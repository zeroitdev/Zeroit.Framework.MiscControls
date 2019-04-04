// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviBarDesigner.cs" company="Zeroit Dev Technologies">
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


using System.ComponentModel;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System;
using System.Collections;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviBarDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ParentControlDesigner" />
    [ToolboxItemFilterAttribute("System.Windows.Forms", ToolboxItemFilterType.Custom)]
   internal class NaviBarDesigner : ParentControlDesigner
   {
        #region Fields

        /// <summary>
        /// The designing control
        /// </summary>
        ZeroitNaviBar designingControl;
        /// <summary>
        /// The selection service
        /// </summary>
        ISelectionService selectionService;
        /// <summary>
        /// The component change service
        /// </summary>
        IComponentChangeService componentChangeService;
        /// <summary>
        /// The host
        /// </summary>
        IDesignerHost host;

        #endregion

        #region Constructor
        #endregion

        #region Properties
        #endregion

        #region Methods

        /// <summary>
        /// Sets the value for a given property
        /// </summary>
        /// <param name="propName">The name of the property</param>
        /// <param name="value">The new value of the property</param>
        private void SetValue(string propName, object value)
      {
         PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(designingControl);
         PropertyDescriptor property = properties.Find(propName, true);
         if (property != null)
         {
            property.SetValue(designingControl, value);
         }
      }

        /// <summary>
        /// Gets the value of a given property
        /// </summary>
        /// <param name="propName">The name of the property</param>
        /// <returns>System.Object.</returns>
        private object GetValue(string propName)
      {
         PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(designingControl);
         PropertyDescriptor property = properties.Find(propName, true);
         if (property != null)
         {
            return property.GetValue(designingControl);
         }
         else
         {
            return null;
         }
      }

        /// <summary>
        /// Initializes the layout engine of the Navigation pane
        /// </summary>
        /// <exception cref="System.SystemException">Invalid value for property LayoutStyle</exception>
        private void InitializeLayout()
      {
         if (designingControl.NaviLayout != null)
         {
            host.DestroyComponent(designingControl.NaviLayout);
         }

         switch (designingControl.LayoutStyle)
         {
            case NaviLayoutStyle.Office2003Blue:
            case NaviLayoutStyle.Office2007Silver:
            case NaviLayoutStyle.Office2007Black:
            case NaviLayoutStyle.Office2007Blue:
               break;
            default:
               throw new SystemException("Invalid value for property LayoutStyle");
         }
         designingControl.Invalidate();
      }

        /// <summary>
        /// Initializes the services.
        /// </summary>
        private void InitializeServices()
      {
         selectionService = GetService(typeof(ISelectionService)) as ISelectionService;
         if (selectionService != null)
         {
            selectionService.SelectionChanged += new System.EventHandler(selectionService_SelectionChanged);
         }

         componentChangeService = GetService(typeof(IComponentChangeService))
            as IComponentChangeService;
         if (componentChangeService != null)
         {
            componentChangeService.ComponentChanged += new ComponentChangedEventHandler(componentChangeService_ComponentChanged);
         }

         host = (IDesignerHost)GetService(typeof(IDesignerHost));
      }

        /// <summary>
        /// Handles the click event.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool HandleClickEvent(int x, int y)
      {
         if (designingControl != null)
         {
            foreach (NaviBand band in designingControl.Bands)
            {
               if ((band.Button != null)
               && (band.Button.Bounds.Contains(x, y)))
               {
                  ArrayList list = new ArrayList();
                  list.Add(band);
                  if (selectionService != null)
                  {
                     selectionService.SetSelectedComponents(list);
                     return true;
                  }
               }
            }
         }
         return false;
      }

        #endregion

        #region Overrides

        /// <summary>
        /// Initializes the designer with the specified component.
        /// </summary>
        /// <param name="component">The <see cref="T:System.ComponentModel.IComponent" /> to associate with the designer.</param>
        public override void Initialize(IComponent component)
      {
         base.Initialize(component);
         designingControl = component as ZeroitNaviBar;
         InitializeServices();
      }

        /// <summary>
        /// Initializes the new component.
        /// </summary>
        /// <param name="defaultValues">A name/value dictionary of default values to apply to properties. May be null if no default values are specified.</param>
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
      {
         designingControl.BeginInit();
         base.InitializeNewComponent(defaultValues);
         InitializeLayout();

         // For some reason ISupportInitialize.EndInit is never called when creating a control
         designingControl.EndInit();
      }

        /// <summary>
        /// Gets the design-time verbs supported by the component that is associated with the designer.
        /// </summary>
        /// <value>The verbs.</value>
        public override DesignerVerbCollection Verbs
      {
         get
         {
            DesignerVerb[] verbs = new DesignerVerb[] { 
               new DesignerVerb("Add band..", 
                  new EventHandler(AddBandVerbClicked)) };
            return new DesignerVerbCollection(verbs);
         }
      }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Design.ParentControlDesigner" />, and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
      {
         base.Dispose(disposing);

         if (componentChangeService != null)
         {
            componentChangeService.ComponentChanged -= new ComponentChangedEventHandler(componentChangeService_ComponentChanged);
         }

         if (selectionService != null)
         {
            selectionService.SelectionChanged -= new System.EventHandler(selectionService_SelectionChanged);
         }
      }

        /// <summary>
        /// Processes Windows messages and optionally routes them to the control.
        /// </summary>
        /// <param name="m">The <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
      {
         switch (m.Msg)
         {
            case NativeMethods.WM_LBUTTONUP:
               if (!HandleClickEvent(NativeMethods.LoWord(m.LParam),
                  NativeMethods.HiWord(m.LParam)))
               {
                  base.WndProc(ref m);
               }
               break;
            default:
               base.WndProc(ref m);
               break;
         }
      }

        #endregion

        #region Event Handling

        /// <summary>
        /// Handles the SelectionChanged event of the selectionService control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void selectionService_SelectionChanged(object sender, System.EventArgs e)
      {
         if (selectionService.PrimarySelection is NaviBand)
         {
            designingControl.SetActiveBand(
               selectionService.PrimarySelection as NaviBand);
         }
      }

        /// <summary>
        /// Adds the band verb clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void AddBandVerbClicked(object sender, EventArgs e)
      {
         NaviBand band = host.CreateComponent(typeof(NaviBand)) as NaviBand;
         if (band != null)
         {
            designingControl.AddBand(band);
         }
      }

        /// <summary>
        /// Handles the ComponentChanged event of the componentChangeService control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ComponentChangedEventArgs"/> instance containing the event data.</param>
        void componentChangeService_ComponentChanged(object sender, ComponentChangedEventArgs e)
      {
         if (e.Component == designingControl)
         {
            if ((e.Member != null)
            && (e.Member.Name == "LayoutStyle"))
            {
               InitializeLayout();
            }
         }
      }

      #endregion
   }
}