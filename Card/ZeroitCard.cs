// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-04-2018
// ***********************************************************************
// <copyright file="ZeroitCard.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    /// <summary>
    /// Class ZeroitCard.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitCardDesigner))]
    public class ZeroitCard : Control
	{

        #region Private Fields
        /// <summary>
        /// The colors
        /// </summary>
        private Color[] colors = new Color[]
        {
            Color.Orange,
            Color.DarkSlateGray
        };


        /// <summary>
        /// The text1
        /// </summary>
        private string text1 = "Card Information";

        /// <summary>
        /// The text2
        /// </summary>
        private string text2 = "0011 2233 4455 6677";

        /// <summary>
        /// The text3
        /// </summary>
        private string text3 = "zeroitdev@gmail.com";

        /// <summary>
        /// The header font
        /// </summary>
        private Font headerFont = new Font("Tahoma", 10);
        /// <summary>
        /// The content font
        /// </summary>
        private Font contentFont = new Font("Tahoma", 15);
        /// <summary>
        /// The footer font
        /// </summary>
        private Font footerFont = new Font("Tahoma", 10);

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the header font.
        /// </summary>
        /// <value>The header font.</value>
        public Font HeaderFont
        {
            get { return headerFont; }
            set
            {
                headerFont = value;
                Invalidate();

            }
        }

        /// <summary>
        /// Gets or sets the content font.
        /// </summary>
        /// <value>The content font.</value>
        public Font ContentFont
        {
            get { return contentFont; }
            set
            {
                contentFont = value;
                Invalidate();

            }
        }

        /// <summary>
        /// Gets or sets the footer font.
        /// </summary>
        /// <value>The footer font.</value>
        public Font FooterFont
        {
            get { return footerFont; }
            set
            {
                footerFont = value;
                Invalidate();

            }
        }

        /// <summary>
        /// Gets or sets the gradient colors.
        /// </summary>
        /// <value>The colors.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("Sets the Color of the gradient")]
        public Color[] Colors
        {
            get
            {
                return this.colors;
            }
            set
            {
                this.colors = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        /// <value>The header text.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("The 1st text")]
        public string TextHeader
        {
            get
            {
                return this.text1;
            }
            set
            {
                this.text1 = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text content.
        /// </summary>
        /// <value>The content text.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("The 2nd text")]
        public string TextContent
        {
            get
            {
                return this.text2;
            }
            set
            {
                this.text2 = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the footer text.
        /// </summary>
        /// <value>The footer text.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("The 3rd text")]
        public string TextFooter
        {
            get
            {
                return this.text3;
            }
            set
            {
                this.text3 = value;
                base.Invalidate();
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCard" /> class.
        /// </summary>
        public ZeroitCard()
        {


            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            base.Size = new System.Drawing.Size(320, 170);
            this.ForeColor = Color.White;
        }
        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            if (AllowTransparency)
            {
                MakeTransparent(this, g);
            }


            int num = (base.Width <= base.Height ? base.Height : base.Width);
            
            #region Old Code
            //GraphicsPath graphicsPath = new GraphicsPath();
            //graphicsPath.AddArc(base.Width - 10 - 2, 0, 10, 10, 250f, 90f);
            //graphicsPath.AddArc(base.Width - 10 - 2, base.Height - 10, 10, 8, 0f, 90f);
            //graphicsPath.AddArc(0, base.Height - 10 - 2, 8, 10, 90f, 90f);
            //graphicsPath.AddArc(0, 0, 10, 10, 180f, 90f);

            //graphicsPath.CloseFigure();
            //e.Graphics.FillPath(linearGradientBrush, graphicsPath);

            //Pen pens = new Pen(linearGradientBrush);
            //g.DrawArc(pens, base.Width - 10 - 2, 0, 10, 10, 250f, 90f);
            //g.DrawArc(pens, base.Width - 10 - 2, base.Height - 10, 10, 8, 0f, 90f);
            //g.DrawArc(pens, 0, base.Height - 10 - 2, 8, 10, 90f, 90f);
            //g.DrawArc(pens, 0, 0, 10, 10, 180f, 90f); 
            #endregion

            DrawRoundedRectangle(e);

            StringFormat stringFormat = new StringFormat()
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            };
            Rectangle rectangle = new Rectangle(2, 6, base.Width - 4, 26);
            g.DrawString(this.text1, HeaderFont, new SolidBrush(this.ForeColor), rectangle, stringFormat);
            stringFormat.Alignment = StringAlignment.Near;
            rectangle = new Rectangle(2, base.Height / 2, base.Width - 4, base.Height / 4);
            g.DrawString(this.text2, ContentFont, new SolidBrush(this.ForeColor), rectangle, stringFormat);
            stringFormat.Alignment = StringAlignment.Near;
            rectangle = new Rectangle(2, base.Height / 2 + base.Height / 4, base.Width - 4, base.Height / 4);
            g.DrawString(this.text3, FooterFont, new SolidBrush(this.ForeColor), rectangle, stringFormat);


        }



        #region Rounded Control

        /// <summary>
        /// The shape
        /// </summary>
        private GraphicsPath Shape;
        //private SolidBrush solidColor;

        /// <summary>
        /// The radius upper left
        /// </summary>
        private Int32 _RadiusUpperLeft = 10;
        /// <summary>
        /// The radius upper right
        /// </summary>
        private Int32 _RadiusUpperRight = 10;
        /// <summary>
        /// The radius bottom left
        /// </summary>
        private Int32 _RadiusBottomLeft = 10;
        /// <summary>
        /// The radius bottom right
        /// </summary>
        private Int32 _RadiusBottomRight = 10;

        /// <summary>
        /// The border width
        /// </summary>
        private int borderWidth = 1;
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.Black;
        /// <summary>
        /// The gradient angle
        /// </summary>
        float gradientAngle = 135f;


        /// <summary>
        /// Gets or sets the gradient angle.
        /// </summary>
        /// <value>The gradient angle.</value>
        public float GradientAngle
        {
            get { return gradientAngle; }
            set
            {
                gradientAngle = value;
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
        /// This changes the upper left radius of the button
        /// </summary>
        /// <value>The corner upper left.</value>
        [Description("This changes the upper left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 CornerUpperLeft
        {
            get { return this._RadiusUpperLeft; }
            set
            {
                if (_RadiusUpperLeft == null)
                {
                    this._RadiusUpperLeft = 10;

                }


                this._RadiusUpperLeft = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The corner upper right.</value>
        [Description("This changes the upper right radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 CornerUpperRight
        {
            get { return this._RadiusUpperRight; }
            set
            {
                if (_RadiusUpperRight == null)
                {
                    this._RadiusUpperRight = 10;

                }

                this._RadiusUpperRight = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The corner bottom left.</value>
        [Description("This changes the bottom left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 CornerBottomLeft
        {
            get { return this._RadiusBottomLeft; }
            set
            {
                if (_RadiusBottomLeft == null)
                {
                    this._RadiusBottomLeft = 10;

                }

                this._RadiusBottomLeft = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The corner bottom right.</value>
        [Description("This changes the bottom right radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 CornerBottomRight
        {
            get { return this._RadiusBottomRight; }
            set
            {
                if (_RadiusBottomRight == null)
                {
                    this._RadiusBottomRight = 10;

                }

                this._RadiusBottomRight = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// Draws the rounded rectangle.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        public void DrawRoundedRectangle(PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Shape = new GraphicsPath();
            Rectangle R1 = new Rectangle(0, 0, Width, Height);

            // Button Background Colors
            //solidColor = new SolidBrush(Color.DarkSlateGray);

            Brush linearGradientBrush = new LinearGradientBrush(base.ClientRectangle, colors[0], colors[1], GradientAngle);


            var _Shape = Shape;
            _Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            _Shape.AddArc(Width - _RadiusUpperRight - 1, 0, _RadiusUpperRight, _RadiusUpperRight, 270, 90);
            _Shape.AddArc(Width - _RadiusBottomRight - 1, Height - _RadiusBottomRight - 1, _RadiusBottomRight, _RadiusBottomRight, 0, 90);
            _Shape.AddArc(0, 0 + Height - _RadiusBottomLeft - 1, _RadiusBottomLeft, _RadiusBottomLeft, 90, 90);
            _Shape.CloseAllFigures();

            g.FillPath(linearGradientBrush, Shape);
            g.DrawPath(new Pen(borderColor, borderWidth), Shape);

        }

        #endregion

        #endregion






        #region Include in Private Field

        /// <summary>
        /// The allow transparency
        /// </summary>
        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow transparency].
        /// </summary>
        /// <value><c>true</c> if [allow transparency]; otherwise, <c>false</c>.</value>
        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion



        #region Include in Paint

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        /// <summary>
        /// Makes the transparent.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="g">The g.</param>
        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion



    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitCardDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitCardDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitCardDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitCardSmartTagActionList(this.Component));
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
            Properties.Remove("Font");
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
    /// Class ZeroitCardSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitCardSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitCard colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCardSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitCardSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitCard;

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
        /// Gets or sets the colors.
        /// </summary>
        /// <value>The colors.</value>
        public Color[] Colors
        {
            get
            {
                return colUserControl.Colors;
            }
            set
            {
                GetPropertyByName("Colors").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text header.
        /// </summary>
        /// <value>The text header.</value>
        public string TextHeader
        {
            get
            {
                return colUserControl.TextHeader;
            }
            set
            {
                GetPropertyByName("TextHeader").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the content of the text.
        /// </summary>
        /// <value>The content of the text.</value>
        public string TextContent
        {
            get
            {
                return colUserControl.TextContent;
            }
            set
            {
                GetPropertyByName("TextContent").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text footer.
        /// </summary>
        /// <value>The text footer.</value>
        public string TextFooter
        {
            get
            {
                return colUserControl.TextFooter;
            }
            set
            {
                GetPropertyByName("TextFooter").SetValue(colUserControl, value);
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
        /// Gets or sets the corner upper left.
        /// </summary>
        /// <value>The corner upper left.</value>
        public int CornerUpperLeft
        {
            get
            {
                return colUserControl.CornerUpperLeft;
            }
            set
            {
                GetPropertyByName("CornerUpperLeft").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the corner upper right.
        /// </summary>
        /// <value>The corner upper right.</value>
        public int CornerUpperRight
        {
            get
            {
                return colUserControl.CornerUpperRight;
            }
            set
            {
                GetPropertyByName("CornerUpperRight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the corner bottom left.
        /// </summary>
        /// <value>The corner bottom left.</value>
        public int CornerBottomLeft
        {
            get
            {
                return colUserControl.CornerBottomLeft;
            }
            set
            {
                GetPropertyByName("CornerBottomLeft").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the corner bottom right.
        /// </summary>
        /// <value>The corner bottom right.</value>
        public int CornerBottomRight
        {
            get
            {
                return colUserControl.CornerBottomRight;
            }
            set
            {
                GetPropertyByName("CornerBottomRight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient angle.
        /// </summary>
        /// <value>The gradient angle.</value>
        public float GradientAngle
        {
            get
            {
                return colUserControl.GradientAngle;
            }
            set
            {
                GetPropertyByName("GradientAngle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the header font.
        /// </summary>
        /// <value>The header font.</value>
        public Font HeaderFont
        {
            get
            {
                return colUserControl.HeaderFont;
            }
            set
            {
                GetPropertyByName("HeaderFont").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the content font.
        /// </summary>
        /// <value>The content font.</value>
        public Font ContentFont
        {
            get
            {
                return colUserControl.ContentFont;
            }
            set
            {
                GetPropertyByName("ContentFont").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the footer font.
        /// </summary>
        /// <value>The footer font.</value>
        public Font FooterFont
        {
            get
            {
                return colUserControl.FooterFont;
            }
            set
            {
                GetPropertyByName("FooterFont").SetValue(colUserControl, value);
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
                     
            
            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("Colors",
                                 "Colors", "Appearance",
                                 "Sets the various colors for the card."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "BorderColor", "Appearance",
                                 "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("GradientAngle",
                                 "Gradient Angle", "Appearance",
                                 "Sets the gradient angle."));
            
            items.Add(new DesignerActionPropertyItem("CornerUpperLeft",
                                 "Corner Upper Left", "Appearance",
                                 "Sets the corner upper-left curve."));

            items.Add(new DesignerActionPropertyItem("CornerUpperRight",
                                 "Corner Upper Right", "Appearance",
                                 "Sets the corner upper-right curve."));

            items.Add(new DesignerActionPropertyItem("CornerBottomLeft",
                                 "Corner Bottom Left", "Appearance",
                                 "Sets the corner bottom-left curve."));

            items.Add(new DesignerActionPropertyItem("CornerBottomRight",
                                 "Corner Bottom Right", "Appearance",
                                 "Sets the corner bottom-right curve."));

            items.Add(new DesignerActionPropertyItem("TextHeader",
                                 "Header Text", "Appearance",
                                 "Sets the header text."));

            items.Add(new DesignerActionPropertyItem("HeaderFont",
                                 "Header Font", "Appearance",
                                 "Sets the header font."));

            items.Add(new DesignerActionPropertyItem("TextContent",
                                 "Content Text", "Appearance",
                                 "Sets the text for the content."));

            items.Add(new DesignerActionPropertyItem("ContentFont",
                                 "Content Font", "Appearance",
                                 "Sets the content font."));

            items.Add(new DesignerActionPropertyItem("TextFooter",
                                 "Footer Text", "Appearance",
                                 "Sets the text for the footer."));

            items.Add(new DesignerActionPropertyItem("FooterFont",
                                 "Footer Font", "Appearance",
                                 "Sets the footer font."));



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