// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ColorPicker.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ColorPicker    
    /// <summary>
    /// A class collection representing a color picker.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    /// <seealso cref="System.Windows.Forms.ColorDialog" />
    public class ZeroitColorPicker : UserControl
    {
        /// <summary>
        /// The size
        /// </summary>
        const int SIZE = 400;
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitColorPicker"/> class.
        /// </summary>
        public ZeroitColorPicker()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            
        }

        /// <summary>
        /// Draws the color picker.
        /// </summary>
        /// <returns>Image.</returns>
        private Image DrawColorPicker()
        {
            
            var img = new Bitmap(SIZE, SIZE, PixelFormat.Format32bppArgb);
            var centerX = SIZE / 2;
            var centerY = SIZE / 2;
            var innerRadius = SIZE * 5 / 12;
            var outerRadius = SIZE / 2;
            for (int y = 0; y < SIZE; y++)
            {
                for (int x = 0; x < SIZE; x++)
                {
                    Color color;
                    var distanceFromCenter = Math.Sqrt((x - centerX) * (x - centerX) + (y - centerY) * (y - centerY));
                    var angle = Math.Atan2(y - centerY, x - centerX) + Math.PI / 2;
                    if (angle < 0) angle += 2 * Math.PI;
                    var sqrt3 = Math.Sqrt(3);
                    // Outside
                    if (distanceFromCenter > outerRadius)
                    {
                        color = Color.Transparent;
                    }
                    else if (distanceFromCenter > innerRadius)
                    {
                        // Wheel
                        var hue = angle;
                        var sat = 1.0; // Could use selected saturation and value, instead of ones
                        var val = 1.0;
                        color = HSV(hue, sat, val, 1);
                    }
                    else
                    {
                        // Inside
                        var x1 = (x - centerX) * 1.0 / innerRadius;
                        var y1 = (y - centerY) * 1.0 / innerRadius;
                        if (0 * x1 + 2 * y1 > 1) color = Color.Transparent;
                        else if (sqrt3 * x1 + (-1) * y1 > 1) color = Color.Transparent;
                        else if (-sqrt3 * x1 + (-1) * y1 > 1) color = Color.Transparent;
                        else
                        {
                            // Triangle
                            var hue = 0.0; // Could use the selected hue, instead of zero
                            var sat = (1 - 2 * y1) / (sqrt3 * x1 - y1 + 2);
                            var val = (sqrt3 * x1 - y1 + 2) / 3;

                            color = HSV(hue, sat, val, 1);
                        }
                    }
                    img.SetPixel(x, y, color);
                }
            }

            return img;
        }

        /// <summary>
        /// HSVs the specified hue.
        /// </summary>
        /// <param name="hue">The hue.</param>
        /// <param name="sat">The sat.</param>
        /// <param name="val">The value.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns>Color.</returns>
        Color HSV(double hue, double sat, double val, double alpha)
        {
            var chroma = val * sat;
            var step = Math.PI / 3;
            var interm = chroma * (1 - Math.Abs((hue / step) % 2.0 - 1));
            var shift = val - chroma;
            if (hue < 1 * step) return RGB(shift + chroma, shift + interm, shift + 0, alpha);
            if (hue < 2 * step) return RGB(shift + interm, shift + chroma, shift + 0, alpha);
            if (hue < 3 * step) return RGB(shift + 0, shift + chroma, shift + interm, alpha);
            if (hue < 4 * step) return RGB(shift + 0, shift + interm, shift + chroma, alpha);
            if (hue < 5 * step) return RGB(shift + interm, shift + 0, shift + chroma, alpha);
            return RGB(shift + chroma, shift + 0, shift + interm, alpha);
        }

        /// <summary>
        /// RGBs the specified red.
        /// </summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns>Color.</returns>
        Color RGB(double red, double green, double blue, double alpha)
        {
            return Color.FromArgb(
                Math.Min(255, (int)(alpha * 256)),
                Math.Min(255, (int)(red * 256)),
                Math.Min(255, (int)(green * 256)),
                Math.Min(255, (int)(blue * 256)));
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            
            Bitmap bit = (Bitmap) DrawColorPicker();
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawImage(bit, 0, 0);

            base.OnPaint(e);

            
        }

        
    }

    #endregion
}
