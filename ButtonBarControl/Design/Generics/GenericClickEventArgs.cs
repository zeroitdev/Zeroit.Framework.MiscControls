// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="GenericClickEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Represents a method which can handle generic click event
    /// </summary>
    /// <typeparam name="T">Generic type which can be associated with the event.</typeparam>
    /// <param name="sender">Event source</param>
    /// <param name="e">Object containing event data.</param>
    public delegate void GenericClickEventHandler<T>(object sender, GenericClickEventArgs<T> e);

    /// <summary>
    /// Class storing information related to generic click event
    /// </summary>
    /// <typeparam name="T">Generic type which can be associated with the event.</typeparam>
    /// <seealso cref="Zeroit.Framework.MiscControls.GenericEventArgs{T}" />
    public class GenericClickEventArgs<T> : GenericEventArgs<T>
    {
        /// <summary>
        /// The button
        /// </summary>
        private readonly MouseButtons button;
        /// <summary>
        /// The position
        /// </summary>
        private readonly Point position;

        /// <summary>
        /// Initializes a new default instance
        /// </summary>
        public GenericClickEventArgs()
        {
            button = MouseButtons.None;
            position = Point.Empty;
        }

        /// <summary>
        /// Initializes a new instance using specified parameters
        /// </summary>
        /// <param name="value">Object to be associated with the event.</param>
        /// <param name="button">Mousebutton which was clicked</param>
        /// <param name="position">Position of mouse</param>
        public GenericClickEventArgs(T value, MouseButtons button, Point position) : base(value)
        {
            this.button = button;
            this.position = position;
        }

        /// <summary>
        /// Gets which mouse button was clicked.
        /// </summary>
        /// <value>The button.</value>
        public MouseButtons Button
        {
            get { return button; }
        }

        /// <summary>
        /// Gets mouseposition when click was performed.
        /// </summary>
        /// <value>The position.</value>
        public Point Position
        {
            get { return position; }
        }
    }
}