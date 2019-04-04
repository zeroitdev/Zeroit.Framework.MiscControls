// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Keyboard.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region ZeroitKeyBoard    
    /// <summary>
    /// A class collection for rendering a keyboard control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitKeyboard : Control
    {

        #region Private Fields
        /// <summary>
        /// The target
        /// </summary>
        private Control _Target;
        /// <summary>
        /// The shift
        /// </summary>
        private bool Shift;
        /// <summary>
        /// The pressed
        /// </summary>
        private int Pressed = -1;
        /// <summary>
        /// The buttons
        /// </summary>
        private Rectangle[] Buttons;
        /// <summary>
        /// The lower
        /// </summary>
        private char[] Lower;
        /// <summary>
        /// The upper
        /// </summary>
        private char[] Upper;
        /// <summary>
        /// The other
        /// </summary>
        private string[] Other =
        {
            "Shift",
            "Space",
            "Back"

        };
        /// <summary>
        /// The upper cache
        /// </summary>
        private PointF[] UpperCache;
        /// <summary>
        /// The lower cache
        /// </summary>
        private PointF[] LowerCache;
        /// <summary>
        /// The g p1
        /// </summary>
        private GraphicsPath GP1;
        /// <summary>
        /// The s z1
        /// </summary>
        private SizeF SZ1;
        /// <summary>
        /// The p t1
        /// </summary>
        private PointF PT1;
        /// <summary>
        /// The p1
        /// </summary>
        private Pen P1;
        /// <summary>
        /// The p2
        /// </summary>
        private Pen P2;
        /// <summary>
        /// The p3
        /// </summary>
        private Pen P3;
        /// <summary>
        /// The b1
        /// </summary>
        private SolidBrush B1;
        /// <summary>
        /// The p b1
        /// </summary>
        private PathGradientBrush PB1;
        /// <summary>
        /// The g b1
        /// </summary>
        private LinearGradientBrush GB1;
        /// <summary>
        /// The g
        /// </summary>
        Graphics G;
        /// <summary>
        /// The text bitmap
        /// </summary>
        private Bitmap TextBitmap;

        /// <summary>
        /// The text graphics
        /// </summary>
        private Graphics TextGraphics;
        /// <summary>
        /// The lower keys
        /// </summary>
        const string LowerKeys = "1234567890-=qwertyuiop[]asdfghjkl\\;'zxcvbnm,./`";

        /// <summary>
        /// The upper keys
        /// </summary>
        const string UpperKeys = "!@#$%^&*()_+QWERTYUIOP{}ASDFGHJKL|:\"ZXCVBNM<>?~";

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitKeyboard" /> class.
        /// </summary>
        public ZeroitKeyboard()
        {
            //SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

            Font = new Font("Verdana", 8.25f);

            TextBitmap = new Bitmap(1, 1);
            TextGraphics = Graphics.FromImage(TextBitmap);

            MinimumSize = new Size(386, 162);
            MaximumSize = new Size(386, 162);

            Lower = LowerKeys.ToCharArray();
            Upper = UpperKeys.ToCharArray();

            PrepareCache();

            P1 = new Pen(Color.FromArgb(45, 45, 45));
            P2 = new Pen(Color.FromArgb(65, 65, 65));
            P3 = new Pen(Color.FromArgb(35, 35, 35));

            B1 = new SolidBrush(Color.FromArgb(100, 100, 100));
        }
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the target control.
        /// </summary>
        /// <value>The target.</value>
        public Control Target
        {
            get { return _Target; }
            set { _Target = value; }
        }
        #endregion

        #region Methods and Overrides
        /// <summary>
        /// Prepares the cache.
        /// </summary>
        private void PrepareCache()
        {
            Buttons = new Rectangle[51];
            UpperCache = new PointF[Upper.Length];
            LowerCache = new PointF[Lower.Length];

            int I = 0;

            SizeF S = default(SizeF);
            Rectangle R = default(Rectangle);

            for (int Y = 0; Y <= 3; Y++)
            {
                for (int X = 0; X <= 11; X++)
                {
                    I = (Y * 12) + X;
                    R = new Rectangle(X * 32, Y * 32, 32, 32);

                    Buttons[I] = R;

                    if (!(I == 47) && !char.IsLetter(Upper[I]))
                    {
                        S = TextGraphics.MeasureString(Upper[I].ToString(), Font);
                        UpperCache[I] = new PointF(R.X + (R.Width / 2 - S.Width / 2), R.Y + R.Height - S.Height - 2);

                        S = TextGraphics.MeasureString(Lower[I].ToString(), Font);
                        LowerCache[I] = new PointF(R.X + (R.Width / 2 - S.Width / 2), R.Y + R.Height - S.Height - 2);
                    }
                }
            }

            Buttons[48] = new Rectangle(0, 4 * 32, 2 * 32, 32);
            Buttons[49] = new Rectangle(Buttons[48].Right, 4 * 32, 8 * 32, 32);
            Buttons[50] = new Rectangle(Buttons[49].Right, 4 * 32, 2 * 32, 32);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            G.Clear(BackColor);

            Rectangle R = default(Rectangle);

            int Offset = 0;
            G.DrawRectangle(P1, 0, 0, (12 * 32) + 1, (5 * 32) + 1);

            for (int I = 0; I <= Buttons.Length - 1; I++)
            {
                R = Buttons[I];

                Offset = 0;
                if (I == Pressed)
                {
                    Offset = 1;

                    GP1 = new GraphicsPath();
                    GP1.AddRectangle(R);

                    PB1 = new PathGradientBrush(GP1);
                    PB1.CenterColor = Color.FromArgb(60, 60, 60);
                    PB1.SurroundColors = new Color[] { Color.FromArgb(55, 55, 55) };
                    PB1.FocusScales = new PointF(0.8f, 0.5f);

                    G.FillPath(PB1, GP1);
                }
                else
                {
                    GB1 = new LinearGradientBrush(R, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90f);
                    G.FillRectangle(GB1, R);
                }

                switch (I)
                {
                    case 48:
                    case 49:
                    case 50:
                        SZ1 = G.MeasureString(Other[I - 48], Font);
                        G.DrawString(Other[I - 48], Font, Brushes.Black, R.X + (R.Width / 2 - SZ1.Width / 2) + Offset + 1, R.Y + (R.Height / 2 - SZ1.Height / 2) + Offset + 1);
                        G.DrawString(Other[I - 48], Font, Brushes.White, R.X + (R.Width / 2 - SZ1.Width / 2) + Offset, R.Y + (R.Height / 2 - SZ1.Height / 2) + Offset);
                        break;
                    case 47:
                        DrawArrow(Color.Black, R.X + Offset + 1, R.Y + Offset + 1);
                        DrawArrow(Color.White, R.X + Offset, R.Y + Offset);
                        break;
                    default:
                        if (Shift)
                        {
                            G.DrawString(Upper[I].ToString(), Font, Brushes.Black, R.X + 3 + Offset + 1, R.Y + 2 + Offset + 1);
                            G.DrawString(Upper[I].ToString(), Font, Brushes.White, R.X + 3 + Offset, R.Y + 2 + Offset);

                            if (!char.IsLetter(Lower[I]))
                            {
                                PT1 = LowerCache[I];
                                G.DrawString(Lower[I].ToString(), Font, B1, PT1.X + Offset, PT1.Y + Offset);
                            }
                        }
                        else
                        {
                            G.DrawString(Lower[I].ToString(), Font, Brushes.Black, R.X + 3 + Offset + 1, R.Y + 2 + Offset + 1);
                            G.DrawString(Lower[I].ToString(), Font, Brushes.White, R.X + 3 + Offset, R.Y + 2 + Offset);

                            if (!char.IsLetter(Upper[I]))
                            {
                                PT1 = UpperCache[I];
                                G.DrawString(Upper[I].ToString(), Font, B1, PT1.X + Offset, PT1.Y + Offset);
                            }
                        }
                        break;
                }

                G.DrawRectangle(P2, R.X + 1 + Offset, R.Y + 1 + Offset, R.Width - 2, R.Height - 2);
                G.DrawRectangle(P3, R.X + Offset, R.Y + Offset, R.Width, R.Height);

                if (I == Pressed)
                {
                    G.DrawLine(P1, R.X, R.Y, R.Right, R.Y);
                    G.DrawLine(P1, R.X, R.Y, R.X, R.Bottom);
                }
            }
        }

        /// <summary>
        /// Draws the arrow.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="rx">The rx.</param>
        /// <param name="ry">The ry.</param>
        private void DrawArrow(Color color, int rx, int ry)
        {
            Rectangle R = new Rectangle(rx + 8, ry + 8, 16, 16);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            Pen P = new Pen(color, 1);
            AdjustableArrowCap C = new AdjustableArrowCap(3, 2);
            P.CustomEndCap = C;

            G.DrawArc(P, R, 0f, 290f);

            P.Dispose();
            C.Dispose();
            G.SmoothingMode = SmoothingMode.None;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            int Index = ((e.Y / 32) * 12) + (e.X / 32);

            if (Index > 47)
            {
                for (int I = 48; I <= Buttons.Length - 1; I++)
                {
                    if (Buttons[I].Contains(e.X, e.Y))
                    {
                        Pressed = I;
                        break;
                    }
                }
            }
            else
            {
                Pressed = Index;
            }

            HandleKey();
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            Pressed = -1;
            Invalidate();
        }

        /// <summary>
        /// Handles the key.
        /// </summary>
        private void HandleKey()
        {
            if (_Target == null)
                return;
            if (Pressed == -1)
                return;

            switch (Pressed)
            {
                case 47:
                    _Target.Text = string.Empty;
                    break;
                case 48:
                    Shift = !Shift;
                    break;
                case 49:
                    _Target.Text += " ";
                    break;
                case 50:
                    if (!(_Target.Text.Length == 0))
                    {
                        _Target.Text = _Target.Text.Remove(_Target.Text.Length - 1);
                    }
                    break;
                default:
                    if (Shift)
                    {
                        _Target.Text += Upper[Pressed];
                    }
                    else
                    {
                        _Target.Text += Lower[Pressed];
                    }
                    break;
            }
        }

        #endregion
        
    }
    #endregion


}
