// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="SimpleReader.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// simplereader can be used as binaryreader, which NOT closes the stream
    /// </summary>
    /// <seealso cref="System.IO.BinaryReader" />
    public class SimpleReader:BinaryReader
	{
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="stream">The stream.</param>
        public SimpleReader(Stream stream)
			:base(stream){}
        /// <summary>
        /// removes the reader form the stream WITHOUT closing it
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
		{
			base.Dispose (false);
		}
	}
    /// <summary>
    /// simplewriter can be used as binarywriter, which NOT closes the stream
    /// </summary>
    /// <seealso cref="System.IO.BinaryWriter" />
    public class SimpleWriter:BinaryWriter
	{
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="stream">The stream.</param>
        public SimpleWriter(Stream stream):
			base(stream){}
        /// <summary>
        /// removes the reader form the stream WITHOUT closing it
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
		{
			base.Dispose (false);
		}
	}
}
