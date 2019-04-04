// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ElongatedGroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region Elongated GroupBox

    #region BaseContainer

    /// <summary>
    /// Summary description for BaseContainer.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.GroupBox" />
    /// <seealso cref="Zeroit.Framework.MiscControls.IGradientContainer" />
	public abstract class BaseContainer : System.Windows.Forms.GroupBox, IGradientContainer
    {
        #region Constants
        /// <summary>
        /// The idefault borderwidth
        /// </summary>
        private const int IDEFAULT_BORDERWIDTH = 6;                                 // Default value of  BorderWidth Property
        /// <summary>
        /// The odefault sizeborderpixelindet
        /// </summary>
        private Size ODEFAULT_SIZEBORDERPIXELINDET = new Size(16, 16);              // Default value of moSizeBorderPixelIndent
        /// <summary>
        /// The odefault gradienttopcolor
        /// </summary>
        private static Color ODEFAULT_GRADIENTTOPCOLOR = Color.FromArgb(225, 225, 183);    // Default value of GradientTopColor Property
        /// <summary>
        /// The odefault gradientbottomcolor
        /// </summary>
        private static Color ODEFAULT_GRADIENTBOTTOMCOLOR = Color.FromArgb(167, 168, 127); // Default value of GradientBottomColor Property
        /// <summary>
        /// The odefault headingtextcolor
        /// </summary>
        private static Color ODEFAULT_HEADINGTEXTCOLOR = Color.FromArgb(57, 66, 1);        // Default value of HeaderTextColor Property
        /// <summary>
        /// The odefault interiortopcolor
        /// </summary>
        private static Color ODEFAULT_INTERIORTOPCOLOR = Color.FromArgb(245, 243, 219);    // Default value of InteriorGradientTopColor Property
        /// <summary>
        /// The odefault interiorbottomcolor
        /// </summary>
        private static Color ODEFAULT_INTERIORBOTTOMCOLOR = Color.FromArgb(214, 209, 153); // Default value of InteriorGradientBottomColor Property
        /// <summary>
        /// The odefault shadowcolor
        /// </summary>
        private static Color ODEFAULT_SHADOWCOLOR = Color.FromArgb(142, 143, 116);         // Default value of ShadowColor Property

        // These values are used in LinerGradientBrush's blend property to specify the Factor and Postion
        // When the values are changed the gradient is drawn differently
        /// <summary>
        /// The iarr relativeintensities
        /// </summary>
        protected Single[] IARR_RELATIVEINTENSITIES = { 0.0F, 0.32F, 1.0F };            // Values for Factor property of blend
        /// <summary>
        /// The iarr relativepositions
        /// </summary>
        protected Single[] IARR_RELATIVEPOSITIONS = { 0.0F, 0.44F, 1.0F };          // Values for Position property of blend
        #endregion

        #region Private Data Members
        // Defining the data member corresponding to different Properties and initializing default values
        /// <summary>
        /// The mi border width
        /// </summary>
        private int miBorderWidth = IDEFAULT_BORDERWIDTH;                           // BorderWidth Property 
        /// <summary>
        /// The mo gradient top color
        /// </summary>
        private Color moGradientTopColor = ODEFAULT_GRADIENTTOPCOLOR;               // GradientTopColor Property 
        /// <summary>
        /// The mo gradient bottom color
        /// </summary>
        private Color moGradientBottomColor = ODEFAULT_GRADIENTBOTTOMCOLOR;         // GradientBottomColor Property
        /// <summary>
        /// The mo heading text color
        /// </summary>
        private Color moHeadingTextColor = ODEFAULT_HEADINGTEXTCOLOR;               // HeaderTextColor Property
        /// <summary>
        /// The mo interior top color
        /// </summary>
        private Color moInteriorTopColor = ODEFAULT_INTERIORTOPCOLOR;               // InteriorTopColor Property
        /// <summary>
        /// The mo interior bottom color
        /// </summary>
        private Color moInteriorBottomColor = ODEFAULT_INTERIORBOTTOMCOLOR;         // InteriorBottomColor Property
        /// <summary>
        /// The mo shadow color
        /// </summary>
        private Color moShadowColor = ODEFAULT_SHADOWCOLOR;                         // ShadowColor Property
        #endregion

        #region Protected Members
        /// <summary>
        /// The mosize border pixel indent
        /// </summary>
        protected Size mosizeBorderPixelIndent;   // Size of the radius of the curves at the corners
        /// <summary>
        /// The mo text size
        /// </summary>
        protected SizeF moTextSize;               // Size(In Floating Point) of the text in pixels based on the font

        // This property defines the border within which the whole control is to be drawn.
        /// <summary>
        /// Gets the border rectangle.
        /// </summary>
        /// <value>The border rectangle.</value>
        protected Rectangle BorderRectangle
        {
            get
            {
                Rectangle rc = this.ClientRectangle;    // We reduce the size of drawing to show everything properly.
                return new Rectangle(1, 1, rc.Width - 3, rc.Height - 3);
            }

        }

        // This property defines the color of shadow of the control
        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        public Color ShadowColor
        {
            get
            {
                return moShadowColor;
            }
            set
            {
                moShadowColor = value;
                this.Invalidate();

            }
        }

        // This property defines the color of the header text
        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>The color of the font.</value>
        public Color FontColor
        {
            get
            {
                return moHeadingTextColor;
            }
            set
            {
                moHeadingTextColor = value;
            }
        }

        // This property defines the Top Color of the BorderGradient
        /// <summary>
        /// Gets or sets the color of the border top.
        /// </summary>
        /// <value>The color of the border top.</value>
        Color IGradientBorderColor.BorderTopColor
        {
            get
            {
                return moGradientTopColor;
            }
            set
            {
                moGradientTopColor = value;
            }
        }

        // This property defines the Bottom Color of the BorderGradient
        /// <summary>
        /// Gets or sets the color of the border bottom.
        /// </summary>
        /// <value>The color of the border bottom.</value>
        Color IGradientBorderColor.BorderBottomColor
        {
            get
            {
                return moGradientBottomColor;
            }
            set
            {
                moGradientBottomColor = value;
            }
        }

        // This property defines the Top Color of the Background Gradient
        /// <summary>
        /// Gets or sets the color of the background top.
        /// </summary>
        /// <value>The color of the background top.</value>
        Color IGradientBackgroundColor.BackgroundTopColor
        {
            get
            {
                return moInteriorTopColor;
            }
            set
            {
                moInteriorTopColor = value;
            }
        }

        // This property defines the Bottom Color of the Background Gradient
        /// <summary>
        /// Gets or sets the color of the background bottom.
        /// </summary>
        /// <value>The color of the background bottom.</value>
        Color IGradientBackgroundColor.BackgroundBottomColor
        {
            get
            {
                return moInteriorBottomColor;
            }
            set
            {
                moInteriorBottomColor = value;
            }
        }
        #endregion

        #region Public Property

        // The colorscheme property which is to be implemented by the Child Classes
        /// <summary>
        /// Gets or sets the zeroit group button color scheme.
        /// </summary>
        /// <value>The zeroit group button color scheme.</value>
        public abstract EnmColorScheme ZeroitGroupButtonColorScheme { get; set; }

        // The BorderWidth Values are accessed and intialised using this property
        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get
            {
                return miBorderWidth;
            }
            set
            {
                miBorderWidth = value;
                this.Invalidate();
            }
        }
        #endregion

        #region Overridable Properties

        // This property is being used in the OnPaint Method to paint the border
        /// <summary>
        /// Gets the interior region path brush.
        /// </summary>
        /// <value>The interior region path brush.</value>
        protected virtual Brush InteriorRegionPathBrush
        {
            get
            {
                // Brush of LinearGradient type is created to draw gradient
                System.Drawing.Drawing2D.LinearGradientBrush brush =
                    new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle,
                    moGradientTopColor,
                    moGradientBottomColor,
                    LinearGradientMode.Vertical);
                // Blend is used to define the blending method for the gradient
                Blend blend = new Blend();
                blend.Factors = IARR_RELATIVEINTENSITIES;
                blend.Positions = IARR_RELATIVEPOSITIONS;
                brush.Blend = blend;
                return brush;
            }
        }
        // This Property is used in the OnPaint Method to define the region property of the control
        /// <summary>
        /// Gets the exterior region path.
        /// </summary>
        /// <value>The exterior region path.</value>
        protected virtual GraphicsPath ExteriorRegionPath
        {
            get
            {
                Rectangle oRectangle = new Rectangle(this.BorderRectangle.X, this.BorderRectangle.Y, this.BorderRectangle.Width + 3, this.BorderRectangle.Height + 3);
                Size oSize = new Size(mosizeBorderPixelIndent.Width + 2, mosizeBorderPixelIndent.Height + 2);
                return this.GetRoundedRectanglarPath(oRectangle, oSize);
            }
        }

        // This property is Used in the OnPaint Method to define path to draw the control
        /// <summary>
        /// Gets the interior region path.
        /// </summary>
        /// <value>The interior region path.</value>
        protected virtual GraphicsPath InteriorRegionPath
        {
            get
            {
                Rectangle oRectangle = new Rectangle(this.BorderRectangle.X + 1, this.BorderRectangle.Y + 1, this.BorderRectangle.Width - 2, this.BorderRectangle.Height - 2);
                Size oSize = new Size(mosizeBorderPixelIndent.Width - 2, mosizeBorderPixelIndent.Height - 2);
                return this.GetRoundedRectanglarPath(oRectangle, oSize);
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseContainer"/> class.
        /// </summary>
        public BaseContainer() : base()
        {
            // This method is to specify to the OS that this control has its own OnPaint Method and 
            // to use it. The double buffering is used so that the control does not flicker when the 
            // Invalidate method is called.
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.DoubleBuffer, true);
            mosizeBorderPixelIndent = ODEFAULT_SIZEBORDERPIXELINDET;
        }

        #region Overridable Methods
        // This procedure draws the Shadows for the outer Borders and gets called from OnPaint Method
        /// <summary>
        /// Draws the border.
        /// </summary>
        /// <param name="aoGraphics">The ao graphics.</param>
        /// <param name="aoRectangle">The ao rectangle.</param>
        protected virtual void DrawBorder(Graphics aoGraphics, Rectangle aoRectangle)
        {
            Pen oPen;
            Size oSize = new Size(mosizeBorderPixelIndent.Width, mosizeBorderPixelIndent.Height);
            Rectangle oRectangle = new Rectangle(aoRectangle.X, aoRectangle.Y, aoRectangle.Width, aoRectangle.Height);
            SizeF szText = aoGraphics.MeasureString(this.Text, this.Font);

            // We are looping 3 times for a 3 pixel wide shadow.
            for (int i = 0; i < 3; i++)
            {
                // Creates a pen to draw Lines and Arcs Dark To Light
                oPen = new Pen(Color.FromArgb((2 - i + 1) * 64, moShadowColor));

                // Draws a shadow arc for the Top Right corner
                aoGraphics.DrawArc(oPen, oRectangle.Right - oSize.Width,
                    oRectangle.Top + 2, oSize.Width,
                    oSize.Height, 270, 90);

                // Draws a vertical shadow line for the right side
                aoGraphics.DrawLine(oPen, oRectangle.Right, oRectangle.Top + (Single)(oSize.Height / 2),
                    oRectangle.Right, oRectangle.Bottom - (Single)(oSize.Height / 2));

                // Draws a shadow arc for bottom right corner
                aoGraphics.DrawArc(oPen, oRectangle.Right - oSize.Width,
                    oRectangle.Bottom - oSize.Height,
                    oSize.Width, oSize.Height, 0, 90);
                // Draws a horizontal shadow line for the bottom
                aoGraphics.DrawLine(oPen, oRectangle.Right - (Single)(oSize.Width / 2),
                    oRectangle.Bottom, oRectangle.Left + (Single)(oSize.Width / 2),
                    oRectangle.Bottom);

                // Creates a pen to draw lines and arcs Light to Dark
                oPen = new Pen(Color.FromArgb((2 - i) * 127, moShadowColor));

                // Draw a shadow arc for the bottom left corner
                aoGraphics.DrawArc(oPen, oRectangle.Left + 2, oRectangle.Bottom - oSize.Height,
                    oSize.Width, oSize.Height, 90, 90);

                // Increasing the Rectangles X and Y position
                oRectangle.X += 1;
                oRectangle.Y += 1;

                // Reducing Height and width of the rectangle
                oRectangle.Width -= 2;
                oRectangle.Height -= 2;

                // Reducing the radius size of the arcs to draw the arcs properly
                oSize.Height -= 2;
                oSize.Width -= 2;
            }
        }

        // This Method is called from OnPaint Method to draw the Interior Part
        /// <summary>
        /// Draws the interior.
        /// </summary>
        /// <param name="aoGraphics">The ao graphics.</param>
        protected virtual void DrawInterior(Graphics aoGraphics)
        {
            // Create rectangle to draw interior
            Rectangle oRcInterior = new Rectangle(this.BorderRectangle.X + miBorderWidth + 1, this.BorderRectangle.Y + 12 + miBorderWidth, this.BorderRectangle.Width - (miBorderWidth * 2), this.BorderRectangle.Height - (12 + miBorderWidth * 2));

            SolidBrush oSolidBrush;
            for (int Index = 1; Index >= 0; Index--)
            {
                // Define Shadow Brushes Dark to Light
                oSolidBrush = new SolidBrush(Color.FromArgb(127 * (2 - Index), moShadowColor));
                Pen oPen = new Pen(oSolidBrush);

                // Draws vertical line on Left side
                aoGraphics.DrawLine(oPen, oRcInterior.X, oRcInterior.Y, oRcInterior.X, oRcInterior.Bottom);

                // Draws horizontal lines on the top
                aoGraphics.DrawLine(oPen, oRcInterior.X, oRcInterior.Y, oRcInterior.Right, oRcInterior.Y);

                // Increasing the X and Y postion of the rectangle
                oRcInterior.X += 1;
                oRcInterior.Y += 1;

                // Reducing the height and width of the rectangle
                oRcInterior.Width -= 2;
                oRcInterior.Height -= 2;
            }

            // Brush of LinearGradient type is created to draw gradient
            LinearGradientBrush oLinearGradient = new LinearGradientBrush(oRcInterior,
                moInteriorTopColor,
                moInteriorBottomColor,
                LinearGradientMode.Vertical);

            // Blend is used to define the blend of the gradient
            Blend oBlend = new Blend();
            oBlend.Factors = IARR_RELATIVEINTENSITIES;
            oBlend.Positions = IARR_RELATIVEPOSITIONS;
            oLinearGradient.Blend = oBlend;

            // Fill the rectangle using Gradient Brush created above
            aoGraphics.FillRectangle(oLinearGradient, oRcInterior);
        }
        #endregion

        #region Private methods
        // This function is used to get Rectangular GraphicsPath with Rounded Corner
        /// <summary>
        /// Gets the rounded rectanglar path.
        /// </summary>
        /// <param name="aoRectangle">The ao rectangle.</param>
        /// <param name="aoSize">Size of the ao.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath GetRoundedRectanglarPath(Rectangle aoRectangle, Size aoSize)
        {
            GraphicsPath oExteriorGraphicPath = new GraphicsPath();

            // Add top horizontal line to the Graphics Path Object
            oExteriorGraphicPath.AddLine(aoRectangle.Left + (Single)(aoSize.Height / 2), aoRectangle.Top, aoRectangle.Right - (Single)(aoSize.Height / 2), aoRectangle.Top);

            // Add arc for the top right corner curve to the Graphics Path object
            oExteriorGraphicPath.AddArc(aoRectangle.Right - aoSize.Width, aoRectangle.Top, aoSize.Width, aoSize.Height, 270, 90);

            // Add right vertical line to the Graphics Path object
            oExteriorGraphicPath.AddLine(aoRectangle.Right, aoRectangle.Top + aoSize.Height, aoRectangle.Right, aoRectangle.Bottom - (Single)(aoSize.Height / 2));

            // Add the bottom right corner curve to the Graphics object
            oExteriorGraphicPath.AddArc(aoRectangle.Right - aoSize.Width, aoRectangle.Bottom - aoSize.Height, aoSize.Width, aoSize.Height, 0, 90);

            // Add the bottom horizontal line to the Graphics Path object
            oExteriorGraphicPath.AddLine(aoRectangle.Right - (Single)(aoSize.Width / 2), aoRectangle.Bottom, aoRectangle.Left + (Single)(aoSize.Width / 2), aoRectangle.Bottom);

            // Add arc for the bottom left curve to the Graphics object
            oExteriorGraphicPath.AddArc(aoRectangle.Left, aoRectangle.Bottom - aoSize.Height, aoSize.Width, aoSize.Height, 90, 90);

            // Add left vertical line to the Graphics Path object
            oExteriorGraphicPath.AddLine(aoRectangle.Left, aoRectangle.Bottom - (Single)(aoSize.Height / 2), aoRectangle.Left, aoRectangle.Top + (Single)(aoSize.Height / 2));

            // Add arc for the top left curve to the Graphics object
            oExteriorGraphicPath.AddArc(aoRectangle.Left, aoRectangle.Top, aoSize.Width, aoSize.Height, 180, 90);
            return oExteriorGraphicPath;
        }
        #endregion

        #region Overriden Events
        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            // Get the size of the string in pixels for the string for a font
            this.moTextSize = e.Graphics.MeasureString(this.Text, this.Font);

            // Original Smoothing is Saved and Smoothing mode mode is change to AntiAlias
            SmoothingMode oldSmooting = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //-----------------------------Include in Paint--------------------------//
            //
            if (AllowTransparency)
            {
                MakeTransparent(this, e.Graphics);
            }
            //
            //-----------------------------Include in Paint--------------------------//



            // Draws shadow border for the control
            DrawBorder(e.Graphics, this.BorderRectangle);

            // Fill the rectangle that represents the border with gradient
            e.Graphics.FillPath(this.InteriorRegionPathBrush, this.InteriorRegionPath);

            // Draws the gradient background with shadows
            DrawInterior(e.Graphics);

            // Defines string format to center the string 
            StringFormat oStringFormat = new StringFormat();

            // The rectangle where the text is to be drawn
            RectangleF oRectangleF =
                new RectangleF(this.BorderRectangle.X + (Single)(this.mosizeBorderPixelIndent.Width / 2) + 8,
                this.BorderRectangle.Y + 2,
                moTextSize.Width + (Single)(this.mosizeBorderPixelIndent.Width / 2),
                moTextSize.Height);

            // Drawing the string in the rectangle
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(moHeadingTextColor), oRectangleF, oStringFormat);

            // Reseting the smoothingmode back to original for OS purposes.
            e.Graphics.SmoothingMode = oldSmooting;

            // Using the graphics path property regionpath to define the non rectangular shape for the control
            this.Region = new Region(this.ExteriorRegionPath);
        }
        #endregion

        #region Transparency


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



        #endregion

    }

    #endregion

    #region ColorScheme

    /// <summary>
    /// Interface ColorChanges
    /// </summary>
    public interface ColorChanges
    {
        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>The color of the font.</value>
        Color FontColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        Color ShadowColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the border top.
        /// </summary>
        /// <value>The color of the border top.</value>
        Color BorderTopColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the border bottom.
        /// </summary>
        /// <value>The color of the border bottom.</value>
        Color BorderBottomColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the background top.
        /// </summary>
        /// <value>The color of the background top.</value>
        Color BackgroundTopColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the background bottom.
        /// </summary>
        /// <value>The color of the background bottom.</value>
        Color BackgroundBottomColor { get; set; }
        /// <summary>
        /// Gets or sets the default color of the border.
        /// </summary>
        /// <value>The default color of the border.</value>
        Color DefaultBorderColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the disabled font.
        /// </summary>
        /// <value>The color of the disabled font.</value>
        Color DisabledFontColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the disbaled bottom.
        /// </summary>
        /// <value>The color of the disbaled bottom.</value>
        Color DisbaledBottomColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the disabled top.
        /// </summary>
        /// <value>The color of the disabled top.</value>
        Color DisabledTopColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the pressed font.
        /// </summary>
        /// <value>The color of the pressed font.</value>
        Color PressedFontColor { get; set; }



    }

    /// <summary>
    /// Enum represent a Color Scheme for <c><see cref="ZeroitGroupBoxCharm" /></c>,
    /// <c><see cref="ZeroitAcasiaGroupBox" /></c> and <c><see cref="ZeroitAcasiaGroupBoxWithToolbar" /></c>.
    /// </summary>
    public enum EnmColorScheme
    {
        /// <summary>
        /// The purple
        /// </summary>
        Purple,
        /// <summary>
        /// The green
        /// </summary>
        Green,
        /// <summary>
        /// The yellow
        /// </summary>
        Yellow,
        /// <summary>
        /// The custom
        /// </summary>
        Custom
    }
    /// <summary>
    /// This class works as a common point for all the controls to
    /// implement the color scheme
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ColorChanges" />
    internal class ZeroitGroupButtonColorScheme : ColorChanges
    {
        /// <summary>
        /// The o color scheme
        /// </summary>
        private EnmColorScheme oClrScheme;

        /// <summary>
        /// The font color
        /// </summary>
        public Color fontColor = Color.AliceBlue;
        /// <summary>
        /// The shadow color
        /// </summary>
        public Color shadowColor = Color.Blue;
        /// <summary>
        /// The border top color
        /// </summary>
        public Color borderTopColor = Color.DarkBlue;
        /// <summary>
        /// The border bottom color
        /// </summary>
        public Color borderBottomColor = Color.CadetBlue;
        /// <summary>
        /// The background top color
        /// </summary>
        public Color backgroundTopColor = Color.LightBlue;
        /// <summary>
        /// The background bottom color
        /// </summary>
        public Color backgroundBottomColor = Color.LemonChiffon;

        /// <summary>
        /// The default border color
        /// </summary>
        public Color defaultBorderColor = Color.BlueViolet;
        /// <summary>
        /// The disabled font color
        /// </summary>
        public Color disabledFontColor = Color.CornflowerBlue;
        /// <summary>
        /// The disbaled bottom color
        /// </summary>
        public Color disbaledBottomColor = Color.LightSkyBlue;
        /// <summary>
        /// The disabled top color
        /// </summary>
        public Color disabledTopColor = Color.PowderBlue;
        /// <summary>
        /// The pressed font color
        /// </summary>
        public Color pressedFontColor = Color.Black;

        /// <summary>
        /// Gets or sets the default color of the border.
        /// </summary>
        /// <value>The default color of the border.</value>
        Color ColorChanges.DefaultBorderColor
        {
            get { return defaultBorderColor; }
            set
            {
                defaultBorderColor = value;

            }
        }
        /// <summary>
        /// Gets or sets the color of the disabled font.
        /// </summary>
        /// <value>The color of the disabled font.</value>
        Color ColorChanges.DisabledFontColor
        {
            get { return disabledFontColor; }
            set
            {
                disabledFontColor = value;

            }
        }
        /// <summary>
        /// Gets or sets the color of the disbaled bottom.
        /// </summary>
        /// <value>The color of the disbaled bottom.</value>
        Color ColorChanges.DisbaledBottomColor
        {
            get { return disbaledBottomColor; }
            set
            {
                disbaledBottomColor = value;

            }
        }
        /// <summary>
        /// Gets or sets the color of the disabled top.
        /// </summary>
        /// <value>The color of the disabled top.</value>
        Color ColorChanges.DisabledTopColor
        {
            get { return disabledTopColor; }
            set
            {
                disabledTopColor = value;

            }
        }
        /// <summary>
        /// Gets or sets the color of the pressed font.
        /// </summary>
        /// <value>The color of the pressed font.</value>
        Color ColorChanges.PressedFontColor
        {
            get { return pressedFontColor; }
            set
            {
                pressedFontColor = value;

            }
        }

        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>The color of the font.</value>
        Color ColorChanges.FontColor
        {
            get { return fontColor; }
            set
            {
                fontColor = value;

            }
        }
        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        Color ColorChanges.ShadowColor
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value;

            }
        }
        /// <summary>
        /// Gets or sets the color of the border top.
        /// </summary>
        /// <value>The color of the border top.</value>
        Color ColorChanges.BorderTopColor
        {
            get { return borderTopColor; }
            set
            {
                borderTopColor = value;

            }
        }
        /// <summary>
        /// Gets or sets the color of the border bottom.
        /// </summary>
        /// <value>The color of the border bottom.</value>
        Color ColorChanges.BorderBottomColor
        {
            get { return borderBottomColor; }
            set
            {
                borderBottomColor = value;

            }
        }
        /// <summary>
        /// Gets or sets the color of the background top.
        /// </summary>
        /// <value>The color of the background top.</value>
        Color ColorChanges.BackgroundTopColor
        {
            get { return backgroundTopColor; }
            set
            {
                backgroundTopColor = value;

            }
        }
        /// <summary>
        /// Gets or sets the color of the background bottom.
        /// </summary>
        /// <value>The color of the background bottom.</value>
        Color ColorChanges.BackgroundBottomColor
        {
            get { return backgroundBottomColor; }
            set
            {
                backgroundBottomColor = value;

            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGroupButtonColorScheme"/> class.
        /// </summary>
        /// <param name="aoColorScheme">The ao color scheme.</param>
        public ZeroitGroupButtonColorScheme(EnmColorScheme aoColorScheme)
        {
            //
            // TODO: Add constructor logic here
            //
            oClrScheme = aoColorScheme;

        }
        /// <summary>
        /// This method sets the values of different color properties
        /// for controls of IGradientButtonColor Type
        /// </summary>
        /// <param name="aCtrl">a control.</param>
        public void SetColorScheme(IGradientButtonColor aCtrl)
        {
            switch (oClrScheme)
            {
                case EnmColorScheme.Green:
                    //=========================================================
                    //Setting color properties of button control for
                    //Green color scheme
                    //---------------------------------------------------------
                    aCtrl.BackgroundBottomColor = Color.FromArgb(193, 201, 140);
                    aCtrl.BackgroundTopColor = Color.FromArgb(230, 233, 208);
                    aCtrl.BorderBottomColor = Color.FromArgb(230, 233, 208);
                    aCtrl.BorderTopColor = Color.FromArgb(193, 201, 140);
                    aCtrl.DefaultBorderColor = Color.FromArgb(167, 168, 127);
                    aCtrl.DisabledFontColor = Color.FromArgb(156, 147, 113);
                    aCtrl.DisbaledBottomColor = Color.FromArgb(209, 215, 170);
                    aCtrl.DisabledTopColor = Color.FromArgb(240, 242, 227);
                    aCtrl.FontColor = Color.FromArgb(105, 110, 26);
                    aCtrl.PressedFontColor = Color.Black;
                    break;
                //---------------------------------------------------------
                case EnmColorScheme.Purple:
                    //=========================================================
                    //Setting color properties of button control for 
                    //Purple color scheme
                    //---------------------------------------------------------
                    aCtrl.BackgroundBottomColor = Color.FromArgb(183, 157, 206);
                    aCtrl.BackgroundTopColor = Color.FromArgb(231, 222, 239);
                    aCtrl.BorderBottomColor = Color.FromArgb(224, 215, 233);
                    aCtrl.BorderTopColor = Color.FromArgb(193, 157, 206);
                    aCtrl.DefaultBorderColor = Color.FromArgb(132, 100, 161);
                    aCtrl.DisabledFontColor = Color.FromArgb(143, 116, 156);
                    aCtrl.DisbaledBottomColor = Color.FromArgb(209, 192, 210);
                    aCtrl.DisabledTopColor = Color.FromArgb(237, 231, 230);
                    aCtrl.FontColor = Color.FromArgb(74, 30, 115);
                    aCtrl.PressedFontColor = Color.Black;
                    break;
                //---------------------------------------------------------
                case EnmColorScheme.Yellow:
                    //=========================================================
                    //Setting color properties of button control for 
                    //Yellow color scheme
                    //---------------------------------------------------------
                    aCtrl.BackgroundBottomColor = Color.FromArgb(194, 168, 120);
                    aCtrl.BackgroundTopColor = Color.FromArgb(248, 245, 224);
                    aCtrl.BorderBottomColor = Color.FromArgb(229, 219, 196);
                    aCtrl.BorderTopColor = Color.FromArgb(194, 168, 120);
                    aCtrl.DefaultBorderColor = Color.FromArgb(189, 153, 74);
                    aCtrl.DisabledFontColor = Color.FromArgb(156, 147, 113);
                    aCtrl.DisbaledBottomColor = Color.FromArgb(201, 177, 135);
                    aCtrl.DisabledTopColor = Color.FromArgb(241, 236, 212);
                    aCtrl.FontColor = Color.FromArgb(96, 83, 43);
                    aCtrl.PressedFontColor = Color.Black;
                    break;
                //---------------------------------------------------------

                case EnmColorScheme.Custom:
                    //=========================================================
                    //Setting color properties of button control for 
                    //Yellow color scheme
                    //---------------------------------------------------------
                    aCtrl.BorderTopColor = borderTopColor;
                    aCtrl.BorderBottomColor = borderBottomColor;
                    aCtrl.BackgroundTopColor = backgroundTopColor;
                    aCtrl.BackgroundBottomColor = backgroundBottomColor;
                    aCtrl.DefaultBorderColor = defaultBorderColor;
                    aCtrl.DisabledFontColor = disabledFontColor;
                    aCtrl.DisbaledBottomColor = disbaledBottomColor;
                    aCtrl.DisabledTopColor = disabledTopColor;
                    //aCtrl.FontColor = Color.FromArgb(96, 83, 43);
                    aCtrl.PressedFontColor = pressedFontColor;
                    break;
            }
        }

        /// <summary>
        /// This method sets the values of different color properties
        /// for controls of IGradientContainer Type
        /// </summary>
        /// <param name="aCtrl">a control.</param>
        /// <exception cref="Zeroit.Framework.MiscControls.InvalidColorSchemeException"></exception>
        public void SetColorScheme(IGradientContainer aCtrl)
        {
            switch (oClrScheme)
            {
                case EnmColorScheme.Green:
                    //=========================================================
                    // Setting color properties of container control for 
                    // Green color scheme
                    //---------------------------------------------------------
                    aCtrl.FontColor = Color.FromArgb(57, 66, 1);
                    aCtrl.ShadowColor = Color.FromArgb(142, 143, 116);
                    aCtrl.BorderTopColor = Color.FromArgb(225, 225, 183);
                    aCtrl.BorderBottomColor = Color.FromArgb(167, 168, 127);
                    aCtrl.BackgroundTopColor = Color.FromArgb(245, 243, 219);
                    aCtrl.BackgroundBottomColor = Color.FromArgb(214, 209, 153);
                    break;
                //---------------------------------------------------------
                case EnmColorScheme.Purple:
                    //=========================================================
                    // Setting color properties of container control for 
                    // Purple color scheme
                    //---------------------------------------------------------
                    aCtrl.FontColor = Color.FromArgb(137, 101, 163);
                    aCtrl.ShadowColor = Color.FromArgb(110, 92, 121);
                    aCtrl.BorderTopColor = Color.FromArgb(234, 218, 245);
                    aCtrl.BorderBottomColor = Color.FromArgb(191, 161, 211);
                    aCtrl.BackgroundTopColor = Color.FromArgb(251, 246, 255);
                    aCtrl.BackgroundBottomColor = Color.FromArgb(241, 229, 249);
                    break;
                //---------------------------------------------------------


                case EnmColorScheme.Yellow:
                    //=========================================================
                    // Setting color properties of container control for 
                    // Purple color scheme
                    //---------------------------------------------------------
                    aCtrl.FontColor = Color.FromArgb(137, 101, 163);
                    aCtrl.ShadowColor = Color.FromArgb(110, 92, 121);
                    aCtrl.BorderTopColor = Color.FromArgb(234, 218, 245);
                    aCtrl.BorderBottomColor = Color.FromArgb(191, 161, 211);
                    aCtrl.BackgroundTopColor = Color.FromArgb(251, 246, 255);
                    aCtrl.BackgroundBottomColor = Color.FromArgb(241, 229, 249);
                    break;
                //---------------------------------------------------------


                case EnmColorScheme.Custom:
                    //=========================================================
                    // Setting color properties of container control for 
                    // Purple color scheme
                    //---------------------------------------------------------
                    aCtrl.FontColor = fontColor;
                    aCtrl.ShadowColor = shadowColor;
                    aCtrl.BorderTopColor = borderTopColor;
                    aCtrl.BorderBottomColor = borderBottomColor;
                    aCtrl.BackgroundTopColor = backgroundTopColor;
                    aCtrl.BackgroundBottomColor = backgroundBottomColor;
                    break;
                //---------------------------------------------------------

                default:
                    // For container control if other than Purple or Green
                    // any other value is selected it throws an exception
                    throw new InvalidColorSchemeException();
            }
        }
    }
    /// <summary>
    /// This class define the exception which is thrown on invalid selection
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class InvalidColorSchemeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidColorSchemeException"/> class.
        /// </summary>
        public InvalidColorSchemeException() : base("Color Scheme Not Supported")
        {
        }
    }

    /// <summary>
    /// This interface defines properties
    /// for control that have diffrent colors
    /// is disabled mode i.e. ElongatedButton
    /// </summary>
    internal interface IGradientDisabledColor
    {
        /// <summary>
        /// Gets or sets the color of the disabled font.
        /// </summary>
        /// <value>The color of the disabled font.</value>
        Color DisabledFontColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the disbaled bottom.
        /// </summary>
        /// <value>The color of the disbaled bottom.</value>
        Color DisbaledBottomColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the disabled top.
        /// </summary>
        /// <value>The color of the disabled top.</value>
        Color DisabledTopColor { get; set; }
    }

    /// <summary>
    /// This interface defines property
    /// for the color of the text on
    /// the control
    /// </summary>
    internal interface IFontColor
    {
        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>The color of the font.</value>
        Color FontColor { get; set; }
    }

    /// <summary>
    /// This interface defines properties
    /// to set the control background
    /// Gradient's top color and bottom color
    /// </summary>
    internal interface IGradientBackgroundColor
    {
        /// <summary>
        /// Gets or sets the color of the background bottom.
        /// </summary>
        /// <value>The color of the background bottom.</value>
        Color BackgroundBottomColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the background top.
        /// </summary>
        /// <value>The color of the background top.</value>
        Color BackgroundTopColor { get; set; }
    }

    /// <summary>
    /// This interface defines properties
    /// to set control's Gradient Border's
    /// Top color and Bottom Color
    /// </summary>
    internal interface IGradientBorderColor
    {
        /// <summary>
        /// Gets or sets the color of the border top.
        /// </summary>
        /// <value>The color of the border top.</value>
        Color BorderTopColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the border bottom.
        /// </summary>
        /// <value>The color of the border bottom.</value>
        Color BorderBottomColor { get; set; }
    }

    /// <summary>
    /// This interface combines the interfaces
    /// needed for button controls and add button
    /// specific properties
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.IFontColor" />
    /// <seealso cref="Zeroit.Framework.MiscControls.IGradientDisabledColor" />
    /// <seealso cref="Zeroit.Framework.MiscControls.IGradientBackgroundColor" />
    /// <seealso cref="Zeroit.Framework.MiscControls.IGradientBorderColor" />
    internal interface IGradientButtonColor :
                    IFontColor, IGradientDisabledColor,
                    IGradientBackgroundColor, IGradientBorderColor
    {
        /// <summary>
        /// Gets or sets the color of the pressed font.
        /// </summary>
        /// <value>The color of the pressed font.</value>
        Color PressedFontColor { get; set; }
        /// <summary>
        /// Gets or sets the default color of the border.
        /// </summary>
        /// <value>The default color of the border.</value>
        Color DefaultBorderColor { get; set; }
    }

    /// <summary>
    /// This interface combines the interfaces
    /// needed for container controls and add
    /// container specific property
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.IFontColor" />
    /// <seealso cref="Zeroit.Framework.MiscControls.IGradientBackgroundColor" />
    /// <seealso cref="Zeroit.Framework.MiscControls.IGradientBorderColor" />
    internal interface IGradientContainer :
                        IFontColor, IGradientBackgroundColor,
                        IGradientBorderColor
    {
        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        Color ShadowColor { get; set; }
    }

    #endregion

    #region Elongated Button

    //   /// <summary>
    ///// Summary description for ElongatedButton.
    ///// </summary>
    //   /// 
    //   [ToolboxItem(false)]
    //public class ElongatedButton : System.Windows.Forms.ButtonBase,
    //       IGradientButtonColor, System.Windows.Forms.IButtonControl
    //   {

    //       #region Enums
    //       private enum ControlState
    //       {
    //           Normal,
    //           Pressed,
    //       }
    //       #endregion

    //       #region Private Data Members
    //       private ControlState enmState = ControlState.Normal;
    //       private EnmColorScheme mColorScheme = EnmColorScheme.Yellow;
    //       private Color clrBackground1;
    //       private Color clrBackground2;
    //       private Color clrDisabledBackground1;
    //       private Color clrDisabledBackground2;
    //       private Color clrBorder1;
    //       private Color clrBorder2;
    //       private Color clrDefaultBorder;
    //       private Color clrFontMouseUp;
    //       private Color clrFontMouseDown;
    //       private Color clrFontDisabled;
    //       private DialogResult myDialogResult;
    //       #region Private Properties
    //       private Rectangle BorderRectangle
    //       {
    //           get
    //           {
    //               Rectangle rc = this.ClientRectangle;
    //               if (rc.Height % 2 == 0)
    //               {
    //                   return new Rectangle(1, 1, rc.Width - 3, rc.Height - 2);
    //               }
    //               else
    //               {
    //                   return new Rectangle(1, 1, rc.Width - 3, rc.Height - 3);
    //               }
    //           }
    //       }
    //       #endregion
    //       #endregion

    //       #region Public Properties
    //       public override Color BackColor
    //       {
    //           get
    //           {
    //               return base.BackColor;
    //           }
    //           set
    //           {
    //               base.BackColor = Color.Transparent;
    //           }
    //       }

    //       public new FlatStyle FlatStyle
    //       {
    //           get
    //           {
    //               return base.FlatStyle;
    //           }
    //           set
    //           {
    //               base.FlatStyle = FlatStyle.Standard;
    //           }
    //       }

    //       public EnmColorScheme ColorScheme
    //       {
    //           get
    //           {
    //               return mColorScheme;
    //           }
    //           set
    //           {
    //               mColorScheme = value;
    //               ZeroitGroupButtonColorScheme oColorScheme = new ZeroitGroupButtonColorScheme(mColorScheme);
    //               oColorScheme.SetColorScheme(this);
    //           }
    //       }
    //       #endregion

    //       #region Interface Implementation
    //       Color IGradientBackgroundColor.BackgroundBottomColor
    //       {
    //           get
    //           {
    //               return clrBackground2;
    //           }
    //           set
    //           {
    //               clrBackground2 = value;
    //               this.Invalidate();
    //           }
    //       }

    //       Color IGradientBackgroundColor.BackgroundTopColor
    //       {
    //           get
    //           {
    //               return clrBackground1;
    //           }
    //           set
    //           {
    //               clrBackground1 = value;
    //               this.Invalidate();
    //           }
    //       }

    //       Color IGradientBorderColor.BorderBottomColor
    //       {
    //           get
    //           {
    //               return clrBorder1;
    //           }
    //           set
    //           {
    //               clrBorder1 = value;
    //               this.Invalidate();
    //           }
    //       }

    //       Color IGradientBorderColor.BorderTopColor
    //       {
    //           get
    //           {
    //               return clrBorder2;
    //           }
    //           set
    //           {
    //               clrBorder2 = value;
    //               this.Invalidate();
    //           }
    //       }

    //       Color IGradientDisabledColor.DisbaledBottomColor
    //       {
    //           get
    //           {
    //               return clrDisabledBackground2;
    //           }
    //           set
    //           {
    //               clrDisabledBackground2 = value;
    //               this.Invalidate();
    //           }
    //       }

    //       Color IGradientDisabledColor.DisabledTopColor
    //       {
    //           get
    //           {
    //               return clrDisabledBackground1;
    //           }
    //           set
    //           {
    //               clrDisabledBackground1 = value;
    //               this.Invalidate();
    //           }
    //       }

    //       Color IFontColor.FontColor
    //       {
    //           get
    //           {
    //               return clrFontMouseUp;
    //           }
    //           set
    //           {
    //               clrFontMouseUp = value;
    //               this.Invalidate();
    //           }
    //       }

    //       Color IGradientButtonColor.PressedFontColor
    //       {
    //           get
    //           {
    //               return clrFontMouseDown;
    //           }
    //           set
    //           {
    //               clrFontMouseDown = value;
    //           }
    //       }
    //       Color IGradientDisabledColor.DisabledFontColor
    //       {
    //           get
    //           {
    //               return clrFontDisabled;
    //           }
    //           set
    //           {
    //               clrFontDisabled = value;
    //               this.Invalidate();
    //           }
    //       }

    //       System.Drawing.Color IGradientButtonColor.DefaultBorderColor
    //       {
    //           get
    //           {
    //               return clrDefaultBorder;
    //           }
    //           set
    //           {
    //               clrDefaultBorder = value;
    //               this.Invalidate();
    //           }
    //       }

    //       // Add implementation to the IButtonControl.DialogResult property.
    //       public DialogResult DialogResult
    //       {
    //           get
    //           {
    //               return this.myDialogResult;
    //           }

    //           set
    //           {
    //               if (Enum.IsDefined(typeof(DialogResult), value))
    //               {
    //                   this.myDialogResult = value;
    //               }
    //           }
    //       }

    //       // Add implementation to the IButtonControl.NotifyDefault method.
    //       public void NotifyDefault(bool value)
    //       {
    //           if (this.IsDefault != value)
    //           {
    //               this.IsDefault = value;
    //           }
    //       }

    //       // Add implementation to the IButtonControl.PerformClick method.
    //       public void PerformClick()
    //       {
    //           if (this.CanSelect)
    //           {
    //               this.OnClick(EventArgs.Empty);
    //           }
    //       }
    //       #endregion

    //       public ElongatedButton() : base()
    //       {
    //           this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
    //           this.Height = 17;
    //           this.Font = new Font("Tahoma", 8);
    //           clrBackground1 = Color.FromArgb(248, 245, 224);
    //           clrBackground2 = Color.FromArgb(194, 168, 120);

    //           clrFontDisabled = Color.FromArgb(156, 147, 113);
    //           clrFontMouseUp = Color.FromArgb(96, 83, 43);
    //           clrFontMouseDown = Color.Black;

    //           clrBorder1 = Color.FromArgb(229, 219, 196);
    //           clrBorder2 = Color.FromArgb(194, 168, 120);

    //           clrDefaultBorder = Color.FromArgb(189, 153, 74);

    //           clrDisabledBackground1 = Color.FromArgb(241, 236, 212);
    //           clrDisabledBackground2 = Color.FromArgb(216, 198, 159);
    //       }
    //       #region Private Methods

    //       //Gets the Shadow colors which are the alpha colors of the 
    //       private Brush[] GetShadowBrushes()
    //       {
    //           int cintShadow = 2;
    //           Brush[] arrBrushes = new Brush[cintShadow - 1];
    //           int intAlphaOffset = 35;
    //           int intMaxAlpha = cintShadow * intAlphaOffset;

    //           for (int intIndex = 0; intIndex <= arrBrushes.GetUpperBound(0); intIndex++)
    //           {
    //               arrBrushes[intIndex] = new SolidBrush(Color.FromArgb(intMaxAlpha - (intIndex * intAlphaOffset), 174, 167, 124));
    //           }

    //           return arrBrushes;
    //       }

    //       private void OnDrawDefault(Graphics g)
    //       {
    //           Rectangle rcBorder = this.BorderRectangle;
    //           GraphicsPath myPath = GetGraphicPath(rcBorder);

    //           LinearGradientBrush brushBackGround =
    //               new LinearGradientBrush(rcBorder, clrBackground1, clrBackground2, LinearGradientMode.Vertical);
    //           Single[] relativeIntensisities = new Single[] { 0.0F, 0.08F, 1.0F };
    //           Single[] relativePositions = new Single[] { 0.0F, 0.44F, 1.0F };
    //           Blend blend = new Blend();

    //           blend.Factors = relativeIntensisities;
    //           blend.Positions = relativePositions;
    //           brushBackGround.Blend = blend;

    //           g.FillPath(brushBackGround, myPath);

    //           //Draw dark to light border for default button
    //           SolidBrush brushPen = new SolidBrush(clrDefaultBorder);
    //           Pen ps = new Pen(brushPen);

    //           DrawBorder(g, ps, this.BorderRectangle);
    //           brushPen = new SolidBrush(Color.FromArgb(128, clrDefaultBorder));
    //           ps = new Pen(brushPen);
    //           Rectangle rc = new Rectangle(this.BorderRectangle.X + 1, this.BorderRectangle.Y + 1, this.BorderRectangle.Width - 2, this.BorderRectangle.Height - 2);
    //           DrawBorder(g, ps, rc);
    //           rc.X += 1;
    //           rc.Y += 1;
    //           rc.Width -= 2;
    //           rc.Height -= 2;
    //           brushPen = new SolidBrush(Color.FromArgb(64, clrDefaultBorder));
    //           ps = new Pen(brushPen);
    //           DrawBorder(g, ps, rc);
    //       }

    //       private void OnDrawNormal(Graphics g)
    //       {
    //           Rectangle rcBorder = this.BorderRectangle;
    //           GraphicsPath myPath = GetGraphicPath(rcBorder);
    //           Region rgn = new Region(this.BorderRectangle);
    //           rgn.Intersect(myPath);
    //           LinearGradientBrush brushBackGround =
    //               new LinearGradientBrush(rcBorder, clrBackground1, clrBackground2, LinearGradientMode.Vertical);
    //           Single[] relativeIntensisities = new Single[] { 0.0F, 0.08F, 1.0F };
    //           Single[] relativePositions = new Single[] { 0.0F, 0.44F, 1.0F };
    //           Blend blend = new Blend();
    //           blend.Factors = relativeIntensisities;
    //           blend.Positions = relativePositions;
    //           brushBackGround.Blend = blend;

    //           g.FillRegion(brushBackGround, rgn);

    //           LinearGradientBrush brushPen =
    //               new LinearGradientBrush(this.BorderRectangle, clrBorder1, clrBorder2, LinearGradientMode.ForwardDiagonal);

    //           brushPen.Blend = blend;
    //           Pen ps = new Pen(brushPen);

    //           DrawBorder(g, ps, this.BorderRectangle);
    //       }

    //       //Create Grahics Path for the elongated buttons
    //       private GraphicsPath GetGraphicPath(Rectangle rc)
    //       {
    //           int adjust = rc.Height % 2 == 0 ? 0 : 1;

    //           GraphicsPath Mypath = new GraphicsPath();

    //           //Add Top Line
    //           Mypath.AddLine(rc.Left + (Single)(rc.Height / 2), rc.Top, rc.Right - (Single)(rc.Height / 2), rc.Top);
    //           //Add Right Semi Circle
    //           Mypath.AddArc(rc.Right - rc.Height, rc.Top, rc.Height, rc.Height, 270, 180);
    //           //Add Bottom Line
    //           Mypath.AddLine(rc.Right - (Single)(rc.Height / 2) - adjust, rc.Bottom, rc.Left + (Single)(rc.Height / 2) + adjust, rc.Bottom);
    //           //Add Left Semi Circle
    //           Mypath.AddArc(rc.Left, rc.Top, rc.Height, rc.Height, 90, 180);

    //           return Mypath;
    //       }

    //       private void DrawBorder(Graphics g, Pen p, Rectangle rc)
    //       {
    //           int adjust = rc.Height % 2 == 0 ? 0 : 1;

    //           g.DrawLine(p, rc.Left + (Single)(rc.Height / 2), rc.Top, rc.Right - (Single)(rc.Height / 2), rc.Top);
    //           g.DrawArc(p, rc.Right - rc.Height, rc.Top, rc.Height, rc.Height, 270, 180);
    //           g.DrawLine(p, rc.Right - (Single)(rc.Height / 2) - adjust, rc.Bottom, rc.Left + (Single)(rc.Height / 2) + adjust, rc.Bottom);
    //           g.DrawArc(p, rc.Left, rc.Top, rc.Height, rc.Height, 90, 180);
    //       }

    //       private void OnDrawDisabled(Graphics g)
    //       {
    //           Rectangle rcBorder = this.BorderRectangle;
    //           GraphicsPath myPath = GetGraphicPath(rcBorder);

    //           LinearGradientBrush brushBackGround =
    //               new LinearGradientBrush(rcBorder, clrDisabledBackground1, clrDisabledBackground2, LinearGradientMode.Vertical);

    //           Single[] relativeIntensisities = new Single[] { 0.0F, 0.08F, 1.0F };
    //           Single[] relativePositions = new Single[] { 0.0F, 0.44F, 1.0F };

    //           Blend blend = new Blend();
    //           blend.Factors = relativeIntensisities;
    //           blend.Positions = relativePositions;
    //           brushBackGround.Blend = blend;
    //           g.FillPath(brushBackGround, myPath);
    //           LinearGradientBrush brushPen = new LinearGradientBrush(this.BorderRectangle, clrBorder1, clrBorder2, LinearGradientMode.ForwardDiagonal);
    //           brushPen.Blend = blend;
    //           Pen ps = new Pen(brushPen);
    //           DrawBorder(g, ps, this.BorderRectangle);
    //       }

    //       private void OnDrawPressed(Graphics g)
    //       {
    //           Rectangle rcBorder = this.BorderRectangle;
    //           GraphicsPath myPath = GetGraphicPath(rcBorder);

    //           LinearGradientBrush brushBackGround =
    //               new LinearGradientBrush(rcBorder, clrBackground2, clrBackground1, LinearGradientMode.Vertical);

    //           Single[] relativeIntensisities = new Single[] { 0.0F, 0.32F, 1.0F };
    //           Single[] relativePositions = new Single[] { 0.0F, 0.02F, 1.0F };

    //           Blend blend = new Blend();
    //           blend.Factors = relativeIntensisities;
    //           blend.Positions = relativePositions;
    //           brushBackGround.Blend = blend;
    //           g.FillPath(brushBackGround, myPath);
    //           LinearGradientBrush brushPen =
    //               new LinearGradientBrush(this.BorderRectangle, clrBorder1, clrBorder2, LinearGradientMode.ForwardDiagonal);

    //           brushPen.Blend = blend;
    //           Pen ps = new Pen(brushPen);
    //           DrawBorder(g, ps, this.BorderRectangle);
    //       }

    //       private void OnDrawText(Graphics g)
    //       {
    //           SizeF sz = g.MeasureString(this.Text, this.Font);
    //           Brush[] br = GetShadowBrushes();
    //           RectangleF rcText = new RectangleF(this.BorderRectangle.Left + ((this.BorderRectangle.Width - sz.Width) / 2), this.BorderRectangle.Top + ((this.BorderRectangle.Height - sz.Height) / 2), sz.Width, sz.Height);

    //           for (int intIndex = 0; intIndex <= br.GetUpperBound(0); intIndex++)
    //           {
    //               g.DrawString(this.Text, this.Font, br[intIndex], rcText.X + (br.GetUpperBound(0) - intIndex), rcText.Y + (br.GetUpperBound(0) - intIndex));
    //           }
    //           if (enmState == ControlState.Normal)
    //           {
    //               if (this.Enabled)
    //               {
    //                   g.DrawString(this.Text, this.Font, new SolidBrush(clrFontMouseUp), rcText);
    //               }
    //               else
    //               {
    //                   g.DrawString(this.Text, this.Font, new SolidBrush(clrFontDisabled), rcText);
    //               }
    //           }
    //           else
    //           {
    //               g.DrawString(this.Text, this.Font, new SolidBrush(clrFontMouseDown), rcText);
    //           }
    //       }
    //       #endregion

    //       #region Overridden Methods

    //       protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //       {
    //           this.OnPaintBackground(e);
    //           SmoothingMode oldSmothing = e.Graphics.SmoothingMode;
    //           e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
    //           switch (enmState)
    //           {
    //               case ControlState.Normal:
    //                   if (this.Enabled)
    //                   {
    //                       if (this.Focused || this.IsDefault)
    //                       {
    //                           //when the control has the focus this method is called
    //                           OnDrawDefault(e.Graphics);
    //                       }
    //                       else
    //                       {
    //                           //when the contrl does not have the focus this method is acalled
    //                           OnDrawNormal(e.Graphics);
    //                       }
    //                   }
    //                   else
    //                   {
    //                       //when the button is disabled this method is called
    //                       OnDrawDisabled(e.Graphics);
    //                   }
    //                   break;
    //               case ControlState.Pressed:
    //                   //when the mouse is pressed over the button 
    //                   OnDrawPressed(e.Graphics);
    //                   break;
    //           }
    //           OnDrawText(e.Graphics);

    //           Rectangle rc = new Rectangle(this.BorderRectangle.X - 1, this.BorderRectangle.Y - 1, this.BorderRectangle.Width + 2, this.BorderRectangle.Height + 2);
    //           this.Region = new Region(GetGraphicPath(rc));
    //           e.Graphics.SmoothingMode = oldSmothing;
    //       }

    //       //Redraw control when the button is resized
    //       protected override void OnResize(EventArgs e)
    //       {
    //           this.Invalidate();
    //       }

    //       //Change the state to pressed
    //       protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //       {
    //           base.OnMouseDown(e);
    //           if (e.Button == MouseButtons.Left && e.Clicks == 1)
    //           {
    //               enmState = ControlState.Pressed;
    //               this.Invalidate();
    //           }
    //       }

    //       //Change the state to normal
    //       protected override void OnClick(EventArgs e)
    //       {
    //           base.OnClick(e);
    //           enmState = ControlState.Normal;
    //           this.Invalidate();
    //       }
    //       #endregion
    //   }

    #endregion

    #region GroupBox with Chamfer

    /// <summary>
    /// A class collection for rendering a GroupBox with chamfer.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.BaseContainer" />
    public class ZeroitGroupBoxCharm : BaseContainer
    {

        #region Private Data Members
        // The enum object to store the colorscheme value
        /// <summary>
        /// Me color scheme
        /// </summary>
        private EnmColorScheme meColorScheme = EnmColorScheme.Custom;


        /// <summary>
        /// The colors
        /// </summary>
        ZeroitGroupButtonColorScheme colors;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGroupBoxCharm" /> class.
        /// </summary>
        public ZeroitGroupBoxCharm() : base()
        {
            colors = new MiscControls.ZeroitGroupButtonColorScheme(meColorScheme);
        }

        #region Overridden Properties        
        /// <summary>
        /// Gets or sets the color of the background bottom.
        /// </summary>
        /// <value>The color of the background bottom.</value>
        public Color BackgroundBottomColor
        {
            get { return colors.backgroundBottomColor; }
            set
            {
                colors.backgroundBottomColor = value;


            }
        }

        /// <summary>
        /// Gets or sets the color of the background top.
        /// </summary>
        /// <value>The color of the background top.</value>
        public Color BackgroundTopColor
        {
            get { return colors.backgroundTopColor; }
            set
            {
                colors.backgroundTopColor = value;


            }
        }

        /// <summary>
        /// Gets or sets the color of the border bottom.
        /// </summary>
        /// <value>The color of the border bottom.</value>
        public Color BorderBottomColor
        {
            get { return colors.borderBottomColor; }
            set
            {
                colors.borderBottomColor = value;


            }
        }

        /// <summary>
        /// Gets or sets the color of the border top.
        /// </summary>
        /// <value>The color of the border top.</value>
        public Color BorderTopColor
        {
            get { return colors.borderTopColor; }
            set
            {
                colors.borderTopColor = value;


            }
        }

        /// <summary>
        /// Gets or sets the default color of the border.
        /// </summary>
        /// <value>The default color of the border.</value>
        public Color DefaultBorderColor
        {
            get { return colors.defaultBorderColor; }
            set
            {
                colors.defaultBorderColor = value;


            }
        }

        /// <summary>
        /// Gets or sets the color of the disabled font.
        /// </summary>
        /// <value>The color of the disabled font.</value>
        public Color DisabledFontColor
        {
            get { return colors.disabledFontColor; }
            set
            {
                colors.disabledFontColor = value;
                Invalidate();

            }
        }

        /// <summary>
        /// Gets or sets the color of the disabled top.
        /// </summary>
        /// <value>The color of the disabled top.</value>
        public Color DisabledTopColor
        {
            get { return colors.disabledTopColor; }
            set
            {
                colors.disabledTopColor = value;
                Invalidate();

            }
        }

        /// <summary>
        /// Gets or sets the color of the disbaled bottom.
        /// </summary>
        /// <value>The color of the disbaled bottom.</value>
        public Color DisbaledBottomColor
        {
            get { return colors.disbaledBottomColor; }
            set
            {
                colors.disbaledBottomColor = value;
                Invalidate();

            }
        }

        /// <summary>
        /// Gets or sets the button color scheme.
        /// </summary>
        /// <value>The button color scheme.</value>
        public override EnmColorScheme ZeroitGroupButtonColorScheme
        {
            get
            {
                return meColorScheme;
            }
            set
            {

                //if(value == EnmColorScheme.Custom)
                //{

                //    colors.backgroundBottomColor = BackgroundBottomColor;
                //    colors.backgroundTopColor = BackgroundTopColor;
                //    colors.borderBottomColor = BorderBottomColor;
                //    colors.borderTopColor = BorderTopColor;
                //    colors.defaultBorderColor = DefaultBorderColor;
                //    colors.disabledFontColor = DisabledFontColor;
                //    colors.disabledTopColor = DisabledTopColor;
                //    colors.disbaledBottomColor = DisbaledBottomColor;
                //}

                //switch (value)
                //{
                //    case EnmColorScheme.Purple:
                //        break;
                //    case EnmColorScheme.Green:
                //        break;
                //    case EnmColorScheme.Yellow:
                //        break;
                //    case EnmColorScheme.Custom:
                //        break;
                //    default:
                //        break;
                //}

                // Create object of ColorScheme Class
                //ZeroitGroupButtonColorScheme oColor = new ZeroitGroupButtonColorScheme(value);

                // Set the controls Diffrent color properties depending on the 
                // Color Scheme selected
                //oColor.SetColorScheme(this);
                colors.SetColorScheme(this);
                meColorScheme = value;
            }
        }

        // This property is being used in the BaseClass's OnPaint method to 
        // get the drawing path of the control
        /// <summary>
        /// Gets the interior region path.
        /// </summary>
        /// <value>The interior region path.</value>
        protected override GraphicsPath InteriorRegionPath
        {
            get
            {
                Rectangle oRectangle = new Rectangle(this.BorderRectangle.X + 1, this.BorderRectangle.Y + 1, this.BorderRectangle.Width - 2, this.BorderRectangle.Height - 2);
                Size oSize = new Size(mosizeBorderPixelIndent.Width - 2, mosizeBorderPixelIndent.Height - 2);
                return this.GetRoundedRectanglarPath(oRectangle, moTextSize, oSize);
            }
        }

        // This property is being used in the Base Class's OnPaint method to
        // get the region path of the control to shape the control that way
        /// <summary>
        /// Gets the exterior region path.
        /// </summary>
        /// <value>The exterior region path.</value>
        protected override GraphicsPath ExteriorRegionPath
        {
            get
            {
                Rectangle oRectangle = new Rectangle(this.BorderRectangle.X, this.BorderRectangle.Y, this.BorderRectangle.Width + 3, this.BorderRectangle.Height + 3);
                Size oSize = new Size(mosizeBorderPixelIndent.Width + 2, mosizeBorderPixelIndent.Width + 2);
                return this.GetRoundedRectanglarPath(oRectangle, new SizeF(moTextSize.Width + 3, moTextSize.Height), oSize);
            }
        }


        #endregion

        #region Private Methods
        // This Function Gets the Graphic Path to draw the Rectangle with Chamfer
        /// <summary>
        /// Gets the rounded rectanglar path.
        /// </summary>
        /// <param name="aoRectangle">The ao rectangle.</param>
        /// <param name="aoTextSize">Size of the ao text.</param>
        /// <param name="aoCurveSize">Size of the ao curve.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath GetRoundedRectanglarPath(Rectangle aoRectangle, SizeF aoTextSize, Size aoCurveSize)
        {
            GraphicsPath oGraphicPath = new GraphicsPath();

            //=======================================================================
            // Following code adds path for the chamfer to be drawn
            //-----------------------------------------------------------------------

            // Add arc for the top left corner curve to the graphic path
            oGraphicPath.AddArc(aoRectangle.Left, aoRectangle.Top, aoCurveSize.Width, aoCurveSize.Height, 180, 90);

            // Add top horizontal line for chamfer to the graphic path
            oGraphicPath.AddLine(aoRectangle.Left + (Single)(aoCurveSize.Height / 2), aoRectangle.Top,
                aoRectangle.Left + (Single)(aoCurveSize.Height / 2) + aoTextSize.Width + 2,
                aoRectangle.Top);

            // Add Right side arc for the chamfer to the Graphics object
            oGraphicPath.AddArc(aoRectangle.Left + aoTextSize.Width + 7,
                aoRectangle.Top, aoCurveSize.Width,
                aoCurveSize.Height, 270, 90);
            //=======================================================================

            // Add Top Horizontal line below the chamfer to the graphic path object
            oGraphicPath.AddLine(aoRectangle.Left + aoTextSize.Width + (Single)(aoCurveSize.Width + 7),
                aoRectangle.Top + (Single)(aoCurveSize.Height / 2),
                aoRectangle.Right - (Single)(aoCurveSize.Height / 2),
                aoRectangle.Top + (Single)(aoCurveSize.Height / 2));

            // Add arc for the top right corner curve to the Graphics Path object
            oGraphicPath.AddArc(aoRectangle.Right - aoCurveSize.Width,
                aoRectangle.Top + (Single)(aoCurveSize.Height / 2),
                aoCurveSize.Width,
                aoCurveSize.Height, 270, 90);

            // Add Right Vertical Line to the Graphics Path object
            oGraphicPath.AddLine(aoRectangle.Right, aoRectangle.Top + aoCurveSize.Height,
                aoRectangle.Right, aoRectangle.Bottom - (Single)(aoCurveSize.Height / 2));

            // Add arc for the bottom right corner curve to the Graphics Path object
            oGraphicPath.AddArc(aoRectangle.Right - aoCurveSize.Width,
                aoRectangle.Bottom - aoCurveSize.Height,
                aoCurveSize.Width, aoCurveSize.Height, 0, 90);

            // Add Bottom Horizontal line to the Graphics Path object
            oGraphicPath.AddLine(aoRectangle.Right - (Single)(aoCurveSize.Width / 2),
                aoRectangle.Bottom,
                aoRectangle.Left + (Single)(aoCurveSize.Width / 2),
                aoRectangle.Bottom);

            // Add arc for the bottom left corner curve to the graphics path object
            oGraphicPath.AddArc(aoRectangle.Left, aoRectangle.Bottom - aoCurveSize.Height,
                aoCurveSize.Width, aoCurveSize.Height, 90, 90);

            // Add Left Vertical Line to the GraphicsPath object
            oGraphicPath.AddLine(aoRectangle.Left, aoRectangle.Bottom - (Single)(aoCurveSize.Height / 2),
                aoRectangle.Left, aoRectangle.Top + (Single)(aoCurveSize.Height / 2));
            return oGraphicPath;
        }
        #endregion

        #region Overridden Methods

        // This method is called in the OnPaint Method of the base class
        /// <summary>
        /// Draws the border.
        /// </summary>
        /// <param name="aoGraphics">The ao graphics.</param>
        /// <param name="aoRectangle">The ao rectangle.</param>
        protected override void DrawBorder(Graphics aoGraphics, Rectangle aoRectangle)
        {


            Pen oPen;
            Size oSize = new Size(mosizeBorderPixelIndent.Width, mosizeBorderPixelIndent.Height);

            Rectangle oRectangle = new Rectangle(aoRectangle.X, aoRectangle.Y, aoRectangle.Width, aoRectangle.Height);
            SizeF aotextsize = aoGraphics.MeasureString(this.Text, this.Font);

            // Draw the shadows for the borders
            for (int i = 0; i <= 2; i++)
            {
                // Creates a pen to draw Lines and Arcs Dark To Light
                oPen = new Pen(Color.FromArgb((2 - i + 1) * 64, this.ShadowColor));

                // Draws a shadow arc for the Chamfer's right hand side
                aoGraphics.DrawArc(oPen, oRectangle.Left + aotextsize.Width - i,
                    oRectangle.Top + 2, oSize.Width, oSize.Height, 270, 90);

                // Draws a shadow arc for the Top Right corner
                aoGraphics.DrawArc(oPen, oRectangle.Right - oSize.Width,
                    oRectangle.Top + (Single)(oSize.Height / 2) + 2,
                    oSize.Width, oSize.Height, 270, 90);

                // Draws a vertical shadow line for the right side
                aoGraphics.DrawLine(oPen, oRectangle.Right, oRectangle.Top + oSize.Height,
                    oRectangle.Right, oRectangle.Bottom - (Single)(oSize.Height / 2));

                // Draws a shadow arc for bottom right corner
                aoGraphics.DrawArc(oPen, oRectangle.Right - oSize.Width,
                    oRectangle.Bottom - oSize.Height, oSize.Width,
                    oSize.Height, 0, 90);

                // Creates a pen to draw lines and arcs Light to Dark
                oPen = new Pen(Color.FromArgb((2 - i) * 127, this.ShadowColor));

                // Draws a horizontal shadow line for the bottom
                aoGraphics.DrawLine(oPen, oRectangle.Right - (Single)(oSize.Width / 2),
                    oRectangle.Bottom, oRectangle.Left + (Single)(oSize.Width / 2),
                    oRectangle.Bottom);

                // Draw a shadow arc for the bottom left corner
                aoGraphics.DrawArc(oPen, oRectangle.Left + 2, oRectangle.Bottom - oSize.Height,
                    oSize.Width, oSize.Height, 90, 90);

                // Increasing the Rectangles X and Y position
                oRectangle.X += 1;
                oRectangle.Y += 1;

                // Reducing Height and width of the rectangle
                oRectangle.Width -= 2;
                oRectangle.Height -= 2;

                // Reducing the size of the arcs to draw the arcs properly
                oSize.Height -= 2;
                oSize.Width -= 2;
            }
        }
        #endregion
    }

    #endregion

    #region RoundedRectangular GroupBox

    /// <summary>
    /// A class collection for rendering a Rounded Rectangular GroupBox.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.BaseContainer" />
	public class ZeroitAcasiaGroupBox : BaseContainer
    {
        #region Private data members
        // The enum object to store the colorscheme value
        /// <summary>
        /// Me color scheme
        /// </summary>
        private EnmColorScheme meColorScheme = EnmColorScheme.Green;
        #endregion

        #region Public Properties
        // Overriding the base class's Mustoverride ColorScheme Property        
        /// <summary>
        /// Gets or sets the group button color scheme.
        /// </summary>
        /// <value>The group button color scheme.</value>
        public override EnmColorScheme ZeroitGroupButtonColorScheme
        {
            get
            {
                return meColorScheme;
            }
            set
            {
                ZeroitGroupButtonColorScheme oColorScheme = new ZeroitGroupButtonColorScheme(value);
                oColorScheme.SetColorScheme(this);
                meColorScheme = value;
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAcasiaGroupBox" /> class.
        /// </summary>
        public ZeroitAcasiaGroupBox() : base()
        { }

        #region Overridden Methods

        // This method is called in the base class' OnPaint method
        /// <summary>
        /// Draws the border.
        /// </summary>
        /// <param name="aoGraphics">The ao graphics.</param>
        /// <param name="aoRectangle">The ao rectangle.</param>
        protected override void DrawBorder(System.Drawing.Graphics aoGraphics, System.Drawing.Rectangle aoRectangle)
        {
            Rectangle oRcInterior;

            // Check if text property is Empty
            if (this.Text.Trim() != "")
            {
                // Creating rectangle to draw interior with more top width than other side of border
                oRcInterior = new Rectangle(this.BorderRectangle.X + this.BorderWidth + 1,
                    this.BorderRectangle.Y + 12 + this.BorderWidth,
                    this.BorderRectangle.Width - (this.BorderWidth * 2),
                    this.BorderRectangle.Height - (12 + this.BorderWidth * 2));
            }
            else
            {
                // Creating rectangle to draw interior with all sides equall
                oRcInterior = new Rectangle(this.BorderRectangle.X + this.BorderWidth + 1,
                    this.BorderRectangle.Y + this.BorderWidth + 1,
                    this.BorderRectangle.Width - (this.BorderWidth * 2),
                    this.BorderRectangle.Height - (this.BorderWidth * 2));
            }

            SolidBrush oSoildBrush;

            // Draw shadows 
            for (int i = 1; i >= 0; i--)
            {
                // Define Shadow Brushes Dark to Light
                oSoildBrush = new SolidBrush(Color.FromArgb(127 * (2 - i), this.ShadowColor));
                Pen p = new Pen(oSoildBrush);

                // Draws vertical line on Left side
                aoGraphics.DrawLine(p, oRcInterior.X, oRcInterior.Y, oRcInterior.X, oRcInterior.Bottom);

                // Draws horizontal lines on the top
                aoGraphics.DrawLine(p, oRcInterior.X, oRcInterior.Y, oRcInterior.Right, oRcInterior.Y);

                // Increasing the X and Y postion of the rectangle
                oRcInterior.X += 1;
                oRcInterior.Y += 1;

                // Reducing the height and width of the rectangle
                oRcInterior.Width -= 2;
                oRcInterior.Height -= 2;
            }

            // Brush of LinearGradient type is created to draw gradient
            IGradientContainer oContainer = this;
            LinearGradientBrush oGradientBrush =
                new LinearGradientBrush(oRcInterior, oContainer.BackgroundTopColor,
                oContainer.BackgroundBottomColor, LinearGradientMode.Vertical);

            // Blend is used to define the blend of the gradient
            Blend oBlend = new Blend();
            oBlend.Factors = this.IARR_RELATIVEINTENSITIES;
            oBlend.Positions = this.IARR_RELATIVEPOSITIONS;
            oGradientBrush.Blend = oBlend;

            // Fill the rectangle using Gradient Brush Created above
            aoGraphics.FillRectangle(oGradientBrush, oRcInterior);
        }
        #endregion
    }

    #endregion

    #region Rounded RectangularGroupBox With Toolbar

    /// <summary>
    /// A class collection for rendering a Rounded Rectangular GroupBox With Toolbar.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.BaseContainer" />
	public class ZeroitAcasiaGroupBoxWithToolbar : BaseContainer
    {
        #region Private Data Members
        // This data member store value of width of the toolbar
        /// <summary>
        /// The mi tool bar width
        /// </summary>
        private int miToolBarWidth = 110;
        // The enum object to store the colorscheme value
        /// <summary>
        /// Me color scheme
        /// </summary>
        private EnmColorScheme meColorScheme = EnmColorScheme.Green;
        #endregion

        #region Public Data Members

        // This property is used to Get and set the toolbarwidth        
        /// <summary>
        /// Gets or sets the width of the toolbar.
        /// </summary>
        /// <value>The width of the toolbar.</value>
        public int ToolbarWidth
        {
            get
            {
                return miToolBarWidth;
            }
            set
            {
                miToolBarWidth = value;
                this.Invalidate();
            }
        }

        // Overriding the base class's Mustoverride ColorScheme Property        
        /// <summary>
        /// Gets or sets the button's color scheme.
        /// </summary>
        /// <value>The button's color scheme.</value>
        public override EnmColorScheme ZeroitGroupButtonColorScheme
        {
            get
            {
                return meColorScheme;
            }
            set
            {
                // Create object of ColorScheme Class
                ZeroitGroupButtonColorScheme oColorScheme = new ZeroitGroupButtonColorScheme(value);
                // Set the controls Diffrent color properties depending on the 
                // Color Scheme selected
                oColorScheme.SetColorScheme(this);
                meColorScheme = value;
                this.Invalidate();
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAcasiaGroupBoxWithToolbar" /> class.
        /// </summary>
        public ZeroitAcasiaGroupBoxWithToolbar() : base() { }

        #region Private Methods
        // This Function is to get the Graphic path to draw the non rectangular interior
        /// <summary>
        /// Gets the interior rounded rectanglar path.
        /// </summary>
        /// <param name="aoRectangle">The ao rectangle.</param>
        /// <param name="iBarWidth">Width of the i bar.</param>
        /// <param name="sz">The sz.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath GetInteriorRoundedRectanglarPath(Rectangle aoRectangle, int iBarWidth, Size sz)
        {
            GraphicsPath oInteriorPath = new GraphicsPath();

            // Add top horizontal line till the downward curve to graphics path
            oInteriorPath.AddLine(aoRectangle.Left, aoRectangle.Top,
                aoRectangle.Right - iBarWidth - (Single)(sz.Width / 2),
                aoRectangle.Top);

            // Add arc to graphics path get the downward curve
            oInteriorPath.AddArc(aoRectangle.Right - iBarWidth - (Single)(sz.Width / 2),
                aoRectangle.Top - (Single)(sz.Height / 2),
                sz.Width, sz.Height, 180, -90);

            // Add Horizontal line from the curve to the right edge
            oInteriorPath.AddLine(aoRectangle.Right - iBarWidth,
                aoRectangle.Top + (Single)(sz.Height / 2),
                aoRectangle.Right,
                aoRectangle.Top + (Single)(sz.Height / 2));

            // Add right vertical line to the graphics path
            oInteriorPath.AddLine(aoRectangle.Right, aoRectangle.Top + (Single)(sz.Height / 2),
                aoRectangle.Right, aoRectangle.Bottom);

            // Add bottom horizontal line to the graphics path
            oInteriorPath.AddLine(aoRectangle.Right, aoRectangle.Bottom,
                aoRectangle.Left, aoRectangle.Bottom);

            // Add left vertical line to the graphics path
            oInteriorPath.AddLine(aoRectangle.Left, aoRectangle.Bottom,
                aoRectangle.Left, aoRectangle.Top);

            return oInteriorPath;
        }
        #endregion

        #region Overridden Methods

        // this method is called in the Onpaint method of the base class
        /// <summary>
        /// Draws the interior.
        /// </summary>
        /// <param name="aoGraphics">The ao graphics.</param>
        protected override void DrawInterior(System.Drawing.Graphics aoGraphics)
        {
            // Create rectangle to draw interior
            Rectangle oRcInterior = new Rectangle(this.BorderRectangle.X + this.BorderWidth + 1,
                this.BorderRectangle.Y + this.BorderWidth + 12,
                this.BorderRectangle.Width - (this.BorderWidth * 2),
                this.BorderRectangle.Height - (12 + this.BorderWidth * 2));

            int iWdth = miToolBarWidth;
            SolidBrush oSolidBrush;

            for (int i = 1; i >= 0; i--)
            {
                // Define Shadow Brushes Dark to Light
                oSolidBrush = new SolidBrush(Color.FromArgb(127 * (2 - i), this.ShadowColor));
                Pen oPen = new Pen(oSolidBrush);

                // Draws vertical shadow lines on the left
                aoGraphics.DrawLine(oPen, oRcInterior.X, oRcInterior.Y, oRcInterior.X, oRcInterior.Bottom);

                // Draws horizontal shadow line till the Toolbar
                aoGraphics.DrawLine(oPen, oRcInterior.X, oRcInterior.Y,
                    oRcInterior.Right - iWdth - (Single)(mosizeBorderPixelIndent.Width / 2),
                    oRcInterior.Y);

                // Draws Shadow for the downward arc
                aoGraphics.DrawArc(oPen, oRcInterior.Right - iWdth - (Single)(mosizeBorderPixelIndent.Width / 2),
                    oRcInterior.Top - (Single)(mosizeBorderPixelIndent.Height / 2),
                    mosizeBorderPixelIndent.Width, mosizeBorderPixelIndent.Height, 180, -90);

                // Draws the horizontal shadow line after the curve
                aoGraphics.DrawLine(oPen, oRcInterior.Right - iWdth - 1,
                    oRcInterior.Y + (Single)(mosizeBorderPixelIndent.Height / 2),
                    oRcInterior.Right,
                    oRcInterior.Y + (Single)(mosizeBorderPixelIndent.Height / 2));

                // Increasing the X and Y postion of the rectangle
                oRcInterior.X += 1;
                oRcInterior.Y += 1;

                // Reducing the height and width of the rectangle
                oRcInterior.Width -= 2;
                oRcInterior.Height -= 2;
            }

            // Brush of LinearGradient type is created to draw gradient
            IGradientContainer oConatiner = this;
            LinearGradientBrush oGradientBrush =
                new LinearGradientBrush(oRcInterior,
                oConatiner.BackgroundTopColor,
                oConatiner.BackgroundBottomColor,
                LinearGradientMode.Vertical);

            // Blend is used to define the blend of the gradient
            Blend oBlend = new Blend();
            oBlend.Factors = this.IARR_RELATIVEINTENSITIES;
            oBlend.Positions = this.IARR_RELATIVEPOSITIONS;
            oGradientBrush.Blend = oBlend;

            // Fill the rectangle using Gradient Brush created above
            aoGraphics.FillPath(oGradientBrush, GetInteriorRoundedRectanglarPath(oRcInterior, miToolBarWidth, mosizeBorderPixelIndent));
        }
        #endregion

    }

    #endregion

    #endregion

}
