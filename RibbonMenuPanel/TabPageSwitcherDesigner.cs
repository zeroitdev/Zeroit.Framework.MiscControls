// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabPageSwitcherDesigner.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class TabPageSwitcherDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ParentControlDesigner" />
    class TabPageSwitcherDesigner : ParentControlDesigner {

        /// <summary>
        /// The verbs
        /// </summary>
        private DesignerVerbCollection verbs;  // a collection of actions to perform (appear as links in propgrid, on designer action panel)
        /// <summary>
        /// The selection service
        /// </summary>
        private ISelectionService selectionService;  // service which lets you know when the selection changes in the designer.

        /// <summary>
        /// The TabPageSwitcher we're designing - strongly typed wrapper around Component property.
        /// </summary>
        /// <value>The control switcher.</value>
        public TabPageSwitcher ControlSwitcher  {
            get { return Component as TabPageSwitcher; }
        }

        /// <summary>
        /// Fetches the selection service from the service provider - from this we can tell what's selected and when selection changes
        /// </summary>
        /// <value>The selection service.</value>
        internal ISelectionService SelectionService {
            get {
                if (selectionService == null) {
                    selectionService = (ISelectionService)GetService(typeof(ISelectionService));
                    Debug.Assert(selectionService != null, "Failed to get Selection Service!");
                }
                return selectionService;
            }
        }

        /// <summary>
        /// List of "verbs" or actions to be used in the designer.  These typically appear on the Context Menu,
        /// links on the property grid, and as links on the designer action panel.
        /// </summary>
        /// <value>The verbs.</value>
        public override System.ComponentModel.Design.DesignerVerbCollection Verbs {
            get {
                if (verbs == null) {

                    verbs = new DesignerVerbCollection();
                    verbs.Add(new DesignerVerb(Properties.Resources.AddTabs, new EventHandler(this.OnAdd)));         
                }

                return verbs;
            }
        }

        /// <summary>
        /// when the designer disposes, we need to be careful about
        /// unhooking from service events we've subscribed to.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            if (disposing) {
                SelectionService.SelectionChanged -= new EventHandler(SelectionService_SelectionChanged);
            }
        }

        /// <summary>
        /// This is called when the designer is first loaded.
        /// Usually a good time to hook up to events.  If you want to
        /// set property defaults, InitializeNewComponent is what you
        /// want to override
        /// </summary>
        /// <param name="component">The <see cref="T:System.ComponentModel.IComponent" /> to associate with the designer.</param>
        public override void Initialize(IComponent component) {
            base.Initialize(component);
            SelectionService.SelectionChanged += new EventHandler(SelectionService_SelectionChanged);
        }

        /// <summary>
        /// Indicates whether the specified control can be a child of the control managed by this designer.
        /// </summary>
        /// <param name="control">The <see cref="T:System.Windows.Forms.Control" /> to test.</param>
        /// <returns>true if the specified control can be a child of the control managed by this designer; otherwise, false.</returns>
        public override bool CanParent(Control control) {
            return control is ZeroitTabStripPage;            
        }
        /// <summary>
        /// Method implementation for our "Add TabStripPage verb".
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eevent">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnAdd(object sender, EventArgs eevent) {

            // fetch our designer host
            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (host != null) {

                // Create a transaction so we're friendly to undo/redo and serialization
                DesignerTransaction t = null;
                try {
                    try {
                        t = host.CreateTransaction(Properties.Resources.AddTab + Component.Site.Name);
                    }
                    catch (CheckoutException ex) {
                        if (ex == CheckoutException.Canceled) {
                            return;
                        }
                        throw ex;
                    }

                    // Add a TabStripPage to the controls collection of the TabPageSwitcher
                    
                    // Notify the TabPageSwitcher that it's control collection is changing.                    
                    MemberDescriptor member = TypeDescriptor.GetProperties(ControlSwitcher)["Controls"];
                    ZeroitTabStripPage page = host.CreateComponent(typeof(ZeroitTabStripPage)) as ZeroitTabStripPage;
                    RaiseComponentChanging(member);
                   
                    // add the page to the controls collection.
                    ControlSwitcher.Controls.Add(page);

                    // set the SelectedTabStripPage to the current page so that it opens correctly
                    SetProperty("SelectedTabStripPage", page);                    
                    
                    // Raise event that we're done changing the controls property.
                    RaiseComponentChanged(member, null, null);

                    // if we have an associated TabStrip,
                    // add a matching Tab to the TabStrip.
                    if (ControlSwitcher.TabStrip != null) {

                        // add a tab to the toolstrip designer
                        MemberDescriptor itemsProp = TypeDescriptor.GetProperties(ControlSwitcher.TabStrip)["Items"];

                        Tab tab = host.CreateComponent(typeof(Tab)) as Tab;
                        RaiseComponentChanging(itemsProp);

                        ControlSwitcher.TabStrip.Items.Add(tab);
                        RaiseComponentChanged(itemsProp, null, null);
                        
                        SetProperty(tab, "DisplayStyle", ToolStripItemDisplayStyle.ImageAndText);
                        SetProperty(tab, "Text", tab.Name);
                        SetProperty(tab, "TabStripPage", page);
                        SetProperty(ControlSwitcher.TabStrip, "SelectedTab", tab);
                    }
                    
                }
                finally {
                    if (t != null)
                        t.Commit();
                }
            }
         
        }



        /// <summary>
        /// Handles the SelectionChanged event of the SelectionService control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void SelectionService_SelectionChanged(object sender, EventArgs e) {
            IList selectedComponents = (IList)SelectionService.GetSelectedComponents();
            if (selectedComponents.Count == 1) {
                Tab tab = selectedComponents[0] as Tab;
                if (tab != null) {
                    SetProperty("SelectedTabStripPage", tab.TabStripPage);
                    SetProperty(tab, "Checked", true);
                }
            }
        }
        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="propname">The propname.</param>
        /// <param name="value">The value.</param>
        private void SetProperty(object target, string propname, object value) {
            PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(target)[propname];
            if (propDescriptor != null) {
                propDescriptor.SetValue(target, value);
            }
        }

        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <param name="propname">The propname.</param>
        /// <param name="value">The value.</param>
        private void SetProperty(string propname, object value) {
            SetProperty(ControlSwitcher, propname, value);
        }
    }
}
