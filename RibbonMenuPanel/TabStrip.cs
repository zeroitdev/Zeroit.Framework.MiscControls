// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabStrip.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for rendering a tab strip.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolStrip" />
    [ToolboxItem(typeof(TabStripToolboxItem))]    
    public partial class ZeroitTabStrip : ToolStrip
    {
        /// <summary>
        /// The bold font
        /// </summary>
        Font boldFont = new Font(SystemFonts.MenuFont, FontStyle.Bold);
        /// <summary>
        /// The extra padding
        /// </summary>
        private const int EXTRA_PADDING = 0;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTabStrip" /> class.
        /// </summary>
        public ZeroitTabStrip()
        {
            Renderer = new TabStripProfessionalRenderer();
            this.Padding = new Padding(60, 3, 30, 0);
            this.AutoSize = false;
            this.Size = new Size(this.Width, 26);
            this.BackColor = Color.FromArgb(191, 219, 255);
            this.GripStyle = ToolStripGripStyle.Hidden;

            this.ShowItemToolTips = false;
        }
        /// <summary>
        /// Creates a default <see cref="T:System.Windows.Forms.ToolStripItem" /> with the specified text, image, and event handler on a new <see cref="T:System.Windows.Forms.ToolStrip" /> instance.
        /// </summary>
        /// <param name="text">The text to use for the <see cref="T:System.Windows.Forms.ToolStripItem" />. If the <paramref name="text" /> parameter is a hyphen (-), this method creates a <see cref="T:System.Windows.Forms.ToolStripSeparator" />.</param>
        /// <param name="image">The <see cref="T:System.Drawing.Image" /> to display on the <see cref="T:System.Windows.Forms.ToolStripItem" />.</param>
        /// <param name="onClick">An event handler that raises the <see cref="E:System.Windows.Forms.Control.Click" /> event when the <see cref="T:System.Windows.Forms.ToolStripItem" /> is clicked.</param>
        /// <returns>A <see cref="M:System.Windows.Forms.ToolStripButton.#ctor(System.String,System.Drawing.Image,System.EventHandler)" />, or a <see cref="T:System.Windows.Forms.ToolStripSeparator" /> if the <paramref name="text" /> parameter is a hyphen (-).</returns>
        protected override ToolStripItem CreateDefaultItem(string text, Image image, EventHandler onClick)
        {
            return new Tab(text, image, onClick);
        }


        /// <summary>
        /// Gets the internal spacing, in pixels, of the contents of a <see cref="T:System.Windows.Forms.ToolStrip" />.
        /// </summary>
        /// <value>The default padding.</value>
        protected override Padding DefaultPadding
        {
            get
            {
                Padding padding = base.DefaultPadding;
                padding.Top += EXTRA_PADDING;
                padding.Bottom += EXTRA_PADDING;

                return padding;
            }
        }

        /// <summary>
        /// The current selection
        /// </summary>
        private Tab currentSelection;

        /// <summary>
        /// Gets or sets the selected tab.
        /// </summary>
        /// <value>The selected tab.</value>
        public Tab SelectedTab
        {
            get { return currentSelection; }
            set
            {
                if (currentSelection != value)
                {
                    currentSelection = value;

                    if (currentSelection != null)
                    {
                        PerformLayout();
                        if (currentSelection.TabStripPage != null)
                        {
                            currentSelection.TabStripPage.Activate();
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStrip.ItemClicked" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemClickedEventArgs" /> that contains the event data.</param>
        protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Tab currentTab = Items[i] as Tab;
                SuspendLayout();
                if (currentTab != null)
                {
                    if (currentTab != e.ClickedItem)
                    {
                        currentTab.Checked = false;
                        currentTab.Font = this.Font;
                        currentTab.b_active = false;
                    }
                    else
                    {
                        // currentTab.Font = boldFont;
                        currentTab.b_active = true;
                    }
                }
                ResumeLayout();
            }
            SelectedTab = e.ClickedItem as Tab;

            base.OnItemClicked(e);

        }

        /// <summary>
        /// Resets the collection of displayed and overflow items after a layout is done.
        /// </summary>
        protected override void SetDisplayedItems()
        {
            base.SetDisplayedItems();
            for (int i = 0; i < DisplayedItems.Count; i++)
            {
                if (DisplayedItems[i] == SelectedTab)
                {
                    DisplayedItems.Add(SelectedTab);
                    break;
                }
            }
        }

        /// <summary>
        /// Gets the default size of the <see cref="T:System.Windows.Forms.ToolStrip" />.
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize
        {
            get
            {
                Size size = base.DefaultSize;
                // size.Height += EXTRA_PADDING*2;
                return size;
            }
        }

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="proposedSize">The custom-sized area for a control.</param>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        public override Size GetPreferredSize(Size proposedSize)
        {
            Size preferredSize = Size.Empty;
            proposedSize -= this.Padding.Size;

            foreach (ToolStripItem item in this.Items)
            {
                preferredSize = LayoutUtils.UnionSizes(preferredSize, item.GetPreferredSize(proposedSize) + item.Padding.Size);
            }
            return preferredSize + this.Padding.Size;
        }

        /// <summary>
        /// The tab overlap
        /// </summary>
        private int tabOverlap = 0;

        /// <summary>
        /// Gets or sets the tab overlap.
        /// </summary>
        /// <value>The tab overlap.</value>
        [DefaultValue(10)]
        public int TabOverlap
        {
            get { return tabOverlap; }
            set
            {
                if (tabOverlap != value)
                {
                   
                    tabOverlap = value;
                    // call perform layout so we 
                    PerformLayout();
                }
            }
        }



    }
}
