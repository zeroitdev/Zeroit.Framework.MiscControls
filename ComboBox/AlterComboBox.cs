// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AlterComboBox.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitComboBoxAlter    
    /// <summary>
    /// A class collection for rendering a combo box.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ComboBox" />
    public class ZeroitComboBoxAlter : ComboBox
    {

        #region Private Fields
        /// <summary>
        /// The x
        /// </summary>
        private int X;
        /// <summary>
        /// The start index
        /// </summary>
        private int _StartIndex = 0;
        /// <summary>
        /// The b1
        /// </summary>
        private SolidBrush B1, B2, B3;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the start index.
        /// </summary>
        /// <value>The start index.</value>
        public int StartIndex
        {
            get { return _StartIndex; }
            set
            {
                _StartIndex = value;
                try
                {
                    base.SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitComboBoxAlter" /> class.
        /// </summary>
        public ZeroitComboBoxAlter()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);
            DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;

            BackColor = Color.FromArgb(225, 225, 225);
            DropDownStyle = ComboBoxStyle.DropDownList;

            Font = new Font("Verdana", 8);

            B1 = new SolidBrush(Color.FromArgb(230, 230, 230));
            B2 = new SolidBrush(Color.FromArgb(210, 210, 210));
            B3 = new SolidBrush(Color.FromArgb(100, 100, 100));
        }

        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, Graphics G)
        {
            DrawBorders(p1, 0, 0, Width, Height, G);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, int offset, Graphics G)
        {
            DrawBorders(p1, 0, 0, Width, Height, offset, G);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, Graphics G)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }
        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset, Graphics G)
        {
            DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2), G);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            X = e.X;
            base.OnMouseMove(e);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            X = 0;
            base.OnMouseLeave(e);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                X = 0;
            }
            base.OnMouseClick(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            Point[] points = new Point[] { new Point(Width - 15, 9), new Point(Width - 6, 9), new Point(Width - 11, 14) };
            G.Clear(BackColor);
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(220, 220, 220), Color.FromArgb(200, 200, 200), 90F);

            G.FillRectangle(LGB1, new Rectangle(0, 0, Width, Height));

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150))), new Point(Width - 21, 2), new Point(Width - 21, Height));

            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(200, 200, 200))), G);
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150))), 1, G);

            try { G.DrawString((string)Items[SelectedIndex].ToString(), Font, new SolidBrush(Color.FromArgb(100, 100, 100)), new Point(3, 4)); }
            catch { G.DrawString(" . . . ", Font, new SolidBrush(Color.FromArgb(100, 100, 100)), new Point(3, 4)); }

            if (X >= 1)
            {
                LinearGradientBrush LGB3 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(200, 200, 200), Color.FromArgb(220, 220, 220), 90F);
                G.FillRectangle(LGB3, new Rectangle(Width - 20, 2, 18, 17));
                G.FillPolygon(B3, points);
            }
            else
            {
                G.FillPolygon(B3, points);
            }
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ComboBox.DrawItem" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs" /> that contains the event data.</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            LinearGradientBrush LGB1 = new LinearGradientBrush(e.Bounds, Color.FromArgb(120, 120, 120), Color.FromArgb(100, 100, 100), 90);
            HatchBrush HB1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(10, Color.White), Color.Transparent);

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(LGB1, new Rectangle(1, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.Graphics.FillRectangle(HB1, e.Bounds);
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, new SolidBrush(Color.FromArgb(200, 200, 200)), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(B2, e.Bounds);
                try { e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, new SolidBrush(Color.FromArgb(100, 100, 100)), e.Bounds); }
                catch { }
            }

        }

        #endregion

        

    }
    #endregion
}
