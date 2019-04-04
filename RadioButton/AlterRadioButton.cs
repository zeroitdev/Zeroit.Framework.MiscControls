// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AlterRadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitRadioButtonAlter    
    /// <summary>
    /// A class collection for rendering a radio button.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ThemeControl154" />
    public class ZeroitRadioButtonAlter : ThemeControl154
    {
        /// <summary>
        /// The tb
        /// </summary>
        Brush TB, Inside;
        /// <summary>
        /// The b
        /// </summary>
        Pen B, IB;

        /// <summary>
        /// The checked
        /// </summary>
        private bool _Checked;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitRadioButtonAlter" /> is checked.
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
        /// Occurs when [checked changed].
        /// </summary>
        public event CheckedChangedEventHandler CheckedChanged;
        /// <summary>
        /// Delegate CheckedChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        public delegate void CheckedChangedEventHandler(object sender);

        /// <summary>
        /// Invalidates the controls.
        /// </summary>
        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is ZeroitRadioButtonAlter)
                {
                    ((ZeroitRadioButtonAlter)C).Checked = false;
                }
            }
        }

        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRadioButtonAlter" /> class.
        /// </summary>
        public ZeroitRadioButtonAlter()
        {
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            LockHeight = 22;
            Width = 140;
            Size = new Size(150, 22);
            SetColor("Text", Color.FromArgb(100, 100, 100));
            SetColor("Border", Color.FromArgb(175, 175, 175));
            SetColor("IB", Color.FromArgb(200, 200, 200));
            SetColor("B", Color.FromArgb(150, 150, 150));
        }

        /// <summary>
        /// Colors the hook.
        /// </summary>
        protected override void ColorHook()
        {
            TB = GetBrush("Text");
            B = GetPen("B");
            IB = GetPen("IB");
            Inside = GetBrush("Border");
        }

        /// <summary>
        /// Paints the hook.
        /// </summary>
        protected override void PaintHook()
        {

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(BackColor);
            if (_Checked)
                G.FillEllipse(TB, new Rectangle(new Point(6, 6), new Size(6, 6)));
            if (State == MouseState.Over)
            {
                if (_Checked) { }
                else
                    G.FillEllipse(Inside, new Rectangle(new Point(5, 5), new Size(8, 8)));
            }

            G.DrawEllipse(new Pen(Color.FromArgb(125, 125, 125)), new Rectangle(new Point(1, 1), new Size(16, 16)));
            G.DrawEllipse(new Pen(Color.FromArgb(200, 200, 200)), new Rectangle(new Point(0, 0), new Size(18, 18)));

            G.DrawString(Text, Font, TB, 19, 2);
        }
    }
    #endregion
}
