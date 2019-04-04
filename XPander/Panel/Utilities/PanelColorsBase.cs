// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PanelColorsBase.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    #region PanelColorsBse
    /// <summary>
    /// Baseclass for a bse styled colortable.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.PanelColors" />
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER
    /// REMAINS UNCHANGED.
    /// </copyright>
	public class PanelColorsBse : PanelColors
    {
        #region Properties
        /// <summary>
        /// Gets the associated PanelStyle for the XPanderControls
        /// </summary>
        /// <value>The panel style.</value>
        public override PanelStyle PanelStyle
        {
            get { return PanelStyle.Office2007; }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initialize a new instance of the PanelColorsBse class.
        /// </summary>
        public PanelColorsBse()
            : base()
        {
        }
        /// <summary>
        /// Initialize a new instance of the PanelColorsBse class.
        /// </summary>
        /// <param name="basePanel">Base class for the panel or xpanderpanel control.</param>
        public PanelColorsBse(BasePanel basePanel)
            : base(basePanel)
        {
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Initialize a color Dictionary with defined Bse colors
        /// </summary>
        /// <param name="rgbTable">Dictionary with defined colors</param>
        protected override void InitColors(Dictionary<KnownColors, System.Drawing.Color> rgbTable)
        {
            base.InitColors(rgbTable);
            rgbTable[KnownColors.PanelCaptionSelectedGradientBegin] = Color.FromArgb(156, 163, 254);
            rgbTable[KnownColors.PanelCaptionSelectedGradientEnd] = Color.FromArgb(90, 98, 254);
            rgbTable[KnownColors.XPanderPanelCheckedCaptionBegin] = Color.FromArgb(136, 144, 254);
            rgbTable[KnownColors.XPanderPanelCheckedCaptionEnd] = Color.FromArgb(111, 145, 255);
            rgbTable[KnownColors.XPanderPanelCheckedCaptionMiddle] = Color.FromArgb(42, 52, 254);
            rgbTable[KnownColors.XPanderPanelPressedCaptionBegin] = Color.FromArgb(106, 109, 228);
            rgbTable[KnownColors.XPanderPanelPressedCaptionEnd] = Color.FromArgb(88, 111, 226);
            rgbTable[KnownColors.XPanderPanelPressedCaptionMiddle] = Color.FromArgb(39, 39, 217);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionBegin] = Color.FromArgb(156, 163, 254);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionEnd] = Color.FromArgb(139, 164, 255);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionMiddle] = Color.FromArgb(90, 98, 254);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionText] = Color.White;
        }
        #endregion
    }
    #endregion
}
