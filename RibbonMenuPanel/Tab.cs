// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{

    /// <summary>
    /// Tab is a specialized ToolStripButton with extra padding
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolStripButton" />
    [System.ComponentModel.DesignerCategory("code")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.None)] // turn off the ability to add this in the DT, the TabPageSwitcher designer will provide this.
    public class Tab : ToolStripButton {

        /// <summary>
        /// The tab strip page
        /// </summary>
        private ZeroitTabStripPage tabStripPage;

        /// <summary>
        /// The b on
        /// </summary>
        public bool b_on = false;
        /// <summary>
        /// The b selected
        /// </summary>
        public bool b_selected = false;
        /// <summary>
        /// The b active
        /// </summary>
        public bool b_active = false;
        /// <summary>
        /// The b fading
        /// </summary>
        public bool b_fading = true;
        /// <summary>
        /// The o opacity
        /// </summary>
        public int o_opacity = 180;
        /// <summary>
        /// The e opacity
        /// </summary>
        public int e_opacity = 40;
        /// <summary>
        /// The i opacity
        /// </summary>
        public int i_opacity;
        /// <summary>
        /// The timer
        /// </summary>
        private Timer timer = new Timer();

        /// <summary>
        /// Constructor for tab - support all overloads.
        /// </summary>
        public Tab() {
            Initialize();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Tab"/> class.
        /// </summary>
        /// <param name="text">The text to display on the <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        public Tab(string text):base(text,null,null) {
            Initialize();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Tab"/> class.
        /// </summary>
        /// <param name="image">The image to display on the <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        public Tab(Image image):base(null,image,null) {
            Initialize();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Tab"/> class.
        /// </summary>
        /// <param name="text">The text to display on the <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        /// <param name="image">The image to display on the <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        public Tab(string text, Image image):base(text,image,null) {
            Initialize();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Tab"/> class.
        /// </summary>
        /// <param name="text">The text to display on the <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        /// <param name="image">The image to display on the <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        /// <param name="onClick">An event handler that raises the <see cref="E:System.Windows.Forms.ToolStripItem.Click" /> event.</param>
        public Tab(string text, Image image, EventHandler onClick):base(text,image,onClick) {
            Initialize();            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Tab"/> class.
        /// </summary>
        /// <param name="text">The text to display on the <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        /// <param name="image">The image to display on the <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        /// <param name="onClick">An event handler that raises the <see cref="E:System.Windows.Forms.ToolStripItem.Click" /> event.</param>
        /// <param name="name">The name of the <see cref="T:System.Windows.Forms.ToolStripButton" />.</param>
        public Tab(string text, Image image, EventHandler onClick, string name):base(text,image,onClick,name) {
            Initialize();
        }

        /// <summary>
        /// Common initialization code between all CTORs.
        /// </summary>
        private void Initialize() {
            this.AutoSize = false;
            this.Width = 60;
            CheckOnClick = true;  // Tab will use the "checked" property in order to represent the "selected tab".
            this.ForeColor = Color.FromArgb(44, 90, 154);
            this.Font = new Font("Segoe UI", 9);
            this.Margin = new Padding(6, this.Margin.Top, this.Margin.Right, this.Margin.Bottom);
            i_opacity = o_opacity;
            timer.Interval = 1;
            timer.Tick += new EventHandler(timer_Tick);
        }

        /// <summary>
        /// Hide the CheckOnClick from the Property Grid so that we can use it for our own purposes.
        /// </summary>
        /// <value><c>true</c> if [check on click]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public new bool CheckOnClick {
            get { return base.CheckOnClick; }
            set { base.CheckOnClick = value; }
        }

        /// <summary>
        /// Specify the default display style to be ImageAndText
        /// </summary>
        /// <value>The default display style.</value>
        protected override ToolStripItemDisplayStyle DefaultDisplayStyle {
            get {
                return ToolStripItemDisplayStyle.ImageAndText;
            }
        }

        /// <summary>
        /// Add extra internal spacing so we have enough room for our curve.
        /// </summary>
        /// <value>The default padding.</value>
        protected override Padding DefaultPadding {
            get {
                return new Padding(35, 0, 6, 0);
            }
        }

        /// <summary>
        /// The associated TabStripPage - when Tab is clicked, this TabPage will be selected.
        /// </summary>
        /// <value>The tab strip page.</value>
        [DefaultValue("null")]
        public ZeroitTabStripPage TabStripPage {
            get {
                return tabStripPage;
            }
            set {
                tabStripPage = value;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripItem.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            b_on = true; b_fading = true; b_selected = true;
            timer.Start();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripItem.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {            
            b_on = false; b_fading = true; 
            timer.Start();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Gets or sets the text that is to be displayed on the item.
        /// </summary>
        /// <value>The text.</value>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;

                Bitmap bmpdummy = new Bitmap(100,100);
                Graphics g = Graphics.FromImage(bmpdummy);
                float textwidth = g.MeasureString(this.Text, this.Font).Width;
                this.Width = Convert.ToInt16(textwidth) + 26;
            }
        }


        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (b_on)
            {
                if (i_opacity > e_opacity)
                {
                    i_opacity -= 20;
                    this.Invalidate();
                }
                else
                {
                    i_opacity = e_opacity;
                    this.Invalidate();
                    timer.Stop();
                }
            }
            if (!b_on)
            {
                if (i_opacity < o_opacity)
                {
                    i_opacity += 8;
                    this.Invalidate();
                }
                else
                {
                    i_opacity = o_opacity;
                    b_fading = false;
                    this.Invalidate();
                    b_selected = false;
                    timer.Stop();
                }

            }
        }
      
    }
}
