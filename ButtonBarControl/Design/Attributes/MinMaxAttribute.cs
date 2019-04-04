// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="MinMaxAttribute.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class MinMaxAttribute.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    internal class MinMaxAttribute : Attribute
    {
        /// <summary>
        /// The default
        /// </summary>
        public static readonly MinMaxAttribute Default = new MinMaxAttribute(0, 255);
        /// <summary>
        /// The maximum value
        /// </summary>
        private readonly int maxValue;
        /// <summary>
        /// The minimum value
        /// </summary>
        private readonly int minValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinMaxAttribute"/> class.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        public MinMaxAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        public int MinValue
        {
            get { return minValue; }
        }

        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public int MaxValue
        {
            get { return maxValue; }
        }

        /// <summary>
        /// Returns a value that indicates whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An <see cref="T:System.Object"></see> to compare with this instance or null.</param>
        /// <returns>true if obj equals the type and value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var attribute = obj as MinMaxAttribute;
            if (attribute != null)
            {
                return attribute.minValue.Equals(minValue) && attribute.maxValue.Equals(maxValue);
            }
            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// When overridden in a derived class, indicates whether the value of this instance is the default value for the derived class.
        /// </summary>
        /// <returns>true if this instance is the default attribute for the class; otherwise, false.</returns>
        public override bool IsDefaultAttribute()
        {
            return Default.Equals(this);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.</returns>
        public override string ToString()
        {
            return "Minimum allowed value : " + minValue + " , Maximum allowed value : " + maxValue;
        }
    }
}