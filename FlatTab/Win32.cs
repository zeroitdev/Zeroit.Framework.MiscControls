// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-13-2017
// ***********************************************************************
// <copyright file="Win32.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.MiscControls.Tabs.FlatTab
{
    /// <summary>
    /// Class Win32.
    /// </summary>
    internal class Win32
	{
        /*
		 * GetWindow() Constants
		 */
        /// <summary>
        /// The gw hwndfirst
        /// </summary>
        public const int GW_HWNDFIRST			= 0;
        /// <summary>
        /// The gw hwndlast
        /// </summary>
        public const int GW_HWNDLAST			= 1;
        /// <summary>
        /// The gw hwndnext
        /// </summary>
        public const int GW_HWNDNEXT			= 2;
        /// <summary>
        /// The gw hwndprev
        /// </summary>
        public const int GW_HWNDPREV			= 3;
        /// <summary>
        /// The gw owner
        /// </summary>
        public const int GW_OWNER				= 4;
        /// <summary>
        /// The gw child
        /// </summary>
        public const int GW_CHILD				= 5;

        /// <summary>
        /// The wm nccalcsize
        /// </summary>
        public const int WM_NCCALCSIZE			= 0x83;
        /// <summary>
        /// The wm windowposchanging
        /// </summary>
        public const int WM_WINDOWPOSCHANGING	= 0x46;
        /// <summary>
        /// The wm paint
        /// </summary>
        public const int WM_PAINT				= 0xF;
        /// <summary>
        /// The wm create
        /// </summary>
        public const int WM_CREATE				= 0x1;
        /// <summary>
        /// The wm nccreate
        /// </summary>
        public const int WM_NCCREATE			= 0x81;
        /// <summary>
        /// The wm ncpaint
        /// </summary>
        public const int WM_NCPAINT				= 0x85;
        /// <summary>
        /// The wm print
        /// </summary>
        public const int WM_PRINT				= 0x317;
        /// <summary>
        /// The wm destroy
        /// </summary>
        public const int WM_DESTROY				= 0x2;
        /// <summary>
        /// The wm showwindow
        /// </summary>
        public const int WM_SHOWWINDOW			= 0x18;
        /// <summary>
        /// The wm shared menu
        /// </summary>
        public const int WM_SHARED_MENU			= 0x1E2;
        /// <summary>
        /// The hc action
        /// </summary>
        public const int HC_ACTION				= 0;
        /// <summary>
        /// The wh callwndproc
        /// </summary>
        public const int WH_CALLWNDPROC			= 4;
        /// <summary>
        /// The GWL wndproc
        /// </summary>
        public const int GWL_WNDPROC			= -4;

        /// <summary>
        /// Initializes a new instance of the <see cref="Win32"/> class.
        /// </summary>
        public Win32()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        /// <summary>
        /// Gets the window dc.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("User32.dll",CharSet = CharSet.Auto)]
		public static extern IntPtr GetWindowDC(IntPtr handle);

        /// <summary>
        /// Releases the dc.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <param name="hDC">The h dc.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("User32.dll",CharSet = CharSet.Auto)]
		public static extern IntPtr ReleaseDC(IntPtr handle, IntPtr hDC);

        /// <summary>
        /// Creates the compatible dc.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("Gdi32.dll",CharSet = CharSet.Auto)]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        /// <summary>
        /// Gets the name of the class.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="maxCount">The maximum count.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("User32.dll",CharSet = CharSet.Auto)]
		public static extern int GetClassName(IntPtr hwnd, char[] className, int maxCount);

        /// <summary>
        /// Gets the window.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="uCmd">The u command.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("User32.dll",CharSet = CharSet.Auto)]
		public static extern IntPtr GetWindow(IntPtr hwnd, int uCmd);

        /// <summary>
        /// Determines whether [is window visible] [the specified HWND].
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <returns><c>true</c> if [is window visible] [the specified HWND]; otherwise, <c>false</c>.</returns>
        [DllImport("User32.dll",CharSet = CharSet.Auto)]
		public static extern bool IsWindowVisible(IntPtr hwnd);

        /// <summary>
        /// Gets the client rect.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="lpRect">The lp rect.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32",CharSet = CharSet.Auto)]
		public static extern int GetClientRect(IntPtr hwnd, ref RECT lpRect);

        /// <summary>
        /// Gets the client rect.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="rect">The rect.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32",CharSet = CharSet.Auto)]
		public static extern int GetClientRect(IntPtr hwnd, [In, Out] ref Rectangle rect);

        /// <summary>
        /// Moves the window.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <param name="bRepaint">if set to <c>true</c> [b repaint].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32",CharSet = CharSet.Auto)]
		public static extern bool MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        /// <summary>
        /// Updates the window.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32",CharSet = CharSet.Auto)]
		public static extern bool UpdateWindow(IntPtr hwnd);

        /// <summary>
        /// Invalidates the rect.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="bErase">if set to <c>true</c> [b erase].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32",CharSet = CharSet.Auto)]
		public static extern bool InvalidateRect(IntPtr hwnd, ref Rectangle rect, bool bErase);

        /// <summary>
        /// Validates the rect.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="rect">The rect.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32",CharSet = CharSet.Auto)]
		public static extern bool ValidateRect(IntPtr hwnd, ref Rectangle rect);

        /// <summary>
        /// Gets the window rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="rect">The rect.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll",CharSet = CharSet.Auto)]
		internal static extern bool GetWindowRect(IntPtr hWnd, [In, Out] ref Rectangle rect);

        /// <summary>
        /// Struct RECT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
			public struct RECT 
		{
            /// <summary>
            /// The left
            /// </summary>
            public int Left;
            /// <summary>
            /// The top
            /// </summary>
            public int Top;
            /// <summary>
            /// The right
            /// </summary>
            public int Right;
            /// <summary>
            /// The bottom
            /// </summary>
            public int Bottom;
		}

        /// <summary>
        /// Struct WINDOWPOS
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
		public struct WINDOWPOS
		{
            /// <summary>
            /// The HWND
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            /// The HWND after
            /// </summary>
            public IntPtr hwndAfter;
            /// <summary>
            /// The x
            /// </summary>
            public int x;
            /// <summary>
            /// The y
            /// </summary>
            public int y;
            /// <summary>
            /// The cx
            /// </summary>
            public int cx;
            /// <summary>
            /// The cy
            /// </summary>
            public int cy;
            /// <summary>
            /// The flags
            /// </summary>
            public uint flags;
		}

        /// <summary>
        /// Struct NCCALCSIZE_PARAMS
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
			public struct NCCALCSIZE_PARAMS
		{
            /// <summary>
            /// The RGC
            /// </summary>
            public RECT rgc;
            /// <summary>
            /// The wndpos
            /// </summary>
            public WINDOWPOS wndpos;
		}
	}

    #region SubClass Classing Handler Class
    /// <summary>
    /// Class SubClass.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.NativeWindow" />
    internal class SubClass : System.Windows.Forms.NativeWindow
	{
        /// <summary>
        /// Delegate SubClassWndProcEventHandler
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns>System.Int32.</returns>
        public delegate int SubClassWndProcEventHandler(ref System.Windows.Forms.Message m);
        /// <summary>
        /// Occurs when [sub classed WND proc].
        /// </summary>
        public event SubClassWndProcEventHandler SubClassedWndProc;
        /// <summary>
        /// The is sub classed
        /// </summary>
        private bool IsSubClassed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubClass"/> class.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="_SubClass">if set to <c>true</c> [sub class].</param>
        public SubClass(IntPtr Handle, bool _SubClass)
		{
			base.AssignHandle(Handle);
			this.IsSubClassed = _SubClass;
		}

        /// <summary>
        /// Gets or sets a value indicating whether [sub classed].
        /// </summary>
        /// <value><c>true</c> if [sub classed]; otherwise, <c>false</c>.</value>
        public bool SubClassed
		{
			get{ return this.IsSubClassed; }
			set{ this.IsSubClassed = value; }
		}

        /// <summary>
        /// Invokes the default window procedure associated with this window.
        /// </summary>
        /// <param name="m">A <see cref="T:System.Windows.Forms.Message" /> that is associated with the current Windows message.</param>
        protected override void WndProc(ref Message m) 
		{
			if (this.IsSubClassed)
			{
				if (OnSubClassedWndProc(ref m) != 0)
					return;
			}
			base.WndProc(ref m);
		}

        /// <summary>
        /// Calls the default WND proc.
        /// </summary>
        /// <param name="m">The m.</param>
        public void CallDefaultWndProc(ref Message m)
		{
			base.WndProc(ref m);
		}

        #region HiWord Message Cracker
        /// <summary>
        /// His the word.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        public int HiWord(int Number) 
		{
			return ((Number >> 16) & 0xffff);
		}
        #endregion

        #region LoWord Message Cracker
        /// <summary>
        /// Loes the word.
        /// </summary>
        /// <param name="Number">The number.</param>
        /// <returns>System.Int32.</returns>
        public int LoWord(int Number) 
		{
			return (Number & 0xffff);
		}
        #endregion

        #region MakeLong Message Cracker
        /// <summary>
        /// Makes the long.
        /// </summary>
        /// <param name="LoWord">The lo word.</param>
        /// <param name="HiWord">The hi word.</param>
        /// <returns>System.Int32.</returns>
        public int MakeLong(int LoWord, int HiWord) 
		{ 
			return (HiWord << 16) | (LoWord & 0xffff); 
		}
        #endregion

        #region MakeLParam Message Cracker
        /// <summary>
        /// Makes the l parameter.
        /// </summary>
        /// <param name="LoWord">The lo word.</param>
        /// <param name="HiWord">The hi word.</param>
        /// <returns>IntPtr.</returns>
        public IntPtr MakeLParam(int LoWord, int HiWord) 
		{ 
			return (IntPtr) ((HiWord << 16) | (LoWord & 0xffff)); 
		}
        #endregion

        /// <summary>
        /// Called when [sub classed WND proc].
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns>System.Int32.</returns>
        private int OnSubClassedWndProc(ref Message m)
		{
			if (SubClassedWndProc != null)
			{
				return this.SubClassedWndProc(ref m);
			}

			return 0;
		}
	}
	#endregion
}
