// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="LightBlueControl.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls.ColorSwatches.MaterialDesign
{
    /// <summary>
    /// A class collection representing Material Design color LightBlue dialog.
    /// </summary>
    public partial class LightBlueControl : System.Windows.Forms.Form
    {
        #region Constructor
        public LightBlueControl()
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
        private void LightBlue_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //LightBlue_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = LightBlue_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void LightBlue_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            LightBlue_500_Header.BackColor = Colors.LightBlue.LightBlueHeader500;
            zeroitLabel20.BackColor = Colors.LightBlue.LightBlueHeader500;
            zeroitLabel21.BackColor = Colors.LightBlue.LightBlueHeader500;
            swatchNameLabel.BackColor = Colors.LightBlue.LightBlueHeader500;
        }

        private void LightBlue_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlueHeader500;
            control.BackColor = Colors.LightBlue.LightBlueHeader500;

        }

        private void LightBlue_500_Header_Click(object sender, EventArgs e)
        {
            LightBlue_500_Header.BackColor = Colors.LightBlue.LightBlueHeader500;
            zeroitLabel20.BackColor = Colors.LightBlue.LightBlueHeader500;
            zeroitLabel21.BackColor = Colors.LightBlue.LightBlueHeader500;
            swatchNameLabel.BackColor = Colors.LightBlue.LightBlueHeader500;
        }

        private void LightBlue_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            LightBlue_500_Header.BackColor = Colors.LightBlue.LightBlueHeader500;
            zeroitLabel20.BackColor = Colors.LightBlue.LightBlueHeader500;
            zeroitLabel21.BackColor = Colors.LightBlue.LightBlueHeader500;
            swatchNameLabel.BackColor = Colors.LightBlue.LightBlueHeader500;
        }


        private void LightBlue_50_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void LightBlue_50_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_50.BackColor = Colors.LightBlue.LightBlue50;
            zeroitLabel18.BackColor = Colors.LightBlue.LightBlue50;
            zeroitLabel19.BackColor = Colors.LightBlue.LightBlue50;
        }



        private void LightBlue_100_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightBlue_100_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_100.BackColor = Colors.LightBlue.LightBlue100;
            zeroitLabel16.BackColor = Colors.LightBlue.LightBlue100;
            zeroitLabel17.BackColor = Colors.LightBlue.LightBlue100;
        }

        private void LightBlue_200_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightBlue_200_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_200.BackColor = Colors.LightBlue.LightBlue200;
            zeroitLabel14.BackColor = Colors.LightBlue.LightBlue200;
            zeroitLabel15.BackColor = Colors.LightBlue.LightBlue200;
        }

        private void LightBlue_300_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightBlue_300_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_300.BackColor = Colors.LightBlue.LightBlue300;
            zeroitLabel13.BackColor = Colors.LightBlue.LightBlue300;
            zeroitLabel2.BackColor = Colors.LightBlue.LightBlue300;
        }

        private void LightBlue_400_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightBlue_400_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_400.BackColor = Colors.LightBlue.LightBlue400;
            zeroitLabel23.BackColor = Colors.LightBlue.LightBlue400;
            zeroitLabel24.BackColor = Colors.LightBlue.LightBlue400;
        }

        private void LightBlue_500_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightBlue_500_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_500.BackColor = Colors.LightBlue.LightBlue500;
            zeroitLabel25.BackColor = Colors.LightBlue.LightBlue500;
            zeroitLabel26.BackColor = Colors.LightBlue.LightBlue500;
        }

        private void LightBlue_600_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightBlue_600_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_600.BackColor = Colors.LightBlue.LightBlue600;
            zeroitLabel27.BackColor = Colors.LightBlue.LightBlue600;
            zeroitLabel28.BackColor = Colors.LightBlue.LightBlue600;
        }

        private void LightBlue_700_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightBlue_700_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_700.BackColor = Colors.LightBlue.LightBlue700;
            zeroitLabel29.BackColor = Colors.LightBlue.LightBlue700;
            zeroitLabel30.BackColor = Colors.LightBlue.LightBlue700;
        }

        private void LightBlue_800_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightBlue_800_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_800.BackColor = Colors.LightBlue.LightBlue800;
            zeroitLabel31.BackColor = Colors.LightBlue.LightBlue800;
            zeroitLabel32.BackColor = Colors.LightBlue.LightBlue800;
        }

        private void LightBlue_900_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightBlue_900_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_900.BackColor = Colors.LightBlue.LightBlue900;
            zeroitLabel33.BackColor = Colors.LightBlue.LightBlue900;
            zeroitLabel34.BackColor = Colors.LightBlue.LightBlue900;
        }

        private void LightBlue_A100_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightBlue_A100_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_A100.BackColor = Colors.LightBlue.LightBlueA100;
            zeroitLabel35.BackColor = Colors.LightBlue.LightBlueA100;
            zeroitLabel36.BackColor = Colors.LightBlue.LightBlueA100;
        }

        private void LightBlue_A200_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightBlue_A200_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_A200.BackColor = Colors.LightBlue.LightBlueA200;
            zeroitLabel37.BackColor = Colors.LightBlue.LightBlueA200;
            zeroitLabel38.BackColor = Colors.LightBlue.LightBlueA200;
        }

        private void LightBlue_A400_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightBlue_A400_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_A400.BackColor = Colors.LightBlue.LightBlueA400;
            zeroitLabel39.BackColor = Colors.LightBlue.LightBlueA400;
            zeroitLabel40.BackColor = Colors.LightBlue.LightBlueA400;
        }

        private void LightBlue_A700_MouseEnter(object sender, EventArgs e)
        {
            LightBlue_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightBlue_A700_MouseLeave(object sender, EventArgs e)
        {
            LightBlue_A700.BackColor = Colors.LightBlue.LightBlueA700;
            zeroitLabel41.BackColor = Colors.LightBlue.LightBlueA700;
            zeroitLabel42.BackColor = Colors.LightBlue.LightBlueA700;
        }





        private void LightBlue_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlue50;
            control.BackColor = Colors.LightBlue.LightBlue50;
        }


        private void LightBlue_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlue100;
            control.BackColor = Colors.LightBlue.LightBlue100;
        }

        private void LightBlue_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlue200;
            control.BackColor = Colors.LightBlue.LightBlue200;
        }

        private void LightBlue_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlue300;
            control.BackColor = Colors.LightBlue.LightBlue300;
        }

        private void LightBlue_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlue400;
            control.BackColor = Colors.LightBlue.LightBlue400;
        }

        private void LightBlue_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlue500;
            control.BackColor = Colors.LightBlue.LightBlue500;
        }


        private void LightBlue_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlue600;
            control.BackColor = Colors.LightBlue.LightBlue600;
        }

        private void LightBlue_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlue700;
            control.BackColor = Colors.LightBlue.LightBlue700;
        }

        private void LightBlue_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlue800;
            control.BackColor = Colors.LightBlue.LightBlue800;
        }

        private void LightBlue_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlue900;
            control.BackColor = Colors.LightBlue.LightBlue900;
        }

        private void LightBlue_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlueA100;
            control.BackColor = Colors.LightBlue.LightBlueA100;
        }

        private void LightBlue_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlueA200;
            control.BackColor = Colors.LightBlue.LightBlueA200;
        }

        private void LightBlue_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlueA400;
            control.BackColor = Colors.LightBlue.LightBlueA400;
        }

        private void LightBlue_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightBlue.LightBlueA700;
            control.BackColor = Colors.LightBlue.LightBlueA700;
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

        private void LightBlueControl_Paint(object sender, PaintEventArgs e)
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
