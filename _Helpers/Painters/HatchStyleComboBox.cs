// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="HatchStyleComboBox.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Represents a ComboBox control from which the user can select a hatch style.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ComboBox" />
    [ToolboxItem(false)]
    public class HatchStyleComboBox : ComboBox
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
		public HatchStyleComboBox()
		{
            base.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.this_DrawItem);

			base.BeginUpdate();
			base.DropDownStyle = ComboBoxStyle.DropDownList;
			base.DrawMode = DrawMode.OwnerDrawFixed;
            base.Items.Clear();
			foreach (HatchStyle hs in hatchStyles)
			{
				base.Items.Add(hs);
			}
			base.SelectedIndex = 0;
			base.EndUpdate();
		}

        /// <summary>
        /// Handles the DrawItem event of the this control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        private void this_DrawItem(object sender, DrawItemEventArgs e)
        {
			HatchStyle hs = hatchStyles[e.Index];
			HatchBrush br = new HatchBrush(hs, e.ForeColor, e.BackColor);
			e.Graphics.FillRectangle(br, e.Bounds);
			br.Dispose();
        }

        /// <summary>
        /// Gets list of selectable items.
        /// Overridden member to prevent designer from re-adding list of hatch styles.
        /// </summary>
        /// <value>List of selectable items.</value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new System.Windows.Forms.ComboBox.ObjectCollection Items
		{
			get { return base.Items; }
		}

        /// <summary>
        /// Gets the current drop down style.
        /// Overridden to prevent changing drop down style.
        /// </summary>
        /// <value>The current drop down style.</value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ComboBoxStyle DropDownStyle
		{
			get	{ return base.DropDownStyle; }
		}

        /// <summary>
        /// Gets the current draw mode.
        /// Overridden to prevent changing draw mode.
        /// </summary>
        /// <value>Current draw mode.</value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DrawMode DrawMode
		{
			get	{ return base.DrawMode; }
		}

        /// <summary>
        /// Gets index specifying the currently selected item.
        /// Overridden to prevent an index of -1.
        /// </summary>
        /// <value>Index specifying the currently selected item.</value>
		public new int SelectedIndex
		{
			get { return base.SelectedIndex; }
			set
			{
				base.SelectedIndex = Math.Min(Math.Max(0, value), hatchStyles.Length - 1);
			}
		}

        /// <summary>
        /// Gets or sets currently selected hatch style.
        /// </summary>
        /// <value>Currently selected hatch style.</value>
		public HatchStyle SelectedHatchStyle
		{
            get
            {
                if (base.SelectedItem == null)
                {
                    return HatchStyle.Min;
                }
                return (HatchStyle)base.SelectedItem;
            }
			set
			{
				for (int i = 0; i < hatchStyles.Length; i++)
				{
					if (value == hatchStyles[i])
					{
						base.SelectedIndex = i;
						return;
					}
				}
				base.SelectedIndex = 0;
			}
		}

        /// <summary>
        /// The hatch styles
        /// </summary>
        private static HatchStyle[] hatchStyles = 
		{
			HatchStyle.BackwardDiagonal,
			HatchStyle.Cross,
			HatchStyle.DarkDownwardDiagonal,
			HatchStyle.DarkHorizontal,
			HatchStyle.DarkUpwardDiagonal,
			HatchStyle.DarkVertical,
			HatchStyle.DashedDownwardDiagonal,
			HatchStyle.DashedHorizontal,
			HatchStyle.DashedUpwardDiagonal,
			HatchStyle.DashedVertical,
			HatchStyle.DiagonalBrick,
			HatchStyle.DiagonalCross,
			HatchStyle.Divot,
			HatchStyle.DottedDiamond,
			HatchStyle.DottedGrid,
			HatchStyle.ForwardDiagonal,
			HatchStyle.Horizontal,
			HatchStyle.HorizontalBrick,
			HatchStyle.LargeCheckerBoard,
			HatchStyle.LargeConfetti,
			HatchStyle.LargeGrid,
			HatchStyle.LightDownwardDiagonal   ,
			HatchStyle.LightHorizontal,
			HatchStyle.LightUpwardDiagonal,
			HatchStyle.LightVertical,
			HatchStyle.NarrowHorizontal,
			HatchStyle.NarrowVertical,
			HatchStyle.OutlinedDiamond,
			HatchStyle.Percent05,
			HatchStyle.Percent10,
			HatchStyle.Percent20,
			HatchStyle.Percent25,
			HatchStyle.Percent30,
			HatchStyle.Percent40,
			HatchStyle.Percent50,
			HatchStyle.Percent60,
			HatchStyle.Percent70,
			HatchStyle.Percent75,
			HatchStyle.Percent80,
			HatchStyle.Percent90,
			HatchStyle.Plaid,
			HatchStyle.Shingle,
			HatchStyle.SmallCheckerBoard,
			HatchStyle.SmallConfetti,
			HatchStyle.SmallGrid,
			HatchStyle.SolidDiamond,
			HatchStyle.Sphere,
			HatchStyle.Trellis,
			HatchStyle.Vertical,
			HatchStyle.Wave,
			HatchStyle.Weave,
			HatchStyle.WideDownwardDiagonal,
			HatchStyle.WideUpwardDiagonal,
			HatchStyle.ZigZag 
		};
    }
}
