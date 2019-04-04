// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviBandRenderer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// This class contains the drawing functionality for a NavigationBand
    /// </summary>
    public abstract class NaviBandRenderer
   {
        #region Properties

        /// <summary>
        /// Gets or sets the colors to draw the control with
        /// </summary>
        /// <value>The color table.</value>
        public abstract NaviColorTableOff7 ColorTable { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the background of an Navigation band
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        public abstract void DrawBackground(Graphics g, Rectangle bounds);

        /// <summary>
        /// Draws the background of the collapsed band
        /// </summary>
        /// <param name="g">The canvas to draw on</param>
        /// <param name="bounds">The bounds of the drawing</param>
        /// <param name="text">The text that should appear into the bar</param>
        /// <param name="font">The font to use when drawing the text</param>
        /// <param name="rightToLeft">if set to <c>true</c> [right to left].</param>
        /// <param name="state">The inputstate of the collapsed band</param>
        public abstract void DrawCollapsedBand(Graphics g, Rectangle bounds, string text, Font font,
         bool rightToLeft, InputState state);

        /// <summary>
        /// Draws the background of the popped up band
        /// </summary>
        /// <param name="g">The canvas to draw on</param>
        /// <param name="bounds">The bounds of the drawing</param>
        public abstract void DrawPopupBand(Graphics g, Rectangle bounds);

      #endregion
   }
}
