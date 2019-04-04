// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Polygon.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace Zeroit.Framework.MiscControls.HelperControls.Widgets
{
    /// <summary>
    /// Class representing a polygon.
    /// </summary>
	[TypeConverter(typeof(Polygon.Converter))]
	[EditorAttribute(typeof(PolygonEditor), typeof(System.Drawing.Design.UITypeEditor))]
	public class Polygon
	{
        /// <summary>
        /// Constructor for an empty polygon.
        /// </summary>
        public Polygon() : this((PointF[])null)
		{
		}

        /// <summary>
        /// Constructor for a polygon from an array of points.
        /// </summary>
        /// <param name="points">Array of points.</param>
		public Polygon(PointF[] points)
		{
			pointList = new List<PointF>();
			if (points != null)
			{
				foreach (PointF p in points)
				{
					pointList.Add(p);
				}
			}
		}

        /// <summary>
        /// Constructor for a polygon from separate arrays of x and y coordinates.
        /// </summary>
        /// <param name="x">Array of x coordinates.</param>
        /// <param name="y">Array of y coordinates.</param>
        /// <exception cref="ArgumentException">One of <c>x</c> or <c>y</c> is <c>null</c>,
        /// or both <c>x</c> and <c>y</c> are not <c>null</c> but have different lengths.</exception>
		public Polygon(float[] x, float[] y)
		{
			if ((x == null && y != null) ||
				(x != null && y == null) ||
				(x != null && y != null && x.Length != y.Length))
			{
				throw new ArgumentException("X");
			}
			pointList = new List<PointF>();
			if (x != null && x.Length > 0)
			{
				for (int i = 0; i < x.Length; i++)
				{
					pointList.Add(new PointF(x[i], y[i]));
				}
			}
		}

        /// <summary>
        /// Constructor for a polygon from a list of points.
        /// </summary>
        /// <param name="list">List of points.</param>
        public Polygon(List<PointF> list) : this((list == null) ? (PointF[])null : list.ToArray())
		{
		}

        /// <summary>
        /// Constructor for a polygon from another instance of <c>Polygon</c>.
        /// </summary>
        /// <param name="other">Other instance of <c>Polygon</c>.</param>
        public Polygon(Polygon other) : this((other == null) ? null : other.pointList)
		{
		}

        /// <summary>
        /// Creates an exact copy of this <c>Polygon</c>.
        /// </summary>
        /// <returns>A new <c>Polygon</c> object.</returns>
        public Polygon Clone()
		{
			return new Polygon(pointList);
		}

        /// <summary>
        /// Add point to polygon.
        /// </summary>
        /// <param name="point">Point to add.</param>
		public void Add(PointF point)
		{
			pointList.Add(point);
		}

        /// <summary>
        /// Remove point from polygon.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException"><c>index</c> is less than 0 or
        /// <c>index</c> is equal or greater than <c>Count</c>.</exception>
		public void RemoveAt(int index)
		{
			pointList.RemoveAt(index);
		}

        /// <summary>
        /// Delete existing points.
        /// </summary>
		public void Clear()
		{
			pointList.Clear();
		}

        /// <summary>
        /// Gets the number of points in the polygon.
        /// </summary>
        /// <value>The number of points in the polygon.</value>
		public int Count
		{
			get { return pointList.Count; }
		}

        /// <summary>
        /// The point list
        /// </summary>
        private List<PointF> pointList;

        /// <summary>
        /// Gets the point at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The point at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><c>index</c> is less than 0 or
        /// <c>index</c> is equal or greater than <c>Count</c>.</exception>
		public PointF this [int index]
		{
			get { return pointList[index]; }
		}

        /// <summary>
        /// Gets an array containing copies of the points.
        /// </summary>
        /// <value>An array containing copies of the points.</value>
		public PointF[] Points
		{
			get { return pointList.ToArray(); }
		}

        /// <summary>
        /// Gets and array containing copies of the X coordinates.
        /// </summary>
        /// <value>An array containing copies of the X coordinates.</value>
		public float[] X
		{
			get
			{
				float[] x = new float[pointList.Count];
				for (int i = 0; i < pointList.Count; i++)
				{
					x[i] = pointList[i].X;
				}
                return x;
			}
		}

        /// <summary>
        /// Gets and array containing copies of the Y coordinates.
        /// </summary>
        /// <value>An array containing copies of the Y coordinates.</value>
		public float[] Y
		{
			get
			{
				float[] y = new float[pointList.Count];
				for (int i = 0; i < pointList.Count; i++)
				{
					y[i] = pointList[i].Y;
				}
                return y;
			}
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
				if (value is Polygon)
				{
					if (destinationType == typeof(string))
					{
						// Display string in designer
						return "(Polygon)";
					}
					else if (destinationType == typeof(InstanceDescriptor))
					{
	                    ConstructorInfo ctor = typeof(Polygon).GetConstructor(new Type[] { typeof(float[]),
	                    																   typeof(float[]) });

						if (ctor != null)
						{
							Polygon poly = (Polygon)value;
							return new InstanceDescriptor(ctor, new object[] { poly.X, poly.Y });
						}
					}				
				}
				return base.ConvertTo(context, culture, value, destinationType);
			}
		}
	}
}

