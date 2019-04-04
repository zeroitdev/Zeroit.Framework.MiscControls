// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ZeroitSlidingPanel.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitSlidingPanel.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitPlutoGradientPanel" />
    public class ZeroitSlidingPanel : ZeroitPlutoGradientPanel
	{
        /// <summary>
        /// The sleeper
        /// </summary>
        private ZeroitBackgroundSleeper sleeper = new ZeroitBackgroundSleeper();

        /// <summary>
        /// The collapsed
        /// </summary>
        private bool collapsed = true;

        /// <summary>
        /// The panel width expanded
        /// </summary>
        private int panelWidthExpanded = 200;

        /// <summary>
        /// The panel width collapsed
        /// </summary>
        private int panelWidthCollapsed = 50;

        /// <summary>
        /// The hide controls
        /// </summary>
        private bool hideControls = false;

        /// <summary>
        /// The collapse control
        /// </summary>
        private Control collapseControl;

        /// <summary>
        /// Gets or sets the collapse control.
        /// </summary>
        /// <value>The collapse control.</value>
        [Browsable(true)]
		[Category("Zeroit.Framework.DaggerControls")]
		[Description("The control used to collapse/expand the sliding panel")]
		public Control CollapseControl
		{
			get
			{
				return this.collapseControl;
			}
			set
			{
				this.collapseControl = value;
				if (this.collapseControl != null)
				{
					this.collapseControl.Click += new EventHandler(this.SwitchCollapsed);
				}
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitSlidingPanel"/> is collapsed.
        /// </summary>
        /// <value><c>true</c> if collapsed; otherwise, <c>false</c>.</value>
        [Browsable(true)]
		[Category("Zeroit.Framework.DaggerControls")]
		[Description("Is the panel collapsed")]
		public bool Collapsed
		{
			get
			{
				return this.collapsed;
			}
			set
			{
				this.collapsed = value;
				this.CollapseChanged();
				this.CollapsedStateChanged();
				base.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether [hide controls].
        /// </summary>
        /// <value><c>true</c> if [hide controls]; otherwise, <c>false</c>.</value>
        [Browsable(true)]
		[Category("Zeroit.Framework.DaggerControls")]
		[Description("Hide controls when collapsed")]
		public bool HideControls
		{
			get
			{
				return this.hideControls;
			}
			set
			{
				this.hideControls = value;
			}
		}

        /// <summary>
        /// Gets or sets the panel width collapsed.
        /// </summary>
        /// <value>The panel width collapsed.</value>
        [Browsable(true)]
		[Category("Zeroit.Framework.DaggerControls")]
		[Description("The panel width expanded")]
		public int PanelWidthCollapsed
		{
			get
			{
				return this.panelWidthCollapsed;
			}
			set
			{
				this.panelWidthCollapsed = value;
				if (this.Collapsed)
				{
					base.Size = new System.Drawing.Size(this.panelWidthCollapsed, base.Height);
				}
			}
		}

        /// <summary>
        /// Gets or sets the panel width expanded.
        /// </summary>
        /// <value>The panel width expanded.</value>
        [Browsable(true)]
		[Category("Zeroit.Framework.DaggerControls")]
		[Description("The panel width expanded")]
		public int PanelWidthExpanded
		{
			get
			{
				return this.panelWidthExpanded;
			}
			set
			{
				this.panelWidthExpanded = value;
				if (!this.Collapsed)
				{
					base.Size = new System.Drawing.Size(this.panelWidthExpanded, base.Height);
				}
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSlidingPanel"/> class.
        /// </summary>
        public ZeroitSlidingPanel()
		{
			this.Dock = DockStyle.Left;
			this.CollapseChanged();
			base.BottomRight = Color.DodgerBlue;
			base.TopLeft = Color.Black;
			base.TopRight = Color.Black;
			base.BottomLeft = Color.Black;
		}

        /// <summary>
        /// Collapses the changed.
        /// </summary>
        private void CollapseChanged()
		{
			if (!this.collapsed)
			{
				while (base.Width < this.panelWidthExpanded)
				{
					if (base.Width < this.panelWidthExpanded / 10 * 6)
					{
						base.Size = new System.Drawing.Size(base.Width + 30, base.Height);
						this.sleeper.Sleep(40);
					}
					else if (base.Width >= this.panelWidthExpanded / 10 * 4)
					{
						base.Size = new System.Drawing.Size(base.Width + 10, base.Height);
						this.sleeper.Sleep(40);
					}
					else
					{
						base.Size = new System.Drawing.Size(base.Width + 20, base.Height);
						this.sleeper.Sleep(40);
					}
				}
				base.Size = new System.Drawing.Size(this.panelWidthExpanded, base.Height);
				if (this.hideControls)
				{
					foreach (Control control in base.Controls)
					{
						if (control == this.collapseControl)
						{
							continue;
						}
						control.Visible = true;
					}
				}
			}
			else
			{
				if (this.hideControls)
				{
					foreach (Control control1 in base.Controls)
					{
						if (control1 == this.collapseControl)
						{
							continue;
						}
						control1.Visible = false;
					}
				}
				while (base.Width > this.panelWidthCollapsed)
				{
					if (base.Width > this.panelWidthExpanded / 5 * 3)
					{
						base.Size = new System.Drawing.Size(base.Width - 30, base.Height);
						this.sleeper.Sleep(40);
					}
					else if (base.Width <= this.panelWidthExpanded / 5 * 2)
					{
						base.Size = new System.Drawing.Size(base.Width - 10, base.Height);
						this.sleeper.Sleep(40);
					}
					else
					{
						base.Size = new System.Drawing.Size(base.Width - 20, base.Height);
						this.sleeper.Sleep(40);
					}
				}
				base.Size = new System.Drawing.Size(this.panelWidthCollapsed, base.Height);
			}
		}

        /// <summary>
        /// Collapseds the state changed.
        /// </summary>
        protected virtual void CollapsedStateChanged()
		{
			if (this.OnCollapsedStateChanged != null)
			{
				this.OnCollapsedStateChanged(this, new EventArgs());
			}
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.DockChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnDockChanged(EventArgs e)
		{
			base.OnDockChanged(e);
			if (this.Dock != DockStyle.Left & this.Dock != DockStyle.Right)
			{
				this.Dock = DockStyle.Left;
			}
		}

        /// <summary>
        /// Switches the collapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SwitchCollapsed(object sender, EventArgs e)
		{
			if (!this.Collapsed)
			{
				this.Collapsed = true;
			}
			else
			{
				this.Collapsed = false;
			}
		}

        /// <summary>
        /// Occurs when [on collapsed state changed].
        /// </summary>
        public event EventHandler OnCollapsedStateChanged;
	}
}