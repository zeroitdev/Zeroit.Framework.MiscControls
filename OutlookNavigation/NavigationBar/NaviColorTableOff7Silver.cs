// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviColorTableOff7Silver.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviColorTableOff7Silver.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviColorTableOff7" />
    public class NaviColorTableOff7Silver : NaviColorTableOff7
   {
        // General colors 
        /// <summary>
        /// Gets the dark border.
        /// </summary>
        /// <value>The dark border.</value>
        public override Color DarkBorder { get { return Color.FromArgb(111, 112, 116); } }
        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public override Color Text { get { return Color.FromArgb(21, 66, 139); } }
        /// <summary>
        /// Gets the shapes front.
        /// </summary>
        /// <value>The shapes front.</value>
        public override Color ShapesFront { get { return Color.FromArgb(101, 104, 112); } }

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
        public override Color ButtonDark { get { return Color.FromArgb(197, 199, 209); } }
        /// <summary>
        /// Gets the button highlight dark.
        /// </summary>
        /// <value>The button highlight dark.</value>
        public override Color ButtonHighlightDark { get { return Color.FromArgb(214, 218, 228); } }
        /// <summary>
        /// Gets the button highlight light.
        /// </summary>
        /// <value>The button highlight light.</value>
        public override Color ButtonHighlightLight { get { return Color.FromArgb(235, 238, 250); } }

        // Header of band
        /// <summary>
        /// Gets the header bg dark.
        /// </summary>
        /// <value>The header bg dark.</value>
        public override Color HeaderBgDark { get { return Color.FromArgb(218, 223, 230); } }
        /// <summary>
        /// Gets the header bg light.
        /// </summary>
        /// <value>The header bg light.</value>
        public override Color HeaderBgLight { get { return Color.FromArgb(255, 255, 255); } }

        // Splitter
        /// <summary>
        /// Gets the splitter dark.
        /// </summary>
        /// <value>The splitter dark.</value>
        public override Color SplitterDark { get { return Color.FromArgb(119, 118, 151); } }
        /// <summary>
        /// Gets the splitter light.
        /// </summary>
        /// <value>The splitter light.</value>
        public override Color SplitterLight { get { return Color.FromArgb(168, 167, 191); } }
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
        public override Color GroupBgLight { get { return Color.FromArgb(215, 215, 229); } }
        /// <summary>
        /// Gets the group bg dark.
        /// </summary>
        /// <value>The group bg dark.</value>
        public override Color GroupBgDark { get { return Color.FromArgb(216, 216, 230); } }
        /// <summary>
        /// Gets the group bg hovered light.
        /// </summary>
        /// <value>The group bg hovered light.</value>
        public override Color GroupBgHoveredLight { get { return Color.FromArgb(215, 215, 229); } }
        /// <summary>
        /// Gets the group bg hovered dark.
        /// </summary>
        /// <value>The group bg hovered dark.</value>
        public override Color GroupBgHoveredDark { get { return Color.FromArgb(216, 216, 230); } }
        /// <summary>
        /// Gets the group border light.
        /// </summary>
        /// <value>The group border light.</value>
        public override Color GroupBorderLight { get { return Color.FromArgb(197, 199, 199); } }

        // Collapsed band
        /// <summary>
        /// Gets the band collapsed bg.
        /// </summary>
        /// <value>The band collapsed bg.</value>
        public override Color BandCollapsedBg { get { return Color.FromArgb(238, 238, 244); } }

        /// <summary>
        /// Gets the popup band background.
        /// </summary>
        /// <value>The popup band background.</value>
        public override Color PopupBandBackground { get { return Color.FromArgb(240, 241, 242); } }
   }
}