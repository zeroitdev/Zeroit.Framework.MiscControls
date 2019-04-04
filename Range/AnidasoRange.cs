// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AnidasoRange.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls.Helper
{
    /// <summary>
    /// Class ZeroitAnidasoRange.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DebuggerStepThrough]
	[DefaultEvent("ZeroitAnidasoRangeChanged")]
	public class ZeroitAnidasoRange : UserControl
	{
        #region Private Fields
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
        /// The slider2
        /// </summary>
        private Panel slider2;

        /// <summary>
        /// The fill
        /// </summary>
        private Panel FILL;

        /// <summary>
        /// The rail height
        /// </summary>
        private int railHeight = 10;

        /// <summary>
        /// The event handler 0
        /// </summary>
        EventHandler eventHandler_0;
        /// <summary>
        /// The event handler 1
        /// </summary>
        EventHandler eventHandler_1;
        /// <summary>
        /// The event handler 2
        /// </summary>
        EventHandler eventHandler_2;

        #endregion

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
			    Invalidate();
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
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
				RangeEllipse.Apply(this.bg, this.int_3);
			    RangeEllipse.Apply(this.slider, this.int_3);
			    RangeEllipse.Apply(this.slider2, this.int_3);
			    Invalidate();
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
				Panel panel = this.slider;
				Panel fILL = this.FILL;
				Color color = value;
				Color color1 = color;
				this.slider2.BackColor = color;
				Color color2 = color1;
				Color color3 = color2;
				fILL.BackColor = color2;
				panel.BackColor = color3;
			    Invalidate();
            }
		}

        /// <summary>
        /// Gets or sets the maximum range.
        /// </summary>
        /// <value>The maximum range.</value>
        public int MaximumZeroitAnidasoRange
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				this.Maximum = this.int_0 * this.slider2.Left / (base.Width - 15);
				this.Minimum = this.int_0 * this.slider.Left / (base.Width - 15);
				this.FILL.Left = this.slider.Left + this.slider.Width / 2;
				this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
			    Invalidate();
            }
		}

        /// <summary>
        /// Gets or sets the upper limit.
        /// </summary>
        /// <value>The range maximum.</value>
        /// <exception cref="System.Exception">
        /// Maximum Value Reached
        /// or
        /// Minium Value Reached
        /// </exception>
        /// <exception cref="Exception">Maximum Value Reached
        /// or
        /// Minium Value Reached</exception>
        public int Maximum
		{
			get
			{
				return this.int_2;
			}
			set
			{
				int left = this.slider2.Left;
				if (value > this.int_0)
				{
					throw new Exception("Maximum Value Reached");
				}
				this.int_2 = value;
				this.slider2.Left = (base.Width - 15) * this.int_2 / this.int_0;
				if (this.slider2.Left < this.slider.Left)
				{
					this.slider2.Left = left;
					throw new Exception("Minium Value Reached");
				}
				this.FILL.Left = this.slider.Left + this.slider.Width / 2;
				this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
			    Invalidate();
            }
		}

        /// <summary>
        /// Gets or sets the lower limit.
        /// </summary>
        /// <value>The range minimum.</value>
        /// <exception cref="System.Exception">
        /// Minium Value Reached
        /// or
        /// Minium Value Reached
        /// </exception>
        /// <exception cref="Exception">Minium Value Reached
        /// or
        /// Minium Value Reached</exception>
        public int Minimum
		{
			get
			{
				return this.int_1;
			}
			set
			{
				int left = this.slider.Left;
				if (value > this.int_0)
				{
					throw new Exception("Minium Value Reached");
				}
				this.int_1 = value;
				this.slider.Left = (base.Width - 15) * this.int_1 / this.int_0;
				if (this.slider.Left > this.slider2.Left)
				{
					this.slider.Left = left;
					throw new Exception("Minium Value Reached");
				}
				this.FILL.Left = this.slider.Left + this.slider.Width / 2;
				this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
			    Invalidate();
            }
		}

        /// <summary>
        /// Gets or sets the height of the rail.
        /// </summary>
        /// <value>The height of the rail.</value>
        public int RailHeight
	    {
	        get { return railHeight; }
	        set { railHeight = value;
	            Invalidate();
	        }
	    }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAnidasoRange" /> class.
        /// </summary>
        public ZeroitAnidasoRange()
		{
			this.InitializeComponent();
			this.Maximum = this.int_0 * this.slider2.Left / (base.Width - 15);
			this.Minimum = this.int_0 * this.slider.Left / (base.Width - 15);
			this.FILL.Left = this.slider.Left + this.slider.Width / 2;
			this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
			CustomControl.initializeComponent(this);
		}

        /// <summary>
        /// Handles the MouseDown event of the bg control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void bg_MouseDown(object sender, MouseEventArgs e)
		{
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
        /// Handles the Resize event of the bg control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bg_Resize(object sender, EventArgs e)
		{
			this.FILL.Height = this.bg.Height + 1;
			this.FILL.Top = -1;
		}

        /// <summary>
        /// Handles the Load event of the ZeroitAnidasoRange control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ZeroitAnidasoRange_Load(object sender, EventArgs e)
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
        /// Handles the Resize event of the ZeroitAnidasoRange control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ZeroitAnidasoRange_Resize(object sender, EventArgs e)
		{
			base.Height = this.slider.Height + 10;
			this.bg.Width = base.Width;
			this.bg.Left = 0;
			RangeEllipse.Apply(this.bg, this.int_3);
			RangeEllipse.Apply(this.slider, this.int_3);
			RangeEllipse.Apply(this.slider2, this.int_3);
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
			this.FILL = new Panel();
			this.slider = new Panel();
			this.slider2 = new Panel();
			this.bg.SuspendLayout();
			base.SuspendLayout();
			this.bg.BackColor = Color.Red;
			this.bg.Controls.Add(this.FILL);
			this.bg.Location = new Point(3, 8);
			this.bg.Name = "bg";
			this.bg.Size = new System.Drawing.Size(408, RailHeight);
			this.bg.TabIndex = 0;
			this.bg.Paint += new PaintEventHandler(this.bg_Paint);
			this.bg.MouseDown += new MouseEventHandler(this.bg_MouseDown);
			this.bg.Resize += new EventHandler(this.bg_Resize);
			this.FILL.BackColor = Color.FromArgb(0, 122, 204);
			this.FILL.Cursor = Cursors.Hand;
			this.FILL.Location = new Point(18, -5);
			this.FILL.Name = "FILL";
			this.FILL.Size = new System.Drawing.Size(183, 20);
			this.FILL.TabIndex = 3;
			this.slider.BackColor = Color.FromArgb(0, 122, 204);
			this.slider.Cursor = Cursors.Hand;
			this.slider.Location = new Point(0, 3);
			this.slider.Name = "slider";
			this.slider.Size = new System.Drawing.Size(20, 20);
			this.slider.TabIndex = 1;
			this.slider.MouseMove += new MouseEventHandler(this.slider_MouseMove);
			this.slider2.BackColor = Color.FromArgb(0, 122, 204);
			this.slider2.Cursor = Cursors.Hand;
			this.slider2.Location = new Point(197, 3);
			this.slider2.Name = "slider2";
			this.slider2.Size = new System.Drawing.Size(20, 20);
			this.slider2.TabIndex = 2;
			this.slider2.MouseMove += new MouseEventHandler(this.slider2_MouseMove);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.Transparent;
			base.Controls.Add(this.slider2);
			base.Controls.Add(this.slider);
			base.Controls.Add(this.bg);
			base.Name = "ZeroitAnidasoRange";
			base.Size = new System.Drawing.Size(415, 28);
			base.Load += new EventHandler(this.ZeroitAnidasoRange_Load);
			base.Resize += new EventHandler(this.ZeroitAnidasoRange_Resize);
			this.bg.ResumeLayout(false);
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
				int x = e.X + this.slider.Left;
				if (x < this.slider2.Left && x > 0 && x + this.slider.Width < base.Width)
				{
					this.slider.Left = x;
					this.FILL.Left = this.slider.Left + this.slider.Width / 2;
					this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
					this.Minimum = this.int_0 * this.slider.Left / (base.Width - 15);
					if (this.eventHandler_0 != null)
					{
						this.eventHandler_0(this, new EventArgs());
					}
					if (this.eventHandler_2 == null)
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
					this.eventHandler_2(this, new EventArgs());
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
        /// Handles the MouseMove event of the slider2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void slider2_MouseMove(object sender, MouseEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				int x = e.X + this.slider2.Left;
				if (x > this.slider.Left && x + this.slider2.Width < base.Width)
				{
					this.slider2.Left = x;
					this.FILL.Left = this.slider.Left + this.slider.Width / 2;
					this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
					this.Maximum = this.int_0 * this.slider2.Left / (base.Width - 15);
					if (this.eventHandler_0 != null)
					{
						this.eventHandler_0(this, new EventArgs());
					}
					if (this.eventHandler_1 == null)
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
					this.eventHandler_1(this, new EventArgs());
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
        /// Occurs when [zeroit anidaso range changed].
        /// </summary>
        public event EventHandler ZeroitAnidasoRangeChanged
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

        /// <summary>
        /// Occurs when [maximum changed].
        /// </summary>
        public event EventHandler MaximumChanged
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler1 = this.eventHandler_1;
				do
				{
					eventHandler = eventHandler1;
					EventHandler eventHandler2 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler1 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_1, eventHandler2, eventHandler);
				}
				while ((object)eventHandler1 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler1 = this.eventHandler_1;
				do
				{
					eventHandler = eventHandler1;
					EventHandler eventHandler2 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler1 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_1, eventHandler2, eventHandler);
				}
				while ((object)eventHandler1 != (object)eventHandler);
			}
		}

        /// <summary>
        /// Occurs when [minimum changed].
        /// </summary>
        public event EventHandler MinimumChanged
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler2 = this.eventHandler_2;
				do
				{
					eventHandler = eventHandler2;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler2 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_2, eventHandler1, eventHandler);
				}
				while ((object)eventHandler2 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler2 = this.eventHandler_2;
				do
				{
					eventHandler = eventHandler2;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler2 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_2, eventHandler1, eventHandler);
				}
				while ((object)eventHandler2 != (object)eventHandler);
			}
		}
	}
}