// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="ComboColorPicker.Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Class ComboColorPicker.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.HelperControls.Widgets.BaseColorPicker" />
    partial class ComboColorPicker
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageWeb = new System.Windows.Forms.TabPage();
            this.webColorPicker = new Zeroit.Framework.MiscControls.HelperControls.Widgets.WebColorPicker();
            this.tabPageSystem = new System.Windows.Forms.TabPage();
            this.systemColorPicker = new Zeroit.Framework.MiscControls.HelperControls.Widgets.SystemColorPicker();
            this.tabPageCustom = new System.Windows.Forms.TabPage();
            this.customColorPicker = new Zeroit.Framework.MiscControls.HelperControls.Widgets.CustomColorPicker();
            this.tabControl.SuspendLayout();
            this.tabPageWeb.SuspendLayout();
            this.tabPageSystem.SuspendLayout();
            this.tabPageCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageWeb);
            this.tabControl.Controls.Add(this.tabPageSystem);
            this.tabControl.Controls.Add(this.tabPageCustom);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(304, 360);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageWeb
            // 
            this.tabPageWeb.Controls.Add(this.webColorPicker);
            this.tabPageWeb.Location = new System.Drawing.Point(4, 22);
            this.tabPageWeb.Name = "tabPageWeb";
            this.tabPageWeb.Size = new System.Drawing.Size(296, 312);
            this.tabPageWeb.TabIndex = 0;
            this.tabPageWeb.Text = "Web";
            this.tabPageWeb.UseVisualStyleBackColor = true;
            // 
            // webColorPicker
            // 
            this.webColorPicker.ColorBoxOffset = 2;
            this.webColorPicker.ColorBoxWidth = 40;
            this.webColorPicker.ColorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webColorPicker.Location = new System.Drawing.Point(0, 0);
            this.webColorPicker.Name = "webColorPicker";
            this.webColorPicker.Size = new System.Drawing.Size(296, 312);
            this.webColorPicker.TabIndex = 0;
            this.webColorPicker.TitleColor = System.Drawing.Color.DarkGray;
            this.webColorPicker.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.webColorPicker.ColorSelected += new Zeroit.Framework.MiscControls.HelperControls.Widgets.BaseColorPicker.ColorSelectedEventHandler(this.tab_ColorSelected);
            // 
            // tabPageSystem
            // 
            this.tabPageSystem.Controls.Add(this.systemColorPicker);
            this.tabPageSystem.Location = new System.Drawing.Point(4, 22);
            this.tabPageSystem.Name = "tabPageSystem";
            this.tabPageSystem.Size = new System.Drawing.Size(296, 312);
            this.tabPageSystem.TabIndex = 1;
            this.tabPageSystem.Text = "System";
            this.tabPageSystem.UseVisualStyleBackColor = true;
            // 
            // systemColorPicker
            // 
            this.systemColorPicker.ColorBoxOffset = 2;
            this.systemColorPicker.ColorBoxWidth = 40;
            this.systemColorPicker.ColorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemColorPicker.Location = new System.Drawing.Point(0, 0);
            this.systemColorPicker.Name = "systemColorPicker";
            this.systemColorPicker.Size = new System.Drawing.Size(296, 312);
            this.systemColorPicker.TabIndex = 0;
            this.systemColorPicker.TitleColor = System.Drawing.Color.DarkGray;
            this.systemColorPicker.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.systemColorPicker.ColorSelected += new Zeroit.Framework.MiscControls.HelperControls.Widgets.BaseColorPicker.ColorSelectedEventHandler(this.tab_ColorSelected);
            // 
            // tabPageCustom
            // 
            this.tabPageCustom.Controls.Add(this.customColorPicker);
            this.tabPageCustom.Location = new System.Drawing.Point(4, 22);
            this.tabPageCustom.Name = "tabPageCustom";
            this.tabPageCustom.Size = new System.Drawing.Size(296, 334);
            this.tabPageCustom.TabIndex = 2;
            this.tabPageCustom.Text = "Custom";
            this.tabPageCustom.UseVisualStyleBackColor = true;
            // 
            // customColorPicker
            // 
            this.customColorPicker.BackColor = System.Drawing.SystemColors.Control;
            this.customColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customColorPicker.Location = new System.Drawing.Point(0, 0);
            this.customColorPicker.MinimumSize = new System.Drawing.Size(120, 120);
            this.customColorPicker.Name = "customColorPicker";
            this.customColorPicker.Size = new System.Drawing.Size(296, 334);
            this.customColorPicker.TabIndex = 0;
            this.customColorPicker.ColorSelected += new Zeroit.Framework.MiscControls.HelperControls.Widgets.BaseColorPicker.ColorSelectedEventHandler(this.tab_ColorSelected);
            // 
            // ComboColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(304, 338);
            this.Name = "ComboColorPicker";
            this.Size = new System.Drawing.Size(304, 360);
            this.tabControl.ResumeLayout(false);
            this.tabPageWeb.ResumeLayout(false);
            this.tabPageSystem.ResumeLayout(false);
            this.tabPageCustom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The tab control
        /// </summary>
        private System.Windows.Forms.TabControl tabControl;
        /// <summary>
        /// The tab page web
        /// </summary>
        private System.Windows.Forms.TabPage tabPageWeb;
        /// <summary>
        /// The web color picker
        /// </summary>
        private WebColorPicker webColorPicker;
        /// <summary>
        /// The tab page system
        /// </summary>
        private System.Windows.Forms.TabPage tabPageSystem;
        /// <summary>
        /// The system color picker
        /// </summary>
        private SystemColorPicker systemColorPicker;
        /// <summary>
        /// The tab page custom
        /// </summary>
        private System.Windows.Forms.TabPage tabPageCustom;
        /// <summary>
        /// The custom color picker
        /// </summary>
        private CustomColorPicker customColorPicker;
    }
}
