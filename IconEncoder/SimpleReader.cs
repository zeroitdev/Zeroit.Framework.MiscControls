// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="SimpleReader.cs" company="Zeroit Dev Technologies">
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
