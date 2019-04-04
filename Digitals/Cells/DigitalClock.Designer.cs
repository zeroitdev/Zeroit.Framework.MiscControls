// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-27-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-27-2018
// ***********************************************************************
// <copyright file="DigitalClock.Designer.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.MiscControls.Digitals.Cells
{
    /// <summary>
    /// Class ZeroitDigitalClock.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.Digitals.Helpers.BaseWControl" />
    partial class ZeroitDigitalClock
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
            this.m_cellHr1 = new Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitSevenCell();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_cellHr2 = new Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitSevenCell();
            this.m_cellMin1 = new Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitSevenCell();
            this.m_cellMin2 = new Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitSevenCell();
            this.m_cellSec1 = new Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitSevenCell();
            this.m_cellSec2 = new Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitSevenCell();
            this.m_colonLeft = new Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitDecimalCell();
            this.m_colonRight = new Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitDecimalCell();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cellHr1
            // 
            this.m_cellHr1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cellHr1.Location = new System.Drawing.Point(0, 0);
            this.m_cellHr1.Margin = new System.Windows.Forms.Padding(0);
            this.m_cellHr1.Name = "m_cellHr1";
            this.m_cellHr1.Size = new System.Drawing.Size(50, 89);
            this.m_cellHr1.TabIndex = 0;
            this.m_cellHr1.Value = '0';
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.33287F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.33287F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.0014F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.33287F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.33287F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.0014F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.33287F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.33287F));
            this.tableLayoutPanel1.Controls.Add(this.m_cellHr1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_cellHr2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_cellMin1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_cellMin2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_cellSec1, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_cellSec2, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_colonLeft, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_colonRight, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(352, 89);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // m_cellHr2
            // 
            this.m_cellHr2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cellHr2.Location = new System.Drawing.Point(50, 0);
            this.m_cellHr2.Margin = new System.Windows.Forms.Padding(0);
            this.m_cellHr2.Name = "m_cellHr2";
            this.m_cellHr2.Size = new System.Drawing.Size(50, 89);
            this.m_cellHr2.TabIndex = 1;
            this.m_cellHr2.Value = '0';
            // 
            // m_cellMin1
            // 
            this.m_cellMin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cellMin1.Location = new System.Drawing.Point(124, 0);
            this.m_cellMin1.Margin = new System.Windows.Forms.Padding(0);
            this.m_cellMin1.Name = "m_cellMin1";
            this.m_cellMin1.Size = new System.Drawing.Size(50, 89);
            this.m_cellMin1.TabIndex = 2;
            this.m_cellMin1.Value = '0';
            // 
            // m_cellMin2
            // 
            this.m_cellMin2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cellMin2.Location = new System.Drawing.Point(174, 0);
            this.m_cellMin2.Margin = new System.Windows.Forms.Padding(0);
            this.m_cellMin2.Name = "m_cellMin2";
            this.m_cellMin2.Size = new System.Drawing.Size(50, 89);
            this.m_cellMin2.TabIndex = 3;
            this.m_cellMin2.Value = '0';
            // 
            // m_cellSec1
            // 
            this.m_cellSec1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cellSec1.Location = new System.Drawing.Point(248, 0);
            this.m_cellSec1.Margin = new System.Windows.Forms.Padding(0);
            this.m_cellSec1.Name = "m_cellSec1";
            this.m_cellSec1.Size = new System.Drawing.Size(50, 89);
            this.m_cellSec1.TabIndex = 4;
            this.m_cellSec1.Value = '0';
            // 
            // m_cellSec2
            // 
            this.m_cellSec2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cellSec2.Location = new System.Drawing.Point(298, 0);
            this.m_cellSec2.Margin = new System.Windows.Forms.Padding(0);
            this.m_cellSec2.Name = "m_cellSec2";
            this.m_cellSec2.Size = new System.Drawing.Size(54, 89);
            this.m_cellSec2.TabIndex = 5;
            this.m_cellSec2.Value = '0';
            // 
            // m_colonLeft
            // 
            this.m_colonLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_colonLeft.Location = new System.Drawing.Point(100, 0);
            this.m_colonLeft.Margin = new System.Windows.Forms.Padding(0);
            this.m_colonLeft.Name = "m_colonLeft";
            this.m_colonLeft.Size = new System.Drawing.Size(24, 89);
            this.m_colonLeft.TabIndex = 6;
            this.m_colonLeft.Value = ':';
            // 
            // m_colonRight
            // 
            this.m_colonRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_colonRight.Location = new System.Drawing.Point(224, 0);
            this.m_colonRight.Margin = new System.Windows.Forms.Padding(0);
            this.m_colonRight.Name = "m_colonRight";
            this.m_colonRight.Size = new System.Drawing.Size(24, 89);
            this.m_colonRight.TabIndex = 7;
            this.m_colonRight.Value = ':';
            // 
            // ZeroitDigitalClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ZeroitDigitalClock";
            this.ShowGradient = false;
            this.Size = new System.Drawing.Size(352, 89);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The m cell HR1
        /// </summary>
        private Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitSevenCell m_cellHr1;
        /// <summary>
        /// The table layout panel1
        /// </summary>
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        /// <summary>
        /// The m cell HR2
        /// </summary>
        private Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitSevenCell m_cellHr2;
        /// <summary>
        /// The m cell min1
        /// </summary>
        private Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitSevenCell m_cellMin1;
        /// <summary>
        /// The m cell min2
        /// </summary>
        private Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitSevenCell m_cellMin2;
        /// <summary>
        /// The m cell sec1
        /// </summary>
        private Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitSevenCell m_cellSec1;
        /// <summary>
        /// The m cell sec2
        /// </summary>
        private Zeroit.Framework.MiscControls.Digitals.Cells.ZeroitSevenCell m_cellSec2;
        /// <summary>
        /// The m colon left
        /// </summary>
        private Cells.ZeroitDecimalCell m_colonLeft;
        /// <summary>
        /// The m colon right
        /// </summary>
        private Cells.ZeroitDecimalCell m_colonRight;

    }
}
