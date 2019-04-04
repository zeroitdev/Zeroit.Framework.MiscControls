// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CollapsibleGroupBox.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms.VisualStyles;

namespace Zeroit.Framework.MiscControls
{

    #region Collapsible GroupBox

    #region Control

    /// <summary>
    /// GroupBox control that provides functionality to
    /// allow it to be collapsed.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.GroupBox" />
    [ToolboxBitmap(typeof(ZeroitCollapseGroupBox))]
    public partial class ZeroitCollapseGroupBox : GroupBox
    {
        #region Fields

        /// <summary>
        /// The m toggle rect
        /// </summary>
        private Rectangle m_toggleRect = new Rectangle(8, 2, 11, 11);
        /// <summary>
        /// The m collapsed
        /// </summary>
        private Boolean m_collapsed = false;
        /// <summary>
        /// The m b resizing from collapse
        /// </summary>
        private Boolean m_bResizingFromCollapse = false;

        /// <summary>
        /// The m collapsed height
        /// </summary>
        private const int m_collapsedHeight = 20;
        /// <summary>
        /// The m full size
        /// </summary>
        private Size m_FullSize = Size.Empty;

        #endregion

        #region Events & Delegates

        /// <summary>
        /// Fired when the Collapse Toggle button is pressed
        /// </summary>
        /// <param name="sender">The sender.</param>
        public delegate void CollapseBoxClickedEventHandler(object sender);
        /// <summary>
        /// Occurs when [collapse box clicked event].
        /// </summary>
        public event CollapseBoxClickedEventHandler CollapseBoxClickedEvent;

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCollapseGroupBox" /> class.
        /// </summary>
        public ZeroitCollapseGroupBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets the full height.
        /// </summary>
        /// <value>The full height.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FullHeight
        {
            get { return m_FullSize.Height; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this control is collapsible.
        /// </summary>
        /// <value><c>true</c> if this instance is collapsed; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCollapsed
        {
            get { return m_collapsed; }
            set
            {
                if (value != m_collapsed)
                {
                    m_collapsed = value;

                    if (!value)
                        // Expand
                        this.Size = m_FullSize;
                    else
                    {
                        // Collapse
                        m_bResizingFromCollapse = true;
                        this.Height = m_collapsedHeight;
                        m_bResizingFromCollapse = false;
                    }

                    foreach (Control c in Controls)
                        c.Visible = !value;

                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets the collapsed height.
        /// </summary>
        /// <value>The height of the collapsed.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CollapsedHeight
        {
            get { return m_collapsedHeight; }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (m_toggleRect.Contains(e.Location))
                ToggleCollapsed();
            else
                base.OnMouseUp(e);
        }

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            HandleResize();
            DrawGroupBox(e.Graphics);
            DrawToggleButton(e.Graphics);
        }

        #endregion

        #region Implimentation

        /// <summary>
        /// Draws the group box.
        /// </summary>
        /// <param name="g">The g.</param>
        void DrawGroupBox(Graphics g)
        {
            // Get windows to draw the GroupBox
            Rectangle bounds = new Rectangle(ClientRectangle.X, ClientRectangle.Y + 6, ClientRectangle.Width, ClientRectangle.Height - 6);
            GroupBoxRenderer.DrawGroupBox(g, bounds, Enabled ? GroupBoxState.Normal : GroupBoxState.Disabled);

            // Text Formating positioning & Size
            StringFormat sf = new StringFormat();
            int i_textPos = (bounds.X + 8) + m_toggleRect.Width + 2;
            int i_textSize = (int)g.MeasureString(Text, this.Font).Width;
            i_textSize = i_textSize < 1 ? 1 : i_textSize;
            int i_endPos = i_textPos + i_textSize + 1;

            // Draw a line to cover the GroupBox border where the text will sit
            g.DrawLine(SystemPens.Control, i_textPos, bounds.Y, i_endPos, bounds.Y);

            // Draw the GroupBox text
            using (SolidBrush drawBrush = new SolidBrush(Color.FromArgb(0, 70, 213)))
                g.DrawString(Text, this.Font, drawBrush, i_textPos, 0);
        }

        /// <summary>
        /// Draws the toggle button.
        /// </summary>
        /// <param name="g">The g.</param>
        void DrawToggleButton(Graphics g)
        {
            if (IsCollapsed)
                g.DrawImage(Properties.Resources.plus, m_toggleRect);
            else
                g.DrawImage(Properties.Resources.minus, m_toggleRect);
        }

        /// <summary>
        /// Toggles the collapsed.
        /// </summary>
        void ToggleCollapsed()
        {
            IsCollapsed = !IsCollapsed;

            if (CollapseBoxClickedEvent != null)
                CollapseBoxClickedEvent(this);
        }

        /// <summary>
        /// Handles the resize.
        /// </summary>
        void HandleResize()
        {
            if (!m_bResizingFromCollapse && !m_collapsed)
                m_FullSize = this.Size;
        }

        #endregion
    }

    #endregion

    #region Designer Generated Code

    partial class ZeroitCollapseGroupBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroitCollapseGroupBox));
            this.SuspendLayout();
            // 
            // ZeroitCollapseGroupBox
            // 
            this.Name = "ZeroitCollapseGroupBox";
            this.ResumeLayout(false);

        }

        #endregion
    }

    #endregion

    #endregion

}
