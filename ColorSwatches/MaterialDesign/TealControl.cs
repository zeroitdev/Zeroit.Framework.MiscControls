// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TealControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection representing Material Design color Teal dialog.
    /// </summary>
    public partial class TealControl : System.Windows.Forms.Form
    {

        #region Constructor
        public TealControl()
        {
            InitializeComponent();
        } 
        #endregion
        
        #region Private Fields

        
        private Control control = new Control();

        #endregion

        #region Private Methods
        public Color SetColor
        {
            get { return selectedColor.BackColor; }
            set
            {
                selectedColor.BackColor = value;
                Invalidate();
            }
        }

        public Color SelectedColor(Control control)
        {
            this.control = control;
            this.control.BackColor = selectedColor.BackColor;

            return this.control.BackColor;
        }

        #endregion

        #region Events
        private void Teal_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //Teal_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = Teal_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void Teal_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            Teal_500_Header.BackColor = Colors.Teal.TealHeader500;
            zeroitLabel20.BackColor = Colors.Teal.TealHeader500;
            zeroitLabel21.BackColor = Colors.Teal.TealHeader500;
            swatchNameLabel.BackColor = Colors.Teal.TealHeader500;
        }

        private void Teal_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.TealHeader500;
            control.BackColor = Colors.Teal.TealHeader500;

        }

        private void Teal_500_Header_Click(object sender, EventArgs e)
        {
            Teal_500_Header.BackColor = Colors.Teal.TealHeader500;
            zeroitLabel20.BackColor = Colors.Teal.TealHeader500;
            zeroitLabel21.BackColor = Colors.Teal.TealHeader500;
            swatchNameLabel.BackColor = Colors.Teal.TealHeader500;
        }

        private void Teal_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            Teal_500_Header.BackColor = Colors.Teal.TealHeader500;
            zeroitLabel20.BackColor = Colors.Teal.TealHeader500;
            zeroitLabel21.BackColor = Colors.Teal.TealHeader500;
            swatchNameLabel.BackColor = Colors.Teal.TealHeader500;
        }


        private void Teal_50_MouseEnter(object sender, EventArgs e)
        {
            Teal_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void Teal_50_MouseLeave(object sender, EventArgs e)
        {
            Teal_50.BackColor = Colors.Teal.Teal50;
            zeroitLabel18.BackColor = Colors.Teal.Teal50;
            zeroitLabel19.BackColor = Colors.Teal.Teal50;
        }



        private void Teal_100_MouseEnter(object sender, EventArgs e)
        {
            Teal_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Teal_100_MouseLeave(object sender, EventArgs e)
        {
            Teal_100.BackColor = Colors.Teal.Teal100;
            zeroitLabel16.BackColor = Colors.Teal.Teal100;
            zeroitLabel17.BackColor = Colors.Teal.Teal100;
        }

        private void Teal_200_MouseEnter(object sender, EventArgs e)
        {
            Teal_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Teal_200_MouseLeave(object sender, EventArgs e)
        {
            Teal_200.BackColor = Colors.Teal.Teal200;
            zeroitLabel14.BackColor = Colors.Teal.Teal200;
            zeroitLabel15.BackColor = Colors.Teal.Teal200;
        }

        private void Teal_300_MouseEnter(object sender, EventArgs e)
        {
            Teal_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Teal_300_MouseLeave(object sender, EventArgs e)
        {
            Teal_300.BackColor = Colors.Teal.Teal300;
            zeroitLabel13.BackColor = Colors.Teal.Teal300;
            zeroitLabel2.BackColor = Colors.Teal.Teal300;
        }

        private void Teal_400_MouseEnter(object sender, EventArgs e)
        {
            Teal_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Teal_400_MouseLeave(object sender, EventArgs e)
        {
            Teal_400.BackColor = Colors.Teal.Teal400;
            zeroitLabel23.BackColor = Colors.Teal.Teal400;
            zeroitLabel24.BackColor = Colors.Teal.Teal400;
        }

        private void Teal_500_MouseEnter(object sender, EventArgs e)
        {
            Teal_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Teal_500_MouseLeave(object sender, EventArgs e)
        {
            Teal_500.BackColor = Colors.Teal.Teal500;
            zeroitLabel25.BackColor = Colors.Teal.Teal500;
            zeroitLabel26.BackColor = Colors.Teal.Teal500;
        }

        private void Teal_600_MouseEnter(object sender, EventArgs e)
        {
            Teal_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Teal_600_MouseLeave(object sender, EventArgs e)
        {
            Teal_600.BackColor = Colors.Teal.Teal600;
            zeroitLabel27.BackColor = Colors.Teal.Teal600;
            zeroitLabel28.BackColor = Colors.Teal.Teal600;
        }

        private void Teal_700_MouseEnter(object sender, EventArgs e)
        {
            Teal_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Teal_700_MouseLeave(object sender, EventArgs e)
        {
            Teal_700.BackColor = Colors.Teal.Teal700;
            zeroitLabel29.BackColor = Colors.Teal.Teal700;
            zeroitLabel30.BackColor = Colors.Teal.Teal700;
        }

        private void Teal_800_MouseEnter(object sender, EventArgs e)
        {
            Teal_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Teal_800_MouseLeave(object sender, EventArgs e)
        {
            Teal_800.BackColor = Colors.Teal.Teal800;
            zeroitLabel31.BackColor = Colors.Teal.Teal800;
            zeroitLabel32.BackColor = Colors.Teal.Teal800;
        }

        private void Teal_900_MouseEnter(object sender, EventArgs e)
        {
            Teal_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Teal_900_MouseLeave(object sender, EventArgs e)
        {
            Teal_900.BackColor = Colors.Teal.Teal900;
            zeroitLabel33.BackColor = Colors.Teal.Teal900;
            zeroitLabel34.BackColor = Colors.Teal.Teal900;
        }

        private void Teal_A100_MouseEnter(object sender, EventArgs e)
        {
            Teal_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Teal_A100_MouseLeave(object sender, EventArgs e)
        {
            Teal_A100.BackColor = Colors.Teal.TealA100;
            zeroitLabel35.BackColor = Colors.Teal.TealA100;
            zeroitLabel36.BackColor = Colors.Teal.TealA100;
        }

        private void Teal_A200_MouseEnter(object sender, EventArgs e)
        {
            Teal_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Teal_A200_MouseLeave(object sender, EventArgs e)
        {
            Teal_A200.BackColor = Colors.Teal.TealA200;
            zeroitLabel37.BackColor = Colors.Teal.TealA200;
            zeroitLabel38.BackColor = Colors.Teal.TealA200;
        }

        private void Teal_A400_MouseEnter(object sender, EventArgs e)
        {
            Teal_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Teal_A400_MouseLeave(object sender, EventArgs e)
        {
            Teal_A400.BackColor = Colors.Teal.TealA400;
            zeroitLabel39.BackColor = Colors.Teal.TealA400;
            zeroitLabel40.BackColor = Colors.Teal.TealA400;
        }

        private void Teal_A700_MouseEnter(object sender, EventArgs e)
        {
            Teal_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Teal_A700_MouseLeave(object sender, EventArgs e)
        {
            Teal_A700.BackColor = Colors.Teal.TealA700;
            zeroitLabel41.BackColor = Colors.Teal.TealA700;
            zeroitLabel42.BackColor = Colors.Teal.TealA700;
        }





        private void Teal_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.Teal50;
            control.BackColor = Colors.Teal.Teal50;
        }


        private void Teal_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.Teal100;
            control.BackColor = Colors.Teal.Teal100;
        }

        private void Teal_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.Teal200;
            control.BackColor = Colors.Teal.Teal200;
        }

        private void Teal_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.Teal300;
            control.BackColor = Colors.Teal.Teal300;
        }

        private void Teal_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.Teal400;
            control.BackColor = Colors.Teal.Teal400;
        }

        private void Teal_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.Teal500;
            control.BackColor = Colors.Teal.Teal500;
        }


        private void Teal_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.Teal600;
            control.BackColor = Colors.Teal.Teal600;
        }

        private void Teal_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.Teal700;
            control.BackColor = Colors.Teal.Teal700;
        }

        private void Teal_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.Teal800;
            control.BackColor = Colors.Teal.Teal800;
        }

        private void Teal_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.Teal900;
            control.BackColor = Colors.Teal.Teal900;
        }

        private void Teal_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.TealA100;
            control.BackColor = Colors.Teal.TealA100;
        }

        private void Teal_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.TealA200;
            control.BackColor = Colors.Teal.TealA200;
        }

        private void Teal_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.TealA400;
            control.BackColor = Colors.Teal.TealA400;
        }

        private void Teal_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Teal.TealA700;
            control.BackColor = Colors.Teal.TealA700;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(244, 67, 54);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(56, 56, 56);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkSlateGray;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(56, 56, 56);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Color.FromArgb(45, 45, 48);
            this.Close();
        }

        private void TealControl_Paint(object sender, PaintEventArgs e)
        {
            formTransition.Start();

        }
        #endregion

        #region Shadow Override

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
