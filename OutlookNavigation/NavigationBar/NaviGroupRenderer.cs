// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviGroupRenderer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviGroupRenderer.
    /// </summary>
    public abstract class NaviGroupRenderer
   {
        #region Methods

        /// <summary>
        /// Draws the background.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        public abstract void DrawBackground(Graphics g, Rectangle bounds);

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="font">The font.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="rightToLeft">if set to <c>true</c> [right to left].</param>
        public abstract void DrawText(Graphics g, Rectangle bounds, Font font, string headerText, bool rightToLeft);

        /// <summary>
        /// Draws the header.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="state">The state.</param>
        /// <param name="expanded">if set to <c>true</c> [expanded].</param>
        /// <param name="rightToLeft">if set to <c>true</c> [right to left].</param>
        public abstract void DrawHeader(Graphics g, Rectangle bounds, InputState state, bool expanded, bool rightToLeft);

        /// <summary>
        /// Draws the hatched panel.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        public abstract void DrawHatchedPanel(Graphics g, Rectangle bounds);
      
      #endregion
   }
}
