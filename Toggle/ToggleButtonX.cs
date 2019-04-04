// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ToggleButtonX.cs" company="Zeroit Dev Technologies">
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
    #region  Toggle Button X    
    /// <summary>
    /// A class collection for rendering a toggle control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitToggleXDesigner))]
    [DefaultEvent("ToggledChanged")]
    public class ZeroitToggleX : Control
    {

        #region  Enums        
        /// <summary>
        /// Enum representing the type of toggle
        /// </summary>
        public enum TypeOfToggle
        {
            /// <summary>
            /// The check mark
            /// </summary>
            CheckMark,
            /// <summary>
            /// The on off
            /// </summary>
            OnOff,
            /// <summary>
            /// The yes no
            /// </summary>
            YesNo,
            /// <summary>
            /// The io
            /// </summary>
            IO
        }

        #endregion

        #region  Variables

        /// <summary>
        /// Delegate ToggledChangedEventHandler
        /// </summary>
        public delegate void ToggledChangedEventHandler();
        /// <summary>
        /// The toggled changed event
        /// </summary>
        private ToggledChangedEventHandler ToggledChangedEvent;

        /// <summary>
        /// Occurs when [toggled changed].
        /// </summary>
        public event ToggledChangedEventHandler ToggledChanged
        {
            add
            {
                ToggledChangedEvent = (ToggledChangedEventHandler)System.Delegate.Combine(ToggledChangedEvent, value);
            }
            remove
            {
                ToggledChangedEvent = (ToggledChangedEventHandler)System.Delegate.Remove(ToggledChangedEvent, value);
            }
        }

        /// <summary>
        /// The toggled
        /// </summary>
        private bool _Toggled;
        /// <summary>
        /// The toggle type
        /// </summary>
        private TypeOfToggle ToggleType;
        /// <summary>
        /// The bar
        /// </summary>
        private Rectangle Bar;
        /// <summary>
        /// The width
        /// </summary>
        private int _Width;
        /// <summary>
        /// The height
        /// </summary>
        private int _Height;

        /// <summary>
        /// The small background color
        /// </summary>
        private Color smallBackgroundColor = Color.FromArgb(66, 76, 85);
        /// <summary>
        /// The big background color
        /// </summary>
        private Color bigBackgroundColor = Color.FromArgb(32, 41, 50);

        /// <summary>
        /// The small background toggled color
        /// </summary>
        private Color smallBackgroundToggledColor = Color.FromArgb(181, 41, 42);
        /// <summary>
        /// The big background toggled color
        /// </summary>
        private Color bigBackgroundToggledColor = Color.FromArgb(32, 41, 50);

        /// <summary>
        /// The small background border color
        /// </summary>
        private Color smallBackgroundBorderColor = Color.Black;
        /// <summary>
        /// The big background border color
        /// </summary>
        private Color bigBackgroundBorderColor = Color.Black;

        #endregion

        #region  Properties

        /// <summary>
        /// Gets or sets the color of the small background.
        /// </summary>
        /// <value>The color of the small background.</value>
        public Color ColorSmallBackground
        {
            get { return smallBackgroundColor; }
            set
            {
                smallBackgroundColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the big background.
        /// </summary>
        /// <value>The color of the big background.</value>
        public Color ColorBigBackground
        {
            get { return bigBackgroundColor; }
            set
            {
                bigBackgroundColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the small background when toggled.
        /// </summary>
        /// <value>The color of the small background when toggled.</value>
        public Color ColorSmallBackgroundToggled
        {
            get { return smallBackgroundToggledColor; }
            set
            {
                smallBackgroundToggledColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the big background when toggled.
        /// </summary>
        /// <value>The color of the big background when toggled.</value>
        public Color ColorBigBackgroundToggled
        {
            get { return bigBackgroundToggledColor; }
            set
            {
                bigBackgroundToggledColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border color of the small background.
        /// </summary>
        /// <value>The border color of the small background border.</value>
        public Color ColorSmallBackgroundBorder
        {
            get { return smallBackgroundBorderColor; }
            set
            {
                smallBackgroundBorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border color of the big background.
        /// </summary>
        /// <value>The border color of the big background border.</value>
        public Color ColorBigBackgroundBorder
        {
            get { return bigBackgroundBorderColor; }
            set
            {
                bigBackgroundBorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitToggleX" /> is toggled.
        /// </summary>
        /// <value><c>true</c> if toggled; otherwise, <c>false</c>.</value>
        public bool Toggled
        {
            get
            {
                return _Toggled;
            }
            set
            {
                _Toggled = value;
                Invalidate();
                if (ToggledChangedEvent != null)
                    ToggledChangedEvent();
            }
        }

        /// <summary>
        /// Gets or sets the type of toggle.
        /// </summary>
        /// <value>The type.</value>
        public TypeOfToggle Type
        {
            get
            {
                return ToggleType;
            }
            set
            {
                ToggleType = value;
                Invalidate();
            }
        }

        #endregion

        #region  EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(76, 33);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Toggled = !Toggled;
            Focus();
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitToggleX" /> class.
        /// </summary>
        public ZeroitToggleX()
        {
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor), true);

            BackColor = Color.Transparent;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            System.Drawing.Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.HighQuality;
            //G.Clear(Parent.BackColor);
            _Width = Width - 1;
            _Height = Height - 1;

            GraphicsPath GP = default(GraphicsPath);
            GraphicsPath GP2 = new GraphicsPath();
            Rectangle BaseRect = new Rectangle(0, 0, _Width, _Height);
            Rectangle ThumbRect = new Rectangle(_Width / 2, 0, 38, _Height);

            G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            G.PixelOffsetMode = (System.Drawing.Drawing2D.PixelOffsetMode)2;
            G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            //G.Clear(BackColor);

            GP = RoundRectangle.RoundRect(BaseRect, 4);
            ThumbRect = new Rectangle(4, 4, 36, _Height - 8);
            GP2 = RoundRectangle.RoundRect(ThumbRect, 4);
            G.FillPath(new SolidBrush(bigBackgroundColor), GP);
            G.FillPath(new SolidBrush(smallBackgroundColor), GP2);
            G.DrawPath(new Pen(bigBackgroundBorderColor), GP);
            G.DrawPath(new Pen(smallBackgroundBorderColor), GP2);


            if (_Toggled)
            {
                GP = RoundRectangle.RoundRect(BaseRect, 4);
                ThumbRect = new Rectangle((_Width / 2) - 2, 4, 36, _Height - 8);
                GP2 = RoundRectangle.RoundRect(ThumbRect, 4);
                G.FillPath(new SolidBrush(bigBackgroundToggledColor), GP);
                G.FillPath(new SolidBrush(smallBackgroundToggledColor), GP2);
                G.DrawPath(new Pen(bigBackgroundBorderColor), GP);
                G.DrawPath(new Pen(smallBackgroundBorderColor), GP2);
            }

            // Draw string
            switch (ToggleType)
            {
                case TypeOfToggle.CheckMark:
                    if (Toggled)
                    {
                        G.DrawString("ü", new Font("Wingdings", 18, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, Bar.Y + 19, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("r", new Font("Marlett", 14, FontStyle.Regular), Brushes.DimGray, Bar.X + 59, Bar.Y + 18, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case TypeOfToggle.OnOff:
                    if (Toggled)
                    {
                        G.DrawString("ON", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, Bar.Y + 16, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("OFF", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DimGray, Bar.X + 57, Bar.Y + 16, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case TypeOfToggle.YesNo:
                    if (Toggled)
                    {
                        G.DrawString("YES", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 19, Bar.Y + 16, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("NO", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DimGray, Bar.X + 56, Bar.Y + 16, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case TypeOfToggle.IO:
                    if (Toggled)
                    {
                        G.DrawString("I", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, Bar.Y + 16, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("O", new Font("Segoe UI", 12, FontStyle.Regular), Brushes.DimGray, Bar.X + 57, Bar.Y + 16, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
            }
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitToggleXDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitToggleXDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitToggleXSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitToggleXSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitToggleXSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitToggleX colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitToggleXSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitToggleXSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitToggleX;

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
        /// Gets or sets the color small background.
        /// </summary>
        /// <value>The color small background.</value>
        public Color ColorSmallBackground
        {
            get
            {
                return colUserControl.ColorSmallBackground;
            }
            set
            {
                GetPropertyByName("ColorSmallBackground").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color big background.
        /// </summary>
        /// <value>The color big background.</value>
        public Color ColorBigBackground
        {
            get
            {
                return colUserControl.ColorBigBackground;
            }
            set
            {
                GetPropertyByName("ColorBigBackground").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color small background toggled.
        /// </summary>
        /// <value>The color small background toggled.</value>
        public Color ColorSmallBackgroundToggled
        {
            get
            {
                return colUserControl.ColorSmallBackgroundToggled;
            }
            set
            {
                GetPropertyByName("ColorSmallBackgroundToggled").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color big background toggled.
        /// </summary>
        /// <value>The color big background toggled.</value>
        public Color ColorBigBackgroundToggled
        {
            get
            {
                return colUserControl.ColorBigBackgroundToggled;
            }
            set
            {
                GetPropertyByName("ColorBigBackgroundToggled").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color small background border.
        /// </summary>
        /// <value>The color small background border.</value>
        public Color ColorSmallBackgroundBorder
        {
            get
            {
                return colUserControl.ColorSmallBackgroundBorder;
            }
            set
            {
                GetPropertyByName("ColorSmallBackgroundBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color big background border.
        /// </summary>
        /// <value>The color big background border.</value>
        public Color ColorBigBackgroundBorder
        {
            get
            {
                return colUserControl.ColorBigBackgroundBorder;
            }
            set
            {
                GetPropertyByName("ColorBigBackgroundBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public Zeroit.Framework.MiscControls.ZeroitToggleX.TypeOfToggle Type
        {
            get
            {
                return colUserControl.Type;
            }
            set
            {
                GetPropertyByName("Type").SetValue(colUserControl, value);
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
                                 "Sets the BackColor."));

            items.Add(new DesignerActionPropertyItem("ColorSmallBackground",
                                 "Color Small Background", "Appearance",
                                 "Sets the handle background color."));

            items.Add(new DesignerActionPropertyItem("ColorBigBackground",
                                 "Color Big Background", "Appearance",
                                 "Sets the background color."));

            items.Add(new DesignerActionPropertyItem("ColorSmallBackgroundToggled",
                                 "Color Small Background Toggled", "Appearance",
                                 "Sets the handle background color when toggled."));

            items.Add(new DesignerActionPropertyItem("ColorBigBackgroundToggled",
                                 "Color Big Background Toggled", "Appearance",
                                 "Sets the handle background color when toggled."));

            items.Add(new DesignerActionPropertyItem("ColorSmallBackgroundBorder",
                                 "Color Small Background Border", "Appearance",
                                 "Sets the handle border color."));

            items.Add(new DesignerActionPropertyItem("ColorBigBackgroundBorder",
                                 "Color Big Background Border", "Appearance",
                                 "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("Type",
                                 "Type", "Appearance",
                                 "Sets the type of toggle."));


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
