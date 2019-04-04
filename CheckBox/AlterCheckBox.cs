// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AlterCheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region ZeroitCheckBoxAlter    
    /// <summary>
    /// A class collection for rendering a.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ThemeControl154" />
    public class ZeroitCheckBoxAlter : ThemeControl154
    {

        #region Fields, Events and Delegates

        /// <summary>
        /// The bg
        /// </summary>
        Color BG;
        /// <summary>
        /// The tb
        /// </summary>
        Brush TB, IN;
        /// <summary>
        /// The ib
        /// </summary>
        Pen IB, B;

        /// <summary>
        /// The checked
        /// </summary>
        private bool _Checked;
        /// <summary>
        /// Occurs when [checked changed].
        /// </summary>
        public event CheckedChangedEventHandler CheckedChanged;
        /// <summary>
        /// Delegate CheckedChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        public delegate void CheckedChangedEventHandler(object sender);

        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitCheckBoxAlter" /> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCheckBoxAlter" /> class.
        /// </summary>
        public ZeroitCheckBoxAlter()
        {
            LockHeight = 22;
            SetColor("BG", Color.FromArgb(240, 240, 240));
            SetColor("Texts", Color.FromArgb(100, 100, 100));
            SetColor("Inside", Color.FromArgb(175, 175, 175));
            SetColor("IB", Color.FromArgb(200, 200, 200));
            SetColor("B", Color.FromArgb(150, 150, 150));
            Size = new Size(150, 22);
        }

        #endregion

        #region Overrides
        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_Checked == true)
                _Checked = false;
            else
                _Checked = true;
        }

        /// <summary>
        /// Colors the hook.
        /// </summary>
        protected override void ColorHook()
        {
            BG = GetColor("BG");
            TB = GetBrush("Texts");
            IN = GetBrush("Inside");
            IB = GetPen("IB");
            B = GetPen("B");
        }

        /// <summary>
        /// Paints the hook.
        /// </summary>
        protected override void PaintHook()
        {
            if (AllowTransparency)
            {
                MakeTransparent(this, G);
            }

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            if (_Checked)
                G.DrawString("a", new Font("Marlett", 12), TB, new Point(-1, 1));

            if (State == MouseState.Over)
            {
                G.FillRectangle(IN, new Rectangle(new Point(4, 4), new Size(10, 10)));
                if (_Checked)
                    G.DrawString("a", new Font("Marlett", 12), TB, new Point(-1, 1));
            }

            G.DrawRectangle(B, 2, 2, 14, 14);
            G.DrawRectangle(IB, 1, 1, 16, 16);
            G.DrawString(Text, Font, TB, 19, 3);
        }

        #endregion





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
        private static void MakeTransparent(Control control, Graphics g)
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
    #endregion
    
}
