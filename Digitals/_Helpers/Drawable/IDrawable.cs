// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-27-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="IDrawable.cs" company="Zeroit Dev Technologies">
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
