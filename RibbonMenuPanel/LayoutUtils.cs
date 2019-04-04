// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="LayoutUtils.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    /// <summary>
    /// Handy layout helper utils.
    /// </summary>
    static class LayoutUtils {
        /// <summary>
        /// Increases the size of the rectangle by the padding
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="padding">The padding.</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle InflateRect(Rectangle rect, Padding padding) {
            rect.X -= padding.Left;
            rect.Y -= padding.Top;
            rect.Width += padding.Horizontal;
            rect.Height += padding.Vertical;
            return rect;
        }


        /// <summary>
        /// Decreases the rectangle by the amount of padding
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="padding">The padding.</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle DeflateRect(Rectangle rect, Padding padding) {
            rect.X += padding.Left;
            rect.Y += padding.Top;
            rect.Width -= padding.Horizontal;
            rect.Height -= padding.Vertical;
            return rect;
        }


        /// <summary>
        /// Given two sizes, returns the maximum width and maximum height
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>Size.</returns>
        public static Size UnionSizes(Size a, Size b) {
            return new Size(
                Math.Max(a.Width, b.Width),
                Math.Max(a.Height, b.Height));
        }
    }
}
