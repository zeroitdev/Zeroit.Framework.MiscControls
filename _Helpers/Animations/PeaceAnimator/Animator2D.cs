// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="Animator2D.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Zeroit.Framework.MiscControls.HelperControls.AnimationHelpers.WinFormAnimation
{
    /// <summary>
    /// The two dimensional animator class, useful for animating values
    /// created from two underlying values
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.HelperControls.AnimationHelpers.WinFormAnimation.IAnimator" />
    public class Animator2D : IAnimator
    {
        /// <summary>
        /// The known two dimensional properties of WinForm controls
        /// </summary>
        public enum KnownProperties
        {
            /// <summary>
            /// The property named 'Size' of the object
            /// </summary>
            Size,

            /// <summary>
            /// The property named 'Location' of the object
            /// </summary>
            Location
        }

        /// <summary>
        /// The paths
        /// </summary>
        private readonly List<Path2D> _paths = new List<Path2D>();


        /// <summary>
        /// The callback to get invoked at the end of the animation
        /// </summary>
        protected SafeInvoker EndCallback;

        /// <summary>
        /// The callback to get invoked at each frame
        /// </summary>
        protected SafeInvoker<Float2D> FrameCallback;

        /// <summary>
        /// A boolean value indicating if the EndInvoker already invoked
        /// </summary>
        protected bool IsEnded;

        /// <summary>
        /// The target object to change the property of
        /// </summary>
        protected object TargetObject;

        /// <summary>
        /// The latest horizontal value
        /// </summary>
        protected float? XValue;

        /// <summary>
        /// The latest vertical value
        /// </summary>
        protected float? YValue;


        /// <summary>
        /// Initializes a new instance of the <see cref="Animator2D" /> class.
        /// </summary>
        public Animator2D()
            : this(new Path2D[] {})
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator2D" /> class.
        /// </summary>
        /// <param name="fpsLimiter">Limits the maximum frames per seconds</param>
        public Animator2D(FPSLimiterKnownValues fpsLimiter)
            : this(new Path2D[] {}, fpsLimiter)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator2D" /> class.
        /// </summary>
        /// <param name="path">The path of the animation</param>
        public Animator2D(Path2D path)
            : this(new[] {path})
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator2D" /> class.
        /// </summary>
        /// <param name="path">The path of the animation</param>
        /// <param name="fpsLimiter">Limits the maximum frames per seconds</param>
        public Animator2D(Path2D path, FPSLimiterKnownValues fpsLimiter)
            : this(new[] {path}, fpsLimiter)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Animator2D" /> class.
        /// </summary>
        /// <param name="paths">An array containing the list of paths of the animation</param>
        public Animator2D(Path2D[] paths) : this(paths, FPSLimiterKnownValues.LimitThirty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator2D" /> class.
        /// </summary>
        /// <param name="paths">An array containing the list of paths of the animation</param>
        /// <param name="fpsLimiter">Limits the maximum frames per seconds</param>
        public Animator2D(Path2D[] paths, FPSLimiterKnownValues fpsLimiter)
        {
            HorizontalAnimator = new Animator(fpsLimiter);
            VerticalAnimator = new Animator(fpsLimiter);
            Paths = paths;
        }

        /// <summary>
        /// Gets the currently active path.
        /// </summary>
        /// <value>The active path.</value>
        public Path2D ActivePath => new Path2D(HorizontalAnimator.ActivePath, VerticalAnimator.ActivePath);

        /// <summary>
        /// Gets the horizontal animator.
        /// </summary>
        /// <value>The horizontal animator.</value>
        public Animator HorizontalAnimator { get; protected set; }

        /// <summary>
        /// Gets the vertical animator.
        /// </summary>
        /// <value>The vertical animator.</value>
        public Animator VerticalAnimator { get; protected set; }

        /// <summary>
        /// Gets or sets an array containing the list of paths of the animation
        /// </summary>
        /// <value>The paths.</value>
        /// <exception cref="InvalidOperationException">Animation is running</exception>
        public Path2D[] Paths
        {
            get { return _paths.ToArray(); }
            set
            {
                if (CurrentStatus == AnimatorStatus.Stopped)
                {
                    _paths.Clear();
                    _paths.AddRange(value);
                    var pathsH = new List<Path>();
                    var pathsV = new List<Path>();
                    foreach (var p in value)
                    {
                        pathsH.Add(p.HorizontalPath);
                        pathsV.Add(p.VerticalPath);
                    }
                    HorizontalAnimator.Paths = pathsH.ToArray();
                    VerticalAnimator.Paths = pathsV.ToArray();
                }
                else
                {
                    throw new InvalidOperationException("Animation is running.");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether animator should repeat the animation after its ending
        /// </summary>
        /// <value><c>true</c> if repeat; otherwise, <c>false</c>.</value>
        public virtual bool Repeat
        {
            get { return HorizontalAnimator.Repeat && VerticalAnimator.Repeat; }

            set { HorizontalAnimator.Repeat = VerticalAnimator.Repeat = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether animator should repeat the animation in reverse after its ending.
        /// </summary>
        /// <value><c>true</c> if [reverse repeat]; otherwise, <c>false</c>.</value>
        public virtual bool ReverseRepeat
        {
            get { return HorizontalAnimator.ReverseRepeat && VerticalAnimator.ReverseRepeat; }

            set { HorizontalAnimator.ReverseRepeat = VerticalAnimator.ReverseRepeat = value; }
        }

        /// <summary>
        /// Gets the current status of the animation
        /// </summary>
        /// <value>The current status.</value>
        public virtual AnimatorStatus CurrentStatus
        {
            get
            {
                if (HorizontalAnimator.CurrentStatus == AnimatorStatus.Stopped
                    && VerticalAnimator.CurrentStatus == AnimatorStatus.Stopped)
                {
                    return AnimatorStatus.Stopped;
                }

                if (HorizontalAnimator.CurrentStatus == AnimatorStatus.Paused
                    && VerticalAnimator.CurrentStatus == AnimatorStatus.Paused)
                {
                    return AnimatorStatus.Paused;
                }

                if (HorizontalAnimator.CurrentStatus == AnimatorStatus.OnHold
                    && VerticalAnimator.CurrentStatus == AnimatorStatus.OnHold)
                {
                    return AnimatorStatus.OnHold;
                }

                return AnimatorStatus.Playing;
            }
        }

        /// <summary>
        /// Pause the animation
        /// </summary>
        public virtual void Pause()
        {
            if (CurrentStatus == AnimatorStatus.OnHold || CurrentStatus == AnimatorStatus.Playing)
            {
                HorizontalAnimator.Pause();
                VerticalAnimator.Pause();
            }
        }

        /// <summary>
        /// Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">The target object to change the property</param>
        /// <param name="propertyName">The name of the property to change</param>
        public virtual void Play(object targetObject, string propertyName)
        {
            Play(targetObject, propertyName, null);
        }

        /// <summary>
        /// Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">The target object to change the property</param>
        /// <param name="propertyName">The name of the property to change</param>
        /// <param name="endCallback">The callback to get invoked at the end of the animation</param>
        public virtual void Play(object targetObject, string propertyName, SafeInvoker endCallback)
        {
            TargetObject = targetObject;
            var prop = TargetObject.GetType()
                .GetProperty(
                    propertyName,
                    BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance |
                    BindingFlags.SetProperty);
            if (prop == null) return;

            Play(
                new SafeInvoker<Float2D>(
                    value =>
                        prop.SetValue(TargetObject, Convert.ChangeType(value, prop.PropertyType), null),
                    TargetObject),
                endCallback);
        }

        /// <summary>
        /// Starts the playing of the animation
        /// </summary>
        /// <typeparam name="T">Any object containing a property</typeparam>
        /// <param name="targetObject">The target object to change the property</param>
        /// <param name="propertySetter">The expression that represents the property of the target object</param>
        public virtual void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter)
        {
            Play(targetObject, propertySetter, null);
        }

        /// <summary>
        /// Starts the playing of the animation
        /// </summary>
        /// <typeparam name="T">Any object containing a property</typeparam>
        /// <param name="targetObject">The target object to change the property</param>
        /// <param name="propertySetter">The expression that represents the property of the target object</param>
        /// <param name="endCallback">The callback to get invoked at the end of the animation</param>
        /// <exception cref="ArgumentException">propertySetter</exception>
        public virtual void Play<T>(T targetObject, Expression<Func<T, object>> propertySetter, SafeInvoker endCallback)
        {
            if (propertySetter == null)
                return;
            TargetObject = targetObject;

            var property =
                ((propertySetter.Body as MemberExpression) ??
                 (((UnaryExpression) propertySetter.Body).Operand as MemberExpression))?.Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException(nameof(propertySetter));
            }

            Play(
                new SafeInvoker<Float2D>(
                    value =>
                        property.SetValue(TargetObject, Convert.ChangeType(value, property.PropertyType), null),
                    TargetObject),
                endCallback);
        }

        /// <summary>
        /// Resume the animation from where it paused
        /// </summary>
        public virtual void Resume()
        {
            if (CurrentStatus == AnimatorStatus.Paused)
            {
                HorizontalAnimator.Resume();
                VerticalAnimator.Resume();
            }
        }

        /// <summary>
        /// Stops the animation and resets its status, resume is no longer possible
        /// </summary>
        public virtual void Stop()
        {
            HorizontalAnimator.Stop();
            VerticalAnimator.Stop();
            XValue = YValue = null;
        }

        /// <summary>
        /// Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">The target object to change the property</param>
        /// <param name="property">The property to change</param>
        public void Play(object targetObject, KnownProperties property)
        {
            Play(targetObject, property, null);
        }


        /// <summary>
        /// Starts the playing of the animation
        /// </summary>
        /// <param name="targetObject">The target object to change the property</param>
        /// <param name="property">The property to change</param>
        /// <param name="endCallback">The callback to get invoked at the end of the animation</param>
        public void Play(object targetObject, KnownProperties property, SafeInvoker endCallback)
        {
            Play(targetObject, property.ToString(), endCallback);
        }

        /// <summary>
        /// Starts the playing of the animation
        /// </summary>
        /// <param name="frameCallback">The callback to get invoked at each frame</param>
        public void Play(SafeInvoker<Float2D> frameCallback)
        {
            Play(frameCallback, (SafeInvoker) null);
        }

        /// <summary>
        /// Starts the playing of the animation
        /// </summary>
        /// <param name="frameCallback">The callback to get invoked at each frame</param>
        /// <param name="endCallback">The callback to get invoked at the end of the animation</param>
        public void Play(SafeInvoker<Float2D> frameCallback, SafeInvoker endCallback)
        {
            Stop();
            FrameCallback = frameCallback;
            EndCallback = endCallback;
            HorizontalAnimator.Play(
                new SafeInvoker<float>(
                    value =>
                    {
                        XValue = value;
                        InvokeSetter();
                    }),
                new SafeInvoker(InvokeFinisher));
            VerticalAnimator.Play(
                new SafeInvoker<float>(
                    value =>
                    {
                        YValue = value;
                        InvokeSetter();
                    }),
                new SafeInvoker(InvokeFinisher));
        }

        /// <summary>
        /// Invokes the finisher.
        /// </summary>
        private void InvokeFinisher()
        {
            if (EndCallback != null && !IsEnded)
            {
                lock (EndCallback)
                {
                    if (CurrentStatus == AnimatorStatus.Stopped)
                    {
                        IsEnded = true;
                        EndCallback.Invoke();
                    }
                }
            }
        }

        /// <summary>
        /// Invokes the setter.
        /// </summary>
        private void InvokeSetter()
        {
            if (XValue != null && YValue != null)
            {
                FrameCallback.Invoke(new Float2D(XValue.Value, YValue.Value));
            }
        }
    }
}