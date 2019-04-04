// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CyanControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection representing Material Design color Cyan dialog.
    /// </summary>
    public partial class CyanControl : System.Windows.Forms.Form
    {

        #region Constructor
        public CyanControl()
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
        private void Cyan_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //Cyan_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = Cyan_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void Cyan_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            Cyan_500_Header.BackColor = Colors.Cyan.CyanHeader500;
            zeroitLabel20.BackColor = Colors.Cyan.CyanHeader500;
            zeroitLabel21.BackColor = Colors.Cyan.CyanHeader500;
            swatchNameLabel.BackColor = Colors.Cyan.CyanHeader500;
        }

        private void Cyan_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.CyanHeader500;
            control.BackColor = Colors.Cyan.CyanHeader500;

        }

        private void Cyan_500_Header_Click(object sender, EventArgs e)
        {
            Cyan_500_Header.BackColor = Colors.Cyan.CyanHeader500;
            zeroitLabel20.BackColor = Colors.Cyan.CyanHeader500;
            zeroitLabel21.BackColor = Colors.Cyan.CyanHeader500;
            swatchNameLabel.BackColor = Colors.Cyan.CyanHeader500;
        }

        private void Cyan_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            Cyan_500_Header.BackColor = Colors.Cyan.CyanHeader500;
            zeroitLabel20.BackColor = Colors.Cyan.CyanHeader500;
            zeroitLabel21.BackColor = Colors.Cyan.CyanHeader500;
            swatchNameLabel.BackColor = Colors.Cyan.CyanHeader500;
        }


        private void Cyan_50_MouseEnter(object sender, EventArgs e)
        {
            Cyan_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void Cyan_50_MouseLeave(object sender, EventArgs e)
        {
            Cyan_50.BackColor = Colors.Cyan.Cyan50;
            zeroitLabel18.BackColor = Colors.Cyan.Cyan50;
            zeroitLabel19.BackColor = Colors.Cyan.Cyan50;
        }



        private void Cyan_100_MouseEnter(object sender, EventArgs e)
        {
            Cyan_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Cyan_100_MouseLeave(object sender, EventArgs e)
        {
            Cyan_100.BackColor = Colors.Cyan.Cyan100;
            zeroitLabel16.BackColor = Colors.Cyan.Cyan100;
            zeroitLabel17.BackColor = Colors.Cyan.Cyan100;
        }

        private void Cyan_200_MouseEnter(object sender, EventArgs e)
        {
            Cyan_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Cyan_200_MouseLeave(object sender, EventArgs e)
        {
            Cyan_200.BackColor = Colors.Cyan.Cyan200;
            zeroitLabel14.BackColor = Colors.Cyan.Cyan200;
            zeroitLabel15.BackColor = Colors.Cyan.Cyan200;
        }

        private void Cyan_300_MouseEnter(object sender, EventArgs e)
        {
            Cyan_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Cyan_300_MouseLeave(object sender, EventArgs e)
        {
            Cyan_300.BackColor = Colors.Cyan.Cyan300;
            zeroitLabel13.BackColor = Colors.Cyan.Cyan300;
            zeroitLabel2.BackColor = Colors.Cyan.Cyan300;
        }

        private void Cyan_400_MouseEnter(object sender, EventArgs e)
        {
            Cyan_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Cyan_400_MouseLeave(object sender, EventArgs e)
        {
            Cyan_400.BackColor = Colors.Cyan.Cyan400;
            zeroitLabel23.BackColor = Colors.Cyan.Cyan400;
            zeroitLabel24.BackColor = Colors.Cyan.Cyan400;
        }

        private void Cyan_500_MouseEnter(object sender, EventArgs e)
        {
            Cyan_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Cyan_500_MouseLeave(object sender, EventArgs e)
        {
            Cyan_500.BackColor = Colors.Cyan.Cyan500;
            zeroitLabel25.BackColor = Colors.Cyan.Cyan500;
            zeroitLabel26.BackColor = Colors.Cyan.Cyan500;
        }

        private void Cyan_600_MouseEnter(object sender, EventArgs e)
        {
            Cyan_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Cyan_600_MouseLeave(object sender, EventArgs e)
        {
            Cyan_600.BackColor = Colors.Cyan.Cyan600;
            zeroitLabel27.BackColor = Colors.Cyan.Cyan600;
            zeroitLabel28.BackColor = Colors.Cyan.Cyan600;
        }

        private void Cyan_700_MouseEnter(object sender, EventArgs e)
        {
            Cyan_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Cyan_700_MouseLeave(object sender, EventArgs e)
        {
            Cyan_700.BackColor = Colors.Cyan.Cyan700;
            zeroitLabel29.BackColor = Colors.Cyan.Cyan700;
            zeroitLabel30.BackColor = Colors.Cyan.Cyan700;
        }

        private void Cyan_800_MouseEnter(object sender, EventArgs e)
        {
            Cyan_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Cyan_800_MouseLeave(object sender, EventArgs e)
        {
            Cyan_800.BackColor = Colors.Cyan.Cyan800;
            zeroitLabel31.BackColor = Colors.Cyan.Cyan800;
            zeroitLabel32.BackColor = Colors.Cyan.Cyan800;
        }

        private void Cyan_900_MouseEnter(object sender, EventArgs e)
        {
            Cyan_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Cyan_900_MouseLeave(object sender, EventArgs e)
        {
            Cyan_900.BackColor = Colors.Cyan.Cyan900;
            zeroitLabel33.BackColor = Colors.Cyan.Cyan900;
            zeroitLabel34.BackColor = Colors.Cyan.Cyan900;
        }

        private void Cyan_A100_MouseEnter(object sender, EventArgs e)
        {
            Cyan_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Cyan_A100_MouseLeave(object sender, EventArgs e)
        {
            Cyan_A100.BackColor = Colors.Cyan.CyanA100;
            zeroitLabel35.BackColor = Colors.Cyan.CyanA100;
            zeroitLabel36.BackColor = Colors.Cyan.CyanA100;
        }

        private void Cyan_A200_MouseEnter(object sender, EventArgs e)
        {
            Cyan_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Cyan_A200_MouseLeave(object sender, EventArgs e)
        {
            Cyan_A200.BackColor = Colors.Cyan.CyanA200;
            zeroitLabel37.BackColor = Colors.Cyan.CyanA200;
            zeroitLabel38.BackColor = Colors.Cyan.CyanA200;
        }

        private void Cyan_A400_MouseEnter(object sender, EventArgs e)
        {
            Cyan_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Cyan_A400_MouseLeave(object sender, EventArgs e)
        {
            Cyan_A400.BackColor = Colors.Cyan.CyanA400;
            zeroitLabel39.BackColor = Colors.Cyan.CyanA400;
            zeroitLabel40.BackColor = Colors.Cyan.CyanA400;
        }

        private void Cyan_A700_MouseEnter(object sender, EventArgs e)
        {
            Cyan_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Cyan_A700_MouseLeave(object sender, EventArgs e)
        {
            Cyan_A700.BackColor = Colors.Cyan.CyanA700;
            zeroitLabel41.BackColor = Colors.Cyan.CyanA700;
            zeroitLabel42.BackColor = Colors.Cyan.CyanA700;
        }





        private void Cyan_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.Cyan50;
            control.BackColor = Colors.Cyan.Cyan50;
        }


        private void Cyan_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.Cyan100;
            control.BackColor = Colors.Cyan.Cyan100;
        }

        private void Cyan_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.Cyan200;
            control.BackColor = Colors.Cyan.Cyan200;
        }

        private void Cyan_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.Cyan300;
            control.BackColor = Colors.Cyan.Cyan300;
        }

        private void Cyan_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.Cyan400;
            control.BackColor = Colors.Cyan.Cyan400;
        }

        private void Cyan_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.Cyan500;
            control.BackColor = Colors.Cyan.Cyan500;
        }


        private void Cyan_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.Cyan600;
            control.BackColor = Colors.Cyan.Cyan600;
        }

        private void Cyan_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.Cyan700;
            control.BackColor = Colors.Cyan.Cyan700;
        }

        private void Cyan_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.Cyan800;
            control.BackColor = Colors.Cyan.Cyan800;
        }

        private void Cyan_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.Cyan900;
            control.BackColor = Colors.Cyan.Cyan900;
        }

        private void Cyan_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.CyanA100;
            control.BackColor = Colors.Cyan.CyanA100;
        }

        private void Cyan_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.CyanA200;
            control.BackColor = Colors.Cyan.CyanA200;
        }

        private void Cyan_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.CyanA400;
            control.BackColor = Colors.Cyan.CyanA400;
        }

        private void Cyan_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Cyan.CyanA700;
            control.BackColor = Colors.Cyan.CyanA700;
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

        private void CyanControl_Paint(object sender, PaintEventArgs e)
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
