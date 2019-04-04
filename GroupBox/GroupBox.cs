// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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

    #region ZeroitGroupBox    
    /// <summary>
    /// A class collection for rendering a groupbox.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ThemeContainerControl" />
    [Designer(typeof(ZeroitGroupBoxDesigner))]
    public class ZeroitGroupBox : ThemeContainerControl
    {
        #region Variables
        /// <summary>
        /// The checked
        /// </summary>
        private bool _Checked;
        /// <summary>
        /// The x
        /// </summary>
        private int X;
        /// <summary>
        /// The y
        /// </summary>
        private int y;

        /// <summary>
        /// The header color
        /// </summary>
        private Color headerColor = Color.FromArgb(231, 231, 231);
        /// <summary>
        /// The header border color
        /// </summary>
        private Color headerBorderColor = Color.FromArgb(237, 237, 237);
        /// <summary>
        /// The border drop1
        /// </summary>
        private Color borderDrop1 = Color.FromArgb(214, 214, 214);
        /// <summary>
        /// The border drop2
        /// </summary>
        private Color borderDrop2 = Color.FromArgb(214, 214, 214);

        /// <summary>
        /// The type font
        /// </summary>
        private Font typeFont = new Font("Tahoma", 10);

        /// <summary>
        /// The opened size
        /// </summary>
        private Size _OpenedSize;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the color of the header.
        /// </summary>
        /// <value>The color of the header.</value>
        public Color HeaderColor
        {
            get { return headerColor; }
            set
            {
                headerColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the header border.
        /// </summary>
        /// <value>The color of the header border.</value>
        public Color HeaderBorderColor
        {
            get { return headerBorderColor; }
            set
            {
                headerBorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border drop.
        /// </summary>
        /// <value>The border drop1.</value>
        public Color BorderDrop1
        {
            get { return borderDrop1; }
            set
            {
                borderDrop1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border drop.
        /// </summary>
        /// <value>The border drop2.</value>
        public Color BorderDrop2
        {
            get { return borderDrop2; }
            set
            {
                borderDrop2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font TypeFont
        {
            get { return typeFont; }
            set
            {
                typeFont = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitGroupBox" /> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size when opened.
        /// </summary>
        /// <value>The size of the open.</value>
        public Size OpenSize
        {
            get { return _OpenedSize; }
            set
            {
                _OpenedSize = value;
                Invalidate();
            }
        }

        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }

        #endregion


        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGroupBox" /> class.
        /// </summary>
        public ZeroitGroupBox()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;

            //MouseDown += changeCheck;
            Resize += meResize;
            AllowTransparent();
            Size = new Size(90, 30);
            MinimumSize = new Size(5, 30);
            _Checked = true;
        }
        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Paints the hook.
        /// </summary>
        public override void PaintHook()
        {

            //this.ForeColor = Color.FromArgb(40, 40, 40);
            if (_Checked == true)
            {
                G.SmoothingMode = smoothing;
                //G.Clear(Color.FromArgb(245, 245, 245));
                G.FillRectangle(new SolidBrush(headerColor), new Rectangle(0, 0, Width, 30));
                G.DrawLine(new Pen(headerBorderColor), 1, 1, Width - 2, 1);
                G.DrawRectangle(new Pen(borderDrop1), 0, 0, Width - 1, Height - 1);
                G.DrawRectangle(new Pen(borderDrop2), 0, 0, Width - 1, 30);
                this.Size = _OpenedSize;
                G.DrawString("t", new Font("Marlett", 12), new SolidBrush(this.ForeColor), Width - 25, 5);
            }



            else
            {
                G.SmoothingMode = smoothing;
                //G.Clear(Color.FromArgb(245, 245, 245));
                G.FillRectangle(new SolidBrush(headerColor), new Rectangle(0, 0, Width, 30));
                G.DrawLine(new Pen(headerBorderColor), 1, 1, Width - 2, 1);
                G.DrawRectangle(new Pen(borderDrop1), 0, 0, Width - 1, Height - 1);
                G.DrawRectangle(new Pen(borderDrop2), 0, 0, Width - 1, 30);
                this.Size = new Size(Width, 30);
                G.DrawString("u", new Font("Marlett", 12), new SolidBrush(this.ForeColor), Width - 25, 5);
            }
            G.DrawString(Text, typeFont, new SolidBrush(this.ForeColor), 7, 6);
        }

        /// <summary>
        /// Mes the resize.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void meResize(object sender, System.EventArgs e)
        {
            if (_Checked == true)
            {
                _OpenedSize = this.Size;
            }
            else
            {
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            y = e.Y;
            Invalidate();
        }

        /// <summary>
        /// Changes the check.
        /// </summary>
        public void changeCheck()
        {

            if (X >= Width - 22)
            {
                if (y <= 30)
                {
                    switch (Checked)
                    {
                        case true:
                            Checked = false;
                            break;
                        case false:
                            Checked = true;
                            break;
                    }
                }
            }
        } 
        #endregion

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitGroupBoxDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitGroupBoxDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitGroupBoxSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitGroupBoxSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitGroupBoxSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitGroupBox colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGroupBoxSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitGroupBoxSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitGroupBox;

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
        /// Gets or sets the color of the header.
        /// </summary>
        /// <value>The color of the header.</value>
        public Color HeaderColor
        {
            get
            {
                return colUserControl.HeaderColor;
            }
            set
            {
                GetPropertyByName("HeaderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the header border.
        /// </summary>
        /// <value>The color of the header border.</value>
        public Color HeaderBorderColor
        {
            get
            {
                return colUserControl.HeaderBorderColor;
            }
            set
            {
                GetPropertyByName("HeaderBorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border drop1.
        /// </summary>
        /// <value>The border drop1.</value>
        public Color BorderDrop1
        {
            get
            {
                return colUserControl.BorderDrop1;
            }
            set
            {
                GetPropertyByName("BorderDrop1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border drop2.
        /// </summary>
        /// <value>The border drop2.</value>
        public Color BorderDrop2
        {
            get
            {
                return colUserControl.BorderDrop2;
            }
            set
            {
                GetPropertyByName("BorderDrop2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type font.
        /// </summary>
        /// <value>The type font.</value>
        public Font TypeFont
        {
            get
            {
                return colUserControl.TypeFont;
            }
            set
            {
                GetPropertyByName("TypeFont").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitGroupBoxSmartTagActionList"/> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked
        {
            get
            {
                return colUserControl.Checked;
            }
            set
            {
                GetPropertyByName("Checked").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the open.
        /// </summary>
        /// <value>The size of the open.</value>
        public Size OpenSize
        {
            get
            {
                return colUserControl.OpenSize;
            }
            set
            {
                GetPropertyByName("OpenSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get
            {
                return colUserControl.Smoothing;
            }
            set
            {
                GetPropertyByName("Smoothing").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("HeaderColor",
                                 "HeaderColor", "Appearance",
                                 "Sets the header color."));

            items.Add(new DesignerActionPropertyItem("HeaderBorderColor",
                                 "Header Border Color", "Appearance",
                                 "Sets the header top border color."));

            items.Add(new DesignerActionPropertyItem("BorderDrop1",
                                 "Border Drop1", "Appearance",
                                 "Sets the main border color."));

            items.Add(new DesignerActionPropertyItem("BorderDrop2",
                                 "Border Drop2", "Appearance",
                                 "Sets the header bottom color."));

            items.Add(new DesignerActionPropertyItem("TypeFont",
                                 "Type Font", "Appearance",
                                 "Sets the Font for the header text."));

            items.Add(new DesignerActionPropertyItem("Checked",
                                 "Checked", "Appearance",
                                 "Set to drop the control to see the tools."));

            items.Add(new DesignerActionPropertyItem("Smoothing",
                                 "Smoothing", "Appearance",
                                 "Sets the smoothing mode."));

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
