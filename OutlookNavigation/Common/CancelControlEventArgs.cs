// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="CancelControlEventArgs.cs" company="Zeroit Dev Technologies">
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