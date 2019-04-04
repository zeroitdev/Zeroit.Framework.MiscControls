// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-07-2018
// ***********************************************************************
// <copyright file="ColorBgra.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// encapsulates a bgra color structure
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
	public struct ColorBgra
	{
        #region fields
        //components
        /// <summary>
        /// The b
        /// </summary>
        [FieldOffset(0)]
		public byte B;
        /// <summary>
        /// The g
        /// </summary>
        [FieldOffset(1)]
		public byte G;
        /// <summary>
        /// The r
        /// </summary>
        [FieldOffset(2)]
		public byte R;
        /// <summary>
        /// a
        /// </summary>
        [FieldOffset(3)]
		public byte A;
        #endregion
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorBgra"/> struct.
        /// </summary>
        /// <param name="argb">The ARGB.</param>
        public ColorBgra(uint argb)
		{
			this.A=(byte)(argb>>24);
			this.R=(byte)(argb>>16);
			this.G=(byte)(argb>>8);
			this.B=(byte)(argb);
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorBgra"/> struct.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        public ColorBgra(byte r, byte g, byte b):
			this((byte)255,r,g,b){}
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorBgra"/> struct.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        public ColorBgra(byte a, byte r, byte g, byte b)
		{
			this.A=a;
			this.R=r;
			this.G=g;
			this.B=b;
		}
        #endregion
        #region constants
        /// <summary>
        /// Gets the transparent.
        /// </summary>
        /// <value>The transparent.</value>
        public static ColorBgra Transparent
		{
			get{return new ColorBgra(0x00000000);}
		}
        /// <summary>
        /// Gets the black.
        /// </summary>
        /// <value>The black.</value>
        public static ColorBgra Black
		{
			get{return new ColorBgra(0xff000000);}
		}
        /// <summary>
        /// Gets the white.
        /// </summary>
        /// <value>The white.</value>
        public static ColorBgra White
		{
			get{return new ColorBgra(0xffffffff);}
		}
        #endregion
        #region properties
        /// <summary>
        /// gets or sets the alpha component of the color within range 0-255
        /// </summary>
        /// <value>The alpha.</value>
        public int Alpha
		{
			get{return (int)A;}
			set
			{
				A=(byte)Math.Min(255,Math.Max(0,value));
			}
		}
        /// <summary>
        /// gets or sets the red component of the color within range 0-255
        /// </summary>
        /// <value>The red.</value>
        public int Red
		{
			get{return (int)R;}
			set
			{
				R=(byte)Math.Min(255,Math.Max(0,value));
			}
		}
        /// <summary>
        /// gets or sets the green component of the color within range 0-255
        /// </summary>
        /// <value>The green.</value>
        public int Green
		{
			get{return (int)G;}
			set
			{
				G=(byte)Math.Min(255,Math.Max(0,value));
			}
		}
        /// <summary>
        /// gets or sets the blue component of the color within range 0-255
        /// </summary>
        /// <value>The blue.</value>
        public int Blue
		{
			get{return (int)B;}
			set
			{
				B=(byte)Math.Min(255,Math.Max(0,value));
			}
		}
        #endregion
        #region conversion
        /// <summary>
        /// converts a system.drawing.color to colorbgra
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>ColorBgra.</returns>
        public static ColorBgra FromArgb(Color value)
		{
			return new ColorBgra(
				(byte)value.A,
				(byte)value.R,
				(byte)value.G,
				(byte)value.B);
		}
        /// <summary>
        /// converts a colorbgra to system.drawing.color
        /// </summary>
        /// <returns>Color.</returns>
        public Color ToArgb()
		{
			return Color.FromArgb(
				(int)A,
				(int)R,
				(int)G,
				(int)B);
		}
		#endregion
	}
}
