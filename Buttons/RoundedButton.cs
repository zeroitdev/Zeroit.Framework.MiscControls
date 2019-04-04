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
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region Rounded Button

    //#region Graphics Buffer

    //// ****************************************** class GraphicsBuffer

    //public class RoundedGraphicsBuffer
    //{
    //    Bitmap bitmap;
    //    Graphics graphic;
    //    int height;
    //    string name;
    //    int width;

    //    // ******************************************** GraphicsBuffer

    //    /// <summary>
    //    /// constructor for the GraphicsBuffer
    //    /// </summary>
    //    public RoundedGraphicsBuffer()
    //    {

    //        Width = 0;
    //        Height = 0;
    //        Name = String.Empty;
    //    }

    //    // **************************************************** Bitmap

    //    public Bitmap Bitmap
    //    {

    //        get
    //        {
    //            return (bitmap);
    //        }

    //        set
    //        {
    //            bitmap = value;
    //        }
    //    }

    //    // **************************************************** Height

    //    public int Height
    //    {

    //        get
    //        {
    //            return (height);
    //        }

    //        set
    //        {
    //            if (value != height)
    //            {
    //                height = value;
    //            }
    //        }
    //    }

    //    // ****************************************************** Name

    //    public string Name
    //    {

    //        get
    //        {
    //            return (name);
    //        }

    //        set
    //        {
    //            if (value != name)
    //            {
    //                name = value;
    //            }
    //        }
    //    }

    //    // ***************************************************** Width

    //    public int Width
    //    {

    //        get
    //        {
    //            return (width);
    //        }

    //        set
    //        {
    //            if (value != width)
    //            {
    //                width = value;
    //            }
    //        }
    //    }

    //    // ************************************** CreateGraphicsBuffer

    //    /// <summary>
    //    /// completes the creation of the GraphicsBuffer object
    //    /// </summary>
    //    /// <param name="name">
    //    /// optional name of the graphics buffer
    //    /// </param>
    //    /// <param name="width">
    //    /// width of the bitmap
    //    /// </param>
    //    /// <param name="height">
    //    /// height of the bitmap
    //    /// </param>
    //    /// <returns>
    //    /// true, if GraphicsBuffer created; otherwise, false
    //    /// </returns>
    //    public bool CreateGraphicsBuffer(string name,
    //                                       int width,
    //                                       int height)
    //    {
    //        bool success = true;

    //        if (graphic != null)
    //        {
    //            graphic.Dispose();
    //            graphic = null;
    //        }

    //        if (bitmap != null)
    //        {
    //            bitmap.Dispose();
    //            bitmap = null;
    //        }

    //        Width = 0;
    //        Height = 0;
    //        Name = String.Empty;

    //        if ((width == 0) || (height == 0))
    //        {
    //            success = false;
    //        }
    //        else
    //        {
    //            Width = width;
    //            Height = height;
    //            Name = name;

    //            bitmap = new Bitmap(Width, Height);
    //            graphic = Graphics.FromImage(bitmap);

    //            success = true;
    //        }

    //        return (success);
    //    }

    //    // ************************************** CreateGraphicsBuffer

    //    public bool CreateGraphicsBuffer(int width,
    //                                       int height)
    //    {

    //        return (CreateGraphicsBuffer(String.Empty,
    //                                        width,
    //                                        height));
    //    }

    //    // ********************************** InitializeGraphicsBuffer

    //    public bool InitializeGraphicsBuffer(string name,
    //                                           int width,
    //                                           int height)
    //    {

    //        return (CreateGraphicsBuffer(name,
    //                                        width,
    //                                        height));
    //    }

    //    // *********************************************** ClearBitmap

    //    public void ClearBitmap(Color background_color)
    //    {

    //        Graphic.Clear(background_color);
    //    }

    //    // ************************************** DeleteGraphicsBuffer

    //    /// <summary>
    //    /// deletes the current GraphicsBuffer
    //    /// </summary>
    //    /// <returns>
    //    /// null, always
    //    /// </returns>
    //    public RoundedGraphicsBuffer DeleteGraphicsBuffer()
    //    {

    //        if (graphic != null)
    //        {
    //            graphic.Dispose();
    //            graphic = null;
    //        }

    //        if (bitmap != null)
    //        {
    //            bitmap.Dispose();
    //            bitmap = null;
    //        }

    //        Width = 0;
    //        Height = 0;
    //        Name = String.Empty;

    //        return (null);
    //    }

    //    // *************************************************** Graphic

    //    /// <summary>
    //    /// returns the current Graphic Graphics object
    //    /// </summary>
    //    public Graphics Graphic
    //    {

    //        get
    //        {
    //            return (graphic);
    //        }
    //    }

    //    // ************************************** GraphicsBufferExists

    //    /// <summary>
    //    /// returns true if the grapgics object exists; false, 
    //    /// otherwise
    //    /// </summary>
    //    public bool GraphicsBufferExists
    //    {

    //        get
    //        {
    //            return (graphic != null);
    //        }
    //    }

    //    // ******************************************* ColorAtLocation

    //    /// <summary>
    //    /// given a point in the graphic bitmap, returns the GDI 
    //    /// Color at that point
    //    /// </summary>
    //    /// <param name="location">
    //    /// location in the bitmap from which the color is to be 
    //    /// returned
    //    /// </param>
    //    /// <returns>
    //    /// if the location is within the bitmap, the color at the 
    //    /// location; otherwise, Black
    //    /// </returns>
    //    public Color ColorAtLocation(Point location)
    //    {
    //        Color color = Color.Black;

    //        if (((location.X > 0) &&
    //               (location.X <= Width)) &&
    //             ((location.Y > 0) &&
    //               (location.Y <= Height)))
    //        {
    //            color = this.bitmap.GetPixel(location.X,
    //                                           location.Y);
    //        }

    //        return (color);
    //    }

    //    // ************************************** RenderGraphicsBuffer

    //    /// <summary>
    //    /// Renders the buffer to the graphic object identified by 
    //    /// graphic
    //    /// </summary>
    //    /// <param name="graphic">
    //    /// target graphic object (e.g., PaintEventArgs e.Graphics)
    //    /// </param>
    //    public void RenderGraphicsBuffer(Graphics graphics)
    //    {

    //        if (bitmap != null)
    //        {
    //            graphics.DrawImage(
    //                        bitmap,
    //                        new Rectangle(0, 0, Width, Height),
    //                        new Rectangle(0, 0, Width, Height),
    //                        GraphicsUnit.Pixel);
    //        }
    //    }

    //    // ********************************************* ClearGraphics

    //    /// <summary>
    //    /// clears the graphic object identified by graphic
    //    /// </summary>
    //    /// <param name="graphic">
    //    /// Window forms graphic object
    //    /// </param>
    //    /// <param name="background_color">
    //    /// background color to be used to clear graphic
    //    /// </param>
    //    public void ClearGraphics(Color background_color)
    //    {

    //        Graphic.Clear(background_color);
    //    }

    //}
    //#endregion

    //#region Rounded Button
    //// ******************************************* class RoundedButton

    //public class RoundedButton : Button
    //{

    //    // ******************************************* class variables

    //    Color border_color = Color.White;
    //    RoundedGraphicsBuffer border_graphic = null;
    //    int border_thickness = 1;
    //    int diameter = 0;
    //    bool draw_rounding_circle = false;
    //    bool must_create_border_graphic = true;

    //    // ************************************* create_border_graphic

    //    /// <summary>
    //    /// creates the graphic image of the border that will be 
    //    /// rendered on the button's surface
    //    /// </summary>
    //    void create_border_graphic()
    //    {
    //        // delete existing buffer
    //        if (border_graphic != null)
    //        {
    //            border_graphic = border_graphic.
    //                             DeleteGraphicsBuffer();
    //        }
    //        // create a new buffer
    //        border_graphic = new RoundedGraphicsBuffer();
    //        border_graphic.InitializeGraphicsBuffer("Border",
    //                                                  this.Width,
    //                                                  this.Height);
    //        border_graphic.Graphic.SmoothingMode =
    //            SmoothingMode.HighQuality;
    //    }

    //    // ***************************************************** round

    //    // http://en.wikipedia.org/wiki/Rounding

    //    int round(float parameter)
    //    {

    //        return ((int)(parameter + 0.5F));
    //    }

    //    // ************************************ rounded_rectangle_path

    //    /// <summary>
    //    /// computes the GraphicsPath of a rounded rectangle
    //    /// </summary>
    //    /// <param name="x">
    //    /// x coordinate of the upper left corner of the rectangle
    //    /// </param>
    //    /// <param name="y">
    //    /// y coordinate of the upper left corner of the rectangle
    //    /// </param>
    //    /// <param name="width">
    //    /// width of the rectangle
    //    /// </param>
    //    /// <param name="height">
    //    /// height of the rectangle
    //    /// </param>
    //    /// <param name="radius">
    //    /// radius of the circle that defines the rounded corner
    //    /// </param>
    //    /// <returns>
    //    /// the GraphicsPath that defines the rounded rectangle
    //    /// </returns>
    //    /// <note>
    //    /// the arcs are drawn in a clockwise order starting at the 
    //    /// bottom right; when all arcs have been drawn, 
    //    /// CloseAllFigures is invoked to drawn the connecting lines
    //    /// </note>
    //    GraphicsPath rounded_rectangle_path(int x,
    //                                          int y,
    //                                          int width,
    //                                          int height)
    //    {
    //        int local_diameter = 0;
    //        GraphicsPath path = new GraphicsPath();
    //        // take into account right and 
    //        // bottom sides
    //        x += 1;
    //        y += 1;
    //        width -= 1;
    //        height -= 1;

    //        if (Diameter == 0)
    //        {
    //            local_diameter = Math.Min(width, height);
    //            local_diameter =
    //                round((float)local_diameter / 2.0F);
    //        }
    //        else
    //        {
    //            local_diameter = Diameter;
    //        }

    //        path.StartFigure();
    //        // bottom right
    //        path.AddArc((x + width - local_diameter),
    //                      (y + height - local_diameter),
    //                      local_diameter,
    //                      local_diameter,
    //                      0.0F,
    //                      90.0F);
    //        // bottom left
    //        path.AddArc(x,
    //                      (y + height - local_diameter),
    //                      local_diameter,
    //                      local_diameter,
    //                      90.0F,
    //                      90.0F);
    //        // top left
    //        path.AddArc(x,
    //                      y,
    //                      local_diameter,
    //                      local_diameter,
    //                      180.0F,
    //                      90.0F);
    //        // top right
    //        path.AddArc((x + width - local_diameter),
    //                      y,
    //                      local_diameter,
    //                      local_diameter,
    //                      270.0F,
    //                      90.0F);
    //        // join all arcs together
    //        path.CloseAllFigures();

    //        return (path);
    //    }

    //    // ************************************* draw_rounding_circles

    //    void draw_rounding_circles(Graphics graphic,
    //                                 int x,
    //                                 int y,
    //                                 int width,
    //                                 int height)
    //    {
    //        int local_diameter = 0;
    //        Pen pen = new Pen(this.ForeColor);
    //        // take into account right and 
    //        // bottom sides
    //        x += 1;
    //        y += 1;
    //        width -= 1;
    //        height -= 1;

    //        if (Diameter == 0)
    //        {
    //            local_diameter = Math.Min(width, height);
    //            local_diameter =
    //                round((float)local_diameter / 2.0F);
    //        }
    //        else
    //        {
    //            local_diameter = Diameter;
    //        }

    //        // top left
    //        graphic.DrawEllipse(pen,
    //                              x,
    //                              y,
    //                              local_diameter,
    //                              local_diameter);
    //        // top right
    //        graphic.DrawEllipse(pen,
    //                              (x + width - local_diameter),
    //                              y,
    //                              local_diameter,
    //                              local_diameter);
    //        // bottom right
    //        graphic.DrawEllipse(pen,
    //                              (x + width - local_diameter),
    //                              (y + height - local_diameter),
    //                              local_diameter,
    //                              local_diameter);
    //        // bottom left
    //        graphic.DrawEllipse(pen,
    //                              x,
    //                              (y + height - local_diameter),
    //                              local_diameter,
    //                              local_diameter);

    //        pen.Dispose();
    //    }

    //    // *************************************** draw_border_graphic

    //    /// <summary>
    //    /// creates the border_graphic GraphicBuffer by performing the 
    //    /// following actions:
    //    /// 
    //    ///     1.  create a GraphicsPath
    //    ///     2.  establish the clipping region that limits graphics 
    //    ///         operations to within the GraphicsPath
    //    ///     3.  draws the outline of the GraphicsPath to the 
    //    ///         border_graphic GraphicsBuffer
    //    ///     4.  deletes the GraphicsPath
    //    ///     5.  optionally draws the outines of the circles that 
    //    ///         were used to create the rounded corners to the 
    //    ///         border_graphic GraphicsBuffer 
    //    /// </summary>
    //    void draw_border_graphic()
    //    {
    //        GraphicsPath path = null;
    //        // ORDER IS IMPORTANT!!!

    //        // compute the path
    //        path = rounded_rectangle_path(0,
    //                                        0,
    //                                        this.Width,
    //                                        this.Height);
    //        // set clipping region
    //        this.Region = new Region(path);
    //        // draw the border
    //        border_graphic.Graphic.DrawPath(
    //            new Pen(BorderColor,
    //                      BorderThickness),
    //            path);
    //        path.Dispose();
    //        // draw circles
    //        if (DrawRoundingCircles)
    //        {
    //            draw_rounding_circles(border_graphic.Graphic,
    //                                    0,
    //                                    0,
    //                                    this.Width,
    //                                    this.Height);
    //        }
    //    }

    //    // ********************************************* RoundedButton

    //    public RoundedButton() : base()
    //    {

    //        this.SetStyle((ControlStyles.DoubleBuffer |
    //                          ControlStyles.UserPaint |
    //                          ControlStyles.AllPaintingInWmPaint),
    //                        true);
    //        this.UpdateStyles();
    //        // prevent button from drawing 
    //        // its own border
    //        FlatAppearance.BorderSize = 0;
    //        FlatStyle = FlatStyle.Flat;
    //    }

    //    // *********************************************** BorderColor

    //    [Category("Appearance"),
    //      Description("Sets/Gets color of the button border"),
    //      DefaultValue(typeof(Color), "White"),
    //      Bindable(true)]
    //    public Color BorderColor
    //    {

    //        get
    //        {
    //            return (border_color);
    //        }

    //        set
    //        {
    //            if (border_color != value)
    //            {
    //                border_color = value;
    //                must_create_border_graphic = true;
    //                this.Refresh();
    //            }
    //        }
    //    }

    //    // ******************************************* BorderThickness

    //    [Category("Appearance"),
    //      Description("Sets/Gets thickness of button border"),
    //      DefaultValue(typeof(int), "1"),
    //      Bindable(true)]
    //    public int BorderThickness
    //    {

    //        get
    //        {
    //            return (border_thickness);
    //        }

    //        set
    //        {
    //            if (border_thickness != value)
    //            {
    //                border_thickness = value;
    //                must_create_border_graphic = true;
    //                this.Refresh();
    //            }
    //        }
    //    }

    //    // ************************************************** Diameter

    //    [Category("Appearance"),
    //      Description("Sets/Gets diameter for rounding corners"),
    //      DefaultValue(typeof(int), "0"),
    //      Bindable(true)]
    //    public int Diameter
    //    {

    //        get
    //        {
    //            return (diameter);
    //        }

    //        set
    //        {
    //            if (diameter != value)
    //            {
    //                diameter = value;
    //                must_create_border_graphic = true;
    //                this.Refresh();
    //            }
    //        }
    //    }

    //    // *************************************** DrawRoundingCircles

    //    [Category("Appearance"),
    //      Description("Are rounding circles to be drawn?"),
    //      DefaultValue(typeof(bool), "false"),
    //      Bindable(true)]
    //    public bool DrawRoundingCircles
    //    {

    //        get
    //        {
    //            return (draw_rounding_circle);
    //        }

    //        set
    //        {
    //            if (draw_rounding_circle != value)
    //            {
    //                draw_rounding_circle = value;
    //                must_create_border_graphic = true;
    //                this.Refresh();
    //            }
    //        }
    //    }

    //    // ****************************************** OnControlRemoved

    //    protected override void OnControlRemoved(
    //                                            ControlEventArgs e)
    //    {

    //        base.OnControlRemoved(e);

    //        if (border_graphic != null)
    //        {
    //            border_graphic.DeleteGraphicsBuffer();
    //        }
    //    }

    //    // *************************************************** OnPaint

    //    /// <summary>
    //    /// the Paint event handler
    //    /// </summary>
    //    /// <note>
    //    /// the button is drawn in the usual manner by the base 
    //    /// method; then a border is added; note too that appropriate 
    //    /// changes to FlatAppearance and FlatStyle have been made to 
    //    /// keep the base class from drawing the button borders
    //    /// </note>
    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        // have base class paint the 
    //        // button normally
    //        base.OnPaint(e);

    //        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

    //        if (must_create_border_graphic)
    //        {
    //            create_border_graphic();
    //            draw_border_graphic();
    //            must_create_border_graphic = false;
    //        }
    //        // draw the border
    //        border_graphic.RenderGraphicsBuffer(e.Graphics);
    //    }

    //    // ************************************************** OnResize

    //    /// <summary>
    //    /// the Resize event handler.
    //    /// </summary>
    //    /// <note>
    //    /// recall that the Resize handler of the base class will 
    //    /// raise the Paint event, so all that is required is to force 
    //    /// the border graphic to be recreated
    //    /// </note>
    //    protected override void OnResize(EventArgs e)
    //    {

    //        base.OnResize(e);

    //        must_create_border_graphic = true;
    //    }

    //} // class RoundedButton
    //#endregion
    #endregion


}
