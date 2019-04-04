// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ComboBox    
    /// <summary>
    /// A class collection for rendering a combo box.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ComboBox" />
    public class ZeroitComboBox : ComboBox
    {

        #region Variables

        /// <summary>
        /// The start index
        /// </summary>
        private int _StartIndex = 0;
        /// <summary>
        /// The hover selection color
        /// </summary>
        private Color _HoverSelectionColor = Color.FromArgb(241, 241, 241);

        /// <summary>
        /// The style
        /// </summary>
        private ComboBoxStyle style = ComboBoxStyle.DropDownList;



        #endregion

        #region Custom Properties        
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

        /// <summary>
        /// Gets or sets the color on hover selection.
        /// </summary>
        /// <value>The color on hover selection.</value>
        public Color HoverSelectionColor
        {
            get { return _HoverSelectionColor; }
            set
            {
                _HoverSelectionColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the drop style.
        /// </summary>
        /// <value>The drop style.</value>
        public ComboBoxStyle DropStyle
        {
            get { return DropDownStyle; }
            set
            {
                DropDownStyle = value;
                Invalidate();
            }
        }

        #endregion

        #region EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ComboBox.DrawItem" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.DrawItemEventArgs" /> that contains the event data.</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(_HoverSelectionColor), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }

            if (!(e.Index == -1))
            {
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, Brushes.DimGray, e.Bounds);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            SuspendLayout();
            Update();
            ResumeLayout();
        }

        /// <summary>
        /// Handles the <see cref="E:PaintBackground" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitComboBox" /> class.
        /// </summary>
        public ZeroitComboBox()
        {
            SetStyle(/*(ControlStyles)139286 | */ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Selectable, false);

            DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;

            //BackColor = Color.FromArgb(246, 246, 246);
            ForeColor = Color.FromArgb(142, 142, 142);
            Size = new Size(135, 26);
            ItemHeight = 20;
            DropDownHeight = 100;
            Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }
        #endregion

        #region Methods and Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            LinearGradientBrush LGB = default(LinearGradientBrush);
            GraphicsPath GP = default(GraphicsPath);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;




            // Create a curvy border
            GP = RoundRectangle.RoundRect(0, 0, Width - 1, Height - 1, 5);
            // Fills the body of the rectangle with a gradient
            LGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(241, 241, 241), Color.FromArgb(241, 241, 241), 90f);

            e.Graphics.Clear(BackColor);
            e.Graphics.SetClip(GP);
            e.Graphics.FillRectangle(LGB, ClientRectangle);
            e.Graphics.ResetClip();

            // Draw rectangle border
            e.Graphics.DrawPath(new Pen(Color.FromArgb(204, 204, 204)), GP);
            // Draw string
            e.Graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(142, 142, 142)), new Rectangle(3, 0, Width - 20, Height), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            });

            // Draw the dropdown arrow
            e.Graphics.DrawLine(new Pen(Color.FromArgb(160, 160, 160), 2), new Point(Width - 18, 10), new Point(Width - 14, 14));
            e.Graphics.DrawLine(new Pen(Color.FromArgb(160, 160, 160), 2), new Point(Width - 14, 14), new Point(Width - 10, 10));
            e.Graphics.DrawLine(new Pen(Color.FromArgb(160, 160, 160)), new Point(Width - 14, 15), new Point(Width - 14, 14));





            GP.Dispose();
            LGB.Dispose();
        } 
        
        #endregion

    }

    #endregion
}
