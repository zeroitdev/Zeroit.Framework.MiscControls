// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Colors.cs" company="Zeroit Dev Technologies">
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
    /// Class Colors.
    /// </summary>
    [Serializable]
    public class Colors
    {
        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the selected fore.
        /// </summary>
        /// <value>The color of the selected fore.</value>
        public Color SelectedForeColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the selected back.
        /// </summary>
        /// <value>The color of the selected back.</value>
        public Color SelectedBackColor { get; set; }
        /// <summary>
        /// Gets or sets the selected back color2.
        /// </summary>
        /// <value>The selected back color2.</value>
        public Color SelectedBackColor2 { get; set; }
        /// <summary>
        /// Gets or sets the color of the highlighting.
        /// </summary>
        /// <value>The color of the highlighting.</value>
        public Color HighlightingColor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Colors"/> class.
        /// </summary>
        public Colors()
        {
            ForeColor = Color.Black;
            BackColor = Color.White;
            SelectedForeColor = Color.Black;
            SelectedBackColor = Color.Orange;
            SelectedBackColor2 = Color.White;
            HighlightingColor = Color.Orange;
        }
    }
}
