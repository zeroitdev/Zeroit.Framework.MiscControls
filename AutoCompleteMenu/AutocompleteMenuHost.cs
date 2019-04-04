// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="AutocompleteMenuHost.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class AutocompleteMenuHost.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolStripDropDown" />
    [System.ComponentModel.ToolboxItem(false)]
    internal class AutocompleteMenuHost : ToolStripDropDown
    {
        /// <summary>
        /// The list view
        /// </summary>
        private IAutocompleteListView listView;
        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>The host.</value>
        public ToolStripControlHost Host { get; set; }
        /// <summary>
        /// The menu
        /// </summary>
        public readonly ZeroitAutocompleteMenu Menu;

        /// <summary>
        /// Gets or sets the ListView.
        /// </summary>
        /// <value>The ListView.</value>
        /// <exception cref="Exception">ListView must be derived from Control class</exception>
        public IAutocompleteListView ListView 
        { 
            get { return listView; }
            set {

                if(listView != null)
                    (listView as Control).LostFocus -= new EventHandler(ListView_LostFocus);

                if (value == null)
                    listView = new AutocompleteListView();
                else
                {
                    if (!(value is Control))
                        throw new Exception("ListView must be derived from Control class");

                    listView = value;
                }

                Host = new ToolStripControlHost(ListView as Control);
                Host.Margin = new Padding(2, 2, 2, 2);
                Host.Padding = Padding.Empty;
                Host.AutoSize = false;
                Host.AutoToolTip = false;

                (ListView as Control).MaximumSize = Menu.MaximumSize;
                (ListView as Control).Size = Menu.MaximumSize;
                (ListView as Control).LostFocus += new EventHandler(ListView_LostFocus);

                CalcSize();
                base.Items.Clear();
                base.Items.Add(Host);
                (ListView as Control).Parent = this;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteMenuHost"/> class.
        /// </summary>
        /// <param name="menu">The menu.</param>
        public AutocompleteMenuHost(ZeroitAutocompleteMenu menu)
        {
            AutoClose = false;
            AutoSize = false;
            Margin = Padding.Empty;
            Padding = Padding.Empty;

            Menu = menu;
            ListView = new AutocompleteListView();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event for the <see cref="T:System.Windows.Forms.ToolStrip" /> background.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(listView.Colors.BackColor))
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
        }

        /// <summary>
        /// Calculates the size.
        /// </summary>
        internal void CalcSize()
        {
            Host.Size = (ListView as Control).Size;
            Size = new System.Drawing.Size((ListView as Control).Size.Width + 4, (ListView as Control).Size.Height + 4);
        }

        /// <summary>
        /// Gets or sets the right to left.
        /// </summary>
        /// <value>The right to left.</value>
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
                (ListView as Control).RightToLeft = value;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if(!(ListView as Control).Focused)
                Close();
        }

        /// <summary>
        /// Handles the LostFocus event of the ListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void ListView_LostFocus(object sender, EventArgs e)
        {
            if (!Focused)
                Close();
        }
    }
}
