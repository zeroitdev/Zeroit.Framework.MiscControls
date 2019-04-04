// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="CancelControlEventArgs.cs" company="Zeroit Dev Technologies">
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

using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// This class provides extra event info and is cancable
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ControlEventArgs" />
    public class CancelControlEventArgs : ControlEventArgs
   {
        /// <summary>
        /// The cancel
        /// </summary>
        private bool cancel = false;

        /// <summary>
        /// Initializes a new instance of the CancelControlEventArgs class
        /// </summary>
        /// <param name="control">The <see cref="T:System.Windows.Forms.Control" /> to store in this event.</param>
        public CancelControlEventArgs(Control control)   
         : base(control)
      {
      }

        /// <summary>
        /// Gets or sets whether this event is canceled or not
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c>.</value>
        public bool Cancel
      {
         get { return cancel; }
         set { cancel = value; }
      }
   }

    /// <summary>
    /// Delegate CancelControlEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="ControlEventArgs"/> instance containing the event data.</param>
    public delegate void CancelControlEventHandler(Control sender, ControlEventArgs e);
}