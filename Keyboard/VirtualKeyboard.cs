// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="VirtualKeyboard.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region Virtual Keyboard Example

    #region iZeroitVirtualKeyboard
    /// <summary>
    /// Interface iZeroitVirtualKeyboard
    /// </summary>
    interface iZeroitVirtualKeyboard
    {
        /// <summary>
        /// Gets or sets a value indicating whether [caps lock state].
        /// </summary>
        /// <value><c>true</c> if [caps lock state]; otherwise, <c>false</c>.</value>
        bool CapsLockState
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [number lock state].
        /// </summary>
        /// <value><c>true</c> if [number lock state]; otherwise, <c>false</c>.</value>
        bool NumLockState
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets a value indicating whether [shift state].
        /// </summary>
        /// <value><c>true</c> if [shift state]; otherwise, <c>false</c>.</value>
        bool ShiftState
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets a value indicating whether [control state].
        /// </summary>
        /// <value><c>true</c> if [control state]; otherwise, <c>false</c>.</value>
        bool CtrlState
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [alt state].
        /// </summary>
        /// <value><c>true</c> if [alt state]; otherwise, <c>false</c>.</value>
        bool AltState
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the color of the begin gradient.
        /// </summary>
        /// <value>The color of the begin gradient.</value>
        Color BeginGradientColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the end color of the gradient.
        /// </summary>
        /// <value>The end color of the gradient.</value>
        Color EndGradientColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the state of the color pressed.
        /// </summary>
        /// <value>The state of the color pressed.</value>
        Color ColorPressedState
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>The color of the font.</value>
        Color FontColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the font color special key.
        /// </summary>
        /// <value>The font color special key.</value>
        Color FontColorSpecialKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the label font.
        /// </summary>
        /// <value>The label font.</value>
        Font LabelFont
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the label font special key.
        /// </summary>
        /// <value>The label font special key.</value>
        Font LabelFontSpecialKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the color of the button border.
        /// </summary>
        /// <value>The color of the button border.</value>
        Color ButtonBorderColor
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the shadow shift.
        /// </summary>
        /// <value>The shadow shift.</value>
        int ShadowShift
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the button rect radius.
        /// </summary>
        /// <value>The button rect radius.</value>
        int ButtonRectRadius
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        Color BackgroundColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        Color ShadowColor
        {
            get;
            set;
        }



        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        Color BorderColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is numeric.
        /// </summary>
        /// <value><c>true</c> if this instance is numeric; otherwise, <c>false</c>.</value>
        bool IsNumeric
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show numeric buttons].
        /// </summary>
        /// <value><c>true</c> if [show numeric buttons]; otherwise, <c>false</c>.</value>
        bool ShowNumericButtons
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets a value indicating whether [show function buttons].
        /// </summary>
        /// <value><c>true</c> if [show function buttons]; otherwise, <c>false</c>.</value>
        bool ShowFunctionButtons
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets a value indicating whether [show background].
        /// </summary>
        /// <value><c>true</c> if [show background]; otherwise, <c>false</c>.</value>
        bool ShowBackground
        {
            get;
            set;
        }





    }

    #endregion

    #region iZeroitVirtualKeyboardButton
    /// <summary>
    /// Interface iZeroitVirtualKeyboardButton
    /// </summary>
    interface iZeroitVirtualKeyboardButton
    {
        /// <summary>
        /// Gets or sets the rectangle.
        /// </summary>
        /// <value>The rectangle.</value>
        Rectangle Rectangle
        { get; set; }

        /// <summary>
        /// Gets or sets the top text.
        /// </summary>
        /// <value>The top text.</value>
        string TopText
        { get; set; }

        /// <summary>
        /// Gets or sets the bottom text.
        /// </summary>
        /// <value>The bottom text.</value>
        string BottomText
        { get; set; }

        /// <summary>
        /// Gets or sets the name of the button.
        /// </summary>
        /// <value>The name of the button.</value>
        string ButtonName
        { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is special key.
        /// </summary>
        /// <value><c>true</c> if this instance is special key; otherwise, <c>false</c>.</value>
        bool IsSpecialKey
        { get; set; }



    }
    #endregion

    #region KeyboardColorTable
    /// <summary>
    /// Class KeyboardColorTable.
    /// </summary>
    internal class KeyboardColorTable
    {
        /// <summary>
        /// The start gradient color
        /// </summary>
        public static readonly Color StartGradientColor = Color.White;
        /// <summary>
        /// The end gradient color
        /// </summary>
        public static readonly Color EndGradientColor = Color.FromArgb(224, 224, 224);
        /// <summary>
        /// The color pressed state
        /// </summary>
        public static readonly Color ColorPressedState = Color.FromArgb(254, 145, 78);

        /// <summary>
        /// The button border color
        /// </summary>
        public static readonly Color ButtonBorderColor = Color.DarkGray;
        /// <summary>
        /// The font color
        /// </summary>
        public static readonly Color FontColor = Color.Black;
        /// <summary>
        /// The background color
        /// </summary>
        public static readonly Color BackgroundColor = Color.FromArgb(164, 209, 255);
        /// <summary>
        /// The shadow color control
        /// </summary>
        public static readonly Color ShadowColorControl = Color.LightGray;
        /// <summary>
        /// The border color
        /// </summary>
        public static readonly Color BorderColor = Color.Black;
        /// <summary>
        /// The font color specialkey
        /// </summary>
        public static readonly Color FontColorSpecialkey = Color.DimGray;
        /// <summary>
        /// The label font
        /// </summary>
        public static readonly Font LabelFont = new Font("Tahoma", 11, FontStyle.Bold,
                                GraphicsUnit.Point, 204);
        /// <summary>
        /// The label font special key
        /// </summary>
        public static readonly Font LabelFontSpecialKey = new Font("Tahoma", 8, FontStyle.Bold,
                        GraphicsUnit.Point, 204);


        /// <summary>
        /// Items the gradient back brush.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <param name="startBackColor">Start color of the back.</param>
        /// <param name="endBackColor">End color of the back.</param>
        /// <returns>LinearGradientBrush.</returns>
        public static LinearGradientBrush ItemGradientBackBrush(Rectangle bounds, Color startBackColor, Color endBackColor)
        {
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, startBackColor, endBackColor, LinearGradientMode.Vertical);
            return linearGradientBrush;
        }


    }
    #endregion

    #region NativeConstants
    /// <summary>
    /// Class NativeConstants.
    /// </summary>
    public static class NativeConstants
    {
        /// <summary>
        /// Gets the pointer information.
        /// </summary>
        /// <param name="pointerID">The pointer identifier.</param>
        /// <param name="pointerInfo">The pointer information.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool GetPointerInfo(int pointerID, ref POINTER_INFO pointerInfo);

        /// <summary>
        /// The wm pointerdown
        /// </summary>
        public const int WM_POINTERDOWN = 0x0246;
        /// <summary>
        /// The wm pointerup
        /// </summary>
        public const int WM_POINTERUP = 0x247;
        /// <summary>
        /// The wm gesturenotify
        /// </summary>
        public const int WM_GESTURENOTIFY = 0x011A;
        /// <summary>
        /// The wm gesture
        /// </summary>
        public const int WM_GESTURE = 0x0119;

        /// <summary>
        /// Enum POINTER_INPUT_TYPE
        /// </summary>
        internal enum POINTER_INPUT_TYPE
        {
            /// <summary>
            /// The pointer
            /// </summary>
            POINTER = 0x00000001,
            /// <summary>
            /// The touch
            /// </summary>
            TOUCH = 0x00000002,
            /// <summary>
            /// The pen
            /// </summary>
            PEN = 0x00000003,
            /// <summary>
            /// The mouse
            /// </summary>
            MOUSE = 0x00000004
        }

        /// <summary>
        /// Enum POINTER_FLAGS
        /// </summary>
        [Flags]
        internal enum POINTER_FLAGS
        {
            /// <summary>
            /// The none
            /// </summary>
            NONE = 0x00000000,
            /// <summary>
            /// The new
            /// </summary>
            NEW = 0x00000001,
            /// <summary>
            /// The inrange
            /// </summary>
            INRANGE = 0x00000002,
            /// <summary>
            /// The incontact
            /// </summary>
            INCONTACT = 0x00000004,
            /// <summary>
            /// The firstbutton
            /// </summary>
            FIRSTBUTTON = 0x00000010,
            /// <summary>
            /// The secondbutton
            /// </summary>
            SECONDBUTTON = 0x00000020,
            /// <summary>
            /// The thirdbutton
            /// </summary>
            THIRDBUTTON = 0x00000040,
            /// <summary>
            /// The fourthbutton
            /// </summary>
            FOURTHBUTTON = 0x00000080,
            /// <summary>
            /// The fifthbutton
            /// </summary>
            FIFTHBUTTON = 0x00000100,
            /// <summary>
            /// The primary
            /// </summary>
            PRIMARY = 0x00002000,
            /// <summary>
            /// The confidence
            /// </summary>
            CONFIDENCE = 0x00004000,
            /// <summary>
            /// The canceled
            /// </summary>
            CANCELED = 0x00008000,
            /// <summary>
            /// Down
            /// </summary>
            DOWN = 0x00010000,
            /// <summary>
            /// The update
            /// </summary>
            UPDATE = 0x00020000,
            /// <summary>
            /// Up
            /// </summary>
            UP = 0x00040000,
            /// <summary>
            /// The wheel
            /// </summary>
            WHEEL = 0x00080000,
            /// <summary>
            /// The hwheel
            /// </summary>
            HWHEEL = 0x00100000,
            /// <summary>
            /// The capturechanged
            /// </summary>
            CAPTURECHANGED = 0x00200000,
        }

        /// <summary>
        /// Enum VIRTUAL_KEY_STATES
        /// </summary>
        [Flags]
        internal enum VIRTUAL_KEY_STATES
        {
            /// <summary>
            /// The none
            /// </summary>
            NONE = 0x0000,
            /// <summary>
            /// The lbutton
            /// </summary>
            LBUTTON = 0x0001,
            /// <summary>
            /// The rbutton
            /// </summary>
            RBUTTON = 0x0002,
            /// <summary>
            /// The shift
            /// </summary>
            SHIFT = 0x0004,
            /// <summary>
            /// The control
            /// </summary>
            CTRL = 0x0008,
            /// <summary>
            /// The mbutton
            /// </summary>
            MBUTTON = 0x0010,
            /// <summary>
            /// The xbutto n1
            /// </summary>
            XBUTTON1 = 0x0020,
            /// <summary>
            /// The xbutto n2
            /// </summary>
            XBUTTON2 = 0x0040
        }

        #region POINT

        /// <summary>
        /// Struct POINT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            /// <summary>
            /// The x
            /// </summary>
            public int X;
            /// <summary>
            /// The y
            /// </summary>
            public int Y;

            /// <summary>
            /// Initializes a new instance of the <see cref="POINT"/> struct.
            /// </summary>
            /// <param name="x">The x.</param>
            /// <param name="y">The y.</param>
            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }
            /// <summary>
            /// Initializes a new instance of the <see cref="POINT"/> struct.
            /// </summary>
            /// <param name="pt">The pt.</param>
            public POINT(Point pt)
            {
                X = pt.X;
                Y = pt.Y;
            }
            /// <summary>
            /// To the point.
            /// </summary>
            /// <returns>Point.</returns>
            public Point ToPoint()
            {
                return new Point(X, Y);
            }
            /// <summary>
            /// Assigns to.
            /// </summary>
            /// <param name="destination">The destination.</param>
            public void AssignTo(ref Point destination)
            {
                destination.X = X;
                destination.Y = Y;
            }
            /// <summary>
            /// Copies from.
            /// </summary>
            /// <param name="source">The source.</param>
            public void CopyFrom(Point source)
            {
                X = source.X;
                Y = source.Y;
            }
            /// <summary>
            /// Copies from.
            /// </summary>
            /// <param name="source">The source.</param>
            public void CopyFrom(POINT source)
            {
                X = source.X;
                Y = source.Y;
            }
        }

        #endregion

        #region POINTER_INFO

        /// <summary>
        /// Struct POINTER_INFO
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct POINTER_INFO
        {
            /// <summary>
            /// The pointer type
            /// </summary>
            public POINTER_INPUT_TYPE pointerType;
            /// <summary>
            /// The pointer identifier
            /// </summary>
            public int PointerID;
            /// <summary>
            /// The frame identifier
            /// </summary>
            public int FrameID;
            /// <summary>
            /// The pointer flags
            /// </summary>
            public POINTER_FLAGS PointerFlags;
            /// <summary>
            /// The source device
            /// </summary>
            public IntPtr SourceDevice;
            /// <summary>
            /// The window target
            /// </summary>
            public IntPtr WindowTarget;
            /// <summary>
            /// The pt pixel location
            /// </summary>
            [MarshalAs(UnmanagedType.Struct)]
            public POINT PtPixelLocation;
            /// <summary>
            /// The pt pixel location raw
            /// </summary>
            [MarshalAs(UnmanagedType.Struct)]
            public POINT PtPixelLocationRaw;
            /// <summary>
            /// The pt himetric location
            /// </summary>
            [MarshalAs(UnmanagedType.Struct)]
            public POINT PtHimetricLocation;
            /// <summary>
            /// The pt himetric location raw
            /// </summary>
            [MarshalAs(UnmanagedType.Struct)]
            public POINT PtHimetricLocationRaw;
            /// <summary>
            /// The time
            /// </summary>
            public uint Time;
            /// <summary>
            /// The history count
            /// </summary>
            public uint HistoryCount;
            /// <summary>
            /// The input data
            /// </summary>
            public uint InputData;
            /// <summary>
            /// The key states
            /// </summary>
            public VIRTUAL_KEY_STATES KeyStates;
            /// <summary>
            /// The performance count
            /// </summary>
            public long PerformanceCount;
            /// <summary>
            /// The button change type
            /// </summary>
            public int ButtonChangeType;
        }

        /// <summary>
        /// Gets the pointer identifier.
        /// </summary>
        /// <param name="wParam">The w parameter.</param>
        /// <returns>System.Int32.</returns>
        internal static int GET_POINTER_ID(IntPtr wParam)
        {
            return LOWORD(wParam);
        }

        /// <summary>
        /// Lowords the specified w parameter.
        /// </summary>
        /// <param name="wParam">The w parameter.</param>
        /// <returns>System.Int32.</returns>
        internal static int LOWORD(IntPtr wParam)
        {
            return (int)(wParam.ToInt64() & 0xffff);
        }

        /// <summary>
        /// Checks the last error.
        /// </summary>
        /// <exception cref="Win32Exception"></exception>
        internal static void CheckLastError()
        {
            int errCode = Marshal.GetLastWin32Error();
            if (errCode != 0)
            {
                throw new Win32Exception(errCode);
            }
        }

        #endregion

    }
    #endregion

    #region RoundedRectangle
    /// <summary>
    /// Class RoundedRectangle.
    /// </summary>
    public abstract class RoundedRectangle
    {

        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath DrawRoundedRectangle(Rectangle rect,
                                          int radius)
        {

            int x = rect.X;
            int y = rect.Y;
            int width = rect.Width;
            int height = rect.Height;

            int xw = x + width;
            int yh = y + height;
            int xwr = xw - radius;
            int yhr = yh - radius;
            int xr = x + radius;
            int yr = y + radius;
            int r2 = radius * 2;
            int xwr2 = xw - r2;
            int yhr2 = yh - r2;

            GraphicsPath p = new GraphicsPath();
            p.StartFigure();

            //Top Left Corner
            if (r2 > 0)
            {
                p.AddArc(x, y, r2, r2, 180, 90);
            }
            else
            {
                p.AddLine(x, yr, x, y);
                p.AddLine(x, y, xr, y);
            }

            //Top Edge
            p.AddLine(xr, y, xwr, y);

            //Top Right Corner
            if (r2 > 0)
            {
                p.AddArc(xwr2, y, r2, r2, 270, 90);
            }
            else
            {
                p.AddLine(xwr, y, xw, y);
                p.AddLine(xw, y, xw, yr);
            }

            //Right Edge
            p.AddLine(xw, yr, xw, yhr);

            //Bottom Right Corner
            if (r2 > 0)
            {
                p.AddArc(xwr2, yhr2, r2, r2, 0, 90);
            }
            else
            {
                p.AddLine(xw, yhr, xw, yh);
                p.AddLine(xw, yh, xwr, yh);
            }

            //Bottom Edge
            p.AddLine(xwr, yh, xr, yh);

            //Bottom Left Corner
            if (r2 > 0)
            {
                p.AddArc(x, yhr2, r2, r2, 90, 90);
            }
            else
            {
                p.AddLine(xr, yh, x, yh);
                p.AddLine(x, yh, x, yhr);
            }

            //Left Edge
            p.AddLine(x, yhr, x, yr);

            p.CloseFigure();
            return p;
        }


    }
    #endregion

    #region VirtualKbButton
    /// <summary>
    /// Class VirtualKbButton.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.iZeroitVirtualKeyboardButton" />
    internal class VirtualKbButton : iZeroitVirtualKeyboardButton
    {
        /// <summary>
        /// Gets or sets the keyboard.
        /// </summary>
        /// <value>The keyboard.</value>
        internal ZeroitVirtualKeyboard Keyboard { set; get; }

        /// <summary>
        /// Gets or sets the rectangle.
        /// </summary>
        /// <value>The rectangle.</value>
        public Rectangle Rectangle { get; set; }
        /// <summary>
        /// Gets or sets the top text.
        /// </summary>
        /// <value>The top text.</value>
        public string TopText { get; set; }
        /// <summary>
        /// Gets or sets the name of the button.
        /// </summary>
        /// <value>The name of the button.</value>
        public string ButtonName { get; set; }
        /// <summary>
        /// Gets or sets the bottom text.
        /// </summary>
        /// <value>The bottom text.</value>
        public string BottomText { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is special key.
        /// </summary>
        /// <value><c>true</c> if this instance is special key; otherwise, <c>false</c>.</value>
        public bool IsSpecialKey { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualKbButton"/> class.
        /// </summary>
        public VirtualKbButton()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualKbButton"/> class.
        /// </summary>
        /// <param name="k">The k.</param>
        public VirtualKbButton(ZeroitVirtualKeyboard k)
        {
            Keyboard = k;
        }

    }
    #endregion

    #region ZeroitVirtualKeyboard    
    /// <summary>
    /// A class collection for rendering a Virtual Keyboard.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    /// <seealso cref="Zeroit.Framework.MiscControls.iZeroitVirtualKeyboard" />
    [Docking(DockingBehavior.Ask)]
    [Designer(typeof(ZeroitVirtualKeyboardDesigner))]
    public class ZeroitVirtualKeyboard : Control, iZeroitVirtualKeyboard
    {


        /// <summary>
        /// Delegate ZeroitVirtualKeyboardButtonPressedHandler
        /// </summary>
        /// <param name="Command">The command.</param>
        public delegate void ZeroitVirtualKeyboardButtonPressedHandler(string Command);
        /// <summary>
        /// Occurs when [keyboard button pressed].
        /// </summary>
        public event ZeroitVirtualKeyboardButtonPressedHandler KeyboardButtonPressed;

        /// <summary>
        /// Occurs when [keyboard click].
        /// </summary>
        public event EventHandler<EventArgs> KeyboardClick;

        #region private fields

        //simulates keyboard SCROLLLOCK and WIN click event
        /// <summary>
        /// Keybds the event.
        /// </summary>
        /// <param name="bVk">The b vk.</param>
        /// <param name="bScan">The b scan.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <param name="dwExtraInfo">The dw extra information.</param>
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        /// <summary>
        /// The keyeventf extendedkey
        /// </summary>
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        /// <summary>
        /// The keyeventf keyup
        /// </summary>
        const int KEYEVENTF_KEYUP = 0x2;
        /// <summary>
        /// The scrolllock
        /// </summary>
        const int SCROLLLOCK = 0x91;
        /// <summary>
        /// The win
        /// </summary>
        const int WIN = 0x5B;

        /// <summary>
        /// The start gradient color
        /// </summary>
        private Color _startGradientColor;
        /// <summary>
        /// The end gradient color
        /// </summary>
        private Color _endGradientColor;
        /// <summary>
        /// The color pressed state
        /// </summary>
        private Color _colorPressedState;
        /// <summary>
        /// The font color
        /// </summary>
        private Color _fontColor;
        /// <summary>
        /// The font color special key
        /// </summary>
        private Color _fontColorSpecialKey;
        /// <summary>
        /// The label font
        /// </summary>
        private Font _labelFont;
        /// <summary>
        /// The label font special key
        /// </summary>
        private Font _labelFontSpecialKey;
        /// <summary>
        /// The button border color
        /// </summary>
        private Color _buttonBorderColor;
        /// <summary>
        /// The shadow shift
        /// </summary>
        private int _shadowShift = 0;
        /// <summary>
        /// The rect radius
        /// </summary>
        private int _rectRadius = 6;
        /// <summary>
        /// The background color
        /// </summary>
        private Color _backgroundColor;
        /// <summary>
        /// The shadow color control
        /// </summary>
        private Color _shadowColorControl;
        /// <summary>
        /// The border color
        /// </summary>
        private Color _borderColor;
        /// <summary>
        /// The is numeric
        /// </summary>
        private bool _isNumeric = false;
        /// <summary>
        /// The show background
        /// </summary>
        private bool _showBackground = true;
        /// <summary>
        /// The show numeric buttons
        /// </summary>
        private bool _showNumericButtons = true;
        /// <summary>
        /// The show function buttons
        /// </summary>
        private bool _showFunctionButtons = false;
        /// <summary>
        /// The BTN coord shift
        /// </summary>
        private const int btnCoordShift = 10; // keyboard padding
        /// <summary>
        /// The mouse click position
        /// </summary>
        private Point mouseClickPosition; // coord. during mouse down event


        /// <summary>
        /// The clicked button name
        /// </summary>
        private string clickedButtonName = String.Empty; // to detect mouse clicked button

        /// <summary>
        /// The BTN columns count
        /// </summary>
        private int btnColumnsCount = 15; // buttons count on the first row
        /// <summary>
        /// The BTN rows count
        /// </summary>
        private int btnRowsCount = 5; // buttons rows count

        /// <summary>
        /// The BTN columns count number
        /// </summary>
        private int btnColumnsCountNum = 4; // num. keyboard buttons count on the first row
        /// <summary>
        /// The BTN rows count number
        /// </summary>
        private int btnRowsCountNum = 4; // num. keyboard buttons rows count

        /// <summary>
        /// The number lock text
        /// </summary>
        public const string numLockText = "Num Lock";
        /// <summary>
        /// The caps text
        /// </summary>
        public const string capsText = "Caps Lock";
        /// <summary>
        /// The enter text
        /// </summary>
        public static string enterText = "Enter ";// + char.ConvertFromUtf32(8626);
        /// <summary>
        /// The shift text
        /// </summary>
        public static string shiftText = char.ConvertFromUtf32(8679);
        /// <summary>
        /// Up text
        /// </summary>
        public static string upText = char.ConvertFromUtf32(8593);
        /// <summary>
        /// The left text
        /// </summary>
        public static string leftText = char.ConvertFromUtf32(8592);
        /// <summary>
        /// Down text
        /// </summary>
        public static string downText = char.ConvertFromUtf32(8595);
        /// <summary>
        /// The right text
        /// </summary>
        public static string rightText = char.ConvertFromUtf32(8594);
        /// <summary>
        /// The delete text
        /// </summary>
        public const string delText = "Del";
        /// <summary>
        /// The control text
        /// </summary>
        public const string ctrlText = "Ctrl";
        /// <summary>
        /// The alt text
        /// </summary>
        public const string altText = "Alt";
        /// <summary>
        /// The space text
        /// </summary>
        public const string spaceText = "Space";
        /// <summary>
        /// The PRT SCR text
        /// </summary>
        public const string prtScrText = "Prt Scr";
        /// <summary>
        /// The back space text
        /// </summary>
        public static string backSpaceText = "Back space";
        /// <summary>
        /// The tab text
        /// </summary>
        public static string tabText = char.ConvertFromUtf32(8646);
        /// <summary>
        /// The escape text
        /// </summary>
        public const string escText = "Esc";
        /// <summary>
        /// The insert text
        /// </summary>
        public const string insertText = "Insert";
        /// <summary>
        /// The scroll lock text
        /// </summary>
        public const string scrollLockText = "Scroll Lock";
        /// <summary>
        /// The win text
        /// </summary>
        public const string winText = "Win";
        /// <summary>
        /// The home text
        /// </summary>
        public const string homeText = "Home";
        /// <summary>
        /// The end text
        /// </summary>
        public const string endText = "End";
        /// <summary>
        /// The page up text
        /// </summary>
        public const string pageUpText = "Pg Up";
        /// <summary>
        /// The page down text
        /// </summary>
        public const string pageDownText = "Pg Dn";


        /// <summary>
        /// The adv BTN
        /// </summary>
        private const string advBtn = "btn_Adv_";
        /// <summary>
        /// The adv BTN naming
        /// </summary>
        private string advBtnNaming = advBtn + "{0}";
        /// <summary>
        /// The symb BTN naming
        /// </summary>
        private string symbBtnNaming = "btn_Symb_{0}";

        /// <summary>
        /// The pattern reg
        /// </summary>
        private const string patternReg = "[{}+^%~()]";
        /// <summary>
        /// The function buttons reg
        /// </summary>
        private const string funcButtonsReg = @"F+[0-9]";


        /// <summary>
        /// The replacement reg
        /// </summary>
        private const string replacementReg = "{$0}";

        /// <summary>
        /// Up command
        /// </summary>
        private const string upCommand = "{UP}";
        /// <summary>
        /// Down command
        /// </summary>
        private const string downCommand = "{DOWN}";
        /// <summary>
        /// The left commmand
        /// </summary>
        private const string leftCommmand = "{LEFT}";
        /// <summary>
        /// The right commmand
        /// </summary>
        private const string rightCommmand = "{RIGHT}";
        /// <summary>
        /// The back space commmand
        /// </summary>
        private const string backSpaceCommmand = "{BACKSPACE}";
        /// <summary>
        /// The enter commmand
        /// </summary>
        private const string enterCommmand = "{ENTER}";

        /// <summary>
        /// The control commmand
        /// </summary>
        private const string ctrlCommmand = "^";
        /// <summary>
        /// The alt commmand
        /// </summary>
        private const string altCommmand = "%";
        /// <summary>
        /// The shift commmand
        /// </summary>
        private const string shiftCommmand = "+";

        /// <summary>
        /// The delete commmand
        /// </summary>
        private const string delCommmand = "{DEL}";
        /// <summary>
        /// The number lock commmand
        /// </summary>
        private const string numLockCommmand = "{NUMLOCK}";
        /// <summary>
        /// The caps lock commmand
        /// </summary>
        private const string capsLockCommmand = "{CAPSLOCK}";
        /// <summary>
        /// The home commmand
        /// </summary>
        private const string homeCommmand = "{HOME}";
        /// <summary>
        /// The end commmand
        /// </summary>
        private const string endCommmand = "{END}";
        /// <summary>
        /// The page up commmand
        /// </summary>
        private const string pageUpCommmand = "{PGUP}";
        /// <summary>
        /// The page down commmand
        /// </summary>
        private const string pageDownCommmand = "{PGDN}";
        /// <summary>
        /// The scrol lock commmand
        /// </summary>
        private const string scrolLockCommmand = "{SCROLLLOCK}";
        /// <summary>
        /// The escape commmand
        /// </summary>
        private const string escCommmand = "{ESC}";
        /// <summary>
        /// The PRT SCR command
        /// </summary>
        private const string prtScrCommand = "{PRTSC}";
        /// <summary>
        /// The insert command
        /// </summary>
        private const string insertCommand = "{INSERT}";
        /// <summary>
        /// The tab command
        /// </summary>
        private const string tabCommand = "{TAB}";

        /// <summary>
        /// The button gap
        /// </summary>
        private int buttonGap = 4; // gap between buttons
        /// <summary>
        /// The number kb gap
        /// </summary>
        private int numKbGap = 10; // gap between numeric are and letter buttons area

        /// <summary>
        /// The sent command
        /// </summary>
        string sentCommand = String.Empty;
        /// <summary>
        /// The sent text
        /// </summary>
        string sentText = String.Empty;

        /// <summary>
        /// The function buttons row
        /// </summary>
        private List<Tuple<string, string>> functionButtonsRow = new List<Tuple<string, string>>
        {
            new Tuple<string, string>(escText,String.Empty),

            new Tuple<string, string>(String.Empty,String.Empty),
            new Tuple<string, string>("F1",String.Empty),
            new Tuple<string, string>("F2",String.Empty),
            new Tuple<string, string>("F3",String.Empty),
            new Tuple<string, string>("F4",String.Empty),
            new Tuple<string, string>("F5",String.Empty),
            new Tuple<string, string>("F6",String.Empty),
            new Tuple<string, string>("F7",String.Empty),
            new Tuple<string, string>("F8",String.Empty),
            new Tuple<string, string>("F9",String.Empty),
            new Tuple<string, string>("F10",String.Empty),
            new Tuple<string, string>("F11",String.Empty),
            new Tuple<string, string>("F12",String.Empty)

        };

        /// <summary>
        /// The first row
        /// </summary>
        private List<Tuple<string, string>> firstRow = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("~", "`"),
            new Tuple<string, string>("!", "1"),
            new Tuple<string, string>("@", "2"),
            new Tuple<string, string>("#", "3"),
            new Tuple<string, string>("$", "4"),
            new Tuple<string, string>("%", "5"),
            new Tuple<string, string>("^", "6"),
            new Tuple<string, string>("&", "7"),
            new Tuple<string, string>("*", "8"),
            new Tuple<string, string>("(", "9"),
            new Tuple<string, string>(")", "0"),
            new Tuple<string, string>("_", "-"),
            new Tuple<string, string>("=", "+"),
            new Tuple<string, string>(backSpaceText, String.Empty)
        };

        /// <summary>
        /// The function row number
        /// </summary>
        private List<Tuple<string, string>> functionRowNum = new List<Tuple<string, string>>
        {
            new Tuple<string, string>(prtScrText, String.Empty),
            new Tuple<string, string>(insertText, String.Empty),
            new Tuple<string, string>(scrollLockText, String.Empty),
            new Tuple<string, string>(winText, String.Empty)
        };

        /// <summary>
        /// The first row number adv
        /// </summary>
        private List<Tuple<string, string>> firstRowNumAdv = new List<Tuple<string, string>>
        {
            new Tuple<string, string>(numLockText, String.Empty),
            new Tuple<string, string>("/", String.Empty),
            new Tuple<string, string>("*", String.Empty),
            new Tuple<string, string>("-", String.Empty)
        };

        /// <summary>
        /// The second row
        /// </summary>
        private List<Tuple<string, string>> secondRow = new List<Tuple<string, string>>
        {
            new Tuple<string, string>(tabText, String.Empty),
            new Tuple<string, string>("Q", String.Empty),
            new Tuple<string, string>("W", String.Empty),
            new Tuple<string, string>("E", String.Empty),
            new Tuple<string, string>("R", String.Empty),
            new Tuple<string, string>("T", String.Empty),
            new Tuple<string, string>("Y", String.Empty),
            new Tuple<string, string>("U", String.Empty),
            new Tuple<string, string>("I", String.Empty),
            new Tuple<string, string>("O", String.Empty),
            new Tuple<string, string>("P", String.Empty),
            new Tuple<string, string>("{", "["),
            new Tuple<string, string>("}", "]"),
            new Tuple<string, string>("|" , "\\")


        };

        /// <summary>
        /// The second row number adv
        /// </summary>
        private List<Tuple<string, string>> secondRowNumAdv = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("7", homeText),
            new Tuple<string, string>("8", String.Empty),
            new Tuple<string, string>("9", pageUpText),
            new Tuple<string, string>("+", String.Empty)
        };

        /// <summary>
        /// The third row
        /// </summary>
        private List<Tuple<string, string>> thirdRow = new List<Tuple<string, string>>
        {
            new Tuple<string, string>(capsText, String.Empty),
            new Tuple<string, string>("A", String.Empty),
            new Tuple<string, string>("S", String.Empty),
            new Tuple<string, string>("D", String.Empty),
            new Tuple<string, string>("F", String.Empty),
            new Tuple<string, string>("G", String.Empty),
            new Tuple<string, string>("H", String.Empty),
            new Tuple<string, string>("J", String.Empty),
            new Tuple<string, string>("K", String.Empty),
            new Tuple<string, string>("L", String.Empty),
            new Tuple<string, string>(":", ";"),
            new Tuple<string, string>("\"" , "'"),
            new Tuple<string, string>(enterText, String.Empty),
            new Tuple<string, string>(String.Empty, String.Empty),


        };

        /// <summary>
        /// The third row number adv
        /// </summary>
        private List<Tuple<string, string>> thirdRowNumAdv = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("4", String.Empty),
            new Tuple<string, string>("5", String.Empty),
            new Tuple<string, string>("6", String.Empty),
            new Tuple<string, string>(String.Empty, String.Empty)
        };


        /// <summary>
        /// The fourth row
        /// </summary>
        private List<Tuple<string, string>> fourthRow = new List<Tuple<string, string>>
        {
            new Tuple<string, string>(shiftText, String.Empty),
            new Tuple<string, string>("Z", String.Empty),
            new Tuple<string, string>("X", String.Empty),
            new Tuple<string, string>("C", String.Empty),
            new Tuple<string, string>("V", String.Empty),
            new Tuple<string, string>("B", String.Empty),
            new Tuple<string, string>("N", String.Empty),
            new Tuple<string, string>("M", String.Empty),
            new Tuple<string, string>("<",","),
            new Tuple<string, string>(">", "."),
            new Tuple<string, string>("?", "/"),
            new Tuple<string, string>(shiftText, String.Empty),
            new Tuple<string, string>(upText, String.Empty),
            new Tuple<string, string>(delText, String.Empty),

        };

        /// <summary>
        /// The fourth row number adv
        /// </summary>
        private List<Tuple<string, string>> fourthRowNumAdv = new List<Tuple<string, string>>
        {

            new Tuple<string, string>("1", endText),
            new Tuple<string, string>("2", String.Empty),
            new Tuple<string, string>("3", pageDownText),
            new Tuple<string, string>(enterText, String.Empty)
        };

        /// <summary>
        /// The fifth row
        /// </summary>
        private List<Tuple<string, string>> fifthRow = new List<Tuple<string, string>>
        {
            new Tuple<string, string>(ctrlText, String.Empty),
            new Tuple<string, string>(altText, String.Empty),
            //new Tuple<string, string>(winText, String.Empty),
            new Tuple<string, string>(spaceText, String.Empty),
            new Tuple<string, string>(altText, String.Empty),

            new Tuple<string, string>(ctrlText, String.Empty),
            new Tuple<string, string>(leftText, String.Empty),
            new Tuple<string, string>(downText, String.Empty),
            new Tuple<string, string>(rightText, String.Empty),

        };

        /// <summary>
        /// The fifth row number adv
        /// </summary>
        private List<Tuple<string, string>> fifthRowNumAdv = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("0", String.Empty),
            new Tuple<string, string>(".", delText),
            new Tuple<string, string>(String.Empty, String.Empty)
        };



        /// <summary>
        /// The first row number
        /// </summary>
        private List<Tuple<string, string>> firstRowNum = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("7", String.Empty),
            new Tuple<string, string>("8", String.Empty),
            new Tuple<string, string>("9", String.Empty),
            new Tuple<string, string>(backSpaceText, String.Empty)
        };

        /// <summary>
        /// The second row number
        /// </summary>
        private List<Tuple<string, string>> secondRowNum = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("4", String.Empty),
            new Tuple<string, string>("5", String.Empty),
            new Tuple<string, string>("6", String.Empty),
            new Tuple<string, string>(delText, String.Empty)
        };

        /// <summary>
        /// The third row number
        /// </summary>
        private List<Tuple<string, string>> thirdRowNum = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("1", String.Empty),
            new Tuple<string, string>("2", String.Empty),
            new Tuple<string, string>("3", String.Empty),
            new Tuple<string, string>(enterText, String.Empty)
        };

        /// <summary>
        /// The fourth row number
        /// </summary>
        private List<Tuple<string, string>> fourthRowNum = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("0", String.Empty),
            new Tuple<string, string>(" ", "."),
            new Tuple<string, string>(leftText, String.Empty),
            new Tuple<string, string>(rightText, String.Empty)
        };

        /// <summary>
        /// The buttons list
        /// </summary>
        private List<VirtualKbButton> buttonsList = new List<VirtualKbButton>();

        /// <summary>
        /// The caps lock state
        /// </summary>
        private bool _capsLockState = false;
        /// <summary>
        /// The number lock state
        /// </summary>
        private bool _numLockState = false;
        /// <summary>
        /// The shift state
        /// </summary>
        private bool _shiftState = false;
        /// <summary>
        /// The control state
        /// </summary>
        private bool _ctrlState = false;
        /// <summary>
        /// The alt state
        /// </summary>
        private bool _altState = false;
        /// <summary>
        /// The scroll lock state
        /// </summary>
        private bool _scrollLockState = false;


        #endregion

        #region iZeroitVirtualKeyboard members

        /// <summary>
        /// The Caps Lock State of the control
        /// </summary>
        /// <value><c>true</c> if [caps lock state]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("Whether the Caps Lock key is pressed.")]
        public bool CapsLockState
        {
            get
            {
                return _capsLockState;
            }
            set
            {
                _capsLockState = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The Num Lock State of the control
        /// </summary>
        /// <value><c>true</c> if [number lock state]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("Whether the Num Lock key is pressed.")]
        public bool NumLockState
        {
            get
            {
                return _numLockState;
            }
            set
            {
                _numLockState = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Shows/Hides numeric area of the control
        /// </summary>
        /// <value><c>true</c> if [show numeric buttons]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("Shows/Hides numeric area of the control.")]
        public bool ShowNumericButtons
        {
            get
            {
                return _showNumericButtons;
            }
            set
            {
                _showNumericButtons = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Shows/Hides function buttons area of the control
        /// </summary>
        /// <value><c>true</c> if [show function buttons]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("Shows/Hides function buttons area of the control.")]
        public bool ShowFunctionButtons
        {
            get
            {
                return _showFunctionButtons;
            }
            set
            {
                _showFunctionButtons = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Shows/Hides background of the control
        /// </summary>
        /// <value><c>true</c> if [show background]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("Shows/Hides background of the control.")]
        public bool ShowBackground
        {
            get
            {
                return _showBackground;
            }
            set
            {
                _showBackground = value;
                Invalidate();
            }
        }


        /// <summary>
        /// The shift State of the control
        /// </summary>
        /// <value><c>true</c> if [shift state]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("Whether Shift key is pressed.")]
        public bool ShiftState
        {
            get
            {
                return _shiftState;
            }
            set
            {
                _shiftState = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The Ctrl State of the control
        /// </summary>
        /// <value><c>true</c> if [control state]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("Whether the Ctrl Lock key is pressed.")]
        public bool CtrlState
        {
            get
            {
                return _ctrlState;
            }
            set
            {
                _ctrlState = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The Alt State of the control
        /// </summary>
        /// <value><c>true</c> if [alt state]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("Whether the Alt Lock key is pressed.")]
        public bool AltState
        {
            get
            {
                return _altState;
            }
            set
            {
                _altState = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The begin gradient color for the buttons
        /// </summary>
        /// <value>The color of the begin gradient.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("The begin grad. color for the buttons.")]
        public Color BeginGradientColor
        {
            get { return _startGradientColor; }
            set
            {
                _startGradientColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The end gradient color of the buttons
        /// </summary>
        /// <value>The end color of the gradient.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("The end grad. color of the buttons.")]
        public Color EndGradientColor
        {
            get { return _endGradientColor; }
            set
            {
                _endGradientColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The color of the buttons when pressed.
        /// </summary>
        /// <value>The state of the color pressed.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("The end grad. color of the buttons.")]
        public Color ColorPressedState
        {
            get { return _colorPressedState; }
            set
            {
                _colorPressedState = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The font color for the buttons
        /// </summary>
        /// <value>The color of the font.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("The font color for the buttons.")]
        public Color FontColor
        {
            get { return _fontColor; }
            set
            {
                _fontColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The font color for the advanced buttons
        /// </summary>
        /// <value>The font color special key.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("The font color for the modifier buttons.")]
        public Color FontColorSpecialKey
        {
            get { return _fontColorSpecialKey; }
            set
            {
                _fontColorSpecialKey = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The font for the buttons
        /// </summary>
        /// <value>The label font.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("The font for the buttons.")]
        public Font LabelFont
        {
            get { return _labelFont; }
            set
            {
                _labelFont = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The font for the advanced buttons
        /// </summary>
        /// <value>The label font special key.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("The font for the modifier buttons.")]
        public Font LabelFontSpecialKey
        {
            get { return _labelFontSpecialKey; }
            set
            {
                _labelFontSpecialKey = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The border color for the buttons
        /// </summary>
        /// <value>The color of the button border.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("The border color for the buttons.")]
        public Color ButtonBorderColor
        {
            get { return _buttonBorderColor; }
            set
            {
                _buttonBorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The shift of the shadow
        /// </summary>
        /// <value>The shadow shift.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">value - /* Out of range value*/</exception>
        [Browsable(true), Category("Virtual Keyboard"), Description("The shift of the shadow.")]
        public int ShadowShift
        {
            get { return _shadowShift; }
            set
            {
                if (value > 15 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "/* Out of range value*/");
                }

                _shadowShift = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The background color of the control
        /// </summary>
        /// <value>The color of the background.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("The background color of the control.")]
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The color of the shadow
        /// </summary>
        /// <value>The color of the shadow.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("The color of the shadow.")]
        public Color ShadowColor
        {
            get { return _shadowColorControl; }
            set
            {
                _shadowColorControl = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The radius of corners for the buttons
        /// </summary>
        /// <value>The button rect radius.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">value - /* Out of range value*/</exception>
        [Browsable(true), Category("Virtual Keyboard"), Description("The radius of corners for the buttons.")]
        public int ButtonRectRadius
        {
            get { return _rectRadius; }
            set
            {
                if (value > 15 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "/* Out of range value*/");
                }
                _rectRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The border color of the control
        /// </summary>
        /// <value>The color of the border.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("The border color of the control.")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Is it numeric keyboard
        /// </summary>
        /// <value><c>true</c> if this instance is numeric; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Virtual Keyboard"), Description("Is it numeric keyboard")]
        public bool IsNumeric
        {
            get { return _isNumeric; }
            set
            {
                _isNumeric = value;
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitVirtualKeyboard" /> class.
        /// </summary>
        public ZeroitVirtualKeyboard()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);


            _startGradientColor = KeyboardColorTable.StartGradientColor;
            _endGradientColor = KeyboardColorTable.EndGradientColor;
            _colorPressedState = KeyboardColorTable.ColorPressedState;
            _fontColor = KeyboardColorTable.FontColor;
            _fontColorSpecialKey = KeyboardColorTable.FontColorSpecialkey;
            _shadowColorControl = KeyboardColorTable.ShadowColorControl;
            _backgroundColor = KeyboardColorTable.BackgroundColor;
            _borderColor = KeyboardColorTable.BorderColor;
            _buttonBorderColor = KeyboardColorTable.ButtonBorderColor;

            _labelFont = KeyboardColorTable.LabelFont;
            _labelFontSpecialKey = KeyboardColorTable.LabelFontSpecialKey;

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.Size = new Size(750, 300);
        }

        #region Paint Methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            DrawKeyboard(e.Graphics);
            base.OnPaint(e);
        }

        /// <summary>
        /// Draws whole keyboard
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        private void DrawKeyboard(Graphics graphics)
        {
            if (ShowBackground)
            {
                DrawBackground(graphics);
            }

            if (!IsNumeric)
            {
                DrawKeyboardItems(graphics);
            }
            else
            {
                DrawKeyboardItemsNumeric(graphics);
            }
        }

        /// <summary>
        /// Draws all rows for numeric keyboard
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        private void DrawKeyboardItemsNumeric(Graphics graphics)
        {
            buttonsList = new List<VirtualKbButton>();

            int totalWidth = Width - ((btnColumnsCountNum - 2) * buttonGap) -
                              ShadowShift - (btnCoordShift * 2);

            int btnWidth = totalWidth / btnColumnsCountNum;

            int btnHeight = (Height - ((btnRowsCountNum - 2) * buttonGap)
                - (btnCoordShift * 2) - ShadowShift) / btnRowsCountNum;

            int calcWidth = btnColumnsCountNum * btnWidth + (btnCoordShift * 2)
                            + ShadowShift + ((btnColumnsCountNum - 1) * buttonGap);


            int calcHeight = btnRowsCountNum * btnHeight + (btnCoordShift * 2)
                            + ShadowShift + ((btnRowsCountNum - 1) * buttonGap);

            int xCoord = ((Width - calcWidth) / 2) + btnCoordShift;
            int yCoord = ((Height - calcHeight) / 2) + btnCoordShift;

            DrawButtonsRow(graphics, firstRowNum, xCoord, yCoord, btnWidth, btnHeight);
            yCoord += btnHeight + buttonGap;

            DrawButtonsRow(graphics, secondRowNum, xCoord, yCoord, btnWidth, btnHeight);
            yCoord += btnHeight + buttonGap;

            DrawButtonsRow(graphics, thirdRowNum, xCoord, yCoord, btnWidth, btnHeight);
            yCoord += btnHeight + buttonGap;

            DrawButtonsRow(graphics, fourthRowNum, xCoord, yCoord, btnWidth, btnHeight);
        }

        /// <summary>
        /// Draws all rows of buttons
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        private void DrawKeyboardItems(Graphics graphics)
        {
            buttonsList = new List<VirtualKbButton>();
            int totalWidth = 0;
            int calcWidth = 0;
            int btnWidth = 0;
            int funcButtonsHeight = 0;

            int totalHeight = 0;
            int btnHeight = 0;
            int calcHeight = 0;

            btnRowsCount = ShowFunctionButtons ? 6 : 5;

            if (ShowNumericButtons)
            {
                btnColumnsCount = firstRow.Count + firstRowNumAdv.Count + 1;
            }
            else
            {
                btnColumnsCount = firstRow.Count() + 1;
            }

            totalWidth = Width - ((btnColumnsCount - 2) * buttonGap) -
                ShadowShift - (btnCoordShift * 2);

            if (ShowNumericButtons)
            {
                totalWidth = totalWidth - numKbGap;
            }

            btnWidth = totalWidth / btnColumnsCount;

            calcWidth = btnColumnsCount * btnWidth + (btnCoordShift * 2)
                + ShadowShift + ((btnColumnsCount - 1) * buttonGap);

            if (ShowNumericButtons)
            {
                calcWidth = calcWidth + numKbGap;
            }

            totalHeight = (Height - ((btnRowsCount - 2) * buttonGap)
                - (btnCoordShift * 2) - ShadowShift);

            if (ShowFunctionButtons)
            {
                totalHeight = totalHeight - numKbGap;
            }



            btnHeight = totalHeight / btnRowsCount;


            calcHeight = btnRowsCount * btnHeight + (btnCoordShift * 2)
                            + ShadowShift + ((btnRowsCount - 1) * buttonGap);

            if (ShowFunctionButtons)
            {
                calcHeight = calcHeight + numKbGap;
                funcButtonsHeight = btnHeight - (btnHeight / 3);
            }

            int xCoord = ((Width - calcWidth) / 2) + btnCoordShift;
            int yCoord = ((Height - calcHeight) / 2) + btnCoordShift;

            List<Tuple<string, string>> funcRowButtons = new List<Tuple<string, string>>();
            List<Tuple<string, string>> firstRowButtons;
            List<Tuple<string, string>> secondRowButtons;
            List<Tuple<string, string>> thirdRowButtons;
            List<Tuple<string, string>> fourthRowButtons;
            List<Tuple<string, string>> fifthRowButtons;

            if (ShowNumericButtons)
            {
                if (ShowFunctionButtons)
                {
                    funcRowButtons = functionButtonsRow
                                        .Concat(functionRowNum)
                                        .ToList();
                }

                firstRowButtons = firstRow
                .Concat(firstRowNumAdv)
                .ToList();

                secondRowButtons = secondRow.
                                    Concat(secondRowNumAdv)
                                    .ToList();

                thirdRowButtons = thirdRow.
                                    Concat(thirdRowNumAdv)
                                    .ToList();

                fourthRowButtons = fourthRow.
                                    Concat(fourthRowNumAdv)
                                    .ToList();


                fifthRowButtons = fifthRow.
                                    Concat(fifthRowNumAdv)
                                    .ToList();
            }

            else
            {
                if (ShowFunctionButtons)
                {
                    funcRowButtons = functionButtonsRow
                                        .ToList();
                }


                firstRowButtons = firstRow;

                secondRowButtons = secondRow;

                thirdRowButtons = thirdRow;

                fourthRowButtons = fourthRow;

                fifthRowButtons = fifthRow;
            }

            if (ShowFunctionButtons)
            {
                DrawButtonsRow(graphics, funcRowButtons, xCoord, yCoord, btnWidth, funcButtonsHeight);
                yCoord += btnHeight + buttonGap + numKbGap;
            }


            DrawButtonsRow(graphics, firstRowButtons, xCoord, yCoord, btnWidth, btnHeight);
            yCoord += btnHeight + buttonGap;

            DrawButtonsRow(graphics, secondRowButtons, xCoord, yCoord, btnWidth, btnHeight);
            yCoord += btnHeight + buttonGap;



            DrawButtonsRow(graphics, thirdRowButtons, xCoord, yCoord, btnWidth, btnHeight);
            yCoord += btnHeight + buttonGap;


            DrawButtonsRow(graphics, fourthRowButtons, xCoord, yCoord, btnWidth, btnHeight);
            yCoord += btnHeight + buttonGap;


            DrawButtonsRow(graphics, fifthRowButtons, xCoord, yCoord, btnWidth, btnHeight);
        }


        /// <summary>
        /// Draws keyboard single row of buttons
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="xCoord">The x coord.</param>
        /// <param name="yCoord">The y coord.</param>
        /// <param name="btnWidth">Width of the BTN.</param>
        /// <param name="btnHeight">Height of the BTN.</param>
        private void DrawButtonsRow(Graphics graphics,
            List<Tuple<string, string>> buttons,
            int xCoord,
            int yCoord,
            int btnWidth,
            int btnHeight)
        {
            Rectangle rect = new Rectangle();
            var btn = new VirtualKbButton();

            int i = 0;
            int spaceBtnW = 7;
            // Draws row of buttons
            foreach (var item in buttons)
            {
                btn = new VirtualKbButton(this);
                btn.TopText = item.Item1;
                btn.BottomText = item.Item2;

                //gives names for buttons
                btn.ButtonName = (i < firstRow.Count || item.Item1 == prtScrText
                    || item.Item1 == insertText ||
                    item.Item1 == scrollLockText ||
                    item.Item1 == winText) ?
                    String.Format(symbBtnNaming, item.Item1) :
                    String.Format(advBtnNaming, Regex.Replace(item.Item1, @"\s+", ""));



                if ((item.Item1 == shiftText &&
                    buttonsList.Any(b => b.ButtonName == String.Format(symbBtnNaming, item.Item1))) ||
                    (item.Item1 == altText &&
                    buttonsList.Any(b => b.ButtonName == String.Format(symbBtnNaming, item.Item1)) ||
                    item.Item1 == ctrlText &&
                    buttonsList.Any(b => b.ButtonName == String.Format(symbBtnNaming, item.Item1)))
                    )
                {
                    btn.ButtonName = btn.ButtonName + "2";
                }


                var isDoubleHeight =
                    (item.Item1 == "+" && i > 13) ||
                    ((item.Item1 == enterText && i > 13));


                var isSpecialKeyButton = IsSpecialKeyText(item.Item1) || IsSpecialKeyText(item.Item2);

                int tabW = btnWidth / 3;
                int capsW = btnWidth / 2;
                int doubleW = btnWidth * 2;
                int funcGap = btnWidth / 2;

                if (!string.IsNullOrEmpty(item.Item1))
                {
                    var w = btnWidth;

                    if (item.Item1 == spaceText)
                    {
                        btnWidth = (btnWidth * (spaceBtnW + 1)) + (buttonGap * spaceBtnW);
                    }

                    if (item.Item1 == "." && item.Item2 == delText)
                    {
                        btnWidth = doubleW + buttonGap;
                    }

                    if (item.Item1 == backSpaceText && !IsNumeric)
                    {
                        btnWidth += (btnWidth) + buttonGap;
                    }

                    if (item.Item1 == tabText)
                    {
                        btnWidth += tabW + buttonGap;
                    }



                    if (item.Item1 == shiftText &&
                        !buttonsList.Any(b => b.TopText == shiftText))
                    {
                        btnWidth = doubleW + buttonGap;
                    }


                    if (item.Item1 == capsText)
                    {
                        btnWidth += capsW + buttonGap;
                    }

                    if (item.Item1 == "|")
                    {
                        int w1 = btnWidth + tabW + buttonGap;
                        int w2 = doubleW + buttonGap;
                        int w3 = w2 - w1;
                        btnWidth = btnWidth + w3;
                    }

                    if (item.Item1 == enterText && !IsNumeric &&
                         !buttonsList.Any(b => b.TopText == enterText))
                    {
                        int w1 = btnWidth + capsW + buttonGap;
                        int w2 = doubleW + buttonGap;
                        int w3 = w2 - w1;

                        btnWidth = btnWidth * 2 + buttonGap + w3;
                    }



                    rect = DrawButton(graphics,
                        xCoord, yCoord, btnWidth,
                        btnHeight,
                        item.Item1,
                        item.Item2,
                        btn.ButtonName,
                        isDoubleHeight);

                    btn.Rectangle = rect;
                    btn.IsSpecialKey = isSpecialKeyButton;

                    buttonsList.Add(btn);

                    btnWidth = w;
                }

                if (item.Item1 == spaceText)
                {
                    xCoord += (btnWidth * spaceBtnW) + (buttonGap * spaceBtnW);
                }

                if (item.Item1 == "." && item.Item2 == delText)
                {
                    xCoord += doubleW + buttonGap;
                }

                if (item.Item1 == backSpaceText)
                {
                    xCoord += (btnWidth) + buttonGap;
                }

                if (item.Item1 == tabText)
                {
                    xCoord += tabW + buttonGap;
                }

                if (item.Item1 == capsText)
                {
                    xCoord += capsW + buttonGap;
                }

                if (item.Item1 == "|")
                {
                    int w1 = btnWidth + tabW + buttonGap;
                    int w2 = doubleW + buttonGap;
                    int w3 = w2 - w1;

                    xCoord += w3;
                }


                if (item.Item1 == enterText && buttonsList.Count(b => b.TopText == enterText) == 1)
                {
                    int w1 = btnWidth + capsW + buttonGap;
                    int w2 = doubleW + buttonGap;
                    int w3 = w2 - w1;

                    xCoord += w3;
                }

                if (item.Item1 == shiftText &&
                    buttonsList.Count(b => b.TopText == shiftText) == 1)
                {
                    xCoord += btnWidth + buttonGap;
                }

                xCoord += (btnWidth + buttonGap);

                //if reached the area of advanced buttons
                if ((i == firstRow.Count - 1 && !buttons.Any(b => b.Item1 == escText)))
                {
                    xCoord += numKbGap;
                }

                //if reached the area of advanced buttons for function buttons row
                if ((i == firstRow.Count - 1 && buttons.Any(b => b.Item1 == escText)))// ||
                {
                    xCoord += numKbGap;
                }


                if (item.Item1 == "F4" || item.Item1 == "F8")
                {
                    xCoord += funcGap;
                }


                i++;

                if (item.Item1 == spaceText)
                {
                    i += (spaceBtnW - 1);
                }
            }
        }

        /// <summary>
        /// Draws keyboard button single rectangle with top and bottom text
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="topText">The top text.</param>
        /// <param name="bottomText">The bottom text.</param>
        /// <param name="clickedButton">The clicked button.</param>
        /// <param name="isDoubleHeight">if set to <c>true</c> [is double height].</param>
        /// <returns>Rectangle.</returns>
        private Rectangle DrawButton(Graphics graphics,
            int x, int y, int width, int height,
            string topText, string bottomText, string clickedButton,
            bool isDoubleHeight)
        {
            Rectangle rect = new Rectangle(x, y, width, !isDoubleHeight ? height : (2 * height) + buttonGap);
            int xTextOffset = 2;
            int yTextTopOffset = 2;
            int yTextBottomOffset = 4;

            int offsetBorder = 1;
            int offsetBorder2 = 2;


            if (topText == spaceText)
            {
                topText = String.Empty;
            }


            if (width > 0 && height > 0)
            {
                var gradientColor = EndGradientColor;
                if ((!string.IsNullOrEmpty(clickedButtonName) && clickedButtonName == clickedButton) ||
                    (ShiftState && topText == shiftText) ||
                    (CapsLockState && topText == capsText) ||
                    (NumLockState && topText == numLockText) ||
                    (CtrlState && topText == ctrlText) ||
                    (AltState && topText == altText) ||
                    (_scrollLockState && topText == scrollLockText))
                {
                    gradientColor = ColorPressedState;
                }

                //Draws button border
                using (SolidBrush solidBrush = new SolidBrush(ControlPaint.Dark(ButtonBorderColor, 0.2f)))
                {
                    GraphicsPath path = RoundedRectangle.DrawRoundedRectangle(rect, _rectRadius);
                    graphics.FillPath(solidBrush, path);
                }

                //Draws button background
                using (LinearGradientBrush gradientBrush = KeyboardColorTable.ItemGradientBackBrush(rect,
                    BeginGradientColor, gradientColor))
                {
                    rect = new Rectangle(rect.X + offsetBorder, rect.Y + offsetBorder,
                        rect.Width - offsetBorder2, rect.Height - offsetBorder2);
                    GraphicsPath path = RoundedRectangle.DrawRoundedRectangle(rect, _rectRadius);
                    graphics.FillPath(gradientBrush, path);
                }


                //Draws button border
                using (Pen pen = new Pen(ControlPaint.Light(SystemColors.InactiveBorder, 0.00f)))
                {
                    rect = new Rectangle(rect.X + offsetBorder, rect.Y + offsetBorder,
                        rect.Width - offsetBorder2, rect.Height - offsetBorder2);
                    GraphicsPath path = RoundedRectangle.DrawRoundedRectangle(rect, _rectRadius);
                    graphics.DrawPath(pen, path);
                }


                var fontTop = !IsSpecialKeyText(topText) ? LabelFont : LabelFontSpecialKey;
                var fontColorTop = !IsSpecialKeyText(topText) ? FontColor : FontColorSpecialKey;

                var fontBottom = !IsSpecialKeyText(bottomText) ? LabelFont : LabelFontSpecialKey;
                var fontColorBottom = !IsSpecialKeyText(bottomText) ? FontColor : FontColorSpecialKey;

                if (topText == tabText || topText == shiftText)
                {
                    fontTop = new Font(fontTop.FontFamily, fontTop.Size * (float)2, fontTop.Style);

                }



                if (string.IsNullOrEmpty(bottomText))
                {
                    var size = graphics.MeasureString(topText, fontTop);

                    //splits button text by space (i.e. Caps Lock, Num Lock...)
                    var buttonText = topText.Split(' ');

                    using (Brush brush = new SolidBrush(fontColorTop))
                    {
                        graphics.TextRenderingHint =
                            System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                        graphics.DrawString(buttonText[0], fontTop, brush,
                            new Point(x + xTextOffset, y + yTextTopOffset));

                        if (buttonText.Count() > 1)
                        {
                            graphics.TextRenderingHint =
                                System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                            yTextTopOffset -= 3;
                            graphics.DrawString(buttonText[1], fontTop, brush,
                                new Point(x + xTextOffset, y + yTextTopOffset + (int)size.Height));
                        }

                    }
                }
                else
                {
                    var size = graphics.MeasureString(topText, fontTop);

                    graphics.TextRenderingHint =
                    System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                    using (Brush brush = new SolidBrush(fontColorTop))
                    {
                        graphics.DrawString(topText, fontTop, brush,
                            new Point(x + xTextOffset, y + yTextTopOffset));
                    }

                    using (Brush brush = new SolidBrush(fontColorBottom))
                    {
                        graphics.DrawString(bottomText, fontBottom, brush,
                            new Point(x + xTextOffset, y + height - (int)size.Height - yTextBottomOffset));
                    }

                }


            }

            return rect;
        }

        /// <summary>
        /// Determines whether [is special key text] [the specified text].
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if [is special key text] [the specified text]; otherwise, <c>false</c>.</returns>
        private bool IsSpecialKeyText(string text)
        {
            var isOptionalButton = text == numLockText || text == backSpaceText ||
                text == capsText || text == enterText || text == shiftText ||
                text == delText || text == upText || text == leftText ||
                text == rightText || text == downText || text == ctrlText ||
                text == altText || text == delText ||
                text == spaceText || text == prtScrText || text == insertText ||
                text == homeText || text == endText || text == pageUpText ||
                text == pageDownText || text == scrollLockText || text == escText ||
                text == tabText || text == winText || Regex.Match(text, funcButtonsReg).Success;

            return isOptionalButton;
        }


        /// <summary>
        /// Draws background with shadow
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        private void DrawBackground(Graphics graphics)
        {
            //filled shadow rect
            Rectangle Rect = new Rectangle(ShadowShift, ShadowShift, Width - ShadowShift, Height - ShadowShift);
            using (Brush brush = new SolidBrush(ShadowColor))
            {
                GraphicsPath path = RoundedRectangle.DrawRoundedRectangle(Rect, 0);
                graphics.FillPath(brush, path);
            }


            //filled background rect
            Rect = new Rectangle(0, 0, Width - ShadowShift, Height - ShadowShift);
            using (Brush BackgroundGradientBrush = new SolidBrush(BackgroundColor))
            {
                GraphicsPath path = RoundedRectangle.DrawRoundedRectangle(Rect, 0);
                graphics.FillPath(BackgroundGradientBrush, path);
            }

            //background border
            using (Pen pen = new Pen(this._borderColor))
            {
                var w = Width - ShadowShift;
                var h = Height - ShadowShift;
                Rect = new Rectangle(0, 0, ShadowShift == 0 ? w - 1 : w
                    , ShadowShift == 0 ? h - 1 : h);
                graphics.DrawRectangle(pen, Rect);
            }

        }
        #endregion

        #region Mouse Events

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            mouseClickPosition = new Point(e.X, e.Y);

            var btn = buttonsList.Where(d =>
                           d.Rectangle.Contains(mouseClickPosition)).SingleOrDefault();
            sentCommand = String.Empty;

            if (btn != null)
            {
                clickedButtonName = btn.ButtonName;

                //if not special key and not numeric kb button pressed
                if (!btn.IsSpecialKey && !btn.ButtonName.Contains(advBtn))
                {
                    string txt = Regex.Replace(btn.TopText, patternReg, replacementReg);

                    if (CtrlState && AltState && ShiftState)
                    {
                        AltState = CtrlState = ShiftState = false;
                        sentCommand = ctrlCommmand + altCommmand + shiftCommmand + txt.ToLower();
                        sentText = txt.ToLower();
                    }
                    else if (CtrlState && AltState)
                    {
                        AltState = CtrlState = false;
                        sentCommand = ctrlCommmand + altCommmand + txt.ToLower();
                        sentText = txt.ToLower();
                    }
                    else if (CtrlState)
                    {
                        CtrlState = false;
                        sentCommand = ctrlCommmand + txt.ToLower();
                        sentText = txt.ToLower();
                    }
                    else if (AltState)
                    {
                        AltState = false;
                        sentCommand = altCommmand + txt.ToLower();
                        sentText = txt.ToLower();
                    }


                    else
                    {
                        if (ShiftState && CapsLockState)
                        {
                            sentCommand = txt.ToLower();
                            sentText = sentCommand;
                            ShiftState = false;
                        }

                        else if (ShiftState || CapsLockState)
                        {
                            if (ShiftState)
                            {
                                sentCommand = txt;
                                sentText = sentCommand;
                                ShiftState = false;
                            }

                            else if (CapsLockState)
                            {
                                sentCommand = string.IsNullOrEmpty(btn.BottomText) ? txt.ToUpper() : btn.BottomText;
                                sentText = sentCommand;
                            }

                            else
                            {
                                sentCommand = string.IsNullOrEmpty(btn.BottomText) ? btn.BottomText : txt;
                                sentText = sentCommand;
                            }
                        }

                        else
                        {
                            sentCommand = !string.IsNullOrEmpty(btn.BottomText)
                                ? btn.BottomText.ToLower()
                                : txt.ToLower();
                            sentText = sentCommand;
                        }

                    }

                }
                else
                {
                    if (btn.TopText == shiftText)
                    {
                        ShiftState = !ShiftState;
                        sentText = shiftText;
                    }

                    if (btn.TopText == scrollLockText)
                    {
                        _scrollLockState = !_scrollLockState;
                        sentCommand = scrolLockCommmand;
                        sentText = scrollLockText;
                        keybd_event(SCROLLLOCK, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                        keybd_event(SCROLLLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);

                    }

                    if (btn.TopText == capsText)
                    {
                        CapsLockState = !CapsLockState;
                        sentCommand = capsLockCommmand;
                        sentText = capsText;

                    }

                    if (btn.TopText == ctrlText)
                    {
                        CtrlState = !CtrlState;
                        sentText = ctrlText;
                    }

                    if (btn.TopText == altText)
                    {
                        AltState = !AltState;
                        sentText = altText;
                    }

                    if (btn.TopText == escText)
                    {
                        sentCommand = escCommmand;
                        sentText = escText;
                    }


                    if (btn.TopText == enterText)
                    {
                        sentCommand = enterCommmand;
                        sentText = enterText;
                    }

                    if (btn.TopText == tabText)
                    {
                        sentCommand = tabCommand;
                        sentText = enterText;
                    }

                    if (btn.TopText == prtScrText)
                    {
                        sentCommand = prtScrCommand;
                        sentText = prtScrText;
                    }

                    if (btn.TopText == spaceText)
                    {
                        sentCommand = " ";
                        sentText = sentCommand;

                    }

                    if (btn.TopText == delText)
                    {
                        sentCommand = delCommmand;
                        sentText = delText;
                    }

                    //var sds = String.Format(symbBtnNaming, backSpaceText);
                    if (btn.TopText == backSpaceText)
                    {

                        sentCommand = backSpaceCommmand;
                    }

                    if (btn.TopText == numLockText)
                    {
                        NumLockState = !NumLockState;
                        sentCommand = numLockCommmand;
                        sentText = numLockText;
                    }

                    if (btn.TopText == upText)
                    {
                        sentCommand = upCommand;
                        sentText = upText;
                    }


                    if (btn.TopText == leftText)
                    {
                        sentCommand = leftCommmand;
                        sentText = leftText;
                    }

                    if (btn.TopText == rightText)
                    {
                        sentCommand = rightCommmand;
                        sentText = rightText;
                    }

                    if (btn.TopText == downText)
                    {
                        sentCommand = downCommand;
                        sentText = downText;
                    }

                    if (btn.TopText == winText)
                    {
                        keybd_event(WIN, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                        keybd_event(WIN, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
                        sentText = winText;
                    }

                    if (btn.TopText == insertText)
                    {
                        sentCommand = insertCommand;
                        sentText = insertText;
                    }

                    // if function button pressed
                    if (Regex.Match(btn.TopText, funcButtonsReg).Success)
                    {
                        var funcCommand = "{" + btn.TopText + "}";
                        sentText = btn.TopText;

                        if (CtrlState && AltState && ShiftState)
                        {
                            AltState = CtrlState = ShiftState = false;
                            sentCommand = ctrlCommmand + altCommmand + shiftCommmand + funcCommand;

                        }
                        else if (CtrlState && AltState)
                        {
                            AltState = CtrlState = false;
                            sentCommand = ctrlCommmand + altCommmand + funcCommand;
                        }
                        else if (CtrlState && ShiftState)
                        {
                            AltState = ShiftState = false;
                            sentCommand = ctrlCommmand + shiftCommmand + funcCommand;
                        }
                        else if (CtrlState)
                        {
                            CtrlState = false;
                            sentCommand = ctrlCommmand + funcCommand;
                        }
                        else if (AltState)
                        {
                            AltState = false;
                            sentCommand = altCommmand + funcCommand;
                        }
                        else
                        {
                            sentCommand = funcCommand;
                        }
                    }

                    // if button in the numeric area  pressed
                    if (btn.ButtonName.Contains(advBtn))
                    {
                        if (!NumLockState)
                        {
                            if (!string.IsNullOrEmpty(btn.BottomText))
                            {
                                if (btn.BottomText == homeText)
                                {
                                    sentCommand = homeCommmand;
                                    sentText = homeText;
                                }

                                if (btn.BottomText == endText)
                                {
                                    sentCommand = endCommmand;
                                    sentText = endText;
                                }

                                if (btn.BottomText == pageDownText)
                                {
                                    sentCommand = pageDownCommmand;
                                    sentText = pageDownText;
                                }

                                if (btn.BottomText == pageUpText)
                                {
                                    sentCommand = pageUpCommmand;
                                    sentText = pageUpText;
                                }

                                if (btn.BottomText == delText)
                                {
                                    sentCommand = delCommmand;
                                    sentText = delText;
                                }
                            }
                        }
                        else
                        {
                            if (!btn.TopText.Contains(numLockText) && !btn.TopText.Contains(enterText))
                            {
                                sentCommand = Regex.Replace(btn.TopText, patternReg, replacementReg);
                                sentText = btn.TopText;
                            }
                        }

                    }
                }

                Invalidate();
                KeyPressed(sentText);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            clickedButtonName = null;
            if (KeyboardClick != null)
            {
                KeyboardClick(this, EventArgs.Empty);
            }

            Invalidate();
        }



        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            if (!string.IsNullOrEmpty(sentCommand))
            {
                SendKeys.Send(sentCommand);
                sentCommand = String.Empty;
            }
        }

        /// <summary>
        /// Keys the pressed.
        /// </summary>
        /// <param name="txt">The text.</param>
        public void KeyPressed(string txt)
        {
            if (KeyboardButtonPressed != null)
            {
                KeyboardButtonPressed(txt);
            }
        }



        /// <summary>
        /// To recognize MouseDown, MouseUp events on a touch device
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeConstants.WM_POINTERDOWN:
                    break;
                case NativeConstants.WM_POINTERUP:
                    break;
                default:
                    base.WndProc(ref m);
                    return;
            }


            int pointerID = NativeConstants.GET_POINTER_ID(m.WParam);
            NativeConstants.POINTER_INFO pi = new NativeConstants.POINTER_INFO();
            if (!NativeConstants.GetPointerInfo(pointerID, ref pi))
            {
                NativeConstants.CheckLastError();
            }
            Point pt = PointToClient(pi.PtPixelLocation.ToPoint());
            MouseEventArgs me = new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, pt.X, pt.Y, 0);
            switch (m.Msg)
            {
                case NativeConstants.WM_POINTERDOWN:
                    OnMouseDown(me);
                    OnClick(me);
                    break;
                case NativeConstants.WM_POINTERUP:
                    OnMouseUp(me);
                    break;

            }
        }
        #endregion


    }

    #region Smart Tag Methods


    /// <summary>
    /// Class ZeroitVirtualKeyboardDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitVirtualKeyboardDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitVirtualKeyboardActionList(this.Component));
                }
                return actionLists;
            }
        }
    }



    /// <summary>
    /// Class ZeroitVirtualKeyboardActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitVirtualKeyboardActionList : System.ComponentModel.Design.DesignerActionList
    {
        /// <summary>
        /// The keyb control
        /// </summary>
        private ZeroitVirtualKeyboard keybControl;

        //The constructor associates the control with the smart tag list.
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitVirtualKeyboardActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitVirtualKeyboardActionList(IComponent component)
            : base(component)
        {
            this.keybControl = component as ZeroitVirtualKeyboard;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="System.ArgumentException">Matching ZeroitVirtualKeyboard property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(keybControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ZeroitVirtualKeyboard property not found!", propName);
            else
                return prop;
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>System.String.</returns>
        private static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            return (propertyExpression.Body as MemberExpression).Member.Name;
        }

        // Properties that are targets of DesignerActionPropertyItem entries.
        /// <summary>
        /// Gets or sets a value indicating whether [show numeric buttons].
        /// </summary>
        /// <value><c>true</c> if [show numeric buttons]; otherwise, <c>false</c>.</value>
        public bool ShowNumericButtons
        {
            get
            {
                return keybControl.ShowNumericButtons;
            }
            set
            {
                GetPropertyByName(GetPropertyName(() => keybControl.ShowNumericButtons)).SetValue(keybControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show function buttons].
        /// </summary>
        /// <value><c>true</c> if [show function buttons]; otherwise, <c>false</c>.</value>
        public bool ShowFunctionButtons
        {
            get
            {
                return keybControl.ShowFunctionButtons;
            }
            set
            {
                GetPropertyByName(GetPropertyName(() => keybControl.ShowFunctionButtons)).SetValue(keybControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is numeric.
        /// </summary>
        /// <value><c>true</c> if this instance is numeric; otherwise, <c>false</c>.</value>
        public bool IsNumeric
        {
            get
            {
                return keybControl.IsNumeric;
            }
            set
            {
                GetPropertyByName(GetPropertyName(() => keybControl.IsNumeric)).
                    SetValue(keybControl, value);
            }
        }



        // Implementation of this abstract method creates smart tag  items, associates their targets, and collects into list.
        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            var appearanceArea = "Appearance";
            items.Add(new DesignerActionHeaderItem(appearanceArea));

            items.Add(new DesignerActionPropertyItem(GetPropertyName(() => keybControl.ShowNumericButtons),
                                 "Show Numeric Buttons", appearanceArea,
                                 "Shows/Hides numeric area."));
            items.Add(new DesignerActionPropertyItem(GetPropertyName(() => keybControl.ShowFunctionButtons),
                                 "Show Function Buttons", appearanceArea,
                                 "Shows/Hides function buttons area."));
            items.Add(new DesignerActionPropertyItem(GetPropertyName(() => keybControl.IsNumeric),
                     "Numeric keyboard", appearanceArea,
                     "Is it numeric keyboard"));



            return items;
        }

    }

    #endregion


    #endregion

    #endregion


}
