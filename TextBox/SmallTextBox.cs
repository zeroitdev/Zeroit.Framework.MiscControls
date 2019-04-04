// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="SmallTextBox.cs" company="Zeroit Dev Technologies">
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
    #region Small TextBox    
    /// <summary>
    /// A class collection for rendering a textbox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitTextBoxSmallDesigner))]
    [DefaultEvent("TextChanged")]
    public class ZeroitTextBoxSmall : Control
    {
        #region Variables

        /// <summary>
        /// The i talk tb
        /// </summary>
        public ZeroitTextBox iTalkTB = new ZeroitTextBox();
        /// <summary>
        /// The shape
        /// </summary>
        private GraphicsPath Shape;
        /// <summary>
        /// The maxchars
        /// </summary>
        private int _maxchars = 32767;
        /// <summary>
        /// The read only
        /// </summary>
        private bool _ReadOnly;
        /// <summary>
        /// The multiline
        /// </summary>
        private bool _Multiline;
        /// <summary>
        /// The aln type
        /// </summary>
        private HorizontalAlignment ALNType;
        /// <summary>
        /// The is password masked
        /// </summary>
        private bool isPasswordMasked = false;
        /// <summary>
        /// The p1
        /// </summary>
        private Pen P1;
        /// <summary>
        /// The b1
        /// </summary>
        private SolidBrush B1;

        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;
        /// <summary>
        /// The image size
        /// </summary>
        private Size _ImageSize;

        /// <summary>
        /// The background color
        /// </summary>
        private Color backgroundColor = Color.White;
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.FromArgb(180, 180, 180);

        /// <summary>
        /// The background color tb
        /// </summary>
        private Color backgroundColorTB = Color.White;

        /// <summary>
        /// The text box width
        /// </summary>
        public int textBoxWidth = 20;

        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the text box width reduced.
        /// </summary>
        /// <value>The text box width reduced.</value>
        public int TextBoxWidthReduced
        {
            get { return textBoxWidth; }
            set
            {
                textBoxWidth = value;
                Invalidate();
            }
        }

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
        /// Gets or sets the background color text box.
        /// </summary>
        /// <value>The background color text box.</value>
        public Color BackgroundColorTextBox
        {
            get { return backgroundColorTB; }
            set
            {
                backgroundColorTB = value;
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
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        public HorizontalAlignment TextAlignment
        {
            get { return ALNType; }
            set
            {
                ALNType = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>The maximum length.</value>
        public int MaxLength
        {
            get { return _maxchars; }
            set
            {
                _maxchars = value;
                iTalkTB.MaxLength = MaxLength;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use system password character.
        /// </summary>
        /// <value><c>true</c> if use system password character; otherwise, <c>false</c>.</value>
        public bool UseSystemPasswordChar
        {
            get { return isPasswordMasked; }
            set
            {
                iTalkTB.UseSystemPasswordChar = UseSystemPasswordChar;
                isPasswordMasked = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether read only.
        /// </summary>
        /// <value><c>true</c> if read only; otherwise, <c>false</c>.</value>
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (iTalkTB != null)
                {
                    iTalkTB.ReadOnly = value;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitTextBoxSmall" /> is multiline.
        /// </summary>
        /// <value><c>true</c> if multiline; otherwise, <c>false</c>.</value>
        public bool Multiline
        {
            get { return _Multiline; }
            set
            {
                _Multiline = value;
                if (iTalkTB != null)
                {
                    iTalkTB.Multiline = value;

                    if (value)
                    {
                        iTalkTB.Height = Height - 10;
                    }
                    else
                    {
                        Height = iTalkTB.Height + 10;
                    }
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;

                if (Image == null)
                {
                    iTalkTB.Location = new Point(5, 5);
                }
                else
                {
                    iTalkTB.Location = new Point(35, 5);
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get
            {
                return _ImageSize;
            }
            set
            {
                _ImageSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        public override Font Font
        {
            get { return base.Font; }
            set { iTalkTB.Font = value; }
        }

        #endregion

        #region EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            iTalkTB.Text = Text;
            Invalidate();
        }

        /// <summary>
        /// Handles the <see cref="E:BaseTextChanged" /> event.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = iTalkTB.Text;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ForeColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnForeColorChanged(System.EventArgs e)
        {
            base.OnForeColorChanged(e);
            iTalkTB.ForeColor = ForeColor;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.FontChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnFontChanged(System.EventArgs e)
        {
            base.OnFontChanged(e);
            iTalkTB.Font = Font;
        }

        /// <summary>
        /// Handles the <see cref="E:PaintBackground" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        /// <summary>
        /// Handles the OnKeyDown event of the  control.
        /// </summary>
        /// <param name="Obj">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void _OnKeyDown(object Obj, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                iTalkTB.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                iTalkTB.Copy();
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            if (_Multiline)
            {
                iTalkTB.Height = Height - 10;
            }
            else
            {
                Height = iTalkTB.Height + 10;
            }

            Shape = new GraphicsPath();
            var _with1 = Shape;
            _with1.AddArc(0, 0, 10, 10, 180, 90);
            _with1.AddArc(Width - 11, 0, 10, 10, -90, 90);
            _with1.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            _with1.AddArc(0, Height - 11, 10, 10, 90, 90);
            _with1.CloseAllFigures();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            iTalkTB.Focus();
        }

        #endregion

        /// <summary>
        /// Adds the text box.
        /// </summary>
        public void AddTextBox()
        {
            var _TB = iTalkTB;
            _TB.Size = new Size(Width - 10, 33);
            _TB.Location = new Point(7, 5);
            _TB.Text = string.Empty;
            _TB.BorderStyle = BorderStyle.None;
            _TB.TextAlign = HorizontalAlignment.Left;
            _TB.Font = new Font("Tahoma", 11);
            _TB.UseSystemPasswordChar = UseSystemPasswordChar;
            _TB.Multiline = false;
            iTalkTB.KeyDown += _OnKeyDown;
            iTalkTB.TextChanged += OnBaseTextChanged;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTextBoxSmall" /> class.
        /// </summary>
        public ZeroitTextBoxSmall()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            AddTextBox();
            Controls.Add(iTalkTB);

            //BackColor = Color.Transparent;
            ForeColor = Color.DimGray;

            Font = new Font("Tahoma", 11);
            Size = new Size(135, 33);
            DoubleBuffered = true;

            if (Image == null)
            {
                iTalkTB.Width = Width - 18;
            }
            else
            {
                iTalkTB.Width = Width - 35;
            }

            iTalkTB.BackColor = backgroundColorTB;
            var _TB = iTalkTB;
            _TB.Width = Width - textBoxWidth;
            _TB.TextAlign = TextAlignment;
            _TB.UseSystemPasswordChar = UseSystemPasswordChar;

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
            
            G.Clear(Color.Transparent);
            G.FillPath(B1, Shape); // Draw background
            G.DrawPath(P1, Shape); // Draw border


            if (Image != null)
            {
                G.DrawImage(_Image, 5, 8, 16, 16);
                // 24x24 is the perfect size of the image
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
    /// Class ZeroitTextBoxSmallDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitTextBoxSmallDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitTextBoxSmallSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitTextBoxSmallSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitTextBoxSmallSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitTextBoxSmall colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTextBoxSmallSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitTextBoxSmallSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitTextBoxSmall;

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
        /// Gets or sets the text box width reduced.
        /// </summary>
        /// <value>The text box width reduced.</value>
        public int TextBoxWidthReduced
        {
            get
            {
                return colUserControl.TextBoxWidthReduced;
            }
            set
            {
                GetPropertyByName("TextBoxWidthReduced").SetValue(colUserControl, value);
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
        /// Gets or sets the background color text box.
        /// </summary>
        /// <value>The background color text box.</value>
        public Color BackgroundColorTextBox
        {
            get
            {
                return colUserControl.BackgroundColorTextBox;
            }
            set
            {
                GetPropertyByName("BackgroundColorTextBox").SetValue(colUserControl, value);
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
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        public HorizontalAlignment TextAlignment
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
        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>The maximum length.</value>
        public int MaxLength
        {
            get
            {
                return colUserControl.MaxLength;
            }
            set
            {
                GetPropertyByName("MaxLength").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use system password character].
        /// </summary>
        /// <value><c>true</c> if [use system password character]; otherwise, <c>false</c>.</value>
        public bool UseSystemPasswordChar
        {
            get
            {
                return colUserControl.UseSystemPasswordChar;
            }
            set
            {
                GetPropertyByName("UseSystemPasswordChar").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [read only].
        /// </summary>
        /// <value><c>true</c> if [read only]; otherwise, <c>false</c>.</value>
        public bool ReadOnly
        {
            get
            {
                return colUserControl.ReadOnly;
            }
            set
            {
                GetPropertyByName("ReadOnly").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitTextBoxSmallSmartTagActionList"/> is multiline.
        /// </summary>
        /// <value><c>true</c> if multiline; otherwise, <c>false</c>.</value>
        public bool Multiline
        {
            get
            {
                return colUserControl.Multiline;
            }
            set
            {
                GetPropertyByName("Multiline").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get
            {
                return colUserControl.Image;
            }
            set
            {
                GetPropertyByName("Image").SetValue(colUserControl, value);
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
                                 "Sets the inner background color."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorTextBox",
                                 "Background Color TextBox", "Appearance",
                                 "Sets the inner background color of the textbox."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the inner border color."));

            items.Add(new DesignerActionPropertyItem("TextAlignment",
                                 "Text Alignment", "Appearance",
                                 "Sets the text alignment of the control."));

            items.Add(new DesignerActionPropertyItem("MaxLength",
                                 "Max Length", "Appearance",
                                 "Sets the Maximum Length."));

            items.Add(new DesignerActionPropertyItem("UseSystemPasswordChar",
                                 "Use System PasswordChar", "Appearance",
                                 "Sets the text to password characters."));

            items.Add(new DesignerActionPropertyItem("ReadOnly",
                                 "ReadOnly", "Appearance",
                                 "Sets the control to be read only."));

            items.Add(new DesignerActionPropertyItem("Multiline",
                                 "Multiline", "Appearance",
                                 "Sets the control to support Multiline."));

            items.Add(new DesignerActionPropertyItem("TextBoxWidthReduced",
                                 "TextBox Width Reduced", "Appearance",
                                 "Sets the control to support Multiline."));


            items.Add(new DesignerActionPropertyItem("Image",
                                 "Image", "Appearance",
                                 "Select an image for the control."));

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
