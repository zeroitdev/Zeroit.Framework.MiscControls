// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="CollectionChangedHandler.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents a method which will handle <see cref="ZeroitToxicButton.ItemsInserted" /> and <see cref="ZeroitToxicButton.ItemsRemoved" />
    /// </summary>
    /// <param name="index">Index of item.</param>
    /// <param name="value">Associated <see cref="BarItem" /></param>
    public delegate void CollectionChangedHandler(int index, BarItem value);
}