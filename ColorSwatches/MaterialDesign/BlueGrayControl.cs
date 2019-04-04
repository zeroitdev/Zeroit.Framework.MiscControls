// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="BlueGrayControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection representing Material Design color BlueGrey dialog.
    /// </summary>
    public partial class BlueGrayControl : System.Windows.Forms.Form
    {
        #region Constructor
        public BlueGrayControl()
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
        private void BlueGrey_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //BlueGrey_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = BlueGrey_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void BlueGrey_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            BlueGrey_500_Header.BackColor = Colors.BlueGrey.BlueGreyHeader500;
            zeroitLabel20.BackColor = Colors.BlueGrey.BlueGreyHeader500;
            zeroitLabel21.BackColor = Colors.BlueGrey.BlueGreyHeader500;
            swatchNameLabel.BackColor = Colors.BlueGrey.BlueGreyHeader500;
        }

        private void BlueGrey_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.BlueGrey.BlueGreyHeader500;
            control.BackColor = Colors.BlueGrey.BlueGreyHeader500;

        }

        private void BlueGrey_500_Header_Click(object sender, EventArgs e)
        {
            BlueGrey_500_Header.BackColor = Colors.BlueGrey.BlueGreyHeader500;
            zeroitLabel20.BackColor = Colors.BlueGrey.BlueGreyHeader500;
            zeroitLabel21.BackColor = Colors.BlueGrey.BlueGreyHeader500;
            swatchNameLabel.BackColor = Colors.BlueGrey.BlueGreyHeader500;
        }

        private void BlueGrey_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            BlueGrey_500_Header.BackColor = Colors.BlueGrey.BlueGreyHeader500;
            zeroitLabel20.BackColor = Colors.BlueGrey.BlueGreyHeader500;
            zeroitLabel21.BackColor = Colors.BlueGrey.BlueGreyHeader500;
            swatchNameLabel.BackColor = Colors.BlueGrey.BlueGreyHeader500;
        }


        private void BlueGrey_50_MouseEnter(object sender, EventArgs e)
        {
            BlueGrey_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void BlueGrey_50_MouseLeave(object sender, EventArgs e)
        {
            BlueGrey_50.BackColor = Colors.BlueGrey.BlueGrey50;
            zeroitLabel18.BackColor = Colors.BlueGrey.BlueGrey50;
            zeroitLabel19.BackColor = Colors.BlueGrey.BlueGrey50;
        }



        private void BlueGrey_100_MouseEnter(object sender, EventArgs e)
        {
            BlueGrey_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void BlueGrey_100_MouseLeave(object sender, EventArgs e)
        {
            BlueGrey_100.BackColor = Colors.BlueGrey.BlueGrey100;
            zeroitLabel16.BackColor = Colors.BlueGrey.BlueGrey100;
            zeroitLabel17.BackColor = Colors.BlueGrey.BlueGrey100;
        }

        private void BlueGrey_200_MouseEnter(object sender, EventArgs e)
        {
            BlueGrey_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void BlueGrey_200_MouseLeave(object sender, EventArgs e)
        {
            BlueGrey_200.BackColor = Colors.BlueGrey.BlueGrey200;
            zeroitLabel14.BackColor = Colors.BlueGrey.BlueGrey200;
            zeroitLabel15.BackColor = Colors.BlueGrey.BlueGrey200;
        }

        private void BlueGrey_300_MouseEnter(object sender, EventArgs e)
        {
            BlueGrey_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void BlueGrey_300_MouseLeave(object sender, EventArgs e)
        {
            BlueGrey_300.BackColor = Colors.BlueGrey.BlueGrey300;
            zeroitLabel13.BackColor = Colors.BlueGrey.BlueGrey300;
            zeroitLabel2.BackColor = Colors.BlueGrey.BlueGrey300;
        }

        private void BlueGrey_400_MouseEnter(object sender, EventArgs e)
        {
            BlueGrey_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void BlueGrey_400_MouseLeave(object sender, EventArgs e)
        {
            BlueGrey_400.BackColor = Colors.BlueGrey.BlueGrey400;
            zeroitLabel23.BackColor = Colors.BlueGrey.BlueGrey400;
            zeroitLabel24.BackColor = Colors.BlueGrey.BlueGrey400;
        }

        private void BlueGrey_500_MouseEnter(object sender, EventArgs e)
        {
            BlueGrey_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void BlueGrey_500_MouseLeave(object sender, EventArgs e)
        {
            BlueGrey_500.BackColor = Colors.BlueGrey.BlueGrey500;
            zeroitLabel25.BackColor = Colors.BlueGrey.BlueGrey500;
            zeroitLabel26.BackColor = Colors.BlueGrey.BlueGrey500;
        }

        private void BlueGrey_600_MouseEnter(object sender, EventArgs e)
        {
            BlueGrey_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void BlueGrey_600_MouseLeave(object sender, EventArgs e)
        {
            BlueGrey_600.BackColor = Colors.BlueGrey.BlueGrey600;
            zeroitLabel27.BackColor = Colors.BlueGrey.BlueGrey600;
            zeroitLabel28.BackColor = Colors.BlueGrey.BlueGrey600;
        }

        private void BlueGrey_700_MouseEnter(object sender, EventArgs e)
        {
            BlueGrey_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void BlueGrey_700_MouseLeave(object sender, EventArgs e)
        {
            BlueGrey_700.BackColor = Colors.BlueGrey.BlueGrey700;
            zeroitLabel29.BackColor = Colors.BlueGrey.BlueGrey700;
            zeroitLabel30.BackColor = Colors.BlueGrey.BlueGrey700;
        }

        private void BlueGrey_800_MouseEnter(object sender, EventArgs e)
        {
            BlueGrey_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void BlueGrey_800_MouseLeave(object sender, EventArgs e)
        {
            BlueGrey_800.BackColor = Colors.BlueGrey.BlueGrey800;
            zeroitLabel31.BackColor = Colors.BlueGrey.BlueGrey800;
            zeroitLabel32.BackColor = Colors.BlueGrey.BlueGrey800;
        }

        private void BlueGrey_900_MouseEnter(object sender, EventArgs e)
        {
            BlueGrey_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void BlueGrey_900_MouseLeave(object sender, EventArgs e)
        {
            BlueGrey_900.BackColor = Colors.BlueGrey.BlueGrey900;
            zeroitLabel33.BackColor = Colors.BlueGrey.BlueGrey900;
            zeroitLabel34.BackColor = Colors.BlueGrey.BlueGrey900;
        }

        

        private void BlueGrey_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.BlueGrey.BlueGrey50;
            control.BackColor = Colors.BlueGrey.BlueGrey50;
        }


        private void BlueGrey_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.BlueGrey.BlueGrey100;
            control.BackColor = Colors.BlueGrey.BlueGrey100;
        }

        private void BlueGrey_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.BlueGrey.BlueGrey200;
            control.BackColor = Colors.BlueGrey.BlueGrey200;
        }

        private void BlueGrey_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.BlueGrey.BlueGrey300;
            control.BackColor = Colors.BlueGrey.BlueGrey300;
        }

        private void BlueGrey_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.BlueGrey.BlueGrey400;
            control.BackColor = Colors.BlueGrey.BlueGrey400;
        }

        private void BlueGrey_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.BlueGrey.BlueGrey500;
            control.BackColor = Colors.BlueGrey.BlueGrey500;
        }


        private void BlueGrey_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.BlueGrey.BlueGrey600;
            control.BackColor = Colors.BlueGrey.BlueGrey600;
        }

        private void BlueGrey_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.BlueGrey.BlueGrey700;
            control.BackColor = Colors.BlueGrey.BlueGrey700;
        }

        private void BlueGrey_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.BlueGrey.BlueGrey800;
            control.BackColor = Colors.BlueGrey.BlueGrey800;
        }

        private void BlueGrey_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.BlueGrey.BlueGrey900;
            control.BackColor = Colors.BlueGrey.BlueGrey900;
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

        private void BlueGreyControl_Paint(object sender, PaintEventArgs e)
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
