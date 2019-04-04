// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ColorTypeConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace Zeroit.Framework.MiscControls
{
    #region Color Type Converter
    /// <summary>
    /// A custom TypeConvert for GradientColor objects
    /// </summary>
    /// <seealso cref="System.ComponentModel.ExpandableObjectConverter" />
	internal class GradientColorConverter : ExpandableObjectConverter
    {
        #region Overrides
        /// <summary>
        /// Provide a <see cref="String" /> representation for the designer property grid
        /// </summary>
        /// <param name="context">designer context</param>
        /// <param name="culture">globalization info</param>
        /// <param name="value"><see cref="GradientColor" /> to be converted</param>
        /// <param name="destinationType">Expected to be <see cref="GradientColor" /></param>
        /// <returns>A simple <see cref="String" /> representation when that type is requested</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string) || !(value is GradientColor))
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
            return "Gradient Color";
        }

        /// <summary>
        /// Construct a <see cref="GradientColor" /> from the properties in a <see cref="IDictionary" />
        /// </summary>
        /// <param name="context">designer context</param>
        /// <param name="propertyValues">The "serialized" values for the <see cref="GradientColor" /></param>
        /// <returns>A <see cref="GradientColor" /></returns>
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            GradientColor gradientColor = new GradientColor();
            gradientColor.Start = (System.Drawing.Color)propertyValues["Start"];
            gradientColor.End = (System.Drawing.Color)propertyValues["End"];
            return (object)gradientColor;
        }

        /// <summary>
        /// We support CreateInstance
        /// </summary>
        /// <param name="context">designer context</param>
        /// <returns><see langword="true" /></returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        #endregion
    }

    /// <summary>
    /// A custom TypeConvert for <see cref="XPanelColorPair" /> objects
    /// </summary>
    /// <seealso cref="System.ComponentModel.ExpandableObjectConverter" />
    internal class ColorPairConverter : ExpandableObjectConverter
    {
        #region Overrides
        /// <summary>
        /// Provide a <see cref="String" /> representation for the designer property grid
        /// </summary>
        /// <param name="context">designer context</param>
        /// <param name="culture">globalization info</param>
        /// <param name="value"><see cref="XPanelColorPair" /> to be converted</param>
        /// <param name="destinationType">Expected to be <see cref="XPanelColorPair" /></param>
        /// <returns>A simple <see cref="String" /> representation when that type is requested</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string) || !(value is XPanelColorPair))
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
            return "Color Pair";
        }


        /// <summary>
        /// Construct a <see cref="XPanelColorPair" /> from the properties in a <see cref="IDictionary" />
        /// </summary>
        /// <param name="context">designer context</param>
        /// <param name="propertyValues">The "serialized" values for the <see cref="XPanelColorPair" /></param>
        /// <returns>A <see cref="XPanelColorPair" /></returns>
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            XPanelColorPair colorPair = new XPanelColorPair();
            colorPair.Foreground = (System.Drawing.Color)propertyValues["Foreground"];
            colorPair.Background = (System.Drawing.Color)propertyValues["Background"];
            return (object)colorPair;
        }

        /// <summary>
        /// We support CreateInstance
        /// </summary>
        /// <param name="context">designer context</param>
        /// <returns><see langword="true" /></returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        #endregion
    }

    /// <summary>
    /// A custom TypeConvert for <see cref="HSLColor" /> objects
    /// </summary>
    /// <seealso cref="System.ComponentModel.ExpandableObjectConverter" />
    internal class HSLColorConverter : ExpandableObjectConverter
    {
        #region Overrides
        /// <summary>
        /// Provide a <see cref="String" /> representation for the designer property grid
        /// </summary>
        /// <param name="context">designer context</param>
        /// <param name="culture">globalization info</param>
        /// <param name="value"><see cref="HSLColor" /> to be converted</param>
        /// <param name="destinationType">Expected to be <see cref="HSLColor" /></param>
        /// <returns>A simple <see cref="String" /> representation when that type is requested</returns>
        /// <remarks>What would be better is to display the current RGB byte values as R,G,B. E.g, 234,44,128</remarks>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string) || !(value is HSLColor))
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
            return "HSL Color";
        }

        /// <summary>
        /// Construct a <see cref="HSLColor" /> from the properties in a <see cref="IDictionary" />
        /// </summary>
        /// <param name="context">designer context</param>
        /// <param name="propertyValues">The "serialized" values for the <see cref="HSLColor" /></param>
        /// <returns>A <see cref="HSLColor" /></returns>
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            HSLColor hslColor = new HSLColor();
            hslColor.Hue = (double)propertyValues["Hue"];
            hslColor.Saturation = (double)propertyValues["Saturation"];
            hslColor.Luminance = (double)propertyValues["Luminance"];
            return (object)hslColor;
        }

        /// <summary>
        /// We support CreateInstance
        /// </summary>
        /// <param name="context">designer context</param>
        /// <returns><see langword="true" /></returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        #endregion
    }
    #endregion
}
