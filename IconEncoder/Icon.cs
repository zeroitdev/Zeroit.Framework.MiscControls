// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-07-2018
// ***********************************************************************
// <copyright file="Icon.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for rendering an icon.
    /// </summary>
    /// <seealso cref="System.Runtime.Serialization.ISerializable" />
    [Serializable(),
	System.ComponentModel.Editor(typeof(IconEditor),
		typeof(System.Drawing.Design.UITypeEditor))]
	public class IconEncoder:ISerializable
	{
        #region classes
        /// <summary>
        /// collection for images inside icon
        /// </summary>
        /// <seealso cref="System.Collections.CollectionBase" />
        public class IconImageCollection:CollectionBase
		{
            /// <summary>
            /// Initializes a new instance of the <see cref="IconImageCollection"/> class.
            /// </summary>
            public IconImageCollection(){}
            /// <summary>
            /// adds an IconImage to the collection
            /// </summary>
            /// <param name="img">The img.</param>
            /// <exception cref="System.ArgumentNullException">img</exception>
            /// <exception cref="System.Exception">number of icons too high</exception>
            public void Add(IconImage img)
			{
				if (img==null)
					throw new ArgumentNullException("img");
				if(this.Count>(short.MaxValue-1))
					throw new Exception("number of icons too high");
				this.List.Add(img);
			}
            /// <summary>
            /// gets or sets the iconimage at the specified index
            /// </summary>
            /// <param name="index">The index.</param>
            /// <returns>IconImage.</returns>
            public IconImage this[int index]
			{
				get{return this.List[index] as IconImage;}
				set{if(value!=null)this.List[index]=value;}
			}
		}
        #endregion
        #region variables
        /// <summary>
        /// The images
        /// </summary>
        private IconImageCollection _images=new IconImageCollection();
        #endregion
        #region constructors
        /// <summary>
        /// constructs a new empty icon
        /// </summary>
        public IconEncoder(){}
        /// <summary>
        /// opens an icon from a stream
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.ArgumentNullException">str</exception>
        public IconEncoder(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str");
			this.Load(str);
		}
        /// <summary>
        /// opens an icon from a file
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <exception cref="System.ArgumentNullException">filename</exception>
        public IconEncoder(string filename)
		{
			if(filename==null)
				throw new ArgumentNullException("filename");
			//open file
			FileStream fstr=null;
//			try
//			{
				fstr=new FileStream(filename,FileMode.Open);
				Load(fstr);
				fstr.Close();
				fstr=null;
//			}
//			catch(Exception e)
//			{
//				if(fstr!=null)
//					fstr.Close();
//				throw e;
//			}
		}
        /// <summary>
        /// deserialization constructor
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        private IconEncoder(SerializationInfo info, StreamingContext context)
		{
			byte[] icondata=(byte[])info.GetValue("IconData",typeof(byte[]));
			using(MemoryStream str=new MemoryStream(icondata))
			{
				Load(str);
			}
		}
        #endregion
        #region loading
        /// <summary>
        /// Loads the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.Exception">
        /// this is not an icon file
        /// or
        /// no iconimages contained
        /// </exception>
        private void Load(Stream str)
		{
			//read the file header and check
			ICONDIR fileheader=new ICONDIR(str);
			if(fileheader.idType!=1)
				throw new Exception("this is not an icon file");
			if(fileheader.idCount<1)
				throw new Exception("no iconimages contained");
			//read direntries
			ICONDIRENTRY[] entries=new ICONDIRENTRY[fileheader.idCount];
			for(int i=0; i<fileheader.idCount; i++)
				entries[i]=new ICONDIRENTRY(str);
			//read images
			for(int i=0; i<fileheader.idCount; i++)
			{
				_images.Add(IconImage.FromStream(str));
			}
		}
        #endregion
        #region saving
        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			MemoryStream str=new MemoryStream();
			this.Save(str);
			info.AddValue("IconData",str.ToArray(),typeof(byte[]));
		}
        /// <summary>
        /// saves the icon to a file
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <exception cref="System.ArgumentNullException">filename</exception>
        public void Save(string filename)
		{
			if(filename==null)
				throw new ArgumentNullException("filename");
			//save to file
			FileStream fstr=null;
			try
			{
				fstr=new FileStream(filename,FileMode.Create);
				this.Save(fstr);
				fstr.Flush();
				fstr.Close();
			}
			catch(Exception e)
			{
				if (fstr!=null)
					fstr.Close();
				throw e;
			}
		}
        /// <summary>
        /// saves the icon to a stream
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.ArgumentNullException">str</exception>
        /// <exception cref="System.Exception">icon is empty</exception>
        public unsafe void Save(Stream str)
		{
			if(str==null)
				throw new ArgumentNullException("str");
			if(_images.Count<1)
				throw new Exception("icon is empty");
			//write file header
			ICONDIR fileheader=new ICONDIR((short)(_images.Count));
			fileheader.Write(str);
			//write direntries
			int fileoffset=sizeof(ICONDIR)+
				_images.Count*sizeof(ICONDIRENTRY);
			foreach(IconImage img in _images)
			{
				ICONDIRENTRY entry=img.GetEntry();
				entry.FileOffset=fileoffset;
				fileoffset+=entry.SizeInBytes;
				entry.Write(str);
			}
			//write images
			foreach(IconImage img in _images)
			{
				img.Write(str);
			}
		}
        #endregion
        #region properties
        /// <summary>
        /// returns the collection of images in the icon
        /// </summary>
        /// <value>The images.</value>
        public IconEncoder.IconImageCollection Images
		{
			get{return this._images;}
		}
		#endregion
	}
}
