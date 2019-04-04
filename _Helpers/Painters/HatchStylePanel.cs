// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="HatchStylePanel.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Represents a control for displaying a hatch pattern.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public partial class HatchStylePanel : UserControl
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public HatchStylePanel()
        {
            InitializeComponent();

			this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
						  ControlStyles.AllPaintingInWmPaint |
						  ControlStyles.ResizeRedraw |
						  ControlStyles.UserPaint, true);

			this.UpdateStyles();
        }

        /// <summary>
        /// The hatch color
        /// </summary>
        private Color hatchColor = Color.Black;
        /// <summary>
        /// Gets or sets hatch color.
        /// </summary>
        /// <value>Hatch color.</value>
        public Color HatchColor
        {
            get { return hatchColor; }
            set
            {
                hatchColor = value;
                Redraw();
            }
        }

        /// <summary>
        /// Gets or sets background color.
        /// </summary>
        /// <value>Background color.</value>
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                Redraw();
            }
        }

        /// <summary>
        /// The hatch style
        /// </summary>
        private HatchStyle hatchStyle = HatchStyle.Cross;
        /// <summary>
        /// Gets or sets hatch style.
        /// </summary>
        /// <value>Hatch style.</value>
        public HatchStyle HatchStyle
        {
            get { return hatchStyle; }
            set
            {
                hatchStyle = value;
                Redraw();
            }
        }

        /// <summary>
        /// Set hatch style, hatch color, and background color.
        /// </summary>
        /// <param name="hatchStyle">Hatch style.</param>
        /// <param name="hatchColor">Hatch color.</param>
        /// <param name="backColor">Background color.</param>
		public void Set(HatchStyle hatchStyle, Color hatchColor, Color backColor)
		{
			this.hatchStyle = hatchStyle;
			this.hatchColor = hatchColor;
			this.BackColor = backColor;
			Redraw();
		}

        /// <summary>
        /// The br
        /// </summary>
        private Brush br = null;

        /// <summary>
        /// Redraws this instance.
        /// </summary>
        private void Redraw()
        {
            if (br != null)
            {
                br.Dispose();
                br = null;
            }
            Invalidate(true);
        }

        /// <summary>
        /// Handles the Paint event of the this control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void this_Paint(object sender, PaintEventArgs e)
        {
            if (br == null)
            {
                br = new HatchBrush(hatchStyle, hatchColor, BackColor);
			}
            e.Graphics.FillRectangle(br, this.ClientRectangle);
        }
    }
}
