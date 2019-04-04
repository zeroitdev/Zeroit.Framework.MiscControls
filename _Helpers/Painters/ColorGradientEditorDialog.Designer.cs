// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="ColorGradientEditorDialog.Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Class ColorGradientEditorDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class ColorGradientEditorDialog
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
            this.colorGradientEditor = new Zeroit.Framework.MiscControls.HelperControls.Widgets.ColorGradientEditor();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorGradientEditor
            // 
            colorBlend1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))))};
            colorBlend1.Positions = new float[] {
        0F,
        0.5F,
        1F};
            this.colorGradientEditor.Blend = colorBlend1;
            this.colorGradientEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorGradientEditor.GradientBackColor = System.Drawing.Color.White;
            this.colorGradientEditor.GradientBorderColor = System.Drawing.Color.DarkGray;
            this.colorGradientEditor.GradientHatchColor = System.Drawing.Color.Black;
            this.colorGradientEditor.Location = new System.Drawing.Point(0, 0);
            this.colorGradientEditor.MarkerBorderColor = System.Drawing.Color.Black;
            this.colorGradientEditor.MarkerFillColor = System.Drawing.Color.White;
            this.colorGradientEditor.MinimumSize = new System.Drawing.Size(322, 120);
            this.colorGradientEditor.Name = "colorGradientEditor";
            this.colorGradientEditor.SelMarkerFillColor = System.Drawing.Color.Yellow;
            this.colorGradientEditor.Size = new System.Drawing.Size(358, 160);
            this.colorGradientEditor.TabIndex = 0;
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitter.IsSplitterFixed = true;
            this.splitter.Location = new System.Drawing.Point(8, 8);
            this.splitter.Name = "splitter";
            this.splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.colorGradientEditor);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.cancelButton);
            this.splitter.Panel2.Controls.Add(this.okButton);
            this.splitter.Size = new System.Drawing.Size(358, 189);
            this.splitter.SplitterDistance = 160;
            this.splitter.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(80, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 24);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(0, 0);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 24);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // ColorGradientEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(374, 205);
            this.Controls.Add(this.splitter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(356, 200);
            this.Name = "ColorGradientEditorDialog";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "Color Gradient Editor";
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The color gradient editor
        /// </summary>
        private ColorGradientEditor colorGradientEditor;
        /// <summary>
        /// The splitter
        /// </summary>
        private System.Windows.Forms.SplitContainer splitter;
        /// <summary>
        /// The cancel button
        /// </summary>
        private System.Windows.Forms.Button cancelButton;
        /// <summary>
        /// The ok button
        /// </summary>
        private System.Windows.Forms.Button okButton;
    }
}