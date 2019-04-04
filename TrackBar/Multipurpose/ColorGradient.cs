// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 12-04-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-04-2018
// ***********************************************************************
// <copyright file="ColorGradient.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Design;


namespace Zeroit.Framework.MiscControls
{

    #region Color Linear Gradient

    #region ColorLinearGradient Class

    /// <summary>
    /// Class ColorLinearGradient.
    /// </summary>
    public class ColorLinearGradient
	    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorLinearGradient"/> class.
        /// </summary>
        public ColorLinearGradient()
		    {
			    _ColorA = Color.Blue;
			    _ColorB = Color.Black;
		    }
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorLinearGradient"/> class.
        /// </summary>
        /// <param name="ColorA">The color a.</param>
        /// <param name="ColorB">The color b.</param>
        public ColorLinearGradient(Color ColorA, Color ColorB)
		    {
			    _ColorA = ColorA;
			    _ColorB = ColorB;
		    }

        /// <summary>
        /// The color a
        /// </summary>
        private Color _ColorA = Color.Blue;
        /// <summary>
        /// Gets or sets the color a.
        /// </summary>
        /// <value>The color a.</value>
        public Color ColorA
		    {
			    get
			    {
				    return _ColorA;
			    }
			    set
			    {
				    _ColorA = value;
			    }
		    }

        /// <summary>
        /// The color b
        /// </summary>
        private Color _ColorB = Color.Black;
        /// <summary>
        /// Gets or sets the color b.
        /// </summary>
        /// <value>The color b.</value>
        public Color ColorB
		    {
			    get
			    {
				    return _ColorB;
			    }
			    set
			    {
				    _ColorB = value;
			    }
		    }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
		    {
			    return string.Format("{0};{1}", getColorString(_ColorA), getColorString(_ColorB));
		    }

        /// <summary>
        /// Gets the color string.
        /// </summary>
        /// <param name="scolor">The scolor.</param>
        /// <returns>System.String.</returns>
        private string getColorString(Color scolor)
		    {
			    if (scolor.IsNamedColor)
			    {
				    return scolor.Name;
			    }
			    else
			    {
				    return string.Format("{0},{1},{2},{3}", scolor.A, scolor.R, scolor.G, scolor.B);
			    }
		    }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
		    {
			    return this.ToString() == ((ColorLinearGradient)obj).ToString();
		    }

	    }

    #endregion

    #region ColorLinearGradientConverter

    /// <summary>
    /// Class ColorLinearGradientConverter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.ExpandableObjectConverter" />
    internal class ColorLinearGradientConverter : ExpandableObjectConverter
	    {
        /// <summary>
        /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> to create a new value, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)" /> to create a new value; otherwise, false.</returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
		    {
			    return true;
		    }

        /// <summary>
        /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter" /> is associated with, using the specified context, given a set of property values for the object.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="propertyValues">An <see cref="T:System.Collections.IDictionary" /> of new property values.</param>
        /// <returns>An <see cref="T:System.Object" /> representing the given <see cref="T:System.Collections.IDictionary" />, or null if the object cannot be created. This method always returns null.</returns>
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
		    {
			    ColorLinearGradient Item = new ColorLinearGradient();
			    Item.ColorA = (Color)propertyValues["ColorA"];
			    Item.ColorB = (Color)propertyValues["ColorB"];
			    return Item;
		    }

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
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		    {


			    if (value is string)
			    {
				    try
				    {
					    List<Color> bColors = new List<Color>();

					    foreach (string cstring in Convert.ToString(value).Split(';'))
					    {
						    bColors.Add((Color)(TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(cstring)));
					    }

					    if (!((bColors == null)) && bColors.Count != 2)
					    {
						    throw new ArgumentException();
					    }
					    else
					    {
						    return new ColorLinearGradient(bColors[0], bColors[1]);
					    }
				    }
				    catch (Exception ex)
				    {
					    throw new ArgumentException(string.Format("Can not convert '{0}' to type ColorLinearGradient", Convert.ToString(value)));
				    }

			    }
			    else
			    {
				    return new ColorLinearGradient();
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

			    if (destinationType == typeof(string) && value is ColorLinearGradient)
			    {
				    return ((ColorLinearGradient)value).ToString();
			    }
			    return base.ConvertTo(context, culture, value, destinationType);

		    }

	    }

    #endregion

    #region ColorLinearGradientEditor

    /// <summary>
    /// Class ColorLinearGradientEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class ColorLinearGradientEditor : UITypeEditor
	    {
        /// <summary>
        /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)" /> is implemented; otherwise, false.</returns>
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		    {

			    return true;

		    }

        /// <summary>
        /// Paints a representation of the value of an object using the specified <see cref="T:System.Drawing.Design.PaintValueEventArgs" />.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Drawing.Design.PaintValueEventArgs" /> that indicates what to paint and where to paint it.</param>
        public override void PaintValue(PaintValueEventArgs e)
		    {
			    // Erase the area.
			    e.Graphics.FillRectangle(Brushes.White, e.Bounds);

			    ColorLinearGradient cLinearGradient = null;
			    if ((e.Context == null))
			    {
				    cLinearGradient = new ColorLinearGradient();
			    }
			    else
			    {
				    cLinearGradient = (ColorLinearGradient)e.Value;
			    }
			    // Draw the sample.
			    using (Pen border_pen = new Pen(Color.Black, 1F))
			    {
				    using (LinearGradientBrush br = new LinearGradientBrush(e.Bounds, cLinearGradient.ColorA, cLinearGradient.ColorB, LinearGradientMode.Horizontal))
				    {

					    e.Graphics.FillRectangle(br, e.Bounds);

				    }

				    e.Graphics.DrawRectangle(border_pen, 1, 1, e.Bounds.Width - 1, e.Bounds.Height - 1);
			    }

		    }
	    }

    #endregion

    #endregion

}