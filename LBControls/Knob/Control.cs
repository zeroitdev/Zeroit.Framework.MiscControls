// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Control.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{


    #region Control
    /// <summary>
    /// Description of LBKnob.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitLBIndustrialCtrlBase" />
    public partial class ZeroitLBKnob : ZeroitLBIndustrialCtrlBase
    {
        #region *( Enumerators *)
        /// <summary>
        /// Enum representing the Knob Style
        /// </summary>
        public enum KnobStyle
        {
            /// <summary>
            /// The circular
            /// </summary>
            Circular = 0,
        }
        #endregion

        #region (* Properties variables *)
        /// <summary>
        /// The minimum value
        /// </summary>
        private float minValue = 0.0F;
        /// <summary>
        /// The maximum value
        /// </summary>
        private float maxValue = 1.0F;
        /// <summary>
        /// The step value
        /// </summary>
        private float stepValue = 0.1F;
        /// <summary>
        /// The curr value
        /// </summary>
        private float currValue = 0.0F;
        /// <summary>
        /// The knob rect
        /// </summary>
        private RectangleF knobRect = RectangleF.Empty;
        /// <summary>
        /// The knob center
        /// </summary>
        private PointF knobCenter = PointF.Empty;
        /// <summary>
        /// The style
        /// </summary>
        private KnobStyle style = KnobStyle.Circular;
        /// <summary>
        /// The scale color
        /// </summary>
        private Color scaleColor = Color.Green;
        /// <summary>
        /// The knob color
        /// </summary>
        private Color knobColor = Color.Black;
        /// <summary>
        /// The indicator color
        /// </summary>
        private Color indicatorColor = Color.Red;
        /// <summary>
        /// The indicator offset
        /// </summary>
        private float indicatorOffset = 10F;
        /// <summary>
        /// The draw ratio
        /// </summary>
        private float drawRatio = 1F;
        #endregion

        #region (* Class variables *)
        /// <summary>
        /// The is knob rotating
        /// </summary>
        private bool isKnobRotating = false;
        #endregion

        #region (* Constructor *)
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLBKnob"/> class.
        /// </summary>
        public ZeroitLBKnob()
        {
            InitializeComponent();

            this.CalculateDimensions();
        }
        #endregion

        #region (* Properties *)
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        [
            Category("Knob"),
            Description("Minimum value of the knob")
        ]
        public float MinValue
        {
            set
            {
                this.minValue = value;
                this.Invalidate();
            }
            get { return this.minValue; }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        [
            Category("Knob"),
            Description("Maximum value of the knob")
        ]
        public float MaxValue
        {
            set
            {
                this.maxValue = value;
                this.Invalidate();
            }
            get { return this.maxValue; }
        }

        /// <summary>
        /// Gets or sets the step value.
        /// </summary>
        /// <value>The step value.</value>
        [
            Category("Knob"),
            Description("Step value of the knob")
        ]
        public float StepValue
        {
            set
            {
                this.stepValue = value;
                this.Invalidate();
            }
            get { return this.stepValue; }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [
            Category("Knob"),
            Description("Current value of the knob")
        ]
        public float Value
        {
            set
            {
                if (value != this.currValue)
                {
                    this.currValue = value;
                    this.CalculateDimensions();
                    this.Invalidate();

                    ZeroitLBKnobEventArgs e = new ZeroitLBKnobEventArgs();
                    e.Value = this.currValue;
                    this.OnKnobChangeValue(e);

                    this.OnValueChanged(EventArgs.Empty);
                }
            }
            get { return this.currValue; }
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [
            Category("Knob"),
            Description("Style of the knob")
        ]
        public KnobStyle Style
        {
            set
            {
                this.style = value;
                this.Invalidate();
            }
            get { return this.style; }
        }

        /// <summary>
        /// Gets or sets the color of the knob.
        /// </summary>
        /// <value>The color of the knob.</value>
        [
            Category("Knob"),
            Description("Color of the knob")
        ]
        public Color KnobColor
        {
            set
            {
                this.knobColor = value;
                this.Invalidate();
            }
            get { return this.knobColor; }
        }

        /// <summary>
        /// Gets or sets the color of the scale.
        /// </summary>
        /// <value>The color of the scale.</value>
        [
            Category("Knob"),
            Description("Color of the scale")
        ]
        public Color ScaleColor
        {
            set
            {
                this.scaleColor = value;
                this.Invalidate();
            }
            get { return this.scaleColor; }
        }

        /// <summary>
        /// Gets or sets the color of the indicator.
        /// </summary>
        /// <value>The color of the indicator.</value>
        [
            Category("Knob"),
            Description("Color of the indicator")
        ]
        public Color IndicatorColor
        {
            set
            {
                this.indicatorColor = value;
                this.Invalidate();
            }
            get { return this.indicatorColor; }
        }

        /// <summary>
        /// Gets or sets the indicator offset.
        /// </summary>
        /// <value>The indicator offset.</value>
        [
            Category("Knob"),
            Description("Offset of the indicator from the kob border")
        ]
        public float IndicatorOffset
        {
            set
            {
                this.indicatorOffset = value;
                this.CalculateDimensions();
                this.Invalidate();
            }
            get { return this.indicatorOffset; }
        }

        /// <summary>
        /// Gets or sets the knob center.
        /// </summary>
        /// <value>The knob center.</value>
        [Browsable(false)]
        public PointF KnobCenter
        {
            set { this.knobCenter = value; }
            get { return this.knobCenter; }
        }

        /// <summary>
        /// Gets or sets the knob rect.
        /// </summary>
        /// <value>The knob rect.</value>
        [Browsable(false)]
        public RectangleF KnobRect
        {
            set { this.knobRect = value; }
            get { return this.knobRect; }
        }

        /// <summary>
        /// Gets or sets the draw ratio.
        /// </summary>
        /// <value>The draw ratio.</value>
        [Browsable(false)]
        public float DrawRatio
        {
            set { this.drawRatio = value; }
            get { return this.drawRatio; }
        }
        #endregion

        #region (* Events delegates *)

        /// <summary>
        /// Processes the command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>true if the character was processed by the control; otherwise, false.</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool blResult = true;

            /// <summary>
            /// Specified WM_KEYDOWN enumeration value.
            /// </summary>
            const int WM_KEYDOWN = 0x0100;

            /// <summary>
            /// Specified WM_SYSKEYDOWN enumeration value.
            /// </summary>
            const int WM_SYSKEYDOWN = 0x0104;

            float val = this.Value;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Up:
                        val += this.StepValue;
                        if (val <= this.MaxValue)
                            this.Value = val;
                        break;

                    case Keys.Down:
                        val -= this.StepValue;
                        if (val >= this.MinValue)
                            this.Value = val;
                        break;

                    case Keys.PageUp:
                        if (val < this.MaxValue)
                        {
                            val += (this.StepValue * 10);
                            this.Value = val;
                        }
                        break;

                    case Keys.PageDown:
                        if (val > this.MinValue)
                        {
                            val -= (this.StepValue * 10);
                            this.Value = val;
                        }
                        break;

                    case Keys.Home:
                        this.Value = this.MinValue;
                        break;

                    case Keys.End:
                        this.Value = this.MaxValue;
                        break;

                    default:
                        blResult = base.ProcessCmdKey(ref msg, keyData);
                        break;
                }
            }

            return blResult;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnClick(EventArgs e)
        {
            this.Focus();
            this.Invalidate();
            base.OnClick(e);
        }

        /// <summary>
        /// Handles the <see cref="E:MouseUp" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void OnMouseUp(object sender, MouseEventArgs e)
        {
            this.isKnobRotating = false;

            if (this.knobRect.Contains(e.Location) == false)
                return;

            float val = this.GetValueFromPosition(e.Location);
            if (val != this.Value)
            {
                this.Value = val;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (this.knobRect.Contains(e.Location) == false)
                return;

            this.isKnobRotating = true;

            this.Focus();
        }

        /// <summary>
        /// Handles the <see cref="E:MouseMove" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (this.isKnobRotating == false)
                return;

            float val = this.GetValueFromPosition(e.Location);
            if (val != this.Value)
            {
                this.Value = val;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Handles the <see cref="E:KeyDown" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        void OnKeyDown(object sender, KeyEventArgs e)
        {
            float val = this.Value;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    val = this.Value + this.StepValue;
                    break;

                case Keys.Down:
                    val = this.Value - this.StepValue;
                    break;
            }

            if (val < this.MinValue)
                val = this.MinValue;

            if (val > this.MaxValue)
                val = this.MaxValue;

            this.Value = val;
        }
        #endregion

        #region (* Virtual methods *)

        /// <summary>
        /// Gets the value from position.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>System.Single.</returns>
        public virtual float GetValueFromPosition(PointF position)
        {
            float degree = 0.0F;
            float v = 0.0F;

            PointF center = this.KnobCenter;

            if (position.X <= center.X)
            {
                degree = (center.Y - position.Y) / (center.X - position.X);
                degree = (float)Math.Atan(degree);
                degree = (float)((degree) * (180F / Math.PI) + 45F);
                v = (degree * (this.MaxValue - this.MinValue) / 270F);
            }
            else
            {
                if (position.X > center.X)
                {
                    degree = (position.Y - center.Y) / (position.X - center.X);
                    degree = (float)Math.Atan(degree);
                    degree = (float)(225F + (degree) * (180F / Math.PI));
                    v = (degree * (this.MaxValue - this.MinValue) / 270F);
                }
            }

            if (v > this.MaxValue)
                v = this.MaxValue;

            if (v < this.MinValue)
                v = this.MinValue;

            return v;
        }

        /// <summary>
        /// Gets the position from value.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>PointF.</returns>
        public virtual PointF GetPositionFromValue(float val)
        {
            PointF pos = new PointF(0.0F, 0.0F);

            // Elimina la divisione per 0
            if ((this.MaxValue - this.MinValue) == 0)
                return pos;

            float _indicatorOffset = this.IndicatorOffset * this.drawRatio;

            float degree = 270F * val / (this.MaxValue - this.MinValue);
            degree = (degree + 135F) * (float)Math.PI / 180F;

            pos.X = (int)(Math.Cos(degree) * ((this.knobRect.Width * 0.5F) - indicatorOffset) + this.knobRect.X + (this.knobRect.Width * 0.5F));
            pos.Y = (int)(Math.Sin(degree) * ((this.knobRect.Width * 0.5F) - indicatorOffset) + this.knobRect.Y + (this.knobRect.Height * 0.5F));
            return pos;
        }

        #endregion

        #region (* Fire events *)
        /// <summary>
        /// Occurs when [knob change value].
        /// </summary>
        public event KnobChangeValue KnobChangeValue;
        /// <summary>
        /// Handles the <see cref="E:KnobChangeValue" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ZeroitLBKnobEventArgs"/> instance containing the event data.</param>
        protected virtual void OnKnobChangeValue(ZeroitLBKnobEventArgs e)
        {
            if (this.KnobChangeValue != null)
                this.KnobChangeValue(this, e);
        }





        #region Event Creation

        /////Implement this in the Property you want to trigger the event///////////////////////////
        // 
        //  For Example this will be triggered by the Value Property
        //
        //  public int Value
        //   { 
        //      get { return _value;}
        //      set
        //         {
        //          
        //              _value = value;
        //
        //              this.OnValueChanged(EventArgs.Empty);
        //              Invalidate();
        //          }
        //    }
        //
        ////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// The on value changed
        /// </summary>
        private EventHandler onValueChanged;

        /// <summary>
        /// Triggered when the Value changes
        /// </summary>

        public event EventHandler ValueChanged
        {
            add
            {
                this.onValueChanged = this.onValueChanged + value;
            }
            remove
            {
                this.onValueChanged = this.onValueChanged - value;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:ValueChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (this.onValueChanged == null)
                return;
            this.onValueChanged((object)this, e);
        }

        #endregion




        #endregion

        #region (* Overrided method *)
        /// <summary>
        /// Call from the constructor to create the default renderer
        /// </summary>
        /// <returns>ILBRenderer.</returns>
        protected override ILBRenderer CreateDefaultRenderer()
        {
            return new ZeroitLBKnobRenderer();
        }
        #endregion
    }

    #region (* Classes for event and event delagates args *)

    #region (* Event args class *)
    /// <summary>
    /// Class for events delegates
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ZeroitLBKnobEventArgs : EventArgs
    {
        /// <summary>
        /// The value
        /// </summary>
        private float val;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLBKnobEventArgs"/> class.
        /// </summary>
        public ZeroitLBKnobEventArgs()
        {
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public float Value
        {
            get { return this.val; }
            set { this.val = value; }
        }
    }
    #endregion

    #region (* Delegates *)
    /// <summary>
    /// Delegate KnobChangeValue
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="ZeroitLBKnobEventArgs"/> instance containing the event data.</param>
    public delegate void KnobChangeValue(object sender, ZeroitLBKnobEventArgs e);
    #endregion

    #endregion
    #endregion

    #region Designer
    partial class ZeroitLBKnob
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
            this.SuspendLayout();
            // 
            // LBKnob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LBKnob";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.ResumeLayout(false);
        }
    }
    #endregion



}
