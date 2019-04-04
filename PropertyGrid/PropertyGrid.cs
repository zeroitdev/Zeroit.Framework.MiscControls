// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PropertyGrid.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region PropertyGrid    
    /// <summary>
    /// A class collection for rendering property grid.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.PropertyGrid" />
    [Designer(typeof(ZeroitPropertyGridDesigner))]
    public class ZeroitPropertyGrid : PropertyGrid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPropertyGrid" /> class.
        /// </summary>
        public ZeroitPropertyGrid()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            
        }

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitPropertyGridDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitPropertyGridDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitPropertyGridSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitPropertyGridSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitPropertyGridSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitPropertyGrid colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPropertyGridSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitPropertyGridSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitPropertyGrid;

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
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the category splitter.
        /// </summary>
        /// <value>The color of the category splitter.</value>
        public Color CategorySplitterColor
        {
            get { return colUserControl.CategorySplitterColor; }
            set
            {
                GetPropertyByName("CategorySplitterColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the category fore.
        /// </summary>
        /// <value>The color of the category fore.</value>
        public Color CategoryForeColor
        {
            get { return colUserControl.CategoryForeColor; }
            set
            {
                GetPropertyByName("CategoryForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the commands active link.
        /// </summary>
        /// <value>The color of the commands active link.</value>
        public Color CommandsActiveLinkColor
        {
            get { return colUserControl.CommandsActiveLinkColor; }
            set
            {
                GetPropertyByName("CommandsActiveLinkColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the commands back.
        /// </summary>
        /// <value>The color of the commands back.</value>
        public Color CommandsBackColor
        {
            get { return colUserControl.CommandsBackColor; }
            set
            {
                GetPropertyByName("CommandsBackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the commands border.
        /// </summary>
        /// <value>The color of the commands border.</value>
        public Color CommandsBorderColor
        {
            get { return colUserControl.CommandsBorderColor; }
            set
            {
                GetPropertyByName("CommandsBorderColor").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Gets or sets the color of the commands disabled link.
        /// </summary>
        /// <value>The color of the commands disabled link.</value>
        public Color CommandsDisabledLinkColor
        {
            get { return colUserControl.CommandsDisabledLinkColor; }
            set
            {
                GetPropertyByName("CommandsDisabledLinkColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the commands fore.
        /// </summary>
        /// <value>The color of the commands fore.</value>
        public Color CommandsForeColor
        {
            get { return colUserControl.CommandsForeColor; }
            set
            {
                GetPropertyByName("CommandsForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the commands link.
        /// </summary>
        /// <value>The color of the commands link.</value>
        public Color CommandsLinkColor
        {
            get { return colUserControl.CommandsLinkColor; }
            set
            {
                GetPropertyByName("CommandsLinkColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the help back.
        /// </summary>
        /// <value>The color of the help back.</value>
        public Color HelpBackColor
        {
            get { return colUserControl.HelpBackColor; }
            set
            {
                GetPropertyByName("HelpBackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the help border.
        /// </summary>
        /// <value>The color of the help border.</value>
        public Color HelpBorderColor
        {
            get { return colUserControl.HelpBorderColor; }
            set
            {
                GetPropertyByName("HelpBorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the help fore.
        /// </summary>
        /// <value>The color of the help fore.</value>
        public Color HelpForeColor
        {
            get { return colUserControl.HelpForeColor; }
            set
            {
                GetPropertyByName("HelpForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        public Color LineColor
        {
            get { return colUserControl.LineColor; }
            set
            {
                GetPropertyByName("LineColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the selected item with focus back.
        /// </summary>
        /// <value>The color of the selected item with focus back.</value>
        public Color SelectedItemWithFocusBackColor
        {
            get { return colUserControl.SelectedItemWithFocusBackColor; }
            set
            {
                GetPropertyByName("SelectedItemWithFocusBackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the selected item with focus fore.
        /// </summary>
        /// <value>The color of the selected item with focus fore.</value>
        public Color SelectedItemWithFocusForeColor
        {
            get { return colUserControl.SelectedItemWithFocusForeColor; }
            set
            {
                GetPropertyByName("SelectedItemWithFocusForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the view back.
        /// </summary>
        /// <value>The color of the view back.</value>
        public Color ViewBackColor
        {
            get { return colUserControl.ViewBackColor; }
            set
            {
                GetPropertyByName("ViewBackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the view border.
        /// </summary>
        /// <value>The color of the view border.</value>
        public Color ViewBorderColor
        {
            get { return colUserControl.ViewBorderColor; }
            set
            {
                GetPropertyByName("ViewBorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the view fore.
        /// </summary>
        /// <value>The color of the view fore.</value>
        public Color ViewForeColor
        {
            get { return colUserControl.ViewForeColor; }
            set
            {
                GetPropertyByName("ViewForeColor").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("CategorySplitterColor",
                                 "Category SplitterColor", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("CategoryForeColor",
                                 "Category ForeColor", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("CommandsActiveLinkColor",
                                 "Commands Active Link Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("CommandsBackColor",
                                 "Commands BackColor", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("CommandsBorderColor",
                                 "Commands Border Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("CommandsDisabledLinkColor",
                                 "Commands Disabled Link Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("HelpBackColor",
                                 "Help Back Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("HelpBorderColor",
                                 "Help Border Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("HelpForeColor",
                                 "Help ForeColor", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("LineColor",
                                 "Line Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SelectedItemWithFocusBackColor",
                                 "Selected Item With Focus BackColor", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SelectedItemWithFocusForeColor",
                                 "Selected Item With Focus ForeColor", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("ViewBackColor",
                                 "View BackColor", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("ViewBorderColor",
                                 "View BorderColor", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("ViewForeColor",
                                 "View ForeColor", "Appearance",
                                 "Type few characters to filter Cities."));


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

    #endregion
}
