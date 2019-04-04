// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="SafeInvoker.cs" company="Zeroit Dev Technologies">
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
using System.Reflection;
using System.Threading;

namespace Zeroit.Framework.MiscControls.HelperControls.AnimationHelpers.WinFormAnimation
{
    /// <summary>
    /// The safe invoker class is a delegate reference holder that always
    /// execute them in the correct thread based on the passed control.
    /// </summary>
    public class SafeInvoker
    {
        /// <summary>
        /// The invoke method
        /// </summary>
        private MethodInfo _invokeMethod;

        /// <summary>
        /// The invoke required property
        /// </summary>
        private PropertyInfo _invokeRequiredProperty;
        /// <summary>
        /// The target control
        /// </summary>
        private object _targetControl;

        /// <summary>
        /// Initializes a new instance of the SafeInvoker class.
        /// </summary>
        /// <param name="action">The callback to be invoked</param>
        /// <param name="targetControl">The control to be used to invoke the callback in UI thread</param>
        public SafeInvoker(Action action, object targetControl) : this((Delegate) action, targetControl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SafeInvoker class.
        /// </summary>
        /// <param name="action">The callback to be invoked</param>
        /// <param name="targetControl">The control to be used to invoke the callback in UI thread</param>
        protected SafeInvoker(Delegate action, object targetControl)
        {
            UnderlyingDelegate = action;
            if (targetControl != null)
            {
                TargetControl = targetControl;
            }
        }

        /// <summary>
        /// Initializes a new instance of the SafeInvoker class.
        /// </summary>
        /// <param name="action">The callback to be invoked</param>
        public SafeInvoker(Action action) : this(action, null)
        {
        }

        /// <summary>
        /// Gets or sets the reference to the control thats going to be used to invoke the callback in UI thread
        /// </summary>
        /// <value>The target control.</value>
        protected object TargetControl
        {
            get { return _targetControl; }
            set
            {
                _invokeRequiredProperty = value.GetType()
                    .GetProperty("InvokeRequired", BindingFlags.Instance | BindingFlags.Public);
                _invokeMethod = value.GetType()
                    .GetMethod(
                        "Invoke",
                        BindingFlags.Instance | BindingFlags.Public,
                        Type.DefaultBinder,
                        new[] {typeof (Delegate)},
                        null);
                if (_invokeRequiredProperty != null && _invokeMethod != null)
                {
                    _targetControl = value;
                }
            }
        }


        /// <summary>
        /// Gets the reference to the callback to be invoked
        /// </summary>
        /// <value>The underlying delegate.</value>
        protected Delegate UnderlyingDelegate { get; }

        /// <summary>
        /// Invoke the contained callback
        /// </summary>
        public virtual void Invoke()
        {
            Invoke(null);
        }

        /// <summary>
        /// Invoke the referenced callback
        /// </summary>
        /// <param name="value">The argument to send to the callback</param>
        protected void Invoke(object value)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(
                    state =>
                    {
                        if (TargetControl != null && (bool) _invokeRequiredProperty.GetValue(TargetControl, null))
                        {
                            _invokeMethod.Invoke(
                                TargetControl,
                                new object[]
                                {
                                    new Action(
                                        () => UnderlyingDelegate.DynamicInvoke(value != null ? new[] {value} : null))
                                });
                            return;
                        }
                        UnderlyingDelegate.DynamicInvoke(value != null ? new[] {value} : null);
                    });
            }
            catch
            {
                // ignored
            }
        }
    }
}