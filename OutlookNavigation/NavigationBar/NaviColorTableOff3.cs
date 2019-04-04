// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviColorTableOff3.cs" company="Zeroit Dev Technologies">
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
    /// Class NaviColorTableOff3.
    /// </summary>
    public class NaviColorTableOff3
   {
        // General colors 
        /// <summary>
        /// Gets the dark border.
        /// </summary>
        /// <value>The dark border.</value>
        public virtual Color DarkBorder { get { return Color.FromArgb(0, 45, 150); } }
        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public virtual Color Text { get { return Color.FromArgb(0, 0, 0); } }
        /// <summary>
        /// Gets the dark outlines.
        /// </summary>
        /// <value>The dark outlines.</value>
        public virtual Color DarkOutlines { get { return Color.FromArgb(0, 58, 162); } }
        /// <summary>
        /// Gets the background.
        /// </summary>
        /// <value>The background.</value>
        public virtual Color Background { get { return Color.FromArgb(255, 255, 255); } }
        /// <summary>
        /// Gets the shapes front.
        /// </summary>
        /// <value>The shapes front.</value>
        public virtual Color ShapesFront { get { return Color.FromArgb(0, 45, 150); } }

        // NaviButton Normal
        /// <summary>
        /// Gets the button light.
        /// </summary>
        /// <value>The button light.</value>
        public virtual Color ButtonLight { get { return Color.FromArgb(210, 229, 252); } }
        /// <summary>
        /// Gets the button dark.
        /// </summary>
        /// <value>The button dark.</value>
        public virtual Color ButtonDark { get { return Color.FromArgb(139, 176, 228); } }

        // NaviButton hovered
        /// <summary>
        /// Gets the button hovered light.
        /// </summary>
        /// <value>The button hovered light.</value>
        public virtual Color ButtonHoveredLight { get { return Color.FromArgb(255, 255, 220); } }
        /// <summary>
        /// Gets the button hovered dark.
        /// </summary>
        /// <value>The button hovered dark.</value>
        public virtual Color ButtonHoveredDark { get { return Color.FromArgb(255, 215, 103); } }

        // NaviButton active
        /// <summary>
        /// Gets the button active light.
        /// </summary>
        /// <value>The button active light.</value>
        public virtual Color ButtonActiveLight { get { return Color.FromArgb(252, 233, 160); } }
        /// <summary>
        /// Gets the button active dark.
        /// </summary>
        /// <value>The button active dark.</value>
        public virtual Color ButtonActiveDark { get { return Color.FromArgb(240, 161, 30); } }

        // Splitter
        /// <summary>
        /// Gets the splitter dark.
        /// </summary>
        /// <value>The splitter dark.</value>
        public virtual Color SplitterDark { get { return Color.FromArgb(14, 66, 156); } }
        /// <summary>
        /// Gets the splitter light.
        /// </summary>
        /// <value>The splitter light.</value>
        public virtual Color SplitterLight { get { return Color.FromArgb(89, 135, 214); } }
        /// <summary>
        /// Gets the splitter highlights.
        /// </summary>
        /// <value>The splitter highlights.</value>
        public virtual Color SplitterHighlights { get { return Color.FromArgb(255, 255, 255); } }

        // Header of band
        /// <summary>
        /// Gets the header bg dark.
        /// </summary>
        /// <value>The header bg dark.</value>
        public virtual Color HeaderBgDark { get { return Color.FromArgb(7, 59, 150); } }
        /// <summary>
        /// Gets the header bg light.
        /// </summary>
        /// <value>The header bg light.</value>
        public virtual Color HeaderBgLight { get { return Color.FromArgb(89, 135, 214); } }
        /// <summary>
        /// Gets the header text.
        /// </summary>
        /// <value>The header text.</value>
        public virtual Color HeaderText { get { return Color.FromArgb(255, 255, 255); } }

        // Group
        /// <summary>
        /// Gets the group bg light.
        /// </summary>
        /// <value>The group bg light.</value>
        public virtual Color GroupBgLight { get { return Color.FromArgb(196, 218, 250); } }
        /// <summary>
        /// Gets the group bg dark.
        /// </summary>
        /// <value>The group bg dark.</value>
        public virtual Color GroupBgDark { get { return Color.FromArgb(160, 191, 245); } }
        /// <summary>
        /// Gets the group bg hovered light.
        /// </summary>
        /// <value>The group bg hovered light.</value>
        public virtual Color GroupBgHoveredLight { get { return Color.FromArgb(196, 218, 250); } }
        /// <summary>
        /// Gets the group bg hovered dark.
        /// </summary>
        /// <value>The group bg hovered dark.</value>
        public virtual Color GroupBgHoveredDark { get { return Color.FromArgb(160, 191, 245); } }
        /// <summary>
        /// Gets the group border light.
        /// </summary>
        /// <value>The group border light.</value>
        public virtual Color GroupBorderLight { get { return Color.FromArgb(158, 190, 245); } }

        // NaviButtonOptions Triangle color options button
        /// <summary>
        /// Gets the button options outer.
        /// </summary>
        /// <value>The button options outer.</value>
        public Color ButtonOptionsOuter { get { return Color.FromArgb(67, 113, 176); } }
        /// <summary>
        /// Gets the button options inner.
        /// </summary>
        /// <value>The button options inner.</value>
        public Color ButtonOptionsInner { get { return Color.FromArgb(255, 248, 203); } }

        // Groupview
        /// <summary>
        /// Gets the color of the dashed line.
        /// </summary>
        /// <value>The color of the dashed line.</value>
        public virtual Color DashedLineColor { get { return Color.FromArgb(194, 194, 194); } }
   }
}
