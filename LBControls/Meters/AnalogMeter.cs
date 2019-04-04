// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AnalogMeter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.MiscControls
{

    #region LBAnalog Meter

    #region Control
    /// <summary>
    /// A class collection for rendering the analog meter control
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitLBIndustrialCtrlBase" />
	public partial class ZeroitLBAnalogMeter : ZeroitLBIndustrialCtrlBase
    {
        #region (* Enumerator *)
        /// <summary>
        /// Enum representing the Analog Meter Style
        /// </summary>
        public enum AnalogMeterStyle
        {
            /// <summary>
            /// The circular
            /// </summary>
            Circular = 0,
        };
        #endregion

        #region (* Properties variables *)
        /// <summary>
        /// The meter style
        /// </summary>
        private AnalogMeterStyle meterStyle;
        /// <summary>
        /// The body color
        /// </summary>
        private Color bodyColor;
        /// <summary>
        /// The needle color
        /// </summary>
        private Color needleColor;
        /// <summary>
        /// The scale color
        /// </summary>
        private Color scaleColor;
        /// <summary>
        /// The view glass
        /// </summary>
        private bool viewGlass;
        /// <summary>
        /// The curr value
        /// </summary>
        private double currValue;
        /// <summary>
        /// The minimum value
        /// </summary>
        private double minValue;
        /// <summary>
        /// The maximum value
        /// </summary>
        private double maxValue;
        /// <summary>
        /// The scale divisions
        /// </summary>
        private int scaleDivisions;
        /// <summary>
        /// The scale sub divisions
        /// </summary>
        private int scaleSubDivisions;
        /// <summary>
        /// The list threshold
        /// </summary>
        private ZeroitLBMeterThresholdCollection listThreshold;
        #endregion

        #region (* Class variables *)
        /// <summary>
        /// The start angle
        /// </summary>
        protected float startAngle;
        /// <summary>
        /// The end angle
        /// </summary>
        protected float endAngle;
        #endregion

        #region (* Costructors *)
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLBAnalogMeter"/> class.
        /// </summary>
        public ZeroitLBAnalogMeter()
        {
            // Initialization
            InitializeComponent();

            // Properties initialization
            this.bodyColor = Color.Red;
            this.needleColor = Color.Yellow;
            this.scaleColor = Color.White;
            this.meterStyle = AnalogMeterStyle.Circular;
            this.viewGlass = false;
            this.startAngle = 135;
            this.endAngle = 405;
            this.minValue = 0;
            this.maxValue = 1;
            this.currValue = 0;
            this.scaleDivisions = 10;
            this.scaleSubDivisions = 10;

            // Create the sector list
            this.listThreshold = new ZeroitLBMeterThresholdCollection();

            this.CalculateDimensions();
        }
        #endregion

        #region (* Properties *)        
        /// <summary>
        /// Gets or sets the meter style.
        /// </summary>
        /// <value>The meter style.</value>
        [
            Category("Analog Meter"),
            Description("Style of the control")
        ]
        public AnalogMeterStyle MeterStyle
        {
            get { return meterStyle; }
            set
            {
                meterStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the body.
        /// </summary>
        /// <value>The color of the body.</value>
        [
            Category("Analog Meter"),
            Description("Color of the body of the control")
        ]
        public Color BodyColor
        {
            get { return bodyColor; }
            set
            {
                bodyColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the needle.
        /// </summary>
        /// <value>The color of the needle.</value>
        [
            Category("Analog Meter"),
            Description("Color of the needle")
        ]
        public Color NeedleColor
        {
            get { return needleColor; }
            set
            {
                needleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show or hide glass effect.
        /// </summary>
        /// <value><c>true</c> if view glass; otherwise, <c>false</c>.</value>
        [
            Category("Analog Meter"),
            Description("Show or hide the glass effect")
        ]
        public bool ViewGlass
        {
            get { return viewGlass; }
            set
            {
                viewGlass = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the scale.
        /// </summary>
        /// <value>The color of the scale.</value>
        [
            Category("Analog Meter"),
            Description("Color of the scale of the control")
        ]
        public Color ScaleColor
        {
            get { return scaleColor; }
            set
            {
                scaleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [
            Category("Analog Meter"),
            Description("Value of the data")
        ]
        public double Value
        {
            get { return currValue; }
            set
            {
                double val = value;
                if (val > maxValue)
                    val = maxValue;

                if (val < minValue)
                    val = minValue;

                currValue = val;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        [
            Category("Analog Meter"),
            Description("Minimum value of the data")
        ]
        public double MinValue
        {
            get { return minValue; }
            set
            {
                minValue = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        [
            Category("Analog Meter"),
            Description("Maximum value of the data")
        ]
        public double MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the scale divisions.
        /// </summary>
        /// <value>The scale divisions.</value>
        [
            Category("Analog Meter"),
            Description("Number of the scale divisions")
        ]
        public int ScaleDivisions
        {
            get { return scaleDivisions; }
            set
            {
                scaleDivisions = value;
                this.CalculateDimensions();
            }
        }

        /// <summary>
        /// Gets or sets the scale sub divisions.
        /// </summary>
        /// <value>The scale sub divisions.</value>
        [
            Category("Analog Meter"),
            Description("Number of the scale subdivisions")
        ]
        public int ScaleSubDivisions
        {
            get { return scaleSubDivisions; }
            set
            {
                scaleSubDivisions = value;
                this.CalculateDimensions();
            }
        }

        /// <summary>
        /// Gets the thresholds.
        /// </summary>
        /// <value>The thresholds.</value>
        [Browsable(false)]
        public ZeroitLBMeterThresholdCollection Thresholds
        {
            get { return this.listThreshold; }
        }
        #endregion

        #region (* Public methods *)
        /// <summary>
        /// Gets the start angle.
        /// </summary>
        /// <returns>System.Single.</returns>
        public float GetStartAngle()
        {
            return this.startAngle;
        }

        /// <summary>
        /// Gets the end angle.
        /// </summary>
        /// <returns>System.Single.</returns>
        public float GetEndAngle()
        {
            return this.endAngle;
        }
        #endregion

        #region (* Overrided methods *)
        /// <summary>
        /// Call from the constructor to create the default renderer
        /// </summary>
        /// <returns>ILBRenderer.</returns>
        protected override ILBRenderer CreateDefaultRenderer()
        {
            return new ZeroitLBAnalogMeterRenderer();
        }
        #endregion
    }
    #endregion

    #region Designer Generated
    public partial class ZeroitLBAnalogMeter
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // UserControl1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LBAnalogMeter";
        }
    }
    #endregion

    #region LBAnalog Meter Renderer
    /// <summary>
    /// Base class for the renderers of the analog meter
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitLBRendererBase" />
	public class ZeroitLBAnalogMeterRenderer : ZeroitLBRendererBase
    {
        #region (* Variables *)
        /// <summary>
        /// The needle center
        /// </summary>
        protected PointF needleCenter;
        /// <summary>
        /// The draw rect
        /// </summary>
        protected RectangleF drawRect;
        /// <summary>
        /// The glossy rect
        /// </summary>
        protected RectangleF glossyRect;
        /// <summary>
        /// The needle cover rect
        /// </summary>
        protected RectangleF needleCoverRect;
        /// <summary>
        /// The draw ratio
        /// </summary>
        protected float drawRatio;
        #endregion

        #region (* Properties *)
        /// <summary>
        /// Gets the analog meter.
        /// </summary>
        /// <value>The analog meter.</value>
        public ZeroitLBAnalogMeter AnalogMeter
        {
            get { return this.Control as ZeroitLBAnalogMeter; }
        }
        #endregion

        #region (* Overrided method *)
        /// <summary>
        /// Update the renderer
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.NullReferenceException">Invalid 'AnalogMeter' object</exception>
        public override bool Update()
        {
            // Check Button object
            if (this.AnalogMeter == null)
                throw new NullReferenceException("Invalid 'AnalogMeter' object");

            // Rectangle
            float x, y, w, h;
            x = 0;
            y = 0;
            w = this.AnalogMeter.Size.Width;
            h = this.AnalogMeter.Size.Height;

            // Calculate ratio
            drawRatio = (Math.Min(w, h)) / 200;
            if (drawRatio == 0.0)
                drawRatio = 1;

            // Draw rectangle
            drawRect.X = x;
            drawRect.Y = y;
            drawRect.Width = w - 2;
            drawRect.Height = h - 2;

            if (w < h)
                drawRect.Height = w;
            else if (w > h)
                drawRect.Width = h;

            if (drawRect.Width < 10)
                drawRect.Width = 10;
            if (drawRect.Height < 10)
                drawRect.Height = 10;

            // Calculate needle center
            needleCenter.X = drawRect.X + (drawRect.Width / 2);
            needleCenter.Y = drawRect.Y + (drawRect.Height / 2);

            // Needle cover rect
            needleCoverRect.X = needleCenter.X - (20 * drawRatio);
            needleCoverRect.Y = needleCenter.Y - (20 * drawRatio);
            needleCoverRect.Width = 40 * drawRatio;
            needleCoverRect.Height = 40 * drawRatio;

            // Glass effect rect
            glossyRect.X = drawRect.X + (20 * drawRatio);
            glossyRect.Y = drawRect.Y + (10 * drawRatio);
            glossyRect.Width = drawRect.Width - (40 * drawRatio);
            glossyRect.Height = needleCenter.Y + (30 * drawRatio);

            return false;
        }

        /// <summary>
        /// Drawing method
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <exception cref="System.ArgumentNullException">Gr</exception>
        /// <exception cref="System.NullReferenceException">Associated control is not valid</exception>
        public override void Draw(Graphics Gr)
        {
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            ZeroitLBAnalogMeter ctrl = this.AnalogMeter;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            this.DrawBackground(Gr, ctrl.Bounds);
            this.DrawBody(Gr, drawRect);
            this.DrawThresholds(Gr, drawRect);
            this.DrawDivisions(Gr, drawRect);
            this.DrawUM(Gr, drawRect);
            this.DrawValue(Gr, drawRect);
            this.DrawNeedle(Gr, drawRect);
            this.DrawNeedleCover(Gr, this.needleCoverRect);
            this.DrawGlass(Gr, this.glossyRect);
        }
        #endregion

        #region (* Virtual method *)
        /// <summary>
        /// Draws the background.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DrawBackground(Graphics gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            Color c = this.AnalogMeter.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.AnalogMeter.Width, this.AnalogMeter.Height);
            gr.DrawRectangle(pen, _rcTmp);
            gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }

        /// <summary>
        /// Draws the body.
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DrawBody(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            Color bodyColor = this.AnalogMeter.BodyColor;
            Color cDark = ZeroitLBColorManager.StepColor(bodyColor, 20);

            LinearGradientBrush br1 = new LinearGradientBrush(rc,
                                                               bodyColor,
                                                               cDark,
                                                               45);
            Gr.FillEllipse(br1, rc);

            RectangleF _rc = rc;
            _rc.X += 3 * drawRatio;
            _rc.Y += 3 * drawRatio;
            _rc.Width -= 6 * drawRatio;
            _rc.Height -= 6 * drawRatio;

            LinearGradientBrush br2 = new LinearGradientBrush(_rc,
                                                               cDark,
                                                               bodyColor,
                                                               45);
            Gr.FillEllipse(br2, _rc);

            return true;
        }

        /// <summary>
        /// Draws the thresholds.
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DrawThresholds(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            RectangleF _rc = rc;
            _rc.Inflate(-18F * drawRatio, -18F * drawRatio);

            double w = _rc.Width;
            double radius = w / 2 - (w * 0.075);

            float startAngle = this.AnalogMeter.GetStartAngle();
            float endAngle = this.AnalogMeter.GetEndAngle();
            float rangeAngle = endAngle - startAngle;
            float minValue = (float)this.AnalogMeter.MinValue;
            float maxValue = (float)this.AnalogMeter.MaxValue;

            double stepVal = rangeAngle / (maxValue - minValue);

            foreach (ZeroitLBMeterThreshold sect in this.AnalogMeter.Thresholds)
            {

                float startPathAngle = ((float)(startAngle + (stepVal * sect.StartValue)));
                float endPathAngle = ((float)((stepVal * (sect.EndValue - sect.StartValue))));

                GraphicsPath pth = new GraphicsPath();
                pth.AddArc(_rc, startPathAngle, endPathAngle);

                Pen pen = new Pen(sect.Color, 4.5F * drawRatio);

                Gr.DrawPath(pen, pth);

                pen.Dispose();
                pth.Dispose();
            }

            return false;
        }

        /// <summary>
        /// Draws the divisions.
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DrawDivisions(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            float startAngle = this.AnalogMeter.GetStartAngle();
            float endAngle = this.AnalogMeter.GetEndAngle();
            float scaleDivisions = this.AnalogMeter.ScaleDivisions;
            float scaleSubDivisions = this.AnalogMeter.ScaleSubDivisions;
            double minValue = this.AnalogMeter.MinValue;
            double maxValue = this.AnalogMeter.MaxValue;
            Color scaleColor = this.AnalogMeter.ScaleColor;

            float cx = needleCenter.X;
            float cy = needleCenter.Y;
            float w = rc.Width;
            float h = rc.Height;

            float incr = ZeroitLBMath.GetRadian((endAngle - startAngle) / ((scaleDivisions - 1) * (scaleSubDivisions + 1)));
            float currentAngle = ZeroitLBMath.GetRadian(startAngle);
            float radius = (float)(w / 2 - (w * 0.08));
            float rulerValue = (float)minValue;

            Pen pen = new Pen(scaleColor, (1 * drawRatio));
            SolidBrush br = new SolidBrush(scaleColor);

            PointF ptStart = new PointF(0, 0);
            PointF ptEnd = new PointF(0, 0);
            int n = 0;
            for (; n < scaleDivisions; n++)
            {
                //Draw Thick Line
                ptStart.X = (float)(cx + radius * Math.Cos(currentAngle));
                ptStart.Y = (float)(cy + radius * Math.Sin(currentAngle));
                ptEnd.X = (float)(cx + (radius - w / 20) * Math.Cos(currentAngle));
                ptEnd.Y = (float)(cy + (radius - w / 20) * Math.Sin(currentAngle));
                Gr.DrawLine(pen, ptStart, ptEnd);

                //Draw Strings
                Font font = new Font(this.AnalogMeter.Font.FontFamily, (float)(6F * drawRatio));

                float tx = (float)(cx + (radius - (20 * drawRatio)) * Math.Cos(currentAngle));
                float ty = (float)(cy + (radius - (20 * drawRatio)) * Math.Sin(currentAngle));
                double val = Math.Round(rulerValue);
                String str = String.Format("{0,0:D}", (int)val);

                SizeF size = Gr.MeasureString(str, font);
                Gr.DrawString(str,
                                font,
                                br,
                                tx - (float)(size.Width * 0.5),
                                ty - (float)(size.Height * 0.5));

                rulerValue += (float)((maxValue - minValue) / (scaleDivisions - 1));

                if (n == scaleDivisions - 1)
                {
                    font.Dispose();
                    break;
                }

                if (scaleDivisions <= 0)
                    currentAngle += incr;
                else
                {
                    for (int j = 0; j <= scaleSubDivisions; j++)
                    {
                        currentAngle += incr;
                        ptStart.X = (float)(cx + radius * Math.Cos(currentAngle));
                        ptStart.Y = (float)(cy + radius * Math.Sin(currentAngle));
                        ptEnd.X = (float)(cx + (radius - w / 50) * Math.Cos(currentAngle));
                        ptEnd.Y = (float)(cy + (radius - w / 50) * Math.Sin(currentAngle));
                        Gr.DrawLine(pen, ptStart, ptEnd);
                    }
                }

                font.Dispose();
            }

            return true;
        }

        /// <summary>
        /// Draws the um.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DrawUM(Graphics gr, RectangleF rc)
        {
            return false;
        }

        /// <summary>
        /// Draws the value.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DrawValue(Graphics gr, RectangleF rc)
        {
            return false;
        }

        /// <summary>
        /// Draws the needle.
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DrawNeedle(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            float w, h;
            w = rc.Width;
            h = rc.Height;

            double minValue = this.AnalogMeter.MinValue;
            double maxValue = this.AnalogMeter.MaxValue;
            double currValue = this.AnalogMeter.Value;
            float startAngle = this.AnalogMeter.GetStartAngle();
            float endAngle = this.AnalogMeter.GetEndAngle();

            float radius = (float)(w / 2 - (w * 0.12));
            float val = (float)(maxValue - minValue);

            val = (float)((100 * (currValue - minValue)) / val);
            val = ((endAngle - startAngle) * val) / 100;
            val += startAngle;

            float angle = ZeroitLBMath.GetRadian(val);

            float cx = needleCenter.X;
            float cy = needleCenter.Y;

            PointF ptStart = new PointF(0, 0);
            PointF ptEnd = new PointF(0, 0);

            GraphicsPath pth1 = new GraphicsPath();

            ptStart.X = cx;
            ptStart.Y = cy;
            angle = ZeroitLBMath.GetRadian(val + 10);
            ptEnd.X = (float)(cx + (w * .09F) * Math.Cos(angle));
            ptEnd.Y = (float)(cy + (w * .09F) * Math.Sin(angle));
            pth1.AddLine(ptStart, ptEnd);

            ptStart = ptEnd;
            angle = ZeroitLBMath.GetRadian(val);
            ptEnd.X = (float)(cx + radius * Math.Cos(angle));
            ptEnd.Y = (float)(cy + radius * Math.Sin(angle));
            pth1.AddLine(ptStart, ptEnd);

            ptStart = ptEnd;
            angle = ZeroitLBMath.GetRadian(val - 10);
            ptEnd.X = (float)(cx + (w * .09F) * Math.Cos(angle));
            ptEnd.Y = (float)(cy + (w * .09F) * Math.Sin(angle));
            pth1.AddLine(ptStart, ptEnd);

            pth1.CloseFigure();

            SolidBrush br = new SolidBrush(this.AnalogMeter.NeedleColor);
            Pen pen = new Pen(this.AnalogMeter.NeedleColor);
            Gr.DrawPath(pen, pth1);
            Gr.FillPath(br, pth1);

            return true;
        }

        /// <summary>
        /// Draws the needle cover.
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DrawNeedleCover(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            Color clr = this.AnalogMeter.NeedleColor;
            RectangleF _rc = rc;

            Color clr1 = Color.FromArgb(70, clr);

            _rc.Inflate(5 * drawRatio, 5 * drawRatio);

            SolidBrush brTransp = new SolidBrush(clr1);
            Gr.FillEllipse(brTransp, _rc);

            clr1 = clr;
            Color clr2 = ZeroitLBColorManager.StepColor(clr, 75);
            LinearGradientBrush br1 = new LinearGradientBrush(rc,
                                                               clr1,
                                                               clr2,
                                                               45);
            Gr.FillEllipse(br1, rc);
            return true;
        }

        /// <summary>
        /// Draws the glass.
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DrawGlass(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogMeter == null)
                return false;

            if (this.AnalogMeter.ViewGlass == false)
                return true;

            Color clr1 = Color.FromArgb(40, 200, 200, 200);

            Color clr2 = Color.FromArgb(0, 200, 200, 200);
            LinearGradientBrush br1 = new LinearGradientBrush(rc,
                                                               clr1,
                                                               clr2,
                                                               45);
            Gr.FillEllipse(br1, rc);

            return true;
        }
        #endregion
    }
    #endregion

    #endregion


}
