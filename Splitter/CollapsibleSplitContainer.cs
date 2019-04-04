// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CollapsibleSplitContainer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Zeroit.Framework.MiscControls
{
    #region Collapsible Split Container

    /// <summary>
    /// Enum representing the Button Position for <c><see cref="ZeroitCollapsibleSplitContainer" /></c>.
    /// </summary>
    public enum ButtonPosition
    {
        /// <summary>
        /// The top left
        /// </summary>
        TopLeft,
        /// <summary>
        /// The center
        /// </summary>
        Center,
        /// <summary>
        /// The bottom right
        /// </summary>
        BottomRight
    }
    /// <summary>
    /// Enum representing the Button Style for <c><see cref="ZeroitCollapsibleSplitContainer" /></c>.
    /// </summary>
    public enum ButtonStyle
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The image
        /// </summary>
        Image,
        /// <summary>
        /// The push button
        /// </summary>
        PushButton,
        /// <summary>
        /// The scroll bar
        /// </summary>
        ScrollBar
    };
    /// <summary>
    /// Enum representing Collapse Distance for <c><see cref="ZeroitCollapsibleSplitContainer" /></c>.
    /// </summary>
    public enum CollapseDistance
    {
        /// <summary>
        /// The minimum size
        /// </summary>
        MinSize,
        /// <summary>
        /// The collapsed
        /// </summary>
        Collapsed
    };

    /// <summary>
    /// A class collection for rendering a collapsible split container.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.SplitContainer" />
    /// <seealso cref="System.ComponentModel.ISupportInitialize" />
    [ToolboxBitmap(typeof(ZeroitCollapsibleSplitContainer), "Resources.collapsesplit.bmp")]
    //[Designer(typeof(ZeroitCollapsibleSplitContainerDesigner))]
    public class ZeroitCollapsibleSplitContainer : SplitContainer, ISupportInitialize
    {
        #region Variables
        /// <summary>
        /// The panel1 minimized
        /// </summary>
        private bool panel1Minimized = false, panel2Minimized = false;
        /// <summary>
        /// The splitter focus hide
        /// </summary>
        private bool splitterFocusHide = false;
        /// <summary>
        /// The splitter vertical
        /// </summary>
        private bool splitterVertical = true;
        /// <summary>
        /// The splitter distance original
        /// </summary>
        private int splitterDistanceOriginal = 0;

        /// <summary>
        /// The button1 state
        /// </summary>
        private ScrollBarArrowButtonState button1State = ScrollBarArrowButtonState.LeftNormal;
        /// <summary>
        /// The button2 state
        /// </summary>
        private ScrollBarArrowButtonState button2State = ScrollBarArrowButtonState.RightNormal;

        // Used for various hit tests
        /// <summary>
        /// The rect left down
        /// </summary>
        private Rectangle rectLeftDown, rectRightUp;

        // Left-oriented bitmap from which the other three directional bitmaps are derived
        /// <summary>
        /// The splitter button bitmap
        /// </summary>
        private Bitmap splitterButtonBitmap = null;
        /// <summary>
        /// The bitmap right
        /// </summary>
        private Bitmap bitmapRight = null, bitmapUp = null, bitmapDown = null;

        // Property fields
        /// <summary>
        /// The splitter button position
        /// </summary>
        private ButtonPosition splitterButtonPosition = ButtonPosition.TopLeft;
        /// <summary>
        /// The splitter button style
        /// </summary>
        private ButtonStyle splitterButtonStyle = ButtonStyle.None;
        /// <summary>
        /// The splitter collapse distance
        /// </summary>
        private CollapseDistance splitterCollapseDistance = CollapseDistance.MinSize;
        /// <summary>
        /// The current orientation
        /// </summary>
        private Orientation currentOrientation = Orientation.Vertical;

        // Embedded cursor resources
        /// <summary>
        /// The pointer
        /// </summary>
        private Cursor pointer = new Cursor(typeof(ZeroitCollapsibleSplitContainer), "Resources.pointer.cur");
        /// <summary>
        /// The pointer no
        /// </summary>
        private Cursor pointer_no = new Cursor(typeof(ZeroitCollapsibleSplitContainer), "Resources.pointer_no.cur");
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCollapsibleSplitContainer" /> class.
        /// </summary>
        public ZeroitCollapsibleSplitContainer()
        {
            // Bug fix for SplitContainer problems with flickering and resizing
            ControlStyles cs = ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer;
            this.SetStyle(cs, true);
            object[] objArgs = new object[] { cs, true };
            MethodInfo objMethodInfo = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
            objMethodInfo.Invoke(this.Panel1, objArgs);
            objMethodInfo.Invoke(this.Panel2, objArgs);
        }

        #region Properties        
        /// <summary>
        /// Gets or sets the splitter button bitmap.
        /// </summary>
        /// <value>The splitter button bitmap.</value>
        [Category("Collapsible"), Description("The bitmap used on the splitter pushbuttons")]
        [DefaultValue(null)]
        public Bitmap SplitterButtonBitmap
        {
            get { return splitterButtonBitmap; }
            set
            {
                if (splitterButtonBitmap != value)
                {
                    splitterButtonBitmap = value;

                    if (splitterButtonBitmap == null)
                    {
                        bitmapRight = null;
                        bitmapUp = null;
                        bitmapDown = null;
                    }
                    else
                    {
                        splitterButtonBitmap.MakeTransparent();

                        // Create the bitmaps for the remaining directions
                        bitmapRight = (Bitmap)splitterButtonBitmap.Clone();
                        bitmapRight.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        bitmapUp = (Bitmap)splitterButtonBitmap.Clone();
                        bitmapUp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        bitmapDown = (Bitmap)splitterButtonBitmap.Clone();
                        bitmapDown.RotateFlip(RotateFlipType.Rotate270FlipNone);

                        // Reset the splitter width
                        this.SplitterWidth = splitterButtonBitmap.Width;
                    }

                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the splitter button position.
        /// </summary>
        /// <value>The splitter button position.</value>
        [Category("Collapsible"), Description("Where the collapse buttons are located on the splitter")]
        [DefaultValue(ButtonPosition.TopLeft)]
        public ButtonPosition SplitterButtonPosition
        {
            get { return splitterButtonPosition; }
            set
            {
                if (splitterButtonPosition != value)
                {
                    splitterButtonPosition = value;
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the splitter button style. The technique used to generate the splitter buttons.
        /// </summary>
        /// <value>The splitter button style.</value>
        [Category("Collapsible"), Description("The technique used to generate the splitter buttons")]
        [DefaultValue(ButtonStyle.None)]
        public ButtonStyle SplitterButtonStyle
        {
            get { return splitterButtonStyle; }
            set
            {
                if (splitterButtonStyle != value)
                {
                    splitterButtonStyle = value;
                    SetButtonState();
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the splitter collapse distance.
        /// </summary>
        /// <value>The splitter collapse distance.</value>
        [Category("Collapsible"), Description("How completely the affected panel collapses")]
        [DefaultValue(CollapseDistance.MinSize)]
        public CollapseDistance SplitterCollapseDistance
        {
            get { return splitterCollapseDistance; }
            set
            {
                if (splitterCollapseDistance != value)
                {
                    if (value == CollapseDistance.MinSize)
                    {
                        if (this.Panel1Collapsed)
                        {
                            panel1Minimized = true;
                            this.SplitterDistance = this.Panel1MinSize;
                        }
                        else if (this.Panel2Collapsed)
                        {
                            panel2Minimized = true;

                            // Calculate the splitter position
                            int distance = -1 * (this.Panel2MinSize + this.SplitterWidth);
                            if (splitterVertical) distance += this.Panel1.Width;
                            else distance += this.Panel1.Height;

                            this.SplitterDistance = distance;
                        }

                        this.Panel1Collapsed = false;
                        this.Panel2Collapsed = false;
                    }
                    else if (value == CollapseDistance.Collapsed)
                    {
                        if (panel1Minimized) { this.Panel1Collapsed = true; }
                        else if (panel2Minimized) { this.Panel2Collapsed = true; }

                        panel1Minimized = false;
                        panel2Minimized = false;
                    }

                    splitterCollapseDistance = value;
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the focus rectangle shows on the splitter.
        /// </summary>
        /// <value><c>true</c> if splitter focus hide; otherwise, <c>false</c>.</value>
        [Category("Collapsible"), Description("Whether the focus rectangle shows on the splitter")]
        [DefaultValue(false)]
        public bool SplitterFocusHide
        {
            get { return splitterFocusHide; }
            set
            {
                if (splitterFocusHide != value)
                {
                    splitterFocusHide = value;
                    this.Refresh();
                }
            }
        }

        // Forces designer to refresh and reflect changes to the property        
        /// <summary>
        /// Gets or sets a value indicating whether the splitter is fixed or movable.
        /// </summary>
        /// <value><c>true</c> if this instance is splitter fixed; otherwise, <c>false</c>.</value>
        public new bool IsSplitterFixed
        {
            get { return base.IsSplitterFixed; }
            set
            {
                if (base.IsSplitterFixed != value)
                {
                    base.IsSplitterFixed = value;
                    this.Refresh();
                }
            }
        }
        #endregion

        #region General Event Handlers
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.BackgroundImageChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);

            // Add image transparency for bitmap background images. Base class
            // supports it for PNG and GIF but not bitmap format
            if (this.BackgroundImage != null)
            {
                ((Bitmap)this.BackgroundImage).MakeTransparent();
                this.Refresh();
            }
        }

        // Redraw the buttons after the splitter is tabbed into
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (splitterButtonStyle == ButtonStyle.None) { return; }
            this.Invalidate();
        }

        // Force redraw of splitter after change in layout
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Layout" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.LayoutEventArgs" /> that contains the event data.</param>
        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);

            // Store current orientation value. Adjust buttons to orientation
            if (currentOrientation != this.Orientation)
            {
                currentOrientation = this.Orientation;
                splitterVertical = (currentOrientation == Orientation.Vertical) ? true : false;

                // Reset cursor and buttons
                SetButtonState();
            }

            this.Invalidate();
        }

        // Paint splitter and, if enabled, the buttons
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.IsSplitterFixed) { return; }

            // Do nothing if buttons are disabled. If FocusHide is enabled,
            // redraw the splitter background to hide the focus rectangle
            if (splitterButtonStyle == ButtonStyle.None || (splitterButtonStyle == ButtonStyle.Image && splitterButtonBitmap == null))
            {
                if (splitterFocusHide) { DrawSplitterBackground(e.Graphics); }
                return;
            }

            if (this.Panel1Collapsed || this.Panel2Collapsed) { return; }

            SetButtonDimensions();

            // Draw the splitter surface and buttons
            DrawSplitterBackground(e.Graphics);
            DrawSplitterFocus(e.Graphics);
            DrawSplitterButtons(e.Graphics);
        }
        #endregion

        #region Mouse Event Handlers
        // Change the button state to Pressed. Default OnMouseDown processing activates
        // the halftone hatch pattern that is shown when the splitter is dragged. There
        // is no way to disable the hatch without a major rewrite of the base class
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Do default processing and return if the buttons are disabled
            if (splitterButtonStyle == ButtonStyle.None)
            {
                base.OnMouseDown(e);
                return;
            }

            // When mouse is over a button, change the state. Otherwise, do default processing
            if (IsHotLeftDown())
            {
                if (splitterVertical) { button1State = ScrollBarArrowButtonState.LeftPressed; }
                else { button2State = ScrollBarArrowButtonState.DownPressed; }
                this.Invalidate();
            }
            else if (IsHotRightUp())
            {
                if (splitterVertical) { button2State = ScrollBarArrowButtonState.RightPressed; }
                else { button1State = ScrollBarArrowButtonState.UpPressed; }
                this.Invalidate();
            }
            else base.OnMouseDown(e);
        }

        // Set a new splitter location based on which button was pushed and the current ButtonStyle
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (splitterButtonStyle == ButtonStyle.None) { return; }

            if (splitterCollapseDistance == CollapseDistance.Collapsed)
            {
                // Hide the panel associated with the clicked button
                if (IsHotLeftDown())
                {
                    if (splitterVertical) { this.Panel1Collapsed = true; }
                    else { this.Panel2Collapsed = true; }
                }
                else if (IsHotRightUp())
                {
                    if (splitterVertical) { this.Panel2Collapsed = true; }
                    else { this.Panel1Collapsed = true; }
                }
            }
            else if (splitterCollapseDistance == CollapseDistance.MinSize)
            {
                // If the panel for the clicked button is already minimized, do nothing
                // Otherwise, have the panel shrink to or return from the minimum size
                if ((splitterVertical && IsHotLeftDown()) || (!splitterVertical && IsHotRightUp()))
                {
                    if (panel1Minimized) { return; }
                    else if (panel2Minimized) // Panel 2
                    {
                        this.SplitterDistance = splitterDistanceOriginal;
                        panel2Minimized = false;
                    }
                    else // Panel 1
                    {
                        splitterDistanceOriginal = this.SplitterDistance;
                        this.SplitterDistance = this.Panel1MinSize;
                        panel1Minimized = true;
                    }
                }
                else if ((!splitterVertical && IsHotLeftDown()) || (splitterVertical && IsHotRightUp()))
                {
                    if (panel2Minimized) { return; }
                    else if (panel1Minimized) // Panel 1
                    {
                        this.SplitterDistance = splitterDistanceOriginal;
                        panel1Minimized = false;
                    }
                    else // Panel 2
                    {
                        splitterDistanceOriginal = this.SplitterDistance;

                        // When the splitter is vertical, set the location of the splitter to
                        // the splitcontainer control width minus the minimum size of panel 2.
                        // For horizontal, set it to height minus panel 2 minimum size
                        if (splitterVertical) { this.SplitterDistance = this.Width - this.Panel2MinSize; }
                        else { this.SplitterDistance = this.Height - this.Panel2MinSize; }

                        panel2Minimized = true;
                    }
                }
            }

            this.Refresh();
        }

        // Set the cursor and button state when the mouse is over a button
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            SetButtonState();
            SetCursor();
        }

        // Set the cursor and button state when the mouse enters the button region
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            SetButtonState();
        }

        // Reset the cursor and button state when the mouse leaves
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            SetButtonState();
            Cursor = Cursors.Default;
        }
        #endregion

        #region Drawing Routines
        // Fill the splitter background with the background color and image
        /// <summary>
        /// Draws the splitter background.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawSplitterBackground(Graphics g)
        {
            Color backcolor = this.BackColor;
            if (backcolor == Color.Transparent)
            {
                // Find the base color that underlies transparency
                Control parent = this.Parent;
                while (parent.BackColor == Color.Transparent)
                {
                    parent = parent.Parent;
                }
                backcolor = parent.BackColor;
            }

            // Paint the background with the underlying background color
            using (SolidBrush brush = new SolidBrush(backcolor))
            {
                g.FillRectangle(brush, this.SplitterRectangle);
            }

            // Draw the background image if present
            if (this.BackgroundImage != null)
            {
                // Use a texture brush to replicate base class tiling
                using (TextureBrush brush = new TextureBrush(this.BackgroundImage))
                {
                    g.FillRectangle(brush, this.SplitterRectangle);
                }
            }
        }

        // Draw the modified focus rectangle if focus is not hidden
        /// <summary>
        /// Draws the splitter focus.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawSplitterFocus(Graphics g)
        {
            if (splitterButtonStyle == ButtonStyle.None) return;

            if (this.Focused && !splitterFocusHide)
            {
                Rectangle focus = new Rectangle(this.SplitterRectangle.Location, this.SplitterRectangle.Size);

                // Draw the focus rectangle to the left/top of the buttons
                if (splitterVertical) { focus.Height = rectLeftDown.Top; }
                else { focus.Width = rectLeftDown.Left; }
                focus.Inflate(-1, -1);
                ControlPaint.DrawFocusRectangle(g, focus, this.ForeColor, this.BackColor);

                // Draw the focus rectangle to the right/bottom of the buttons
                if (splitterVertical)
                {
                    focus.Location = new Point(rectRightUp.Left, rectRightUp.Bottom);
                    focus.Size = new Size(rectRightUp.Width, this.SplitterRectangle.Bottom - rectRightUp.Bottom);
                }
                else
                {
                    focus.Location = new Point(rectRightUp.Right + 1, rectRightUp.Top);
                    focus.Size = new Size(this.SplitterRectangle.Right - rectRightUp.Right - 1, rectRightUp.Height);
                }
                focus.Inflate(-1, -1);
                ControlPaint.DrawFocusRectangle(g, focus, this.ForeColor, this.BackColor);
            }
        }

        // Render the splitter buttons based on system capability and button style
        /// <summary>
        /// Draws the splitter buttons.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawSplitterButtons(Graphics g)
        {
            if (splitterButtonStyle == ButtonStyle.Image)
            {
                if (!panel1Minimized)
                {
                    if (splitterVertical) { g.DrawImage(splitterButtonBitmap, rectLeftDown); }
                    else { g.DrawImage(bitmapUp, rectRightUp); }
                }

                if (!panel2Minimized)
                {
                    if (splitterVertical) { g.DrawImage(bitmapRight, rectRightUp); }
                    else { g.DrawImage(bitmapDown, rectLeftDown); }
                }
            }
            else if (splitterButtonStyle == ButtonStyle.PushButton)
            {
                // Map ScrollBarArrowButtonStates to PushButtonStates
                PushButtonState pbs1 = (PushButtonState)((int)button1State & 3);
                PushButtonState pbs2 = (PushButtonState)((int)button2State & 3);

                if (!panel1Minimized)
                {
                    if (splitterVertical) { ButtonRenderer.DrawButton(g, rectLeftDown, pbs1); }
                    else { ButtonRenderer.DrawButton(g, rectRightUp, pbs1); }

                    if (splitterButtonBitmap != null)
                    {
                        if (splitterVertical) { g.DrawImage(splitterButtonBitmap, rectLeftDown); }
                        else { g.DrawImage(bitmapUp, rectRightUp); }
                    }
                }

                if (!panel2Minimized)
                {
                    if (splitterVertical) { ButtonRenderer.DrawButton(g, rectRightUp, pbs2); }
                    else { ButtonRenderer.DrawButton(g, rectLeftDown, pbs2); }

                    if (splitterButtonBitmap != null)
                    {
                        if (splitterVertical) { g.DrawImage(bitmapRight, rectRightUp); }
                        else { g.DrawImage(bitmapDown, rectLeftDown); }
                    }
                }
            }
            else if (ScrollBarRenderer.IsSupported && splitterButtonStyle == ButtonStyle.ScrollBar)
            {
                if (!panel1Minimized)
                {
                    if (splitterVertical) { ScrollBarRenderer.DrawArrowButton(g, rectLeftDown, button1State); }
                    else { ScrollBarRenderer.DrawArrowButton(g, rectRightUp, button1State); }
                }

                if (!panel2Minimized)
                {
                    if (splitterVertical) { ScrollBarRenderer.DrawArrowButton(g, rectRightUp, button2State); }
                    else { ScrollBarRenderer.DrawArrowButton(g, rectLeftDown, button2State); }
                }
            }
        }
        #endregion

        #region Miscellaneous Helpers
        // Tests for button hot state
        /// <summary>
        /// Determines whether [is hot left down].
        /// </summary>
        /// <returns><c>true</c> if [is hot left down]; otherwise, <c>false</c>.</returns>
        private bool IsHotLeftDown() { return rectLeftDown.Contains(PointToClient(MousePosition)); }
        /// <summary>
        /// Determines whether [is hot right up].
        /// </summary>
        /// <returns><c>true</c> if [is hot right up]; otherwise, <c>false</c>.</returns>
        private bool IsHotRightUp() { return rectRightUp.Contains(PointToClient(MousePosition)); }

        // Set the button state to hot or normal
        /// <summary>
        /// Sets the state of the button.
        /// </summary>
        private void SetButtonState()
        {
            if (SplitterButtonStyle == ButtonStyle.None) { return; }

            // Set button states for Left and Down buttons
            if (IsHotLeftDown())
            {
                if (splitterVertical) { button1State = ScrollBarArrowButtonState.LeftHot; }
                else { button2State = ScrollBarArrowButtonState.DownHot; }
            }
            else
            {
                if (splitterVertical) { button1State = ScrollBarArrowButtonState.LeftNormal; }
                else { button2State = ScrollBarArrowButtonState.DownNormal; }
            }

            // Set button states for Right and Up buttons
            if (IsHotRightUp())
            {
                if (splitterVertical) { button2State = ScrollBarArrowButtonState.RightHot; }
                else { button1State = ScrollBarArrowButtonState.UpHot; }
            }
            else
            {
                if (splitterVertical) { button2State = ScrollBarArrowButtonState.RightNormal; }
                else { button1State = ScrollBarArrowButtonState.UpNormal; }
            }

            this.Invalidate();
        }

        // Dimension the button rectangles and call the button location method
        /// <summary>
        /// Sets the button dimensions.
        /// </summary>
        private void SetButtonDimensions()
        {
            int width = 0, height = 0;

            if (splitterButtonStyle == ButtonStyle.ScrollBar)
            {
                width = this.SplitterWidth;
                height = width;
            }
            else
            {
                if (splitterButtonBitmap == null)
                {
                    if (splitterButtonStyle == ButtonStyle.Image)
                    {
                        width = 0;
                        height = 0;
                    }
                    else
                    {
                        width = this.SplitterWidth;
                        height = width;
                    }
                }
                else
                {
                    int h = splitterButtonBitmap.Height;
                    int w = splitterButtonBitmap.Width;

                    // Swap the width and height if one is larger than the
                    // other and the splitter orientation is Horizontal
                    if (h == w || splitterVertical)
                    {
                        width = w; // Normal
                        height = h;
                    }
                    else
                    {
                        width = h; // Swapped
                        height = w;
                    }
                }
            }

            // Call the method that calculates the button region
            SetButtonLocation(new Rectangle(this.SplitterRectangle.Location, new Size(width, height)));
        }

        // Adjust the button locations based on orientation and position
        /// <summary>
        /// Sets the button location.
        /// </summary>
        /// <param name="rect">The rect.</param>
        private void SetButtonLocation(Rectangle rect)
        {
            rectLeftDown = rect;
            rectRightUp = rect;

            int offset = 0, position = 0;

            if (splitterVertical)
            {
                offset = rect.Height;
                position = rect.Top;

                if (splitterButtonPosition == ButtonPosition.Center) { position = (this.SplitterRectangle.Height / 2) - (offset * 2); }
                else if (splitterButtonPosition == ButtonPosition.BottomRight) { position = (this.SplitterRectangle.Bottom) - (offset * 2); }

                rectLeftDown.Offset(0, position);
                rectRightUp.Offset(0, offset + position);
            }
            else
            {
                offset = rect.Width;
                position = rect.Left;

                if (splitterButtonPosition == ButtonPosition.Center) { position = (this.SplitterRectangle.Width / 2) - (offset * 2); }
                else if (splitterButtonPosition == ButtonPosition.BottomRight) { position = (this.SplitterRectangle.Right) - (offset * 2); }

                rectLeftDown.Offset(position, 0);
                rectRightUp.Offset(offset + position, 0);
            }
        }

        // Change the cursor when over the button region
        /// <summary>
        /// Sets the cursor.
        /// </summary>
        private void SetCursor()
        {
            if (splitterButtonStyle == ButtonStyle.None) { return; }

            bool leftHot = IsHotLeftDown(), rightHot = IsHotRightUp();

            if (leftHot)
            {
                if ((splitterVertical && panel1Minimized) || (!splitterVertical && panel2Minimized)) { this.Cursor = pointer_no; }
                else { this.Cursor = pointer; }
            }

            if (rightHot)
            {
                if ((!splitterVertical && panel1Minimized) || (splitterVertical && panel2Minimized)) { this.Cursor = pointer_no; }
                else { this.Cursor = pointer; }
            }

            if (!leftHot && !rightHot) { this.Cursor = Cursors.Default; }
        }

        // Load an image to use on the splitter
        /// <summary>
        /// Loads the image.
        /// </summary>
        public void LoadImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.bmp;*.png;*.gif;*.ico)|*.bmp;*.png;*.gif;*.ico|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.SplitterButtonBitmap = new Bitmap(ofd.FileName);
            }
        }
        #endregion

        // ISupportInitialize methods. Unneeded for .Net 4 and higher
        /// <summary>
        /// Signals the object that initialization is started.
        /// </summary>
        public void BeginInit() { }
        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        public void EndInit() { }
    }



    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitCollapsibleSplitContainerDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitCollapsibleSplitContainerDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitCollapsibleSplitContainerDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitCollapsibleSplitContainerSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitCollapsibleSplitContainerSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitCollapsibleSplitContainerSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitCollapsibleSplitContainer colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCollapsibleSplitContainerSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitCollapsibleSplitContainerSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitCollapsibleSplitContainer;

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

        #region Properties
        /// <summary>
        /// Gets or sets the splitter button bitmap.
        /// </summary>
        /// <value>The splitter button bitmap.</value>
        public Bitmap SplitterButtonBitmap
        {
            get
            {
                return colUserControl.SplitterButtonBitmap;
            }
            set
            {
                GetPropertyByName("SplitterButtonBitmap").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the splitter button position.
        /// </summary>
        /// <value>The splitter button position.</value>
        public ButtonPosition SplitterButtonPosition
        {
            get
            {
                return colUserControl.SplitterButtonPosition;
            }
            set
            {
                GetPropertyByName("SplitterButtonPosition").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the splitter button style.
        /// </summary>
        /// <value>The splitter button style.</value>
        public ButtonStyle SplitterButtonStyle
        {
            get
            {
                return colUserControl.SplitterButtonStyle;
            }
            set
            {
                GetPropertyByName("SplitterButtonStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the splitter collapse distance.
        /// </summary>
        /// <value>The splitter collapse distance.</value>
        public CollapseDistance SplitterCollapseDistance
        {
            get
            {
                return colUserControl.SplitterCollapseDistance;
            }
            set
            {
                GetPropertyByName("SplitterCollapseDistance").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [splitter focus hide].
        /// </summary>
        /// <value><c>true</c> if [splitter focus hide]; otherwise, <c>false</c>.</value>
        public bool SplitterFocusHide
        {
            get
            {
                return colUserControl.SplitterFocusHide;
            }
            set
            {
                GetPropertyByName("SplitterFocusHide").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is splitter fixed.
        /// </summary>
        /// <value><c>true</c> if this instance is splitter fixed; otherwise, <c>false</c>.</value>
        public bool IsSplitterFixed
        {
            get
            {
                return colUserControl.IsSplitterFixed;
            }
            set
            {
                GetPropertyByName("IsSplitterFixed").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("SplitterButtonBitmap",
                                 "Splitter Button Bitmap", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SplitterButtonPosition",
                                 "Splitter Button Position", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("SplitterButtonStyle",
                                 "Splitter Button Style", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("SplitterCollapseDistance",
                                 "Splitter Collapse Distance", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("SplitterFocusHide",
                                 "Splitter Focus Hide", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("IsSplitterFixed",
                                 "Is Splitter Fixed", "Appearance",
                                 "Type few characters to filter Cities."));

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
