// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="DigitalMeter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region LBDigital Meter

    #region Control
    /// <summary>
    /// A class collection for rendering a digital meter
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitLBIndustrialCtrlBase" />
    public partial class ZeroitLBDigitalMeter : ZeroitLBIndustrialCtrlBase
    {
        #region (* Class variables *)
        /// <summary>
        /// The dp position
        /// </summary>
        protected int _dpPos = 0;
        /// <summary>
        /// The number digits
        /// </summary>
        protected int _numDigits = 0;
        /// <summary>
        /// The signed
        /// </summary>
        private bool _signed = false;
        /// <summary>
        /// The format
        /// </summary>
        private string _format = string.Empty;
        /// <summary>
        /// The value
        /// </summary>
        private double val = 0.0;
        #endregion

        #region (* Constructor *)        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLBDigitalMeter" /> class.
        /// </summary>
        public ZeroitLBDigitalMeter()
        {
            InitializeComponent();

            // Transparent background
            this.BackColor = Color.Black;

            this.Format = "000";
        }
        #endregion

        #region (* Properties *)        
        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;

                foreach (Control disp in this.Controls)
                {
                    if (disp.GetType() == typeof(ZeroitLB7SegmentDisplay))
                    {
                        ZeroitLB7SegmentDisplay d = disp as ZeroitLB7SegmentDisplay;

                        d.BackColor = value;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;

                foreach (Control disp in this.Controls)
                {
                    if (disp.GetType() == typeof(ZeroitLB7SegmentDisplay))
                    {
                        ZeroitLB7SegmentDisplay d = disp as ZeroitLB7SegmentDisplay;

                        d.ForeColor = value;
                    }
                }
            }
        }

        /// <summary>
        /// Set the Set the signed value of the meter.
        /// </summary>
        /// <value><c>true</c> if signed; otherwise, <c>false</c>.</value>

        [
            Category("Digital meter"),
            Description("Set the signed value of the meter")
        ]
        public bool Signed
        {
            set
            {
                if (this._signed == value)
                    return;

                this._signed = value;

                this.UpdateControls();
            }

            get { return this._signed; }
        }

        /// <summary>
        /// Set the format of the display, without the sign
        /// </summary>
        /// <value>The format.</value>

        [
            Category("Digital meter"),
            Description("Format of the display value")
        ]
        public string Format
        {
            set
            {
                if (this._format == value)
                    return;

                this._format = value;

                this.UpdateControls();

                this.Value = this.Value;
            }

            get { return this._format; }
        }

        /// <summary>
        /// Set the value of the display
        /// </summary>
        /// <value>The value.</value>
        [
            Category("Digital meter"),
            Description("Value to display")
        ]
        public double Value
        {
            set
            {
                this.val = value;

                string str = this.val.ToString(this.Format);
                str = str.Replace(".", string.Empty);
                str = str.Replace(",", string.Empty);

                bool sign = false;
                if (str[0] == '-')
                {
                    sign = true;
                    str = str.TrimStart(new char[] { '-' });
                }

                if (str.Length > this._numDigits)
                {
                    foreach (ZeroitLB7SegmentDisplay d in this.Controls)
                        d.Value = (int)'E';

                    return;
                }

                int idx = 0;
                for (idx = str.Length - 1; idx >= 0; idx--)
                {
                    int id = idx;
                    if (this.Signed != false)
                        id++;
                    ZeroitLB7SegmentDisplay d = this.Controls[id] as ZeroitLB7SegmentDisplay;
                    d.Value = Convert.ToInt32(str[idx].ToString());
                }

                ZeroitLB7SegmentDisplay s = this.Controls["digit_sign"] as ZeroitLB7SegmentDisplay;
                if (s != null)
                {
                    if (sign != false)
                        s.Value = (int)'-';
                    else
                        s.Value = -1;
                }
            }

            get { return this.val; }
        }
        #endregion

        #region (* Overrided methods *)
        /// <summary>
        /// Create the default renderer
        /// </summary>
        /// <returns>ILBRenderer.</returns>
        protected override ILBRenderer CreateDefaultRenderer()
        {
            return new ZeroitLBDigitalMeterRenderer();
        }
        /// <summary>
        /// Resize of the control
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.RepositionControls();
        }
        #endregion

        #region (* Protected methods *)
        /// <summary>
        /// Update the controls of the meter
        /// </summary>
        protected virtual void UpdateControls()
        {
            int count = this.Format.Length;

            this._dpPos = -1;

            char[] seps = new char[] { '.', ',' };
            int sepIndex = this.Format.IndexOfAny(seps);
            if (sepIndex > 0)
            {
                count--;
                this._dpPos = sepIndex - 1;
                this._numDigits = count;
            }

            this._numDigits = count;

            this.Controls.Clear();

            if (this.Signed != false)
            {
                ZeroitLB7SegmentDisplay disp = new ZeroitLB7SegmentDisplay();
                disp.Name = "digit_sign";
                disp.Value = -1;
                this.Controls.Add(disp);
            }

            for (int idx = 0; idx < count; idx++)
            {
                ZeroitLB7SegmentDisplay disp = new ZeroitLB7SegmentDisplay();

                disp.Name = "digit_" + idx.ToString();

                disp.Click += this.DisplayClicked;

                if (sepIndex - 1 == idx)
                    disp.ShowDP = true;

                this.Controls.Add(disp);
            }

            this.RepositionControls();
        }

        /// <summary>
        /// Reposition of the digital displaies
        /// </summary>
        protected void RepositionControls()
        {
            Rectangle rc = this.ClientRectangle;

            if (this.Controls.Count <= 0)
                return;

            int digitW = rc.Width / this.Controls.Count;
            bool signFind = false;
            foreach (Control disp in this.Controls)
            {
                if (disp.GetType() == typeof(ZeroitLB7SegmentDisplay))
                {
                    ZeroitLB7SegmentDisplay d = disp as ZeroitLB7SegmentDisplay;

                    int idDigit = 0;
                    if (d.Name.Contains("digit_sign") != false)
                    {
                        signFind = true;
                    }
                    else
                    {
                        if (d.Name.Contains("digit_") != false)
                        {
                            string s = d.Name.Remove(0, 6);
                            idDigit = Convert.ToInt32(s);

                            if (signFind != false)
                                idDigit++;
                        }
                    }

                    Point pos = new Point();
                    pos.X = idDigit * digitW;
                    pos.Y = 0;
                    d.Location = pos;

                    Size dim = new Size();
                    dim.Width = digitW;
                    dim.Height = rc.Height;
                    d.Size = dim;
                }
            }
        }

        /// <summary>
        /// Event generate from the displaies in the control
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DisplayClicked(object sender, System.EventArgs e)
        {
            this.InvokeOnClick(this, e);
        }
        #endregion
    }
    #endregion

    #region Designer Generated
    partial class ZeroitLBDigitalMeter
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LBDigitalMeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LBDigitalMeter";
            this.Size = new System.Drawing.Size(385, 150);
            this.ResumeLayout(false);

        }

        #endregion
    }
    #endregion

    #region LBDigital Meter Render
    /// <summary>
    /// Class ZeroitLBDigitalMeterRenderer.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitLBRendererBase" />
    public class ZeroitLBDigitalMeterRenderer : ZeroitLBRendererBase
    {
        #region (* Constructor *)
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLBDigitalMeterRenderer"/> class.
        /// </summary>
        public ZeroitLBDigitalMeterRenderer()
        {
        }
        #endregion

        #region (* Overrided methods *)
        /// <summary>
        /// Drawing method
        /// </summary>
        /// <param name="Gr">The gr.</param>
        public override void Draw(Graphics Gr)
        {
            if (this.Meter == null)
                return;

            RectangleF _rc = new RectangleF(0, 0, this.Meter.Width, this.Meter.Height);
            Gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            this.DrawBackground(Gr, _rc);
            this.DrawBorder(Gr, _rc);
        }
        #endregion

        #region (* Properties *)
        /// <summary>
        /// Gets the meter.
        /// </summary>
        /// <value>The meter.</value>
        public ZeroitLBDigitalMeter Meter
        {
            get { return this.Control as ZeroitLBDigitalMeter; }
        }
        #endregion

        #region (* Virtual methods *)
        /// <summary>
        /// Draws the background.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DrawBackground(Graphics gr, RectangleF rc)
        {
            if (this.Meter == null)
                return false;

            Color c = this.Meter.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.Meter.Width, this.Meter.Height);
            gr.DrawRectangle(pen, _rcTmp);
            gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }

        /// <summary>
        /// Draws the border.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="rc">The rc.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool DrawBorder(Graphics gr, RectangleF rc)
        {
            if (this.Meter == null)
                return false;

            return true;
        }
        #endregion
    }
    #endregion

    #endregion

    #region LBMeter Threshold
    /// <summary>
    /// Class for the meter threshold
    /// </summary>
    public class ZeroitLBMeterThreshold
    {
        #region (* Properties variables *)
        /// <summary>
        /// The color
        /// </summary>
        private Color color = Color.Empty;
        /// <summary>
        /// The start value
        /// </summary>
        private double startValue = 0.0;
        /// <summary>
        /// The end value
        /// </summary>
        private double endValue = 1.0;
        #endregion

        #region (* Constructor *)
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLBMeterThreshold"/> class.
        /// </summary>
        public ZeroitLBMeterThreshold()
        {
        }
        #endregion

        #region (* Properties *)
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color
        {
            set { this.color = value; }
            get { return this.color; }
        }

        /// <summary>
        /// Gets or sets the start value.
        /// </summary>
        /// <value>The start value.</value>
        public double StartValue
        {
            set { this.startValue = value; }
            get { return this.startValue; }
        }

        /// <summary>
        /// Gets or sets the end value.
        /// </summary>
        /// <value>The end value.</value>
        public double EndValue
        {
            set { this.endValue = value; }
            get { return this.endValue; }
        }
        #endregion

        #region (* Public methods *)
        /// <summary>
        /// Determines whether [is in range] [the specified value].
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns><c>true</c> if [is in range] [the specified value]; otherwise, <c>false</c>.</returns>
        public bool IsInRange(double val)
        {
            if (val > this.EndValue)
                return false;

            if (val < this.StartValue)
                return false;

            return true;
        }
        #endregion
    }

    /// <summary>
    /// Collection of the meter thresolds
    /// </summary>
    /// <seealso cref="System.Collections.CollectionBase" />
    public class ZeroitLBMeterThresholdCollection : CollectionBase
    {
        #region (* Properties variables *)
        /// <summary>
        /// The is read only
        /// </summary>
        private bool _IsReadOnly = false;
        #endregion

        #region (* Constructor *)
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLBMeterThresholdCollection"/> class.
        /// </summary>
        public ZeroitLBMeterThresholdCollection()
        {
        }
        #endregion

        #region (* Properties *)
        /// <summary>
        /// Gets or sets the <see cref="ZeroitLBMeterThreshold"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>ZeroitLBMeterThreshold.</returns>
        public virtual ZeroitLBMeterThreshold this[int index]
        {
            get { return (ZeroitLBMeterThreshold)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> is read-only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public virtual bool IsReadOnly
        {
            get { return _IsReadOnly; }
        }
        #endregion

        #region (* Public methods *)
        /// <summary>
        /// Add an object to the collection
        /// </summary>
        /// <param name="sector">The sector.</param>
        public virtual void Add(ZeroitLBMeterThreshold sector)
        {
            InnerList.Add(sector);
        }

        /// <summary>
        /// Remove an object from the collection
        /// </summary>
        /// <param name="sector">The sector.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool Remove(ZeroitLBMeterThreshold sector)
        {
            bool result = false;

            //loop through the inner array's indices
            for (int i = 0; i < InnerList.Count; i++)
            {
                //store current index being checked
                ZeroitLBMeterThreshold obj = (ZeroitLBMeterThreshold)InnerList[i];

                //compare the values of the objects
                if ((obj.StartValue == sector.StartValue) &&
                    (obj.EndValue == sector.EndValue))
                {
                    //remove item from inner ArrayList at index i
                    InnerList.RemoveAt(i);
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Check if the object is containing in the collection
        /// </summary>
        /// <param name="sector">The sector.</param>
        /// <returns><c>true</c> if [contains] [the specified sector]; otherwise, <c>false</c>.</returns>
        public bool Contains(ZeroitLBMeterThreshold sector)
        {
            //loop through the inner ArrayList
            foreach (ZeroitLBMeterThreshold obj in InnerList)
            {
                //compare the values of the objects
                if ((obj.StartValue == sector.StartValue) &&
                    (obj.EndValue == sector.EndValue))
                {
                    //if it matches return true
                    return true;
                }
            }

            //no match
            return false;
        }

        /// <summary>
        /// Copy the collection
        /// </summary>
        /// <param name="MeterThresholdArray">The meter threshold array.</param>
        /// <param name="index">The index.</param>
        /// <exception cref="System.Exception">This Method is not valid for this implementation.</exception>
        public virtual void CopyTo(ZeroitLBMeterThreshold[] MeterThresholdArray, int index)
        {
            throw new Exception("This Method is not valid for this implementation.");
        }
        #endregion
    }
    #endregion
}
