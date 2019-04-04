// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="CustomColorPickerDialog.Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Class CustomColorPickerDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class CustomColorPickerDialog
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
            this.customColorPicker = new Zeroit.Framework.MiscControls.HelperControls.Widgets.CustomColorPicker();
            this.SuspendLayout();
            // 
            // customColorPicker
            // 
            this.customColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customColorPicker.Location = new System.Drawing.Point(0, 0);
            this.customColorPicker.MinimumSize = new System.Drawing.Size(288, 300);
            this.customColorPicker.Name = "customColorPicker";
            this.customColorPicker.Size = new System.Drawing.Size(296, 334);
            this.customColorPicker.TabIndex = 0;
            this.customColorPicker.ColorSelected += new Zeroit.Framework.MiscControls.HelperControls.Widgets.BaseColorPicker.ColorSelectedEventHandler(this.customColorPicker_ColorSelected);
            // 
            // CustomColorPickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 334);
            this.Controls.Add(this.customColorPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomColorPickerDialog";
            this.Text = "Custom Color Picker";
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The custom color picker
        /// </summary>
        private Zeroit.Framework.MiscControls.HelperControls.Widgets.CustomColorPicker customColorPicker;
    }
}