// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviColorTableOff7Black.cs" company="Zeroit Dev Technologies">
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
    /// Class NaviColorTableOff7Black.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviColorTableOff7" />
    public class NaviColorTableOff7Black : NaviColorTableOff7
   {
        // General colors 
        /// <summary>
        /// Gets the dark border.
        /// </summary>
        /// <value>The dark border.</value>
        public override Color DarkBorder { get { return Color.FromArgb(167, 173, 182); } }
        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public override Color Text { get { return Color.FromArgb(0, 0, 0); } }
        /// <summary>
        /// Gets the shapes front.
        /// </summary>
        /// <value>The shapes front.</value>
        public override Color ShapesFront { get { return Color.FromArgb(49, 52, 49); } }

        // NaviButton Normal
        /// <summary>
        /// Gets the button light.
        /// </summary>
        /// <value>The button light.</value>
        public override Color ButtonLight { get { return Color.FromArgb(219, 222, 226); } }
        /// <summary>
        /// Gets the button dark.
        /// </summary>
        /// <value>The button dark.</value>
        public override Color ButtonDark { get { return Color.FromArgb(199, 203, 209); } }
        /// <summary>
        /// Gets the button highlight dark.
        /// </summary>
        /// <value>The button highlight dark.</value>
        public override Color ButtonHighlightDark { get { return Color.FromArgb(223, 226, 228); } }
        /// <summary>
        /// Gets the button highlight light.
        /// </summary>
        /// <value>The button highlight light.</value>
        public override Color ButtonHighlightLight { get { return Color.FromArgb(248, 248, 249); } }

        // Header of band
        /// <summary>
        /// Gets the header bg dark.
        /// </summary>
        /// <value>The header bg dark.</value>
        public override Color HeaderBgDark { get { return Color.FromArgb(189, 193, 200); } }
        /// <summary>
        /// Gets the header bg light.
        /// </summary>
        /// <value>The header bg light.</value>
        public override Color HeaderBgLight { get { return Color.FromArgb(240, 241, 242); } }

        // Splitter
        /// <summary>
        /// Gets the splitter dark.
        /// </summary>
        /// <value>The splitter dark.</value>
        public override Color SplitterDark { get { return Color.FromArgb(195, 200, 206); } }
        /// <summary>
        /// Gets the splitter light.
        /// </summary>
        /// <value>The splitter light.</value>
        public override Color SplitterLight { get { return Color.FromArgb(255, 255, 255); } }
        /// <summary>
        /// Gets the splitter highlights.
        /// </summary>
        /// <value>The splitter highlights.</value>
        public override Color SplitterHighlights { get { return Color.FromArgb(255, 255, 255); } }

        // Group
        /// <summary>
        /// Gets the group bg light.
        /// </summary>
        /// <value>The group bg light.</value>
        public override Color GroupBgLight { get { return Color.FromArgb(239, 240, 241); } }
        /// <summary>
        /// Gets the group bg dark.
        /// </summary>
        /// <value>The group bg dark.</value>
        public override Color GroupBgDark { get { return Color.FromArgb(221, 224, 227); } }
        /// <summary>
        /// Gets the group bg hovered light.
        /// </summary>
        /// <value>The group bg hovered light.</value>
        public override Color GroupBgHoveredLight { get { return Color.FromArgb(255, 255, 255); } }
        /// <summary>
        /// Gets the group bg hovered dark.
        /// </summary>
        /// <value>The group bg hovered dark.</value>
        public override Color GroupBgHoveredDark { get { return Color.FromArgb(232, 234, 236); } }
        /// <summary>
        /// Gets the group border light.
        /// </summary>
        /// <value>The group border light.</value>
        public override Color GroupBorderLight { get { return Color.FromArgb(199, 203, 209); } }
        /// <summary>
        /// Gets the group inner border.
        /// </summary>
        /// <value>The group inner border.</value>
        public override Color GroupInnerBorder { get { return Color.FromArgb(255, 255, 255); } }

        // Collapsed band
        /// <summary>
        /// Gets the band collapsed bg.
        /// </summary>
        /// <value>The band collapsed bg.</value>
        public override Color BandCollapsedBg { get { return Color.FromArgb(235, 235, 235); } }

        /// <summary>
        /// Gets the popup band background.
        /// </summary>
        /// <value>The popup band background.</value>
        public override Color PopupBandBackground { get { return Color.FromArgb(240, 241, 242); } }
   }
}