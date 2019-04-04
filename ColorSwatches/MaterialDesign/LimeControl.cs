// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="LimeControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection representing Material Design color Lime dialog.
    /// </summary>
    public partial class LimeControl : System.Windows.Forms.Form
    {

        #region Constructor
        public LimeControl()
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
        private void Lime_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //Lime_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = Lime_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void Lime_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            Lime_500_Header.BackColor = Colors.Lime.LimeHeader500;
            zeroitLabel20.BackColor = Colors.Lime.LimeHeader500;
            zeroitLabel21.BackColor = Colors.Lime.LimeHeader500;
            swatchNameLabel.BackColor = Colors.Lime.LimeHeader500;
        }

        private void Lime_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.LimeHeader500;
            control.BackColor = Colors.Lime.LimeHeader500;

        }

        private void Lime_500_Header_Click(object sender, EventArgs e)
        {
            Lime_500_Header.BackColor = Colors.Lime.LimeHeader500;
            zeroitLabel20.BackColor = Colors.Lime.LimeHeader500;
            zeroitLabel21.BackColor = Colors.Lime.LimeHeader500;
            swatchNameLabel.BackColor = Colors.Lime.LimeHeader500;
        }

        private void Lime_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            Lime_500_Header.BackColor = Colors.Lime.LimeHeader500;
            zeroitLabel20.BackColor = Colors.Lime.LimeHeader500;
            zeroitLabel21.BackColor = Colors.Lime.LimeHeader500;
            swatchNameLabel.BackColor = Colors.Lime.LimeHeader500;
        }


        private void Lime_50_MouseEnter(object sender, EventArgs e)
        {
            Lime_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void Lime_50_MouseLeave(object sender, EventArgs e)
        {
            Lime_50.BackColor = Colors.Lime.Lime50;
            zeroitLabel18.BackColor = Colors.Lime.Lime50;
            zeroitLabel19.BackColor = Colors.Lime.Lime50;
        }



        private void Lime_100_MouseEnter(object sender, EventArgs e)
        {
            Lime_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Lime_100_MouseLeave(object sender, EventArgs e)
        {
            Lime_100.BackColor = Colors.Lime.Lime100;
            zeroitLabel16.BackColor = Colors.Lime.Lime100;
            zeroitLabel17.BackColor = Colors.Lime.Lime100;
        }

        private void Lime_200_MouseEnter(object sender, EventArgs e)
        {
            Lime_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Lime_200_MouseLeave(object sender, EventArgs e)
        {
            Lime_200.BackColor = Colors.Lime.Lime200;
            zeroitLabel14.BackColor = Colors.Lime.Lime200;
            zeroitLabel15.BackColor = Colors.Lime.Lime200;
        }

        private void Lime_300_MouseEnter(object sender, EventArgs e)
        {
            Lime_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Lime_300_MouseLeave(object sender, EventArgs e)
        {
            Lime_300.BackColor = Colors.Lime.Lime300;
            zeroitLabel13.BackColor = Colors.Lime.Lime300;
            zeroitLabel2.BackColor = Colors.Lime.Lime300;
        }

        private void Lime_400_MouseEnter(object sender, EventArgs e)
        {
            Lime_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Lime_400_MouseLeave(object sender, EventArgs e)
        {
            Lime_400.BackColor = Colors.Lime.Lime400;
            zeroitLabel23.BackColor = Colors.Lime.Lime400;
            zeroitLabel24.BackColor = Colors.Lime.Lime400;
        }

        private void Lime_500_MouseEnter(object sender, EventArgs e)
        {
            Lime_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Lime_500_MouseLeave(object sender, EventArgs e)
        {
            Lime_500.BackColor = Colors.Lime.Lime500;
            zeroitLabel25.BackColor = Colors.Lime.Lime500;
            zeroitLabel26.BackColor = Colors.Lime.Lime500;
        }

        private void Lime_600_MouseEnter(object sender, EventArgs e)
        {
            Lime_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Lime_600_MouseLeave(object sender, EventArgs e)
        {
            Lime_600.BackColor = Colors.Lime.Lime600;
            zeroitLabel27.BackColor = Colors.Lime.Lime600;
            zeroitLabel28.BackColor = Colors.Lime.Lime600;
        }

        private void Lime_700_MouseEnter(object sender, EventArgs e)
        {
            Lime_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Lime_700_MouseLeave(object sender, EventArgs e)
        {
            Lime_700.BackColor = Colors.Lime.Lime700;
            zeroitLabel29.BackColor = Colors.Lime.Lime700;
            zeroitLabel30.BackColor = Colors.Lime.Lime700;
        }

        private void Lime_800_MouseEnter(object sender, EventArgs e)
        {
            Lime_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Lime_800_MouseLeave(object sender, EventArgs e)
        {
            Lime_800.BackColor = Colors.Lime.Lime800;
            zeroitLabel31.BackColor = Colors.Lime.Lime800;
            zeroitLabel32.BackColor = Colors.Lime.Lime800;
        }

        private void Lime_900_MouseEnter(object sender, EventArgs e)
        {
            Lime_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Lime_900_MouseLeave(object sender, EventArgs e)
        {
            Lime_900.BackColor = Colors.Lime.Lime900;
            zeroitLabel33.BackColor = Colors.Lime.Lime900;
            zeroitLabel34.BackColor = Colors.Lime.Lime900;
        }

        private void Lime_A100_MouseEnter(object sender, EventArgs e)
        {
            Lime_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Lime_A100_MouseLeave(object sender, EventArgs e)
        {
            Lime_A100.BackColor = Colors.Lime.LimeA100;
            zeroitLabel35.BackColor = Colors.Lime.LimeA100;
            zeroitLabel36.BackColor = Colors.Lime.LimeA100;
        }

        private void Lime_A200_MouseEnter(object sender, EventArgs e)
        {
            Lime_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Lime_A200_MouseLeave(object sender, EventArgs e)
        {
            Lime_A200.BackColor = Colors.Lime.LimeA200;
            zeroitLabel37.BackColor = Colors.Lime.LimeA200;
            zeroitLabel38.BackColor = Colors.Lime.LimeA200;
        }

        private void Lime_A400_MouseEnter(object sender, EventArgs e)
        {
            Lime_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Lime_A400_MouseLeave(object sender, EventArgs e)
        {
            Lime_A400.BackColor = Colors.Lime.LimeA400;
            zeroitLabel39.BackColor = Colors.Lime.LimeA400;
            zeroitLabel40.BackColor = Colors.Lime.LimeA400;
        }

        private void Lime_A700_MouseEnter(object sender, EventArgs e)
        {
            Lime_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Lime_A700_MouseLeave(object sender, EventArgs e)
        {
            Lime_A700.BackColor = Colors.Lime.LimeA700;
            zeroitLabel41.BackColor = Colors.Lime.LimeA700;
            zeroitLabel42.BackColor = Colors.Lime.LimeA700;
        }





        private void Lime_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.Lime50;
            control.BackColor = Colors.Lime.Lime50;
        }


        private void Lime_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.Lime100;
            control.BackColor = Colors.Lime.Lime100;
        }

        private void Lime_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.Lime200;
            control.BackColor = Colors.Lime.Lime200;
        }

        private void Lime_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.Lime300;
            control.BackColor = Colors.Lime.Lime300;
        }

        private void Lime_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.Lime400;
            control.BackColor = Colors.Lime.Lime400;
        }

        private void Lime_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.Lime500;
            control.BackColor = Colors.Lime.Lime500;
        }


        private void Lime_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.Lime600;
            control.BackColor = Colors.Lime.Lime600;
        }

        private void Lime_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.Lime700;
            control.BackColor = Colors.Lime.Lime700;
        }

        private void Lime_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.Lime800;
            control.BackColor = Colors.Lime.Lime800;
        }

        private void Lime_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.Lime900;
            control.BackColor = Colors.Lime.Lime900;
        }

        private void Lime_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.LimeA100;
            control.BackColor = Colors.Lime.LimeA100;
        }

        private void Lime_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.LimeA200;
            control.BackColor = Colors.Lime.LimeA200;
        }

        private void Lime_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.LimeA400;
            control.BackColor = Colors.Lime.LimeA400;
        }

        private void Lime_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Lime.LimeA700;
            control.BackColor = Colors.Lime.LimeA700;
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

        private void LimeControl_Paint(object sender, PaintEventArgs e)
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
