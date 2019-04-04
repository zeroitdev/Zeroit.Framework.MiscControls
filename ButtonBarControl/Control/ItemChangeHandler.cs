// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="ItemChangeHandler.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents a method which will handle <see cref="ZeroitToxicButton.ItemsChanged" />.
    /// </summary>
    /// <param name="index">Index of item</param>
    /// <param name="oldValue">Old value of <see cref="BarItem" /></param>
    /// <param name="newValue">New value of <see cref="BarItem" /></param>
    public delegate void ItemChangeHandler(int index, BarItem oldValue, BarItem newValue);
}