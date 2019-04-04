// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 12-04-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-04-2018
// ***********************************************************************
// <copyright file="ColorPack.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Design;


namespace Zeroit.Framework.MiscControls
{

    #region ColorPack

    #region ColorPack Class

    /// <summary>
    /// Class ColorPack.
    /// </summary>
    public class ColorPack
	    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPack"/> class.
        /// </summary>
        public ColorPack()
		    {
			    _border = Color.Black;
			    _face = Color.DarkGray;
			    _highlight = Color.AliceBlue;
		    }
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPack"/> class.
        /// </summary>
        /// <param name="Border">The border.</param>
        /// <param name="Face">The face.</param>
        /// <param name="Highlight">The highlight.</param>
        public ColorPack(Color Border, Color Face, Color Highlight)
		    {
			    _border = Border;
			    _face = Face;
			    _highlight = Highlight;
		    }

        /// <summary>
        /// The border
        /// </summary>
        private Color _border = Color.Black;
        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        public Color Border
		    {
			    get
			    {
				    return _border;
			    }
			    set
			    {
				    _border = value;
			    }
		    }

        /// <summary>
        /// The face
        /// </summary>
        private Color _face = Color.DarkGray;
        /// <summary>
        /// Gets or sets the face.
        /// </summary>
        /// <value>The face.</value>
        public Color Face
		    {
			    get
			    {
				    return _face;
			    }
			    set
			    {
				    _face = value;
			    }
		    }

        /// <summary>
        /// The highlight
        /// </summary>
        private Color _highlight = Color.AliceBlue;
        /// <summary>
        /// Gets or sets the highlight.
        /// </summary>
        /// <value>The highlight.</value>
        public Color Highlight
		    {
			    get
			    {
				    return _highlight;
			    }
			    set
			    {
				    _highlight = value;
			    }
		    }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
		    {
			    return string.Format("{0};{1};{2}", getColorString(_border), getColorString(_face), getColorString(_highlight));
		    }

        /// <summary>
        /// Gets the color string.
        /// </summary>
        /// <param name="bcolor">The bcolor.</param>
        /// <returns>System.String.</returns>
        private string getColorString(Color bcolor)
		    {
			    if (bcolor.IsNamedColor)
			    {
				    return bcolor.Name;
			    }
			    else
			    {
				    return string.Format("{0},{1},{2},{3}", bcolor.A, bcolor.R, bcolor.G, bcolor.B);
			    }
		    }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
		    {
			    return this.ToString() == ((ColorPack)obj).ToString();
		    }

	    }
    #endregion

    #region ColorPackConverter

    /// <summary>
    /// Class ColorPackConverter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.ExpandableObjectConverter" />
    internal class ColorPackConverter : ExpandableObjectConverter
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
			    ColorPack Item = new ColorPack();
			    Item.Border = (Color)propertyValues["Border"];
			    Item.Face = (Color)propertyValues["Face"];
			    Item.Highlight = (Color)propertyValues["Highlight"];
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

					    if (!((bColors == null)) && bColors.Count != 3)
					    {
						    throw new ArgumentException();
					    }
					    else
					    {
						    return new ColorPack(bColors[0], bColors[1], bColors[2]);
					    }
				    }
				    catch (Exception ex)
				    {
					    throw new ArgumentException(string.Format("Can not convert '{0}' to type ColorPack", Convert.ToString(value)));
				    }

			    }
			    else
			    {
				    return new ColorPack();
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

			    if (destinationType == typeof(string) && value is ColorPack)
			    {
				    return ((ColorPack)value).ToString();
			    }
			    return base.ConvertTo(context, culture, value, destinationType);

		    }

	    }

    #endregion

    #region ColorPackEditor

    /// <summary>
    /// Class ColorPackEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class ColorPackEditor : UITypeEditor
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

			    ColorPack cPack = null;
			    if ((e.Context == null))
			    {
				    cPack = new ColorPack();
			    }
			    else
			    {
				    cPack = (ColorPack)e.Value;
			    }
			    // Draw the sample.
			    using (Pen border_pen = new Pen(cPack.Border, 2F))
			    {
				    using (GraphicsPath gp = new GraphicsPath())
				    {
					    gp.AddRectangle(e.Bounds);
					    if (e.Context.PropertyDescriptor.DisplayName == "AButColor" || (((ZeroitMultiTrackBar)e.Context.Instance).BrushStyle == ZeroitMultiTrackBar.eBrushStyle.Linear || ((ZeroitMultiTrackBar)e.Context.Instance).BrushStyle == ZeroitMultiTrackBar.eBrushStyle.Linear2))
					    {
						    using (LinearGradientBrush br = new LinearGradientBrush(gp.GetBounds(), cPack.Highlight, cPack.Face, LinearGradientMode.Horizontal))
						    {
	
							    e.Graphics.FillPath(br, gp);
	
						    }
					    }
					    else
					    {
						    using (PathGradientBrush br = new PathGradientBrush(gp))
						    {
							    br.SurroundColors = new Color[] {cPack.Face};
							    br.CenterColor = cPack.Highlight;
							    br.CenterPoint = new PointF(br.CenterPoint.X - 5, Convert.ToSingle(br.CenterPoint.Y - 2.5));
							    br.FocusScales = new PointF(0F, 0F);
							    e.Graphics.FillPath(br, gp);
						    }
					    }
	
					    e.Graphics.DrawRectangle(border_pen, 2, 2, e.Bounds.Width - 2, e.Bounds.Height - 2);
				    }
			    }

		    }
	    }

    #endregion

    #endregion

}