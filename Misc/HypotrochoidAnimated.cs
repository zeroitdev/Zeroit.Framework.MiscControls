// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="HypotrochoidAnimated.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region HypotrochoidAnimated    
    /// <summary>
    /// A class collection for rendering an animated hypothrochoid.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitHypotrochoidAnimated : Control
    {
        // The angle from one circle's center to the other.
        /// <summary>
        /// The theta
        /// </summary>
        private float theta = 0;
        /// <summary>
        /// The dtheta
        /// </summary>
        private float dtheta;

        // Drawing parameters.
        /// <summary>
        /// a
        /// </summary>
        private int A, B, C, wid, hgt, cx, cy;
        /// <summary>
        /// The maximum t
        /// </summary>
        private double max_t;
        /// <summary>
        /// The points
        /// </summary>
        private List<PointF> points;

        /// <summary>
        /// The TMR
        /// </summary>
        private System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();

        /// <summary>
        /// The width
        /// </summary>
        private int width = 50;
        /// <summary>
        /// The sides
        /// </summary>
        private int sides = 30;
        /// <summary>
        /// The circles
        /// </summary>
        private int circles = 50;
        /// <summary>
        /// The iterations
        /// </summary>
        private int iterations = 20;

        /// <summary>
        /// The color
        /// </summary>
        private Color color = Color.Black;

        /// <summary>
        /// The pic canvas
        /// </summary>
        private PictureBox picCanvas = new PictureBox();


        #region Include in Private Field


        /// <summary>
        /// The automatic animate
        /// </summary>
        private bool autoAnimate = true;


        #endregion

        #region Include in Public Properties        
        /// <summary>
        /// Gets or sets a value indicating whether automatically animate the control.
        /// </summary>
        /// <value><c>true</c> if automatic animate; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get { return autoAnimate; }
            set
            {
                autoAnimate = value;

                if (value == true)
                {
                    tmr.Enabled = true;
                }

                else
                {
                    tmr.Enabled = false;
                }

                Invalidate();
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            theta += dtheta;
            DrawCurve();
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitHypotrochoidAnimated" /> class.
        /// </summary>
        public ZeroitHypotrochoidAnimated()
        {

            Controls.Add(picCanvas);
            picCanvas.Width = width + width + width + width + width + width + width;
            picCanvas.Height = width + width + width + width + width + width + width;
            picCanvas.Location = new Point(-2 * width, -2 * width);


            #region AutoAnimate
            //if (DesignMode)
            //{
            //    tmr.Tick += Timer_Tick;
            //    if (AutoAnimate)
            //    {
            //        tmr.Interval = 100;
            //        tmr.Start();
            //    }
            //}



            if (AutoAnimate)
            {
                tmr.Enabled = true;
                tmr.Interval = 100;
                tmr.Start();
            }

            tmr.Tick += Timer_Tick;

            #endregion
        }


        #region Private Methods
        /// <summary>
        /// Draws the curve.
        /// </summary>
        private void DrawCurve()
        {
            int A = width;
            int B = sides;
            int C = circles;
            int iter = iterations;

            //wid = Width;
            //hgt = Height;
            int wid = picCanvas.ClientSize.Width;
            int hgt = picCanvas.ClientSize.Height;
            cx = wid / 2;
            cy = hgt / 2;

            points = new List<PointF>();
            points.Add(new PointF(cx + A - B + C, cy));
            theta = 0;
            dtheta = (float)(Math.PI * 2 / iter);

            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw the outer circle.
                gr.DrawEllipse(Pens.Blue, cx - A, cy - A, 2 * A, 2 * A);

                // Draw the inner circle.
                int r = A - B;
                float cx1 = (float)(cx + r * Math.Cos(theta));
                float cy1 = (float)(cy + r * Math.Sin(theta));
                gr.DrawEllipse(Pens.Blue, cx1 - B, cy1 - B, 2 * B, 2 * B);

                // Add the next point.
                PointF new_point = new PointF(
                    (float)(cx + X(theta, A, B, C)),
                    (float)(cy + Y(theta, A, B, C)));
                points.Add(new_point);

                // Draw the line.
                gr.DrawLine(Pens.Blue, new PointF(cx1, cy1), new_point);

                // Draw the points.
                if (points.Count > 1) gr.DrawLines(Pens.Red, points.ToArray());
            }

            picCanvas.Image = bm;

            if (theta > max_t) tmr.Enabled = false;
        }

        // The parametric function X(t).
        /// <summary>
        /// xes the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="A">a.</param>
        /// <param name="B">The b.</param>
        /// <param name="C">The c.</param>
        /// <returns>System.Double.</returns>
        private double X(double t, double A, double B, double C)
        {
            return (A - B) * Math.Cos(t) + C * Math.Cos(t * (A - B) / B);
        }

        // The parametric function Y(t).
        /// <summary>
        /// ies the specified t.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="A">a.</param>
        /// <param name="B">The b.</param>
        /// <param name="C">The c.</param>
        /// <returns>System.Double.</returns>
        private double Y(double t, double A, double B, double C)
        {
            return (A - B) * Math.Sin(t) - C * Math.Sin(t * (A - B) / B);
        }

        // Use Euclid's algorithm to calculate the
        // greatest common divisor (GCD) of two numbers.
        /// <summary>
        /// GCDs the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>System.Int64.</returns>
        private long GCD(long a, long b)
        {
            // Make a >= b.
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a < b)
            {
                long tmp = a;
                a = b;
                b = tmp;
            }

            // Pull out remainders.
            for (;;)
            {
                long remainder = a % b;
                if (remainder == 0) return b;
                a = b;
                b = remainder;
            };
        }

        // Return the least common multiple
        // (LCM) of two numbers.
        /// <summary>
        /// LCMs the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>System.Int64.</returns>
        private long LCM(long a, long b)
        {
            return a * b / GCD(a, b);
        }
        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //DrawCurve();
        }
        #endregion


    }
    #endregion
}
