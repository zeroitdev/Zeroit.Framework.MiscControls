// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviColorTableOff3Silver.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviColorTableOff3Silver.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviColorTableOff3" />
    public class NaviColorTableOff3Silver : NaviColorTableOff3
   {
        // General colors 
        /// <summary>
        /// Gets the dark border.
        /// </summary>
        /// <value>The dark border.</value>
        public override Color DarkBorder { get { return Color.FromArgb(124, 124, 148); } }
        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public override Color Text { get { return Color.FromArgb(0, 0, 0); } }
        /// <summary>
        /// Gets the dark outlines.
        /// </summary>
        /// <value>The dark outlines.</value>
        public override Color DarkOutlines { get { return Color.FromArgb(124, 124, 148); } }

        // NaviButton Normal
        /// <summary>
        /// Gets the button light.
        /// </summary>
        /// <value>The button light.</value>
        public override Color ButtonLight { get { return Color.FromArgb(225, 226, 236); } }
        /// <summary>
        /// Gets the button dark.
        /// </summary>
        /// <value>The button dark.</value>
        public override Color ButtonDark { get { return Color.FromArgb(149, 147, 177); } }

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

        // Header of band
        /// <summary>
        /// Gets the header bg dark.
        /// </summary>
        /// <value>The header bg dark.</value>
        public override Color HeaderBgDark { get { return Color.FromArgb(114, 113, 147); } }
        /// <summary>
        /// Gets the header bg light.
        /// </summary>
        /// <value>The header bg light.</value>
        public override Color HeaderBgLight { get { return Color.FromArgb(168, 167, 191); } }
        /// <summary>
        /// Gets the header text.
        /// </summary>
        /// <value>The header text.</value>
        public override Color HeaderText { get { return Color.FromArgb(255, 255, 255); } }

        /// <summary>
        /// Gets the group bg light.
        /// </summary>
        /// <value>The group bg light.</value>
        public override Color GroupBgLight { get { return Color.FromArgb(242, 244, 244); } }
        /// <summary>
        /// Gets the group bg dark.
        /// </summary>
        /// <value>The group bg dark.</value>
        public override Color GroupBgDark { get { return Color.FromArgb(213, 219, 231); } }
        /// <summary>
        /// Gets the group bg hovered light.
        /// </summary>
        /// <value>The group bg hovered light.</value>
        public override Color GroupBgHoveredLight { get { return Color.FromArgb(242, 244, 244); } }
        /// <summary>
        /// Gets the group bg hovered dark.
        /// </summary>
        /// <value>The group bg hovered dark.</value>
        public override Color GroupBgHoveredDark { get { return Color.FromArgb(213, 219, 231); } }
        /// <summary>
        /// Gets the group border light.
        /// </summary>
        /// <value>The group border light.</value>
        public override Color GroupBorderLight { get { return Color.FromArgb(197, 199, 199); } }

      // NaviButtonOptions Triangle color options button
      //public override  ButtonOptionsOuter { get { return Color.FromArgb(67, 113, 176); } }
      //public override  ButtonOptionsInner { get { return Color.FromArgb(255, 248, 203); } }
   }
}