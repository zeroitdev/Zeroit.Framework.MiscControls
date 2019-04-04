// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Office2007BlackColorTable.cs" company="Zeroit Dev Technologies">
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
    #region Office2007BlackColorTable
    /// <summary>
    /// Provides colors used for Microsoft Office 2007 black display elements.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.OfficeColorTable" />
    public class Office2007BlackColorTable : OfficeColorTable
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
                    this.m_panelColorTable = new PanelColorsOffice2007Black();
                }
                return this.m_panelColorTable;
            }
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Initializes a color dictionary with defined colors.
        /// </summary>
        /// <param name="rgbTable">Dictionary with defined colors</param>
        protected override void InitColors(Dictionary<ProfessionalColorTable.KnownColors, Color> rgbTable)
        {
            rgbTable[KnownColors.ButtonPressedBorder] = Color.FromArgb(255, 189, 105);
            rgbTable[KnownColors.ButtonPressedGradientBegin] = Color.FromArgb(248, 181, 106);
            rgbTable[KnownColors.ButtonPressedGradientEnd] = Color.FromArgb(255, 208, 134);
            rgbTable[KnownColors.ButtonPressedGradientMiddle] = Color.FromArgb(251, 140, 60);
            rgbTable[KnownColors.ButtonSelectedBorder] = Color.FromArgb(255, 189, 105);
            rgbTable[KnownColors.ButtonSelectedGradientBegin] = Color.FromArgb(255, 245, 204);
            rgbTable[KnownColors.ButtonSelectedGradientEnd] = Color.FromArgb(255, 219, 117);
            rgbTable[KnownColors.ButtonSelectedGradientMiddle] = Color.FromArgb(255, 231, 162);
            rgbTable[KnownColors.ButtonSelectedHighlightBorder] = Color.FromArgb(255, 189, 105);
            rgbTable[KnownColors.CheckBackground] = Color.FromArgb(255, 227, 149);
            rgbTable[KnownColors.CheckSelectedBackground] = Color.FromArgb(254, 128, 62);
            rgbTable[KnownColors.GripDark] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.GripLight] = Color.FromArgb(221, 224, 227);
            rgbTable[KnownColors.ImageMarginGradientBegin] = Color.FromArgb(239, 239, 239);
            rgbTable[KnownColors.MenuBorder] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.MenuItemBorder] = Color.FromArgb(255, 189, 105);
            rgbTable[KnownColors.MenuItemPressedGradientBegin] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.MenuItemPressedGradientEnd] = Color.FromArgb(108, 117, 128);
            rgbTable[KnownColors.MenuItemPressedGradientMiddle] = Color.FromArgb(126, 135, 146);
            rgbTable[KnownColors.MenuItemSelected] = Color.FromArgb(255, 238, 194);
            rgbTable[KnownColors.MenuItemSelectedGradientBegin] = Color.FromArgb(255, 245, 204);
            rgbTable[KnownColors.MenuItemSelectedGradientEnd] = Color.FromArgb(255, 223, 132);
            rgbTable[KnownColors.MenuItemText] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.MenuStripGradientBegin] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.MenuStripGradientEnd] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.OverflowButtonGradientBegin] = Color.FromArgb(178, 183, 191);
            rgbTable[KnownColors.OverflowButtonGradientEnd] = Color.FromArgb(81, 88, 98);
            rgbTable[KnownColors.OverflowButtonGradientMiddle] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.RaftingContainerGradientBegin] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.RaftingContainerGradientEnd] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.SeparatorDark] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.SeparatorLight] = Color.FromArgb(221, 224, 227);
            rgbTable[KnownColors.StatusStripGradientBegin] = Color.FromArgb(76, 83, 92);
            rgbTable[KnownColors.StatusStripGradientEnd] = Color.FromArgb(35, 38, 42);
            rgbTable[KnownColors.StatusStripText] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.ToolStripBorder] = Color.FromArgb(76, 83, 92);
            rgbTable[KnownColors.ToolStripContentPanelGradientBegin] = Color.FromArgb(82, 82, 82);
            rgbTable[KnownColors.ToolStripContentPanelGradientEnd] = Color.FromArgb(10, 10, 10);
            rgbTable[KnownColors.ToolStripDropDownBackground] = Color.FromArgb(250, 250, 250);
            rgbTable[KnownColors.ToolStripGradientBegin] = Color.FromArgb(205, 208, 213);
            rgbTable[KnownColors.ToolStripGradientEnd] = Color.FromArgb(148, 156, 166);
            rgbTable[KnownColors.ToolStripGradientMiddle] = Color.FromArgb(188, 193, 200);
            rgbTable[KnownColors.ToolStripPanelGradientBegin] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.ToolStripPanelGradientEnd] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.ToolStripText] = Color.FromArgb(0, 0, 0);
        }

        #endregion
    }
    #endregion
}
