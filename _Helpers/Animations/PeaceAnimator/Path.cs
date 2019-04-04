// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="Path.cs" company="Zeroit Dev Technologies">
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
    /// The Path class is a representation of a line in a 1D plane and the
    /// speed in which the animator plays it
    /// </summary>
    public class Path
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        public Path() : this(default(float), default(float), default(ulong), 0, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        /// <param name="start">The starting value</param>
        /// <param name="end">The ending value</param>
        /// <param name="duration">The time in miliseconds that the animator must play this path</param>
        /// <exception cref="ArgumentOutOfRangeException">Duration is less than zero</exception>
        public Path(float start, float end, ulong duration) : this(start, end, duration, 0, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        /// <param name="start">The starting value</param>
        /// <param name="end">The ending value</param>
        /// <param name="duration">The time in miliseconds that the animator must play this path</param>
        /// <param name="function">The animation function</param>
        /// <exception cref="ArgumentOutOfRangeException">Duration is less than zero</exception>
        public Path(float start, float end, ulong duration, AnimationFunctions.Function function)
            : this(start, end, duration, 0, function)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        /// <param name="start">The starting value</param>
        /// <param name="end">The ending value</param>
        /// <param name="duration">The time in miliseconds that the animator must play this path</param>
        /// <param name="delay">The time in miliseconds that the animator must wait before playing this path</param>
        /// <exception cref="ArgumentOutOfRangeException">Duration is less than zero</exception>
        public Path(float start, float end, ulong duration, ulong delay) : this(start, end, duration, delay, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        /// <param name="start">The starting value</param>
        /// <param name="end">The ending value</param>
        /// <param name="duration">The time in miliseconds that the animator must play this path</param>
        /// <param name="delay">The time in miliseconds that the animator must wait before playing this path</param>
        /// <param name="function">The animation function</param>
        /// <exception cref="ArgumentOutOfRangeException">Duration is less than zero</exception>
        public Path(float start, float end, ulong duration, ulong delay, AnimationFunctions.Function function)
        {
            Start = start;
            End = end;
            Function = function ?? AnimationFunctions.Liner;
            Duration = duration;
            Delay = delay;
        }

        /// <summary>
        /// Gets the difference of starting and ending values
        /// </summary>
        /// <value>The change.</value>
        public float Change => End - Start;

        /// <summary>
        /// Gets or sets the starting delay
        /// </summary>
        /// <value>The delay.</value>
        public ulong Delay { get; set; }

        /// <summary>
        /// Gets or sets the duration in milliseconds
        /// </summary>
        /// <value>The duration.</value>
        public ulong Duration { get; set; }

        /// <summary>
        /// Gets or sets the ending value
        /// </summary>
        /// <value>The end.</value>
        public float End { get; set; }

        /// <summary>
        /// Gets or sets the animation function
        /// </summary>
        /// <value>The function.</value>
        public AnimationFunctions.Function Function { get; set; }

        /// <summary>
        /// Gets or sets the starting value
        /// </summary>
        /// <value>The start.</value>
        public float Start { get; set; }

        /// <summary>
        /// Creates and returns a new <see cref="Path" /> based on the current path but in reverse order
        /// </summary>
        /// <returns>A new <see cref="Path" /> which is the reverse of the current <see cref="Path" /></returns>
        public Path Reverse()
        {
            return new Path(End, Start, Duration, Delay, Function);
        }
    }
}