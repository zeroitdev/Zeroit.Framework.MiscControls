// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AnalogueClock.cs" company="Zeroit Dev Technologies">
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
    #region Analogue Clock

    /// <summary>
    /// Defines the ticking style used for the second and minute hands of the <c><see cref="ZeroitClockAnalogSaz" /></c> clock.
    /// </summary>
    public enum TickStyle
    {
        /// <summary>
        /// Smooth ticking style. For example if used with second hand it will be updated every millisecond.
        /// </summary>
        Smooth,
        /// <summary>
        /// Normal ticking style. For example if used with second hand it will be updated every second only.
        /// </summary>
        Normal
    }


    /// <summary>
    /// A class collection for rendering the Analog clock control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />

    [Designer(typeof(ZeroitClockAnalogDesigner))]
    public class ZeroitClockAnalog : UserControl
    {


        #region Variables

        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// The clock timer
        /// </summary>
        System.Windows.Forms.Timer clockTimer = new System.Windows.Forms.Timer();

        /// <summary>
        /// The drawnumerals
        /// </summary>
        private bool drawnumerals = true;
        /// <summary>
        /// The draw rim
        /// </summary>
        private bool drawRim = true;
        /// <summary>
        /// The draw drop shadow
        /// </summary>
        private bool drawDropShadow = true;
        /// <summary>
        /// The draw second hand shadow
        /// </summary>
        private bool drawSecondHandShadow = true;
        /// <summary>
        /// The draw minute hand shadow
        /// </summary>
        private bool drawMinuteHandShadow = true;
        /// <summary>
        /// The draw hour hand shadow
        /// </summary>
        private bool drawHourHandShadow = true;
        /// <summary>
        /// The draw second hand
        /// </summary>
        private bool drawSecondHand = true;
        /// <summary>
        /// The draw minute hand
        /// </summary>
        private bool drawMinuteHand = true;
        /// <summary>
        /// The draw hour hand
        /// </summary>
        private bool drawHourHand = true;

        /// <summary>
        /// The drop shadow color
        /// </summary>
        private Color dropShadowColor = Color.Black;

        /// <summary>
        /// The second hand drop shadow color
        /// </summary>
        private Color secondHandDropShadowColor = Color.Gray;
        /// <summary>
        /// The hour hand drop shadow color
        /// </summary>
        private Color hourHandDropShadowColor = Color.Gray;
        /// <summary>
        /// The minute hand drop shadow color
        /// </summary>
        private Color minuteHandDropShadowColor = Color.Gray;

        /// <summary>
        /// The face color1
        /// </summary>
        private Color faceColor1 = Color.RoyalBlue;
        /// <summary>
        /// The face color2
        /// </summary>
        private Color faceColor2 = Color.SkyBlue;
        /// <summary>
        /// The rim color1
        /// </summary>
        private Color rimColor1 = Color.RoyalBlue;
        /// <summary>
        /// The rim color2
        /// </summary>
        private Color rimColor2 = Color.SkyBlue;
        /// <summary>
        /// The numeral color
        /// </summary>
        private Color numeralColor = Color.WhiteSmoke;
        /// <summary>
        /// The second hand color
        /// </summary>
        private Color secondHandColor = Color.Tomato;

        /// <summary>
        /// The gb
        /// </summary>
        private LinearGradientBrush gb;
        /// <summary>
        /// The smoothing mode
        /// </summary>
        private SmoothingMode smoothingMode = SmoothingMode.AntiAlias;
        /// <summary>
        /// The text rendering hint
        /// </summary>
        private TextRenderingHint textRenderingHint = TextRenderingHint.AntiAlias;
        /// <summary>
        /// The sec line end cap
        /// </summary>
        private LineCap secLineEndCap = LineCap.Round;
        //private Point dropShadowOffset = new Point(5,5);
        /// <summary>
        /// The face gradient mode
        /// </summary>
        private LinearGradientMode faceGradientMode = LinearGradientMode.ForwardDiagonal;
        /// <summary>
        /// The rim gradient mode
        /// </summary>
        private LinearGradientMode rimGradientMode = LinearGradientMode.BackwardDiagonal;
        /// <summary>
        /// The time
        /// </summary>
        private DateTime time;

        /// <summary>
        /// The hour hand color
        /// </summary>
        private Color hourHandColor = Color.Gainsboro;
        /// <summary>
        /// The minimum hand color
        /// </summary>
        private Color minHandColor = Color.WhiteSmoke;

        /// <summary>
        /// The radius
        /// </summary>
        private float radius;
        /// <summary>
        /// The midx
        /// </summary>
        private float midx;
        /// <summary>
        /// The midy
        /// </summary>
        private float midy;
        /// <summary>
        /// The y
        /// </summary>
        private float y;
        /// <summary>
        /// The x
        /// </summary>
        private float x;
        /// <summary>
        /// The fontsize
        /// </summary>
        private float fontsize;
        /// <summary>
        /// The text font
        /// </summary>
        private Font textFont = new Font("Verdana", 10, FontStyle.Bold);
        /// <summary>
        /// The minimum
        /// </summary>
        private int min;
        /// <summary>
        /// The hour
        /// </summary>
        private int hour;
        /// <summary>
        /// The sec
        /// </summary>
        private double sec;
        /// <summary>
        /// The img
        /// </summary>
        private Image img;

        /// <summary>
        /// The minute angle
        /// </summary>
        float minuteAngle;
        /// <summary>
        /// The second angle
        /// </summary>
        double secondAngle;
        /// <summary>
        /// The hour angle
        /// </summary>
        double hourAngle;

        /// <summary>
        /// The second hand tick style
        /// </summary>
        private TickStyle secondHandTickStyle = TickStyle.Normal;
        /// <summary>
        /// The minimum hand tick style
        /// </summary>
        private TickStyle minHandTickStyle = TickStyle.Normal;

        /// <summary>
        /// The drop shadow offset
        /// </summary>
        private Point dropShadowOffset;

        #endregion

        /// <summary>
        /// Creates a new instace of the Analog Clock control.
        /// </summary>
        public ZeroitClockAnalog()
        {

            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            clockTimer.Start();
            clockTimer.Tick += clockTimer_Tick;

        }

        /// <summary>
        /// Handles the Tick event of the clockTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void clockTimer_Tick(object sender, EventArgs e)
        {
            this.Time = DateTime.UtcNow;
        }

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // AnalogClock
            // 
            //this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.Name = "AnalogClock";
            this.Size = new System.Drawing.Size(232, 232);
            this.Resize += new System.EventHandler(this.AnalogClock_Resize);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnalogClock_Paint);

        }
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the font for the text.
        /// </summary>
        /// <value>The font for the text.</value>
        public Font TextFont
        {
            get { return textFont; }
            set
            {
                textFont = value;
                Invalidate();
            }
        }
        /// <summary>
        /// The Background image used in the clock face.
        /// </summary>
        /// <value>The face image.</value>
        /// <remarks>Using a large image will result in poor performance and increased memory consumption.</remarks>
        [
        Category("Clock"),
        Description("The Background image used in the clock face."),
        ]
        public Image FaceImage
        {
            get { return img; }
            set { this.img = value; Invalidate(); }
        }


        /// <summary>
        /// Defines the second hand tick style.
        /// </summary>
        /// <value>The second hand tick style.</value>
        [
        Category("Clock"),
        Description("Defines the second hand tick style."),

        ]
        public TickStyle SecondHandTickStyle
        {
            get { return secondHandTickStyle; }
            set { this.secondHandTickStyle = value; }
        }

        /// <summary>
        /// Defines the minute hand tick style.
        /// </summary>
        /// <value>The minute hand tick style.</value>
        [
        Category("Clock"),
        Description("Defines the minute hand tick style."),

        ]
        public TickStyle MinuteHandTickStyle
        {
            get { return minHandTickStyle; }
            set { minHandTickStyle = value; }
        }

        /// <summary>
        /// Determines whether the Numerals are drawn on the clock face.
        /// </summary>
        /// <value><c>true</c> if [draw numerals]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the Numerals are drawn on the clock face."),
        DefaultValue(true),
        ]
        public bool DrawNumerals
        {
            get { return drawnumerals; }
            set { drawnumerals = value; Invalidate(); }

        }

        /// <summary>
        /// Sets or gets the rendering quality of the clock.
        /// </summary>
        /// <value>The smoothing mode.</value>
        /// <remarks>This property does not effect the numeral text rendering quality. To set the numeral text rendering quality use the <see cref="TextRenderingHint" /> Property</remarks>
        [
        Category("Clock"),
        Description("Sets or gets the rendering quality of the clock."),
        DefaultValue(SmoothingMode.AntiAlias),
        ]
        public SmoothingMode SmoothingMode
        {
            get { return smoothingMode; }
            set { this.smoothingMode = value; Invalidate(); }
        }

        /// <summary>
        /// Sets or gets the text rendering mode used for the clock numerals.
        /// </summary>
        /// <value>The text rendering hint.</value>
        [
        Category("Clock"),
        Description("Sets or gets the text rendering mode used for the clock numerals."),
        DefaultValue(TextRenderingHint.AntiAlias),
        ]
        public TextRenderingHint TextRenderingHint
        {
            get { return this.textRenderingHint; }
            set { this.textRenderingHint = value; Invalidate(); }

        }

        /// <summary>
        /// Determines whether the clock Rim is drawn or not.
        /// </summary>
        /// <value><c>true</c> if [draw rim]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the clock Rim is drawn or not."),
        DefaultValue(true),
        ]
        public bool DrawRim
        {
            get { return this.drawRim; }
            set { this.drawRim = value; Invalidate(); }
        }

        /// <summary>
        /// Determines whether drop shadow for the clock is drawn or not.
        /// </summary>
        /// <value><c>true</c> if [draw drop shadow]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether drop shadow for the clock is drawn or not."),
        DefaultValue(true),
        ]
        public bool DrawDropShadow
        {
            get { return this.drawDropShadow; }
            set { drawDropShadow = value; Invalidate(); }
        }

        /// <summary>
        /// Sets or gets the color of the Drop Shadow.
        /// </summary>
        /// <value>The color of the drop shadow.</value>
        [
        Category("Clock"),
        Description("Sets or gets the color of the Drop Shadow."),

        ]
        public Color DropShadowColor
        {
            get { return this.dropShadowColor; }
            set { this.dropShadowColor = value; Invalidate(); }
        }


        /// <summary>
        /// Sets or gets the color of the second hand drop Shadow.
        /// </summary>
        /// <value>The color of the second hand drop shadow.</value>
        [
        Category("Clock"),
        Description("Sets or gets the color of the second hand drop Shadow."),

        ]
        public Color SecondHandDropShadowColor
        {
            get { return this.secondHandDropShadowColor; }
            set { this.secondHandDropShadowColor = value; Invalidate(); }
        }


        /// <summary>
        /// Sets or gets the color of the Minute hand drop Shadow.
        /// </summary>
        /// <value>The color of the minute hand drop shadow.</value>
        [
        Category("Clock"),
        Description("Sets or gets the color of the Minute hand drop Shadow."),

        ]
        public Color MinuteHandDropShadowColor
        {
            get { return this.minuteHandDropShadowColor; }
            set { this.minuteHandDropShadowColor = value; Invalidate(); }
        }

        /// <summary>
        /// Sets or gets the color of the hour hand drop Shadow.
        /// </summary>
        /// <value>The color of the hour hand drop shadow.</value>
        [
        Category("Clock"),
        Description("Sets or gets the color of the hour hand drop Shadow."),

        ]
        public Color HourHandDropShadowColor
        {
            get { return this.hourHandDropShadowColor; }
            set { this.hourHandDropShadowColor = value; Invalidate(); }
        }

        /// <summary>
        /// Determines the first color of the clock face gradient.
        /// </summary>
        /// <value>The face color high.</value>
        [
        Category("Clock"),
        Description("Determines the first color of the clock face gradient."),

        ]
        public Color FaceColorHigh
        {
            get { return this.faceColor1; }
            set { this.faceColor1 = value; Invalidate(); }
        }

        /// <summary>
        /// Determines the second color of the clock face gradient.
        /// </summary>
        /// <value>The face color low.</value>
        [
        Category("Clock"),
        Description("Determines the second color of the clock face gradient."),
        DefaultValue(typeof(Color), "Black")
        ]
        public Color FaceColorLow
        {
            get { return this.faceColor2; }
            set { this.faceColor2 = value; Invalidate(); }
        }


        /// <summary>
        /// Determines whether the second hand casts a drop shadow for added realism.
        /// </summary>
        /// <value><c>true</c> if [draw second hand shadow]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the second hand casts a drop shadow for added realism."),
        DefaultValue(true)
        ]
        public bool DrawSecondHandShadow
        {
            get { return this.drawSecondHandShadow; }
            set { this.drawSecondHandShadow = value; Invalidate(); }
        }


        /// <summary>
        /// Determines whether the hour hand casts a drop shadow for added realism.
        /// </summary>
        /// <value><c>true</c> if [draw hour hand shadow]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the hour hand casts a drop shadow for added realism."),
        ]
        public bool DrawHourHandShadow
        {
            get { return this.drawHourHandShadow; }
            set { this.drawHourHandShadow = value; Invalidate(); }
        }

        /// <summary>
        /// Determines whether the minute hand casts a drop shadow for added realism.
        /// </summary>
        /// <value><c>true</c> if [draw minute hand shadow]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the minute hand casts a drop shadow for added realism."),
        ]
        public bool DrawMinuteHandShadow
        {
            get { return this.drawMinuteHandShadow; }
            set { this.drawMinuteHandShadow = value; Invalidate(); }
        }

        /// <summary>
        /// Determines the first color of the rim gradient.
        /// </summary>
        /// <value>The rim color high.</value>
        [
        Category("Clock"),
        Description("Determines the first color of the rim gradient."),
        ]
        public Color RimColorHigh
        {
            get { return this.rimColor1; }
            set { this.rimColor1 = value; Invalidate(); }
        }

        /// <summary>
        /// Determines the second color of the rim face gradient.
        /// </summary>
        /// <value>The rim color low.</value>
        [
        Category("Clock"),
        Description("Determines the second color of the rim face gradient."),
        ]
        public Color RimColorLow
        {
            get { return this.rimColor2; }
            set { this.rimColor2 = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the direction of the Rim gradient.
        /// </summary>
        /// <value>The rim gradient mode.</value>
        //TODO:replace this by degree
        [
        Category("Clock"),
        Description("Gets or sets the direction of the Rim gradient."),
        ]
        public LinearGradientMode RimGradientMode
        {
            get { return this.faceGradientMode; }
            set { this.faceGradientMode = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the direction of the Clock Face gradient.
        /// </summary>
        /// <value>The face gradient mode.</value>
        //TODO:replace this by degree
        [
        Category("Clock"),
        Description("Gets or sets the direction of the Clock Face gradient."),
        ]
        public LinearGradientMode FaceGradientMode
        {
            get { return this.rimGradientMode; }
            set { this.rimGradientMode = value; Invalidate(); }
        }

        /// <summary>
        /// Determines the Seconds hand end line shape.
        /// </summary>
        /// <value>The second hand end cap.</value>
        [
        Category("Clock"),
        Description("Determines the shape of second hand."),
        ]
        public LineCap SecondHandEndCap
        {
            get { return this.secLineEndCap; }
            set { this.secLineEndCap = value; Invalidate(); }
        }

        /// <summary>
        /// The System.DateTime structure which is used to display time.
        /// </summary>
        /// <value>The time.</value>
        /// <example>
        ///   <code>
        /// AnalogClock clock = new AnalogClock();
        /// clock.Time = DateTime.Now;
        /// </code>
        /// </example>
        /// <remarks>The clock face is updated every time the value of this property is changed.</remarks>
        [
        Category("Clock"),
        Description("The DateTime structure which the clock uses to display time."),
        Browsable(false)
        ]
        public DateTime Time
        {
            get { return this.time; }
            set { this.time = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the Seconds Hand.
        /// </summary>
        /// <value>The color of the second hand.</value>
        [
        Category("Clock"),
        Description("Gets or sets the color of the Seconds Hand."),
        ]
        public Color SecondHandColor
        {
            get { return this.secondHandColor; }
            set { this.secondHandColor = value; Invalidate(); }
        }

        /// <summary>
        /// Sets or gets the color of the clock Numerals.
        /// </summary>
        /// <value>The color of the numeral.</value>
        /// <remarks>To change the numeral font use the <see cref=" Font " /> Property</remarks>
        [
        Category("Clock"),
        Description("Sets or gets the color of the clock Numerals."),
        ]
        public Color NumeralColor
        {
            get { return this.numeralColor; }
            set { this.numeralColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the Hour Hand.
        /// </summary>
        /// <value>The color of the hour hand.</value>
        [
        Category("Clock"),
        Description("Gets or sets the color of the Hour Hand."),
        ]
        public Color HourHandColor
        {
            get { return this.hourHandColor; }
            set { this.hourHandColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the Minute Hand.
        /// </summary>
        /// <value>The color of the minute hand.</value>
        [
        Category("Clock"),
        Description("Gets or sets the color of the Minute Hand."),
        ]
        public Color MinuteHandColor
        {
            get { return this.minHandColor; }
            set { this.minHandColor = value; Invalidate(); }
        }


        /// <summary>
        /// Determines whether the second Hand is shown.
        /// </summary>
        /// <value><c>true</c> if [draw second hand]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the second Hand is shown."),
        ]
        public bool DrawSecondHand
        {
            get { return drawSecondHand; }
            set { this.drawSecondHand = value; Invalidate(); }
        }


        /// <summary>
        /// Determines whether the minute hand is shown.
        /// </summary>
        /// <value><c>true</c> if [draw minute hand]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the minute hand is shown."),
        ]
        public bool DrawMinuteHand
        {
            get { return drawMinuteHand; }
            set { this.drawMinuteHand = value; Invalidate(); }
        }

        /// <summary>
        /// Determines whether the hour Hand is shown.
        /// </summary>
        /// <value><c>true</c> if [draw hour hand]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the hour Hand is shown."),
        ]
        public bool DrawHourHand
        {
            get { return drawHourHand; }
            set { this.drawHourHand = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the drop shadow offset.
        /// </summary>
        /// <value>The drop shadow offset.</value>
        [
        Category("Clock"),
        Description("Gets or sets the drop shadow offset."),
        ]
        public Point DropShadowOffset
        {
            get { return dropShadowOffset; }
            set { this.dropShadowOffset = value; Invalidate(); }
        }





        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Handles the Paint event of the AnalogClock control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void AnalogClock_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            DrawClock(e.Graphics);
        }


        /// <summary>
        /// Gets the x.
        /// </summary>
        /// <param name="deg">The deg.</param>
        /// <returns>System.Single.</returns>
        private float GetX(float deg)
        { return (float)(radius * Math.Cos((Math.PI / 180) * deg)); }

        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <param name="deg">The deg.</param>
        /// <returns>System.Single.</returns>
        private float GetY(float deg)
        { return (float)(radius * Math.Sin((Math.PI / 180) * deg)); }


        /// <summary>
        /// Handles the Resize event of the AnalogClock control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void AnalogClock_Resize(object sender, System.EventArgs e)
        {
            this.Width = this.Height;
            this.Width = this.Width;
            this.Invalidate();
        }

        /// <summary>
        /// Draws analog clock on the given GDI+ Drawing surface.
        /// </summary>
        /// <param name="e">The GDI+ Drawing surface.</param>
        private void DrawClock(Graphics e)
        {
            Graphics grfx = e;
            grfx.SmoothingMode = smoothingMode;
            grfx.TextRenderingHint = textRenderingHint;
            grfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            midx = this.ClientSize.Width / 2;
            midy = this.ClientSize.Height / 2;


            x = this.ClientSize.Width;
            y = this.ClientSize.Height;

            SolidBrush stringBrush = new SolidBrush(this.numeralColor);
            Pen pen = new Pen(stringBrush, 2);


            //Define rectangles inside which we will draw circles.

            Rectangle rect = new Rectangle(0 + 10, 0 + 10, (int)x - 20, (int)y - 20);
            Rectangle rectrim = new Rectangle(0 + 20, 0 + 20, (int)x - 40, (int)y - 40);

            Rectangle rectinner = new Rectangle(0 + 40, 0 + 40, (int)x - 80, (int)y - 80);
            Rectangle rectdropshadow = new Rectangle(0 + 10, 0 + 10, (int)x - 17, (int)y - 17);


            radius = rectinner.Width / 2;

            fontsize = radius / 5;
            textFont = this.Font;


            //Drop Shadow
            gb = new LinearGradientBrush(rect, Color.Transparent, dropShadowColor, LinearGradientMode.BackwardDiagonal);
            rectdropshadow.Offset(dropShadowOffset);
            if (this.drawDropShadow)
                grfx.FillEllipse(gb, rectdropshadow);


            //Face
            gb = new LinearGradientBrush(rect, rimColor1, rimColor2, faceGradientMode);
            if (this.drawRim)
                grfx.FillEllipse(gb, rect);




            //Rim
            gb = new LinearGradientBrush(rect, faceColor1, faceColor2, rimGradientMode);
            grfx.FillEllipse(gb, rectrim);










            //Define a circular clip region and draw the image inside it.
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(rectrim);
            grfx.SetClip(path);

            if (this.img != null)
            {
                grfx.DrawImage(this.img, rect);
            }
            path.Dispose();

            //Reset clip region
            grfx.ResetClip();

            //			Triangular region
            //			pen.Width =2;
            //			grfx.DrawRectangle(pen, rect);
            //			grfx.DrawRectangle(pen, rectinner);
            //			grfx.DrawRectangle(pen, rectrim);
            //			grfx.DrawRectangle(pen, rectdropshadow);
            //			
            //			grfx.DrawRectangle(pen, rect);
            //			grfx.DrawEllipse(pen, rect);
            //			grfx.DrawEllipse(pen, rectinner);
            //			grfx.DrawEllipse(pen, rectrim);
            //			grfx.DrawEllipse(pen, rectdropshadow);
            //			


            //Center Point
            //grfx.DrawEllipse(pen, midx, midy ,2 ,2);

            //Define the midpoint of the control as the centre
            grfx.TranslateTransform(midx, midy);



            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;


            //Draw Numerals on the Face 
            int deg = 360 / 12;
            if (drawnumerals)
            {
                for (int i = 1; i <= 12; i++)
                {

                    grfx.DrawString(i.ToString(), textFont, stringBrush, -1 * GetX(i * deg + 90), -1 * GetY(i * deg + 90), format);
                }

            }
            format.Dispose();



            hour = time.Hour;
            min = time.Minute;
            Point centre = new Point(0, 0);

            //Draw Minute hand
            if (drawMinuteHand)
            {

                if (minHandTickStyle == TickStyle.Smooth)
                    minuteAngle = (float)(2.0 * Math.PI * (min + sec / 60.0) / 60.0);
                else
                    minuteAngle = (float)(2.0 * Math.PI * (min / 60.0));

                pen.EndCap = LineCap.Round;
                pen.StartCap = LineCap.RoundAnchor;
                pen.Width = (int)radius / 14;

                centre.Offset(2, 2);
                pen.Color = Color.Gray;
                Point minHandShadow = new Point((int)(radius * Math.Sin(minuteAngle)), (int)(-(radius) * Math.Cos(minuteAngle) + 2));


                if (this.drawMinuteHandShadow)
                {
                    pen.Color = minuteHandDropShadowColor;
                    grfx.DrawLine(pen, centre, minHandShadow);
                }

                centre.X = centre.Y = 0;
                pen.Color = minHandColor;
                Point minHand = new Point((int)(radius * Math.Sin(minuteAngle)), (int)(-(radius) * Math.Cos(minuteAngle)));
                grfx.DrawLine(pen, centre, minHand);
            }

            //--End Minute Hand


            // Draw Hour Hand
            if (drawHourHand)
            {
                hourAngle = 2.0 * Math.PI * (hour + min / 60.0) / 12.0;


                pen.EndCap = LineCap.Round;
                pen.StartCap = LineCap.RoundAnchor;
                pen.Width = (int)radius / 14;

                centre.X = centre.Y = 1;
                pen.Color = Color.Gray;
                Point hourHandShadow = new Point((int)((radius * Math.Sin(hourAngle) / 1.5) + 2), (int)((-(radius) * Math.Cos(hourAngle) / 1.5) + 2));

                if (this.drawHourHandShadow)
                {
                    pen.Color = hourHandDropShadowColor;
                    grfx.DrawLine(pen, centre, hourHandShadow);
                }

                centre.X = centre.Y = 0;
                pen.Color = hourHandColor;
                Point hourHand = new Point((int)(radius * Math.Sin(hourAngle) / 1.5), (int)(-(radius) * Math.Cos(hourAngle) / 1.5));
                grfx.DrawLine(pen, centre, hourHand);
            }
            //---End Hour Hand


            if (secondHandTickStyle == TickStyle.Smooth)
                sec = time.Second + (time.Millisecond * 0.001);
            else
                sec = time.Second;


            //Draw Sec Hand
            if (drawSecondHand)
            {
                int width = (int)radius / 25;
                pen.Width = width;
                pen.EndCap = secLineEndCap;
                pen.StartCap = LineCap.RoundAnchor;
                secondAngle = 2.0 * Math.PI * sec / 60.0;




                //Draw Second Hand Drop Shadow
                pen.Color = Color.DimGray;
                centre.X = 1;
                centre.Y = 1;

                Point secHand = new Point((int)(radius * Math.Sin(secondAngle)), (int)(-(radius) * Math.Cos(secondAngle)));
                Point secHandshadow = new Point((int)(radius * Math.Sin(secondAngle)), (int)(-(radius) * Math.Cos(secondAngle) + 2));



                if (drawSecondHandShadow)
                {
                    pen.Color = secondHandDropShadowColor;
                    grfx.DrawLine(pen, centre, secHandshadow);

                }

                centre.X = centre.Y = 0;
                pen.Color = secondHandColor;
                grfx.DrawLine(pen, centre, secHand);
            }
            pen.Dispose();


        } 
        #endregion


    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitClockAnalogDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitClockAnalogDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitClockAnalogSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitClockAnalogSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitClockAnalogSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitClockAnalog colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitClockAnalogSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitClockAnalogSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitClockAnalog;

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
        /// The Background image used in the clock face.
        /// </summary>
        /// <value>The face image.</value>
        /// <remarks>Using a large image will result in poor performance and increased memory consumption.</remarks>
        [
        Category("Clock"),
        Description("The Background image used in the clock face."),

        ]
        public Image FaceImage
        {
            get
            {
                return colUserControl.FaceImage;
            }
            set
            {
                GetPropertyByName("FaceImage").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Defines the second hand tick style.
        /// </summary>
        /// <value>The second hand tick style.</value>
        [
        Category("Clock"),
        Description("Defines the second hand tick style."),

        ]
        public TickStyle SecondHandTickStyle
        {
            get
            {
                return colUserControl.SecondHandTickStyle;
            }
            set
            {
                GetPropertyByName("SecondHandTickStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Defines the minute hand tick style.
        /// </summary>
        /// <value>The minute hand tick style.</value>
        [
        Category("Clock"),
        Description("Defines the minute hand tick style."),

        ]
        public TickStyle MinuteHandTickStyle
        {
            get
            {
                return colUserControl.MinuteHandTickStyle;
            }
            set
            {
                GetPropertyByName("MinuteHandTickStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Determines whether the Numerals are drawn on the clock face.
        /// </summary>
        /// <value><c>true</c> if [draw numerals]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the Numerals are drawn on the clock face."),
        DefaultValue(true),
        ]
        public bool DrawNumerals
        {
            get
            {
                return colUserControl.DrawNumerals;
            }
            set
            {
                GetPropertyByName("DrawNumerals").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Sets or gets the rendering quality of the clock.
        /// </summary>
        /// <value>The smoothing mode.</value>
        /// <remarks>This property does not effect the numeral text rendering quality. To set the numeral text rendering quality use the <see cref="TextRenderingHint" /> Property</remarks>
        [
        Category("Clock"),
        Description("Sets or gets the rendering quality of the clock."),
        DefaultValue(SmoothingMode.AntiAlias),
        ]
        public SmoothingMode SmoothingMode
        {
            get
            {
                return colUserControl.SmoothingMode;
            }
            set
            {
                GetPropertyByName("SmoothingMode").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Sets or gets the text rendering mode used for the clock numerals.
        /// </summary>
        /// <value>The text rendering hint.</value>
        [
        Category("Clock"),
        Description("Sets or gets the text rendering mode used for the clock numerals."),
        DefaultValue(TextRenderingHint.AntiAlias),
        ]

        public TextRenderingHint TextRenderingHint
        {
            get
            {
                return colUserControl.TextRenderingHint;
            }
            set
            {
                GetPropertyByName("TextRenderingHint").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Determines whether the clock Rim is drawn or not.
        /// </summary>
        /// <value><c>true</c> if [draw rim]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the clock Rim is drawn or not."),
        DefaultValue(true),
        ]
        public bool DrawRim
        {
            get
            {
                return colUserControl.DrawRim;
            }
            set
            {
                GetPropertyByName("DrawRim").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Determines whether drop shadow for the clock is drawn or not.
        /// </summary>
        /// <value><c>true</c> if [draw drop shadow]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether drop shadow for the clock is drawn or not."),
        DefaultValue(true),
        ]
        public bool DrawDropShadow
        {
            get
            {
                return colUserControl.DrawDropShadow;
            }
            set
            {
                GetPropertyByName("DrawDropShadow").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Sets or gets the color of the Drop Shadow.
        /// </summary>
        /// <value>The color of the drop shadow.</value>
        [
        Category("Clock"),
        Description("Sets or gets the color of the Drop Shadow."),

        ]
        public Color DropShadowColor
        {
            get
            {
                return colUserControl.DropShadowColor;
            }
            set
            {
                GetPropertyByName("DropShadowColor").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Sets or gets the color of the second hand drop Shadow.
        /// </summary>
        /// <value>The color of the second hand drop shadow.</value>
        [
        Category("Clock"),
        Description("Sets or gets the color of the second hand drop Shadow."),

        ]
        public Color SecondHandDropShadowColor
        {
            get
            {
                return colUserControl.SecondHandDropShadowColor;
            }
            set
            {
                GetPropertyByName("SecondHandDropShadowColor").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Sets or gets the color of the Minute hand drop Shadow.
        /// </summary>
        /// <value>The color of the minute hand drop shadow.</value>
        [
        Category("Clock"),
        Description("Sets or gets the color of the Minute hand drop Shadow."),

        ]
        public Color MinuteHandDropShadowColor
        {
            get
            {
                return colUserControl.MinuteHandDropShadowColor;
            }
            set
            {
                GetPropertyByName("MinuteHandDropShadowColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Sets or gets the color of the hour hand drop Shadow.
        /// </summary>
        /// <value>The color of the hour hand drop shadow.</value>
        [
        Category("Clock"),
        Description("Sets or gets the color of the hour hand drop Shadow."),

        ]
        public Color HourHandDropShadowColor
        {
            get
            {
                return colUserControl.HourHandDropShadowColor;
            }
            set
            {
                GetPropertyByName("HourHandDropShadowColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Determines the first color of the clock face gradient.
        /// </summary>
        /// <value>The face color high.</value>
        [
        Category("Clock"),
        Description("Determines the first color of the clock face gradient."),

        ]
        public Color FaceColorHigh
        {
            get
            {
                return colUserControl.FaceColorHigh;
            }
            set
            {
                GetPropertyByName("FaceColorHigh").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Determines the second color of the clock face gradient.
        /// </summary>
        /// <value>The face color low.</value>
        [
        Category("Clock"),
        Description("Determines the second color of the clock face gradient."),
        DefaultValue(typeof(Color), "Black")
        ]
        public Color FaceColorLow
        {
            get
            {
                return colUserControl.FaceColorLow;
            }
            set
            {
                GetPropertyByName("FaceColorLow").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Determines whether the second hand casts a drop shadow for added realism.
        /// </summary>
        /// <value><c>true</c> if [draw second hand shadow]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the second hand casts a drop shadow for added realism."),
        DefaultValue(true)
        ]
        public bool DrawSecondHandShadow
        {
            get
            {
                return colUserControl.DrawSecondHandShadow;
            }
            set
            {
                GetPropertyByName("DrawSecondHandShadow").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Determines whether the hour hand casts a drop shadow for added realism.
        /// </summary>
        /// <value><c>true</c> if [draw hour hand shadow]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the hour hand casts a drop shadow for added realism."),
        ]
        public bool DrawHourHandShadow
        {
            get
            {
                return colUserControl.DrawHourHandShadow;
            }
            set
            {
                GetPropertyByName("DrawHourHandShadow").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Determines whether the minute hand casts a drop shadow for added realism.
        /// </summary>
        /// <value><c>true</c> if [draw minute hand shadow]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the minute hand casts a drop shadow for added realism."),
        ]
        public bool DrawMinuteHandShadow
        {
            get
            {
                return colUserControl.DrawMinuteHandShadow;
            }
            set
            {
                GetPropertyByName("DrawMinuteHandShadow").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Determines the first color of the rim gradient.
        /// </summary>
        /// <value>The rim color high.</value>
        [
        Category("Clock"),
        Description("Determines the first color of the rim gradient."),
        ]
        public Color RimColorHigh
        {
            get
            {
                return colUserControl.RimColorHigh;
            }
            set
            {
                GetPropertyByName("RimColorHigh").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Determines the second color of the rim face gradient.
        /// </summary>
        /// <value>The rim color low.</value>
        [
        Category("Clock"),
        Description("Determines the second color of the rim face gradient."),
        ]
        public Color RimColorLow
        {
            get
            {
                return colUserControl.RimColorLow;
            }
            set
            {
                GetPropertyByName("RimColorLow").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the direction of the Rim gradient.
        /// </summary>
        /// <value>The rim gradient mode.</value>
        //TODO:replace this by degree
        [
        Category("Clock"),
        Description("Gets or sets the direction of the Rim gradient."),
        ]
        public LinearGradientMode RimGradientMode
        {
            get
            {
                return colUserControl.RimGradientMode;
            }
            set
            {
                GetPropertyByName("RimGradientMode").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the direction of the Clock Face gradient.
        /// </summary>
        /// <value>The face gradient mode.</value>
        //TODO:replace this by degree
        [
        Category("Clock"),
        Description("Gets or sets the direction of the Clock Face gradient."),
        ]
        public LinearGradientMode FaceGradientMode
        {
            get
            {
                return colUserControl.FaceGradientMode;
            }
            set
            {
                GetPropertyByName("FaceGradientMode").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Determines the Seconds hand end line shape.
        /// </summary>
        /// <value>The second hand end cap.</value>
        [
        Category("Clock"),
        Description("Determines the shape of second hand."),
        ]
        public LineCap SecondHandEndCap
        {
            get
            {
                return colUserControl.SecondHandEndCap;
            }
            set
            {
                GetPropertyByName("SecondHandEndCap").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// The System.DateTime structure which is used to display time.
        /// </summary>
        /// <value>The time.</value>
        /// <example>
        ///   <code>
        /// AnalogClock clock = new AnalogClock();
        /// clock.Time = DateTime.Now;
        /// </code>
        /// </example>
        /// <remarks>The clock face is updated every time the value of this property is changed.</remarks>
        [
        Category("Clock"),
        Description("The DateTime structure which the clock uses to display time."),
        Browsable(false)
        ]
        public DateTime Time
        {
            get
            {
                return colUserControl.Time;
            }
            set
            {
                GetPropertyByName("Time").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the Seconds Hand.
        /// </summary>
        /// <value>The color of the second hand.</value>
        [
        Category("Clock"),
        Description("Gets or sets the color of the Seconds Hand."),
        ]
        public Color SecondHandColor
        {
            get
            {
                return colUserControl.SecondHandColor;
            }
            set
            {
                GetPropertyByName("SecondHandColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Sets or gets the color of the clock Numerals.
        /// </summary>
        /// <value>The color of the numeral.</value>
        /// <remarks>To change the numeral font use the <see cref=" Font " /> Property</remarks>
        [
        Category("Clock"),
        Description("Sets or gets the color of the clock Numerals."),
        ]
        public Color NumeralColor
        {
            get
            {
                return colUserControl.NumeralColor;
            }
            set
            {
                GetPropertyByName("NumeralColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the Hour Hand.
        /// </summary>
        /// <value>The color of the hour hand.</value>
        [
        Category("Clock"),
        Description("Gets or sets the color of the Hour Hand."),
        ]
        public Color HourHandColor
        {
            get
            {
                return colUserControl.HourHandColor;
            }
            set
            {
                GetPropertyByName("HourHandColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the Minute Hand.
        /// </summary>
        /// <value>The color of the minute hand.</value>
        [
        Category("Clock"),
        Description("Gets or sets the color of the Minute Hand."),
        ]
        public Color MinuteHandColor
        {
            get
            {
                return colUserControl.MinuteHandColor;
            }
            set
            {
                GetPropertyByName("MinuteHandColor").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Determines whether the second Hand is shown.
        /// </summary>
        /// <value><c>true</c> if [draw second hand]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the second Hand is shown."),
        ]
        public bool DrawSecondHand
        {
            get
            {
                return colUserControl.DrawSecondHand;
            }
            set
            {
                GetPropertyByName("DrawSecondHand").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Determines whether the minute hand is shown.
        /// </summary>
        /// <value><c>true</c> if [draw minute hand]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the minute hand is shown."),
        ]
        public bool DrawMinuteHand
        {
            get
            {
                return colUserControl.DrawMinuteHand;
            }
            set
            {
                GetPropertyByName("DrawMinuteHand").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Determines whether the hour Hand is shown.
        /// </summary>
        /// <value><c>true</c> if [draw hour hand]; otherwise, <c>false</c>.</value>
        [
        Category("Clock"),
        Description("Determines whether the hour Hand is shown."),
        ]
        public bool DrawHourHand
        {
            get
            {
                return colUserControl.DrawHourHand;
            }
            set
            {
                GetPropertyByName("DrawHourHand").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the drop shadow offset.
        /// </summary>
        /// <value>The drop shadow offset.</value>
        [
        Category("Clock"),
        Description("Gets or sets the drop shadow offset."),
        ]
        public Point DropShadowOffset
        {
            get
            {
                return colUserControl.DropShadowOffset;
            }
            set
            {
                GetPropertyByName("DropShadowOffset").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text font.
        /// </summary>
        /// <value>The text font.</value>
        public Font TextFont
        {
            get
            {
                return colUserControl.TextFont;
            }
            set
            {
                GetPropertyByName("TextFont").SetValue(colUserControl, value);
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

            //items.Add(new DesignerActionPropertyItem("BackColor",
            //                     "Back Color", "Appearance",
            //                     "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("FaceImage",
                                 "Face Image", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("SecondHandTickStyle",
                                 "Second Hand TickStyle", "Appearance",
                                 "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("MinuteHandTickStyle",
            //                     "Minute Hand TickStyle", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("SmoothingMode",
            //                     "Smoothing Mode", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("TextRenderingHint",
            //                     "Text Rendering Hint", "Appearance",
            //                     "Type few characters to filter Cities."));


            items.Add(new DesignerActionPropertyItem("DropShadowColor",
                                 "Drop Shadow Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SecondHandDropShadowColor",
                                 "Second Hand DropShadowColor", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("MinuteHandDropShadowColor",
                                 "Minute Hand DropShadowColor", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("HourHandDropShadowColor",
                                 "Hour Hand DropShadowColor", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("FaceColorHigh",
                                 "Face  ColorHigh", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("FaceColorLow",
                                 "Face Color Low", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("RimColorHigh",
                                 "Rim Color High", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("RimColorLow",
                                 "Rim Color Low", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("RimGradientMode",
                                 "Rim Gradient Mode", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("FaceGradientMode",
                                 "Face Gradient Mode", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SecondHandEndCap",
                                 "Second Hand EndCap", "Appearance",
                                 "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("Time",
            //                     "Time", "Appearance",
            //                     "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SecondHandColor",
                                 "Second Hand Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("NumeralColor",
                                 "Numeral Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("HourHandColor",
                                 "Hour Hand Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("MinuteHandColor",
                                 "Minute Hand Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SecondHandColor",
                                 "SecondHandColor", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SecondHandColor",
                                 "Second Hand Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("NumeralColor",
                                 "Numeral Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("HourHandColor",
                                 "Hour Hand Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("MinuteHandColor",
                                 "Minute Hand Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SecondHandColor",
                                 "SecondHandColor", "Appearance",
                                 "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("DrawSecondHand",
            //                     "Draw Second Hand", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("DrawMinuteHand",
            //                     "Draw Minute Hand", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("DrawHourHand",
            //                     "Draw Hour Hand", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("DrawSecondHandShadow",
            //                     "Draw Second Hand Shadow", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("DrawHourHandShadow",
            //                     "Draw Hour Hand Shadow", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("DrawMinuteHandShadow",
            //                     "Draw Minute Hand Shadow", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("DrawNumerals",
            //                     "Draw Numerals", "Appearance",
            //                     "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("DrawRim",
                                 "Draw Rim", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("DrawDropShadow",
                                 "Draw DropShadow", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("DropShadowOffset",
                                 "Drop Shadow Offset", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("TextFont",
                                 "TextFont", "Appearance",
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
