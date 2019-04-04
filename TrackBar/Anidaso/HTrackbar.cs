// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-30-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="HTrackbar.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for rendering a slider.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DebuggerStepThrough]
	[DefaultEvent("ValueChanged")]
	public class ZeroitAnidasoHorTrackbar : UserControl
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
        /// The panel1
        /// </summary>
        private Panel panel1;

        /// <summary>
        /// The event handler 0
        /// </summary>
        EventHandler eventHandler_0;
        /// <summary>
        /// The event handler 1
        /// </summary>
        EventHandler eventHandler_1;
        #endregion


        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Color Background
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
				Ellipse.Apply(this.slider, this.int_2);
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
				this.panel1.BackColor = this.slider.BackColor;
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
				double width = (double)base.Width;
				double num = (double)this.slider.Width;
				int left = this.slider.Left;
				double int1 = (double)this.int_1 * (width - num) / (double)this.MaximumValue;
				this.slider.Left = (int)Math.Truncate(int1);
				this.panel1.Width = this.slider.Left + this.slider.Width / 2;
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
				double width = (double)base.Width;
				double num = (double)this.slider.Width;
				int left = this.slider.Left;
				double int1 = (double)this.int_1 * (width - num) / (double)this.MaximumValue;
				this.slider.Left = (int)Math.Truncate(int1);
				this.panel1.Width = this.slider.Left + this.slider.Width / 2;
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAnidasoHorTrackbar" /> class.
        /// </summary>
        public ZeroitAnidasoHorTrackbar()
		{
			this.InitializeComponent();
			this.panel1.Width = this.slider.Left + this.slider.Width / 2;
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
				int x = e.X;
				if (x > 0 && x + this.slider.Width < base.Width)
				{
					this.slider.Left = x;
					double width = (double)base.Width;
					double width1 = (double)this.slider.Width;
					double left = (double)this.slider.Left;
					double maximumValue = (double)this.MaximumValue * left / (width - width1);
					this.int_1 = (int)Math.Truncate(maximumValue);
					this.panel1.Width = this.slider.Left + this.slider.Width / 2;
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
        /// Handles the Load event of the ZeroitAnidasoHorTrackbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ZeroitAnidasoHorTrackbar_Load(object sender, EventArgs e)
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
        /// Handles the Resize event of the ZeroitAnidasoHorTrackbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ZeroitAnidasoHorTrackbar_Resize(object sender, EventArgs e)
		{
			base.Height = this.slider.Height + 10;
			this.bg.Width = base.Width;
			this.bg.Left = 0;
			Ellipse.Apply(this.bg, this.int_2);
			Ellipse.Apply(this.slider, this.int_2);
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
			this.panel1 = new Panel();
			this.slider = new Panel();
			this.bg.SuspendLayout();
			base.SuspendLayout();
			this.bg.BackColor = Color.DarkGray;
			this.bg.Controls.Add(this.panel1);
			this.bg.Cursor = Cursors.Hand;
			this.bg.Location = new Point(3, 8);
			this.bg.Name = "bg";
			this.bg.Size = new System.Drawing.Size(408, 10);
			this.bg.TabIndex = 0;
			this.bg.Paint += new PaintEventHandler(this.bg_Paint);
			this.bg.MouseDown += new MouseEventHandler(this.bg_MouseDown);
			this.panel1.BackColor = Color.SeaGreen;
			this.panel1.Cursor = Cursors.Hand;
			this.panel1.Dock = DockStyle.Left;
			this.panel1.Enabled = false;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(0, 10);
			this.panel1.TabIndex = 2;
			this.slider.BackColor = Color.SeaGreen;
			this.slider.Cursor = Cursors.Hand;
			this.slider.Location = new Point(0, 3);
			this.slider.Name = "slider";
			this.slider.Size = new System.Drawing.Size(20, 20);
			this.slider.TabIndex = 1;
			this.slider.MouseMove += new MouseEventHandler(this.slider_MouseMove);
			this.slider.MouseUp += new MouseEventHandler(this.slider_MouseUp);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.Transparent;
			base.Controls.Add(this.slider);
			base.Controls.Add(this.bg);
			base.Name = "ZeroitAnidasoHorTrackbar";
			base.Size = new System.Drawing.Size(415, 28);
			base.Load += new EventHandler(this.ZeroitAnidasoHorTrackbar_Load);
			base.Resize += new EventHandler(this.ZeroitAnidasoHorTrackbar_Resize);
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
				if (x < 0)
				{
					this.slider.Left = 0;
					this.int_1 = 0;
				}
				else if (x + this.slider.Width <= base.Width)
				{
					this.slider.Left = x;
					double width = (double)base.Width;
					double width1 = (double)this.slider.Width;
					double left = (double)this.slider.Left;
					double maximumValue = (double)this.MaximumValue * left / (width - width1);
					this.int_1 = (int)Math.Truncate(maximumValue);
				}
				else
				{
					this.slider.Left = base.Width - this.slider.Width;
					this.int_1 = this.MaximumValue;
				}
				this.panel1.Width = this.slider.Left + this.slider.Width / 2;
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
        /// Handles the MouseUp event of the slider control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void slider_MouseUp(object sender, MouseEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
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
			}
			else
			{
				this.eventHandler_1(this, new EventArgs());
			}
		}

        /// <summary>
        /// Occurs when [value change complete].
        /// </summary>
        public event EventHandler ValueChangeComplete
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


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (AllowTransparency)
            {
                MakeTransparent(this, e.Graphics);
            }
        }



        #region Include in Private Field

        /// <summary>
        /// The allow transparency
        /// </summary>
        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow transparency].
        /// </summary>
        /// <value><c>true</c> if [allow transparency]; otherwise, <c>false</c>.</value>
        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion



        #region Include in Paint

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        /// <summary>
        /// Makes the transparent.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="g">The g.</param>
        private static void MakeTransparent(Control control, System.Drawing.Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion



    }
}