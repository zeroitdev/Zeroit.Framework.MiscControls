// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="WebColorPickerDialog.Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Class WebColorPickerDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    partial class WebColorPickerDialog
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
            this.webColorPicker = new Zeroit.Framework.MiscControls.HelperControls.Widgets.WebColorPicker();
            this.SuspendLayout();
            // 
            // webColorPicker
            // 
            this.webColorPicker.ColorBoxOffset = 2;
            this.webColorPicker.ColorBoxWidth = 40;
            this.webColorPicker.ColorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webColorPicker.Location = new System.Drawing.Point(0, 0);
            this.webColorPicker.Name = "webColorPicker";
            this.webColorPicker.Size = new System.Drawing.Size(164, 175);
            this.webColorPicker.TabIndex = 0;
            this.webColorPicker.TitleColor = System.Drawing.Color.DarkGray;
            this.webColorPicker.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.webColorPicker.ColorSelected += new Zeroit.Framework.MiscControls.HelperControls.Widgets.BaseColorPicker.ColorSelectedEventHandler(this.webColorPicker_ColorSelected);
            // 
            // WebColorPickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(164, 175);
            this.Controls.Add(this.webColorPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "WebColorPickerDialog";
            this.Text = "Web Color Picker";
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The web color picker
        /// </summary>
        private Zeroit.Framework.MiscControls.HelperControls.Widgets.WebColorPicker webColorPicker;
    }
}