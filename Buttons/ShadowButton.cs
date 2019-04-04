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

    #region Shadow Button

    /// <summary>
    /// A class collection for rendering a shadow button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitButtonShadow : Control
    {
        #region Private Fields
        private float _ShadowDistance = -7f;
        private float depth = 7;
        private int shadowAlpha = 180;
        private float _Radius = 1;
        private float radiusCurvature = 2f;
        private bool shadow = true;

        private Color shadowColor = Color.DimGray;
        private Color backgroundColor1 = Color.Tomato;
        private Color backgroundColor2 = Color.MistyRose;

        private Color borderColor = Color.DimGray;
        private float borderWidth = 1f;
        private LinearGradientMode gradientMode = LinearGradientMode.Vertical;

        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitButtonShadow"/> has shadow enabled.
        /// </summary>
        /// <value><c>true</c> if shadow; otherwise, <c>false</c>.</value>
        public bool Shadow
        {
            get { return shadow; }
            set
            {
                shadow = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the radius curvature.
        /// </summary>
        /// <value>The radius curvature.</value>
        public float RadiusCurvature
        {
            get { return radiusCurvature; }
            set
            {
                if (value < 0.1f)
                {
                    value = 0.1f;
                }

                radiusCurvature = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border radius.
        /// </summary>
        /// <value>The border radius.</value>
        public float BorderRadius
        {
            get { return _Radius; }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                _Radius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shadow alpha.
        /// </summary>
        /// <value>The shadow alpha.</value>
        public int ShadowAlpha
        {
            get { return shadowAlpha; }
            set
            {
                shadowAlpha = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient mode.
        /// </summary>
        /// <value>The gradient mode.</value>
        public LinearGradientMode GradientMode
        {
            get { return gradientMode; }
            set
            {
                gradientMode = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        public Color ShadowColor
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value>The background color1.</value>
        public Color BackgroundColor1
        {
            get { return backgroundColor1; }
            set
            {
                backgroundColor1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value>The background color2.</value>
        public Color BackgroundColor2
        {
            get { return backgroundColor2; }
            set
            {
                backgroundColor2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public float BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shadow depth.
        /// </summary>
        /// <value>The shadow depth.</value>
        public float ShadowDepth
        {
            get { return depth; }
            set
            {
                depth = value;

                _ShadowDistance = 0f - depth;

                Invalidate();
            }
        }
        
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonShadow"/> class.
        /// </summary>
        public ZeroitButtonShadow()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);

        }

        #endregion
        
        #region Methods and overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawRndRect(ref e);

        }

        private void DrawRndRect(ref PaintEventArgs e)
        {
            // I like clean lines so set the smoothingmode to Anti-Alias
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // lets create a rectangle that will be centered in the picturebox and
            // just under half the size

            Rectangle _Rectangle = new Rectangle(10 + (int)depth, 10 + (int)depth, this.Width - 20 - (int)depth, this.Height - 20 - (int)depth);
            //Rectangle _Rectangle = new Rectangle((int)(picCanvas.Width * .3), (int)(picCanvas.Height * .3),
            //    (int)(picCanvas.Width * .4), (int)(picCanvas.Height * .4));

            // create the radius variable and set it equal to 20% the height of the rectangle
            // this will determine the amount of bend at the corners
            _Radius = (int)(_Rectangle.Height * .2);

            // create an x and y variable so that we can reduce the length of our code lines
            float X = _Rectangle.Left;
            float Y = _Rectangle.Top;

            // make sure that we have a valid radius, too small and we have a problem
            if (_Radius < 1)
                _Radius = 1;

            try
            {
                // Create a graphicspath object with the using operator so the framework
                // can clean up the resources for us
                using (GraphicsPath _Path = new GraphicsPath())
                {
                    // build the rounded rectangle starting at the top line and going around
                    // until the line meets itself again
                    _Path.AddLine(X + _Radius, Y, X + _Rectangle.Width - (_Radius * radiusCurvature), Y);
                    _Path.AddArc(X + _Rectangle.Width - (_Radius * radiusCurvature), Y, (_Radius * radiusCurvature), (_Radius * radiusCurvature), 270, 90);
                    _Path.AddLine(X + _Rectangle.Width, Y + _Radius, X + _Rectangle.Width, Y + _Rectangle.Height - (_Radius * 2));
                    _Path.AddArc(X + _Rectangle.Width - (_Radius * radiusCurvature), Y + _Rectangle.Height - (_Radius * radiusCurvature), (_Radius * radiusCurvature), (_Radius * radiusCurvature), 0, 90);
                    _Path.AddLine(X + _Rectangle.Width - (_Radius * radiusCurvature), Y + _Rectangle.Height, X + _Radius, Y + _Rectangle.Height);
                    _Path.AddArc(X, Y + _Rectangle.Height - (_Radius * radiusCurvature), (_Radius * radiusCurvature), (_Radius * radiusCurvature), 90, 90);
                    _Path.AddLine(X, Y + _Rectangle.Height - (_Radius * radiusCurvature), X, Y + _Radius);
                    _Path.AddArc(X, Y, (_Radius * radiusCurvature), (_Radius * radiusCurvature), 180, 90);

                    // this is where we create the shadow effect, so we will use a 
                    // pathgradientbursh

                    PathGradientBrush _Brush = new PathGradientBrush(_Path);

                    // set the wrapmode so that the colors will layer themselves
                    // from the outer edge in
                    _Brush.WrapMode = WrapMode.Clamp;

                    // Create a color blend to manage our colors and positions and
                    // since we need 3 colors set the default length to 3
                    ColorBlend _ColorBlend = new ColorBlend(3);

                    // here is the important part of the shadow making process, remember
                    // the clamp mode on the colorblend object layers the colors from
                    // the outside to the center so we want our transparent color first
                    // followed by the actual shadow color. Set the shadow color to a 
                    // slightly transparent DimGray, I find that it works best.

                    if (Shadow)
                    {
                        _ColorBlend.Colors = new Color[] { Color.Transparent, Color.FromArgb(shadowAlpha, shadowColor), Color.FromArgb(shadowAlpha, shadowColor) };
                    }

                    else
                    {
                        _ColorBlend.Colors = new Color[] { Color.Transparent, Color.FromArgb(0, shadowColor), Color.FromArgb(0, shadowColor) };
                    }


                    // our color blend will control the distance of each color layer
                    // we want to set our transparent color to 0 indicating that the 
                    // transparent color should be the outer most color drawn, then
                    // our Dimgray color at about 10% of the distance from the edge
                    _ColorBlend.Positions = new float[] { 0f, .1f, 1f };

                    // assign the color blend to the pathgradientbrush
                    _Brush.InterpolationColors = _ColorBlend;

                    // fill the shadow with our pathgradientbrush
                    e.Graphics.FillPath(_Brush, _Path);

                    // since the shadow was drawm first we need to move the actual path
                    // up and back a little so that we can show the shadow underneath
                    // the object. To accomplish this we will create a Matrix Object
                    Matrix _Matrix = new Matrix();

                    // tell the matrix to move the path up and back the designated distance
                    _Matrix.Translate(_ShadowDistance, _ShadowDistance);

                    // assign the matrix to the graphics path of the rounded rectangle
                    _Path.Transform(_Matrix);

                    // fill the graphics path first
                    LinearGradientBrush _LinBrush = new LinearGradientBrush(this.ClientRectangle, backgroundColor1, backgroundColor2, gradientMode);
                    e.Graphics.FillPath(_LinBrush, _Path);


                    //using (LinearGradientBrush _Brush = new LinearGradientBrush(
                    //                picCanvas.ClientRectangle, Color.Tomato, Color.MistyRose, LinearGradientMode.Vertical))
                    //{
                    //    e.Graphics.FillPath(_Brush, _Path);
                    //}

                    // Draw the Graphicspath last so that we have cleaner borders
                    using (Pen _Pen = new Pen(borderColor, borderWidth))
                    {
                        e.Graphics.DrawPath(_Pen, _Path);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(GetType().Name + ".DrawRndRect() Error: " + ex.Message);
            }
        }

        #endregion

    }

    #endregion


}
