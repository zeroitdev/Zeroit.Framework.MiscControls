// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="EventArgs.cs" company="Zeroit Dev Technologies">
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
    /// Class SelectingEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class SelectingEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <value>The item.</value>
        public AutocompleteItem Item { get; internal set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SelectingEventArgs"/> is cancel.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c>.</value>
        public bool Cancel { get; set; }
        /// <summary>
        /// Gets or sets the index of the selected.
        /// </summary>
        /// <value>The index of the selected.</value>
        public int SelectedIndex { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SelectingEventArgs"/> is handled.
        /// </summary>
        /// <value><c>true</c> if handled; otherwise, <c>false</c>.</value>
        public bool Handled { get; set; }
    }

    /// <summary>
    /// Class SelectedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class SelectedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <value>The item.</value>
        public AutocompleteItem Item { get; internal set; }
        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>The control.</value>
        public Control Control { get; set; }
    }

    /// <summary>
    /// Class HoveredEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class HoveredEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <value>The item.</value>
        public AutocompleteItem Item { get; internal set; }
    }


    /// <summary>
    /// Class PaintItemEventArgs.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.PaintEventArgs" />
    public class PaintItemEventArgs : PaintEventArgs
    {
        /// <summary>
        /// Gets the text rect.
        /// </summary>
        /// <value>The text rect.</value>
        public RectangleF TextRect { get; internal set; }
        /// <summary>
        /// Gets the string format.
        /// </summary>
        /// <value>The string format.</value>
        public StringFormat StringFormat { get; internal set; }
        /// <summary>
        /// Gets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font { get; internal set; }
        /// <summary>
        /// Gets a value indicating whether this instance is selected.
        /// </summary>
        /// <value><c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
        public bool IsSelected { get; internal set; }
        /// <summary>
        /// Gets a value indicating whether this instance is hovered.
        /// </summary>
        /// <value><c>true</c> if this instance is hovered; otherwise, <c>false</c>.</value>
        public bool IsHovered { get; internal set; }
        /// <summary>
        /// Gets the colors.
        /// </summary>
        /// <value>The colors.</value>
        public Colors Colors { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaintItemEventArgs"/> class.
        /// </summary>
        /// <param name="graphics">The <see cref="T:System.Drawing.Graphics" /> used to paint the item.</param>
        /// <param name="clipRect">The <see cref="T:System.Drawing.Rectangle" /> that represents the rectangle in which to paint.</param>
        public PaintItemEventArgs(Graphics graphics, Rectangle clipRect):base(graphics, clipRect)
        {
        }
    }

    /// <summary>
    /// Class WrapperNeededEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class WrapperNeededEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the target control.
        /// </summary>
        /// <value>The target control.</value>
        public Control TargetControl { get; private set; }
        /// <summary>
        /// Gets or sets the wrapper.
        /// </summary>
        /// <value>The wrapper.</value>
        public ITextBoxWrapper Wrapper { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WrapperNeededEventArgs"/> class.
        /// </summary>
        /// <param name="targetControl">The target control.</param>
        public WrapperNeededEventArgs(Control targetControl)
        {
            this.TargetControl = targetControl;
        }
    }
}
