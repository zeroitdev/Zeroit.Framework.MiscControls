// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 03-06-2018
// ***********************************************************************
// <copyright file="DragCode.cs" company="Zeroit Dev Technologies">
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
#region Imports

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.MiscControls.Helper
{
    /// <summary>
    /// Class Drag.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public class Drag : System.Windows.Forms.Form
    {
        /// <summary>
        /// The bool 0
        /// </summary>
        private bool bool_0;

        /// <summary>
        /// The int 0
        /// </summary>
        private int int_0;

        /// <summary>
        /// The int 1
        /// </summary>
        private int int_1;

        /// <summary>
        /// The control 0
        /// </summary>
        private Control control_0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Drag"/> class.
        /// </summary>
        public Drag()
        {
        }

        /// <summary>
        /// Grabs the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        public void Grab(Control a)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            try
            {
                this.control_0 = a;
                this.bool_0 = true;
                Point mousePosition = Control.MousePosition;
                this.int_0 = mousePosition.X - this.control_0.Left;
                mousePosition = Control.MousePosition;
                this.int_1 = mousePosition.Y - this.control_0.Top;
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
        /// Moves the object.
        /// </summary>
        /// <param name="Horizontal">if set to <c>true</c> [horizontal].</param>
        /// <param name="Vertical">if set to <c>true</c> [vertical].</param>
        public void MoveObject(bool Horizontal = true, bool Vertical = true)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            try
            {
                if (this.bool_0)
                {
                    int x = Control.MousePosition.X;
                    int y = Control.MousePosition.Y;
                    if (Vertical)
                    {
                        this.control_0.Top = y - this.int_1;
                    }
                    if (Horizontal)
                    {
                        this.control_0.Left = x - this.int_0;
                    }
                }
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
        /// Releases this instance.
        /// </summary>
        public void Release()
        {
            this.bool_0 = false;
        }
    }
}
