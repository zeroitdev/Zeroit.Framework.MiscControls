// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviButtonCollection.cs" company="Zeroit Dev Technologies">
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
    /// This class represents a collection of <see cref="NaviButton" /> items
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ChildControlCollection" />
    public class NaviButtonCollection : ChildControlCollection
   {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviButtonCollection class
        /// </summary>
        public NaviButtonCollection()
         : base()
      {
      }

        #endregion

        #region Methods

        /// <summary>
        /// Gets or sets a NavigationButton at a certain location
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The item if found</returns>
        public NaviButton this[int index]
      {
         get { return ((NaviButton)List[index]); }
         set { List[index] = value; }
      }

        /// <summary>
        /// Adds a new button the the collection
        /// </summary>
        /// <param name="value">The new button to add</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullExceptions">Raised when the button argument is null</exception>
        internal void Add(NaviButton value)
      {
         if (value == null)
            throw new ArgumentNullException();
         base.List.Add(value);
      }

        /// <summary>
        /// Removes an item from the list
        /// </summary>
        /// <param name="value">The button to remove</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullExceptions">Raised when the button argument is null</exception>
        internal void Remove(NaviButton value)
      {
         if (value == null)
            throw new ArgumentNullException();
         base.List.Remove(value);
      }

        /// <summary>
        /// Determines whether the list contains a specific value
        /// </summary>
        /// <param name="button">The button.</param>
        /// <returns>Returns true if the list contains the item; false otherwise</returns>
        public bool Contains(NaviButton button)
      {
         return base.List.Contains(button);
      }

      #endregion
   }
}
