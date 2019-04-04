// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 07-06-2018
// ***********************************************************************
// <copyright file="AnimatorStatus.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Zeroit.Framework.MiscControls.HelperControls.AnimationHelpers.WinFormAnimation
{
    /// <summary>
    /// The possible statuses for an animator instance
    /// </summary>
    public enum AnimatorStatus
    {
        /// <summary>
        /// Animation is stopped
        /// </summary>
        Stopped,

        /// <summary>
        /// Animation is now playing
        /// </summary>
        Playing,

        /// <summary>
        /// Animation is now on hold for path delay, consider this value as playing
        /// </summary>
        OnHold,

        /// <summary>
        /// Animation is paused
        /// </summary>
        Paused
    }
}