#if false
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Design;
using System.Design;
using System.Windows.Forms.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Forms.Design;
using System.Collections.Generic;


namespace Microsoft.Samples {

    [Serializable]
    internal class TabToolboxItem : ToolboxItem {
        public TabToolboxItem() { }

        public TabToolboxItem(Type toolType)
            : base(toolType) {
        }

        private TabToolboxItem(SerializationInfo info, StreamingContext context) {
            Deserialize(info, context);
        }

        protected override IComponent[] CreateComponentsCore(IDesignerHost host) {
            IComponent[] components = base.CreateComponentsCore(host);
            
            Control parentControl = null;
            ControlDesigner parentControlDesigner = null;
            TabStrip tabStrip = null;
            IComponentChangeService changeSvc = (IComponentChangeService)host.GetService(typeof(IComponentChangeService));
                    

            // fish out the parent we're adding the TabStrip to.
            if (components.Length > 0 && components[0] is TabStrip) {
                tabStrip = components[0] as TabStrip;

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
                    MemberDescriptor controlsMember = TypeDescriptor.GetProperties(parentControlDesigner)["Controls"];
                    controlSwitcher = host.CreateComponent(typeof(TabPageSwitcher)) as TabPageSwitcher;
                    
                    if (changeSvc != null) {
                        changeSvc.OnComponentChanging(parentControl, controlsMember);                           
                        changeSvc.OnComponentChanged(parentControl, controlsMember, null, null);
                    }

                    Dictionary<string, object> propertyValues = new Dictionary<string, object>();
                    propertyValues["Location"] = new Point(tabStrip.Left, tabStrip.Bottom + 3);

                    SetProperties(controlSwitcher, propertyValues, host);
                    


                    

                }
                finally {
                    if (t != null)
                        t.Commit();
                }

                if (controlSwitcher != null) {
                    IComponent[] newComponents = new IComponent[components.Length + 1];
                    Array.Copy(components, newComponents, components.Length);
                    newComponents[newComponents.Length - 1] = controlSwitcher;
                    return newComponents;
                }

            }

            return components;
        }


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
#endif