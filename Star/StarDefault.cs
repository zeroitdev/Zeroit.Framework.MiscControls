// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="StarDefault.cs" company="Zeroit Dev Technologies">
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
    #region Star Default    
    /// <summary>
    /// A class collection for rendering a star control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitControlStarDefaultDesigner))]
    public class ZeroitControlStarDefault : Control
    {
        #region Variables
        /// <summary>
        /// The star brush
        /// </summary>
        private StarBrush starBrush = StarBrush.SolidBrush;
        /// <summary>
        /// The star point x
        /// </summary>
        private float _StarPointX = 15f;
        /// <summary>
        /// The star point y
        /// </summary>
        private float _StarPointY = 15f;
        /// <summary>
        /// The star radius inner
        /// </summary>
        public float _StarRadiusInner = 3f;  //6f
        /// <summary>
        /// The star radius outer
        /// </summary>
        public float _StarRadiusOuter = 6f; //12f
        /// <summary>
        /// The star grad a point x
        /// </summary>
        private Int32 _StarGradAPointX = 50; //150
        /// <summary>
        /// The star grad a point y
        /// </summary>
        private Int32 _StarGradAPointY = 10;  //30
        /// <summary>
        /// The star grad b point x
        /// </summary>
        private Int32 _StarGradBPointX = 70; //100
        /// <summary>
        /// The star grad b point y
        /// </summary>
        private Int32 _StarGradBPointY = 140; //200
        /// <summary>
        /// The star width
        /// </summary>
        private float _StarWidth = 5;
        /// <summary>
        /// The star color1
        /// </summary>
        private Color _StarColor1 = Color.Gray;
        /// <summary>
        /// The star color2
        /// </summary>
        private Color _StarColor2 = Color.LightGray;
        /// <summary>
        /// The star hover color
        /// </summary>
        private Color _StarHoverColor = Color.Yellow;
        /// <summary>
        /// The star pressed color
        /// </summary>
        private Color _StarPressedColor = Color.Green;
        /// <summary>
        /// The star leave color
        /// </summary>
        private Color _StarLeaveColor = Color.Black;
        /// <summary>
        /// The star color default
        /// </summary>
        private Color _StarColorDefault = Color.Gray;
        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode _Smoothing = SmoothingMode.HighQuality;
        /// <summary>
        /// The pen color
        /// </summary>
        private Color penColor = Color.Black;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the color of the pen.
        /// </summary>
        /// <value>The color of the pen.</value>
        public Color PenColor
        {
            get
            {
                return penColor;
            }

            set
            {
                penColor = value;
                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the type of the star.
        /// </summary>
        /// <value>The type of the star.</value>
        public StarBrush StarType
        {
            get { return this.starBrush; }
            set
            {
                this.starBrush = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star gradient.
        /// </summary>
        /// <value>The star grad a point x.</value>
        public Int32 StarGradAPointX
        {
            get { return this._StarGradAPointX; }
            set
            {
                this._StarGradAPointX = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star gradient.
        /// </summary>
        /// <value>The star grad a point y.</value>
        public Int32 StarGradAPointY
        {
            get { return this._StarGradAPointY; }
            set
            {
                this._StarGradAPointY = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star gradient.
        /// </summary>
        /// <value>The star grad b point x.</value>
        public Int32 StarGradBPointX
        {
            get { return this._StarGradBPointX; }
            set
            {
                this._StarGradBPointX = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star gradient.
        /// </summary>
        /// <value>The star grad b point y.</value>
        public Int32 StarGradBPointY
        {
            get { return this._StarGradBPointY; }
            set
            {
                this._StarGradBPointY = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star point x.
        /// </summary>
        /// <value>The star point x.</value>
        public float StarPointX
        {
            get { return this._StarPointX; }
            set
            {
                this._StarPointX = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star point y.
        /// </summary>
        /// <value>The star point y.</value>
        public float StarPointY
        {
            get { return this._StarPointY; }
            set
            {
                this._StarPointY = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star radius inner.
        /// </summary>
        /// <value>The star radius inner.</value>
        public float StarRadiusInner
        {
            get { return this._StarRadiusInner; }
            set
            {
                this._StarRadiusInner = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star radius outer.
        /// </summary>
        /// <value>The star radius outer.</value>
        public float StarRadiusOuter
        {
            get { return this._StarRadiusOuter; }
            set
            {
                this._StarRadiusOuter = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the star color.
        /// </summary>
        /// <value>The star color1.</value>
        public Color StarColor1
        {
            get
            {
                return this._StarColor1;
            }

            set
            {
                this._StarColor1 = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the star color when the user leaves.
        /// </summary>
        /// <value>The star color leave.</value>
        public Color StarColorLeave
        {
            get
            {
                return this._StarLeaveColor;
                
            }

            set
            {
                this._StarLeaveColor = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the star color.
        /// </summary>
        /// <value>The star color2.</value>
        public Color StarColor2
        {
            get
            {
                return this._StarColor2;
                this.Invalidate();
            }

            set
            {
                this._StarColor2 = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the star color when hovered.
        /// </summary>
        /// <value>The star color hover.</value>
        public Color StarColorHover
        {
            get
            {
                return this._StarHoverColor;
                this.Invalidate();
            }

            set
            {
                this._StarHoverColor = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the star color when pressed.
        /// </summary>
        /// <value>The star color pressed.</value>
        public Color StarColorPressed
        {
            get
            {
                return this._StarPressedColor;
            }

            set
            {
                this._StarPressedColor = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the star's default color.
        /// </summary>
        /// <value>The star color default.</value>
        public Color StarColorDefault
        {
            get
            {
                return this._StarColorDefault;
            }

            set
            {
                this._StarColorDefault = value;
                this.Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the width of the star.
        /// </summary>
        /// <value>The width of the star.</value>
        public float StarWidth
        {
            get { return this._StarWidth; }
            set
            {
                this._StarWidth = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return this._Smoothing; }
            set
            {
                this._Smoothing = value;
                this.Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Enum representing the StarBrush
        /// </summary>
        public enum StarBrush
        {
            /// <summary>
            /// The solid brush
            /// </summary>
            SolidBrush,
            /// <summary>
            /// The hatch brush
            /// </summary>
            HatchBrush,
            /// <summary>
            /// The gradient brush
            /// </summary>
            GradientBrush,
            /// <summary>
            /// The pen
            /// </summary>
            Pen
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitControlStarDefault" /> class.
        /// </summary>
        public ZeroitControlStarDefault() // contructor
        {
            //InitializeComponent
            //this.Text = "My drawings"; // title of window form
            this.Size = new Size(30, 30); // size of window form
            //this.Paint += new PaintEventHandler(MyPainting); // install handler
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);


        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics G = e.Graphics;
            G.SmoothingMode = _Smoothing;
            // init 4 stars
            switch (starBrush)
            {
                case StarBrush.SolidBrush:
                    PointF[] Star1 = Calculate5StarPoints(new PointF(_StarPointX, _StarPointY), _StarRadiusOuter, _StarRadiusInner);
                    SolidBrush FillBrush = new SolidBrush(_StarColor1);
                    G.FillPolygon(FillBrush, Star1);
                    G.DrawPolygon(new Pen(_StarColor1, 5), Star1);
                    //this.Invalidate();
                    break;

                case StarBrush.HatchBrush:
                    PointF[] Star2 = Calculate5StarPoints(new PointF(_StarPointX, _StarPointY), _StarRadiusOuter, _StarRadiusInner);
                    HatchBrush pat = new HatchBrush(HatchStyle.Divot, _StarColor1, _StarColor2);
                    G.FillPolygon(pat, Star2);
                    //this.Invalidate();
                    //G.Dispose();
                    //pat.Dispose();
                    break;

                case StarBrush.GradientBrush:
                    PointF[] Star3 = Calculate5StarPoints(new PointF(_StarPointX, _StarPointX), _StarRadiusOuter, _StarRadiusInner);
                    LinearGradientBrush lin = new LinearGradientBrush(new Point(_StarGradAPointX, _StarGradAPointY), new Point(_StarGradBPointX, _StarGradBPointY), _StarColor1, _StarColor2);
                    G.FillPolygon(lin, Star3);
                    //G.Dispose();
                    //lin.Dispose();
                    //this.Invalidate();
                    break;

                case StarBrush.Pen:
                    PointF[] Star4 = Calculate5StarPoints(new PointF(_StarPointX, _StarPointX), _StarRadiusOuter, _StarRadiusInner);
                    G.DrawPolygon(new Pen(penColor, 3), Star4);
                    //G.Dispose();

                    //this.Invalidate();
                    break;

                default:
                    break;
            }


        }
        /// <summary>
        /// Return an array of 10 points to be used in a Draw- or FillPolygon method
        /// </summary>
        /// <param name="Orig">The origin is the middle of the star.</param>
        /// <param name="outerradius">Radius of the surrounding circle.</param>
        /// <param name="innerradius">Radius of the circle for the "inner" points</param>
        /// <returns>Array of 10 PointF structures</returns>
        private PointF[] Calculate5StarPoints(PointF Orig, float outerradius, float innerradius)
        {
            // Define some variables to avoid as much calculations as possible
            // conversions to radians
            double Ang36 = Math.PI / 5.0;   // 36Â° x PI/180
            double Ang72 = 2.0 * Ang36;     // 72Â° x PI/180
            // some sine and cosine values we need
            float Sin36 = (float)Math.Sin(Ang36);
            float Sin72 = (float)Math.Sin(Ang72);
            float Cos36 = (float)Math.Cos(Ang36);
            float Cos72 = (float)Math.Cos(Ang72);
            // Fill array with 10 origin points
            PointF[] pnts = { Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig };
            pnts[0].Y -= outerradius;  // top off the star, or on a clock this is 12:00 or 0:00 hours
            pnts[1].X += innerradius * Sin36; pnts[1].Y -= innerradius * Cos36; // 0:06 hours
            pnts[2].X += outerradius * Sin72; pnts[2].Y -= outerradius * Cos72; // 0:12 hours
            pnts[3].X += innerradius * Sin72; pnts[3].Y += innerradius * Cos72; // 0:18
            pnts[4].X += outerradius * Sin36; pnts[4].Y += outerradius * Cos36; // 0:24 
            // Phew! Glad I got that trig working.
            pnts[5].Y += innerradius;
            // I use the symmetry of the star figure here
            pnts[6].X += pnts[6].X - pnts[4].X; pnts[6].Y = pnts[4].Y;  // mirror point
            pnts[7].X += pnts[7].X - pnts[3].X; pnts[7].Y = pnts[3].Y;  // mirror point
            pnts[8].X += pnts[8].X - pnts[2].X; pnts[8].Y = pnts[2].Y;  // mirror point
            pnts[9].X += pnts[9].X - pnts[1].X; pnts[9].Y = pnts[1].Y;  // mirror point
            return pnts;
        }
    }

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitControlStarDefaultDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitControlStarDefaultDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitControlStarDefaultSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitControlStarDefaultSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitControlStarDefaultSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitControlStarDefault colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitControlStarDefaultSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitControlStarDefaultSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitControlStarDefault;

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
        /// Gets or sets the type of the star.
        /// </summary>
        /// <value>The type of the star.</value>
        public Zeroit.Framework.MiscControls.ZeroitControlStarDefault.StarBrush StarType
        {
            get
            {
                return colUserControl.StarType;
            }
            set
            {
                GetPropertyByName("StarType").SetValue(colUserControl, value);
            }
        }



        /// <summary>
        /// Gets or sets the star grad a point x.
        /// </summary>
        /// <value>The star grad a point x.</value>
        public Int32 StarGradAPointX
        {
            get
            {
                return colUserControl.StarGradAPointX;
            }
            set
            {
                GetPropertyByName("StarGradAPointX").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star grad a point y.
        /// </summary>
        /// <value>The star grad a point y.</value>
        public Int32 StarGradAPointY
        {
            get
            {
                return colUserControl.StarGradAPointY;
            }
            set
            {
                GetPropertyByName("StarGradAPointY").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star grad b point x.
        /// </summary>
        /// <value>The star grad b point x.</value>
        public Int32 StarGradBPointX
        {
            get
            {
                return colUserControl.StarGradBPointX;
            }
            set
            {
                GetPropertyByName("StarGradBPointX").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star grad b point y.
        /// </summary>
        /// <value>The star grad b point y.</value>
        public Int32 StarGradBPointY
        {
            get
            {
                return colUserControl.StarGradBPointY;
            }
            set
            {
                GetPropertyByName("StarGradBPointY").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star point x.
        /// </summary>
        /// <value>The star point x.</value>
        public float StarPointX
        {
            get
            {
                return colUserControl.StarPointX;
            }
            set
            {
                GetPropertyByName("StarPointX").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star point y.
        /// </summary>
        /// <value>The star point y.</value>
        public float StarPointY
        {
            get
            {
                return colUserControl.StarPointY;
            }
            set
            {
                GetPropertyByName("StarPointY").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star radius inner.
        /// </summary>
        /// <value>The star radius inner.</value>
        public float StarRadiusInner
        {
            get
            {
                return colUserControl.StarRadiusInner;
            }
            set
            {
                GetPropertyByName("StarRadiusInner").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the star radius outer.
        /// </summary>
        /// <value>The star radius outer.</value>
        public float StarRadiusOuter
        {
            get
            {
                return colUserControl.StarRadiusOuter;
            }
            set
            {
                GetPropertyByName("StarRadiusOuter").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the pen.
        /// </summary>
        /// <value>The color of the pen.</value>
        public Color PenColor
        {
            get
            {
                return colUserControl.PenColor;
            }
            set
            {
                GetPropertyByName("PenColor").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the star color1.
        /// </summary>
        /// <value>The star color1.</value>
        public Color StarColor1
        {
            get
            {
                return colUserControl.StarColor1;
            }
            set
            {
                GetPropertyByName("StarColor1").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the star color leave.
        /// </summary>
        /// <value>The star color leave.</value>
        public Color StarColorLeave
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
        /// Gets or sets the star color2.
        /// </summary>
        /// <value>The star color2.</value>
        public Color StarColor2
        {
            get
            {
                return colUserControl.StarColor2;
            }
            set
            {
                GetPropertyByName("StarColor2").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the star color hover.
        /// </summary>
        /// <value>The star color hover.</value>
        public Color StarColorHover
        {
            get
            {
                return colUserControl.StarColorHover;
            }
            set
            {
                GetPropertyByName("StarColorHover").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the star color pressed.
        /// </summary>
        /// <value>The star color pressed.</value>
        public Color StarColorPressed
        {
            get
            {
                return colUserControl.StarColorPressed;
            }
            set
            {
                GetPropertyByName("StarColorPressed").SetValue(colUserControl, value);
            }

        }

        /// <summary>
        /// Gets or sets the star color default.
        /// </summary>
        /// <value>The star color default.</value>
        public Color StarColorDefault
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
        /// Gets or sets the width of the star.
        /// </summary>
        /// <value>The width of the star.</value>
        public float StarWidth
        {
            get
            {
                return colUserControl.StarWidth;
            }
            set
            {
                GetPropertyByName("StarWidth").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("StarType",
                                 "Pen Width", "Appearance",
                                 "Sets the type of star."));

            //items.Add(new DesignerActionPropertyItem("PenWidth",
            //                     "Star Type", "Appearance",
            //                     "Sets the width of the pen."));

            items.Add(new DesignerActionPropertyItem("StarGradAPointX",
                                 "Star GradA Point X", "Appearance",
                                 "Sets the gradient x-cordinate when the startype is set to GradientBrush."));

            items.Add(new DesignerActionPropertyItem("StarGradAPointY",
                                 "Star GradA Point Y", "Appearance",
                                 "Sets the gradient y-cordinate when the startype is set to GradientBrush."));

            items.Add(new DesignerActionPropertyItem("StarGradBPointX",
                                 "Star GradB Point X", "Appearance",
                                 "Sets the gradient x-cordinate when the startype is set to GradientBrush."));

            items.Add(new DesignerActionPropertyItem("StarGradBPointY",
                                 "Star GradB Point Y", "Appearance",
                                 "Sets the gradient y-cordinate when the startype is set to GradientBrush."));

            items.Add(new DesignerActionPropertyItem("StarPointX",
                                 "Star Point X", "Appearance",
                                 "Sets the x-cordinate location of the star."));

            items.Add(new DesignerActionPropertyItem("StarPointY",
                                 "Star Point Y", "Appearance",
                                 "Sets the y-cordinate location of the star."));

            items.Add(new DesignerActionPropertyItem("StarRadiusInner",
                                 "Star Radius Inner", "Appearance",
                                 "Sets the inner radius of the star. Increase in value widens the star."));

            items.Add(new DesignerActionPropertyItem("StarRadiusOuter",
                                 "Star Radius Outer", "Appearance",
                                 "Sets the outer radius of the star. Increase in value increases the size of the star."));

            items.Add(new DesignerActionPropertyItem("PenColor",
                                 "PenColor", "Appearance",
                                 "Sets the color of the star."));

            items.Add(new DesignerActionPropertyItem("StarColor1",
                                 "Star Color1", "Appearance",
                                 "Sets the solid brush color of the star."));

            items.Add(new DesignerActionPropertyItem("StarColor2",
                                 "Star Color2", "Appearance",
                                 "Sets the gradient brush of the star. Not needed though."));

            items.Add(new DesignerActionPropertyItem("StarColorLeave",
                                 "Star Color Leave", "Appearance",
                                 "Sets the color of the star when the mouse leaves the control."));

            items.Add(new DesignerActionPropertyItem("StarColorHover",
                                 "Star Color Hover", "Appearance",
                                 "Sets the hover color of the star when the mouse enters the control."));

            items.Add(new DesignerActionPropertyItem("StarColorPressed",
                                 "Star Color Pressed", "Appearance",
                                 "Sets the color of the star when it is pressed."));

            items.Add(new DesignerActionPropertyItem("StarColorDefault",
                                 "Star Color Default", "Appearance",
                                 "Sets the default color of the star when inactive."));

            items.Add(new DesignerActionPropertyItem("StarWidth",
                                 "Star Width", "Appearance",
                                 "Sets the width of the star."));

            items.Add(new DesignerActionPropertyItem("Smoothing",
                                 "Smoothing", "Appearance",
                                 "Sets the smoothing mode of the star."));

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
