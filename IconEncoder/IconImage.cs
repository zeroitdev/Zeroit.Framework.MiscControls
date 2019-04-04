// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="IconImage.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// abstract base class of iconimage which encapsulates an image inside of icon
    /// </summary>
    public unsafe abstract class IconImage
	{
        /// <summary>
        /// used to apply an AND mask to bitmap/stream
        /// </summary>
        protected class ANDMap
		{
            /// <summary>
            /// Prevents a default instance of the <see cref="ANDMap"/> class from being created.
            /// </summary>
            private ANDMap(){}
            /// <summary>
            /// applies an AND mask found in the stream to the specified bitmap
            /// </summary>
            /// <param name="rdr">The RDR.</param>
            /// <param name="bd">The bd.</param>
            public static void StampToBitmapData(SimpleReader rdr, BitmapData bd)
			{
				int* scan0=(int*)bd.Scan0;
				scan0+=bd.Width*bd.Height;
				for(int y=0; y<bd.Height; y++)
				{
					scan0-=bd.Width;
					int maskpos=7,
						maskdata=rdr.ReadInt32();
					for(int x=0; x<bd.Width; x++)
					{
						if(maskpos>=32)//read next value
						{
							maskdata=rdr.ReadInt32();
							maskpos-=32;
						}
						if((maskdata&(1<<maskpos))!=0)//pixel is transparent
							scan0[x]=0;

						//every byte holds 8 pixels, its highest order bit
						//representing the leftmost pixel of those
						if(maskpos%8==0)
							maskpos+=15;
						else
							maskpos--;
					}
				}
			}
            /// <summary>
            /// writes an AND mask found in the bitmap to the specified stream
            /// </summary>
            /// <param name="bd">The bd.</param>
            /// <param name="wrt">The WRT.</param>
            public static void WriteToStream(BitmapData bd, SimpleWriter wrt)
			{
				int* scan0=(int*)bd.Scan0;
				scan0+=bd.Width*bd.Height;
				for(int y=0; y<bd.Height; y++)
				{
					scan0-=bd.Width;
					int maskpos=7,
						maskdata=0;//no bits set, all transparent
					for(int x=0; x<bd.Width; x++)
					{
						if((scan0[x]&0xFF000000)==0)//transparent
							maskdata|=(1<<maskpos);

						//every byte holds 8 pixels, its highest order bit
						//representing the leftmost pixel of those
						if(maskpos%8==0)
							maskpos+=15;
						else
							maskpos--;
						if(maskpos>=32)
						{
							wrt.Write(maskdata);
							maskdata=0;
							maskpos-=32;
						}
					}
					if(maskpos!=7)
						wrt.Write(maskdata);
				}
			}
            /// <summary>
            /// gets the size in bytes of a 1-bit uncompressed bitmap
            /// with the specified size
            /// </summary>
            /// <param name="sz">The sz.</param>
            /// <returns>System.Int32.</returns>
            public static int GetSizeInBytes(Size sz)
			{
				int rem;
				int stridedws=Math.DivRem(sz.Width,32,out rem);
				//pad to 32bit boundary
				if(rem!=0) stridedws+=1;
				return stridedws*sz.Height*4;
			}
		}
        #region variables
        /// <summary>
        /// The bitmap
        /// </summary>
        protected Bitmap _bitmap;
        /// <summary>
        /// The bitsperpixel
        /// </summary>
        protected short _bitsperpixel;
        #endregion
        /// <summary>
        /// creates an empty iconimage,
        /// not accessible outside the dll
        /// </summary>
        internal IconImage(){}
        #region static constructors
        /// <summary>
        /// creates a iconimage from a stream
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>IconImage.</returns>
        /// <exception cref="System.ArgumentNullException">str</exception>
        /// <exception cref="System.Exception">
        /// header size != 40
        /// or
        /// invalid image size
        /// or
        /// invalid number of planes
        /// or
        /// invalid compression
        /// or
        /// invalid bitdepth
        /// </exception>
        public static IconImage FromStream(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str");
			//check header
			BITMAPINFOHEADER header=new BITMAPINFOHEADER(str);
			if(header.Size!=40)
				throw new Exception("header size != 40");
			Size sz=new Size(header.Width,header.Height/2);
			if(sz.Width<1||sz.Height<1)
				throw new Exception("invalid image size");
			if(header.Planes!=1)
				throw new Exception("invalid number of planes");
			if(header.Compression!=0)
				throw new Exception("invalid compression");
			//decode image
			switch(header.BitCount)
			{
				case 32:
					return new IconImage32bpp(str,sz);
				case 24:
					return new IconImage24bpp(str,sz);
				case 8:
				case 4:
				case 1:
					return new IconImageIndexed(str,sz,header.BitCount);
				default:
					throw new Exception("invalid bitdepth");
			}
		}
        #endregion
        #region saving
        //override this
        /// <summary>
        /// Gets the entry.
        /// </summary>
        /// <returns>ICONDIRENTRY.</returns>
        public abstract ICONDIRENTRY GetEntry();
        //override this
        /// <summary>
        /// Writes the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        public abstract void Write(Stream str);
        #endregion
        #region properties
        //override this
        /// <summary>
        /// Gets the size in bytes.
        /// </summary>
        /// <value>The size in bytes.</value>
        public abstract int SizeInBytes{get;}
        /// <summary>
        /// Gets the bitmap.
        /// </summary>
        /// <value>The bitmap.</value>
        public Bitmap Bitmap
		{
			get{return _bitmap;}
		}
        /// <summary>
        /// Gets the bits per pixel.
        /// </summary>
        /// <value>The bits per pixel.</value>
        public short BitsPerPixel
		{
			get{return _bitsperpixel;}
		}
		#endregion
	}
    /// <summary>
    /// iconimage representing a 32bit truecolor icon image
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.IconImage" />
    public unsafe class IconImage32bpp:IconImage
	{
        /// <summary>
        /// constructs a 32bpp icon image from a stream,
        /// not accessible outside the dll
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="sz">The sz.</param>
        internal IconImage32bpp(Stream str, Size sz)
		{
			#region read 32bpp data
			//create bitmap and lock it
			_bitmap=new Bitmap(sz.Width,sz.Height,PixelFormat.Format32bppArgb);
			BitmapData bd=_bitmap.LockBits(
				new Rectangle(Point.Empty,_bitmap.Size),
				ImageLockMode.ReadWrite,
				PixelFormat.Format32bppArgb);
			int* scan0=(int*)bd.Scan0;
			//read pixels, note: bottom-up, left-right
			using (SimpleReader rdr=new SimpleReader(str))
			{
				scan0+=bd.Width*bd.Height;
				for(int y=0; y<bd.Height; y++)
				{
					scan0-=bd.Width;
					for (int x=0; x<bd.Width; x++)
						scan0[x]=rdr.ReadInt32();
				}
				ANDMap.StampToBitmapData(rdr,bd);
			}
			_bitmap.UnlockBits(bd);
			#endregion
			_bitsperpixel=32;
		}
        /// <summary>
        /// writes the image to the specified stream
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.ArgumentNullException">str</exception>
        public override void Write(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str");
			//write header
			BITMAPINFOHEADER header=new BITMAPINFOHEADER(
				_bitmap.Size,
				32,
				this.SizeInBytes,
				0);
			header.Write(str);
			#region write 32bpp data
			//write bitmap
			BitmapData bd=_bitmap.LockBits(
				new Rectangle(Point.Empty,_bitmap.Size),
				ImageLockMode.ReadWrite,
				PixelFormat.Format32bppArgb);
			int* scan0=(int*)bd.Scan0;
			//write pixels, note: bottom-up, left-right
			using (SimpleWriter wrt=new SimpleWriter(str))
			{
				scan0+=bd.Width*bd.Height;
				for(int y=0; y<bd.Height; y++)
				{
					scan0-=bd.Width;
					for (int x=0; x<bd.Width; x++)
						wrt.Write(scan0[x]);
				}
				ANDMap.WriteToStream(bd,wrt);
			}
			_bitmap.UnlockBits(bd);
			#endregion
		}
        /// <summary>
        /// gets an ICONDIRENTRY struct that represents this image
        /// </summary>
        /// <returns>ICONDIRENTRY.</returns>
        public override ICONDIRENTRY GetEntry()
		{
			return new ICONDIRENTRY(
				(byte)(_bitmap.Width & 0xFF),
				(byte)(_bitmap.Height & 0xFF),
				0,
				32,
				this.SizeInBytes+sizeof(BITMAPINFOHEADER));
		}
        /// <summary>
        /// gets the size of the image in bytes
        /// </summary>
        /// <value>The size in bytes.</value>
        public override int SizeInBytes
		{
			get
			{
				return (_bitmap.Width*_bitmap.Height*4)+//size of xor map
					ANDMap.GetSizeInBytes(_bitmap.Size);//size of and map
			}
		}

	}
    /// <summary>
    /// iconimage representing a 24bit truecolor icon image
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.IconImage" />
    public unsafe class IconImage24bpp:IconImage
	{
        /// <summary>
        /// constructs a 24bpp icon image from a stream,
        /// not accessible outside the dll
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="sz">The sz.</param>
        internal IconImage24bpp(Stream str, Size sz)
		{
			#region read 24bpp data
			//create bitmap and lock it
			_bitmap=new Bitmap(sz.Width,sz.Height,PixelFormat.Format32bppArgb);
			BitmapData bd=_bitmap.LockBits(
				new Rectangle(Point.Empty,_bitmap.Size),
				ImageLockMode.ReadOnly,
				PixelFormat.Format32bppArgb);
			ColorBgra* scan0=(ColorBgra*)bd.Scan0;
			//calculate padding at end of stride
			int padbytescount=(_bitmap.Width*3)%4;
			//read pixels, note: bottom-up, left-right
			ColorBgra color=ColorBgra.Black;
			using (SimpleReader rdr=new SimpleReader(str))
			{
				scan0+=bd.Width*bd.Height;
				for(int y=0; y<bd.Height; y++)
				{
					scan0-=bd.Width;
					for (int x=0; x<bd.Width; x++)
					{
						color.Blue=rdr.ReadByte();
						color.Green=rdr.ReadByte();
						color.Red=rdr.ReadByte();
						scan0[x]=color;
					}
					//pad to 32bit
					if(padbytescount!=0)
						rdr.ReadBytes(padbytescount);
				}
				ANDMap.StampToBitmapData(rdr,bd);
			}
			_bitmap.UnlockBits(bd);
			#endregion
			_bitsperpixel=24;
		}
        /// <summary>
        /// writes the image to the specified stream
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.ArgumentNullException">str</exception>
        public override void Write(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str");
			//write header
			BITMAPINFOHEADER header=new BITMAPINFOHEADER(
				_bitmap.Size,
				24,
				this.SizeInBytes,
				0);
			header.Write(str);
			#region write 24bpp data
			//write bitmap
			BitmapData bd=_bitmap.LockBits(
				new Rectangle(Point.Empty,_bitmap.Size),
				ImageLockMode.ReadWrite,
				PixelFormat.Format32bppArgb);
			ColorBgra* scan0=(ColorBgra*)bd.Scan0;
			//calculate padding at end of stride
			int padbytescount=(_bitmap.Width*3)%4;
			byte[] padbytes=null;
			if(padbytescount!=0)
				padbytes=new byte[padbytescount];
			//write pixels, note: bottom-up, left-right
			using (SimpleWriter wrt=new SimpleWriter(str))
			{
				scan0+=bd.Width*bd.Height;
				for(int y=0; y<bd.Height; y++)
				{
					scan0-=bd.Width;
					for (int x=0; x<bd.Width; x++)
					{
						wrt.Write(scan0[x].Blue);
						wrt.Write(scan0[x].Green);
						wrt.Write(scan0[x].Red);
					}
					//pad to 32bit
					if(padbytes!=null)
						wrt.Write(padbytes);
				}
				ANDMap.WriteToStream(bd,wrt);
			}
			_bitmap.UnlockBits(bd);
			#endregion
		}
        /// <summary>
        /// gets an ICONDIRENTRY struct that represents this image
        /// </summary>
        /// <returns>ICONDIRENTRY.</returns>
        public override ICONDIRENTRY GetEntry()
		{
			return new ICONDIRENTRY(
				(byte)(_bitmap.Width & 0xFF),
				(byte)(_bitmap.Height & 0xFF),
				0,
				24,
				this.SizeInBytes+sizeof(BITMAPINFOHEADER));
		}
        /// <summary>
        /// gets the size of the image in bytes
        /// </summary>
        /// <value>The size in bytes.</value>
        public override int SizeInBytes
		{
			get
			{
				int rem;
				int stridedws=Math.DivRem(_bitmap.Width*3,4,out rem);
				//pad stride to 32bit
				if(rem!=0)
					stridedws++;

				return (stridedws*_bitmap.Height*4)+//size of xor map
					ANDMap.GetSizeInBytes(_bitmap.Size);//size of and map
			}
		}

	}
    /// <summary>
    /// iconimage representing a indexed (1,4,8bpp) icon image
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.IconImage" />
    public unsafe class IconImageIndexed:IconImage
	{
        #region variables
        /// <summary>
        /// The octree
        /// </summary>
        private Octree _octree;
        #endregion
        /// <summary>
        /// constructs a indexed icon image from a stream,
        /// not accessible outside the dll
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="sz">The sz.</param>
        /// <param name="bpp">The BPP.</param>
        internal IconImageIndexed(Stream str, Size sz, short bpp)
		{
			using (SimpleReader rdr=new SimpleReader(str))
			{
				#region read palette
				int colorcount=Quantizer.LengthOfPalette(bpp);
				ColorBgra[] palette=new ColorBgra[colorcount];
				for(int i=0; i<palette.Length; i++)
				{
					palette[i].A=255;
					palette[i].B=rdr.ReadByte();
					palette[i].G=rdr.ReadByte();
					palette[i].R=rdr.ReadByte();
					rdr.ReadByte();//reserved
				}
				_octree=Octree.FromColorArray(palette);
				#endregion	
				#region read indexed data
				//create bitmap and lock it
				_bitmap=new Bitmap(sz.Width,sz.Height,PixelFormat.Format32bppArgb);
				BitmapData bd=_bitmap.LockBits(
					new Rectangle(Point.Empty,_bitmap.Size),
					ImageLockMode.ReadOnly,
					PixelFormat.Format32bppArgb);
				ColorBgra* scan0=(ColorBgra*)bd.Scan0;
				//read pixels
				int indexmask=(1<<bpp)-1;
				scan0+=bd.Width*bd.Height;
				for(int y=0; y<bd.Height; y++)
				{
					scan0-=bd.Width;
					int indexpos=8-bpp,
						data=rdr.ReadInt32();
					for(int x=0; x<bd.Width; x++)
					{
						if(indexpos>=32)
						{
							data=rdr.ReadInt32();
							indexpos-=32;
						}
						scan0[x]=palette[indexmask&(data>>indexpos)];
						if(indexpos%8==0)
							indexpos+=16-bpp;
						else
							indexpos-=bpp;
					}
				}
				ANDMap.StampToBitmapData(rdr,bd);
				_bitmap.UnlockBits(bd);
				#endregion
			}
			_bitsperpixel=bpp;
		}
        /// <summary>
        /// writes the image to the specified stream
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.ArgumentNullException">str</exception>
        public override void Write(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str");
			//write header
			BITMAPINFOHEADER header=new BITMAPINFOHEADER(
				_bitmap.Size,
				_bitsperpixel,
				this.SizeInBytes,
				(1<<_bitsperpixel)&0xFF);
			header.Write(str);
			using (SimpleWriter wrt=new SimpleWriter(str))
			{
				#region write palette
				foreach(ColorBgra value in _octree.Table)
				{
					wrt.Write(value.B);
					wrt.Write(value.G);
					wrt.Write(value.R);
					wrt.Write((byte)0);//reserved
				}
				#endregion
				#region write indexed data
				//write bitmap
				BitmapData bd=_bitmap.LockBits(
					new Rectangle(Point.Empty,_bitmap.Size),
					ImageLockMode.ReadWrite,
					PixelFormat.Format32bppArgb);
				ColorBgra* scan0=(ColorBgra*)bd.Scan0;
				//write indexed data
				int indexmask=(1<<_bitsperpixel)-1,
					indexdata=0;
				scan0+=bd.Width*bd.Height;
				for(int y=0; y<bd.Height; y++)
				{
					scan0-=bd.Width;
					int indexpos=8-_bitsperpixel;
					indexdata=0;
					for (int x=0; x<bd.Width; x++)
					{
						indexdata|=
							(_octree.GetOctreeIndex(scan0[x])&indexmask)<<indexpos;
						if(indexpos%8==0)
							indexpos+=(16-_bitsperpixel);
						else
							indexpos-=_bitsperpixel;
						if(indexpos>=32)
						{
							wrt.Write(indexdata);
							indexdata=0;
							indexpos-=32;
						}
					}
					if(indexpos!=(8-_bitsperpixel))
						wrt.Write(indexdata);
				}
				ANDMap.WriteToStream(bd,wrt);
				#endregion
				_bitmap.UnlockBits(bd);
			}
		}
        /// <summary>
        /// gets an ICONDIRENTRY struct that represents this image
        /// </summary>
        /// <returns>ICONDIRENTRY.</returns>
        public override ICONDIRENTRY GetEntry()
		{
			return new ICONDIRENTRY(
				(byte)(_bitmap.Width & 0xFF),
				(byte)(_bitmap.Height & 0xFF),
				0,
				_bitsperpixel,
				this.SizeInBytes+sizeof(BITMAPINFOHEADER));
		}
        /// <summary>
        /// gets the size of the image in bytes
        /// </summary>
        /// <value>The size in bytes.</value>
        public override int SizeInBytes
		{
			get
			{
				int rem;
				int stridedws=Math.DivRem(_bitmap.Width*_bitsperpixel,32,out rem);
				//pad stride to 32bit
				if(rem!=0)
					stridedws++;
				int colorcount=1<<_bitsperpixel;
				return (colorcount*4)+//size of palette
					(stridedws*_bitmap.Height*4)+//size of xor map
					ANDMap.GetSizeInBytes(_bitmap.Size);//size of and map
			}

		}
        /// <summary>
        /// gets or sets the octree which is used for quantizing the image
        /// </summary>
        /// <value>The octree.</value>
        public Octree Octree
		{
			get{return _octree;}
			set
			{
				if(value!=null)
					_octree=value;
			}
		}
	}
}
