// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="YellowControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection representing Material Design color Yellow dialog.
    /// </summary>
    public partial class YellowControl : System.Windows.Forms.Form
    {

        #region Constructor
        public YellowControl()
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
        private void Yellow_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //Yellow_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = Yellow_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void Yellow_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            Yellow_500_Header.BackColor = Colors.Yellow.YellowHeader500;
            zeroitLabel20.BackColor = Colors.Yellow.YellowHeader500;
            zeroitLabel21.BackColor = Colors.Yellow.YellowHeader500;
            swatchNameLabel.BackColor = Colors.Yellow.YellowHeader500;
        }

        private void Yellow_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.YellowHeader500;
            control.BackColor = Colors.Yellow.YellowHeader500;

        }

        private void Yellow_500_Header_Click(object sender, EventArgs e)
        {
            Yellow_500_Header.BackColor = Colors.Yellow.YellowHeader500;
            zeroitLabel20.BackColor = Colors.Yellow.YellowHeader500;
            zeroitLabel21.BackColor = Colors.Yellow.YellowHeader500;
            swatchNameLabel.BackColor = Colors.Yellow.YellowHeader500;
        }

        private void Yellow_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            Yellow_500_Header.BackColor = Colors.Yellow.YellowHeader500;
            zeroitLabel20.BackColor = Colors.Yellow.YellowHeader500;
            zeroitLabel21.BackColor = Colors.Yellow.YellowHeader500;
            swatchNameLabel.BackColor = Colors.Yellow.YellowHeader500;
        }


        private void Yellow_50_MouseEnter(object sender, EventArgs e)
        {
            Yellow_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void Yellow_50_MouseLeave(object sender, EventArgs e)
        {
            Yellow_50.BackColor = Colors.Yellow.Yellow50;
            zeroitLabel18.BackColor = Colors.Yellow.Yellow50;
            zeroitLabel19.BackColor = Colors.Yellow.Yellow50;
        }



        private void Yellow_100_MouseEnter(object sender, EventArgs e)
        {
            Yellow_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Yellow_100_MouseLeave(object sender, EventArgs e)
        {
            Yellow_100.BackColor = Colors.Yellow.Yellow100;
            zeroitLabel16.BackColor = Colors.Yellow.Yellow100;
            zeroitLabel17.BackColor = Colors.Yellow.Yellow100;
        }

        private void Yellow_200_MouseEnter(object sender, EventArgs e)
        {
            Yellow_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Yellow_200_MouseLeave(object sender, EventArgs e)
        {
            Yellow_200.BackColor = Colors.Yellow.Yellow200;
            zeroitLabel14.BackColor = Colors.Yellow.Yellow200;
            zeroitLabel15.BackColor = Colors.Yellow.Yellow200;
        }

        private void Yellow_300_MouseEnter(object sender, EventArgs e)
        {
            Yellow_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Yellow_300_MouseLeave(object sender, EventArgs e)
        {
            Yellow_300.BackColor = Colors.Yellow.Yellow300;
            zeroitLabel13.BackColor = Colors.Yellow.Yellow300;
            zeroitLabel2.BackColor = Colors.Yellow.Yellow300;
        }

        private void Yellow_400_MouseEnter(object sender, EventArgs e)
        {
            Yellow_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Yellow_400_MouseLeave(object sender, EventArgs e)
        {
            Yellow_400.BackColor = Colors.Yellow.Yellow400;
            zeroitLabel23.BackColor = Colors.Yellow.Yellow400;
            zeroitLabel24.BackColor = Colors.Yellow.Yellow400;
        }

        private void Yellow_500_MouseEnter(object sender, EventArgs e)
        {
            Yellow_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Yellow_500_MouseLeave(object sender, EventArgs e)
        {
            Yellow_500.BackColor = Colors.Yellow.Yellow500;
            zeroitLabel25.BackColor = Colors.Yellow.Yellow500;
            zeroitLabel26.BackColor = Colors.Yellow.Yellow500;
        }

        private void Yellow_600_MouseEnter(object sender, EventArgs e)
        {
            Yellow_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Yellow_600_MouseLeave(object sender, EventArgs e)
        {
            Yellow_600.BackColor = Colors.Yellow.Yellow600;
            zeroitLabel27.BackColor = Colors.Yellow.Yellow600;
            zeroitLabel28.BackColor = Colors.Yellow.Yellow600;
        }

        private void Yellow_700_MouseEnter(object sender, EventArgs e)
        {
            Yellow_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Yellow_700_MouseLeave(object sender, EventArgs e)
        {
            Yellow_700.BackColor = Colors.Yellow.Yellow700;
            zeroitLabel29.BackColor = Colors.Yellow.Yellow700;
            zeroitLabel30.BackColor = Colors.Yellow.Yellow700;
        }

        private void Yellow_800_MouseEnter(object sender, EventArgs e)
        {
            Yellow_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Yellow_800_MouseLeave(object sender, EventArgs e)
        {
            Yellow_800.BackColor = Colors.Yellow.Yellow800;
            zeroitLabel31.BackColor = Colors.Yellow.Yellow800;
            zeroitLabel32.BackColor = Colors.Yellow.Yellow800;
        }

        private void Yellow_900_MouseEnter(object sender, EventArgs e)
        {
            Yellow_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Yellow_900_MouseLeave(object sender, EventArgs e)
        {
            Yellow_900.BackColor = Colors.Yellow.Yellow900;
            zeroitLabel33.BackColor = Colors.Yellow.Yellow900;
            zeroitLabel34.BackColor = Colors.Yellow.Yellow900;
        }

        private void Yellow_A100_MouseEnter(object sender, EventArgs e)
        {
            Yellow_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Yellow_A100_MouseLeave(object sender, EventArgs e)
        {
            Yellow_A100.BackColor = Colors.Yellow.YellowA100;
            zeroitLabel35.BackColor = Colors.Yellow.YellowA100;
            zeroitLabel36.BackColor = Colors.Yellow.YellowA100;
        }

        private void Yellow_A200_MouseEnter(object sender, EventArgs e)
        {
            Yellow_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Yellow_A200_MouseLeave(object sender, EventArgs e)
        {
            Yellow_A200.BackColor = Colors.Yellow.YellowA200;
            zeroitLabel37.BackColor = Colors.Yellow.YellowA200;
            zeroitLabel38.BackColor = Colors.Yellow.YellowA200;
        }

        private void Yellow_A400_MouseEnter(object sender, EventArgs e)
        {
            Yellow_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Yellow_A400_MouseLeave(object sender, EventArgs e)
        {
            Yellow_A400.BackColor = Colors.Yellow.YellowA400;
            zeroitLabel39.BackColor = Colors.Yellow.YellowA400;
            zeroitLabel40.BackColor = Colors.Yellow.YellowA400;
        }

        private void Yellow_A700_MouseEnter(object sender, EventArgs e)
        {
            Yellow_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Yellow_A700_MouseLeave(object sender, EventArgs e)
        {
            Yellow_A700.BackColor = Colors.Yellow.YellowA700;
            zeroitLabel41.BackColor = Colors.Yellow.YellowA700;
            zeroitLabel42.BackColor = Colors.Yellow.YellowA700;
        }





        private void Yellow_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.Yellow50;
            control.BackColor = Colors.Yellow.Yellow50;
        }


        private void Yellow_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.Yellow100;
            control.BackColor = Colors.Yellow.Yellow100;
        }

        private void Yellow_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.Yellow200;
            control.BackColor = Colors.Yellow.Yellow200;
        }

        private void Yellow_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.Yellow300;
            control.BackColor = Colors.Yellow.Yellow300;
        }

        private void Yellow_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.Yellow400;
            control.BackColor = Colors.Yellow.Yellow400;
        }

        private void Yellow_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.Yellow500;
            control.BackColor = Colors.Yellow.Yellow500;
        }


        private void Yellow_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.Yellow600;
            control.BackColor = Colors.Yellow.Yellow600;
        }

        private void Yellow_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.Yellow700;
            control.BackColor = Colors.Yellow.Yellow700;
        }

        private void Yellow_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.Yellow800;
            control.BackColor = Colors.Yellow.Yellow800;
        }

        private void Yellow_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.Yellow900;
            control.BackColor = Colors.Yellow.Yellow900;
        }

        private void Yellow_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.YellowA100;
            control.BackColor = Colors.Yellow.YellowA100;
        }

        private void Yellow_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.YellowA200;
            control.BackColor = Colors.Yellow.YellowA200;
        }

        private void Yellow_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.YellowA400;
            control.BackColor = Colors.Yellow.YellowA400;
        }

        private void Yellow_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Yellow.YellowA700;
            control.BackColor = Colors.Yellow.YellowA700;
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

        private void YellowControl_Paint(object sender, PaintEventArgs e)
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
