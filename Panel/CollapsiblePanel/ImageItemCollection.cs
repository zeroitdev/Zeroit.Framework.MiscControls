// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ImageItemCollection.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{
    #region ImageItemCollection
    /// <summary>
    /// ImageItemCollection represents an arbitrary number of image index
    /// mappings
    /// </summary>
    /// <remarks>Although we provide an implementation of <see cref="ICollection" /> we are not
    /// defined as doing so because it causes confusion with the designer.
    /// <para>This class is <see cref="SerializableAttribute" /> but does not implement
    /// <see cref="System.Runtime.Serialization.ISerializable" /></para></remarks>
	[Serializable]
    public class ImageItemCollection /* : ICollection */
    {
        #region class PropertyChangeEventArgs
        /// <summary>
        /// <see cref="ImageItemCollection.PropertyChange" /> event
        /// arguments
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class PropertyChangeEventArgs : System.EventArgs
        {
            /// <summary>
            /// The image index mapping that changed
            /// </summary>
            private readonly int indexChanged;

            /// <summary>
            /// Create a <c>PropertyChangeEventArgs</c>
            /// </summary>
            /// <param name="index">The index that changed or -1 if the associated
            /// <see cref="ImageSet" /> changed</param>
            public PropertyChangeEventArgs(int index)
            {
                this.indexChanged = index;
            }

            /// <summary>
            /// Get the image index mapping that changed
            /// </summary>
            /// <value>The index.</value>
            public int Index
            {
                get
                {
                    return indexChanged;
                }
            }

            /// <summary>
            /// Determine if the PropertyChange represents and image index
            /// mapping (as opposed to the associated <see cref="ImageSet" />)
            /// </summary>
            /// <value><c>true</c> if this instance is image index; otherwise, <c>false</c>.</value>
            public bool IsImageIndex
            {
                get
                {
                    return indexChanged != ImageItemCollection.Undefined;
                }
            }

            /// <summary>
            /// Determine if the PropertyChange represents a change to
            /// the associated <see cref="ImageSet" />
            /// </summary>
            /// <value><c>true</c> if this instance is image set; otherwise, <c>false</c>.</value>
            public bool IsImageSet
            {
                get
                {
                    return !IsImageIndex;
                }
            }
        }
        #endregion class PropertyChangeEventArgs

        #region Constants
        /// <summary>
        /// Represents an undefined mapping (i.e., no mapping)
        /// </summary>
        public const int Undefined = -1;
        #endregion Constants

        #region Fields
        /// <summary>
        /// The associated <see cref="ImageSet" /> that has the images being mapped
        /// </summary>
        [NonSerialized]
        private ImageSet imageSet = null;

        /// <summary>
        /// array that holds the image index mappings
        /// </summary>
        private int[] imageMap = null;

        /// <summary>
        /// <see cref="PropertyChange" /> event listeners
        /// </summary>
        private EventHandler propertyChangeListeners = null;
        #endregion Fields

        #region Constructor(s)
        /// <summary>
        /// Create an <c>ImageItemCollection</c> that holds the specified number
        /// of image mappings
        /// </summary>
        /// <param name="numImages">The number of image index mappings</param>
        /// <exception cref="System.ArgumentException">ImageItems: # of image items must be > 0</exception>
        /// <exception cref="ArgumentException">If <c>numImages</c> &lt;= 0</exception>
        public ImageItemCollection(int numImages)
        {
            if (numImages <= 0)
            {
                throw new ArgumentException("ImageItems: # of image items must be > 0");
            }

            imageMap = new int[numImages];

            for (int i = 0; i < numImages; i++)
            {
                imageMap[i] = -1;
            }
        }
        #endregion Constructor(s)

        #region Properties
        /// <summary>
        /// Get/Set an image index mapping
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.IndexOutOfRangeException">
        /// Image item (" + index + ") out-of-range
        /// or
        /// Image item (" + index + ") out-of-range
        /// </exception>
        /// <exception cref="IndexOutOfRangeException">If the index is invalid</exception>
        [Browsable(false)]
        public int this[int index]
        {
            get
            {
                if ((index < 0) || (index >= imageMap.Length))
                {
                    throw new IndexOutOfRangeException("Image item (" + index + ") out-of-range");
                }

                return imageMap[index];
            }

            set
            {
                if ((index < 0) || (index >= imageMap.Length))
                {
                    throw new IndexOutOfRangeException("Image item (" + index + ") out-of-range");
                }

                if (imageMap[index] != value)
                {
                    imageMap[index] = value;
                    OnPropertyChange(index);
                }
            }
        }

        /// <summary>
        /// Get/Set the associated <see cref="ImageSet" />
        /// </summary>
        /// <value>The image set.</value>
        /// <remarks>When the <see cref="ImageSet" /> changes we send a property change
        /// event with a index value of <see cref="Undefined" /></remarks>
        [Category("Images"), Description("ImageSet containing referenced images")]
        public ImageSet ImageSet
        {
            get
            {
                return imageSet;
            }

            set
            {
                if (imageSet != value)
                {
                    imageSet = value;
                    OnPropertyChange(Undefined);
                }
            }
        }

        /// <summary>
        /// Determine if all the image index mappings are undefined
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                for (int i = 0; i < imageMap.Length; i++)
                {
                    if (imageMap[i] != Undefined)
                        return false;
                }

                return true;
            }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Determine if the specified image index has a defined mapping
        /// </summary>
        /// <param name="index">The image index</param>
        /// <returns><see langword="true" /> if the image index has a defined mapping</returns>
        public bool IsDefined(int index)
        {
            return ((index >= 0) && (index < Count)) && (imageMap[index] != Undefined);
        }

        /// <summary>
        /// Determine if the specified image index is both defined and referencs
        /// a valid image
        /// </summary>
        /// <param name="index">The image index</param>
        /// <returns><see langword="true" /> if the image index has a defined mapping and a valid
        /// image in the <see cref="ImageSet" /></returns>
        public bool IsImage(int index)
        {
            if ((index < 0) || (index >= Count) || (imageMap[index] == Undefined) || (imageSet == null))
                return false;

            return (imageMap[index] < imageSet.Count);
        }

        /// <summary>
        /// Get the <see cref="Image" /> mapped for the specified image index
        /// </summary>
        /// <param name="index">The image index</param>
        /// <returns>The <see cref="Image" /> mapped for the specified image index, or <see langword="null" />
        /// if the image index mapping is undefined or the specified image does not exist</returns>
        /// <exception cref="System.IndexOutOfRangeException">ImageItemCollection.Image(int): index is out-of-range</exception>
        public Image Image(int index)
        {
            if ((index < 0) || (index >= Count))
            {
                throw new IndexOutOfRangeException("ImageItemCollection.Image(int): index is out-of-range");
            }

            return IsImage(index) ? imageSet.Images[imageMap[index]] : null;
        }
        #endregion Methods

        #region Events
        /// <summary>
        /// Add/Remove <c>PropertyChange</c> listeners
        /// </summary>
        public event EventHandler PropertyChange
        {
            add
            {
                propertyChangeListeners += value;
            }
            remove
            {
                propertyChangeListeners -= value;
            }
        }
        #endregion Events

        #region Overrides
        /// <summary>
        /// Compare this <c>ImageItemCollection</c> to another for equality
        /// </summary>
        /// <param name="obj">The other <c>ImageItemCollection</c> to compare</param>
        /// <returns><see langword="true" /> if the two instances have the same definition,
        /// <see langword="false" /> otherwise</returns>
        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is ImageItemCollection))
                return false;

            ImageItemCollection other = obj as ImageItemCollection;

            if (Count != other.Count)
                return false;

            if (other == this)
                return true;

            for (int i = 0; i < Count; i++)
            {
                if (imageMap[i] != other.imageMap[i])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Overridden to avoid warning when overriding <see cref="Equals(object)" />
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion Overrides

        #region Virtual Members
        /// <summary>
        /// Internal routine to trigger the <see cref="PropertyChange" />
        /// event to listeners
        /// </summary>
        /// <param name="index">The index that changed or <see cref="Undefined" />
        /// if the <see cref="ImageSet" /> changed</param>
        protected virtual void OnPropertyChange(int index)
        {
            if (propertyChangeListeners != null)
            {
                propertyChangeListeners(this, new PropertyChangeEventArgs(index));
            }
        }
        #endregion Virtual Members

        #region ICollection Members
        /// <summary>
        /// <see cref="ICollection.IsSynchronized" />
        /// </summary>
        /// <value><c>true</c> if this instance is synchronized; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// <see cref="ICollection.Count" />
        /// </summary>
        /// <value>The count.</value>
        [Browsable(false)]
        public int Count
        {
            get
            {
                return imageMap.Length;
            }
        }

        /// <summary>
        /// <see cref="ICollection.CopyTo(Array,int)" />
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        public void CopyTo(Array array, int index)
        {
            imageMap.CopyTo(array, index);
        }

        /// <summary>
        /// <see cref="ICollection.SyncRoot" />
        /// </summary>
        /// <value>The synchronize root.</value>
        [Browsable(false)]
        public object SyncRoot
        {
            get
            {
                return imageMap;
            }
        }
        #endregion

        #region IEnumerable Members
        /// <summary>
        /// <see cref="IEnumerable.GetEnumerator()" />
        /// </summary>
        /// <returns>IEnumerator.</returns>
        public IEnumerator GetEnumerator()
        {
            return imageMap.GetEnumerator();
        }
        #endregion
    }
    #endregion
}
