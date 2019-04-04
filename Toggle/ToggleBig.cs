// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ToggleBig.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region  Toggle Button Big    
    /// <summary>
    /// A class collection for rendering a toggle control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("ToggledChanged")]
    [Designer(typeof(ZeroitToggleBigDesigner))]
    public class ZeroitToggleBig : Control
    {
        #region Variables
        /// <summary>
        /// The handle switched1
        /// </summary>
        private Color handleSwitched1 = Color.FromArgb(231, 108, 58);
        /// <summary>
        /// The handle switched2
        /// </summary>
        private Color handleSwitched2 = Color.FromArgb(236, 113, 63);

        /// <summary>
        /// The handle idle1
        /// </summary>
        private Color handleIdle1 = Color.FromArgb(192, 192, 255);
        /// <summary>
        /// The handle idle2
        /// </summary>
        private Color handleIdle2 = Color.FromArgb(192, 255, 255);

        /// <summary>
        /// The switched background1
        /// </summary>
        private Color switchedBackground1 = Color.FromArgb(192, 255, 192);
        /// <summary>
        /// The switched background2
        /// </summary>
        private Color switchedBackground2 = Color.FromArgb(255, 255, 128);

        /// <summary>
        /// The border toggled
        /// </summary>
        private Color borderToggled = Color.Black;
        /// <summary>
        /// The border un toggled
        /// </summary>
        private Color borderUnToggled = Color.Black;


        #endregion

        #region  Enums

        /// <summary>
        /// Enum representing the type of toggle
        /// </summary>
        public enum ToggleType
        {
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
            IO,
            /// <summary>
            /// The start stop
            /// </summary>
            StartStop,
            /// <summary>
            /// The play pause
            /// </summary>
            PlayPause,
            /// <summary>
            /// The hide show
            /// </summary>
            HideShow,
            /// <summary>
            /// The open close
            /// </summary>
            OpenClose
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
        /// The type
        /// </summary>
        private ToggleType type;
        /// <summary>
        /// The bar
        /// </summary>
        private Rectangle Bar;
        /// <summary>
        /// The c handle
        /// </summary>
        private Size cHandle = new Size(15, 20);

        /// <summary>
        /// The font
        /// </summary>
        private Font font = new Font("Tahoma", 9.7f, FontStyle.Regular);

        #endregion

        #region  Properties

        #region Smoothing
        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }
        #endregion

        /// <summary>
        /// Gets or sets the type of the font.
        /// </summary>
        /// <value>The type of the font.</value>
        public Font FontType
        {
            get { return font; }
            set
            {
                font = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the handle switched.
        /// </summary>
        /// <value>The handle switched1.</value>
        public Color HandleSwitched1
        {
            get { return handleSwitched1; }
            set
            {
                handleSwitched1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the handle switched.
        /// </summary>
        /// <value>The handle switched2.</value>
        public Color HandleSwitched2
        {
            get { return handleSwitched2; }
            set
            {
                handleSwitched2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value>The background idle1.</value>
        public Color BackgroundIdle1
        {
            get { return handleIdle1; }
            set
            {
                handleIdle1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value>The background idle2.</value>
        public Color BackgroundIdle2
        {
            get { return handleIdle2; }
            set
            {
                handleIdle2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the handle color.
        /// </summary>
        /// <value>The handle color1.</value>
        public Color HandleColor1
        {
            get { return switchedBackground1; }
            set
            {
                switchedBackground1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the handle color.
        /// </summary>
        /// <value>The handle color2.</value>
        public Color HandleColor2
        {
            get { return switchedBackground2; }
            set
            {
                switchedBackground2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border when toggled.
        /// </summary>
        /// <value>The border toggled.</value>
        public Color BorderToggled
        {
            get { return borderToggled; }
            set
            {
                borderToggled = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border when not toggled.
        /// </summary>
        /// <value>The border when not toggled.</value>
        public Color BorderUnToggled
        {
            get { return borderUnToggled; }
            set
            {
                borderUnToggled = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitToggleBig" /> is toggled.
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
        public ToggleType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
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
            Width = 79;
            Height = 27;
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
        /// Initializes a new instance of the <see cref="ZeroitToggleBig" /> class.
        /// </summary>
        public ZeroitToggleBig()
        {
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor), true);
            BackColor = Color.Transparent;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            G.SmoothingMode = smoothing;
            //G.Clear(Parent.BackColor);

            int SwitchXLoc = 3;
            Rectangle ControlRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath ControlPath = RoundRectangle.RoundRect(ControlRectangle, 4);

            LinearGradientBrush BackgroundLGB = default(LinearGradientBrush);
            if (_Toggled)
            {
                SwitchXLoc = 37;
                BackgroundLGB = new LinearGradientBrush(ControlRectangle, handleSwitched1, handleSwitched2, 90.0F);
            }
            else
            {
                SwitchXLoc = 0;
                BackgroundLGB = new LinearGradientBrush(ControlRectangle, handleIdle1, handleIdle2, 90.0F);
            }

            // Fill inside background gradient
            G.FillPath(BackgroundLGB, ControlPath);

            // Draw string
            switch (Type)
            {
                case ToggleType.OnOff:
                    if (Toggled)
                    {
                        G.DrawString("ON", font, Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("OFF", font, Brushes.DimGray, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case ToggleType.YesNo:
                    if (Toggled)
                    {
                        G.DrawString("YES", font, Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("NO", font, Brushes.DimGray, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case ToggleType.IO:
                    if (Toggled)
                    {
                        G.DrawString("I", font, Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("O", font, Brushes.DimGray, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case ToggleType.StartStop:
                    if (Toggled)
                    {
                        G.DrawString("Start", font, Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("Stop", font, Brushes.DimGray, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case ToggleType.PlayPause:
                    if (Toggled)
                    {
                        G.DrawString("Play", font, Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("Pause", font, Brushes.DimGray, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case ToggleType.HideShow:
                    if (Toggled)
                    {
                        G.DrawString("Hide", font, Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("Show", font, Brushes.DimGray, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case ToggleType.OpenClose:
                    if (Toggled)
                    {
                        G.DrawString("Open", font, Brushes.WhiteSmoke, Bar.X + 18, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    else
                    {
                        G.DrawString("Close", font, Brushes.DimGray, Bar.X + 59, (float)(Bar.Y + 13.5), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
            }

            Rectangle SwitchRectangle = new Rectangle(SwitchXLoc, 0, Width - 38, Height);
            GraphicsPath SwitchPath = RoundRectangle.RoundRect(SwitchRectangle, 4);
            LinearGradientBrush SwitchButtonLGB = new LinearGradientBrush(SwitchRectangle, switchedBackground1, switchedBackground2, LinearGradientMode.Vertical);

            // Fill switch background gradient
            G.FillPath(SwitchButtonLGB, SwitchPath);

            // Draw borders
            if (_Toggled == true)
            {
                G.DrawPath(new Pen(borderToggled), SwitchPath);
                G.DrawPath(new Pen(borderToggled), ControlPath);
            }
            else
            {
                G.DrawPath(new Pen(borderUnToggled), SwitchPath);
                G.DrawPath(new Pen(borderUnToggled), ControlPath);
            }
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitToggleBigDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitToggleBigDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitToggleBigSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitToggleBigSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitToggleBigSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitToggleBig colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitToggleBigSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitToggleBigSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitToggleBig;

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
        /// Gets or sets the handle switched1.
        /// </summary>
        /// <value>The handle switched1.</value>
        public Color HandleSwitched1
        {
            get
            {
                return colUserControl.HandleSwitched1;
            }
            set
            {
                GetPropertyByName("HandleSwitched1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the handle switched2.
        /// </summary>
        /// <value>The handle switched2.</value>
        public Color HandleSwitched2
        {
            get
            {
                return colUserControl.HandleSwitched2;
            }
            set
            {
                GetPropertyByName("HandleSwitched2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background idle1.
        /// </summary>
        /// <value>The background idle1.</value>
        public Color BackgroundIdle1
        {
            get
            {
                return colUserControl.BackgroundIdle1;
            }
            set
            {
                GetPropertyByName("BackgroundIdle1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background idle2.
        /// </summary>
        /// <value>The background idle2.</value>
        public Color BackgroundIdle2
        {
            get
            {
                return colUserControl.BackgroundIdle2;
            }
            set
            {
                GetPropertyByName("BackgroundIdle2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the handle color1.
        /// </summary>
        /// <value>The handle color1.</value>
        public Color HandleColor1
        {
            get
            {
                return colUserControl.HandleColor1;
            }
            set
            {
                GetPropertyByName("HandleColor1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the handle color2.
        /// </summary>
        /// <value>The handle color2.</value>
        public Color HandleColor2
        {
            get
            {
                return colUserControl.HandleColor2;
            }
            set
            {
                GetPropertyByName("HandleColor2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border toggled.
        /// </summary>
        /// <value>The border toggled.</value>
        public Color BorderToggled
        {
            get
            {
                return colUserControl.BorderToggled;
            }
            set
            {
                GetPropertyByName("BorderToggled").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border un toggled.
        /// </summary>
        /// <value>The border un toggled.</value>
        public Color BorderUnToggled
        {
            get
            {
                return colUserControl.BorderUnToggled;
            }
            set
            {
                GetPropertyByName("BorderUnToggled").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public Zeroit.Framework.MiscControls.ZeroitToggleBig.ToggleType Type
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

        /// <summary>
        /// Gets or sets the type of the font.
        /// </summary>
        /// <value>The type of the font.</value>
        public Font FontType
        {
            get
            {
                return colUserControl.FontType;
            }
            set
            {
                GetPropertyByName("FontType").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get
            {
                return colUserControl.Smoothing;
            }
            set
            {
                GetPropertyByName("Smoothing").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Type",
                                 "Type", "Appearance",
                                 "Set the type of toggle."));

            items.Add(new DesignerActionPropertyItem("Smoothing",
                                 "Smoothing Mode", "Appearance",
                                 "Set the type of toggle."));

            items.Add(new DesignerActionPropertyItem("HandleSwitched1",
                                 "Handle Switched1", "Appearance",
                                 "Sets the handle color when switched."));

            items.Add(new DesignerActionPropertyItem("HandleSwitched2",
                                 "Handle Switched2", "Appearance",
                                 "Sets the handle color when switched."));

            items.Add(new DesignerActionPropertyItem("BackgroundIdle1",
                                 "Background Idle1", "Appearance",
                                 "Sets the background color when idle."));

            items.Add(new DesignerActionPropertyItem("BackgroundIdle2",
                                 "Background Idle2", "Appearance",
                                 "Sets the background color when idle."));

            items.Add(new DesignerActionPropertyItem("HandleColor1",
                                 "Handle Color1", "Appearance",
                                 "Sets the handle color."));

            items.Add(new DesignerActionPropertyItem("HandleColor2",
                                 "Handle Color2", "Appearance",
                                 "Sets the handle color."));

            items.Add(new DesignerActionPropertyItem("BorderToggled",
                                 "Border Toggled", "Appearance",
                                 "Sets the border color when toggled."));

            items.Add(new DesignerActionPropertyItem("BorderUnToggled",
                                 "Border UnToggled", "Appearance",
                                 "Sets the border color when not toggled."));

            items.Add(new DesignerActionPropertyItem("FontType",
                                 "Font Type", "Appearance",
                                 "Sets the Font of the text."));

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
