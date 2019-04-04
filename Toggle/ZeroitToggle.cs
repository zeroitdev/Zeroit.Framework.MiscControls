// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ZeroitToggle.cs" company="Zeroit Dev Technologies">
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
    #region ZeroitToggle

    /// <summary>
    /// A class collection representing a toggle control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("ToggledChanged")]
    [Designer(typeof(ZeroitToggleDesigner))]
    public class ZeroitToggle : Control
    {

        #region Designer

        
        /// <summary>
        /// Class PillStyle.
        /// </summary>
        public class PillStyle
        {
            /// <summary>
            /// The left
            /// </summary>
            public bool Left;
            /// <summary>
            /// The right
            /// </summary>
            public bool Right;
        }

        /// <summary>
        /// Pills the specified rectangle.
        /// </summary>
        /// <param name="Rectangle">The rectangle.</param>
        /// <param name="PillStyle">The pill style.</param>
        /// <returns>GraphicsPath.</returns>
        public GraphicsPath Pill(Rectangle Rectangle, PillStyle PillStyle)
        {
            GraphicsPath functionReturnValue = default(GraphicsPath);
            functionReturnValue = new GraphicsPath();

            if (PillStyle.Left)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Height, Rectangle.Height), -270, 180);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y);
            }

            if (PillStyle.Right)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.X + Rectangle.Width - Rectangle.Height, Rectangle.Y, Rectangle.Height, Rectangle.Height), -90, 180);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height);
            }

            functionReturnValue.CloseAllFigures();
            return functionReturnValue;
        }

        /// <summary>
        /// Pills the specified x.
        /// </summary>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="Width">The width.</param>
        /// <param name="Height">The height.</param>
        /// <param name="PillStyle">The pill style.</param>
        /// <returns>System.Object.</returns>
        public object Pill(int X, int Y, int Width, int Height, PillStyle PillStyle)
        {
            return Pill(new Rectangle(X, Y, Width, Height), PillStyle);
        }

        #endregion

        #region Enums

        /// <summary>
        /// Enum representing the type of toggle
        /// </summary>
        public enum TypeOfToggle
        {
            /// <summary>
            /// The yes no
            /// </summary>
            YesNo,
            /// <summary>
            /// The on off
            /// </summary>
            OnOff,
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

        #region Variables

        /// <summary>
        /// The animation timer
        /// </summary>
        private System.Windows.Forms.Timer AnimationTimer = new System.Windows.Forms.Timer { Interval = 1 };
        /// <summary>
        /// The toggle location
        /// </summary>
        private int ToggleLocation = 0;
        /// <summary>
        /// Occurs when [toggled changed].
        /// </summary>
        public event ToggledChangedEventHandler ToggledChanged;
        /// <summary>
        /// Delegate ToggledChangedEventHandler
        /// </summary>
        public delegate void ToggledChangedEventHandler();
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
        /// The c handle
        /// </summary>
        private Size cHandle = new Size(15, 20);

        /// <summary>
        /// The color backcolor1
        /// </summary>
        private Color colorBackcolor1 = Color.FromArgb(250, 250, 250);
        /// <summary>
        /// The color backcolor2
        /// </summary>
        private Color colorBackcolor2 = Color.FromArgb(240, 240, 240);

        /// <summary>
        /// The color ellipse
        /// </summary>
        private Color colorEllipse = Color.FromArgb(249, 249, 249);
        /// <summary>
        /// The color ellipse border
        /// </summary>
        private Color colorEllipseBorder = Color.FromArgb(177, 177, 176);

        /// <summary>
        /// The color ellipse small
        /// </summary>
        private Color colorEllipseSmall = Color.FromArgb(249, 249, 249);
        /// <summary>
        /// The color ellipse small border
        /// </summary>
        private Color colorEllipseSmallBorder = Color.FromArgb(177, 177, 176);

        /// <summary>
        /// The font
        /// </summary>
        private Font font = new Font("Segoe UI", 7f, FontStyle.Regular);


        #endregion

        #region Properties        
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
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color backcolor1.</value>
        public Color ColorBackcolor1
        {
            get { return colorBackcolor1; }
            set
            {
                colorBackcolor1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color backcolor2.</value>
        public Color ColorBackcolor2
        {
            get { return colorBackcolor2; }
            set
            {
                colorBackcolor2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the ellipse.
        /// </summary>
        /// <value>The color ellipse.</value>
        public Color ColorEllipse
        {
            get { return colorEllipse; }
            set
            {
                colorEllipse = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border color of the ellipse.
        /// </summary>
        /// <value>The color ellipse border.</value>
        public Color ColorEllipseBorder
        {
            get { return colorEllipseBorder; }
            set
            {
                colorEllipseBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the small ellipse.
        /// </summary>
        /// <value>The color of the small ellipse.</value>
        public Color ColorEllipseSmall
        {
            get { return colorEllipseSmall; }
            set
            {
                colorEllipseSmall = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border color of the small ellipse.
        /// </summary>
        /// <value>The border color small ellipse.</value>
        public Color ColorEllipseSmallBorder
        {
            get { return colorEllipseSmallBorder; }
            set
            {
                colorEllipseSmallBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitToggle" /> is toggled.
        /// </summary>
        /// <value><c>true</c> if toggled; otherwise, <c>false</c>.</value>
        public bool Toggled
        {
            get { return _Toggled; }
            set
            {
                _Toggled = value;
                Invalidate();

                if (ToggledChanged != null)
                {
                    ToggledChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of toggle.
        /// </summary>
        /// <value>The type.</value>
        public TypeOfToggle Type
        {
            get { return ToggleType; }
            set
            {
                ToggleType = value;
                Invalidate();
            }
        }

        #endregion

        #region EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(47, 19);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Toggled = !Toggled;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitToggle" /> class.
        /// </summary>
        public ZeroitToggle()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            AnimationTimer.Tick += new EventHandler(AnimationTimer_Tick);

            BackColor = Color.Transparent;
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AnimationTimer.Start();
        }

        /// <summary>
        /// Handles the Tick event of the AnimationTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void AnimationTimer_Tick(object sender, EventArgs e)
        {
            //  Create a slide animation when toggled on/off
            if ((_Toggled == true))
            {
                if ((ToggleLocation < 100))
                {
                    ToggleLocation += 10;
                    this.Invalidate(false);
                }
            }
            else if ((ToggleLocation > 0))
            {
                ToggleLocation -= 10;
                this.Invalidate(false);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            //G.Clear(Parent.BackColor);
            checked
            {
                Point point = new Point(0, (int)Math.Round(unchecked((double)this.Height / 2.0 - (double)this.cHandle.Height / 2.0)));
                Point arg_A8_0 = point;
                Point point2 = new Point(0, (int)Math.Round(unchecked((double)this.Height / 2.0 + (double)this.cHandle.Height / 2.0)));
                LinearGradientBrush Gradient = new LinearGradientBrush(arg_A8_0, point2, colorBackcolor1, colorBackcolor2);
                this.Bar = new Rectangle(8, 10, this.Width - 21, this.Height - 21);

                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.FillPath(Gradient, (GraphicsPath)this.Pill(0, (int)Math.Round(unchecked((double)this.Height / 2.0 - (double)this.cHandle.Height / 2.0)), this.Width - 1, this.cHandle.Height - 5, new ZeroitToggle.PillStyle
                {
                    Left = true,
                    Right = true
                }));
                G.DrawPath(new Pen(colorEllipseBorder), (GraphicsPath)this.Pill(0, (int)Math.Round(unchecked((double)this.Height / 2.0 - (double)this.cHandle.Height / 2.0)), this.Width - 1, this.cHandle.Height - 5, new ZeroitToggle.PillStyle
                {
                    Left = true,
                    Right = true
                }));
                Gradient.Dispose();
                switch (this.ToggleType)
                {
                    case ZeroitToggle.TypeOfToggle.YesNo:
                        {
                            bool toggled = this.Toggled;
                            if (toggled)
                            {
                                G.DrawString("Yes", font, Brushes.Gray, (float)(this.Bar.X + 7), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            else
                            {
                                G.DrawString("No", font, Brushes.Gray, (float)(this.Bar.X + 18), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            break;
                        }
                    case ZeroitToggle.TypeOfToggle.OnOff:
                        {
                            bool toggled = this.Toggled;
                            if (toggled)
                            {
                                G.DrawString("On", font, Brushes.Gray, (float)(this.Bar.X + 7), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            else
                            {
                                G.DrawString("Off", font, Brushes.Gray, (float)(this.Bar.X + 18), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            break;
                        }
                    case ZeroitToggle.TypeOfToggle.IO:
                        {
                            bool toggled = this.Toggled;
                            if (toggled)
                            {
                                G.DrawString("I", font, Brushes.Gray, (float)(this.Bar.X + 7), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            else
                            {
                                G.DrawString("O", font, Brushes.Gray, (float)(this.Bar.X + 18), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            break;
                        }

                    case ZeroitToggle.TypeOfToggle.HideShow:
                        {
                            bool toggled = this.Toggled;
                            if (toggled)
                            {
                                G.DrawString("Show", font, Brushes.Gray, (float)(this.Bar.X + 7), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            else
                            {
                                G.DrawString("Hide", font, Brushes.Gray, (float)(this.Bar.X + 18), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            break;
                        }

                    case ZeroitToggle.TypeOfToggle.StartStop:
                        {
                            bool toggled = this.Toggled;
                            if (toggled)
                            {
                                G.DrawString("Start", font, Brushes.Gray, (float)(this.Bar.X + 7), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            else
                            {
                                G.DrawString("Stop", font, Brushes.Gray, (float)(this.Bar.X + 18), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            break;
                        }

                    case ZeroitToggle.TypeOfToggle.PlayPause:
                        {
                            bool toggled = this.Toggled;
                            if (toggled)
                            {
                                G.DrawString("Play", font, Brushes.Gray, (float)(this.Bar.X + 7), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            else
                            {
                                G.DrawString("Pause", font, Brushes.Gray, (float)(this.Bar.X + 18), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            break;
                        }

                    case ZeroitToggle.TypeOfToggle.OpenClose:
                        {
                            bool toggled = this.Toggled;
                            if (toggled)
                            {
                                G.DrawString("Open", font, Brushes.Gray, (float)(this.Bar.X + 7), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            else
                            {
                                G.DrawString("Close", font, Brushes.Gray, (float)(this.Bar.X + 18), (float)this.Bar.Y, new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                });
                            }
                            break;
                        }

                }
                G.FillEllipse(new SolidBrush(colorEllipseSmall), this.Bar.X + (int)Math.Round(unchecked((double)this.Bar.Width * ((double)this.ToggleLocation / 80.0))) - (int)Math.Round((double)this.cHandle.Width / 2.0), this.Bar.Y + (int)Math.Round((double)this.Bar.Height / 2.0) - (int)Math.Round(unchecked((double)this.cHandle.Height / 2.0 - 1.0)), this.cHandle.Width, this.cHandle.Height - 5);
                G.DrawEllipse(new Pen(colorEllipseSmallBorder), this.Bar.X + (int)Math.Round(unchecked((double)this.Bar.Width * ((double)this.ToggleLocation / 80.0) - (double)checked((int)Math.Round((double)this.cHandle.Width / 2.0)))), this.Bar.Y + (int)Math.Round((double)this.Bar.Height / 2.0) - (int)Math.Round(unchecked((double)this.cHandle.Height / 2.0 - 1.0)), this.cHandle.Width, this.cHandle.Height - 5);
            }
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitToggleDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitToggleDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitToggleSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitToggleSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitToggleSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitToggle colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitToggleSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitToggleSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitToggle;

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
        /// Gets or sets the color backcolor1.
        /// </summary>
        /// <value>The color backcolor1.</value>
        public Color ColorBackcolor1
        {
            get
            {
                return colUserControl.ColorBackcolor1;
            }
            set
            {
                GetPropertyByName("ColorBackcolor1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color backcolor2.
        /// </summary>
        /// <value>The color backcolor2.</value>
        public Color ColorBackcolor2
        {
            get
            {
                return colUserControl.ColorBackcolor2;
            }
            set
            {
                GetPropertyByName("ColorBackcolor2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color ellipse.
        /// </summary>
        /// <value>The color ellipse.</value>
        public Color ColorEllipse
        {
            get
            {
                return colUserControl.ColorEllipse;
            }
            set
            {
                GetPropertyByName("ColorEllipse").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color ellipse border.
        /// </summary>
        /// <value>The color ellipse border.</value>
        public Color ColorEllipseBorder
        {
            get
            {
                return colUserControl.ColorEllipseBorder;
            }
            set
            {
                GetPropertyByName("ColorEllipseBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color ellipse small.
        /// </summary>
        /// <value>The color ellipse small.</value>
        public Color ColorEllipseSmall
        {
            get
            {
                return colUserControl.ColorEllipseSmall;
            }
            set
            {
                GetPropertyByName("ColorEllipseSmall").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color ellipse small border.
        /// </summary>
        /// <value>The color ellipse small border.</value>
        public Color ColorEllipseSmallBorder
        {
            get
            {
                return colUserControl.ColorEllipseSmallBorder;
            }
            set
            {
                GetPropertyByName("ColorEllipseSmallBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public Zeroit.Framework.MiscControls.ZeroitToggle.TypeOfToggle Type
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
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ColorBackcolor1",
                                 "Color Back Color1", "Appearance",
                                 "Selects the gradient of the background color."));

            items.Add(new DesignerActionPropertyItem("ColorBackcolor2",
                                 "Color Back Color2", "Appearance",
                                 "Selects the gradient of the background color."));

            items.Add(new DesignerActionPropertyItem("ColorEllipse",
                                 "Color Ellipse", "Appearance",
                                 "Sets the color of the ellipse."));

            items.Add(new DesignerActionPropertyItem("ColorEllipseBorder",
                                 "Color Ellipse Border", "Appearance",
                                 "Sets the border color of the ellipse."));

            items.Add(new DesignerActionPropertyItem("ColorEllipseSmall",
                                "Color Ellipse Small", "Appearance",
                                "Sets the color of the ellipse."));

            items.Add(new DesignerActionPropertyItem("ColorEllipseSmallBorder",
                                 "Color Ellipse Small Border", "Appearance",
                                 "Sets the border color of the ellipse."));

            items.Add(new DesignerActionPropertyItem("Type",
                                 "Type", "Appearance",
                                 "Sets the border color of the ellipse."));

            items.Add(new DesignerActionPropertyItem("FontType",
                                 "FontType", "Appearance",
                                 "Sets the border color of the ellipse."));

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
