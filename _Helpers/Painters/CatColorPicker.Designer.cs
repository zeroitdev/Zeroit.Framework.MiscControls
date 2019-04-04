namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    partial class CatColorPicker
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
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.panel = new Zeroit.Framework.MiscControls.HelperControls.Widgets.NoFlickerPanel();
            this.SuspendLayout();
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.LargeChange = 1;
            this.vScrollBar.Location = new System.Drawing.Point(133, 0);
            this.vScrollBar.Maximum = 2;
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 150);
            this.vScrollBar.TabIndex = 1;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(133, 150);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_MouseClick);
            this.panel.SizeChanged += new System.EventHandler(this.panel_SizeChanged);
            this.panel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.panel_KeyDown);
            // 
            // BaseColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.vScrollBar);
            this.Name = "BaseColorPicker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar;
        private NoFlickerPanel panel;
    }
}
