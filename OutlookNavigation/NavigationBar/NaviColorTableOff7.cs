// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviColorTableOff7.cs" company="Zeroit Dev Technologies">
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

using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviColorTableOff7.
    /// </summary>
    public class NaviColorTableOff7
   {
        // General colors 
        /// <summary>
        /// Gets the dark border.
        /// </summary>
        /// <value>The dark border.</value>
        public virtual Color DarkBorder { get { return Color.FromArgb(101, 147, 207); } }
        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public virtual Color Text { get { return Color.FromArgb(21, 66, 139); } }
        /// <summary>
        /// Gets the background.
        /// </summary>
        /// <value>The background.</value>
        public virtual Color Background { get { return Color.FromArgb(255, 255, 255); } }
        /// <summary>
        /// Gets the shapes front.
        /// </summary>
        /// <value>The shapes front.</value>
        public virtual Color ShapesFront { get { return Color.FromArgb(86, 125, 177); } }

        // NaviButton Normal
        /// <summary>
        /// Gets the button light.
        /// </summary>
        /// <value>The button light.</value>
        public virtual Color ButtonLight { get { return Color.FromArgb(192, 219, 255); } }
        /// <summary>
        /// Gets the button dark.
        /// </summary>
        /// <value>The button dark.</value>
        public virtual Color ButtonDark { get { return Color.FromArgb(173, 209, 255); } }
        /// <summary>
        /// Gets the button highlight dark.
        /// </summary>
        /// <value>The button highlight dark.</value>
        public virtual Color ButtonHighlightDark { get { return Color.FromArgb(196, 221, 255); } }
        /// <summary>
        /// Gets the button highlight light.
        /// </summary>
        /// <value>The button highlight light.</value>
        public virtual Color ButtonHighlightLight { get { return Color.FromArgb(227, 239, 255); } }

        // NaviButton hovered
        /// <summary>
        /// Gets the button hovered light.
        /// </summary>
        /// <value>The button hovered light.</value>
        public virtual Color ButtonHoveredLight { get { return Color.FromArgb(255, 230, 159); } }
        /// <summary>
        /// Gets the button hovered dark.
        /// </summary>
        /// <value>The button hovered dark.</value>
        public virtual Color ButtonHoveredDark { get { return Color.FromArgb(255, 215, 103); } }
        /// <summary>
        /// Gets the button hovered highlight dark.
        /// </summary>
        /// <value>The button hovered highlight dark.</value>
        public virtual Color ButtonHoveredHighlightDark { get { return Color.FromArgb(255, 233, 168); } }
        /// <summary>
        /// Gets the button hovered highlight light.
        /// </summary>
        /// <value>The button hovered highlight light.</value>
        public virtual Color ButtonHoveredHighlightLight { get { return Color.FromArgb(255, 254, 228); } }

        // NaviButton active
        /// <summary>
        /// Gets the button active light.
        /// </summary>
        /// <value>The button active light.</value>
        public virtual Color ButtonActiveLight { get { return Color.FromArgb(254, 225, 122); } }
        /// <summary>
        /// Gets the button active dark.
        /// </summary>
        /// <value>The button active dark.</value>
        public virtual Color ButtonActiveDark { get { return Color.FromArgb(255, 171, 63); } }
        /// <summary>
        /// Gets the button active highlight dark.
        /// </summary>
        /// <value>The button active highlight dark.</value>
        public virtual Color ButtonActiveHighlightDark { get { return Color.FromArgb(255, 188, 111); } }
        /// <summary>
        /// Gets the button active highlight light.
        /// </summary>
        /// <value>The button active highlight light.</value>
        public virtual Color ButtonActiveHighlightLight { get { return Color.FromArgb(255, 217, 170); } }

        // NaviButton clicked
        /// <summary>
        /// Gets the button clicked light.
        /// </summary>
        /// <value>The button clicked light.</value>
        public virtual Color ButtonClickedLight { get { return Color.FromArgb(255, 211, 101); } }
        /// <summary>
        /// Gets the button clicked dark.
        /// </summary>
        /// <value>The button clicked dark.</value>
        public virtual Color ButtonClickedDark { get { return Color.FromArgb(251, 140, 60); } }
        /// <summary>
        /// Gets the button clicked highlight dark.
        /// </summary>
        /// <value>The button clicked highlight dark.</value>
        public virtual Color ButtonClickedHighlightDark { get { return Color.FromArgb(255, 173, 67); } }
        /// <summary>
        /// Gets the button clicked highlight light.
        /// </summary>
        /// <value>The button clicked highlight light.</value>
        public virtual Color ButtonClickedHighlightLight { get { return Color.FromArgb(255, 189, 105); } }

        // Popuped band backcolor
        /// <summary>
        /// Gets the popup band background.
        /// </summary>
        /// <value>The popup band background.</value>
        public virtual Color PopupBandBackground { get { return Color.FromArgb(227, 239, 255); } }

        // Splitter
        /// <summary>
        /// Gets the splitter dark.
        /// </summary>
        /// <value>The splitter dark.</value>
        public virtual Color SplitterDark { get { return Color.FromArgb(182, 214, 255); } }
        /// <summary>
        /// Gets the splitter light.
        /// </summary>
        /// <value>The splitter light.</value>
        public virtual Color SplitterLight { get { return Color.FromArgb(255, 255, 255); } }
        /// <summary>
        /// Gets the splitter highlights.
        /// </summary>
        /// <value>The splitter highlights.</value>
        public virtual Color SplitterHighlights { get { return Color.FromArgb(255, 255, 255); } }

        // Options button
        /// <summary>
        /// Gets the button options outer.
        /// </summary>
        /// <value>The button options outer.</value>
        public virtual Color ButtonOptionsOuter { get { return Color.FromArgb(67, 113, 176); } }
        /// <summary>
        /// Gets the button options inner.
        /// </summary>
        /// <value>The button options inner.</value>
        public virtual Color ButtonOptionsInner { get { return Color.FromArgb(255, 248, 203); } }

        // Header of band
        /// <summary>
        /// Gets the header bg dark.
        /// </summary>
        /// <value>The header bg dark.</value>
        public virtual Color HeaderBgDark { get { return Color.FromArgb(175, 210, 255); } }
        /// <summary>
        /// Gets the header bg light.
        /// </summary>
        /// <value>The header bg light.</value>
        public virtual Color HeaderBgLight { get { return Color.FromArgb(227, 239, 255); } }
        /// <summary>
        /// Gets the header bg inner border.
        /// </summary>
        /// <value>The header bg inner border.</value>
        public virtual Color HeaderBgInnerBorder { get { return Color.FromArgb(255, 255, 255); } }

        // Group
        /// <summary>
        /// Gets the group bg light.
        /// </summary>
        /// <value>The group bg light.</value>
        public virtual Color GroupBgLight { get { return Color.FromArgb(226, 238, 255); } }
        /// <summary>
        /// Gets the group bg dark.
        /// </summary>
        /// <value>The group bg dark.</value>
        public virtual Color GroupBgDark { get { return Color.FromArgb(214, 232, 255); } }
        /// <summary>
        /// Gets the group bg hovered light.
        /// </summary>
        /// <value>The group bg hovered light.</value>
        public virtual Color GroupBgHoveredLight { get { return Color.FromArgb(255, 255, 255); } }
        /// <summary>
        /// Gets the group bg hovered dark.
        /// </summary>
        /// <value>The group bg hovered dark.</value>
        public virtual Color GroupBgHoveredDark { get { return Color.FromArgb(227, 239, 255); } }
        /// <summary>
        /// Gets the group border light.
        /// </summary>
        /// <value>The group border light.</value>
        public virtual Color GroupBorderLight { get { return Color.FromArgb(173, 209, 255); } }
        /// <summary>
        /// Gets the group inner border.
        /// </summary>
        /// <value>The group inner border.</value>
        public virtual Color GroupInnerBorder { get { return Color.FromArgb(255, 255, 255); } }

        // Collapse button       
        /// <summary>
        /// Gets the collapse button hovered dark.
        /// </summary>
        /// <value>The collapse button hovered dark.</value>
        public virtual Color CollapseButtonHoveredDark { get { return Color.FromArgb(248, 194, 94); } }
        /// <summary>
        /// Gets the collapse button hovered light.
        /// </summary>
        /// <value>The collapse button hovered light.</value>
        public virtual Color CollapseButtonHoveredLight { get { return Color.FromArgb(255, 255, 220); } }
        /// <summary>
        /// Gets the collapse button down dark.
        /// </summary>
        /// <value>The collapse button down dark.</value>
        public virtual Color CollapseButtonDownDark { get { return Color.FromArgb(232, 127, 8); } }
        /// <summary>
        /// Gets the collapse button down light.
        /// </summary>
        /// <value>The collapse button down light.</value>
        public virtual Color CollapseButtonDownLight { get { return Color.FromArgb(247, 217, 121); } }

        // Collapsed band
        /// <summary>
        /// Gets the band collapsed bg.
        /// </summary>
        /// <value>The band collapsed bg.</value>
        public virtual Color BandCollapsedBg { get { return Color.FromArgb(213, 228, 242); } }
        /// <summary>
        /// Gets the band collapsed focused.
        /// </summary>
        /// <value>The band collapsed focused.</value>
        public virtual Color BandCollapsedFocused { get { return Color.FromArgb(255, 231, 162); } }
        /// <summary>
        /// Gets the band collapsed clicked.
        /// </summary>
        /// <value>The band collapsed clicked.</value>
        public virtual Color BandCollapsedClicked { get { return Color.FromArgb(251, 140, 60); } }

        // Groupview
        /// <summary>
        /// Gets the color of the dashed line.
        /// </summary>
        /// <value>The color of the dashed line.</value>
        public virtual Color DashedLineColor { get { return Color.FromArgb(194, 194, 194); } }
   }
}
