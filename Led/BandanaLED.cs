// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="BandanaLED.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region ZeroitBandanaLED

    /// <summary>
    /// ZeroitBandanaLED is a small .NET Windows User Control which displays an LED vu meter, similar to
    /// those found on PC/Mac music applications.
    /// It has 15 seperate LEDs, and accepts values from 1 to 15.
    /// The peak LED will stay lit for 1 second.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitBandanaLED : System.Windows.Forms.Control
    {
        #region Private Fields
        /// <summary>
        /// The timer1
        /// </summary>
        protected System.Windows.Forms.Timer timer1;                 // Timer to determine how long the peak indicator persists 
        // Array of LED colors Unlit surround		Lit surround	Lit centre
        //													Unlit centre
        /// <summary>
        /// The led colours
        /// </summary>
        Color[] ledColours = new Color[]{Color.DarkRed,     Color.Red,      Color.White,
            Color.DarkRed,      Color.Red,      Color.White,
            Color.DarkRed,      Color.Red,      Color.White,
            Color.DarkGoldenrod,Color.Orange,   Color.White,
            Color.DarkGoldenrod,Color.Orange,   Color.White,
            Color.DarkGoldenrod,Color.Orange,   Color.White,
            Color.DarkGoldenrod,Color.Orange,   Color.White,
            Color.DarkGreen,    Color.Green,    Color.White,
            Color.DarkGreen,    Color.Green,    Color.White,
            Color.DarkGreen,    Color.Green,    Color.White,
            Color.DarkGreen,    Color.Green,    Color.White,
            Color.DarkGreen,    Color.Green,    Color.White,
            Color.DarkGreen,    Color.Green,    Color.White,
            Color.DarkGreen,    Color.Green,    Color.White,
            Color.DarkGreen,    Color.Green,    Color.White};
        /// <summary>
        /// The draw borders
        /// </summary>
        bool drawBorders = false;
        /// <summary>
        /// The led value
        /// </summary>
        int ledVal;                             // VU meter value - range 1 to 15
        /// <summary>
        /// The peak value
        /// </summary>
        int peakVal;                            // Peak value
        /// <summary>
        /// The led count
        /// </summary>
        int ledCount = 15;                      // Number of LEDs
        /// <summary>
        /// The peak msec
        /// </summary>
        int peakMsec = 1000;                    // Peak Indicator time is 1 sec.

        #endregion

        #region Public Properties
        // Determine how many LEDs to light - valid range 0 - 15

        /// <summary>
        /// Gets or sets how many LEDs to light - valid range 0 - 15.
        /// </summary>
        /// <value>The volume.</value>
        public int Volume
        {
            get
            {
                return ledVal;
            }
            set
            {
                // Do not allow negative value
                if (value < 0)
                {
                    ledVal = 0;
                }
                // Max value is 15 - anything over that, allow it but set to 15
                else if (value > 15)
                {
                    ledVal = 15;
                }
                else
                {
                    ledVal = value;
                }

                // New peak value
                if (ledVal > peakVal)
                {
                    peakVal = ledVal;
                    timer1.Enabled = true;          // Tell the peak indicator to stay
                }
                this.Invalidate();                  // Re-draw the control
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to draw the border.
        /// </summary>
        /// <value><c>true</c> if draw border; otherwise, <c>false</c>.</value>
        public bool DrawBorder
        {
            get { return drawBorders; }
            set
            {
                drawBorders = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBandanaLED" /> class.
        /// </summary>
        public ZeroitBandanaLED()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            this.Name = "ZeroitBandanaLED";
            this.Size = new System.Drawing.Size(20, 100);       // Default size for control
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = peakMsec;							// Peak indicator time
            timer1.Enabled = false;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (AllowTransparency)
            {
                MakeTransparent(this, g);
            }

            DrawLeds(g);

            if (drawBorders)
            {
                DrawBorders(g);
            }

        }

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;                 // Tell the peak indicator to go
            peakVal = 0;                            //
            this.Invalidate();
        }

        /// <summary>
        /// Draws the leds.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawLeds(Graphics g)
        {
            // Rectangle values for each individual LED - fit them nicely inside the border
            int ledLeft = this.ClientRectangle.Left + 3;
            int ledTop = this.ClientRectangle.Top + 3;
            int ledWidth = this.ClientRectangle.Width - 6;
            int ledHeight = this.ClientRectangle.Height / ledCount - 2;

            // Create the LED rectangle
            Rectangle ledRect = new Rectangle(ledLeft, ledTop, ledWidth, ledHeight);

            GraphicsPath gp = new GraphicsPath();                   // Create Graphics Path
            gp.AddRectangle(ledRect);                               // Add the rectangle
            PathGradientBrush pgb = new PathGradientBrush(gp);      // Nice brush for shiny LEDs

            // Two ints in the FOR LOOP, because the graphics are offset from the top, but the LED
            // values start from the bottom...
            for (int i = 0, j = ledCount; i < ledCount; i++, j--)
            {
                // Light the LED if it's under current value, or if it's the peak value.
                if ((j <= ledVal) | (j == peakVal))
                {
                    pgb.CenterColor = ledColours[i * 3 + 2];
                    pgb.SurroundColors = new Color[] { ledColours[i * 3 + 1] };
                }
                // Otherwise, don't light it.
                else
                {
                    pgb.CenterColor = ledColours[i * 3 + 1];
                    pgb.SurroundColors = new Color[] { ledColours[i * 3] };
                }

                // Light LED fom the centre.
                pgb.CenterPoint = new PointF(ledRect.X + ledRect.Width / 2, ledRect.Y + ledRect.Height / 2);

                // Use a matrix to move the LED graphics down according to the value of i
                Matrix mx = new Matrix();
                mx.Translate(0, i * (ledHeight + 2));
                g.Transform = mx;
                g.FillRectangle(pgb, ledRect);
            }

            // Translate back to original position to draw the border
            Matrix mx1 = new Matrix();
            mx1.Translate(0, 0);
            g.Transform = mx1;

            gp.Dispose();
        }

        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawBorders(Graphics g)
        {
            int PenWidth = (int)Pens.White.Width;

            // Draw the outer 3D border round the control
            //
            g.DrawLine(Pens.White,
                new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
                new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top)); //Top
            g.DrawLine(Pens.White,
                new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
                new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth)); //Left
            g.DrawLine(Pens.DarkGray,
                new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth),
                new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth)); //Bottom
            g.DrawLine(Pens.DarkGray,
                new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top),
                new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth)); //Right


            // Draw the inner 3D border round the LEDs
            //

            // Set the size to fit nicely inside the control.
            int ledBorderLeft = this.ClientRectangle.Left + 2;
            int ledBorderTop = this.ClientRectangle.Top + 2;
            int ledBorderWidth = this.ClientRectangle.Width - 3;
            int ledBorderHeight = this.ClientRectangle.Height - 3;

            // Draw the border
            g.DrawLine(Pens.DarkGray, new Point(ledBorderLeft, ledBorderTop), new Point(ledBorderWidth, ledBorderTop)); //Top
            g.DrawLine(Pens.DarkGray, new Point(ledBorderLeft, ledBorderTop), new Point(ledBorderLeft, ledBorderHeight)); //Left
            g.DrawLine(Pens.White, new Point(ledBorderLeft, ledBorderHeight), new Point(ledBorderWidth, ledBorderHeight)); //Bottom
            g.DrawLine(Pens.White, new Point(ledBorderWidth, ledBorderTop), new Point(ledBorderWidth, ledBorderHeight)); //Right
                                                                                                                         // Extra line to overwrite any LED which shows between the inner and outer border.
            g.DrawLine(Pens.LightGray, new Point(ledBorderLeft, ledBorderHeight + 1), new Point(ledBorderWidth, ledBorderHeight + 1));

        }

        #endregion





        #region Include in Private Field

        /// <summary>
        /// The allow transparency
        /// </summary>
        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow transparency].
        /// </summary>
        /// <value><c>true</c> if [allow transparency]; otherwise, <c>false</c>.</value>
        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion



        #region Include in Paint

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        /// <summary>
        /// Makes the transparent.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="g">The g.</param>
        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion




    }

    #endregion

}
