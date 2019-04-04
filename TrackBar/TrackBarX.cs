// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TrackBarX.cs" company="Zeroit Dev Technologies">
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
    #region  TrackBar X    
    /// <summary>
    /// A class collection for rendering a track bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitTrackBarXDesigner))]
    [DefaultEvent("ValueChanged")]
    public class ZeroitTrackBarX : Control
    {

        #region  Enums

        /// <summary>
        /// Enum representing a value divisor
        /// </summary>
        public enum ValueDivisor
        {
            /// <summary>
            /// The by1
            /// </summary>
            By1 = 1,
            /// <summary>
            /// The by10
            /// </summary>
            By10 = 10,
            /// <summary>
            /// The by100
            /// </summary>
            By100 = 100,
            /// <summary>
            /// The by1000
            /// </summary>
            By1000 = 1000
        }

        #endregion

        #region  Variables

        /// <summary>
        /// The fill value
        /// </summary>
        private Rectangle FillValue;
        /// <summary>
        /// The pipe border
        /// </summary>
        private Rectangle PipeBorder;
        /// <summary>
        /// The track bar handle rect
        /// </summary>
        private Rectangle TrackBarHandleRect;
        /// <summary>
        /// The cap
        /// </summary>
        private bool Cap;
        /// <summary>
        /// The value drawer
        /// </summary>
        private int ValueDrawer;

        /// <summary>
        /// The thumb size
        /// </summary>
        private Size ThumbSize = new Size(14, 14);
        /// <summary>
        /// The track thumb
        /// </summary>
        private Rectangle TrackThumb;

        /// <summary>
        /// The minimum
        /// </summary>
        private int _Minimum = 0;
        /// <summary>
        /// The maximum
        /// </summary>
        private int _Maximum = 10;
        /// <summary>
        /// The value
        /// </summary>
        private int _Value = 0;

        /// <summary>
        /// The jump to mouse
        /// </summary>
        private bool _JumpToMouse = false;
        /// <summary>
        /// The divided value
        /// </summary>
        private ValueDivisor DividedValue = ValueDivisor.By1;

        /// <summary>
        /// The color background
        /// </summary>
        private Color colorBackground = Color.FromArgb(124, 131, 137);
        /// <summary>
        /// The color border
        /// </summary>
        private Color colorBorder = Color.FromArgb(124, 131, 137);
        /// <summary>
        /// The color fill value
        /// </summary>
        private Color colorFillValue = Color.FromArgb(181, 41, 42);

        /// <summary>
        /// The color handle
        /// </summary>
        private Color colorHandle = Color.FromArgb(181, 41, 42);
        /// <summary>
        /// The color handle border
        /// </summary>
        private Color colorHandleBorder = Color.FromArgb(181, 41, 42);

        #endregion

        #region  Properties        
        /// <summary>
        /// Gets or sets the color background.
        /// </summary>
        /// <value>The color background.</value>
        public Color ColorBackground
        {
            get { return colorBackground; }
            set
            {
                colorBackground = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color ColorBorder
        {
            get { return colorBorder; }
            set
            {
                colorBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the fill value.
        /// </summary>
        /// <value>The color of the fill value.</value>
        public Color ColorFillValue
        {
            get { return colorFillValue; }
            set
            {
                colorFillValue = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the handle.
        /// </summary>
        /// <value>The color of the handle.</value>
        public Color ColorHandle
        {
            get { return colorHandle; }
            set
            {
                colorHandle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border color handle.
        /// </summary>
        /// <value>The border color handle.</value>
        public Color ColorHandleBorder
        {
            get { return colorHandleBorder; }
            set
            {
                colorHandleBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {

                if (value >= _Maximum)
                {
                    value = _Maximum - 10;
                }
                if (_Value < value)
                {
                    _Value = value;
                }

                _Minimum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {

                if (value <= _Minimum)
                {
                    value = _Minimum + 10;
                }
                if (_Value > value)
                {
                    _Value = value;
                }

                _Maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Delegate ValueChangedEventHandler
        /// </summary>
        public delegate void ValueChangedEventHandler();
        /// <summary>
        /// The value changed event
        /// </summary>
        private ValueChangedEventHandler ValueChangedEvent;

        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event ValueChangedEventHandler ValueChanged
        {
            add
            {
                ValueChangedEvent = (ValueChangedEventHandler)System.Delegate.Combine(ValueChangedEvent, value);
            }
            remove
            {
                ValueChangedEvent = (ValueChangedEventHandler)System.Delegate.Remove(ValueChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (_Value != value)
                {
                    if (value < _Minimum)
                    {
                        _Value = _Minimum;
                    }
                    else
                    {
                        if (value > _Maximum)
                        {
                            _Value = _Maximum;
                        }
                        else
                        {
                            _Value = value;
                        }
                    }
                    Invalidate();
                    if (ValueChangedEvent != null)
                        ValueChangedEvent();
                }
            }
        }

        /// <summary>
        /// Gets or sets the value divisor.
        /// </summary>
        /// <value>The value divisor.</value>
        public ValueDivisor ValueDivison
        {
            get
            {
                return DividedValue;
            }
            set
            {
                DividedValue = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value to set.
        /// </summary>
        /// <value>The value to set.</value>
        [Browsable(false)]
        public float ValueToSet
        {
            get
            {
                return _Value / (int)DividedValue;
            }
            set
            {
                Value = (int)(value * (int)DividedValue);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to jump to mouse.
        /// </summary>
        /// <value><c>true</c> if jump to mouse; otherwise, <c>false</c>.</value>
        public bool JumpToMouse
        {
            get
            {
                return _JumpToMouse;
            }
            set
            {
                _JumpToMouse = value;
                Invalidate();
            }
        }

        #endregion

        #region  EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            checked
            {
                bool flag = this.Cap && e.X > -1 && e.X < this.Width + 1;
                if (flag)
                {
                    this.Value = this._Minimum + (int)Math.Round((double)(this._Maximum - this._Minimum) * ((double)e.X / (double)this.Width));
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                this.ValueDrawer = (int)Math.Round(((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(this.Width - 11));
                TrackBarHandleRect = new Rectangle(ValueDrawer, 0, 25, 25);
                Cap = TrackBarHandleRect.Contains(e.Location);
                Focus();
                if (_JumpToMouse)
                {
                    this.Value = this._Minimum + (int)Math.Round((double)(this._Maximum - this._Minimum) * ((double)e.X / (double)this.Width));
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTrackBarX" /> class.
        /// </summary>
        public ZeroitTrackBarX()
        {
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor), true);

            BackColor = Color.Transparent;
            Size = new Size(80, 22);
            MinimumSize = new Size(47, 22);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 22;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            //G.Clear(Parent.BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;
            TrackThumb = new Rectangle(7, 10, Width - 16, 2);
            PipeBorder = new Rectangle(1, 10, Width - 3, 2);

            try
            {
                this.ValueDrawer = (int)Math.Round(((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(this.Width));
            }
            catch (Exception)
            {
            }


            TrackBarHandleRect = new Rectangle(ValueDrawer, 0, 3, 20);

            G.FillRectangle(new SolidBrush(colorBackground), PipeBorder);
            FillValue = new Rectangle(0, 10, TrackBarHandleRect.X + TrackBarHandleRect.Width - 4, 3);

            G.ResetClip();

            G.SmoothingMode = SmoothingMode.Default;
            G.DrawRectangle(new Pen(colorBorder), PipeBorder); // Draw pipe border
            G.FillRectangle(new SolidBrush(colorFillValue), FillValue);

            G.ResetClip();

            G.SmoothingMode = SmoothingMode.HighQuality;

            G.FillEllipse(new SolidBrush(colorHandle), this.TrackThumb.X + (int)Math.Round(unchecked((double)this.TrackThumb.Width * ((double)this.Value / (double)this.Maximum))) - (int)Math.Round((double)this.ThumbSize.Width / 2.0), this.TrackThumb.Y + (int)Math.Round((double)this.TrackThumb.Height / 2.0) - (int)Math.Round((double)this.ThumbSize.Height / 2.0), this.ThumbSize.Width, this.ThumbSize.Height);
            G.DrawEllipse(new Pen(colorHandleBorder), this.TrackThumb.X + (int)Math.Round(unchecked((double)this.TrackThumb.Width * ((double)this.Value / (double)this.Maximum))) - (int)Math.Round((double)this.ThumbSize.Width / 2.0), this.TrackThumb.Y + (int)Math.Round((double)this.TrackThumb.Height / 2.0) - (int)Math.Round((double)this.ThumbSize.Height / 2.0), this.ThumbSize.Width, this.ThumbSize.Height);
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitTrackBarXDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitTrackBarXDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitTrackBarXSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitTrackBarXSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitTrackBarXSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitTrackBarX colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTrackBarXSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitTrackBarXSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitTrackBarX;

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
        /// Gets or sets the color background.
        /// </summary>
        /// <value>The color background.</value>
        public Color ColorBackground
        {
            get
            {
                return colUserControl.ColorBackground;
            }
            set
            {
                GetPropertyByName("ColorBackground").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color border.
        /// </summary>
        /// <value>The color border.</value>
        public Color ColorBorder
        {
            get
            {
                return colUserControl.ColorBorder;
            }
            set
            {
                GetPropertyByName("ColorBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color fill value.
        /// </summary>
        /// <value>The color fill value.</value>
        public Color ColorFillValue
        {
            get
            {
                return colUserControl.ColorFillValue;
            }
            set
            {
                GetPropertyByName("ColorFillValue").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color handle.
        /// </summary>
        /// <value>The color handle.</value>
        public Color ColorHandle
        {
            get
            {
                return colUserControl.ColorHandle;
            }
            set
            {
                GetPropertyByName("ColorHandle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color handle border.
        /// </summary>
        /// <value>The color handle border.</value>
        public Color ColorHandleBorder
        {
            get
            {
                return colUserControl.ColorHandleBorder;
            }
            set
            {
                GetPropertyByName("ColorHandleBorder").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return colUserControl.Minimum;
            }
            set
            {
                GetPropertyByName("Minimum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return colUserControl.Maximum;
            }
            set
            {
                GetPropertyByName("Maximum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                return colUserControl.Value;
            }
            set
            {
                GetPropertyByName("Value").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the value divison.
        /// </summary>
        /// <value>The value divison.</value>
        public Zeroit.Framework.MiscControls.ZeroitTrackBarX.ValueDivisor ValueDivison
        {
            get
            {
                return colUserControl.ValueDivison;
            }
            set
            {
                GetPropertyByName("ValueDivison").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [jump to mouse].
        /// </summary>
        /// <value><c>true</c> if [jump to mouse]; otherwise, <c>false</c>.</value>
        public bool JumpToMouse
        {
            get
            {
                return colUserControl.JumpToMouse;
            }
            set
            {
                GetPropertyByName("JumpToMouse").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("ColorBackground",
                                 "Color Background", "Appearance",
                                 "Sets the Background color."));

            items.Add(new DesignerActionPropertyItem("ColorBorder",
                                 "Color Border", "Appearance",
                                 "Sets the Border color."));

            items.Add(new DesignerActionPropertyItem("ColorFillValue",
                                 "Color Fill Value", "Appearance",
                                 "Sets the Fill Value color."));

            items.Add(new DesignerActionPropertyItem("ColorHandle",
                                 "Color Handle", "Appearance",
                                 "Sets the Handle color."));

            items.Add(new DesignerActionPropertyItem("ColorHandleBorder",
                                 "Color Handle Border", "Appearance",
                                 "Sets the Handle border color."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                                 "Minimum", "Appearance",
                                 "Sets the minimum value."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value."));

            items.Add(new DesignerActionPropertyItem("ValueDivison",
                                 "ValueDivison", "Appearance",
                                 "Sets the division value."));

            items.Add(new DesignerActionPropertyItem("JumpToMouse",
                                 "JumpToMouse", "Appearance",
                                 "Sets the value with the mouse."));

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
