// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="IAnimator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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