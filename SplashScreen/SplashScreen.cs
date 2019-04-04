// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="SplashScreen.cs" company="Zeroit Dev Technologies">
//    This program is for creating various controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Splash Screen

    #region Control
    /// <summary>
    /// This class implements a splash screen.  It disposes of itself either when it times out, based on the amount of time entered,
    /// or when the user clicks on it.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    /// <example>
    ///   <code>
    /// SplashScreen splash = new SplashScreen(@"..\..\wdilogo.png");
    /// splash.ShowSplashScreen(3000);
    /// </code>
    /// </example>
    public partial class SplashScreen : System.Windows.Forms.Form
    {

        /// <summary>
        /// The seconds
        /// </summary>
        private int seconds = 3000;

        /// <summary>
        /// Gets or sets the seconds.
        /// </summary>
        /// <value>The seconds.</value>
        public int Seconds
        {
            get { return seconds; }
            set
            {
                if (value < 1000)
                {
                    value = 1000;
                }
                seconds = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SplashScreen" /> class.
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();


            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            //image = this.BackgroundImage Image.FromFile(ImageFile);
            //this.Size = image.Size;
            //MessageBox.Show("width: " + image.Width + " height: " + image.Height);
            //if (Image == null)
            //    MessageBox.Show("Error loading image");
        }

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            //if(Image == null)
            //{
            //    Bitmap drawing = new Bitmap(5,5);

            //    e.Graphics.DrawImage(drawing, 0, 0, this.Width, this.Height);
            //}

            //else
            //{
            //    //if(Parent.BackgroundImage == null)
            //    //{
            //    //    Parent.BackgroundImage = new Bitmap(5, 5);
            //    //    e.Graphics.DrawImage(Parent.BackgroundImage, 0, 0, this.Width, this.Height);

            //    //}
            //    //else
            //    //{
            //    //    e.Graphics.DrawImage(Parent.BackgroundImage, 0, 0, this.Width, this.Height);
            //    //    //Invalidate();
            //    //    //e.Graphics.DrawImageUnscaled(image, 0, 0);
            //    //}

            //    e.Graphics.DrawImage(this.Image, 0, 0, this.Width, this.Height);

            //}

        }

        /// <summary>
        /// Show this splash screen for the amount of time specified
        /// </summary>
        public void ShowSplashScreen(/*int msec*/)
        {
            this.Invalidate();
            //msec = seconds;
            timer1.Interval = seconds;
            timer1.Enabled = true;
            this.ShowDialog();
        }

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// Handles the MouseClick event of the SplashScreen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void SplashScreen_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
            this.Dispose();
        }
    }

    #endregion

    #region Designer Generated

    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;

            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(320, 190);

            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The timer1
        /// </summary>
        private System.Windows.Forms.Timer timer1;

    }

    #endregion

    #endregion
}
