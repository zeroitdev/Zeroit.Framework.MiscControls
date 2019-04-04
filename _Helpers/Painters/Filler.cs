// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Filler.cs" company="Zeroit Dev Technologies">
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
    /// Specifies the type of fill.
    /// </summary>
	public enum FillerType
	{
        /// <summary>
        /// Specifies no fill.
        /// </summary>
        None,

        /// <summary>
        /// Specifies a solid fill in a single color.
        /// </summary>
        Solid,

        /// <summary>
        /// Specifies a hatched fill.
        /// </summary>
        Hatch,

        /// <summary>
        /// Specifies a color gradient fill in a fixed direction.
        /// </summary>
        LinearGradient,

        /// <summary>
        /// Specifies a color gradient fill which radiates out from a center point.
        /// </summary>
        PathGradient
    };

    /// <summary>
    /// Specifies the type of path gradient fill.
    /// </summary>
	public enum PathGradientType
	{
        /// <summary>
        /// Specifies a color gradient fill radiation out from a center point in a rectangular shape.
        /// </summary>
        Rect,

        /// <summary>
        /// Specifies a color gradient fill radiation out from a center point in a elliptical shape.
        /// </summary>
        Radial
    };

    /// <summary>
    /// Class representing a solid, hatched, or gradient fill.
    /// </summary>
    [TypeConverter(typeof(Filler.Converter))]
    [EditorAttribute(typeof(FillerEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public class Filler
    {
        /// <summary>
        /// Constructor for no fill.
        /// </summary>
        public Filler()
            : this(FillerType.None,
                   Color.Empty, Color.Empty,
                   HatchStyle.Cross,
                   0.0f, /* linearGradientAngle */
                   PathGradientType.Rect,
                   null) /* gradientColors */
        {
        }

        /// <summary>
        /// Constructor for solid fill.
        /// </summary>
        /// <param name="solidColor">Fill color.</param>
        public Filler(Color solidColor)
            : this(FillerType.Solid,
                   solidColor, solidColor,
                   HatchStyle.Cross,
                   0.0f, /* linearGradientAngle */
                   PathGradientType.Rect,
                   null) /* gradientColors */
        {
        }

        /// <summary>
        /// Constructor for hatched fill.
        /// </summary>
        /// <param name="hatchStyle">A <c>System.Drawing.Drawing2D.HatchStyle</c> enumeration value that specifies the style of hatching.</param>
        /// <param name="hatchColor">Hatch lines color.</param>
        /// <param name="backColor">Background color.</param>
        public Filler(HatchStyle hatchStyle, Color hatchColor, Color backColor)
            : this(FillerType.Hatch,
                   hatchColor, backColor,
                   hatchStyle,
                   0.0f, /* linearGradientAngle */
                   PathGradientType.Rect,
                   null) /* gradientColors */
        {
        }

        /// <summary>
        /// Constructor for a two color linear gradient fill.
        /// </summary>
        /// <param name="linearGradientAngle">Angle of gradient.</param>
        /// <param name="startColor">Starting color.</param>
        /// <param name="endColor">Ending color.</param>
        public Filler(float linearGradientAngle, Color startColor, Color endColor)
            : this(linearGradientAngle, Utils.NewColorBlend(startColor, endColor))
        {
        }

        /// <summary>
        /// Constructor for a multi color linear gradient fill.
        /// </summary>
        /// <param name="linearGradientAngle">Angle of gradient.</param>
        /// <param name="colors">Array of colors to use at corresponding positions along the gradient.</param>
        /// <param name="positions">Array of positions along the gradient.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="colors" /> or <paramref name="positions" /> is null.</exception>
        /// <remarks>Refer to the documentation of <c>System.Drawing.Drawing2D.ColorBlend</c> for more information about <c>colors</c> and <c>positions</c>.</remarks>
        public Filler(float linearGradientAngle, Color[] colors, float[] positions)
            : this(linearGradientAngle, Utils.NewColorBlend(colors, positions))
        {
        }

        /// <summary>
        /// Constructor for a multi color linear gradient fill.
        /// </summary>
        /// <param name="linearGradientAngle">Angle of gradient.</param>
        /// <param name="gradientColors">A <c>System.Drawing.Drawing2D.ColorBlend</c> object containing arrays of colors and positions defining a multi color gradient.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="gradientColors" /> is null.</exception>
        public Filler(float linearGradientAngle, ColorBlend gradientColors)
            : this(FillerType.LinearGradient,
                   gradientColors.Colors[0], gradientColors.Colors[gradientColors.Colors.Length - 1],
                   HatchStyle.Cross,
                   linearGradientAngle,
                   PathGradientType.Rect,
                   gradientColors)
        {
        }

        /// <summary>
        /// Constructor for a two color path gradient fill.
        /// </summary>
        /// <param name="pathGradientType">Type of path gradient.</param>
        /// <param name="startColor">Starting color.</param>
        /// <param name="endColor">Ending color.</param>
        public Filler(PathGradientType pathGradientType, Color startColor, Color endColor)
            : this(pathGradientType, Utils.NewColorBlend(startColor, endColor))
        {
        }

        /// <summary>
        /// Constructor for a multi color path gradient fill.
        /// </summary>
        /// <param name="pathGradientType">Type of path gradient.</param>
        /// <param name="colors">Array of colors to use at corresponding positions along the gradient.</param>
        /// <param name="positions">Array of positions along the gradient.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="colors" /> or <paramref name="positions" /> is null.</exception>
        /// <remarks>Refer to the documentation of <c>System.Drawing.Drawing2D.ColorBlend</c> for more information about <c>colors</c> and <c>positions</c>.</remarks>
        public Filler(PathGradientType pathGradientType, Color[] colors, float[] positions)
            : this(pathGradientType, Utils.NewColorBlend(colors, positions))
        {
        }

        /// <summary>
        /// Constructor for a multi color path gradient fill.
        /// </summary>
        /// <param name="pathGradientType">Type of path gradient.</param>
        /// <param name="gradientColors">A <c>System.Drawing.Drawing2D.ColorBlend</c> object containing arrays of colors and positions defining a multi color gradient.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="gradientColors" /> is null.</exception>
        public Filler(PathGradientType pathGradientType, ColorBlend gradientColors)
            : this(FillerType.PathGradient,
                   gradientColors.Colors[0], gradientColors.Colors[gradientColors.Colors.Length - 1],
                   HatchStyle.Cross,
                   0.0f, /* linearGradientAngle */
                   pathGradientType,
                   gradientColors)
        {
        }

        // Internal constructor 
        /// <summary>
        /// Initializes a new instance of the <see cref="Filler"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="color1">The color1.</param>
        /// <param name="color2">The color2.</param>
        /// <param name="hatchStyle">The hatch style.</param>
        /// <param name="linearGradientAngle">The linear gradient angle.</param>
        /// <param name="pathGradientType">Type of the path gradient.</param>
        /// <param name="gradientColors">The gradient colors.</param>
        private Filler(FillerType type,
                       Color color1, Color color2,
                       HatchStyle hatchStyle,
                       float linearGradientAngle,
                       PathGradientType pathGradientType,
                       ColorBlend gradientColors)
        {
            FillType = type;
            this.color1 = color1;
            this.color2 = color2;
            HatchStyle = hatchStyle;
            LinearGradientAngle = linearGradientAngle;
            PathGradientType = pathGradientType;
            GradientColors = (gradientColors == null) ? Utils.GetDefaultColorBlend() : gradientColors;
        }

        /// <summary>
        /// Creates an exact copy of this <c>Filler</c>.
        /// </summary>
        /// <returns>A <c>Filler</c>.</returns>
        public Filler Clone()
        {
            return new Filler(FillType,
                              color1, color2,
                              HatchStyle,
                              LinearGradientAngle,
                              PathGradientType,
                		      Utils.CloneColorBlend(GradientColors));
        }

        /// <summary>
        /// No fill constructor.
        /// </summary>
        /// <returns><c>Filler</c> no-fill object.</returns>
        public static Filler Empty()
        {
            return new Filler();
        }

        /// <summary>
        /// The color1
        /// </summary>
        private readonly Color color1;
        /// <summary>
        /// The color2
        /// </summary>
        private readonly Color color2;

        /// <summary>
        /// Type of fill.
        /// </summary>
        public readonly FillerType FillType;

        /// <summary>
        /// Hatch style in a hatched fill.
        /// </summary>
        public readonly HatchStyle HatchStyle;

        /// <summary>
        /// Direction of gradient fill if <c>FillType</c> is <c>LinearGradient</c>.
        /// </summary>
        public readonly float LinearGradientAngle;

        /// <summary>
        /// Type of path gradient fill if <c>FillType</c> is <c>PathGradient</c>.
        /// </summary>
        public readonly PathGradientType PathGradientType;

        /// <summary>
        /// Color blend for a linear or path gradient fill.
        /// </summary>
        public readonly ColorBlend GradientColors;

        /// <summary>
        /// Gets foreground color in a solid fill.
        /// </summary>
        /// <value>Foreground color in a solid fill.</value>
        public Color SolidColor { get { return color1; } }

        /// <summary>
        /// Gets foreground color in a hatched fill.
        /// </summary>
        /// <value>Foreground color in a hatched fill.</value>
        public Color HatchColor { get { return color1; } }

        /// <summary>
        /// Gets background color in a hatched fill.
        /// </summary>
        /// <value>Background color in a hatched fill.</value>
        public Color BackColor { get { return color2; } }

        /// <summary>
        /// Gets the UI type editor brush.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <returns>Brush.</returns>
        internal Brush GetUITypeEditorBrush(Rectangle bounds)
		{
			return GetBrush(bounds);
		}

        /// <summary>
        /// Get <c>Brush</c> for this fill.
        /// </summary>
        /// <param name="rect">Rectangle area to which fill is to be applied.</param>
        /// <returns>Brush.</returns>
        /// <remarks>The <c>rect</c> parameter only affects the brush if <c>FillerType</c> is <c>LinearGradient</c> or <c>PathGradient</c>.
        /// <para>
        /// The caller is responsible for disposing of the returned brush.
        /// </para></remarks>
        public Brush GetBrush(Rectangle rect)
        {
            return GetBrush(new RectangleF(rect.X, rect.Y, rect.Width, rect.Height));
        }

        /// <summary>
        /// Get <c>Brush</c> for this fill.
        /// </summary>
        /// <param name="rect">Rectangle area to which fill is to be applied.</param>
        /// <returns>Brush.</returns>
        /// <remarks>The <c>rect</c> parameter only affects the brush if <c>FillerType</c> is <c>LinearGradient</c> or <c>PathGradient</c>.
        /// <para>
        /// The caller is responsible for disposing of the returned brush.
        /// </para></remarks>
        public Brush GetBrush(RectangleF rect)
        {
            if (FillType == FillerType.Solid)
            {
                return new SolidBrush(SolidColor);
            }
            else if (FillType == FillerType.Hatch)
            {
                return new HatchBrush(HatchStyle, HatchColor, BackColor);
            }
            else if (FillType == FillerType.LinearGradient)
            {
                LinearGradientBrush brush = new LinearGradientBrush(rect,
	                                                                GradientColors.Colors[0],
    	                                                            GradientColors.Colors[GradientColors.Colors.Length - 1],
        	                                                        -1.0f * LinearGradientAngle, // we treat angle opposite
            	                                                    false);
                brush.InterpolationColors = GradientColors;
                return brush;
            }
            else if (FillType == FillerType.PathGradient)
            {
                GraphicsPath path = new GraphicsPath();
                if (PathGradientType == PathGradientType.Rect)
                {
                    path.AddRectangle(rect);
                }
                else
                {
                    path.AddEllipse(rect);
                }
                path.CloseFigure();
                PathGradientBrush brush = new PathGradientBrush(path);
				path.Dispose();
                brush.InterpolationColors = GradientColors;

                return brush;
            }

            return null;
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
				if (value is Filler)
				{
					if (destinationType == typeof(string))
					{
						// Display string in designer
						return "(Filler)";
					}
					else if (destinationType == typeof(InstanceDescriptor))
					{
						Filler filler = (Filler)value;

						if (filler.FillType == FillerType.Solid)
						{
		                    ConstructorInfo ctor = typeof(Filler).GetConstructor(new Type[] { typeof(Color) });
							if (ctor != null)
							{
								return new InstanceDescriptor(ctor, new object[] { filler.SolidColor });
							}
						}
		                else if (filler.FillType == FillerType.Hatch)
						{
                            ConstructorInfo ctor = typeof(Filler).GetConstructor(new Type[] { typeof(HatchStyle),
		                                                                                       typeof(Color),
		                                                                                       typeof(Color) });
							if (ctor != null)
							{
								return new InstanceDescriptor(ctor, new object[] { filler.HatchStyle,
																				   filler.HatchColor,
																				   filler.BackColor });
							}
						}
		                else if (filler.FillType == FillerType.LinearGradient)
						{
		                    ConstructorInfo ctor = typeof(Filler).GetConstructor(new Type[] { typeof(float),
		                    																   typeof(Color[]),
	        																				   typeof(float[]) });
							if (ctor != null)
							{
								return new InstanceDescriptor(ctor, new object[] { filler.LinearGradientAngle,
																				   filler.GradientColors.Colors,
																				   filler.GradientColors.Positions });
							}
						}
		                else if (filler.FillType == FillerType.PathGradient)
						{
		                    ConstructorInfo ctor = typeof(Filler).GetConstructor(new Type[] { typeof(PathGradientType),
		                    																   typeof(Color[]),
	        																				   typeof(float[]) });
							if (ctor != null)
							{
								return new InstanceDescriptor(ctor, new object[] { filler.PathGradientType,
																				   filler.GradientColors.Colors,
																				   filler.GradientColors.Positions });
							}
						}
						else
						{
		                    ConstructorInfo ctor = typeof(Filler).GetConstructor(Type.EmptyTypes);
							if (ctor != null)
							{
								return new InstanceDescriptor(ctor, null);
							}
						}
					}				
				}
				return base.ConvertTo(context, culture, value, destinationType);
			}
        }
    }
}

