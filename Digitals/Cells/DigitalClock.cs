// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-27-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="DigitalClock.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Zeroit.Framework.MiscControls.Digitals.Helpers;

namespace Zeroit.Framework.MiscControls.Digitals.Cells
{
    /// <summary>
    /// A digital clock to display times
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.Digitals.Helpers.BaseWControl" />
    [ToolboxItem(true)]
    [Description("A digital clock to display times")]
    public partial class ZeroitDigitalClock : BaseWControl
    {
        /// <summary>
        /// The m value
        /// </summary>
        private TimeSpan m_value = TimeSpan.Zero;
        /// <summary>
        /// The value of the clock
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="ArgumentOutOfRangeException">value</exception>
        [Description("The value of the clock")]
        [DefaultValue(typeof(TimeSpan), "00:00:00")]
        [Category("Appearance")]
        public TimeSpan Value
        {
            get { return m_value; }
            set
            {
                if (value < TimeSpan.Zero || value >= TimeSpan.FromHours(100))
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                m_value = value;
                UpdateValue();
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
                m_cellHr1.ForeColor = value;
                m_cellHr2.ForeColor = value;
                m_cellMin1.ForeColor = value;
                m_cellMin2.ForeColor = value;
                m_cellSec1.ForeColor = value;
                m_cellSec2.ForeColor = value;
                m_colonLeft.ForeColor = value;
                m_colonRight.ForeColor = value;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitDigitalClock"/> class.
        /// </summary>
        public ZeroitDigitalClock()
            : base(false)
        {
            InitializeComponent();
            UpdateValue();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            OnPaintGloss(e.Graphics);
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        private void UpdateValue()
        {
            string strHr = Value.Hours.ToString("00");
            string strMin = Value.Minutes.ToString("00");
            string strSec = Value.Seconds.ToString("00");

            m_cellHr1.Value = strHr[0];
            m_cellHr2.Value = strHr[1];
            m_cellMin1.Value = strMin[0];
            m_cellMin2.Value = strMin[1];
            m_cellSec1.Value = strSec[0];
            m_cellSec2.Value = strSec[1];
        }
    }
}
