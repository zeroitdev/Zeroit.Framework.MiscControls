// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ShapeControl.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region Shape Control

    /// <summary>
    /// Enum representin the Line Direction for <c><see cref="ZeroitCustomControl" /></c>.
    /// </summary>
    public enum LineDirection
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The right up
        /// </summary>
        RightUp,
        /// <summary>
        /// The right down
        /// </summary>
        RightDown,
        /// <summary>
        /// The left up
        /// </summary>
        LeftUp,
        /// <summary>
        /// The left down
        /// </summary>
        LeftDown

    }

    /// <summary>
    /// Enum representing the type of connector for <c><see cref="ZeroitCustomControl" /></c>.
    /// </summary>
    public enum ConnecterType
    {
        /// <summary>
        /// The top
        /// </summary>
        Top,
        /// <summary>
        /// The right
        /// </summary>
        Right,
        /// <summary>
        /// The bottom
        /// </summary>
        Bottom,
        /// <summary>
        /// The left
        /// </summary>
        Left,
        /// <summary>
        /// The center
        /// </summary>
        Center
    }

    //All the defined shape type    
    /// <summary>
    /// Enum representing the custom shape to draw for <c><see cref="ZeroitCustomControl" /></c>.
    /// </summary>
    public enum ShapeType
    {
        /// <summary>
        /// The rectangle
        /// </summary>
        Rectangle,
        /// <summary>
        /// The rounded rectangle
        /// </summary>
        RoundedRectangle,
        /// <summary>
        /// The diamond
        /// </summary>
        Diamond,
        /// <summary>
        /// The ellipse
        /// </summary>
        Ellipse,
        /// <summary>
        /// The triangle up
        /// </summary>
        TriangleUp,
        /// <summary>
        /// The triangle down
        /// </summary>
        TriangleDown,
        /// <summary>
        /// The triangle left
        /// </summary>
        TriangleLeft,
        /// <summary>
        /// The triangle right
        /// </summary>
        TriangleRight,
        /// <summary>
        /// The ballon ne
        /// </summary>
        BallonNE,
        /// <summary>
        /// The ballon nw
        /// </summary>
        BallonNW,
        /// <summary>
        /// The ballon sw
        /// </summary>
        BallonSW,
        /// <summary>
        /// The ballon se
        /// </summary>
        BallonSE,
        /// <summary>
        /// The custom polygon
        /// </summary>
        CustomPolygon,
        /// <summary>
        /// The custom pie
        /// </summary>
        CustomPie,
        /// <summary>
        /// The line down
        /// </summary>
        LineDown,
        /// <summary>
        /// The line up
        /// </summary>
        LineUp,
        /// <summary>
        /// The line horizontal
        /// </summary>
        LineHorizontal,
        /// <summary>
        /// The line vertical
        /// </summary>
        LineVertical

    }

    /// <summary>
    /// A class collection for rendering a custom control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitCustomControlDesigner))]
    public class ZeroitCustomControl : System.Windows.Forms.Control
    {

        #region Private Fields
        /// <summary>
        /// The shapestorageloadfile
        /// </summary>
        private string _shapestorageloadfile = "";
        /// <summary>
        /// The shapestoragesavefile
        /// </summary>
        private string _shapestoragesavefile = "";

        /// <summary>
        /// The custompath
        /// </summary>
        private GraphicsPath _custompath = new GraphicsPath();
        /// <summary>
        /// The components
        /// </summary>
        private IContainer components;

        /// <summary>
        /// The connector
        /// </summary>
        ConnecterType _connector = ConnecterType.Center;

        /// <summary>
        /// The direction
        /// </summary>
        LineDirection _direction = LineDirection.None;
        /// <summary>
        /// The shape
        /// </summary>
        ShapeType _shape = ShapeType.Rectangle;
        /// <summary>
        /// The borderstyle
        /// </summary>
        DashStyle _borderstyle = DashStyle.Solid;
        /// <summary>
        /// The bordercolor
        /// </summary>
        Color _bordercolor = Color.FromArgb(255, 255, 0, 0);
        /// <summary>
        /// The borderwidth
        /// </summary>
        int _borderwidth = 3;
        /// <summary>
        /// The outline
        /// </summary>
        GraphicsPath _outline = new GraphicsPath();
        /// <summary>
        /// The usegradient
        /// </summary>
        bool _usegradient = false;
        /// <summary>
        /// The blink
        /// </summary>
        bool _blink = false;
        /// <summary>
        /// The vibrate
        /// </summary>
        bool _vibrate = false;
        /// <summary>
        /// The voffseted
        /// </summary>
        bool _voffseted = false;

        /// <summary>
        /// The animateborder
        /// </summary>
        bool _animateborder = false;
        /// <summary>
        /// The prevborderwidth
        /// </summary>
        int _prevborderwidth = 3;
        /// <summary>
        /// The prevbordercolor
        /// </summary>
        Color _prevbordercolor = Color.Red;
        /// <summary>
        /// The btoggled
        /// </summary>
        bool _btoggled = false;
        /// <summary>
        /// The static ds
        /// </summary>
        int _static_ds = 0;

        /// <summary>
        /// The prevborderstyle
        /// </summary>
        DashStyle _prevborderstyle = DashStyle.Solid;


        /// <summary>
        /// The centercolor
        /// </summary>
        Color _centercolor = Color.FromArgb(100, 255, 0, 0);
        /// <summary>
        /// The surroundcolor
        /// </summary>
        Color _surroundcolor = Color.FromArgb(100, 0, 255, 255);
        /// <summary>
        /// The timer1
        /// </summary>
        private System.Windows.Forms.Timer timer1;
        /// <summary>
        /// The timer2
        /// </summary>
        private System.Windows.Forms.Timer timer2;
        /// <summary>
        /// The tag2
        /// </summary>
        string _tag2 = "";
        /// <summary>
        /// The timer3
        /// </summary>
        private System.Windows.Forms.Timer timer3;
        /// <summary>
        /// The bm
        /// </summary>
        Bitmap _bm; //for shapeimage property
        /// <summary>
        /// The bmtexture
        /// </summary>
        Bitmap _bmtexture; //for shapeimagetexture property
        /// <summary>
        /// The shapeimagerotation
        /// </summary>
        private int _shapeimagerotation = 0;


        #endregion

        #region Public Properties

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


        /// <summary>
        /// Gets the outline.
        /// </summary>
        /// <value>The outline.</value>
        public GraphicsPath Outline
        {
            get { return _outline; }
        }

        /// <summary>
        /// Gets or sets the shape storage load file.
        /// </summary>
        /// <value>The shape storage load file.</value>
        [Category("Shape"), Description("Shape Storage Load File")]
        [EditorAttribute(typeof(FileLoadEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string ShapeStorageLoadFile
        {
            set
            {


                LoadFromFile(this, value, true);

            }

            get
            {
                return _shapestorageloadfile;
            }
        }

        /// <summary>
        /// Gets or sets the shape storage save file.
        /// </summary>
        /// <value>The shape storage save file.</value>
        [Category("Shape"), Description("Shape Storage Save File")]
        [EditorAttribute(typeof(FileSaveEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string ShapeStorageSaveFile
        {
            set
            {
                if (value.Length < 8) return;
                if (value.ToUpper().IndexOf(".SHP.JPG") != value.Length - 8)
                {
                    SaveToFile(this, value + ".shp.jpg", true);
                }
                else
                    SaveToFile(this, value, true);

            }

            get
            {
                return _shapestoragesavefile;
            }
        }

        /// <summary>
        /// Gets or sets the connector.
        /// </summary>
        /// <value>The connector.</value>
        [Category("Shape"), Description("Connect at")]
        public ConnecterType Connector
        {
            get { return _connector; }
            set { _connector = value; }
        }

        /// <summary>
        /// Gets or sets the line direction.
        /// </summary>
        /// <value>The line direction.</value>
        [Category("Shape"), Description("For Directional Line")]
        public LineDirection Direction
        {
            get { return _direction; }
            set
            {
                _direction = value;

                OnResize(null);
            }
        }

        /// <summary>
        /// Gets or sets the tag. An additional user-defined data
        /// </summary>
        /// <value>The tag2.</value>
        [Category("Shape"), Description("Additional user-defined data")]
        public string Tag2
        {

            get { return _tag2; }
            set
            {
                _tag2 = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to animate the control's border.
        /// </summary>
        /// <value><c>true</c> if [animate border]; otherwise, <c>false</c>.</value>
        [Category("Shape"), Description("Causes the control border to animate")]
        public bool AnimateBorder
        {
            get { return _animateborder; }
            set
            {

                _animateborder = value;
                if (_animateborder)
                {
                    //save all the border
                    _prevborderstyle = _borderstyle;
                    _prevborderwidth = _borderwidth;
                    _prevbordercolor = _bordercolor;

                    if (_borderwidth == 0)
                        _borderwidth = 3;
                    int a, r, g, b;
                    a = _bordercolor.A;
                    r = _bordercolor.R;
                    g = _bordercolor.G;
                    b = _bordercolor.B;

                    _bordercolor = Color.FromArgb(255, r, g, b);


                }
                else
                {

                    _borderwidth = _prevborderwidth;
                    _bordercolor = _prevbordercolor;
                    this.BorderStyle = _prevborderstyle;
                }

                timer3.Enabled = _animateborder;

            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitCustomControl" /> blinks.
        /// </summary>
        /// <value><c>true</c> if blink; otherwise, <c>false</c>.</value>
        [Category("Shape"), Description("Causes the control to blink")]
        public bool Blink
        {
            get { return _blink; }
            set
            {

                _blink = value;
                timer1.Enabled = _blink;
                if (!_blink) this.Visible = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitCustomControl" /> vibrates.
        /// </summary>
        /// <value><c>true</c> if vibrate; otherwise, <c>false</c>.</value>
        [Category("Shape"), Description("Causes the control to vibrate")]
        public bool Vibrate
        {
            get { return _vibrate; }
            set
            {

                _vibrate = value;
                timer2.Enabled = _vibrate;
                if (!_vibrate)
                    if (_voffseted) { this.Top += 5; _voffseted = false; }
            }
        }

        /// <summary>
        /// Gets or sets the shape image rotation.
        /// This represents rotation angle in deg for ShapeImage\nValid values between -180 and 180
        /// </summary>
        /// <value>The shape image rotation.</value>
        [Category("Shape"), Description("Rotation angle in deg for ShapeImage\nValid values between -180 and 180")]
        public int ShapeImageRotation
        {
            get
            {
                return _shapeimagerotation;
            }

            set
            {
                if (value >= -180 && value <= 180)
                {
                    _shapeimagerotation = value;
                    if (_bm != null)
                    {
                        OnResize(null);

                    }
                }

            }
        }

        /// <summary>
        /// Gets or sets the shape of the image.
        /// </summary>
        /// <value>The shape image.</value>
        [Category("Shape"), Description("Background Image to define outline")]
        public Image ShapeImage
        {
            get
            {
                return _bm;
            }
            set
            {


                if (value != null)
                {
                    _bm = (Bitmap)value.Clone();
                    Width = 150;
                    Height = 150;
                    OnResize(null);
                }
                else
                {
                    if (_bm != null)
                        _bm = null;

                    OnResize(null);
                }
            }
        }

        /// <summary>
        /// Gets or sets the shape's image texture.
        /// </summary>
        /// <value>The shape image texture.</value>
        [Category("Shape"), Description("Texture Image for ShapeImage")]
        public Image ShapeImageTexture
        {
            get
            {
                return _bmtexture;
            }
            set
            {


                if (value != null)
                {
                    _bmtexture = (Bitmap)value.Clone();
                    OnResize(null);
                }
                else
                {
                    if (_bmtexture != null)
                        _bmtexture = null;

                    OnResize(null);
                }
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [Category("Shape"), Description("Text to display")]
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

        //Overide the BackColor Property to be associated with our custom editor        
        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Category("Shape"), Description("Back Color")]
        [BrowsableAttribute(true)]
        [EditorAttribute(typeof(ColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value; this.Refresh();

            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use gradient to fill the shape.
        /// </summary>
        /// <value><c>true</c> if use gradient; otherwise, <c>false</c>.</value>
        [Category("Shape"), Description("Using Gradient to fill Shape")]
        public bool UseGradient
        {
            get { return _usegradient; }
            set { _usegradient = value; this.Refresh(); }
        }

        //For Gradient Rendering, this is the color at the center of the shape        
        /// <summary>
        /// Gets or sets the center color.
        /// </summary>
        /// <value>The color of the center.</value>
        [Category("Shape"), Description("Color at center")]
        [BrowsableAttribute(true)]
        [EditorAttribute(typeof(ColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Color CenterColor
        {
            get { return _centercolor; }
            set { _centercolor = value; this.Refresh(); }
        }

        //For Gradient Rendering, this is the color at the edges of the shape        
        /// <summary>
        /// Gets or sets the color at the edges of the Shape.
        /// </summary>
        /// <value>The color at the edges of the Shape.</value>
        [Category("Shape"), Description("Color at the edges of the Shape")]
        [BrowsableAttribute(true)]
        [EditorAttribute(typeof(ColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Color SurroundColor
        {
            get { return _surroundcolor; }
            set { _surroundcolor = value; this.Refresh(); }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        [Category("Shape"), Description("Border Width")]
        public int BorderWidth
        {
            get
            {

                return _borderwidth;

            }
            set
            {
                _borderwidth = value;
                if (_borderwidth < 0) _borderwidth = 0;
                OnResize(null);
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Category("Shape"), Description("Border Color")]
        [BrowsableAttribute(true)]
        [EditorAttribute(typeof(ColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Color BorderColor
        {
            get { return _bordercolor; }
            set { _bordercolor = value; this.Refresh(); }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value>The border style.</value>
        [Category("Shape"), Description("Border Style")]
        public DashStyle BorderStyle
        {
            get { return _borderstyle; }
            set { _borderstyle = value; this.Refresh(); }
        }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        [Category("Shape"), Description("Select Shape")]
        [BrowsableAttribute(true)]
        [EditorAttribute(typeof(ShapeTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ShapeType Shape
        {
            get { return _shape; }
            set
            {
                _shape = value;
                if (_shape == ShapeType.LineVertical ||
                    _shape == ShapeType.LineHorizontal ||
                    _shape == ShapeType.LineUp ||
                    _shape == ShapeType.LineDown)
                    ForeColor = Color.FromArgb(0, 255, 255, 255);

                if (_shape == ShapeType.LineVertical)
                    this.Width = 20;
                if (_shape == ShapeType.LineHorizontal)
                    this.Height = 20;
                OnResize(null);
            }
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCustomControl" /> class.
        /// </summary>
        public ZeroitCustomControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            this.DoubleBuffered = true;
            //Using of Double Buffer allow for smooth rendering 
            //minizing flickering
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.DoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);

            //set the default backcolor and font
            this.BackColor = Color.FromArgb(0, 255, 255, 255);
            this.Font = new Font("Arial", 12, FontStyle.Bold);
            this.Width = 100;
            this.Height = 100;
            this.Text = "";
        }

        #endregion

        #region Component Designer Generated code

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // CustomControl
            // 
            this.TextChanged += new System.EventHandler(this.ShapeControl_TextChanged);
            this.ResumeLayout(false);


        }

        #endregion

        #endregion

        #region Events and Timer Events

        /// <summary>
        /// Handles the TextChanged event of the ShapeControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ShapeControl_TextChanged(object sender, System.EventArgs e)
        {
            this.Refresh();
        }

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
        }

        /// <summary>
        /// Handles the Tick event of the timer2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!_vibrate) return;
            _voffseted = !_voffseted;
            this.Top = _voffseted ? this.Top - 5 : this.Top + 5;


        }

        /// <summary>
        /// Handles the Tick event of the timer3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer3_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            _btoggled = !_btoggled;
        }


        #endregion

        #region Overrides
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            if (this.Width < 2 * _borderwidth)
            {
                this.Width = 2 * _borderwidth;
                return;

            }
            if (this.Height < 2 * _borderwidth)
            {
                this.Height = 2 * _borderwidth;
                return;

            }

            //    if (this.Width <= 0 || this.Height <= 0) return;

            if (_bm == null)
            {

                _outline = new GraphicsPath();

                updateOutline(ref _outline, _shape, this.Width, this.Height, this.BorderWidth);
            }
            else
            {
                Bitmap bm = (Bitmap)_bm.Clone();
                Bitmap bm2 = new Bitmap(Width, Height);
                //  System.Diagnostics.Debug.WriteLine(bm2.Width + "," + bm2.Height);
                Graphics g = Graphics.FromImage(bm2);

                Matrix _m = new Matrix();

                if (_shapeimagerotation != 0)
                {

                    _m.RotateAt(_shapeimagerotation, new PointF(this.Width / 2, this.Height / 2));
                    //  g.Transform = _m;
                }

                // Graphics.FromImage(bm2).DrawImage(bm, new RectangleF(0, 0, bm2.Width, bm2.Height), new RectangleF(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel);
                g.DrawImage(bm, new RectangleF(0, 0, bm2.Width, bm2.Height), new RectangleF(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel);
                CTraceOuline trace = new CTraceOuline();
                string s = trace.TraceOutlineN(bm2, 0, bm2.Height / 2, bm2.Width / 2, Color.Black, Color.White, true, 1);
                if (s == "") return;

                Point[] p = trace.StringOutline2Polygon(s);

                _outline = new GraphicsPath();

                _outline.AddPolygon(p);
                _outline.Transform(_m);

                if (_bmtexture != null)
                {
                    g.Transform = _m;
                    g.DrawImage(_bmtexture, new RectangleF(0, 0, bm2.Width, bm2.Height), new RectangleF(0, 0, _bmtexture.Width, _bmtexture.Height), GraphicsUnit.Pixel);

                }
                g.Dispose();

                if (_bmtexture != null)
                {
                    this.BackgroundImage = bm2;

                }
                else
                {
                    this.BackgroundImage = null;
                    this.Refresh();
                }

                this.Region = new Region(_outline);

            }

            if (_outline != null && _bm == null)
            {
                //these require widening
                if (
                    this.Shape == ShapeType.LineDown ||
                    this.Shape == ShapeType.LineUp ||
                    this.Shape == ShapeType.LineHorizontal ||
                    this.Shape == ShapeType.LineVertical ||
                    this.Shape == ShapeType.Rectangle
                    )
                {
                    //border width to widen by
                    int bw = (this.Shape == ShapeType.Rectangle) ? 1 : _borderwidth;

                    GraphicsPath tmpoutline = (GraphicsPath)_outline.Clone();

                    Pen p = new Pen(_bordercolor, bw);

                    //line is always generated from left to right

                    //defaults no direction caps
                    //leftmost or topmost for vertical line
                    p.StartCap = LineCap.Round;
                    //rigtmost or bottommost for vertical line
                    p.EndCap = LineCap.Round;

                    if (_direction != LineDirection.None)
                        switch (this.Shape)
                        {
                            //case ShapeType.LineHorizontal:
                            //    //
                            //    if (_direction == LineDirection.LeftDown || _direction == LineDirection.LeftUp)
                            //        p.StartCap = LineCap.ArrowAnchor;
                            //    else
                            //        p.EndCap = LineCap.ArrowAnchor;
                            //    break;

                            case ShapeType.LineVertical:
                                if (_direction == LineDirection.LeftUp || _direction == LineDirection.RightUp)
                                    p.StartCap = LineCap.ArrowAnchor;
                                else
                                    p.EndCap = LineCap.ArrowAnchor;

                                break;

                            case ShapeType.LineHorizontal:
                            case ShapeType.LineUp:
                            case ShapeType.LineDown:
                                if (_direction == LineDirection.LeftUp || _direction == LineDirection.LeftDown)
                                    p.StartCap = LineCap.ArrowAnchor;
                                else
                                    p.EndCap = LineCap.ArrowAnchor;

                                break;
                        }



                    try
                    {
                        tmpoutline.Widen(p);
                    }
                    catch
                    {
                    }


                    if (this.Shape != ShapeType.Rectangle)
                    {
                        //widen region
                        this.Region = new Region(tmpoutline);
                        //original region
                        Region org = new Region(_outline);
                        //add up both 
                        this.Region.Union(org);
                    }
                    else
                    {
                        _outline.AddPath(tmpoutline, true);
                        _outline.CloseAllFigures();
                        this.Region = new Region(_outline);
                    }

                }
                else
                {
                    this.Region = new Region(_outline);
                }

            }

            this.Refresh();
            base.OnResize(e);
        }

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="pe">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.SmoothingMode = smoothing;

            //Rendering with Gradient
            if (_usegradient)
            {
                try
                {
                    PathGradientBrush br = new PathGradientBrush(this._outline);
                    br.CenterColor = this._centercolor;
                    br.SurroundColors = new Color[] { this._surroundcolor };
                    pe.Graphics.FillPath(br, this._outline);
                }
                catch { }
            }

            //Rendering with Border
            if (_borderwidth > 0)
            {
                Pen p = new Pen(_bordercolor, _borderwidth * 2);

                //setting for lines
                if (this.Shape == ShapeType.LineDown ||
                   this.Shape == ShapeType.LineUp ||
                   this.Shape == ShapeType.LineHorizontal ||
                   this.Shape == ShapeType.LineVertical)
                {
                    p = new Pen(_bordercolor, _borderwidth);
                    p.StartCap = LineCap.Round;
                    p.EndCap = LineCap.Round;

                    if (_direction != LineDirection.None)
                        switch (this.Shape)
                        {
                            //case ShapeType.LineHorizontal:
                            //    if (_direction == LineDirection.LeftDown || _direction == LineDirection.LeftUp)
                            //        p.StartCap = LineCap.ArrowAnchor;
                            //    else
                            //        p.EndCap = LineCap.ArrowAnchor;
                            //    break;
                            case ShapeType.LineVertical:
                                if (_direction == LineDirection.LeftUp || _direction == LineDirection.RightUp)
                                    p.StartCap = LineCap.ArrowAnchor;
                                else
                                    p.EndCap = LineCap.ArrowAnchor;
                                break;

                            case ShapeType.LineHorizontal:
                            case ShapeType.LineUp:
                            case ShapeType.LineDown:
                                if (_direction == LineDirection.LeftUp || _direction == LineDirection.LeftDown)
                                    p.StartCap = LineCap.ArrowAnchor;
                                else
                                    p.EndCap = LineCap.ArrowAnchor;
                                break;
                        }
                }

                //set border style
                p.DashStyle = _borderstyle;
                if (p.DashStyle == DashStyle.Custom)
                    p.DashPattern = new float[] { 1, 1, 1, 1 };

                //animate border by using a one of sequence of 10 generated dash style with every call
                if (this.AnimateBorder)
                {
                    p.DashStyle = DashStyle.Custom;
                    _static_ds = (_static_ds++) % 10;
                    p.DashPattern = this._btoggled ? new float[] { 1, 0.01f + 0.05f * _static_ds, 1, 1, 1 } : new float[] { 1, 1, 1, 1 };
                }

                pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                pe.Graphics.DrawPath(p, this._outline);



                p.Dispose();
            }

            //Rendering the text to be at the center of the shape
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            switch (_shape)
            {
                case ShapeType.BallonNE:
                case ShapeType.BallonNW:
                    pe.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new RectangleF(0, this.Height * 0.25f, this.Width, this.Height * 0.75f), sf);
                    break;

                case ShapeType.BallonSE:
                case ShapeType.BallonSW:
                    pe.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new RectangleF(0, 0, this.Width, this.Height * 0.75f), sf);
                    break;

                default:
                    pe.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new Rectangle(0, 0, this.Width, this.Height), sf);
                    break;
            }

            // Calling the base class OnPaint

            base.OnPaint(pe);
        }

        #endregion

        #region Private Methods
        //This function creates the path for each shape
        //It is also being used by the ShapeTypeEditor to create the various shapes
        //for the Shape property editor UI
        /// <summary>
        /// Updates the outline.
        /// </summary>
        /// <param name="outline">The outline.</param>
        /// <param name="shape">The shape.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="borderwidth">The borderwidth.</param>
        internal static void updateOutline(ref GraphicsPath outline, ShapeType shape, int width, int height, int borderwidth)
        {

            switch (shape)
            {

                case ShapeType.LineVertical:

                    outline.AddLine(new PointF((float)width / 2, borderwidth),
                                    new PointF((float)width / 2, height - borderwidth));

                    break;

                case ShapeType.LineHorizontal:
                    outline.AddLine(new PointF(borderwidth, (float)height / 2), new PointF(width - borderwidth, (float)height / 2));
                    break;

                /////////////////////////////
                //        *
                //      *
                //    *
                //  *
                //*
                //////////////////////////////
                case ShapeType.LineUp:
                    outline.AddLine(new PointF(borderwidth, height - borderwidth), new PointF(width - borderwidth, borderwidth));
                    break;

                ////////////////////////////
                // *
                //   *
                //     *
                //       *
                //         *
                /////////////////////////////
                case ShapeType.LineDown:
                    outline.AddLine(new PointF(borderwidth, borderwidth), new PointF(width - borderwidth, height - borderwidth));
                    break;

                case ShapeType.CustomPie:
                    outline.AddPie(0, 0, width, height, 180, 270);
                    break;
                case ShapeType.CustomPolygon:
                    outline.AddPolygon(new PointF[]{
                                  new PointF(0,0),
                                  new PointF((float)width/2,(float)height/4),
                                  new PointF((float)width,0),
                                  new PointF(((float)width*3)/4,(float)height/2),
                                  new PointF((float)width,(float)height),
                                  new PointF((float)width/2,((float)height*3)/4),
                                  new PointF(0,(float)height),
                                  new PointF((float)width/4,(float)height/2)
                                                  }
                        );
                    break;
                case ShapeType.Diamond:
                    outline.AddPolygon(new PointF[]{
                                new PointF(0,(float)height/2),
                                new PointF((float)width/2,0),
                                new PointF((float)width,(float)height/2),
                                new PointF((float)width/2,(float)height)
                                                  });
                    break;

                case ShapeType.Rectangle:
                    outline.AddRectangle(new RectangleF(0, 0, width, height));
                    break;

                case ShapeType.Ellipse:
                    outline.AddEllipse(0, 0, (float)width, (float)height);
                    break;

                case ShapeType.TriangleUp:
                    outline.AddPolygon(new PointF[] { new PointF(0, (float)height), new PointF((float)width, (float)height), new PointF((float)width / 2, 0) });
                    break;

                case ShapeType.TriangleDown:
                    outline.AddPolygon(new PointF[] { new PointF(0, 0), new PointF(width, 0), new PointF(width / 2, (float)(float)height) });
                    break;

                case ShapeType.TriangleLeft:
                    outline.AddPolygon(new PointF[] { new PointF(width, 0), new PointF(0, (float)(float)height / 2), new PointF(width, (float)(float)height) });
                    break;

                case ShapeType.TriangleRight:
                    outline.AddPolygon(new PointF[] { new PointF(0, 0), new PointF(width, (float)(float)height / 2), new PointF(0, (float)(float)height) });
                    break;

                case ShapeType.RoundedRectangle:
                    outline.AddArc(0, 0, (float)width / 4, (float)width / 4, 180, 90);
                    outline.AddLine((float)width / 8, 0, (float)width - (float)width / 8, 0);
                    outline.AddArc((float)width - (float)width / 4, 0, (float)width / 4, (float)width / 4, 270, 90);
                    outline.AddLine((float)width, (float)width / 8, (float)width, (float)height - (float)width / 8);
                    outline.AddArc((float)width - (float)width / 4, (float)height - (float)width / 4, (float)width / 4, (float)width / 4, 0, 90);
                    outline.AddLine((float)width - (float)width / 8, (float)height, (float)width / 8, (float)height);
                    outline.AddArc(0, (float)height - (float)width / 4, (float)width / 4, (float)width / 4, 90, 90);
                    outline.AddLine(0, (float)height - (float)width / 8, 0, (float)width / 8);
                    break;

                case ShapeType.BallonSW:
                    outline.AddArc(0, 0, (float)width / 4, (float)width / 4, 180, 90);
                    outline.AddLine((float)width / 8, 0, (float)width - (float)width / 8, 0);
                    outline.AddArc((float)width - (float)width / 4, 0, (float)width / 4, (float)width / 4, 270, 90);
                    outline.AddLine((float)width, (float)width / 8, (float)width, ((float)height * 0.75f) - (float)width / 8);
                    outline.AddArc((float)width - (float)width / 4, ((float)height * 0.75f) - (float)width / 4, (float)width / 4, (float)width / 4, 0, 90);
                    outline.AddLine((float)width - (float)width / 8, ((float)height * 0.75f), (float)width / 8 + ((float)width / 4), ((float)height * 0.75f));
                    outline.AddLine((float)width / 8 + ((float)width / 4), (float)height * 0.75f, (float)width / 8 + ((float)width / 8), (float)height);
                    outline.AddLine((float)width / 8 + ((float)width / 8), (float)height, (float)width / 8 + ((float)width / 8), ((float)height * 0.75f));
                    outline.AddLine((float)width / 8 + ((float)width / 8), ((float)height * 0.75f), (float)width / 8, ((float)height * 0.75f));
                    outline.AddArc(0, ((float)height * 0.75f) - (float)width / 4, (float)width / 4, (float)width / 4, 90, 90);
                    outline.AddLine(0, ((float)height * 0.75f) - (float)width / 8, 0, (float)width / 8);
                    break;

                case ShapeType.BallonSE:
                    outline.AddArc(0, 0, (float)width / 4, (float)width / 4, 180, 90);
                    outline.AddLine((float)width / 8, 0, (float)width - (float)width / 8, 0);
                    outline.AddArc((float)width - (float)width / 4, 0, (float)width / 4, (float)width / 4, 270, 90);
                    outline.AddLine((float)width, (float)width / 8, (float)width, ((float)height * 0.75f) - (float)width / 8);
                    outline.AddArc((float)width - (float)width / 4, ((float)height * 0.75f) - (float)width / 4, (float)width / 4, (float)width / 4, 0, 90);
                    outline.AddLine((float)width - (float)width / 8, ((float)height * 0.75f), (float)width - ((float)width / 4), ((float)height * 0.75f));
                    outline.AddLine((float)width - ((float)width / 4), (float)height * 0.75f, (float)width - ((float)width / 4), (float)height);
                    outline.AddLine((float)width - ((float)width / 4), (float)height, (float)width - (3 * (float)width / 8), ((float)height * 0.75f));
                    outline.AddLine((float)width - (3 * (float)width / 8), ((float)height * 0.75f), (float)width / 8, ((float)height * 0.75f));
                    outline.AddArc(0, ((float)height * 0.75f) - (float)width / 4, (float)width / 4, (float)width / 4, 90, 90);
                    outline.AddLine(0, ((float)height * 0.75f) - (float)width / 8, 0, (float)width / 8);
                    break;

                case ShapeType.BallonNW:
                    outline.AddArc((float)width - (float)width / 4, ((float)height) - (float)width / 4, (float)width / 4, (float)width / 4, 0, 90);
                    outline.AddLine((float)width - (float)width / 8, ((float)height), (float)width - ((float)width / 4), ((float)height));
                    outline.AddArc(0, ((float)height) - (float)width / 4, (float)width / 4, (float)width / 4, 90, 90);
                    outline.AddLine(0, ((float)height) - (float)width / 8, 0, (float)height * 0.25f + (float)width / 8);
                    outline.AddArc(0, (float)height * 0.25f, (float)width / 4, (float)width / 4, 180, 90);
                    outline.AddLine((float)width / 8, (float)height * 0.25f, (float)width / 4, (float)height * 0.25f);
                    outline.AddLine((float)width / 4, (float)height * 0.25f, (float)width / 4, 0);
                    outline.AddLine((float)width / 4, 0, 3 * (float)width / 8, (float)height * 0.25f);
                    outline.AddLine(3 * (float)width / 8, (float)height * 0.25f, (float)width - (float)width / 8, (float)height * 0.25f);
                    outline.AddArc((float)width - (float)width / 4, (float)height * 0.25f, (float)width / 4, (float)width / 4, 270, 90);
                    outline.AddLine((float)width, (float)width / 8 + (float)height * 0.25f, (float)width, ((float)height) - (float)width / 8);
                    break;

                case ShapeType.BallonNE:
                    outline.AddArc((float)width - (float)width / 4, ((float)height) - (float)width / 4, (float)width / 4, (float)width / 4, 0, 90);
                    outline.AddLine((float)width - (float)width / 8, ((float)height), (float)width - ((float)width / 4), ((float)height));
                    outline.AddArc(0, ((float)height) - (float)width / 4, (float)width / 4, (float)width / 4, 90, 90);
                    outline.AddLine(0, ((float)height) - (float)width / 8, 0, (float)height * 0.25f + (float)width / 8);
                    outline.AddArc(0, (float)height * 0.25f, (float)width / 4, (float)width / 4, 180, 90);
                    outline.AddLine((float)width / 8, (float)height * 0.25f, 5 * (float)width / 8, (float)height * 0.25f);
                    outline.AddLine(5 * (float)width / 8, (float)height * 0.25f, 3 * (float)width / 4, 0);
                    outline.AddLine(3 * (float)width / 4, 0, 3 * (float)width / 4, (float)height * 0.25f);
                    outline.AddLine(3 * (float)width / 4, (float)height * 0.25f, (float)width - (float)width / 8, (float)height * 0.25f);
                    outline.AddArc((float)width - (float)width / 4, (float)height * 0.25f, (float)width / 4, (float)width / 4, 270, 90);
                    outline.AddLine((float)width, (float)width / 8 + (float)height * 0.25f, (float)width, ((float)height) - (float)width / 8);
                    break;

                default: break;
            }
        }

        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="ctrl1">The CTRL1.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="bFromDesigner">if set to <c>true</c> [b from designer].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool SaveToFile(ZeroitCustomControl ctrl1, string filename, bool bFromDesigner)
        {
            string path = "";
            try
            {
                if (filename.Length < 8) return false; //min name .shp.jpg
                if (filename.ToUpper().IndexOf(".SHP.JPG") != (filename.Length - 8)) return false;

                if (filename != "")
                {
                    if (filename.IndexOf("\\") >= 0)
                        path = filename;
                    else
                        path = Application.UserAppDataPath + "\\" + filename;
                    if (bFromDesigner)
                    {
                        if (MessageBox.Show("Save to " + path, "Confirm", MessageBoxButtons.OKCancel) != DialogResult.OK)
                            return false;
                    }

                    string shapepath = path.Substring(0, path.Length - 4);

                    if (File.Exists(path))
                    {
                        if (bFromDesigner)
                        {
                            if (MessageBox.Show(path + " already exist. Overwrite", "Confirm", MessageBoxButtons.OKCancel) != DialogResult.OK)
                                return false;
                        }
                        File.Delete(path);
                        if (File.Exists(shapepath))
                            File.Delete(shapepath);
                    }

                    if (!File.Exists(shapepath))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(shapepath))
                        {
                            sw.WriteLine("AnimateBorder<" + ctrl1.AnimateBorder.ToString() + ">");
                            sw.WriteLine("Vibrate<" + ctrl1.Vibrate.ToString() + ">");
                            sw.WriteLine("Blink<" + ctrl1.Blink.ToString() + ">");

                            sw.WriteLine("BackColor<" + ctrl1.BackColor.ToArgb() + ">");
                            sw.WriteLine("BorderColor<" + ctrl1.BorderColor.ToArgb() + ">");


                            sw.WriteLine("BorderColor<" + ctrl1.BorderColor.ToArgb() + ">");
                            sw.WriteLine("BorderStyle<" + ctrl1.BorderStyle.ToString() + ">");
                            sw.WriteLine("BorderWidth<" + ctrl1.BorderWidth + ">");
                            sw.WriteLine("CenterColor<" + ctrl1.CenterColor.ToArgb() + ">");
                            sw.WriteLine("Connector<" + ctrl1.Connector + ">");
                            sw.WriteLine("Direction<" + ctrl1.Direction + ">");
                            sw.WriteLine("Font<Name:" + ctrl1.Font.FontFamily.Name + ",Size:" + ctrl1.Font.Size + ",Style:" + ctrl1.Font.Style +
                                         ",GraphicalUnits:" + ctrl1.Font.Unit + ">");
                            sw.WriteLine("Shape<" + ctrl1.Shape.ToString() + ">");
                            if (ctrl1.ShapeImage != null)
                            {
                                //sw.WriteLine("ShapeImage>shapeimage.jpg");
                                //ctrl1.ShapeImage.Save(path + ".shapeimage.jpg",
                                //     System.Drawing.Imaging.ImageFormat.Jpeg);
                                sw.WriteLine("ShapeImage<" + BitmapToBase64String((Bitmap)ctrl1.ShapeImage) + ">");
                            }
                            else sw.WriteLine("ShapeImage<null>");

                            sw.WriteLine("ShapeImageRotation<" + ctrl1.ShapeImageRotation + ">");

                            if (ctrl1.ShapeImageTexture != null)
                            {
                                //sw.WriteLine("ShapeImageTexture>shapeimagetexture.jpg");
                                //ctrl1.ShapeImageTexture.Save(path + ".shapeimagetexture.jpg",
                                //     System.Drawing.Imaging.ImageFormat.Jpeg);
                                sw.WriteLine("ShapeImageTexture<" + BitmapToBase64String((Bitmap)ctrl1.ShapeImageTexture) + ">");
                            }
                            else sw.WriteLine("ShapeImageTexture<null>");

                            sw.WriteLine("SurroundColor<" + ctrl1.SurroundColor.ToArgb() + ">");
                            sw.WriteLine("UseGradient<" + ctrl1.UseGradient.ToString() + ">");
                            sw.WriteLine("ForeColor<" + ctrl1.ForeColor.ToArgb() + ">");
                            sw.WriteLine("Text<" + ctrl1.Text.ToString() + ">");


                            sw.WriteLine("Width<" + ctrl1.Width + ">");
                            sw.WriteLine("Height<" + ctrl1.Height + ">");
                            if (ctrl1.BackgroundImage == null)
                                sw.WriteLine("BackgroundImage<null>");
                            else
                            {
                                //sw.WriteLine("BackgroundImage>backgroundimage.jpg");
                                //ctrl1.BackgroundImage.Save(path + ".backgroundimage.jpg",
                                //    System.Drawing.Imaging.ImageFormat.Jpeg);
                                sw.WriteLine("BackgroundImage<" + BitmapToBase64String((Bitmap)ctrl1.BackgroundImage) + ">");
                            }

                            Bitmap bm = new Bitmap(ctrl1.Width, ctrl1.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                            Bitmap mask = (Bitmap)bm.Clone();
                            Graphics g = Graphics.FromImage(mask);
                            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, mask.Width, mask.Height);
                            Region maskregion = ctrl1.Region;//new Region(ctrl1._outline);
                            g.FillRegion(new SolidBrush(Color.White), maskregion);
                            g.Dispose();
                            //for debugging purpose
                            //mask.Save(path + ".mask.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            ctrl1.DrawToBitmap(bm, ctrl1.ClientRectangle);
                            // bm.Save(path + ".bm.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            Bitmap bmout = CBitmapOps.DoBitOpsForBitmap(bm, mask, "AND");
                            CBitmapOps.DoInvertBitmap(mask);
                            //mask.Save(path + ".mask_inv.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                            bmout = CBitmapOps.DoBitOpsForBitmap(bmout, mask, "OR");

                            // bmout.Save(path + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            bmout.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);

                            if (bFromDesigner)
                                MessageBox.Show("Shape saved to " + path);
                        }
                    } //if
                } //if

            } //try
            catch (Exception e)
            {
                if (bFromDesigner)
                    MessageBox.Show(e.ToString());

                return false;

            }
            return true;
        }

        /// <summary>
        /// Unicodes to hexadecimal.
        /// </summary>
        /// <param name="uni">The uni.</param>
        /// <returns>System.String.</returns>
        private static string UnicodeToHex(string uni)
        {
            return "";
        }

        /// <summary>
        /// Bitmaps to base64 string.
        /// </summary>
        /// <param name="bm">The bm.</param>
        /// <returns>System.String.</returns>
        private static string BitmapToBase64String(Bitmap bm)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                bm.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] bms = ms.GetBuffer();
                ms.Close();
                ms.Dispose();

                string b64str = Convert.ToBase64String(bms);
                return b64str;
            }

        }

        /// <summary>
        /// Bitmaps from base64 string.
        /// </summary>
        /// <param name="b64str">The B64STR.</param>
        /// <returns>Bitmap.</returns>
        private static Bitmap BitmapFromBase64String(string b64str)
        {
            byte[] b = Convert.FromBase64String(b64str);
            using (MemoryStream ms = new MemoryStream(b))
            {
                Bitmap bm = (Bitmap)Bitmap.FromStream(ms);
                return bm;
            }
        }

        /// <summary>
        /// Loads from file.
        /// </summary>
        /// <param name="ctrl1">The CTRL1.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="bFromDesigner">if set to <c>true</c> [b from designer].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool LoadFromFile(ZeroitCustomControl ctrl1, string filename, bool bFromDesigner)
        {

            try
            {
                if (filename != "")
                {

                    if (filename.Length < 8) return false; //min name .shp.jpg
                    if (filename.ToUpper().IndexOf(".SHP.JPG") != (filename.Length - 8)) return false;

                    if (bFromDesigner)
                    {
                        if (MessageBox.Show("Load from " + filename, "Confirm", MessageBoxButtons.OKCancel) != DialogResult.OK)
                            return false;
                    }

                    //remove the .jpg to get the .shp filename
                    string shapefilename = filename.Substring(0, filename.Length - 4);

                    var v = System.IO.File.ReadAllLines(shapefilename);

                    for (int i = 0; i < v.Length; i++)
                    {
                        // var v1 = v[i].Split('>');
                        //find first "<"
                        int startindex = v[i].IndexOf("<");
                        int endindex = v[i].LastIndexOf(">");
                        var v1 = new string[2];
                        if ((endindex > 0) && (startindex > 0) && (endindex > startindex))
                        {
                            v1[0] = v[i].Substring(0, startindex); //last char before <
                            v1[1] = v[i].Substring(startindex + 1);        //from char after <
                            v1[1] = v1[1].Substring(0, v1[1].Length - 1); //remove >
                        }
                        else
                            continue;

                        switch (v1[0])
                        {

                            case "BackgroundImage":
                                if (v1[1] == "null")
                                {

                                    ctrl1.BackgroundImage = null;
                                }
                                else
                                {

                                    //using (var bmpTemp = new Bitmap(filename + "." + v1[1]))
                                    //{
                                    //    ctrl1.BackgroundImage = new Bitmap(bmpTemp);
                                    //}

                                    using (var bmpTemp = BitmapFromBase64String(v1[1]))
                                    {
                                        ctrl1.BackgroundImage = new Bitmap(bmpTemp);
                                    }

                                }
                                break;
                            case "ShapeImage":
                                if (v1[1] == "null")
                                {

                                    ctrl1.ShapeImage = null;
                                }
                                else
                                {

                                    //using (var bmpTemp = new Bitmap(filename + "." + v1[1]))
                                    //{
                                    //    ctrl1.ShapeImage = new Bitmap(bmpTemp);
                                    //}

                                    using (var bmpTemp = BitmapFromBase64String(v1[1]))
                                    {
                                        ctrl1.ShapeImage = new Bitmap(bmpTemp);
                                    }

                                }
                                break;

                            case "Shape":
                                ctrl1.Shape = (ShapeType)Enum.Parse(typeof(ShapeType), v1[1], true);
                                break;
                            case "ForeColor":
                                ctrl1.ForeColor = Color.FromArgb(int.Parse(v1[1]));
                                break;
                            case "Text":
                                ctrl1.Text = v1[1];
                                break;
                            case "BorderColor":
                                ctrl1.BorderColor = Color.FromArgb(int.Parse(v1[1]));
                                break;
                            case "AnimateBorder":
                                ctrl1.AnimateBorder = bool.Parse(v1[1]); break;
                            case "BackColor":
                                ctrl1.BackColor = Color.FromArgb(int.Parse(v1[1]));
                                break;
                            case "BorderWidth":
                                ctrl1.BorderWidth = int.Parse(v1[1]);
                                break;
                            case "BorderStyle":
                                ctrl1.BorderStyle = (System.Drawing.Drawing2D.DashStyle)Enum.Parse(typeof(System.Drawing.Drawing2D.DashStyle), v1[1]);
                                break;
                            case "CenterColor":
                                ctrl1.CenterColor = Color.FromArgb(int.Parse(v1[1]));
                                break;
                            case "SurroundColor":
                                ctrl1.SurroundColor = Color.FromArgb(int.Parse(v1[1]));
                                break;
                            case "Connector":
                                ctrl1.Connector = (ConnecterType)Enum.Parse(typeof(ConnecterType), v1[1], true);
                                break;
                            case "Direction":
                                ctrl1.Direction = (LineDirection)Enum.Parse(typeof(LineDirection), v1[1], true);
                                break;
                            case "Font":
                                var v2 = v1[1].Split(',');

                                string familyname = "Arial";
                                float size = 8f;
                                GraphicsUnit gu = GraphicsUnit.Point;
                                FontStyle fs = FontStyle.Regular;

                                for (int j = 0; j < v2.Length; j++)
                                {
                                    var v3 = v2[j].Trim().Split(':');
                                    switch (v3[0].Trim())
                                    {
                                        case "Name": familyname = v3[1]; break;
                                        case "Size": size = float.Parse(v3[1]); break;
                                        case "GraphicalUnits":
                                            gu = (GraphicsUnit)Enum.Parse(typeof(GraphicsUnit), v3[1], true);
                                            break;
                                        case "Style":
                                            fs = (FontStyle)Enum.Parse(typeof(FontStyle), v3[1], true);
                                            break;

                                    }
                                }
                                ctrl1.Font = new Font(familyname, size, fs, gu);
                                break;
                            case "UseGradient":
                                ctrl1.UseGradient = bool.Parse(v1[1]);
                                break;

                            case "ShapeImageRotation":
                                ctrl1.ShapeImageRotation = int.Parse(v1[1]);
                                break;
                            case "ShapeImageTexture":
                                if (v1[1] == "null")
                                {
                                    ctrl1.ShapeImageTexture = null;
                                }
                                else
                                {
                                    //using (var bmpTemp = new Bitmap(filename + "." + v1[1]))
                                    //{
                                    //    ctrl1.ShapeImageTexture = new Bitmap(bmpTemp);
                                    //}
                                    using (var bmpTemp = BitmapFromBase64String(v1[1]))
                                    {
                                        ctrl1.ShapeImageTexture = new Bitmap(bmpTemp);
                                    }

                                }
                                break;
                            case "Width":
                                ctrl1.Width = int.Parse(v1[1]);
                                break;
                            case "Height":
                                ctrl1.Height = int.Parse(v1[1]);
                                break;

                        }
                    }


                }
            }
            catch (Exception e)
            {
                if (bFromDesigner)
                    MessageBox.Show(e.ToString());

                return false;
            }

            return true;
        }

        #endregion
    }

    #region Line

    /// <summary>
    /// Class Line.
    /// </summary>
    public class Line
    {

        /// <summary>
        /// Sets the connectors.
        /// </summary>
        /// <param name="ctrl1">The CTRL1.</param>
        /// <param name="ctrl2">The CTRL2.</param>
        public static void setConnectors(ref ZeroitCustomControl ctrl1, ref ZeroitCustomControl ctrl2)
        {
            //defaults
            ctrl1.Connector = ConnecterType.Center;
            ctrl2.Connector = ConnecterType.Center;

            int maxwidth = (ctrl1.Width > ctrl2.Width) ? ctrl1.Width : ctrl2.Width;
            int maxheight = (ctrl1.Height > ctrl2.Height) ? ctrl1.Height : ctrl2.Height;

            //check y delta
            int ydelta = ctrl1.Top - ctrl2.Top;
            int xdelta = ctrl1.Left - ctrl2.Left;

            //overlapped
            if (Math.Abs(ydelta) < maxheight && Math.Abs(xdelta) < maxwidth) return;

            if (Math.Abs(ydelta) > Math.Abs(xdelta)) //use top and bottom connector
            {
                if (ydelta > 0) //ctrl1 is lower
                {
                    ctrl1.Connector = ConnecterType.Top;
                    ctrl2.Connector = ConnecterType.Bottom;
                }
                else
                {
                    ctrl1.Connector = ConnecterType.Bottom;
                    ctrl2.Connector = ConnecterType.Top;
                }

            }
            else //use left and right connector
            {
                if (xdelta > 0) // ctrl1 on the right
                {
                    ctrl1.Connector = ConnecterType.Left;
                    ctrl2.Connector = ConnecterType.Right;
                }
                else
                {
                    ctrl1.Connector = ConnecterType.Right;
                    ctrl2.Connector = ConnecterType.Left;
                }

            }

        }


        /// <summary>
        /// Sets the connector point.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="ctrl">The control.</param>
        public static void setConnectorPoint(ref int x, ref int y, ZeroitCustomControl ctrl)
        {
            int x0 = ctrl.Location.X;
            int y0 = ctrl.Location.Y;
            int x0delta = 0, y0delta = 0;
            switch (ctrl.Connector)
            {
                case ConnecterType.Left:
                    y0delta = ctrl.Height / 2;
                    break;
                case ConnecterType.Right:
                    x0delta = ctrl.Width;
                    y0delta = ctrl.Height / 2;
                    break;
                case ConnecterType.Top:
                    x0delta = ctrl.Width / 2;
                    break;
                case ConnecterType.Bottom:
                    x0delta = ctrl.Width / 2;
                    y0delta = ctrl.Height;
                    break;
                case ConnecterType.Center:
                    x0delta = ctrl.Width / 2;
                    y0delta = ctrl.Height / 2;
                    break;

            }

            x = x0 + x0delta;
            y = y0 + y0delta;
        }


        //generic 
        //can be used for any line shape control
        //x0,y0 is source pt, x1,y1 is the dest point
        //for directional line, the arrow would appear in x1,y1
        /// <summary>
        /// Sets the line.
        /// </summary>
        /// <param name="ctrl1">The CTRL1.</param>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        public static void setLine(ref ZeroitCustomControl ctrl1, int x0, int y0, int x1, int y1)
        {

            int xx0 = 0; //left 
            int yy0 = 0; //top
            int xx1 = 0; //right
            int yy1 = 0; //bottom

            //set direction based on location of dest_cm in relation to src_cam
            if (x0 <= x1)  // dest on the right
            {

                if (ctrl1.Direction != LineDirection.None)
                {
                    if (y0 < y1) // dest_cam at the bottom
                        ctrl1.Direction = LineDirection.RightDown;
                    else
                        ctrl1.Direction = LineDirection.RightUp;
                }

                //left src
                xx0 = x0;
                yy0 = y0;

                //right dest
                xx1 = x1;
                yy1 = y1;
            }
            else //dest on the left
            {

                if (ctrl1.Direction != LineDirection.None)
                {
                    if (y0 < y1) //dest_cam at the bottom
                        ctrl1.Direction = LineDirection.LeftDown;
                    else
                        ctrl1.Direction = LineDirection.LeftUp;
                }

                //left dest
                xx0 = x1;
                yy0 = y1;

                //right src
                xx1 = x0;
                yy1 = y0;


            }


            float gradient = 0f;


            //check for vert and horizontal line
            if (Math.Abs(xx0 - xx1) <= 0 || Math.Abs(yy0 - yy1) <= 0)
            {

                ctrl1.Shape = (Math.Abs(xx0 - xx1) <= 0) ?
                    ShapeType.LineVertical :
                    ShapeType.LineHorizontal;



            } //normal line
            else
            {
                gradient = (float)(yy0 - yy1) / (float)(xx0 - xx1);
                ctrl1.Shape = (gradient > 0f) ? ShapeType.LineDown : ShapeType.LineUp;
            }

            //all shape control are specified by
            //the top-left corner, width and height

            //lx0,ly0 : location for top-left of shape control
            //lx1,ly1 : location for bottom-right of shape control
            //lw: width of shape control
            //lh: height of shape control

            int lx0 = 0, ly0 = 0, lx1 = 0, ly1 = 0, lw = 0, lh = 0;

            //offset from to cater for line width
            int delta = (4 * ctrl1.BorderWidth) / 4;


            switch (ctrl1.Shape)
            {
                case ShapeType.LineVertical:
                    lx0 = xx0 - delta;
                    lx1 = xx1 + delta;

                    ly0 = yy0 - delta;
                    ly1 = yy1 + delta;


                    lw = Math.Abs(lx0 - lx1);
                    lh = Math.Abs(ly0 - ly1);


                    break;

                case ShapeType.LineHorizontal:

                    ly0 = yy0 - delta;
                    ly1 = yy1 + delta;
                    lx0 = xx0 - delta;
                    lx1 = xx1 + delta;

                    lh = Math.Abs(ly0 - ly1);

                    lw = Math.Abs(lx0 - lx1);


                    break;
                case ShapeType.LineUp:
                    lx0 = xx0 - delta;
                    ly0 = yy1 - delta;
                    lx1 = xx1 + delta;
                    ly1 = yy0 + delta;

                    lw = Math.Abs(lx0 - lx1);
                    lh = Math.Abs(ly0 - ly1);

                    break;
                case ShapeType.LineDown:
                    lx0 = xx0 - delta;
                    ly0 = yy0 - delta;
                    lx1 = xx1 + delta;
                    ly1 = yy1 + delta;

                    lw = Math.Abs(lx0 - lx1);
                    lh = Math.Abs(ly0 - ly1);

                    break;

            }

            //set the location and sie of the line shape control

            ctrl1.Size = new System.Drawing.Size(lw, lh);
            ctrl1.Location = new Point(lx0, ly0);


        }



    }


    #endregion


    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitCustomControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitCustomControlDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitCustomControlDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitCustomControlSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitCustomControlSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitCustomControlSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitCustomControl colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCustomControlSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitCustomControlSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitCustomControl;

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

        #region Public Properties

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

        /// <summary>
        /// Gets or sets the shape storage load file.
        /// </summary>
        /// <value>The shape storage load file.</value>
        public string ShapeStorageLoadFile
        {
            get
            {
                return colUserControl.ShapeStorageLoadFile;
            }
            set
            {
                GetPropertyByName("ShapeStorageLoadFile").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the shape storage save file.
        /// </summary>
        /// <value>The shape storage save file.</value>
        public string ShapeStorageSaveFile
        {
            get
            {
                return colUserControl.ShapeStorageSaveFile;
            }
            set
            {
                GetPropertyByName("ShapeStorageSaveFile").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the connector.
        /// </summary>
        /// <value>The connector.</value>
        public ConnecterType Connector
        {
            get
            {
                return colUserControl.Connector;
            }
            set
            {
                GetPropertyByName("Connector").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        public LineDirection Direction
        {
            get
            {
                return colUserControl.Direction;
            }
            set
            {
                GetPropertyByName("Direction").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the tag2.
        /// </summary>
        /// <value>The tag2.</value>
        public string Tag2
        {

            get
            {
                return colUserControl.Tag2;
            }
            set
            {
                GetPropertyByName("Tag2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [animate border].
        /// </summary>
        /// <value><c>true</c> if [animate border]; otherwise, <c>false</c>.</value>
        public bool AnimateBorder
        {
            get
            {
                return colUserControl.AnimateBorder;
            }
            set
            {
                GetPropertyByName("AnimateBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitCustomControlSmartTagActionList"/> is blink.
        /// </summary>
        /// <value><c>true</c> if blink; otherwise, <c>false</c>.</value>
        public bool Blink
        {
            get
            {
                return colUserControl.Blink;
            }
            set
            {
                GetPropertyByName("Blink").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitCustomControlSmartTagActionList"/> is vibrate.
        /// </summary>
        /// <value><c>true</c> if vibrate; otherwise, <c>false</c>.</value>
        public bool Vibrate
        {
            get
            {
                return colUserControl.Vibrate;
            }
            set
            {
                GetPropertyByName("Vibrate").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the shape image rotation.
        /// </summary>
        /// <value>The shape image rotation.</value>
        public int ShapeImageRotation
        {
            get
            {
                return colUserControl.ShapeImageRotation;
            }
            set
            {
                GetPropertyByName("ShapeImageRotation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the shape image.
        /// </summary>
        /// <value>The shape image.</value>
        public Image ShapeImage
        {
            get
            {
                return colUserControl.ShapeImage;
            }
            set
            {
                GetPropertyByName("ShapeImage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the shape image texture.
        /// </summary>
        /// <value>The shape image texture.</value>
        public Image ShapeImageTexture
        {
            get
            {
                return colUserControl.ShapeImageTexture;
            }
            set
            {
                GetPropertyByName("ShapeImageTexture").SetValue(colUserControl, value);
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

        /// <summary>
        /// Gets or sets a value indicating whether [use gradient].
        /// </summary>
        /// <value><c>true</c> if [use gradient]; otherwise, <c>false</c>.</value>
        public bool UseGradient
        {
            get
            {
                return colUserControl.UseGradient;
            }
            set
            {
                GetPropertyByName("UseGradient").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the center.
        /// </summary>
        /// <value>The color of the center.</value>
        public Color CenterColor
        {
            get
            {
                return colUserControl.CenterColor;
            }
            set
            {
                GetPropertyByName("CenterColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the surround.
        /// </summary>
        /// <value>The color of the surround.</value>
        public Color SurroundColor
        {
            get
            {
                return colUserControl.SurroundColor;
            }
            set
            {
                GetPropertyByName("SurroundColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get
            {
                return colUserControl.BorderWidth;
            }
            set
            {
                GetPropertyByName("BorderWidth").SetValue(colUserControl, value);
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
        /// Gets or sets the border style.
        /// </summary>
        /// <value>The border style.</value>
        public DashStyle BorderStyle
        {
            get
            {
                return colUserControl.BorderStyle;
            }
            set
            {
                GetPropertyByName("BorderStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        public ShapeType Shape
        {
            get
            {
                return colUserControl.Shape;
            }
            set
            {
                GetPropertyByName("Shape").SetValue(colUserControl, value);
            }
        }

        #endregion

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

            items.Add(new DesignerActionPropertyItem("AnimateBorder",
                                 "Animate Border", "Appearance",
                                 "Set to enable border animation."));

            items.Add(new DesignerActionPropertyItem("Blink",
                                "Blink", "Appearance",
                                "Set to enable control to blink."));

            items.Add(new DesignerActionPropertyItem("Vibrate",
                                 "Vibrate", "Appearance",
                                 "Set to enable control to vibrate."));

            items.Add(new DesignerActionPropertyItem("UseGradient",
                                "Use Gradient", "Appearance",
                                "Set to enable control to use gradient."));

            items.Add(new DesignerActionPropertyItem("Smoothing",
                                "Smoothing", "Appearance",
                                "Sets the smoothing mode of the control."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("CenterColor",
                                 "Center Color", "Appearance",
                                 "Sets the center color."));

            items.Add(new DesignerActionPropertyItem("SurroundColor",
                                 "Surround Color", "Appearance",
                                 "Sets the surrounding color."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("ShapeStorageLoadFile",
                                 "Shape Storage Load File", "Appearance",
                                 "Sets the shape file."));

            items.Add(new DesignerActionPropertyItem("ShapeStorageSaveFile",
                                 "Shape Storage Save File", "Appearance",
                                 "Save the shape file."));

            items.Add(new DesignerActionPropertyItem("Connector",
                                 "Connector", "Appearance",
                                 "Sets the connector."));

            items.Add(new DesignerActionPropertyItem("Direction",
                                 "Direction", "Appearance",
                                 "Sets the direction."));

            //items.Add(new DesignerActionPropertyItem("Tag2",
            //                     "Tag2", "Appearance",
            //                     "Sets the tag."));


            items.Add(new DesignerActionPropertyItem("ShapeImageRotation",
                                 "Shape Image Rotation", "Appearance",
                                 "Sets the shape image rotation."));

            items.Add(new DesignerActionPropertyItem("ShapeImage",
                                 "Shape Image", "Appearance",
                                 "Sets the shape image."));

            items.Add(new DesignerActionPropertyItem("ShapeImageTexture",
                                 "Shape Image Texture", "Appearance",
                                 "Sets the shape image texture."));

            items.Add(new DesignerActionPropertyItem("Text",
                                 "Text", "Appearance",
                                 "Sets the text."));

            items.Add(new DesignerActionPropertyItem("BorderWidth",
                                 "Border Width", "Appearance",
                                 "Sets the border width."));

            items.Add(new DesignerActionPropertyItem("BorderStyle",
                                 "Border Style", "Appearance",
                                 "Sets the border style."));

            items.Add(new DesignerActionPropertyItem("Shape",
                                "Shape", "Appearance",
                                "Sets the shape."));


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
