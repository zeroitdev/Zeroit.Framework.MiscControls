// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="FastList.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitFastList.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitFastListBase" />
    [DefaultEvent("ItemTextNeeded")]
    [ToolboxItem(true)]
    public class ZeroitFastList : ZeroitFastListBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFastList"/> class.
        /// </summary>
        public ZeroitFastList()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                ItemCount = 100;
                ItemTextNeeded += (o, a) => a.Result = "Item " + a.ItemIndex;
                SelectedItemIndexes.Add(0);
            }
        }

        /// <summary>
        /// Builds the specified item count.
        /// </summary>
        /// <param name="itemCount">The item count.</param>
        public void Build(int itemCount)
        {
            ItemCount = itemCount;
        }

        /// <summary>
        /// Rebuilds this instance.
        /// </summary>
        public void Rebuild()
        {
            Invalidate();
        }

        /// <summary>
        /// Builds the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void Build(ICollection list)
        {
            if (list == null)
                ItemCount = 0;
            else
                ItemCount = list.Count;
        }

        #region Overrided methods

        /// <summary>
        /// Checks the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool CheckItem(int itemIndex)
        {
            if (GetItemChecked(itemIndex))
                return true;

            Invalidate();

            if (CanCheckItem(itemIndex))
            {
                if (ItemCheckStateNeeded == null)//add to CheckedItemIndex only if handler of ItemCheckStateNeeded is not assigned
                    CheckedItemIndex.Add(itemIndex);
                OnItemChecked(itemIndex);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is item height fixed.
        /// </summary>
        /// <value><c>true</c> if this instance is item height fixed; otherwise, <c>false</c>.</value>
        protected override bool IsItemHeightFixed
        {
            get
            {
                return ItemHeightNeeded == null;
            }
        }

        #endregion Overrided methods

        #region Events

        /// <summary>
        /// Occurs when [item height needed].
        /// </summary>
        public event EventHandler<IntItemEventArgs> ItemHeightNeeded;
        /// <summary>
        /// Occurs when [item indent needed].
        /// </summary>
        public event EventHandler<IntItemEventArgs> ItemIndentNeeded;
        /// <summary>
        /// Occurs when [item text needed].
        /// </summary>
        public event EventHandler<StringItemEventArgs> ItemTextNeeded;
        /// <summary>
        /// Occurs when [item check state needed].
        /// </summary>
        public event EventHandler<BoolItemEventArgs> ItemCheckStateNeeded;
        /// <summary>
        /// Occurs when [item icon needed].
        /// </summary>
        public event EventHandler<ImageItemEventArgs> ItemIconNeeded;
        /// <summary>
        /// Occurs when [item CheckBox visible needed].
        /// </summary>
        public event EventHandler<BoolItemEventArgs> ItemCheckBoxVisibleNeeded;
        /// <summary>
        /// Occurs when [item back color needed].
        /// </summary>
        public event EventHandler<ColorItemEventArgs> ItemBackColorNeeded;
        /// <summary>
        /// Occurs when [item fore color needed].
        /// </summary>
        public event EventHandler<ColorItemEventArgs> ItemForeColorNeeded;
        /// <summary>
        /// Occurs when [item expanded needed].
        /// </summary>
        public event EventHandler<BoolItemEventArgs> ItemExpandedNeeded;
        /// <summary>
        /// Occurs when [can unselect item needed].
        /// </summary>
        public event EventHandler<BoolItemEventArgs> CanUnselectItemNeeded;
        /// <summary>
        /// Occurs when [can select item needed].
        /// </summary>
        public event EventHandler<BoolItemEventArgs> CanSelectItemNeeded;
        /// <summary>
        /// Occurs when [can uncheck item needed].
        /// </summary>
        public event EventHandler<BoolItemEventArgs> CanUncheckItemNeeded;
        /// <summary>
        /// Occurs when [can check item needed].
        /// </summary>
        public event EventHandler<BoolItemEventArgs> CanCheckItemNeeded;
        /// <summary>
        /// Occurs when [can expand item needed].
        /// </summary>
        public event EventHandler<BoolItemEventArgs> CanExpandItemNeeded;
        /// <summary>
        /// Occurs when [can collapse item needed].
        /// </summary>
        public event EventHandler<BoolItemEventArgs> CanCollapseItemNeeded;
        /// <summary>
        /// Occurs when [can edit item needed].
        /// </summary>
        public event EventHandler<BoolItemEventArgs> CanEditItemNeeded;

        /// <summary>
        /// Occurs when [item checked state changed].
        /// </summary>
        public event EventHandler<ItemCheckedStateChangedEventArgs> ItemCheckedStateChanged;
        /// <summary>
        /// Occurs when [item expanded state changed].
        /// </summary>
        public event EventHandler<ItemExpandedStateChangedEventArgs> ItemExpandedStateChanged;
        /// <summary>
        /// Occurs when [item selected state changed].
        /// </summary>
        public event EventHandler<ItemSelectedStateChangedEventArgs> ItemSelectedStateChanged;
        /// <summary>
        /// Occurs when [item text pushed].
        /// </summary>
        public event EventHandler<ItemTextPushedEventArgs> ItemTextPushed;

        /// <summary>
        /// Occurs when [paint item].
        /// </summary>
        public event EventHandler<PaintItemContentEventArgs> PaintItem;
        /// <summary>
        /// Occurs when [scrollbars updated].
        /// </summary>
        public event EventHandler ScrollbarsUpdated;

        /// <summary>
        /// Occurs when user start to drag items
        /// </summary>
        public event EventHandler<ItemDragEventArgs> ItemDrag;

        /// <summary>
        /// Occurs when user drag object over node
        /// </summary>
        public event EventHandler<DragOverItemEventArgs> DragOverItem;

        /// <summary>
        /// Occurs when user drop object on given item
        /// </summary>
        public event EventHandler<DragOverItemEventArgs> DropOverItem;

        /// <summary>
        /// Gets the height of the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>System.Int32.</returns>
        protected override int GetItemHeight(int itemIndex)
        {
            return GetIntItemProperty(itemIndex, ItemHeightNeeded, ItemHeightDefault);
        }

        /// <summary>
        /// Gets the item indent.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>System.Int32.</returns>
        public override int GetItemIndent(int itemIndex)
        {
            return GetIntItemProperty(itemIndex, ItemIndentNeeded, ItemIndentDefault);
        }

        /// <summary>
        /// Gets the item text.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>System.String.</returns>
        protected override string GetItemText(int itemIndex)
        {
            return GetStringItemProperty(itemIndex, ItemTextNeeded, string.Empty);
        }

        /// <summary>
        /// Gets the item checked.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool GetItemChecked(int itemIndex)
        {
            return GetBoolItemProperty(itemIndex, ItemCheckStateNeeded, CheckedItemIndex.Contains(itemIndex));
        }

        /// <summary>
        /// Gets the item icon.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>Image.</returns>
        protected override Image GetItemIcon(int itemIndex)
        {
            return GetImageItemProperty(itemIndex, ItemIconNeeded, ImageDefaultIcon);
        }

        /// <summary>
        /// Gets the item CheckBox visible.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool GetItemCheckBoxVisible(int itemIndex)
        {
            return GetBoolItemProperty(itemIndex, ItemCheckBoxVisibleNeeded, ShowCheckBoxes);
        }

        /// <summary>
        /// Gets the color of the item back.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>Color.</returns>
        protected override Color GetItemBackColor(int itemIndex)
        {
            return GetColorItemProperty(itemIndex, ItemBackColorNeeded, Color.Empty);
        }

        /// <summary>
        /// Gets the color of the item fore.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>Color.</returns>
        protected override Color GetItemForeColor(int itemIndex)
        {
            return GetColorItemProperty(itemIndex, ItemForeColorNeeded, ForeColor);
        }

        /// <summary>
        /// Gets the item expanded.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool GetItemExpanded(int itemIndex)
        {
            return GetBoolItemProperty(itemIndex, ItemExpandedNeeded, false);
        }

        /// <summary>
        /// Determines whether this instance [can unselect item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can unselect item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanUnselectItem(int itemIndex)
        {
            return GetBoolItemProperty(itemIndex, CanUnselectItemNeeded, true);
        }

        /// <summary>
        /// Determines whether this instance [can select item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can select item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanSelectItem(int itemIndex)
        {
            return GetBoolItemProperty(itemIndex, CanSelectItemNeeded, AllowSelectItems);
        }

        /// <summary>
        /// Determines whether this instance [can uncheck item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can uncheck item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanUncheckItem(int itemIndex)
        {
            return GetBoolItemProperty(itemIndex, CanUncheckItemNeeded, true);
        }

        /// <summary>
        /// Determines whether this instance [can check item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can check item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanCheckItem(int itemIndex)
        {
            return GetBoolItemProperty(itemIndex, CanCheckItemNeeded, true);
        }

        /// <summary>
        /// Determines whether this instance [can expand item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can expand item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanExpandItem(int itemIndex)
        {
            return GetBoolItemProperty(itemIndex, CanExpandItemNeeded, true);
        }

        /// <summary>
        /// Determines whether this instance [can collapse item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can collapse item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanCollapseItem(int itemIndex)
        {
            return GetBoolItemProperty(itemIndex, CanCollapseItemNeeded, true);
        }

        /// <summary>
        /// Determines whether this instance [can edit item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can edit item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanEditItem(int itemIndex)
        {
            return GetBoolItemProperty(itemIndex, CanEditItemNeeded, true);
        }

        /// <summary>
        /// Called when [item checked].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemChecked(int itemIndex)
        {
            if (ItemCheckedStateChanged != null)
                ItemCheckedStateChanged(this, new ItemCheckedStateChangedEventArgs { ItemIndex = itemIndex, Checked = true });

            base.OnItemChecked(itemIndex);
        }

        /// <summary>
        /// Called when [item unchecked].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemUnchecked(int itemIndex)
        {
            if (ItemCheckedStateChanged != null)
                ItemCheckedStateChanged(this, new ItemCheckedStateChangedEventArgs { ItemIndex = itemIndex, Checked = false });

            base.OnItemUnchecked(itemIndex);
        }

        /// <summary>
        /// Called when [item expanded].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemExpanded(int itemIndex)
        {
            if (ItemExpandedStateChanged != null)
                ItemExpandedStateChanged(this, new ItemExpandedStateChangedEventArgs { ItemIndex = itemIndex, Expanded = true });

            base.OnItemExpanded(itemIndex);
        }

        /// <summary>
        /// Called when [item collapsed].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemCollapsed(int itemIndex)
        {
            if (ItemExpandedStateChanged != null)
                ItemExpandedStateChanged(this, new ItemExpandedStateChangedEventArgs { ItemIndex = itemIndex, Expanded = false });

            base.OnItemCollapsed(itemIndex);
        }

        /// <summary>
        /// Called when [item selected].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemSelected(int itemIndex)
        {
            if (ItemSelectedStateChanged != null)
                ItemSelectedStateChanged(this, new ItemSelectedStateChangedEventArgs { ItemIndex = itemIndex, Selected = true });

            base.OnItemSelected(itemIndex);
        }

        /// <summary>
        /// Called when [item text pushed].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="text">The text.</param>
        protected override void OnItemTextPushed(int itemIndex, string text)
        {
            if (ItemTextPushed != null)
                ItemTextPushed(this, new ItemTextPushedEventArgs { ItemIndex = itemIndex, Text = text});

            base.OnItemTextPushed(itemIndex, text);
        }

        /// <summary>
        /// Called when [item unselected].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemUnselected(int itemIndex)
        {
            if (ItemSelectedStateChanged != null)
                ItemSelectedStateChanged(this, new ItemSelectedStateChangedEventArgs { ItemIndex = itemIndex, Selected = false });

            base.OnItemUnselected(itemIndex);
        }

        /// <summary>
        /// Called when [item drag].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemDrag(HashSet<int> itemIndex)
        {
            if (ItemDrag != null)
                ItemDrag(this, new ItemDragEventArgs { ItemIndex = itemIndex });
            else
                DoDragDrop(itemIndex, DragDropEffects.Copy);

            base.OnItemDrag(itemIndex);
        }

        /// <summary>
        /// Draws the item.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="info">The information.</param>
        protected override void DrawItem(Graphics gr, VisibleItemInfo info)
        {
            if (PaintItem != null)
                PaintItem(this, new PaintItemContentEventArgs {Graphics = gr, Info = info});
            else
                base.DrawItem(gr, info);
        }

        /// <summary>
        /// Handles the <see cref="E:DragOverItem" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DragOverItemEventArgs"/> instance containing the event data.</param>
        protected override void OnDragOverItem(DragOverItemEventArgs e)
        {
            base.OnDragOverItem(e);

            if (DragOverItem != null)
                DragOverItem(this, e);
        }

        /// <summary>
        /// Handles the <see cref="E:DropOverItem" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DragOverItemEventArgs"/> instance containing the event data.</param>
        protected override void OnDropOverItem(DragOverItemEventArgs e)
        {
            if (DropOverItem != null)
                DropOverItem(this, e);

            base.OnDropOverItem(e);
        }

        /// <summary>
        /// Called when [scrollbars updated].
        /// </summary>
        protected override void  OnScrollbarsUpdated()
        {
            if (ScrollbarsUpdated != null)
                ScrollbarsUpdated(this, EventArgs.Empty);
 	         base.OnScrollbarsUpdated();
        }

        #endregion

        #region Event Helpers

        /// <summary>
        /// The int argument
        /// </summary>
        private IntItemEventArgs intArg = new IntItemEventArgs();
        /// <summary>
        /// The bool argument
        /// </summary>
        private BoolItemEventArgs boolArg = new BoolItemEventArgs();
        /// <summary>
        /// The string argument
        /// </summary>
        private StringItemEventArgs stringArg = new StringItemEventArgs();
        /// <summary>
        /// The image argument
        /// </summary>
        private ImageItemEventArgs imageArg = new ImageItemEventArgs();
        /// <summary>
        /// The color argument
        /// </summary>
        private ColorItemEventArgs colorArg = new ColorItemEventArgs();

        /// <summary>
        /// Gets the int item property.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.Int32.</returns>
        int GetIntItemProperty(int itemIndex, EventHandler<IntItemEventArgs> handler, int defaultValue)
        {
            if (handler != null)
            {
                intArg.ItemIndex = itemIndex;
                intArg.Result = defaultValue;
                handler(this, intArg);
                return intArg.Result;
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the string item property.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.String.</returns>
        string GetStringItemProperty(int itemIndex, EventHandler<StringItemEventArgs> handler, string defaultValue)
        {
            if (handler != null)
            {
                stringArg.ItemIndex = itemIndex;
                stringArg.Result = defaultValue;
                handler(this, stringArg);
                return stringArg.Result;
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the bool item property.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool GetBoolItemProperty(int itemIndex, EventHandler<BoolItemEventArgs> handler, bool defaultValue)
        {
            if (handler != null)
            {
                boolArg.ItemIndex = itemIndex;
                boolArg.Result = defaultValue;
                handler(this, boolArg);
                return boolArg.Result;
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the image item property.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Image.</returns>
        Image GetImageItemProperty(int itemIndex, EventHandler<ImageItemEventArgs> handler, Image defaultValue)
        {
            if (handler != null)
            {
                imageArg.ItemIndex = itemIndex;
                imageArg.Result = defaultValue;
                handler(this, imageArg);
                return imageArg.Result;
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the color item property.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Color.</returns>
        Color GetColorItemProperty(int itemIndex, EventHandler<ColorItemEventArgs> handler, Color defaultValue)
        {
            if (handler != null)
            {
                colorArg.ItemIndex = itemIndex;
                colorArg.Result = defaultValue;
                handler(this, colorArg);
                return colorArg.Result;
            }

            return defaultValue;
        }

        #endregion Helpers
    }

    /// <summary>
    /// Class GenericItemResultEventArgs.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.EventArgs" />
    public class GenericItemResultEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Gets the index of the item.
        /// </summary>
        /// <value>The index of the item.</value>
        public int ItemIndex { get; internal set; }
        /// <summary>
        /// The result
        /// </summary>
        public T Result;
    }

    /// <summary>
    /// Class IntItemEventArgs.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.GenericItemResultEventArgs{System.Int32}" />
    public class IntItemEventArgs : GenericItemResultEventArgs<int>
    {
    }

    /// <summary>
    /// Class StringItemEventArgs.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.GenericItemResultEventArgs{System.String}" />
    public class StringItemEventArgs : GenericItemResultEventArgs<string>
    {
    }

    /// <summary>
    /// Class ImageItemEventArgs.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.GenericItemResultEventArgs{System.Drawing.Image}" />
    public class ImageItemEventArgs : GenericItemResultEventArgs<Image>
    {
    }

    /// <summary>
    /// Class ColorItemEventArgs.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.GenericItemResultEventArgs{System.Drawing.Color}" />
    public class ColorItemEventArgs : GenericItemResultEventArgs<Color>
    {
    }

    /// <summary>
    /// Class BoolItemEventArgs.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.GenericItemResultEventArgs{System.Boolean}" />
    public class BoolItemEventArgs : GenericItemResultEventArgs<bool>
    {
    }

    /// <summary>
    /// Class ItemCheckedStateChangedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ItemCheckedStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The item index
        /// </summary>
        public int ItemIndex;
        /// <summary>
        /// The checked
        /// </summary>
        public bool Checked;
    }

    /// <summary>
    /// Class ItemExpandedStateChangedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ItemExpandedStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The item index
        /// </summary>
        public int ItemIndex;
        /// <summary>
        /// The expanded
        /// </summary>
        public bool Expanded;
    }

    /// <summary>
    /// Class ItemSelectedStateChangedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ItemSelectedStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The item index
        /// </summary>
        public int ItemIndex;
        /// <summary>
        /// The selected
        /// </summary>
        public bool Selected;
    }

    /// <summary>
    /// Class PaintItemContentEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class PaintItemContentEventArgs:EventArgs
    {
        /// <summary>
        /// The graphics
        /// </summary>
        public Graphics Graphics;
        /// <summary>
        /// The information
        /// </summary>
        public ZeroitFastListBase.VisibleItemInfo Info;
    }

    /// <summary>
    /// Class ItemDragEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ItemDragEventArgs : EventArgs
    {
        /// <summary>
        /// The item index
        /// </summary>
        public HashSet<int> ItemIndex;
    }

    /// <summary>
    /// Class ItemTextPushedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ItemTextPushedEventArgs : EventArgs
    {
        /// <summary>
        /// The item index
        /// </summary>
        public int ItemIndex;
        /// <summary>
        /// The text
        /// </summary>
        public string Text;
    }
}
