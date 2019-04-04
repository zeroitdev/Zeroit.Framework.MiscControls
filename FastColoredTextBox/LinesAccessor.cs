// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="LinesAccessor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Class LinesAccessor.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IList{System.String}" />
    public class LinesAccessor : IList<string>
    {
        /// <summary>
        /// The ts
        /// </summary>
        IList<Line> ts;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinesAccessor"/> class.
        /// </summary>
        /// <param name="ts">The ts.</param>
        public LinesAccessor(IList<Line> ts)
        {
            this.ts = ts;
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1" />.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1" />.</param>
        /// <returns>The index of <paramref name="item" /> if found in the list; otherwise, -1.</returns>
        public int IndexOf(string item)
        {
            for (int i = 0; i < ts.Count; i++)
                if (ts[i].Text == item)
                    return i;

            return -1;
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1" /> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
        /// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1" />.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Insert(int index, string item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets or sets the <see cref="System.String"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string this[int index]
        {
            get
            {
                return ts[index].Text;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Add(string item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.</returns>
        public bool Contains(string item)
        {
            for (int i = 0; i < ts.Count; i++)
                if (ts[i].Text == item)
                    return true;

            return false;
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        public void CopyTo(string[] array, int arrayIndex)
        {
            for (int i = 0; i < ts.Count; i++)
                array[i + arrayIndex] = ts[i].Text;
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return ts.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly
        {
            get { return true; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Remove(string item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < ts.Count; i++)
                yield return ts[i].Text;
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
