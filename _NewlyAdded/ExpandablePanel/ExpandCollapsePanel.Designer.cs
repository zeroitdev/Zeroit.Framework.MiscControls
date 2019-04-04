namespace Zeroit.Framework.MiscControls
{
    partial class ZeroitPiperExCollapsePanel
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
            this.components = new System.ComponentModel.Container();
            this._btnExpandCollapse = new Zeroit.Framework.MiscControls.ZeroitPiperExCollapseButton();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // _btnExpandCollapse
            // 
            this._btnExpandCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btnExpandCollapse.ButtonSize = Zeroit.Framework.MiscControls.ZeroitPiperExCollapseButton.ExpandButtonSize.Normal;
            this._btnExpandCollapse.ButtonStyle = Zeroit.Framework.MiscControls.ZeroitPiperExCollapseButton.ExpandButtonStyle.Circle;
            this._btnExpandCollapse.IsExpanded = false;
            this._btnExpandCollapse.Location = new System.Drawing.Point(3, 3);
            this._btnExpandCollapse.Name = "_btnExpandCollapse";
            this._btnExpandCollapse.TabIndex = 0;
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 50;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // ExpandCollapsePanel
            // 
            this.Controls.Add(this._btnExpandCollapse);
            this.Size = new System.Drawing.Size(365, 319);
            this.ResumeLayout(false);

        }

        #endregion

        private Zeroit.Framework.MiscControls.ZeroitPiperExCollapseButton _btnExpandCollapse;
        private System.Windows.Forms.Timer animationTimer;
    }
}
