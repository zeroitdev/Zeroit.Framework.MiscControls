// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="HSColor.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Imaging;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Specifies the type of HS color space.
    /// </summary>
	public enum ColorSpace
	{
        /// <summary>
        /// Specifies the Hue/Saturation/Value color space.
        /// </summary>
        HSV,

        /// <summary>
        /// Specifies the Hue/Saturation/Luma color space.
        /// </summary>
        HSL
    };

    /// <summary>
    /// Represent an HSL or HSV color.
    /// The actual color space (HSL or HSV) does not need to be specified until the
    /// the value is converted to RGB.
    /// </summary>
	public class HSColor
	{
        /// <summary>
        /// Construct an HS color.
        /// </summary>
        /// <param name="hue">Hue; should be in there range [0,360) - will be silently adjusted if not.</param>
        /// <param name="sat">Saturation; must be the range [0,1].</param>
        /// <param name="val">Value or Luma; must be the range [0,1].</param>
        /// <exception cref="ArgumentException">
        /// sat - sat must be in the range [0,1]
        /// or
        /// val - val must be in the range [0,1]
        /// </exception>
        /// <exception cref="System.ArgumentException">Thrown if <paramref name="sat" /> is less than zero or greater than one, or if
        /// <paramref name="val" /> is less than zero or greater than one.</exception>
        public HSColor(double hue, double sat, double val)
		{
			if (sat < 0.0 || sat > 1.0)
			{
				throw new ArgumentException("sat", "sat must be in the range [0,1]");
			}
			if (val < 0.0 || val > 1.0)
			{
				throw new ArgumentException("val", "val must be in the range [0,1]");
			}
            Hue = FixHue(hue);
			Sat = sat;
			Val = val;
		}

        /// <summary>
        /// Hue.
        /// </summary>
		public readonly double Hue;

        /// <summary>
        /// Saturation.
        /// </summary>
        public readonly double Sat;

        /// <summary>
        /// Value or luma.
        /// </summary>
        public readonly double Val;

        /// <summary>
        /// Convert color to RGB.
        /// </summary>
        /// <param name="cs">Color space from which to convert.</param>
        /// <returns>Color value.</returns>
		public Color ToRGB(ColorSpace cs)
		{
			if (cs == ColorSpace.HSL)
			{
				return HSL2RGB(Hue, Sat, Val);
			}
			if (cs == ColorSpace.HSV)
			{
				return HSV2RGB(Hue, Sat, Val);
			}
			return Color.Empty;
		}

        /// <summary>
        /// Fixes the hue.
        /// </summary>
        /// <param name="hue">The hue.</param>
        /// <returns>System.Double.</returns>
        internal static double FixHue(double hue)
		{
            return ((hue % 360) + 360) % 360;
		}

        /// <summary>
        /// Convert HSL color to RGB.
        /// </summary>
        /// <param name="hue">Hue.</param>
        /// <param name="sat">Saturation.</param>
        /// <param name="val">Luma.</param>
        /// <returns>Color value.</returns>
		public static Color HSL2RGB(double hue, double sat, double val)
		{
			double c = (1 - Math.Abs(2 * val - 1)) * sat;
			double h = FixHue(hue) / 60;
			double x = c * (1.0 - Math.Abs(h % 2 - 1));
			double m = val - 0.5 * c;

			double r,g,b;
			
			if      (h < 1.0) { r = c; g = x; b = 0; }
			else if (h < 2.0) { r = x; g = c; b = 0; }
			else if (h < 3.0) { r = 0; g = c; b = x; }
			else if (h < 4.0) { r = 0; g = x; b = c; }
			else if (h < 5.0) { r = x; g = 0; b = c; }
			else              { r = c; g = 0; b = x; }

			return DoubleToByte(r + m, g + m, b + m);
		}

        /// <summary>
        /// Convert HSV color to RGB.
        /// </summary>
        /// <param name="hue">Hue.</param>
        /// <param name="sat">Saturation.</param>
        /// <param name="val">Value.</param>
        /// <returns>Color value.</returns>
		public static Color HSV2RGB(double hue, double sat, double val)
		{
			double c = sat * val;
			double h = FixHue(hue) / 60;
			double x = c * (1.0 - Math.Abs(h % 2 - 1));
			double m = val - c;

			double r,g,b;
			
			if      (h < 1.0) { r = c; g = x; b = 0; }
			else if (h < 2.0) { r = x; g = c; b = 0; }
			else if (h < 3.0) { r = 0; g = c; b = x; }
			else if (h < 4.0) { r = 0; g = x; b = c; }
			else if (h < 5.0) { r = x; g = 0; b = c; }
			else              { r = c; g = 0; b = x; }

			return DoubleToByte(r + m, g + m, b + m);
		}

        /// <summary>
        /// Doubles to byte.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <returns>Color.</returns>
        private static Color DoubleToByte(double r, double g, double b)
		{
			return Color.FromArgb((int)Math.Round(255 * r),
							      (int)Math.Round(255 * g),
								  (int)Math.Round(255 * b));
		}

        /// <summary>
        /// Convert RGB color to HSL color.
        /// </summary>
        /// <param name="c">Color (RGB) value.</param>
        /// <returns>HSColor value in the HSL color space.</returns>
		public static HSColor RGB2HSL(Color c)
		{
			double R = (double)c.R / 255.0;
			double G = (double)c.G / 255.0;
			double B = (double)c.B / 255.0;

			double M = Math.Max(R, Math.Max(G, B));
			double m = Math.Min(R, Math.Min(G, B));
			double C = M - m;

            double h = 0.0;
			if      (C == 0) h = 0;
			else if (M == R) h = ((G - B) / C) % 6;
			else if (M == G) h = ((B - R) / C) + 2;
			else if (M == B) h = ((R - G) / C) + 4;

			double hue = FixHue(h * 60);

			// Diff between HSL and HSV starts here

			double val = 0.5 * (M + m); // light

			double sat;
			if (C == 0)
			{
				sat = 0.0;
			}
			else
			{
				sat = Math.Min(1.0, C / (1.0 - Math.Abs(2 * val - 1)));
			}

			return new HSColor(hue, sat, val);
		}

        /// <summary>
        /// Convert RGB color to HSV color.
        /// </summary>
        /// <param name="c">Color (RGB) value.</param>
        /// <returns>HSColor value in the HSV color space.</returns>
		public static HSColor RGB2HSV(Color c)
		{
			double R = (double)c.R / 255.0;
			double G = (double)c.G / 255.0;
			double B = (double)c.B / 255.0;

			double M = Math.Max(R, Math.Max(G, B));
			double m = Math.Min(R, Math.Min(G, B));
			double C = M - m;

            double h = 0.0;
			if      (C == 0) h = 0;
			else if (M == R) h = ((G - B) / C) % 6;
			else if (M == G) h = ((B - R) / C) + 2;
			else if (M == B) h = ((R - G) / C) + 4;
			double hue = FixHue(h * 60);

			// Diff between HSL and HSV starts here

			double val = M; // light

			double sat;
			if (C == 0)
			{
				sat = 0.0;
			}
			else
			{
				sat = Math.Min(1.0, C / val);
			}
			return new HSColor(hue, sat, val);
		}

        /// <summary>
        /// Delegate HS2RGBDelegate
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <param name="sat">The sat.</param>
        /// <param name="val">The value.</param>
        /// <returns>Color.</returns>
        private delegate Color HS2RGBDelegate(double angle, double sat, double val);

        /// <summary>
        /// Generate a HSV or HSL color circle.
        /// </summary>
        /// <param name="size">Size of returned bitmap.</param>
        /// <param name="innerRadius">Radius of inner edge of color circle.</param>
        /// <param name="outerRadius">Radius of outer edge of color circle.</param>
        /// <param name="binning">Binning factor.</param>
        /// <param name="innerColor">Solid color of area within the inner radius.</param>
        /// <param name="outerColor">Solid color of area outside the outer radius.</param>
        /// <param name="colorSpace">Color space (HSV or HSL).</param>
        /// <param name="val">Value if color space is HSV, or luma if color space is HSL.</param>
        /// <returns>Bitmap of the color circle.</returns>
        /// <exception cref="ArgumentException">
        /// size
        /// or
        /// innerRadius
        /// or
        /// innerRadius must be less than outerRadius
        /// or
        /// binning
        /// or
        /// val
        /// </exception>
        /// <exception cref="System.ArgumentException">Thrown if either member (<c>Width</c> or <c>Height</c>) of <paramref name="size" /> is less than one, or if
        /// <paramref name="innerRadius" /> is less than zero, or if
        /// <paramref name="innerRadius" /> is greater than <paramref name="outerRadius" />, of if
        /// <paramref name="binning" /> is less than 1 or greater than <paramref name="outerRadius" />, or if
        /// <paramref name="val" /> is less than zero or greater the one.</exception>
		public static Bitmap GenerateCircle(Size size,
											int innerRadius,
											int outerRadius,
											int binning,
											Color innerColor,
											Color outerColor,
											ColorSpace colorSpace,
											double val) // V in HSV, L in HSL
		{
			if (size.Width < 1 || size.Height < 1)
			{
				throw new ArgumentException("size");
			}
			if (innerRadius < 0)
			{
				throw new ArgumentException("innerRadius");
			}
			if (outerRadius <= innerRadius)
			{
				throw new ArgumentException("innerRadius must be less than outerRadius");
			}
			if (binning < 1 || binning > outerRadius)
			{
				throw new ArgumentException("binning");
			}
			if (val < 0.0 || val > 1.0)
			{
				throw new ArgumentException("val");
			}
		
			Bitmap bm = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb);
			Graphics g = Graphics.FromImage(bm);

			Brush br = new SolidBrush(outerColor);
			g.FillRectangle(br, new Rectangle(0, 0, size.Width, size.Height));
			br.Dispose();

			Brush innerBr = new SolidBrush(innerColor);

			double rad2angle = 180.0 / Math.PI;
			double bin2 = (double)binning / 2.0f;
			double diffRadius = outerRadius - innerRadius;

			HS2RGBDelegate calc;
            if (colorSpace == ColorSpace.HSV)
            {
                calc = HSColor.HSV2RGB;
            }
            else
            {
                calc = HSColor.HSL2RGB;
            }

			int xmid = size.Width / 2 - outerRadius;
			int ymid = size.Height / 2 - outerRadius;
			int count = outerRadius / binning;

			for (int xc = 0; xc < count; xc++)
			{
				double x = (double)xc * binning + bin2;
				double x2 = x * x;

				int x14 = xmid + outerRadius + xc * binning;
				int x23 = xmid + outerRadius - (xc + 1) * binning;

				for (int yc = 0; yc < count; yc++)
				{
					double y = (double)yc * binning + bin2;
					double r = Math.Sqrt(x2 + y*y);

					if (r > outerRadius)
					{
						continue;
					}

					int y12 = ymid + outerRadius - (yc + 1)* binning;
					int y34 = ymid + outerRadius + yc * binning;

					if (r < innerRadius)
					{
						g.FillRectangle(innerBr, x14, y12, binning, binning);
						g.FillRectangle(innerBr, x23, y12, binning, binning);
						g.FillRectangle(innerBr, x23, y34, binning, binning);
						g.FillRectangle(innerBr, x14, y34, binning, binning);
					}
					else
					{
						double a1 = Math.Asin(y / r) * rad2angle;
						double a2 = 180.0 - a1;
						double a3 = 180.0 + a1;
						double a4 = 360.0 - a1;

						// Scale rr so that it is 0.0 at innerRadius and 1.0 at outerRadius
						double rr = (r - innerRadius) / diffRadius;

						Brush b1 = new SolidBrush(calc(a1, rr, val));
						Brush b2 = new SolidBrush(calc(a2, rr, val));
						Brush b3 = new SolidBrush(calc(a3, rr, val));
						Brush b4 = new SolidBrush(calc(a4, rr, val));

						g.FillRectangle(b1, x14, y12, binning, binning);
						g.FillRectangle(b2, x23, y12, binning, binning);
						g.FillRectangle(b3, x23, y34, binning, binning);
						g.FillRectangle(b4, x14, y34, binning, binning);

						b1.Dispose();
						b2.Dispose();
						b3.Dispose();
						b4.Dispose();
					}
				}
			}

			innerBr.Dispose();

            return bm;
		}
	}
}
