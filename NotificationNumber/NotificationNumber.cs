// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NotificationNumber.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Notification Number    
    /// <summary>
    /// A class collection for rendering a notification.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitNotificationDesigner))]
    public class ZeroitNotification : Control
    {
        #region Variables

        /// <summary>
        /// The value
        /// </summary>
        private int _Value = 0;
        /// <summary>
        /// The maximum
        /// </summary>
        private int _Maximum = 99;
        /// <summary>
        /// The color background1
        /// </summary>
        private Color colorBackground1 = Color.FromArgb(197, 69, 68);
        /// <summary>
        /// The color background2
        /// </summary>
        private Color colorBackground2 = Color.FromArgb(176, 52, 52);
        /// <summary>
        /// The color border
        /// </summary>
        private Color colorBorder = Color.FromArgb(205, 70, 66);
        /// <summary>
        /// The color text
        /// </summary>
        private Color colorText = Color.FromArgb(255, 255, 253);

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color background1.</value>
        public Color ColorBackground1
        {
            get { return colorBackground1; }
            set
            {
                colorBackground1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color background2.</value>
        public Color ColorBackground2
        {
            get { return colorBackground2; }
            set
            {
                colorBackground2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color border.
        /// </summary>
        /// <value>The color border.</value>
        public Color ColorBorder
        {
            get { return colorBorder; }
            set
            {
                colorBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color text.
        /// </summary>
        /// <value>The color text.</value>
        public Color ColorText
        {
            get { return colorText; }
            set
            {
                colorText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                if (this._Value == 0)
                {
                    return 0;
                }
                return this._Value;
            }
            set
            {
                if (value > this._Maximum)
                {
                    value = this._Maximum;
                }
                this._Value = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return this._Maximum;
            }
            set
            {
                if (value < this._Value)
                {
                    this._Value = value;
                }
                this._Maximum = value;
                this.Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitNotification" /> class.
        /// </summary>
        public ZeroitNotification()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            Size = new Size(25, 25);

            Text = null;
            DoubleBuffered = true;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            new Size(Width - 30, Height - 30);
            //Height = 20;
            //Width = 20;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var _G = e.Graphics;
            string myString = _Value.ToString();

            _G.SmoothingMode = SmoothingMode.AntiAlias;

            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(Width, Height)), colorBackground1, colorBackground2, 90f);

            // Fills the body with LGB gradient
            //_G.Clear(Color.Transparent);
            _G.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(Width - 1, Height - 1)));
            // Draw border
            _G.DrawEllipse(new Pen(colorBorder), new Rectangle(new Point(0, 0), new Size(Width - 1, Height - 1)));
            _G.DrawString(myString, new Font("Segoe UI", 8, FontStyle.Bold), new SolidBrush(colorText), new Rectangle(0, 0, Width, Height), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            e.Dispose();
        }

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitNotificationDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitNotificationDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitNotificationSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitNotificationSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitNotificationSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitNotification colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitNotificationSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitNotificationSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitNotification;

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
        /// Gets or sets the color background1.
        /// </summary>
        /// <value>The color background1.</value>
        public Color ColorBackground1
        {
            get
            {
                return colUserControl.ColorBackground1;
            }
            set
            {
                GetPropertyByName("ColorBackground1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color background2.
        /// </summary>
        /// <value>The color background2.</value>
        public Color ColorBackground2
        {
            get
            {
                return colUserControl.ColorBackground2;
            }
            set
            {
                GetPropertyByName("ColorBackground2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color border.
        /// </summary>
        /// <value>The color border.</value>
        public Color ColorBorder
        {
            get
            {
                return colUserControl.ColorBorder;
            }
            set
            {
                GetPropertyByName("ColorBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color text.
        /// </summary>
        /// <value>The color text.</value>
        public Color ColorText
        {
            get
            {
                return colUserControl.ColorText;
            }
            set
            {
                GetPropertyByName("ColorText").SetValue(colUserControl, value);
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
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return colUserControl.Maximum;
            }
            set
            {
                GetPropertyByName("Maximum").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("ColorBackground1",
                                 "Color Background1", "Appearance",
                                 "Sets the background color of the control."));

            items.Add(new DesignerActionPropertyItem("ColorBackground2",
                                 "Color Background2", "Appearance",
                                 "Sets the background color of the control."));

            items.Add(new DesignerActionPropertyItem("ColorBorder",
                                 "Color Border", "Appearance",
                                 "Sets the border color of the control."));

            items.Add(new DesignerActionPropertyItem("ColorText",
                                 "Color Text", "Appearance",
                                 "Sets the color of the text."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value of the control."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value of the control."));

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
