// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="GenericEventArgs.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents a method which can handle generic event with associated object.
    /// </summary>
    /// <typeparam name="T">Generic type which can be associated with the event.</typeparam>
    /// <param name="sender">Event source</param>
    /// <param name="tArgs">Object containing event data</param>
    public delegate void GenericEventHandler<T>(object sender, GenericEventArgs<T> tArgs);

    /// <summary>
    /// Class holding information related to generic event.
    /// </summary>
    /// <typeparam name="T">Generic type which can be associated with the event.</typeparam>
    /// <seealso cref="System.EventArgs" />
    public class GenericEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Initializes new default instance.
        /// </summary>
        public GenericEventArgs()
        {
            Value = default(T);
        }

        /// <summary>
        /// Initializes new instance with specified parameter.
        /// </summary>
        /// <param name="value">Object to be associated with the event.</param>
        public GenericEventArgs(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Object associated with the event.
        /// </summary>
        /// <value>The value.</value>
        public T Value { get; set; }
    }
}