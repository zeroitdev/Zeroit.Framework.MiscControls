// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="IndigoControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection representing Material Design color Indigo dialog.
    /// </summary>
    public partial class IndigoControl : System.Windows.Forms.Form
    {
        #region Constructor
        public IndigoControl()
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
        private void Indigo_500_Header_MouseEnter(object sender, EventArgs e)
        {
            //Indigo_500_Header.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel20.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel21.BackColor = Color.FromArgb(0, 122, 204);
            swatchNameLabel.BackColor = Color.FromArgb(0, 122, 204);

            zeroitLabel20.Visible = false;
            zeroitLabel21.Visible = false;
            swatchNameLabel.Visible = false;

            zeroitObjectAnimator1.Control = Indigo_500_Header;
            zeroitObjectAnimator1.Start();

        }

        private void Indigo_500_Header_MouseLeave(object sender, EventArgs e)
        {
            zeroitLabel20.Visible = true;
            zeroitLabel21.Visible = true;
            swatchNameLabel.Visible = true;

            Indigo_500_Header.BackColor = Colors.Indigo.IndigoHeader500;
            zeroitLabel20.BackColor = Colors.Indigo.IndigoHeader500;
            zeroitLabel21.BackColor = Colors.Indigo.IndigoHeader500;
            swatchNameLabel.BackColor = Colors.Indigo.IndigoHeader500;
        }

        private void Indigo_500_Header_Click_1(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.IndigoHeader500;
            control.BackColor = Colors.Indigo.IndigoHeader500;

        }

        private void Indigo_500_Header_Click(object sender, EventArgs e)
        {
            Indigo_500_Header.BackColor = Colors.Indigo.IndigoHeader500;
            zeroitLabel20.BackColor = Colors.Indigo.IndigoHeader500;
            zeroitLabel21.BackColor = Colors.Indigo.IndigoHeader500;
            swatchNameLabel.BackColor = Colors.Indigo.IndigoHeader500;
        }

        private void Indigo_500_Header_MouseClick(object sender, MouseEventArgs e)
        {
            Indigo_500_Header.BackColor = Colors.Indigo.IndigoHeader500;
            zeroitLabel20.BackColor = Colors.Indigo.IndigoHeader500;
            zeroitLabel21.BackColor = Colors.Indigo.IndigoHeader500;
            swatchNameLabel.BackColor = Colors.Indigo.IndigoHeader500;
        }


        private void Indigo_50_MouseEnter(object sender, EventArgs e)
        {
            Indigo_50.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel18.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel19.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void Indigo_50_MouseLeave(object sender, EventArgs e)
        {
            Indigo_50.BackColor = Colors.Indigo.Indigo50;
            zeroitLabel18.BackColor = Colors.Indigo.Indigo50;
            zeroitLabel19.BackColor = Colors.Indigo.Indigo50;
        }



        private void Indigo_100_MouseEnter(object sender, EventArgs e)
        {
            Indigo_100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel16.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel17.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Indigo_100_MouseLeave(object sender, EventArgs e)
        {
            Indigo_100.BackColor = Colors.Indigo.Indigo100;
            zeroitLabel16.BackColor = Colors.Indigo.Indigo100;
            zeroitLabel17.BackColor = Colors.Indigo.Indigo100;
        }

        private void Indigo_200_MouseEnter(object sender, EventArgs e)
        {
            Indigo_200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel14.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel15.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Indigo_200_MouseLeave(object sender, EventArgs e)
        {
            Indigo_200.BackColor = Colors.Indigo.Indigo200;
            zeroitLabel14.BackColor = Colors.Indigo.Indigo200;
            zeroitLabel15.BackColor = Colors.Indigo.Indigo200;
        }

        private void Indigo_300_MouseEnter(object sender, EventArgs e)
        {
            Indigo_300.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel13.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel2.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Indigo_300_MouseLeave(object sender, EventArgs e)
        {
            Indigo_300.BackColor = Colors.Indigo.Indigo300;
            zeroitLabel13.BackColor = Colors.Indigo.Indigo300;
            zeroitLabel2.BackColor = Colors.Indigo.Indigo300;
        }

        private void Indigo_400_MouseEnter(object sender, EventArgs e)
        {
            Indigo_400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel23.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel24.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Indigo_400_MouseLeave(object sender, EventArgs e)
        {
            Indigo_400.BackColor = Colors.Indigo.Indigo400;
            zeroitLabel23.BackColor = Colors.Indigo.Indigo400;
            zeroitLabel24.BackColor = Colors.Indigo.Indigo400;
        }

        private void Indigo_500_MouseEnter(object sender, EventArgs e)
        {
            Indigo_500.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel25.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel26.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Indigo_500_MouseLeave(object sender, EventArgs e)
        {
            Indigo_500.BackColor = Colors.Indigo.Indigo500;
            zeroitLabel25.BackColor = Colors.Indigo.Indigo500;
            zeroitLabel26.BackColor = Colors.Indigo.Indigo500;
        }

        private void Indigo_600_MouseEnter(object sender, EventArgs e)
        {
            Indigo_600.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel27.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel28.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Indigo_600_MouseLeave(object sender, EventArgs e)
        {
            Indigo_600.BackColor = Colors.Indigo.Indigo600;
            zeroitLabel27.BackColor = Colors.Indigo.Indigo600;
            zeroitLabel28.BackColor = Colors.Indigo.Indigo600;
        }

        private void Indigo_700_MouseEnter(object sender, EventArgs e)
        {
            Indigo_700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel29.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel30.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Indigo_700_MouseLeave(object sender, EventArgs e)
        {
            Indigo_700.BackColor = Colors.Indigo.Indigo700;
            zeroitLabel29.BackColor = Colors.Indigo.Indigo700;
            zeroitLabel30.BackColor = Colors.Indigo.Indigo700;
        }

        private void Indigo_800_MouseEnter(object sender, EventArgs e)
        {
            Indigo_800.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel31.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel32.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Indigo_800_MouseLeave(object sender, EventArgs e)
        {
            Indigo_800.BackColor = Colors.Indigo.Indigo800;
            zeroitLabel31.BackColor = Colors.Indigo.Indigo800;
            zeroitLabel32.BackColor = Colors.Indigo.Indigo800;
        }

        private void Indigo_900_MouseEnter(object sender, EventArgs e)
        {
            Indigo_900.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel33.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel34.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Indigo_900_MouseLeave(object sender, EventArgs e)
        {
            Indigo_900.BackColor = Colors.Indigo.Indigo900;
            zeroitLabel33.BackColor = Colors.Indigo.Indigo900;
            zeroitLabel34.BackColor = Colors.Indigo.Indigo900;
        }

        private void Indigo_A100_MouseEnter(object sender, EventArgs e)
        {
            Indigo_A100.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel35.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel36.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Indigo_A100_MouseLeave(object sender, EventArgs e)
        {
            Indigo_A100.BackColor = Colors.Indigo.IndigoA100;
            zeroitLabel35.BackColor = Colors.Indigo.IndigoA100;
            zeroitLabel36.BackColor = Colors.Indigo.IndigoA100;
        }

        private void Indigo_A200_MouseEnter(object sender, EventArgs e)
        {
            Indigo_A200.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel37.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel38.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Indigo_A200_MouseLeave(object sender, EventArgs e)
        {
            Indigo_A200.BackColor = Colors.Indigo.IndigoA200;
            zeroitLabel37.BackColor = Colors.Indigo.IndigoA200;
            zeroitLabel38.BackColor = Colors.Indigo.IndigoA200;
        }

        private void Indigo_A400_MouseEnter(object sender, EventArgs e)
        {
            Indigo_A400.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel39.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel40.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Indigo_A400_MouseLeave(object sender, EventArgs e)
        {
            Indigo_A400.BackColor = Colors.Indigo.IndigoA400;
            zeroitLabel39.BackColor = Colors.Indigo.IndigoA400;
            zeroitLabel40.BackColor = Colors.Indigo.IndigoA400;
        }

        private void Indigo_A700_MouseEnter(object sender, EventArgs e)
        {
            Indigo_A700.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel41.BackColor = Color.FromArgb(0, 122, 204);
            zeroitLabel42.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void Indigo_A700_MouseLeave(object sender, EventArgs e)
        {
            Indigo_A700.BackColor = Colors.Indigo.IndigoA700;
            zeroitLabel41.BackColor = Colors.Indigo.IndigoA700;
            zeroitLabel42.BackColor = Colors.Indigo.IndigoA700;
        }





        private void Indigo_50_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.Indigo50;
            control.BackColor = Colors.Indigo.Indigo50;
        }


        private void Indigo_100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.Indigo100;
            control.BackColor = Colors.Indigo.Indigo100;
        }

        private void Indigo_200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.Indigo200;
            control.BackColor = Colors.Indigo.Indigo200;
        }

        private void Indigo_300_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.Indigo300;
            control.BackColor = Colors.Indigo.Indigo300;
        }

        private void Indigo_400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.Indigo400;
            control.BackColor = Colors.Indigo.Indigo400;
        }

        private void Indigo_500_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.Indigo500;
            control.BackColor = Colors.Indigo.Indigo500;
        }


        private void Indigo_600_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.Indigo600;
            control.BackColor = Colors.Indigo.Indigo600;
        }

        private void Indigo_700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.Indigo700;
            control.BackColor = Colors.Indigo.Indigo700;
        }

        private void Indigo_800_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.Indigo800;
            control.BackColor = Colors.Indigo.Indigo800;
        }

        private void Indigo_900_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.Indigo900;
            control.BackColor = Colors.Indigo.Indigo900;
        }

        private void Indigo_A100_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.IndigoA100;
            control.BackColor = Colors.Indigo.IndigoA100;
        }

        private void Indigo_A200_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.IndigoA200;
            control.BackColor = Colors.Indigo.IndigoA200;
        }

        private void Indigo_A400_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.IndigoA400;
            control.BackColor = Colors.Indigo.IndigoA400;
        }

        private void Indigo_A700_Click(object sender, EventArgs e)
        {
            selectedColor.BackColor = Colors.Indigo.IndigoA700;
            control.BackColor = Colors.Indigo.IndigoA700;
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

        private void IndigoControl_Paint(object sender, PaintEventArgs e)
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
