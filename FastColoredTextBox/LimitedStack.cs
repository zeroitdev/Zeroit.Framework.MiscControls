// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-22-2018
// ***********************************************************************
// <copyright file="LimitedStack.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Limited stack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LimitedStack<T>
    {
        /// <summary>
        /// The items
        /// </summary>
        T[] items;
        /// <summary>
        /// The count
        /// </summary>
        int count;
        /// <summary>
        /// The start
        /// </summary>
        int start;

        /// <summary>
        /// Max stack length
        /// </summary>
        /// <value>The maximum item count.</value>
        public int MaxItemCount
        {
            get { return items.Length; }
        }

        /// <summary>
        /// Current length of stack
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxItemCount">Maximum length of stack</param>
        public LimitedStack(int maxItemCount)
        {
            items = new T[maxItemCount];
            count = 0;
            start = 0;
        }

        /// <summary>
        /// Pop item
        /// </summary>
        /// <returns>T.</returns>
        /// <exception cref="System.Exception">Stack is empty</exception>
        public T Pop()
        {
            if (count == 0)
                throw new Exception("Stack is empty");

            int i = LastIndex;
            T item = items[i];
            items[i] = default(T);

            count--;

            return item;
        }

        /// <summary>
        /// Gets the last index.
        /// </summary>
        /// <value>The last index.</value>
        int LastIndex
        {
            get { return (start + count - 1) % items.Length; }
        }

        /// <summary>
        /// Peek item
        /// </summary>
        /// <returns>T.</returns>
        public T Peek()
        {
            if (count == 0)
                return default(T);

            return items[LastIndex];
        }

        /// <summary>
        /// Push item
        /// </summary>
        /// <param name="item">The item.</param>
        public void Push(T item)
        {
            if (count == items.Length)
                start = (start + 1) % items.Length;
            else
                count++;

            items[LastIndex] = item;
        }

        /// <summary>
        /// Clear stack
        /// </summary>
        public void Clear()
        {
            items = new T[items.Length];
            count = 0;
            start = 0;
        }

        /// <summary>
        /// To the array.
        /// </summary>
        /// <returns>T[].</returns>
        public T[] ToArray()
        {
            T[] result = new T[count];
            for (int i = 0; i < count; i++)
                result[i] = items[(start + i) % items.Length];
            return result;
        }
    }
}