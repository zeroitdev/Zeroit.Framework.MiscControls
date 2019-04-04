// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="RoseTab.cs" company="Zeroit Dev Technologies">
//    This program is for creating various controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Reflection;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.MiscControls
{

    #region Enums
    /// <summary>
    /// Enum representing the Tab Render Style for <c><see cref="RoseTabControl" /></c>.
    /// </summary>
    public enum TabRenderStyle
    {
        /// <summary>
        /// The custom
        /// </summary>
        Custom,
        /// <summary>
        /// The graphic
        /// </summary>
        Graphic
    }
    #endregion

    /// <summary>
    /// A class collection for rendering a rose tab.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.NativeWindow" />
    /// <seealso cref="System.IDisposable" />
    public class RoseTabControl : NativeWindow, IDisposable
    {
        #region Constants
        // alphablend
        /// <summary>
        /// The ac source over
        /// </summary>
        private const byte AC_SRC_OVER = 0x00;
        /// <summary>
        /// The ac source alpha
        /// </summary>
        private const byte AC_SRC_ALPHA = 0x01;
        // window messages
        /// <summary>
        /// The wm mousemove
        /// </summary>
        private const int WM_MOUSEMOVE = 0x200;
        /// <summary>
        /// The wm mouseleave
        /// </summary>
        private const int WM_MOUSELEAVE = 0x2A3;
        /// <summary>
        /// The wm lbuttondown
        /// </summary>
        private const int WM_LBUTTONDOWN = 0x201;
        /// <summary>
        /// The wm lbuttonup
        /// </summary>
        private const int WM_LBUTTONUP = 0x202;
        /// <summary>
        /// The wm mousehover
        /// </summary>
        private const int WM_MOUSEHOVER = 0x2A1;
        /// <summary>
        /// The wm paint
        /// </summary>
        private const int WM_PAINT = 0xF;
        // tab messages
        /// <summary>
        /// The tcif state
        /// </summary>
        private const int TCIF_STATE = 0x0010;
        /// <summary>
        /// The TCM first
        /// </summary>
        private const int TCM_FIRST = 0x1300;
        /// <summary>
        /// The TCM getimagelist
        /// </summary>
        private const int TCM_GETIMAGELIST = (TCM_FIRST + 2);
        /// <summary>
        /// The TCM setimagelist
        /// </summary>
        private const int TCM_SETIMAGELIST = (TCM_FIRST + 3);
        /// <summary>
        /// The TCM getitemcount
        /// </summary>
        private const int TCM_GETITEMCOUNT = (TCM_FIRST + 4);
        /// <summary>
        /// The TCM getitema
        /// </summary>
        private const int TCM_GETITEMA = (TCM_FIRST + 5);
        /// <summary>
        /// The TCM getitemw
        /// </summary>
        private const int TCM_GETITEMW = (TCM_FIRST + 60);
        /// <summary>
        /// The TCM setitema
        /// </summary>
        private const int TCM_SETITEMA = (TCM_FIRST + 6);
        /// <summary>
        /// The TCM setitemw
        /// </summary>
        private const int TCM_SETITEMW = (TCM_FIRST + 61);
        /// <summary>
        /// The TCM insertitema
        /// </summary>
        private const int TCM_INSERTITEMA = (TCM_FIRST + 7);
        /// <summary>
        /// The TCM insertitemw
        /// </summary>
        private const int TCM_INSERTITEMW = (TCM_FIRST + 62);
        /// <summary>
        /// The TCM deleteitem
        /// </summary>
        private const int TCM_DELETEITEM = (TCM_FIRST + 8);
        /// <summary>
        /// The TCM deleteallitems
        /// </summary>
        private const int TCM_DELETEALLITEMS = (TCM_FIRST + 9);
        /// <summary>
        /// The TCM getitemrect
        /// </summary>
        private const int TCM_GETITEMRECT = (TCM_FIRST + 10);
        /// <summary>
        /// The TCN first
        /// </summary>
        private const int TCN_FIRST = 550;
        /// <summary>
        /// The TCN last
        /// </summary>
        private const int TCN_LAST = 580;
        /// <summary>
        /// The TCN keydown
        /// </summary>
        private const int TCN_KEYDOWN = (TCN_FIRST - 0);
        /// <summary>
        /// The TCN selchange
        /// </summary>
        private const int TCN_SELCHANGE = (TCN_FIRST - 1);
        /// <summary>
        /// The TCN selchanging
        /// </summary>
        private const int TCN_SELCHANGING = (TCN_FIRST - 2);
        /// <summary>
        /// The TCN getobject
        /// </summary>
        private const int TCN_GETOBJECT = (TCN_FIRST - 3);
        /// <summary>
        /// The tcis buttonpressed
        /// </summary>
        private const int TCIS_BUTTONPRESSED = 0x0001;
        /// <summary>
        /// The tcis highlighted
        /// </summary>
        private const int TCIS_HIGHLIGHTED = 0x0002;
        #endregion

        #region Structs
        /// <summary>
        /// Struct PAINTSTRUCT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct PAINTSTRUCT
        {
            /// <summary>
            /// The HDC
            /// </summary>
            internal IntPtr hdc;
            /// <summary>
            /// The f erase
            /// </summary>
            internal int fErase;
            /// <summary>
            /// The rc paint
            /// </summary>
            internal RECT rcPaint;
            /// <summary>
            /// The f restore
            /// </summary>
            internal int fRestore;
            /// <summary>
            /// The f inc update
            /// </summary>
            internal int fIncUpdate;
            /// <summary>
            /// The reserved1
            /// </summary>
            internal int Reserved1;
            /// <summary>
            /// The reserved2
            /// </summary>
            internal int Reserved2;
            /// <summary>
            /// The reserved3
            /// </summary>
            internal int Reserved3;
            /// <summary>
            /// The reserved4
            /// </summary>
            internal int Reserved4;
            /// <summary>
            /// The reserved5
            /// </summary>
            internal int Reserved5;
            /// <summary>
            /// The reserved6
            /// </summary>
            internal int Reserved6;
            /// <summary>
            /// The reserved7
            /// </summary>
            internal int Reserved7;
            /// <summary>
            /// The reserved8
            /// </summary>
            internal int Reserved8;
        }

        /// <summary>
        /// Struct RECT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="RECT"/> struct.
            /// </summary>
            /// <param name="X">The x.</param>
            /// <param name="Y">The y.</param>
            /// <param name="Width">The width.</param>
            /// <param name="Height">The height.</param>
            internal RECT(int X, int Y, int Width, int Height)
            {
                this.Left = X;
                this.Top = Y;
                this.Right = Width;
                this.Bottom = Height;
            }
            /// <summary>
            /// The left
            /// </summary>
            internal int Left;
            /// <summary>
            /// The top
            /// </summary>
            internal int Top;
            /// <summary>
            /// The right
            /// </summary>
            internal int Right;
            /// <summary>
            /// The bottom
            /// </summary>
            internal int Bottom;
        }

        /// <summary>
        /// Struct BLENDFUNCTION
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct BLENDFUNCTION
        {
            /// <summary>
            /// The blend op
            /// </summary>
            byte BlendOp;
            /// <summary>
            /// The blend flags
            /// </summary>
            byte BlendFlags;
            /// <summary>
            /// The source constant alpha
            /// </summary>
            byte SourceConstantAlpha;
            /// <summary>
            /// The alpha format
            /// </summary>
            byte AlphaFormat;

            /// <summary>
            /// Initializes a new instance of the <see cref="BLENDFUNCTION"/> struct.
            /// </summary>
            /// <param name="op">The op.</param>
            /// <param name="flags">The flags.</param>
            /// <param name="alpha">The alpha.</param>
            /// <param name="format">The format.</param>
            internal BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
            {
                BlendOp = op;
                BlendFlags = flags;
                SourceConstantAlpha = alpha;
                AlphaFormat = format;
            }
        }
        #endregion

        #region API
        /// <summary>
        /// Begins the paint.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="ps">The ps.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        /// <summary>
        /// Ends the paint.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="ps">The ps.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref RECT lParam);

        /// <summary>
        /// Gets the cursor position.
        /// </summary>
        /// <param name="lpPoint">The lp point.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Point lpPoint);

        /// <summary>
        /// Pts the in rect.
        /// </summary>
        /// <param name="lprc">The LPRC.</param>
        /// <param name="pt">The pt.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PtInRect([In] ref RECT lprc, Point pt);

        /// <summary>
        /// Gets the window rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lpRect">The lp rect.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        /// <summary>
        /// Offsets the rect.
        /// </summary>
        /// <param name="lpRect">The lp rect.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        private extern static int OffsetRect(ref RECT lpRect, int x, int y);

        /// <summary>
        /// Gets the client rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="r">The r.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

        /// <summary>
        /// Alphas the blend.
        /// </summary>
        /// <param name="hdcDest">The HDC dest.</param>
        /// <param name="nXOriginDest">The n x origin dest.</param>
        /// <param name="nYOriginDest">The n y origin dest.</param>
        /// <param name="nWidthDest">The n width dest.</param>
        /// <param name="nHeightDest">The n height dest.</param>
        /// <param name="hdcSrc">The HDC source.</param>
        /// <param name="nXOriginSrc">The n x origin source.</param>
        /// <param name="nYOriginSrc">The n y origin source.</param>
        /// <param name="nWidthSrc">The n width source.</param>
        /// <param name="nHeightSrc">The n height source.</param>
        /// <param name="blendFunction">The blend function.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll", EntryPoint = "GdiAlphaBlend")]
        private static extern bool AlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,
        IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, BLENDFUNCTION blendFunction);

        /// <summary>
        /// Stretches the BLT.
        /// </summary>
        /// <param name="hDest">The h dest.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <param name="hdcSrc">The HDC source.</param>
        /// <param name="sX">The s x.</param>
        /// <param name="sY">The s y.</param>
        /// <param name="nWidthSrc">The n width source.</param>
        /// <param name="nHeightSrc">The n height source.</param>
        /// <param name="dwRop">The dw rop.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool StretchBlt(IntPtr hDest, int X, int Y, int nWidth, int nHeight, IntPtr hdcSrc,
        int sX, int sY, int nWidthSrc, int nHeightSrc, int dwRop);

        /// <summary>
        /// Selects the object.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="hObject">The h object.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        /// <summary>
        /// Validates the rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lpRect">The lp rect.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool ValidateRect(IntPtr hWnd, ref RECT lpRect);

        /// <summary>
        /// Bits the BLT.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="nXDest">The n x dest.</param>
        /// <param name="nYDest">The n y dest.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <param name="hdcSrc">The HDC source.</param>
        /// <param name="nXSrc">The n x source.</param>
        /// <param name="nYSrc">The n y source.</param>
        /// <param name="dwRop">The dw rop.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        /// <summary>
        /// Inflates the rect.
        /// </summary>
        /// <param name="lpRect">The lp rect.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        private extern static int InflateRect(ref RECT lpRect, int x, int y);
        #endregion

        #region Fields
        // tab
        /// <summary>
        /// The b painting
        /// </summary>
        private bool _bPainting = false;
        /// <summary>
        /// The tab control WND
        /// </summary>
        private IntPtr _tabControlWnd = IntPtr.Zero;
        /// <summary>
        /// The tab header bitmap
        /// </summary>
        private Bitmap _tabHeaderBitmap;
        /// <summary>
        /// The tab border color
        /// </summary>
        private Color _tabBorderColor = Color.DarkGray;
        /// <summary>
        /// The tab gradient begin
        /// </summary>
        private Color _tabGradientBegin = Color.White;
        /// <summary>
        /// The tab gradient end
        /// </summary>
        private Color _tabGradientEnd = Color.Silver;
        /// <summary>
        /// The tab fore color
        /// </summary>
        private Color _tabForeColor = Color.Black;
        /// <summary>
        /// The tab focused color
        /// </summary>
        private Color _tabFocusedColor = Color.CornflowerBlue;
        /// <summary>
        /// The tab focused fore color
        /// </summary>
        private Color _tabFocusedForeColor = Color.White;
        /// <summary>
        /// The tab selected color
        /// </summary>
        private Color _tabSelectedColor = Color.White;
        /// <summary>
        /// The tab selected fore color
        /// </summary>
        private Color _tabSelectedForeColor = Color.Black;
        /// <summary>
        /// The tab strip gradient blend
        /// </summary>
        private Blend _tabStripGradientBlend = new Blend();
        /// <summary>
        /// The tab render style
        /// </summary>
        private TabRenderStyle _tabRenderStyle = TabRenderStyle.Custom;
        // tooltip
        /// <summary>
        /// The tool tip shown
        /// </summary>
        private bool _toolTipShown = false;
        /// <summary>
        /// The tool tip enable
        /// </summary>
        private bool _toolTipEnable = false;
        /// <summary>
        /// The tool tip use icon
        /// </summary>
        private bool _toolTipUseIcon = false;
        /// <summary>
        /// The tool tip right to left
        /// </summary>
        private bool _toolTipRightToLeft = false;
        /// <summary>
        /// The tool tip maximum length
        /// </summary>
        private int _toolTipMaximumLength = 200;
        /// <summary>
        /// The tool tip delay time
        /// </summary>
        private int _toolTipDelayTime = 1000;
        /// <summary>
        /// The tool tip visible time
        /// </summary>
        private int _toolTipVisibleTime = 2000;
        /// <summary>
        /// The tool tip gradient begin
        /// </summary>
        private Color _toolTipGradientBegin = Color.White;
        /// <summary>
        /// The tool tip gradient end
        /// </summary>
        private Color _toolTipGradientEnd = Color.Black;
        /// <summary>
        /// The tool tip fore color
        /// </summary>
        private Color _toolTipForeColor = Color.Black;
        /// <summary>
        /// The last focused page
        /// </summary>
        private TabPage _lastFocusedPage;
        /// <summary>
        /// The tool tip
        /// </summary>
        private RoseToolTip _toolTip;
        /// <summary>
        /// The tool tip text
        /// </summary>
        private Dictionary<TabPage, string> _toolTipText = new Dictionary<TabPage, string>();
        /// <summary>
        /// The tool tip title
        /// </summary>
        private Dictionary<TabPage, string> _toolTipTitle = new Dictionary<TabPage, string>();
        #endregion  

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="RoseTabControl" /> class.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="skin">The skin.</param>
        /// <exception cref="System.Exception">
        /// The tab control handle is invalid.
        /// or
        /// The image provided is invalid.
        /// </exception>
        /// <exception cref="Exception">The tab control handle is invalid.
        /// or
        /// The image provided is invalid.</exception>
        public RoseTabControl(IntPtr hWnd, Bitmap skin)
        {
            if (hWnd == IntPtr.Zero)
                throw new Exception("The tab control handle is invalid.");
            if (skin == null)
                throw new Exception("The image provided is invalid.");
            TabHeaderGraphic = skin;
            Init();
            _tabControlWnd = hWnd;
            this.AssignHandle(hWnd);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoseTabControl" /> class.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <exception cref="System.Exception">The tab control handle is invalid.</exception>
        /// <exception cref="Exception">The tab control handle is invalid.</exception>
        public RoseTabControl(IntPtr hWnd)
        {
            if (hWnd == IntPtr.Zero)
                throw new Exception("The tab control handle is invalid.");
            Init();
            _tabControlWnd = hWnd;
            this.AssignHandle(hWnd);
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Init()
        {
            _tabStripGradientBlend.Positions = new float[] { 0f, .3f, .4f, .9f, 1f };
            _tabStripGradientBlend.Factors = new float[] { 0f, .2f, .5f, 1f, .6f };
        }
        #endregion

        #region RoseToolTip Events
        /// <summary>
        /// Handles the ControlAdded event of the tab control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ControlEventArgs"/> instance containing the event data.</param>
        private void tab_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control.GetType() == typeof(TabPage))
            {
                TabPage item = (TabPage)e.Control;
                if (ToolTipEnable == true && !String.IsNullOrEmpty(item.ToolTipText))
                {
                    _toolTipText.Add(item, item.ToolTipText);
                    item.ToolTipText = "";
                }
            }
        }

        /// <summary>
        /// Handles the ControlRemoved event of the tab control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ControlEventArgs"/> instance containing the event data.</param>
        private void tab_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control.GetType() == typeof(TabPage))
            {
                if (_toolTipText.ContainsKey((TabPage)e.Control))
                    _toolTipText.Remove((TabPage)e.Control);
                if (_toolTipTitle.ContainsKey((TabPage)e.Control))
                    _toolTipTitle.Remove((TabPage)e.Control);
            }
        }

        /// <summary>
        /// Handles the HandleCreated event of the tab control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tab_HandleCreated(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TabControl))
            {
                TabControl tab = (TabControl)sender;
                _tabControlWnd = tab.Handle;
            }
        }

        /// <summary>
        /// Handles the HandleDestroyed event of the tab control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tab_HandleDestroyed(object sender, EventArgs e)
        {
            if (_toolTip != null)
                _toolTip.Dispose();
        }

        /// <summary>
        /// Handles the MouseDown event of the tab control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void tab_MouseDown(object sender, MouseEventArgs e)
        {
            toolTipStop();
        }

        /// <summary>
        /// Handles the MouseLeave event of the tab control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tab_MouseLeave(object sender, EventArgs e)
        {
            toolTipStop();
        }

        /// <summary>
        /// Handles the MouseMove event of the tab control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void tab_MouseMove(object sender, MouseEventArgs e)
        {
            TabPage item = overPage();
            if (item != null)
                toolTipStart(item);
        }
        #endregion

        #region Properties
        #region Tab Control
        /// <summary>
        /// Get/Set the tab border color.
        /// </summary>
        /// <value>The color of the tab border.</value>
        public Color TabBorderColor
        {
            get { return _tabBorderColor; }
            set { _tabBorderColor = value; }
        }

        /// <summary>
        /// Get/Set the drawing render style.
        /// </summary>
        /// <value>The tab drawing style.</value>
        public TabRenderStyle TabDrawingStyle
        {
            get { return _tabRenderStyle; }
            set { _tabRenderStyle = value; }
        }

        /// <summary>
        /// Get/Set the ForeColor.
        /// </summary>
        /// <value>The color of the tab fore.</value>
        public Color TabForeColor
        {
            get { return _tabForeColor; }
            set { _tabForeColor = value; }
        }

        /// <summary>
        /// Get/Set the focused ForeColor.
        /// </summary>
        /// <value>The color of the tab focused fore.</value>
        public Color TabFocusedForeColor
        {
            get { return _tabFocusedForeColor; }
            set { _tabFocusedForeColor = value; }
        }

        /// <summary>
        /// Get/Set the tab focused Color.
        /// </summary>
        /// <value>The color of the tab focused.</value>
        public Color TabFocusedColor
        {
            get { return _tabFocusedColor; }
            set { _tabFocusedColor = value; }
        }

        /// <summary>
        /// Get/Set the starting color of the button fade gradient.
        /// </summary>
        /// <value>The tab gradient begin.</value>
        public Color TabGradientBegin
        {
            get { return _tabGradientBegin; }
            set { _tabGradientBegin = value; }
        }

        /// <summary>
        /// Get/Set the ending color of the button fade gradient.
        /// </summary>
        /// <value>The tab gradient end.</value>
        public Color TabGradientEnd
        {
            get { return _tabGradientEnd; }
            set { _tabGradientEnd = value; }
        }

        /// <summary>
        /// Get/Set the blend factor of the gradient.
        /// </summary>
        /// <value>The tab gradient blend.</value>
        public Blend TabGradientBlend
        {
            get { return _tabStripGradientBlend; }
            set { _tabStripGradientBlend = value; }
        }

        /// <summary>
        /// Get/Set the bitmap used for the tab header.
        /// </summary>
        /// <value>The tab header graphic.</value>
        public Bitmap TabHeaderGraphic
        {
            get { return _tabHeaderBitmap; }
            set { _tabHeaderBitmap = value; }
        }

        /// <summary>
        /// Get/Set the tab selected Color.
        /// </summary>
        /// <value>The color of the tab selected.</value>
        public Color TabSelectedColor
        {
            get { return _tabSelectedColor; }
            set { _tabSelectedColor = value; }
        }

        /// <summary>
        /// Get/Set the tab selected Color.
        /// </summary>
        /// <value>The color of the tab selected fore.</value>
        public Color TabSelectedForeColor
        {
            get { return _tabSelectedForeColor; }
            set { _tabSelectedForeColor = value; }
        }
        #endregion

        #region RoseToolTip
        /// <summary>
        /// The amount of time in milliseconds before the RoseToolTip appears.
        /// </summary>
        /// <value>The tool tip delay time.</value>
        public int ToolTipDelayTime
        {
            get { return _toolTipDelayTime; }
            set
            {
                _toolTipDelayTime = value;
                if (_toolTip != null)
                    _toolTip.DelayTime = value;
            }
        }

        /// <summary>
        /// Get/Set the ToolStrip enabled property.
        /// </summary>
        /// <value><c>true</c> if [tool tip enable]; otherwise, <c>false</c>.</value>
        public bool ToolTipEnable
        {
            get { return _toolTipEnable; }
            set { _toolTipEnable = value; }
        }

        /// <summary>
        /// Get/Set the forecolor of drop down menu items.
        /// </summary>
        /// <value>The color of the tool tip fore.</value>
        public Color ToolTipForeColor
        {
            get { return _toolTipForeColor; }
            set
            {
                _toolTipForeColor = value;
                if (_toolTip != null)
                    _toolTip.ForeColor = value;
            }
        }

        /// <summary>
        /// Get/Set the starting color of the gradient.
        /// </summary>
        /// <value>The tool tip gradient begin.</value>
        public Color ToolTipGradientBegin
        {
            get { return _toolTipGradientBegin; }
            set
            {
                _toolTipGradientBegin = value;
                if (_toolTip != null)
                    _toolTip.GradientBegin = value;
            }
        }

        /// <summary>
        /// Get/Set the ending color of the gradient.
        /// </summary>
        /// <value>The tool tip gradient end.</value>
        public Color ToolTipGradientEnd
        {
            get { return _toolTipGradientEnd; }
            set
            {
                _toolTipGradientEnd = value;
                if (_toolTip != null)
                    _toolTip.GradientEnd = value;
            }
        }

        /// <summary>
        /// The maximum length of the RoseToolTip in pixels.
        /// </summary>
        /// <value>The maximum length of the tool tip.</value>
        public int ToolTipMaximumLength
        {
            get { return _toolTipMaximumLength; }
            set
            {
                _toolTipMaximumLength = value;
                if (_toolTip != null)
                    _toolTip.MaximumLength = value;
            }
        }

        /// <summary>
        /// Position the RoseToolTip text right to left.
        /// </summary>
        /// <value><c>true</c> if [tool tip right to left]; otherwise, <c>false</c>.</value>
        public bool ToolTipRightToLeft
        {
            get { return _toolTipRightToLeft; }
            set
            {
                _toolTipRightToLeft = value;
                if (_toolTip != null)
                    _toolTip.TextRightToLeft = value;
            }
        }

        /// <summary>
        /// Display the buttons icon in the RoseToolTip.
        /// </summary>
        /// <value><c>true</c> if [tool tip use icon]; otherwise, <c>false</c>.</value>
        public bool ToolTipUseIcon
        {
            get { return _toolTipUseIcon; }
            set
            {
                _toolTipUseIcon = value;
                if (_toolTip != null)
                    _toolTip.UseIcon = value;
            }
        }

        /// <summary>
        /// The length of time in milliseconds that the RoseToolTip remains visible.
        /// </summary>
        /// <value>The tool tip visible time.</value>
        public int ToolTipVisibleTime
        {
            get { return _toolTipVisibleTime; }
            set
            {
                _toolTipVisibleTime = value;
                if (_toolTip != null)
                    _toolTip.VisibleTime = value;
            }
        }
        #endregion
        #endregion

        #region Methods
        #region Tab Control
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.ReleaseHandle();
            _tabHeaderBitmap.Dispose();
        }

        /// <summary>
        /// Draws the focused tab.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="gradient">The gradient.</param>
        private void drawFocusedTab(Graphics g, Rectangle bounds, LinearGradientMode gradient)
        {
            // draw using anti alias
            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
            {
                // create the path
                using (GraphicsPath buttonPath = createRoundRectanglePath(
                    g,
                    bounds.X, bounds.Y,
                    bounds.Width, bounds.Height,
                    1.0f))
                {
                    // draw the outer edge
                    using (Pen borderPen = new Pen(Color.FromArgb(50, Color.SlateGray), 1f))
                        g.DrawPath(borderPen, buttonPath);
                }
                bounds.Inflate(-1, -1);

                using (GraphicsPath buttonPath = createRoundRectanglePath(
                    g,
                    bounds.X, bounds.Y,
                    bounds.Width, bounds.Height,
                    1.0f))
                {
                    // draw the inner edge
                    using (Pen borderPen = new Pen(Color.FromArgb(50, TabBorderColor), 1.5f))
                        g.DrawPath(borderPen, buttonPath);

                    // create a thin gradient cover
                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(
                        bounds,
                        Color.FromArgb(50, Color.FromArgb(200, Color.White)),
                        Color.FromArgb(50, TabGradientEnd),
                        gradient))
                    {
                        // shift the blend factors
                        Blend blend = new Blend();
                        blend.Positions = new float[] { 0f, .3f, .6f, 1f };
                        blend.Factors = new float[] { 0f, .5f, .8f, .2f };
                        fillBrush.Blend = blend;
                        // fill the path
                        g.FillPath(fillBrush, buttonPath);
                    }
                }
            }
        }

        /// <summary>
        /// Draws the tab control.
        /// </summary>
        private void drawTabControl()
        {
            // buffer drawing
            cStoreDc tempDc = new cStoreDc();
            int state = 0;
            RECT tabRect = new RECT();
            RECT ctlRect = new RECT();
            Rectangle headerRect = new Rectangle();
            TabControl tab = (TabControl)Control.FromHandle(_tabControlWnd);
            TabAlignment align = tab.Alignment;
            Rectangle fillRect = new Rectangle();

            // get size and dimension buffer dc
            GetWindowRect(_tabControlWnd, ref ctlRect);
            OffsetRect(ref ctlRect, -ctlRect.Left, -ctlRect.Top);
            tempDc.Width = ctlRect.Right;
            tempDc.Height = ctlRect.Bottom;
            Graphics g = Graphics.FromHdc(tempDc.Hdc);

            fillRect = new Rectangle(0, 0, ctlRect.Right, ctlRect.Bottom);
            // fill and backfill //
            if (tab.TabCount > 0)
            {
                // fill transparent section
                headerRect = new Rectangle(0, 0, ctlRect.Right, tab.DisplayRectangle.Y);
                using (Brush fillBrush = new SolidBrush(tab.Parent.BackColor))
                    g.FillRectangle(fillBrush, headerRect);
                // backfill the client
                headerRect = new Rectangle(0, tab.DisplayRectangle.Y, ctlRect.Right, ctlRect.Bottom - tab.DisplayRectangle.Y);
                using (Brush fillBrush = new SolidBrush(tab.Parent.BackColor))
                    g.FillRectangle(fillBrush, tab.ClientRectangle);
            }
            else
            {
                using (Brush fillBrush = new SolidBrush(Color.White))
                    g.FillRectangle(fillBrush, fillRect);
            }

            // draw the frame //
            //using (Pen darkPen = new Pen(Color.FromKnownColor(KnownColor.ControlDark)))
            using (Pen darkPen = new Pen(TabBorderColor)) //tester
            {
                Rectangle r = tab.DisplayRectangle;
                r.Inflate(1, 1);
                r.X--;
                r.Y--;
                g.DrawRectangle(darkPen, r);
            }

            // draw the tab headers //
            for (int i = 0; i < tab.TabCount; i++)
            {
                // get the header size
                SendMessage(_tabControlWnd, TCM_GETITEMRECT, i, ref tabRect);

                // state
                if (tab.Enabled == false)
                    state = 3;
                else if (tab.SelectedTab == tab.TabPages[i])
                    state = 2;
                else if (Hovering(tabRect))
                    state = 1;
                else
                    state = 0;

                // bitmap mode //
                if (TabDrawingStyle == TabRenderStyle.Graphic && _tabHeaderBitmap != null)
                {
                    int width = _tabHeaderBitmap.Width / 4;
                    // create a new bitmap
                    Bitmap bm;
                    Bitmap cl;
                    int xsize = (state != 2) ? (tabRect.Bottom - tabRect.Top) : (tabRect.Bottom - tabRect.Top) - 2;

                    // to maintain a constant border depth while stretching the bitmap //
                    if (align == TabAlignment.Bottom || align == TabAlignment.Top)
                        bm = new Bitmap(tabRect.Right - tabRect.Left, xsize);
                    else
                        bm = new Bitmap(xsize, tabRect.Right - tabRect.Left);

                    Graphics gcl = Graphics.FromImage(bm);
                    // clone the inner portion
                    cl = _tabHeaderBitmap.Clone(new Rectangle((state * width) + 2, 2, width - 4, _tabHeaderBitmap.Height - 2), System.Drawing.Imaging.PixelFormat.DontCare);

                    // draw to new bmp
                    if (align == TabAlignment.Bottom || align == TabAlignment.Top)
                        gcl.DrawImage(cl, new Rectangle(2, 2, tabRect.Right - tabRect.Left, xsize));
                    else
                        gcl.DrawImage(cl, new Rectangle(2, 2, xsize, tabRect.Right - tabRect.Left));

                    // clone and draw the edges
                    // left
                    cl = _tabHeaderBitmap.Clone(new Rectangle(state * width, 0, 2, _tabHeaderBitmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                    gcl.DrawImage(cl, new Rectangle(0, 0, 2, xsize));
                    cl.Dispose();
                    // top
                    cl = _tabHeaderBitmap.Clone(new Rectangle(state * width + 2, 0, width - 4, 2), System.Drawing.Imaging.PixelFormat.DontCare);
                    gcl.DrawImage(cl, new Rectangle(2, 0, bm.Width - 4, 2));
                    cl.Dispose();
                    //right
                    cl = _tabHeaderBitmap.Clone(new Rectangle((state * width) + (width - 2), 0, 2, _tabHeaderBitmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                    gcl.DrawImage(cl, new Rectangle(bm.Width - 2, 0, 2, xsize));
                    cl.Dispose();
                    gcl.Dispose();
                    Rectangle dstRect = new Rectangle();

                    // set the base drawing coordinates //
                    switch (align)
                    {
                        case TabAlignment.Bottom:
                            dstRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
                            bm.RotateFlip(RotateFlipType.Rotate180FlipX);
                            if (state == 2)
                            {
                                dstRect.Height++;
                                dstRect.Y--;
                            }
                            break;
                        case TabAlignment.Left:
                            dstRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
                            bm.RotateFlip(RotateFlipType.Rotate90FlipX);
                            if (state == 2)
                                dstRect.Width++;
                            break;
                        case TabAlignment.Right:
                            dstRect = new Rectangle(tabRect.Left - 1, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
                            bm.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            if (state == 2)
                            {
                                dstRect.Width++;
                                dstRect.X--;
                            }
                            break;
                        case TabAlignment.Top:
                            dstRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
                            if (state == 2)
                                dstRect.Height++;
                            break;
                    }
                    // draw the image to temp dc
                    width = tabRect.Right - tabRect.Left;
                    Rectangle srcRect = new Rectangle(0, 0, bm.Width, bm.Height);
                    g.DrawImage(bm, dstRect, srcRect, GraphicsUnit.Pixel);
                    bm.Dispose();
                }
                // custom draw //
                else
                {
                    Color clBegin = TabGradientBegin;
                    Color clEnd = TabGradientEnd;
                    SendMessage(_tabControlWnd, TCM_GETITEMRECT, i, ref tabRect);
                    headerRect = new Rectangle(tabRect.Left, tabRect.Top, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top);
                    // gradient color assignment
                    switch (align)
                    {
                        case TabAlignment.Bottom:
                            headerRect.Y -= 2;
                            clBegin = TabGradientBegin;
                            clEnd = (state == 2) ? TabSelectedColor : TabGradientEnd;
                            break;
                        case TabAlignment.Left:
                            clBegin = TabGradientBegin;
                            clEnd = (state == 2) ? TabSelectedColor : TabGradientEnd;
                            break;
                        case TabAlignment.Right:
                            headerRect.X -= 2;
                            clEnd = (state == 2) ? TabSelectedColor : TabGradientEnd;
                            clBegin = TabGradientBegin;
                            break;
                        case TabAlignment.Top:
                            clBegin = TabGradientBegin;
                            clEnd = (state == 2) ? TabSelectedColor : TabGradientEnd;
                            break;
                    }
                    if (tab.Enabled == false)
                    {
                        clBegin = Color.LightGray;
                        clEnd = Color.LightGray;
                    }
                    // draw the gradient
                    fillRect = headerRect;
                    fillRect.Inflate(-1, -1);
                    fillRect.Width++;
                    fillRect.Height++;
                    drawBlendedGradient(g,
                        (align == TabAlignment.Bottom || align == TabAlignment.Top) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal,
                        clBegin,
                        (state == 1) ? TabFocusedColor : clEnd,
                        fillRect,
                        TabGradientBlend);
                    if (state == 1)
                    {
                        // selection mask
                        drawFocusedTab(g, headerRect, LinearGradientMode.Vertical);
                    }
                    else if (state == 2)
                    {
                        // draw selected tab header frame
                        using (Pen darkPen = new Pen(TabBorderColor))
                            g.DrawRectangle(darkPen, headerRect);
                        // cover edge
                        switch (align)
                        {
                            case TabAlignment.Bottom:
                                using (Pen edgePen = new Pen(clBegin))
                                    g.DrawLine(edgePen, new Point(headerRect.Left + 1, headerRect.Top), new Point(headerRect.Right - 1, headerRect.Top));
                                break;
                            case TabAlignment.Left:
                                using (Pen edgePen = new Pen(clBegin))
                                    g.DrawLine(edgePen, new Point(headerRect.Right, headerRect.Top + 1), new Point(headerRect.Right, headerRect.Bottom - 1));
                                break;
                            case TabAlignment.Right:
                                using (Pen edgePen = new Pen(clBegin))
                                    g.DrawLine(edgePen, new Point(headerRect.Left, headerRect.Top + 1), new Point(headerRect.Left, headerRect.Bottom - 1));
                                break;
                            case TabAlignment.Top:
                                using (Pen edgePen = new Pen(clBegin))
                                    g.DrawLine(edgePen, new Point(headerRect.Left + 1, headerRect.Bottom), new Point(headerRect.Right - 1, headerRect.Bottom));
                                break;
                        }
                    }
                    else
                    {
                        // frame inactive tabs
                        using (Pen darkPen = new Pen(Color.FromArgb(100, TabBorderColor)))
                            g.DrawRectangle(darkPen, headerRect);
                    }
                }

                // draw icon //
                int hoffset = 4;
                int voffset = 4;
                if (tab.ImageList != null)
                {
                    // calculate offsets and draw the icon
                    if (tab.TabPages[i].ImageIndex > -1)
                    {
                        if (align == TabAlignment.Top || align == TabAlignment.Bottom)
                        {
                            voffset = ((tabRect.Bottom - tabRect.Top) - tab.ImageList.Images[i].Size.Height) / 2;
                            hoffset = 4;
                            tab.ImageList.Draw(g, new Point(tabRect.Left + hoffset, tabRect.Top + voffset), tab.TabPages[i].ImageIndex);
                            hoffset += tab.ImageList.Images[i].Size.Width;
                        }
                        else if (align == TabAlignment.Right)
                        {
                            hoffset = ((tabRect.Right - tabRect.Left) - tab.ImageList.Images[i].Size.Width) / 2;
                            voffset = 4;
                            tab.ImageList.Draw(g, new Point(tabRect.Left + hoffset, tabRect.Top + voffset), tab.TabPages[i].ImageIndex);
                            voffset += tab.ImageList.Images[i].Size.Height;
                        }
                        else if (align == TabAlignment.Left)
                        {
                            hoffset = ((tabRect.Right - tabRect.Left) - tab.ImageList.Images[i].Size.Width) / 2;
                            voffset = (tab.ImageList.Images[i].Size.Height + 4);
                            tab.ImageList.Draw(g, new Point(tabRect.Left + hoffset, tabRect.Bottom - voffset), tab.TabPages[i].ImageIndex);
                            voffset = tab.ImageList.Images[i].Size.Height + 4;
                        }
                    }
                }

                // draw text //
                // text offsets
                SizeF sz = g.MeasureString(tab.TabPages[i].Text, tab.Font);
                if (align == TabAlignment.Top || align == TabAlignment.Bottom)
                    voffset = ((tabRect.Bottom - tabRect.Top) - (int)sz.Height) / 2;
                else
                    hoffset = ((tabRect.Right - tabRect.Left) - (int)sz.Height) / 2;

                // text graphics
                Graphics gx = Graphics.FromHdcInternal(tempDc.Hdc);
                using (StringFormat sf = new StringFormat())
                {
                    gx.SmoothingMode = SmoothingMode.AntiAlias;
                    gx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    // poition and format
                    if (align == TabAlignment.Top || align == TabAlignment.Bottom)
                    {
                        hoffset += tabRect.Left;
                        voffset += tabRect.Top;
                    }
                    else if (align == TabAlignment.Left)
                    {
                        // create 'mirrored' text
                        // vertical text
                        sf.FormatFlags = StringFormatFlags.DirectionVertical;
                        // create a new matrix and rotate
                        Matrix mt = new Matrix();
                        mt.Rotate(180f);
                        // adjust offsets
                        voffset += -tabRect.Bottom;
                        hoffset += -tabRect.Right;
                        // apply the transform
                        gx.Transform = mt;

                    }
                    else if (align == TabAlignment.Right)
                    {
                        sf.FormatFlags = StringFormatFlags.DirectionVertical;
                        hoffset += tabRect.Left;
                        voffset += tabRect.Top;
                    }
                    // rtl
                    if (tab.RightToLeftLayout)
                        sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                    Color foreColor;
                    if (state == 1)
                        foreColor = TabFocusedForeColor;
                    else if (state == 2)
                        foreColor = TabSelectedForeColor;
                    else
                        foreColor = TabForeColor;
                    // draw the text
                    using (Brush captionBrush = new SolidBrush(foreColor))
                        gx.DrawString(tab.TabPages[i].Text, tab.Font, captionBrush, new RectangleF(hoffset, voffset, tabRect.Right - tabRect.Left, tabRect.Bottom - tabRect.Top), sf);
                }
                gx.Dispose();
            }

            g.Dispose();
            // draw the buffer to the control
            g = Graphics.FromHwnd(_tabControlWnd);
            BitBlt(g.GetHdc(), 0, 0, ctlRect.Right, ctlRect.Bottom, tempDc.Hdc, 0, 0, 0xCC0020);
            g.ReleaseHdc();
            tempDc.Dispose();
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Creates the round rectangle path.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath createRoundRectanglePath(Graphics g, float X, float Y, float width, float height, float radius)
        {
            // create a path
            GraphicsPath pathBounds = new GraphicsPath();
            pathBounds.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            pathBounds.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            pathBounds.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            pathBounds.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            pathBounds.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            pathBounds.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            pathBounds.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            pathBounds.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            pathBounds.CloseFigure();
            return pathBounds;
        }

        /// <summary>
        /// Draws the blended gradient.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="begin">The begin.</param>
        /// <param name="end">The end.</param>
        /// <param name="rc">The rc.</param>
        /// <param name="bp">The bp.</param>
        private void drawBlendedGradient(Graphics g, LinearGradientMode mode, Color begin, Color end, Rectangle rc, Blend bp)
        {
            using (LinearGradientBrush hb = new LinearGradientBrush(
                rc,
                begin,
                end,
                mode))
            {
                hb.Blend = bp;
                g.FillRectangle(hb, rc);
            }
        }

        /// <summary>
        /// Hoverings the specified tab header.
        /// </summary>
        /// <param name="tabHeader">The tab header.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool Hovering(RECT tabHeader)
        {
            RECT windowRect = new RECT();
            Point pos = new Point();

            GetWindowRect(_tabControlWnd, ref windowRect);
            OffsetRect(ref tabHeader, windowRect.Left, windowRect.Top);
            GetCursorPos(ref pos);
            if (PtInRect(ref tabHeader, pos))
                return true;
            return false;
        }
        #endregion

        #region RoseToolTip
        /// <summary>
        /// Overs the page.
        /// </summary>
        /// <returns>TabPage.</returns>
        private TabPage overPage()
        {
            TabControl tab = (TabControl)Control.FromHandle(_tabControlWnd);
            RECT tabRect = new RECT();
            if (tab != null)
            {
                for (int i = 0; i < tab.TabCount; i++)
                {
                    SendMessage(_tabControlWnd, TCM_GETITEMRECT, i, ref tabRect);
                    if (Hovering(tabRect))
                        return tab.TabPages[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Tools the tip start.
        /// </summary>
        /// <param name="item">The item.</param>
        private void toolTipStart(TabPage item)
        {
            if ((_toolTip != null) && (ToolTipEnable))
            {
                if (item != _lastFocusedPage)
                {
                    toolTipStop();
                    _lastFocusedPage = item;
                    _toolTipShown = false;
                }
                else
                {
                    if (_toolTipShown)
                        return;
                }
                Rectangle bounds = new Rectangle();
                RECT tabRect = new RECT();
                if (_toolTipText.ContainsKey(item))
                {
                    string caption = _toolTipText[item];
                    string title = String.Empty;
                    if (_toolTipTitle.ContainsKey(item))
                        title = _toolTipTitle[item];
                    TabControl tab = (TabControl)Control.FromHandle(_tabControlWnd);
                    SendMessage(_tabControlWnd, TCM_GETITEMRECT, tab.TabPages.IndexOf(item), ref tabRect);

                    bounds.X = tabRect.Left + 10;
                    bounds.Y = tabRect.Bottom + 10;
                    bounds.Width = ToolTipMaximumLength;
                    bounds.Height = 20;
                    _toolTip.UseIcon = ToolTipUseIcon;
                    Bitmap bmp = null;
                    if (ToolTipUseIcon)
                    {
                        if (tab.ImageList != null && item.ImageIndex > -1)
                        {
                            Size imageSize = tab.ImageList.ImageSize;
                            bmp = new Bitmap(tab.ImageList.Images[item.ImageIndex], imageSize);
                        }
                    }
                    _toolTip.Start(title, caption, bmp, bounds);
                    _toolTipShown = true;
                }
            }
        }

        /// <summary>
        /// Tools the tip stop.
        /// </summary>
        private void toolTipStop()
        {
            if (_toolTip != null)
                _toolTip.Stop();
        }

        /// <summary>
        /// Tools the tip title.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="title">The title.</param>
        public void ToolTipTitle(TabPage item, string title)
        {
            if (!String.IsNullOrEmpty(title))
            {
                _toolTipTitle.Add(item, title);
            }
        }

        /// <summary>
        /// Uses the custom tool tips.
        /// </summary>
        /// <param name="tab">The tab.</param>
        public void UseCustomToolTips(TabControl tab)
        {
            tab.MouseMove += new MouseEventHandler(tab_MouseMove);
            tab.MouseLeave += new EventHandler(tab_MouseLeave);
            tab.MouseDown += new MouseEventHandler(tab_MouseDown);
            tab.ControlAdded += new ControlEventHandler(tab_ControlAdded);
            tab.ControlRemoved += new ControlEventHandler(tab_ControlRemoved);
            tab.HandleDestroyed += new EventHandler(tab_HandleDestroyed);
            tab.HandleCreated += new EventHandler(tab_HandleCreated);
            _toolTipTitle.Clear();
            _toolTipText.Clear();
            foreach (TabPage item in tab.TabPages)
            {
                if (!String.IsNullOrEmpty(item.ToolTipText))
                {
                    _toolTipText.Add(item, item.ToolTipText);
                    item.ToolTipText = "";
                }
            }
            if (_toolTipText.Count > 0)
            {
                _toolTip = new RoseToolTip(tab.Handle);
                _toolTip.TextRightToLeft = ToolTipRightToLeft;
                ToolTipEnable = true;
            }
        }
        #endregion
        #endregion

        #region WndProc
        /// <summary>
        /// Invokes the default window procedure associated with this window.
        /// </summary>
        /// <param name="m">A <see cref="T:System.Windows.Forms.Message" /> that is associated with the current Windows message.</param>
        protected override void WndProc(ref Message m)
        {
            PAINTSTRUCT pntStrct = new PAINTSTRUCT();
            switch (m.Msg)
            {
                case WM_PAINT:
                    if (!_bPainting)
                    {
                        _bPainting = true;
                        // start painting engine
                        BeginPaint(m.HWnd, ref pntStrct);
                        drawTabControl();
                        ValidateRect(m.HWnd, ref pntStrct.rcPaint);
                        // done
                        EndPaint(m.HWnd, ref pntStrct);

                        _bPainting = false;
                    }
                    else
                    {
                        base.WndProc(ref m);
                    }
                    break;

                case WM_MOUSEMOVE:
                    // only necessary if vertically aligned..
                    drawTabControl();
                    base.WndProc(ref m);
                    break;

                case WM_MOUSELEAVE:
                    drawTabControl();
                    base.WndProc(ref m);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion
    }
    #region GraphicsMode
    /// <summary>
    /// Class GraphicsMode.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    internal class GraphicsMode : IDisposable
    {
        #region Instance Fields
        /// <summary>
        /// The graphic copy
        /// </summary>
        private Graphics _graphicCopy;
        /// <summary>
        /// The old mode
        /// </summary>
        private SmoothingMode _oldMode;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the class.
        /// </summary>
        /// <param name="g">Graphics instance.</param>
        /// <param name="mode">Desired Smoothing mode.</param>
        public GraphicsMode(Graphics g, SmoothingMode mode)
        {
            _graphicCopy = g;
            _oldMode = _graphicCopy.SmoothingMode;
            _graphicCopy.SmoothingMode = mode;
        }

        /// <summary>
        /// Revert the SmoothingMode to original setting.
        /// </summary>
        public void Dispose()
        {
            _graphicCopy.SmoothingMode = _oldMode;
        }
        #endregion
    }
    #endregion

    #region RoseToolTip
    /// <summary>
    /// Class RoseToolTip.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.NativeWindow" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    internal class RoseToolTip : NativeWindow
    {
        #region Constants
        // setwindowpos
        /// <summary>
        /// The HWND notopmost
        /// </summary>
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        /// <summary>
        /// The HWND topmost
        /// </summary>
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        /// <summary>
        /// The HWND top
        /// </summary>
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        /// <summary>
        /// The HWND bottom
        /// </summary>
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        // size/move
        /// <summary>
        /// The SWP nosize
        /// </summary>
        private const uint SWP_NOSIZE = 0x0001;
        /// <summary>
        /// The SWP nomove
        /// </summary>
        private const uint SWP_NOMOVE = 0x0002;
        /// <summary>
        /// The SWP nozorder
        /// </summary>
        private const uint SWP_NOZORDER = 0x0004;
        /// <summary>
        /// The SWP noredraw
        /// </summary>
        private const uint SWP_NOREDRAW = 0x0008;
        /// <summary>
        /// The SWP noactivate
        /// </summary>
        private const uint SWP_NOACTIVATE = 0x0010;
        /// <summary>
        /// The SWP framechanged
        /// </summary>
        private const uint SWP_FRAMECHANGED = 0x0020;
        /// <summary>
        /// The SWP showwindow
        /// </summary>
        private const uint SWP_SHOWWINDOW = 0x0040;
        /// <summary>
        /// The SWP hidewindow
        /// </summary>
        private const uint SWP_HIDEWINDOW = 0x0080;
        /// <summary>
        /// The SWP nocopybits
        /// </summary>
        private const uint SWP_NOCOPYBITS = 0x0100;
        /// <summary>
        /// The SWP noownerzorder
        /// </summary>
        private const uint SWP_NOOWNERZORDER = 0x0200;
        /// <summary>
        /// The SWP nosendchanging
        /// </summary>
        private const uint SWP_NOSENDCHANGING = 0x0400;
        // styles
        /// <summary>
        /// The TTS alwaystip
        /// </summary>
        private const int TTS_ALWAYSTIP = 0x01;
        /// <summary>
        /// The TTS noprefix
        /// </summary>
        private const int TTS_NOPREFIX = 0x02;
        /// <summary>
        /// The TTS noanimate
        /// </summary>
        private const int TTS_NOANIMATE = 0x10;
        /// <summary>
        /// The TTS nofade
        /// </summary>
        private const int TTS_NOFADE = 0x20;
        /// <summary>
        /// The TTS balloon
        /// </summary>
        private const int TTS_BALLOON = 0x40;
        /// <summary>
        /// The TTS close
        /// </summary>
        private const int TTS_CLOSE = 0x80;
        /// <summary>
        /// The TTS usevisualstyle
        /// </summary>
        private const int TTS_USEVISUALSTYLE = 0x100;
        // window messages
        /// <summary>
        /// The wm notify
        /// </summary>
        private const int WM_NOTIFY = 0x4E;
        /// <summary>
        /// The wm reflect
        /// </summary>
        private const int WM_REFLECT = 0x2000;
        /// <summary>
        /// The wm paint
        /// </summary>
        private const int WM_PAINT = 0xF;
        /// <summary>
        /// The wm size
        /// </summary>
        private const int WM_SIZE = 0x5;
        /// <summary>
        /// The wm move
        /// </summary>
        private const int WM_MOVE = 0x3;
        /// <summary>
        /// The wm setfont
        /// </summary>
        private const int WM_SETFONT = 0x30;
        /// <summary>
        /// The wm getfont
        /// </summary>
        private const int WM_GETFONT = 0x31;
        /// <summary>
        /// The wm showwindow
        /// </summary>
        private const int WM_SHOWWINDOW = 0x18;
        /// <summary>
        /// The wm mousemove
        /// </summary>
        private const int WM_MOUSEMOVE = 0x200;
        /// <summary>
        /// The wm mouseleave
        /// </summary>
        private const int WM_MOUSELEAVE = 0x2A3;
        /// <summary>
        /// The wm lbuttondown
        /// </summary>
        private const int WM_LBUTTONDOWN = 0x201;
        /// <summary>
        /// The wm lbuttonup
        /// </summary>
        private const int WM_LBUTTONUP = 0x202;
        /// <summary>
        /// The wm lbuttondblclk
        /// </summary>
        private const int WM_LBUTTONDBLCLK = 0x203;
        /// <summary>
        /// The wm rbuttondown
        /// </summary>
        private const int WM_RBUTTONDOWN = 0x204;
        /// <summary>
        /// The wm rbuttonup
        /// </summary>
        private const int WM_RBUTTONUP = 0x205;
        /// <summary>
        /// The wm rbuttondblclk
        /// </summary>
        private const int WM_RBUTTONDBLCLK = 0x206;
        /// <summary>
        /// The wm mbuttondown
        /// </summary>
        private const int WM_MBUTTONDOWN = 0x207;
        /// <summary>
        /// The wm mbuttonup
        /// </summary>
        private const int WM_MBUTTONUP = 0x208;
        /// <summary>
        /// The wm mbuttondblclk
        /// </summary>
        private const int WM_MBUTTONDBLCLK = 0x209;
        /// <summary>
        /// The wm mousewheel
        /// </summary>
        private const int WM_MOUSEWHEEL = 0x20A;
        /// <summary>
        /// The wm timer
        /// </summary>
        private const int WM_TIMER = 0x113;
        /// <summary>
        /// The wm ncpaint
        /// </summary>
        private const int WM_NCPAINT = 0x85;
        /// <summary>
        /// The wm destroy
        /// </summary>
        private const int WM_DESTROY = 0x2;
        /// <summary>
        /// The wm setfocus
        /// </summary>
        private const int WM_SETFOCUS = 0x7;
        /// <summary>
        /// The wm killfocus
        /// </summary>
        private const int WM_KILLFOCUS = 0x8;
        /// <summary>
        /// The wm IME notify
        /// </summary>
        private const int WM_IME_NOTIFY = 0x282;
        /// <summary>
        /// The wm IME setcontext
        /// </summary>
        private const int WM_IME_SETCONTEXT = 0x281;
        /// <summary>
        /// The wm activate
        /// </summary>
        private const int WM_ACTIVATE = 0x6;
        /// <summary>
        /// The wm ncactivate
        /// </summary>
        private const int WM_NCACTIVATE = 0x86;
        /// <summary>
        /// The wm stylechanged
        /// </summary>
        private const int WM_STYLECHANGED = 0x7d;
        /// <summary>
        /// The wm stylechanging
        /// </summary>
        private const int WM_STYLECHANGING = 0x7c;
        /// <summary>
        /// The wm windowposchanging
        /// </summary>
        private const int WM_WINDOWPOSCHANGING = 0x46;
        /// <summary>
        /// The wm windowposchanged
        /// </summary>
        private const int WM_WINDOWPOSCHANGED = 0x47;
        /// <summary>
        /// The wm nccalcsize
        /// </summary>
        private const int WM_NCCALCSIZE = 0x83;
        /// <summary>
        /// The wm ctlcolor
        /// </summary>
        private const int WM_CTLCOLOR = 0x3d8d610;
        // window styles
        /// <summary>
        /// The GWL style
        /// </summary>
        private const int GWL_STYLE = (-16);
        /// <summary>
        /// The GWL exstyle
        /// </summary>
        private const int GWL_EXSTYLE = (-20);
        /// <summary>
        /// The ss ownerdraw
        /// </summary>
        private const int SS_OWNERDRAW = 0xD;
        /// <summary>
        /// The ws overlapped
        /// </summary>
        private const int WS_OVERLAPPED = 0x0;
        /// <summary>
        /// The ws tabstop
        /// </summary>
        private const int WS_TABSTOP = 0x10000;
        /// <summary>
        /// The ws thickframe
        /// </summary>
        private const int WS_THICKFRAME = 0x40000;
        /// <summary>
        /// The ws hscroll
        /// </summary>
        private const int WS_HSCROLL = 0x100000;
        /// <summary>
        /// The ws vscroll
        /// </summary>
        private const int WS_VSCROLL = 0x200000;
        /// <summary>
        /// The ws border
        /// </summary>
        private const int WS_BORDER = 0x800000;
        /// <summary>
        /// The ws clipchildren
        /// </summary>
        private const int WS_CLIPCHILDREN = 0x2000000;
        /// <summary>
        /// The ws clipsiblings
        /// </summary>
        private const int WS_CLIPSIBLINGS = 0x4000000;
        /// <summary>
        /// The ws visible
        /// </summary>
        private const int WS_VISIBLE = 0x10000000;
        /// <summary>
        /// The ws child
        /// </summary>
        private const int WS_CHILD = 0x40000000;
        /// <summary>
        /// The ws popup
        /// </summary>
        private const int WS_POPUP = -2147483648;
        // window extended styles
        /// <summary>
        /// The ws ex ltrreading
        /// </summary>
        private const int WS_EX_LTRREADING = 0x0;
        /// <summary>
        /// The ws ex left
        /// </summary>
        private const int WS_EX_LEFT = 0x0;
        /// <summary>
        /// The ws ex rightscrollbar
        /// </summary>
        private const int WS_EX_RIGHTSCROLLBAR = 0x0;
        /// <summary>
        /// The ws ex dlgmodalframe
        /// </summary>
        private const int WS_EX_DLGMODALFRAME = 0x1;
        /// <summary>
        /// The ws ex noparentnotify
        /// </summary>
        private const int WS_EX_NOPARENTNOTIFY = 0x4;
        /// <summary>
        /// The ws ex topmost
        /// </summary>
        private const int WS_EX_TOPMOST = 0x8;
        /// <summary>
        /// The ws ex acceptfiles
        /// </summary>
        private const int WS_EX_ACCEPTFILES = 0x10;
        /// <summary>
        /// The ws ex transparent
        /// </summary>
        private const int WS_EX_TRANSPARENT = 0x20;
        /// <summary>
        /// The ws ex mdichild
        /// </summary>
        private const int WS_EX_MDICHILD = 0x40;
        /// <summary>
        /// The ws ex toolwindow
        /// </summary>
        private const int WS_EX_TOOLWINDOW = 0x80;
        /// <summary>
        /// The ws ex windowedge
        /// </summary>
        private const int WS_EX_WINDOWEDGE = 0x100;
        /// <summary>
        /// The ws ex clientedge
        /// </summary>
        private const int WS_EX_CLIENTEDGE = 0x200;
        /// <summary>
        /// The ws ex contexthelp
        /// </summary>
        private const int WS_EX_CONTEXTHELP = 0x400;
        /// <summary>
        /// The ws ex right
        /// </summary>
        private const int WS_EX_RIGHT = 0x1000;
        /// <summary>
        /// The ws ex rtlreading
        /// </summary>
        private const int WS_EX_RTLREADING = 0x2000;
        /// <summary>
        /// The ws ex leftscrollbar
        /// </summary>
        private const int WS_EX_LEFTSCROLLBAR = 0x4000;
        /// <summary>
        /// The ws ex controlparent
        /// </summary>
        private const int WS_EX_CONTROLPARENT = 0x10000;
        /// <summary>
        /// The ws ex staticedge
        /// </summary>
        private const int WS_EX_STATICEDGE = 0x20000;
        /// <summary>
        /// The ws ex appwindow
        /// </summary>
        private const int WS_EX_APPWINDOW = 0x40000;
        /// <summary>
        /// The ws ex noactivate
        /// </summary>
        private const int WS_EX_NOACTIVATE = 0x8000000;
        /// <summary>
        /// The ws ex layered
        /// </summary>
        private const int WS_EX_LAYERED = 0x80000;
        #endregion

        #region Structs
        /// <summary>
        /// Struct RECT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="RECT"/> struct.
            /// </summary>
            /// <param name="X">The x.</param>
            /// <param name="Y">The y.</param>
            /// <param name="Width">The width.</param>
            /// <param name="Height">The height.</param>
            private RECT(int X, int Y, int Width, int Height)
            {
                this.Left = X;
                this.Top = Y;
                this.Right = Width;
                this.Bottom = Height;
            }
            /// <summary>
            /// The left
            /// </summary>
            internal int Left;
            /// <summary>
            /// The top
            /// </summary>
            internal int Top;
            /// <summary>
            /// The right
            /// </summary>
            internal int Right;
            /// <summary>
            /// The bottom
            /// </summary>
            internal int Bottom;
        }
        #endregion

        #region API
        /// <summary>
        /// Creates the window ex.
        /// </summary>
        /// <param name="exstyle">The exstyle.</param>
        /// <param name="lpClassName">Name of the lp class.</param>
        /// <param name="lpWindowName">Name of the lp window.</param>
        /// <param name="dwStyle">The dw style.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <param name="hwndParent">The HWND parent.</param>
        /// <param name="Menu">The menu.</param>
        /// <param name="hInstance">The h instance.</param>
        /// <param name="lpParam">The lp parameter.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CreateWindowEx(int exstyle, string lpClassName, string lpWindowName, int dwStyle,
            int x, int y, int nWidth, int nHeight, IntPtr hwndParent, IntPtr Menu, IntPtr hInstance, IntPtr lpParam);

        /// <summary>
        /// Destroys the window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DestroyWindow(IntPtr hWnd);

        /// <summary>
        /// Gets the desktop window.
        /// </summary>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", SetLastError = false)]
        private static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// Sets the timer.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nIDEvent">The n identifier event.</param>
        /// <param name="uElapse">The u elapse.</param>
        /// <param name="lpTimerFunc">The lp timer function.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern IntPtr SetTimer(IntPtr hWnd, int nIDEvent, uint uElapse, IntPtr lpTimerFunc);

        /// <summary>
        /// Kills the timer.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="uIDEvent">The u identifier event.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool KillTimer(IntPtr hWnd, uint uIDEvent);

        /// <summary>
        /// Sets the window position.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="hWndAfter">The h WND after.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="cx">The cx.</param>
        /// <param name="cy">The cy.</param>
        /// <param name="flags">The flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int cx, int cy, uint flags);

        /// <summary>
        /// Gets the client rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="r">The r.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

        /// <summary>
        /// Gets the window rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lpRect">The lp rect.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        /// <summary>
        /// Gets the window long.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="nIndex">Index of the n.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        /// <summary>
        /// Sets the window long.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="nIndex">Index of the n.</param>
        /// <param name="dwNewLong">The dw new long.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        /// <summary>
        /// Gets the cursor position.
        /// </summary>
        /// <param name="lpPoint">The lp point.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Point lpPoint);

        /// <summary>
        /// Screens to client.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lpPoint">The lp point.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref Point lpPoint);

        /// <summary>
        /// Gets the dc.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr handle);

        /// <summary>
        /// Releases the dc.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <param name="hdc">The HDC.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

        /// <summary>
        /// Bits the BLT.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="nXDest">The n x dest.</param>
        /// <param name="nYDest">The n y dest.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <param name="hdcSrc">The HDC source.</param>
        /// <param name="nXSrc">The n x source.</param>
        /// <param name="nYSrc">The n y source.</param>
        /// <param name="dwRop">The dw rop.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        #endregion

        #region Fields
        /// <summary>
        /// The timer active
        /// </summary>
        private bool _timerActive = false;
        /// <summary>
        /// The tip showing
        /// </summary>
        private bool _tipShowing = false;
        /// <summary>
        /// The text right to left
        /// </summary>
        private bool _textRightToLeft = false;
        /// <summary>
        /// The use icon
        /// </summary>
        private bool _useIcon = false;
        /// <summary>
        /// The timer tick
        /// </summary>
        private int _timerTick = 0;
        /// <summary>
        /// The delay time
        /// </summary>
        private int _delayTime = 1000;
        /// <summary>
        /// The visible time
        /// </summary>
        private int _visibleTime = 2000;
        /// <summary>
        /// The client caption
        /// </summary>
        private string _clientCaption = String.Empty;
        /// <summary>
        /// The client title
        /// </summary>
        private string _clientTitle = String.Empty;
        /// <summary>
        /// The fore color
        /// </summary>
        private Color _foreColor = Color.Black;
        /// <summary>
        /// The gradient begin
        /// </summary>
        private Color _gradientBegin = Color.White;
        /// <summary>
        /// The gradient end
        /// </summary>
        private Color _gradientEnd = Color.Silver;
        /// <summary>
        /// The h tip WND
        /// </summary>
        private IntPtr _hTipWnd = IntPtr.Zero;
        /// <summary>
        /// The h instance
        /// </summary>
        private IntPtr _hInstance = IntPtr.Zero;
        /// <summary>
        /// The h parent WND
        /// </summary>
        private IntPtr _hParentWnd = IntPtr.Zero;
        /// <summary>
        /// The client bounds
        /// </summary>
        private Rectangle _clientBounds = new Rectangle();
        /// <summary>
        /// The title font
        /// </summary>
        private Font _titleFont;
        /// <summary>
        /// The caption font
        /// </summary>
        private Font _captionFont;
        /// <summary>
        /// The client image
        /// </summary>
        private Bitmap _clientImage = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RoseToolTip"/> class.
        /// </summary>
        /// <param name="hParentWnd">The h parent WND.</param>
        public RoseToolTip(IntPtr hParentWnd)
        {
            Type t = typeof(RoseToolTip);
            Module m = t.Module;
            _hInstance = Marshal.GetHINSTANCE(m);
            _hParentWnd = hParentWnd;
            // create window
            _hTipWnd = CreateWindowEx(WS_EX_TOPMOST | WS_EX_TOOLWINDOW,
                "STATIC", "",
                SS_OWNERDRAW | WS_CHILD | WS_CLIPSIBLINGS | WS_OVERLAPPED,
                0, 0,
                0, 0,
                GetDesktopWindow(),
                IntPtr.Zero, _hInstance, IntPtr.Zero);
            // set starting position
            SetWindowPos(_hTipWnd, HWND_TOP,
                0, 0,
                0, 0,
                SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_NOOWNERZORDER);
            createFonts();
            this.AssignHandle(_hTipWnd);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the tip bounds.
        /// </summary>
        /// <value>The tip bounds.</value>
        private Rectangle TipBounds
        {
            get { return _clientBounds; }
            set { _clientBounds = value; }
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        private string Caption
        {
            get { return _clientCaption; }
            set { _clientCaption = value; }
        }

        /// <summary>
        /// Gets or sets the delay time.
        /// </summary>
        /// <value>The delay time.</value>
        public int DelayTime
        {
            get { return _delayTime; }
            set { _delayTime = value; }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get { return _foreColor; }
            set { _foreColor = value; }
        }

        /// <summary>
        /// Gets or sets the gradient begin.
        /// </summary>
        /// <value>The gradient begin.</value>
        public Color GradientBegin
        {
            get { return _gradientBegin; }
            set { _gradientBegin = value; }
        }

        /// <summary>
        /// Gets or sets the gradient end.
        /// </summary>
        /// <value>The gradient end.</value>
        public Color GradientEnd
        {
            get { return _gradientEnd; }
            set { _gradientEnd = value; }
        }

        /// <summary>
        /// Gets or sets the item image.
        /// </summary>
        /// <value>The item image.</value>
        public Bitmap ItemImage
        {
            get { return _clientImage; }
            set { _clientImage = value; }
        }

        /// <summary>
        /// Sets the maximum length.
        /// </summary>
        /// <value>The maximum length.</value>
        public int MaximumLength
        {
            set { _clientBounds.Width = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [text right to left].
        /// </summary>
        /// <value><c>true</c> if [text right to left]; otherwise, <c>false</c>.</value>
        public bool TextRightToLeft
        {
            get { return _textRightToLeft; }
            set { _textRightToLeft = value; }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        private string Title
        {
            get { return _clientTitle; }
            set { _clientTitle = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use icon].
        /// </summary>
        /// <value><c>true</c> if [use icon]; otherwise, <c>false</c>.</value>
        public bool UseIcon
        {
            get { return _useIcon; }
            set { _useIcon = value; }
        }

        /// <summary>
        /// Gets or sets the visible time.
        /// </summary>
        /// <value>The visible time.</value>
        public int VisibleTime
        {
            get { return _visibleTime; }
            set { _visibleTime = value; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Starts the specified title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        public void Start(string title, string caption, Bitmap image, Rectangle bounds)
        {
            if (_timerActive)
                Stop();
            destroyImage();
            Title = title;
            Caption = caption;
            ItemImage = image;
            TipBounds = bounds;
            SetTimer(_hTipWnd, 1, 100, IntPtr.Zero);
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            // kill the timer
            KillTimer(_hTipWnd, 1);
            // hide the window
            showWindow(false);
            // reset properties
            Title = String.Empty;
            Caption = String.Empty;
            ItemImage = null;
            TipBounds = Rectangle.Empty;
            // reset timer values
            _timerTick = 0;
            _tipShowing = false;
            _timerActive = false;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            if (_hTipWnd != IntPtr.Zero)
            {
                this.ReleaseHandle();
                destroyFonts();
                destroyImage();
                DestroyWindow(_hTipWnd);
                _hTipWnd = IntPtr.Zero;
            }
        }
        #endregion

        #region Internal Methods
        /// <summary>
        /// Calculates the size.
        /// </summary>
        /// <returns>Rectangle.</returns>
        private Rectangle calculateSize()
        {
            SizeF textSize = new SizeF();
            SizeF titleSize = new SizeF();

            // calculate text
            if (!String.IsNullOrEmpty(Caption))
                textSize = calcTextSize(Caption, _captionFont, 0);
            // calc title
            if (!String.IsNullOrEmpty(Title))
                titleSize = calcTextSize(Title, _titleFont, 0);
            if (textSize.Width < titleSize.Width)
                textSize.Width = titleSize.Width;
            if (titleSize.Height > 0)
                textSize.Height += (titleSize.Height + 4);
            // calc icon
            if ((ItemImage != null) && (UseIcon))
            {
                textSize.Height += 8;
                textSize.Width += ItemImage.Size.Width + 8;
            }
            else
            {
                textSize.Height += 4;
                textSize.Width += 4;
            }
            Rectangle bounds = new Rectangle(0, 0, (int)textSize.Width, (int)textSize.Height);
            bounds.Inflate(4, 4);
            bounds.Offset(4, 4);
            return bounds;
        }

        /// <summary>
        /// Calculates the size of the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="width">The width.</param>
        /// <returns>SizeF.</returns>
        private SizeF calcTextSize(string text, Font font, int width)
        {
            SizeF sF = new SizeF();
            IntPtr hdc = GetDC(_hTipWnd);
            Graphics g = Graphics.FromHdc(hdc);
            if (width > 0)
                sF = g.MeasureString(text, font, width);
            else
                sF = g.MeasureString(text, font);
            ReleaseDC(_hTipWnd, hdc);
            g.Dispose();
            return sF;
        }

        /// <summary>
        /// Copies the background.
        /// </summary>
        /// <param name="g">The g.</param>
        private void copyBackground(Graphics g)
        {
            RECT windowRect = new RECT();
            GetWindowRect(_hTipWnd, ref windowRect);
            g.CopyFromScreen(windowRect.Left, windowRect.Top, 0, 0, new Size(windowRect.Right - windowRect.Left, windowRect.Bottom - windowRect.Top), CopyPixelOperation.SourceCopy);
        }

        /// <summary>
        /// Creates the fonts.
        /// </summary>
        private void createFonts()
        {
            _titleFont = new Font("Tahoma", 8, FontStyle.Bold);
            _captionFont = new Font("Tahoma", 8, FontStyle.Regular);
        }

        /// <summary>
        /// Creates the round rectangle path.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath createRoundRectanglePath(Graphics g, float X, float Y, float width, float height, float radius)
        {
            // create a path
            GraphicsPath pathBounds = new GraphicsPath();
            pathBounds.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            pathBounds.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            pathBounds.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            pathBounds.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            pathBounds.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            pathBounds.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            pathBounds.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            pathBounds.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            pathBounds.CloseFigure();
            return pathBounds;
        }

        /// <summary>
        /// Destroys the fonts.
        /// </summary>
        private void destroyFonts()
        {
            if (_titleFont != null)
                _titleFont.Dispose();
            if (_captionFont != null)
                _captionFont.Dispose();
        }

        /// <summary>
        /// Destroys the image.
        /// </summary>
        private void destroyImage()
        {
            if (ItemImage != null)
                ItemImage.Dispose();
            ItemImage = null;
        }

        /// <summary>
        /// Draws the background.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        private void drawBackground(IntPtr hdc)
        {
            // create the graphics instance
            Graphics g = Graphics.FromHdc(hdc);
            // copy in the background to mimic transparency
            copyBackground(g);
            // create the shadow rect
            Rectangle shadowArea = new Rectangle(3, TipBounds.Height - 3, TipBounds.Width - 3, TipBounds.Height);
            // draw the bottom shadow
            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
            {
                using (GraphicsPath shadowPath = createRoundRectanglePath(g, 4, TipBounds.Height - 4, TipBounds.Width - 4, TipBounds.Height, 1f))
                {
                    using (LinearGradientBrush shadowBrush = new LinearGradientBrush(shadowArea, Color.FromArgb(100, 0x99, 0x99, 0x99), Color.FromArgb(60, 0x44, 0x44, 0x44), LinearGradientMode.Vertical))
                    {
                        Blend blend = new Blend();
                        blend.Positions = new float[] { 0f, .3f, .6f, 1f };
                        blend.Factors = new float[] { 0f, .3f, .6f, .9f };
                        shadowBrush.Blend = blend;
                        g.FillPath(shadowBrush, shadowPath);
                    }
                }
                // draw the right shadow
                using (GraphicsPath shadowPath = createRoundRectanglePath(g, TipBounds.Width - 4, 4, TipBounds.Width - 4, TipBounds.Height - 8, 1f))
                {
                    using (LinearGradientBrush shadowBrush = new LinearGradientBrush(shadowArea, Color.FromArgb(100, 0x99, 0x99, 0x99), Color.FromArgb(60, 0x44, 0x44, 0x44), LinearGradientMode.Horizontal))
                    {
                        Blend blend = new Blend();
                        blend.Positions = new float[] { 0f, .3f, .6f, 1f };
                        blend.Factors = new float[] { 0f, .3f, .6f, .9f };
                        shadowBrush.Blend = blend;
                        g.FillPath(shadowBrush, shadowPath);
                    }
                }
                // adjust the bounds
                Rectangle fillBounds = new Rectangle(0, 0, TipBounds.Width - 4, TipBounds.Height - 4);
                using (GraphicsPath fillPath = createRoundRectanglePath(g, fillBounds.X, fillBounds.Y, fillBounds.Width, fillBounds.Height, 2f))
                {
                    using (LinearGradientBrush shadowBrush = new LinearGradientBrush(shadowArea, GradientBegin, GradientEnd, LinearGradientMode.Vertical))
                    {
                        // draw the frame
                        using (Pen fillPen = new Pen(Color.FromArgb(250, 0x44, 0x44, 0x44)))
                            g.DrawPath(fillPen, fillPath);
                        // fill the body
                        Blend blend = new Blend();
                        blend.Positions = new float[] { 0f, .4f, .6f, 1f };
                        blend.Factors = new float[] { 0f, .3f, .6f, .8f };
                        shadowBrush.Blend = blend;
                        g.FillPath(shadowBrush, fillPath);
                    }
                }
            }
            g.Dispose();
        }

        /// <summary>
        /// Draws the caption.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        private void drawCaption(IntPtr hdc)
        {
            Graphics g = Graphics.FromHdc(hdc);
            using (StringFormat sF = new StringFormat())
            {
                int vOffset;
                int hOffset;

                if ((ItemImage != null) && (UseIcon))
                {
                    vOffset = ItemImage.Size.Width + 8;
                    if (!String.IsNullOrEmpty(Title))
                        hOffset = (ItemImage.Size.Height / 2) + (_titleFont.Height);
                    else
                        hOffset = (TipBounds.Height - ItemImage.Size.Height) / 2;
                }
                else if (!String.IsNullOrEmpty(Title))
                {
                    vOffset = 4;
                    hOffset = (_titleFont.Height + 8);
                }
                else
                {
                    vOffset = 4;
                    hOffset = 4;
                }

                sF.Alignment = StringAlignment.Near;
                sF.LineAlignment = StringAlignment.Near;
                if (TextRightToLeft)
                    sF.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                using (Brush captionBrush = new SolidBrush(ForeColor))
                    g.DrawString(Caption, _captionFont, captionBrush, new RectangleF(vOffset, hOffset, TipBounds.Width - vOffset, TipBounds.Height - hOffset), sF);
            }
            g.Dispose();
        }

        /// <summary>
        /// Draws the icon.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        private void drawIcon(IntPtr hdc)
        {
            if (ItemImage != null)
            {
                Graphics g = Graphics.FromHdc(hdc);
                g.DrawImage(ItemImage, new Point(4, 4));
                g.Dispose();
            }
        }

        /// <summary>
        /// Draws the title.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        private void drawTitle(IntPtr hdc)
        {
            Graphics g = Graphics.FromHdc(hdc);
            using (StringFormat sF = new StringFormat())
            {
                int vOffset;
                int hOffset;

                if ((ItemImage != null) && (UseIcon))
                {
                    vOffset = ItemImage.Size.Width + 8;
                    hOffset = (ItemImage.Size.Height / 2) + 2;
                }
                else
                {
                    vOffset = 4;
                    hOffset = 12;
                }

                sF.Alignment = StringAlignment.Near;
                sF.LineAlignment = StringAlignment.Center;
                sF.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
                sF.FormatFlags = StringFormatFlags.NoWrap;

                if (TextRightToLeft)
                    sF.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                using (Brush titleBrush = new SolidBrush(ForeColor))
                    g.DrawString(Title, _titleFont, titleBrush, new PointF(vOffset, hOffset), sF);
            }
            g.Dispose();
        }

        /// <summary>
        /// Positions the window.
        /// </summary>
        private void positionWindow()
        {
            if (_hTipWnd != IntPtr.Zero)
            {
                // offset with screen position
                RECT windowRect = new RECT();
                GetWindowRect(_hParentWnd, ref windowRect);
                windowRect.Left += TipBounds.X;
                windowRect.Top += TipBounds.Y;
                // position the window
                SetWindowPos(_hTipWnd, HWND_TOPMOST, windowRect.Left, windowRect.Top, TipBounds.Width, TipBounds.Height, SWP_SHOWWINDOW | SWP_NOACTIVATE);
            }
        }

        /// <summary>
        /// Renders the tip.
        /// </summary>
        private void renderTip()
        {
            if ((Caption != String.Empty) && (TipBounds != Rectangle.Empty))
            {
                // create the canvas
                _clientBounds.Height = 50;
                Rectangle bounds = calculateSize();
                bounds.X = TipBounds.X;
                bounds.Y = TipBounds.Y;
                TipBounds = bounds;
                cStoreDc drawDc = new cStoreDc();
                drawDc.Width = TipBounds.Width;
                drawDc.Height = TipBounds.Height;
                positionWindow();
                // show the window
                showWindow(true);
                // draw the background to the temp dc
                drawBackground(drawDc.Hdc);
                // draw image and text
                if ((ItemImage != null) && (UseIcon))
                    drawIcon(drawDc.Hdc);
                if (Title != String.Empty)
                    drawTitle(drawDc.Hdc);
                drawCaption(drawDc.Hdc);
                // draw the tempdc to the window
                IntPtr hdc = GetDC(_hTipWnd);
                BitBlt(hdc, 0, 0, TipBounds.Width, TipBounds.Height, drawDc.Hdc, 0, 0, 0xCC0020);
                ReleaseDC(_hTipWnd, hdc);
                // cleanup
                drawDc.Dispose();
            }
        }

        /// <summary>
        /// Shows the window.
        /// </summary>
        /// <param name="show">if set to <c>true</c> [show].</param>
        private void showWindow(bool show)
        {
            if (show)
                SetWindowPos(_hTipWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_SHOWWINDOW | SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE);
            else
                SetWindowPos(_hTipWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_HIDEWINDOW | SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE);
        }
        #endregion

        #region WndProc
        /// <summary>
        /// Invokes the default window procedure associated with this window.
        /// </summary>
        /// <param name="m">A <see cref="T:System.Windows.Forms.Message" /> that is associated with the current Windows message.</param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_TIMER:
                    _timerTick++;
                    if (_timerTick > (DelayTime / 100))
                    {
                        if (!_tipShowing)
                        {
                            _tipShowing = true;
                            renderTip();
                        }
                    }
                    if (_timerTick > ((DelayTime + VisibleTime) / 100))
                        Stop();
                    base.WndProc(ref m);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion
    }
    #endregion

    #region StoreDc
    /// <summary>
    /// Class cStoreDc.
    /// </summary>
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    internal class cStoreDc
    {
        /// <summary>
        /// Creates the dca.
        /// </summary>
        /// <param name="lpszDriver">The LPSZ driver.</param>
        /// <param name="lpszDevice">The LPSZ device.</param>
        /// <param name="lpszOutput">The LPSZ output.</param>
        /// <param name="lpInitData">The lp initialize data.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDCA([MarshalAs(UnmanagedType.LPStr)]string lpszDriver, [MarshalAs(UnmanagedType.LPStr)]string lpszDevice, [MarshalAs(UnmanagedType.LPStr)]string lpszOutput, int lpInitData);

        /// <summary>
        /// Creates the DCW.
        /// </summary>
        /// <param name="lpszDriver">The LPSZ driver.</param>
        /// <param name="lpszDevice">The LPSZ device.</param>
        /// <param name="lpszOutput">The LPSZ output.</param>
        /// <param name="lpInitData">The lp initialize data.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDCW([MarshalAs(UnmanagedType.LPWStr)]string lpszDriver, [MarshalAs(UnmanagedType.LPWStr)]string lpszDevice, [MarshalAs(UnmanagedType.LPWStr)]string lpszOutput, int lpInitData);

        /// <summary>
        /// Creates the dc.
        /// </summary>
        /// <param name="lpszDriver">The LPSZ driver.</param>
        /// <param name="lpszDevice">The LPSZ device.</param>
        /// <param name="lpszOutput">The LPSZ output.</param>
        /// <param name="lpInitData">The lp initialize data.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, int lpInitData);

        /// <summary>
        /// Creates the compatible dc.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        /// <summary>
        /// Creates the compatible bitmap.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        /// <summary>
        /// Deletes the dc.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteDC(IntPtr hdc);

        /// <summary>
        /// Selects the object.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="hgdiobj">The hgdiobj.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true)]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <param name="hObject">The h object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// The height
        /// </summary>
        private int _Height = 0;
        /// <summary>
        /// The width
        /// </summary>
        private int _Width = 0;
        /// <summary>
        /// The HDC
        /// </summary>
        private IntPtr _Hdc = IntPtr.Zero;
        /// <summary>
        /// The BMP
        /// </summary>
        private IntPtr _Bmp = IntPtr.Zero;
        /// <summary>
        /// The BMP old
        /// </summary>
        private IntPtr _BmpOld = IntPtr.Zero;

        /// <summary>
        /// Gets the HDC.
        /// </summary>
        /// <value>The HDC.</value>
        public IntPtr Hdc
        {
            get { return _Hdc; }
        }

        /// <summary>
        /// Gets the h BMP.
        /// </summary>
        /// <value>The h BMP.</value>
        public IntPtr HBmp
        {
            get { return _Bmp; }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {
            get { return _Height; }
            set
            {
                if (_Height != value)
                {
                    _Height = value;
                    ImageCreate(_Width, _Height);
                }
            }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {
            get { return _Width; }
            set
            {
                if (_Width != value)
                {
                    _Width = value;
                    ImageCreate(_Width, _Height);
                }
            }
        }

        /// <summary>
        /// Images the create.
        /// </summary>
        /// <param name="Width">The width.</param>
        /// <param name="Height">The height.</param>
        private void ImageCreate(int Width, int Height)
        {
            IntPtr pHdc = IntPtr.Zero;

            ImageDestroy();
            pHdc = CreateDCA("DISPLAY", "", "", 0);
            _Hdc = CreateCompatibleDC(pHdc);
            _Bmp = CreateCompatibleBitmap(pHdc, _Width, _Height);
            _BmpOld = SelectObject(_Hdc, _Bmp);
            if (_BmpOld == IntPtr.Zero)
            {
                ImageDestroy();
            }
            else
            {
                _Width = Width;
                _Height = Height;
            }
            DeleteDC(pHdc);
            pHdc = IntPtr.Zero;
        }

        /// <summary>
        /// Images the destroy.
        /// </summary>
        private void ImageDestroy()
        {
            if (_BmpOld != IntPtr.Zero)
            {
                SelectObject(_Hdc, _BmpOld);
                _BmpOld = IntPtr.Zero;
            }
            if (_Bmp != IntPtr.Zero)
            {
                DeleteObject(_Bmp);
                _Bmp = IntPtr.Zero;
            }
            if (_Hdc != IntPtr.Zero)
            {
                DeleteDC(_Hdc);
                _Hdc = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            ImageDestroy();
        }
    }
    #endregion
}
