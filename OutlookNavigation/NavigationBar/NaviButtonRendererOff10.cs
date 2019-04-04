// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviButtonRendererOff10.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// This class contains drawing functionality for an button
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviButtonRenderer" />
    public class NaviButtonRendererOff10 : NaviButtonRenderer
   {
        #region Fields
        /// <summary>
        /// The color table
        /// </summary>
        NaviColorTableOff10 colorTable = new NaviColorTableOff10();
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviButtonOfficeRenderer class
        /// </summary>
        public NaviButtonRendererOff10()
      {
         // Use by default the blue colors, override this with the property ColorTable
         colorTable = new NaviColorTableOff10();
      }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the color table.
        /// </summary>
        /// <value>The color table.</value>
        public NaviColorTableOff10 ColorTable
      {
         get { return colorTable; }
         set { colorTable = value; }
      }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the background gradients of an Button
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        /// <param name="state">The state.</param>
        /// <param name="inputState">State of the input.</param>
        public override void DrawBackground(Graphics g, Rectangle bounds, ControlState state, InputState inputState)
      {
         Color[] endColors = new Color[1];

         if ((state == ControlState.Normal) && (inputState == InputState.Normal))
         {
            endColors = new Color[] { ColorTable.ButtonDark, ColorTable.ButtonDark };
         }
         else if ((state == ControlState.Normal) && (inputState == InputState.Hovered))
         {
            endColors = new Color[] { ColorTable.ButtonHoveredDark, ColorTable.ButtonHoveredLight };
         }
         else if ((state == ControlState.Active) && (inputState == InputState.Normal))
         {
            endColors = new Color[] { ColorTable.ButtonActiveDark, ColorTable.ButtonActiveLight };
         }
         else if ((inputState == InputState.Clicked)
            || ((state == ControlState.Active) && (inputState == InputState.Hovered)))
         {
            endColors = new Color[] { ColorTable.ButtonActiveLight, ColorTable.ButtonActiveDark };
         }

         float[] ColorPositions = { 0.0f, 1.0f };

         ExtDrawing.DrawGradient(g, bounds, endColors, ColorPositions);

         using (Pen p = new Pen(ColorTable.DarkOutlines))
         {
            g.DrawLine(p, bounds.Left, bounds.Top, bounds.Right, bounds.Top);
            p.Color = ColorTable.LightOutlines;
            g.DrawLine(p, bounds.Left, bounds.Top + 1, bounds.Right, bounds.Top + 1);
         }
      }

        /// <summary>
        /// Draws text on a graphics canvas
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the text</param>
        /// <param name="font">The font of the text</param>
        /// <param name="text">The text to draw</param>
        /// <param name="rightToLeft">Rigth to left or left to right layout</param>
        public override void DrawText(Graphics g, Rectangle bounds, Font font, string text, bool rightToLeft)
      {
         using (Brush brush = new SolidBrush(ColorTable.TextColor))
         {
            if (rightToLeft)
            {
               TextRenderer.DrawText(g, text, font, bounds, ColorTable.TextColor,
                  TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
                  | TextFormatFlags.Right | TextFormatFlags.RightToLeft);
            }
            else
            {
               TextRenderer.DrawText(g, text, font, bounds, ColorTable.TextColor,
                  TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }
         }
      }

        /// <summary>
        /// Draws an image on the canvas at a given location
        /// </summary>
        /// <param name="g">The graphics canvas to draw on</param>
        /// <param name="location">The location of the image</param>
        /// <param name="image">The image</param>
        public override void DrawImage(Graphics g, Point location, Image image)
      {
         g.DrawImage(image, location);
      }

        #endregion

        #region Overrides

        /// <summary>
        /// Draws the surface of the options button
        /// </summary>
        /// <param name="g">The graphics canvas to draw on</param>
        /// <param name="bounds">The bounds of the text</param>
        public override void DrawOptionsTriangle(Graphics g, Rectangle bounds)
      {
         Point[] points = new Point[] { 
            new Point(bounds.Width /2 +3,bounds.Height /2 -1), 
            new Point(bounds.Width /2, bounds.Height /2 +2), 
            new Point(bounds.Width /2 -2,bounds.Height /2 -1) };

         Point[] pointsRec2 = new Point[] { 
            new Point(bounds.Width /2 +3,bounds.Height /2), 
            new Point(bounds.Width /2, bounds.Height /2 +3), 
            new Point(bounds.Width /2 -2,bounds.Height /2) };

         using (SolidBrush b = new SolidBrush(colorTable.ButtonOptionsInner))
         {
            g.FillPolygon(b, pointsRec2);
            b.Color = colorTable.ButtonOptionsOuter;
            g.FillPolygon(b, points);
         }
      }

        /// <summary>
        /// Draws the surface of the Collapse button
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        /// <param name="inputState">The input state of the control</param>
        /// <param name="rightToLeft">Right to left or left to right</param>
        /// <param name="collapsed">The bar is collasped or not</param>
        public override void DrawCollapseButton(Graphics g, Rectangle bounds, InputState inputState, bool rightToLeft,
         bool collapsed)
      {
         // TODO
      }

      #endregion

      #region Event Handling
      #endregion
   }
}
