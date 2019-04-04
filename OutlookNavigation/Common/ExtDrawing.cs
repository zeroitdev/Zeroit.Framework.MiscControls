// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ExtDrawing.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ExtDrawing.
    /// </summary>
    public class ExtDrawing
   {
        /// <summary>
        /// Draws a gradient on a Graphics canvas
        /// </summary>
        /// <param name="g">The graphics canvas</param>
        /// <param name="bounds">The bounds of the gradient</param>
        /// <param name="colors">The colors of the gradient</param>
        /// <param name="positions">The position of the colors inside the gradient</param>
        public static void DrawGradient(Graphics g, Rectangle bounds, Color[] colors,
         float[] positions)
      {
         ColorBlend blend = new ColorBlend();

         blend.Colors = colors;
         blend.Positions = positions;

         // To prevent out of memory exceptions when the width or height is 0
         if (bounds.Height == 0)
            bounds.Height = 1; 
         if (bounds.Width == 0)
            bounds.Width = 1;

         // Make the linear brush and assign the custom blend to it
         using (LinearGradientBrush brush = new LinearGradientBrush(new Point(bounds.Left, bounds.Bottom),
                                                           new Point(bounds.Left, bounds.Top),
                                                           Color.White,
                                                           Color.Black))
         {
            brush.InterpolationColors = blend;
            g.FillRectangle(brush, bounds);
         }
      }
   }
}
