// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="ButtonBar.Properties.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitToxicButton.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    partial class ZeroitToxicButton
    {
        #region Public properties

        /// <summary>
        /// Imagelist containing images for buttons.
        /// </summary>
        /// <value>The image list.</value>
        [Category("Appearance")]
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ImageList ImageList
        {
            get { return imageList; }
            set
            {
                imageList = value;
                RefreshControl();
            }
        }

        /// <summary>
        /// Property used to Get or Set which theme should be used. See also <see cref="Design.Entity.ThemeProperty" />
        /// </summary>
        /// <value>The theme property.</value>
        [Category("Appearance")]
        [TypeConverter(typeof (GenericConverter<ThemeProperty>))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ThemeProperty ThemeProperty
        {
            get { return themeProperty; }
        }

        /// <summary>
        /// Collections of buttons.
        /// </summary>
        /// <value>The items.</value>
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("The collection of list items for the control.")]
        public GenericCollection<BarItem> Items
        {
            get { return items; }
        }

        /// <summary>
        /// Indicates wether to use shortcut keys or not.
        /// </summary>
        /// <value><c>true</c> if [use mnemonic]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool UseMnemonic
        {
            get { return useMnemonic; }
            set
            {
                if (useMnemonic != value)
                {
                    useMnemonic = value;
                    RefreshControl();
                }
            }
        }

        /// <summary>
        /// Width of buttons. Control resizes itself to button.
        /// </summary>
        /// <value>The width of the button.</value>
        [Category("Appearance")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(120)]
        public int ButtonWidth
        {
            get { return buttonWidth; }
            set
            {
                if (buttonWidth != value)
                {
                    buttonWidth = value;
                    RefreshControl();
                }
            }
        }

        /// <summary>
        /// Get current selected button.
        /// </summary>
        /// <value>The selected item.</value>
        [Category("Appearance")]
        [TypeConverter(typeof (ReadOnlyConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BarItem SelectedItem
        {
            get
            {
                BarItem barItem = null;
                foreach (BarItem item in items)
                {
                    if (item.Selected)
                    {
                        barItem = item;
                        break;
                    }
                }
                return barItem;
            }
        }

        /// <summary>
        /// <see cref="Design.Layout.Appearance" /> object containing Global Appearance information.
        /// </summary>
        /// <value>The appearance.</value>
        [Category("Appearance")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [TypeConverter(typeof (GenericConverter<Appearance>))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof (AppearanceEditor), typeof (UITypeEditor))]
        public Appearance Appearance
        {
            get { return appearance; }
        }

        /// <summary>
        /// Gets or Sets wether borders will be shown or not.
        /// </summary>
        /// <value><c>true</c> if [show borders]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(true)]
        public bool ShowBorders
        {
            get { return showBorders; }
            set
            {
                if (showBorders == value)
                    return;
                showBorders = value;
                RefreshControl();
            }
        }

        //[Category("209, 212, 215")]
        /// <summary>
        /// Gets the current appearance.
        /// </summary>
        /// <value>The current appearance.</value>
        [RefreshProperties(RefreshProperties.Repaint)]
        [TypeConverter(typeof (ReadOnlyConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        internal Appearance CurrentAppearance
        {
            get { return currentAppearance; }
        }

        /// <summary>
        /// Gets or Sets Background Image transparency.
        /// </summary>
        /// <value>The image transparency.</value>
        [Category("Appearance")]
        [Editor(typeof (RangeEditor), typeof (UITypeEditor))]
        [MinMax(0, 100)]
        [DefaultValue(90)]
        public int ImageTransparency
        {
            get { return imageTransparency; }
            set
            {
                if (imageTransparency == value)
                    return;
                imageTransparency = value;
                RefreshControl();
            }
        }

        /// <summary>
        /// Gets or Sets Disabled State Transparency.
        /// </summary>
        /// <value>The disable transparency.</value>
        [Category("Appearance")]
        [Editor(typeof (RangeEditor), typeof (UITypeEditor))]
        [MinMax(0, 100)]
        [DefaultValue(20)]
        public int DisableTransparency
        {
            get { return disableTransparency; }
            set
            {
                if (disableTransparency == value)
                    return;
                disableTransparency = value;
                RefreshControl();
            }
        }

        /// <summary>
        /// Gets or Sets Global image alignment of button images.
        /// </summary>
        /// <value>The image alignment.</value>
        [Category("Appearance")]
        [DefaultValue(ImageAlignment.Top)]
        public ImageAlignment ImageAlignment
        {
            get { return imageAlignment; }
            set
            {
                if (imageAlignment == value)
                    return;
                imageAlignment = value;
                OnAppearanceChanged(this, new GenericEventArgs<AppearanceAction>(AppearanceAction.Recreate));
            }
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("This property is not relevent.")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        /// <value><c>true</c> if [automatic scroll]; otherwise, <c>false</c>.</value>
        [Obsolete("This property is not relevent.")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                base.AutoScroll = value;
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control. Thsi property is not relevent with this control.
        /// </summary>
        /// <value>The text.</value>
        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        /// <summary>
        /// Gets the graphics.
        /// </summary>
        /// <value>The graphics.</value>
        private Graphics Graphics
        {
            get
            {
                if (graphics == null)
                    CreateMemoryBitmap();
                return graphics;
            }
        }

        /// <summary>
        /// Gets or Sets distance between buttons.
        /// </summary>
        /// <value>The spacing.</value>
        [Category("Appearance")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(4)]
        public int Spacing
        {
            get { return spacing; }
            set
            {
                if (spacing == value)
                    return;
                spacing = value;
                RefreshControl();
            }
        }

        #endregion

        /// <summary>
        /// Resets Theme Property to Default Value.
        /// </summary>
        protected void ResetThemeProperty()
        {
            ThemeProperty.Reset();
        }

        /// <summary>
        /// Resets <see cref="Design.Layout.Appearance.Item" /> to default value.
        /// </summary>
        protected void ResetItemStyle()
        {
            appearance.Item.Assign(DEFAULT.Item);
        }

        /// <summary>
        /// Resets <see cref="Design.Layout.Appearance.Bar" /> to default value.
        /// </summary>
        protected void ResetBarStyle()
        {
            appearance.Bar.Assign(DEFAULT.Bar);
        }

        /// <summary>
        /// Indicates wether <see cref="ThemeProperty" /> needs to be serialized by designer or not.
        /// </summary>
        /// <returns>true if designer needs to serialize</returns>
        protected bool ShouldSerializeThemeProperty()
        {
            return ThemeProperty.DefaultChanged();
        }

        /// <summary>
        /// Indicates wether <see cref="Design.Layout.Appearance.Item" /> needs to be serialized by designer or not.
        /// </summary>
        /// <returns>true if designer needs to serialize</returns>
        protected bool ShouldSerializeItemStyle()
        {
            return appearance.Item != DEFAULT.Item;
        }

        /// <summary>
        /// Indicates wether <see cref="Design.Layout.Appearance.Bar" /> needs to be serialized by designer or not.
        /// </summary>
        /// <returns>true if designer needs to serialize</returns>
        protected bool ShouldSerializeBarStyle()
        {
            return appearance.Bar != DEFAULT.Bar;
        }
    }
}