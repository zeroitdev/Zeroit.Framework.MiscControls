// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="GreenLightControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection representing Material Design color GreenLight dialog.
    /// </summary>
    public partial class LightGreenControl : System.Windows.Forms.Form
    {

        #region Constructor
        public LightGreenControl()
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
        private void LightGreen_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //LightGreen_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = LightGreen_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void LightGreen_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            LightGreen_500_Header.BackColor = Colors.LightGreen.LightgreenHeader500;
            zeroitLabel20.BackColor = Colors.LightGreen.LightgreenHeader500;
            zeroitLabel21.BackColor = Colors.LightGreen.LightgreenHeader500;
            swatchNameLabel.BackColor = Colors.LightGreen.LightgreenHeader500;
        }

        private void LightGreen_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.LightgreenHeader500;
            control.BackColor = Colors.LightGreen.LightgreenHeader500;

        }

        private void LightGreen_500_Header_Click(object sender, EventArgs e)
        {
            LightGreen_500_Header.BackColor = Colors.LightGreen.LightgreenHeader500;
            zeroitLabel20.BackColor = Colors.LightGreen.LightgreenHeader500;
            zeroitLabel21.BackColor = Colors.LightGreen.LightgreenHeader500;
            swatchNameLabel.BackColor = Colors.LightGreen.LightgreenHeader500;
        }

        private void LightGreen_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            LightGreen_500_Header.BackColor = Colors.LightGreen.LightgreenHeader500;
            zeroitLabel20.BackColor = Colors.LightGreen.LightgreenHeader500;
            zeroitLabel21.BackColor = Colors.LightGreen.LightgreenHeader500;
            swatchNameLabel.BackColor = Colors.LightGreen.LightgreenHeader500;
        }


        private void LightGreen_50_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void LightGreen_50_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_50.BackColor = Colors.LightGreen.Lightgreen50;
            zeroitLabel18.BackColor = Colors.LightGreen.Lightgreen50;
            zeroitLabel19.BackColor = Colors.LightGreen.Lightgreen50;
        }



        private void LightGreen_100_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightGreen_100_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_100.BackColor = Colors.LightGreen.Lightgreen100;
            zeroitLabel16.BackColor = Colors.LightGreen.Lightgreen100;
            zeroitLabel17.BackColor = Colors.LightGreen.Lightgreen100;
        }

        private void LightGreen_200_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightGreen_200_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_200.BackColor = Colors.LightGreen.Lightgreen200;
            zeroitLabel14.BackColor = Colors.LightGreen.Lightgreen200;
            zeroitLabel15.BackColor = Colors.LightGreen.Lightgreen200;
        }

        private void LightGreen_300_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightGreen_300_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_300.BackColor = Colors.LightGreen.Lightgreen300;
            zeroitLabel13.BackColor = Colors.LightGreen.Lightgreen300;
            zeroitLabel2.BackColor = Colors.LightGreen.Lightgreen300;
        }

        private void LightGreen_400_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightGreen_400_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_400.BackColor = Colors.LightGreen.Lightgreen400;
            zeroitLabel23.BackColor = Colors.LightGreen.Lightgreen400;
            zeroitLabel24.BackColor = Colors.LightGreen.Lightgreen400;
        }

        private void LightGreen_500_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightGreen_500_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_500.BackColor = Colors.LightGreen.Lightgreen500;
            zeroitLabel25.BackColor = Colors.LightGreen.Lightgreen500;
            zeroitLabel26.BackColor = Colors.LightGreen.Lightgreen500;
        }

        private void LightGreen_600_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightGreen_600_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_600.BackColor = Colors.LightGreen.Lightgreen600;
            zeroitLabel27.BackColor = Colors.LightGreen.Lightgreen600;
            zeroitLabel28.BackColor = Colors.LightGreen.Lightgreen600;
        }

        private void LightGreen_700_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightGreen_700_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_700.BackColor = Colors.LightGreen.Lightgreen700;
            zeroitLabel29.BackColor = Colors.LightGreen.Lightgreen700;
            zeroitLabel30.BackColor = Colors.LightGreen.Lightgreen700;
        }

        private void LightGreen_800_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightGreen_800_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_800.BackColor = Colors.LightGreen.Lightgreen800;
            zeroitLabel31.BackColor = Colors.LightGreen.Lightgreen800;
            zeroitLabel32.BackColor = Colors.LightGreen.Lightgreen800;
        }

        private void LightGreen_900_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightGreen_900_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_900.BackColor = Colors.LightGreen.Lightgreen900;
            zeroitLabel33.BackColor = Colors.LightGreen.Lightgreen900;
            zeroitLabel34.BackColor = Colors.LightGreen.Lightgreen900;
        }

        private void LightGreen_A100_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightGreen_A100_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_A100.BackColor = Colors.LightGreen.LightgreenA100;
            zeroitLabel35.BackColor = Colors.LightGreen.LightgreenA100;
            zeroitLabel36.BackColor = Colors.LightGreen.LightgreenA100;
        }

        private void LightGreen_A200_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightGreen_A200_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_A200.BackColor = Colors.LightGreen.LightgreenA200;
            zeroitLabel37.BackColor = Colors.LightGreen.LightgreenA200;
            zeroitLabel38.BackColor = Colors.LightGreen.LightgreenA200;
        }

        private void LightGreen_A400_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightGreen_A400_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_A400.BackColor = Colors.LightGreen.LightgreenA400;
            zeroitLabel39.BackColor = Colors.LightGreen.LightgreenA400;
            zeroitLabel40.BackColor = Colors.LightGreen.LightgreenA400;
        }

        private void LightGreen_A700_MouseEnter(object sender, EventArgs e)
        {
            LightGreen_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void LightGreen_A700_MouseLeave(object sender, EventArgs e)
        {
            LightGreen_A700.BackColor = Colors.LightGreen.LightgreenA700;
            zeroitLabel41.BackColor = Colors.LightGreen.LightgreenA700;
            zeroitLabel42.BackColor = Colors.LightGreen.LightgreenA700;
        }





        private void LightGreen_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.Lightgreen50;
            control.BackColor = Colors.LightGreen.Lightgreen50;
        }


        private void LightGreen_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.Lightgreen100;
            control.BackColor = Colors.LightGreen.Lightgreen100;
        }

        private void LightGreen_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.Lightgreen200;
            control.BackColor = Colors.LightGreen.Lightgreen200;
        }

        private void LightGreen_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.Lightgreen300;
            control.BackColor = Colors.LightGreen.Lightgreen300;
        }

        private void LightGreen_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.Lightgreen400;
            control.BackColor = Colors.LightGreen.Lightgreen400;
        }

        private void LightGreen_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.Lightgreen500;
            control.BackColor = Colors.LightGreen.Lightgreen500;
        }


        private void LightGreen_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.Lightgreen600;
            control.BackColor = Colors.LightGreen.Lightgreen600;
        }

        private void LightGreen_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.Lightgreen700;
            control.BackColor = Colors.LightGreen.Lightgreen700;
        }

        private void LightGreen_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.Lightgreen800;
            control.BackColor = Colors.LightGreen.Lightgreen800;
        }

        private void LightGreen_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.Lightgreen900;
            control.BackColor = Colors.LightGreen.Lightgreen900;
        }

        private void LightGreen_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.LightgreenA100;
            control.BackColor = Colors.LightGreen.LightgreenA100;
        }

        private void LightGreen_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.LightgreenA200;
            control.BackColor = Colors.LightGreen.LightgreenA200;
        }

        private void LightGreen_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.LightgreenA400;
            control.BackColor = Colors.LightGreen.LightgreenA400;
        }

        private void LightGreen_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.LightGreen.LightgreenA700;
            control.BackColor = Colors.LightGreen.LightgreenA700;
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

        private void LightGreenControl_Paint(object sender, PaintEventArgs e)
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
