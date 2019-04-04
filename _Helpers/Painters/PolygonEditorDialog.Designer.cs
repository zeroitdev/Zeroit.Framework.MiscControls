// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="PolygonEditorDialog.Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Class PolygonEditorDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class PolygonEditorDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.gridSplit = new System.Windows.Forms.SplitContainer();
            this.grid = new System.Windows.Forms.DataGridView();
            this.colX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.imageSplit = new System.Windows.Forms.SplitContainer();
            this.imagePanel = new Zeroit.Framework.MiscControls.HelperControls.Widgets.NoFlickerPanel();
            this.controlSplit1 = new System.Windows.Forms.SplitContainer();
            this.controlSplit2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.axesCheckBox = new System.Windows.Forms.CheckBox();
            this.gridCheckBox = new System.Windows.Forms.CheckBox();
            this.panel = new System.Windows.Forms.Panel();
            this.infoSplit = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.gridSplit.Panel1.SuspendLayout();
            this.gridSplit.Panel2.SuspendLayout();
            this.gridSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.imageSplit.Panel1.SuspendLayout();
            this.imageSplit.Panel2.SuspendLayout();
            this.imageSplit.SuspendLayout();
            this.controlSplit1.Panel1.SuspendLayout();
            this.controlSplit1.Panel2.SuspendLayout();
            this.controlSplit1.SuspendLayout();
            this.controlSplit2.Panel1.SuspendLayout();
            this.controlSplit2.Panel2.SuspendLayout();
            this.controlSplit2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            this.panel.SuspendLayout();
            this.infoSplit.Panel1.SuspendLayout();
            this.infoSplit.Panel2.SuspendLayout();
            this.infoSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainSplit.IsSplitterFixed = true;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.gridSplit);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.imageSplit);
            this.mainSplit.Size = new System.Drawing.Size(392, 301);
            this.mainSplit.SplitterDistance = 97;
            this.mainSplit.TabIndex = 1;
            // 
            // gridSplit
            // 
            this.gridSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.gridSplit.IsSplitterFixed = true;
            this.gridSplit.Location = new System.Drawing.Point(0, 0);
            this.gridSplit.Name = "gridSplit";
            this.gridSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // gridSplit.Panel1
            // 
            this.gridSplit.Panel1.Controls.Add(this.grid);
            // 
            // gridSplit.Panel2
            // 
            this.gridSplit.Panel2.Controls.Add(this.cancelButton);
            this.gridSplit.Panel2.Controls.Add(this.okButton);
            this.gridSplit.Panel2.Controls.Add(this.downButton);
            this.gridSplit.Panel2.Controls.Add(this.addButton);
            this.gridSplit.Panel2.Controls.Add(this.delButton);
            this.gridSplit.Panel2.Controls.Add(this.upButton);
            this.gridSplit.Size = new System.Drawing.Size(97, 301);
            this.gridSplit.SplitterDistance = 194;
            this.gridSplit.TabIndex = 6;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colX,
            this.colY});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.Size = new System.Drawing.Size(97, 194);
            this.grid.TabIndex = 1;
            this.grid.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellValidated);
            this.grid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_CellValidating);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // colX
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colX.DefaultCellStyle = dataGridViewCellStyle1;
            this.colX.HeaderText = "X";
            this.colX.Name = "colX";
            // 
            // colY
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colY.DefaultCellStyle = dataGridViewCellStyle2;
            this.colY.HeaderText = "Y";
            this.colY.Name = "colY";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(16, 80);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(64, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(16, 56);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(64, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(48, 24);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(48, 25);
            this.downButton.TabIndex = 3;
            this.downButton.Text = "&Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(0, 0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(48, 25);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "&Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(48, 0);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(48, 25);
            this.delButton.TabIndex = 1;
            this.delButton.Text = "D&el";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(0, 24);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(48, 25);
            this.upButton.TabIndex = 2;
            this.upButton.Text = "&Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // imageSplit
            // 
            this.imageSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.imageSplit.IsSplitterFixed = true;
            this.imageSplit.Location = new System.Drawing.Point(0, 0);
            this.imageSplit.Name = "imageSplit";
            this.imageSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // imageSplit.Panel1
            // 
            this.imageSplit.Panel1.Controls.Add(this.imagePanel);
            // 
            // imageSplit.Panel2
            // 
            this.imageSplit.Panel2.Controls.Add(this.controlSplit1);
            this.imageSplit.Size = new System.Drawing.Size(291, 301);
            this.imageSplit.SplitterDistance = 248;
            this.imageSplit.TabIndex = 1;
            // 
            // imagePanel
            // 
            this.imagePanel.BackColor = System.Drawing.Color.DimGray;
            this.imagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePanel.Location = new System.Drawing.Point(0, 0);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(291, 248);
            this.imagePanel.TabIndex = 0;
            this.imagePanel.SizeChanged += new System.EventHandler(this.imagePanel_SizeChanged);
            this.imagePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.imagePanel_Paint);
            // 
            // controlSplit1
            // 
            this.controlSplit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlSplit1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.controlSplit1.IsSplitterFixed = true;
            this.controlSplit1.Location = new System.Drawing.Point(0, 0);
            this.controlSplit1.Name = "controlSplit1";
            // 
            // controlSplit1.Panel1
            // 
            this.controlSplit1.Panel1.Controls.Add(this.controlSplit2);
            // 
            // controlSplit1.Panel2
            // 
            this.controlSplit1.Panel2.Controls.Add(this.axesCheckBox);
            this.controlSplit1.Panel2.Controls.Add(this.gridCheckBox);
            this.controlSplit1.Size = new System.Drawing.Size(291, 49);
            this.controlSplit1.SplitterDistance = 225;
            this.controlSplit1.TabIndex = 4;
            // 
            // controlSplit2
            // 
            this.controlSplit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlSplit2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.controlSplit2.IsSplitterFixed = true;
            this.controlSplit2.Location = new System.Drawing.Point(0, 0);
            this.controlSplit2.Name = "controlSplit2";
            // 
            // controlSplit2.Panel1
            // 
            this.controlSplit2.Panel1.Controls.Add(this.label1);
            this.controlSplit2.Panel1.Controls.Add(this.zoomLabel);
            // 
            // controlSplit2.Panel2
            // 
            this.controlSplit2.Panel2.Controls.Add(this.zoomTrackBar);
            this.controlSplit2.Size = new System.Drawing.Size(225, 49);
            this.controlSplit2.SplitterDistance = 48;
            this.controlSplit2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zoom:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zoomLabel
            // 
            this.zoomLabel.Location = new System.Drawing.Point(0, 24);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(48, 21);
            this.zoomLabel.TabIndex = 2;
            this.zoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoomTrackBar.Location = new System.Drawing.Point(0, 0);
            this.zoomTrackBar.Maximum = 23;
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Size = new System.Drawing.Size(173, 49);
            this.zoomTrackBar.TabIndex = 1;
            this.zoomTrackBar.Value = 10;
            this.zoomTrackBar.ValueChanged += new System.EventHandler(this.zoomTrackBar_ValueChanged);
            // 
            // axesCheckBox
            // 
            this.axesCheckBox.Checked = true;
            this.axesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.axesCheckBox.Location = new System.Drawing.Point(0, 0);
            this.axesCheckBox.Name = "axesCheckBox";
            this.axesCheckBox.Size = new System.Drawing.Size(56, 21);
            this.axesCheckBox.TabIndex = 2;
            this.axesCheckBox.Text = "Axes";
            this.axesCheckBox.UseVisualStyleBackColor = true;
            this.axesCheckBox.CheckedChanged += new System.EventHandler(this.axesCheckBox_CheckedChanged);
            // 
            // gridCheckBox
            // 
            this.gridCheckBox.Checked = true;
            this.gridCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridCheckBox.Location = new System.Drawing.Point(0, 24);
            this.gridCheckBox.Name = "gridCheckBox";
            this.gridCheckBox.Size = new System.Drawing.Size(56, 21);
            this.gridCheckBox.TabIndex = 3;
            this.gridCheckBox.Text = "Grid";
            this.gridCheckBox.UseVisualStyleBackColor = true;
            this.gridCheckBox.CheckedChanged += new System.EventHandler(this.gridCheckBox_CheckedChanged);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.infoSplit);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Padding = new System.Windows.Forms.Padding(4);
            this.panel.Size = new System.Drawing.Size(400, 345);
            this.panel.TabIndex = 2;
            // 
            // infoSplit
            // 
            this.infoSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.infoSplit.IsSplitterFixed = true;
            this.infoSplit.Location = new System.Drawing.Point(4, 4);
            this.infoSplit.Name = "infoSplit";
            this.infoSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // infoSplit.Panel1
            // 
            this.infoSplit.Panel1.Controls.Add(this.label3);
            // 
            // infoSplit.Panel2
            // 
            this.infoSplit.Panel2.Controls.Add(this.mainSplit);
            this.infoSplit.Size = new System.Drawing.Size(392, 337);
            this.infoSplit.SplitterDistance = 32;
            this.infoSplit.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(392, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Create and edit the polygon by entering the coordinates of the points which make " +
    "up the polygon.";
            // 
            // PolygonEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(400, 345);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PolygonEditorDialog";
            this.Text = "Polygon Editor";
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            this.mainSplit.ResumeLayout(false);
            this.gridSplit.Panel1.ResumeLayout(false);
            this.gridSplit.Panel2.ResumeLayout(false);
            this.gridSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.imageSplit.Panel1.ResumeLayout(false);
            this.imageSplit.Panel2.ResumeLayout(false);
            this.imageSplit.ResumeLayout(false);
            this.controlSplit1.Panel1.ResumeLayout(false);
            this.controlSplit1.Panel2.ResumeLayout(false);
            this.controlSplit1.ResumeLayout(false);
            this.controlSplit2.Panel1.ResumeLayout(false);
            this.controlSplit2.Panel2.ResumeLayout(false);
            this.controlSplit2.Panel2.PerformLayout();
            this.controlSplit2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
            this.panel.ResumeLayout(false);
            this.infoSplit.Panel1.ResumeLayout(false);
            this.infoSplit.Panel2.ResumeLayout(false);
            this.infoSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The main split
        /// </summary>
        private System.Windows.Forms.SplitContainer mainSplit;
        /// <summary>
        /// The grid CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox gridCheckBox;
        /// <summary>
        /// The axes CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox axesCheckBox;
        /// <summary>
        /// The zoom track bar
        /// </summary>
        private System.Windows.Forms.TrackBar zoomTrackBar;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The grid split
        /// </summary>
        private System.Windows.Forms.SplitContainer gridSplit;
        /// <summary>
        /// The grid
        /// </summary>
        private System.Windows.Forms.DataGridView grid;
        /// <summary>
        /// The col x
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn colX;
        /// <summary>
        /// The col y
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn colY;
        /// <summary>
        /// The add button
        /// </summary>
        private System.Windows.Forms.Button addButton;
        /// <summary>
        /// The delete button
        /// </summary>
        private System.Windows.Forms.Button delButton;
        /// <summary>
        /// The ok button
        /// </summary>
        private System.Windows.Forms.Button okButton;
        /// <summary>
        /// The cancel button
        /// </summary>
        private System.Windows.Forms.Button cancelButton;
        /// <summary>
        /// The image panel
        /// </summary>
        private NoFlickerPanel imagePanel;
        /// <summary>
        /// The panel
        /// </summary>
        private System.Windows.Forms.Panel panel;
        /// <summary>
        /// The image split
        /// </summary>
        private System.Windows.Forms.SplitContainer imageSplit;
        /// <summary>
        /// The information split
        /// </summary>
        private System.Windows.Forms.SplitContainer infoSplit;
        /// <summary>
        /// The label3
        /// </summary>
        private System.Windows.Forms.Label label3;
        /// <summary>
        /// The control split1
        /// </summary>
        private System.Windows.Forms.SplitContainer controlSplit1;
        /// <summary>
        /// The control split2
        /// </summary>
        private System.Windows.Forms.SplitContainer controlSplit2;
        /// <summary>
        /// The zoom label
        /// </summary>
        private System.Windows.Forms.Label zoomLabel;
        /// <summary>
        /// Down button
        /// </summary>
        private System.Windows.Forms.Button downButton;
        /// <summary>
        /// Up button
        /// </summary>
        private System.Windows.Forms.Button upButton;
    }
}