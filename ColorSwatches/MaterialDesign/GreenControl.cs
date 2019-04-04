// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="GreenControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection representing Material Design color Green dialog.
    /// </summary>
    public partial class GreenControl : System.Windows.Forms.Form
    {

        #region Constructor
        public GreenControl()
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
        private void Green_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //Green_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = Green_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void Green_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            Green_500_Header.BackColor = Colors.Green.GreenHeader500;
            zeroitLabel20.BackColor = Colors.Green.GreenHeader500;
            zeroitLabel21.BackColor = Colors.Green.GreenHeader500;
            swatchNameLabel.BackColor = Colors.Green.GreenHeader500;
        }

        private void Green_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.GreenHeader500;
            control.BackColor = Colors.Green.GreenHeader500;

        }

        private void Green_500_Header_Click(object sender, EventArgs e)
        {
            Green_500_Header.BackColor = Colors.Green.GreenHeader500;
            zeroitLabel20.BackColor = Colors.Green.GreenHeader500;
            zeroitLabel21.BackColor = Colors.Green.GreenHeader500;
            swatchNameLabel.BackColor = Colors.Green.GreenHeader500;
        }

        private void Green_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            Green_500_Header.BackColor = Colors.Green.GreenHeader500;
            zeroitLabel20.BackColor = Colors.Green.GreenHeader500;
            zeroitLabel21.BackColor = Colors.Green.GreenHeader500;
            swatchNameLabel.BackColor = Colors.Green.GreenHeader500;
        }


        private void Green_50_MouseEnter(object sender, EventArgs e)
        {
            Green_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void Green_50_MouseLeave(object sender, EventArgs e)
        {
            Green_50.BackColor = Colors.Green.Green50;
            zeroitLabel18.BackColor = Colors.Green.Green50;
            zeroitLabel19.BackColor = Colors.Green.Green50;
        }



        private void Green_100_MouseEnter(object sender, EventArgs e)
        {
            Green_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Green_100_MouseLeave(object sender, EventArgs e)
        {
            Green_100.BackColor = Colors.Green.Green100;
            zeroitLabel16.BackColor = Colors.Green.Green100;
            zeroitLabel17.BackColor = Colors.Green.Green100;
        }

        private void Green_200_MouseEnter(object sender, EventArgs e)
        {
            Green_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Green_200_MouseLeave(object sender, EventArgs e)
        {
            Green_200.BackColor = Colors.Green.Green200;
            zeroitLabel14.BackColor = Colors.Green.Green200;
            zeroitLabel15.BackColor = Colors.Green.Green200;
        }

        private void Green_300_MouseEnter(object sender, EventArgs e)
        {
            Green_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Green_300_MouseLeave(object sender, EventArgs e)
        {
            Green_300.BackColor = Colors.Green.Green300;
            zeroitLabel13.BackColor = Colors.Green.Green300;
            zeroitLabel2.BackColor = Colors.Green.Green300;
        }

        private void Green_400_MouseEnter(object sender, EventArgs e)
        {
            Green_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Green_400_MouseLeave(object sender, EventArgs e)
        {
            Green_400.BackColor = Colors.Green.Green400;
            zeroitLabel23.BackColor = Colors.Green.Green400;
            zeroitLabel24.BackColor = Colors.Green.Green400;
        }

        private void Green_500_MouseEnter(object sender, EventArgs e)
        {
            Green_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Green_500_MouseLeave(object sender, EventArgs e)
        {
            Green_500.BackColor = Colors.Green.Green500;
            zeroitLabel25.BackColor = Colors.Green.Green500;
            zeroitLabel26.BackColor = Colors.Green.Green500;
        }

        private void Green_600_MouseEnter(object sender, EventArgs e)
        {
            Green_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Green_600_MouseLeave(object sender, EventArgs e)
        {
            Green_600.BackColor = Colors.Green.Green600;
            zeroitLabel27.BackColor = Colors.Green.Green600;
            zeroitLabel28.BackColor = Colors.Green.Green600;
        }

        private void Green_700_MouseEnter(object sender, EventArgs e)
        {
            Green_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Green_700_MouseLeave(object sender, EventArgs e)
        {
            Green_700.BackColor = Colors.Green.Green700;
            zeroitLabel29.BackColor = Colors.Green.Green700;
            zeroitLabel30.BackColor = Colors.Green.Green700;
        }

        private void Green_800_MouseEnter(object sender, EventArgs e)
        {
            Green_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Green_800_MouseLeave(object sender, EventArgs e)
        {
            Green_800.BackColor = Colors.Green.Green800;
            zeroitLabel31.BackColor = Colors.Green.Green800;
            zeroitLabel32.BackColor = Colors.Green.Green800;
        }

        private void Green_900_MouseEnter(object sender, EventArgs e)
        {
            Green_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Green_900_MouseLeave(object sender, EventArgs e)
        {
            Green_900.BackColor = Colors.Green.Green900;
            zeroitLabel33.BackColor = Colors.Green.Green900;
            zeroitLabel34.BackColor = Colors.Green.Green900;
        }

        private void Green_A100_MouseEnter(object sender, EventArgs e)
        {
            Green_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Green_A100_MouseLeave(object sender, EventArgs e)
        {
            Green_A100.BackColor = Colors.Green.GreenA100;
            zeroitLabel35.BackColor = Colors.Green.GreenA100;
            zeroitLabel36.BackColor = Colors.Green.GreenA100;
        }

        private void Green_A200_MouseEnter(object sender, EventArgs e)
        {
            Green_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Green_A200_MouseLeave(object sender, EventArgs e)
        {
            Green_A200.BackColor = Colors.Green.GreenA200;
            zeroitLabel37.BackColor = Colors.Green.GreenA200;
            zeroitLabel38.BackColor = Colors.Green.GreenA200;
        }

        private void Green_A400_MouseEnter(object sender, EventArgs e)
        {
            Green_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Green_A400_MouseLeave(object sender, EventArgs e)
        {
            Green_A400.BackColor = Colors.Green.GreenA400;
            zeroitLabel39.BackColor = Colors.Green.GreenA400;
            zeroitLabel40.BackColor = Colors.Green.GreenA400;
        }

        private void Green_A700_MouseEnter(object sender, EventArgs e)
        {
            Green_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Green_A700_MouseLeave(object sender, EventArgs e)
        {
            Green_A700.BackColor = Colors.Green.GreenA700;
            zeroitLabel41.BackColor = Colors.Green.GreenA700;
            zeroitLabel42.BackColor = Colors.Green.GreenA700;
        }





        private void Green_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.Green50;
            control.BackColor = Colors.Green.Green50;
        }


        private void Green_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.Green100;
            control.BackColor = Colors.Green.Green100;
        }

        private void Green_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.Green200;
            control.BackColor = Colors.Green.Green200;
        }

        private void Green_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.Green300;
            control.BackColor = Colors.Green.Green300;
        }

        private void Green_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.Green400;
            control.BackColor = Colors.Green.Green400;
        }

        private void Green_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.Green500;
            control.BackColor = Colors.Green.Green500;
        }


        private void Green_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.Green600;
            control.BackColor = Colors.Green.Green600;
        }

        private void Green_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.Green700;
            control.BackColor = Colors.Green.Green700;
        }

        private void Green_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.Green800;
            control.BackColor = Colors.Green.Green800;
        }

        private void Green_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.Green900;
            control.BackColor = Colors.Green.Green900;
        }

        private void Green_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.GreenA100;
            control.BackColor = Colors.Green.GreenA100;
        }

        private void Green_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.GreenA200;
            control.BackColor = Colors.Green.GreenA200;
        }

        private void Green_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.GreenA400;
            control.BackColor = Colors.Green.GreenA400;
        }

        private void Green_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Green.GreenA700;
            control.BackColor = Colors.Green.GreenA700;
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

        private void GreenControl_Paint(object sender, PaintEventArgs e)
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
