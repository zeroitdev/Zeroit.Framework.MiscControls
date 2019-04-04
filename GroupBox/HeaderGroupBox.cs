// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="HeaderGroupBox.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region HeaderGroupBox
    /// <summary>
    /// A class collection for rendering a Header GroupBox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.GroupBox" />
    public class ZeroitHeaderGroupBox : System.Windows.Forms.GroupBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitHeaderGroupBox" /> class.
        /// </summary>
        public ZeroitHeaderGroupBox()
        {

        }

        #region Methods and Overrides

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            StringFormat format = new StringFormat();
            format.Trimming = StringTrimming.Character;
            format.Alignment = StringAlignment.Near;
            if (this.RightToLeft == RightToLeft.Yes)
            {
                format.FormatFlags = format.FormatFlags | StringFormatFlags.DirectionRightToLeft;
            }

            SizeF stringSize = e.Graphics.MeasureString(Text, Font, ClientRectangle.Size, format);

            if (Enabled)
            {
                Brush br = new SolidBrush(ForeColor);
                e.Graphics.DrawString(Text, Font, br, ClientRectangle, format);
                br.Dispose();
            }
            else
            {
                ControlPaint.DrawStringDisabled(e.Graphics, Text, Font, BackColor, ClientRectangle, format);
            }

            Pen forePen = new Pen(ControlPaint.LightLight(BackColor), SystemInformation.BorderSize.Height);
            Pen forePenDark = new Pen(ControlPaint.Dark(BackColor), SystemInformation.BorderSize.Height);
            Point lineLeft = new Point(ClientRectangle.Left, ClientRectangle.Top + (int)(Font.Height / 2f));
            Point lineRight = new Point(ClientRectangle.Right, ClientRectangle.Top + (int)(Font.Height / 2f));
            if (this.RightToLeft != RightToLeft.Yes)
            {
                lineLeft.X += (int)stringSize.Width;
            }
            else
            {
                lineRight.X -= (int)stringSize.Width;
            }

            if (FlatStyle == FlatStyle.Flat)
            {
                e.Graphics.DrawLine(forePenDark, lineLeft, lineRight);
            }
            else
            {
                e.Graphics.DrawLine(forePenDark, lineLeft, lineRight);
                lineLeft.Offset(0, (int)Math.Ceiling((float)SystemInformation.BorderSize.Height / 2f));
                lineRight.Offset(0, (int)Math.Ceiling((float)SystemInformation.BorderSize.Height / 2f));
                e.Graphics.DrawLine(forePen, lineLeft, lineRight);
            }
            forePen.Dispose();
            forePenDark.Dispose();
        } 
        
        #endregion

    }
    #endregion

}
