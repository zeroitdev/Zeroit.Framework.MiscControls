// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PopupCancelEventArgs.cs" company="Zeroit Dev Technologies">
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
