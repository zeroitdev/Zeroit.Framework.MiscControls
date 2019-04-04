// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CaptionDraggingEventArgs.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls
{
    #region CaptionDraggingEventArgs

    /// <summary>
    /// Class CaptionDraggingEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class CaptionDraggingEventArgs : EventArgs
    {
        #region Members
        /// <summary>
        /// Instance of the width change
        /// </summary>
        private int width = 0;

        /// <summary>
        /// Instance of the height change
        /// </summary>
        private int height = 0;
        #endregion

        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="CaptionDraggingEventArgs"/> class.
        /// </summary>
        public CaptionDraggingEventArgs()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaptionDraggingEventArgs"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public CaptionDraggingEventArgs(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        #endregion
    }

    #endregion
}
