// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PopupCancelEventArgs.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Arguments to a <see cref="PopupCancelEvent" />.  Provides a
    /// reference to the popup form that is to be closed and
    /// allows the operation to be cancelled.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class PopupCancelEventArgs : EventArgs
   {
        /// <summary>
        /// Whether to cancel the operation
        /// </summary>
        private bool cancel = false;
        /// <summary>
        /// Mouse down location
        /// </summary>
        private Point location;
        /// <summary>
        /// Popup form.
        /// </summary>
        private System.Windows.Forms.Form popup = null;

        /// <summary>
        /// Constructs a new instance of this class.
        /// </summary>
        /// <param name="popup">The popup form</param>
        /// <param name="location">The mouse location, if any, where the
        /// mouse event that would cancel the popup occured.</param>
        public PopupCancelEventArgs(System.Windows.Forms.Form popup, Point location)
      {
         this.popup = popup;
         this.location = location;
         this.cancel = false;
      }

        /// <summary>
        /// Gets the popup form
        /// </summary>
        /// <value>The popup.</value>
        public System.Windows.Forms.Form Popup
      {
         get
         {
            return this.popup;
         }
      }

        /// <summary>
        /// Gets the location that the mouse down which would cancel this
        /// popup occurred
        /// </summary>
        /// <value>The cursor location.</value>
        public Point CursorLocation
      {
         get
         {
            return this.location;
         }
      }

        /// <summary>
        /// Gets/sets whether to cancel closing the form. Set to
        /// <c>true</c> to prevent the popup from being closed.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c>.</value>
        public bool Cancel
      {
         get
         {
            return this.cancel;
         }
         set
         {
            this.cancel = value;
         }
      }
   }

    /// <summary>
    /// Represents the method which responds to a <see cref="PopupCancel" /> event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="PopupCancelEventArgs"/> instance containing the event data.</param>
    public delegate void PopupCancelEventHandler(object sender, PopupCancelEventArgs e);
}
