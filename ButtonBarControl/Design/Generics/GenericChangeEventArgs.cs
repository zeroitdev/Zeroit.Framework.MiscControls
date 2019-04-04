// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="GenericChangeEventArgs.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents a method which can be used for Change events which will have <see cref="GenericChangeEventArgs{T}.OldValue" />, <see cref="GenericChangeEventArgs{T}.NewValue" /> and <see cref="CancelEventArgs.Cancel" />.
    /// </summary>
    /// <typeparam name="T">Type of object to be used for.</typeparam>
    /// <param name="sender">sender of Event.</param>
    /// <param name="e">Object containing event data</param>
    public delegate void GenericValueChangingHandler<T>(object sender, GenericChangeEventArgs<T> e);

    /// <summary>
    /// Place holder for change event containing Old and New Value.
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    /// <seealso cref="System.ComponentModel.CancelEventArgs" />
    public class GenericChangeEventArgs<T> : CancelEventArgs
    {
        /// <summary>
        /// The old value
        /// </summary>
        private readonly T oldValue;

        /// <summary>
        /// Initializes new instance with specified parameter.
        /// </summary>
        /// <param name="oldValue">Old Value.</param>
        /// <param name="newValue">New Value</param>
        public GenericChangeEventArgs(T oldValue, T newValue) : base(false)
        {
            this.oldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        /// Initializes new instance with specified parameter.
        /// </summary>
        /// <param name="oldValue">Old Value.</param>
        /// <param name="newValue">New Value</param>
        /// <param name="cancel">Cancel flag which can be used to stop event execution.</param>
        public GenericChangeEventArgs(T oldValue, T newValue, bool cancel) : base(cancel)
        {
            this.oldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        /// Gets old value which is being modified.
        /// </summary>
        /// <value>The old value.</value>
        public T OldValue
        {
            get { return oldValue; }
        }

        /// <summary>
        /// Gets or Sets new Value which is being set for old value.
        /// </summary>
        /// <value>The new value.</value>
        public T NewValue { get; set; }
    }
}