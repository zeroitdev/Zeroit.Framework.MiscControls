// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="BarItem.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Design;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents button on <see cref="ZeroitToxicButton" />
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    [ToolboxItem(false)]
    public class BarItem : ICloneable
    {
        /// <summary>
        /// The appearance
        /// </summary>
        private readonly AppearanceItem appearance;
        /// <summary>
        /// The caption
        /// </summary>
        private string caption;
        /// <summary>
        /// The enabled
        /// </summary>
        private bool enabled = true;
        /// <summary>
        /// The image alignment
        /// </summary>
        private ItemImageAlignment imageAlignment;
        /// <summary>
        /// The image index
        /// </summary>
        private int imageIndex;
        /// <summary>
        /// The owner
        /// </summary>
        private ZeroitToxicButton owner;
        /// <summary>
        /// The selected
        /// </summary>
        private bool selected;
        /// <summary>
        /// The show border
        /// </summary>
        private ShowBorder showBorder;
        /// <summary>
        /// The tag
        /// </summary>
        private object tag;
        /// <summary>
        /// The tool tip text
        /// </summary>
        private string toolTipText;

        /// <summary>
        /// Initializes a new instance of the <see cref="BarItem" /> class.
        /// </summary>
        public BarItem()
        {
            caption = string.Empty;
            enabled = true;
            Height = 0;
            imageIndex = -1;
            MouseDown = false;
            MouseOver = false;
            owner = null;
            selected = false;
            Top = 0;
            tag = null;
            toolTipText = string.Empty;
            appearance = new AppearanceItem();
            appearance.AppearanceChanged += OnAppearanceChanged;
            showBorder = ShowBorder.Inherit;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BarItem" /> class with Specified owner of <see cref="BarItem" />
        /// </summary>
        /// <param name="owner">The owner.</param>
        public BarItem(ZeroitToxicButton owner)
        {
            this.owner = owner;
            caption = GetCaption();
            enabled = true;
            Height = 0;
            imageIndex = -1;
            MouseDown = false;
            MouseOver = false;
            selected = false;
            Top = 0;
            tag = null;
            toolTipText = caption;
            appearance = new AppearanceItem();
            appearance.AppearanceChanged += OnAppearanceChanged;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BarItem" /> class with Specified Text
        /// </summary>
        /// <param name="text">Text of Button</param>
        public BarItem(string text)
            : this()
        {
            caption = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BarItem" /> class with Specified Text
        /// </summary>
        /// <param name="text">Text of Button</param>
        /// <param name="imageIndex"><see cref="ImageIndex" /> of Button.</param>
        public BarItem(string text, int imageIndex)
            : this(text)
        {
            this.imageIndex = imageIndex;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BarItem" /> class.
        /// </summary>
        /// <param name="text">Text of Button</param>
        /// <param name="imageIndex"><see cref="ImageIndex" /> of Button.</param>
        /// <param name="toolTipText"><see cref="ToolTipText" /> of button.</param>
        public BarItem(string text, int imageIndex, string toolTipText)
            : this(text, imageIndex)
        {
            this.toolTipText = toolTipText;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BarItem" /> class.
        /// </summary>
        /// <param name="text">Text of Button</param>
        /// <param name="imageIndex"><see cref="ImageIndex" /> of Button.</param>
        /// <param name="toolTipText"><see cref="ToolTipText" /> of button.</param>
        /// <param name="enabled">Button is enabled or not.</param>
        public BarItem(string text, int imageIndex, string toolTipText, bool enabled)
            : this(text, imageIndex, toolTipText)
        {
            this.enabled = enabled;
        }

        /// <summary>
        /// Gets or Sets caption of <see cref="BarItem" />
        /// </summary>
        /// <value>The caption.</value>
        [Localizable(true)]
        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                if (owner != null)
                {
                    owner.RefreshControl();
                }
            }
        }

        /// <summary>
        /// Contains settings related to button Appearance. This overrides global Appearance
        /// </summary>
        /// <value>The appearance.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public AppearanceItem Appearance
        {
            get { return appearance; }
        }

        /// <summary>
        /// Gets or Sets Tooltip text of button.
        /// </summary>
        /// <value>The tool tip text.</value>
        [Localizable(true)]
        public string ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText = value; }
        }

        /// <summary>
        /// Gets or Sets Tag of button. Can be used to hold information.
        /// </summary>
        /// <value>The tag.</value>
        [TypeConverter(typeof (StringConverter)), Bindable(true), Localizable(false), DefaultValue((string) null)]
        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        /// <summary>
        /// Imageindex of button. Uses <see cref="Owner" /> s imagelist to retrieve images.
        /// </summary>
        /// <value>The index of the image.</value>
        [DefaultValue(-1)]
        [ImageProperty("Owner.ImageList")]
        [Editor(typeof (ImageListIndexEditor), typeof (UITypeEditor))]
        public int ImageIndex
        {
            get { return imageIndex; }
            set
            {
                imageIndex = value;
                if (owner != null)
                {
                    owner.RefreshControl();
                }
            }
        }

        /// <summary>
        /// Gets or Sets button is enabled or not.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                if (owner != null)
                {
                    owner.RefreshControl();
                }
            }
        }

        /// <summary>
        /// Owner of button.
        /// </summary>
        /// <value>The owner.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ZeroitToxicButton Owner
        {
            get { return owner; }
            internal set
            {
                owner = value;
                if (string.IsNullOrEmpty(caption) && string.IsNullOrEmpty(toolTipText))
                {
                    caption = GetCaption();
                    toolTipText = caption;
                }
            }
        }

        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        /// <value>The top.</value>
        internal int Top { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        internal int Height { get; set; }

        /// <summary>
        /// Gets or Sets item is selected or not.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (value == selected)
                    return;
                if (owner == null)
                    return;
                selected = owner.OnSelectItem(this, value);
                owner.RefreshControl();
            }
        }

        /// <summary>
        /// Gets or Sets items image alignment.
        /// </summary>
        /// <value>The image alignment.</value>
        public ItemImageAlignment ImageAlignment
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
        /// Gets or Sets wether border needs to be shown or not.
        /// </summary>
        /// <value>The show border.</value>
        public ShowBorder ShowBorder
        {
            get { return showBorder; }
            set
            {
                if (showBorder == value)
                    return;
                showBorder = value;
                OnAppearanceChanged(this, new GenericEventArgs<AppearanceAction>(AppearanceAction.Recreate));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [mouse down].
        /// </summary>
        /// <value><c>true</c> if [mouse down]; otherwise, <c>false</c>.</value>
        internal bool MouseDown { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [mouse over].
        /// </summary>
        /// <value><c>true</c> if [mouse over]; otherwise, <c>false</c>.</value>
        internal bool MouseOver { get; set; }

        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            var myClone = new BarItem(caption, imageIndex, toolTipText, enabled)
                              {Tag = tag, ImageAlignment = imageAlignment, ShowBorder = showBorder};
            myClone.Appearance.Assign(appearance);
            return myClone;
        }

        #endregion

        /// <summary>
        /// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.</returns>
        public override string ToString()
        {
            return caption;
        }

        /// <summary>
        /// This function is called whenever there is change <see cref="Appearance" />
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="tArgs">Object containing Event data</param>
        protected virtual void OnAppearanceChanged(object sender, GenericEventArgs<AppearanceAction> tArgs)
        {
            if (owner == null)
                return;
            owner.RefreshControl();
        }


        /// <summary>
        /// Gets the caption.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetCaption()
        {
            const string s = "Button ";
            var names = new List<string>();
            for (int i = 0; i < owner.Items.Count; i++)
            {
                names.Add(owner.Items[i].Caption);
            }
            bool found;
            int j = 0;
            do
            {
                j++;
                found = names.IndexOf(s + j) >= 0;
            } while (found);
            return s + j;
        }

        /// <summary>
        /// Resets <see cref="ImageAlignment" /> property
        /// </summary>
        protected void ResetImageAlignment()
        {
            imageAlignment = ItemImageAlignment.Inherit;
        }

        /// <summary>
        /// Resets <see cref="ShowBorder" /> property
        /// </summary>
        protected void ResetShowBorder()
        {
            ShowBorder = ShowBorder.Inherit;
        }

        /// <summary>
        /// Indicates wether <see cref="ImageAlignment" /> needs to be serialized.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected bool ShouldSerializeShowBorder()
        {
            return ShowBorder != ShowBorder.Inherit;
        }
    }
}