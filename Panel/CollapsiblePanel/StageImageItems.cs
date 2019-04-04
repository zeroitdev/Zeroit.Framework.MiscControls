// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="StageImageItems.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls
{
    #region StateImageItems



    #region enum StateImageItemTypes
    /// <summary>
    /// Enumeration of standard image states
    /// </summary>
    public enum StateImageItemTypes
    {
        /// <summary>
        /// Normal (enabled) image
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Hot image (mouse over)
        /// </summary>
        Highlight,

        /// <summary>
        /// Pressed image (mouse down)
        /// </summary>
        Pressed,

        /// <summary>
        /// Disabled image
        /// </summary>
        Disabled
    }
    #endregion enum StateImageItemTypes

    /// <summary>
    /// Provides image index mapping for standard image states
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ImageItemCollection" />
    /// <remarks>This class is <see cref="SerializableAttribute" /> but does not implement
    /// <see cref="System.Runtime.Serialization.ISerializable" /></remarks>
#if DEBUG
    // tried using custom type converters and nothing worked correctly. Just use
    // this generic .NET implementation and things work fine
    [TypeConverter(typeof(ExpandableObjectConverter))]
#endif
    [Serializable]
    public class StateImageItems : ImageItemCollection
    {
        #region Constructor(s)
        /// <summary>
        /// Create an <c>StateImageItems</c> with all state values = -1
        /// </summary>
        public StateImageItems() : base((int)StateImageItemTypes.Disabled + 1) { }
        #endregion Constructor(s)

        #region Properties
        /// <summary>
        /// Get/Set the <i>normal</i> state image index
        /// </summary>
        /// <value>The normal.</value>
        /// <exception cref="System.ArgumentException">Invalid image item index. Must be >= -1</exception>
        /// <remarks>Uses custom <see cref="System.Drawing.Design.UITypeEditor" /> that shows a popup of all
        /// images in the <see cref="ImageSet" /> See <see cref="UIComponents.Designers.ImageMapEditor" /></remarks>
        [Editor(typeof(ImageMapEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Category("Image States"), Description("Image index for the normal state"), DefaultValue(-1)]
        public int Normal
        {
            get
            {
                return this[(int)StateImageItemTypes.Normal];
            }

            set
            {
                if (value < Undefined)
                {
                    throw new ArgumentException("Invalid image item index. Must be >= -1");
                }

                this[(int)StateImageItemTypes.Normal] = value;
            }
        }

        /// <summary>
        /// Get/Set the <see cref="Image" /> associated with the <i>normal</i> state
        /// </summary>
        /// <value>The normal image.</value>
        [Browsable(false)]
        public Image NormalImage
        {
            get
            {
                return Image((int)StateImageItemTypes.Normal);
            }
        }

        /// <summary>
        /// Get/Set the <i>highlight</i> state image index
        /// </summary>
        /// <value>The highlight.</value>
        /// <exception cref="System.ArgumentException">Invalid image item index. Must be >= -1</exception>
        /// <remarks>Uses custom <see cref="System.Drawing.Design.UITypeEditor" /> that shows a popup of all
        /// images in the <see cref="ImageSet" /> See <see cref="UIComponents.Designers.ImageMapEditor" /></remarks>
        [Category("Image States"), Description("Image index for the highlight (mouse over) state"), DefaultValue(-1)]
        [Editor(typeof(ImageMapEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int Highlight
        {
            get
            {
                return this[(int)StateImageItemTypes.Highlight];
            }

            set
            {
                if (value < Undefined)
                {
                    throw new ArgumentException("Invalid image item index. Must be >= -1");
                }

                this[(int)StateImageItemTypes.Highlight] = value;
            }
        }

        /// <summary>
        /// Get/Set the <see cref="Image" /> associated with the <i>highlight</i> state
        /// </summary>
        /// <value>The highlight image.</value>
        [Browsable(false)]
        public Image HighlightImage
        {
            get
            {
                return Image((int)StateImageItemTypes.Highlight);
            }
        }

        /// <summary>
        /// Get/Set the <i>pressed</i> state image index
        /// </summary>
        /// <value>The pressed.</value>
        /// <exception cref="System.ArgumentException">Invalid image item index. Must be >= -1</exception>
        /// <remarks>Uses custom <see cref="System.Drawing.Design.UITypeEditor" /> that shows a popup of all
        /// images in the <see cref="ImageSet" /> See <see cref="ImageMapEditor" /></remarks>
        [Category("Image States"), Description("Image index for the pressed (mouse down) state"), DefaultValue(-1)]
        [Editor(typeof(ImageMapEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int Pressed
        {
            get
            {
                return this[(int)StateImageItemTypes.Pressed];
            }

            set
            {
                if (value < Undefined)
                {
                    throw new ArgumentException("Invalid image item index. Must be >= -1");
                }

                this[(int)StateImageItemTypes.Pressed] = value;
            }
        }

        /// <summary>
        /// Get/Set the <see cref="Image" /> associated with the <i>pressed</i> state
        /// </summary>
        /// <value>The pressed image.</value>
        [Browsable(false)]
        public Image PressedImage
        {
            get
            {
                return Image((int)StateImageItemTypes.Pressed);
            }
        }

        /// <summary>
        /// Get/Set the <i>disabled</i> state image index
        /// </summary>
        /// <value>The disabled.</value>
        /// <exception cref="System.ArgumentException">Invalid image item index. Must be >= -1</exception>
        /// <remarks>Uses custom <see cref="System.Drawing.Design.UITypeEditor" /> that shows a popup of all
        /// images in the <see cref="ImageSet" />. See <see cref="UIComponents.Designers.ImageMapEditor" /></remarks>
        [Category("Image States"), Description("Image index for the disabled state"), DefaultValue(-1)]
        [Editor(typeof(ImageMapEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int Disabled
        {
            get
            {
                return this[(int)StateImageItemTypes.Disabled];
            }

            set
            {
                if (value < Undefined)
                {
                    throw new ArgumentException("Invalid image item index. Must be >= -1");
                }

                this[(int)StateImageItemTypes.Disabled] = value;
            }
        }

        /// <summary>
        /// Get/Set the <see cref="Image" /> associated with the <i>disabled</i> state
        /// </summary>
        /// <value>The disabled image.</value>
        [Browsable(false)]
        public Image DisabledImage
        {
            get
            {
                return Image((int)StateImageItemTypes.Disabled);
            }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Determine if an image state has a defined image mapping
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns><see langword="true" /> if the state has an associated image mapping,
        /// <see langword="false" /> otherwise</returns>
        public bool IsDefined(StateImageItemTypes state)
        {
            return base.IsDefined((int)state);
        }

        /// <summary>
        /// Determine if an image state has a defined image mapping that maps
        /// to an actual image
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns><see langword="true" /> if the state has an associated image mapping
        /// and valid image, <see langword="false" /> otherwise</returns>
        public bool IsImage(StateImageItemTypes state)
        {
            return base.IsImage((int)state);
        }
        #endregion Methods
    }
    #endregion
}
