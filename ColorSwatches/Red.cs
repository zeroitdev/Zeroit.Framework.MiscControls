// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Red.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.ColorSwatches
{
    /// <summary>
    /// A class collection for rendering a Material Design Red color control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public partial class Red : UserControl
    {
        private static Color red_header_500 = Color.FromArgb(244, 67, 54);
        private static Color red_50 = Color.FromArgb(255, 235, 238);
        private static Color red_100 = Color.FromArgb(255, 205, 210);
        private static Color red_200 = Color.FromArgb(239, 154, 154);
        private static Color red_300 = Color.FromArgb(229, 115, 115);
        private static Color red_400 = Color.FromArgb(239, 83, 80);
        private static Color red_500 = Color.FromArgb(244, 67, 54);
        private static Color red_600 = Color.FromArgb(229, 57, 53);
        private static Color red_700 = Color.FromArgb(211, 47, 47);
        private static Color red_800 = Color.FromArgb(198, 40, 40);
        private static Color red_900 = Color.FromArgb(183, 28, 28);
        private static Color red_A100 = Color.FromArgb(255, 138, 128);
        private static Color red_A200 = Color.FromArgb(255, 82, 82);
        private static Color red_A400 = Color.FromArgb(255, 23, 68);
        private static Color red_A700 = Color.FromArgb(213, 0, 0);



        public Red()
        {
            InitializeComponent();
        }

        private void zeroitExtendedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Red_500_Header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Red_500_Header_MouseEnter(object sender, EventArgs e)
        {
            Red_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel22.BackColor = Color.FromArgb(0, 122, 204);
            
        }

        private void Red_500_Header_MouseLeave(object sender, EventArgs e)
        {
            Red_500_Header.BackColor = red_header_500;
            zeroitLabel20.BackColor = red_header_500;
            zeroitLabel21.BackColor = red_header_500;
            zeroitLabel22.BackColor = red_header_500;
        }

        private void Red_50_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Red_50_MouseEnter(object sender, EventArgs e)
        {
            Red_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void zeroitLabel18_Click(object sender, EventArgs e)
        {

        }

        private void zeroitLabel19_Click(object sender, EventArgs e)
        {

        }

        private void Red_50_MouseLeave(object sender, EventArgs e)
        {
            Red_50.BackColor = red_50;
            zeroitLabel18.BackColor = red_50;
            zeroitLabel19.BackColor = red_50;
        }

        private void Red_500_Header_Click(object sender, EventArgs e)
        {
            Red_500_Header.BackColor = red_header_500;
            zeroitLabel20.BackColor = red_header_500;
            zeroitLabel21.BackColor = red_header_500;
            zeroitLabel22.BackColor = red_header_500;
        }

        private void Red_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            Red_500_Header.BackColor = red_header_500;
            zeroitLabel20.BackColor = red_header_500;
            zeroitLabel21.BackColor = red_header_500;
            zeroitLabel22.BackColor = red_header_500;
        }

        private void Red_100_MouseEnter(object sender, EventArgs e)
        {
            Red_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Red_100_MouseLeave(object sender, EventArgs e)
        {
            Red_100.BackColor = red_100;
            zeroitLabel16.BackColor = red_100;
            zeroitLabel17.BackColor = red_100;
        }

        private void Red_200_MouseEnter(object sender, EventArgs e)
        {
            Red_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Red_200_MouseLeave(object sender, EventArgs e)
        {
            Red_200.BackColor = red_200;
            zeroitLabel14.BackColor = red_200;
            zeroitLabel15.BackColor = red_200;
        }

        private void Red_300_MouseEnter(object sender, EventArgs e)
        {
            Red_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Red_300_MouseLeave(object sender, EventArgs e)
        {
            Red_300.BackColor = red_300;
            zeroitLabel13.BackColor = red_300;
            zeroitLabel2.BackColor = red_300;
        }

        private void Red_400_MouseEnter(object sender, EventArgs e)
        {
            Red_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Red_400_MouseLeave(object sender, EventArgs e)
        {
            Red_400.BackColor = red_400;
            zeroitLabel23.BackColor = red_400;
            zeroitLabel24.BackColor = red_400;
        }

        private void Red_500_MouseEnter(object sender, EventArgs e)
        {
            Red_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Red_500_MouseLeave(object sender, EventArgs e)
        {
            Red_500.BackColor = red_500;
            zeroitLabel25.BackColor = red_500;
            zeroitLabel26.BackColor = red_500;
        }

        private void Red_600_MouseEnter(object sender, EventArgs e)
        {
            Red_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Red_600_MouseLeave(object sender, EventArgs e)
        {
            Red_600.BackColor = red_600;
            zeroitLabel27.BackColor = red_600;
            zeroitLabel28.BackColor = red_600;
        }

        private void Red_700_MouseEnter(object sender, EventArgs e)
        {
            Red_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Red_700_MouseLeave(object sender, EventArgs e)
        {
            Red_700.BackColor = red_700;
            zeroitLabel29.BackColor = red_700;
            zeroitLabel30.BackColor = red_700;
        }

        private void Red_800_MouseEnter(object sender, EventArgs e)
        {
            Red_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Red_800_MouseLeave(object sender, EventArgs e)
        {
            Red_800.BackColor = red_800;
            zeroitLabel31.BackColor = red_800;
            zeroitLabel32.BackColor = red_800;
        }

        private void Red_900_MouseEnter(object sender, EventArgs e)
        {
            Red_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Red_900_MouseLeave(object sender, EventArgs e)
        {
            Red_900.BackColor = red_900;
            zeroitLabel33.BackColor = red_900;
            zeroitLabel34.BackColor = red_900;
        }

        private void Red_A100_MouseEnter(object sender, EventArgs e)
        {
            Red_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Red_A100_MouseLeave(object sender, EventArgs e)
        {
            Red_A100.BackColor = red_A100;
            zeroitLabel35.BackColor = red_A100;
            zeroitLabel36.BackColor = red_A100;
        }

        private void Red_A200_MouseEnter(object sender, EventArgs e)
        {
            Red_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Red_A200_MouseLeave(object sender, EventArgs e)
        {
            Red_A200.BackColor = red_A200;
            zeroitLabel37.BackColor = red_A200;
            zeroitLabel38.BackColor = red_A200;
        }

        private void Red_A400_MouseEnter(object sender, EventArgs e)
        {
            Red_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Red_A400_MouseLeave(object sender, EventArgs e)
        {
            Red_A400.BackColor = red_A400;
            zeroitLabel39.BackColor = red_A400;
            zeroitLabel40.BackColor = red_A400;
        }

        private void Red_A700_MouseEnter(object sender, EventArgs e)
        {
            Red_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Red_A700_MouseLeave(object sender, EventArgs e)
        {
            Red_A700.BackColor = red_A700;
            zeroitLabel41.BackColor = red_A700;
            zeroitLabel42.BackColor = red_A700;
        }
    }
}
