// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="GradientColor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.MiscControls
{
    #region GradientColor
    /// <summary>
    /// <c>GradientColor</c> describes the <c>start</c> and <c>end</c><see cref="Color" /> values for
    /// a gradient fill.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.AbstractColorPair" />
    /// <remarks>Like <see cref="XPanelColorPair" /> this class extends <see cref="AbstractColorPair" /> and provides
    /// to overload properties <see cref="Start" /> and <see cref="End" />.
    /// <para>
    /// This class uses a custom <see cref="System.Drawing.Design.UITypeEditor" /> and <see cref="TypeConverter" />. See
    /// <see cref="UIComponents.Designers.GradientColorEditor" /> and
    /// <see cref="UIComponents.Designers.GradientColorConverter" /> respectively.
    /// The primary purpose of the <see cref="System.Drawing.Design.UITypeEditor" /> is to show a preview of the
    /// gradient in the designer property grid.
    /// </para><para>This class is <see cref="SerializableAttribute" /> but does not implement
    /// <see cref="System.Runtime.Serialization.ISerializable" /></para></remarks>
#if DEBUG
    [Editor(typeof(GradientColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
    [TypeConverter(typeof(GradientColorConverter))]
#endif
    [Serializable]
    public class GradientColor : AbstractColorPair
    {
        #region enum GradientColorType
        /// <summary>
        /// Enumeration of <see cref="GradientColor" /> values
        /// </summary>
        public enum GradientColorType
        {
            /// <summary>
            /// Start color index of the gradient
            /// </summary>
            GradientStart = 0,

            /// <summary>
            /// End color index for the gradient
            /// </summary>
            GradientEnd = 1
        }
        #endregion enum GradientColorType

        #region Constructors
        /// <summary>
        /// Create a <c>GradientColor</c> with <see cref="Start" /> and <see cref="End" />
        /// values equal to <see cref="Color.Empty" />
        /// </summary>
        public GradientColor() : this(Color.Empty) { }

        /// <summary>
        /// Create a <c>GradientColor</c> with <see cref="Start" /> and <see cref="End" />
        /// values equal to the specified <see cref="Color" />
        /// </summary>
        /// <param name="color">The color.</param>
        public GradientColor(Color color) : base(color) { }

        /// <summary>
        /// Create a <c>GradientColor</c> with <see cref="Start" /> and <see cref="End" />
        /// values equal to the specified <see cref="Color" /> values
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public GradientColor(Color start, Color end) : base(start, end) { }

        /// <summary>
        /// Create a <c>GradientColor</c> from an <see cref="AbstractColorPair" />
        /// </summary>
        /// <param name="colorPair">The color pair.</param>
        /// <remarks>See <see cref="AbstractColorPair(BaseColorCollection)" /> for more information</remarks>
        public GradientColor(AbstractColorPair colorPair) : base(colorPair) { }

        /// <summary>
        /// Create a <c>GradientColor</c> from a <see cref="BaseColorCollection" />
        /// </summary>
        /// <param name="colors">The other <c>BaseColorCollection</c></param>
        /// <remarks>Only the 1st and 2nd color are considered. If the <c>colors</c>
        /// collection only contains a single color, both color entries are
        /// equal to that value. If zero colors are specified in colors
        /// then both values are the default, <see cref="Color.Empty" /></remarks>
        public GradientColor(BaseColorCollection colors) : base(colors) { }
        #endregion Constructors

        #region ICloneable Members
        /// <summary>
        /// Clone this <c>ColorPair</c>
        /// </summary>
        /// <returns>A clone of this <c>ColorPair</c></returns>
        public override object Clone()
        {
            return new GradientColor(this);
        }
        #endregion ICloneable Members

        #region Properties
        /// <summary>
        /// Get/Set the start <see cref="Color" /> value of the <c>GradientColor</c>
        /// </summary>
        /// <value>The start.</value>
        [Category("GradientColor Properties")]
        [Description("The start color for the linear gradient")]
        public Color Start
        {
            get
            {
                return base.Color1;
            }
            set
            {
                base.Color1 = value;
            }
        }

        /// <summary>
        /// Get/Set the end <see cref="Color" /> value of the <c>GradientColor</c>
        /// </summary>
        /// <value>The end.</value>
        [Category("GradientColor Properties")]
        [Description("The end color for the linear gradient")]
        public Color End
        {
            get
            {
                return base.Color2;
            }
            set
            {
                base.Color2 = value;
            }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Return a LinearGradientBrush for this GradientColor using the specified
        /// <see cref="Rectangle" /> and <see cref="LinearGradientMode" />
        /// </summary>
        /// <param name="rect">The <see cref="Rectangle" /></param>
        /// <param name="mode">The mode of the <see cref="LinearGradientBrush" /></param>
        /// <returns>LinearGradientBrush.</returns>
        public LinearGradientBrush GetBrush(Rectangle rect, LinearGradientMode mode)
        {
            return new LinearGradientBrush(rect, Start, End, mode);
        }
        #endregion Methods

        #region Overrides
        /// <summary>
        /// Override to provide our 'custom' enumeration for our color indices
        /// </summary>
        /// <returns>typeof(ColorPairType)</returns>
        protected override Type GetColorItemType()
        {
            return typeof(GradientColorType);
        }
        #endregion Overrides
    }
    #endregion
}
