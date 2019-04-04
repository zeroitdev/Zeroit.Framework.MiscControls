// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="NaviLayout.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class NaviLayout.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    /// <seealso cref="Zeroit.Framework.MiscControls.IObserver" />
    [TypeConverter(typeof(ExpandableObjectConverter))]
   public abstract class NaviLayout : Component, IObserver
   {
        #region IObserver Members

        /// <summary>
        /// Overriden. Handles the Notification the observable object sent
        /// </summary>
        /// <param name="obj">The observable object</param>
        /// <param name="id">An identification which caused this notification</param>
        /// <param name="arguments">Additional info</param>
        public abstract void Notify(IObservable obj, string id, object arguments);

        #endregion

        /// <summary>
        /// Gets the amount of visible buttons
        /// </summary>
        /// <value>The visible buttons.</value>
        public abstract int VisibleButtons { get; }

        /// <summary>
        /// Draws the Navigation pane
        /// </summary>
        /// <param name="g">Graphics object providing drawing functionality</param>
        public abstract void Draw(Graphics g);

        /// <summary>
        /// Draws the background of the Navigation pane
        /// </summary>
        /// <param name="g">Graphics object providing drawing functionality</param>
        public abstract void DrawBackground(Graphics g);

        /// <summary>
        /// Requests that the layout engine should perform a layout operation
        /// </summary>
        /// <param name="container">The container</param>
        /// <param name="layoutEventArgs">Additional event info</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public abstract bool Layout(object container, LayoutEventArgs layoutEventArgs);

        /// <summary>
        /// Initializes the child controls, only call once.
        /// </summary>
        public abstract void InitializeChildControls();

        /// <summary>
        /// Handles additional functionality at the end of the initialization
        /// </summary>
        public abstract void EndInit();

        /// <summary>
        /// Changes the navigation bar to collapsed view
        /// </summary>
        /// <param name="collapse">if set to <c>true</c> [collapse].</param>
        /// <param name="oldCollapsed">if set to <c>true</c> [old collapsed].</param>
        public abstract void SwitchCollapsion(bool collapse, bool oldCollapsed);

        /// <summary>
        /// Gets or sets the Navigationbar
        /// </summary>
        public ZeroitNaviBar Bar;
   }
}
