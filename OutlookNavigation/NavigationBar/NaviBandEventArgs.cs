// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviBandEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
