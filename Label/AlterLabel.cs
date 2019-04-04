// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AlterLabel.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitLabelAlter    
    /// <summary>
    /// A class collection for rendering a Label.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Label" />
    public class ZeroitLabelAlter : Label
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLabelAlter" /> class.
        /// </summary>
        public ZeroitLabelAlter()
        {
            ForeColor = Color.FromArgb(100, 100, 100);
            BackColor = Color.Transparent;
            Font = new Font("Verdana", 8);
        }
    }
    #endregion
}
