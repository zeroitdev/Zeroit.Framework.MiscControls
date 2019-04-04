// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="OrangeDeepControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection representing Material Design color OrangeDeep dialog.
    /// </summary>
    public partial class DeepOrangeControl : System.Windows.Forms.Form
    {

        #region Constructor
        public DeepOrangeControl()
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
        private void DeepOrange_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //DeepOrange_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = DeepOrange_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void DeepOrange_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            DeepOrange_500_Header.BackColor = Colors.DeepOrange.DeepOrangeHeader500;
            zeroitLabel20.BackColor = Colors.DeepOrange.DeepOrangeHeader500;
            zeroitLabel21.BackColor = Colors.DeepOrange.DeepOrangeHeader500;
            swatchNameLabel.BackColor = Colors.DeepOrange.DeepOrangeHeader500;
        }

        private void DeepOrange_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrangeHeader500;
            control.BackColor = Colors.DeepOrange.DeepOrangeHeader500;

        }

        private void DeepOrange_500_Header_Click(object sender, EventArgs e)
        {
            DeepOrange_500_Header.BackColor = Colors.DeepOrange.DeepOrangeHeader500;
            zeroitLabel20.BackColor = Colors.DeepOrange.DeepOrangeHeader500;
            zeroitLabel21.BackColor = Colors.DeepOrange.DeepOrangeHeader500;
            swatchNameLabel.BackColor = Colors.DeepOrange.DeepOrangeHeader500;
        }

        private void DeepOrange_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            DeepOrange_500_Header.BackColor = Colors.DeepOrange.DeepOrangeHeader500;
            zeroitLabel20.BackColor = Colors.DeepOrange.DeepOrangeHeader500;
            zeroitLabel21.BackColor = Colors.DeepOrange.DeepOrangeHeader500;
            swatchNameLabel.BackColor = Colors.DeepOrange.DeepOrangeHeader500;
        }


        private void DeepOrange_50_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void DeepOrange_50_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_50.BackColor = Colors.DeepOrange.DeepOrange50;
            zeroitLabel18.BackColor = Colors.DeepOrange.DeepOrange50;
            zeroitLabel19.BackColor = Colors.DeepOrange.DeepOrange50;
        }



        private void DeepOrange_100_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepOrange_100_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_100.BackColor = Colors.DeepOrange.DeepOrange100;
            zeroitLabel16.BackColor = Colors.DeepOrange.DeepOrange100;
            zeroitLabel17.BackColor = Colors.DeepOrange.DeepOrange100;
        }

        private void DeepOrange_200_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepOrange_200_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_200.BackColor = Colors.DeepOrange.DeepOrange200;
            zeroitLabel14.BackColor = Colors.DeepOrange.DeepOrange200;
            zeroitLabel15.BackColor = Colors.DeepOrange.DeepOrange200;
        }

        private void DeepOrange_300_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepOrange_300_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_300.BackColor = Colors.DeepOrange.DeepOrange300;
            zeroitLabel13.BackColor = Colors.DeepOrange.DeepOrange300;
            zeroitLabel2.BackColor = Colors.DeepOrange.DeepOrange300;
        }

        private void DeepOrange_400_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepOrange_400_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_400.BackColor = Colors.DeepOrange.DeepOrange400;
            zeroitLabel23.BackColor = Colors.DeepOrange.DeepOrange400;
            zeroitLabel24.BackColor = Colors.DeepOrange.DeepOrange400;
        }

        private void DeepOrange_500_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepOrange_500_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_500.BackColor = Colors.DeepOrange.DeepOrange500;
            zeroitLabel25.BackColor = Colors.DeepOrange.DeepOrange500;
            zeroitLabel26.BackColor = Colors.DeepOrange.DeepOrange500;
        }

        private void DeepOrange_600_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepOrange_600_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_600.BackColor = Colors.DeepOrange.DeepOrange600;
            zeroitLabel27.BackColor = Colors.DeepOrange.DeepOrange600;
            zeroitLabel28.BackColor = Colors.DeepOrange.DeepOrange600;
        }

        private void DeepOrange_700_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepOrange_700_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_700.BackColor = Colors.DeepOrange.DeepOrange700;
            zeroitLabel29.BackColor = Colors.DeepOrange.DeepOrange700;
            zeroitLabel30.BackColor = Colors.DeepOrange.DeepOrange700;
        }

        private void DeepOrange_800_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepOrange_800_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_800.BackColor = Colors.DeepOrange.DeepOrange800;
            zeroitLabel31.BackColor = Colors.DeepOrange.DeepOrange800;
            zeroitLabel32.BackColor = Colors.DeepOrange.DeepOrange800;
        }

        private void DeepOrange_900_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepOrange_900_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_900.BackColor = Colors.DeepOrange.DeepOrange900;
            zeroitLabel33.BackColor = Colors.DeepOrange.DeepOrange900;
            zeroitLabel34.BackColor = Colors.DeepOrange.DeepOrange900;
        }

        private void DeepOrange_A100_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepOrange_A100_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_A100.BackColor = Colors.DeepOrange.DeepOrangeA100;
            zeroitLabel35.BackColor = Colors.DeepOrange.DeepOrangeA100;
            zeroitLabel36.BackColor = Colors.DeepOrange.DeepOrangeA100;
        }

        private void DeepOrange_A200_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepOrange_A200_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_A200.BackColor = Colors.DeepOrange.DeepOrangeA200;
            zeroitLabel37.BackColor = Colors.DeepOrange.DeepOrangeA200;
            zeroitLabel38.BackColor = Colors.DeepOrange.DeepOrangeA200;
        }

        private void DeepOrange_A400_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepOrange_A400_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_A400.BackColor = Colors.DeepOrange.DeepOrangeA400;
            zeroitLabel39.BackColor = Colors.DeepOrange.DeepOrangeA400;
            zeroitLabel40.BackColor = Colors.DeepOrange.DeepOrangeA400;
        }

        private void DeepOrange_A700_MouseEnter(object sender, EventArgs e)
        {
            DeepOrange_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void DeepOrange_A700_MouseLeave(object sender, EventArgs e)
        {
            DeepOrange_A700.BackColor = Colors.DeepOrange.DeepOrangeA700;
            zeroitLabel41.BackColor = Colors.DeepOrange.DeepOrangeA700;
            zeroitLabel42.BackColor = Colors.DeepOrange.DeepOrangeA700;
        }





        private void DeepOrange_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrange50;
            control.BackColor = Colors.DeepOrange.DeepOrange50;
        }


        private void DeepOrange_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrange100;
            control.BackColor = Colors.DeepOrange.DeepOrange100;
        }

        private void DeepOrange_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrange200;
            control.BackColor = Colors.DeepOrange.DeepOrange200;
        }

        private void DeepOrange_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrange300;
            control.BackColor = Colors.DeepOrange.DeepOrange300;
        }

        private void DeepOrange_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrange400;
            control.BackColor = Colors.DeepOrange.DeepOrange400;
        }

        private void DeepOrange_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrange500;
            control.BackColor = Colors.DeepOrange.DeepOrange500;
        }


        private void DeepOrange_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrange600;
            control.BackColor = Colors.DeepOrange.DeepOrange600;
        }

        private void DeepOrange_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrange700;
            control.BackColor = Colors.DeepOrange.DeepOrange700;
        }

        private void DeepOrange_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrange800;
            control.BackColor = Colors.DeepOrange.DeepOrange800;
        }

        private void DeepOrange_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrange900;
            control.BackColor = Colors.DeepOrange.DeepOrange900;
        }

        private void DeepOrange_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrangeA100;
            control.BackColor = Colors.DeepOrange.DeepOrangeA100;
        }

        private void DeepOrange_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrangeA200;
            control.BackColor = Colors.DeepOrange.DeepOrangeA200;
        }

        private void DeepOrange_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrangeA400;
            control.BackColor = Colors.DeepOrange.DeepOrangeA400;
        }

        private void DeepOrange_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.DeepOrange.DeepOrangeA700;
            control.BackColor = Colors.DeepOrange.DeepOrangeA700;
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

        private void DeepOrangeControl_Paint(object sender, PaintEventArgs e)
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
