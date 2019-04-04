// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="SafeInvoker`1.cs" company="Zeroit Dev Technologies">
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