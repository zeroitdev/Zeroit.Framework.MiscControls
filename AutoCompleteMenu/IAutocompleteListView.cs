// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-22-2018
// ***********************************************************************
// <copyright file="IAutocompleteListView.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Control for displaying menu items, hosted in AutocompleteMenu.
    /// </summary>
    public interface IAutocompleteListView
    {
        /// <summary>
        /// Image list
        /// </summary>
        /// <value>The image list.</value>
        ImageList ImageList { get; set; }

        /// <summary>
        /// Index of current selected item
        /// </summary>
        /// <value>The index of the selected item.</value>
        int SelectedItemIndex { get; set; }

        /// <summary>
        /// Index of current selected item
        /// </summary>
        /// <value>The index of the highlighted item.</value>
        int HighlightedItemIndex { get; set; }

        /// <summary>
        /// List of visible elements
        /// </summary>
        /// <value>The visible items.</value>
        IList<AutocompleteItem> VisibleItems { get;set;}

        /// <summary>
        /// Duration (ms) of tooltip showing
        /// </summary>
        /// <value>The duration of the tool tip.</value>
        int ToolTipDuration { get; set; }

        /// <summary>
        /// Occurs when user selected item for inserting into text
        /// </summary>
        event EventHandler ItemSelected;

        /// <summary>
        /// Occurs when current hovered item is changing
        /// </summary>
        event EventHandler<HoveredEventArgs> ItemHovered;

        /// <summary>
        /// Shows tooltip
        /// </summary>
        /// <param name="autocompleteItem">The autocomplete item.</param>
        /// <param name="control">The control.</param>
        void ShowToolTip(AutocompleteItem autocompleteItem, Control control = null);

        /// <summary>
        /// Returns rectangle of item
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>Rectangle.</returns>
        Rectangle GetItemRectangle(int itemIndex);

        /// <summary>
        /// Colors
        /// </summary>
        /// <value>The colors.</value>
        Colors Colors { get; set; }
    }
}
