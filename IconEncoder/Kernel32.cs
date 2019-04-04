// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Kernel32.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;
using System.IO;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// kernel32.dll wrapper - resource extracting
    /// </summary>
    internal class Kernel32
	{
        /// <summary>
        /// Prevents a default instance of the <see cref="Kernel32"/> class from being created.
        /// </summary>
        private Kernel32(){}

        //constants
        /// <summary>
        /// The rt group icon
        /// </summary>
        public const int RT_GROUP_ICON = 14;
        /// <summary>
        /// The rt icon
        /// </summary>
        public const int RT_ICON = 3;
        /// <summary>
        /// The load library as datafile
        /// </summary>
        public const int LOAD_LIBRARY_AS_DATAFILE = 0x2;

        //functions
        /// <summary>
        /// Finds the resource.
        /// </summary>
        /// <param name="hInstance">The h instance.</param>
        /// <param name="lpName">Name of the lp.</param>
        /// <param name="lpType">Type of the lp.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll", EntryPoint="FindResourceA")]
		public static extern IntPtr FindResource (IntPtr hInstance, int lpName, int lpType);
        /// <summary>
        /// Finds the resource.
        /// </summary>
        /// <param name="hInstance">The h instance.</param>
        /// <param name="lpName">Name of the lp.</param>
        /// <param name="lpType">Type of the lp.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll", EntryPoint="FindResourceA")]
		public static extern IntPtr FindResource (IntPtr hInstance, string lpName, int lpType);

        /// <summary>
        /// Loads the resource.
        /// </summary>
        /// <param name="hInstance">The h instance.</param>
        /// <param name="hResInfo">The h resource information.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll")]
		public static extern IntPtr LoadResource (IntPtr hInstance, IntPtr hResInfo);

        /// <summary>
        /// Locks the resource.
        /// </summary>
        /// <param name="hResData">The h resource data.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll")]
		public static extern IntPtr LockResource (IntPtr hResData);

        /// <summary>
        /// Sizeofs the resource.
        /// </summary>
        /// <param name="hInstance">The h instance.</param>
        /// <param name="hResInfo">The h resource information.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("kernel32.dll")]
		public static extern int SizeofResource (IntPtr hInstance, IntPtr hResInfo);

        /// <summary>
        /// Enums the resource names.
        /// </summary>
        /// <param name="hModule">The h module.</param>
        /// <param name="lpType">Type of the lp.</param>
        /// <param name="lpEnumFunc">The lp enum function.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("kernel32.dll", EntryPoint="EnumResourceNamesA")]
		public static extern int EnumResourceNames (IntPtr hModule, int lpType,[MarshalAs(UnmanagedType.FunctionPtr)]EnumProc lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// Loads the library ex.
        /// </summary>
        /// <param name="lpLibFileName">Name of the lp library file.</param>
        /// <param name="hFile">The h file.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("kernel32.dll", EntryPoint="LoadLibraryExA")]
		public static extern IntPtr LoadLibraryEx (string lpLibFileName, IntPtr hFile, int dwFlags);

        /// <summary>
        /// Frees the library.
        /// </summary>
        /// <param name="hLibModule">The h library module.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("kernel32.dll")]
		public static extern int FreeLibrary (IntPtr hLibModule);

        //delegates
        /// <summary>
        /// Delegate EnumProc
        /// </summary>
        /// <param name="hModule">The h module.</param>
        /// <param name="lpszType">Type of the LPSZ.</param>
        /// <param name="lpszName">Name of the LPSZ.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public delegate bool EnumProc(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, IntPtr lParam);

        /// <summary>
        /// gives a stream of a locked memory resource
        /// </summary>
        /// <param name="hlibrary">The hlibrary.</param>
        /// <param name="hresinfo">The hresinfo.</param>
        /// <returns>Stream.</returns>
        /// <exception cref="System.Exception">
        /// resource could not be loaded
        /// or
        /// resource could not be locked
        /// </exception>
        /// <exception cref="System.ArgumentException">size invalid</exception>
        public static Stream GetStreamFromResource(IntPtr hlibrary, IntPtr hresinfo)
		{
			//load resource
			IntPtr hresloaded=LoadResource(hlibrary,hresinfo);
			if(hresloaded==IntPtr.Zero)
				throw new Exception("resource could not be loaded");
			//lock resource
			IntPtr hreslocked=LockResource(hresloaded);
			if(hreslocked==IntPtr.Zero)
				throw new Exception("resource could not be locked");
			//get size
			int size=SizeofResource(hlibrary,hresinfo);
			if (size<1)
				throw new ArgumentException("size invalid");
			//copy into buffer
			byte[] data=new byte[size];
			Marshal.Copy(hreslocked,data,0,size);
			return new MemoryStream(data);
		}
        /// <summary>
        /// gets if the specified pointer is an ID or a pointer to unicode string
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified value is intresource; otherwise, <c>false</c>.</returns>
        public static bool IS_INTRESOURCE(IntPtr value)
		{
			return value.ToInt32()<=0xFFFF;
		}
	}
}
