// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="RatingStar.cs" company="Zeroit Dev Technologies">
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
    #region Rating Star

    #region Control

    /// <summary>
    /// Enum representing Icon Style
    /// </summary>
    public enum IconStyle
    {
        /// <summary>
        /// The star
        /// </summary>
        Star,
        /// <summary>
        /// The heart
        /// </summary>
        Heart,
        /// <summary>
        /// The misc
        /// </summary>
        Misc
    }

    /// <summary>
    /// Delegate OnRateChanged
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="RatingBarRateEventArgs"/> instance containing the event data.</param>
    public delegate void OnRateChanged(object sender, RatingBarRateEventArgs e);

    /// <summary>
    /// A class collection for rendering a rate control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("RateChanged")]
    [Designer(typeof(ZeroitRateDesigner))]
    public class ZeroitRate : Control
    {
        /// <summary>
        /// Occurs when [rate changed].
        /// </summary>
        public event OnRateChanged RateChanged;

        /// <summary>
        /// The gap
        /// </summary>
        byte gap = 1;
        /// <summary>
        /// The icons count
        /// </summary>
        byte iconsCount = 10;
        /// <summary>
        /// The rate
        /// </summary>
        float rate = 0;
        /// <summary>
        /// The temporary rate holder
        /// </summary>
        float tempRateHolder = 0;
        /// <summary>
        /// The read only
        /// </summary>
        bool readOnly = false;
        /// <summary>
        /// The rate once
        /// </summary>
        bool rateOnce = false;
        /// <summary>
        /// The is voted
        /// </summary>
        bool isVoted = false;

        /// <summary>
        /// The alignment
        /// </summary>
        System.Drawing.ContentAlignment alignment = System.Drawing.ContentAlignment.MiddleCenter;
        /// <summary>
        /// The icon empty
        /// </summary>
        Image iconEmpty;
        /// <summary>
        /// The icon half
        /// </summary>
        Image iconHalf;
        /// <summary>
        /// The icon full
        /// </summary>
        Image iconFull;
        /// <summary>
        /// The icon style
        /// </summary>
        IconStyle iconStyle = IconStyle.Star;
        /// <summary>
        /// The pb
        /// </summary>
        PictureBox pb;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRate" /> class.
        /// </summary>
        public ZeroitRate()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            pb = new PictureBox();
            pb.BackgroundImageLayout = ImageLayout.None;
            pb.MouseMove += new MouseEventHandler(pb_MouseMove);
            pb.MouseLeave += new EventHandler(pb_MouseLeave);
            pb.MouseClick += new MouseEventHandler(pb_MouseClick);
            pb.Cursor = Cursors.Hand;
            this.Controls.Add(pb);
            UpdateIcons();
            UpdateBarSize();
            #region --- Drawing Empty Icons ---
            Bitmap tb = new Bitmap(pb.Width, pb.Height);
            Graphics g = Graphics.FromImage(tb);
            DrawEmptyIcons(g, 0, iconsCount);
            g.Dispose();
            pb.BackgroundImage = tb;
            #endregion
        }

        #region --- Mouse Events ---
        /// <summary>
        /// Handles the MouseMove event of the pb control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (readOnly || (rateOnce && isVoted))
                return;
            Bitmap tb = new Bitmap(pb.Width, pb.Height);
            Graphics g = Graphics.FromImage(tb);
            int x = 0;
            float trate = 0;
            byte ticonsCount = iconsCount; // temporary variable to hold the iconsCount value, because we're decreasing it on each loop
            for (int a = 0; a < iconsCount; a++)
            {
                if (e.X > x && e.X <= x + iconEmpty.Width / 2)
                {
                    g.DrawImage(iconHalf, x, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                    x += gap + iconEmpty.Width;
                    trate += 0.5f;
                }
                else if (e.X > x)
                {
                    g.DrawImage(iconFull, x, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                    x += gap + iconEmpty.Width;
                    trate += 1.0f;
                }
                else
                    break;
                ticonsCount--;
            }
            tempRateHolder = trate;
            DrawEmptyIcons(g, x, ticonsCount);
            g.Dispose();
            pb.BackgroundImage = tb;

        }
        /// <summary>
        /// Handles the MouseLeave event of the pb control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void pb_MouseLeave(object sender, EventArgs e)
        {
            if (readOnly || (rateOnce && isVoted))
                return;
            Bitmap tb = new Bitmap(pb.Width, pb.Height);
            Graphics g = Graphics.FromImage(tb);
            int x = 0;
            byte ticonsCount = iconsCount;
            float trate = rate;
            while (trate > 0)
            {
                if (trate > 0.5f)
                {
                    g.DrawImage(iconFull, x, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                    x += gap + iconEmpty.Width;
                }
                else if (trate == 0.5f)
                {
                    g.DrawImage(iconHalf, x, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                    x += gap + iconEmpty.Width;
                }
                else
                    break;
                ticonsCount--;
                trate--;
            }
            DrawEmptyIcons(g, x, ticonsCount);

            g.Dispose();
            pb.BackgroundImage = tb;
        }
        /// <summary>
        /// Handles the MouseClick event of the pb control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void pb_MouseClick(object sender, MouseEventArgs e)
        {
            float toldRate = rate;
            rate = tempRateHolder;
            isVoted = true;
            if (rateOnce)
                pb.Cursor = Cursors.Default;
            OnRateChanged(new RatingBarRateEventArgs(rate, toldRate));
        }
        #endregion
        #region --- Override Functions ---
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            UpdateBarLocation();
            base.OnResize(e);
        }
        #endregion
        #region --- Custom Functions ---
        /// <summary>
        /// Draws the icons.
        /// </summary>
        void DrawIcons()
        {
            Bitmap tb = new Bitmap(pb.Width, pb.Height);
            Graphics g = Graphics.FromImage(tb);
            int x = 0;
            byte ticonsCount = iconsCount;
            float trate = rate;
            while (trate > 0)
            {
                if (trate > 0.5f)
                {
                    g.DrawImage(iconFull, x, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                    x += gap + iconEmpty.Width;
                }
                else if (trate == 0.5f)
                {
                    g.DrawImage(iconHalf, x, 0, iconEmpty.Width, iconEmpty.Height); // Draw icons with the dimension of iconEmpty, so that they do not look odd
                    x += gap + iconEmpty.Width;
                }
                else
                    break;
                ticonsCount--;
                trate--;
            }
            DrawEmptyIcons(g, x, ticonsCount);

            g.Dispose();
            pb.BackgroundImage = tb;
        }
        /// <summary>
        /// Draws the empty icons.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="x">The x.</param>
        /// <param name="count">The count.</param>
        void DrawEmptyIcons(Graphics g, int x, byte count)
        {
            for (byte a = 0; a < count; a++)
            {
                g.DrawImage(iconEmpty, x, 0);
                x += gap + iconEmpty.Width;
            }
        }
        /// <summary>
        /// Updates the size of the bar.
        /// </summary>
        void UpdateBarSize()
        {
            pb.Size = new Size((iconEmpty.Width * iconsCount) + (gap * (iconsCount - 1)), iconEmpty.Height); // Last icon wont need gap, therefore we need to use -1
            UpdateBarLocation();
        }
        /// <summary>
        /// Updates the bar location.
        /// </summary>
        void UpdateBarLocation()
        {
            if (alignment == System.Drawing.ContentAlignment.TopLeft) { }// Leave it blank, Since we're calling this from Resize Event then we dont need to set same point again and again
            else if (alignment == System.Drawing.ContentAlignment.TopRight)
                pb.Location = new Point(this.Width - pb.Width, 0);
            else if (alignment == System.Drawing.ContentAlignment.TopCenter)
                pb.Location = new Point(this.Width / 2 - pb.Width / 2, 0);
            else if (alignment == System.Drawing.ContentAlignment.BottomLeft)
                pb.Location = new Point(0, this.Height - pb.Height);
            else if (alignment == System.Drawing.ContentAlignment.BottomRight)
                pb.Location = new Point(this.Width - pb.Width, this.Height - pb.Height);
            else if (alignment == System.Drawing.ContentAlignment.BottomCenter)
                pb.Location = new Point(this.Width / 2 - pb.Width / 2, this.Height - pb.Height);
            else if (alignment == System.Drawing.ContentAlignment.MiddleLeft)
                pb.Location = new Point(0, this.Height / 2 - pb.Height / 2);
            else if (alignment == System.Drawing.ContentAlignment.MiddleRight)
                pb.Location = new Point(this.Width - pb.Width, this.Height / 2 - pb.Height / 2);
            else if (alignment == System.Drawing.ContentAlignment.MiddleCenter)
                pb.Location = new Point(this.Width / 2 - pb.Width / 2, this.Height / 2 - pb.Height / 2);
        }
        /// <summary>
        /// Updates the icons.
        /// </summary>
        void UpdateIcons()
        {
            if (iconStyle == IconStyle.Star)
            {
                iconEmpty = Properties.Resources.iconStarEmpty;
                iconFull = Properties.Resources.iconStarFull;
                iconHalf = Properties.Resources.iconStartHalf;


            }
            else if (iconStyle == IconStyle.Heart)
            {
                iconEmpty = Properties.Resources.iconHeartEmpty;
                iconFull = Properties.Resources.iconHeartFull;
                iconHalf = Properties.Resources.iconHeartHalf;


            }
            else if (iconStyle == IconStyle.Misc)
            {
                iconEmpty = Properties.Resources.iconMiscEmpty;
                iconFull = Properties.Resources.iconMiscFull;
                iconHalf = Properties.Resources.iconMiscHalf;


            }


        }
        #endregion
        #region --- Virtual Functions ---
        /// <summary>
        /// Handles the <see cref="E:RateChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="RatingBarRateEventArgs"/> instance containing the event data.</param>
        protected virtual void OnRateChanged(RatingBarRateEventArgs e)
        {
            if (RateChanged != null && e.NewRate != e.OldRate)
                RateChanged(this, e);
        }
        #endregion
        #region --- Properties ---        
        /// <summary>
        /// Gets or sets the gap.
        /// </summary>
        /// <value>The gap.</value>
        public byte Gap
        {
            get { return gap; }
            set { gap = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the icons count.
        /// </summary>
        /// <value>The icons count.</value>
        public byte IconsCount
        {
            get { return iconsCount; }
            set { if (value <= 10) { iconsCount = value; UpdateBarSize(); } Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the alignment.
        /// </summary>
        /// <value>The alignment.</value>
        [DefaultValue(typeof(System.Drawing.ContentAlignment), "middlecenter")]
        public System.Drawing.ContentAlignment Alignment
        {
            get { return alignment; }
            set
            {
                alignment = value;
                if (value == System.Drawing.ContentAlignment.TopLeft)
                    pb.Location = new Point(0, 0);
                else UpdateBarLocation();

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the icon empty.
        /// </summary>
        /// <value>The icon empty.</value>
        public Image IconEmpty
        {
            get { return iconEmpty; }
            set { iconEmpty = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the icon half.
        /// </summary>
        /// <value>The icon half.</value>
        public Image IconHalf
        {
            get { return iconHalf; }
            set { iconHalf = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the icon full.
        /// </summary>
        /// <value>The icon full.</value>
        public Image IconFull
        {
            get { return iconFull; }
            set { iconFull = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to be read only].
        /// </summary>
        /// <value><c>true</c> if read only; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; if (value) pb.Cursor = Cursors.Default; else pb.Cursor = Cursors.Hand; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to rate once.
        /// </summary>
        /// <value><c>true</c> if rate once; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool RateOnce
        {
            get { return rateOnce; }
            set { rateOnce = value; if (!value) pb.Cursor = Cursors.Hand; Invalidate(); /* Set hand cursor, if false is set from true*/ }
        }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Rate - Value '" + value + "' is not valid for 'Rate'. Value must be Non-negative and less than or equals to '" + iconsCount + "'</exception>
        /// <exception cref="ArgumentOutOfRangeException">Rate - Value '" + value + "' is not valid for 'Rate'. Value must be Non-negative and less than or equals to '" + iconsCount + "'</exception>
        [Browsable(false)]
        public float Rate
        {
            get { return rate; }
            set
            {
                if (value >= 0 && value <= (float)iconsCount)
                {
                    float toldRate = rate;
                    rate = value;
                    DrawIcons();
                    OnRateChanged(new RatingBarRateEventArgs(value, toldRate));
                }
                else
                    throw new ArgumentOutOfRangeException("Rate", "Value '" + value + "' is not valid for 'Rate'. Value must be Non-negative and less than or equals to '" + iconsCount + "'");

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the bar background.
        /// </summary>
        /// <value>The color of the bar background.</value>
        public Color BarBackColor
        {
            get { return pb.BackColor; }
            set { pb.BackColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the icon style.
        /// </summary>
        /// <value>The icon style.</value>
        [DefaultValue(typeof(IconStyle), "star")]
        public IconStyle IconStyle
        {
            get { return iconStyle; }
            set { iconStyle = value; UpdateIcons(); Invalidate(); }
        }

        #endregion
    }
    /// <summary>
    /// Class RatingBarRateEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class RatingBarRateEventArgs : EventArgs
    {
        /// <summary>
        /// The new rate
        /// </summary>
        public float NewRate;
        /// <summary>
        /// The old rate
        /// </summary>
        public float OldRate;
        /// <summary>
        /// Initializes a new instance of the <see cref="RatingBarRateEventArgs"/> class.
        /// </summary>
        /// <param name="newRate">The new rate.</param>
        /// <param name="oldRate">The old rate.</param>
        public RatingBarRateEventArgs(float newRate, float oldRate)
        {
            NewRate = newRate;
            OldRate = oldRate;
        }
    }



    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitRateDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitRateDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitRateDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitRateSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitRateSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitRateSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitRate colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRateSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitRateSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitRate;

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

        #region --- Properties ---
        /// <summary>
        /// Gets or sets the gap.
        /// </summary>
        /// <value>The gap.</value>
        public byte Gap
        {
            get
            {
                return colUserControl.Gap;
            }
            set
            {
                GetPropertyByName("Gap").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the icons count.
        /// </summary>
        /// <value>The icons count.</value>
        public byte IconsCount
        {
            get
            {
                return colUserControl.IconsCount;
            }
            set
            {
                GetPropertyByName("IconsCount").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the alignment.
        /// </summary>
        /// <value>The alignment.</value>
        public System.Drawing.ContentAlignment Alignment
        {
            get
            {
                return colUserControl.Alignment;
            }
            set
            {
                GetPropertyByName("Alignment").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the icon empty.
        /// </summary>
        /// <value>The icon empty.</value>
        public Image IconEmpty
        {
            get
            {
                return colUserControl.IconEmpty;
            }
            set
            {
                GetPropertyByName("IconEmpty").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the icon half.
        /// </summary>
        /// <value>The icon half.</value>
        public Image IconHalf
        {
            get
            {
                return colUserControl.IconHalf;
            }
            set
            {
                GetPropertyByName("IconHalf").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the icon full.
        /// </summary>
        /// <value>The icon full.</value>
        public Image IconFull
        {
            get
            {
                return colUserControl.IconFull;
            }
            set
            {
                GetPropertyByName("IconFull").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [read only].
        /// </summary>
        /// <value><c>true</c> if [read only]; otherwise, <c>false</c>.</value>
        public bool ReadOnly
        {
            get
            {
                return colUserControl.ReadOnly;
            }
            set
            {
                GetPropertyByName("ReadOnly").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [rate once].
        /// </summary>
        /// <value><c>true</c> if [rate once]; otherwise, <c>false</c>.</value>
        public bool RateOnce
        {
            get
            {
                return colUserControl.RateOnce;
            }
            set
            {
                GetPropertyByName("RateOnce").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        public float Rate
        {
            get
            {
                return colUserControl.Rate;
            }
            set
            {
                GetPropertyByName("Rate").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the bar back.
        /// </summary>
        /// <value>The color of the bar back.</value>
        public Color BarBackColor
        {
            get
            {
                return colUserControl.BarBackColor;
            }
            set
            {
                GetPropertyByName("BarBackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the icon style.
        /// </summary>
        /// <value>The icon style.</value>
        public IconStyle IconStyle
        {
            get
            {
                return colUserControl.IconStyle;
            }
            set
            {
                GetPropertyByName("IconStyle").SetValue(colUserControl, value);
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


            items.Add(new DesignerActionPropertyItem("ReadOnly",
                                 "Read Only", "Appearance",
                                 "Set to enable read only mode."));

            items.Add(new DesignerActionPropertyItem("RateOnce",
                                 "Rate Once", "Appearance",
                                 "Set to enable rate frequency."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("Gap",
                                 "Gap", "Appearance",
                                 "Sets the gap."));

            items.Add(new DesignerActionPropertyItem("IconsCount",
                                 "Icons Count", "Appearance",
                                 "Sets the number of icons."));

            items.Add(new DesignerActionPropertyItem("Alignment",
                                 "Alignment", "Appearance",
                                 "Sets the alignment."));

            items.Add(new DesignerActionPropertyItem("IconEmpty",
                                 "Icon Empty", "Appearance",
                                 "Sets the icon."));

            items.Add(new DesignerActionPropertyItem("IconHalf",
                                 "Icon Half", "Appearance",
                                 "Sets the icon."));

            items.Add(new DesignerActionPropertyItem("IconFull",
                                 "Icon Full", "Appearance",
                                 "Sets the icon."));

            items.Add(new DesignerActionPropertyItem("Rate",
                                 "Rate", "Appearance",
                                 "Sets the rate level."));

            items.Add(new DesignerActionPropertyItem("BarBackColor",
                                 "Bar BackColor", "Appearance",
                                 "Sets the bar back color."));

            items.Add(new DesignerActionPropertyItem("IconStyle",
                                 "Icon Style", "Appearance",
                                 "Sets the icon style."));


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
