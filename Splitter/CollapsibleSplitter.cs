// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CollapsibleSplitter.cs" company="Zeroit Dev Technologies">
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
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Collapsible Splitter

    #region Enums
    /// <summary>
    /// Enumeration to sepcify the visual style to be applied to the CollapsibleSplitter control
    /// </summary>
    public enum CollpasibleVisualStyles
    {
        /// <summary>
        /// The mozilla
        /// </summary>
        Mozilla = 0,
        /// <summary>
        /// The xp
        /// </summary>
        XP,
        /// <summary>
        /// The win9x
        /// </summary>
        Win9x,
        /// <summary>
        /// The double dots
        /// </summary>
        DoubleDots,
        /// <summary>
        /// The lines
        /// </summary>
        Lines
    }

    /// <summary>
    /// Enumeration to specify the current animation state of the control.
    /// </summary>
    public enum SplitterState
    {
        /// <summary>
        /// The collapsed
        /// </summary>
        Collapsed = 0,
        /// <summary>
        /// The expanding
        /// </summary>
        Expanding,
        /// <summary>
        /// The expanded
        /// </summary>
        Expanded,
        /// <summary>
        /// The collapsing
        /// </summary>
        Collapsing
    }

    #endregion

    /// <summary>
    /// A custom collapsible splitter that can resize, hide and show associated form controls
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Splitter" />
    [ToolboxBitmap(typeof(ZeroitSidedCollapsibleSplitter))]
    //[DesignerAttribute(typeof(CollapsibleSplitterDesigner))]
    [Designer(typeof(ZeroitSidedCollapsibleSplitterDesigner))]
    public class ZeroitSidedCollapsibleSplitter : System.Windows.Forms.Splitter
    {
        #region Private Properties

        // declare and define some base properties
        /// <summary>
        /// The hot
        /// </summary>
        private bool hot;
        /// <summary>
        /// The hot color
        /// </summary>
        private System.Drawing.Color hotColor = CalculateColor(SystemColors.Highlight, SystemColors.Window, 70);
        /// <summary>
        /// The control to hide
        /// </summary>
        private System.Windows.Forms.Control controlToHide;
        /// <summary>
        /// The rr
        /// </summary>
        private System.Drawing.Rectangle rr;
        /// <summary>
        /// The parent form
        /// </summary>
        private System.Windows.Forms.Form parentForm;
        /// <summary>
        /// The expand parent form
        /// </summary>
        private bool expandParentForm;
        /// <summary>
        /// The visual style
        /// </summary>
        private CollpasibleVisualStyles visualStyle;

        // Border added in version 1.3
        /// <summary>
        /// The border style
        /// </summary>
        private System.Windows.Forms.Border3DStyle borderStyle = System.Windows.Forms.Border3DStyle.Flat;

        // animation controls introduced in version 1.22
        /// <summary>
        /// The animation timer
        /// </summary>
        private System.Windows.Forms.Timer animationTimer;
        /// <summary>
        /// The control width
        /// </summary>
        private int controlWidth;
        /// <summary>
        /// The control height
        /// </summary>
        private int controlHeight;
        /// <summary>
        /// The parent form width
        /// </summary>
        private int parentFormWidth;
        /// <summary>
        /// The parent form height
        /// </summary>
        private int parentFormHeight;
        /// <summary>
        /// The current state
        /// </summary>
        private SplitterState currentState;
        /// <summary>
        /// The animation delay
        /// </summary>
        private int animationDelay = 20;
        /// <summary>
        /// The animation step
        /// </summary>
        private int animationStep = 20;
        /// <summary>
        /// The use animations
        /// </summary>
        private bool useAnimations;

        #endregion

        #region Public Properties

        /// <summary>
        /// The initial state of the Splitter. Set to True if the control to hide is not visible by default
        /// </summary>
        /// <value><c>true</c> if this instance is collapsed; otherwise, <c>false</c>.</value>
        [Bindable(true), Category("Collapsing Options"), DefaultValue("False"),
        Description("The initial state of the Splitter. Set to True if the control to hide is not visible by default")]
        public bool IsCollapsed
        {
            get
            {
                if (this.controlToHide != null)
                    return !this.controlToHide.Visible;
                else
                    return true;
            }
        }

        /// <summary>
        /// The System.Windows.Forms.Control that the splitter will collapse
        /// </summary>
        /// <value>The control to hide.</value>
        [Bindable(true), Category("Collapsing Options"), DefaultValue(""),
        Description("The System.Windows.Forms.Control that the splitter will collapse")]
        public System.Windows.Forms.Control ControlToHide
        {
            get { return this.controlToHide; }
            set { this.controlToHide = value; }
        }

        /// <summary>
        /// Determines if the collapse and expanding actions will be animated
        /// </summary>
        /// <value><c>true</c> if [use animations]; otherwise, <c>false</c>.</value>
        [Bindable(true), Category("Collapsing Options"), DefaultValue("True"),
        Description("Determines if the collapse and expanding actions will be animated")]
        public bool UseAnimations
        {
            get { return this.useAnimations; }
            set { this.useAnimations = value; }
        }

        /// <summary>
        /// The delay in millisenconds between animation steps
        /// </summary>
        /// <value>The animation delay.</value>
        [Bindable(true), Category("Collapsing Options"), DefaultValue("20"),
        Description("The delay in millisenconds between animation steps")]
        public int AnimationDelay
        {
            get { return this.animationDelay; }
            set { this.animationDelay = value; }
        }

        /// <summary>
        /// The amount of pixels moved in each animation step
        /// </summary>
        /// <value>The animation step.</value>
        [Bindable(true), Category("Collapsing Options"), DefaultValue("20"),
        Description("The amount of pixels moved in each animation step")]
        public int AnimationStep
        {
            get { return this.animationStep; }
            set { this.animationStep = value; }
        }

        /// <summary>
        /// When true the entire parent form will be expanded and collapsed, otherwise just the contol to expand will be changed
        /// </summary>
        /// <value><c>true</c> if [expand parent form]; otherwise, <c>false</c>.</value>
        [Bindable(true), Category("Collapsing Options"), DefaultValue("False"),
        Description("When true the entire parent form will be expanded and collapsed, otherwise just the contol to expand will be changed")]
        public bool ExpandParentForm
        {
            get { return this.expandParentForm; }
            set { this.expandParentForm = value; }
        }

        /// <summary>
        /// The visual style that will be painted on the control
        /// </summary>
        /// <value>The visual style.</value>
        [Bindable(true), Category("Collapsing Options"), DefaultValue("VisualStyles.XP"),
        Description("The visual style that will be painted on the control")]
        public CollpasibleVisualStyles VisualStyle
        {
            get { return this.visualStyle; }
            set
            {
                this.visualStyle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// An optional border style to paint on the control. Set to Flat for no border
        /// </summary>
        /// <value>The border style3 d.</value>
        [Bindable(true), Category("Collapsing Options"), DefaultValue("System.Windows.Forms.Border3DStyle.Flat"),
        Description("An optional border style to paint on the control. Set to Flat for no border")]
        public System.Windows.Forms.Border3DStyle BorderStyle3D
        {
            get { return this.borderStyle; }
            set
            {
                this.borderStyle = value;
                this.Invalidate();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Toggles the state.
        /// </summary>
        public void ToggleState()
        {
            this.ToggleSplitter();
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSidedCollapsibleSplitter" /> class.
        /// </summary>
        public ZeroitSidedCollapsibleSplitter()
        {
            // Register mouse events
            this.Click += new System.EventHandler(OnClick);
            this.Resize += new System.EventHandler(OnResize);
            this.MouseLeave += new System.EventHandler(OnMouseLeave);
            this.MouseMove += new MouseEventHandler(OnMouseMove);

            // Setup the animation timer control
            this.animationTimer = new System.Windows.Forms.Timer();
            this.animationTimer.Interval = animationDelay;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimerTick);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.parentForm = this.FindForm();

            // set the current state
            if (this.controlToHide != null)
            {
                if (this.controlToHide.Visible)
                {
                    this.currentState = SplitterState.Expanded;
                }
                else
                {
                    this.currentState = SplitterState.Collapsed;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.EnabledChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnEnabledChanged(System.EventArgs e)
        {
            base.OnEnabledChanged(e);
            this.Invalidate();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // if the hider control isn't hot, let the base resize action occur
            if (this.controlToHide != null)
            {
                if (!this.hot && this.controlToHide.Visible)
                {
                    base.OnMouseDown(e);
                }
            }
        }

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnResize(object sender, System.EventArgs e)
        {
            this.Invalidate();
        }

        // this method was updated in version 1.11 to fix a flickering problem
        // discovered by John O'Byrne
        /// <summary>
        /// Handles the <see cref="E:MouseMove" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // check to see if the mouse cursor position is within the bounds of our control
            if (e.X >= rr.X && e.X <= rr.X + rr.Width && e.Y >= rr.Y && e.Y <= rr.Y + rr.Height)
            {
                if (!this.hot)
                {
                    this.hot = true;
                    this.Cursor = Cursors.Hand;
                    this.Invalidate();
                }
            }
            else
            {
                if (this.hot)
                {
                    this.hot = false;
                    this.Invalidate(); ;
                }

                this.Cursor = Cursors.Default;

                if (controlToHide != null)
                {
                    if (!controlToHide.Visible)
                        this.Cursor = Cursors.Default;
                    else // Changed in v1.2 to support Horizontal Splitters
                    {
                        if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                        {
                            this.Cursor = Cursors.VSplit;
                        }
                        else
                        {
                            this.Cursor = Cursors.HSplit;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the <see cref="E:MouseLeave" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnMouseLeave(object sender, System.EventArgs e)
        {
            // ensure that the hot state is removed
            this.hot = false;
            this.Invalidate(); ;
        }

        /// <summary>
        /// Handles the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnClick(object sender, System.EventArgs e)
        {
            if (controlToHide != null && hot &&
                currentState != SplitterState.Collapsing &&
                currentState != SplitterState.Expanding)
            {
                ToggleSplitter();
            }
        }

        /// <summary>
        /// Toggles the splitter.
        /// </summary>
        private void ToggleSplitter()
        {

            // if an animation is currently in progress for this control, drop out
            if (currentState == SplitterState.Collapsing || currentState == SplitterState.Expanding)
                return;

            controlWidth = controlToHide.Width;
            controlHeight = controlToHide.Height;

            if (controlToHide.Visible)
            {
                if (useAnimations)
                {
                    currentState = SplitterState.Collapsing;

                    if (parentForm != null)
                    {
                        if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                        {
                            parentFormWidth = parentForm.Width - controlWidth;
                        }
                        else
                        {
                            parentFormHeight = parentForm.Height - controlHeight;
                        }
                    }

                    this.animationTimer.Enabled = true;
                }
                else
                {
                    // no animations, so just toggle the visible state
                    currentState = SplitterState.Collapsed;
                    controlToHide.Visible = false;
                    if (expandParentForm && parentForm != null)
                    {
                        if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                        {
                            parentForm.Width -= controlToHide.Width;
                        }
                        else
                        {
                            parentForm.Height -= controlToHide.Height;
                        }
                    }
                }
            }
            else
            {
                // control to hide is collapsed
                if (useAnimations)
                {
                    currentState = SplitterState.Expanding;

                    if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                    {
                        if (parentForm != null)
                        {
                            parentFormWidth = parentForm.Width + controlWidth;
                        }
                        controlToHide.Width = 0;

                    }
                    else
                    {
                        if (parentForm != null)
                        {
                            parentFormHeight = parentForm.Height + controlHeight;
                        }
                        controlToHide.Height = 0;
                    }
                    controlToHide.Visible = true;
                    this.animationTimer.Enabled = true;
                }
                else
                {
                    // no animations, so just toggle the visible state
                    currentState = SplitterState.Expanded;
                    controlToHide.Visible = true;
                    if (expandParentForm && parentForm != null)
                    {
                        if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                        {
                            parentForm.Width += controlToHide.Width;
                        }
                        else
                        {
                            parentForm.Height += controlToHide.Height;
                        }
                    }
                }
            }

        }

        #endregion

        #region Implementation

        #region Animation Timer Tick

        /// <summary>
        /// Animations the timer tick.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void animationTimerTick(object sender, System.EventArgs e)
        {
            switch (currentState)
            {
                case SplitterState.Collapsing:

                    if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                    {
                        // vertical splitter
                        if (controlToHide.Width > animationStep)
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized
                                && parentForm != null)
                            {
                                parentForm.Width -= animationStep;
                            }
                            controlToHide.Width -= animationStep;
                        }
                        else
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized
                                && parentForm != null)
                            {
                                parentForm.Width = parentFormWidth;
                            }
                            controlToHide.Visible = false;
                            animationTimer.Enabled = false;
                            controlToHide.Width = controlWidth;
                            currentState = SplitterState.Collapsed;
                            this.Invalidate();
                        }
                    }
                    else
                    {
                        // horizontal splitter
                        if (controlToHide.Height > animationStep)
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized
                                && parentForm != null)
                            {
                                parentForm.Height -= animationStep;
                            }
                            controlToHide.Height -= animationStep;
                        }
                        else
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized
                                && parentForm != null)
                            {
                                parentForm.Height = parentFormHeight;
                            }
                            controlToHide.Visible = false;
                            animationTimer.Enabled = false;
                            controlToHide.Height = controlHeight;
                            currentState = SplitterState.Collapsed;
                            this.Invalidate();
                        }
                    }
                    break;

                case SplitterState.Expanding:

                    if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                    {
                        // vertical splitter
                        if (controlToHide.Width < (controlWidth - animationStep))
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized
                                && parentForm != null)
                            {
                                parentForm.Width += animationStep;
                            }
                            controlToHide.Width += animationStep;
                        }
                        else
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized
                                && parentForm != null)
                            {
                                parentForm.Width = parentFormWidth;
                            }
                            controlToHide.Width = controlWidth;
                            controlToHide.Visible = true;
                            animationTimer.Enabled = false;
                            currentState = SplitterState.Expanded;
                            this.Invalidate();
                        }
                    }
                    else
                    {
                        // horizontal splitter
                        if (controlToHide.Height < (controlHeight - animationStep))
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized
                                && parentForm != null)
                            {
                                parentForm.Height += animationStep;
                            }
                            controlToHide.Height += animationStep;
                        }
                        else
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized
                                && parentForm != null)
                            {
                                parentForm.Height = parentFormHeight;
                            }
                            controlToHide.Height = controlHeight;
                            controlToHide.Visible = true;
                            animationTimer.Enabled = false;
                            currentState = SplitterState.Expanded;
                            this.Invalidate();
                        }

                    }
                    break;
            }
        }

        #endregion

        #region Paint the control

        // OnPaint is now an override rather than an event in version 1.1
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        /// <exception cref="System.Exception">The Collapsible Splitter control cannot have the Filled or None Dockstyle property</exception>
        protected override void OnPaint(PaintEventArgs e)
        {
            // create a Graphics object
            Graphics g = e.Graphics;

            // find the rectangle for the splitter and paint it
            Rectangle r = this.ClientRectangle; // fixed in version 1.1
            g.FillRectangle(new SolidBrush(this.BackColor), r);

            #region Vertical Splitter
            // Check the docking style and create the control rectangle accordingly
            if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
            {
                // create a new rectangle in the vertical center of the splitter for our collapse control button
                rr = new Rectangle(r.X, (int)r.Y + ((r.Height - 115) / 2), 8, 115);
                // force the width to 8px so that everything always draws correctly
                this.Width = 8;

                // draw the background color for our control image
                if (hot)
                {
                    g.FillRectangle(new SolidBrush(hotColor), new Rectangle(rr.X + 1, rr.Y, 6, 115));
                }
                else
                {
                    g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(rr.X + 1, rr.Y, 6, 115));
                }

                // draw the top & bottom lines for our control image
                g.DrawLine(new Pen(SystemColors.ControlDark, 1), rr.X + 1, rr.Y, rr.X + rr.Width - 2, rr.Y);
                g.DrawLine(new Pen(SystemColors.ControlDark, 1), rr.X + 1, rr.Y + rr.Height, rr.X + rr.Width - 2, rr.Y + rr.Height);

                if (this.Enabled)
                {
                    // draw the arrows for our control image
                    // the ArrowPointArray is a point array that defines an arrow shaped polygon
                    g.FillPolygon(new SolidBrush(SystemColors.ControlDarkDark), ArrowPointArray(rr.X + 2, rr.Y + 3));
                    g.FillPolygon(new SolidBrush(SystemColors.ControlDarkDark), ArrowPointArray(rr.X + 2, rr.Y + rr.Height - 9));
                }

                // draw the dots for our control image using a loop
                int x = rr.X + 3;
                int y = rr.Y + 14;

                // Visual Styles added in version 1.1
                switch (visualStyle)
                {
                    case CollpasibleVisualStyles.Mozilla:

                        for (int i = 0; i < 30; i++)
                        {
                            // light dot
                            g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y + (i * 3), x + 1, y + 1 + (i * 3));
                            // dark dot
                            g.DrawLine(new Pen(SystemColors.ControlDarkDark), x + 1, y + 1 + (i * 3), x + 2, y + 2 + (i * 3));
                            // overdraw the background color as we actually drew 2px diagonal lines, not just dots
                            if (hot)
                            {
                                g.DrawLine(new Pen(hotColor), x + 2, y + 1 + (i * 3), x + 2, y + 2 + (i * 3));
                            }
                            else
                            {
                                g.DrawLine(new Pen(this.BackColor), x + 2, y + 1 + (i * 3), x + 2, y + 2 + (i * 3));
                            }
                        }
                        break;

                    case CollpasibleVisualStyles.DoubleDots:
                        for (int i = 0; i < 30; i++)
                        {
                            // light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLightLight), x, y + 1 + (i * 3), 1, 1);
                            // dark dot
                            g.DrawRectangle(new Pen(SystemColors.ControlDark), x - 1, y + (i * 3), 1, 1);
                            i++;
                            // light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLightLight), x + 2, y + 1 + (i * 3), 1, 1);
                            // dark dot
                            g.DrawRectangle(new Pen(SystemColors.ControlDark), x + 1, y + (i * 3), 1, 1);
                        }
                        break;

                    case CollpasibleVisualStyles.Win9x:

                        g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y, x + 2, y);
                        g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y, x, y + 90);
                        g.DrawLine(new Pen(SystemColors.ControlDark), x + 2, y, x + 2, y + 90);
                        g.DrawLine(new Pen(SystemColors.ControlDark), x, y + 90, x + 2, y + 90);
                        break;

                    case CollpasibleVisualStyles.XP:

                        for (int i = 0; i < 18; i++)
                        {
                            // light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLight), x, y + (i * 5), 2, 2);
                            // light light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLightLight), x + 1, y + 1 + (i * 5), 1, 1);
                            // dark dark dot
                            g.DrawRectangle(new Pen(SystemColors.ControlDarkDark), x, y + (i * 5), 1, 1);
                            // dark fill
                            g.DrawLine(new Pen(SystemColors.ControlDark), x, y + (i * 5), x, y + (i * 5) + 1);
                            g.DrawLine(new Pen(SystemColors.ControlDark), x, y + (i * 5), x + 1, y + (i * 5));
                        }
                        break;

                    case CollpasibleVisualStyles.Lines:

                        for (int i = 0; i < 44; i++)
                        {
                            g.DrawLine(new Pen(SystemColors.ControlDark), x, y + (i * 2), x + 2, y + (i * 2));
                        }

                        break;
                }

                // Added in version 1.3
                if (this.borderStyle != System.Windows.Forms.Border3DStyle.Flat)
                {
                    // Paint the control border
                    ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, this.borderStyle, Border3DSide.Left);
                    ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, this.borderStyle, Border3DSide.Right);
                }
            }

            #endregion

            // Horizontal Splitter support added in v1.2

            #region Horizontal Splitter

            else if (this.Dock == DockStyle.Top || this.Dock == DockStyle.Bottom)
            {
                // create a new rectangle in the horizontal center of the splitter for our collapse control button
                rr = new Rectangle((int)r.X + ((r.Width - 115) / 2), r.Y, 115, 8);
                // force the height to 8px
                this.Height = 8;

                // draw the background color for our control image
                if (hot)
                {
                    g.FillRectangle(new SolidBrush(hotColor), new Rectangle(rr.X, rr.Y + 1, 115, 6));
                }
                else
                {
                    g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(rr.X, rr.Y + 1, 115, 6));
                }

                // draw the left & right lines for our control image
                g.DrawLine(new Pen(SystemColors.ControlDark, 1), rr.X, rr.Y + 1, rr.X, rr.Y + rr.Height - 2);
                g.DrawLine(new Pen(SystemColors.ControlDark, 1), rr.X + rr.Width, rr.Y + 1, rr.X + rr.Width, rr.Y + rr.Height - 2);

                if (this.Enabled)
                {
                    // draw the arrows for our control image
                    // the ArrowPointArray is a point array that defines an arrow shaped polygon
                    g.FillPolygon(new SolidBrush(SystemColors.ControlDarkDark), ArrowPointArray(rr.X + 3, rr.Y + 2));
                    g.FillPolygon(new SolidBrush(SystemColors.ControlDarkDark), ArrowPointArray(rr.X + rr.Width - 9, rr.Y + 2));
                }

                // draw the dots for our control image using a loop
                int x = rr.X + 14;
                int y = rr.Y + 3;

                // Visual Styles added in version 1.1
                switch (visualStyle)
                {
                    case CollpasibleVisualStyles.Mozilla:

                        for (int i = 0; i < 30; i++)
                        {
                            // light dot
                            g.DrawLine(new Pen(SystemColors.ControlLightLight), x + (i * 3), y, x + 1 + (i * 3), y + 1);
                            // dark dot
                            g.DrawLine(new Pen(SystemColors.ControlDarkDark), x + 1 + (i * 3), y + 1, x + 2 + (i * 3), y + 2);
                            // overdraw the background color as we actually drew 2px diagonal lines, not just dots
                            if (hot)
                            {
                                g.DrawLine(new Pen(hotColor), x + 1 + (i * 3), y + 2, x + 2 + (i * 3), y + 2);
                            }
                            else
                            {
                                g.DrawLine(new Pen(this.BackColor), x + 1 + (i * 3), y + 2, x + 2 + (i * 3), y + 2);
                            }
                        }
                        break;

                    case CollpasibleVisualStyles.DoubleDots:

                        for (int i = 0; i < 30; i++)
                        {
                            // light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLightLight), x + 1 + (i * 3), y, 1, 1);
                            // dark dot
                            g.DrawRectangle(new Pen(SystemColors.ControlDark), x + (i * 3), y - 1, 1, 1);
                            i++;
                            // light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLightLight), x + 1 + (i * 3), y + 2, 1, 1);
                            // dark dot
                            g.DrawRectangle(new Pen(SystemColors.ControlDark), x + (i * 3), y + 1, 1, 1);
                        }
                        break;

                    case CollpasibleVisualStyles.Win9x:

                        g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y, x, y + 2);
                        g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y, x + 88, y);
                        g.DrawLine(new Pen(SystemColors.ControlDark), x, y + 2, x + 88, y + 2);
                        g.DrawLine(new Pen(SystemColors.ControlDark), x + 88, y, x + 88, y + 2);
                        break;

                    case CollpasibleVisualStyles.XP:

                        for (int i = 0; i < 18; i++)
                        {
                            // light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLight), x + (i * 5), y, 2, 2);
                            // light light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLightLight), x + 1 + (i * 5), y + 1, 1, 1);
                            // dark dark dot
                            g.DrawRectangle(new Pen(SystemColors.ControlDarkDark), x + (i * 5), y, 1, 1);
                            // dark fill
                            g.DrawLine(new Pen(SystemColors.ControlDark), x + (i * 5), y, x + (i * 5) + 1, y);
                            g.DrawLine(new Pen(SystemColors.ControlDark), x + (i * 5), y, x + (i * 5), y + 1);
                        }
                        break;

                    case CollpasibleVisualStyles.Lines:

                        for (int i = 0; i < 44; i++)
                        {
                            g.DrawLine(new Pen(SystemColors.ControlDark), x + (i * 2), y, x + (i * 2), y + 2);
                        }

                        break;
                }

                // Added in version 1.3
                if (this.borderStyle != System.Windows.Forms.Border3DStyle.Flat)
                {
                    // Paint the control border
                    ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, this.borderStyle, Border3DSide.Top);
                    ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, this.borderStyle, Border3DSide.Bottom);
                }
            }

            #endregion

            else
            {
                throw new Exception("The Collapsible Splitter control cannot have the Filled or None Dockstyle property");
            }



            // dispose the Graphics object
            g.Dispose();
        }
        #endregion

        #region Arrow Polygon Array

        // This creates a point array to draw a arrow-like polygon
        /// <summary>
        /// Arrows the point array.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>Point[].</returns>
        private Point[] ArrowPointArray(int x, int y)
        {
            Point[] point = new Point[3];

            if (controlToHide != null)
            {
                // decide which direction the arrow will point
                if (
                    (this.Dock == DockStyle.Right && controlToHide.Visible)
                    || (this.Dock == DockStyle.Left && !controlToHide.Visible)
                    )
                {
                    // right arrow
                    point[0] = new Point(x, y);
                    point[1] = new Point(x + 3, y + 3);
                    point[2] = new Point(x, y + 6);
                }
                else if (
                    (this.Dock == DockStyle.Right && !controlToHide.Visible)
                    || (this.Dock == DockStyle.Left && controlToHide.Visible)
                    )
                {
                    // left arrow
                    point[0] = new Point(x + 3, y);
                    point[1] = new Point(x, y + 3);
                    point[2] = new Point(x + 3, y + 6);
                }

                // Up/Down arrows added in v1.2

                else if (
                    (this.Dock == DockStyle.Top && controlToHide.Visible)
                    || (this.Dock == DockStyle.Bottom && !controlToHide.Visible)
                    )
                {
                    // up arrow
                    point[0] = new Point(x + 3, y);
                    point[1] = new Point(x + 6, y + 4);
                    point[2] = new Point(x, y + 4);
                }
                else if (
                    (this.Dock == DockStyle.Top && !controlToHide.Visible)
                    || (this.Dock == DockStyle.Bottom && controlToHide.Visible)
                    )
                {
                    // down arrow
                    point[0] = new Point(x, y);
                    point[1] = new Point(x + 6, y);
                    point[2] = new Point(x + 3, y + 3);
                }
            }

            return point;
        }

        #endregion

        #region Color Calculator

        // this method was borrowed from the RichUI Control library by Sajith M
        /// <summary>
        /// Calculates the color.
        /// </summary>
        /// <param name="front">The front.</param>
        /// <param name="back">The back.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns>Color.</returns>
        private static Color CalculateColor(Color front, Color back, int alpha)
        {
            // solid color obtained as a result of alpha-blending

            Color frontColor = Color.FromArgb(255, front);
            Color backColor = Color.FromArgb(255, back);

            float frontRed = frontColor.R;
            float frontGreen = frontColor.G;
            float frontBlue = frontColor.B;
            float backRed = backColor.R;
            float backGreen = backColor.G;
            float backBlue = backColor.B;

            float fRed = frontRed * alpha / 255 + backRed * ((float)(255 - alpha) / 255);
            byte newRed = (byte)fRed;
            float fGreen = frontGreen * alpha / 255 + backGreen * ((float)(255 - alpha) / 255);
            byte newGreen = (byte)fGreen;
            float fBlue = frontBlue * alpha / 255 + backBlue * ((float)(255 - alpha) / 255);
            byte newBlue = (byte)fBlue;

            return Color.FromArgb(255, newRed, newGreen, newBlue);
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// A simple designer class for the CollapsibleSplitter control to remove
    /// unwanted properties at design time.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    public class CollapsibleSplitterDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollapsibleSplitterDesigner"/> class.
        /// </summary>
        public CollapsibleSplitterDesigner()
        {
        }

        /// <summary>
        /// Adjusts the set of properties the component exposes through a <see cref="T:System.ComponentModel.TypeDescriptor" />.
        /// </summary>
        /// <param name="properties">An <see cref="T:System.Collections.IDictionary" /> containing the properties for the class of the component.</param>
        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            properties.Remove("IsCollapsed");
            properties.Remove("BorderStyle");
            properties.Remove("Size");
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitSidedCollapsibleSplitterDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitSidedCollapsibleSplitterDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitSidedCollapsibleSplitterDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitSidedCollapsibleSplitterSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }

        /// <summary>
        /// Adjusts the set of properties the component exposes through a <see cref="T:System.ComponentModel.TypeDescriptor" />.
        /// </summary>
        /// <param name="properties">An <see cref="T:System.Collections.IDictionary" /> containing the properties for the class of the component.</param>
        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            //properties.Remove("IsCollapsed");
            //properties.Remove("BorderStyle");
            //properties.Remove("Size");
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitSidedCollapsibleSplitterSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitSidedCollapsibleSplitterSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitSidedCollapsibleSplitter colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSidedCollapsibleSplitterSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitSidedCollapsibleSplitterSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitSidedCollapsibleSplitter;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="System.ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance is collapsed.
        /// </summary>
        /// <value><c>true</c> if this instance is collapsed; otherwise, <c>false</c>.</value>
        public bool IsCollapsed
        {
            get
            {
                return colUserControl.IsCollapsed;
            }
            set
            {
                GetPropertyByName("IsCollapsed").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use animations].
        /// </summary>
        /// <value><c>true</c> if [use animations]; otherwise, <c>false</c>.</value>
        public bool UseAnimations
        {
            get
            {
                return colUserControl.UseAnimations;
            }
            set
            {
                GetPropertyByName("UseAnimations").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [expand parent form].
        /// </summary>
        /// <value><c>true</c> if [expand parent form]; otherwise, <c>false</c>.</value>
        public bool ExpandParentForm
        {
            get
            {
                return colUserControl.ExpandParentForm;
            }
            set
            {
                GetPropertyByName("ExpandParentForm").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the control to hide.
        /// </summary>
        /// <value>The control to hide.</value>
        public System.Windows.Forms.Control ControlToHide
        {
            get
            {
                return colUserControl.ControlToHide;
            }
            set
            {
                GetPropertyByName("ControlToHide").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the animation delay.
        /// </summary>
        /// <value>The animation delay.</value>
        public int AnimationDelay
        {
            get
            {
                return colUserControl.AnimationDelay;
            }
            set
            {
                GetPropertyByName("AnimationDelay").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the animation step.
        /// </summary>
        /// <value>The animation step.</value>
        public int AnimationStep
        {
            get
            {
                return colUserControl.AnimationStep;
            }
            set
            {
                GetPropertyByName("AnimationStep").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the visual style.
        /// </summary>
        /// <value>The visual style.</value>
        public CollpasibleVisualStyles VisualStyle
        {
            get
            {
                return colUserControl.VisualStyle;
            }
            set
            {
                GetPropertyByName("VisualStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border style3 d.
        /// </summary>
        /// <value>The border style3 d.</value>
        public System.Windows.Forms.Border3DStyle BorderStyle3D
        {
            get
            {
                return colUserControl.BorderStyle3D;
            }
            set
            {
                GetPropertyByName("BorderStyle3D").SetValue(colUserControl, value);
            }
        }

        #endregion

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("IsCollapsed",
                                 "Is Collapsed", "Appearance",
                                 "Set to enable the control to be either collapsible or not."));

            items.Add(new DesignerActionPropertyItem("UseAnimations",
                                 "Use Animations", "Appearance",
                                 "Set to enable the use of animations."));

            items.Add(new DesignerActionPropertyItem("ExpandParentForm",
                                 "Expand Parent Form", "Appearance",
                                 "Set to allow parent form to be either expandable or not."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("ControlToHide",
                                 "Control To Hide", "Appearance",
                                 "Select the control to hide."));

            items.Add(new DesignerActionPropertyItem("AnimationDelay",
                                 "Animation Delay", "Appearance",
                                 "Set the animation delay."));

            items.Add(new DesignerActionPropertyItem("AnimationStep",
                                 "Animation Step", "Appearance",
                                 "Set the animation step."));

            items.Add(new DesignerActionPropertyItem("VisualStyle",
                                 "Visual Style", "Appearance",
                                 "Set the animation style."));

            items.Add(new DesignerActionPropertyItem("BorderStyle3D",
                                 "Border Style 3D", "Appearance",
                                 "Set the border style."));

            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion


    #endregion
}
