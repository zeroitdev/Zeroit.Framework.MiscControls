// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabStripToolboxItem.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.Serialization;
using System.Windows.Forms.Design;
using System.Collections.Generic;


namespace Zeroit.Framework.MiscControls
{


    /// <summary>
    /// This class is invoked when dragging a TabStrip off the toolbox.
    /// note that it creates two things - a TabStrip and a TabStripPageSwitcher.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.ToolboxItem" />
    [Serializable]
    internal class TabStripToolboxItem : ToolboxItem {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabStripToolboxItem"/> class.
        /// </summary>
        public TabStripToolboxItem() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TabStripToolboxItem"/> class.
        /// </summary>
        /// <param name="toolType">The type of <see cref="T:System.ComponentModel.IComponent" /> that the toolbox item creates.</param>
        public TabStripToolboxItem(Type toolType)
            : base(toolType) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TabStripToolboxItem"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        private TabStripToolboxItem(SerializationInfo info, StreamingContext context) {
            Deserialize(info, context);
        }


        /// <summary>
        /// this method is called when dragging a TabStrip off the toolbox.
        /// </summary>
        /// <param name="host">The <see cref="T:System.ComponentModel.Design.IDesignerHost" /> to host the toolbox item.</param>
        /// <returns>An array of created <see cref="T:System.ComponentModel.IComponent" /> objects.</returns>
        protected override IComponent[] CreateComponentsCore(IDesignerHost host) {
            IComponent[] components = base.CreateComponentsCore(host);
            
            Control parentControl = null;
            ControlDesigner parentControlDesigner = null;
            ZeroitTabStrip tabStrip = null;
            IComponentChangeService changeSvc = (IComponentChangeService)host.GetService(typeof(IComponentChangeService));
                    

            // fish out the parent we're adding the TabStrip to.
            if (components.Length > 0 && components[0] is ZeroitTabStrip) {
                tabStrip = components[0] as ZeroitTabStrip;

                ITreeDesigner tabStripDesigner = host.GetDesigner(tabStrip) as ITreeDesigner;
                parentControlDesigner = tabStripDesigner.Parent as ControlDesigner;
                if (parentControlDesigner != null) {
                    parentControl = parentControlDesigner.Control;
                }               
            }
           
            // Create a ControlSwitcher on the same parent.

            if (host != null) {
                TabPageSwitcher controlSwitcher = null;

                DesignerTransaction t = null;
                try {
                    try {
                        t = host.CreateTransaction("add tabswitcher");
                    }
                    catch (CheckoutException ex) {
                        if (ex == CheckoutException.Canceled) {
                            return components;
                        }
                        throw ex;
                    }

                    // create a TabPageSwitcher and add it to the same parent as the TabStrip
                    MemberDescriptor controlsMember = TypeDescriptor.GetProperties(parentControlDesigner)["Controls"];
                    controlSwitcher = host.CreateComponent(typeof(TabPageSwitcher)) as TabPageSwitcher;
                    
                    if (changeSvc != null) {
                        changeSvc.OnComponentChanging(parentControl, controlsMember);                           
                        changeSvc.OnComponentChanged(parentControl, controlsMember, null, null);
                    }

                    // specify default values for our TabStrip
                    Dictionary<string, object> propertyValues = new Dictionary<string, object>();
                    propertyValues["Location"] = new Point(tabStrip.Left, tabStrip.Bottom + 3);
                    propertyValues["TabStrip"] = tabStrip;

                    // set the property values
                    SetProperties(controlSwitcher, propertyValues, host);
                    
                }
                finally {
                    if (t != null)
                        t.Commit();
                }

                // add the TabPageSwitcher to the list of components that we've created
                if (controlSwitcher != null) {
                    IComponent[] newComponents = new IComponent[components.Length + 1];
                    Array.Copy(components, newComponents, components.Length);
                    newComponents[newComponents.Length - 1] = controlSwitcher;
                    return newComponents;
                }

            }

            return components;
        }


        /// <summary>
        /// handy helper method for setting multiple properties.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="properties">The properties.</param>
        /// <param name="host">The host.</param>
        private void SetProperties(Component component, Dictionary<string,object> properties, IDesignerHost host) {
            IComponentChangeService changeSvc = (IComponentChangeService)host.GetService(typeof(IComponentChangeService));
                      
            foreach (string propname in properties.Keys) {
                PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(component)[propname];
           
                if (changeSvc != null) {
                    changeSvc.OnComponentChanging(component, propDescriptor);
                }
                if (propDescriptor != null) {
                    propDescriptor.SetValue(component, properties[propname]);
                }
                if (changeSvc != null) {
                    changeSvc.OnComponentChanged(component, propDescriptor, null, null);
                }
            }

            
        }
    }
}
