// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ColorTableBlack.cs" company="Zeroit Dev Technologies">
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
    #region ColorTableBlack
    /// <summary>
    /// Provide Office 2007 black theme colors
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.BseColorTable" />
    public class ColorTableBlack : BseColorTable
    {
        #region FieldsPrivate
        /// <summary>
        /// The m panel color table
        /// </summary>
        private PanelColors m_panelColorTable;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the associated ColorTable for the XPanderControls
        /// </summary>
        /// <value>The panel color table.</value>
        public override PanelColors PanelColorTable
        {
            get
            {
                if (this.m_panelColorTable == null)
                {
                    this.m_panelColorTable = new PanelColorsBlack();
                }
                return this.m_panelColorTable;
            }
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Initializes a color dictionary with defined colors
        /// </summary>
        /// <param name="rgbTable">Dictionary with defined colors</param>
        protected override void InitColors(Dictionary<ProfessionalColorTable.KnownColors, Color> rgbTable)
        {
            base.InitColors(rgbTable);
            rgbTable[KnownColors.ButtonPressedBorder] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.ButtonPressedGradientBegin] = Color.FromArgb(141, 170, 253);
            rgbTable[KnownColors.ButtonPressedGradientEnd] = Color.FromArgb(98, 101, 252);
            rgbTable[KnownColors.ButtonPressedGradientMiddle] = Color.FromArgb(43, 93, 255);
            rgbTable[KnownColors.ButtonSelectedGradientBegin] = Color.FromArgb(106, 109, 228);
            rgbTable[KnownColors.ButtonSelectedGradientEnd] = Color.FromArgb(88, 111, 226);
            rgbTable[KnownColors.ButtonSelectedGradientMiddle] = Color.FromArgb(39, 39, 217);
            rgbTable[KnownColors.ButtonSelectedHighlightBorder] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.GripDark] = Color.FromArgb(102, 102, 102);
            rgbTable[KnownColors.GripLight] = Color.FromArgb(182, 182, 182);
            rgbTable[KnownColors.ImageMarginGradientBegin] = Color.FromArgb(239, 239, 239);
            rgbTable[KnownColors.MenuBorder] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.MenuItemSelectedGradientBegin] = Color.FromArgb(231, 239, 243);
            rgbTable[KnownColors.MenuItemSelectedGradientEnd] = Color.FromArgb(218, 235, 243);
            rgbTable[KnownColors.MenuItemText] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.MenuItemTopLevelSelectedBorder] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.MenuItemTopLevelSelectedGradientBegin] = Color.FromArgb(205, 208, 213);
            rgbTable[KnownColors.MenuStripGradientBegin] = Color.FromArgb(102, 102, 102);
            rgbTable[KnownColors.MenuStripGradientEnd] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.OverflowButtonGradientBegin] = Color.FromArgb(136, 144, 254);
            rgbTable[KnownColors.OverflowButtonGradientEnd] = Color.FromArgb(111, 145, 255);
            rgbTable[KnownColors.OverflowButtonGradientMiddle] = Color.FromArgb(42, 52, 254);
            rgbTable[KnownColors.RaftingContainerGradientBegin] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.RaftingContainerGradientEnd] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.SeparatorDark] = Color.FromArgb(102, 102, 102);
            rgbTable[KnownColors.SeparatorLight] = Color.FromArgb(182, 182, 182);
            rgbTable[KnownColors.StatusStripGradientBegin] = Color.FromArgb(100, 100, 100);
            rgbTable[KnownColors.StatusStripGradientEnd] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.StatusStripText] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.ToolStripBorder] = Color.FromArgb(102, 102, 102);
            rgbTable[KnownColors.ToolStripContentPanelGradientBegin] = Color.FromArgb(42, 42, 42);
            rgbTable[KnownColors.ToolStripContentPanelGradientEnd] = Color.FromArgb(10, 10, 10);
            rgbTable[KnownColors.ToolStripDropDownBackground] = Color.FromArgb(250, 250, 250);
            rgbTable[KnownColors.ToolStripGradientBegin] = Color.FromArgb(102, 102, 102);
            rgbTable[KnownColors.ToolStripGradientEnd] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.ToolStripGradientMiddle] = Color.FromArgb(52, 52, 52);
            rgbTable[KnownColors.ToolStripPanelGradientBegin] = Color.FromArgb(12, 12, 12);
            rgbTable[KnownColors.ToolStripPanelGradientEnd] = Color.FromArgb(2, 2, 2);
            rgbTable[KnownColors.ToolStripText] = Color.FromArgb(255, 255, 255);
        }

        #endregion
    }
    #endregion
}
