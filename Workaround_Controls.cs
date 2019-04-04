// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Workaround_Controls.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Zeroit.Framework.MiscControls.HelperControls.Widgets;


namespace Zeroit.Framework.MiscControls
{


    #region XP Styled Explorer

    // #region Expando

    // #region Delegates

    // /// <summary>
    // /// Represents the method that will handle the StateChanged, ExpandoAdded, 
    // /// and ExpandoRemoved events of an Expando or TaskPane
    // /// </summary>
    // /// <param name="sender">The source of the event</param>
    // /// <param name="e">A ExpandoEventArgs that contains the event data</param>
    // public delegate void ExpandoEventHandler(object sender, ExpandoEventArgs e);

    // #endregion



    // #region Expando

    // /// <summary>
    // /// A Control that replicates the collapsable panels found in 
    // /// Windows XP's Explorer Bar
    // /// </summary>
    // [ToolboxItem(true),
    // DefaultEvent("StateChanged"),
    // DesignerAttribute(typeof(ExpandoDesigner))]
    // public class Expando : Control, ISupportInitialize
    // {
    //     #region EventHandlers

    //     /// <summary>
    //     /// Occurs when the value of the Collapsed property changes
    //     /// </summary>
    //     public event ExpandoEventHandler StateChanged;

    //     /// <summary>
    //     /// Occurs when the value of the TitleImage property changes
    //     /// </summary>
    //     public event ExpandoEventHandler TitleImageChanged;

    //     /// <summary>
    //     /// Occurs when the value of the SpecialGroup property changes
    //     /// </summary>
    //     public event ExpandoEventHandler SpecialGroupChanged;

    //     /// <summary>
    //     /// Occurs when the value of the Watermark property changes
    //     /// </summary>
    //     public event ExpandoEventHandler WatermarkChanged;

    //     /// <summary>
    //     /// Occurs when an item (Control) is added to the Expando
    //     /// </summary>
    //     public event ControlEventHandler ItemAdded;

    //     /// <summary>
    //     /// Occurs when an item (Control) is removed from the Expando
    //     /// </summary>
    //     public event ControlEventHandler ItemRemoved;

    //     /// <summary>
    //     /// Occurs when a value in the CustomSettings or CustomHeaderSettings 
    //     /// proterties changes
    //     /// </summary>
    //     public event EventHandler CustomSettingsChanged;

    //     #endregion


    //     #region Class Data

    //     /// <summary>
    //     /// Required designer variable
    //     /// </summary>
    //     private Container components = null;

    //     /// <summary>
    //     /// System settings for the Expando
    //     /// </summary>
    //     private ExplorerBarInfo systemSettings;

    //     /// <summary>
    //     /// Is the Expando a special group
    //     /// </summary>
    //     private bool specialGroup;

    //     /// <summary>
    //     /// The height of the Expando in its expanded state
    //     /// </summary>
    //     private int expandedHeight;

    //     /// <summary>
    //     /// The image displayed on the left side of the titlebar
    //     /// </summary>
    //     private Image titleImage;

    //     /// <summary>
    //     /// The height of the header section 
    //     /// (includes titlebar and title image)
    //     /// </summary>
    //     private int headerHeight;

    //     /// <summary>
    //     /// Is the Expando collapsed
    //     /// </summary>
    //     private bool collapsed;

    //     /// <summary>
    //     /// The state of the titlebar
    //     /// </summary>
    //     private FocusStates focusState;

    //     /// <summary>
    //     /// The height of the titlebar
    //     /// </summary>
    //     private int titleBarHeight;

    //     /// <summary>
    //     /// Specifies whether the Expando is allowed to animate
    //     /// </summary>
    //     private bool animate;

    //     /// <summary>
    //     /// Spcifies whether the Expando is currently animating a fade
    //     /// </summary>
    //     private bool animatingFade;

    //     /// <summary>
    //     /// Spcifies whether the Expando is we currently animating a slide
    //     /// </summary>
    //     private bool animatingSlide;

    //     /// <summary>
    //     /// An image of the "client area" which is used 
    //     /// during a fade animation
    //     /// </summary>
    //     private Image animationImage;

    //     /// <summary>
    //     /// An AnimationHelper that help the Expando to animate
    //     /// </summary>
    //     private AnimationHelper animationHelper;

    //     /// <summary>
    //     /// The TaskPane the Expando belongs to
    //     /// </summary>
    //     private TaskPane taskpane;

    //     /// <summary>
    //     /// Should the Expando layout its items itself
    //     /// </summary>
    //     private bool autoLayout;

    //     /// <summary>
    //     /// The last known width of the Expando 
    //     /// (used while animating)
    //     /// </summary>
    //     private int oldWidth;

    //     /// <summary>
    //     /// Specifies whether the Expando is currently initialising
    //     /// </summary>
    //     private bool initialising;

    //     /// <summary>
    //     /// Internal list of items contained in the Expando
    //     /// </summary>
    //     private ItemCollection itemList;

    //     /// <summary>
    //     /// Internal list of controls that have been hidden
    //     /// </summary>
    //     private ArrayList hiddenControls;

    //     /// <summary>
    //     /// A panel the Expando can move its controls onto when it is 
    //     /// animating from collapsed to expanded.
    //     /// </summary>
    //     private AnimationPanel dummyPanel;

    //     /// <summary>
    //     /// Specifies whether the Expando is allowed to collapse
    //     /// </summary>
    //     private bool canCollapse;

    //     /// <summary>
    //     /// The height of the Expando at the end of its slide animation
    //     /// </summary>
    //     private int slideEndHeight;

    //     /// <summary>
    //     /// The index of the Image that is used as a watermark
    //     /// </summary>
    //     private Image watermark;

    //     /// <summary>
    //     /// Specifies whether the Expando should draw a focus rectangle 
    //     /// when it has focus
    //     /// </summary>
    //     private bool showFocusCues;

    //     /// <summary>
    //     /// Specifies whether the Expando is currently performing a 
    //     /// layout operation
    //     /// </summary>
    //     private bool layout = false;

    //     /// <summary>
    //     /// Specifies the custom settings for the Expando
    //     /// </summary>
    //     private ExpandoInfo customSettings;

    //     /// <summary>
    //     /// Specifies the custom header settings for the Expando
    //     /// </summary>
    //     private HeaderInfo customHeaderSettings;

    //     /// <summary>
    //     /// An array of pre-determined heights for use during a 
    //     /// fade animation
    //     /// </summary>
    //     private int[] fadeHeights;

    //     /// <summary>
    //     /// Specifies whether the Expando should use Windows 
    //     /// defsult Tab handling mechanism
    //     /// </summary>
    //     private bool useDefaultTabHandling;

    //     /// <summary>
    //     /// Specifies the number of times BeginUpdate() has been called
    //     /// </summary>
    //     private int beginUpdateCount;

    //     /// <summary>
    //     /// Specifies whether slide animations should be batched
    //     /// </summary>
    //     private bool slideAnimationBatched;

    //     /// <summary>
    //     /// Specifies whether the Expando is currently being dragged
    //     /// </summary>
    //     private bool dragging;

    //     /// <summary>
    //     /// Specifies the Point that a drag operation started at
    //     /// </summary>
    //     private Point dragStart;

    //     #endregion


    //     #region Constructor

    //     /// <summary>
    //     /// Initializes a new instance of the Expando class with default settings
    //     /// </summary>
    //     public Expando() : base()
    //     {
    //         // This call is required by the Windows.Forms Form Designer.
    //         this.components = new System.ComponentModel.Container();

    //         // set control styles
    //         this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    //         this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    //         this.SetStyle(ControlStyles.UserPaint, true);
    //         this.SetStyle(ControlStyles.ResizeRedraw, true);
    //         this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    //         this.SetStyle(ControlStyles.Selectable, true);
    //         this.TabStop = true;

    //         // get the system theme settings
    //         this.systemSettings = ThemeManager.GetSystemExplorerBarSettings();

    //         this.customSettings = new ExpandoInfo();
    //         this.customSettings.Expando = this;
    //         this.customSettings.SetDefaultEmptyValues();

    //         this.customHeaderSettings = new HeaderInfo();
    //         this.customHeaderSettings.Expando = this;
    //         this.customHeaderSettings.SetDefaultEmptyValues();

    //         this.BackColor = this.systemSettings.Expando.NormalBackColor;

    //         // the height of the Expando in the expanded state
    //         this.expandedHeight = 100;

    //         // animation
    //         this.animate = false;
    //         this.animatingFade = false;
    //         this.animatingSlide = false;
    //         this.animationImage = null;
    //         this.slideEndHeight = -1;
    //         this.animationHelper = null;
    //         this.fadeHeights = new int[AnimationHelper.NumAnimationFrames];

    //         // size
    //         this.Size = new Size(this.systemSettings.Header.BackImageWidth, this.expandedHeight);
    //         this.titleBarHeight = this.systemSettings.Header.BackImageHeight;
    //         this.headerHeight = this.titleBarHeight;
    //         this.oldWidth = this.Width;

    //         // start expanded
    //         this.collapsed = false;

    //         // not a special group
    //         this.specialGroup = false;

    //         // unfocused titlebar
    //         this.focusState = FocusStates.None;

    //         // no title image
    //         this.titleImage = null;
    //         this.watermark = null;

    //         this.Font = new Font(this.TitleFont.Name, 8.25f, FontStyle.Regular);

    //         // don't get the Expando to layout its items itself
    //         this.autoLayout = false;

    //         // don't know which TaskPane we belong to
    //         this.taskpane = null;

    //         // internal list of items
    //         this.itemList = new ItemCollection(this);
    //         this.hiddenControls = new ArrayList();

    //         // initialise the dummyPanel
    //         this.dummyPanel = new AnimationPanel();
    //         this.dummyPanel.Size = this.Size;
    //         this.dummyPanel.Location = new Point(-1000, 0);

    //         this.canCollapse = true;

    //         this.showFocusCues = false;
    //         this.useDefaultTabHandling = true;

    //         this.CalcAnimationHeights();

    //         this.slideAnimationBatched = false;

    //         this.dragging = false;
    //         this.dragStart = Point.Empty;

    //         this.beginUpdateCount = 0;

    //         this.initialising = false;
    //         this.layout = false;
    //     }

    //     #endregion


    //     #region Methods

    //     #region Animation

    //     #region Fade Collapse/Expand

    //     /// <summary>
    //     /// Collapses the group without any animation.  
    //     /// </summary>
    //     public void Collapse()
    //     {
    //         this.collapsed = true;

    //         if (!this.Animating && this.Height != this.HeaderHeight)
    //         {
    //             this.Height = this.headerHeight;

    //             // fix: Raise StateChanged event
    //             //      Jewlin (jewlin88@hotmail.com)
    //             //      22/10/2004
    //             //      v3.0
    //             this.OnStateChanged(new ExpandoEventArgs(this));
    //         }
    //     }


    //     /// <summary>
    //     /// Expands the group without any animation.  
    //     /// </summary>
    //     public void Expand()
    //     {
    //         this.collapsed = false;

    //         if (!this.Animating && this.Height != this.ExpandedHeight)
    //         {
    //             this.Height = this.ExpandedHeight;

    //             // fix: Raise StateChanged event
    //             //      Jewlin (jewlin88@hotmail.com)
    //             //      22/10/2004
    //             //      v3.0
    //             this.OnStateChanged(new ExpandoEventArgs(this));
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Expando ready to start its collapse/expand animation
    //     /// </summary>
    //     protected void StartFadeAnimation()
    //     {
    //         //
    //         this.animatingFade = true;

    //         //
    //         this.SuspendLayout();

    //         // get an image of the client area that we can
    //         // use for alpha-blending in our animation
    //         this.animationImage = this.GetFadeAnimationImage();

    //         // set each control invisible (otherwise they
    //         // appear to slide off the bottom of the group)
    //         foreach (Control control in this.Controls)
    //         {
    //             control.Visible = false;
    //         }

    //         // restart the layout engine
    //         this.ResumeLayout(false);
    //     }


    //     /// <summary>
    //     /// Updates the next "frame" of the animation
    //     /// </summary>
    //     /// <param name="animationStepNum">The current step in the animation</param>
    //     /// <param name="numAnimationSteps">The total number of steps in the animation</param>
    //     protected void UpdateFadeAnimation(int animationStepNum, int numAnimationSteps)
    //     {
    //         // fix: use the precalculated heights to determine 
    //         //      the correct height
    //         //      David Nissimoff (dudi_001@yahoo.com.br)
    //         //      22/10/2004
    //         //      v3.0

    //         // set the height of the group
    //         if (this.collapsed)
    //         {
    //             this.Height = this.fadeHeights[animationStepNum - 1] + this.headerHeight;
    //         }
    //         else
    //         {
    //             this.Height = (this.ExpandedHeight - this.HeaderHeight) - this.fadeHeights[animationStepNum - 1] + this.HeaderHeight - 1;
    //         }

    //         if (this.TaskPane != null)
    //         {
    //             this.TaskPane.DoLayout();
    //         }
    //         else
    //         {
    //             // draw the next frame
    //             this.Invalidate();
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Expando to stop its animation
    //     /// </summary>
    //     protected void StopFadeAnimation()
    //     {
    //         //
    //         this.animatingFade = false;

    //         //
    //         this.SuspendLayout();

    //         // get rid of the image used for the animation
    //         this.animationImage.Dispose();
    //         this.animationImage = null;

    //         // set the final height of the group, depending on
    //         // whether we are collapsed or expanded
    //         if (this.collapsed)
    //         {
    //             this.Height = this.HeaderHeight;
    //         }
    //         else
    //         {
    //             this.Height = this.ExpandedHeight;
    //         }

    //         // set each control visible again
    //         foreach (Control control in this.Controls)
    //         {
    //             control.Visible = !this.hiddenControls.Contains(control);
    //         }

    //         //
    //         this.ResumeLayout(true);

    //         if (this.TaskPane != null)
    //         {
    //             this.TaskPane.DoLayout();
    //         }
    //     }


    //     /// <summary>
    //     /// Returns an image of the group's display area to be used
    //     /// in the fade animation
    //     /// </summary>
    //     /// <returns>The Image to use during the fade animation</returns>
    //     protected Image GetFadeAnimationImage()
    //     {
    //         if (this.Height == this.ExpandedHeight)
    //         {
    //             return this.GetExpandedImage();
    //         }
    //         else
    //         {
    //             return this.GetCollapsedImage();
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the image to be used in the animation while the 
    //     /// Expando is in its expanded state
    //     /// </summary>
    //     /// <returns>The Image to use during the fade animation</returns>
    //     protected Image GetExpandedImage()
    //     {
    //         // create a new image to draw into
    //         Image image = new Bitmap(this.Width, this.Height);

    //         // get a graphics object we can draw into
    //         Graphics g = Graphics.FromImage(image);
    //         IntPtr hDC = g.GetHdc();

    //         // some flags to tell the control how to draw itself
    //         IntPtr flags = (IntPtr)(WmPrintFlags.PRF_CLIENT | WmPrintFlags.PRF_CHILDREN | WmPrintFlags.PRF_ERASEBKGND);

    //         // tell the control to draw itself
    //         NativeMethods.SendMessage(this.Handle, WindowMessageFlags.WM_PRINT, hDC, flags);

    //         // clean up resources
    //         g.ReleaseHdc(hDC);
    //         g.Dispose();

    //         // return the completed animation image
    //         return image;
    //     }


    //     /// <summary>
    //     /// Gets the image to be used in the animation while the 
    //     /// Expando is in its collapsed state
    //     /// </summary>
    //     /// <returns>The Image to use during the fade animation</returns>
    //     protected Image GetCollapsedImage()
    //     {
    //         // this is pretty nasty.  after much experimentation, 
    //         // this is the least preferred way to get the image as
    //         // it is a pain in the backside, but it stops any 
    //         // flickering and it gets xp themed controls to draw 
    //         // their borders properly.
    //         // we have to do this in two stages:
    //         //    1) pretend we're expanded and draw our background,
    //         //       borders and "client area" into a bitmap
    //         //    2) set the bitmap as our dummyPanel's background, 
    //         //       move all our controls onto the dummyPanel and 
    //         //       get the dummyPanel to print itself

    //         int width = this.Width;
    //         int height = this.ExpandedHeight;


    //         // create a new image to draw that is the same
    //         // size we would be if we were expanded
    //         Image backImage = new Bitmap(width, height);

    //         // get a graphics object we can draw into
    //         Graphics g = Graphics.FromImage(backImage);

    //         // draw our parents background
    //         this.PaintTransparentBackground(g, new Rectangle(0, 0, width, height));

    //         // don't need to draw the titlebar as it is ignored 
    //         // when we paint with the animation image, but we do 
    //         // need to draw the borders and "client area"

    //         this.OnPaintTitleBarBackground(g);
    //         this.OnPaintTitleBar(g);

    //         // borders
    //         using (SolidBrush brush = new SolidBrush(this.BorderColor))
    //         {
    //             // top border
    //             g.FillRectangle(brush,
    //                 this.Border.Left,
    //                 this.HeaderHeight,
    //                 width - this.Border.Left - this.Border.Right,
    //                 this.Border.Top);

    //             // left border
    //             g.FillRectangle(brush,
    //                 0,
    //                 this.HeaderHeight,
    //                 this.Border.Left,
    //                 height - this.HeaderHeight);

    //             // right border
    //             g.FillRectangle(brush,
    //                 width - this.Border.Right,
    //                 this.HeaderHeight,
    //                 this.Border.Right,
    //                 height - this.HeaderHeight);

    //             // bottom border
    //             g.FillRectangle(brush,
    //                 this.Border.Left,
    //                 height - this.Border.Bottom,
    //                 width - this.Border.Left - this.Border.Right,
    //                 this.Border.Bottom);
    //         }

    //         // "client area"
    //         using (SolidBrush brush = new SolidBrush(this.BackColor))
    //         {
    //             g.FillRectangle(brush,
    //                 this.Border.Left,
    //                 this.HeaderHeight,
    //                 width - this.Border.Left - this.Border.Right,
    //                 height - this.HeaderHeight - this.Border.Bottom - this.Border.Top);
    //         }

    //         // check if we have a background image
    //         if (this.BackImage != null)
    //         {
    //             // tile the backImage
    //             using (TextureBrush brush = new TextureBrush(this.BackImage, WrapMode.Tile))
    //             {
    //                 g.FillRectangle(brush,
    //                     this.Border.Left,
    //                     this.HeaderHeight,
    //                     width - this.Border.Left - this.Border.Right,
    //                     height - this.HeaderHeight - this.Border.Bottom - this.Border.Top);
    //             }
    //         }

    //         // watermark
    //         if (this.Watermark != null)
    //         {
    //             // work out a rough location of where the watermark should go
    //             Rectangle rect = new Rectangle(0, 0, this.Watermark.Width, this.Watermark.Height);
    //             rect.X = width - this.Border.Right - this.Watermark.Width;
    //             rect.Y = height - this.Border.Bottom - this.Watermark.Height;

    //             // shrink the destination rect if necesary so that we
    //             // can see all of the image

    //             if (rect.X < 0)
    //             {
    //                 rect.X = 0;
    //             }

    //             if (rect.Width > this.ClientRectangle.Width)
    //             {
    //                 rect.Width = this.ClientRectangle.Width;
    //             }

    //             if (rect.Y < this.DisplayRectangle.Top)
    //             {
    //                 rect.Y = this.DisplayRectangle.Top;
    //             }

    //             if (rect.Height > this.DisplayRectangle.Height)
    //             {
    //                 rect.Height = this.DisplayRectangle.Height;
    //             }

    //             // draw the watermark
    //             g.DrawImage(this.Watermark, rect);
    //         }

    //         // cleanup resources;
    //         g.Dispose();


    //         // make sure the dummyPanel is the same size as our image
    //         // (we don't want any tiling of the image)
    //         this.dummyPanel.Size = new Size(width, height);
    //         this.dummyPanel.HeaderHeight = this.HeaderHeight;
    //         this.dummyPanel.Border = this.Border;

    //         // set the image as the dummyPanels background
    //         this.dummyPanel.BackImage = backImage;

    //         // move all our controls to the dummyPanel, and then add
    //         // the dummyPanel to us
    //         while (this.Controls.Count > 0)
    //         {
    //             Control control = this.Controls[0];

    //             this.Controls.RemoveAt(0);
    //             this.dummyPanel.Controls.Add(control);

    //             control.Visible = !this.hiddenControls.Contains(control);
    //         }
    //         this.Controls.Add(this.dummyPanel);


    //         // create a new image for the dummyPanel to draw itself into
    //         Image image = new Bitmap(width, height);

    //         // get a graphics object we can draw into
    //         g = Graphics.FromImage(image);
    //         IntPtr hDC = g.GetHdc();

    //         // some flags to tell the control how to draw itself
    //         IntPtr flags = (IntPtr)(WmPrintFlags.PRF_CLIENT | WmPrintFlags.PRF_CHILDREN);

    //         // tell the control to draw itself
    //         NativeMethods.SendMessage(this.dummyPanel.Handle, WindowMessageFlags.WM_PRINT, hDC, flags);

    //         // clean up resources
    //         g.ReleaseHdc(hDC);
    //         g.Dispose();

    //         this.Controls.Remove(this.dummyPanel);

    //         // get our controls back
    //         while (this.dummyPanel.Controls.Count > 0)
    //         {
    //             Control control = this.dummyPanel.Controls[0];

    //             control.Visible = false;

    //             this.dummyPanel.Controls.RemoveAt(0);
    //             this.Controls.Add(control);
    //         }

    //         // dispose of the background image
    //         this.dummyPanel.BackImage = null;
    //         backImage.Dispose();

    //         return image;
    //     }


    //     // Added: CalcAnimationHeights()
    //     //        David Nissimoff (dudi_001@yahoo.com.br)
    //     //        22/10/2004
    //     //        v3.0

    //     /// <summary>
    //     /// Caches the heights that the Expando should be for each frame 
    //     /// of a fade animation
    //     /// </summary>
    //     internal void CalcAnimationHeights()
    //     {
    //         // Windows XP uses a Bezier curve to calculate the height of 
    //         // an Expando during a fade animation, so here we precalculate 
    //         // the height of the "client area" for each frame.
    //         // 
    //         // I can't describe what's happening better than David Nissimoff, 
    //         // so here's David's description of what goes on:
    //         //
    //         //   "The only thing that I've noticed is that the animation routine 
    //         // doesn't completely simulate the one used in Windows. After 2 days 
    //         // of endless tests I have finally discovered what should've been written 
    //         // to accurately simulate Windows XP behaviour.
    //         //   I first created a simple application in VB that would copy an 
    //         // area of the screen (set to one of the Windows' expandos) every time 
    //         // it changed. Having that information, analyzing every frame of the 
    //         // animation I could see that it would always be formed of 23 steps.
    //         //    Once having all of the animation, frame by frame, I could see 
    //         // that the expando's height obeyed to a bézier curve. For testing 
    //         // purposes, I have created an application that draws the bézier curve 
    //         // on top of the frames put side by side, and it matches 100%.
    //         //    The height of the expando in each step would be the vertical 
    //         // position of the bézier in the horizontal position(i.e. the step).
    //         //    A bézier should be drawn into a Graphics object, with x1 set to 
    //         // 0 (initial step = 0) and y1 to the initial height of the expando to 
    //         // be animated. The first control point (x2,y2) is defined by:
    //         //    x2 = (numAnimationSteps / 4) * 3
    //         //    y2 = (HeightVariation / 4) * 3
    //         // The second control point (x3,y3) is defined as follows:
    //         //    x3 = numAnimationSteps / 4
    //         //    y3 = HeightVariation / 4
    //         // The end point (x3,y3) would be:
    //         //    x4 = 22 --> 23 steps = 0 to 22
    //         //    y4 = FinalAnimationHeight
    //         // Then, to get the height of the expando on any desired step, you 
    //         // should call the Bitmap used to create the Graphics and look pixel by 
    //         // pixel in the column of the step number until you find the curve."
    //         //
    //         // I hope that helps ;)

    //         using (Bitmap bitmap = new Bitmap(this.fadeHeights.Length, this.ExpandedHeight - this.HeaderHeight))
    //         {
    //             // draw the bezier curve
    //             using (Graphics g = Graphics.FromImage(bitmap))
    //             {
    //                 g.Clear(Color.White);
    //                 g.DrawBezier(new Pen(Color.Black),
    //                     0,
    //                     bitmap.Height - 1,
    //                     bitmap.Width / 4 * 3,
    //                     bitmap.Height / 4 * 3,
    //                     bitmap.Width / 4,
    //                     bitmap.Height / 4,
    //                     bitmap.Width - 1,
    //                     0);
    //             }

    //             // extract heights
    //             for (int i = 0; i < bitmap.Width; i++)
    //             {
    //                 int j = bitmap.Height - 1;

    //                 for (; j > 0; j--)
    //                 {
    //                     if (bitmap.GetPixel(i, j).R == 0)
    //                     {
    //                         break;
    //                     }
    //                 }

    //                 this.fadeHeights[i] = j;
    //             }
    //         }
    //     }

    //     #endregion

    //     #region Slide Show/Hide

    //     /// <summary>
    //     /// Gets the Expando ready to start its show/hide animation
    //     /// </summary>
    //     protected internal void StartSlideAnimation()
    //     {
    //         this.animatingSlide = true;

    //         this.slideEndHeight = this.CalcHeightAndLayout();
    //     }


    //     /// <summary>
    //     /// Updates the next "frame" of a slide animation
    //     /// </summary>
    //     /// <param name="animationStepNum">The current step in the animation</param>
    //     /// <param name="numAnimationSteps">The total number of steps in the animation</param>
    //     protected internal void UpdateSlideAnimation(int animationStepNum, int numAnimationSteps)
    //     {
    //         // the percentage we need to adjust our height by
    //         // double step = (1 / (double) numAnimationSteps) * animationStepNum;
    //         // replacement by: Joel Holdsworth (joel@airwebreathe.org.uk)
    //         //                 Paolo Messina (ppescher@hotmail.com)
    //         //                 05/06/2004
    //         //                 v1.1
    //         double step = (1.0 - Math.Cos(Math.PI * (double)animationStepNum / (double)numAnimationSteps)) / 2.0;

    //         // set the height of the group
    //         this.Height = this.expandedHeight + (int)((this.slideEndHeight - this.expandedHeight) * step);

    //         if (this.TaskPane != null)
    //         {
    //             this.TaskPane.DoLayout();
    //         }
    //         else
    //         {
    //             // draw the next frame
    //             this.Invalidate();
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Expando to stop its animation
    //     /// </summary>
    //     protected internal void StopSlideAnimation()
    //     {
    //         this.animatingSlide = false;

    //         // make sure we're the right height
    //         this.Height = this.slideEndHeight;
    //         this.slideEndHeight = -1;

    //         this.DoLayout();
    //     }

    //     #endregion

    //     #endregion

    //     #region Controls

    //     /// <summary>
    //     /// Hides the specified Control
    //     /// </summary>
    //     /// <param name="control">The Control to hide</param>
    //     public void HideControl(Control control)
    //     {
    //         this.HideControl(new Control[] { control });
    //     }


    //     /// <summary>
    //     /// Hides the Controls contained in the specified array
    //     /// </summary>
    //     /// <param name="controls">The array Controls to hide</param>
    //     public void HideControl(Control[] controls)
    //     {
    //         // don't bother if we are animating
    //         if (this.Animating || this.Collapsed)
    //         {
    //             return;
    //         }

    //         this.SuspendLayout();

    //         // flag to check if we actually hid any controls
    //         bool anyHidden = false;

    //         foreach (Control control in controls)
    //         {
    //             // hide the control if we own it and it is not already hidden
    //             if (this.Controls.Contains(control) && !this.hiddenControls.Contains(control))
    //             {
    //                 anyHidden = true;

    //                 control.Visible = false;
    //                 this.hiddenControls.Add(control);
    //             }
    //         }

    //         this.ResumeLayout(false);

    //         // if we didn't hide any, get out of here
    //         if (!anyHidden)
    //         {
    //             return;
    //         }

    //         //
    //         if (this.beginUpdateCount > 0)
    //         {
    //             this.slideAnimationBatched = true;

    //             return;
    //         }

    //         // are we able to animate?
    //         if (!this.AutoLayout || !this.Animate)
    //         {
    //             // guess not
    //             this.DoLayout();
    //         }
    //         else
    //         {
    //             if (this.animationHelper != null)
    //             {
    //                 this.animationHelper.Dispose();
    //                 this.animationHelper = null;
    //             }

    //             this.animationHelper = new AnimationHelper(this, AnimationHelper.SlideAnimation);

    //             this.animationHelper.StartAnimation();
    //         }
    //     }


    //     /// <summary>
    //     /// Shows the specified Control
    //     /// </summary>
    //     /// <param name="control">The Control to show</param>
    //     public void ShowControl(Control control)
    //     {
    //         this.ShowControl(new Control[] { control });
    //     }


    //     /// <summary>
    //     /// Shows the Controls contained in the specified array
    //     /// </summary>
    //     /// <param name="controls">The array Controls to show</param>
    //     public void ShowControl(Control[] controls)
    //     {
    //         // don't bother if we are animating
    //         if (this.Animating || this.Collapsed)
    //         {
    //             return;
    //         }

    //         this.SuspendLayout();

    //         // flag to check if any controls were shown
    //         bool anyHidden = false;

    //         foreach (Control control in controls)
    //         {
    //             // show the control if we own it and it is not already shown
    //             if (this.Controls.Contains(control) && this.hiddenControls.Contains(control))
    //             {
    //                 anyHidden = true;

    //                 control.Visible = true;
    //                 this.hiddenControls.Remove(control);
    //             }
    //         }

    //         this.ResumeLayout(false);

    //         // if we didn't show any, get out of here
    //         if (!anyHidden)
    //         {
    //             return;
    //         }

    //         //
    //         if (this.beginUpdateCount > 0)
    //         {
    //             this.slideAnimationBatched = true;

    //             return;
    //         }

    //         // are we able to animate?
    //         if (!this.AutoLayout || !this.Animate)
    //         {
    //             // guess not
    //             this.DoLayout();
    //         }
    //         else
    //         {
    //             if (this.animationHelper != null)
    //             {
    //                 this.animationHelper.Dispose();
    //                 this.animationHelper = null;
    //             }

    //             this.animationHelper = new AnimationHelper(this, AnimationHelper.SlideAnimation);

    //             this.animationHelper.StartAnimation();
    //         }
    //     }

    //     #endregion

    //     #region Dispose

    //     /// <summary> 
    //     /// Releases the unmanaged resources used by the Expando and 
    //     /// optionally releases the managed resources
    //     /// </summary>
    //     /// <param name="disposing">True to release both managed and unmanaged 
    //     /// resources; false to release only unmanaged resources</param>
    //     protected override void Dispose(bool disposing)
    //     {
    //         if (disposing)
    //         {
    //             if (components != null)
    //             {
    //                 components.Dispose();
    //             }

    //             if (this.systemSettings != null)
    //             {
    //                 this.systemSettings.Dispose();
    //                 this.systemSettings = null;
    //             }

    //             if (this.animationHelper != null)
    //             {
    //                 this.animationHelper.Dispose();
    //                 this.animationHelper = null;
    //             }
    //         }

    //         base.Dispose(disposing);
    //     }

    //     #endregion

    //     #region Invalidation

    //     /// <summary>
    //     /// Invalidates the titlebar area
    //     /// </summary>
    //     protected void InvalidateTitleBar()
    //     {
    //         this.Invalidate(new Rectangle(0, 0, this.Width, this.headerHeight), false);
    //     }

    //     #endregion

    //     #region ISupportInitialize Members

    //     /// <summary>
    //     /// Signals the object that initialization is starting
    //     /// </summary>
    //     public void BeginInit()
    //     {
    //         this.initialising = true;
    //     }


    //     /// <summary>
    //     /// Signals the object that initialization is complete
    //     /// </summary>
    //     public void EndInit()
    //     {
    //         this.initialising = false;

    //         this.DoLayout();

    //         this.CalcAnimationHeights();
    //     }


    //     /// <summary>
    //     /// Gets whether the Expando is currently initializing
    //     /// </summary>
    //     [Browsable(false)]
    //     public bool Initialising
    //     {
    //         get
    //         {
    //             return this.initialising;
    //         }
    //     }

    //     #endregion

    //     #region Keys

    //     /// <summary>
    //     /// Processes a dialog key
    //     /// </summary>
    //     /// <param name="keyData">One of the Keys values that represents 
    //     /// the key to process</param>
    //     /// <returns>true if the key was processed by the control; 
    //     /// otherwise, false</returns>
    //     protected override bool ProcessDialogKey(Keys keyData)
    //     {
    //         if (this.UseDefaultTabHandling || this.Parent == null || !(this.Parent is TaskPane))
    //         {
    //             return base.ProcessDialogKey(keyData);
    //         }

    //         Keys key = keyData & Keys.KeyCode;

    //         if (key != Keys.Tab)
    //         {
    //             switch (key)
    //             {
    //                 case Keys.Left:
    //                 case Keys.Up:
    //                 case Keys.Right:
    //                 case Keys.Down:
    //                     {
    //                         if (this.ProcessArrowKey(((key == Keys.Right) ? true : (key == Keys.Down))))
    //                         {
    //                             return true;
    //                         }

    //                         break;
    //                     }
    //             }

    //             return base.ProcessDialogKey(keyData);
    //         }

    //         if (key == Keys.Tab)
    //         {
    //             if (this.ProcessTabKey(((keyData & Keys.Shift) == Keys.None)))
    //             {
    //                 return true;
    //             }
    //         }

    //         return base.ProcessDialogKey(keyData);
    //     }


    //     /// <summary>
    //     /// Selects the next available control and makes it the active control
    //     /// </summary>
    //     /// <param name="forward">true to cycle forward through the controls in 
    //     /// the Expando; otherwise, false</param>
    //     /// <returns>true if a control is selected; otherwise, false</returns>
    //     protected virtual bool ProcessTabKey(bool forward)
    //     {
    //         if (forward)
    //         {
    //             if ((this.Focused && !this.Collapsed) || this.Items.Count == 0)
    //             {
    //                 return base.SelectNextControl(this, forward, true, true, false);
    //             }
    //             else
    //             {
    //                 return this.Parent.SelectNextControl(this.Items[this.Items.Count - 1], forward, true, true, false);
    //             }
    //         }
    //         else
    //         {
    //             if (this.Focused || this.Items.Count == 0 || this.Collapsed)
    //             {
    //                 return this.Parent.SelectNextControl(this, forward, true, true, false);
    //             }
    //             else
    //             {
    //                 this.Select();

    //                 return this.Focused;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Selects the next available control and makes it the active control
    //     /// </summary>
    //     /// <param name="forward">true to cycle forward through the controls in 
    //     /// the Expando; otherwise, false</param>
    //     /// <returns>true if a control is selected; otherwise, false</returns>
    //     protected virtual bool ProcessArrowKey(bool forward)
    //     {
    //         if (forward)
    //         {
    //             if (this.Focused && !this.Collapsed)
    //             {
    //                 return base.SelectNextControl(this, forward, true, true, false);
    //             }
    //             else if ((this.Items.Count > 0 && this.Items[this.Items.Count - 1].Focused) || this.Collapsed)
    //             {
    //                 int index = this.TaskPane.Expandos.IndexOf(this);

    //                 if (index < this.TaskPane.Expandos.Count - 1)
    //                 {
    //                     this.TaskPane.Expandos[index + 1].Select();

    //                     return this.TaskPane.Expandos[index + 1].Focused;
    //                 }
    //                 else
    //                 {
    //                     return true;
    //                 }
    //             }
    //         }
    //         else
    //         {
    //             if (this.Focused)
    //             {
    //                 int index = this.TaskPane.Expandos.IndexOf(this);

    //                 if (index > 0)
    //                 {
    //                     return this.Parent.SelectNextControl(this, forward, true, true, false);
    //                 }
    //                 else
    //                 {
    //                     return true;
    //                 }
    //             }
    //             else if (this.Items.Count > 0)
    //             {
    //                 if (this.Items[0].Focused)
    //                 {
    //                     this.Select();

    //                     return this.Focused;
    //                 }
    //                 else
    //                 {
    //                     return this.Parent.SelectNextControl(this.FindFocusedChild(), forward, true, true, false);
    //                 }
    //             }
    //         }

    //         return false;
    //     }


    //     /// <summary>
    //     /// Gets the control contained in the Expando that currently has focus
    //     /// </summary>
    //     /// <returns>The control contained in the Expando that currently has focus, 
    //     /// or null if no child controls have focus</returns>
    //     protected Control FindFocusedChild()
    //     {
    //         if (this.Controls.Count == 0)
    //         {
    //             return null;
    //         }

    //         foreach (Control control in this.Controls)
    //         {
    //             if (control.ContainsFocus)
    //             {
    //                 return control;
    //             }
    //         }

    //         return null;
    //     }

    //     #endregion

    //     #region Layout

    //     /// <summary>
    //     /// Prevents the Expando from drawing until the EndUpdate method is called
    //     /// </summary>
    //     public void BeginUpdate()
    //     {
    //         this.beginUpdateCount++;
    //     }


    //     /// <summary>
    //     /// Resumes drawing of the Expando after drawing is suspended by the 
    //     /// BeginUpdate method
    //     /// </summary>
    //     public void EndUpdate()
    //     {
    //         this.beginUpdateCount = Math.Max(--this.beginUpdateCount, 0);

    //         if (beginUpdateCount == 0)
    //         {
    //             if (this.slideAnimationBatched)
    //             {
    //                 this.slideAnimationBatched = false;

    //                 if (this.Animate && this.AutoLayout)
    //                 {
    //                     if (this.animationHelper != null)
    //                     {
    //                         this.animationHelper.Dispose();
    //                         this.animationHelper = null;
    //                     }

    //                     this.animationHelper = new AnimationHelper(this, AnimationHelper.SlideAnimation);

    //                     this.animationHelper.StartAnimation();
    //                 }
    //                 else
    //                 {
    //                     this.DoLayout(true);
    //                 }
    //             }
    //             else
    //             {
    //                 this.DoLayout(true);
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Forces the control to apply layout logic to child controls, 
    //     /// and adjusts the height of the Expando if necessary
    //     /// </summary>
    //     public void DoLayout()
    //     {
    //         this.DoLayout(true);
    //     }


    //     /// <summary>
    //     /// Forces the control to apply layout logic to child controls, 
    //     /// and adjusts the height of the Expando if necessary
    //     /// </summary>
    //     public virtual void DoLayout(bool performRealLayout)
    //     {
    //         if (this.layout)
    //         {
    //             return;
    //         }

    //         this.layout = true;

    //         // stop the layout engine
    //         this.SuspendLayout();

    //         // work out the height of the header section

    //         // is there an image to display on the titlebar
    //         if (this.titleImage != null)
    //         {
    //             // is the image bigger than the height of the titlebar
    //             if (this.titleImage.Height > this.titleBarHeight)
    //             {
    //                 this.headerHeight = this.titleImage.Height;
    //             }
    //             // is the image smaller than the height of the titlebar
    //             else if (this.titleImage.Height < this.titleBarHeight)
    //             {
    //                 this.headerHeight = this.titleBarHeight;
    //             }
    //             // is the image smaller than the current header height
    //             else if (this.titleImage.Height < this.headerHeight)
    //             {
    //                 this.headerHeight = this.titleImage.Height;
    //             }
    //         }
    //         else
    //         {
    //             this.headerHeight = this.titleBarHeight;
    //         }

    //         // do we need to layout our items
    //         if (this.AutoLayout)
    //         {
    //             Control c;
    //             TaskItem ti;
    //             Point p;

    //             // work out how wide to make the controls, and where
    //             // the top of the first control should be
    //             int y = this.DisplayRectangle.Y + this.Padding.Top;
    //             int width = this.PseudoClientRect.Width - this.Padding.Left - this.Padding.Right;

    //             // for each control in our list...
    //             for (int i = 0; i < this.itemList.Count; i++)
    //             {
    //                 c = (Control)this.itemList[i];

    //                 if (this.hiddenControls.Contains(c))
    //                 {
    //                     continue;
    //                 }

    //                 // set the starting point
    //                 p = new Point(this.Padding.Left, y);

    //                 // is the control a TaskItem?  if so, we may
    //                 // need to take into account the margins
    //                 if (c is TaskItem)
    //                 {
    //                     ti = (TaskItem)c;

    //                     // only adjust the y co-ord if this isn't the first item 
    //                     if (i > 0)
    //                     {
    //                         y += ti.Margin.Top;

    //                         p.Y = y;
    //                     }

    //                     // adjust and set the width and height
    //                     ti.Width = width;
    //                     ti.Height = ti.PreferredHeight;
    //                 }
    //                 else
    //                 {
    //                     y += this.systemSettings.TaskItem.Margin.Top;

    //                     p.Y = y;
    //                 }

    //                 // set the location of the control
    //                 c.Location = p;

    //                 // update the next starting point.
    //                 y += c.Height;

    //                 // is the control a TaskItem?  if so, we may
    //                 // need to take into account the bottom margin
    //                 if (i < this.itemList.Count - 1)
    //                 {
    //                     if (c is TaskItem)
    //                     {
    //                         ti = (TaskItem)c;

    //                         y += ti.Margin.Bottom;
    //                     }
    //                     else
    //                     {
    //                         y += this.systemSettings.TaskItem.Margin.Bottom;
    //                     }
    //                 }
    //             }

    //             // workout where the bottom of the Expando should be
    //             y += this.Padding.Bottom + this.Border.Bottom;

    //             // adjust the ExpandedHeight if they're not the same
    //             if (y != this.ExpandedHeight)
    //             {
    //                 this.ExpandedHeight = y;

    //                 // if we're not collapsed then we had better change
    //                 // our height as well
    //                 if (!this.Collapsed)
    //                 {
    //                     this.Height = this.ExpandedHeight;

    //                     // if we belong to a TaskPane then it needs to
    //                     // re-layout its Expandos
    //                     if (this.TaskPane != null)
    //                     {
    //                         this.TaskPane.DoLayout(true);
    //                     }
    //                 }
    //             }
    //         }

    //         if (this.Collapsed)
    //         {
    //             this.Height = this.HeaderHeight;
    //         }

    //         // restart the layout engine
    //         this.ResumeLayout(performRealLayout);

    //         this.layout = false;
    //     }


    //     /// <summary>
    //     /// Calculates the height that the Expando would be if a 
    //     /// call to DoLayout() were made
    //     /// </summary>
    //     /// <returns>The height that the Expando would be if a 
    //     /// call to DoLayout() were made</returns>
    //     internal int CalcHeightAndLayout()
    //     {
    //         // stop the layout engine
    //         this.SuspendLayout();

    //         // work out the height of the header section

    //         // is there an image to display on the titlebar
    //         if (this.titleImage != null)
    //         {
    //             // is the image bigger than the height of the titlebar
    //             if (this.titleImage.Height > this.titleBarHeight)
    //             {
    //                 this.headerHeight = this.titleImage.Height;
    //             }
    //             // is the image smaller than the height of the titlebar
    //             else if (this.titleImage.Height < this.titleBarHeight)
    //             {
    //                 this.headerHeight = this.titleBarHeight;
    //             }
    //             // is the image smaller than the current header height
    //             else if (this.titleImage.Height < this.headerHeight)
    //             {
    //                 this.headerHeight = this.titleImage.Height;
    //             }
    //         }
    //         else
    //         {
    //             this.headerHeight = this.titleBarHeight;
    //         }

    //         int y = -1;

    //         // do we need to layout our items
    //         if (this.AutoLayout)
    //         {
    //             Control c;
    //             TaskItem ti;
    //             Point p;

    //             // work out how wide to make the controls, and where
    //             // the top of the first control should be
    //             y = this.DisplayRectangle.Y + this.Padding.Top;
    //             int width = this.PseudoClientRect.Width - this.Padding.Left - this.Padding.Right;

    //             // for each control in our list...
    //             for (int i = 0; i < this.itemList.Count; i++)
    //             {
    //                 c = (Control)this.itemList[i];

    //                 if (this.hiddenControls.Contains(c))
    //                 {
    //                     continue;
    //                 }

    //                 // set the starting point
    //                 p = new Point(this.Padding.Left, y);

    //                 // is the control a TaskItem?  if so, we may
    //                 // need to take into account the margins
    //                 if (c is TaskItem)
    //                 {
    //                     ti = (TaskItem)c;

    //                     // only adjust the y co-ord if this isn't the first item 
    //                     if (i > 0)
    //                     {
    //                         y += ti.Margin.Top;

    //                         p.Y = y;
    //                     }

    //                     // adjust and set the width and height
    //                     ti.Width = width;
    //                     ti.Height = ti.PreferredHeight;
    //                 }
    //                 else
    //                 {
    //                     y += this.systemSettings.TaskItem.Margin.Top;

    //                     p.Y = y;
    //                 }

    //                 // set the location of the control
    //                 c.Location = p;

    //                 // update the next starting point.
    //                 y += c.Height;

    //                 // is the control a TaskItem?  if so, we may
    //                 // need to take into account the bottom margin
    //                 if (i < this.itemList.Count - 1)
    //                 {
    //                     if (c is TaskItem)
    //                     {
    //                         ti = (TaskItem)c;

    //                         y += ti.Margin.Bottom;
    //                     }
    //                     else
    //                     {
    //                         y += this.systemSettings.TaskItem.Margin.Bottom;
    //                     }
    //                 }
    //             }

    //             // workout where the bottom of the Expando should be
    //             y += this.Padding.Bottom + this.Border.Bottom;
    //         }

    //         // restart the layout engine
    //         this.ResumeLayout(true);

    //         return y;
    //     }


    //     /// <summary>
    //     /// Updates the layout of the Expandos items while in design mode, and 
    //     /// adds/removes itemss from the ControlCollection as necessary
    //     /// </summary>
    //     internal void UpdateItems()
    //     {
    //         if (this.Items.Count == this.Controls.Count)
    //         {
    //             // make sure the the items index in the ControlCollection 
    //             // are the same as in the ItemCollection (indexes in the 
    //             // ItemCollection may have changed due to the user moving 
    //             // them around in the editor)
    //             this.MatchControlCollToItemColl();

    //             return;
    //         }

    //         // were any items added
    //         if (this.Items.Count > this.Controls.Count)
    //         {
    //             // add any extra items in the ItemCollection to the 
    //             // ControlCollection
    //             for (int i = 0; i < this.Items.Count; i++)
    //             {
    //                 if (!this.Controls.Contains(this.Items[i]))
    //                 {
    //                     this.OnItemAdded(new ControlEventArgs(this.Items[i]));
    //                 }
    //             }
    //         }
    //         else
    //         {
    //             // items were removed
    //             int i = 0;
    //             Control control;

    //             // remove any extra items from the ControlCollection
    //             while (i < this.Controls.Count)
    //             {
    //                 control = (Control)this.Controls[i];

    //                 if (!this.Items.Contains(control))
    //                 {
    //                     this.OnItemRemoved(new ControlEventArgs(control));
    //                 }
    //                 else
    //                 {
    //                     i++;
    //                 }
    //             }
    //         }

    //         this.Invalidate(true);
    //     }


    //     /// <summary>
    //     /// Make sure the controls index in the ControlCollection 
    //     /// are the same as in the ItemCollection (indexes in the 
    //     /// ItemCollection may have changed due to the user moving 
    //     /// them around in the editor or calling ItemCollection.Move())
    //     /// </summary>
    //     internal void MatchControlCollToItemColl()
    //     {
    //         this.SuspendLayout();

    //         for (int i = 0; i < this.Items.Count; i++)
    //         {
    //             this.Controls.SetChildIndex(this.Items[i], i);
    //         }

    //         this.ResumeLayout(false);

    //         this.DoLayout();

    //         this.Invalidate(true);
    //     }


    //     /// <summary>
    //     /// Performs the work of scaling the entire control and any child controls
    //     /// </summary>
    //     /// <param name="dx">The ratio by which to scale the control horizontally</param>
    //     /// <param name="dy">The ratio by which to scale the control vertically</param>
    //     [Obsolete]
    //     protected override void ScaleCore(float dx, float dy)
    //     {
    //         // fix: need to adjust expanded height when scaling
    //         //      AndrewEames (andrew@cognex.com)
    //         //      14/09/2005
    //         //      v3.3

    //         base.ScaleCore(dx, dy);

    //         this.expandedHeight = (int)(expandedHeight * dy);
    //     }

    //     #endregion

    //     #endregion


    //     #region Properties

    //     #region Alignment

    //     /// <summary>
    //     /// Gets the alignment of the text in the title bar.
    //     /// </summary>
    //     [Browsable(false)]
    //     public System.Drawing.ContentAlignment TitleAlignment
    //     {
    //         get
    //         {
    //             if (this.SpecialGroup)
    //             {
    //                 if (this.CustomHeaderSettings.SpecialAlignment != System.Drawing.ContentAlignment.MiddleLeft)
    //                 {
    //                     return this.CustomHeaderSettings.SpecialAlignment;
    //                 }

    //                 return this.SystemSettings.Header.SpecialAlignment;
    //             }

    //             if (this.CustomHeaderSettings.NormalAlignment != System.Drawing.ContentAlignment.MiddleLeft)
    //             {
    //                 return this.CustomHeaderSettings.NormalAlignment;
    //             }

    //             return this.SystemSettings.Header.NormalAlignment;
    //         }
    //     }

    //     #endregion

    //     #region Animation

    //     /// <summary>
    //     /// Gets or sets whether the Expando is allowed to animate
    //     /// </summary>
    //     [Category("Appearance"),
    //     DefaultValue(false),
    //     Description("Specifies whether the Expando is allowed to animate")]
    //     public bool Animate
    //     {
    //         get
    //         {
    //             return this.animate;
    //         }

    //         set
    //         {
    //             if (this.animate != value)
    //             {
    //                 this.animate = value;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets whether the Expando is currently animating
    //     /// </summary>
    //     [Browsable(false)]
    //     public bool Animating
    //     {
    //         get
    //         {
    //             return (this.animatingFade || this.animatingSlide);
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Image used by the Expando while it is animating
    //     /// </summary>
    //     protected Image AnimationImage
    //     {
    //         get
    //         {
    //             return this.animationImage;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the height that the Expando should be at the end of its 
    //     /// slide animation
    //     /// </summary>
    //     protected int SlideEndHeight
    //     {
    //         get
    //         {
    //             return this.slideEndHeight;
    //         }
    //     }

    //     #endregion

    //     #region Border

    //     /// <summary>
    //     /// Gets the width of the border along each side of the Expando's pane.
    //     /// </summary>
    //     [Browsable(false)]
    //     public Border Border
    //     {
    //         get
    //         {
    //             if (this.SpecialGroup)
    //             {
    //                 if (this.CustomSettings.SpecialBorder != Border.Empty)
    //                 {
    //                     return this.CustomSettings.SpecialBorder;
    //                 }

    //                 return this.SystemSettings.Expando.SpecialBorder;
    //             }

    //             if (this.CustomSettings.NormalBorder != Border.Empty)
    //             {
    //                 return this.CustomSettings.NormalBorder;
    //             }

    //             return this.SystemSettings.Expando.NormalBorder;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the color of the border along each side of the Expando's pane.
    //     /// </summary>
    //     [Browsable(false)]
    //     public Color BorderColor
    //     {
    //         get
    //         {
    //             if (this.SpecialGroup)
    //             {
    //                 if (this.CustomSettings.SpecialBorderColor != Color.Empty)
    //                 {
    //                     return this.CustomSettings.SpecialBorderColor;
    //                 }

    //                 return this.SystemSettings.Expando.SpecialBorderColor;
    //             }

    //             if (this.CustomSettings.NormalBorderColor != Color.Empty)
    //             {
    //                 return this.CustomSettings.NormalBorderColor;
    //             }

    //             return this.SystemSettings.Expando.NormalBorderColor;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the width of the border along each side of the Expando's Title Bar.
    //     /// </summary>
    //     [Browsable(false)]
    //     public Border TitleBorder
    //     {
    //         get
    //         {
    //             if (this.SpecialGroup)
    //             {
    //                 if (this.CustomHeaderSettings.SpecialBorder != Border.Empty)
    //                 {
    //                     return this.CustomHeaderSettings.SpecialBorder;
    //                 }

    //                 return this.SystemSettings.Header.SpecialBorder;
    //             }

    //             if (this.CustomHeaderSettings.NormalBorder != Border.Empty)
    //             {
    //                 return this.CustomHeaderSettings.NormalBorder;
    //             }

    //             return this.SystemSettings.Header.NormalBorder;
    //         }
    //     }

    //     #endregion

    //     #region Color

    //     /// <summary>
    //     /// Gets the background color of the titlebar
    //     /// </summary>
    //     [Browsable(false)]
    //     public Color TitleBackColor
    //     {
    //         get
    //         {
    //             if (this.SpecialGroup)
    //             {
    //                 if (this.CustomHeaderSettings.SpecialBackColor != Color.Empty &&
    //                     this.CustomHeaderSettings.SpecialBackColor != Color.Transparent)
    //                 {
    //                     return this.CustomHeaderSettings.SpecialBackColor;
    //                 }
    //                 else if (this.CustomHeaderSettings.SpecialBorderColor != Color.Empty)
    //                 {
    //                     return this.CustomHeaderSettings.SpecialBorderColor;
    //                 }

    //                 if (this.SystemSettings.Header.SpecialBackColor != Color.Transparent)
    //                 {
    //                     return this.systemSettings.Header.SpecialBackColor;
    //                 }

    //                 return this.SystemSettings.Header.SpecialBorderColor;
    //             }

    //             if (this.CustomHeaderSettings.NormalBackColor != Color.Empty &&
    //                 this.CustomHeaderSettings.NormalBackColor != Color.Transparent)
    //             {
    //                 return this.CustomHeaderSettings.NormalBackColor;
    //             }
    //             else if (this.CustomHeaderSettings.NormalBorderColor != Color.Empty)
    //             {
    //                 return this.CustomHeaderSettings.NormalBorderColor;
    //             }

    //             if (this.SystemSettings.Header.NormalBackColor != Color.Transparent)
    //             {
    //                 return this.systemSettings.Header.NormalBackColor;
    //             }

    //             return this.SystemSettings.Header.NormalBorderColor;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets whether any of the title bar's gradient colors are empty colors
    //     /// </summary>
    //     protected bool AnyCustomTitleGradientsEmpty
    //     {
    //         get
    //         {
    //             if (this.SpecialGroup)
    //             {
    //                 if (this.CustomHeaderSettings.SpecialGradientStartColor == Color.Empty)
    //                 {
    //                     return true;
    //                 }
    //                 else if (this.CustomHeaderSettings.SpecialGradientEndColor == Color.Empty)
    //                 {
    //                     return true;
    //                 }
    //             }
    //             else
    //             {
    //                 if (this.CustomHeaderSettings.NormalGradientStartColor == Color.Empty)
    //                 {
    //                     return true;
    //                 }
    //                 else if (this.CustomHeaderSettings.NormalGradientEndColor == Color.Empty)
    //                 {
    //                     return true;
    //                 }
    //             }

    //             return false;
    //         }
    //     }

    //     #endregion

    //     #region Client Rectangle

    //     /// <summary>
    //     /// Returns a fake Client Rectangle.  
    //     /// The rectangle takes into account the size of the titlebar 
    //     /// and borders (these are actually parts of the real 
    //     /// ClientRectangle)
    //     /// </summary>
    //     protected Rectangle PseudoClientRect
    //     {
    //         get
    //         {
    //             return new Rectangle(this.Border.Left,
    //                 this.HeaderHeight + this.Border.Top,
    //                 this.Width - this.Border.Left - this.Border.Right,
    //                 this.Height - this.HeaderHeight - this.Border.Top - this.Border.Bottom);
    //         }
    //     }


    //     /// <summary>
    //     /// Returns the height of the fake client rectangle
    //     /// </summary>
    //     protected int PseudoClientHeight
    //     {
    //         get
    //         {
    //             return this.Height - this.HeaderHeight - this.Border.Top - this.Border.Bottom;
    //         }
    //     }

    //     #endregion

    //     #region Display Rectangle

    //     /// <summary>
    //     /// Overrides DisplayRectangle so that docked controls
    //     /// don't cover the titlebar or borders
    //     /// </summary>
    //     [Browsable(false)]
    //     public override Rectangle DisplayRectangle
    //     {
    //         get
    //         {
    //             return new Rectangle(this.Border.Left,
    //                 this.HeaderHeight + this.Border.Top,
    //                 this.Width - this.Border.Left - this.Border.Right,
    //                 this.ExpandedHeight - this.HeaderHeight - this.Border.Top - this.Border.Bottom);
    //         }
    //     }


    //     /// <summary>
    //     /// Gets a rectangle that contains the titlebar area
    //     /// </summary>
    //     protected Rectangle TitleBarRectangle
    //     {
    //         get
    //         {
    //             return new Rectangle(0,
    //                 this.HeaderHeight - this.TitleBarHeight,
    //                 this.Width,
    //                 this.TitleBarHeight);
    //         }
    //     }

    //     #endregion

    //     #region Focus

    //     /// <summary>
    //     /// Gets or sets a value indicating whether the Expando should display 
    //     /// focus rectangles
    //     /// </summary>
    //     [Category("Appearance"),
    //     DefaultValue(false),
    //     Description("Determines whether the Expando should display a focus rectangle.")]
    //     public new bool ShowFocusCues
    //     {
    //         get
    //         {
    //             return this.showFocusCues;
    //         }

    //         set
    //         {
    //             if (this.showFocusCues != value)
    //             {
    //                 this.showFocusCues = value;

    //                 if (this.Focused)
    //                 {
    //                     this.InvalidateTitleBar();
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets whether the Expando should use Windows 
    //     /// default Tab handling mechanism
    //     /// </summary>
    //     [Category("Appearance"),
    //     DefaultValue(true),
    //     Description("Specifies whether the Expando should use Windows default Tab handling mechanism")]
    //     public bool UseDefaultTabHandling
    //     {
    //         get
    //         {
    //             return this.useDefaultTabHandling;
    //         }

    //         set
    //         {
    //             this.useDefaultTabHandling = value;
    //         }
    //     }

    //     #endregion

    //     #region Fonts

    //     /// <summary>
    //     /// Gets the color of the Title Bar's text.
    //     /// </summary>
    //     [Browsable(false)]
    //     public Color TitleForeColor
    //     {
    //         get
    //         {
    //             if (this.SpecialGroup)
    //             {
    //                 if (this.CustomHeaderSettings.SpecialTitleColor != Color.Empty)
    //                 {
    //                     return this.CustomHeaderSettings.SpecialTitleColor;
    //                 }

    //                 return this.SystemSettings.Header.SpecialTitleColor;
    //             }

    //             if (this.CustomHeaderSettings.NormalTitleColor != Color.Empty)
    //             {
    //                 return this.CustomHeaderSettings.NormalTitleColor;
    //             }

    //             return this.SystemSettings.Header.NormalTitleColor;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the color of the Title Bar's text when highlighted.
    //     /// </summary>
    //     [Browsable(false)]
    //     public Color TitleHotForeColor
    //     {
    //         get
    //         {
    //             if (this.SpecialGroup)
    //             {
    //                 if (this.CustomHeaderSettings.SpecialTitleHotColor != Color.Empty)
    //                 {
    //                     return this.CustomHeaderSettings.SpecialTitleHotColor;
    //                 }

    //                 return this.SystemSettings.Header.SpecialTitleHotColor;
    //             }

    //             if (this.CustomHeaderSettings.NormalTitleHotColor != Color.Empty)
    //             {
    //                 return this.CustomHeaderSettings.NormalTitleHotColor;
    //             }

    //             return this.SystemSettings.Header.NormalTitleHotColor;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the current color of the Title Bar's text, depending 
    //     /// on the current state of the Expando
    //     /// </summary>
    //     [Browsable(false)]
    //     public Color TitleColor
    //     {
    //         get
    //         {
    //             if (this.FocusState == FocusStates.Mouse)
    //             {
    //                 return this.TitleHotForeColor;
    //             }

    //             return this.TitleForeColor;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the font used to render the Title Bar's text.
    //     /// </summary>
    //     [Browsable(false)]
    //     public Font TitleFont
    //     {
    //         get
    //         {
    //             if (this.CustomHeaderSettings.TitleFont != null)
    //             {
    //                 return this.CustomHeaderSettings.TitleFont;
    //             }

    //             return this.SystemSettings.Header.TitleFont;
    //         }
    //     }

    //     #endregion

    //     #region Images

    //     /// <summary>
    //     /// Gets the expand/collapse arrow image currently displayed 
    //     /// in the title bar, depending on the current state of the Expando
    //     /// </summary>
    //     [Browsable(false)]
    //     public Image ArrowImage
    //     {
    //         get
    //         {
    //             // fix: return null if the Expando isn't allowed to 
    //             //      collapse (this will stop an expand/collapse 
    //             //      arrow appearing on the titlebar
    //             //      dani kenan (dani_k@netvision.net.il)
    //             //      11/10/2004
    //             //      v2.1
    //             if (!this.CanCollapse)
    //             {
    //                 return null;
    //             }

    //             if (this.SpecialGroup)
    //             {
    //                 if (this.collapsed)
    //                 {
    //                     if (this.FocusState == FocusStates.None)
    //                     {
    //                         if (this.CustomHeaderSettings.SpecialArrowDown != null)
    //                         {
    //                             return this.CustomHeaderSettings.SpecialArrowDown;
    //                         }

    //                         return this.SystemSettings.Header.SpecialArrowDown;
    //                     }
    //                     else
    //                     {
    //                         if (this.CustomHeaderSettings.SpecialArrowDownHot != null)
    //                         {
    //                             return this.CustomHeaderSettings.SpecialArrowDownHot;
    //                         }

    //                         return this.SystemSettings.Header.SpecialArrowDownHot;
    //                     }
    //                 }
    //                 else
    //                 {
    //                     if (this.FocusState == FocusStates.None)
    //                     {
    //                         if (this.CustomHeaderSettings.SpecialArrowUp != null)
    //                         {
    //                             return this.CustomHeaderSettings.SpecialArrowUp;
    //                         }

    //                         return this.SystemSettings.Header.SpecialArrowUp;
    //                     }
    //                     else
    //                     {
    //                         if (this.CustomHeaderSettings.SpecialArrowUpHot != null)
    //                         {
    //                             return this.CustomHeaderSettings.SpecialArrowUpHot;
    //                         }

    //                         return this.SystemSettings.Header.SpecialArrowUpHot;
    //                     }
    //                 }
    //             }
    //             else
    //             {
    //                 if (this.collapsed)
    //                 {
    //                     if (this.FocusState == FocusStates.None)
    //                     {
    //                         if (this.CustomHeaderSettings.NormalArrowDown != null)
    //                         {
    //                             return this.CustomHeaderSettings.NormalArrowDown;
    //                         }

    //                         return this.SystemSettings.Header.NormalArrowDown;
    //                     }
    //                     else
    //                     {
    //                         if (this.CustomHeaderSettings.NormalArrowDownHot != null)
    //                         {
    //                             return this.CustomHeaderSettings.NormalArrowDownHot;
    //                         }

    //                         return this.SystemSettings.Header.NormalArrowDownHot;
    //                     }
    //                 }
    //                 else
    //                 {
    //                     if (this.FocusState == FocusStates.None)
    //                     {
    //                         if (this.CustomHeaderSettings.NormalArrowUp != null)
    //                         {
    //                             return this.CustomHeaderSettings.NormalArrowUp;
    //                         }

    //                         return this.SystemSettings.Header.NormalArrowUp;
    //                     }
    //                     else
    //                     {
    //                         if (this.CustomHeaderSettings.NormalArrowUpHot != null)
    //                         {
    //                             return this.CustomHeaderSettings.NormalArrowUpHot;
    //                         }

    //                         return this.SystemSettings.Header.NormalArrowUpHot;
    //                     }
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the width of the expand/collapse arrow image 
    //     /// currently displayed in the title bar
    //     /// </summary>
    //     protected int ArrowImageWidth
    //     {
    //         get
    //         {
    //             if (this.ArrowImage == null)
    //             {
    //                 return 0;
    //             }

    //             return this.ArrowImage.Width;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the height of the expand/collapse arrow image 
    //     /// currently displayed in the title bar
    //     /// </summary>
    //     protected int ArrowImageHeight
    //     {
    //         get
    //         {
    //             if (this.ArrowImage == null)
    //             {
    //                 return 0;
    //             }

    //             return this.ArrowImage.Height;
    //         }
    //     }


    //     /// <summary>
    //     /// The background image used for the Title Bar.
    //     /// </summary>
    //     [Browsable(false)]
    //     public Image TitleBackImage
    //     {
    //         get
    //         {
    //             if (this.SpecialGroup)
    //             {
    //                 if (this.CustomHeaderSettings.SpecialBackImage != null)
    //                 {
    //                     return this.CustomHeaderSettings.SpecialBackImage;
    //                 }

    //                 return this.SystemSettings.Header.SpecialBackImage;
    //             }

    //             if (this.CustomHeaderSettings.NormalBackImage != null)
    //             {
    //                 return this.CustomHeaderSettings.NormalBackImage;
    //             }

    //             return this.SystemSettings.Header.NormalBackImage;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the height of the background image used for the Title Bar.
    //     /// </summary>
    //     protected int TitleBackImageHeight
    //     {
    //         get
    //         {
    //             return this.SystemSettings.Header.BackImageHeight;
    //         }
    //     }


    //     /// <summary>
    //     /// The image used on the left side of the Title Bar.
    //     /// </summary>
    //     [Category("Appearance"),
    //     DefaultValue(null),
    //     Description("The image used on the left side of the Title Bar.")]
    //     public Image TitleImage
    //     {
    //         get
    //         {
    //             return this.titleImage;
    //         }

    //         set
    //         {
    //             this.titleImage = value;

    //             this.DoLayout();

    //             this.InvalidateTitleBar();

    //             OnTitleImageChanged(new ExpandoEventArgs(this));
    //         }
    //     }


    //     /// <summary>
    //     /// The width of the image used on the left side of the Title Bar.
    //     /// </summary>
    //     protected int TitleImageWidth
    //     {
    //         get
    //         {
    //             if (this.TitleImage == null)
    //             {
    //                 return 0;
    //             }

    //             return this.TitleImage.Width;
    //         }
    //     }


    //     /// <summary>
    //     /// The height of the image used on the left side of the Title Bar.
    //     /// </summary>
    //     protected int TitleImageHeight
    //     {
    //         get
    //         {
    //             if (this.TitleImage == null)
    //             {
    //                 return 0;
    //             }

    //             return this.TitleImage.Height;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Image that is used as a watermark in the Expando's 
    //     /// client area
    //     /// </summary>
    //     [Category("Appearance"),
    //     DefaultValue(null),
    //     Description("The Image used as a watermark in the client area of the Expando.")]
    //     public Image Watermark
    //     {
    //         get
    //         {
    //             return this.watermark;
    //         }

    //         set
    //         {
    //             if (this.watermark != value)
    //             {
    //                 this.watermark = value;

    //                 this.Invalidate();

    //                 OnWatermarkChanged(new ExpandoEventArgs(this));
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// The background image used for the Expandos content area.
    //     /// </summary>
    //     [Browsable(false)]
    //     public Image BackImage
    //     {
    //         get
    //         {
    //             if (this.SpecialGroup)
    //             {
    //                 if (this.CustomSettings.SpecialBackImage != null)
    //                 {
    //                     return this.CustomSettings.SpecialBackImage;
    //                 }

    //                 return this.SystemSettings.Expando.SpecialBackImage;
    //             }

    //             if (this.CustomSettings.NormalBackImage != null)
    //             {
    //                 return this.CustomSettings.NormalBackImage;
    //             }

    //             return this.SystemSettings.Expando.NormalBackImage;
    //         }
    //     }

    //     #endregion

    //     #region Items

    //     /// <summary>
    //     /// An Expando.ItemCollection representing the collection of 
    //     /// Controls contained within the Expando
    //     /// </summary>
    //     [Category("Behavior"),
    //     DefaultValue(null),
    //     Description("The Controls contained in the Expando"),
    //     DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
    //     Editor(typeof(ItemCollectionEditor), typeof(UITypeEditor))]
    //     public Expando.ItemCollection Items
    //     {
    //         get
    //         {
    //             return this.itemList;
    //         }
    //     }


    //     /// <summary>
    //     /// A Control.ControlCollection representing the collection of 
    //     /// controls contained within the control
    //     /// </summary>
    //     [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //     public new Control.ControlCollection Controls
    //     {
    //         get
    //         {
    //             return base.Controls;
    //         }
    //     }

    //     #endregion

    //     #region Layout

    //     /// <summary>
    //     /// Gets or sets whether the Expando will automagically layout its items
    //     /// </summary>
    //     [Bindable(true),
    //     Category("Layout"),
    //     DefaultValue(false),
    //     Description("The AutoLayout property determines whether the Expando will automagically layout its items.")]
    //     public bool AutoLayout
    //     {
    //         get
    //         {
    //             return this.autoLayout;
    //         }

    //         set
    //         {
    //             this.autoLayout = value;

    //             if (this.autoLayout)
    //             {
    //                 this.DoLayout();
    //             }
    //         }
    //     }

    //     #endregion

    //     #region Padding

    //     /// <summary>
    //     /// Gets the amount of space between the border and items along 
    //     /// each side of the Expando.
    //     /// </summary>
    //     [Browsable(false)]
    //     public new Padding Padding
    //     {
    //         get
    //         {
    //             if (this.SpecialGroup)
    //             {
    //                 if (this.CustomSettings.SpecialPadding != Padding.Empty)
    //                 {
    //                     return this.CustomSettings.SpecialPadding;
    //                 }

    //                 return this.SystemSettings.Expando.SpecialPadding;
    //             }

    //             if (this.CustomSettings.NormalPadding != Padding.Empty)
    //             {
    //                 return this.CustomSettings.NormalPadding;
    //             }

    //             return this.SystemSettings.Expando.NormalPadding;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the amount of space between the border and items along 
    //     /// each side of the Title Bar.
    //     /// </summary>
    //     [Browsable(false)]
    //     public Padding TitlePadding
    //     {
    //         get
    //         {
    //             if (this.SpecialGroup)
    //             {
    //                 if (this.CustomHeaderSettings.SpecialPadding != Padding.Empty)
    //                 {
    //                     return this.CustomHeaderSettings.SpecialPadding;
    //                 }

    //                 return this.SystemSettings.Header.SpecialPadding;
    //             }

    //             if (this.CustomHeaderSettings.NormalPadding != Padding.Empty)
    //             {
    //                 return this.CustomHeaderSettings.NormalPadding;
    //             }

    //             return this.SystemSettings.Header.NormalPadding;
    //         }
    //     }

    //     #endregion

    //     #region Size

    //     /// <summary>
    //     /// Gets or sets the height and width of the control
    //     /// </summary>
    //     public new Size Size
    //     {
    //         get
    //         {
    //             return base.Size;
    //         }

    //         set
    //         {
    //             if (!this.Size.Equals(value))
    //             {
    //                 if (!this.Animating)
    //                 {
    //                     this.Width = value.Width;

    //                     if (!this.Initialising)
    //                     {
    //                         this.ExpandedHeight = value.Height;
    //                     }
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the Size property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the Size property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeSize()
    //     {
    //         return this.TaskPane != null;
    //     }


    //     /// <summary>
    //     /// Gets the height of the Expando in its expanded state
    //     /// </summary>
    //     [Bindable(true),
    //     Category("Layout"),
    //     DefaultValue(100),
    //     Description("The height of the Expando in its expanded state.")]
    //     public int ExpandedHeight
    //     {
    //         get
    //         {
    //             return this.expandedHeight;
    //         }

    //         set
    //         {
    //             this.expandedHeight = value;

    //             this.CalcAnimationHeights();

    //             if (!this.Collapsed && !this.Animating)
    //             {
    //                 this.Height = this.expandedHeight;

    //                 if (this.TaskPane != null)
    //                 {
    //                     this.TaskPane.DoLayout();
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the height of the header section of the Expando
    //     /// </summary>
    //     protected int HeaderHeight
    //     {
    //         get
    //         {
    //             return this.headerHeight;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the height of the titlebar
    //     /// </summary>
    //     protected int TitleBarHeight
    //     {
    //         get
    //         {
    //             return this.titleBarHeight;
    //         }
    //     }

    //     #endregion

    //     #region Special Groups

    //     /// <summary>
    //     /// Gets or sets whether the Expando should be rendered as a Special Group.
    //     /// </summary>
    //     [Bindable(true),
    //     Category("Appearance"),
    //     DefaultValue(false),
    //     Description("The SpecialGroup property determines whether the Expando will be rendered as a SpecialGroup.")]
    //     public bool SpecialGroup
    //     {
    //         get
    //         {
    //             return this.specialGroup;
    //         }

    //         set
    //         {
    //             this.specialGroup = value;

    //             this.DoLayout();

    //             if (this.specialGroup)
    //             {
    //                 if (this.CustomSettings.SpecialBackColor != Color.Empty)
    //                 {
    //                     this.BackColor = this.CustomSettings.SpecialBackColor;
    //                 }
    //                 else
    //                 {
    //                     this.BackColor = this.SystemSettings.Expando.SpecialBackColor;
    //                 }
    //             }
    //             else
    //             {
    //                 if (this.CustomSettings.NormalBackColor != Color.Empty)
    //                 {
    //                     this.BackColor = this.CustomSettings.NormalBackColor;
    //                 }
    //                 else
    //                 {
    //                     this.BackColor = this.SystemSettings.Expando.NormalBackColor;
    //                 }
    //             }

    //             this.Invalidate();

    //             OnSpecialGroupChanged(new ExpandoEventArgs(this));
    //         }
    //     }

    //     #endregion

    //     #region State

    //     /// <summary>
    //     /// Gets or sets whether the Expando is collapsed.
    //     /// </summary>
    //     [Bindable(true),
    //     Category("Appearance"),
    //     DefaultValue(false),
    //     Description("The Collapsed property determines whether the Expando is collapsed.")]
    //     public bool Collapsed
    //     {
    //         get
    //         {
    //             return this.collapsed;
    //         }

    //         set
    //         {
    //             if (this.collapsed != value)
    //             {
    //                 // if we're supposed to collapse, check if we can
    //                 if (value && !this.CanCollapse)
    //                 {
    //                     // looks like we can't so time to bail
    //                     return;
    //                 }

    //                 this.collapsed = value;

    //                 // only animate if we're allowed to, we're not in 
    //                 // design mode and we're not initialising
    //                 if (this.Animate && !this.DesignMode && !this.Initialising)
    //                 {
    //                     if (this.animationHelper != null)
    //                     {
    //                         this.animationHelper.Dispose();
    //                         this.animationHelper = null;
    //                     }

    //                     this.animationHelper = new AnimationHelper(this, AnimationHelper.FadeAnimation);

    //                     this.OnStateChanged(new ExpandoEventArgs(this));

    //                     this.animationHelper.StartAnimation();
    //                 }
    //                 else
    //                 {
    //                     if (this.collapsed)
    //                     {
    //                         this.Collapse();
    //                     }
    //                     else
    //                     {
    //                         this.Expand();
    //                     }

    //                     // don't need to raise OnStateChanged as 
    //                     // Collapse() or Expand() will do it for us
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets whether the title bar is in a highlighted state.
    //     /// </summary>
    //     [Browsable(false)]
    //     protected internal FocusStates FocusState
    //     {
    //         get
    //         {
    //             return this.focusState;
    //         }

    //         set
    //         {
    //             // fix: if the Expando isn't allowed to collapse, 
    //             //      don't update the titlebar highlight
    //             //      dani kenan (dani_k@netvision.net.il)
    //             //      11/10/2004
    //             //      v2.1
    //             if (!this.CanCollapse)
    //             {
    //                 value = FocusStates.None;
    //             }

    //             if (this.focusState != value)
    //             {
    //                 this.focusState = value;

    //                 this.InvalidateTitleBar();

    //                 if (this.focusState == FocusStates.Mouse)
    //                 {
    //                     this.Cursor = Cursors.Hand;
    //                 }
    //                 else
    //                 {
    //                     this.Cursor = Cursors.Default;
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets whether the Expando is able to collapse
    //     /// </summary>
    //     [Bindable(true),
    //     Category("Behavior"),
    //     DefaultValue(true),
    //     Description("The CanCollapse property determines whether the Expando is able to collapse.")]
    //     public bool CanCollapse
    //     {
    //         get
    //         {
    //             return this.canCollapse;
    //         }

    //         set
    //         {
    //             if (this.canCollapse != value)
    //             {
    //                 this.canCollapse = value;

    //                 // if the Expando is collapsed and it's not allowed 
    //                 // to collapse, then we had better expand it
    //                 if (!this.canCollapse && this.Collapsed)
    //                 {
    //                     this.Collapsed = false;
    //                 }

    //                 this.InvalidateTitleBar();
    //             }
    //         }
    //     }

    //     #endregion

    //     #region System Settings

    //     /// <summary>
    //     /// Gets or sets the system settings for the Expando
    //     /// </summary>
    //     [Browsable(false)]
    //     protected internal ExplorerBarInfo SystemSettings
    //     {
    //         get
    //         {
    //             return this.systemSettings;
    //         }

    //         set
    //         {
    //             // make sure we have a new value
    //             if (this.systemSettings != value)
    //             {
    //                 this.SuspendLayout();

    //                 // get rid of the old settings
    //                 if (this.systemSettings != null)
    //                 {
    //                     this.systemSettings.Dispose();
    //                     this.systemSettings = null;
    //                 }

    //                 // set the new settings
    //                 this.systemSettings = value;

    //                 this.titleBarHeight = this.systemSettings.Header.BackImageHeight;

    //                 // is there an image to display on the titlebar
    //                 if (this.titleImage != null)
    //                 {
    //                     // is the image bigger than the height of the titlebar
    //                     if (this.titleImage.Height > this.titleBarHeight)
    //                     {
    //                         this.headerHeight = this.titleImage.Height;
    //                     }
    //                     // is the image smaller than the height of the titlebar
    //                     else if (this.titleImage.Height < this.titleBarHeight)
    //                     {
    //                         this.headerHeight = this.titleBarHeight;
    //                     }
    //                     // is the image smaller than the current header height
    //                     else if (this.titleImage.Height < this.headerHeight)
    //                     {
    //                         this.headerHeight = this.titleImage.Height;
    //                     }
    //                 }
    //                 else
    //                 {
    //                     this.headerHeight = this.titleBarHeight;
    //                 }

    //                 if (this.SpecialGroup)
    //                 {
    //                     if (this.CustomSettings.SpecialBackColor != Color.Empty)
    //                     {
    //                         this.BackColor = this.CustomSettings.SpecialBackColor;
    //                     }
    //                     else
    //                     {
    //                         this.BackColor = this.SystemSettings.Expando.SpecialBackColor;
    //                     }
    //                 }
    //                 else
    //                 {
    //                     if (this.CustomSettings.NormalBackColor != Color.Empty)
    //                     {
    //                         this.BackColor = this.CustomSettings.NormalBackColor;
    //                     }
    //                     else
    //                     {
    //                         this.BackColor = this.SystemSettings.Expando.NormalBackColor;
    //                     }
    //                 }

    //                 // update the system settings for each TaskItem
    //                 for (int i = 0; i < this.itemList.Count; i++)
    //                 {
    //                     Control control = (Control)this.itemList[i];

    //                     if (control is TaskItem)
    //                     {
    //                         ((TaskItem)control).SystemSettings = this.systemSettings;
    //                     }
    //                 }

    //                 this.ResumeLayout(false);

    //                 // if our parent is not an TaskPane then re-layout the 
    //                 // Expando (don't need to do this if our parent is a 
    //                 // TaskPane as it will tell us when to do it)
    //                 if (this.TaskPane == null)
    //                 {
    //                     this.DoLayout();
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the custom settings for the Expando
    //     /// </summary>
    //     [Category("Appearance"),
    //     Description(""),
    //     DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
    //     TypeConverter(typeof(ExpandoInfoConverter))]
    //     public ExpandoInfo CustomSettings
    //     {
    //         get
    //         {
    //             return this.customSettings;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the custom header settings for the Expando
    //     /// </summary>
    //     [Category("Appearance"),
    //     Description(""),
    //     DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
    //     TypeConverter(typeof(HeaderInfoConverter))]
    //     public HeaderInfo CustomHeaderSettings
    //     {
    //         get
    //         {
    //             return this.customHeaderSettings;
    //         }
    //     }


    //     /// <summary>
    //     /// Resets the custom settings to their default values
    //     /// </summary>
    //     public void ResetCustomSettings()
    //     {
    //         this.CustomSettings.SetDefaultEmptyValues();
    //         this.CustomHeaderSettings.SetDefaultEmptyValues();

    //         this.FireCustomSettingsChanged(EventArgs.Empty);
    //     }

    //     #endregion

    //     #region TaskPane

    //     /// <summary>
    //     /// Gets or sets the TaskPane the Expando belongs to
    //     /// </summary>
    //     protected internal TaskPane TaskPane
    //     {
    //         get
    //         {
    //             return this.taskpane;
    //         }

    //         set
    //         {
    //             this.taskpane = value;

    //             if (value != null)
    //             {
    //                 this.SystemSettings = this.TaskPane.SystemSettings;
    //             }
    //         }
    //     }

    //     #endregion

    //     #region Text

    //     /// <summary>
    //     /// Gets or sets the text displayed on the titlebar
    //     /// </summary>
    //     public override string Text
    //     {
    //         get
    //         {
    //             return base.Text;
    //         }

    //         set
    //         {
    //             base.Text = value;

    //             this.InvalidateTitleBar();
    //         }
    //     }

    //     #endregion

    //     #region Visible

    //     /// <summary>
    //     /// Gets or sets a value indicating whether the Expando is displayed
    //     /// </summary>
    //     public new bool Visible
    //     {
    //         get
    //         {
    //             return base.Visible;
    //         }

    //         set
    //         {
    //             // fix: TaskPane will now perform a layout if the 
    //             //      Expando is to become invisible and the TaskPane 
    //             //      is currently invisible
    //             //      Brian Nottingham (nottinbe@slu.edu)
    //             //      22/12/2004
    //             //      v3.0
    //             //if (base.Visible != value)
    //             if (base.Visible != value || (!value && this.Parent != null && !this.Parent.Visible))
    //             {
    //                 base.Visible = value;

    //                 if (this.TaskPane != null)
    //                 {
    //                     this.TaskPane.DoLayout();
    //                 }
    //             }
    //         }
    //     }

    //     #endregion

    //     #endregion


    //     #region Events

    //     #region Controls

    //     /// <summary>
    //     /// Raises the ControlAdded event
    //     /// </summary>
    //     /// <param name="e">A ControlEventArgs that contains the event data</param>
    //     protected override void OnControlAdded(ControlEventArgs e)
    //     {
    //         // don't do anything if we are animating
    //         // (as we're probably the ones who added the control)
    //         if (this.Animating)
    //         {
    //             return;
    //         }

    //         base.OnControlAdded(e);

    //         // add the control to the ItemCollection if necessary
    //         if (!this.Items.Contains(e.Control))
    //         {
    //             this.Items.Add(e.Control);
    //         }
    //     }


    //     /// <summary>
    //     /// Raises the ControlRemoved event
    //     /// </summary>
    //     /// <param name="e">A ControlEventArgs that contains the event data</param>
    //     protected override void OnControlRemoved(ControlEventArgs e)
    //     {
    //         // don't do anything if we are animating 
    //         // (as we're probably the ones who removed the control)
    //         if (this.Animating)
    //         {
    //             return;
    //         }

    //         base.OnControlRemoved(e);

    //         // remove the control from the itemList
    //         if (this.Items.Contains(e.Control))
    //         {
    //             this.Items.Remove(e.Control);
    //         }

    //         // update the layout of the controls
    //         this.DoLayout();
    //     }

    //     #endregion

    //     #region Custom Settings

    //     /// <summary>
    //     /// Raises the CustomSettingsChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     internal void FireCustomSettingsChanged(EventArgs e)
    //     {
    //         this.titleBarHeight = this.TitleBackImageHeight;

    //         // is there an image to display on the titlebar
    //         if (this.titleImage != null)
    //         {
    //             // is the image bigger than the height of the titlebar
    //             if (this.titleImage.Height > this.titleBarHeight)
    //             {
    //                 this.headerHeight = this.titleImage.Height;
    //             }
    //             // is the image smaller than the height of the titlebar
    //             else if (this.titleImage.Height < this.titleBarHeight)
    //             {
    //                 this.headerHeight = this.titleBarHeight;
    //             }
    //             // is the image smaller than the current header height
    //             else if (this.titleImage.Height < this.headerHeight)
    //             {
    //                 this.headerHeight = this.titleImage.Height;
    //             }
    //         }
    //         else
    //         {
    //             this.headerHeight = this.titleBarHeight;
    //         }

    //         if (this.SpecialGroup)
    //         {
    //             if (this.CustomSettings.SpecialBackColor != Color.Empty)
    //             {
    //                 this.BackColor = this.CustomSettings.SpecialBackColor;
    //             }
    //             else
    //             {
    //                 this.BackColor = this.SystemSettings.Expando.SpecialBackColor;
    //             }
    //         }
    //         else
    //         {
    //             if (this.CustomSettings.NormalBackColor != Color.Empty)
    //             {
    //                 this.BackColor = this.CustomSettings.NormalBackColor;
    //             }
    //             else
    //             {
    //                 this.BackColor = this.SystemSettings.Expando.NormalBackColor;
    //             }
    //         }

    //         this.DoLayout();

    //         this.Invalidate(true);

    //         this.OnCustomSettingsChanged(e);
    //     }


    //     /// <summary>
    //     /// Raises the CustomSettingsChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected virtual void OnCustomSettingsChanged(EventArgs e)
    //     {
    //         if (CustomSettingsChanged != null)
    //         {
    //             CustomSettingsChanged(this, e);
    //         }
    //     }

    //     #endregion

    //     #region Expando

    //     /// <summary>
    //     /// Raises the StateChanged event
    //     /// </summary>
    //     /// <param name="e">An ExpandoStateChangedEventArgs that contains the event data</param>
    //     protected virtual void OnStateChanged(ExpandoEventArgs e)
    //     {
    //         if (StateChanged != null)
    //         {
    //             StateChanged(this, e);
    //         }
    //     }


    //     /// <summary>
    //     /// Raises the TitleImageChanged event
    //     /// </summary>
    //     /// <param name="e">An ExpandoEventArgs that contains the event data</param>
    //     protected virtual void OnTitleImageChanged(ExpandoEventArgs e)
    //     {
    //         if (TitleImageChanged != null)
    //         {
    //             TitleImageChanged(this, e);
    //         }
    //     }


    //     /// <summary>
    //     /// Raises the SpecialGroupChanged event
    //     /// </summary>
    //     /// <param name="e">An ExpandoEventArgs that contains the event data</param>
    //     protected virtual void OnSpecialGroupChanged(ExpandoEventArgs e)
    //     {
    //         if (SpecialGroupChanged != null)
    //         {
    //             SpecialGroupChanged(this, e);
    //         }
    //     }


    //     /// <summary>
    //     /// Raises the WatermarkChanged event
    //     /// </summary>
    //     /// <param name="e">An ExpandoEventArgs that contains the event data</param>
    //     protected virtual void OnWatermarkChanged(ExpandoEventArgs e)
    //     {
    //         if (WatermarkChanged != null)
    //         {
    //             WatermarkChanged(this, e);
    //         }
    //     }

    //     #endregion

    //     #region Focus

    //     /// <summary>
    //     /// Raises the GotFocus event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnGotFocus(EventArgs e)
    //     {
    //         base.OnGotFocus(e);

    //         this.InvalidateTitleBar();
    //     }


    //     /// <summary>
    //     /// Raises the LostFocus event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnLostFocus(EventArgs e)
    //     {
    //         base.OnLostFocus(e);

    //         this.InvalidateTitleBar();
    //     }

    //     #endregion

    //     #region Items

    //     /// <summary>
    //     /// Raises the ItemAdded event
    //     /// </summary>
    //     /// <param name="e">A ControlEventArgs that contains the event data</param>
    //     protected virtual void OnItemAdded(ControlEventArgs e)
    //     {
    //         // add the expando to the ControlCollection if it hasn't already
    //         if (!this.Controls.Contains(e.Control))
    //         {
    //             this.Controls.Add(e.Control);
    //         }

    //         // check if the control is a TaskItem
    //         if (e.Control is TaskItem)
    //         {
    //             TaskItem item = (TaskItem)e.Control;

    //             // set anchor styles
    //             item.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);

    //             // tell the TaskItem who's its daddy...
    //             item.Expando = this;
    //             item.SystemSettings = this.systemSettings;
    //         }

    //         // update the layout of the controls
    //         this.DoLayout();

    //         //
    //         if (ItemAdded != null)
    //         {
    //             ItemAdded(this, e);
    //         }
    //     }


    //     /// <summary>
    //     /// Raises the ItemRemoved event
    //     /// </summary>
    //     /// <param name="e">A ControlEventArgs that contains the event data</param>
    //     protected virtual void OnItemRemoved(ControlEventArgs e)
    //     {
    //         // remove the control from the ControlCollection if it hasn't already
    //         if (this.Controls.Contains(e.Control))
    //         {
    //             this.Controls.Remove(e.Control);
    //         }

    //         // update the layout of the controls
    //         this.DoLayout();

    //         //
    //         if (ItemRemoved != null)
    //         {
    //             ItemRemoved(this, e);
    //         }
    //     }

    //     #endregion

    //     #region Keys

    //     /// <summary>
    //     /// Raises the KeyUp event
    //     /// </summary>
    //     /// <param name="e">A KeyEventArgs that contains the event data</param>
    //     protected override void OnKeyUp(KeyEventArgs e)
    //     {
    //         // fix: should call OnKeyUp instead of OnKeyDown
    //         //      Simon Cropp (simonc@avanade.com)
    //         //      14/09/2005
    //         //      v3.3
    //         base.OnKeyUp(e);

    //         if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
    //         {
    //             this.Collapsed = !this.Collapsed;
    //         }
    //     }

    //     #endregion

    //     #region Location

    //     /// <summary>
    //     /// Raises the LocationChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnLocationChanged(EventArgs e)
    //     {
    //         base.OnLocationChanged(e);

    //         // sometimes the title image gets cropped (why???) if the 
    //         // expando is scrolled from off-screen to on-screen so we'll 
    //         // repaint the titlebar if the expando has a titlebar image 
    //         // and it is taller then the titlebar
    //         if (this.TitleImage != null && this.TitleImageHeight > this.TitleBarHeight)
    //         {
    //             this.InvalidateTitleBar();
    //         }
    //     }

    //     #endregion

    //     #region Mouse

    //     /// <summary>
    //     /// Raises the MouseUp event
    //     /// </summary>
    //     /// <param name="e">A MouseEventArgs that contains the event data</param>
    //     protected override void OnMouseUp(MouseEventArgs e)
    //     {
    //         base.OnMouseUp(e);

    //         // was it the left mouse button
    //         if (e.Button == MouseButtons.Left)
    //         {
    //             if (this.dragging)
    //             {
    //                 this.Cursor = Cursors.Default;

    //                 this.dragging = false;

    //                 this.TaskPane.DropExpando(this);
    //             }
    //             else
    //             {
    //                 // was it in the titlebar area
    //                 if (e.Y < this.HeaderHeight && e.Y > (this.HeaderHeight - this.TitleBarHeight))
    //                 {
    //                     // make sure that our taskPane (if we have one) is not animating
    //                     if (!this.Animating)
    //                     {
    //                         // collapse/expand the group
    //                         this.Collapsed = !this.Collapsed;
    //                     }

    //                     if (this.CanCollapse)
    //                     {
    //                         this.Select();
    //                     }
    //                 }
    //             }

    //             this.dragStart = Point.Empty;
    //         }
    //     }


    //     /// <summary>
    //     /// Raises the MouseDown event
    //     /// </summary>
    //     /// <param name="e">A MouseEventArgs that contains the event data</param>
    //     protected override void OnMouseDown(MouseEventArgs e)
    //     {
    //         base.OnMouseDown(e);

    //         // we're not doing anything here yet...
    //         // but we might later :)

    //         if (e.Button == MouseButtons.Left)
    //         {
    //             if (this.TaskPane != null && this.TaskPane.AllowExpandoDragging && !this.Animating)
    //             {
    //                 this.dragStart = this.PointToScreen(new Point(e.X, e.Y));
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Raises the MouseMove event
    //     /// </summary>
    //     /// <param name="e">A MouseEventArgs that contains the event data</param>
    //     protected override void OnMouseMove(MouseEventArgs e)
    //     {
    //         base.OnMouseMove(e);

    //         if (e.Button == MouseButtons.Left && this.dragStart != Point.Empty)
    //         {
    //             Point p = this.PointToScreen(new Point(e.X, e.Y));

    //             if (!this.dragging)
    //             {
    //                 if (Math.Abs(this.dragStart.X - p.X) > 8 || Math.Abs(this.dragStart.Y - p.Y) > 8)
    //                 {
    //                     this.dragging = true;

    //                     this.FocusState = FocusStates.None;
    //                 }
    //             }

    //             if (this.dragging)
    //             {
    //                 if (this.TaskPane.ClientRectangle.Contains(this.TaskPane.PointToClient(p)))
    //                 {
    //                     this.Cursor = Cursors.Default;
    //                 }
    //                 else
    //                 {
    //                     this.Cursor = Cursors.No;
    //                 }

    //                 this.TaskPane.UpdateDropPoint(p);

    //                 return;
    //             }
    //         }

    //         // check if the mouse is moving in the titlebar area
    //         if (e.Y < this.HeaderHeight && e.Y > (this.HeaderHeight - this.TitleBarHeight))
    //         {
    //             // change the cursor to a hand and highlight the titlebar
    //             this.FocusState = FocusStates.Mouse;
    //         }
    //         else
    //         {
    //             // reset the titlebar highlight and cursor if they haven't already
    //             this.FocusState = FocusStates.None;
    //         }
    //     }


    //     /// <summary>
    //     /// Raises the MouseLeave event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnMouseLeave(EventArgs e)
    //     {
    //         base.OnMouseLeave(e);

    //         // reset the titlebar highlight if it hasn't already
    //         this.FocusState = FocusStates.None;
    //     }

    //     #endregion

    //     #region Paint

    //     /// <summary>
    //     /// Raises the PaintBackground event
    //     /// </summary>
    //     /// <param name="e">A PaintEventArgs that contains the event data</param>
    //     protected override void OnPaintBackground(PaintEventArgs e)
    //     {
    //         // we may have a solid background color, but the titlebar back image
    //         // might have treansparent bits, so instead we draw our own 
    //         // transparent background (rather than getting windows to draw 
    //         // a solid background)
    //         this.PaintTransparentBackground(e.Graphics, e.ClipRectangle);

    //         // paint the titlebar background
    //         if (this.TitleBarRectangle.IntersectsWith(e.ClipRectangle))
    //         {
    //             this.OnPaintTitleBarBackground(e.Graphics);
    //         }

    //         // only paint the border and "display rect" if we are not collapsed
    //         if (this.Height != this.headerHeight)
    //         {
    //             if (this.PseudoClientRect.IntersectsWith(e.ClipRectangle))
    //             {
    //                 this.OnPaintBorder(e.Graphics);

    //                 this.OnPaintDisplayRect(e.Graphics);
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Raises the Paint event
    //     /// </summary>
    //     /// <param name="e">A PaintEventArgs that contains the event data</param>
    //     protected override void OnPaint(PaintEventArgs e)
    //     {
    //         // paint the titlebar
    //         if (this.TitleBarRectangle.IntersectsWith(e.ClipRectangle))
    //         {
    //             this.OnPaintTitleBar(e.Graphics);
    //         }
    //     }


    //     #region TitleBar

    //     /// <summary>
    //     /// Paints the title bar background
    //     /// </summary>
    //     /// <param name="g">The Graphics used to paint the titlebar</param>
    //     protected void OnPaintTitleBarBackground(Graphics g)
    //     {
    //         // fix: draw grayscale titlebar when disabled
    //         //      Brad Jones (brad@bradjones.com)
    //         //      20/08/2004
    //         //      v1.21

    //         int y = 0;

    //         // work out where the top of the titleBar actually is
    //         if (this.HeaderHeight > this.TitleBarHeight)
    //         {
    //             y = this.HeaderHeight - this.TitleBarHeight;
    //         }

    //         if (this.CustomHeaderSettings.TitleGradient && !this.AnyCustomTitleGradientsEmpty)
    //         {
    //             // gradient titlebar
    //             Color start = this.CustomHeaderSettings.NormalGradientStartColor;
    //             if (this.SpecialGroup)
    //             {
    //                 start = this.CustomHeaderSettings.SpecialGradientStartColor;
    //             }

    //             Color end = this.CustomHeaderSettings.NormalGradientEndColor;
    //             if (this.SpecialGroup)
    //             {
    //                 end = this.CustomHeaderSettings.SpecialGradientEndColor;
    //             }

    //             if (!this.Enabled)
    //             {
    //                 // simulate saturation of 0

    //                 start = Color.FromArgb((int)(start.GetBrightness() * 255),
    //                     (int)(start.GetBrightness() * 255),
    //                     (int)(start.GetBrightness() * 255));
    //                 end = Color.FromArgb((int)(end.GetBrightness() * 255),
    //                     (int)(end.GetBrightness() * 255),
    //                     (int)(end.GetBrightness() * 255));
    //             }

    //             using (LinearGradientBrush brush = new LinearGradientBrush(this.TitleBarRectangle, start, end, LinearGradientMode.Horizontal))
    //             {
    //                 // work out where the gradient starts
    //                 if (this.CustomHeaderSettings.GradientOffset > 0f && this.CustomHeaderSettings.GradientOffset < 1f)
    //                 {
    //                     ColorBlend colorBlend = new ColorBlend();
    //                     colorBlend.Colors = new Color[] { brush.LinearColors[0], brush.LinearColors[0], brush.LinearColors[1] };
    //                     colorBlend.Positions = new float[] { 0f, this.CustomHeaderSettings.GradientOffset, 1f };
    //                     brush.InterpolationColors = colorBlend;
    //                 }

    //                 // check if we need round corners
    //                 if (this.CustomHeaderSettings.TitleRadius > 0)
    //                 {
    //                     GraphicsPath path = new GraphicsPath();

    //                     // top
    //                     path.AddLine(this.TitleBarRectangle.Left + this.CustomHeaderSettings.TitleRadius,
    //                         this.TitleBarRectangle.Top,
    //                         this.TitleBarRectangle.Right - (this.CustomHeaderSettings.TitleRadius * 2) - 1,
    //                         this.TitleBarRectangle.Top);

    //                     // right corner
    //                     path.AddArc(this.TitleBarRectangle.Right - (this.CustomHeaderSettings.TitleRadius * 2) - 1,
    //                         this.TitleBarRectangle.Top,
    //                         this.CustomHeaderSettings.TitleRadius * 2,
    //                         this.CustomHeaderSettings.TitleRadius * 2,
    //                         270,
    //                         90);

    //                     // right
    //                     path.AddLine(this.TitleBarRectangle.Right,
    //                         this.TitleBarRectangle.Top + this.CustomHeaderSettings.TitleRadius,
    //                         this.TitleBarRectangle.Right,
    //                         this.TitleBarRectangle.Bottom);

    //                     // bottom
    //                     path.AddLine(this.TitleBarRectangle.Right,
    //                         this.TitleBarRectangle.Bottom,
    //                         this.TitleBarRectangle.Left - 1,
    //                         this.TitleBarRectangle.Bottom);

    //                     // left corner
    //                     path.AddArc(this.TitleBarRectangle.Left,
    //                         this.TitleBarRectangle.Top,
    //                         this.CustomHeaderSettings.TitleRadius * 2,
    //                         this.CustomHeaderSettings.TitleRadius * 2,
    //                         180,
    //                         90);

    //                     g.SmoothingMode = SmoothingMode.AntiAlias;

    //                     g.FillPath(brush, path);

    //                     g.SmoothingMode = SmoothingMode.Default;
    //                 }
    //                 else
    //                 {
    //                     g.FillRectangle(brush, this.TitleBarRectangle);
    //                 }
    //             }
    //         }
    //         else if (this.TitleBackImage != null)
    //         {
    //             // check if the system header background images have different 
    //             // RightToLeft values compared to what we do.  if they are different, 
    //             // then we had better mirror them
    //             if ((this.RightToLeft == RightToLeft.Yes && !this.SystemSettings.Header.RightToLeft) ||
    //                 (this.RightToLeft == RightToLeft.No && this.SystemSettings.Header.RightToLeft))
    //             {
    //                 if (this.SystemSettings.Header.NormalBackImage != null)
    //                 {
    //                     this.SystemSettings.Header.NormalBackImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
    //                 }

    //                 if (this.SystemSettings.Header.SpecialBackImage != null)
    //                 {
    //                     this.SystemSettings.Header.SpecialBackImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
    //                 }

    //                 this.SystemSettings.Header.RightToLeft = (this.RightToLeft == RightToLeft.Yes);
    //             }

    //             if (this.Enabled)
    //             {
    //                 if (this.SystemSettings.OfficialTheme)
    //                 {
    //                     // left edge
    //                     g.DrawImage(this.TitleBackImage,
    //                         new Rectangle(0, y, 5, this.TitleBarHeight),
    //                         new Rectangle(0, 0, 5, this.TitleBackImage.Height),
    //                         GraphicsUnit.Pixel);

    //                     // right edge
    //                     g.DrawImage(this.TitleBackImage,
    //                         new Rectangle(this.Width - 5, y, 5, this.TitleBarHeight),
    //                         new Rectangle(this.TitleBackImage.Width - 5, 0, 5, this.TitleBackImage.Height),
    //                         GraphicsUnit.Pixel);

    //                     // middle
    //                     g.DrawImage(this.TitleBackImage,
    //                         new Rectangle(5, y, this.Width - 10, this.TitleBarHeight),
    //                         new Rectangle(5, 0, this.TitleBackImage.Width - 10, this.TitleBackImage.Height),
    //                         GraphicsUnit.Pixel);
    //                 }
    //                 else
    //                 {
    //                     g.DrawImage(this.TitleBackImage, 0, y, this.Width, this.TitleBarHeight);
    //                 }
    //             }
    //             else
    //             {
    //                 if (this.SystemSettings.OfficialTheme)
    //                 {
    //                     using (Image image = new Bitmap(this.Width, this.TitleBarHeight))
    //                     {
    //                         using (Graphics g2 = Graphics.FromImage(image))
    //                         {
    //                             // left edge
    //                             g2.DrawImage(this.TitleBackImage,
    //                                 new Rectangle(0, y, 5, this.TitleBarHeight),
    //                                 new Rectangle(0, 0, 5, this.TitleBackImage.Height),
    //                                 GraphicsUnit.Pixel);


    //                             // right edge
    //                             g2.DrawImage(this.TitleBackImage,
    //                                 new Rectangle(this.Width - 5, y, 5, this.TitleBarHeight),
    //                                 new Rectangle(this.TitleBackImage.Width - 5, 0, 5, this.TitleBackImage.Height),
    //                                 GraphicsUnit.Pixel);

    //                             // middle
    //                             g2.DrawImage(this.TitleBackImage,
    //                                 new Rectangle(5, y, this.Width - 10, this.TitleBarHeight),
    //                                 new Rectangle(5, 0, this.TitleBackImage.Width - 10, this.TitleBackImage.Height),
    //                                 GraphicsUnit.Pixel);
    //                         }

    //                         ControlPaint.DrawImageDisabled(g, image, 0, y, this.TitleBackColor);
    //                     }
    //                 }
    //                 else
    //                 {
    //                     // first stretch the background image for ControlPaint.
    //                     using (Image image = new Bitmap(this.TitleBackImage, this.Width, this.TitleBarHeight))
    //                     {
    //                         ControlPaint.DrawImageDisabled(g, image, 0, y, this.TitleBackColor);
    //                     }
    //                 }
    //             }
    //         }
    //         else
    //         {
    //             // single color titlebar
    //             using (SolidBrush brush = new SolidBrush(this.TitleBackColor))
    //             {
    //                 g.FillRectangle(brush, 0, y, this.Width, this.TitleBarHeight);
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Paints the title bar
    //     /// </summary>
    //     /// <param name="g">The Graphics used to paint the titlebar</param>
    //     protected void OnPaintTitleBar(Graphics g)
    //     {
    //         int y = 0;

    //         // work out where the top of the titleBar actually is
    //         if (this.HeaderHeight > this.TitleBarHeight)
    //         {
    //             y = this.HeaderHeight - this.TitleBarHeight;
    //         }

    //         // draw the titlebar image if we have one
    //         if (this.TitleImage != null)
    //         {
    //             int x = 0;
    //             //int y = 0;

    //             if (this.RightToLeft == RightToLeft.Yes)
    //             {
    //                 x = this.Width - this.TitleImage.Width;
    //             }

    //             if (this.Enabled)
    //             {
    //                 g.DrawImage(this.TitleImage, x, 0);
    //             }
    //             else
    //             {
    //                 ControlPaint.DrawImageDisabled(g, TitleImage, x, 0, this.TitleBackColor);
    //             }
    //         }

    //         // get which collapse/expand arrow we should draw
    //         Image arrowImage = this.ArrowImage;

    //         // get the titlebar's border and padding
    //         Border border = this.TitleBorder;
    //         Padding padding = this.TitlePadding;

    //         // draw the arrow if we have one
    //         if (arrowImage != null)
    //         {
    //             // work out where to position the arrow
    //             int x = this.Width - arrowImage.Width - border.Right - padding.Right;
    //             y += border.Top + padding.Top;

    //             if (this.RightToLeft == RightToLeft.Yes)
    //             {
    //                 x = border.Right + padding.Right;
    //             }

    //             // draw it...
    //             if (this.Enabled)
    //             {
    //                 g.DrawImage(arrowImage, x, y);
    //             }
    //             else
    //             {
    //                 ControlPaint.DrawImageDisabled(g, arrowImage, x, y, this.TitleBackColor);
    //             }
    //         }

    //         // check if we have any text to draw in the titlebar
    //         if (this.Text.Length > 0)
    //         {
    //             // a rectangle that will contain our text
    //             Rectangle rect = new Rectangle();

    //             // work out the x coordinate
    //             if (this.TitleImage == null)
    //             {
    //                 rect.X = border.Left + padding.Left;
    //             }
    //             else
    //             {
    //                 rect.X = this.TitleImage.Width + border.Left;
    //             }

    //             // work out the y coordinate
    //             System.Drawing.ContentAlignment alignment = this.TitleAlignment;

    //             switch (alignment)
    //             {
    //                 case System.Drawing.ContentAlignment.MiddleLeft:
    //                 case System.Drawing.ContentAlignment.MiddleCenter:
    //                 case System.Drawing.ContentAlignment.MiddleRight:
    //                     rect.Y = ((this.HeaderHeight - this.TitleFont.Height) / 2) + ((this.HeaderHeight - this.TitleBarHeight) / 2) + border.Top + padding.Top;
    //                     break;

    //                 case System.Drawing.ContentAlignment.TopLeft:
    //                 case System.Drawing.ContentAlignment.TopCenter:
    //                 case System.Drawing.ContentAlignment.TopRight:
    //                     rect.Y = (this.HeaderHeight - this.TitleBarHeight) + border.Top + padding.Top;
    //                     break;

    //                 case System.Drawing.ContentAlignment.BottomLeft:
    //                 case System.Drawing.ContentAlignment.BottomCenter:
    //                 case System.Drawing.ContentAlignment.BottomRight:
    //                     rect.Y = this.HeaderHeight - this.TitleFont.Height;
    //                     break;
    //             }

    //             // the height of the rectangle
    //             rect.Height = this.TitleFont.Height;

    //             // make sure the text stays inside the header
    //             if (rect.Bottom > this.HeaderHeight)
    //             {
    //                 rect.Y -= rect.Bottom - this.HeaderHeight;
    //             }

    //             // work out how wide the rectangle should be
    //             if (arrowImage != null)
    //             {
    //                 rect.Width = this.Width - arrowImage.Width - border.Right - padding.Right - rect.X;
    //             }
    //             else
    //             {
    //                 rect.Width = this.Width - border.Right - padding.Right - rect.X;
    //             }

    //             // don't wrap the string, and use an ellipsis if
    //             // the string is too big to fit the rectangle
    //             StringFormat sf = new StringFormat();
    //             sf.FormatFlags = StringFormatFlags.NoWrap;
    //             sf.Trimming = StringTrimming.EllipsisCharacter;

    //             // should the string be aligned to the left/center/right
    //             switch (alignment)
    //             {
    //                 case System.Drawing.ContentAlignment.MiddleLeft:
    //                 case System.Drawing.ContentAlignment.TopLeft:
    //                 case System.Drawing.ContentAlignment.BottomLeft:
    //                     sf.Alignment = StringAlignment.Near;
    //                     break;

    //                 case System.Drawing.ContentAlignment.MiddleCenter:
    //                 case System.Drawing.ContentAlignment.TopCenter:
    //                 case System.Drawing.ContentAlignment.BottomCenter:
    //                     sf.Alignment = StringAlignment.Center;
    //                     break;

    //                 case System.Drawing.ContentAlignment.MiddleRight:
    //                 case System.Drawing.ContentAlignment.TopRight:
    //                 case System.Drawing.ContentAlignment.BottomRight:
    //                     sf.Alignment = StringAlignment.Far;
    //                     break;
    //             }

    //             if (this.RightToLeft == RightToLeft.Yes)
    //             {
    //                 sf.FormatFlags |= StringFormatFlags.DirectionRightToLeft;

    //                 if (this.TitleImage == null)
    //                 {
    //                     rect.X = this.Width - rect.Width - border.Left - padding.Left;
    //                 }
    //                 else
    //                 {
    //                     rect.X = this.Width - rect.Width - this.TitleImage.Width - border.Left;
    //                 }
    //             }

    //             // draw the text
    //             using (SolidBrush brush = new SolidBrush(this.TitleColor))
    //             {
    //                 //g.DrawString(this.Text, this.TitleFont, brush, rect, sf);
    //                 if (this.Enabled)
    //                 {
    //                     g.DrawString(this.Text, this.TitleFont, brush, rect, sf);
    //                 }
    //                 else
    //                 {
    //                     ControlPaint.DrawStringDisabled(g, this.Text, this.TitleFont, SystemColors.ControlLightLight, rect, sf);
    //                 }
    //             }
    //         }

    //         // check if windows will let us show a focus rectangle 
    //         // if we have focus
    //         if (this.Focused && base.ShowFocusCues)
    //         {
    //             if (this.ShowFocusCues)
    //             {
    //                 // for some reason, if CanCollapse is false the focus rectangle 
    //                 // will be drawn 2 pixels higher than it should be, so move it down
    //                 if (!this.CanCollapse)
    //                 {
    //                     y += 2;
    //                 }

    //                 ControlPaint.DrawFocusRectangle(g, new Rectangle(2, y, this.Width - 4, this.TitleBarHeight - 3));
    //             }
    //         }
    //     }

    //     #endregion

    //     #region DisplayRect

    //     /// <summary>
    //     /// Paints the "Display Rectangle".  This is the dockable
    //     /// area of the control (ie non-titlebar/border area).  This is
    //     /// also the same as the PseudoClientRect.
    //     /// </summary>
    //     /// <param name="g">The Graphics used to paint the DisplayRectangle</param>
    //     protected void OnPaintDisplayRect(Graphics g)
    //     {
    //         // are we animating a fade
    //         if (this.animatingFade && this.AnimationImage != null)
    //         {
    //             // calculate the transparency value for the animation image
    //             float alpha = (((float)(this.Height - this.HeaderHeight)) / ((float)(this.ExpandedHeight - this.HeaderHeight)));

    //             float[][] ptsArray = {new float[] {1, 0, 0, 0, 0},
    //                                      new float[] {0, 1, 0, 0, 0},
    //                                      new float[] {0, 0, 1, 0, 0},
    //                                      new float[] {0, 0, 0, alpha, 0},
    //                                      new float[] {0, 0, 0, 0, 1}};

    //             ColorMatrix colorMatrix = new ColorMatrix(ptsArray);
    //             ImageAttributes imageAttributes = new ImageAttributes();
    //             imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

    //             // work out how far up the animation image we need to start
    //             int y = this.AnimationImage.Height - this.PseudoClientHeight - this.Border.Bottom;

    //             // draw the image
    //             g.DrawImage(this.AnimationImage,
    //                 new Rectangle(0, this.HeaderHeight, this.Width, this.Height - this.HeaderHeight),
    //                 0,
    //                 y,
    //                 this.AnimationImage.Width,
    //                 this.AnimationImage.Height - y,
    //                 GraphicsUnit.Pixel,
    //                 imageAttributes);
    //         }
    //         // are we animating a slide
    //         else if (this.animatingSlide)
    //         {
    //             // check if we have a background image
    //             if (this.BackImage != null)
    //             {
    //                 // tile the backImage
    //                 using (TextureBrush brush = new TextureBrush(this.BackImage, WrapMode.Tile))
    //                 {
    //                     g.FillRectangle(brush, this.DisplayRectangle);
    //                 }
    //             }
    //             else
    //             {
    //                 // just paint the area with a solid brush
    //                 using (SolidBrush brush = new SolidBrush(this.BackColor))
    //                 {
    //                     g.FillRectangle(brush,
    //                         this.Border.Left,
    //                         this.HeaderHeight + this.Border.Top,
    //                         this.Width - this.Border.Left - this.Border.Right,
    //                         this.Height - this.HeaderHeight - this.Border.Top - this.Border.Bottom);
    //                 }
    //             }
    //         }
    //         else
    //         {
    //             // check if we have a background image
    //             if (this.BackImage != null)
    //             {
    //                 // tile the backImage
    //                 using (TextureBrush brush = new TextureBrush(this.BackImage, WrapMode.Tile))
    //                 {
    //                     g.FillRectangle(brush, this.DisplayRectangle);
    //                 }
    //             }
    //             else
    //             {
    //                 // just paint the area with a solid brush
    //                 using (SolidBrush brush = new SolidBrush(this.BackColor))
    //                 {
    //                     g.FillRectangle(brush, this.DisplayRectangle);
    //                 }
    //             }

    //             if (this.Watermark != null)
    //             {
    //                 // work out a rough location of where the watermark should go
    //                 Rectangle rect = new Rectangle(0, 0, this.Watermark.Width, this.Watermark.Height);
    //                 rect.X = this.PseudoClientRect.Right - this.Watermark.Width;
    //                 rect.Y = this.DisplayRectangle.Bottom - this.Watermark.Height;

    //                 // shrink the destination rect if necesary so that we
    //                 // can see all of the image

    //                 if (rect.X < 0)
    //                 {
    //                     rect.X = 0;
    //                 }

    //                 if (rect.Width > this.ClientRectangle.Width)
    //                 {
    //                     rect.Width = this.ClientRectangle.Width;
    //                 }

    //                 if (rect.Y < this.DisplayRectangle.Top)
    //                 {
    //                     rect.Y = this.DisplayRectangle.Top;
    //                 }

    //                 if (rect.Height > this.DisplayRectangle.Height)
    //                 {
    //                     rect.Height = this.DisplayRectangle.Height;
    //                 }

    //                 // draw the watermark
    //                 g.DrawImage(this.Watermark, rect);
    //             }
    //         }
    //     }

    //     #endregion

    //     #region Borders

    //     /// <summary>
    //     /// Paints the borders
    //     /// </summary>
    //     /// <param name="g">The Graphics used to paint the border</param>
    //     protected void OnPaintBorder(Graphics g)
    //     {
    //         // get the current border and border colors
    //         Border border = this.Border;
    //         Color c = this.BorderColor;

    //         // check if we are currently animating a fade
    //         if (this.animatingFade)
    //         {
    //             // calculate the alpha value for the color
    //             int alpha = (int)(255 * (((float)(this.Height - this.HeaderHeight)) / ((float)(this.ExpandedHeight - this.HeaderHeight))));

    //             // make sure it doesn't go past 0 or 255
    //             if (alpha < 0)
    //             {
    //                 alpha = 0;
    //             }
    //             else if (alpha > 255)
    //             {
    //                 alpha = 255;
    //             }

    //             // update the color with the alpha value
    //             c = Color.FromArgb(alpha, c.R, c.G, c.B);
    //         }

    //         // draw the borders
    //         using (SolidBrush brush = new SolidBrush(c))
    //         {
    //             g.FillRectangle(brush, border.Left, this.HeaderHeight, this.Width - border.Left - border.Right, border.Top); // top border
    //             g.FillRectangle(brush, 0, this.HeaderHeight, border.Left, this.Height - this.HeaderHeight); // left border
    //             g.FillRectangle(brush, this.Width - border.Right, this.HeaderHeight, border.Right, this.Height - this.HeaderHeight); // right border
    //             g.FillRectangle(brush, border.Left, this.Height - border.Bottom, this.Width - border.Left - border.Right, border.Bottom); // bottom border
    //         }
    //     }

    //     #endregion

    //     #region TransparentBackground

    //     /// <summary>
    //     /// Simulates a transparent background by getting the Expandos parent 
    //     /// to paint its background and foreground into the specified Graphics 
    //     /// at the specified location
    //     /// </summary>
    //     /// <param name="g">The Graphics used to paint the background</param>
    //     /// <param name="clipRect">The Rectangle that represents the rectangle 
    //     /// in which to paint</param>
    //     protected void PaintTransparentBackground(Graphics g, Rectangle clipRect)
    //     {
    //         // check if we have a parent
    //         if (this.Parent != null)
    //         {
    //             // convert the clipRects coordinates from ours to our parents
    //             clipRect.Offset(this.Location);

    //             PaintEventArgs e = new PaintEventArgs(g, clipRect);

    //             // save the graphics state so that if anything goes wrong 
    //             // we're not fubar
    //             GraphicsState state = g.Save();

    //             try
    //             {
    //                 // move the graphics object so that we are drawing in 
    //                 // the correct place
    //                 g.TranslateTransform((float)-this.Location.X, (float)-this.Location.Y);

    //                 // draw the parents background and foreground
    //                 this.InvokePaintBackground(this.Parent, e);
    //                 this.InvokePaint(this.Parent, e);

    //                 return;
    //             }
    //             finally
    //             {
    //                 // reset everything back to where they were before
    //                 g.Restore(state);
    //                 clipRect.Offset(-this.Location.X, -this.Location.Y);
    //             }
    //         }

    //         // we don't have a parent, so fill the rect with
    //         // the default control color
    //         g.FillRectangle(SystemBrushes.Control, clipRect);
    //     }

    //     #endregion

    //     #endregion

    //     #region Parent

    //     /// <summary>
    //     /// Raises the ParentChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnParentChanged(EventArgs e)
    //     {
    //         if (this.Parent == null)
    //         {
    //             this.TaskPane = null;
    //         }
    //         else if (this.Parent is TaskPane)
    //         {
    //             this.TaskPane = (TaskPane)this.Parent;

    //             this.Location = this.TaskPane.CalcExpandoLocation(this);
    //         }

    //         base.OnParentChanged(e);
    //     }

    //     #endregion

    //     #region Size

    //     /// <summary>
    //     /// Raises the SizeChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnSizeChanged(EventArgs e)
    //     {
    //         base.OnSizeChanged(e);

    //         // if we are currently animating and the width of the
    //         // group has changed (eg. due to a scrollbar on the 
    //         // TaskPane appearing/disappearing), get a new image 
    //         // to use for the animation. (if we were to continue to 
    //         // use the old image it would be shrunk or stretched making 
    //         // the animation look wierd)
    //         if (this.Animating && this.Width != this.oldWidth)
    //         {
    //             // if the width or height of the group is zero it probably 
    //             // means that our parent form has been minimized so we should 
    //             // immediately stop animating
    //             if (this.Width == 0)
    //             {
    //                 this.animationHelper.StopAnimation();
    //             }
    //             else
    //             {
    //                 this.oldWidth = this.Width;

    //                 if (this.AnimationImage != null)
    //                 {
    //                     // get the new animationImage
    //                     this.animationImage = this.GetFadeAnimationImage();
    //                 }
    //             }
    //         }
    //         // check if the width has changed.  if it has re-layout
    //         // the group so that the TaskItems can resize themselves
    //         // if neccessary
    //         else if (this.Width != this.oldWidth)
    //         {
    //             this.oldWidth = this.Width;

    //             this.DoLayout();
    //         }
    //     }

    //     #endregion

    //     #endregion


    //     #region ItemCollection

    //     /// <summary>
    //     /// Represents a collection of Control objects
    //     /// </summary>
    //     public class ItemCollection : CollectionBase
    //     {
    //         #region Class Data

    //         /// <summary>
    //         /// The Expando that owns this ControlCollection
    //         /// </summary>
    //         private Expando owner;

    //         #endregion


    //         #region Constructor

    //         /// <summary>
    //         /// Initializes a new instance of the Expando.ItemCollection class
    //         /// </summary>
    //         /// <param name="owner">An Expando representing the expando that owns 
    //         /// the Control collection</param>
    //         public ItemCollection(Expando owner) : base()
    //         {
    //             if (owner == null)
    //             {
    //                 throw new ArgumentNullException("owner");
    //             }

    //             this.owner = owner;
    //         }

    //         #endregion


    //         #region Methods

    //         /// <summary>
    //         /// Adds the specified control to the control collection
    //         /// </summary>
    //         /// <param name="value">The Control to add to the control collection</param>
    //         public void Add(Control value)
    //         {
    //             if (value == null)
    //             {
    //                 throw new ArgumentNullException("value");
    //             }

    //             this.List.Add(value);
    //             this.owner.Controls.Add(value);

    //             this.owner.OnItemAdded(new ControlEventArgs(value));
    //         }


    //         /// <summary>
    //         /// Adds an array of control objects to the collection
    //         /// </summary>
    //         /// <param name="controls">An array of Control objects to add 
    //         /// to the collection</param>
    //         public void AddRange(Control[] controls)
    //         {
    //             if (controls == null)
    //             {
    //                 throw new ArgumentNullException("controls");
    //             }

    //             for (int i = 0; i < controls.Length; i++)
    //             {
    //                 this.Add(controls[i]);
    //             }
    //         }


    //         /// <summary>
    //         /// Removes all controls from the collection
    //         /// </summary>
    //         public new void Clear()
    //         {
    //             while (this.Count > 0)
    //             {
    //                 this.RemoveAt(0);
    //             }
    //         }


    //         /// <summary>
    //         /// Determines whether the specified control is a member of the 
    //         /// collection
    //         /// </summary>
    //         /// <param name="control">The Control to locate in the collection</param>
    //         /// <returns>true if the Control is a member of the collection; 
    //         /// otherwise, false</returns>
    //         public bool Contains(Control control)
    //         {
    //             if (control == null)
    //             {
    //                 throw new ArgumentNullException("control");
    //             }

    //             return (this.IndexOf(control) != -1);
    //         }


    //         /// <summary>
    //         /// Retrieves the index of the specified control in the control 
    //         /// collection
    //         /// </summary>
    //         /// <param name="control">The Control to locate in the collection</param>
    //         /// <returns>A zero-based index value that represents the position 
    //         /// of the specified Control in the Expando.ItemCollection</returns>
    //         public int IndexOf(Control control)
    //         {
    //             if (control == null)
    //             {
    //                 throw new ArgumentNullException("control");
    //             }

    //             for (int i = 0; i < this.Count; i++)
    //             {
    //                 if (this[i] == control)
    //                 {
    //                     return i;
    //                 }
    //             }

    //             return -1;
    //         }


    //         /// <summary>
    //         /// Removes the specified control from the control collection
    //         /// </summary>
    //         /// <param name="value">The Control to remove from the 
    //         /// Expando.ItemCollection</param>
    //         public void Remove(Control value)
    //         {
    //             if (value == null)
    //             {
    //                 throw new ArgumentNullException("value");
    //             }

    //             this.List.Remove(value);
    //             this.owner.Controls.Remove(value);

    //             this.owner.OnItemRemoved(new ControlEventArgs(value));
    //         }


    //         /// <summary>
    //         /// Removes a control from the control collection at the 
    //         /// specified indexed location
    //         /// </summary>
    //         /// <param name="index">The index value of the Control to 
    //         /// remove</param>
    //         public new void RemoveAt(int index)
    //         {
    //             this.Remove(this[index]);
    //         }


    //         /// <summary>
    //         /// Moves the specified control to the specified indexed location 
    //         /// in the control collection
    //         /// </summary>
    //         /// <param name="value">The control to be moved</param>
    //         /// <param name="index">The indexed location in the control collection 
    //         /// that the specified control will be moved to</param>
    //         public void Move(Control value, int index)
    //         {
    //             if (value == null)
    //             {
    //                 throw new ArgumentNullException("value");
    //             }

    //             // make sure the index is within range
    //             if (index < 0)
    //             {
    //                 index = 0;
    //             }
    //             else if (index > this.Count)
    //             {
    //                 index = this.Count;
    //             }

    //             // don't go any further if the expando is already 
    //             // in the desired position or we don't contain it
    //             if (!this.Contains(value) || this.IndexOf(value) == index)
    //             {
    //                 return;
    //             }

    //             this.List.Remove(value);

    //             // if the index we're supposed to move the expando to
    //             // is now greater to the number of expandos contained, 
    //             // add it to the end of the list, otherwise insert it at 
    //             // the specified index
    //             if (index > this.Count)
    //             {
    //                 this.List.Add(value);
    //             }
    //             else
    //             {
    //                 this.List.Insert(index, value);
    //             }

    //             // re-layout the controls
    //             this.owner.MatchControlCollToItemColl();
    //         }


    //         /// <summary>
    //         /// Moves the specified control to the top of the control collection
    //         /// </summary>
    //         /// <param name="value">The control to be moved</param>
    //         public void MoveToTop(Control value)
    //         {
    //             this.Move(value, 0);
    //         }


    //         /// <summary>
    //         /// Moves the specified control to the bottom of the control collection
    //         /// </summary>
    //         /// <param name="value">The control to be moved</param>
    //         public void MoveToBottom(Control value)
    //         {
    //             this.Move(value, this.Count);
    //         }

    //         #endregion


    //         #region Properties

    //         /// <summary>
    //         /// The Control located at the specified index location within 
    //         /// the control collection
    //         /// </summary>
    //         /// <param name="index">The index of the control to retrieve 
    //         /// from the control collection</param>
    //         public virtual Control this[int index]
    //         {
    //             get
    //             {
    //                 return this.List[index] as Control;
    //             }
    //         }

    //         #endregion
    //     }

    //     #endregion


    //     #region ItemCollectionEditor

    //     /// <summary>
    //     /// A custom CollectionEditor for editing ItemCollections
    //     /// </summary>
    //     internal class ItemCollectionEditor : CollectionEditor
    //     {
    //         /// <summary>
    //         /// Initializes a new instance of the CollectionEditor class 
    //         /// using the specified collection type
    //         /// </summary>
    //         /// <param name="type"></param>
    //         public ItemCollectionEditor(Type type) : base(type)
    //         {

    //         }


    //         /// <summary>
    //         /// Edits the value of the specified object using the specified 
    //         /// service provider and context
    //         /// </summary>
    //         /// <param name="context">An ITypeDescriptorContext that can be 
    //         /// used to gain additional context information</param>
    //         /// <param name="isp">A service provider object through which 
    //         /// editing services can be obtained</param>
    //         /// <param name="value">The object to edit the value of</param>
    //         /// <returns>The new value of the object. If the value of the 
    //         /// object has not changed, this should return the same object 
    //         /// it was passed</returns>
    //         public override object EditValue(ITypeDescriptorContext context, IServiceProvider isp, object value)
    //         {
    //             Expando originalControl = (Expando)context.Instance;

    //             object returnObject = base.EditValue(context, isp, value);

    //             originalControl.UpdateItems();

    //             return returnObject;
    //         }


    //         /// <summary>
    //         /// Gets the data types that this collection editor can contain
    //         /// </summary>
    //         /// <returns>An array of data types that this collection can contain</returns>
    //         protected override Type[] CreateNewItemTypes()
    //         {
    //             return new Type[] {typeof(TaskItem),
    //                                   typeof(Button),
    //                                   typeof(CheckBox),
    //                                   typeof(CheckedListBox),
    //                                   typeof(ComboBox),
    //                                   typeof(DateTimePicker),
    //                                   typeof(Label),
    //                                   typeof(LinkLabel),
    //                                   typeof(ListBox),
    //                                   typeof(ListView),
    //                                   typeof(Panel),
    //                                   typeof(ProgressBar),
    //                                   typeof(RadioButton),
    //                                   typeof(TabControl),
    //                                   typeof(TextBox),
    //                                   typeof(TreeView)};
    //         }


    //         /// <summary>
    //         /// Creates a new instance of the specified collection item type
    //         /// </summary>
    //         /// <param name="itemType">The type of item to create</param>
    //         /// <returns>A new instance of the specified object</returns>
    //         protected override object CreateInstance(Type itemType)
    //         {
    //             // if the item we're supposed to create is one of the 
    //             // types that doesn't correctly draw themed borders 
    //             // during animation, substitute it for our customised 
    //             // versions which will.

    //             if (itemType == typeof(TextBox))
    //             {
    //                 itemType = typeof(XPTextBox);
    //             }
    //             else if (itemType == typeof(CheckedListBox))
    //             {
    //                 itemType = typeof(XPCheckedListBox);
    //             }
    //             else if (itemType == typeof(ListBox))
    //             {
    //                 itemType = typeof(XPListBox);
    //             }
    //             else if (itemType == typeof(ListView))
    //             {
    //                 itemType = typeof(XPListView);
    //             }
    //             else if (itemType == typeof(TreeView))
    //             {
    //                 itemType = typeof(XPTreeView);
    //             }
    //             else if (itemType == typeof(DateTimePicker))
    //             {
    //                 itemType = typeof(XPDateTimePicker);
    //             }

    //             return base.CreateInstance(itemType);
    //         }
    //     }

    //     #endregion


    //     #region AnimationPanel

    //     /// <summary>
    //     /// An extremely stripped down version of an Expando that an 
    //     /// Expando can use instead of itself to get an image of its 
    //     /// "client area" and child controls
    //     /// </summary>
    //     internal class AnimationPanel : Panel
    //     {
    //         #region Class Data

    //         /// <summary>
    //         /// The height of the header section 
    //         /// (includes titlebar and title image)
    //         /// </summary>
    //         protected int headerHeight;

    //         /// <summary>
    //         /// The border around the "client area"
    //         /// </summary>
    //         protected Border border;

    //         /// <summary>
    //         /// The background image displayed in the control
    //         /// </summary>
    //         protected Image backImage;

    //         #endregion


    //         #region Constructor

    //         /// <summary>
    //         /// Initializes a new instance of the AnimationPanel class with default settings
    //         /// </summary>
    //         public AnimationPanel() : base()
    //         {
    //             this.headerHeight = 0;
    //             this.border = new Border();
    //             this.backImage = null;
    //         }

    //         #endregion


    //         #region Properties

    //         /// <summary>
    //         /// Overrides AutoScroll to disable scrolling
    //         /// </summary>
    //         public new bool AutoScroll
    //         {
    //             get
    //             {
    //                 return false;
    //             }

    //             set
    //             {

    //             }
    //         }


    //         /// <summary>
    //         /// Gets or sets the height of the header section of the Expando
    //         /// </summary>
    //         public int HeaderHeight
    //         {
    //             get
    //             {
    //                 return this.headerHeight;
    //             }

    //             set
    //             {
    //                 this.headerHeight = value;
    //             }
    //         }


    //         /// <summary>
    //         /// Gets or sets the border around the "client area"
    //         /// </summary>
    //         public Border Border
    //         {
    //             get
    //             {
    //                 return this.border;
    //             }

    //             set
    //             {
    //                 this.border = value;
    //             }
    //         }


    //         /// <summary>
    //         /// Gets or sets the background image displayed in the control
    //         /// </summary>
    //         public Image BackImage
    //         {
    //             get
    //             {
    //                 return this.backImage;
    //             }

    //             set
    //             {
    //                 this.backImage = value;
    //             }
    //         }


    //         /// <summary>
    //         /// Overrides DisplayRectangle so that docked controls
    //         /// don't cover the titlebar or borders
    //         /// </summary>
    //         public override Rectangle DisplayRectangle
    //         {
    //             get
    //             {
    //                 return new Rectangle(this.Border.Left,
    //                     this.HeaderHeight + this.Border.Top,
    //                     this.Width - this.Border.Left - this.Border.Right,
    //                     this.Height - this.HeaderHeight - this.Border.Top - this.Border.Bottom);
    //             }
    //         }

    //         #endregion


    //         #region Events

    //         /// <summary>
    //         /// Raises the Paint event
    //         /// </summary>
    //         /// <param name="e">A PaintEventArgs that contains the event data</param>
    //         protected override void OnPaint(PaintEventArgs e)
    //         {
    //             base.OnPaint(e);

    //             if (this.BackImage != null)
    //             {
    //                 e.Graphics.DrawImageUnscaled(this.BackImage, 0, 0);
    //             }
    //         }

    //         #endregion
    //     }

    //     #endregion


    //     #region AnimationHelper

    //     /// <summary>
    //     /// A class that helps Expandos animate
    //     /// </summary>
    //     public class AnimationHelper : IDisposable
    //     {
    //         #region Class Data

    //         /// <summary>
    //         /// The number of frames in an animation
    //         /// </summary>
    //         public static readonly int NumAnimationFrames = 23;

    //         /// <summary>
    //         /// Specifes that a fade animation is to be performed
    //         /// </summary>
    //         public static int FadeAnimation = 1;

    //         /// <summary>
    //         /// Specifes that a slide animation is to be performed
    //         /// </summary>
    //         public static int SlideAnimation = 2;

    //         /// <summary>
    //         /// The type of animation to perform
    //         /// </summary>
    //         private int animationType;

    //         /// <summary>
    //         /// The Expando to animate
    //         /// </summary>
    //         private Expando expando;

    //         /// <summary>
    //         /// The current frame in animation
    //         /// </summary>
    //         private int animationStepNum;

    //         /// <summary>
    //         /// The number of frames in the animation
    //         /// </summary>
    //         private int numAnimationSteps;

    //         /// <summary>
    //         /// The amount of time each frame is shown (in milliseconds)
    //         /// </summary>
    //         private int animationFrameInterval;

    //         /// <summary>
    //         /// Specifies whether an animation is being performed
    //         /// </summary>
    //         private bool animating;

    //         /// <summary>
    //         /// A timer that notifies the helper when the next frame is due
    //         /// </summary>
    //         private System.Windows.Forms.Timer animationTimer;

    //         #endregion


    //         #region Constructor

    //         /// <summary>
    //         /// Initializes a new instance of the AnimationHelper class with the specified settings
    //         /// </summary>
    //         /// <param name="expando">The Expando to be animated</param>
    //         /// <param name="animationType">The type of animation to perform</param>
    //         public AnimationHelper(Expando expando, int animationType)
    //         {
    //             this.expando = expando;
    //             this.animationType = animationType;

    //             this.animating = false;

    //             this.numAnimationSteps = NumAnimationFrames;
    //             this.animationFrameInterval = 10;

    //             // I know that this isn't the best way to do this, but I 
    //             // haven't quite worked out how to do it with threads so 
    //             // this will have to do for the moment
    //             this.animationTimer = new System.Windows.Forms.Timer();
    //             this.animationTimer.Tick += new EventHandler(this.animationTimer_Tick);
    //             this.animationTimer.Interval = this.animationFrameInterval;
    //         }

    //         #endregion


    //         #region Methods

    //         /// <summary>
    //         /// Releases all resources used by the AnimationHelper
    //         /// </summary>
    //         public void Dispose()
    //         {
    //             if (this.animationTimer != null)
    //             {
    //                 this.animationTimer.Stop();
    //                 this.animationTimer.Dispose();
    //                 this.animationTimer = null;
    //             }

    //             this.expando = null;
    //         }


    //         /// <summary>
    //         /// Starts the Expando collapse/expand animation
    //         /// </summary>
    //         public void StartAnimation()
    //         {
    //             // don't bother going any further if we are already animating
    //             if (this.Animating)
    //             {
    //                 return;
    //             }

    //             this.animationStepNum = 0;

    //             // tell the expando to get ready to animate
    //             if (this.AnimationType == FadeAnimation)
    //             {
    //                 this.expando.StartFadeAnimation();
    //             }
    //             else
    //             {
    //                 this.expando.StartSlideAnimation();
    //             }

    //             // start the animation timer
    //             this.animationTimer.Start();
    //         }


    //         /// <summary>
    //         /// Updates the animation for the Expando
    //         /// </summary>
    //         protected void PerformAnimation()
    //         {
    //             // if we have more animation steps to perform
    //             if (this.animationStepNum < this.numAnimationSteps)
    //             {
    //                 // update the animation step number
    //                 this.animationStepNum++;

    //                 // tell the animating expando to update the animation
    //                 if (this.AnimationType == FadeAnimation)
    //                 {
    //                     this.expando.UpdateFadeAnimation(this.animationStepNum, this.numAnimationSteps);
    //                 }
    //                 else
    //                 {
    //                     this.expando.UpdateSlideAnimation(this.animationStepNum, this.numAnimationSteps);
    //                 }
    //             }
    //             else
    //             {
    //                 this.StopAnimation();
    //             }
    //         }


    //         /// <summary>
    //         /// Stops the Expando collapse/expand animation
    //         /// </summary>
    //         public void StopAnimation()
    //         {
    //             // stop the animation
    //             this.animationTimer.Stop();
    //             this.animationTimer.Dispose();

    //             if (this.AnimationType == FadeAnimation)
    //             {
    //                 this.expando.StopFadeAnimation();
    //             }
    //             else
    //             {
    //                 this.expando.StopSlideAnimation();
    //             }
    //         }

    //         #endregion


    //         #region Properties

    //         /// <summary>
    //         /// Gets the Expando that is te be animated
    //         /// </summary>
    //         public Expando Expando
    //         {
    //             get
    //             {
    //                 return this.expando;
    //             }
    //         }


    //         /// <summary>
    //         /// Gets or sets the number of steps that are needed for the Expando 
    //         /// to get from fully expanded to fully collapsed, or visa versa
    //         /// </summary>
    //         public int NumAnimationSteps
    //         {
    //             get
    //             {
    //                 return this.numAnimationSteps;
    //             }

    //             set
    //             {
    //                 if (value < 0)
    //                 {
    //                     throw new ArgumentOutOfRangeException("value", "NumAnimationSteps must be at least 0");
    //                 }

    //                 // only change this if we are not currently animating
    //                 // (if we are animating, changing this could cause things
    //                 // to screw up big time)
    //                 if (!this.animating)
    //                 {
    //                     this.numAnimationSteps = value;
    //                 }
    //             }
    //         }


    //         /// <summary>
    //         /// Gets or sets the number of milliseconds that each "frame" 
    //         /// of the animation stays on the screen
    //         /// </summary>
    //         public int AnimationFrameInterval
    //         {
    //             get
    //             {
    //                 return this.animationFrameInterval;
    //             }

    //             set
    //             {
    //                 this.animationFrameInterval = value;
    //             }
    //         }


    //         /// <summary>
    //         /// Gets whether the Expando is currently animating
    //         /// </summary>
    //         public bool Animating
    //         {
    //             get
    //             {
    //                 return this.animating;
    //             }
    //         }


    //         /// <summary>
    //         /// Gets the type of animation to perform
    //         /// </summary>
    //         public int AnimationType
    //         {
    //             get
    //             {
    //                 return this.animationType;
    //             }
    //         }

    //         #endregion


    //         #region Events

    //         /// <summary>
    //         /// Event handler for the animation timer tick event
    //         /// </summary>
    //         /// <param name="sender">The object that fired the event</param>
    //         /// <param name="e">An EventArgs that contains the event data</param>
    //         private void animationTimer_Tick(object sender, EventArgs e)
    //         {
    //             // do the next bit of the aniation
    //             this.PerformAnimation();
    //         }

    //         #endregion
    //     }

    //     #endregion


    //     #region ExpandoSurrogate

    //     /// <summary>
    //     /// A class that is serialized instead of an Expando (as 
    //     /// Expandos contain objects that cause serialization problems)
    //     /// </summary>
    //     [Serializable()]
    //     public class ExpandoSurrogate : ISerializable
    //     {
    //         #region Class Data

    //         /// <summary>
    //         /// See Expando.Name.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public string Name;

    //         /// <summary>
    //         /// See Expando.Text.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public string Text;

    //         /// <summary>
    //         /// See Expando.Size.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public Size Size;

    //         /// <summary>
    //         /// See Expando.Location.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public Point Location;

    //         /// <summary>
    //         /// See Expando.BackColor.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public string BackColor;

    //         /// <summary>
    //         /// See Expando.ExpandedHeight.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public int ExpandedHeight;

    //         /// <summary>
    //         /// See Expando.CustomSettings.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public ExpandoInfo.ExpandoInfoSurrogate CustomSettings;

    //         /// <summary>
    //         /// See Expando.CustomHeaderSettings.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public HeaderInfo.HeaderInfoSurrogate CustomHeaderSettings;

    //         /// <summary>
    //         /// See Expando.Animate.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool Animate;

    //         /// <summary>
    //         /// See Expando.ShowFocusCues.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool ShowFocusCues;

    //         /// <summary>
    //         /// See Expando.Collapsed.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool Collapsed;

    //         /// <summary>
    //         /// See Expando.CanCollapse.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool CanCollapse;

    //         /// <summary>
    //         /// See Expando.SpecialGroup.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool SpecialGroup;

    //         /// <summary>
    //         /// See Expando.TitleImage.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         //[XmlElement("TitleImage", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] TitleImage;

    //         /// <summary>
    //         /// See Expando.Watermark.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         //[XmlElement("Watermark", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] Watermark;

    //         /// <summary>
    //         /// See Expando.Enabled.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool Enabled;

    //         /// <summary>
    //         /// See Expando.Visible.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool Visible;

    //         /// <summary>
    //         /// See Expando.AutoLayout.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool AutoLayout;

    //         /// <summary>
    //         /// See Expando.Anchor.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public AnchorStyles Anchor;

    //         /// <summary>
    //         /// See Expando.Dock.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public DockStyle Dock;

    //         /// <summary>
    //         /// See Font.Name.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public string FontName;

    //         /// <summary>
    //         /// See Font.Size.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public float FontSize;

    //         /// <summary>
    //         /// See Font.Style.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public FontStyle FontDecoration;

    //         /// <summary>
    //         /// See Expando.Items.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         //[XmlArray("Items"), XmlArrayItem("TaskItemSurrogate", typeof(TaskItem.TaskItemSurrogate))]
    //         public ArrayList Items;

    //         /// <summary>
    //         /// See Control.Tag.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("Tag", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] Tag;

    //         /// <summary>
    //         /// Version number of the surrogate.  This member is not intended 
    //         /// to be used directly from your code.
    //         /// </summary>
    //         public int Version = 3300;

    //         #endregion


    //         #region Constructor

    //         /// <summary>
    //         /// Initializes a new instance of the ExpandoSurrogate class with default settings
    //         /// </summary>
    //         public ExpandoSurrogate()
    //         {
    //             this.Name = null;
    //             this.Text = null;
    //             this.Size = Size.Empty;
    //             this.Location = Point.Empty;

    //             this.BackColor = ThemeManager.ConvertColorToString(SystemColors.Control);
    //             this.ExpandedHeight = -1;

    //             this.CustomSettings = null;
    //             this.CustomHeaderSettings = null;

    //             this.Animate = false;
    //             this.ShowFocusCues = false;
    //             this.Collapsed = false;
    //             this.CanCollapse = true;
    //             this.SpecialGroup = false;

    //             this.TitleImage = new byte[0];
    //             this.Watermark = new byte[0];

    //             this.Enabled = true;
    //             this.Visible = true;
    //             this.AutoLayout = false;

    //             this.Anchor = AnchorStyles.None;
    //             this.Dock = DockStyle.None;

    //             this.FontName = "Tahoma";
    //             this.FontSize = 8.25f;
    //             this.FontDecoration = FontStyle.Regular;

    //             this.Items = new ArrayList();

    //             this.Tag = new byte[0];
    //         }

    //         #endregion


    //         #region Methods

    //         /// <summary>
    //         /// Populates the ExpandoSurrogate with data that is to be 
    //         /// serialized from the specified Expando
    //         /// </summary>
    //         /// <param name="expando">The Expando that contains the data 
    //         /// to be serialized</param>
    //         public void Load(Expando expando)
    //         {
    //             this.Name = expando.Name;
    //             this.Text = expando.Text;
    //             this.Size = expando.Size;
    //             this.Location = expando.Location;

    //             this.BackColor = ThemeManager.ConvertColorToString(expando.BackColor);
    //             this.ExpandedHeight = expando.ExpandedHeight;

    //             this.CustomSettings = new ExpandoInfo.ExpandoInfoSurrogate();
    //             this.CustomSettings.Load(expando.CustomSettings);
    //             this.CustomHeaderSettings = new HeaderInfo.HeaderInfoSurrogate();
    //             this.CustomHeaderSettings.Load(expando.CustomHeaderSettings);

    //             this.Animate = expando.Animate;
    //             this.ShowFocusCues = expando.ShowFocusCues;
    //             this.Collapsed = expando.Collapsed;
    //             this.CanCollapse = expando.CanCollapse;
    //             this.SpecialGroup = expando.SpecialGroup;

    //             this.TitleImage = ThemeManager.ConvertImageToByteArray(expando.TitleImage);
    //             this.Watermark = ThemeManager.ConvertImageToByteArray(expando.Watermark);

    //             this.Enabled = expando.Enabled;
    //             this.Visible = expando.Visible;
    //             this.AutoLayout = expando.AutoLayout;

    //             this.Anchor = expando.Anchor;
    //             this.Dock = expando.Dock;

    //             this.FontName = expando.Font.FontFamily.Name;
    //             this.FontSize = expando.Font.SizeInPoints;
    //             this.FontDecoration = expando.Font.Style;

    //             this.Tag = ThemeManager.ConvertObjectToByteArray(expando.Tag);

    //             for (int i = 0; i < expando.Items.Count; i++)
    //             {
    //                 if (expando.Items[i] is TaskItem)
    //                 {
    //                     TaskItem.TaskItemSurrogate tis = new TaskItem.TaskItemSurrogate();

    //                     tis.Load((TaskItem)expando.Items[i]);

    //                     this.Items.Add(tis);
    //                 }
    //             }
    //         }


    //         /// <summary>
    //         /// Returns an Expando that contains the deserialized ExpandoSurrogate data
    //         /// </summary>
    //         /// <returns>An Expando that contains the deserialized ExpandoSurrogate data</returns>
    //         public Expando Save()
    //         {
    //             Expando expando = new Expando();
    //             ((ISupportInitialize)expando).BeginInit();
    //             expando.SuspendLayout();

    //             expando.Name = this.Name;
    //             expando.Text = this.Text;
    //             expando.Size = this.Size;
    //             expando.Location = this.Location;

    //             expando.BackColor = ThemeManager.ConvertStringToColor(this.BackColor);
    //             expando.ExpandedHeight = this.ExpandedHeight;

    //             expando.customSettings = this.CustomSettings.Save();
    //             expando.customSettings.Expando = expando;
    //             expando.customHeaderSettings = this.CustomHeaderSettings.Save();
    //             expando.customHeaderSettings.Expando = expando;

    //             expando.TitleImage = ThemeManager.ConvertByteArrayToImage(this.TitleImage);
    //             expando.Watermark = ThemeManager.ConvertByteArrayToImage(this.Watermark);

    //             expando.Animate = this.Animate;
    //             expando.ShowFocusCues = this.ShowFocusCues;
    //             expando.Collapsed = this.Collapsed;
    //             expando.CanCollapse = this.CanCollapse;
    //             expando.SpecialGroup = this.SpecialGroup;

    //             expando.Enabled = this.Enabled;
    //             expando.Visible = this.Visible;
    //             expando.AutoLayout = this.AutoLayout;

    //             expando.Anchor = this.Anchor;
    //             expando.Dock = this.Dock;

    //             expando.Font = new Font(this.FontName, this.FontSize, this.FontDecoration);

    //             expando.Tag = ThemeManager.ConvertByteArrayToObject(this.Tag);

    //             foreach (Object o in this.Items)
    //             {
    //                 TaskItem ti = ((TaskItem.TaskItemSurrogate)o).Save();

    //                 expando.Items.Add(ti);
    //             }

    //             ((ISupportInitialize)expando).EndInit();
    //             expando.ResumeLayout(false);

    //             return expando;
    //         }


    //         /// <summary>
    //         /// Populates a SerializationInfo with the data needed to serialize the ExpandoSurrogate
    //         /// </summary>
    //         /// <param name="info">The SerializationInfo to populate with data</param>
    //         /// <param name="context">The destination for this serialization</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         public void GetObjectData(SerializationInfo info, StreamingContext context)
    //         {
    //             info.AddValue("Version", this.Version);

    //             info.AddValue("Name", this.Name);
    //             info.AddValue("Text", this.Text);
    //             info.AddValue("Size", this.Size);
    //             info.AddValue("Location", this.Location);

    //             info.AddValue("BackColor", this.BackColor);
    //             info.AddValue("ExpandedHeight", this.ExpandedHeight);

    //             info.AddValue("CustomSettings", this.CustomSettings);
    //             info.AddValue("CustomHeaderSettings", this.CustomHeaderSettings);

    //             info.AddValue("Animate", this.Animate);
    //             info.AddValue("ShowFocusCues", this.ShowFocusCues);
    //             info.AddValue("Collapsed", this.Collapsed);
    //             info.AddValue("CanCollapse", this.CanCollapse);
    //             info.AddValue("SpecialGroup", this.SpecialGroup);

    //             info.AddValue("TitleImage", this.TitleImage);
    //             info.AddValue("Watermark", this.Watermark);

    //             info.AddValue("Enabled", this.Enabled);
    //             info.AddValue("Visible", this.Visible);
    //             info.AddValue("AutoLayout", this.AutoLayout);

    //             info.AddValue("Anchor", this.Anchor);
    //             info.AddValue("Dock", this.Dock);

    //             info.AddValue("FontName", this.FontName);
    //             info.AddValue("FontSize", this.FontSize);
    //             info.AddValue("FontDecoration", this.FontDecoration);

    //             info.AddValue("Tag", this.Tag);

    //             info.AddValue("Items", this.Items);
    //         }


    //         /// <summary>
    //         /// Initializes a new instance of the ExpandoSurrogate class using the information 
    //         /// in the SerializationInfo
    //         /// </summary>
    //         /// <param name="info">The information to populate the ExpandoSurrogate</param>
    //         /// <param name="context">The source from which the ExpandoSurrogate is deserialized</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         protected ExpandoSurrogate(SerializationInfo info, StreamingContext context) : base()
    //         {
    //             int version = info.GetInt32("Version");

    //             this.Name = info.GetString("Name");
    //             this.Text = info.GetString("Text");
    //             this.Size = (Size)info.GetValue("Size", typeof(Size));
    //             this.Location = (Point)info.GetValue("Location", typeof(Point));

    //             this.BackColor = info.GetString("BackColor");
    //             this.ExpandedHeight = info.GetInt32("ExpandedHeight");

    //             this.CustomSettings = (ExpandoInfo.ExpandoInfoSurrogate)info.GetValue("CustomSettings", typeof(ExpandoInfo.ExpandoInfoSurrogate));
    //             this.CustomHeaderSettings = (HeaderInfo.HeaderInfoSurrogate)info.GetValue("CustomHeaderSettings", typeof(HeaderInfo.HeaderInfoSurrogate));

    //             this.Animate = info.GetBoolean("Animate");
    //             this.ShowFocusCues = info.GetBoolean("ShowFocusCues");
    //             this.Collapsed = info.GetBoolean("Collapsed");
    //             this.CanCollapse = info.GetBoolean("CanCollapse");
    //             this.SpecialGroup = info.GetBoolean("SpecialGroup");

    //             this.TitleImage = (byte[])info.GetValue("TitleImage", typeof(byte[]));
    //             this.Watermark = (byte[])info.GetValue("Watermark", typeof(byte[]));

    //             this.Enabled = info.GetBoolean("Enabled");
    //             this.Visible = info.GetBoolean("Visible");
    //             this.AutoLayout = info.GetBoolean("AutoLayout");

    //             this.Anchor = (AnchorStyles)info.GetValue("Anchor", typeof(AnchorStyles));
    //             this.Dock = (DockStyle)info.GetValue("Dock", typeof(DockStyle));

    //             this.FontName = info.GetString("FontName");
    //             this.FontSize = info.GetSingle("FontSize");
    //             this.FontDecoration = (FontStyle)info.GetValue("FontDecoration", typeof(FontStyle));

    //             this.Tag = (byte[])info.GetValue("Tag", typeof(byte[]));

    //             this.Items = (ArrayList)info.GetValue("Items", typeof(ArrayList));
    //         }

    //         #endregion
    //     }

    //     #endregion
    // }

    // #endregion



    // #region ExpandoEventArgs

    // /// <summary>
    // /// Provides data for the StateChanged, ExpandoAdded and 
    // /// ExpandoRemoved events
    // /// </summary>
    // public class ExpandoEventArgs : EventArgs
    // {
    //     #region Class Data

    //     /// <summary>
    //     /// The Expando that generated the event
    //     /// </summary>
    //     private Expando expando;

    //     #endregion


    //     #region Constructor

    //     /// <summary>
    //     /// Initializes a new instance of the ExpandoEventArgs class with default settings
    //     /// </summary>
    //     public ExpandoEventArgs()
    //     {
    //         expando = null;
    //     }


    //     /// <summary>
    //     /// Initializes a new instance of the ExpandoEventArgs class with specific Expando
    //     /// </summary>
    //     /// <param name="expando">The Expando that generated the event</param>
    //     public ExpandoEventArgs(Expando expando)
    //     {
    //         this.expando = expando;
    //     }

    //     #endregion


    //     #region Properties

    //     /// <summary>
    //     /// Gets the Expando that generated the event
    //     /// </summary>
    //     public Expando Expando
    //     {
    //         get
    //         {
    //             return this.expando;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets whether the Expando is collapsed
    //     /// </summary>
    //     public bool Collapsed
    //     {
    //         get
    //         {
    //             return this.expando.Collapsed;
    //         }
    //     }

    //     #endregion
    // }

    // #endregion



    // #region ExpandoConverter

    // /// <summary>
    // /// A custom TypeConverter used to help convert Expandos from 
    // /// one Type to another
    // /// </summary>
    // internal class ExpandoConverter : TypeConverter
    // {
    //     /// <summary>
    //     /// Returns whether this converter can convert the object to the 
    //     /// specified type, using the specified context
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a 
    //     /// format context</param>
    //     /// <param name="destinationType">A Type that represents the type 
    //     /// you want to convert to</param>
    //     /// <returns>true if this converter can perform the conversion; o
    //     /// therwise, false</returns>
    //     public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    //     {
    //         if (destinationType == typeof(InstanceDescriptor))
    //         {
    //             return true;
    //         }

    //         return base.CanConvertTo(context, destinationType);
    //     }


    //     /// <summary>
    //     /// Converts the given value object to the specified type, using 
    //     /// the specified context and culture information
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides 
    //     /// a format context</param>
    //     /// <param name="culture">A CultureInfo object. If a null reference 
    //     /// is passed, the current culture is assumed</param>
    //     /// <param name="value">The Object to convert</param>
    //     /// <param name="destinationType">The Type to convert the value 
    //     /// parameter to</param>
    //     /// <returns>An Object that represents the converted value</returns>
    //     public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    //     {
    //         if (destinationType == typeof(InstanceDescriptor) && value is Expando)
    //         {
    //             ConstructorInfo ci = typeof(Expando).GetConstructor(new Type[] { });

    //             if (ci != null)
    //             {
    //                 return new InstanceDescriptor(ci, null, false);
    //             }
    //         }

    //         return base.ConvertTo(context, culture, value, destinationType);
    //     }
    // }

    // #endregion



    // #region ExpandoDesigner

    // /// <summary>
    // /// A custom designer used by Expandos to remove unwanted 
    // /// properties from the Property window in the designer
    // /// </summary>
    // internal class ExpandoDesigner : ParentControlDesigner
    // {
    //     /// <summary>
    //     /// Initializes a new instance of the ExpandoDesigner class
    //     /// </summary>
    //     public ExpandoDesigner() : base()
    //     {

    //     }


    //     /// <summary>
    //     /// Adjusts the set of properties the component exposes through 
    //     /// a TypeDescriptor
    //     /// </summary>
    //     /// <param name="properties">An IDictionary containing the properties 
    //     /// for the class of the component</param>
    //     protected override void PreFilterProperties(IDictionary properties)
    //     {
    //         base.PreFilterProperties(properties);

    //         properties.Remove("BackColor");
    //         properties.Remove("BackgroundImage");
    //         properties.Remove("BorderStyle");
    //         properties.Remove("Cursor");
    //         properties.Remove("BackgroundImage");
    //     }
    // }

    // #endregion



    // #region FocusStates

    // /// <summary>
    // /// Defines the state of an Expandos title bar
    // /// </summary>
    // public enum FocusStates
    // {
    //     /// <summary>
    //     /// Normal state
    //     /// </summary>
    //     None = 0,

    //     /// <summary>
    //     /// The mouse is over the title bar
    //     /// </summary>
    //     Mouse = 1
    // }

    // #endregion

    // #endregion

    // #region Explorer Bar Info

    // #region ExplorerBarInfo Class

    // /// <summary>
    // /// A class that contains system defined settings for an XPExplorerBar
    // /// </summary>
    // public class ExplorerBarInfo : IDisposable
    // {
    //     #region Class Data

    //     /// <summary>
    //     /// System defined settings for a TaskPane
    //     /// </summary>
    //     private TaskPaneInfo taskPane;

    //     /// <summary>
    //     /// System defined settings for a TaskItem
    //     /// </summary>
    //     private TaskItemInfo taskItem;

    //     /// <summary>
    //     /// System defined settings for an Expando
    //     /// </summary>
    //     private ExpandoInfo expando;

    //     /// <summary>
    //     /// System defined settings for an Expando's header
    //     /// </summary>
    //     private HeaderInfo header;

    //     /// <summary>
    //     /// Specifies whether the ExplorerBarInfo represents an 
    //     /// official Windows XP theme
    //     /// </summary>
    //     private bool officialTheme;

    //     /// <summary>
    //     /// Specifies whether the ExplorerBarInfo represents the 
    //     /// Windows XP "classic" theme
    //     /// </summary>
    //     private bool classicTheme;

    //     /// <summary>
    //     /// A string that contains the full path to the ShellStyle.dll 
    //     /// that the ExplorerBarInfo was loaded from
    //     /// </summary>
    //     private string shellStylePath;

    //     #endregion


    //     #region Constructor

    //     /// <summary>
    //     /// Initializes a new instance of the ExplorerBarInfo class with 
    //     /// default settings
    //     /// </summary>
    //     public ExplorerBarInfo()
    //     {
    //         this.taskPane = new TaskPaneInfo();
    //         this.taskItem = new TaskItemInfo();
    //         this.expando = new ExpandoInfo();
    //         this.header = new HeaderInfo();

    //         this.officialTheme = false;
    //         this.classicTheme = false;
    //         this.shellStylePath = null;
    //     }

    //     #endregion


    //     #region Methods

    //     /// <summary>
    //     /// Sets the arrow images for use when theming is not supported
    //     /// </summary>
    //     public void SetUnthemedArrowImages()
    //     {
    //         this.Header.SetUnthemedArrowImages();
    //     }


    //     /// <summary>
    //     /// Force use of default values
    //     /// </summary>
    //     public void UseClassicTheme()
    //     {
    //         this.classicTheme = true;

    //         this.TaskPane.SetDefaultValues();
    //         this.Expando.SetDefaultValues();
    //         this.Header.SetDefaultValues();
    //         this.TaskItem.SetDefaultValues();

    //         this.SetUnthemedArrowImages();
    //     }


    //     /// <summary>
    //     /// Releases all resources used by the ExplorerBarInfo
    //     /// </summary>
    //     public void Dispose()
    //     {
    //         this.taskPane.Dispose();
    //         this.header.Dispose();
    //         this.expando.Dispose();
    //     }

    //     #endregion


    //     #region Properties

    //     /// <summary>
    //     /// Gets the ExplorerPane settings
    //     /// </summary>
    //     public TaskPaneInfo TaskPane
    //     {
    //         get
    //         {
    //             return this.taskPane;
    //         }

    //         set
    //         {
    //             this.taskPane = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the TaskLink settings
    //     /// </summary>
    //     public TaskItemInfo TaskItem
    //     {
    //         get
    //         {
    //             return this.taskItem;
    //         }

    //         set
    //         {
    //             this.taskItem = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Group settings
    //     /// </summary>
    //     public ExpandoInfo Expando
    //     {
    //         get
    //         {
    //             return this.expando;
    //         }

    //         set
    //         {
    //             this.expando = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Header settings
    //     /// </summary>
    //     public HeaderInfo Header
    //     {
    //         get
    //         {
    //             return this.header;
    //         }

    //         set
    //         {
    //             this.header = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets whether the ExplorerBarInfo contains settings for 
    //     /// an official Windows XP Visual Style
    //     /// </summary>
    //     public bool OfficialTheme
    //     {
    //         get
    //         {
    //             return this.officialTheme;
    //         }

    //         /*set
    //{
    //	this.officialTheme = value;
    //}*/
    //     }


    //     /// <summary>
    //     /// Sets whether the ExplorerBarInfo contains settings for 
    //     /// an official Windows XP Visual Style
    //     /// </summary>
    //     /// <param name="officialTheme">true if the ExplorerBarInfo 
    //     /// contains settings for an official Windows XP Visual Style, 
    //     /// otherwise false</param>
    //     internal void SetOfficialTheme(bool officialTheme)
    //     {
    //         this.officialTheme = officialTheme;
    //     }


    //     /// <summary>
    //     /// Gets whether the ExplorerBarInfo contains settings for 
    //     /// the Windows XP "classic" Visual Style
    //     /// </summary>
    //     public bool ClassicTheme
    //     {
    //         get
    //         {
    //             return this.classicTheme;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets a string that specifies the full path to the 
    //     /// ShellStyle.dll that the ExplorerBarInfo was loaded from
    //     /// </summary>
    //     public string ShellStylePath
    //     {
    //         get
    //         {
    //             return this.shellStylePath;
    //         }

    //         set
    //         {
    //             this.shellStylePath = value;
    //         }
    //     }

    //     #endregion


    //     #region ExplorerBarInfoSurrogate

    //     /// <summary>
    //     /// A class that is serialized instead of an ExplorerBarInfo (as 
    //     /// ExplorerBarInfos contain objects that cause serialization problems)
    //     /// </summary>
    //     [Serializable()]
    //     public class ExplorerBarInfoSurrogate : ISerializable
    //     {
    //         #region Class Data

    //         /// <summary>
    //         /// This member is not intended to be used directly from your code.
    //         /// </summary>
    //         public TaskPaneInfo.TaskPaneInfoSurrogate TaskPaneInfoSurrogate;

    //         /// <summary>
    //         /// This member is not intended to be used directly from your code.
    //         /// </summary>
    //         public TaskItemInfo.TaskItemInfoSurrogate TaskItemInfoSurrogate;

    //         /// <summary>
    //         /// This member is not intended to be used directly from your code.
    //         /// </summary>
    //         public ExpandoInfo.ExpandoInfoSurrogate ExpandoInfoSurrogate;

    //         /// <summary>
    //         /// This member is not intended to be used directly from your code.
    //         /// </summary>
    //         public HeaderInfo.HeaderInfoSurrogate HeaderInfoSurrogate;

    //         /// <summary>
    //         /// Version number of the surrogate.  This member is not intended 
    //         /// to be used directly from your code.
    //         /// </summary>
    //         public int Version = 3300;

    //         #endregion


    //         #region Constructor

    //         /// <summary>
    //         /// Initializes a new instance of the ExplorerBarInfoSurrogate class with default settings
    //         /// </summary>
    //         public ExplorerBarInfoSurrogate()
    //         {
    //             this.TaskPaneInfoSurrogate = null;
    //             this.TaskItemInfoSurrogate = null;
    //             this.ExpandoInfoSurrogate = null;
    //             this.HeaderInfoSurrogate = null;
    //         }

    //         #endregion


    //         #region Methods

    //         /// <summary>
    //         /// Populates the ExplorerBarInfoSurrogate with data that is to be 
    //         /// serialized from the specified ExplorerBarInfo
    //         /// </summary>
    //         /// <param name="explorerBarInfo">The ExplorerBarInfo that contains the data 
    //         /// to be serialized</param>
    //         public void Load(ExplorerBarInfo explorerBarInfo)
    //         {
    //             this.TaskPaneInfoSurrogate = new TaskPaneInfo.TaskPaneInfoSurrogate();
    //             this.TaskPaneInfoSurrogate.Load(explorerBarInfo.TaskPane);

    //             this.TaskItemInfoSurrogate = new TaskItemInfo.TaskItemInfoSurrogate();
    //             this.TaskItemInfoSurrogate.Load(explorerBarInfo.TaskItem);

    //             this.ExpandoInfoSurrogate = new ExpandoInfo.ExpandoInfoSurrogate();
    //             this.ExpandoInfoSurrogate.Load(explorerBarInfo.Expando);

    //             this.HeaderInfoSurrogate = new HeaderInfo.HeaderInfoSurrogate();
    //             this.HeaderInfoSurrogate.Load(explorerBarInfo.Header);
    //         }


    //         /// <summary>
    //         /// Returns an ExplorerBarInfo that contains the deserialized ExplorerBarInfoSurrogate data
    //         /// </summary>
    //         /// <returns>An ExplorerBarInfo that contains the deserialized ExplorerBarInfoSurrogate data</returns>
    //         public ExplorerBarInfo Save()
    //         {
    //             ExplorerBarInfo explorerBarInfo = new ExplorerBarInfo();

    //             explorerBarInfo.TaskPane = this.TaskPaneInfoSurrogate.Save();
    //             explorerBarInfo.TaskItem = this.TaskItemInfoSurrogate.Save();
    //             explorerBarInfo.Expando = this.ExpandoInfoSurrogate.Save();
    //             explorerBarInfo.Header = this.HeaderInfoSurrogate.Save();

    //             return explorerBarInfo;
    //         }


    //         /// <summary>
    //         /// Populates a SerializationInfo with the data needed to serialize the ExplorerBarInfoSurrogate
    //         /// </summary>
    //         /// <param name="info">The SerializationInfo to populate with data</param>
    //         /// <param name="context">The destination for this serialization</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         public void GetObjectData(SerializationInfo info, StreamingContext context)
    //         {
    //             info.AddValue("Version", this.Version);

    //             info.AddValue("TaskPaneInfoSurrogate", this.TaskPaneInfoSurrogate);
    //             info.AddValue("TaskItemInfoSurrogate", this.TaskItemInfoSurrogate);
    //             info.AddValue("ExpandoInfoSurrogate", this.ExpandoInfoSurrogate);
    //             info.AddValue("HeaderInfoSurrogate", this.HeaderInfoSurrogate);
    //         }


    //         /// <summary>
    //         /// Initializes a new instance of the ExplorerBarInfoSurrogate class using the information 
    //         /// in the SerializationInfo
    //         /// </summary>
    //         /// <param name="info">The information to populate the ExplorerBarInfoSurrogate</param>
    //         /// <param name="context">The source from which the ExplorerBarInfoSurrogate is deserialized</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         protected ExplorerBarInfoSurrogate(SerializationInfo info, StreamingContext context) : base()
    //         {
    //             int version = info.GetInt32("Version");

    //             this.TaskPaneInfoSurrogate = (TaskPaneInfo.TaskPaneInfoSurrogate)info.GetValue("TaskPaneInfoSurrogate", typeof(TaskPaneInfo.TaskPaneInfoSurrogate));
    //             this.TaskItemInfoSurrogate = (TaskItemInfo.TaskItemInfoSurrogate)info.GetValue("TaskItemInfoSurrogate", typeof(TaskItemInfo.TaskItemInfoSurrogate));
    //             this.ExpandoInfoSurrogate = (ExpandoInfo.ExpandoInfoSurrogate)info.GetValue("ExpandoInfoSurrogate", typeof(ExpandoInfo.ExpandoInfoSurrogate));
    //             this.HeaderInfoSurrogate = (HeaderInfo.HeaderInfoSurrogate)info.GetValue("HeaderInfoSurrogate", typeof(HeaderInfo.HeaderInfoSurrogate));
    //         }

    //         #endregion
    //     }

    //     #endregion
    // }

    // #endregion


    // #region TaskPaneInfo Class

    // /// <summary>
    // /// A class that contains system defined settings for TaskPanes
    // /// </summary>
    // public class TaskPaneInfo : IDisposable
    // {
    //     #region Class Data

    //     /// <summary>
    //     /// The starting Color for the TaskPane's background gradient
    //     /// </summary>
    //     private Color gradientStartColor;

    //     /// <summary>
    //     /// The ending Color for the TaskPane's background gradient
    //     /// </summary>
    //     private Color gradientEndColor;

    //     /// <summary>
    //     /// The direction of the TaskPane's gradient background
    //     /// </summary>
    //     private LinearGradientMode direction;

    //     /// <summary>
    //     /// The amount of space between the Border and Expandos along 
    //     /// each edge of the TaskPane
    //     /// </summary>
    //     private Padding padding;

    //     /// <summary>
    //     /// The Image that is used as the TaskPane's background
    //     /// </summary>
    //     private Image backImage;

    //     /// <summary>
    //     /// Specified how the TaskPane's background Image is drawn
    //     /// </summary>
    //     private ImageStretchMode stretchMode;

    //     /// <summary>
    //     /// The Image that is used as a watermark
    //     /// </summary>
    //     private Image watermark;

    //     /// <summary>
    //     /// The alignment of the Image used as a watermark
    //     /// </summary>
    //     private System.Drawing.ContentAlignment watermarkAlignment;

    //     /// <summary>
    //     /// The TaskPane that owns the TaskPaneInfo
    //     /// </summary>
    //     private TaskPane owner;

    //     #endregion


    //     #region Constructor

    //     /// <summary>
    //     /// Initializes a new instance of the TaskPaneInfo class with default settings
    //     /// </summary>
    //     public TaskPaneInfo()
    //     {
    //         // set background values
    //         this.gradientStartColor = Color.Transparent;
    //         this.gradientEndColor = Color.Transparent;
    //         this.direction = LinearGradientMode.Vertical;

    //         // set padding values
    //         this.padding = new Padding(12, 12, 12, 12);

    //         // images
    //         this.backImage = null;
    //         this.stretchMode = ImageStretchMode.Tile;

    //         this.watermark = null;
    //         this.watermarkAlignment = System.Drawing.ContentAlignment.BottomCenter;

    //         this.owner = null;
    //     }

    //     #endregion


    //     #region Methods

    //     /// <summary>
    //     /// Forces the use of default values
    //     /// </summary>
    //     public void SetDefaultValues()
    //     {
    //         // set background values
    //         this.gradientStartColor = SystemColors.Window;
    //         this.gradientEndColor = SystemColors.Window;
    //         this.direction = LinearGradientMode.Vertical;

    //         // set padding values
    //         this.padding.Left = 12;
    //         this.padding.Top = 12;
    //         this.padding.Right = 12;
    //         this.padding.Bottom = 12;

    //         // images
    //         this.backImage = null;
    //         this.stretchMode = ImageStretchMode.Tile;
    //         this.watermark = null;
    //         this.watermarkAlignment = System.Drawing.ContentAlignment.BottomCenter;
    //     }


    //     /// <summary>
    //     /// Forces the use of default empty values
    //     /// </summary>
    //     public void SetDefaultEmptyValues()
    //     {
    //         // set background values
    //         this.gradientStartColor = Color.Empty;
    //         this.gradientEndColor = Color.Empty;
    //         this.direction = LinearGradientMode.Vertical;

    //         // set padding values
    //         this.padding.Left = 0;
    //         this.padding.Top = 0;
    //         this.padding.Right = 0;
    //         this.padding.Bottom = 0;

    //         // images
    //         this.backImage = null;
    //         this.stretchMode = ImageStretchMode.Tile;
    //         this.watermark = null;
    //         this.watermarkAlignment = System.Drawing.ContentAlignment.BottomCenter;
    //     }


    //     /// <summary>
    //     /// Releases all resources used by the TaskPaneInfo
    //     /// </summary>
    //     public void Dispose()
    //     {
    //         if (this.backImage != null)
    //         {
    //             this.backImage.Dispose();
    //             this.backImage = null;
    //         }

    //         if (this.watermark != null)
    //         {
    //             this.watermark.Dispose();
    //             this.watermark = null;
    //         }
    //     }

    //     #endregion


    //     #region Properties

    //     #region Background

    //     /// <summary>
    //     /// Gets or sets the TaskPane's first gradient background color
    //     /// </summary>
    //     [Description("The TaskPane's first gradient background color")]
    //     public Color GradientStartColor
    //     {
    //         get
    //         {
    //             return this.gradientStartColor;
    //         }

    //         set
    //         {
    //             if (this.gradientStartColor != value)
    //             {
    //                 this.gradientStartColor = value;

    //                 if (this.TaskPane != null)
    //                 {
    //                     this.TaskPane.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the GradientStartColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the GradientStartColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeGradientStartColor()
    //     {
    //         return this.GradientStartColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the TaskPane's second gradient background color
    //     /// </summary>
    //     [Description("The TaskPane's second gradient background color")]
    //     public Color GradientEndColor
    //     {
    //         get
    //         {
    //             return this.gradientEndColor;
    //         }

    //         set
    //         {
    //             if (this.gradientEndColor != value)
    //             {
    //                 this.gradientEndColor = value;

    //                 if (this.TaskPane != null)
    //                 {
    //                     this.TaskPane.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the GradientEndColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the GradientEndColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeGradientEndColor()
    //     {
    //         return this.GradientEndColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the direction of the TaskPane's gradient
    //     /// </summary>
    //     [DefaultValue(LinearGradientMode.Vertical),
    //     Description("The direction of the TaskPane's background gradient")]
    //     public LinearGradientMode GradientDirection
    //     {
    //         get
    //         {
    //             return this.direction;
    //         }

    //         set
    //         {
    //             if (!Enum.IsDefined(typeof(LinearGradientMode), value))
    //             {
    //                 throw new InvalidEnumArgumentException("value", (int)value, typeof(LinearGradientMode));
    //             }

    //             if (this.direction != value)
    //             {
    //                 this.direction = value;

    //                 if (this.TaskPane != null)
    //                 {
    //                     this.TaskPane.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }

    //     #endregion

    //     #region Images

    //     /// <summary>
    //     /// Gets or sets the Image that is used as the TaskPane's background
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("The Image that is used as the TaskPane's background")]
    //     public Image BackImage
    //     {
    //         get
    //         {
    //             return this.backImage;
    //         }

    //         set
    //         {
    //             if (this.backImage != value)
    //             {
    //                 this.backImage = value;

    //                 if (this.TaskPane != null)
    //                 {
    //                     this.TaskPane.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets how the TaskPane's background Image is drawn
    //     /// </summary>
    //     [Browsable(false),
    //     DefaultValue(ImageStretchMode.Tile),
    //     Description("Specifies how the TaskPane's background Image is drawn")]
    //     public ImageStretchMode StretchMode
    //     {
    //         get
    //         {
    //             return this.stretchMode;
    //         }

    //         set
    //         {
    //             if (!Enum.IsDefined(typeof(ImageStretchMode), value))
    //             {
    //                 throw new InvalidEnumArgumentException("value", (int)value, typeof(ImageStretchMode));
    //             }

    //             if (this.stretchMode != value)
    //             {
    //                 this.stretchMode = value;

    //                 if (this.TaskPane != null)
    //                 {
    //                     this.TaskPane.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the Image that is used as the TaskPane's watermark
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("The Image that is used as the TaskPane's watermark")]
    //     public Image Watermark
    //     {
    //         get
    //         {
    //             return this.watermark;
    //         }

    //         set
    //         {
    //             if (this.watermark != value)
    //             {
    //                 this.watermark = value;

    //                 if (this.TaskPane != null)
    //                 {
    //                     this.TaskPane.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the alignment of the Image that is used as the 
    //     /// TaskPane's watermark
    //     /// </summary>
    //     [DefaultValue(System.Drawing.ContentAlignment.BottomCenter),
    //     Description("The alignment of the Image that is used as the TaskPane's watermark")]
    //     public System.Drawing.ContentAlignment WatermarkAlignment
    //     {
    //         get
    //         {
    //             return this.watermarkAlignment;
    //         }

    //         set
    //         {
    //             if (!Enum.IsDefined(typeof(System.Drawing.ContentAlignment), value))
    //             {
    //                 throw new InvalidEnumArgumentException("value", (int)value, typeof(System.Drawing.ContentAlignment));
    //             }

    //             if (this.watermarkAlignment != value)
    //             {
    //                 this.watermarkAlignment = value;

    //                 if (this.TaskPane != null)
    //                 {
    //                     this.TaskPane.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }

    //     #endregion

    //     #region Padding

    //     /// <summary>
    //     /// Gets or sets the TaskPane's padding between the border and any items
    //     /// </summary>
    //     [Description("The amount of space between the border and the Expando's along each side of the TaskPane")]
    //     public Padding Padding
    //     {
    //         get
    //         {
    //             return this.padding;
    //         }

    //         set
    //         {
    //             if (this.padding != value)
    //             {
    //                 this.padding = value;

    //                 if (this.TaskPane != null)
    //                 {
    //                     this.TaskPane.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the Padding property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the Padding property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializePadding()
    //     {
    //         return this.Padding != Padding.Empty;
    //     }

    //     #endregion

    //     #region TaskPane

    //     /// <summary>
    //     /// Gets or sets the TaskPane the TaskPaneInfo belongs to
    //     /// </summary>
    //     protected internal TaskPane TaskPane
    //     {
    //         get
    //         {
    //             return this.owner;
    //         }

    //         set
    //         {
    //             this.owner = value;
    //         }
    //     }

    //     #endregion

    //     #endregion


    //     #region TaskPaneInfoSurrogate

    //     /// <summary>
    //     /// A class that is serialized instead of a TaskPaneInfo (as 
    //     /// TaskPaneInfos contain objects that cause serialization problems)
    //     /// </summary>
    //     [Serializable()]
    //     public class TaskPaneInfoSurrogate : ISerializable
    //     {
    //         #region Class Data

    //         /// <summary>
    //         /// See TaskPaneInfo.GradientStartColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string GradientStartColor;

    //         /// <summary>
    //         /// See TaskPaneInfo.GradientEndColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string GradientEndColor;

    //         /// <summary>
    //         /// See TaskPaneInfo.GradientDirection.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public LinearGradientMode GradientDirection;

    //         /// <summary>
    //         /// See TaskPaneInfo.Padding.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public Padding Padding;

    //         /// <summary>
    //         /// See TaskPaneInfo.BackImage.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("BackImage", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] BackImage;

    //         /// <summary>
    //         /// See TaskPaneInfo.StretchMode.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public ImageStretchMode StretchMode;

    //         /// <summary>
    //         /// See TaskPaneInfo.Watermark.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("Watermark", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] Watermark;

    //         /// <summary>
    //         /// See TaskPaneInfo.WatermarkAlignment.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public System.Drawing.ContentAlignment WatermarkAlignment;

    //         /// <summary>
    //         /// Version number of the surrogate.  This member is not intended 
    //         /// to be used directly from your code.
    //         /// </summary>
    //         public int Version = 3300;

    //         #endregion


    //         #region Constructor

    //         /// <summary>
    //         /// Initializes a new instance of the TaskPaneInfoSurrogate class with default settings
    //         /// </summary>
    //         public TaskPaneInfoSurrogate()
    //         {
    //             this.GradientStartColor = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.GradientEndColor = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.GradientDirection = LinearGradientMode.Vertical;

    //             this.Padding = Padding.Empty;

    //             this.BackImage = new byte[0];
    //             this.StretchMode = ImageStretchMode.Normal;

    //             this.Watermark = new byte[0];
    //             this.WatermarkAlignment = System.Drawing.ContentAlignment.BottomCenter;
    //         }

    //         #endregion


    //         #region Methods

    //         /// <summary>
    //         /// Populates the TaskPaneInfoSurrogate with data that is to be 
    //         /// serialized from the specified TaskPaneInfo
    //         /// </summary>
    //         /// <param name="taskPaneInfo">The TaskPaneInfo that contains the data 
    //         /// to be serialized</param>
    //         public void Load(TaskPaneInfo taskPaneInfo)
    //         {
    //             this.GradientStartColor = ThemeManager.ConvertColorToString(taskPaneInfo.GradientStartColor);
    //             this.GradientEndColor = ThemeManager.ConvertColorToString(taskPaneInfo.GradientEndColor);
    //             this.GradientDirection = taskPaneInfo.GradientDirection;

    //             this.Padding = taskPaneInfo.Padding;

    //             this.BackImage = ThemeManager.ConvertImageToByteArray(taskPaneInfo.BackImage);
    //             this.StretchMode = taskPaneInfo.StretchMode;

    //             this.Watermark = ThemeManager.ConvertImageToByteArray(taskPaneInfo.Watermark);
    //             this.WatermarkAlignment = taskPaneInfo.WatermarkAlignment;
    //         }


    //         /// <summary>
    //         /// Returns a TaskPaneInfo that contains the deserialized TaskPaneInfoSurrogate data
    //         /// </summary>
    //         /// <returns>A TaskPaneInfo that contains the deserialized TaskPaneInfoSurrogate data</returns>
    //         public TaskPaneInfo Save()
    //         {
    //             TaskPaneInfo taskPaneInfo = new TaskPaneInfo();

    //             taskPaneInfo.GradientStartColor = ThemeManager.ConvertStringToColor(this.GradientStartColor);
    //             taskPaneInfo.GradientEndColor = ThemeManager.ConvertStringToColor(this.GradientEndColor);
    //             taskPaneInfo.GradientDirection = this.GradientDirection;

    //             taskPaneInfo.Padding = this.Padding;

    //             taskPaneInfo.BackImage = ThemeManager.ConvertByteArrayToImage(this.BackImage);
    //             taskPaneInfo.StretchMode = this.StretchMode;

    //             taskPaneInfo.Watermark = ThemeManager.ConvertByteArrayToImage(this.Watermark);
    //             taskPaneInfo.WatermarkAlignment = this.WatermarkAlignment;

    //             return taskPaneInfo;
    //         }


    //         /// <summary>
    //         /// Populates a SerializationInfo with the data needed to serialize the TaskPaneInfoSurrogate
    //         /// </summary>
    //         /// <param name="info">The SerializationInfo to populate with data</param>
    //         /// <param name="context">The destination for this serialization</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         public void GetObjectData(SerializationInfo info, StreamingContext context)
    //         {
    //             info.AddValue("Version", this.Version);

    //             info.AddValue("GradientStartColor", this.GradientStartColor);
    //             info.AddValue("GradientEndColor", this.GradientEndColor);
    //             info.AddValue("GradientDirection", this.GradientDirection);

    //             info.AddValue("Padding", this.Padding);

    //             info.AddValue("BackImage", this.BackImage);
    //             info.AddValue("StretchMode", this.StretchMode);

    //             info.AddValue("Watermark", this.Watermark);
    //             info.AddValue("WatermarkAlignment", this.WatermarkAlignment);
    //         }


    //         /// <summary>
    //         /// Initializes a new instance of the TaskPaneInfoSurrogate class using the information 
    //         /// in the SerializationInfo
    //         /// </summary>
    //         /// <param name="info">The information to populate the TaskPaneInfoSurrogate</param>
    //         /// <param name="context">The source from which the TaskPaneInfoSurrogate is deserialized</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         protected TaskPaneInfoSurrogate(SerializationInfo info, StreamingContext context) : base()
    //         {
    //             int version = info.GetInt32("Version");

    //             this.GradientStartColor = info.GetString("GradientStartColor");
    //             this.GradientEndColor = info.GetString("GradientEndColor");
    //             this.GradientDirection = (LinearGradientMode)info.GetValue("GradientDirection", typeof(LinearGradientMode));

    //             this.Padding = (Padding)info.GetValue("Padding", typeof(Padding));

    //             this.BackImage = (byte[])info.GetValue("BackImage", typeof(byte[]));
    //             this.StretchMode = (ImageStretchMode)info.GetValue("StretchMode", typeof(ImageStretchMode));

    //             this.Watermark = (byte[])info.GetValue("Watermark", typeof(byte[]));
    //             this.WatermarkAlignment = (System.Drawing.ContentAlignment)info.GetValue("WatermarkAlignment", typeof(System.Drawing.ContentAlignment));
    //         }

    //         #endregion
    //     }

    //     #endregion
    // }


    // #region TaskPaneInfoConverter

    // /// <summary>
    // /// A custom TypeConverter used to help convert TaskPaneInfo from 
    // /// one Type to another
    // /// </summary>
    // internal class TaskPaneInfoConverter : ExpandableObjectConverter
    // {
    //     /// <summary>
    //     /// Converts the given value object to the specified type, using 
    //     /// the specified context and culture information
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides 
    //     /// a format context</param>
    //     /// <param name="culture">A CultureInfo object. If a null reference 
    //     /// is passed, the current culture is assumed</param>
    //     /// <param name="value">The Object to convert</param>
    //     /// <param name="destinationType">The Type to convert the value 
    //     /// parameter to</param>
    //     /// <returns>An Object that represents the converted value</returns>
    //     public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    //     {
    //         if (destinationType == typeof(string) && value is TaskPaneInfo)
    //         {
    //             return "";
    //         }

    //         return base.ConvertTo(context, culture, value, destinationType);
    //     }
    // }

    // #endregion

    // #endregion


    // #region TaskItemInfo Class

    // /// <summary>
    // /// A class that contains system defined settings for TaskItems
    // /// </summary>
    // public class TaskItemInfo
    // {
    //     #region Class Data

    //     /// <summary>
    //     /// The amount of space around the text along each side of 
    //     /// the TaskItem
    //     /// </summary>
    //     private Padding padding;

    //     /// <summary>
    //     /// The amount of space between individual TaskItems 
    //     /// along each side of the TaskItem
    //     /// </summary>
    //     private Margin margin;

    //     /// <summary>
    //     /// The Color of the text displayed in the TaskItem
    //     /// </summary>
    //     private Color linkNormal;

    //     /// <summary>
    //     /// The Color of the text displayed in the TaskItem when 
    //     /// highlighted
    //     /// </summary>
    //     private Color linkHot;

    //     /// <summary>
    //     /// The decoration to be used on the text while in a highlighted state
    //     /// </summary>
    //     private FontStyle fontDecoration;

    //     /// <summary>
    //     /// The TaskItem that owns this TaskItemInfo
    //     /// </summary>
    //     private TaskItem owner;

    //     #endregion


    //     #region Constructor

    //     /// <summary>
    //     /// Initializes a new instance of the TaskLinkInfo class with default settings
    //     /// </summary>
    //     public TaskItemInfo()
    //     {
    //         // set padding values
    //         this.padding = new Padding(6, 0, 4, 0);

    //         // set margin values
    //         this.margin = new Margin(0, 4, 0, 0);

    //         // set text values
    //         this.linkNormal = SystemColors.ControlText;
    //         this.linkHot = SystemColors.ControlText;

    //         this.fontDecoration = FontStyle.Underline;

    //         this.owner = null;
    //     }

    //     #endregion


    //     #region Methods

    //     /// <summary>
    //     /// Forces the use of default values
    //     /// </summary>
    //     public void SetDefaultValues()
    //     {
    //         // set padding values
    //         this.padding.Left = 6;
    //         this.padding.Top = 0;
    //         this.padding.Right = 4;
    //         this.padding.Bottom = 0;

    //         // set margin values
    //         this.margin.Left = 0;
    //         this.margin.Top = 4;
    //         this.margin.Right = 0;
    //         this.margin.Bottom = 0;

    //         // set text values
    //         this.linkNormal = SystemColors.ControlText;
    //         this.linkHot = SystemColors.HotTrack;

    //         this.fontDecoration = FontStyle.Underline;
    //     }


    //     /// <summary>
    //     /// Forces the use of default empty values
    //     /// </summary>
    //     public void SetDefaultEmptyValues()
    //     {
    //         this.padding = Padding.Empty;
    //         this.margin = Margin.Empty;
    //         this.linkNormal = Color.Empty;
    //         this.linkHot = Color.Empty;
    //         this.fontDecoration = FontStyle.Underline;
    //     }

    //     #endregion


    //     #region Properties

    //     #region Margin

    //     /// <summary>
    //     /// Gets or sets the amount of space between individual TaskItems 
    //     /// along each side of the TaskItem
    //     /// </summary>
    //     [Description("The amount of space between individual TaskItems along each side of the TaskItem")]
    //     public Margin Margin
    //     {
    //         get
    //         {
    //             return this.margin;
    //         }

    //         set
    //         {
    //             if (this.margin != value)
    //             {
    //                 this.margin = value;

    //                 if (this.TaskItem != null)
    //                 {
    //                     this.TaskItem.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the Margin property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the Margin property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeMargin()
    //     {
    //         return this.Margin != Margin.Empty;
    //     }

    //     #endregion

    //     #region Padding

    //     /// <summary>
    //     /// Gets or sets the amount of space around the text along each 
    //     /// side of the TaskItem
    //     /// </summary>
    //     [Description("The amount of space around the text along each side of the TaskItem")]
    //     public Padding Padding
    //     {
    //         get
    //         {
    //             return this.padding;
    //         }

    //         set
    //         {
    //             if (this.padding != value)
    //             {
    //                 this.padding = value;

    //                 if (this.TaskItem != null)
    //                 {
    //                     this.TaskItem.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the Padding property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the Padding property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializePadding()
    //     {
    //         return this.Padding != Padding.Empty;
    //     }

    //     #endregion

    //     #region Text

    //     /// <summary>
    //     /// Gets or sets the foreground color of a normal link
    //     /// </summary>
    //     [Description("The foreground color of a normal link")]
    //     public Color LinkColor
    //     {
    //         get
    //         {
    //             return this.linkNormal;
    //         }

    //         set
    //         {
    //             if (this.linkNormal != value)
    //             {
    //                 this.linkNormal = value;

    //                 if (this.TaskItem != null)
    //                 {
    //                     this.TaskItem.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the LinkColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the LinkColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeLinkColor()
    //     {
    //         return this.LinkColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the foreground color of a highlighted link
    //     /// </summary>
    //     [Description("The foreground color of a highlighted link")]
    //     public Color HotLinkColor
    //     {
    //         get
    //         {
    //             return this.linkHot;
    //         }

    //         set
    //         {
    //             if (this.linkHot != value)
    //             {
    //                 this.linkHot = value;

    //                 if (this.TaskItem != null)
    //                 {
    //                     this.TaskItem.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the HotLinkColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the HotLinkColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeHotLinkColor()
    //     {
    //         return this.HotLinkColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the font decoration of a link
    //     /// </summary>
    //     [DefaultValue(FontStyle.Underline),
    //     Description("")]
    //     public FontStyle FontDecoration
    //     {
    //         get
    //         {
    //             return this.fontDecoration;
    //         }

    //         set
    //         {
    //             if (!Enum.IsDefined(typeof(FontStyle), value))
    //             {
    //                 throw new InvalidEnumArgumentException("value", (int)value, typeof(FontStyle));
    //             }

    //             if (this.fontDecoration != value)
    //             {
    //                 this.fontDecoration = value;

    //                 if (this.TaskItem != null)
    //                 {
    //                     this.TaskItem.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }

    //     #endregion

    //     #region TaskItem

    //     /// <summary>
    //     /// Gets or sets the TaskItem the TaskItemInfo belongs to
    //     /// </summary>
    //     protected internal TaskItem TaskItem
    //     {
    //         get
    //         {
    //             return this.owner;
    //         }

    //         set
    //         {
    //             this.owner = value;
    //         }
    //     }

    //     #endregion

    //     #endregion


    //     #region TaskItemInfoSurrogate

    //     /// <summary>
    //     /// A class that is serialized instead of a TaskItemInfo (as 
    //     /// TaskItemInfos contain objects that cause serialization problems)
    //     /// </summary>
    //     [Serializable()]
    //     public class TaskItemInfoSurrogate : ISerializable
    //     {
    //         #region Class Data

    //         /// <summary>
    //         /// See TaskItemInfo.Padding.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public Padding Padding;

    //         /// <summary>
    //         /// See TaskItemInfo.Margin.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public Margin Margin;

    //         /// <summary>
    //         /// See TaskItemInfo.LinkColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string LinkNormal;

    //         /// <summary>
    //         /// See TaskItemInfo.HotLinkColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string LinkHot;

    //         /// <summary>
    //         /// See TaskItemInfo.FontDecoration.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public FontStyle FontDecoration;

    //         /// <summary>
    //         /// Version number of the surrogate.  This member is not intended 
    //         /// to be used directly from your code.
    //         /// </summary>
    //         public int Version = 3300;

    //         #endregion


    //         #region Constructor

    //         /// <summary>
    //         /// Initializes a new instance of the TaskItemInfoSurrogate class with default settings
    //         /// </summary>
    //         public TaskItemInfoSurrogate()
    //         {
    //             this.Padding = Padding.Empty;
    //             this.Margin = Margin.Empty;

    //             this.LinkNormal = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.LinkHot = ThemeManager.ConvertColorToString(Color.Empty);

    //             this.FontDecoration = FontStyle.Regular;
    //         }

    //         #endregion


    //         #region Methods

    //         /// <summary>
    //         /// Populates the TaskItemInfoSurrogate with data that is to be 
    //         /// serialized from the specified TaskItemInfo
    //         /// </summary>
    //         /// <param name="taskItemInfo">The TaskItemInfo that contains the data 
    //         /// to be serialized</param>
    //         public void Load(TaskItemInfo taskItemInfo)
    //         {
    //             this.Padding = taskItemInfo.Padding;
    //             this.Margin = taskItemInfo.Margin;

    //             this.LinkNormal = ThemeManager.ConvertColorToString(taskItemInfo.LinkColor);
    //             this.LinkHot = ThemeManager.ConvertColorToString(taskItemInfo.HotLinkColor);

    //             this.FontDecoration = taskItemInfo.FontDecoration;
    //         }


    //         /// <summary>
    //         /// Returns a TaskItemInfo that contains the deserialized TaskItemInfoSurrogate data
    //         /// </summary>
    //         /// <returns>A TaskItemInfo that contains the deserialized TaskItemInfoSurrogate data</returns>
    //         public TaskItemInfo Save()
    //         {
    //             TaskItemInfo taskItemInfo = new TaskItemInfo();

    //             taskItemInfo.Padding = this.Padding;
    //             taskItemInfo.Margin = this.Margin;

    //             taskItemInfo.LinkColor = ThemeManager.ConvertStringToColor(this.LinkNormal);
    //             taskItemInfo.HotLinkColor = ThemeManager.ConvertStringToColor(this.LinkHot);

    //             taskItemInfo.FontDecoration = this.FontDecoration;

    //             return taskItemInfo;
    //         }


    //         /// <summary>
    //         /// Populates a SerializationInfo with the data needed to serialize the TaskItemInfoSurrogate
    //         /// </summary>
    //         /// <param name="info">The SerializationInfo to populate with data</param>
    //         /// <param name="context">The destination for this serialization</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         public void GetObjectData(SerializationInfo info, StreamingContext context)
    //         {
    //             info.AddValue("Version", this.Version);

    //             info.AddValue("Padding", this.Padding);
    //             info.AddValue("Margin", this.Margin);

    //             info.AddValue("LinkNormal", this.LinkNormal);
    //             info.AddValue("LinkHot", this.LinkHot);

    //             info.AddValue("FontDecoration", this.FontDecoration);
    //         }


    //         /// <summary>
    //         /// Initializes a new instance of the TaskItemInfoSurrogate class using the information 
    //         /// in the SerializationInfo
    //         /// </summary>
    //         /// <param name="info">The information to populate the TaskItemInfoSurrogate</param>
    //         /// <param name="context">The source from which the TaskItemInfoSurrogate is deserialized</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         protected TaskItemInfoSurrogate(SerializationInfo info, StreamingContext context) : base()
    //         {
    //             int version = info.GetInt32("Version");

    //             this.Padding = (Padding)info.GetValue("Padding", typeof(Padding));
    //             this.Margin = (Margin)info.GetValue("Margin", typeof(Margin));

    //             this.LinkNormal = info.GetString("LinkNormal");
    //             this.LinkHot = info.GetString("LinkHot");

    //             this.FontDecoration = (FontStyle)info.GetValue("FontDecoration", typeof(FontStyle));
    //         }

    //         #endregion
    //     }

    //     #endregion
    // }


    // #region TaskItemInfoConverter

    // /// <summary>
    // /// A custom TypeConverter used to help convert TaskItemInfo from 
    // /// one Type to another
    // /// </summary>
    // internal class TaskItemInfoConverter : ExpandableObjectConverter
    // {
    //     /// <summary>
    //     /// Converts the given value object to the specified type, using 
    //     /// the specified context and culture information
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides 
    //     /// a format context</param>
    //     /// <param name="culture">A CultureInfo object. If a null reference 
    //     /// is passed, the current culture is assumed</param>
    //     /// <param name="value">The Object to convert</param>
    //     /// <param name="destinationType">The Type to convert the value 
    //     /// parameter to</param>
    //     /// <returns>An Object that represents the converted value</returns>
    //     public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    //     {
    //         if (destinationType == typeof(string) && value is TaskItemInfo)
    //         {
    //             return "";
    //         }

    //         return base.ConvertTo(context, culture, value, destinationType);
    //     }
    // }

    // #endregion

    // #endregion


    // #region ExpandoInfo Class

    // /// <summary>
    // /// A class that contains system defined settings for Expandos
    // /// </summary>
    // public class ExpandoInfo : IDisposable
    // {
    //     #region Class Data

    //     /// <summary>
    //     /// The background Color of an Expando that is a special group
    //     /// </summary>
    //     private Color specialBackColor;

    //     /// <summary>
    //     /// The background Color of an Expando that is a normal group
    //     /// </summary>
    //     private Color normalBackColor;

    //     /// <summary>
    //     /// The width of the Border along each edge of an Expando that 
    //     /// is a special group
    //     /// </summary>
    //     private Border specialBorder;

    //     /// <summary>
    //     /// The width of the Border along each edge of an Expando that 
    //     /// is a normal group
    //     /// </summary>
    //     private Border normalBorder;

    //     /// <summary>
    //     /// The Color of the Border an Expando that is a special group
    //     /// </summary>
    //     private Color specialBorderColor;

    //     /// <summary>
    //     /// The Color of the Border an Expando that is a normal group
    //     /// </summary>
    //     private Color normalBorderColor;

    //     /// <summary>
    //     /// The amount of space between the Border and items along 
    //     /// each edge of an Expando that is a special group
    //     /// </summary>
    //     private Padding specialPadding;

    //     /// <summary>
    //     /// The amount of space between the Border and items along 
    //     /// each edge of an Expando that is a normal group
    //     /// </summary>
    //     private Padding normalPadding;

    //     /// <summary>
    //     /// The alignment of the Image that is to be used as a watermark
    //     /// </summary>
    //     private System.Drawing.ContentAlignment watermarkAlignment;

    //     /// <summary>
    //     /// The background image used for the content area of a special Expando
    //     /// </summary>
    //     private Image specialBackImage;

    //     /// <summary>
    //     /// The background image used for the content area of a normal Expando
    //     /// </summary>
    //     private Image normalBackImage;

    //     /// <summary>
    //     /// The Expando that the ExpandoInfo belongs to
    //     /// </summary>
    //     private Expando owner;

    //     #endregion


    //     #region Constructor

    //     /// <summary>
    //     /// Initializes a new instance of the ExpandoInfo class with default settings
    //     /// </summary>
    //     public ExpandoInfo()
    //     {
    //         // set background color values
    //         this.specialBackColor = Color.Transparent;
    //         this.normalBackColor = Color.Transparent;

    //         // set border values
    //         this.specialBorder = new Border(1, 0, 1, 1);
    //         this.specialBorderColor = Color.Transparent;

    //         this.normalBorder = new Border(1, 0, 1, 1);
    //         this.normalBorderColor = Color.Transparent;

    //         // set padding values
    //         this.specialPadding = new Padding(12, 10, 12, 10);
    //         this.normalPadding = new Padding(12, 10, 12, 10);

    //         this.specialBackImage = null;
    //         this.normalBackImage = null;

    //         this.watermarkAlignment = System.Drawing.ContentAlignment.BottomRight;

    //         this.owner = null;
    //     }

    //     #endregion


    //     #region Methods

    //     /// <summary>
    //     /// Forces the use of default values
    //     /// </summary>
    //     public void SetDefaultValues()
    //     {
    //         // set background color values
    //         this.specialBackColor = SystemColors.Window;
    //         this.normalBackColor = SystemColors.Window;

    //         // set border values
    //         this.specialBorder.Left = 1;
    //         this.specialBorder.Top = 0;
    //         this.specialBorder.Right = 1;
    //         this.specialBorder.Bottom = 1;

    //         this.specialBorderColor = SystemColors.Highlight;

    //         this.normalBorder.Left = 1;
    //         this.normalBorder.Top = 0;
    //         this.normalBorder.Right = 1;
    //         this.normalBorder.Bottom = 1;

    //         this.normalBorderColor = SystemColors.Control;

    //         // set padding values
    //         this.specialPadding.Left = 12;
    //         this.specialPadding.Top = 10;
    //         this.specialPadding.Right = 12;
    //         this.specialPadding.Bottom = 10;

    //         this.normalPadding.Left = 12;
    //         this.normalPadding.Top = 10;
    //         this.normalPadding.Right = 12;
    //         this.normalPadding.Bottom = 10;

    //         this.specialBackImage = null;
    //         this.normalBackImage = null;

    //         this.watermarkAlignment = System.Drawing.ContentAlignment.BottomRight;
    //     }


    //     /// <summary>
    //     /// Forces the use of default empty values
    //     /// </summary>
    //     public void SetDefaultEmptyValues()
    //     {
    //         // set background color values
    //         this.specialBackColor = Color.Empty;
    //         this.normalBackColor = Color.Empty;

    //         // set border values
    //         this.specialBorder = Border.Empty;
    //         this.specialBorderColor = Color.Empty;

    //         this.normalBorder = Border.Empty;
    //         this.normalBorderColor = Color.Empty;

    //         // set padding values
    //         this.specialPadding = Padding.Empty;
    //         this.normalPadding = Padding.Empty;

    //         this.specialBackImage = null;
    //         this.normalBackImage = null;

    //         this.watermarkAlignment = System.Drawing.ContentAlignment.BottomRight;
    //     }


    //     /// <summary>
    //     /// Releases all resources used by the ExpandoInfo
    //     /// </summary>
    //     public void Dispose()
    //     {
    //         if (this.specialBackImage != null)
    //         {
    //             this.specialBackImage.Dispose();
    //             this.specialBackImage = null;
    //         }

    //         if (this.normalBackImage != null)
    //         {
    //             this.normalBackImage.Dispose();
    //             this.normalBackImage = null;
    //         }
    //     }

    //     #endregion


    //     #region Properties

    //     #region Background

    //     /// <summary>
    //     /// Gets or sets the background color of a special expando
    //     /// </summary>
    //     [Description("The background color of a special Expando")]
    //     public Color SpecialBackColor
    //     {
    //         get
    //         {
    //             return this.specialBackColor;
    //         }

    //         set
    //         {
    //             if (this.specialBackColor != value)
    //             {
    //                 this.specialBackColor = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the SpecialBackColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the SpecialBackColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeSpecialBackColor()
    //     {
    //         return this.SpecialBackColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the background color of a normal expando
    //     /// </summary>
    //     [Description("The background color of a normal Expando")]
    //     public Color NormalBackColor
    //     {
    //         get
    //         {
    //             return this.normalBackColor;
    //         }

    //         set
    //         {
    //             if (this.normalBackColor != value)
    //             {
    //                 this.normalBackColor = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the NormalBackColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the NormalBackColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeNormalBackColor()
    //     {
    //         return this.NormalBackColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the alignment for the expando's background image
    //     /// </summary>
    //     [DefaultValue(System.Drawing.ContentAlignment.BottomRight),
    //     Description("The alignment for the expando's background image")]
    //     public System.Drawing.ContentAlignment WatermarkAlignment
    //     {
    //         get
    //         {
    //             return this.watermarkAlignment;
    //         }

    //         set
    //         {
    //             if (!Enum.IsDefined(typeof(System.Drawing.ContentAlignment), value))
    //             {
    //                 throw new InvalidEnumArgumentException("value", (int)value, typeof(System.Drawing.ContentAlignment));
    //             }

    //             if (this.watermarkAlignment != value)
    //             {
    //                 this.watermarkAlignment = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets a special expando's background image
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("")]
    //     public Image SpecialBackImage
    //     {
    //         get
    //         {
    //             return this.specialBackImage;
    //         }

    //         set
    //         {
    //             if (this.specialBackImage != value)
    //             {
    //                 this.specialBackImage = value;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets a normal expando's background image
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("")]
    //     public Image NormalBackImage
    //     {
    //         get
    //         {
    //             return this.normalBackImage;
    //         }

    //         set
    //         {
    //             if (this.normalBackImage != value)
    //             {
    //                 this.normalBackImage = value;
    //             }
    //         }
    //     }

    //     #endregion

    //     #region Border

    //     /// <summary>
    //     /// Gets or sets the border for a special expando
    //     /// </summary>
    //     [Description("The width of the Border along each side of a special Expando")]
    //     public Border SpecialBorder
    //     {
    //         get
    //         {
    //             return this.specialBorder;
    //         }

    //         set
    //         {
    //             if (this.specialBorder != value)
    //             {
    //                 this.specialBorder = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the SpecialBorder property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the SpecialBorder property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeSpecialBorder()
    //     {
    //         return this.SpecialBorder != Border.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the border for a normal expando
    //     /// </summary>
    //     [Description("The width of the Border along each side of a normal Expando")]
    //     public Border NormalBorder
    //     {
    //         get
    //         {
    //             return this.normalBorder;
    //         }

    //         set
    //         {
    //             if (this.normalBorder != value)
    //             {
    //                 this.normalBorder = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the NormalBorder property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the NormalBorder property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeNormalBorder()
    //     {
    //         return this.NormalBorder != Border.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the border color for a special expando
    //     /// </summary>
    //     [Description("The border color for a special Expando")]
    //     public Color SpecialBorderColor
    //     {
    //         get
    //         {
    //             return this.specialBorderColor;
    //         }

    //         set
    //         {
    //             if (this.specialBorderColor != value)
    //             {
    //                 this.specialBorderColor = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the SpecialBorderColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the SpecialBorderColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeSpecialBorderColor()
    //     {
    //         return this.SpecialBorderColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the border color for a normal expando
    //     /// </summary>
    //     [Description("The border color for a normal Expando")]
    //     public Color NormalBorderColor
    //     {
    //         get
    //         {
    //             return this.normalBorderColor;
    //         }

    //         set
    //         {
    //             if (this.normalBorderColor != value)
    //             {
    //                 this.normalBorderColor = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the NormalBorderColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the NormalBorderColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeNormalBorderColor()
    //     {
    //         return this.NormalBorderColor != Color.Empty;
    //     }

    //     #endregion

    //     #region Padding

    //     /// <summary>
    //     /// Gets or sets the padding value for a special expando
    //     /// </summary>
    //     [Description("The amount of space between the border and items along each side of a special Expando")]
    //     public Padding SpecialPadding
    //     {
    //         get
    //         {
    //             return this.specialPadding;
    //         }

    //         set
    //         {
    //             if (this.specialPadding != value)
    //             {
    //                 this.specialPadding = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the SpecialPadding property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the SpecialPadding property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeSpecialPadding()
    //     {
    //         return this.SpecialPadding != Padding.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the padding value for a normal expando
    //     /// </summary>
    //     [Description("The amount of space between the border and items along each side of a normal Expando")]
    //     public Padding NormalPadding
    //     {
    //         get
    //         {
    //             return this.normalPadding;
    //         }

    //         set
    //         {
    //             if (this.normalPadding != value)
    //             {
    //                 this.normalPadding = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the NormalPadding property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the NormalPadding property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeNormalPadding()
    //     {
    //         return this.NormalPadding != Padding.Empty;
    //     }

    //     #endregion

    //     #region Expando

    //     /// <summary>
    //     /// Gets or sets the Expando that the ExpandoInfo belongs to
    //     /// </summary>
    //     protected internal Expando Expando
    //     {
    //         get
    //         {
    //             return this.owner;
    //         }

    //         set
    //         {
    //             this.owner = value;
    //         }
    //     }

    //     #endregion

    //     #endregion


    //     #region ExpandoInfoSurrogate

    //     /// <summary>
    //     /// A class that is serialized instead of an ExpandoInfo (as 
    //     /// ExpandoInfos contain objects that cause serialization problems)
    //     /// </summary>
    //     [Serializable()]
    //     public class ExpandoInfoSurrogate : ISerializable
    //     {
    //         #region Class Data

    //         /// <summary>
    //         /// See ExpandoInfo.SpecialBackColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string SpecialBackColor;

    //         /// <summary>
    //         /// See ExpandoInfo.NormalBackColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string NormalBackColor;

    //         /// <summary>
    //         /// See ExpandoInfo.SpecialBorder.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public Border SpecialBorder;

    //         /// <summary>
    //         /// See ExpandoInfo.NormalBorder.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public Border NormalBorder;

    //         /// <summary>
    //         /// See ExpandoInfo.SpecialBorderColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string SpecialBorderColor;

    //         /// <summary>
    //         /// See ExpandoInfo.NormalBorderColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string NormalBorderColor;

    //         /// <summary>
    //         /// See ExpandoInfo.SpecialPadding.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public Padding SpecialPadding;

    //         /// <summary>
    //         /// See ExpandoInfo.NormalPadding.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public Padding NormalPadding;

    //         /// <summary>
    //         /// See ExpandoInfo.SpecialBackImage.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("SpecialBackImage", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] SpecialBackImage;

    //         /// <summary>
    //         /// See ExpandoInfo.NormalBackImage.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("NormalBackImage", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] NormalBackImage;

    //         /// <summary>
    //         /// See ExpandoInfo.WatermarkAlignment.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public System.Drawing.ContentAlignment WatermarkAlignment;

    //         /// <summary>
    //         /// Version number of the surrogate.  This member is not intended 
    //         /// to be used directly from your code.
    //         /// </summary>
    //         public int Version = 3300;

    //         #endregion


    //         #region Constructor

    //         /// <summary>
    //         /// Initializes a new instance of the ExpandoInfoSurrogate class with default settings
    //         /// </summary>
    //         public ExpandoInfoSurrogate()
    //         {
    //             this.SpecialBackColor = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.NormalBackColor = ThemeManager.ConvertColorToString(Color.Empty);

    //             this.SpecialBorder = Border.Empty;
    //             this.NormalBorder = Border.Empty;

    //             this.SpecialBorderColor = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.NormalBorderColor = ThemeManager.ConvertColorToString(Color.Empty);

    //             this.SpecialPadding = Padding.Empty;
    //             this.NormalPadding = Padding.Empty;

    //             this.SpecialBackImage = new byte[0];
    //             this.NormalBackImage = new byte[0];

    //             this.WatermarkAlignment = System.Drawing.ContentAlignment.BottomRight;
    //         }

    //         #endregion


    //         #region Methods

    //         /// <summary>
    //         /// Populates the ExpandoInfoSurrogate with data that is to be 
    //         /// serialized from the specified ExpandoInfo
    //         /// </summary>
    //         /// <param name="expandoInfo">The ExpandoInfo that contains the data 
    //         /// to be serialized</param>
    //         public void Load(ExpandoInfo expandoInfo)
    //         {
    //             this.SpecialBackColor = ThemeManager.ConvertColorToString(expandoInfo.SpecialBackColor);
    //             this.NormalBackColor = ThemeManager.ConvertColorToString(expandoInfo.NormalBackColor);

    //             this.SpecialBorder = expandoInfo.SpecialBorder;
    //             this.NormalBorder = expandoInfo.NormalBorder;

    //             this.SpecialBorderColor = ThemeManager.ConvertColorToString(expandoInfo.SpecialBorderColor);
    //             this.NormalBorderColor = ThemeManager.ConvertColorToString(expandoInfo.NormalBorderColor);

    //             this.SpecialPadding = expandoInfo.SpecialPadding;
    //             this.NormalPadding = expandoInfo.NormalPadding;

    //             this.SpecialBackImage = ThemeManager.ConvertImageToByteArray(expandoInfo.SpecialBackImage);
    //             this.NormalBackImage = ThemeManager.ConvertImageToByteArray(expandoInfo.NormalBackImage);

    //             this.WatermarkAlignment = expandoInfo.WatermarkAlignment;
    //         }


    //         /// <summary>
    //         /// Returns an ExpandoInfo that contains the deserialized ExpandoInfoSurrogate data
    //         /// </summary>
    //         /// <returns>An ExpandoInfo that contains the deserialized ExpandoInfoSurrogate data</returns>
    //         public ExpandoInfo Save()
    //         {
    //             ExpandoInfo expandoInfo = new ExpandoInfo();

    //             expandoInfo.SpecialBackColor = ThemeManager.ConvertStringToColor(this.SpecialBackColor);
    //             expandoInfo.NormalBackColor = ThemeManager.ConvertStringToColor(this.NormalBackColor);

    //             expandoInfo.SpecialBorder = this.SpecialBorder;
    //             expandoInfo.NormalBorder = this.NormalBorder;

    //             expandoInfo.SpecialBorderColor = ThemeManager.ConvertStringToColor(this.SpecialBorderColor);
    //             expandoInfo.NormalBorderColor = ThemeManager.ConvertStringToColor(this.NormalBorderColor);

    //             expandoInfo.SpecialPadding = this.SpecialPadding;
    //             expandoInfo.NormalPadding = this.NormalPadding;

    //             expandoInfo.SpecialBackImage = ThemeManager.ConvertByteArrayToImage(this.SpecialBackImage);
    //             expandoInfo.NormalBackImage = ThemeManager.ConvertByteArrayToImage(this.NormalBackImage);

    //             expandoInfo.WatermarkAlignment = this.WatermarkAlignment;

    //             return expandoInfo;
    //         }


    //         /// <summary>
    //         /// Populates a SerializationInfo with the data needed to serialize the ExpandoInfoSurrogate
    //         /// </summary>
    //         /// <param name="info">The SerializationInfo to populate with data</param>
    //         /// <param name="context">The destination for this serialization</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         public void GetObjectData(SerializationInfo info, StreamingContext context)
    //         {
    //             info.AddValue("Version", this.Version);

    //             info.AddValue("SpecialBackColor", this.SpecialBackColor);
    //             info.AddValue("NormalBackColor", this.NormalBackColor);

    //             info.AddValue("SpecialBorder", this.SpecialBorder);
    //             info.AddValue("NormalBorder", this.NormalBorder);

    //             info.AddValue("SpecialBorderColor", this.SpecialBorderColor);
    //             info.AddValue("NormalBorderColor", this.NormalBorderColor);

    //             info.AddValue("SpecialPadding", this.SpecialPadding);
    //             info.AddValue("NormalPadding", this.NormalPadding);

    //             info.AddValue("SpecialBackImage", this.SpecialBackImage);
    //             info.AddValue("NormalBackImage", this.NormalBackImage);

    //             info.AddValue("WatermarkAlignment", this.WatermarkAlignment);
    //         }


    //         /// <summary>
    //         /// Initializes a new instance of the ExpandoInfoSurrogate class using the information 
    //         /// in the SerializationInfo
    //         /// </summary>
    //         /// <param name="info">The information to populate the ExpandoInfoSurrogate</param>
    //         /// <param name="context">The source from which the ExpandoInfoSurrogate is deserialized</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         protected ExpandoInfoSurrogate(SerializationInfo info, StreamingContext context) : base()
    //         {
    //             int version = info.GetInt32("Version");

    //             this.SpecialBackColor = info.GetString("SpecialBackColor");
    //             this.NormalBackColor = info.GetString("NormalBackColor");

    //             this.SpecialBorder = (Border)info.GetValue("SpecialBorder", typeof(Border));
    //             this.NormalBorder = (Border)info.GetValue("NormalBorder", typeof(Border));

    //             this.SpecialBorderColor = info.GetString("SpecialBorderColor");
    //             this.NormalBorderColor = info.GetString("NormalBorderColor");

    //             this.SpecialPadding = (Padding)info.GetValue("SpecialPadding", typeof(Padding));
    //             this.NormalPadding = (Padding)info.GetValue("NormalPadding", typeof(Padding));

    //             this.SpecialBackImage = (byte[])info.GetValue("SpecialBackImage", typeof(byte[]));
    //             this.NormalBackImage = (byte[])info.GetValue("NormalBackImage", typeof(byte[]));

    //             this.WatermarkAlignment = (System.Drawing.ContentAlignment)info.GetValue("WatermarkAlignment", typeof(System.Drawing.ContentAlignment));
    //         }

    //         #endregion
    //     }

    //     #endregion
    // }


    // #region ExpandoInfoConverter

    // /// <summary>
    // /// A custom TypeConverter used to help convert ExpandoInfos from 
    // /// one Type to another
    // /// </summary>
    // internal class ExpandoInfoConverter : ExpandableObjectConverter
    // {
    //     /// <summary>
    //     /// Converts the given value object to the specified type, using 
    //     /// the specified context and culture information
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides 
    //     /// a format context</param>
    //     /// <param name="culture">A CultureInfo object. If a null reference 
    //     /// is passed, the current culture is assumed</param>
    //     /// <param name="value">The Object to convert</param>
    //     /// <param name="destinationType">The Type to convert the value 
    //     /// parameter to</param>
    //     /// <returns>An Object that represents the converted value</returns>
    //     public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    //     {
    //         if (destinationType == typeof(string) && value is ExpandoInfo)
    //         {
    //             return "";
    //         }

    //         return base.ConvertTo(context, culture, value, destinationType);
    //     }


    //     /// <summary>
    //     /// Returns a collection of properties for the type of array specified 
    //     /// by the value parameter, using the specified context and attributes
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a format 
    //     /// context</param>
    //     /// <param name="value">An Object that specifies the type of array for 
    //     /// which to get properties</param>
    //     /// <param name="attributes">An array of type Attribute that is used as 
    //     /// a filter</param>
    //     /// <returns>A PropertyDescriptorCollection with the properties that are 
    //     /// exposed for this data type, or a null reference if there are no 
    //     /// properties</returns>
    //     public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    //     {
    //         // set the order in which the properties appear 
    //         // in the property window

    //         PropertyDescriptorCollection collection = TypeDescriptor.GetProperties(typeof(ExpandoInfo), attributes);

    //         string[] s = new string[9];
    //         s[0] = "NormalBackColor";
    //         s[1] = "SpecialBackColor";
    //         s[2] = "NormalBorder";
    //         s[3] = "SpecialBorder";
    //         s[4] = "NormalBorderColor";
    //         s[5] = "SpecialBorderColor";
    //         s[6] = "NormalPadding";
    //         s[7] = "SpecialPadding";
    //         s[8] = "WatermarkAlignment";

    //         return collection.Sort(s);
    //     }
    // }

    // #endregion

    // #endregion


    // #region HeaderInfo Class

    // /// <summary>
    // /// A class that contains system defined settings for an Expando's 
    // /// header section
    // /// </summary>
    // public class HeaderInfo : IDisposable
    // {
    //     #region Class Data

    //     /// <summary>
    //     /// The Font used to draw the text on the title bar
    //     /// </summary>
    //     private Font titleFont;

    //     /// <summary>
    //     /// The Margin around the header
    //     /// </summary>
    //     private int margin;

    //     /// <summary>
    //     /// The Image used as the title bar's background for a special Expando
    //     /// </summary>
    //     private Image specialBackImage;

    //     /// <summary>
    //     /// The Image used as the title bar's background for a normal Expando
    //     /// </summary>
    //     private Image normalBackImage;

    //     /// <summary>
    //     ///  The width of the Image used as the title bar's background
    //     /// </summary>
    //     private int backImageWidth;

    //     /// <summary>
    //     /// The height of the Image used as the title bar's background
    //     /// </summary>
    //     private int backImageHeight;

    //     /// <summary>
    //     /// The Color of the text on the title bar for a special Expando
    //     /// </summary>
    //     private Color specialTitle;

    //     /// <summary>
    //     /// The Color of the text on the title bar for a normal Expando
    //     /// </summary>
    //     private Color normalTitle;

    //     /// <summary>
    //     /// The Color of the text on the title bar for a special Expando 
    //     /// when highlighted
    //     /// </summary>
    //     private Color specialTitleHot;

    //     /// <summary>
    //     /// The Color of the text on the title bar for a normal Expando 
    //     /// when highlighted
    //     /// </summary>
    //     private Color normalTitleHot;

    //     /// <summary>
    //     /// The alignment of the text on the title bar for a special Expando
    //     /// </summary>
    //     private System.Drawing.ContentAlignment specialAlignment;

    //     /// <summary>
    //     /// The alignment of the text on the title bar for a normal Expando
    //     /// </summary>
    //     private System.Drawing.ContentAlignment normalAlignment;

    //     /// <summary>
    //     /// The amount of space between the border and items along 
    //     /// each edge of the title bar for a special Expando
    //     /// </summary>
    //     private Padding specialPadding;

    //     /// <summary>
    //     /// The amount of space between the border and items along 
    //     /// each edge of the title bar for a normal Expando
    //     /// </summary>
    //     private Padding normalPadding;

    //     /// <summary>
    //     /// The width of the Border along each edge of the title bar 
    //     /// for a special Expando
    //     /// </summary>
    //     private Border specialBorder;

    //     /// <summary>
    //     /// The width of the Border along each edge of the title bar 
    //     /// for a normal Expando
    //     /// </summary>
    //     private Border normalBorder;

    //     /// <summary>
    //     /// The Color of the title bar's Border for a special Expando
    //     /// </summary>
    //     private Color specialBorderColor;

    //     /// <summary>
    //     /// The Color of the title bar's Border for a normal Expando
    //     /// </summary>
    //     private Color normalBorderColor;

    //     /// <summary>
    //     /// The Color of the title bar's background for a special Expando
    //     /// </summary>
    //     private Color specialBackColor;

    //     /// <summary>
    //     /// The Color of the title bar's background for a normal Expando
    //     /// </summary>
    //     private Color normalBackColor;

    //     /// <summary>
    //     /// The Image that is used as a collapse arrow on the title bar 
    //     /// for a special Expando
    //     /// </summary>
    //     private Image specialArrowUp;

    //     /// <summary>
    //     /// The Image that is used as a collapse arrow on the title bar 
    //     /// for a special Expando when highlighted
    //     /// </summary>
    //     private Image specialArrowUpHot;

    //     /// <summary>
    //     /// The Image that is used as an expand arrow on the title bar 
    //     /// for a special Expando
    //     /// </summary>
    //     private Image specialArrowDown;

    //     /// <summary>
    //     /// The Image that is used as an expand arrow on the title bar 
    //     /// for a special Expando when highlighted
    //     /// </summary>
    //     private Image specialArrowDownHot;

    //     /// <summary>
    //     /// The Image that is used as a collapse arrow on the title bar 
    //     /// for a normal Expando
    //     /// </summary>
    //     private Image normalArrowUp;

    //     /// <summary>
    //     /// The Image that is used as a collapse arrow on the title bar 
    //     /// for a normal Expando when highlighted
    //     /// </summary>
    //     private Image normalArrowUpHot;

    //     /// <summary>
    //     /// The Image that is used as an expand arrow on the title bar 
    //     /// for a normal Expando
    //     /// </summary>
    //     private Image normalArrowDown;

    //     /// <summary>
    //     /// The Image that is used as an expand arrow on the title bar 
    //     /// for a normal Expando when highlighted
    //     /// </summary>
    //     private Image normalArrowDownHot;

    //     /// <summary>
    //     /// Specifies whether the title bar should use a gradient fill
    //     /// </summary>
    //     private bool useTitleGradient;

    //     /// <summary>
    //     /// The start Color of a title bar's gradient fill for a special 
    //     /// Expando
    //     /// </summary>
    //     private Color specialGradientStartColor;

    //     /// <summary>
    //     /// The end Color of a title bar's gradient fill for a special 
    //     /// Expando
    //     /// </summary>
    //     private Color specialGradientEndColor;

    //     /// <summary>
    //     /// The start Color of a title bar's gradient fill for a normal 
    //     /// Expando
    //     /// </summary>
    //     private Color normalGradientStartColor;

    //     /// <summary>
    //     /// The end Color of a title bar's gradient fill for a normal 
    //     /// Expando
    //     /// </summary>
    //     private Color normalGradientEndColor;

    //     /// <summary>
    //     /// How far along the title bar the gradient starts
    //     /// </summary>
    //     private float gradientOffset;

    //     /// <summary>
    //     /// The radius of the corners on the title bar
    //     /// </summary>
    //     private int titleRadius;

    //     /// <summary>
    //     /// The Expando that the HeaderInfo belongs to
    //     /// </summary>
    //     private Expando owner;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     private bool rightToLeft;

    //     #endregion


    //     #region Constructor

    //     /// <summary>
    //     /// Initializes a new instance of the HeaderInfo class with default settings
    //     /// </summary>
    //     public HeaderInfo()
    //     {
    //         // work out the default font name for the user's os.
    //         // this ignores other fonts that may be specified - need 
    //         // to change parser to get font names
    //         if (Environment.OSVersion.Version.Major >= 5)
    //         {
    //             // Win2k, XP, Server 2003
    //             this.titleFont = new Font("Tahoma", 8.25f, FontStyle.Bold);
    //         }
    //         else
    //         {
    //             // Win9x, ME, NT
    //             this.titleFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
    //         }

    //         this.margin = 15;

    //         // set title colors and alignment
    //         this.specialTitle = Color.Transparent;
    //         this.specialTitleHot = Color.Transparent;

    //         this.normalTitle = Color.Transparent;
    //         this.normalTitleHot = Color.Transparent;

    //         this.specialAlignment = System.Drawing.ContentAlignment.MiddleLeft;
    //         this.normalAlignment = System.Drawing.ContentAlignment.MiddleLeft;

    //         // set padding values
    //         this.specialPadding = new Padding(10, 0, 1, 0);
    //         this.normalPadding = new Padding(10, 0, 1, 0);

    //         // set border values
    //         this.specialBorder = new Border(2, 2, 2, 0);
    //         this.specialBorderColor = Color.Transparent;

    //         this.normalBorder = new Border(2, 2, 2, 0);
    //         this.normalBorderColor = Color.Transparent;

    //         this.specialBackColor = Color.Transparent;
    //         this.normalBackColor = Color.Transparent;

    //         // set background image values
    //         this.specialBackImage = null;
    //         this.normalBackImage = null;

    //         this.backImageWidth = -1;
    //         this.backImageHeight = -1;

    //         // set arrow values
    //         this.specialArrowUp = null;
    //         this.specialArrowUpHot = null;
    //         this.specialArrowDown = null;
    //         this.specialArrowDownHot = null;

    //         this.normalArrowUp = null;
    //         this.normalArrowUpHot = null;
    //         this.normalArrowDown = null;
    //         this.normalArrowDownHot = null;

    //         this.useTitleGradient = false;
    //         this.specialGradientStartColor = Color.White;
    //         this.specialGradientEndColor = SystemColors.Highlight;
    //         this.normalGradientStartColor = Color.White;
    //         this.normalGradientEndColor = SystemColors.Highlight;
    //         this.gradientOffset = 0.5f;
    //         this.titleRadius = 5;

    //         this.owner = null;
    //         this.rightToLeft = false;
    //     }

    //     #endregion


    //     #region Methods

    //     /// <summary>
    //     /// Forces the use of default values
    //     /// </summary>
    //     public void SetDefaultValues()
    //     {
    //         // work out the default font name for the user's os
    //         if (Environment.OSVersion.Version.Major >= 5)
    //         {
    //             // Win2k, XP, Server 2003
    //             this.titleFont = new Font("Tahoma", 8.25f, FontStyle.Bold);
    //         }
    //         else
    //         {
    //             // Win9x, ME, NT
    //             this.titleFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
    //         }

    //         this.margin = 15;

    //         // set title colors and alignment
    //         this.specialTitle = SystemColors.HighlightText;
    //         this.specialTitleHot = SystemColors.HighlightText;

    //         this.normalTitle = SystemColors.ControlText;
    //         this.normalTitleHot = SystemColors.ControlText;

    //         this.specialAlignment = System.Drawing.ContentAlignment.MiddleLeft;
    //         this.normalAlignment = System.Drawing.ContentAlignment.MiddleLeft;

    //         // set padding values
    //         this.specialPadding.Left = 10;
    //         this.specialPadding.Top = 0;
    //         this.specialPadding.Right = 1;
    //         this.specialPadding.Bottom = 0;

    //         this.normalPadding.Left = 10;
    //         this.normalPadding.Top = 0;
    //         this.normalPadding.Right = 1;
    //         this.normalPadding.Bottom = 0;

    //         // set border values
    //         this.specialBorder.Left = 2;
    //         this.specialBorder.Top = 2;
    //         this.specialBorder.Right = 2;
    //         this.specialBorder.Bottom = 0;

    //         this.specialBorderColor = SystemColors.Highlight;
    //         this.specialBackColor = SystemColors.Highlight;

    //         this.normalBorder.Left = 2;
    //         this.normalBorder.Top = 2;
    //         this.normalBorder.Right = 2;
    //         this.normalBorder.Bottom = 0;

    //         this.normalBorderColor = SystemColors.Control;
    //         this.normalBackColor = SystemColors.Control;

    //         // set background image values
    //         this.specialBackImage = null;
    //         this.normalBackImage = null;

    //         this.backImageWidth = 186;
    //         this.backImageHeight = 25;

    //         // set arrow values
    //         this.specialArrowUp = null;
    //         this.specialArrowUpHot = null;
    //         this.specialArrowDown = null;
    //         this.specialArrowDownHot = null;

    //         this.normalArrowUp = null;
    //         this.normalArrowUpHot = null;
    //         this.normalArrowDown = null;
    //         this.normalArrowDownHot = null;

    //         this.useTitleGradient = false;
    //         this.specialGradientStartColor = Color.White;
    //         this.specialGradientEndColor = SystemColors.Highlight;
    //         this.normalGradientStartColor = Color.White;
    //         this.normalGradientEndColor = SystemColors.Highlight;
    //         this.gradientOffset = 0.5f;
    //         this.titleRadius = 2;

    //         this.rightToLeft = false;
    //     }


    //     /// <summary>
    //     /// Forces the use of default empty values
    //     /// </summary>
    //     public void SetDefaultEmptyValues()
    //     {
    //         // work out the default font name for the user's os
    //         this.titleFont = null;

    //         this.margin = 15;

    //         // set title colors and alignment
    //         this.specialTitle = Color.Empty;
    //         this.specialTitleHot = Color.Empty;

    //         this.normalTitle = Color.Empty;
    //         this.normalTitleHot = Color.Empty;

    //         this.specialAlignment = System.Drawing.ContentAlignment.MiddleLeft;
    //         this.normalAlignment = System.Drawing.ContentAlignment.MiddleLeft;

    //         // set padding values
    //         this.specialPadding = Padding.Empty;
    //         this.normalPadding = Padding.Empty;

    //         // set border values
    //         this.specialBorder = Border.Empty;
    //         this.specialBorderColor = Color.Empty;
    //         this.specialBackColor = Color.Empty;

    //         this.normalBorder = Border.Empty;
    //         this.normalBorderColor = Color.Empty;
    //         this.normalBackColor = Color.Empty;

    //         // set background image values
    //         this.specialBackImage = null;
    //         this.normalBackImage = null;

    //         this.backImageWidth = 186;
    //         this.backImageHeight = 25;

    //         // set arrow values
    //         this.specialArrowUp = null;
    //         this.specialArrowUpHot = null;
    //         this.specialArrowDown = null;
    //         this.specialArrowDownHot = null;

    //         this.normalArrowUp = null;
    //         this.normalArrowUpHot = null;
    //         this.normalArrowDown = null;
    //         this.normalArrowDownHot = null;

    //         this.useTitleGradient = false;
    //         this.specialGradientStartColor = Color.Empty;
    //         this.specialGradientEndColor = Color.Empty;
    //         this.normalGradientStartColor = Color.Empty;
    //         this.normalGradientEndColor = Color.Empty;
    //         this.gradientOffset = 0.5f;
    //         this.titleRadius = 2;

    //         this.rightToLeft = false;
    //     }


    //     /// <summary>
    //     /// Releases all resources used by the HeaderInfo
    //     /// </summary>
    //     public void Dispose()
    //     {
    //         if (this.specialBackImage != null)
    //         {
    //             this.specialBackImage.Dispose();
    //             this.specialBackImage = null;
    //         }

    //         if (this.normalBackImage != null)
    //         {
    //             this.normalBackImage.Dispose();
    //             this.normalBackImage = null;
    //         }


    //         if (this.specialArrowUp != null)
    //         {
    //             this.specialArrowUp.Dispose();
    //             this.specialArrowUp = null;
    //         }

    //         if (this.specialArrowUpHot != null)
    //         {
    //             this.specialArrowUpHot.Dispose();
    //             this.specialArrowUpHot = null;
    //         }

    //         if (this.specialArrowDown != null)
    //         {
    //             this.specialArrowDown.Dispose();
    //             this.specialArrowDown = null;
    //         }

    //         if (this.specialArrowDownHot != null)
    //         {
    //             this.specialArrowDownHot.Dispose();
    //             this.specialArrowDownHot = null;
    //         }

    //         if (this.normalArrowUp != null)
    //         {
    //             this.normalArrowUp.Dispose();
    //             this.normalArrowUp = null;
    //         }

    //         if (this.normalArrowUpHot != null)
    //         {
    //             this.normalArrowUpHot.Dispose();
    //             this.normalArrowUpHot = null;
    //         }

    //         if (this.normalArrowDown != null)
    //         {
    //             this.normalArrowDown.Dispose();
    //             this.normalArrowDown = null;
    //         }

    //         if (this.normalArrowDownHot != null)
    //         {
    //             this.normalArrowDownHot.Dispose();
    //             this.normalArrowDownHot = null;
    //         }
    //     }

    //     #endregion


    //     #region Properties

    //     #region Border

    //     /// <summary>
    //     /// Gets or sets the border value for a special header
    //     /// </summary>
    //     [Description("The width of the border along each side of a special Expando's Title Bar")]
    //     public Border SpecialBorder
    //     {
    //         get
    //         {
    //             return this.specialBorder;
    //         }

    //         set
    //         {
    //             if (this.specialBorder != value)
    //             {
    //                 this.specialBorder = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the SpecialBorder property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the SpecialBorder property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeSpecialBorder()
    //     {
    //         return this.SpecialBorder != Border.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the border color for a special header
    //     /// </summary>
    //     [Description("The border color for a special Expandos titlebar")]
    //     public Color SpecialBorderColor
    //     {
    //         get
    //         {
    //             return this.specialBorderColor;
    //         }

    //         set
    //         {
    //             if (this.specialBorderColor != value)
    //             {
    //                 this.specialBorderColor = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the SpecialBorderColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the SpecialBorderColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeSpecialBorderColor()
    //     {
    //         return this.SpecialBorderColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the background Color for a special header
    //     /// </summary>
    //     [Description("The background Color for a special Expandos titlebar")]
    //     public Color SpecialBackColor
    //     {
    //         get
    //         {
    //             return this.specialBackColor;
    //         }

    //         set
    //         {
    //             if (this.specialBackColor != value)
    //             {
    //                 this.specialBackColor = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the SpecialBackColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the SpecialBackColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeSpecialBackColor()
    //     {
    //         return this.SpecialBackColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the border value for a normal header
    //     /// </summary>
    //     [Description("The width of the border along each side of a normal Expando's Title Bar")]
    //     public Border NormalBorder
    //     {
    //         get
    //         {
    //             return this.normalBorder;
    //         }

    //         set
    //         {
    //             if (this.normalBorder != value)
    //             {
    //                 this.normalBorder = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the NormalBorder property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the NormalBorder property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeNormalBorder()
    //     {
    //         return this.NormalBorder != Border.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the border color for a normal header
    //     /// </summary>
    //     [Description("The border color for a normal Expandos titlebar")]
    //     public Color NormalBorderColor
    //     {
    //         get
    //         {
    //             return this.normalBorderColor;
    //         }

    //         set
    //         {
    //             if (this.normalBorderColor != value)
    //             {
    //                 this.normalBorderColor = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the NormalBorderColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the NormalBorderColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeNormalBorderColor()
    //     {
    //         return this.NormalBorderColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the background Color for a normal header
    //     /// </summary>
    //     [Description("The background Color for a normal Expandos titlebar")]
    //     public Color NormalBackColor
    //     {
    //         get
    //         {
    //             return this.normalBackColor;
    //         }

    //         set
    //         {
    //             if (this.normalBackColor != value)
    //             {
    //                 this.normalBackColor = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the NormalBackColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the NormalBackColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeNormalBackColor()
    //     {
    //         return this.NormalBackColor != Color.Empty;
    //     }

    //     #endregion

    //     #region Fonts

    //     /// <summary>
    //     /// Gets the Font used to render the header's text
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("The Font used to render the titlebar's text")]
    //     public Font TitleFont
    //     {
    //         get
    //         {
    //             return this.titleFont;
    //         }

    //         set
    //         {
    //             if (this.titleFont != value)
    //             {
    //                 this.titleFont = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the name of the font used to render the header's text. 
    //     /// </summary>
    //     protected internal string FontName
    //     {
    //         get
    //         {
    //             return this.TitleFont.Name;
    //         }

    //         set
    //         {
    //             this.TitleFont = new Font(value, this.TitleFont.SizeInPoints, this.TitleFont.Style);
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the size of the font used to render the header's text. 
    //     /// </summary>
    //     protected internal float FontSize
    //     {
    //         get
    //         {
    //             return this.TitleFont.SizeInPoints;
    //         }

    //         set
    //         {
    //             this.TitleFont = new Font(this.TitleFont.Name, value, this.TitleFont.Style);
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the weight of the font used to render the header's text. 
    //     /// </summary>
    //     protected internal FontStyle FontWeight
    //     {
    //         get
    //         {
    //             return this.TitleFont.Style;
    //         }

    //         set
    //         {
    //             value |= this.TitleFont.Style;

    //             this.TitleFont = new Font(this.TitleFont.Name, this.TitleFont.SizeInPoints, value);
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the style of the Font used to render the header's text. 
    //     /// </summary>
    //     protected internal FontStyle FontStyle
    //     {
    //         get
    //         {
    //             return this.TitleFont.Style;
    //         }

    //         set
    //         {
    //             value |= this.TitleFont.Style;

    //             this.TitleFont = new Font(this.TitleFont.Name, this.TitleFont.SizeInPoints, value);
    //         }
    //     }

    //     #endregion

    //     #region Images

    //     /// <summary>
    //     /// Gets or sets the background image for a special header
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("The background image for a special titlebar")]
    //     public Image SpecialBackImage
    //     {
    //         get
    //         {
    //             return this.specialBackImage;
    //         }

    //         set
    //         {
    //             if (this.specialBackImage != value)
    //             {
    //                 this.specialBackImage = value;

    //                 if (value != null)
    //                 {
    //                     this.backImageWidth = value.Width;
    //                     this.backImageHeight = value.Height;
    //                 }

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the background image for a normal header
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("The background image for a normal titlebar")]
    //     public Image NormalBackImage
    //     {
    //         get
    //         {
    //             return this.normalBackImage;
    //         }

    //         set
    //         {
    //             if (this.normalBackImage != value)
    //             {
    //                 this.normalBackImage = value;

    //                 if (value != null)
    //                 {
    //                     this.backImageWidth = value.Width;
    //                     this.backImageHeight = value.Height;
    //                 }

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the width of the header's background image
    //     /// </summary>
    //     protected internal int BackImageWidth
    //     {
    //         get
    //         {
    //             if (this.backImageWidth == -1)
    //             {
    //                 return 186;
    //             }

    //             return this.backImageWidth;
    //         }

    //         set
    //         {
    //             this.backImageWidth = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the height of the header's background image
    //     /// </summary>
    //     protected internal int BackImageHeight
    //     {
    //         get
    //         {
    //             if (this.backImageHeight < 23)
    //             {
    //                 return 23;
    //             }

    //             return this.backImageHeight;
    //         }

    //         set
    //         {
    //             this.backImageHeight = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets a special header's collapse arrow image in it's normal state
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("A special Expando's collapse arrow image in it's normal state")]
    //     public Image SpecialArrowUp
    //     {
    //         get
    //         {
    //             return this.specialArrowUp;
    //         }

    //         set
    //         {
    //             if (this.specialArrowUp != value)
    //             {
    //                 this.specialArrowUp = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets a special header's collapse arrow image in it's highlighted state
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("A special Expando's collapse arrow image in it's highlighted state")]
    //     public Image SpecialArrowUpHot
    //     {
    //         get
    //         {
    //             return this.specialArrowUpHot;
    //         }

    //         set
    //         {
    //             if (this.specialArrowUpHot != value)
    //             {
    //                 this.specialArrowUpHot = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets a special header's expand arrow image in it's normal state
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("A special Expando's expand arrow image in it's normal state")]
    //     public Image SpecialArrowDown
    //     {
    //         get
    //         {
    //             return this.specialArrowDown;
    //         }

    //         set
    //         {
    //             if (this.specialArrowDown != value)
    //             {
    //                 this.specialArrowDown = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets a special header's expend arrow image in it's highlighted state
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("A special Expando's expand arrow image in it's highlighted state")]
    //     public Image SpecialArrowDownHot
    //     {
    //         get
    //         {
    //             return this.specialArrowDownHot;
    //         }

    //         set
    //         {
    //             if (this.specialArrowDownHot != value)
    //             {
    //                 this.specialArrowDownHot = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets a normal header's collapse arrow image in it's normal state
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("A normal Expando's collapse arrow image in it's normal state")]
    //     public Image NormalArrowUp
    //     {
    //         get
    //         {
    //             return this.normalArrowUp;
    //         }

    //         set
    //         {
    //             if (this.normalArrowUp != value)
    //             {
    //                 this.normalArrowUp = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets a normal header's collapse arrow image in it's highlighted state
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("A normal Expando's collapse arrow image in it's highlighted state")]
    //     public Image NormalArrowUpHot
    //     {
    //         get
    //         {
    //             return this.normalArrowUpHot;
    //         }

    //         set
    //         {
    //             if (this.normalArrowUpHot != value)
    //             {
    //                 this.normalArrowUpHot = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets a normal header's expand arrow image in it's normal state
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("A normal Expando's expand arrow image in it's normal state")]
    //     public Image NormalArrowDown
    //     {
    //         get
    //         {
    //             return this.normalArrowDown;
    //         }

    //         set
    //         {
    //             if (this.normalArrowDown != value)
    //             {
    //                 this.normalArrowDown = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets a normal header's expand arrow image in it's highlighted state
    //     /// </summary>
    //     [DefaultValue(null),
    //     Description("A normal Expando's expand arrow image in it's highlighted state")]
    //     public Image NormalArrowDownHot
    //     {
    //         get
    //         {
    //             return this.normalArrowDownHot;
    //         }

    //         set
    //         {
    //             if (this.normalArrowDownHot != value)
    //             {
    //                 this.normalArrowDownHot = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Sets the arrow images for use when theming is not supported
    //     /// </summary>
    //     internal void SetUnthemedArrowImages()
    //     {
    //         // get the arrow images resource
    //         System.Reflection.Assembly myAssembly;
    //         myAssembly = this.GetType().Assembly;
    //         ResourceManager myManager = new ResourceManager("XPExplorerBar.ExpandoArrows", myAssembly);

    //         // set the arrow images
    //         this.specialArrowDown = new Bitmap((Image)myManager.GetObject("SPECIALGROUPEXPAND"));
    //         this.specialArrowDownHot = new Bitmap((Image)myManager.GetObject("SPECIALGROUPEXPANDHOT"));
    //         this.specialArrowUp = new Bitmap((Image)myManager.GetObject("SPECIALGROUPCOLLAPSE"));
    //         this.specialArrowUpHot = new Bitmap((Image)myManager.GetObject("SPECIALGROUPCOLLAPSEHOT"));

    //         this.normalArrowDown = new Bitmap((Image)myManager.GetObject("NORMALGROUPEXPAND"));
    //         this.normalArrowDownHot = new Bitmap((Image)myManager.GetObject("NORMALGROUPEXPANDHOT"));
    //         this.normalArrowUp = new Bitmap((Image)myManager.GetObject("NORMALGROUPCOLLAPSE"));
    //         this.normalArrowUpHot = new Bitmap((Image)myManager.GetObject("NORMALGROUPCOLLAPSEHOT"));
    //     }

    //     #endregion

    //     #region Margin

    //     /// <summary>
    //     /// Gets or sets the margin around the header
    //     /// </summary>
    //     [DefaultValue(15),
    //     Description("The margin around the titlebar")]
    //     public int Margin
    //     {
    //         get
    //         {
    //             return this.margin;
    //         }

    //         set
    //         {
    //             if (this.margin != value)
    //             {
    //                 this.margin = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }

    //     #endregion

    //     #region Padding

    //     /// <summary>
    //     /// Gets or sets the padding for a special header
    //     /// </summary>
    //     [Description("The amount of space between the border and items along each side of a special Expandos Title Bar")]
    //     public Padding SpecialPadding
    //     {
    //         get
    //         {
    //             return this.specialPadding;
    //         }

    //         set
    //         {
    //             if (this.specialPadding != value)
    //             {
    //                 this.specialPadding = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the SpecialPadding property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the SpecialPadding property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeSpecialPadding()
    //     {
    //         return this.SpecialPadding != Padding.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the padding for a normal header
    //     /// </summary>
    //     [Description("The amount of space between the border and items along each side of a normal Expandos Title Bar")]
    //     public Padding NormalPadding
    //     {
    //         get
    //         {
    //             return this.normalPadding;
    //         }

    //         set
    //         {
    //             if (this.normalPadding != value)
    //             {
    //                 this.normalPadding = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the NormalPadding property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the NormalPadding property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeNormalPadding()
    //     {
    //         return this.NormalPadding != Padding.Empty;
    //     }

    //     #endregion

    //     #region Title

    //     /// <summary>
    //     /// Gets or sets the color of the text displayed in a special 
    //     /// header in it's normal state
    //     /// </summary>
    //     [Description("The color of the text displayed in a special Expandos titlebar in it's normal state")]
    //     public Color SpecialTitleColor
    //     {
    //         get
    //         {
    //             return this.specialTitle;
    //         }

    //         set
    //         {
    //             if (this.specialTitle != value)
    //             {
    //                 this.specialTitle = value;

    //                 // set the SpecialTitleHotColor as well just in case
    //                 // it isn't/wasn't set during UIFILE parsing
    //                 if (this.SpecialTitleHotColor == Color.Transparent)
    //                 {
    //                     this.SpecialTitleHotColor = value;
    //                 }

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the SpecialTitleColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the SpecialTitleColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeSpecialTitleColor()
    //     {
    //         return this.SpecialTitleColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the color of the text displayed in a special 
    //     /// header in it's highlighted state
    //     /// </summary>
    //     [Description("The color of the text displayed in a special Expandos titlebar in it's highlighted state")]
    //     public Color SpecialTitleHotColor
    //     {
    //         get
    //         {
    //             return this.specialTitleHot;
    //         }

    //         set
    //         {
    //             if (this.specialTitleHot != value)
    //             {
    //                 this.specialTitleHot = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the SpecialTitleHotColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the SpecialTitleHotColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeSpecialTitleHotColor()
    //     {
    //         return this.SpecialTitleHotColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the color of the text displayed in a normal 
    //     /// header in it's normal state
    //     /// </summary>
    //     [Description("The color of the text displayed in a normal Expandos titlebar in it's normal state")]
    //     public Color NormalTitleColor
    //     {
    //         get
    //         {
    //             return this.normalTitle;
    //         }

    //         set
    //         {
    //             if (this.normalTitle != value)
    //             {
    //                 this.normalTitle = value;

    //                 // set the NormalTitleHotColor as well just in case
    //                 // it isn't/wasn't set during UIFILE parsing
    //                 if (this.NormalTitleHotColor == Color.Transparent)
    //                 {
    //                     this.NormalTitleHotColor = value;
    //                 }

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the NormalTitleColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the NormalTitleColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeNormalTitleColor()
    //     {
    //         return this.NormalTitleColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the color of the text displayed in a normal 
    //     /// header in it's highlighted state
    //     /// </summary>
    //     [Description("The color of the text displayed in a normal Expandos titlebar in it's highlighted state")]
    //     public Color NormalTitleHotColor
    //     {
    //         get
    //         {
    //             return this.normalTitleHot;
    //         }

    //         set
    //         {
    //             if (this.normalTitleHot != value)
    //             {
    //                 this.normalTitleHot = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the NormalTitleHotColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the NormalTitleHotColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeNormalTitleHotColor()
    //     {
    //         return this.NormalTitleHotColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the alignment of the text displayed in a special header
    //     /// </summary>
    //     [DefaultValue(System.Drawing.ContentAlignment.MiddleLeft),
    //     Description("The alignment of the text displayed in a special Expandos titlebar")]
    //     public System.Drawing.ContentAlignment SpecialAlignment
    //     {
    //         get
    //         {
    //             return this.specialAlignment;
    //         }

    //         set
    //         {
    //             if (!Enum.IsDefined(typeof(System.Drawing.ContentAlignment), value))
    //             {
    //                 throw new InvalidEnumArgumentException("value", (int)value, typeof(System.Drawing.ContentAlignment));
    //             }

    //             if (this.specialAlignment != value)
    //             {
    //                 this.specialAlignment = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the alignment of the text displayed in a normal header
    //     /// </summary>
    //     [DefaultValue(System.Drawing.ContentAlignment.MiddleLeft),
    //     Description("The alignment of the text displayed in a normal Expandos titlebar")]
    //     public System.Drawing.ContentAlignment NormalAlignment
    //     {
    //         get
    //         {
    //             return this.normalAlignment;
    //         }

    //         set
    //         {
    //             if (!Enum.IsDefined(typeof(System.Drawing.ContentAlignment), value))
    //             {
    //                 throw new InvalidEnumArgumentException("value", (int)value, typeof(System.Drawing.ContentAlignment));
    //             }

    //             if (this.normalAlignment != value)
    //             {
    //                 this.normalAlignment = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets whether the header's background should use a gradient fill
    //     /// </summary>
    //     [DefaultValue(false),
    //     Description("")]
    //     public bool TitleGradient
    //     {
    //         get
    //         {
    //             return this.useTitleGradient;
    //         }

    //         set
    //         {
    //             if (this.useTitleGradient != value)
    //             {
    //                 this.useTitleGradient = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the start Color of a header's gradient fill for a special 
    //     /// Expando
    //     /// </summary>
    //     [Description("")]
    //     public Color SpecialGradientStartColor
    //     {
    //         get
    //         {
    //             return this.specialGradientStartColor;
    //         }

    //         set
    //         {
    //             if (this.specialGradientStartColor != value)
    //             {
    //                 this.specialGradientStartColor = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the SpecialGradientStartColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the SpecialGradientStartColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeSpecialGradientStartColor()
    //     {
    //         return this.SpecialGradientStartColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the end Color of a header's gradient fill for a special 
    //     /// Expando
    //     /// </summary>
    //     [Description("")]
    //     public Color SpecialGradientEndColor
    //     {
    //         get
    //         {
    //             return this.specialGradientEndColor;
    //         }

    //         set
    //         {
    //             if (this.specialGradientEndColor != value)
    //             {
    //                 this.specialGradientEndColor = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the SpecialGradientEndColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the SpecialGradientEndColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeSpecialGradientEndColor()
    //     {
    //         return this.SpecialGradientEndColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the start Color of a header's gradient fill for a normal 
    //     /// Expando
    //     /// </summary>
    //     [Description("")]
    //     public Color NormalGradientStartColor
    //     {
    //         get
    //         {
    //             return this.normalGradientStartColor;
    //         }

    //         set
    //         {
    //             if (this.normalGradientStartColor != value)
    //             {
    //                 this.normalGradientStartColor = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the NormalGradientStartColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the NormalGradientStartColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeNormalGradientStartColor()
    //     {
    //         return this.NormalGradientStartColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets the end Color of a header's gradient fill for a normal 
    //     /// Expando
    //     /// </summary>
    //     [Description("")]
    //     public Color NormalGradientEndColor
    //     {
    //         get
    //         {
    //             return this.normalGradientEndColor;
    //         }

    //         set
    //         {
    //             if (this.normalGradientEndColor != value)
    //             {
    //                 this.normalGradientEndColor = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Specifies whether the NormalGradientEndColor property should be 
    //     /// serialized at design time
    //     /// </summary>
    //     /// <returns>true if the NormalGradientEndColor property should be 
    //     /// serialized, false otherwise</returns>
    //     private bool ShouldSerializeNormalGradientEndColor()
    //     {
    //         return this.NormalGradientEndColor != Color.Empty;
    //     }


    //     /// <summary>
    //     /// Gets or sets how far along the header the gradient starts
    //     /// </summary>
    //     [DefaultValue(0.5f),
    //     Description("")]
    //     public float GradientOffset
    //     {
    //         get
    //         {
    //             return this.gradientOffset;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0f;
    //             }
    //             else if (value > 1)
    //             {
    //                 value = 1f;
    //             }

    //             if (this.gradientOffset != value)
    //             {
    //                 this.gradientOffset = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     ///Gets or sets the radius of the corners on the header
    //     /// </summary>
    //     [DefaultValue(2),
    //     Description("")]
    //     public int TitleRadius
    //     {
    //         get
    //         {
    //             return this.titleRadius;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0;
    //             }
    //             else if (value > this.BackImageHeight)
    //             {
    //                 value = this.BackImageHeight;
    //             }

    //             if (this.titleRadius != value)
    //             {
    //                 this.titleRadius = value;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.FireCustomSettingsChanged(EventArgs.Empty);
    //                 }
    //             }
    //         }
    //     }

    //     #endregion

    //     #region Expando

    //     /// <summary>
    //     /// Gets or sets the Expando the HeaderInfo belongs to
    //     /// </summary>
    //     protected internal Expando Expando
    //     {
    //         get
    //         {
    //             return this.owner;
    //         }

    //         set
    //         {
    //             this.owner = value;
    //         }
    //     }


    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     internal bool RightToLeft
    //     {
    //         get
    //         {
    //             return this.rightToLeft;
    //         }

    //         set
    //         {
    //             this.rightToLeft = value;
    //         }
    //     }

    //     #endregion

    //     #endregion


    //     #region HeaderInfoSurrogate

    //     /// <summary>
    //     /// A class that is serialized instead of a HeaderInfo (as 
    //     /// HeaderInfos contain objects that cause serialization problems)
    //     /// </summary>
    //     [Serializable()]
    //     public class HeaderInfoSurrogate : ISerializable
    //     {
    //         #region Class Data

    //         /// <summary>
    //         /// See Font.Name.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public string FontName;

    //         /// <summary>
    //         /// See Font.Size.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public float FontSize;

    //         /// <summary>
    //         /// See Font.Style.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public FontStyle FontStyle;

    //         /// <summary>
    //         /// See HeaderInfo.Margin.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public int Margin;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialBackImage.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("SpecialBackImage", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] SpecialBackImage;

    //         /// <summary>
    //         /// See HeaderInfo.NormalBackImage.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("NormalBackImage", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] NormalBackImage;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialTitle.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string SpecialTitle;

    //         /// <summary>
    //         /// See HeaderInfo.NormalTitle.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string NormalTitle;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialTitleHot.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string SpecialTitleHot;

    //         /// <summary>
    //         /// See HeaderInfo.NormalTitleHot.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string NormalTitleHot;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialAlignment.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public System.Drawing.ContentAlignment SpecialAlignment;

    //         /// <summary>
    //         /// See HeaderInfo.NormalAlignment.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public System.Drawing.ContentAlignment NormalAlignment;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialPadding.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public Padding SpecialPadding;

    //         /// <summary>
    //         /// See HeaderInfo.NormalPadding.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public Padding NormalPadding;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialBorder.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public Border SpecialBorder;

    //         /// <summary>
    //         /// See HeaderInfo.NormalBorder.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public Border NormalBorder;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialBorderColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string SpecialBorderColor;

    //         /// <summary>
    //         /// See HeaderInfo.NormalBorderColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string NormalBorderColor;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialBackColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string SpecialBackColor;

    //         /// <summary>
    //         /// See HeaderInfo.NormalBackColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string NormalBackColor;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialArrowUp.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("SpecialArrowUp", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] SpecialArrowUp;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialArrowUpHot.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("SpecialArrowUpHot", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] SpecialArrowUpHot;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialArrowDown.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("SpecialArrowDown", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] SpecialArrowDown;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialArrowDownHot.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("SpecialArrowDownHot", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] SpecialArrowDownHot;

    //         /// <summary>
    //         /// See HeaderInfo.NormalArrowUp.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("NormalArrowUp", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] NormalArrowUp;

    //         /// <summary>
    //         /// See HeaderInfo.NormalArrowUpHot.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("NormalArrowUpHot", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] NormalArrowUpHot;

    //         /// <summary>
    //         /// See HeaderInfo.NormalArrowDown.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("NormalArrowDown", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] NormalArrowDown;

    //         /// <summary>
    //         /// See HeaderInfo.NormalArrowDownHot.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("NormalArrowDownHot", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] NormalArrowDownHot;

    //         /// <summary>
    //         /// See HeaderInfo.TitleGradient.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public bool TitleGradient;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialGradientStartColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string SpecialGradientStartColor;

    //         /// <summary>
    //         /// See HeaderInfo.SpecialGradientEndColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string SpecialGradientEndColor;

    //         /// <summary>
    //         /// See HeaderInfo.NormalGradientStartColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string NormalGradientStartColor;

    //         /// <summary>
    //         /// See HeaderInfo.NormalGradientEndColor.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public string NormalGradientEndColor;

    //         /// <summary>
    //         /// See HeaderInfo.GradientOffset.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public float GradientOffset;

    //         /// <summary>
    //         /// See HeaderInfo.TitleRadius.  This member is not 
    //         /// intended to be used directly from your code.
    //         /// </summary>
    //         public int TitleRadius;

    //         /// <summary>
    //         /// Version number of the surrogate.  This member is not intended 
    //         /// to be used directly from your code.
    //         /// </summary>
    //         public int Version = 3300;

    //         #endregion


    //         #region Constructor

    //         /// <summary>
    //         /// Initializes a new instance of the HeaderInfoSurrogate class with default settings
    //         /// </summary>
    //         public HeaderInfoSurrogate()
    //         {
    //             this.FontName = null;
    //             this.FontSize = 8.25f;
    //             this.FontStyle = FontStyle.Regular;
    //             this.Margin = 15;

    //             this.SpecialBackImage = new byte[0];
    //             this.NormalBackImage = new byte[0];

    //             this.SpecialTitle = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.NormalTitle = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.SpecialTitleHot = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.NormalTitleHot = ThemeManager.ConvertColorToString(Color.Empty);

    //             this.SpecialAlignment = System.Drawing.ContentAlignment.MiddleLeft;
    //             this.NormalAlignment = System.Drawing.ContentAlignment.MiddleLeft;

    //             this.SpecialPadding = Padding.Empty;
    //             this.NormalPadding = Padding.Empty;

    //             this.SpecialBorder = Border.Empty;
    //             this.NormalBorder = Border.Empty;
    //             this.SpecialBorderColor = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.NormalBorderColor = ThemeManager.ConvertColorToString(Color.Empty);

    //             this.SpecialBackColor = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.NormalBackColor = ThemeManager.ConvertColorToString(Color.Empty);

    //             this.SpecialArrowUp = new byte[0];
    //             this.SpecialArrowUpHot = new byte[0];
    //             this.SpecialArrowDown = new byte[0];
    //             this.SpecialArrowDownHot = new byte[0];
    //             this.NormalArrowUp = new byte[0];
    //             this.NormalArrowUpHot = new byte[0];
    //             this.NormalArrowDown = new byte[0];
    //             this.NormalArrowDownHot = new byte[0];

    //             this.TitleGradient = false;
    //             this.SpecialGradientStartColor = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.SpecialGradientEndColor = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.NormalGradientStartColor = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.NormalGradientEndColor = ThemeManager.ConvertColorToString(Color.Empty);
    //             this.GradientOffset = 0.5f;
    //         }

    //         #endregion


    //         #region Methods

    //         /// <summary>
    //         /// Populates the HeaderInfoSurrogate with data that is to be 
    //         /// serialized from the specified HeaderInfo
    //         /// </summary>
    //         /// <param name="headerInfo">The HeaderInfo that contains the data 
    //         /// to be serialized</param>
    //         public void Load(HeaderInfo headerInfo)
    //         {
    //             if (headerInfo.TitleFont != null)
    //             {
    //                 this.FontName = headerInfo.TitleFont.Name;
    //                 this.FontSize = headerInfo.TitleFont.SizeInPoints;
    //                 this.FontStyle = headerInfo.TitleFont.Style;
    //             }

    //             this.Margin = headerInfo.Margin;

    //             this.SpecialBackImage = ThemeManager.ConvertImageToByteArray(headerInfo.SpecialBackImage);
    //             this.NormalBackImage = ThemeManager.ConvertImageToByteArray(headerInfo.NormalBackImage);

    //             this.SpecialTitle = ThemeManager.ConvertColorToString(headerInfo.SpecialTitleColor);
    //             this.NormalTitle = ThemeManager.ConvertColorToString(headerInfo.NormalTitleColor);
    //             this.SpecialTitleHot = ThemeManager.ConvertColorToString(headerInfo.SpecialTitleHotColor);
    //             this.NormalTitleHot = ThemeManager.ConvertColorToString(headerInfo.NormalTitleHotColor);

    //             this.SpecialAlignment = headerInfo.SpecialAlignment;
    //             this.NormalAlignment = headerInfo.NormalAlignment;

    //             this.SpecialPadding = headerInfo.SpecialPadding;
    //             this.NormalPadding = headerInfo.NormalPadding;

    //             this.SpecialBorder = headerInfo.SpecialBorder;
    //             this.NormalBorder = headerInfo.NormalBorder;
    //             this.SpecialBorderColor = ThemeManager.ConvertColorToString(headerInfo.SpecialBorderColor);
    //             this.NormalBorderColor = ThemeManager.ConvertColorToString(headerInfo.NormalBorderColor);

    //             this.SpecialBackColor = ThemeManager.ConvertColorToString(headerInfo.SpecialBackColor);
    //             this.NormalBackColor = ThemeManager.ConvertColorToString(headerInfo.NormalBackColor);

    //             this.SpecialArrowUp = ThemeManager.ConvertImageToByteArray(headerInfo.SpecialArrowUp);
    //             this.SpecialArrowUpHot = ThemeManager.ConvertImageToByteArray(headerInfo.SpecialArrowUpHot);
    //             this.SpecialArrowDown = ThemeManager.ConvertImageToByteArray(headerInfo.SpecialArrowDown);
    //             this.SpecialArrowDownHot = ThemeManager.ConvertImageToByteArray(headerInfo.SpecialArrowDownHot);
    //             this.NormalArrowUp = ThemeManager.ConvertImageToByteArray(headerInfo.NormalArrowUp);
    //             this.NormalArrowUpHot = ThemeManager.ConvertImageToByteArray(headerInfo.NormalArrowUpHot);
    //             this.NormalArrowDown = ThemeManager.ConvertImageToByteArray(headerInfo.NormalArrowDown);
    //             this.NormalArrowDownHot = ThemeManager.ConvertImageToByteArray(headerInfo.NormalArrowDownHot);

    //             this.TitleGradient = headerInfo.TitleGradient;
    //             this.SpecialGradientStartColor = ThemeManager.ConvertColorToString(headerInfo.SpecialGradientStartColor);
    //             this.SpecialGradientEndColor = ThemeManager.ConvertColorToString(headerInfo.SpecialGradientEndColor);
    //             this.NormalGradientStartColor = ThemeManager.ConvertColorToString(headerInfo.NormalGradientStartColor);
    //             this.NormalGradientEndColor = ThemeManager.ConvertColorToString(headerInfo.NormalGradientEndColor);
    //             this.GradientOffset = headerInfo.GradientOffset;
    //         }


    //         /// <summary>
    //         /// Returns a HeaderInfo that contains the deserialized HeaderInfoSurrogate data
    //         /// </summary>
    //         /// <returns>A HeaderInfo that contains the deserialized HeaderInfoSurrogate data</returns>
    //         public HeaderInfo Save()
    //         {
    //             HeaderInfo headerInfo = new HeaderInfo();

    //             if (this.FontName != null)
    //             {
    //                 headerInfo.TitleFont = new Font(this.FontName, this.FontSize, this.FontStyle);
    //             }

    //             headerInfo.Margin = this.Margin;

    //             headerInfo.SpecialBackImage = ThemeManager.ConvertByteArrayToImage(this.SpecialBackImage);
    //             headerInfo.NormalBackImage = ThemeManager.ConvertByteArrayToImage(this.NormalBackImage);

    //             headerInfo.SpecialTitleColor = ThemeManager.ConvertStringToColor(this.SpecialTitle);
    //             headerInfo.NormalTitleColor = ThemeManager.ConvertStringToColor(this.NormalTitle);
    //             headerInfo.SpecialTitleHotColor = ThemeManager.ConvertStringToColor(this.SpecialTitleHot);
    //             headerInfo.NormalTitleHotColor = ThemeManager.ConvertStringToColor(this.NormalTitleHot);

    //             headerInfo.SpecialAlignment = this.SpecialAlignment;
    //             headerInfo.NormalAlignment = this.NormalAlignment;

    //             headerInfo.SpecialPadding = this.SpecialPadding;
    //             headerInfo.NormalPadding = this.NormalPadding;

    //             headerInfo.SpecialBorder = this.SpecialBorder;
    //             headerInfo.NormalBorder = this.NormalBorder;
    //             headerInfo.SpecialBorderColor = ThemeManager.ConvertStringToColor(this.SpecialBorderColor);
    //             headerInfo.NormalBorderColor = ThemeManager.ConvertStringToColor(this.NormalBorderColor);

    //             headerInfo.SpecialBackColor = ThemeManager.ConvertStringToColor(this.SpecialBackColor);
    //             headerInfo.NormalBackColor = ThemeManager.ConvertStringToColor(this.NormalBackColor);

    //             headerInfo.SpecialArrowUp = ThemeManager.ConvertByteArrayToImage(this.SpecialArrowUp);
    //             headerInfo.SpecialArrowUpHot = ThemeManager.ConvertByteArrayToImage(this.SpecialArrowUpHot);
    //             headerInfo.SpecialArrowDown = ThemeManager.ConvertByteArrayToImage(this.SpecialArrowDown);
    //             headerInfo.SpecialArrowDownHot = ThemeManager.ConvertByteArrayToImage(this.SpecialArrowDownHot);
    //             headerInfo.NormalArrowUp = ThemeManager.ConvertByteArrayToImage(this.NormalArrowUp);
    //             headerInfo.NormalArrowUpHot = ThemeManager.ConvertByteArrayToImage(this.NormalArrowUpHot);
    //             headerInfo.NormalArrowDown = ThemeManager.ConvertByteArrayToImage(this.NormalArrowDown);
    //             headerInfo.NormalArrowDownHot = ThemeManager.ConvertByteArrayToImage(this.NormalArrowDownHot);

    //             headerInfo.TitleGradient = this.TitleGradient;
    //             headerInfo.SpecialGradientStartColor = ThemeManager.ConvertStringToColor(this.SpecialGradientStartColor);
    //             headerInfo.SpecialGradientEndColor = ThemeManager.ConvertStringToColor(this.SpecialGradientEndColor);
    //             headerInfo.NormalGradientStartColor = ThemeManager.ConvertStringToColor(this.NormalGradientStartColor);
    //             headerInfo.NormalGradientEndColor = ThemeManager.ConvertStringToColor(this.NormalGradientEndColor);
    //             headerInfo.GradientOffset = this.GradientOffset;

    //             return headerInfo;
    //         }


    //         /// <summary>
    //         /// Populates a SerializationInfo with the data needed to serialize the HeaderInfoSurrogate
    //         /// </summary>
    //         /// <param name="info">The SerializationInfo to populate with data</param>
    //         /// <param name="context">The destination for this serialization</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         public void GetObjectData(SerializationInfo info, StreamingContext context)
    //         {
    //             info.AddValue("Version", this.Version);

    //             info.AddValue("FontName", this.FontName);
    //             info.AddValue("FontSize", this.FontSize);
    //             info.AddValue("FontStyle", this.FontStyle);

    //             info.AddValue("Margin", this.Margin);

    //             info.AddValue("SpecialBackImage", this.SpecialBackImage);
    //             info.AddValue("NormalBackImage", this.NormalBackImage);

    //             info.AddValue("SpecialTitle", this.SpecialTitle);
    //             info.AddValue("NormalTitle", this.NormalTitle);
    //             info.AddValue("SpecialTitleHot", this.SpecialTitleHot);
    //             info.AddValue("NormalTitleHot", this.NormalTitleHot);

    //             info.AddValue("SpecialAlignment", this.SpecialAlignment);
    //             info.AddValue("NormalAlignment", this.NormalAlignment);

    //             info.AddValue("SpecialPadding", this.SpecialPadding);
    //             info.AddValue("NormalPadding", this.NormalPadding);

    //             info.AddValue("SpecialBorder", this.SpecialBorder);
    //             info.AddValue("NormalBorder", this.NormalBorder);
    //             info.AddValue("SpecialBorderColor", this.SpecialBorderColor);
    //             info.AddValue("NormalBorderColor", this.NormalBorderColor);

    //             info.AddValue("SpecialBackColor", this.SpecialBackColor);
    //             info.AddValue("NormalBackColor", this.NormalBackColor);

    //             info.AddValue("SpecialArrowUp", this.SpecialArrowUp);
    //             info.AddValue("SpecialArrowUpHot", this.SpecialArrowUpHot);
    //             info.AddValue("SpecialArrowDown", this.SpecialArrowDown);
    //             info.AddValue("SpecialArrowDownHot", this.SpecialArrowDownHot);
    //             info.AddValue("NormalArrowUp", this.NormalArrowUp);
    //             info.AddValue("NormalArrowUpHot", this.NormalArrowUpHot);
    //             info.AddValue("NormalArrowDown", this.NormalArrowDown);
    //             info.AddValue("NormalArrowDownHot", this.NormalArrowDownHot);

    //             info.AddValue("TitleGradient", this.TitleGradient);
    //             info.AddValue("SpecialGradientStartColor", this.SpecialGradientStartColor);
    //             info.AddValue("SpecialGradientEndColor", this.SpecialGradientEndColor);
    //             info.AddValue("NormalGradientStartColor", this.NormalGradientStartColor);
    //             info.AddValue("NormalGradientEndColor", this.NormalGradientEndColor);
    //             info.AddValue("GradientOffset", this.GradientOffset);
    //         }


    //         /// <summary>
    //         /// Initializes a new instance of the HeaderInfoSurrogate class using the information 
    //         /// in the SerializationInfo
    //         /// </summary>
    //         /// <param name="info">The information to populate the HeaderInfoSurrogate</param>
    //         /// <param name="context">The source from which the HeaderInfoSurrogate is deserialized</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         protected HeaderInfoSurrogate(SerializationInfo info, StreamingContext context) : base()
    //         {
    //             int version = info.GetInt32("Version");

    //             this.FontName = info.GetString("FontName");
    //             this.FontSize = info.GetSingle("FontSize");
    //             this.FontStyle = (FontStyle)info.GetValue("FontStyle", typeof(FontStyle));

    //             this.Margin = info.GetInt32("Margin");

    //             this.SpecialBackImage = (byte[])info.GetValue("SpecialBackImage", typeof(byte[]));
    //             this.NormalBackImage = (byte[])info.GetValue("NormalBackImage", typeof(byte[]));

    //             this.SpecialTitle = info.GetString("SpecialTitle");
    //             this.NormalTitle = info.GetString("NormalTitle");
    //             this.SpecialTitleHot = info.GetString("SpecialTitleHot");
    //             this.NormalTitleHot = info.GetString("NormalTitleHot");

    //             this.SpecialAlignment = (System.Drawing.ContentAlignment)info.GetValue("SpecialAlignment", typeof(System.Drawing.ContentAlignment));
    //             this.NormalAlignment = (System.Drawing.ContentAlignment)info.GetValue("NormalAlignment", typeof(System.Drawing.ContentAlignment));

    //             this.SpecialPadding = (Padding)info.GetValue("SpecialPadding", typeof(Padding));
    //             this.NormalPadding = (Padding)info.GetValue("NormalPadding", typeof(Padding));

    //             this.SpecialBorder = (Border)info.GetValue("SpecialBorder", typeof(Border));
    //             this.NormalBorder = (Border)info.GetValue("NormalBorder", typeof(Border));
    //             this.SpecialBorderColor = info.GetString("SpecialBorderColor");
    //             this.NormalBorderColor = info.GetString("NormalBorderColor");

    //             this.SpecialBackColor = info.GetString("SpecialBackColor");
    //             this.NormalBackColor = info.GetString("NormalBackColor");

    //             this.SpecialArrowUp = (byte[])info.GetValue("SpecialArrowUp", typeof(byte[]));
    //             this.SpecialArrowUpHot = (byte[])info.GetValue("SpecialArrowUpHot", typeof(byte[]));
    //             this.SpecialArrowDown = (byte[])info.GetValue("SpecialArrowDown", typeof(byte[]));
    //             this.SpecialArrowDownHot = (byte[])info.GetValue("SpecialArrowDownHot", typeof(byte[]));
    //             this.NormalArrowUp = (byte[])info.GetValue("NormalArrowUp", typeof(byte[]));
    //             this.NormalArrowUpHot = (byte[])info.GetValue("NormalArrowUpHot", typeof(byte[]));
    //             this.NormalArrowDown = (byte[])info.GetValue("NormalArrowDown", typeof(byte[]));
    //             this.NormalArrowDownHot = (byte[])info.GetValue("NormalArrowDownHot", typeof(byte[]));

    //             this.TitleGradient = info.GetBoolean("TitleGradient");
    //             this.SpecialGradientStartColor = info.GetString("SpecialGradientStartColor");
    //             this.SpecialGradientEndColor = info.GetString("SpecialGradientEndColor");
    //             this.NormalGradientStartColor = info.GetString("NormalGradientStartColor");
    //             this.NormalGradientEndColor = info.GetString("NormalGradientEndColor");
    //             this.GradientOffset = info.GetSingle("GradientOffset");
    //         }

    //         #endregion
    //     }

    //     #endregion
    // }


    // #region HeaderInfoConverter

    // /// <summary>
    // /// A custom TypeConverter used to help convert HeaderInfos from 
    // /// one Type to another
    // /// </summary>
    // internal class HeaderInfoConverter : ExpandableObjectConverter
    // {
    //     /// <summary>
    //     /// Converts the given value object to the specified type, using 
    //     /// the specified context and culture information
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides 
    //     /// a format context</param>
    //     /// <param name="culture">A CultureInfo object. If a null reference 
    //     /// is passed, the current culture is assumed</param>
    //     /// <param name="value">The Object to convert</param>
    //     /// <param name="destinationType">The Type to convert the value 
    //     /// parameter to</param>
    //     /// <returns>An Object that represents the converted value</returns>
    //     public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    //     {
    //         if (destinationType == typeof(string) && value is HeaderInfo)
    //         {
    //             return "";
    //         }

    //         return base.ConvertTo(context, culture, value, destinationType);
    //     }


    //     /// <summary>
    //     /// Returns a collection of properties for the type of array specified 
    //     /// by the value parameter, using the specified context and attributes
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a format 
    //     /// context</param>
    //     /// <param name="value">An Object that specifies the type of array for 
    //     /// which to get properties</param>
    //     /// <param name="attributes">An array of type Attribute that is used as 
    //     /// a filter</param>
    //     /// <returns>A PropertyDescriptorCollection with the properties that are 
    //     /// exposed for this data type, or a null reference if there are no 
    //     /// properties</returns>
    //     public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    //     {
    //         // set the order in which the properties appear 
    //         // in the property window

    //         PropertyDescriptorCollection collection = TypeDescriptor.GetProperties(typeof(HeaderInfo), attributes);

    //         string[] s = new string[33];
    //         s[0] = "TitleFont";
    //         s[1] = "TitleGradient";
    //         s[2] = "NormalGradientStartColor";
    //         s[3] = "NormalGradientEndColor";
    //         s[4] = "SpecialGradientStartColor";
    //         s[5] = "SpecialGradientEndColor";
    //         s[6] = "GradientOffset";
    //         s[7] = "TitleRadius";
    //         s[8] = "NormalBackImage";
    //         s[9] = "SpecialBackImage";
    //         s[10] = "NormalArrowUp";
    //         s[11] = "NormalArrowUpHot";
    //         s[12] = "NormalArrowDown";
    //         s[13] = "NormalArrowDownHot";
    //         s[14] = "SpecialArrowUp";
    //         s[15] = "SpecialArrowUpHot";
    //         s[16] = "SpecialArrowDown";
    //         s[17] = "SpecialArrowDownHot";
    //         s[18] = "NormalAlignment";
    //         s[19] = "SpecialAlignment";
    //         s[20] = "NormalBackColor";
    //         s[21] = "SpecialBackColor";
    //         s[22] = "NormalBorder";
    //         s[23] = "SpecialBorder";
    //         s[24] = "NormalBorderColor";
    //         s[25] = "SpecialBorderColor";
    //         s[26] = "NormalPadding";
    //         s[27] = "SpecialPadding";
    //         s[28] = "NormalTitleColor";
    //         s[29] = "NormalTitleHotColor";
    //         s[30] = "SpecialTitleColor";
    //         s[31] = "SpecialTitleHotColor";
    //         s[32] = "Margin";

    //         return collection.Sort(s);
    //     }
    // }

    // #endregion

    // #endregion


    // #region Border Class

    // /// <summary>
    // /// Specifies the width of the border along each edge of an object
    // /// </summary>
    // [Serializable(),
    // TypeConverter(typeof(BorderConverter))]
    // public class Border
    // {
    //     #region Class Data

    //     /// <summary>
    //     /// Represents a Border structure with its properties 
    //     /// left uninitialized
    //     /// </summary>
    //     [NonSerialized()]
    //     public static readonly Border Empty = new Border(0, 0, 0, 0);

    //     /// <summary>
    //     /// The width of the left border
    //     /// </summary>
    //     private int left;

    //     /// <summary>
    //     /// The width of the right border
    //     /// </summary>
    //     private int right;

    //     /// <summary>
    //     /// The width of the top border
    //     /// </summary>
    //     private int top;

    //     /// <summary>
    //     /// The width of the bottom border
    //     /// </summary>
    //     private int bottom;

    //     #endregion


    //     #region Constructor

    //     /// <summary>
    //     /// Initializes a new instance of the Border class with default settings
    //     /// </summary>
    //     public Border() : this(0, 0, 0, 0)
    //     {

    //     }


    //     /// <summary>
    //     /// Initializes a new instance of the Border class
    //     /// </summary>
    //     /// <param name="left">The width of the left border</param>
    //     /// <param name="top">The Height of the top border</param>
    //     /// <param name="right">The width of the right border</param>
    //     /// <param name="bottom">The Height of the bottom border</param>
    //     public Border(int left, int top, int right, int bottom)
    //     {
    //         this.left = left;
    //         this.right = right;
    //         this.top = top;
    //         this.bottom = bottom;
    //     }

    //     #endregion


    //     #region Methods

    //     /// <summary>
    //     /// Tests whether obj is a Border structure with the same values as 
    //     /// this Border structure
    //     /// </summary>
    //     /// <param name="obj">The Object to test</param>
    //     /// <returns>This method returns true if obj is a Border structure 
    //     /// and its Left, Top, Right, and Bottom properties are equal to 
    //     /// the corresponding properties of this Border structure; 
    //     /// otherwise, false</returns>
    //     public override bool Equals(object obj)
    //     {
    //         if (!(obj is Border))
    //         {
    //             return false;
    //         }

    //         Border border = (Border)obj;

    //         if (((border.Left == this.Left) && (border.Top == this.Top)) && (border.Right == this.Right))
    //         {
    //             return (border.Bottom == this.Bottom);
    //         }

    //         return false;
    //     }


    //     /// <summary>
    //     /// Returns the hash code for this Border structure
    //     /// </summary>
    //     /// <returns>An integer that represents the hashcode for this 
    //     /// border</returns>
    //     public override int GetHashCode()
    //     {
    //         return (((this.Left ^ ((this.Top << 13) | (this.Top >> 0x13))) ^ ((this.Right << 0x1a) | (this.Right >> 6))) ^ ((this.Bottom << 7) | (this.Bottom >> 0x19)));
    //     }

    //     #endregion


    //     #region Properties

    //     /// <summary>
    //     /// Gets or sets the value of the left border
    //     /// </summary>
    //     public int Left
    //     {
    //         get
    //         {
    //             return this.left;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0;
    //             }

    //             this.left = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the value of the right border
    //     /// </summary>
    //     public int Right
    //     {
    //         get
    //         {
    //             return this.right;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0;
    //             }

    //             this.right = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the value of the top border
    //     /// </summary>
    //     public int Top
    //     {
    //         get
    //         {
    //             return this.top;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0;
    //             }

    //             this.top = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the value of the bottom border
    //     /// </summary>
    //     public int Bottom
    //     {
    //         get
    //         {
    //             return this.bottom;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0;
    //             }

    //             this.bottom = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Tests whether all numeric properties of this Border have 
    //     /// values of zero
    //     /// </summary>
    //     [Browsable(false)]
    //     public bool IsEmpty
    //     {
    //         get
    //         {
    //             if (((this.Left == 0) && (this.Top == 0)) && (this.Right == 0))
    //             {
    //                 return (this.Bottom == 0);
    //             }

    //             return false;
    //         }
    //     }

    //     #endregion


    //     #region Operators

    //     /// <summary>
    //     /// Tests whether two Border structures have equal Left, Top, 
    //     /// Right, and Bottom properties
    //     /// </summary>
    //     /// <param name="left">The Border structure that is to the left 
    //     /// of the equality operator</param>
    //     /// <param name="right">The Border structure that is to the right 
    //     /// of the equality operator</param>
    //     /// <returns>This operator returns true if the two Border structures 
    //     /// have equal Left, Top, Right, and Bottom properties</returns>
    //     public static bool operator ==(Border left, Border right)
    //     {
    //         if (((left.Left == right.Left) && (left.Top == right.Top)) && (left.Right == right.Right))
    //         {
    //             return (left.Bottom == right.Bottom);
    //         }

    //         return false;
    //     }


    //     /// <summary>
    //     /// Tests whether two Border structures differ in their Left, Top, 
    //     /// Right, and Bottom properties
    //     /// </summary>
    //     /// <param name="left">The Border structure that is to the left 
    //     /// of the equality operator</param>
    //     /// <param name="right">The Border structure that is to the right 
    //     /// of the equality operator</param>
    //     /// <returns>This operator returns true if any of the Left, Top, Right, 
    //     /// and Bottom properties of the two Border structures are unequal; 
    //     /// otherwise false</returns>
    //     public static bool operator !=(Border left, Border right)
    //     {
    //         return !(left == right);
    //     }

    //     #endregion
    // }


    // #region BorderConverter

    // /// <summary>
    // /// A custom TypeConverter used to help convert Borders from 
    // /// one Type to another
    // /// </summary>
    // internal class BorderConverter : TypeConverter
    // {
    //     /// <summary>
    //     /// Returns whether this converter can convert the object to the 
    //     /// specified type, using the specified context
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides 
    //     /// a format context</param>
    //     /// <param name="sourceType">A Type that represents the type you 
    //     /// want to convert from</param>
    //     /// <returns>true if this converter can perform the conversion; 
    //     /// otherwise, false</returns>
    //     public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    //     {
    //         if (sourceType == typeof(string))
    //         {
    //             return true;
    //         }

    //         return base.CanConvertFrom(context, sourceType);
    //     }


    //     /// <summary>
    //     /// Returns whether this converter can convert the object to the 
    //     /// specified type, using the specified context
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a 
    //     /// format context</param>
    //     /// <param name="destinationType">A Type that represents the type you 
    //     /// want to convert to</param>
    //     /// <returns>true if this converter can perform the conversion; 
    //     /// otherwise, false</returns>
    //     public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    //     {
    //         if (destinationType == typeof(InstanceDescriptor))
    //         {
    //             return true;
    //         }

    //         return base.CanConvertTo(context, destinationType);
    //     }


    //     /// <summary>
    //     /// Converts the given object to the type of this converter, using 
    //     /// the specified context and culture information
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a 
    //     /// format context</param>
    //     /// <param name="culture">The CultureInfo to use as the current culture</param>
    //     /// <param name="value">The Object to convert</param>
    //     /// <returns>An Object that represents the converted value</returns>
    //     public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
    //     {
    //         if (value is string)
    //         {
    //             string text = ((string)value).Trim();

    //             if (text.Length == 0)
    //             {
    //                 return null;
    //             }

    //             if (culture == null)
    //             {
    //                 culture = CultureInfo.CurrentCulture;
    //             }

    //             char[] listSeparators = culture.TextInfo.ListSeparator.ToCharArray();

    //             string[] s = text.Split(listSeparators);

    //             if (s.Length < 4)
    //             {
    //                 return null;
    //             }

    //             return new Border(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]), int.Parse(s[3]));
    //         }

    //         return base.ConvertFrom(context, culture, value);
    //     }


    //     /// <summary>
    //     /// Converts the given value object to the specified type, using 
    //     /// the specified context and culture information
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides 
    //     /// a format context</param>
    //     /// <param name="culture">A CultureInfo object. If a null reference 
    //     /// is passed, the current culture is assumed</param>
    //     /// <param name="value">The Object to convert</param>
    //     /// <param name="destinationType">The Type to convert the value 
    //     /// parameter to</param>
    //     /// <returns>An Object that represents the converted value</returns>
    //     public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    //     {
    //         if (destinationType == null)
    //         {
    //             throw new ArgumentNullException("destinationType");
    //         }

    //         if ((destinationType == typeof(string)) && (value is Border))
    //         {
    //             Border b = (Border)value;

    //             if (culture == null)
    //             {
    //                 culture = CultureInfo.CurrentCulture;
    //             }

    //             string separator = culture.TextInfo.ListSeparator + " ";

    //             TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));

    //             string[] s = new string[4];

    //             s[0] = converter.ConvertToString(context, culture, b.Left);
    //             s[1] = converter.ConvertToString(context, culture, b.Top);
    //             s[2] = converter.ConvertToString(context, culture, b.Right);
    //             s[3] = converter.ConvertToString(context, culture, b.Bottom);

    //             return string.Join(separator, s);
    //         }

    //         if ((destinationType == typeof(InstanceDescriptor)) && (value is Border))
    //         {
    //             Border b = (Border)value;

    //             Type[] t = new Type[4];
    //             t[0] = t[1] = t[2] = t[3] = typeof(int);

    //             ConstructorInfo info = typeof(Border).GetConstructor(t);

    //             if (info != null)
    //             {
    //                 object[] o = new object[4];

    //                 o[0] = b.Left;
    //                 o[1] = b.Top;
    //                 o[2] = b.Right;
    //                 o[3] = b.Bottom;

    //                 return new InstanceDescriptor(info, o);
    //             }
    //         }

    //         return base.ConvertTo(context, culture, value, destinationType);
    //     }


    //     /// <summary>
    //     /// Creates an instance of the Type that this TypeConverter is associated 
    //     /// with, using the specified context, given a set of property values for 
    //     /// the object
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a format 
    //     /// context</param>
    //     /// <param name="propertyValues">An IDictionary of new property values</param>
    //     /// <returns>An Object representing the given IDictionary, or a null 
    //     /// reference if the object cannot be created</returns>
    //     public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
    //     {
    //         return new Border((int)propertyValues["Left"],
    //             (int)propertyValues["Top"],
    //             (int)propertyValues["Right"],
    //             (int)propertyValues["Bottom"]);
    //     }


    //     /// <summary>
    //     /// Returns whether changing a value on this object requires a call to 
    //     /// CreateInstance to create a new value, using the specified context
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a 
    //     /// format context</param>
    //     /// <returns>true if changing a property on this object requires a call 
    //     /// to CreateInstance to create a new value; otherwise, false</returns>
    //     public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
    //     {
    //         return true;
    //     }


    //     /// <summary>
    //     /// Returns a collection of properties for the type of array specified 
    //     /// by the value parameter, using the specified context and attributes
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a format 
    //     /// context</param>
    //     /// <param name="value">An Object that specifies the type of array for 
    //     /// which to get properties</param>
    //     /// <param name="attributes">An array of type Attribute that is used as 
    //     /// a filter</param>
    //     /// <returns>A PropertyDescriptorCollection with the properties that are 
    //     /// exposed for this data type, or a null reference if there are no 
    //     /// properties</returns>
    //     public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    //     {
    //         PropertyDescriptorCollection collection = TypeDescriptor.GetProperties(typeof(Border), attributes);

    //         string[] s = new string[4];
    //         s[0] = "Left";
    //         s[1] = "Top";
    //         s[2] = "Right";
    //         s[3] = "Bottom";

    //         return collection.Sort(s);
    //     }


    //     /// <summary>
    //     /// Returns whether this object supports properties, using the specified context
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a format context</param>
    //     /// <returns>true if GetProperties should be called to find the properties of this 
    //     /// object; otherwise, false</returns>
    //     public override bool GetPropertiesSupported(ITypeDescriptorContext context)
    //     {
    //         return true;
    //     }
    // }

    // #endregion

    // #endregion


    // #region Padding Class

    // /// <summary>
    // /// Specifies the amount of space between the border and any contained 
    // /// items along each edge of an object
    // /// </summary>
    // [Serializable,
    // TypeConverter(typeof(PaddingConverter))]
    // public class XPPadding
    // {
    //     #region Class Data

    //     /// <summary>
    //     /// Represents a Padding structure with its properties 
    //     /// left uninitialized
    //     /// </summary>
    //     [NonSerialized()]
    //     public static readonly Padding Empty = new Padding(0, 0, 0, 0);

    //     /// <summary>
    //     /// The width of the left padding
    //     /// </summary>
    //     private int left;

    //     /// <summary>
    //     /// The width of the right padding
    //     /// </summary>
    //     private int right;

    //     /// <summary>
    //     /// The width of the top padding
    //     /// </summary>
    //     private int top;

    //     /// <summary>
    //     /// The width of the bottom padding
    //     /// </summary>
    //     private int bottom;

    //     #endregion


    //     #region Constructor

    //     /// <summary>
    //     /// Initializes a new instance of the Padding class with default settings
    //     /// </summary>
    //     public XPPadding() : this(0, 0, 0, 0)
    //     {

    //     }


    //     /// <summary>
    //     /// Initializes a new instance of the Padding class
    //     /// </summary>
    //     /// <param name="left">The width of the left padding value</param>
    //     /// <param name="top">The height of top padding value</param>
    //     /// <param name="right">The width of the right padding value</param>
    //     /// <param name="bottom">The height of bottom padding value</param>
    //     public XPPadding(int left, int top, int right, int bottom)
    //     {
    //         this.left = left;
    //         this.right = right;
    //         this.top = top;
    //         this.bottom = bottom;
    //     }

    //     #endregion


    //     #region Methods

    //     /// <summary>
    //     /// Tests whether obj is a Padding structure with the same values as 
    //     /// this Padding structure
    //     /// </summary>
    //     /// <param name="obj">The Object to test</param>
    //     /// <returns>This method returns true if obj is a Padding structure 
    //     /// and its Left, Top, Right, and Bottom properties are equal to 
    //     /// the corresponding properties of this Padding structure; 
    //     /// otherwise, false</returns>
    //     public override bool Equals(object obj)
    //     {
    //         if (!(obj is Padding))
    //         {
    //             return false;
    //         }

    //         Padding padding = (Padding)obj;

    //         if (((padding.Left == this.Left) && (padding.Top == this.Top)) && (padding.Right == this.Right))
    //         {
    //             return (padding.Bottom == this.Bottom);
    //         }

    //         return false;
    //     }


    //     /// <summary>
    //     /// Returns the hash code for this Padding structure
    //     /// </summary>
    //     /// <returns>An integer that represents the hashcode for this 
    //     /// padding</returns>
    //     public override int GetHashCode()
    //     {
    //         return (((this.Left ^ ((this.Top << 13) | (this.Top >> 0x13))) ^ ((this.Right << 0x1a) | (this.Right >> 6))) ^ ((this.Bottom << 7) | (this.Bottom >> 0x19)));
    //     }

    //     #endregion


    //     #region Properties

    //     /// <summary>
    //     /// Gets or sets the width of the left padding value
    //     /// </summary>
    //     public int Left
    //     {
    //         get
    //         {
    //             return this.left;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0;
    //             }

    //             this.left = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the width of the right padding value
    //     /// </summary>
    //     public int Right
    //     {
    //         get
    //         {
    //             return this.right;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0;
    //             }

    //             this.right = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the height of the top padding value
    //     /// </summary>
    //     public int Top
    //     {
    //         get
    //         {
    //             return this.top;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0;
    //             }

    //             this.top = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the height of the bottom padding value
    //     /// </summary>
    //     public int Bottom
    //     {
    //         get
    //         {
    //             return this.bottom;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0;
    //             }

    //             this.bottom = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Tests whether all numeric properties of this Padding have 
    //     /// values of zero
    //     /// </summary>
    //     [Browsable(false)]
    //     public bool IsEmpty
    //     {
    //         get
    //         {
    //             if (((this.Left == 0) && (this.Top == 0)) && (this.Right == 0))
    //             {
    //                 return (this.Bottom == 0);
    //             }

    //             return false;
    //         }
    //     }

    //     #endregion


    //     #region Operators

    //     /// <summary>
    //     /// Tests whether two Padding structures have equal Left, Top, 
    //     /// Right, and Bottom properties
    //     /// </summary>
    //     /// <param name="left">The Padding structure that is to the left 
    //     /// of the equality operator</param>
    //     /// <param name="right">The Padding structure that is to the right 
    //     /// of the equality operator</param>
    //     /// <returns>This operator returns true if the two Padding structures 
    //     /// have equal Left, Top, Right, and Bottom properties</returns>
    //     public static bool operator ==(XPPadding left, XPPadding right)
    //     {
    //         if (((left.Left == right.Left) && (left.Top == right.Top)) && (left.Right == right.Right))
    //         {
    //             return (left.Bottom == right.Bottom);
    //         }

    //         return false;
    //     }


    //     /// <summary>
    //     /// Tests whether two Padding structures differ in their Left, Top, 
    //     /// Right, and Bottom properties
    //     /// </summary>
    //     /// <param name="left">The Padding structure that is to the left 
    //     /// of the equality operator</param>
    //     /// <param name="right">The Padding structure that is to the right 
    //     /// of the equality operator</param>
    //     /// <returns>This operator returns true if any of the Left, Top, Right, 
    //     /// and Bottom properties of the two Padding structures are unequal; 
    //     /// otherwise false</returns>
    //     public static bool operator !=(XPPadding left, XPPadding right)
    //     {
    //         return !(left == right);
    //     }

    //     #endregion
    // }


    // #region PaddingConverter

    // /// <summary>
    // /// A custom TypeConverter used to help convert Padding objects from 
    // /// one Type to another
    // /// </summary>
    // internal class PaddingConverter : TypeConverter
    // {
    //     /// <summary>
    //     /// Returns whether this converter can convert an object of the 
    //     /// given type to the type of this converter, using the specified context
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides 
    //     /// a format context</param>
    //     /// <param name="sourceType">A Type that represents the type you 
    //     /// want to convert from</param>
    //     /// <returns>true if this converter can perform the conversion; 
    //     /// otherwise, false</returns>
    //     public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    //     {
    //         if (sourceType == typeof(string))
    //         {
    //             return true;
    //         }

    //         return base.CanConvertFrom(context, sourceType);
    //     }


    //     /// <summary>
    //     /// Returns whether this converter can convert the object to the 
    //     /// specified type, using the specified context
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a 
    //     /// format context</param>
    //     /// <param name="destinationType">A Type that represents the type you 
    //     /// want to convert to</param>
    //     /// <returns>true if this converter can perform the conversion; 
    //     /// otherwise, false</returns>
    //     public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    //     {
    //         if (destinationType == typeof(InstanceDescriptor))
    //         {
    //             return true;
    //         }

    //         return base.CanConvertTo(context, destinationType);
    //     }


    //     /// <summary>
    //     /// Converts the given object to the type of this converter, using 
    //     /// the specified context and culture information
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a 
    //     /// format context</param>
    //     /// <param name="culture">The CultureInfo to use as the current culture</param>
    //     /// <param name="value">The Object to convert</param>
    //     /// <returns>An Object that represents the converted value</returns>
    //     public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
    //     {
    //         if (value is string)
    //         {
    //             string text = ((string)value).Trim();

    //             if (text.Length == 0)
    //             {
    //                 return null;
    //             }

    //             if (culture == null)
    //             {
    //                 culture = CultureInfo.CurrentCulture;
    //             }

    //             char[] listSeparators = culture.TextInfo.ListSeparator.ToCharArray();

    //             string[] s = text.Split(listSeparators);

    //             if (s.Length < 4)
    //             {
    //                 return null;
    //             }

    //             return new Padding(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]), int.Parse(s[3]));
    //         }

    //         return base.ConvertFrom(context, culture, value);
    //     }


    //     /// <summary>
    //     /// Converts the given value object to the specified type, using 
    //     /// the specified context and culture information
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides 
    //     /// a format context</param>
    //     /// <param name="culture">A CultureInfo object. If a null reference 
    //     /// is passed, the current culture is assumed</param>
    //     /// <param name="value">The Object to convert</param>
    //     /// <param name="destinationType">The Type to convert the value 
    //     /// parameter to</param>
    //     /// <returns>An Object that represents the converted value</returns>
    //     public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    //     {
    //         if (destinationType == null)
    //         {
    //             throw new ArgumentNullException("destinationType");
    //         }

    //         if ((destinationType == typeof(string)) && (value is Padding))
    //         {
    //             Padding p = (Padding)value;

    //             if (culture == null)
    //             {
    //                 culture = CultureInfo.CurrentCulture;
    //             }

    //             string separator = culture.TextInfo.ListSeparator + " ";

    //             TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));

    //             string[] s = new string[4];

    //             s[0] = converter.ConvertToString(context, culture, p.Left);
    //             s[1] = converter.ConvertToString(context, culture, p.Top);
    //             s[2] = converter.ConvertToString(context, culture, p.Right);
    //             s[3] = converter.ConvertToString(context, culture, p.Bottom);

    //             return string.Join(separator, s);
    //         }

    //         if ((destinationType == typeof(InstanceDescriptor)) && (value is Padding))
    //         {
    //             Padding p = (Padding)value;

    //             Type[] t = new Type[4];
    //             t[0] = t[1] = t[2] = t[3] = typeof(int);

    //             ConstructorInfo info = typeof(Padding).GetConstructor(t);

    //             if (info != null)
    //             {
    //                 object[] o = new object[4];

    //                 o[0] = p.Left;
    //                 o[1] = p.Top;
    //                 o[2] = p.Right;
    //                 o[3] = p.Bottom;

    //                 return new InstanceDescriptor(info, o);
    //             }
    //         }

    //         return base.ConvertTo(context, culture, value, destinationType);
    //     }


    //     /// <summary>
    //     /// Creates an instance of the Type that this TypeConverter is associated 
    //     /// with, using the specified context, given a set of property values for 
    //     /// the object
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a format 
    //     /// context</param>
    //     /// <param name="propertyValues">An IDictionary of new property values</param>
    //     /// <returns>An Object representing the given IDictionary, or a null 
    //     /// reference if the object cannot be created</returns>
    //     public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
    //     {
    //         return new Padding((int)propertyValues["Left"],
    //             (int)propertyValues["Top"],
    //             (int)propertyValues["Right"],
    //             (int)propertyValues["Bottom"]);
    //     }


    //     /// <summary>
    //     /// Returns whether changing a value on this object requires a call to 
    //     /// CreateInstance to create a new value, using the specified context
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a 
    //     /// format context</param>
    //     /// <returns>true if changing a property on this object requires a call 
    //     /// to CreateInstance to create a new value; otherwise, false</returns>
    //     public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
    //     {
    //         return true;
    //     }


    //     /// <summary>
    //     /// Returns a collection of properties for the type of array specified 
    //     /// by the value parameter, using the specified context and attributes
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a format 
    //     /// context</param>
    //     /// <param name="value">An Object that specifies the type of array for 
    //     /// which to get properties</param>
    //     /// <param name="attributes">An array of type Attribute that is used as 
    //     /// a filter</param>
    //     /// <returns>A PropertyDescriptorCollection with the properties that are 
    //     /// exposed for this data type, or a null reference if there are no 
    //     /// properties</returns>
    //     public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    //     {
    //         PropertyDescriptorCollection collection = TypeDescriptor.GetProperties(typeof(Padding), attributes);

    //         string[] s = new string[4];
    //         s[0] = "Left";
    //         s[1] = "Top";
    //         s[2] = "Right";
    //         s[3] = "Bottom";

    //         return collection.Sort(s);
    //     }


    //     /// <summary>
    //     /// Returns whether this object supports properties, using the specified context
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a format context</param>
    //     /// <returns>true if GetProperties should be called to find the properties of this 
    //     /// object; otherwise, false</returns>
    //     public override bool GetPropertiesSupported(ITypeDescriptorContext context)
    //     {
    //         return true;
    //     }
    // }

    // #endregion

    // #endregion


    // #region Margin Class

    // /// <summary>
    // /// Specifies the amount of space arouund an object along each side
    // /// </summary>
    // [Serializable,
    // TypeConverter(typeof(MarginConverter))]
    // public class Margin
    // {
    //     #region Class Data

    //     /// <summary>
    //     /// Represents a Margin structure with its properties 
    //     /// left uninitialized
    //     /// </summary>
    //     [NonSerialized()]
    //     public static readonly Margin Empty = new Margin(0, 0, 0, 0);

    //     /// <summary>
    //     /// The width of the left margin
    //     /// </summary>
    //     private int left;

    //     /// <summary>
    //     /// The width of the right margin
    //     /// </summary>
    //     private int right;

    //     /// <summary>
    //     /// The width of the top margin
    //     /// </summary>
    //     private int top;

    //     /// <summary>
    //     /// The width of the bottom margin
    //     /// </summary>
    //     private int bottom;

    //     #endregion


    //     #region Constructor

    //     /// <summary>
    //     /// Initializes a new instance of the Margin class with default settings
    //     /// </summary>
    //     public Margin() : this(0, 0, 0, 0)
    //     {

    //     }


    //     /// <summary>
    //     /// Initializes a new instance of the Margin class
    //     /// </summary>
    //     /// <param name="left">The width of the left margin value</param>
    //     /// <param name="top">The height of the top margin value</param>
    //     /// <param name="right">The width of the right margin value</param>
    //     /// <param name="bottom">The height of the bottom margin value</param>
    //     public Margin(int left, int top, int right, int bottom)
    //     {
    //         this.left = left;
    //         this.right = right;
    //         this.top = top;
    //         this.bottom = bottom;
    //     }

    //     #endregion


    //     #region Methods

    //     /// <summary>
    //     /// Tests whether obj is a Margin structure with the same values as 
    //     /// this Border structure
    //     /// </summary>
    //     /// <param name="obj">The Object to test</param>
    //     /// <returns>This method returns true if obj is a Margin structure 
    //     /// and its Left, Top, Right, and Bottom properties are equal to 
    //     /// the corresponding properties of this Margin structure; 
    //     /// otherwise, false</returns>
    //     public override bool Equals(object obj)
    //     {
    //         if (!(obj is Margin))
    //         {
    //             return false;
    //         }

    //         Margin margin = (Margin)obj;

    //         if (((margin.Left == this.Left) && (margin.Top == this.Top)) && (margin.Right == this.Right))
    //         {
    //             return (margin.Bottom == this.Bottom);
    //         }

    //         return false;
    //     }


    //     /// <summary>
    //     /// Returns the hash code for this Margin structure
    //     /// </summary>
    //     /// <returns>An integer that represents the hashcode for this 
    //     /// margin</returns>
    //     public override int GetHashCode()
    //     {
    //         return (((this.Left ^ ((this.Top << 13) | (this.Top >> 0x13))) ^ ((this.Right << 0x1a) | (this.Right >> 6))) ^ ((this.Bottom << 7) | (this.Bottom >> 0x19)));
    //     }

    //     #endregion


    //     #region Properties

    //     /// <summary>
    //     /// Gets or sets the left margin value
    //     /// </summary>
    //     public int Left
    //     {
    //         get
    //         {
    //             return this.left;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0;
    //             }

    //             this.left = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the right margin value
    //     /// </summary>
    //     public int Right
    //     {
    //         get
    //         {
    //             return this.right;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0;
    //             }

    //             this.right = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the top margin value
    //     /// </summary>
    //     public int Top
    //     {
    //         get
    //         {
    //             return this.top;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0;
    //             }

    //             this.top = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the bottom margin value
    //     /// </summary>
    //     public int Bottom
    //     {
    //         get
    //         {
    //             return this.bottom;
    //         }

    //         set
    //         {
    //             if (value < 0)
    //             {
    //                 value = 0;
    //             }

    //             this.bottom = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Tests whether all numeric properties of this Margin have 
    //     /// values of zero
    //     /// </summary>
    //     [Browsable(false)]
    //     public bool IsEmpty
    //     {
    //         get
    //         {
    //             if (((this.Left == 0) && (this.Top == 0)) && (this.Right == 0))
    //             {
    //                 return (this.Bottom == 0);
    //             }

    //             return false;
    //         }
    //     }

    //     #endregion


    //     #region Operators

    //     /// <summary>
    //     /// Tests whether two Margin structures have equal Left, Top, 
    //     /// Right, and Bottom properties
    //     /// </summary>
    //     /// <param name="left">The Margin structure that is to the left 
    //     /// of the equality operator</param>
    //     /// <param name="right">The Margin structure that is to the right 
    //     /// of the equality operator</param>
    //     /// <returns>This operator returns true if the two Margin structures 
    //     /// have equal Left, Top, Right, and Bottom properties</returns>
    //     public static bool operator ==(Margin left, Margin right)
    //     {
    //         if (((left.Left == right.Left) && (left.Top == right.Top)) && (left.Right == right.Right))
    //         {
    //             return (left.Bottom == right.Bottom);
    //         }

    //         return false;
    //     }


    //     /// <summary>
    //     /// Tests whether two Margin structures differ in their Left, Top, 
    //     /// Right, and Bottom properties
    //     /// </summary>
    //     /// <param name="left">The Margin structure that is to the left 
    //     /// of the equality operator</param>
    //     /// <param name="right">The Margin structure that is to the right 
    //     /// of the equality operator</param>
    //     /// <returns>This operator returns true if any of the Left, Top, Right, 
    //     /// and Bottom properties of the two Margin structures are unequal; 
    //     /// otherwise false</returns>
    //     public static bool operator !=(Margin left, Margin right)
    //     {
    //         return !(left == right);
    //     }

    //     #endregion
    // }


    // #region MarginConverter

    // /// <summary>
    // /// A custom TypeConverter used to help convert Margins from 
    // /// one Type to another
    // /// </summary>
    // internal class MarginConverter : TypeConverter
    // {
    //     /// <summary>
    //     /// Returns whether this converter can convert an object of the 
    //     /// given type to the type of this converter, using the specified context
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides 
    //     /// a format context</param>
    //     /// <param name="sourceType">A Type that represents the type you 
    //     /// want to convert from</param>
    //     /// <returns>true if this converter can perform the conversion; 
    //     /// otherwise, false</returns>
    //     public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    //     {
    //         if (sourceType == typeof(string))
    //         {
    //             return true;
    //         }

    //         return base.CanConvertFrom(context, sourceType);
    //     }


    //     /// <summary>
    //     /// Returns whether this converter can convert the object to the 
    //     /// specified type, using the specified context
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a 
    //     /// format context</param>
    //     /// <param name="destinationType">A Type that represents the type you 
    //     /// want to convert to</param>
    //     /// <returns>true if this converter can perform the conversion; 
    //     /// otherwise, false</returns>
    //     public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    //     {
    //         if (destinationType == typeof(InstanceDescriptor))
    //         {
    //             return true;
    //         }

    //         return base.CanConvertTo(context, destinationType);
    //     }


    //     /// <summary>
    //     /// Converts the given object to the type of this converter, using 
    //     /// the specified context and culture information
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a 
    //     /// format context</param>
    //     /// <param name="culture">The CultureInfo to use as the current culture</param>
    //     /// <param name="value">The Object to convert</param>
    //     /// <returns>An Object that represents the converted value</returns>
    //     public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
    //     {
    //         if (value is string)
    //         {
    //             string text = ((string)value).Trim();

    //             if (text.Length == 0)
    //             {
    //                 return null;
    //             }

    //             if (culture == null)
    //             {
    //                 culture = CultureInfo.CurrentCulture;
    //             }

    //             char[] listSeparators = culture.TextInfo.ListSeparator.ToCharArray();

    //             string[] s = text.Split(listSeparators);

    //             if (s.Length < 4)
    //             {
    //                 return null;
    //             }

    //             return new Margin(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]), int.Parse(s[3]));
    //         }

    //         return base.ConvertFrom(context, culture, value);
    //     }


    //     /// <summary>
    //     /// Converts the given value object to the specified type, using 
    //     /// the specified context and culture information
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides 
    //     /// a format context</param>
    //     /// <param name="culture">A CultureInfo object. If a null reference 
    //     /// is passed, the current culture is assumed</param>
    //     /// <param name="value">The Object to convert</param>
    //     /// <param name="destinationType">The Type to convert the value 
    //     /// parameter to</param>
    //     /// <returns>An Object that represents the converted value</returns>
    //     public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    //     {
    //         if (destinationType == null)
    //         {
    //             throw new ArgumentNullException("destinationType");
    //         }

    //         if ((destinationType == typeof(string)) && (value is Margin))
    //         {
    //             Margin m = (Margin)value;

    //             if (culture == null)
    //             {
    //                 culture = CultureInfo.CurrentCulture;
    //             }

    //             string separator = culture.TextInfo.ListSeparator + " ";

    //             TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));

    //             string[] s = new string[4];

    //             s[0] = converter.ConvertToString(context, culture, m.Left);
    //             s[1] = converter.ConvertToString(context, culture, m.Top);
    //             s[2] = converter.ConvertToString(context, culture, m.Right);
    //             s[3] = converter.ConvertToString(context, culture, m.Bottom);

    //             return string.Join(separator, s);
    //         }

    //         if ((destinationType == typeof(InstanceDescriptor)) && (value is Margin))
    //         {
    //             Margin m = (Margin)value;

    //             Type[] t = new Type[4];
    //             t[0] = t[1] = t[2] = t[3] = typeof(int);

    //             ConstructorInfo info = typeof(Margin).GetConstructor(t);

    //             if (info != null)
    //             {
    //                 object[] o = new object[4];

    //                 o[0] = m.Left;
    //                 o[1] = m.Top;
    //                 o[2] = m.Right;
    //                 o[3] = m.Bottom;

    //                 return new InstanceDescriptor(info, o);
    //             }
    //         }

    //         return base.ConvertTo(context, culture, value, destinationType);
    //     }


    //     /// <summary>
    //     /// Creates an instance of the Type that this TypeConverter is associated 
    //     /// with, using the specified context, given a set of property values for 
    //     /// the object
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a format 
    //     /// context</param>
    //     /// <param name="propertyValues">An IDictionary of new property values</param>
    //     /// <returns>An Object representing the given IDictionary, or a null 
    //     /// reference if the object cannot be created</returns>
    //     public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
    //     {
    //         return new Margin((int)propertyValues["Left"],
    //             (int)propertyValues["Top"],
    //             (int)propertyValues["Right"],
    //             (int)propertyValues["Bottom"]);
    //     }


    //     /// <summary>
    //     /// Returns whether changing a value on this object requires a call to 
    //     /// CreateInstance to create a new value, using the specified context
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a 
    //     /// format context</param>
    //     /// <returns>true if changing a property on this object requires a call 
    //     /// to CreateInstance to create a new value; otherwise, false</returns>
    //     public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
    //     {
    //         return true;
    //     }


    //     /// <summary>
    //     /// Returns a collection of properties for the type of array specified 
    //     /// by the value parameter, using the specified context and attributes
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a format 
    //     /// context</param>
    //     /// <param name="value">An Object that specifies the type of array for 
    //     /// which to get properties</param>
    //     /// <param name="attributes">An array of type Attribute that is used as 
    //     /// a filter</param>
    //     /// <returns>A PropertyDescriptorCollection with the properties that are 
    //     /// exposed for this data type, or a null reference if there are no 
    //     /// properties</returns>
    //     public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    //     {
    //         PropertyDescriptorCollection collection = TypeDescriptor.GetProperties(typeof(Margin), attributes);

    //         string[] s = new string[4];
    //         s[0] = "Left";
    //         s[1] = "Top";
    //         s[2] = "Right";
    //         s[3] = "Bottom";

    //         return collection.Sort(s);
    //     }


    //     /// <summary>
    //     /// Returns whether this object supports properties, using the specified context
    //     /// </summary>
    //     /// <param name="context">An ITypeDescriptorContext that provides a format context</param>
    //     /// <returns>true if GetProperties should be called to find the properties of this 
    //     /// object; otherwise, false</returns>
    //     public override bool GetPropertiesSupported(ITypeDescriptorContext context)
    //     {
    //         return true;
    //     }
    // }

    // #endregion

    // #endregion Margin Class


    // #region ImageStretchMode

    // /// <summary>
    // /// Specifies how images should fill objects
    // /// </summary>
    // public enum ImageStretchMode
    // {
    //     /// <summary>
    //     /// Use default settings
    //     /// </summary>
    //     Normal = 0,

    //     /// <summary>
    //     /// The image is transparent
    //     /// </summary>
    //     Transparent = 2,

    //     /// <summary>
    //     /// The image should be tiled
    //     /// </summary>
    //     Tile = 3,

    //     /// <summary>
    //     /// The image should be stretched to fit the objects width 
    //     /// </summary>
    //     Horizontal = 5,

    //     /// <summary>
    //     /// The image should be stretched to fill the object
    //     /// </summary>
    //     Stretch = 6,

    //     /// <summary>
    //     /// The image is stored in ARGB format
    //     /// </summary>
    //     ARGBImage = 7
    // }

    // #endregion

    // #endregion

    // #region Native Methods

    // #region NativeMethods

    // /// <summary>
    // /// A class that provides access to the Win32 API
    // /// </summary>
    // public sealed class NativeMethods
    // {
    //     /// <summary>
    //     /// The LoadLibrary function maps the specified executable module into the 
    //     /// address space of the calling process
    //     /// </summary>
    //     /// <param name="lpFileName">Pointer to a null-terminated string that names 
    //     /// the executable module (either a .dll or .exe file). The name specified 
    //     /// is the file name of the module and is not related to the name stored in 
    //     /// the library module itself, as specified by the LIBRARY keyword in the 
    //     /// module-definition (.def) file.  
    //     /// If the string specifies a path but the file does not exist in the specified 
    //     /// directory, the function fails. When specifying a path, be sure to use 
    //     /// backslashes (\), not forward slashes (/).  
    //     /// If the string does not specify a path, the function uses a standard search 
    //     /// strategy to find the file.</param>
    //     /// <returns>If the function succeeds, the return value is a handle to the module. 
    //     /// If the function fails, the return value is NULL</returns>
    //     [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    //     public static extern IntPtr LoadLibrary(string lpFileName);


    //     /// <summary>
    //     /// The LoadLibraryEx function maps the specified executable module into the 
    //     /// address space of the calling process. The executable module can be a .dll 
    //     /// or an .exe file. The specified module may cause other modules to be mapped 
    //     /// into the address space
    //     /// </summary>
    //     /// <param name="lpfFileName">Pointer to a null-terminated string that names 
    //     /// the executable module (either a .dll or an .exe file). The name specified 
    //     /// is the file name of the executable module. This name is not related to the 
    //     /// name stored in a library module itself, as specified by the LIBRARY keyword 
    //     /// in the module-definition (.def) file. If the string specifies a path, but 
    //     /// the file does not exist in the specified directory, the function fails. When 
    //     /// specifying a path, be sure to use backslashes (\), not forward slashes (/). 
    //     /// If the string does not specify a path, and the file name extension is omitted, 
    //     /// the function appends the default library extension .dll to the file name. 
    //     /// However, the file name string can include a trailing point character (.) to 
    //     /// indicate that the module name has no extension. If the string does not specify 
    //     /// a path, the function uses a standard search strategy to find the file. If 
    //     /// mapping the specified module into the address space causes the system to map 
    //     /// in other, associated executable modules, the function can use either the 
    //     /// standard search strategy or an alternate search strategy to find those modules.</param>
    //     /// <param name="flags">Action to take when loading the module. If no flags are 
    //     /// specified, the behavior of this function is identical to that of the LoadLibrary 
    //     /// function. This parameter can be one of the LoadLibraryExFlags values</param>
    //     /// <returns>If the function succeeds, the return value is a handle to the mapped 
    //     /// executable module. If the function fails, the return value is NULL.</returns>
    //     public static IntPtr LoadLibraryEx(string lpfFileName, LoadLibraryExFlags flags)
    //     {
    //         return NativeMethods.InternalLoadLibraryEx(lpfFileName, IntPtr.Zero, (int)flags);
    //     }

    //     [DllImport("Kernel32.dll", EntryPoint = "LoadLibraryEx")]
    //     private static extern IntPtr InternalLoadLibraryEx(string lpfFileName, IntPtr hFile, int dwFlags);


    //     /// <summary>
    //     /// The FreeLibrary function decrements the reference count of the loaded 
    //     /// dynamic-link library (DLL). When the reference count reaches zero, the 
    //     /// module is unmapped from the address space of the calling process and the 
    //     /// handle is no longer valid
    //     /// </summary>
    //     /// <param name="hModule">Handle to the loaded DLL module. The LoadLibrary 
    //     /// function returns this handle</param>
    //     /// <returns>If the function succeeds, the return value is nonzero. If the 
    //     /// function fails, the return value is zero</returns>
    //     [DllImport("Kernel32.dll")]
    //     public static extern bool FreeLibrary(IntPtr hModule);


    //     /// <summary>
    //     /// The FindResource function determines the location of a resource with the 
    //     /// specified type and name in the specified module
    //     /// </summary>
    //     /// <param name="hModule">Handle to the module whose executable file contains 
    //     /// the resource. A value of NULL specifies the module handle associated with 
    //     /// the image file that the operating system used to create the current process</param>
    //     /// <param name="lpName">Specifies the name of the resource</param>
    //     /// <param name="lpType">Specifies the resource type</param>
    //     /// <returns>If the function succeeds, the return value is a handle to the 
    //     /// specified resource's information block. To obtain a handle to the resource, 
    //     /// pass this handle to the LoadResource function. If the function fails, the 
    //     /// return value is NULL</returns>
    //     [DllImport("Kernel32.dll")]
    //     public static extern IntPtr FindResource(IntPtr hModule, string lpName, int lpType);

    //     /// <summary>
    //     /// The FindResource function determines the location of a resource with the 
    //     /// specified type and name in the specified module
    //     /// </summary>
    //     /// <param name="hModule">Handle to the module whose executable file contains 
    //     /// the resource. A value of NULL specifies the module handle associated with 
    //     /// the image file that the operating system used to create the current process</param>
    //     /// <param name="lpName">Specifies the name of the resource</param>
    //     /// <param name="lpType">Specifies the resource type</param>
    //     /// <returns>If the function succeeds, the return value is a handle to the 
    //     /// specified resource's information block. To obtain a handle to the resource, 
    //     /// pass this handle to the LoadResource function. If the function fails, the 
    //     /// return value is NULL</returns>
    //     [DllImport("Kernel32.dll")]
    //     public static extern IntPtr FindResource(IntPtr hModule, string lpName, string lpType);


    //     /// <summary>
    //     /// The SizeofResource function returns the size, in bytes, of the specified 
    //     /// resource
    //     /// </summary>
    //     /// <param name="hModule">Handle to the module whose executable file contains 
    //     /// the resource</param>
    //     /// <param name="hResInfo">Handle to the resource. This handle must be created 
    //     /// by using the FindResource or FindResourceEx function</param>
    //     /// <returns>If the function succeeds, the return value is the number of bytes 
    //     /// in the resource. If the function fails, the return value is zero</returns>
    //     [DllImport("Kernel32.dll")]
    //     public static extern int SizeofResource(IntPtr hModule, IntPtr hResInfo);


    //     /// <summary>
    //     /// The LoadResource function loads the specified resource into global memory
    //     /// </summary>
    //     /// <param name="hModule">Handle to the module whose executable file contains 
    //     /// the resource. If hModule is NULL, the system loads the resource from the 
    //     /// module that was used to create the current process</param>
    //     /// <param name="hResInfo">Handle to the resource to be loaded. This handle is 
    //     /// returned by the FindResource or FindResourceEx function</param>
    //     /// <returns>If the function succeeds, the return value is a handle to the data 
    //     /// associated with the resource. If the function fails, the return value is NULL</returns>
    //     [DllImport("Kernel32.dll")]
    //     public static extern System.IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);


    //     /// <summary>
    //     /// The FreeResource function decrements (decreases by one) the reference count 
    //     /// of a loaded resource. When the reference count reaches zero, the memory occupied 
    //     /// by the resource is freed
    //     /// </summary>
    //     /// <param name="hglbResource">Handle of the resource. It is assumed that hglbResource 
    //     /// was created by LoadResource</param>
    //     /// <returns>If the function succeeds, the return value is zero. If the function fails, 
    //     /// the return value is non-zero, which indicates that the resource has not been freed</returns>
    //     [DllImport("Kernel32.dll")]
    //     public static extern int FreeResource(IntPtr hglbResource);


    //     /// <summary>
    //     /// The CopyMemory function copies a block of memory from one location to another
    //     /// </summary>
    //     /// <param name="Destination">Pointer to the starting address of the copied 
    //     /// block's destination</param>
    //     /// <param name="Source">Pointer to the starting address of the block of memory 
    //     /// to copy</param>
    //     /// <param name="Length">Size of the block of memory to copy, in bytes</param>
    //     [DllImport("Kernel32.dll")]
    //     public static extern void CopyMemory(IntPtr Destination, IntPtr Source, int Length);


    //     /// <summary>
    //     /// The LoadBitmap function loads the specified bitmap resource from a module's 
    //     /// executable file
    //     /// </summary>
    //     /// <param name="hInstance">Handle to the instance of the module whose executable 
    //     /// file contains the bitmap to be loaded</param>
    //     /// <param name="lpBitmapName">Pointer to a null-terminated string that contains 
    //     /// the name of the bitmap resource to be loaded. Alternatively, this parameter 
    //     /// can consist of the resource identifier in the low-order word and zero in the 
    //     /// high-order word</param>
    //     /// <returns>If the function succeeds, the return value is the handle to the specified 
    //     /// bitmap. If the function fails, the return value is NULL</returns>
    //     [DllImport("User32.dll")]
    //     public static extern IntPtr LoadBitmap(IntPtr hInstance, long lpBitmapName);


    //     /// <summary>
    //     /// The LoadBitmap function loads the specified bitmap resource from a module's 
    //     /// executable file
    //     /// </summary>
    //     /// <param name="hInstance">Handle to the instance of the module whose executable 
    //     /// file contains the bitmap to be loaded</param>
    //     /// <param name="lpBitmapName">Pointer to a null-terminated string that contains 
    //     /// the name of the bitmap resource to be loaded. Alternatively, this parameter 
    //     /// can consist of the resource identifier in the low-order word and zero in the 
    //     /// high-order word</param>
    //     /// <returns>If the function succeeds, the return value is the handle to the specified 
    //     /// bitmap. If the function fails, the return value is NULL</returns>
    //     [DllImport("User32.dll")]
    //     public static extern IntPtr LoadBitmap(IntPtr hInstance, string lpBitmapName);


    //     /// <summary>
    //     /// The GdiFlush function flushes the calling thread's current batch
    //     /// </summary>
    //     /// <returns>If all functions in the current batch succeed, the return value is 
    //     /// nonzero. If not all functions in the current batch succeed, the return value 
    //     /// is zero, indicating that at least one function returned an error</returns>
    //     [DllImport("Gdi32.dll")]
    //     public static extern int GdiFlush();


    //     /// <summary>
    //     /// The LoadString function loads a string resource from the executable file 
    //     /// associated with a specified module, copies the string into a buffer, and 
    //     /// appends a terminating null character
    //     /// </summary>
    //     /// <param name="hInstance">Handle to an instance of the module whose executable 
    //     /// file contains the string resource</param>
    //     /// <param name="uID">Specifies the integer identifier of the string to be loaded</param>
    //     /// <param name="lpBuffer">Pointer to the buffer to receive the string</param>
    //     /// <param name="nBufferMax">Specifies the size of the buffer, in TCHARs. This 
    //     /// refers to bytes for versions of the function or WCHARs for Unicode versions. 
    //     /// The string is truncated and null terminated if it is longer than the number 
    //     /// of characters specified</param>
    //     /// <returns>If the function succeeds, the return value is the number of TCHARs 
    //     /// copied into the buffer, not including the null-terminating character, or 
    //     /// zero if the string resource does not exist</returns>
    //     [DllImport("User32.dll")]
    //     public static extern int LoadString(IntPtr hInstance, int uID, StringBuilder lpBuffer, int nBufferMax);


    //     /// <summary>
    //     /// The SendMessage function sends the specified message to a 
    //     /// window or windows. It calls the window procedure for the 
    //     /// specified window and does not return until the window 
    //     /// procedure has processed the message
    //     /// </summary>
    //     /// <param name="hwnd">Handle to the window whose window procedure will 
    //     /// receive the message</param>
    //     /// <param name="msg">Specifies the message to be sent</param>
    //     /// <param name="wParam">Specifies additional message-specific information</param>
    //     /// <param name="lParam">Specifies additional message-specific information</param>
    //     /// <returns>The return value specifies the result of the message processing; 
    //     /// it depends on the message sent</returns>
    //     public static int SendMessage(IntPtr hwnd, WindowMessageFlags msg, IntPtr wParam, IntPtr lParam)
    //     {
    //         return NativeMethods.InternalSendMessage(hwnd, (int)msg, wParam, lParam);
    //     }

    //     [DllImport("User32.dll", EntryPoint = "SendMessage")]
    //     private static extern int InternalSendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);


    //     /// <summary>
    //     /// Implemented by many of the Microsoft® Windows® Shell dynamic-link libraries 
    //     /// (DLLs) to allow applications to obtain DLL-specific version information
    //     /// </summary>
    //     /// <param name="pdvi">Pointer to a DLLVERSIONINFO structure that receives the 
    //     /// version information. The cbSize member must be filled in before calling 
    //     /// the function</param>
    //     /// <returns>Returns NOERROR if successful, or an OLE-defined error value otherwise</returns>
    //     [DllImport("Comctl32.dll")]
    //     public static extern int DllGetVersion(ref DLLVERSIONINFO pdvi);


    //     /// <summary>
    //     /// The GetProcAddress function retrieves the address of an exported function 
    //     /// or variable from the specified dynamic-link library (DLL)
    //     /// </summary>
    //     /// <param name="hModule">Handle to the DLL module that contains the function 
    //     /// or variable. The LoadLibrary or GetModuleHandle function returns this handle</param>
    //     /// <param name="procName">Pointer to a null-terminated string that specifies 
    //     /// the function or variable name, or the function's ordinal value. If this 
    //     /// parameter is an ordinal value, it must be in the low-order word; the 
    //     /// high-order word must be zero</param>
    //     /// <returns>If the function succeeds, the return value is the address of the 
    //     /// exported function or variable. If the function fails, the return value is NULL</returns>
    //     [DllImport("Kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
    //     public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);


    //     /// <summary>
    //     /// The SetErrorMode function controls whether the system will handle the 
    //     /// specified types of serious errors, or whether the process will handle them
    //     /// </summary>
    //     /// <param name="uMode">Process error mode. This parameter can be one or more of 
    //     /// the SetErrorModeFlags values</param>
    //     /// <returns>The return value is the previous state of the error-mode bit flags</returns>
    //     public static int SetErrorMode(SetErrorModeFlags uMode)
    //     {
    //         return NativeMethods.InternalSetErrorMode((int)uMode);
    //     }

    //     [DllImport("Kernel32.dll", EntryPoint = "SetErrorMode")]
    //     private static extern int InternalSetErrorMode(int uMode);


    //     /// <summary>
    //     /// The GetSystemMetrics function retrieves various system metrics (widths and 
    //     /// heights of display elements) and system configuration settings. All dimensions 
    //     /// retrieved by GetSystemMetrics are in pixels
    //     /// </summary>
    //     /// <param name="nIndex">System metric or configuration setting to retrieve. This 
    //     /// parameter can be one of the SysMetricsFlags values. Note that all SM_CX* values 
    //     /// are widths and all SM_CY* values are heights</param>
    //     /// <returns>If the function succeeds, the return value is the requested system 
    //     /// metric or configuration setting. If the function fails, the return value is zero</returns>
    //     [DllImport("User32.dll")]
    //     internal static extern int GetSystemMetrics(int nIndex);


    //     /// <summary>
    //     /// The GetDC function retrieves a handle to a display device context (DC) for 
    //     /// the client area of a specified window or for the entire screen. You can use 
    //     /// the returned handle in subsequent GDI functions to draw in the DC
    //     /// </summary>
    //     /// <param name="hWnd">Handle to the window whose DC is to be retrieved. If this 
    //     /// value is IntPtr.Zero, GetDC retrieves the DC for the entire screen</param>
    //     /// <returns>If the function succeeds, the return value is an IntPtr that points 
    //     /// to the handle to the DC for the specified window's client area. If the function 
    //     /// fails, the return value is IntPtr.Zero</returns>
    //     [DllImport("User32.dll")]
    //     internal static extern IntPtr GetDC(IntPtr hWnd);


    //     /// <summary>
    //     /// The ReleaseDC function releases a device context (DC), freeing it for use by 
    //     /// other applications. The effect of the ReleaseDC function depends on the type 
    //     /// of DC. It frees only common and window DCs. It has no effect on class or 
    //     /// private DCs
    //     /// </summary>
    //     /// <param name="hWnd">Handle to the window whose DC is to be released</param>
    //     /// <param name="hDC">Handle to the DC to be released</param>
    //     /// <returns>If the DC was released, the return value is 1, otherwise the return 
    //     /// value is zero</returns>
    //     [DllImport("User32.dll")]
    //     internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);


    //     /// <summary>
    //     /// The GetDeviceCaps function retrieves device-specific information for the 
    //     /// specified device
    //     /// </summary>
    //     /// <param name="hDC">Handle to the DC</param>
    //     /// <param name="nIndex">Specifies the item to return. This parameter can be one of 
    //     /// the DeviceCapsFlags values</param>
    //     /// <returns>The return value specifies the value of the desired item</returns>
    //     [DllImport("Gdi32.dll")]
    //     internal static extern int GetDeviceCaps(IntPtr hDC, int nIndex);


    //     /// <summary>
    //     /// The CreateIconFromResourceEx function creates an icon or cursor from resource 
    //     /// bits describing the icon
    //     /// </summary>
    //     /// <param name="pbIconBits">Pointer to a buffer containing the icon or cursor 
    //     /// resource bits. These bits are typically loaded by calls to the 
    //     /// LookupIconIdFromDirectoryEx and LoadResource functions</param>
    //     /// <param name="cbIconBits">Specifies the size, in bytes, of the set of bits 
    //     /// pointed to by the pbIconBits parameter</param>
    //     /// <param name="fIcon">Specifies whether an icon or a cursor is to be created. 
    //     /// If this parameter is TRUE, an icon is to be created. If it is FALSE, a cursor 
    //     /// is to be created</param>
    //     /// <param name="dwVersion">Specifies the version number of the icon or cursor 
    //     /// format for the resource bits pointed to by the pbIconBits parameter. This 
    //     /// parameter can be 0x00030000</param>
    //     /// <param name="csDesired">Specifies the desired width, in pixels, of the icon 
    //     /// or cursor. If this parameter is zero, the function uses the SM_CXICON or 
    //     /// SM_CXCURSOR system metric value to set the width</param>
    //     /// <param name="cyDesired">Specifies the desired height, in pixels, of the icon 
    //     /// or cursor. If this parameter is zero, the function uses the SM_CYICON or 
    //     /// SM_CYCURSOR system metric value to set the height</param>
    //     /// <param name="flags"></param>
    //     /// <returns>If the function succeeds, the return value is a handle to the icon 
    //     /// or cursor. If the function fails, the return value is NULL</returns>
    //     [DllImport("User32.dll")]
    //     internal static extern unsafe IntPtr CreateIconFromResourceEx(byte* pbIconBits, int cbIconBits, bool fIcon, int dwVersion, int csDesired, int cyDesired, int flags);


    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="hdc"></param>
    //     /// <param name="hgdiobj"></param>
    //     /// <returns></returns>
    //     [DllImport("Gdi32.dll")]
    //     internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);


    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="hObject"></param>
    //     /// <returns></returns>
    //     [DllImport("Gdi32.dll")]
    //     internal static extern bool DeleteObject(IntPtr hObject);


    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="hdc"></param>
    //     /// <param name="lpString"></param>
    //     /// <param name="nCount"></param>
    //     /// <param name="lpRect"></param>
    //     /// <param name="uFormat"></param>
    //     /// <returns></returns>
    //     [DllImport("user32.dll", CharSet = CharSet.Auto)]
    //     internal static extern int DrawText(IntPtr hdc, string lpString, int nCount, ref RECT lpRect, DrawTextFlags uFormat);


    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="hdc"></param>
    //     /// <param name="iBkMode"></param>
    //     /// <returns></returns>
    //     [DllImport("Gdi32.dll")]
    //     internal static extern int SetBkMode(IntPtr hdc, int iBkMode);


    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="hdc"></param>
    //     /// <param name="crColor"></param>
    //     /// <returns></returns>
    //     [DllImport("Gdi32.dll")]
    //     internal static extern int SetTextColor(IntPtr hdc, int crColor);
    // }

    // #endregion



    // #region Structs

    // /// <summary>
    // /// The POINT structure defines the x- and y- coordinates of a point
    // /// </summary>
    // [Serializable(),
    // StructLayout(LayoutKind.Sequential)]
    // public struct POINT
    // {
    //     /// <summary>
    //     /// Specifies the x-coordinate of the point
    //     /// </summary>
    //     public int x;

    //     /// <summary>
    //     /// Specifies the y-coordinate of the point
    //     /// </summary>
    //     public int y;


    //     /// <summary>
    //     /// Creates a new RECT struct with the specified x and y coordinates
    //     /// </summary>
    //     /// <param name="x">The x-coordinate of the point</param>
    //     /// <param name="y">The y-coordinate of the point</param>
    //     public POINT(int x, int y)
    //     {
    //         this.x = x;
    //         this.y = y;
    //     }


    //     /// <summary>
    //     /// Creates a new POINT struct from the specified Point
    //     /// </summary>
    //     /// <param name="p">The Point to create the POINT from</param>
    //     /// <returns>A POINT struct with the same x and y coordinates as 
    //     /// the specified Point</returns>
    //     public static POINT FromPoint(Point p)
    //     {
    //         return new POINT(p.X, p.Y);
    //     }


    //     /// <summary>
    //     /// Returns a Point with the same x and y coordinates as the POINT
    //     /// </summary>
    //     /// <returns>A Point with the same x and y coordinates as the POINT</returns>
    //     public Point ToPoint()
    //     {
    //         return new Point(this.x, this.y);
    //     }
    // }


    // /// <summary>
    // /// The RECT structure defines the coordinates of the upper-left 
    // /// and lower-right corners of a rectangle
    // /// </summary>
    // [Serializable(),
    // StructLayout(LayoutKind.Sequential)]
    // public struct RECT
    // {
    //     /// <summary>
    //     /// Specifies the x-coordinate of the upper-left corner of the RECT
    //     /// </summary>
    //     public int left;

    //     /// <summary>
    //     /// Specifies the y-coordinate of the upper-left corner of the RECT
    //     /// </summary>
    //     public int top;

    //     /// <summary>
    //     /// Specifies the x-coordinate of the lower-right corner of the RECT
    //     /// </summary>
    //     public int right;

    //     /// <summary>
    //     /// Specifies the y-coordinate of the lower-right corner of the RECT
    //     /// </summary>
    //     public int bottom;


    //     /// <summary>
    //     /// Creates a new RECT struct with the specified location and size
    //     /// </summary>
    //     /// <param name="left">The x-coordinate of the upper-left corner of the RECT</param>
    //     /// <param name="top">The y-coordinate of the upper-left corner of the RECT</param>
    //     /// <param name="right">The x-coordinate of the lower-right corner of the RECT</param>
    //     /// <param name="bottom">The y-coordinate of the lower-right corner of the RECT</param>
    //     public RECT(int left, int top, int right, int bottom)
    //     {
    //         this.left = left;
    //         this.top = top;
    //         this.right = right;
    //         this.bottom = bottom;
    //     }


    //     /// <summary>
    //     /// Creates a new RECT struct from the specified Rectangle
    //     /// </summary>
    //     /// <param name="rect">The Rectangle to create the RECT from</param>
    //     /// <returns>A RECT struct with the same location and size as 
    //     /// the specified Rectangle</returns>
    //     public static RECT FromRectangle(Rectangle rect)
    //     {
    //         return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
    //     }


    //     /// <summary>
    //     /// Creates a new RECT struct with the specified location and size
    //     /// </summary>
    //     /// <param name="x">The x-coordinate of the upper-left corner of the RECT</param>
    //     /// <param name="y">The y-coordinate of the upper-left corner of the RECT</param>
    //     /// <param name="width">The width of the RECT</param>
    //     /// <param name="height">The height of the RECT</param>
    //     /// <returns>A RECT struct with the specified location and size</returns>
    //     public static RECT FromXYWH(int x, int y, int width, int height)
    //     {
    //         return new RECT(x, y, x + width, y + height);
    //     }


    //     /// <summary>
    //     /// Returns a Rectangle with the same location and size as the RECT
    //     /// </summary>
    //     /// <returns>A Rectangle with the same location and size as the RECT</returns>
    //     public Rectangle ToRectangle()
    //     {
    //         return new Rectangle(this.left, this.top, this.right - this.left, this.bottom - this.top);
    //     }
    // }


    // /// <summary>
    // /// Receives dynamic-link library (DLL)-specific version information. 
    // /// It is used with the DllGetVersion function
    // /// </summary>
    // [Serializable(),
    // StructLayout(LayoutKind.Sequential)]
    // public struct DLLVERSIONINFO
    // {
    //     /// <summary>
    //     /// Size of the structure, in bytes. This member must be filled 
    //     /// in before calling the function
    //     /// </summary>
    //     public int cbSize;

    //     /// <summary>
    //     /// Major version of the DLL. If the DLL's version is 4.0.950, 
    //     /// this value will be 4
    //     /// </summary>
    //     public int dwMajorVersion;

    //     /// <summary>
    //     /// Minor version of the DLL. If the DLL's version is 4.0.950, 
    //     /// this value will be 0
    //     /// </summary>
    //     public int dwMinorVersion;

    //     /// <summary>
    //     /// Build number of the DLL. If the DLL's version is 4.0.950, 
    //     /// this value will be 950
    //     /// </summary>
    //     public int dwBuildNumber;

    //     /// <summary>
    //     /// Identifies the platform for which the DLL was built
    //     /// </summary>
    //     public int dwPlatformID;
    // }


    // /// <summary>
    // /// 
    // /// </summary>
    // [StructLayout(LayoutKind.Sequential, Pack = 2)]
    // internal struct ICONFILE
    // {
    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     public short reserved;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     public short resourceType;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     public short iconCount;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     public ICONENTRY entries;
    // }


    // /// <summary>
    // /// 
    // /// </summary>
    // [StructLayout(LayoutKind.Sequential)]
    // internal struct ICONENTRY
    // {
    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     public byte width;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     public byte height;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     public byte numColors;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     public byte reserved;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     public short numPlanes;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     public short bitsPerPixel;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     public int dataSize;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     public int dataOffset;
    // }

    // #endregion



    // #region Flags

    // #region Window Messages

    // /// <summary>
    // /// The WindowMessageFlags enemeration contains Windows messages that the 
    // /// XPExplorerBar may be interested in listening for
    // /// </summary>
    // public enum WindowMessageFlags
    // {
    //     /// <summary>
    //     /// The WM_PRINT message is sent to a window to request that it draw 
    //     /// itself in the specified device context, most commonly in a printer 
    //     /// device context
    //     /// </summary>
    //     WM_PRINT = 791,

    //     /// <summary>
    //     /// The WM_PRINTCLIENT message is sent to a window to request that it draw 
    //     /// its client area in the specified device context, most commonly in a 
    //     /// printer device context
    //     /// </summary>
    //     WM_PRINTCLIENT = 792,
    // }

    // #endregion

    // #region WmPrint

    // /// <summary>
    // /// The WmPrintFlags enemeration contains flags that may be sent 
    // /// when a WM_PRINT or WM_PRINTCLIENT message is recieved
    // /// </summary>
    // public enum WmPrintFlags
    // {
    //     /// <summary>
    //     /// Draws the window only if it is visible
    //     /// </summary>
    //     PRF_CHECKVISIBLE = 1,

    //     /// <summary>
    //     /// Draws the nonclient area of the window
    //     /// </summary>
    //     PRF_NONCLIENT = 2,

    //     /// <summary>
    //     /// Draws the client area of the window
    //     /// </summary>
    //     PRF_CLIENT = 4,

    //     /// <summary>
    //     /// Erases the background before drawing the window
    //     /// </summary>
    //     PRF_ERASEBKGND = 8,

    //     /// <summary>
    //     /// Draws all visible children windows
    //     /// </summary>
    //     PRF_CHILDREN = 16,

    //     /// <summary>
    //     /// Draws all owned windows
    //     /// </summary>
    //     PRF_OWNED = 32
    // }

    // #endregion

    // #region LoadLibraryEx

    // /// <summary>
    // /// The LoadLibraryExFlags enemeration contains flags that control 
    // /// how a .dll file is loaded with the NativeMethods.LoadLibraryEx 
    // /// function
    // /// </summary>
    // public enum LoadLibraryExFlags
    // {
    //     /// <summary>
    //     /// If this value is used, and the executable module is a DLL, 
    //     /// the system does not call DllMain for process and thread 
    //     /// initialization and termination. Also, the system does not 
    //     /// load additional executable modules that are referenced by 
    //     /// the specified module. If this value is not used, and the 
    //     /// executable module is a DLL, the system calls DllMain for 
    //     /// process and thread initialization and termination. The system 
    //     /// loads additional executable modules that are referenced by 
    //     /// the specified module
    //     /// </summary>
    //     DONT_RESOLVE_DLL_REFERENCES = 1,

    //     /// <summary>
    //     /// If this value is used, the system maps the file into the calling 
    //     /// process's virtual address space as if it were a data file. Nothing 
    //     /// is done to execute or prepare to execute the mapped file. Use 
    //     /// this flag when you want to load a DLL only to extract messages 
    //     /// or resources from it
    //     /// </summary>
    //     LOAD_LIBRARY_AS_DATAFILE = 2,

    //     /// <summary>
    //     /// If this value is used, and lpFileName specifies a path, the 
    //     /// system uses the alternate file search strategy to find associated 
    //     /// executable modules that the specified module causes to be loaded. 
    //     /// If this value is not used, or if lpFileName does not specify a 
    //     /// path, the system uses the standard search strategy to find 
    //     /// associated executable modules that the specified module causes 
    //     /// to be loaded
    //     /// </summary>
    //     LOAD_WITH_ALTERED_SEARCH_PATH = 8,

    //     /// <summary>
    //     /// If this value is used, the system does not perform automatic 
    //     /// trust comparisons on the DLL or its dependents when they are 
    //     /// loaded
    //     /// </summary>
    //     LOAD_IGNORE_CODE_AUTHZ_LEVEL = 16
    // }

    // #endregion

    // #region SetErrorMode

    // /// <summary>
    // /// The SetErrorModeFlags enemeration contains flags that control 
    // /// whether the system will handle the specified types of serious errors, 
    // /// or whether the process will handle them
    // /// </summary>
    // public enum SetErrorModeFlags
    // {
    //     /// <summary>
    //     /// Use the system default, which is to display all error dialog boxes
    //     /// </summary>
    //     SEM_DEFAULT = 0,

    //     /// <summary>
    //     /// The system does not display the critical-error-handler message box. 
    //     /// Instead, the system sends the error to the calling process
    //     /// </summary>
    //     SEM_FAILCRITICALERRORS = 1,

    //     /// <summary>
    //     /// The system does not display the general-protection-fault message box. 
    //     /// This flag should only be set by debugging applications that handle 
    //     /// general protection (GP) faults themselves with an exception handler
    //     /// </summary>
    //     SEM_NOGPFAULTERRORBOX = 2,

    //     /// <summary>
    //     /// After this value is set for a process, subsequent attempts to clear 
    //     /// the value are ignored. 64-bit Windows:  The system automatically fixes 
    //     /// memory alignment faults and makes them invisible to the application. 
    //     /// It does this for the calling process and any descendant processes
    //     /// </summary>
    //     SEM_NOALIGNMENTFAULTEXCEPT = 4,

    //     /// <summary>
    //     /// The system does not display a message box when it fails to find a 
    //     /// file. Instead, the error is returned to the calling process
    //     /// </summary>
    //     SEM_NOOPENFILEERRORBOX = 32768
    // }

    // #endregion

    // #region DrawTextFlags

    // /// <summary>
    // /// 
    // /// </summary>
    // public enum DrawTextFlags
    // {
    //     /// <summary>
    //     /// Justifies the text to the top of the rectangle.
    //     /// </summary>
    //     DT_TOP = 0x00000000,

    //     /// <summary>
    //     /// Aligns text to the left.
    //     /// </summary>
    //     DT_LEFT = 0x00000000,

    //     /// <summary>
    //     /// Centers text horizontally in the rectangle
    //     /// </summary>
    //     DT_CENTER = 0x00000001,

    //     /// <summary>
    //     /// Aligns text to the right
    //     /// </summary>
    //     DT_RIGHT = 0x00000002,

    //     /// <summary>
    //     /// Centers text vertically. This value is used only with the DT_SINGLELINE value
    //     /// </summary>
    //     DT_VCENTER = 0x00000004,

    //     /// <summary>
    //     /// Justifies the text to the bottom of the rectangle. This value is used 
    //     /// only with the DT_SINGLELINE value
    //     /// </summary>
    //     DT_BOTTOM = 0x00000008,

    //     /// <summary>
    //     /// Breaks words. Lines are automatically broken between words if a word would 
    //     /// extend past the edge of the rectangle specified by the lpRect parameter. A 
    //     /// carriage return-line feed sequence also breaks the line. If this is not 
    //     /// specified, output is on one line
    //     /// </summary>
    //     DT_WORDBREAK = 0x00000010,

    //     /// <summary>
    //     /// Displays text on a single line only. Carriage returns and line feeds do not 
    //     /// break the line
    //     /// </summary>
    //     DT_SINGLELINE = 0x00000020,

    //     /// <summary>
    //     /// Expands tab characters. The default number of characters per tab is eight. 
    //     /// The DT_WORD_ELLIPSIS, DT_PATH_ELLIPSIS, and DT_END_ELLIPSIS values cannot be 
    //     /// used with the DT_EXPANDTABS value
    //     /// </summary>
    //     DT_EXPANDTABS = 0x00000040,

    //     /// <summary>
    //     /// Sets tab stops. Bits 15–8 (high-order byte of the low-order word) of the uFormat 
    //     /// parameter specify the number of characters for each tab. The default number of 
    //     /// characters per tab is eight. The DT_CALCRECT, DT_EXTERNALLEADING, DT_INTERNAL, 
    //     /// DT_NOCLIP, and DT_NOPREFIX values cannot be used with the DT_TABSTOP value
    //     /// </summary>
    //     DT_TABSTOP = 0x00000080,

    //     /// <summary>
    //     /// Draws without clipping. DrawText is somewhat faster when DT_NOCLIP is used
    //     /// </summary>
    //     DT_NOCLIP = 0x00000100,

    //     /// <summary>
    //     /// Includes the font external leading in line height. Normally, external leading 
    //     /// is not included in the height of a line of text
    //     /// </summary>
    //     DT_EXTERNALLEADING = 0x00000200,

    //     /// <summary>
    //     /// Determines the width and height of the rectangle. If there are multiple lines 
    //     /// of text, DrawText uses the width of the rectangle pointed to by the lpRect 
    //     /// parameter and extends the base of the rectangle to bound the last line of text. 
    //     /// If the largest word is wider than the rectangle, the width is expanded. If the 
    //     /// text is less than the width of the rectangle, the width is reduced. If there is 
    //     /// only one line of text, DrawText modifies the right side of the rectangle so that 
    //     /// it bounds the last character in the line. In either case, DrawText returns the 
    //     /// height of the formatted text but does not draw the text
    //     /// </summary>
    //     DT_CALCRECT = 0x00000400,

    //     /// <summary>
    //     /// Turns off processing of prefix characters. Normally, DrawText interprets the 
    //     /// mnemonic-prefix character &amp; as a directive to underscore the character that 
    //     /// follows, and the mnemonic-prefix characters &amp;&amp; as a directive to print a 
    //     /// single &amp;. By specifying DT_NOPREFIX, this processing is turned off
    //     /// </summary>
    //     DT_NOPREFIX = 0x00000800,

    //     /// <summary>
    //     /// Uses the system font to calculate text metrics
    //     /// </summary>
    //     DT_INTERNAL = 0x00001000,

    //     /// <summary>
    //     /// Duplicates the text-displaying characteristics of a multiline edit control. 
    //     /// Specifically, the average character width is calculated in the same manner as 
    //     /// for an edit control, and the function does not display a partially visible last 
    //     /// line
    //     /// </summary>
    //     DT_EDITCONTROL = 0x00002000,

    //     /// <summary>
    //     /// For displayed text, replaces characters in the middle of the string with ellipses 
    //     /// so that the result fits in the specified rectangle. If the string contains backslash 
    //     /// (\) characters, DT_PATH_ELLIPSIS preserves as much as possible of the text after 
    //     /// the last backslash. The string is not modified unless the DT_MODIFYSTRING flag is 
    //     /// specified
    //     /// </summary>
    //     DT_PATH_ELLIPSIS = 0x00004000,

    //     /// <summary>
    //     /// For displayed text, if the end of a string does not fit in the rectangle, it is 
    //     /// truncated and ellipses are added. If a word that is not at the end of the string 
    //     /// goes beyond the limits of the rectangle, it is truncated without ellipses. The 
    //     /// string is not modified unless the DT_MODIFYSTRING flag is specified
    //     /// </summary>
    //     DT_END_ELLIPSIS = 0x00008000,

    //     /// <summary>
    //     /// Modifies the specified string to match the displayed text. This value has no effect 
    //     /// unless DT_END_ELLIPSIS or DT_PATH_ELLIPSIS is specified
    //     /// </summary>
    //     DT_MODIFYSTRING = 0x00010000,

    //     /// <summary>
    //     /// Layout in right-to-left reading order for bi-directional text when the font selected 
    //     /// into the hdc is a Hebrew or Arabic font. The default reading order for all text is 
    //     /// left-to-right
    //     /// </summary>
    //     DT_RTLREADING = 0x00020000,

    //     /// <summary>
    //     /// Truncates any word that does not fit in the rectangle and adds ellipses
    //     /// </summary>
    //     DT_WORD_ELLIPSIS = 0x00040000
    // }

    // #endregion

    // #endregion

    // #endregion

    // #region Task Item

    // #region TaskItem

    // /// <summary>
    // /// A Label-like Control used to display text and/or an 
    // /// Image in an Expando
    // /// </summary>
    // [ToolboxItem(true),
    // DesignerAttribute(typeof(TaskItemDesigner))]
    // public class TaskItem : Button
    // {
    //     #region Event Handlers

    //     /// <summary>
    //     /// Occurs when a value in the CustomSettings proterty changes
    //     /// </summary>
    //     public event EventHandler CustomSettingsChanged;

    //     #endregion


    //     #region Class Data

    //     /// <summary>
    //     /// System defined settings for the TaskItem
    //     /// </summary>
    //     private ExplorerBarInfo systemSettings;

    //     /// <summary>
    //     /// The Expando the TaskItem belongs to
    //     /// </summary>
    //     private Expando expando;

    //     /// <summary>
    //     /// The cached preferred width of the TaskItem
    //     /// </summary>
    //     private int preferredWidth;

    //     /// <summary>
    //     /// The cached preferred height of the TaskItem
    //     /// </summary>
    //     private int preferredHeight;

    //     /// <summary>
    //     /// The focus state of the TaskItem
    //     /// </summary>
    //     private FocusStates focusState;

    //     /// <summary>
    //     /// The rectangle where the TaskItems text is drawn
    //     /// </summary>
    //     private Rectangle textRect;

    //     /// <summary>
    //     /// Specifies whether the TaskItem should draw a focus rectangle 
    //     /// when it has focus
    //     /// </summary>
    //     private bool showFocusCues;

    //     /// <summary>
    //     /// Specifies the custom settings for the TaskItem
    //     /// </summary>
    //     private TaskItemInfo customSettings;

    //     /// <summary>
    //     /// Specifies whether the TaskItem's text should be drawn and measured 
    //     /// using GDI instead of GDI+
    //     /// </summary>
    //     private bool useGdiText;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     private StringFormat stringFormat;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     private DrawTextFlags drawTextFlags;

    //     #endregion


    //     #region Constructor

    //     /// <summary>
    //     /// Initializes a new instance of the TaskItem class with default settings
    //     /// </summary>
    //     public TaskItem() : base()
    //     {
    //         // set control styles
    //         this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    //         this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    //         this.SetStyle(ControlStyles.UserPaint, true);
    //         this.SetStyle(ControlStyles.Selectable, true);

    //         this.TabStop = true;

    //         this.BackColor = Color.Transparent;

    //         // get the system theme settings
    //         this.systemSettings = ThemeManager.GetSystemExplorerBarSettings();

    //         this.customSettings = new TaskItemInfo();
    //         this.customSettings.TaskItem = this;
    //         this.customSettings.SetDefaultEmptyValues();

    //         // preferred size
    //         this.preferredWidth = -1;
    //         this.preferredHeight = -1;

    //         // unfocused item
    //         this.focusState = FocusStates.None;

    //         this.Cursor = Cursors.Hand;

    //         this.textRect = new Rectangle();
    //         this.TextAlign = System.Drawing.ContentAlignment.TopLeft;

    //         this.showFocusCues = false;
    //         this.useGdiText = false;

    //         this.InitStringFormat();
    //         this.InitDrawTextFlags();
    //     }

    //     #endregion


    //     #region Properties

    //     #region Colors

    //     /// <summary>
    //     /// Gets the color of the TaskItem's text
    //     /// </summary>
    //     [Browsable(false)]
    //     public Color LinkColor
    //     {
    //         get
    //         {
    //             if (this.CustomSettings.LinkColor != Color.Empty)
    //             {
    //                 return this.CustomSettings.LinkColor;
    //             }

    //             return this.systemSettings.TaskItem.LinkColor;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the color of the TaskItem's text when highlighted.
    //     /// </summary>
    //     [Browsable(false)]
    //     public Color LinkHotColor
    //     {
    //         get
    //         {
    //             if (this.CustomSettings.HotLinkColor != Color.Empty)
    //             {
    //                 return this.CustomSettings.HotLinkColor;
    //             }

    //             return this.systemSettings.TaskItem.HotLinkColor;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the current color of the TaskItem's text
    //     /// </summary>
    //     [Browsable(false)]
    //     public Color FocusLinkColor
    //     {
    //         get
    //         {
    //             if (this.FocusState == FocusStates.Mouse)
    //             {
    //                 return this.LinkHotColor;
    //             }

    //             return this.LinkColor;
    //         }
    //     }

    //     #endregion

    //     #region Expando

    //     /// <summary>
    //     /// Gets or sets the Expando the TaskItem belongs to
    //     /// </summary>
    //     [Browsable(false),
    //     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //     public Expando Expando
    //     {
    //         get
    //         {
    //             return this.expando;
    //         }

    //         set
    //         {
    //             this.expando = value;

    //             if (value != null)
    //             {
    //                 this.SystemSettings = this.expando.SystemSettings;
    //             }
    //         }
    //     }

    //     #endregion

    //     #region FlatStyle

    //     /// <summary>
    //     /// Overrides Button.FlatStyle
    //     /// </summary>
    //     public new FlatStyle FlatStyle
    //     {
    //         get
    //         {
    //             throw new NotSupportedException();
    //         }

    //         set
    //         {
    //             throw new NotSupportedException();
    //         }
    //     }

    //     #endregion

    //     #region Focus

    //     /// <summary>
    //     /// Gets or sets a value indicating whether the TaskItem should
    //     /// display focus rectangles
    //     /// </summary>
    //     [Category("Appearance"),
    //     DefaultValue(false),
    //     Description("Determines whether the TaskItem should display a focus rectangle.")]
    //     public new bool ShowFocusCues
    //     {
    //         get
    //         {
    //             return this.showFocusCues;
    //         }

    //         set
    //         {
    //             if (this.showFocusCues != value)
    //             {
    //                 this.showFocusCues = value;

    //                 if (this.Focused)
    //                 {
    //                     this.Invalidate();
    //                 }
    //             }
    //         }
    //     }

    //     #endregion

    //     #region Fonts

    //     /// <summary>
    //     /// Gets the decoration to be used on the text when the TaskItem is 
    //     /// in a highlighted state 
    //     /// </summary>
    //     [Browsable(false)]
    //     public FontStyle FontDecoration
    //     {
    //         get
    //         {
    //             if (this.CustomSettings.FontDecoration != FontStyle.Underline)
    //             {
    //                 return this.CustomSettings.FontDecoration;
    //             }

    //             return this.systemSettings.TaskItem.FontDecoration;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the font of the text displayed by the TaskItem
    //     /// </summary>
    //     public override Font Font
    //     {
    //         get
    //         {
    //             if (this.FocusState == FocusStates.Mouse)
    //             {
    //                 return new Font(base.Font.Name, base.Font.SizeInPoints, this.FontDecoration);
    //             }

    //             return base.Font;
    //         }

    //         set
    //         {
    //             base.Font = value;
    //         }
    //     }

    //     #endregion

    //     #region Images

    //     /// <summary>
    //     /// Gets or sets the Image displayed by the TaskItem
    //     /// </summary>
    //     public new Image Image
    //     {
    //         get
    //         {
    //             return base.Image;
    //         }

    //         set
    //         {
    //             // make sure the image is 16x16
    //             if (value != null && (value.Width != 16 || value.Height != 16))
    //             {
    //                 Bitmap bitmap = new Bitmap(value, 16, 16);

    //                 base.Image = bitmap;
    //             }
    //             else
    //             {
    //                 base.Image = value;
    //             }

    //             // invalidate the preferred size cache
    //             this.preferredWidth = -1;
    //             this.preferredHeight = -1;

    //             this.textRect.Width = 0;
    //             this.textRect.Height = 0;

    //             if (this.Expando != null)
    //             {
    //                 this.Expando.DoLayout();
    //             }

    //             this.Invalidate();
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the ImageList that contains the images to 
    //     /// display in the TaskItem
    //     /// </summary>
    //     public new ImageList ImageList
    //     {
    //         get
    //         {
    //             return base.ImageList;
    //         }

    //         set
    //         {
    //             // make sure the images inside the ImageList are 16x16
    //             if (value != null && (value.ImageSize.Width != 16 || value.ImageSize.Height != 16))
    //             {
    //                 // make a copy of the imagelist and resize all the images
    //                 ImageList imageList = new ImageList();
    //                 imageList.ColorDepth = value.ColorDepth;
    //                 imageList.TransparentColor = value.TransparentColor;
    //                 imageList.ImageSize = new Size(16, 16);

    //                 foreach (Image image in value.Images)
    //                 {
    //                     Bitmap bitmap = new Bitmap(image, 16, 16);

    //                     imageList.Images.Add(bitmap);
    //                 }

    //                 base.ImageList = imageList;
    //             }
    //             else
    //             {
    //                 base.ImageList = value;
    //             }

    //             // invalidate the preferred size cache
    //             this.preferredWidth = -1;
    //             this.preferredHeight = -1;

    //             this.textRect.Width = 0;
    //             this.textRect.Height = 0;

    //             if (this.Expando != null)
    //             {
    //                 this.Expando.DoLayout();
    //             }

    //             this.Invalidate();
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the index value of the image displayed on the TaskItem
    //     /// </summary>
    //     public new int ImageIndex
    //     {
    //         get
    //         {
    //             return base.ImageIndex;
    //         }

    //         set
    //         {
    //             base.ImageIndex = value;

    //             // invalidate the preferred size cache
    //             this.preferredWidth = -1;
    //             this.preferredHeight = -1;

    //             this.textRect.Width = 0;
    //             this.textRect.Height = 0;

    //             if (this.Expando != null)
    //             {
    //                 this.Expando.DoLayout();
    //             }

    //             this.Invalidate();
    //         }
    //     }

    //     #endregion

    //     #region Margins

    //     /// <summary>
    //     /// Gets the amount of space between individual TaskItems 
    //     /// along each side of the TaskItem
    //     /// </summary>
    //     [Browsable(false)]
    //     public new Margin Margin
    //     {
    //         get
    //         {
    //             if (this.CustomSettings.Margin != Margin.Empty)
    //             {
    //                 return this.CustomSettings.Margin;
    //             }

    //             return this.systemSettings.TaskItem.Margin;
    //         }
    //     }

    //     #endregion

    //     #region Padding

    //     /// <summary>
    //     /// Gets the amount of space around the text along each 
    //     /// side of the TaskItem
    //     /// </summary>
    //     [Browsable(false)]
    //     public new Padding Padding
    //     {
    //         get
    //         {
    //             if (this.CustomSettings.Padding != Padding.Empty)
    //             {
    //                 return this.CustomSettings.Padding;
    //             }

    //             return this.systemSettings.TaskItem.Padding;
    //         }
    //     }

    //     #endregion

    //     #region Preferred Size

    //     /// <summary>
    //     /// Gets the preferred width of the TaskItem.
    //     /// Assumes that the text is required to fit on a single line
    //     /// </summary>
    //     [Browsable(false)]
    //     public int PreferredWidth
    //     {
    //         get
    //         {
    //             //
    //             if (this.preferredWidth != -1)
    //             {
    //                 return this.preferredWidth;
    //             }

    //             //
    //             if (this.Text.Length == 0)
    //             {
    //                 this.preferredWidth = 0;

    //                 return 0;
    //             }

    //             using (Graphics g = this.CreateGraphics())
    //             {
    //                 if (this.UseGdiText)
    //                 {
    //                     this.preferredWidth = this.CalcGdiPreferredWidth(g);
    //                 }
    //                 else
    //                 {
    //                     this.preferredWidth = this.CalcGdiPlusPreferredWidth(g);
    //                 }
    //             }

    //             return this.preferredWidth;
    //         }
    //     }


    //     /// <summary>
    //     /// Calculates the preferred width of the TaskItem using GDI+
    //     /// </summary>
    //     /// <param name="g">The Graphics used to measure the TaskItem</param>
    //     /// <returns>The preferred width of the TaskItem</returns>
    //     protected int CalcGdiPlusPreferredWidth(Graphics g)
    //     {
    //         SizeF size = g.MeasureString(this.Text, this.Font, new SizeF(0, 0), this.StringFormat);

    //         int width = (int)Math.Ceiling(size.Width) + 18 + this.Padding.Left + this.Padding.Right;

    //         return width;
    //     }


    //     /// <summary>
    //     /// Calculates the preferred width of the TaskItem using GDI
    //     /// </summary>
    //     /// <param name="g">The Graphics used to measure the TaskItem</param>
    //     /// <returns>The preferred width of the TaskItem</returns>
    //     protected int CalcGdiPreferredWidth(Graphics g)
    //     {
    //         IntPtr hdc = g.GetHdc();

    //         int width = 0;

    //         if (hdc != IntPtr.Zero)
    //         {
    //             IntPtr hFont = this.Font.ToHfont();
    //             IntPtr oldFont = NativeMethods.SelectObject(hdc, hFont);

    //             RECT rect = new RECT();

    //             NativeMethods.DrawText(hdc, this.Text, this.Text.Length, ref rect, DrawTextFlags.DT_CALCRECT | this.DrawTextFlags);

    //             width = rect.right - rect.left + 18 + this.Padding.Left + this.Padding.Right;

    //             NativeMethods.SelectObject(hdc, oldFont);
    //             NativeMethods.DeleteObject(hFont);
    //         }
    //         else
    //         {
    //             width = this.CalcGdiPlusPreferredWidth(g);
    //         }

    //         g.ReleaseHdc(hdc);

    //         return width;
    //     }


    //     /// <summary>
    //     /// Gets the preferred height of the TaskItem.
    //     /// Assumes that the text is required to fit within the
    //     /// current width of the TaskItem
    //     /// </summary>
    //     [Browsable(false)]
    //     public int PreferredHeight
    //     {
    //         get
    //         {
    //             //
    //             if (this.preferredHeight != -1)
    //             {
    //                 return this.preferredHeight;
    //             }

    //             //
    //             if (this.Text.Length == 0)
    //             {
    //                 return 16;
    //             }

    //             int textHeight = 0;

    //             using (Graphics g = this.CreateGraphics())
    //             {
    //                 if (this.UseGdiText)
    //                 {
    //                     textHeight = this.CalcGdiPreferredHeight(g);
    //                 }
    //                 else
    //                 {
    //                     textHeight = this.CalcGdiPlusPreferredHeight(g);
    //                 }
    //             }

    //             //
    //             if (textHeight > 16)
    //             {
    //                 this.preferredHeight = textHeight;
    //             }
    //             else
    //             {
    //                 this.preferredHeight = 16;
    //             }

    //             return this.preferredHeight;
    //         }
    //     }


    //     /// <summary>
    //     /// Calculates the preferred height of the TaskItem using GDI+
    //     /// </summary>
    //     /// <param name="g">The Graphics used to measure the TaskItem</param>
    //     /// <returns>The preferred height of the TaskItem</returns>
    //     protected int CalcGdiPlusPreferredHeight(Graphics g)
    //     {
    //         //
    //         int width = this.Width - this.Padding.Right;

    //         if (this.Image != null)
    //         {
    //             width -= 16 + this.Padding.Left;
    //         }

    //         //
    //         SizeF size = g.MeasureString(this.Text, this.Font, width, this.StringFormat);

    //         //
    //         int height = (int)Math.Ceiling(size.Height);

    //         return height;
    //     }


    //     /// <summary>
    //     /// Calculates the preferred height of the TaskItem using GDI
    //     /// </summary>
    //     /// <param name="g">The Graphics used to measure the TaskItem</param>
    //     /// <returns>The preferred height of the TaskItem</returns>
    //     protected int CalcGdiPreferredHeight(Graphics g)
    //     {
    //         IntPtr hdc = g.GetHdc();

    //         int height = 0;

    //         if (hdc != IntPtr.Zero)
    //         {
    //             IntPtr hFont = this.Font.ToHfont();
    //             IntPtr oldFont = NativeMethods.SelectObject(hdc, hFont);

    //             RECT rect = new RECT();

    //             int width = this.Width - this.Padding.Right;

    //             if (this.Image != null)
    //             {
    //                 width -= 16 + this.Padding.Left;
    //             }

    //             rect.right = width;

    //             NativeMethods.DrawText(hdc, this.Text, this.Text.Length, ref rect, DrawTextFlags.DT_CALCRECT | this.DrawTextFlags);

    //             height = rect.bottom - rect.top;

    //             NativeMethods.SelectObject(hdc, oldFont);
    //             NativeMethods.DeleteObject(hFont);
    //         }
    //         else
    //         {
    //             height = this.CalcGdiPlusPreferredHeight(g);
    //         }

    //         g.ReleaseHdc(hdc);

    //         return height;
    //     }


    //     /// <summary>
    //     /// This member overrides Button.DefaultSize
    //     /// </summary>
    //     [Browsable(false)]
    //     protected override Size DefaultSize
    //     {
    //         get
    //         {
    //             return new Size(162, 16);
    //         }
    //     }

    //     #endregion

    //     #region State

    //     /// <summary>
    //     /// Gets or sets whether the TaskItem is in a highlighted state.
    //     /// </summary>
    //     protected FocusStates FocusState
    //     {
    //         get
    //         {
    //             return this.focusState;
    //         }

    //         set
    //         {
    //             if (this.focusState != value)
    //             {
    //                 this.focusState = value;

    //                 this.Invalidate();
    //             }
    //         }
    //     }

    //     #endregion

    //     #region System Settings

    //     /// <summary>
    //     /// Gets or sets System settings for the TaskItem
    //     /// </summary>
    //     [Browsable(false)]
    //     protected internal ExplorerBarInfo SystemSettings
    //     {
    //         get
    //         {
    //             return this.systemSettings;
    //         }

    //         set
    //         {
    //             // make sure we have a new value
    //             if (this.systemSettings != value)
    //             {
    //                 this.SuspendLayout();

    //                 // get rid of the old settings
    //                 this.systemSettings = null;

    //                 // set the new settings
    //                 this.systemSettings = value;

    //                 this.ResumeLayout(true);
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the custom settings for the TaskItem
    //     /// </summary>
    //     [Category("Appearance"),
    //     Description(""),
    //     DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
    //     TypeConverter(typeof(TaskItemInfoConverter))]
    //     public TaskItemInfo CustomSettings
    //     {
    //         get
    //         {
    //             return this.customSettings;
    //         }
    //     }


    //     /// <summary>
    //     /// Resets the custom settings to their default values
    //     /// </summary>
    //     public void ResetCustomSettings()
    //     {
    //         this.CustomSettings.SetDefaultEmptyValues();

    //         this.FireCustomSettingsChanged(EventArgs.Empty);
    //     }

    //     #endregion

    //     #region Text

    //     /// <summary>
    //     /// Gets or sets the text associated with this TaskItem
    //     /// </summary>
    //     public override string Text
    //     {
    //         get
    //         {
    //             return base.Text;
    //         }

    //         set
    //         {
    //             base.Text = value;

    //             // reset the preferred width and height
    //             this.preferredHeight = -1;
    //             this.preferredWidth = -1;

    //             if (this.Expando != null)
    //             {
    //                 this.Expando.DoLayout();
    //             }

    //             this.Invalidate();
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets whether the TaskItem's text should be drawn 
    //     /// and measured using GDI instead of GDI+
    //     /// </summary>
    //     [Browsable(false),
    //     DefaultValue(false)]
    //     public bool UseGdiText
    //     {
    //         get
    //         {
    //             return this.useGdiText;
    //         }

    //         set
    //         {
    //             if (this.useGdiText != value)
    //             {
    //                 this.useGdiText = value;

    //                 // reset the preferred width and height
    //                 this.preferredHeight = -1;
    //                 this.preferredWidth = -1;

    //                 if (this.Expando != null)
    //                 {
    //                     this.Expando.DoLayout();
    //                 }

    //                 this.Invalidate();
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the alignment of the text on the TaskItem
    //     /// </summary>
    //     public override System.Drawing.ContentAlignment TextAlign
    //     {
    //         get
    //         {
    //             return base.TextAlign;
    //         }

    //         set
    //         {
    //             if (value != base.TextAlign)
    //             {
    //                 this.InitStringFormat();
    //                 this.InitDrawTextFlags();

    //                 // should the text be aligned to the left/center/right
    //                 switch (value)
    //                 {
    //                     case System.Drawing.ContentAlignment.MiddleLeft:
    //                     case System.Drawing.ContentAlignment.TopLeft:
    //                     case System.Drawing.ContentAlignment.BottomLeft:
    //                         {
    //                             this.stringFormat.Alignment = StringAlignment.Near;

    //                             this.drawTextFlags &= ~DrawTextFlags.DT_CENTER;
    //                             this.drawTextFlags &= ~DrawTextFlags.DT_RIGHT;
    //                             this.drawTextFlags |= DrawTextFlags.DT_LEFT;

    //                             break;
    //                         }

    //                     case System.Drawing.ContentAlignment.MiddleCenter:
    //                     case System.Drawing.ContentAlignment.TopCenter:
    //                     case System.Drawing.ContentAlignment.BottomCenter:
    //                         {
    //                             this.stringFormat.Alignment = StringAlignment.Center;

    //                             this.drawTextFlags &= ~DrawTextFlags.DT_LEFT;
    //                             this.drawTextFlags &= ~DrawTextFlags.DT_RIGHT;
    //                             this.drawTextFlags |= DrawTextFlags.DT_CENTER;

    //                             break;
    //                         }

    //                     case System.Drawing.ContentAlignment.MiddleRight:
    //                     case System.Drawing.ContentAlignment.TopRight:
    //                     case System.Drawing.ContentAlignment.BottomRight:
    //                         {
    //                             this.stringFormat.Alignment = StringAlignment.Far;

    //                             this.drawTextFlags &= ~DrawTextFlags.DT_LEFT;
    //                             this.drawTextFlags &= ~DrawTextFlags.DT_CENTER;
    //                             this.drawTextFlags |= DrawTextFlags.DT_RIGHT;

    //                             break;
    //                         }
    //                 }

    //                 base.TextAlign = value;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the StringFormat object used to draw the TaskItem's text
    //     /// </summary>
    //     protected StringFormat StringFormat
    //     {
    //         get
    //         {
    //             return this.stringFormat;
    //         }
    //     }


    //     /// <summary>
    //     /// Initializes the TaskItem's StringFormat object
    //     /// </summary>
    //     private void InitStringFormat()
    //     {
    //         if (this.stringFormat == null)
    //         {
    //             this.stringFormat = new StringFormat();
    //             this.stringFormat.LineAlignment = StringAlignment.Near;
    //             this.stringFormat.Alignment = StringAlignment.Near;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the DrawTextFlags object used to draw the TaskItem's text
    //     /// </summary>
    //     protected DrawTextFlags DrawTextFlags
    //     {
    //         get
    //         {
    //             return this.drawTextFlags;
    //         }
    //     }


    //     /// <summary>
    //     /// Initializes the TaskItem's DrawTextFlags object
    //     /// </summary>
    //     private void InitDrawTextFlags()
    //     {
    //         if (this.drawTextFlags == (int)0)
    //         {
    //             this.drawTextFlags = (DrawTextFlags.DT_LEFT | DrawTextFlags.DT_TOP | DrawTextFlags.DT_WORDBREAK);
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Rectangle that the TaskItem's text is drawn in
    //     /// </summary>
    //     protected Rectangle TextRect
    //     {
    //         get
    //         {
    //             return this.textRect;
    //         }
    //     }

    //     #endregion

    //     #endregion


    //     #region Events

    //     #region Custom Settings

    //     /// <summary>
    //     /// Raises the CustomSettingsChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     internal void FireCustomSettingsChanged(EventArgs e)
    //     {
    //         if (this.Expando != null)
    //         {
    //             this.Expando.DoLayout();
    //         }

    //         this.Invalidate();

    //         this.OnCustomSettingsChanged(e);
    //     }


    //     /// <summary>
    //     /// Raises the CustomSettingsChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected virtual void OnCustomSettingsChanged(EventArgs e)
    //     {
    //         if (CustomSettingsChanged != null)
    //         {
    //             CustomSettingsChanged(this, e);
    //         }
    //     }

    //     #endregion

    //     #region Focus

    //     /// <summary>
    //     /// Raises the GotFocus event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnGotFocus(EventArgs e)
    //     {
    //         // if we get focus and our expando is collapsed, give
    //         // it focus instead
    //         if (this.Expando != null && this.Expando.Collapsed)
    //         {
    //             this.Expando.Select();
    //         }

    //         base.OnGotFocus(e);
    //     }


    //     /// <summary>
    //     /// Raises the VisibleChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnVisibleChanged(EventArgs e)
    //     {
    //         // if we become invisible and have focus, give the 
    //         // focus to our expando instead
    //         if (!this.Visible && this.Focused && this.Expando != null && this.Expando.Collapsed)
    //         {
    //             this.Expando.Select();
    //         }

    //         base.OnVisibleChanged(e);
    //     }

    //     #endregion

    //     #region Mouse

    //     /// <summary>
    //     /// Raises the MouseEnter event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnMouseEnter(EventArgs e)
    //     {
    //         base.OnMouseEnter(e);

    //         this.FocusState = FocusStates.Mouse;
    //     }


    //     /// <summary>
    //     /// Raises the MouseLeave event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnMouseLeave(EventArgs e)
    //     {
    //         base.OnMouseLeave(e);

    //         this.FocusState = FocusStates.None;
    //     }

    //     #endregion

    //     #region Paint

    //     /// <summary>
    //     /// Raises the PaintBackground event
    //     /// </summary>
    //     /// <param name="e">A PaintEventArgs that contains the event data</param>
    //     protected override void OnPaintBackground(PaintEventArgs e)
    //     {
    //         // don't let windows paint our background as it will be black
    //         // (we'll paint the background in OnPaint instead)
    //         //base.OnPaintBackground (pevent);
    //     }


    //     /// <summary>
    //     /// Raises the Paint event
    //     /// </summary>
    //     /// <param name="e">A PaintEventArgs that contains the event data</param>
    //     protected override void OnPaint(PaintEventArgs e)
    //     {
    //         base.OnPaintBackground(e);

    //         //base.OnPaint(e);

    //         // do we have an image to draw
    //         if (this.Image != null)
    //         {
    //             if (this.Enabled)
    //             {
    //                 if (this.RightToLeft == RightToLeft.Yes)
    //                 {
    //                     e.Graphics.DrawImage(this.Image, this.Width - 16, 0, 16, 16);
    //                 }
    //                 else
    //                 {
    //                     e.Graphics.DrawImage(this.Image, 0, 0, 16, 16);
    //                 }
    //             }
    //             else
    //             {
    //                 // fix: use ControlPaint.DrawImageDisabled() to draw 
    //                 //      the disabled image
    //                 //      Brad Jones (brad@bradjones.com)
    //                 //      26/08/2004
    //                 //      v1.3

    //                 if (this.RightToLeft == RightToLeft.Yes)
    //                 {
    //                     ControlPaint.DrawImageDisabled(e.Graphics, this.Image, this.Width - 16, 0, this.BackColor);
    //                 }
    //                 else
    //                 {
    //                     ControlPaint.DrawImageDisabled(e.Graphics, this.Image, 0, 0, this.BackColor);
    //                 }
    //             }
    //         }

    //         // do we have any text to draw
    //         if (this.Text.Length > 0)
    //         {
    //             if (this.textRect.Width == 0 && this.textRect.Height == 0)
    //             {
    //                 this.textRect.X = 0;
    //                 this.textRect.Y = 0;
    //                 this.textRect.Height = this.PreferredHeight;

    //                 if (this.RightToLeft == RightToLeft.Yes)
    //                 {
    //                     this.textRect.Width = this.Width - this.Padding.Right;

    //                     if (this.Image != null)
    //                     {
    //                         this.textRect.Width -= 16;
    //                     }
    //                 }
    //                 else
    //                 {
    //                     if (this.Image != null)
    //                     {
    //                         this.textRect.X = 16 + this.Padding.Left;
    //                     }

    //                     this.textRect.Width = this.Width - this.textRect.X - this.Padding.Right;
    //                 }
    //             }

    //             if (this.RightToLeft == RightToLeft.Yes)
    //             {
    //                 this.stringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
    //                 this.drawTextFlags |= DrawTextFlags.DT_RTLREADING;
    //             }
    //             else
    //             {
    //                 this.stringFormat.FormatFlags &= ~StringFormatFlags.DirectionRightToLeft;
    //                 this.drawTextFlags &= ~DrawTextFlags.DT_RTLREADING;
    //             }

    //             if (this.UseGdiText)
    //             {
    //                 this.DrawGdiText(e.Graphics);
    //             }
    //             else
    //             {
    //                 this.DrawText(e.Graphics);
    //             }
    //         }

    //         // check if windows will let us show a focus rectangle 
    //         // if we have focus
    //         if (this.Focused && base.ShowFocusCues)
    //         {
    //             if (this.ShowFocusCues)
    //             {
    //                 ControlPaint.DrawFocusRectangle(e.Graphics, this.ClientRectangle);
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="g"></param>
    //     protected void DrawText(Graphics g)
    //     {
    //         if (this.Enabled)
    //         {
    //             using (SolidBrush brush = new SolidBrush(this.FocusLinkColor))
    //             {
    //                 g.DrawString(this.Text, this.Font, brush, this.TextRect, this.StringFormat);
    //             }
    //         }
    //         else
    //         {
    //             // draw disable text the same way as a Label
    //             ControlPaint.DrawStringDisabled(g, this.Text, this.Font, this.DisabledColor, (RectangleF)this.TextRect, this.StringFormat);
    //         }
    //     }


    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="g"></param>
    //     protected void DrawGdiText(Graphics g)
    //     {
    //         IntPtr hdc = g.GetHdc();

    //         if (hdc != IntPtr.Zero)
    //         {
    //             IntPtr hFont = this.Font.ToHfont();
    //             IntPtr oldFont = NativeMethods.SelectObject(hdc, hFont);

    //             int oldBkMode = NativeMethods.SetBkMode(hdc, 1);

    //             if (this.Enabled)
    //             {
    //                 int oldColor = NativeMethods.SetTextColor(hdc, ColorTranslator.ToWin32(this.FocusLinkColor));

    //                 RECT rect = RECT.FromRectangle(this.TextRect);

    //                 NativeMethods.DrawText(hdc, this.Text, this.Text.Length, ref rect, this.DrawTextFlags);

    //                 NativeMethods.SetTextColor(hdc, oldColor);
    //             }
    //             else
    //             {
    //                 Rectangle layoutRectangle = this.TextRect;
    //                 layoutRectangle.Offset(1, 1);

    //                 Color color = ControlPaint.LightLight(this.DisabledColor);

    //                 int oldColor = NativeMethods.SetTextColor(hdc, ColorTranslator.ToWin32(color));
    //                 RECT rect = RECT.FromRectangle(layoutRectangle);
    //                 NativeMethods.DrawText(hdc, this.Text, this.Text.Length, ref rect, this.DrawTextFlags);

    //                 layoutRectangle.Offset(-1, -1);
    //                 color = ControlPaint.Dark(this.DisabledColor);

    //                 NativeMethods.SetTextColor(hdc, ColorTranslator.ToWin32(color));
    //                 rect = RECT.FromRectangle(layoutRectangle);
    //                 NativeMethods.DrawText(hdc, this.Text, this.Text.Length, ref rect, this.DrawTextFlags);

    //                 NativeMethods.SetTextColor(hdc, oldColor);
    //             }

    //             NativeMethods.SetBkMode(hdc, oldBkMode);
    //             NativeMethods.SelectObject(hdc, oldFont);
    //             NativeMethods.DeleteObject(hFont);
    //         }
    //         else
    //         {
    //             this.DrawText(g);
    //         }

    //         g.ReleaseHdc(hdc);
    //     }


    //     /// <summary>
    //     /// Calculates the disabled color for text when the control is disabled
    //     /// </summary>
    //     internal Color DisabledColor
    //     {
    //         get
    //         {
    //             if (this.BackColor.A != 0)
    //             {
    //                 return this.BackColor;
    //             }

    //             Color c = this.BackColor;

    //             for (Control control = this.Parent; (c.A == 0); control = control.Parent)
    //             {
    //                 if (control == null)
    //                 {
    //                     return SystemColors.Control;
    //                 }

    //                 c = control.BackColor;
    //             }

    //             return c;
    //         }
    //     }

    //     #endregion

    //     #region Size

    //     /// <summary>
    //     /// Raises the SizeChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnSizeChanged(EventArgs e)
    //     {
    //         base.OnSizeChanged(e);

    //         // invalidate the preferred size cache
    //         this.preferredWidth = -1;
    //         this.preferredHeight = -1;

    //         this.textRect.Width = 0;
    //         this.textRect.Height = 0;
    //     }

    //     #endregion

    //     #endregion


    //     #region TaskItemSurrogate

    //     /// <summary>
    //     /// A class that is serialized instead of a TaskItem (as 
    //     /// TaskItems contain objects that cause serialization problems)
    //     /// </summary>
    //     [Serializable()]
    //     public class TaskItemSurrogate : ISerializable
    //     {
    //         #region Class Data

    //         /// <summary>
    //         /// See TaskItem.Name.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public string Name;

    //         /// <summary>
    //         /// See TaskItem.Size.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public Size Size;

    //         /// <summary>
    //         /// See TaskItem.Location.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public Point Location;

    //         /// <summary>
    //         /// See TaskItem.BackColor.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public string BackColor;

    //         /// <summary>
    //         /// See TaskItem.CustomSettings.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public TaskItemInfo.TaskItemInfoSurrogate CustomSettings;

    //         /// <summary>
    //         /// See TaskItem.Text.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public string Text;

    //         /// <summary>
    //         /// See TaskItem.ShowFocusCues.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool ShowFocusCues;

    //         /// <summary>
    //         /// See TaskItem.Image.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("TaskItemImage", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] Image;

    //         /// <summary>
    //         /// See TaskItem.Enabled.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool Enabled;

    //         /// <summary>
    //         /// See TaskItem.Visible.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool Visible;

    //         /// <summary>
    //         /// See TaskItem.Anchor.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public AnchorStyles Anchor;

    //         /// <summary>
    //         /// See TaskItem.Dock.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public DockStyle Dock;

    //         /// <summary>
    //         /// See Font.Name.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public string FontName;

    //         /// <summary>
    //         /// See Font.Size.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public float FontSize;

    //         /// <summary>
    //         /// See Font.Style.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public FontStyle FontDecoration;

    //         /// <summary>
    //         /// See TaskItem.UseGdiText.  This member is not intended to 
    //         /// be used directly from your code.
    //         /// </summary>
    //         public bool UseGdiText;

    //         /// <summary>
    //         /// See Control.Tag.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("Tag", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] Tag;

    //         /// <summary>
    //         /// Version number of the surrogate.  This member is not intended 
    //         /// to be used directly from your code.
    //         /// </summary>
    //         public int Version = 3300;

    //         #endregion


    //         #region Constructor

    //         /// <summary>
    //         /// Initializes a new instance of the TaskItemSurrogate class with default settings
    //         /// </summary>
    //         public TaskItemSurrogate()
    //         {
    //             this.Name = null;

    //             this.Size = Size.Empty;
    //             this.Location = Point.Empty;

    //             this.BackColor = ThemeManager.ConvertColorToString(Color.Empty);

    //             this.CustomSettings = null;

    //             this.Text = null;
    //             this.ShowFocusCues = false;
    //             this.Image = new byte[0];

    //             this.Enabled = true;
    //             this.Visible = true;

    //             this.Anchor = AnchorStyles.None;
    //             this.Dock = DockStyle.None;

    //             this.FontName = null;
    //             this.FontSize = 8.25f;
    //             this.FontDecoration = FontStyle.Regular;
    //             this.UseGdiText = false;

    //             this.Tag = new byte[0];
    //         }

    //         #endregion


    //         #region Methods

    //         /// <summary>
    //         /// Populates the TaskItemSurrogate with data that is to be 
    //         /// serialized from the specified TaskItem
    //         /// </summary>
    //         /// <param name="taskItem">The TaskItem that contains the data 
    //         /// to be serialized</param>
    //         public void Load(TaskItem taskItem)
    //         {
    //             this.Name = taskItem.Name;
    //             this.Size = taskItem.Size;
    //             this.Location = taskItem.Location;

    //             this.BackColor = ThemeManager.ConvertColorToString(taskItem.BackColor);

    //             this.CustomSettings = new TaskItemInfo.TaskItemInfoSurrogate();
    //             this.CustomSettings.Load(taskItem.CustomSettings);

    //             this.Text = taskItem.Text;
    //             this.ShowFocusCues = taskItem.ShowFocusCues;
    //             this.Image = ThemeManager.ConvertImageToByteArray(taskItem.Image);

    //             this.Enabled = taskItem.Enabled;
    //             this.Visible = taskItem.Visible;

    //             this.Anchor = taskItem.Anchor;
    //             this.Dock = taskItem.Dock;

    //             this.FontName = taskItem.Font.FontFamily.Name;
    //             this.FontSize = taskItem.Font.SizeInPoints;
    //             this.FontDecoration = taskItem.Font.Style;
    //             this.UseGdiText = taskItem.UseGdiText;

    //             this.Tag = ThemeManager.ConvertObjectToByteArray(taskItem.Tag);
    //         }


    //         /// <summary>
    //         /// Returns a TaskItem that contains the deserialized TaskItemSurrogate data
    //         /// </summary>
    //         /// <returns>A TaskItem that contains the deserialized TaskItemSurrogate data</returns>
    //         public TaskItem Save()
    //         {
    //             TaskItem taskItem = new TaskItem();

    //             taskItem.Name = this.Name;
    //             taskItem.Size = this.Size;
    //             taskItem.Location = this.Location;

    //             taskItem.BackColor = ThemeManager.ConvertStringToColor(this.BackColor);

    //             taskItem.customSettings = this.CustomSettings.Save();
    //             taskItem.customSettings.TaskItem = taskItem;

    //             taskItem.Text = this.Text;
    //             taskItem.ShowFocusCues = this.ShowFocusCues;
    //             taskItem.Image = ThemeManager.ConvertByteArrayToImage(this.Image);

    //             taskItem.Enabled = this.Enabled;
    //             taskItem.Visible = this.Visible;

    //             taskItem.Anchor = this.Anchor;
    //             taskItem.Dock = this.Dock;

    //             taskItem.Font = new Font(this.FontName, this.FontSize, this.FontDecoration);
    //             taskItem.UseGdiText = this.UseGdiText;

    //             taskItem.Tag = ThemeManager.ConvertByteArrayToObject(this.Tag);

    //             return taskItem;
    //         }


    //         /// <summary>
    //         /// Populates a SerializationInfo with the data needed to serialize the TaskItemSurrogate
    //         /// </summary>
    //         /// <param name="info">The SerializationInfo to populate with data</param>
    //         /// <param name="context">The destination for this serialization</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         public void GetObjectData(SerializationInfo info, StreamingContext context)
    //         {
    //             info.AddValue("Version", this.Version);

    //             info.AddValue("Name", this.Name);
    //             info.AddValue("Size", this.Size);
    //             info.AddValue("Location", this.Location);

    //             info.AddValue("BackColor", this.BackColor);

    //             info.AddValue("CustomSettings", this.CustomSettings);

    //             info.AddValue("Text", this.Text);
    //             info.AddValue("ShowFocusCues", this.ShowFocusCues);
    //             info.AddValue("Image", this.Image);

    //             info.AddValue("Enabled", this.Enabled);
    //             info.AddValue("Visible", this.Visible);

    //             info.AddValue("Anchor", this.Anchor);
    //             info.AddValue("Dock", this.Dock);

    //             info.AddValue("FontName", this.FontName);
    //             info.AddValue("FontSize", this.FontSize);
    //             info.AddValue("FontDecoration", this.FontDecoration);
    //             info.AddValue("UseGdiText", this.UseGdiText);

    //             info.AddValue("Tag", this.Tag);
    //         }


    //         /// <summary>
    //         /// Initializes a new instance of the TaskItemSurrogate class using the information 
    //         /// in the SerializationInfo
    //         /// </summary>
    //         /// <param name="info">The information to populate the TaskItemSurrogate</param>
    //         /// <param name="context">The source from which the TaskItemSurrogate is deserialized</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         protected TaskItemSurrogate(SerializationInfo info, StreamingContext context) : base()
    //         {
    //             int version = info.GetInt32("Version");

    //             this.Name = info.GetString("Name");
    //             this.Size = (Size)info.GetValue("Size", typeof(Size));
    //             this.Location = (Point)info.GetValue("Location", typeof(Point));

    //             this.BackColor = info.GetString("BackColor");

    //             this.CustomSettings = (TaskItemInfo.TaskItemInfoSurrogate)info.GetValue("CustomSettings", typeof(TaskItemInfo.TaskItemInfoSurrogate));

    //             this.Text = info.GetString("Text");
    //             this.ShowFocusCues = info.GetBoolean("ShowFocusCues");
    //             this.Image = (byte[])info.GetValue("Image", typeof(byte[]));

    //             this.Enabled = info.GetBoolean("Enabled");
    //             this.Visible = info.GetBoolean("Visible");

    //             this.Anchor = (AnchorStyles)info.GetValue("Anchor", typeof(AnchorStyles));
    //             this.Dock = (DockStyle)info.GetValue("Dock", typeof(DockStyle));

    //             this.FontName = info.GetString("FontName");
    //             this.FontSize = info.GetSingle("FontSize");
    //             this.FontDecoration = (FontStyle)info.GetValue("FontDecoration", typeof(FontStyle));

    //             if (version >= 3300)
    //             {
    //                 this.UseGdiText = info.GetBoolean("UseGdiText");
    //             }

    //             this.Tag = (byte[])info.GetValue("Tag", typeof(byte[]));
    //         }

    //         #endregion
    //     }

    //     #endregion
    // }

    // #endregion



    // #region TaskItemDesigner

    // /// <summary>
    // /// A custom designer used by TaskItems to remove unwanted 
    // /// properties from the Property window in the designer
    // /// </summary>
    // internal class TaskItemDesigner : ControlDesigner
    // {
    //     /// <summary>
    //     /// Initializes a new instance of the TaskItemDesigner class
    //     /// </summary>
    //     public TaskItemDesigner()
    //     {

    //     }


    //     /// <summary>
    //     /// Adjusts the set of properties the component exposes through 
    //     /// a TypeDescriptor
    //     /// </summary>
    //     /// <param name="properties">An IDictionary containing the properties 
    //     /// for the class of the component</param>
    //     protected override void PreFilterProperties(IDictionary properties)
    //     {
    //         base.PreFilterProperties(properties);

    //         properties.Remove("BackgroundImage");
    //         properties.Remove("Cursor");
    //         properties.Remove("ForeColor");
    //         properties.Remove("FlatStyle");
    //     }
    // }

    // #endregion

    // #endregion

    // #region Task Pane


    // #region TaskPane

    // /// <summary>
    // /// A ScrollableControl that can contain Expandos
    // /// </summary>
    // [ToolboxItem(true),
    // DesignerAttribute(typeof(TaskPaneDesigner))]
    // public class TaskPane : ScrollableControl, ISupportInitialize
    // {
    //     #region Event Handlers

    //     /// <summary>
    //     /// Occurs when an Expando is added to the TaskPane
    //     /// </summary>
    //     public event ExpandoEventHandler ExpandoAdded;

    //     /// <summary>
    //     /// Occurs when an Expando is removed from the TaskPane
    //     /// </summary>
    //     public event ExpandoEventHandler ExpandoRemoved;

    //     /// <summary>
    //     /// Occurs when a value in the CustomSettings proterty changes
    //     /// </summary>
    //     public event EventHandler CustomSettingsChanged;

    //     #endregion


    //     #region Class Data

    //     /// <summary>
    //     /// Required designer variable.
    //     /// </summary>
    //     private System.ComponentModel.Container components = null;

    //     /// <summary>
    //     /// Internal list of Expandos contained in the TaskPane
    //     /// </summary>
    //     private TaskPane.ExpandoCollection expandoCollection;

    //     /// <summary>
    //     /// System defined settings for the TaskBar
    //     /// </summary>
    //     private ExplorerBarInfo systemSettings;

    //     /// <summary>
    //     /// Specifies whether the TaskPane is currently initialising
    //     /// </summary>
    //     private bool initialising;

    //     /// <summary>
    //     /// Specifies whether the TaskPane and its children should render 
    //     /// themselves using a theme similar to the Windows XP Classic theme
    //     /// </summary>
    //     private bool classicTheme;

    //     /// <summary>
    //     /// Specifies whether the TaskPane and its children should render 
    //     /// themselves using a non-official Windows XP theme
    //     /// </summary>
    //     private bool customTheme;

    //     /// <summary>
    //     /// A Rectangle that specifies the size and location of the watermark
    //     /// </summary>
    //     private Rectangle watermarkRect;

    //     /// <summary>
    //     /// Specifies whether the TaskPane is currently performing a 
    //     /// layout operation
    //     /// </summary>
    //     private bool layout;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     private int beginUpdateCount;

    //     /// <summary>
    //     /// Specifies the custom settings for the TaskPane
    //     /// </summary>
    //     private TaskPaneInfo customSettings;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     private bool allowExpandoDragging;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     private Point dropPoint;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     private Color dropIndicatorColor;

    //     #endregion


    //     #region Constructor

    //     /// <summary>
    //     /// Initializes a new instance of the TaskPane class with default settings
    //     /// </summary>
    //     public TaskPane()
    //     {
    //         // This call is required by the Windows.Forms Form Designer.
    //         components = new System.ComponentModel.Container();

    //         // set control styles
    //         this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    //         this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    //         this.SetStyle(ControlStyles.UserPaint, true);
    //         this.SetStyle(ControlStyles.ResizeRedraw, true);
    //         this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

    //         this.expandoCollection = new TaskPane.ExpandoCollection(this);

    //         // get the system theme settings
    //         this.systemSettings = ThemeManager.GetSystemExplorerBarSettings();

    //         this.customSettings = new TaskPaneInfo();
    //         this.customSettings.TaskPane = this;
    //         this.customSettings.SetDefaultEmptyValues();

    //         this.BackColor = this.systemSettings.TaskPane.GradientStartColor;
    //         this.BackgroundImage = this.BackImage;

    //         this.classicTheme = false;
    //         this.customTheme = false;

    //         // size
    //         int width = (this.systemSettings.TaskPane.Padding.Left +
    //             this.systemSettings.TaskPane.Padding.Right +
    //             this.systemSettings.Header.BackImageWidth);
    //         int height = width;
    //         this.Size = new Size(width, height);

    //         // setup sutoscrolling
    //         this.AutoScroll = false;
    //         this.AutoScrollMargin = new Size(this.systemSettings.TaskPane.Padding.Right,
    //             this.systemSettings.TaskPane.Padding.Bottom);

    //         // Listen for changes to the parent
    //         this.ParentChanged += new EventHandler(this.OnParentChanged);

    //         this.allowExpandoDragging = false;
    //         this.dropPoint = Point.Empty;
    //         this.dropIndicatorColor = Color.Red;

    //         this.beginUpdateCount = 0;

    //         this.initialising = false;
    //         this.layout = false;
    //     }

    //     #endregion


    //     #region Methods

    //     #region Appearance

    //     /// <summary>
    //     /// Forces the TaskPane and all it's Expandos to use a theme
    //     /// equivalent to Windows XPs classic theme 
    //     /// </summary>
    //     public void UseClassicTheme()
    //     {
    //         this.classicTheme = true;
    //         this.customTheme = false;

    //         ExplorerBarInfo settings = ThemeManager.GetSystemExplorerBarSettings(true);

    //         this.systemSettings.Dispose();
    //         this.systemSettings = null;

    //         this.SystemSettings = settings;
    //     }


    //     /// <summary>
    //     /// Forces the TaskPane and all it's Expandos to use the 
    //     /// specified theme
    //     /// </summary>
    //     /// <param name="stylePath">The path to the custom 
    //     /// shellstyle.dll to use</param>
    //     public void UseCustomTheme(string stylePath)
    //     {
    //         this.customTheme = true;
    //         this.classicTheme = false;

    //         ExplorerBarInfo settings = ThemeManager.GetSystemExplorerBarSettings(stylePath);

    //         this.systemSettings.Dispose();
    //         this.systemSettings = null;

    //         this.SystemSettings = settings;
    //     }


    //     /// <summary>
    //     /// Forces the TaskPane and all it's Expandos to use the 
    //     /// current system theme
    //     /// </summary>
    //     public void UseDefaultTheme()
    //     {
    //         this.customTheme = false;
    //         this.classicTheme = false;

    //         ExplorerBarInfo settings = ThemeManager.GetSystemExplorerBarSettings();

    //         this.systemSettings.Dispose();
    //         this.systemSettings = null;

    //         this.SystemSettings = settings;
    //     }

    //     #endregion

    //     #region Dispose

    //     /// <summary> 
    //     /// Releases the unmanaged resources used by the TaskPane and 
    //     /// optionally releases the managed resources
    //     /// </summary>
    //     /// <param name="disposing">True to release both managed and unmanaged 
    //     /// resources; false to release only unmanaged resources</param>
    //     protected override void Dispose(bool disposing)
    //     {
    //         if (disposing)
    //         {
    //             if (components != null)
    //             {
    //                 components.Dispose();
    //             }

    //             if (this.systemSettings != null)
    //             {
    //                 this.systemSettings.Dispose();
    //             }
    //         }

    //         base.Dispose(disposing);
    //     }

    //     #endregion

    //     #region Expandos

    //     /// <summary>
    //     /// Collaspes all the Expandos contained in the TaskPane
    //     /// </summary>
    //     // suggested by: PaleyX (jmpalethorpe@tiscali.co.uk)
    //     //               03/06/2004
    //     //               v1.1
    //     public void CollapseAll()
    //     {
    //         foreach (Expando expando in this.Expandos)
    //         {
    //             expando.Collapsed = true;
    //         }
    //     }


    //     /// <summary>
    //     /// Expands all the Expandos contained in the TaskPane
    //     /// </summary>
    //     // suggested by: PaleyX (jmpalethorpe@tiscali.co.uk)
    //     //               03/06/2004
    //     //               v1.1
    //     public void ExpandAll()
    //     {
    //         foreach (Expando expando in this.Expandos)
    //         {
    //             expando.Collapsed = false;
    //         }
    //     }


    //     /// <summary>
    //     /// Collaspes all the Expandos contained in the TaskPane, 
    //     /// except for the specified Expando which is expanded
    //     /// </summary>
    //     /// <param name="expando">The Expando that is to be expanded</param>
    //     // suggested by: PaleyX (jmpalethorpe@tiscali.co.uk)
    //     //               03/06/2004
    //     //               v1.1
    //     public void CollapseAllButOne(Expando expando)
    //     {
    //         foreach (Expando e in this.Expandos)
    //         {
    //             if (e != expando)
    //             {
    //                 e.Collapsed = true;
    //             }
    //             else
    //             {
    //                 expando.Collapsed = false;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Calculates the Point that the currently dragged Expando will 
    //     /// dropped at based on the specified mouse position
    //     /// </summary>
    //     /// <param name="point">The current position of the mouse in screen 
    //     /// co-ordinates</param>
    //     internal void UpdateDropPoint(Point point)
    //     {
    //         Point p = this.PointToClient(point);

    //         if (this.ClientRectangle.Contains(p))
    //         {
    //             if (p.Y <= this.Expandos[0].Top)
    //             {
    //                 this.dropPoint.Y = this.Padding.Top / 2;
    //             }
    //             else if (p.Y >= this.Expandos[this.Expandos.Count - 1].Bottom)
    //             {
    //                 this.dropPoint.Y = this.Expandos[this.Expandos.Count - 1].Bottom + (this.Padding.Top / 2);
    //             }
    //             else
    //             {
    //                 for (int i = 0; i < this.Expandos.Count; i++)
    //                 {
    //                     if (p.Y >= this.Expandos[i].Top && p.Y <= this.Expandos[i].Bottom)
    //                     {
    //                         if (p.Y <= this.Expandos[i].Top + (this.Expandos[i].Height / 2))
    //                         {
    //                             if (i == 0)
    //                             {
    //                                 this.dropPoint.Y = this.Padding.Top / 2;
    //                             }
    //                             else
    //                             {
    //                                 this.dropPoint.Y = this.Expandos[i].Top - ((this.Expandos[i].Top - this.Expandos[i - 1].Bottom) / 2);
    //                             }
    //                         }
    //                         else
    //                         {
    //                             if (i == this.Expandos.Count - 1)
    //                             {
    //                                 this.dropPoint.Y = this.Expandos[this.Expandos.Count - 1].Bottom + (this.Padding.Top / 2);
    //                             }
    //                             else
    //                             {
    //                                 this.dropPoint.Y = this.Expandos[i].Bottom + ((this.Expandos[i + 1].Top - this.Expandos[i].Bottom) / 2);
    //                             }
    //                         }

    //                         break;
    //                     }
    //                 }
    //             }
    //         }
    //         else
    //         {
    //             this.dropPoint = Point.Empty;
    //         }

    //         this.Invalidate(false);
    //     }


    //     /// <summary>
    //     /// "Drops" the specified Expando and moves it to the current drop point
    //     /// </summary>
    //     /// <param name="expando">The Expando to be "dropped"</param>
    //     internal void DropExpando(Expando expando)
    //     {
    //         if (this.dropPoint == Point.Empty)
    //         {
    //             return;
    //         }

    //         if (expando != null && expando.TaskPane == this)
    //         {
    //             int i = 0;
    //             int expandoIndex = this.Expandos.IndexOf(expando);

    //             for (; i < this.Expandos.Count; i++)
    //             {
    //                 if (this.dropPoint.Y <= this.Expandos[i].Top)
    //                 {
    //                     if (i > expandoIndex)
    //                     {
    //                         this.Expandos.Move(expando, i - 1);
    //                     }
    //                     else if (i < expandoIndex)
    //                     {
    //                         this.Expandos.Move(expando, i);
    //                     }

    //                     break;
    //                 }
    //             }

    //             if (i == this.Expandos.Count)
    //             {
    //                 this.Expandos.Move(expando, i);
    //             }
    //         }

    //         this.dropPoint = Point.Empty;

    //         this.Invalidate(false);
    //     }

    //     #endregion

    //     #region ISupportInitialize Members

    //     /// <summary>
    //     /// Signals the TaskPane that initialization is starting
    //     /// </summary>
    //     public void BeginInit()
    //     {
    //         this.initialising = true;
    //     }


    //     /// <summary>
    //     /// Signals the TaskPane that initialization is complete
    //     /// </summary>
    //     public void EndInit()
    //     {
    //         this.initialising = false;

    //         this.DoLayout();
    //     }


    //     /// <summary>
    //     /// Gets whether the TaskPane is currently initialising
    //     /// </summary>
    //     [Browsable(false)]
    //     public bool Initialising
    //     {
    //         get
    //         {
    //             return this.initialising;
    //         }
    //     }

    //     #endregion

    //     #region Layout

    //     // fix: Added BeginUpdate() and EndUpdate() so that DoLayout() 
    //     //      isn't called everytime something happens with Expandos
    //     //      Brian Nottingham (nottinbe@slu.edu)
    //     //      22/12/2004
    //     //      v3.0

    //     /// <summary>
    //     /// Prevents the TaskPane from drawing until the EndUpdate method is called
    //     /// </summary>
    //     public void BeginUpdate()
    //     {
    //         this.beginUpdateCount++;
    //     }


    //     /// <summary>
    //     /// Resumes drawing of the TaskPane after drawing is suspended by the 
    //     /// BeginUpdate method
    //     /// </summary>
    //     public void EndUpdate()
    //     {
    //         this.beginUpdateCount = Math.Max(this.beginUpdateCount--, 0);

    //         if (beginUpdateCount == 0)
    //         {
    //             this.DoLayout(true);
    //         }
    //     }


    //     /// <summary>
    //     /// Forces the TaskPane to apply layout logic to child Expandos, 
    //     /// and adjusts the Size and Location of the Expandos if necessary
    //     /// </summary>
    //     public void DoLayout()
    //     {
    //         this.DoLayout(false);
    //     }


    //     // fix: Added DoLayout(bool performRealLayout) to improve 
    //     //      TaskPane scroll behavior
    //     //      Jewlin (jewlin88@hotmail.com)
    //     //      22/10/2004
    //     //      v3.0

    //     /// <summary>
    //     /// Forces the TaskPane to apply layout logic to child Expandos, 
    //     /// and adjusts the Size and Location of the Expandos if necessary
    //     /// </summary>
    //     /// <param name="performRealLayout">true to execute pending layout 
    //     /// requests; otherwise, false</param>
    //     public void DoLayout(bool performRealLayout)
    //     {
    //         // fix: take into account beginUpdateCount
    //         //      Brian Nottingham (nottinbe@slu.edu)
    //         //      22/12/2004
    //         //      v3.0
    //         //if (this.layout)
    //         if (this.layout || this.beginUpdateCount > 0)
    //         {
    //             return;
    //         }

    //         this.layout = true;

    //         // stop the layout engine
    //         this.SuspendLayout();

    //         Expando e;
    //         Point p;

    //         // work out how wide to make the controls, and where
    //         // the top of the first control should be
    //         int y = this.DisplayRectangle.Y + this.Padding.Top;
    //         int width = this.ClientSize.Width - this.Padding.Left - this.Padding.Right;

    //         // for each control in our list...
    //         for (int i = 0; i < this.Expandos.Count; i++)
    //         {
    //             e = this.Expandos[i];

    //             // go to the next expando if this one is invisible and 
    //             // it's parent is visible
    //             if (!e.Visible && e.Parent != null && e.Parent.Visible)
    //             {
    //                 continue;
    //             }

    //             p = new Point(this.Padding.Left, y);

    //             // set the width and location of the control
    //             e.Location = p;
    //             e.Width = width;

    //             // update the next starting point
    //             y += e.Height + this.Padding.Bottom;
    //         }

    //         // restart the layout engine
    //         this.ResumeLayout(performRealLayout);

    //         this.layout = false;
    //     }


    //     /// <summary>
    //     /// Calculates where the specified Expando should be located
    //     /// </summary>
    //     /// <returns>A Point that specifies where the Expando should 
    //     /// be located</returns>
    //     protected internal Point CalcExpandoLocation(Expando target)
    //     {
    //         if (target == null)
    //         {
    //             throw new ArgumentNullException("target");
    //         }

    //         int targetIndex = this.Expandos.IndexOf(target);

    //         Expando e;
    //         Point p;

    //         int y = this.DisplayRectangle.Y + this.Padding.Top;
    //         int width = this.ClientSize.Width - this.Padding.Left - this.Padding.Right;

    //         for (int i = 0; i < targetIndex; i++)
    //         {
    //             e = this.Expandos[i];

    //             if (!e.Visible)
    //             {
    //                 continue;
    //             }

    //             p = new Point(this.Padding.Left, y);
    //             y += e.Height + this.Padding.Bottom;
    //         }

    //         return new Point(this.Padding.Left, y);
    //     }


    //     /// <summary>
    //     /// Updates the layout of the Expandos while in design mode, and 
    //     /// adds/removes Expandos from the ControlCollection as necessary
    //     /// </summary>
    //     internal void UpdateExpandos()
    //     {
    //         if (this.Expandos.Count == this.Controls.Count)
    //         {
    //             // make sure the the expandos index in the ControlCollection 
    //             // are the same as in the ExpandoCollection (indexes in the 
    //             // ExpandoCollection may have changed due to the user moving 
    //             // them around in the editor)
    //             this.MatchControlCollToExpandoColl();

    //             return;
    //         }

    //         // were any expandos added
    //         if (this.Expandos.Count > this.Controls.Count)
    //         {
    //             // add any extra expandos in the ExpandoCollection to the 
    //             // ControlCollection
    //             for (int i = 0; i < this.Expandos.Count; i++)
    //             {
    //                 if (!this.Controls.Contains(this.Expandos[i]))
    //                 {
    //                     this.OnExpandoAdded(new ExpandoEventArgs(this.Expandos[i]));
    //                 }
    //             }
    //         }
    //         else
    //         {
    //             // expandos were removed
    //             int i = 0;
    //             Expando expando;

    //             // remove any extra expandos from the ControlCollection
    //             while (i < this.Controls.Count)
    //             {
    //                 expando = (Expando)this.Controls[i];

    //                 if (!this.Expandos.Contains(expando))
    //                 {
    //                     this.OnExpandoRemoved(new ExpandoEventArgs(expando));
    //                 }
    //                 else
    //                 {
    //                     i++;
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Make sure the the expandos index in the ControlCollection 
    //     /// are the same as in the ExpandoCollection (indexes in the 
    //     /// ExpandoCollection may have changed due to the user moving 
    //     /// them around in the editor or calling ExpandoCollection.Move())
    //     /// </summary>
    //     internal void MatchControlCollToExpandoColl()
    //     {
    //         this.SuspendLayout();

    //         for (int i = 0; i < this.Expandos.Count; i++)
    //         {
    //             this.Controls.SetChildIndex(this.Expandos[i], i);
    //         }

    //         this.ResumeLayout(false);

    //         this.DoLayout(true);

    //         this.Invalidate(true);
    //     }

    //     #endregion

    //     #endregion


    //     #region Properties

    //     #region Colors

    //     /// <summary>
    //     /// Gets the first color of the TaskPane's background gradient fill.
    //     /// </summary>
    //     [Browsable(false)]
    //     public Color GradientStartColor
    //     {
    //         get
    //         {
    //             if (this.CustomSettings.GradientStartColor != Color.Empty)
    //             {
    //                 return this.CustomSettings.GradientStartColor;
    //             }

    //             return this.systemSettings.TaskPane.GradientStartColor;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the second color of the TaskPane's background gradient fill.
    //     /// </summary>
    //     [Browsable(false)]
    //     public Color GradientEndColor
    //     {
    //         get
    //         {
    //             if (this.CustomSettings.GradientEndColor != Color.Empty)
    //             {
    //                 return this.CustomSettings.GradientEndColor;
    //             }

    //             return this.systemSettings.TaskPane.GradientEndColor;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the direction of the TaskPane's background gradient fill.
    //     /// </summary>
    //     [Browsable(false)]
    //     public LinearGradientMode GradientDirection
    //     {
    //         get
    //         {
    //             if (this.CustomSettings.GradientStartColor != Color.Empty &&
    //                 this.CustomSettings.GradientEndColor != Color.Empty)
    //             {
    //                 return this.CustomSettings.GradientDirection;
    //             }

    //             return this.systemSettings.TaskPane.GradientDirection;
    //         }
    //     }

    //     #endregion

    //     #region Expandos

    //     /// <summary>
    //     /// A TaskPane.ExpandoCollection representing the collection of 
    //     /// Expandos contained within the TaskPane
    //     /// </summary>
    //     [Category("Behavior"),
    //     DefaultValue(null),
    //     Description("The Expandos contained in the TaskPane"),
    //     DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
    //     Editor(typeof(ExpandoCollectionEditor), typeof(UITypeEditor))]
    //     public TaskPane.ExpandoCollection Expandos
    //     {
    //         get
    //         {
    //             return this.expandoCollection;
    //         }
    //     }


    //     /// <summary>
    //     /// A Control.ControlCollection representing the collection of 
    //     /// controls contained within the control
    //     /// </summary>
    //     [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //     public new Control.ControlCollection Controls
    //     {
    //         get
    //         {
    //             return base.Controls;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets whether Expandos can be dragged around the TaskPane
    //     /// </summary>
    //     [Category("Behavior"),
    //     DefaultValue(false),
    //     Description("Indicates whether Expandos can be dragged around the TaskPane")]
    //     public bool AllowExpandoDragging
    //     {
    //         get
    //         {
    //             return this.allowExpandoDragging;
    //         }

    //         set
    //         {
    //             this.allowExpandoDragging = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets or sets the Color that the Expando drop point indicator is drawn in
    //     /// </summary>
    //     [Browsable(false),
    //     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //     public Color ExpandoDropIndicatorColor
    //     {
    //         get
    //         {
    //             return this.dropIndicatorColor;
    //         }

    //         set
    //         {
    //             this.dropIndicatorColor = value;
    //         }
    //     }

    //     #endregion

    //     #region Images

    //     /// <summary>
    //     /// Gets the Image used as the TaskPane's background
    //     /// </summary>
    //     [Browsable(false)]
    //     public Image BackImage
    //     {
    //         get
    //         {
    //             if (this.CustomSettings.BackImage != null)
    //             {
    //                 return this.CustomSettings.BackImage;
    //             }

    //             return this.systemSettings.TaskPane.BackImage;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets how the TaskPane's background Image is to be drawn
    //     /// </summary>
    //     [Browsable(false)]
    //     public ImageStretchMode StretchMode
    //     {
    //         get
    //         {
    //             if (this.CustomSettings.BackImage != null)
    //             {
    //                 return this.CustomSettings.StretchMode;
    //             }

    //             return this.systemSettings.TaskPane.StretchMode;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Image that is used as a watermark in the TaskPane's 
    //     /// client area
    //     /// </summary>
    //     [Browsable(false)]
    //     public Image Watermark
    //     {
    //         get
    //         {
    //             if (this.CustomSettings.Watermark != null)
    //             {
    //                 return this.CustomSettings.Watermark;
    //             }

    //             return this.systemSettings.TaskPane.Watermark;
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the alignment of the TaskPane's watermark
    //     /// </summary>
    //     [Browsable(false)]
    //     public System.Drawing.ContentAlignment WatermarkAlignment
    //     {
    //         get
    //         {
    //             if (this.CustomSettings.Watermark != null)
    //             {
    //                 return this.CustomSettings.WatermarkAlignment;
    //             }

    //             return this.systemSettings.TaskPane.WatermarkAlignment;
    //         }
    //     }

    //     #endregion

    //     #region Padding

    //     /// <summary>
    //     /// Gets the amount of space between the border and the 
    //     /// Expando's along each side of the TaskPane.
    //     /// </summary>
    //     [Browsable(false)]
    //     public new Padding Padding
    //     {
    //         get
    //         {
    //             if (this.CustomSettings.Padding != Padding.Empty)
    //             {
    //                 return this.CustomSettings.Padding;
    //             }

    //             return this.systemSettings.TaskPane.Padding;
    //         }
    //     }

    //     #endregion

    //     #region SystemSettings

    //     /// <summary>
    //     /// Gets or sets the system defined settings for the TaskPane
    //     /// </summary>
    //     protected internal ExplorerBarInfo SystemSettings
    //     {
    //         get
    //         {
    //             return this.systemSettings;
    //         }

    //         set
    //         {
    //             // ignore null values
    //             if (value == null)
    //             {
    //                 return;
    //             }

    //             if (this.systemSettings != value)
    //             {
    //                 this.SuspendLayout();

    //                 if (this.systemSettings != null)
    //                 {
    //                     this.systemSettings.Dispose();
    //                     this.systemSettings = null;
    //                 }

    //                 this.watermarkRect = Rectangle.Empty;

    //                 this.systemSettings = value;
    //                 this.BackColor = this.GradientStartColor;
    //                 this.BackgroundImage = this.BackImage;

    //                 foreach (Expando expando in this.Expandos)
    //                 {
    //                     expando.SystemSettings = this.systemSettings;
    //                     expando.DoLayout();
    //                 }

    //                 this.DoLayout();

    //                 this.ResumeLayout(true);

    //                 this.Invalidate(true);
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the custom settings for the TaskPane
    //     /// </summary>
    //     [Category("Appearance"),
    //     Description(""),
    //     DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
    //     TypeConverter(typeof(TaskPaneInfoConverter))]
    //     public TaskPaneInfo CustomSettings
    //     {
    //         get
    //         {
    //             return this.customSettings;
    //         }

    //         set
    //         {
    //             this.customSettings = value;
    //         }
    //     }


    //     /// <summary>
    //     /// Resets the custom settings to their default values
    //     /// </summary>
    //     public void ResetCustomSettings()
    //     {
    //         this.CustomSettings.SetDefaultEmptyValues();

    //         this.FireCustomSettingsChanged(EventArgs.Empty);
    //     }

    //     #endregion

    //     #endregion


    //     #region Events

    //     #region Controls

    //     /// <summary>
    //     /// Raises the ControlAdded event
    //     /// </summary>
    //     /// <param name="e">A ControlEventArgs that contains the event data</param>
    //     protected override void OnControlAdded(ControlEventArgs e)
    //     {
    //         // make sure the control is an Expando
    //         if ((e.Control as Expando) == null)
    //         {
    //             // remove the control
    //             this.Controls.Remove(e.Control);

    //             // throw a hissy fit
    //             throw new InvalidCastException("Only Expando's can be added to the TaskPane");
    //         }

    //         base.OnControlAdded(e);

    //         // add the expando to the ExpandoCollection if necessary
    //         if (!this.Expandos.Contains((Expando)e.Control))
    //         {
    //             this.Expandos.Add((Expando)e.Control);
    //         }
    //     }


    //     /// <summary>
    //     /// Raises the ControlRemoved event
    //     /// </summary>
    //     /// <param name="e">A ControlEventArgs that contains the event data</param>
    //     protected override void OnControlRemoved(ControlEventArgs e)
    //     {
    //         base.OnControlRemoved(e);

    //         // remove the control from the itemList
    //         if (this.Expandos.Contains(e.Control))
    //         {
    //             this.Expandos.Remove((Expando)e.Control);
    //         }

    //         // update the layout of the controls
    //         this.DoLayout();
    //     }

    //     #endregion

    //     #region Custom Settings

    //     /// <summary>
    //     /// Raises the CustomSettingsChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     internal void FireCustomSettingsChanged(EventArgs e)
    //     {
    //         this.BackColor = this.GradientStartColor;
    //         this.BackgroundImage = this.BackImage;

    //         this.DoLayout();

    //         this.Invalidate(true);

    //         this.OnCustomSettingsChanged(e);
    //     }


    //     /// <summary>
    //     /// Raises the CustomSettingsChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected virtual void OnCustomSettingsChanged(EventArgs e)
    //     {
    //         if (CustomSettingsChanged != null)
    //         {
    //             CustomSettingsChanged(this, e);
    //         }
    //     }

    //     #endregion

    //     #region Expandos

    //     /// <summary> 
    //     /// Event handler for the Expando StateChanged event
    //     /// </summary>
    //     /// <param name="sender">The object that fired the event</param>
    //     /// <param name="e">An ExpandoEventArgs that contains the event data</param>
    //     private void expando_StateChanged(object sender, ExpandoEventArgs e)
    //     {
    //         this.OnExpandoStateChanged(e);
    //     }


    //     /// <summary>
    //     /// Occurs when the value of an Expandos Collapsed property changes
    //     /// </summary>
    //     /// <param name="e">An ExpandoEventArgs that contains the event data</param>
    //     protected virtual void OnExpandoStateChanged(ExpandoEventArgs e)
    //     {
    //         this.DoLayout(true);
    //     }


    //     /// <summary>
    //     /// Raises the ExpandoAdded event
    //     /// </summary>
    //     /// <param name="e">An ExpandoEventArgs that contains the event data</param>
    //     protected virtual void OnExpandoAdded(ExpandoEventArgs e)
    //     {
    //         // add the expando to the ControlCollection if it hasn't already
    //         if (!this.Controls.Contains(e.Expando))
    //         {
    //             this.Controls.Add(e.Expando);
    //         }

    //         // set anchor styles
    //         e.Expando.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);

    //         // tell the Expando who's its daddy...
    //         e.Expando.TaskPane = this;
    //         e.Expando.SystemSettings = this.systemSettings;

    //         // listen for collapse/expand events
    //         e.Expando.StateChanged += new ExpandoEventHandler(this.expando_StateChanged);

    //         // update the layout of the controls
    //         this.DoLayout();

    //         //
    //         if (ExpandoAdded != null)
    //         {
    //             ExpandoAdded(this, e);
    //         }
    //     }


    //     /// <summary>
    //     /// Raises the ExpandoRemoved event
    //     /// </summary>
    //     /// <param name="e">An ExpandoEventArgs that contains the event data</param>
    //     protected virtual void OnExpandoRemoved(ExpandoEventArgs e)
    //     {
    //         // remove the control from the ControlCollection if it hasn't already
    //         if (this.Controls.Contains(e.Expando))
    //         {
    //             this.Controls.Remove(e.Expando);
    //         }

    //         // remove the StateChanged listener
    //         e.Expando.StateChanged -= new ExpandoEventHandler(this.expando_StateChanged);

    //         // update the layout of the controls
    //         this.DoLayout();

    //         //
    //         if (ExpandoRemoved != null)
    //         {
    //             ExpandoRemoved(this, e);
    //         }
    //     }

    //     #endregion

    //     #region Paint

    //     /// <summary> 
    //     /// Raises the PaintBackground event
    //     /// </summary>
    //     /// <param name="e">A PaintEventArgs that contains the event data</param>
    //     protected override void OnPaintBackground(PaintEventArgs e)
    //     {
    //         // paint background
    //         if (this.BackImage != null)
    //         {
    //             //base.OnPaintBackground(e);

    //             WrapMode wrap = WrapMode.Clamp;

    //             if ((this.StretchMode == ImageStretchMode.Tile) || (this.StretchMode == ImageStretchMode.Horizontal))
    //             {
    //                 wrap = WrapMode.Tile;
    //             }

    //             using (TextureBrush brush = new TextureBrush(this.BackImage, wrap))
    //             {
    //                 e.Graphics.FillRectangle(brush, this.DisplayRectangle);
    //             }
    //         }
    //         else
    //         {
    //             if (this.GradientStartColor != this.GradientEndColor)
    //             {
    //                 using (LinearGradientBrush brush = new LinearGradientBrush(this.DisplayRectangle,
    //                            this.GradientStartColor,
    //                            this.GradientEndColor,
    //                            this.GradientDirection))
    //                 {
    //                     e.Graphics.FillRectangle(brush, this.DisplayRectangle);
    //                 }
    //             }
    //             else
    //             {
    //                 using (SolidBrush brush = new SolidBrush(this.GradientStartColor))
    //                 {
    //                     e.Graphics.FillRectangle(brush, this.ClientRectangle);
    //                 }
    //             }
    //         }

    //         // draw the watermark if we have one
    //         if (this.Watermark != null)
    //         {
    //             Rectangle rect = new Rectangle(0, 0, this.Watermark.Width, this.Watermark.Height);

    //             // work out a rough location of where the watermark should go

    //             switch (this.WatermarkAlignment)
    //             {
    //                 case System.Drawing.ContentAlignment.BottomCenter:
    //                 case System.Drawing.ContentAlignment.BottomLeft:
    //                 case System.Drawing.ContentAlignment.BottomRight:
    //                     {
    //                         rect.Y = this.DisplayRectangle.Bottom - this.Watermark.Height;

    //                         break;
    //                     }

    //                 case System.Drawing.ContentAlignment.MiddleCenter:
    //                 case System.Drawing.ContentAlignment.MiddleLeft:
    //                 case System.Drawing.ContentAlignment.MiddleRight:
    //                     {
    //                         rect.Y = this.DisplayRectangle.Top + ((this.DisplayRectangle.Height - this.Watermark.Height) / 2);

    //                         break;
    //                     }
    //             }

    //             switch (this.WatermarkAlignment)
    //             {
    //                 case System.Drawing.ContentAlignment.BottomRight:
    //                 case System.Drawing.ContentAlignment.MiddleRight:
    //                 case System.Drawing.ContentAlignment.TopRight:
    //                     {
    //                         rect.X = this.ClientRectangle.Right - this.Watermark.Width;

    //                         break;
    //                     }

    //                 case System.Drawing.ContentAlignment.BottomCenter:
    //                 case System.Drawing.ContentAlignment.MiddleCenter:
    //                 case System.Drawing.ContentAlignment.TopCenter:
    //                     {
    //                         rect.X = this.ClientRectangle.Left + ((this.ClientRectangle.Width - this.Watermark.Width) / 2);

    //                         break;
    //                     }
    //             }

    //             // shrink the destination rect if necesary so that we
    //             // can see all of the image

    //             if (rect.X < 0)
    //             {
    //                 rect.X = 0;
    //             }

    //             if (rect.Width > this.ClientRectangle.Width)
    //             {
    //                 rect.Width = this.ClientRectangle.Width;
    //             }

    //             if (rect.Y < this.DisplayRectangle.Top)
    //             {
    //                 rect.Y = this.DisplayRectangle.Top;
    //             }

    //             if (rect.Height > this.DisplayRectangle.Height)
    //             {
    //                 rect.Height = this.DisplayRectangle.Height;
    //             }

    //             // draw the watermark
    //             e.Graphics.DrawImage(this.Watermark, rect);
    //         }
    //     }


    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="e"></param>
    //     protected override void OnPaint(PaintEventArgs e)
    //     {
    //         base.OnPaint(e);

    //         if (this.dropPoint != Point.Empty)
    //         {
    //             int width = this.ClientSize.Width - this.Padding.Left - this.Padding.Right;

    //             using (Brush brush = new SolidBrush(this.ExpandoDropIndicatorColor))
    //             {
    //                 e.Graphics.FillRectangle(brush, this.Padding.Left, this.dropPoint.Y, width, 1);

    //                 e.Graphics.FillPolygon(brush, new Point[] { new Point(this.Padding.Left, this.dropPoint.Y - 4),
    //                                                               new Point(this.Padding.Left + 4, this.dropPoint.Y),
    //                                                               new Point(this.Padding.Left, this.dropPoint.Y + 4)});

    //                 e.Graphics.FillPolygon(brush, new Point[] { new Point(this.Width - this.Padding.Right, this.dropPoint.Y - 4),
    //                                                               new Point(this.Width - this.Padding.Right - 4, this.dropPoint.Y),
    //                                                               new Point(this.Width - this.Padding.Right, this.dropPoint.Y + 4)});
    //             }
    //         }
    //     }

    //     #endregion

    //     #region Parents

    //     // fix: TaskPane will now perform a layout when its 
    //     //      parent becomes visible
    //     //      Brian Nottingham (nottinbe@slu.edu)
    //     //      22/12/2004
    //     //      v3.0

    //     /// <summary>
    //     /// Event handler for the ParentChanged event
    //     /// </summary>
    //     /// <param name="sender">The object that fired the event</param>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     private void OnParentChanged(object sender, EventArgs e)
    //     {
    //         if (this.Parent != null)
    //         {
    //             this.Parent.VisibleChanged += new EventHandler(this.OnParentVisibleChanged);
    //         }
    //     }


    //     /// <summary>
    //     /// Event handler for the ParentVisibleChanged event
    //     /// </summary>
    //     /// <param name="sender">The object that fired the event</param>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     private void OnParentVisibleChanged(object sender, EventArgs e)
    //     {
    //         if (sender != this.Parent)
    //         {
    //             ((Control)sender).VisibleChanged -= new EventHandler(this.OnParentVisibleChanged);

    //             return;
    //         }

    //         if (this.Parent.Visible)
    //         {
    //             this.DoLayout();
    //         }
    //     }

    //     #endregion

    //     #region System Colors

    //     /// <summary> 
    //     /// Raises the SystemColorsChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnSystemColorsChanged(EventArgs e)
    //     {
    //         base.OnSystemColorsChanged(e);

    //         // don't go any further if we are explicitly using
    //         // the classic or a custom theme
    //         if (this.classicTheme || this.customTheme)
    //         {
    //             return;
    //         }

    //         this.SuspendLayout();

    //         // get rid of the current system theme info
    //         this.systemSettings.Dispose();
    //         this.systemSettings = null;

    //         // get a new system theme info for the new theme
    //         this.systemSettings = ThemeManager.GetSystemExplorerBarSettings();

    //         this.BackgroundImage = this.BackImage;


    //         // update the system settings for each expando
    //         foreach (Control control in this.Controls)
    //         {
    //             if (control is Expando)
    //             {
    //                 Expando expando = (Expando)control;

    //                 expando.SystemSettings = this.systemSettings;
    //             }
    //         }

    //         // update the layout of the controls
    //         this.DoLayout();

    //         this.ResumeLayout(true);
    //     }

    //     #endregion

    //     #region Size

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="e"></param>
    //     protected override void OnSizeChanged(EventArgs e)
    //     {
    //         base.OnSizeChanged(e);

    //         this.DoLayout();
    //     }

    //     #endregion

    //     #endregion


    //     #region ExpandoCollection

    //     /// <summary>
    //     /// Represents a collection of Expando objects
    //     /// </summary>
    //     public class ExpandoCollection : CollectionBase
    //     {
    //         #region Class Data

    //         /// <summary>
    //         /// The TaskPane that owns this ExpandoCollection
    //         /// </summary>
    //         private TaskPane owner;

    //         #endregion


    //         #region Constructor

    //         /// <summary>
    //         /// Initializes a new instance of the TaskPane.ExpandoCollection class
    //         /// </summary>
    //         /// <param name="owner">A TaskPane representing the taskpane that owns 
    //         /// the Expando collection</param>
    //         public ExpandoCollection(TaskPane owner) : base()
    //         {
    //             if (owner == null)
    //             {
    //                 throw new ArgumentNullException("owner");
    //             }

    //             this.owner = owner;
    //         }

    //         #endregion


    //         #region Methods

    //         /// <summary>
    //         /// Adds the specified expando to the expando collection
    //         /// </summary>
    //         /// <param name="value">The Expando to add to the expando collection</param>
    //         public void Add(Expando value)
    //         {
    //             if (value == null)
    //             {
    //                 throw new ArgumentNullException("value");
    //             }

    //             this.List.Add(value);
    //             this.owner.Controls.Add(value);

    //             this.owner.OnExpandoAdded(new ExpandoEventArgs(value));
    //         }


    //         /// <summary>
    //         /// Adds an array of expando objects to the collection
    //         /// </summary>
    //         /// <param name="expandos">An array of Expando objects to add 
    //         /// to the collection</param>
    //         public void AddRange(Expando[] expandos)
    //         {
    //             if (expandos == null)
    //             {
    //                 throw new ArgumentNullException("expandos");
    //             }

    //             for (int i = 0; i < expandos.Length; i++)
    //             {
    //                 this.Add(expandos[i]);
    //             }
    //         }


    //         /// <summary>
    //         /// Removes all expandos from the collection
    //         /// </summary>
    //         public new void Clear()
    //         {
    //             while (this.Count > 0)
    //             {
    //                 this.RemoveAt(0);
    //             }
    //         }


    //         /// <summary>
    //         /// Determines whether the specified expando is a member of the 
    //         /// collection
    //         /// </summary>
    //         /// <param name="expando">The Expando to locate in the collection</param>
    //         /// <returns>true if the Expando is a member of the collection; 
    //         /// otherwise, false</returns>
    //         public bool Contains(Expando expando)
    //         {
    //             if (expando == null)
    //             {
    //                 throw new ArgumentNullException("expando");
    //             }

    //             return (this.IndexOf(expando) != -1);
    //         }


    //         /// <summary>
    //         /// Determines whether the specified control is a member of the 
    //         /// collection
    //         /// </summary>
    //         /// <param name="control">The Control to locate in the collection</param>
    //         /// <returns>true if the Control is a member of the collection; 
    //         /// otherwise, false</returns>
    //         public bool Contains(Control control)
    //         {
    //             if (!(control is Expando))
    //             {
    //                 return false;
    //             }

    //             return this.Contains((Expando)control);
    //         }


    //         /// <summary>
    //         /// Retrieves the index of the specified expando in the expando 
    //         /// collection
    //         /// </summary>
    //         /// <param name="expando">The Expando to locate in the collection</param>
    //         /// <returns>A zero-based index value that represents the position 
    //         /// of the specified Expando in the TaskPane.ExpandoCollection</returns>
    //         public int IndexOf(Expando expando)
    //         {
    //             if (expando == null)
    //             {
    //                 throw new ArgumentNullException("expando");
    //             }

    //             for (int i = 0; i < this.Count; i++)
    //             {
    //                 if (this[i] == expando)
    //                 {
    //                     return i;
    //                 }
    //             }

    //             return -1;
    //         }


    //         /// <summary>
    //         /// Removes the specified expando from the expando collection
    //         /// </summary>
    //         /// <param name="value">The Expando to remove from the 
    //         /// TaskPane.ExpandoCollection</param>
    //         public void Remove(Expando value)
    //         {
    //             if (value == null)
    //             {
    //                 throw new ArgumentNullException("value");
    //             }

    //             this.List.Remove(value);

    //             this.owner.Controls.Remove(value);

    //             this.owner.OnExpandoRemoved(new ExpandoEventArgs(value));
    //         }


    //         /// <summary>
    //         /// Removes an expando from the expando collection at the 
    //         /// specified indexed location
    //         /// </summary>
    //         /// <param name="index">The index value of the Expando to 
    //         /// remove</param>
    //         public new void RemoveAt(int index)
    //         {
    //             this.Remove(this[index]);
    //         }


    //         /// <summary>
    //         /// Moves the specified expando to the specified indexed location 
    //         /// in the expando collection
    //         /// </summary>
    //         /// <param name="value">The expando to be moved</param>
    //         /// <param name="index">The indexed location in the expando collection 
    //         /// that the specified expando will be moved to</param>
    //         public void Move(Expando value, int index)
    //         {
    //             if (value == null)
    //             {
    //                 throw new ArgumentNullException("value");
    //             }

    //             // make sure the index is within range
    //             if (index < 0)
    //             {
    //                 index = 0;
    //             }
    //             else if (index > this.Count)
    //             {
    //                 index = this.Count;
    //             }

    //             // don't go any further if the expando is already 
    //             // in the desired position or we don't contain it
    //             if (!this.Contains(value) || this.IndexOf(value) == index)
    //             {
    //                 return;
    //             }

    //             this.List.Remove(value);

    //             // if the index we're supposed to move the expando to
    //             // is now greater to the number of expandos contained, 
    //             // add it to the end of the list, otherwise insert it at 
    //             // the specified index
    //             if (index > this.Count)
    //             {
    //                 this.List.Add(value);
    //             }
    //             else
    //             {
    //                 this.List.Insert(index, value);
    //             }

    //             // re-layout the controls
    //             this.owner.MatchControlCollToExpandoColl();
    //         }


    //         /// <summary>
    //         /// Moves the specified expando to the top of the expando collection
    //         /// </summary>
    //         /// <param name="value">The expando to be moved</param>
    //         public void MoveToTop(Expando value)
    //         {
    //             this.Move(value, 0);
    //         }


    //         /// <summary>
    //         /// Moves the specified expando to the bottom of the expando collection
    //         /// </summary>
    //         /// <param name="value">The expando to be moved</param>
    //         public void MoveToBottom(Expando value)
    //         {
    //             this.Move(value, this.Count);
    //         }

    //         #endregion


    //         #region Properties

    //         /// <summary>
    //         /// The Expando located at the specified index location within 
    //         /// the expando collection
    //         /// </summary>
    //         /// <param name="index">The index of the expando to retrieve 
    //         /// from the expando collection</param>
    //         public virtual Expando this[int index]
    //         {
    //             get
    //             {
    //                 return this.List[index] as Expando;
    //             }
    //         }

    //         #endregion
    //     }

    //     #endregion


    //     #region ExpandoCollectionEditor

    //     /// <summary>
    //     /// A custom CollectionEditor for editing ExpandoCollections
    //     /// </summary>
    //     internal class ExpandoCollectionEditor : CollectionEditor
    //     {
    //         /// <summary>
    //         /// Initializes a new instance of the CollectionEditor class 
    //         /// using the specified collection type
    //         /// </summary>
    //         /// <param name="type"></param>
    //         public ExpandoCollectionEditor(Type type) : base(type)
    //         {

    //         }


    //         /// <summary>
    //         /// Edits the value of the specified object using the specified 
    //         /// service provider and context
    //         /// </summary>
    //         /// <param name="context">An ITypeDescriptorContext that can be 
    //         /// used to gain additional context information</param>
    //         /// <param name="isp">A service provider object through which 
    //         /// editing services can be obtained</param>
    //         /// <param name="value">The object to edit the value of</param>
    //         /// <returns>The new value of the object. If the value of the 
    //         /// object has not changed, this should return the same object 
    //         /// it was passed</returns>
    //         public override object EditValue(ITypeDescriptorContext context, IServiceProvider isp, object value)
    //         {
    //             TaskPane originalControl = (TaskPane)context.Instance;

    //             object returnObject = base.EditValue(context, isp, value);

    //             originalControl.UpdateExpandos();

    //             return returnObject;
    //         }


    //         /// <summary>
    //         /// Creates a new instance of the specified collection item type
    //         /// </summary>
    //         /// <param name="itemType">The type of item to create</param>
    //         /// <returns>A new instance of the specified object</returns>
    //         protected override object CreateInstance(Type itemType)
    //         {
    //             object expando = base.CreateInstance(itemType);

    //             ((Expando)expando).Name = "expando";

    //             return expando;
    //         }
    //     }

    //     #endregion


    //     #region TaskPaneSurrogate

    //     /// <summary>
    //     /// A class that is serialized instead of a TaskPane (as 
    //     /// TaskPanes contain objects that cause serialization problems)
    //     /// </summary>
    //     //[Serializable(),
    //     //    XmlRoot("TaskPaneSurrogate", Namespace = "", IsNullable = false)]
    //     public class TaskPaneSurrogate : ISerializable
    //     {
    //         #region Class Data

    //         /// <summary>
    //         /// See TaskPane.Name.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public string Name;

    //         /// <summary>
    //         /// See TaskPane.Size.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public Size Size;

    //         /// <summary>
    //         /// See TaskPane.Location.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public Point Location;

    //         /// <summary>
    //         /// See TaskPane.BackColor.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public string BackColor;

    //         /// <summary>
    //         /// See TaskPane.CustomSettings.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public TaskPaneInfo.TaskPaneInfoSurrogate CustomSettings;

    //         /// <summary>
    //         /// See TaskPane.AutoScroll.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool AutoScroll;

    //         /// <summary>
    //         /// See TaskPane.AutoScrollMargin.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public Size AutoScrollMargin;

    //         /// <summary>
    //         /// See TaskPane.Enabled.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool Enabled;

    //         /// <summary>
    //         /// See TaskPane.Visible.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool Visible;

    //         /// <summary>
    //         /// See TaskPane.Anchor.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public AnchorStyles Anchor;

    //         /// <summary>
    //         /// See TaskPane.Dock.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public DockStyle Dock;

    //         /// <summary>
    //         /// See Font.Name.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public string FontName;

    //         /// <summary>
    //         /// See Font.Size.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public float FontSize;

    //         /// <summary>
    //         /// See Font.Style.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public FontStyle FontDecoration;

    //         /// <summary>
    //         /// See TaskPane.Expandos.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         //[XmlArray("Expandos"), XmlArrayItem("ExpandoSurrogate", typeof(Expando.ExpandoSurrogate))]
    //         public ArrayList Expandos;

    //         /// <summary>
    //         /// See Control.Tag.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         //[XmlElementAttribute("Tag", typeof(Byte[]), DataType = "base64Binary")]
    //         public byte[] Tag;

    //         /// <summary>
    //         /// See TaskPane.AllowExpandoDragging.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public bool AllowExpandoDragging;

    //         /// <summary>
    //         /// See TaskPane.ExpandoDropIndicatorColor.  This member is not intended to be used 
    //         /// directly from your code.
    //         /// </summary>
    //         public string ExpandoDropIndicatorColor;

    //         /// <summary>
    //         /// Version number of the surrogate.  This member is not intended 
    //         /// to be used directly from your code.
    //         /// </summary>
    //         public int Version = 3300;

    //         #endregion


    //         #region Constructor

    //         /// <summary>
    //         /// Initializes a new instance of the TaskPaneSurrogate class with default settings
    //         /// </summary>
    //         public TaskPaneSurrogate()
    //         {
    //             this.Name = null;

    //             this.Size = Size.Empty;
    //             this.Location = Point.Empty;

    //             this.BackColor = ThemeManager.ConvertColorToString(SystemColors.Control);

    //             this.CustomSettings = null;

    //             this.AutoScroll = false;
    //             this.AutoScrollMargin = Size.Empty;

    //             this.Enabled = true;
    //             this.Visible = true;

    //             this.Anchor = AnchorStyles.None;
    //             this.Dock = DockStyle.None;

    //             this.FontName = "Tahoma";
    //             this.FontSize = 8.25f;
    //             this.FontDecoration = FontStyle.Regular;

    //             this.Tag = new byte[0];

    //             this.AllowExpandoDragging = false;
    //             this.ExpandoDropIndicatorColor = ThemeManager.ConvertColorToString(Color.Red);

    //             this.Expandos = new ArrayList();
    //         }

    //         #endregion


    //         #region Methods

    //         /// <summary>
    //         /// Populates the TaskPaneSurrogate with data that is to be 
    //         /// serialized from the specified TaskPane
    //         /// </summary>
    //         /// <param name="taskPane">The TaskPane that contains the data 
    //         /// to be serialized</param>
    //         public void Load(TaskPane taskPane)
    //         {
    //             this.Name = taskPane.Name;
    //             this.Size = taskPane.Size;
    //             this.Location = taskPane.Location;

    //             this.BackColor = ThemeManager.ConvertColorToString(taskPane.BackColor);

    //             this.CustomSettings = new TaskPaneInfo.TaskPaneInfoSurrogate();
    //             this.CustomSettings.Load(taskPane.CustomSettings);

    //             this.AutoScroll = taskPane.AutoScroll;
    //             this.AutoScrollMargin = taskPane.AutoScrollMargin;

    //             this.Enabled = taskPane.Enabled;
    //             this.Visible = taskPane.Visible;

    //             this.Anchor = taskPane.Anchor;
    //             this.Dock = taskPane.Dock;

    //             this.FontName = taskPane.Font.FontFamily.Name;
    //             this.FontSize = taskPane.Font.SizeInPoints;
    //             this.FontDecoration = taskPane.Font.Style;

    //             this.AllowExpandoDragging = taskPane.AllowExpandoDragging;
    //             this.ExpandoDropIndicatorColor = ThemeManager.ConvertColorToString(taskPane.ExpandoDropIndicatorColor);

    //             this.Tag = ThemeManager.ConvertObjectToByteArray(taskPane.Tag);

    //             foreach (Expando expando in taskPane.Expandos)
    //             {
    //                 Expando.ExpandoSurrogate es = new Expando.ExpandoSurrogate();

    //                 es.Load(expando);

    //                 this.Expandos.Add(es);
    //             }
    //         }


    //         /// <summary>
    //         /// Returns a TaskPane that contains the deserialized TaskPaneSurrogate data
    //         /// </summary>
    //         /// <returns>A TaskPane that contains the deserialized TaskPaneSurrogate data</returns>
    //         public TaskPane Save()
    //         {
    //             TaskPane taskPane = new TaskPane();
    //             ((ISupportInitialize)taskPane).BeginInit();
    //             taskPane.SuspendLayout();

    //             taskPane.Name = this.Name;
    //             taskPane.Size = this.Size;
    //             taskPane.Location = this.Location;

    //             taskPane.BackColor = ThemeManager.ConvertStringToColor(this.BackColor);

    //             taskPane.customSettings = this.CustomSettings.Save();
    //             taskPane.customSettings.TaskPane = taskPane;

    //             taskPane.AutoScroll = this.AutoScroll;
    //             taskPane.AutoScrollMargin = this.AutoScrollMargin;

    //             taskPane.Enabled = this.Enabled;
    //             taskPane.Visible = this.Visible;

    //             taskPane.Anchor = this.Anchor;
    //             taskPane.Dock = this.Dock;

    //             taskPane.Font = new Font(this.FontName, this.FontSize, this.FontDecoration);

    //             taskPane.Tag = ThemeManager.ConvertByteArrayToObject(this.Tag);

    //             taskPane.AllowExpandoDragging = this.AllowExpandoDragging;
    //             taskPane.ExpandoDropIndicatorColor = ThemeManager.ConvertStringToColor(this.ExpandoDropIndicatorColor);

    //             foreach (Object o in this.Expandos)
    //             {
    //                 Expando e = ((Expando.ExpandoSurrogate)o).Save();

    //                 taskPane.Expandos.Add(e);
    //             }

    //             ((ISupportInitialize)taskPane).EndInit();
    //             taskPane.ResumeLayout(false);

    //             return taskPane;
    //         }


    //         /// <summary>
    //         /// Populates a SerializationInfo with the data needed to serialize the TaskPaneSurrogate
    //         /// </summary>
    //         /// <param name="info">The SerializationInfo to populate with data</param>
    //         /// <param name="context">The destination for this serialization</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         public void GetObjectData(SerializationInfo info, StreamingContext context)
    //         {
    //             info.AddValue("Version", this.Version);

    //             info.AddValue("Name", this.Name);
    //             info.AddValue("Size", this.Size);
    //             info.AddValue("Location", this.Location);

    //             info.AddValue("BackColor", this.BackColor);

    //             info.AddValue("CustomSettings", this.CustomSettings);

    //             info.AddValue("AutoScroll", this.AutoScroll);
    //             info.AddValue("AutoScrollMargin", this.AutoScrollMargin);

    //             info.AddValue("Enabled", this.Enabled);
    //             info.AddValue("Visible", this.Visible);

    //             info.AddValue("Anchor", this.Anchor);
    //             info.AddValue("Dock", this.Dock);

    //             info.AddValue("FontName", this.FontName);
    //             info.AddValue("FontSize", this.FontSize);
    //             info.AddValue("FontDecoration", this.FontDecoration);

    //             info.AddValue("AllowExpandoDragging", this.AllowExpandoDragging);
    //             info.AddValue("ExpandoDropIndicatorColor", this.ExpandoDropIndicatorColor);

    //             info.AddValue("Tag", this.Tag);

    //             info.AddValue("Expandos", this.Expandos);
    //         }


    //         /// <summary>
    //         /// Initializes a new instance of the TaskPaneSurrogate class using the information 
    //         /// in the SerializationInfo
    //         /// </summary>
    //         /// <param name="info">The information to populate the TaskPaneSurrogate</param>
    //         /// <param name="context">The source from which the TaskPaneSurrogate is deserialized</param>
    //         [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
    //         protected TaskPaneSurrogate(SerializationInfo info, StreamingContext context) : base()
    //         {
    //             int version = info.GetInt32("Version");

    //             this.Name = info.GetString("Name");
    //             this.Size = (Size)info.GetValue("Size", typeof(Size));
    //             this.Location = (Point)info.GetValue("Location", typeof(Point));

    //             this.BackColor = info.GetString("BackColor");

    //             this.CustomSettings = (TaskPaneInfo.TaskPaneInfoSurrogate)info.GetValue("CustomSettings", typeof(TaskPaneInfo.TaskPaneInfoSurrogate));

    //             this.AutoScroll = info.GetBoolean("AutoScroll");
    //             this.AutoScrollMargin = (Size)info.GetValue("AutoScrollMargin", typeof(Size));

    //             this.Enabled = info.GetBoolean("Enabled");
    //             this.Visible = info.GetBoolean("Visible");

    //             this.Anchor = (AnchorStyles)info.GetValue("Anchor", typeof(AnchorStyles));
    //             this.Dock = (DockStyle)info.GetValue("Dock", typeof(DockStyle));

    //             this.FontName = info.GetString("FontName");
    //             this.FontSize = info.GetSingle("FontSize");
    //             this.FontDecoration = (FontStyle)info.GetValue("FontDecoration", typeof(FontStyle));

    //             if (version >= 3300)
    //             {
    //                 this.AllowExpandoDragging = info.GetBoolean("AllowExpandoDragging");
    //                 this.ExpandoDropIndicatorColor = info.GetString("ExpandoDropIndicatorColor");
    //             }

    //             this.Tag = (byte[])info.GetValue("Tag", typeof(byte[]));

    //             this.Expandos = (ArrayList)info.GetValue("Expandos", typeof(ArrayList));
    //         }

    //         #endregion
    //     }

    //     #endregion
    // }

    // #endregion



    // #region TaskPaneDesigner

    // /// <summary>
    // /// A custom designer used by TaskPanes to remove unwanted 
    // /// properties from the Property window in the designer
    // /// </summary>
    // internal class TaskPaneDesigner : ScrollableControlDesigner
    // {
    //     /// <summary>
    //     /// Initializes a new instance of the TaskPaneDesigner class
    //     /// </summary>
    //     public TaskPaneDesigner() : base()
    //     {

    //     }


    //     /// <summary>
    //     /// Adjusts the set of properties the component exposes through 
    //     /// a TypeDescriptor
    //     /// </summary>
    //     /// <param name="properties">An IDictionary containing the properties 
    //     /// for the class of the component</param>
    //     protected override void PreFilterProperties(System.Collections.IDictionary properties)
    //     {
    //         base.PreFilterProperties(properties);

    //         properties.Remove("BackColor");
    //         properties.Remove("BackgroundImage");
    //         properties.Remove("Cursor");
    //         properties.Remove("ForeColor");
    //     }
    // }

    // #endregion

    // #endregion

    // #region Theme Manager


    // #region ThemeManager Class

    // /// <summary>
    // /// A class that extracts theme settings from Windows XP shellstyle dlls
    // /// </summary>
    // public class ThemeManager
    // {
    //     /// <summary>
    //     /// pointer to a shellstyle dll
    //     /// </summary>
    //     private static IntPtr hModule = IntPtr.Zero;

    //     /// <summary>
    //     /// cached version of the current shellstyle in use
    //     /// </summary>
    //     private static ExplorerBarInfo currentShellStyle = null;



    //     /// <summary>
    //     /// Gets the System defined settings for the ExplorerBar according
    //     /// to the current System theme
    //     /// </summary>
    //     /// <returns>An ExplorerBarInfo object that contains the System defined 
    //     /// settings for the ExplorerBar according to the current System theme</returns>
    //     public static ExplorerBarInfo GetSystemExplorerBarSettings()
    //     {
    //         return GetSystemExplorerBarSettings(false);
    //     }


    //     /// <summary>
    //     /// Gets the System defined settings for the ExplorerBar according
    //     /// to the current System theme
    //     /// </summary>
    //     /// <param name="useClassicTheme">Specifies whether the current system theme 
    //     /// should be ignored and return unthemed settings</param>
    //     /// <returns>An ExplorerBarInfo object that contains the System defined 
    //     /// settings for the ExplorerBar according to the current System theme</returns>
    //     public static ExplorerBarInfo GetSystemExplorerBarSettings(bool useClassicTheme)
    //     {
    //         // check if we can return the cached theme
    //         // note: caching a classic theme seems to cause a few
    //         //       problems i haven't been able to resolve, so 
    //         //       for the moment always return a new 
    //         //       ExplorerBarInfo if useClassicTheme is true
    //         if (currentShellStyle != null && !useClassicTheme)
    //         {
    //             if (currentShellStyle.ShellStylePath != null && currentShellStyle.ShellStylePath.Equals(GetShellStylePath()))
    //             {
    //                 return currentShellStyle;
    //             }
    //         }

    //         ExplorerBarInfo systemTheme;

    //         // check if we are using themes.  if so, load up the
    //         // appropriate shellstyle.dll
    //         if (!useClassicTheme && UxTheme.AppThemed && LoadShellStyleDll())
    //         {
    //             try
    //             {
    //                 // get the uifile contained in the shellstyle.dll
    //                 // and get ready to parse it
    //                 Parser parser = new Parser(GetResourceUIFile());

    //                 // let the parser do its stuff
    //                 systemTheme = parser.Parse();
    //                 systemTheme.SetOfficialTheme(true);
    //                 systemTheme.ShellStylePath = GetShellStylePath();
    //             }
    //             catch
    //             {
    //                 // something went wrong, so use default settings
    //                 systemTheme = new ExplorerBarInfo();
    //                 systemTheme.UseClassicTheme();
    //                 systemTheme.SetOfficialTheme(true);

    //                 // add non-themed arrows as the ExplorerBar will
    //                 // look funny without them.
    //                 systemTheme.SetUnthemedArrowImages();
    //             }
    //             finally
    //             {
    //                 // unload the shellstyle.dll
    //                 FreeShellStyleDll();
    //             }
    //         }
    //         else
    //         {
    //             // no themes available, so use default settings
    //             systemTheme = new ExplorerBarInfo();
    //             systemTheme.UseClassicTheme();
    //             systemTheme.SetOfficialTheme(true);

    //             // add non-themed arrows as the ExplorerBar will
    //             // look funny without them.
    //             systemTheme.SetUnthemedArrowImages();
    //         }

    //         // cache the theme
    //         currentShellStyle = systemTheme;

    //         return systemTheme;
    //     }


    //     /// <summary>
    //     /// Gets the System defined settings for the ExplorerBar specified
    //     /// by the shellstyle.dll at the specified path
    //     /// </summary>
    //     /// <param name="stylePath">The path to the shellstyle.dll</param>
    //     /// <returns>An ExplorerBarInfo object that contains the settings for 
    //     /// the ExplorerBar specified by the shellstyle.dll at the specified path</returns>
    //     public static ExplorerBarInfo GetSystemExplorerBarSettings(string stylePath)
    //     {
    //         // check if we can return the cached theme
    //         if (currentShellStyle != null)
    //         {
    //             if (!currentShellStyle.ClassicTheme && currentShellStyle.ShellStylePath != null && currentShellStyle.ShellStylePath.Equals(stylePath))
    //             {
    //                 return currentShellStyle;
    //             }
    //         }

    //         ExplorerBarInfo systemTheme;

    //         // attampt to load the specified shellstyle.dll
    //         if (LoadShellStyleDll(stylePath))
    //         {
    //             try
    //             {
    //                 // get the uifile contained in the shellstyle.dll
    //                 // and get ready to parse it
    //                 Parser parser = new Parser(GetResourceUIFile());

    //                 // let the parser do its stuff
    //                 systemTheme = parser.Parse();
    //                 systemTheme.SetOfficialTheme(false);
    //                 systemTheme.ShellStylePath = stylePath;
    //             }
    //             catch
    //             {
    //                 // something went wrong, so try to use current system theme
    //                 systemTheme = GetSystemExplorerBarSettings();
    //             }
    //             finally
    //             {
    //                 // unload the shellstyle.dll
    //                 FreeShellStyleDll();
    //             }
    //         }
    //         else
    //         {
    //             // no themes available, so use default settings
    //             systemTheme = new ExplorerBarInfo();
    //             systemTheme.UseClassicTheme();
    //             systemTheme.SetOfficialTheme(true);

    //             // add non-themed arrows as the ExplorerBar will
    //             // look funny without them.
    //             systemTheme.SetUnthemedArrowImages();
    //         }

    //         // cache the theme
    //         currentShellStyle = systemTheme;

    //         return systemTheme;
    //     }


    //     #region ShellStyle Dll

    //     /// <summary>
    //     /// Loads the ShellStyle.dll into memory as determined by the current
    //     /// system theme
    //     /// </summary>
    //     /// <returns>If the function succeeds, the return value is true. If the 
    //     /// function fails, the return value is false</returns>
    //     private static bool LoadShellStyleDll()
    //     {
    //         // work out the path to the shellstyle.dll according
    //         // to the current theme
    //         string stylePath = GetShellStylePath();

    //         // if for some reason it doesn't exist, return false 
    //         // so we can use our classic theme instead
    //         if (!File.Exists(stylePath))
    //         {
    //             return false;
    //         }

    //         // make sure Windows won't throw up any error boxes if for
    //         // some reason it can't find the dll
    //         int lastErrorMode = NativeMethods.SetErrorMode(SetErrorModeFlags.SEM_FAILCRITICALERRORS | SetErrorModeFlags.SEM_NOOPENFILEERRORBOX);

    //         // attempt to load the shellstyle dll

    //         // fix: use LoadLibraryEx to load shellstyle.dll to improve
    //         //      compatibility with non-official themes
    //         //      use SetErrorMode to supress error messages
    //         //      scorteel (scorteel@ask.be)
    //         //      17/08/2004
    //         //      v1.21
    //         // fix: Win9x craps itself on the NativeMethods.LoadLibraryEx 
    //         //      and doesn't return a valid hModule pointer, so we'll 
    //         //      use LoadLibrary instead and hope if doesn't cause
    //         //      any problems
    //         //      18/01/2005
    //         //      v3.2
    //         if (Environment.OSVersion.Platform == PlatformID.Win32Windows)
    //         {
    //             hModule = NativeMethods.LoadLibrary(stylePath);
    //         }
    //         else
    //         {
    //             hModule = NativeMethods.LoadLibraryEx(stylePath, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE);
    //         }

    //         // set the error mode back to its original value
    //         NativeMethods.SetErrorMode((SetErrorModeFlags)lastErrorMode);

    //         // return whether we succeeded
    //         return (hModule != IntPtr.Zero);
    //     }


    //     /// <summary>
    //     /// Loads the specified ShellStyle.dll into memory
    //     /// </summary>
    //     /// <returns>If the function succeeds, the return value is true. If the 
    //     /// function fails, the return value is false</returns>
    //     private static bool LoadShellStyleDll(string stylePath)
    //     {
    //         // if the file doesn't exist, return the current style
    //         if (!File.Exists(stylePath))
    //         {
    //             return LoadShellStyleDll();
    //         }

    //         // make sure Windows won't throw up any error boxes if for
    //         // some reason it can't find the dll
    //         int lastErrorMode = NativeMethods.SetErrorMode(SetErrorModeFlags.SEM_FAILCRITICALERRORS | SetErrorModeFlags.SEM_NOOPENFILEERRORBOX);

    //         // attempt to load the shellstyle dll

    //         // fix: use LoadLibraryEx to load shellstyle.dll to improve
    //         //      compatibility with non-official themes
    //         //      use SetErrorMode to supress error messages
    //         //      scorteel (scorteel@ask.be)
    //         //      17/08/2004
    //         //      v1.21
    //         // fix: Win9x craps itself on the NativeMethods.LoadLibraryEx 
    //         //      and doesn't return a valid hModule pointer, so we'll 
    //         //      use LoadLibrary instead and hope if doesn't cause
    //         //      any problems
    //         //      18/01/2005
    //         //      v3.2
    //         if (Environment.OSVersion.Platform == PlatformID.Win32Windows)
    //         {
    //             hModule = NativeMethods.LoadLibrary(stylePath);
    //         }
    //         else
    //         {
    //             hModule = NativeMethods.LoadLibraryEx(stylePath, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE);
    //         }

    //         // set the error mode back to its original value
    //         NativeMethods.SetErrorMode((SetErrorModeFlags)lastErrorMode);

    //         // return whether we succeeded
    //         return (hModule != IntPtr.Zero);
    //     }


    //     /// <summary>
    //     /// Removes the ShellStyle.dll from memory.  Assumes that
    //     /// LoadShellStyleDll() was successful
    //     /// </summary>
    //     private static void FreeShellStyleDll()
    //     {
    //         // unload the dll
    //         NativeMethods.FreeLibrary(hModule);

    //         // reset the hModule pointer
    //         hModule = IntPtr.Zero;
    //     }


    //     /// <summary>
    //     /// Returns a string that specifies the path to the shellstyle.dll 
    //     /// accordingto the current theme
    //     /// </summary>
    //     /// <returns>a string that specifies the path to the shellstyle.dll 
    //     /// accordingto the current theme</returns>
    //     private static string GetShellStylePath()
    //     {
    //         // work out the path to the shellstyle.dll according
    //         // to the current theme
    //         // fix: considered a issue with handling custom themes 
    //         //      located in sub-directories or using a non-flat 
    //         //      directory structure
    //         //      torsten_rendelmann (torsten.rendelmann@gmx.net)
    //         //      13/09/2005
    //         //      v3.3
    //         string themeName = UxTheme.ThemeName;

    //         if (themeName.IndexOf('\\') >= 0)
    //         {
    //             themeName = themeName.Substring(0, themeName.LastIndexOf('\\'));
    //         }

    //         string styleName = themeName + "\\Shell\\" + UxTheme.ColorName;
    //         string stylePath = styleName + "\\shellstyle.dll";

    //         return stylePath;
    //     }

    //     #endregion


    //     #region Resources

    //     /// <summary>
    //     /// Extracts the UIFILE from the currently loaded ShellStyle.dll
    //     /// </summary>
    //     /// <returns>A string that contains the UIFILE</returns>
    //     internal static string GetResourceUIFile()
    //     {
    //         // locate the "UIFILE" resource
    //         IntPtr hResource = NativeMethods.FindResource(hModule, "#1", "UIFILE");

    //         // get its size
    //         int resourceSize = NativeMethods.SizeofResource(hModule, hResource);

    //         // load the resource
    //         IntPtr resourceData = NativeMethods.LoadResource(hModule, hResource);

    //         // copy the resource data into a byte array so we
    //         // still have a copy once the resource is freed
    //         // fix: use GCHandle.Alloc to pin uiBytes
    //         //      Paul Haley (phaley@mail.com)
    //         //      03/06/2004
    //         //      v1.1
    //         byte[] uiBytes = new byte[resourceSize];
    //         GCHandle gcHandle = GCHandle.Alloc(uiBytes, GCHandleType.Pinned);
    //         IntPtr firstCopyElement = Marshal.UnsafeAddrOfPinnedArrayElement(uiBytes, 0);
    //         NativeMethods.CopyMemory(firstCopyElement, resourceData, resourceSize);

    //         // free the resource
    //         gcHandle.Free();
    //         NativeMethods.FreeResource(resourceData);

    //         // convert the char array to an ansi string
    //         string s = Marshal.PtrToStringAnsi(firstCopyElement, resourceSize);

    //         return s;
    //     }


    //     /// <summary>
    //     /// Returns a Bitmap from the currently loaded ShellStyle.dll
    //     /// </summary>
    //     /// <param name="resourceName">The name of the Bitmap to load</param>
    //     /// <returns>The Bitmap specified by the resourceName</returns>
    //     internal static Bitmap GetResourceBMP(string resourceName)
    //     {
    //         // find the resource
    //         IntPtr hBitmap = NativeMethods.LoadBitmap(hModule, Int32.Parse(resourceName));

    //         // load the bitmap
    //         Bitmap bitmap = Bitmap.FromHbitmap(hBitmap);

    //         return bitmap;
    //     }


    //     /// <summary>
    //     /// Returns a Png Bitmap from the currently loaded ShellStyle.dll
    //     /// </summary>
    //     /// <param name="resourceName">The name of the Png to load</param>
    //     /// <returns>The Bitmap specified by the resourceName</returns>
    //     internal static Bitmap GetResourcePNG(string resourceName)
    //     {
    //         // the resource size includes some header information (for PNG's in shellstyle.dll this
    //         // appears to be the standard 40 bytes of BITMAPHEADERINFO).
    //         const int FILE_HEADER_BYTES = 40;

    //         // load the bitmap resource normally to get dimensions etc.
    //         Bitmap tmpNoAlpha = Bitmap.FromResource(hModule, "#" + resourceName);
    //         IntPtr hResource = NativeMethods.FindResource(hModule, "#" + resourceName, 2 /*RT_BITMAP*/ );
    //         int resourceSize = NativeMethods.SizeofResource(hModule, hResource);

    //         // initialise 32bit alpha bitmap (target)
    //         Bitmap bitmap = new Bitmap(tmpNoAlpha.Width, tmpNoAlpha.Height, PixelFormat.Format32bppArgb);

    //         // load the resource via kernel32.dll (preserves alpha)
    //         IntPtr hLoadedResource = NativeMethods.LoadResource(hModule, hResource);

    //         // copy bitmap data into byte array directly
    //         // still have a copy once the resource is freed
    //         // fix: use GCHandle.Alloc to pin uiBytes
    //         //      Paul Haley (phaley@mail.com)
    //         //      03/06/2004
    //         //      v1.1
    //         byte[] bitmapBytes = new byte[resourceSize];
    //         GCHandle gcHandle = GCHandle.Alloc(bitmapBytes, GCHandleType.Pinned);
    //         IntPtr firstCopyElement = Marshal.UnsafeAddrOfPinnedArrayElement(bitmapBytes, 0);
    //         // nb. we only copy the actual PNG data (no header)
    //         NativeMethods.CopyMemory(firstCopyElement, hLoadedResource, resourceSize);
    //         NativeMethods.FreeResource(hLoadedResource);

    //         // copy the byte array contents back to a handle to the alpha bitmap (use lockbits)
    //         Rectangle copyArea = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
    //         BitmapData alphaBits = bitmap.LockBits(copyArea, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

    //         // copymemory to bitmap data (Scan0)
    //         firstCopyElement = Marshal.UnsafeAddrOfPinnedArrayElement(bitmapBytes, FILE_HEADER_BYTES);
    //         NativeMethods.CopyMemory(alphaBits.Scan0, firstCopyElement, resourceSize - FILE_HEADER_BYTES);
    //         gcHandle.Free();

    //         // complete operation
    //         bitmap.UnlockBits(alphaBits);
    //         NativeMethods.GdiFlush();

    //         // flip bits (not sure why this is needed at the moment..)
    //         bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

    //         return bitmap;
    //     }


    //     /// <summary>
    //     /// Returns a string from the currently loaded ShellStyle.dll
    //     /// </summary>
    //     /// <param name="id">The integer identifier of the string to be loaded</param>
    //     internal static string GetResourceString(int id)
    //     {
    //         // return null if shellstyle.dll isn't loaded
    //         if (hModule == IntPtr.Zero)
    //         {
    //             return null;
    //         }

    //         // get the string
    //         StringBuilder buffer = new StringBuilder(1024);
    //         NativeMethods.LoadString(hModule, id, buffer, 1024);

    //         return buffer.ToString();
    //     }


    //     /// <summary>
    //     /// Converts an Icon to a Bitmap
    //     /// </summary>
    //     /// <param name="icon">The Icon to be converted</param>
    //     /// <returns>A Bitmap that contains the converted Icon</returns>
    //     public static Bitmap IconToBitmap(Icon icon)
    //     {
    //         // try to convert to a 32bpp bitmap
    //         Bitmap bitmap = ThemeManager.ConvertToBitmap(icon);

    //         // if the bitmap is null, either there isn't a 32bpp 
    //         // icon we can convert or the display is running in 
    //         // less than 32bpp mode, so we can safely get windows 
    //         // to convert the icon for us (it won't ignore alpha)
    //         if (bitmap == null)
    //         {
    //             bitmap = icon.ToBitmap();
    //         }

    //         return bitmap;
    //     }


    //     /// <summary>
    //     /// Converts an Icon to a Bitmap
    //     /// </summary>
    //     /// <param name="icon">The Icon to be converted</param>
    //     /// <returns>A Bitmap that contains the converted Icon</returns>
    //     internal static unsafe Bitmap ConvertToBitmap(Icon icon)
    //     {
    //         Bitmap bitmap = null;

    //         // get the screen bpp
    //         int bitDepth = 0;

    //         IntPtr dc = NativeMethods.GetDC(IntPtr.Zero);
    //         bitDepth = NativeMethods.GetDeviceCaps(dc, 12 /*BITSPIXEL*/);
    //         bitDepth *= NativeMethods.GetDeviceCaps(dc, 14 /*PLANES*/);
    //         NativeMethods.ReleaseDC(IntPtr.Zero, dc);

    //         // if the screen bpp is not 32bpp return the 
    //         // null bitmap so that IconToBitmap can get 
    //         // windows to convert the icon (as it only 
    //         // ignores the alpha channel if the display 
    //         // is in 32bpp mode - why??)
    //         if (bitDepth != 32)
    //         {
    //             return bitmap;
    //         }

    //         // get the default icon sizes
    //         int defaultWidth = NativeMethods.GetSystemMetrics(11 /*SM_CXICON*/);
    //         int defaultHeight = NativeMethods.GetSystemMetrics(12 /*SM_CYICON*/);

    //         // convert the icon into a byte array

    //         MemoryStream ms = new MemoryStream();
    //         icon.Save(ms);

    //         byte[] iconData = ms.ToArray();

    //         ms.Close();
    //         ms = null;

    //         // prevent the garbage collector from relocating the iconData
    //         fixed (byte* data = iconData)
    //         {
    //             // "read" the data
    //             ICONFILE* iconfile = (ICONFILE*)data;

    //             // make sure we have valid data
    //             if (iconfile->reserved != 0 || iconfile->resourceType != 1 || iconfile->iconCount == 0)
    //             {
    //                 throw new ArgumentException("The argument picture must be a picture that can be used as a Icon");
    //             }

    //             // set the current entry to the start of the entry section
    //             ICONENTRY* currentEntry = &iconfile->entries;

    //             // the entry that contains the icon whose properties closest 
    //             // match the default icon size and bitdepth
    //             ICONENTRY* targetEntry = null;
    //             int bpp = 0;

    //             // record the size of an ICONENTRY
    //             int iconEntrySize = Marshal.SizeOf(typeof(ICONENTRY));

    //             // make sure we have enough data to read each entry
    //             if ((iconEntrySize * iconfile->iconCount) >= iconData.Length)
    //             {
    //                 throw new ArgumentException("The argument picture must be a picture that can be used as a Icon");
    //             }

    //             // go through each entry
    //             for (int i = 0; i < iconfile->iconCount; i++)
    //             {
    //                 // get the icons bpp
    //                 int iconBitDepth = currentEntry->numPlanes * currentEntry->bitsPerPixel;

    //                 // make sure it is at least 16bpp
    //                 iconBitDepth = Math.Max(iconBitDepth, 16);

    //                 // set the target entry if we haven't already
    //                 if (targetEntry == null)
    //                 {
    //                     targetEntry = currentEntry;
    //                     bpp = iconBitDepth;
    //                 }
    //                 else
    //                 {
    //                     // work out the difference between default sizes
    //                     int targetTotalDiff = Math.Abs(targetEntry->width - defaultWidth) + Math.Abs(targetEntry->height - defaultHeight);
    //                     int currentTotalDiff = Math.Abs(currentEntry->width - defaultWidth) + Math.Abs(currentEntry->height - defaultHeight);

    //                     // check if the current match is closer than the previous match
    //                     if (currentTotalDiff < targetTotalDiff)
    //                     {
    //                         targetEntry = currentEntry;
    //                         bpp = iconBitDepth;
    //                     }
    //                     // if the size differences are the same, compare bit depths
    //                     else if ((currentTotalDiff == targetTotalDiff) && ((iconBitDepth <= bitDepth) && (iconBitDepth > bpp)) || (bpp > bitDepth) && (iconBitDepth < bpp))
    //                     {
    //                         targetEntry = currentEntry;
    //                         bpp = iconBitDepth;
    //                     }
    //                 }

    //                 // move to the next entry
    //                 currentEntry++;
    //             }

    //             // make sure the target entry is valid
    //             if ((targetEntry->dataOffset < 0) || ((targetEntry->dataOffset + targetEntry->dataSize) > iconData.Length))
    //             {
    //                 throw new ArgumentException("The argument picture must be a picture that can be used as a Icon");
    //             }

    //             // make sure the target is 32bpp
    //             if (targetEntry->bitsPerPixel == 32)
    //             {
    //                 int offset = targetEntry->dataOffset;
    //                 int dataSize = targetEntry->dataSize;

    //                 bitmap = new Bitmap(targetEntry->width, targetEntry->height, PixelFormat.Format32bppArgb);

    //                 int FILE_HEADER_BYTES = 40;
    //                 int PALETTE_SIZE = targetEntry->bitsPerPixel * 4;
    //                 int AND_MAP_SIZE = (targetEntry->width / 8) * (targetEntry->height / 8);
    //                 int XOR_MAP_SIZE = dataSize - FILE_HEADER_BYTES - PALETTE_SIZE;
    //                 int ROW_SIZE = targetEntry->width * (targetEntry->bitsPerPixel / 8);

    //                 byte[] bitmapBytes = new byte[dataSize];

    //                 GCHandle gcHandle = GCHandle.Alloc(bitmapBytes, GCHandleType.Pinned);
    //                 // nb. we only copy the actual PNG data (no header)
    //                 Array.Copy(iconData, offset, bitmapBytes, 0, dataSize);

    //                 // copy the byte array contents back to a handle to the alpha bitmap (use lockbits)
    //                 Rectangle copyArea = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
    //                 BitmapData alphaBits = bitmap.LockBits(copyArea, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

    //                 int dataStart = FILE_HEADER_BYTES + PALETTE_SIZE;

    //                 // copymemory to bitmap data (Scan0)
    //                 IntPtr firstCopyElement = Marshal.UnsafeAddrOfPinnedArrayElement(bitmapBytes, dataStart);
    //                 NativeMethods.CopyMemory(alphaBits.Scan0, firstCopyElement, XOR_MAP_SIZE - ROW_SIZE);
    //                 gcHandle.Free();

    //                 // complete operation
    //                 bitmap.UnlockBits(alphaBits);
    //                 NativeMethods.GdiFlush();

    //                 // flip bits (not sure why this is needed at the moment..)
    //                 bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
    //             }
    //         }

    //         return bitmap;
    //     }


    //     /// <summary>
    //     /// Converts an Image to a byte array
    //     /// </summary>
    //     /// <param name="image">The image to be converted</param>
    //     /// <returns>A byte array that contains the converted image</returns>
    //     internal static byte[] ConvertImageToByteArray(Image image)
    //     {
    //         if (image == null)
    //         {
    //             return new byte[0];
    //         }

    //         MemoryStream ms = new MemoryStream();

    //         image.Save(ms, ImageFormat.Png);

    //         return ms.ToArray();
    //     }


    //     /// <summary>
    //     /// Converts a byte array to an Image
    //     /// </summary>
    //     /// <param name="bytes">The array of bytes to be converted</param>
    //     /// <returns>An Image that represents the byte array</returns>
    //     internal static Image ConvertByteArrayToImage(byte[] bytes)
    //     {
    //         if (bytes.Length == 0)
    //         {
    //             return null;
    //         }

    //         MemoryStream ms = new MemoryStream(bytes);

    //         return Image.FromStream(ms);
    //     }


    //     /// <summary>
    //     /// Converts a Color to a string representation
    //     /// </summary>
    //     /// <param name="color">The Color to be converted</param>
    //     /// <returns>A string that represents the specified color</returns>
    //     internal static string ConvertColorToString(Color color)
    //     {
    //         if (color == Color.Empty)
    //         {
    //             return null;
    //         }

    //         return "" + color.A + ":" + color.R + ":" + color.G + ":" + color.B;
    //     }


    //     /// <summary>
    //     /// Converts a string to a color
    //     /// </summary>
    //     /// <param name="col">The string to be converted</param>
    //     /// <returns>The converted Color</returns>
    //     internal static Color ConvertStringToColor(string col)
    //     {
    //         if (col == null)
    //         {
    //             return Color.Empty;
    //         }

    //         string[] s = col.Split(new char[] { ':' });

    //         if (s.Length != 4)
    //         {
    //             return Color.Empty;
    //         }

    //         return Color.FromArgb(Int32.Parse(s[0]), Int32.Parse(s[1]), Int32.Parse(s[2]), Int32.Parse(s[3]));
    //     }


    //     /// <summary>
    //     /// Converts an object to a byte array
    //     /// </summary>
    //     /// <param name="obj">The object to be converted</param>
    //     /// <returns>A byte array that contains the converted object</returns>
    //     internal static byte[] ConvertObjectToByteArray(object obj)
    //     {
    //         if (obj == null)
    //         {
    //             return new byte[0];
    //         }

    //         MemoryStream stream = new MemoryStream();
    //         IFormatter formatter = new BinaryFormatter();

    //         formatter.Serialize(stream, obj);

    //         byte[] bytes = stream.ToArray();

    //         stream.Flush();
    //         stream.Close();
    //         stream = null;

    //         return bytes;
    //     }


    //     /// <summary>
    //     /// Converts a byte array to an object
    //     /// </summary>
    //     /// <param name="bytes">The array of bytes to be converted</param>
    //     /// <returns>An object that represents the byte array</returns>
    //     internal static object ConvertByteArrayToObject(byte[] bytes)
    //     {
    //         if (bytes.Length == 0)
    //         {
    //             return null;
    //         }

    //         MemoryStream stream = new MemoryStream(bytes);
    //         stream.Position = 0;

    //         IFormatter formatter = new BinaryFormatter();

    //         object obj = formatter.Deserialize(stream);

    //         stream.Close();
    //         stream = null;

    //         return obj;
    //     }

    //     #endregion
    // }

    // #endregion



    // #region UxTheme

    // /// <summary>
    // /// A class that wraps Windows XPs UxTheme.dll
    // /// </summary>
    // public class UxTheme
    // {
    //     /// <summary>
    //     /// Private constructor
    //     /// </summary>
    //     private UxTheme()
    //     {

    //     }


    //     /// <summary>
    //     /// Reports whether the current application's user interface 
    //     /// displays using visual styles
    //     /// </summary>
    //     public static bool AppThemed
    //     {
    //         get
    //         {
    //             bool themed = false;

    //             OperatingSystem os = System.Environment.OSVersion;

    //             // check if the OS id XP or higher
    //             // fix:	Win2k3 now recognised
    //             //      Russkie (codeprj@webcontrol.net.au)
    //             if (os.Platform == PlatformID.Win32NT && ((os.Version.Major == 5 && os.Version.Minor >= 1) || os.Version.Major > 5))
    //             {
    //                 themed = IsAppThemed();
    //             }

    //             return themed;
    //         }
    //     }


    //     /// <summary>
    //     /// Retrieves the name of the current visual style
    //     /// </summary>
    //     public static String ThemeName
    //     {
    //         get
    //         {
    //             StringBuilder themeName = new StringBuilder(256);

    //             GetCurrentThemeName(themeName, 256, null, 0, null, 0);

    //             return themeName.ToString();
    //         }
    //     }


    //     /// <summary>
    //     /// Retrieves the color scheme name of the current visual style
    //     /// </summary>
    //     public static String ColorName
    //     {
    //         get
    //         {
    //             StringBuilder themeName = new StringBuilder(256);
    //             StringBuilder colorName = new StringBuilder(256);

    //             GetCurrentThemeName(themeName, 256, colorName, 256, null, 0);

    //             return colorName.ToString();
    //         }
    //     }


    //     #region Win32 Methods

    //     /// <summary>
    //     /// Opens the theme data for a window and its associated class
    //     /// </summary>
    //     /// <param name="hwnd">Handle of the window for which theme data 
    //     /// is required</param>
    //     /// <param name="pszClassList">Pointer to a string that contains 
    //     /// a semicolon-separated list of classes</param>
    //     /// <returns>OpenThemeData tries to match each class, one at a 
    //     /// time, to a class data section in the active theme. If a match 
    //     /// is found, an associated HTHEME handle is returned. If no match 
    //     /// is found NULL is returned</returns>
    //     [DllImport("UxTheme.dll")]
    //     public static extern IntPtr OpenThemeData(IntPtr hwnd, [MarshalAs(UnmanagedType.LPTStr)] string pszClassList);


    //     /// <summary>
    //     /// Closes the theme data handle
    //     /// </summary>
    //     /// <param name="hTheme">Handle to a window's specified theme data. 
    //     /// Use OpenThemeData to create an HTHEME</param>
    //     /// <returns>Returns S_OK if successful, or an error value otherwise</returns>
    //     [DllImport("UxTheme.dll")]
    //     public static extern int CloseThemeData(IntPtr hTheme);


    //     /// <summary>
    //     /// Draws the background image defined by the visual style for the 
    //     /// specified control part
    //     /// </summary>
    //     /// <param name="hTheme">Handle to a window's specified theme data. 
    //     /// Use OpenThemeData to create an HTHEME</param>
    //     /// <param name="hdc">Handle to a device context (HDC) used for 
    //     /// drawing the theme-defined background image</param>
    //     /// <param name="iPartId">Value of type int that specifies the part 
    //     /// to draw</param>
    //     /// <param name="iStateId">Value of type int that specifies the state 
    //     /// of the part to draw</param>
    //     /// <param name="pRect">Pointer to a RECT structure that contains the 
    //     /// rectangle, in logical coordinates, in which the background image 
    //     /// is drawn</param>
    //     /// <param name="pClipRect">Pointer to a RECT structure that contains 
    //     /// a clipping rectangle. This parameter may be set to NULL</param>
    //     /// <returns>Returns S_OK if successful, or an error value otherwise</returns>
    //     [DllImport("UxTheme.dll")]
    //     public static extern int DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pRect, ref RECT pClipRect);


    //     /// <summary>
    //     /// Tests if a visual style for the current application is active
    //     /// </summary>
    //     /// <returns>TRUE if a visual style is enabled, and windows with 
    //     /// visual styles applied should call OpenThemeData to start using 
    //     /// theme drawing services, FALSE otherwise</returns>
    //     [DllImport("UxTheme.dll")]
    //     public static extern bool IsThemeActive();


    //     /// <summary>
    //     /// Reports whether the current application's user interface 
    //     /// displays using visual styles
    //     /// </summary>
    //     /// <returns>TRUE if the application has a visual style applied,
    //     /// FALSE otherwise</returns>
    //     [DllImport("UxTheme.dll")]
    //     public static extern bool IsAppThemed();


    //     /// <summary>
    //     /// Retrieves the name of the current visual style, and optionally retrieves the 
    //     /// color scheme name and size name
    //     /// </summary>
    //     /// <param name="pszThemeFileName">Pointer to a string that receives the theme 
    //     /// path and file name</param>
    //     /// <param name="dwMaxNameChars">Value of type int that contains the maximum 
    //     /// number of characters allowed in the theme file name</param>
    //     /// <param name="pszColorBuff">Pointer to a string that receives the color scheme 
    //     /// name. This parameter may be set to NULL</param>
    //     /// <param name="cchMaxColorChars">Value of type int that contains the maximum 
    //     /// number of characters allowed in the color scheme name</param>
    //     /// <param name="pszSizeBuff">Pointer to a string that receives the size name. 
    //     /// This parameter may be set to NULL</param>
    //     /// <param name="cchMaxSizeChars">Value of type int that contains the maximum 
    //     /// number of characters allowed in the size name</param>
    //     /// <returns>Returns S_OK if successful, otherwise an error code</returns>
    //     [DllImport("UxTheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
    //     protected static extern int GetCurrentThemeName(StringBuilder pszThemeFileName, int dwMaxNameChars, StringBuilder pszColorBuff, int cchMaxColorChars, StringBuilder pszSizeBuff, int cchMaxSizeChars);


    //     /// <summary>
    //     /// Draws the part of a parent control that is covered by a 
    //     /// partially-transparent or alpha-blended child control
    //     /// </summary>
    //     /// <param name="hwnd">Handle of the child control</param>
    //     /// <param name="hdc">Handle to the child control's device context </param>
    //     /// <param name="prc">Pointer to a RECT structure that defines the 
    //     /// area to be drawn. The rectangle is in the child window's coordinates. 
    //     /// This parameter may be set to NULL</param>
    //     /// <returns>Returns S_OK if successful, or an error value otherwise</returns>
    //     [DllImport("UxTheme.dll")]
    //     public static extern int DrawThemeParentBackground(IntPtr hwnd, IntPtr hdc, ref RECT prc);

    //     #endregion



    //     #region WindowClasses

    //     /// <summary>
    //     /// Window class IDs used by UxTheme.dll to draw controls
    //     /// </summary>
    //     public class WindowClasses
    //     {
    //         /// <summary>
    //         /// TextBox class
    //         /// </summary>
    //         public static readonly string Edit = "EDIT";

    //         /// <summary>
    //         /// ListView class
    //         /// </summary>
    //         public static readonly string ListView = "LISTVIEW";

    //         /// <summary>
    //         /// TreeView class
    //         /// </summary>
    //         public static readonly string TreeView = "TREEVIEW";
    //     }

    //     #endregion



    //     #region Parts

    //     /// <summary>
    //     /// Window parts IDs used by UxTheme.dll to draw controls
    //     /// </summary>
    //     public class Parts
    //     {
    //         #region Edit

    //         /// <summary>
    //         /// TextBox parts
    //         /// </summary>
    //         public enum Edit
    //         {
    //             /// <summary>
    //             /// TextBox
    //             /// </summary>
    //             EditText = 1
    //         }

    //         #endregion


    //         #region ListView

    //         /// <summary>
    //         /// ListView parts
    //         /// </summary>
    //         public enum ListView
    //         {
    //             /// <summary>
    //             /// ListView
    //             /// </summary>
    //             ListItem = 1
    //         }

    //         #endregion


    //         #region TreeView

    //         /// <summary>
    //         /// TreeView parts
    //         /// </summary>
    //         public enum TreeView
    //         {
    //             /// <summary>
    //             /// TreeView
    //             /// </summary>
    //             TreeItem = 1
    //         }

    //         #endregion
    //     }

    //     #endregion



    //     #region PartStates

    //     /// <summary>
    //     /// Window part state IDs used by UxTheme.dll to draw controls
    //     /// </summary>
    //     public class PartStates
    //     {
    //         #region EditParts

    //         /// <summary>
    //         /// TextBox part states
    //         /// </summary>
    //         public enum EditText
    //         {
    //             /// <summary>
    //             /// The TextBox is in its normal state
    //             /// </summary>
    //             Normal = 1,

    //             /// <summary>
    //             /// The mouse is over the TextBox
    //             /// </summary>
    //             Hot = 2,

    //             /// <summary>
    //             /// The TextBox is selected
    //             /// </summary>
    //             Selected = 3,

    //             /// <summary>
    //             /// The TextBox is disabled
    //             /// </summary>
    //             Disabled = 4,

    //             /// <summary>
    //             /// The TextBox currently has focus
    //             /// </summary>
    //             Focused = 5,

    //             /// <summary>
    //             /// The TextBox is readonly
    //             /// </summary>
    //             Readonly = 6
    //         }

    //         #endregion


    //         #region ListViewParts

    //         /// <summary>
    //         /// ListView part states
    //         /// </summary>
    //         public enum ListItem
    //         {
    //             /// <summary>
    //             /// The ListView is in its normal state
    //             /// </summary>
    //             Normal = 1,

    //             /// <summary>
    //             /// The mouse is over the ListView
    //             /// </summary>
    //             Hot = 2,

    //             /// <summary>
    //             /// The ListView is selected
    //             /// </summary>
    //             Selected = 3,

    //             /// <summary>
    //             /// The ListView is disabled
    //             /// </summary>
    //             Disabled = 4,

    //             /// <summary>
    //             /// The ListView is selected but currently does not have focus
    //             /// </summary>
    //             SelectedNotFocused = 5
    //         }

    //         #endregion


    //         #region TreeViewParts

    //         /// <summary>
    //         /// TreeView part states
    //         /// </summary>
    //         public enum TreeItem
    //         {
    //             /// <summary>
    //             /// The TreeView is in its normal state
    //             /// </summary>
    //             Normal = 1,

    //             /// <summary>
    //             /// The mouse is over the TreeView
    //             /// </summary>
    //             Hot = 2,

    //             /// <summary>
    //             /// The TreeView is selected
    //             /// </summary>
    //             Selected = 3,

    //             /// <summary>
    //             /// The TreeView is disabled
    //             /// </summary>
    //             Disabled = 4,

    //             /// <summary>
    //             /// The TreeView is selected but currently does not have focus
    //             /// </summary>
    //             SelectedNotFocused = 5
    //         }

    //         #endregion
    //     }

    //     #endregion
    // }

    // #endregion



    // #region Parser Class

    // /// <summary>
    // /// A class that parses a UIFILE
    // /// </summary>
    // internal class Parser
    // {
    //     //
    //     private const int UNKNOWN = 0;
    //     private const int MAINSECTIONSS = 1;
    //     private const int MAINSECTIONTASKSS = 2;
    //     private const int SECTIONSS = 3;
    //     private const int SECTIONTASKSS = 4;
    //     private const int TASKPANE = 5;
    //     //
    //     private int style;

    //     //
    //     private const int BUTTON = 1;
    //     private const int DESTINATIONTASK = 2;
    //     private const int ACTIONTASK = 4;
    //     private const int TITLE = 8;
    //     private const int ARROW = 16;
    //     private const int WATERMARK = 32;
    //     private const int TASKLIST = 64;
    //     private const int SECTIONLIST = 128;
    //     private const int SELECTED = 256;
    //     private const int MOUSEFOCUSED = 512;
    //     private const int KEYFOCUSED = 1024;
    //     private const int EXPANDO = 2048;
    //     private const int BACKDROP = 4096;
    //     private const int HEADER = 8192;
    //     //
    //     private int section;

    //     private const int CONTENT = 1;
    //     private const int CONTENTALIGN = 2;
    //     private const int FONTFACE = 3;
    //     private const int FONTSIZE = 4;
    //     private const int FONTWEIGHT = 5;
    //     private const int FONTSTYLE = 6;
    //     private const int BACKGROUND = 7;
    //     private const int FOREGROUND = 8;
    //     private const int BORDERTHICKNESS = 9;
    //     private const int BORDERDOLOR = 10;
    //     private const int PADDING = 11;
    //     private const int MARGIN = 12;
    //     //
    //     private int property;

    //     //
    //     private ExplorerBarInfo info;

    //     //
    //     private StringTokenizer tokenizer;


    //     /// <summary>
    //     /// Creates a new Parser
    //     /// </summary>
    //     /// <param name="uifile">The text from the UIFILE that is to be parsed</param>
    //     public Parser(string uifile)
    //     {
    //         // I'm lazy so get rid of a few strings
    //         uifile = uifile.Replace("rp", " ");
    //         uifile = uifile.Replace("rcstr", " ");
    //         uifile = uifile.Replace("rcint", " ");
    //         uifile = uifile.Replace("pt", " ");
    //         uifile = uifile.Replace("rect", " ");

    //         // create a new StringTokenizer with lots of delimiters
    //         this.tokenizer = new StringTokenizer(uifile, " \t\n\r\f<>=()[]{}:;,\\");

    //         this.style = UNKNOWN;
    //         this.section = UNKNOWN;
    //         this.property = UNKNOWN;
    //     }


    //     /// <summary>
    //     /// Parses the UIFILE
    //     /// </summary>
    //     /// <returns>An ExplorerBarInfo object that contains the system 
    //     /// settings defined in the UIFILE</returns>
    //     public ExplorerBarInfo Parse()
    //     {
    //         this.info = new ExplorerBarInfo();

    //         string token = null;

    //         // keep going till we run out of tokens
    //         while (this.tokenizer.HasMoreTokens())
    //         {
    //             // get the next token
    //             token = this.tokenizer.NextToken();

    //             // is the token the start of a style section
    //             if (token.Equals("style"))
    //             {
    //                 // work out which style section it is
    //                 style = GetStyle(token);
    //             }
    //             // is the token the end of a style section
    //             else if (token.Equals("/style"))
    //             {
    //                 // reset the style
    //                 style = UNKNOWN;
    //             }
    //             // is the token the start of a property section in a known style
    //             else if (style != UNKNOWN && IsSection(token))
    //             {
    //                 // work out which property section it is
    //                 section = GetSection(token);
    //             }
    //             // is the token a property that belongs to a known property 
    //             // section and style
    //             else if (style != UNKNOWN && section != UNKNOWN && IsProperty(token))
    //             {
    //                 // get the property
    //                 property = GetPropertyType(token);
    //                 ExtractProperty();
    //             }
    //         }

    //         return info;
    //     }


    //     /// <summary>
    //     /// Returns the style name for the current style token
    //     /// </summary>
    //     /// <param name="s"></param>
    //     /// <returns></returns>
    //     private int GetStyle(string s)
    //     {
    //         // check if the next token is the string "resid"
    //         if (!this.tokenizer.PeekToken().Equals("resid"))
    //         {
    //             // shouldn't get here, but if we do, return
    //             // an unknown style
    //             return UNKNOWN;
    //         }

    //         // skip past the "resid" token and get the next token
    //         this.tokenizer.SkipToken();
    //         string t = this.tokenizer.NextToken();

    //         // ckeck if it is one of the styles we're looking for.
    //         // if so, return which style it is
    //         switch (t)
    //         {
    //             case "mainsectionss": return MAINSECTIONSS;

    //             case "mainsectiontaskss": return MAINSECTIONTASKSS;

    //             case "sectionss": return SECTIONSS;

    //             case "sectiontaskss": return SECTIONTASKSS;

    //             case "taskpane": return TASKPANE;
    //         }

    //         // not one of our styles, so return unknown
    //         return UNKNOWN;
    //     }


    //     /// <summary>
    //     /// Returns whether the token is a property section that we are interested in
    //     /// </summary>
    //     /// <param name="s"></param>
    //     /// <returns></returns>
    //     private bool IsSection(string s)
    //     {
    //         return (s.Equals("button") || s.Equals("destinationtask") ||
    //             s.Equals("actiontask") || s.Equals("title") ||
    //             s.Equals("arrow") || s.Equals("watermark") ||
    //             s.Equals("tasklist") || s.Equals("sectionlist") ||
    //             s.Equals("backdrop") || s.Equals("expando") || s.Equals("header"));
    //     }


    //     /// <summary>
    //     /// Returns the name of the property section for the current token
    //     /// </summary>
    //     /// <param name="s"></param>
    //     /// <returns></returns>
    //     private int GetSection(string s)
    //     {
    //         switch (s)
    //         {
    //             case "button":
    //                 if (this.tokenizer.PeekToken().Equals("keyfocused"))
    //                 {
    //                     this.tokenizer.SkipToken();

    //                     return BUTTON + KEYFOCUSED;
    //                 }
    //                 return BUTTON;

    //             case "destinationtask": return DESTINATIONTASK;

    //             case "actiontask": return ACTIONTASK;

    //             case "title":
    //                 if (this.tokenizer.PeekToken().Equals("mousefocused"))
    //                 {
    //                     this.tokenizer.SkipToken();

    //                     return TITLE + MOUSEFOCUSED;
    //                 }
    //                 return TITLE;

    //             case "arrow":
    //                 if (this.tokenizer.PeekToken().Equals("selected"))
    //                 {
    //                     this.tokenizer.SkipToken();

    //                     if (this.tokenizer.PeekToken().Equals("mousefocused"))
    //                     {
    //                         this.tokenizer.SkipToken();

    //                         return ARROW + SELECTED + MOUSEFOCUSED;
    //                     }

    //                     return ARROW + SELECTED;
    //                 }
    //                 else if (this.tokenizer.PeekToken().Equals("mousefocused"))
    //                 {
    //                     this.tokenizer.SkipToken();

    //                     return ARROW + MOUSEFOCUSED;
    //                 }
    //                 return ARROW;

    //             case "watermark": return WATERMARK;

    //             case "tasklist": return TASKLIST;

    //             case "sectionlist": return SECTIONLIST;

    //             case "expando": return EXPANDO;

    //             case "backdrop": return BACKDROP;

    //             case "header": return HEADER;
    //         }

    //         return UNKNOWN;
    //     }


    //     /// <summary>
    //     /// Returns whether the token is a property that we are interested in
    //     /// </summary>
    //     /// <param name="s"></param>
    //     /// <returns></returns>
    //     private bool IsProperty(string s)
    //     {
    //         return (s.Equals("content") || s.Equals("contentalign") ||
    //             s.Equals("fontface") || s.Equals("fontsize") ||
    //             s.Equals("fontweight") || s.Equals("fontstyle") ||
    //             s.Equals("background") || s.Equals("foreground") ||
    //             s.Equals("borderthickness") || s.Equals("bordercolor") ||
    //             s.Equals("padding") || s.Equals("margin") || s.Equals("cursor"));
    //     }


    //     /// <summary>
    //     /// Returns the property type for the current proprty token
    //     /// </summary>
    //     /// <param name="s"></param>
    //     /// <returns></returns>
    //     private int GetPropertyType(string s)
    //     {
    //         switch (s)
    //         {
    //             case "content": return CONTENT;

    //             case "contentalign": return CONTENTALIGN;

    //             case "fontface": return FONTFACE;

    //             case "fontsize": return FONTSIZE;

    //             case "fontweight": return FONTWEIGHT;

    //             case "fontstyle": return FONTSTYLE;

    //             case "background": return BACKGROUND;

    //             case "foreground": return FOREGROUND;

    //             case "borderthickness": return BORDERTHICKNESS;

    //             case "bordercolor": return BORDERDOLOR;

    //             case "padding": return PADDING;

    //             case "margin": return MARGIN;
    //         }

    //         return UNKNOWN;
    //     }


    //     /// <summary>
    //     /// Extracts a property from the current property token
    //     /// </summary>
    //     private void ExtractProperty()
    //     {
    //         switch (property)
    //         {
    //             case CONTENT:
    //                 ExtractContent();
    //                 break;

    //             case CONTENTALIGN:
    //                 ExtractContentAlignment();
    //                 break;

    //             case FONTFACE:
    //                 ExtractFontFace();
    //                 break;

    //             case FONTSIZE:
    //                 ExtractFontSize();
    //                 break;

    //             case FONTWEIGHT:
    //                 ExtractFontWeight();
    //                 break;

    //             case FONTSTYLE:
    //                 ExtractFontStyle();
    //                 break;

    //             case BACKGROUND:
    //                 ExtractBackground();
    //                 break;

    //             case FOREGROUND:
    //                 ExtractForeground();
    //                 break;

    //             case BORDERTHICKNESS:
    //                 ExtractBorder();
    //                 break;

    //             case BORDERDOLOR:
    //                 ExtractBorderColor();
    //                 break;

    //             case PADDING:
    //                 ExtractPadding();
    //                 break;

    //             case MARGIN:
    //                 ExtractMargin();
    //                 break;
    //         }
    //     }


    //     /// <summary>
    //     /// Extracts a Bitmap from a "content" property
    //     /// </summary>
    //     private void ExtractContent()
    //     {
    //         // peek at the next token
    //         string token = this.tokenizer.PeekToken();

    //         // check if is a bitmap
    //         if (token.Equals("rcbmp"))
    //         {
    //             // skip past the "rcbmp" token
    //             this.tokenizer.SkipToken();

    //             // extract the bitmap
    //             ExtractBitmap();
    //         }
    //     }


    //     /// <summary>
    //     /// Extracts a ContentAlignment from a "contentalign" property
    //     /// </summary>
    //     private void ExtractContentAlignment()
    //     {
    //         // get the next token
    //         string token = this.tokenizer.NextToken();

    //         // get the content alignment
    //         System.Drawing.ContentAlignment c = GetContentAlignment(token);

    //         // should the content be wrapped
    //         bool wrap = (token.IndexOf("wrap") != -1);

    //         // store the property in the current section
    //         if (style == MAINSECTIONSS)
    //         {
    //             if (section == TITLE)
    //             {
    //                 info.Header.SpecialAlignment = c;
    //             }
    //             else if (section == WATERMARK)
    //             {
    //                 info.Expando.WatermarkAlignment = c;
    //             }
    //         }
    //         else if (style == SECTIONSS)
    //         {
    //             if (section == TITLE)
    //             {
    //                 info.Header.NormalAlignment = c;
    //             }
    //             else if (section == WATERMARK)
    //             {
    //                 info.Expando.WatermarkAlignment = c;
    //             }
    //         }
    //         else if (style == TASKPANE)
    //         {
    //             if (section == BACKDROP)
    //             {
    //                 info.TaskPane.WatermarkAlignment = c;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Returns the ContentAlignment value contained in the specified string
    //     /// </summary>
    //     /// <param name="s"></param>
    //     /// <returns></returns>
    //     private System.Drawing.ContentAlignment GetContentAlignment(string s)
    //     {
    //         System.Drawing.ContentAlignment c;

    //         // is it aligned with the top
    //         if (s.IndexOf("top") != -1)
    //         {
    //             if (s.IndexOf("left") != -1)
    //             {
    //                 c = System.Drawing.ContentAlignment.TopLeft;
    //             }
    //             else if (s.IndexOf("center") != -1)
    //             {
    //                 c = System.Drawing.ContentAlignment.TopCenter;
    //             }
    //             else if (s.IndexOf("right") != -1)
    //             {
    //                 c = System.Drawing.ContentAlignment.TopRight;
    //             }
    //             // assume it's left aligned
    //             else
    //             {
    //                 c = System.Drawing.ContentAlignment.TopLeft;
    //             }
    //         }
    //         // is it aligned with the middle
    //         else if (s.IndexOf("middle") != -1)
    //         {
    //             if (s.IndexOf("left") != -1)
    //             {
    //                 c = System.Drawing.ContentAlignment.MiddleLeft;
    //             }
    //             else if (s.IndexOf("center") != -1)
    //             {
    //                 c = System.Drawing.ContentAlignment.MiddleCenter;
    //             }
    //             else if (s.IndexOf("right") != -1)
    //             {
    //                 c = System.Drawing.ContentAlignment.MiddleRight;
    //             }
    //             // assume it's left aligned
    //             else
    //             {
    //                 c = System.Drawing.ContentAlignment.MiddleLeft;
    //             }
    //         }
    //         // is it aligned with the bottom
    //         else if (s.IndexOf("bottom") != -1)
    //         {
    //             if (s.IndexOf("left") != -1)
    //             {
    //                 c = System.Drawing.ContentAlignment.BottomLeft;
    //             }
    //             else if (s.IndexOf("center") != -1)
    //             {
    //                 c = System.Drawing.ContentAlignment.BottomCenter;
    //             }
    //             else if (s.IndexOf("right") != -1)
    //             {
    //                 c = System.Drawing.ContentAlignment.BottomRight;
    //             }
    //             // assume it's left aligned
    //             else
    //             {
    //                 c = System.Drawing.ContentAlignment.BottomLeft;
    //             }
    //         }
    //         // ckeck for wrapping
    //         else
    //         {
    //             // assume values are aligned with the middle
    //             if (s.Equals("wrapleft"))
    //             {
    //                 c = System.Drawing.ContentAlignment.MiddleLeft;
    //             }
    //             if (s.Equals("wrapcenter"))
    //             {
    //                 c = System.Drawing.ContentAlignment.MiddleRight;
    //             }
    //             if (s.Equals("wrapright"))
    //             {
    //                 c = System.Drawing.ContentAlignment.MiddleRight;
    //             }
    //             // assume middle left alignment
    //             else
    //             {
    //                 c = System.Drawing.ContentAlignment.MiddleLeft;
    //             }
    //         }

    //         return c;
    //     }


    //     /// <summary>
    //     /// Gets the FontFace property
    //     /// </summary>
    //     private void ExtractFontFace()
    //     {
    //         // get the fontsize value
    //         int id = Int32.Parse(this.tokenizer.NextToken());
    //         string fontName = ThemeManager.GetResourceString(id);

    //         if (style == MAINSECTIONSS || style == SECTIONSS)
    //         {
    //             if (section == EXPANDO)
    //             {
    //                 if (fontName != null && fontName.Length > 0)
    //                 {
    //                     info.Header.FontName = fontName;
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the FontFace property
    //     /// </summary>
    //     private void ExtractFontSize()
    //     {
    //         // get the fontsize value
    //         int id = Int32.Parse(this.tokenizer.NextToken());
    //         string fontSize = ThemeManager.GetResourceString(id);

    //         if (style == MAINSECTIONSS || style == SECTIONSS)
    //         {
    //             if (section == EXPANDO)
    //             {
    //                 if (fontSize != null && fontSize.Length > 0)
    //                 {
    //                     info.Header.FontSize = Single.Parse(fontSize);
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the FontWeight property
    //     /// </summary>
    //     private void ExtractFontWeight()
    //     {
    //         // set a default value incase something goes wrong
    //         int weight = 400;

    //         // get the fontweight value
    //         int id = Int32.Parse(this.tokenizer.NextToken());
    //         string fontWeight = ThemeManager.GetResourceString(id);

    //         if (fontWeight != null && fontWeight.Length > 0)
    //         {
    //             weight = Int32.Parse(fontWeight);
    //         }

    //         FontStyle fontStyle;

    //         // is it bold
    //         if (weight == 700)
    //         {
    //             fontStyle = FontStyle.Bold;
    //         }
    //         else
    //         {
    //             fontStyle = FontStyle.Regular;
    //         }

    //         // update the property
    //         if (style == MAINSECTIONSS)
    //         {
    //             if (section == BUTTON || section == HEADER)
    //             {
    //                 info.Header.FontWeight = fontStyle;
    //             }
    //         }
    //         else if (style == SECTIONSS)
    //         {
    //             if (section == BUTTON || section == HEADER)
    //             {
    //                 info.Header.FontWeight = fontStyle;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the FontStyle property
    //     /// </summary>
    //     private void ExtractFontStyle()
    //     {
    //         // get the next token
    //         string token = this.tokenizer.NextToken();

    //         FontStyle fontStyle;

    //         // get the fontstyle
    //         if (token.Equals("underline"))
    //         {
    //             fontStyle = FontStyle.Underline;
    //         }
    //         else if (token.Equals("italic"))
    //         {
    //             fontStyle = FontStyle.Italic;
    //         }
    //         else if (token.Equals("strikeout"))
    //         {
    //             fontStyle = FontStyle.Strikeout;
    //         }
    //         else
    //         {
    //             fontStyle = FontStyle.Regular;
    //         }

    //         // update the property
    //         if (style == MAINSECTIONSS || style == SECTIONSS)
    //         {
    //             if (section == TITLE)
    //             {
    //                 info.Header.FontStyle = fontStyle;
    //             }
    //         }
    //         else if (style == MAINSECTIONTASKSS)
    //         {
    //             if (section - MOUSEFOCUSED == BUTTON)
    //             {
    //                 info.TaskItem.FontDecoration = fontStyle;
    //             }
    //         }
    //         else if (style == SECTIONTASKSS)
    //         {
    //             if (section - MOUSEFOCUSED == BUTTON)
    //             {
    //                 info.TaskItem.FontDecoration = fontStyle;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Background property
    //     /// </summary>
    //     private void ExtractBackground()
    //     {
    //         // take a look at the next token
    //         string token = this.tokenizer.PeekToken();

    //         // is it a bitmap
    //         if (token.Equals("rcbmp"))
    //         {
    //             this.tokenizer.SkipToken();

    //             ExtractBitmap();
    //         }
    //         // is it a gradient
    //         else if (token.Equals("gradient"))
    //         {
    //             this.tokenizer.SkipToken();

    //             // get the gradient colors and direction
    //             info.TaskPane.GradientStartColor = ExtractColor();
    //             info.TaskPane.GradientEndColor = ExtractColor();
    //             info.TaskPane.GradientDirection = (LinearGradientMode)Int32.Parse(tokenizer.NextToken());
    //         }
    //         // just a normal color
    //         else
    //         {
    //             Color c = ExtractColor();

    //             // if all components are 0, don't bother
    //             if (c.A == 0 && c.R == 0 && c.G == 0 && c.B == 0)
    //             {
    //                 return;
    //             }

    //             // update the property
    //             if (style == MAINSECTIONSS)
    //             {
    //                 if (section == WATERMARK || section == TASKLIST)
    //                 {
    //                     info.Expando.SpecialBackColor = c;
    //                 }
    //                 else if (section == EXPANDO)
    //                 {
    //                     info.Expando.SpecialBackColor = c;
    //                     info.Header.SpecialBackColor = c;
    //                 }
    //                 else if (section == HEADER)
    //                 {
    //                     info.Header.SpecialBackColor = c;
    //                 }
    //             }
    //             else if (style == SECTIONSS)
    //             {
    //                 if (section == TASKLIST)
    //                 {
    //                     info.Expando.NormalBackColor = c;
    //                 }
    //                 else if (section == EXPANDO)
    //                 {
    //                     info.Expando.NormalBackColor = c;
    //                     info.Header.NormalBackColor = c;
    //                 }
    //                 else if (section == HEADER)
    //                 {
    //                     info.Header.NormalBackColor = c;
    //                 }
    //             }
    //             else if (style == TASKPANE)
    //             {
    //                 if (section == BACKDROP || section == SECTIONLIST)
    //                 {
    //                     info.TaskPane.GradientStartColor = c;
    //                     info.TaskPane.GradientEndColor = c;
    //                     info.TaskPane.GradientDirection = LinearGradientMode.Vertical;
    //                 }
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Extracts bitmap specified by the current token from
    //     /// the ShellStyle.dll
    //     /// </summary>
    //     private void ExtractBitmap()
    //     {
    //         // get the bitmap id
    //         string id = this.tokenizer.NextToken();

    //         // don't care about the next token
    //         //this.tokenizer.SkipToken();
    //         ImageStretchMode stretch = (ImageStretchMode)Int32.Parse(this.tokenizer.NextToken());

    //         // get the transparency value
    //         string transparent = this.tokenizer.NextToken();

    //         Bitmap image = null;

    //         if (stretch == ImageStretchMode.Transparent || stretch == ImageStretchMode.ARGBImage)
    //         {
    //             // get the png
    //             image = ThemeManager.GetResourcePNG(id);
    //         }
    //         else
    //         {
    //             // get the bitmap
    //             image = ThemeManager.GetResourceBMP(id);

    //             // set the transparency color
    //             if (transparent.StartsWith("#"))
    //             {
    //                 byte[] bytes = GetBytes(transparent);
    //                 image.MakeTransparent(Color.FromArgb((int)bytes[0], (int)bytes[1], (int)bytes[2]));
    //             }
    //         }

    //         // update the property
    //         if (style == MAINSECTIONSS)
    //         {
    //             if (section == BUTTON || section == HEADER)
    //             {
    //                 info.Header.SpecialBackImage = image;
    //             }
    //             else if (section == ARROW)
    //             {
    //                 info.Header.SpecialArrowDown = image;
    //             }
    //             else if (section - SELECTED - MOUSEFOCUSED == ARROW)
    //             {
    //                 info.Header.SpecialArrowUpHot = image;
    //             }
    //             else if (section - SELECTED == ARROW)
    //             {
    //                 info.Header.SpecialArrowUp = image;
    //             }
    //             else if (section - MOUSEFOCUSED == ARROW)
    //             {
    //                 info.Header.SpecialArrowDownHot = image;
    //             }
    //             else if (section == TASKLIST)
    //             {
    //                 info.Expando.SpecialBackImage = image;
    //             }
    //         }
    //         else if (style == SECTIONSS)
    //         {
    //             if (section == BUTTON || section == HEADER)
    //             {
    //                 info.Header.NormalBackImage = image;
    //             }
    //             else if (section == ARROW)
    //             {
    //                 info.Header.NormalArrowDown = image;
    //             }
    //             else if (section - SELECTED - MOUSEFOCUSED == ARROW)
    //             {
    //                 info.Header.NormalArrowUpHot = image;
    //             }
    //             else if (section - SELECTED == ARROW)
    //             {
    //                 info.Header.NormalArrowUp = image;
    //             }
    //             else if (section - MOUSEFOCUSED == ARROW)
    //             {
    //                 info.Header.NormalArrowDownHot = image;
    //             }
    //             else if (section == TASKLIST)
    //             {
    //                 info.Expando.NormalBackImage = image;
    //             }
    //         }
    //         else if (style == TASKPANE)
    //         {
    //             if (section == SECTIONLIST)
    //             {
    //                 info.TaskPane.BackImage = image;
    //                 info.TaskPane.StretchMode = stretch;
    //             }
    //             else if (section == BACKDROP)
    //             {
    //                 info.TaskPane.Watermark = image;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Foreground color property
    //     /// </summary>
    //     private void ExtractForeground()
    //     {
    //         // get the foreground color
    //         Color c = ExtractColor();

    //         // update the property
    //         if (style == MAINSECTIONSS)
    //         {
    //             if (section == BUTTON || section == HEADER)
    //             {
    //                 info.Header.SpecialTitleColor = c;
    //             }
    //             else if (section == TITLE)
    //             {
    //                 info.Header.SpecialTitleColor = c;
    //             }
    //             else if (section - MOUSEFOCUSED == TITLE)
    //             {
    //                 info.Header.SpecialTitleHotColor = c;
    //             }
    //             else if (section - KEYFOCUSED == TITLE)
    //             {
    //                 info.Header.SpecialTitleHotColor = c;
    //             }
    //         }
    //         else if (style == MAINSECTIONTASKSS)
    //         {
    //             if (section == BUTTON)
    //             {
    //                 info.TaskItem.LinkColor = c;
    //             }
    //             else if (section == TITLE)
    //             {
    //                 info.TaskItem.LinkColor = c;
    //             }
    //             else if (section - MOUSEFOCUSED == TITLE)
    //             {
    //                 info.TaskItem.HotLinkColor = c;
    //             }
    //         }
    //         else if (style == SECTIONSS)
    //         {
    //             if (section == BUTTON || section == HEADER)
    //             {
    //                 info.Header.NormalTitleColor = c;
    //             }
    //             else if (section == TITLE)
    //             {
    //                 info.Header.NormalTitleColor = c;
    //             }
    //             else if (section - MOUSEFOCUSED == TITLE)
    //             {
    //                 info.Header.NormalTitleHotColor = c;
    //             }
    //             else if (section - KEYFOCUSED == TITLE)
    //             {
    //                 info.Header.NormalTitleHotColor = c;
    //             }
    //         }
    //         else if (style == SECTIONTASKSS)
    //         {
    //             if (section == BUTTON)
    //             {
    //                 info.TaskItem.LinkColor = c;
    //             }
    //             else if (section == TITLE)
    //             {
    //                 info.TaskItem.LinkColor = c;
    //             }
    //             else if (section - MOUSEFOCUSED == TITLE)
    //             {
    //                 info.TaskItem.HotLinkColor = c;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Padding property
    //     /// </summary>
    //     private void ExtractPadding()
    //     {
    //         // get the padding value
    //         Padding p = new Padding();
    //         p.Left = Int32.Parse(this.tokenizer.NextToken());
    //         p.Top = Int32.Parse(this.tokenizer.NextToken());
    //         p.Right = Int32.Parse(this.tokenizer.NextToken());
    //         p.Bottom = Int32.Parse(this.tokenizer.NextToken());

    //         // update the property
    //         if (style == MAINSECTIONSS)
    //         {
    //             if (section == BUTTON || section == HEADER)
    //             {
    //                 info.Header.SpecialPadding = p;
    //             }
    //             else if (section == TASKLIST)
    //             {
    //                 info.Expando.SpecialPadding = p;
    //             }
    //         }
    //         else if (style == MAINSECTIONTASKSS)
    //         {
    //             if (section == TITLE)
    //             {
    //                 info.TaskItem.Padding = p;
    //             }
    //         }
    //         else if (style == SECTIONSS)
    //         {
    //             if (section == BUTTON || section == HEADER)
    //             {
    //                 info.Header.NormalPadding = p;
    //             }
    //             else if (section == TASKLIST)
    //             {
    //                 info.Expando.NormalPadding = p;
    //             }
    //         }
    //         else if (style == SECTIONTASKSS)
    //         {
    //             if (section == TITLE)
    //             {
    //                 info.TaskItem.Padding = p;
    //             }
    //         }
    //         else if (style == TASKPANE)
    //         {
    //             if (section == SECTIONLIST)
    //             {
    //                 info.TaskPane.Padding = p;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Margin property
    //     /// </summary>
    //     private void ExtractMargin()
    //     {
    //         // get the margin property
    //         Margin m = new Margin();
    //         m.Left = Int32.Parse(this.tokenizer.NextToken());
    //         m.Top = Int32.Parse(this.tokenizer.NextToken());
    //         m.Bottom = Int32.Parse(this.tokenizer.NextToken());
    //         m.Right = Int32.Parse(this.tokenizer.NextToken());

    //         // update the property
    //         if (style == MAINSECTIONTASKSS)
    //         {
    //             if (section == DESTINATIONTASK)
    //             {
    //                 info.TaskItem.Margin = m;
    //             }
    //             else if (section == ACTIONTASK)
    //             {
    //                 info.TaskItem.Margin = m;
    //             }
    //         }
    //         else if (style == SECTIONTASKSS)
    //         {
    //             if (section == DESTINATIONTASK)
    //             {
    //                 info.TaskItem.Margin = m;
    //             }
    //             else if (section == ACTIONTASK)
    //             {
    //                 info.TaskItem.Margin = m;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Border property
    //     /// </summary>
    //     private void ExtractBorder()
    //     {
    //         // gets the border property
    //         Border b = new Border();
    //         b.Left = Int32.Parse(this.tokenizer.NextToken());
    //         b.Top = Int32.Parse(this.tokenizer.NextToken());
    //         b.Right = Int32.Parse(this.tokenizer.NextToken());
    //         b.Bottom = Int32.Parse(this.tokenizer.NextToken());

    //         // update the property
    //         if (style == MAINSECTIONSS)
    //         {
    //             if (section == BUTTON || section == HEADER)
    //             {
    //                 info.Header.SpecialBorder = b;
    //             }
    //             else if (section == TASKLIST)
    //             {
    //                 info.Expando.SpecialBorder = b;
    //             }
    //         }
    //         else if (style == SECTIONSS)
    //         {
    //             if (section == BUTTON || section == HEADER)
    //             {
    //                 info.Header.NormalBorder = b;
    //             }
    //             else if (section == TASKLIST)
    //             {
    //                 info.Expando.NormalBorder = b;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Gets the Border color property
    //     /// </summary>
    //     private void ExtractBorderColor()
    //     {
    //         // get the border color
    //         Color c = ExtractColor();

    //         // update the property
    //         if (style == MAINSECTIONSS)
    //         {
    //             if (section == BUTTON || section == HEADER)
    //             {
    //                 info.Header.SpecialBorderColor = c;
    //             }
    //             else if (section == TASKLIST)
    //             {
    //                 info.Expando.SpecialBorderColor = c;
    //             }
    //         }
    //         else if (style == SECTIONSS)
    //         {
    //             if (section == BUTTON || section == HEADER)
    //             {
    //                 info.Header.NormalBorderColor = c;
    //             }
    //             else if (section == TASKLIST)
    //             {
    //                 info.Expando.NormalBorderColor = c;
    //             }
    //         }
    //     }


    //     /// <summary>
    //     /// Extracts a color from the current token
    //     /// </summary>
    //     /// <returns></returns>
    //     private Color ExtractColor()
    //     {
    //         // take a look at the next token
    //         string token = this.tokenizer.PeekToken();

    //         Color c = Color.Transparent;

    //         // is it a rgb
    //         if (token.Equals("rgb"))
    //         {
    //             c = ExtractRGBColor();
    //         }
    //         // or an argb
    //         else if (token.Equals("argb"))
    //         {
    //             c = ExtractARGBColor();
    //         }
    //         // or a hex color
    //         else if (token.StartsWith("#"))
    //         {
    //             c = ExtractHexColor(token);
    //         }
    //         // it must be a color name
    //         else
    //         {
    //             c = Color.FromName(token);
    //         }

    //         return c;
    //     }


    //     /// <summary>
    //     /// Extracts a RGB color from the current token
    //     /// </summary>
    //     /// <returns></returns>
    //     private Color ExtractRGBColor()
    //     {
    //         // if the next token is "rgb" then skip it
    //         if (this.tokenizer.PeekToken().Equals("rgb"))
    //         {
    //             tokenizer.SkipToken();
    //         }

    //         // extract and return the color
    //         return Color.FromArgb(Int32.Parse(this.tokenizer.NextToken()),          // Red
    //             Int32.Parse(this.tokenizer.NextToken()),        // Green
    //             Int32.Parse(this.tokenizer.NextToken()));       // Blue
    //     }


    //     /// <summary>
    //     /// Extracts an ARGB color from the current token
    //     /// </summary>
    //     /// <returns></returns>
    //     private Color ExtractARGBColor()
    //     {
    //         // if the next token is "argb" then skip it
    //         if (this.tokenizer.PeekToken().Equals("argb"))
    //         {
    //             tokenizer.SkipToken();
    //         }

    //         // extract the color
    //         Color c = Color.FromArgb(Int32.Parse(this.tokenizer.NextToken()),   // Alpha
    //             Int32.Parse(this.tokenizer.NextToken()),        // Red
    //             Int32.Parse(this.tokenizer.NextToken()),        // Green
    //             Int32.Parse(this.tokenizer.NextToken()));       // Blue

    //         // if all components are 0, return the color
    //         if (c.A == 0 && c.R == 0 && c.G == 0 && c.B == 0)
    //         {
    //             return c;
    //         }

    //         // adjust transparency
    //         c = Color.FromArgb(255 - c.A, c.R, c.G, c.B);

    //         return c;
    //     }


    //     /// <summary>
    //     /// Extracts a color from a hexadecimal string
    //     /// </summary>
    //     /// <param name="s"></param>
    //     /// <returns></returns>
    //     private Color ExtractHexColor(string s)
    //     {
    //         byte[] bytes = GetBytes(s.Substring(1));

    //         return Color.FromArgb((int)bytes[0], (int)bytes[1], (int)bytes[2]);
    //     }


    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="hexString"></param>
    //     /// <returns></returns>
    //     public byte[] GetBytes(string hexString)
    //     {
    //         //discarded = 0;
    //         StringBuilder sb = new StringBuilder();
    //         char c;

    //         // remove all none A-F, 0-9, characters
    //         for (int i = 0; i < hexString.Length; i++)
    //         {
    //             c = hexString[i];

    //             if (IsHexDigit(c))
    //             {
    //                 sb.Append(c);
    //             }
    //         }

    //         // if odd number of characters, discard last character
    //         if (sb.Length % 2 != 0)
    //         {
    //             sb.Remove(sb.Length - 1, 1);
    //         }

    //         int byteLength = sb.Length / 2;
    //         byte[] bytes = new byte[byteLength];
    //         string hex;
    //         int j = 0;
    //         for (int i = 0; i < bytes.Length; i++)
    //         {
    //             hex = new String(new Char[] { sb[j], sb[j + 1] });
    //             bytes[i] = HexToByte(hex);
    //             j = j + 2;
    //         }

    //         return bytes;
    //     }


    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="c"></param>
    //     /// <returns></returns>
    //     private bool IsHexDigit(Char c)
    //     {
    //         int numChar;
    //         int numA = Convert.ToInt32('A');
    //         int num1 = Convert.ToInt32('0');
    //         c = Char.ToUpper(c);
    //         numChar = Convert.ToInt32(c);

    //         if (numChar >= numA && numChar < (numA + 6))
    //         {
    //             return true;
    //         }

    //         if (numChar >= num1 && numChar < (num1 + 10))
    //         {
    //             return true;
    //         }

    //         return false;
    //     }


    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="hex"></param>
    //     /// <returns></returns>
    //     private byte HexToByte(string hex)
    //     {
    //         if (hex.Length > 2 || hex.Length <= 0)
    //         {
    //             throw new ArgumentException("hex must be 1 or 2 characters in length");
    //         }

    //         byte newByte = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

    //         return newByte;
    //     }
    // }

    // #endregion



    // #region StringTokenizer Class

    // /// <summary>
    // /// A class that breaks a string into tokens
    // /// </summary>
    // internal class StringTokenizer
    // {
    //     /// <summary>
    //     /// The index of the current token
    //     /// </summary>
    //     private int currentIndex;

    //     /// <summary>
    //     /// The number of tokens
    //     /// </summary>
    //     private int numberOfTokens;

    //     /// <summary>
    //     /// Internal list of tokens
    //     /// </summary>
    //     private ArrayList tokens;

    //     /// <summary>
    //     /// The string to be parsed
    //     /// </summary>
    //     private string source;

    //     /// <summary>
    //     /// The delimiters
    //     /// </summary>
    //     private string delimiter;


    //     /// <summary>
    //     /// Initializes a new instance of the StringTokenizer class with the 
    //     /// specified source string and delimiters
    //     /// </summary>
    //     /// <param name="source">The String to be parsed</param>
    //     /// <param name="delimiter">A String containing the delimiters</param>
    //     public StringTokenizer(string source, string delimiter)
    //     {
    //         this.tokens = new ArrayList(10);
    //         this.source = source;
    //         this.delimiter = delimiter;

    //         if (delimiter.Length == 0)
    //         {
    //             this.delimiter = " ";
    //         }

    //         this.Tokenize();
    //     }


    //     /// <summary>
    //     /// Initializes a new instance of the StringTokenizer class with the 
    //     /// specified source string and delimiters
    //     /// </summary>
    //     /// <param name="source">The String to be parsed</param>
    //     /// <param name="delimiter">A char array containing the delimiters</param>
    //     public StringTokenizer(string source, char[] delimiter)
    //         : this(source, new string(delimiter))
    //     {

    //     }


    //     /// <summary>
    //     /// Initializes a new instance of the StringTokenizer class with the 
    //     /// specified source string
    //     /// </summary>
    //     /// <param name="source">The String to be parsed</param>
    //     public StringTokenizer(string source)
    //         : this(source, "")
    //     {

    //     }


    //     /// <summary>
    //     /// Parses the source string
    //     /// </summary>
    //     private void Tokenize()
    //     {
    //         string s = this.source;
    //         StringBuilder sb = new StringBuilder();
    //         this.numberOfTokens = 0;
    //         this.tokens.Clear();
    //         this.currentIndex = 0;

    //         int i = 0;

    //         while (i < this.source.Length)
    //         {
    //             if (this.delimiter.IndexOf(this.source[i]) != -1)
    //             {
    //                 if (sb.Length > 0)
    //                 {
    //                     this.tokens.Add(sb.ToString());

    //                     sb.Remove(0, sb.Length);
    //                 }
    //             }
    //             else
    //             {
    //                 sb.Append(this.source[i]);
    //             }

    //             i++;
    //         }

    //         this.numberOfTokens = this.tokens.Count;
    //     }


    //     /// <summary>
    //     /// Returns the number of tokens in the string
    //     /// </summary>
    //     /// <returns>The number of tokens in the string</returns>
    //     public int CountTokens()
    //     {
    //         return this.tokens.Count;
    //     }


    //     /// <summary>
    //     /// Checks if there are more tokens available from this tokenizer's 
    //     /// string
    //     /// </summary>
    //     /// <returns>true if more tokens are available, false otherwise</returns>
    //     public bool HasMoreTokens()
    //     {
    //         if (this.currentIndex <= (this.tokens.Count - 1))
    //         {
    //             return true;
    //         }
    //         else
    //         {
    //             return false;
    //         }
    //     }


    //     /// <summary>
    //     /// Returns the current token and moves to the next token
    //     /// </summary>
    //     /// <returns>The current token</returns>
    //     public string NextToken()
    //     {
    //         string s = "";

    //         if (this.currentIndex <= (this.tokens.Count - 1))
    //         {
    //             s = (string)tokens[this.currentIndex];

    //             this.currentIndex++;

    //             return s;
    //         }
    //         else
    //         {
    //             return null;
    //         }
    //     }


    //     /// <summary>
    //     /// Moves to the next token without returning the current token
    //     /// </summary>
    //     public void SkipToken()
    //     {
    //         if (this.currentIndex <= (this.tokens.Count - 1))
    //         {
    //             this.currentIndex++;
    //         }
    //     }


    //     /// <summary>
    //     /// Returns the current token but does not move to the next token
    //     /// </summary>
    //     /// <returns></returns>
    //     public string PeekToken()
    //     {
    //         string s = "";

    //         if (this.currentIndex <= (this.tokens.Count - 1))
    //         {
    //             s = (string)tokens[this.currentIndex];

    //             return s;
    //         }
    //         else
    //         {
    //             return null;
    //         }
    //     }


    //     /// <summary>
    //     /// Returns the source string
    //     /// </summary>
    //     public string Source
    //     {
    //         get
    //         {
    //             return this.source;
    //         }
    //     }


    //     /// <summary>
    //     /// Returns a string that contains the delimiters used to 
    //     /// parse the source string
    //     /// </summary>
    //     public string Delimiter
    //     {
    //         get
    //         {
    //             return this.delimiter;
    //         }
    //     }
    // }

    // #endregion

    // #endregion

    // #region XPControl

    // #region XPCheckedListBox

    // /// <summary>
    // /// A CheckedListBox that correctly draws themed borders if Windows XP 
    // /// Visual Styles are enabled when it recieves a WM_PRINT message
    // /// </summary>
    // [ToolboxItem(true)]
    // public class XPCheckedListBox : ListBox
    // {
    //     /// <summary>
    //     /// The cached value of whether Xindows XP Visual Styles are enabled
    //     /// </summary>
    //     private bool visualStylesEnabled;


    //     /// <summary>
    //     /// Initializes a new instance of the XPCheckedListBox class with default settings
    //     /// </summary>
    //     public XPCheckedListBox() : base()
    //     {
    //         // check if visual styles have been enabled
    //         this.visualStylesEnabled = this.VisualStylesEnabled;
    //     }


    //     /// <summary>
    //     /// Raises the SystemColorsChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnSystemColorsChanged(EventArgs e)
    //     {
    //         base.OnSystemColorsChanged(e);

    //         // recheck if visual styles have been enabled
    //         this.visualStylesEnabled = this.VisualStylesEnabled;
    //     }


    //     /// <summary>
    //     /// Returns whether Windows XP Visual Styles are currently enabled
    //     /// </summary>
    //     protected bool VisualStylesEnabled
    //     {
    //         get
    //         {
    //             OperatingSystem os = System.Environment.OSVersion;

    //             // check if the OS id XP or higher
    //             if (os.Platform == PlatformID.Win32NT && ((os.Version.Major == 5 && os.Version.Minor >= 1) || os.Version.Major > 5))
    //             {
    //                 // are themes enabled
    //                 if (UxTheme.IsThemeActive() && UxTheme.IsAppThemed())
    //                 {
    //                     DLLVERSIONINFO version = new DLLVERSIONINFO();
    //                     version.cbSize = Marshal.SizeOf(typeof(DLLVERSIONINFO));

    //                     // are we using Common Controls v6
    //                     if (NativeMethods.DllGetVersion(ref version) == 0)
    //                     {
    //                         return (version.dwMajorVersion > 5);
    //                     }
    //                 }
    //             }

    //             return false;
    //         }
    //     }


    //     /// <summary>
    //     /// Processes Windows messages
    //     /// </summary>
    //     /// <param name="m">The Windows Message to process</param>
    //     protected override void WndProc(ref Message m)
    //     {
    //         base.WndProc(ref m);

    //         if (!this.visualStylesEnabled || this.BorderStyle != BorderStyle.Fixed3D)
    //         {
    //             return;
    //         }

    //         if (m.Msg == (int)WindowMessageFlags.WM_PRINT)
    //         {
    //             if ((m.LParam.ToInt32() & (int)WmPrintFlags.PRF_NONCLIENT) == (int)WmPrintFlags.PRF_NONCLIENT)
    //             {
    //                 // open theme data
    //                 IntPtr hTheme = UxTheme.OpenThemeData(this.Handle, UxTheme.WindowClasses.ListView);

    //                 if (hTheme != IntPtr.Zero)
    //                 {
    //                     // get the part and state needed
    //                     int partId = (int)UxTheme.Parts.ListView.ListItem;
    //                     int stateId = (int)UxTheme.PartStates.ListItem.Normal;

    //                     RECT rect = new RECT();
    //                     rect.right = this.Width;
    //                     rect.bottom = this.Height;

    //                     RECT clipRect = new RECT();

    //                     // draw the left border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.left + 2;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the top border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.top + 2;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the right border
    //                     clipRect.left = rect.right - 2;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the bottom border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.bottom - 2;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);
    //                 }

    //                 UxTheme.CloseThemeData(hTheme);
    //             }
    //         }
    //     }
    // }

    // #endregion



    // #region XPDateTimePicker

    // /// <summary>
    // /// A DateTimePicker that correctly draws themed borders if Windows XP 
    // /// Visual Styles are enabled when it recieves a WM_PRINT message
    // /// </summary>
    // [ToolboxItem(true)]
    // public class XPDateTimePicker : DateTimePicker
    // {
    //     /// <summary>
    //     /// The cached value of whether Xindows XP Visual Styles are enabled
    //     /// </summary>
    //     private bool visualStylesEnabled;


    //     /// <summary>
    //     /// Initializes a new instance of the XPDateTimePicker class with default settings
    //     /// </summary>
    //     public XPDateTimePicker() : base()
    //     {
    //         // check if visual styles have been enabled
    //         this.visualStylesEnabled = this.VisualStylesEnabled;
    //     }


    //     /// <summary>
    //     /// Raises the SystemColorsChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnSystemColorsChanged(EventArgs e)
    //     {
    //         base.OnSystemColorsChanged(e);

    //         // recheck if visual styles have been enabled
    //         this.visualStylesEnabled = this.VisualStylesEnabled;
    //     }


    //     /// <summary>
    //     /// Returns whether Windows XP Visual Styles are currently enabled
    //     /// </summary>
    //     protected bool VisualStylesEnabled
    //     {
    //         get
    //         {
    //             OperatingSystem os = System.Environment.OSVersion;

    //             // check if the OS id XP or higher
    //             if (os.Platform == PlatformID.Win32NT && ((os.Version.Major == 5 && os.Version.Minor >= 1) || os.Version.Major > 5))
    //             {
    //                 // are themes enabled
    //                 if (UxTheme.IsThemeActive() && UxTheme.IsAppThemed())
    //                 {
    //                     DLLVERSIONINFO version = new DLLVERSIONINFO();
    //                     version.cbSize = Marshal.SizeOf(typeof(DLLVERSIONINFO));

    //                     // are we using Common Controls v6
    //                     if (NativeMethods.DllGetVersion(ref version) == 0)
    //                     {
    //                         return (version.dwMajorVersion > 5);
    //                     }
    //                 }
    //             }

    //             return false;
    //         }
    //     }


    //     /// <summary>
    //     /// Processes Windows messages
    //     /// </summary>
    //     /// <param name="m">The Windows Message to process</param>
    //     protected override void WndProc(ref Message m)
    //     {
    //         base.WndProc(ref m);

    //         if (!this.visualStylesEnabled)
    //         {
    //             return;
    //         }

    //         if (m.Msg == (int)WindowMessageFlags.WM_PRINT)
    //         {
    //             if ((m.LParam.ToInt32() & (int)WmPrintFlags.PRF_NONCLIENT) == (int)WmPrintFlags.PRF_NONCLIENT)
    //             {
    //                 // open theme data
    //                 IntPtr hTheme = UxTheme.OpenThemeData(this.Handle, UxTheme.WindowClasses.Edit);

    //                 if (hTheme != IntPtr.Zero)
    //                 {
    //                     // get the part and state needed
    //                     int partId = (int)UxTheme.Parts.Edit.EditText;
    //                     int stateId = (int)UxTheme.PartStates.EditText.Normal;

    //                     RECT rect = new RECT();
    //                     rect.right = this.Width;
    //                     rect.bottom = this.Height;

    //                     RECT clipRect = new RECT();

    //                     // draw the left border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.left + 2;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the top border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.top + 2;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the right border
    //                     clipRect.left = rect.right - 2;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the bottom border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.bottom - 2;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);
    //                 }

    //                 UxTheme.CloseThemeData(hTheme);
    //             }
    //         }
    //     }
    // }

    // #endregion



    // #region XPListBox

    // /// <summary>
    // /// A ListBox that correctly draws themed borders if Windows XP 
    // /// Visual Styles are enabled when it recieves a WM_PRINT message
    // /// </summary>
    // [ToolboxItem(true)]
    // public class XPListBox : ListBox
    // {
    //     /// <summary>
    //     /// The cached value of whether Xindows XP Visual Styles are enabled
    //     /// </summary>
    //     private bool visualStylesEnabled;


    //     /// <summary>
    //     /// Initializes a new instance of the XPListBox class with default settings
    //     /// </summary>
    //     public XPListBox() : base()
    //     {
    //         // check if visual styles have been enabled
    //         this.visualStylesEnabled = this.VisualStylesEnabled;
    //     }


    //     /// <summary>
    //     /// Raises the SystemColorsChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnSystemColorsChanged(EventArgs e)
    //     {
    //         base.OnSystemColorsChanged(e);

    //         // recheck if visual styles have been enabled
    //         this.visualStylesEnabled = this.VisualStylesEnabled;
    //     }


    //     /// <summary>
    //     /// Returns whether Windows XP Visual Styles are currently enabled
    //     /// </summary>
    //     protected bool VisualStylesEnabled
    //     {
    //         get
    //         {
    //             OperatingSystem os = System.Environment.OSVersion;

    //             // check if the OS id XP or higher
    //             if (os.Platform == PlatformID.Win32NT && ((os.Version.Major == 5 && os.Version.Minor >= 1) || os.Version.Major > 5))
    //             {
    //                 // are themes enabled
    //                 if (UxTheme.IsThemeActive() && UxTheme.IsAppThemed())
    //                 {
    //                     DLLVERSIONINFO version = new DLLVERSIONINFO();
    //                     version.cbSize = Marshal.SizeOf(typeof(DLLVERSIONINFO));

    //                     // are we using Common Controls v6
    //                     if (NativeMethods.DllGetVersion(ref version) == 0)
    //                     {
    //                         return (version.dwMajorVersion > 5);
    //                     }
    //                 }
    //             }

    //             return false;
    //         }
    //     }


    //     /// <summary>
    //     /// Processes Windows messages
    //     /// </summary>
    //     /// <param name="m">The Windows Message to process</param>
    //     protected override void WndProc(ref Message m)
    //     {
    //         base.WndProc(ref m);

    //         if (!this.visualStylesEnabled || this.BorderStyle != BorderStyle.Fixed3D)
    //         {
    //             return;
    //         }

    //         if (m.Msg == (int)WindowMessageFlags.WM_PRINT)
    //         {
    //             if ((m.LParam.ToInt32() & (int)WmPrintFlags.PRF_NONCLIENT) == (int)WmPrintFlags.PRF_NONCLIENT)
    //             {
    //                 // open theme data
    //                 IntPtr hTheme = UxTheme.OpenThemeData(this.Handle, UxTheme.WindowClasses.ListView);

    //                 if (hTheme != IntPtr.Zero)
    //                 {
    //                     // get the part and state needed
    //                     int partId = (int)UxTheme.Parts.ListView.ListItem;
    //                     int stateId = (int)UxTheme.PartStates.ListItem.Normal;

    //                     RECT rect = new RECT();
    //                     rect.right = this.Width;
    //                     rect.bottom = this.Height;

    //                     RECT clipRect = new RECT();

    //                     // draw the left border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.left + 2;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the top border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.top + 2;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the right border
    //                     clipRect.left = rect.right - 2;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the bottom border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.bottom - 2;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);
    //                 }

    //                 UxTheme.CloseThemeData(hTheme);
    //             }
    //         }
    //     }
    // }

    // #endregion



    // #region XPListView

    // /// <summary>
    // /// A ListView that correctly draws themed borders if Windows XP 
    // /// Visual Styles are enabled when it recieves a WM_PRINT message
    // /// </summary>
    // [ToolboxItem(true)]
    // public class XPListView : ListView
    // {
    //     /// <summary>
    //     /// The cached value of whether Xindows XP Visual Styles are enabled
    //     /// </summary>
    //     private bool visualStylesEnabled;


    //     /// <summary>
    //     /// Initializes a new instance of the XPListView class with default settings
    //     /// </summary>
    //     public XPListView() : base()
    //     {
    //         // check if visual styles have been enabled
    //         this.visualStylesEnabled = this.VisualStylesEnabled;
    //     }


    //     /// <summary>
    //     /// Raises the SystemColorsChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnSystemColorsChanged(EventArgs e)
    //     {
    //         base.OnSystemColorsChanged(e);

    //         // recheck if visual styles have been enabled
    //         this.visualStylesEnabled = this.VisualStylesEnabled;
    //     }


    //     /// <summary>
    //     /// Returns whether Windows XP Visual Styles are currently enabled
    //     /// </summary>
    //     protected bool VisualStylesEnabled
    //     {
    //         get
    //         {
    //             OperatingSystem os = System.Environment.OSVersion;

    //             // check if the OS id XP or higher
    //             if (os.Platform == PlatformID.Win32NT && ((os.Version.Major == 5 && os.Version.Minor >= 1) || os.Version.Major > 5))
    //             {
    //                 // are themes enabled
    //                 if (UxTheme.IsThemeActive() && UxTheme.IsAppThemed())
    //                 {
    //                     DLLVERSIONINFO version = new DLLVERSIONINFO();
    //                     version.cbSize = Marshal.SizeOf(typeof(DLLVERSIONINFO));

    //                     // are we using Common Controls v6
    //                     if (NativeMethods.DllGetVersion(ref version) == 0)
    //                     {
    //                         return (version.dwMajorVersion > 5);
    //                     }
    //                 }
    //             }

    //             return false;
    //         }
    //     }


    //     /// <summary>
    //     /// Processes Windows messages
    //     /// </summary>
    //     /// <param name="m">The Windows Message to process</param>
    //     protected override void WndProc(ref Message m)
    //     {
    //         base.WndProc(ref m);

    //         if (!this.visualStylesEnabled || this.BorderStyle != BorderStyle.Fixed3D)
    //         {
    //             return;
    //         }

    //         if (m.Msg == (int)WindowMessageFlags.WM_PRINT)
    //         {
    //             if ((m.LParam.ToInt32() & (int)WmPrintFlags.PRF_NONCLIENT) == (int)WmPrintFlags.PRF_NONCLIENT)
    //             {
    //                 // open theme data
    //                 IntPtr hTheme = UxTheme.OpenThemeData(this.Handle, UxTheme.WindowClasses.ListView);

    //                 if (hTheme != IntPtr.Zero)
    //                 {
    //                     // get the part and state needed
    //                     int partId = (int)UxTheme.Parts.ListView.ListItem;
    //                     int stateId = (int)UxTheme.PartStates.ListItem.Normal;

    //                     if (!this.Enabled)
    //                     {
    //                         stateId = (int)UxTheme.PartStates.ListItem.Disabled;
    //                     }

    //                     RECT rect = new RECT();
    //                     rect.right = this.Width;
    //                     rect.bottom = this.Height;

    //                     RECT clipRect = new RECT();

    //                     // draw the left border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.left + 2;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the top border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.top + 2;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the right border
    //                     clipRect.left = rect.right - 2;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the bottom border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.bottom - 2;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);
    //                 }

    //                 UxTheme.CloseThemeData(hTheme);
    //             }
    //         }
    //     }
    // }

    // #endregion



    // #region XPTextBox

    // /// <summary>
    // /// A TextBox that correctly draws themed borders if Windows XP 
    // /// Visual Styles are enabled when it recieves a WM_PRINT message
    // /// </summary>
    // [ToolboxItem(true)]
    // public class XPTextBox : TextBox
    // {
    //     /// <summary>
    //     /// The cached value of whether Xindows XP Visual Styles are enabled
    //     /// </summary>
    //     private bool visualStylesEnabled;


    //     /// <summary>
    //     /// Initializes a new instance of the XPTextBox class with default settings
    //     /// </summary>
    //     public XPTextBox() : base()
    //     {
    //         // check if visual styles have been enabled
    //         this.visualStylesEnabled = this.VisualStylesEnabled;
    //     }


    //     /// <summary>
    //     /// Raises the SystemColorsChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnSystemColorsChanged(EventArgs e)
    //     {
    //         base.OnSystemColorsChanged(e);

    //         // recheck if visual styles have been enabled
    //         this.visualStylesEnabled = this.VisualStylesEnabled;
    //     }


    //     /// <summary>
    //     /// Returns whether Windows XP Visual Styles are currently enabled
    //     /// </summary>
    //     protected bool VisualStylesEnabled
    //     {
    //         get
    //         {
    //             OperatingSystem os = System.Environment.OSVersion;

    //             // check if the OS id XP or higher
    //             if (os.Platform == PlatformID.Win32NT && ((os.Version.Major == 5 && os.Version.Minor >= 1) || os.Version.Major > 5))
    //             {
    //                 // are themes enabled
    //                 if (UxTheme.IsThemeActive() && UxTheme.IsAppThemed())
    //                 {
    //                     DLLVERSIONINFO version = new DLLVERSIONINFO();
    //                     version.cbSize = Marshal.SizeOf(typeof(DLLVERSIONINFO));

    //                     // are we using Common Controls v6
    //                     if (NativeMethods.DllGetVersion(ref version) == 0)
    //                     {
    //                         return (version.dwMajorVersion > 5);
    //                     }
    //                 }
    //             }

    //             return false;
    //         }
    //     }


    //     /// <summary>
    //     /// Processes Windows messages
    //     /// </summary>
    //     /// <param name="m">The Windows Message to process</param>
    //     protected override void WndProc(ref Message m)
    //     {
    //         base.WndProc(ref m);

    //         if (!this.visualStylesEnabled)
    //         {
    //             return;
    //         }

    //         if (m.Msg == (int)WindowMessageFlags.WM_PRINT)
    //         {
    //             if ((m.LParam.ToInt32() & (int)WmPrintFlags.PRF_NONCLIENT) == (int)WmPrintFlags.PRF_NONCLIENT)
    //             {
    //                 // open theme data
    //                 IntPtr hTheme = UxTheme.OpenThemeData(this.Handle, UxTheme.WindowClasses.Edit);

    //                 if (hTheme != IntPtr.Zero)
    //                 {
    //                     // get the part and state needed
    //                     int partId = (int)UxTheme.Parts.Edit.EditText;
    //                     int stateId = (int)UxTheme.PartStates.EditText.Normal;

    //                     if (this.ReadOnly)
    //                     {
    //                         stateId = (int)UxTheme.PartStates.EditText.Readonly;
    //                     }
    //                     else if (!this.Enabled)
    //                     {
    //                         stateId = (int)UxTheme.PartStates.EditText.Disabled;
    //                     }

    //                     RECT rect = new RECT();
    //                     rect.right = this.Width;
    //                     rect.bottom = this.Height;

    //                     RECT clipRect = new RECT();

    //                     // draw the left border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.left + 2;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the top border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.top + 2;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the right border
    //                     clipRect.left = rect.right - 2;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the bottom border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.bottom - 2;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);
    //                 }

    //                 UxTheme.CloseThemeData(hTheme);
    //             }
    //         }
    //     }
    // }

    // #endregion



    // #region XPTreeView

    // /// <summary>
    // /// A TreeView that correctly draws themed borders if Windows XP 
    // /// Visual Styles are enabled when it recieves a WM_PRINT message
    // /// </summary>
    // [ToolboxItem(true)]
    // public class XPTreeView : TreeView
    // {
    //     /// <summary>
    //     /// The cached value of whether Xindows XP Visual Styles are enabled
    //     /// </summary>
    //     private bool visualStylesEnabled;


    //     /// <summary>
    //     /// Initializes a new instance of the XPTreeView class with default settings
    //     /// </summary>
    //     public XPTreeView() : base()
    //     {
    //         // check if visual styles have been enabled
    //         this.visualStylesEnabled = this.VisualStylesEnabled;
    //     }


    //     /// <summary>
    //     /// Raises the SystemColorsChanged event
    //     /// </summary>
    //     /// <param name="e">An EventArgs that contains the event data</param>
    //     protected override void OnSystemColorsChanged(EventArgs e)
    //     {
    //         base.OnSystemColorsChanged(e);

    //         // recheck if visual styles have been enabled
    //         this.visualStylesEnabled = this.VisualStylesEnabled;
    //     }


    //     /// <summary>
    //     /// Returns whether Windows XP Visual Styles are currently enabled
    //     /// </summary>
    //     protected bool VisualStylesEnabled
    //     {
    //         get
    //         {
    //             OperatingSystem os = System.Environment.OSVersion;

    //             // check if the OS id XP or higher
    //             if (os.Platform == PlatformID.Win32NT && ((os.Version.Major == 5 && os.Version.Minor >= 1) || os.Version.Major > 5))
    //             {
    //                 // are themes enabled
    //                 if (UxTheme.IsThemeActive() && UxTheme.IsAppThemed())
    //                 {
    //                     DLLVERSIONINFO version = new DLLVERSIONINFO();
    //                     version.cbSize = Marshal.SizeOf(typeof(DLLVERSIONINFO));

    //                     // are we using Common Controls v6
    //                     if (NativeMethods.DllGetVersion(ref version) == 0)
    //                     {
    //                         return (version.dwMajorVersion > 5);
    //                     }
    //                 }
    //             }

    //             return false;
    //         }
    //     }


    //     /// <summary>
    //     /// Processes Windows messages
    //     /// </summary>
    //     /// <param name="m">The Windows Message to process</param>
    //     protected override void WndProc(ref Message m)
    //     {
    //         base.WndProc(ref m);

    //         if (!this.visualStylesEnabled || this.BorderStyle != BorderStyle.Fixed3D)
    //         {
    //             return;
    //         }

    //         if (m.Msg == (int)WindowMessageFlags.WM_PRINT)
    //         {
    //             if ((m.LParam.ToInt32() & (int)WmPrintFlags.PRF_NONCLIENT) == (int)WmPrintFlags.PRF_NONCLIENT)
    //             {
    //                 // open theme data
    //                 IntPtr hTheme = UxTheme.OpenThemeData(this.Handle, UxTheme.WindowClasses.TreeView);

    //                 if (hTheme != IntPtr.Zero)
    //                 {
    //                     // get the part and state needed
    //                     int partId = (int)UxTheme.Parts.TreeView.TreeItem;
    //                     int stateId = (int)UxTheme.PartStates.TreeItem.Normal;

    //                     RECT rect = new RECT();
    //                     rect.right = this.Width;
    //                     rect.bottom = this.Height;

    //                     RECT clipRect = new RECT();

    //                     // draw the left border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.left + 2;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the top border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.top + 2;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the right border
    //                     clipRect.left = rect.right - 2;
    //                     clipRect.top = rect.top;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);

    //                     // draw the bottom border
    //                     clipRect.left = rect.left;
    //                     clipRect.top = rect.bottom - 2;
    //                     clipRect.right = rect.right;
    //                     clipRect.bottom = rect.bottom;
    //                     UxTheme.DrawThemeBackground(hTheme, m.WParam, partId, stateId, ref rect, ref clipRect);
    //                 }

    //                 UxTheme.CloseThemeData(hTheme);
    //             }
    //         }
    //     }
    // }

    // #endregion

    // #endregion

    #endregion

    /// <summary>
    /// Hypothetical polygon creation tool.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitPolyTestControl : Control
    {

        /// <summary>
        /// The polygons
        /// </summary>
        private Polygon polygons = new Polygon(new PointF[] 
                                   { new PointF(100, 0),
                                     new PointF(0, 100),
                                     new PointF(100, 200),
                                     new PointF(100, 0)});

        /// <summary>
        /// The fill color
        /// </summary>
        private Color fillColor = Color.CadetBlue;
        /// <summary>
        /// The draw color
        /// </summary>
        private Color drawColor = Color.Black;

        /// <summary>
        /// Gets or sets the color to fill the control.
        /// </summary>
        /// <value>The color of the fill.</value>
        public Color FillColor
        {
            get { return fillColor; }
            set
            {
                fillColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the draw.
        /// </summary>
        /// <value>The color of the draw.</value>
        public Color DrawColor
        {
            get { return drawColor; }
            set
            {
                drawColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the polygon shape.
        /// </summary>
        /// <value>The polygon shape.</value>
        public Polygon PolyShape
        {
            get { return polygons; }
            set
            {
                polygons = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPolyTestControl" /> class.
        /// </summary>
        public ZeroitPolyTestControl()
        {

            SetStyle(
                ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.ResizeRedraw | 
                ControlStyles.UserPaint | 
                ControlStyles.DoubleBuffer | 
                ControlStyles.SupportsTransparentBackColor, true);
            
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.FillPolygon(new SolidBrush(fillColor), polygons.Points);
            g.DrawPolygon(new Pen(drawColor), polygons.Points);

        }
    }
    
    
}
