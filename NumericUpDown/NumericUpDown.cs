// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NumericUpDown.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    #region  NumericUpDown    
    /// <summary>
    /// A class collection for rendering a numeric up and down control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitNumericUpDownDesigner))]
    public class ZeroitNumericUpDown : Control
    {

        #region  Enums

        /// <summary>
        /// Enum representing the Text Alignment
        /// </summary>
        public enum TextAlign
        {
            /// <summary>
            /// The near
            /// </summary>
            Near,
            /// <summary>
            /// The center
            /// </summary>
            Center
        }

        #endregion

        #region  Variables

        /// <summary>
        /// The shape
        /// </summary>
        private GraphicsPath Shape;
        /// <summary>
        /// The p1
        /// </summary>
        private Pen P1;
        /// <summary>
        /// The b1
        /// </summary>
        private SolidBrush B1;

        /// <summary>
        /// The value
        /// </summary>
        private long _Value;
        /// <summary>
        /// The minimum
        /// </summary>
        private long _Minimum;
        /// <summary>
        /// The maximum
        /// </summary>
        private long _Maximum;
        /// <summary>
        /// The xval
        /// </summary>
        private int Xval;
        /// <summary>
        /// The yval
        /// </summary>
        private int Yval;
        /// <summary>
        /// The keyboard number
        /// </summary>
        private bool KeyboardNum;
        /// <summary>
        /// My string alignment
        /// </summary>
        private TextAlign MyStringAlignment;

        /// <summary>
        /// The background color
        /// </summary>
        private Color backgroundColor = Color.White;
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.FromArgb(180, 180, 180);

        /// <summary>
        /// The background gradient1
        /// </summary>
        private Color backgroundGradient1 = Color.FromArgb(241, 241, 241);
        /// <summary>
        /// The background gradient2
        /// </summary>
        private Color backgroundGradient2 = Color.FromArgb(241, 241, 241);

        /// <summary>
        /// Up text
        /// </summary>
        private string upText = "+";
        /// <summary>
        /// Down text
        /// </summary>
        private string downText = "-";


        #endregion

        #region  Properties        
        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background gradient.
        /// </summary>
        /// <value>The background gradient1.</value>
        public Color BackgroundGradient1
        {
            get { return backgroundGradient1; }
            set
            {
                backgroundGradient1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background gradient.
        /// </summary>
        /// <value>The background gradient2.</value>
        public Color BackgroundGradient2
        {
            get { return backgroundGradient2; }
            set
            {
                backgroundGradient2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets up text.
        /// </summary>
        /// <value>Up text.</value>
        public String UpText
        {
            get { return upText; }
            set
            {
                upText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets down text.
        /// </summary>
        /// <value>Down text.</value>
        public String DownText
        {
            get { return downText; }
            set
            {
                downText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets current the value.
        /// </summary>
        /// <value>The value.</value>
        public long Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value <= _Maximum & value >= _Minimum)
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
        public long Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value < _Maximum)
                {
                    _Minimum = value;
                }
                if (_Value < _Minimum)
                {
                    _Value = Minimum;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        public long Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value > _Minimum)
                {
                    _Maximum = value;
                }
                if (_Value > _Maximum)
                {
                    _Value = _Maximum;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        public TextAlign TextAlignment
        {
            get
            {
                return MyStringAlignment;
            }
            set
            {
                MyStringAlignment = value;
                Invalidate();
            }
        }

        #endregion

        #region  EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Height = 28;
            Shape = new GraphicsPath();
            Shape.AddArc(0, 0, 10, 10, 180, 90);
            Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            Shape.CloseAllFigures();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Xval = e.Location.X;
            Yval = e.Location.Y;
            Invalidate();

            if (e.X < Width - 24)
            {
                Cursor = Cursors.IBeam;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (Xval > this.Width - 23 && Xval < this.Width - 3)
            {
                if (Yval < 15)
                {
                    if ((Value + 1) <= _Maximum)
                    {
                        _Value++;
                    }
                }
                else
                {
                    if ((Value - 1) >= _Minimum)
                    {
                        _Value--;
                    }
                }
            }
            else
            {
                KeyboardNum = !KeyboardNum;
                Focus();
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
                if (KeyboardNum == true)
                {
                    _Value = long.Parse((_Value).ToString() + e.KeyChar.ToString().ToString());
                }
                if (_Value > _Maximum)
                {
                    _Value = _Maximum;
                }
            }
            catch (Exception)
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
            if (e.KeyCode == Keys.Back)
            {
                string TemporaryValue = _Value.ToString();
                TemporaryValue = TemporaryValue.Remove(Convert.ToInt32(TemporaryValue.Length - 1));
                if (TemporaryValue.Length == 0)
                {
                    TemporaryValue = "0";
                }
                _Value = Convert.ToInt32(TemporaryValue);
            }
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseWheel" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta > 0)
            {
                if ((Value + 1) <= _Maximum)
                {
                    _Value++;
                }
                Invalidate();
            }
            else
            {
                if ((Value - 1) >= _Minimum)
                {
                    _Value--;
                }
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitNumericUpDown" /> class.
        /// </summary>
        public ZeroitNumericUpDown()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            //P1 = new Pen(Color.FromArgb(180, 180, 180)); // P1 = Border color
            //B1 = new SolidBrush(Color.White); // B1 = Rect Background color
            BackColor = Color.Transparent;
            ForeColor = Color.DimGray;

            _Minimum = 0;
            _Maximum = 100;

            Font = new Font("Tahoma", 11);
            Size = new Size(70, 28);
            MinimumSize = new Size(62, 28);
            DoubleBuffered = true;
        }

        /// <summary>
        /// Increments the specified value.
        /// </summary>
        /// <param name="Value">The value.</param>
        public void Increment(int Value)
        {
            this._Value += Value;
            Invalidate();
        }

        /// <summary>
        /// Decrements the specified value.
        /// </summary>
        /// <param name="Value">The value.</param>
        public void Decrement(int Value)
        {
            this._Value -= Value;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            P1 = new Pen(borderColor); // P1 = Border color
            B1 = new SolidBrush(backgroundColor); // B1 = Rect Background color

            G.SmoothingMode = SmoothingMode.AntiAlias;

            G.Clear(Color.Transparent); // Set control background color
            G.FillPath(B1, Shape); // Draw background
            G.DrawPath(P1, Shape); // Draw border

            LinearGradientBrush ColorGradient = new LinearGradientBrush(new Rectangle(Width - 23, 4, 19, 19), backgroundGradient1, backgroundGradient2, 90.0F);
            G.FillRectangle(ColorGradient, ColorGradient.Rectangle); // Fills the body of the rectangle

            G.DrawRectangle(new Pen(Color.FromArgb(252, 252, 252)), new Rectangle(Width - 22, 5, 17, 17));
            G.DrawRectangle(new Pen(Color.FromArgb(180, 180, 180)), new Rectangle(Width - 23, 4, 19, 19));

            G.DrawLine(new Pen(Color.FromArgb(250, 252, 250)), new Point(Width - 22, Height - 16), new Point(Width - 5, Height - 16));
            G.DrawLine(new Pen(Color.FromArgb(180, 180, 180)), new Point(Width - 22, Height - 15), new Point(Width - 5, Height - 15));
            G.DrawLine(new Pen(Color.FromArgb(250, 250, 250)), new Point(Width - 22, Height - 14), new Point(Width - 5, Height - 14));

            G.DrawString(upText, new Font("Tahoma", 8), Brushes.Black, Width - 19, Height - 24);
            G.DrawString(downText, new Font("Tahoma", 8), Brushes.Black, Width - 19, Height - 15);

            switch (MyStringAlignment)
            {
                case TextAlign.Near:
                    G.DrawString(System.Convert.ToString(Value), Font, new SolidBrush(ForeColor), new Rectangle(5, 0, Width - 1, Height - 1), new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                    break;
                case TextAlign.Center:
                    G.DrawString(System.Convert.ToString(Value), Font, new SolidBrush(ForeColor), new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    break;
            }

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitNumericUpDownDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitNumericUpDownDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitNumericUpDownSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitNumericUpDownSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitNumericUpDownSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitNumericUpDown colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitNumericUpDownSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitNumericUpDownSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitNumericUpDown;

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
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Color BackgroundColor
        {
            get
            {
                return colUserControl.BackgroundColor;
            }
            set
            {
                GetPropertyByName("BackgroundColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return colUserControl.BorderColor;
            }
            set
            {
                GetPropertyByName("BorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background gradient1.
        /// </summary>
        /// <value>The background gradient1.</value>
        public Color BackgroundGradient1
        {
            get
            {
                return colUserControl.BackgroundGradient1;
            }
            set
            {
                GetPropertyByName("BackgroundGradient1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background gradient2.
        /// </summary>
        /// <value>The background gradient2.</value>
        public Color BackgroundGradient2
        {
            get
            {
                return colUserControl.BackgroundGradient2;
            }
            set
            {
                GetPropertyByName("BackgroundGradient2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets up text.
        /// </summary>
        /// <value>Up text.</value>
        public String UpText
        {
            get
            {
                return colUserControl.UpText;
            }
            set
            {
                GetPropertyByName("UpText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets down text.
        /// </summary>
        /// <value>Down text.</value>
        public String DownText
        {
            get
            {
                return colUserControl.DownText;
            }
            set
            {
                GetPropertyByName("DownText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public long Value
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
        public long Minimum
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
        public long Maximum
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

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        public Zeroit.Framework.MiscControls.ZeroitNumericUpDown.TextAlign TextAlignment
        {
            get
            {
                return colUserControl.TextAlignment;
            }
            set
            {
                GetPropertyByName("TextAlignment").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("BackgroundColor",
                                 "Background Color", "Appearance",
                                 "Sets the background color of the control."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the border color of the control."));

            items.Add(new DesignerActionPropertyItem("BackgroundGradient1",
                                 "Background Gradient1", "Appearance",
                                 "Sets the background color of the control buttons."));

            items.Add(new DesignerActionPropertyItem("BackgroundGradient2",
                                 "Background Gradient2", "Appearance",
                                 "Sets the background color of the control buttons."));

            items.Add(new DesignerActionPropertyItem("UpText",
                                 "Up Text", "Appearance",
                                 "Sets the increment text."));

            items.Add(new DesignerActionPropertyItem("DownText",
                                 "Down Text", "Appearance",
                                 "Sets the decrement text."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the Value of the control."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                                 "Minimum", "Appearance",
                                 "Sets the minimum value of the control."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value of the control."));

            items.Add(new DesignerActionPropertyItem("TextAlignment",
                                 "Text Alignment", "Appearance",
                                 "Sets the text alignment of the control."));

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
