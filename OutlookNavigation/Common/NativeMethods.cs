// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NativeMethods.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License and Copyright

/*
 
Author:  Jacob Mesu
 
Attribution-Noncommercial-Share Alike 3.0 Unported
You are free:

    * to Share — to copy, distribute and transmit the work
    * to Remix — to adapt the work

Under the following conditions:

    * Attribution — You must attribute the work and give credits to the author or Zeroit.Framework.MiscControls.Navigation.OutlookNavigation.net
    * Noncommercial — You may not use this work for commercial purposes. If you want to adapt
      this work for a commercial purpose, visit Zeroit.Framework.MiscControls.Navigation.OutlookNavigation.net and request the Attribution-Share 
      Alike 3.0 Unported license for free. 

http://creativecommons.org/licenses/by-nc-sa/3.0/

*/
#endregion

using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NativeMethods.
    /// </summary>
    public class NativeMethods
   {
        /// <summary>
        /// The aw hide
        /// </summary>
        public const int AW_HIDE = 0X10000;
        /// <summary>
        /// The aw activate
        /// </summary>
        public const int AW_ACTIVATE = 0X20000;
        /// <summary>
        /// The aw hor positive
        /// </summary>
        public const int AW_HOR_POSITIVE = 0X1;
        /// <summary>
        /// The aw hor negative
        /// </summary>
        public const int AW_HOR_NEGATIVE = 0X2;
        /// <summary>
        /// The aw slide
        /// </summary>
        public const int AW_SLIDE = 0X40000;
        /// <summary>
        /// The aw blend
        /// </summary>
        public const int AW_BLEND = 0X80000;

        /// <summary>
        /// The ma noactivate
        /// </summary>
        public const int MA_NOACTIVATE = 0x0003;

        /// <summary>
        /// The ws ex noactivate
        /// </summary>
        public const int WS_EX_NOACTIVATE = 0x08000000;
        /// <summary>
        /// The ws ex toolwindow
        /// </summary>
        public const int WS_EX_TOOLWINDOW = 0x00000080;

        /// <summary>
        /// The wm activate
        /// </summary>
        public const int WM_ACTIVATE = 0x0006;
        /// <summary>
        /// The wm activateapp
        /// </summary>
        public const int WM_ACTIVATEAPP = 0x001C;
        /// <summary>
        /// The wm getminmaxinfo
        /// </summary>
        public const int WM_GETMINMAXINFO = 0x0024;
        /// <summary>
        /// The wm nchittest
        /// </summary>
        public const int WM_NCHITTEST = 0x0084;
        /// <summary>
        /// The wm ncactivate
        /// </summary>
        public const int WM_NCACTIVATE = 0x0086;

        /// <summary>
        /// The wm mouseactivate
        /// </summary>
        public const int WM_MOUSEACTIVATE = 0x0021;

        /// <summary>
        /// The wm capturechanged
        /// </summary>
        public const int WM_CAPTURECHANGED = 0x215;
        /// <summary>
        /// The wm lbuttondown
        /// </summary>
        public const int WM_LBUTTONDOWN = 0x201;
        /// <summary>
        /// The wm lbuttonup
        /// </summary>
        public const int WM_LBUTTONUP = 0x202;
        /// <summary>
        /// The wm rbuttondown
        /// </summary>
        public const int WM_RBUTTONDOWN = 0x204;
        /// <summary>
        /// The wm mbuttondown
        /// </summary>
        public const int WM_MBUTTONDOWN = 0x207;
        /// <summary>
        /// The wm nclbuttondown
        /// </summary>
        public const int WM_NCLBUTTONDOWN = 0x0A1;
        /// <summary>
        /// The wm ncrbuttondown
        /// </summary>
        public const int WM_NCRBUTTONDOWN = 0x0A4;
        /// <summary>
        /// The wm ncmbuttondown
        /// </summary>
        public const int WM_NCMBUTTONDOWN = 0x0A7;

        /// <summary>
        /// The keyeventf keyup
        /// </summary>
        public const int KEYEVENTF_KEYUP = 0x0002;

        /// <summary>
        /// The httransparent
        /// </summary>
        public const int HTTRANSPARENT = -1;
        /// <summary>
        /// The htleft
        /// </summary>
        public const int HTLEFT = 10;
        /// <summary>
        /// The htright
        /// </summary>
        public const int HTRIGHT = 11;
        /// <summary>
        /// The httop
        /// </summary>
        public const int HTTOP = 12;
        /// <summary>
        /// The httopleft
        /// </summary>
        public const int HTTOPLEFT = 13;
        /// <summary>
        /// The httopright
        /// </summary>
        public const int HTTOPRIGHT = 14;
        /// <summary>
        /// The htbottom
        /// </summary>
        public const int HTBOTTOM = 15;
        /// <summary>
        /// The htbottomleft
        /// </summary>
        public const int HTBOTTOMLEFT = 16;
        /// <summary>
        /// The htbottomright
        /// </summary>
        public const int HTBOTTOMRIGHT = 17;
        /// <summary>
        /// The cs dropshadow
        /// </summary>
        public const int CS_DROPSHADOW = 0x20000;

        /// <summary>
        /// Enum SHOWWINDOW
        /// </summary>
        public enum SHOWWINDOW : uint
      {
            /// <summary>
            /// The sw hide
            /// </summary>
            SW_HIDE = 0,
            /// <summary>
            /// The sw shownormal
            /// </summary>
            SW_SHOWNORMAL = 1,
            /// <summary>
            /// The sw normal
            /// </summary>
            SW_NORMAL = 1,
            /// <summary>
            /// The sw showminimized
            /// </summary>
            SW_SHOWMINIMIZED = 2,
            /// <summary>
            /// The sw showmaximized
            /// </summary>
            SW_SHOWMAXIMIZED = 3,
            /// <summary>
            /// The sw maximize
            /// </summary>
            SW_MAXIMIZE = 3,
            /// <summary>
            /// The sw shownoactivate
            /// </summary>
            SW_SHOWNOACTIVATE = 4,
            /// <summary>
            /// The sw show
            /// </summary>
            SW_SHOW = 5,
            /// <summary>
            /// The sw minimize
            /// </summary>
            SW_MINIMIZE = 6,
            /// <summary>
            /// The sw showminnoactive
            /// </summary>
            SW_SHOWMINNOACTIVE = 7,
            /// <summary>
            /// The sw showna
            /// </summary>
            SW_SHOWNA = 8,
            /// <summary>
            /// The sw restore
            /// </summary>
            SW_RESTORE = 9,
            /// <summary>
            /// The sw showdefault
            /// </summary>
            SW_SHOWDEFAULT = 10,
            /// <summary>
            /// The sw forceminimize
            /// </summary>
            SW_FORCEMINIMIZE = 11,
            /// <summary>
            /// The sw maximum
            /// </summary>
            SW_MAX = 11,
      }


        /// <summary>
        /// Animates the window.
        /// </summary>
        /// <param name="hwand">The hwand.</param>
        /// <param name="dwTime">The dw time.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
      public static extern int AnimateWindow(IntPtr hwand, int dwTime, int dwFlags);

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
      public extern static int SendMessage(IntPtr handle, int msg, int wParam, IntPtr lParam);

        /// <summary>
        /// Posts the message.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
      public extern static int PostMessage(IntPtr handle, int msg, int wParam, IntPtr lParam);

        /// <summary>
        /// Keybds the event.
        /// </summary>
        /// <param name="bVk">The b vk.</param>
        /// <param name="bScan">The b scan.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <param name="dwExtraInfo">The dw extra information.</param>
        [DllImport("user32")]
      public extern static void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        /// <summary>
        /// His the word.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns>System.Int32.</returns>
        public static int HiWord(int n)
      {
         return (n >> 16) & 0xffff;
      }

        /// <summary>
        /// His the word.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns>System.Int32.</returns>
        public static int HiWord(IntPtr n)
      {
         return HiWord(unchecked((int)(long)n));
      }

        /// <summary>
        /// Loes the word.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns>System.Int32.</returns>
        public static int LoWord(int n)
      {
         return n & 0xffff;
      }

        /// <summary>
        /// Loes the word.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns>System.Int32.</returns>
        public static int LoWord(IntPtr n)
      {
         return LoWord(unchecked((int)(long)n));
      }

        /// <summary>
        /// Struct MINMAXINFO
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
      public struct MINMAXINFO
      {
            /// <summary>
            /// The reserved
            /// </summary>
            public Point reserved;
            /// <summary>
            /// The maximum size
            /// </summary>
            public Size maxSize;
            /// <summary>
            /// The maximum position
            /// </summary>
            public Point maxPosition;
            /// <summary>
            /// The minimum track size
            /// </summary>
            public Size minTrackSize;
            /// <summary>
            /// The maximum track size
            /// </summary>
            public Size maxTrackSize;
      }
   }
}
