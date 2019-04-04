// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="UXTHEME.cs" company="Zeroit Dev Technologies">
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