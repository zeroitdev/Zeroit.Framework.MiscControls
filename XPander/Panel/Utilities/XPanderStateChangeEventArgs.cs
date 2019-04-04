// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="XPanderStateChangeEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.MiscControls
{
    #region XPanderStateChangeEventArgs
    /// <summary>
    /// Provides data for the XPanderStateChange event.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER
    /// REMAINS UNCHANGED.
    
    public class XPanderStateChangeEventArgs : EventArgs
    {
        #region FieldsPrivate

        /// <summary>
        /// The m b expand
        /// </summary>
        private bool m_bExpand;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the panel expands.
        /// </summary>
        /// <value><c>true</c> if expand; otherwise, <c>false</c>.</value>
        public bool Expand
        {
            get { return m_bExpand; }
        }

        #endregion

        #region MethodsPublic
        /// <summary>
        /// arguments used when a XPanderStateChange event occurs.
        /// </summary>
        /// <param name="bExpand">Gets a value indicating whether the panel expands.</param>
        public XPanderStateChangeEventArgs(bool bExpand)
        {
            this.m_bExpand = bExpand;
        }

        #endregion
    }
    #endregion
}
