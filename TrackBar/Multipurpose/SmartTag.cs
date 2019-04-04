// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 12-04-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="SmartTag.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Text;

namespace Zeroit.Framework.MiscControls
{

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitMultiTrackBarDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitMultiTrackBarDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitMultiTrackBarDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitMultiTrackBarSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }

        #region Zeroit Filter (Remove Properties)
        /// <summary>
        /// Remove Button and Control properties that are
        /// not supported by the <see cref="MACButton" />.
        /// </summary>
        /// <param name="Properties">The properties.</param>
        protected override void PostFilterProperties(IDictionary Properties)
        {
            //Properties.Remove("AllowDrop");
            //Properties.Remove("FlatStyle");
            //Properties.Remove("ForeColor");
            //Properties.Remove("ImageIndex");
            //Properties.Remove("ImageList");
        }
        #endregion

    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitMultiTrackBarSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    internal class ZeroitMultiTrackBarSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitMultiTrackBar colUserControl;


        /// <summary>
        /// Gets the designer action UI service.
        /// </summary>
        /// <value>The designer action UI service.</value>
        private DesignerActionUIService DesignerActionUIService
        {
            get { return GetService(typeof(DesignerActionUIService)) as DesignerActionUIService; }
        }


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMultiTrackBarSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitMultiTrackBarSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitMultiTrackBar;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="System.ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public Orientation Orientation
        {
            get
            {
                return colUserControl.Orientation;
            }
            set
            {
                GetPropertyByName("Orientation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the slider shape.
        /// </summary>
        /// <value>The slider shape.</value>
        public ZeroitMultiTrackBar.eShape SliderShape
        {
            get
            {
                return colUserControl.SliderShape;
            }
            set
            {
                GetPropertyByName("SliderShape").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the tick.
        /// </summary>
        /// <value>The type of the tick.</value>
        public ZeroitMultiTrackBar.eTickType TickType
        {
            get
            {
                return colUserControl.TickType;
            }
            set
            {
                GetPropertyByName("TickType").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the slider.
        /// </summary>
        /// <value>The size of the slider.</value>
        public Size SliderSize
        {
            get
            {
                return colUserControl.SliderSize;
            }
            set
            {
                GetPropertyByName("SliderSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color down face.
        /// </summary>
        /// <value>The color down face.</value>
        public Color ColorDownFace
        {
            get
            {
                return colUserControl.ColorDown.Face;
            }
            set
            {
                colUserControl.ColorDown.Face = value;
            }
        }

        /// <summary>
        /// Gets or sets the color down border.
        /// </summary>
        /// <value>The color down border.</value>
        public Color ColorDownBorder
        {
            get
            {
                return colUserControl.ColorDown.Border;
            }
            set
            {
                colUserControl.ColorDown.Border = value;
            }
        }

        /// <summary>
        /// Gets or sets the color down high light.
        /// </summary>
        /// <value>The color down high light.</value>
        public Color ColorDownHighLight
        {
            get
            {
                return colUserControl.ColorDown.Highlight;
            }
            set
            {
                colUserControl.ColorDown.Highlight = value;
            }
        }


        /// <summary>
        /// Gets or sets the color hover face.
        /// </summary>
        /// <value>The color hover face.</value>
        public Color ColorHoverFace
        {
            get
            {
                return colUserControl.ColorHover.Face;
            }
            set
            {
                colUserControl.ColorHover.Face = value;
            }
        }

        /// <summary>
        /// Gets or sets the color hover border.
        /// </summary>
        /// <value>The color hover border.</value>
        public Color ColorHoverBorder
        {
            get
            {
                return colUserControl.ColorHover.Border;
            }
            set
            {
                colUserControl.ColorHover.Border = value;
            }
        }

        /// <summary>
        /// Gets or sets the color hover high light.
        /// </summary>
        /// <value>The color hover high light.</value>
        public Color ColorHoverHighLight
        {
            get
            {
                return colUserControl.ColorHover.Highlight;
            }
            set
            {
                colUserControl.ColorHover.Highlight = value;
            }
        }



        /// <summary>
        /// Gets or sets the color up face.
        /// </summary>
        /// <value>The color up face.</value>
        public Color ColorUpFace
        {
            get
            {
                return colUserControl.ColorUp.Face;
            }
            set
            {
                colUserControl.ColorUp.Face = value;
            }
        }

        /// <summary>
        /// Gets or sets the color up border.
        /// </summary>
        /// <value>The color up border.</value>
        public Color ColorUpBorder
        {
            get
            {
                return colUserControl.ColorUp.Border;
            }
            set
            {
                colUserControl.ColorUp.Border = value;
            }
        }

        /// <summary>
        /// Gets or sets the color up high light.
        /// </summary>
        /// <value>The color up high light.</value>
        public Color ColorUpHighLight
        {
            get
            {
                return colUserControl.ColorUp.Highlight;
            }
            set
            {
                colUserControl.ColorUp.Highlight = value;
            }
        }


        /// <summary>
        /// Gets or sets the change small.
        /// </summary>
        /// <value>The change small.</value>
        public int ChangeSmall
        {
            get
            {
                return colUserControl.ChangeSmall;
            }
            set
            {
                GetPropertyByName("ChangeSmall").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the change large.
        /// </summary>
        /// <value>The change large.</value>
        public int ChangeLarge
        {
            get
            {
                return colUserControl.ChangeLarge;
            }
            set
            {
                GetPropertyByName("ChangeLarge").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public int MaxValue
        {
            get
            {
                return colUserControl.MaxValue;
            }
            set
            {
                GetPropertyByName("MaxValue").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        public int MinValue
        {
            get
            {
                return colUserControl.MinValue;
            }
            set
            {
                GetPropertyByName("MinValue").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Gets or sets the value box.
        /// </summary>
        /// <value>The value box.</value>
        public ZeroitMultiTrackBar.eValueBox ValueBox
        {
            get
            {
                return colUserControl.ValueBox;
            }
            set
            {
                GetPropertyByName("ValueBox").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the value box shape.
        /// </summary>
        /// <value>The value box shape.</value>
        public ZeroitMultiTrackBar.eShape ValueBoxShape
        {
            get
            {
                return colUserControl.ValueBoxShape;
            }
            set
            {
                GetPropertyByName("ValueBoxShape").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the value box back.
        /// </summary>
        /// <value>The color of the value box back.</value>
        public Color ValueBoxBackColor
        {
            get
            {
                return colUserControl.ValueBoxBackColor;
            }
            set
            {
                GetPropertyByName("ValueBoxBackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the value box border.
        /// </summary>
        /// <value>The color of the value box border.</value>
        public Color ValueBoxBorderColor
        {
            get
            {
                return colUserControl.ValueBoxBorder;
            }
            set
            {
                GetPropertyByName("ValueBoxBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the value box font.
        /// </summary>
        /// <value>The color of the value box font.</value>
        public Color ValueBoxFontColor
        {
            get
            {
                return colUserControl.ValueBoxFontColor;
            }
            set
            {
                GetPropertyByName("ValueBoxFontColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the value box.
        /// </summary>
        /// <value>The size of the value box.</value>
        public Size ValueBoxSize
        {
            get
            {
                return colUserControl.ValueBoxSize;
            }
            set
            {
                GetPropertyByName("ValueBoxSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the tick.
        /// </summary>
        /// <value>The color of the tick.</value>
        public Color TickColor
        {
            get
            {
                return colUserControl.TickColor;
            }
            set
            {
                GetPropertyByName("TickColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the tick interval.
        /// </summary>
        /// <value>The tick interval.</value>
        public int TickInterval
        {
            get
            {
                return colUserControl.TickInterval;
            }
            set
            {
                GetPropertyByName("TickInterval").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the tick offset.
        /// </summary>
        /// <value>The tick offset.</value>
        public int TickOffset
        {
            get
            {
                return colUserControl.TickOffset;
            }
            set
            {
                GetPropertyByName("TickOffset").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the tick thickness.
        /// </summary>
        /// <value>The tick thickness.</value>
        public float TickThickness
        {
            get
            {
                return colUserControl.TickThickness;
            }
            set
            {
                GetPropertyByName("TickThickness").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the tick.
        /// </summary>
        /// <value>The width of the tick.</value>
        public int TickWidth
        {
            get
            {
                return colUserControl.TickWidth;
            }
            set
            {
                GetPropertyByName("TickWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                return colUserControl.Value;
            }
            set
            {
                GetPropertyByName("Value").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of up down.
        /// </summary>
        /// <value>The width of up down.</value>
        public int UpDownWidth
        {
            get
            {
                return colUserControl.UpDownWidth;
            }
            set
            {
                GetPropertyByName("UpDownWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [snap to value].
        /// </summary>
        /// <value><c>true</c> if [snap to value]; otherwise, <c>false</c>.</value>
        public bool SnapToValue
        {
            get
            {
                return colUserControl.SnapToValue;
            }
            set
            {
                GetPropertyByName("SnapToValue").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [jump to mouse].
        /// </summary>
        /// <value><c>true</c> if [jump to mouse]; otherwise, <c>false</c>.</value>
        public bool JumpToMouse
        {
            get
            {
                return colUserControl.JumpToMouse;
            }
            set
            {
                GetPropertyByName("JumpToMouse").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [label show].
        /// </summary>
        /// <value><c>true</c> if [label show]; otherwise, <c>false</c>.</value>
        public bool LabelShow
        {
            get
            {
                return colUserControl.LabelShow;
            }
            set
            {
                GetPropertyByName("LabelShow").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [up down show].
        /// </summary>
        /// <value><c>true</c> if [up down show]; otherwise, <c>false</c>.</value>
        public bool UpDownShow
        {
            get
            {
                return colUserControl.UpDownShow;
            }
            set
            {
                GetPropertyByName("UpDownShow").SetValue(colUserControl, value);
            }
        }





        #endregion

        #region DesignerActionItemCollection

        #region Template Methods
        //internal void RefreshComponent()
        //{
        //    if (DesignerActionUIService != null)
        //        DesignerActionUIService.Refresh(colUserControl);
        //}


        //protected virtual void Export()
        //{
        //    var editor = new System.Windows.Forms.Form();
        //    editor.ShowDialog();
        //}

        //protected virtual void Import()
        //{
        //    var editor = new System.Windows.Forms.Form();
        //    editor.ShowDialog();
        //}

        //protected virtual void ShowBorders()
        //{
        //    colUserControl.ShowBorders = !colUserControl.ShowBorders;
        //    colUserControl.Invalidate();
        //    RefreshComponent();
        //}


        //protected virtual void AddButton()
        //{

        //    var item = "Added";
        //    colUserControl.Items.Add(item);
        //    colUserControl.Invalidate();
        //    RefreshComponent();
        //}

        //protected virtual void ClearButtons()
        //{
        //    colUserControl.Items.Clear();
        //    colUserControl.Invalidate();
        //    RefreshComponent();
        //}

        //protected virtual void DeleteItem()
        //{
        //    colUserControl.Items.Remove("Added");
        //    colUserControl.Invalidate();
        //    RefreshComponent();
        //}


        #endregion

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            #region Add Private Methods

            //items.Add(new DesignerActionHeaderItem("Template"));

            //items.Add(new DesignerActionMethodItem(this, "Export",
            //                     "Export Template", "Template",
            //                     "Selects the template to display"));

            //items.Add(new DesignerActionMethodItem(this, "Import",
            //                     "Import Template", "Template", true)); //Alternative Method



            //items.Add(new DesignerActionHeaderItem("Visuals"));

            //if (!colUserControl.ShowBorders)
            //    items.Add(new DesignerActionMethodItem(this, "ShowBorders", "Show Borders", "Visuals", true));
            //else
            //    items.Add(new DesignerActionMethodItem(this, "ShowBorders", "Hide Borders", "Visuals", true));

            ////List or Collections
            //items.Add(new DesignerActionHeaderItem("Collection"));
            //if (colUserControl.Items.Count > 0)
            //    items.Add(new DesignerActionMethodItem(this, "ClearButtons", "Clear Buttons", "Collection", true));
            //items.Add(new DesignerActionMethodItem(this, "AddButton", "Add Button", "Collection", true));
            //if (colUserControl.Items.Count > 0)
            //    items.Add(new DesignerActionMethodItem(this, "DeleteButton", "Delete Button", "Collection", true));



            #endregion

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));


            items.Add(new DesignerActionPropertyItem("SliderShape",
                "Slider Shape", "Appearance",
                "Sets the slider shape."));

            items.Add(new DesignerActionPropertyItem("Orientation",
                "Orientation", "Appearance",
                "Sets the orientation."));

            items.Add(new DesignerActionPropertyItem("SliderSize",
                "Slider Size", "Appearance",
                "Sets the slider size."));

            items.Add(new DesignerActionPropertyItem("ColorDownFace",
                "Knob Pressed Color", "Appearance",
                "Sets the knob color when pressed ."));

            items.Add(new DesignerActionPropertyItem("ColorUpFace",
                "Knob Released Color", "Appearance",
                "Sets the knob color when released."));

            items.Add(new DesignerActionPropertyItem("ColorHoverFace",
                "Knob Hover Color", "Appearance",
                "Sets the knob color when hovered."));

            items.Add(new DesignerActionPropertyItem("ChangeSmall",
                "Small Change", "Appearance",
                "Sets the small change value."));

            items.Add(new DesignerActionPropertyItem("ChangeLarge",
                "Large Change", "Appearance",
                "Sets the large change value."));

            items.Add(new DesignerActionPropertyItem("MaxValue",
                "Maximum", "Appearance",
                "Sets the maximum value."));

            items.Add(new DesignerActionPropertyItem("MinValue",
                "Minimum", "Appearance",
                "Sets the minimum value."));

            items.Add(new DesignerActionPropertyItem("UpDownWidth",
                "Arrow Width", "Appearance",
                "Sets the arrow width."));



            items.Add(new DesignerActionHeaderItem("Behaviour"));

            items.Add(new DesignerActionPropertyItem("SnapToValue",
                "Snap To Value", "Behaviour",
                "Set to immediately snap to a value on mouse click."));

            items.Add(new DesignerActionPropertyItem("JumpToMouse",
                "Jump To Mouse", "Behaviour",
                "Set to allow the knob jump to the location of the mouse."));

            items.Add(new DesignerActionPropertyItem("LabelShow",
                "Show Numbers", "Behaviour",
                "Set to show the numbers ."));

            items.Add(new DesignerActionPropertyItem("UpDownShow",
                "Show Arrows", "Behaviour",
                "Set to show the arrows."));
            
            items.Add(new DesignerActionHeaderItem("Ticks"));

            items.Add(new DesignerActionPropertyItem("TickType",
                "Tick Type", "Ticks",
                "Sets the tick type."));

            items.Add(new DesignerActionPropertyItem("TickColor",
                "Tick Color", "Ticks",
                "Sets the tip color."));

            items.Add(new DesignerActionPropertyItem("TickInterval",
                "Tick Interval", "Ticks",
                "Sets the tick interval."));

            items.Add(new DesignerActionPropertyItem("TickOffset",
                "Tick Offset", "Ticks",
                "Sets the tick offset."));

            items.Add(new DesignerActionPropertyItem("TickThickness",
                "Tick Thickness", "Ticks",
                "Sets the tick thickness."));

            items.Add(new DesignerActionPropertyItem("TickWidth",
                "Tick Width", "Ticks",
                "Sets the tick width."));


            items.Add(new DesignerActionHeaderItem("ValueBox"));

            items.Add(new DesignerActionPropertyItem("ValueBox",
                "Location", "ValueBox",
                "Sets the value box location."));

            items.Add(new DesignerActionPropertyItem("ValueBoxShape",
                "Shape", "ValueBox",
                "Sets the value box shape."));

            items.Add(new DesignerActionPropertyItem("ValueBoxBackColor",
                "Back Color", "ValueBox",
                "Sets the value box background color."));

            items.Add(new DesignerActionPropertyItem("ValueBoxBorderColor",
                "Border", "ValueBox",
                "Sets the value box border color."));

            //items.Add(new DesignerActionPropertyItem("ValueBoxFontColor",
            //    "Font Color", "ValueBox",
            //    "Sets the value box font color."));

            items.Add(new DesignerActionPropertyItem("ValueBoxSize",
                "Size", "ValueBox",
                "Sets the value box size."));




            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion


}