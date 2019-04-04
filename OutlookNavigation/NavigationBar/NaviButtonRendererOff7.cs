// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviButtonRendererOff7.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// This class contains drawing functionality for an button
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviButtonRenderer" />
    public class NaviButtonRendererOff7 : NaviButtonRenderer
   {
        #region Fields

        /// <summary>
        /// The color table
        /// </summary>
        NaviColorTableOff7 colorTable;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviButtonOfficeRenderer class
        /// </summary>
        public NaviButtonRendererOff7()
      {
         // Use by default the blue colors, override this with the property ColorTable
         colorTable = new NaviColorTableOff7();
      }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the table of colors
        /// </summary>
        /// <value>The color table.</value>
        public NaviColorTableOff7 ColorTable
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
            endColors = new Color[] { ColorTable.ButtonLight, ColorTable.ButtonDark, 
                                ColorTable.ButtonHighlightDark, ColorTable.ButtonHighlightLight };
         }
         else if ((state == ControlState.Normal) && (inputState == InputState.Hovered))
         {
            endColors = new Color[] { ColorTable.ButtonHoveredLight, ColorTable.ButtonHoveredDark, 
                                ColorTable.ButtonHoveredHighlightDark, ColorTable.ButtonHoveredHighlightLight };
         }
         else if ((state == ControlState.Active) && (inputState == InputState.Normal))
         {
            endColors = new Color[] { ColorTable.ButtonActiveLight, ColorTable.ButtonActiveDark, 
                                ColorTable.ButtonActiveHighlightDark, ColorTable.ButtonActiveHighlightLight };
         }
         else if ((inputState == InputState.Clicked)
            || ((state == ControlState.Active) && (inputState == InputState.Hovered)))
         {
            endColors = new Color[] { ColorTable.ButtonClickedLight, ColorTable.ButtonClickedDark, 
                                ColorTable.ButtonClickedHighlightDark, ColorTable.ButtonClickedHighlightLight };
         }

         float[] ColorPositions = { 0.0f, 0.62f, 0.62f, 1.0f };

         ExtDrawing.DrawGradient(g, bounds, endColors, ColorPositions);

         using (Pen p = new Pen(ColorTable.DarkBorder))
         {
            g.DrawLine(p, bounds.Left, bounds.Top, bounds.Right, bounds.Top);
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
         using (Brush brush = new SolidBrush(ColorTable.Text))
         {
            if (rightToLeft)
            {
               TextRenderer.DrawText(g, text, font, bounds, ColorTable.Text,
                  TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
                  | TextFormatFlags.Right | TextFormatFlags.RightToLeft);
            }
            else
            {
               TextRenderer.DrawText(g, text, font, bounds, ColorTable.Text,
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
         Color[] endColors = new Color[1];
         Color[] smallColors = new Color[1];

         if (inputState == InputState.Clicked)
         {
            smallColors = new Color[] { colorTable.CollapseButtonDownDark, 
               colorTable.CollapseButtonDownLight };
         }
         else if (inputState == InputState.Hovered)
         {
            smallColors = new Color[] { colorTable.CollapseButtonHoveredLight, 
               colorTable.CollapseButtonHoveredDark };
         }

         endColors = new Color[] { colorTable.HeaderBgLight, 
               colorTable.HeaderBgDark};

         float[] ColorPositions = { 0.0f, 1.0f };

         ColorBlend blend = new ColorBlend();

         blend.Colors = endColors;
         blend.Positions = ColorPositions;

         if (bounds.Height == 0) // To prevent an out of memory exception
            bounds.Height = 1;
         if (bounds.Width == 0)
            bounds.Width = 1;

         // Make the linear brush and assign the custom blend to it
         using (LinearGradientBrush brush = new LinearGradientBrush(new Point(bounds.Left, bounds.Top),
                                                           new Point(bounds.Left, bounds.Bottom),
                                                           Color.White,
                                                           Color.Black))
         {
            brush.InterpolationColors = blend;
            g.FillRectangle(brush, bounds);
         }

         if ((inputState == InputState.Clicked) || (inputState == InputState.Hovered))
         {
            Rectangle smallBounds = bounds;
            smallBounds.Location = new Point(smallBounds.Left + 4, smallBounds.Top + 3);
            smallBounds.Size = new Size(smallBounds.Width - 8, smallBounds.Height - 6);

            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(smallBounds.Left, smallBounds.Top),
                                                           new Point(smallBounds.Left, smallBounds.Bottom),
                                                           Color.White,
                                                           Color.Black))
            {
               blend.Colors = smallColors;
               brush.InterpolationColors = blend;
               g.FillRectangle(brush, smallBounds);
            }
         }

         using (Pen pen = new Pen(colorTable.DarkBorder))
         {
            // Arrows
            pen.Color = colorTable.ShapesFront;

            //width-7
            //(height/2)+1
            // w=7 h=4
            pen.Width = 1.5f;
            float x = 0;
            float y = 0;

            if (bounds.Height != 0)
               y = (bounds.Height / 2) - 3;

            if (bounds.Width != 0)
               x = (bounds.Width / 2) - 1;

            if (((rightToLeft) && (!collapsed)) || (!rightToLeft) && (collapsed))
            {
               PointF[] points = {new PointF(x -3, y), 
                               new PointF(x,y + 3), 
                               new PointF(x-3, y + 3 + 3) };
               g.DrawLines(pen, points);

               PointF[] points2 = {new PointF(x + 1, y), 
                               new PointF(x + 4,y + 3), 
                               new PointF(x + 1, y + 3 + 3) };
               g.DrawLines(pen, points2);
            }
            else
            {
               PointF[] points = {new PointF(x, y), 
                               new PointF(x - 3,y + 3), 
                               new PointF(x, y + 3 + 3) };
               g.DrawLines(pen, points);

               PointF[] points2 = {new PointF(x + 4, y), 
                               new PointF(x + 1,y + 3), 
                               new PointF(x + 4, y + 3 + 3) };
               g.DrawLines(pen, points2);
            }
         }
      }

      #endregion

      #region Event Handling
      #endregion
   }
}
