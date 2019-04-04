// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Control.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitChevyExtendedPanel Panel

    #region Control

    /// <summary>
    /// As there is a background thread notifying the control it should change its size I use a delegate in order to have the access on the control in
    /// a thread safe way
    /// </summary>
    /// <param name="size">the new size of the control; it depends on the docking either width or height</param>
    internal delegate void NotifyAnimationCallback(int size);

    /// <summary>
    /// As there is a background thread notifying the control it should change its size I use a delegate in order to have the access on the control in
    /// a thread safe way
    /// </summary>
    internal delegate void NotifyAnimationFinishedCallback();

    /// <summary>
    /// A class collection for rendering a panel control.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.CornerCtrl" />
    [Designer(typeof(ZeroitChevyExtendedPanelDesigner))]
    [ToolboxItem(true)]
    public partial class ZeroitChevyExtendedPanel : CornerCtrl
    {
        #region Members
        /// <summary>
        /// The first time visible
        /// </summary>
        private bool firstTimeVisible = false;

        /// <summary>
        /// Tells if this control can be moved by dragging the caption control
        /// </summary>
        private bool moveable = false;

        /// <summary>
        /// When
        /// </summary>
        private bool backupMoveable = false;

        /// <summary>
        /// Saves the control full height.it is needed for the collapse/expand action
        /// </summary>
        private int backupHeight = 0;

        /// <summary>
        /// Saves the control full width. it is needed for the collapse/expand action
        /// </summary>
        private int backupWidth = 0;

        /// <summary>
        /// The step in pixel used when collapsing or expanding
        /// </summary>
        private int step = 20;

        /// <summary>
        /// Represents how much of the widht/height should be the caption
        /// </summary>
        private int captionSize = 0;

        /// <summary>
        /// It saves the Anchor property as it is needed if the caption is set to be bottom/right
        /// </summary>
        private AnchorStyles backupAnchor = AnchorStyles.None;

        /// <summary>
        /// flag setting if there is an animation for collapsing/expanding the control
        /// </summary>
        private Animation animation = Animation.Yes;

        /// <summary>
        /// Holds the state of this control
        /// </summary>
        private ExtendedPanelState state = ExtendedPanelState.Expanded;

        /// <summary>
        /// Instance of the object telling where to display the caption control for this panel
        /// </summary>
        private DirectionStyle captionAlign = DirectionStyle.Up;

        /// <summary>
        /// The instance of the caption ctrl of this Panel
        /// </summary>
        private CaptionCtrl captionCtrl = null;

        /// <summary>
        /// The instance of the object used for the animation of expanding/collapsing
        /// </summary>
        private CollapseAnimation collapseAnimation = null;

        /// <summary>
        /// the callback for notifying the size has changed
        /// </summary>
        private NotifyAnimationCallback callbackNotifyAnimation = null;

        /// <summary>
        /// the callback method used when the animation thread finishes
        /// </summary>
        private NotifyAnimationFinishedCallback callbackNotifyAnimationFinished = null;

        /// <summary>
        /// The visible controls
        /// </summary>
        private List<Control> visibleControls = new List<Control>();


        /// <summary>
        /// The dummy
        /// </summary>
        private object dummy = 1;
        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitChevyExtendedPanel" /> class.
        /// </summary>
        public ZeroitChevyExtendedPanel()
        {

            InitializeComponent();


            //set handler for collapsing/expanding
            captionCtrl.SetStyleChangedHandler(new DirectionCtrlStyleChangedEvent(CollapsingHandler));

            //set the handler for the dragging event
            if (moveable == true)
            {
                captionCtrl.Dragging += new CaptionDraggingEvent(CaptionDraggingEvent);
            }

            //set the callback
            callbackNotifyAnimation = new NotifyAnimationCallback(SetSizeCallback);
            callbackNotifyAnimationFinished = new NotifyAnimationFinishedCallback(AnimationFinished);

        }

        #endregion

        #region Public

        /// <summary>
        /// Collapses the control. No need to click on the direction control to get the event raised
        /// </summary>
        /// <exception cref="System.InvalidOperationException">The control has to be in an expanded state for calling collapsing!</exception>
        public void Collapse()
        {
            if (this.state != ExtendedPanelState.Expanded)
            {
                throw new InvalidOperationException("The control has to be in an expanded state for calling collapsing!");
            }

            DirectionStyle oldStyle = DirectionStyle.Up;
            DirectionStyle newStyle = DirectionStyle.Down;

            switch (captionAlign)
            {
                case DirectionStyle.Up:         //set above
                    break;

                case DirectionStyle.Left:
                    oldStyle = DirectionStyle.Left;
                    newStyle = DirectionStyle.Right;
                    break;

                case DirectionStyle.Right:
                    oldStyle = DirectionStyle.Right;
                    newStyle = DirectionStyle.Left;
                    break;

                case DirectionStyle.Down:
                    oldStyle = DirectionStyle.Down;
                    newStyle = DirectionStyle.Up;
                    break;
            }
            this.captionCtrl.SetDirectionStyle(newStyle);
            ChangeStyleEventArgs args = new ChangeStyleEventArgs(oldStyle, newStyle);
            CollapsingHandler(this, args);
        }

        /// <summary>
        /// Expands the control. No need to click on the direction control
        /// </summary>
        /// <exception cref="System.InvalidOperationException">The control has to be in an expanded state for calling collapsing!</exception>
        public void Expand()
        {
            if (this.state != ExtendedPanelState.Collapsed)
            {
                throw new InvalidOperationException("The control has to be in an expanded state for calling collapsing!");
            }

            DirectionStyle oldStyle = DirectionStyle.Down;
            DirectionStyle newStyle = DirectionStyle.Up;

            switch (captionAlign)
            {
                case DirectionStyle.Up:         //set above
                    break;

                case DirectionStyle.Left:
                    oldStyle = DirectionStyle.Right;
                    newStyle = DirectionStyle.Left;
                    break;

                case DirectionStyle.Right:
                    oldStyle = DirectionStyle.Left;
                    newStyle = DirectionStyle.Right;
                    break;

                case DirectionStyle.Down:
                    oldStyle = DirectionStyle.Up;
                    newStyle = DirectionStyle.Down;
                    break;
            }
            this.captionCtrl.SetDirectionStyle(newStyle);
            ChangeStyleEventArgs args = new ChangeStyleEventArgs(oldStyle, newStyle);
            CollapsingHandler(this, args);
        }
        #endregion

        #region Private

        /// <summary>
        /// Repositioning of the contained controls in the case the caption is overlapping them
        /// </summary>
        /// <param name="oldCaptionSize">Old size of the caption.</param>
        private void CheckDocking(int oldCaptionSize)
        {
            int offset = captionSize - oldCaptionSize;
            if (offset != 0)
            {
                switch (captionAlign)
                {
                    case DirectionStyle.Up:
                        this.SuspendLayout();
                        foreach (Control control in Controls)
                        {
                            if (control != captionCtrl)
                            {
                                control.Top += offset;
                            }
                        }
                        this.ResumeLayout(false);
                        break;

                    case DirectionStyle.Down:
                        this.SuspendLayout();
                        foreach (Control control in Controls)
                        {
                            if (control != captionCtrl)
                            {
                                control.Top -= offset;
                            }
                        }
                        this.ResumeLayout(false);

                        break;

                    case DirectionStyle.Left:
                        this.SuspendLayout();
                        foreach (Control control in Controls)
                        {
                            if (control != captionCtrl)
                            {
                                control.Left += offset;
                            }
                        }
                        this.ResumeLayout(false);
                        break;

                    case DirectionStyle.Right:
                        this.SuspendLayout();
                        foreach (Control control in Controls)
                        {
                            if (control != captionCtrl)
                            {
                                control.Left -= offset;
                            }
                        }
                        this.ResumeLayout(false);
                        break;
                }
            }
        }

        /// <summary>
        /// Show/hide the controls other than the caption this is for not showing the controls on the caption in collapsed mode
        /// </summary>
        private void ShowControls()
        {

            if (state == ExtendedPanelState.Collapsed)
            {

                lock (dummy)
                {
                    if (visibleControls.Count > 0)
                    {
                        while (visibleControls.Count > 0)
                        {
                            //visibleControls[visibleControls.Count - 1].Enabled = true;
                            visibleControls[visibleControls.Count - 1].Visible = true;
                            visibleControls.RemoveAt(visibleControls.Count - 1);
                        }

                    }
                    else
                    {
                        foreach (Control control in this.Controls)
                        {
                            if (control != this.captionCtrl)
                            {
                                if (control.Visible)
                                {
                                    visibleControls.Add(control);
                                    control.Visible = false;
                                    //  control.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Callback for making this control thread safe
        /// </summary>
        /// <param name="size">The size.</param>
        private void SetSizeCallback(int size)
        {
            switch (this.captionAlign)
            {
                case DirectionStyle.Down:
                    int tempY = this.Height - size;
                    //set the new location of the panel
                    Win32Wrapper.SetWindowPos(this.Handle, IntPtr.Zero, this.Location.X, this.Location.Y + tempY, this.Width, size, Win32Wrapper.FlagsSetWindowPos.SWP_NOZORDER | Win32Wrapper.FlagsSetWindowPos.SWP_SHOWWINDOW);
                    break;

                case DirectionStyle.Up:
                    this.Height = size;
                    break;

                case DirectionStyle.Right:
                    int tempX = this.Width - size;
                    Win32Wrapper.SetWindowPos(this.Handle, IntPtr.Zero, this.Location.X + tempX, this.Location.Y, size, this.Height, Win32Wrapper.FlagsSetWindowPos.SWP_NOZORDER | Win32Wrapper.FlagsSetWindowPos.SWP_SHOWWINDOW);
                    break;

                case DirectionStyle.Left:
                    this.Width = size;
                    if (this.Width < this.captionCtrl.Width)
                    {
                        this.Width = this.captionCtrl.Width;
                    }
                    break;
            }
        }

        /// <summary>
        /// Method called in order to have this control accessed in a thread safe way
        /// </summary>
        private void AnimationFinished()
        {
            //check to see  if Anchoring needs special treatment
            if (this.captionAlign == DirectionStyle.Right || this.captionAlign == DirectionStyle.Down)
            {
                this.Anchor = backupAnchor;
            }
            if (captionAlign == DirectionStyle.Down)
            {
                //set caption location (no redrawing) and hiding
                Win32Wrapper.SetWindowPos(this.captionCtrl.Handle, IntPtr.Zero, 0, this.Height - this.captionCtrl.Height, 0, 0, Win32Wrapper.FlagsSetWindowPos.SWP_NOREDRAW | Win32Wrapper.FlagsSetWindowPos.SWP_NOZORDER | Win32Wrapper.FlagsSetWindowPos.SWP_NOSIZE | Win32Wrapper.FlagsSetWindowPos.SWP_HIDEWINDOW);
                //set back the parent
                this.captionCtrl.Parent = this;
                this.captionCtrl.Visible = true;

                //set back the moveable property; during collapsing the movement is not allowed
                moveable = backupMoveable;
            }
            else
            {
                if (captionAlign == DirectionStyle.Right)
                {
                    //set caption location (no redrawing) and hiding
                    Win32Wrapper.SetWindowPos(this.captionCtrl.Handle, IntPtr.Zero, this.Width - this.captionCtrl.Width, 0, 0, 0, Win32Wrapper.FlagsSetWindowPos.SWP_NOREDRAW | Win32Wrapper.FlagsSetWindowPos.SWP_NOZORDER | Win32Wrapper.FlagsSetWindowPos.SWP_NOSIZE | Win32Wrapper.FlagsSetWindowPos.SWP_HIDEWINDOW);
                    //set back the parent
                    this.captionCtrl.Parent = this;
                    this.captionCtrl.Visible = true;
                    //set back the moveable property; during collapsing the movement is not allowed
                    moveable = backupMoveable;
                }
            }
            //set the state of the object expanded/collapsed
            SetState();
            ShowControls();

        }

        /// <summary>
        /// Set the state for this panel
        /// </summary>
        private void SetState()
        {
            if (this.captionCtrl.Width >= this.captionCtrl.Height)
            {
                if (this.captionCtrl.Height == this.Height)
                {
                    state = ExtendedPanelState.Collapsed;
                }
                else
                {
                    state = ExtendedPanelState.Expanded;
                }
            }
            else
            {
                if (this.captionCtrl.Width == this.Width)
                {
                    state = ExtendedPanelState.Collapsed;
                }
                else
                {
                    state = ExtendedPanelState.Expanded;
                }
            }
        }

        /// <summary>
        /// Set the caption properties for size and location
        /// </summary>
        /// <param name="flag">if true will set location and the widht/percentage of the parent based on alignment</param>
        private void SetCaptionControl(bool flag)
        {
            if (flag && state == ExtendedPanelState.Expanded)
            {
                this.captionCtrl.SetDirectionStyle(captionAlign);
            }
            switch (captionAlign)
            {

                case DirectionStyle.Up:
                    if (flag)
                    {
                        this.captionCtrl.Height = captionSize;//(int)(this.Height * captionSize / 100);
                        this.captionCtrl.Location = new Point(0, 0);
                    }
                    if (this.Width != this.captionCtrl.Width)
                    {
                        this.captionCtrl.Width = this.Width;
                    }
                    break;

                case DirectionStyle.Down:
                    if (flag)
                    {
                        this.captionCtrl.Height = captionSize; //(int)(this.Height * captionSize / 100);
                        this.captionCtrl.Location = new Point(0, this.Height - this.captionCtrl.Height);
                    }
                    if (this.Width != this.captionCtrl.Width)
                    {
                        this.captionCtrl.Width = this.Width;
                    }

                    break;

                case DirectionStyle.Left:
                    if (flag)
                    {
                        this.captionCtrl.Width = captionSize;// (int)(this.Width * captionSize / 100);
                        this.captionCtrl.Location = new Point(0, 0);
                    }
                    if (this.captionCtrl.Height != this.Height)
                    {
                        this.captionCtrl.Height = this.Height;
                    }
                    break;

                case DirectionStyle.Right:
                    if (flag)
                    {
                        this.captionCtrl.Width = captionSize;// (int)(this.Width * captionSize / 100);
                        this.captionCtrl.Location = new Point(this.Width - this.captionCtrl.Width, 0);
                    }
                    if (this.captionCtrl.Height != this.Height)
                    {
                        this.captionCtrl.Height = this.Height;
                    }

                    break;
            }
        }

        /// <summary>
        /// This method will take the caption control out of the controls of this panel
        /// </summary>
        private void ChangeCaptionParent()
        {
            //take the caption out of the panel beacause of the flickering
            this.captionCtrl.Parent = this.Parent;
            this.captionCtrl.Location = new Point(this.Location.X + this.Width - this.captionCtrl.Width, this.Location.Y + this.Height - this.captionCtrl.Height);
            Win32Wrapper.SetWindowPos(this.Handle, this.captionCtrl.Handle, 0, 0, 0, 0, Win32Wrapper.FlagsSetWindowPos.SWP_NOMOVE | Win32Wrapper.FlagsSetWindowPos.SWP_NOSIZE | Win32Wrapper.FlagsSetWindowPos.SWP_NOREDRAW);

            //disable moving 
            backupMoveable = moveable;
            moveable = false;
        }
        #endregion

        #region Protected

        /// <summary>
        /// Creates the graphic path used for drawing the border
        /// </summary>
        protected override void InitializeGraphicPath()
        {
            cornerSquare = (int)(captionCtrl.Height > captionCtrl.Width ? captionCtrl.Height * 0.05f : captionCtrl.Width * 0.05f);// Width * 0.25f;
            base.InitializeGraphicPath();
        }

        #endregion

        #region WM_PAINT

        /// <summary>
        /// The event raised for painting the control
        /// </summary>
        /// <param name="e">Instance of the object containing event data</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //set flags for the graphics object
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = smoothing;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            e.Graphics.TextRenderingHint = textrendering;


            //recreate the path if is ull
            if (null == graphicPath)
            {
                InitializeGraphicPath();
            }

            //draw the border
            e.Graphics.DrawPath(new Pen(borderColor), graphicPath);

        }

        #endregion

        #region Overrides

        /// <summary>
        /// This needs overriding in the case the control is being resized.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (captionSize == 0)
            {
                captionSize = (int)(this.Height * 20 / 100);
                CheckDocking(0);
            }

            //if the control is resized (other than collapsing and expanding) the caption needs to be updated
            SetCaptionControl(state != ExtendedPanelState.Collapsing && state != ExtendedPanelState.Expanding);
            this.Refresh();
        }


        /// <summary>
        /// WNDs the proc.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {

            if (!DesignMode && firstTimeVisible && m.Msg == 0x18)
            {
                firstTimeVisible = false;
                backupHeight = Height;
                backupWidth = Width;

                switch (this.captionAlign)
                {
                    case DirectionStyle.Down:
                        //set the new location of the panel
                        Win32Wrapper.SetWindowPos(this.Handle, IntPtr.Zero, this.Location.X, this.Location.Y + captionCtrl.Location.Y, this.Width, captionCtrl.Height, Win32Wrapper.FlagsSetWindowPos.SWP_NOZORDER);
                        this.captionCtrl.SetDirectionStyle(DirectionStyle.Up);
                        break;

                    case DirectionStyle.Up:
                        this.Height = captionCtrl.Height;
                        this.captionCtrl.SetDirectionStyle(DirectionStyle.Down);
                        break;

                    case DirectionStyle.Right:
                        //int tempX = this.Width - size;
                        Win32Wrapper.SetWindowPos(this.Handle, IntPtr.Zero, this.Location.X + Width - captionCtrl.Location.X, this.Location.Y, captionCtrl.Width, this.Height, Win32Wrapper.FlagsSetWindowPos.SWP_NOZORDER);
                        this.captionCtrl.SetDirectionStyle(DirectionStyle.Left);
                        break;

                    case DirectionStyle.Left:
                        this.Width = this.captionCtrl.Width;
                        this.captionCtrl.SetDirectionStyle(DirectionStyle.Right);
                        break;
                }
                this.captionCtrl.Location = new Point(0, 0);
                //set the state of the object expanded/collapsed
                ShowControls();

            }
            base.WndProc(ref m);
        }
        #endregion

        #region Properties


        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }

        #endregion

        #region TextRenderingHint

        #region Add it to OnPaint / Graphics Rendering component

        //e.Graphics.TextRenderingHint = textrendering;
        #endregion

        /// <summary>
        /// The textrendering
        /// </summary>
        TextRenderingHint textrendering = TextRenderingHint.AntiAlias;

        /// <summary>
        /// Gets or sets the text rendering.
        /// </summary>
        /// <value>The text rendering.</value>
        public TextRenderingHint TextRendering
        {
            get { return textrendering; }
            set
            {
                textrendering = value;
                Invalidate();
            }
        }
        #endregion

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitChevyExtendedPanel"/> is moveable.
        /// </summary>
        /// <value><c>true</c> if moveable; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Sets/Gets whether this control can be moved by dragging")]
        public bool Moveable
        {
            get
            {
                return moveable;
            }

            set
            {
                if (value != moveable)
                {
                    moveable = value;
                    if (moveable == true)
                    {
                        if (!captionCtrl.IsDraggingEnabled())
                        {
                            captionCtrl.Dragging += new CaptionDraggingEvent(CaptionDraggingEvent);
                        }
                    }
                    else
                    {
                        if (captionCtrl.IsDraggingEnabled())
                        {
                            captionCtrl.Dragging -= new CaptionDraggingEvent(CaptionDraggingEvent);
                        }
                    }
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the animation.
        /// </summary>
        /// <value>The animation.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(Animation.Yes)]
        [Description("Sets/Gets whether collapsing or expanding process is being animated")]
        public Animation Animation
        {
            get
            {
                return animation;
            }
            set
            {
                animation = value;
                this.captionCtrl.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the caption align.
        /// </summary>
        /// <value>The caption align.</value>
        [Category("Caption")]
        [DefaultValue(DirectionStyle.Up)]
        [Description("Set/Get where the caption for this panel is positioned")]
        public DirectionStyle CaptionAlign
        {
            get
            {
                return this.captionAlign;
            }
            set
            {
                if (value != captionAlign)
                {
                    captionAlign = value;
                    SetCaptionControl(true);
                    this.captionCtrl.Refresh();
                    //this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the caption text.
        /// </summary>
        /// <value>The caption text.</value>
        [Category("Caption")]
        [DefaultValue("Caption")]
        [Description("Set/Get the text to be displayed in the caption of this control")]
        public string CaptionText
        {
            get
            {
                return this.captionCtrl.CaptionText;
            }
            set
            {
                this.captionCtrl.CaptionText = value;
                this.captionCtrl.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the caption image.
        /// </summary>
        /// <value>The caption image.</value>
        [Category("Caption")]
        [DefaultValue(null)]
        [Description("Get/Set the image to be displayed in the caption of this control")]
        public Icon CaptionImage
        {
            get
            {
                return this.captionCtrl.CaptionIcon;
            }
            set
            {
                this.captionCtrl.CaptionIcon = value;
                this.captionCtrl.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the caption brush.
        /// </summary>
        /// <value>The caption brush.</value>
        [Category("Caption")]
        [DefaultValue(BrushType.Gradient)]
        [Description("Get/Set the brush type used in filling the caption")]
        public BrushType CaptionBrush
        {
            get
            {
                return captionCtrl.BrushType;
            }
            set
            {
                this.captionCtrl.BrushType = value;
                this.captionCtrl.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the color of the caption text.
        /// </summary>
        /// <value>The color of the caption text.</value>
        [Category("Caption")]
        [Description("Get/Set the color of the text displayed in the caption")]
        public Color CaptionTextColor
        {
            get
            {
                return this.captionCtrl.TextColor;
            }
            set
            {
                this.captionCtrl.TextColor = value;
                this.captionCtrl.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the caption color one.
        /// </summary>
        /// <value>The caption color one.</value>
        [Category("Caption")]
        [Description("Get/Set the starting color for the gradient brush if brush type is chose to be gradient")]
        public Color CaptionColorOne
        {
            get
            {
                return this.captionCtrl.ColorOne;
            }
            set
            {
                this.captionCtrl.ColorOne = value;
                this.captionCtrl.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the caption color two.
        /// </summary>
        /// <value>The caption color two.</value>
        [Category("Caption")]
        [Description("Get/Set the ending color for the gradient brush if brush type is chose to be gradient")]
        public Color CaptionColorTwo
        {
            get
            {
                return this.captionCtrl.ColorTwo;
            }
            set
            {
                this.captionCtrl.ColorTwo = value;
                this.captionCtrl.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the caption font.
        /// </summary>
        /// <value>The caption font.</value>
        [Category("Caption")]
        [Description("Get/Set the font used for drawing the caption text")]
        public Font CaptionFont
        {
            get
            {
                return this.captionCtrl.CaptionFont;
            }
            set
            {
                this.captionCtrl.CaptionFont = value;
                this.captionCtrl.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [Category("Appearance")]
        [DefaultValue(ExtendedPanelState.Expanded)]
        [Description("Returns the state of this panel")]
        public ExtendedPanelState State
        {
            get
            {
                return this.state;
            }

            [DesignOnly(true)]
            set
            {
                if (value == ExtendedPanelState.Collapsing || value == ExtendedPanelState.Expanding)
                {
                    return;
                }
                this.state = value;
                if (value == ExtendedPanelState.Collapsed)
                {
                    firstTimeVisible = true;
                }

                this.captionCtrl.Refresh();
            }
        }


        /// <summary>
        /// Gets or sets the size of the caption.
        /// </summary>
        /// <value>The size of the caption.</value>
        /// <exception cref="System.ArgumentException">Need a value greater or equal to 0</exception>
        /// <exception cref="System.InvalidOperationException">You can set the caption size while the control is fully expanded</exception>
        [Category("Caption")]
        [DefaultValue(0)]
        [Description("Set/Get the percent of the caption part of this control 1 to 100")]
        public int CaptionSize
        {
            get
            {
                return this.captionSize;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Need a value greater or equal to 0 ");
                }
                if (state != ExtendedPanelState.Expanded)
                {
                    throw new InvalidOperationException("You can set the caption size while the control is fully expanded");
                }
                if (value != this.captionSize)
                {
                    int backupCaptionSize = captionSize;
                    this.captionSize = value;
                    SetCaptionControl(true);
                    CheckDocking(backupCaptionSize);
                    this.captionCtrl.Refresh();
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets the animation step.
        /// </summary>
        /// <value>The animation step.</value>
        /// <exception cref="System.ArgumentException">Need a value greater or equal to 1</exception>
        [Category("Caption")]
        [DefaultValue(20)]
        [Description("Get/Set the step used for animating collasping/expanding")]
        public int AnimationStep
        {
            get
            {
                return this.step;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Need a value greater or equal to 1");
                }
                step = value;

                this.captionCtrl.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the color of the direction control.
        /// </summary>
        /// <value>The color of the direction control.</value>
        [Browsable(true)]
        public Color DirectionCtrlColor
        {
            get
            {
                return captionCtrl.DirectionCtrlColor;
            }
            set
            {
                captionCtrl.DirectionCtrlColor = value;

                this.captionCtrl.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the color of the direction control hover.
        /// </summary>
        /// <value>The color of the direction control hover.</value>
        [Browsable(true)]
        public Color DirectionCtrlHoverColor
        {
            get
            {
                return captionCtrl.DirectionCtrlHoverColor;
            }
            set
            {
                captionCtrl.DirectionCtrlHoverColor = value;

                this.captionCtrl.Refresh();
            }
        }
        #endregion

        #region Events

        /// <summary>
        /// Event raised for exapanding/collapsing the control
        /// </summary>
        /// <param name="sender">instance of the object raising the event</param>
        /// <param name="e">instance of an object containing the event data</param>
        private void CollapsingHandler(object sender, ChangeStyleEventArgs e)
        {
            //check to see  if Anchoring needs special treatment
            if (this.captionAlign == DirectionStyle.Right || this.captionAlign == DirectionStyle.Down)
            {
                backupAnchor = this.Anchor;
                this.Anchor |= AnchorStyles.Left;
                this.Anchor |= AnchorStyles.Top;
                this.Anchor &= ~AnchorStyles.Right;
                this.Anchor &= ~AnchorStyles.Bottom;
            }
            //create the thread for collasping/expanding the control 
            if (null == collapseAnimation)
            {
                collapseAnimation = new CollapseAnimation();
                //set the events to be raised by the animation worker thread
                collapseAnimation.NotifyAnimation += new NotifyAnimationEvent(OnNotifyAnimationEvent);
                collapseAnimation.NotifyAnimationFinished += new NotifyAnimationFinishedEvent(OnNotifyAnimationFinished);
                if (backupHeight == 0)
                {
                    backupHeight = this.Height;
                }
                if (backupWidth == 0)
                {
                    backupWidth = this.Width;
                }
            }

            switch (this.captionAlign)
            {
                case DirectionStyle.Up:
                    if (e.Old == DirectionStyle.Up)
                    {
                        backupHeight = this.Height;
                        backupWidth = this.Width;

                        collapseAnimation.Maximum = this.Height;
                        collapseAnimation.Minimum = captionCtrl.Height;
                        if (animation == Animation.Yes)
                        {
                            collapseAnimation.Step = step;
                        }
                        else
                        {
                            collapseAnimation.Step = this.Height - captionCtrl.Height;
                        }
                    }
                    else
                    {
                        collapseAnimation.Maximum = backupHeight;
                        collapseAnimation.Minimum = captionCtrl.Height;
                        if (animation == Animation.Yes)
                        {
                            collapseAnimation.Step = -step;
                        }
                        else
                        {
                            collapseAnimation.Step = -(backupHeight - captionCtrl.Height);
                        }
                    }
                    break;

                case DirectionStyle.Down:
                    if (e.Old == DirectionStyle.Down)
                    {
                        //have to extract caption ctrl because of the flickering involved
                        ChangeCaptionParent();

                        //save the size as will need them for expanding the control back
                        backupHeight = this.Height;
                        backupWidth = this.Width;

                        collapseAnimation.Maximum = this.Height;
                        collapseAnimation.Minimum = captionCtrl.Height;
                        if (animation == Animation.Yes)
                        {
                            collapseAnimation.Step = step;
                        }
                        else
                        {
                            collapseAnimation.Step = this.Height - captionCtrl.Height;
                        }
                    }
                    else
                    {
                        //have to extract caption ctrl because of the flickering involved
                        ChangeCaptionParent();

                        collapseAnimation.Maximum = backupHeight;
                        collapseAnimation.Minimum = captionCtrl.Height;
                        if (animation == Animation.Yes)
                        {
                            collapseAnimation.Step = -step;
                        }
                        else
                        {
                            collapseAnimation.Step = -(backupHeight - captionCtrl.Height);
                        }
                    }
                    break;


                case DirectionStyle.Left:
                    if (e.Old == DirectionStyle.Left)
                    {
                        //save the size as will need them for expanding the control back
                        backupHeight = this.Height;
                        backupWidth = this.Width;

                        collapseAnimation.Maximum = this.Width;
                        collapseAnimation.Minimum = captionCtrl.Width;
                        if (animation == Animation.Yes)
                        {
                            collapseAnimation.Step = step;
                        }
                        else
                        {
                            collapseAnimation.Step = this.Width - captionCtrl.Width;
                        }
                    }
                    else
                    {
                        collapseAnimation.Maximum = backupWidth;
                        collapseAnimation.Minimum = captionCtrl.Width;
                        if (animation == Animation.Yes)
                        {
                            collapseAnimation.Step = -step;
                        }
                        else
                        {
                            collapseAnimation.Step = -(backupWidth - captionCtrl.Width);
                        }
                    }
                    break;

                case DirectionStyle.Right:
                    if (e.Old == DirectionStyle.Right)
                    {
                        //have to extract caption ctrl because of the flickering involved
                        ChangeCaptionParent();

                        backupHeight = this.Height;
                        backupWidth = this.Width;

                        collapseAnimation.Maximum = this.Width;
                        collapseAnimation.Minimum = captionCtrl.Width;
                        if (animation == Animation.Yes)
                        {
                            collapseAnimation.Step = step;
                        }
                        else
                        {
                            collapseAnimation.Step = this.Width - captionCtrl.Width;
                        }
                    }
                    else
                    {
                        //have to extract caption ctrl because of the flickering involved
                        ChangeCaptionParent();

                        collapseAnimation.Maximum = backupWidth;
                        collapseAnimation.Minimum = captionCtrl.Width;
                        if (animation == Animation.Yes)
                        {
                            collapseAnimation.Step = -step;
                        }
                        else
                        {
                            collapseAnimation.Step = -(backupWidth - captionCtrl.Width);
                        }
                    }
                    break;
            }

            SetState();
            ShowControls();
            //start collapsing/expanding and set the new state
            if (state == ExtendedPanelState.Collapsed)
            {
                state = ExtendedPanelState.Expanding;
            }
            else
            {
                if (state == ExtendedPanelState.Expanded)
                {
                    state = ExtendedPanelState.Collapsing;
                }
            }
            collapseAnimation.Start();
        }


        /// <summary>
        /// The Event raised when the size of the control should change (during colapsing/expanind
        /// </summary>
        /// <param name="sender">instance of the object making the call</param>
        /// <param name="size">the new size for this panel</param>
        private void OnNotifyAnimationEvent(object sender, int size)
        {
            this.Invoke(callbackNotifyAnimation, size);
        }


        /// <summary>
        /// Event raised when the animation collapsing/expanding has finished
        /// </summary>
        /// <param name="sender">the object raising the event.Would be an instance of CollapsingAnimation</param>
        private void OnNotifyAnimationFinished(object sender)
        {
            this.Invoke(callbackNotifyAnimationFinished);
        }

        /// <summary>
        /// Event raised when this control is being dragged on the screen
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CaptionDraggingEventArgs"/> instance containing the event data.</param>
        private void CaptionDraggingEvent(object sender, CaptionDraggingEventArgs e)
        {
            if (moveable == true)
            {
                //set the new location
                this.Location = new Point(this.Location.X - e.Width, this.Location.Y - e.Height);
            }
        }
        #endregion
    }

    #endregion

    #region Designer Generated Code

    partial class ZeroitChevyExtendedPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();

            //add the caption control
            this.captionCtrl = new CaptionCtrl();
            this.captionCtrl.Width = this.Width;
            this.captionCtrl.Height = this.Height;
            this.captionCtrl.Location = new Point(0, 0);
            this.captionCtrl.BackColor = Color.Transparent;


            this.Controls.Add(captionCtrl);
            // 
            // ExtendedPanel
            //
            this.Name = "ExtendedPanel";
            this.ResumeLayout(false);

        }

        #endregion
    }

    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitChevyExtendedPanelDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitChevyExtendedPanelDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitChevyExtendedPanelSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitChevyExtendedPanelSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitChevyExtendedPanelSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitChevyExtendedPanel colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitChevyExtendedPanelSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitChevyExtendedPanelSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitChevyExtendedPanel;

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


        #region Smoothing Mode

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get
            {
                return colUserControl.Smoothing;
            }
            set
            {
                GetPropertyByName("Smoothing").SetValue(colUserControl, value);
            }
        }

        #endregion



        #region TextRenderingHint

        #region Add it to OnPaint / Graphics Rendering component

        //e.Graphics.TextRenderingHint = textrendering;
        #endregion

        /// <summary>
        /// Gets or sets the text rendering.
        /// </summary>
        /// <value>The text rendering.</value>
        public TextRenderingHint TextRendering
        {
            get
            {
                return colUserControl.TextRendering;
            }
            set
            {
                GetPropertyByName("TextRendering").SetValue(colUserControl, value);
            }
        }
        #endregion

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitChevyExtendedPanelSmartTagActionList"/> is moveable.
        /// </summary>
        /// <value><c>true</c> if moveable; otherwise, <c>false</c>.</value>
        public bool Moveable
        {
            get
            {
                return colUserControl.Moveable;
            }
            set
            {
                GetPropertyByName("Moveable").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the animation.
        /// </summary>
        /// <value>The animation.</value>
        public Animation Animation
        {
            get
            {
                return colUserControl.Animation;
            }
            set
            {
                GetPropertyByName("Animation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the caption align.
        /// </summary>
        /// <value>The caption align.</value>
        public DirectionStyle CaptionAlign
        {
            get
            {
                return colUserControl.CaptionAlign;
            }
            set
            {
                GetPropertyByName("CaptionAlign").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the caption text.
        /// </summary>
        /// <value>The caption text.</value>
        public string CaptionText
        {
            get
            {
                return colUserControl.CaptionText;
            }
            set
            {
                GetPropertyByName("CaptionText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the caption image.
        /// </summary>
        /// <value>The caption image.</value>
        public Icon CaptionImage
        {
            get
            {
                return colUserControl.CaptionImage;
            }
            set
            {
                GetPropertyByName("CaptionImage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the caption brush.
        /// </summary>
        /// <value>The caption brush.</value>
        public BrushType CaptionBrush
        {
            get
            {
                return colUserControl.CaptionBrush;
            }
            set
            {
                GetPropertyByName("CaptionBrush").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the caption text.
        /// </summary>
        /// <value>The color of the caption text.</value>
        public Color CaptionTextColor
        {
            get
            {
                return colUserControl.CaptionTextColor;
            }
            set
            {
                GetPropertyByName("CaptionTextColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the caption color one.
        /// </summary>
        /// <value>The caption color one.</value>
        public Color CaptionColorOne
        {
            get
            {
                return colUserControl.CaptionColorOne;
            }
            set
            {
                GetPropertyByName("CaptionColorOne").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the caption color two.
        /// </summary>
        /// <value>The caption color two.</value>
        public Color CaptionColorTwo
        {
            get
            {
                return colUserControl.CaptionColorTwo;
            }
            set
            {
                GetPropertyByName("CaptionColorTwo").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the caption font.
        /// </summary>
        /// <value>The caption font.</value>
        public Font CaptionFont
        {
            get
            {
                return colUserControl.CaptionFont;
            }
            set
            {
                GetPropertyByName("CaptionFont").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public ExtendedPanelState State
        {
            get
            {
                return colUserControl.State;
            }
            set
            {
                GetPropertyByName("State").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Gets or sets the size of the caption.
        /// </summary>
        /// <value>The size of the caption.</value>
        public int CaptionSize
        {
            get
            {
                return colUserControl.CaptionSize;
            }
            set
            {
                GetPropertyByName("CaptionSize").SetValue(colUserControl, value);
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
        /// Gets or sets the color of the direction control.
        /// </summary>
        /// <value>The color of the direction control.</value>
        public Color DirectionCtrlColor
        {
            get
            {
                return colUserControl.DirectionCtrlColor;
            }
            set
            {
                GetPropertyByName("DirectionCtrlColor").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Gets or sets the color of the direction control hover.
        /// </summary>
        /// <value>The color of the direction control hover.</value>
        public Color DirectionCtrlHoverColor
        {
            get
            {
                return colUserControl.DirectionCtrlHoverColor;
            }
            set
            {
                GetPropertyByName("DirectionCtrlHoverColor").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Moveable",
                                 "Moveable", "Appearance",
                                 "Sets the control to have moving capabilities."));

            items.Add(new DesignerActionPropertyItem("Animation",
                                 "Animation", "Appearance",
                                 "Allow the control to be animated."));

            items.Add(new DesignerActionPropertyItem("CaptionAlign",
                                 "Caption Align", "Appearance",
                                 "Set the caption align."));

            items.Add(new DesignerActionPropertyItem("CaptionText",
                                 "Caption Text", "Appearance",
                                 "Sets the caption text."));

            items.Add(new DesignerActionPropertyItem("CaptionImage",
                                 "Caption Image", "Appearance",
                                 "Sets the caption image."));

            items.Add(new DesignerActionPropertyItem("CaptionBrush",
                                 "Caption Brush", "Appearance",
                                 "Sets the caption brush."));

            items.Add(new DesignerActionPropertyItem("CaptionTextColor",
                                 "Caption Text Color", "Appearance",
                                 "Sets the caption text color."));

            items.Add(new DesignerActionPropertyItem("CaptionColorOne",
                                 "Caption Color One", "Appearance",
                                 "Sets the caption color."));

            items.Add(new DesignerActionPropertyItem("CaptionColorTwo",
                                 "Caption Color Two", "Appearance",
                                 "Sets the caption color."));

            items.Add(new DesignerActionPropertyItem("CaptionFont",
                                 "Caption Font", "Appearance",
                                 "Sets the caption font."));

            items.Add(new DesignerActionPropertyItem("State",
                                 "State", "Appearance",
                                 "Sets the state."));

            items.Add(new DesignerActionPropertyItem("CaptionSize",
                                 "Caption Size", "Appearance",
                                 "Sets the caption size."));

            items.Add(new DesignerActionPropertyItem("AnimationStep",
                                 "Animation Step", "Appearance",
                                 "Sets the animation step."));

            items.Add(new DesignerActionPropertyItem("DirectionCtrlColor",
                                 "Direction Control Color", "Appearance",
                                 "Sets the direction control color."));

            items.Add(new DesignerActionPropertyItem("DirectionCtrlHoverColor",
                                 "Direction Control Hover Color", "Appearance",
                                 "Sets the direction control hover color."));

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
