// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 12-04-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PointFConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.ComponentModel;


namespace Zeroit.Framework.MiscControls
{


    #region PointFConverter

    /// <summary>
    /// Class PointFConverter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.ExpandableObjectConverter" />
    internal class PointFConverter : ExpandableObjectConverter
	{
        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{

			if (sourceType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);

		}

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> to use as the current culture.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{

			if (value is string)
			{
				try
				{
					string s = Convert.ToString(value);
					string[] ConverterParts = new string[3];
					ConverterParts = s.Split(',');
					if (!((ConverterParts == null)))
					{
						if ((ConverterParts[0] == null))
						{
							ConverterParts[0] = "-5";
						}
						if ((ConverterParts[1] == null))
						{
							ConverterParts[1] = "-2.5";
						}
						return new PointF(Convert.ToSingle(ConverterParts[0].Trim()), Convert.ToSingle(ConverterParts[1].Trim()));
					}
				}
				catch (Exception ex)
				{
					throw new ArgumentException(string.Format("Can not convert '{0}' to type Corners", Convert.ToString(value)));
				}
			}
			else
			{
				return new PointF(-5.0F, -2.5F);
			}

			return base.ConvertFrom(context, culture, value);

		}

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{

			if (destinationType == typeof(string) && value is PointF)
			{

				PointF ConverterProperty = (PointF)value;
				// build the string representation 
				return string.Format("{0}, {1}", ConverterProperty.X, ConverterProperty.Y);
			}
			return base.ConvertTo(context, culture, value, destinationType);

		}

	} //PointFConverter Class

#endregion
    

}