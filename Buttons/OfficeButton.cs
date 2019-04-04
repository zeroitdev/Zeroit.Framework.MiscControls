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

    #region OfficeButton    
    /// <summary>
    /// A class collection for rendering an office like button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Button" />
    public class ZeroitButtonOffice : Button
    {
        #region Enum
        /// <summary>
        /// Enum representing the button state
        /// </summary>
        public enum ZeroitButtonState
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The pressed
            /// </summary>
            Pressed,
            /// <summary>
            /// The selected
            /// </summary>
            Selected
        }
        #endregion

        #region Fields
        ZeroitButtonState _buttonState = ZeroitButtonState.None;
        ColorBlend _selectionBlend = null;
        Color[] _interpolationColors = null;
        Int32 DEF_PADDING = 10;
        #endregion

        #region Properties
        private LinearGradientMode gradientMode = LinearGradientMode.Vertical;

        /// <summary>
        /// Gets or sets the linear gradient mode.
        /// </summary>
        /// <value>The gradient mode.</value>
        public LinearGradientMode GradientMode
        {
            get
            {
                return gradientMode;
            }

            set
            {
                gradientMode = value;
                Invalidate();
            }
        }
        internal Color[] InterpolationColors
        {
            get
            {
                if (_interpolationColors == null)
                {
                    _interpolationColors = new Color[]
                    {
                        Color.FromArgb(255,226,119),
                        Color.FromArgb(255,227,124),
                        Color.FromArgb(255,229,133),
                        Color.FromArgb(255,238,164),
                        Color.FromArgb(255,244,192),
                        Color.FromArgb(255,250,214),
                        Color.FromArgb(255,252,224)
                    };
                }

                return _interpolationColors;
            }
        }

        /// <summary>
        /// Gets or sets the state of the button.
        /// </summary>
        /// <value>The state of the button.</value>
        public ZeroitButtonState ButtonState
        {
            get { return _buttonState; }
            set { _buttonState = value; }
        }

        internal ColorBlend SelectionBlend
        {
            get
            {
                if (_selectionBlend == null)
                {
                    _selectionBlend = new ColorBlend(7);
                    _selectionBlend.Positions = new float[]
                    {
                       0F,
                       0.83F,
                       0.86F,
                       0.9F,
                       0.93F,
                       0.96F,
                       1F
                    };
                }

                return _selectionBlend;
            }

        }

        #endregion

        #region Ctor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonOffice"/> class.
        /// </summary>
        public ZeroitButtonOffice()
        {

        }
        #endregion

        #region Overrides

        protected override void OnPaint(PaintEventArgs pevent)
        {
            PaintButtonBackground(pevent);

            PaintImageAndText(pevent);

            PaintButtonBorder(pevent);
        }
        
        #endregion

        #region Implementations

        private void PaintImageAndText(PaintEventArgs e)
        {
            Rectangle txtRect = GetTextRectangle(e.Graphics);
            Rectangle imgRect = Rectangle.Empty;
            Rectangle client = this.ClientRectangle;

            if (this.Image != null)
            {
                imgRect = new Rectangle(Point.Empty, this.Image.Size);

                e.Graphics.DrawImageUnscaled(this.Image, new Point((this.Width - imgRect.Width) / 2, DEF_PADDING));
            }

            e.Graphics.DrawString(this.Text, this.Font, Brushes.Black, new Point((this.Width - txtRect.Width) / 2, imgRect.Height + 2 * DEF_PADDING));
        }

        private Rectangle GetTextRectangle(Graphics graphics)
        {
            Size sz = TextRenderer.MeasureText(graphics, this.Text, this.Font, Size.Empty, TextFormatFlags.WordBreak);
            return new Rectangle(Point.Empty, sz);
        }

        private void PaintButtonBackground(PaintEventArgs e)
        {
            ZeroitButtonState state = GetButtonState();

            using (LinearGradientBrush brush = GetBackgroundGradientBrush(state))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private LinearGradientBrush GetBackgroundGradientBrush(ZeroitButtonState buttonState)
        {
            Color gradientBegin = Color.Empty;
            Color gradientEnd = Color.Empty;

            switch (buttonState)
            {
                case ZeroitButtonState.None:
                    gradientBegin = Color.FromArgb(163, 163, 163);
                    gradientEnd = Color.FromArgb(201, 201, 201);
                    break;
                case ZeroitButtonState.Pressed:
                    gradientBegin = Color.FromArgb(254, 226, 135);
                    gradientEnd = Color.FromArgb(251, 214, 120);
                    break;
                case ZeroitButtonState.Selected:
                    LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, gradientEnd, gradientBegin, gradientMode);
                    this.SelectionBlend.Colors = this.InterpolationColors;
                    brush.InterpolationColors = this.SelectionBlend;
                    return brush;
            }
            return new LinearGradientBrush(this.ClientRectangle, gradientEnd, gradientBegin, gradientMode);
        }

        private void PaintButtonBorder(PaintEventArgs e)
        {
            PaintButtonBorder(e, GetButtonState());
        }

        private void PaintButtonBorder(PaintEventArgs e, ZeroitButtonState buttonState)
        {
            Rectangle border = this.ClientRectangle;
            border.Inflate(0, 0);
            border.Size = new Size(this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);

            switch (buttonState)
            {
                case ZeroitButtonState.Pressed:
                    {
                        using (Pen borderPen = new Pen(Color.FromArgb(194, 118, 43)))
                        {
                            e.Graphics.DrawRectangle(borderPen, border);
                        }
                    }
                    break;
                case ZeroitButtonState.Selected:
                    {
                        Rectangle innerLine = border;
                        innerLine.Inflate(-1, -1);
                        innerLine.Size = new Size(border.Width - 2, border.Height - 2);

                        using (Pen borderPen = new Pen(Color.FromArgb(248, 212, 39)))
                        {
                            e.Graphics.DrawRectangle(borderPen, border);
                        }

                        using (Pen borderPen = new Pen(Color.WhiteSmoke))
                        {
                            e.Graphics.DrawRectangle(borderPen, innerLine);
                        }
                    }
                    break;
            }
        }

        protected ZeroitButtonState GetButtonState()
        {
            Point mousePosition = this.PointToClient(Control.MousePosition);

            if (this.ClientRectangle.Contains(mousePosition))
            {
                if (Control.MouseButtons == MouseButtons.None)
                    return ZeroitButtonState.Selected;
                else
                    return ZeroitButtonState.Pressed;
            }

            return ZeroitButtonState.None;
        }

        #endregion

    }

    #endregion


}
