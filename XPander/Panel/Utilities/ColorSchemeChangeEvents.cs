// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ColorSchemeChangeEvents.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitProColorSchemeChangeEventArgs
    /// <summary>
    /// Provides data for the ZeroitProColorSchemeChange event.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER
    /// REMAINS UNCHANGED.
    /// </copyright>
    public class ZeroitProColorSchemeChangeEventArgs : EventArgs
    {
        #region FieldsPrivate

        /// <summary>
        /// The m e color schema
        /// </summary>
        private ZeroitProColorScheme m_eColorSchema;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the color schema which is used for the panel.
        /// </summary>
        /// <value>The zeroit pro color schema.</value>
        public ZeroitProColorScheme ZeroitProColorSchema
        {
            get { return this.m_eColorSchema; }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Arguments used when a ZeroitProColorSchemeChange event occurs.
        /// </summary>
        /// <param name="eColorSchema">The color schema which is used for the panel.</param>
        public ZeroitProColorSchemeChangeEventArgs(ZeroitProColorScheme eColorSchema)
        {
            this.m_eColorSchema = eColorSchema;
        }

        #endregion
    }
    #endregion
}
