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
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region MovingBorder Button

    #region Graphics Buffer


    // ****************************************** class GraphicsBuffer

    public class GraphicsBuffer
    {
        Bitmap bitmap;
        Graphics graphic;
        int height;
        string name;
        int width;

        // ******************************************** GraphicsBuffer

        /// <summary>
        /// constructor for the GraphicsBuffer
        /// </summary>
        public GraphicsBuffer()
        {

            Width = 0;
            Height = 0;
            Name = String.Empty;
        }

        // **************************************************** Bitmap

        public Bitmap Bitmap
        {

            get
            {
                return (bitmap);
            }

            set
            {
                bitmap = value;
            }
        }

        // **************************************************** Height

        public int Height
        {

            get
            {
                return (height);
            }

            set
            {
                if (value != height)
                {
                    height = value;
                }
            }
        }

        // ****************************************************** Name

        public string Name
        {

            get
            {
                return (name);
            }

            set
            {
                if (value != name)
                {
                    name = value;
                }
            }
        }

        // ***************************************************** Width

        public int Width
        {

            get
            {
                return (width);
            }

            set
            {
                if (value != width)
                {
                    width = value;
                }
            }
        }

        // ************************************** CreateGraphicsBuffer

        /// <summary>
        /// completes the creation of the GraphicsBuffer object
        /// </summary>
        /// <param name="name">
        /// optional name of the graphics buffer
        /// </param>
        /// <param name="width">
        /// width of the bitmap
        /// </param>
        /// <param name="height">
        /// height of the bitmap
        /// </param>
        /// <returns>
        /// true, if GraphicsBuffer created; otherwise, false
        /// </returns>
        public bool CreateGraphicsBuffer(string name,
                                           int width,
                                           int height)
        {
            bool success = true;

            if (graphic != null)
            {
                graphic.Dispose();
                graphic = null;
            }

            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }

            Width = 0;
            Height = 0;
            Name = String.Empty;

            if ((width == 0) || (height == 0))
            {
                success = false;
            }
            else
            {
                Width = width;
                Height = height;
                Name = name;

                bitmap = new Bitmap(Width, Height);
                graphic = Graphics.FromImage(bitmap);

                success = true;
            }

            return (success);
        }

        // ************************************** CreateGraphicsBuffer

        public bool CreateGraphicsBuffer(int width,
                                           int height)
        {

            return (CreateGraphicsBuffer(String.Empty,
                                            width,
                                            height));
        }

        // ********************************** InitializeGraphicsBuffer

        public bool InitializeGraphicsBuffer(string name,
                                               int width,
                                               int height)
        {

            return (CreateGraphicsBuffer(name,
                                            width,
                                            height));
        }

        // *********************************************** ClearBitmap

        public void ClearBitmap(Color background_color)
        {

            Graphic.Clear(background_color);
        }

        // ************************************** DeleteGraphicsBuffer

        /// <summary>
        /// deletes the current GraphicsBuffer
        /// </summary>
        /// <returns>
        /// null, always
        /// </returns>
        public GraphicsBuffer DeleteGraphicsBuffer()
        {

            if (graphic != null)
            {
                graphic.Dispose();
                graphic = null;
            }

            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }

            Width = 0;
            Height = 0;
            Name = String.Empty;

            return (null);
        }

        // *************************************************** Graphic

        /// <summary>
        /// returns the current Graphic Graphics object
        /// </summary>
        public Graphics Graphic
        {

            get
            {
                return (graphic);
            }
        }

        // ************************************** GraphicsBufferExists

        /// <summary>
        /// returns true if the grapgics object exists; false, 
        /// otherwise
        /// </summary>
        public bool GraphicsBufferExists
        {

            get
            {
                return (graphic != null);
            }
        }

        // ******************************************* ColorAtLocation

        /// <summary>
        /// given a point in the graphic bitmap, returns the GDI 
        /// Color at that point
        /// </summary>
        /// <param name="location">
        /// location in the bitmap from which the color is to be 
        /// returned
        /// </param>
        /// <returns>
        /// if the location is within the bitmap, the color at the 
        /// location; otherwise, Black
        /// </returns>
        public Color ColorAtLocation(Point location)
        {
            Color color = Color.Black;

            if (((location.X > 0) &&
                   (location.X <= Width)) &&
                 ((location.Y > 0) &&
                   (location.Y <= Height)))
            {
                color = this.bitmap.GetPixel(location.X,
                                               location.Y);
            }

            return (color);
        }

        // ************************************** RenderGraphicsBuffer

        /// <summary>
        /// Renders the buffer to the graphic object identified by 
        /// graphic
        /// </summary>
        /// <param name="graphic">
        /// target graphic object (e.g., PaintEventArgs e.Graphics)
        /// </param>
        public void RenderGraphicsBuffer(Graphics graphics)
        {

            if (bitmap != null)
            {
                graphics.DrawImage(
                            bitmap,
                            new Rectangle(0, 0, Width, Height),
                            new Rectangle(0, 0, Width, Height),
                            GraphicsUnit.Pixel);
            }
        }

        // ********************************************* ClearGraphics

        /// <summary>
        /// clears the graphic object identified by graphic
        /// </summary>
        /// <param name="graphic">
        /// Window forms graphic object
        /// </param>
        /// <param name="background_color">
        /// background color to be used to clear graphic
        /// </param>
        public void ClearGraphics(Color background_color)
        {

            Graphic.Clear(background_color);
        }

    } // class GraphicsBuffer

    #endregion

    #region Control

    // ************************************** class MovingBorderButton    
    /// <summary>
    /// A class collection for rendering a moving representing.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Button" />
    [Designer(typeof(ZeroitButtonMovingBorderButtonDesigner))]
    public class ZeroitButtonMovingBorder : Button
    {
        #region Constants


        // ******************************************* class constants

        const int DASH_LENGTH = 4;
        const int PEN_WIDTH = 2;
        const double TIMER_INTERVAL = 100.0;
        // border edge constants
        const int TOP = 0;
        const int RIGHT = TOP + 1;
        const int BOTTOM = RIGHT + 1;
        const int LEFT = BOTTOM + 1;
        const int EDGES = LEFT + 1;
        #endregion

        #region Variables



        // ******************************************* class variables

        int dash_length = DASH_LENGTH;
        float[] dash_pattern = new float[]
                                {
                                DASH_LENGTH / PEN_WIDTH,
                                DASH_LENGTH / PEN_WIDTH
                                };
        Point[] end_at = new Point[EDGES];
        bool initialized = false;
        GraphicsBuffer moving_border_graphic = null;
        bool move_button_border = false;
        Pen moving_border_pen = null;
        int pen_width = PEN_WIDTH;
        Point[] start_at = new Point[EDGES];
        System.Timers.Timer timer = null;
        double timer_interval = TIMER_INTERVAL;
        #endregion

        #region Memory_Cleanup


        // ******************************************** memory_cleanup

        /// <summary>
        /// cleans up any GDI or timer objects to avoid memory leaks
        /// </summary>
        void memory_cleanup(object sender,
                              EventArgs e)
        {

            if (timer != null)
            {
                if (timer.Enabled)
                {
                    timer.Elapsed -= new ElapsedEventHandler(tick);
                    timer.Stop();
                }
                timer = null;
            }

            if (moving_border_graphic != null)
            {
                moving_border_graphic.DeleteGraphicsBuffer();
            }

            if (moving_border_pen != null)
            {
                moving_border_pen.Dispose();
                moving_border_pen = null;
            }
        }

        #endregion

        #region Contrasting Color


        // ***************************************** contrasting_color

        /// <summary>
        /// determines the color (black or white) that contrasts with 
        /// the given color
        /// </summary>
        /// <param name="color">
        /// color for which to find its contrasting color
        /// </param>
        /// <returns>
        /// the contrasting color (black or white)
        /// </returns>
        /// <reference>
        /// http://stackoverflow.com/questions/1855884/
        ///     determine-font-color-based-on-background-color
        /// </reference>
        Color contrasting_color(Color color)
        {
            double a;
            int d = 0;

            a = 1.0 - ((0.299 * color.R +
                          0.587 * color.G +
                          0.114 * color.B) / 255.0);

            if (a < 0.5)
            {
                d = 0;                  // bright colors - black font
            }
            else
            {
                d = 255;                // dark colors - white font
            }

            return (Color.FromArgb(d, d, d));
        }

        #endregion

        #region Moving Pen


        // ********************************** create_moving_border_pen

        /// <summary>
        /// creates the pen that will be used to draw the moving 
        /// border
        /// </summary>
        void create_moving_border_pen()
        {

            if (moving_border_pen != null)
            {
                moving_border_pen.Dispose();
                moving_border_pen = null;
            }

            moving_border_pen =
                new Pen(contrasting_color(BackColor),
                          PenWidth);

            dash_pattern = new float[]
                                {
                                DashLength / PenWidth,
                                DashLength / PenWidth
                                };

            moving_border_pen.DashPattern = dash_pattern;
            moving_border_pen.DashOffset = 0.0F;
            moving_border_pen.DashStyle = DashStyle.Custom;
            moving_border_pen.EndCap = LineCap.Flat;
            moving_border_pen.StartCap = LineCap.Flat;
        }

        #endregion

        #region Initialize Starts and Ends



        // ******************************** initialize_starts_and_ends

        /// <summary>
        /// performs the initialization of the TOP, RIGHT, BOTTOM, and 
        /// LEFT edges starting and ending points; initialization is 
        /// performed by the OnPaint event handler when the button's 
        /// size is known
        /// </summary>
        void initialize_starts_and_ends()
        {
            // initialization is performed 
            // once during OnPaint when 
            // the button's size is known
            for (int i = 0; (i < EDGES); i++)
            {
                switch (i)
                {
                    case TOP:
                        start_at[TOP] = new Point(
                            -(DashLength - 1),
                            (PenWidth / 2));
                        end_at[TOP] = start_at[TOP];
                        end_at[TOP].X = this.Width +
                                           DashLength;
                        break;
                    case RIGHT:
                        start_at[RIGHT] = new Point(
                            this.Width - (PenWidth / 2) - 1,
                            -(DashLength - 1));
                        end_at[RIGHT] = start_at[RIGHT];
                        end_at[RIGHT].Y = this.Height +
                                             DashLength;
                        break;

                    case BOTTOM:
                        start_at[BOTTOM] = new Point(
                            this.Width + (DashLength - 1),
                            this.Height - (PenWidth / 2) - 1);
                        end_at[BOTTOM] = start_at[BOTTOM];
                        end_at[BOTTOM].X = -DashLength;
                        break;

                    case LEFT:
                        start_at[LEFT] = new Point(
                            (PenWidth / 2),
                            this.Height + (DashLength - 1));
                        end_at[LEFT] = start_at[LEFT];
                        end_at[LEFT].Y = -DashLength;
                        break;

                    default:
                        break;
                }
            }

            initialized = true;
        }
        #endregion

        #region Revise Start Ats


        // ****************************************** revise_start_ats

        /// <summary>
        /// revises the TOP, RIGHT, BOTTOM, and LEFT edges starting 
        /// point at each timer tick; revision is performed by the 
        /// OnPaint event handler
        /// </summary>
        void revise_start_ats()
        {

            start_at[TOP].X++;
            if (start_at[TOP].X >= DashLength)
            {
                start_at[TOP].X = -(DashLength + 1);
            }

            start_at[RIGHT].Y++;
            if (start_at[RIGHT].Y >= DashLength)
            {
                start_at[RIGHT].Y = -(DashLength - 1);
            }

            start_at[BOTTOM].X--;
            if (start_at[BOTTOM].X <= this.Width - DashLength)
            {
                start_at[BOTTOM].X =
                    this.Width + (DashLength - 1);
            }

            start_at[LEFT].Y--;
            if (start_at[LEFT].Y <= this.Height - DashLength)
            {
                start_at[LEFT].Y =
                    this.Height + (DashLength - 1);
            }
        }
        #endregion

        #region Create Moving Border Graphic
        // ***************************** create_moving_border_graphic

        /// <summary>
        /// creates the graphic image of the moving border that will be 
        /// rendered on the button's surface
        /// </summary>
        /// 

        void create_moving_border_graphic()
        {
            // delete existing buffer
            if (moving_border_graphic != null)
            {
                moving_border_graphic = moving_border_graphic.
                                       DeleteGraphicsBuffer();
            }
            // create a new buffer
            moving_border_graphic = new GraphicsBuffer();
            moving_border_graphic.InitializeGraphicsBuffer(
                                                      "Moving",
                                                      this.Width,
                                                      this.Height);
            moving_border_graphic.Graphic.SmoothingMode =
                SmoothingMode.HighQuality;
            // draw the border edges
            for (int i = 0; (i < EDGES); i++)
            {
                moving_border_graphic.Graphic.DrawLine(
                    moving_border_pen,
                    start_at[i],
                    end_at[i]);
            }
        }

        #endregion

        #region Moving Border Button


        // ***************************************** MovingBorderButton

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonMovingBorder"/> class.
        /// </summary>
        public ZeroitButtonMovingBorder()
        {

            this.SetStyle((ControlStyles.DoubleBuffer |
                              ControlStyles.UserPaint |
                              ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw),
                            true);
            this.UpdateStyles();

            this.Disposed += new EventHandler(memory_cleanup);
        }

        // ****************************************************** tick

        /// <summary>
        /// handles the timer's elapsed time event
        /// </summary>
        /// <note>
        /// this event handler executes in a thread separate from the 
        /// user interface thread and therefore needs to use Invoke
        /// </note>
        void tick(object source,
                    ElapsedEventArgs e)
        {

            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(
                        new EventHandler(
                            delegate
                            {
                                this.Refresh();
                            }
                            )
                        );
                }
                else
                {
                    this.Refresh();
                }
            }
            catch
            {

            }
        }

        #endregion

        #region DashLength


        // ************************************************ DashLength

        /// <summary>
        /// Gets or sets the length of the dash.
        /// </summary>
        /// <value>The length of the dash.</value>
        [Category("Appearance"),
          Description("Sets/Gets length of the button border dashes"),
          DefaultValue(typeof(int), "6"),
          Bindable(true)]
        public int DashLength
        {

            get
            {
                return (dash_length);
            }

            set
            {
                if (dash_length != value)
                {
                    if (value > PenWidth)
                    {
                        dash_length = value;
                        create_moving_border_pen();
                        this.Invalidate();
                    }
                }
            }
        }

        #endregion

        #region Move Button Border

        // ****************************************** MoveButtonBorder        
        /// <summary>
        /// Gets or sets a value indicating whether to move the button border.
        /// </summary>
        /// <value><c>true</c> if move button border; otherwise, <c>false</c>.</value>
        [Category("Appearance"),
          Description("Specifies if button border should move"),
          DefaultValue(typeof(bool), "false"),
          Bindable(true)]
        public bool MoveButtonBorder
        {

            get
            {
                return (move_button_border);
            }

            set
            {
                move_button_border = value;
                if (move_button_border)
                {
                    // prevent button from drawing 
                    // its own border
                    FlatAppearance.BorderSize = 0;
                    FlatStyle = FlatStyle.Flat;

                    if (timer == null)
                    {
                        timer = new System.Timers.Timer();
                        timer.Elapsed +=
                            new ElapsedEventHandler(tick);
                        timer.Interval = timer_interval;
                        timer.Start();
                    }
                }
                else
                {
                    if (timer != null)
                    {
                        if (timer.Enabled)
                        {
                            timer.Elapsed -=
                                new ElapsedEventHandler(tick);
                            timer.Stop();
                        }
                        timer = null;
                    }
                    // allow button to draw its 
                    // own border
                    FlatAppearance.BorderSize = 1;
                    FlatStyle = FlatStyle.Standard;
                }

                Invalidate();
            }
        }
        #endregion

        #region Pen Width

        // ************************************************** PenWidth        
        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        [Category("Appearance"),
          Description("Sets/Gets width of the button border pen"),
          DefaultValue(typeof(int), "2"),
          Bindable(true)]
        public int PenWidth
        {

            get
            {
                return (pen_width);
            }

            set
            {
                if (pen_width != value)
                {
                    if ((value > 0) &&
                         (value < DashLength))
                    {
                        pen_width = value;
                        create_moving_border_pen();
                        this.Invalidate();
                    }
                }
            }
        }

        #endregion

        #region Timer Interval


        // ********************************************* TimerInterval

        [Category("Appearance"),
          Description("Sets/Gets how often button border moves (ms)"),
          DefaultValue(typeof(double), "20.0"),
          Bindable(true)]
        public double TimerInterval
        {

            get
            {
                return (timer_interval);
            }

            set
            {
                timer_interval = value;
                if (timer != null)
                {
                    if (timer.Enabled)
                    {
                        timer.Elapsed -=
                            new ElapsedEventHandler(tick);
                        timer.Stop();
                    }
                    timer = new System.Timers.Timer();
                    timer.Elapsed +=
                        new ElapsedEventHandler(tick);
                    timer.Interval = timer_interval;
                    timer.Start();
                }
            }
        }
        #endregion

        #region OnPaint


        // *************************************************** OnPaint

        /// <summary>
        /// the Paint event handler
        /// </summary>
        /// <note>
        /// the button is drawn in the usual manner by the base 
        /// method; then a border is added if MoveButtonBorder is 
        /// true; note too that MoveButtonBorder makes appropriate 
        /// changes to FlatAppearance and FlatStyle
        /// </note>
        protected override void OnPaint(PaintEventArgs e)
        {
            // have base class paint the 
            // button normally
            base.OnPaint(e);
            // add the moving border only 
            // if border movement was 
            // specified
            if (MoveButtonBorder)
            {
                if (!initialized)
                {
                    initialize_starts_and_ends();
                    create_moving_border_pen();
                }

                create_moving_border_graphic();
                moving_border_graphic.RenderGraphicsBuffer(
                                        e.Graphics);
                revise_start_ats();
            }
        }
        #endregion


    } // class MovingBorderButton

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitButtonMovingBorderButtonDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitButtonMovingBorderSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    public class ZeroitButtonMovingBorderSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        private ZeroitButtonMovingBorder colUserControl;


        private DesignerActionUIService designerActionUISvc = null;


        public ZeroitButtonMovingBorderSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitButtonMovingBorder;

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

        public int DashLength
        {

            get
            {
                return colUserControl.DashLength;
            }
            set
            {
                GetPropertyByName("DashLength").SetValue(colUserControl, value);
            }
        }

        public bool MoveButtonBorder
        {

            get
            {
                return colUserControl.MoveButtonBorder;
            }
            set
            {
                GetPropertyByName("MoveButtonBorder").SetValue(colUserControl, value);
            }
        }

        public int PenWidth
        {

            get
            {
                return colUserControl.PenWidth;
            }
            set
            {
                GetPropertyByName("PenWidth").SetValue(colUserControl, value);
            }
        }

        public double TimerInterval
        {

            get
            {
                return colUserControl.TimerInterval;
            }
            set
            {
                GetPropertyByName("TimerInterval").SetValue(colUserControl, value);
            }
        }


        #endregion

        #region DesignerActionItemCollection

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

            items.Add(new DesignerActionPropertyItem("DashLength",
                                 "Dash Length", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("MoveButtonBorder",
                                 "Move Button Border", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("PenWidth",
                                 "Pen Width", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("TimerInterval",
                                 "Timer Interval", "Appearance",
                                 "Type few characters to filter Cities."));

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
