// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="Path3D.cs" company="Zeroit Dev Technologies">
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
    /// The Path3D class is a representation of a line in a 3D plane and the
    /// speed in which the animator plays it
    /// </summary>
    public class Path3D
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="startX">The starting horizontal value</param>
        /// <param name="endX">The ending horizontal value</param>
        /// <param name="startY">The starting vertical value</param>
        /// <param name="endY">The ending vertical value</param>
        /// <param name="startZ">The starting depth value</param>
        /// <param name="endZ">The ending depth value</param>
        /// <param name="duration">The time in miliseconds that the animator must play this path</param>
        /// <param name="delay">The time in miliseconds that the animator must wait before playing this path</param>
        /// <param name="function">The animation function</param>
        /// <exception cref="ArgumentOutOfRangeException">Duration is less than zero</exception>
        public Path3D(
            float startX,
            float endX,
            float startY,
            float endY,
            float startZ,
            float endZ,
            ulong duration,
            ulong delay,
            AnimationFunctions.Function function)
            : this(
                new Path(startX, endX, duration, delay, function),
                new Path(startY, endY, duration, delay, function),
                new Path(startZ, endZ, duration, delay, function))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="startX">The starting horizontal value</param>
        /// <param name="endX">The ending horizontal value</param>
        /// <param name="startY">The starting vertical value</param>
        /// <param name="endY">The ending vertical value</param>
        /// <param name="startZ">The starting depth value</param>
        /// <param name="endZ">The ending depth value</param>
        /// <param name="duration">The time in miliseconds that the animator must play this path</param>
        /// <param name="delay">The time in miliseconds that the animator must wait before playing this path</param>
        /// <exception cref="ArgumentOutOfRangeException">Duration is less than zero</exception>
        public Path3D(
            float startX,
            float endX,
            float startY,
            float endY,
            float startZ,
            float endZ,
            ulong duration,
            ulong delay)
            : this(
                new Path(startX, endX, duration, delay),
                new Path(startY, endY, duration, delay),
                new Path(startZ, endZ, duration, delay))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="startX">The starting horizontal value</param>
        /// <param name="endX">The ending horizontal value</param>
        /// <param name="startY">The starting vertical value</param>
        /// <param name="endY">The ending vertical value</param>
        /// <param name="startZ">The starting depth value</param>
        /// <param name="endZ">The ending depth value</param>
        /// <param name="duration">The time in miliseconds that the animator must play this path</param>
        /// <param name="function">The animation function</param>
        /// <exception cref="ArgumentOutOfRangeException">Duration is less than zero</exception>
        public Path3D(
            float startX,
            float endX,
            float startY,
            float endY,
            float startZ,
            float endZ,
            ulong duration,
            AnimationFunctions.Function function)
            : this(
                new Path(startX, endX, duration, function),
                new Path(startY, endY, duration, function),
                new Path(startZ, endZ, duration, function))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="startX">The starting horizontal value</param>
        /// <param name="endX">The ending horizontal value</param>
        /// <param name="startY">The starting vertical value</param>
        /// <param name="endY">The ending vertical value</param>
        /// <param name="startZ">The starting depth value</param>
        /// <param name="endZ">The ending depth value</param>
        /// <param name="duration">The time in miliseconds that the animator must play this path</param>
        /// <exception cref="ArgumentOutOfRangeException">Duration is less than zero</exception>
        public Path3D(
            float startX,
            float endX,
            float startY,
            float endY,
            float startZ,
            float endZ,
            ulong duration)
            : this(new Path(startX, endX, duration), new Path(startY, endY, duration), new Path(startZ, endZ, duration))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="start">The starting point in a 3D plane</param>
        /// <param name="end">The ending point in a 3D plane</param>
        /// <param name="duration">The time in miliseconds that the animator must play this path</param>
        /// <param name="delay">The time in miliseconds that the animator must wait before playing this path</param>
        /// <param name="function">The animation function</param>
        /// <exception cref="ArgumentOutOfRangeException">Duration is less than zero</exception>
        public Path3D(Float3D start, Float3D end, ulong duration, ulong delay, AnimationFunctions.Function function)
            : this(
                new Path(start.X, end.X, duration, delay, function),
                new Path(start.Y, end.Y, duration, delay, function),
                new Path(start.Z, end.Z, duration, delay, function))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="start">The starting point in a 3D plane</param>
        /// <param name="end">The ending point in a 3D plane</param>
        /// <param name="duration">The time in miliseconds that the animator must play this path</param>
        /// <param name="delay">The time in miliseconds that the animator must wait before playing this path</param>
        /// <exception cref="ArgumentOutOfRangeException">Duration is less than zero</exception>
        public Path3D(Float3D start, Float3D end, ulong duration, ulong delay)
            : this(
                new Path(start.X, end.X, duration, delay),
                new Path(start.Y, end.Y, duration, delay),
                new Path(start.Z, end.Z, duration, delay))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="start">The starting point in a 3D plane</param>
        /// <param name="end">The ending point in a 3D plane</param>
        /// <param name="duration">The time in miliseconds that the animator must play this path</param>
        /// <param name="function">The animation function</param>
        /// <exception cref="ArgumentOutOfRangeException">Duration is less than zero</exception>
        public Path3D(Float3D start, Float3D end, ulong duration, AnimationFunctions.Function function)
            : this(
                new Path(start.X, end.X, duration, function),
                new Path(start.Y, end.Y, duration, function),
                new Path(start.Z, end.Z, duration, function))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="start">The starting point in a 3D plane</param>
        /// <param name="end">The ending point in a 3D plane</param>
        /// <param name="duration">The time in miliseconds that the animator must play this path</param>
        /// <exception cref="ArgumentOutOfRangeException">Duration is less than zero</exception>
        public Path3D(Float3D start, Float3D end, ulong duration)
            : this(
                new Path(start.X, end.X, duration),
                new Path(start.Y, end.Y, duration),
                new Path(start.Z, end.Z, duration))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path3D" /> class.
        /// </summary>
        /// <param name="x">The horizontal path.</param>
        /// <param name="y">The vertical path.</param>
        /// <param name="z">The depth path.</param>
        public Path3D(Path x, Path y, Path z)
        {
            HorizontalPath = x;
            VerticalPath = y;
            DepthPath = z;
        }

        /// <summary>
        /// Gets the horizontal path
        /// </summary>
        /// <value>The horizontal path.</value>
        public Path HorizontalPath { get; }

        /// <summary>
        /// Gets the vertical path
        /// </summary>
        /// <value>The vertical path.</value>
        public Path VerticalPath { get; }

        /// <summary>
        /// Gets the depth path
        /// </summary>
        /// <value>The depth path.</value>
        public Path DepthPath { get; }


        /// <summary>
        /// Gets the starting point of the path
        /// </summary>
        /// <value>The start.</value>
        public Float3D Start => new Float3D(HorizontalPath.Start, VerticalPath.Start, DepthPath.Start);


        /// <summary>
        /// Gets the ending point of the path
        /// </summary>
        /// <value>The end.</value>
        public Float3D End => new Float3D(HorizontalPath.End, VerticalPath.End, DepthPath.End);

        /// <summary>
        /// Creates and returns a new <see cref="Path3D" /> based on the current path but in reverse order
        /// </summary>
        /// <returns>A new <see cref="Path" /> which is the reverse of the current <see cref="Path3D" /></returns>
        public Path3D Reverse()
        {
            return new Path3D(HorizontalPath.Reverse(), VerticalPath.Reverse(), DepthPath.Reverse());
        }
    }
}