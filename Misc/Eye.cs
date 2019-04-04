// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Eye.cs" company="Zeroit Dev Technologies">
//    This program is for creating various controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Eye

    #region Ball

    /// <summary>
    /// A class collection for rendering an eye ball.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    /// <remarks>Credits to ]Metty[ for the majority of this control.
    

    [ToolboxItem(false)]
    public class ZeroitEyeBall : Control
    {
        #region -- Members --
        /// <summary>
        /// The move x
        /// </summary>
        private double moveX;
        /// <summary>
        /// The move y
        /// </summary>
        private double moveY;
        /// <summary>
        /// The x
        /// </summary>
        private double X;
        /// <summary>
        /// The y
        /// </summary>
        private double Y;
        /// <summary>
        /// The gravity
        /// </summary>
        private const double gravity = 0.1;
        /// <summary>
        /// The col
        /// </summary>
        private Color col;
        /// <summary>
        /// The rand
        /// </summary>
        private Random rand;
        /// <summary>
        /// The moving
        /// </summary>
        private bool moving;
        /// <summary>
        /// The relative
        /// </summary>
        private Point rel;
        /// <summary>
        /// The area
        /// </summary>
        private Rectangle area;


        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.Black;
        /// <summary>
        /// The border width
        /// </summary>
        private int borderWidth = 3;
        /// <summary>
        /// The inflated value
        /// </summary>
        private int inflatedValue = 2;
        #endregion

        #region -- Properties --        
        /// <summary>
        /// Gets or sets the inflated value.
        /// </summary>
        /// <value>The inflated value.</value>
        public int InflatedValue
        {
            get { return inflatedValue; }
            set
            {
                inflatedValue = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
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
        /// Gets or sets the area.
        /// </summary>
        /// <value>The area.</value>
        public Rectangle Area
        {
            get { return area; }
            set { area = value; }
        }
        #endregion

        #region -- Constructor --
        /// <summary>
        /// Initializes a new instance of the <see cref="Ball" /> class.
        /// </summary>
        public ZeroitEyeBall()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeControl();
        }

        /// <summary>
        /// Initializes the control.
        /// </summary>
        private void InitializeControl()
        {
            BackColor = Color.Transparent;
            rand = new Random(Environment.TickCount);
            col = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            Width = 24;
            Height = 24;
        }
        #endregion

        #region -- Protected overrides --

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ParentChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (Parent != null)
                area = Parent.ClientRectangle;
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = ClientRectangle;
            rect.Inflate(-inflatedValue, -inflatedValue);
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(rect);
                g.FillPath(new SolidBrush(col), path);
                Region = new Region(path);
            }
            rect.Inflate(-inflatedValue, -inflatedValue);
            g.DrawEllipse(new Pen(borderColor, borderWidth), rect);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                rel = e.Location;
                Capture = true;
                moving = true;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                Capture = false;
                moving = false;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!moving) return;
            X = e.Location.X - rel.X + Location.X;
            Y = e.Location.Y - rel.Y + Location.Y;

            moveX += (X - Location.X) / 2;
            moveY += (Y - Location.Y) / 2;
            if (moveX > 2) moveX = 2;
            if (moveY > 2) moveY = 2;

            Location = new Point((int)X, (int)Y);
        }
        #endregion

        #region -- Public Methods --

        #region Center
        /// <summary>
        /// Centers this instance.
        /// </summary>
        /// <returns>Point.</returns>
        public Point Center()
        {
            Point center = PointToScreen(new Point(0, 0));
            center.Offset(Width / 2, Height / 2);
            return center;
        }
        #endregion

        #region Bounce
        /// <summary>
        /// Bounces this instance.
        /// </summary>
        public void Bounce()
        {
            moveX = (rand.NextDouble() + rand.NextDouble()) - 1;
            moveY = -(rand.NextDouble());
            moveX *= 50;
            moveY *= 50;
            X += moveX;
            Y += moveY;
        }
        #endregion

        #region Tick
        /// <summary>
        /// Ticks this instance.
        /// </summary>
        public void Tick()
        {
            if (moving) return;
            moveY += gravity;

            X += moveX;
            Y += moveY;
            Location = new Point((int)X, (int)Y);

            //Check Collision
            if (X < 0)
            {
                X = 0;
                moveX = -moveX;
                moveX *= 0.75;
                moveY *= 0.95;
            }
            if (X > area.Width - 1 - Width)
            {
                X = area.Width - 1 - Width;
                moveX = -moveX;
                moveX *= 0.75;
                moveY *= 0.95;
            }

            if (Y < 0)
            {
                Y = 0;
                moveY = -moveY;
                moveY *= 0.75;
                moveX *= 0.95;
            }
            if (Y > area.Height - 1 - Height)
            {
                Y = area.Height - 1 - Height;
                moveY = -moveY;
                moveY *= 0.8;
                moveX *= 0.95;
            }

            if (Math.Abs(moveX) < 0.1 && Math.Abs(moveY) < 0.5 &&
              DateTime.Now.Second % 3 == 0 && Y > area.Height - 1 - Height - 40)
            {
                Bounce();
            }
        }
        #endregion

        #endregion
    }

    #endregion

    #region Eye

    /// <summary>
    /// A class collection for rendering an eye.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    /// <remarks>Credits to Niel M. Thomas.</remarks>
    [Designer(typeof(ZeroitEyeDesigner))]
    public class ZeroitEye : Control
    {
        #region -- Members --

        /// <summary>
        /// The focus point
        /// </summary>
        private Point focusPoint;
        /// <summary>
        /// The center point
        /// </summary>
        private PointF centerPoint;
        /// <summary>
        /// The focus distance
        /// </summary>
        private int focusDistance;
        /// <summary>
        /// The focus angle
        /// </summary>
        private int focusAngle;
        /// <summary>
        /// The pupil size
        /// </summary>
        private int pupilSize;
        /// <summary>
        /// The iris size
        /// </summary>
        private int irisSize;
        /// <summary>
        /// The slit size
        /// </summary>
        private int slitSize;
        /// <summary>
        /// The lid thickness
        /// </summary>
        private int lidThickness;
        /// <summary>
        /// The temporary slit size
        /// </summary>
        private int tmpSlitSize;
        /// <summary>
        /// The blink step
        /// </summary>
        private int blinkStep;
        /// <summary>
        /// The lid offset
        /// </summary>
        private int lidOffset;
        /// <summary>
        /// The iris color
        /// </summary>
        private Color irisColor;
        /// <summary>
        /// The shadow color
        /// </summary>
        private Color shadowColor;
        /// <summary>
        /// The iris colors
        /// </summary>
        private Color[] irisColors;
        /// <summary>
        /// The shadow colors
        /// </summary>
        private Color[] shadowColors;
        /// <summary>
        /// The lid color
        /// </summary>
        private Color lidColor;
        /// <summary>
        /// The lid border color
        /// </summary>
        private Color lidBorderColor;
        /// <summary>
        /// The pupil color
        /// </summary>
        private Color pupilColor;
        /// <summary>
        /// The iris rectangle
        /// </summary>
        private RectangleF irisRectangle;
        /// <summary>
        /// The pupil rectangle
        /// </summary>
        private RectangleF pupilRectangle;
        /// <summary>
        /// The eye rectangle
        /// </summary>
        private RectangleF eyeRectangle;
        /// <summary>
        /// The draw lid
        /// </summary>
        private bool drawLid;
        /// <summary>
        /// The draw shadow
        /// </summary>
        private bool drawShadow;
        /// <summary>
        /// The draw detailed iris
        /// </summary>
        private bool drawDetailedIris;
        /// <summary>
        /// The blinking
        /// </summary>
        private bool blinking;
        /// <summary>
        /// The direction up
        /// </summary>
        private bool directionUp;
        /// <summary>
        /// The blink thread
        /// </summary>
        private Thread blinkThread;
        /// <summary>
        /// The eye type
        /// </summary>
        private EyeType eyeType;

        #region enum EyeType

        /// <summary>
        /// Eye type
        /// </summary>
        public enum EyeType
        {
            /// <summary>
            /// Left eye (Gives an offset to the eye lid to the right)
            /// </summary>
            Left,
            /// <summary>
            /// Right eye (Gives an offset to the eye lid to the left)
            /// </summary>
            Right,
            /// <summary>
            /// No offset (default)
            /// </summary>
            Cyclops
        }

        #endregion

        // events used to stop worker thread

        #endregion


        #region Include in Private Field

        /// <summary>
        /// The limit
        /// </summary>
        private int limit = 20;
        /// <summary>
        /// The automatic animate
        /// </summary>
        private bool autoAnimate = true;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        /// <summary>
        /// The interval
        /// </summary>
        private int interval = 200;

        #endregion

        #region Event

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.SlitSize + 1 > Limit)
                this.SlitSize = 0;
            else
                this.SlitSize++;
        }

        #endregion

        #region -- Properties --

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [automatic animate].
        /// </summary>
        /// <value><c>true</c> if [automatic animate]; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get { return autoAnimate; }
            set
            {
                autoAnimate = value;

                if (value == true)
                {
                    timer.Enabled = true;
                }

                else
                {
                    timer.Enabled = false;
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        public int TimerInterval
        {
            get { return interval; }
            set
            {
                interval = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <value>The limit.</value>
        public int Limit
        {
            get { return limit; }
            set
            {
                limit = value;
                Invalidate();
            }
        }

        #endregion


        /// <summary>
        /// Gets or sets the height and width of the control.
        /// </summary>
        /// <value>The size.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public new Size Size
        {
            get { return base.Size; }
            set
            {
                base.Size = value;
                CalcRectangles();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the blink step.
        /// </summary>
        /// <value>The blink step.</value>
        [DefaultValue(10), Category("Eye"), Browsable(true)]
        [Description("The blink velocity, higher is faster.")]
        public int BlinkStep
        {
            get { return blinkStep; }
            set { blinkStep = value; }
        }
        /// <summary>
        /// Gets or sets the color of the pupil.
        /// </summary>
        /// <value>The color of the pupil.</value>
        [DefaultValue(typeof(Color), "Black")]
        [Category("Eye"), Browsable(true)]
        [Description("The color of the pupil.")]
        public Color PupilColor
        {
            get { return pupilColor; }
            set
            {
                pupilColor = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the lid offset, is the Iris width / Value in pixels.
        /// </summary>
        /// <value>The lid offset.</value>
        [DefaultValue(5), Category("Eye"), Browsable(true)]
        [Description("Is the Iris width / value in pixels. Must be greater than 3.")]
        public int LidOffset
        {
            get { return lidOffset; }
            set
            {
                lidOffset = value;
                if (value < 3)
                    lidOffset = 3;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type of eye.
        /// </summary>
        /// <value>The type of eye.</value>
        [DefaultValue(typeof(EyeType), "Cyclops")]
        [Category("Eye"), Browsable(true)]
        [Description("Left, Right og Cyclops (Default)")]
        public EyeType TypeOfEye
        {
            get { return eyeType; }
            set
            {
                eyeType = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the lid border.
        /// </summary>
        /// <value>The color of the lid border.</value>
        [DefaultValue(typeof(Color), "Sienna")]
        [Category("Eye"), Browsable(true)]
        [Description("The border color of the lid.")]
        public Color LidBorderColor
        {
            get { return lidBorderColor; }
            set
            {
                lidBorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the lid.
        /// </summary>
        /// <value>The color of the lid.</value>
        [DefaultValue(typeof(Color), "Bisque")]
        [Category("Eye"), Browsable(true)]
        [Description("The color of the lid. Bisque is default.")]
        public Color LidColor
        {
            get { return lidColor; }
            set
            {
                lidColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the lid thickness.
        /// </summary>
        /// <value>The lid thickness.</value>
        [DefaultValue(5), Category("Eye"), Browsable(true)]
        [Description("The thickness of the upper lid in pixels.")]
        public int LidThickness
        {
            get { return lidThickness; }
            set
            {
                lidThickness = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to draw lid.
        /// </summary>
        /// <value><c>true</c> if [draw lid]; otherwise, <c>false</c>.</value>
        [DefaultValue(true), Category("Eye"), Browsable(true)]
        [Description("Draw the lid.")]
        public bool DrawLid
        {
            get { return drawLid; }
            set
            {
                drawLid = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the slit.
        /// </summary>
        /// <value>The size of the slit.</value>
        [DefaultValue(20), Category("Eye"), Browsable(true)]
        [Description("The size of the eye slit.")]
        public int SlitSize
        {
            get { return slitSize; }
            set
            {
                slitSize = value;
                if (slitSize < 0) slitSize = 0;
                CalcRectangles();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw detailed iris].
        /// </summary>
        /// <value><c>true</c> if [draw detailed iris]; otherwise, <c>false</c>.</value>
        [DefaultValue(true), Category("Eye"), Browsable(true)]
        [Description("Draw a detailed iris. Default is true.")]
        public bool DrawDetailedIris
        {
            get { return drawDetailedIris; }
            set
            {
                drawDetailedIris = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw shadow].
        /// </summary>
        /// <value><c>true</c> if [draw shadow]; otherwise, <c>false</c>.</value>
        [DefaultValue(true), Category("Eye"), Browsable(true)]
        [Description("Draw a shadow around the eye. Gives a 3D look.")]
        public bool DrawShadow
        {
            get { return drawShadow; }
            set
            {
                drawShadow = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        [DefaultValue(typeof(Color), "Red")]
        [Category("Eye"), Browsable(true)]
        [Description("The color of the shadow, Default is red.")]
        public Color ShadowColor
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value;
                shadowColors = new[]
                                 {
                           Color.FromArgb(40, shadowColor),
                           Color.FromArgb(10, shadowColor),
                           Color.Transparent
                         };
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the iris.
        /// </summary>
        /// <value>The color of the iris.</value>
        [DefaultValue(typeof(Color), "Brown")]
        [Category("Eye"), Browsable(true)]
        [Description("The color of the Iris.")]
        public Color IrisColor
        {
            get { return irisColor; }
            set
            {
                irisColor = value;
                irisColors = new Color[4];
                int rc = irisColor.R;
                int gc = irisColor.G;
                int bc = irisColor.B;
                irisColors[0] = Color.Transparent;
                irisColors[1] = Color.FromArgb(Math.Max((rc - 100), 0), Math.Max((gc - 100), 0), Math.Max((bc - 100), 0));
                irisColors[2] = irisColor = value;
                irisColors[3] = Color.FromArgb(Math.Min((rc + 100), 255), Math.Min((gc + 100), 255), Math.Min((bc + 100), 255));
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the focus distance (Screen coordinates)
        /// </summary>
        /// <value>The focus distance.</value>
        [DefaultValue(typeof(Point), "{0;0}")]
        [Category("Eye"), Browsable(true)]
        [Description("The location for the eye to look. In screen coordinates")]
        public Point FocusPoint
        {
            get { return focusPoint; }
            set
            {
                if (focusPoint == value) return;
                focusPoint = value;
                Point center = Center();
                focusDistance = (int)Distance(focusPoint, center);
                focusAngle = (int)CalcAngle(focusPoint, center);
                CalcRectangles();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets the focus angle.
        /// </summary>
        /// <value>The focus angle.</value>
        [Category("Eye"), Browsable(true)]
        [Description("The angle from 0 to the focus point.")]
        public int FocusAngle
        {
            get { return focusAngle; }
        }

        /// <summary>
        /// Gets the focus distance.
        /// </summary>
        /// <value>The focus distance.</value>
        [Category("Eye"), Browsable(true)]
        [Description("The distance from the center of the eye to the focus point.")]
        public int FocusDistance
        {
            get { return focusDistance; }
        }

        /// <summary>
        /// Gets or sets the size of the pupil.
        /// </summary>
        /// <value>The size of the pupil.</value>
        [DefaultValue(20), Category("Eye"), Browsable(true)]
        [Description("The size of the pupil.")]
        public int PupilSize
        {
            get { return pupilSize; }
            set
            {
                pupilSize = value;
                if (pupilSize < 0) pupilSize = 0;
                if (pupilSize > 50) pupilSize = 50;
                CalcRectangles();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the iris.
        /// </summary>
        /// <value>The size of the iris.</value>
        [DefaultValue(30), Category("Eye"), Browsable(true)]
        [Description("The iris size.")]
        public int IrisSize
        {
            get { return irisSize; }
            set
            {
                irisSize = value;
                if (irisSize < 0) irisSize = 0;
                if (irisSize > 50) irisSize = 50;
                CalcRectangles();
                Invalidate();
            }
        }

        #endregion

        #region -- Constructor --

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitEye" /> class.
        /// </summary>
        public ZeroitEye()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

            #region MyRegion
            if (DesignMode)
            {
                timer.Tick += Timer_Tick;
                if (AutoAnimate)
                {
                    //timer.Interval = 100;
                    timer.Start();
                }
            }

            if (!DesignMode)
            {
                timer.Tick += Timer_Tick;

                if (AutoAnimate)
                {
                    //timer.Interval = 100;
                    timer.Start();
                }
            }



            #endregion
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            Size = new Size(100, 100);
            eyeType = EyeType.Cyclops;
            drawLid = true;
            drawShadow = true;
            drawDetailedIris = true;
            pupilSize = 20;
            irisSize = 30;
            slitSize = 20;
            lidThickness = 5;
            blinkStep = 10;
            lidOffset = 5;
            pupilColor = Color.Black;
            lidColor = Color.Bisque;
            lidBorderColor = Color.Sienna;
            IrisColor = Color.Brown;
            ShadowColor = Color.Red;
            // Calc values based on default settings
            CalcRectangles();
            blinkThread = new Thread(BlinkThreadStart) { Name = "BlinkThread" };
        }

        #endregion

        #region -- Protected overrides (Control) --

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CalcRectangles();
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {

            timer.Interval = interval;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            base.OnPaintBackground(e);
            PaintBackground(g);
            PaintIris(g);
            if (drawShadow) PaintShadow(g);
            PaintPupil(g);
            PaintReflex(g);
            if (drawLid) PaintLid(g);
            g.SmoothingMode = SmoothingMode.Default; // Reset
        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
        }

        #endregion

        #region -- Public Methods --

        #region Blink

        /// <summary>
        /// Make the Eye blink.
        /// </summary>
        public virtual void Blink()
        {
            if (blinking) return;
            blinking = true;
            tmpSlitSize = slitSize;
            directionUp = false;
            if (blinkThread != null && blinkThread.ThreadState != System.Threading.ThreadState.Unstarted)
            {
                blinkThread.Abort();
                blinkThread = new Thread(BlinkThreadStart) { Name = "BlinkThread" };
            }
            blinkThread.Start();
        }

        #endregion

        #endregion

        #region -- Protected virtual methods --

        #region PaintBackground

        /// <summary>
        /// Paints the background.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void PaintBackground(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.White), eyeRectangle);
            g.DrawEllipse(new Pen(Color.White, 1), eyeRectangle);
        }

        #endregion

        #region PaintIris

        /// <summary>
        /// Paints the iris.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void PaintIris(Graphics g)
        {
            RectangleF rect = irisRectangle;
            if (!drawDetailedIris)
            {
                using (Brush b = new SolidBrush(irisColor))
                    g.FillEllipse(b, rect);
                g.DrawEllipse(new Pen(irisColor, 1), rect);
            }
            else
            {
                if (rect.IsEmpty) return;
                using (var path = new GraphicsPath())
                {
                    path.AddEllipse(rect);
                    using (var gradientBrush = new PathGradientBrush(path))
                    {
                        gradientBrush.CenterPoint = centerPoint;
                        var cb = new ColorBlend(4)
                        {
                            Colors = irisColors,
                            Positions = new[] { 0.0F, 0.05F, 0.1F, 1.0F }
                        };
                        if (cb.Colors == null) return;
                        gradientBrush.InterpolationColors = cb;
                        g.FillPath(gradientBrush, path);
                        g.DrawPath(new Pen(irisColor, 1), path);
                    }
                }
            }
        }

        #endregion

        #region PaintPupil

        /// <summary>
        /// Paints the pupil.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void PaintPupil(Graphics g)
        {
            using (var b = new SolidBrush(pupilColor))
                g.FillEllipse(b, pupilRectangle);
            g.DrawEllipse(new Pen(pupilColor, 1), pupilRectangle);

        }

        #endregion

        #region PaintReflex

        /// <summary>
        /// Paints the reflex.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void PaintReflex(Graphics g)
        {
            using (var path = new GraphicsPath())
            {
                path.AddArc(eyeRectangle, -180, 180);
                var lowerArcRect = new Rectangle(0, Height / 3, Width, Height / 4);
                path.AddArc(lowerArcRect, 0, 180);
                path.CloseFigure();
                using (var lgb = new LinearGradientBrush(eyeRectangle,
                                                         Color.FromArgb(40, Color.White),
                                                         Color.FromArgb(100, Color.White), 90))
                {
                    g.FillPath(lgb, path);
                    //g.DrawPath(new Pen(Color.White, 1), path);
                }
            }
        }

        #endregion

        #region PaintShadow

        /// <summary>
        /// Prints the shadow.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void PaintShadow(Graphics g)
        {
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(eyeRectangle);
                using (var gradientBrush = new PathGradientBrush(path))
                {
                    gradientBrush.CenterPoint = new PointF(eyeRectangle.Width / 2, eyeRectangle.Height / 2);
                    gradientBrush.CenterColor = Color.Transparent;
                    var cb = new ColorBlend(3)
                    {
                        Colors = shadowColors,
                        Positions = new[] { 0.0F, 0.3F, 1.0F }
                    };
                    gradientBrush.InterpolationColors = cb;
                    g.FillPath(gradientBrush, path);
                }
            }
        }

        #endregion

        #region PaintLid

        /// <summary>
        /// Paints the lid.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void PaintLid(Graphics g)
        {
            using (var path = new GraphicsPath())
            {
                path.AddArc(eyeRectangle, -180, 180);
                var slitHeight = (int)(eyeRectangle.Height * slitSize / 100);
                // Offset for the Right / Left eye
                float offSet = 0;
                if (eyeType == EyeType.Left)
                    offSet = irisRectangle.Width / lidOffset;
                else if (eyeType == EyeType.Right)
                    offSet = -irisRectangle.Width / lidOffset;
                // Top an bottom of the Lid arc.
                var top = new PointF(centerPoint.X + offSet, centerPoint.Y - slitHeight);
                var bottom = new PointF(centerPoint.X + offSet, centerPoint.Y + slitHeight);
                var upper = new[]
                              {
                        new Point(Width, Height/2), top, new Point(1, Height/2)
                      };
                var lower = new[]
                              {
                        new Point(Width, Height/2), bottom,
                        new Point(1, Height/2)
                      };
                // Create the upper and lower lids as 2 figures.
                path.AddCurve(upper);
                path.CloseFigure();
                path.AddArc(eyeRectangle, -180, -180);
                path.AddCurve(lower);
                path.CloseFigure();
                // Fill lids
                using (Brush b = new SolidBrush(lidColor))
                    g.FillPath(b, path);
                // Draw the border
                using (var p = new Pen(lidBorderColor, lidThickness))
                    g.DrawCurve(p, upper);
                using (var p = new Pen(lidBorderColor, 1))
                    g.DrawCurve(p, lower);
            }
        }

        #endregion

        #region CalcRectangles

        /// <summary>
        /// Calcs the rectangles.
        /// </summary>
        protected virtual void CalcRectangles()
        {
            RectangleF rect = ClientRectangle;
            rect.Inflate(-1, -1);
            // eyeRectangle
            eyeRectangle = rect;
            // IrisRectangle
            rect.Inflate(-(rect.Width * (50 - IrisSize)) / 100,
                         -(rect.Height * (50 - IrisSize)) / 100);
            double offsetDistanceX = (Width - rect.Width) / 2;
            double offsetDistanceY = (Height - rect.Height) / 2;
            if (focusDistance < offsetDistanceX) offsetDistanceX = focusDistance;
            if (focusDistance < offsetDistanceY) offsetDistanceY = focusDistance;
            rect.Offset((float)(offsetDistanceX * Math.Cos((180 - focusAngle) * Math.PI / 180)),
                        (float)(-offsetDistanceY * Math.Sin((180 - focusAngle) * Math.PI / 180)));
            irisRectangle = rect;
            irisRectangle.Inflate(-2, -2); // Reduce to avoid clipping
                                           // CenterPoint
            centerPoint = Center(irisRectangle);
            // PupilRectangle
            rect.Inflate(-(rect.Width * (52 - PupilSize)) / 100, -(rect.Height * (52 - PupilSize)) / 100);
            pupilRectangle = rect;
        }

        #endregion

        #endregion

        #region -- Private methods --

        #region CalcAngle

        /// <summary>
        /// Calculates the angle.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <returns>System.Double.</returns>
        private static double CalcAngle(Point p1, Point p2)
        {
            return (Math.Atan2(p2.Y - p1.Y, p2.X - p1.X) * 180.0 / Math.PI);
        }

        #endregion

        #region Distance

        /// <summary>
        /// Distances the specified p1.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <returns>System.Double.</returns>
        private static double Distance(PointF p1, PointF p2)
        {
            double x = p2.X - p1.X;
            double y = p2.Y - p1.Y;
            return Math.Sqrt(x * x + y * y);
        }

        #endregion

        #region Center

        /// <summary>
        /// Centers this instance.
        /// </summary>
        /// <returns>Point.</returns>
        public Point Center()
        {
            Point center = PointToScreen(new Point(0, 0));
            center.Offset(Width / 2, Height / 2);
            return center;
        }

        /// <summary>
        /// Centers the specified rect.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns>Point.</returns>
        private static Point Center(RectangleF rect)
        {
            return Center(Rectangle.Truncate(rect));
        }

        /// <summary>
        /// Centers the specified rect.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns>Point.</returns>
        private static Point Center(Rectangle rect)
        {
            return new Point(rect.Location.X + rect.Width / 2, rect.Location.Y + rect.Height / 2);
        }

        #endregion

        #region BlinkThreadStart

        /// <summary>
        /// Blinks the thread start.
        /// </summary>
        private void BlinkThreadStart()
        {
            while (blinking)
            {
                if ((slitSize - 10 >= 0) && !directionUp)
                {
                    slitSize -= 10;
                }
                else
                {
                    directionUp = true;
                    slitSize += 10;
                }
                Invalidate();
                Thread.Sleep(50);
                if ((slitSize >= tmpSlitSize) && directionUp)
                    blinking = false;
            }
            //Reset Size
            slitSize = tmpSlitSize;
        }

        #endregion

        #endregion
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitEyeDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitEyeDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitEyeSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitEyeSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitEyeSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitEye colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitEyeSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitEyeSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitEye;

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

        #region -- Properties --

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [automatic animate].
        /// </summary>
        /// <value><c>true</c> if [automatic animate]; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get
            {
                return colUserControl.AutoAnimate;
            }
            set
            {
                GetPropertyByName("AutoAnimate").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        public int TimerInterval
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

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <value>The limit.</value>
        public int Limit
        {
            get
            {
                return colUserControl.Limit;
            }
            set
            {
                GetPropertyByName("Limit").SetValue(colUserControl, value);
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public Size Size
        {
            get
            {
                return colUserControl.Size;
            }
            set
            {
                GetPropertyByName("Size").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the blink step.
        /// </summary>
        /// <value>The blink step.</value>
        public int BlinkStep
        {
            get
            {
                return colUserControl.BlinkStep;
            }
            set
            {
                GetPropertyByName("BlinkStep").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the pupil.
        /// </summary>
        /// <value>The color of the pupil.</value>
        public Color PupilColor
        {
            get
            {
                return colUserControl.PupilColor;
            }
            set
            {
                GetPropertyByName("PupilColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the lid offset.
        /// </summary>
        /// <value>The lid offset.</value>
        public int LidOffset
        {
            get
            {
                return colUserControl.LidOffset;
            }
            set
            {
                GetPropertyByName("LidOffset").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of eye.
        /// </summary>
        /// <value>The type of eye.</value>
        public Zeroit.Framework.MiscControls.ZeroitEye.EyeType TypeOfEye
        {
            get
            {
                return colUserControl.TypeOfEye;
            }
            set
            {
                GetPropertyByName("TypeOfEye").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the lid border.
        /// </summary>
        /// <value>The color of the lid border.</value>
        public Color LidBorderColor
        {
            get
            {
                return colUserControl.LidBorderColor;
            }
            set
            {
                GetPropertyByName("LidBorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the lid.
        /// </summary>
        /// <value>The color of the lid.</value>
        public Color LidColor
        {
            get
            {
                return colUserControl.LidColor;
            }
            set
            {
                GetPropertyByName("LidColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the lid thickness.
        /// </summary>
        /// <value>The lid thickness.</value>
        public int LidThickness
        {
            get
            {
                return colUserControl.LidThickness;
            }
            set
            {
                GetPropertyByName("LidThickness").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw lid].
        /// </summary>
        /// <value><c>true</c> if [draw lid]; otherwise, <c>false</c>.</value>
        public bool DrawLid
        {
            get
            {
                return colUserControl.DrawLid;
            }
            set
            {
                GetPropertyByName("DrawLid").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the slit.
        /// </summary>
        /// <value>The size of the slit.</value>
        public int SlitSize
        {
            get
            {
                return colUserControl.SlitSize;
            }
            set
            {
                GetPropertyByName("SlitSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw detailed iris].
        /// </summary>
        /// <value><c>true</c> if [draw detailed iris]; otherwise, <c>false</c>.</value>
        public bool DrawDetailedIris
        {
            get
            {
                return colUserControl.DrawDetailedIris;
            }
            set
            {
                GetPropertyByName("DrawDetailedIris").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw shadow].
        /// </summary>
        /// <value><c>true</c> if [draw shadow]; otherwise, <c>false</c>.</value>
        public bool DrawShadow
        {
            get
            {
                return colUserControl.DrawShadow;
            }
            set
            {
                GetPropertyByName("DrawShadow").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        public Color ShadowColor
        {
            get
            {
                return colUserControl.ShadowColor;
            }
            set
            {
                GetPropertyByName("ShadowColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the iris.
        /// </summary>
        /// <value>The color of the iris.</value>
        public Color IrisColor
        {
            get
            {
                return colUserControl.IrisColor;
            }
            set
            {
                GetPropertyByName("IrisColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the focus point.
        /// </summary>
        /// <value>The focus point.</value>
        public Point FocusPoint
        {
            get
            {
                return colUserControl.FocusPoint;
            }
            set
            {
                GetPropertyByName("FocusPoint").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the pupil.
        /// </summary>
        /// <value>The size of the pupil.</value>
        public int PupilSize
        {
            get
            {
                return colUserControl.PupilSize;
            }
            set
            {
                GetPropertyByName("PupilSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the iris.
        /// </summary>
        /// <value>The size of the iris.</value>
        public int IrisSize
        {
            get
            {
                return colUserControl.IrisSize;
            }
            set
            {
                GetPropertyByName("IrisSize").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("DrawLid",
                                 "Draw Lid", "Appearance",
                                 "Set to draw lid."));

            items.Add(new DesignerActionPropertyItem("DrawDetailedIris",
                                 "Draw Detailed Iris", "Appearance",
                                 "Set to draw detailed iris."));

            items.Add(new DesignerActionPropertyItem("DrawShadow",
                                 "Draw Shadow", "Appearance",
                                 "Set to draw shadow."));

            items.Add(new DesignerActionPropertyItem("AutoAnimate",
                                 "Auto Animate", "Appearance",
                                 "Set to enable auto animation."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("TimerInterval",
                                 "Timer Interval", "Appearance",
                                 "Sets the timer interval."));

            items.Add(new DesignerActionPropertyItem("Limit",
                                 "Limit", "Appearance",
                                 "Sets the limit of the eye for the animation."));

            items.Add(new DesignerActionPropertyItem("Size",
                                 "Size", "Appearance",
                                 "Sets the size of the control."));

            items.Add(new DesignerActionPropertyItem("BlinkStep",
                                 "Blink Step", "Appearance",
                                 "Sets the blink step."));

            items.Add(new DesignerActionPropertyItem("PupilColor",
                                 "Pupil Color", "Appearance",
                                 "Sets the pupil color."));

            items.Add(new DesignerActionPropertyItem("LidOffset",
                                 "Lid Offset", "Appearance",
                                 "Sets the lid offset."));

            items.Add(new DesignerActionPropertyItem("TypeOfEye",
                                 "Type Of Eye", "Appearance",
                                 "Sets the type of eye."));

            items.Add(new DesignerActionPropertyItem("LidBorderColor",
                                 "Lid Border Color", "Appearance",
                                 "Sets the lid border color."));

            items.Add(new DesignerActionPropertyItem("LidColor",
                                 "Lid Color", "Appearance",
                                 "Sets the lid color."));

            items.Add(new DesignerActionPropertyItem("LidThickness",
                                 "Lid Thickness", "Appearance",
                                 "Sets the lid thickness."));

            items.Add(new DesignerActionPropertyItem("SlitSize",
                                 "Slit Size", "Appearance",
                                 "Sets the slit size."));


            items.Add(new DesignerActionPropertyItem("ShadowColor",
                                 "Shadow Color", "Appearance",
                                 "Sets the shadow color."));

            items.Add(new DesignerActionPropertyItem("IrisColor",
                                 "Iris Color", "Appearance",
                                 "Sets the iris color."));

            items.Add(new DesignerActionPropertyItem("FocusPoint",
                                 "Focus Point", "Appearance",
                                 "Sets the focus point."));

            items.Add(new DesignerActionPropertyItem("PupilSize",
                                 "Pupil Size", "Appearance",
                                 "Sets the pupil size."));

            items.Add(new DesignerActionPropertyItem("IrisSize",
                                 "Iris Size", "Appearance",
                                 "Sets the iris size."));

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

    #endregion
}
