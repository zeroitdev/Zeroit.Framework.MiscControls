// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ZeroitPlutoGradientPanel.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for rendering a gradient panel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    public class ZeroitPlutoGradientPanel : Panel
	{


        /// <summary>
        /// The buffered graphics
        /// </summary>
        private BufferedGraphics bufferedGraphics;

        /// <summary>
        /// The primer color
        /// </summary>
        private Color primerColor = Color.White;

        /// <summary>
        /// The top left
        /// </summary>
        private Color topLeft = Color.DeepSkyBlue;

        /// <summary>
        /// The top right
        /// </summary>
        private Color topRight = Color.Fuchsia;

        /// <summary>
        /// The bottom left
        /// </summary>
        private Color bottomLeft = Color.Black;

        /// <summary>
        /// The bottom right
        /// </summary>
        private Color bottomRight = Color.Fuchsia;

        /// <summary>
        /// The style
        /// </summary>
        private ZeroitPlutoGradientPanel.GradientStyle style = ZeroitPlutoGradientPanel.GradientStyle.Corners;


        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Color BackColor
		{
			get;
			set;
		}

        /// <summary>
        /// Gets or sets the bottom left.
        /// </summary>
        /// <value>The bottom left.</value>
        [Browsable(true)]
		[Category("Zeroit.Framework.DaggerControls")]
		[Description("The bottom left color")]
		public Color BottomLeft
		{
			get
			{
				return this.bottomLeft;
			}
			set
			{
				this.bottomLeft = value;
				base.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets the bottom right.
        /// </summary>
        /// <value>The bottom right.</value>
        [Browsable(true)]
		[Category("Zeroit.Framework.DaggerControls")]
		[Description("The bottom right color")]
		public Color BottomRight
		{
			get
			{
				return this.bottomRight;
			}
			set
			{
				this.bottomRight = value;
				base.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Color ForeColor
		{
			get;
			set;
		}

        /// <summary>
        /// Gets or sets the color of the primer.
        /// </summary>
        /// <value>The color of the primer.</value>
        [Browsable(true)]
		[Category("Zeroit.Framework.DaggerControls")]
		[Description("The primer color")]
		public Color PrimerColor
		{
			get
			{
				return this.primerColor;
			}
			set
			{
				this.primerColor = value;
				base.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [Browsable(true)]
		[Category("Zeroit.Framework.DaggerControls")]
		[Description("The gradient orientation")]
		public ZeroitPlutoGradientPanel.GradientStyle Style
		{
			get
			{
				return this.style;
			}
			set
			{
				this.style = value;
				this.Refresh();
			}
		}

        /// <summary>
        /// Gets or sets the top left.
        /// </summary>
        /// <value>The top left.</value>
        [Browsable(true)]
		[Category("Zeroit.Framework.DaggerControls")]
		[Description("The top left color")]
		public Color TopLeft
		{
			get
			{
				return this.topLeft;
			}
			set
			{
				this.topLeft = value;
				base.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets the top right.
        /// </summary>
        /// <value>The top right.</value>
        [Browsable(true)]
		[Category("Zeroit.Framework.DaggerControls")]
		[Description("The top right color")]
		public Color TopRight
		{
			get
			{
				return this.topRight;
			}
			set
			{
				this.topRight = value;
				base.Invalidate();
			}
		}


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPlutoGradientPanel" /> class.
        /// </summary>
        public ZeroitPlutoGradientPanel()
		{
			this.DoubleBuffered = true;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
			this.BackColor = Color.White;
			base.Size = new System.Drawing.Size(200, 200);
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
		{
			Brush brush;
			base.OnPaint(e);
			BufferedGraphicsContext current = BufferedGraphicsManager.Current;
			current.MaximumBuffer = new System.Drawing.Size(base.Width + 1, base.Height + 1);
			this.bufferedGraphics = current.Allocate(base.CreateGraphics(), base.ClientRectangle);
			this.bufferedGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			this.bufferedGraphics.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
			this.bufferedGraphics.Graphics.CompositingQuality = CompositingQuality.HighQuality;
			this.bufferedGraphics.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			this.bufferedGraphics.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			this.bufferedGraphics.Graphics.Clear(this.primerColor);
			if (this.style != ZeroitPlutoGradientPanel.GradientStyle.Corners)
			{
				brush = (this.style != ZeroitPlutoGradientPanel.GradientStyle.Vertical ? new LinearGradientBrush(base.ClientRectangle, this.topLeft, this.topRight, 90f) : new LinearGradientBrush(base.ClientRectangle, this.topLeft, this.topRight, 720f));
				this.bufferedGraphics.Graphics.FillRectangle(brush, base.ClientRectangle);
				brush.Dispose();
			}
			else
			{
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), this.TopLeft, Color.Transparent, 45f);
				this.bufferedGraphics.Graphics.FillRectangle(linearGradientBrush, base.ClientRectangle);
				linearGradientBrush = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), this.topRight, Color.Transparent, 135f);
				this.bufferedGraphics.Graphics.FillRectangle(linearGradientBrush, base.ClientRectangle);
				linearGradientBrush = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), this.bottomRight, Color.Transparent, 225f);
				this.bufferedGraphics.Graphics.FillRectangle(linearGradientBrush, base.ClientRectangle);
				linearGradientBrush = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), this.bottomLeft, Color.Transparent, 315f);
				this.bufferedGraphics.Graphics.FillRectangle(linearGradientBrush, base.ClientRectangle);
				linearGradientBrush.Dispose();
			}
			this.bufferedGraphics.Render(e.Graphics);
		}

        /// <summary>
        /// Enum representing the gradient style
        /// </summary>
        public enum GradientStyle
		{
            /// <summary>
            /// The horizontal
            /// </summary>
            Horizontal,
            /// <summary>
            /// The vertical
            /// </summary>
            Vertical,
            /// <summary>
            /// The corners
            /// </summary>
            Corners
        }

	}
}