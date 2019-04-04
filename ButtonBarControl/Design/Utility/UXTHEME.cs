// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="UXTHEME.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.InteropServices;
using System.Text;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class UXTHEME.
    /// </summary>
    internal static class UXTHEME
    {
        /// <summary>
        /// Gets the name of the current theme.
        /// </summary>
        /// <param name="pszThemeFileName">Name of the PSZ theme file.</param>
        /// <param name="dwMaxNameChars">The dw maximum name chars.</param>
        /// <param name="pszColorBuff">The PSZ color buff.</param>
        /// <param name="cchMaxColorChars">The CCH maximum color chars.</param>
        /// <param name="pszSizeBuff">The PSZ size buff.</param>
        /// <param name="cchMaxSizeChars">The CCH maximum size chars.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("UxTheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        internal static extern int GetCurrentThemeName(StringBuilder pszThemeFileName, int dwMaxNameChars,
                                                       StringBuilder pszColorBuff, int cchMaxColorChars,
                                                       StringBuilder pszSizeBuff, int cchMaxSizeChars);

        /// <summary>
        /// Determines whether [is theme active].
        /// </summary>
        /// <returns><c>true</c> if [is theme active]; otherwise, <c>false</c>.</returns>
        [DllImport("UxTheme.dll", CharSet = CharSet.Auto)]
        internal static extern bool IsThemeActive();
    }
}