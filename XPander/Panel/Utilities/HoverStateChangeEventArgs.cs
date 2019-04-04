// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="HoverStateChangeEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.MiscControls
{
    #region HoverStateChangeEventArgs
    /// <summary>
    /// Provides data for the HoverStateChange event.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER
    /// REMAINS UNCHANGED.
    /// </copyright>
    public class HoverStateChangeEventArgs : EventArgs
    {
        #region FieldsPrivate
        /// <summary>
        /// The m hover state
        /// </summary>
        private HoverState m_hoverState;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the HoverState.
        /// </summary>
        /// <value>The state of the hover.</value>
        public HoverState HoverState
        {
            get { return this.m_hoverState; }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the HoverStateChangeEventArgs class.
        /// </summary>
        /// <param name="hoverState">The <see cref="HoverState" /> values.</param>
        public HoverStateChangeEventArgs(HoverState hoverState)
        {
            this.m_hoverState = hoverState;
        }
        #endregion
    }
    #endregion
}
