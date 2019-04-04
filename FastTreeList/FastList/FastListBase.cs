// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="FastListBase.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using Zeroit.Framework.MiscControls.Properties;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitFastListBase.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public class ZeroitFastListBase : UserControl
    {
        /// <summary>
        /// The y of items
        /// </summary>
        private readonly List<int> yOfItems = new List<int>();
        /// <summary>
        /// The tt
        /// </summary>
        private ToolTip tt;
        /// <summary>
        /// The item count
        /// </summary>
        private int itemCount;
        /// <summary>
        /// The current hot tracking index
        /// </summary>
        protected int currentHotTrackingIndex;
        /// <summary>
        /// The show scroll bar
        /// </summary>
        private bool showScrollBar;
        /// <summary>
        /// The local automatic scroll minimum size
        /// </summary>
        private Size localAutoScrollMinSize;

        /// <summary>
        /// Gets the selected item indexes.
        /// </summary>
        /// <value>The selected item indexes.</value>
        [Browsable(false)]
        public HashSet<int> SelectedItemIndexes { get; private set; }
        /// <summary>
        /// Gets the index of the selected item.
        /// </summary>
        /// <value>The index of the selected item.</value>
        [Browsable(false)]
        public int SelectedItemIndex { get { return SelectedItemIndexes.Count == 0 ? -1 : SelectedItemIndexes.First(); } }
        /// <summary>
        /// Gets the index of the checked item.
        /// </summary>
        /// <value>The index of the checked item.</value>
        [Browsable(false)]
        public HashSet<int> CheckedItemIndex { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show tool tips].
        /// </summary>
        /// <value><c>true</c> if [show tool tips]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool ShowToolTips { get; set; }
        /// <summary>
        /// Gets or sets the item height default.
        /// </summary>
        /// <value>The item height default.</value>
        [DefaultValue(17)]
        public virtual int ItemHeightDefault { get; set; }
        /// <summary>
        /// Gets or sets the item line alignment default.
        /// </summary>
        /// <value>The item line alignment default.</value>
        [DefaultValue(StringAlignment.Near)]
        public virtual StringAlignment ItemLineAlignmentDefault { get; set; }
        /// <summary>
        /// Gets or sets the item indent default.
        /// </summary>
        /// <value>The item indent default.</value>
        [DefaultValue(10)]
        public virtual int ItemIndentDefault { get; set; }
        /// <summary>
        /// Gets or sets the size of the icon.
        /// </summary>
        /// <value>The size of the icon.</value>
        [DefaultValue(typeof(Size), "16, 16")]
        public Size IconSize { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is edit mode.
        /// </summary>
        /// <value><c>true</c> if this instance is edit mode; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsEditMode { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitFastListBase"/> is readonly.
        /// </summary>
        /// <value><c>true</c> if readonly; otherwise, <c>false</c>.</value>
        [Browsable(true), DefaultValue(false)]
        public bool Readonly { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show icons].
        /// </summary>
        /// <value><c>true</c> if [show icons]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool ShowIcons { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show check boxes].
        /// </summary>
        /// <value><c>true</c> if [show check boxes]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool ShowCheckBoxes { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show expand boxes].
        /// </summary>
        /// <value><c>true</c> if [show expand boxes]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool ShowExpandBoxes { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show empty expand boxes].
        /// </summary>
        /// <value><c>true</c> if [show empty expand boxes]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool ShowEmptyExpandBoxes { get; set; }
        /// <summary>
        /// Gets or sets the image CheckBox on.
        /// </summary>
        /// <value>The image CheckBox on.</value>
        public virtual Image ImageCheckBoxOn { get; set; }
        /// <summary>
        /// Gets or sets the image CheckBox off.
        /// </summary>
        /// <value>The image CheckBox off.</value>
        public virtual Image ImageCheckBoxOff { get; set; }
        /// <summary>
        /// Gets or sets the image collapse.
        /// </summary>
        /// <value>The image collapse.</value>
        public virtual Image ImageCollapse { get; set; }
        /// <summary>
        /// Gets or sets the image expand.
        /// </summary>
        /// <value>The image expand.</value>
        public virtual Image ImageExpand { get; set; }
        /// <summary>
        /// Gets or sets the image empty expand.
        /// </summary>
        /// <value>The image empty expand.</value>
        public virtual Image ImageEmptyExpand { get; set; }
        /// <summary>
        /// Gets or sets the image default icon.
        /// </summary>
        /// <value>The image default icon.</value>
        public virtual Image ImageDefaultIcon { get; set; }

        /// <summary>
        /// Gets or sets the color of the selection.
        /// </summary>
        /// <value>The color of the selection.</value>
        [DefaultValue(typeof(Color), "33, 53, 80")]
        public Color SelectionColor { get; set; }
        /// <summary>
        /// Gets or sets the selection color opaque.
        /// </summary>
        /// <value>The selection color opaque.</value>
        [DefaultValue(100)]
        public int SelectionColorOpaque { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [multi select].
        /// </summary>
        /// <value><c>true</c> if [multi select]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool MultiSelect { get; set; }
        /// <summary>
        /// Gets or sets the item interval.
        /// </summary>
        /// <value>The item interval.</value>
        [DefaultValue(2)]
        public int ItemInterval { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [full item select].
        /// </summary>
        /// <value><c>true</c> if [full item select]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool FullItemSelect { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [allow drag items].
        /// </summary>
        /// <value><c>true</c> if [allow drag items]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool AllowDragItems { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [allow select items].
        /// </summary>
        /// <value><c>true</c> if [allow select items]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool AllowSelectItems { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [hot tracking].
        /// </summary>
        /// <value><c>true</c> if [hot tracking]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool HotTracking { get; set; }
        /// <summary>
        /// Gets or sets the color of the hot tracking.
        /// </summary>
        /// <value>The color of the hot tracking.</value>
        [DefaultValue(typeof(Color), "255, 192, 128")]
        public Color HotTrackingColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show scroll bar].
        /// </summary>
        /// <value><c>true</c> if [show scroll bar]; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Scollbar visibility.")]
        public bool ShowScrollBar
        {
            get { return showScrollBar; }
            set
            {
                if (value == showScrollBar) return;
                showScrollBar = value;
                buildNeeded = true;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        /// <value><c>true</c> if [automatic scroll]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public override bool AutoScroll { get { return true; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFastListBase"/> class.
        /// </summary>
        public ZeroitFastListBase()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable, true);

            tt = new ToolTip() { UseAnimation = false };

            SelectedItemIndexes = new HashSet<int>();
            CheckedItemIndex = new HashSet<int>();
            InitDefaultProperties();
        }

        /// <summary>
        /// Initializes the default properties.
        /// </summary>
        protected virtual void InitDefaultProperties()
        {
            IconSize = new Size(16, 16);
            ItemHeightDefault = 17;
            VerticalScroll.SmallChange = ItemHeightDefault;

            ImageCheckBoxOn = Resources.checkbox_yes;
            ImageCheckBoxOff = Resources.checkbox_no;
            ImageCollapse = Resources.collapse1;
            ImageExpand = Resources.expand1;
            ImageEmptyExpand = Resources.empty;
            ImageDefaultIcon = Resources.default_icon;
            SelectionColor = Color.FromArgb(33, 53, 80);
            SelectionColorOpaque = 100;
            ItemInterval = 2;
            BackColor = SystemColors.Window;
            ItemIndentDefault = 10;
            ShowToolTips = true;
            AllowSelectItems = true;
            ShowEmptyExpandBoxes = true;
            HotTrackingColor = Color.FromArgb(255, 192, 128);
            showScrollBar = true;
        }

        /// <summary>
        /// Gets or sets the item count.
        /// </summary>
        /// <value>The item count.</value>
        public virtual int ItemCount
        {
            get { return itemCount; }
            set
            {
                itemCount = value;
                if (IsHandleCreated)
                    Build();
                else
                    BuildNeeded();
            }
        }

        #region Drag&Drop

        /// <summary>
        /// The last drag and drop effect
        /// </summary>
        private DragOverItemEventArgs lastDragAndDropEffect;

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.DragOver" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.DragEventArgs" /> that contains the event data.</param>
        protected override void OnDragOver(DragEventArgs e)
        {
            var p = new Point(e.X, e.Y);
            p = PointToClient(p);

            var itemIndex = YToIndexAround(p.Y + VerticalScroll.Value);
            var rect = CalcItemRect(itemIndex);

            var textRect = rect;
            if (visibleItemInfos.ContainsKey(itemIndex))
            {
                var info = visibleItemInfos[itemIndex];
                textRect = new Rectangle(info.X_Text, rect.Y, info.X_EndText - info.X_Text + 1, rect.Height);
            }

            var ea = new DragOverItemEventArgs(e.Data, e.KeyState, p.X, p.Y, e.AllowedEffect, e.Effect, rect, textRect) { ItemIndex = itemIndex };

            OnDragOverItem(ea);

            if (ea.Effect != DragDropEffects.None)
                lastDragAndDropEffect = ea;
            else
                lastDragAndDropEffect = null;

            e.Effect = ea.Effect;

            //scroll
            if (ea.ItemIndex >= 0 && ea.ItemIndex < ItemCount && itemIndex != ea.ItemIndex)
            {
                rect = CalcItemRect(ea.ItemIndex);
                rect.Inflate(0, 2);
                rect.Offset(HorizontalScroll.Value, VerticalScroll.Value);
                ScrollToRectangle(rect);
            }
            else
            {
                if (p.Y <= Padding.Top + ItemHeightDefault / 2)
                    ScrollUp();
                else if (p.Y >= ClientSize.Height - Padding.Bottom - +ItemHeightDefault / 2)
                    ScrollDown();
            }

            Invalidate();

            //base.OnDragOver(e);
        }

        /// <summary>
        /// Handles the <see cref="E:DragOverItem" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DragOverItemEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDragOverItem(DragOverItemEventArgs e)
        {
            if (e.Y < e.ItemRect.Y + e.ItemRect.Height / 2)
                e.InsertEffect = InsertEffect.InsertBefore;
            else
                e.InsertEffect = InsertEffect.InsertAfter;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.DragDrop" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.DragEventArgs" /> that contains the event data.</param>
        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

            if (lastDragAndDropEffect != null)
                OnDropOverItem(lastDragAndDropEffect);

            lastDragAndDropEffect = null;
            Invalidate();
        }

        /// <summary>
        /// Handles the <see cref="E:DropOverItem" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DragOverItemEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDropOverItem(DragOverItemEventArgs e)
        {
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.DragLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnDragLeave(EventArgs e)
        {
            base.OnDragLeave(e);
            lastDragAndDropEffect = null;
            Invalidate();
        }

        /// <summary>
        /// Calculates the item rect.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Rectangle.</returns>
        public Rectangle CalcItemRect(int index)
        {
            Rectangle res;

            var i = index;
            if (i >= ItemCount)
                i = ItemCount - 1;

            if (i < 0)
                res = Rectangle.FromLTRB(ClientRectangle.Left + Padding.Left, ClientRectangle.Top + Padding.Top - 2, ClientRectangle.Right - Padding.Right, ClientRectangle.Top + Padding.Top - 1);
            else
            {
                var y = GetItemY(i);
                var h = GetItemY(i + 1) - y;

                res = Rectangle.FromLTRB(ClientRectangle.Left + Padding.Left, y, ClientRectangle.Right - Padding.Right,
                                         y + h);

                if (index >= itemCount)
                    res.Offset(0, (index - itemCount + 1) * ItemHeightDefault);
            }

            res.Offset(-HorizontalScroll.Value, -VerticalScroll.Value);

            return res;
        }

        #endregion Drop

        #region Keyboard

        /// <summary>
        /// Determines whether the specified key is a regular input key or a special key that requires preprocessing.
        /// </summary>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values.</param>
        /// <returns>true if the specified key is a regular input key; otherwise, false.</returns>
        protected override bool IsInputKey(Keys keyData)
        {
            if (!IsEditMode)
            {
                switch (keyData)
                {
                    case Keys.Home:
                    case Keys.End:
                    case Keys.PageDown:
                    case Keys.PageUp:
                    case Keys.Down:
                    case Keys.Up:
                    case Keys.Left:
                    case Keys.Right:
                    case Keys.Enter:
                    case Keys.Space:
                    case Keys.A | Keys.Control:
                        return true;

                    default:
                        return false;
                }
            }
            else
                return base.IsInputKey(keyData);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Handled) return;

            CancelDelayedAction();

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (e.Control)
                        ScrollUp();
                    else
                        SelectPrev();
                    break;

                case Keys.Down:
                    if (e.Control)
                        ScrollDown();
                    else
                        SelectNext();
                    break;

                case Keys.PageUp:
                    if (e.Control)
                        ScrollPageUp();
                    else
                    if (SelectedItemIndexes.Count > 0)
                    {
                        var i = SelectedItemIndexes.First();
                        var y = GetItemY(i) - ClientRectMinusPaddings.Height;
                        i = YToIndex(y) + 1;
                        SelectItem(Math.Max(0, Math.Min(ItemCount - 1, i)));
                    }
                    break;

                case Keys.PageDown:
                    if (e.Control)
                        ScrollPageDown();
                    else
                    if (SelectedItemIndexes.Count > 0)
                    {
                        var i = SelectedItemIndexes.First();
                        var y = GetItemY(i) + ClientRectMinusPaddings.Height;
                        i = YToIndex(y);
                        SelectItem(i < 0 ? ItemCount - 1 : i);
                    }
                    break;

                case Keys.Home:
                    if (e.Control)
                        ScrollToItem(0);
                    else
                        SelectItem(0);
                    break;

                case Keys.End:
                    if (e.Control)
                        ScrollToItem(ItemCount - 1);
                    else
                        SelectItem(ItemCount - 1);
                    break;

                case Keys.Enter:
                case Keys.Space:
                    if (ShowCheckBoxes)
                    {
                        if (SelectedItemIndexes.Count > 0)
                        {
                            var val = GetItemChecked(SelectedItemIndexes.First());
                            if (val)
                                UncheckSelected();
                            else
                                CheckSelected();
                        }
                    }
                    else
                    if (ShowExpandBoxes)
                    {
                        if (SelectedItemIndexes.Count > 0)
                        {
                            var itemIndex = SelectedItemIndexes.First();
                            if (GetItemExpanded(itemIndex))
                                CollapseItem(itemIndex);
                            else
                                ExpandItem(itemIndex);
                        }
                    }
                    break;

                case Keys.A:
                    if (e.Control)
                    {
                        SelectAll();
                    }
                    break;
            }
        }

        #endregion

        #region Dealyed Actions

        /// <summary>
        /// The delayed action timer
        /// </summary>
        private System.Threading.Timer delayedActionTimer;

        /// <summary>
        /// Creates the delayed action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="delayInterval">The delay interval.</param>
        protected void CreateDelayedAction(Action action, int delayInterval)
        {
            CancelDelayedAction();
            delayedActionTimer = new System.Threading.Timer((o) => this.Invoke(action), null, delayInterval, Timeout.Infinite);
        }

        /// <summary>
        /// Cancels the delayed action.
        /// </summary>
        protected void CancelDelayedAction()
        {
            if (delayedActionTimer != null)
            {
                delayedActionTimer.Change(Timeout.Infinite, Timeout.Infinite);
                delayedActionTimer.Dispose();
            }
            delayedActionTimer = null;
        }

        #endregion

        #region Mouse

        /// <summary>
        /// The start diapason selected item index
        /// </summary>
        private int startDiapasonSelectedItemIndex;
        /// <summary>
        /// The mouse can select area
        /// </summary>
        private bool mouseCanSelectArea;
        /// <summary>
        /// The start mouse select area
        /// </summary>
        private Point startMouseSelectArea;
        /// <summary>
        /// The mouse select area
        /// </summary>
        private Rectangle mouseSelectArea;
        /// <summary>
        /// The last mouse click
        /// </summary>
        private Point lastMouseClick;

        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            Focus();
            mouseCanSelectArea = false;
            mouseSelectArea = Rectangle.Empty;
            lastMouseClick = e.Location;
            CancelDelayedAction();

            var item = PointToItemInfo(e.Location);

            if (item == null)
                return;

            if (e.Button == MouseButtons.Left && item.X_Text <= e.Location.X)
                if (SelectedItemIndexes.Count == 1 && SelectedItemIndexes.Contains(item.ItemIndex))
                    if (!Readonly && CanEditItem(item.ItemIndex))
                    {
                        CreateDelayedAction(() => OnStartEdit(item.ItemIndex), 500);
                    }

            if (AllowSelectItems)
                if (e.Button == MouseButtons.Left && item.X_Icon <= e.Location.X)
                {
                    //Select
                    if (MultiSelect)
                    {
                        startMouseSelectArea = e.Location;
                        startMouseSelectArea.Offset(HorizontalScroll.Value, VerticalScroll.Value);
                        mouseCanSelectArea = item.X_EndText < e.Location.X || !AllowDragItems;
                    }

                    if (!AllowDragItems || !MultiSelect)
                        OnMouseSelectItem(e, item);
                }

            if (ShowCheckBoxes && e.Button == MouseButtons.Left)
            {
                if ((item.X_CheckBox <= e.Location.X && item.X_Icon > e.Location.X) || (!AllowSelectItems))
                {
                    //Checkbox
                    OnCheckboxClick(item);
                    Invalidate();
                }
            }

            if (ShowExpandBoxes)
                if (e.Button == MouseButtons.Left && item.X_ExpandBox <= e.Location.X && item.X_CheckBox > e.Location.X)
                {
                    //Expand
                    OnExpandBoxClick(item);
                    Invalidate();
                }
        }

        /// <summary>
        /// Called when [mouse select item].
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        /// <param name="item">The item.</param>
        protected virtual void OnMouseSelectItem(MouseEventArgs e, VisibleItemInfo item)
        {
            if (MultiSelect)
            {
                startMouseSelectArea = e.Location;
                startMouseSelectArea.Offset(HorizontalScroll.Value, VerticalScroll.Value);
                mouseCanSelectArea = item.X_EndText < e.Location.X || !AllowDragItems;

                if (Control.ModifierKeys == Keys.Control)
                {
                    if (SelectedItemIndexes.Contains(item.ItemIndex) && SelectedItemIndexes.Count > 1)
                        UnselectItem(item.ItemIndex);
                    else
                        SelectItem(item.ItemIndex, false);

                    startDiapasonSelectedItemIndex = -1;
                }
                else if (Control.ModifierKeys == Keys.Shift)
                {
                    if (SelectedItemIndexes.Count == 1)
                        startDiapasonSelectedItemIndex = SelectedItemIndexes.First();

                    if (startDiapasonSelectedItemIndex >= 0)
                        SelectItems(Math.Min(startDiapasonSelectedItemIndex, item.ItemIndex),
                                    Math.Max(startDiapasonSelectedItemIndex, item.ItemIndex));
                }
            }

            if (!MultiSelect || Control.ModifierKeys == Keys.None)
                if (!SelectedItemIndexes.Contains(item.ItemIndex) || SelectedItemIndexes.Count > 1)
                    SelectItem(item.ItemIndex, true);

            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button != MouseButtons.None)
                CancelDelayedAction();

            if (e.Button == MouseButtons.Left && mouseCanSelectArea)
            {
                if (Math.Abs(e.Location.X - startMouseSelectArea.X) > 0)
                {
                    var pos = e.Location;
                    pos.Offset(HorizontalScroll.Value, VerticalScroll.Value);
                    mouseSelectArea = new Rectangle(Math.Min(startMouseSelectArea.X, pos.X), Math.Min(startMouseSelectArea.Y, pos.Y), Math.Abs(startMouseSelectArea.X - pos.X), Math.Abs(startMouseSelectArea.Y - pos.Y));

                    var i1 = YToIndex(startMouseSelectArea.Y);
                    var i2 = YToIndex(pos.Y);
                    if (i1 >= 0 && i2 >= 0)
                    {
                        SelectItems(Math.Min(i1, i2), Math.Max(i1, i2));
                    }

                    if (e.Location.Y <= Padding.Top + ItemHeightDefault / 2)
                        ScrollUp();
                    else
                    if (e.Location.Y >= ClientSize.Height - Padding.Bottom - +ItemHeightDefault / 2)
                        ScrollDown();

                    Invalidate();
                }
                else
                    mouseSelectArea = Rectangle.Empty;
            }
            else
            if (e.Button == System.Windows.Forms.MouseButtons.Left && AllowDragItems && (Math.Abs(lastMouseClick.X - e.Location.X) > 2 || Math.Abs(lastMouseClick.Y - e.Location.Y) > 2))
            {
                var p = PointToClient(MousePosition);
                var info = PointToItemInfo(p);
                if (info != null)
                {
                    if (!SelectedItemIndexes.Contains(info.ItemIndex))
                        SelectItem(info.ItemIndex);
                    OnItemDrag(new HashSet<int>(SelectedItemIndexes));
                }
            }
            else
            if (e.Button == System.Windows.Forms.MouseButtons.None)
            {
                var p = PointToClient(MousePosition);
                var info = PointToItemInfo(p);

                if (HotTracking)
                {
                    var i = -1;
                    if (info != null)
                        i = info.ItemIndex;

                    if (currentHotTrackingIndex != i)
                    {
                        currentHotTrackingIndex = i;
                        Invalidate();
                    }
                }

                if (info != null && info.X_EndText == info.X_End)
                {
                    if (tt.Tag != info.Text && ShowToolTips)
                        tt.Show(info.Text, this, info.X_Text - 3, info.Y - 2, 2000);
                    tt.Tag = info.Text;
                }
                else
                {
                    tt.Tag = null;
                    tt.Hide(this);
                }
            }
        }

        /// <summary>
        /// Called when [item drag].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected virtual void OnItemDrag(HashSet<int> itemIndex)
        {
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            var item = PointToItemInfo(e.Location);

            if (item != null)
                if (AllowSelectItems)
                    if (e.Button == MouseButtons.Left && item.X_Icon <= e.Location.X)
                    {
                        if (AllowDragItems && MultiSelect && mouseSelectArea == Rectangle.Empty)
                            OnMouseSelectItem(e, item);
                    }

            mouseCanSelectArea = false;

            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDoubleClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            CancelDelayedAction();

            var item = PointToItemInfo(e.Location);

            if (item != null)
                if (e.Button == MouseButtons.Left && item.X_Icon <= e.Location.X)
                {
                    if (GetItemExpanded(item.ItemIndex))
                        CollapseItem(item.ItemIndex);
                    else
                        ExpandItem(item.ItemIndex);
                }
        }

        #endregion mouse

        #region Check, Expand

        /// <summary>
        /// Called when [expand box click].
        /// </summary>
        /// <param name="info">The information.</param>
        protected virtual void OnExpandBoxClick(VisibleItemInfo info)
        {
            if (info.Expanded)
                CollapseItem(info.ItemIndex);
            else
                ExpandItem(info.ItemIndex);
        }

        /// <summary>
        /// Collapses the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool CollapseItem(int itemIndex)
        {
            Invalidate();

            if (CanCollapseItem(itemIndex))
            {
                OnItemCollapsed(itemIndex);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Expands the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool ExpandItem(int itemIndex)
        {
            Invalidate();

            if (CanExpandItem(itemIndex))
            {
                OnItemExpanded(itemIndex);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Called when [item collapsed].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected virtual void OnItemCollapsed(int itemIndex)
        {
        }

        /// <summary>
        /// Called when [item expanded].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected virtual void OnItemExpanded(int itemIndex)
        {
        }


        /// <summary>
        /// Called when [checkbox click].
        /// </summary>
        /// <param name="info">The information.</param>
        protected virtual void OnCheckboxClick(VisibleItemInfo info)
        {
            if (GetItemChecked(info.ItemIndex))
                UncheckItem(info.ItemIndex);
            else
                CheckItem(info.ItemIndex);
        }

        /// <summary>
        /// Checks the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool CheckItem(int itemIndex)
        {
            if (GetItemChecked(itemIndex))
                return true;

            Invalidate();

            if (CanCheckItem(itemIndex))
            {
                CheckedItemIndex.Add(itemIndex);
                OnItemChecked(itemIndex);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks all.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool CheckAll()
        {
            var res = true;
            for (int i = 0; i < ItemCount; i++)
                res &= CheckItem(i);

            return res;
        }

        /// <summary>
        /// Unchecks the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool UncheckItem(int itemIndex)
        {
            if (!GetItemChecked(itemIndex))
                return true;

            Invalidate();

            if (CanUncheckItem(itemIndex))
            {
                CheckedItemIndex.Remove(itemIndex);
                OnItemUnchecked(itemIndex);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Unchecks all.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool UncheckAll()
        {
            foreach (var i in CheckedItemIndex)
                if (!CanUncheckItem(i))
                    return false;

            var list = new List<int>(CheckedItemIndex);

            CheckedItemIndex.Clear();

            foreach (var i in list)
                OnItemUnchecked(i);

            Invalidate();

            return true;
        }

        /// <summary>
        /// Called when [item checked].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected virtual void OnItemChecked(int itemIndex)
        {
        }

        /// <summary>
        /// Called when [item unchecked].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected virtual void OnItemUnchecked(int itemIndex)
        {
        }

        /// <summary>
        /// Checks the selected.
        /// </summary>
        protected virtual void CheckSelected()
        {
            foreach (var i in SelectedItemIndexes)
                CheckItem(i);
        }

        /// <summary>
        /// Unchecks the selected.
        /// </summary>
        protected virtual void UncheckSelected()
        {
            foreach (var i in SelectedItemIndexes)
                UncheckItem(i);
        }

        #endregion Check, Expand

        #region Selection

        /// <summary>
        /// Unselects the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool UnselectItem(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex >= ItemCount)
                return false;

            if (!SelectedItemIndexes.Contains(itemIndex))
                return true;

            if (!CanUnselectItem(itemIndex))
                return false;

            SelectedItemIndexes.Remove(itemIndex);
            OnItemUnselected(itemIndex);

            return true;
        }

        /// <summary>
        /// Unselects all.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool UnselectAll()
        {
            foreach (var i in SelectedItemIndexes)
                if (!CanUnselectItem(i))
                    return false;

            var list = new List<int>(SelectedItemIndexes);

            SelectedItemIndexes.Clear();

            foreach (var i in list)
                OnItemUnselected(i);

            Invalidate();

            return true;
        }

        /// <summary>
        /// Selects the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="unselectOtherItems">if set to <c>true</c> [unselect other items].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool SelectItem(int itemIndex, bool unselectOtherItems = true)
        {
            if (itemIndex < 0 || itemIndex >= ItemCount)
                return false;

            if (!CanSelectItem(itemIndex))
                return false;

            var contains = SelectedItemIndexes.Contains(itemIndex);

            if (unselectOtherItems)
            {
                foreach (var i in SelectedItemIndexes)
                    if (i != itemIndex)
                        if (!CanUnselectItem(i))
                            return false;

                var list = new List<int>(SelectedItemIndexes);

                //SelectedItemIndexes.Clear();

                foreach (var i in list)
                    if (i != itemIndex)
                    {
                        SelectedItemIndexes.Remove(i);
                        OnItemUnselected(i);
                    }
            }

            SelectedItemIndexes.Add(itemIndex);

            if (!contains)
                OnItemSelected(itemIndex);

            ScrollToItem(itemIndex);

            return true;
        }

        /// <summary>
        /// Selects the items.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool SelectItems(int from, int to)
        {
            foreach (var i in SelectedItemIndexes)
                if (i < from || i > to)
                    if (!CanUnselectItem(i))
                        return false;

            var list = new List<int>(SelectedItemIndexes);

            //SelectedItemIndexes.RemoveWhere(i=> i < from | i > to);

            foreach (var i in list)
                if (i < from || i > to)
                {
                    SelectedItemIndexes.Remove(i);
                    OnItemUnselected(i);
                }

            for (int i = from; i <= to; i++)
                if (!SelectedItemIndexes.Contains(i))
                    if (CanSelectItem(i))
                    {
                        SelectedItemIndexes.Add(i);
                        OnItemSelected(i);
                    }

            Invalidate();

            return SelectedItemIndexes.Count > 0;
        }

        /// <summary>
        /// Selects all.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool SelectAll()
        {
            return SelectItems(0, ItemCount - 1);
        }

        /// <summary>
        /// Selects the next.
        /// </summary>
        /// <param name="unselectOtherItems">if set to <c>true</c> [unselect other items].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SelectNext(bool unselectOtherItems = true)
        {
            if (SelectedItemIndexes.Count == 0)
                return false;

            var index = SelectedItemIndexes.Max() + 1;
            if (index >= ItemCount)
                return false;

            var res = SelectItem(index, unselectOtherItems);
            if (res)
                ScrollToItem(index);

            return res;
        }

        /// <summary>
        /// Selects the previous.
        /// </summary>
        /// <param name="unselectOtherItems">if set to <c>true</c> [unselect other items].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SelectPrev(bool unselectOtherItems = true)
        {
            if (SelectedItemIndexes.Count == 0)
                return false;

            var index = SelectedItemIndexes.Min() - 1;
            if (index < 0)
                return false;

            var res = SelectItem(index, unselectOtherItems);
            if (res)
                ScrollToItem(index);

            return res;
        }

        /// <summary>
        /// Called when [item selected].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected virtual void OnItemSelected(int itemIndex)
        {
        }

        /// <summary>
        /// Called when [item unselected].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected virtual void OnItemUnselected(int itemIndex)
        {
        }

        #endregion

        #region Paint

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //was build request
            if (buildNeeded)
            {
                Build();
                buildNeeded = false;
            }
            //
            e.Graphics.SetClip(ClientRectMinusPaddings);
            DrawItems(e.Graphics);

            if (lastDragAndDropEffect == null)
                DrawMouseSelectedArea(e.Graphics);
            else
                DrawDragOverInsertEffect(e.Graphics, lastDragAndDropEffect);

            base.OnPaint(e);

            if (!Enabled)
            {
                e.Graphics.SetClip(ClientRectangle);
                var color = Color.FromArgb(50, (BackColor.R + 127) >> 1, (BackColor.G + 127) >> 1, (BackColor.B + 127) >> 1);
                using (var brush = new SolidBrush(color))
                    e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }

        /// <summary>
        /// Draws the drag over insert effect.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="e">The <see cref="DragOverItemEventArgs"/> instance containing the event data.</param>
        protected virtual void DrawDragOverInsertEffect(Graphics gr, DragOverItemEventArgs e)
        {
            var c1 = Color.FromArgb(SelectionColor.A == 255 ? SelectionColorOpaque : SelectionColor.A, SelectionColor);
            var c2 = Color.Transparent;

            if (!visibleItemInfos.ContainsKey(e.ItemIndex))
                return;
            var info = visibleItemInfos[e.ItemIndex];
            var rect = new Rectangle(info.X_ExpandBox, info.Y, 1000, info.Height);

            switch (e.InsertEffect)
            {
                case InsertEffect.Replace:
                    using (var brush = new SolidBrush(c1))
                        gr.FillRectangle(brush, rect);
                    break;

                case InsertEffect.InsertBefore:
                    if (e.ItemIndex <= 0)
                        rect.Offset(0, 2);
                    using (var pen = new Pen(c1, 2) { DashStyle = DashStyle.Dash })
                        gr.DrawLine(pen, rect.Left, rect.Top, rect.Right, rect.Top);
                    break;

                case InsertEffect.InsertAfter:
                    if (e.ItemIndex < 0)
                        rect.Offset(0, 2);
                    using (var pen = new Pen(c1, 2) { DashStyle = DashStyle.Dash })
                        gr.DrawLine(pen, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                    break;

                case InsertEffect.AddAsChild:
                    if (e.ItemIndex >= 0 && e.ItemIndex < ItemCount)
                    {
                        var dx = GetItemIndent(e.ItemIndex) + 80;
                        rect.Offset(dx, 0);
                        using (var pen = new Pen(c1, 2) { DashStyle = DashStyle.Dash })
                            gr.DrawLine(pen, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
                    }
                    break;
            }
        }

        /// <summary>
        /// Draws the mouse selected area.
        /// </summary>
        /// <param name="gr">The gr.</param>
        private void DrawMouseSelectedArea(Graphics gr)
        {
            if (mouseCanSelectArea && mouseSelectArea != Rectangle.Empty)
            {
                var c = Color.FromArgb(SelectionColor.A == 255 ? SelectionColorOpaque : SelectionColor.A, SelectionColor);
                var rect = new Rectangle(mouseSelectArea.Left - HorizontalScroll.Value, mouseSelectArea.Top - VerticalScroll.Value, mouseSelectArea.Width, mouseSelectArea.Height);
                using (var pen = new Pen(c))
                    gr.DrawRectangle(pen, rect);
            }

        }

        /// <summary>
        /// Draws the items.
        /// </summary>
        /// <param name="gr">The gr.</param>
        protected virtual void DrawItems(Graphics gr)
        {
            var i = Math.Max(0, PointToIndex(new Point(Padding.Left, Padding.Top)) - 1);

            visibleItemInfos.Clear();

            for (; i < ItemCount; i++)
            {
                var info = visibleItemInfos[i] = CalcVisibleItemInfo(gr, i);
                if (info.Y > ClientSize.Height)
                    break;

                DrawItem(gr, info);
            }
        }

        /// <summary>
        /// The visible item infos
        /// </summary>
        protected readonly Dictionary<int, VisibleItemInfo> visibleItemInfos = new Dictionary<int, VisibleItemInfo>();

        /// <summary>
        /// Draws the item.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="info">The information.</param>
        protected virtual void DrawItem(Graphics gr, VisibleItemInfo info)
        {
            DrawItemWhole(gr, info);
        }

        /// <summary>
        /// Draws the item whole.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="info">The information.</param>
        public void DrawItemWhole(Graphics gr, VisibleItemInfo info)
        {
            DrawItemBackgound(gr, info);

            if (lastDragAndDropEffect == null) //do not draw selection when drag&drop over the control
                if (!IsEditMode)//do not draw selection when edit mode
                    if (SelectedItemIndexes.Contains(info.ItemIndex))
                        DrawSelection(gr, info);

            if (HotTracking && info.ItemIndex == currentHotTrackingIndex)
                DrawItemHotTracking(gr, info);


            DrawItemIcons(gr, info);
            DrawItemContent(gr, info);
        }

        /// <summary>
        /// Draws the item hot tracking.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="info">The information.</param>
        protected virtual void DrawItemHotTracking(Graphics gr, VisibleItemInfo info)
        {
            var c1 = HotTrackingColor;
            var rect = info.TextAndIconRect;

            if (FullItemSelect)
            {
                var cr = ClientRectMinusPaddings;
                rect = new Rectangle(cr.Left, rect.Top, cr.Width - 1, rect.Height);
            }

            if (rect.Width > 0 && rect.Height > 0)
                using (var pen = new Pen(c1))
                    gr.DrawRectangle(pen, rect);
        }

        /// <summary>
        /// Gets the client rect minus paddings.
        /// </summary>
        /// <value>The client rect minus paddings.</value>
        [Browsable(false)]
        public Rectangle ClientRectMinusPaddings
        {
            get
            {
                var rect = ClientRectangle;
                return new Rectangle(rect.Left + Padding.Left, rect.Top + Padding.Top,
                                     rect.Width - Padding.Left - Padding.Right,
                                     rect.Height - Padding.Top - Padding.Bottom);
            }
        }

        /// <summary>
        /// Draws the selection.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="info">The information.</param>
        public virtual void DrawSelection(Graphics gr, VisibleItemInfo info)
        {
            var c1 = Color.FromArgb(SelectionColor.A == 255 ? SelectionColorOpaque : SelectionColor.A, SelectionColor);
            var c2 = Color.FromArgb(c1.A / 2, SelectionColor);
            var rect = info.TextAndIconRect;

            if (FullItemSelect)
            {
                var cr = ClientRectMinusPaddings;
                rect = new Rectangle(cr.Left, rect.Top, cr.Width - 1, rect.Height);
            }

            if (rect.Width > 0 && rect.Height > 0)
                using (var brush = new LinearGradientBrush(rect, c2, c1, LinearGradientMode.Vertical))
                using (var pen = new Pen(c1))
                {
                    gr.FillRectangle(brush, Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right + 1, rect.Bottom + 1));
                    gr.DrawRectangle(pen, rect);
                }
        }

        /// <summary>
        /// Draws Expand box, Check box and Icon of the Item
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="info">The information.</param>
        public virtual void DrawItemIcons(Graphics gr, VisibleItemInfo info)
        {
            if (info.ExpandBoxType > 0)
            {
                var img = (Bitmap)(info.ExpandBoxType == 2 ? ImageEmptyExpand : (info.Expanded ? ImageCollapse : ImageExpand));
                if (img != null)
                {
                    img.SetResolution(gr.DpiX, gr.DpiY);
                    gr.DrawImage(img, info.X_ExpandBox, info.Y + 1);
                }
            }

            if (info.CheckBoxVisible)
            {
                var img = (Bitmap)(GetItemChecked(info.ItemIndex) ? ImageCheckBoxOn : ImageCheckBoxOff);
                if (img != null)
                {
                    img.SetResolution(gr.DpiX, gr.DpiY);
                    gr.DrawImage(img, info.X_CheckBox, info.Y + 1);
                }
            }

            if (ShowIcons && info.Icon != null)
            {
                var img = (Bitmap)info.Icon;
                if (img != null)
                {
                    img.SetResolution(gr.DpiX, gr.DpiY);
                    gr.DrawImage(img, info.X_Icon, info.Y + 1);
                }
            }
        }

        /// <summary>
        /// Draws the content of the item.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="info">The information.</param>
        public virtual void DrawItemContent(Graphics gr, VisibleItemInfo info)
        {
            using(var sf  = new StringFormat() { LineAlignment = info.LineAlignment })
            using (var brush = new SolidBrush(info.ForeColor))
            {
                var rect = new Rectangle(info.X_Text, info.Y + 1, info.X_EndText - info.X_Text + 1, info.Height - 1);
                //gr.DrawString(info.Text, Font, brush, info.X_Text, info.Y + 1, sf);
                gr.DrawString(info.Text, Font, brush, rect, sf);
            }
        }

        /// <summary>
        /// Draws the item backgound.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="info">The information.</param>
        public virtual void DrawItemBackgound(Graphics gr, VisibleItemInfo info)
        {
            var backColor = info.BackColor;

            if (backColor != Color.Empty)
                using (var brush = new SolidBrush(backColor))
                    gr.FillRectangle(brush, info.TextAndIconRect);
        }

        /// <summary>
        /// Calculates the visible item information.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>VisibleItemInfo.</returns>
        protected virtual VisibleItemInfo CalcVisibleItemInfo(Graphics gr, int itemIndex)
        {
            var result = new VisibleItemInfo();
            result.Calc(this, itemIndex, gr);
            return result;
        }

        #endregion

        #region Coordinates

        /// <summary>
        /// Gets a value indicating whether this instance is item height fixed.
        /// </summary>
        /// <value><c>true</c> if this instance is item height fixed; otherwise, <c>false</c>.</value>
        protected virtual bool IsItemHeightFixed
        {
            get { return true; }
        }

        /// <summary>
        /// Absolute Y coordinate of the control to item index
        /// </summary>
        /// <param name="y">The y.</param>
        /// <returns>System.Int32.</returns>
        public int YToIndex(int y)
        {
            if (y < Padding.Top)
                return -1;

            if (ItemCount <= 0)
                return -1;

            int i = 0;

            if (IsItemHeightFixed)
            {
                i = (y - Padding.Top) / (ItemHeightDefault + ItemInterval);
            }
            else
            {
                i = yOfItems.BinarySearch(y + 1);
                if (i < 0)
                {
                    i = ~i;
                    i -= 1;
                }
            }

            if (i >= ItemCount)
                return -1;

            return i;
        }

        /// <summary>
        /// Gets the item y.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>System.Int32.</returns>
        protected virtual int GetItemY(int index)
        {
            if (IsItemHeightFixed)
                return Padding.Top + index * (ItemHeightDefault + ItemInterval);
            else
                return yOfItems[index];
        }

        /// <summary>
        /// ies to index around.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <returns>System.Int32.</returns>
        protected int YToIndexAround(int y)
        {
            if (ItemCount <= 0)
                return -1;

            var i = 0;

            if (IsItemHeightFixed)
            {
                i = (y - Padding.Top) / (ItemHeightDefault + ItemInterval);
            }
            else
            {
                i = yOfItems.BinarySearch(y + 1);
                if (i < 0)
                {
                    i = ~i;
                    i -= 1;
                }
            }

            if (i < 0)
                i = 0;

            if (i >= ItemCount)
                i = ItemCount - 1;

            return i;
        }

        /// <summary>
        /// Control visible rect coordinates to item index
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns>System.Int32.</returns>
        public int PointToIndex(Point p)
        {
            if (p.X < Padding.Left || p.X > ClientRectangle.Right - Padding.Right)
                return -1;

            var y = p.Y + VerticalScroll.Value;

            return YToIndex(y);
        }

        /// <summary>
        /// Control visible rect coordinates to item info
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns>VisibleItemInfo.</returns>
        public virtual VisibleItemInfo PointToItemInfo(Point p)
        {
            var index = PointToIndex(p);
            VisibleItemInfo info = null;
            visibleItemInfos.TryGetValue(index, out info);

            return info;
        }

        /// <summary>
        /// x0  x1  x2  x3      x4     x5
        /// |   |   |   |       |      |
        /// □   □   □   ItemText
        /// </summary>
        public class VisibleItemInfo
        {
            /// <summary>
            /// The item index
            /// </summary>
            public int ItemIndex;
            /// <summary>
            /// The y
            /// </summary>
            public int Y;
            /// <summary>
            /// The height
            /// </summary>
            public int Height;
            /// <summary>
            /// The text
            /// </summary>
            public string Text;
            /// <summary>
            /// The x
            /// </summary>
            public int X;
            /// <summary>
            /// The x expand box
            /// </summary>
            public int X_ExpandBox;
            /// <summary>
            /// The x CheckBox
            /// </summary>
            public int X_CheckBox;
            /// <summary>
            /// The x icon
            /// </summary>
            public int X_Icon;
            /// <summary>
            /// The x text
            /// </summary>
            public int X_Text;
            /// <summary>
            /// The x end text
            /// </summary>
            public int X_EndText;
            /// <summary>
            /// The x end
            /// </summary>
            public int X_End;
            /// <summary>
            /// The CheckBox visible
            /// </summary>
            public bool CheckBoxVisible;
            /// <summary>
            /// The expand box type
            /// </summary>
            public int ExpandBoxType;
            /// <summary>
            /// The icon
            /// </summary>
            public Image Icon;
            /// <summary>
            /// The expanded
            /// </summary>
            public bool Expanded;
            /// <summary>
            /// The fore color
            /// </summary>
            public Color ForeColor;
            /// <summary>
            /// The back color
            /// </summary>
            public Color BackColor;
            /// <summary>
            /// The line alignment
            /// </summary>
            public StringAlignment LineAlignment = StringAlignment.Near;

            /// <summary>
            /// Gets the full rect.
            /// </summary>
            /// <value>The full rect.</value>
            public Rectangle FullRect
            {
                get { return new Rectangle(X, Y, X_End - X + 1, Height); }
            }

            /// <summary>
            /// Gets the rect.
            /// </summary>
            /// <value>The rect.</value>
            public Rectangle Rect
            {
                get { return new Rectangle(X_ExpandBox, Y, X_EndText - X + 1, Height); }
            }

            /// <summary>
            /// Gets the text and icon rect.
            /// </summary>
            /// <value>The text and icon rect.</value>
            public Rectangle TextAndIconRect
            {
                get { return new Rectangle(X_Icon, Y, X_EndText - X_Icon + 1, Height); }
            }

            /// <summary>
            /// Gets the text rect.
            /// </summary>
            /// <value>The text rect.</value>
            public Rectangle TextRect
            {
                get { return new Rectangle(X_Text, Y, X_EndText - X_Text + 1, Height); }
            }

            /// <summary>
            /// Calculates the specified list.
            /// </summary>
            /// <param name="list">The list.</param>
            /// <param name="itemIndex">Index of the item.</param>
            /// <param name="gr">The gr.</param>
            public virtual void Calc(ZeroitFastListBase list, int itemIndex, Graphics gr)
            {
                //var vertScroll = list.VerticalScroll.Visible ? list.VerticalScroll.Value : 0;
                var vertScroll = list.VerticalScroll.Value;//!!!!!!!!!!!!

                ItemIndex = itemIndex;
                CheckBoxVisible = list.ShowCheckBoxes && list.GetItemCheckBoxVisible(itemIndex);
                Icon = list.GetItemIcon(itemIndex);
                LineAlignment = list.GetItemLineAlignment(itemIndex);
                var y = list.GetItemY(itemIndex);
                Y = y - vertScroll;
                Height = list.GetItemY(itemIndex + 1) - y - list.ItemInterval;
                Text = list.GetItemText(itemIndex) ?? "";
                Expanded = list.GetItemExpanded(itemIndex);
                var temp = list.ShowEmptyExpandBoxes ? 2 : 0;
                ExpandBoxType = list.ShowExpandBoxes ? (Expanded ? (list.CanCollapseItem(itemIndex) ? 1 : temp) : (list.CanExpandItem(itemIndex) ? 1 : temp)) : 0;
                BackColor = list.GetItemBackColor(itemIndex);
                ForeColor = list.GetItemForeColor(itemIndex);

                X = list.Padding.Left;
                var x = list.GetItemIndent(itemIndex) + list.Padding.Left;
                X_ExpandBox = x;
                if (list.ShowExpandBoxes) x += list.ImageExpand.Width + 2;
                X_CheckBox = x;
                if (list.ShowCheckBoxes) x += list.ImageCheckBoxOn.Width + 2;
                X_Icon = x;
                if (list.ShowIcons) x += list.IconSize.Width + 2;
                X_Text = x;
                x += (int)gr.MeasureString(Text, list.Font).Width + 1;
                X_End = list.ClientSize.Width - list.Padding.Right - 2;
                X_EndText = Math.Min(x, X_End);
            }
        }

        #endregion

        #region Build

        /// <summary>
        /// Builds this instance.
        /// </summary>
        protected virtual void Build()
        {
            yOfItems.Clear();

            int y = Padding.Top;

            if (!IsItemHeightFixed)
            {
                for (int i = 0; i < itemCount; i++)
                {
                    yOfItems.Add(y);
                    y += GetItemHeight(i) + ItemInterval;
                }

                yOfItems.Add(y);
            }
            else
            {
                y += itemCount * (ItemHeightDefault + ItemInterval);
            }


            SelectedItemIndexes.RemoveWhere(i => i >= itemCount);
            CheckedItemIndex.RemoveWhere(i => i >= itemCount);

            AutoScrollMinSize = new Size(AutoScrollMinSize.Width, y + Padding.Bottom + 2);
            Invalidate();
        }

        /// <summary>
        /// The build needed
        /// </summary>
        bool buildNeeded;

        /// <summary>
        /// Builds the needed.
        /// </summary>
        public virtual void BuildNeeded()
        {
            buildNeeded = true;
        }

        #endregion

        #region Get item info methods

        /// <summary>
        /// Gets the height of the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>System.Int32.</returns>
        protected virtual int GetItemHeight(int itemIndex)
        {
            return ItemHeightDefault;
        }

        /// <summary>
        /// Gets the item indent.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>System.Int32.</returns>
        public virtual int GetItemIndent(int itemIndex)
        {
            return ItemIndentDefault;
        }

        /// <summary>
        /// Gets the item text.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>System.String.</returns>
        protected virtual string GetItemText(int itemIndex)
        {
            return string.Empty;
        }

        /// <summary>
        /// Called when [item text pushed].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="text">The text.</param>
        protected virtual void OnItemTextPushed(int itemIndex, string text)
        {
            Invalidate();
        }

        /// <summary>
        /// Gets the item CheckBox visible.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected virtual bool GetItemCheckBoxVisible(int itemIndex)
        {
            return ShowCheckBoxes;
        }

        /// <summary>
        /// Gets the item checked.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected virtual bool GetItemChecked(int itemIndex)
        {
            return CheckedItemIndex.Contains(itemIndex);
        }

        /// <summary>
        /// Gets the item icon.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>Image.</returns>
        protected virtual Image GetItemIcon(int itemIndex)
        {
            return null;
        }

        /// <summary>
        /// Gets the item line alignment.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>StringAlignment.</returns>
        protected virtual StringAlignment GetItemLineAlignment(int itemIndex)
        {
            return StringAlignment.Near;
        }

        /// <summary>
        /// Gets the color of the item back.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>Color.</returns>
        protected virtual Color GetItemBackColor(int itemIndex)
        {
            return Color.Empty;
        }

        /// <summary>
        /// Gets the color of the item fore.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>Color.</returns>
        protected virtual Color GetItemForeColor(int itemIndex)
        {
            return ForeColor;
        }

        /// <summary>
        /// Gets the item expanded.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected virtual bool GetItemExpanded(int itemIndex)
        {
            return false;
        }

        /// <summary>
        /// Determines whether this instance [can unselect item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can unselect item] the specified item index; otherwise, <c>false</c>.</returns>
        protected virtual bool CanUnselectItem(int itemIndex)
        {
            return true;
        }

        /// <summary>
        /// Determines whether this instance [can select item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can select item] the specified item index; otherwise, <c>false</c>.</returns>
        protected virtual bool CanSelectItem(int itemIndex)
        {
            return AllowSelectItems;
        }

        /// <summary>
        /// Determines whether this instance [can uncheck item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can uncheck item] the specified item index; otherwise, <c>false</c>.</returns>
        protected virtual bool CanUncheckItem(int itemIndex)
        {
            return true;
        }

        /// <summary>
        /// Determines whether this instance [can check item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can check item] the specified item index; otherwise, <c>false</c>.</returns>
        protected virtual bool CanCheckItem(int itemIndex)
        {
            return true;
        }

        /// <summary>
        /// Determines whether this instance [can expand item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can expand item] the specified item index; otherwise, <c>false</c>.</returns>
        protected virtual bool CanExpandItem(int itemIndex)
        {
            return true;
        }

        /// <summary>
        /// Determines whether this instance [can collapse item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can collapse item] the specified item index; otherwise, <c>false</c>.</returns>
        protected virtual bool CanCollapseItem(int itemIndex)
        {
            return true;
        }

        /// <summary>
        /// Determines whether this instance [can edit item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can edit item] the specified item index; otherwise, <c>false</c>.</returns>
        protected virtual bool CanEditItem(int itemIndex)
        {
            return true;
        }

        #endregion

        #region Scroll

        /// <summary>
        /// Scrolls up.
        /// </summary>
        protected virtual void ScrollUp()
        {
            OnScrollVertical(VerticalScroll.Value - VerticalScroll.SmallChange);
        }

        /// <summary>
        /// Scrolls down.
        /// </summary>
        protected virtual void ScrollDown()
        {
            OnScrollVertical(VerticalScroll.Value + VerticalScroll.SmallChange);
        }

        /// <summary>
        /// Scrolls the page up.
        /// </summary>
        protected virtual void ScrollPageUp()
        {
            OnScrollVertical(VerticalScroll.Value - VerticalScroll.LargeChange);
        }

        /// <summary>
        /// Scrolls the page down.
        /// </summary>
        protected virtual void ScrollPageDown()
        {
            OnScrollVertical(VerticalScroll.Value + VerticalScroll.LargeChange);
        }

        /// <summary>
        /// Gets or sets the minimum size of the auto-scroll.
        /// </summary>
        /// <value>The minimum size of the automatic scroll.</value>
        public new Size AutoScrollMinSize
        {
            set
            {
                if (showScrollBar)
                {
                    if (!base.AutoScroll)
                        base.AutoScroll = true;
                    Size newSize = value;
                    base.AutoScrollMinSize = newSize;
                }
                else
                {
                    if (base.AutoScroll)
                        base.AutoScroll = false;
                    base.AutoScrollMinSize = new Size(0, 0);
                    VerticalScroll.Visible = false;
                    HorizontalScroll.Visible = false;
                    VerticalScroll.Maximum = Math.Max(0, value.Height - ClientSize.Height);
                    HorizontalScroll.Maximum = Math.Max(0, value.Width - ClientSize.Width);
                    localAutoScrollMinSize = value;
                }
            }

            get
            {
                if (showScrollBar)
                    return base.AutoScrollMinSize;
                else
                    return localAutoScrollMinSize;
            }
        }

        /// <summary>
        /// Updates scrollbar position after Value changed
        /// </summary>
        public void UpdateScrollbars()
        {
            if (ShowScrollBar)
            {
                //some magic for update scrolls
                base.AutoScrollMinSize -= new Size(1, 0);
                base.AutoScrollMinSize += new Size(1, 0);
            }
            else
                AutoScrollMinSize = AutoScrollMinSize;

            if (IsHandleCreated)
                BeginInvoke((MethodInvoker)OnScrollbarsUpdated);
        }

        /// <summary>
        /// Called when [scrollbars updated].
        /// </summary>
        protected virtual void OnScrollbarsUpdated()
        {
        }

        /// <summary>
        /// The wm hscroll
        /// </summary>
        private const int WM_HSCROLL = 0x114;
        /// <summary>
        /// The wm vscroll
        /// </summary>
        private const int WM_VSCROLL = 0x115;
        /// <summary>
        /// The sb endscroll
        /// </summary>
        private const int SB_ENDSCROLL = 0x8;
        /// <summary>
        /// The wm mousewheel
        /// </summary>
        private const int WM_MOUSEWHEEL = 0x20A;

        /// <summary>
        /// WNDs the proc.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HSCROLL || m.Msg == WM_VSCROLL)
                if (m.WParam.ToInt32() != SB_ENDSCROLL)
                {
                    Focus();
                    Invalidate();
                }
            if (m.Msg == WM_MOUSEWHEEL)
            {
                //var step = 3 * ItemHeightDefault * Math.Sign(-m.WParam.ToInt64());
                var step = -3 * ItemHeightDefault * Math.Sign((short) (m.WParam.ToInt64() >> 16));
                if(VerticalScroll.Visible)
                    OnScroll(new ScrollEventArgs(ScrollEventType.ThumbPosition, VerticalScroll.Value + step, ScrollOrientation.VerticalScroll));
                Focus();
                return;
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// Scrolls to rectangle.
        /// </summary>
        /// <param name="rect">The rect.</param>
        public void ScrollToRectangle(Rectangle rect)
        {
            rect = new Rectangle(rect.X - HorizontalScroll.Value, rect.Y - VerticalScroll.Value, rect.Width, rect.Height);

            int v = VerticalScroll.Value;
            int h = HorizontalScroll.Value;

            if (rect.Bottom > ClientRectangle.Height)
                v += rect.Bottom - ClientRectangle.Height;
            else if (rect.Top < Padding.Top)
                v += rect.Top - Padding.Top;

            if (rect.Right > ClientRectangle.Width)
                h += rect.Right - ClientRectangle.Width;
            else if (rect.Left < Padding.Left)
                h += rect.Left - Padding.Left;
            //
            v = Math.Max(VerticalScroll.Minimum, v);
            h = Math.Max(HorizontalScroll.Minimum, h);
            //
            try
            {
                OnScrollVertical(v);
            }
            catch (ArgumentOutOfRangeException)
            {
                ;
            }
        }

        /// <summary>
        /// Scrolls to item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        public void ScrollToItem(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex >= ItemCount)
                return;

            var y = GetItemY(itemIndex);
            var height = GetItemHeight(itemIndex);
            ScrollToRectangle(new Rectangle(0, y, ClientRectangle.Width, height));
        }

        /// <summary>
        /// Called when [scroll vertical].
        /// </summary>
        /// <param name="newVerticalScrollBarValue">The new vertical scroll bar value.</param>
        public void OnScrollVertical(int newVerticalScrollBarValue)
        {
            OnScroll(new ScrollEventArgs(ScrollEventType.ThumbPosition, newVerticalScrollBarValue, ScrollOrientation.VerticalScroll));
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ScrollableControl.Scroll" /> event.
        /// </summary>
        /// <param name="se">A <see cref="T:System.Windows.Forms.ScrollEventArgs" /> that contains the event data.</param>
        protected override void OnScroll(ScrollEventArgs se)
        {
            if (se.ScrollOrientation == ScrollOrientation.VerticalScroll)
                VerticalScroll.Value = Math.Max(VerticalScroll.Minimum, Math.Min(VerticalScroll.Maximum, se.NewValue));

            UpdateScrollbars();
            Invalidate();
            //
            base.OnScroll(se);
        }

        #endregion

        #region Edit

        /// <summary>
        /// The edit item index
        /// </summary>
        protected int EditItemIndex;
        /// <summary>
        /// The edit control
        /// </summary>
        protected Control EditControl;
        /// <summary>
        /// The edit updating
        /// </summary>
        protected int editUpdating = 0;

        /// <summary>
        /// Called when [start edit].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="startValue">The start value.</param>
        public virtual void OnStartEdit(int itemIndex, string startValue = null)
        {
            if (!visibleItemInfos.ContainsKey(itemIndex))
                return;

            var info = visibleItemInfos[itemIndex];

            EditItemIndex = itemIndex;
            IsEditMode = true;
            var ctrl = new TextBox() { Text = GetItemText(itemIndex), AcceptsTab = true, Multiline = false, WordWrap = false };
            ctrl.Bounds = new Rectangle(info.X_Text, info.Y, info.X_End - info.X_Text, info.Height);
            ctrl.Parent = this;
            ctrl.Focus();
            if (startValue != null)
            {
                ctrl.Text = startValue;
                (ctrl as TextBox).SelectionStart = startValue.Length;
            }
            ctrl.LostFocus += (o, a) => OnEndEdit();
            ctrl.PreviewKeyDown += (o, a) => a.IsInputKey = true;
            ctrl.KeyDown += (o, a) =>
            {
                switch (a.KeyCode)
                {
                    case Keys.Escape: OnEndEdit(null); a.Handled = true; a.SuppressKeyPress = true; break;
                    case Keys.Enter: OnEndEdit(); a.Handled = true; a.SuppressKeyPress = true; break;
                }
            };
            EditControl = ctrl;
            Invalidate();
        }

        /// <summary>
        /// Called when [end edit].
        /// </summary>
        public virtual void OnEndEdit()
        {
            string val = null;

            if (EditControl != null)
                val = EditControl.Text;

            OnEndEdit(val);
        }

        /// <summary>
        /// Called when [end edit].
        /// </summary>
        /// <param name="newValue">The new value.</param>
        public virtual void OnEndEdit(string newValue)
        {
            if (editUpdating > 0)
                return;

            try
            {
                editUpdating++;

                if (newValue != null)
                    OnItemTextPushed(EditItemIndex, newValue);

                if (EditControl != null)
                    EditControl.Parent = null;

                EditControl = null;
                IsEditMode = false;
                //mouseCanSelect = false;
                Invalidate();
            }
            finally
            {
                editUpdating--;
            }
        }

        #endregion

        #region Routines

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        #endregion

        #region ISupportInitialize

        /// <summary>
        /// The is initializing
        /// </summary>
        protected bool IsInitializing;

        /// <summary>
        /// Begins the initialize.
        /// </summary>
        public void BeginInit()
        {
            IsInitializing = true;
        }

        /// <summary>
        /// Ends the initialize.
        /// </summary>
        public void EndInit()
        {
            IsInitializing = false;
            ItemCount = ItemCount;
        }

        #endregion ISupportInitialize
    }

    /// <summary>
    /// Class DragOverItemEventArgs.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.DragEventArgs" />
    public class DragOverItemEventArgs : DragEventArgs
    {
        /// <summary>
        /// Gets or sets the index of the item.
        /// </summary>
        /// <value>The index of the item.</value>
        public int ItemIndex { get; set; }
        /// <summary>
        /// Gets or sets the insert effect.
        /// </summary>
        /// <value>The insert effect.</value>
        public InsertEffect InsertEffect { get; set; }
        /// <summary>
        /// Gets the item rect.
        /// </summary>
        /// <value>The item rect.</value>
        public Rectangle ItemRect { get; private set; }
        /// <summary>
        /// Gets the text rect.
        /// </summary>
        /// <value>The text rect.</value>
        public Rectangle TextRect { get; private set; }
        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        public object Tag { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DragOverItemEventArgs"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="keyState">State of the key.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="allowedEffects">The allowed effects.</param>
        /// <param name="effect">The effect.</param>
        /// <param name="itemRect">The item rect.</param>
        /// <param name="textRect">The text rect.</param>
        public DragOverItemEventArgs(IDataObject data, int keyState, int x, int y, DragDropEffects allowedEffects, DragDropEffects effect, Rectangle itemRect, Rectangle textRect)
            : base(data, keyState, x, y, allowedEffects, effect)
        {
            this.ItemRect = itemRect;
            this.TextRect = textRect;
        }
    }

    /// <summary>
    /// Enum InsertEffect
    /// </summary>
    public enum InsertEffect
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The insert before
        /// </summary>
        InsertBefore,
        /// <summary>
        /// The insert after
        /// </summary>
        InsertAfter,
        /// <summary>
        /// The replace
        /// </summary>
        Replace,
        /// <summary>
        /// The add as child
        /// </summary>
        AddAsChild
    }
}
