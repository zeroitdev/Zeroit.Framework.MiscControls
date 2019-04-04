// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="KnownAnimationFunctions.cs" company="Zeroit Dev Technologies">
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
namespace Zeroit.Framework.MiscControls.HelperControls.AnimationHelpers.WinFormAnimation
{
    /// <summary>
    /// Contains a list of all known animation functions
    /// </summary>
    public enum KnownAnimationFunctions
    {
        /// <summary>
        /// No known animation function
        /// </summary>
        None,

        /// <summary>
        /// The bounce ease-out animation function.
        /// </summary>
        BounceEaseOut,

        /// <summary>
        /// The bounce ease-in animation function.
        /// </summary>
        BounceEaseIn,

        /// <summary>
        /// The bounce ease-in-out animation function.
        /// </summary>
        BounceEaseInOut,

        /// <summary>
        /// The bounce ease-out-in animation function.
        /// </summary>
        BounceEaseOutIn,

        /// <summary>
        /// The cubic ease-in animation function.
        /// </summary>
        CubicEaseIn,

        /// <summary>
        /// The cubic ease-in and ease-out animation function.
        /// </summary>
        CubicEaseInOut,

        /// <summary>
        /// The cubic ease-out animation function.
        /// </summary>
        CubicEaseOut,

        /// <summary>
        /// The liner animation function.
        /// </summary>
        Liner,

        /// <summary>
        /// The circular ease-in and ease-out animation function.
        /// </summary>
        CircularEaseInOut,

        /// <summary>
        /// The circular ease-in animation function.
        /// </summary>
        CircularEaseIn,

        /// <summary>
        /// The circular ease-out animation function.
        /// </summary>
        CircularEaseOut,

        /// <summary>
        /// The quadratic ease-in animation function.
        /// </summary>
        QuadraticEaseIn,

        /// <summary>
        /// The quadratic ease-out animation function.
        /// </summary>
        QuadraticEaseOut,

        /// <summary>
        /// The quadratic ease-in and ease-out animation function.
        /// </summary>
        QuadraticEaseInOut,

        /// <summary>
        /// The quartic ease-in animation function.
        /// </summary>
        QuarticEaseIn,

        /// <summary>
        /// The quartic ease-out animation function.
        /// </summary>
        QuarticEaseOut,

        /// <summary>
        /// The quartic ease-in and ease-out animation function.
        /// </summary>
        QuarticEaseInOut,

        /// <summary>
        /// The quintic ease-in and ease-out animation function.
        /// </summary>
        QuinticEaseInOut,

        /// <summary>
        /// The quintic ease-in animation function.
        /// </summary>
        QuinticEaseIn,

        /// <summary>
        /// The quintic ease-out animation function.
        /// </summary>
        QuinticEaseOut,

        /// <summary>
        /// The sinusoidal ease-in animation function.
        /// </summary>
        SinusoidalEaseIn,

        /// <summary>
        /// The sinusoidal ease-out animation function.
        /// </summary>
        SinusoidalEaseOut,

        /// <summary>
        /// The sinusoidal ease-in and ease-out animation function.
        /// </summary>
        SinusoidalEaseInOut,

        /// <summary>
        /// The exponential ease-in animation function.
        /// </summary>
        ExponentialEaseIn,

        /// <summary>
        /// The exponential ease-out animation function.
        /// </summary>
        ExponentialEaseOut,

        /// <summary>
        /// The exponential ease-in and ease-out animation function.
        /// </summary>
        ExponentialEaseInOut,

        //-----------------------------------Zeroit Additions------------------------//
        //Linear,
        //EaseIn,
        //EaseOut,
        //EaseInAndOut,
        /// <summary>
        /// The linear tween
        /// </summary>
        LinearTween,
        /// <summary>
        /// The ease in quad
        /// </summary>
        EaseInQuad,
        /// <summary>
        /// The ease out quad
        /// </summary>
        EaseOutQuad,
        /// <summary>
        /// The ease in out quad
        /// </summary>
        EaseInOutQuad,
        /// <summary>
        /// The ease in cubic
        /// </summary>
        EaseInCubic,
        /// <summary>
        /// The ease out cubic
        /// </summary>
        EaseOutCubic,
        /// <summary>
        /// The ease in out cubic
        /// </summary>
        EaseInOutCubic,
        /// <summary>
        /// The ease in quart
        /// </summary>
        EaseInQuart,
        /// <summary>
        /// The ease out quart
        /// </summary>
        EaseOutQuart,
        /// <summary>
        /// The ease in out quart
        /// </summary>
        EaseInOutQuart,
        /// <summary>
        /// The ease in quint
        /// </summary>
        EaseInQuint,
        /// <summary>
        /// The ease out quint
        /// </summary>
        EaseOutQuint,
        /// <summary>
        /// The ease in out quint
        /// </summary>
        EaseInOutQuint,
        /// <summary>
        /// The ease in sine
        /// </summary>
        EaseInSine,
        /// <summary>
        /// The ease out sine
        /// </summary>
        EaseOutSine,
        /// <summary>
        /// The ease in out sine
        /// </summary>
        EaseInOutSine,
        /// <summary>
        /// The ease in expo
        /// </summary>
        EaseInExpo,
        /// <summary>
        /// The ease out expo
        /// </summary>
        EaseOutExpo,
        /// <summary>
        /// The ease in out expo
        /// </summary>
        EaseInOutExpo,
        /// <summary>
        /// The ease in circ
        /// </summary>
        EaseInCirc,
        /// <summary>
        /// The ease out circ
        /// </summary>
        EaseOutCirc,
        /// <summary>
        /// The ease in out circ
        /// </summary>
        EaseInOutCirc,
        /// <summary>
        /// The elastic ease out
        /// </summary>
        ElasticEaseOut,
        /// <summary>
        /// The elastic ease in
        /// </summary>
        ElasticEaseIn,
        /// <summary>
        /// The elastic ease in out
        /// </summary>
        ElasticEaseInOut,
        /// <summary>
        /// The elastic ease out in
        /// </summary>
        ElasticEaseOutIn,
        /// <summary>
        /// The bounce ease out v2
        /// </summary>
        BounceEaseOutV2,
        /// <summary>
        /// The bounce ease in v2
        /// </summary>
        BounceEaseInV2,
        /// <summary>
        /// The bounce ease in out v2
        /// </summary>
        BounceEaseInOutV2,
        /// <summary>
        /// The bounce ease out in v2
        /// </summary>
        BounceEaseOutInV2,
        /// <summary>
        /// The back ease out
        /// </summary>
        BackEaseOut,
        /// <summary>
        /// The back ease in
        /// </summary>
        BackEaseIn,
        /// <summary>
        /// The back ease in out
        /// </summary>
        BackEaseInOut,
        /// <summary>
        /// The back ease out in
        /// </summary>
        BackEaseOutIn
        //-----------------------------------Zeroit Additions------------------------//


    }
}