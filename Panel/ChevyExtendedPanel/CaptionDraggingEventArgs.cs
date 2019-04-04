// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CaptionDraggingEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Zeroit.Framework.MiscControls
{
    #region CaptionDraggingEventArgs

    /// <summary>
    /// Class CaptionDraggingEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class CaptionDraggingEventArgs : EventArgs
    {
        #region Members
        /// <summary>
        /// Instance of the width change
        /// </summary>
        private int width = 0;

        /// <summary>
        /// Instance of the height change
        /// </summary>
        private int height = 0;
        #endregion

        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="CaptionDraggingEventArgs"/> class.
        /// </summary>
        public CaptionDraggingEventArgs()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaptionDraggingEventArgs"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public CaptionDraggingEventArgs(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        #endregion
    }

    #endregion
}
