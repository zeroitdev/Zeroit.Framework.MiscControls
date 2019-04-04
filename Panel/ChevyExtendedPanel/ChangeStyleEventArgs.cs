// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ChangeStyleEventArgs.cs" company="Zeroit Dev Technologies">
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
    #region ChangeStyleEventArgs

    /// <summary>
    /// Class used to send the data to the event raised as a consequence of the "expanding/collapsing" button being hit
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ChangeStyleEventArgs : EventArgs
    {
        #region Members
        /// <summary>
        /// Old direction
        /// </summary>
        private DirectionStyle oldStyle;
        /// <summary>
        /// New direction
        /// </summary>
        private DirectionStyle newStyle;
        #endregion

        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeStyleEventArgs"/> class.
        /// </summary>
        public ChangeStyleEventArgs()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeStyleEventArgs"/> class.
        /// </summary>
        /// <param name="oldStyle">The old style.</param>
        /// <param name="newStyle">The new style.</param>
        public ChangeStyleEventArgs(DirectionStyle oldStyle, DirectionStyle newStyle)
        {
            this.oldStyle = oldStyle;
            this.newStyle = newStyle;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the old.
        /// </summary>
        /// <value>The old.</value>
        public DirectionStyle Old
        {
            get
            {
                return oldStyle;
            }
            set
            {
                oldStyle = value;
            }
        }

        /// <summary>
        /// Gets or sets the new.
        /// </summary>
        /// <value>The new.</value>
        public DirectionStyle New
        {
            get
            {
                return newStyle;
            }

            set
            {
                newStyle = value;
            }
        }
        #endregion

    }

    #endregion
}
