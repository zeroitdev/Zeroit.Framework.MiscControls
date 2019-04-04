// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ZeroitSlider.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitSlider.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitSliderDesigner))]
    public class ZeroitSlider : Control
	{
        #region Enum

        /// <summary>
        /// Enum Style
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// The flat
            /// </summary>
            Flat,
            /// <summary>
            /// The material
            /// </summary>
            Material,
            /// <summary>
            /// The mac os
            /// </summary>
            MacOS,
            /// <summary>
            /// The android
            /// </summary>
            Android,
            /// <summary>
            /// The windows10
            /// </summary>
            Windows10
        }

        #endregion

        #region Private Fields
        /// <summary>
        /// The bar rectangle
        /// </summary>
        private Rectangle barRectangle;

        /// <summary>
        /// The buffered graphics
        /// </summary>
        private BufferedGraphics bufferedGraphics;

        /// <summary>
        /// The on handle
        /// </summary>
        private bool onHandle = false;

        /// <summary>
        /// The bar thickness
        /// </summary>
        private int barThickness = 4;

        /// <summary>
        /// The big step increment
        /// </summary>
        private float bigStepIncrement = 1;

        /// <summary>
        /// The percentage
        /// </summary>
        private int percentage = 50;

        /// <summary>
        /// The filled color
        /// </summary>
        private Color filledColor = Color.FromArgb(1, 119, 215);

        /// <summary>
        /// The unfilled color
        /// </summary>
        private Color unfilledColor = Color.FromArgb(26, 169, 219);

        /// <summary>
        /// The knob color
        /// </summary>
        private Color knobColor = Color.Gray;

        /// <summary>
        /// The knob image
        /// </summary>
        private Image knobImage;

        /// <summary>
        /// The quick hopping
        /// </summary>
        private bool quickHopping = true;

        /// <summary>
        /// The slider style
        /// </summary>
        private ZeroitSlider.Style sliderStyle = ZeroitSlider.Style.Windows10;

        /// <summary>
        /// The maximum
        /// </summary>
        private int maximum = 100;

        /// <summary>
        /// The alpha
        /// </summary>
        int alpha = 150;
        #endregion

        #region Events

        /// <summary>
        /// Occurs when [scroll].
        /// </summary>
        public event EventHandler Scroll;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get { return maximum; }
            set
            {
                maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the bar thickness.
        /// </summary>
        /// <value>The bar thickness.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("The bar thickness")]
        public int BarThickness
        {
            get
            {
                return this.barThickness;
            }
            set
            {
                this.barThickness = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the big step increment.
        /// </summary>
        /// <value>The big step increment.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("The increment incresed or decreased when not clicking in the handle")]
        public float BigStepIncrement
        {
            get
            {
                return this.bigStepIncrement;
            }
            set
            {
                this.bigStepIncrement = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the filled.
        /// </summary>
        /// <value>The color of the filled.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("The filled color")]
        public Color FilledColor
        {
            get
            {
                return this.filledColor;
            }
            set
            {
                this.filledColor = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the knob.
        /// </summary>
        /// <value>The color of the knob.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("The knob color")]
        public Color KnobColor
        {
            get
            {
                return this.knobColor;
            }
            set
            {
                this.knobColor = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the knob image.
        /// </summary>
        /// <value>The knob image.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("The knob image")]
        public Image KnobImage
        {
            get
            {
                return this.knobImage;
            }
            set
            {
                this.knobImage = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the percentage.
        /// </summary>
        /// <value>The percentage.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("The default percentage")]
        public int Percentage
        {
            get
            {
                return this.percentage;
            }
            set
            {
                this.percentage = value;
                this.OnScroll();
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [quick hopping].
        /// </summary>
        /// <value><c>true</c> if [quick hopping]; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("Allow instantly jumping to the position clicked")]
        public bool QuickHopping
        {
            get
            {
                return this.quickHopping;
            }
            set
            {
                this.quickHopping = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the slider style.
        /// </summary>
        /// <value>The slider style.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("The slider style")]
        public ZeroitSlider.Style SliderStyle
        {
            get
            {
                return this.sliderStyle;
            }
            set
            {
                this.sliderStyle = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the unfilled.
        /// </summary>
        /// <value>The color of the unfilled.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("The unfilled color")]
        public Color UnfilledColor
        {
            get
            {
                return this.unfilledColor;
            }
            set
            {
                this.unfilledColor = value;
                base.Invalidate();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSlider"/> class.
        /// </summary>
        public ZeroitSlider()
        {
            base.Size = new System.Drawing.Size(250, 20);
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.barRectangle = new Rectangle(base.Height / 2 + 1, 1, base.Width - base.Height, base.Height - 1);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!this.quickHopping)
            {
                float val = Percentage / Maximum;
                int percentage = Convert.ToInt32(val * Width);

                //int percentage = this.Percentage * base.Width / 100;
                if ((e.X <= percentage - base.Height / 2 ? false : e.X < percentage + base.Height / 2))
                {
                    this.onHandle = true;
                }
                else if (e.X < percentage - base.Height / 2)
                {
                    this.Percentage = this.Percentage - Convert.ToInt32(this.bigStepIncrement);
                    if (this.Percentage < 0)
                    {
                        this.Percentage = 0;
                    }
                    base.Invalidate();
                }
                else if (e.X > percentage + base.Height / 2)
                {
                    this.Percentage = this.Percentage + Convert.ToInt32(this.bigStepIncrement);
                    if (this.Percentage > Maximum)
                    {
                        this.Percentage = Maximum;
                    }
                    base.Invalidate();
                }
            }
            else
            {
                this.Percentage = (int)Math.Round((double)(Maximum * e.X) / (double)base.Width);
                this.onHandle = true;
            }
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.onHandle)
            {
                #region Old Working Code
                //this.Percentage = (int)Math.Round((double)(100 * e.X) / (double)base.Width);
                //if (this.Percentage < 0)
                //{
                //	this.Percentage = 0;
                //}
                //if (this.Percentage > 100)
                //{
                //	this.Percentage = 100;
                //} 
                #endregion

                this.Percentage = (int)Math.Round((double)(Maximum * e.X) / (double)base.Width);
                if (this.Percentage < 0)
                {
                    this.Percentage = 0;
                }
                if (this.Percentage > Maximum)
                {
                    this.Percentage = Maximum;
                }

                alpha = 150;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            alpha = 100;

            this.onHandle = false;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            float val = Percentage / Maximum;
            int percentage = Convert.ToInt32(val * Width);

            BufferedGraphicsContext current = BufferedGraphicsManager.Current;
            current.MaximumBuffer = new System.Drawing.Size(base.Width + 1, base.Height + 1);
            this.bufferedGraphics = current.Allocate(base.CreateGraphics(), base.ClientRectangle);
            this.bufferedGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.bufferedGraphics.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            this.bufferedGraphics.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            this.bufferedGraphics.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            int num = Convert.ToInt32((this.Percentage * (Width - Height)) / Maximum);

            this.bufferedGraphics.Graphics.Clear(this.BackColor);
            if (this.sliderStyle == ZeroitSlider.Style.Flat)
            {
                this.bufferedGraphics.Graphics.FillRectangle(new SolidBrush(this.unfilledColor), base.Height / 2 + 1, base.Height / 2 - this.barThickness / 2, base.Width - base.Height - 2, this.barThickness);
                this.bufferedGraphics.Graphics.FillRectangle(new SolidBrush(this.filledColor), 1 + base.Height / 2, base.Height / 2 - this.barThickness / 2, num - 2, this.barThickness);
                if (this.knobImage != null)
                {
                    this.bufferedGraphics.Graphics.DrawImage(new Bitmap(this.knobImage, base.Height - 2, base.Height - 2), num + 1, 1);
                }
                else
                {
                    this.bufferedGraphics.Graphics.FillEllipse(new SolidBrush(this.knobColor), num + 1, 1, base.Height - 2, base.Height - 2);
                }
            }
            if (this.sliderStyle == ZeroitSlider.Style.MacOS)
            {
                this.bufferedGraphics.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(185, 185, 185)), base.Height / 2 + 1, base.Height / 2 - this.barThickness / 2, base.Width - base.Height - 2, this.barThickness);
                this.bufferedGraphics.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, 150, 230)), 1 + base.Height / 2, base.Height / 2 - this.barThickness / 2, num - 2, this.barThickness);
                this.bufferedGraphics.Graphics.FillEllipse(new SolidBrush(Color.White), num + 1, 1, base.Height - 2, base.Height - 2);
                this.bufferedGraphics.Graphics.DrawEllipse(new Pen(Color.FromArgb(190, 200, 200)), num + 1, 1, base.Height - 2, base.Height - 2);
            }
            if (this.sliderStyle == ZeroitSlider.Style.Windows10)
            {
                this.bufferedGraphics.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(146, 147, 148)), base.Height / 2 + 1, base.Height / 2 - this.barThickness / 2, base.Width - base.Height - 2, this.barThickness);
                this.bufferedGraphics.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(65, 155, 225)), 1 + base.Height / 2, base.Height / 2 - this.barThickness / 2, num - 2, this.barThickness);
                this.bufferedGraphics.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 120, 215)), num + 1 + base.Height / 3, 3, base.Height / 2 - 2, base.Height - 6);
                this.bufferedGraphics.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(0, 120, 215)), num + 1 + base.Height / 3, 0, base.Height / 2 - 2, 4);
                this.bufferedGraphics.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(0, 120, 215)), num + 1 + base.Height / 3, base.Height - 5, base.Height / 2 - 2, 4);
            }
            if (this.sliderStyle == ZeroitSlider.Style.Android)
            {
                this.bufferedGraphics.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, 100, 100)), base.Height / 2 + 1, base.Height / 2 - this.barThickness / 2, base.Width - base.Height - 2, this.barThickness);
                this.bufferedGraphics.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 180, 230)), 1 + base.Height / 2, base.Height / 2 - this.barThickness / 2, num - 2, this.barThickness);
                this.bufferedGraphics.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(50, 180, 230)), num + 1 + this.barThickness / 3 * 5, base.Height / 2 - this.barThickness / 3 * 4, this.barThickness * 2, this.barThickness * 2);
                this.bufferedGraphics.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(alpha, 50, 180, 230)), num + 1, 1, base.Height - 2, base.Height - 2);
                this.bufferedGraphics.Graphics.DrawEllipse(new Pen(Color.FromArgb(50, 180, 230), 2f), num + 1, 1, base.Height - 2, base.Height - 2);
            }
            if (this.sliderStyle == ZeroitSlider.Style.Material)
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), Color.Black, Color.Black, 0f, false);
                ColorBlend colorBlend = new ColorBlend()
                {
                    Positions = new float[] { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f },
                    Colors = new Color[] { Color.FromArgb(76, 217, 100), Color.FromArgb(85, 205, 205), Color.FromArgb(2, 124, 255), Color.FromArgb(130, 75, 180), Color.FromArgb(255, 0, 150), Color.FromArgb(255, 45, 85) }
                };
                linearGradientBrush.InterpolationColors = colorBlend;
                linearGradientBrush.RotateTransform(1f);
                this.bufferedGraphics.Graphics.FillRectangle(linearGradientBrush, base.Height / 2 + 1, base.Height / 2 - this.barThickness / 2, base.Width - base.Height - 2, this.barThickness);
                this.bufferedGraphics.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 1 + base.Height / 2 + num, base.Height / 2 - this.barThickness / 2, base.Width - base.Height - 2 - num, this.barThickness);
                this.bufferedGraphics.Graphics.FillEllipse(new SolidBrush(Color.White), num + 1, 1, base.Height - 2, base.Height - 2);
                this.bufferedGraphics.Graphics.DrawEllipse(new Pen(Color.FromArgb(200, 200, 200)), num + 1, 1, base.Height - 2, base.Height - 2);
            }
            this.bufferedGraphics.Render(e.Graphics);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when [scroll].
        /// </summary>
        protected virtual void OnScroll()
        {
            if (this.Scroll != null)
            {
                this.Scroll(this, EventArgs.Empty);
            }
        }

        #endregion
               
        
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitSliderDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitSliderDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitSliderDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitSliderSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }

        #region Zeroit Filter (Remove Properties)
        /// <summary>
        /// Remove Button and Control properties that are
        /// not supported by the <see cref="MACButton" />.
        /// </summary>
        /// <param name="Properties">The properties.</param>
        protected override void PostFilterProperties(IDictionary Properties)
        {
            //Properties.Remove("AllowDrop");
            //Properties.Remove("FlatStyle");
            //Properties.Remove("ForeColor");
            //Properties.Remove("ImageIndex");
            //Properties.Remove("ImageList");
        }
        #endregion

    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitSliderSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitSliderSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitSlider colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSliderSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitSliderSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitSlider;

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
        /// Gets or sets a value indicating whether [quick hopping].
        /// </summary>
        /// <value><c>true</c> if [quick hopping]; otherwise, <c>false</c>.</value>
        public bool QuickHopping
        {
            get
            {
                return colUserControl.QuickHopping;
            }
            set
            {
                GetPropertyByName("QuickHopping").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the slider style.
        /// </summary>
        /// <value>The slider style.</value>
        public ZeroitSlider.Style SliderStyle
        {
            get
            {
                return colUserControl.SliderStyle;
            }
            set
            {
                GetPropertyByName("SliderStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return colUserControl.Maximum;
            }
            set
            {
                GetPropertyByName("Maximum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the percentage.
        /// </summary>
        /// <value>The percentage.</value>
        public int Percentage
        {
            get
            {
                return colUserControl.Percentage;
            }
            set
            {
                GetPropertyByName("Percentage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the bar thickness.
        /// </summary>
        /// <value>The bar thickness.</value>
        public int BarThickness
        {
            get
            {
                return colUserControl.BarThickness;
            }
            set
            {
                GetPropertyByName("BarThickness").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the big step increment.
        /// </summary>
        /// <value>The big step increment.</value>
        public float BigStepIncrement
        {
            get
            {
                return colUserControl.BigStepIncrement;
            }
            set
            {
                GetPropertyByName("BigStepIncrement").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the filled.
        /// </summary>
        /// <value>The color of the filled.</value>
        public Color FilledColor
        {
            get
            {
                return colUserControl.FilledColor;
            }
            set
            {
                GetPropertyByName("FilledColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the knob.
        /// </summary>
        /// <value>The color of the knob.</value>
        public Color KnobColor
        {
            get
            {
                return colUserControl.KnobColor;
            }
            set
            {
                GetPropertyByName("KnobColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the unfilled.
        /// </summary>
        /// <value>The color of the unfilled.</value>
        public Color UnfilledColor
        {
            get
            {
                return colUserControl.UnfilledColor;
            }
            set
            {
                GetPropertyByName("UnfilledColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the knob image.
        /// </summary>
        /// <value>The knob image.</value>
        public Image KnobImage
        {
            get
            {
                return colUserControl.KnobImage;
            }
            set
            {
                GetPropertyByName("KnobImage").SetValue(colUserControl, value);
            }
        }



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

            items.Add(new DesignerActionPropertyItem("QuickHopping",
                                 "Quick Hopping", "Appearance",
                                 "Set to enable immediate hop on mouse click."));

            items.Add(new DesignerActionPropertyItem("SliderStyle",
                                 "Slider Style", "Appearance",
                                 "Sets the slider type."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value."));

            items.Add(new DesignerActionPropertyItem("Percentage",
                                 "Percentage", "Appearance",
                                 "Sets the percentage."));

            items.Add(new DesignerActionPropertyItem("BarThickness",
                                 "Bar Thickness", "Appearance",
                                 "Sets the bar's thickness."));

            items.Add(new DesignerActionPropertyItem("BigStepIncrement",
                                 "Big Step Increment", "Appearance",
                                 "Sets the increment value."));

            items.Add(new DesignerActionPropertyItem("FilledColor",
                                 "Filled Color", "Appearance",
                                 "Sets the fill color."));

            items.Add(new DesignerActionPropertyItem("KnobColor",
                                 "Knob Color", "Appearance",
                                 "Sets the knob color."));


            items.Add(new DesignerActionPropertyItem("UnfilledColor",
                                 "Unfilled Color", "Appearance",
                                 "Sets the slider bar color."));

            items.Add(new DesignerActionPropertyItem("KnobImage",
                                 "Knob Image", "Appearance",
                                 "Sets the knob's image."));



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

}