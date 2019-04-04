// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="LinearGradientBrush2.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Represents a replacement for the <c>System.Drawing.Drawing2D.LinearGradientBrush</c>.
    /// </summary>
    /// <remarks>There is a bug in the <c>System.Drawing.Drawing2D.LinearGradientBrush</c> where somtimes,
    /// the gradient wraps around and fills the first pixel column/row with the last color.
    /// It was explained as one-of-many off-by-one bugs in GDI+:
    /// http://stackoverflow.com/questions/5326473/weird-behavior-of-lineargradientbrush</remarks>
	public class LinearGradientBrush2
	{
        /// <summary>
        /// Constructor for a two color linear gradient.
        /// </summary>
        /// <param name="rect">Bounding rectangle of area to be filled.</param>
        /// <param name="c1">Starting color.</param>
        /// <param name="c2">Ending color.</param>
        /// <param name="mode">A <c>System.Drawing.Drawing2D.LinearGradientMode</c> enumeration value that specifies the orientation of the gradient.</param>
        public LinearGradientBrush2(Rectangle rect, Color c1, Color c2, LinearGradientMode mode)
		{
			this.mode = mode;
			gradientBrush = new LinearGradientBrush(rect, c1, c2, mode);
		}

        /// <summary>
        /// Constructor for a multi color linear gradient.
        /// </summary>
        /// <param name="rect">Bounding rectangle of area to be filled.</param>
        /// <param name="blend">A <c>System.Drawing.Drawing2D.ColorBlend</c> object containing arrays of colors and positions defining a multi color gradient.</param>
        /// <param name="mode">A <c>System.Drawing.Drawing2D.LinearGradientMode</c> enumeration value that specifies the orientation of the gradient.</param>
        /// <exception cref="ArgumentNullException">blend</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="blend" /> is null.</exception>
        public LinearGradientBrush2(Rectangle rect, ColorBlend blend, LinearGradientMode mode)
		{
			if (blend == null)
			{
				throw new ArgumentNullException("blend");
			}
			this.mode = mode;
			gradientBrush = new LinearGradientBrush(rect, blend.Colors[0], blend.Colors[blend.Colors.Length - 1], mode);
			gradientBrush.InterpolationColors = blend;
		}

        /// <summary>
        /// Dispose of brush.
        /// </summary>
		public void Dispose()
		{
			if (gradientBrush != null)
			{
				gradientBrush.Dispose();
				gradientBrush = null;
			}
		}

        /// <summary>
        /// The mode
        /// </summary>
        private LinearGradientMode mode;
        /// <summary>
        /// The gradient brush
        /// </summary>
        private LinearGradientBrush gradientBrush = null;

        /// <summary>
        /// Fill a rectangular area with the linear gradient.
        /// </summary>
        /// <param name="g">Graphics object.</param>
        /// <param name="r">Rectangle area to fill.</param>
        /// <param name="backBrush">Brush to fill the background before filling with the linear gradient.</param>
        /// <exception cref="ArgumentNullException">g</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="g" /> is null.</exception>
		public void FillRectangle(Graphics g, Rectangle r, Brush backBrush)
		{
			if (g == null)
			{
				throw new ArgumentNullException("g");
			}

			g.FillRectangle(backBrush, r);

			PixelOffsetMode oldMode = g.PixelOffsetMode;
			g.PixelOffsetMode = PixelOffsetMode.Half;
			g.FillRectangle(gradientBrush, r);
			g.PixelOffsetMode = oldMode;
		}
	}
}
