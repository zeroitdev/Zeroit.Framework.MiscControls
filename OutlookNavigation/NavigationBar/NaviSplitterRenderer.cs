// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviSplitterRenderer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Contains drawing functionality for the splitter
    /// </summary>
    public abstract class NaviSplitterRenderer   
   {
        #region Methods

        /// <summary>
        /// Draws the background of the gradient splitter class to a graphics surface
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the drawing relative to the graphics surface</param>
        public abstract void DrawBackground(Graphics g, Rectangle bounds);

      #endregion
   }
}
