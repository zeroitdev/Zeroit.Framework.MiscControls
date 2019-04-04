// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviButtonCollection.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
