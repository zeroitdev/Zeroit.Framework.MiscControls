// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviBarRenderer.cs" company="Zeroit Dev Technologies">
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
    /// Contains the base class for all Bar drawing classes
    /// </summary>
    public abstract class NaviBarRenderer    
   {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NaviBarRenderer"/> class.
        /// </summary>
        public NaviBarRenderer()
      {
      }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the background of the NavigationBar
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the background</param>
        /// <remarks>Its sufficient to supply the ClientRectangle property of the control</remarks>
        public abstract void DrawBackground(Graphics g, Rectangle bounds);

        /// <summary>
        /// Draws the background of the rectangle containing the small buttons on the bottom
        /// of the NavigationBar
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the small rectangle</param>
        public abstract void DrawSmallButtonRegion(Graphics g, Rectangle bounds);

        /// <summary>
        /// Draws the header region on top of the NavigationBar
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the header</param>
        public abstract void DrawHeader(Graphics g, Rectangle bounds);

        /// <summary>
        /// Draws the text of the header region
        /// </summary>
        /// <param name="g">The canvas to draw on</param>
        /// <param name="bounds">The bounds of the text</param>
        /// <param name="text">The header text to draw</param>
        /// <param name="font">The font to use to draw the text</param>
        /// <param name="rightToLeft">indicates whether it's right to left or left to right layout</param>
        public abstract void DrawHeaderText(Graphics g, Rectangle bounds, string text, Font font, bool rightToLeft);

      #endregion
   }
}
