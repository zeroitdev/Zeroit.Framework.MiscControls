// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="SlidingScale.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Scale Control

    #region Control

    /// <summary>
    /// A class collection for rendering a sliding scale.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
	public partial class ZeroitSlidingScale : UserControl
    {
        #region [ Constructor ... ]

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSlidingScale" /> class.
        /// </summary>
        public ZeroitSlidingScale()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.SupportsTransparentBackColor,
                     true);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ZeroitSlidingScale
            // 
            this.ForeColor = System.Drawing.Color.Black;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Name = "ZeroitSlidingScale";
            this.Size = new System.Drawing.Size(254, 45);
            this.ResumeLayout(false);
        }

        #endregion [ Constructor ]

        #region [ Properties ... ]

        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>The control.</value>
        public Control Control
        {
            get;
            set;
        }

        /// <summary>
        /// The current value
        /// </summary>
        private double curValue = 0.0;
        /// <summary>
        /// The current position of the scale.
        /// </summary>
        /// <value>The value.</value>
        [
            Browsable(true),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
            Category("Behavior"),
            Description("The current position of the scale."),
            DefaultValue(typeof(double), "0.0")
        ]
        public double Value
        {
            get { return curValue; }
            set
            {
                double oldValue = curValue;

                curValue = value;

                // Refresh only if the curValue is significant changed.
                if (Math.Abs(oldValue - curValue) > 0.0001)
                    this.Refresh();
            }
        }

        /// <summary>
        /// The scale range
        /// </summary>
        private double scaleRange = 100.0;
        /// <summary>
        /// The visible range of the scale.
        /// </summary>
        /// <value>The scale range.</value>
        [
            Browsable(true),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
            Category("Appearance"),
            Description("The visible range of the scale."),
            DefaultValue(typeof(double), "100.0")
        ]
        public double ScaleRange
        {
            get { return scaleRange; }
            set
            {
                if (value > 0.001)
                {
                    scaleRange = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The large ticks count
        /// </summary>
        private int largeTicksCount = 5;
        /// <summary>
        /// The number of large ticks.
        /// </summary>
        /// <value>The large ticks count.</value>
        [
            Browsable(true),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
            Category("Appearance"),
            Description("The number of large ticks."),
            DefaultValue(typeof(int), "5")
        ]
        public int LargeTicksCount
        {
            get { return largeTicksCount; }
            set
            {
                if (value != largeTicksCount && value > 0)
                {
                    largeTicksCount = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The large ticks length
        /// </summary>
        private int largeTicksLength = 15;
        /// <summary>
        /// The length of large ticks.
        /// </summary>
        /// <value>The length of the large ticks.</value>
        [
            Browsable(true),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
            Category("Appearance"),
            Description("The length of large ticks."),
            DefaultValue(typeof(int), "15")
        ]
        public int LargeTicksLength
        {
            get { return largeTicksLength; }
            set
            {
                if (value != largeTicksLength && value > -1)
                {
                    largeTicksLength = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The small ticks count
        /// </summary>
        private int smallTicksCount = 4;
        /// <summary>
        /// The number of small ticks.
        /// </summary>
        /// <value>The small tick count.</value>
        [
            Browsable(true),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
            Category("Appearance"),
            Description("The number of small ticks."),
            DefaultValue(typeof(int), "4")
        ]
        public int SmallTickCount
        {
            get { return smallTicksCount; }
            set
            {
                if (value != smallTicksCount && value > -1 && value < 10)
                {
                    smallTicksCount = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The small ticks length
        /// </summary>
        private int smallTicksLength = 10;
        /// <summary>
        /// The length of small ticks.
        /// </summary>
        /// <value>The length of the small tick.</value>
        [
            Browsable(true),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
            Category("Appearance"),
            Description("The length of small ticks."),
            DefaultValue(typeof(int), "10")
        ]
        public int SmallTickLength
        {
            get { return smallTicksLength; }
            set
            {
                if (value != smallTicksLength && value > -1)
                {
                    smallTicksLength = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The shadow enabled
        /// </summary>
        private bool shadowEnabled = true;
        /// <summary>
        /// The shadow color of the component.
        /// </summary>
        /// <value><c>true</c> if [shadow enabled]; otherwise, <c>false</c>.</value>
        [
            Browsable(true),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
            Category("Appearance"),
            Description("Is the shadow enabled?"),
            DefaultValue(typeof(bool), "true")
        ]
        public bool ShadowEnabled
        {
            get { return shadowEnabled; }
            set
            {
                if (value != shadowEnabled)
                {
                    shadowEnabled = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The shadow color
        /// </summary>
        private Color shadowColor = Color.Black;
        /// <summary>
        /// The shadow color of the component.
        /// </summary>
        /// <value>The color of the shadow.</value>
        [
            Browsable(true),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
            Category("Appearance"),
            Description("The shadow color of the component."),
            DefaultValue(typeof(Color), "Black")
        ]
        public Color ShadowColor
        {
            get { return shadowColor; }
            set
            {
                if (value != shadowColor)
                {
                    shadowColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The needle color
        /// </summary>
        private Color needleColor = Color.Blue;
        /// <summary>
        /// The color of the scala needle.
        /// </summary>
        /// <value>The color of the needle.</value>
        [
            Browsable(true),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
            Category("Appearance"),
            Description("The color of the scala needle."),
            DefaultValue(typeof(Color), "Blue")
        ]
        public Color NeedleColor
        {
            get { return needleColor; }
            set
            {
                if (value != needleColor)
                {
                    needleColor = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The orientation
        /// </summary>
        private Orientation orientation = Orientation.Horizontal;
        /// <summary>
        /// The orientation of the control.
        /// </summary>
        /// <value>The orientation.</value>
        [
            Browsable(true),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
            Category("Appearance"),
            Description("The orientation of the control."),
            DefaultValue(typeof(Orientation), "Horizontal")
        ]
        public Orientation Orientation
        {
            get { return orientation; }
            set
            {
                if (value != orientation)
                {
                    orientation = value;
                    this.Invalidate();
                }
            }
        }

        #endregion [ Properties ]

        #region [ Private ... ]

        /// <summary>
        /// The w
        /// </summary>
        private int W, H, Wm, Hm = 0;
        /// <summary>
        /// The large ticks distance
        /// </summary>
        private double largeTicksDistance = 0.0;
        /// <summary>
        /// The small ticks distance
        /// </summary>
        private double smallTicksDistance = 0.0;
        /// <summary>
        /// The small ticks pixels
        /// </summary>
        private float smallTicksPixels = 0f;



        /// <summary>
        /// Calculates the locals.
        /// </summary>
        private void CalculateLocals()
        {
            // Calculate help variables
            W = this.ClientRectangle.Width;
            H = this.ClientRectangle.Height;

            Wm = W / 2;
            Hm = H / 2;

            // Calculate distances between ticks
            largeTicksDistance = scaleRange / largeTicksCount;
            smallTicksDistance = largeTicksDistance / (smallTicksCount + 1);

            // Calculate number of pixel between small ticks
            if (Orientation == Orientation.Horizontal)
                smallTicksPixels = (float)(W / scaleRange * smallTicksDistance);
            else
                smallTicksPixels = (float)(H / scaleRange * smallTicksDistance);
        }

        /// <summary>
        /// Draws the horizontal.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawHorizontal(Graphics g)
        {
            // Calculate first large tick value and position
            double tickValue = Math.Floor((curValue - scaleRange / 2) /
                                          largeTicksDistance) * largeTicksDistance;
            float tickPosition = (float)Math.Floor(Wm - W / scaleRange * (curValue - tickValue));

            // Create drawing resources
            Pen pen = new Pen(ForeColor);
            Brush brush = new SolidBrush(ForeColor);

            // For all large ticks
            for (int L = 0; L <= largeTicksCount; L++)
            {
                // Draw large tick
                g.DrawLine(pen, tickPosition - 0, 0, tickPosition - 0, largeTicksLength);
                g.DrawLine(pen, tickPosition - 1, 0, tickPosition - 1, largeTicksLength);

                // Draw large tick numerical value
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                g.DrawString(Math.Round(tickValue, 2).ToString(),
                             Font, brush, new PointF(tickPosition, (H + largeTicksLength) / 2), sf);

                // For all small ticks
                for (int S = 1; S <= smallTicksCount; S++)
                {
                    // Update tick value and position
                    tickValue += smallTicksDistance;
                    tickPosition += smallTicksPixels;

                    // Draw small tick
                    g.DrawLine(pen, tickPosition, 0, tickPosition, smallTicksLength);
                }

                // Update tick value and position
                tickValue += smallTicksDistance;
                tickPosition += smallTicksPixels;
            }

            // Dispose drawing resources
            brush.Dispose();
            pen.Dispose();

            if (ShadowEnabled)
            {
                LinearGradientBrush LGBrush = null;
                Rectangle LGRect;

                // Draw left side shadow
                LGRect = new Rectangle(0, 0, Wm, H);
                LGBrush = new LinearGradientBrush(LGRect,
                                                  Color.FromArgb(255, ShadowColor),
                                                  Color.FromArgb(0, BackColor),
                                                  000, true);
                g.FillRectangle(LGBrush, LGRect);

                // Draw right/bottom side shadow
                LGRect = new Rectangle(Wm + 1, 0, Wm, H);
                LGBrush = new LinearGradientBrush(LGRect,
                                                  Color.FromArgb(255, ShadowColor),
                                                  Color.FromArgb(0, BackColor),
                                                  180, true);
                g.FillRectangle(LGBrush, LGRect);

                LGBrush.Dispose();
            }

            // Draw scale needle
            g.DrawLine(new Pen(NeedleColor), Wm - 0, 0, Wm - 0, H);
            g.DrawLine(new Pen(NeedleColor), Wm - 1, 0, Wm - 1, H);
        }

        /// <summary>
        /// Draws the vertical.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawVertical(Graphics g)
        {
            // Calculate first large tick value and position
            double tickValue = Math.Ceiling((curValue - scaleRange / 2) /
                                            largeTicksDistance) * largeTicksDistance;
            float tickPosition = (float)Math.Ceiling(Hm + H / scaleRange * (curValue - tickValue));

            // Create drawing resources
            Pen pen = new Pen(ForeColor);
            Brush brush = new SolidBrush(ForeColor);

            // For all large ticks
            for (int L = 0; L <= largeTicksCount; L++)
            {
                // Draw large tick
                g.DrawLine(pen, 0, tickPosition + 0, largeTicksLength, tickPosition + 0);
                g.DrawLine(pen, 0, tickPosition + 1, largeTicksLength, tickPosition + 1);

                // Draw large tick numerical value
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                g.DrawString(Math.Round(tickValue, 2).ToString(),
                             Font, brush, new PointF((W + largeTicksLength) / 2, tickPosition), sf);

                // For all small ticks
                for (int S = 1; S <= smallTicksCount; S++)
                {
                    // Update tick value and position
                    tickValue += smallTicksDistance;
                    tickPosition -= smallTicksPixels;

                    // Draw small tick
                    g.DrawLine(pen, 0, tickPosition, smallTicksLength, tickPosition);
                }

                // Update tick value and position
                tickValue += smallTicksDistance;
                tickPosition -= smallTicksPixels;
            }


            // Dispose drawing resources
            brush.Dispose();
            pen.Dispose();

            if (ShadowEnabled)
            {
                LinearGradientBrush LGBrush = null;

                Rectangle LGRect;

                // Draw left/top side shadow
                LGRect = new Rectangle(0, 0, W, Hm);
                LGBrush = new LinearGradientBrush(LGRect,
                                                  Color.FromArgb(255, ShadowColor),
                                                  Color.FromArgb(0, BackColor),
                                                  090, true);
                g.FillRectangle(LGBrush, LGRect);

                // Draw right/bottom side shadow
                LGRect = new Rectangle(0, Hm + 1, W, Hm);
                LGBrush = new LinearGradientBrush(LGRect,
                                                  Color.FromArgb(255, ShadowColor),
                                                  Color.FromArgb(0, BackColor),
                                                  270, true);
                g.FillRectangle(LGBrush, LGRect);

                LGBrush.Dispose();
            }

            // Draw scale needle
            g.DrawLine(new Pen(NeedleColor), 0, Hm + 0, W, Hm + 0);
            g.DrawLine(new Pen(NeedleColor), 0, Hm + 1, W, Hm + 1);
        }

        #endregion [ Private ]

        #region [ Override ... ]

        /// <summary>
        /// OnPaint override.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!Visible || !IsHandleCreated) return;

            // Draw simple text, don't waste time with luxus render:
            e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;

            CalculateLocals();

            if (Orientation == Orientation.Horizontal)
                DrawHorizontal(e.Graphics);
            else
                DrawVertical(e.Graphics);

            base.OnPaint(e);
        }

        //protected override void OnMouseWheel(MouseEventArgs e)
        //{
        //    base.OnMouseWheel(e);

        //    this.Value++;

        //}



        //		public override string ToString()
        //		{
        //			return base.ToString() + ", Minimum: " + Minimum + ", Maximum: " + Maximum + ", Value: " + Value;
        //		}

        #endregion [ Override ]

        #region Private Methods

        //void TrackBarsScroll(object sender, EventArgs e)
        //{
        //    this.Value = Control.Value + trackBar2.Value / 10.0;
        //    label1.Text = this.Value.ToString();
        //}

        #endregion
    }

    #endregion

    #endregion
}
