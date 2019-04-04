// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviBandCollection.cs" company="Zeroit Dev Technologies">
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
    /// This class represents a collection of Navigation Bands
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ChildControlCollection" />
    public class NaviBandCollection : ChildControlCollection
   {
        #region Fields
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviBandCollection class
        /// </summary>
        public NaviBandCollection()
         : base()
      {
      }

        #endregion

        #region Properties
        #endregion

        #region Methods

        /// <summary>
        /// Gets or sets a NaviBand at a certain location
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The item if found</returns>
        public NaviBand this[int index]
      {
         get { return ((NaviBand)List[index]); }
         set
         {
            List[index] = value;
         }
      }

        /// <summary>
        /// Adds a new NaviBand the the collection
        /// </summary>
        /// <param name="value">The new NaviBand to add</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullExceptions">Raised when the band argument is null</exception>
        public void Add(NaviBand value)
      {
         if (value == null)
            throw new ArgumentNullException();

         // We need this to be able to reset the ordering of the bands
         value.OriginalOrder = base.List.Add(value);
      }

        /// <summary>
        /// Adds a new NaviBand the the collection without notifying parent
        /// </summary>
        /// <param name="value">The new NaviBand to add</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullExceptions">Raised when the band argument is null</exception>
        internal void SilentAdd(NaviBand value)
      {
         if (value == null)
            throw new ArgumentNullException();
         try
         {
            base.notify = false;
            // We need this to be able to reset the ordering of the bands
            value.OriginalOrder = base.List.Add(value);
         }
         finally
         {
            base.notify = true;
         }
      }

        /// <summary>
        /// Removes a band from the collection of bands
        /// </summary>
        /// <param name="band">The band to remove</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullExceptions">Raised when the band argument is null</exception>
        internal void Remove(NaviBand band)
      {
         if (band == null)
            throw new ArgumentNullException();
         base.List.Remove(band);
      }

        /// <summary>
        /// Determines whether the list contains a specific value
        /// </summary>
        /// <param name="band">The value</param>
        /// <returns>Returns true if the list contains the item; false otherwise</returns>
        public bool Contains(NaviBand band)
      {
         return base.List.Contains(band);
      }

      #endregion

      #region Overrides
      #endregion

      #region Event Handling
      #endregion
   }
}