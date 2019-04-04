// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ZeroitGradientPanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    #region Gradient Panel

    #region Control    
    /// <summary>
    /// A class collection for rendering a gradient panel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [Designer(typeof(ZeroitGradientPanelDesigner))]
    public partial class ZeroitGradientPanel : System.Windows.Forms.Panel
    {

        #region Private Fields
        // member variables
        /// <summary>
        /// The m start color
        /// </summary>
        System.Drawing.Color mStartColor = Color.DarkSlateGray;
        /// <summary>
        /// The m end color
        /// </summary>
        System.Drawing.Color mEndColor = Color.SaddleBrown;

        /// <summary>
        /// The gradient angle
        /// </summary>
        private float gradientAngle = 90f;
        /// <summary>
        /// The alpha
        /// </summary>
        private int alpha = 100;

        /// <summary>
        /// The alpha blend
        /// </summary>
        private bool alphaBlend = false;


        #endregion

        #region Timer Utility

        #region Include in Private Field


        /// <summary>
        /// The automatic animate
        /// </summary>
        private bool autoAnimate = true;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        /// <summary>
        /// The interval
        /// </summary>
        private int interval = 100;

        #endregion

        #region Event

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.GradientAngle + 1 > 360)
            {
                this.GradientAngle = 0;
            }

            else
            {
                this.GradientAngle++;
            }

            if (Alpha + 1 > 255)
            {
                Alpha = 0;
            }

            else
            {
                Alpha++;
            }

        }

        #endregion

        #endregion

        #region Public Properties

        #region Include in Public Properties        
        /// <summary>
        /// Gets or sets a value indicating whether to automatically animate.
        /// </summary>
        /// <value><c>true</c> if automatic animate; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get { return autoAnimate; }
            set
            {
                autoAnimate = value;

                if (value == true)
                {
                    timer.Enabled = true;
                }

                else
                {
                    timer.Enabled = false;
                }

                PaintGradient();
            }
        }

        /// <summary>
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        public int TimerInterval
        {
            get { return interval; }
            set
            {
                interval = value;
                PaintGradient();
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets a value indicating whether enable alpha blend.
        /// </summary>
        /// <value><c>true</c> if [alpha blend]; otherwise, <c>false</c>.</value>
        public bool AlphaBlend
        {
            get { return alphaBlend; }
            set
            {
                alphaBlend = value;
                PaintGradient();
            }
        }

        /// <summary>
        /// Gets or sets the alpha.
        /// </summary>
        /// <value>The alpha.</value>
        public int Alpha
        {
            get { return alpha; }
            set
            {
                alpha = value;
                PaintGradient();
            }
        }

        /// <summary>
        /// Gets or sets the gradient angle.
        /// </summary>
        /// <value>The gradient angle.</value>
        public float GradientAngle
        {
            get { return gradientAngle; }
            set
            {
                gradientAngle = value;
                PaintGradient();
            }
        }

        /// <summary>
        /// Gets or sets the start color of the page.
        /// </summary>
        /// <value>The start color of the page.</value>
        public System.Drawing.Color PageStartColor
        {
            get
            {
                return mStartColor;
            }
            set
            {
                mStartColor = value;
                PaintGradient();
            }
        }

        /// <summary>
        /// Gets or sets the end color of the page.
        /// </summary>
        /// <value>The end color of the page.</value>
        public System.Drawing.Color PageEndColor
        {
            get
            {
                return mEndColor;
            }
            set
            {
                mEndColor = value;
                PaintGradient();
            }
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGradientPanel" /> class.
        /// </summary>
        public ZeroitGradientPanel()
        {


            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();
            PaintGradient();

            #region MyRegion
            if (DesignMode)
            {
                timer.Tick += Timer_Tick;
                if (AutoAnimate)
                {
                    //timer.Interval = 100;
                    timer.Start();
                }
            }

            if (!DesignMode)
            {
                timer.Tick += Timer_Tick;

                if (AutoAnimate)
                {
                    //timer.Interval = 100;
                    timer.Start();
                }
            }

            #endregion
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="pe">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: Add custom paint code here

            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Paints the gradient.
        /// </summary>
        private void PaintGradient()
        {
            timer.Interval = interval;
            System.Drawing.Drawing2D.LinearGradientBrush gradBrush;
            //gradBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0),
            //new Point(this.Width, this.Height), PageStartColor, PageEndColor);

            if (alphaBlend)
            {
                gradBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(alpha, PageStartColor), Color.FromArgb(alpha, PageEndColor), gradientAngle);

            }
            else
            {
                gradBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, Width, Height), PageStartColor, PageEndColor, gradientAngle);

            }

            Bitmap bmp = new Bitmap(this.Width, this.Height);

            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(gradBrush, new Rectangle(0, 0, this.Width, this.Height));
            this.BackgroundImage = bmp;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        #endregion


    }
    #endregion


    #region Designer Generated Code

    partial class ZeroitGradientPanel
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
            // 
            // GradientPanel
            // 
            this.ResumeLayout(false);

        }

        #endregion
    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitGradientPanelDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitGradientPanelDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitGradientPanelDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitGradientPanelSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitGradientPanelSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitGradientPanelSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitGradientPanel colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGradientPanelSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitGradientPanelSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitGradientPanel;

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

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [automatic animate].
        /// </summary>
        /// <value><c>true</c> if [automatic animate]; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get
            {
                return colUserControl.AutoAnimate;
            }
            set
            {
                GetPropertyByName("AutoAnimate").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        public int TimerInterval
        {
            get
            {
                return colUserControl.TimerInterval;
            }
            set
            {
                GetPropertyByName("TimerInterval").SetValue(colUserControl, value);
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets a value indicating whether [alpha blend].
        /// </summary>
        /// <value><c>true</c> if [alpha blend]; otherwise, <c>false</c>.</value>
        public bool AlphaBlend
        {
            get
            {
                return colUserControl.AlphaBlend;
            }
            set
            {
                GetPropertyByName("AlphaBlend").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the alpha.
        /// </summary>
        /// <value>The alpha.</value>
        public int Alpha
        {
            get
            {
                return colUserControl.Alpha;
            }
            set
            {
                GetPropertyByName("Alpha").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient angle.
        /// </summary>
        /// <value>The gradient angle.</value>
        public float GradientAngle
        {
            get
            {
                return colUserControl.GradientAngle;
            }
            set
            {
                GetPropertyByName("GradientAngle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the start color of the page.
        /// </summary>
        /// <value>The start color of the page.</value>
        public System.Drawing.Color PageStartColor
        {
            get
            {
                return colUserControl.PageStartColor;
            }
            set
            {
                GetPropertyByName("PageStartColor").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Gets or sets the end color of the page.
        /// </summary>
        /// <value>The end color of the page.</value>
        public System.Drawing.Color PageEndColor
        {
            get
            {
                return colUserControl.PageEndColor;
            }
            set
            {
                GetPropertyByName("PageEndColor").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("AutoAnimate",
                                 "Auto Animate", "Appearance",
                                 "Set to automatically animate the control."));

            items.Add(new DesignerActionPropertyItem("AlphaBlend",
                                 "Alpha Blend", "Appearance",
                                 "Set to enable alpha blend."));

            items.Add(new DesignerActionPropertyItem("TimerInterval",
                                 "Timer Interval", "Appearance",
                                 "Sets the speed of the animation."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("Alpha",
                                 "Alpha", "Appearance",
                                 "Sets the alpha of the color."));

            items.Add(new DesignerActionPropertyItem("GradientAngle",
                                 "Gradient Angle", "Appearance",
                                 "Sets the gradient angle."));

            items.Add(new DesignerActionPropertyItem("PageStartColor",
                                 "Page Start Color", "Appearance",
                                 "Sets the start color."));

            items.Add(new DesignerActionPropertyItem("PageEndColor",
                                 "Page End Color", "Appearance",
                                 "Sets the end color."));

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
