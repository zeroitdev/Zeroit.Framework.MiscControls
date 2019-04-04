// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="ButtonBar.Overrides.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitToxicButton.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    partial class ZeroitToxicButton
    {
        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Leave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!Focused)
                Focus();
            base.OnMouseDown(e);
            var info = HitTest();
            if (info.Area == HitArea.Button)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        items[info.ButtonIndex].MouseDown = true;
                        Invalidate();
                        break;
                    case MouseButtons.Right:
                        {
                            var itemEventArgs = new GenericClickEventArgs<BarItem>(items[info.ButtonIndex],
                                                                                   MouseButtons.Right,
                                                                                   new Point(e.X, e.Y));
                            OnItemClick(itemEventArgs);
                        }
                        break;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                OnBarClick(e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RefreshControl();
        }

        /// <summary>
        /// Processes the mnemonic.
        /// </summary>
        /// <param name="charCode">The character to process.</param>
        /// <returns>true if the character was processed as a mnemonic by the control; otherwise, false.</returns>
        protected override bool ProcessMnemonic(Char charCode)
        {
            string itemText;
            var index = -1;
            var compareText = "&" + Char.ToUpper(charCode);
            var ret = false;

            for (var i = 0; i < items.Count; i++)
            {
                itemText = items[i].Caption.ToUpper();
                var pos = itemText.IndexOf(compareText);
                if (pos <= 0) continue;
                index = i;
                ret = true;
                break;
            }
            if (index > -1)
            {
                items[index].Selected = true;
                EnsureVisibility(index);
                var itemClickArgs = new GenericClickEventArgs<BarItem>(items[index], MouseButtons.None, new Point(0, 0));
                OnItemClick(itemClickArgs);
            }

            return ret;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button != MouseButtons.Left) return;
            var changed = false;
            for (var i = 0; i < items.Count; i++)
            {
                if (!items[i].MouseDown) continue;
                var info = HitTest();
                if (info.ButtonIndex == i)
                {
                    if (items[i].Enabled)
                    {
                        items[i].MouseDown = false;
                        items[i].Selected = true;
                        EnsureVisibility(i);
                        Invalidate();
                        var itemEventArgs = new GenericClickEventArgs<BarItem>(items[i], MouseButtons.Left,
                                                                               new Point(e.X, e.Y));
                        OnItemClick(itemEventArgs);
                    }
                    else
                    {
                        items[i].MouseDown = false;
                    }
                }
                else
                {
                    items[i].MouseDown = false;
                    changed = true;
                }
            }
            if (changed)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var changed = false;
            var info = HitTest();
            for (var i = 0; i < items.Count; i++)
            {
                if (i == info.ButtonIndex)
                {
                    if (!items[i].MouseOver)
                    {
                        SetToolTip(items[i].ToolTipText);
                        items[i].MouseOver = true;
                        changed = true;
                    }
                }
                else
                {
                    if (items[i].MouseOver)
                    {
                        items[i].MouseOver = false;
                        changed = true;
                    }
                }
            }
            if (info.ButtonIndex == -1)
            {
                SetToolTip("");
            }
            if (changed)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (items == null) return;
            if (items.Count <= 0) return;
            var newIndex = -1;
            var currentIndex = -1;
            var mouseOverIndex = -1;
            var found = false;
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].MouseOver)
                {
                    mouseOverIndex = i;
                }
                if (items[i].Selected)
                {
                    currentIndex = i;
                }
            }

            if (mouseOverIndex > 0)
            {
                currentIndex = mouseOverIndex;
            }
            switch (e.KeyCode)
            {
                case Keys.Up:
                    newIndex = NextItem(currentIndex, -1);
                    break;
                case Keys.Down:
                    newIndex = NextItem(currentIndex, 1);
                    break;
                case Keys.PageUp:
                    newIndex = NextItem(currentIndex, -4);
                    break;
                case Keys.PageDown:
                    newIndex = NextItem(currentIndex, 4);
                    break;
                case Keys.Home:
                    newIndex = 1;
                    while (!found)
                    {
                        if (items[newIndex].Enabled)
                        {
                            found = true;
                        }
                        else
                        {
                            newIndex++;
                            if (newIndex >= items.Count)
                            {
                                found = true;
                            }
                        }
                    }
                    break;
                case Keys.End:
                    newIndex = items.Count - 1;
                    while (!found)
                    {
                        if (items[newIndex].Enabled)
                        {
                            found = true;
                        }
                        else
                        {
                            newIndex--;
                            if (newIndex < 0)
                            {
                                found = true;
                            }
                        }
                    }
                    break;
                case Keys.Enter:
                    if (mouseOverIndex >= 0)
                    {
                        items[mouseOverIndex].Selected = true;
                        items[mouseOverIndex].MouseOver = false;
                        for (var i = 0; i < items.Count; i++)
                        {
                            items[i].MouseOver = false;
                        }
                        EnsureVisibility(mouseOverIndex);
                        var itemClickArgs = new GenericClickEventArgs<BarItem>(items[mouseOverIndex], MouseButtons.None,
                                                                               new Point(0, 0));
                        OnItemClick(itemClickArgs);
                    }
                    break;
            }

            if ((newIndex == currentIndex) || (newIndex <= -1) || (newIndex >= items.Count)) return;
            for (var i = 0; i < items.Count; i++)
            {
                items[i].MouseOver = i == newIndex;
            }
            EnsureVisibility(newIndex);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SystemColorsChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSystemColorsChanged(EventArgs e)
        {
            base.OnSystemColorsChanged(e);
            SetThemeDefaults();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ScrollableControl.Scroll" /> event.
        /// </summary>
        /// <param name="se">A <see cref="T:System.Windows.Forms.ScrollEventArgs" /> that contains the event data.</param>
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            Invalidate();
        }

        /// <summary>
        /// Determines whether the specified key is a regular input key or a special key that requires preprocessing.
        /// </summary>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values.</param>
        /// <returns>true if the specified key is a regular input key; otherwise, false.</returns>
        protected override bool IsInputKey(Keys keyData)
        {
            var ret = base.IsInputKey(keyData);
            switch (keyData)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Left:
                case Keys.Enter:
                    ret = true;
                    break;
            }
            return ret;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            var index = -1;
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].MouseDown)
                {
                    return;
                }
                if (items[i].MouseOver)
                {
                    index = i;
                }
            }
            if ((index < 0) || (items.Count <= 0)) return;
            var info = HitTest();
            if (info.ButtonIndex >= 0) return;
            SetToolTip("");
            items[index].MouseOver = false;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            CreateMemoryBitmap();
            //RefreshControl();
            Graphics.Clear(BackColor);
            //Graphics.Clear(Color.Transparent);
            var bArgs = new DrawBackGroundEventArgs(Graphics, ClientRectangle, CurrentAppearance.Bar, this);
            OnCustomDrawBackGround(bArgs);
            if (!bArgs.Handeled)
            {
                bArgs.DrawBackground();
                bArgs.DrawBorder();
            }
            if (!((items == null) || (items.Count == 0)))
            {
                foreach (BarItem barItem in items)
                {
                    var itemRect = new Rectangle(Padding.Left, barItem.Top, buttonWidth - Padding.Left - Padding.Right,
                                                 barItem.Height);
                    itemRect.Offset(0, AutoScrollPosition.Y);
                    var args = new DrawItemsEventArgs(Graphics, itemRect, barItem, GetButtonState(barItem), this);
                    OnCustomDrawItems(args);
                    if (args.Handeled) continue;
                    args.DrawItemBackGround();
                    args.DrawItemBorder();
                    args.DrawIcon();
                    args.DrawItemText();
                }
            }
            if (!Enabled)
                Graphics.FillRectangle(
                    new SolidBrush(Color.FromArgb((int) (DisableTransparency*2.55), CurrentAppearance.Bar.DisabledMask)),
                    0, 0, Width - 1, Height - 1);
            PaintUtility.DrawImage(e.Graphics, new Rectangle(0, 0, Width, Height), bmp, (int) (ImageTransparency*2.55));
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.PaddingChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            RefreshControl();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseWheel" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            Invalidate();
        }

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Fires <see cref="CustomDrawBackGround" /> event.
        /// </summary>
        /// <param name="args">Object containing event data.</param>
        protected virtual void OnCustomDrawBackGround(DrawBackGroundEventArgs args)
        {
            if (CustomDrawBackGround != null)
            {
                CustomDrawBackGround(this, args);
            }
        }

        /// <summary>
        /// Fires <see cref="CustomDrawItems" /> event.
        /// </summary>
        /// <param name="args">Object containing event data.</param>
        protected virtual void OnCustomDrawItems(DrawItemsEventArgs args)
        {
            if (CustomDrawItems != null)
            {
                CustomDrawItems(this, args);
            }
        }

        /// <summary>
        /// Fires <see cref="ItemClick" /> event
        /// </summary>
        /// <param name="e">Object containing event data.</param>
        protected virtual void OnItemClick(GenericClickEventArgs<BarItem> e)
        {
            if (ItemClick != null)
            {
                ItemClick(this, e);
            }
        }

        /// <summary>
        /// Fires <see cref="BarClick" /> event.
        /// </summary>
        /// <param name="e">Object containing event data.</param>
        protected virtual void OnBarClick(MouseEventArgs e)
        {
            if (BarClick != null)
            {
                BarClick(this, e);
            }
        }

        /// <summary>
        /// Fires <see cref="SelectionChanged" /> event
        /// </summary>
        /// <param name="e">Object containing event data.</param>
        protected virtual void OnSelectionChanged(GenericEventArgs<BarItem> e)
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(this, e);
            }
        }

        /// <summary>
        /// Fires <see cref="SelectionChanged" /> event
        /// </summary>
        /// <param name="e">Object containing event data.</param>
        protected virtual void OnSelectionChanging(GenericChangeEventArgs<BarItem> e)
        {
            if (SelectionChanging != null)
            {
                int indx = -1;
                for (int i = 0; i < Items.Count; i++)
                {
                    if (e.NewValue.Equals(Items[i]))
                    {
                        indx = i;
                        break;
                    }
                }
                SelectionChanging(indx, e);
            }
        }

        /// <summary>
        /// Fires <see cref="ItemsClearing" /> event.
        /// </summary>
        /// <param name="value">Object containing event data.</param>
        protected virtual void OnItemsClearing(GenericCancelEventArgs<GenericCollection<BarItem>> value)
        {
            if (ItemsClearing != null)
            {
                ItemsClearing(value);
            }
        }

        /// <summary>
        /// Fires <see cref="ItemsRemoving" /> event.
        /// </summary>
        /// <param name="index">Index of item being removed.</param>
        /// <param name="value">Item collection from where item is being removed.</param>
        protected virtual void OnItemsRemoving(int index, GenericCancelEventArgs<BarItem> value)
        {
            if (ItemsRemoving != null)
            {
                ItemsRemoving(index, value);
            }
        }

        /// <summary>
        /// Fires <see cref="ItemsChanging" /> event.
        /// </summary>
        /// <param name="index">Index of item being changed.</param>
        /// <param name="e">Object containing event data.</param>
        protected virtual void OnItemsChanging(int index, GenericChangeEventArgs<BarItem> e)
        {
            if (ItemsChanging != null)
            {
                ItemsChanging(index, e);
            }
        }

        /// <summary>
        /// Fires <see cref="ItemsInserting" /> event.
        /// </summary>
        /// <param name="index">Index of item</param>
        /// <param name="value">Object containing event data.</param>
        protected virtual void OnItemsInserting(int index, GenericCancelEventArgs<BarItem> value)
        {
            if (ItemsInserting != null)
            {
                ItemsInserting(index, value);
            }
        }

        /// <summary>
        /// Fires <see cref="ItemsChanged" />
        /// </summary>
        /// <param name="index">Index of item.</param>
        /// <param name="oldValue">Old value of Item</param>
        /// <param name="newValue">New Value of item</param>
        protected virtual void OnItemsChanged(int index, BarItem oldValue, BarItem newValue)
        {
            newValue.Owner = this;
            if (ItemsChanged != null)
            {
                ItemsChanged(index, oldValue, newValue);
            }
            RefreshControl();
        }

        /// <summary>
        /// Fires <see cref="ItemsRemoved" />
        /// </summary>
        /// <param name="index">Index of Item.</param>
        /// <param name="value">Item removed.</param>
        protected virtual void OnItemsRemoved(int index, BarItem value)
        {
            if (ItemsRemoved != null)
                ItemsRemoved(index, value);
            RefreshControl();
        }

        /// <summary>
        /// Fires <see cref="ItemsInserted" />event.
        /// </summary>
        /// <param name="index">Index of Item.</param>
        /// <param name="value">Item inserted.</param>
        protected virtual void OnItemsInserted(int index, BarItem value)
        {
            value.Owner = this;
            if (SelectedItem == null && items.Count > 0)
            {
                items[0].Selected = true;
            }
            if (ItemsInserted != null)
                ItemsInserted(index, value);
            RefreshControl();
        }

        #endregion
    }
}