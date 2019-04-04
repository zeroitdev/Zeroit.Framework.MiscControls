// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviBandEventArgs.cs" company="Zeroit Dev Technologies">
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
    /// <summary>
    /// Delegate NaviBandEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="NaviBandEventArgs"/> instance containing the event data.</param>
    public delegate void NaviBandEventHandler(object sender, NaviBandEventArgs e);

    /// <summary>
    /// Class NaviBandEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class NaviBandEventArgs : EventArgs
   {
        #region Fields

        /// <summary>
        /// The new active band
        /// </summary>
        NaviBand newActiveBand;
        /// <summary>
        /// The cancel
        /// </summary>
        bool cancel = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviBandEventArgs class
        /// </summary>
        /// <param name="newActiveBand">The new active band.</param>
        public NaviBandEventArgs(NaviBand newActiveBand)
         : base()
      {
         this.newActiveBand = newActiveBand;
      }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the new active band
        /// </summary>
        /// <value>The new active band.</value>
        public NaviBand NewActiveBand
      {
         get { return newActiveBand; }
         set { newActiveBand = value; }
      }

        /// <summary>
        /// Gets or sets whether the event is canceled
        /// </summary>
        /// <value><c>true</c> if canceled; otherwise, <c>false</c>.</value>
        public bool Canceled
      {
         get { return cancel; }
         set { cancel = value; }
      }

      #endregion
   }
   
}
