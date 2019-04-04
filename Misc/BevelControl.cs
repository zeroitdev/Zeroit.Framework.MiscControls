// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="BevelControl.cs" company="Zeroit Dev Technologies">
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
    #region Bevel Control

    #region Enums

    /// <summary>
    /// Enum representing the Bevel Style for <c><see cref="ZeroitBevelControl" /></c>.
    /// </summary>
    public enum BevelStyle
    {
        /// <summary>
        /// The lowered
        /// </summary>
        Lowered,
        /// <summary>
        /// The raised
        /// </summary>
        Raised
    }

    /// <summary>
    /// Enum representing the Bevel Type.
    /// </summary>
    public enum BevelType
    {
        /// <summary>
        /// The box
        /// </summary>
        Box,
        /// <summary>
        /// The frame
        /// </summary>
        Frame,
        /// <summary>
        /// The top line
        /// </summary>
        TopLine,
        /// <summary>
        /// The bottom line
        /// </summary>
        BottomLine,
        /// <summary>
        /// The left line
        /// </summary>
        LeftLine,
        /// <summary>
        /// The right line
        /// </summary>
        RightLine,
        /// <summary>
        /// The spacer
        /// </summary>
        Spacer
    }
    #endregion

    #region Control    
    /// <summary>
    /// A class collection for rendering a bevel control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitBevelControlDesigner))]
    public class ZeroitBevelControl : Control
    {
        #region private members
        /// <summary>
        /// The bevel style
        /// </summary>
        private BevelStyle _bevelStyle = BevelStyle.Lowered;
        /// <summary>
        /// The bevel type
        /// </summary>
        private BevelType _bevelType = BevelType.Box;
        /// <summary>
        /// The shadow color
        /// </summary>
        private Color _shadowColor = SystemColors.ButtonShadow;
        /// <summary>
        /// The highlight color
        /// </summary>
        private Color _highlightColor = SystemColors.ButtonHighlight;
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.Black;
        #endregion

        #region protected methods (painting)
        /// <summary>
        /// Gets the pen.
        /// </summary>
        /// <param name="iIndex">Index of the i.</param>
        /// <returns>Pen.</returns>
        protected virtual Pen GetPen(int iIndex)
        {
            //Color color = Color.Black;

            if (iIndex.Equals(0))
                borderColor = _bevelStyle.Equals(BevelStyle.Lowered) ? _shadowColor : _highlightColor;
            else
                borderColor = _bevelStyle.Equals(BevelStyle.Lowered) ? _highlightColor : _shadowColor;

            return new Pen(borderColor);
        }
        /// <summary>
        /// Bevels the rect.
        /// </summary>
        /// <param name="iGraphics">The i graphics.</param>
        /// <param name="iRect">The i rect.</param>
        protected virtual void BevelRect(Graphics iGraphics, Rectangle iRect)
        {
            using (Pen pen = GetPen(0))
            {
                iGraphics.DrawLine(pen, iRect.Left, iRect.Bottom, iRect.Left, iRect.Top);
                iGraphics.DrawLine(pen, iRect.Left, iRect.Top, iRect.Right, iRect.Top);
            }
            using (Pen pen = GetPen(1))
            {
                iGraphics.DrawLine(pen, iRect.Right, iRect.Top, iRect.Right, iRect.Bottom);
                iGraphics.DrawLine(pen, iRect.Right, iRect.Bottom, iRect.Left, iRect.Bottom);
            }
        }
        /// <summary>
        /// Frames the rect.
        /// </summary>
        /// <param name="iGraphics">The i graphics.</param>
        /// <param name="iRect">The i rect.</param>
        protected virtual void FrameRect(Graphics iGraphics, Rectangle iRect)
        {
            using (Pen pen = GetPen(1))
                iGraphics.DrawRectangle(pen, iRect);

            iRect = new Rectangle(iRect.Left - 1, iRect.Top - 1, iRect.Width, iRect.Height);
            using (Pen pen = GetPen(0))
                iGraphics.DrawRectangle(pen, iRect);
        }
        /// <summary>
        /// Bevels the line.
        /// </summary>
        /// <param name="iPen">The i pen.</param>
        /// <param name="iGraphics">The i graphics.</param>
        /// <param name="iX1">The i x1.</param>
        /// <param name="iY1">The i y1.</param>
        /// <param name="iX2">The i x2.</param>
        /// <param name="iY2">The i y2.</param>
        protected virtual void BevelLine(Pen iPen, Graphics iGraphics, int iX1, int iY1, int iX2, int iY2)
        {
            iGraphics.DrawLine(iPen, iX1, iY1, iX2, iY2);
        }
        /// <summary>
        /// Spacers the rect.
        /// </summary>
        /// <param name="iGraphics">The i graphics.</param>
        /// <param name="iRect">The i rect.</param>
        protected virtual void SpacerRect(Graphics iGraphics, Rectangle iRect)
        {
            //using (Pen pen = new Pen(Color.Black))
            //{
            //    pen.DashStyle = DashStyle.Dot;
            //    iGraphics.DrawRectangle(pen, iRect);
            //}

            using (Pen pen = new Pen(borderColor))
            {
                pen.DashStyle = DashStyle.Dot;
                iGraphics.DrawRectangle(pen, iRect);
            }
        }
        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="pe">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            base.OnPaint(pe);

            if (AllowTransparency)
            {
                MakeTransparent(this, pe.Graphics);
            }

            switch (_bevelType)
            {
                case BevelType.Box:
                    BevelRect(pe.Graphics, new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
                case BevelType.Frame:
                    FrameRect(pe.Graphics, new Rectangle(1, 1, Width - 2, Height - 2));
                    break;
                case BevelType.TopLine:
                    using (Pen pen = GetPen(0))
                        BevelLine(pen, pe.Graphics, 0, 0, Width, 0);
                    using (Pen pen = GetPen(1))
                        BevelLine(pen, pe.Graphics, 0, 1, Width, 1);
                    break;
                case BevelType.BottomLine:
                    using (Pen pen = GetPen(0))
                        BevelLine(pen, pe.Graphics, 0, Height - 2, Width, Height - 2);
                    using (Pen pen = GetPen(1))
                        BevelLine(pen, pe.Graphics, 0, Height - 1, Width, Height - 1);
                    break;
                case BevelType.LeftLine:
                    using (Pen pen = GetPen(0))
                        BevelLine(pen, pe.Graphics, 0, 0, 0, Height);
                    using (Pen pen = GetPen(1))
                        BevelLine(pen, pe.Graphics, 1, 0, 1, Height);
                    break;
                case BevelType.RightLine:
                    using (Pen pen = GetPen(0))
                        BevelLine(pen, pe.Graphics, Width - 2, 0, Width - 2, Height);
                    using (Pen pen = GetPen(1))
                        BevelLine(pen, pe.Graphics, Width - 1, 0, Width - 1, Height);
                    break;
                case BevelType.Spacer:
                    if (DesignMode)
                        SpacerRect(pe.Graphics, new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region public properties        
        /// <summary>
        /// Gets or sets the bevel style.
        /// </summary>
        /// <value>The bevel style.</value>
        [Category("Bevel"), Description("How to draw edge")]
        public BevelStyle BevelStyle
        {
            get { return _bevelStyle; }
            set { _bevelStyle = value; Refresh(); }
        }
        /// <summary>
        /// Gets or sets the type of the bevel.
        /// </summary>
        /// <value>The type of the bevel.</value>
        [Category("Bevel"), Description("Where to draw edge")]
        public BevelType BevelType
        {
            get { return _bevelType; }
            set { _bevelType = value; Refresh(); }
        }
        /// <summary>
        /// Gets or sets the color of the highlight.
        /// </summary>
        /// <value>The color of the highlight.</value>
        [Category("Bevel")]
        [BrowsableAttribute(true)]
        public Color HighlightColor
        {
            get { return _highlightColor; }
            set { _highlightColor = value; Refresh(); }
        }
        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        [Category("Bevel")]
        [BrowsableAttribute(true)]
        public Color ShadowColor
        {
            get { return _shadowColor; }
            set { _shadowColor = value; Refresh(); }
        }


        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Category("Bevel")]
        [BrowsableAttribute(true)]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Refresh(); }
        }
        #endregion






        #region Include in Private Field

        /// <summary>
        /// The allow transparency
        /// </summary>
        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow transparency].
        /// </summary>
        /// <value><c>true</c> if [allow transparency]; otherwise, <c>false</c>.</value>
        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion



        #region Include in Paint

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

        /// <summary>
        /// Makes the transparent.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="g">The g.</param>
        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
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
    /// Class ZeroitBevelControlDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitBevelControlDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitBevelControlSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitBevelControlSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitBevelControlSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitBevelControl colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBevelControlSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitBevelControlSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitBevelControl;

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

        #region public properties

        /// <summary>
        /// Gets or sets the bevel style.
        /// </summary>
        /// <value>The bevel style.</value>
        public BevelStyle BevelStyle
        {
            get
            {
                return colUserControl.BevelStyle;
            }
            set
            {
                GetPropertyByName("BevelStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the bevel.
        /// </summary>
        /// <value>The type of the bevel.</value>
        public BevelType BevelType
        {
            get
            {
                return colUserControl.BevelType;
            }
            set
            {
                GetPropertyByName("BevelType").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the highlight.
        /// </summary>
        /// <value>The color of the highlight.</value>
        public Color HighlightColor
        {
            get
            {
                return colUserControl.HighlightColor;
            }
            set
            {
                GetPropertyByName("HighlightColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        public Color ShadowColor
        {
            get
            {
                return colUserControl.ShadowColor;
            }
            set
            {
                GetPropertyByName("ShadowColor").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("BevelStyle",
                                 "Bevel Style", "Appearance",
                                 "Sets the bevel style."));

            items.Add(new DesignerActionPropertyItem("BevelType",
                                 "Bevel Type", "Appearance",
                                 "Sets the bevel type."));

            items.Add(new DesignerActionPropertyItem("HighlightColor",
                                 "Highlight Color", "Appearance",
                                 "Sets the highlight color."));

            items.Add(new DesignerActionPropertyItem("ShadowColor",
                                 "Shadow Color", "Appearance",
                                 "Sets the shadow color."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the border color."));

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
