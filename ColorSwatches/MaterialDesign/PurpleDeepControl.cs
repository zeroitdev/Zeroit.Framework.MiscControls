// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PurpleDeepControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection representing Material Design color PurpleDeep dialog.
    /// </summary>
    public partial class DeepPurpleControl : System.Windows.Forms.Form
    {

        #region Constructor
        public DeepPurpleControl()
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
        private void DeepPurple_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //DeepPurple_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = DeepPurple_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void DeepPurple_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            DeepPurple_500_Header.BackColor = Colors.DeepPurple.DeepPurpleHeader500;
            zeroitLabel20.BackColor = Colors.DeepPurple.DeepPurpleHeader500;
            zeroitLabel21.BackColor = Colors.DeepPurple.DeepPurpleHeader500;
            swatchNameLabel.BackColor = Colors.DeepPurple.DeepPurpleHeader500;
        }

        private void DeepPurple_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurpleHeader500;
            control.BackColor = Colors.DeepPurple.DeepPurpleHeader500;

        }

        private void DeepPurple_500_Header_Click(object sender, EventArgs e)
        {
            DeepPurple_500_Header.BackColor = Colors.DeepPurple.DeepPurpleHeader500;
            zeroitLabel20.BackColor = Colors.DeepPurple.DeepPurpleHeader500;
            zeroitLabel21.BackColor = Colors.DeepPurple.DeepPurpleHeader500;
            swatchNameLabel.BackColor = Colors.DeepPurple.DeepPurpleHeader500;
        }

        private void DeepPurple_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            DeepPurple_500_Header.BackColor = Colors.DeepPurple.DeepPurpleHeader500;
            zeroitLabel20.BackColor = Colors.DeepPurple.DeepPurpleHeader500;
            zeroitLabel21.BackColor = Colors.DeepPurple.DeepPurpleHeader500;
            swatchNameLabel.BackColor = Colors.DeepPurple.DeepPurpleHeader500;
        }


        private void DeepPurple_50_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void DeepPurple_50_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_50.BackColor = Colors.DeepPurple.DeepPurple50;
            zeroitLabel18.BackColor = Colors.DeepPurple.DeepPurple50;
            zeroitLabel19.BackColor = Colors.DeepPurple.DeepPurple50;
        }



        private void DeepPurple_100_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepPurple_100_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_100.BackColor = Colors.DeepPurple.DeepPurple100;
            zeroitLabel16.BackColor = Colors.DeepPurple.DeepPurple100;
            zeroitLabel17.BackColor = Colors.DeepPurple.DeepPurple100;
        }

        private void DeepPurple_200_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepPurple_200_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_200.BackColor = Colors.DeepPurple.DeepPurple200;
            zeroitLabel14.BackColor = Colors.DeepPurple.DeepPurple200;
            zeroitLabel15.BackColor = Colors.DeepPurple.DeepPurple200;
        }

        private void DeepPurple_300_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepPurple_300_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_300.BackColor = Colors.DeepPurple.DeepPurple300;
            zeroitLabel13.BackColor = Colors.DeepPurple.DeepPurple300;
            zeroitLabel2.BackColor = Colors.DeepPurple.DeepPurple300;
        }

        private void DeepPurple_400_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepPurple_400_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_400.BackColor = Colors.DeepPurple.DeepPurple400;
            zeroitLabel23.BackColor = Colors.DeepPurple.DeepPurple400;
            zeroitLabel24.BackColor = Colors.DeepPurple.DeepPurple400;
        }

        private void DeepPurple_500_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepPurple_500_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_500.BackColor = Colors.DeepPurple.DeepPurple500;
            zeroitLabel25.BackColor = Colors.DeepPurple.DeepPurple500;
            zeroitLabel26.BackColor = Colors.DeepPurple.DeepPurple500;
        }

        private void DeepPurple_600_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepPurple_600_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_600.BackColor = Colors.DeepPurple.DeepPurple600;
            zeroitLabel27.BackColor = Colors.DeepPurple.DeepPurple600;
            zeroitLabel28.BackColor = Colors.DeepPurple.DeepPurple600;
        }

        private void DeepPurple_700_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepPurple_700_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_700.BackColor = Colors.DeepPurple.DeepPurple700;
            zeroitLabel29.BackColor = Colors.DeepPurple.DeepPurple700;
            zeroitLabel30.BackColor = Colors.DeepPurple.DeepPurple700;
        }

        private void DeepPurple_800_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepPurple_800_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_800.BackColor = Colors.DeepPurple.DeepPurple800;
            zeroitLabel31.BackColor = Colors.DeepPurple.DeepPurple800;
            zeroitLabel32.BackColor = Colors.DeepPurple.DeepPurple800;
        }

        private void DeepPurple_900_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepPurple_900_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_900.BackColor = Colors.DeepPurple.DeepPurple900;
            zeroitLabel33.BackColor = Colors.DeepPurple.DeepPurple900;
            zeroitLabel34.BackColor = Colors.DeepPurple.DeepPurple900;
        }

        private void DeepPurple_A100_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepPurple_A100_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_A100.BackColor = Colors.DeepPurple.DeepPurpleA100;
            zeroitLabel35.BackColor = Colors.DeepPurple.DeepPurpleA100;
            zeroitLabel36.BackColor = Colors.DeepPurple.DeepPurpleA100;
        }

        private void DeepPurple_A200_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepPurple_A200_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_A200.BackColor = Colors.DeepPurple.DeepPurpleA200;
            zeroitLabel37.BackColor = Colors.DeepPurple.DeepPurpleA200;
            zeroitLabel38.BackColor = Colors.DeepPurple.DeepPurpleA200;
        }

        private void DeepPurple_A400_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepPurple_A400_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_A400.BackColor = Colors.DeepPurple.DeepPurpleA400;
            zeroitLabel39.BackColor = Colors.DeepPurple.DeepPurpleA400;
            zeroitLabel40.BackColor = Colors.DeepPurple.DeepPurpleA400;
        }

        private void DeepPurple_A700_MouseEnter(object sender, EventArgs e)
        {
            DeepPurple_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepPurple_A700_MouseLeave(object sender, EventArgs e)
        {
            DeepPurple_A700.BackColor = Colors.DeepPurple.DeepPurpleA700;
            zeroitLabel41.BackColor = Colors.DeepPurple.DeepPurpleA700;
            zeroitLabel42.BackColor = Colors.DeepPurple.DeepPurpleA700;
        }





        private void DeepPurple_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurple50;
            control.BackColor = Colors.DeepPurple.DeepPurple50;
        }


        private void DeepPurple_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurple100;
            control.BackColor = Colors.DeepPurple.DeepPurple100;
        }

        private void DeepPurple_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurple200;
            control.BackColor = Colors.DeepPurple.DeepPurple200;
        }

        private void DeepPurple_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurple300;
            control.BackColor = Colors.DeepPurple.DeepPurple300;
        }

        private void DeepPurple_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurple400;
            control.BackColor = Colors.DeepPurple.DeepPurple400;
        }

        private void DeepPurple_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurple500;
            control.BackColor = Colors.DeepPurple.DeepPurple500;
        }


        private void DeepPurple_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurple600;
            control.BackColor = Colors.DeepPurple.DeepPurple600;
        }

        private void DeepPurple_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurple700;
            control.BackColor = Colors.DeepPurple.DeepPurple700;
        }

        private void DeepPurple_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurple800;
            control.BackColor = Colors.DeepPurple.DeepPurple800;
        }

        private void DeepPurple_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurple900;
            control.BackColor = Colors.DeepPurple.DeepPurple900;
        }

        private void DeepPurple_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurpleA100;
            control.BackColor = Colors.DeepPurple.DeepPurpleA100;
        }

        private void DeepPurple_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurpleA200;
            control.BackColor = Colors.DeepPurple.DeepPurpleA200;
        }

        private void DeepPurple_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurpleA400;
            control.BackColor = Colors.DeepPurple.DeepPurpleA400;
        }

        private void DeepPurple_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepPurple.DeepPurpleA700;
            control.BackColor = Colors.DeepPurple.DeepPurpleA700;
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

        private void DeepPurpleControl_Paint(object sender, PaintEventArgs e)
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
