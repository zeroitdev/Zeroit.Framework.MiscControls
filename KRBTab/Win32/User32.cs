// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="User32.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.MiscControls.Tabs.ZeroitKRBTab.Win32
{
    /// <summary>
    /// Class User32.
    /// </summary>
    internal partial class User32
    {
        #region Struct

        /// <summary>
        /// Struct RECT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            /// <summary>
            /// The left
            /// </summary>
            public int left;
            /// <summary>
            /// The top
            /// </summary>
            public int top;
            /// <summary>
            /// The right
            /// </summary>
            public int right;
            /// <summary>
            /// The bottom
            /// </summary>
            public int bottom;

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
            public override string ToString()
            {
                return "{left=" + left.ToString() + ", " + "top=" + top.ToString() + ", " +
                    "right=" + right.ToString() + ", " + "bottom=" + bottom.ToString() + "}";
            }
        }

        /// <summary>
        /// Struct BLENDFUNCTION
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct BLENDFUNCTION
        {
            /// <summary>
            /// The blend op
            /// </summary>
            public byte BlendOp;
            /// <summary>
            /// The blend flags
            /// </summary>
            public byte BlendFlags;
            /// <summary>
            /// The source constant alpha
            /// </summary>
            public byte SourceConstantAlpha;
            /// <summary>
            /// The alpha format
            /// </summary>
            public byte AlphaFormat;
        }

        #region Tab Control Notification Structures

        //[StructLayout(LayoutKind.Sequential)]
        //internal struct NMHDR
        //{
        //    public IntPtr HWND;
        //    public uint idFrom;
        //    public int code;

        //    public override string ToString()
        //    {
        //        return String.Format("Hwnd: {0}, ControlID: {1}, Code: {2}", HWND, idFrom, code);
        //    }
        //}

        ///// <summary>
        ///// From MSDN, Contains information about a key press in a tab control. It is used with the TCN_KEYDOWN notification message. This structure supersedes the TC_KEYDOWN structure.
        ///// </summary>
        //[StructLayout(LayoutKind.Sequential)]
        //internal struct NMTCKEYDOWN
        //{
        //    /// <summary>
        //    /// NMHDR structure that contains information about the notification message. 
        //    /// </summary>
        //    public NMHDR hdr;

        //    /// <summary>
        //    /// Virtual key code.
        //    /// </summary>
        //    public VirtualKeys wVKey;

        //    /// <summary>
        //    /// Value that is identical to the lParam parameter of the WM_KEYDOWN message.
        //    /// </summary>
        //    public uint flags;

        //    public override string ToString()
        //    {
        //        return String.Format("NMHDR: [{0}], Key codes: [{1}], the lParam parameter of the WM_KEYDOWN: [{2}]", hdr, wVKey, flags);
        //    }
        //}

        #endregion

        /// <summary>
        /// Struct TCHITTESTINFO
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct TCHITTESTINFO
        {
            /// <summary>
            /// The pt
            /// </summary>
            public Point pt;
            /// <summary>
            /// The flags
            /// </summary>
            public TabControlHitTest flags;

            /// <summary>
            /// Initializes a new instance of the <see cref="TCHITTESTINFO"/> struct.
            /// </summary>
            /// <param name="hitTest">The hit test.</param>
            public TCHITTESTINFO(TabControlHitTest hitTest)
                : this()
            {
                flags = hitTest;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="TCHITTESTINFO"/> struct.
            /// </summary>
            /// <param name="point">The point.</param>
            /// <param name="hitTest">The hit test.</param>
            public TCHITTESTINFO(Point point, TabControlHitTest hitTest)
                : this(hitTest)
            {
                pt = point;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="TCHITTESTINFO"/> struct.
            /// </summary>
            /// <param name="x">The x.</param>
            /// <param name="y">The y.</param>
            /// <param name="hitTest">The hit test.</param>
            public TCHITTESTINFO(int x, int y, TabControlHitTest hitTest)
                : this(hitTest)
            {
                pt = new Point(x, y);
            }
        }

        #endregion

        #region UnmanagedMethods

        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <param name="hObject">The h object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32")]
        internal static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// Selects the object.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="hgdiobj">The hgdiobj.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32")]
        internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        /// <summary>
        /// Creates the compatible dc.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32", SetLastError = true)]
        internal static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        /// <summary>
        /// Creates the dc.
        /// </summary>
        /// <param name="driverName">Name of the driver.</param>
        /// <param name="deviceName">Name of the device.</param>
        /// <param name="output">The output.</param>
        /// <param name="lpInitData">The lp initialize data.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32")]
        internal static extern IntPtr CreateDC(
          String driverName,
          String deviceName,
          String output,
          IntPtr lpInitData);

        /// <summary>
        /// Deletes the dc.
        /// </summary>
        /// <param name="dc">The dc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32")]
        internal static extern bool DeleteDC(
          IntPtr dc);

        /// <summary>
        /// Sets the window theme.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="textSubAppName">Name of the text sub application.</param>
        /// <param name="textSubIdList">The text sub identifier list.</param>
        /// <returns>Int32.</returns>
        [DllImport("uxtheme", ExactSpelling = true, CharSet = CharSet.Unicode)]
        internal static extern Int32 SetWindowTheme(
            IntPtr hWnd,
            String textSubAppName,
            String textSubIdList);

        /// <summary>
        /// Sets the parent.
        /// </summary>
        /// <param name="hwndChild">The HWND child.</param>
        /// <param name="hwndParent">The HWND parent.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern IntPtr SetParent(IntPtr hwndChild, IntPtr hwndParent);

        /// <summary>
        /// The GetParent function retrieves a handle to the specified window's parent or owner.
        /// </summary>
        /// <param name="hwnd">Handle to the window whose parent window handle is to be retrieved.</param>
        /// <returns>If the window is a child window, the return value is a handle to the parent window. If the window is a top-level window, the return value is a handle to the owner window. If the window is a top-level unowned window or if the function fails, the return value is NULL.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetParent(IntPtr hwnd);

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="wMsg">The w MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern int SendMessage(
            IntPtr hwnd,
            int wMsg,
            int wParam,
            int lParam);

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="wMsg">The w MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern int SendMessage(
            IntPtr hwnd,
            int wMsg,
            IntPtr wParam,
            IntPtr lParam);

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="tMsg">The t MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern int SendMessage(
            IntPtr hwnd,
            int tMsg,
            IntPtr wParam,
            ref TCHITTESTINFO lParam);

        /// <summary>
        /// Loads the cursor from file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern IntPtr LoadCursorFromFile(string filename);

        /// <summary>
        /// Determines whether [is window visible] [the specified HWND].
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <returns><c>true</c> if [is window visible] [the specified HWND]; otherwise, <c>false</c>.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern bool IsWindowVisible(IntPtr hwnd);

        /// <summary>
        /// The FindWindowEx function retrieves a handle to a window whose class name and window name match the specified strings. The function searches child windows, beginning with the one following the specified child window.
        /// </summary>
        /// <param name="hwndParent">Handle to the parent window whose child windows are to be searched.</param>
        /// <param name="hwndChildAfter">Handle to a child window.</param>
        /// <param name="lpszClass">Specifies class name.</param>
        /// <param name="lpszWindow">Pointer to a null-terminated string that specifies the window name (the window's title).</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class and window names.If the function fails, the return value is NULL.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern IntPtr FindWindowEx(
            IntPtr hwndParent,
            IntPtr hwndChildAfter,
            [MarshalAs(UnmanagedType.LPTStr)]
			string lpszClass,
            [MarshalAs(UnmanagedType.LPTStr)]
			string lpszWindow);

        /// <summary>
        /// The InvalidateRect function adds a rectangle to the specified window's update region.
        /// </summary>
        /// <param name="hwnd">Handle to window.</param>
        /// <param name="rect">Rectangle coordinates.</param>
        /// <param name="bErase">Erase state.</param>
        /// <returns>If the function succeeds, the return value is true.If the function fails, the return value is false.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern bool InvalidateRect(
            IntPtr hwnd,
            ref Rectangle rect,
            bool bErase);

        /// <summary>
        /// The ValidateRect function validates the client area within a rectangle by removing the rectangle from the update region of the specified window.
        /// </summary>
        /// <param name="hwnd">Handle to window.</param>
        /// <param name="rect">Validation rectangle coordinates.</param>
        /// <returns>If the function succeeds, the return value is true.If the function fails, the return value is false.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern bool ValidateRect(
            IntPtr hwnd,
            ref Rectangle rect);

        /// <summary>
        /// Gets the window long.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="dwStyle">The dw style.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern int GetWindowLong(
            IntPtr hWnd,
            int dwStyle);

        /// <summary>
        /// Gets the dc.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetDC(
            IntPtr hwnd);

        /// <summary>
        /// Releases the dc.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="hdc">The HDC.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern int ReleaseDC(
            IntPtr hwnd,
            IntPtr hdc);

        //[DllImport("user32", SetLastError = false)]
        //internal static extern IntPtr GetDesktopWindow();

        //[DllImport("user32", CharSet = CharSet.Auto)]
        //internal static extern int GetScrollPos(
        //    IntPtr hwnd,
        //    int nBar);

        /// <summary>
        /// Gets the client rect.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="rc">The rc.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern int GetClientRect(
            IntPtr hwnd,
            ref RECT rc);

        /// <summary>
        /// Gets the client rect.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="rect">The rect.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern int GetClientRect(
            IntPtr hwnd,
            [In, Out] ref Rectangle rect);

        /// <summary>
        /// Gets the window rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="rect">The rect.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern bool GetWindowRect(
            IntPtr hWnd,
            [In, Out] ref Rectangle rect);

        /// <summary>
        /// Gets the window rect.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="rc">The rc.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern int GetWindowRect(
            IntPtr hwnd,
            ref RECT rc);

        /// <summary>
        /// Updates the layered window.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="hdcDst">The HDC DST.</param>
        /// <param name="pptDst">The PPT DST.</param>
        /// <param name="psize">The psize.</param>
        /// <param name="hdcSrc">The HDC source.</param>
        /// <param name="pprSrc">The PPR source.</param>
        /// <param name="crKey">The cr key.</param>
        /// <param name="pblend">The pblend.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32", ExactSpelling = true, SetLastError = true)]
        internal static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        /// <summary>
        /// Sets the window long.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nIndex">Index of the n.</param>
        /// <param name="dwNewLong">The dw new long.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern uint SetWindowLong(
            IntPtr hWnd,
            int nIndex,
            int dwNewLong);

        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window.
        /// These windows are ordered according to their appearance on the screen.
        /// The topmost window receives the highest rank and is the first window in the Z order.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="hWndAfter">A handle to the window to precede the positioned window in the Z order. This parameter must be a window handle or one of the following values.</param>
        /// <param name="X">Specifies the new position of the left side of the window, in client coordinates.</param>
        /// <param name="Y">Specifies the new position of the top of the window, in client coordinates.</param>
        /// <param name="Width">Specifies the new width of the window, in pixels.</param>
        /// <param name="Height">Specifies the new height of the window, in pixels.</param>
        /// <param name="flags">Specifies the window sizing and positioning flags. This parameter can be a combination of the following values.</param>
        /// <returns>If the function succeeds, the return value is nonzero, if the function fails, the return value is zero.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern int SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndAfter,
            int X,
            int Y,
            int Width,
            int Height,
            FlagsSetWindowPos flags);

        /// <summary>
        /// Sets the window position.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="hWndInsertAfter">The h WND insert after.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="cx">The cx.</param>
        /// <param name="cy">The cy.</param>
        /// <param name="uFlags">The u flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X,
           int Y, int cx, int cy, uint uFlags);

        #endregion
    }
}