// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-27-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="DigitalCell.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Zeroit.Framework.MiscControls.Digitals.Helpers.Drawable;

namespace Zeroit.Framework.MiscControls.Digitals.Cells
{
    /// <summary>
    /// Class ZeroitDigitalCell.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public partial class ZeroitDigitalCell : UserControl
    {
        /// <summary>
        /// Always transparent
        /// </summary>
        /// <value>The color of the back.</value>
        [Browsable(false)]
        public override Color BackColor { get { return Color.Transparent; } }

        /// <summary>
        /// The m d off opacity
        /// </summary>
        private double m_dOffOpacity = .1d;

        //public char value
        /// <summary>
        /// The color of the bar
        /// </summary>
        /// <value>The color of the fore.</value>
        [DefaultValue(typeof(Color), "Black")]
        [Description("The color of the cell's segments")]
        [Category("Appearance")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set 
            {
                base.ForeColor = value;
                foreach (DigitalBar bar in m_segments)
                {
                    bar.Color = value;
                }
                this.Invalidate(GetCompositeRedrawRegion());
            }
        }

        /// <summary>
        /// How opaque the bar is when it is turned off
        /// </summary>
        /// <value>The opacity when off.</value>
        /// <exception cref="ArgumentOutOfRangeException">value</exception>
        [DefaultValue(0.1d)]
        [Description("How opaque the cell's segments are when they are turned off")]
        [Category("Appearance")]
        public virtual double OpacityWhenOff
        {
            get { return m_dOffOpacity; }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                m_dOffOpacity = value;
                foreach (DigitalBar bar in m_segments)
                {
                    bar.OpacityWhenOff = m_dOffOpacity;
                }
                this.Invalidate(GetCompositeRedrawRegion());
            }
        }

        /// <summary>
        /// The m value
        /// </summary>
        private char m_value = (char)0;
        /// <summary>
        /// What character this cell should display
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="InvalidOperationException">value</exception>
        [DefaultValue((char)0)]
        [Description("What character this cell should display")]
        [Category("Appearance")]
        public char Value
        {
            get { return m_value; }
            set
            {
                if (!CanHandleValue(value))
                {
                    throw new InvalidOperationException("value");
                }

                m_value = value;
                UpdateSegmentsOnOff();
                this.Invalidate(GetCompositeRedrawRegion());
            }
        }

        /// <summary>
        /// The m segments
        /// </summary>
        private List<DigitalBar> m_segments = new List<DigitalBar>();
        /// <summary>
        /// Gets the segments.
        /// </summary>
        /// <value>The segments.</value>
        protected List<DigitalBar> Segments
        {
            get { return m_segments; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitDigitalCell"/> class.
        /// </summary>
        public ZeroitDigitalCell()
        {
            InitializeComponent();
            
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint, true);

            ForeColor = Color.Black;
            OpacityWhenOff = 0.1d;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (DigitalBar bar in m_segments)
            {
                bar.Draw(e.Graphics);
            }

            base.OnPaint(e);
        }

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            CalculateSegments(ClientRectangle);
            base.OnResize(e);
        }

        /// <summary>
        /// When overriden, this function should recalculate the size/location
        /// of any segments given the containing rectangle
        /// </summary>
        /// <param name="container">the parent container</param>
        protected virtual void CalculateSegments(RectangleF container)
        {
        }

        /// <summary>
        /// When overridden, tells the control what values are acceptable for the Value parameter.
        /// </summary>
        /// <param name="value">The value in question</param>
        /// <returns>True if the value specified can be handled</returns>
        /// <exception cref="NotSupportedException"></exception>
        protected virtual bool CanHandleValue(char value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// When overridden, handles setting segments on/off and corners.
        /// </summary>
        protected virtual void UpdateSegmentsOnOff()
        {
        }

        /// <summary>
        /// Gets the total redraw region of all segments
        /// </summary>
        /// <returns>the entire region that needs redrawn</returns>
        protected virtual Region GetCompositeRedrawRegion()
        {
            Region r = new Region();
            foreach (DigitalBar bar in Segments)
            {
                r.Union(bar.GetRedrawRegion());
            }

            return r;
        }

        /// <summary>
        /// Clean up any resources being used.
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

                foreach (DigitalBar bar in m_segments)
                {
                    bar.Dispose();
                }
                m_segments.Clear();
            }
            base.Dispose(disposing);
        }
    }
}
