// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviBandRendererOff7.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// This class contains the drawing functionality for a NavigationBand
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.NaviBandRenderer" />
    public class NaviBandRendererOff7 : NaviBandRenderer
   {
        #region Fields

        /// <summary>
        /// The color table
        /// </summary>
        NaviColorTableOff7 colorTable = new NaviColorTableOff7();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NaviBandRendererOff7"/> class.
        /// </summary>
        public NaviBandRendererOff7()
      {
      }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the colors to draw the control with
        /// </summary>
        /// <value>The color table.</value>
        public override NaviColorTableOff7 ColorTable
      {
         get { return colorTable; }
         set { colorTable = value; }
      }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the background of an Navigation band
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        public override void DrawBackground(Graphics g, Rectangle bounds)
      {
         using (Brush b = new SolidBrush(colorTable.Background))
         {
            g.FillRectangle(b, bounds);
         }
      }

        /// <summary>
        /// Draws the background of the collapsed band
        /// </summary>
        /// <param name="g">The canvas to draw on</param>
        /// <param name="bounds">The bounds of the drawing</param>
        /// <param name="text">The text that should appear into the bar</param>
        /// <param name="font">The font to use when drawing the text</param>
        /// <param name="rightToLeft">if set to <c>true</c> [right to left].</param>
        /// <param name="state">The inputstate of the collapsed band</param>
        public override void DrawCollapsedBand(Graphics g, Rectangle bounds, string text, Font font,
         bool rightToLeft, InputState state)
      {
         // TODO Right to left

         using (SolidBrush b = new SolidBrush(colorTable.BandCollapsedBg))
         {
            if (state == InputState.Hovered)
               b.Color = colorTable.BandCollapsedFocused;
            else if (state == InputState.Clicked)
               b.Color = colorTable.BandCollapsedClicked;

            g.FillRectangle(b, bounds);
         }

         // inner border
         using (Pen p = new Pen(colorTable.DarkBorder))
         {
            g.DrawLine(p, new Point(bounds.Left, bounds.Top), new Point(bounds.Right,
               bounds.Top));
            p.Color = colorTable.HeaderBgInnerBorder;
            if (state == InputState.Normal)
            {
               g.DrawLine(p, new Point(bounds.Left, bounds.Top + 1), new Point(bounds.Right,
                  bounds.Top + 1));
               g.DrawLine(p, new Point(bounds.Left, bounds.Top + 1), new Point(bounds.Left,
                  bounds.Bottom));
            }
         }

         using (Brush brush = new SolidBrush(colorTable.Text))
         {
            if (rightToLeft)
            {
               Point ptCenter = new Point(bounds.X + bounds.Width / 2 + 7, bounds.Y +
                  bounds.Height / 2);
               System.Drawing.Drawing2D.Matrix transform = g.Transform;
               transform.RotateAt(90, ptCenter);
               g.Transform = transform;
               using (StringFormat format = new StringFormat())
               {
                  format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
                  g.DrawString(text, font, brush, ptCenter, format);
               }
            }
            else
            {
               Point ptCenter = new Point(bounds.X + bounds.Width / 2 - 7, bounds.Y +
                  bounds.Height / 2);
               System.Drawing.Drawing2D.Matrix transform = g.Transform;
               transform.RotateAt(270, ptCenter);
               g.Transform = transform;
               g.DrawString(text, font, brush, ptCenter);
            }
         }
      }

        /// <summary>
        /// Draws the background of the popped up band
        /// </summary>
        /// <param name="g">The canvas to draw on</param>
        /// <param name="bounds">The bounds of the drawing</param>
        public override void DrawPopupBand(Graphics g, Rectangle bounds)
      {
         // TODO Right to left
         using (Brush b = new SolidBrush(colorTable.PopupBandBackground))
         {
            g.FillRectangle(b, bounds);
         }
      }

      #endregion
   }
}
