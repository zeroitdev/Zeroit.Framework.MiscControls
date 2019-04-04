// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-12-2018
// ***********************************************************************
// <copyright file="Enums.cs" company="Zeroit Dev Technologies">
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
    /// Hit test result of <see cref="FATabStrip" />
    /// </summary>
    public enum HitTestResult
    {
        /// <summary>
        /// The close button
        /// </summary>
        CloseButton,
        /// <summary>
        /// The menu glyph
        /// </summary>
        MenuGlyph,
        /// <summary>
        /// The tab item
        /// </summary>
        TabItem,
        /// <summary>
        /// The none
        /// </summary>
        None
    }

    /// <summary>
    /// Theme Type
    /// </summary>
    public enum ThemeTypes
    {
        /// <summary>
        /// The windows xp
        /// </summary>
        WindowsXP,
        /// <summary>
        /// The office2000
        /// </summary>
        Office2000,
        /// <summary>
        /// The office2003
        /// </summary>
        Office2003
    }

    /// <summary>
    /// Indicates a change into TabStrip collection
    /// </summary>
    public enum FATabStripItemChangeTypes
    {
        /// <summary>
        /// The added
        /// </summary>
        Added,
        /// <summary>
        /// The removed
        /// </summary>
        Removed,
        /// <summary>
        /// The changed
        /// </summary>
        Changed,
        /// <summary>
        /// The selection changed
        /// </summary>
        SelectionChanged
    }
}
