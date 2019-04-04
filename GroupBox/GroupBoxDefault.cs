// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="GroupBoxDefault.cs" company="Zeroit Dev Technologies">
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
    #region GroupBox    
    /// <summary>
    /// A class collection for rendering a groupbox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    [Designer(typeof(ZeroitGroupBoxDefaultDesigner))]
    public class ZeroitGroupBoxDefault : ContainerControl
    {
        #region Variables
        /// <summary>
        /// The border title box
        /// </summary>
        private Color borderTitleBox = Color.FromArgb(182, 180, 186);
        /// <summary>
        /// The border title group box
        /// </summary>
        private Color borderTitleGroupBox = Color.FromArgb(159, 159, 161);

        #region Brush Enum
        /// <summary>
        /// The background
        /// </summary>
        private Color background = Color.White;

        /// <summary>
        /// The title box background
        /// </summary>
        Color titleBoxBackground = Color.Gray;
        #endregion
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the border title box.
        /// </summary>
        /// <value>The border title box.</value>
        public Color BorderTitleBox
        {
            get { return borderTitleBox; }
            set
            {
                borderTitleBox = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border title group box.
        /// </summary>
        /// <value>The border title group box.</value>
        public Color BorderTitleGroupBox
        {
            get { return borderTitleGroupBox; }
            set
            {
                borderTitleGroupBox = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type of the brush for the background.
        /// </summary>
        /// <value>The type of the brush.</value>
        public Color BrushType
        {
            get { return background; }
            set
            {
                background = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the brush type for the title box.
        /// </summary>
        /// <value>The brush type for the title box.</value>
        public Color BrushTypeTitleBox
        {
            get { return titleBoxBackground; }
            set
            {
                titleBoxBackground = value;
                Invalidate();
            }
        }


        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGroupBoxDefault" /> class.
        /// </summary>
        public ZeroitGroupBoxDefault()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            this.Size = new Size(212, 104);
            this.MinimumSize = new Size(136, 50);
            this.Padding = new Padding(5, 28, 5, 5);
        }

        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle TitleBox = new Rectangle(51, 3, Width - 103, 18);
            Rectangle box = new Rectangle(0, 0, Width - 1, Height - 10);

            G.Clear(Color.Transparent);
            G.SmoothingMode = SmoothingMode.HighQuality;

            // Draw the body of the GroupBox

            G.FillPath(new SolidBrush(BackColor), RoundRectangle.RoundRect(new Rectangle(1, 12, Width - 3, box.Height - 1), 8));

            
            // Draw the border of the GroupBox
            G.DrawPath(new Pen(borderTitleGroupBox), RoundRectangle.RoundRect(new Rectangle(1, 12, Width - 3, Height - 13), 8));

            // Draw the background of the title box
            
            G.FillPath(new SolidBrush(titleBoxBackground), RoundRectangle.RoundRect(TitleBox, 1));

            

            // Draw the border of the title box
            G.DrawPath(new Pen(borderTitleBox), RoundRectangle.RoundRect(TitleBox, 4));
            // Draw the specified string from 'Text' property inside the title box
            G.DrawString(Text, new Font("Tahoma", 9, FontStyle.Regular), new SolidBrush(Color.FromArgb(53, 53, 53)), TitleBox, new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        #endregion

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitGroupBoxDefaultDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitGroupBoxDefaultDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitGroupBoxDefaultSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitGroupBoxDefaultSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitGroupBoxDefaultSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitGroupBoxDefault colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGroupBoxDefaultSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitGroupBoxDefaultSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitGroupBoxDefault;

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
        /// Gets or sets the border title box.
        /// </summary>
        /// <value>The border title box.</value>
        public Color BorderTitleBox
        {
            get
            {
                return colUserControl.BorderTitleBox;
            }
            set
            {
                GetPropertyByName("BorderTitleBox").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border title group box.
        /// </summary>
        /// <value>The border title group box.</value>
        public Color BorderTitleGroupBox
        {
            get
            {
                return colUserControl.BorderTitleGroupBox;
            }
            set
            {
                GetPropertyByName("BorderTitleGroupBox").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Gets or sets the brush type title box.
        /// </summary>
        /// <value>The brush type title box.</value>
        public Color BrushTypeTitleBox
        {
            get
            {
                return colUserControl.BrushTypeTitleBox;
            }
            set
            {
                GetPropertyByName("BrushTypeTitleBox").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("BorderTitleBox",
                                 "Border TitleBox", "Appearance",
                                 "Sets the titlebox color."));

            items.Add(new DesignerActionPropertyItem("BrushType",
                                 "Brush Type", "Appearance",
                                 "Sets the inner-background color."));

            items.Add(new DesignerActionPropertyItem("BrushTypeTitleBox",
                                 "Brush Type TitleBox", "Appearance",
                                 "Sets the background color for the titlebox."));

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
