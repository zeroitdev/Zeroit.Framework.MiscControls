// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ZeroitLabelLink.cs" company="Zeroit Dev Technologies">
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
    #region Link Label    
    /// <summary>
    /// A class collection for rendering a link label.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.LinkLabel" />
    [Designer(typeof(ZeroitLabelLinkDesigner))]
    public class ZeroitLabelLink : LinkLabel
    {
        #region Variables

        /// <summary>
        /// The linkbehaviour
        /// </summary>
        private LinkBehavior linkbehaviour = LinkBehavior.NeverUnderline;
        /// <summary>
        /// The link color
        /// </summary>
        private Color linkColor = Color.FromArgb(51, 153, 225);
        /// <summary>
        /// The active link color
        /// </summary>
        private Color activeLinkColor = Color.FromArgb(0, 101, 202);
        /// <summary>
        /// The visited link color
        /// </summary>
        private Color visitedLinkColor = Color.FromArgb(0, 101, 202);
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the behaviour.
        /// </summary>
        /// <value>The behaviour.</value>
        public LinkBehavior Behaviour
        {
            get { return linkbehaviour; }
            set
            {
                linkbehaviour = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the link.
        /// </summary>
        /// <value>The color link.</value>
        public Color ColorLink
        {
            get { return linkColor; }
            set
            {
                linkColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the active link.
        /// </summary>
        /// <value>The color of the active link.</value>
        public Color ColorActiveLink
        {
            get { return activeLinkColor; }
            set
            {
                activeLinkColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the visited link.
        /// </summary>
        /// <value>The color of the visited link.</value>
        public Color ColorVisitedLink
        {
            get { return visitedLinkColor; }
            set
            {
                visitedLinkColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control is automatically resized to display its entire contents.
        /// </summary>
        /// <value><c>true</c> if [automatic size]; otherwise, <c>false</c>.</value>
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }

            set
            {
                base.AutoSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the text displayed by the <see cref="T:System.Windows.Forms.LinkLabel" />.
        /// </summary>
        /// <value>The text.</value>
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLabelLink" /> class.
        /// </summary>
        public ZeroitLabelLink()
        {

        }

        #region Methods and Overrides

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.OnPaint(System.Windows.Forms.PaintEventArgs)" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Font = new Font("Segoe UI", 8, FontStyle.Regular);
            BackColor = Color.Transparent;
            LinkColor = linkColor;
            ActiveLinkColor = activeLinkColor;
            VisitedLinkColor = visitedLinkColor;
            LinkBehavior = linkbehaviour;
        }

        #endregion

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitLabelLinkDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitLabelLinkDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitLabelLinkSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitLabelLinkSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitLabelLinkSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitLabelLink colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLabelLinkSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitLabelLinkSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitLabelLink;

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
        /// Gets or sets the behaviour.
        /// </summary>
        /// <value>The behaviour.</value>
        public LinkBehavior Behaviour
        {
            get
            {
                return colUserControl.Behaviour;
            }
            set
            {
                GetPropertyByName("Behaviour").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color link.
        /// </summary>
        /// <value>The color link.</value>
        public Color ColorLink
        {
            get
            {
                return colUserControl.ColorLink;
            }
            set
            {
                GetPropertyByName("ColorLink").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get
            {
                return colUserControl.Font;
            }
            set
            {
                GetPropertyByName("Font").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color active link.
        /// </summary>
        /// <value>The color active link.</value>
        public Color ColorActiveLink
        {
            get
            {
                return colUserControl.ColorActiveLink;
            }
            set
            {
                GetPropertyByName("ColorActiveLink").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color visited link.
        /// </summary>
        /// <value>The color visited link.</value>
        public Color ColorVisitedLink
        {
            get
            {
                return colUserControl.ColorVisitedLink;
            }
            set
            {
                GetPropertyByName("ColorVisitedLink").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic size].
        /// </summary>
        /// <value><c>true</c> if [automatic size]; otherwise, <c>false</c>.</value>
        public bool AutoSize
        {
            get
            {
                return colUserControl.AutoSize;
            }
            set
            {
                GetPropertyByName("AutoSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                return colUserControl.Text;
            }
            set
            {
                GetPropertyByName("Text").SetValue(colUserControl, value);
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


            items.Add(new DesignerActionPropertyItem("AutoSize",
                                 "Auto Size", "Appearance",
                                 "Set to automatically resize the control."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("Behaviour",
                                 "Behaviour", "Appearance",
                                 "Sets the behaviour of the link."));

            items.Add(new DesignerActionPropertyItem("ColorLink",
                                 "Color Link", "Appearance",
                                 "Sets the color of the link when inactive."));

            items.Add(new DesignerActionPropertyItem("ColorActiveLink",
                                 "Color Active Link", "Appearance",
                                 "Sets the color of the link when active."));

            items.Add(new DesignerActionPropertyItem("ColorVisitedLink",
                                 "ColorVisitedLink", "Appearance",
                                 "Sets the color of the link when visited."));

            items.Add(new DesignerActionPropertyItem("Text",
                                 "Text", "Appearance",
                                 "Sets the text of the control."));

            items.Add(new DesignerActionPropertyItem("Font",
                                 "Font", "Appearance",
                                 "Sets the Font of the link."));

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
