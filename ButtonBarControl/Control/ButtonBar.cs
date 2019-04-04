// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="ButtonBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Button bar control implementation for Windows Forms application.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    [Designer(typeof (ZeroitToxicButtonDesigner), typeof (IDesigner))]
    public partial class ZeroitToxicButton : ContainerControl
    {
        #region Fields

        /// <summary>
        /// The default
        /// </summary>
        internal static readonly Appearance DEFAULT = new Appearance();
        /// <summary>
        /// The appearance
        /// </summary>
        private readonly Appearance appearance;
        /// <summary>
        /// The current appearance
        /// </summary>
        private readonly Appearance currentAppearance;
        /// <summary>
        /// The items
        /// </summary>
        private readonly GenericCollection<BarItem> items;
        /// <summary>
        /// The theme property
        /// </summary>
        private readonly ThemeProperty themeProperty;
        /// <summary>
        /// The tool tip
        /// </summary>
        private readonly ToolTip toolTip;
        /// <summary>
        /// The BMP
        /// </summary>
        private Bitmap bmp;
        /// <summary>
        /// The button width
        /// </summary>
        private int buttonWidth = 120;
        /// <summary>
        /// The disable transparency
        /// </summary>
        private int disableTransparency = 20;
        /// <summary>
        /// The graphics
        /// </summary>
        private Graphics graphics;
        /// <summary>
        /// The image alignment
        /// </summary>
        private ImageAlignment imageAlignment = ImageAlignment.Top;
        /// <summary>
        /// The image list
        /// </summary>
        private ImageList imageList;
        /// <summary>
        /// The image transparency
        /// </summary>
        private int imageTransparency = 90;
        /// <summary>
        /// The last button width
        /// </summary>
        private int lastButtonWidth;
        /// <summary>
        /// The show borders
        /// </summary>
        private bool showBorders = true;
        /// <summary>
        /// The show scroll
        /// </summary>
        private bool showScroll;
        /// <summary>
        /// The spacing
        /// </summary>
        private int spacing = 4;
        /// <summary>
        /// The use mnemonic
        /// </summary>
        private bool useMnemonic = true;

        #endregion

        #region Events

        /// <summary>
        /// Occurs when a button is pressed. This is also fiered when Shortcut key is pressed or Enter key is pressed.
        /// </summary>
        public event GenericClickEventHandler<BarItem> ItemClick;

        /// <summary>
        /// Occurs when Bar is clicked. This fired when clicked on area other than buttons.
        /// </summary>
        public event MouseEventHandler BarClick;

        /// <summary>
        /// Occurs when Button Selection changes.
        /// </summary>
        public event GenericEventHandler<BarItem> SelectionChanged;

        /// <summary>
        /// Occurs when Button Selection is about to change.
        /// </summary>
        public event ItemChangingHandler SelectionChanging;

        /// <summary>
        /// Occurs when <see cref="BarItem" /> is being inserted on <see cref="Items" />
        /// </summary>
        public event CollectionChangingHandler ItemsInserting;

        /// <summary>
        /// Occurs when <see cref="Items" /> is clearing.
        /// </summary>
        public event CollectionClearingHandler ItemsClearing;

        /// <summary>
        /// Occurs when <see cref="BarItem" /> is being removed from <see cref="Items" />
        /// </summary>
        public event CollectionChangingHandler ItemsRemoving;

        /// <summary>
        /// Occurs when <see cref="BarItem" /> of <see cref="Items" /> is changing.
        /// </summary>
        public event ItemChangingHandler ItemsChanging;

        /// <summary>
        /// Occurs when <see cref="BarItem" /> requests drawing. This can be used to implement own drawing.
        /// </summary>
        public event EventHandler<DrawItemsEventArgs> CustomDrawItems;

        /// <summary>
        /// Occurs when <see cref="ZeroitToxicButton" /> requests drawing. This can be used to implement custom draw.
        /// </summary>
        public event EventHandler<DrawBackGroundEventArgs> CustomDrawBackGround;

        /// <summary>
        /// Occurs when <see cref="BarItem" /> of <see cref="Items" /> is changed.
        /// </summary>
        public event ItemChangeHandler ItemsChanged;

        /// <summary>
        /// Occurs when <see cref="BarItem" /> of <see cref="Items" /> is inserted into collection.
        /// </summary>
        public event CollectionChangedHandler ItemsInserted;

        /// <summary>
        /// Occurs when <see cref="BarItem" /> of <see cref="Items" /> is removed from collection.
        /// </summary>
        public event CollectionChangedHandler ItemsRemoved;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitToxicButton" /> class.
        /// </summary>
        public ZeroitToxicButton()
        {
            TabStop = true;
            Padding = new Padding(3, 3, 3, 3);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            items = new GenericCollection<BarItem>();
            items.Inserted += OnItemsInserted;
            items.Removed += OnItemsRemoved;
            items.Changed += OnItemsChanged;
            items.Inserting += OnItemsInserting;
            items.Changing += OnItemsChanging;
            items.Removing += OnItemsRemoving;
            items.Clearing += OnItemsClearing;
            toolTip = new ToolTip();
            appearance = new Appearance();
            appearance.AppearanceChanged += OnAppearanceChanged;
            currentAppearance = new Appearance();
            themeProperty = new ThemeProperty();
            themeProperty.ThemeChanged += OnAppearanceChanged;
            showScroll = false;
            useMnemonic = true;
            showBorders = true;
            Height = 200;
            InitializeDefaultScheme();
            SetThemeDefaults();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitToxicButton" /> class.
        /// </summary>
        /// <param name="component">Container containing <see cref="ZeroitToxicButton" /> control.</param>
        public ZeroitToxicButton(IContainer component) : this()
        {
            component.Add(this);
            TabStop = true;
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Called when [appearance changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="tArgs">The t arguments.</param>
        private void OnAppearanceChanged(object sender, GenericEventArgs<AppearanceAction> tArgs)
        {
            SetThemeDefaults();
            Invalidate();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the tool tip.
        /// </summary>
        /// <param name="sToolTip">The s tool tip.</param>
        private void SetToolTip(string sToolTip)
        {
            if (toolTip != null)
            {
                toolTip.SetToolTip(this, sToolTip);
            }
        }

        /// <summary>
        /// Refreshes the control.
        /// </summary>
        internal void RefreshControl()
        {
            var minHeight = 0;
            if (items != null)
            {
                if (items.Count > 0)
                {
                    BarItem lastBarItem = null;
                    foreach (BarItem barItem in items)
                    {
                        //Set Bar Items size
                        var itemText = barItem.Caption;
                        var img = (imageList != null && barItem.ImageIndex >= 0 &&
                                   imageList.Images.Count > barItem.ImageIndex)
                                      ? imageList.Images[barItem.ImageIndex]
                                      : null;
                        var format = new StringFormat
                                         {
                                             Trimming = currentAppearance.Item.AppearenceText.Trimming,
                                             Alignment = currentAppearance.Item.AppearenceText.Alignment,
                                             LineAlignment = currentAppearance.Item.AppearenceText.LineAlignment
                                         };
                        if (useMnemonic)
                        {
                            format.HotkeyPrefix = HotkeyPrefix.Show;
                        }
                        var alignment = barItem.ImageAlignment == ItemImageAlignment.Inherit
                                            ? ImageAlignment
                                            : ((ImageAlignment) ((int) barItem.ImageAlignment));
                        var txtHeight =
                            (int)
                            Graphics.MeasureString(itemText, Font,
                                                   buttonWidth -
                                                   (img != null &&
                                                    (alignment == ImageAlignment.Left ||
                                                     alignment == ImageAlignment.Right)
                                                        ? img.Width
                                                        : 0), format).Height;
                        var imageHeight = (img != null &&
                                           (alignment == ImageAlignment.Top || alignment == ImageAlignment.Bottom)
                                               ? img.Height
                                               : 0);
                        if (lastBarItem == null)
                        {
                            barItem.Top = Padding.Top;
                        }
                        else
                        {
                            barItem.Top = lastBarItem.Top + lastBarItem.Height + spacing;
                        }
                        barItem.Height = txtHeight + 4 + imageHeight + 6;
                        minHeight = barItem.Top + barItem.Height;
                        lastBarItem = barItem;
                        format.Dispose();
                    }
                    minHeight = minHeight + 3;
                }
            }
            var scroll = false;
            if (minHeight + Padding.Bottom > Height)
            {
                scroll = true;
            }
            AutoScrollMinSize = new Size(0, minHeight + Padding.Bottom);
            if (((showScroll != scroll)) | ((lastButtonWidth != buttonWidth)))
            {
                if (scroll)
                {
                    Width = buttonWidth + SystemInformation.VerticalScrollBarWidth;
                }
                else
                {
                    Width = buttonWidth;
                }
                showScroll = scroll;
                lastButtonWidth = buttonWidth;
            }
            else
            {
                if (scroll)
                {
                    Width = buttonWidth + SystemInformation.VerticalScrollBarWidth;
                }
                else
                {
                    Width = buttonWidth;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Hits the test.
        /// </summary>
        /// <returns>HitTestInfo.</returns>
        private HitTestInfo HitTest()
        {
            var p = new Point(MousePosition.X, MousePosition.Y);
            p = PointToClient(p);
            return HitTest(p.X, p.Y);
        }

        /// <summary>
        /// Nexts the item.
        /// </summary>
        /// <param name="lCurrent">The l current.</param>
        /// <param name="lDir">The l dir.</param>
        /// <returns>System.Int32.</returns>
        private int NextItem(int lCurrent, int lDir)
        {
            var bFound = false;
            var lNewIndex = -1;

            var lLastChecked = lCurrent;
            while (!bFound)
            {
                lNewIndex = lLastChecked + lDir;
                if ((lNewIndex < 0) || (lNewIndex >= items.Count))
                {
                    if (Math.Abs(lDir) > 1)
                    {
                        if (Math.Sign(lDir) == 1)
                        {
                            lNewIndex = items.Count - 1;
                            while (!bFound)
                            {
                                if (items[lNewIndex].Enabled)
                                {
                                    bFound = true;
                                }
                                else
                                {
                                    lNewIndex--;
                                    if (lNewIndex < 0)
                                    {
                                        bFound = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            lNewIndex = 0;
                            while (!bFound)
                            {
                                if (items[lNewIndex].Enabled)
                                {
                                    bFound = true;
                                }
                                else
                                {
                                    lNewIndex++;
                                    if (lNewIndex >= items.Count)
                                    {
                                        bFound = true;
                                    }
                                }
                            }
                        }
                    }
                    bFound = true;
                }
                else
                {
                    lLastChecked = lNewIndex;
                    if (items[lNewIndex].Enabled)
                    {
                        bFound = true;
                    }
                    lDir = Math.Sign(lDir);
                }
            }
            return lNewIndex;
        }

        /// <summary>
        /// Scrolls to.
        /// </summary>
        /// <param name="newPosition">The new position.</param>
        private void ScrollTo(int newPosition)
        {
            int stepSize;
            var complete = false;
            var current = -AutoScrollPosition.Y;
            if (newPosition > current)
            {
                stepSize = 1;
            }
            else
            {
                stepSize = -1;
            }
            while (!complete)
            {
                var newValue = current + stepSize;
                if (stepSize < 0)
                {
                    if (newValue < newPosition)
                    {
                        newValue = newPosition;
                        complete = true;
                    }
                }
                else
                {
                    if (newValue > newPosition)
                    {
                        newValue = newPosition;
                        complete = true;
                    }
                }
                AutoScrollPosition = new Point(0, Math.Abs(newValue));
                stepSize = stepSize*2;
            }
        }

        /// <summary>
        /// Sets the theme defaults.
        /// </summary>
        internal void SetThemeDefaults()
        {
            currentAppearance.Reset();
            if (!themeProperty.UseTheme)
            {
                if (!appearance.Bar.BackStyle.IsEmpty)
                    currentAppearance.Bar.BackStyle.Assign(appearance.Bar.BackStyle);
                else
                    currentAppearance.Bar.BackStyle.Assign(DEFAULT.Bar.BackStyle);
                currentAppearance.Bar.FocusedBorder = !appearance.Bar.FocusedBorder.IsEmpty
                                                          ? appearance.Bar.FocusedBorder
                                                          : DEFAULT.Bar.FocusedBorder;
                currentAppearance.Bar.NormalBorder = !appearance.Bar.NormalBorder.IsEmpty
                                                         ? appearance.Bar.NormalBorder
                                                         : DEFAULT.Bar.NormalBorder;
                if (!appearance.Bar.AppearanceBorder.IsEmpty)
                    currentAppearance.Bar.AppearanceBorder.Assign(appearance.Bar.AppearanceBorder);
                else
                    currentAppearance.Bar.AppearanceBorder.Assign(DEFAULT.Bar.AppearanceBorder);
                currentAppearance.Bar.CornerRadius = appearance.Bar.CornerRadius != 0
                                                         ? appearance.Bar.CornerRadius
                                                         : DEFAULT.Bar.CornerRadius;
                currentAppearance.Bar.DisabledMask = !appearance.Bar.DisabledMask.IsEmpty
                                                         ? appearance.Bar.DisabledMask
                                                         : DEFAULT.Bar.DisabledMask;

                if (!appearance.Item.BackStyle.IsEmpty)
                    currentAppearance.Item.BackStyle.Assign(appearance.Item.BackStyle);
                else
                    currentAppearance.Item.BackStyle.Assign(DEFAULT.Item.BackStyle);
                if (!appearance.Item.ClickStyle.IsEmpty)
                    currentAppearance.Item.ClickStyle.Assign(appearance.Item.ClickStyle);
                else
                    currentAppearance.Item.ClickStyle.Assign(DEFAULT.Item.ClickStyle);
                if (!appearance.Item.SelectedStyle.IsEmpty)
                    currentAppearance.Item.SelectedStyle.Assign(appearance.Item.SelectedStyle);
                else
                    currentAppearance.Item.SelectedStyle.Assign(DEFAULT.Item.SelectedStyle);
                if (!appearance.Item.DisabledStyle.IsEmpty)
                    currentAppearance.Item.DisabledStyle.Assign(appearance.Item.DisabledStyle);
                else
                    currentAppearance.Item.DisabledStyle.Assign(DEFAULT.Item.DisabledStyle);
                if (!appearance.Item.SelectedHoverStyle.IsEmpty)
                    currentAppearance.Item.SelectedHoverStyle.Assign(appearance.Item.SelectedHoverStyle);
                else
                    currentAppearance.Item.SelectedHoverStyle.Assign(DEFAULT.Item.SelectedHoverStyle);
                if (!appearance.Item.HoverStyle.IsEmpty)
                    currentAppearance.Item.HoverStyle.Assign(appearance.Item.HoverStyle);
                else
                    currentAppearance.Item.HoverStyle.Assign(DEFAULT.Item.HoverStyle);
                currentAppearance.Item.HoverBorder = !appearance.Item.HoverBorder.IsEmpty
                                                         ? appearance.Item.HoverBorder
                                                         : DEFAULT.Item.HoverBorder;
                currentAppearance.Item.HoverForeGround = !appearance.Item.HoverForeGround.IsEmpty
                                                             ? appearance.Item.HoverForeGround
                                                             : DEFAULT.Item.HoverForeGround;
                currentAppearance.Item.SelectedBorder = !appearance.Item.SelectedBorder.IsEmpty
                                                            ? appearance.Item.SelectedBorder
                                                            : DEFAULT.Item.SelectedBorder;
                currentAppearance.Item.NormalBorder = !appearance.Item.NormalBorder.IsEmpty
                                                          ? appearance.Item.NormalBorder
                                                          : DEFAULT.Item.NormalBorder;
                currentAppearance.Item.NormalForeGround = !appearance.Item.NormalForeGround.IsEmpty
                                                              ? appearance.Item.NormalForeGround
                                                              : DEFAULT.Item.NormalForeGround;
                currentAppearance.Item.SelectedForeGround = !appearance.Item.SelectedForeGround.IsEmpty
                                                                ? appearance.Item.SelectedForeGround
                                                                : DEFAULT.Item.SelectedForeGround;
                currentAppearance.Item.DisabledBorder = !appearance.Item.DisabledBorder.IsEmpty
                                                            ? appearance.Item.DisabledBorder
                                                            : DEFAULT.Item.DisabledBorder;
                currentAppearance.Item.DisabledForeGround = !appearance.Item.DisabledForeGround.IsEmpty
                                                                ? appearance.Item.DisabledForeGround
                                                                : DEFAULT.Item.DisabledForeGround;
                currentAppearance.Item.Gradient = appearance.Item.Gradient != 90
                                                      ? appearance.Item.Gradient
                                                      : DEFAULT.Item.Gradient;
                if (!appearance.Item.AppearenceText.IsEmpty)
                    currentAppearance.Item.AppearenceText.Assign(appearance.Item.AppearenceText);
                else
                    currentAppearance.Item.AppearenceText.Assign(DEFAULT.Item.AppearenceText);
            }
            else
            {
                switch (themeProperty.ColorScheme)
                {
                    case ColorScheme.VS2005:
                        SetColors(ColorSchemeDefinition.VS2005);
                        break;
                    case ColorScheme.Classic:
                        SetColors(ColorSchemeDefinition.Classic);
                        break;
                    case ColorScheme.Blue:
                        SetColors(ColorSchemeDefinition.Blue);
                        break;
                    case ColorScheme.Default:
                        SetColors(ColorSchemeDefinition.GetColorScheme(ColorScheme.Default));
                        break;
                    case ColorScheme.OliveGreen:
                        SetColors(ColorSchemeDefinition.OliveGreen);
                        break;
                    case ColorScheme.Royale:
                        SetColors(ColorSchemeDefinition.Royale);
                        break;
                    case ColorScheme.Silver:
                        SetColors(ColorSchemeDefinition.Silver);
                        break;
                }
            }
        }

        /// <summary>
        /// Initializes the default scheme.
        /// </summary>
        private void InitializeDefaultScheme()
        {
            DEFAULT.Bar.BackStyle.Assign(new ColorPair(Color.White, Color.White));
            DEFAULT.Bar.FocusedBorder = Color.DarkBlue;
            DEFAULT.Bar.NormalBorder = Color.LightBlue;
            DEFAULT.Bar.ResetAppearanceBorder();
            DEFAULT.Bar.ResetCornerRadius();
            DEFAULT.Bar.DisabledMask = Color.White;

            DEFAULT.Item.BackStyle.Assign(new ColorPair(Color.FromArgb(238, 236, 223)));
            DEFAULT.Item.ClickStyle.Assign(new ColorPair(Color.FromArgb(225, 230, 232)));
            DEFAULT.Item.Gradient = 90;
            DEFAULT.Item.HoverStyle.Assign(new ColorPair(Color.FromArgb(193, 210, 238)));
            DEFAULT.Item.SelectedHoverStyle.Assign(new ColorPair(Color.FromArgb(193, 210, 238)));
            DEFAULT.Item.SelectedStyle.Assign(new ColorPair(Color.FromArgb(225, 230, 232)));
            DEFAULT.Item.DisabledStyle.Assign(new ColorPair(Color.FromArgb(238, 236, 223)));

            DEFAULT.Item.NormalForeGround = Color.Black;
            DEFAULT.Item.SelectedForeGround = Color.Black;
            DEFAULT.Item.DisabledForeGround = Color.Gray;
            DEFAULT.Item.HoverForeGround = Color.Black;

            DEFAULT.Item.NormalBorder = Color.FromArgb(49, 106, 197);
            DEFAULT.Item.HoverBorder = Color.FromArgb(49, 106, 197);
            DEFAULT.Item.SelectedBorder = Color.FromArgb(49, 106, 197);
            DEFAULT.Item.DisabledBorder = Color.Gray;
        }

        /// <summary>
        /// Sets the colors.
        /// </summary>
        /// <param name="def">The definition.</param>
        private void SetColors(ColorSchemeDefinition def)
        {
            currentAppearance.Bar.BackStyle.Assign(def.BarBackStyle);
            currentAppearance.Bar.FocusedBorder = def.BarFocusedBorder;
            currentAppearance.Bar.NormalBorder = def.BarNormalBorder;
            currentAppearance.Bar.ResetAppearanceBorder();
            currentAppearance.Bar.ResetCornerRadius();
            currentAppearance.Bar.DisabledMask = def.DisabledMask;
            currentAppearance.Bar.CornerRadius = appearance.Bar.CornerRadius;

            currentAppearance.Item.BackStyle.Assign(def.BackStyle);
            currentAppearance.Item.ClickStyle.Assign(def.ClickStyle);
            currentAppearance.Item.Gradient = def.GradientMode;
            currentAppearance.Item.HoverBorder = def.HoverBorder;
            currentAppearance.Item.HoverForeGround = def.HoverForeGround;
            currentAppearance.Item.HoverStyle.Assign(def.HoverStyle);
            currentAppearance.Item.NormalBorder = def.NormalBorder;
            currentAppearance.Item.NormalForeGround = def.NormalForeGround;
            currentAppearance.Item.SelectedBorder = def.SelectedBorder;
            currentAppearance.Item.SelectedForeGround = def.SelectedForeGround;
            currentAppearance.Item.SelectedHoverStyle.Assign(def.SelectedHoverStyle);
            currentAppearance.Item.SelectedStyle.Assign(def.SelectedStyle);
            currentAppearance.Item.DisabledStyle.Assign(def.DisabledStyle);
            currentAppearance.Item.DisabledBorder = def.DisabledBorder;
            currentAppearance.Item.DisabledForeGround = def.DisabledForeGround;
            currentAppearance.Item.AppearenceText.Assign(appearance.Item.AppearenceText);
        }

        /// <summary>
        /// Creates the memory bitmap.
        /// </summary>
        private void CreateMemoryBitmap()
        {
            if (((bmp != null) && (bmp.Width == Width)) && (bmp.Height == Height))
                return;
            bmp = new Bitmap(Width, Height);
            graphics = Graphics.FromImage(bmp);
            Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Graphics.CompositingQuality = CompositingQuality.HighQuality;
            Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        /// <summary>
        /// Called when [select item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal bool OnSelectItem(BarItem item, bool value)
        {
            if (value)
            {
                var e2 = new GenericChangeEventArgs<BarItem>(SelectedItem, item);
                OnSelectionChanging(e2);
                if (e2.Cancel)
                    return false;
                for (var i = 0; i < items.Count; i++)
                {
                    if (items[i] != item && items[i].Selected)
                    {
                        items[i].Selected = false;
                    }
                }
                var e = new GenericEventArgs<BarItem>(item);
                OnSelectionChanged(e);
                return true;
            }
            return false;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Performs HitTest for specified point.
        /// </summary>
        /// <param name="pt">Point of hit</param>
        /// <returns><see cref="HitTestInfo" /> object containing information related to hit. e.g. Location, button index etc.</returns>
        public HitTestInfo HitTest(Point pt)
        {
            return HitTest(pt.X, pt.Y);
        }

        /// <summary>
        /// Performs HitTest for specified point.
        /// </summary>
        /// <param name="x">X co-ordinate of point.</param>
        /// <param name="y">Y co-ordinate of point.</param>
        /// <returns><see cref="HitTestInfo" /> object containing information related to hit. e.g. Location, button index etc.</returns>
        public HitTestInfo HitTest(int x, int y)
        {
            var hitItem = -1;
            if ((x >= 3) && (x <= buttonWidth - 6))
            {
                if ((y >= 0) && (y <= ClientSize.Height))
                {
                    for (var i = 0; i < items.Count; i++)
                    {
                        if (y < items[i].Top + AutoScrollPosition.Y) continue;
                        if (y >= items[i].Top + items[i].Height + AutoScrollPosition.Y) continue;
                        hitItem = i;
                        break;
                    }
                }
            }
            HitArea area;
            if (hitItem < 0 && ClientRectangle.Contains(x, y))
                area = HitArea.Client;
            else
                area = HitArea.Button;
            return new HitTestInfo(hitItem, area);
        }

        /// <summary>
        /// Selects the item in button bar.
        /// </summary>
        /// <param name="item">Item to be selected.</param>
        /// <returns>Returns wether item was selected or not.</returns>
        public bool SelectItem(BarItem item)
        {
            if (!item.Selected)
            {
                var e2 = new GenericChangeEventArgs<BarItem>(SelectedItem, item);
                OnSelectionChanging(e2);
                if (e2.Cancel)
                    return false;
                for (var i = 0; i < items.Count; i++)
                {
                    if (items[i] != item && items[i].Selected)
                    {
                        items[i].Selected = false;
                    }
                }
                item.Selected = true;
                var e = new GenericEventArgs<BarItem>(item);
                OnSelectionChanged(e);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Exports current Appearance to a specified file in XML format only..
        /// </summary>
        /// <param name="fileName">*.xml file where required information will be written.</param>
        /// <returns>Returns wether export operation was successful or not.</returns>
        public bool ExportAppearance(string fileName)
        {
            try
            {
                using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
                {
                    var serializer = new XmlSerializer(typeof (Appearance));
                    serializer.Serialize(writer, Appearance);
                    writer.Flush();
                    writer.Close();
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// Imports Appearance from exported XML file.
        /// </summary>
        /// <param name="fileName">*.xml file containing Appearance export.</param>
        /// <returns>Wether Import operation was successful or not.</returns>
        public bool ImportAppearance(string fileName)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof (Appearance));
                    var app = (Appearance) serializer.Deserialize(fs);
                    Appearance.Assign(app);
                    SetThemeDefaults();
                    Refresh();
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// Ensures given item is visible.Scrolls to item if not visible.
        /// </summary>
        /// <param name="index">Index of item to be shown.</param>
        public void EnsureVisibility(int index)
        {
            var offset = AutoScrollPosition.Y;
            var top = items[index].Top + offset - 3;
            int newValue;
            if (top < 0)
            {
                newValue = (-offset) + top;
                if (newValue <= 2)
                {
                    newValue = 0;
                }
                ScrollTo(newValue);
            }
            else
            {
                var bottom = items[index].Top + offset - 3 + items[index].Height;
                if (bottom > ClientSize.Height)
                {
                    newValue = -AutoScrollPosition.Y + (bottom - ClientSize.Height) + 6;
                    if (newValue >= AutoScrollMinSize.Height - 4)
                    {
                        newValue = AutoScrollMinSize.Height;
                    }
                    ScrollTo(newValue);
                }
            }
        }

        #endregion

        #region Static Method

        /// <summary>
        /// Gets Current State of button.
        /// </summary>
        /// <param name="barItem"><see cref="BarItem" /> of which state is to be determined.</param>
        /// <returns><see cref="State" /> of button.</returns>
        public static State GetButtonState(BarItem barItem)
        {
            State state;
            if (barItem.Enabled)
            {
                if (barItem.MouseDown)
                {
                    if (barItem.MouseOver)
                    {
                        state = barItem.Selected ? State.SelectedHover : State.Pressed;
                    }
                    else
                    {
                        state = barItem.Selected ? State.Selected : State.Hover;
                    }
                }
                else
                {
                    if (barItem.MouseOver)
                    {
                        state = barItem.Selected ? State.SelectedHover : State.Hover;
                    }
                    else
                    {
                        state = barItem.Selected ? State.Selected : State.Normal;
                    }
                }
            }
            else
            {
                state = State.Disabled;
            }
            return state;
        }

        #endregion
    }
}