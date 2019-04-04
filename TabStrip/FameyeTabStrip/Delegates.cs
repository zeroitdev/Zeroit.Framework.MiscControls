// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="Delegates.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
