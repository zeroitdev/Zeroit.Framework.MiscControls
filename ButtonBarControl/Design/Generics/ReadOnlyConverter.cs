// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="ReadOnlyConverter.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ReadOnlyConverter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.TypeConverter" />
    internal class ReadOnlyConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return false;
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return false;
        }

        /// <summary>
        /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> to create a new value, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> to create a new value; otherwise, false.</returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> should be called to find the properties of this object; otherwise, false.</returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="value">An <see cref="T:System.Object" /> that specifies the type of array for which to get properties.</param>
        /// <param name="attributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> with the properties that are exposed for this data type, or null if there are no properties.</returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value,
                                                                   Attribute[] attributes)
        {
            var init = TypeDescriptor.GetProperties(value.GetType(), attributes);
            var pds = new PropertyDescriptor[init.Count];
            for (var i = 0; i < init.Count; i++)
            {
                if (!init[i].IsBrowsable)
                    continue;
                var attrs = new List<Attribute>();
                for (var j = 0; j < attributes.Length; j++)
                {
                    attrs.Add(attributes[j]);
                }
                attrs.Add(new ReadOnlyAttribute(true));
                if (init[i].Converter == null || !init[i].Converter.GetType().Assembly.GlobalAssemblyCache)
                {
                    attrs.Add(new TypeConverterAttribute(typeof (ReadOnlyConverter)));
                }
                attrs.Add(new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden));
                pds[i] = new PD(init[i].ComponentType, init[i].Name, init[i].PropertyType, attrs.ToArray());
            }
            return new PropertyDescriptorCollection(pds);
        }

        #region Nested type: PD

        /// <summary>
        /// Class PD.
        /// </summary>
        /// <seealso cref="System.ComponentModel.TypeConverter.SimplePropertyDescriptor" />
        private class PD : SimplePropertyDescriptor
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PD"/> class.
            /// </summary>
            /// <param name="componentType">A <see cref="T:System.Type" /> that represents the type of component to which this property descriptor binds.</param>
            /// <param name="name">The name of the property.</param>
            /// <param name="propertyType">A <see cref="T:System.Type" /> that represents the data type for this property.</param>
            /// <param name="attributes">An <see cref="T:System.Attribute" /> array with the attributes to associate with the property.</param>
            public PD(Type componentType, string name, Type propertyType, Attribute[] attributes)
                : base(componentType, name, propertyType, attributes)
            {
            }

            #region Overrides of PropertyDescriptor

            /// <summary>
            /// When overridden in a derived class, gets the current value of the property on a component.
            /// </summary>
            /// <param name="component">The component with the property for which to retrieve the value.</param>
            /// <returns>The value of a property for a given component.</returns>
            public override object GetValue(object component)
            {
                return component.GetType().GetProperty(Name).GetValue(component, null);
            }

            /// <summary>
            /// When overridden in a derived class, sets the value of the component to a different value.
            /// </summary>
            /// <param name="component">The component with the property value that is to be set.</param>
            /// <param name="value">The new value.</param>
            public override void SetValue(object component, object value)
            {
            }

            #endregion
        }

        #endregion
    }
}