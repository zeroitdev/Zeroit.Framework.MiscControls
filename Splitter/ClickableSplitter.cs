// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ClickableSplitter.cs" company="Zeroit Dev Technologies">
//    This program is for creating various controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Clickable Splitter

    /// <summary>
    /// A custom control based on a standard splitter that
    /// adds a click handler and position and orientation based
    /// cursors.
    /// Uses embedded cursors and shows how to use embedded resources.
    /// Uses a custom property that shows one way to turn an event handler
    /// on and off.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Splitter" />

    public class ZeroitClickableSplitter : System.Windows.Forms.Splitter
    {
        #region Member data

        // the cache for the last known position to which can be restored
        /// <summary>
        /// The last position
        /// </summary>
        private int lastPosition;

        // whether to use position and location based cursors
        /// <summary>
        /// The use cursors
        /// </summary>
        private bool useCursors;

        // to give the cursor styles proper names
        /// <summary>
        /// Enum cursorStyles
        /// </summary>
        private enum cursorStyles
        {
            /// <summary>
            /// Down
            /// </summary>
            down,
            /// <summary>
            /// Down restore
            /// </summary>
            downRestore,
            /// <summary>
            /// The left
            /// </summary>
            left,
            /// <summary>
            /// The left restore
            /// </summary>
            leftRestore,
            /// <summary>
            /// The left right left
            /// </summary>
            leftRightLeft,
            /// <summary>
            /// The left right right
            /// </summary>
            leftRightRight,
            /// <summary>
            /// The right
            /// </summary>
            right,
            /// <summary>
            /// The right restore
            /// </summary>
            rightRestore,
            /// <summary>
            /// Up
            /// </summary>
            up,
            /// <summary>
            /// Up down down
            /// </summary>
            upDownDown,
            /// <summary>
            /// Up down up
            /// </summary>
            upDownUp,
            /// <summary>
            /// Up restore
            /// </summary>
            upRestore
        };


        /// <summary>
        /// The cursor names
        /// </summary>
        private string[] cursorNames =
            {
                "down",
                "downRestore",
                "left",
                "leftRestore",
                "leftRightLeft",
                "leftRightRight",
                "right",
                "rightRestore",
                "up",
                "upDownDown",
                "upDownUp",
                "upRestore"};

        /// <summary>
        /// The cursors
        /// </summary>
        private Cursor[] cursors = new Cursor[12];

        #endregion

        #region Constructors

        /// <summary>
        /// Construct an instance, i.e. load the cursors. There should be
        /// a better way, i.e. something static in combination with a
        /// property. If no clikable splitter uses the extended cursor
        /// thing why load them? What's more, if using more than one
        /// clickable splitter why load them more than once? Let's say
        /// I left that as an exercise for the reader.
        /// </summary>

        public ZeroitClickableSplitter()
        {
            Assembly assembly = GetType().Assembly;
            AssemblyName assemblyName = assembly.GetName();
            for (cursorStyles cursorStyle = cursorStyles.down; cursorStyle <= cursorStyles.upRestore; cursorStyle++)
                cursors[(int)cursorStyle] = new Cursor(assembly.GetManifestResourceStream(assemblyName.Name + ".Resources." + cursorNames[(int)cursorStyle] + ".cur"));
            //cursors[(int)cursorStyle] = new Cursor(assembly.GetManifestResourceStream(assemblyName.Name + ".Cursors." + cursorNames[(int)cursorStyle] + ".cur"));
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Handles the clickable splitter click. Choose for override
        /// since default behavior does not do much, now does it?
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>

        protected override void OnClick(System.EventArgs e)
        {
            // get the mouse location in client coordinates
            Point p = PointToClient(MousePosition);
            if (isVertical)
                // mouse on vertical splitter
                if (p.Y < (Height >> 1))
                    // mouse on upper half of splitter
                    if (SplitPosition != MinSize)
                        // splitter not on left extreme, move splitter to the left extreme
                        // if splitter was on right extreme its position will not update cached position
                        OnVerticalSplitterMoved(MinSize, Parent.ClientSize.Width - MinExtra - Width);
                    else
                        // splitter on left extreme, restore from cached position
                        OnSplitterMoved(new SplitterEventArgs(lastPosition, 0, lastPosition, 0));
                else
                    // mouse click on lower half of vertical splitter
                    if (SplitPosition != Parent.ClientSize.Width - MinExtra - Width)
                    // splitter not on right extreme, move splitter to the right extreme
                    // if splitter was on left extreme its position will not update cached position
                    OnVerticalSplitterMoved(Parent.ClientSize.Width - MinExtra - Width, MinSize);
                else
                    // vertical splitter on right extreme, restore from cached position
                    OnSplitterMoved(new SplitterEventArgs(lastPosition, 0, lastPosition, 0));
            else
                // mouse click on horizontal splitter
                if (p.X < (Width >> 1))
                // mouse on left half of splitter
                if (SplitPosition != Parent.ClientSize.Height - MinExtra - Height)
                    // splitter not on lower extreme, move splitter to the lower extreme
                    // if splitter was on upper extreme its position will not update cached position
                    OnHorizontalSplitterMoved(Parent.ClientSize.Height - MinExtra - Height, MinSize);
                else
                    // splitter on lower extreme, restore from cached position
                    OnSplitterMoved(new SplitterEventArgs(0, lastPosition, 0, lastPosition));
            else
                    // mouse on right half of splitter
                    if (SplitPosition != MinSize)
                // splitter not on upper extreme, move splitter to the upper extreme
                // if splitter was on lower extreme its position will not update cached position
                OnHorizontalSplitterMoved(MinSize, Parent.ClientSize.Height - MinExtra - Height);
            else
                // splitter on upper extreme, restore from cached position
                OnSplitterMoved(new SplitterEventArgs(0, lastPosition, 0, lastPosition));
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// Handles the <see cref="E:MouseMove" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            // mouse location in e is in client coordinates and ready for use "as is"
            if (isVertical)
                // mouse on vertical splitter
                if (e.Y < (Height >> 1))
                    // mouse on upper half of splitter
                    if (SplitPosition == MinSize)
                        // splitter on left extreme 
                        Cursor = cursors[(int)cursorStyles.rightRestore];
                    else
                    if (SplitPosition == (Parent.ClientSize.Width - MinExtra - Width))
                        // splitter on right extreme
                        Cursor = cursors[(int)cursorStyles.left];
                    else
                        // splitter not on extreme
                        Cursor = cursors[(int)cursorStyles.leftRightLeft];
                else
                    // mouse on lower half of splitter
                    if (SplitPosition == MinSize)
                    // splitter on left extreme
                    Cursor = cursors[(int)cursorStyles.right];
                else
                    if (SplitPosition == (Parent.ClientSize.Width - MinExtra - Width))
                    // splitter on right extreme
                    Cursor = cursors[(int)cursorStyles.leftRestore];
                else
                    // splitter not on extreme
                    Cursor = cursors[(int)cursorStyles.leftRightRight];
            else
                // mouse on horizontal splitter
                if (e.X < (Width >> 1))
                // mouse on left half of splitter
                if (SplitPosition == MinSize)
                    // splitter on upper extreme
                    Cursor = cursors[(int)cursorStyles.down];
                else
                if (SplitPosition == (Parent.ClientSize.Height - MinExtra - Height))
                    // splitter on lower extreme
                    Cursor = cursors[(int)cursorStyles.upRestore];
                else
                    // splitter not on extreme
                    Cursor = cursors[(int)cursorStyles.upDownDown];
            else
                    // mouse on right half of splitter
                    if (SplitPosition == MinSize)
                // splitter on upper extreme
                Cursor = cursors[(int)cursorStyles.downRestore];
            else
                    if (SplitPosition == (Parent.ClientSize.Height - MinExtra - Height))
                // splitter on lower extreme
                Cursor = cursors[(int)cursorStyles.up];
            else
                // splitter not on extreme
                Cursor = cursors[(int)cursorStyles.upDownUp];
        }

        #endregion

        #region Properties

        /// <summary>
        /// States whether clickable splitter is vertical clickable
        /// splitter. If not, I guess it must be a horizontal one...
        /// </summary>
        /// <value><c>true</c> if this instance is vertical; otherwise, <c>false</c>.</value>

        private bool isVertical
        {
            get { return (Dock == DockStyle.Left || Dock == DockStyle.Right); }
        }

        /// <summary>
        /// Custom property to define whether to use orientation
        /// and position based cursors. Default is false.
        /// </summary>
        /// <value><c>true</c> if [use cursors]; otherwise, <c>false</c>.</value>

        [
            Bindable(true),
            Category("Behavior"),
            DefaultValue(false),
            Description("Determines whether to use orientation and position based cursors.")
        ]
        public bool UseCursors
        {
            get { return useCursors; }
            set
            {
                if (!value)
                {
                    if (useCursors)
                        MouseMove -= new MouseEventHandler(OnMouseMove);
                }
                else
                {
                    if (!useCursors)
                        MouseMove += new MouseEventHandler(OnMouseMove);
                }
                useCursors = value;
            }
        }

        #endregion

        #region Helper methods

        /// <summary>
        /// Triggers a horizontal splitter move to a new position.
        /// Caches current position if required for restore later on.
        /// </summary>
        /// <param name="newSize">The splitter position to be.</param>
        /// <param name="extremeSize">The extreem position for which not to update cached position.</param>

        private void OnHorizontalSplitterMoved(int newSize, int extremeSize)
        {
            if (SplitPosition != extremeSize)
                lastPosition = SplitPosition;
            OnSplitterMoved(new SplitterEventArgs(0, newSize, 0, newSize));
        }

        /// <summary>
        /// Triggers a vertical splitter move to a new position.
        /// Caches current position if required for restore later on.
        /// </summary>
        /// <param name="newSize">The splitter position to be.</param>
        /// <param name="extremeSize">The extreem position for which not to update cached position.</param>

        private void OnVerticalSplitterMoved(int newSize, int extremeSize)
        {
            if (SplitPosition != extremeSize)
                lastPosition = SplitPosition;
            OnSplitterMoved(new SplitterEventArgs(newSize, 0, newSize, 0));
        }

        #endregion
    }

    #endregion
}
