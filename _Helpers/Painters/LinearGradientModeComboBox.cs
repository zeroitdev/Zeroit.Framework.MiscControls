// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="LinearGradientModeComboBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    /// Represents a ComboBox control from which the user can select a linear gradient mode.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ComboBox" />
    [ToolboxItem(false)]
    public class LinearGradientModeComboBox : ComboBox
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
		public LinearGradientModeComboBox()
		{
			base.BeginUpdate();
			base.DropDownStyle = ComboBoxStyle.DropDownList;
            base.Items.Clear();
			base.Items.Add(LinearGradientMode.Horizontal);
			base.Items.Add(LinearGradientMode.Vertical);
			base.Items.Add(LinearGradientMode.BackwardDiagonal);
			base.Items.Add(LinearGradientMode.ForwardDiagonal);
			base.SelectedIndex = 0;
			base.EndUpdate();
		}

        /// <summary>
        /// Gets list of selectable items.
        /// Overridden member to prevent designer from re-adding list of linear gradient mode values.
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
				base.SelectedIndex = Math.Min(Math.Max(0, value), base.Items.Count - 1);
			}
		}

        /// <summary>
        /// Gets or sets currently selected linear gradient mode.
        /// </summary>
        /// <value>Currently selected linear gradient mode.</value>
		public LinearGradientMode SelectedMode
		{
            get
            {
				if (base.SelectedItem == null)
				{
					return LinearGradientMode.Horizontal;
				}
            	return (LinearGradientMode)base.SelectedItem;
            }
			set
			{
				for (int i = 0; i < base.Items.Count; i++)
				{
					if (value == (LinearGradientMode)base.Items[i])
					{
						base.SelectedIndex = i;
						return;
					}
				}
				base.SelectedIndex = 0;
			}
		}
    }
}
