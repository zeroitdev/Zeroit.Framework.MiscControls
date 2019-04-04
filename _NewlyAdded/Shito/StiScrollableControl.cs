// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="StiScrollableControl.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Defines a base class for controls that support scrolling behavior.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ScrollableControl" />
    [ToolboxItem(true)]
	[ToolboxBitmap(typeof(ZeroitScrollPanel), "Toolbox.StiScrollableControl.bmp")]
	public class ZeroitScrollPanel : ScrollableControl
	{
        #region Handlers
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(System.EventArgs e)
		{
			base.OnSizeChanged(e);
			SetPos();
			this.SetDisplayRectLocation(10, 10);
		}

        /// <summary>
        /// Handles the <see cref="E:ValueChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnValueChanged(object sender, EventArgs e)
		{
			SetPos();		
			Draw();
		}
        #endregion

        #region Fields
        /// <summary>
        /// The edge panel
        /// </summary>
        private Panel edgePanel = new Panel();
        #endregion

        #region Browsable(false)
        /// <summary>
        /// Do not use this property.
        /// </summary>
        /// <value>The background image.</value>
        [Browsable(false)]
		public new Image BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

        /// <summary>
        /// Do not use this property.
        /// </summary>
        /// <value>The dock padding.</value>
        [Browsable(false)]
		public new ScrollableControl.DockPaddingEdges DockPadding
		{
			get
			{
				return base.DockPadding;
			}
		}
        #endregion

        #region Properties

        /// <summary>
        /// The curve
        /// </summary>
        private int curve = 10;

        /// <summary>
        /// Gets or sets the curve.
        /// </summary>
        /// <value>The curve.</value>
        public int Curve
        {
            get { return curve; }
            set
            {
                if(value < 1)
                {
                    value = 1;
                }
                curve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The v scroll bar
        /// </summary>
        private StiVScrollBar vScrollBar;
        /// <summary>
        /// Gets or sets the vertical ScrollBar.
        /// </summary>
        /// <value>The v scroll bar.</value>
        [Browsable(false)]
		public StiVScrollBar VScrollBar
		{
			get
			{
				return vScrollBar;
			}
			set
			{
				vScrollBar = value;
			}
		}

        /// <summary>
        /// The h scroll bar
        /// </summary>
        private StiHScrollBar hScrollBar;
        /// <summary>
        /// Gets or sets the horizontal ScrollBar.
        /// </summary>
        /// <value>The h scroll bar.</value>
        [Browsable(false)]
		public StiHScrollBar HScrollBar
		{
			get
			{
				return hScrollBar;
			}
			set
			{
				hScrollBar = value;
			}
		}

        /// <summary>
        /// The scroll width
        /// </summary>
        private int scrollWidth = 100;
        /// <summary>
        /// Gets or sets the value indicates width of a scrolling area.
        /// </summary>
        /// <value>The width of the scroll.</value>
        [Category("Behavior")]
		public virtual int ScrollWidth
		{
			get
			{
				return scrollWidth;
			}
			set
			{
				scrollWidth = value;
				SetPos();
				Draw();
			}
		}


        /// <summary>
        /// The scroll height
        /// </summary>
        private int scrollHeight = 100;
        /// <summary>
        /// Gets or sets the value indicates height of a scrolling area.
        /// </summary>
        /// <value>The height of the scroll.</value>
        [Category("Behavior")]
		public virtual int ScrollHeight
		{
			get
			{
				return scrollHeight;
			}
			set
			{
				scrollHeight = value;
				SetPos();
				Draw();
			}
		}


        /// <summary>
        /// The scroll top
        /// </summary>
        private int scrollTop = 0;
        /// <summary>
        /// Gets or sets the top position of a scrolling area.
        /// </summary>
        /// <value>The scroll top.</value>
        [Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int ScrollTop
		{
			get
			{
				return scrollTop;
			}
			set
			{
				int dist = value - scrollTop;
				if (dist != 0)
				{
					foreach (Control control in Controls)
						if (!IsScrollBar(control))						
							control.Top += dist;
					
					scrollTop = value;
				}
			}
		}


        /// <summary>
        /// The scroll left
        /// </summary>
        private int scrollLeft = 0;
        /// <summary>
        /// Gets or sets the left position of a scrolling area.
        /// </summary>
        /// <value>The scroll left.</value>
        [Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int ScrollLeft
		{
			get
			{
				return scrollLeft;
			}
			set
			{
				
				int dist = value - scrollLeft;
				if (dist != 0)
				{
					//HScrollBar.Value = value;
					foreach (Control control in Controls)
						if (!IsScrollBar(control))
							control.Left += dist;
					
					scrollLeft = value;
				}
			}
		}

        /// <summary>
        /// Gets or sets the width of the client area of the control.
        /// </summary>
        /// <value>The width of the client.</value>
		[Browsable(false)]
		public int ClientWidth
		{
			get
			{
				if (VScrollBar.Visible)return this.Width - 16;
				else return this.Width;
			}
		}

        /// <summary>
        /// Gets or sets the height of the client area of the control.
        /// </summary>
        /// <value>The height of the client.</value>
        [Browsable(false)]
		public int ClientHeight
		{
			get
			{
				if (HScrollBar.Visible)return this.Height - 16;
				else return this.Height;
			}
		}

        #endregion

        #region Methods
        /// <summary>
        /// Draws this instance.
        /// </summary>
        private void Draw()
		{
			Invalidate(this.ClientRectangle);
		}

        /// <summary>
        /// Determines whether [is scroll bar] [the specified control].
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns><c>true</c> if [is scroll bar] [the specified control]; otherwise, <c>false</c>.</returns>
        private bool IsScrollBar(Control control)
		{
			return (control == VScrollBar) || (control == HScrollBar) || (control == edgePanel);
		}

        /// <summary>
        /// Sets the position.
        /// </summary>
        protected void SetPos()
		{
			try
			{
				if (ClientWidth >= ScrollWidth)
				{
					HScrollBar.Visible = false;
				}
				else HScrollBar.Visible = true;

				if (ClientHeight >= ScrollHeight)
				{
					VScrollBar.Visible = false;
				}
				else VScrollBar.Visible = true;

				#region VScrollBar
				VScrollBar.Width = 16;
				if (HScrollBar.Visible)VScrollBar.Height = this.Height - 16;
				else VScrollBar.Height = this.Height - Curve;
				VScrollBar.Top = (int)(Curve / 2);
				VScrollBar.Left = this.Width - VScrollBar.Width-(int)(Curve/2);
				#endregion
			
				#region HScrollBar
				HScrollBar.Width = this.Width - 16;
				if (VScrollBar.Visible)HScrollBar.Width = this.Width - 16;
				else HScrollBar.Width = this.Width-Curve;
				HScrollBar.Height = 16;
				HScrollBar.Left = (int)(Curve / 2);
				HScrollBar.Top = this.Height - HScrollBar.Height - (int)(Curve / 2);
				#endregion

				#region EdgePanel
				edgePanel.Left = HScrollBar.Right;
				edgePanel.Top = VScrollBar.Bottom;
				edgePanel.Width = VScrollBar.Width;
				edgePanel.Height = HScrollBar.Height;
				edgePanel.Visible = HScrollBar.Visible & VScrollBar.Visible;
				edgePanel.BackColor = SystemColors.Control;
				#endregion

				ScrollTop = - VScrollBar.Value;
				ScrollLeft = - HScrollBar.Value;

				VScrollBar.Minimum = 0;
				VScrollBar.Maximum = ScrollHeight;
				VScrollBar.LargeChange = Math.Max(this.ClientHeight, 0);
				VScrollBar.SmallChange = VScrollBar.LargeChange / 10;

				HScrollBar.Minimum = 0;
				HScrollBar.Maximum = ScrollWidth;
				HScrollBar.LargeChange = Math.Max(this.ClientWidth, 0);
				HScrollBar.SmallChange = HScrollBar.LargeChange / 10;
			}
			catch
			{
			}
			
		}

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitScrollPanel"/> class.
        /// </summary>
        public ZeroitScrollPanel()
		{
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.ContainerControl, false);

			#region ScrollBars
			VScrollBar = new StiVScrollBar();
            VScrollBar.Location = new Point(5, 5);



            VScrollBar.ValueChanged += new EventHandler(OnValueChanged);

			HScrollBar = new StiHScrollBar();
			HScrollBar.ValueChanged += new EventHandler(OnValueChanged);
		
			this.Controls.Add(VScrollBar);
			this.Controls.Add(HScrollBar);
			#endregion

			#region EdgePanel
			this.Controls.Add(edgePanel);
			#endregion

			SetPos();

			Width = 100;
			Height = 100;

			this.ClientSize = new Size(40, 40);// = Width - 40;
		}
        #endregion

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Rectangle bounds = this.ClientRectangle;
            bounds.Inflate(-1, -1);

            GraphicsPath shape = RoundRect(bounds, Curve,Curve,Curve,Curve);

            g.DrawPath(new Pen(Color.Gray), shape);

            e.Graphics.DrawImage(b, 0, 0);
            b.Dispose();
            g.Dispose();
        }

        /// <summary>
        /// Rounded Rectangle
        /// </summary>
        /// <param name="Rectangle">Set Rectangle</param>
        /// <param name="UpperLeftCurve">Set Upper Left Curve</param>
        /// <param name="UpperRightCurve">Set Upper Right Curve</param>
        /// <param name="DownLeftCurve">Set Down Left Curve</param>
        /// <param name="DownRightCurve">Set Down Right Curve</param>
        /// <returns>GraphicsPath.</returns>
        private static GraphicsPath RoundRect(Rectangle Rectangle, int UpperLeftCurve, int UpperRightCurve, int DownLeftCurve, int DownRightCurve)
        {
            //Curve = curve;
            GraphicsPath P = new GraphicsPath();
            

            int UpperLeftCorner = UpperLeftCurve * 2;
            int UpperRightCorner = UpperRightCurve * 2;
            int DownLeftCorner = DownLeftCurve * 2;
            int DownRightCorner = DownRightCurve * 2;

            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, UpperLeftCorner, UpperLeftCorner), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - UpperRightCorner + Rectangle.X, Rectangle.Y, UpperRightCorner, UpperRightCorner), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - DownRightCorner + Rectangle.X, Rectangle.Height - DownRightCorner + Rectangle.Y, DownRightCorner, DownRightCorner), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - DownLeftCorner + Rectangle.Y, DownLeftCorner, DownLeftCorner), 90, 90);
            //P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));

            //P.AddLine(new Point(Rectangle.X, Rectangle.Height - UpperLeftCorner + Rectangle.Y), new Point(Rectangle.X, UpperLeftCorner + Rectangle.Y));

            P.CloseAllFigures();
            return P;
        }

    }
}
