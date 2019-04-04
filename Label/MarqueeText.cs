// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="MarqueeText.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace Zeroit.Framework.MiscControls
{
    #region MarqueText  !!!!!!!!!!!Freezes

    #region Attributes

    #region ImagePropertyAttribute
    /// <summary>
    /// Indicates Image property for indexing. e.g. If parent contains image list use "Parent.ImageList".
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal sealed class MarqueeTextImagePropertyAttribute : Attribute
    {
        private readonly string propertyName;

        /// <summary>
        /// Crate instance of the <see cref="MarqueeTextImagePropertyAttribute"/>
        /// </summary>
        /// <param name="relatedImageList"></param>
        public MarqueeTextImagePropertyAttribute(string relatedImageList)
        {
            propertyName = relatedImageList;
        }

        /// <summary>
        /// Gets the name of the property which is to be used for imagelist.
        /// </summary>
        public string PropertyName
        {
            get { return propertyName; }
        }
    }

    #endregion

    #region MinMaxAttribute
    /// <summary>
    /// Minmimum maximum value attribute.
    /// </summary>
    internal sealed class MarqueeMinMaxAttribute : Attribute
    {
        public static readonly MarqueeMinMaxAttribute Default = new MarqueeMinMaxAttribute(0, 999);
        private readonly int minValue;
        private readonly int maxValue;

        /// <summary>
        /// Create instance of <see cref="MarqueeMinMaxAttribute"/>.
        /// </summary>
        /// <param name="minValue">Minimum value</param>
        /// <param name="maxValue">Maximum value</param>
        public MarqueeMinMaxAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        /// <summary>
        /// Gets minimum value.
        /// </summary>
        public int MinValue
        {
            get { return minValue; }
        }
        /// <summary>
        /// Gets maximum value.
        /// </summary>
        public int MaxValue
        {
            get { return maxValue; }
        }

        ///<summary>
        ///Returns a value that indicates whether this instance is equal to a specified object.
        ///</summary>
        ///
        ///<returns>
        ///true if obj equals the type and value of this instance; otherwise, false.
        ///</returns>
        ///
        ///<param name="obj">An <see cref="T:System.Object"></see> to compare with this instance or null. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            MarqueeMinMaxAttribute attribute = obj as MarqueeMinMaxAttribute;
            if (attribute != null)
            {
                return attribute.minValue.Equals(minValue) && attribute.maxValue.Equals(maxValue);
            }
            return false;
        }

        ///<summary>
        ///Returns the hash code for this instance.
        ///</summary>
        ///
        ///<returns>
        ///A 32-bit signed integer hash code.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        ///<summary>
        ///When overridden in a derived class, indicates whether the value of this instance is the default value for the derived class.
        ///</summary>
        ///
        ///<returns>
        ///true if this instance is the default attribute for the class; otherwise, false.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override bool IsDefaultAttribute()
        {
            return Default.Equals(this);
        }

        ///<summary>
        ///Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override string ToString()
        {
            return "Minimum allowed value : " + minValue + " , Maximum allowed value : " + maxValue;
        }
    }

    #endregion

    #endregion

    #region Collection

    #region GenericCollection
    /// <summary>
    /// Collection which supports events.
    /// </summary>
    /// <typeparam name="T">Collection element type.</typeparam>
    public class MarqueeGenericCollection<T> : CollectionBase, IDeserializationCallback, IDisposable, ISerializable
    {
        #region Delegates

        /// <summary>
        /// Delegate Collection changed.
        /// </summary>
        /// <param name="index">Index of collecten being modified.</param>
        /// <param name="value">Modified value.</param>
        public delegate void CollectionChangedHandler(int index, T value);

        /// <summary>
        /// Delegate Collection changing.
        /// </summary>
        /// <param name="index">Index of collecten being modified.</param>
        /// <param name="value">Modified value.</param>
        public delegate void CollectionChangingHandler(int index, MarqueeGenericCancelEventArgs<T> value);

        /// <summary>
        /// Delegate for collection cleared.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        public delegate void CollectionClearHandler();

        /// <summary>
        /// Delegate for collection clearing.
        /// </summary>
        /// <param name="value">Cancel event args which contains collection data.</param>
        public delegate void CollectionClearingHandler(MarqueeGenericCancelEventArgs<MarqueeGenericCollection<T>> value);

        /// <summary>
        /// Delegate for index being changed.
        /// </summary>
        /// <param name="index">Index being changed.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        public delegate void ItemChangeHandler(int index, T oldValue, T newValue);

        /// <summary>
        /// Delegate for Item changing.
        /// </summary>
        /// <param name="index">Index of item which is changing.</param>
        /// <param name="e">Change event argument.</param>
        public delegate void ItemChangingHandler(int index, MarqueeGenericChangeEventArgs<T> e);

        /// <summary>
        /// Delegate for Item being validated.
        /// </summary>
        /// <param name="value">Item being validated.</param>
        public delegate void ValidateHandler(T value);

        #endregion

        #region Constructor

        /// <summary>
        /// Create new instance of the collection.
        /// </summary>
        public MarqueeGenericCollection()
        {
        }

        /// <summary>
        /// Create new instance of the collection.
        /// </summary>
        /// <param name="owner">Owner of the collection.</param>
        public MarqueeGenericCollection(object owner)
        {
            this.owner = owner;
        }

        /// <summary>
        /// Create new instance of the collection.
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected MarqueeGenericCollection(SerializationInfo info, StreamingContext context)
        {
            siInfo = info;
        }

        /// <summary>
        /// Create new instance of the collection.
        /// </summary>
        /// <param name="items">Items to be inserted by default.</param>
        public MarqueeGenericCollection(IEnumerable<T> items)
            : this()
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
        /// Create new instance of the collection.
        /// </summary>
        /// <param name="items">Items to be inserted by default.</param>
        public MarqueeGenericCollection(MarqueeGenericCollection<T> items)
            : this()
        {
            foreach (T item in items)
            {
                T newItem = (T)(item is ICloneable ? (item as ICloneable).Clone() : item);
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
        /// Gets or sets the item at the specified index.
        /// </summary>
        /// <param name="index">Index of item to be retrieved.</param>
        /// <returns></returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public T this[int index]
        {
            get { return (T)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        /// <summary>
        /// Gets or sets the Owner of the collection.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        #endregion

        #region Events

        /// <summary>
        /// Collection is cleared.
        /// </summary>
        [Category("Collection")]
        [Description("Collection is cleared.")]
        public event CollectionClearHandler Cleared;

        /// <summary>
        /// Collection is clearing.
        /// </summary>
        [Category("Collection")]
        [Description("Collection is clearing.")]
        public event CollectionClearingHandler Clearing;

        /// <summary>
        /// Item is inserted in the collection.
        /// </summary>
        [Category("Collection")]
        [Description("Item is inserted in the collection.")]
        public event CollectionChangedHandler Inserted;

        /// <summary>
        /// Item is inserting in the collection.
        /// </summary>
        [Category("Collection")]
        [Description("Item is inserting in the collection.")]
        public event CollectionChangingHandler Inserting;

        /// <summary>
        /// Item is removed from the collection.
        /// </summary>
        [Category("Collection")]
        [Description("Item is removed from the collection.")]
        public event CollectionChangedHandler Removed;

        /// <summary>
        /// Item is removing from the collection.
        /// </summary>
        [Category("Collection")]
        [Description("Item is removing from the collection.")]
        public event CollectionChangingHandler Removing;

        /// <summary>
        /// Item value is changing in the collection.
        /// </summary>
        [Category("Collection")]
        [Description("Item value is changing in the collection.")]
        public event ItemChangingHandler Changing;

        /// <summary>
        /// Item value is changed in the collection.
        /// </summary>
        [Category("Collection")]
        [Description("Item value is changed in the collection.")]
        public event ItemChangeHandler Changed;

        /// <summary>
        /// Item is being validated.
        /// </summary>
        [Category("Collection")]
        [Description("Item is being validated.")]
        public event ValidateHandler Validating;

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
        /// Adds the array of elements.
        /// </summary>
        /// <param name="items"></param>
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
        /// <param name="items">The item to be added to the end of the Collection. The value can be null. </param>
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
        /// Gets the last index of item.
        /// </summary>
        /// <param name="item">Item to be searched.</param>
        /// <returns>Gets the last index of the element.</returns>
        public int LastIndexOf(T item)
        {
            return InnerList.LastIndexOf(item);
        }

        /// <summary>
        /// Gets the last index of the supplied item from the starting index.
        /// </summary>
        /// <param name="item">Item to be searched.</param>
        /// <param name="startIndex">Start index from which searching will be done.</param>
        /// <returns>Gets the last index of the element.</returns>
        public int LastIndexOf(T item, int startIndex)
        {
            return InnerList.LastIndexOf(item, startIndex);
        }

        /// <summary>
        /// Gets the last index of the supplied item from the starting index. 
        /// </summary>
        /// <param name="item">The System.Object to locate in the System.Collections.ArrayList. The value can be null.</param>
        /// <param name="startIndex">The zero-based starting index of the backward search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The zero-based index of the last occurrence of value within the range of elements in the System.Collections.ArrayList that contains count number of elements and ends at startIndex, if found; otherwise, -1.</returns>
        public int LastIndexOf(T item, int startIndex, int count)
        {
            return InnerList.LastIndexOf(item, startIndex, count);
        }

        /// <summary>
        /// Inserts the elements to the specified index.
        /// </summary>
        /// <param name="index">Index at which insertion will be take palce.</param>
        /// <param name="items">Items to be inserted.</param>
        public void InsertRange(int index, MarqueeGenericCollection<T> items)
        {
            InnerList.InsertRange(index, items);
        }

        /// <summary>
        /// Finds collection contains the supplied element.
        /// </summary>
        /// <param name="item">Item to be searched.</param>
        /// <returns>return true if found, else false.</returns>
        public bool Contains(T item)
        {
            return InnerList.Contains(item);
        }

        /// <summary>
        /// Gets the index of the supplied item.
        /// </summary>
        /// <param name="value">Item to be searched.</param>
        /// <returns>returns index of the iotem. Returns -1 if not found in the collection.</returns>
        public int IndexOf(T value)
        {
            return InnerList.IndexOf(value);
        }

        /// <summary>
        /// Gets the index of the supplied item.
        /// </summary>
        /// <param name="value">Item to be searched.</param>
        /// <param name="startIndex">Index from which searching will start.</param>
        /// <returns>returns index of the iotem. Returns -1 if not found in the collection.</returns>
        public int IndexOf(T value, int startIndex)
        {
            return InnerList.IndexOf(value, startIndex);
        }

        /// <summary>
        /// Gets the index of the supplied item.
        /// </summary>
        /// <param name="value">Item to be searched.</param>
        /// <param name="startIndex">Index from which searching will start.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>returns index of the iotem. Returns -1 if not found in the collection.</returns>
        public int IndexOf(T value, int startIndex, int count)
        {
            return InnerList.IndexOf(value, startIndex, count);
        }

        #endregion

        #region Overrides

        ///<summary>
        ///Performs additional custom processes when clearing the contents of the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        protected override void OnClear()
        {
            MarqueeGenericCancelEventArgs<MarqueeGenericCollection<T>> e = new MarqueeGenericCancelEventArgs<MarqueeGenericCollection<T>>(this);
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

        ///<summary>
        ///Performs additional custom processes after clearing the contents of the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        protected override void OnClearComplete()
        {
            base.OnClearComplete();
            if (Cleared != null)
            {
                Cleared();
            }
        }

        ///<summary>
        ///Performs additional custom processes before inserting a new element into the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        ///<param name="value">The new value of the element at index.</param>
        ///<param name="index">The zero-based index at which to insert value.</param>
        protected override void OnInsert(int index, object value)
        {
            MarqueeGenericCancelEventArgs<T> e = new MarqueeGenericCancelEventArgs<T>((T)value);
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

        ///<summary>
        ///Performs additional custom processes after inserting a new element into the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        ///<param name="value">The new value of the element at index.</param>
        ///<param name="index">The zero-based index at which to insert value.</param>
        protected override void OnInsertComplete(int index, object value)
        {
            base.OnInsertComplete(index, value);
            if (Inserted != null)
            {
                Inserted(index, (T)value);
            }
        }

        ///<summary>
        ///Performs additional custom processes when removing an element from the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        ///<param name="value">The value of the element to remove from index.</param>
        ///<param name="index">The zero-based index at which value can be found.</param>
        protected override void OnRemove(int index, object value)
        {
            MarqueeGenericCancelEventArgs<T> e = new MarqueeGenericCancelEventArgs<T>((T)value);
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

        ///<summary>
        ///Performs additional custom processes after removing an element from the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        ///<param name="value">The value of the element to remove from index.</param>
        ///<param name="index">The zero-based index at which value can be found.</param>
        protected override void OnRemoveComplete(int index, object value)
        {
            base.OnRemoveComplete(index, value);
            if (Removed != null)
            {
                Removed(index, (T)value);
            }
        }

        ///<summary>
        ///Performs additional custom processes when validating a value.
        ///</summary>
        ///
        ///<param name="value">The object to validate.</param>
        protected override void OnValidate(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            if (Validating != null)
            {
                Validating((T)value);
            }
            base.OnValidate(value);
        }

        ///<summary>
        ///Performs additional custom processes before setting a value in the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        ///<param name="oldValue">The value to replace with newValue.</param>
        ///<param name="newValue">The new value of the element at index.</param>
        ///<param name="index">The zero-based index at which oldValue can be found.</param>
        protected override void OnSet(int index, object oldValue, object newValue)
        {
            MarqueeGenericChangeEventArgs<T> e = new MarqueeGenericChangeEventArgs<T>((T)oldValue, (T)newValue);
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

        ///<summary>
        ///Performs additional custom processes after setting a value in the <see cref="T:System.Collections.CollectionBase"></see> instance.
        ///</summary>
        ///
        ///<param name="oldValue">The value to replace with newValue.</param>
        ///<param name="newValue">The new value of the element at index.</param>
        ///<param name="index">The zero-based index at which oldValue can be found.</param>
        protected override void OnSetComplete(int index, object oldValue, object newValue)
        {
            base.OnSetComplete(index, oldValue, newValue);
            if (Changed != null)
            {
                Changed(index, (T)oldValue, (T)newValue);
            }
        }

        #endregion

        private object owner;

        private SerializationInfo siInfo;

        #region IDeserializationCallback Members

        ///<summary>
        ///Runs when the entire object graph has been deserialized.
        ///</summary>
        ///
        ///<param name="sender">The object that initiated the callback. The functionality for this parameter is not currently implemented. </param>
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
                        Add((T)siInfo.GetValue("Items" + i, typeof(T)));
                    }
                }
                siInfo = null;
            }
        }

        #endregion

        #region IDisposable Members

        ///<summary>
        ///Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        ///</summary>
        ///<filterpriority>2</filterpriority>
        public void Dispose()
        {
            owner = null;
            List.Clear();
            InnerList.Clear();
            siInfo = null;
        }

        #endregion

        #region ISerializable Members

        ///<summary>
        ///Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> with the data needed to serialize the target object.
        ///</summary>
        ///
        ///<param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"></see>) for this serialization. </param>
        ///<param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> to populate with data. </param>
        ///<exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
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
        /// Sets the index of the child to the specified index.
        /// </summary>
        /// <param name="item">Child of which index is to be set.</param>
        /// <param name="index">New index of the child.</param>
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
        /// Sortes the collection with specified <see cref="IComparer"/>
        /// </summary>
        /// <param name="comparer"><see cref="IComparer"/> for sorting.</param>
        public void Sort(IComparer comparer)
        {
            if ((List.Count > 0) && (comparer != null))
            {
                object[] array = new object[List.Count];
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

    #endregion

    #endregion

    #region Controls

    #region ZeroitSuperMarquee

    #region Designer Generated Code

    partial class ZeroitSuperMarquee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Dispose();
            }
            tmrRefresh.Dispose();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 20;
            this.tmrRefresh.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // ttMain
            // 
            this.ttMain.AutomaticDelay = 100;
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ToolTip ttMain;
    }


    #endregion

    #region ZeroitSuperMarquee.Serialize

    partial class ZeroitSuperMarquee
    {
        #region Should serialize implementation

        private bool ShouldSerializeHoverStop()
        {
            return !HoverStop;
        }

        private bool ShouldSerializeAutoRewind()
        {
            return !AutoRewind;
        }

        private bool ShouldSerializeRunning()
        {
            return !Running; ;
        }

        private bool ShouldSerializeImageList()
        {
            return ImageList != null;
        }

        private bool ShouldSerializeStripColor()
        {
            return StripColor != Color.Transparent;
        }

        private bool ShouldSerializeShowStrip()
        {
            return ShowStrip;
        }

        private bool ShouldSerializeMarqueeSpeed()
        {
            return MarqueeSpeed != 900;
        }
        private bool ShouldSerializeAutoToolTip()
        {
            return !AutoToolTip;
        }
        #endregion

        #region Reset implementation

        /// <summary>
        /// Reset the <see cref="ZeroitSuperMarquee"/>
        /// </summary>
        public void Reset()
        {
            ResetHoverStop();
            ResetAutoRewind();
            ResetRunning();
            ResetImageList();
            ResetStripColor();
            ResetShowStrip();
            ResetMarqueeSpeed();
        }

        private void ResetHoverStop()
        {
            HoverStop = true;
        }

        private void ResetAutoRewind()
        {
            AutoRewind = true;
        }

        private void ResetRunning()
        {
            Running = true; ;
        }

        private void ResetImageList()
        {
            ImageList = null;
        }

        private void ResetStripColor()
        {
            StripColor = Color.Transparent;
        }

        private void ResetShowStrip()
        {
            ShowStrip = false;
        }

        private void ResetMarqueeSpeed()
        {
            MarqueeSpeed = 900;
        }
        private void ResetAutoToolTip()
        {
            AutoToolTip = true;
        }
        #endregion
    }

    #endregion

    #region ZeroitSuperMarquee

    /// <summary>
    /// A class collection for rendering a marquee text.
    /// </summary>
    [Designer(typeof(SuperMarqueDesigner))]
    [DefaultEvent("ItemClicked")]
    [DefaultProperty("Elements")]
    public partial class ZeroitSuperMarquee : Control
    {

        #region Events

        /// <summary>
        /// Item is clicked.
        /// </summary>
        [Category("Text element events")]
        [Description("Item is clicked.")]
        public event EventHandler<ItemClickEventArgs> ItemClicked;
        /// <summary>
        /// Item was double clicked.
        /// </summary>
        [Category("Text element events")]
        [Description("Item was double clicked.")]
        public event EventHandler<ItemClickEventArgs> ItemDoubleClicked;
        /// <summary>
        /// Lap was completed.
        /// </summary>
        [Category("Lap events")]
        [Description("Lap was completed.")]
        public event EventHandler LapCompleted;
        /// <summary>
        /// Lap was completed.
        /// </summary>
        [Category("ToolTip events")]
        [Description("Before ToolTip show.")]
        public event MarqueeGenericCancelEventHandler<ToolTipData> BeforeToolTip;

        #endregion

        #region Private Fields

        private readonly MarqueeGenericCollection<TextElement> elements = new MarqueeGenericCollection<TextElement>();
        private bool autoRewind;
        private Rectangle bound;
        private int firstElementWidth;
        private int firstIndex;
        private bool hover;
        private bool hoverStop;
        private ImageList imageList;
        private int maxHeight = 0;
        private int offset = int.MinValue;
        private System.Windows.Forms.Timer tmrRefresh;
        private Color stripColor;
        private bool showStrip;
        private int tmpOffset;
        private bool lapComplete;
        private bool showing;
        private bool autoToolTip = true;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSuperMarquee"/> class.
        /// </summary>
        public ZeroitSuperMarquee()
        {
            InitializeComponent();
            MarqueeSpeed = 900;
            autoRewind = true;
            hoverStop = true;
            stripColor = Color.Transparent;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            elements.Removed += OnRemoved;
            elements.Inserted += OnInserted;
        }

        #endregion

        #region Overrides

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        ///</summary>
        ///
        ///<param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (firstIndex >= 0 && firstIndex < elements.Count)
            {
                using (Graphics g = e.Graphics)
                {
                    if (showStrip)
                    {
                        g.FillRectangle(new SolidBrush(stripColor), bound);
                    }
                    Point start = new Point(bound.X, Height / 2);
                    firstElementWidth = (int)elements[firstIndex].GetSize().Width;
                    int i = firstIndex;
                    if (firstIndex == 0 && autoRewind && lapComplete)
                    {
                        Point buffStart = new Point(bound.X, Height / 2);
                        elements[Elements.Count - 1].DrawElement(g, ref buffStart, tmpOffset);
                    }
                    for (; i < elements.Count; i++)
                    {
                        elements[i].DrawElement(g, ref start, offset);
                        if (start.X - offset > Width)
                        {
                            break;
                        }
                    }
                }
            }
        }

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hover = true;
        }

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hover = false;
            if (showing && autoToolTip)
            {
                ttMain.Hide(this);
                showing = false;
            }
        }

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            bound = new Rectangle(0, (Height / 2) - ((maxHeight + 4) / 2), Width, maxHeight + 4);
            if (Width != 0 && offset == int.MinValue)
            {
                offset = -Width;
            }
        }

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.MouseClick"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data. </param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            MarqueeHitTestInfo test = HitTest(e.Location);
            if (test != null && test.Area != HitTestArea.None)
            {
                if (test.Area == HitTestArea.Item && this[test.Index].IsLink)
                {
                    OnItemClicked(test.Index);
                }
            }
        }

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.DoubleClick"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            MarqueeHitTestInfo test = HitTest(PointToClient(MousePosition));
            if (test != null && test.Area != HitTestArea.None)
            {
                if (test.Area == HitTestArea.Item && this[test.Index].IsLink)
                {
                    OnItemDoubleClicked(test.Index);
                }
            }
        }

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"></see> event.
        ///</summary>
        ///
        ///<param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data. </param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            MarqueeHitTestInfo test = HitTest(e.Location);
            if (test != null && test.Area != HitTestArea.None)
            {
                if (test.Area == HitTestArea.Item && !showing && autoToolTip)
                {
                    showing = true;
                    Point loc = new Point(this[test.Index].TextRect.X, this[test.Index].TextRect.Y + this[test.Index].Font.Height);
                    ToolTipData data = new ToolTipData(this[test.Index].ToolTipText, test.Index, loc);
                    MarqueeGenericCancelEventArgs<ToolTipData> args = new MarqueeGenericCancelEventArgs<ToolTipData>(data, false);
                    OnBeforeToolTip(args);
                    if (!args.Cancel)
                    {
                        ttMain.Show(args.Value.ToolTipText, this, data.Location);
                    }
                }

                if (test.Area == HitTestArea.Item && this[test.Index].IsLink)
                {
                    Cursor = CursorHelper.NormalCursor;
                }
                else
                {
                    Cursor = Cursors.Default;
                    if (showing && autoToolTip)
                    {
                        ttMain.Hide(this);
                        showing = false;
                    }
                }
            }
        }

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"></see> event.
        ///</summary>
        ///
        ///<param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data. </param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MarqueeHitTestInfo test = HitTest(e.Location);
            if (test != null && test.Area != HitTestArea.None)
            {
                if (test.Area == HitTestArea.Item && this[test.Index].IsLink)
                {
                    Cursor = CursorHelper.PressedCursor;
                }
                else
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Handler for timer Tick.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Agruments attached with the event.</param>
        private void OnTimerTick(object sender, EventArgs e)
        {
            if (hoverStop && hover)
            {
                return;
            }
            if (firstIndex >= elements.Count)
            {
                return;
            }
            int buffer = elements[firstIndex].LeftRect.Width + elements[firstIndex].RightRect.Width + 8;



            if (firstElementWidth >= offset - buffer)
            {
                offset++;
                tmpOffset++;
            }
            else
            {
                if (elements.Count > firstIndex && firstIndex >= 0 && firstIndex < elements.Count - 1)
                {
                    int shift;
                    firstIndex++;
                    if (elements[firstIndex].LeftImageIndex != -1 && elements[firstIndex].LeftImageIndex < imageList.Images.Count && elements[firstIndex - 1].RightImageIndex != -1 && elements[firstIndex - 1].RightImageIndex < imageList.Images.Count)
                    {
                        shift = -elements[firstIndex - 1].LeftRect.Width + elements[firstIndex].RightRect.Width + 2;
                    }
                    else if ((elements[firstIndex - 1].RightImageIndex != -1 && elements[firstIndex - 1].RightImageIndex < imageList.Images.Count) && (elements[firstIndex].LeftImageIndex == -1 || elements[firstIndex].LeftImageIndex > imageList.Images.Count))
                    {
                        shift = 3;
                    }
                    else if ((elements[firstIndex - 1].RightImageIndex != -1 || elements[firstIndex - 1].RightImageIndex > imageList.Images.Count))
                    {
                        shift = 3;
                    }
                    else
                    {
                        shift = 9;
                    }
                    offset = shift;
                }
                if (elements.Count > 0 && firstIndex == 0)
                {
                    if (elements[elements.Count - 1].LeftImageIndex != -1 && elements[elements.Count - 1].LeftImageIndex < imageList.Images.Count)
                    {
                        tmpOffset = 2;
                    }
                    else
                    {
                        tmpOffset = 9;
                    }
                }
            }
            if (autoRewind && firstIndex >= elements.Count - 1)
            {
                firstIndex = 0;
                offset = -Width;
                lapComplete = true;

                if (lapComplete)
                {
                    if (elements[elements.Count - 1].LeftImageIndex != -1 && elements[elements.Count - 1].LeftImageIndex < imageList.Images.Count)
                    {
                        tmpOffset = 2;
                    }
                    else
                    {
                        tmpOffset = 9;
                    }
                }
            }

            if (firstIndex == 0 && autoRewind && lapComplete)
            {
                if (tmpOffset == elements[Elements.Count - 1].TextRect.Width)
                {
                    OnLapCompleted();
                }
            }
            Invalidate();
        }

        /// <summary>
        /// Handler for <see cref="TextElement"/> removed from the collection.
        /// </summary>
        /// <param name="index">Index of the <see cref="TextElement"/></param>
        /// <param name="value">Value of the <see cref="TextElement"/> </param>
        private void OnRemoved(int index, TextElement value)
        {
            maxHeight = GetMaxHeight();
        }

        /// <summary>
        /// Handler for <see cref="TextElement"/> being inserted in the collection.
        /// </summary>
        /// <param name="index">Index of the <see cref="TextElement"/></param>
        /// <param name="value">Value of the <see cref="TextElement"/> </param>
        private void OnInserted(int index, TextElement value)
        {
            if (string.IsNullOrEmpty(value.Text))
            {
                value.Text = GetDefaultText();
            }
            value.SetParent(this);
            if (DesignMode)
            {
                Container.Add(value);
            }
            maxHeight = GetMaxHeight();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Start the marquee.
        /// </summary>
        public void StartMarquee()
        {
            tmrRefresh.Start();
        }

        /// <summary>
        /// Stop the marquee.
        /// </summary>
        public void StopMarquee()
        {
            tmrRefresh.Stop();
        }

        /// <summary>
        /// Reset the marquee.
        /// </summary>
        public void ResetMorquee()
        {
            offset = -Width;
            firstIndex = 0;
        }

        /// <summary>
        /// Performs the HitTest.
        /// </summary>
        /// <param name="p">Point at which HitTest will be performed.</param>
        /// <returns>returm <see cref="MarqueeHitTestInfo"/> object containing HitTest information.</returns>
        public MarqueeHitTestInfo HitTest(Point p)
        {
            MarqueeHitTestInfo info = new MarqueeHitTestInfo();
            info.Area = HitTestArea.None;
            info.Point = p;
            info.Index = -1;
            for (int i = firstIndex; i < elements.Count; i++)
            {
                if (elements[i].TextRect.Contains(p))
                {
                    info.Area = HitTestArea.Item;
                    info.Index = i;
                    break;
                }
                else if (elements[i].LeftRect.Contains(p))
                {
                    info.Area = HitTestArea.LeftImage;
                    info.Index = i;
                    break;
                }
                else if (elements[i].RightRect.Contains(p))
                {
                    info.Area = HitTestArea.RightImage;
                    info.Index = i;
                    break;
                }
            }
            if (info.Area == HitTestArea.None)
            {
                if (bound.Contains(p))
                {
                    info.Area = HitTestArea.Strip;
                }
                else if (ClientRectangle.Contains(p))
                {
                    info.Area = HitTestArea.Control;
                }
            }
            return info;
        }

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets that marquee will be running or not if mouse hover is there.
        /// </summary>
        [Category("Behavior")]
        public bool HoverStop
        {
            get { return hoverStop; }
            set
            {
                if (hoverStop != value)
                {
                    hoverStop = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets on completion of one round of marquee it will start again or not.
        /// </summary>
        /// <value>ZeroitSuperMarquee will be auto rewined or not.</value>
        [Category("Behavior")]
        public bool AutoRewind
        {
            get { return autoRewind; }
            set
            {
                if (autoRewind != value)
                {
                    autoRewind = value;
                }
            }
        }

        /// <summary>
        /// Gets list of the <see cref="TextElement"/> associated with the control.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Collection")]
        public MarqueeGenericCollection<TextElement> Elements
        {
            get { return elements; }
        }

        /// <summary>
        /// Gets the <see cref="TextElement"/> at the specified index.
        /// </summary>
        /// <param name="index">Index of the <see cref="TextElement"/> to be obtained.</param>
        /// <returns><see cref="TextElement"/> at the specified index.</returns>
        [Category("Collection")]
        public TextElement this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("Index specified should be less than the size of collection.");
                }
                if (index > elements.Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return elements[index];
            }
        }

        /// <summary>
        /// Gets or sets whether marquee is running or not.
        /// </summary>
        /// <value>ZeroitSuperMarquee is running or not.</value>
        [Category("Behavior")]
        public bool Running
        {
            get { return tmrRefresh.Enabled; }
            set { tmrRefresh.Enabled = value; }
        }

        /// <summary>
        /// Gets or sets whether tool tip will be shown autometically..
        /// </summary>
        /// <value>ToolTip will be shown or not.</value>
        [Category("Behavior")]
        public bool AutoToolTip
        {
            get { return autoToolTip; }
            set { autoToolTip = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Windows.Forms.ImageList"/> associated with the component.
        /// </summary>
        /// <value>ImageList associated with the component.</value>
        [Category("Appearance")]
        public ImageList ImageList
        {
            get { return imageList; }
            set { if (imageList != value) { imageList = value; } }
        }

        /// <summary>
        /// Gets or sets the Color of the stripe. Enable <see cref="ShowStrip"/> for displaying the strip.
        /// </summary>or of the ZeroitSuperMarquee strip.
        /// <value>Col.</value>
        [Category("Appearance")]
        public Color StripColor
        {
            get { return stripColor; }
            set { if (stripColor != value) { stripColor = value; } }
        }

        /// <summary>
        /// Gets or sets that strip will be shown or not.
        /// </summary>
        [Category("Appearance")]
        public bool ShowStrip
        {
            get { return showStrip; }
            set
            {
                if (showStrip != value)
                {
                    showStrip = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Speed of the marquee. Maximum speed is 999 and minimum speed is 1.
        /// </summary>
        [Editor(typeof(MarqueeRangeEditor), typeof(UITypeEditor))]
        [MinMax(1, 999)]
        [Category("Behavior")]
        public int MarqueeSpeed
        {
            get { return 1000 - tmrRefresh.Interval; }
            set
            {
                if ((1000 - tmrRefresh.Interval) != value)
                {
                    if (1000 - value < 1)
                    {
                        value = 999;
                    }
                    if (1000 - value > 999)
                    {
                        value = 1;
                    }
                    tmrRefresh.Interval = 1000 - value;

                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the control can respond to user interaction.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new bool Enabled
        {
            get { return base.Enabled; }
            set { base.Enabled = value; }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }



        #endregion

        #region Virtual Methods

        /// <summary>
        /// Fires <see cref="ItemDoubleClicked"/> event.
        /// </summary>
        /// <param name="index">Index of the <see cref="TextElement"/></param>
        protected virtual void OnItemDoubleClicked(int index)
        {
            if (ItemDoubleClicked != null)
            {
                ItemDoubleClicked(this, new ItemClickEventArgs(index));
            }
        }

        /// <summary>
        /// Fires <see cref="ItemClicked"/> event.
        /// </summary>
        /// <param name="index">Index of the <see cref="TextElement"/></param>
        protected virtual void OnItemClicked(int index)
        {
            if (ItemClicked != null)
            {
                ItemClicked(this, new ItemClickEventArgs(index));
            }
        }

        /// <summary>
        /// Fires <see cref="LapCompleted"/> event.
        /// </summary>
        protected virtual void OnLapCompleted()
        {
            if (LapCompleted != null)
            {
                LapCompleted(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires event BeforeToolTip.
        /// </summary>
        /// <param name="args">Event data of <see cref="BeforeToolTip"/></param>
        protected virtual void OnBeforeToolTip(MarqueeGenericCancelEventArgs<ToolTipData> args)
        {
            if (BeforeToolTip != null)
            {
                BeforeToolTip(this, args);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the default text for the newly added <see cref="TextElement"/> object
        /// </summary>
        /// <returns>Default text for added <see cref="TextElement"/> object </returns>
        private string GetDefaultText()
        {
            int count = 1;
            string defaultText = "Element" + 1;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Text.Equals(defaultText, StringComparison.CurrentCultureIgnoreCase))
                {
                    count++;
                    defaultText = "Element" + (count);
                    i = 0;
                }
            }
            return defaultText;
        }

        /// <summary>
        /// Gets the maximum height of the stripe.
        /// </summary>
        /// <returns></returns>
        private int GetMaxHeight()
        {
            int currMax = 0;
            for (int i = 0; i < Elements.Count; i++)
            {
                currMax = Math.Max(currMax, (int)this[i].GetSize().Height);
            }
            return currMax;
        }

        #endregion
    }



    #endregion

    #endregion


    #endregion

    #region Designer

    #region MarqueeImageListIndexEditor
    public class MarqueeImageListIndexEditor : UITypeEditor
    {
        protected ImageList currentImageList;
        protected PropertyDescriptor currentImageListProp;
        protected object currentInstance;
        protected UITypeEditor imageEditor = ((UITypeEditor)TypeDescriptor.GetEditor(typeof(Image), typeof(UITypeEditor)));
        private ImageIndexUI imageUI;

        internal UITypeEditor ImageEditor
        {
            get { return imageEditor; }
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (edSvc == null)
                {
                    return value;
                }
                if (imageUI == null)
                {
                    imageUI = new ImageIndexUI();
                }
                InitializeImageList(context);
                imageUI.Start(edSvc, value, currentImageList);
                edSvc.DropDownControl(imageUI);
                value = imageUI.Value;
                imageUI.End();
            }
            return value;
        }

        private void InitializeImageList(ITypeDescriptorContext context)
        {
            object instance = context.Instance;
            PropertyDescriptor imageListProperty = GetImageListProperty(context.PropertyDescriptor, ref instance);
            while ((instance != null) && (imageListProperty == null))
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(instance);
                foreach (PropertyDescriptor descriptor2 in properties)
                {
                    if (typeof(ImageList).IsAssignableFrom(descriptor2.PropertyType))
                    {
                        imageListProperty = descriptor2;
                        break;
                    }
                }
            }
            if (imageListProperty != null)
            {
                currentImageList = (ImageList)imageListProperty.GetValue(instance);
                currentImageListProp = imageListProperty;
                currentInstance = instance;
            }
            else
            {
                currentImageList = null;
                currentImageListProp = imageListProperty;
                currentInstance = instance;
            }
        }

        protected virtual Image GetImage(ITypeDescriptorContext context, int index, string key, bool useIntIndex)
        {
            Image image = null;
            object instance = context.Instance;
            if (!(instance is object[]))
            {
                if ((index < 0) && (key == null))
                {
                    return image;
                }
                InitializeImageList(context);
                if (currentImageList != null)
                {
                    if (useIntIndex)
                    {
                        if ((currentImageList != null) && (index < currentImageList.Images.Count))
                        {
                            index = (index > 0) ? index : 0;
                            image = currentImageList.Images[index];
                        }
                        return image;
                    }
                    return currentImageList.Images[key];
                }
            }
            return null;
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return ((imageEditor != null) && imageEditor.GetPaintValueSupported(context));
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            if (ImageEditor != null)
            {
                Image image = null;
                if (e.Value is int)
                {
                    image = GetImage(e.Context, (int)e.Value, null, true);
                }
                else if (e.Value is string)
                {
                    image = GetImage(e.Context, -1, (string)e.Value, false);
                }
                if (image != null)
                {
                    ImageEditor.PaintValue(new PaintValueEventArgs(e.Context, image, e.Graphics, e.Bounds));
                }
            }
        }

        public static PropertyDescriptor GetImageListProperty(PropertyDescriptor currentComponent, ref object instance)
        {
            if (instance is object[])
            {
                return null;
            }
            PropertyDescriptor descriptor = null;
            object component = instance;
            MarqueeTextImagePropertyAttribute attribute = currentComponent.Attributes[typeof(MarqueeTextImagePropertyAttribute)] as MarqueeTextImagePropertyAttribute;
            if (attribute != null)
            {
                string[] strArray = attribute.PropertyName.Split(new char[] { '.' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (component == null)
                    {
                        return descriptor;
                    }
                    PropertyDescriptor descriptor2 = TypeDescriptor.GetProperties(component)[strArray[i]];
                    if (descriptor2 == null)
                    {
                        return descriptor;
                    }
                    if (i == (strArray.Length - 1))
                    {
                        if (typeof(ImageList).IsAssignableFrom(descriptor2.PropertyType))
                        {
                            instance = component;
                            return descriptor2;
                        }
                    }
                    else
                    {
                        component = descriptor2.GetValue(component);
                    }
                }
            }
            return descriptor;
        }

        #region Nested type: ImageIndexUI

        private class ImageIndexUI : ListBox
        {
            private IWindowsFormsEditorService edSvc;
            private int value = -1;

            public ImageIndexUI()
            {
#pragma warning disable DoNotCallOverridableMethodsInConstructor
                ItemHeight = 20;
                Height = 20 * 5;
                DrawMode = DrawMode.OwnerDrawFixed;
                Dock = DockStyle.Fill;
#pragma warning restore DoNotCallOverridableMethodsInConstructor
                BorderStyle = BorderStyle.None;
            }

            public int Value
            {
                get { return value; }
            }

            public void End()
            {
                edSvc = null;
                value = -1;
            }

            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                value = SelectedIndex - 1;
                edSvc.CloseDropDown();
            }

            protected override void OnDrawItem(DrawItemEventArgs die)
            {
                base.OnDrawItem(die);
                if (die.Index != -1)
                {
                    Bitmap image = Items[die.Index] as Bitmap;
                    string s = (die.Index - 1).ToString();
                    Font font = die.Font;
                    Brush brush = new SolidBrush(die.ForeColor);
                    die.DrawBackground();
                    if (image != null)
                    {
                        die.Graphics.DrawRectangle(SystemPens.WindowText, new Rectangle(die.Bounds.X, die.Bounds.Y, 18, 18));
                        die.Graphics.DrawImage(image, new Rectangle(die.Bounds.X + 2, die.Bounds.Y + 2, 16, 16));
                        die.Graphics.DrawString(s, font, brush, die.Bounds.X + 36, die.Bounds.Y + ((die.Bounds.Height - font.Height) / 2));
                    }
                    else
                    {
                        die.Graphics.DrawString("(none)", font, brush, die.Bounds.X + 36, die.Bounds.Y + ((die.Bounds.Height - font.Height) / 2));
                    }
                    brush.Dispose();
                }
            }

            protected override bool ProcessDialogKey(Keys keyData)
            {
                if (((keyData & Keys.KeyCode) == Keys.Return) && ((keyData & (Keys.Alt | Keys.Control)) == Keys.None))
                {
                    OnClick(EventArgs.Empty);
                    return true;
                }
                return base.ProcessDialogKey(keyData);
            }

            public void Start(IWindowsFormsEditorService service, object objectValue, ImageList list)
            {
                edSvc = service;
                value = (int)objectValue;
                Items.Clear();
                Items.Add("(none");
                if (list != null)
                {
                    for (int i = 0; i < list.Images.Count; i++)
                    {
                        Items.Add(list.Images[i]);
                    }
                }

                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i] == objectValue)
                    {
                        SelectedIndex = i + 1;
                        return;
                    }
                }
            }
        }

        #endregion
    }

    #endregion

    #region MarqueeRangeEditor
    internal class MarqueeRangeEditor : UITypeEditor
    {
        private int min = 0;
        private int max = 100;
        private int defaultValue = 50;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService;
            OpacityEditorUI editor;

            if (context != null && context.Instance != null && provider != null)
            {
                editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                SetMinMaxValue(context);
                if (!(value is int && (int)value >= min && (int)value <= max))
                {
                    value = defaultValue;
                }
                if (editorService != null)
                {
                    int currentValue = (int)value;
                    editor = new OpacityEditorUI(currentValue, min, max);
                    editor.Dock = DockStyle.Fill;
                    editorService.DropDownControl(editor);
                    value = editor.GetValue();
                }
            }

            return value;
        }

        private void SetMinMaxValue(ITypeDescriptorContext context)
        {
            MarqueeMinMaxAttribute attribute = context.PropertyDescriptor.Attributes[typeof(MarqueeMinMaxAttribute)] as MarqueeMinMaxAttribute;
            if (attribute != null)
            {
                min = attribute.MinValue;
                max = attribute.MaxValue;
            }
            if (max <= min)
            {
                min = 0;
                max = 100;
                defaultValue = 0;
            }
            DefaultValueAttribute defaultVal = context.PropertyDescriptor.Attributes[typeof(DefaultValueAttribute)] as DefaultValueAttribute;
            if (defaultVal != null && defaultVal.Value is int)
            {
                defaultValue = (int)defaultVal.Value;
            }
            else
            {
                if (defaultValue > max)
                {
                    defaultValue = max;
                }
                if (defaultValue < min)
                {
                    defaultValue = min;
                }
            }
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        #region Nested type: OpacityEditorUI

        [ToolboxItem(false)]
        private class OpacityEditorUI : UserControl
        {
            /// <summary> 
            /// Required designer variable.
            /// </summary>
            private IContainer components = null;
            private int currentValue;
            private TrackBar trkMain;

            protected internal OpacityEditorUI(int currentValue, int min, int max)
            {
                InitializeComponent();
                this.currentValue = currentValue;
                trkMain.Minimum = min;
                trkMain.Maximum = max;
                trkMain.Value = currentValue;
                trkMain.TickFrequency = (max - min) / 10;
            }

            public object GetValue()
            {
                return currentValue;
            }

            private void trkMain_ValueChanged(object sender, EventArgs e)
            {
                currentValue = trkMain.Value;
            }

            /// <summary> 
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Component Designer generated code

            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.components = new Container();
                this.trkMain = new System.Windows.Forms.TrackBar();
                ((System.ComponentModel.ISupportInitialize)(this.trkMain)).BeginInit();
                this.SuspendLayout();
                // 
                // trkMain
                // 
                this.trkMain.AutoSize = false;
                this.trkMain.Dock = System.Windows.Forms.DockStyle.Fill;
                this.trkMain.Location = new System.Drawing.Point(0, 0);
                this.trkMain.Name = "trkMain";
                this.trkMain.RightToLeftLayout = true;
                this.trkMain.Size = new System.Drawing.Size(150, 37);
                this.trkMain.TabIndex = 0;
                this.trkMain.TickFrequency = 16;
                this.trkMain.ValueChanged += new System.EventHandler(this.trkMain_ValueChanged);
                // 
                // OpacityEditorUI
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.White;
                this.Controls.Add(this.trkMain);
                this.Name = "OpacityEditorUI";
                this.Size = new System.Drawing.Size(150, 37);
                ((System.ComponentModel.ISupportInitialize)(this.trkMain)).EndInit();
                this.ResumeLayout(false);
            }

            #endregion
        }

        #endregion
    }

    #endregion

    #region SuperMarqueDesigner
    internal class SuperMarqueDesigner : ControlDesigner
    {
        #region Constructor

        public SuperMarqueDesigner()
        {
            AutoResizeHandles = false;
        }

        #endregion

        #region Overrides

        ///<summary>
        ///Gets the design-time action lists supported by the component associated with the designer.
        ///</summary>
        ///
        ///<returns>
        ///The design-time action lists supported by the component associated with the designer.
        ///</returns>
        ///
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionListCollection = new DesignerActionListCollection();
                SuperMarqueDesignerActionList designerActionList = new SuperMarqueDesignerActionList(this);
                actionListCollection.Add(designerActionList);
                return actionListCollection;
            }
        }

        ///<summary>
        ///Initializes the designer with the specified component.
        ///</summary>
        ///
        ///<param name="component">The <see cref="T:System.ComponentModel.IComponent"></see> to associate with the designer. </param>
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            AutoResizeHandles = true;
        }

        #endregion

        #region Properties

        internal IComponentChangeService ComponentChangeService
        {
            get { return (GetService(typeof(IComponentChangeService)) as IComponentChangeService); }
        }
        internal IDesignerHost DesignerHost
        {
            get { return (GetService(typeof(IDesignerHost)) as IDesignerHost); }
        }
        internal IMenuCommandService MenuCommandService
        {
            get { return (GetService(typeof(IMenuCommandService)) as IMenuCommandService); }
        }
        internal ISelectionService SelectionService
        {
            get { return (GetService(typeof(ISelectionService)) as ISelectionService); }
        }

        #endregion
    }


    #endregion

    #region SuperMarqueDesignerActionList

    internal class SuperMarqueDesignerActionList : DesignerActionList
    {
        #region Constructor

        public SuperMarqueDesignerActionList(IDesigner designer)
            : base(designer.Component)
        {
            ZeroitSuperMarquee marquee = designer.Component as ZeroitSuperMarquee;
            if (marquee != null)
            {
                marquee.Elements.Removed += delegate
                {
                    marquee.Invalidate();
                    RefreshDisplay();
                };
                marquee.Elements.Inserted += delegate
                {
                    marquee.Invalidate();
                    RefreshDisplay();
                };
                marquee.Elements.Cleared += delegate
                {
                    marquee.Invalidate();
                    RefreshDisplay();
                };
                marquee.Elements.Changed += delegate
                {
                    marquee.Invalidate();
                    RefreshDisplay();
                };
            }
        }

        #endregion

        #region Overrides

        ///<summary>
        ///Gets or sets a value indicating whether the smart tag panel should automatically be displayed when it is created.
        ///</summary>
        ///
        ///<returns>
        ///true if the panel should be shown when the owning component is created; otherwise, false. The default is false.
        ///</returns>
        ///
        public override bool AutoShow
        {
            get { return true; }
            set { base.AutoShow = value; }
        }

        ///<summary>
        ///Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"></see> objects contained in the list.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.ComponentModel.Design.DesignerActionItem"></see> array that contains the items in this list.
        ///</returns>
        ///
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();
            items.Add(new DesignerActionHeaderItem("Appearance", "Appearance"));
            items.Add(new DesignerActionMethodItem(this, "Reset", "Reset", "Appearance", true));
            items.Add(new DesignerActionMethodItem(this, "SetStripColor", "Choose Strip Color", "Appearance", true));
            items.Add(new DesignerActionMethodItem(this, "SetBackColor", "Choose Back Color", "Appearance", true));
            items.Add(new DesignerActionPropertyItem("BackgroundImage", "BackgroundImage", "Appearance"));
            items.Add(new DesignerActionPropertyItem("BackgroundImageLayout", "BackgroundImageLayout", "Appearance"));
            items.Add(new DesignerActionPropertyItem("ImageList", "ImageList", "Appearance"));
            if (ZeroitSuperMarquee.ImageList == null)
            {
                items.Add(new DesignerActionMethodItem(this, "AddImageList", "Add ImageList", "Appearance", true));
            }
            else
            {
                items.Add(new DesignerActionMethodItem(this, "RemoveImageList", "Remove ImageList", "Appearance", true));
            }

            items.Add(new DesignerActionHeaderItem("Collection", "Collection"));
            items.Add(new DesignerActionPropertyItem("Elements", "Element Editor", "Collection"));
            items.Add(new DesignerActionMethodItem(this, "AddElement", "Add Element", "Collection", true));
            if (ZeroitSuperMarquee.Elements.Count > 0)
            {
                items.Add(new DesignerActionMethodItem(this, "ClearElement", "Clear Element", "Collection", true));
            }

            items.Add(new DesignerActionHeaderItem("Behavior", "Behavior"));
            items.Add(new DesignerActionMethodItem(this, "OnDock", GetDockText(), "Behavior", true));
            items.Add(new DesignerActionMethodItem(this, "StartStop", ZeroitSuperMarquee.Running ? "Stop marquee" : "Start marquee", "Behavior", true));
            items.Add(new DesignerActionPropertyItem("HoverStop", "Hover Stop", "Behavior"));
            items.Add(new DesignerActionPropertyItem("AutoRewind", "Auto Rewind", "Behavior"));
            items.Add(new DesignerActionPropertyItem("MarqueeSpeed", "Marquee Speed", "Behavior"));
            items.Add(new DesignerActionMethodItem(this, "ShowStrip", ZeroitSuperMarquee.ShowStrip ? "Hide Strip" : "Show Strip", "Behavior", true));
            return items;
        }

        #endregion

        #region Property

        private ZeroitSuperMarquee ZeroitSuperMarquee
        {
            get { return (ZeroitSuperMarquee)Component; }
        }

        #endregion

        #region Helper Methods

        private void RefreshDisplay()
        {
            DesignerActionUIService service = (DesignerActionUIService)GetService(typeof(DesignerActionUIService));
            if (service != null)
            {
                service.Refresh(ZeroitSuperMarquee);
            }
        }

        private static Color GetColor(Color defColor)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = defColor;
            dlg.FullOpen = true;
            dlg.SolidColorOnly = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.Color;
            }
            return Color.Empty;
        }

        private string GetDockText()
        {
            if (ZeroitSuperMarquee.Dock == DockStyle.None)
            {
                return "Dock in parent container";
            }
            return "Undock in parent container";
        }

        #endregion

        #region Designer Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MarqueeGenericCollection<TextElement> Elements
        {
            get { return ZeroitSuperMarquee.Elements; }
        }
        public ImageList ImageList
        {
            get { return ZeroitSuperMarquee.ImageList; }
            set
            {
                if (ZeroitSuperMarquee.ImageList != value)
                {
                    ZeroitSuperMarquee.ImageList = value;
                    ZeroitSuperMarquee.Invalidate();
                }
            }
        }
        public bool HoverStop
        {
            get { return ZeroitSuperMarquee.HoverStop; }
            set
            {
                if (ZeroitSuperMarquee.HoverStop != value)
                {
                    ZeroitSuperMarquee.HoverStop = value;
                    ZeroitSuperMarquee.Invalidate();
                }
            }
        }

        public bool AutoRewind
        {
            get { return ZeroitSuperMarquee.AutoRewind; }
            set
            {
                if (ZeroitSuperMarquee.AutoRewind != value)
                {
                    ZeroitSuperMarquee.AutoRewind = value;
                    ZeroitSuperMarquee.Invalidate();
                }
            }
        }

        public ImageLayout BackgroundImageLayout
        {
            get { return ZeroitSuperMarquee.BackgroundImageLayout; }
            set
            {
                if (ZeroitSuperMarquee.BackgroundImageLayout != value)
                {
                    ZeroitSuperMarquee.BackgroundImageLayout = value;
                    ZeroitSuperMarquee.Invalidate();
                }
            }
        }

        public Image BackgroundImage
        {
            get { return ZeroitSuperMarquee.BackgroundImage; }
            set
            {
                if (ZeroitSuperMarquee.BackgroundImage != value)
                {
                    ZeroitSuperMarquee.BackgroundImage = value;
                    ZeroitSuperMarquee.Invalidate();
                }
            }
        }

        [Editor(typeof(MarqueeRangeEditor), typeof(UITypeEditor))]
        [MinMax(1, 999)]
        public int MarqueeSpeed
        {
            get { return ZeroitSuperMarquee.MarqueeSpeed; }
            set
            {
                if (ZeroitSuperMarquee.MarqueeSpeed != value)
                {
                    ZeroitSuperMarquee.MarqueeSpeed = value;
                    ZeroitSuperMarquee.Invalidate();
                }
            }
        }

        #endregion

        #region Designer Methods

        protected virtual void ClearElement()
        {
            ZeroitSuperMarquee.Elements.Clear();
            ZeroitSuperMarquee.Invalidate();
            RefreshDisplay();
        }

        protected virtual void AddElement()
        {
            ZeroitSuperMarquee.Elements.Add(new TextElement());
            ZeroitSuperMarquee.Invalidate();
            RefreshDisplay();
        }

        protected virtual void AddImageList()
        {
            ImageList imageList = GetExistingImageList();
            if (imageList == null)
            {
                imageList = CreateNewImagelist();
            }
            ZeroitSuperMarquee.ImageList = imageList;
            ZeroitSuperMarquee.Invalidate();
            RefreshDisplay();
        }

        private ImageList CreateNewImagelist()
        {
            IContainer container = null;
            System.Windows.Forms.Form form = ZeroitSuperMarquee.FindForm();
            if (form != null)
            {
                container = form.Container;
            }
            else
            {
                if (ZeroitSuperMarquee.Parent != null)
                {
                    container = ZeroitSuperMarquee.Parent.Container;
                }
            }
            if (container == null)
            {
                return null;
            }
            ImageList imageList = new ImageList(container);
            return imageList;
        }

        private ImageList GetExistingImageList()
        {
            IContainer container = null;
            System.Windows.Forms.Form form = ZeroitSuperMarquee.FindForm();
            if (form != null)
            {
                container = form.Container;
            }
            else
            {
                if (ZeroitSuperMarquee.Parent != null)
                {
                    container = ZeroitSuperMarquee.Parent.Container;
                }
            }
            if (container == null)
            {
                return null;
            }
            ImageList imageList = null;
            for (int i = 0; i < container.Components.Count; i++)
            {
                if (container.Components[i] is ImageList)
                {
                    imageList = (ImageList)container.Components[i];
                    break;
                }
            }
            return imageList;
        }

        protected virtual void RemoveImageList()
        {
            ZeroitSuperMarquee.ImageList = null;
            ZeroitSuperMarquee.Invalidate();
            RefreshDisplay();
        }

        protected virtual void ShowStrip()
        {
            ZeroitSuperMarquee.ShowStrip = !ZeroitSuperMarquee.ShowStrip;
            ZeroitSuperMarquee.Invalidate();
            RefreshDisplay();
        }

        protected virtual void OnDock()
        {
            if (ZeroitSuperMarquee.Dock == DockStyle.Fill)
            {
                ZeroitSuperMarquee.Dock = DockStyle.None;
            }
            else
            {
                ZeroitSuperMarquee.Dock = DockStyle.Fill;
            }
            RefreshDisplay();
        }

        protected virtual void SetStripColor()
        {
            Color c = GetColor(ZeroitSuperMarquee.StripColor);
            if (!c.IsEmpty)
            {
                ZeroitSuperMarquee.StripColor = c;
                ZeroitSuperMarquee.Invalidate();
            }
        }

        protected virtual void SetBackColor()
        {
            Color c = GetColor(ZeroitSuperMarquee.BackColor);
            if (!c.IsEmpty)
            {
                ZeroitSuperMarquee.BackColor = c;
                ZeroitSuperMarquee.Invalidate();
            }
        }

        protected virtual void Reset()
        {
            ZeroitSuperMarquee.Reset();
            ZeroitSuperMarquee.Invalidate();
            RefreshDisplay();
        }

        protected virtual void StartStop()
        {
            ZeroitSuperMarquee.Running = !ZeroitSuperMarquee.Running;
            RefreshDisplay();
        }

        #endregion
    }


    #endregion

    #region TextElementDesigner

    internal class TextElementDesigner : ComponentDesigner
    {
        private TextElement TextElement
        {
            get { return (TextElement)Component; }
        }

        ///<summary>
        ///Gets the design-time action lists supported by the component associated with the designer.
        ///</summary>
        ///
        ///<returns>
        ///The design-time action lists supported by the component associated with the designer.
        ///</returns>
        ///
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionListCollection = new DesignerActionListCollection();
                TextElementDesignerActionList designerActionList = new TextElementDesignerActionList(this);
                actionListCollection.Add(designerActionList);
                return actionListCollection;
            }
        }

        protected override IComponent ParentComponent
        {
            get
            {
                return TextElement.Parent;
            }
        }

        internal BehaviorService BehaviorService
        {
            get
            {
                BehaviorService service = GetService(typeof(BehaviorService)) as BehaviorService;
                if (service != null)
                {
                    service.AdornerWindowGraphics.Clip = new Region(new Rectangle(0, 0, 10, 10));
                }
                return service;
            }
        }
    }

    internal class TextElementDesignerActionList : DesignerActionList
    {
        private TextElement TextElement
        {
            get
            {
                return (TextElement)Component;
            }
        }

        #region Constructor

        public TextElementDesignerActionList(IDesigner designer)
            : base(designer.Component)
        {
        }

        #endregion


        #region Overrides

        ///<summary>
        ///Gets or sets a value indicating whether the smart tag panel should automatically be displayed when it is created.
        ///</summary>
        ///
        ///<returns>
        ///true if the panel should be shown when the owning component is created; otherwise, false. The default is false.
        ///</returns>
        ///
        public override bool AutoShow
        {
            get { return true; }
            set { base.AutoShow = value; }
        }

        ///<summary>
        ///Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"></see> objects contained in the list.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.ComponentModel.Design.DesignerActionItem"></see> array that contains the items in this list.
        ///</returns>
        ///
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();
            items.Add(new DesignerActionHeaderItem("Appearance", "Appearance"));
            items.Add(new DesignerActionMethodItem(this, "Reset", "Reset", "Appearance", true));
            items.Add(new DesignerActionMethodItem(this, "ForeColor", "ForeColor", "Appearance", true));
            items.Add(new DesignerActionPropertyItem("Font", "Font", "Appearance"));

            items.Add(new DesignerActionHeaderItem("Behavior", "Behavior"));
            items.Add(new DesignerActionPropertyItem("Text", "Text", "Behavior"));
            items.Add(new DesignerActionPropertyItem("IsLink", "Is Link", "Behavior"));
            return items;
        }

        #endregion

        protected void Reset()
        {
            TextElement.Reset();
            TextElement.Parent.Invalidate();
        }

        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Text
        {
            get { return TextElement.Text; }
            set
            {
                if (!TextElement.Text.Equals(value))
                {
                    TextElement.Text = value;
                    TextElement.Parent.Invalidate();
                }
            }
        }

        public void ForeColor()
        {
            Color c = GetColor(TextElement.ForeColor);
            if (!c.IsEmpty)
            {
                TextElement.ForeColor = c;
                TextElement.Parent.Invalidate();
            }
        }
        public bool IsLink
        {
            get { return TextElement.IsLink; }
            set
            {
                if (!TextElement.IsLink.Equals(value))
                {
                    TextElement.IsLink = value;
                    TextElement.Parent.Invalidate();
                }
            }
        }
        public Font Font
        {
            get { return TextElement.Font; }
            set
            {
                if (!TextElement.Font.Equals(value))
                {
                    TextElement.Font = value;
                    TextElement.Parent.Invalidate();
                }
            }
        }

        private static Color GetColor(Color defColor)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = defColor;
            dlg.FullOpen = true;
            dlg.SolidColorOnly = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.Color;
            }
            return Color.Empty;
        }
    }


    #endregion

    #endregion

    #region Entity

    #region MarqueeHitTestInfo
    /// <summary>
    /// HitTest information class  for the ZeroitSuperMarquee control.
    /// </summary>
    public class MarqueeHitTestInfo
    {
        private HitTestArea area;
        private int index;
        private Point point;

        /// <summary>
        /// Default constructor
        /// </summary>
        internal MarqueeHitTestInfo()
        {
        }

        /// <summary>
        /// Create instance of <see cref="MarqueeHitTestInfo"/>. Use this to get the HitTest information.
        /// </summary>
        /// <param name="control"><see cref="ZeroitSuperMarquee"/> for which HitTest is to be performed.</param>
        /// <param name="testPoint">HitTest Point</param>
        public MarqueeHitTestInfo(ZeroitSuperMarquee control, Point testPoint)
        {
            if (control != null)
            {
                MarqueeHitTestInfo test = control.HitTest(testPoint);
                index = test.index;
                point = test.point;
                area = test.area;
            }
            else
            {
                index = -1;
                point = testPoint;
                area = HitTestArea.None;
            }
        }

        /// <summary>
        /// Index of the <see cref="TextElement"/> if point is above element otherwise -1.
        /// </summary>
        public int Index
        {
            get { return index; }
            internal set { index = value; }
        }

        /// <summary>
        /// HitTest point.
        /// </summary>
        public Point Point
        {
            get { return point; }
            internal set { point = value; }
        }

        /// <summary>
        /// <see cref="HitTestArea"/> at which point is located.
        /// </summary>
        public HitTestArea Area
        {
            get { return area; }
            internal set { area = value; }
        }
    }

    #endregion

    #region TextElement.Serialize
    partial class TextElement
    {
        #region Should serialize implementation

        private bool ShouldSerializeForeColor()
        {
            return foreColor != SystemColors.ControlText;
        }

        private bool ShouldSerializeIsLink()
        {
            return !isLink;
        }

        private bool ShouldSerializeFont()
        {
            return !font.Equals(new Font("Microsoft Sans Serif", 8.25F));
        }

        private bool ShouldSerializeTag()
        {
            return tag != null;
        }

        private bool ShouldSerializeLeftImageIndex()
        {
            return leftImageIndex != -1;
        }

        private bool ShouldSerializeRightImageIndex()
        {
            return rightImageIndex != -1;
        }
        private bool ShouldSerializeToolTipText()
        {
            return ToolTipText != string.Empty;
        }
        #endregion

        #region Reset implementation

        /// <summary>
        /// Reset the <see cref="TextElement"/>
        /// </summary>
        public void Reset()
        {
            ResetForeColor();
            ResetIsLink();
            ResetFont();
            ResetTag();
            ResetLeftImageIndex();
            ResetRightImageIndex();
            ResetToolTipText();
        }

        private void ResetForeColor()
        {
            foreColor = SystemColors.ControlText;
        }

        private void ResetIsLink()
        {
            isLink = true;
        }

        private void ResetFont()
        {
            font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point); ;
        }

        private void ResetTag()
        {
            tag = null;
        }

        private void ResetLeftImageIndex()
        {
            leftImageIndex = -1;
        }

        private void ResetRightImageIndex()
        {
            rightImageIndex = -1;
        }

        private void ResetToolTipText()
        {
            ToolTipText = string.Empty;
        }
        #endregion
    }
    #endregion

    #region TextElement
    /// <summary>
    /// Component to be used as display in marquee control.
    /// </summary>
    [Designer(typeof(TextElementDesigner))]
    [ToolboxItem(false)]
    public partial class TextElement : Component
    {
        #region Private Fields

        private Color foreColor;
        private Font font;
        private bool isLink;
        private int leftImageIndex;
        private Rectangle leftRect = new Rectangle(0, 0, 0, 0);
        private ZeroitSuperMarquee parent;
        private int rightImageIndex;
        private Rectangle rightRect = new Rectangle(0, 0, 0, 0);
        private object tag;
        private string text;
        private Rectangle textRect = new Rectangle(0, 0, 0, 0);
        private string toolTipText;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TextElement()
        {
            text = string.Empty;
            foreColor = SystemColors.ControlText;
            isLink = true;
            font = new Font("Microsoft Sans Serif", 8.25F);
            leftImageIndex = -1;
            rightImageIndex = -1;
            toolTipText = string.Empty;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="text">Text of the element.</param>
        public TextElement(string text)
        {
            this.text = text;
            foreColor = SystemColors.ControlText;
            isLink = true;
            font = new Font("Microsoft Sans Serif", 8.25F);
            leftImageIndex = -1;
            rightImageIndex = -1;
            toolTipText = string.Empty;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="text">Text of the element.</param>
        /// <param name="isLink">Indicates behaves like a link or not.</param>
        public TextElement(string text, bool isLink)
        {
            this.text = text;
            foreColor = SystemColors.ControlText;
            this.isLink = isLink;
            font = new Font("Microsoft Sans Serif", 8.25F);
            leftImageIndex = -1;
            rightImageIndex = -1;
            toolTipText = string.Empty;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="text">Text of the new element.</param>
        /// <param name="foreColor">Text color of the element</param>
        public TextElement(string text, Color foreColor)
        {
            this.text = text;
            this.foreColor = foreColor;
            font = new Font("Microsoft Sans Serif", 8.25F);
            isLink = true;
            leftImageIndex = -1;
            rightImageIndex = -1;
            toolTipText = string.Empty;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="text">Text of the new element.</param>
        /// <param name="foreColor">Text color of the element</param>
        /// <param name="isLink">Indicates behaves like a link or not.</param>
        public TextElement(string text, Color foreColor, bool isLink)
        {
            this.text = text;
            this.foreColor = foreColor;
            font = new Font("Microsoft Sans Serif", 8.25F);
            this.isLink = isLink;
            leftImageIndex = -1;
            rightImageIndex = -1;
            toolTipText = string.Empty;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="text">Text of the new element.</param>
        /// <param name="foreColor">Text color of the element</param>
        /// <param name="font">F</param>ont of the element.
        public TextElement(string text, Color foreColor, Font font)
        {
            this.text = text;
            this.foreColor = foreColor;
            this.font = font;
            isLink = true;
            leftImageIndex = -1;
            rightImageIndex = -1;
            toolTipText = string.Empty;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="text">Text of the new element.</param>
        /// <param name="foreColor">Text color of the element</param>
        /// <param name="font">F</param>ont of the element.
        /// <param name="isLink">Indicates behaves like a link or not.</param>
        public TextElement(string text, Color foreColor, Font font, bool isLink)
        {
            this.text = text;
            this.foreColor = foreColor;
            this.font = font;
            this.isLink = isLink;
            leftImageIndex = -1;
            rightImageIndex = -1;
            toolTipText = string.Empty;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="text">Text of the new element.</param>
        /// <param name="leftImageIndex">Left image index</param>
        /// <param name="rightImageIndex">Right image index</param>
        /// <param name="isLink">Indicates behaves like a link or not.</param>
        public TextElement(string text, int leftImageIndex, int rightImageIndex, bool isLink)
        {
            this.text = text;
            foreColor = SystemColors.ControlText;
            font = new Font("Microsoft Sans Serif", 8.25F);
            this.leftImageIndex = leftImageIndex;
            this.rightImageIndex = rightImageIndex;
            this.isLink = isLink;
            toolTipText = string.Empty;
        }

        #endregion

        #region internal Methods

        internal SizeF GetSize()
        {
            using (Graphics ge = Graphics.FromImage(new Bitmap(10, 10)))
            {
                SizeF sz = ge.MeasureString(text, font);
                int imageFactor = 0;
                int imageHeight = 0;
                if (leftImageIndex >= 0 && parent.ImageList != null && leftImageIndex < parent.ImageList.Images.Count)
                {
                    imageFactor += parent.ImageList.ImageSize.Width;
                    imageHeight = parent.ImageList.ImageSize.Height;
                }
                if (rightImageIndex >= 0 && parent.ImageList != null && rightImageIndex < parent.ImageList.Images.Count)
                {
                    imageFactor += parent.ImageList.ImageSize.Width;
                    imageHeight = parent.ImageList.ImageSize.Height;
                }
                return new SizeF(sz.Width + imageFactor + 8, Math.Max(sz.Height, imageHeight));
            }
        }

        internal void DrawElement(Graphics g, ref Point startPoint, int offset)
        {
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            SizeF size = GetSize();
            if (leftImageIndex >= 0 && parent.ImageList != null && leftImageIndex < parent.ImageList.Images.Count)
            {
                Image leftImage = parent.ImageList.Images[leftImageIndex];
                leftRect = new Rectangle(startPoint.X - offset + 4, (startPoint.Y - (leftImage.Height / 2)), leftImage.Width, leftImage.Height);
                g.DrawImage(leftImage, leftRect);
                startPoint.X = startPoint.X + leftImage.Width + 4;
            }

            textRect = new Rectangle(startPoint.X - offset, (startPoint.Y - ((int)size.Height / 2)), (int)size.Width, (int)size.Height);
            StringFormat f = new StringFormat();
            f.Alignment = StringAlignment.Center;
            f.LineAlignment = StringAlignment.Center;
            f.Trimming = StringTrimming.None;
            g.DrawString(text, font, new SolidBrush(foreColor), textRect, f);
            startPoint.X = (int)(startPoint.X + size.Width);

            if (rightImageIndex >= 0 && parent.ImageList != null && rightImageIndex < parent.ImageList.Images.Count)
            {
                Image rightImage = parent.ImageList.Images[rightImageIndex];
                rightRect = new Rectangle(startPoint.X - offset, (startPoint.Y - (rightImage.Height / 2)), rightImage.Width, rightImage.Height);
                g.DrawImage(rightImage, rightRect);
                startPoint.X = startPoint.X + rightImage.Width + 4;
            }
        }

        /// <summary>
        /// Sets the parent of the element.
        /// </summary>
        /// <param name="marquee">Parent control</param>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        internal void SetParent(ZeroitSuperMarquee marquee)
        {
            parent = marquee;
        }

        #endregion

        #region Public Property

        /// <summary>
        /// Text displayed in this element.
        /// </summary>
        [Description("Text displayed in this element.")]
        [Category("Behavior")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [Localizable(true)]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        /// <summary>
        /// Text color of the element.
        /// </summary>
        [Description("Text color of the element.")]
        [Category("Appearance")]
        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }
        /// <summary>
        /// Indicates whether the element will be displayed as a link or not.
        /// </summary>
        [Description("Indicates whether the element will be displayed as a link or not.")]
        [Category("Behavior")]
        public bool IsLink
        {
            get { return isLink; }
            set { isLink = value; }
        }
        /// <summary>
        /// Font of this element.
        /// </summary>
        [Description("Font of this element.")]
        [Category("Appearance")]
        public Font Font
        {
            get { return font; }
            set { font = value; }
        }
        /// <summary>
        /// User data associated with the element.
        /// </summary>
        [Description("Text displayed in this element.")]
        [Category("Behavior")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }
        /// <summary>
        /// Left image index of the image to be displayed.
        /// </summary>
        [Description("Left image index of the image to be displayed.")]
        [Category("Appearance")]
        [Editor(typeof(MarqueeImageListIndexEditor), typeof(UITypeEditor)), MarqueeTextImageProperty("Parent.ImageList"), TypeConverter(typeof(ImageIndexConverter))]
        public int LeftImageIndex
        {
            get { return leftImageIndex; }
            set { leftImageIndex = value; }
        }
        /// <summary>
        /// Right image index of the image to be displayed.
        /// </summary>
        [Description("Right image index of the image to be displayed.")]
        [Category("Appearance")]
        [Editor(typeof(MarqueeImageListIndexEditor), typeof(UITypeEditor)), MarqueeTextImageProperty("Parent.ImageList"), TypeConverter(typeof(ImageIndexConverter))]
        public int RightImageIndex
        {
            get { return rightImageIndex; }
            set { rightImageIndex = value; }
        }
        /// <summary>
        /// Parent where this element is added.
        /// </summary>
        [Description("Parent where this element is added.")]
        [Category("Parent")]
        public ZeroitSuperMarquee Parent
        {
            get { return parent; }
            internal set { parent = value; }
        }
        /// <summary>
        /// Text displayed in this element.
        /// </summary>
        [Description("Text displayed in this element.")]
        [Category("Behavior")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [Localizable(true)]
        public string ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText = value; }
        }

        #endregion

        #region Internal Property

        internal Rectangle TextRect
        {
            get { return textRect; }
        }
        internal Rectangle LeftRect
        {
            get { return leftRect; }
        }
        internal Rectangle RightRect
        {
            get { return rightRect; }
        }

        #endregion

        #region Overrides

        ///<summary>
        ///Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override string ToString()
        {
            return text;
        }

        ///<summary>
        ///Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
        ///</summary>
        ///
        ///<returns>
        ///A hash code for the current <see cref="T:System.Object"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        ///<summary>
        ///Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component"></see> and optionally releases the managed resources.
        ///</summary>
        ///
        ///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
        protected override void Dispose(bool disposing)
        {
            text = string.Empty;
            foreColor = Color.Empty;
            isLink = true;
            font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            leftImageIndex = -1;
            rightImageIndex = -1;
            base.Dispose(disposing);
        }

        #endregion
    }

    #endregion

    #region ToolTipData
    /// <summary>
    /// Stores data of ToolTip.
    /// </summary>
    public class ToolTipData
    {
        private string toolTipText;
        private readonly int itemIndex;
        private Point location;

        /// <summary>
        /// Create instance of the class.
        /// </summary>
        /// <param name="toolTipText">text associated with ToolTip</param>
        /// <param name="itemIndex">index of the Item over which ToolTip will be displayed</param>
        /// <param name="location">location of ToolTip relative to Control. Do not forget to call Control.PointToClient method.</param>
        public ToolTipData(string toolTipText, int itemIndex, Point location)
        {
            this.toolTipText = toolTipText;
            this.itemIndex = itemIndex;
            this.location = location;
        }
        /// <summary>
        /// Gets or sets text associated with ToolTip
        /// </summary>
        public string ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText = value; }
        }
        /// <summary>
        /// Gets index of the Item over which ToolTip will be displayed.
        /// </summary>
        public int ItemIndex
        {
            get { return itemIndex; }
        }
        /// <summary>
        /// Gets or sets location of ToolTip relative to Control. Do not forget to call Control.PointToClient method.
        /// </summary>
        public Point Location
        {
            get { return location; }
            set { location = value; }
        }

        ///<summary>
        ///Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override string ToString()
        {
            return toolTipText;
        }

        ///<summary>
        ///Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
        ///</summary>
        ///
        ///<returns>
        ///A hash code for the current <see cref="T:System.Object"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }


    #endregion

    #endregion

    #region Enums

    #region HitTestArea
    /// <summary>
    /// Indicates the HitTestArea
    /// </summary>
    public enum HitTestArea
    {
        /// <summary>
        /// Item.
        /// </summary>
        Item,
        /// <summary>
        /// Left image.
        /// </summary>
        LeftImage,
        /// <summary>
        /// Right image.
        /// </summary>
        RightImage,
        /// <summary>
        /// Strip at which marquee is being displayed.
        /// </summary>
        Strip,
        /// <summary>
        /// Super marque control.
        /// </summary>
        Control,
        /// <summary>
        /// No where.
        /// </summary>
        None
    }


    #endregion

    #endregion

    #region Event Arguments

    #region MarqueeGenericCancelEventHandler
    /// <summary>
    /// Generic cancel event handler.
    /// </summary>
    /// <typeparam name="T">Generic value type.</typeparam>
    /// <param name="sender">Source of the event.</param>
    /// <param name="tArgs">Event data associated with the event.</param>
    public delegate void MarqueeGenericCancelEventHandler<T>(object sender, MarqueeGenericCancelEventArgs<T> tArgs);

    /// <summary>
    /// Cancel event argument.
    /// </summary>
    /// <typeparam name="T">Generic value type.</typeparam>
    public class MarqueeGenericCancelEventArgs<T> : CancelEventArgs
    {
        private T value;

        /// <summary>
        /// Create instance for <see cref="MarqueeGenericCancelEventArgs{T}"/>
        /// </summary>
        /// <param name="value">Event data associated with the event.</param>
        public MarqueeGenericCancelEventArgs(T value)
            : base(false)
        {
            this.value = value;
        }

        /// <summary>
        /// Create instance for <see cref="MarqueeGenericCancelEventArgs{T}"/>
        /// </summary>
        /// <param name="value">Event data associated with the event.</param>
        /// <param name="cancel">Perform cancel operation.</param>
        public MarqueeGenericCancelEventArgs(T value, bool cancel)
            : base(cancel)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets or sets value.
        /// </summary>
        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }


    #endregion

    #region MarqueeGenericChangeEventArgs
    /// <summary>
    /// Generic Event Handler.
    /// </summary>
    /// <typeparam name="T">Generic value type.</typeparam>
    public class MarqueeGenericChangeEventArgs<T> : CancelEventArgs
    {
        private readonly T oldValue;
        private T newValue;

        /// <summary>
        /// Craetes new instance of the <see cref="MarqueeGenericChangeEventArgs{T}"/>
        /// </summary>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        public MarqueeGenericChangeEventArgs(T oldValue, T newValue)
            : base(false)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        /// <summary>
        /// Craetes new instance of the <see cref="MarqueeGenericChangeEventArgs{T}"/>
        /// </summary>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        /// <param name="cancel">Perform cancel operation or not.</param>
        public MarqueeGenericChangeEventArgs(T oldValue, T newValue, bool cancel)
            : base(cancel)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        /// <summary>
        /// Gets old value.
        /// </summary>
        public T OldValue
        {
            get { return oldValue; }
        }
        /// <summary>
        /// Gets or sets New value
        /// </summary>
        public T NewValue
        {
            get { return newValue; }
            set { newValue = value; }
        }
    }


    #endregion

    #region ItemClickEventArgs
    /// <summary>
    /// Item click argument.
    /// </summary>
    public class ItemClickEventArgs : EventArgs
    {
        private readonly int index;

        /// <summary>
        /// Create  instance for EventAgrs
        /// </summary>
        /// <param name="index"></param>
        public ItemClickEventArgs(int index)
        {
            this.index = index;
        }

        /// <summary>
        /// Index of the element clicked.
        /// </summary>
        public int Index
        {
            get { return index; }
        }
    }


    #endregion

    #endregion

    #region CursorHelper
    internal static class CursorHelper
    {
        static CursorHelper()
        {
            GetCursor();
        }

        public static Cursor PressedCursor
        {
            get { return Cursors.Hand; }
        }
        public static Cursor NormalCursor
        {
            get { return Cursors.Hand; }
        }
        private static void GetCursor()
        {
        }
    }


    #endregion

    #endregion
}
