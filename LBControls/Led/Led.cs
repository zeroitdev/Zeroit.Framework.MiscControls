// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Led.cs" company="Zeroit Dev Technologies">
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

    #region LBLed

    #region Control
    /// <summary>
    /// A class for rendering a Led control.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitLBIndustrialCtrlBase" />
    public partial class ZeroitLBLed : ZeroitLBIndustrialCtrlBase
    {
        #region (* Enumeratives *)
        /// <summary>
        /// Enum representing the Led's State
        /// </summary>
        public enum LedState
        {
            /// <summary>
            /// The off
            /// </summary>
            Off = 0,
            /// <summary>
            /// The on
            /// </summary>
            On,
            /// <summary>
            /// The blink
            /// </summary>
            Blink,
        }

        /// <summary>
        /// Enum representing the text position
        /// </summary>
        public enum LedLabelPosition
        {
            /// <summary>
            /// The left
            /// </summary>
            Left = 0,
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
        }

        /// <summary>
        /// Enum representing the Led Style
        /// </summary>
        public enum LedStyle
        {
            /// <summary>
            /// The circular
            /// </summary>
            Circular = 0,
            /// <summary>
            /// The rectangular
            /// </summary>
            Rectangular,
        }

        #endregion

        #region (* Properties variables *)
        /// <summary>
        /// The led color
        /// </summary>
        private Color ledColor;
        /// <summary>
        /// The state
        /// </summary>
        private LedState state;
        /// <summary>
        /// The style
        /// </summary>
        private LedStyle style;
        /// <summary>
        /// The label position
        /// </summary>
        private LedLabelPosition labelPosition;
        /// <summary>
        /// The label
        /// </summary>
        private String label = "Led";
        /// <summary>
        /// The led size
        /// </summary>
        private SizeF ledSize;
        /// <summary>
        /// The blink interval
        /// </summary>
        private int blinkInterval = 500;
        #endregion

        #region (* Class variables *)
        /// <summary>
        /// The TMR blink
        /// </summary>
        private System.Windows.Forms.Timer tmrBlink;
        /// <summary>
        /// The blink is on
        /// </summary>
        private bool blinkIsOn = false;
        #endregion

        #region (* Constructor *)
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLBLed"/> class.
        /// </summary>
        public ZeroitLBLed()
        {
            InitializeComponent();

            this.Size = new Size(20, 20);
            this.ledColor = Color.Red;
            this.state = ZeroitLBLed.LedState.Off;
            this.style = ZeroitLBLed.LedStyle.Circular;
            this.blinkIsOn = false;
            this.ledSize = new SizeF(10F, 10F);
            this.labelPosition = LedLabelPosition.Top;
        }
        #endregion

        #region (* Properties *)        
        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [
            Category("Led"),
            Description("Style of the led")
        ]
        public LedStyle Style
        {
            get { return style; }
            set
            {
                style = value;
                this.CalculateDimensions();
            }
        }

        /// <summary>
        /// Gets or sets the color of the led.
        /// </summary>
        /// <value>The color of the led.</value>
        [
            Category("Led"),
            Description("Color of the led")
        ]
        public Color LedColor
        {
            get { return ledColor; }
            set
            {
                ledColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the state of the led.
        /// </summary>
        /// <value>The state.</value>
        [
            Category("Led"),
            Description("State of the led")
        ]
        public LedState State
        {
            get { return state; }
            set
            {
                state = value;
                if (state == LedState.Blink)
                {
                    this.blinkIsOn = true;
                    this.tmrBlink.Interval = this.BlinkInterval;
                    this.tmrBlink.Start();
                }
                else
                {
                    this.blinkIsOn = true;
                    this.tmrBlink.Stop();
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the led.
        /// </summary>
        /// <value>The size of the led.</value>
        [
            Category("Led"),
            Description("Size of the led")
        ]
        public SizeF LedSize
        {
            get { return this.ledSize; }
            set
            {
                this.ledSize = value;
                this.CalculateDimensions();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [
            Category("Led"),
            Description("Label of the led")
        ]
        public String Label
        {
            get { return this.label; }
            set
            {
                this.label = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text position.
        /// </summary>
        /// <value>The text position.</value>
        [
            Category("Led"),
            Description("Position of the label of the led")
        ]
        public LedLabelPosition LabelPosition
        {
            get { return this.labelPosition; }
            set
            {
                this.labelPosition = value;
                this.CalculateDimensions();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the blink interval.
        /// </summary>
        /// <value>The blink interval.</value>
        [
            Category("Led"),
            Description("Interval for the blink state of the led")
        ]
        public int BlinkInterval
        {
            get { return this.blinkInterval; }
            set { this.blinkInterval = value; }
        }

        /// <summary>
        /// Gets a value indicating whether the blink should be activated.
        /// </summary>
        /// <value><c>true</c> if blink is on; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool BlinkIsOn
        {
            get { return this.blinkIsOn; }
        }
        #endregion

        #region (* Events delegates *)
        /// <summary>
        /// Handles the <see cref="E:Blink" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void OnBlink(object sender, EventArgs e)
        {
            if (this.State == LedState.Blink)
            {
                if (this.blinkIsOn == false)
                    this.blinkIsOn = true;
                else
                    this.blinkIsOn = false;

                this.Invalidate();
            }
        }
        #endregion

        #region (* Overrided methods *)
        /// <summary>
        /// Call from the constructor to create the default renderer
        /// </summary>
        /// <returns>ILBRenderer.</returns>
        protected override ILBRenderer CreateDefaultRenderer()
        {
            return new ZeroitLBLedRenderer();
        }
        #endregion
    }
    #endregion

    #region Designer Generated
    public partial class ZeroitLBLed
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the control.
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
            this.components = new System.ComponentModel.Container();
            this.tmrBlink = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrBlink
            // 
            this.tmrBlink.Interval = 500;
            this.tmrBlink.Tick += new System.EventHandler(this.OnBlink);
            // 
            // LBLed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LBLed";
            this.ResumeLayout(false);
        }
    }
    #endregion

    #region LBLedRenderer

    /// <summary>
    /// Base class for the led renderers
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitLBRendererBase" />
    public class ZeroitLBLedRenderer : ZeroitLBRendererBase
    {
        #region (* Variables *)
        /// <summary>
        /// The draw rect
        /// </summary>
        private RectangleF drawRect;
        /// <summary>
        /// The rect led
        /// </summary>
        private RectangleF rectLed;
        /// <summary>
        /// The rect label
        /// </summary>
        private RectangleF rectLabel;
        #endregion

        #region (* Properies *)
        /// <summary>
        /// Get the associated led object
        /// </summary>
        /// <value>The led.</value>
        public ZeroitLBLed Led
        {
            get { return this.Control as ZeroitLBLed; }
        }
        #endregion

        #region (* Overrided method *)
        /// <summary>
        /// Update the rectangles for drawing
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.NullReferenceException">Invalid 'Led' object</exception>
        public override bool Update()
        {
            // Check Led object
            if (this.Led == null)
                throw new NullReferenceException("Invalid 'Led' object");

            // Dati del rettangolo
            float x, y, w, h;
            x = 0;
            y = 0;
            w = this.Led.Size.Width;
            h = this.Led.Size.Height;

            // Rettangolo di disegno
            drawRect.X = x;
            drawRect.Y = y;
            drawRect.Width = w - 2;
            drawRect.Height = h - 2;
            if (drawRect.Width <= 0)
                drawRect.Width = 20;
            if (drawRect.Height <= 0)
                drawRect.Height = 20;

            this.rectLed = drawRect;
            this.rectLabel = drawRect;

            if (this.Led.LabelPosition == ZeroitLBLed.LedLabelPosition.Bottom)
            {
                this.rectLed.X = (this.rectLed.Width * 0.5F) - (this.Led.LedSize.Width * 0.5F);
                this.rectLed.Width = this.Led.LedSize.Width;
                this.rectLed.Height = this.Led.LedSize.Height;

                this.rectLabel.Y = this.rectLed.Bottom;
            }

            else if (this.Led.LabelPosition == ZeroitLBLed.LedLabelPosition.Top)
            {
                this.rectLed.X = (this.rectLed.Width * 0.5F) - (this.Led.LedSize.Width * 0.5F);
                this.rectLed.Y = this.rectLed.Height - this.Led.LedSize.Height;
                this.rectLed.Width = this.Led.LedSize.Width;
                this.rectLed.Height = this.Led.LedSize.Height;

                this.rectLabel.Height = this.rectLed.Top;
            }

            else if (this.Led.LabelPosition == ZeroitLBLed.LedLabelPosition.Left)
            {
                this.rectLed.X = this.rectLed.Width - this.Led.LedSize.Width;
                this.rectLed.Width = this.Led.LedSize.Width;
                this.rectLed.Height = this.Led.LedSize.Height;

                this.rectLabel.Width = this.rectLabel.Width - this.rectLed.Width;
            }

            else if (this.Led.LabelPosition == ZeroitLBLed.LedLabelPosition.Right)
            {
                this.rectLed.Width = this.Led.LedSize.Width;
                this.rectLed.Height = this.Led.LedSize.Height;

                this.rectLabel.X = this.rectLed.Right;
            }

            return true;
        }

        /// <summary>
        /// Draw the led object
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <exception cref="System.ArgumentNullException">Gr</exception>
        /// <exception cref="System.NullReferenceException">Associated control is not valid</exception>
        public override void Draw(Graphics Gr)
        {
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            ZeroitLBLed ctrl = this.Led;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            Rectangle rc = ctrl.Bounds;

            this.DrawBackground(Gr, rc);

            if (this.rectLed.Width <= 0)
                this.rectLed.Width = rectLabel.Width;
            if (this.rectLed.Height <= 0)
                this.rectLed.Height = ctrl.LedSize.Height;

            this.DrawLed(Gr, this.rectLed);

            this.DrawLabel(Gr, this.rectLabel);
        }
        #endregion

        #region (* Virtual method *)
        /// <summary>
        /// Draw the background of the control
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public virtual bool DrawBackground(Graphics Gr, RectangleF rc)
        {
            if (this.Led == null)
                return false;

            Color c = this.Led.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.Led.Width, this.Led.Height);
            Gr.DrawRectangle(pen, _rcTmp);
            Gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }

        /// <summary>
        /// Draw the body of the control
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DrawLed(Graphics Gr, RectangleF rc)
        {
            if (this.Led == null)
                return false;

            Color cDarkOff = ZeroitLBColorManager.StepColor(Color.LightGray, 20);
            Color cDarkOn = ZeroitLBColorManager.StepColor(this.Led.LedColor, 60);

            LinearGradientBrush brOff = new LinearGradientBrush(rc,
                                                                     Color.Gray,
                                                                     cDarkOff,
                                                                  45);

            LinearGradientBrush brOn = new LinearGradientBrush(rc,
                                                                   this.Led.LedColor,
                                                                   cDarkOn,
                                                                   45);
            if (this.Led.State == ZeroitLBLed.LedState.Blink)
            {
                if (this.Led.BlinkIsOn == false)
                {
                    if (this.Led.Style == ZeroitLBLed.LedStyle.Circular)
                        Gr.FillEllipse(brOff, rc);
                    else if (this.Led.Style == ZeroitLBLed.LedStyle.Rectangular)
                        Gr.FillRectangle(brOff, rc);
                }
                else
                {
                    if (this.Led.Style == ZeroitLBLed.LedStyle.Circular)
                        Gr.FillEllipse(brOn, rc);
                    else if (this.Led.Style == ZeroitLBLed.LedStyle.Rectangular)
                        Gr.FillRectangle(brOn, rc);
                }
            }
            else
            {
                if (this.Led.State == ZeroitLBLed.LedState.Off)
                {
                    if (this.Led.Style == ZeroitLBLed.LedStyle.Circular)
                        Gr.FillEllipse(brOff, rc);
                    else if (this.Led.Style == ZeroitLBLed.LedStyle.Rectangular)
                        Gr.FillRectangle(brOff, rc);
                }
                else
                {
                    if (this.Led.Style == ZeroitLBLed.LedStyle.Circular)
                        Gr.FillEllipse(brOn, rc);
                    else if (this.Led.Style == ZeroitLBLed.LedStyle.Rectangular)
                        Gr.FillRectangle(brOn, rc);
                }
            }

            brOff.Dispose();
            brOn.Dispose();

            return true;
        }

        /// <summary>
        /// Draw the text of the control
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DrawLabel(Graphics Gr, RectangleF rc)
        {
            if (this.Led == null)
                return false;

            if (this.Led.Label == String.Empty)
                return false;

            SizeF size = Gr.MeasureString(this.Led.Label, this.Led.Font);

            SolidBrush br1 = new SolidBrush(this.Led.ForeColor);

            float hPos = 0;
            float vPos = 0;
            switch (this.Led.LabelPosition)
            {
                case ZeroitLBLed.LedLabelPosition.Top:
                    hPos = (float)(rc.Width * 0.5F) - (float)(size.Width * 0.5F);
                    vPos = rc.Bottom - size.Height;
                    break;

                case ZeroitLBLed.LedLabelPosition.Bottom:
                    hPos = (float)(rc.Width * 0.5F) - (float)(size.Width * 0.5F);
                    break;

                case ZeroitLBLed.LedLabelPosition.Left:
                    hPos = rc.Width - size.Width;
                    vPos = (float)(rc.Height * 0.5F) - (float)(size.Height * 0.5F);
                    break;

                case ZeroitLBLed.LedLabelPosition.Right:
                    vPos = (float)(rc.Height * 0.5F) - (float)(size.Height * 0.5F);
                    break;
            }

            Gr.DrawString(this.Led.Label,
                            this.Led.Font,
                            br1,
                            rc.Left + hPos,
                            rc.Top + vPos);

            return true;
        }
        #endregion
    }

    #endregion

    #endregion


}
