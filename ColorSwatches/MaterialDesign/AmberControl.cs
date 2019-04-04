// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AmberControl.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.ColorSwatches.MaterialDesign
{
    /// <summary>
    /// A class collection representing Material Design color Amber dialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AmberControl : System.Windows.Forms.Form
    {

        #region Private Field

        /// <summary>
        /// The control
        /// </summary>
        private Control control = new Control();

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AmberControl"/> class.
        /// </summary>
        public AmberControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets or sets the color of the set.
        /// </summary>
        /// <value>The color of the set.</value>
        public Color SetColor
        {
            get { return selectedColor.BackColor; }
            set
            {
                selectedColor.BackColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Selecteds the color.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>Color.</returns>
        public Color SelectedColor(Control control)
        {
            this.control = control;
            this.control.BackColor = selectedColor.BackColor;

            return this.control.BackColor;
        }
        #endregion

        #region Events


        /// <summary>
        /// Handles the MouseEnter event of the Amber_500_Header control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //Amber_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = Amber_500_Header;
            zeroitObjectAnimator1.Start();

        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_500_Header control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            Amber_500_Header.BackColor = Colors.Amber.AmberHeader500;
            zeroitLabel20.BackColor = Colors.Amber.AmberHeader500;
            zeroitLabel21.BackColor = Colors.Amber.AmberHeader500;
            swatchNameLabel.BackColor = Colors.Amber.AmberHeader500;



        }

        /// <summary>
        /// Handles the Paint event of the Amber_50 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void Amber_50_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_50 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_50_MouseEnter(object sender, EventArgs e)
        {
            Amber_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the Click event of the zeroitLabel18 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void zeroitLabel18_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the zeroitLabel19 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void zeroitLabel19_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_50 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_50_MouseLeave(object sender, EventArgs e)
        {
            Amber_50.BackColor = Colors.Amber.Amber50;
            zeroitLabel18.BackColor = Colors.Amber.Amber50;
            zeroitLabel19.BackColor = Colors.Amber.Amber50;
        }

        /// <summary>
        /// Handles the Click event of the Amber_500_Header control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_500_Header_Click(object sender, EventArgs e)
        {
            Amber_500_Header.BackColor = Colors.Amber.AmberHeader500;
            zeroitLabel20.BackColor = Colors.Amber.AmberHeader500;
            zeroitLabel21.BackColor = Colors.Amber.AmberHeader500;
            swatchNameLabel.BackColor = Colors.Amber.AmberHeader500;
        }

        /// <summary>
        /// Handles the MouseClick event of the Amber_500_Header control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void Amber_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            Amber_500_Header.BackColor = Colors.Amber.AmberHeader500;
            zeroitLabel20.BackColor = Colors.Amber.AmberHeader500;
            zeroitLabel21.BackColor = Colors.Amber.AmberHeader500;
            swatchNameLabel.BackColor = Colors.Amber.AmberHeader500;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_100 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_100_MouseEnter(object sender, EventArgs e)
        {
            Amber_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_100 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_100_MouseLeave(object sender, EventArgs e)
        {
            Amber_100.BackColor = Colors.Amber.Amber100;
            zeroitLabel16.BackColor = Colors.Amber.Amber100;
            zeroitLabel17.BackColor = Colors.Amber.Amber100;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_200 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_200_MouseEnter(object sender, EventArgs e)
        {
            Amber_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_200 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_200_MouseLeave(object sender, EventArgs e)
        {
            Amber_200.BackColor = Colors.Amber.Amber200;
            zeroitLabel14.BackColor = Colors.Amber.Amber200;
            zeroitLabel15.BackColor = Colors.Amber.Amber200;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_300 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_300_MouseEnter(object sender, EventArgs e)
        {
            Amber_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_300 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_300_MouseLeave(object sender, EventArgs e)
        {
            Amber_300.BackColor = Colors.Amber.Amber300;
            zeroitLabel13.BackColor = Colors.Amber.Amber300;
            zeroitLabel2.BackColor = Colors.Amber.Amber300;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_400 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_400_MouseEnter(object sender, EventArgs e)
        {
            Amber_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_400 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_400_MouseLeave(object sender, EventArgs e)
        {
            Amber_400.BackColor = Colors.Amber.Amber400;
            zeroitLabel23.BackColor = Colors.Amber.Amber400;
            zeroitLabel24.BackColor = Colors.Amber.Amber400;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_500 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_500_MouseEnter(object sender, EventArgs e)
        {
            Amber_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_500 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_500_MouseLeave(object sender, EventArgs e)
        {
            Amber_500.BackColor = Colors.Amber.Amber500;
            zeroitLabel25.BackColor = Colors.Amber.Amber500;
            zeroitLabel26.BackColor = Colors.Amber.Amber500;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_600 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_600_MouseEnter(object sender, EventArgs e)
        {
            Amber_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_600 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_600_MouseLeave(object sender, EventArgs e)
        {
            Amber_600.BackColor = Colors.Amber.Amber600;
            zeroitLabel27.BackColor = Colors.Amber.Amber600;
            zeroitLabel28.BackColor = Colors.Amber.Amber600;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_700 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_700_MouseEnter(object sender, EventArgs e)
        {
            Amber_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_700 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_700_MouseLeave(object sender, EventArgs e)
        {
            Amber_700.BackColor = Colors.Amber.Amber700;
            zeroitLabel29.BackColor = Colors.Amber.Amber700;
            zeroitLabel30.BackColor = Colors.Amber.Amber700;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_800 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_800_MouseEnter(object sender, EventArgs e)
        {
            Amber_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_800 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_800_MouseLeave(object sender, EventArgs e)
        {
            Amber_800.BackColor = Colors.Amber.Amber800;
            zeroitLabel31.BackColor = Colors.Amber.Amber800;
            zeroitLabel32.BackColor = Colors.Amber.Amber800;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_900 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_900_MouseEnter(object sender, EventArgs e)
        {
            Amber_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_900 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_900_MouseLeave(object sender, EventArgs e)
        {
            Amber_900.BackColor = Colors.Amber.Amber900;
            zeroitLabel33.BackColor = Colors.Amber.Amber900;
            zeroitLabel34.BackColor = Colors.Amber.Amber900;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_A100 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_A100_MouseEnter(object sender, EventArgs e)
        {
            Amber_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_A100 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_A100_MouseLeave(object sender, EventArgs e)
        {
            Amber_A100.BackColor = Colors.Amber.AmberA100;
            zeroitLabel35.BackColor = Colors.Amber.AmberA100;
            zeroitLabel36.BackColor = Colors.Amber.AmberA100;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_A200 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_A200_MouseEnter(object sender, EventArgs e)
        {
            Amber_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_A200 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_A200_MouseLeave(object sender, EventArgs e)
        {
            Amber_A200.BackColor = Colors.Amber.AmberA200;
            zeroitLabel37.BackColor = Colors.Amber.AmberA200;
            zeroitLabel38.BackColor = Colors.Amber.AmberA200;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_A400 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_A400_MouseEnter(object sender, EventArgs e)
        {
            Amber_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_A400 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_A400_MouseLeave(object sender, EventArgs e)
        {
            Amber_A400.BackColor = Colors.Amber.AmberA400;
            zeroitLabel39.BackColor = Colors.Amber.AmberA400;
            zeroitLabel40.BackColor = Colors.Amber.AmberA400;
        }

        /// <summary>
        /// Handles the MouseEnter event of the Amber_A700 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_A700_MouseEnter(object sender, EventArgs e)
        {
            Amber_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        /// <summary>
        /// Handles the MouseLeave event of the Amber_A700 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_A700_MouseLeave(object sender, EventArgs e)
        {
            Amber_A700.BackColor = Colors.Amber.AmberA700;
            zeroitLabel41.BackColor = Colors.Amber.AmberA700;
            zeroitLabel42.BackColor = Colors.Amber.AmberA700;
        }



        /// <summary>
        /// Handles the MouseEnter event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(244, 67, 54);
        }

        /// <summary>
        /// Handles the MouseLeave event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(56, 56, 56);
        }

        /// <summary>
        /// Handles the MouseEnter event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkSlateGray;
        }

        /// <summary>
        /// Handles the MouseLeave event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(56, 56, 56);
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Color.FromArgb(45, 45, 48);
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        /// <summary>
        /// Handles the Paint event of the Amber_500_Header control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void Amber_500_Header_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Handles the 1 event of the Amber_500_Header_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.AmberHeader500;
            control.BackColor = Colors.Amber.AmberHeader500;

        }

        /// <summary>
        /// Handles the Click event of the Amber_50 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.Amber50;
            control.BackColor = Colors.Amber.Amber50;
        }

        /// <summary>
        /// Handles the Click event of the Amber_100 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.Amber100;
            control.BackColor = Colors.Amber.Amber100;
        }

        /// <summary>
        /// Handles the Click event of the Amber_200 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.Amber200;
            control.BackColor = Colors.Amber.Amber200;
        }

        /// <summary>
        /// Handles the Click event of the Amber_300 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.Amber300;
            control.BackColor = Colors.Amber.Amber300;
        }

        /// <summary>
        /// Handles the Click event of the Amber_400 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.Amber400;
            control.BackColor = Colors.Amber.Amber400;
        }

        /// <summary>
        /// Handles the Click event of the Amber_500 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.Amber500;
            control.BackColor = Colors.Amber.Amber500;
        }


        /// <summary>
        /// Handles the Click event of the Amber_600 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.Amber600;
            control.BackColor = Colors.Amber.Amber600;
        }

        /// <summary>
        /// Handles the Click event of the Amber_700 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.Amber700;
            control.BackColor = Colors.Amber.Amber700;
        }

        /// <summary>
        /// Handles the Click event of the Amber_800 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.Amber800;
            control.BackColor = Colors.Amber.Amber800;
        }

        /// <summary>
        /// Handles the Click event of the Amber_900 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.Amber900;
            control.BackColor = Colors.Amber.Amber900;
        }

        /// <summary>
        /// Handles the Click event of the Amber_A100 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.AmberA100;
            control.BackColor = Colors.Amber.AmberA100;
        }

        /// <summary>
        /// Handles the Click event of the Amber_A200 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.AmberA200;
            control.BackColor = Colors.Amber.AmberA200;
        }

        /// <summary>
        /// Handles the Click event of the Amber_A400 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.AmberA400;
            control.BackColor = Colors.Amber.AmberA400;
        }

        /// <summary>
        /// Handles the Click event of the Amber_A700 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Amber_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Amber.AmberA700;
            control.BackColor = Colors.Amber.AmberA700;
        }

        /// <summary>
        /// Handles the Paint event of the AmberControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void AmberControl_Paint(object sender, PaintEventArgs e)
        {
            formTransition.Start();

        }
        #endregion

        #region Shadow Override

        /// <summary>
        /// Gets the create parameters.
        /// </summary>
        /// <value>The create parameters.</value>
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        #endregion
    }
}
