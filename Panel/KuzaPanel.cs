// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="KuzaPanel.cs" company="Zeroit Dev Technologies">
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
    #region Kuza Panel

    #region Static Class
    /// <summary>
    /// Class Common.
    /// </summary>
    static class Common
    {
        /// <summary>
        /// Roundeds the rect.
        /// </summary>
        /// <param name="baseRect">The base rect.</param>
        /// <param name="topLeftRadius">The top left radius.</param>
        /// <param name="topRightRadius">The top right radius.</param>
        /// <param name="bottomLeftRadius">The bottom left radius.</param>
        /// <param name="bottomRightRadius">The bottom right radius.</param>
        /// <returns>System.Drawing.Drawing2D.GraphicsPath.</returns>
        public static System.Drawing.Drawing2D.GraphicsPath RoundedRect(
            System.Drawing.Rectangle baseRect, int topLeftRadius,
            int topRightRadius, int bottomLeftRadius, int bottomRightRadius)
        {
            int topLeftDiameter = topLeftRadius * 2;
            int topRightDiameter = topRightRadius * 2;
            int bottomLeftDiameter = bottomLeftRadius * 2;
            int bottomRightDiameter = bottomRightRadius * 2;

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

            System.Drawing.Rectangle rectTopLeft = new System.Drawing.Rectangle(
                baseRect.Left, baseRect.Top, topLeftDiameter, topLeftDiameter);
            System.Drawing.Rectangle rectTopRight = new System.Drawing.Rectangle(
                baseRect.Right - topRightDiameter, baseRect.Top, topRightDiameter, topRightDiameter);
            System.Drawing.Rectangle rectBottomLeft = new System.Drawing.Rectangle(
                baseRect.Left, baseRect.Bottom - bottomLeftDiameter, bottomLeftDiameter, bottomLeftDiameter);
            System.Drawing.Rectangle rectBottomRight = new System.Drawing.Rectangle(
                baseRect.Right - bottomRightDiameter, baseRect.Bottom - bottomRightDiameter, bottomRightDiameter, bottomRightDiameter);

            gp.AddArc(rectTopLeft, 180, 90);
            gp.AddArc(rectTopRight, 270, 90);
            gp.AddArc(rectBottomRight, 0, 90);
            gp.AddArc(rectBottomLeft, 90, 90);

            gp.CloseFigure();

            return gp;
        }

        /// <summary>
        /// Roundeds the rect.
        /// </summary>
        /// <param name="baseRect">The base rect.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <returns>System.Drawing.Drawing2D.GraphicsPath.</returns>
        public static System.Drawing.Drawing2D.GraphicsPath RoundedRect(
            System.Drawing.Rectangle baseRect, int cornerRadius)
        {
            int diameter = cornerRadius * 2;

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

            System.Drawing.Rectangle rectTopLeft = new System.Drawing.Rectangle(
                baseRect.Left, baseRect.Top, diameter, diameter);
            System.Drawing.Rectangle rectTopRight = new System.Drawing.Rectangle(
                baseRect.Right - diameter, baseRect.Top, diameter, diameter);
            System.Drawing.Rectangle rectBottomLeft = new System.Drawing.Rectangle(
                baseRect.Left, baseRect.Bottom - diameter, diameter, diameter);
            System.Drawing.Rectangle rectBottomRight = new System.Drawing.Rectangle(
                baseRect.Right - diameter, baseRect.Bottom - diameter, diameter, diameter);

            gp.AddArc(rectTopLeft, 180, 90);
            gp.AddArc(rectTopRight, 270, 90);
            gp.AddArc(rectBottomRight, 0, 90);
            gp.AddArc(rectBottomLeft, 90, 90);

            gp.CloseFigure();

            return gp;
        }
    }

    #endregion

    #region ZeroitKuzaButton

    //[ToolboxItem(true)]
    //public class ZeroitKuzaButton : Control, IButtonControl
    //{
    //    public enum Alignment { Left, Right };

    //    private bool isMouseIn;
    //    private bool isMouseDown;

    //    private SBButtonAppearance _defaultStyle = new SBButtonAppearance();

    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance")]
    //    public SBButtonAppearance DefaultStyle
    //    {
    //        get
    //        {
    //            return _defaultStyle;
    //        }
    //    }

    //    private SBButtonAppearance _mouseOverStyle = new SBButtonAppearance();

    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance")]
    //    public SBButtonAppearance MouseOverStyle
    //    {
    //        get
    //        {
    //            return _mouseOverStyle;
    //        }
    //    }

    //    private SBButtonAppearance _mouseDownStyle = new SBButtonAppearance();

    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance")]
    //    public SBButtonAppearance MouseDownStyle
    //    {
    //        get
    //        {
    //            return _mouseDownStyle;
    //        }
    //    }

    //    private SBButtonAppearance _disabledStyle = new SBButtonAppearance();

    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance")]
    //    public SBButtonAppearance DisabledStyle
    //    {
    //        get
    //        {
    //            return _disabledStyle;
    //        }
    //    }

    //    private Color _focusCueColor = SystemColors.ControlDarkDark;

    //    [Category("Appearance")]
    //    public Color FocusCueColor
    //    {
    //        get { return _focusCueColor; }
    //        set
    //        {
    //            _focusCueColor = value;
    //            this.Invalidate();
    //        }
    //    }

    //    private bool _roundedCorners = true;

    //    [Category("Appearance")]
    //    public bool RoundedCorners
    //    {
    //        get { return _roundedCorners; }
    //        set
    //        {
    //            _roundedCorners = value;
    //            this.Invalidate();
    //        }
    //    }

    //    private bool _showFocusCue = true;

    //    [Category("Appearance")]
    //    public bool ShowFocusCue
    //    {
    //        get { return _showFocusCue; }
    //        set
    //        {
    //            _showFocusCue = value;
    //        }
    //    }

    //    private Image _image;

    //    [Category("Appearance")]
    //    public Image Image
    //    {
    //        get { return _image; }
    //        set
    //        {
    //            _image = value;
    //            this.Invalidate();
    //        }
    //    }

    //    private Alignment _imageAlignment = Alignment.Right;

    //    [Category("Appearance")]
    //    public Alignment ImageAlignment
    //    {
    //        get { return _imageAlignment; }
    //        set
    //        {
    //            _imageAlignment = value;
    //            this.Invalidate();
    //        }
    //    }

    //    [Browsable(false)]
    //    public override Color BackColor
    //    {
    //        get
    //        {
    //            return base.BackColor;
    //        }
    //        set
    //        {
    //            base.BackColor = value;
    //        }
    //    }

    //    [Browsable(false)]
    //    public override Color ForeColor
    //    {
    //        get
    //        {
    //            return base.ForeColor;
    //        }
    //        set
    //        {
    //            base.ForeColor = value;
    //        }
    //    }

    //    [Browsable(false)]
    //    public override Font Font
    //    {
    //        get
    //        {
    //            return base.Font;
    //        }
    //        set
    //        {
    //            base.Font = value;
    //        }
    //    }

    //    [Browsable(false)]
    //    public override Image BackgroundImage
    //    {
    //        get
    //        {
    //            return base.BackgroundImage;
    //        }
    //        set
    //        {
    //            base.BackgroundImage = value;
    //        }
    //    }

    //    [Browsable(false)]
    //    public override ImageLayout BackgroundImageLayout
    //    {
    //        get
    //        {
    //            return base.BackgroundImageLayout;
    //        }
    //        set
    //        {
    //            base.BackgroundImageLayout = value;
    //        }
    //    }

    //    public override string Text
    //    {
    //        get
    //        {
    //            return base.Text;
    //        }
    //        set
    //        {
    //            base.Text = value;
    //            this.Invalidate();
    //        }
    //    }

    //    #region IButtonControl Members

    //    private DialogResult _dialogResult = DialogResult.None;

    //    [Category("Behavior")]
    //    public DialogResult DialogResult
    //    {
    //        get
    //        {
    //            return _dialogResult;
    //        }
    //        set
    //        {
    //            _dialogResult = value;
    //        }
    //    }

    //    public void NotifyDefault(bool value)
    //    {
    //        //do nothing here
    //    }

    //    public void PerformClick()
    //    {
    //        base.OnClick(new EventArgs());
    //    }

    //    #endregion

    //    public ZeroitKuzaButton()
    //    {


    //        this.SetStyle(ControlStyles.UserPaint, true);
    //        this.SetStyle(ControlStyles.ResizeRedraw, true);
    //        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    //        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    //        this.SetStyle(ControlStyles.Selectable, true);
    //        this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    //        this.SetStyle(ControlStyles.UserMouse, true);

    //        this.BackColor = Color.Transparent;

    //        this.MouseOverStyle.BackColor1 = SystemColors.ButtonFace;
    //        this.MouseOverStyle.BackColor2 = SystemColors.ControlLightLight;
    //        this.MouseOverStyle.FillMode = LinearGradientMode.Vertical;

    //        this.MouseDownStyle.BackColor1 = SystemColors.ButtonFace;
    //        this.MouseDownStyle.BackColor2 = SystemColors.ControlDark;
    //        this.MouseDownStyle.FillMode = LinearGradientMode.Vertical;

    //        this.DisabledStyle.HightLightOpacity1 = 0;
    //        this.DisabledStyle.HightLightOpacity2 = 0;
    //        this.DisabledStyle.GlowOpacity = 0;
    //        this.DisabledStyle.TextColor = SystemColors.GrayText;

    //        this.DefaultStyle.SBButtonAppearanceChanged += new EventHandler<EventArgs>(DefaultStyle_SBButtonAppearanceChanged);
    //    }

    //    void DefaultStyle_SBButtonAppearanceChanged(object sender, EventArgs e)
    //    {
    //        this.Invalidate();
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
    //        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;

    //        if (!isMouseIn && !isMouseDown && this.Enabled)
    //            this.DrawDefault(e);

    //        if (isMouseIn && !isMouseDown && this.Enabled)
    //            this.DrawMouseOver(e);

    //        if (isMouseIn && isMouseDown && this.Enabled)
    //            this.DrawMouseDown(e);

    //        if (!isMouseIn && isMouseDown && this.Enabled)
    //            this.DrawMouseDown(e);

    //        if (!this.Enabled)
    //            this.DrawDisabled(e);

    //        if (this.Focused && this.ShowFocusCue && this.Enabled)
    //            ControlPaint.DrawBorder(e.Graphics, new Rectangle(
    //                2, 2, this.Width - 4, this.Height - 4), this.FocusCueColor,
    //                ButtonBorderStyle.Dashed);
    //    }

    //    protected override void OnMouseEnter(EventArgs e)
    //    {
    //        isMouseIn = true;
    //        this.Invalidate();
    //    }

    //    protected override void OnMouseLeave(EventArgs e)
    //    {
    //        isMouseIn = false;
    //        this.Invalidate();
    //    }

    //    protected override void OnMouseDown(MouseEventArgs e)
    //    {
    //        if (e.Button == MouseButtons.Left)
    //        {
    //            isMouseDown = true;
    //            this.Invalidate();
    //        }
    //    }

    //    protected override void OnMouseUp(MouseEventArgs e)
    //    {
    //        if (e.Button == MouseButtons.Left)
    //            this.Select();

    //        isMouseDown = false;
    //        this.Invalidate();
    //    }

    //    protected override void OnGotFocus(EventArgs e)
    //    {
    //        this.Invalidate();
    //    }

    //    protected override void OnLostFocus(EventArgs e)
    //    {
    //        this.Invalidate();
    //    }

    //    protected override void OnKeyDown(KeyEventArgs e)
    //    {
    //        if (e.KeyCode == Keys.Space)
    //        {
    //            isMouseDown = true;
    //            this.Invalidate();
    //        }
    //    }

    //    protected override void OnKeyUp(KeyEventArgs e)
    //    {
    //        isMouseDown = false;

    //        if (e.KeyCode == Keys.Space)
    //            this.PerformClick();

    //        this.Invalidate();
    //    }

    //    protected override void OnKeyPress(KeyPressEventArgs e)
    //    {
    //        if (e.KeyChar == (char)13)
    //            this.PerformClick();
    //    }

    //    protected override void OnMouseClick(MouseEventArgs e)
    //    {
    //        if (e.Button == MouseButtons.Left)
    //            this.PerformClick();
    //    }

    //    protected override void OnClick(EventArgs e)
    //    {
    //        isMouseDown = false;
    //        this.Invalidate();
    //    }

    //    protected override bool ProcessMnemonic(char charCode)
    //    {
    //        if (CanSelect && IsMnemonic(charCode, this.Text))
    //        {
    //            this.PerformClick();
    //            return true;
    //        }

    //        return false;
    //    }

    //    private void DrawDefault(PaintEventArgs e)
    //    {
    //        LinearGradientBrush brBackground = new LinearGradientBrush(
    //            this.ClientRectangle, this.DefaultStyle.BackColor1, this.DefaultStyle.BackColor2,
    //            this.DefaultStyle.FillMode);
    //        LinearGradientBrush brHighlight = new LinearGradientBrush(new Rectangle(
    //            2, 2, this.Width - 5, this.Height / 2), Color.FromArgb(this.DefaultStyle.HightLightOpacity1, this.DefaultStyle.HighLightColor),
    //            Color.FromArgb(this.DefaultStyle.HightLightOpacity2, this.DefaultStyle.HighLightColor), LinearGradientMode.Vertical);
    //        LinearGradientBrush brGlow = new LinearGradientBrush(new Rectangle(
    //            0, this.Height - this.Height / 4 - 1, this.Width - 1, this.Height / 4),
    //            Color.Transparent, Color.FromArgb(this.DefaultStyle.GlowOpacity, this.DefaultStyle.GlowColor), LinearGradientMode.Vertical);

    //        Pen pnOuterBorder = new Pen(this.DefaultStyle.OuterBorderColor, 1);
    //        Pen pnInnerBorder = new Pen(Color.FromArgb(DefaultStyle.InnerBorderOpacity, this.DefaultStyle.InnerBorderColor));

    //        GraphicsPath gpBackground = Common.RoundedRect(new Rectangle(
    //            0, 0, this.Width - 1, this.Height - 1), 3);
    //        GraphicsPath gpGlow = Common.RoundedRect(new Rectangle(
    //            1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4), 1, 1, 3, 3);
    //        GraphicsPath gpHighlight = Common.RoundedRect(new Rectangle(
    //            2, 2, this.Width - 5, this.Height / 2 - 1), 3, 3, 1, 1);
    //        GraphicsPath gpOuterBorder = Common.RoundedRect(new Rectangle(
    //            0, 0, this.Width - 1, this.Height - 1), 3);
    //        GraphicsPath gpInnerBorder = Common.RoundedRect(new Rectangle(
    //            1, 1, this.Width - 3, this.Height - 3), 3);

    //        Rectangle rectBackground = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
    //        Rectangle rectGlow = new Rectangle(1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4);
    //        Rectangle rectHighlight = new Rectangle(2, 2, this.Width - 5, this.Height / 2 - 1);
    //        Rectangle rectOuterBorder = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
    //        Rectangle rectInnerBorder = new Rectangle(1, 1, this.Width - 3, this.Height - 3);

    //        Size textSize = TextRenderer.MeasureText(this.Text, this.DefaultStyle.Font);

    //        Point textPos = new Point(this.Width / 2 - textSize.Width / 2,
    //            this.Height / 2 - textSize.Height / 2);
    //        Point imagePos = new Point();

    //        switch (this.ImageAlignment)
    //        {
    //            case Alignment.Right:
    //                if (this.Image != null)
    //                {
    //                    textPos = new Point(5, this.Height / 2 - textSize.Height / 2);
    //                    imagePos = new Point(this.Width - this.Image.Width - 5,
    //                        this.Height / 2 - this.Image.Size.Height / 2);
    //                }
    //                break;
    //            case Alignment.Left:
    //                if (this.Image != null)
    //                {
    //                    textPos = new Point(this.Width - textSize.Width - 5,
    //                        this.Height / 2 - textSize.Height / 2);
    //                    imagePos = new Point(5, this.Height / 2 - this.Image.Size.Height / 2);
    //                }
    //                break;
    //        }

    //        if (this.RoundedCorners)
    //        {
    //            e.Graphics.FillPath(brBackground, gpBackground);
    //            e.Graphics.FillPath(brGlow, gpGlow);
    //            e.Graphics.FillPath(brHighlight, gpHighlight);
    //            e.Graphics.DrawPath(pnOuterBorder, gpOuterBorder);
    //            e.Graphics.DrawPath(pnInnerBorder, gpInnerBorder);
    //        }
    //        else
    //        {
    //            e.Graphics.FillRectangle(brBackground, rectBackground);
    //            e.Graphics.FillRectangle(brGlow, rectGlow);
    //            e.Graphics.FillRectangle(brHighlight, rectHighlight);
    //            e.Graphics.DrawRectangle(pnOuterBorder, rectOuterBorder);
    //            e.Graphics.DrawRectangle(pnInnerBorder, rectInnerBorder);
    //        }

    //        if (this.Image != null)
    //            e.Graphics.DrawImage(this.Image, imagePos.X, imagePos.Y, this.Image.Width, this.Image.Height);

    //        TextRenderer.DrawText(e.Graphics, this.Text, this.DefaultStyle.Font, textPos, this.DefaultStyle.TextColor);
    //    }

    //    private void DrawMouseOver(PaintEventArgs e)
    //    {
    //        LinearGradientBrush brBackground = new LinearGradientBrush(
    //            this.ClientRectangle, this.MouseOverStyle.BackColor1, this.MouseOverStyle.BackColor2,
    //            this.MouseOverStyle.FillMode);
    //        LinearGradientBrush brHighlight = new LinearGradientBrush(new Rectangle(
    //            2, 2, this.Width - 5, this.Height / 2), Color.FromArgb(this.MouseOverStyle.HightLightOpacity1, this.MouseOverStyle.HighLightColor),
    //            Color.FromArgb(this.MouseOverStyle.HightLightOpacity2, this.MouseOverStyle.HighLightColor), LinearGradientMode.Vertical);
    //        LinearGradientBrush brGlow = new LinearGradientBrush(new Rectangle(
    //            0, this.Height - this.Height / 4 - 1, this.Width - 1, this.Height / 4),
    //            Color.Transparent, Color.FromArgb(this.MouseOverStyle.GlowOpacity, this.MouseOverStyle.GlowColor), LinearGradientMode.Vertical);

    //        Pen pnOuterBorder = new Pen(this.MouseDownStyle.OuterBorderColor, 1);
    //        Pen pnInnerBorder = new Pen(Color.FromArgb(MouseOverStyle.InnerBorderOpacity, this.MouseDownStyle.InnerBorderColor));

    //        GraphicsPath gpBackground = Common.RoundedRect(new Rectangle(
    //            0, 0, this.Width - 1, this.Height - 1), 3);
    //        GraphicsPath gpGlow = Common.RoundedRect(new Rectangle(
    //            1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4), 1, 1, 3, 3);
    //        GraphicsPath gpHighlight = Common.RoundedRect(new Rectangle(
    //            2, 2, this.Width - 5, this.Height / 2 - 1), 3, 3, 1, 1);
    //        GraphicsPath gpOuterBorder = Common.RoundedRect(new Rectangle(
    //            0, 0, this.Width - 1, this.Height - 1), 3);
    //        GraphicsPath gpInnerBorder = Common.RoundedRect(new Rectangle(
    //            1, 1, this.Width - 3, this.Height - 3), 3);

    //        Rectangle rectBackground = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
    //        Rectangle rectGlow = new Rectangle(1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4);
    //        Rectangle rectHighlight = new Rectangle(2, 2, this.Width - 5, this.Height / 2 - 1);
    //        Rectangle rectOuterBorder = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
    //        Rectangle rectInnerBorder = new Rectangle(1, 1, this.Width - 3, this.Height - 3);

    //        Size textSize = TextRenderer.MeasureText(this.Text, this.MouseOverStyle.Font);

    //        Point textPos = new Point(this.Width / 2 - textSize.Width / 2 - 1,
    //            this.Height / 2 - textSize.Height / 2 - 1);
    //        Point imagePos = new Point();

    //        switch (this.ImageAlignment)
    //        {
    //            case Alignment.Right:
    //                if (this.Image != null)
    //                {
    //                    textPos = new Point(4, this.Height / 2 - textSize.Height / 2 - 1);
    //                    imagePos = new Point(this.Width - this.Image.Width - 6,
    //                        this.Height / 2 - this.Image.Size.Height / 2 - 1);
    //                }
    //                break;
    //            case Alignment.Left:
    //                if (this.Image != null)
    //                {
    //                    textPos = new Point(this.Width - textSize.Width - 6,
    //                        this.Height / 2 - textSize.Height / 2 - 1);
    //                    imagePos = new Point(4, this.Height / 2 - this.Image.Size.Height / 2 - 1);
    //                }
    //                break;
    //        }

    //        if (this.RoundedCorners)
    //        {
    //            e.Graphics.FillPath(brBackground, gpBackground);
    //            e.Graphics.FillPath(brGlow, gpGlow);
    //            e.Graphics.FillPath(brHighlight, gpHighlight);
    //            e.Graphics.DrawPath(pnOuterBorder, gpOuterBorder);
    //            e.Graphics.DrawPath(pnInnerBorder, gpInnerBorder);
    //        }
    //        else
    //        {
    //            e.Graphics.FillRectangle(brBackground, rectBackground);
    //            e.Graphics.FillRectangle(brGlow, rectGlow);
    //            e.Graphics.FillRectangle(brHighlight, rectHighlight);
    //            e.Graphics.DrawRectangle(pnOuterBorder, rectOuterBorder);
    //            e.Graphics.DrawRectangle(pnInnerBorder, rectInnerBorder);
    //        }

    //        if (this.Image != null)
    //            e.Graphics.DrawImage(this.Image, imagePos.X, imagePos.Y, this.Image.Width, this.Image.Height);

    //        TextRenderer.DrawText(e.Graphics, this.Text, this.MouseOverStyle.Font, textPos, this.MouseOverStyle.TextColor);
    //    }

    //    private void DrawMouseDown(PaintEventArgs e)
    //    {
    //        LinearGradientBrush brBackground = new LinearGradientBrush(
    //            this.ClientRectangle, this.MouseDownStyle.BackColor1, this.MouseDownStyle.BackColor2,
    //            this.MouseDownStyle.FillMode);
    //        LinearGradientBrush brHighlight = new LinearGradientBrush(new Rectangle(
    //            2, 2, this.Width - 5, this.Height / 2), Color.FromArgb(this.MouseDownStyle.HightLightOpacity1, this.MouseDownStyle.HighLightColor),
    //            Color.FromArgb(this.MouseDownStyle.HightLightOpacity2, this.MouseDownStyle.HighLightColor), LinearGradientMode.Vertical);
    //        LinearGradientBrush brGlow = new LinearGradientBrush(new Rectangle(
    //            0, this.Height - this.Height / 4 - 1, this.Width - 1, this.Height / 4),
    //            Color.Transparent, Color.FromArgb(this.MouseDownStyle.GlowOpacity, this.MouseDownStyle.GlowColor), LinearGradientMode.Vertical);

    //        Pen pnOuterBorder = new Pen(this.MouseDownStyle.OuterBorderColor, 1);
    //        Pen pnInnerBorder = new Pen(Color.FromArgb(MouseDownStyle.InnerBorderOpacity, this.MouseDownStyle.InnerBorderColor));

    //        GraphicsPath gpBackground = Common.RoundedRect(new Rectangle(
    //            0, 0, this.Width - 1, this.Height - 1), 3);
    //        GraphicsPath gpGlow = Common.RoundedRect(new Rectangle(
    //            1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4), 1, 1, 3, 3);
    //        GraphicsPath gpHighlight = Common.RoundedRect(new Rectangle(
    //            2, 2, this.Width - 5, this.Height / 2 - 1), 3, 3, 1, 1);
    //        GraphicsPath gpOuterBorder = Common.RoundedRect(new Rectangle(
    //            0, 0, this.Width - 1, this.Height - 1), 3);
    //        GraphicsPath gpInnerBorder = Common.RoundedRect(new Rectangle(
    //            1, 1, this.Width - 3, this.Height - 3), 3);

    //        Rectangle rectBackground = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
    //        Rectangle rectGlow = new Rectangle(1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4);
    //        Rectangle rectHighlight = new Rectangle(2, 2, this.Width - 5, this.Height / 2 - 1);
    //        Rectangle rectOuterBorder = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
    //        Rectangle rectInnerBorder = new Rectangle(1, 1, this.Width - 3, this.Height - 3);

    //        Size textSize = TextRenderer.MeasureText(this.Text, this.MouseDownStyle.Font);

    //        Point textPos = new Point(this.Width / 2 - textSize.Width / 2,
    //            this.Height / 2 - textSize.Height / 2);
    //        Point imagePos = new Point();

    //        switch (this.ImageAlignment)
    //        {
    //            case Alignment.Right:
    //                if (this.Image != null)
    //                {
    //                    textPos = new Point(5, this.Height / 2 - textSize.Height / 2);
    //                    imagePos = new Point(this.Width - this.Image.Width - 5,
    //                        this.Height / 2 - this.Image.Size.Height / 2);
    //                }
    //                break;
    //            case Alignment.Left:
    //                if (this.Image != null)
    //                {
    //                    textPos = new Point(this.Width - textSize.Width - 5,
    //                        this.Height / 2 - textSize.Height / 2);
    //                    imagePos = new Point(5, this.Height / 2 - this.Image.Size.Height / 2);
    //                }
    //                break;
    //        }

    //        if (this.RoundedCorners)
    //        {
    //            e.Graphics.FillPath(brBackground, gpBackground);
    //            e.Graphics.FillPath(brGlow, gpGlow);
    //            e.Graphics.FillPath(brHighlight, gpHighlight);
    //            e.Graphics.DrawPath(pnOuterBorder, gpOuterBorder);
    //            e.Graphics.DrawPath(pnInnerBorder, gpInnerBorder);
    //        }
    //        else
    //        {
    //            e.Graphics.FillRectangle(brBackground, rectBackground);
    //            e.Graphics.FillRectangle(brGlow, rectGlow);
    //            e.Graphics.FillRectangle(brHighlight, rectHighlight);
    //            e.Graphics.DrawRectangle(pnOuterBorder, rectOuterBorder);
    //            e.Graphics.DrawRectangle(pnInnerBorder, rectInnerBorder);
    //        }

    //        if (this.Image != null)
    //            e.Graphics.DrawImage(this.Image, imagePos.X, imagePos.Y, this.Image.Width, this.Image.Height);

    //        TextRenderer.DrawText(e.Graphics, this.Text, this.MouseDownStyle.Font, textPos, this.MouseDownStyle.TextColor);
    //    }

    //    private void DrawDisabled(PaintEventArgs e)
    //    {
    //        LinearGradientBrush brBackground = new LinearGradientBrush(
    //            this.ClientRectangle, this.DisabledStyle.BackColor1, this.DisabledStyle.BackColor2,
    //            this.DefaultStyle.FillMode);
    //        LinearGradientBrush brHighlight = new LinearGradientBrush(new Rectangle(
    //            2, 2, this.Width - 5, this.Height / 2), Color.FromArgb(this.DisabledStyle.HightLightOpacity1, this.DisabledStyle.HighLightColor),
    //            Color.FromArgb(this.DisabledStyle.HightLightOpacity2, this.DisabledStyle.HighLightColor), LinearGradientMode.Vertical);
    //        LinearGradientBrush brGlow = new LinearGradientBrush(new Rectangle(
    //            0, this.Height - this.Height / 4 - 1, this.Width - 1, this.Height / 4),
    //            Color.Transparent, Color.FromArgb(this.DisabledStyle.GlowOpacity, this.DisabledStyle.GlowColor), LinearGradientMode.Vertical);

    //        Pen pnOuterBorder = new Pen(this.DisabledStyle.OuterBorderColor, 1);
    //        Pen pnInnerBorder = new Pen(Color.FromArgb(DisabledStyle.InnerBorderOpacity, this.DisabledStyle.InnerBorderColor));

    //        GraphicsPath gpBackground = Common.RoundedRect(new Rectangle(
    //            0, 0, this.Width - 1, this.Height - 1), 3);
    //        GraphicsPath gpGlow = Common.RoundedRect(new Rectangle(
    //            1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4), 1, 1, 3, 3);
    //        GraphicsPath gpHighlight = Common.RoundedRect(new Rectangle(
    //            2, 2, this.Width - 5, this.Height / 2 - 1), 3, 3, 1, 1);
    //        GraphicsPath gpOuterBorder = Common.RoundedRect(new Rectangle(
    //            0, 0, this.Width - 1, this.Height - 1), 3);
    //        GraphicsPath gpInnerBorder = Common.RoundedRect(new Rectangle(
    //            1, 1, this.Width - 3, this.Height - 3), 3);

    //        Rectangle rectBackground = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
    //        Rectangle rectGlow = new Rectangle(1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4);
    //        Rectangle rectHighlight = new Rectangle(2, 2, this.Width - 5, this.Height / 2 - 1);
    //        Rectangle rectOuterBorder = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
    //        Rectangle rectInnerBorder = new Rectangle(1, 1, this.Width - 3, this.Height - 3);

    //        Size textSize = TextRenderer.MeasureText(this.Text, this.DisabledStyle.Font);

    //        Point textPos = new Point(this.Width / 2 - textSize.Width / 2,
    //            this.Height / 2 - textSize.Height / 2);
    //        Point imagePos = new Point();

    //        switch (this.ImageAlignment)
    //        {
    //            case Alignment.Right:
    //                if (this.Image != null)
    //                {
    //                    textPos = new Point(5, this.Height / 2 - textSize.Height / 2);
    //                    imagePos = new Point(this.Width - this.Image.Width - 5,
    //                        this.Height / 2 - this.Image.Size.Height / 2);
    //                }
    //                break;
    //            case Alignment.Left:
    //                if (this.Image != null)
    //                {
    //                    textPos = new Point(this.Width - textSize.Width - 5,
    //                        this.Height / 2 - textSize.Height / 2);
    //                    imagePos = new Point(5, this.Height / 2 - this.Image.Size.Height / 2);
    //                }
    //                break;
    //        }

    //        if (this.RoundedCorners)
    //        {
    //            e.Graphics.FillPath(brBackground, gpBackground);
    //            e.Graphics.FillPath(brGlow, gpGlow);
    //            e.Graphics.FillPath(brHighlight, gpHighlight);
    //            e.Graphics.DrawPath(pnOuterBorder, gpOuterBorder);
    //            e.Graphics.DrawPath(pnInnerBorder, gpInnerBorder);
    //        }
    //        else
    //        {
    //            e.Graphics.FillRectangle(brBackground, rectBackground);
    //            e.Graphics.FillRectangle(brGlow, rectGlow);
    //            e.Graphics.FillRectangle(brHighlight, rectHighlight);
    //            e.Graphics.DrawRectangle(pnOuterBorder, rectOuterBorder);
    //            e.Graphics.DrawRectangle(pnInnerBorder, rectInnerBorder);
    //        }

    //        if (this.Image != null)
    //            e.Graphics.DrawImage(this.Image, imagePos.X, imagePos.Y, this.Image.Width, this.Image.Height);

    //        TextRenderer.DrawText(e.Graphics, this.Text, this.DisabledStyle.Font, textPos, this.DisabledStyle.TextColor);
    //    }
    //}

    //[Serializable()]
    //[TypeConverter(typeof(ExpandableObjectConverter))]
    //public class SBButtonAppearance
    //{
    //    public event EventHandler<EventArgs> SBButtonAppearanceChanged;

    //    private Color _backColor1 = SystemColors.ButtonFace;

    //    public Color BackColor1
    //    {
    //        get { return _backColor1; }
    //        set
    //        {
    //            _backColor1 = value;
    //            AppearanceChanged();
    //        }
    //    }

    //    private Color _backColor2 = SystemColors.ButtonFace;

    //    public Color BackColor2
    //    {
    //        get { return _backColor2; }
    //        set
    //        {
    //            _backColor2 = value;
    //            AppearanceChanged();
    //        }
    //    }

    //    private Color _outerBorderColor = SystemColors.ControlDarkDark;

    //    public Color OuterBorderColor
    //    {
    //        get { return _outerBorderColor; }
    //        set
    //        {
    //            _outerBorderColor = value;
    //            AppearanceChanged();
    //        }
    //    }

    //    private Color _innerBorderColor = SystemColors.ControlLightLight;

    //    public Color InnerBorderColor
    //    {
    //        get { return _innerBorderColor; }
    //        set
    //        {
    //            _innerBorderColor = value;
    //            AppearanceChanged();
    //        }
    //    }

    //    private Color _glowColor = SystemColors.ControlLightLight;

    //    public Color GlowColor
    //    {
    //        get { return _glowColor; }
    //        set
    //        {
    //            _glowColor = value;
    //            AppearanceChanged();
    //        }
    //    }

    //    private Color _highLightColor = SystemColors.ControlLightLight;

    //    public Color HighLightColor
    //    {
    //        get { return _highLightColor; }
    //        set
    //        {
    //            _highLightColor = value;
    //            AppearanceChanged();
    //        }
    //    }

    //    private Color _textColor = SystemColors.ControlText;

    //    public Color TextColor
    //    {
    //        get { return _textColor; }
    //        set
    //        {
    //            _textColor = value;
    //            AppearanceChanged();
    //        }
    //    }

    //    private Font _font = SystemFonts.DefaultFont;

    //    public Font Font
    //    {
    //        get { return _font; }
    //        set
    //        {
    //            _font = value;
    //            AppearanceChanged();
    //        }
    //    }

    //    private LinearGradientMode _fillMode = LinearGradientMode.Horizontal;

    //    public LinearGradientMode FillMode
    //    {
    //        get { return _fillMode; }
    //        set
    //        {
    //            _fillMode = value;
    //            AppearanceChanged();
    //        }
    //    }

    //    private int _innerBorderOpacity = 200;

    //    public int InnerBorderOpacity
    //    {
    //        get { return _innerBorderOpacity; }
    //        set
    //        {
    //            if (value > 255) value = 255;
    //            if (value < 0) value = 0;

    //            _innerBorderOpacity = value;
    //            AppearanceChanged();
    //        }
    //    }

    //    private int _highLightOpacity1 = 200;

    //    public int HightLightOpacity1
    //    {
    //        get { return _highLightOpacity1; }
    //        set
    //        {
    //            if (value > 255) value = 255;
    //            if (value < 0) value = 0;

    //            _highLightOpacity1 = value;
    //            AppearanceChanged();
    //        }
    //    }

    //    private int _highLightOpacity2 = 150;

    //    public int HightLightOpacity2
    //    {
    //        get { return _highLightOpacity2; }
    //        set
    //        {
    //            if (value > 255) value = 255;
    //            if (value < 0) value = 0;

    //            _highLightOpacity2 = value;
    //            AppearanceChanged();
    //        }
    //    }

    //    private int _glowOpacity = 120;

    //    public int GlowOpacity
    //    {
    //        get { return _glowOpacity; }
    //        set
    //        {
    //            if (value > 255) value = 255;
    //            if (value < 0) value = 0;

    //            _glowOpacity = value;
    //            AppearanceChanged();
    //        }
    //    }

    //    public override string ToString()
    //    {
    //        return null;
    //    }

    //    private void AppearanceChanged()
    //    {
    //        EventHandler<EventArgs> temp = SBButtonAppearanceChanged;
    //        if (temp != null)
    //            temp(this, new EventArgs());
    //    }
    //}

    #endregion

    #region Gradient Panel

    #region Control        
    /// <summary>
    /// A class collection for rendering a panel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [Designer(typeof(ZeroitKuzaPanelDesigner))]
    public partial class ZeroitKuzaPanel : Panel
    {
        /// <summary>
        /// The gradient color1
        /// </summary>
        private Color _gradientColor1 = SystemColors.ControlLight;

        #region Public Properties        
        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient color1.</value>
        [Category("Appearance")]
        public Color GradientColor1
        {
            get { return _gradientColor1; }
            set
            {
                _gradientColor1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The gradient color2
        /// </summary>
        private Color _gradientColor2 = SystemColors.Control;

        /// <summary>
        /// Gets or sets the gradient color.
        /// </summary>
        /// <value>The gradient color2.</value>
        [Category("Appearance")]
        public Color GradientColor2
        {
            get { return _gradientColor2; }
            set
            {
                _gradientColor2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The gradient direction
        /// </summary>
        private LinearGradientMode _gradientDirection = LinearGradientMode.Vertical;

        /// <summary>
        /// Gets or sets the gradient direction.
        /// </summary>
        /// <value>The gradient direction.</value>
        [Category("Appearance")]
        public LinearGradientMode GradientDirection
        {
            get { return _gradientDirection; }
            set
            {
                _gradientDirection = value;
                this.Invalidate();
            }
        }
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitKuzaPanel" /> class.
        /// </summary>
        public ZeroitKuzaPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brBackground = new LinearGradientBrush(
                this.ClientRectangle, this.GradientColor1, this.GradientColor2,
                this.GradientDirection);
            e.Graphics.FillRectangle(brBackground, this.ClientRectangle);
        }
        #endregion
    }

    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitKuzaPanelDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitKuzaPanelDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitKuzaPanelDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitKuzaPanelSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitKuzaPanelSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitKuzaPanelSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitKuzaPanel colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitKuzaPanelSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitKuzaPanelSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitKuzaPanel;

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
        /// Gets or sets the gradient color1.
        /// </summary>
        /// <value>The gradient color1.</value>
        public Color GradientColor1
        {
            get
            {
                return colUserControl.GradientColor1;
            }
            set
            {
                GetPropertyByName("GradientColor1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient color2.
        /// </summary>
        /// <value>The gradient color2.</value>
        public Color GradientColor2
        {
            get
            {
                return colUserControl.GradientColor2;
            }
            set
            {
                GetPropertyByName("GradientColor2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient direction.
        /// </summary>
        /// <value>The gradient direction.</value>
        public LinearGradientMode GradientDirection
        {
            get
            {
                return colUserControl.GradientDirection;
            }
            set
            {
                GetPropertyByName("GradientDirection").SetValue(colUserControl, value);
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
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("GradientColor1",
                                 "Gradient Color 1", "Appearance",
                                 "Sets the gradient color."));

            items.Add(new DesignerActionPropertyItem("GradientColor2",
                                 "Gradient Color 2", "Appearance",
                                 "Sets the gradient color."));

            items.Add(new DesignerActionPropertyItem("GradientDirection",
                                 "Gradient Direction", "Appearance",
                                 "Sets the gradient mode."));

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

    #endregion
}
