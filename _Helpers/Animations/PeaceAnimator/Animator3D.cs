// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="Animator3D.cs" company="Zeroit Dev Technologies">
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
    /// The three dimensional animator class, useful for animating values
    /// created from three underlying values
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.HelperControls.AnimationHelpers.WinFormAnimation.IAnimator" />
    public class Animator3D : IAnimator
    {
        /// <summary>
        /// The known three dimensional properties of WinForm controls
        /// </summary>
        public enum KnownProperties
        {
            /// <summary>
            /// The property named 'BackColor' of the object
            /// </summary>
            BackColor,

            /// <summary>
            /// The property named 'ForeColor' of the object
            /// </summary>
            ForeColor,

            /// <summary>
            /// The selects a custom color property of the object
            /// </summary>
            Custom,
                        
        }

        /// <summary>
        /// The paths
        /// </summary>
        private readonly List<Path3D> _paths = new List<Path3D>();

        /// <summary>
        /// The callback to get invoked at the end of the animation
        /// </summary>
        protected SafeInvoker EndCallback;

        /// <summary>
        /// The callback to get invoked at each frame
        /// </summary>
        protected SafeInvoker<Float3D> FrameCallback;

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
        /// The latest depth value
        /// </summary>
        protected float? ZValue;


        /// <summary>
        /// Initializes a new instance of the <see cref="Animator3D" /> class.
        /// </summary>
        public Animator3D()
            : this(new Path3D[] {})
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator3D" /> class.
        /// </summary>
        /// <param name="fpsLimiter">Limits the maximum frames per seconds</param>
        public Animator3D(FPSLimiterKnownValues fpsLimiter)
            : this(new Path3D[] {}, fpsLimiter)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator3D" /> class.
        /// </summary>
        /// <param name="path">The path of the animation</param>
        public Animator3D(Path3D path)
            : this(new[] {path})
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator3D" /> class.
        /// </summary>
        /// <param name="path">The path of the animation</param>
        /// <param name="fpsLimiter">Limits the maximum frames per seconds</param>
        public Animator3D(Path3D path, FPSLimiterKnownValues fpsLimiter)
            : this(new[] {path}, fpsLimiter)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator3D" /> class.
        /// </summary>
        /// <param name="paths">An array containing the list of paths of the animation</param>
        public Animator3D(Path3D[] paths) : this(paths, FPSLimiterKnownValues.LimitThirty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator3D" /> class.
        /// </summary>
        /// <param name="paths">An array containing the list of paths of the animation</param>
        /// <param name="fpsLimiter">Limits the maximum frames per seconds</param>
        public Animator3D(Path3D[] paths, FPSLimiterKnownValues fpsLimiter)
        {
            HorizontalAnimator = new Animator(fpsLimiter);
            VerticalAnimator = new Animator(fpsLimiter);
            DepthAnimator = new Animator(fpsLimiter);
            Paths = paths;
        }

        /// <summary>
        /// Gets the currently active path.
        /// </summary>
        /// <value>The active path.</value>
        public Path3D ActivePath => new Path3D(
            HorizontalAnimator.ActivePath,
            VerticalAnimator.ActivePath,
            DepthAnimator.ActivePath);

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
        /// Gets the depth animator.
        /// </summary>
        /// <value>The depth animator.</value>
        public Animator DepthAnimator { get; protected set; }


        /// <summary>
        /// Gets or sets an array containing the list of paths of the animation
        /// </summary>
        /// <value>The paths.</value>
        /// <exception cref="NotSupportedException">Animation is running.</exception>
        /// <exception cref="InvalidOperationException">Animation is running</exception>
        public Path3D[] Paths
        {
            get { return _paths.ToArray(); }
            set
            {
                if (CurrentStatus == AnimatorStatus.Stopped)
                {
                    _paths.Clear();
                    _paths.AddRange(value);
                    var pathsX = new List<Path>();
                    var pathsY = new List<Path>();
                    var pathsZ = new List<Path>();
                    foreach (var p in value)
                    {
                        pathsX.Add(p.HorizontalPath);
                        pathsY.Add(p.VerticalPath);
                        pathsZ.Add(p.DepthPath);
                    }

                    HorizontalAnimator.Paths = pathsX.ToArray();
                    VerticalAnimator.Paths = pathsY.ToArray();
                    DepthAnimator.Paths = pathsZ.ToArray();
                }
                else
                {
                    throw new NotSupportedException("Animation is running.");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether animator should repeat the animation after its ending
        /// </summary>
        /// <value><c>true</c> if repeat; otherwise, <c>false</c>.</value>
        public virtual bool Repeat
        {
            get { return HorizontalAnimator.Repeat && VerticalAnimator.Repeat && DepthAnimator.Repeat; }

            set { HorizontalAnimator.Repeat = VerticalAnimator.Repeat = DepthAnimator.Repeat = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether animator should repeat the animation in reverse after its ending.
        /// </summary>
        /// <value><c>true</c> if [reverse repeat]; otherwise, <c>false</c>.</value>
        public virtual bool ReverseRepeat
        {
            get
            {
                return HorizontalAnimator.ReverseRepeat && VerticalAnimator.ReverseRepeat
                       && DepthAnimator.ReverseRepeat;
            }

            set
            {
                HorizontalAnimator.ReverseRepeat =
                    VerticalAnimator.ReverseRepeat = DepthAnimator.ReverseRepeat = value;
            }
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
                    && VerticalAnimator.CurrentStatus == AnimatorStatus.Stopped
                    && DepthAnimator.CurrentStatus == AnimatorStatus.Stopped)
                {
                    return AnimatorStatus.Stopped;
                }

                if (HorizontalAnimator.CurrentStatus == AnimatorStatus.Paused
                    && VerticalAnimator.CurrentStatus == AnimatorStatus.Paused
                    && DepthAnimator.CurrentStatus == AnimatorStatus.Paused)
                {
                    return AnimatorStatus.Paused;
                }

                if (HorizontalAnimator.CurrentStatus == AnimatorStatus.OnHold
                    && VerticalAnimator.CurrentStatus == AnimatorStatus.OnHold
                    && DepthAnimator.CurrentStatus == AnimatorStatus.OnHold)
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
                DepthAnimator.Pause();
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
                new SafeInvoker<Float3D>(
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
                new SafeInvoker<Float3D>(
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
                DepthAnimator.Resume();
            }
        }

        /// <summary>
        /// Stops the animation and resets its status, resume is no longer possible
        /// </summary>
        public virtual void Stop()
        {
            HorizontalAnimator.Stop();
            VerticalAnimator.Stop();
            DepthAnimator.Stop();
            XValue = YValue = ZValue = null;
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
        public void Play(SafeInvoker<Float3D> frameCallback)
        {
            Play(frameCallback, (SafeInvoker) null);
        }

        /// <summary>
        /// Starts the playing of the animation
        /// </summary>
        /// <param name="frameCallback">The callback to get invoked at each frame</param>
        /// <param name="endCallback">The callback to get invoked at the end of the animation</param>
        public void Play(SafeInvoker<Float3D> frameCallback, SafeInvoker endCallback)
        {
            Stop();
            FrameCallback = frameCallback;
            EndCallback = endCallback;
            IsEnded = false;
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
            DepthAnimator.Play(
                new SafeInvoker<float>(
                    value =>
                    {
                        ZValue = value;
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
            if (XValue != null && YValue != null && ZValue != null)
            {
                FrameCallback.Invoke(new Float3D(XValue.Value, YValue.Value, ZValue.Value));
            }
        }
    }
}