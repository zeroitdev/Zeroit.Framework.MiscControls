// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PopupClosedEventArgs.cs" company="Zeroit Dev Technologies">
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
    /// Contains event information for a <see cref="PopupClosed" /> event.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class PopupClosedEventArgs : EventArgs
   {
        /// <summary>
        /// The popup form.
        /// </summary>
        private System.Windows.Forms.Form popup = null;

        /// <summary>
        /// Gets the popup form which is being closed.
        /// </summary>
        /// <value>The popup.</value>
        public System.Windows.Forms.Form Popup
      {
         get { return popup; }
      }

        /// <summary>
        /// Constructs a new instance of this class for the specified
        /// popup form.
        /// </summary>
        /// <param name="popup">Popup Form which is being closed.</param>
        public PopupClosedEventArgs(System.Windows.Forms.Form popup)
      {
         this.popup = popup;
      }
   }

    /// <summary>
    /// Represents the method which responds to a <see cref="PopupClosed" /> event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="PopupClosedEventArgs"/> instance containing the event data.</param>
    public delegate void PopupClosedEventHandler(object sender, PopupClosedEventArgs e);
}
