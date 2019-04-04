// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AutocompleteItems.cs" company="Zeroit Dev Technologies">
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
    /// This autocomplete item appears after dot
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.AutocompleteItem" />
    public class MethodAutocompleteItem : AutocompleteItem
    {
        /// <summary>
        /// The first part
        /// </summary>
        string firstPart;
        /// <summary>
        /// The lowercase text
        /// </summary>
        string lowercaseText;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodAutocompleteItem"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public MethodAutocompleteItem(string text)
            : base(text)
        {
            lowercaseText = Text.ToLower();
        }

        /// <summary>
        /// Compares fragment text with this item
        /// </summary>
        /// <param name="fragmentText">The fragment text.</param>
        /// <returns>CompareResult.</returns>
        public override CompareResult Compare(string fragmentText)
        {
            int i = fragmentText.LastIndexOf('.');
            if (i < 0)
                return CompareResult.Hidden;
            string lastPart = fragmentText.Substring(i + 1);
            firstPart = fragmentText.Substring(0, i);

            if (lastPart == "") return CompareResult.Visible;
            if (Text.StartsWith(lastPart, StringComparison.InvariantCultureIgnoreCase))
                return CompareResult.VisibleAndSelected;
            if (lowercaseText.Contains(lastPart.ToLower()))
                return CompareResult.Visible;

            return CompareResult.Hidden;
        }

        /// <summary>
        /// Returns text for inserting into Textbox
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetTextForReplace()
        {
            return firstPart + "." + Text;
        }
    }

    /// <summary>
    /// Autocomplete item for code snippets
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.AutocompleteItem" />
    /// <remarks>Snippet can contain special char ^ for caret position.</remarks>
    public class SnippetAutocompleteItem : AutocompleteItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SnippetAutocompleteItem"/> class.
        /// </summary>
        /// <param name="snippet">The snippet.</param>
        public SnippetAutocompleteItem(string snippet)
        {
            Text = snippet.Replace("\r", "");
            ToolTipTitle = "Code snippet:";
            ToolTipText = Text;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return MenuText ?? Text.Replace("\n", " ").Replace("^", "");
        }

        /// <summary>
        /// Returns text for inserting into Textbox
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetTextForReplace()
        {
            return Text;
        }

        /// <summary>
        /// This method is called after item was inserted into text
        /// </summary>
        /// <param name="e">The <see cref="SelectedEventArgs" /> instance containing the event data.</param>
        public override void OnSelected(SelectedEventArgs e)
        {
            var tb = Parent.TargetControlWrapper;
            //
            if (!Text.Contains("^"))
                return;
            var text = tb.Text;
            for (int i = Parent.Fragment.Start; i < text.Length; i++)
                if (text[i] == '^')
                {
                    tb.SelectionStart = i;
                    tb.SelectionLength = 1;
                    tb.SelectedText = "";
                    return;
                }
        }

        /// <summary>
        /// Compares fragment text with this item
        /// </summary>
        /// <param name="fragmentText">The fragment text.</param>
        /// <returns>CompareResult.</returns>
        public override CompareResult Compare(string fragmentText)
        {
            if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) &&
                   Text != fragmentText)
                return CompareResult.Visible;

            return CompareResult.Hidden;
        }
    }

    /// <summary>
    /// This class finds items by substring
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.AutocompleteItem" />
    public class SubstringAutocompleteItem : AutocompleteItem
    {
        /// <summary>
        /// The lowercase text
        /// </summary>
        protected readonly string lowercaseText;
        /// <summary>
        /// The ignore case
        /// </summary>
        protected readonly bool ignoreCase;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubstringAutocompleteItem"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        public SubstringAutocompleteItem(string text, bool ignoreCase = true)
            : base(text)
        {
            this.ignoreCase = ignoreCase;
            if(ignoreCase)
                lowercaseText = text.ToLower();
        }

        /// <summary>
        /// Compares fragment text with this item
        /// </summary>
        /// <param name="fragmentText">The fragment text.</param>
        /// <returns>CompareResult.</returns>
        public override CompareResult Compare(string fragmentText)
        {
            if(ignoreCase)
            {
                if (lowercaseText.Contains(fragmentText.ToLower()))
                    return CompareResult.Visible;
            }
            else
            {
                if (Text.Contains(fragmentText))
                    return CompareResult.Visible;
            }

            return CompareResult.Hidden;
        }
    }

    /// <summary>
    /// This item draws multicolumn menu
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.SubstringAutocompleteItem" />
    public class MulticolumnAutocompleteItem : SubstringAutocompleteItem
    {
        /// <summary>
        /// Gets or sets a value indicating whether [compare by substring].
        /// </summary>
        /// <value><c>true</c> if [compare by substring]; otherwise, <c>false</c>.</value>
        public bool CompareBySubstring { get; set; }
        /// <summary>
        /// Gets or sets the menu text by columns.
        /// </summary>
        /// <value>The menu text by columns.</value>
        public string[] MenuTextByColumns { get; set; }
        /// <summary>
        /// Gets or sets the width of the column.
        /// </summary>
        /// <value>The width of the column.</value>
        public int[] ColumnWidth { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MulticolumnAutocompleteItem"/> class.
        /// </summary>
        /// <param name="menuTextByColumns">The menu text by columns.</param>
        /// <param name="insertingText">The inserting text.</param>
        /// <param name="compareBySubstring">if set to <c>true</c> [compare by substring].</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        public MulticolumnAutocompleteItem(string[] menuTextByColumns, string insertingText, bool compareBySubstring = true, bool ignoreCase = true)
            : base(insertingText, ignoreCase)
        {
            this.CompareBySubstring = compareBySubstring;
            this.MenuTextByColumns = menuTextByColumns;
        }

        /// <summary>
        /// Compares the specified fragment text.
        /// </summary>
        /// <param name="fragmentText">The fragment text.</param>
        /// <returns>CompareResult.</returns>
        public override CompareResult Compare(string fragmentText)
        {
            if (CompareBySubstring)
                return base.Compare(fragmentText);

            if(ignoreCase)
            {
                if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase))
                    return CompareResult.VisibleAndSelected;
            }else
                if (Text.StartsWith(fragmentText))
                    return CompareResult.VisibleAndSelected;

            return CompareResult.Hidden;
        }

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintItemEventArgs" /> instance containing the event data.</param>
        /// <exception cref="Exception">ColumnWidth.Length != MenuTextByColumns.Length</exception>
        public override void OnPaint(PaintItemEventArgs e)
        {
            if (ColumnWidth != null && ColumnWidth.Length != MenuTextByColumns.Length)
                throw new Exception("ColumnWidth.Length != MenuTextByColumns.Length");

            int[] columnWidth = ColumnWidth;
            if(columnWidth == null)
            {
                columnWidth = new int[MenuTextByColumns.Length];
                float step = e.TextRect.Width/MenuTextByColumns.Length;
                for (int i = 0; i < MenuTextByColumns.Length; i++)
                    columnWidth[i] = (int)step;
            }

            //draw columns
            Pen pen = Pens.Silver;
            float x = e.TextRect.X;
            e.StringFormat.FormatFlags = e.StringFormat.FormatFlags | StringFormatFlags.NoWrap;

            using (var brush = new SolidBrush(e.IsSelected ? e.Colors.SelectedForeColor : e.Colors.ForeColor))
            for (int i=0;i<MenuTextByColumns.Length;i++)
            {
                var width = columnWidth[i];
                var rect = new RectangleF(x, e.TextRect.Top, width, e.TextRect.Height);
                e.Graphics.DrawLine(pen, new PointF(x, e.TextRect.Top), new PointF(x, e.TextRect.Bottom));
                e.Graphics.DrawString(MenuTextByColumns[i], e.Font, brush, rect, e.StringFormat);
                x += width;
            }
        }
    }
}