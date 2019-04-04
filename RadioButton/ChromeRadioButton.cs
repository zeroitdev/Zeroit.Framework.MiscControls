// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ChromeRadioButton.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitRadioButtonChrome    
    /// <summary>
    /// A class collection for rendering a chrome radio button.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ThemeControl154" />
    [DefaultEventAttribute("CheckedChanged")]
    public class ZeroitChromeRadioButton : ThemeControl154
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitChromeRadioButton" /> class.
        /// </summary>
        public ZeroitChromeRadioButton()
        {
            Font = new Font("Segoe UI", 9);
            LockHeight = 17;
            SetColor("Text", 60, 60, 60);
            SetColor("Gradient top", 237, 237, 237);
            SetColor("Gradient bottom", 230, 230, 230);
            SetColor("Borders", 167, 167, 167);
            SetColor("Bullet", 100, 100, 100);
            Width = 180;


            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            //BackColor = Color.Transparent;

        }

        /// <summary>
        /// The x
        /// </summary>
        private int X;
        /// <summary>
        /// The text color
        /// </summary>
        private Color TextColor;
        /// <summary>
        /// The g1
        /// </summary>
        private Color G1;
        /// <summary>
        /// The g2
        /// </summary>
        private Color G2;
        /// <summary>
        /// The bo
        /// </summary>
        private Color Bo;

        /// <summary>
        /// The bb
        /// </summary>
        private Color Bb;
        /// <summary>
        /// Colors the hook.
        /// </summary>
        protected override void ColorHook()
        {
            TextColor = GetColor("Text");
            G1 = GetColor("Gradient top");
            G2 = GetColor("Gradient bottom");
            Bb = GetColor("Bullet");
            Bo = GetColor("Borders");
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }

        /// <summary>
        /// Paints the hook.
        /// </summary>
        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;
            if (_Checked)
            {
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 14)), G1, G2, 90f);
                G.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(14, 14)));
            }
            else
            {
                LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 16)), G1, G2, 90f);
                G.FillEllipse(LGB, new Rectangle(new Point(0, 0), new Size(14, 14)));
            }

            if (State == MouseState.Over & X < 15)
            {
                SolidBrush SB = new SolidBrush(Color.FromArgb(10, Color.Black));
                G.FillEllipse(SB, new Rectangle(new Point(0, 0), new Size(14, 14)));
            }
            else if (State == MouseState.Down & X < 15)
            {
                SolidBrush SB = new SolidBrush(Color.FromArgb(20, Color.Black));
                G.FillEllipse(SB, new Rectangle(new Point(0, 0), new Size(14, 14)));
            }

            GraphicsPath P = new GraphicsPath();
            P.AddEllipse(new Rectangle(0, 0, 14, 14));
            G.SetClip(P);

            LinearGradientBrush LLGGBB = new LinearGradientBrush(new Rectangle(0, 0, 14, 5), Color.FromArgb(150, Color.White), Color.Transparent, 90f);
            G.FillRectangle(LLGGBB, LLGGBB.Rectangle);

            G.ResetClip();

            G.DrawEllipse(new Pen(Bo), new Rectangle(new Point(0, 0), new Size(14, 14)));

            if (_Checked)
            {
                SolidBrush LGB = new SolidBrush(Bb);
                G.FillEllipse(LGB, new Rectangle(new Point(4, 4), new Size(6, 6)));
            }

            DrawText(new SolidBrush(TextColor), HorizontalAlignment.Left, 17, -2);
        }

        /// <summary>
        /// The field
        /// </summary>
        private int _Field = 16;

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>The field.</value>
        public int Field
        {
            get { return _Field; }
            set
            {
                if (value < 4)
                    return;
                _Field = value;
                LockHeight = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The checked
        /// </summary>
        private bool _Checked;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitChromeRadioButton" /> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Occurs when the has checked and changed.
        /// </summary>
        public event CheckedChangedEventHandler CheckedChanged;

        /// <summary>
        /// Delegate CheckedChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        public delegate void CheckedChangedEventHandler(object sender);

        /// <summary>
        /// Called when [creation].
        /// </summary>
        protected override void OnCreation()
        {
            InvalidateControls();
        }

        /// <summary>
        /// Invalidates the controls.
        /// </summary>
        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is ZeroitChromeRadioButton)
                {
                    ((ZeroitChromeRadioButton)C).Checked = false;
                }
            }
        }

    }
    #endregion
}
