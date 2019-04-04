// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Hypotrochoid.cs" company="Zeroit Dev Technologies">
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
    #region Hypotrochoid    
    /// <summary>
    /// A class collection for rendering a Hypotrochoid.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitHypotrochoid : Control
    {
        #region Private Fields

        /// <summary>
        /// The width
        /// </summary>
        private int width = 80;
        /// <summary>
        /// The sides
        /// </summary>
        private int sides = 14;
        /// <summary>
        /// The circles
        /// </summary>
        private int circles = 30;
        /// <summary>
        /// The iterations
        /// </summary>
        private int iterations = 100;
        /// <summary>
        /// The color
        /// </summary>
        private Color color = Color.Black;

        /// <summary>
        /// The pic canvas
        /// </summary>
        private PictureBox picCanvas = new PictureBox();

        //private int wid = 10;

        //private int hgt = 10;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the width of the hypo.
        /// </summary>
        /// <value>The width of the hypo.</value>
        public int HypoWidth
        {
            get { return width; }
            set
            {
                width = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the hypo sides.
        /// </summary>
        /// <value>The hypo sides.</value>
        public int HypoSides
        {
            get { return sides; }
            set
            {
                sides = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the hypo circles.
        /// </summary>
        /// <value>The hypo circles.</value>
        public int HypoCircles
        {
            get { return circles; }
            set
            {
                circles = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the hypo iterations.
        /// </summary>
        /// <value>The hypo iterations.</value>
        public int HypoIterations
        {
            get { return iterations; }
            set
            {
                iterations = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the hypo.
        /// </summary>
        /// <value>The color of the hypo.</value>
        public Color HypoColor
        {
            get { return color; }
            set
            {
                color = value;
                Invalidate();
            }
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitHypotrochoid" /> class.
        /// </summary>
        public ZeroitHypotrochoid()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint  /* | ControlStyles.SupportsTransparentBackColor*/, true);
            
            Controls.Add(picCanvas);
            picCanvas.Width = width + width + width + width + width + width + width;
            picCanvas.Height = width + width + width + width + width + width + width;
            picCanvas.Location = new Point(-2 * width, -2 * width);

            //Width = picCanvas.Width;
            //Height = picCanvas.Height;

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

            int A = width;
            int B = sides;
            int C = circles;
            int iter = iterations;

            //wid = Width;
            //hgt = Height;
            int wid = picCanvas.ClientSize.Width;
            int hgt = picCanvas.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            Graphics gr = Graphics.FromImage(bm);

            gr.SmoothingMode = SmoothingMode.HighQuality;
            //gr.Clear(BackColor);

            int cx = wid / 2;
            int cy = hgt / 2;
            double t = 0;
            double dt = Math.PI / iter;
            double max_t = 2 * Math.PI * B / GCD(A, B);
            double x1 = cx + X(t, A, B, C);
            double y1 = cy + Y(t, A, B, C);
            List<PointF> points = new List<PointF>();
            points.Add(new PointF((float)x1, (float)y1));
            while (t <= max_t)
            {
                t += dt;
                x1 = cx + X(t, A, B, C);
                y1 = cy + Y(t, A, B, C);
                points.Add(new PointF((float)x1, (float)y1));
            }
            // Draw the polygon.
            gr.DrawPolygon(new Pen(color), points.ToArray());

            picCanvas.Image = bm;
        }
        #endregion

        #region Private Methods
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
            return (A - B) * Math.Cos(t) + C * Math.Cos((A - B) / B * t);
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
            return (A - B) * Math.Sin(t) - C * Math.Sin((A - B) / B * t);
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
    }

    #endregion
}
