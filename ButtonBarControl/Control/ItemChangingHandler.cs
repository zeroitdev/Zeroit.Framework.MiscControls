// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="ItemChangingHandler.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents a method which will handle <see cref="ZeroitToxicButton.ItemsChanging" />
    /// </summary>
    /// <param name="index">Index of item being changed.</param>
    /// <param name="e">Object that contains event data.</param>
    public delegate void ItemChangingHandler(int index, GenericChangeEventArgs<BarItem> e);
}