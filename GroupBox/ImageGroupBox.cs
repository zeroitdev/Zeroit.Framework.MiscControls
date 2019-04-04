// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ImageGroupBox.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms.VisualStyles;

namespace Zeroit.Framework.MiscControls
{

    #region Image Group Box

    #region Control    
    /// <summary>
    /// A class collection for rendering an image group box.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.GroupBox" />
    [Designer(typeof(ZeroitImageGroupBoxDesigner))]
    public class ZeroitImageGroupBox : GroupBox
    {

        #region Private Fields
        /// <summary>
        /// Contain a reference to the icon to be painted in the header area.
        /// </summary>
        private Icon m_Icon = null;
        /// <summary>
        /// Contain a reference to the VisualStyleRenderer object that will help in drawing visual styles effects.
        /// </summary>
        private VisualStyleRenderer m_Renderer = null;

        #endregion

        #region Public Properties
        /// <summary>
        /// Get or set the icon to be painted in the header area.
        /// </summary>
        /// <value>The icon.</value>
        [Description("Icon before the text"), AmbientValue((string)null), Category("Appearance"), Localizable(true)]
        public Icon Icon
        {
            get { return m_Icon; }
            set { if (m_Icon != value) { m_Icon = value; this.Invalidate(false); } }
        }
        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Override the GroupBox OnPaint method for customized drawing.
        /// </summary>
        /// <param name="e">The PaintEventArgs associated object.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // This override only draws the control if the icon is not null. Otherwise, the base method is called
            if (m_Icon != null && (Application.RenderWithVisualStyles && (base.Width >= 10)) && (base.Height >= 10))
            {
                // Draw the entire control
                DrawGroupBox(e.Graphics);
            }
            else base.OnPaint(e);
        }

        /// <summary>
        /// Draw the entire control with visual styles effects.
        /// </summary>
        /// <param name="grfx">The Graphics object in which the control must painted to.</param>
        private void DrawGroupBox(Graphics grfx)
        {
            // Set the enabled state of the control
            System.Windows.Forms.VisualStyles.GroupBoxState state = base.Enabled ? GroupBoxState.Normal : GroupBoxState.Disabled;
            // Set the flags of TextFormat
            TextFormatFlags txtflags = TextFormatFlags.PreserveGraphicsTranslateTransform | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;
            if (!this.ShowKeyboardCues) txtflags |= TextFormatFlags.HidePrefix;
            if (this.RightToLeft == RightToLeft.Yes) txtflags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            // The rectangle that bounds the control
            Rectangle bounds = new Rectangle(0, 0, base.Width, base.Height);
            // Initialize the renderer for visual styles
            InitializeRenderer((int)state);
            // Set the rectangle to display the Text
            Size txtsize = TextRenderer.MeasureText(grfx, base.Text, base.Font, new Size(bounds.Width - 14, bounds.Height));
            // The optimized height of the header
            int headerheight = Math.Max(m_Icon.Height, txtsize.Height);
            // Define the rectangle for the icon
            Rectangle iconrect = new Rectangle(9, (headerheight - m_Icon.Height) / 2, m_Icon.Width, m_Icon.Height);
            // Define the rectangle of the text
            Rectangle textrect = new Rectangle(new Point(iconrect.Right, (headerheight - txtsize.Height) / 2), txtsize);
            // Move the rectangles if needed by the txtflags
            if ((txtflags & TextFormatFlags.Right) == TextFormatFlags.Right)
            {
                iconrect.X = bounds.Right - iconrect.Right - 1;
                textrect.X = bounds.Right - textrect.Right - 1;
            }
            // Define the rectangle that defines the inner container
            Rectangle displayrect = bounds; displayrect.Y += headerheight / 2; displayrect.Height -= headerheight / 2;
            // Draw the icon
            DrawIcon(grfx, m_Icon, iconrect, state);
            // Draw the text
            DrawText(grfx, this.Text, this.Font, textrect, m_Renderer.GetColor(ColorProperty.TextColor), this.BackColor, txtflags);
            // Draw the background
            DrawBackground(grfx, displayrect, textrect, m_Icon.Width, txtflags);
            // Clean up
            grfx.Dispose();
        }

        /// <summary>
        /// Draw an icon in a enabled or disabled state.
        /// </summary>
        /// <param name="grfx">The Graphics object in which the icon must painted to.</param>
        /// <param name="icon">The icon to be painted</param>
        /// <param name="rc">The rectangle that bounds the icon.</param>
        /// <param name="state">Specifies whether the icon must be painted in a disabled or endabled state.</param>
        private void DrawIcon(Graphics grfx, Icon icon, Rectangle rc, GroupBoxState state)
        {
            if (state == GroupBoxState.Disabled)
            {
                using (Image image = m_Icon.ToBitmap())
                {
                    // Draw the disabled icon
                    ControlPaint.DrawImageDisabled(grfx, image, rc.Left, rc.Top, Color.Empty);
                }
            }
            else
            {
                // Draw the enabled icon
                grfx.DrawIcon(icon, rc);
            }
        }

        /// <summary>
        /// Draw a text.
        /// </summary>
        /// <param name="grfx">The Graphics object in which the text must drawn to.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font used to draw the text.</param>
        /// <param name="bounds">The rectangle that bounds the text.</param>
        /// <param name="txtcolor">The fore color of the text.</param>
        /// <param name="backcolor">The color of the background of the text.</param>
        /// <param name="txtflags">Attributes to format the text.</param>
        private void DrawText(Graphics grfx, string text, Font font, Rectangle bounds, Color txtcolor, Color backcolor, TextFormatFlags txtflags)
        {
            TextRenderer.DrawText(grfx, text, font, bounds, txtcolor, backcolor, txtflags);
        }

        /// <summary>
        /// Draw the rounded rectangle of the control.
        /// </summary>
        /// <param name="grfx">The Graphics object in which the rectangle must drawn to.</param>
        /// <param name="bounds">The rectangle that bounds the rounded rectangle.</param>
        /// <param name="headerrect">The rectangle that bounds the header area.</param>
        /// <param name="iconwidth">The width of the icon of the header.</param>
        /// <param name="txtflags">The txtflags.</param>
        private void DrawBackground(Graphics grfx, Rectangle bounds, Rectangle headerrect, int iconwidth, TextFormatFlags txtflags)
        {
            Rectangle leftrect = bounds; leftrect.Width = 7;
            Rectangle middlerect = bounds; middlerect.Width = Math.Max(0, headerrect.Width + iconwidth);
            Rectangle rightrect = bounds;
            if ((txtflags & TextFormatFlags.Right) == TextFormatFlags.Right)
            {
                leftrect.X = bounds.Right - 7;
                middlerect.X = leftrect.Left - middlerect.Width;
                rightrect.Width = middlerect.X - bounds.X;
            }
            else
            {
                middlerect.X = leftrect.Right;
                rightrect.X = middlerect.Right;
                rightrect.Width = bounds.Right - rightrect.X;
            }
            middlerect.Y = headerrect.Bottom;
            middlerect.Height -= headerrect.Bottom - bounds.Top;
            //VisualStyleRenderer visualstylerenderer = this.CreateRenderer((int)state);
            // Left part
            m_Renderer.DrawBackground(grfx, bounds, leftrect);
            // Middle part
            m_Renderer.DrawBackground(grfx, bounds, middlerect);
            // Right part
            m_Renderer.DrawBackground(grfx, bounds, rightrect);
        }

        /// <summary>
        /// Get the color of a text, while the container control is disabled, rendering a disbaled text effect.
        /// </summary>
        /// <param name="backcolor">The backcolor.</param>
        /// <returns>The disabled color of the text.</returns>
        private Color DisabledTextColor(Color backcolor)
        {
            return GetLuminosity(backcolor) < GetLuminosity(SystemColors.Control) ? ControlPaint.Dark(backcolor) : SystemColors.ControlDark;
        }

        /// <summary>
        /// Get the luminosity of a color.
        /// </summary>
        /// <param name="color">The color to be analyzed.</param>
        /// <returns>The luminosity of the color.</returns>
        private int GetLuminosity(Color color)
        {
            int num = Math.Max(Math.Max(color.R, color.G), color.B) + Math.Min(Math.Min(color.R, color.G), color.B);
            return ((num * 240) + 0xff) / 510;
        }

        /// <summary>
        /// Initialize the renderer.
        /// </summary>
        /// <param name="state">The state of the control.</param>
        private void InitializeRenderer(int state)
        {
            VisualStyleElement visualstyleelement = VisualStyleElement.Button.GroupBox.Normal;
            if (m_Renderer == null) m_Renderer = new VisualStyleRenderer(visualstyleelement.ClassName, visualstyleelement.Part, state);
            else m_Renderer.SetParameters(visualstyleelement.ClassName, visualstyleelement.Part, state);
        }

        #endregion

    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitImageGroupBoxDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitImageGroupBoxDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitImageGroupBoxDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitImageGroupBoxSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitImageGroupBoxSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitImageGroupBoxSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitImageGroupBox colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitImageGroupBoxSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitImageGroupBoxSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitImageGroupBox;

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
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        public Icon Icon
        {
            get
            {
                return colUserControl.Icon;
            }
            set
            {
                GetPropertyByName("Icon").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Icon",
                                 "Icon", "Appearance",
                                 "Sets the Icon."));


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
