// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="OrangeControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection representing Material Design color Orange dialog.
    /// </summary>
    public partial class OrangeControl : System.Windows.Forms.Form
    {

        #region Constructor
        public OrangeControl()
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
        private void Orange_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //Orange_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = Orange_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void Orange_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            Orange_500_Header.BackColor = Colors.Orange.OrangeHeader500;
            zeroitLabel20.BackColor = Colors.Orange.OrangeHeader500;
            zeroitLabel21.BackColor = Colors.Orange.OrangeHeader500;
            swatchNameLabel.BackColor = Colors.Orange.OrangeHeader500;
        }

        private void Orange_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.OrangeHeader500;
            control.BackColor = Colors.Orange.OrangeHeader500;

        }

        private void Orange_500_Header_Click(object sender, EventArgs e)
        {
            Orange_500_Header.BackColor = Colors.Orange.OrangeHeader500;
            zeroitLabel20.BackColor = Colors.Orange.OrangeHeader500;
            zeroitLabel21.BackColor = Colors.Orange.OrangeHeader500;
            swatchNameLabel.BackColor = Colors.Orange.OrangeHeader500;
        }

        private void Orange_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            Orange_500_Header.BackColor = Colors.Orange.OrangeHeader500;
            zeroitLabel20.BackColor = Colors.Orange.OrangeHeader500;
            zeroitLabel21.BackColor = Colors.Orange.OrangeHeader500;
            swatchNameLabel.BackColor = Colors.Orange.OrangeHeader500;
        }


        private void Orange_50_MouseEnter(object sender, EventArgs e)
        {
            Orange_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void Orange_50_MouseLeave(object sender, EventArgs e)
        {
            Orange_50.BackColor = Colors.Orange.Orange50;
            zeroitLabel18.BackColor = Colors.Orange.Orange50;
            zeroitLabel19.BackColor = Colors.Orange.Orange50;
        }



        private void Orange_100_MouseEnter(object sender, EventArgs e)
        {
            Orange_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Orange_100_MouseLeave(object sender, EventArgs e)
        {
            Orange_100.BackColor = Colors.Orange.Orange100;
            zeroitLabel16.BackColor = Colors.Orange.Orange100;
            zeroitLabel17.BackColor = Colors.Orange.Orange100;
        }

        private void Orange_200_MouseEnter(object sender, EventArgs e)
        {
            Orange_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Orange_200_MouseLeave(object sender, EventArgs e)
        {
            Orange_200.BackColor = Colors.Orange.Orange200;
            zeroitLabel14.BackColor = Colors.Orange.Orange200;
            zeroitLabel15.BackColor = Colors.Orange.Orange200;
        }

        private void Orange_300_MouseEnter(object sender, EventArgs e)
        {
            Orange_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Orange_300_MouseLeave(object sender, EventArgs e)
        {
            Orange_300.BackColor = Colors.Orange.Orange300;
            zeroitLabel13.BackColor = Colors.Orange.Orange300;
            zeroitLabel2.BackColor = Colors.Orange.Orange300;
        }

        private void Orange_400_MouseEnter(object sender, EventArgs e)
        {
            Orange_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Orange_400_MouseLeave(object sender, EventArgs e)
        {
            Orange_400.BackColor = Colors.Orange.Orange400;
            zeroitLabel23.BackColor = Colors.Orange.Orange400;
            zeroitLabel24.BackColor = Colors.Orange.Orange400;
        }

        private void Orange_500_MouseEnter(object sender, EventArgs e)
        {
            Orange_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Orange_500_MouseLeave(object sender, EventArgs e)
        {
            Orange_500.BackColor = Colors.Orange.Orange500;
            zeroitLabel25.BackColor = Colors.Orange.Orange500;
            zeroitLabel26.BackColor = Colors.Orange.Orange500;
        }

        private void Orange_600_MouseEnter(object sender, EventArgs e)
        {
            Orange_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Orange_600_MouseLeave(object sender, EventArgs e)
        {
            Orange_600.BackColor = Colors.Orange.Orange600;
            zeroitLabel27.BackColor = Colors.Orange.Orange600;
            zeroitLabel28.BackColor = Colors.Orange.Orange600;
        }

        private void Orange_700_MouseEnter(object sender, EventArgs e)
        {
            Orange_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Orange_700_MouseLeave(object sender, EventArgs e)
        {
            Orange_700.BackColor = Colors.Orange.Orange700;
            zeroitLabel29.BackColor = Colors.Orange.Orange700;
            zeroitLabel30.BackColor = Colors.Orange.Orange700;
        }

        private void Orange_800_MouseEnter(object sender, EventArgs e)
        {
            Orange_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Orange_800_MouseLeave(object sender, EventArgs e)
        {
            Orange_800.BackColor = Colors.Orange.Orange800;
            zeroitLabel31.BackColor = Colors.Orange.Orange800;
            zeroitLabel32.BackColor = Colors.Orange.Orange800;
        }

        private void Orange_900_MouseEnter(object sender, EventArgs e)
        {
            Orange_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Orange_900_MouseLeave(object sender, EventArgs e)
        {
            Orange_900.BackColor = Colors.Orange.Orange900;
            zeroitLabel33.BackColor = Colors.Orange.Orange900;
            zeroitLabel34.BackColor = Colors.Orange.Orange900;
        }

        private void Orange_A100_MouseEnter(object sender, EventArgs e)
        {
            Orange_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Orange_A100_MouseLeave(object sender, EventArgs e)
        {
            Orange_A100.BackColor = Colors.Orange.OrangeA100;
            zeroitLabel35.BackColor = Colors.Orange.OrangeA100;
            zeroitLabel36.BackColor = Colors.Orange.OrangeA100;
        }

        private void Orange_A200_MouseEnter(object sender, EventArgs e)
        {
            Orange_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Orange_A200_MouseLeave(object sender, EventArgs e)
        {
            Orange_A200.BackColor = Colors.Orange.OrangeA200;
            zeroitLabel37.BackColor = Colors.Orange.OrangeA200;
            zeroitLabel38.BackColor = Colors.Orange.OrangeA200;
        }

        private void Orange_A400_MouseEnter(object sender, EventArgs e)
        {
            Orange_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Orange_A400_MouseLeave(object sender, EventArgs e)
        {
            Orange_A400.BackColor = Colors.Orange.OrangeA400;
            zeroitLabel39.BackColor = Colors.Orange.OrangeA400;
            zeroitLabel40.BackColor = Colors.Orange.OrangeA400;
        }

        private void Orange_A700_MouseEnter(object sender, EventArgs e)
        {
            Orange_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Orange_A700_MouseLeave(object sender, EventArgs e)
        {
            Orange_A700.BackColor = Colors.Orange.OrangeA700;
            zeroitLabel41.BackColor = Colors.Orange.OrangeA700;
            zeroitLabel42.BackColor = Colors.Orange.OrangeA700;
        }





        private void Orange_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.Orange50;
            control.BackColor = Colors.Orange.Orange50;
        }


        private void Orange_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.Orange100;
            control.BackColor = Colors.Orange.Orange100;
        }

        private void Orange_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.Orange200;
            control.BackColor = Colors.Orange.Orange200;
        }

        private void Orange_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.Orange300;
            control.BackColor = Colors.Orange.Orange300;
        }

        private void Orange_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.Orange400;
            control.BackColor = Colors.Orange.Orange400;
        }

        private void Orange_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.Orange500;
            control.BackColor = Colors.Orange.Orange500;
        }


        private void Orange_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.Orange600;
            control.BackColor = Colors.Orange.Orange600;
        }

        private void Orange_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.Orange700;
            control.BackColor = Colors.Orange.Orange700;
        }

        private void Orange_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.Orange800;
            control.BackColor = Colors.Orange.Orange800;
        }

        private void Orange_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.Orange900;
            control.BackColor = Colors.Orange.Orange900;
        }

        private void Orange_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.OrangeA100;
            control.BackColor = Colors.Orange.OrangeA100;
        }

        private void Orange_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.OrangeA200;
            control.BackColor = Colors.Orange.OrangeA200;
        }

        private void Orange_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.OrangeA400;
            control.BackColor = Colors.Orange.OrangeA400;
        }

        private void Orange_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Orange.OrangeA700;
            control.BackColor = Colors.Orange.OrangeA700;
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

        private void OrangeControl_Paint(object sender, PaintEventArgs e)
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
