// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PurpleControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection representing Material Design color Purple dialog.
    /// </summary>
    public partial class PurpleControl : System.Windows.Forms.Form
    {

        #region Constructor
        public PurpleControl()
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
        private void Purple_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //Purple_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = Purple_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void Purple_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            Purple_500_Header.BackColor = Colors.Purple.PurpleHeader500;
            zeroitLabel20.BackColor = Colors.Purple.PurpleHeader500;
            zeroitLabel21.BackColor = Colors.Purple.PurpleHeader500;
            swatchNameLabel.BackColor = Colors.Purple.PurpleHeader500;
        }

        private void Purple_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.PurpleHeader500;
            control.BackColor = Colors.Purple.PurpleHeader500;

        }

        private void Purple_500_Header_Click(object sender, EventArgs e)
        {
            Purple_500_Header.BackColor = Colors.Purple.PurpleHeader500;
            zeroitLabel20.BackColor = Colors.Purple.PurpleHeader500;
            zeroitLabel21.BackColor = Colors.Purple.PurpleHeader500;
            swatchNameLabel.BackColor = Colors.Purple.PurpleHeader500;
        }

        private void Purple_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            Purple_500_Header.BackColor = Colors.Purple.PurpleHeader500;
            zeroitLabel20.BackColor = Colors.Purple.PurpleHeader500;
            zeroitLabel21.BackColor = Colors.Purple.PurpleHeader500;
            swatchNameLabel.BackColor = Colors.Purple.PurpleHeader500;
        }


        private void Purple_50_MouseEnter(object sender, EventArgs e)
        {
            Purple_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void Purple_50_MouseLeave(object sender, EventArgs e)
        {
            Purple_50.BackColor = Colors.Purple.Purple50;
            zeroitLabel18.BackColor = Colors.Purple.Purple50;
            zeroitLabel19.BackColor = Colors.Purple.Purple50;
        }



        private void Purple_100_MouseEnter(object sender, EventArgs e)
        {
            Purple_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Purple_100_MouseLeave(object sender, EventArgs e)
        {
            Purple_100.BackColor = Colors.Purple.Purple100;
            zeroitLabel16.BackColor = Colors.Purple.Purple100;
            zeroitLabel17.BackColor = Colors.Purple.Purple100;
        }

        private void Purple_200_MouseEnter(object sender, EventArgs e)
        {
            Purple_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Purple_200_MouseLeave(object sender, EventArgs e)
        {
            Purple_200.BackColor = Colors.Purple.Purple200;
            zeroitLabel14.BackColor = Colors.Purple.Purple200;
            zeroitLabel15.BackColor = Colors.Purple.Purple200;
        }

        private void Purple_300_MouseEnter(object sender, EventArgs e)
        {
            Purple_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Purple_300_MouseLeave(object sender, EventArgs e)
        {
            Purple_300.BackColor = Colors.Purple.Purple300;
            zeroitLabel13.BackColor = Colors.Purple.Purple300;
            zeroitLabel2.BackColor = Colors.Purple.Purple300;
        }

        private void Purple_400_MouseEnter(object sender, EventArgs e)
        {
            Purple_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Purple_400_MouseLeave(object sender, EventArgs e)
        {
            Purple_400.BackColor = Colors.Purple.Purple400;
            zeroitLabel23.BackColor = Colors.Purple.Purple400;
            zeroitLabel24.BackColor = Colors.Purple.Purple400;
        }

        private void Purple_500_MouseEnter(object sender, EventArgs e)
        {
            Purple_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Purple_500_MouseLeave(object sender, EventArgs e)
        {
            Purple_500.BackColor = Colors.Purple.Purple500;
            zeroitLabel25.BackColor = Colors.Purple.Purple500;
            zeroitLabel26.BackColor = Colors.Purple.Purple500;
        }

        private void Purple_600_MouseEnter(object sender, EventArgs e)
        {
            Purple_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Purple_600_MouseLeave(object sender, EventArgs e)
        {
            Purple_600.BackColor = Colors.Purple.Purple600;
            zeroitLabel27.BackColor = Colors.Purple.Purple600;
            zeroitLabel28.BackColor = Colors.Purple.Purple600;
        }

        private void Purple_700_MouseEnter(object sender, EventArgs e)
        {
            Purple_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Purple_700_MouseLeave(object sender, EventArgs e)
        {
            Purple_700.BackColor = Colors.Purple.Purple700;
            zeroitLabel29.BackColor = Colors.Purple.Purple700;
            zeroitLabel30.BackColor = Colors.Purple.Purple700;
        }

        private void Purple_800_MouseEnter(object sender, EventArgs e)
        {
            Purple_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Purple_800_MouseLeave(object sender, EventArgs e)
        {
            Purple_800.BackColor = Colors.Purple.Purple800;
            zeroitLabel31.BackColor = Colors.Purple.Purple800;
            zeroitLabel32.BackColor = Colors.Purple.Purple800;
        }

        private void Purple_900_MouseEnter(object sender, EventArgs e)
        {
            Purple_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Purple_900_MouseLeave(object sender, EventArgs e)
        {
            Purple_900.BackColor = Colors.Purple.Purple900;
            zeroitLabel33.BackColor = Colors.Purple.Purple900;
            zeroitLabel34.BackColor = Colors.Purple.Purple900;
        }

        private void Purple_A100_MouseEnter(object sender, EventArgs e)
        {
            Purple_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Purple_A100_MouseLeave(object sender, EventArgs e)
        {
            Purple_A100.BackColor = Colors.Purple.PurpleA100;
            zeroitLabel35.BackColor = Colors.Purple.PurpleA100;
            zeroitLabel36.BackColor = Colors.Purple.PurpleA100;
        }

        private void Purple_A200_MouseEnter(object sender, EventArgs e)
        {
            Purple_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Purple_A200_MouseLeave(object sender, EventArgs e)
        {
            Purple_A200.BackColor = Colors.Purple.PurpleA200;
            zeroitLabel37.BackColor = Colors.Purple.PurpleA200;
            zeroitLabel38.BackColor = Colors.Purple.PurpleA200;
        }

        private void Purple_A400_MouseEnter(object sender, EventArgs e)
        {
            Purple_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Purple_A400_MouseLeave(object sender, EventArgs e)
        {
            Purple_A400.BackColor = Colors.Purple.PurpleA400;
            zeroitLabel39.BackColor = Colors.Purple.PurpleA400;
            zeroitLabel40.BackColor = Colors.Purple.PurpleA400;
        }

        private void Purple_A700_MouseEnter(object sender, EventArgs e)
        {
            Purple_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Purple_A700_MouseLeave(object sender, EventArgs e)
        {
            Purple_A700.BackColor = Colors.Purple.PurpleA700;
            zeroitLabel41.BackColor = Colors.Purple.PurpleA700;
            zeroitLabel42.BackColor = Colors.Purple.PurpleA700;
        }





        private void Purple_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.Purple50;
            control.BackColor = Colors.Purple.Purple50;
        }


        private void Purple_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.Purple100;
            control.BackColor = Colors.Purple.Purple100;
        }

        private void Purple_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.Purple200;
            control.BackColor = Colors.Purple.Purple200;
        }

        private void Purple_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.Purple300;
            control.BackColor = Colors.Purple.Purple300;
        }

        private void Purple_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.Purple400;
            control.BackColor = Colors.Purple.Purple400;
        }

        private void Purple_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.Purple500;
            control.BackColor = Colors.Purple.Purple500;
        }


        private void Purple_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.Purple600;
            control.BackColor = Colors.Purple.Purple600;
        }

        private void Purple_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.Purple700;
            control.BackColor = Colors.Purple.Purple700;
        }

        private void Purple_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.Purple800;
            control.BackColor = Colors.Purple.Purple800;
        }

        private void Purple_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.Purple900;
            control.BackColor = Colors.Purple.Purple900;
        }

        private void Purple_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.PurpleA100;
            control.BackColor = Colors.Purple.PurpleA100;
        }

        private void Purple_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.PurpleA200;
            control.BackColor = Colors.Purple.PurpleA200;
        }

        private void Purple_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.PurpleA400;
            control.BackColor = Colors.Purple.PurpleA400;
        }

        private void Purple_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Purple.PurpleA700;
            control.BackColor = Colors.Purple.PurpleA700;
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

        private void PurpleControl_Paint(object sender, PaintEventArgs e)
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
