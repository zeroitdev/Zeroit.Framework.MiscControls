// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-04-2018
// ***********************************************************************
// <copyright file="gTrackBar.Designer.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Design;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitMultiTrackBar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class ZeroitMultiTrackBar : System.Windows.Forms.UserControl
	{
        //UserControl1 overrides dispose to clean up the component list.
        /// <summary>
        /// The instance fields initialized
        /// </summary>
        private bool InstanceFieldsInitialized = false;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        [System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

        //Required by the Windows Form Designer
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        /// <summary>
        /// Initializes the component.
        /// </summary>
        [System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.SuspendLayout();
			//
			//ZeroitMultiTrackBar
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "multiTrackBar";
			this.Size = new System.Drawing.Size(300, 43);
			this.ResumeLayout(false);

            this.Load += new System.EventHandler(TBSlider_Load);
			this.MouseDown += new MouseEventHandler(TBSlider_MouseDown);
			this.MouseLeave += new System.EventHandler(gTrackBar_MouseLeave);
			this.MouseMove += new MouseEventHandler(TBSlider_MouseMove);
			this.MouseUp += new MouseEventHandler(TBSlider_MouseUp);
			this.MouseWheel += new MouseEventHandler(TBSlider_MouseWheel);
			this.KeyUp += new KeyEventHandler(gTrackBar_KeyUp);
			this.Resize += new System.EventHandler(TBSlider_Resize);
			this.LostFocus += new System.EventHandler(gTrackBar_LostFocus);
			this.GotFocus += new System.EventHandler(gTrackBar_LostFocus);
		}



        /// <summary>
        /// The events subscribed
        /// </summary>
        private bool EventsSubscribed = false;
        /// <summary>
        /// Subscribes to events.
        /// </summary>
        private void SubscribeToEvents()
		{
			if (EventsSubscribed)
				return;
			else
				EventsSubscribed = true;

			MouseTimer.Tick += MouseTimer_Tick;
		}

	}

}