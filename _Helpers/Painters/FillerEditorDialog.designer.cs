// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="FillerEditorDialog.designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Class FillerEditorDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class FillerEditorDialog
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
            System.Drawing.Drawing2D.ColorBlend colorBlend1 = new System.Drawing.Drawing2D.ColorBlend();
            this.emptyRadioButton = new System.Windows.Forms.RadioButton();
            this.solidRadioButton = new System.Windows.Forms.RadioButton();
            this.noneRadioButton = new System.Windows.Forms.RadioButton();
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.gradientRadioButton = new System.Windows.Forms.RadioButton();
            this.hatchRadioButton = new System.Windows.Forms.RadioButton();
            this.solidGroupBox = new System.Windows.Forms.GroupBox();
            this.sampleSolidPanel = new System.Windows.Forms.Label();
            this.opacityPreLabel = new System.Windows.Forms.Label();
            this.solidAlphaNud = new System.Windows.Forms.NumericUpDown();
            this.solidColorButton = new System.Windows.Forms.Button();
            this.solidColorLabel = new System.Windows.Forms.Label();
            this.solidColorTextLabel = new System.Windows.Forms.Label();
            this.hatchGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.backAlphaNud = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.hatchAlphaNud = new System.Windows.Forms.NumericUpDown();
            this.hatchComboBox = new Zeroit.Framework.MiscControls.HelperControls.Widgets.HatchStyleComboBox();
            this.sampleHatchPanel = new Zeroit.Framework.MiscControls.HelperControls.Widgets.HatchStylePanel();
            this.hatchPatternTextLabel = new System.Windows.Forms.Label();
            this.backColorButton = new System.Windows.Forms.Button();
            this.backColorLabel = new System.Windows.Forms.Label();
            this.backColorTextLabel = new System.Windows.Forms.Label();
            this.hatchColorButton = new System.Windows.Forms.Button();
            this.hatchColorLabel = new System.Windows.Forms.Label();
            this.hatchColorTextLabel = new System.Windows.Forms.Label();
            this.gradientGroupBox = new System.Windows.Forms.GroupBox();
            this.gradientTypeComboBox = new System.Windows.Forms.ComboBox();
            this.gradientAngleNud = new System.Windows.Forms.NumericUpDown();
            this.gradientAngleTextLabel = new System.Windows.Forms.Label();
            this.gradientTypeTextLabel = new System.Windows.Forms.Label();
            this.gradientEditor = new Zeroit.Framework.MiscControls.HelperControls.Widgets.ColorGradientEditor();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.typeGroupBox.SuspendLayout();
            this.solidGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solidAlphaNud)).BeginInit();
            this.hatchGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backAlphaNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hatchAlphaNud)).BeginInit();
            this.gradientGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientAngleNud)).BeginInit();
            this.SuspendLayout();
            // 
            // emptyRadioButton
            // 
            this.emptyRadioButton.Location = new System.Drawing.Point(16, 16);
            this.emptyRadioButton.Name = "emptyRadioButton";
            this.emptyRadioButton.Size = new System.Drawing.Size(128, 24);
            this.emptyRadioButton.TabIndex = 0;
            this.emptyRadioButton.TabStop = true;
            this.emptyRadioButton.Text = "Empty (transparent)";
            this.emptyRadioButton.UseVisualStyleBackColor = true;
            // 
            // solidRadioButton
            // 
            this.solidRadioButton.Location = new System.Drawing.Point(16, 48);
            this.solidRadioButton.Name = "solidRadioButton";
            this.solidRadioButton.Size = new System.Drawing.Size(120, 24);
            this.solidRadioButton.TabIndex = 1;
            this.solidRadioButton.TabStop = true;
            this.solidRadioButton.Text = "Solid (one color)";
            this.solidRadioButton.UseVisualStyleBackColor = true;
            this.solidRadioButton.CheckedChanged += new System.EventHandler(this.fillerTypeChanged);
            // 
            // noneRadioButton
            // 
            this.noneRadioButton.Location = new System.Drawing.Point(16, 24);
            this.noneRadioButton.Name = "noneRadioButton";
            this.noneRadioButton.Size = new System.Drawing.Size(120, 24);
            this.noneRadioButton.TabIndex = 0;
            this.noneRadioButton.TabStop = true;
            this.noneRadioButton.Text = "None (transparent)";
            this.noneRadioButton.UseVisualStyleBackColor = true;
            this.noneRadioButton.CheckedChanged += new System.EventHandler(this.fillerTypeChanged);
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.Controls.Add(this.gradientRadioButton);
            this.typeGroupBox.Controls.Add(this.hatchRadioButton);
            this.typeGroupBox.Controls.Add(this.noneRadioButton);
            this.typeGroupBox.Controls.Add(this.solidRadioButton);
            this.typeGroupBox.Location = new System.Drawing.Point(8, 8);
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.Size = new System.Drawing.Size(144, 128);
            this.typeGroupBox.TabIndex = 0;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = " Fill Type ";
            // 
            // gradientRadioButton
            // 
            this.gradientRadioButton.Location = new System.Drawing.Point(16, 96);
            this.gradientRadioButton.Name = "gradientRadioButton";
            this.gradientRadioButton.Size = new System.Drawing.Size(120, 24);
            this.gradientRadioButton.TabIndex = 3;
            this.gradientRadioButton.TabStop = true;
            this.gradientRadioButton.Text = "Gradient";
            this.gradientRadioButton.UseVisualStyleBackColor = true;
            this.gradientRadioButton.CheckedChanged += new System.EventHandler(this.fillerTypeChanged);
            // 
            // hatchRadioButton
            // 
            this.hatchRadioButton.Location = new System.Drawing.Point(16, 72);
            this.hatchRadioButton.Name = "hatchRadioButton";
            this.hatchRadioButton.Size = new System.Drawing.Size(120, 24);
            this.hatchRadioButton.TabIndex = 2;
            this.hatchRadioButton.TabStop = true;
            this.hatchRadioButton.Text = "Hatch pattern";
            this.hatchRadioButton.UseVisualStyleBackColor = true;
            this.hatchRadioButton.CheckedChanged += new System.EventHandler(this.fillerTypeChanged);
            // 
            // solidGroupBox
            // 
            this.solidGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.solidGroupBox.Controls.Add(this.sampleSolidPanel);
            this.solidGroupBox.Controls.Add(this.opacityPreLabel);
            this.solidGroupBox.Controls.Add(this.solidAlphaNud);
            this.solidGroupBox.Controls.Add(this.solidColorButton);
            this.solidGroupBox.Controls.Add(this.solidColorLabel);
            this.solidGroupBox.Controls.Add(this.solidColorTextLabel);
            this.solidGroupBox.Location = new System.Drawing.Point(160, 8);
            this.solidGroupBox.Name = "solidGroupBox";
            this.solidGroupBox.Size = new System.Drawing.Size(352, 88);
            this.solidGroupBox.TabIndex = 3;
            this.solidGroupBox.TabStop = false;
            this.solidGroupBox.Text = " Solid (one color) ";
            // 
            // sampleSolidPanel
            // 
            this.sampleSolidPanel.Location = new System.Drawing.Point(208, 24);
            this.sampleSolidPanel.Name = "sampleSolidPanel";
            this.sampleSolidPanel.Size = new System.Drawing.Size(128, 48);
            this.sampleSolidPanel.TabIndex = 11;
            this.sampleSolidPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // opacityPreLabel
            // 
            this.opacityPreLabel.Location = new System.Drawing.Point(48, 52);
            this.opacityPreLabel.Name = "opacityPreLabel";
            this.opacityPreLabel.Size = new System.Drawing.Size(48, 21);
            this.opacityPreLabel.TabIndex = 9;
            this.opacityPreLabel.Text = "Alpha:";
            this.opacityPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // solidAlphaNud
            // 
            this.solidAlphaNud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solidAlphaNud.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.solidAlphaNud.Location = new System.Drawing.Point(96, 52);
            this.solidAlphaNud.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.solidAlphaNud.Name = "solidAlphaNud";
            this.solidAlphaNud.Size = new System.Drawing.Size(48, 21);
            this.solidAlphaNud.TabIndex = 10;
            this.solidAlphaNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.solidAlphaNud.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.solidAlphaNud.ValueChanged += new System.EventHandler(this.solidAlphaNud_ValueChanged);
            // 
            // solidColorButton
            // 
            this.solidColorButton.BackgroundImage = global::Zeroit.Framework.MiscControls.Properties.Resources.Color;
            this.solidColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.solidColorButton.Location = new System.Drawing.Point(168, 24);
            this.solidColorButton.Name = "solidColorButton";
            this.solidColorButton.Size = new System.Drawing.Size(24, 23);
            this.solidColorButton.TabIndex = 3;
            this.solidColorButton.UseVisualStyleBackColor = true;
            this.solidColorButton.Click += new System.EventHandler(this.solidColorButton_Click);
            // 
            // solidColorLabel
            // 
            this.solidColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.solidColorLabel.Location = new System.Drawing.Point(96, 24);
            this.solidColorLabel.Name = "solidColorLabel";
            this.solidColorLabel.Size = new System.Drawing.Size(72, 23);
            this.solidColorLabel.TabIndex = 2;
            this.solidColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // solidColorTextLabel
            // 
            this.solidColorTextLabel.Location = new System.Drawing.Point(8, 24);
            this.solidColorTextLabel.Name = "solidColorTextLabel";
            this.solidColorTextLabel.Size = new System.Drawing.Size(88, 23);
            this.solidColorTextLabel.TabIndex = 1;
            this.solidColorTextLabel.Text = "Color: ";
            this.solidColorTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hatchGroupBox
            // 
            this.hatchGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.hatchGroupBox.Controls.Add(this.label4);
            this.hatchGroupBox.Controls.Add(this.backAlphaNud);
            this.hatchGroupBox.Controls.Add(this.label1);
            this.hatchGroupBox.Controls.Add(this.hatchAlphaNud);
            this.hatchGroupBox.Controls.Add(this.hatchComboBox);
            this.hatchGroupBox.Controls.Add(this.sampleHatchPanel);
            this.hatchGroupBox.Controls.Add(this.hatchPatternTextLabel);
            this.hatchGroupBox.Controls.Add(this.backColorButton);
            this.hatchGroupBox.Controls.Add(this.backColorLabel);
            this.hatchGroupBox.Controls.Add(this.backColorTextLabel);
            this.hatchGroupBox.Controls.Add(this.hatchColorButton);
            this.hatchGroupBox.Controls.Add(this.hatchColorLabel);
            this.hatchGroupBox.Controls.Add(this.hatchColorTextLabel);
            this.hatchGroupBox.Location = new System.Drawing.Point(160, 104);
            this.hatchGroupBox.Name = "hatchGroupBox";
            this.hatchGroupBox.Size = new System.Drawing.Size(352, 168);
            this.hatchGroupBox.TabIndex = 4;
            this.hatchGroupBox.TabStop = false;
            this.hatchGroupBox.Text = " Hatch pattern ";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(48, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "Alpha:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // backAlphaNud
            // 
            this.backAlphaNud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backAlphaNud.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.backAlphaNud.Location = new System.Drawing.Point(96, 108);
            this.backAlphaNud.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.backAlphaNud.Name = "backAlphaNud";
            this.backAlphaNud.Size = new System.Drawing.Size(48, 21);
            this.backAlphaNud.TabIndex = 16;
            this.backAlphaNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.backAlphaNud.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.backAlphaNud.ValueChanged += new System.EventHandler(this.backAlphaNud_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(48, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "Alpha:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hatchAlphaNud
            // 
            this.hatchAlphaNud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hatchAlphaNud.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.hatchAlphaNud.Location = new System.Drawing.Point(96, 52);
            this.hatchAlphaNud.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.hatchAlphaNud.Name = "hatchAlphaNud";
            this.hatchAlphaNud.Size = new System.Drawing.Size(48, 21);
            this.hatchAlphaNud.TabIndex = 13;
            this.hatchAlphaNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hatchAlphaNud.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.hatchAlphaNud.ValueChanged += new System.EventHandler(this.hatchAlphaNud_ValueChanged);
            // 
            // hatchComboBox
            // 
            this.hatchComboBox.FormattingEnabled = true;
            this.hatchComboBox.Location = new System.Drawing.Point(96, 136);
            this.hatchComboBox.Name = "hatchComboBox";
            this.hatchComboBox.SelectedHatchStyle = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            this.hatchComboBox.Size = new System.Drawing.Size(96, 21);
            this.hatchComboBox.TabIndex = 10;
            this.hatchComboBox.SelectedIndexChanged += new System.EventHandler(this.hatchComboBox_SelectedIndexChanged);
            // 
            // sampleHatchPanel
            // 
            this.sampleHatchPanel.HatchColor = System.Drawing.Color.White;
            this.sampleHatchPanel.HatchStyle = System.Drawing.Drawing2D.HatchStyle.LargeGrid;
            this.sampleHatchPanel.Location = new System.Drawing.Point(208, 24);
            this.sampleHatchPanel.Name = "sampleHatchPanel";
            this.sampleHatchPanel.Size = new System.Drawing.Size(128, 132);
            this.sampleHatchPanel.TabIndex = 9;
            // 
            // hatchPatternTextLabel
            // 
            this.hatchPatternTextLabel.Location = new System.Drawing.Point(8, 136);
            this.hatchPatternTextLabel.Name = "hatchPatternTextLabel";
            this.hatchPatternTextLabel.Size = new System.Drawing.Size(88, 23);
            this.hatchPatternTextLabel.TabIndex = 7;
            this.hatchPatternTextLabel.Text = "Hatch pattern:";
            this.hatchPatternTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // backColorButton
            // 
            this.backColorButton.BackgroundImage = global::Zeroit.Framework.MiscControls.Properties.Resources.Color;
            this.backColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.backColorButton.Location = new System.Drawing.Point(168, 80);
            this.backColorButton.Name = "backColorButton";
            this.backColorButton.Size = new System.Drawing.Size(24, 23);
            this.backColorButton.TabIndex = 6;
            this.backColorButton.UseVisualStyleBackColor = true;
            this.backColorButton.Click += new System.EventHandler(this.backColorButton_Click);
            // 
            // backColorLabel
            // 
            this.backColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backColorLabel.Location = new System.Drawing.Point(96, 80);
            this.backColorLabel.Name = "backColorLabel";
            this.backColorLabel.Size = new System.Drawing.Size(72, 23);
            this.backColorLabel.TabIndex = 5;
            this.backColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backColorTextLabel
            // 
            this.backColorTextLabel.Location = new System.Drawing.Point(8, 80);
            this.backColorTextLabel.Name = "backColorTextLabel";
            this.backColorTextLabel.Size = new System.Drawing.Size(88, 23);
            this.backColorTextLabel.TabIndex = 4;
            this.backColorTextLabel.Text = "Back color: ";
            this.backColorTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hatchColorButton
            // 
            this.hatchColorButton.BackgroundImage = global::Zeroit.Framework.MiscControls.Properties.Resources.Color;
            this.hatchColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.hatchColorButton.Location = new System.Drawing.Point(168, 24);
            this.hatchColorButton.Name = "hatchColorButton";
            this.hatchColorButton.Size = new System.Drawing.Size(24, 23);
            this.hatchColorButton.TabIndex = 3;
            this.hatchColorButton.UseVisualStyleBackColor = true;
            this.hatchColorButton.Click += new System.EventHandler(this.hatchColorButton_Click);
            // 
            // hatchColorLabel
            // 
            this.hatchColorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hatchColorLabel.Location = new System.Drawing.Point(96, 24);
            this.hatchColorLabel.Name = "hatchColorLabel";
            this.hatchColorLabel.Size = new System.Drawing.Size(72, 24);
            this.hatchColorLabel.TabIndex = 2;
            this.hatchColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hatchColorTextLabel
            // 
            this.hatchColorTextLabel.Location = new System.Drawing.Point(8, 24);
            this.hatchColorTextLabel.Name = "hatchColorTextLabel";
            this.hatchColorTextLabel.Size = new System.Drawing.Size(88, 23);
            this.hatchColorTextLabel.TabIndex = 1;
            this.hatchColorTextLabel.Text = "Hatch color: ";
            this.hatchColorTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gradientGroupBox
            // 
            this.gradientGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.gradientGroupBox.Controls.Add(this.gradientTypeComboBox);
            this.gradientGroupBox.Controls.Add(this.gradientAngleNud);
            this.gradientGroupBox.Controls.Add(this.gradientAngleTextLabel);
            this.gradientGroupBox.Controls.Add(this.gradientTypeTextLabel);
            this.gradientGroupBox.Controls.Add(this.gradientEditor);
            this.gradientGroupBox.Location = new System.Drawing.Point(160, 280);
            this.gradientGroupBox.Name = "gradientGroupBox";
            this.gradientGroupBox.Size = new System.Drawing.Size(352, 192);
            this.gradientGroupBox.TabIndex = 5;
            this.gradientGroupBox.TabStop = false;
            this.gradientGroupBox.Text = " Gradient ";
            // 
            // gradientTypeComboBox
            // 
            this.gradientTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradientTypeComboBox.FormattingEnabled = true;
            this.gradientTypeComboBox.Items.AddRange(new object[] {
            "Linear",
            "PathRect",
            "PathRadial"});
            this.gradientTypeComboBox.Location = new System.Drawing.Point(96, 160);
            this.gradientTypeComboBox.Name = "gradientTypeComboBox";
            this.gradientTypeComboBox.Size = new System.Drawing.Size(104, 21);
            this.gradientTypeComboBox.TabIndex = 2;
            this.gradientTypeComboBox.SelectedValueChanged += new System.EventHandler(this.gradientTypeComboBox_SelectedValueChanged);
            // 
            // gradientAngleNud
            // 
            this.gradientAngleNud.DecimalPlaces = 1;
            this.gradientAngleNud.Location = new System.Drawing.Point(272, 162);
            this.gradientAngleNud.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.gradientAngleNud.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.gradientAngleNud.Name = "gradientAngleNud";
            this.gradientAngleNud.Size = new System.Drawing.Size(64, 20);
            this.gradientAngleNud.TabIndex = 4;
            this.gradientAngleNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gradientAngleTextLabel
            // 
            this.gradientAngleTextLabel.Location = new System.Drawing.Point(224, 160);
            this.gradientAngleTextLabel.Name = "gradientAngleTextLabel";
            this.gradientAngleTextLabel.Size = new System.Drawing.Size(48, 23);
            this.gradientAngleTextLabel.TabIndex = 3;
            this.gradientAngleTextLabel.Text = "Angle: ";
            this.gradientAngleTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gradientTypeTextLabel
            // 
            this.gradientTypeTextLabel.Location = new System.Drawing.Point(16, 160);
            this.gradientTypeTextLabel.Name = "gradientTypeTextLabel";
            this.gradientTypeTextLabel.Size = new System.Drawing.Size(80, 23);
            this.gradientTypeTextLabel.TabIndex = 1;
            this.gradientTypeTextLabel.Text = "Gradient type: ";
            this.gradientTypeTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gradientEditor
            // 
            colorBlend1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))))};
            colorBlend1.Positions = new float[] {
        0F,
        0.5F,
        1F};
            this.gradientEditor.Blend = colorBlend1;
            this.gradientEditor.GradientBackColor = System.Drawing.Color.White;
            this.gradientEditor.GradientBorderColor = System.Drawing.Color.DarkGray;
            this.gradientEditor.GradientHatchColor = System.Drawing.Color.Black;
            this.gradientEditor.Location = new System.Drawing.Point(16, 24);
            this.gradientEditor.MarkerBorderColor = System.Drawing.Color.Black;
            this.gradientEditor.MarkerFillColor = System.Drawing.Color.White;
            this.gradientEditor.MinimumSize = new System.Drawing.Size(322, 120);
            this.gradientEditor.Name = "gradientEditor";
            this.gradientEditor.SelMarkerFillColor = System.Drawing.Color.Yellow;
            this.gradientEditor.Size = new System.Drawing.Size(322, 120);
            this.gradientEditor.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(80, 144);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(67, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(8, 144);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(67, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // FillerEditorDialog
            // 
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(524, 484);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.gradientGroupBox);
            this.Controls.Add(this.hatchGroupBox);
            this.Controls.Add(this.solidGroupBox);
            this.Controls.Add(this.typeGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FillerEditorDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Filler Editor";
            this.typeGroupBox.ResumeLayout(false);
            this.solidGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.solidAlphaNud)).EndInit();
            this.hatchGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backAlphaNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hatchAlphaNud)).EndInit();
            this.gradientGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientAngleNud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The empty RadioButton
        /// </summary>
        private System.Windows.Forms.RadioButton emptyRadioButton;
        /// <summary>
        /// The none RadioButton
        /// </summary>
        private System.Windows.Forms.RadioButton noneRadioButton;
        /// <summary>
        /// The solid RadioButton
        /// </summary>
        private System.Windows.Forms.RadioButton solidRadioButton;
        /// <summary>
        /// The type group box
        /// </summary>
        private System.Windows.Forms.GroupBox typeGroupBox;
        /// <summary>
        /// The gradient RadioButton
        /// </summary>
        private System.Windows.Forms.RadioButton gradientRadioButton;
        /// <summary>
        /// The hatch RadioButton
        /// </summary>
        private System.Windows.Forms.RadioButton hatchRadioButton;
        /// <summary>
        /// The solid group box
        /// </summary>
        private System.Windows.Forms.GroupBox solidGroupBox;
        /// <summary>
        /// The solid color button
        /// </summary>
        private System.Windows.Forms.Button solidColorButton;
        /// <summary>
        /// The solid color label
        /// </summary>
        private System.Windows.Forms.Label solidColorLabel;
        /// <summary>
        /// The solid color text label
        /// </summary>
        private System.Windows.Forms.Label solidColorTextLabel;
        /// <summary>
        /// The hatch group box
        /// </summary>
        private System.Windows.Forms.GroupBox hatchGroupBox;
        /// <summary>
        /// The back color button
        /// </summary>
        private System.Windows.Forms.Button backColorButton;
        /// <summary>
        /// The back color label
        /// </summary>
        private System.Windows.Forms.Label backColorLabel;
        /// <summary>
        /// The back color text label
        /// </summary>
        private System.Windows.Forms.Label backColorTextLabel;
        /// <summary>
        /// The hatch color button
        /// </summary>
        private System.Windows.Forms.Button hatchColorButton;
        /// <summary>
        /// The hatch color label
        /// </summary>
        private System.Windows.Forms.Label hatchColorLabel;
        /// <summary>
        /// The hatch color text label
        /// </summary>
        private System.Windows.Forms.Label hatchColorTextLabel;
        /// <summary>
        /// The hatch pattern text label
        /// </summary>
        private System.Windows.Forms.Label hatchPatternTextLabel;
        /// <summary>
        /// The gradient group box
        /// </summary>
        private System.Windows.Forms.GroupBox gradientGroupBox;
        /// <summary>
        /// The gradient editor
        /// </summary>
        private ColorGradientEditor gradientEditor;
        /// <summary>
        /// The cancel button
        /// </summary>
        private System.Windows.Forms.Button cancelButton;
        /// <summary>
        /// The ok button
        /// </summary>
        private System.Windows.Forms.Button okButton;
        /// <summary>
        /// The sample hatch panel
        /// </summary>
        private HatchStylePanel sampleHatchPanel;
        /// <summary>
        /// The hatch ComboBox
        /// </summary>
        private HatchStyleComboBox hatchComboBox;
        /// <summary>
        /// The gradient type text label
        /// </summary>
        private System.Windows.Forms.Label gradientTypeTextLabel;
        /// <summary>
        /// The gradient angle nud
        /// </summary>
        private System.Windows.Forms.NumericUpDown gradientAngleNud;
        /// <summary>
        /// The gradient angle text label
        /// </summary>
        private System.Windows.Forms.Label gradientAngleTextLabel;
        /// <summary>
        /// The gradient type ComboBox
        /// </summary>
        private System.Windows.Forms.ComboBox gradientTypeComboBox;
        /// <summary>
        /// The opacity pre label
        /// </summary>
        private System.Windows.Forms.Label opacityPreLabel;
        /// <summary>
        /// The solid alpha nud
        /// </summary>
        private System.Windows.Forms.NumericUpDown solidAlphaNud;
        /// <summary>
        /// The label4
        /// </summary>
        private System.Windows.Forms.Label label4;
        /// <summary>
        /// The back alpha nud
        /// </summary>
        private System.Windows.Forms.NumericUpDown backAlphaNud;
        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// The hatch alpha nud
        /// </summary>
        private System.Windows.Forms.NumericUpDown hatchAlphaNud;
        /// <summary>
        /// The sample solid panel
        /// </summary>
        private System.Windows.Forms.Label sampleSolidPanel;
    }
}