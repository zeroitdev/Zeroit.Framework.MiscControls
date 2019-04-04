// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="Delegates.cs" company="Zeroit Dev Technologies">
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
    #region TabStripItemClosingEventArgs

    /// <summary>
    /// Class TabStripItemClosingEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class TabStripItemClosingEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabStripItemClosingEventArgs"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public TabStripItemClosingEventArgs(ZeroitFameyeTabStripItem item)
        {
            _item = item;
        }

        /// <summary>
        /// The cancel
        /// </summary>
        private bool _cancel = false;
        /// <summary>
        /// The item
        /// </summary>
        private ZeroitFameyeTabStripItem _item;

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>The item.</value>
        public ZeroitFameyeTabStripItem Item
        {
            get { return _item; }
            set { _item = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TabStripItemClosingEventArgs"/> is cancel.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c>.</value>
        public bool Cancel
        {
            get { return _cancel; }
            set { _cancel = value; }
        }

    }

    #endregion

    #region TabStripItemChangedEventArgs

    /// <summary>
    /// Class TabStripItemChangedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class TabStripItemChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The itm
        /// </summary>
        ZeroitFameyeTabStripItem itm;
        /// <summary>
        /// The change type
        /// </summary>
        FATabStripItemChangeTypes changeType;

        /// <summary>
        /// Initializes a new instance of the <see cref="TabStripItemChangedEventArgs"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="type">The type.</param>
        public TabStripItemChangedEventArgs(ZeroitFameyeTabStripItem item, FATabStripItemChangeTypes type)
        {
            changeType = type;
            itm = item;
        }

        /// <summary>
        /// Gets the type of the change.
        /// </summary>
        /// <value>The type of the change.</value>
        public FATabStripItemChangeTypes ChangeType
        {
            get { return changeType; }
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <value>The item.</value>
        public ZeroitFameyeTabStripItem Item
        {
            get { return itm; }
        }
    }

    #endregion

    /// <summary>
    /// Delegate TabStripItemChangedHandler
    /// </summary>
    /// <param name="e">The <see cref="TabStripItemChangedEventArgs"/> instance containing the event data.</param>
    public delegate void TabStripItemChangedHandler(TabStripItemChangedEventArgs e);
    /// <summary>
    /// Delegate TabStripItemClosingHandler
    /// </summary>
    /// <param name="e">The <see cref="TabStripItemClosingEventArgs"/> instance containing the event data.</param>
    public delegate void TabStripItemClosingHandler(TabStripItemClosingEventArgs e);

}
