// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabStyleIE8Provider.cs" company="Zeroit Dev Technologies">
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


using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.Tabs
{

    /// <summary>
    /// Class TabStyleIE8Provider.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.Tabs.TabStyleRoundedProvider" />
    [System.ComponentModel.ToolboxItem(false)]
	public class TabStyleIE8Provider : TabStyleRoundedProvider
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="TabStyleIE8Provider"/> class.
        /// </summary>
        /// <param name="tabControl">The tab control.</param>
        public TabStyleIE8Provider(ZeroitDuredoTab tabControl) : base(tabControl){
			this._Radius = 3;
			this._ShowTabCloser = true;
			this._CloserColorActive = Color.Red;
			
			//	Must set after the _Radius as this is used in the calculations of the actual padding
			this.Padding = new Point(6, 5);

		}

        /// <summary>
        /// Gets the tab rect.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Rectangle.</returns>
        public override Rectangle GetTabRect(int index){
			if (index < 0){
				return new Rectangle();
			}
			Rectangle tabBounds = base.GetTabRect(index);
			bool firstTabinRow = this._TabControl.IsFirstTabInRow(index);

			//	Make non-SelectedTabs smaller and selected tab bigger
			if (index != this._TabControl.SelectedIndex) {
				switch (this._TabControl.Alignment) {
					case TabAlignment.Top:
						tabBounds.Y += 1;
						tabBounds.Height -= 1;
						break;
					case TabAlignment.Bottom:
						tabBounds.Height -= 1;
						break;
					case TabAlignment.Left:
						tabBounds.X += 1;
						tabBounds.Width -= 1;
						break;
					case TabAlignment.Right:
						tabBounds.Width -= 1;
						break;
				}
			} else {
				switch (this._TabControl.Alignment) {
					case TabAlignment.Top:
						tabBounds.Y -= 1;
						tabBounds.Height += 1;
						
						if (firstTabinRow){
							tabBounds.Width += 1;
						} else {
							tabBounds.X -= 1;
							tabBounds.Width += 2;
						}
						break;
					case TabAlignment.Bottom:
						tabBounds.Height += 1;

						if (firstTabinRow){
							tabBounds.Width += 1;
						} else {
							tabBounds.X -= 1;
							tabBounds.Width += 2;
						}
						break;
					case TabAlignment.Left:
						tabBounds.X -= 1;
						tabBounds.Width += 1;

						if (firstTabinRow){
							tabBounds.Height += 1;
						} else {
							tabBounds.Y -= 1;
							tabBounds.Height += 2;
						}
						break;
					case TabAlignment.Right:
						tabBounds.Width += 1;
						if (firstTabinRow){
							tabBounds.Height += 1;
						} else {
							tabBounds.Y -= 1;
							tabBounds.Height += 2;
						}
						break;
				}
			}
			
			//	Adjust first tab in the row to align with tabpage
			this.EnsureFirstTabIsInView(ref tabBounds, index);
			return tabBounds;
		}

        /// <summary>
        /// Gets the tab background brush.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Brush.</returns>
        protected override Brush GetTabBackgroundBrush(int index){
			LinearGradientBrush fillBrush = null;

			//	Capture the colours dependant on selection state of the tab
			Color dark = Color.FromArgb(227, 238, 251);
			Color light = Color.FromArgb(227, 238, 251);
			
			if (this._TabControl.SelectedIndex == index) {
				dark = Color.FromArgb(196, 222, 251);
				light = SystemColors.Window;
			} else if (!this._TabControl.TabPages[index].Enabled){
				light = dark;
			} else if (this.HotTrack && index == this._TabControl.ActiveIndex){
				//	Enable hot tracking
				light = SystemColors.Window;
				dark = Color.FromArgb(166, 203, 248);
			}
			
			//	Get the correctly aligned gradient
			Rectangle tabBounds = this.GetTabRect(index);
			tabBounds.Inflate(3,3);
			tabBounds.X -= 1;
			tabBounds.Y -= 1;
			switch (this._TabControl.Alignment) {
				case TabAlignment.Top:
					fillBrush = new LinearGradientBrush(tabBounds, dark, light, LinearGradientMode.Vertical);
					break;
				case TabAlignment.Bottom:
					fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Vertical);
					break;
				case TabAlignment.Left:
					fillBrush = new LinearGradientBrush(tabBounds, dark, light, LinearGradientMode.Horizontal);
					break;
				case TabAlignment.Right:
					fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Horizontal);
					break;
			}
			
			//	Add the blend
			fillBrush.Blend = this.GetBackgroundBlend(index);
			
			return fillBrush;
		}

        /// <summary>
        /// Gets the background blend.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Blend.</returns>
        private Blend GetBackgroundBlend(int index){
			float[] relativeIntensities = new float[]{0f, 0.7f, 1f};
			float[] relativePositions = new float[]{0f, 0.8f, 1f};

			if (this._TabControl.SelectedIndex != index) {
				relativeIntensities = new float[]{0f, 0.3f, 1f};
				relativePositions = new float[]{0f, 0.2f, 1f};
			}
	
			Blend blend = new Blend();
			blend.Factors = relativeIntensities;
			blend.Positions = relativePositions;
			
			return blend;
		}

        /// <summary>
        /// Draws the tab closer.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="graphics">The graphics.</param>
        protected override void DrawTabCloser(int index, Graphics graphics){
			if (this._ShowTabCloser){
				Rectangle closerRect = this._TabControl.GetTabCloserRect(index);
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				if (closerRect.Contains(this._TabControl.MousePosition)){
					using (GraphicsPath closerPath = GetCloserButtonPath(closerRect)){
						graphics.FillPath(Brushes.White, closerPath);
						using (Pen closerPen = new Pen(this.BorderColor)){
							graphics.DrawPath(closerPen, closerPath);
						}
					}
					using (GraphicsPath closerPath = GetCloserPath(closerRect)){
						using (Pen closerPen = new Pen(this._CloserColorActive)){
							closerPen.Width = 2;
							graphics.DrawPath(closerPen, closerPath);
						}
					}
				} else {
					using (GraphicsPath closerPath = GetCloserPath(closerRect)){
						using (Pen closerPen = new Pen(this._CloserColor)){
							closerPen.Width = 2;
							graphics.DrawPath(closerPen, closerPath);

						}
					}
				}

			}
		}

        /// <summary>
        /// Gets the closer button path.
        /// </summary>
        /// <param name="closerRect">The closer rect.</param>
        /// <returns>GraphicsPath.</returns>
        private static GraphicsPath GetCloserButtonPath(Rectangle closerRect){
			GraphicsPath closerPath = new GraphicsPath();
			closerPath.AddLine(closerRect.X - 1, closerRect.Y - 2, closerRect.Right + 1, closerRect.Y - 2);
			closerPath.AddLine(closerRect.Right + 2, closerRect.Y - 1, closerRect.Right + 2, closerRect.Bottom + 1);
			closerPath.AddLine(closerRect.Right + 1, closerRect.Bottom + 2, closerRect.X - 1, closerRect.Bottom + 2);
			closerPath.AddLine(closerRect.X - 2, closerRect.Bottom + 1, closerRect.X - 2, closerRect.Y - 1);
			closerPath.CloseFigure();
			return closerPath;
		}

        /// <summary>
        /// Gets the page background brush.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Brush.</returns>
        public override Brush GetPageBackgroundBrush(int index){

			//	Capture the colours dependant on selection state of the tab
			Color light = Color.FromArgb(227, 238, 251);
			
			if (this._TabControl.SelectedIndex == index) {
				light = SystemColors.Window;
			} else if (!this._TabControl.TabPages[index].Enabled){
				light = Color.FromArgb(207, 207, 207);
			} else if (this._HotTrack && index == this._TabControl.ActiveIndex){
				//	Enable hot tracking
				light = Color.FromArgb(234, 246, 253);
			}
			
			return new SolidBrush(light);
		}

	}
}
