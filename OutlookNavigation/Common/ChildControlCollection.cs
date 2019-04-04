// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="ChildControlCollection.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region License and Copyright

/*
 
Author:  Jacob Mesu
 
Attribution-Noncommercial-Share Alike 3.0 Unported
You are free:

    * to Share — to copy, distribute and transmit the work
    * to Remix — to adapt the work

Under the following conditions:

    * Attribution — You must attribute the work and give credits to the author or Zeroit.Framework.MiscControls.Navigation.OutlookNavigation.net
    * Noncommercial — You may not use this work for commercial purposes. If you want to adapt
      this work for a commercial purpose, visit Zeroit.Framework.MiscControls.Navigation.OutlookNavigation.net and request the Attribution-Share 
      Alike 3.0 Unported license for free. 

http://creativecommons.org/licenses/by-nc-sa/3.0/

*/
#endregion

using System.Collections;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// The basic collection class with events which notifies when new items have been added or removed
    /// </summary>
    /// <seealso cref="System.Collections.CollectionBase" />
    /// <example>TODO</example>
    /// <remarks>This class can be usefull when a container class needs to now which object have been added to
    /// the collection or have been removed. This is especially usefull when you want the child controls
    /// to appear in the document outline (Visual Studio only). The child controls needs to be part of
    /// the controls collection to achieve this. You can use the events <see cref="ItemAdded" /> and
    /// <see cref="ItemRemoved" /> to add or remove the controls from the Controls collection.</remarks>
    public class ChildControlCollection : CollectionBase
   {
        #region Fields

        /// <summary>
        /// The m item added
        /// </summary>
        CollectionEventHandler m_itemAdded;
        /// <summary>
        /// The m item removed
        /// </summary>
        CollectionEventHandler m_itemRemoved;
        /// <summary>
        /// The notify
        /// </summary>
        protected bool notify = true;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ChildControlCollection class
        /// </summary>
        public ChildControlCollection()
         : base()
      {
      }

        #endregion

        #region Properties
        #endregion

        #region Methods

        /// <summary>
        /// Sorts the specified comparer.
        /// </summary>
        /// <param name="comparer">The IComparer implementation to use when comparing elements.</param>
        public virtual void Sort(IComparer comparer)      
      {
         InnerList.Sort(comparer);
      }

        #endregion

        #region Overrides

        /// <summary>
        /// Overriden. Raises the Removed event
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value" /> can be found.</param>
        /// <param name="value">The value of the element to remove from <paramref name="index" />.</param>
        protected override void OnRemoveComplete(int index, object value)
      {
         base.OnRemoveComplete(index, value);
         CollectionEventHandler handler = m_itemRemoved;
         if ((handler != null)
         && notify)
         {
            handler(this, new ChildCollectionEventArgs(value));
         }
      }

        /// <summary>
        /// Overriden. Raises the item added event
        /// </summary>
        /// <param name="index">The zero-based index at which to insert <paramref name="value" />.</param>
        /// <param name="value">The new value of the element at <paramref name="index" />.</param>
        protected override void OnInsertComplete(int index, object value)
      {
         base.OnInsertComplete(index, value);
         CollectionEventHandler handler = m_itemAdded;
         if ((handler != null)
         && notify)
         {
            handler(this, new ChildCollectionEventArgs(value));
         }
      }

        #endregion

        #region Event Handling

        /// <summary>
        /// Occurs when an item has been added to the collection
        /// </summary>
        public event CollectionEventHandler ItemAdded
      {
         add { m_itemAdded += value; }
         remove { m_itemAdded -= value; }
      }

        /// <summary>
        /// Occurs when an item has been removed from the collection
        /// </summary>
        public event CollectionEventHandler ItemRemoved
      {
         add { m_itemRemoved += value; }
         remove { m_itemRemoved -= value; }
      }

      #endregion
   }
}