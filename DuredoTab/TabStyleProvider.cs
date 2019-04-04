// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabStyleProvider.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.Tabs
{
    /// <summary>
    /// Class TabStyleProvider.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Component" />
    [System.ComponentModel.ToolboxItem(false)]
	public abstract class TabStyleProvider : Component
	{
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TabStyleProvider"/> class.
        /// </summary>
        /// <param name="tabControl">The tab control.</param>
        protected TabStyleProvider(ZeroitDuredoTab tabControl){
			this._TabControl = tabControl;
			
			this._BorderColor = Color.Empty;
			this._BorderColorSelected = Color.Empty;
			this._FocusColor = Color.Orange;
			
			if (this._TabControl.RightToLeftLayout){
				this._ImageAlign = ContentAlignment.MiddleRight;
			} else {
				this._ImageAlign = ContentAlignment.MiddleLeft;
			}
			
			this.HotTrack = true;
			
			//	Must set after the _Overlap as this is used in the calculations of the actual padding
			this.Padding = new Point(6,3);
		}

        #endregion

        #region Factory Methods

        /// <summary>
        /// Creates the provider.
        /// </summary>
        /// <param name="tabControl">The tab control.</param>
        /// <returns>TabStyleProvider.</returns>
        public static TabStyleProvider CreateProvider(ZeroitDuredoTab tabControl){
			TabStyleProvider provider;
			
			//	Depending on the display style of the tabControl generate an appropriate provider.
			switch (tabControl.DisplayStyle) {
				case TabStyle.None:
					provider = new TabStyleNoneProvider(tabControl);
					break;
					
				case TabStyle.Default:
					provider = new TabStyleDefaultProvider(tabControl);
					break;
					
				case TabStyle.Angled:
					provider = new TabStyleAngledProvider(tabControl);
					break;
					
				case TabStyle.Rounded:
					provider = new TabStyleRoundedProvider(tabControl);
					break;
					
				case TabStyle.VisualStudio:
					provider = new TabStyleVisualStudioProvider(tabControl);
					break;
					
				case TabStyle.Chrome:
					provider = new TabStyleChromeProvider(tabControl);
					break;
					
				case TabStyle.IE8:
					provider = new TabStyleIE8Provider(tabControl);
					break;

				case TabStyle.VS2010:
					provider = new TabStyleVS2010Provider(tabControl);
					break;

				default:
					provider = new TabStyleDefaultProvider(tabControl);
					break;
			}
			
			provider._Style = tabControl.DisplayStyle;
			return provider;
		}

        #endregion

        #region	Protected variables

        /// <summary>
        /// The tab control
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected ZeroitDuredoTab _TabControl;

        /// <summary>
        /// The padding
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected Point _Padding;
        /// <summary>
        /// The hot track
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected bool _HotTrack;
        /// <summary>
        /// The style
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected TabStyle _Style = TabStyle.Default;


        /// <summary>
        /// The image align
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected ContentAlignment _ImageAlign;
        /// <summary>
        /// The radius
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected int _Radius = 1;
        /// <summary>
        /// The overlap
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected int _Overlap;
        /// <summary>
        /// The focus track
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected bool _FocusTrack;
        /// <summary>
        /// The opacity
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected float _Opacity = 1;
        /// <summary>
        /// The show tab closer
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected bool _ShowTabCloser;

        /// <summary>
        /// The border color selected
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected Color _BorderColorSelected = Color.Empty;
        /// <summary>
        /// The border color
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected Color _BorderColor = Color.Empty;
        /// <summary>
        /// The border color hot
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected Color _BorderColorHot = Color.Empty;
        /// <summary>
        /// The closer color active
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		
		protected Color _CloserColorActive = Color.Black;
        /// <summary>
        /// The closer color
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected Color _CloserColor = Color.DarkGray;
        /// <summary>
        /// The focus color
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		
		protected Color _FocusColor = Color.Empty;
        /// <summary>
        /// The text color
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		
		protected Color _TextColor = Color.Empty;
        /// <summary>
        /// The text color selected
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected Color _TextColorSelected = Color.Empty;
        /// <summary>
        /// The text color disabled
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
		protected Color _TextColorDisabled = Color.Empty;

        #endregion

        #region overridable Methods

        /// <summary>
        /// Adds the tab border.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="tabBounds">The tab bounds.</param>
        public abstract void AddTabBorder(GraphicsPath path, Rectangle tabBounds);

        /// <summary>
        /// Gets the tab rect.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Rectangle.</returns>
        public virtual Rectangle GetTabRect(int index){
			
			if (index < 0){
				return new Rectangle();
			}
			Rectangle tabBounds = this._TabControl.GetTabRect(index);
			if (this._TabControl.RightToLeftLayout){
				tabBounds.X = this._TabControl.Width - tabBounds.Right;
			}
			bool firstTabinRow = this._TabControl.IsFirstTabInRow(index);
			
			//	Expand to overlap the tabpage
			switch (this._TabControl.Alignment) {
				case TabAlignment.Top:
					tabBounds.Height += 2;
					break;
				case TabAlignment.Bottom:
					tabBounds.Height += 2;
					tabBounds.Y -= 2;
					break;
				case TabAlignment.Left:
					tabBounds.Width += 2;
					break;
				case TabAlignment.Right:
					tabBounds.X -= 2;
					tabBounds.Width += 2;
					break;
			}
			

			//	Greate Overlap unless first tab in the row to align with tabpage
			if ((!firstTabinRow || this._TabControl.RightToLeftLayout) && this._Overlap > 0) {
				if (this._TabControl.Alignment <= TabAlignment.Bottom) {
					tabBounds.X -= this._Overlap;
					tabBounds.Width += this._Overlap;
				} else {
					tabBounds.Y -= this._Overlap;
					tabBounds.Height += this._Overlap;
				}
			}

			//	Adjust first tab in the row to align with tabpage
			this.EnsureFirstTabIsInView(ref tabBounds, index);

			return tabBounds;
		}


        /// <summary>
        /// Ensures the first tab is in view.
        /// </summary>
        /// <param name="tabBounds">The tab bounds.</param>
        /// <param name="index">The index.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#")]
		protected virtual void EnsureFirstTabIsInView(ref Rectangle tabBounds, int index){
			//	Adjust first tab in the row to align with tabpage
			//	Make sure we only reposition visible tabs, as we may have scrolled out of view.
			
			bool firstTabinRow = this._TabControl.IsFirstTabInRow(index);

			if (firstTabinRow) {
				if (this._TabControl.Alignment <= TabAlignment.Bottom) {
					if (this._TabControl.RightToLeftLayout) {
						if (tabBounds.Left < this._TabControl.Right) {
							int tabPageRight = this._TabControl.GetPageBounds(index).Right;
							if (tabBounds.Right > tabPageRight) {
								tabBounds.Width -= (tabBounds.Right - tabPageRight);
							}
						}
					} else {
						if (tabBounds.Right > 0) {
							int tabPageX = this._TabControl.GetPageBounds(index).X;
							if (tabBounds.X < tabPageX) {
								tabBounds.Width -= (tabPageX - tabBounds.X);
								tabBounds.X = tabPageX;
							}
						}
					}
				} else {
					if (this._TabControl.RightToLeftLayout) {
						if (tabBounds.Top < this._TabControl.Bottom) {
							int tabPageBottom = this._TabControl.GetPageBounds(index).Bottom;
							if (tabBounds.Bottom > tabPageBottom) {
								tabBounds.Height -= (tabBounds.Bottom - tabPageBottom);
							}
						}
					} else {
						if (tabBounds.Bottom > 0) {
							int tabPageY = this._TabControl.GetPageBounds(index).Location.Y;
							if (tabBounds.Y < tabPageY) {
								tabBounds.Height -= (tabPageY - tabBounds.Y);
								tabBounds.Y = tabPageY;
							}
						}
					}
				}
			}
		}

        /// <summary>
        /// Gets the tab background brush.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Brush.</returns>
        protected virtual Brush GetTabBackgroundBrush(int index){
			LinearGradientBrush fillBrush = null;

			//	Capture the colours dependant on selection state of the tab
			Color dark = Color.FromArgb(207, 207, 207);
			Color light = Color.FromArgb(242, 242, 242);
			
			if (this._TabControl.SelectedIndex == index) {
				dark = SystemColors.ControlLight;
				light = SystemColors.Window;
			} else if (!this._TabControl.TabPages[index].Enabled){
				light = dark;
			} else if (this._HotTrack && index == this._TabControl.ActiveIndex){
				//	Enable hot tracking
				light = Color.FromArgb(234, 246, 253);
				dark = Color.FromArgb(167, 217, 245);
			}
			
			//	Get the correctly aligned gradient
			Rectangle tabBounds = this.GetTabRect(index);
			tabBounds.Inflate(3,3);
			tabBounds.X -= 1;
			tabBounds.Y -= 1;
			switch (this._TabControl.Alignment) {
				case TabAlignment.Top:
					if (this._TabControl.SelectedIndex == index) {
						dark = light;
					}
					fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Vertical);
					break;
				case TabAlignment.Bottom:
					fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Vertical);
					break;
				case TabAlignment.Left:
					fillBrush = new LinearGradientBrush(tabBounds, dark, light, LinearGradientMode.Horizontal);
					break;
				case TabAlignment.Right:
					fillBrush = new LinearGradientBrush(tabBounds, light, dark, LinearGradientMode.Horizontal);
					break;
			}
			
			//	Add the blend
			fillBrush.Blend = this.GetBackgroundBlend();
			
			return fillBrush;
		}

        #endregion

        #region	Base Properties

        /// <summary>
        /// Gets or sets the display style.
        /// </summary>
        /// <value>The display style.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public TabStyle DisplayStyle {
			get { return this._Style; }
			set { this._Style = value; }
		}

        /// <summary>
        /// Gets or sets the image align.
        /// </summary>
        /// <value>The image align.</value>
        [Category("Appearance")]
		public ContentAlignment ImageAlign {
			get { return this._ImageAlign; }
			set {
				this._ImageAlign = value;
				this._TabControl.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets the padding.
        /// </summary>
        /// <value>The padding.</value>
        [Category("Appearance")]
		public Point Padding {
			get { return this._Padding; }
			set {
				this._Padding = value;
				//	This line will trigger the handle to recreate, therefore invalidating the control
				if (this._ShowTabCloser){
					if (value.X + (int)(this._Radius/2) < -6){
						((TabControl)this._TabControl).Padding = new Point(0, value.Y);
					} else {
						((TabControl)this._TabControl).Padding = new Point(value.X + (int)(this._Radius/2) + 6, value.Y);
					}
				} else {
					if (value.X + (int)(this._Radius/2) < 1){
						((TabControl)this._TabControl).Padding = new Point(0, value.Y);
					} else {
						((TabControl)this._TabControl).Padding = new Point(value.X + (int)(this._Radius/2) -1, value.Y);
					}
				}
			}
		}


        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>The radius.</value>
        /// <exception cref="System.ArgumentException">The radius must be greater than 1 - value</exception>
        [Category("Appearance"), DefaultValue(1), Browsable(true)]
		public int Radius {
			get { return this._Radius; }
			set {
				if (value < 1){
					throw new ArgumentException("The radius must be greater than 1", "value");
				}
				this._Radius = value;
				//	Adjust padding
				this.Padding = this._Padding;
			}
		}

        /// <summary>
        /// Gets or sets the overlap.
        /// </summary>
        /// <value>The overlap.</value>
        /// <exception cref="System.ArgumentException">The tabs cannot have a negative overlap - value</exception>
        [Category("Appearance")]
		public int Overlap {
			get { return this._Overlap; }
			set {
				if (value < 0){
					throw new ArgumentException("The tabs cannot have a negative overlap", "value");
				}
				this._Overlap = value;
				
			}
		}


        /// <summary>
        /// Gets or sets a value indicating whether [focus track].
        /// </summary>
        /// <value><c>true</c> if [focus track]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
		public bool FocusTrack {
			get { return this._FocusTrack; }
			set {
				this._FocusTrack = value;
				this._TabControl.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether [hot track].
        /// </summary>
        /// <value><c>true</c> if [hot track]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
		public bool HotTrack {
			get { return this._HotTrack; }
			set {
				this._HotTrack = value;
				((TabControl)this._TabControl).HotTrack = value;
			}
		}

        /// <summary>
        /// Gets or sets a value indicating whether [show tab closer].
        /// </summary>
        /// <value><c>true</c> if [show tab closer]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
		public bool ShowTabCloser {
			get { return this._ShowTabCloser; }
			set {
				this._ShowTabCloser = value;
				//	Adjust padding
				this.Padding = this._Padding;
			}
		}

        /// <summary>
        /// Gets or sets the opacity.
        /// </summary>
        /// <value>The opacity.</value>
        /// <exception cref="System.ArgumentException">
        /// The opacity must be between 0 and 1 - value
        /// or
        /// The opacity must be between 0 and 1 - value
        /// </exception>
        [Category("Appearance")]
		public float Opacity {
			get { return this._Opacity; }
			set {
				if (value < 0){
					throw new ArgumentException("The opacity must be between 0 and 1", "value");
				}
				if (value > 1){
					throw new ArgumentException("The opacity must be between 0 and 1", "value");
				}
				this._Opacity = value;
				this._TabControl.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets the border color selected.
        /// </summary>
        /// <value>The border color selected.</value>
        [Category("Appearance"), DefaultValue(typeof(Color), "")]
		public Color BorderColorSelected
		{
			get {
				if (this._BorderColorSelected.IsEmpty){
					return ThemedColors.ToolBorder;
				} else {
					return this._BorderColorSelected;
				}
			}
			set {
				if (value.Equals(ThemedColors.ToolBorder)){
					this._BorderColorSelected = Color.Empty;
				} else {
					this._BorderColorSelected = value;
				}
				this._TabControl.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets the border color hot.
        /// </summary>
        /// <value>The border color hot.</value>
        [Category("Appearance"), DefaultValue(typeof(Color), "")]
		public Color BorderColorHot
		{
			get {
				if (this._BorderColorHot.IsEmpty){
					return SystemColors.ControlDark;
				} else {
					return this._BorderColorHot;
				}
			}
			set {
				if (value.Equals(SystemColors.ControlDark)){
					this._BorderColorHot = Color.Empty;
				} else {
					this._BorderColorHot = value;
				}
				this._TabControl.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Category("Appearance"), DefaultValue(typeof(Color), "")]
		public Color BorderColor
		{
			get {
				if (this._BorderColor.IsEmpty){
					return SystemColors.ControlDark;
				} else {
					return this._BorderColor;
				}
			}
			set {
				if (value.Equals(SystemColors.ControlDark)){
					this._BorderColor = Color.Empty;
				} else {
					this._BorderColor = value;
				}
				this._TabControl.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        [Category("Appearance"), DefaultValue(typeof(Color), "")]
		public Color TextColor
		{
			get {
				if (this._TextColor.IsEmpty){
					return SystemColors.ControlText;
				} else {
					return this._TextColor;
				}
			}
			set {
				if (value.Equals(SystemColors.ControlText)){
					this._TextColor = Color.Empty;
				} else {
					this._TextColor = value;
				}
				this._TabControl.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets the text color selected.
        /// </summary>
        /// <value>The text color selected.</value>
        [Category("Appearance"), DefaultValue(typeof(Color), "")]
		public Color TextColorSelected
		{
			get {
				if (this._TextColorSelected.IsEmpty){
					return SystemColors.ControlText;
				} else {
					return this._TextColorSelected;
				}
			}
			set {
				if (value.Equals(SystemColors.ControlText)){
					this._TextColorSelected = Color.Empty;
				} else {
					this._TextColorSelected = value;
				}
				this._TabControl.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets the text color disabled.
        /// </summary>
        /// <value>The text color disabled.</value>
        [Category("Appearance"), DefaultValue(typeof(Color), "")]
		public Color TextColorDisabled
		{
			get {
				if (this._TextColor.IsEmpty){
					return SystemColors.ControlDark;
				} else {
					return this._TextColorDisabled;
				}
			}
			set {
				if (value.Equals(SystemColors.ControlDark)){
					this._TextColorDisabled = Color.Empty;
				} else {
					this._TextColorDisabled = value;
				}
				this._TabControl.Invalidate();
			}
		}


        /// <summary>
        /// Gets or sets the color of the focus.
        /// </summary>
        /// <value>The color of the focus.</value>
        [Category("Appearance"), DefaultValue(typeof(Color), "Orange")]
		public Color FocusColor
		{
			get { return this._FocusColor; }
			set { this._FocusColor = value;
				this._TabControl.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets the closer color active.
        /// </summary>
        /// <value>The closer color active.</value>
        [Category("Appearance"), DefaultValue(typeof(Color), "Black")]
		public Color CloserColorActive
		{
			get { return this._CloserColorActive; }
			set { this._CloserColorActive = value;
				this._TabControl.Invalidate();
			}
		}

        /// <summary>
        /// Gets or sets the color of the closer.
        /// </summary>
        /// <value>The color of the closer.</value>
        [Category("Appearance"), DefaultValue(typeof(Color), "DarkGrey")]
		public Color CloserColor
		{
			get { return this._CloserColor; }
			set { this._CloserColor = value;
				this._TabControl.Invalidate();
			}
		}

        #endregion

        #region Painting

        /// <summary>
        /// Paints the tab.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="graphics">The graphics.</param>
        public void PaintTab(int index, Graphics graphics){
			using (GraphicsPath tabpath = this.GetTabBorder(index)) {
				using (Brush fillBrush = this.GetTabBackgroundBrush(index)) {
					//	Paint the background
					graphics.FillPath(fillBrush, tabpath);
					
					//	Paint a focus indication
					if (this._TabControl.Focused){
						this.DrawTabFocusIndicator(tabpath, index, graphics);
					}

					//	Paint the closer
					this.DrawTabCloser(index, graphics);

				}
			}
		}

        /// <summary>
        /// Draws the tab closer.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="graphics">The graphics.</param>
        protected virtual void DrawTabCloser(int index, Graphics graphics){
			if (this._ShowTabCloser){
				Rectangle closerRect = this._TabControl.GetTabCloserRect(index);
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				using (GraphicsPath closerPath = TabStyleProvider.GetCloserPath(closerRect)){
					if (closerRect.Contains(this._TabControl.MousePosition)){
						using (Pen closerPen = new Pen(this._CloserColorActive)){
							graphics.DrawPath(closerPen, closerPath);
						}
					} else {
						using (Pen closerPen = new Pen(this._CloserColor)){
							graphics.DrawPath(closerPen, closerPath);
						}
					}
					
				}
			}
		}

        /// <summary>
        /// Gets the closer path.
        /// </summary>
        /// <param name="closerRect">The closer rect.</param>
        /// <returns>GraphicsPath.</returns>
        protected static GraphicsPath GetCloserPath(Rectangle closerRect){
			GraphicsPath closerPath = new GraphicsPath();
			closerPath.AddLine(closerRect.X, closerRect.Y, closerRect.Right, closerRect.Bottom);
			closerPath.CloseFigure();
			closerPath.AddLine(closerRect.Right, closerRect.Y, closerRect.X, closerRect.Bottom);
			closerPath.CloseFigure();
			
			return closerPath;
		}

        /// <summary>
        /// Draws the tab focus indicator.
        /// </summary>
        /// <param name="tabpath">The tabpath.</param>
        /// <param name="index">The index.</param>
        /// <param name="graphics">The graphics.</param>
        private void DrawTabFocusIndicator(GraphicsPath tabpath, int index, Graphics graphics)
		{
			if (this._FocusTrack && this._TabControl.Focused && index == this._TabControl.SelectedIndex) {
				Brush focusBrush = null;
				RectangleF pathRect = tabpath.GetBounds();
				Rectangle focusRect = Rectangle.Empty;
				switch (this._TabControl.Alignment) {
					case TabAlignment.Top:
						focusRect = new Rectangle((int)pathRect.X, (int)pathRect.Y, (int)pathRect.Width, 4);
						focusBrush = new LinearGradientBrush(focusRect,this._FocusColor, SystemColors.Window, LinearGradientMode.Vertical);
						break;
					case TabAlignment.Bottom:
						focusRect = new Rectangle((int)pathRect.X, (int)pathRect.Bottom - 4, (int)pathRect.Width, 4);
						focusBrush = new LinearGradientBrush(focusRect, SystemColors.ControlLight, this._FocusColor, LinearGradientMode.Vertical);
						break;
					case TabAlignment.Left:
						focusRect = new Rectangle((int)pathRect.X, (int)pathRect.Y, 4, (int)pathRect.Height);
						focusBrush = new LinearGradientBrush(focusRect, this._FocusColor, SystemColors.ControlLight, LinearGradientMode.Horizontal);
						break;
					case TabAlignment.Right:
						focusRect = new Rectangle((int)pathRect.Right - 4, (int)pathRect.Y, 4, (int)pathRect.Height);
						focusBrush = new LinearGradientBrush(focusRect, SystemColors.ControlLight, this._FocusColor, LinearGradientMode.Horizontal);
						break;
				}
				
				//	Ensure the focus stip does not go outside the tab
				Region focusRegion = new Region(focusRect);
				focusRegion.Intersect(tabpath);
				graphics.FillRegion(focusBrush, focusRegion);
				focusRegion.Dispose();
				focusBrush.Dispose();
			}
		}

        #endregion

        #region Background brushes

        /// <summary>
        /// Gets the background blend.
        /// </summary>
        /// <returns>Blend.</returns>
        private Blend GetBackgroundBlend(){
			float[] relativeIntensities = new float[]{0f, 0.7f, 1f};
			float[] relativePositions = new float[]{0f, 0.6f, 1f};

			//	Glass look to top aligned tabs
			if (this._TabControl.Alignment == TabAlignment.Top){
				relativeIntensities = new float[]{0f, 0.5f, 1f, 1f};
				relativePositions = new float[]{0f, 0.5f, 0.51f, 1f};
			}
			
			Blend blend = new Blend();
			blend.Factors = relativeIntensities;
			blend.Positions = relativePositions;
			
			return blend;
		}

        /// <summary>
        /// Gets the page background brush.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Brush.</returns>
        public virtual Brush GetPageBackgroundBrush(int index){

			//	Capture the colours dependant on selection state of the tab
			Color light = Color.FromArgb(242, 242, 242);
			if (this._TabControl.Alignment == TabAlignment.Top){
				light = Color.FromArgb(207, 207, 207);
			}
			
			if (this._TabControl.SelectedIndex == index) {
				light = SystemColors.Window;
			} else if (!this._TabControl.TabPages[index].Enabled){
				light = Color.FromArgb(207, 207, 207);
			} else if (this._HotTrack && index == this._TabControl.ActiveIndex){
				//	Enable hot tracking
				light = Color.FromArgb(234, 246, 253);
			}
			
			return new SolidBrush(light);
		}

        #endregion

        #region Tab border and rect

        /// <summary>
        /// Gets the tab border.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>GraphicsPath.</returns>
        public GraphicsPath GetTabBorder(int index){
			
			GraphicsPath path = new GraphicsPath();
			Rectangle tabBounds = this.GetTabRect(index);
			
			this.AddTabBorder(path, tabBounds);
			
			path.CloseFigure();
			return path;
		}

		#endregion
		
	}
}
