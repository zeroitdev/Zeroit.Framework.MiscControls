// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-11-2018
// ***********************************************************************
// <copyright file="NaviLayoutStyle.cs" company="Zeroit Dev Technologies">
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
    /// Indicates how a control is presented to the user.
    /// </summary>
    public enum NaviLayoutStyle
   {
        /// <summary>
        /// Presents the control in the Blue Office 2003 colour and layout style
        /// </summary>
        Office2003Blue,

        /// <summary>
        /// Presents the control in the Green Office 2003 colour and layout style
        /// </summary>
        Office2003Green,

        /// <summary>
        /// Presents the control in the Silver Office 2003 colour and layout style
        /// </summary>
        Office2003Silver,

        /// <summary>
        /// Indicates that the control should be presented as the blue Ms Office 2007 Navigation pane
        /// </summary>
        Office2007Blue,

        /// <summary>
        /// Indicates that the control should be presented as the silver Ms Office 2007 Navigation pane
        /// </summary>
        Office2007Silver,

        /// <summary>
        /// Indicates that the control should be presented as the black Ms Office 2007 Navigation pane
        /// </summary>
        Office2007Black,
   }
}
