namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    partial class ColorGradientEditor
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
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.gradientPanel = new Zeroit.Framework.MiscControls.HelperControls.Widgets.NoFlickerPanel();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.newBeforeButton = new System.Windows.Forms.Button();
            this.newAfterButton = new System.Windows.Forms.Button();
            this.stopLabel = new System.Windows.Forms.Label();
            this.delButton = new System.Windows.Forms.Button();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.opacityPreLabel = new System.Windows.Forms.Label();
            this.firstButton = new System.Windows.Forms.Button();
            this.lastButton = new System.Windows.Forms.Button();
            this.alphaNud = new System.Windows.Forms.NumericUpDown();
            this.colorPreLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.postionPreLabel = new System.Windows.Forms.Label();
            this.prevButton = new System.Windows.Forms.Button();
            this.positionNud = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alphaNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionNud)).BeginInit();
            this.SuspendLayout();
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.mainSplit.IsSplitterFixed = true;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            this.mainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.gradientPanel);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.controlPanel);
            this.mainSplit.Panel2.SizeChanged += new System.EventHandler(this.mainSplit_Panel2_SizeChanged);
            this.mainSplit.Size = new System.Drawing.Size(323, 147);
            this.mainSplit.SplitterDistance = 83;
            this.mainSplit.TabIndex = 0;
            this.mainSplit.TabStop = false;
            // 
            // gradientPanel
            // 
            this.gradientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel.Name = "gradientPanel";
            this.gradientPanel.Size = new System.Drawing.Size(323, 83);
            this.gradientPanel.TabIndex = 0;
            this.gradientPanel.SizeChanged += new System.EventHandler(this.gradientPanel_SizeChanged);
            this.gradientPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel_Paint);
            this.gradientPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gradientPanel_MouseDown);
            this.gradientPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientPanel_MouseMove);
            this.gradientPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gradientPanel_MouseUp);
            // 
            // controlPanel
            // 
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel.Controls.Add(this.newBeforeButton);
            this.controlPanel.Controls.Add(this.newAfterButton);
            this.controlPanel.Controls.Add(this.stopLabel);
            this.controlPanel.Controls.Add(this.delButton);
            this.controlPanel.Controls.Add(this.colorLabel);
            this.controlPanel.Controls.Add(this.colorButton);
            this.controlPanel.Controls.Add(this.opacityPreLabel);
            this.controlPanel.Controls.Add(this.firstButton);
            this.controlPanel.Controls.Add(this.lastButton);
            this.controlPanel.Controls.Add(this.alphaNud);
            this.controlPanel.Controls.Add(this.colorPreLabel);
            this.controlPanel.Controls.Add(this.nextButton);
            this.controlPanel.Controls.Add(this.postionPreLabel);
            this.controlPanel.Controls.Add(this.prevButton);
            this.controlPanel.Controls.Add(this.positionNud);
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(322, 60);
            this.controlPanel.TabIndex = 0;
            // 
            // newBeforeButton
            // 
            this.newBeforeButton.Location = new System.Drawing.Point(176, 4);
            this.newBeforeButton.Name = "newBeforeButton";
            this.newBeforeButton.Size = new System.Drawing.Size(48, 23);
            this.newBeforeButton.TabIndex = 4;
            this.newBeforeButton.Text = "< New";
            this.newBeforeButton.UseVisualStyleBackColor = true;
            this.newBeforeButton.Click += new System.EventHandler(this.newBeforeButton_Click);
            // 
            // newAfterButton
            // 
            this.newAfterButton.Location = new System.Drawing.Point(224, 4);
            this.newAfterButton.Name = "newAfterButton";
            this.newAfterButton.Size = new System.Drawing.Size(52, 23);
            this.newAfterButton.TabIndex = 5;
            this.newAfterButton.Text = "New >";
            this.newAfterButton.UseVisualStyleBackColor = true;
            this.newAfterButton.Click += new System.EventHandler(this.newAfterButton_Click);
            // 
            // stopLabel
            // 
            this.stopLabel.Location = new System.Drawing.Point(4, 4);
            this.stopLabel.Name = "stopLabel";
            this.stopLabel.Size = new System.Drawing.Size(72, 21);
            this.stopLabel.TabIndex = 0;
            this.stopLabel.Text = "Stop X/Y:";
            this.stopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(280, 4);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(36, 23);
            this.delButton.TabIndex = 6;
            this.delButton.Text = "Del";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // colorLabel
            // 
            this.colorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorLabel.Location = new System.Drawing.Point(140, 33);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(56, 21);
            this.colorLabel.TabIndex = 10;
            this.colorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colorButton
            // 
            this.colorButton.BackgroundImage = global::Zeroit.Framework.MiscControls.Properties.Resources.Color;
            this.colorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.colorButton.Location = new System.Drawing.Point(196, 32);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(24, 23);
            this.colorButton.TabIndex = 11;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // opacityPreLabel
            // 
            this.opacityPreLabel.Location = new System.Drawing.Point(224, 32);
            this.opacityPreLabel.Name = "opacityPreLabel";
            this.opacityPreLabel.Size = new System.Drawing.Size(44, 21);
            this.opacityPreLabel.TabIndex = 12;
            this.opacityPreLabel.Text = "Alpha:";
            this.opacityPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // firstButton
            // 
            this.firstButton.BackgroundImage = global::Zeroit.Framework.MiscControls.Properties.Resources.First;
            this.firstButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.firstButton.Location = new System.Drawing.Point(76, 4);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(25, 23);
            this.firstButton.TabIndex = 1;
            this.firstButton.UseVisualStyleBackColor = true;
            this.firstButton.Click += new System.EventHandler(this.firstButton_Click);
            // 
            // lastButton
            // 
            this.lastButton.BackgroundImage = global::Zeroit.Framework.MiscControls.Properties.Resources.Last;
            this.lastButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.lastButton.Location = new System.Drawing.Point(148, 4);
            this.lastButton.Name = "lastButton";
            this.lastButton.Size = new System.Drawing.Size(24, 23);
            this.lastButton.TabIndex = 3;
            this.lastButton.UseVisualStyleBackColor = true;
            this.lastButton.Click += new System.EventHandler(this.lastButton_Click);
            // 
            // alphaNud
            // 
            this.alphaNud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaNud.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.alphaNud.Location = new System.Drawing.Point(268, 32);
            this.alphaNud.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaNud.Name = "alphaNud";
            this.alphaNud.Size = new System.Drawing.Size(48, 21);
            this.alphaNud.TabIndex = 13;
            this.alphaNud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.alphaNud.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaNud.ValueChanged += new System.EventHandler(this.alphaNud_ValueChanged);
            // 
            // colorPreLabel
            // 
            this.colorPreLabel.Location = new System.Drawing.Point(100, 32);
            this.colorPreLabel.Name = "colorPreLabel";
            this.colorPreLabel.Size = new System.Drawing.Size(40, 21);
            this.colorPreLabel.TabIndex = 9;
            this.colorPreLabel.Text = "Color:";
            this.colorPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nextButton
            // 
            this.nextButton.BackgroundImage = global::Zeroit.Framework.MiscControls.Properties.Resources.Next;
            this.nextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.nextButton.Location = new System.Drawing.Point(124, 4);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(24, 23);
            this.nextButton.TabIndex = 2;
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // postionPreLabel
            // 
            this.postionPreLabel.Location = new System.Drawing.Point(4, 32);
            this.postionPreLabel.Name = "postionPreLabel";
            this.postionPreLabel.Size = new System.Drawing.Size(48, 21);
            this.postionPreLabel.TabIndex = 7;
            this.postionPreLabel.Text = "Position:";
            this.postionPreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // prevButton
            // 
            this.prevButton.BackgroundImage = global::Zeroit.Framework.MiscControls.Properties.Resources.Prev;
            this.prevButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.prevButton.Location = new System.Drawing.Point(100, 4);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(24, 23);
            this.prevButton.TabIndex = 1;
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // positionNud
            // 
            this.positionNud.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionNud.Location = new System.Drawing.Point(52, 32);
            this.positionNud.Name = "positionNud";
            this.positionNud.Size = new System.Drawing.Size(44, 21);
            this.positionNud.TabIndex = 8;
            this.positionNud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.positionNud.ValueChanged += new System.EventHandler(this.positionNud_ValueChanged);
            // 
            // ColorGradientEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainSplit);
            this.MinimumSize = new System.Drawing.Size(322, 120);
            this.Name = "ColorGradientEditor";
            this.Size = new System.Drawing.Size(323, 147);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alphaNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionNud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.Label postionPreLabel;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button firstButton;
        private System.Windows.Forms.Label colorPreLabel;
        private System.Windows.Forms.NumericUpDown positionNud;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button lastButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.NumericUpDown alphaNud;
        private System.Windows.Forms.Label opacityPreLabel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button newAfterButton;
        private System.Windows.Forms.Label stopLabel;
        private NoFlickerPanel gradientPanel;
        private System.Windows.Forms.Button newBeforeButton;
    }
}
