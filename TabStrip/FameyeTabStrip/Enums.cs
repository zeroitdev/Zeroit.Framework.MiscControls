// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-12-2018
// ***********************************************************************
// <copyright file="Enums.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Hit test result of <see cref="FATabStrip" />
    /// </summary>
    public enum HitTestResult
    {
        /// <summary>
        /// The close button
        /// </summary>
        CloseButton,
        /// <summary>
        /// The menu glyph
        /// </summary>
        MenuGlyph,
        /// <summary>
        /// The tab item
        /// </summary>
        TabItem,
        /// <summary>
        /// The none
        /// </summary>
        None
    }

    /// <summary>
    /// Theme Type
    /// </summary>
    public enum ThemeTypes
    {
        /// <summary>
        /// The windows xp
        /// </summary>
        WindowsXP,
        /// <summary>
        /// The office2000
        /// </summary>
        Office2000,
        /// <summary>
        /// The office2003
        /// </summary>
        Office2003
    }

    /// <summary>
    /// Indicates a change into TabStrip collection
    /// </summary>
    public enum FATabStripItemChangeTypes
    {
        /// <summary>
        /// The added
        /// </summary>
        Added,
        /// <summary>
        /// The removed
        /// </summary>
        Removed,
        /// <summary>
        /// The changed
        /// </summary>
        Changed,
        /// <summary>
        /// The selection changed
        /// </summary>
        SelectionChanged
    }
}
