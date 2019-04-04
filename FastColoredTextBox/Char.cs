// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Char.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Char and style
    /// </summary>
    public struct Char
    {
        /// <summary>
        /// Unicode character
        /// </summary>
        public char c;
        /// <summary>
        /// Style bit mask
        /// </summary>
        public StyleIndex style;

        /// <summary>
        /// Initializes a new instance of the <see cref="Char"/> struct.
        /// </summary>
        /// <param name="c">The c.</param>
        public Char(char c)
        {
            this.c = c;
            style = StyleIndex.None;
        }
    }
}
