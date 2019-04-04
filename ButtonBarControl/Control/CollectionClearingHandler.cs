// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="CollectionClearingHandler.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents a method which will handle <see cref="ZeroitToxicButton.ItemsClearing" />
    /// </summary>
    /// <param name="value">Object that contains event data.</param>
    public delegate void CollectionClearingHandler(GenericCancelEventArgs<GenericCollection<BarItem>> value);
}