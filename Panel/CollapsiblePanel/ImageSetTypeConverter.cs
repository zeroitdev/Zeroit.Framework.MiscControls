// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ImageSetTypeConverter.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Reflection;

namespace Zeroit.Framework.MiscControls
{
    #region ImageSetTypeConverter
    /// <summary>
    /// ImageSetTypeConverter designed to provide an alternate
    /// constructor for designer code-generation.
    /// </summary>
    /// <seealso cref="System.ComponentModel.TypeConverter" />
    /// <remarks>This class is no longer used. Although the implementation is valid, various
    /// issues with the designer and <see cref="ImageSet" /> prevent this technique
    /// from working (at least out-of-the-box).</remarks>
	public class ImageSetTypeConverter : TypeConverter
    {
        /// <summary>
        /// Create an <c>ImageSetTypeConverter</c>
        /// </summary>
        public ImageSetTypeConverter() { }

        /// <summary>
        /// Tell the designer we can convert to <see cref="InstanceDescriptor" /> so
        /// that we can use an alternate constructor during code-generation.
        /// </summary>
        /// <param name="context">designer context</param>
        /// <param name="destinationType">target conversion type</param>
        /// <returns><see langword="true" /> if an <see cref="InstanceDescriptor" /> is requested,
        /// otherwise whatever the base class says</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        /// <summary>
        /// Handle a conversion
        /// </summary>
        /// <param name="context">designer context</param>
        /// <param name="culture">globalization info</param>
        /// <param name="value">The value to be converted</param>
        /// <param name="destinationType">Target type</param>
        /// <returns>An instance of the <c>destinationType</c></returns>
        /// <remarks>This code specifically handles conversion to a <see cref="InstanceDescriptor" /> so that
        /// the <see cref="ImageSet" /> can be created using a constructor of the form:
        /// <code>
        /// new ImageSet(<see cref="System.Drawing.Size" />,<see cref="Color" />) ;
        /// </code><para>
        /// Note, the <see cref="InstanceDescriptor" /> is told that the instance may need further
        /// initialization beyond the values provided to the constructor
        /// </para></remarks>
        public override object ConvertTo(
            ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture,
            object value,
            Type destinationType
            )
        {
            if ((destinationType == typeof(InstanceDescriptor)) && (value is ImageSet))
            {
                ImageSet imageSet = value as ImageSet;
                ConstructorInfo ctorInfo = typeof(ImageSet).GetConstructor(new Type[] { typeof(Size), typeof(Color) });
                if (ctorInfo != null)
                {
                    return new InstanceDescriptor(ctorInfo, new object[] { imageSet.Size, imageSet.TransparentColor }, false);
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    #endregion
}
