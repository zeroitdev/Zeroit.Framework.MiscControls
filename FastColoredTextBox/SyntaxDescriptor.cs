// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-22-2018
// ***********************************************************************
// <copyright file="SyntaxDescriptor.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Class SyntaxDescriptor.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class SyntaxDescriptor: IDisposable
    {
        /// <summary>
        /// The left bracket
        /// </summary>
        public char leftBracket = '(';
        /// <summary>
        /// The right bracket
        /// </summary>
        public char rightBracket = ')';
        /// <summary>
        /// The left bracket2
        /// </summary>
        public char leftBracket2 = '{';
        /// <summary>
        /// The right bracket2
        /// </summary>
        public char rightBracket2 = '}';
        /// <summary>
        /// The brackets highlight strategy
        /// </summary>
        public BracketsHighlightStrategy bracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
        /// <summary>
        /// The styles
        /// </summary>
        public readonly List<Style> styles = new List<Style>();
        /// <summary>
        /// The rules
        /// </summary>
        public readonly List<RuleDesc> rules = new List<RuleDesc>();
        /// <summary>
        /// The foldings
        /// </summary>
        public readonly List<FoldingDesc> foldings = new List<FoldingDesc>();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            foreach (var style in styles)
                style.Dispose();
        }
    }

    /// <summary>
    /// Class RuleDesc.
    /// </summary>
    public class RuleDesc
    {
        /// <summary>
        /// The regex
        /// </summary>
        Regex regex;
        /// <summary>
        /// The pattern
        /// </summary>
        public string pattern;
        /// <summary>
        /// The options
        /// </summary>
        public RegexOptions options = RegexOptions.None;
        /// <summary>
        /// The style
        /// </summary>
        public Style style;

        /// <summary>
        /// Gets the regex.
        /// </summary>
        /// <value>The regex.</value>
        public Regex Regex
        {
            get
            {
                if (regex == null)
                {
                    regex = new Regex(pattern, SyntaxHighlighter.RegexCompiledOption | options);
                }
                return regex;
            }
        }
    }

    /// <summary>
    /// Class FoldingDesc.
    /// </summary>
    public class FoldingDesc
    {
        /// <summary>
        /// The start marker regex
        /// </summary>
        public string startMarkerRegex;
        /// <summary>
        /// The finish marker regex
        /// </summary>
        public string finishMarkerRegex;
        /// <summary>
        /// The options
        /// </summary>
        public RegexOptions options = RegexOptions.None;
    }
}
