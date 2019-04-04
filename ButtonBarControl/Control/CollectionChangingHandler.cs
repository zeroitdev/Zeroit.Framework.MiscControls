// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="CollectionChangingHandler.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents a method which will handle <see cref="ZeroitToxicButton.ItemsInserting" /> and <see cref="ZeroitToxicButton.ItemsRemoving" />
    /// </summary>
    /// <param name="index">Index of the item in collection.</param>
    /// <param name="value">Collection containing item.</param>
    public delegate void CollectionChangingHandler(int index, GenericCancelEventArgs<BarItem> value);
}