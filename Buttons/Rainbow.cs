using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region Rainbow Button

    #region Delegates
    /// <summary>
    /// Event handler delegate for the ColorChanged event
    /// </summary>
    public delegate void ColorChangedEventHandler(object sender, EventArgs e);
    /// <summary>
    /// Event handler delegate for the TransparentcyChanged event
    /// </summary>
    public delegate void TransparentcyChangedEventHandler
        (object sender, EventArgs e);

    #endregion

    #region Control    
    /// <summary>
    /// A multi colored button with five colours merged as one in a rainbow effect
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Button" />
    [Designer(typeof(ZeroitButtonRainBowDesigner))]    
    public class ZeroitButtonRainBow : System.Windows.Forms.Button
    {
        #region Class varibles, constructors and events

        #region Events


        /// <summary>
        /// Event that is called when a colour is changed
        /// </summary>
        public event ColorChangedEventHandler ColorChanged;

        /// <summary>
        /// Event that is called when the transparentcy is changed
        /// </summary>
        public event TransparentcyChangedEventHandler TransparentcyChanged;

        #endregion

        #region Fields


        // 2 colours that make up the lineargradientbrushs
        private Color _color1;
        private Color _color2;
        private Color _color3;
        private Color _color4;
        private Color _color5;

        // trasparentcy for the color merge
        // initalize them with 64, can be changed later
        private int _colorTransparentcy1 = 64;
        private int _colorTransparentcy2 = 64;
        private int _colorTransparentcy3 = 64;
        private int _colorTransparentcy4 = 64;
        private int _colorTransparentcy5 = 64;

        private float angle1 = 5;
        private float angle2 = 5;
        private float angle3 = 5;
        private float angle4 = 5;
        #endregion

        #region Public Properties


        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle1.</value>
        public float ColorAngle1
        {
            get { return angle1; }
            set
            {
                angle1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle2.</value>
        public float ColorAngle2
        {
            get { return angle2; }
            set
            {
                angle2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle3.</value>
        public float ColorAngle3
        {
            get { return angle3; }
            set
            {
                angle3 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle4.</value>
        public float ColorAngle4
        {
            get { return angle4; }
            set
            {
                angle4 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// First colour from the left
        /// </summary>
        public Color Color1
        {
            get { return _color1; }
            set { _color1 = value; Invalidate(); invokeColorChange(); }
        }
        /// <summary>
        /// Second colour from the left
        /// </summary>
        public Color Color2
        {
            get { return _color2; }
            set { _color2 = value; Invalidate(); invokeColorChange(); }
        }
        /// <summary>
        /// Third colour from the left
        /// </summary>
        public Color Color3
        {
            get { return _color3; }
            set { _color3 = value; Invalidate(); invokeColorChange(); }
        }
        /// <summary>
        /// Forth colour from the left
        /// </summary>
        public Color Color4
        {
            get { return _color4; }
            set { _color4 = value; Invalidate(); invokeColorChange(); }
        }
        /// <summary>
        /// Fifth colour from the left
        /// </summary>
        public Color Color5
        {
            get { return _color5; }
            set { _color5 = value; Invalidate(); invokeColorChange(); }
        }

        /// <summary>
        /// Transparency for Color1
        /// </summary>
        public int ColorTransparentcy1
        {
            get { return _colorTransparentcy1; }
            set { _colorTransparentcy1 = value; Invalidate(); invokeTransparentcyChange(); }
        }
        /// <summary>
        /// Transparency for Color2
        /// </summary>
        public int ColorTransparentcy2
        {
            get { return _colorTransparentcy2; }
            set { _colorTransparentcy2 = value; Invalidate(); invokeTransparentcyChange(); }
        }
        /// <summary>
        /// Transparency for Color3
        /// </summary>
        public int ColorTransparentcy3
        {
            get { return _colorTransparentcy3; }
            set { _colorTransparentcy3 = value; Invalidate(); invokeTransparentcyChange(); }
        }
        /// <summary>
        /// Transparency for Color4
        /// </summary>
        public int ColorTransparentcy4
        {
            get { return _colorTransparentcy4; }
            set { _colorTransparentcy4 = value; Invalidate(); invokeTransparentcyChange(); }
        }
        /// <summary>
        /// Transparency for Color5
        /// </summary>
        public int ColorTransparentcy5
        {
            get { return _colorTransparentcy5; }
            set { _colorTransparentcy5 = value; Invalidate(); invokeTransparentcyChange(); }
        }

        #endregion

        #region Button Constructors

        /// <summary>
        /// rainbowButton Constructor
        /// </summary>
        /// <param name="color1">First colour on the left of the button</param>
        /// <param name="color2">Second colour on the left of the button</param>
        /// <param name="color3">Third colour on the left of the button</param>
        /// <param name="color4">Forth colour on the left of the button</param>
        /// <param name="color5">Fifth colour on the left of the button</param>
        public ZeroitButtonRainBow
            (Color color1, Color color2, Color color3, Color color4, Color color5)
        {
            Color1 = color1;
            Color2 = color2;
            Color3 = color3;
            Color4 = color4;
            Color5 = color5;
        }
        /// <summary>
        /// Constructor that uses default colours(Green,Yellow,Red,Blue)
        /// </summary>
        public ZeroitButtonRainBow()
        {
            Color1 = Color.Green;
            Color2 = Color.Yellow;
            Color3 = Color.Red;
            Color4 = Color.Blue;
            Color5 = Color.DeepPink;
        }
        
        #endregion

        #endregion

        #region Overrides
        /// <summary>
        /// Over written OnPaint class. Does all the drawing
        /// </summary>
        /// <param name="pe">PaintEventArgs used to do the drawing</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            base.OnPaint(pe);

            // getting 25% of the ClientRectangle
            float percentage = ClientRectangle.Width * 0.25f;

            // getting rectangle to fill
            RectangleF pRect = new RectangleF(new PointF(0.0f, 0.0f), new SizeF(percentage, ClientRectangle.Height));

            // create the first transparent colours
            Color c1 = Color.FromArgb(ColorTransparentcy1, Color1);
            Color c2 = Color.FromArgb(ColorTransparentcy2, Color2);

            // create the first brush
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush
                (pRect, c1, c2, angle1);

            // fill the first segment
            pe.Graphics.FillRectangle(b, pRect);

            // get second rectangle
            pRect.Offset(percentage, 0);

            // get the second colours
            c1 = Color.FromArgb(ColorTransparentcy2, Color2);
            c2 = Color.FromArgb(ColorTransparentcy3, Color3);

            // create second brush
            b.Dispose();
            b = new System.Drawing.Drawing2D.LinearGradientBrush
                (pRect, c1, c2, angle2);

            // fill the second segment
            pe.Graphics.FillRectangle(b, pRect);

            // get third rectangle
            pRect.Offset(percentage, 0);

            // get the third colours
            c1 = Color.FromArgb(ColorTransparentcy3, Color3);
            c2 = Color.FromArgb(ColorTransparentcy4, Color4);

            // create third brush
            b.Dispose();
            b = new System.Drawing.Drawing2D.LinearGradientBrush
                (pRect, c1, c2, angle3);

            // fill the third rectangle
            pe.Graphics.FillRectangle(b, pRect);

            // get last rectangle
            pRect.Offset(percentage, 0);

            // get the last colours
            c1 = Color.FromArgb(ColorTransparentcy4, Color4);
            c2 = Color.FromArgb(ColorTransparentcy5, Color5);

            // create last brush
            b.Dispose();
            b = new System.Drawing.Drawing2D.LinearGradientBrush
                (pRect, c1, c2, angle4);

            // fill the last rectangle
            pe.Graphics.FillRectangle(b, pRect);

            // dispose of resources
            b.Dispose();
        }

        #endregion

        #region Private Methods
        private void invokeColorChange()
        {
            if (ColorChanged != null)
            {
                EventArgs e = new EventArgs();
                ColorChanged(this, e);
            }
        }
        private void invokeTransparentcyChange()
        {
            if (TransparentcyChanged != null)
            {
                EventArgs e = new EventArgs();
                TransparentcyChanged(this, e);
            }
        }
        #endregion

    }

    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitButtonRainBowDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitButtonRainBowSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    public class ZeroitButtonRainBowSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        private ZeroitButtonRainBow colUserControl;


        private DesignerActionUIService designerActionUISvc = null;


        public ZeroitButtonRainBowSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitButtonRainBow;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
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

        public Color Color1
        {
            get
            {
                return colUserControl.Color1;
            }
            set
            {
                GetPropertyByName("Color1").SetValue(colUserControl, value);
            }
        }

        public Color Color2
        {
            get
            {
                return colUserControl.Color2;
            }
            set
            {
                GetPropertyByName("Color2").SetValue(colUserControl, value);
            }
        }

        public Color Color3
        {
            get
            {
                return colUserControl.Color3;
            }
            set
            {
                GetPropertyByName("Color3").SetValue(colUserControl, value);
            }
        }

        public Color Color4
        {
            get
            {
                return colUserControl.Color4;
            }
            set
            {
                GetPropertyByName("Color4").SetValue(colUserControl, value);
            }
        }

        public Color Color5
        {
            get
            {
                return colUserControl.Color5;
            }
            set
            {
                GetPropertyByName("Color5").SetValue(colUserControl, value);
            }
        }

        public float ColorAngle1
        {
            get
            {
                return colUserControl.ColorAngle1;
            }
            set
            {
                GetPropertyByName("ColorAngle1").SetValue(colUserControl, value);
            }
        }

        public float ColorAngle2
        {
            get
            {
                return colUserControl.ColorAngle2;
            }
            set
            {
                GetPropertyByName("ColorAngle2").SetValue(colUserControl, value);
            }
        }

        public float ColorAngle3
        {
            get
            {
                return colUserControl.ColorAngle3;
            }
            set
            {
                GetPropertyByName("ColorAngle3").SetValue(colUserControl, value);
            }
        }

        public float ColorAngle4
        {
            get
            {
                return colUserControl.ColorAngle4;
            }
            set
            {
                GetPropertyByName("ColorAngle4").SetValue(colUserControl, value);
            }
        }

        public int ColorTransparentcy1
        {
            get
            {
                return colUserControl.ColorTransparentcy1;
            }
            set
            {
                GetPropertyByName("ColorTransparentcy1").SetValue(colUserControl, value);
            }
        }

        public int ColorTransparentcy2
        {
            get
            {
                return colUserControl.ColorTransparentcy2;
            }
            set
            {
                GetPropertyByName("ColorTransparentcy2").SetValue(colUserControl, value);
            }
        }

        public int ColorTransparentcy3
        {
            get
            {
                return colUserControl.ColorTransparentcy3;
            }
            set
            {
                GetPropertyByName("ColorTransparentcy3").SetValue(colUserControl, value);
            }
        }

        public int ColorTransparentcy4
        {
            get
            {
                return colUserControl.ColorTransparentcy4;
            }
            set
            {
                GetPropertyByName("ColorTransparentcy4").SetValue(colUserControl, value);
            }
        }

        public int ColorTransparentcy5
        {
            get
            {
                return colUserControl.ColorTransparentcy5;
            }
            set
            {
                GetPropertyByName("ColorTransparentcy5").SetValue(colUserControl, value);
            }
        }



        #endregion

        #region DesignerActionItemCollection

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

            items.Add(new DesignerActionPropertyItem("Color1",
                                 "Color1", "Appearance",
                                 "Sets the background color of rainbow1."));

            items.Add(new DesignerActionPropertyItem("Color2",
                                 "Color2", "Appearance",
                                 "Sets the background color of rainbow2."));

            items.Add(new DesignerActionPropertyItem("Color3",
                                 "Color3", "Appearance",
                                 "Sets the background color of rainbow3."));

            items.Add(new DesignerActionPropertyItem("Color4",
                                 "Color4", "Appearance",
                                 "Sets the background color of rainbow4."));

            items.Add(new DesignerActionPropertyItem("Color5",
                                 "Color5", "Appearance",
                                 "Sets the background color of rainbow5."));

            items.Add(new DesignerActionPropertyItem("ColorAngle1",
                                 "ColorAngle1", "Appearance",
                                 "Sets the color angle."));

            items.Add(new DesignerActionPropertyItem("ColorAngle2",
                                 "ColorAngle2", "Appearance",
                                 "Sets the color angle."));

            items.Add(new DesignerActionPropertyItem("ColorAngle3",
                                 "ColorAngle3", "Appearance",
                                 "Sets the color angle."));

            items.Add(new DesignerActionPropertyItem("ColorAngle4",
                                 "ColorAngle4", "Appearance",
                                 "Sets the color angle."));

            items.Add(new DesignerActionPropertyItem("ColorTransparentcy1",
                                 "ColorTransparentcy1", "Appearance",
                                 "Sets the color transparency for color1."));

            items.Add(new DesignerActionPropertyItem("ColorTransparentcy2",
                                 "ColorTransparentcy2", "Appearance",
                                 "Sets the color transparency for color2."));

            items.Add(new DesignerActionPropertyItem("ColorTransparentcy3",
                                 "ColorTransparentcy3", "Appearance",
                                 "Sets the color transparency for color3."));

            items.Add(new DesignerActionPropertyItem("ColorTransparentcy4",
                                 "ColorTransparentcy4", "Appearance",
                                 "Sets the color transparency for color4."));

            items.Add(new DesignerActionPropertyItem("ColorTransparentcy5",
                                 "ColorTransparentcy5", "Appearance",
                                 "Sets the color transparency for color5."));

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
