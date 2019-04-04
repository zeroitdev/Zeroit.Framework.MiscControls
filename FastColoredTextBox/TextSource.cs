// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="TextSource.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.IO;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// This class contains the source text (chars and styles).
    /// It stores a text lines, the manager of commands, undo/redo stack, styles.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IList{Zeroit.Framework.MiscControls.FastControls.Line}" />
    /// <seealso cref="System.IDisposable" />
    public class TextSource: IList<Line>, IDisposable
    {
        /// <summary>
        /// The lines
        /// </summary>
        readonly protected List<Line> lines = new List<Line>();
        /// <summary>
        /// The lines accessor
        /// </summary>
        protected LinesAccessor linesAccessor;
        /// <summary>
        /// The last line unique identifier
        /// </summary>
        int lastLineUniqueId;
        /// <summary>
        /// Gets or sets the manager.
        /// </summary>
        /// <value>The manager.</value>
        public CommandManager Manager { get; set; }
        /// <summary>
        /// The current tb
        /// </summary>
        ZeroitCodeTextBox currentTB;
        /// <summary>
        /// Styles
        /// </summary>
        public readonly Style[] Styles;
        /// <summary>
        /// Occurs when line was inserted/added
        /// </summary>
        public event EventHandler<LineInsertedEventArgs> LineInserted;
        /// <summary>
        /// Occurs when line was removed
        /// </summary>
        public event EventHandler<LineRemovedEventArgs> LineRemoved;
        /// <summary>
        /// Occurs when text was changed
        /// </summary>
        public event EventHandler<TextChangedEventArgs> TextChanged;
        /// <summary>
        /// Occurs when recalc is needed
        /// </summary>
        public event EventHandler<TextChangedEventArgs> RecalcNeeded;
        /// <summary>
        /// Occurs when recalc wordwrap is needed
        /// </summary>
        public event EventHandler<TextChangedEventArgs> RecalcWordWrap;
        /// <summary>
        /// Occurs before text changing
        /// </summary>
        public event EventHandler<TextChangingEventArgs> TextChanging;
        /// <summary>
        /// Occurs after CurrentTB was changed
        /// </summary>
        public event EventHandler CurrentTBChanged;
        /// <summary>
        /// Current focused ZeroitCodeTextBox
        /// </summary>
        /// <value>The current tb.</value>
        public ZeroitCodeTextBox CurrentTB {
            get { return currentTB; }
            set {
                if (currentTB == value)
                    return;
                currentTB = value;
                OnCurrentTBChanged(); 
            }
        }

        /// <summary>
        /// Clears the is changed.
        /// </summary>
        public virtual void ClearIsChanged()
        {
            foreach(var line in lines)
                line.IsChanged = false;
        }

        /// <summary>
        /// Creates the line.
        /// </summary>
        /// <returns>Line.</returns>
        public virtual Line CreateLine()
        {
            return new Line(GenerateUniqueLineId());
        }

        /// <summary>
        /// Called when [current tb changed].
        /// </summary>
        private void OnCurrentTBChanged()
        {
            if (CurrentTBChanged != null)
                CurrentTBChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Default text style
        /// This style is using when no one other ZeroitFastTextStyle is not defined in Char.style
        /// </summary>
        /// <value>The default style.</value>
        public ZeroitFastTextStyle DefaultStyle { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextSource"/> class.
        /// </summary>
        /// <param name="currentTB">The current tb.</param>
        public TextSource(ZeroitCodeTextBox currentTB)
        {
            this.CurrentTB = currentTB;
            linesAccessor = new LinesAccessor(this);
            Manager = new CommandManager(this);

            if (Enum.GetUnderlyingType(typeof(StyleIndex)) == typeof(UInt32))
                Styles = new Style[32];
            else
                Styles = new Style[16];

            InitDefaultStyle();
        }

        /// <summary>
        /// Initializes the default style.
        /// </summary>
        public virtual void InitDefaultStyle()
        {
            DefaultStyle = new ZeroitFastTextStyle(null, null, FontStyle.Regular);
        }

        /// <summary>
        /// Gets or sets the <see cref="Line"/> with the specified i.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>Line.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual Line this[int i]
        {
            get{
                 return lines[i];
            }
            set {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Determines whether [is line loaded] [the specified i line].
        /// </summary>
        /// <param name="iLine">The i line.</param>
        /// <returns><c>true</c> if [is line loaded] [the specified i line]; otherwise, <c>false</c>.</returns>
        public virtual bool IsLineLoaded(int iLine)
        {
            return lines[iLine] != null;
        }

        /// <summary>
        /// Text lines
        /// </summary>
        /// <returns>IList&lt;System.String&gt;.</returns>
        public virtual IList<string> GetLines()
        {
            return linesAccessor;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<Line> GetEnumerator()
        {
            return lines.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (lines  as IEnumerator);
        }

        /// <summary>
        /// Binaries the search.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>System.Int32.</returns>
        public virtual int BinarySearch(Line item, IComparer<Line> comparer)
        {
            return lines.BinarySearch(item, comparer);
        }

        /// <summary>
        /// Generates the unique line identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public virtual int GenerateUniqueLineId()
        {
            return lastLineUniqueId++;
        }

        /// <summary>
        /// Inserts the line.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="line">The line.</param>
        public virtual void InsertLine(int index, Line line)
        {
            lines.Insert(index, line);
            OnLineInserted(index);
        }

        /// <summary>
        /// Called when [line inserted].
        /// </summary>
        /// <param name="index">The index.</param>
        public virtual void OnLineInserted(int index)
        {
            OnLineInserted(index, 1);
        }

        /// <summary>
        /// Called when [line inserted].
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public virtual void OnLineInserted(int index, int count)
        {
            if (LineInserted != null)
                LineInserted(this, new LineInsertedEventArgs(index, count));
        }

        /// <summary>
        /// Removes the line.
        /// </summary>
        /// <param name="index">The index.</param>
        public virtual void RemoveLine(int index)
        {
            RemoveLine(index, 1);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is need build removed line ids.
        /// </summary>
        /// <value><c>true</c> if this instance is need build removed line ids; otherwise, <c>false</c>.</value>
        public virtual bool IsNeedBuildRemovedLineIds
        {
            get { return LineRemoved != null; }
        }

        /// <summary>
        /// Removes the line.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public virtual void RemoveLine(int index, int count)
        {
            List<int> removedLineIds = new List<int>();
            //
            if (count > 0)
                if (IsNeedBuildRemovedLineIds)
                    for (int i = 0; i < count; i++)
                        removedLineIds.Add(this[index + i].UniqueId);
            //
            lines.RemoveRange(index, count);

            OnLineRemoved(index, count, removedLineIds);
        }

        /// <summary>
        /// Called when [line removed].
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <param name="removedLineIds">The removed line ids.</param>
        public virtual void OnLineRemoved(int index, int count, List<int> removedLineIds)
        {
            if (count > 0)
                if (LineRemoved != null)
                    LineRemoved(this, new LineRemovedEventArgs(index, count, removedLineIds));
        }

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="fromLine">From line.</param>
        /// <param name="toLine">To line.</param>
        public virtual void OnTextChanged(int fromLine, int toLine)
        {
            if (TextChanged != null)
                TextChanged(this, new TextChangedEventArgs(Math.Min(fromLine, toLine), Math.Max(fromLine, toLine) ));
        }

        /// <summary>
        /// Class TextChangedEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class TextChangedEventArgs : EventArgs
        {
            /// <summary>
            /// The i from line
            /// </summary>
            public int iFromLine;
            /// <summary>
            /// The i to line
            /// </summary>
            public int iToLine;

            /// <summary>
            /// Initializes a new instance of the <see cref="TextChangedEventArgs"/> class.
            /// </summary>
            /// <param name="iFromLine">The i from line.</param>
            /// <param name="iToLine">The i to line.</param>
            public TextChangedEventArgs(int iFromLine, int iToLine)
            {
                this.iFromLine = iFromLine;
                this.iToLine = iToLine;
            }
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1" />.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1" />.</param>
        /// <returns>The index of <paramref name="item" /> if found in the list; otherwise, -1.</returns>
        public virtual int IndexOf(Line item)
        {
            return lines.IndexOf(item);
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1" /> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
        /// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1" />.</param>
        public virtual void Insert(int index, Line item)
        {
            InsertLine(index, item);
        }

        /// <summary>
        /// Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public virtual void RemoveAt(int index)
        {
            RemoveLine(index);
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        public virtual void Add(Line item)
        {
            InsertLine(Count, item);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public virtual void Clear()
        {
            RemoveLine(0, Count);
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.</returns>
        public virtual bool Contains(Line item)
        {
            return lines.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        public virtual void CopyTo(Line[] array, int arrayIndex)
        {
            lines.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Lines count
        /// </summary>
        /// <value>The count.</value>
        public virtual int Count
        {
            get { return lines.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.</returns>
        public virtual bool Remove(Line item)
        {
            int i = IndexOf(item);
            if (i >= 0)
            {
                RemoveLine(i);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Needs the recalc.
        /// </summary>
        /// <param name="args">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        public virtual void NeedRecalc(TextChangedEventArgs args)
        {
            if (RecalcNeeded != null)
                RecalcNeeded(this, args);
        }

        /// <summary>
        /// Handles the <see cref="E:RecalcWordWrap" /> event.
        /// </summary>
        /// <param name="args">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        public virtual void OnRecalcWordWrap(TextChangedEventArgs args)
        {
            if (RecalcWordWrap != null)
                RecalcWordWrap(this, args);
        }

        /// <summary>
        /// Called when [text changing].
        /// </summary>
        public virtual void OnTextChanging()
        {
            string temp = null;
            OnTextChanging(ref temp);
        }

        /// <summary>
        /// Called when [text changing].
        /// </summary>
        /// <param name="text">The text.</param>
        public virtual void OnTextChanging(ref string text)
        {
            if (TextChanging != null)
            {
                var args = new TextChangingEventArgs() { InsertingText = text };
                TextChanging(this, args);
                text = args.InsertingText;
                if (args.Cancel)
                    text = string.Empty;
            };
        }

        /// <summary>
        /// Gets the length of the line.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>System.Int32.</returns>
        public virtual int GetLineLength(int i)
        {
            return lines[i].Count;
        }

        /// <summary>
        /// Lines the has folding start marker.
        /// </summary>
        /// <param name="iLine">The i line.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool LineHasFoldingStartMarker(int iLine)
        {
            return !string.IsNullOrEmpty(lines[iLine].FoldingStartMarker);
        }

        /// <summary>
        /// Lines the has folding end marker.
        /// </summary>
        /// <param name="iLine">The i line.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool LineHasFoldingEndMarker(int iLine)
        {
            return !string.IsNullOrEmpty(lines[iLine].FoldingEndMarker);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            ;
        }

        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="enc">The enc.</param>
        public virtual void SaveToFile(string fileName, Encoding enc)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false, enc))
            {
                for (int i = 0; i < Count - 1;i++ )
                    sw.WriteLine(lines[i].Text);

                sw.Write(lines[Count-1].Text);
            }
        }
    }
}
