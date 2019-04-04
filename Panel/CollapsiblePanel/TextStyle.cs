// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-30-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TextStyle.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    /// <summary>
    /// Defines the visualization of a <see cref="XPanelTextElement" />
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    [DefaultProperty("TextColor"), DefaultEvent("PropertyChange")]
    public class ZeroitPandaTextStyle : Component
    {
        #region Fields
        /// <summary>
        /// Font for the style
        /// </summary>
        private Font font = null;

        /// <summary>
        /// Foreground Color for the style
        /// </summary>
        private Color textColor = Color.Empty;

        /// <summary>
        /// Background Color for the style
        /// </summary>
        private Color backColor = Color.Transparent;

        /// <summary>
        /// Horizontal Alignment of the element within its bounding rectangle
        /// </summary>
        private StringAlignment horzAlignment = StringAlignment.Near;

        /// <summary>
        /// Vertical Alignment of an element within its bounding rectangle
        /// </summary>
        private StringAlignment vertAlignment = StringAlignment.Near;

        /// <summary>
        /// +/- value to alter default spacing of style of parent
        /// </summary>
        private Size spacingAdjust = Size.Empty;

        /// <summary>
        /// ImageSet associated with the style
        /// </summary>
        private ImageSet imageSet = null;

        /// <summary>
        /// A description for the style (not used by code)
        /// </summary>
        private String description = String.Empty;

        /// <summary>
        /// Left indent (in pixels) for the style
        /// </summary>
        private int indent = 0;

        #region Events
        /// <summary>
        /// <see cref="PropertyChange" />
        /// </summary>
        [NonSerialized]
        private TextElementPropertyChangeEventHandler propertyChangeListeners = null;
        #endregion Events
        #endregion Fields

        #region Constructor(s)
        /// <summary>
        /// Create a <see cref="ZeroitPandaTextStyle" /> with defaults
        /// </summary>
        public ZeroitPandaTextStyle() { }
        #endregion Constructor(s)

        #region Events
        /// <summary>
        /// Register/Unregister for <see cref="PropertyChange" /> events
        /// </summary>
        public event TextElementPropertyChangeEventHandler PropertyChange
        {
            add
            {
                propertyChangeListeners += value;
            }

            remove
            {
                propertyChangeListeners -= value;
            }
        }
        #endregion Events

        #region Properties
        /// <summary>
        /// Just a description string. Might be helpful if you have 50 of these things
        /// </summary>
        /// <value>The description.</value>
        /// <remarks>This property has no effect on functionality</remarks>
        [Category("Misc"), Description("For informational purposes only")]
        public String Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        /// <summary>
        /// Get/Set the <see cref="System.Drawing.Font" /> for the <c>ZeroitPandaTextStyle</c>
        /// </summary>
        /// <value>The font.</value>
        /// <remarks>Settting this value fires a <see cref="PropertyChange" /><see langword="event" />
        /// with the argument of <see cref="TextElementProperty.FontProperty" /></remarks>
        [Category("Appearance"), Description("Font of the ZeroitPandaTextStyle")]
        public Font Font
        {
            get
            {
                return font;
            }

            set
            {
                if (font != value)
                {
                    font = value;
                    OnPropertyChange(TextElementProperty.FontProperty);
                }
            }
        }

        /// <summary>
        /// Get/Set the Foreground <see cref="Color" /> of the <c>ZeroitPandaTextStyle</c>
        /// </summary>
        /// <value>The color of the text.</value>
        /// <remarks>Settting this value fires a <see cref="PropertyChange" /><see langword="event" />
        /// with the argument of <see cref="TextElementProperty.TextColorProperty" /></remarks>
        [Category("Appearance"), Description("ForeColor of the ZeroitPandaTextStyle")]
        public Color TextColor
        {
            get
            {
                return textColor;
            }

            set
            {
                if (textColor != value)
                {
                    textColor = value;
                    OnPropertyChange(TextElementProperty.TextColorProperty);
                }
            }
        }

        /// <summary>
        /// Get/Set the Background <see cref="Color" /> of the <c>ZeroitPandaTextStyle</c>
        /// </summary>
        /// <value>The color of the back.</value>
        /// <remarks>Settting this value fires a <see cref="PropertyChange" /><see langword="event" />
        /// with the argument of <see cref="TextElementProperty.BackColorProperty" /></remarks>
        [Category("Appearance"), Description("BackColor of the ZeroitPandaTextStyle")]
        public Color BackColor
        {
            get
            {
                return backColor;
            }

            set
            {
                if (backColor != value)
                {
                    backColor = value;
                    OnPropertyChange(TextElementProperty.BackColorProperty);
                }
            }
        }

        /// <summary>
        /// Get/Set the horizontal alignment of the <c>ZeroitPandaTextStyle</c>
        /// </summary>
        /// <value>The horz align.</value>
        /// <remarks>Settting this value fires a <see cref="PropertyChange" /><see langword="event" />
        /// with the argument of <see cref="TextElementProperty.HorizontalAlignmentProperty" /></remarks>
        [Category("Appearance"), Description("Horizontal Alignment of the ZeroitPandaTextStyle")]
        public StringAlignment HorzAlign
        {
            get
            {
                return horzAlignment;
            }

            set
            {
                if (horzAlignment != value)
                {
                    horzAlignment = value;
                    OnPropertyChange(TextElementProperty.HorizontalAlignmentProperty);
                }
            }
        }

        /// <summary>
        /// Get/Set the vertical alignment of the <c>ZeroitPandaTextStyle</c>
        /// </summary>
        /// <value>The vert align.</value>
        /// <remarks>Settting this value fires a <see cref="PropertyChange" /><see langword="event" />
        /// with the argument of <see cref="TextElementProperty.VerticalAlignmentProperty" /></remarks>
        [Category("Appearance"), Description("Vertical Alignment of the ZeroitPandaTextStyle")]
        public StringAlignment VertAlign
        {
            get
            {
                return vertAlignment;
            }

            set
            {
                if (vertAlignment != value)
                {
                    vertAlignment = value;
                    OnPropertyChange(TextElementProperty.VerticalAlignmentProperty);
                }
            }
        }

        /// <summary>
        /// Get/Set the <see cref="ImageSet" /> associated with the <c>ZeroitPandaTextStyle</c>
        /// </summary>
        /// <value>The image set.</value>
        /// <remarks><see cref="XPanelTextElement.ImageIndex" /> is used to associate a <see cref="XPanelTextElement" />
        /// with an <see cref="Image" /> in the <see cref="ImageSet" />. Note that the <see cref="XPanelTextElement.Image" />
        /// property can override the <see cref="XPanelTextElement.ImageIndex" /> property
        /// <para>
        /// Settting this value fires a <see cref="PropertyChange" /><see langword="event" />
        /// with the argument of <see cref="TextElementProperty.ImageSetProperty" /></para></remarks>
        [Category("Appearance"), Description("Images of the ZeroitPandaTextStyle")]
        public ImageSet ImageSet
        {
            get
            {
                return imageSet;
            }

            set
            {
                if (imageSet != value)
                {
                    imageSet = value;
                    OnPropertyChange(TextElementProperty.ImageSetProperty);
                }
            }
        }

        /// <summary>
        /// Get/Set the Y-spacing adjustment for the <c>ZeroitPandaTextStyle</c>
        /// </summary>
        /// <value>The spacing adjustment.</value>
        /// <remarks>The <see cref="Size.Width" /> values specifies the +/- offset from the
        /// proceeding element, while the <see cref="Size.Height" /> specifies the
        /// +/- offset from the succeeding element
        /// <para>
        /// Settting this value fires a <see cref="PropertyChange" /><see langword="event" />
        /// with the argument of <see cref="TextElementProperty.SpacingAdjustmentProperty" /></para></remarks>
        [Category("Appearance"), Description("Pre/Post Kerning adjustment fo the TextElement")]
        public Size SpacingAdjustment
        {
            get
            {
                return spacingAdjust;
            }

            set
            {
                if (spacingAdjust != value)
                {
                    spacingAdjust = value;
                    OnPropertyChange(TextElementProperty.SpacingAdjustmentProperty);
                }
            }
        }

        /// <summary>
        /// Number of "pixels" to indent element (from left)
        /// </summary>
        /// <value>The indent.</value>
        /// <remarks>Settting this value fires a <see cref="PropertyChange" /><see langword="event" />
        /// with the argument of <see cref="TextElementProperty.IndentProperty" /></remarks>
        [Category("Appearance"), Description("Left Indent (in pixels) of the TextElement")]
        public int Indent
        {
            get
            {
                return indent;
            }

            set
            {
                if (indent != value)
                {
                    indent = value;
                    OnPropertyChange(TextElementProperty.IndentProperty);
                }
            }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Look up an image given an index
        /// </summary>
        /// <param name="index">The index into the <see cref="ImageSet" /></param>
        /// <returns>The <see cref="Image" /> or <see langword="null" /> if it cannot be found</returns>
        public Image GetImage(int index)
        {
            if ((imageSet != null) && (index >= 0) && (index < imageSet.Count))
                return imageSet.Images[index];

            return null;
        }
        #endregion Methods

        #region Implementation
        /// <summary>
        /// Fire <see cref="PropertyChange" /> events to listeners
        /// </summary>
        /// <param name="property">The property.</param>
        protected virtual void OnPropertyChange(TextElementProperty property)
        {
            if (propertyChangeListeners != null)
            {
                propertyChangeListeners(this, new TextElementPropertyChangeEventArgs(property));
            }
        }
        #endregion Implementation
    }

    
}
