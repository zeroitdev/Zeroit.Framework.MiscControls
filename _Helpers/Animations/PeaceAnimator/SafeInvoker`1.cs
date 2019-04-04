// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="SafeInvoker`1.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.MiscControls.HelperControls.AnimationHelpers.WinFormAnimation
{
    /// <summary>
    /// The safe invoker class is a delegate reference holder that always
    /// execute them in the correct thread based on the passed control.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Zeroit.Framework.MiscControls.HelperControls.AnimationHelpers.WinFormAnimation.SafeInvoker" />
    public class SafeInvoker<T> : SafeInvoker
    {
        /// <summary>
        /// Initializes a new instance of the SafeInvoker class.
        /// </summary>
        /// <param name="action">The callback to be invoked</param>
        /// <param name="targetControl">The control to be used to invoke the callback in UI thread</param>
        public SafeInvoker(Action<T> action, object targetControl) : base(action, targetControl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SafeInvoker class.
        /// </summary>
        /// <param name="action">The callback to be invoked</param>
        public SafeInvoker(Action<T> action) : this(action, null)
        {
        }

        /// <summary>
        /// Invoke the contained callback with the specified value as the parameter
        /// </summary>
        /// <param name="value">The value.</param>
        public void Invoke(T value)
        {
            Invoke((object) value);
        }
    }
}