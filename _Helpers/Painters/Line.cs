// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Line.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Reflection;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Class representing a line of any color, thickness, and dash style.
    /// </summary>
	[TypeConverter(typeof(Line.Converter))]
	[EditorAttribute(typeof(LineEditor), typeof(System.Drawing.Design.UITypeEditor))]
	public class Line
	{
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Line() : this(Color.Black)
		{
		}

        /// <summary>
        /// Constructor for a solid line of width 1.
        /// </summary>
        /// <param name="color">Line color.</param>
		public Line(Color color) : this(color, 1.0f)
		{
		}

        /// <summary>
        /// Constructor for a aolid line of any color and width.
        /// </summary>
        /// <param name="color">Line color.</param>
        /// <param name="width">Width in pixels.  A value of zero or less indicates an empty line.</param>
		public Line(Color color, float width) : this(color, width, DashStyle.Solid)
		{
		}

        /// <summary>
        /// Constructor for a line of any color, width and dashstyle.
        /// </summary>
        /// <param name="color">Line color.</param>
        /// <param name="width">Width in pixels.  A value of zero or less indicates an empty line.</param>
        /// <param name="dashStyle">Dashstyle.</param>
		public Line(Color color, float width, DashStyle dashStyle)
		{
			this.Color = color;
			this.Width = Math.Max(0.0f, width);
			this.DashStyle = dashStyle;
			this.DashPattern = null;
		}

        /// <summary>
        /// Constructor for a line with a custom dash pattern.
        /// </summary>
        /// <param name="color">Line color.</param>
        /// <param name="width">Width in pixels.  A value of zero or less indicates an empty line.</param>
        /// <param name="dashPattern">An array of real numbers that specifies the lengths of alternating dashes and spaces.</param>
		public Line(Color color, float width, float[] dashPattern)
		{
			this.Color = color;
			this.Width = Math.Max(0.0f, width);
			this.DashStyle = DashStyle.Custom;
			this.DashPattern = dashPattern;
		}

        /// <summary>
        /// Constructor for a line from another line.
        /// </summary>
        /// <param name="other"><c>Line</c> to copy.</param>
		public Line(Line other)
		{
			this.Color = other.Color;
			this.Width = other.Width;
			this.DashStyle = other.DashStyle;
			this.DashPattern = other.DashPattern;
		}

        /// <summary>
        /// Constructs an empty line.
        /// </summary>
        /// <returns>A <c>Line</c> with color <c>Color.Empty</c> and zero width.</returns>
		public static Line Empty()
		{
			return new Line(Color.Empty, 0.0f);
		}

        /// <summary>
        /// Creates an exact copy of this <c>Line</c>.
        /// </summary>
        /// <returns>A <c>Line</c>.</returns>
		public Line Clone()
		{
			return new Line(this);
		}

        /// <summary>
        /// Line color.
        /// </summary>
		public readonly Color Color;

        /// <summary>
        /// Line width (in pixels).
        /// </summary>
        public readonly float Width;

        /// <summary>
        /// Dashstyle.
        /// </summary>
        public readonly DashStyle DashStyle;

        /// <summary>
        /// Dash pattern.  Is <c>null</c> unless <c>DashStyle</c> is <c>DashStyle.Custom</c>.
        /// </summary>
        public readonly float[] DashPattern;

        /// <summary>
        /// <c>True</c> if empty, false otherwise.
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
		public bool IsEmpty
		{
			get { return Color.IsEmpty && (Width == 0.0f); }
		}

        /// <summary>
        /// The pen
        /// </summary>
        private Pen pen = null;

        /// <summary>
        /// Disposes the pen.
        /// </summary>
        private void DisposePen()
		{
			if (pen != null)
			{
				pen.Dispose();
				pen = null;
			}
		}

        /// <summary>
        /// Get pen for this line.
        /// </summary>
        /// <returns>Pen.</returns>
		public Pen GetPen()
		{
			if (pen == null)
			{
				pen = new Pen(Color, Width);
				pen.DashStyle = DashStyle;
				if (DashPattern != null)
				{
					pen.DashPattern = DashPattern;
				}
			}
			return pen;
		}

        /// <summary>
        /// Class Converter.
        /// </summary>
        /// <seealso cref="System.ComponentModel.TypeConverter" />
        internal class Converter : TypeConverter
		{
            /// <summary>
            /// Returns whether this converter can convert the object to the specified type, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
            /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
            /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) 
			{
				if (destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string))
				{
					return true;
				}
				return base.CanConvertTo(context, destinationType);
			}

            // This code allows the designer to generate the Fill constructor

            /// <summary>
            /// Converts the given value object to the specified type, using the specified context and culture information.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
            /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
            /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
            /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
            /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
            public override object ConvertTo(ITypeDescriptorContext context,
											 CultureInfo culture,
											 object value,
											 Type destinationType)
			{
				if (value is Line)
				{
					if (destinationType == typeof(string))
					{
						// Display string in designer
						return "(Line)";
					}
					else if (destinationType == typeof(InstanceDescriptor))
					{
						Line line = (Line)value;

						if (line.DashStyle == DashStyle.Custom)
						{
		                    ConstructorInfo ctor = typeof(Line).GetConstructor(new Type[] { typeof(Color),
																							typeof(float),
																							typeof(float[]) });
							if (ctor != null)
							{
								return new InstanceDescriptor(ctor, new object[] { line.Color,
																				   line.Width,
																				   line.DashPattern });
							}
						}
						else
						{
		                    ConstructorInfo ctor = typeof(Line).GetConstructor(new Type[] { typeof(Color),
																							typeof(float),
																							typeof(DashStyle) });
							if (ctor != null)
							{
								return new InstanceDescriptor(ctor, new object[] { line.Color,
																				   line.Width,
																				   line.DashStyle });
							}
						}
					}				
				}
				return base.ConvertTo(context, culture, value, destinationType);
			}
		}
	}
}

