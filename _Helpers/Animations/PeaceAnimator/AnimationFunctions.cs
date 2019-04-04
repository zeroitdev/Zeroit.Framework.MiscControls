// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="AnimationFunctions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.MiscControls.HelperControls.AnimationHelpers.WinFormAnimation
{
    /// <summary>
    /// The functions gallery for animation
    /// </summary>
    public static class AnimationFunctions
    {

        /// <summary>
        /// The base delegate for defining new animation functions.
        /// </summary>
        /// <param name="time">The time of the animation.</param>
        /// <param name="beginningValue">The starting value.</param>
        /// <param name="changeInValue">The different between starting and ending value.</param>
        /// <param name="duration">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public delegate float Function(float time, float beginningValue, float changeInValue, float duration);

        /// <summary>
        /// Returns a function delegate based on the the passed known animation function
        /// </summary>
        /// <param name="knownFunction">The animation function</param>
        /// <returns>Animation fucntion delegate</returns>
        /// <exception cref="ArgumentOutOfRangeException">knownFunction - The passed animation function is unknown.</exception>
        public static Function FromKnown(KnownAnimationFunctions knownFunction)
        {
            switch (knownFunction)
            {
                case KnownAnimationFunctions.BounceEaseIn:
                    return BounceEaseIn;
                case KnownAnimationFunctions.BounceEaseInOut:
                    return BounceEaseInOut;
                case KnownAnimationFunctions.BounceEaseOut:
                    return BounceEaseOut;
                case KnownAnimationFunctions.BounceEaseOutIn:
                    return BounceEaseOutIn;
                case KnownAnimationFunctions.CubicEaseIn:
                    return CubicEaseIn;
                case KnownAnimationFunctions.CubicEaseInOut:
                    return CubicEaseInOut;
                case KnownAnimationFunctions.CubicEaseOut:
                    return CubicEaseOut;
                case KnownAnimationFunctions.Liner:
                    return Liner;
                case KnownAnimationFunctions.CircularEaseInOut:
                    return CircularEaseInOut;
                case KnownAnimationFunctions.CircularEaseIn:
                    return CircularEaseIn;
                case KnownAnimationFunctions.CircularEaseOut:
                    return CircularEaseOut;
                case KnownAnimationFunctions.QuadraticEaseIn:
                    return QuadraticEaseIn;
                case KnownAnimationFunctions.QuadraticEaseOut:
                    return QuadraticEaseOut;
                case KnownAnimationFunctions.QuadraticEaseInOut:
                    return QuadraticEaseInOut;
                case KnownAnimationFunctions.QuarticEaseIn:
                    return QuarticEaseIn;
                case KnownAnimationFunctions.QuarticEaseOut:
                    return QuarticEaseOut;
                case KnownAnimationFunctions.QuarticEaseInOut:
                    return QuarticEaseInOut;
                case KnownAnimationFunctions.QuinticEaseInOut:
                    return QuinticEaseInOut;
                case KnownAnimationFunctions.QuinticEaseIn:
                    return QuinticEaseIn;
                case KnownAnimationFunctions.QuinticEaseOut:
                    return QuinticEaseOut;
                case KnownAnimationFunctions.SinusoidalEaseIn:
                    return SinusoidalEaseIn;
                case KnownAnimationFunctions.SinusoidalEaseOut:
                    return SinusoidalEaseOut;
                case KnownAnimationFunctions.SinusoidalEaseInOut:
                    return SinusoidalEaseInOut;
                case KnownAnimationFunctions.ExponentialEaseIn:
                    return ExponentialEaseIn;
                case KnownAnimationFunctions.ExponentialEaseOut:
                    return ExponentialEaseOut;
                case KnownAnimationFunctions.ExponentialEaseInOut:
                    return ExponentialEaseInOut;

                    //Zeroit Additions
                //case KnownAnimationFunctions.Linear:
                //    return Linear;
                //case KnownAnimationFunctions.EaseIn:
                //    return EaseIn;
                //case KnownAnimationFunctions.EaseOut:
                //    return EaseOut;
                //case KnownAnimationFunctions.EaseInAndOut:
                //    return EaseInAndOut;
                case KnownAnimationFunctions.LinearTween:
                    return LinearTween;
                case KnownAnimationFunctions.EaseInQuad:
                    return EaseInQuad;
                case KnownAnimationFunctions.EaseOutQuad:
                    return EaseOutQuad;
                case KnownAnimationFunctions.EaseInOutQuad:
                    return EaseInOutQuad;
                case KnownAnimationFunctions.EaseInCubic:
                    return EaseInCubic;
                case KnownAnimationFunctions.EaseOutCubic:
                    return EaseOutCubic;
                case KnownAnimationFunctions.EaseInOutCubic:
                    return EaseInOutCubic;
                case KnownAnimationFunctions.EaseInQuart:
                    return EaseInQuart;
                case KnownAnimationFunctions.EaseOutQuart:
                    return EaseOutQuart;
                case KnownAnimationFunctions.EaseInOutQuart:
                    return EaseInOutQuart;
                case KnownAnimationFunctions.EaseInQuint:
                    return EaseInQuint;
                case KnownAnimationFunctions.EaseOutQuint:
                    return EaseOutQuint;
                case KnownAnimationFunctions.EaseInOutQuint:
                    return EaseInOutQuint;
                case KnownAnimationFunctions.EaseInSine:
                    return EaseInSine;
                case KnownAnimationFunctions.EaseOutSine:
                    return EaseOutSine;
                case KnownAnimationFunctions.EaseInOutSine:
                    return EaseInOutSine;
                case KnownAnimationFunctions.EaseInExpo:
                    return EaseInExpo;
                case KnownAnimationFunctions.EaseOutExpo:
                    return EaseOutExpo;
                case KnownAnimationFunctions.EaseInOutExpo:
                    return EaseInOutExpo;
                case KnownAnimationFunctions.EaseInCirc:
                    return EaseInCirc;
                case KnownAnimationFunctions.EaseOutCirc:
                    return EaseOutCirc;
                case KnownAnimationFunctions.EaseInOutCirc:
                    return EaseInOutCirc;
                case KnownAnimationFunctions.ElasticEaseOut:
                    return ElasticEaseOut;
                case KnownAnimationFunctions.ElasticEaseIn:
                    return ElasticEaseIn;
                case KnownAnimationFunctions.ElasticEaseInOut:
                    return ElasticEaseInOut;
                case KnownAnimationFunctions.ElasticEaseOutIn:
                    return ElasticEaseOutIn;
                case KnownAnimationFunctions.BounceEaseOutV2:
                    return BounceEaseOutV2;
                case KnownAnimationFunctions.BounceEaseInV2:
                    return BounceEaseInV2;
                case KnownAnimationFunctions.BounceEaseInOutV2:
                    return BounceEaseInOutV2;
                case KnownAnimationFunctions.BounceEaseOutInV2:
                    return BounceEaseOutInV2;
                case KnownAnimationFunctions.BackEaseOut:
                    return BackEaseOut;
                case KnownAnimationFunctions.BackEaseIn:
                    return BackEaseIn;
                case KnownAnimationFunctions.BackEaseInOut:
                    return BackEaseInOut;
                case KnownAnimationFunctions.BackEaseOutIn:
                    return BackEaseOutIn;
                default:
                    throw new ArgumentOutOfRangeException(nameof(knownFunction), knownFunction,
                        "The passed animation function is unknown.");
            }
        }


        /// <summary>
        /// The cubic ease-in animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float CubicEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c*t*t*t + b;
        }

        /// <summary>
        /// The cubic ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float CubicEaseInOut(float t, float b, float c, float d)
        {
            t /= d/2;
            if (t < 1)
                return c/2*t*t*t + b;

            t -= 2;
            return c/2*(t*t*t + 2) + b;
        }

        /// <summary>
        /// The cubic ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float CubicEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return c*(t*t*t + 1) + b;
        }

        /// <summary>
        /// The liner animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float Liner(float t, float b, float c, float d)
        {
            return c*t/d + b;
        }

        /// <summary>
        /// The circular ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float CircularEaseInOut(float t, float b, float c, float d)
        {
            t /= d/2;
            if (t < 1)
                return (float) (-c/2*(Math.Sqrt(1 - t*t) - 1) + b);
            t -= 2;
            return (float) (c/2*(Math.Sqrt(1 - t*t) + 1) + b);
        }


        /// <summary>
        /// The circular ease-in animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float CircularEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return (float) (-c*(Math.Sqrt(1 - t*t) - 1) + b);
        }


        /// <summary>
        /// The circular ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float CircularEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (float) (c*Math.Sqrt(1 - t*t) + b);
        }


        /// <summary>
        /// The quadratic ease-in animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float QuadraticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c*t*t + b;
        }


        /// <summary>
        /// The quadratic ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float QuadraticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            return -c*t*(t - 2) + b;
        }


        /// <summary>
        /// The quadratic ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float QuadraticEaseInOut(float t, float b, float c, float d)
        {
            t /= d/2;
            if (t < 1) return c/2*t*t + b;
            t--;
            return -c/2*(t*(t - 2) - 1) + b;
        }

        /// <summary>
        /// The quartic ease-in animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float QuarticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c*t*t*t*t + b;
        }

        /// <summary>
        /// The quartic ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float QuarticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return -c*(t*t*t*t - 1) + b;
        }

        /// <summary>
        /// The quartic ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float QuarticEaseInOut(float t, float b, float c, float d)
        {
            t /= d/2;
            if (t < 1) return c/2*t*t*t*t + b;
            t -= 2;
            return -c/2*(t*t*t*t - 2) + b;
        }

        /// <summary>
        /// The quintic ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float QuinticEaseInOut(float t, float b, float c, float d)
        {
            t /= d/2;
            if (t < 1) return c/2*t*t*t*t*t + b;
            t -= 2;
            return c/2*(t*t*t*t*t + 2) + b;
        }

        /// <summary>
        /// The quintic ease-in animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float QuinticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c*t*t*t*t*t + b;
        }

        /// <summary>
        /// The quintic ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float QuinticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return c*(t*t*t*t*t + 1) + b;
        }

        /// <summary>
        /// The sinusoidal ease-in animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float SinusoidalEaseIn(float t, float b, float c, float d)
        {
            return (float) (-c*Math.Cos(t/d*(Math.PI/2)) + c + b);
        }

        /// <summary>
        /// The sinusoidal ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float SinusoidalEaseOut(float t, float b, float c, float d)
        {
            return (float) (c*Math.Sin(t/d*(Math.PI/2)) + b);
        }

        /// <summary>
        /// The sinusoidal ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float SinusoidalEaseInOut(float t, float b, float c, float d)
        {
            return (float) (-c/2*(Math.Cos(Math.PI*t/d) - 1) + b);
        }

        /// <summary>
        /// The exponential ease-in animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float ExponentialEaseIn(float t, float b, float c, float d)
        {
            return (float) (c*Math.Pow(2, 10*(t/d - 1)) + b);
        }

        /// <summary>
        /// The exponential ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float ExponentialEaseOut(float t, float b, float c, float d)
        {
            return (float) (c*(-Math.Pow(2, -10*t/d) + 1) + b);
        }


        /// <summary>
        /// The exponential ease-in and ease-out animation function.
        /// </summary>
        /// <param name="t">The time of the animation.</param>
        /// <param name="b">The starting value.</param>
        /// <param name="c">The different between starting and ending value.</param>
        /// <param name="d">The duration of the animations.</param>
        /// <returns>The calculated current value of the animation</returns>
        public static float ExponentialEaseInOut(float t, float b, float c, float d)
        {
            t /= d/2;
            if (t < 1)
                return (float) (c/2*Math.Pow(2, 10*(t - 1)) + b);
            t--;
            return (float) (c/2*(-Math.Pow(2, -10*t) + 2) + b);
        }

        #region Bounce

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float BounceEaseOut(float t, float b, float c, float d)
        {
            if ((t /= d) < (1 / 2.75))
                return c * (7.5625f * t * t) + b;

            if (t < (2 / 2.75))
                return c * (7.5625f * (t -= (1.5f / 2.75f)) * t + .75f) + b;

            if (t < (2.5 / 2.75))
                return c * (7.5625f * (t -= (2.25f / 2.75f)) * t + .9375f) + b;

            return c * (7.5625f * (t -= (2.625f / 2.75f)) * t + .984375f) + b;
        }

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float BounceEaseIn(float t, float b, float c, float d)
        {
            return c - BounceEaseOut(d - t, 0, c, d) + b;
        }

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float BounceEaseInOut(float t, float b, float c, float d)
        {
            if (t < d / 2)
                return BounceEaseIn(t * 2, 0, c, d) * .5f + b;

            return BounceEaseOut(t * 2 - d, 0, c, d) * .5f + c * .5f + b;
        }

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float BounceEaseOutIn(float t, float b, float c, float d)
        {
            if (t < d / 2)
                return BounceEaseOut(t * 2, b, c / 2, d);

            return BounceEaseIn((t * 2) - d, b + c / 2, c / 2, d);
        }


        #endregion

        #region Zeroit Easing Functions

        #region Linear Easing Functions

        #region LinearTween
        /// <summary>
        /// Simple linear tweening - no easing, no acceleration.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float LinearTween(float t, float b, float c, float d)
        {
            
            
            
            return (c * t) / (d + b);
        }
        #endregion

        #endregion

        #region Quadratic Easing Functions

        #region EaseInQuad
        /// <summary>
        /// Quadratic easing in - accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInQuad(float t, float b, float c, float d)
        {
             
            t /= d;
            return c * t * t + b;

        }
        #endregion

        #region EaseOutQuad
        /// <summary>
        /// Quadratic easing out - decelerating to zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseOutQuad(float t, float b, float c, float d)
        {
            

            t /= d;
            return -c * t * (t - 2) + b;

        }
        #endregion

        #region EaseInOutQuad
        /// <summary>
        /// Quadratic easing in/out - acceleration until halfway, then deceleration
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInOutQuad(float t, float b, float c, float d)
        {
            
            t /= d / 2;
            if (t < 1) return c / 2 * t * t + b;
            t--;
            return -c / 2 * (t * (t - 2) - 1) + b;

        }
        #endregion
        #endregion

        #region Cubic Easing Functions

        #region EaseInCubic
        /// <summary>
        /// Cubic easing in - accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInCubic(float t, float b, float c, float d)
        {
            
            
            

            t /= d;
            return c * t * t * t + b;

        }
        #endregion

        #region EaseOutCubic
        /// <summary>
        /// Cubic easing out - decelerating to zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseOutCubic(float t, float b, float c, float d)
        {
            
            
            

            t /= d;
            t--;
            return c * (t * t * t + 1) + b;

        }
        #endregion

        #region EaseInOutCubic
        /// <summary>
        /// Cubic easing in/out - acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInOutCubic(float t, float b, float c, float d)
        {
            
            
            

            t /= d / 2;
            if (t < 1) return c / 2 * t * t * t + b;
            t -= 2;
            return c / 2 * (t * t * t + 2) + b;

        }
        #endregion

        #endregion

        #region Quartic Easing Functions

        #region EaseInQuart
        /// <summary>
        /// Quartic easing in - accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInQuart(float t, float b, float c, float d)
        {
            
            
            

            t /= d;
            return c * t * t * t * t + b;

        }
        #endregion

        #region EaseOutQuart
        /// <summary>
        /// Quartic easing out - decelerating to zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseOutQuart(float t, float b, float c, float d)
        {
            
            
            

            t /= d;
            t--;
            return -c * (t * t * t * t - 1) + b;

        }
        #endregion

        #region EaseInOutQuart
        /// <summary>
        /// Quartic easing in/out - acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInOutQuart(float t, float b, float c, float d)
        {
            
            
            

            t /= d / 2;
            if (t < 1) return c / 2 * t * t * t * t + b;
            t -= 2;
            return -c / 2 * (t * t * t * t - 2) + b;

        }
        #endregion

        #endregion

        #region Quintic Easing Functions

        #region EaseInQuint
        /// <summary>
        /// Quintic easing in - accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInQuint(float t, float b, float c, float d)
        {
            
            
            

            t /= d;
            return c * t * t * t * t * t + b;

        }
        #endregion

        #region EaseOutQuint
        /// <summary>
        /// Quintic easing out - decelerating to zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseOutQuint(float t, float b, float c, float d)
        {
            
            
            

            t /= d;
            t--;
            return c * (t * t * t * t * t + 1) + b;

        }
        #endregion

        #region EaseInOutQuint
        /// <summary>
        /// Quintic easing in/out - acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInOutQuint(float t, float b, float c, float d)
        {
            
            
            

            t /= d / 2;
            if (t < 1) return c / 2 * t * t * t * t * t + b;
            t -= 2;
            return c / 2 * (t * t * t * t * t + 2) + b;

        }
        #endregion

        #endregion

        #region Sinusoidal Easing Functions

        #region EaseInSine
        /// <summary>
        /// Sinusoidal easing in - accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInSine(float t, float b, float c, float d)
        {
            
            
            

            return -c * (float)Math.Cos(t / d * (Math.PI / 2)) + c + b;

        }
        #endregion

        #region EaseOutSine
        /// <summary>
        /// Sinusoidal easing out - decelerating to zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseOutSine(float t, float b, float c, float d)
        {
            
            
            

            return c * (float)(Math.Sin(t / d * (Math.PI / 2))) + b;

        }
        #endregion

        #region EaseInOutSine
        /// <summary>
        /// sinusoidal easing in/out - accelerating until halfway, then decelerating.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInOutSine(float t, float b, float c, float d)
        {
            
            
            

            return -c / 2 * (float)(Math.Cos(Math.PI * t / d) - 1) + b;

        }
        #endregion

        #endregion

        #region Exponential Easing Functions

        #region EaseInExpo
        /// <summary>
        /// Exponential easing in - accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInExpo(float t, float b, float c, float d)
        {
            
            
            

            return c * (float)Math.Pow(2, 10 * (t / d - 1)) + b;

        }
        #endregion

        #region EaseOutExpo
        /// <summary>
        /// exponential easing out - decelerating to zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseOutExpo(float t, float b, float c, float d)
        {
            
            
            

            return c * (float)(-Math.Pow(2, -10 * t / d) + 1) + b;

        }
        #endregion

        #region EaseInOutExpo
        /// <summary>
        /// Exponential easing in/out - accelerating until halfway, then decelerating.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInOutExpo(float t, float b, float c, float d)
        {
            
            
            

            t /= d / 2;
            if (t < 1) return c / 2 * (float)Math.Pow(2, 10 * (t - 1)) + b;
            t--;
            return c / 2 * (float)(-Math.Pow(2, -10 * t) + 2) + b;

        }
        #endregion

        #endregion

        #region Circular Easing Functions

        #region EaseInCirc
        /// <summary>
        /// circular easing in - accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInCirc(float t, float b, float c, float d)
        {
            
            
            

            t /= d;
            return -c * (float)(Math.Sqrt(1 - t * t) - 1) + b;

        }
        #endregion

        #region EaseOutCirc
        /// <summary>
        /// Circular easing out - decelerating to zero velocity.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseOutCirc(float t, float b, float c, float d)
        {
            
            
            

            t /= d;
            t--;
            return c * (float)Math.Sqrt(1 - t * t) + b;

        }
        #endregion

        #region EaseInOutCirc
        /// <summary>
        /// circular easing in/out - acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Input between 0 and 1.</param>
        /// <param name="b">Start Value. Input between 0 and 1.</param>
        /// <param name="c">Change in Value. Input between 0 and 1.</param>
        /// <param name="d">d. Input between 0 and 1.</param>
        /// <returns>Output between 0 and 1.</returns>
        public static float EaseInOutCirc(float t, float b, float c, float d)
        {
            
            
            

            t /= d / 2;
            if (t < 1) return -c / 2 * (float)(Math.Sqrt(1 - t * t) - 1) + b;
            t -= 2;
            return c / 2 * (float)(Math.Sqrt(1 - t * t) + 1) + b;
        }
        #endregion

        #endregion

        #region Elastic

        #region ElasticEaseOut
        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float ElasticEaseOut(float t, float b, float c, float d)
        {
            
            
            

            if ((t /= d) == 1)
                return b + c;

            float p = (d * .3f);
            float s = p / 4;

            return (c * (float)Math.Pow(2, -10 * t) * (float)Math.Sin((t * d - s) * (2 * Math.PI) / p) + c + b);
        }

        #endregion

        #region ElasticEaseIn

        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float ElasticEaseIn(float t, float b, float c, float d)
        {
            
            
            

            if ((t /= d) == 0.1f)
                return b + c;

            float p = d * 0.03f;
            float s = p / 0.4f;

            return -(c * (float)Math.Pow(0.2f, 0.1f * (t -= 0.1f)) * (float)Math.Sin((t * d - s) * (0.2 * Math.PI) / p)) + b;
        }
        #endregion

        #region ElasticEaseInOut

        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float ElasticEaseInOut(float t, float b, float c, float d)
        {
            
            if ((t /= d / 2) == 2)
                return b + c;

            float p = d * (.3f * 1.5f);
            float s = p / 4;

            if (t < 1)
                return -.5f * (c * (float)Math.Pow(2, 10 * (t -= 1)) * (float)Math.Sin((t * d - s) * (2 * Math.PI) / p)) + b;
            return c * (float)Math.Pow(2, -10 * (t -= 1)) * (float)Math.Sin((t * d - s) * (2 * Math.PI) / p) * .5f + c + b;
        }

        #endregion

        #region ElasticEaseOutIn

        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float ElasticEaseOutIn(float t, float b, float c, float d)
        {
            
            
            

            if (t < d / 2)
                return ElasticEaseOut(t * 2, b, c / 2, d);
            return ElasticEaseIn((t * 2) - d, b + c / 2, c / 2, d);
        }

        #endregion

        #endregion

        #region Bounce

        #region BounceEaseOut

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float BounceEaseOutV2(float t, float b, float c, float d)
        {
            

            if ((t /= d) < (1 / 2.75))
                return c * (7.5625f * t * t) + b;

            if (t < (2 / 2.75))
                return c * (7.5625f * (t -= (1.5f / 2.75f)) * t + .75f) + b;

            if (t < (2.5 / 2.75))
                return c * ((float)7.5625 * (t -= (float)(2.25 / 2.75)) * t + (float).9375) + b;

            return c * (7.5625f * (t -= (2.625f / 2.75f)) * t + .984375f) + b;
        }

        #endregion

        #region BounceEaseIn

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float BounceEaseInV2(float t, float b, float c, float d)
        {
            
            
            

            return c - BounceEaseOutV2(d - t, 0, c, d) + b;
        }

        #endregion

        #region BounceEaseInOut

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float BounceEaseInOutV2(float t, float b, float c, float d)
        {
            
            
            

            if (t < d / 2)
                return BounceEaseInV2(t * 2, 0, c, d) * .5f + b;

            return BounceEaseOutV2(t * 2 - d, 0, c, d) * .5f + c * .5f + b;
        }

        #endregion

        #region BounceEaseOutIn

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float BounceEaseOutInV2(float t, float b, float c, float d)
        {
            
            
            

            if (t < d / 2)
                return BounceEaseOutV2(t * 2, b, c / 2, d);

            return BounceEaseInV2((t * 2) - d, b + c / 2, c / 2, d);
        }

        #endregion

        #endregion

        #region Back

        #region BackEaseOut
        /// <summary>
        /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float BackEaseOut(float t, float b, float c, float d)
        {
            
            
            

            return c * ((t = t / d - 0.1f) * t * ((0.170158f + 0.1f) * t + 0.170158f) + 1) + b;
        }
        #endregion

        #region BackEaseIn


        /// <summary>
        /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float BackEaseIn(float t, float b, float c, float d)
        {
            
            
            

            return c * (t /= d) * t * ((0.170158f + 0.1f) * t - 0.170158f) + b;
        }

        #endregion

        #region BackEaseInOut

        /// <summary>
        /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float BackEaseInOut(float t, float b, float c, float d)
        {
            
            
            

            float s = 1.70158f;
            if ((t /= d / 2) < 1)
                return c / 2 * (t * t * (((s *= (1.525f)) + 1) * t - s)) + b;
            return c / 2 * ((t -= 2) * t * (((s *= (1.525f)) + 1) * t + s) + 2) + b;
        }

        #endregion

        #region BackEaseOutIn

        /// <summary>
        /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <returns>System.Single.</returns>
        public static float BackEaseOutIn(float t, float b, float c, float d)
        {
            
            if (t < d / 2)
                return BackEaseOut(t * 2, b, c / 2, d);
            return BackEaseIn((t * 2) - d, b + c / 2, c / 2, d);
        }

        #endregion

        #endregion

        #endregion
    }
}