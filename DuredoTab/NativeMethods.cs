// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NativeMethods.cs" company="Zeroit Dev Technologies">
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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.Tabs
{
    /// <summary>
    /// Description of NativeMethods.
    /// </summary>
    //[SecurityPermission(SecurityAction.Assert, Flags=SecurityPermissionFlag.UnmanagedCode)]
    internal sealed class NativeMethods
	{
        /// <summary>
        /// Prevents a default instance of the <see cref="NativeMethods"/> class from being created.
        /// </summary>
        private NativeMethods(){}

        #region Windows Constants

        /// <summary>
        /// The wm gettabrect
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		public const int WM_GETTABRECT = 0x130a;
        /// <summary>
        /// The ws ex transparent
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		public const int WS_EX_TRANSPARENT = 0x20;
        /// <summary>
        /// The wm setfont
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		public const int WM_SETFONT = 0x30;
        /// <summary>
        /// The wm fontchange
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		public const int WM_FONTCHANGE = 0x1d;
        /// <summary>
        /// The wm hscroll
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		public const int WM_HSCROLL = 0x114;
        /// <summary>
        /// The TCM hittest
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		public const int TCM_HITTEST = 0x130D;
        /// <summary>
        /// The wm paint
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		public const int WM_PAINT = 0xf;
        /// <summary>
        /// The ws ex layoutrtl
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		public const int WS_EX_LAYOUTRTL  = 0x400000;
        /// <summary>
        /// The ws ex noinheritlayout
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		public const int WS_EX_NOINHERITLAYOUT = 0x100000;


        #endregion

        #region Content Alignment

        /// <summary>
        /// Any right align
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		public static readonly ContentAlignment AnyRightAlign = ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight;
        /// <summary>
        /// Any left align
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		public static readonly ContentAlignment AnyLeftAlign = ContentAlignment.BottomLeft | ContentAlignment.MiddleLeft | ContentAlignment.TopLeft;
        /// <summary>
        /// Any top align
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
	    public static readonly ContentAlignment AnyTopAlign = ContentAlignment.TopRight | ContentAlignment.TopCenter | ContentAlignment.TopLeft;
        /// <summary>
        /// Any bottom align
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
	    public static readonly ContentAlignment AnyBottomAlign = ContentAlignment.BottomRight | ContentAlignment.BottomCenter | ContentAlignment.BottomLeft;
        /// <summary>
        /// Any middle align
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
	    public static readonly ContentAlignment AnyMiddleAlign = ContentAlignment.MiddleRight | ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft;
        /// <summary>
        /// Any center align
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		public static readonly ContentAlignment AnyCenterAlign = ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter;

        #endregion

        #region User32.dll

        //        [DllImport("user32.dll"), SecurityPermission(SecurityAction.Demand)]
        //		public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>IntPtr.</returns>
        public static IntPtr SendMessage (IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam){
			//	This Method replaces the User32 method SendMessage, but will only work for sending
			//	messages to Managed controls.
			Control control = Control.FromHandle(hWnd);
			if (control == null){
				return IntPtr.Zero;
			}
			
			Message message = new Message();
			message.HWnd = hWnd;
			message.LParam = lParam;
			message.WParam = wParam;
			message.Msg = msg;
			
			MethodInfo wproc = control.GetType().GetMethod("WndProc"
			                                               , BindingFlags.NonPublic 
			                                                | BindingFlags.InvokeMethod 
			                                                | BindingFlags.FlattenHierarchy 
			                                                | BindingFlags.IgnoreCase 
			                                                | BindingFlags.Instance);
			
			object[] args = new object[] {message};
			wproc.Invoke(control, args);
			
			return ((Message)args[0]).Result;
		}


        //		[DllImport("user32.dll")]
        //		public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT paintStruct);
        //		
        //		[DllImport("user32.dll")]
        //		[return: MarshalAs(UnmanagedType.Bool)]
        //		public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT paintStruct);
        //
        #endregion

        #region Misc Functions

        /// <summary>
        /// Loes the word.
        /// </summary>
        /// <param name="dWord">The d word.</param>
        /// <returns>System.Int32.</returns>
        public static int LoWord(IntPtr dWord){
            return dWord.ToInt32() & 0xffff;
        }

        /// <summary>
        /// His the word.
        /// </summary>
        /// <param name="dWord">The d word.</param>
        /// <returns>System.Int32.</returns>
        public static int HiWord(IntPtr dWord){
            if ((dWord.ToInt32() & 0x80000000) == 0x80000000)
                return (dWord.ToInt32() >> 16);
            else
                return (dWord.ToInt32() >> 16) & 0xffff;
        }

        /// <summary>
        /// To the int PTR.
        /// </summary>
        /// <param name="structure">The structure.</param>
        /// <returns>IntPtr.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2106:SecureAsserts")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
 		public static IntPtr ToIntPtr(object structure){
			IntPtr lparam = IntPtr.Zero;
			lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(structure));
			Marshal.StructureToPtr(structure, lparam, false);
			return lparam;
		}


        #endregion

        #region Windows Structures and Enums

        /// <summary>
        /// Enum TCHITTESTFLAGS
        /// </summary>
        [Flags()]
		public enum TCHITTESTFLAGS{
            /// <summary>
            /// The TCHT nowhere
            /// </summary>
            TCHT_NOWHERE = 1,
            /// <summary>
            /// The TCHT onitemicon
            /// </summary>
            TCHT_ONITEMICON = 2,
            /// <summary>
            /// The TCHT onitemlabel
            /// </summary>
            TCHT_ONITEMLABEL = 4,
            /// <summary>
            /// The TCHT onitem
            /// </summary>
            TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL
		}



        /// <summary>
        /// Struct TCHITTESTINFO
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
		public struct TCHITTESTINFO{

            /// <summary>
            /// Initializes a new instance of the <see cref="TCHITTESTINFO"/> struct.
            /// </summary>
            /// <param name="location">The location.</param>
            public TCHITTESTINFO(Point location){
				pt = location;
				flags = TCHITTESTFLAGS.TCHT_ONITEM;
			}

            /// <summary>
            /// The pt
            /// </summary>
            public Point pt;
            /// <summary>
            /// The flags
            /// </summary>
            public TCHITTESTFLAGS flags;
		}

        /// <summary>
        /// Struct PAINTSTRUCT
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct PAINTSTRUCT{
            /// <summary>
            /// The HDC
            /// </summary>
            public IntPtr hdc;
            /// <summary>
            /// The f erase
            /// </summary>
            public int fErase;
            /// <summary>
            /// The rc paint
            /// </summary>
            public RECT rcPaint;
            /// <summary>
            /// The f restore
            /// </summary>
            public int fRestore;
            /// <summary>
            /// The f inc update
            /// </summary>
            public int fIncUpdate;
            /// <summary>
            /// The RGB reserved
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=32)] 
		    public byte[] rgbReserved;
		}

        /// <summary>
        /// Struct RECT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
		public struct RECT{
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
            /// Initializes a new instance of the <see cref="RECT"/> struct.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="top">The top.</param>
            /// <param name="right">The right.</param>
            /// <param name="bottom">The bottom.</param>
            public RECT(int left, int top, int right, int bottom){
		        this.left = left;
		        this.top = top;
		        this.right = right;
		        this.bottom = bottom;
		    }

            /// <summary>
            /// Initializes a new instance of the <see cref="RECT"/> struct.
            /// </summary>
            /// <param name="r">The r.</param>
            public RECT(Rectangle r){
		        this.left = r.Left;
		        this.top = r.Top;
		        this.right = r.Right;
		        this.bottom = r.Bottom;
		    }

            /// <summary>
            /// Froms the xywh.
            /// </summary>
            /// <param name="x">The x.</param>
            /// <param name="y">The y.</param>
            /// <param name="width">The width.</param>
            /// <param name="height">The height.</param>
            /// <returns>RECT.</returns>
            public static RECT FromXYWH(int x, int y, int width, int height){
		        return new RECT(x, y, x + width, y + height);
		    }

            /// <summary>
            /// Froms the int PTR.
            /// </summary>
            /// <param name="ptr">The PTR.</param>
            /// <returns>RECT.</returns>
            public static RECT FromIntPtr(IntPtr ptr){
		    	RECT rect = (RECT)Marshal.PtrToStructure(ptr, typeof(RECT));
		    	return rect;
		    }

            /// <summary>
            /// Gets the size.
            /// </summary>
            /// <value>The size.</value>
            public Size Size{
		        get{
		            return new Size(this.right - this.left, this.bottom - this.top);
		        }
		    }
		}
		

#endregion

	}
	
}
