// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="GenericCollection.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Generic collection with events.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.CollectionBase" />
    /// <seealso cref="System.Runtime.Serialization.IDeserializationCallback" />
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="System.Runtime.Serialization.ISerializable" />
    public class GenericCollection<T> : CollectionBase, IDeserializationCallback, IDisposable, ISerializable
    {
        #region Delegates

        /// <summary>
        /// Represents a method which will handle <see cref="GenericCollection{T}.Inserted" /> and <see cref="GenericCollection{T}.Removed" /> events.
        /// </summary>
        /// <param name="index">Index of item</param>
        /// <param name="value">Item</param>
        public delegate void CollectionChangedHandler(int index, T value);

        /// <summary>
        /// Represents a method which will handle <see cref="GenericCollection{T}.Inserting" /> and <see cref="GenericCollection{T}.Removing" /> events.
        /// </summary>
        /// <param name="index">Index of item</param>
        /// <param name="value">Item</param>
        public delegate void CollectionChangingHandler(int index, GenericCancelEventArgs<T> value);

        /// <summary>
        /// Represents a method which will handle <see cref="GenericCollection{T}.Cleared" /> event.
        /// </summary>
        public delegate void CollectionClearHandler();

        /// <summary>
        /// Represents a method which will handle <see cref="GenericCollection{T}.Clearing" /> event.
        /// </summary>
        /// <param name="value">The value.</param>
        public delegate void CollectionClearingHandler(GenericCancelEventArgs<GenericCollection<T>> value);

        /// <summary>
        /// Represents a method which will handle <see cref="GenericCollection{T}.Changed" /> event.
        /// </summary>
        /// <param name="index">Index of item.</param>
        /// <param name="oldValue">Old object value</param>
        /// <param name="newValue">New object value.</param>
        public delegate void ItemChangeHandler(int index, T oldValue, T newValue);

        /// <summary>
        /// Represents a method which will handle <see cref="GenericCollection{T}.Changing" />
        /// </summary>
        /// <param name="index">Index of item.</param>
        /// <param name="e">Object containing event data.</param>
        public delegate void ItemChangingHandler(int index, GenericChangeEventArgs<T> e);

        /// <summary>
        /// Represents a method which will handle <see cref="GenericCollection{T}.Validating" /> event.
        /// </summary>
        /// <param name="value">Value of object validating.</param>
        public delegate void ValidateHandle(T value);

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize default instance.
        /// </summary>
        public GenericCollection()
        {
        }

        /// <summary>
        /// Initialize new instance with specified <see cref="Owner" />
        /// </summary>
        /// <param name="owner">The owner.</param>
        public GenericCollection(object owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// Initialize new instance.
        /// </summary>
        /// <param name="info">Serialization info object</param>
        /// <param name="context">Streaming context</param>
        protected GenericCollection(SerializationInfo info, StreamingContext context)
        {
            siInfo = info;
        }

        /// <summary>
        /// Initialize new instance with specified items.
        /// </summary>
        /// <param name="items">Items to be added by default.</param>
        public GenericCollection(IEnumerable<T> items) : this()
        {
            foreach (T barItem in items)
            {
#pragma warning disable DoNotCallOverridableMethodsInConstructor
                OnInsert(InnerList.Count, barItem);
#pragma warning restore DoNotCallOverridableMethodsInConstructor
                InnerList.Add(barItem);
#pragma warning disable DoNotCallOverridableMethodsInConstructor
                OnInsertComplete(InnerList.Count - 1, barItem);
#pragma warning restore DoNotCallOverridableMethodsInConstructor
            }
        }

        /// <summary>
        /// Initialize new instance with specified items.
        /// </summary>
        /// <param name="items">Items to be added by default.</param>
        public GenericCollection(GenericCollection<T> items) : this()
        {
            foreach (T item in items)
            {
                var newItem = (T) (item is ICloneable ? (item as ICloneable).Clone() : item);
#pragma warning disable DoNotCallOverridableMethodsInConstructor
                OnInsert(InnerList.Count, newItem);
#pragma warning restore DoNotCallOverridableMethodsInConstructor
                InnerList.Add(newItem);
#pragma warning disable DoNotCallOverridableMethodsInConstructor
                OnInsertComplete(InnerList.Count - 1, newItem);
#pragma warning restore DoNotCallOverridableMethodsInConstructor
            }
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets object from collection with sepcific index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Returns object at specified index in the collection.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public T this[int index]
        {
            get { return (T) InnerList[index]; }
            set { InnerList[index] = value; }
        }

        /// <summary>
        /// Gets or Sets owner of the collection
        /// </summary>
        /// <value>The owner.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Owner { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when collection is being cleared.
        /// </summary>
        public event CollectionClearHandler Cleared;

        /// <summary>
        /// Occurs when collection is about to clear
        /// </summary>
        public event CollectionClearingHandler Clearing;

        /// <summary>
        /// Occurs when item is inserted to the collection
        /// </summary>
        public event CollectionChangedHandler Inserted;

        /// <summary>
        /// Occurs when an item is about to be inserted.
        /// </summary>
        public event CollectionChangingHandler Inserting;

        /// <summary>
        /// Occurs when item is removed from collection
        /// </summary>
        public event CollectionChangedHandler Removed;

        /// <summary>
        /// Occurs when item is about to be removed.
        /// </summary>
        public event CollectionChangingHandler Removing;

        /// <summary>
        /// Occurs when item is about to change.
        /// </summary>
        public event ItemChangingHandler Changing;

        /// <summary>
        /// Occurs when item is changed.
        /// </summary>
        public event ItemChangeHandler Changed;

        /// <summary>
        /// Occurs when collection requests additional custom processes when validating a value.
        /// </summary>
        public event ValidateHandle Validating;

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds an item to the end of the collection.
        /// </summary>
        /// <param name="item">The item to be added to the end of the Collection. The value can be null.</param>
        /// <returns>The index at which the value has been added.</returns>
        public int Add(T item)
        {
            OnInsert(InnerList.Count, item);
            int index = InnerList.Add(item);
            OnInsertComplete(InnerList.Count, item);
            return index;
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        public void AddRange(T[] items)
        {
            foreach (T item in items)
            {
                OnInsert(InnerList.Count, item);
                InnerList.Add(item);
                OnInsertComplete(InnerList.Count, item);
            }
        }

        /// <summary>
        /// Adds an item(s) to the end of the collection.
        /// </summary>
        /// <param name="items">The item to be added to the end of the Collection. The value can be null.</param>
        public void Add(T[] items)
        {
            foreach (T item in items)
            {
                OnInsert(InnerList.Count, item);
                InnerList.Add(item);
                OnInsertComplete(InnerList.Count, item);
            }
        }

        /// <summary>
        /// Inserts an element into the Collection at the specified index.
        /// </summary>
        /// <param name="index">Index at which item has to be inserted.</param>
        /// <param name="item">Item to be inserted</param>
        public void Insert(int index, T item)
        {
            OnInsert(index, item);
            InnerList.Insert(index, item);
            OnInsertComplete(index, item);
        }

        /// <summary>
        /// Removes item from the collection.
        /// </summary>
        /// <param name="item">Item to be removed.</param>
        public void Remove(T item)
        {
            int index = IndexOf(item);
            OnRemove(index, item);
            InnerList.Remove(item);
            OnRemoveComplete(index, item);
        }

        /// <summary>
        /// Lasts the index of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.Int32.</returns>
        public int LastIndexOf(T item)
        {
            return InnerList.LastIndexOf(item);
        }

        /// <summary>
        /// Lasts the index of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>System.Int32.</returns>
        public int LastIndexOf(T item, int startIndex)
        {
            return InnerList.LastIndexOf(item, startIndex);
        }

        /// <summary>
        /// Lasts the index of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Int32.</returns>
        public int LastIndexOf(T item, int startIndex, int count)
        {
            return InnerList.LastIndexOf(item, startIndex, count);
        }

        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="items">The items.</param>
        public void InsertRange(int index, GenericCollection<T> items)
        {
            InnerList.InsertRange(index, items);
        }

        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.</returns>
        public bool Contains(T item)
        {
            return InnerList.Contains(item);
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public int IndexOf(T value)
        {
            return InnerList.IndexOf(value);
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>System.Int32.</returns>
        public int IndexOf(T value, int startIndex)
        {
            return InnerList.IndexOf(value, startIndex);
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Int32.</returns>
        public int IndexOf(T value, int startIndex, int count)
        {
            return InnerList.IndexOf(value, startIndex, count);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Performs additional custom processes when clearing the contents of the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        protected override void OnClear()
        {
            var e = new GenericCancelEventArgs<GenericCollection<T>>(this);
            if (Clearing != null)
            {
                Clearing(e);
                if (e.Cancel)
                {
                    return;
                }
            }
            base.OnClear();
        }

        /// <summary>
        /// Performs additional custom processes after clearing the contents of the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        protected override void OnClearComplete()
        {
            base.OnClearComplete();
            if (Cleared != null)
            {
                Cleared();
            }
        }

        /// <summary>
        /// Performs additional custom processes before inserting a new element into the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        /// <param name="index">The zero-based index at which to insert value.</param>
        /// <param name="value">The new value of the element at index.</param>
        protected override void OnInsert(int index, object value)
        {
            var e = new GenericCancelEventArgs<T>((T) value);
            if (Inserting != null)
            {
                Inserting(index, e);
                if (e.Cancel)
                {
                    return;
                }
            }
            base.OnInsert(index, value);
        }

        /// <summary>
        /// Performs additional custom processes after inserting a new element into the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        /// <param name="index">The zero-based index at which to insert value.</param>
        /// <param name="value">The new value of the element at index.</param>
        protected override void OnInsertComplete(int index, object value)
        {
            base.OnInsertComplete(index, value);
            if (Inserted != null)
            {
                Inserted(index, (T) value);
            }
        }

        /// <summary>
        /// Performs additional custom processes when removing an element from the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        /// <param name="index">The zero-based index at which value can be found.</param>
        /// <param name="value">The value of the element to remove from index.</param>
        protected override void OnRemove(int index, object value)
        {
            var e = new GenericCancelEventArgs<T>((T) value);
            if (Removing != null)
            {
                Removing(index, e);
                if (e.Cancel)
                {
                    return;
                }
            }
            base.OnRemove(index, value);
        }

        /// <summary>
        /// Performs additional custom processes after removing an element from the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        /// <param name="index">The zero-based index at which value can be found.</param>
        /// <param name="value">The value of the element to remove from index.</param>
        protected override void OnRemoveComplete(int index, object value)
        {
            base.OnRemoveComplete(index, value);
            if (Removed != null)
            {
                Removed(index, (T) value);
            }
        }

        /// <summary>
        /// Performs additional custom processes when validating a value.
        /// </summary>
        /// <param name="value">The object to validate.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected override void OnValidate(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            if (Validating != null)
            {
                Validating((T) value);
            }
            base.OnValidate(value);
        }

        /// <summary>
        /// Performs additional custom processes before setting a value in the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        /// <param name="index">The zero-based index at which oldValue can be found.</param>
        /// <param name="oldValue">The value to replace with newValue.</param>
        /// <param name="newValue">The new value of the element at index.</param>
        protected override void OnSet(int index, object oldValue, object newValue)
        {
            var e = new GenericChangeEventArgs<T>((T) oldValue, (T) newValue);
            if (Changing != null)
            {
                Changing(index, e);
                if (e.Cancel)
                {
                    return;
                }
            }
            base.OnSet(index, oldValue, newValue);
        }

        /// <summary>
        /// Performs additional custom processes after setting a value in the <see cref="T:System.Collections.CollectionBase"></see> instance.
        /// </summary>
        /// <param name="index">The zero-based index at which oldValue can be found.</param>
        /// <param name="oldValue">The value to replace with newValue.</param>
        /// <param name="newValue">The new value of the element at index.</param>
        protected override void OnSetComplete(int index, object oldValue, object newValue)
        {
            base.OnSetComplete(index, oldValue, newValue);
            if (Changed != null)
            {
                Changed(index, (T) oldValue, (T) newValue);
            }
        }

        #endregion

        /// <summary>
        /// The si information
        /// </summary>
        private SerializationInfo siInfo;

        #region IDeserializationCallback Members

        /// <summary>
        /// Runs when the entire object graph has been deserialized.
        /// </summary>
        /// <param name="sender">The object that initiated the callback. The functionality for this parameter is not currently implemented.</param>
        public void OnDeserialization(object sender)
        {
            if (siInfo != null)
            {
                Clear();
                if (siInfo.GetInt32("Count") != 0)
                {
                    Clear();
                    int num = siInfo.GetInt32("Count");
                    for (int i = 0; i < num; i++)
                    {
                        Add((T) siInfo.GetValue("Items" + i, typeof (T)));
                    }
                }
                siInfo = null;
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Owner = null;
            List.Clear();
            InnerList.Clear();
            siInfo = null;
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
        /// <exception cref="ArgumentNullException">info</exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("Count", Count);
            if (Count != 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    info.AddValue("Items" + i, this[i]);
                }
            }
        }

        #endregion

        /// <summary>
        /// Sets index of the item to given index.
        /// </summary>
        /// <param name="item">Item whose index is to be set.</param>
        /// <param name="index">New index of item.</param>
        public void SetChildIndex(T item, int index)
        {
            if (List.Count > 0)
            {
                int num = IndexOf(item);
                if (index < 0)
                {
                    index = 0;
                }
                if (index >= List.Count)
                {
                    index = List.Count - 1;
                }
                if ((index >= 0) && (index < List.Count))
                {
                    if (num < index)
                    {
                        for (int i = num; i < index; i++)
                        {
                            List[i] = List[i + 1];
                        }
                        List[index] = item;
                    }
                    else if (num > index)
                    {
                        for (int j = num; j > index; j--)
                        {
                            List[j] = List[j - 1];
                        }
                        List[index] = item;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts list using specified <see cref="IComparer" />
        /// </summary>
        /// <param name="comparer"><see cref="IComparer" /> used to sort items.</param>
        public void Sort(IComparer comparer)
        {
            if ((List.Count > 0) && (comparer != null))
            {
                var array = new object[List.Count];
                for (int i = 0; i < List.Count; i++)
                {
                    array[i] = List[i];
                }
                Array.Sort(array, comparer);
                List.Clear();
                for (int j = 0; j < array.Length; j++)
                {
                    List.Add(array[j]);
                }
            }
        }
    }
}