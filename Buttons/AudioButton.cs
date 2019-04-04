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

    #region Audio Button

    #region DrawState
    /// <summary>
    /// Enum representing the rendering state
    /// </summary>
    public enum AudioButtonDrawState
    {
        /// <summary>
        /// The normal
        /// </summary>
        Normal,
        /// <summary>
        /// The hot
        /// </summary>
        Hot,
        /// <summary>
        /// The pressed
        /// </summary>
        Pressed,
        /// <summary>
        /// The disable
        /// </summary>
        Disable
    }
    #endregion
    #region AudioButtonType
    /// <summary>
    /// Enum representing the audio button type
    /// </summary>
    public enum AudioButtonType
    {
        /// <summary>
        /// To start
        /// </summary>
        ToStart,
        /// <summary>
        /// The rewind
        /// </summary>
        Rewind,
        /// <summary>
        /// The play
        /// </summary>
        Play,
        /// <summary>
        /// The pause
        /// </summary>
        Pause,
        /// <summary>
        /// The stop
        /// </summary>
        Stop,
        /// <summary>
        /// The forward
        /// </summary>
        Forward,
        /// <summary>
        /// To end
        /// </summary>
        ToEnd
    }
    #endregion

    #region Control

    /// <summary>
    /// AudioButton - Buttons used at the bottom of the window
    /// Handling the audio.
    /// </summary>
    public class ZeroitAudioButton : System.Windows.Forms.Button
    {
        #region internal variables
        //private bool blnGotFocus=false;
        private bool blnMouseEnter = false;
        private bool blnMouseDown = false;
        private bool blnGotFocus = false;
        private AudioButtonType audiobuttontype = AudioButtonType.Play;//Is it play,pause, stop...?
        Color gradientColor1 = Color.White;
        Color gradientColor2 = Color.FromArgb(83, 139, 230);
        Color lightblue = Color.FromArgb(43, 109, 219);
        Color darkblue = Color.FromArgb(51, 0, 153);
        private Size sIconsize;
        private Point pIconlocation;

        private Color[] normalColor = new Color[]
        {
            Color.White,
            Color.Gray,
            Color.DarkGray,
            Color.Black
        };

        private Color[] disabledColor = new Color[]
        {
            Color.FromArgb(240, 236, 237),
            Color.FromArgb(179, 179, 179),
            Color.FromArgb(189, 188, 186),
            Color.FromArgb(136, 132, 133)
        };

        private Color[] hotColor = new Color[]
        {
            Color.FromArgb(240, 236, 237),
            Color.FromArgb(179, 179, 179),
            Color.FromArgb(189, 188, 186),
            Color.FromArgb(136, 132, 133)
        };

        private Color[] pressedColor = new Color[]
        {
            Color.FromArgb(240, 236, 237),
            Color.FromArgb(179, 179, 179),
            Color.FromArgb(189, 188, 186),
            Color.FromArgb(136, 132, 133)
        };

        #endregion

        #region constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAudioButton"/> class.
        /// </summary>
        public ZeroitAudioButton()
        {
            // This call is required by the Windows.Forms Form Designer.

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.Size = new Size(32, 32);

            switch (this.audiobuttontype)
            {
                case AudioButtonType.ToStart:
                    //this.DrawAudioToStart(g,8,7,12,16,DrawState.Pressed);
                    this.sIconsize = new Size(12, 16);
                    this.pIconlocation = new Point(8, 7);
                    break;
                case AudioButtonType.Forward:
                    this.sIconsize = new Size(16, 16);
                    this.pIconlocation = new Point(7, 7);
                    //this.DrawAudioForward(g,7,7,16,16,DrawState.Pressed);
                    break;
                case AudioButtonType.Pause:
                    //this.DrawAudioPause(g,8,8,14,14,DrawState.Pressed);
                    this.sIconsize = new Size(14, 14);
                    this.pIconlocation = new Point(8, 8);
                    break;
                case AudioButtonType.Play:
                    //this.DrawAudioPlay(g,8,8,14,14,DrawState.Pressed);
                    this.sIconsize = new Size(14, 14);
                    this.pIconlocation = new Point(8, 8);
                    break;
                case AudioButtonType.Rewind:
                    //this.DrawAudioRewind(g,6,7,16,16,DrawState.Pressed);
                    this.sIconsize = new Size(16, 16);
                    this.pIconlocation = new Point(6, 7);
                    break;
                case AudioButtonType.Stop:
                    //this.DrawAudioStop(g,8,8,14,14,DrawState.Pressed);
                    this.sIconsize = new Size(14, 14);
                    this.pIconlocation = new Point(8, 8);
                    break;
                case AudioButtonType.ToEnd:
                    //this.DrawAudioToEnd(g,8,7,12,16,DrawState.Pressed);
                    this.sIconsize = new Size(12, 16);
                    this.pIconlocation = new Point(8, 7);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Overriders

        protected override void OnMouseEnter(EventArgs e)
        {
            blnMouseEnter = true;
            this.blnGotFocus = true;
            base.OnMouseEnter(e);
            Invalidate(ClientRectangle);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            blnMouseEnter = false;
            this.blnGotFocus = false;
            base.OnMouseLeave(e);
            Invalidate(ClientRectangle);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            blnMouseDown = true;
            base.OnMouseDown(e);
            Invalidate(ClientRectangle);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            blnMouseDown = false;
            base.OnMouseUp(e);
            Invalidate(ClientRectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(BackColor);
            Rectangle rc = ClientRectangle;

            if (this.Enabled)
            {
                if (blnMouseDown)//Mouse Down
                {
                    switch (this.audiobuttontype)
                    {
                        //this.sIconsize = new Size(14,14);
                        //	this.pIconlocation = new Point(8,8);
                        case AudioButtonType.ToStart:
                            this.DrawAudioToStart(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Pressed);
                            break;
                        case AudioButtonType.Forward:
                            this.DrawAudioForward(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Pressed);
                            break;
                        case AudioButtonType.Pause:
                            this.DrawAudioPause(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Pressed);
                            break;
                        case AudioButtonType.Play:
                            this.DrawAudioPlay(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Pressed);
                            break;
                        case AudioButtonType.Rewind:
                            this.DrawAudioRewind(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Pressed);
                            break;
                        case AudioButtonType.Stop:
                            this.DrawAudioStop(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Pressed);
                            break;
                        case AudioButtonType.ToEnd:
                            this.DrawAudioToEnd(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Pressed);
                            break;
                        default:
                            break;
                    }
                }
                else if (blnMouseEnter || blnGotFocus)//Mouse Enter
                {
                    switch (this.audiobuttontype)
                    {
                        case AudioButtonType.ToStart:
                            this.DrawAudioToStart(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Hot);
                            break;
                        case AudioButtonType.Forward:
                            this.DrawAudioForward(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Hot);
                            break;
                        case AudioButtonType.Pause:
                            this.DrawAudioPause(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Hot);
                            break;
                        case AudioButtonType.Play:
                            this.DrawAudioPlay(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Hot);
                            break;
                        case AudioButtonType.Rewind:
                            this.DrawAudioRewind(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Hot);
                            break;
                        case AudioButtonType.Stop:
                            this.DrawAudioStop(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Hot);
                            break;
                        case AudioButtonType.ToEnd:
                            this.DrawAudioToEnd(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Hot);
                            break;
                        default:
                            break;
                    }
                }
                else//normal
                {
                    switch (this.audiobuttontype)
                    {
                        case AudioButtonType.ToStart:
                            this.DrawAudioToStart(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Normal);
                            break;
                        case AudioButtonType.Forward:
                            this.DrawAudioForward(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Normal);
                            break;
                        case AudioButtonType.Pause:
                            this.DrawAudioPause(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Normal);
                            break;
                        case AudioButtonType.Play:
                            this.DrawAudioPlay(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Normal);
                            break;
                        case AudioButtonType.Rewind:
                            this.DrawAudioRewind(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Normal);
                            break;
                        case AudioButtonType.Stop:
                            this.DrawAudioStop(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Normal);
                            break;
                        case AudioButtonType.ToEnd:
                            this.DrawAudioToEnd(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Normal);
                            break;
                        default:
                            break;
                    }
                }
            }
            else//Disabled
            {
                switch (this.audiobuttontype)
                {
                    case AudioButtonType.ToStart:
                        this.DrawAudioToStart(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Disable);
                        break;
                    case AudioButtonType.Forward:
                        this.DrawAudioForward(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Disable);
                        break;
                    case AudioButtonType.Pause:
                        this.DrawAudioPause(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Disable);
                        break;
                    case AudioButtonType.Play:
                        this.DrawAudioPlay(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Disable);
                        break;
                    case AudioButtonType.Rewind:
                        this.DrawAudioRewind(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Disable);
                        break;
                    case AudioButtonType.Stop:
                        this.DrawAudioStop(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Disable);
                        break;
                    case AudioButtonType.ToEnd:
                        this.DrawAudioToEnd(g, pIconlocation.X, pIconlocation.Y, sIconsize.Width, sIconsize.Height, AudioButtonDrawState.Disable);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the type of the button.
        /// <list type="bullet">
        /// <item>ToEnd: To the end of the audio file</item>
        /// <item>ToStart: To the Start of the audio file</item>
        /// <item>Play: Play the audio file</item>
        /// <item>Pause:Pause the play</item>
        /// <item>Stop: Stop the play</item>
        /// <item>Rewind: Fast Rewind the audio</item>
        /// <item>Forward: Fast Forward the audio</item>
        /// <item>ShiftLeft: Left Shift the selection</item>
        /// <item>LoopSelection: Loop playing the selection</item>
        /// </list>
        /// </summary>
        /// <value>The type of the button.</value>
        [Description("The type of Audio buttons:    " +
        "ToEnd: To the end of the audio file;    " +
        "ToStart: To the Start of the audio file;    " +
        "Play: Play the audio file;    " +
             "Pause:Pause the play;    " +
             "Stop: Stop the play;    " +
             "Rewind: Fast Rewind the audio;    " +
             "Forward: Fast Forward the audio;    " +
             "ShiftLeft: Left Shift the selection;    " +
             "ShiftRight: Right Shift the selection;    " +
             "LoopSelection: Loop playing the selection    ")]
        [Category("Audio Button")]

        public AudioButtonType ButtonType
        {
            get
            {
                return audiobuttontype;
            }
            set
            {
                audiobuttontype = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the icon.
        /// </summary>
        /// <value>The size of the icon.</value>
        [Description("The Size of the Icons on the Audio button")]
        [Category("Audio Button")]
        public Size IconSize
        {
            get
            {
                return this.sIconsize;
            }
            set
            {
                if (value.Width > this.Size.Width || value.Height > this.Size.Height)
                {
                    MessageBox.Show("The Icon Size is bigger than the base size!", "Note!", MessageBoxButtons.OK);
                }
                else
                    this.sIconsize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the location of the icon.
        /// </summary>
        /// <value>The icon location.</value>
        [Description("The Location of the Icon on the button")]
        [Category("Audio Button")]
        public Point IconLocation
        {
            get
            {
                return pIconlocation;
            }
            set
            {
                if (value.X > this.Size.Width || value.Y > this.Size.Height)
                {
                    MessageBox.Show("The Icon location is out of the base control!", "Hello! You Stupid!", MessageBoxButtons.OK);
                }
                else
                    pIconlocation = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the normal state.
        /// </summary>
        /// <value>The color of the normal state.</value>
        public Color[] NormalColor
        {
            get { return normalColor; }
            set { normalColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the disabled state.
        /// </summary>
        /// <value>The color of the disabled state.</value>
        public Color[] DisabledColor
        {
            get { return disabledColor; }
            set { disabledColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the hot state.
        /// </summary>
        /// <value>The color of the hot state.</value>
        public Color[] HotColor
        {
            get { return hotColor; }
            set { hotColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the pressed state.
        /// </summary>
        /// <value>The color of the pressed state.</value>
        public Color[] PressedColor
        {
            get { return pressedColor; }
            set { pressedColor = value; Invalidate(); }
        }

        #endregion

        #region implementation

        private void DrawBackground(Graphics g, AudioButtonDrawState state)
        {
            Rectangle rc = this.ClientRectangle;

            if (state == AudioButtonDrawState.Disable || state == AudioButtonDrawState.Normal)
            {
                g.FillRectangle(new SolidBrush(BackColor), rc);
            }

            if (state == AudioButtonDrawState.Hot)
            {
                g.FillRectangle(new SolidBrush(BackColor), rc);
                ControlPaint.DrawBorder3D(g, rc.Left, rc.Top, rc.Width - 1, rc.Height - 1, Border3DStyle.Raised);

            }
            if (state == AudioButtonDrawState.Pressed)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(40, BackColor)), rc);
                ControlPaint.DrawBorder3D(g, rc.Left, rc.Top, rc.Width - 1, rc.Height - 1, Border3DStyle.Sunken);
            }
        }

        /// <summary>
        /// Draw Audio Button "Stop"
        /// </summary>
        /// <param name="g">The Graphics Handle</param>
        /// <param name="x">The x-coordinate of the Actual Image origin (TopLeft corner)</param>
        /// <param name="y">The y-coordinate of the Actual Image origin (TopLeft corner)</param>
        /// <param name="intWidth">The Actual Image Width</param>
        /// <param name="intHeight">The Actual Image Height</param>
        /// <param name="state">one of DrawState Enumeration</param>
        private void DrawAudioStop(Graphics g, int x, int y, int intWidth, int intHeight, AudioButtonDrawState state)
        {

            Rectangle rect = new Rectangle(x, y, intWidth, intHeight);
            //Rectangle rc = this.ClientRectangle;

            DrawBackground(g, state);

            if (state == AudioButtonDrawState.Disable)
            {
                LinearGradientBrush lb = new LinearGradientBrush(rect, disabledColor[0], disabledColor[1], LinearGradientMode.ForwardDiagonal);
                Pen penRect = new Pen(new SolidBrush(disabledColor[2]), 1);
                Pen pen3DLine = new Pen(new SolidBrush(disabledColor[3]), 1);
                g.FillRectangle(lb, rect);
                g.DrawRectangle(penRect, x, y, intWidth - 1, intHeight - 1);
                g.DrawLine(pen3DLine, x, y + intHeight, x + intWidth, y + intHeight);//Horizontal Bottom line
                g.DrawLine(pen3DLine, x + intWidth, y + intHeight, x + intWidth, y);//Vertical Right line
            }
            else if (state == AudioButtonDrawState.Hot || state == AudioButtonDrawState.Pressed)
            {
                LinearGradientBrush lb = new LinearGradientBrush(rect, hotColor[0], hotColor[1], LinearGradientMode.ForwardDiagonal);
                Pen penRect = new Pen(new SolidBrush(hotColor[2]), 1);
                Pen pen3DLine = new Pen(new SolidBrush(hotColor[3]), 1);
                g.FillRectangle(lb, rect);
                g.DrawRectangle(penRect, x, y, intWidth - 1, intHeight - 1);
                g.DrawLine(pen3DLine, x, y + intHeight, x + intWidth, y + intHeight);//Horizontal Bottom line
                g.DrawLine(pen3DLine, x + intWidth, y + intHeight, x + intWidth, y);//Vertical Right line
            }
            else //Normal state
            {
                LinearGradientBrush lb = new LinearGradientBrush(rect, normalColor[0], normalColor[1], LinearGradientMode.ForwardDiagonal);
                Pen penRect = new Pen(new SolidBrush(normalColor[2]), 1);
                Pen pen3DLine = new Pen(new SolidBrush(normalColor[3]), 1);
                g.FillRectangle(lb, rect);
                g.DrawRectangle(penRect, x, y, intWidth - 1, intHeight - 1);
                g.DrawLine(pen3DLine, x, y + intHeight, x + intWidth, y + intHeight);//Horizontal Bottom line
                g.DrawLine(pen3DLine, x + intWidth, y + intHeight, x + intWidth, y);//Vertical Right line
            }
        }

        private void DrawAudioPlay(Graphics g, int x, int y, int intWidth, int intHeight, AudioButtonDrawState state)
        {

            Point pTop = new Point(x, y);
            Point pBottom = new Point(x, y + intHeight);
            Point pRight = new Point(x + intWidth, y + (int)(intHeight / 2));
            Point[] points = { pBottom, pRight, pTop };

            Point pInnerTop = new Point(x + 1, y + 1);
            Point pInnerBottom = new Point(x + 1, y + intHeight - 1);
            Point pInnerRight = new Point(x + intWidth - 1, y + (int)(intHeight / 2));
            Point[] innerPoints = { pInnerBottom, pInnerRight, pInnerTop };

            Rectangle rect = new Rectangle(x, y, intWidth, intHeight);
            //Rectangle rc = this.ClientRectangle;

            DrawBackground(g, state);

            if (state == AudioButtonDrawState.Disable)
            {
                LinearGradientBrush lb = new LinearGradientBrush(rect, disabledColor[0], disabledColor[1], LinearGradientMode.ForwardDiagonal);
                Pen penRect = new Pen(new SolidBrush(disabledColor[2]), 1);
                Pen pen3DLine = new Pen(new SolidBrush(disabledColor[3]), 1);

                g.FillPolygon(lb, points);
                g.DrawLines(penRect, innerPoints);//Vertical Left line
                g.DrawLine(penRect, pTop, pBottom);
                g.DrawLines(pen3DLine, points);//Dark lines
            }
            else if (state == AudioButtonDrawState.Hot || state == AudioButtonDrawState.Pressed)
            {
                LinearGradientBrush lb = new LinearGradientBrush(rect, this.gradientColor1, this.gradientColor2, LinearGradientMode.ForwardDiagonal);
                Pen penRect = new Pen(new SolidBrush(this.lightblue), 1);
                Pen pen3DLine = new Pen(new SolidBrush(this.darkblue), 1);
                g.FillPolygon(lb, points);
                g.DrawLines(penRect, innerPoints);//Vertical Left line
                g.DrawLine(penRect, pTop, pBottom);
                g.DrawLines(pen3DLine, points);//Dark lines
            }
            else //Normal state
            {

                LinearGradientBrush lb = new LinearGradientBrush(rect, Color.White, Color.Gray, LinearGradientMode.ForwardDiagonal);
                Pen penRect = new Pen(new SolidBrush(Color.DarkGray), 1);
                Pen pen3DLine = new Pen(new SolidBrush(Color.Black), 1);
                g.FillPolygon(lb, points);
                g.DrawLines(penRect, innerPoints);//Vertical Left line
                g.DrawLine(penRect, pTop, pBottom);
                g.DrawLines(pen3DLine, points);//Dark lines
            }
        }

        private void DrawAudioPause(Graphics g, int x, int y, int intWidth, int intHeight, AudioButtonDrawState state)
        {

            int width = (int)((intWidth - 2) / 2);
            Rectangle rectLeft = new Rectangle(x, y, width, intHeight);
            Rectangle rectRight = new Rectangle(x + (int)((intWidth + 2) / 2), y, width, intHeight);
            //Rectangle rc = this.ClientRectangle;

            DrawBackground(g, state);

            if (state == AudioButtonDrawState.Disable)
            {
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, Color.FromArgb(240, 236, 237), Color.FromArgb(179, 179, 179), LinearGradientMode.ForwardDiagonal);
                Pen penRect = new Pen(new SolidBrush(Color.FromArgb(189, 188, 186)), 1);
                Pen pen3DLine = new Pen(new SolidBrush(Color.FromArgb(136, 132, 133)), 1);

                //Left half of Pause
                g.FillRectangle(lbLeft, rectLeft);
                g.DrawRectangle(penRect, x, y, width - 1, intHeight - 1);
                g.DrawLine(pen3DLine, x, y + intHeight, x + width, y + intHeight);//Horizontal Bottom line
                g.DrawLine(pen3DLine, x + width, y + intHeight, x + width, y);//Vertical Right line
                                                                              //Right half of Pause
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, Color.FromArgb(240, 236, 237), Color.FromArgb(179, 179, 179), LinearGradientMode.ForwardDiagonal);
                g.FillRectangle(lbRight, rectRight);
                g.DrawRectangle(penRect, x + (int)((intWidth + 2) / 2), y, width - 1, intHeight - 1);
                g.DrawLine(pen3DLine, x + (int)((intWidth + 2) / 2), y + intHeight, x + (int)((intWidth + 2) / 2) + width, y + intHeight);//Horizontal Bottom line
                g.DrawLine(pen3DLine, x + (int)((intWidth + 2) / 2) + width, y + intHeight, x + (int)((intWidth + 2) / 2) + width, y);//Vertical Right line

            }
            else if (state == AudioButtonDrawState.Hot || state == AudioButtonDrawState.Pressed)
            {
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, this.gradientColor1, this.gradientColor2, LinearGradientMode.ForwardDiagonal);
                Pen penRect = new Pen(new SolidBrush(this.lightblue), 1);
                Pen pen3DLine = new Pen(new SolidBrush(this.darkblue), 1);

                //Left half of Pause
                g.FillRectangle(lbLeft, rectLeft);
                g.DrawRectangle(penRect, x, y, width - 1, intHeight - 1);
                g.DrawLine(pen3DLine, x, y + intHeight, x + width, y + intHeight);//Horizontal Bottom line
                g.DrawLine(pen3DLine, x + width, y + intHeight, x + width, y);//Vertical Right line
                                                                              //Right half of Pause
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, this.gradientColor1, this.gradientColor2, LinearGradientMode.ForwardDiagonal);
                g.FillRectangle(lbRight, rectRight);
                g.DrawRectangle(penRect, x + (int)((intWidth + 2) / 2), y, width - 1, intHeight - 1);
                g.DrawLine(pen3DLine, x + (int)((intWidth + 2) / 2), y + intHeight, x + (int)((intWidth + 2) / 2) + width, y + intHeight);//Horizontal Bottom line
                g.DrawLine(pen3DLine, x + (int)((intWidth + 2) / 2) + width, y + intHeight, x + (int)((intWidth + 2) / 2) + width, y);//Vertical Right line


            }
            else //Normal state
            {
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, Color.White, Color.Gray, LinearGradientMode.ForwardDiagonal);
                Pen penRect = new Pen(new SolidBrush(Color.DarkGray), 1);
                Pen pen3DLine = new Pen(new SolidBrush(Color.Black), 1);

                //Left half of Pause
                g.FillRectangle(lbLeft, rectLeft);
                g.DrawRectangle(penRect, x, y, width - 1, intHeight - 1);
                g.DrawLine(pen3DLine, x, y + intHeight, x + width, y + intHeight);//Horizontal Bottom line
                g.DrawLine(pen3DLine, x + width, y + intHeight, x + width, y);//Vertical Right line
                                                                              //Right half of Pause
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, Color.White, Color.Gray, LinearGradientMode.ForwardDiagonal);
                g.FillRectangle(lbRight, rectRight);
                g.DrawRectangle(penRect, x + (int)((intWidth + 2) / 2), y, width - 1, intHeight - 1);
                g.DrawLine(pen3DLine, x + (int)((intWidth + 2) / 2), y + intHeight, x + (int)((intWidth + 2) / 2) + width, y + intHeight);//Horizontal Bottom line
                g.DrawLine(pen3DLine, x + (int)((intWidth + 2) / 2) + width, y + intHeight, x + (int)((intWidth + 2) / 2) + width, y);//Vertical Right line

            }
        }

        private void DrawAudioForward(Graphics g, int x, int y, int intWidth, int intHeight, AudioButtonDrawState state)
        {
            int width = (int)(intWidth / 2);
            int height = (int)(intHeight / 2);
            //Left Points
            Point pLeftTop = new Point(x, y);
            Point pLeftBottom = new Point(x, y + intHeight);
            Point pLeftRight = new Point(x + width, y + height);
            Point[] pointsLeft = { pLeftBottom, pLeftRight, pLeftTop };
            //Left Inner Points
            Point pLeftInnerTop = new Point(x + 1, y + 1);
            Point pLeftInnerBottom = new Point(x + 1, y + intHeight - 1);
            Point pLeftInnerRight = new Point(x + width - 1, y + height);
            Point[] pointsLeftInner = { pLeftInnerBottom, pLeftInnerRight, pLeftInnerTop };
            //Right Points
            Point pRightTop = new Point(x + width + 1, y);
            Point pRightBottom = new Point(x + width + 1, y + intHeight);
            Point pRightRight = new Point(x + intWidth + 1, y + height);
            Point[] pointsRight = { pRightBottom, pRightRight, pRightTop };
            //Right Inner Points
            Point pRightInnerTop = new Point(x + width + 2, y + 1);
            Point pRightInnerBottom = new Point(x + width + 2, y + intHeight - 1);
            Point pRightInnerRight = new Point(x + intWidth, y + height);
            Point[] pointsRightInner = { pRightInnerBottom, pRightInnerRight, pRightInnerTop };

            Rectangle rectLeft = new Rectangle(x, y, width, intHeight);
            Rectangle rectRight = new Rectangle(x + width + 1, y, width, intHeight);


            DrawBackground(g, state);

            if (state == AudioButtonDrawState.Disable)
            {
                Pen penRect = new Pen(new SolidBrush(Color.FromArgb(189, 188, 186)), 1);
                Pen pen3DLine = new Pen(new SolidBrush(Color.FromArgb(136, 132, 133)), 1);
                //Left half
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, Color.FromArgb(240, 236, 237), Color.FromArgb(179, 179, 179), LinearGradientMode.ForwardDiagonal);
                g.FillPolygon(lbLeft, pointsLeft);
                g.DrawLines(penRect, pointsLeftInner);//Vertical Left line
                g.DrawLine(penRect, pLeftTop, pLeftBottom);
                g.DrawLines(pen3DLine, pointsLeft);//Dark lines
                                                   //Right Half
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, Color.FromArgb(240, 236, 237), Color.FromArgb(179, 179, 179), LinearGradientMode.ForwardDiagonal);
                g.FillRectangle(lbRight, rectRight);
                g.DrawRectangle(penRect, x + (int)((intWidth + 2) / 2), y, width - 1, intHeight - 1);
                g.DrawLine(pen3DLine, x + (int)((intWidth + 2) / 2), y + intHeight, x + (int)((intWidth + 2) / 2) + width, y + intHeight);//Horizontal Bottom line
                g.DrawLine(pen3DLine, x + (int)((intWidth + 2) / 2) + width, y + intHeight, x + (int)((intWidth + 2) / 2) + width, y);//Vertical Right line
            }
            else if (state == AudioButtonDrawState.Hot || state == AudioButtonDrawState.Pressed)
            {
                Pen penRect = new Pen(new SolidBrush(this.lightblue), 1);
                Pen pen3DLine = new Pen(new SolidBrush(this.darkblue), 1);

                //Left half
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, this.gradientColor1, this.gradientColor2, LinearGradientMode.ForwardDiagonal);
                g.FillPolygon(lbLeft, pointsLeft);
                g.DrawLines(penRect, pointsLeftInner);//Vertical Left line
                g.DrawLine(penRect, pLeftTop, pLeftBottom);
                g.DrawLines(pen3DLine, pointsLeft);//Dark lines
                                                   //Right Half
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, this.gradientColor1, this.gradientColor2, LinearGradientMode.ForwardDiagonal);
                g.FillPolygon(lbRight, pointsRight);
                g.DrawLines(penRect, pointsRightInner);//Vertical Left line
                g.DrawLine(penRect, pRightTop, pRightBottom);
                g.DrawLines(pen3DLine, pointsRight);//Dark lines
            }
            else //Normal state
            {
                Pen penRect = new Pen(new SolidBrush(Color.DarkGray), 1);
                Pen pen3DLine = new Pen(new SolidBrush(Color.Black), 1);

                //Left half
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, Color.White, Color.Gray, LinearGradientMode.ForwardDiagonal);
                g.FillPolygon(lbLeft, pointsLeft);
                g.DrawLines(penRect, pointsLeftInner);//Vertical Left line
                g.DrawLine(penRect, pLeftTop, pLeftBottom);
                g.DrawLines(pen3DLine, pointsLeft);//Dark lines
                                                   //Right Half
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, Color.White, Color.Gray, LinearGradientMode.ForwardDiagonal);
                g.FillPolygon(lbRight, pointsRight);
                g.DrawLines(penRect, pointsRightInner);//Vertical Left line
                g.DrawLine(penRect, pRightTop, pRightBottom);
                g.DrawLines(pen3DLine, pointsRight);//Dark lines
            }
        }
        private void DrawAudioRewind(Graphics g, int x, int y, int intWidth, int intHeight, AudioButtonDrawState state)
        {
            int width = (int)(intWidth / 2);
            int height = (int)(intHeight / 2);
            //Left Points
            Point pLeftTop = new Point(x + width, y);
            Point pLeftBottom = new Point(x + width, y + intHeight);
            Point pLeftLeft = new Point(x, y + height);
            Point[] pointsLeft = { pLeftTop, pLeftLeft, pLeftBottom };
            //Left Inner Points
            Point pLeftInnerTop = new Point(x + width - 1, y + 1);
            Point pLeftInnerBottom = new Point(x + width - 1, y + intHeight - 1);
            Point pLeftInnerLeft = new Point(x + 1, y + height);
            Point[] pointsLeftInner = { pLeftInnerTop, pLeftInnerLeft, pLeftInnerBottom };
            //Right Points
            Point pRightTop = new Point(x + intWidth + 1, y);
            Point pRightBottom = new Point(x + intWidth + 1, y + intHeight);
            Point pRightLeft = new Point(x + width + 1, y + height);
            Point[] pointsRight = { pRightTop, pRightLeft, pRightBottom };
            //Right Inner Points
            Point pRightInnerTop = new Point(x + intWidth, y + 1);
            Point pRightInnerBottom = new Point(x + intWidth, y + intHeight - 1);
            Point pRightInnerLeft = new Point(x + width + 2, y + height);
            Point[] pointsRightInner = { pRightInnerTop, pRightInnerLeft, pRightInnerBottom };

            Rectangle rectLeft = new Rectangle(x, y, width, intHeight);
            Rectangle rectRight = new Rectangle(x + width + 1, y, width, intHeight);

            DrawBackground(g, state);

            if (state == AudioButtonDrawState.Disable)
            {
                Pen penRect = new Pen(new SolidBrush(Color.FromArgb(189, 188, 186)), 1);
                Pen pen3DLine = new Pen(new SolidBrush(Color.FromArgb(136, 132, 133)), 1);
                //Left half
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, Color.FromArgb(240, 236, 237), Color.FromArgb(179, 179, 179), LinearGradientMode.BackwardDiagonal);
                g.FillPolygon(lbLeft, pointsLeft);
                g.DrawLines(penRect, pointsLeftInner);//Vertical Left line
                g.DrawLine(penRect, pLeftBottom, pLeftTop);
                g.DrawLines(pen3DLine, pointsLeft);//Dark lines
                                                   //Right Half
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, Color.FromArgb(240, 236, 237), Color.FromArgb(179, 179, 179), LinearGradientMode.BackwardDiagonal);
                g.FillPolygon(lbRight, pointsRight);
                g.DrawLines(penRect, pointsRightInner);//Vertical Left line
                g.DrawLine(penRect, pRightBottom, pRightTop);
                g.DrawLines(pen3DLine, pointsRight);//Dark lines
            }
            else if (state == AudioButtonDrawState.Hot || state == AudioButtonDrawState.Pressed)
            {
                Pen penRect = new Pen(new SolidBrush(this.lightblue), 1);
                Pen pen3DLine = new Pen(new SolidBrush(this.darkblue), 1);

                //Left half
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, this.gradientColor1, this.gradientColor2, LinearGradientMode.BackwardDiagonal);
                g.FillPolygon(lbLeft, pointsLeft);
                g.DrawLines(penRect, pointsLeftInner);//Vertical Left line
                g.DrawLine(penRect, pLeftBottom, pLeftTop);
                g.DrawLines(pen3DLine, pointsLeft);//Dark lines
                                                   //Right Half
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, this.gradientColor1, this.gradientColor2, LinearGradientMode.BackwardDiagonal);
                g.FillPolygon(lbRight, pointsRight);
                g.DrawLines(penRect, pointsRightInner);//Vertical Left line
                g.DrawLine(penRect, pRightBottom, pRightTop);
                g.DrawLines(pen3DLine, pointsRight);//Dark lines
            }
            else //Normal state
            {
                Pen penRect = new Pen(new SolidBrush(Color.DarkGray), 1);
                Pen pen3DLine = new Pen(new SolidBrush(Color.Black), 1);

                //Left half
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, Color.White, Color.Gray, LinearGradientMode.BackwardDiagonal);
                g.FillPolygon(lbLeft, pointsLeft);
                g.DrawLines(penRect, pointsLeftInner);//Vertical Left line
                g.DrawLine(penRect, pLeftBottom, pLeftTop);
                g.DrawLines(pen3DLine, pointsLeft);//Dark lines
                                                   //Right Half
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, Color.White, Color.Gray, LinearGradientMode.BackwardDiagonal);
                g.FillPolygon(lbRight, pointsRight);
                g.DrawLine(penRect, pRightBottom, pRightTop);
                g.DrawLines(pen3DLine, pointsRight);//Dark lines
            }
        }

        private void DrawAudioToStart(Graphics g, int x, int y, int intWidth, int intHeight, AudioButtonDrawState state)
        {

            int width = 4;
            int height = (int)(intHeight / 2);

            Rectangle rectLeft = new Rectangle(x, y, width, intHeight);

            //Right Points
            Point pRightTop = new Point(x + intWidth + 1, y);
            Point pRightBottom = new Point(x + intWidth + 1, y + intHeight);
            Point pRightLeft = new Point(x + width + 1, y + height);
            Point[] pointsRight = { pRightTop, pRightLeft, pRightBottom };
            //Right Inner Points
            Point pRightInnerTop = new Point(x + intWidth, y + 1);
            Point pRightInnerBottom = new Point(x + intWidth, y + intHeight - 1);
            Point pRightInnerLeft = new Point(x + width + 2, y + height);
            Point[] pointsRightInner = { pRightInnerTop, pRightInnerLeft, pRightInnerBottom };


            Rectangle rectRight = new Rectangle(x + width + 1, y, intWidth - width + 1, intHeight);

            DrawBackground(g, state);

            if (state == AudioButtonDrawState.Disable)
            {
                Pen penRect = new Pen(new SolidBrush(Color.FromArgb(189, 188, 186)), 1);
                Pen pen3DLine = new Pen(new SolidBrush(Color.FromArgb(136, 132, 133)), 1);

                //Left half
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, Color.FromArgb(240, 236, 237), Color.FromArgb(179, 179, 179), LinearGradientMode.ForwardDiagonal);
                g.FillRectangle(lbLeft, rectLeft);
                g.DrawRectangle(penRect, rectLeft.Left, rectLeft.Top, width - 1, intHeight - 1);
                g.DrawLine(pen3DLine, rectLeft.Left, rectLeft.Bottom, rectLeft.Right, rectLeft.Bottom);//Horizontal Bottom line
                g.DrawLine(pen3DLine, rectLeft.Right, rectLeft.Bottom, rectLeft.Right, rectLeft.Top);//Vertical Right line
                                                                                                     //Right Half
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, Color.FromArgb(240, 236, 237), Color.FromArgb(179, 179, 179), LinearGradientMode.BackwardDiagonal);
                g.FillPolygon(lbRight, pointsRight);
                g.DrawLines(penRect, pointsRightInner);//Vertical Left line
                g.DrawLine(penRect, pRightBottom, pRightTop);
                g.DrawLines(pen3DLine, pointsRight);//Dark lines
            }
            else if (state == AudioButtonDrawState.Hot || state == AudioButtonDrawState.Pressed)
            {
                Pen penRect = new Pen(new SolidBrush(this.lightblue), 1);
                Pen pen3DLine = new Pen(new SolidBrush(this.darkblue), 1);

                //Left half 
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, this.gradientColor1, this.gradientColor2, LinearGradientMode.ForwardDiagonal);
                g.FillRectangle(lbLeft, rectLeft);
                g.DrawRectangle(penRect, rectLeft.Left, rectLeft.Top, width - 1, intHeight - 1);
                g.DrawLine(pen3DLine, rectLeft.Left, rectLeft.Bottom, rectLeft.Right, rectLeft.Bottom);//Horizontal Bottom line
                g.DrawLine(pen3DLine, rectLeft.Right, rectLeft.Bottom, rectLeft.Right, rectLeft.Top);//Vertical Right line
                                                                                                     //Right Half
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, this.gradientColor1, this.gradientColor2, LinearGradientMode.BackwardDiagonal);
                g.FillPolygon(lbRight, pointsRight);
                g.DrawLines(penRect, pointsRightInner);//Vertical Left line
                g.DrawLine(penRect, pRightBottom, pRightTop);
                g.DrawLines(pen3DLine, pointsRight);//Dark lines

            }
            else //Normal state
            {
                Pen penRect = new Pen(new SolidBrush(Color.DarkGray), 1);
                Pen pen3DLine = new Pen(new SolidBrush(Color.Black), 1);

                //Left half
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, Color.White, Color.Gray, LinearGradientMode.ForwardDiagonal);
                g.FillRectangle(lbLeft, rectLeft);
                g.DrawRectangle(penRect, rectLeft.Left, rectLeft.Top, width - 1, intHeight - 1);
                g.DrawLine(pen3DLine, rectLeft.Left, rectLeft.Bottom, rectLeft.Right, rectLeft.Bottom);//Horizontal Bottom line
                g.DrawLine(pen3DLine, rectLeft.Right, rectLeft.Bottom, rectLeft.Right, rectLeft.Top);//Vertical Right line
                                                                                                     //Right Half
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, Color.White, Color.Gray, LinearGradientMode.BackwardDiagonal);
                g.FillPolygon(lbRight, pointsRight);
                g.DrawLine(penRect, pRightBottom, pRightTop);
                g.DrawLines(pen3DLine, pointsRight);//Dark lines
            }
        }
        private void DrawAudioToEnd(Graphics g, int x, int y, int intWidth, int intHeight, AudioButtonDrawState state)
        {

            int width = 4;
            int height = (int)(intHeight / 2);

            Rectangle rectRight = new Rectangle(x + intWidth - width + 1, y, width, intHeight);

            //Left Points
            Point pLeftTop = new Point(x, y);
            Point pLeftBottom = new Point(x, y + intHeight);
            Point pLeftRight = new Point(x + intWidth - width, y + height);
            Point[] pointsLeft = { pLeftBottom, pLeftRight, pLeftTop };
            //Left Inner Points
            Point pLeftInnerTop = new Point(x + 1, y + 1);
            Point pLeftInnerBottom = new Point(x + 1, y + intHeight - 1);
            Point pLeftInnerRight = new Point(x + intWidth - width - 1, y + height);
            Point[] pointsLeftInner = { pLeftInnerBottom, pLeftInnerRight, pLeftInnerTop };

            Rectangle rectLeft = new Rectangle(x, y, intWidth - width, intHeight);

            DrawBackground(g, state);

            if (state == AudioButtonDrawState.Disable)
            {
                Pen penRect = new Pen(new SolidBrush(Color.FromArgb(189, 188, 186)), 1);
                Pen pen3DLine = new Pen(new SolidBrush(Color.FromArgb(136, 132, 133)), 1);
                //Left Half
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, Color.FromArgb(240, 236, 237), Color.FromArgb(179, 179, 179), LinearGradientMode.ForwardDiagonal);
                g.FillPolygon(lbLeft, pointsLeft);
                g.DrawLines(penRect, pointsLeftInner);//Vertical Left line
                g.DrawLine(penRect, pLeftTop, pLeftBottom);
                g.DrawLines(pen3DLine, pointsLeft);//Dark lines
                                                   //Right Half
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, Color.FromArgb(240, 236, 237), Color.FromArgb(179, 179, 179), LinearGradientMode.ForwardDiagonal);
                g.FillRectangle(lbRight, rectRight);
                g.DrawRectangle(penRect, rectRight.Left, y, width - 1, intHeight - 1);
                g.DrawLine(pen3DLine, rectRight.Left, rectRight.Bottom, rectRight.Right, rectRight.Bottom);//Horizontal Bottom line
                g.DrawLine(pen3DLine, rectRight.Right, rectRight.Bottom, rectRight.Right, rectRight.Top);//Vertical Right line

            }
            else if (state == AudioButtonDrawState.Hot || state == AudioButtonDrawState.Pressed)
            {
                Pen penRect = new Pen(new SolidBrush(this.lightblue), 1);
                Pen pen3DLine = new Pen(new SolidBrush(this.darkblue), 1);
                //Left half 
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, this.gradientColor1, this.gradientColor2, LinearGradientMode.ForwardDiagonal);
                g.FillPolygon(lbLeft, pointsLeft);
                g.DrawLines(penRect, pointsLeftInner);//Vertical Left line
                g.DrawLine(penRect, pLeftTop, pLeftBottom);
                g.DrawLines(pen3DLine, pointsLeft);//Dark lines
                                                   //Right Half
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, this.gradientColor1, this.gradientColor2, LinearGradientMode.BackwardDiagonal);
                g.FillRectangle(lbRight, rectRight);
                g.DrawRectangle(penRect, rectRight.Left, y, width - 1, intHeight - 1);
                g.DrawLine(pen3DLine, rectRight.Left, rectRight.Bottom, rectRight.Right, rectRight.Bottom);//Horizontal Bottom line
                g.DrawLine(pen3DLine, rectRight.Right, rectRight.Bottom, rectRight.Right, rectRight.Top);//Vertical Right line
            }
            else //Normal state
            {
                Pen penRect = new Pen(new SolidBrush(Color.DarkGray), 1);
                Pen pen3DLine = new Pen(new SolidBrush(Color.Black), 1);
                //Left half
                LinearGradientBrush lbLeft = new LinearGradientBrush(rectLeft, Color.White, Color.Gray, LinearGradientMode.ForwardDiagonal);
                g.FillPolygon(lbLeft, pointsLeft);
                g.DrawLines(penRect, pointsLeftInner);//Vertical Left line
                g.DrawLine(penRect, pLeftTop, pLeftBottom);
                g.DrawLines(pen3DLine, pointsLeft);//Dark lines
                                                   //Right Half
                LinearGradientBrush lbRight = new LinearGradientBrush(rectRight, Color.White, Color.Gray, LinearGradientMode.BackwardDiagonal);
                g.FillRectangle(lbRight, rectRight);
                g.DrawRectangle(penRect, rectRight.Left, y, width - 1, intHeight - 1);
                g.DrawLine(pen3DLine, rectRight.Left, rectRight.Bottom, rectRight.Right, rectRight.Bottom);//Horizontal Bottom line
                g.DrawLine(pen3DLine, rectRight.Right, rectRight.Bottom, rectRight.Right, rectRight.Top);//Vertical Right line
            }
        }

        #endregion
    }

    #endregion

    #endregion


}
