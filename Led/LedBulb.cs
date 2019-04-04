// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="LedBulb.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region Led

    #region Control

    /// <summary>
    /// A class collection for rendering a led bulb.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DesignerCategory("Code")]
    [Designer(typeof(ZeroitLedBulbDesigner))]
    public class ZeroitLedBulb : System.Windows.Forms.Control
    {
        #region Private Fields

        /// <summary>
        /// The tick
        /// </summary>
        private System.Windows.Forms.Timer tick;

        /// <summary>
        /// The shinny on
        /// </summary>
        private Color shinnyOn = Color.White;
        /// <summary>
        /// The shinny off
        /// </summary>
        private Color shinnyOff = Color.Black;
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = System.Drawing.SystemColors.ControlDarkDark;
        /// <summary>
        /// The color off
        /// </summary>
        private Color _ColorOff = SystemColors.Control;
        /// <summary>
        /// The color on
        /// </summary>
        private Color _ColorOn = Color.Red;
        /// <summary>
        /// The flash colors
        /// </summary>
        public Color[] flashColors;

        /// <summary>
        /// The border width
        /// </summary>
        private int borderWidth = 1;
        /// <summary>
        /// The flash intervals
        /// </summary>
        public int[] flashIntervals = new int[1] { 250 };
        /// <summary>
        /// The tick index
        /// </summary>
        public int tickIndex;

        /// <summary>
        /// The flash colors
        /// </summary>
        private string _FlashColors = string.Empty;
        /// <summary>
        /// The flash intervals
        /// </summary>
        private string _FlashIntervals = "250";

        /// <summary>
        /// The active
        /// </summary>
        private bool _Active = true;
        /// <summary>
        /// The flash
        /// </summary>
        private bool _Flash = false;

        /// <summary>
        /// Occurs when the control is redrawn.
        /// </summary>
        public new event PaintEventHandler Paint;

        #endregion

        #region Public properties


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

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        [Category("Appearance")]
        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Category("Appearance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shinny color when on.
        /// </summary>
        /// <value>The shinny on.</value>
        [Category("Appearance")]
        public Color ShinnyOn
        {
            get { return shinnyOn; }
            set
            {
                shinnyOn = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shinny color when off.
        /// </summary>
        /// <value>The shinny off.</value>
        [Category("Appearance")]
        public Color ShinnyOff
        {
            get { return shinnyOff; }
            set
            {
                shinnyOff = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitLedBulb" /> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [Category("Behavior"),
        DefaultValue(true)]
        public bool Active
        {
            get { return _Active; }
            set
            {
                _Active = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color when the bulb is on.
        /// </summary>
        /// <value>The color on.</value>
        [Category("Appearance")]
        public Color ColorOn
        {
            get { return _ColorOn; }
            set
            {
                _ColorOn = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color when the bulb is off.
        /// </summary>
        /// <value>The color off.</value>
        [Category("Appearance")]
        public Color ColorOff
        {
            get { return _ColorOff; }
            set
            {
                _ColorOff = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitLedBulb" /> should start flashing.
        /// </summary>
        /// <value><c>true</c> if flash; otherwise, <c>false</c>.</value>
        [Category("Behavior"),
        DefaultValue(false)]
        public bool Flash
        {
            get { return _Flash; }
            set
            {
                _Flash = value && (flashIntervals.Length > 0);
                tickIndex = 0;
                tick.Interval = flashIntervals[tickIndex];
                tick.Enabled = _Flash;
                Active = true;
            }
        }

        /// <summary>
        /// Gets or sets the flash speed.
        /// </summary>
        /// <value>The flash speed.</value>
        [Category("Appearance"),
        DefaultValue("250")]
        public string FlashSpeed
        {
            get { return _FlashIntervals; }
            set
            {
                _FlashIntervals = value;
                string[] fi = _FlashIntervals.Split(new char[] { ',', '/', '|', ' ', '\n' });
                flashIntervals = new int[fi.Length];
                for (int i = 0; i < fi.Length; i++)
                    try
                    {
                        flashIntervals[i] = int.Parse(fi[i]);
                    }
                    catch
                    {
                        flashIntervals[i] = 25;
                    }
            }
        }

        /// <summary>
        /// Gets or sets the flash colors.
        /// </summary>
        /// <value>The flash colors.</value>
        [Category("Appearance"),
        DefaultValue(""),
        Browsable(true)]
        public string FlashColors
        {
            get { return _FlashColors; }
            set
            {
                _FlashColors = value;
                if (_FlashColors == string.Empty)
                {
                    flashColors = null;
                }
                else
                {
                    string[] fc = _FlashColors.Split(new char[] { ',', '/', '|', ' ', '\n' });
                    flashColors = new Color[fc.Length];
                    for (int i = 0; i < fc.Length; i++)
                        try
                        {
                            flashColors[i] = (fc[i] != "") ? Color.FromName(fc[i]) : Color.Empty;
                        }
                        catch
                        {
                            flashColors[i] = Color.Empty;
                        }
                }
            }
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLedBulb" /> class.
        /// </summary>
        public ZeroitLedBulb() : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            BackColor = Color.Transparent;

            Width = 17;
            Height = 17;

            tick = new System.Windows.Forms.Timer();
            tick.Enabled = false;
            tick.Tick += new System.EventHandler(this._Tick);
        }

        #endregion

        #region helper color functions
        /// <summary>
        /// Fades the color.
        /// </summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="i1">The i1.</param>
        /// <param name="i2">The i2.</param>
        /// <returns>Color.</returns>
        public static Color FadeColor(Color c1, Color c2, int i1, int i2)
        {
            int r = (i1 * c1.R + i2 * c2.R) / (i1 + i2);
            int g = (i1 * c1.G + i2 * c2.G) / (i1 + i2);
            int b = (i1 * c1.B + i2 * c2.B) / (i1 + i2);

            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Fades the color.
        /// </summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <returns>Color.</returns>
        public static Color FadeColor(Color c1, Color c2)
        {
            return FadeColor(c1, c2, 1, 1);
        }
        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (null != Paint) Paint(this, e);
            else
            {
                base.OnPaint(e);
                //        e.Graphics.Clear(BackColor);
                e.Graphics.SmoothingMode = smoothing;
                if (Enabled)
                {
                    if (Active)
                    {
                        e.Graphics.FillEllipse(new SolidBrush(ColorOn), 1, 1, Width - 3, Height - 3);
                        e.Graphics.DrawArc(new Pen(FadeColor(ColorOn, shinnyOn, 1, 2), 2), 3, 3, Width - 7, Height - 7, -90.0F, -90.0F);
                        e.Graphics.DrawEllipse(new Pen(FadeColor(ColorOn, shinnyOn), 1), 1, 1, Width - 3, Height - 3);
                    }
                    else
                    {
                        e.Graphics.FillEllipse(new SolidBrush(ColorOff), 1, 1, Width - 3, Height - 3);
                        e.Graphics.DrawArc(new Pen(FadeColor(ColorOff, shinnyOff, 2, 1), 2), 3, 3, Width - 7, Height - 7, 0.0F, 90.0F);
                        e.Graphics.DrawEllipse(new Pen(FadeColor(ColorOff, shinnyOff), 1), 1, 1, Width - 3, Height - 3);
                    }
                }
                else e.Graphics.DrawEllipse(new Pen(borderColor, borderWidth), 1, 1, Width - 3, Height - 3);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Handles the Tick event of the  control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void _Tick(object sender, System.EventArgs e)
        {
            tickIndex = (++tickIndex) % (flashIntervals.Length);
            tick.Interval = flashIntervals[tickIndex];
            try
            {
                if ((flashColors == null) || (flashColors.Length < tickIndex) || (flashColors[tickIndex] == Color.Empty))
                    Active = !Active;
                else
                {
                    ColorOn = flashColors[tickIndex];
                    Active = true;
                }
            }
            catch
            {
                Active = !Active;
            }
        }

        #endregion

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitLedBulbDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitLedBulbDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitLedBulbDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitLedBulbSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitLedBulbSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitLedBulbSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitLedBulb colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLedBulbSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitLedBulbSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitLedBulb;

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

        #region Public properties


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


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitLedBulbSmartTagActionList"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active
        {
            get
            {
                return colUserControl.Active;
            }
            set
            {
                GetPropertyByName("Active").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitLedBulbSmartTagActionList"/> is flash.
        /// </summary>
        /// <value><c>true</c> if flash; otherwise, <c>false</c>.</value>
        public bool Flash
        {
            get
            {
                return colUserControl.Flash;
            }
            set
            {
                GetPropertyByName("Flash").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get
            {
                return colUserControl.BorderWidth;
            }
            set
            {
                GetPropertyByName("BorderWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return colUserControl.BorderColor;
            }
            set
            {
                GetPropertyByName("BorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the shinny on.
        /// </summary>
        /// <value>The shinny on.</value>
        public Color ShinnyOn
        {
            get
            {
                return colUserControl.ShinnyOn;
            }
            set
            {
                GetPropertyByName("ShinnyOn").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the shinny off.
        /// </summary>
        /// <value>The shinny off.</value>
        public Color ShinnyOff
        {
            get
            {
                return colUserControl.ShinnyOff;
            }
            set
            {
                GetPropertyByName("ShinnyOff").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color on.
        /// </summary>
        /// <value>The color on.</value>
        public Color ColorOn
        {
            get
            {
                return colUserControl.ColorOn;
            }
            set
            {
                GetPropertyByName("ColorOn").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color off.
        /// </summary>
        /// <value>The color off.</value>
        public Color ColorOff
        {
            get
            {
                return colUserControl.ColorOff;
            }
            set
            {
                GetPropertyByName("ColorOff").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the flash speed.
        /// </summary>
        /// <value>The flash speed.</value>
        public string FlashSpeed
        {
            get
            {
                return colUserControl.FlashSpeed;
            }
            set
            {
                GetPropertyByName("FlashSpeed").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the flash colors.
        /// </summary>
        /// <value>The flash colors.</value>
        public string FlashColors
        {
            get
            {
                return colUserControl.FlashColors;
            }
            set
            {
                GetPropertyByName("FlashColors").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Active",
                                 "Active", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Flash",
                                 "Flash", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("ShinnyOn",
                                 "Shinny On", "Appearance",
                                 "Sets the shinny color when on."));

            items.Add(new DesignerActionPropertyItem("ShinnyOff",
                                 "Shinny Off", "Appearance",
                                 "Sets the shinny color when off."));

            items.Add(new DesignerActionPropertyItem("ColorOn",
                                 "Color On", "Appearance",
                                 "Sets the color when on."));

            items.Add(new DesignerActionPropertyItem("ColorOff",
                                 "Color Off", "Appearance",
                                 "Sets the color when off."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("BorderWidth",
                                 "Border Width", "Appearance",
                                 "Sets the border width."));

            items.Add(new DesignerActionPropertyItem("FlashSpeed",
                                 "Flash Speed", "Appearance",
                                 "Sets the flash speed."));


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

    #endregion

}
