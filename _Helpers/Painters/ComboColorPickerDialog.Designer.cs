// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="ComboColorPickerDialog.Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Class ComboColorPickerDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class ComboColorPickerDialog
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
            this.comboColorPicker = new Zeroit.Framework.MiscControls.HelperControls.Widgets.ComboColorPicker();
            this.SuspendLayout();
            // 
            // comboColorPicker
            // 
            this.comboColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboColorPicker.Location = new System.Drawing.Point(0, 0);
            this.comboColorPicker.MinimumSize = new System.Drawing.Size(304, 338);
            this.comboColorPicker.Name = "comboColorPicker";
            this.comboColorPicker.Size = new System.Drawing.Size(308, 364);
            this.comboColorPicker.TabIndex = 0;
            this.comboColorPicker.ColorSelected += new Zeroit.Framework.MiscControls.HelperControls.Widgets.BaseColorPicker.ColorSelectedEventHandler(this.comboColorPicker_ColorSelected);
            // 
            // ComboColorPickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 364);
            this.Controls.Add(this.comboColorPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(324, 398);
            this.Name = "ComboColorPickerDialog";
            this.Text = "Color Picker";
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The combo color picker
        /// </summary>
        private ComboColorPicker comboColorPicker;
    }
}