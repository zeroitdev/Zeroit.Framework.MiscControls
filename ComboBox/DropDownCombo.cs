// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="DropDownCombo.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitDropDownCombo    
    /// <summary>
    /// A class collection for rendering a combo box.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ComboBox" />
    [Designer(typeof(ZeroitComboDropDownDesigner))]
    public class ZeroitComboDropDown : ComboBox
    {
        #region Variables
        /// <summary>
        /// The x
        /// </summary>
        private int X;


        /// <summary>
        /// The op
        /// </summary>
        private Color _op = Color.FromArgb(204, 204, 204);
        /// <summary>
        /// The o
        /// </summary>
        private Color _o = Color.FromArgb(237, 237, 237);
        /// <summary>
        /// The border
        /// </summary>
        private Color border = Color.FromArgb(120, 255, 255, 255);

        /// <summary>
        /// The gradient1
        /// </summary>
        private Color gradient1 = Color.FromArgb(239, 239, 239);
        /// <summary>
        /// The gradient2
        /// </summary>
        private Color gradient2 = Color.FromArgb(236, 236, 236);
        /// <summary>
        /// The gradient3
        /// </summary>
        private Color gradient3 = Color.FromArgb(234, 234, 234);
        /// <summary>
        /// The gradient4
        /// </summary>
        private Color gradient4 = Color.FromArgb(242, 242, 242);

        /// <summary>
        /// The draw item color1
        /// </summary>
        Color drawItemColor1 = Color.FromArgb(235, 235, 235);
        /// <summary>
        /// The draw item color2
        /// </summary>
        Color drawItemColor2 = Color.FromArgb(230, 230, 230);
        /// <summary>
        /// The draw item color background
        /// </summary>
        Color drawItemColorBackground = Color.White;

        /// <summary>
        /// The collections
        /// </summary>
        private ObjectCollection collections;




        /// <summary>
        /// The over
        /// </summary>
        private bool Over;
        #endregion

        #region Properties                
        /// <summary>
        /// Gets or sets the outer border.
        /// </summary>
        /// <value>The outer border.</value>
        public Color OuterBorder
        {
            get { return _op; }
            set
            {
                _op = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner border.
        /// </summary>
        /// <value>The inner border.</value>
        public Color InnerBorder
        {
            get { return _o; }
            set
            {
                _o = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        public Color Border
        {
            get { return border; }
            set
            {
                border = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient color1.</value>
        public Color Gradient1
        {
            get { return gradient1; }
            set
            {
                gradient1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient color2.</value>
        public Color Gradient2
        {
            get { return gradient2; }
            set
            {
                gradient2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient color3.</value>
        public Color Gradient3
        {
            get { return gradient3; }
            set
            {
                gradient3 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient color4.</value>
        public Color Gradient4
        {
            get { return gradient4; }
            set
            {
                gradient4 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the drawn item color.
        /// </summary>
        /// <value>The draw item color1.</value>
        public Color DrawItemColor1
        {
            get { return drawItemColor1; }
            set
            {
                drawItemColor1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the drawn item color.
        /// </summary>
        /// <value>The draw item color2.</value>
        public Color DrawItemColor2
        {
            get { return drawItemColor2; }
            set
            {
                drawItemColor2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the drawn item's background color.
        /// </summary>
        /// <value>The draw item background color.</value>
        public Color DrawItemColorBackground
        {
            get { return drawItemColorBackground; }
            set
            {
                drawItemColorBackground = value;
                Invalidate();
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitComboDropDown" /> class.
        /// </summary>
        public ZeroitComboDropDown()
            : base()
        {
            TextChanged += GhostCombo_TextChanged;
            DropDownClosed += GhostComboBox_DropDownClosed;
            DropDown += GhostComboBox_DropDown;
            Font = new Font("Tahoma", 9, FontStyle.Regular);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 25;
            DropDownStyle = ComboBoxStyle.DropDownList;


        }
        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            Over = true;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            Over = false;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {

            this.Font = new Font("Tahoma", 9, FontStyle.Regular);
            SolidBrush bs = new SolidBrush(this.ForeColor);
            if (!(DropDownStyle == ComboBoxStyle.DropDownList))
                DropDownStyle = ComboBoxStyle.DropDownList;
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Font m = new Font("Marlett", 11);
            //G.Clear(Color.FromArgb(50, 50, 50));
            LinearGradientBrush GradientBrush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), gradient3, gradient4, 270f);
            G.FillRectangle(GradientBrush, new Rectangle(0, 0, Width, Height));

            Pen op = new Pen(_op, 1);
            Pen o = new Pen(_o, 6);

            G.DrawPath(o, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
            G.DrawPath(op, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));

            if (X >= Width - 20 & Over)
            {
                GradientBrush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), gradient1, gradient2, 90f);
                G.FillRectangle(GradientBrush, new Rectangle(Width - 22, 2, 20, Height - 4));
            }
            else if (X < Width - 20 & Over)
            {
                GradientBrush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), gradient1, gradient2, 90f);
                G.FillRectangle(GradientBrush, new Rectangle(2, 2, Width - 27, Height - 4));
            }

            int S1 = (int)G.MeasureString(" ... ", Font).Height;
            if (SelectedIndex != -1)
            {
                G.DrawString(Items[SelectedIndex].ToString(), Font, bs, 4, (Height / 2 - S1 / 2));
                G.DrawString("6", m, bs, Width - 22, (Height / 2 - S1 / 2));
            }
            else
            {
                if ((Items != null) & Items.Count > 0)
                {
                    G.DrawString(Items[0].ToString(), Font, bs, 4, (Height / 2 - S1 / 2));
                    G.DrawString("6", m, bs, Width - 22, (Height / 2 - S1 / 2));
                }
                else
                {
                    G.DrawString(" ... ", Font, bs, 4, (Height / 2 - S1 / 2));
                    G.DrawString("6", m, bs, Width - 22, (Height / 2 - S1 / 2));
                }
            }
            G.DrawLine(new Pen(border), 1, 1, Width - 3, 1);
            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);

            G.Dispose();
            B.Dispose();

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ComboBox.DrawItem" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs" /> that contains the event data.</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {

            if (e.Index < 0)
                return;
            Rectangle rect = new Rectangle();
            rect.X = e.Bounds.X;
            rect.Y = e.Bounds.Y;
            rect.Width = e.Bounds.Width - 1;
            rect.Height = e.Bounds.Height - 1;

            e.DrawBackground();
            if ((int)e.State == 785 | (int)e.State == 17)
            {
                e.Graphics.FillRectangle(new SolidBrush(drawItemColor1), e.Bounds);
                e.Graphics.FillRectangle(new SolidBrush(drawItemColor2), e.Bounds);
                e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y + 5);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(drawItemColorBackground), e.Bounds);
                e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y + 4);
            }
            base.OnDrawItem(e);
        }

        /// <summary>
        /// Handles the DropDown event of the GhostComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void GhostComboBox_DropDown(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Handles the DropDownClosed event of the GhostComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void GhostComboBox_DropDownClosed(object sender, System.EventArgs e)
        {
            DropDownStyle = ComboBoxStyle.Simple;
            Application.DoEvents();
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Handles the TextChanged event of the GhostCombo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void GhostCombo_TextChanged(object sender, System.EventArgs e)
        {
            Invalidate();
        }

        #endregion

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitComboDropDownDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitComboDropDownDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitComboDropDownSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitComboDropDownSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitComboDropDownSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitComboDropDown colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitComboDropDownSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitComboDropDownSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitComboDropDown;

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
        /// <exception cref="ArgumentException">Matching ColorLabel property not found!</exception>
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
        /// Gets or sets the collections.
        /// </summary>
        /// <value>The collections.</value>
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public Zeroit.Framework.MiscControls.ZeroitComboDropDown.ObjectCollection Collections
        {
            get { return colUserControl.Items; }
            set
            {
                GetPropertyByName("Items").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the outer border.
        /// </summary>
        /// <value>The outer border.</value>
        public Color OuterBorder
        {
            get
            {
                return colUserControl.OuterBorder;
            }
            set
            {
                GetPropertyByName("OuterBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the inner border.
        /// </summary>
        /// <value>The inner border.</value>
        public Color InnerBorder
        {
            get
            {
                return colUserControl.InnerBorder;
            }
            set
            {
                GetPropertyByName("InnerBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        public Color Border
        {
            get
            {
                return colUserControl.Border;
            }
            set
            {
                GetPropertyByName("Border").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient1.
        /// </summary>
        /// <value>The gradient1.</value>
        public Color Gradient1
        {
            get
            {
                return colUserControl.Gradient1;
            }
            set
            {
                GetPropertyByName("Gradient1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient2.
        /// </summary>
        /// <value>The gradient2.</value>
        public Color Gradient2
        {
            get
            {
                return colUserControl.Gradient2;
            }
            set
            {
                GetPropertyByName("Gradient2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient3.
        /// </summary>
        /// <value>The gradient3.</value>
        public Color Gradient3
        {
            get
            {
                return colUserControl.Gradient3;
            }
            set
            {
                GetPropertyByName("Gradient3").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient4.
        /// </summary>
        /// <value>The gradient4.</value>
        public Color Gradient4
        {
            get
            {
                return colUserControl.Gradient4;
            }
            set
            {
                GetPropertyByName("Gradient4").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the draw item color1.
        /// </summary>
        /// <value>The draw item color1.</value>
        public Color DrawItemColor1
        {
            get
            {
                return colUserControl.DrawItemColor1;
            }
            set
            {
                GetPropertyByName("DrawItemColor1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the draw item color2.
        /// </summary>
        /// <value>The draw item color2.</value>
        public Color DrawItemColor2
        {
            get
            {
                return colUserControl.DrawItemColor2;
            }
            set
            {
                GetPropertyByName("DrawItemColor2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the draw item color background.
        /// </summary>
        /// <value>The draw item color background.</value>
        public Color DrawItemColorBackground
        {
            get
            {
                return colUserControl.DrawItemColorBackground;
            }
            set
            {
                GetPropertyByName("DrawItemColorBackground").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Collections",
                                 "Collections", "Appearance",
                                 "Sets the items to display."));

            items.Add(new DesignerActionPropertyItem("OuterBorder",
                                 "OuterBorder", "Appearance",
                                 "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("InnerBorder",
                                 "InnerBorder", "Appearance",
                                 "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("Border",
                                 "Border", "Appearance",
                                 "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("Gradient1",
                                 "Gradient1", "Appearance",
                                 "Sets the hover gradient color."));

            items.Add(new DesignerActionPropertyItem("Gradient2",
                                 "Gradient2", "Appearance",
                                 "Sets the hover gradient color."));

            items.Add(new DesignerActionPropertyItem("Gradient3",
                                 "Gradient3", "Appearance",
                                 "Sets the inactive gradient color."));

            items.Add(new DesignerActionPropertyItem("Gradient4",
                                 "Gradient4", "Appearance",
                                 "Sets the inactive gradient color."));

            items.Add(new DesignerActionPropertyItem("DrawItemColor1",
                                 "Draw Item Color1", "Appearance",
                                 "Sets the selected item color."));

            items.Add(new DesignerActionPropertyItem("DrawItemColor2",
                                 "Draw Item Color2", "Appearance",
                                 "Sets the selected item color."));

            items.Add(new DesignerActionPropertyItem("DrawItemColorBackground",
                                 "Draw Item Color Background", "Appearance",
                                 "Sets the dropdown background color."));

            //items.Add(new DesignerActionPropertyItem("Color2_inactive",
            //                     "Color2 inactive", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("Color2_inactive",
            //                     "Color2 inactive", "Appearance",
            //                     "Type few characters to filter Cities."));

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
