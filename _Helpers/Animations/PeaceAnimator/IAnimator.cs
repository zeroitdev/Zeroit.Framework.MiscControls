// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="IAnimator.cs" company="Zeroit Dev Technologies">
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
using System.Linq.Expressions;

namespace Zeroit.Framework.MiscControls.HelperControls.AnimationHelpers.WinFormAnimation
{
    /// <summary>
    /// The base interface for any Animator class, custom or build-in
    /// </summary>
    public interface IAnimator
    {
        /// <summary>
        /// Gets the current status of the animation
        /// </summary>
        /// <value>The current status.</value>
        AnimatorStatus CurrentStatus { get; }

        /// <summary>
        /// Gets or sets a value indicating whether animator should repeat the animation after its ending
        /// </summary>
        /// <value><c>true</c> if repeat; otherwise, <c>false</c>.</value>
        bool Repeat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether animator should repeat the animation in reverse after its ending.
        /// </summary>
        /// <value><c>true</c> if [reverse repeat]; otherwise, <c>false</c>.</value>
        bool ReverseRepeat { get; set; }

        /// <summary>
        /// Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">The target object to change the property</param>
        /// <param name="propertyName">The name of the property to change</param>
        void Play(object targetObject, string propertyName);

        /// <summary>
        /// Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">The target object to change the property</param>
        /// <param name="propertyName">The name of the property to change</param>
        /// <param name="endCallback">The callback to get invoked at the end of the animation</param>
        void Play(object targetObject, string propertyName, SafeInvoker endCallback);

        /// <summary>
        /// Starts the playing of the animation
        /// </summary>
        /// <typeparam name="T">Any object containing a property</typeparam>
        /// <param name="targetObject">The target object to change the property</param>
        /// <param name="propertySetter">The expression that represents the property of the target object</param>
        void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter);

        /// <summary>
        /// Starts the playing of the animation
        /// </summary>
        /// <typeparam name="T">Any object containing a property</typeparam>
        /// <param name="targetObject">The target object to change the property</param>
        /// <param name="propertySetter">The expression that represents the property of the target object</param>
        /// <param name="endCallback">The callback to get invoked at the end of the animation</param>
        void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter, SafeInvoker endCallback);

        /// <summary>
        /// Resume the animation from where it paused
        /// </summary>
        void Resume();

        /// <summary>
        /// Stops the animation and resets its status, resume is no longer possible
        /// </summary>
        void Stop();

        /// <summary>
        /// Pause the animation
        /// </summary>
        void Pause();
    }
}