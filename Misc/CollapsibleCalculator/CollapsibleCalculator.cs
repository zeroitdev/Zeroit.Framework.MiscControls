// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CollapsibleCalculator.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Collapsible Calculator

    #region Seperator

    #region Control
    /// <summary>
    /// A control that draws text with a line following.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitSimpleSeparateDesigner))]
    public partial class ZeroitSimpleSeparate : Control
    {
        #region State

        /// <summary>
        /// The m line color
        /// </summary>
        private Color m_LineColor = Color.Gray;
        /// <summary>
        /// The m text line gap
        /// </summary>
        private int m_TextLineGap = 10;
        /// <summary>
        /// The m line width
        /// </summary>
        private int m_LineWidth = 1;

        #endregion //--State


        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSimpleSeparate"/> class.
        /// </summary>
        public ZeroitSimpleSeparate()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        #endregion //--Construction


        #region Control Overrides

        /// <summary>
        /// Gets the default size of the control.
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize
        {
            get { return new Size(200, 20); }
        }

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="pe">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            SizeF sz = g.MeasureString(Text, Font);
            using (Brush b = new SolidBrush(ForeColor))
            {
                g.DrawString(Text, Font, b, 0F, 0F);
            }
            using (Pen p = new Pen(m_LineColor, LineWidth))
            {
                float y = (float)sz.Height / 2.0F;
                g.DrawLine(p, sz.Width + TextLineGap, y, Width, y);
            }
        }
        #endregion //--Control Overrides


        #region Public Interface

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Gray")]
        public virtual Color LineColor
        {
            get { return m_LineColor; }
            set
            {
                m_LineColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text line gap.
        /// </summary>
        /// <value>The text line gap.</value>
        [Category("Appearance")]
        [DefaultValue(10)]
        public virtual int TextLineGap
        {
            get { return m_TextLineGap; }
            set
            {
                m_TextLineGap = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        [Category("Appearance")]
        [DefaultValue(1)]
        public virtual int LineWidth
        {
            get { return m_LineWidth; }
            set
            {
                m_LineWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [Category("Appearance")]
        [DefaultValue("")]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
        #endregion //--Public Interface
    }
    #endregion

    #region Designer Generated Code

    partial class ZeroitSimpleSeparate
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
            components = new System.ComponentModel.Container();
        }

        #endregion
    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitSimpleSeparateDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitSimpleSeparateDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitSimpleSeparateDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitSimpleSeparateSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitSimpleSeparateSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitSimpleSeparateSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitSimpleSeparate colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSimpleSeparateSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitSimpleSeparateSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitSimpleSeparate;

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

        #region Public Interface

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        public virtual Color LineColor
        {
            get
            {
                return colUserControl.LineColor;
            }
            set
            {
                GetPropertyByName("LineColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text line gap.
        /// </summary>
        /// <value>The text line gap.</value>
        public virtual int TextLineGap
        {
            get
            {
                return colUserControl.TextLineGap;
            }
            set
            {
                GetPropertyByName("TextLineGap").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        public virtual int LineWidth
        {
            get
            {
                return colUserControl.LineWidth;
            }
            set
            {
                GetPropertyByName("LineWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                return colUserControl.Text;
            }
            set
            {
                GetPropertyByName("Text").SetValue(colUserControl, value);
            }
        }
        #endregion //--Public Interface

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

            items.Add(new DesignerActionPropertyItem("LineColor",
                                 "Line Color", "Appearance",
                                 "Sets the line color."));

            items.Add(new DesignerActionPropertyItem("TextLineGap",
                                 "Text Line Gap", "Appearance",
                                 "Sets the text line gap."));

            items.Add(new DesignerActionPropertyItem("LineWidth",
                                 "Line Width", "Appearance",
                                 "Sets the line width."));

            items.Add(new DesignerActionPropertyItem("Text",
                                 "Text", "Appearance",
                                 "Sets the text."));

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

    #region Resource Designer

    /// <summary>
    /// A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Res
    {

        /// <summary>
        /// The resource man
        /// </summary>
        private static global::System.Resources.ResourceManager resourceMan;

        /// <summary>
        /// The resource culture
        /// </summary>
        private static global::System.Globalization.CultureInfo resourceCulture;

        /// <summary>
        /// Initializes a new instance of the <see cref="Res"/> class.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Res()
        {
        }

        /// <summary>
        /// Returns the cached ResourceManager instance used by this class.
        /// </summary>
        /// <value>The resource manager.</value>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    ResourceManager temp = new ResourceManager("Res", typeof(Res).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        /// Overrides the current thread's CurrentUICulture property for all
        /// resource lookups using this strongly typed resource class.
        /// </summary>
        /// <value>The culture.</value>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        /// <summary>
        /// Gets the calculate.
        /// </summary>
        /// <value>The calculate.</value>
        internal static System.Drawing.Bitmap calc
        {
            get
            {
                object obj = ResourceManager.GetObject("calc", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }

        /// <summary>
        /// Gets the check.
        /// </summary>
        /// <value>The check.</value>
        internal static System.Drawing.Bitmap check
        {
            get
            {
                object obj = ResourceManager.GetObject("check", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }

        /// <summary>
        /// Gets the delete.
        /// </summary>
        /// <value>The delete.</value>
        internal static System.Drawing.Bitmap del
        {
            get
            {
                object obj = ResourceManager.GetObject("del", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }

        /// <summary>
        /// Gets the x.
        /// </summary>
        /// <value>The x.</value>
        internal static System.Drawing.Bitmap x
        {
            get
            {
                object obj = ResourceManager.GetObject("x", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }

    #endregion

    #region Location Finder

    /// <summary>
    /// Class LocationFinder.
    /// </summary>
    public static class LocationFinder
    {
        /// <summary>
        /// Gets the screen location.
        /// </summary>
        /// <param name="ctl">The control.</param>
        /// <returns>Point.</returns>
        public static Point GetScreenLocation(Control ctl)
        {
            if (null == ctl)
                return new Point(0, 0);

            int x = ctl.Location.X;
            int y = ctl.Location.Y;
            Control parent = ctl.Parent;
            while (null != parent.Parent)
            {
                x += parent.Location.X;
                y += parent.Location.Y;
                parent = parent.Parent;
                if (null != parent && parent is System.Windows.Forms.Form)
                    break;
            }
            System.Windows.Forms.Form f = ctl.FindForm();
            Point pt = f.PointToScreen(new Point(x, y));

            return pt;
        }
    }

    #endregion

    #region Image Button

    #region Control
    /// <summary>
    /// Class ZeroitImageButton.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public partial class ZeroitImageButton : Control
    {
        /// <summary>
        /// The m button image
        /// </summary>
        private Image m_ButtonImage;
        /// <summary>
        /// The m image offset
        /// </summary>
        private Point m_ImageOffset;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitImageButton"/> class.
        /// </summary>
        public ZeroitImageButton()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="pe">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Image img = ButtonImage;
            if (null != img)
            {
                Point pt = ImageOffset;
                Graphics g = pe.Graphics;
                g.DrawImage(img, pt.X, pt.Y);
            }
        }

        /// <summary>
        /// Gets the image offset.
        /// </summary>
        /// <returns>Point.</returns>
        protected virtual Point GetImageOffset()
        {
            return new Point(1, 1);
        }

        /// <summary>
        /// Gets or sets the default cursor for the control.
        /// </summary>
        /// <value>The default cursor.</value>
        protected override Cursor DefaultCursor
        {
            get { return Cursors.Hand; }
        }

        /// <summary>
        /// Gets the default size of the control.
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize
        {
            get { return new Size(20, 20); }
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        /// Gets or sets the button image.
        /// </summary>
        /// <value>The button image.</value>
        [Category("Appearance")]
        [DefaultValue(null)]
        public virtual Image ButtonImage
        {
            get { return m_ButtonImage; }
            set
            {
                m_ButtonImage = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image offset.
        /// </summary>
        /// <value>The image offset.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Point), "0, 0,")]
        public virtual Point ImageOffset
        {
            get { return m_ImageOffset; }
            set
            {
                m_ImageOffset = value;
                Invalidate();
            }
        }
    }
    #endregion

    #region Designer Generated Code

    partial class ZeroitImageButton
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
            components = new System.ComponentModel.Container();
        }

        #endregion
    }

    #endregion
    #endregion

    #region Erase Button

    #region Control
    /// <summary>
    /// Class EraseButton.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitImageButton" />
    [ToolboxItem(false)]
    public partial class EraseButton : ZeroitImageButton
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EraseButton"/> class.
        /// </summary>
        public EraseButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the button image.
        /// </summary>
        /// <value>The button image.</value>
        [Browsable(false)]
        public override Image ButtonImage
        {
            get { return Properties.Resources.del; }
            set
            {
            }
        }
    }
    #endregion

    #region Designer Generated Code

    partial class EraseButton
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
            components = new System.ComponentModel.Container();
        }

        #endregion
    }

    #endregion

    #endregion

    #region Calculator TextBox

    #region Control
    /// <summary>
    /// A class that integrates a text box and ZeroitCalculatorButton. This user
    /// control forwards all its properties and methods to the button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Designer(typeof(ZeroitCalculatorTextBoxDesigner))]
    public partial class ZeroitCalculatorTextBox : UserControl
    {
        #region Construction        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCalculatorTextBox" /> class.
        /// </summary>
        public ZeroitCalculatorTextBox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        #endregion //--Construction


        #region Public Interface

        /// <summary>
        /// Closes the calculator.
        /// </summary>
        /// <param name="acceptResult">if set to <c>true</c> [accept result].</param>
        public void CloseCalculator(bool acceptResult)
        {
            m_BtnCalc.CloseCalculator(acceptResult);
        }

        /// <summary>
        /// Cancels the calculator.
        /// </summary>
        public void CancelCalculator()
        {
            m_BtnCalc.PreventCalculator();
        }

        /// <summary>
        /// Gets or sets the text box text.
        /// </summary>
        /// <value>The text box text.</value>
        [Category("Calculator")]
        [DefaultValue("")]
        public string TextBoxText
        {
            get { return m_TxtResult.Text; }
            set { m_TxtResult.Text = value; }
        }

        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        [Category("Calculator")]
        [DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment TextAlign
        {
            get { return m_TxtResult.TextAlign; }
            set { m_TxtResult.TextAlign = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [text read only].
        /// </summary>
        /// <value><c>true</c> if [text read only]; otherwise, <c>false</c>.</value>
        [Category("Calculator")]
        [DefaultValue(false)]
        public bool TextReadOnly
        {
            get { return m_TxtResult.ReadOnly; }
            set { m_TxtResult.ReadOnly = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show modal].
        /// </summary>
        /// <value><c>true</c> if [show modal]; otherwise, <c>false</c>.</value>
        [Category("Calculator")]
        [DefaultValue(false)]
        public bool ShowModal
        {
            get { return m_BtnCalc.ShowModal; }
            set { m_BtnCalc.ShowModal = value; }
        }

        /// <summary>
        /// Occurs when [calculator parse].
        /// </summary>
        [Category("Calculator")]
        public event EventHandler<CalculatorParseEventArgs> CalculatorParse
        {
            add { m_BtnCalc.CalculatorParse += value; }
            remove { m_BtnCalc.CalculatorParse -= value; }
        }

        /// <summary>
        /// Occurs when [calculator format].
        /// </summary>
        [Category("Calculator")]
        public event EventHandler<CalculatorFormatEventArgs> CalculatorFormat
        {
            add { m_BtnCalc.CalculatorFormat += value; }
            remove { m_BtnCalc.CalculatorFormat -= value; }
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the calculator back.
        /// </summary>
        /// <value>The color of the calculator back.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "Black")]
        public Color CalculatorBackColor
        {
            get { return m_BtnCalc.CalculatorBackColor; }
            set { m_BtnCalc.CalculatorBackColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the calculator border.
        /// </summary>
        /// <value>The color of the calculator border.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "White")]
        public Color CalculatorBorderColor
        {
            get { return m_BtnCalc.CalculatorBorderColor; }
            set { m_BtnCalc.CalculatorBorderColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the calculator number.
        /// </summary>
        /// <value>The color of the calculator number.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "Black")]
        public Color CalculatorNumberColor
        {
            get { return m_BtnCalc.CalculatorNumberColor; }
            set { m_BtnCalc.CalculatorNumberColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the calculator operator.
        /// </summary>
        /// <value>The color of the calculator operator.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "DimGray")]
        public Color CalculatorOperatorColor
        {
            get { return m_BtnCalc.CalculatorOperatorColor; }
            set { m_BtnCalc.CalculatorOperatorColor = value; }
        }

        /// <summary>
        /// Gets or sets the button flat style.
        /// </summary>
        /// <value>The button flat style.</value>
        [Category("Calculator")]
        [DefaultValue(FlatStyle.Standard)]
        public FlatStyle ButtonFlatStyle
        {
            get { return m_BtnCalc.ButtonFlatStyle; }
            set { m_BtnCalc.ButtonFlatStyle = value; }
        }

        /// <summary>
        /// Gets or sets the calculator heading.
        /// </summary>
        /// <value>The calculator heading.</value>
        [Category("Calculator")]
        [DefaultValue("Calculator")]
        public string CalculatorHeading
        {
            get { return m_BtnCalc.CalculatorHeading; }
            set { m_BtnCalc.CalculatorHeading = value; }
        }

        /// <summary>
        /// Gets or sets the color of the calculator title.
        /// </summary>
        /// <value>The color of the calculator title.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "White")]
        public Color CalculatorTitleColor
        {
            get { return m_BtnCalc.CalculatorTitleColor; }
            set { m_BtnCalc.CalculatorTitleColor = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic evaluate percent key].
        /// </summary>
        /// <value><c>true</c> if [automatic evaluate percent key]; otherwise, <c>false</c>.</value>
        [Category("Calculator")]
        [DefaultValue(false)]
        public bool AutoEvaluatePercentKey
        {
            get { return m_BtnCalc.AutoEvaluatePercentKey; }
            set { m_BtnCalc.AutoEvaluatePercentKey = value; }
        }
        #endregion //--Public Interface
    }
    #endregion

    #region Designer Generated Code

    partial class ZeroitCalculatorTextBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroitCalculatorTextBox));
            this.m_TxtResult = new System.Windows.Forms.TextBox();
            this.m_BtnCalc = new ZeroitCalculatorButton();
            this.SuspendLayout();
            // 
            // m_TxtResult
            // 
            this.m_TxtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TxtResult.Location = new System.Drawing.Point(0, 0);
            this.m_TxtResult.Name = "m_TxtResult";
            this.m_TxtResult.Size = new System.Drawing.Size(100, 20);
            this.m_TxtResult.TabIndex = 0;
            // 
            // m_BtnCalc
            // 
            this.m_BtnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BtnCalc.BackColor = System.Drawing.SystemColors.Control;
            //this.m_BtnCalc.ButtonImage = ((System.Drawing.Image)(resources.GetObject("m_BtnCalc.ButtonImage")));
            this.m_BtnCalc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_BtnCalc.ImageOffset = new System.Drawing.Point(0, 0);
            this.m_BtnCalc.Location = new System.Drawing.Point(103, 2);
            this.m_BtnCalc.Name = "m_BtnCalc";
            this.m_BtnCalc.ResultControl = this.m_TxtResult;
            this.m_BtnCalc.Size = new System.Drawing.Size(16, 16);
            this.m_BtnCalc.TabIndex = 1;
            // 
            // ZeroitCalculatorTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_TxtResult);
            this.Controls.Add(this.m_BtnCalc);
            this.Name = "ZeroitCalculatorTextBox";
            this.Size = new System.Drawing.Size(120, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The m text result
        /// </summary>
        private System.Windows.Forms.TextBox m_TxtResult;
        /// <summary>
        /// The m BTN calculate
        /// </summary>
        private ZeroitCalculatorButton m_BtnCalc;
    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(CalculatorTextBoxDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitCalculatorTextBoxDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitCalculatorTextBoxDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitCalculatorTextBoxSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitCalculatorTextBoxSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitCalculatorTextBoxSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitCalculatorTextBox colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCalculatorTextBoxSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitCalculatorTextBoxSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitCalculatorTextBox;

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

        /// <summary>
        /// Gets or sets a value indicating whether [show modal].
        /// </summary>
        /// <value><c>true</c> if [show modal]; otherwise, <c>false</c>.</value>
        public bool ShowModal
        {
            get
            {
                return colUserControl.ShowModal;
            }
            set
            {
                GetPropertyByName("ShowModal").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text box text.
        /// </summary>
        /// <value>The text box text.</value>
        public string TextBoxText
        {
            get
            {
                return colUserControl.TextBoxText;
            }
            set
            {
                GetPropertyByName("TextBoxText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        public HorizontalAlignment TextAlign
        {
            get
            {
                return colUserControl.TextAlign;
            }
            set
            {
                GetPropertyByName("TextAlign").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [text read only].
        /// </summary>
        /// <value><c>true</c> if [text read only]; otherwise, <c>false</c>.</value>
        public bool TextReadOnly
        {
            get
            {
                return colUserControl.TextReadOnly;
            }
            set
            {
                GetPropertyByName("TextReadOnly").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the calculator back.
        /// </summary>
        /// <value>The color of the calculator back.</value>
        public Color CalculatorBackColor
        {
            get
            {
                return colUserControl.CalculatorBackColor;
            }
            set
            {
                GetPropertyByName("CalculatorBackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the calculator border.
        /// </summary>
        /// <value>The color of the calculator border.</value>
        public Color CalculatorBorderColor
        {
            get
            {
                return colUserControl.CalculatorBorderColor;
            }
            set
            {
                GetPropertyByName("CalculatorBorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the calculator number.
        /// </summary>
        /// <value>The color of the calculator number.</value>
        public Color CalculatorNumberColor
        {
            get
            {
                return colUserControl.CalculatorNumberColor;
            }
            set
            {
                GetPropertyByName("CalculatorNumberColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the calculator operator.
        /// </summary>
        /// <value>The color of the calculator operator.</value>
        public Color CalculatorOperatorColor
        {
            get
            {
                return colUserControl.CalculatorOperatorColor;
            }
            set
            {
                GetPropertyByName("CalculatorOperatorColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the button flat style.
        /// </summary>
        /// <value>The button flat style.</value>
        public FlatStyle ButtonFlatStyle
        {
            get
            {
                return colUserControl.ButtonFlatStyle;
            }
            set
            {
                GetPropertyByName("ButtonFlatStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the calculator heading.
        /// </summary>
        /// <value>The calculator heading.</value>
        public string CalculatorHeading
        {
            get
            {
                return colUserControl.CalculatorHeading;
            }
            set
            {
                GetPropertyByName("CalculatorHeading").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the calculator title.
        /// </summary>
        /// <value>The color of the calculator title.</value>
        public Color CalculatorTitleColor
        {
            get
            {
                return colUserControl.CalculatorTitleColor;
            }
            set
            {
                GetPropertyByName("CalculatorTitleColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic evaluate percent key].
        /// </summary>
        /// <value><c>true</c> if [automatic evaluate percent key]; otherwise, <c>false</c>.</value>
        public bool AutoEvaluatePercentKey
        {
            get
            {
                return colUserControl.AutoEvaluatePercentKey;
            }
            set
            {
                GetPropertyByName("AutoEvaluatePercentKey").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("TextReadOnly",
                                 "Text Read Only", "Appearance",
                                 "Sets the calculator text to be readonly."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("TextBoxText",
                                 "TextBox Text", "Appearance",
                                 "Set the textbox text."));

            items.Add(new DesignerActionPropertyItem("TextAlign",
                                 "Text Align", "Appearance",
                                 "Sets the text alignment."));


            items.Add(new DesignerActionHeaderItem("Calculator"));

            items.Add(new DesignerActionPropertyItem("ShowModal",
                                 "Show Modal", "Calculator",
                                 "Set to show the modal."));

            items.Add(new DesignerActionPropertyItem("AutoEvaluatePercentKey",
                                 "Auto Evaluate Percent Key", "Calculator",
                                 "Set to automatically evaluate the percent key."));

            items.Add(new DesignerActionPropertyItem("CalculatorBackColor",
                                 "Calculator BackColor", "Calculator",
                                 "Sets the calculator backcolor."));

            items.Add(new DesignerActionPropertyItem("CalculatorBorderColor",
                                 "Calculator Border Color", "Calculator",
                                 "Sets the calculator border color."));

            items.Add(new DesignerActionPropertyItem("CalculatorNumberColor",
                                 "Calculator Number Color", "Calculator",
                                 "Sets the calculator number color."));

            items.Add(new DesignerActionPropertyItem("CalculatorOperatorColor",
                                 "Calculator Operator Color", "Calculator",
                                 "Sets the operator color."));

            items.Add(new DesignerActionPropertyItem("ButtonFlatStyle",
                                 "Button Flat Style", "Calculator",
                                 "Sets the button flat style of the control."));

            items.Add(new DesignerActionPropertyItem("CalculatorHeading",
                                 "Calculator Heading", "Calculator",
                                 "Sets the calculator heading."));

            items.Add(new DesignerActionPropertyItem("CalculatorTitleColor",
                                 "Calculator Title Color", "Calculator",
                                 "Sets the calculator title color."));


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

    #region EventArgs

    #region CalculatorParseEventArgs

    /// <summary>
    /// The event args class used when a CalculatorPanel opens and needs to
    /// parse the string passed in. This event args will be called when the
    /// calculator panel first opens.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class CalculatorParseEventArgs : EventArgs
    {
        #region State

        /// <summary>
        /// The m original
        /// </summary>
        private string m_Original = String.Empty;
        /// <summary>
        /// The m parsed
        /// </summary>
        private string m_Parsed = String.Empty;

        #endregion //--State


        #region Construction

        /// <summary>
        /// Constructs a new CalculatorParseEventArgs with the given string.
        /// </summary>
        /// <param name="original">The original.</param>
        public CalculatorParseEventArgs(string original)
        {
            m_Original = null == original ? String.Empty : original;
            m_Parsed = m_Original;
        }
        #endregion //--Construction


        #region Public Interface

        /// <summary>
        /// Gets the original string value.
        /// </summary>
        /// <value>The original.</value>
        public string Original
        {
            get { return m_Original; }
        }

        /// <summary>
        /// Gets or sets the parsed string value.
        /// </summary>
        /// <value>The parsed.</value>
        public string Parsed
        {
            get { return m_Parsed; }
            set { m_Parsed = value; }
        }

        /// <summary>
        /// Gets the double of the parsed string. Will return 0.0
        /// if the value cannot be parsed to a double.
        /// </summary>
        /// <returns>System.Double.</returns>
        public double GetResult()
        {
            double d = 0.0;
            Double.TryParse(m_Parsed, out d);

            return d;
        }
        #endregion //--Public Interface
    }

    #endregion

    #region CalculatorFormatEventArgs

    /// <summary>
    /// The event args class used when a calculation in a CalculatorPanel
    /// is completed.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
	public class CalculatorFormatEventArgs : EventArgs
    {
        #region State

        /// <summary>
        /// The m result
        /// </summary>
        private double m_Result = 0.0;
        /// <summary>
        /// The m formatted result
        /// </summary>
        private string m_FormattedResult = String.Empty;

        #endregion //--State


        #region Construction

        /// <summary>
        /// Constructs a new CalculatorFormatEventArgs with the result of
        /// the calculation.
        /// </summary>
        /// <param name="result">The result.</param>
        public CalculatorFormatEventArgs(double result)
        {
            m_Result = result;
            m_FormattedResult = m_Result.ToString();
        }
        #endregion //--Construction


        #region Public Interface

        /// <summary>
        /// Gets the result of the calculation.
        /// </summary>
        /// <value>The result.</value>
        public double Result
        {
            get { return m_Result; }
        }

        /// <summary>
        /// Gets or sets the formatted result.
        /// </summary>
        /// <value>The formatted result.</value>
        public string FormattedResult
        {
            get { return m_FormattedResult; }
            set { m_FormattedResult = value; }
        }
        #endregion //--Public Interface
    }

    #endregion

    #endregion

    #region CalculatorPanel

    #region Control
    /// <summary>
    /// A calculator that is controlled from a ZeroitCalculatorButton.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
	public partial class CalculatorPanel : System.Windows.Forms.Form
    {
        #region State

        /// <summary>
        /// The m result control
        /// </summary>
        private Control m_ResultControl;
        /// <summary>
        /// The m anchor control
        /// </summary>
        private Control m_AnchorControl;
        /// <summary>
        /// The m start value
        /// </summary>
        private string m_StartValue = String.Empty;
        /// <summary>
        /// The m result
        /// </summary>
        private string m_Result = "0";
        /// <summary>
        /// The m restart
        /// </summary>
        private bool m_Restart = true;
        /// <summary>
        /// The m border color
        /// </summary>
        private Color m_BorderColor = Color.White;
        /// <summary>
        /// The m last op
        /// </summary>
        private char m_LastOp = '\0';
        /// <summary>
        /// The m is in equals
        /// </summary>
        private bool m_IsInEquals = false;
        /// <summary>
        /// The m stack
        /// </summary>
        private Stack<double> m_Stack = new Stack<double>();
        /// <summary>
        /// The m parse
        /// </summary>
        private EventHandler<CalculatorParseEventArgs> m_Parse;
        /// <summary>
        /// The m format
        /// </summary>
        private EventHandler<CalculatorFormatEventArgs> m_Format;
        /// <summary>
        /// The m centered
        /// </summary>
        private bool m_Centered = false;
        /// <summary>
        /// The m automatic evaluate percent key
        /// </summary>
        private bool m_AutoEvaluatePercentKey = false;

        #endregion //--State


        #region Construction        
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorPanel" /> class.
        /// </summary>
        public CalculatorPanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);
            m_Btn_Num_Negate.Text = '\u00B1'.ToString();
            m_Btn_Num_Dot.Text = GetSeparatorChar().ToString();
        }
        #endregion //--Construction


        #region Event Handlers

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HookAnchorEvents(true);
            InitStartValue();
            m_LblTitle.Text = Text;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Closed" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClosed(EventArgs e)
        {
            HookAnchorEvents(false);
            base.OnClosed(e);
        }

        /// <summary>
        /// Anchors the location changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AnchorLocationChanged(object sender, EventArgs e)
        {
            Reposition();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Escape)
                CancelAndClose();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyPress" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs" /> that contains the event data.</param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            char c = e.KeyChar;
            EventArgs ev = EventArgs.Empty;
            if (Char.IsDigit(c) || c == GetSeparatorChar())
                AddChar(c);
            else
            {
                switch (c)
                {
                    case '+':
                    case '-':
                    case '/':
                    case '*':
                        DoOpChar(c);
                        break;
                    case '%':
                        DoPercentChar();
                        break;
                    case '=':
                    case '\r':
                        DoEqualsChar();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle bounds = ClientRectangle;
            bounds.Inflate(-4, -4);
            g.DrawRectangle(new Pen(m_BorderColor, 2f), bounds);
        }

        /// <summary>
        /// Handles the <see cref="E:Parse" /> event.
        /// </summary>
        /// <param name="e">The <see cref="CalculatorParseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnParse(CalculatorParseEventArgs e)
        {
            if (null != m_Parse)
                m_Parse(this, e);
        }

        /// <summary>
        /// Handles the <see cref="E:Format" /> event.
        /// </summary>
        /// <param name="e">The <see cref="CalculatorFormatEventArgs"/> instance containing the event data.</param>
        protected virtual void OnFormat(CalculatorFormatEventArgs e)
        {
            if (null != m_Format)
                m_Format(this, e);
        }
        #endregion //--Event Handlers


        #region Private Members

        /// <summary>
        /// Hooks the anchor events.
        /// </summary>
        /// <param name="hook">if set to <c>true</c> [hook].</param>
        private void HookAnchorEvents(bool hook)
        {
            Control ctl = GetAnchorControl();
            while (null != ctl)
            {
                ctl.LocationChanged -= new EventHandler(
                    AnchorLocationChanged);
                ctl = ctl.Parent;
            }
            if (hook)
            {
                ctl = GetAnchorControl();
                while (null != ctl)
                {
                    ctl.LocationChanged += new EventHandler(
                        AnchorLocationChanged);
                    ctl = ctl.Parent;
                }
                ctl = GetAnchorControl();
                if (null != ctl)
                    Owner = ctl.FindForm();
            }
        }

        /// <summary>
        /// Gets the anchor control.
        /// </summary>
        /// <returns>Control.</returns>
        private Control GetAnchorControl()
        {
            if (null != m_ResultControl)
                return m_ResultControl;

            return m_AnchorControl;
        }

        /// <summary>
        /// Gets the separator character.
        /// </summary>
        /// <returns>System.Char.</returns>
        private char GetSeparatorChar()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            string sep = culture.NumberFormat.NumberDecimalSeparator;
            if (String.IsNullOrEmpty(sep))
                return '.';

            return sep[0];
        }

        /// <summary>
        /// Sets the display.
        /// </summary>
        /// <param name="s">The s.</param>
        private void SetDisplay(string s)
        {
            m_TxtDisplay.Focus();
            m_Result = s;
            m_TxtDisplay.Text = s;
        }

        /// <summary>
        /// Adds the character.
        /// </summary>
        /// <param name="c">The c.</param>
        private void AddChar(char c)
        {
            string s = m_TxtDisplay.Text;
            if (c == GetSeparatorChar() &&
                s.Contains(GetSeparatorChar().ToString()) && !m_Restart)
                return;

            if (s == "0")
                s = c.ToString();
            else
                s += c;
            SetDisplay(s);
            if (m_Restart)
            {
                SetDisplay(c.ToString());
                m_Restart = false;
            }
        }

        /// <summary>
        /// Gets the display value.
        /// </summary>
        /// <value>The display value.</value>
        private double DisplayValue
        {
            get
            {
                double d = 0;
                if (Double.TryParse(m_TxtDisplay.Text, out d))
                    return d;

                return 0.0;
            }
        }

        /// <summary>
        /// Does the last op.
        /// </summary>
        private void DoLastOp()
        {
            m_Restart = true;
            if (m_LastOp == '\0' || m_Stack.Count == 1)
                return;

            double valTwo = m_Stack.Pop();
            double valOne = m_Stack.Pop();
            switch (m_LastOp)
            {
                case '+':
                    m_Stack.Push(valOne + valTwo);
                    break;
                case '-':
                    m_Stack.Push(valOne - valTwo);
                    break;
                case '*':
                    m_Stack.Push(valOne * valTwo);
                    break;
                case '/':
                    m_Stack.Push(valOne / valTwo);
                    break;
                default:
                    break;
            }
            SetDisplay(m_Stack.Peek().ToString());
            if (m_IsInEquals)
                m_Stack.Push(valTwo);
        }

        /// <summary>
        /// Does the op character.
        /// </summary>
        /// <param name="op">The op.</param>
        private void DoOpChar(char op)
        {
            if (m_IsInEquals)
            {
                m_Stack.Clear();
                m_IsInEquals = false;
            }
            m_Stack.Push(DisplayValue);
            DoLastOp();
            m_LastOp = op;
        }

        /// <summary>
        /// Does the equals character.
        /// </summary>
        private void DoEqualsChar()
        {
            if (m_LastOp == '\0')
                return;

            if (!m_IsInEquals)
            {
                m_IsInEquals = true;
                m_Stack.Push(DisplayValue);
            }
            DoLastOp();
        }

        /// <summary>
        /// Does the percent character.
        /// </summary>
        private void DoPercentChar()
        {
            if (m_Stack.Count == 0)
                return;

            SetDisplay((m_Stack.Peek() * (DisplayValue / 100.0)).ToString());
            if (AutoEvaluatePercentKey)
                DoEqualsChar();
        }

        /// <summary>
        /// Resets all.
        /// </summary>
        private void ResetAll()
        {
            SetDisplay("0");
            m_LastOp = '\0';
            m_Restart = true;
            m_Stack.Clear();
        }

        /// <summary>
        /// Initializes the start value.
        /// </summary>
        private void InitStartValue()
        {
            if (null != m_ResultControl)
                m_StartValue = m_ResultControl.Text;
            CalculatorParseEventArgs cpe = new CalculatorParseEventArgs(m_StartValue);
            OnParse(cpe);
            SetDisplay(cpe.GetResult().ToString());
        }

        /// <summary>
        /// Oks the and close.
        /// </summary>
        private void OkAndClose()
        {
            SetDisplay(m_TxtDisplay.Text);
            CalculatorFormatEventArgs cfe = new CalculatorFormatEventArgs(Result);
            OnFormat(cfe);
            Close();
            if (null != m_ResultControl)
                m_ResultControl.Focus();
            if (null != m_AnchorControl)
                m_AnchorControl.Focus();
        }

        /// <summary>
        /// Cancels the and close.
        /// </summary>
        private void CancelAndClose()
        {
            m_Result = m_StartValue;
            Close();
        }
        #endregion //--Private Members


        #region Control Events

        /// <summary>
        /// Numbers the BTN click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NumberBtnClick(object sender, EventArgs e)
        {
            AddChar(((Button)sender).Text[0]);
        }

        /// <summary>
        /// Ops the BTN click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OpBtnClick(object sender, EventArgs e)
        {
            DoOpChar(((Button)sender).Text[0]);
        }

        /// <summary>
        /// Equalses the BTN click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EqualsBtnClick(object sender, EventArgs e)
        {
            DoEqualsChar();
        }

        /// <summary>
        /// Percents the BTN click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PercentBtnClick(object sender, EventArgs e)
        {
            DoPercentChar();
        }

        /// <summary>
        /// Negates the BTN click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NegateBtnClick(object sender, EventArgs e)
        {
            SetDisplay((-(DisplayValue)).ToString());
        }

        /// <summary>
        /// Clears the BTN click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ClearBtnClick(object sender, EventArgs e)
        {
            ResetAll();
        }

        /// <summary>
        /// Oks the BTN click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OkBtnClick(object sender, EventArgs e)
        {
            OkAndClose();
        }

        /// <summary>
        /// Cancels the BTN click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CancelBtnClick(object sender, EventArgs e)
        {
            CancelAndClose();
        }
        #endregion //--Control Events


        #region Public Interface

        /// <summary>
        /// Accepts this instance.
        /// </summary>
        public void Accept()
        {
            OkAndClose();
        }

        /// <summary>
        /// Occurs when [parse].
        /// </summary>
        [Category("Calculator")]
        public event EventHandler<CalculatorParseEventArgs> Parse
        {
            add { m_Parse += value; }
            remove { m_Parse -= value; }
        }

        /// <summary>
        /// Occurs when [format].
        /// </summary>
        [Category("Calculator")]
        public event EventHandler<CalculatorFormatEventArgs> Format
        {
            add { m_Format += value; }
            remove { m_Format -= value; }
        }

        /// <summary>
        /// Gets or sets the control that opened the calculator. This is used
        /// for positioning if ResultControl is null.
        /// </summary>
        /// <value>The anchor control.</value>
        [Browsable(false)]
        public Control AnchorControl
        {
            get { return m_AnchorControl; }
            set
            {
                m_AnchorControl = value;
                Reposition();
                HookAnchorEvents(true);
            }
        }

        /// <summary>
        /// Gets or sets the control where the text result will be stored.
        /// </summary>
        /// <value>The result control.</value>
        [Category("Calculator")]
        [DefaultValue(null)]
        public Control ResultControl
        {
            get { return m_ResultControl; }
            set
            {
                m_ResultControl = value;
                Reposition();
                HookAnchorEvents(true);
                ResetAll();
                InitStartValue();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "White")]
        public Color BorderColor
        {
            get { return m_BorderColor; }
            set
            {
                m_BorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the number.
        /// </summary>
        /// <value>The color of the number.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "Black")]
        public Color NumberColor
        {
            get { return m_Btn_Num_0.ForeColor; }
            set
            {
                foreach (Control c in Controls)
                {
                    if (c.Name.Contains("_Num_"))
                        c.ForeColor = value;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the operator.
        /// </summary>
        /// <value>The color of the operator.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "DimGray")]
        public Color OperatorColor
        {
            get { return m_Btn_Op_Add.ForeColor; }
            set
            {
                foreach (Control c in Controls)
                {
                    if (c.Name.Contains("_Op_"))
                        c.ForeColor = value;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the title.
        /// </summary>
        /// <value>The color of the title.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "White")]
        public Color TitleColor
        {
            get { return m_LblTitle.ForeColor; }
            set
            {
                m_LblTitle.ForeColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the button flat style.
        /// </summary>
        /// <value>The button flat style.</value>
        [Category("Calculator")]
        [DefaultValue(FlatStyle.Standard)]
        public FlatStyle ButtonFlatStyle
        {
            get { return m_Btn_Num_0.FlatStyle; }
            set
            {
                foreach (Control c in Controls)
                {
                    if (c is Button)
                        ((Button)c).FlatStyle = value;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic evaluate percent key].
        /// </summary>
        /// <value><c>true</c> if [automatic evaluate percent key]; otherwise, <c>false</c>.</value>
        [Category("Calculator")]
        [DefaultValue(false)]
        public bool AutoEvaluatePercentKey
        {
            get { return m_AutoEvaluatePercentKey; }
            set { m_AutoEvaluatePercentKey = value; }
        }

        /// <summary>
        /// Gets or sets the start value.
        /// </summary>
        /// <value>The start value.</value>
        [Browsable(false)]
        public string StartValue
        {
            get { return m_StartValue; }
            set { m_StartValue = null == value ? String.Empty : value; }
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>The result.</value>
        [Browsable(false)]
        public double Result
        {
            get
            {
                double d = 0;
                Double.TryParse(m_Result, out d);

                return d;
            }
        }

        /// <summary>
        /// Gets the string result.
        /// </summary>
        /// <value>The string result.</value>
        [Browsable(false)]
        public string StringResult
        {
            get { return m_Result; }
        }

        /// <summary>
        /// Repositions this instance.
        /// </summary>
        public void Reposition()
        {
            Control ctl = GetAnchorControl();
            if (null == ctl)
                return;

            if (!m_Centered)
            {
                CenterToScreen();
                m_Centered = true;
            }
            Point pt = LocationFinder.GetScreenLocation(ctl);
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            if (screen.Height < pt.Y + Height + ctl.Height)
                pt = new Point(pt.X, pt.Y - Height);
            else
                pt = new Point(pt.X, pt.Y + ctl.Height);
            Location = pt;
        }
        #endregion //--Public Interface
    }
    #endregion

    #region Designer Generated Code

    partial class CalculatorPanel
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
            this.m_Btn_Num_7 = new System.Windows.Forms.Button();
            this.m_Btn_Num_8 = new System.Windows.Forms.Button();
            this.m_Btn_Num_9 = new System.Windows.Forms.Button();
            this.m_Btn_Num_4 = new System.Windows.Forms.Button();
            this.m_Btn_Num_5 = new System.Windows.Forms.Button();
            this.m_Btn_Num_6 = new System.Windows.Forms.Button();
            this.m_Btn_Num_1 = new System.Windows.Forms.Button();
            this.m_Btn_Num_2 = new System.Windows.Forms.Button();
            this.m_Btn_Num_3 = new System.Windows.Forms.Button();
            this.m_Btn_Op_Divide = new System.Windows.Forms.Button();
            this.m_Btn_Op_Multiply = new System.Windows.Forms.Button();
            this.m_Btn_Num_0 = new System.Windows.Forms.Button();
            this.m_Btn_Num_Dot = new System.Windows.Forms.Button();
            this.m_Btn_Op_Add = new System.Windows.Forms.Button();
            this.m_Btn_Op_Subtract = new System.Windows.Forms.Button();
            this.m_Btn_Op_Enter = new System.Windows.Forms.Button();
            this.m_Btn_Op_Percent = new System.Windows.Forms.Button();
            this.m_Btn_Num_Negate = new System.Windows.Forms.Button();
            this.m_Btn_Op_Clear = new System.Windows.Forms.Button();
            this.m_TxtDisplay = new System.Windows.Forms.TextBox();
            this.m_Btn_Op_Ok = new System.Windows.Forms.Button();
            this.m_Btn_Op_Cancel = new System.Windows.Forms.Button();
            this.m_LblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_Btn_Num_7
            // 
            this.m_Btn_Num_7.BackColor = System.Drawing.Color.White;
            this.m_Btn_Num_7.ForeColor = System.Drawing.Color.Black;
            this.m_Btn_Num_7.Location = new System.Drawing.Point(10, 86);
            this.m_Btn_Num_7.Name = "m_Btn_Num_7";
            this.m_Btn_Num_7.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Num_7.TabIndex = 0;
            this.m_Btn_Num_7.TabStop = false;
            this.m_Btn_Num_7.Text = "7";
            this.m_Btn_Num_7.UseVisualStyleBackColor = false;
            this.m_Btn_Num_7.Click += new System.EventHandler(this.NumberBtnClick);
            // 
            // m_Btn_Num_8
            // 
            this.m_Btn_Num_8.BackColor = System.Drawing.Color.White;
            this.m_Btn_Num_8.ForeColor = System.Drawing.Color.Black;
            this.m_Btn_Num_8.Location = new System.Drawing.Point(41, 86);
            this.m_Btn_Num_8.Name = "m_Btn_Num_8";
            this.m_Btn_Num_8.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Num_8.TabIndex = 0;
            this.m_Btn_Num_8.TabStop = false;
            this.m_Btn_Num_8.Text = "8";
            this.m_Btn_Num_8.UseVisualStyleBackColor = false;
            this.m_Btn_Num_8.Click += new System.EventHandler(this.NumberBtnClick);
            // 
            // m_Btn_Num_9
            // 
            this.m_Btn_Num_9.BackColor = System.Drawing.Color.White;
            this.m_Btn_Num_9.ForeColor = System.Drawing.Color.Black;
            this.m_Btn_Num_9.Location = new System.Drawing.Point(72, 86);
            this.m_Btn_Num_9.Name = "m_Btn_Num_9";
            this.m_Btn_Num_9.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Num_9.TabIndex = 0;
            this.m_Btn_Num_9.TabStop = false;
            this.m_Btn_Num_9.Text = "9";
            this.m_Btn_Num_9.UseVisualStyleBackColor = false;
            this.m_Btn_Num_9.Click += new System.EventHandler(this.NumberBtnClick);
            // 
            // m_Btn_Num_4
            // 
            this.m_Btn_Num_4.BackColor = System.Drawing.Color.White;
            this.m_Btn_Num_4.ForeColor = System.Drawing.Color.Black;
            this.m_Btn_Num_4.Location = new System.Drawing.Point(10, 117);
            this.m_Btn_Num_4.Name = "m_Btn_Num_4";
            this.m_Btn_Num_4.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Num_4.TabIndex = 0;
            this.m_Btn_Num_4.TabStop = false;
            this.m_Btn_Num_4.Text = "4";
            this.m_Btn_Num_4.UseVisualStyleBackColor = false;
            this.m_Btn_Num_4.Click += new System.EventHandler(this.NumberBtnClick);
            // 
            // m_Btn_Num_5
            // 
            this.m_Btn_Num_5.BackColor = System.Drawing.Color.White;
            this.m_Btn_Num_5.ForeColor = System.Drawing.Color.Black;
            this.m_Btn_Num_5.Location = new System.Drawing.Point(41, 117);
            this.m_Btn_Num_5.Name = "m_Btn_Num_5";
            this.m_Btn_Num_5.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Num_5.TabIndex = 0;
            this.m_Btn_Num_5.TabStop = false;
            this.m_Btn_Num_5.Text = "5";
            this.m_Btn_Num_5.UseVisualStyleBackColor = false;
            this.m_Btn_Num_5.Click += new System.EventHandler(this.NumberBtnClick);
            // 
            // m_Btn_Num_6
            // 
            this.m_Btn_Num_6.BackColor = System.Drawing.Color.White;
            this.m_Btn_Num_6.ForeColor = System.Drawing.Color.Black;
            this.m_Btn_Num_6.Location = new System.Drawing.Point(72, 117);
            this.m_Btn_Num_6.Name = "m_Btn_Num_6";
            this.m_Btn_Num_6.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Num_6.TabIndex = 0;
            this.m_Btn_Num_6.TabStop = false;
            this.m_Btn_Num_6.Text = "6";
            this.m_Btn_Num_6.UseVisualStyleBackColor = false;
            this.m_Btn_Num_6.Click += new System.EventHandler(this.NumberBtnClick);
            // 
            // m_Btn_Num_1
            // 
            this.m_Btn_Num_1.BackColor = System.Drawing.Color.White;
            this.m_Btn_Num_1.ForeColor = System.Drawing.Color.Black;
            this.m_Btn_Num_1.Location = new System.Drawing.Point(10, 148);
            this.m_Btn_Num_1.Name = "m_Btn_Num_1";
            this.m_Btn_Num_1.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Num_1.TabIndex = 0;
            this.m_Btn_Num_1.TabStop = false;
            this.m_Btn_Num_1.Text = "1";
            this.m_Btn_Num_1.UseVisualStyleBackColor = false;
            this.m_Btn_Num_1.Click += new System.EventHandler(this.NumberBtnClick);
            // 
            // m_Btn_Num_2
            // 
            this.m_Btn_Num_2.BackColor = System.Drawing.Color.White;
            this.m_Btn_Num_2.ForeColor = System.Drawing.Color.Black;
            this.m_Btn_Num_2.Location = new System.Drawing.Point(41, 148);
            this.m_Btn_Num_2.Name = "m_Btn_Num_2";
            this.m_Btn_Num_2.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Num_2.TabIndex = 0;
            this.m_Btn_Num_2.TabStop = false;
            this.m_Btn_Num_2.Text = "2";
            this.m_Btn_Num_2.UseVisualStyleBackColor = false;
            this.m_Btn_Num_2.Click += new System.EventHandler(this.NumberBtnClick);
            // 
            // m_Btn_Num_3
            // 
            this.m_Btn_Num_3.BackColor = System.Drawing.Color.White;
            this.m_Btn_Num_3.ForeColor = System.Drawing.Color.Black;
            this.m_Btn_Num_3.Location = new System.Drawing.Point(72, 148);
            this.m_Btn_Num_3.Name = "m_Btn_Num_3";
            this.m_Btn_Num_3.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Num_3.TabIndex = 0;
            this.m_Btn_Num_3.TabStop = false;
            this.m_Btn_Num_3.Text = "3";
            this.m_Btn_Num_3.UseVisualStyleBackColor = false;
            this.m_Btn_Num_3.Click += new System.EventHandler(this.NumberBtnClick);
            // 
            // m_Btn_Op_Divide
            // 
            this.m_Btn_Op_Divide.BackColor = System.Drawing.Color.White;
            this.m_Btn_Op_Divide.ForeColor = System.Drawing.Color.DimGray;
            this.m_Btn_Op_Divide.Location = new System.Drawing.Point(41, 55);
            this.m_Btn_Op_Divide.Name = "m_Btn_Op_Divide";
            this.m_Btn_Op_Divide.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Op_Divide.TabIndex = 0;
            this.m_Btn_Op_Divide.TabStop = false;
            this.m_Btn_Op_Divide.Text = "/";
            this.m_Btn_Op_Divide.UseVisualStyleBackColor = false;
            this.m_Btn_Op_Divide.Click += new System.EventHandler(this.OpBtnClick);
            // 
            // m_Btn_Op_Multiply
            // 
            this.m_Btn_Op_Multiply.BackColor = System.Drawing.Color.White;
            this.m_Btn_Op_Multiply.ForeColor = System.Drawing.Color.DimGray;
            this.m_Btn_Op_Multiply.Location = new System.Drawing.Point(72, 55);
            this.m_Btn_Op_Multiply.Name = "m_Btn_Op_Multiply";
            this.m_Btn_Op_Multiply.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Op_Multiply.TabIndex = 0;
            this.m_Btn_Op_Multiply.TabStop = false;
            this.m_Btn_Op_Multiply.Text = "*";
            this.m_Btn_Op_Multiply.UseVisualStyleBackColor = false;
            this.m_Btn_Op_Multiply.Click += new System.EventHandler(this.OpBtnClick);
            // 
            // m_Btn_Num_0
            // 
            this.m_Btn_Num_0.BackColor = System.Drawing.Color.White;
            this.m_Btn_Num_0.ForeColor = System.Drawing.Color.Black;
            this.m_Btn_Num_0.Location = new System.Drawing.Point(10, 179);
            this.m_Btn_Num_0.Name = "m_Btn_Num_0";
            this.m_Btn_Num_0.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Num_0.TabIndex = 0;
            this.m_Btn_Num_0.TabStop = false;
            this.m_Btn_Num_0.Text = "0";
            this.m_Btn_Num_0.UseVisualStyleBackColor = false;
            this.m_Btn_Num_0.Click += new System.EventHandler(this.NumberBtnClick);
            // 
            // m_Btn_Num_Dot
            // 
            this.m_Btn_Num_Dot.BackColor = System.Drawing.Color.White;
            this.m_Btn_Num_Dot.ForeColor = System.Drawing.Color.Black;
            this.m_Btn_Num_Dot.Location = new System.Drawing.Point(72, 179);
            this.m_Btn_Num_Dot.Name = "m_Btn_Num_Dot";
            this.m_Btn_Num_Dot.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Num_Dot.TabIndex = 0;
            this.m_Btn_Num_Dot.TabStop = false;
            this.m_Btn_Num_Dot.Text = ".";
            this.m_Btn_Num_Dot.UseVisualStyleBackColor = false;
            this.m_Btn_Num_Dot.Click += new System.EventHandler(this.NumberBtnClick);
            // 
            // m_Btn_Op_Add
            // 
            this.m_Btn_Op_Add.BackColor = System.Drawing.Color.White;
            this.m_Btn_Op_Add.ForeColor = System.Drawing.Color.DimGray;
            this.m_Btn_Op_Add.Location = new System.Drawing.Point(103, 86);
            this.m_Btn_Op_Add.Name = "m_Btn_Op_Add";
            this.m_Btn_Op_Add.Size = new System.Drawing.Size(30, 61);
            this.m_Btn_Op_Add.TabIndex = 0;
            this.m_Btn_Op_Add.TabStop = false;
            this.m_Btn_Op_Add.Text = "+";
            this.m_Btn_Op_Add.UseVisualStyleBackColor = false;
            this.m_Btn_Op_Add.Click += new System.EventHandler(this.OpBtnClick);
            // 
            // m_Btn_Op_Subtract
            // 
            this.m_Btn_Op_Subtract.BackColor = System.Drawing.Color.White;
            this.m_Btn_Op_Subtract.ForeColor = System.Drawing.Color.DimGray;
            this.m_Btn_Op_Subtract.Location = new System.Drawing.Point(103, 55);
            this.m_Btn_Op_Subtract.Name = "m_Btn_Op_Subtract";
            this.m_Btn_Op_Subtract.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Op_Subtract.TabIndex = 0;
            this.m_Btn_Op_Subtract.TabStop = false;
            this.m_Btn_Op_Subtract.Text = "-";
            this.m_Btn_Op_Subtract.UseVisualStyleBackColor = false;
            this.m_Btn_Op_Subtract.Click += new System.EventHandler(this.OpBtnClick);
            // 
            // m_Btn_Op_Enter
            // 
            this.m_Btn_Op_Enter.BackColor = System.Drawing.Color.White;
            this.m_Btn_Op_Enter.ForeColor = System.Drawing.Color.DimGray;
            this.m_Btn_Op_Enter.Location = new System.Drawing.Point(103, 148);
            this.m_Btn_Op_Enter.Name = "m_Btn_Op_Enter";
            this.m_Btn_Op_Enter.Size = new System.Drawing.Size(30, 61);
            this.m_Btn_Op_Enter.TabIndex = 0;
            this.m_Btn_Op_Enter.TabStop = false;
            this.m_Btn_Op_Enter.Text = "=";
            this.m_Btn_Op_Enter.UseVisualStyleBackColor = false;
            this.m_Btn_Op_Enter.Click += new System.EventHandler(this.EqualsBtnClick);
            // 
            // m_Btn_Op_Percent
            // 
            this.m_Btn_Op_Percent.BackColor = System.Drawing.Color.White;
            this.m_Btn_Op_Percent.ForeColor = System.Drawing.Color.DimGray;
            this.m_Btn_Op_Percent.Location = new System.Drawing.Point(10, 55);
            this.m_Btn_Op_Percent.Name = "m_Btn_Op_Percent";
            this.m_Btn_Op_Percent.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Op_Percent.TabIndex = 0;
            this.m_Btn_Op_Percent.TabStop = false;
            this.m_Btn_Op_Percent.Text = "%";
            this.m_Btn_Op_Percent.UseVisualStyleBackColor = false;
            this.m_Btn_Op_Percent.Click += new System.EventHandler(this.PercentBtnClick);
            // 
            // m_Btn_Num_Negate
            // 
            this.m_Btn_Num_Negate.BackColor = System.Drawing.Color.White;
            this.m_Btn_Num_Negate.ForeColor = System.Drawing.Color.Black;
            this.m_Btn_Num_Negate.Location = new System.Drawing.Point(41, 179);
            this.m_Btn_Num_Negate.Name = "m_Btn_Num_Negate";
            this.m_Btn_Num_Negate.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Num_Negate.TabIndex = 0;
            this.m_Btn_Num_Negate.TabStop = false;
            this.m_Btn_Num_Negate.UseVisualStyleBackColor = false;
            this.m_Btn_Num_Negate.Click += new System.EventHandler(this.NegateBtnClick);
            // 
            // m_Btn_Op_Clear
            // 
            this.m_Btn_Op_Clear.BackColor = System.Drawing.Color.White;
            this.m_Btn_Op_Clear.ForeColor = System.Drawing.Color.DimGray;
            this.m_Btn_Op_Clear.Location = new System.Drawing.Point(134, 55);
            this.m_Btn_Op_Clear.Name = "m_Btn_Op_Clear";
            this.m_Btn_Op_Clear.Size = new System.Drawing.Size(30, 61);
            this.m_Btn_Op_Clear.TabIndex = 0;
            this.m_Btn_Op_Clear.TabStop = false;
            this.m_Btn_Op_Clear.Text = "C";
            this.m_Btn_Op_Clear.UseVisualStyleBackColor = false;
            this.m_Btn_Op_Clear.Click += new System.EventHandler(this.ClearBtnClick);
            // 
            // m_TxtDisplay
            // 
            this.m_TxtDisplay.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_TxtDisplay.Location = new System.Drawing.Point(10, 27);
            this.m_TxtDisplay.Name = "m_TxtDisplay";
            this.m_TxtDisplay.ReadOnly = true;
            this.m_TxtDisplay.Size = new System.Drawing.Size(153, 21);
            this.m_TxtDisplay.TabIndex = 1;
            this.m_TxtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_Btn_Op_Ok
            // 
            this.m_Btn_Op_Ok.BackColor = System.Drawing.Color.White;
            this.m_Btn_Op_Ok.ForeColor = System.Drawing.Color.DimGray;
            this.m_Btn_Op_Ok.Image = Properties.Resources.check;
            this.m_Btn_Op_Ok.Location = new System.Drawing.Point(134, 117);
            this.m_Btn_Op_Ok.Name = "m_Btn_Op_Ok";
            this.m_Btn_Op_Ok.Size = new System.Drawing.Size(30, 61);
            this.m_Btn_Op_Ok.TabIndex = 0;
            this.m_Btn_Op_Ok.TabStop = false;
            this.m_Btn_Op_Ok.UseVisualStyleBackColor = false;
            this.m_Btn_Op_Ok.Click += new System.EventHandler(this.OkBtnClick);
            // 
            // m_Btn_Op_Cancel
            // 
            this.m_Btn_Op_Cancel.BackColor = System.Drawing.Color.White;
            this.m_Btn_Op_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_Btn_Op_Cancel.ForeColor = System.Drawing.Color.DimGray;
            this.m_Btn_Op_Cancel.Image = Properties.Resources.x;
            this.m_Btn_Op_Cancel.Location = new System.Drawing.Point(134, 179);
            this.m_Btn_Op_Cancel.Name = "m_Btn_Op_Cancel";
            this.m_Btn_Op_Cancel.Size = new System.Drawing.Size(30, 30);
            this.m_Btn_Op_Cancel.TabIndex = 0;
            this.m_Btn_Op_Cancel.TabStop = false;
            this.m_Btn_Op_Cancel.UseVisualStyleBackColor = false;
            this.m_Btn_Op_Cancel.Click += new System.EventHandler(this.CancelBtnClick);
            // 
            // m_LblTitle
            // 
            this.m_LblTitle.AutoSize = true;
            this.m_LblTitle.ForeColor = System.Drawing.Color.White;
            this.m_LblTitle.Location = new System.Drawing.Point(7, 8);
            this.m_LblTitle.Name = "m_LblTitle";
            this.m_LblTitle.Size = new System.Drawing.Size(64, 13);
            this.m_LblTitle.TabIndex = 2;
            this.m_LblTitle.Text = "Calculator";
            // 
            // CalculatorPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.m_Btn_Op_Cancel;
            this.ClientSize = new System.Drawing.Size(174, 220);
            this.Controls.Add(this.m_LblTitle);
            this.Controls.Add(this.m_TxtDisplay);
            this.Controls.Add(this.m_Btn_Num_Negate);
            this.Controls.Add(this.m_Btn_Num_Dot);
            this.Controls.Add(this.m_Btn_Op_Enter);
            this.Controls.Add(this.m_Btn_Num_3);
            this.Controls.Add(this.m_Btn_Num_6);
            this.Controls.Add(this.m_Btn_Op_Ok);
            this.Controls.Add(this.m_Btn_Op_Clear);
            this.Controls.Add(this.m_Btn_Op_Subtract);
            this.Controls.Add(this.m_Btn_Op_Add);
            this.Controls.Add(this.m_Btn_Op_Multiply);
            this.Controls.Add(this.m_Btn_Num_9);
            this.Controls.Add(this.m_Btn_Num_2);
            this.Controls.Add(this.m_Btn_Num_5);
            this.Controls.Add(this.m_Btn_Op_Percent);
            this.Controls.Add(this.m_Btn_Op_Divide);
            this.Controls.Add(this.m_Btn_Num_8);
            this.Controls.Add(this.m_Btn_Op_Cancel);
            this.Controls.Add(this.m_Btn_Num_0);
            this.Controls.Add(this.m_Btn_Num_1);
            this.Controls.Add(this.m_Btn_Num_4);
            this.Controls.Add(this.m_Btn_Num_7);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "CalculatorPanel";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The m BTN number 7
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Num_7;
        /// <summary>
        /// The m BTN number 8
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Num_8;
        /// <summary>
        /// The m BTN number 9
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Num_9;
        /// <summary>
        /// The m BTN number 5
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Num_5;
        /// <summary>
        /// The m BTN number 6
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Num_6;
        /// <summary>
        /// The m BTN number 1
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Num_1;
        /// <summary>
        /// The m BTN number 2
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Num_2;
        /// <summary>
        /// The m BTN number 3
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Num_3;
        /// <summary>
        /// The m BTN op divide
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Op_Divide;
        /// <summary>
        /// The m BTN op multiply
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Op_Multiply;
        /// <summary>
        /// The m BTN number 0
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Num_0;
        /// <summary>
        /// The m BTN number dot
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Num_Dot;
        /// <summary>
        /// The m BTN op add
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Op_Add;
        /// <summary>
        /// The m BTN op subtract
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Op_Subtract;
        /// <summary>
        /// The m BTN op enter
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Op_Enter;
        /// <summary>
        /// The m BTN op percent
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Op_Percent;
        /// <summary>
        /// The m BTN number negate
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Num_Negate;
        /// <summary>
        /// The m BTN op cancel
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Op_Cancel;
        /// <summary>
        /// The m BTN number 4
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Num_4;
        /// <summary>
        /// The m BTN op clear
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Op_Clear;
        /// <summary>
        /// The m text display
        /// </summary>
        private System.Windows.Forms.TextBox m_TxtDisplay;
        /// <summary>
        /// The m BTN op ok
        /// </summary>
        private System.Windows.Forms.Button m_Btn_Op_Ok;
        /// <summary>
        /// The m label title
        /// </summary>
        private System.Windows.Forms.Label m_LblTitle;
    }

    #endregion

    #endregion

    #region ZeroitCalculatorButton

    #region Control
    /// <summary>
    /// A custom button control that pops up a CalculatorPanel.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitImageButton" />
    [Designer(typeof(ZeroitCalculatorButtonDesigner))]
    public partial class ZeroitCalculatorButton : ZeroitImageButton
    {
        #region State

        /// <summary>
        /// The m show modal
        /// </summary>
        private bool m_ShowModal = false;
        /// <summary>
        /// The m is prevented
        /// </summary>
        private bool m_IsPrevented = false;
        /// <summary>
        /// The m result control
        /// </summary>
        private Control m_ResultControl;
        /// <summary>
        /// The m start value
        /// </summary>
        private string m_StartValue = String.Empty;
        /// <summary>
        /// The m calculate panel
        /// </summary>
        private CalculatorPanel m_CalcPanel;
        /// <summary>
        /// The m calculator back color
        /// </summary>
        private Color m_CalculatorBackColor = Color.Black;
        /// <summary>
        /// The m calculator border color
        /// </summary>
        private Color m_CalculatorBorderColor = Color.White;
        /// <summary>
        /// The m calculator title color
        /// </summary>
        private Color m_CalculatorTitleColor = Color.White;
        /// <summary>
        /// The m calculator number color
        /// </summary>
        private Color m_CalculatorNumberColor = Color.Black;
        /// <summary>
        /// The m calculator operator color
        /// </summary>
        private Color m_CalculatorOperatorColor = Color.DimGray;
        /// <summary>
        /// The m button flat style
        /// </summary>
        private FlatStyle m_ButtonFlatStyle = FlatStyle.Standard;
        /// <summary>
        /// The m calculator parse
        /// </summary>
        private EventHandler<CalculatorParseEventArgs> m_CalculatorParse;
        /// <summary>
        /// The m calculator format
        /// </summary>
        private EventHandler<CalculatorFormatEventArgs> m_CalculatorFormat;
        /// <summary>
        /// The m calculator heading
        /// </summary>
        private string m_CalculatorHeading = "Calculator";
        /// <summary>
        /// The m automatic evaluate percent key
        /// </summary>
        private bool m_AutoEvaluatePercentKey = false;

        #endregion //--State


        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCalculatorButton"/> class.
        /// </summary>
        public ZeroitCalculatorButton() : base()
        {
            InitializeComponent();
        }
        #endregion //--Construction


        #region Event Handlers

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            CloseCalculator(false);
            if (m_IsPrevented)
            {
                m_IsPrevented = false;
                return;
            }
            if (null != m_ResultControl)
                m_ResultControl.Focus();
            m_CalcPanel = new CalculatorPanel();
            m_CalcPanel.ResultControl = ResultControl;
            m_CalcPanel.BorderColor = CalculatorBorderColor;
            m_CalcPanel.BackColor = CalculatorBackColor;
            m_CalcPanel.NumberColor = CalculatorNumberColor;
            m_CalcPanel.OperatorColor = CalculatorOperatorColor;
            m_CalcPanel.ButtonFlatStyle = ButtonFlatStyle;
            m_CalcPanel.Text = CalculatorHeading;
            m_CalcPanel.TitleColor = CalculatorTitleColor;
            m_CalcPanel.AutoEvaluatePercentKey = AutoEvaluatePercentKey;
            m_CalcPanel.AnchorControl = this;
            m_CalcPanel.Parse +=
                new EventHandler<CalculatorParseEventArgs>(CalcPanelParse);
            m_CalcPanel.Format +=
                new EventHandler<CalculatorFormatEventArgs>(CalcPanelFormat);
            if (m_ShowModal)
                m_CalcPanel.ShowDialog();
            else
                m_CalcPanel.Show();
        }

        /// <summary>
        /// Handles the <see cref="E:CalculatorParse" /> event.
        /// </summary>
        /// <param name="e">The <see cref="CalculatorParseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnCalculatorParse(CalculatorParseEventArgs e)
        {
            if (null != m_CalculatorParse)
                m_CalculatorParse(this, e);
        }

        /// <summary>
        /// Handles the <see cref="E:CalculatorFormat" /> event.
        /// </summary>
        /// <param name="e">The <see cref="CalculatorFormatEventArgs"/> instance containing the event data.</param>
        protected virtual void OnCalculatorFormat(CalculatorFormatEventArgs e)
        {
            if (null != m_CalculatorFormat)
                m_CalculatorFormat(this, e);
            if (null != m_ResultControl)
                m_ResultControl.Text = e.FormattedResult;
        }

        /// <summary>
        /// Calculates the panel parse.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CalculatorParseEventArgs"/> instance containing the event data.</param>
        private void CalcPanelParse(object sender, CalculatorParseEventArgs e)
        {
            OnCalculatorParse(e);
        }

        /// <summary>
        /// Calculates the panel format.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CalculatorFormatEventArgs"/> instance containing the event data.</param>
        private void CalcPanelFormat(object sender, CalculatorFormatEventArgs e)
        {
            OnCalculatorFormat(e);
        }
        #endregion //--Event Handlers


        #region Control Overrides

        /// <summary>
        /// Gets or sets the button image.
        /// </summary>
        /// <value>The button image.</value>
        [Browsable(false)]
        public override Image ButtonImage
        {
            get { return Properties.Resources.calc; }
            set { }
        }
        #endregion //--Control Overrides


        #region Public Interface

        /// <summary>
        /// Closes the calculator.
        /// </summary>
        /// <param name="acceptResult">if set to <c>true</c> [accept result].</param>
        public void CloseCalculator(bool acceptResult)
        {
            if (null != m_CalcPanel)
            {
                if (acceptResult)
                    m_CalcPanel.Accept();
                m_CalcPanel.Parse -=
                    new EventHandler<CalculatorParseEventArgs>(CalcPanelParse);
                m_CalcPanel.Format -=
                    new EventHandler<CalculatorFormatEventArgs>(CalcPanelFormat);
                if (!acceptResult)
                    m_CalcPanel.Close();
            }
        }

        /// <summary>
        /// Prevents the calculator.
        /// </summary>
        public void PreventCalculator()
        {
            m_IsPrevented = true;
        }

        /// <summary>
        /// Gets the current string result.
        /// </summary>
        /// <value>The current string result.</value>
        [Browsable(false)]
        public string CurrentStringResult
        {
            get
            {
                if (null == m_CalcPanel)
                    return String.Empty;

                return m_CalcPanel.StringResult;
            }
        }

        /// <summary>
        /// Gets the current result.
        /// </summary>
        /// <value>The current result.</value>
        [Browsable(false)]
        public double CurrentResult
        {
            get
            {
                if (null == m_CalcPanel)
                    return 0.0;

                return m_CalcPanel.Result;
            }
        }

        /// <summary>
        /// Gets or sets the start value.
        /// </summary>
        /// <value>The start value.</value>
        [Browsable(false)]
        [DefaultValue("")]
        public string StartValue
        {
            get { return m_StartValue; }
            set { m_StartValue = null == value ? String.Empty : value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show modal].
        /// </summary>
        /// <value><c>true</c> if [show modal]; otherwise, <c>false</c>.</value>
        [Category("Calculator")]
        [DefaultValue(false)]
        public bool ShowModal
        {
            get { return m_ShowModal; }
            set { m_ShowModal = value; }
        }

        /// <summary>
        /// Occurs when [calculator parse].
        /// </summary>
        [Category("Calculator")]
        public event EventHandler<CalculatorParseEventArgs> CalculatorParse
        {
            add { m_CalculatorParse += value; }
            remove { m_CalculatorParse -= value; }
        }

        /// <summary>
        /// Occurs when [calculator format].
        /// </summary>
        [Category("Calculator")]
        public event EventHandler<CalculatorFormatEventArgs> CalculatorFormat
        {
            add { m_CalculatorFormat += value; }
            remove { m_CalculatorFormat -= value; }
        }

        /// <summary>
        /// Gets or sets the result control.
        /// </summary>
        /// <value>The result control.</value>
        [Category("Calculator")]
        [DefaultValue(null)]
        public Control ResultControl
        {
            get { return m_ResultControl; }
            set
            {
                m_ResultControl = value;
                if (null != m_CalcPanel && !m_CalcPanel.IsDisposed)
                {
                    m_CalcPanel.ResultControl = value;
                    m_CalcPanel.Reposition();
                }
            }
        }

        //[Category("Appearance")]
        //[DefaultValue(typeof(Color), "Transparent")]
        //public override Color BackColor
        //{
        //    get { return base.BackColor; }
        //    set { base.BackColor = value; }
        //}

        /// <summary>
        /// Gets or sets the color of the calculator back.
        /// </summary>
        /// <value>The color of the calculator back.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "Black")]
        public Color CalculatorBackColor
        {
            get { return m_CalculatorBackColor; }
            set { m_CalculatorBackColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the calculator border.
        /// </summary>
        /// <value>The color of the calculator border.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "White")]
        public Color CalculatorBorderColor
        {
            get { return m_CalculatorBorderColor; }
            set { m_CalculatorBorderColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the calculator number.
        /// </summary>
        /// <value>The color of the calculator number.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "Black")]
        public Color CalculatorNumberColor
        {
            get { return m_CalculatorNumberColor; }
            set { m_CalculatorNumberColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the calculator operator.
        /// </summary>
        /// <value>The color of the calculator operator.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "DimGray")]
        public Color CalculatorOperatorColor
        {
            get { return m_CalculatorOperatorColor; }
            set { m_CalculatorOperatorColor = value; }
        }

        /// <summary>
        /// Gets or sets the button flat style.
        /// </summary>
        /// <value>The button flat style.</value>
        [Category("Calculator")]
        [DefaultValue(FlatStyle.Standard)]
        public FlatStyle ButtonFlatStyle
        {
            get { return m_ButtonFlatStyle; }
            set { m_ButtonFlatStyle = value; }
        }

        /// <summary>
        /// Gets or sets the calculator heading.
        /// </summary>
        /// <value>The calculator heading.</value>
        [Category("Calculator")]
        [DefaultValue("Calculator")]
        public string CalculatorHeading
        {
            get { return m_CalculatorHeading; }
            set { m_CalculatorHeading = value; }
        }

        /// <summary>
        /// Gets or sets the color of the calculator title.
        /// </summary>
        /// <value>The color of the calculator title.</value>
        [Category("Calculator")]
        [DefaultValue(typeof(Color), "White")]
        public Color CalculatorTitleColor
        {
            get { return m_CalculatorTitleColor; }
            set { m_CalculatorTitleColor = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic evaluate percent key].
        /// </summary>
        /// <value><c>true</c> if [automatic evaluate percent key]; otherwise, <c>false</c>.</value>
        [Category("Calculator")]
        [DefaultValue(false)]
        public bool AutoEvaluatePercentKey
        {
            get { return m_AutoEvaluatePercentKey; }
            set { m_AutoEvaluatePercentKey = value; }
        }
        #endregion //--Public Interface
    }
    #endregion

    #region Designer Generated Code

    partial class ZeroitCalculatorButton
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
            // ZeroitCalculatorButton
            // 
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
    /// Class ZeroitCalculatorButtonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitCalculatorButtonDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitCalculatorButtonSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitCalculatorButtonSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitCalculatorButtonSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitCalculatorButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCalculatorButtonSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitCalculatorButtonSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitCalculatorButton;

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

        /// <summary>
        /// Gets or sets a value indicating whether [show modal].
        /// </summary>
        /// <value><c>true</c> if [show modal]; otherwise, <c>false</c>.</value>
        public bool ShowModal
        {
            get
            {
                return colUserControl.ShowModal;
            }
            set
            {
                GetPropertyByName("ShowModal").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the result control.
        /// </summary>
        /// <value>The result control.</value>
        public Control ResultControl
        {
            get
            {
                return colUserControl.ResultControl;
            }
            set
            {
                GetPropertyByName("ResultControl").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the calculator back.
        /// </summary>
        /// <value>The color of the calculator back.</value>
        public Color CalculatorBackColor
        {
            get
            {
                return colUserControl.CalculatorBackColor;
            }
            set
            {
                GetPropertyByName("CalculatorBackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the calculator border.
        /// </summary>
        /// <value>The color of the calculator border.</value>
        public Color CalculatorBorderColor
        {
            get
            {
                return colUserControl.CalculatorBorderColor;
            }
            set
            {
                GetPropertyByName("CalculatorBorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the calculator number.
        /// </summary>
        /// <value>The color of the calculator number.</value>
        public Color CalculatorNumberColor
        {
            get
            {
                return colUserControl.CalculatorNumberColor;
            }
            set
            {
                GetPropertyByName("CalculatorNumberColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the calculator operator.
        /// </summary>
        /// <value>The color of the calculator operator.</value>
        public Color CalculatorOperatorColor
        {
            get
            {
                return colUserControl.CalculatorOperatorColor;
            }
            set
            {
                GetPropertyByName("CalculatorOperatorColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the button flat style.
        /// </summary>
        /// <value>The button flat style.</value>
        public FlatStyle ButtonFlatStyle
        {
            get
            {
                return colUserControl.ButtonFlatStyle;
            }
            set
            {
                GetPropertyByName("ButtonFlatStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the calculator heading.
        /// </summary>
        /// <value>The calculator heading.</value>
        public string CalculatorHeading
        {
            get
            {
                return colUserControl.CalculatorHeading;
            }
            set
            {
                GetPropertyByName("CalculatorHeading").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the calculator title.
        /// </summary>
        /// <value>The color of the calculator title.</value>
        public Color CalculatorTitleColor
        {
            get
            {
                return colUserControl.CalculatorTitleColor;
            }
            set
            {
                GetPropertyByName("CalculatorTitleColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic evaluate percent key].
        /// </summary>
        /// <value><c>true</c> if [automatic evaluate percent key]; otherwise, <c>false</c>.</value>
        public bool AutoEvaluatePercentKey
        {
            get
            {
                return colUserControl.AutoEvaluatePercentKey;
            }
            set
            {
                GetPropertyByName("AutoEvaluatePercentKey").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("ShowModal",
                                 "Show Modal", "Appearance",
                                 "Set to show the modal."));

            items.Add(new DesignerActionPropertyItem("AutoEvaluatePercentKey",
                                 "Auto Evaluate Percent Key", "Appearance",
                                 "Set to automatically evaluate the percent key."));

            items.Add(new DesignerActionPropertyItem("ResultControl",
                                 "Result Control", "Appearance",
                                 "Set the control to show the results of the calculator."));

            items.Add(new DesignerActionPropertyItem("CalculatorBackColor",
                                 "Calculator BackColor", "Appearance",
                                 "Sets the calculator backcolor."));

            items.Add(new DesignerActionPropertyItem("CalculatorBorderColor",
                                 "Calculator Border Color", "Appearance",
                                 "Sets the calculator border color."));

            items.Add(new DesignerActionPropertyItem("CalculatorNumberColor",
                                 "Calculator Number Color", "Appearance",
                                 "Sets the calculator number color."));

            items.Add(new DesignerActionPropertyItem("CalculatorOperatorColor",
                                 "Calculator Operator Color", "Appearance",
                                 "Sets the operator color."));

            items.Add(new DesignerActionPropertyItem("ButtonFlatStyle",
                                 "Button Flat Style", "Appearance",
                                 "Sets the button flat style of the control."));

            items.Add(new DesignerActionPropertyItem("CalculatorHeading",
                                 "Calculator Heading", "Appearance",
                                 "Sets the calculator heading."));

            items.Add(new DesignerActionPropertyItem("CalculatorTitleColor",
                                 "Calculator Title Color", "Appearance",
                                 "Sets the calculator title color."));


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

    #region Anchored Separator

    #region Control

    /// <summary>
    /// A class collection for rendering a seperator.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitSimpleSeparate" />
    [Designer(typeof(ZeroitAnchoredSeparatorDesigner))]
    public partial class ZeroitAnchoredSeparator : ZeroitSimpleSeparate
    {
        /// <summary>
        /// The m anchor
        /// </summary>
        private AnchorStyles m_Anchor =
            AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAnchoredSeparator" /> class.
        /// </summary>
        public ZeroitAnchoredSeparator()
        {
            base.Anchor = m_Anchor;
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the edges of the container to which a control is bound and determines how a control is resized with its parent.
        /// </summary>
        /// <value>The anchor.</value>
        [Category("Layout")]
        [DefaultValue(AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right)]
        public override AnchorStyles Anchor
        {
            get { return m_Anchor; }
            set
            {
                m_Anchor = value;
                base.Anchor = value;
            }
        }
    }
    #endregion

    #region Designer Generated Code
    partial class ZeroitAnchoredSeparator
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
            components = new System.ComponentModel.Container();
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
    /// Class ZeroitAnchoredSeparatorDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitAnchoredSeparatorDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitAnchoredSeparatorSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitAnchoredSeparatorSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitAnchoredSeparatorSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitAnchoredSeparator colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAnchoredSeparatorSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitAnchoredSeparatorSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitAnchoredSeparator;

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

        /// <summary>
        /// Gets or sets the color of the line.
        /// </summary>
        /// <value>The color of the line.</value>
        public Color LineColor
        {
            get { return colUserControl.LineColor; }
            set
            {
                GetPropertyByName("LineColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the line.
        /// </summary>
        /// <value>The width of the line.</value>
        public int LineWidth
        {
            get { return colUserControl.LineWidth; }
            set
            {
                GetPropertyByName("LineWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text line gap.
        /// </summary>
        /// <value>The text line gap.</value>
        public int TextLineGap
        {
            get { return colUserControl.TextLineGap; }
            set
            {
                GetPropertyByName("TextLineGap").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("LineColor",
                                 "Line Color", "Appearance",
                                 "Sets the color of the line."));

            items.Add(new DesignerActionPropertyItem("LineWidth",
                                 "Line Width", "Appearance",
                                 "Sets the width of the line."));

            items.Add(new DesignerActionPropertyItem("TextLineGap",
                                 "Text Line Gap", "Appearance",
                                 "Sets the gap between the line and the text."));

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
