// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="HorizontalTab.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitHorizontalTab.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("TabChanged")]
    [Designer(typeof(ZeroitHorizontalTabDesigner))]
    public class ZeroitHorizontalTab : Control
	{
        #region Enum

        /// <summary>
        /// Enum representing the Style
        /// </summary>
        public enum Style
	    {
            /// <summary>
            /// The iOS
            /// </summary>
            iOS,
            /// <summary>
            /// The android
            /// </summary>
            Android,
            /// <summary>
            /// The material
            /// </summary>
            Material
        }


        #endregion

        #region Private Fields
        //private string items = "Contacts, Recents, Messages, Dialer";

        /// <summary>
        /// The selected index
        /// </summary>
        private int selectedIndex = 0;

        /// <summary>
        /// The segment style
        /// </summary>
        private ZeroitHorizontalTab.Style segmentStyle = ZeroitHorizontalTab.Style.Material;

        /// <summary>
        /// The fit width
        /// </summary>
        private bool fitWidth = false;

        /// <summary>
        /// The parent width
        /// </summary>
        private int parentWidth = 330;

        /// <summary>
        /// The tabs
        /// </summary>
        private string tabs = "";

        /// <summary>
        /// The source
        /// </summary>
        private string[] source = new string[]
        {
            "Addition",
            "Condemn",
            "Dissapoint",
            "Excuse"
        };

        /// <summary>
        /// The destination
        /// </summary>
        private string[] destination = new string[] { };

        /// <summary>
        /// The android colors
        /// </summary>
        private AndroidColors androidColors = new AndroidColors();
        /// <summary>
        /// The material colors
        /// </summary>
        private MaterialColors materialColors = new MaterialColors();
        /// <summary>
        /// The i os colors
        /// </summary>
        private iOSColors iOSColors = new iOSColors();
        /// <summary>
        /// The show bar
        /// </summary>
        private bool showBar = true;

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the tab pages.
        /// </summary>
        /// <value>The tab pages.</value>
        public string[] TabPages
        {
            get { return source; }
            set
            {

                foreach (string x in source)
                {
                    string[] temp = new string[destination.Length + 1];
                    destination.CopyTo(temp, 0);

                    temp[temp.Length - 1] = x;
                    destination = temp;
                }

                source = value;
                Invalidate();
            }
        }


        //[Browsable(true)]
        //[Category("Zeroit.Framework.DaggerControls")]
        //[Description("The items, split by ','.")]
        ////[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        //[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        //private string Items
        //{
        //	get
        //	{
        //		return this.items;
        //	}
        //	set
        //	{

        //      this.items = value;
        //		base.Invalidate();
        //	}
        //}

        /// <summary>
        /// Gets or sets the tabs.
        /// </summary>
        /// <value>The tabs.</value>
        [Browsable(false)]
        public string Tabs
        {
            get { return tabs; }
            set
            {
                tabs = value;

                //this.OnTabChanged(EventArgs.Empty);
                Invalidate();

            }
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        public override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;

        }

        /// <summary>
        /// Gets or sets the segment style.
        /// </summary>
        /// <value>The segment style.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("The segment style")]
        public ZeroitHorizontalTab.Style SegmentStyle
        {
            get
            {
                return this.segmentStyle;
            }
            set
            {
                this.segmentStyle = value;
                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the selected index.
        /// </summary>
        /// <value>The selected index.</value>
        [Browsable(true)]
        [Category("Zeroit.Framework.DaggerControls")]
        [Description("The selected index")]
        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }
            set
            {
                this.selectedIndex = value;

                this.OnTabChanged(EventArgs.Empty);
                this.OnIndexChanged();

                base.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [fit width].
        /// </summary>
        /// <value><c>true</c> if [fit width]; otherwise, <c>false</c>.</value>
        public bool FitWidth
        {
            get { return fitWidth; }
            set
            {
                if (value == true)
                {
                    try
                    {
                        Width = this.FindForm().Width;
                    }
                    catch (Exception e)
                    {

                    }

                    this.Location = new Point(0, this.Location.Y);
                }

                fitWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show bar].
        /// </summary>
        /// <value><c>true</c> if [show bar]; otherwise, <c>false</c>.</value>
        public bool ShowBar
        {
            get { return showBar; }
            set
            {
                showBar = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the colors android.
        /// </summary>
        /// <value>The colors android.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public AndroidColors ColorsAndroid
        {
            get { return androidColors; }
            set { androidColors = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the colors material.
        /// </summary>
        /// <value>The colors material.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public MaterialColors ColorsMaterial
        {
            get { return materialColors; }
            set { materialColors = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the colors ios.
        /// </summary>
        /// <value>The colors ios.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public iOSColors ColorsIOS
        {
            get { return iOSColors; }
            set { iOSColors = value; Invalidate(); }
        }

        //public int MaxTabs
        //{
        //    get { return maxTabs; }
        //    set
        //    {
        //        maxTabs = value;
        //        Invalidate();
        //    }
        //}

        //private int maxTabs = 6;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitHorizontalTab" /> class.
        /// </summary>
        public ZeroitHorizontalTab()
        {
            base.Size = new System.Drawing.Size(330, 30);
            this.Cursor = Cursors.Hand;

            //this.SegmentBackColor = BackColor;
        }
        #endregion

        #region Events and Overrides

        /// <summary>
        /// Occurs when [selected index changed].
        /// </summary>
        public event EventHandler SelectedIndexChanged;

        /// <summary>
        /// Called when [index changed].
        /// </summary>
        protected virtual void OnIndexChanged()
        {
            if (this.SelectedIndexChanged != null)
            {
                this.SelectedIndexChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int num = 0;
            int num1 = 0;
            string str = null;
            //string[] strArrays = this.items.Split(new char[] { ',' });

            string[] strArrays = source;


            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                str = strArrays[i];
                num1++;
            }

            int width = base.Width / num1;

            if (e.X > 0)
            {
                num = 0;
            }

            //for (int i = 0; i <= maxTabs; i++)
            //{
            //    if (e.X > width * i)
            //    {
            //        num = i;
            //    }
            //      }

            for (int i = 0; i <= source.Length; i++)
            {
                if (e.X > width * i)
                {
                    num = i;
                }
            }


            #region Old Code
            //if (e.X > width)
            //{
            //    num = 1;
            //}

            //if (e.X > width * 2)
            //{
            //    num = 2;
            //}

            //if (e.X > width * 3)
            //{
            //    num = 3;
            //}
            //if (e.X > width * 4)
            //{
            //    num = 4;
            //}
            //if (e.X > width * 5)
            //{
            //    num = 5;
            //}
            //if (e.X > width * 6)
            //{
            //    num = 6;
            //}
            //if (e.X > width * 7)
            //{
            //    num = 7;
            //}
            //if (e.X > width * 8)
            //{
            //    num = 8;
            //}
            //if (e.X > width * 9)
            //{
            //    num = 9;
            //}
            //if (e.X > width * 10)
            //{
            //    num = 10;
            //}

            //if (e.X > width * 11)
            //{
            //    num = 11;
            //}

            #endregion

            if (num != this.selectedIndex)
            {
                this.SelectedIndex = num;

                //MessageBox.Show(strArrays[SelectedIndex].ToString());

                Tabs = strArrays[SelectedIndex].ToString();

            }



        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.Clear(BackColor);

            int num = 0;
            //string[] strArrays = this.items.Split(new char[] { ',' });

            string[] strArrays = source;

            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                num++;
            }

            int width = base.Width / num;

            int num1 = 0;
            int num2 = 0;

            if (this.segmentStyle == ZeroitHorizontalTab.Style.iOS)
            {
                //string[] strArrays1 = this.items.Split(new char[] { ',' });

                string[] strArrays1 = source;


                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    string str1 = strArrays1[j];
                    if (num1 <= num)
                    {
                        Rectangle rectangle = new Rectangle(num2, 0, width, base.Height);
                        StringFormat stringFormat = new StringFormat()
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        };
                        e.Graphics.DrawRectangle(new Pen(ColorsIOS.BorderColors[0], 1f), 0, 0, base.Width - 1, base.Height - 1);
                        if (this.selectedIndex != num1)
                        {
                            e.Graphics.DrawRectangle(new Pen(ColorsIOS.BorderColors[0], 1f), num2, 0, num2 + width, base.Height - 1);
                            e.Graphics.DrawString(str1, this.Font, new SolidBrush(ColorsIOS.InactiveTextColor), rectangle, stringFormat);
                        }
                        else
                        {
                            e.Graphics.FillRectangle(new SolidBrush(ColorsIOS.SegmentColor), num2, 0, width, base.Height);
                            e.Graphics.DrawString(str1, this.Font, new SolidBrush(ColorsIOS.ActiveTextColor), rectangle, stringFormat);
                        }
                    }
                    num2 = num2 + width;
                    num1++;
                }
            }

            if (this.segmentStyle == ZeroitHorizontalTab.Style.Android)
            {
                e.Graphics.FillRectangle(new SolidBrush(BackColor), 0, 0, base.Width, base.Height);

                ///string[] strArrays2 = this.items.Split(new char[] { ',' });

                string[] strArrays2 = source;


                for (int k = 0; k < (int)strArrays2.Length; k++)
                {
                    string str2 = strArrays2[k];
                    if (num1 <= num)
                    {
                        Rectangle rectangle1 = new Rectangle(num2, 0, width, base.Height - 5);
                        StringFormat stringFormat1 = new StringFormat()
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        };
                        if (this.selectedIndex != num1)
                        {
                            e.Graphics.DrawString(str2, this.Font, new SolidBrush(ColorsAndroid.InactiveTextColor), rectangle1, stringFormat1);
                        }
                        else
                        {
                            if (ShowBar)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(ColorsAndroid.SegmentColor), num2, base.Height - 3, width, 3);

                            }
                            e.Graphics.DrawString(str2, this.Font, new SolidBrush(ColorsAndroid.ActiveTextColor), rectangle1, stringFormat1);
                        }
                    }
                    num2 = num2 + width;
                    num1++;
                }
            }

            if (this.segmentStyle == ZeroitHorizontalTab.Style.Material)
            {
                e.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, base.Width, base.Height);

                //string[] strArrays3 = this.items.Split(new char[] { ',' });

                string[] strArrays3 = source;


                for (int l = 0; l < (int)strArrays3.Length; l++)
                {
                    string str3 = strArrays3[l];

                    if (num1 <= num)
                    {
                        Rectangle rectangle2 = new Rectangle(num2, 0, width, base.Height - 5);
                        StringFormat stringFormat2 = new StringFormat()
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        };
                        if (this.selectedIndex != num1)
                        {
                            e.Graphics.DrawString(str3, this.Font, new SolidBrush(ColorsMaterial.InactiveTextColor), rectangle2, stringFormat2);
                        }
                        else
                        {
                            if (ShowBar)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(ColorsMaterial.SegmentColor), num2, base.Height - 3, width, 3);

                            }

                            e.Graphics.DrawString(str3, this.Font, new SolidBrush(ColorsMaterial.ActiveTextColor), rectangle2, stringFormat2);
                        }
                    }

                    num2 = num2 + width;

                    num1++;
                }
            }

        }


        /////Implement this in the Property you want to trigger the event///////////////////////////
        // 
        //  For Example this will be triggered by the Value Property
        //
        //  public int Value
        //   { 
        //      get { return _value;}
        //      set
        //         {
        //          
        //              _value = value;
        //
        //              this.OnTabChanged(EventArgs.Empty);
        //              Invalidate();
        //          }
        //    }
        //
        ////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// The tab changed
        /// </summary>
        private EventHandler tabChanged;

        /// <summary>
        /// Triggered when the Value changes
        /// </summary>
        public event EventHandler TabChanged
        {
            add
            {
                this.tabChanged = this.tabChanged + value;
            }
            remove
            {
                this.tabChanged = this.tabChanged - value;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:TabChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnTabChanged(EventArgs e)
        {
            if (this.tabChanged == null)
                return;
            this.tabChanged((object)this, e);
        }

        #endregion
        
    }

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitSegmentDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitHorizontalTabDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitHorizontalTabDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitHorizontalTabSmartTagActionList(this.Component));
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
            Properties.Remove("ForeColor");
            //Properties.Remove("ImageIndex");
            //Properties.Remove("ImageList");
        }
        #endregion

    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitHorizontalTabSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitHorizontalTabSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitHorizontalTab colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitHorizontalTabSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitHorizontalTabSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitHorizontalTab;

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
        /// Gets or sets the tab pages.
        /// </summary>
        /// <value>The tab pages.</value>
        public string[] TabPages
        {
            get
            {
                return colUserControl.TabPages;
            }
            set
            {
                GetPropertyByName("TabPages").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the tabs.
        /// </summary>
        /// <value>The tabs.</value>
        public string Tabs
        {
            get
            {
                return colUserControl.Tabs;
            }
            set
            {
                GetPropertyByName("Tabs").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the segment style.
        /// </summary>
        /// <value>The segment style.</value>
        public ZeroitHorizontalTab.Style SegmentStyle
        {
            get
            {
                return colUserControl.SegmentStyle;
            }
            set
            {
                GetPropertyByName("SegmentStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the index of the selected.
        /// </summary>
        /// <value>The index of the selected.</value>
        public int SelectedIndex
        {
            get
            {
                return colUserControl.SelectedIndex;
            }
            set
            {
                GetPropertyByName("SelectedIndex").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [fit width].
        /// </summary>
        /// <value><c>true</c> if [fit width]; otherwise, <c>false</c>.</value>
        public bool FitWidth
        {
            get
            {
                return colUserControl.FitWidth;
            }
            set
            {
                GetPropertyByName("FitWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show bar].
        /// </summary>
        /// <value><c>true</c> if [show bar]; otherwise, <c>false</c>.</value>
        public bool ShowBar
        {
            get
            {
                return colUserControl.ShowBar;
            }
            set
            {
                GetPropertyByName("ShowBar").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the colors android.
        /// </summary>
        /// <value>The colors android.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public AndroidColors ColorsAndroid
        {
            get
            {
                return colUserControl.ColorsAndroid;
            }
            set
            {
                GetPropertyByName("ColorsAndroid").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the colors material.
        /// </summary>
        /// <value>The colors material.</value>
        public MaterialColors ColorsMaterial
        {
            get
            {
                return colUserControl.ColorsMaterial;
            }
            set
            {
                GetPropertyByName("ColorsMaterial").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the colors ios.
        /// </summary>
        /// <value>The colors ios.</value>
        public iOSColors ColorsIOS
        {
            get
            {
                return colUserControl.ColorsIOS;
            }
            set
            {
                GetPropertyByName("ColorsIOS").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("FitWidth",
                "Fit Width", "Appearance",
                "This fits the horizontal tab to the width of the form."));

            items.Add(new DesignerActionPropertyItem("ShowBar",
                "Show Bar", "Appearance",
                "Set to show the hover bar."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Sets the background color."));

            items.Add(new DesignerActionPropertyItem("SegmentStyle",
                "Segment Style", "Appearance",
                "Sets the segment style."));

            items.Add(new DesignerActionPropertyItem("TabPages",
                "Tab Pages", "Appearance",
                "Sets the tab pages."));


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

    /// <summary>
    /// Class AndroidColors.
    /// </summary>
    public class AndroidColors
    {
        /// <summary>
        /// The segment color
        /// </summary>
        private Color segmentColor = Color.FromArgb(65, 130, 205);

        /// <summary>
        /// The segment active text color
        /// </summary>
        private Color segmentActiveTextColor = Color.FromArgb(65, 130, 205);

        /// <summary>
        /// The segment inactive text color
        /// </summary>
        private Color segmentInactiveTextColor = Color.FromArgb(153, 153, 153);

        /// <summary>
        /// Gets or sets the color of the segment.
        /// </summary>
        /// <value>The color of the segment.</value>
        public Color SegmentColor
        {
            get { return segmentColor; }
            set { segmentColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the active text.
        /// </summary>
        /// <value>The color of the active text.</value>
        public Color ActiveTextColor
        {
            get { return segmentActiveTextColor; }
            set { segmentActiveTextColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the inactive text.
        /// </summary>
        /// <value>The color of the inactive text.</value>
        public Color InactiveTextColor
        {
            get { return segmentInactiveTextColor; }
            set { segmentInactiveTextColor = value; }
        }
    }

    /// <summary>
    /// Class iOSColors.
    /// </summary>
    public class iOSColors
    {
        /// <summary>
        /// The segment color
        /// </summary>
        private Color segmentColor = Color.FromArgb(0, 120, 255);

        /// <summary>
        /// The border colors
        /// </summary>
        private Color[] borderColors = new Color[]
        {
            Color.FromArgb(0, 120, 255),
            Color.FromArgb(0, 120, 255),
        };


        /// <summary>
        /// The segment active text color
        /// </summary>
        private Color segmentActiveTextColor = Color.White;

        /// <summary>
        /// The segment inactive text color
        /// </summary>
        private Color segmentInactiveTextColor = Color.FromArgb(0, 120, 255);

        /// <summary>
        /// Gets or sets the color of the segment.
        /// </summary>
        /// <value>The color of the segment.</value>
        public Color SegmentColor
        {
            get { return segmentColor; }
            set { segmentColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the active text.
        /// </summary>
        /// <value>The color of the active text.</value>
        public Color ActiveTextColor
        {
            get { return segmentActiveTextColor; }
            set { segmentActiveTextColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the inactive text.
        /// </summary>
        /// <value>The color of the inactive text.</value>
        public Color InactiveTextColor
        {
            get { return segmentInactiveTextColor; }
            set { segmentInactiveTextColor = value; }
        }

        /// <summary>
        /// Gets or sets the border colors.
        /// </summary>
        /// <value>The border colors.</value>
        public Color[] BorderColors
        {
            get { return borderColors; }
            set { borderColors = value; }
        }
    }

    /// <summary>
    /// Class MaterialColors.
    /// </summary>
    public class MaterialColors
    {
        /// <summary>
        /// The segment color
        /// </summary>
        private Color segmentColor = Color.White;

        /// <summary>
        /// The segment active text color
        /// </summary>
        private Color segmentActiveTextColor = Color.White;

        /// <summary>
        /// The segment inactive text color
        /// </summary>
        private Color segmentInactiveTextColor = Color.FromArgb(150, 210, 210);

        /// <summary>
        /// Gets or sets the color of the segment.
        /// </summary>
        /// <value>The color of the segment.</value>
        public Color SegmentColor
        {
            get { return segmentColor; }
            set { segmentColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the active text.
        /// </summary>
        /// <value>The color of the active text.</value>
        public Color ActiveTextColor
        {
            get { return segmentActiveTextColor; }
            set { segmentActiveTextColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the inactive text.
        /// </summary>
        /// <value>The color of the inactive text.</value>
        public Color InactiveTextColor
        {
            get { return segmentInactiveTextColor; }
            set { segmentInactiveTextColor = value; }
        }
    }

}