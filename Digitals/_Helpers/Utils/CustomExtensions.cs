// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-27-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CustomExtensions.cs" company="Zeroit Dev Technologies">
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
using Zeroit.Framework.MiscControls.Digitals.Helpers.Drawable;

namespace Zeroit.Framework.MiscControls.Digitals.Helpers.Utils
{
    /// <summary>
    /// Class CustomExtensions.
    /// </summary>
    public static class CustomExtensions
    {
        /// <summary>
        /// Measures the display size of the string.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <returns>SizeF.</returns>
        public static SizeF MeasureDisplayStringSize(Graphics graphics, string text, Font font)
        {
            StringFormat format = StringFormat.GenericTypographic;
            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0,
                                                                          1000, 1000);
            System.Drawing.CharacterRange[] ranges = 
                                       { new System.Drawing.CharacterRange(0, 
                                                               text.Length) };
            System.Drawing.Region[] regions = new System.Drawing.Region[1];

            format.SetMeasurableCharacterRanges(ranges);

            regions = graphics.MeasureCharacterRanges(text, font, rect, format);
            rect = regions[0].GetBounds(graphics);

            format.Dispose();
            foreach (Region r in regions)
            {
                r.Dispose();
            }

            return new SizeF(rect.Right, rect.Bottom);
        }

        /// <summary>
        /// Adds the rounded rectangle.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        public static void AddRoundedRectangle(GraphicsPath path, RectangleF rect, int cornerRadius)
        {
            if (cornerRadius > 0)
            {
                path.StartFigure();
                path.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
                path.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
                path.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
                path.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);

                path.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);

                path.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
                path.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                path.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
                path.CloseFigure();
            }
            else
            {
                path.AddRectangle(rect);
            }
        }

        /// <summary>
        /// Determines whether [is flag set] [the specified me].
        /// </summary>
        /// <param name="me">Me.</param>
        /// <param name="corners">The corners.</param>
        /// <returns><c>true</c> if [is flag set] [the specified me]; otherwise, <c>false</c>.</returns>
        public static bool IsFlagSet(SegmentCorners me, SegmentCorners corners)
        {
            return (me & corners) == corners;
        }
    }
}
