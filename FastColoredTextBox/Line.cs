// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-22-2018
// ***********************************************************************
// <copyright file="Line.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System;
using System.Text;
using System.Drawing;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Line of text
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IList{Zeroit.Framework.MiscControls.FastControls.Char}" />
    public class Line : IList<Char>
    {
        /// <summary>
        /// The chars
        /// </summary>
        protected List<Char> chars;

        /// <summary>
        /// Gets or sets the folding start marker.
        /// </summary>
        /// <value>The folding start marker.</value>
        public string FoldingStartMarker { get; set; }
        /// <summary>
        /// Gets or sets the folding end marker.
        /// </summary>
        /// <value>The folding end marker.</value>
        public string FoldingEndMarker { get; set; }
        /// <summary>
        /// Text of line was changed
        /// </summary>
        /// <value><c>true</c> if this instance is changed; otherwise, <c>false</c>.</value>
        public bool IsChanged { get; set; }
        /// <summary>
        /// Time of last visit of caret in this line
        /// </summary>
        /// <value>The last visit.</value>
        /// <remarks>This property can be used for forward/backward navigating</remarks>
        public DateTime LastVisit { get; set; }
        /// <summary>
        /// Background brush.
        /// </summary>
        /// <value>The background brush.</value>
        public Brush BackgroundBrush { get; set;}
        /// <summary>
        /// Unique ID
        /// </summary>
        /// <value>The unique identifier.</value>
        public int UniqueId { get; private set; }
        /// <summary>
        /// Count of needed start spaces for AutoIndent
        /// </summary>
        /// <value>The automatic indent spaces needed count.</value>
        public int AutoIndentSpacesNeededCount
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        /// <param name="uid">The uid.</param>
        internal Line(int uid)
        {
            this.UniqueId = uid;
            chars = new List<Char>();
        }


        /// <summary>
        /// Clears style of chars, delete folding markers
        /// </summary>
        /// <param name="styleIndex">Index of the style.</param>
        public void ClearStyle(StyleIndex styleIndex)
        {
            FoldingStartMarker = null;
            FoldingEndMarker = null;
            for (int i = 0; i < Count; i++)
            {
                Char c = this[i];
                c.style &= ~styleIndex;
                this[i] = c;
            }
        }

        /// <summary>
        /// Text of the line
        /// </summary>
        /// <value>The text.</value>
        public virtual string Text
        {
            get{
                StringBuilder sb = new StringBuilder(Count);
                foreach(Char c in this)
                    sb.Append(c.c);
                return sb.ToString();
            }
        }

        /// <summary>
        /// Clears folding markers
        /// </summary>
        public void ClearFoldingMarkers()
        {
            FoldingStartMarker = null;
            FoldingEndMarker = null;
        }

        /// <summary>
        /// Count of start spaces
        /// </summary>
        /// <value>The start spaces count.</value>
        public int StartSpacesCount
        {
            get
            {
                int spacesCount = 0;
                for (int i = 0; i < Count; i++)
                    if (this[i].c == ' ')
                        spacesCount++;
                    else
                        break;
                return spacesCount;
            }
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1" />.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1" />.</param>
        /// <returns>The index of <paramref name="item" /> if found in the list; otherwise, -1.</returns>
        public int IndexOf(Char item)
        {
            return chars.IndexOf(item);
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1" /> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
        /// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1" />.</param>
        public void Insert(int index, Char item)
        {
            chars.Insert(index, item);
        }

        /// <summary>
        /// Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            chars.RemoveAt(index);
        }

        /// <summary>
        /// Gets or sets the <see cref="Char"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Char.</returns>
        public Char this[int index]
        {
            get
            {
                return chars[index];
            }
            set
            {
                chars[index] = value;
            }
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        public void Add(Char item)
        {
            chars.Add(item);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public void Clear()
        {
            chars.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.</returns>
        public bool Contains(Char item)
        {
            return chars.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        public void CopyTo(Char[] array, int arrayIndex)
        {
            chars.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Chars count
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return chars.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly
        {
            get {  return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.</returns>
        public bool Remove(Char item)
        {
            return chars.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<Char> GetEnumerator()
        {
            return chars.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return chars.GetEnumerator() as System.Collections.IEnumerator;
        }

        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public virtual void RemoveRange(int index, int count)
        {
            if (index >= Count)
                return;
            chars.RemoveRange(index, Math.Min(Count - index, count));
        }

        /// <summary>
        /// Trims the excess.
        /// </summary>
        public virtual void TrimExcess()
        {
            chars.TrimExcess();
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public virtual void AddRange(IEnumerable<Char> collection)
        {
            chars.AddRange(collection);
        }
    }

    /// <summary>
    /// Struct LineInfo
    /// </summary>
    public struct LineInfo
    {
        /// <summary>
        /// The cut off positions
        /// </summary>
        List<int> cutOffPositions;
        //Y coordinate of line on screen
        /// <summary>
        /// The start y
        /// </summary>
        internal int startY;
        /// <summary>
        /// The bottom padding
        /// </summary>
        internal int bottomPadding;
        //indent of secondary wordwrap strings (in chars)
        /// <summary>
        /// The word wrap indent
        /// </summary>
        internal int wordWrapIndent;
        /// <summary>
        /// Visible state
        /// </summary>
        public VisibleState VisibleState;

        /// <summary>
        /// Initializes a new instance of the <see cref="LineInfo"/> struct.
        /// </summary>
        /// <param name="startY">The start y.</param>
        public LineInfo(int startY)
        {
            cutOffPositions = null;
            VisibleState = VisibleState.Visible;
            this.startY = startY;
            bottomPadding = 0;
            wordWrapIndent = 0;
        }
        /// <summary>
        /// Positions for wordwrap cutoffs
        /// </summary>
        /// <value>The cut off positions.</value>
        public List<int> CutOffPositions
        {
            get
            {
                if (cutOffPositions == null)
                    cutOffPositions = new List<int>();
                return cutOffPositions;
            }
        }

        /// <summary>
        /// Count of wordwrap string count for this line
        /// </summary>
        /// <value>The word wrap strings count.</value>
        public int WordWrapStringsCount
        {
            get
            {
                switch (VisibleState)
                {
                    case VisibleState.Visible:
                         if (cutOffPositions == null)
                            return 1;
                         else
                            return cutOffPositions.Count + 1;
                    case VisibleState.Hidden: return 0;
                    case VisibleState.StartOfHiddenBlock: return 1;
                }

                return 0;
            }
        }

        /// <summary>
        /// Gets the word wrap string start position.
        /// </summary>
        /// <param name="iWordWrapLine">The i word wrap line.</param>
        /// <returns>System.Int32.</returns>
        internal int GetWordWrapStringStartPosition(int iWordWrapLine)
        {
            return iWordWrapLine == 0 ? 0 : CutOffPositions[iWordWrapLine - 1];
        }

        /// <summary>
        /// Gets the word wrap string finish position.
        /// </summary>
        /// <param name="iWordWrapLine">The i word wrap line.</param>
        /// <param name="line">The line.</param>
        /// <returns>System.Int32.</returns>
        internal int GetWordWrapStringFinishPosition(int iWordWrapLine, Line line)
        {
            if (WordWrapStringsCount <= 0)
                return 0;
            return iWordWrapLine == WordWrapStringsCount - 1 ? line.Count - 1 : CutOffPositions[iWordWrapLine] - 1;
        }

        /// <summary>
        /// Gets index of wordwrap string for given char position
        /// </summary>
        /// <param name="iChar">The i character.</param>
        /// <returns>System.Int32.</returns>
        public int GetWordWrapStringIndex(int iChar)
        {
            if (cutOffPositions == null || cutOffPositions.Count == 0) return 0;
            for (int i = 0; i < cutOffPositions.Count; i++)
                if (cutOffPositions[i] >/*>=*/ iChar)
                    return i;
            return cutOffPositions.Count;
        }
    }

    /// <summary>
    /// Enum VisibleState
    /// </summary>
    public enum VisibleState: byte
    {
        /// <summary>
        /// The visible
        /// </summary>
        Visible, StartOfHiddenBlock, Hidden
    }

    /// <summary>
    /// Enum IndentMarker
    /// </summary>
    public enum IndentMarker
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The increased
        /// </summary>
        Increased,
        /// <summary>
        /// The decreased
        /// </summary>
        Decreased
    }
}
