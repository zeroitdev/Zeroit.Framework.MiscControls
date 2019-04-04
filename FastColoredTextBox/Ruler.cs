// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Ruler.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Class ZeroitCodeTextBoxRuler.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class ZeroitCodeTextBoxRuler : UserControl
    {
        /// <summary>
        /// The target changed
        /// </summary>
        public EventHandler TargetChanged;

        /// <summary>
        /// Gets or sets the back color2.
        /// </summary>
        /// <value>The back color2.</value>
        [DefaultValue(typeof(Color), "ControlLight")]
        public Color BackColor2 { get; set; }

        /// <summary>
        /// Gets or sets the color of the tick.
        /// </summary>
        /// <value>The color of the tick.</value>
        [DefaultValue(typeof(Color), "DarkGray")]
        public Color TickColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the caret tick.
        /// </summary>
        /// <value>The color of the caret tick.</value>
        [DefaultValue(typeof(Color), "Black")]
        public Color CaretTickColor { get; set; }

        /// <summary>
        /// The target
        /// </summary>
        ZeroitCodeTextBox target;

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        [Description("Target ZeroitCodeTextBox")]
        public ZeroitCodeTextBox Target
        {
            get { return target; }
            set
            {
                if (target != null)
                    UnSubscribe(target);
                target = value;
                Subscribe(target);
                OnTargetChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCodeTextBoxRuler"/> class.
        /// </summary>
        public ZeroitCodeTextBoxRuler()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            MinimumSize = new Size(0, 24);
            MaximumSize = new Size(int.MaxValue/2, 24);

            BackColor2 = SystemColors.ControlLight;
            TickColor = Color.DarkGray;
            CaretTickColor = Color.Black;
        }



        /// <summary>
        /// Called when [target changed].
        /// </summary>
        protected virtual void OnTargetChanged()
        {
            if (TargetChanged != null)
                TargetChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Uns the subscribe.
        /// </summary>
        /// <param name="target">The target.</param>
        protected virtual void UnSubscribe(ZeroitCodeTextBox target)
        {
            target.Scroll -= new ScrollEventHandler(target_Scroll);
            target.SelectionChanged -= new EventHandler(target_SelectionChanged);
            target.VisibleRangeChanged -= new EventHandler(target_VisibleRangeChanged);
        }

        /// <summary>
        /// Subscribes the specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        protected virtual void Subscribe(ZeroitCodeTextBox target)
        {
            target.Scroll += new ScrollEventHandler(target_Scroll);
            target.SelectionChanged += new EventHandler(target_SelectionChanged);
            target.VisibleRangeChanged += new EventHandler(target_VisibleRangeChanged);
        }

        /// <summary>
        /// Handles the VisibleRangeChanged event of the target control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void target_VisibleRangeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the target control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void target_SelectionChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Handles the Scroll event of the target control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ScrollEventArgs"/> instance containing the event data.</param>
        protected virtual void target_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (target == null)
                return;

            Point car = PointToClient(target.PointToScreen(target.PlaceToPoint(target.Selection.Start)));

            Size fontSize = TextRenderer.MeasureText("W", Font);

            int column = 0;
            e.Graphics.FillRectangle(new LinearGradientBrush(new Rectangle(0, 0, Width, Height), BackColor, BackColor2, 270), new Rectangle(0, 0, Width, Height));

            float columnWidth = target.CharWidth;
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Near;

            var zeroPoint = target.PositionToPoint(0);
            zeroPoint = PointToClient(target.PointToScreen(zeroPoint));

            using (var pen = new Pen(TickColor))
            using (var textBrush = new SolidBrush(ForeColor))
            for (float x = zeroPoint.X; x < Right; x += columnWidth, ++column)
            {
                if (column % 10 == 0)
                    e.Graphics.DrawString(column.ToString(), Font, textBrush, x, 0f, sf);

                e.Graphics.DrawLine(pen, (int)x, fontSize.Height + (column % 5 == 0 ? 1 : 3), (int)x, Height - 4);
            }

            using (var pen = new Pen(TickColor))
                e.Graphics.DrawLine(pen, new Point(car.X - 3, Height - 3), new Point(car.X + 3, Height - 3));

            using (var pen = new Pen(CaretTickColor))
            {
                e.Graphics.DrawLine(pen, new Point(car.X - 2, fontSize.Height + 3), new Point(car.X - 2, Height - 4));
                e.Graphics.DrawLine(pen, new Point(car.X, fontSize.Height + 1), new Point(car.X, Height - 4));
                e.Graphics.DrawLine(pen, new Point(car.X + 2, fontSize.Height + 3), new Point(car.X + 2, Height - 4));
            }
        }
    }
}
