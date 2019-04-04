// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 02-20-2018
// ***********************************************************************
// <copyright file="Elipse.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Zeroit.Framework.MiscControls.Helper
{
    /// <summary>
    /// Class Ellipse.
    /// </summary>
    [DebuggerStepThrough]
    public static class Ellipse
    {
        /// <summary>
        /// Applies the specified form.
        /// </summary>
        /// <param name="Form">The form.</param>
        /// <param name="_Elipse">The elipse.</param>
        public static void Apply(System.Windows.Forms.Form Form, int _Elipse)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            try
            {
                Form.FormBorderStyle = FormBorderStyle.None;
                Form.Region = Region.FromHrgn(Ellipse.CreateRoundRectRgn(0, 0, Form.Width, Form.Height, _Elipse, _Elipse));
            }
            catch (Exception exception)
            {
            }
            do
            {
                if (num != num1)
                {
                    break;
                }
                num1 = 1;
                num2 = num;
                num = 1;
            }
            while (1 <= num2);
        }

        /// <summary>
        /// Applies the specified control.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        /// <param name="Elipse">The elipse.</param>
        public static void Apply(Control ctrl, int Elipse)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            try
            {
                ctrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ctrl.Width, ctrl.Height, Elipse, Elipse));
            }
            catch (Exception exception)
            {
            }
            do
            {
                if (num != num1)
                {
                    break;
                }
                num1 = 1;
                num2 = num;
                num = 1;
            }
            while (1 <= num2);
        }

        /// <summary>
        /// Creates the round rect RGN.
        /// </summary>
        /// <param name="nLeftRect">The n left rect.</param>
        /// <param name="nTopRect">The n top rect.</param>
        /// <param name="nRightRect">The n right rect.</param>
        /// <param name="nBottomRect">The n bottom rect.</param>
        /// <param name="nWidthEllipse">The n width ellipse.</param>
        /// <param name="nHeightEllipse">The n height ellipse.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("Gdi32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}
