// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="RichTextBox.cs" company="Zeroit Dev Technologies">
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
    #region RichTextBox    
    /// <summary>
    /// A class collection for rendering a rich textbox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("TextChanged")]
    [Designer(typeof(ZeroitRichTextBoxDesigner))]
    public class ZeroitRichTextBox : Control
    {

        #region Variables

        /// <summary>
        /// The i talk RTB
        /// </summary>
        public ZeroitRichTBox iTalkRTB = new ZeroitRichTBox();
        /// <summary>
        /// The read only
        /// </summary>
        private bool _ReadOnly;
        /// <summary>
        /// The word wrap
        /// </summary>
        private bool _WordWrap;
        /// <summary>
        /// The automatic word selection
        /// </summary>
        private bool _AutoWordSelection;
        /// <summary>
        /// The shape
        /// </summary>
        private GraphicsPath Shape;

        /// <summary>
        /// The background color tb
        /// </summary>
        private Color backgroundColorTB = Color.White;
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.FromArgb(180, 180, 180);
        #endregion

        #region Brush Enum
        /// <summary>
        /// The background
        /// </summary>
        private Color background = Color.White;

        #endregion

        #region Properties



        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
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
        /// Gets or sets the background color text box.
        /// </summary>
        /// <value>The background color text box.</value>
        public Color BackgroundColorTextBox
        {
            get { return backgroundColorTB; }
            set
            {
                backgroundColorTB = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        public override string Text
        {
            get { return iTalkRTB.Text; }
            set
            {
                iTalkRTB.Text = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [read only].
        /// </summary>
        /// <value><c>true</c> if [read only]; otherwise, <c>false</c>.</value>
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (iTalkRTB != null)
                {
                    iTalkRTB.ReadOnly = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [word wrap].
        /// </summary>
        /// <value><c>true</c> if [word wrap]; otherwise, <c>false</c>.</value>
        public bool WordWrap
        {
            get { return _WordWrap; }
            set
            {
                _WordWrap = value;
                if (iTalkRTB != null)
                {
                    iTalkRTB.WordWrap = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [automatic word selection].
        /// </summary>
        /// <value><c>true</c> if [automatic word selection]; otherwise, <c>false</c>.</value>
        public bool AutoWordSelection
        {
            get { return _AutoWordSelection; }
            set
            {
                _AutoWordSelection = value;
                if (iTalkRTB != null)
                {
                    iTalkRTB.AutoWordSelection = value;
                }
            }
        }
        #endregion
        #region EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ForeColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnForeColorChanged(System.EventArgs e)
        {
            base.OnForeColorChanged(e);
            iTalkRTB.ForeColor = ForeColor;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.FontChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnFontChanged(System.EventArgs e)
        {
            base.OnFontChanged(e);
            iTalkRTB.Font = Font;
        }
        /// <summary>
        /// Handles the <see cref="E:PaintBackground" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            iTalkRTB.Size = new Size(Width - 13, Height - 11);
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);

            Shape = new GraphicsPath();
            var _Shape = Shape;
            _Shape.AddArc(0, 0, 10, 10, 180, 90);
            _Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            _Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            _Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            _Shape.CloseAllFigures();
        }

        /// <summary>
        /// Handles the TextChanged event of the  control.
        /// </summary>
        /// <param name="s">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void _TextChanged(object s, EventArgs e)
        {
            iTalkRTB.Text = Text;
        }

        #endregion

        /// <summary>
        /// Adds the rich text box.
        /// </summary>
        public void AddRichTextBox()
        {
            var _RTB = iTalkRTB;
            //_RTB.BackColor = backgroundColorTB;
            _RTB.Size = new Size(Width - 10, 100);
            _RTB.Location = new Point(7, 5);
            _RTB.Text = string.Empty;
            _RTB.BorderStyle = BorderStyle.None;
            _RTB.Font = new Font("Tahoma", 10);
            _RTB.Multiline = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRichTextBox"/> class.
        /// </summary>
        public ZeroitRichTextBox()
            : base()
        {

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            AddRichTextBox();
            Controls.Add(iTalkRTB);
            BackColor = Color.Transparent;
            ForeColor = Color.DimGray;

            Text = null;
            Font = new Font("Tahoma", 10);
            Size = new Size(150, 100);
            WordWrap = true;
            AutoWordSelection = false;
            DoubleBuffered = true;

            TextChanged += _TextChanged;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {

            base.OnPaint(e);
            Bitmap B = new Bitmap(this.Width, this.Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            iTalkRTB.BackColor = backgroundColorTB;

            G.Clear(Color.Transparent);

            G.FillPath(new SolidBrush(background), this.Shape);

            #region Brushes Paint
            
            #endregion
            G.DrawPath(new Pen(borderColor), this.Shape);
            G.Dispose();
            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            B.Dispose();
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitRichTextBoxDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitRichTextBoxDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitRichTextBoxSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitRichTextBoxSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitRichTextBoxSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitRichTextBox colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRichTextBoxSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitRichTextBoxSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitRichTextBox;

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
        /// Gets or sets a value indicating whether [word wrap].
        /// </summary>
        /// <value><c>true</c> if [word wrap]; otherwise, <c>false</c>.</value>
        public bool WordWrap
        {
            get
            {
                return colUserControl.WordWrap;
            }
            set
            {
                GetPropertyByName("WordWrap").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [automatic word selection].
        /// </summary>
        /// <value><c>true</c> if [automatic word selection]; otherwise, <c>false</c>.</value>
        public bool AutoWordSelection
        {
            get
            {
                return colUserControl.AutoWordSelection;
            }
            set
            {
                GetPropertyByName("AutoWordSelection").SetValue(colUserControl, value);
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
        /// Gets or sets the background color text box.
        /// </summary>
        /// <value>The background color text box.</value>
        public Color BackgroundColorTextBox
        {
            get
            {
                return colUserControl.BackgroundColorTextBox;
            }
            set
            {
                GetPropertyByName("BackgroundColorTextBox").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the border color of the control."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorTextBox",
                                 "Background Color TextBox", "Appearance",
                                 "Sets the background color for the inner-richtextbox color of the control."));

            
            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("Text",
                                 "Text", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("ReadOnly",
                                 "ReadOnly", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("WordWrap",
                                 "WordWrap", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("AutoWordSelection",
                                 "AutoWord Selection", "Appearance",
                                 "Type few characters to filter Cities."));

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
