// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviBandOrgOrderComparer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviBandOrgOrderComparer.
    /// </summary>
    /// <seealso cref="System.Collections.IComparer" />
    public class NaviBandOrgOrderComparer : IComparer
   {
        #region IComparer Members

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero <paramref name="x" /> is less than <paramref name="y" />. Zero <paramref name="x" /> equals <paramref name="y" />. Greater than zero <paramref name="x" /> is greater than <paramref name="y" />.</returns>
        /// <exception cref="System.ArgumentException">Both of the argument should be of type NaviBand</exception>
        public int Compare(object x, object y)
      {
         if (!(x is NaviBand) || !(y is NaviBand))
            throw new ArgumentException("Both of the argument should be of type NaviBand");

         NaviBand bandx = (NaviBand)x;
         NaviBand bandy = (NaviBand)y;

         return bandx.OriginalOrder.CompareTo(bandy.OriginalOrder);
      }

      #endregion
   }
}
