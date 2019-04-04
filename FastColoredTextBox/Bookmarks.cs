// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Bookmarks.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Base class for bookmark collection
    /// </summary>
    /// <seealso cref="System.Collections.Generic.ICollection{Zeroit.Framework.MiscControls.FastControls.Bookmark}" />
    /// <seealso cref="System.IDisposable" />
    public abstract class BaseBookmarks : ICollection<Bookmark>, IDisposable
    {
        #region ICollection
        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        public abstract void Add(Bookmark item);
        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public abstract void Clear();
        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.</returns>
        public abstract bool Contains(Bookmark item);
        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        public abstract void CopyTo(Bookmark[] array, int arrayIndex);
        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <value>The count.</value>
        public abstract int Count { get; }
        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public abstract bool IsReadOnly { get; }
        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.</returns>
        public abstract bool Remove(Bookmark item);
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public abstract IEnumerator<Bookmark> GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region IDisposable
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public abstract void Dispose();
        #endregion

        #region Additional properties

        /// <summary>
        /// Adds the specified line index.
        /// </summary>
        /// <param name="lineIndex">Index of the line.</param>
        /// <param name="bookmarkName">Name of the bookmark.</param>
        public abstract void Add(int lineIndex, string bookmarkName);
        /// <summary>
        /// Adds the specified line index.
        /// </summary>
        /// <param name="lineIndex">Index of the line.</param>
        public abstract void Add(int lineIndex);
        /// <summary>
        /// Determines whether [contains] [the specified line index].
        /// </summary>
        /// <param name="lineIndex">Index of the line.</param>
        /// <returns><c>true</c> if [contains] [the specified line index]; otherwise, <c>false</c>.</returns>
        public abstract bool Contains(int lineIndex);
        /// <summary>
        /// Removes the specified line index.
        /// </summary>
        /// <param name="lineIndex">Index of the line.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public abstract bool Remove(int lineIndex);
        /// <summary>
        /// Gets the bookmark.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>Bookmark.</returns>
        public abstract Bookmark GetBookmark(int i);

        #endregion
    }

    /// <summary>
    /// Collection of bookmarks
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.BaseBookmarks" />
    public class Bookmarks : BaseBookmarks
    {
        /// <summary>
        /// The tb
        /// </summary>
        protected ZeroitCodeTextBox tb;
        /// <summary>
        /// The items
        /// </summary>
        protected List<Bookmark> items = new List<Bookmark>();
        /// <summary>
        /// The counter
        /// </summary>
        protected int counter;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bookmarks"/> class.
        /// </summary>
        /// <param name="tb">The tb.</param>
        public Bookmarks(ZeroitCodeTextBox tb)
        {
            this.tb = tb;
            tb.LineInserted += tb_LineInserted;
            tb.LineRemoved += tb_LineRemoved;
        }

        /// <summary>
        /// Handles the LineRemoved event of the tb control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LineRemovedEventArgs"/> instance containing the event data.</param>
        protected virtual void tb_LineRemoved(object sender, LineRemovedEventArgs e)
        {
            for(int i=0; i<Count; i++)
            if (items[i].LineIndex >= e.Index)
            {
                if (items[i].LineIndex >= e.Index + e.Count)
                {
                    items[i].LineIndex = items[i].LineIndex - e.Count;
                    continue;
                }

                var was = e.Index <= 0;
                foreach (var b in items)
                    if (b.LineIndex == e.Index - 1)
                        was = true;

                if(was)
                {
                    items.RemoveAt(i);
                    i--;
                }else
                    items[i].LineIndex = e.Index - 1;

                //if (items[i].LineIndex == e.Index + e.Count - 1)
                //{
                //    items[i].LineIndex = items[i].LineIndex - e.Count;
                //    continue;
                //}
                //
                //items.RemoveAt(i);
                //i--;
            }
        }

        /// <summary>
        /// Handles the LineInserted event of the tb control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LineInsertedEventArgs"/> instance containing the event data.</param>
        protected virtual void tb_LineInserted(object sender, LineInsertedEventArgs e)
        {
            for (int i = 0; i < Count; i++)
                if (items[i].LineIndex >= e.Index)
                {
                    items[i].LineIndex = items[i].LineIndex + e.Count;
                }else
                if (items[i].LineIndex == e.Index - 1 && e.Count == 1)
                {
                    if(tb[e.Index - 1].StartSpacesCount == tb[e.Index - 1].Count)
                        items[i].LineIndex = items[i].LineIndex + e.Count;
                }
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public override void Dispose()
        {
            tb.LineInserted -= tb_LineInserted;
            tb.LineRemoved -= tb_LineRemoved;
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>IEnumerator&lt;Bookmark&gt;.</returns>
        public override IEnumerator<Bookmark> GetEnumerator()
        {
            foreach (var item in items)
                yield return item;
        }

        /// <summary>
        /// Adds the specified line index.
        /// </summary>
        /// <param name="lineIndex">Index of the line.</param>
        /// <param name="bookmarkName">Name of the bookmark.</param>
        public override void Add(int lineIndex, string bookmarkName)
        {
            Add(new Bookmark(tb, bookmarkName ?? "Bookmark " + counter, lineIndex));
        }

        /// <summary>
        /// Adds the specified line index.
        /// </summary>
        /// <param name="lineIndex">Index of the line.</param>
        public override void Add(int lineIndex)
        {
            Add(new Bookmark(tb, "Bookmark " + counter, lineIndex));
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public override void Clear()
        {
            items.Clear();
            counter = 0;
        }

        /// <summary>
        /// Adds the specified bookmark.
        /// </summary>
        /// <param name="bookmark">The bookmark.</param>
        public override void Add(Bookmark bookmark)
        {
            foreach (var bm in items)
                if (bm.LineIndex == bookmark.LineIndex)
                    return;

            items.Add(bookmark);
            counter++;
            tb.Invalidate();
        }

        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.</returns>
        public override bool Contains(Bookmark item)
        {
            return items.Contains(item);
        }

        /// <summary>
        /// Determines whether [contains] [the specified line index].
        /// </summary>
        /// <param name="lineIndex">Index of the line.</param>
        /// <returns><c>true</c> if [contains] [the specified line index]; otherwise, <c>false</c>.</returns>
        public override bool Contains(int lineIndex)
        {
            foreach (var item in items)
                if (item.LineIndex == lineIndex)
                    return true;
            return false;
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        public override void CopyTo(Bookmark[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public override int Count
        {
            get { return items.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public override bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool Remove(Bookmark item)
        {
            tb.Invalidate();
            return items.Remove(item);
        }

        /// <summary>
        /// Removes bookmark by line index
        /// </summary>
        /// <param name="lineIndex">Index of the line.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool Remove(int lineIndex)
        {
            bool was = false;
            for (int i = 0; i < Count; i++)
            if (items[i].LineIndex == lineIndex)
            {
                items.RemoveAt(i);
                i--;
                was = true;
            }
            tb.Invalidate();

            return was;
        }

        /// <summary>
        /// Returns Bookmark by index.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>Bookmark.</returns>
        public override Bookmark GetBookmark(int i)
        {
            return items[i];
        }
    }

    /// <summary>
    /// Bookmark of FastColoredTextbox
    /// </summary>
    public class Bookmark
    {
        /// <summary>
        /// Gets the tb.
        /// </summary>
        /// <value>The tb.</value>
        public ZeroitCodeTextBox TB { get; private set; }
        /// <summary>
        /// Name of bookmark
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Line index
        /// </summary>
        /// <value>The index of the line.</value>
        public int LineIndex {get; set; }
        /// <summary>
        /// Color of bookmark sign
        /// </summary>
        /// <value>The color.</value>
        public Color Color { get; set; }

        /// <summary>
        /// Scroll textbox to the bookmark
        /// </summary>
        public virtual void DoVisible()
        {
            TB.Selection.Start = new Place(0, LineIndex);
            TB.DoRangeVisible(TB.Selection, true);
            TB.Invalidate();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bookmark"/> class.
        /// </summary>
        /// <param name="tb">The tb.</param>
        /// <param name="name">The name.</param>
        /// <param name="lineIndex">Index of the line.</param>
        public Bookmark(ZeroitCodeTextBox tb, string name, int lineIndex)
        {
            this.TB = tb;
            this.Name = name;
            this.LineIndex = lineIndex;
            Color = tb.BookmarkColor;
        }

        /// <summary>
        /// Paints the specified gr.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="lineRect">The line rect.</param>
        public virtual void Paint(Graphics gr, Rectangle lineRect)
        {
            var size = TB.CharHeight - 1;
            using (var brush = new LinearGradientBrush(new Rectangle(0, lineRect.Top, size, size), Color.White, Color, 45))
                gr.FillEllipse(brush, 0, lineRect.Top, size, size);
            using (var pen = new Pen(Color))
                gr.DrawEllipse(pen, 0, lineRect.Top, size, size);
        }
    }
}
