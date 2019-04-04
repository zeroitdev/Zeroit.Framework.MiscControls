// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="FATabStripDesigner.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitFameyeTabStripDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ParentControlDesigner" />
    public class ZeroitFameyeTabStripDesigner : ParentControlDesigner
    {
        #region Fields

        /// <summary>
        /// The change service
        /// </summary>
        IComponentChangeService changeService;

        #endregion

        #region Initialize & Dispose

        /// <summary>
        /// Initializes the designer with the specified component.
        /// </summary>
        /// <param name="component">The <see cref="T:System.ComponentModel.IComponent" /> to associate with the designer.</param>
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            
            //Design services
            changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));

            //Bind design events
            changeService.ComponentRemoving += new ComponentEventHandler(OnRemoving);

            Verbs.Add(new DesignerVerb("Add TabStrip", new EventHandler(OnAddTabStrip)));
            Verbs.Add(new DesignerVerb("Remove TabStrip", new EventHandler(OnRemoveTabStrip)));
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Design.ParentControlDesigner" />, and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            changeService.ComponentRemoving -= new ComponentEventHandler(OnRemoving);

            base.Dispose(disposing);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Handles the <see cref="E:Removing" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ComponentEventArgs"/> instance containing the event data.</param>
        private void OnRemoving(object sender, ComponentEventArgs e)
        {
            IDesignerHost host = (IDesignerHost) GetService(typeof (IDesignerHost));

            //Removing a button
            if (e.Component is ZeroitFameyeTabStripItem)
            {
                ZeroitFameyeTabStripItem itm = e.Component as ZeroitFameyeTabStripItem;
                if (Control.Items.Contains(itm))
                {
                    changeService.OnComponentChanging(Control, null);
                    Control.RemoveTab(itm);
                    changeService.OnComponentChanged(Control, null, null, null);
                    return;
                }
            }

            if (e.Component is ZeroitFameyeTabStrip)
            {
                for (int i = Control.Items.Count - 1; i >= 0; i--)
                {
                    ZeroitFameyeTabStripItem itm = Control.Items[i];
                    changeService.OnComponentChanging(Control, null);
                    Control.RemoveTab(itm);
                    host.DestroyComponent(itm);
                    changeService.OnComponentChanged(Control, null, null, null);
                }
            }
        }

        /// <summary>
        /// Handles the <see cref="E:AddTabStrip" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnAddTabStrip(object sender, EventArgs e)
        {
            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));
            DesignerTransaction transaction = host.CreateTransaction("Add TabStrip");
            ZeroitFameyeTabStripItem itm = (ZeroitFameyeTabStripItem)host.CreateComponent(typeof(ZeroitFameyeTabStripItem));
            changeService.OnComponentChanging(Control, null);
            Control.AddTab(itm);
            int indx = Control.Items.IndexOf(itm) + 1;
            itm.Title = "TabStrip Page " + indx.ToString();
            Control.SelectItem(itm);
            changeService.OnComponentChanged(Control, null, null, null);
            transaction.Commit();
        }

        /// <summary>
        /// Handles the <see cref="E:RemoveTabStrip" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnRemoveTabStrip(object sender, EventArgs e)
        {
            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));
            DesignerTransaction transaction = host.CreateTransaction("Remove Button");
            changeService.OnComponentChanging(Control, null);
            ZeroitFameyeTabStripItem itm = Control.Items[Control.Items.Count - 1];
            Control.UnSelectItem(itm);
            Control.Items.Remove(itm);
            changeService.OnComponentChanged(Control, null, null, null);
            transaction.Commit();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Check HitTest on <see cref="FATabStrip" /> control and
        /// let the user click on close and menu buttons.
        /// </summary>
        /// <param name="point">A <see cref="T:System.Drawing.Point" /> indicating the position at which the mouse was clicked, in screen coordinates.</param>
        /// <returns>true if a click at the specified point is to be handled by the control; otherwise, false.</returns>
        protected override bool GetHitTest(Point point)
        {
            HitTestResult result = Control.HitTest(point);
            if(result == HitTestResult.CloseButton || result == HitTestResult.MenuGlyph)
                return true;
            
            return false;
        }

        /// <summary>
        /// Adjusts the set of properties the component will expose through a <see cref="T:System.ComponentModel.TypeDescriptor" />.
        /// </summary>
        /// <param name="properties">An <see cref="T:System.Collections.IDictionary" /> that contains the properties for the class of the component.</param>
        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);

            properties.Remove("DockPadding");
            properties.Remove("DrawGrid");
            properties.Remove("Margin");
            properties.Remove("Padding");
            properties.Remove("BorderStyle");
            properties.Remove("ForeColor");
            properties.Remove("BackColor");
            properties.Remove("BackgroundImage");
            properties.Remove("BackgroundImageLayout");
            properties.Remove("GridSize");
            properties.Remove("ImeMode");
        }

        /// <summary>
        /// WNDs the proc.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == 0x201)
            {
                Point pt = Control.PointToClient(Cursor.Position);
                ZeroitFameyeTabStripItem itm = Control.GetTabItemByPoint(pt);
                if (itm != null)
                {
                    Control.SelectedItem = itm;
                    ArrayList selection = new ArrayList();
                    selection.Add(itm);
                    ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
                    selectionService.SetSelectedComponents(selection);
                }
            }

            base.WndProc(ref msg);
        }

        /// <summary>
        /// Gets the collection of components associated with the component managed by the designer.
        /// </summary>
        /// <value>The associated components.</value>
        public override ICollection AssociatedComponents
        {
            get
            {
                return Control.Items;
            }
        }

        /// <summary>
        /// Gets the control that the designer is designing.
        /// </summary>
        /// <value>The control.</value>
        public new virtual ZeroitFameyeTabStrip Control
        {
            get
            {
                return base.Control as ZeroitFameyeTabStrip;
            }
        }

        #endregion
    }
}
