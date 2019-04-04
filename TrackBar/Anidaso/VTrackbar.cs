// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="VTrackbar.cs" company="Zeroit Dev Technologies">
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
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Zeroit.Framework.MiscControls.Helper;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for rendering a vertical trackbar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DebuggerStepThrough]
	[DefaultEvent("ValueChanged")]
	[ProvideProperty("ZeroitFramework", typeof(Control))]
	public class ZeroitAnidasoVertTrackbar : UserControl
	{
        /// <summary>
        /// The int 0
        /// </summary>
        private int int_0 = 100;

        /// <summary>
        /// The int 1
        /// </summary>
        private int int_1;

        /// <summary>
        /// The int 2
        /// </summary>
        private int int_2;

        /// <summary>
        /// The int 3
        /// </summary>
        private int int_3;

        /// <summary>
        /// The icontainer 0
        /// </summary>
        private IContainer icontainer_0;

        /// <summary>
        /// The bg
        /// </summary>
        private Panel bg;

        /// <summary>
        /// The slider
        /// </summary>
        private Panel slider;



        /// <summary>
        /// The event handler 0
        /// </summary>
        EventHandler eventHandler_0;

        /// <summary>
        /// Gets or sets the color of the backgroud.
        /// </summary>
        /// <value>The color of the backgroud.</value>
        public Color BackgroudColor
		{
			get
			{
				return this.bg.BackColor;
			}
			set
			{
				this.bg.BackColor = value;
			}
		}

        /// <summary>
        /// Gets or sets the border radius.
        /// </summary>
        /// <value>The border radius.</value>
        public int BorderRadius
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				Ellipse.Apply(this.bg, this.int_2);
			}
		}

        /// <summary>
        /// Gets or sets the color of the indicator.
        /// </summary>
        /// <value>The color of the indicator.</value>
        public Color IndicatorColor
		{
			get
			{
				return this.slider.BackColor;
			}
			set
			{
				this.slider.BackColor = value;
			    
			}
		}

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public int MaximumValue
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				this.slider.Top = (base.Height - 15) * this.int_1 / this.int_0;
			    
			}
		}

        /// <summary>
        /// Gets or sets the slider radius.
        /// </summary>
        /// <value>The slider radius.</value>
        public int SliderRadius
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
				Ellipse.Apply(this.slider, this.int_3);
			}
		}

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
		{
			get
			{
				return this.int_1;
			}
			set
			{
				if (value > this.int_0)
				{
					MessageBox.Show("Cannot exceed maximum Value");
					return;
				}
				this.int_1 = value;
				double height = (double)base.Height;
				double num = (double)this.slider.Height;
				int top = this.slider.Top;
				double int1 = (double)this.int_1 * (height - num) / (double)this.MaximumValue;
				this.slider.Top = (int)Math.Truncate(int1);
			    
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAnidasoVertTrackbar" /> class.
        /// </summary>
        public ZeroitAnidasoVertTrackbar()
		{
			this.InitializeComponent();
		    CustomControl.initializeComponent(this);
		}

        /// <summary>
        /// Handles the MouseDown event of the bg control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void bg_MouseDown(object sender, MouseEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				int y = e.Y;
				if (y >= 0 && y + this.slider.Height <= base.Height)
				{
					this.slider.Top = y;
					double height = (double)base.Height;
					double height1 = (double)this.slider.Height;
					double top = (double)this.slider.Top;
					double maximumValue = (double)this.MaximumValue * top / (height - height1);
					this.int_1 = (int)Math.Truncate(maximumValue);
				    if (this.eventHandler_0 == null)
					{
						do
						{
							if (num != num1)
							{
								break;
							}
							num1 = 1;
							num2 = num;
							num = 1;
						}
						while (1 <= num2);
						return;
					}
					this.eventHandler_0(this, new EventArgs());
					return;
				}
			}
			do
			{
				if (num != num1)
				{
					break;
				}
				num1 = 1;
				num2 = num;
				num = 1;
			}
			while (1 <= num2);
		}

        /// <summary>
        /// Handles the Paint event of the bg control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void bg_Paint(object sender, PaintEventArgs e)
		{
		}

        /// <summary>
        /// Handles the Load event of the ZeroitAnidasoVertTrackbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ZeroitAnidasoVertTrackbar_Load(object sender, EventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (!base.DesignMode)
			{
				do
				{
					if (num != num1)
					{
						break;
					}
					num1 = 1;
					num2 = num;
					num = 1;
				}
				while (1 <= num2);
			}
			else
			{
				CustomControl.initializeComponent(this);
			}
		}

        /// <summary>
        /// Handles the Resize event of the ZeroitAnidasoVertTrackbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ZeroitAnidasoVertTrackbar_Resize(object sender, EventArgs e)
		{
			base.Width = this.slider.Width + 10;
			this.bg.Height = base.Height;
			this.bg.Top = 0;
			Ellipse.Apply(this.bg, this.int_2);
			Ellipse.Apply(this.slider, this.int_3);
		}

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
		{
		    
            this.bg = new Panel();
		    this.slider = new Panel();
			base.SuspendLayout();
			this.bg.BackColor = Color.DarkGray;
		    
            this.bg.Cursor = Cursors.Hand;
			this.bg.Location = new Point(9, 8);
			this.bg.Name = "bg";
			this.bg.Size = new System.Drawing.Size(10, 408);
			this.bg.TabIndex = 0;
			this.bg.Paint += new PaintEventHandler(this.bg_Paint);
			this.bg.MouseDown += new MouseEventHandler(this.bg_MouseDown);
		    
            this.slider.BackColor = Color.Red;
			this.slider.Cursor = Cursors.Hand;
			this.slider.Location = new Point(4, 0);
			this.slider.Name = "slider";
			this.slider.Size = new System.Drawing.Size(20, 20);
			this.slider.TabIndex = 1;
			this.slider.MouseMove += new MouseEventHandler(this.slider_MouseMove);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.Transparent;
			base.Controls.Add(this.slider);
			base.Controls.Add(this.bg);
		    base.Name = "ZeroitAnidasoVertTrackbar";
			base.Size = new System.Drawing.Size(28, 415);
			base.Load += new EventHandler(this.ZeroitAnidasoVertTrackbar_Load);
			base.Resize += new EventHandler(this.ZeroitAnidasoVertTrackbar_Resize);
			base.ResumeLayout(false);
		}

        /// <summary>
        /// Handles the MouseMove event of the slider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void slider_MouseMove(object sender, MouseEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				int y = e.Y + this.slider.Top;
				if (y < 0)
				{
					this.slider.Top = 0;
					this.int_1 = 0;
				}
				else if (y + this.slider.Height <= base.Height)
				{
					this.slider.Top = y;
					double height = (double)base.Height;
					double height1 = (double)this.slider.Height;
					double top = (double)this.slider.Top;
					double maximumValue = (double)this.MaximumValue * top / (height - height1);
					this.int_1 = (int)Math.Truncate(maximumValue);
				}
				else
				{
					this.slider.Top = base.Height - this.slider.Height;
					this.int_1 = this.MaximumValue;
				}
			    if (this.eventHandler_0 == null)
				{
					do
					{
						if (num != num1)
						{
							break;
						}
						num1 = 1;
						num2 = num;
						num = 1;
					}
					while (1 <= num2);
					return;
				}
				this.eventHandler_0(this, new EventArgs());
				return;
			}
			do
			{
				if (num != num1)
				{
					break;
				}
				num1 = 1;
				num2 = num;
				num = 1;
			}
			while (1 <= num2);
		}

        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event EventHandler ValueChanged
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler0 = this.eventHandler_0;
				do
				{
					eventHandler = eventHandler0;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, eventHandler1, eventHandler);
				}
				while ((object)eventHandler0 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler0 = this.eventHandler_0;
				do
				{
					eventHandler = eventHandler0;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, eventHandler1, eventHandler);
				}
				while ((object)eventHandler0 != (object)eventHandler);
			}
		}
	}
}