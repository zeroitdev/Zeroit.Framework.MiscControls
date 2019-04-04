// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviGroupRenderer.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviGroupRenderer.
    /// </summary>
    public abstract class NaviGroupRenderer
   {
        #region Methods

        /// <summary>
        /// Draws the background.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        public abstract void DrawBackground(Graphics g, Rectangle bounds);

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="font">The font.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="rightToLeft">if set to <c>true</c> [right to left].</param>
        public abstract void DrawText(Graphics g, Rectangle bounds, Font font, string headerText, bool rightToLeft);

        /// <summary>
        /// Draws the header.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="state">The state.</param>
        /// <param name="expanded">if set to <c>true</c> [expanded].</param>
        /// <param name="rightToLeft">if set to <c>true</c> [right to left].</param>
        public abstract void DrawHeader(Graphics g, Rectangle bounds, InputState state, bool expanded, bool rightToLeft);

        /// <summary>
        /// Draws the hatched panel.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        public abstract void DrawHatchedPanel(Graphics g, Rectangle bounds);
      
      #endregion
   }
}
