// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PasswordHoverGenerator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Zeroit Password Hover Generator

    /// <summary>
    /// A class collection for rendering a password generator when the mouse button is hovered on it.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Label" />
    [ToolboxItem(true)]
    public class ZeroitPasswordHoverGenerator : Label
    {
        /// <summary>
        /// The generate pass
        /// </summary>
        private bool generatePass = false;

        /// <summary>
        /// Generates the password.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GeneratePWD()
        {
            int passwordLength = 10;
            int quantity = 1;
            ArrayList arrCharPool = new ArrayList();
            Random rndNum = new Random();
            arrCharPool.Clear();
            string password = "";


            //Lower Case 
            for (int i = 97; i < 123; i++)
            {
                arrCharPool.Add(Convert.ToChar(i).ToString());
            }
            //Number
            for (int i = 48; i < 58; i++)
            {
                arrCharPool.Add(Convert.ToChar(i).ToString());
            }

            //Upper Case 
            for (int i = 65; i < 91; i++)
            {
                arrCharPool.Add(Convert.ToChar(i).ToString());
            }



            for (int x = 0; x < quantity; x++)
            {
                //Iterate through the number of characters required in the password
                for (int i = 0; i < passwordLength; i++)
                {
                    password += arrCharPool[rndNum.Next(arrCharPool.Count)].ToString();
                }
            }

            return password;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPasswordHoverGenerator" /> class.
        /// </summary>
        public ZeroitPasswordHoverGenerator()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            generatePass = true;

            if (generatePass)
            {
                string generate = GeneratePWD();

                this.Text = "";

                this.Text = generate;

            }

            Invalidate();


        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            generatePass = false;
        }

    }

    #endregion
}
