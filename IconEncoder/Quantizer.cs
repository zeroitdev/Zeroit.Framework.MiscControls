// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Quantizer.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Imaging;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class Quantizer. This class cannot be inherited.
    /// </summary>
    public sealed class Quantizer
	{
        #region variables
        /// <summary>
        /// The maxcolors
        /// </summary>
        private int _maxcolors;
        /// <summary>
        /// The octree
        /// </summary>
        private Octree _octree=null;
        #endregion
        /// <summary>
        /// constructs a new quantizer object for the
        /// specified bitdepth
        /// </summary>
        /// <param name="format">The format.</param>
        public Quantizer(PixelFormat format)
		{
			_maxcolors=LengthOfPalette(format);
		}
        /// <summary>
        /// constructs a new quantizer object for the
        /// specified bitdepth
        /// </summary>
        /// <param name="bitsperpixel">The bitsperpixel.</param>
        public Quantizer(int bitsperpixel)
		{
			_maxcolors=LengthOfPalette(bitsperpixel);
		}
        #region public members
        /// <summary>
        /// evaluates the colors in a palette of the specified bitdepth
        /// </summary>
        /// <param name="bitsperpixel">The bitsperpixel.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">bitsperpixel</exception>
        public static int LengthOfPalette(int bitsperpixel)
		{
			switch(bitsperpixel)
			{
				case 1:	return 2;
				case 4:	return 16;
				case 8:	return 256;
				default:
					throw new ArgumentOutOfRangeException("bitsperpixel");
			}
		}
        /// <summary>
        /// evaluates the colors in a palette of the specified format
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">format</exception>
        public static int LengthOfPalette(PixelFormat format)
		{
			switch(format)
			{
				case PixelFormat.Format1bppIndexed:
					return 2;
				case PixelFormat.Format4bppIndexed:
					return 16;
				case PixelFormat.Format8bppIndexed:
					return 256;
				default:
					throw new ArgumentOutOfRangeException("format");
			}
		}
        /// <summary>
        /// makes a copy of the image with a 32bpp argb format.
        /// the original image is not altered
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        /// <returns>Bitmap.</returns>
        public static Bitmap CopyImage(Bitmap bmp)
		{
			if (bmp==null || bmp.Width<1 || bmp.Height<1) return null;
			//copy the input argument
			Bitmap copy=new Bitmap(bmp.Width,bmp.Height,PixelFormat.Format32bppArgb);
			using (Graphics gr=Graphics.FromImage(copy))
			{
				gr.DrawImage(bmp,0,0,bmp.Width,bmp.Height);
			}
			return copy;
		}
        /// <summary>
        /// quantizes the specified image with the internal palette.
        /// to alter the palette, use MakePalette()
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        /// <param name="dithering">The dithering.</param>
        /// <exception cref="System.Exception">table not initialized. add some colors to the table</exception>
        public unsafe void QuantizeImage(Bitmap bmp,DitheringType dithering)
		{
			if (bmp==null || bmp.PixelFormat!=PixelFormat.Format32bppArgb) return;
			if (_octree==null)
				throw new Exception("table not initialized. add some colors to the table");
			//lock bitmap
			BitmapData bdata=bmp.LockBits(
				new Rectangle(0,0,bmp.Width,bmp.Height),
				ImageLockMode.ReadWrite,
				PixelFormat.Format32bppArgb);
			switch(dithering)
			{
				case DitheringType.Uniform:
					QuantizeUniform(
						(ColorBgra*)bdata.Scan0,
						bmp.Width,
						bmp.Height);
					break;
				case DitheringType.RandomError:
					QuantizeRandom(
						(ColorBgra*)bdata.Scan0,
						bmp.Width,
						bmp.Height);
					break;
				case DitheringType.FloydSteinberg:
					QuantizeFloydSteinberg(
						(ColorBgra*)bdata.Scan0,
						bmp.Width,
						bmp.Height);
					break;
			}
			bmp.UnlockBits(bdata);
		}
        #region makepalette
        /// <summary>
        /// creates an adaptive palette based on the data in the
        /// specified bitmap
        /// </summary>
        /// <param name="bmp">a bitmap containing the colors. use only 32bppArgb images</param>
        public void MakePalette(Bitmap bmp)
		{
			_octree=Octree.FromBitmap(bmp,_maxcolors);
		}
        /// <summary>
        /// creates an exact palette based on the colors in the array
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentException">invalid - value</exception>
        public void MakePalette(ColorBgra[] value)
		{
			if(value==null || value.Length!=_maxcolors)
				throw new ArgumentException("invalid","value");
			_octree=Octree.FromColorArray(value);
		}
        #endregion
        #endregion
        #region properties
        /// <summary>
        /// gets the internal octree
        /// be careful: if you haven't initialized a palette,
        /// this is NULL
        /// </summary>
        /// <value>The palette.</value>
        public ColorBgra[] Palette
		{
			get
			{
				if(_octree==null) return null;
				else return _octree.Table;
			}
		}
        /// <summary>
        /// gets the maximum number of colors
        /// </summary>
        /// <value>The maximum colors.</value>
        public int MaxColors
		{
			get{return _maxcolors;}
		}
        #endregion
        #region quantization algorithms
        #region constants
        //matrix containing the error dispersion
        //coefficients for floyd-steinberg algorithm
        /// <summary>
        /// The floydsteinbergmatrix
        /// </summary>
        private int[][] floydsteinbergmatrix=
			new int[][]{
						   new int[]{0,0,7},
						   new int[]{3,5,1}
					   };
        /// <summary>
        /// The floydsteinbergsum
        /// </summary>
        private int floydsteinbergsum=16;
        #endregion
        /// <summary>
        /// quantizes the specified image using a floyd-steinberg error diffusion dithering
        /// </summary>
        /// <param name="pixels">The pixels.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private unsafe void QuantizeFloydSteinberg(ColorBgra* pixels, int width, int height)
		{
			if(_octree==null) return;
			int index=0;
			ColorBgra col;
			for (int y=0; y<height; y++)
			{			
				for (int x=0; x<width; x++, index++)
				{

					col=_octree.Table[_octree.GetOctreeIndex(pixels[index])];
					int er=(int)pixels[index].R-(int)col.R,
						eg=(int)pixels[index].G-(int)col.G,
						eb=(int)pixels[index].B-(int)col.B;
					#region error matrix
					for (int i=0; i<2; i++)
					{
						int iy=i+y;
						if (iy>=0 && iy<height)
						{
							for (int j=-1; j<2; j++)
							{
								int jx=j+x;
								if (jx>=0 && jx<width)
								{
									//load error dispersion from matrix
									int w=floydsteinbergmatrix[i][j+1];
									if (w!=0)
									{
										int k=jx+iy*width;
										pixels[k].Red+=(er*w)/floydsteinbergsum;
										pixels[k].Green+=(eg*w)/floydsteinbergsum;
										pixels[k].Blue+=(eb*w)/floydsteinbergsum;
									}
								}
							}
						}
						#endregion
					}
					pixels[index]=col;
				}
			}
		}
        /// <summary>
        /// quantizes the specified image using a random error diffusion
        /// </summary>
        /// <param name="pixels">The pixels.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private unsafe void QuantizeRandom(ColorBgra* pixels, int width, int height)
		{
			if(_octree==null) return;
			Random rnd=new Random();
			int count=width*height;
			for (int i=0; i<count; i++)
				pixels[i]=_octree.Table[
					_octree.GetOctreeIndex(
					Math.Min(255,Math.Max(0,pixels[i].Red+rnd.Next(-12,12))),
					Math.Min(255,Math.Max(0,pixels[i].Green+rnd.Next(-12,12))),
					Math.Min(255,Math.Max(0,pixels[i].Blue+rnd.Next(-12,12))))];
		}
        /// <summary>
        /// quantizes the specified image without using any dithering
        /// </summary>
        /// <param name="pixels">The pixels.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        private unsafe void QuantizeUniform(ColorBgra* pixels, int width, int height)
		{
			if(_octree==null) return;
			int count=width*height;
			for (int i=0; i<count; i++)
				pixels[i]=_octree.Table[_octree.GetOctreeIndex(pixels[i])];
		}
		#endregion
	}
    /// <summary>
    /// encapsulates an octree for quick lookup of colors
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class Octree:IDisposable
	{
        #region types
        /// <summary>
        /// encapsulates a single octree node
        /// </summary>
        private class OctreeNode
		{
            #region variables
            /// <summary>
            /// The children
            /// </summary>
            public OctreeNode[] Children=new OctreeNode[8];
            /// <summary>
            /// The is leaf
            /// </summary>
            public bool IsLeaf=false;
            /// <summary>
            /// The next
            /// </summary>
            public OctreeNode Next=null;
            /// <summary>
            /// The red sum
            /// </summary>
            public int RedSum=0,
                /// <summary>
                /// The green sum
                /// </summary>
                GreenSum = 0,
                /// <summary>
                /// The blue sum
                /// </summary>
                BlueSum = 0,
                /// <summary>
                /// The pixel count
                /// </summary>
                PixelCount = 0;
            /// <summary>
            /// The index
            /// </summary>
            public int Index;
            #endregion
            /// <summary>
            /// ctor
            /// </summary>
            /// <param name="isleaf">if set to <c>true</c> [isleaf].</param>
            /// <param name="reducible">The reducible.</param>
            public OctreeNode(bool isleaf, ref OctreeNode reducible)
			{
				this.IsLeaf=isleaf;
				if (!isleaf)
				{
					this.Next=reducible;
					reducible=this;
				}
			}
            #region public members
            /// <summary>
            /// adds the specified color to the node and
            /// increases the counter by one
            /// </summary>
            /// <param name="red">The red.</param>
            /// <param name="green">The green.</param>
            /// <param name="blue">The blue.</param>
            public void AddPixel(int red, int green, int blue)
			{
				this.RedSum+=red;
				this.GreenSum+=green;
				this.BlueSum+=blue;
				this.PixelCount++;
			}
            /// <summary>
            /// returns a value representing the color of the node.
            /// if this is not a leaf, ColorBgra.Transparent is returned
            /// </summary>
            /// <returns>ColorBgra.</returns>
            public ColorBgra ToColor()
			{
				if (PixelCount<1) return ColorBgra.Transparent;
				return new ColorBgra(
					(byte)(RedSum/PixelCount),
					(byte)(GreenSum/PixelCount),
					(byte)(BlueSum/PixelCount));
			}
            /// <summary>
            /// adds the element recursively to the specified table
            /// </summary>
            /// <param name="table">The table.</param>
            /// <param name="index">The index.</param>
            public void AddToTable(ColorBgra[] table, ref int index)
			{
				//failure, index out of range
				if (index>=table.Length) return;
				if (this.IsLeaf)
				{
					//add to table and remember index
					table[index]=this.ToColor();
					this.Index=index;
					index++;
				}
				else
				{
					//recursively add children to table
					for (int i=0; i<8; i++)
					{
						if (Children[i]==null) continue;
						Children[i].AddToTable(table, ref index);
					}
				}
			}
            /// <summary>
            /// deletes all children of the node,
            /// including the next pointer
            /// </summary>
            public void DeleteChildren()
			{
				for (int i=0; i<8; i++)
				{
					if (Children[i]==null) continue;
					Children[i].DeleteChildren();
					Children[i]=null;
				}
				Next=null;
			}
			#endregion
		}
        #endregion
        #region variables
        /// <summary>
        /// The maxdepth
        /// </summary>
        private int MAXDEPTH=5;
        /// <summary>
        /// The root
        /// </summary>
        private OctreeNode _root;
        /// <summary>
        /// The reduciblenodes
        /// </summary>
        private OctreeNode[] _reduciblenodes;
        /// <summary>
        /// The colors
        /// </summary>
        private int _colors, _maxcolors=0;
        /// <summary>
        /// The table
        /// </summary>
        private ColorBgra[] _table;
        #endregion
        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Octree"/> class.
        /// </summary>
        /// <param name="maxdepth">The maxdepth.</param>
        /// <param name="maxcolors">The maxcolors.</param>
        private Octree(int maxdepth, int maxcolors)
		{
			//different maxdepths are needet for exactness
			MAXDEPTH=maxdepth;
			//init nodes
			_reduciblenodes=new OctreeNode[MAXDEPTH+1];
			_root=new OctreeNode(false,ref _reduciblenodes[0]);
			_colors=0;
		}
        /// <summary>
        /// parses an array of colors into the octree for
        /// making possible a quick lookup
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Octree.</returns>
        /// <exception cref="System.ArgumentNullException">value</exception>
        /// <exception cref="System.ArgumentException">length of colors not equal to maxcolors - value</exception>
        public static Octree FromColorArray(ColorBgra[] value)
		{
			if(value==null)
				throw new ArgumentNullException("value");
			if(value.Length<2 || value.Length>256)
				throw new ArgumentException("length of colors not equal to maxcolors","value");
			//exact mapping of colors
			Octree ret=new Octree(8,value.Length);
			//loop through colors
			for(int i=0; i<value.Length; i++)
			{
				OctreeNode node=ret.FindOrCreateNode(value[i]);
				if(node==null)continue;
				node.Index=i;
			}
			//no reduction needed this time, create table
			ret._table=new ColorBgra[value.Length];
			value.CopyTo(ret._table,0);
			//return octree
			return ret;
		}
        /// <summary>
        /// creates a palette of colors from a bitmap
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        /// <param name="maxcolors">The maxcolors.</param>
        /// <returns>Octree.</returns>
        /// <exception cref="System.ArgumentException">
        /// bmp not valid. use copyimage()
        /// or
        /// length of colors not valid - value
        /// </exception>
        public unsafe static Octree FromBitmap(Bitmap bmp, int maxcolors)
		{
			if (bmp==null || bmp.PixelFormat!=PixelFormat.Format32bppArgb)
				throw new ArgumentException("bmp not valid. use copyimage()");
			if(maxcolors<2 || maxcolors>256)
				throw new ArgumentException("length of colors not valid","value");
			//no exact mapping of colors
			Octree ret=new Octree(5,maxcolors);
			#region adding bitmap
			//lock bitmap
			BitmapData bdata=bmp.LockBits(
				new Rectangle(0,0,bmp.Width,bmp.Height),
				ImageLockMode.ReadWrite,
				PixelFormat.Format32bppArgb);
			int count=bmp.Width*bmp.Height;
			ColorBgra* pixels=(ColorBgra*)bdata.Scan0;
			//loop through pixels
			for (int i=0; i<count; i++)
			{
				ret.AddColor(pixels[i]);
				while(ret._colors>ret._maxcolors)
				{
					ret.ReduceTree();
				}
			}
			bmp.UnlockBits(bdata);
			#endregion
			//make palette
			ret._table=new ColorBgra[maxcolors];
			int index=0;
			ret._root.AddToTable(ret._table,ref index);
			//return octree
			return ret;
		}
        #endregion
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
		{
			//erase reducible pointers
			_reduciblenodes=null;
			//delete recursively
			_root.DeleteChildren();
			//delete table
			_table=null;
		}
        #region algorithms
        /// <summary>
        /// adds the specified color to the octree
        /// </summary>
        /// <param name="value">The value.</param>
        private void AddColor(ColorBgra value)
		{
			OctreeNode node=FindOrCreateNode(value);
			if(node!=null)
				node.AddPixel(value.Red,value.Green,value.Blue);
		}
        /// <summary>
        /// finds or creates a node for the given color
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>OctreeNode.</returns>
        private OctreeNode FindOrCreateNode(ColorBgra value)
		{
			return FindOrCreateNode(value.Red,value.Green,value.Blue);
		}
        /// <summary>
        /// finds or creates a node for the given color
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <returns>OctreeNode.</returns>
        private OctreeNode FindOrCreateNode(int r, int g, int b)
		{
			int mask=0x80, index;
			OctreeNode node=_root, child;
			//root is the only color
			if (node.IsLeaf)
				return node;
			//loop through children
			for (int depth=1; depth<=MAXDEPTH; depth++, mask>>=1)
			{
				index=0;
				//index selecting
				if((r&mask)!=0) index+=4;
				if((g&mask)!=0) index+=2;
				if((b&mask)!=0) index+=1;
				//look for child node, no matter if NULL
				child=node.Children[index];
				//create new node and add to reducibles if not leaf
				if (child==null)
				{
					node.Children[index]=child=new OctreeNode(
						depth==MAXDEPTH,
						ref _reduciblenodes[depth]);
					if (child.IsLeaf) _colors++;
				}
				//child represents the color
				if (child.IsLeaf)
					return child;
				node=child;
			}
			return null;
		}
        /// <summary>
        /// gets the index of the octree node closest to the specified color
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <returns>OctreeNode.</returns>
        private OctreeNode FindNode(int r, int g, int b)
		{
			int mask=0x80, index;
			OctreeNode node=_root, child;
			//root is the only color
			if (node.IsLeaf)
				return node;
			//loop through children
			for (int depth=1; depth<=MAXDEPTH; depth++, mask>>=1)
			{
				//index selecting
				index=0;
				if((r&mask)!=0) index+=4;
				if((g&mask)!=0) index+=2;
				if((b&mask)!=0) index+=1;

				//look for child node
				child=node.Children[index];
				//color not in octree
				if (child==null)
				{
					//search for first child
					for (int i=0; i<8; i++)
						if (node.Children[i]!=null)
						{
							child=node.Children[i];
							break;
						}
					//fatal failure
					if (child==null)
						return null;
				}
				//child represents color
				if (child.IsLeaf)
					return child;
				node=child;
			}
			return null;
		}
        /// <summary>
        /// reduces the last node in the deepest level
        /// </summary>
        private void ReduceTree()
		{
			OctreeNode node;
			int depth;
			//find deepest level
			for (depth=MAXDEPTH; depth>0 && _reduciblenodes[depth]==null; depth--);
			//swap values
			node=_reduciblenodes[depth];
			_reduciblenodes[depth]=node.Next;
			//reduce all children
			for (int i=0; i<8; i++)
			{
				if (node.Children[i]==null) continue;
				//eat child
				node.RedSum+=node.Children[i].RedSum;
				node.GreenSum+=node.Children[i].GreenSum;
				node.BlueSum+=node.Children[i].BlueSum;
				node.PixelCount+=node.Children[i].PixelCount;
				node.Children[i]=null;
				//reduce global color counter
				_colors--;
			}
			//parent node is now a color
			_colors++;
			node.IsLeaf=true;
		}
        #endregion
        #region public members
        /// <summary>
        /// gets the index of the octree node closest to the specified color
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>System.Int32.</returns>
        public int GetOctreeIndex(Color color)
		{
			return GetOctreeIndex(color.R,color.G,color.B);
		}
        /// <summary>
        /// gets the index of the octree node closest to the specified color
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>System.Int32.</returns>
        public int GetOctreeIndex(ColorBgra color)
		{
			return GetOctreeIndex(color.Red,color.Green,color.Blue);
		}
        /// <summary>
        /// gets the index of the octree node closest to the specified color
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <returns>System.Int32.</returns>
        public int GetOctreeIndex(int r, int g, int b)
		{
			OctreeNode node=FindNode(r,g,b);
			if(node==null)
				return 0;//fatal error
			else
				return node.Index;
		}
        #endregion
        #region properties
        /// <summary>
        /// gets the palette this octree refers to
        /// </summary>
        /// <value>The table.</value>
        public ColorBgra[] Table
		{
			get{return _table;}
		}
		#endregion
	}
    /// <summary>
    /// enumeration of possible dithering strategies
    /// </summary>
    public enum DitheringType
	{
        /// <summary>
        /// The uniform
        /// </summary>
        Uniform = 0,
        /// <summary>
        /// The floyd steinberg
        /// </summary>
        FloydSteinberg = 1,
        /// <summary>
        /// The random error
        /// </summary>
        RandomError = 2
	}

}
