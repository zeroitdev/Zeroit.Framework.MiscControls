// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-04-2018
// ***********************************************************************
// <copyright file="GradientPanel.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using Zeroit.Framework.MiscControls.Helper;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for rendering a gradient panel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    public class ZeroitAnidasoGradientPanel : Panel
	{
        #region Private Fields
        /// <summary>
        /// The color 0
        /// </summary>
        private Color color_0 = Color.White;

        /// <summary>
        /// The color 1
        /// </summary>
        private Color color_1 = Color.White;

        /// <summary>
        /// The color 2
        /// </summary>
        private Color color_2 = Color.White;

        /// <summary>
        /// The color 3
        /// </summary>
        private Color color_3 = Color.White;

        /// <summary>
        /// The int 0
        /// </summary>
        private int int_0 = 10;

        /// <summary>
        /// The icontainer 0
        /// </summary>
        private IContainer icontainer_0;

        #endregion


        #region Public Properties        
        /// <summary>
        /// Gets or sets the gradient bottom left.
        /// </summary>
        /// <value>The gradient bottom left.</value>
        public Color GradientBottomLeft
        {
            get
            {
                return this.color_2;
            }
            set
            {
                this.color_2 = value;
                this.method_0();
            }
        }

        /// <summary>
        /// Gets or sets the gradient bottom right.
        /// </summary>
        /// <value>The gradient bottom right.</value>
        public Color GradientBottomRight
        {
            get
            {
                return this.color_3;
            }
            set
            {
                this.color_3 = value;
                this.method_0();
            }
        }

        /// <summary>
        /// Gets or sets the gradient top left.
        /// </summary>
        /// <value>The gradient top left.</value>
        public Color GradientTopLeft
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
                this.method_0();
            }
        }

        /// <summary>
        /// Gets or sets the gradient top right.
        /// </summary>
        /// <value>The gradient top right.</value>
        public Color GradientTopRight
        {
            get
            {
                return this.color_1;
            }
            set
            {
                this.color_1 = value;
                this.method_0();
            }
        }

        /// <summary>
        /// Gets or sets the quality.
        /// </summary>
        /// <value>The quality.</value>
        public int Quality
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
                this.method_0();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAnidasoGradientPanel" /> class.
        /// </summary>
        public ZeroitAnidasoGradientPanel()
		{
			this.method_1();
			this.method_0();


            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            DoubleBuffered = true;
        }

        /// <summary>
        /// Handles the Resize event of the ZeroitAnidasoGradientPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ZeroitAnidasoGradientPanel_Resize(object sender, EventArgs e)
		{
			this.method_0();
		}

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
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
        /// Methods the 0.
        /// </summary>
        private void method_0()
		{
			Bitmap bitmap = new Bitmap(this.Quality, this.Quality);
			if (this.Quality == 100)
			{
				bitmap = new Bitmap(base.Width, base.Height);
			}
			for (int i = 0; i < bitmap.Width; i++)
			{
				double num = Math.Round((double)i / (double)bitmap.Width * 100, 0);
				Color colorScale = ZeroitAnidasoColorTransition.getColorScale(int.Parse(num.ToString()), this.GradientTopLeft, this.GradientTopRight);
				for (int j = 0; j < bitmap.Height; j++)
				{
					num = Math.Round((double)j / (double)bitmap.Height * 100, 0);
					Color color = ZeroitAnidasoColorTransition.getColorScale(int.Parse(num.ToString()), this.GradientBottomLeft, this.GradientBottomRight);
					bitmap.SetPixel(i, j, Zeroit.Framework.MiscControls.Helper.Graphics.AddColor(colorScale, color));
				}
			}
			if (this.BackgroundImageLayout != ImageLayout.Stretch)
			{
				this.BackgroundImageLayout = ImageLayout.Stretch;
			}
			this.BackgroundImage = bitmap;
		}

        /// <summary>
        /// Methods the 1.
        /// </summary>
        private void method_1()
		{
			base.SuspendLayout();
			base.Resize += new EventHandler(this.ZeroitAnidasoGradientPanel_Resize);
			base.ResumeLayout(false);
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