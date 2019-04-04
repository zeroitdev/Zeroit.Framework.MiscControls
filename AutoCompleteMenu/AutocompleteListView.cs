// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-22-2018
// ***********************************************************************
// <copyright file="AutocompleteListView.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class AutocompleteListView.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    /// <seealso cref="Zeroit.Framework.MiscControls.IAutocompleteListView" />
    [System.ComponentModel.ToolboxItem(false)]
    public class AutocompleteListView : UserControl, IAutocompleteListView
    {
        /// <summary>
        /// The tool tip
        /// </summary>
        private readonly ToolTip toolTip = new ToolTip();
        /// <summary>
        /// Index of current selected item
        /// </summary>
        /// <value>The index of the highlighted item.</value>
        public int HighlightedItemIndex { get; set; }
        /// <summary>
        /// The old item count
        /// </summary>
        private int oldItemCount;
        /// <summary>
        /// The selected item index
        /// </summary>
        private int selectedItemIndex = -1;
        /// <summary>
        /// The visible items
        /// </summary>
        private IList<AutocompleteItem> visibleItems;

        /// <summary>
        /// Duration (ms) of tooltip showing
        /// </summary>
        /// <value>The duration of the tool tip.</value>
        public int ToolTipDuration { get; set; }

        /// <summary>
        /// Occurs when user selected item for inserting into text
        /// </summary>
        public event EventHandler ItemSelected;


        /// <summary>
        /// Occurs when current hovered item is changing
        /// </summary>
        public event EventHandler<HoveredEventArgs> ItemHovered;

        /// <summary>
        /// Colors
        /// </summary>
        /// <value>The colors.</value>
        public Colors Colors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteListView"/> class.
        /// </summary>
        internal AutocompleteListView()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            base.Font = new Font(FontFamily.GenericSansSerif, 9);
            ItemHeight = Font.Height + 2;
            VerticalScroll.SmallChange = ItemHeight;
            BackColor = Color.White;
            LeftPadding = 18;
            ToolTipDuration = 3000;
            Colors = new Colors();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                toolTip.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// The item height
        /// </summary>
        private int itemHeight;

        /// <summary>
        /// Gets or sets the height of the item.
        /// </summary>
        /// <value>The height of the item.</value>
        public int ItemHeight
        {
            get { return itemHeight; }
            set { 
                itemHeight = value;
                VerticalScroll.SmallChange = value;
                oldItemCount = -1;
                AdjustScroll();
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                ItemHeight = Font.Height + 2;
            }
        }

        /// <summary>
        /// Gets or sets the left padding.
        /// </summary>
        /// <value>The left padding.</value>
        public int LeftPadding { get; set; }

        /// <summary>
        /// Image list
        /// </summary>
        /// <value>The image list.</value>
        public ImageList ImageList { get; set; }

        /// <summary>
        /// List of visible elements
        /// </summary>
        /// <value>The visible items.</value>
        public IList<AutocompleteItem> VisibleItems
        {
            get { return visibleItems; }
            set
            {
                visibleItems = value;
                SelectedItemIndex = -1;
                AdjustScroll();
                Invalidate();
            }
        }

        /// <summary>
        /// Index of current selected item
        /// </summary>
        /// <value>The index of the selected item.</value>
        public int SelectedItemIndex
        {
            get { return selectedItemIndex; }
            set
            {
                AutocompleteItem item = null;
                if (value >= 0 && value < VisibleItems.Count)
                    item = VisibleItems[value];

                selectedItemIndex = value;

                OnItemHovered(new HoveredEventArgs() { Item = item });

                if (item != null)
                {
                    ShowToolTip(item);
                    ScrollToSelected();
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Handles the <see cref="E:ItemHovered" /> event.
        /// </summary>
        /// <param name="e">The <see cref="HoveredEventArgs"/> instance containing the event data.</param>
        private void OnItemHovered(HoveredEventArgs e)
        {
            if (ItemHovered != null)
                ItemHovered(this, e);
        }

        /// <summary>
        /// Adjusts the scroll.
        /// </summary>
        private void AdjustScroll()
        {
            if (VisibleItems == null)
                return;
            if (oldItemCount == VisibleItems.Count)
                return;

            int needHeight = ItemHeight*VisibleItems.Count + 1;
            Height = Math.Min(needHeight, MaximumSize.Height);
            AutoScrollMinSize = new Size(0, needHeight);
            oldItemCount = VisibleItems.Count;
        }


        /// <summary>
        /// Scrolls to selected.
        /// </summary>
        private void ScrollToSelected()
        {
            int y = SelectedItemIndex*ItemHeight - VerticalScroll.Value;
            if (y < 0)
                VerticalScroll.Value = SelectedItemIndex*ItemHeight;
            if (y > ClientSize.Height - ItemHeight)
                VerticalScroll.Value = Math.Min(VerticalScroll.Maximum,
                                                SelectedItemIndex*ItemHeight - ClientSize.Height + ItemHeight);
            //some magic for update scrolls
            AutoScrollMinSize -= new Size(1, 0);
            AutoScrollMinSize += new Size(1, 0);
        }

        /// <summary>
        /// Returns rectangle of item
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>Rectangle.</returns>
        public Rectangle GetItemRectangle(int itemIndex)
        {
            var y = itemIndex * ItemHeight - VerticalScroll.Value;
            return new Rectangle(0, y, ClientSize.Width - 1, ItemHeight - 1);
        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(Colors.BackColor);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            bool rtl = RightToLeft == RightToLeft.Yes;
            AdjustScroll();
            int startI = VerticalScroll.Value/ItemHeight - 1;
            int finishI = (VerticalScroll.Value + ClientSize.Height)/ItemHeight + 1;
            startI = Math.Max(startI, 0);
            finishI = Math.Min(finishI, VisibleItems.Count);
            int y = 0;

            for (int i = startI; i < finishI; i++)
            {
                y = i*ItemHeight - VerticalScroll.Value;

                if (ImageList != null && VisibleItems[i].ImageIndex >= 0)
                    if (rtl)
                        e.Graphics.DrawImage(ImageList.Images[VisibleItems[i].ImageIndex], Width - 1 - LeftPadding, y);
                    else
                        e.Graphics.DrawImage(ImageList.Images[VisibleItems[i].ImageIndex], 1, y);

                var textRect = new Rectangle(LeftPadding, y, ClientSize.Width - 1 - LeftPadding, ItemHeight - 1);
                if (rtl)
                    textRect = new Rectangle(1, y, ClientSize.Width - 1 - LeftPadding, ItemHeight - 1);

                if (i == SelectedItemIndex)
                {
                    Brush selectedBrush = new LinearGradientBrush(new Point(0, y - 3), new Point(0, y + ItemHeight),
                                                                  Colors.SelectedBackColor2, Colors.SelectedBackColor);
                    e.Graphics.FillRectangle(selectedBrush, textRect);
                    using(var pen = new Pen(Colors.SelectedBackColor2))
                        e.Graphics.DrawRectangle(pen, textRect);
                }

                if (i == HighlightedItemIndex)
                using (var pen = new Pen(Colors.HighlightingColor))
                    e.Graphics.DrawRectangle(pen, textRect);

                var sf = new StringFormat();
                if (rtl)
                    sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                var args = new PaintItemEventArgs(e.Graphics, e.ClipRectangle)
                               {
                                   Font = Font,
                                   TextRect = new RectangleF(textRect.Location, textRect.Size),
                                   StringFormat = sf,
                                   IsSelected = i == SelectedItemIndex,
                                   IsHovered = i == HighlightedItemIndex,
                                   Colors = Colors
                               };
                //call drawing
                VisibleItems[i].OnPaint(args);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ScrollableControl.Scroll" /> event.
        /// </summary>
        /// <param name="se">A <see cref="T:System.Windows.Forms.ScrollEventArgs" /> that contains the event data.</param>
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            Invalidate(true);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                SelectedItemIndex = PointToItemIndex(e.Location);
                ScrollToSelected();
                Invalidate();
            }
        }

        /// <summary>
        /// The mouse enter point
        /// </summary>
        private Point mouseEnterPoint;

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            mouseEnterPoint = Control.MousePosition;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (mouseEnterPoint != Control.MousePosition)
            {
                HighlightedItemIndex = PointToItemIndex(e.Location);
                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDoubleClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            SelectedItemIndex = PointToItemIndex(e.Location);
            Invalidate();
            OnItemSelected();
        }

        /// <summary>
        /// Called when [item selected].
        /// </summary>
        private void OnItemSelected()
        {
            if (ItemSelected != null)
                ItemSelected(this, EventArgs.Empty);
        }


        /// <summary>
        /// Points the index of to item.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns>System.Int32.</returns>
        private int PointToItemIndex(Point p)
        {
            return (p.Y + VerticalScroll.Value)/ItemHeight;
        }

        /// <summary>
        /// Processes the command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>true if the character was processed by the control; otherwise, false.</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var host = Parent as AutocompleteMenuHost;
            if (host != null)
                if (host.Menu.ProcessKey((char) keyData, Keys.None))
                    return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Selects the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        public void SelectItem(int itemIndex)
        {
            SelectedItemIndex = itemIndex;
            ScrollToSelected();
            Invalidate();
        }

        /// <summary>
        /// Sets the items.
        /// </summary>
        /// <param name="items">The items.</param>
        public void SetItems(List<AutocompleteItem> items)
        {
            VisibleItems = items;
            SelectedItemIndex = -1;
            AdjustScroll();
            Invalidate();
        }

        /// <summary>
        /// Shows tooltip
        /// </summary>
        /// <param name="autocompleteItem">The autocomplete item.</param>
        /// <param name="control">The control.</param>
        public void ShowToolTip(AutocompleteItem autocompleteItem, Control control = null)
        {
            string title = autocompleteItem.ToolTipTitle;
            string text = autocompleteItem.ToolTipText;
            if (control == null)
                control = this;

            if (string.IsNullOrEmpty(title))
            {
                toolTip.ToolTipTitle = null;
                toolTip.SetToolTip(control, null);
                return;
            }

            if (string.IsNullOrEmpty(text))
            {
                toolTip.ToolTipTitle = null;
                toolTip.Show(title, control, Width + 3, 0, ToolTipDuration);
            }
            else
            {
                toolTip.ToolTipTitle = title;
                toolTip.Show(text, control, Width + 3, 0, ToolTipDuration);
            }
        }
    }
}