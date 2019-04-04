// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Control.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region frmMain

    #region Designer Generated

    /// <summary>
    /// Class ZeroitCurveArrow.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    partial class ZeroitCurveArrow
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
            this.SuspendLayout();
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 798);
            this.Name = "frmMain";
            this.Text = "Test";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }

    #endregion

    #region Control

    /// <summary>
    /// A class collection for rendering an curly arrows
    /// </summary>
    public partial class ZeroitCurveArrow : UserControl
    {
        private ArrowRenderer a;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCurveArrow" /> class.
        /// </summary>
        public ZeroitCurveArrow()
        {
            InitializeComponent();
            ResizeRedraw = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            a = new ArrowRenderer(15, (float)Math.PI / 6, true);
            a.SetThetaInDegrees(90);
        }


        /// <summary>
        /// Handles the Paint event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            //draw two regular arrows, one using regular arrow-rendering method, the other using Bezier curves
            a.DrawArrow(e.Graphics, Pens.Crimson, Brushes.DodgerBlue, 30, 0, 80, 90);
            a.DrawArrowOnCurve(e.Graphics, Pens.Black, Brushes.Blue, 30, 0, 100, 70, 40, 10, 50, 20);

            //draw some random-colored curved arrows
            e.Graphics.TranslateTransform(Width / 2, Height / 2);
            //e.Graphics.ScaleTransform(0.6f, 0.6f);
            for (int i = 0; i < 360; i += 15)
            {
                Random rr = new Random((int)DateTime.Now.Ticks);
                using (Pen pp = new Pen(Color.FromArgb(2 * rr.Next(127), 2 * rr.Next(127), 2 * rr.Next(127)), 1.5f))
                using (Brush bb = new SolidBrush(Color.FromArgb(2 * rr.Next(127), 2 * rr.Next(127), 2 * rr.Next(127))))
                    a.DrawArrowOnCurve(e.Graphics, pp, bb, 0, 0, 300, 120, 40, 160, 280, -220);
                e.Graphics.RotateTransform(15);
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //set form's caption to mouse coordinates
            Text = string.Format("X = {0}, Y = {1}", e.X, e.Y);
        }
    }

    #endregion

    #endregion
}
