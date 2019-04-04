// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-07-2018
// ***********************************************************************
// <copyright file="IconCollection.cs" company="Zeroit Dev Technologies">
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
using System.IO;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Zusammenfassung für IconCollection.
    /// </summary>
    /// <seealso cref="System.Collections.CollectionBase" />
    public class IconCollection:CollectionBase
	{
        #region classes
        /// <summary>
        /// used for extracting icons from a dll
        /// </summary>
        private class DLLExtractor
		{
            #region variables
            /// <summary>
            /// The resnames
            /// </summary>
            private static ArrayList __resnames;
            #endregion
            /// <summary>
            /// Prevents a default instance of the <see cref="DLLExtractor"/> class from being created.
            /// </summary>
            private DLLExtractor(){}
            /// <summary>
            /// constructs a new iconcollection from a file
            /// </summary>
            /// <param name="filename">The filename.</param>
            /// <returns>IconCollection.</returns>
            /// <exception cref="System.ArgumentNullException">filename</exception>
            /// <exception cref="System.Exception">
            /// loading the library failed
            /// or
            /// dll file invalid
            /// </exception>
            public static IconCollection FromFile(string filename)
			{
				if(filename==null || filename=="")
					throw new ArgumentNullException("filename");
				//load library handle
				IntPtr hLibrary=Kernel32.LoadLibraryEx(
					filename,
					IntPtr.Zero,
					Kernel32.LOAD_LIBRARY_AS_DATAFILE);
				if(hLibrary==IntPtr.Zero)
					throw new Exception("loading the library failed");

				ArrayList resourceids;
				//load resource names
				lock(typeof(DLLExtractor))
				{
					DLLExtractor.__resnames=new ArrayList();
					Kernel32.EnumResourceNames(hLibrary,
						Kernel32.RT_GROUP_ICON,
						new Kernel32.EnumProc(DLLExtractor.EnumProcedure),
						IntPtr.Zero);
					resourceids=new ArrayList(DLLExtractor.__resnames);
				}
				//load icons
				IconCollection ret=new IconCollection();
				try
				{
					for (int i=0; i<resourceids.Count; i++)
					{
						ret.Add(IconFromLibrary(hLibrary,resourceids[i]));
					}
				}
				catch(Exception e)
				{
					throw new Exception("dll file invalid",e);
				}
				finally
				{
					Kernel32.FreeLibrary(hLibrary);
				}
				return ret;
			}
            /// <summary>
            /// used to enumerate resource names
            /// </summary>
            /// <param name="hModule">The h module.</param>
            /// <param name="lpszType">Type of the LPSZ.</param>
            /// <param name="lpszName">Name of the LPSZ.</param>
            /// <param name="lParam">The l parameter.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            private static bool EnumProcedure(IntPtr  hModule, IntPtr lpszType, IntPtr lpszName, IntPtr lParam)
			{
				if(Kernel32.IS_INTRESOURCE(lpszName))
					__resnames.Add(lpszName.ToInt32());
				else
					__resnames.Add(System.Runtime.InteropServices.Marshal.PtrToStringAnsi(lpszName));
				return true;
			}
            /// <summary>
            /// constructs an icon from a dll resource
            /// </summary>
            /// <param name="hlibrary">The hlibrary.</param>
            /// <param name="resourceid">The resourceid.</param>
            /// <returns>IconEncoder.</returns>
            /// <exception cref="System.ArgumentException">resourceid is invalid type - resourceid</exception>
            /// <exception cref="System.Exception">
            /// this is not an icon file
            /// or
            /// no iconimages contained
            /// </exception>
            private static IconEncoder IconFromLibrary(IntPtr hlibrary, object resourceid)
			{
				IntPtr hicon;
				//is_intresource
				if(resourceid is int)
					hicon=Kernel32.FindResource(hlibrary,(int)resourceid,Kernel32.RT_GROUP_ICON);
				else if(resourceid is string)
					hicon=Kernel32.FindResource(hlibrary,(string)resourceid,Kernel32.RT_GROUP_ICON);
				else
					throw new ArgumentException("resourceid is invalid type","resourceid");
				//open stream
				MEMICONDIRENTRY[] entries;
				using (Stream str=Kernel32.GetStreamFromResource(hlibrary,hicon))
				{
					ICONDIR header=new ICONDIR(str);
					if(header.idType!=1)
						throw new Exception("this is not an icon file");
					if(header.idCount<1)
						throw new Exception("no iconimages contained");
					//read headers
					entries=new MEMICONDIRENTRY[header.idCount];
					for(int i=0; i<entries.Length; i++)
					{
						entries[i]=new MEMICONDIRENTRY(str);
					}
				}
				IconEncoder ret=new IconEncoder();
				//read images
				for(int i=0; i<entries.Length; i++)
				{
					//stream for single image
					using(Stream str=Kernel32.GetStreamFromResource(hlibrary,
							  Kernel32.FindResource(hlibrary,entries[i].ID,Kernel32.RT_ICON)))
					{
						ret.Images.Add(IconImage.FromStream(str));
					}
				}
				return ret;
			}
		}
        #endregion
        /// <summary>
        /// constructs a blank iconcollection
        /// </summary>
        public IconCollection(){}
        /// <summary>
        /// constructs a iconcollection from a dll file
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>IconCollection.</returns>
        public static IconCollection FromDLL(string filename)
		{
			return DLLExtractor.FromFile(filename);
		}
        #region collection members
        /// <summary>
        /// adds the specified icon to the collection
        /// </summary>
        /// <param name="value">The value.</param>
        public void Add(IconEncoder value)
		{
			if(value==null)
				return;
			this.List.Add(value);
		}
        /// <summary>
        /// gets or sets the icon at the specified position
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>IconEncoder.</returns>
        public IconEncoder this[int index]
		{
			get{return (IconEncoder)this.List[index];}
			set
			{
				if (value==null) return;
				this.List[index]=value;
			}
		}
		#endregion
	}
}
