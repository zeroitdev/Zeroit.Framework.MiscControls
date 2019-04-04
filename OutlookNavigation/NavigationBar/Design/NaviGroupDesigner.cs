// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviGroupDesigner.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviGroupDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ParentControlDesigner" />
    internal class NaviGroupDesigner : ParentControlDesigner
   {
        #region Fields

        /// <summary>
        /// The change service
        /// </summary>
        IComponentChangeService changeService = null;
        /// <summary>
        /// The selection service
        /// </summary>
        ISelectionService selectionService = null;
        /// <summary>
        /// The m designing control
        /// </summary>
        ZeroitNaviGroup m_designingControl;

        #endregion

        #region Static

        /// <summary>
        /// Loes the word.
        /// </summary>
        /// <param name="dwValue">The dw value.</param>
        /// <returns>System.Int32.</returns>
        public static int LoWord(int dwValue)
      {
         return dwValue & 0xFFFF;
      }

        /// <summary>
        /// His the word.
        /// </summary>
        /// <param name="dwValue">The dw value.</param>
        /// <returns>System.Int32.</returns>
        public static int HiWord(int dwValue)
      {
         return (dwValue >> 16) & 0xFFFF;
      }

        #endregion

        #region Constructor
        #endregion

        #region Properties
        #endregion

        #region Methods

        /// <summary>
        /// Checks the header click.
        /// </summary>
        /// <param name="location">The location.</param>
        private void CheckHeaderClick(Point location)
      {
         if (m_designingControl.HeaderRegion.IsVisible(location))
         {
            if (selectionService.PrimarySelection == m_designingControl)
               SetControlProperty("Expanded", !m_designingControl.Expanded);
         }
      }

        /// <summary>
        /// Initializes the services.
        /// </summary>
        private void InitializeServices()
      {
         if (changeService == null)
         {
            this.changeService =
               GetService(typeof(IComponentChangeService)) as IComponentChangeService;
         }
         if (selectionService == null)
         {
            this.selectionService =
               GetService(typeof(ISelectionService)) as ISelectionService;
         }
      }

        /// <summary>
        /// Sets the control property.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <param name="value">The value.</param>
        private void SetControlProperty(string propName, object value)
      {
         PropertyDescriptor propDesc =
            TypeDescriptor.GetProperties(m_designingControl)[propName];

         if (changeService != null)
         {
            // Raise event that we are about to change
            this.changeService.OnComponentChanging(m_designingControl, propDesc);
         }

         // Change to desired value
         object oldValue = propDesc.GetValue(m_designingControl);
         propDesc.SetValue(m_designingControl, value);

         if (changeService != null)
         {
            // Raise event that the component has been changed
            this.changeService.OnComponentChanged(m_designingControl, propDesc, oldValue, value);
         }
      }
        #endregion

        #region Overrides

        /// <summary>
        /// Processes Windows messages and optionally routes them to the control.
        /// </summary>
        /// <param name="m">The <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
      {
         if (m.HWnd == Control.Handle)
         {
            switch (m.Msg)
            {
               case 0x202: //WM_LBUTTONUP
                  CheckHeaderClick(new Point(LoWord((int)m.LParam), HiWord((int)m.LParam)));
                  break;
               default:
                  break;
            }
         }
         base.WndProc(ref m);
      }

        /// <summary>
        /// Initializes the designer with the specified component.
        /// </summary>
        /// <param name="component">The <see cref="T:System.ComponentModel.IComponent" /> to associate with the designer.</param>
        public override void Initialize(System.ComponentModel.IComponent component)
      {
         base.Initialize(component);
         if (component is ZeroitNaviGroup)
         {
            m_designingControl = (ZeroitNaviGroup)component;
         }
         InitializeServices();
      }
      #endregion

      #region Event Handling

      #endregion
   }
}
