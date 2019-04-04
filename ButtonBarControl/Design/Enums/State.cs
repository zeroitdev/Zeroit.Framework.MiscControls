// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="State.cs" company="Zeroit Dev Technologies">
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
    /// <summary>
    /// Enum representing State of Button
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Button is Selected
        /// </summary>
        Selected = 5,
        /// <summary>
        /// Button is Disabled
        /// </summary>
        Disabled = 4,
        /// <summary>
        /// Buton has mouse hover
        /// </summary>
        Hover = 2,
        /// <summary>
        /// Button is Selected and Mouse is over button
        /// </summary>
        SelectedHover = 6,
        /// <summary>
        /// Button is in normal State
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Button is pressed
        /// </summary>
        Pressed = 3
    }
}