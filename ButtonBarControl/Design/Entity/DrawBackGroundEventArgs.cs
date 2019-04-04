// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="DrawBackGroundEventArgs.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class holding information related to <see cref="ZeroitToxicButton.CustomDrawBackGround" /> event.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class DrawBackGroundEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DrawBackGroundEventArgs" /> with supplied arguments.
        /// </summary>
        /// <param name="graphics">Graphics surface where drawing has to be done.</param>
        /// <param name="bounds"><see cref="ZeroitToxicButton" /> control's boundry.</param>
        /// <param name="appearance">Appearance of current <see cref="ZeroitToxicButton" /></param>
        /// <param name="bar">Related <see cref="ZeroitToxicButton" /></param>
        public DrawBackGroundEventArgs(Graphics graphics, Rectangle bounds, AppearanceBar appearance, ZeroitToxicButton bar)
        {
            Graphics = graphics;
            Bounds = bounds;
            Appearance = appearance;
            Bar = bar;
        }

        /// <summary>
        /// Gets or sets drwaing has been done by user or not.
        /// </summary>
        /// <value><c>true</c> if handeled; otherwise, <c>false</c>.</value>
        public bool Handeled { get; set; }

        /// <summary>
        /// Gets Graphics surface where drawing has to be done.
        /// </summary>
        /// <value>The graphics.</value>
        public Graphics Graphics { get; private set; }

        /// <summary>
        /// Gets <see cref="ZeroitToxicButton" /> control's boundry.
        /// </summary>
        /// <value>The bounds.</value>
        public Rectangle Bounds { get; private set; }

        /// <summary>
        /// Gets appearance of current <see cref="ZeroitToxicButton" />
        /// </summary>
        /// <value>The appearance.</value>
        public AppearanceBar Appearance { get; private set; }

        /// <summary>
        /// Gets related <see cref="ZeroitToxicButton" />
        /// </summary>
        /// <value>The bar.</value>
        public ZeroitToxicButton Bar { get; private set; }

        /// <summary>
        /// Draw control background.
        /// </summary>
        public void DrawBackground()
        {
            PaintUtility.DrawBackground(Graphics, Bounds, Appearance.BackStyle.GetBrush(Bounds),
                                        Appearance.AppearanceBorder.CornerShape, Appearance.CornerRadius, null);
        }

        /// <summary>
        /// Draw control border.
        /// </summary>
        public void DrawBorder()
        {
            if (!Bar.ShowBorders) return;
            var rect = new Rectangle(Bounds.X, Bounds.Y, Bounds.Width - 1, Bounds.Height - 1);
            PaintUtility.DrawBorder(Graphics, rect, Appearance.AppearanceBorder.CornerShape,
                                    Appearance.AppearanceBorder.BorderVisibility,
                                    Appearance.AppearanceBorder.BorderLineStyle, Appearance.CornerRadius,
                                    Bar.Focused ? Appearance.FocusedBorder : Appearance.NormalBorder, null, null);
        }
    }
}