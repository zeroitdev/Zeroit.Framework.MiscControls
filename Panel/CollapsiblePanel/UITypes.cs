// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="UITypes.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.MiscControls
{
    #region UITypes
    /// <summary>
    /// Enumeration used for various panel types to describe how the
    /// background should be painted (or not painted)
    /// </summary>
    public enum BackgroundStyle
    {
        /// <summary>
        /// No background will be drawn
        /// </summary>
        Transparent,
        /// <summary>
        /// Background will be drawn using <see cref="System.Windows.Forms.Control.BackColor" />
        /// </summary>
        Solid,
        /// <summary>
        /// Background will be drawn using a gradient defined by the control
        /// </summary>
        Gradient
    }
    #endregion
}
