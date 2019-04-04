// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-27-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="IDrawable.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.MiscControls.Digitals.Helpers.Drawable
{
    /// <summary>
    /// Interface IDrawable
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// Draws a control onto the graphics
        /// </summary>
        /// <param name="g">The graphics to draw onto</param>
        void Draw(Graphics g);

        /// <summary>
        /// Calculates this controls shape and size that will be used
        /// when it is drawn
        /// </summary>
        /// <param name="container">The allowed space for the control</param>
        void CalculatePaths(RectangleF container);

        /// <summary>
        /// Gets the region that needs to be redrawn because of changes to the control.
        /// This should be a union of where the control was last drawn and where it needs
        /// to be drawn.
        /// </summary>
        /// <returns>The region affected by this control</returns>
        Region GetRedrawRegion();
    }
}
