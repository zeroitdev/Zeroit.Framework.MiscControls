// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviButtonRenderer.cs" company="Zeroit Dev Technologies">
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
    /// This class contains drawing functionality for an button
    /// </summary>
    public abstract class NaviButtonRenderer
   {
        #region Fields
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviButtonRenderer class
        /// </summary>
        public NaviButtonRenderer()
      {
      }

        #endregion

        #region Properties
        #endregion

        #region Methods

        /// <summary>
        /// Draws the background gradients of an Button
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        /// <param name="state">The state.</param>
        /// <param name="inputState">State of the input.</param>
        public abstract void DrawBackground(Graphics g, Rectangle bounds, ControlState state, InputState inputState);

        /// <summary>
        /// Draws text on a graphics canvas
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the text</param>
        /// <param name="font">The font of the text</param>
        /// <param name="text">The text to draw</param>
        /// <param name="rightToLeft">Rigth to left or left to right layout</param>
        public abstract void DrawText(Graphics g, Rectangle bounds, Font font, string text, bool rightToLeft);

        /// <summary>
        /// Draws an image on the canvas at a given location
        /// </summary>
        /// <param name="g">The graphics canvas to draw on</param>
        /// <param name="location">The location of the image</param>
        /// <param name="image">The image</param>
        public abstract void DrawImage(Graphics g, Point location, Image image);

        /// <summary>
        /// Draws the surface of the options button
        /// </summary>
        /// <param name="g">The graphics canvas to draw on</param>
        /// <param name="bounds">The bounds of the text</param>
        public abstract void DrawOptionsTriangle(Graphics g, Rectangle bounds);

        /// <summary>
        /// Draws the surface of the Collapse button
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        /// <param name="inputState">The input state of the control</param>
        /// <param name="rightToLeft">Right to left or left to right</param>
        /// <param name="collapsed">The bar is collasped or not</param>
        public abstract void DrawCollapseButton(Graphics g, Rectangle bounds, InputState inputState, bool rightToLeft,
         bool collapsed);
      
      #endregion

      #region Overrides

      #endregion

      #region Event Handling
      #endregion
   }
}
