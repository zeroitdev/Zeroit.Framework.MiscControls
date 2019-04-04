// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="ExpandCollapsePanelActionList.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// DesignerActionList-derived class defines smart tag entries and resultant actions.
    /// <remarks>http://msdn.microsoft.com/en-us/library/ms171829.aspx</remarks>
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitPiperExCollapsePanelActionList : System.ComponentModel.Design.DesignerActionList
    {
        /// <summary>
        /// The panel
        /// </summary>
        private ZeroitPiperExCollapsePanel panel;

        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;

        //The constructor associates the control  
        //with the smart tag list. 
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPiperExCollapsePanelActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitPiperExCollapsePanelActionList(IComponent component)
            : base(component)
        {
            this.panel = component as ZeroitPiperExCollapsePanel;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc =
                GetService(typeof(DesignerActionUIService))
                as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of  
        // GetProperties enables undo and menu updates to work properly. 
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="ArgumentException">Matching ExpandCollapsePanel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(panel)[propName];
            if (null == prop)
                throw new ArgumentException(
                    "Matching ExpandCollapsePanel property not found!",
                    propName);
            else
                return prop;
        }

        // Properties that are targets of DesignerActionPropertyItem entries. 
        /// <summary>
        /// Gets or sets a value indicating whether this instance is expanded.
        /// </summary>
        /// <value><c>true</c> if this instance is expanded; otherwise, <c>false</c>.</value>
        public bool IsExpanded
        {
            get
            {
                return panel.IsExpanded;
            }
            set
            {
                GetPropertyByName("IsExpanded").SetValue(panel, value);

                // Refresh the list. 
                //this.designerActionUISvc.Refresh(this.Component);
            }
        }

        /// <summary>
        /// Gets or sets the button style.
        /// </summary>
        /// <value>The button style.</value>
        public ZeroitPiperExCollapseButton.ExpandButtonStyle ButtonStyle
        {
            get
            {
                return panel.ButtonStyle;
            }
            set
            {
                GetPropertyByName("ButtonStyle").SetValue(panel, value);

                // Refresh the list. 
                //this.designerActionUISvc.Refresh(this.Component);
            }
        }

        /// <summary>
        /// Gets or sets the size of the button.
        /// </summary>
        /// <value>The size of the button.</value>
        public ZeroitPiperExCollapseButton.ExpandButtonSize ButtonSize
        {
            get
            {
                return panel.ButtonSize;
            }
            set
            {
                GetPropertyByName("ButtonSize").SetValue(panel, value);

                // Refresh the list. 
                //this.designerActionUISvc.Refresh(this.Component);
            }
        }


        // Implementation of this abstract method creates smart tag   
        // items, associates their targets, and collects into list. 
        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));
            //items.Add(new DesignerActionHeaderItem("Information"));

            //Boolean property for locking color selections.
            items.Add(new DesignerActionPropertyItem("IsExpanded",
                                                     "IsExpanded", "Appearance",
                                                     "Expand/collapse the panel."));
            items.Add(new DesignerActionPropertyItem("ButtonStyle",
                                                     "ButtonStyle", "Appearance",
                                                     "Visual style of the expand-collapse button."));
            items.Add(new DesignerActionPropertyItem("ButtonSize",
                                                     "ButtonSize", "Appearance",
                                                     "Size preset of the expand-collapse button."));

            return items;
        }
    }
}