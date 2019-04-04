// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="MathFunctions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.MiscControls
{
    #region Math Functions

    /// <summary>
    /// Mathematic Functions
    /// </summary>
    public class ZeroitLBMath : Object
    {
        /// <summary>
        /// Gets the radian.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>System.Single.</returns>
        public static float GetRadian(float val)
        {
            return (float)(val * Math.PI / 180);
        }
    }

    #endregion
}
