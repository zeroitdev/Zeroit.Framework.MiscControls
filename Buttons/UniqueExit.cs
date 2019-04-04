using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region UniqueButtonExit    
    /// <summary>
    /// A class collection for rendering a button exit.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitControlBoxUniqueExitDesigner))]
    public class ZeroitControlBoxUniqueExit : Control
    {

        #region Variables

        private int MouseState;
        private GraphicsPath Shape;
        private LinearGradientBrush InactiveGB;
        private LinearGradientBrush PressedGB;
        private LinearGradientBrush PressedContourGB;
        private LinearGradientBrush HoverGB;
        private LinearGradientBrush HoverContourGB;
        private LinearGradientBrush InactiveContourGB;
        private Rectangle R1;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private Image _Image;
        private Size _ImageSize;
        private Color _BackgroundColor1;
        private Color _BackgroundColor2;
        private Color _BackgroundColorPressed1;
        private Color _BackgroundColorPressed2;
        private Color _BackgroundColorPressedContour1;
        private Color _BackgroundColorPressedContour2;
        private Color _BackgroundContour1;
        private Color _BackgroundContour2;
        private Color _HoverContour1;
        private Color _HoverContour2;
        private Color _HoverBackColor1;
        private Color _HoverBackColor2;
        private int _RadiusUpperLeft = 10;
        private int _RadiusUpperRight = 10;
        private int _RadiusBottomLeft = 10;
        private int _RadiusBottomRight = 10;
        private double _Angle = 90f;
        private float CorrectAngle;
        private StringAlignment _TextAlignment = StringAlignment.Center;
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;

        #endregion

        #region Image Designer

        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            PointF MyPoint = default(PointF);
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.X = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.X = Area.Width - ImageArea.Width - 2;
                    break;
            }

            switch (SF.LineAlignment)
            {
                case StringAlignment.Center:
                    MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.Y = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.Y = Area.Height - ImageArea.Height - 2;
                    break;
            }
            return MyPoint;
        }

        private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
        {
            StringFormat SF = new StringFormat();
            switch (_ContentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopCenter:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopLeft:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Far;
                    break;
            }
            return SF;
        }

        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return _Image; }
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
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        public StringAlignment TextAlignment
        {
            get { return this._TextAlignment; }
            set
            {
                this._TextAlignment = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets the size of the image.
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get { return _ImageSize; }
            set
            {
                _ImageSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image alignment.
        /// </summary>
        /// <value>The image alignment.</value>
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value>The background color1.</value>
        public Color BackgroundColor1
        {
            get { return this._BackgroundColor1; }
            set
            {
                this._BackgroundColor1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value>The background color2.</value>
        public Color BackgroundColor2
        {
            get { return this._BackgroundColor2; }
            set
            {
                this._BackgroundColor2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color when the control is pressed.
        /// </summary>
        /// <value>The background color pressed1.</value>
        public Color BackgroundColorPressed1
        {
            get { return this._BackgroundColorPressed1; }
            set
            {
                this._BackgroundColorPressed1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color when the control is pressed.
        /// </summary>
        /// <value>The background color pressed2.</value>
        public Color BackgroundColorPressed2
        {
            get { return this._BackgroundColorPressed2; }
            set
            {
                this._BackgroundColorPressed2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background border color when the control is pressed.
        /// </summary>
        /// <value>The background color pressed contour1.</value>
        public Color BackgroundColorPressedContour1
        {
            get { return this._BackgroundColorPressedContour1; }
            set
            {
                this._BackgroundColorPressedContour1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background border color when the control is pressed.
        /// </summary>
        /// <value>The background color pressed contour2.</value>
        public Color BackgroundColorPressedContour2
        {
            get { return this._BackgroundColorPressedContour2; }
            set
            {
                this._BackgroundColorPressedContour2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background hover color.
        /// </summary>
        /// <value>The back hover color1.</value>
        public Color BackHoverColor1
        {
            get { return this._HoverBackColor1; }
            set
            {
                this._HoverBackColor1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background hover color.
        /// </summary>
        /// <value>The back hover color2.</value>
        public Color BackHoverColor2
        {
            get { return this._HoverBackColor2; }
            set
            {
                this._HoverBackColor2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the hover border color.
        /// </summary>
        /// <value>The hover contour1.</value>
        public Color HoverContour1
        {
            get { return this._HoverContour1; }
            set
            {
                this._HoverContour1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the hover color.
        /// </summary>
        /// <value>The hover contour2.</value>
        public Color HoverContour2
        {
            get { return this._HoverContour2; }
            set
            {
                this._HoverContour2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background border color.
        /// </summary>
        /// <value>The background contour1.</value>
        public Color BackgroundContour1
        {
            get { return this._BackgroundContour1; }
            set
            {
                this._BackgroundContour1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background border color.
        /// </summary>
        /// <value>The background contour2.</value>
        public Color BackgroundContour2
        {
            get { return this._BackgroundContour2; }
            set
            {
                this._BackgroundContour2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// This changes the upper left radius of the button
        /// </summary>
        [Description("This changes the upper left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(int), "10"),
        Browsable(true)]
        public int Radius
        {
            get
            {
                return this._RadiusUpperLeft;
                return this._RadiusUpperRight;
                return this._RadiusBottomLeft;
                return this._RadiusBottomRight;
            }
            set
            {
                if (_RadiusUpperLeft == null && _RadiusUpperRight == null && _RadiusBottomLeft == null && _RadiusBottomRight == null)
                {
                    this._RadiusUpperLeft = 10;
                    this._RadiusUpperRight = 10;
                    this._RadiusBottomLeft = 10;
                    this._RadiusBottomRight = 10;

                }


                this._RadiusUpperLeft = value;
                this._RadiusUpperRight = value;
                this._RadiusBottomLeft = value;
                this._RadiusBottomRight = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper left radius of the button
        /// </summary>
        [Description("This changes the upper left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(int), "10"),
        Browsable(true)]
        public int RadiusUpperLeft
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
        [Description("This changes the upper right radius of the button"),
        Category("Appearance"), DefaultValue(typeof(int), "10"),
        Browsable(true)]
        public int RadiusUpperRight
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
        [Description("This changes the bottom left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(int), "10"),
        Browsable(true)]
        public int RadiusBottomLeft
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
        [Description("This changes the bottom right radius of the button"),
        Category("Appearance"), DefaultValue(typeof(int), "10"),
        Browsable(true)]
        public int RadiusBottomRight
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
        /// This changes the upper left radius of the button
        /// </summary>
        [Description("This changes the upper left radius of the button"),
        Category("Appearance"),
        Browsable(true)]
        public double Angle
        {
            get { return this._Angle; }
            set
            {
                if (_Angle == null)
                {
                    this._Angle = 30f;
                }

                this._Angle = value;
                CorrectAngle = DoubleToFloat(_Angle);

                this.Invalidate();



            }
        }


        public static float DoubleToFloat(double dValue)
        {
            if (float.IsPositiveInfinity(Convert.ToSingle(dValue)))
            {
                return float.MaxValue;
            }
            if (float.IsNegativeInfinity(Convert.ToSingle(dValue)))
            {
                return float.MinValue;
            }
            return Convert.ToSingle(dValue);
        }

        #endregion

        #region EventArgs

        protected override void OnMouseUp(MouseEventArgs e)
        {
            MouseState = 0;
            Invalidate();
            base.OnMouseUp(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            MouseState = 1;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            MouseState = 0;
            // [Inactive]
            Invalidate();
            // Update control
            base.OnMouseLeave(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            MouseState = 2;
            Invalidate();
            base.OnMouseHover(e);
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //Application.Exit();
                Environment.Exit(0);
            }

            Invalidate();
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitControlBoxUniqueExit"/> class.
        /// </summary>
        public ZeroitControlBoxUniqueExit()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 14);
            ForeColor = Color.White;
            Size = new Size(24, 24);
            _TextAlignment = StringAlignment.Center;

            Anchor = AnchorStyles.Top | AnchorStyles.Right;


        } 

        #endregion

        #region Methods and Overrides
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            if (Width > 0 && Height > 0)
            {
                Shape = new GraphicsPath();
                R1 = new Rectangle(0, 0, Width, Height);

                // Button Background Colors
                InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColor1, _BackgroundColor2, CorrectAngle);
                InactiveContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundContour1, _BackgroundContour2, CorrectAngle);
                PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColorPressed1, _BackgroundColorPressed2, CorrectAngle);
                PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), BackgroundColorPressedContour1, BackgroundColorPressedContour2, CorrectAngle);
                HoverGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverBackColor1, _HoverBackColor2, CorrectAngle);
                HoverContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverContour1, _HoverContour2, CorrectAngle);
                P1 = new Pen(InactiveContourGB);
                P3 = new Pen(PressedContourGB);
                P2 = new Pen(HoverContourGB);
            }

            // Button Radius iTalk
            //var _Shape = Shape;
            //_Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            //_Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            //_Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            //_Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            //_Shape.CloseAllFigures();


            //Button Radius 
            var _Shape = Shape;
            _Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            _Shape.AddArc(Width - _RadiusUpperRight - 1, 0, _RadiusUpperRight, _RadiusUpperRight, 270, 90);
            _Shape.AddArc(Width - _RadiusBottomRight - 1, Height - _RadiusBottomRight - 1, _RadiusBottomRight, _RadiusBottomRight, 0, 90);
            _Shape.AddArc(0, 0 + Height - _RadiusBottomLeft - 1, _RadiusBottomLeft, _RadiusBottomLeft, 90, 90);
            _Shape.CloseAllFigures();

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var _G = e.Graphics;
            _G.SmoothingMode = SmoothingMode.HighQuality;

            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

            switch (MouseState)
            {
                case 0:
                    _G.FillPath(InactiveGB, Shape);
                    _G.DrawPath(P1, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
                case 1:
                    _G.FillPath(PressedGB, Shape);
                    _G.DrawPath(P3, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;

                case 2:
                    _G.FillPath(HoverGB, Shape);
                    _G.DrawPath(P2, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
            }

            if (DesignMode)
            {
                Font = new Font("Tahoma", 10);
                Text = "X";
            }

            #region Remove code if it causes trouble
            //if (Width > 0 && Height > 0)
            //{
            Shape = new GraphicsPath();
            R1 = new Rectangle(0, 0, Width, Height);

            // Button Background Colors
            InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColor1, _BackgroundColor2, CorrectAngle);
            InactiveContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundContour1, _BackgroundContour2, CorrectAngle);
            PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColorPressed1, _BackgroundColorPressed2, CorrectAngle);
            PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), BackgroundColorPressedContour1, BackgroundColorPressedContour2, CorrectAngle);
            HoverGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverBackColor1, _HoverBackColor2, CorrectAngle);
            HoverContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverContour1, _HoverContour2, CorrectAngle);
            P1 = new Pen(InactiveContourGB);
            P3 = new Pen(PressedContourGB);
            P2 = new Pen(HoverContourGB);
            //}

            // Button Radius
            //var _Shape = Shape;
            //_Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            //_Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            //_Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            //_Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            //_Shape.CloseAllFigures();


            //Button Radius 
            var _Shape = Shape;
            _Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            _Shape.AddArc(Width - _RadiusUpperRight - 1, 0, _RadiusUpperRight, _RadiusUpperRight, 270, 90);
            _Shape.AddArc(Width - _RadiusBottomRight - 1, Height - _RadiusBottomRight - 1, _RadiusBottomRight, _RadiusBottomRight, 0, 90);
            _Shape.AddArc(0, 0 + Height - _RadiusBottomLeft - 1, _RadiusBottomLeft, _RadiusBottomLeft, 90, 90);
            _Shape.CloseAllFigures();
            #endregion

            base.OnPaint(e);
        } 
        #endregion
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitControlBoxUniqueExitDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitControlBoxUniqueExitSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    public class ZeroitControlBoxUniqueExitSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        private ZeroitControlBoxUniqueExit colUserControl;


        private DesignerActionUIService designerActionUISvc = null;


        public ZeroitControlBoxUniqueExitSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitControlBoxUniqueExit;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
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

        public StringAlignment TextAlignment
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

        public ContentAlignment ImageAlign
        {
            get
            {
                return colUserControl.ImageAlign;
            }
            set
            {
                GetPropertyByName("ImageAlign").SetValue(colUserControl, value);
            }
        }

        public Color BackgroundColor1
        {
            get
            {
                return colUserControl.BackgroundColor1;
            }
            set
            {
                GetPropertyByName("BackgroundColor1").SetValue(colUserControl, value);
            }
        }

        public Color BackgroundColor2
        {
            get
            {
                return colUserControl.BackgroundColor2;
            }
            set
            {
                GetPropertyByName("BackgroundColor2").SetValue(colUserControl, value);
            }
        }

        public Color BackgroundColorPressed1
        {
            get
            {
                return colUserControl.BackgroundColorPressed1;
            }
            set
            {
                GetPropertyByName("BackgroundColorPressed1").SetValue(colUserControl, value);
            }
        }

        public Color BackgroundColorPressed2
        {
            get
            {
                return colUserControl.BackgroundColorPressed2;
            }
            set
            {
                GetPropertyByName("BackgroundColorPressed2").SetValue(colUserControl, value);
            }
        }

        public Color BackgroundColorPressedContour1
        {
            get
            {
                return colUserControl.BackgroundColorPressedContour1;
            }
            set
            {
                GetPropertyByName("BackgroundColorPressedContour1").SetValue(colUserControl, value);
            }
        }

        public Color BackgroundColorPressedContour2
        {
            get
            {
                return colUserControl.BackgroundColorPressedContour2;
            }
            set
            {
                GetPropertyByName("BackgroundColorPressedContour2").SetValue(colUserControl, value);
            }
        }

        public Color BackHoverColor1
        {
            get
            {
                return colUserControl.BackHoverColor1;
            }
            set
            {
                GetPropertyByName("BackHoverColor1").SetValue(colUserControl, value);
            }
        }

        public Color BackHoverColor2
        {
            get
            {
                return colUserControl.BackHoverColor2;
            }
            set
            {
                GetPropertyByName("BackHoverColor2").SetValue(colUserControl, value);
            }
        }

        public Color HoverContour1
        {
            get
            {
                return colUserControl.HoverContour1;
            }
            set
            {
                GetPropertyByName("HoverContour1").SetValue(colUserControl, value);
            }
        }

        public Color HoverContour2
        {
            get
            {
                return colUserControl.HoverContour2;
            }
            set
            {
                GetPropertyByName("HoverContour2").SetValue(colUserControl, value);
            }
        }

        public Color BackgroundContour1
        {
            get
            {
                return colUserControl.BackgroundContour1;
            }
            set
            {
                GetPropertyByName("BackgroundContour1").SetValue(colUserControl, value);
            }
        }

        public Color BackgroundContour2
        {
            get
            {
                return colUserControl.BackgroundContour2;
            }
            set
            {
                GetPropertyByName("BackgroundContour2").SetValue(colUserControl, value);
            }
        }

        public int Radius
        {
            get
            {
                return colUserControl.Radius;
            }
            set
            {
                GetPropertyByName("Radius").SetValue(colUserControl, value);
            }
        }

        public int RadiusUpperLeft
        {
            get
            {
                return colUserControl.RadiusUpperLeft;
            }
            set
            {
                GetPropertyByName("RadiusUpperLeft").SetValue(colUserControl, value);
            }
        }

        public int RadiusUpperRight
        {
            get
            {
                return colUserControl.RadiusUpperRight;
            }
            set
            {
                GetPropertyByName("RadiusUpperRight").SetValue(colUserControl, value);
            }
        }

        public int RadiusBottomLeft
        {
            get
            {
                return colUserControl.RadiusBottomLeft;
            }
            set
            {
                GetPropertyByName("RadiusBottomLeft").SetValue(colUserControl, value);
            }
        }

        public int RadiusBottomRight
        {
            get
            {
                return colUserControl.RadiusBottomRight;
            }
            set
            {
                GetPropertyByName("RadiusBottomRight").SetValue(colUserControl, value);
            }
        }

        public double Angle
        {
            get
            {
                return colUserControl.Angle;
            }
            set
            {
                GetPropertyByName("Angle").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region DesignerActionItemCollection

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Sets the foreground color."));

            items.Add(new DesignerActionPropertyItem("Image",
                                 "Image", "Appearance",
                                 "Set the image of the control."));

            items.Add(new DesignerActionPropertyItem("TextAlignment",
                                 "Text Alignment", "Appearance",
                                 "Sets the text alignment of the control."));

            items.Add(new DesignerActionPropertyItem("ImageAlign",
                                 "Image Align", "Appearance",
                                 "Sets the image alignment."));

            items.Add(new DesignerActionPropertyItem("BackgroundColor1",
                                 "Background Color1", "Appearance",
                                 "Sets the inactive background color."));

            items.Add(new DesignerActionPropertyItem("BackgroundColor2",
                                 "Background Color2", "Appearance",
                                 "Sets the inactive background color."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorPressed1",
                                 "Background ColorPressed1", "Appearance",
                                 "Sets the background color when pressed."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorPressed2",
                                 "Background Color Pressed2", "Appearance",
                                 "Sets the background color when pressed."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorPressedContour1",
                                 "Background Color Pressed Contour1", "Appearance",
                                 "Sets the border color when pressed."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorPressedContour2",
                                 "Background Color Pressed Contour2", "Appearance",
                                 "Sets the border color when pressed."));

            items.Add(new DesignerActionPropertyItem("BackHoverColor1",
                                 "Back Hover Color1", "Appearance",
                                 "Sets the background color when hovered."));

            items.Add(new DesignerActionPropertyItem("BackHoverColor2",
                                 "Back Hover Color2", "Appearance",
                                 "Sets the background color when hovered."));

            items.Add(new DesignerActionPropertyItem("HoverContour1",
                                 "Hover Contour1", "Appearance",
                                 "Sets the border color when hovered."));

            items.Add(new DesignerActionPropertyItem("HoverContour2",
                                 "Hover Contour2", "Appearance",
                                 "Sets the border color when hovered."));

            items.Add(new DesignerActionPropertyItem("BackgroundContour1",
                                 "Background Contour1", "Appearance",
                                 "Sets the inactive border color."));

            items.Add(new DesignerActionPropertyItem("BackgroundContour2",
                                 "Background Contour2", "Appearance",
                                 "Sets the inactive border color."));

            items.Add(new DesignerActionPropertyItem("Radius",
                                 "Radius", "Appearance",
                                 "Sets the corner curve for all sides."));

            items.Add(new DesignerActionPropertyItem("RadiusUpperLeft",
                                 "Radius Upper Left", "Appearance",
                                 "Sets the upper-left corner curve."));

            items.Add(new DesignerActionPropertyItem("RadiusUpperRight",
                                 "Radius Upper Right", "Appearance",
                                 "Sets the upper-right corner curve."));

            items.Add(new DesignerActionPropertyItem("RadiusBottomLeft",
                                 "Radius Bottom Left", "Appearance",
                                 "Sets the bottom-left corner curve."));

            items.Add(new DesignerActionPropertyItem("RadiusBottomRight",
                                 "Radius Bottom Right", "Appearance",
                                 "Sets the bottom-right corner curve."));

            items.Add(new DesignerActionPropertyItem("Angle",
                                 "Angle", "Appearance",
                                 "Sets the color angle."));



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
