// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ExportToRTF.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Text;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Exports colored text as RTF
    /// </summary>
    /// <remarks>At this time only ZeroitFastTextStyle renderer is supported. Other styles are not exported.</remarks>
    public class ExportToRTF
    {
        /// <summary>
        /// Includes line numbers
        /// </summary>
        /// <value><c>true</c> if [include line numbers]; otherwise, <c>false</c>.</value>
        public bool IncludeLineNumbers { get; set; }
        /// <summary>
        /// Use original font
        /// </summary>
        /// <value><c>true</c> if [use original font]; otherwise, <c>false</c>.</value>
        public bool UseOriginalFont { get; set; }

        /// <summary>
        /// The tb
        /// </summary>
        ZeroitCodeTextBox tb;
        /// <summary>
        /// The color table
        /// </summary>
        Dictionary<Color, int> colorTable = new Dictionary<Color, int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportToRTF"/> class.
        /// </summary>
        public ExportToRTF()
        {
            UseOriginalFont = true;
        }

        /// <summary>
        /// Gets the RTF.
        /// </summary>
        /// <param name="tb">The tb.</param>
        /// <returns>System.String.</returns>
        public string GetRtf(ZeroitCodeTextBox tb)
        {
            this.tb = tb;
            Range sel = new Range(tb);
            sel.SelectAll();
            return GetRtf(sel);
        }

        /// <summary>
        /// Gets the RTF.
        /// </summary>
        /// <param name="r">The r.</param>
        /// <returns>System.String.</returns>
        public string GetRtf(Range r)
        {
            this.tb = r.tb;
            var styles = new Dictionary<StyleIndex, object>();
            var sb = new StringBuilder();
            var tempSB = new StringBuilder();
            var currentStyleId = StyleIndex.None;
            r.Normalize();
            int currentLine = r.Start.iLine;
            styles[currentStyleId] = null;
            colorTable.Clear();
            //
            var lineNumberColor = GetColorTableNumber(r.tb.LineNumberColor);

            if (IncludeLineNumbers)
                tempSB.AppendFormat(@"{{\cf{1} {0}}}\tab", currentLine + 1, lineNumberColor);
            //
            foreach (Place p in r)
            {
                Char c = r.tb[p.iLine][p.iChar];
                if (c.style != currentStyleId)
                {
                    Flush(sb, tempSB, currentStyleId);
                    currentStyleId = c.style;
                    styles[currentStyleId] = null;
                }

                if (p.iLine != currentLine)
                {
                    for (int i = currentLine; i < p.iLine; i++)
                    {
                        tempSB.AppendLine(@"\line");
                        if (IncludeLineNumbers)
                            tempSB.AppendFormat(@"{{\cf{1} {0}}}\tab", i + 2, lineNumberColor);
                    }
                    currentLine = p.iLine;
                }
                switch (c.c)
                {
                    case '\\':
                        tempSB.Append(@"\\");
                        break;
                    case '{':
                        tempSB.Append(@"\{");
                        break;
                    case '}':
                        tempSB.Append(@"\}");
                        break;
                    default:
                        var ch = c.c;
                        var code = (int)ch;
                        if(code < 128)
                            tempSB.Append(c.c);
                        else
                            tempSB.AppendFormat(@"{{\u{0}}}", code);
                        break;
                }
            }
            Flush(sb, tempSB, currentStyleId);
           
            //build color table
            var list = new SortedList<int, Color>();
            foreach (var pair in colorTable)
                list.Add(pair.Value, pair.Key);

            tempSB.Length = 0;
            tempSB.AppendFormat(@"{{\colortbl;");

            foreach (var pair in list)
                tempSB.Append(GetColorAsString(pair.Value)+";");
            tempSB.AppendLine("}");

            //
            if (UseOriginalFont)
            {
                sb.Insert(0, string.Format(@"{{\fonttbl{{\f0\fmodern {0};}}}}{{\fs{1} ",
                                tb.Font.Name, (int)(2 * tb.Font.SizeInPoints), tb.CharHeight));
                sb.AppendLine(@"}");
            }

            sb.Insert(0, tempSB.ToString());

            sb.Insert(0, @"{\rtf1\ud\deff0");
            sb.AppendLine(@"}");

            return sb.ToString();
        }

        /// <summary>
        /// Gets the RTF descriptor.
        /// </summary>
        /// <param name="styleIndex">Index of the style.</param>
        /// <returns>RTFStyleDescriptor.</returns>
        private RTFStyleDescriptor GetRtfDescriptor(StyleIndex styleIndex)
        {
            List<Style> styles = new List<Style>();
            //find text renderer
            ZeroitFastTextStyle textStyle = null;
            int mask = 1;
            bool hasZeroitFastTextStyle = false;
            for (int i = 0; i < tb.Styles.Length; i++)
            {
                if (tb.Styles[i] != null && ((int)styleIndex & mask) != 0)
                    if (tb.Styles[i].IsExportable)
                    {
                        var style = tb.Styles[i];
                        styles.Add(style);

                        bool isZeroitFastTextStyle = style is ZeroitFastTextStyle;
                        if (isZeroitFastTextStyle)
                            if (!hasZeroitFastTextStyle || tb.AllowSeveralZeroitFastTextStyleDrawing)
                            {
                                hasZeroitFastTextStyle = true;
                                textStyle = style as ZeroitFastTextStyle;
                            }
                    }
                mask = mask << 1;
            }
            //add ZeroitFastTextStyle css
            RTFStyleDescriptor result = null;

            if (!hasZeroitFastTextStyle)
            {
                //draw by default renderer
                result = tb.DefaultStyle.GetRTF();
            }
            else
            {
                result = textStyle.GetRTF();
            }

            return result;
        }

        /// <summary>
        /// Gets the color as string.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>System.String.</returns>
        public static string GetColorAsString(Color color)
        {
            if (color == Color.Transparent)
                return "";
            return string.Format(@"\red{0}\green{1}\blue{2}", color.R, color.G, color.B);
        }

        /// <summary>
        /// Flushes the specified sb.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="tempSB">The temporary sb.</param>
        /// <param name="currentStyle">The current style.</param>
        private void Flush(StringBuilder sb, StringBuilder tempSB, StyleIndex currentStyle)
        {
            //find textRenderer
            if (tempSB.Length == 0)
                return;

            var desc = GetRtfDescriptor(currentStyle);
            var cf = GetColorTableNumber(desc.ForeColor);
            var cb = GetColorTableNumber(desc.BackColor);
            var tags = new StringBuilder();
            if (cf >= 0)
                tags.AppendFormat(@"\cf{0}", cf);
            if (cb >= 0)
                tags.AppendFormat(@"\highlight{0}", cb);
            if(!string.IsNullOrEmpty(desc.AdditionalTags))
                tags.Append(desc.AdditionalTags.Trim());

            if(tags.Length > 0)
                sb.AppendFormat(@"{{{0} {1}}}", tags, tempSB.ToString());
            else
                sb.Append(tempSB.ToString());
            tempSB.Length = 0;
        }

        /// <summary>
        /// Gets the color table number.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>System.Int32.</returns>
        private int GetColorTableNumber(Color color)
        {
            if (color.A == 0)
                return -1;

            if (!colorTable.ContainsKey(color))
                colorTable[color] = colorTable.Count + 1;

            return colorTable[color];
        }
    }

    /// <summary>
    /// Class RTFStyleDescriptor.
    /// </summary>
    public class RTFStyleDescriptor
    {
        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor { get; set; }
        /// <summary>
        /// Gets or sets the additional tags.
        /// </summary>
        /// <value>The additional tags.</value>
        public string AdditionalTags { get; set; }
    }
}
