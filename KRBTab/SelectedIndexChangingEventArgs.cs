// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="SelectedIndexChangingEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.Tabs.ZeroitKRBTab
{
    /// <summary>
    /// Class ZeroitKRBTab.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TabControl" />
    partial class ZeroitKRBTab
    {
        /// <summary>
        /// Class SelectedIndexChangingEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        /// <seealso cref="System.IDisposable" />
        public class SelectedIndexChangingEventArgs : EventArgs, IDisposable
        {
            #region Instance Member

            /// <summary>
            /// The cancel
            /// </summary>
            private bool cancel = false;
            /// <summary>
            /// The tab page index
            /// </summary>
            private int tabPageIndex = -1;
            /// <summary>
            /// The tab page
            /// </summary>
            private TabPageEx tabPage = null;

            #endregion

            #region Constructor

            /// <summary>
            /// Initializes a new instance of the <see cref="SelectedIndexChangingEventArgs"/> class.
            /// </summary>
            /// <param name="tabPage">The tab page.</param>
            /// <param name="tabPageIndex">Index of the tab page.</param>
            public SelectedIndexChangingEventArgs(TabPageEx tabPage, int tabPageIndex)
            {
                this.tabPage = tabPage;
                this.tabPageIndex = tabPageIndex;
            }

            #endregion

            #region Property

            /// <summary>
            /// Gets or sets a value indicating whether the event should be canceled.
            /// </summary>
            /// <value><c>true</c> if cancel; otherwise, <c>false</c>.</value>
            public bool Cancel
            {
                get { return cancel; }
                set
                {
                    if (!value.Equals(cancel))
                        cancel = value;
                }
            }

            /// <summary>
            /// Gets the zero-based index of the TabPageEx in the ZeroitKRBTab.TabPages collection.
            /// </summary>
            /// <value>The index of the tab page.</value>
            public int TabPageIndex
            {
                get { return tabPageIndex; }
            }

            /// <summary>
            /// Gets the TabPageEx the event is occurring for.
            /// </summary>
            /// <value>The tab page.</value>
            public TabPageEx TabPage
            {
                get { return tabPage; }
            }

            #endregion

            #region IDisposable Members

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            void IDisposable.Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion
        }

        /// <summary>
        /// Class ContextMenuShownEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        /// <seealso cref="System.IDisposable" />
        public class ContextMenuShownEventArgs : EventArgs, IDisposable
        {
            #region Instance Member

            /// <summary>
            /// The context menu
            /// </summary>
            private ContextMenuStrip contextMenu = null;
            /// <summary>
            /// The menu location
            /// </summary>
            private Point menuLocation = Point.Empty;

            #endregion

            #region Constructor

            /// <summary>
            /// Initializes a new instance of the <see cref="ContextMenuShownEventArgs"/> class.
            /// </summary>
            /// <param name="contextMenu">The context menu.</param>
            /// <param name="menuLocation">The menu location.</param>
            public ContextMenuShownEventArgs(ContextMenuStrip contextMenu, Point menuLocation)
            {
                this.contextMenu = contextMenu;
                this.menuLocation = menuLocation;
            }

            #endregion

            #region Property

            /// <summary>
            /// Gets the drop-down menu of the control.It shows when a user clicks the drop-down icon on the caption.
            /// </summary>
            /// <value>The context menu.</value>
            public ContextMenuStrip ContextMenu
            {
                get { return contextMenu; }
            }

            /// <summary>
            /// Gets or sets the drop-down menu location on the screen coordinates.
            /// </summary>
            /// <value>The menu location.</value>
            public Point MenuLocation
            {
                get { return menuLocation; }
                set 
                { 
                    menuLocation = value;
                }
            }

            #endregion

            #region IDisposable Members

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            void IDisposable.Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #endregion
        }
    }
}