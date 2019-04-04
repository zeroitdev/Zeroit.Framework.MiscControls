// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-07-2018
// ***********************************************************************
// <copyright file="IconInfoStructs.cs" company="Zeroit Dev Technologies">
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
using System.IO;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// header of multiple icon file
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
	public struct ICONDIR
	{
        #region fields
        /// <summary>
        /// The identifier reserved
        /// </summary>
        public short idReserved;
        /// <summary>
        /// The identifier type
        /// </summary>
        public short idType;
        /// <summary>
        /// The identifier count
        /// </summary>
        public short idCount;
        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="ICONDIR"/> struct.
        /// </summary>
        /// <param name="idcount">The idcount.</param>
        public ICONDIR(short idcount)
		{
			this.idCount=idcount;
			this.idReserved=0;
			this.idType=1;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="ICONDIR"/> struct.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.ArgumentNullException">str - null reference in ICONDIR.ctor</exception>
        public unsafe ICONDIR(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str","null reference in ICONDIR.ctor");
			byte[] buffer=new byte[sizeof(ICONDIR)];
			str.Read(buffer,0,buffer.Length);
			fixed(byte* ptbuffer=buffer)
			{
				this=*(ICONDIR*)ptbuffer;
			}
		}
        /// <summary>
        /// Writes the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.ArgumentNullException">str - null reference in ICONDIR.Write</exception>
        public unsafe void Write(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str","null reference in ICONDIR.Write");
			byte[] buffer=new byte[sizeof(ICONDIR)];
			fixed(ICONDIR* ptthis=&this)
			{
				Marshal.Copy((IntPtr)ptthis,buffer,0,buffer.Length);
			}
			str.Write(buffer,0,buffer.Length);
		}
	}
    /// <summary>
    /// header of icon image inside .ico
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
	public struct ICONDIRENTRY
	{
        #region fields
        /// <summary>
        /// The width
        /// </summary>
        public byte Width;
        /// <summary>
        /// The height
        /// </summary>
        public byte Height;
        /// <summary>
        /// The color count
        /// </summary>
        public byte ColorCount;
        /// <summary>
        /// The reserved
        /// </summary>
        public byte Reserved;
        /// <summary>
        /// The planes
        /// </summary>
        public short Planes;
        /// <summary>
        /// The bits per pixel
        /// </summary>
        public short BitsPerPixel;
        /// <summary>
        /// The size in bytes
        /// </summary>
        public int SizeInBytes;
        /// <summary>
        /// The file offset
        /// </summary>
        public int FileOffset;
        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="ICONDIRENTRY"/> struct.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="colorcount">The colorcount.</param>
        /// <param name="bitsperpixel">The bitsperpixel.</param>
        /// <param name="sizeinbytes">The sizeinbytes.</param>
        public ICONDIRENTRY(
			byte width,
			byte height,
			byte colorcount,
			short bitsperpixel,
			int sizeinbytes)
		{
			this.Width=width;
			this.Height=height;
			this.ColorCount=colorcount;
			this.Reserved=0;
			this.Planes=1;
			this.BitsPerPixel=bitsperpixel;
			this.SizeInBytes=sizeinbytes;
			this.FileOffset=0;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="ICONDIRENTRY"/> struct.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.ArgumentNullException">str - null reference in ICONDIRENTRY.ctor</exception>
        public unsafe ICONDIRENTRY(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str","null reference in ICONDIRENTRY.ctor");
			byte[] buffer=new byte[sizeof(ICONDIRENTRY)];
			str.Read(buffer,0,buffer.Length);
			fixed(byte* ptbuffer=buffer)
			{
				this=*(ICONDIRENTRY*)ptbuffer;
			}
		}
        /// <summary>
        /// Writes the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.ArgumentNullException">str - null reference in ICONDIRENTRY.Write</exception>
        public unsafe void Write(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str","null reference in ICONDIRENTRY.Write");
			byte[] buffer=new byte[sizeof(ICONDIRENTRY)];
			fixed(ICONDIRENTRY* ptthis=&this)
			{
				Marshal.Copy((IntPtr)ptthis,buffer,0,buffer.Length);
			}
			str.Write(buffer,0,buffer.Length);
		}
	}
    /// <summary>
    /// header of icon image inside .dll
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
	public struct MEMICONDIRENTRY
	{
        #region fields
        /// <summary>
        /// The width
        /// </summary>
        public byte Width;
        /// <summary>
        /// The height
        /// </summary>
        public byte Height;
        /// <summary>
        /// The color count
        /// </summary>
        public byte ColorCount;
        /// <summary>
        /// The reserved
        /// </summary>
        public byte Reserved;
        /// <summary>
        /// The planes
        /// </summary>
        public short Planes;
        /// <summary>
        /// The bits per pixel
        /// </summary>
        public short BitsPerPixel;
        /// <summary>
        /// The size in bytes
        /// </summary>
        public int SizeInBytes;
        /// <summary>
        /// The identifier
        /// </summary>
        public short ID;
        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="MEMICONDIRENTRY"/> struct.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.ArgumentNullException">str - null reference in MEMICONDIRENTRY.ctor</exception>
        public unsafe MEMICONDIRENTRY(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str","null reference in MEMICONDIRENTRY.ctor");
			byte[] buffer=new byte[sizeof(MEMICONDIRENTRY)];
			str.Read(buffer,0,buffer.Length);
			fixed(byte* ptbuffer=buffer)
			{
				this=*(MEMICONDIRENTRY*)ptbuffer;
			}		
		}
        /// <summary>
        /// Writes the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.ArgumentNullException">str - null reference in MEMICONDIRENTRY.Write</exception>
        public unsafe void Write(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str","null reference in MEMICONDIRENTRY.Write");
			byte[] buffer=new byte[sizeof(MEMICONDIRENTRY)];
			fixed(MEMICONDIRENTRY* ptthis=&this)
			{
				Marshal.Copy((IntPtr)ptthis,buffer,0,buffer.Length);
			}
			str.Write(buffer,0,buffer.Length);
		}
	}
    /// <summary>
    /// header of bitmap data
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=2)]
	public struct BITMAPINFOHEADER
	{
        #region fields
        /// <summary>
        /// The size
        /// </summary>
        public int Size;
        /// <summary>
        /// The width
        /// </summary>
        public int Width;
        /// <summary>
        /// The height
        /// </summary>
        public int Height;
        /// <summary>
        /// The planes
        /// </summary>
        public short Planes;
        /// <summary>
        /// The bit count
        /// </summary>
        public short BitCount;
        /// <summary>
        /// The compression
        /// </summary>
        public int Compression;
        /// <summary>
        /// The size image
        /// </summary>
        public int SizeImage;
        /// <summary>
        /// The x pixels per meter
        /// </summary>
        public int XPixelsPerMeter;
        /// <summary>
        /// The y pixels per meter
        /// </summary>
        public int YPixelsPerMeter;
        /// <summary>
        /// The colors used
        /// </summary>
        public int ColorsUsed;
        /// <summary>
        /// The colors important
        /// </summary>
        public int ColorsImportant;
        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="BITMAPINFOHEADER"/> struct.
        /// </summary>
        /// <param name="sz">The sz.</param>
        /// <param name="bitcount">The bitcount.</param>
        /// <param name="sizeimage">The sizeimage.</param>
        /// <param name="colorcount">The colorcount.</param>
        public BITMAPINFOHEADER(
			System.Drawing.Size sz,
			short bitcount,
			int sizeimage,
			int colorcount)
		{
			this.Size=40;
			this.Width=sz.Width;
			this.Height=sz.Height*2;
			this.Planes=1;
			this.BitCount=bitcount;
			this.Compression=0;
			this.SizeImage=sizeimage;
			this.XPixelsPerMeter=0;
			this.YPixelsPerMeter=0;
			this.ColorsUsed=
				this.ColorsImportant=colorcount;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="BITMAPINFOHEADER"/> struct.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.ArgumentNullException">str - null reference in BITMAPINFOHEADER.ctor</exception>
        public unsafe BITMAPINFOHEADER(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str","null reference in BITMAPINFOHEADER.ctor");
			byte[] buffer=new byte[sizeof(BITMAPINFOHEADER)];
			str.Read(buffer,0,buffer.Length);
			fixed(byte* ptbuffer=buffer)
			{
				this=*(BITMAPINFOHEADER*)ptbuffer;
			}
		}
        /// <summary>
        /// Writes the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.ArgumentNullException">str - null reference in BITMAPINFOHEADER.Write</exception>
        public unsafe void Write(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str","null reference in BITMAPINFOHEADER.Write");
			byte[] buffer=new byte[sizeof(BITMAPINFOHEADER)];
			fixed(BITMAPINFOHEADER* ptthis=&this)
			{
				Marshal.Copy((IntPtr)ptthis,buffer,0,buffer.Length);
			}
			str.Write(buffer,0,buffer.Length);
		}
	}
}
