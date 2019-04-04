// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="FATabStripItemCollection.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class FATabStripItemCollection.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.CollectionWithEvents" />
    public class FATabStripItemCollection : CollectionWithEvents
    {
        #region Fields

        /// <summary>
        /// Occurs when [collection changed].
        /// </summary>
        [Browsable(false)]
        public event CollectionChangeEventHandler CollectionChanged;

        /// <summary>
        /// The lock update
        /// </summary>
        private int lockUpdate;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="FATabStripItemCollection"/> class.
        /// </summary>
        public FATabStripItemCollection()
        {
            lockUpdate = 0;
        }

        #endregion

        #region Props

        /// <summary>
        /// Gets or sets the <see cref="ZeroitFameyeTabStripItem"/> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>ZeroitFameyeTabStripItem.</returns>
        public ZeroitFameyeTabStripItem this[int index]
        {
            get
            {
                if (index < 0 || List.Count - 1 < index)
                    return null;

                return (ZeroitFameyeTabStripItem)List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        /// <summary>
        /// Gets the drawn count.
        /// </summary>
        /// <value>The drawn count.</value>
        [Browsable(false)]
        public virtual int DrawnCount
        {
            get
            {
                int count = Count, res = 0;
                if (count == 0) return 0;
                for (int n = 0; n < count; n++)
                {
                    if (this[n].IsDrawn) 
                        res++;
                }
                return res;
            }
        }

        /// <summary>
        /// Gets the last visible.
        /// </summary>
        /// <value>The last visible.</value>
        public virtual ZeroitFameyeTabStripItem LastVisible
        {
            get
            {
                for (int n = Count - 1; n > 0; n--)
                {
                    if (this[n].Visible)
                        return this[n];
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the first visible.
        /// </summary>
        /// <value>The first visible.</value>
        public virtual ZeroitFameyeTabStripItem FirstVisible
        {
            get
            {
                for (int n = 0; n < Count; n++)
                {
                    if (this[n].Visible)
                        return this[n];
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the visible count.
        /// </summary>
        /// <value>The visible count.</value>
        [Browsable(false)]
        public virtual int VisibleCount
        {
            get
            {
                int count = Count, res = 0;
                if (count == 0) return 0;
                for (int n = 0; n < count; n++)
                {
                    if (this[n].Visible) 
                        res++;
                }
                return res;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the <see cref="E:CollectionChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="CollectionChangeEventArgs"/> instance containing the event data.</param>
        protected virtual void OnCollectionChanged(CollectionChangeEventArgs e)
        {
            if (CollectionChanged != null)
                CollectionChanged(this, e);
        }

        /// <summary>
        /// Begins the update.
        /// </summary>
        protected virtual void BeginUpdate()
        {
            lockUpdate++;
        }

        /// <summary>
        /// Ends the update.
        /// </summary>
        protected virtual void EndUpdate()
        {
            if (--lockUpdate == 0)
                OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        public virtual void AddRange(ZeroitFameyeTabStripItem[] items)
        {
            BeginUpdate();
            try
            {
                foreach (ZeroitFameyeTabStripItem item in items)
                {
                    List.Add(item);
                }
            }
            finally
            {
                EndUpdate();
            }
        }

        /// <summary>
        /// Assigns the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public virtual void Assign(FATabStripItemCollection collection)
        {
            BeginUpdate();
            try
            {
                Clear();
                for (int n = 0; n < collection.Count; n++)
                {
                    ZeroitFameyeTabStripItem item = collection[n];
                    ZeroitFameyeTabStripItem newItem = new ZeroitFameyeTabStripItem();
                    newItem.Assign(item);
                    Add(newItem);
                }
            }
            finally
            {
                EndUpdate();
            }
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.Int32.</returns>
        public virtual int Add(ZeroitFameyeTabStripItem item)
        {
            int res = IndexOf(item);
            if (res == -1) res = List.Add(item);
            return res;
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public virtual void Remove(ZeroitFameyeTabStripItem item)
        {
            if (List.Contains(item))
                List.Remove(item);
        }

        /// <summary>
        /// Moves to.
        /// </summary>
        /// <param name="newIndex">The new index.</param>
        /// <param name="item">The item.</param>
        /// <returns>ZeroitFameyeTabStripItem.</returns>
        public virtual ZeroitFameyeTabStripItem MoveTo(int newIndex, ZeroitFameyeTabStripItem item)
        {
            int currentIndex = List.IndexOf(item);
            if (currentIndex >= 0)
            {
                RemoveAt(currentIndex);
                Insert(0, item);

                return item;
            }

            return null;
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.Int32.</returns>
        public virtual int IndexOf(ZeroitFameyeTabStripItem item)
        {
            return List.IndexOf(item);
        }

        /// <summary>
        /// Determines whether [contains] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.</returns>
        public virtual bool Contains(ZeroitFameyeTabStripItem item)
        {
            return List.Contains(item);
        }

        /// <summary>
        /// Inserts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        public virtual void Insert(int index, ZeroitFameyeTabStripItem item)
        {
            if (Contains(item)) return;
            List.Insert(index, item);
        }

        /// <summary>
        /// Called when [insert complete].
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        protected override void OnInsertComplete(int index, object item)
        {
            ZeroitFameyeTabStripItem itm = item as ZeroitFameyeTabStripItem;
            itm.Changed += new EventHandler(OnItem_Changed);
            OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, item));
        }

        /// <summary>
        /// Called when [remove].
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        protected override void OnRemove(int index, object item)
        {
            base.OnRemove(index, item);
            ZeroitFameyeTabStripItem itm = item as ZeroitFameyeTabStripItem;
            itm.Changed -= new EventHandler(OnItem_Changed);
            OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, item));
        }

        /// <summary>
        /// Raises the Clearing event when not suspended.
        /// </summary>
        protected override void OnClear()
        {
            if (Count == 0) return;
            BeginUpdate();
            try
            {
                for (int n = Count - 1; n >= 0; n--)
                {
                    RemoveAt(n);
                }
            }
            finally
            {
                EndUpdate();
            }
        }

        /// <summary>
        /// Handles the <see cref="E:ItemChanged" /> event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnItem_Changed(object sender, EventArgs e)
        {
            OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, sender));
        }

        #endregion
    }
}
