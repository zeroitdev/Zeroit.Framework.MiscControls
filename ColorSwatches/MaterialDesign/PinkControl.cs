// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PinkControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection representing Material Design color Pink dialog.
    /// </summary>
    public partial class PinkControl : System.Windows.Forms.Form
    {

        #region Constructor
        public PinkControl()
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
        private void Pink_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //Pink_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = Pink_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void Pink_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            Pink_500_Header.BackColor = Colors.Pink.PinkHeader500;
            zeroitLabel20.BackColor = Colors.Pink.PinkHeader500;
            zeroitLabel21.BackColor = Colors.Pink.PinkHeader500;
            swatchNameLabel.BackColor = Colors.Pink.PinkHeader500;
        }

        private void Pink_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.PinkHeader500;
            control.BackColor = Colors.Pink.PinkHeader500;

        }

        private void Pink_500_Header_Click(object sender, EventArgs e)
        {
            Pink_500_Header.BackColor = Colors.Pink.PinkHeader500;
            zeroitLabel20.BackColor = Colors.Pink.PinkHeader500;
            zeroitLabel21.BackColor = Colors.Pink.PinkHeader500;
            swatchNameLabel.BackColor = Colors.Pink.PinkHeader500;
        }

        private void Pink_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            Pink_500_Header.BackColor = Colors.Pink.PinkHeader500;
            zeroitLabel20.BackColor = Colors.Pink.PinkHeader500;
            zeroitLabel21.BackColor = Colors.Pink.PinkHeader500;
            swatchNameLabel.BackColor = Colors.Pink.PinkHeader500;
        }


        private void Pink_50_MouseEnter(object sender, EventArgs e)
        {
            Pink_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void Pink_50_MouseLeave(object sender, EventArgs e)
        {
            Pink_50.BackColor = Colors.Pink.Pink50;
            zeroitLabel18.BackColor = Colors.Pink.Pink50;
            zeroitLabel19.BackColor = Colors.Pink.Pink50;
        }



        private void Pink_100_MouseEnter(object sender, EventArgs e)
        {
            Pink_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Pink_100_MouseLeave(object sender, EventArgs e)
        {
            Pink_100.BackColor = Colors.Pink.Pink100;
            zeroitLabel16.BackColor = Colors.Pink.Pink100;
            zeroitLabel17.BackColor = Colors.Pink.Pink100;
        }

        private void Pink_200_MouseEnter(object sender, EventArgs e)
        {
            Pink_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Pink_200_MouseLeave(object sender, EventArgs e)
        {
            Pink_200.BackColor = Colors.Pink.Pink200;
            zeroitLabel14.BackColor = Colors.Pink.Pink200;
            zeroitLabel15.BackColor = Colors.Pink.Pink200;
        }

        private void Pink_300_MouseEnter(object sender, EventArgs e)
        {
            Pink_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Pink_300_MouseLeave(object sender, EventArgs e)
        {
            Pink_300.BackColor = Colors.Pink.Pink300;
            zeroitLabel13.BackColor = Colors.Pink.Pink300;
            zeroitLabel2.BackColor = Colors.Pink.Pink300;
        }

        private void Pink_400_MouseEnter(object sender, EventArgs e)
        {
            Pink_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Pink_400_MouseLeave(object sender, EventArgs e)
        {
            Pink_400.BackColor = Colors.Pink.Pink400;
            zeroitLabel23.BackColor = Colors.Pink.Pink400;
            zeroitLabel24.BackColor = Colors.Pink.Pink400;
        }

        private void Pink_500_MouseEnter(object sender, EventArgs e)
        {
            Pink_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Pink_500_MouseLeave(object sender, EventArgs e)
        {
            Pink_500.BackColor = Colors.Pink.Pink500;
            zeroitLabel25.BackColor = Colors.Pink.Pink500;
            zeroitLabel26.BackColor = Colors.Pink.Pink500;
        }

        private void Pink_600_MouseEnter(object sender, EventArgs e)
        {
            Pink_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Pink_600_MouseLeave(object sender, EventArgs e)
        {
            Pink_600.BackColor = Colors.Pink.Pink600;
            zeroitLabel27.BackColor = Colors.Pink.Pink600;
            zeroitLabel28.BackColor = Colors.Pink.Pink600;
        }

        private void Pink_700_MouseEnter(object sender, EventArgs e)
        {
            Pink_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Pink_700_MouseLeave(object sender, EventArgs e)
        {
            Pink_700.BackColor = Colors.Pink.Pink700;
            zeroitLabel29.BackColor = Colors.Pink.Pink700;
            zeroitLabel30.BackColor = Colors.Pink.Pink700;
        }

        private void Pink_800_MouseEnter(object sender, EventArgs e)
        {
            Pink_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Pink_800_MouseLeave(object sender, EventArgs e)
        {
            Pink_800.BackColor = Colors.Pink.Pink800;
            zeroitLabel31.BackColor = Colors.Pink.Pink800;
            zeroitLabel32.BackColor = Colors.Pink.Pink800;
        }

        private void Pink_900_MouseEnter(object sender, EventArgs e)
        {
            Pink_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Pink_900_MouseLeave(object sender, EventArgs e)
        {
            Pink_900.BackColor = Colors.Pink.Pink900;
            zeroitLabel33.BackColor = Colors.Pink.Pink900;
            zeroitLabel34.BackColor = Colors.Pink.Pink900;
        }

        private void Pink_A100_MouseEnter(object sender, EventArgs e)
        {
            Pink_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Pink_A100_MouseLeave(object sender, EventArgs e)
        {
            Pink_A100.BackColor = Colors.Pink.PinkA100;
            zeroitLabel35.BackColor = Colors.Pink.PinkA100;
            zeroitLabel36.BackColor = Colors.Pink.PinkA100;
        }

        private void Pink_A200_MouseEnter(object sender, EventArgs e)
        {
            Pink_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Pink_A200_MouseLeave(object sender, EventArgs e)
        {
            Pink_A200.BackColor = Colors.Pink.PinkA200;
            zeroitLabel37.BackColor = Colors.Pink.PinkA200;
            zeroitLabel38.BackColor = Colors.Pink.PinkA200;
        }

        private void Pink_A400_MouseEnter(object sender, EventArgs e)
        {
            Pink_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Pink_A400_MouseLeave(object sender, EventArgs e)
        {
            Pink_A400.BackColor = Colors.Pink.PinkA400;
            zeroitLabel39.BackColor = Colors.Pink.PinkA400;
            zeroitLabel40.BackColor = Colors.Pink.PinkA400;
        }

        private void Pink_A700_MouseEnter(object sender, EventArgs e)
        {
            Pink_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Pink_A700_MouseLeave(object sender, EventArgs e)
        {
            Pink_A700.BackColor = Colors.Pink.PinkA700;
            zeroitLabel41.BackColor = Colors.Pink.PinkA700;
            zeroitLabel42.BackColor = Colors.Pink.PinkA700;
        }





        private void Pink_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.Pink50;
            control.BackColor = Colors.Pink.Pink50;
        }


        private void Pink_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.Pink100;
            control.BackColor = Colors.Pink.Pink100;
        }

        private void Pink_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.Pink200;
            control.BackColor = Colors.Pink.Pink200;
        }

        private void Pink_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.Pink300;
            control.BackColor = Colors.Pink.Pink300;
        }

        private void Pink_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.Pink400;
            control.BackColor = Colors.Pink.Pink400;
        }

        private void Pink_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.Pink500;
            control.BackColor = Colors.Pink.Pink500;
        }


        private void Pink_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.Pink600;
            control.BackColor = Colors.Pink.Pink600;
        }

        private void Pink_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.Pink700;
            control.BackColor = Colors.Pink.Pink700;
        }

        private void Pink_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.Pink800;
            control.BackColor = Colors.Pink.Pink800;
        }

        private void Pink_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.Pink900;
            control.BackColor = Colors.Pink.Pink900;
        }

        private void Pink_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.PinkA100;
            control.BackColor = Colors.Pink.PinkA100;
        }

        private void Pink_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.PinkA200;
            control.BackColor = Colors.Pink.PinkA200;
        }

        private void Pink_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.PinkA400;
            control.BackColor = Colors.Pink.PinkA400;
        }

        private void Pink_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Pink.PinkA700;
            control.BackColor = Colors.Pink.PinkA700;
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

        private void PinkControl_Paint(object sender, PaintEventArgs e)
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
