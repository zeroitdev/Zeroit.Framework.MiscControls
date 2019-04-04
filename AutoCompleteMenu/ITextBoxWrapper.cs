// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ITextBoxWrapper.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Wrapper over the control like TextBox.
    /// </summary>
    public interface ITextBoxWrapper
    {
        /// <summary>
        /// Gets the target control.
        /// </summary>
        /// <value>The target control.</value>
        Control TargetControl { get; }
        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        string Text { get; }
        /// <summary>
        /// Gets or sets the selected text.
        /// </summary>
        /// <value>The selected text.</value>
        string SelectedText { get; set; }
        /// <summary>
        /// Gets or sets the length of the selection.
        /// </summary>
        /// <value>The length of the selection.</value>
        int SelectionLength { get; set; }
        /// <summary>
        /// Gets or sets the selection start.
        /// </summary>
        /// <value>The selection start.</value>
        int SelectionStart { get; set; }
        /// <summary>
        /// Gets the index of the position from character.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns>Point.</returns>
        Point GetPositionFromCharIndex(int pos);
        /// <summary>
        /// Gets a value indicating whether this <see cref="ITextBoxWrapper"/> is readonly.
        /// </summary>
        /// <value><c>true</c> if readonly; otherwise, <c>false</c>.</value>
        bool Readonly { get; }
        /// <summary>
        /// Occurs when [lost focus].
        /// </summary>
        event EventHandler LostFocus;
        /// <summary>
        /// Occurs when [scroll].
        /// </summary>
        event ScrollEventHandler Scroll;
        /// <summary>
        /// Occurs when [key down].
        /// </summary>
        event KeyEventHandler KeyDown;
        /// <summary>
        /// Occurs when [mouse down].
        /// </summary>
        event MouseEventHandler MouseDown;
    }
}
