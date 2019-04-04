// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="RulerControl.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region ZeroitCodeTextBoxRuler Control

    #region Enumerations

    /// <summary>
    /// Enum representing the ZeroitCodeTextBoxRuler Orientation
    /// </summary>
    public enum RulerOrientation
    {
        /// <summary>
        /// The horizontal
        /// </summary>
        Horizontal = 0,
        /// <summary>
        /// The or vertical
        /// </summary>
        Vertical = 1
    }

    /// <summary>
    /// Enum representing Scale Mode
    /// </summary>
    public enum ScaleMode
    {
        /// <summary>
        /// The sm points
        /// </summary>
        smPoints = 0,
        /// <summary>
        /// The sm pixels
        /// </summary>
        smPixels = 1,
        /// <summary>
        /// The sm centimetres
        /// </summary>
        smCentimetres = 2,
        /// <summary>
        /// The sm inches
        /// </summary>
        smInches = 3,
        /// <summary>
        /// The sm millimetres
        /// </summary>
        smMillimetres = 4
    }


    /// <summary>
    /// Enum representing ZeroitCodeTextBoxRuler Alignment
    /// </summary>
    public enum RulerAlign
    {
        /// <summary>
        /// The top or left
        /// </summary>
        TopOrLeft,
        /// <summary>
        /// The middle
        /// </summary>
        Middle,
        /// <summary>
        /// The bottom or right
        /// </summary>
        BottomOrRight
    }


    /// <summary>
    /// Enum Msg
    /// </summary>
    internal enum Msg
    {
        /// <summary>
        /// The wm mousemove
        /// </summary>
        WM_MOUSEMOVE = 0x0200,
        /// <summary>
        /// The wm mouseleave
        /// </summary>
        WM_MOUSELEAVE = 0x02A3,
        /// <summary>
        /// The wm ncmouseleave
        /// </summary>
        WM_NCMOUSELEAVE = 0x02A2,
    }

    #endregion

    /// <summary>
    /// A class collection for rendering a ruler.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    /// <seealso cref="System.Windows.Forms.IMessageFilter" />
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ZeroitRuler), "ZeroitCodeTextBoxRuler.bmp")]
    public class ZeroitRuler : System.Windows.Forms.Control, IMessageFilter
    {

        #region Internal Variables

#if !FRAMEWORKMENUS
        private PopupMenu _mnuContext = null;
#endif
        /// <summary>
        /// The scale
        /// </summary>
        private int _Scale;
        /// <summary>
        /// The b draw line
        /// </summary>
        private bool _bDrawLine = false;
        /// <summary>
        /// The b in control
        /// </summary>
        private bool _bInControl = false;
        /// <summary>
        /// The i mouse position
        /// </summary>
        private int _iMousePosition = 1;
        /// <summary>
        /// The i old mouse position
        /// </summary>
        private int _iOldMousePosition = -1;
        //private Bitmap //_Bitmap = null;

        #endregion

        #region Property variable

        /// <summary>
        /// The orientation
        /// </summary>
        private RulerOrientation _Orientation;
        /// <summary>
        /// The scale mode
        /// </summary>
        private ScaleMode _ScaleMode;
        /// <summary>
        /// The ruler alignment
        /// </summary>
        private RulerAlign _RulerAlignment = RulerAlign.BottomOrRight;
        /// <summary>
        /// The i3 d border style
        /// </summary>
        private Border3DStyle _i3DBorderStyle = Border3DStyle.Etched;
        /// <summary>
        /// The i major interval
        /// </summary>
        private int _iMajorInterval = 100;
        /// <summary>
        /// The i number of divisions
        /// </summary>
        private int _iNumberOfDivisions = 10;
        /// <summary>
        /// The division mark factor
        /// </summary>
        private int _DivisionMarkFactor = 5;
        /// <summary>
        /// The middle mark factor
        /// </summary>
        private int _MiddleMarkFactor = 3;
        /// <summary>
        /// The zoom factor
        /// </summary>
        private double _ZoomFactor = 1;
        /// <summary>
        /// The start value
        /// </summary>
        private double _StartValue = 0;
        /// <summary>
        /// The b mouse tracking on
        /// </summary>
        private bool _bMouseTrackingOn = false;
        /// <summary>
        /// The vertical numbers
        /// </summary>
        private bool _VerticalNumbers = true;
        /// <summary>
        /// The b actual size
        /// </summary>
        private bool _bActualSize = true;
        /// <summary>
        /// The dpi x
        /// </summary>
        private float _DpiX = 96;

        #endregion

        #region Event Arguments

        /// <summary>
        /// Class ScaleModeChangedEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class ScaleModeChangedEventArgs : EventArgs
        {
            /// <summary>
            /// The mode
            /// </summary>
            public ScaleMode Mode;

            /// <summary>
            /// Initializes a new instance of the <see cref="ScaleModeChangedEventArgs"/> class.
            /// </summary>
            /// <param name="Mode">The mode.</param>
            public ScaleModeChangedEventArgs(ScaleMode Mode) : base()
            {
                this.Mode = Mode;
            }
        }

        /// <summary>
        /// Class HooverValueEventArgs.
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class HooverValueEventArgs : EventArgs
        {
            /// <summary>
            /// The value
            /// </summary>
            public double Value;

            /// <summary>
            /// Initializes a new instance of the <see cref="HooverValueEventArgs"/> class.
            /// </summary>
            /// <param name="Value">The value.</param>
            public HooverValueEventArgs(double Value) : base()
            {
                this.Value = Value;
            }
        }


        #endregion

        #region Delegates

        /// <summary>
        /// Delegate ScaleModeChangedEvent
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ScaleModeChangedEventArgs"/> instance containing the event data.</param>
        public delegate void ScaleModeChangedEvent(object sender, ScaleModeChangedEventArgs e);
        /// <summary>
        /// Delegate HooverValueEvent
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="HooverValueEventArgs"/> instance containing the event data.</param>
        public delegate void HooverValueEvent(object sender, HooverValueEventArgs e);
        // public delegate void ClickEvent(object sender, ClickEventArgs e);

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [scale mode changed].
        /// </summary>
        public event ScaleModeChangedEvent ScaleModeChanged;
        /// <summary>
        /// Occurs when [hoover value].
        /// </summary>
        public event HooverValueEvent HooverValue;

        #endregion

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #region Constrcutors/Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRuler" /> class.
        /// </summary>
        public ZeroitRuler()
        {

            
            //base.BackColor = System.Drawing.Color.White;
            base.ForeColor = System.Drawing.Color.Black;

            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

#if !FRAMEWORKMENUS

            // Create the popup menu object
            _mnuContext = new PopupMenu();

            // Create the menu objects
            MenuCommand mnuPoints = new MenuCommand("Points", new EventHandler(Popup_Click));
            mnuPoints.Tag = ScaleMode.smPoints;
            MenuCommand mnuPixels = new MenuCommand("Pixels", new EventHandler(Popup_Click));
            mnuPixels.Tag = ScaleMode.smPixels;
            MenuCommand mnuCentimetres = new MenuCommand("Centimetres", new EventHandler(Popup_Click));
            mnuCentimetres.Tag = ScaleMode.smCentimetres;
            MenuCommand mnuInches = new MenuCommand("Inches", new EventHandler(Popup_Click));
            mnuInches.Tag = ScaleMode.smInches;
            MenuCommand mnuInches = new MenuCommand("Millimetres", new EventHandler(Popup_Click));
            mnuInches.Tag = ScaleMode.smMillimetres;

            // Define the list of menu commands
            _mnuContext.MenuCommands.AddRange(new MenuCommand[] { mnuPoints, mnuPixels, mnuCentimetres, mnuInches });

            // Define the properties to get appearance to match MenuControl
            _mnuContext.Style = VisualStyle.IDE;

#endif

#if FRAMEWORKMENUS

            System.Windows.Forms.MenuItem mnuPoints = new System.Windows.Forms.MenuItem("Points", new EventHandler(Popup_Click));
            System.Windows.Forms.MenuItem mnuPixels = new System.Windows.Forms.MenuItem("Pixels", new EventHandler(Popup_Click));
            System.Windows.Forms.MenuItem mnuCentimetres = new System.Windows.Forms.MenuItem("Centimetres", new EventHandler(Popup_Click));
            System.Windows.Forms.MenuItem mnuInches = new System.Windows.Forms.MenuItem("Inches", new EventHandler(Popup_Click));
            System.Windows.Forms.MenuItem mnuMillimetres = new System.Windows.Forms.MenuItem("Millimetres", new EventHandler(Popup_Click));
            ContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { mnuPoints, mnuPixels, mnuCentimetres, mnuInches, mnuMillimetres });
#endif
            Graphics g = this.CreateGraphics();
            _DpiX = g.DpiX;
            ScaleMode = ScaleMode.smPoints;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Filters out a message before it is dispatched.
        /// </summary>
        /// <param name="m">The message to be dispatched. You cannot modify this message.</param>
        /// <returns>true to filter the message and stop it from being dispatched; false to allow the message to continue to the next filter or control.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PreFilterMessage(ref Message m)
        {
            if (!this._bMouseTrackingOn) return false;

            if (m.Msg == (int)Msg.WM_MOUSEMOVE)
            {
                int X = 0;
                int Y = 0;

                // The mouse coordinate are measured in screen coordinates because thats what 
                // Control.MousePosition returns.  The Message,LParam value is not used because
                // it returns the mouse position relative to the control the mouse is over. 
                // Chalk and cheese.

                Point pointScreen = Control.MousePosition;

                // Get the origin of this control in screen coordinates so that later we can 
                // compare it against the mouse point to determine it we've hit this control.

                Point pointClientOrigin = new Point(X, Y);
                pointClientOrigin = PointToScreen(pointClientOrigin);

                _bDrawLine = false;
                _bInControl = false;

                HooverValueEventArgs eHoover = null;

                // Work out whether the mouse is within the Y-axis bounds of a vertital ruler or 
                // within the X-axis bounds of a horizontal ruler

                if (this.Orientation == RulerOrientation.Horizontal)
                {
                    _bDrawLine = (pointScreen.X >= pointClientOrigin.X) && (pointScreen.X <= pointClientOrigin.X + this.Width);
                }
                else
                {
                    _bDrawLine = (pointScreen.Y >= pointClientOrigin.Y) && (pointScreen.Y <= pointClientOrigin.Y + this.Height);
                }

                // If the mouse is in valid position...
                if (_bDrawLine)
                {
                    // ...workout the position of the mouse relative to the 
                    X = pointScreen.X - pointClientOrigin.X;
                    Y = pointScreen.Y - pointClientOrigin.Y;

                    // Determine whether the mouse is within the bounds of the control itself
                    _bInControl = (this.ClientRectangle.Contains(new Point(X, Y)));

                    // Make the relative mouse position available in pixel relative to this control's origin
                    ChangeMousePosition((this.Orientation == RulerOrientation.Horizontal) ? X : Y);
                    eHoover = new HooverValueEventArgs(CalculateValue(_iMousePosition));

                }
                else
                {
                    ChangeMousePosition(-1);
                    eHoover = new HooverValueEventArgs(_iMousePosition);
                }

                // Paint directly by calling the OnPaint() method.  This way the background is not 
                // hosed by the call to Invalidate() so paining occurs without the hint of a flicker
                PaintEventArgs e = null;
                try
                {
                    e = new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle);
                    OnPaint(e);
                }
                finally
                {
                    e.Graphics.Dispose();
                }

                OnHooverValue(eHoover);
            }

            if ((m.Msg == (int)Msg.WM_MOUSELEAVE) ||
                (m.Msg == (int)Msg.WM_NCMOUSELEAVE))
            {
                _bDrawLine = false;
                PaintEventArgs paintArgs = null;
                try
                {
                    paintArgs = new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle);
                    this.OnPaint(paintArgs);
                }
                finally
                {
                    paintArgs.Graphics.Dispose();
                }
            }

            return false;  // Whether or not the message is filtered
        }


        /// <summary>
        /// Pixels to scale value.
        /// </summary>
        /// <param name="iOffset">The i offset.</param>
        /// <returns>System.Double.</returns>
        public double PixelToScaleValue(int iOffset)
        {
            return this.CalculateValue(iOffset);
        }

        /// <summary>
        /// Scales the value to pixel.
        /// </summary>
        /// <param name="nScaleValue">The n scale value.</param>
        /// <returns>System.Int32.</returns>
        public int ScaleValueToPixel(double nScaleValue)
        {
            return CalculatePixel(nScaleValue);
        }

        #endregion

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ZeroitRuler
            // 
            this.Name = "ZeroitRuler";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ZeroitRuler_MouseUp);

            base.SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);

#if FRAMEWORKMENUS
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.Popup += new EventHandler(ContextMenu_Popup);
#endif

        }
        #endregion

        #region Overrides

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Take private resize actions here
            //_Bitmap = null;
            this.Invalidate();
        }

        /// <summary>
        /// Forces the control to invalidate its client area and immediately redraw itself and any child controls.
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();
            this.Invalidate();
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        [Description("Draws the ruler marks in the scale requested.")]
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawControl(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.VisibleChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.Visible)
            {
                if (_bMouseTrackingOn) Application.AddMessageFilter(this);
            }
            else
            {
                // DOn't change the tracking state so that the filter will be added again when the control is made visible again; 
                if (_bMouseTrackingOn) RemoveMessageFilter();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleDestroyed" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            RemoveMessageFilter();
            _bMouseTrackingOn = false;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ControlRemoved" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs" /> that contains the event data.</param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            RemoveMessageFilter();
            _bMouseTrackingOn = false;
        }

        /// <summary>
        /// Removes the message filter.
        /// </summary>
        private void RemoveMessageFilter()
        {
            try
            {
                if (_bMouseTrackingOn)
                {
                    Application.RemoveMessageFilter(this);
                }
            }
            catch { }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handles the MouseDown event of the ZeroitRuler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ZeroitRuler_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //			if (e.Button.Equals(MouseButtons.Right)) 
        }

        /// <summary>
        /// Handles the MouseUp event of the ZeroitRuler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ZeroitRuler_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
#if FRAMEWORKMENUS
            if ((Control.MouseButtons & MouseButtons.Right) != 0)
            {
                this.ContextMenu.Show(this, PointToClient(Control.MousePosition));
#else
            if ((e.Button & MouseButtons.Right) != 0)
            {
                _mnuContext.TrackPopup(this.PointToScreen(new Point(e.X, e.Y)));
#endif
            }
            else
            {
                EventArgs eClick = new EventArgs();
                this.OnClick(eClick);
            }
        }

        /// <summary>
        /// Handles the Click event of the Popup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Popup_Click(object sender, EventArgs e)
        {
#if FRAMEWORKMENUS
            System.Windows.Forms.MenuItem item = (System.Windows.Forms.MenuItem)sender;
            ScaleMode = (ScaleMode)item.Index;
#else
            MenuCommand item = (MenuCommand)sender;
            ScaleMode = (ScaleMode)item.Tag;
#endif
            //_Bitmap = null;
            Invalidate();
        }

        /// <summary>
        /// Handles the <see cref="E:HooverValue" /> event.
        /// </summary>
        /// <param name="e">The <see cref="HooverValueEventArgs"/> instance containing the event data.</param>
        protected void OnHooverValue(HooverValueEventArgs e)
        {
            if (HooverValue != null) HooverValue(this, e);
        }

        /// <summary>
        /// Handles the <see cref="E:ScaleModeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ScaleModeChangedEventArgs"/> instance containing the event data.</param>
        protected void OnScaleModeChanged(ScaleModeChangedEventArgs e)
        {
            if (ScaleModeChanged != null) ScaleModeChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Enter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            _bDrawLine = false;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Leave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            Invalidate();
        }

        /// <summary>
        /// Handles the Popup event of the ContextMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ContextMenu_Popup(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Popup");
        }

        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value>The border style.</value>
        [
        DefaultValue(typeof(Border3DStyle), "Etched"),
        Description("The border style use the Windows.Forms.Border3DStyle type"),
        Category("ZeroitCodeTextBoxRuler"),
        ]
        public Border3DStyle BorderStyle
        {
            get
            {
                return _i3DBorderStyle;
            }
            set
            {
                _i3DBorderStyle = value;
                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        [Description("Horizontal or vertical layout")]
        [Category("ZeroitCodeTextBoxRuler")]
        public RulerOrientation Orientation
        {
            get { return _Orientation; }
            set
            {
                _Orientation = value;
                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the start value. A value from which the ruler marking should be shown.  Default is zero
        /// </summary>
        /// <value>The start value.</value>
        [Description("A value from which the ruler marking should be shown.  Default is zero.")]
        [Category("ZeroitCodeTextBoxRuler")]
        public double StartValue
        {
            get { return _StartValue; }
            set
            {
                _StartValue = value;
                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the scale mode.
        /// </summary>
        /// <value>The scale mode.</value>
        [Description("The scale to use")]
        [Category("ZeroitCodeTextBoxRuler")]
        public ScaleMode ScaleMode
        {
            get { return _ScaleMode; }
            set
            {
                ScaleMode iOldScaleMode = _ScaleMode;
                _ScaleMode = value;

                if (_iMajorInterval == DefaultMajorInterval(iOldScaleMode))
                {
                    // Set the default Scale and MajorInterval value
                    _Scale = DefaultScale(_ScaleMode);
                    _iMajorInterval = DefaultMajorInterval(_ScaleMode);

                }
                else
                {
                    MajorInterval = _iMajorInterval;
                }

                // Use the current start value (if there is one)
                this.StartValue = this._StartValue;

                // Setup the menu
                for (int i = 0; i <= 4; i++)
#if FRAMEWORKMENUS
                    ContextMenu.MenuItems[i].Checked = false;

                ContextMenu.MenuItems[(int)value].Checked = true;
#else
                    _mnuContext.MenuCommands[i].Checked = false;

                _mnuContext.MenuCommands[(int)value].Checked = true;
#endif

                ScaleModeChangedEventArgs e = new ScaleModeChangedEventArgs(value);
                this.OnScaleModeChanged(e);
            }
        }

        /// <summary>
        /// Gets or sets the major interval.
        /// When displaying inches, 1 is a typical value.
        /// When displaying Points, 36 or 72 might good values
        /// </summary>
        /// <value>The major interval.</value>
        /// <exception cref="System.Exception">The major interval value cannot be less than one</exception>
        /// <exception cref="Exception">The major interval value cannot be less than one</exception>
        [Description("The value of the major interval.  When displaying inches, 1 is a typical value.  When displaying Points, 36 or 72 might good values.")]
        [Category("ZeroitCodeTextBoxRuler")]
        public int MajorInterval
        {
            get { return _iMajorInterval; }
            set
            {
                if (value <= 0) throw new Exception("The major interval value cannot be less than one");
                _iMajorInterval = value;
                _Scale = DefaultScale(_ScaleMode) * _iMajorInterval / DefaultMajorInterval(_ScaleMode);
                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the divisions.
        /// </summary>
        /// <value>The divisions.</value>
        /// <exception cref="System.Exception">The number of divisions cannot be less than one</exception>
        /// <exception cref="Exception">The number of divisions cannot be less than one</exception>
        [Description("How many divisions should be shown between each major interval")]
        [Category("ZeroitCodeTextBoxRuler")]
        public int Divisions
        {
            get { return _iNumberOfDivisions; }
            set
            {
                if (value <= 0) throw new Exception("The number of divisions cannot be less than one");
                _iNumberOfDivisions = value;
                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the division mark factor.
        /// The height or width of this control multiplied by the
        /// reciprocal of this number will be used to compute the
        /// height of the non-middle division marks.
        /// </summary>
        /// <value>The division mark factor.</value>
        /// <exception cref="System.Exception">The Division Mark Factor cannot be less than one</exception>
        /// <exception cref="Exception">The Division Mark Factor cannot be less than one</exception>
        [Description("The height or width of this control multiplied by the reciprocal of this number will be used to compute the height of the non-middle division marks.")]
        [Category("ZeroitCodeTextBoxRuler")]
        public int DivisionMarkFactor
        {
            get { return _DivisionMarkFactor; }
            set
            {
                if (value <= 0) throw new Exception("The Division Mark Factor cannot be less than one");
                _DivisionMarkFactor = value;
                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the middle mark factor.
        /// The height or width of this control multiplied by
        /// the reciprocal of this number will be used to compute
        /// the height of the middle division mark.
        /// </summary>
        /// <value>The middle mark factor.</value>
        /// <exception cref="System.Exception">The Middle Mark Factor cannot be less than one</exception>
        /// <exception cref="Exception">The Middle Mark Factor cannot be less than one</exception>
        [Description("The height or width of this control multiplied by the reciprocal of this number will be used to compute the height of the middle division mark.")]
        [Category("ZeroitCodeTextBoxRuler")]
        public int MiddleMarkFactor
        {
            get { return _MiddleMarkFactor; }
            set
            {
                if (value <= 0) throw new Exception("The Middle Mark Factor cannot be less than one");
                _MiddleMarkFactor = value;
                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets the scale value.
        /// The value of the current mouse position expressed
        /// in unit of the scale set (centimetres, inches, etc.)
        /// </summary>
        /// <value>The scale value.</value>
        [Description("The value of the current mouse position expressed in unit of the scale set (centimetres, inches, etc.)")]
        [Category("ZeroitCodeTextBoxRuler")]
        public double ScaleValue
        {
            get { return CalculateValue(_iMousePosition); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable mouse tracking.
        /// </summary>
        /// <value><c>true</c> if mouse tracking on; otherwise, <c>false</c>.</value>
        [Description("TRUE if a line is displayed to track the current position of the mouse and events are generated as the mouse moves.")]
        [Category("ZeroitCodeTextBoxRuler")]
        public bool MouseTrackingOn
        {
            get { return _bMouseTrackingOn; }
            set
            {
                if (value == _bMouseTrackingOn) return;

                if (value)
                {
                    // Tracking is being enabled so add the message filter hook
                    if (this.Visible) Application.AddMessageFilter(this);
                }
                else
                {
                    // Tracking is being disabled so remove the message filter hook
                    Application.RemoveMessageFilter(this);
                    ChangeMousePosition(-1);
                }

                _bMouseTrackingOn = value;

                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Description("The font used to display the division number")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets the mouse location.
        /// Return the mouse position as number of pixels
        /// from the top or left of the control.
        /// -1 means that the mouse is positioned before or after the control.
        /// </summary>
        /// <value>The mouse location.</value>
        [Description("Return the mouse position as number of pixels from the top or left of the control.  -1 means that the mouse is positioned before or after the control.")]
        [Category("ZeroitCodeTextBoxRuler")]
        public int MouseLocation
        {
            get { return _iMousePosition; }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [DefaultValue(typeof(Color), "ControlDarkDark")]
        [Description("The color used to lines and numbers on the ruler")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [DefaultValue(typeof(Color), "White")]
        [Description("The color used to paint the background of the ruler")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use vertical numbers.
        /// </summary>
        /// <value><c>true</c> if vertical numbers; otherwise, <c>false</c>.</value>
        [Description("")]
        [Category("ZeroitCodeTextBoxRuler")]
        public bool VerticalNumbers
        {
            get { return _VerticalNumbers; }
            set
            {
                _VerticalNumbers = value;
                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the zoom factor.
        /// A factor between 0.1 and 10 by
        /// which the displayed scale will be zoomed.
        /// </summary>
        /// <value>The zoom factor.</value>
        /// <exception cref="System.Exception">Zoom factor can be between 10% and 1000%</exception>
        /// <exception cref="Exception">Zoom factor can be between 10% and 1000%</exception>
        [Description("A factor between 0.1 and 10 by which the displayed scale will be zoomed.")]
        [Category("ZeroitCodeTextBoxRuler")]
        public double ZoomFactor
        {
            get { return _ZoomFactor; }
            set
            {
                if ((value < 0.1) || (value > 10)) throw new Exception("Zoom factor can be between 10% and 1000%");
                if (_ZoomFactor == value) return;
                _ZoomFactor = value;
                this.ScaleMode = _ScaleMode;
                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// True if the ruler measurement is to be based on the systems pixels per inch figure.
        /// </summary>
        /// <value><c>true</c> if [actual size]; otherwise, <c>false</c>.</value>
        [Description("True if the ruler measurement is to be based on the systems pixels per inch figure")]
        [Category("ZeroitCodeTextBoxRuler")]
        public bool ActualSize
        {
            get { return _bActualSize; }
            set
            {
                if (_bActualSize == value) return;
                _bActualSize = value;
                this.ScaleMode = _ScaleMode;
                //_Bitmap = null;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the ruler alignment. Determines how the ruler markings are displayed
        /// </summary>
        /// <value>The ruler alignment.</value>
        [Description("Determines how the ruler markings are displayed")]
        [Category("ZeroitCodeTextBoxRuler")]
        public RulerAlign RulerAlignment
        {
            get { return _RulerAlignment; }
            set
            {
                if (_RulerAlignment == value) return;
                _RulerAlignment = value;
                //_Bitmap = null;
                Invalidate();
            }
        }


        #endregion

        #region Private functions

        /// <summary>
        /// Calculates the value.
        /// </summary>
        /// <param name="iOffset">The i offset.</param>
        /// <returns>System.Double.</returns>
        private double CalculateValue(int iOffset)
        {
            if (iOffset < 0) return 0;

            double nValue = ((double)iOffset - Start()) / (double)_Scale * (double)_iMajorInterval;
            return nValue + this._StartValue;
        }

        /// <summary>
        /// Calculates the pixel.
        /// </summary>
        /// <param name="nScaleValue">The n scale value.</param>
        /// <returns>System.Int32.</returns>
        [Description("May not return zero even when a -ve scale number is given as the returned value needs to allow for the border thickness")]
        private int CalculatePixel(double nScaleValue)
        {

            double nValue = nScaleValue - this._StartValue;
            if (nValue < 0) return Start();  // Start is the offset to the actual display area to allow for the border (if any)

            int iOffset = Convert.ToInt32(nValue / (double)_iMajorInterval * (double)_Scale);

            return iOffset + Start();
        }

        /// <summary>
        /// Renders the track line.
        /// </summary>
        /// <param name="g">The g.</param>
        public void RenderTrackLine(Graphics g)
        {
            if (_bMouseTrackingOn & _bDrawLine)
            {
                int iOffset = Offset();

                // Optionally render Mouse tracking line
                switch (Orientation)
                {
                    case RulerOrientation.Horizontal:
                        Line(g, _iMousePosition, iOffset, _iMousePosition, Height - iOffset);
                        break;
                    case RulerOrientation.Vertical:
                        Line(g, iOffset, _iMousePosition, Width - iOffset, _iMousePosition);
                        break;
                }
            }
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void DrawControl(PaintEventArgs e)
        {
            // Create a bitmap
            //Bitmap _Bitmap = new Bitmap(this.Width, this.Height);

            Graphics g = e.Graphics ;
            g.SmoothingMode = SmoothingMode.HighQuality;
            
            g.Clear(BackColor);
            if (!this.Visible) return;

            // Bug reported by Kristoffer F 
            if (this.Width < 1 || this.Height < 1)
            {
#if DEBUG
                System.Diagnostics.Trace.WriteLine("Minimised?");
#endif
                return;
            }



            int iValueOffset = 0;
            int iScaleStartValue;

            

            
                // Wash the background with BackColor
                //g.FillRectangle(new SolidBrush(this.BackColor), 0, 0, Width, Height);

                if (this.StartValue >= 0)
                {
                    iScaleStartValue = Convert.ToInt32(_StartValue * _Scale / _iMajorInterval);  // Convert value to pixels
                }
                else
                {
                    // If the start value is -ve then assume that we are starting just above zero
                    // For example if the requested value -1.1 then make believe that the start is
                    // +0.9.  We can fix up the printing of numbers later.
                    double dStartValue = Math.Ceiling(Math.Abs(_StartValue)) - Math.Abs(_StartValue);

                    // Compute the offset that is to be used with the start point is -ve
                    // This will be subtracted from the number calculated for the display numeral
                    iScaleStartValue = Convert.ToInt32(dStartValue * _Scale / _iMajorInterval);  // Convert value to pixels
                    iValueOffset = Convert.ToInt32(Math.Ceiling(Math.Abs(_StartValue)));
                };

                // Paint the lines on the image
                int iScale = _Scale;

                int iStart = Start();  // iStart is the pixel number on which to start.
                int iEnd = (this.Orientation == RulerOrientation.Horizontal) ? Width : Height;

#if DEBUG
                if (this.Orientation == RulerOrientation.Vertical)
                {
                    System.Diagnostics.Debug.WriteLine("Vert");
                }
#endif
                for (int j = iStart; j <= iEnd; j += iScale)
                {
                    int iLeft = _Scale;  // Make an assumption that we're starting at zero or on a major increment
                    int jOffset = j + iScaleStartValue;

                    iScale = ((jOffset - iStart) % _Scale);  // Get the mod value to see if this is "big line" opportunity

                    // If it is, draw big line
                    if (iScale == 0)
                    {
                        if (_RulerAlignment != RulerAlign.Middle)
                        {
                            if (this.Orientation == RulerOrientation.Horizontal)
                                Line(g, j, 0, j, Height);
                            else
                                Line(g, 0, j, Width, j);
                        }

                        iLeft = _Scale;     // Set the for loop increment
                    }
                    else
                    {
                        iLeft = _Scale - Math.Abs(iScale);     // Set the for loop increment
                    }

                    iScale = iLeft;

                    int iValue = (((jOffset - iStart) / _Scale) + 1) * _iMajorInterval;

                    // Accommodate the offset if the starting point is -ve
                    iValue -= iValueOffset;
                    DrawValue(g, iValue, j - iStart, iScale);

                    int iUsed = 0;

                    // TO DO: This must be wrong when the start is negative and not a whole number
                    //Draw small lines
                    for (int i = 0; i < _iNumberOfDivisions; i++)
                    {
                        // Get the increment for the next mark
                        int iX = Convert.ToInt32(Math.Round((double)(_Scale - iUsed) / (double)(_iNumberOfDivisions - i), 0)); // Use a spreading algorithm rather that using expensive floating point numbers

                        // So the next mark will have used up 
                        iUsed += iX;

                        if (iUsed >= (_Scale - iLeft))
                        {
                            iX = iUsed + j - (_Scale - iLeft);

                            // Is it an even number and, if so, is it the middle value?
                            bool bMiddleMark = ((_iNumberOfDivisions & 0x1) == 0) & (i + 1 == _iNumberOfDivisions / 2);
                            bool bShowMiddleMark = bMiddleMark;
                            bool bLastDivisionMark = (i + 1 == _iNumberOfDivisions);
                            bool bLastAlignMiddleDivisionMark = bLastDivisionMark & (_RulerAlignment == RulerAlign.Middle);
                            bool bShowDivisionMark = !bMiddleMark & !bLastAlignMiddleDivisionMark;

                            if (bShowMiddleMark)
                            {
                                DivisionMark(g, iX, _MiddleMarkFactor);  // Height or Width will be 1/3
                            }
                            else if (bShowDivisionMark)
                            {
                                DivisionMark(g, iX, _DivisionMarkFactor);  // Height or Width will be 1/5
                            }
                        }
                    }
                }

                if (_i3DBorderStyle != Border3DStyle.Flat)
                    ControlPaint.DrawBorder3D(g, this.ClientRectangle, this._i3DBorderStyle);

            RenderTrackLine(g);

            
            
        }

        /// <summary>
        /// Divisions the mark.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="iPosition">The i position.</param>
        /// <param name="iProportion">The i proportion.</param>
        private void DivisionMark(Graphics g, int iPosition, int iProportion)
        {
            // This function is affected by the RulerAlignment setting

            int iMarkStart = 0, iMarkEnd = 0;

            if (this.Orientation == RulerOrientation.Horizontal)
            {

                switch (_RulerAlignment)
                {
                    case RulerAlign.BottomOrRight:
                        {
                            iMarkStart = Height - Height / iProportion;
                            iMarkEnd = Height;
                            break;
                        }
                    case RulerAlign.Middle:
                        {
                            iMarkStart = (Height - Height / iProportion) / 2 - 1;
                            iMarkEnd = iMarkStart + Height / iProportion;
                            break;
                        }
                    case RulerAlign.TopOrLeft:
                        {
                            iMarkStart = 0;
                            iMarkEnd = Height / iProportion;
                            break;
                        }
                }

                Line(g, iPosition, iMarkStart, iPosition, iMarkEnd);
            }
            else
            {

                switch (_RulerAlignment)
                {
                    case RulerAlign.BottomOrRight:
                        {
                            iMarkStart = Width - Width / iProportion;
                            iMarkEnd = Width;
                            break;
                        }
                    case RulerAlign.Middle:
                        {
                            iMarkStart = (Width - Width / iProportion) / 2 - 1;
                            iMarkEnd = iMarkStart + Width / iProportion;
                            break;
                        }
                    case RulerAlign.TopOrLeft:
                        {
                            iMarkStart = 0;
                            iMarkEnd = Width / iProportion;
                            break;
                        }
                }

                Line(g, iMarkStart, iPosition, iMarkEnd, iPosition);
            }
        }

        /// <summary>
        /// Draws the value.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="iValue">The i value.</param>
        /// <param name="iPosition">The i position.</param>
        /// <param name="iSpaceAvailable">The i space available.</param>
        private void DrawValue(Graphics g, int iValue, int iPosition, int iSpaceAvailable)
        {

            // The sizing operation is common to all options
            StringFormat format = new StringFormat(StringFormatFlags.MeasureTrailingSpaces);
            if (_VerticalNumbers)
                format.FormatFlags |= StringFormatFlags.DirectionVertical;

            SizeF size = g.MeasureString((iValue).ToString(), this.Font, iSpaceAvailable, format);

            Point drawingPoint;
            int iX = 0;
            int iY = 0;

            if (this.Orientation == RulerOrientation.Horizontal)
            {
                switch (_RulerAlignment)
                {
                    case RulerAlign.BottomOrRight:
                        {
                            iX = iPosition + iSpaceAvailable - (int)size.Width - 2;
                            iY = 2;
                            break;
                        }
                    case RulerAlign.Middle:
                        {
                            iX = iPosition + iSpaceAvailable - (int)size.Width / 2;
                            iY = (Height - (int)size.Height) / 2 - 2;
                            break;
                        }
                    case RulerAlign.TopOrLeft:
                        {
                            iX = iPosition + iSpaceAvailable - (int)size.Width - 2;
                            iY = Height - 2 - (int)size.Height;
                            break;
                        }
                }

                drawingPoint = new Point(iX, iY);
            }
            else
            {
                switch (_RulerAlignment)
                {
                    case RulerAlign.BottomOrRight:
                        {
                            iX = 2;
                            iY = iPosition + iSpaceAvailable - (int)size.Height - 2;
                            break;
                        }
                    case RulerAlign.Middle:
                        {
                            iX = (Width - (int)size.Width) / 2 - 1;
                            iY = iPosition + iSpaceAvailable - (int)size.Height / 2;
                            break;
                        }
                    case RulerAlign.TopOrLeft:
                        {
                            iX = Width - 2 - (int)size.Width;
                            iY = iPosition + iSpaceAvailable - (int)size.Height - 2;
                            break;
                        }
                }

                drawingPoint = new Point(iX, iY);
            }

            // The drawstring function is common to all operations

            g.DrawString(iValue.ToString(), this.Font, new SolidBrush(this.ForeColor), drawingPoint, format);
        }

        /// <summary>
        /// Lines the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        private void Line(Graphics g, int x1, int y1, int x2, int y2)
        {
            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {
                using (Pen pen = new Pen(brush))
                {
                    g.DrawLine(pen, x1, y1, x2, y2);
                    pen.Dispose();
                    brush.Dispose();
                }
            }
        }

        /// <summary>
        /// Defaults the scale.
        /// </summary>
        /// <param name="iScaleMode">The i scale mode.</param>
        /// <returns>System.Int32.</returns>
        private int DefaultScale(ScaleMode iScaleMode)
        {
            int iScale = 100;

            // Set scaling
            switch (iScaleMode)
            {
                // Determines the *relative* proportions of each scale
                case ScaleMode.smPoints:
                    iScale = 660; // 132;
                    break;
                case ScaleMode.smPixels:
                    iScale = 100;
                    break;
                case ScaleMode.smCentimetres:
                    iScale = 262; // 53;
                    break;
                case ScaleMode.smInches:
                    iScale = 660; // 132;
                    break;
                case ScaleMode.smMillimetres:
                    iScale = 27;
                    break;
                    /*
                                    case ScaleMode.smPoints:
                                        iScale = 96;
                                        break;
                                    case ScaleMode.smPixels:
                                        iScale = 100;
                                        break;
                                    case ScaleMode.smCentimetres:
                                        iScale = 38;
                                        break;
                                    case ScaleMode.smInches:
                                        iScale = 96;
                                        break;
                                    case ScaleMode.smMillimetres:
                                        iScale = 4;
                                        break;
                    */
            }

            if (iScaleMode == ScaleMode.smPixels)
                return Convert.ToInt32((double)iScale * _ZoomFactor);
            else
                return Convert.ToInt32((double)iScale * _ZoomFactor * (double)(_bActualSize ? (double)_DpiX / (float)480 : 0.2));
        }

        /// <summary>
        /// Defaults the major interval.
        /// </summary>
        /// <param name="iScaleMode">The i scale mode.</param>
        /// <returns>System.Int32.</returns>
        private int DefaultMajorInterval(ScaleMode iScaleMode)
        {
            int iInterval = 10;

            // Set scaling
            switch (iScaleMode)
            {
                // Determines the *relative* proportions of each scale
                case ScaleMode.smPoints:
                    iInterval = 72;
                    break;
                case ScaleMode.smPixels:
                    iInterval = 100;
                    break;
                case ScaleMode.smCentimetres:
                    iInterval = 1;
                    break;
                case ScaleMode.smInches:
                    iInterval = 1;
                    break;
                case ScaleMode.smMillimetres:
                    iInterval = 1;
                    break;
            }

            return iInterval;
        }

        /// <summary>
        /// Offsets this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int Offset()
        {
            int iOffset = 0;

            switch (this._i3DBorderStyle)
            {
                case Border3DStyle.Flat: iOffset = 0; break;
                case Border3DStyle.Adjust: iOffset = 0; break;
                case Border3DStyle.Sunken: iOffset = 2; break;
                case Border3DStyle.Bump: iOffset = 2; break;
                case Border3DStyle.Etched: iOffset = 2; break;
                case Border3DStyle.Raised: iOffset = 2; break;
                case Border3DStyle.RaisedInner: iOffset = 1; break;
                case Border3DStyle.RaisedOuter: iOffset = 1; break;
                case Border3DStyle.SunkenInner: iOffset = 1; break;
                case Border3DStyle.SunkenOuter: iOffset = 1; break;
                default: iOffset = 0; break;
            }

            return iOffset;
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int Start()
        {
            int iStart = 0;

            switch (this._i3DBorderStyle)
            {
                case Border3DStyle.Flat: iStart = 0; break;
                case Border3DStyle.Adjust: iStart = 0; break;
                case Border3DStyle.Sunken: iStart = 1; break;
                case Border3DStyle.Bump: iStart = 1; break;
                case Border3DStyle.Etched: iStart = 1; break;
                case Border3DStyle.Raised: iStart = 1; break;
                case Border3DStyle.RaisedInner: iStart = 0; break;
                case Border3DStyle.RaisedOuter: iStart = 0; break;
                case Border3DStyle.SunkenInner: iStart = 0; break;
                case Border3DStyle.SunkenOuter: iStart = 0; break;
                default: iStart = 0; break;
            }
            return iStart;
        }

        /// <summary>
        /// Changes the mouse position.
        /// </summary>
        /// <param name="iNewPosition">The i new position.</param>
        private void ChangeMousePosition(int iNewPosition)
        {
            this._iOldMousePosition = this._iMousePosition;
            this._iMousePosition = iNewPosition;
        }





        #region Include in Private Field

        /// <summary>
        /// The allow transparency
        /// </summary>
        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow transparency].
        /// </summary>
        /// <value><c>true</c> if [allow transparency]; otherwise, <c>false</c>.</value>
        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion



        #region Include in Paint

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        /// <summary>
        /// Makes the transparent.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="g">The g.</param>
        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion




    }

    #endregion

        

    #endregion
}
