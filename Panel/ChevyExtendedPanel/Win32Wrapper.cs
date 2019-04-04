// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Win32Wrapper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.MiscControls
{
    #region Win32Wrapper


    /// <summary>
    /// Class Win32Wrapper.
    /// </summary>
    class Win32Wrapper
    {
        /// <summary>
        /// Flags used in SetWindowsPos
        /// </summary>
        public enum FlagsSetWindowPos { SWP_NOSIZE = 0x0001, SWP_NOMOVE = 0x0002, SWP_NOZORDER = 0x0004, SWP_NOREDRAW = 0x0008, SWP_NOACTIVATE = 0x0010, SWP_FRAMECHANGED = 0x0020, SWP_SHOWWINDOW = 0x0040, SWP_HIDEWINDOW = 0x0080, SWP_NOCOPYBITS = 0x0100, SWP_NOOWNERZORDER = 0x0200, SWP_NOSENDCHANGING = 0x0400 };

        /// <summary>
        /// Msdn:"The SetWindowPos function changes the size, position, and Z order of a child, pop-up, or top-level window. Child, pop-up, and top-level windows are ordered according to their appearance on the screen. The topmost window receives the highest rank and is the first window in the Z order."
        /// </summary>
        /// <param name="hWnd">window handle</param>
        /// <param name="hWndInsertAfter">handle to the window it should insert Z order</param>
        /// <param name="X">position on X axis of the top left corner</param>
        /// <param name="Y">position on the Y axis of the top left corner</param>
        /// <param name="cx">window width</param>
        /// <param name="cy">window height</param>
        /// <param name="uFlags">flags</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, FlagsSetWindowPos uFlags);
    }

    #endregion
}
