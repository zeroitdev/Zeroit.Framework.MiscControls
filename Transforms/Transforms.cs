// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Transforms.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Zeroit.Framework.MiscControls.HelperControls.AnimationHelpers.WinFormAnimation;
using Zeroit.Framework.MiscControls.HelperControls.Widgets;

namespace Zeroit.Framework.MiscControls
{

    /// <summary>
    /// A class collection for rendering a transform-like animation control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitTransforms : Control
    {

        #region Private Fields
        /// <summary>
        /// The border type
        /// </summary>
        private TypeOfBorder _borderType = TypeOfBorder.Normal;

        /// <summary>
        /// The back fill
        /// </summary>
        private Filler backFill = new Filler(Color.Blue);

        /// <summary>
        /// The border
        /// </summary>
        private Zeroit.Framework.MiscControls.HelperControls.Widgets.Line border = new HelperControls.Widgets.Line();

        /// <summary>
        /// The solidify
        /// </summary>
        private bool solidify = false;

        /// <summary>
        /// The magic border
        /// </summary>
        private bool magicBorder = false;

        /// <summary>
        /// The scale trans
        /// </summary>
        private float[] scaleTrans = new float[]
        {
            90f,
            90f,
        };

        /// <summary>
        /// The transl trans
        /// </summary>
        private int[] translTrans = new int[]
        {
            5,
            90,
            5
        };

        /// <summary>
        /// The sizes
        /// </summary>
        private int sizes = 2;

        /// <summary>
        /// The maximum
        /// </summary>
        private int maximum = 12;

        /// <summary>
        /// The rota trans
        /// </summary>
        private float rotaTrans = 5;

        /// <summary>
        /// The rot trans
        /// </summary>
        private int[] rotTrans = new int[]
        {
            -1,
            -1,
            2,
            2
        };

        /// <summary>
        /// The drop value
        /// </summary>
        private float dropValue = 0;

        /// <summary>
        /// The normal border
        /// </summary>
        private Color normalBorder = Color.Black;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTransforms"/> class.
        /// </summary>
        public ZeroitTransforms()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            #region MyRegion
            if (DesignMode)
            {
                timer.Tick += Timer_Tick;
                if (AutoAnimate)
                {
                    timer.Interval = 100;
                    timer.Start();
                }
            }

            if (!DesignMode)
            {
                timer.Tick += Timer_Tick;

                if (AutoAnimate)
                {
                    timer.Interval = 100;
                    timer.Start();
                }
            }



            #endregion

            #region AutoIncrement Animation

            peaceAnimator.Control = this;
            peaceAnimator.DurationValue = (ulong)speed[2];
            peaceAnimator.Repeat = true;
            peaceAnimator.Reverse = true;
            peaceAnimator.OneDProperty = HelperControls.AnimationHelpers.WinFormAnimation.Animator.KnownProperties.Custom;
            peaceAnimator.PropertyName = "TransRota";
            peaceAnimator.StartValue = 0;
            //peaceAnimator.EndValue = maximum;


            #endregion



        }

        #endregion

        #region Enum

        /// <summary>
        /// Enum representing the type of border
        /// </summary>
        public enum TypeOfBorder
        {
            /// <summary>
            /// The normal
            /// </summary>
            Normal,
            /// <summary>
            /// The magic
            /// </summary>
            Magic
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the drop value.
        /// </summary>
        /// <value>The drop value.</value>
        public float DropValue
        {
            get { return dropValue; }
            set
            {
                dropValue = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get { return maximum; }
            set
            {

                maximum = value;

                peaceAnimator.EndValue = maximum;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the sizes.
        /// </summary>
        /// <value>The sizes.</value>
        public int Sizes
        {
            get { return sizes; }
            set
            {
                sizes = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the transform scale.
        /// </summary>
        /// <value>The transform scale.</value>
        public float[] TransScale
        {
            get { return scaleTrans; }
            set
            {
                scaleTrans = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the transform translation.
        /// </summary>
        /// <value>The transform translation.</value>
        public int[] TransTransL
        {
            get { return translTrans; }
            set
            {
                translTrans = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the transform rotation.
        /// </summary>
        /// <value>The transform rotation.</value>
        public float TransRota
        {
            get { return rotaTrans; }
            set
            {
                rotaTrans = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the transform rotations.
        /// </summary>
        /// <value>The trans rot.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Value must be more than 0
        /// or
        /// Value must be more than 0
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Value must be more than 0
        /// or
        /// Value must be more than 0</exception>
        public int[] TransRot
        {
            get { return rotTrans; }
            set
            {
                //if(value[0] < 1 )
                //{
                //    value[0] = 1;
                //    throw new ArgumentOutOfRangeException("", "Value must be more than 0");

                //}

                if (value[2] < 1)
                {
                    value[2] = 1;
                    throw new ArgumentOutOfRangeException("", "Value must be more than 0");

                }

                if (value[3] < 1)
                {
                    value[3] = 1;
                    throw new ArgumentOutOfRangeException("", "Value must be more than 0");

                }

                rotTrans = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitTransforms" /> should be solidified.
        /// </summary>
        /// <value><c>true</c> if solidify; otherwise, <c>false</c>.</value>
        public bool Solidify
        {
            get { return solidify; }
            set
            {
                solidify = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background fill.
        /// </summary>
        /// <value>The background fill.</value>
        public Filler BackFill
        {
            get { return backFill; }
            set
            {
                backFill = value.Clone();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        public Zeroit.Framework.MiscControls.HelperControls.Widgets.Line Border
        {
            get { return border; }
            set
            {
                border = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type of the border.
        /// </summary>
        /// <value>The type of the border.</value>
        public TypeOfBorder BorderType
        {
            get
            {
                return _borderType;
            }

            set
            {
                _borderType = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the normal border.
        /// </summary>
        /// <value>The normal border.</value>
        public Color NormalBorder
        {
            get { return normalBorder; }
            set
            {
                normalBorder = value;
                Invalidate();
            }
        }

        #endregion

        #region AutoIncrement Animation

        /// <summary>
        /// Enum representing the easing animation
        /// </summary>
        public enum EasingMode
        {
            /// <summary>
            /// The bounce ease in
            /// </summary>
            BounceEaseIn,
            /// <summary>
            /// The bounce ease in out
            /// </summary>
            BounceEaseInOut,
            /// <summary>
            /// The bounce ease out
            /// </summary>
            BounceEaseOut,
            /// <summary>
            /// The bounce ease out in
            /// </summary>
            BounceEaseOutIn,
            /// <summary>
            /// The circular ease in
            /// </summary>
            CircularEaseIn,
            /// <summary>
            /// The circular ease in out
            /// </summary>
            CircularEaseInOut,
            /// <summary>
            /// The circular ease out
            /// </summary>
            CircularEaseOut,
            /// <summary>
            /// The cubic ease in
            /// </summary>
            CubicEaseIn,
            /// <summary>
            /// The cubic ease in out
            /// </summary>
            CubicEaseInOut,
            /// <summary>
            /// The cubic ease out
            /// </summary>
            CubicEaseOut,
            /// <summary>
            /// The exponential ease in
            /// </summary>
            ExponentialEaseIn,
            /// <summary>
            /// The exponential ease in out
            /// </summary>
            ExponentialEaseInOut,
            /// <summary>
            /// The exponential ease out
            /// </summary>
            ExponentialEaseOut,
            /// <summary>
            /// The liner
            /// </summary>
            Liner,
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The quadratic ease in
            /// </summary>
            QuadraticEaseIn,
            /// <summary>
            /// The quadratic ease in out
            /// </summary>
            QuadraticEaseInOut,
            /// <summary>
            /// The quadratic ease out
            /// </summary>
            QuadraticEaseOut,
            /// <summary>
            /// The quartic ease in
            /// </summary>
            QuarticEaseIn,
            /// <summary>
            /// The quartic ease in out
            /// </summary>
            QuarticEaseInOut,
            /// <summary>
            /// The quartic ease out
            /// </summary>
            QuarticEaseOut,
            /// <summary>
            /// The quintic ease in
            /// </summary>
            QuinticEaseIn,
            /// <summary>
            /// The quintic ease in out
            /// </summary>
            QuinticEaseInOut,
            /// <summary>
            /// The quintic ease out
            /// </summary>
            QuinticEaseOut,
            /// <summary>
            /// The sinusoidal ease in
            /// </summary>
            SinusoidalEaseIn,
            /// <summary>
            /// The sinusoidal ease in out
            /// </summary>
            SinusoidalEaseInOut,
            /// <summary>
            /// The sinusoidal ease out
            /// </summary>
            SinusoidalEaseOut
        }
        /// <summary>
        /// The easing type
        /// </summary>
        private EasingMode _easingType = EasingMode.BounceEaseIn;

        /// <summary>
        /// The peace animator
        /// </summary>
        PeaceAnimator peaceAnimator = new PeaceAnimator();
        /// <summary>
        /// The automatic increment
        /// </summary>
        private bool autoIncrement = false;
        /// <summary>
        /// The speed
        /// </summary>
        private int[] speed = new int[]
        {
            100,
            100,
            5000
        };

        /// <summary>
        /// Gets or sets a value indicating whether to automatically add easing animation.
        /// </summary>
        /// <value><c>true</c> if automatic increment; otherwise, <c>false</c>.</value>
        public bool AutoIncrement
        {
            get { return autoIncrement; }
            set
            {

                if (value == true)
                {

                    peaceAnimator.Start();
                }

                else
                {
                    peaceAnimator.Stop();
                }

                autoIncrement = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        public int[] AnimationSpeed
        {
            get { return speed; }
            set
            {
                for (int i = 0; i <= 1; i++)
                    if (value[0] < 1)
                    {
                        value[0] = 1;
                    }

                if (value[1] < 1)
                {
                    value[1] = 1;
                }

                speed = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type of the easing.
        /// </summary>
        /// <value>The type of the easing.</value>
        public EasingMode EasingType
        {
            get { return _easingType; }
            set
            {
                _easingType = value;
                Invalidate();
            }
        }


        #endregion

        #region Include in Private Field


        /// <summary>
        /// The automatic animate
        /// </summary>
        private bool autoAnimate = true;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        #endregion

        #region Include in Public Properties        
        /// <summary>
        /// Gets or sets a value indicating whether enable/disable animation.
        /// </summary>
        /// <value><c>true</c> if automatic animate; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get { return autoAnimate; }
            set
            {
                autoAnimate = value;

                if (value == true)
                {
                    timer.Enabled = true;
                }

                else
                {
                    timer.Enabled = false;
                }

                Invalidate();
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.rotaTrans + 1 > maximum)
            {
                this.rotaTrans = -maximum;
            }

            else
            {
                this.rotaTrans++;
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), new Point((Width/3) + (Text.Length * 2) - (int)Font.Size, Height/2));


            switch (_easingType)
            {
                case EasingMode.BounceEaseIn:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.BounceEaseIn;

                    break;
                case EasingMode.BounceEaseInOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.BounceEaseInOut;

                    break;
                case EasingMode.BounceEaseOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.BounceEaseOut;

                    break;
                case EasingMode.BounceEaseOutIn:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.BounceEaseOutIn;

                    break;
                case EasingMode.CircularEaseIn:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CircularEaseIn;

                    break;
                case EasingMode.CircularEaseInOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CircularEaseInOut;

                    break;
                case EasingMode.CircularEaseOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CircularEaseOut;

                    break;
                case EasingMode.CubicEaseIn:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CubicEaseIn;

                    break;
                case EasingMode.CubicEaseInOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CubicEaseInOut;

                    break;
                case EasingMode.CubicEaseOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.CubicEaseOut;

                    break;
                case EasingMode.ExponentialEaseIn:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.ExponentialEaseIn;

                    break;
                case EasingMode.ExponentialEaseInOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.ExponentialEaseInOut;

                    break;
                case EasingMode.ExponentialEaseOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.ExponentialEaseOut;

                    break;
                case EasingMode.Liner:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.Liner;

                    break;
                case EasingMode.None:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.None;

                    break;
                case EasingMode.QuadraticEaseIn:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuadraticEaseIn;

                    break;
                case EasingMode.QuadraticEaseInOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuadraticEaseInOut;

                    break;
                case EasingMode.QuadraticEaseOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuadraticEaseOut;

                    break;
                case EasingMode.QuarticEaseIn:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuarticEaseIn;

                    break;
                case EasingMode.QuarticEaseInOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuarticEaseInOut;

                    break;
                case EasingMode.QuarticEaseOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuarticEaseOut;

                    break;
                case EasingMode.QuinticEaseIn:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuinticEaseIn;

                    break;
                case EasingMode.QuinticEaseInOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuinticEaseInOut;

                    break;
                case EasingMode.QuinticEaseOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.QuinticEaseOut;

                    break;
                case EasingMode.SinusoidalEaseIn:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.SinusoidalEaseIn;

                    break;
                case EasingMode.SinusoidalEaseInOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.SinusoidalEaseInOut;

                    break;
                case EasingMode.SinusoidalEaseOut:
                    peaceAnimator.OneD_Path_Easing = HelperControls.AnimationHelpers.WinFormAnimation.KnownAnimationFunctions.SinusoidalEaseOut;

                    break;
                default:
                    break;
            }
            
            e.Graphics.ScaleTransform(scaleTrans[0], scaleTrans[1], MatrixOrder.Append);

            e.Graphics.TranslateTransform(this.ClientRectangle.Width / sizes, this.ClientRectangle.Height / sizes, MatrixOrder.Append);

            LinearGradientBrush linbrush =
                new LinearGradientBrush(new Rectangle(rotTrans[0], rotTrans[1], rotTrans[2], rotTrans[3]), Color.Black,
                    Color.Blue, 270f);

            for (int i = translTrans[0]; i <= translTrans[1]; i += translTrans[2])
            {
                e.Graphics.RotateTransform(rotaTrans, MatrixOrder.Prepend);

                //e.Graphics.FillRectangle(linbrush, rotTrans[0], rotTrans[1], rotTrans[2], rotTrans[3]);

                if(solidify)
                {
                    e.Graphics.FillRectangle(backFill.GetBrush(new Rectangle(rotTrans[0], rotTrans[1], rotTrans[2], rotTrans[3])), rotTrans[0], rotTrans[1], rotTrans[2], rotTrans[3]);

                }

                //e.Graphics.DrawRectangle(new Pen(Color.Black, 0), rotTrans[0], rotTrans[1], rotTrans[2], rotTrans[3]);

                switch (_borderType)
                {
                    case TypeOfBorder.Normal:
                        e.Graphics.DrawRectangle(new Pen(normalBorder, 0f), rotTrans[0], rotTrans[1], rotTrans[2], rotTrans[3]);

                        break;
                    case TypeOfBorder.Magic:
                        e.Graphics.DrawRectangle(border.GetPen(), rotTrans[0], rotTrans[1], rotTrans[2], rotTrans[3]);

                        break;
                    default:
                        break;
                }

                
            }

            
        }


    }

    

}