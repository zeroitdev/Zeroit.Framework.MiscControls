// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Utilities.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Utilities

    #region GetExecutableIcon
    // *************************************** class GetExecutableIcon

    /// <summary>
    /// Class GetExecutableIcon.
    /// </summary>
    public class GetExecutableIcon
    {

        // WIN32 ENTRY POINTS ****************************************

        // ********************************************* ExtractIconEx

        // http://www.pinvoke.net/default.aspx/shell32/ExtractIconEx.html"/>

        /// <summary>
        /// returns one or more icons
        /// </summary>
        /// <param name="szFileName">null-terminated string specifying the name of an
        /// executable file, DLL, or icon file from which icons will
        /// be extracted</param>
        /// <param name="nIconIndex">the zero-based index of the first icon to extract. For
        /// example, if this value is zero, the function extracts the
        /// first icon in the specified file
        /// if this value is a negative number and either phiconLarge
        /// or phiconSmall is not NULL, the function begins by
        /// extracting the icon whose resource identifier is equal to
        /// the absolute value of nIconIndex. For example, use -3 to
        /// extract the icon whose resource identifier is 3.</param>
        /// <param name="phiconLarge">pointer to an array of icon handles that receives handles
        /// to the large icons extracted from the file; if NULL, no
        /// large icons are extracted from the file</param>
        /// <param name="phiconSmall">pointer to an array of icon handles that receives handles
        /// to the small icons extracted from the file; if NULL, no
        /// small icons are extracted from the file</param>
        /// <param name="nIcons">specifies the number of icons to extract from the file</param>
        /// <returns>the number of icons found</returns>
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern uint ExtractIconEx(string szFileName,
                                           int nIconIndex,
                                           IntPtr[] phiconLarge,
                                           IntPtr[] phiconSmall,
                                           uint nIcons);

        // *********************************************** DestroyIcon

        /// <summary>
        /// destroys an icon and frees any memory the icon occupied
        /// </summary>
        /// <param name="hIcon">handle to the icon to be destroyed; the icon must not be
        /// in use</param>
        /// <returns>if succeesful, the return value is nonzero; otherwise, the
        /// return value is zero</returns>
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool DestroyIcon(IntPtr hIcon);

        // C# ENTRY POINTS ******************************************* 

        // *************************************** get_executable_icon

        /// <summary>
        /// attempts to extract and return the first icon in the
        /// application's executable file; large icons are returned
        /// before small icons
        /// </summary>
        /// <returns>first icon found in the application's executable file; if
        /// no icons are found in the application's executable file,
        /// the SystemIcons.Exclamation icon as a 32x32 bit icon</returns>
        /// <remarks>the local icons are destroyed by DestroyIcon; the icon
        /// returned to the invoker must be destroyed by a call to
        /// Icon.Dispose ( )</remarks>
        public static Icon get_executable_icon()
        {
            uint count = 0;
            Icon icon = null;
            IntPtr[] large = new IntPtr[] { IntPtr.Zero };
            IntPtr[] small = new IntPtr[] { IntPtr.Zero };

            icon = new Icon(SystemIcons.Exclamation, 32, 32);
            try
            {
                count = ExtractIconEx(Application.ExecutablePath,
                                        0,
                                        large,
                                        small,
                                        1);
                if (count > 0)
                {
                    if (large[0] != IntPtr.Zero)
                    {
                        icon = (Icon)Icon.FromHandle(
                                             large[0]).Clone();
                    }
                    else if (small[0] != IntPtr.Zero)
                    {
                        icon = (Icon)Icon.FromHandle(
                                             small[0]).Clone();
                    }
                    else
                    {
                        // already set default icon
                    }
                }
                else
                {
                    // already set default icon
                }
            }
            catch (Exception ex)
            {
                icon = new Icon(SystemIcons.Exclamation, 32, 32);
            }
            finally
            {
                // release resources
                foreach (IntPtr ptr in large)
                {
                    if (ptr != IntPtr.Zero)
                    {
                        DestroyIcon(ptr);
                    }
                }

                foreach (IntPtr ptr in small)
                {
                    if (ptr != IntPtr.Zero)
                    {
                        DestroyIcon(ptr);
                    }
                }
            }

            return (icon);
        }

    } // class GetExecutableIcon


    #endregion

    #region FrameRegion

    // ********************************************* class FrameRegion

    /// <summary>
    /// Class FrameRegion.
    /// </summary>
    public class FrameRegion
    {

        // **************************************** WIN32 ENTRY POINTS

        // ************************************************** FrameRgn

        /// <summary>
        /// Frames the RGN.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="hrgn">The HRGN.</param>
        /// <param name="hbr">The HBR.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32")]
        static extern bool FrameRgn(IntPtr hdc,
                                      IntPtr hrgn,
                                      IntPtr hbr,
                                      int nWidth,
                                      int nHeight);

        // ******************************************** GetStockObject

        /// <summary>
        /// Gets the stock object.
        /// </summary>
        /// <param name="stock_object">The stock object.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("gdi32")]
        static extern IntPtr GetStockObject(
                                        StockObjects stock_object);

        // ******************************** WIN32 ENUMS AND STRUCTURES

        // ********************************************** StockObjects

        /// <summary>
        /// Enum representing
        /// </summary>
        public enum StockObjects : int
        {
            /// <summary>
            /// The white brush
            /// </summary>
            WHITE_BRUSH = 0,
            /// <summary>
            /// The ltgray brush
            /// </summary>
            LTGRAY_BRUSH = 1,
            /// <summary>
            /// The gray brush
            /// </summary>
            GRAY_BRUSH = 2,
            /// <summary>
            /// The dkgray brush
            /// </summary>
            DKGRAY_BRUSH = 3,
            /// <summary>
            /// The black brush
            /// </summary>
            BLACK_BRUSH = 4,
            /// <summary>
            /// The null brush
            /// </summary>
            NULL_BRUSH = 5,
            /// <summary>
            /// The hollow brush
            /// </summary>
            HOLLOW_BRUSH = NULL_BRUSH,
            /// <summary>
            /// The white pen
            /// </summary>
            WHITE_PEN = 6,
            /// <summary>
            /// The black pen
            /// </summary>
            BLACK_PEN = 7,
            /// <summary>
            /// The null pen
            /// </summary>
            NULL_PEN = 8,
            /// <summary>
            /// The oem fixed font
            /// </summary>
            OEM_FIXED_FONT = 10,
            /// <summary>
            /// The ANSI fixed font
            /// </summary>
            ANSI_FIXED_FONT = 11,
            /// <summary>
            /// The ANSI variable font
            /// </summary>
            ANSI_VAR_FONT = 12,
            /// <summary>
            /// The system font
            /// </summary>
            SYSTEM_FONT = 13,
            /// <summary>
            /// The device default font
            /// </summary>
            DEVICE_DEFAULT_FONT = 14,
            /// <summary>
            /// The default palette
            /// </summary>
            DEFAULT_PALETTE = 15,
            /// <summary>
            /// The system fixed font
            /// </summary>
            SYSTEM_FIXED_FONT = 16,
            /// <summary>
            /// The default GUI font
            /// </summary>
            DEFAULT_GUI_FONT = 17,
            /// <summary>
            /// The dc brush
            /// </summary>
            DC_BRUSH = 18,
            /// <summary>
            /// The dc pen
            /// </summary>
            DC_PEN = 19,
        }

        // ******************************************* C# ENTRY POINTS

        // ********************************************** frame_region

        /// <summary>
        /// draws a black border around the specified region
        /// </summary>
        /// <param name="graphics">the Graphics object on which to draw the frame</param>
        /// <param name="region">region around which to draw the frame</param>
        public static void frame_region(Graphics graphics,
                                          Region region)
        {
            var hregn = region.GetHrgn(graphics);
            var hdc = graphics.GetHdc();

            FrameRgn(hdc,
                       hregn,
                       GetStockObject(StockObjects.BLACK_PEN),
                       1,
                       1);
            graphics.ReleaseHdc(hdc);
        }

    } // class FrameRegion

    #endregion

    #endregion
}
