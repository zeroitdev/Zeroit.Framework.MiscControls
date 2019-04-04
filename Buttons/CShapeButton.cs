using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region CShape Button

    #region Enums
    /// <summary>
    /// Enum representint the graphics quality for <c><see cref="ZeroitCShape"/></c>.
    /// </summary>
    public enum RenderQuality
    {
        /// <summary>
        /// The high quality
        /// </summary>
        HighQuality = 0,
        /// <summary>
        /// The anti alias
        /// </summary>
        AntiAlias = 1,
        /// <summary>
        /// The high speed
        /// </summary>
        HighSpeed = 2,
        /// <summary>
        /// The default quality
        /// </summary>
        DefaultQuality = 3,
        /// <summary>
        /// The none
        /// </summary>
        None = 4
    }

    /// <summary>
    /// Enum representing the button shapes for  for <c><see cref="ZeroitCShape"/></c>.
    /// </summary>
    public enum ButtonShapes
    {
        /// <summary>
        /// The rectangle
        /// </summary>
        Rectangle = 0,
        /// <summary>
        /// The square
        /// </summary>
        Square = 1,
        /// <summary>
        /// The oval
        /// </summary>
        Oval = 2,
        /// <summary>
        /// The circle
        /// </summary>
        Circle = 3,
        /// <summary>
        /// The rnded rectangle
        /// </summary>
        Rnded_Rectangle = 4,
        /// <summary>
        /// The rnded square
        /// </summary>
        Rnded_Square = 5,
        /// <summary>
        /// The triangle
        /// </summary>
        Triangle = 6,
        /// <summary>
        /// The arrow
        /// </summary>
        Arrow = 7
    }

    /// <summary>
    /// Enum representing the 3D button shape  for <c><see cref="ZeroitCShape"/></c>.
    /// </summary>
    public enum Button3DShape
    {
        /// <summary>
        /// The flat
        /// </summary>
        Flat = 0,
        /// <summary>
        /// The shaded
        /// </summary>
        Shaded = 1,
        /// <summary>
        /// The shaded3 d
        /// </summary>
        Shaded3D = 2
    }

    /// <summary>
    /// Enum representing the button direction for  for <c><see cref="ZeroitCShape"/></c>.
    /// </summary>
    public enum ButtonDirection
    {
        /// <summary>
        /// The top
        /// </summary>
        Top = 0,
        /// <summary>
        /// The right
        /// </summary>
        Right = 1,
        /// <summary>
        /// The bottom
        /// </summary>
        Bottom = 2,
        /// <summary>
        /// The left
        /// </summary>
        Left = 3
    }
    #endregion

    #region Control    
    /// <summary>
    /// A class collection for rendering a customized button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Serializable]
    public class ZeroitCShape : System.Windows.Forms.Control
    {
        #region Variables
        //Custom
        Button3DShape Image3DStyle = Button3DShape.Flat;
        LinearGradientMode ImageGradientMode = LinearGradientMode.Vertical;
        SmoothingMode ImageQuality = SmoothingMode.HighQuality;
        ButtonShapes ImageShape = ButtonShapes.Square;
        HatchStyle ImageHatchStyle = HatchStyle.DashedHorizontal;
        ButtonDirection ImageDirection = ButtonDirection.Top;
        DashStyle ImageLnStyle = DashStyle.Solid;

        bool ImageHatched = false;
        bool objInitialized = false;
        bool ObjTransParent = false;
        bool objOutLine = true;
        bool ObjIsCirc = false;

        int ImageDrawWidth = 1;
        //Colors
        Color colFill = Color.AliceBlue;
        Color colOutLine = Color.Gray;
        Color colAlternate = Color.LightGray;
        Color[] colGradColors = { };
        float[] colGradPositions = { };
        double ImageRadius = 0.1;

        #region Objects
        Pen grfxPen = new Pen(Color.DimGray);
        //Build the object
        GraphicsPath grfxObject = new GraphicsPath();
        Brush grfxBrush = new SolidBrush(Color.LightGray);
        #endregion

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int SetProcessWorkingSetSize(
            int hProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);
        #endregion

        #region Properties
        /*
		 * Remember in the properties, you only want to re-build/redraw if the new value
		 * is different from the existing value. Saves unnecessary computing
		 */
        /// <summary>
        /// Gets or sets the HatchStyle for the object when in Flat Shading mode.
        /// </summary>
        /// <value>The hatch fill style.</value>
        [Description("Sets the HatchStyle for the object when in Flat Shading mode."), Category("Drawing")]
        public HatchStyle HatchFillStyle
        {
            get { return ImageHatchStyle; }
            set
            {
                if (ImageHatchStyle != value)
                {
                    ImageHatchStyle = value;
                    if (ImageHatched == true & Image3DStyle == Button3DShape.Flat)
                    {
                        BuildBrush();
                        DrawObject();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the object to be filled with Hatches when in Flat Shading mode.
        /// </summary>
        /// <value><c>true</c> if hatch fill; otherwise, <c>false</c>.</value>
        [Description("Sets the object to be filled with Hatches when in Flat Shading mode."), Category("Drawing")]
        public bool HatchFill
        {
            get { return ImageHatched; }
            set
            {
                if (ImageHatched != value)
                {
                    ImageHatched = value;
                    BuildBrush();
                    DrawObject();
                }
            }
        }


        /// <summary>
        /// Gets or sets the Shape drawn for the object.
        /// </summary>
        /// <value>The shape.</value>
        [Description("Sets the Shape drawn for the object."), Category("Drawing")]
        public ButtonShapes Shape
        {
            get { return ImageShape; }
            set
            {
                if (ImageShape != value)
                {
                    ImageShape = value;
                    BuildObject();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the gradient mode.
        /// </summary>
        /// <value>The shape gradient mode.</value>
        [Description("Sets the Gradient mode for the object."), Category("Drawing")]
        public LinearGradientMode ShapeGradientMode
        {
            get
            {
                return ImageGradientMode;
            }
            set
            {
                if (ImageGradientMode != value)
                {
                    ImageGradientMode = value;
                    BuildBrush();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the level of Anti-Aliasing for the object.
        /// </summary>
        /// <value>The shape quality.</value>
        [Description("Sets the level of Anti-Aliasing for the object."), Category("Drawing")]
        public RenderQuality ShapeQuality
        {
            get
            {
                switch (ImageQuality)
                {
                    case SmoothingMode.AntiAlias:
                        return RenderQuality.AntiAlias;
                    case SmoothingMode.HighQuality:
                        return RenderQuality.HighQuality;
                    case SmoothingMode.HighSpeed:
                        return RenderQuality.HighSpeed;
                    case SmoothingMode.Default:
                        return RenderQuality.DefaultQuality;
                    case SmoothingMode.None:
                        return RenderQuality.None;
                    default:
                        return RenderQuality.None;
                }
            }
            set
            {
                switch (value)
                {
                    case RenderQuality.AntiAlias:
                        ImageQuality = SmoothingMode.AntiAlias;
                        break;
                    case RenderQuality.HighQuality:
                        ImageQuality = SmoothingMode.HighQuality;
                        break;
                    case RenderQuality.HighSpeed:
                        ImageQuality = SmoothingMode.HighSpeed;
                        break;
                    case RenderQuality.DefaultQuality:
                        ImageQuality = SmoothingMode.Default;
                        break;
                    case RenderQuality.None:
                        ImageQuality = SmoothingMode.None;
                        break;
                    default:
                        ImageQuality = SmoothingMode.None;
                        break;
                }
                DrawObject();
            }
        }


        /// <summary>
        /// Gets or sets the shading mode.
        /// </summary>
        /// <value>The shape shading.</value>
        [Description("Sets the Shading mode for the object."), Category("Drawing")]
        public Button3DShape ShapeShading
        {
            get
            {
                return Image3DStyle;
            }
            set
            {
                if (Image3DStyle != value)
                {
                    Image3DStyle = value;
                    BuildBrush();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Thermometer Color.
        /// </summary>
        /// <value>The Thermometer Color.</value>
        [Description("Sets the Thermometer Color."), Category("Colors")]
        public Color FillColor
        {
            get { return colFill; }
            set
            {
                if (colFill != value)
                {
                    colFill = value;
                    BuildBrush();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the outline Color the thermometer is drawn in.
        /// </summary>
        /// <value>The color of the out line.</value>
        [Description("Sets the the outline Color the thermometer is drawn in."), Category("Colors")]
        public Color OutLineColor
        {
            get { return colOutLine; }
            set
            {
                if (colOutLine != value)
                {
                    colOutLine = value;
                    grfxPen = GetPen();
                    DrawObject();
                }
            }
        }


        /// <summary>
        /// Gets or sets the Alternate shading color.
        /// </summary>
        /// <value>The color of the alternate.</value>
        [Description("Sets the Alternate shading color."), Category("Drawing")]
        public Color AlternateColor
        {
            get { return colAlternate; }
            set
            {
                if (colAlternate != value)
                {
                    colAlternate = value;
                    BuildBrush();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the pen width for the object.
        /// </summary>
        /// <value>The width of the draw.</value>
        [Description("Sets the pen width for the object."), Category("Drawing")]
        public int DrawWidth
        {
            get { return ImageDrawWidth; }
            set
            {
                if (ImageDrawWidth != value)
                {
                    ImageDrawWidth = value;
                    grfxPen = GetPen();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Color array used in the 3D Shading Mode.
        /// </summary>
        /// <value>The gradients.</value>
        [Description("Sets the Color array used in the 3D Shading Mode."), Category("Drawing")]
        public Color[] Gradients
        {
            get { return colGradColors; }
            set
            {
                if (colGradColors != value)
                {
                    colGradColors = value;
                    if (colGradColors.Length != colGradPositions.Length)
                    {
                        if (colGradPositions.Length <= 0) { colGradPositions = new float[value.Length]; }
                        //colGradPositions
                        float[] m_Floats = new float[value.Length];
                        for (int i = 0; i < colGradPositions.Length; i++)
                        {
                            if (colGradPositions.Length >= i)
                            {
                                m_Floats[i] = colGradPositions[i];
                            }
                        }
                        //Reset the positions fro the length of the colors
                        colGradPositions = new float[value.Length];
                        //Copy the origional values back in
                        for (int i = 0; i < m_Floats.Length; i++)
                        {
                            colGradPositions[i] = m_Floats[i];
                        }
                    }
                    BuildBrush();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the positions of each color in the gradient color array when in 3D shading mode.
        /// </summary>
        /// <value>The gradient positions.</value>
        [Description("Sets the positions of each color in the gradient color array when in 3D shading mode."), Category("Drawing")]
        public float[] GradientPositions
        {
            get { return colGradPositions; }
            set
            {
                if (colGradPositions != value)
                {
                    colGradPositions = value;
                    BuildBrush();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Activates/Deactivates the drawing on the object.
        /// </summary>
        /// <value><c>true</c> if z object; otherwise, <c>false</c>.</value>
        [Description("Activates/Deactivates the drawing on the object."), Category("Drawing")]
        public bool zObject
        {
            get { return objInitialized; }
            set { objInitialized = value; DrawObject(); }
        }

        /// <summary>
        /// Gets or sets the radius of the rounded corners when applicable.
        /// </summary>
        /// <value>The corner radius.</value>
        [Description("Sets the radius of the rounded corners when applicable."), Category("Drawing")]
        public double CornerRadius
        {
            get { return ImageRadius; }
            set
            {
                if (value >= 0.1 & value < 1)
                {
                    if (ImageRadius != value)
                    {
                        ImageRadius = value;
                        if (ImageShape == ButtonShapes.Rnded_Rectangle ||
                            ImageShape == ButtonShapes.Rnded_Square)
                        {
                            DrawObject();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        [Description("Sets the Direction of the object when applicable"), Category("Drawing")]
        public ButtonDirection Direction
        {
            get { return ImageDirection; }
            set
            {
                if (ImageDirection != value)
                {
                    ImageDirection = value;
                    BuildObject();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the background opacity.
        /// </summary>
        /// <value><c>true</c> if transparent background; otherwise, <c>false</c>.</value>
        [Description("Sets the background opacity."), Category("Drawing")]
        public bool TransparentBackground
        {
            get { return ObjTransParent; }
            set
            {
                if (ObjTransParent != value)
                {
                    ObjTransParent = value;
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the style of line to draw the object.
        /// </summary>
        /// <value>The line style.</value>
        [Description("Sets/Gets the style of line to draw the object."), Category("Drawing")]
        public DashStyle LineStyle
        {
            get { return ImageLnStyle; }
            set
            {
                if (ImageLnStyle != value)
                {
                    ImageLnStyle = value;
                    grfxPen = GetPen();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not to draw an outline around the object.
        /// </summary>
        /// <value><c>true</c> if outline; otherwise, <c>false</c>.</value>
        [Description("Sets/Gets whether or not to draw an outline around the object."), Category("Drawing")]
        public bool OutLine
        {
            get { return objOutLine; }
            set
            {
                if (objOutLine != value)
                {
                    objOutLine = value;
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value>The border style.</value>
        [Description("Sets/Gets the shape BorderStyle."), Category("Drawing")]
        public BorderStyle BorderStyle
        {
            get { return picImage.BorderStyle; }
            set
            {
                if (picImage.BorderStyle != value)
                {
                    picImage.BorderStyle = value;
                }
            }
        }
        //Colors
        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCShape"/> class.
        /// </summary>
        public ZeroitCShape()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// 
        #region Build Brushes/Pen
        //Builds the Pen object used to draw the shape
        private Pen GetPen()
        {
            //Here you set the pen linestyle,color and thickness
            Pen t_Pen = new Pen(colOutLine, ImageDrawWidth);
            t_Pen.DashStyle = ImageLnStyle;
            return t_Pen;
        }

        //Builds a 2 Color LinearGradientBrush
        private LinearGradientBrush BuildBrushes()
        {
            //Build the Brush and set it's Paint Area, The Alternate Color
            //The Primary Color, and the Gradient Mode
            return new LinearGradientBrush(this.ClientRectangle,
                colAlternate, colFill, ImageGradientMode);
        }

        //Builds a 1 Color LinearGradientBrush
        private LinearGradientBrush BuildFlatBrush()
        {
            //Build the Brush and set it's Paint Area, The Alternate Color=Primary Color
            //The Primary Color, and the Gradient Mode is defaulted, because there is not 
            //Visible gradient
            return new LinearGradientBrush(this.ClientRectangle,
                colFill, colFill, LinearGradientMode.Vertical);
        }

        //Builds a User-Defined LinearGradientBrush
        private LinearGradientBrush Build3DBrush()
        {
            //Multi Colored brushes are a little more difficult than the standard
            //2 color brush.
            //First thing, check for the usable properties and ensure that they are 
            //properly setup. If not just send it to the gradient brush function until they are
            //Setup properly, that will give them an image to see at least.
            //Make sure there are colors in the Color Array
            if (colGradColors == null || colGradColors.Length <= 0)
            { MessageBox.Show("No Colors Assigned to color Array!"); return BuildBrushes(); }
            //Make sure there are positions to set the colors in the color array properly
            //into the brush gradient
            if (colGradPositions == null || colGradPositions.Length <= 0)
            { MessageBox.Show("No Color positions assigned to positions array!"); return BuildBrushes(); }
            //Make sure that the color array has the same number of elements as 
            //the Color position array or it will bomb. 
            if (colGradPositions.Length != colGradPositions.Length)
            { MessageBox.Show("Different amount of color from positions!"); return BuildBrushes(); }
            //Create an new standard LinearGradientBrush as you would any other
            LinearGradientBrush lBrush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height),
                colAlternate, colFill, ImageGradientMode);
            try
            {
                //Create a Color Blend object. The ColorBlend brings together the Colors Selected
                //And the positions the user wants them put at.
                ColorBlend cBlend = new ColorBlend((int)(colGradColors.Length - 1));
                //Set the user-defined Colors
                cBlend.Colors = colGradColors;
                //Set the user-defined Positions for the Colors
                cBlend.Positions = colGradPositions;
                //Set the LinearGradientBrush's Interpolation Colors. Layman- Tell the brush
                //to paint each color to a certain percent of the fillarea and then begin the next
                //color accordingly
                lBrush.InterpolationColors = cBlend;
                //Return your newly created 3D brush;
                return lBrush;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string Message = "There was an error, Check your Gradient Positions.\r\n";
                Message += "Make Sure that the First Position is 0.0 And the Last Position is 1.0. \r\n";
                Message += "Make Sure that Number of Colors matches the number of positions.";
                MessageBox.Show(Message);
                return BuildBrushes();
            }

        }

        //Builds a HatchBrush
        private HatchBrush BuildHatchBrush()
        {
            //Very Simple Brush
            //Here you set the brush HatchStyle,AlternateColr and PrimaryColor
            return new HatchBrush(ImageHatchStyle, colAlternate, colFill);
        }
        //Builds a Brush that is defiend for a GraphicsPath-created earlier
        private PathGradientBrush BuildPathBrush(GraphicsPath pth)
        {
            //First Create a generic Path Brush, using the graphicsPath(shape)
            //Passed in.
            PathGradientBrush brsh = new PathGradientBrush(pth);
            //Set the CenterColor for the brush, since this brush is being used for circular
            //shapes
            brsh.CenterColor = colAlternate;
            //Set the Surround Color tot he promary color for the brush, since this brush 
            //is being used for circular shapes
            brsh.SurroundColors = new Color[] { colFill };
            return brsh;
        }
        #endregion

        #region Build Objects
        private GraphicsPath BuildRect()
        {
            //Create a new Graphics Path
            GraphicsPath grfxPath = new GraphicsPath();
            //Create a new Rectangle for Calculations
            Rectangle grfxRect = new Rectangle();
            //Set the New Rectangle bound = to the control bounds
            grfxRect = new Rectangle(0, 0, (int)(this.Width - 1), (int)(this.Height - 1));
            try
            {
                //Start the Figure
                grfxPath.StartFigure();
                //Add the shape to the Path
                grfxPath.AddRectangle(grfxRect);
                //Close the Path, this ensures that all line will form 
                //one Continuous shape outline
                grfxPath.CloseFigure();
                //Return the Path to be drawn and filled
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        private GraphicsPath BuildSquare()
        {
            //Create a new Graphics Path
            GraphicsPath grfxPath = new GraphicsPath();
            //Create a new Rectangle for Calculations
            Rectangle grfxRect = new Rectangle();
            int m_Diff = 0;
            if (this.Height > this.Width)
            {
                m_Diff = (int)((this.Height - this.Width) * .5);
                grfxRect = new Rectangle(0, (int)(m_Diff - 1), (int)(this.Width - 1), (int)(this.Height - (m_Diff * 2)));
            }
            else
            {
                m_Diff = (int)((this.Width - this.Height) * .5);
                grfxRect = new Rectangle((int)(m_Diff - 1), 0, (int)(this.Width - (m_Diff * 2)), (int)(this.Height - 1));
            }

            try
            {
                grfxPath.StartFigure();
                grfxPath.AddRectangle(grfxRect);
                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        private GraphicsPath BuildOval()
        {
            //Create a new Graphics Path
            GraphicsPath grfxPath = new GraphicsPath();
            //Create a new Rectangle for Calculations
            Rectangle grfxRect = new Rectangle();
            //Set the New Rectangle bound = to the control bounds
            grfxRect = new Rectangle(0, 0, (int)(this.Width - 1), (int)(this.Height - 1));
            try
            {
                grfxPath.StartFigure();
                grfxPath.AddEllipse(grfxRect);
                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        private GraphicsPath BuildCircle()
        {
            //Create a new Graphics Path
            GraphicsPath grfxPath = new GraphicsPath();
            //Create a new Rectangle for Calculations
            Rectangle grfxRect = new Rectangle();
            int m_Diff = 0;
            if (this.Height > this.Width)
            {
                m_Diff = (int)((this.Height - this.Width) * .5);
                grfxRect = new Rectangle(0, (int)(m_Diff - 1), (int)(this.Width - 1), (int)(this.Height - (m_Diff * 2)));
            }
            else
            {
                m_Diff = (int)((this.Width - this.Height) * .5);
                grfxRect = new Rectangle((int)(m_Diff - 1), 0, (int)(this.Width - (m_Diff * 2)), (int)(this.Height - 1));
            }

            try
            {
                grfxPath.StartFigure();
                grfxPath.AddEllipse(grfxRect);
                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        private GraphicsPath BuildRndRect()
        {
            //Create a new Graphics Path
            GraphicsPath grfxPath = new GraphicsPath();
            //Create a new Rectangle for Calculations
            Rectangle grfxRect = new Rectangle();
            //Set the New Rectangle bound = to the control bounds
            grfxRect = new Rectangle(0, 0, (int)(this.Width - 1), (int)(this.Height - 1));
            //The Radius of the rounded edges
            float radius = (int)(grfxRect.Height * ImageRadius);
            //Width of the rectangle
            float width = (int)(grfxRect.Width);
            //Height of the rectangle
            float height = (int)(grfxRect.Height);
            //Following two lines are simply the Location of the rectangle
            float X = grfxRect.Left;
            float Y = grfxRect.Top;
            //Make sure the radius is a valid value
            if (radius < 1) { radius = 1; }
            try
            {
                grfxPath.StartFigure();
                grfxPath.AddLine(X + radius, Y, X + width - (radius * 2), Y);
                grfxPath.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
                grfxPath.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
                grfxPath.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
                grfxPath.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
                grfxPath.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
                grfxPath.AddLine(X, Y + height - (radius * 2), X, Y + radius);
                grfxPath.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        private GraphicsPath BuildRndSquare()
        {
            //Create a new Graphics Path
            GraphicsPath grfxPath = new GraphicsPath();
            //Create a new Rectangle for Calculations
            Rectangle grfxRect = new Rectangle();
            int m_Diff = 0;
            if (this.Height > this.Width)
            {
                m_Diff = (int)((this.Height - this.Width) * .5);
                grfxRect = new Rectangle(0, (int)(m_Diff - 1), (int)(this.Width - 1), (int)(this.Height - (m_Diff * 2)));
            }
            else
            {
                m_Diff = (int)((this.Width - this.Height) * .5);
                grfxRect = new Rectangle((int)(m_Diff - 1), 0, (int)(this.Width - (m_Diff * 2)), (int)(this.Height - 1));
            }
            float radius = (int)(grfxRect.Width * ImageRadius);
            float width = (int)(grfxRect.Width);
            float height = (int)(grfxRect.Height);
            float X = grfxRect.Left;
            float Y = grfxRect.Top;

            try
            {
                grfxPath.StartFigure();
                grfxPath.AddLine(X + radius, Y, X + width - (radius * 2), Y);
                grfxPath.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
                grfxPath.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
                grfxPath.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
                grfxPath.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
                grfxPath.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
                grfxPath.AddLine(X, Y + height - (radius * 2), X, Y + radius);
                grfxPath.AddArc(X, Y, radius * 2, radius * 2, 180, 90);

                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        private GraphicsPath BuildTriangle()
        {
            GraphicsPath grfxPath = new GraphicsPath();
            Rectangle grfxRect = new Rectangle();
            int m_Diff = 0;
            if (this.Height > this.Width)
            {
                m_Diff = (int)((this.Height - this.Width) * .5);
                grfxRect = new Rectangle(0, (int)(m_Diff - 1), (int)(this.Width - 1), (int)(this.Height - (m_Diff * 2)));
            }
            else
            {
                m_Diff = (int)((this.Width - this.Height) * .5);
                grfxRect = new Rectangle((int)(m_Diff - 1), 0, (int)(this.Width - (m_Diff * 2)), (int)(this.Height - 1));
            }
            m_Diff = grfxRect.Left;
            try
            {
                grfxPath.StartFigure();
                switch (ImageDirection)
                {
                    default:
                    case ButtonDirection.Top:
                        grfxPath.AddLine((int)(this.Width * .5), 0, 0, (int)(this.Height - 1));
                        grfxPath.AddLine(0, (int)(this.Height - 1), this.Width, (int)(this.Height - 1));
                        grfxPath.AddLine(this.Width, (int)(this.Height - 1), (int)(this.Width * .5), 0);
                        break;
                    case ButtonDirection.Right:
                        grfxPath.AddLine(0, 0, 0, (int)(this.Height - 1));
                        grfxPath.AddLine(0, (int)(this.Height - 1), (int)(this.Width - 1), (int)(this.Height * .5));
                        grfxPath.AddLine((int)(this.Width - 1), (int)(this.Height * .5), 0, 0);
                        break;
                    case ButtonDirection.Bottom:
                        grfxPath.AddLine(0, 0, (int)(this.Width * .5), (int)(this.Height - 1));
                        grfxPath.AddLine((int)(this.Width * .5), (int)(this.Height - 1), this.Width, 0);
                        grfxPath.AddLine(this.Width, 0, 0, 0);
                        break;
                    case ButtonDirection.Left:
                        grfxPath.AddLine(0, (int)(this.Height * .5), (int)(this.Width - 1), (int)(this.Height - 1));
                        grfxPath.AddLine((int)(this.Width - 1), (int)(this.Height - 1), (int)(this.Width - 1), 0);
                        grfxPath.AddLine((int)(this.Width - 1), 0, 0, (int)(this.Height * .5));
                        break;
                }
                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        private GraphicsPath BuildArrow()
        {
            GraphicsPath grfxPath = new GraphicsPath();
            Rectangle grfxRect = new Rectangle();
            int m_Diff = 0;
            if (this.Height > this.Width)
            {
                m_Diff = (int)((this.Height - this.Width) * .5);
                grfxRect = new Rectangle(0, (int)(m_Diff - 1), (int)(this.Width - 1), (int)(this.Height - (m_Diff * 2)));
            }
            else
            {
                m_Diff = (int)((this.Width - this.Height) * .5);
                grfxRect = new Rectangle((int)(m_Diff - 1), 0, (int)(this.Width - (m_Diff * 2)), (int)(this.Height - 1));
            }
            m_Diff = grfxRect.Left;
            try
            {
                grfxPath.StartFigure();
                switch (ImageDirection)
                {
                    default:
                    case ButtonDirection.Top:
                        grfxPath.AddLine((int)(this.Width * .5), 0, 0, (int)(this.Height - 1));
                        grfxPath.AddLine(0, (int)(this.Height - 1), (int)(this.Width * .5), (int)(this.Height * .8));
                        grfxPath.AddLine((int)(this.Width * .5), (int)(this.Height * .8), this.Width, (int)(this.Height - 1));
                        grfxPath.AddLine(this.Width, (int)(this.Height - 1), (int)(this.Width * .5), 0);
                        break;
                    case ButtonDirection.Right:
                        grfxPath.AddLine(0, 0, (int)(this.Width * .2), (int)(this.Height * .5));
                        grfxPath.AddLine((int)(this.Width * .2), (int)(this.Height * .5), 0, (int)(this.Height - 1));
                        grfxPath.AddLine(0, (int)(this.Height - 1), (int)(this.Width - 1), (int)(this.Height * .5));
                        grfxPath.AddLine((int)(this.Width - 1), (int)(this.Height * .5), 0, 0);
                        break;
                    case ButtonDirection.Bottom:
                        grfxPath.AddLine(0, 0, (int)(this.Width * .5), (int)(this.Height - 1));
                        grfxPath.AddLine((int)(this.Width * .5), (int)(this.Height - 1), this.Width, 0);
                        grfxPath.AddLine(this.Width, 0, (int)(this.Width * .5), (int)(this.Height * .2));
                        grfxPath.AddLine((int)(this.Width * .5), (int)(this.Height * .2), 0, 0);
                        break;
                    case ButtonDirection.Left:
                        grfxPath.AddLine(0, (int)(this.Height * .5), (int)(this.Width - 1), (int)(this.Height - 1));

                        grfxPath.AddLine((int)(this.Width - 1), (int)(this.Height - 1),
                            (int)(this.Width * .8), (int)(this.Height * .5));

                        grfxPath.AddLine((int)(this.Width * .8), (int)(this.Height * .5),
                            (int)(this.Width - 1), 0);

                        grfxPath.AddLine((int)(this.Width - 1), 0, 0, (int)(this.Height * .5));
                        break;
                }
                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #region Build and Draw Routines
        //The BuildObject Routine determines the object selected as the shape
        //and builds it accordingly
        private void BuildObject()
        {
            switch (ImageShape)
            {
                default:
                case ButtonShapes.Square:
                    grfxObject = this.BuildSquare();
                    ObjIsCirc = false;
                    break;
                case ButtonShapes.Rnded_Square:
                    grfxObject = this.BuildRndSquare();
                    ObjIsCirc = false;
                    break;
                case ButtonShapes.Rectangle:
                    grfxObject = this.BuildRect();
                    ObjIsCirc = false;
                    break;
                case ButtonShapes.Rnded_Rectangle:
                    grfxObject = this.BuildRndRect();
                    ObjIsCirc = false;
                    break;
                case ButtonShapes.Circle:
                    grfxObject = this.BuildCircle();
                    ObjIsCirc = true;
                    break;
                case ButtonShapes.Oval:
                    grfxObject = this.BuildOval();
                    ObjIsCirc = true;
                    break;
                case ButtonShapes.Triangle:
                    grfxObject = BuildTriangle();
                    ObjIsCirc = false;
                    break;
                case ButtonShapes.Arrow:
                    grfxObject = BuildArrow();
                    ObjIsCirc = false;
                    break;
            }
            BuildBrush();
        }

        //The BuildBrush Routine determines what type of fill was selected for the shape
        //And Builds a brush to accordingly
        private void BuildBrush()
        {
            switch (Image3DStyle)
            {
                default:
                case Button3DShape.Flat:
                    if (ImageHatched == true)
                    {
                        grfxBrush = this.BuildHatchBrush();
                    }
                    else
                    {
                        grfxBrush = this.BuildFlatBrush();
                    }
                    break;
                case Button3DShape.Shaded:
                    grfxBrush = this.BuildBrushes();
                    break;
                case Button3DShape.Shaded3D:
                    if (ObjIsCirc == true)
                    {
                        grfxBrush = this.BuildPathBrush(grfxObject);
                    }
                    else
                    {
                        grfxBrush = this.Build3DBrush();
                    }
                    break;
            }
        }
        //The Rebuild() Routine re-Builds all elements on the screen
        private void ReBuild()
        {
            //Build the pen object
            grfxPen = GetPen();
            //Build the object
            BuildObject();
            //Draw The Object to the screen
            DrawObject();
        }

        //The DrawObject routine is the routine responsible for presenting the 
        //Image to the screen after it is drawn. It utilized a seperate Image Created
        //in Memory to do the drawing and then sets it's image to the screen.
        private void DrawObject()
        {
            //if(objInitialized==false){return;}
            //Create the graphics Object and set Quality
            Bitmap bit = new Bitmap(picImage.Width, picImage.Height);
            Graphics grfx = Graphics.FromImage(bit);
            grfx.SmoothingMode = ImageQuality;

            try
            {
                //Present the Shape
                grfx.FillPath(grfxBrush, grfxObject);
                //Only draw an Outline if the user wants it.
                //Point to remember when drawing in GDI+. If you want a good outline
                //Draw the outline last. To view the difference switch the previous line
                //with the following line.
                if (objOutLine == true) { grfx.DrawPath(grfxPen, grfxObject); }
                //Set the background properties
                if (ObjTransParent == true)
                {
                    this.Region = new Region(grfxObject);
                }
                else
                {
                    this.Region = new Region(this.ClientRectangle);
                }
                picImage.Image = bit;
                picImage.Refresh();
                bit = null;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
            }
            finally
            {
                //Graphics and Pen
                grfx.Dispose(); grfx = null;
            }
        }

        #endregion

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picImage = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(17, 17);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(59, 141);
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            this.picImage.DoubleClick += new System.EventHandler(this.picImage_DoubleClick);
            // 
            // csShape
            // 
            this.Controls.Add(this.picImage);
            this.Resize += new System.EventHandler(this.csShape_Resize);
            this.Size = new System.Drawing.Size(67, 150);
            this.ResumeLayout(false);

        }
        #endregion

        #region resize Events
        private void csShape_Paint(object sender, System.EventArgs e)
        {
            try
            {
                ReBuild();
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
            }
        }

        private void csShape_Resize(object sender, System.EventArgs e)
        {
            try
            {
                picImage.Location = new Point(0, 0);
                picImage.Size = new Size(this.Width, this.Height);
                ReBuild();
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
            }
        }

        private void picImage_Click(object sender, System.EventArgs e)
        {
            OnClick(e);
        }

        private void picImage_DoubleClick(object sender, System.EventArgs e)
        {
            OnDoubleClick(e);
        }

        #endregion

        #region Process Management
        private void ManageMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                //Tell the machine to swap processes
                Int32 RetVal = SetProcessWorkingSetSize((int)
                    System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion
    }

    #endregion

    #endregion


}
