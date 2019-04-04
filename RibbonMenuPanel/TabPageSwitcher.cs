// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabPageSwitcher.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.MiscControls
{

    /// <summary>
    /// The TabPageSwitcher works on Z-Order principals - it Dock.Fills all
    /// the contents and uses BringToFront to quickly bring a page to the front
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    [Designer(typeof(TabPageSwitcherDesigner))]       // specify a custom designer
    [System.ComponentModel.DesignerCategory("code")]  // when this file is opened, open the editor instead of the designer
    [Docking(DockingBehavior.AutoDock)]               // when this control is dropped onto the form, try to Dock.Fill
    [ToolboxItem(false)]                              // dont show this control in the toolbox, it will be added by the TabStripToolBoxItem
    public class TabPageSwitcher : ContainerControl {
        /// <summary>
        /// The selected tab strip page
        /// </summary>
        private ZeroitTabStripPage selectedTabStripPage;
        /// <summary>
        /// The tab strip
        /// </summary>
        private ZeroitTabStrip tabStrip;

        /// <summary>
        /// Initializes a new instance of the <see cref="TabPageSwitcher"/> class.
        /// </summary>
        public TabPageSwitcher() {
            ResetBackColor();
        }

        /// <summary>
        /// specify the default size for the control
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize {
            get {
                return new Size(60,60);
            }
        }


        /// <summary>
        /// specify a default padding to give a border around the control
        /// </summary>
        /// <value>The default padding.</value>
        protected override Padding DefaultPadding {
            get {
                return new Padding(4, 0, 4, 2);
            }
        }

        /// <summary>
        /// Expose a Load event
        /// </summary>
        public event EventHandler Load;


        /// <summary>
        /// The associated TabStrip
        /// </summary>
        /// <value>The tab strip.</value>
        public ZeroitTabStrip TabStrip {
            get {
               return tabStrip;
            }
            set {
                tabStrip = value;
            }
        }

        /// <summary>
        /// Specify the selected TabStripPage.
        /// </summary>
        /// <value>The selected tab strip page.</value>
        public ZeroitTabStripPage SelectedTabStripPage {
            get { return selectedTabStripPage; }
            set {
                if (selectedTabStripPage != value) {
                    
                    selectedTabStripPage = value;
                   
                    if (selectedTabStripPage != null) {
                        if (!Controls.Contains(value)) {
                            Controls.Add(selectedTabStripPage);
                            
                        }
                        else {
                            selectedTabStripPage.BringToFront();
                            
                        }
                    }

                  
                }
                
            }
        }

        /// <summary>
        /// Occurs when the selected tab has changed
        /// </summary>
        public event EventHandler SelectedTabStripPageChanged;


        /// <summary>
        /// Handle the OnHandleCreated event to fire the Load event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            if (!RecreatingHandle) {
                OnLoad(EventArgs.Empty);
            }
        }

        /// <summary>
        /// When the control is loaded, if we dont have a SelectedTabStripPage, look for one to activate.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnLoad(EventArgs e) {
            if (this.Load != null) {
                Load(this, e);
            }

            if (!DesignMode) {

                this.TabStrip.SelectedTab = (Tab) this.TabStrip.Items[0];
                ((Tab)this.TabStrip.Items[0]).b_active = true;
                
            }
        }


        /// <summary>
        /// Override OnControlAdded, all controls added to this control should become Dock.Fill.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs" /> that contains the event data.</param>
        protected override void OnControlAdded(ControlEventArgs e) {
            e.Control.Dock = DockStyle.Fill;
            base.OnControlAdded(e);
        }

        /// <summary>
        /// occurs when the selected tab has changed
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnSelectedTabStripPageChanged(EventArgs e) {
            if (SelectedTabStripPageChanged != null) {
                SelectedTabStripPageChanged(this, EventArgs.Empty);
                
            }
        }

        #region DesignerSerialization Friendliness
        /// <summary>
        /// Shoulds the color of the serialize back.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ShouldSerializeBackColor() {
            return this.BackColor != Color.FromArgb(191, 219, 255);
        }
        /// <summary>
        /// Resets the <see cref="P:System.Windows.Forms.Control.BackColor" /> property to its default value.
        /// </summary>
        public override void ResetBackColor() {
            this.BackColor = Color.FromArgb(191, 219, 255);
        }
        #endregion


       
    }
}
