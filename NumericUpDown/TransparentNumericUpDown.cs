// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TransparentNumericUpDown.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitNumericUpDownTransparent    
    /// <summary>
    /// A class collection for rendering a transparent numeric up and down control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitNumericUpDownTransparentDesigner))]
    public class ZeroitNumericUpDownTransparent : Control
    {

        #region " Private "
        /// <summary>
        /// The g
        /// </summary>
        private Graphics G;
        /// <summary>
        /// The value
        /// </summary>
        private int _Value;
        /// <summary>
        /// The minimum
        /// </summary>
        private int _Min;
        /// <summary>
        /// The maximum
        /// </summary>
        private int _Max;
        /// <summary>
        /// The loc
        /// </summary>
        private Point Loc;
        /// <summary>
        /// Down
        /// </summary>
        private bool Down;
        /// <summary>
        /// The enabled calculate
        /// </summary>
        private bool _EnabledCalc;
        #endregion
        /// <summary>
        /// The etc
        /// </summary>
        private Color ETC = Color.Blue;

        /// <summary>
        /// Up down arrow
        /// </summary>
        Color upDownArrow = Color.White;
        /// <summary>
        /// The text color center
        /// </summary>
        Color textColorCenter = Color.White;
        /// <summary>
        /// The outer border
        /// </summary>
        Color outerBorder = Helpers.GreyColor(190);
        /// <summary>
        /// The arrow border
        /// </summary>
        Color arrowBorder = Helpers.GreyColor(190);

        #region " Properties "        
        /// <summary>
        /// Gets or sets up down arrow.
        /// </summary>
        /// <value>Up down arrow.</value>
        public Color UpDownArrow
        {
            get { return upDownArrow; }
            set
            {
                upDownArrow = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the center text color.
        /// </summary>
        /// <value>The center text color.</value>
        public Color TextColorCenter
        {
            get { return textColorCenter; }
            set
            {
                textColorCenter = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer border.
        /// </summary>
        /// <value>The outer border.</value>
        public Color OuterBorder
        {
            get { return outerBorder; }
            set
            {
                outerBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the arrow border.
        /// </summary>
        /// <value>The arrow border.</value>
        public Color ArrowBorder
        {
            get { return arrowBorder; }
            set
            {
                arrowBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control can respond to user interaction.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public new bool Enabled
        {
            get { return EnabledCalc; }
            set
            {
                _EnabledCalc = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether enabled calculate is set.
        /// </summary>
        /// <value><c>true</c> if enabled calculate; otherwise, <c>false</c>.</value>
        [DisplayName("Enabled")]
        public bool EnabledCalc
        {
            get { return _EnabledCalc; }
            set
            {
                Enabled = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get { return _Value; }

            set
            {
                if (value <= _Max & value >= Minimum)
                {
                    _Value = value;
                }

                Invalidate();

            }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get { return _Min; }

            set
            {
                if (value < Maximum)
                {
                    _Min = value;
                }

                if (value < Minimum)
                {
                    value = Minimum;
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get { return _Max; }

            set
            {
                if (value > Minimum)
                {
                    _Max = value;
                }

                if (value > Maximum)
                {
                    value = Maximum;
                }

                Invalidate();
            }
        }

        #endregion

        #region " Control "        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitNumericUpDownTransparent" /> class.
        /// </summary>
        public ZeroitNumericUpDownTransparent()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);


            DoubleBuffered = true;
            Value = 0;
            Minimum = 0;
            Maximum = 100;
            Cursor = Cursors.IBeam;
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(66, 78, 90);
            Font = Theme1.GlobalFont(FontStyle.Regular, 10);
            Enabled = true;
            Size = new Size(64, 30);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Loc.X = e.X;
            Loc.Y = e.Y;
            Invalidate();

            if (Loc.X < Width - 23)
            {
                Cursor = Cursors.IBeam;
            }
            else
            {
                Cursor = Cursors.Default;
            }

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 30;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseClick(e);


            if (Enabled)
            {
                if (Loc.X > Width - 21 && Loc.X < Width - 3)
                {
                    if (Loc.Y < 15)
                    {
                        if ((Value + 1) <= Maximum)
                        {
                            Value += 1;
                        }
                    }
                    else
                    {
                        if ((Value - 1) >= Minimum)
                        {
                            Value -= 1;
                        }
                    }
                }
                else
                {
                    Down = !Down;
                    Focus();
                }

            }

            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyPress" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs" /> that contains the event data.</param>
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            try
            {
                if (Down)
                {
                    Value = Convert.ToInt32(Value.ToString() + e.KeyChar.ToString());
                }

                if (Value > Maximum)
                {
                    Value = Maximum;
                }

            }
            catch
            {
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyUp(e);


            if (e.KeyCode == Keys.Up)
            {
                if ((Value + 1) <= Maximum)
                {
                    Value += 1;
                }

                Invalidate();


            }
            else if (e.KeyCode == Keys.Down)
            {
                if ((Value - 1) >= Minimum)
                {
                    Value -= 1;
                }

            }
            else if (e.KeyCode == Keys.Back)
            {
                string BC = Value.ToString();
                BC = BC.Remove(Convert.ToInt32(BC.Length - 1));

                if ((BC.Length == 0))
                {
                    BC = "0";
                }

                Value = Convert.ToInt32(BC);

            }

            Invalidate();

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            //G.Clear(Parent.BackColor);


            if (Enabled)
            {
                ETC = Color.FromArgb(66, 78, 90);

                using (Pen P = new Pen(arrowBorder))
                {
                    Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 2, outerBorder);
                    G.DrawLine(P, new Point(Width - 24, (int)13.5f), new Point(Width - 5, (int)13.5f));
                }

                Helpers.DrawRoundRect(G, new Rectangle(Width - 24, 4, 19, 21), 3, arrowBorder);

            }
            else
            {
                ETC = Helpers.GreyColor(170);

                using (Pen P = new Pen(arrowBorder))
                {
                    Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 2, outerBorder);
                    G.DrawLine(P, new Point(Width - 24, (int)13.5f), new Point(Width - 5, (int)13.5f));
                }

                Helpers.DrawRoundRect(G, new Rectangle(Width - 24, 4, 19, 21), 3, arrowBorder);

            }

            using (SolidBrush B = new SolidBrush(upDownArrow))
            {
                G.DrawString("t", new Font("Marlett", 8, FontStyle.Bold), B, new Point(Width - 22, 5));
                G.DrawString("u", new Font("Marlett", 8, FontStyle.Bold), B, new Point(Width - 22, 13));
                Helpers.CenterString(G, Value.ToString(), new Font("Segoe UI", 10), textColorCenter, new Rectangle(Width / 2 - 10, 0, Width - 5, Height));
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
    /// Class ZeroitNumericUpDownTransparentDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitNumericUpDownTransparentDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitNumericUpDownTransparentSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitNumericUpDownTransparentSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitNumericUpDownTransparentSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitNumericUpDownTransparent colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitNumericUpDownTransparentSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitNumericUpDownTransparentSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitNumericUpDownTransparent;

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
        /// Gets or sets up down arrow.
        /// </summary>
        /// <value>Up down arrow.</value>
        public Color UpDownArrow
        {
            get
            {
                return colUserControl.UpDownArrow;
            }
            set
            {
                GetPropertyByName("UpDownArrow").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text color center.
        /// </summary>
        /// <value>The text color center.</value>
        public Color TextColorCenter
        {
            get
            {
                return colUserControl.TextColorCenter;
            }
            set
            {
                GetPropertyByName("TextColorCenter").SetValue(colUserControl, value);
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
        /// Gets or sets the arrow border.
        /// </summary>
        /// <value>The arrow border.</value>
        public Color ArrowBorder
        {
            get
            {
                return colUserControl.ArrowBorder;
            }
            set
            {
                GetPropertyByName("ArrowBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitNumericUpDownTransparentSmartTagActionList"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled
        {
            get
            {
                return colUserControl.Enabled;
            }
            set
            {
                GetPropertyByName("Enabled").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enabled calculate].
        /// </summary>
        /// <value><c>true</c> if [enabled calculate]; otherwise, <c>false</c>.</value>
        public bool EnabledCalc
        {
            get
            {
                return colUserControl.EnabledCalc;
            }
            set
            {
                GetPropertyByName("EnabledCalc").SetValue(colUserControl, value);
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
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return colUserControl.Minimum;
            }
            set
            {
                GetPropertyByName("Minimum").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("UpDownArrow",
                                 "UpDown Arrow", "Appearance",
                                 "Sets the color of the up and down arrow."));

            items.Add(new DesignerActionPropertyItem("TextColorCenter",
                                 "Text Color Center", "Appearance",
                                 "Sets the color of the value."));

            items.Add(new DesignerActionPropertyItem("OuterBorder",
                                 "Outer Border", "Appearance",
                                 "Sets the color of the outer border."));

            items.Add(new DesignerActionPropertyItem("ArrowBorder",
                                 "Arrow Border", "Appearance",
                                 "Sets the color of the arrow border."));

            items.Add(new DesignerActionPropertyItem("Enabled",
                                 "Enabled", "Appearance",
                                 "Set to enable the control."));

            items.Add(new DesignerActionPropertyItem("EnabledCalc",
                                 "Enabled Calc", "Appearance",
                                 "Set to enable the control."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value of the control."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                                 "Minimum", "Appearance",
                                 "Sets the minimum value."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value."));

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
