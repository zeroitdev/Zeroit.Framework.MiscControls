// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviSplitterRendererOff3.cs" company="Zeroit Dev Technologies">
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
    /// Class NaviSplitterRendererOff3.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviSplitterRenderer" />
    public class NaviSplitterRendererOff3 : NaviSplitterRenderer
   {
        #region Fields

        /// <summary>
        /// The color table
        /// </summary>
        NaviColorTableOff3 colorTable;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the GradientSplitterProRenderer class
        /// </summary>
        public NaviSplitterRendererOff3()
      {
         colorTable = new NaviColorTableOff3();
      }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the colors to draw with
        /// </summary>
        /// <value>The color table.</value>
        public NaviColorTableOff3 ColorTable
      {
         get { return colorTable; }
         set { colorTable = value; }
      }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the background of the gradient splitter class to a graphics surface
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the drawing relative to the graphics surface</param>
        public override void DrawBackground(Graphics g, Rectangle bounds)
      {
         bool vertical = bounds.Width > bounds.Height;

         // Background
         Color[] EndColors = { colorTable.SplitterLight, colorTable.SplitterDark };
         float[] ColorPositions = { 0.0f, 1.0f };

         ColorBlend blend = new ColorBlend();

         blend.Colors = EndColors;
         blend.Positions = ColorPositions;

         if (bounds.Height == 0)
            bounds.Height = 1;
         if (bounds.Width == 0)
            bounds.Width = 1; // its to prevent an out of memory exception

         Point beginPoint;
         Point endPoint;
         if (vertical)
         {
            beginPoint = new Point(0, bounds.Top);
            endPoint = new Point(0, bounds.Bottom);
         }
         else
         {
            beginPoint = new Point(bounds.Left, 0);
            endPoint = new Point(bounds.Right, 0);
         }

         // Make the linear brush and assign the custom blend to it
         using (LinearGradientBrush brush = new LinearGradientBrush(beginPoint,
                                                           endPoint,
                                                           Color.White,
                                                           Color.Black))
         {
            brush.InterpolationColors = blend;
            g.FillRectangle(brush, bounds);
         }

         int centerX = bounds.Right - (bounds.Width / 2);
         int centerY = bounds.Bottom - (bounds.Height / 2);

         using (SolidBrush b = new SolidBrush(colorTable.DarkBorder))
         {
            if (vertical)
            {
               g.FillRectangle(b, centerX - 8, centerY - 1, 2, 2);
               g.FillRectangle(b, centerX - 4, centerY - 1, 2, 2);
               g.FillRectangle(b, centerX, centerY - 1, 2, 2);
               g.FillRectangle(b, centerX + 4, centerY - 1, 2, 2);
               g.FillRectangle(b, centerX + 8, centerY - 1, 2, 2);

               b.Color = colorTable.SplitterHighlights;

               g.FillRectangle(b, centerX - 7, centerY, 2, 2);
               g.FillRectangle(b, centerX - 3, centerY, 2, 2);
               g.FillRectangle(b, centerX + 1, centerY, 2, 2);
               g.FillRectangle(b, centerX + 5, centerY, 2, 2);
               g.FillRectangle(b, centerX + 9, centerY, 2, 2);
            }
            else
            {
               g.FillRectangle(b, centerX - 1, centerY - 8, 2, 2);
               g.FillRectangle(b, centerX - 1, centerY - 4, 2, 2);
               g.FillRectangle(b, centerX - 1, centerY, 2, 2);
               g.FillRectangle(b, centerX - 1, centerY + 4, 2, 2);
               g.FillRectangle(b, centerX - 1, centerY + 8, 2, 2);

               b.Color = colorTable.SplitterHighlights;

               g.FillRectangle(b, centerX, centerY - 7, 2, 2);
               g.FillRectangle(b, centerX, centerY - 3, 2, 2);
               g.FillRectangle(b, centerX, centerY + 1, 2, 2);
               g.FillRectangle(b, centerX, centerY + 5, 2, 2);
               g.FillRectangle(b, centerX, centerY + 9, 2, 2);
            }
         }
      }

      #endregion
   }
}
