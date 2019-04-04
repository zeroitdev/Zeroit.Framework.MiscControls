// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="ChildCollectionEventArgs.cs" company="Zeroit Dev Technologies">
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

using System;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// This class contains additional info about an add or remove operation
    /// For more information see <see cref="ChildControlCollection" />
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ChildCollectionEventArgs : EventArgs
   {
        #region Fields

        /// <summary>
        /// The m item
        /// </summary>
        private Object m_item;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the CollectionEventArgs class
        /// </summary>
        public ChildCollectionEventArgs()
      {
      }

        /// <summary>
        /// Initializes a new instance of the CollectionEventArgs class
        /// </summary>
        /// <param name="item">Item which changed the collection</param>
        public ChildCollectionEventArgs(object item)
      {
         m_item = item;
      }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the item which changed the collection
        /// </summary>
        /// <value>The item.</value>
        public Object Item
      {
         get { return m_item; }
         set { m_item = value; }
      }

      #endregion
   }

    /// <summary>
    /// Delegate CollectionEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="ChildCollectionEventArgs"/> instance containing the event data.</param>
    public delegate void CollectionEventHandler(object sender, ChildCollectionEventArgs e);
}
