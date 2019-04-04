// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PopupWindowHelperMessageFilter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************



using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A Message Loop filter which detect mouse events whilst the popup form is shown
    /// and notifies the owning <see cref="PopupWindowHelper" /> class when a mouse
    /// click outside the popup occurs.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.IMessageFilter" />
    public class PopupWindowHelperMessageFilter : IMessageFilter
   {
        /// <summary>
        /// Raised when the Popup Window is about to be cancelled.  The
        /// <see cref="PopupCancelEventArgs.Cancel" /> property can be
        /// set to <c>true</c> to prevent the form from being cancelled.
        /// </summary>
        public event PopupCancelEventHandler PopupCancel;

        /// <summary>
        /// The popup form
        /// </summary>
        private System.Windows.Forms.Form popup = null;
        /// <summary>
        /// The owning <see cref="PopupWindowHelper" /> object.
        /// </summary>
        private PopupWindowHelper owner = null;

        /// <summary>
        /// Constructs a new instance of this class and sets the owning
        /// object.
        /// </summary>
        /// <param name="owner">The <see cref="PopupWindowHelper" /> object
        /// which owns this class.</param>
        public PopupWindowHelperMessageFilter(PopupWindowHelper owner)
      {
         this.owner = owner;
      }

        /// <summary>
        /// Gets/sets the popup form which is being displayed.
        /// </summary>
        /// <value>The popup.</value>
        public System.Windows.Forms.Form Popup
      {
         get
         {
            return this.popup;
         }
         set
         {
            this.popup = value;
         }
      }

        /// <summary>
        /// Checks the message loop for mouse messages whilst the popup
        /// window is displayed.  If one is detected the position is
        /// checked to see if it is outside the form, and the owner
        /// is notified if so.
        /// </summary>
        /// <param name="m">Windows Message about to be processed by the
        /// message loop</param>
        /// <returns><c>true</c> to filter the message, <c>false</c> otherwise.
        /// This implementation always returns <c>false</c>.</returns>
        public bool PreFilterMessage(ref Message m)
      {
         if (this.popup != null)
         {
            switch (m.Msg)
            {
               case NativeMethods.WM_LBUTTONDOWN:
               case NativeMethods.WM_RBUTTONDOWN:
               case NativeMethods.WM_MBUTTONDOWN:
               case NativeMethods.WM_NCLBUTTONDOWN:
               case NativeMethods.WM_NCRBUTTONDOWN:
               case NativeMethods.WM_NCMBUTTONDOWN:
                  OnMouseDown();
                  break;
            }
         }
         return false;
      }

        /// <summary>
        /// Checks the mouse location and calls the OnCancelPopup method
        /// if the mouse is outside the popup form.
        /// </summary>
        private void OnMouseDown()
      {
         // Get the cursor location
         Point cursorPos = Cursor.Position;
         // Check if it is within the popup form
         if (!popup.Bounds.Contains(cursorPos))
         {
            // If not, then call to see if it should be closed
            OnCancelPopup(new PopupCancelEventArgs(popup, cursorPos));
         }
      }

        /// <summary>
        /// Raises the <see cref="PopupCancel" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PopupCancelEventArgs" /> associated
        /// with the cancel event.</param>
        protected virtual void OnCancelPopup(PopupCancelEventArgs e)
      {
         if (this.PopupCancel != null)
         {
            this.PopupCancel(this, e);
         }
         if (!e.Cancel)
         {
            owner.ClosePopup();
            // Clear reference for GC
            popup = null;
         }
      }
   }
}
