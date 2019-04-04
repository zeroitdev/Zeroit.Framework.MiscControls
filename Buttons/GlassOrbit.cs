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

    #region GlassOrbit

    //public class ZeroitGlassOrbit : UserControl
    //{
    //    private System.Windows.Forms.Timer _timer;
    //    private Color _mainColor = Color.DarkGreen;
    //    private Color _endColor = Color.LightYellow;
    //    private bool _mouseEnter = false;
    //    private bool _mouseDown = false;
    //    private Color _borderColor = Color.Black;
    //    private Image _icoImage = null;
    //    private String _text = "";
    //    private Color _fontColor = Color.Black;
    //    private Color outerColor = Color.WhiteSmoke;
    //    private float _focus = 0f;


    //    public Image IcoImage
    //    {
    //        get { return _icoImage; }
    //        set
    //        {
    //            if (_icoImage != value)
    //            {
    //                _icoImage = value;
    //                Invalidate();
    //            }
    //        }
    //    }



    //    public String DisplayText
    //    {
    //        get { return _text; }
    //        set
    //        {
    //            if (_text != value)
    //            {
    //                _text = value;
    //                Invalidate();
    //            }
    //        }
    //    }


    //    public Color FontColor
    //    {
    //        get { return _fontColor; }
    //        set
    //        {
    //            if (_fontColor != value)
    //            {
    //                _fontColor = value;
    //                Invalidate();
    //            }
    //        }
    //    }


    //    public Color BorderColor
    //    {
    //        get { return _borderColor; }
    //        set
    //        {
    //            if (_borderColor != value)
    //            {
    //                _borderColor = value;
    //                Invalidate();
    //            }
    //        }
    //    }

    //    public Color EndColor
    //    {
    //        get { return _endColor; }
    //        set
    //        {
    //            if (_endColor != value)
    //            {
    //                _endColor = value;
    //                Invalidate();
    //            }
    //        }
    //    }

    //    public Color OuterColor
    //    {
    //        get { return outerColor; }
    //        set
    //        {
    //            if (outerColor != value)
    //            {
    //                outerColor = value;
    //                Invalidate();
    //            }
    //        }
    //    }

    //    public Color MainColor
    //    {
    //        get { return _mainColor; }
    //        set
    //        {
    //            if (_mainColor != value)
    //            {
    //                _mainColor = value;

    //                Invalidate();
    //            }
    //        }
    //    }

    //    public ZeroitGlassOrbit()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
    //        SetStyle(ControlStyles.Opaque, false);
    //        this.BackColor = Color.Transparent;
    //        _timer = new System.Windows.Forms.Timer();
    //        _timer.Interval = 1;
    //        _timer.Tick += new EventHandler(_timer_Tick);
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
    //        Rectangle rect = Shrink(new Rectangle(0, 0, this.Width, this.Height), 3);
    //        GraphicsPath path = new GraphicsPath();
    //        e.Graphics.FillEllipse(new SolidBrush(outerColor), new Rectangle(0, 0, this.Width, this.Height));
    //        path.AddEllipse(rect);
    //        PathGradientBrush pgb1 = new PathGradientBrush(path);
    //        pgb1.CenterColor = this._endColor;
    //        pgb1.SurroundColors = new Color[] { this._mainColor };
    //        pgb1.FocusScales = new PointF(_focus, _focus);
    //        e.Graphics.FillEllipse(pgb1, rect);
    //        Rectangle small = Shrink(rect, (int)(rect.Width * 0.1));
    //        GraphicsPath p2 = new GraphicsPath();
    //        p2.AddEllipse(small);
    //        if (!_mouseDown)
    //        {
    //            PathGradientBrush pgb = new PathGradientBrush(p2);
    //            pgb.CenterColor = Color.FromArgb(0, this._mainColor);
    //            pgb.SurroundColors = new Color[] { this._mainColor };
    //            pgb.CenterPoint = new PointF(small.Left, small.Top);
    //            pgb.FocusScales = new PointF(0.2f, 0.2f);
    //            e.Graphics.FillEllipse(pgb, small);
    //        }
    //        else
    //        {
    //            LinearGradientBrush lgb2 = new LinearGradientBrush(small, _mainColor, _endColor, 225);

    //            e.Graphics.FillEllipse(lgb2, small);
    //        }
    //        GraphicsState state = e.Graphics.Save();
    //        e.Graphics.SetClip(p2);
    //        if (_icoImage != null && _text != "")
    //        {

    //            float side = Side(small) / 3f;
    //            float left = small.Left + small.Width / 2f - side / 2f;
    //            float top = small.Top + small.Height / 2f - side;
    //            e.Graphics.DrawImage(_icoImage, new RectangleF(left, top, side, side),
    //                                            new RectangleF(0, 0, _icoImage.Width, _icoImage.Height),
    //            GraphicsUnit.Pixel);

    //            Size s = TextRenderer.MeasureText(_text, base.Font);
    //            e.Graphics.DrawString(_text, base.Font, new SolidBrush(_fontColor),
    //                new PointF(small.Left + small.Width / 2f - s.Width / 2,
    //                    small.Top + small.Height / 2f));
    //        }
    //        else
    //        {
    //            if (_text != "")
    //            {
    //                Size s = TextRenderer.MeasureText(_text, base.Font);
    //                e.Graphics.DrawString(_text, base.Font, new SolidBrush(_fontColor),
    //                    new PointF(small.Left + small.Width / 2f - s.Width / 2,
    //                        small.Top + small.Height / 2f - s.Height / 2));
    //            }
    //            if (_icoImage != null)
    //            {
    //                float side = Side(small) / 3f;
    //                float left = small.Left + small.Width / 2f - side / 2f;
    //                float top = small.Top + small.Height / 2f - side / 2f;
    //                e.Graphics.DrawImage(_icoImage, new RectangleF(left, top, side, side),
    //                                                new RectangleF(0, 0, _icoImage.Width, _icoImage.Height),
    //                GraphicsUnit.Pixel);
    //            }
    //        }

    //        e.Graphics.Restore(state);

    //        e.Graphics.DrawEllipse(new Pen(_borderColor, 1), rect);
    //        e.Graphics.DrawEllipse(new Pen(_borderColor, 1), small);


    //        base.OnPaint(e);
    //    }


    //    protected override void OnMouseDown(MouseEventArgs e)
    //    {
    //        _mouseDown = true;
    //        base.OnMouseDown(e);
    //        Invalidate();
    //    }

    //    protected override void OnMouseUp(MouseEventArgs e)
    //    {
    //        _mouseDown = false;
    //        base.OnMouseUp(e);
    //        Invalidate();
    //    }

    //    protected override void OnMouseEnter(EventArgs e)
    //    {
    //        _mouseEnter = true;
    //        _timer.Start();
    //        base.OnMouseEnter(e);
    //    }

    //    protected override void OnMouseLeave(EventArgs e)
    //    {
    //        _mouseEnter = false;
    //        _timer.Start();
    //        base.OnMouseLeave(e);
    //    }

    //    private int Side(Rectangle input)
    //    {
    //        if (input.Height <= input.Width)
    //        {
    //            return input.Height;
    //        }
    //        return input.Width;
    //    }

    //    private Rectangle Shrink(Rectangle input, int size)
    //    {
    //        int width = input.Width - size * 2;
    //        int height = input.Height - size * 2;
    //        if (width < 1)
    //            width = 1;
    //        if (height < 1)
    //            height = 1;
    //        return new Rectangle(input.Left + size, input.Top + size, width, height);

    //    }

    //    void _timer_Tick(object sender, EventArgs e)
    //    {
    //        if (_mouseEnter)
    //        {
    //            if (_focus < 0.9f)
    //            {
    //                _focus = _focus + 0.1f;
    //            }
    //            else
    //            {
    //                _timer.Stop();
    //            }
    //        }
    //        else
    //        {
    //            if (_focus > 0)
    //            {
    //                _focus = _focus - 0.1f;
    //            }
    //            else
    //            {
    //                _timer.Stop();
    //            }

    //        }
    //        Invalidate();
    //    }


    //}

    #endregion


}
