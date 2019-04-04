// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="GenericEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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