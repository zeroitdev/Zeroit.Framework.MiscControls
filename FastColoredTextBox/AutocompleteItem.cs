// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="AutocompleteItem.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Item of autocomplete menu
    /// </summary>
    public class AutocompleteItem
    {
        /// <summary>
        /// The text
        /// </summary>
        public string Text;
        /// <summary>
        /// The image index
        /// </summary>
        public int ImageIndex = -1;
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
        /// Gets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public AutocompleteMenu Parent { get; internal set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteItem"/> class.
        /// </summary>
        public AutocompleteItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteItem"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public AutocompleteItem(string text)
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
        /// This method is called after item inserted into text
        /// </summary>
        /// <param name="popupMenu">The popup menu.</param>
        /// <param name="e">The <see cref="SelectedEventArgs"/> instance containing the event data.</param>
        public virtual void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
        {
            ;
        }

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
            get{ return toolTipText; }
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
        /// Fore color of text of item
        /// </summary>
        /// <value>The color of the fore.</value>
        /// <exception cref="System.NotImplementedException">Override this property to change color</exception>
        public virtual Color ForeColor
        {
            get { return Color.Transparent; }
            set { throw new NotImplementedException("Override this property to change color"); }
        }

        /// <summary>
        /// Back color of item
        /// </summary>
        /// <value>The color of the back.</value>
        /// <exception cref="System.NotImplementedException">Override this property to change color</exception>
        public virtual Color BackColor
        {
            get { return Color.Transparent; }
            set { throw new NotImplementedException("Override this property to change color"); }
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

    /// <summary>
    /// Autocomplete item for code snippets
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.AutocompleteItem" />
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
        /// This method is called after item inserted into text
        /// </summary>
        /// <param name="popupMenu">The popup menu.</param>
        /// <param name="e">The <see cref="SelectedEventArgs"/> instance containing the event data.</param>
        public override void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
        {
            e.Tb.BeginUpdate();
            e.Tb.Selection.BeginUpdate();
            //remember places
            var p1 = popupMenu.Fragment.Start;
            var p2 = e.Tb.Selection.Start;
            //do auto indent
            if (e.Tb.AutoIndent)
            {
                for (int iLine = p1.iLine + 1; iLine <= p2.iLine; iLine++)
                {
                    e.Tb.Selection.Start = new Place(0, iLine);
                    e.Tb.DoAutoIndent(iLine);
                }
            }
            e.Tb.Selection.Start = p1;
            //move caret position right and find char ^
            while (e.Tb.Selection.CharBeforeStart != '^')
                if (!e.Tb.Selection.GoRightThroughFolded())
                    break;
            //remove char ^
            e.Tb.Selection.GoLeft(true);
            e.Tb.InsertText("");
            //
            e.Tb.Selection.EndUpdate();
            e.Tb.EndUpdate();
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
    /// This autocomplete item appears after dot
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.AutocompleteItem" />
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

            if(lastPart=="") return CompareResult.Visible;
            if(Text.StartsWith(lastPart, StringComparison.InvariantCultureIgnoreCase))
                return CompareResult.VisibleAndSelected;
            if(lowercaseText.Contains(lastPart.ToLower()))
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
    /// This Item does not check correspondence to current text fragment.
    /// SuggestItem is intended for dynamic menus.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.AutocompleteItem" />
    public class SuggestItem : AutocompleteItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuggestItem"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="imageIndex">Index of the image.</param>
        public SuggestItem(string text, int imageIndex):base(text, imageIndex)
        {   
        }

        /// <summary>
        /// Compares fragment text with this item
        /// </summary>
        /// <param name="fragmentText">The fragment text.</param>
        /// <returns>CompareResult.</returns>
        public override CompareResult Compare(string fragmentText)
        {
            return CompareResult.Visible;
        }
    }
}
