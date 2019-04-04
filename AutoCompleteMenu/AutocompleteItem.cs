// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AutocompleteItem.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Item of autocomplete menu
    /// </summary>
    public class AutocompleteItem
    {
        /// <summary>
        /// The tag
        /// </summary>
        public object Tag;
        /// <summary>
        /// The tool tip title
        /// </summary>
        string toolTipTitle;
        /// <summary>
        /// The tool tip text
        /// </summary>
        string toolTipText;
        /// <summary>
        /// The menu text
        /// </summary>
        string menuText;

        /// <summary>
        /// Parent ZeroitAutocompleteMenu
        /// </summary>
        /// <value>The parent.</value>
        public ZeroitAutocompleteMenu Parent { get; internal set; }

        /// <summary>
        /// Text for inserting into textbox
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        /// Image index for this item
        /// </summary>
        /// <value>The index of the image.</value>
        public int ImageIndex{get; set; }

        /// <summary>
        /// Title for tooltip.
        /// </summary>
        /// <value>The tool tip title.</value>
        /// <remarks>Return null for disable tooltip for this item</remarks>
        public virtual string ToolTipTitle
        {
            get { return toolTipTitle; }
            set { toolTipTitle = value; }
        }

        /// <summary>
        /// Tooltip text.
        /// </summary>
        /// <value>The tool tip text.</value>
        /// <remarks>For display tooltip text, ToolTipTitle must be not null</remarks>
        public virtual string ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText = value; }
        }

        /// <summary>
        /// Menu text. This text is displayed in the drop-down menu.
        /// </summary>
        /// <value>The menu text.</value>
        public virtual string MenuText
        {
            get { return menuText; }
            set { menuText = value; }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteItem"/> class.
        /// </summary>
        public AutocompleteItem()
        {
            ImageIndex = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteItem"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public AutocompleteItem(string text):this()
        {
            Text = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteItem"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="imageIndex">Index of the image.</param>
        public AutocompleteItem(string text, int imageIndex)
            : this(text)
        {
            this.ImageIndex = imageIndex;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteItem"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="imageIndex">Index of the image.</param>
        /// <param name="menuText">The menu text.</param>
        public AutocompleteItem(string text, int imageIndex, string menuText)
            : this(text, imageIndex)
        {
            this.menuText = menuText;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteItem"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="imageIndex">Index of the image.</param>
        /// <param name="menuText">The menu text.</param>
        /// <param name="toolTipTitle">The tool tip title.</param>
        /// <param name="toolTipText">The tool tip text.</param>
        public AutocompleteItem(string text, int imageIndex, string menuText, string toolTipTitle, string toolTipText)
            : this(text, imageIndex, menuText)
        {
            this.toolTipTitle = toolTipTitle;
            this.toolTipText = toolTipText;
        }

        /// <summary>
        /// Returns text for inserting into Textbox
        /// </summary>
        /// <returns>System.String.</returns>
        public virtual string GetTextForReplace()
        {
            return Text;
        }

        /// <summary>
        /// Compares fragment text with this item
        /// </summary>
        /// <param name="fragmentText">The fragment text.</param>
        /// <returns>CompareResult.</returns>
        public virtual CompareResult Compare(string fragmentText)
        {
            if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) &&
                   Text != fragmentText)
                return CompareResult.VisibleAndSelected;

            return CompareResult.Hidden;
        }

        /// <summary>
        /// Returns text for display into popup menu
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return menuText ?? Text;
        }

        /// <summary>
        /// This method is called after item was inserted into text
        /// </summary>
        /// <param name="e">The <see cref="SelectedEventArgs"/> instance containing the event data.</param>
        public virtual void OnSelected(SelectedEventArgs e)
        {
        }

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintItemEventArgs"/> instance containing the event data.</param>
        public virtual void OnPaint(PaintItemEventArgs e)
        {
            using(var brush = new SolidBrush(e.IsSelected ? e.Colors.SelectedForeColor : e.Colors.ForeColor))
                e.Graphics.DrawString(ToString(), e.Font, brush, e.TextRect, e.StringFormat);
        }
    }

    /// <summary>
    /// Enum CompareResult
    /// </summary>
    public enum CompareResult
    {
        /// <summary>
        /// Item do not appears
        /// </summary>
        Hidden,
        /// <summary>
        /// Item appears
        /// </summary>
        Visible,
        /// <summary>
        /// Item appears and will selected
        /// </summary>
        VisibleAndSelected
    }
}
