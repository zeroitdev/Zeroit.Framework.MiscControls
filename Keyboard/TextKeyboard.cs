// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TextKeyboard.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region Text Keyboard Helper

    #region Onscreen Keyboard Form

    /// <summary>
    /// A class collection for rendering an On Screen Keyboard.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class OnScreenKeyboardForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// The ws ex noactivate
        /// </summary>
        const int WS_EX_NOACTIVATE = 0x08000000;
        /// <summary>
        /// The ws ex topmost
        /// </summary>
        const int WS_EX_TOPMOST = 0x00000008;
        /// <summary>
        /// The ws ex windowedge
        /// </summary>
        const int WS_EX_WINDOWEDGE = 0x00000100;
        /// <summary>
        /// The ws child
        /// </summary>
        const int WS_CHILD = 0x40000000;
        /// <summary>
        /// The ws ex toolwindow
        /// </summary>
        private const int WS_EX_TOOLWINDOW = 0x00000080;


        /// <summary>
        /// Gets the create parameters.
        /// </summary>
        /// <value>The create parameters.</value>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams ret = base.CreateParams;
                ret.Style =
                   WS_CHILD;
                ret.ExStyle |= WS_EX_NOACTIVATE |
                    WS_EX_TOPMOST |
                    WS_EX_WINDOWEDGE |
                    WS_EX_TOOLWINDOW;
                ret.X = LocationPoint.X;
                ret.Y = LocationPoint.Y;
                return ret;
            }
        }

        /// <summary>
        /// Gets or sets the location point.
        /// </summary>
        /// <value>The location point.</value>
        public Point LocationPoint
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnScreenKeyboardForm" /> class.
        /// </summary>
        public OnScreenKeyboardForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnScreenKeyboardForm"/> class.
        /// </summary>
        /// <param name="isNumeric">if set to <c>true</c> [is numeric].</param>
        /// <param name="isCapsLock">if set to <c>true</c> [is caps lock].</param>
        /// <param name="isNumLock">if set to <c>true</c> [is number lock].</param>
        /// <param name="isShift">if set to <c>true</c> [is shift].</param>
        /// <param name="isAlt">if set to <c>true</c> [is alt].</param>
        /// <param name="isCtrl">if set to <c>true</c> [is control].</param>
        public OnScreenKeyboardForm(bool isNumeric, bool isCapsLock, bool isNumLock,
            bool isShift, bool isAlt, bool isCtrl)
        {
            InitializeComponent();

            virtualKeyboard.IsNumeric = isNumeric;
            virtualKeyboard.CapsLockState = isCapsLock;
            virtualKeyboard.NumLockState = isNumLock;
            virtualKeyboard.ShiftState = isShift;
            virtualKeyboard.AltState = isAlt;
            virtualKeyboard.CtrlState = isCtrl;

        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
            this.TransparencyKey = Color.Silver;
        }
    }

    #endregion

    #region Onscreen Keyboard Form Designer Generated Code

    partial class OnScreenKeyboardForm
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
            this.virtualKeyboard = new ZeroitVirtualKeyboard();
            this.SuspendLayout();
            // 
            // virtualKeyboard
            // 
            this.virtualKeyboard.AltState = false;
            this.virtualKeyboard.BackColor = System.Drawing.Color.Transparent;
            this.virtualKeyboard.BackgroundColor = System.Drawing.Color.Transparent;
            this.virtualKeyboard.BeginGradientColor = System.Drawing.Color.White;
            this.virtualKeyboard.BorderColor = System.Drawing.Color.Black;
            this.virtualKeyboard.ButtonBorderColor = System.Drawing.Color.DarkGray;
            this.virtualKeyboard.ButtonRectRadius = 6;
            this.virtualKeyboard.CapsLockState = false;
            this.virtualKeyboard.ColorPressedState = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(145)))), ((int)(((byte)(78)))));
            this.virtualKeyboard.CtrlState = false;
            this.virtualKeyboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtualKeyboard.EndGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.virtualKeyboard.FontColor = System.Drawing.Color.Black;
            this.virtualKeyboard.FontColorSpecialKey = System.Drawing.Color.DimGray;
            this.virtualKeyboard.IsNumeric = false;
            this.virtualKeyboard.LabelFont = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.virtualKeyboard.LabelFontSpecialKey = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.virtualKeyboard.Location = new System.Drawing.Point(0, 0);
            this.virtualKeyboard.Name = "virtualKeyboard";
            this.virtualKeyboard.NumLockState = false;
            this.virtualKeyboard.ShadowColor = System.Drawing.Color.Gray;
            this.virtualKeyboard.ShadowShift = 5;
            this.virtualKeyboard.ShiftState = false;
            this.virtualKeyboard.ShowBackground = true;
            this.virtualKeyboard.ShowFunctionButtons = false;
            this.virtualKeyboard.ShowNumericButtons = false;
            this.virtualKeyboard.Size = new System.Drawing.Size(684, 237);
            this.virtualKeyboard.TabIndex = 0;
            this.virtualKeyboard.Text = "virtualKeyboard1";
            // 
            // OnScreenKeyboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 237);
            this.Controls.Add(this.virtualKeyboard);
            this.Name = "OnScreenKeyboardForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The virtual keyboard
        /// </summary>
        private ZeroitVirtualKeyboard virtualKeyboard;
    }

    #endregion

    #endregion


}
