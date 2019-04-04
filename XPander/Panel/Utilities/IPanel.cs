// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="IPanel.cs" company="Zeroit Dev Technologies">
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
    #region IPanel
    /// <summary>
    /// Used to group collections of controls.
    /// </summary>
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER
    /// REMAINS UNCHANGED.
    /// </copyright>
    public interface IPanel
    {
        /// <summary>
        /// Gets or sets the style of the panel.
        /// </summary>
        /// <value>The panel style.</value>
        PanelStyle PanelStyle { get; set; }
        /// <summary>
        /// Gets or sets the color schema which is used for the panel.
        /// </summary>
        /// <value>The zeroit pro color scheme.</value>
        ZeroitProColorScheme ZeroitProColorScheme { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the control shows a border
        /// </summary>
        /// <value><c>true</c> if [show border]; otherwise, <c>false</c>.</value>
        bool ShowBorder { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the expand icon in the caption bar is visible.
        /// </summary>
        /// <value><c>true</c> if [show expand icon]; otherwise, <c>false</c>.</value>
        bool ShowExpandIcon { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the close icon in the caption bar is visible.
        /// </summary>
        /// <value><c>true</c> if [show close icon]; otherwise, <c>false</c>.</value>
        bool ShowCloseIcon { get; set; }
        /// <summary>
        /// Expands the panel or xpanderpanel.
        /// </summary>
        /// <value><c>true</c> if expand; otherwise, <c>false</c>.</value>
        bool Expand { get; set; }
    }
    #endregion
}
