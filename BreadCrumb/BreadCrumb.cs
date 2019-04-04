// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="BreadCrumb.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region BreadCrumb
    /// <summary>
    /// Class CrumbClickEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class CrumbClickEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the index of the clicked crumb in the nesting.
        /// </summary>
        /// <value>The index.</value>
        public int Index { get; private set; }
        /// <summary>
        /// Gets the crumb which was clicked.
        /// </summary>
        /// <value>The sender.</value>
        internal ZeroitBreadCrumb Sender { get; private set; }
        /// <summary>
        /// Gets whether the crumb was checked before clicking.
        /// </summary>
        /// <value><c>true</c> if [checked before]; otherwise, <c>false</c>.</value>
        public bool CheckedBefore { get; private set; }
        /// <summary>
        /// Gets or sets whether the crumb will be checked after this event.
        /// </summary>
        /// <value><c>true</c> if [checked after]; otherwise, <c>false</c>.</value>
        public bool CheckedAfter { get; set; }
        /// <summary>
        /// Gets or sets whether the crumb checks on click.
        /// <para>If the crumb checks on click, the CheckedAfter value of this event argument will not affect the control in any way.</para>
        /// </summary>
        /// <value><c>true</c> if [checks on click]; otherwise, <c>false</c>.</value>
        public bool ChecksOnClick { get; set; }

        /// <summary>
        /// Creates a new instance of the CrumbClickEventArgs class with the necessary parameters.
        /// </summary>
        /// <param name="index">The index of the clicked crumb.</param>
        /// <param name="checkd">Was the crumb checked before it was clicked?</param>
        /// <param name="checksonclick">Is the crumb supposed to change it's checked state when clicked?</param>
        /// <param name="sender">The clicked crumb.</param>
        internal CrumbClickEventArgs(int index, bool checkd, bool checksonclick, ZeroitBreadCrumb sender)
        {
            Index = index;
            Sender = sender;

            if (ChecksOnClick = checksonclick) CheckedAfter = !(CheckedBefore = checkd); else CheckedAfter = CheckedBefore = checkd;
        }
    }

    /// <summary>
    /// A class collection for rendering a bread crumb control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("CrumbClick")]
    [DefaultProperty("Text")]
    public partial class ZeroitBreadCrumb : Control
    {
        #region SETUP
        /// <summary>
        /// The left edge
        /// </summary>
        static Image Left_Edge = Properties.Resources.crumb_left_end;
        /// <summary>
        /// The body
        /// </summary>
        static Image Body = Properties.Resources.crumb_body;
        /// <summary>
        /// The right edge
        /// </summary>
        static Image Right_Edge = Properties.Resources.crumb_right_end;
        /// <summary>
        /// The right triangle
        /// </summary>
        static Image Right_Triangle = Properties.Resources.crumb_right_point;

        /// <summary>
        /// The selected left edge
        /// </summary>
        static Image Selected_Left_Edge = Properties.Resources.selected_crumb_left_end;
        /// <summary>
        /// The selected body
        /// </summary>
        static Image Selected_Body = Properties.Resources.selected_crumb_body;
        /// <summary>
        /// The selected right edge
        /// </summary>
        static Image Selected_Right_Edge = Properties.Resources.selected_crumb_right_end;
        /// <summary>
        /// The selected right triangle
        /// </summary>
        static Image Selected_Right_Triangle = Properties.Resources.selected_crumb_right_point;

        /// <summary>
        /// The hovered left edge
        /// </summary>
        static Image Hovered_Left_Edge = Properties.Resources.hovered_crumb_left_end;
        /// <summary>
        /// The hovered body
        /// </summary>
        static Image Hovered_Body = Properties.Resources.hovered_crumb_body;
        /// <summary>
        /// The hovered right edge
        /// </summary>
        static Image Hovered_Right_Edge = Properties.Resources.hovered_crumb_right_end;
        /// <summary>
        /// The hovered right triangle
        /// </summary>
        static Image Hovered_Right_Triangle = Properties.Resources.hovered_crumb_right_point;

        /// <summary>
        /// The clicked left edge
        /// </summary>
        static Image Clicked_Left_Edge = Properties.Resources.clicked_crumb_left_end;
        /// <summary>
        /// The clicked body
        /// </summary>
        static Image Clicked_Body = Properties.Resources.clicked_crumb_body;
        /// <summary>
        /// The clicked right edge
        /// </summary>
        static Image Clicked_Right_Edge = Properties.Resources.clicked_crumb_right_end;
        /// <summary>
        /// The clicked right triangle
        /// </summary>
        static Image Clicked_Right_Triangle = Properties.Resources.clicked_crumb_right_point;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when [crumb click].
        /// </summary>
        public event EventHandler<CrumbClickEventArgs> CrumbClick;

        /// <summary>
        /// Handles the <see cref="E:CrumbClick" /> event.
        /// </summary>
        /// <param name="e">The <see cref="CrumbClickEventArgs"/> instance containing the event data.</param>
        protected void OnCrumbClick(CrumbClickEventArgs e)
        {
            if (CrumbClick != null) { CrumbClick.Invoke(this, e); }
        }
        #endregion

        #region Params
        /// <summary>
        /// Gets the default size of the control.
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize
        {
            get
            {
                var w = (c == null ? (this.Controls.Count == 0 ? 3 : 15) : Math.Max(15, c.Width)) + (this.CheckBox ? 24 : 0) + (this.img != null ? img.Width : 0) + (!string.IsNullOrEmpty(this.Text) ? TextRenderer.MeasureText(this.Text, this.Font).Width : 0) + (this.Parent is ZeroitBreadCrumb ? 13 : 0);
                return new Size(this.Controls.Count > 0 ? w : Math.Max(w, this.Width), 24);
            }
        }
        #endregion

        #region Nesting
        /// <summary>
        /// fs the parent.
        /// </summary>
        /// <returns>Control.</returns>
        private Control fParent()
        {
            var c = this.Parent;
            while (c != null)
                if (!(c is ZeroitBreadCrumb))
                    return c;
                else
                    c = c.Parent;
            return null;
        }
        /// <summary>
        /// cs the parent.
        /// </summary>
        /// <param name="cr">The cr.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool cParent(ZeroitBreadCrumb cr)
        {
            try
            {
                var c = cr.Parent as ZeroitBreadCrumb;
                while (c != null)
                    if (c == this)
                        return true;
                    else
                        c = c.Parent as ZeroitBreadCrumb;
            }
            catch { }
            return false;
        }
        /// <summary>
        /// cs the child.
        /// </summary>
        /// <param name="cr">The cr.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool cChild(ZeroitBreadCrumb cr)
        {
            try
            {
                var c = cr.Child;
                while (c != null)
                    if (c == this)
                        return true;
                    else
                        c = c.Child;
            }
            catch { }
            return false;
        }
        /// <summary>
        /// Gets at index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>ZeroitBreadCrumb.</returns>
        private ZeroitBreadCrumb GetAtIndex(int index)
        {
            if (index < 0) { return null; }

            var i = this.Index;

            if (i == index) { return this; }
            else if (i < index)
            {
                this.Child.GetAtIndex(index);
            }
            else
            {
                (this.Parent as ZeroitBreadCrumb).GetAtIndex(index);
            }

            return null;
        }

        /// <summary>
        /// The c
        /// </summary>
        ZeroitBreadCrumb c = null;
        /// <summary>
        /// Gets or sets the child.
        /// </summary>
        /// <value>The child.</value>
        public ZeroitBreadCrumb Child
        {
            get
            {
                return c;
            }
            set
            {
                if (value != this && c != value && !cParent(value) && !cChild(value))
                {
                    if (c != null)
                    {
                        c.Paint -= childPaint;
                        c.Resize -= childResize;
                        c.CrumbClick -= childClick;

                        c.Parent = fParent();
                    }

                    c = value;

                    if (c != null)
                    {
                        this.Controls.Add(c);
                        c.Dock = DockStyle.Right;

                        c.Paint += childPaint;
                        c.Resize += childResize;
                        c.CrumbClick += childClick;

                        c.Refresh();
                    }

                    Refresh();
                }
            }
        }

        /// <summary>
        /// The child click
        /// </summary>
        EventHandler<CrumbClickEventArgs> childClick = new EventHandler<CrumbClickEventArgs>(c_Click);
        /// <summary>
        /// Handles the Click event of the c control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CrumbClickEventArgs"/> instance containing the event data.</param>
        static void c_Click(object sender, CrumbClickEventArgs e)
        {
            if ((sender as ZeroitBreadCrumb).Parent is ZeroitBreadCrumb) { ((sender as ZeroitBreadCrumb).Parent as ZeroitBreadCrumb).OnCrumbClick(e); }
        }

        /// <summary>
        /// The child resize
        /// </summary>
        EventHandler childResize = new EventHandler(c_Resize);
        /// <summary>
        /// Handles the Resize event of the c control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        static void c_Resize(object sender, EventArgs e)
        {
            (sender as Control).Parent.Refresh();
        }

        /// <summary>
        /// The child paint
        /// </summary>
        PaintEventHandler childPaint = new PaintEventHandler(c_Paint);
        /// <summary>
        /// Handles the Paint event of the c control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        static void c_Paint(object sender, PaintEventArgs e)
        {
            var c = sender as ZeroitBreadCrumb;

            if (c.Parent != null && c.Parent is ZeroitBreadCrumb)
            {
                var p = c.Parent as ZeroitBreadCrumb;
                dc(e, Color.Black, -25f, width: 38f, hovered: p.hovered, clicked: p.clicked, chk: p.chk, chkbox: p.chkbox);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// The CHK
        /// </summary>
        bool chk = false;
        /// <summary>
        /// Gets or sets a value indicating whether the control is checked or not.
        /// </summary>
        /// <value>The checked.</value>
        [DefaultValue(false)]
        [Description("Indicates whether the control is checked or not.")]
        public Boolean Checked
        {
            get
            {
                return chk;
            }
            set
            {
                if (!nocc)
                {
                    nocc = true;

                    ZeroitBreadCrumb cr = this.Child;
                    while (cr != null) { cr.Checked = false; cr = cr.Child; }
                    cr = this.Parent as ZeroitBreadCrumb;
                    while (cr != null && cr is ZeroitBreadCrumb) { cr.Checked = false; cr = cr.Parent as ZeroitBreadCrumb; }

                    nocc = false;
                }
                chk = value;

                Refresh();
            }
        }

        /// <summary>
        /// The CHKCLK
        /// </summary>
        bool chkclk = false;
        /// <summary>
        /// Gets or sets a value determining if the control's Checked state should change when it is clicked.
        /// </summary>
        /// <value>The check on click.</value>
        [DefaultValue(false)]
        [Description("Determines whether the control's Checked state should change when it is clicked.")]
        public Boolean CheckOnClick
        {
            get
            {
                return chkclk;
            }
            set
            {
                chkclk = value;

                Refresh();
            }
        }

        /// <summary>
        /// The chkbox
        /// </summary>
        bool chkbox = false;
        /// <summary>
        /// Gets or sets a value indicating whether a checkbox should be displayed on the control to represent it's checked state.
        /// </summary>
        /// <value>The CheckBox.</value>
        [DefaultValue(false)]
        [Description("Indicates whether a checkbox should be displayed on the control to represent it's checked state.")]
        public Boolean CheckBox
        {
            get
            {
                return chkbox;
            }
            set
            {
                chkbox = value;

                Refresh();
            }
        }

        /// <summary>
        /// The img
        /// </summary>
        Image img = null;
        /// <summary>
        /// Gets or sets the image displayed on the control.
        /// </summary>
        /// <value>The image.</value>
        [DefaultValue(null)]
        [Description("The image displayed on the control.")]
        public Image Image
        {
            get
            {
                return img;
            }
            set
            {
                img = value;

                Refresh();
            }
        }

        /// <summary>
        /// The imga
        /// </summary>
        ContentAlignment imga = ContentAlignment.MiddleLeft;
        /// <summary>
        /// Gets or sets a value indicating the alignment of the image on the control.
        /// </summary>
        /// <value>The image align.</value>
        [DefaultValue(ContentAlignment.MiddleLeft)]
        [Description("Indicates the alignment of the image on the control.")]
        public ContentAlignment ImageAlign
        {
            get
            {
                return imga;
            }
            set
            {
                imga = value;

                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the text displayed on the control.
        /// </summary>
        /// <value>The text.</value>
        [DefaultValue("")]
        [Description("The text displayed on the control.")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;

                Refresh();
            }
        }

        /// <summary>
        /// The txta
        /// </summary>
        ContentAlignment txta = ContentAlignment.MiddleCenter;
        /// <summary>
        /// Gets or sets a value indicating the alignment of the text on the control.
        /// </summary>
        /// <value>The text align.</value>
        [DefaultValue(ContentAlignment.MiddleCenter)]
        [Description("The alignment of the text on the control.")]
        public ContentAlignment TextAlign
        {
            get
            {
                return txta;
            }
            set
            {
                txta = value;

                Refresh();
            }
        }

        /// <summary>
        /// The tai
        /// </summary>
        Boolean tai = false;
        /// <summary>
        /// Gets or sets a value determining whether the image and the text will be linked and will obey to the text's alignment.
        /// </summary>
        /// <value>The text after image.</value>
        [DefaultValue(false)]
        [Description("Determines whether the image will be before the text and will obey to the text's alignment.")]
        public Boolean TextAfterImage
        {
            get
            {
                return tai;
            }
            set
            {
                tai = value;

                Refresh();
            }
        }

        /// <summary>
        /// Determines whether the size is not a default value.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeSize()
        {
            return this.Size != this.DefaultSize;
        }
        /// <summary>
        /// Resets the size to the default value.
        /// </summary>
        public void ResetSize()
        {
            this.Size = this.DefaultSize;
        }

        /// <summary>
        /// Gets the index of this crumb in the nesting.
        /// <para>0 means first!</para>
        /// </summary>
        /// <value>The index.</value>
        [Browsable(false)]
        public int Index
        {
            get
            {
                int i = 0;

                var c = this.Parent as ZeroitBreadCrumb;
                while (c != null) { i++; c = c.Parent as ZeroitBreadCrumb; }

                return i;
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBreadCrumb" /> class.
        /// </summary>
        public ZeroitBreadCrumb()
        {
            this.ResizeRedraw = this.DoubleBuffered = true;
        }

        /// <summary>
        /// Forces the control to invalidate its client area and immediately redraw itself and any child controls.
        /// </summary>
        public override void Refresh()
        {
            this.Size = this.DefaultSize;

            base.Refresh();
        }

        #region Behavior
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.Size != this.DefaultSize) { this.Size = this.DefaultSize; }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.DockChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnDockChanged(EventArgs e)
        {
            if (this.Parent is ZeroitBreadCrumb)
            {
                if (this.Dock != DockStyle.Right) { this.Dock = DockStyle.Right; }
            }
            else
            {
                base.OnDockChanged(e);
            }
        }

        /// <summary>
        /// The nocc
        /// </summary>
        static Boolean nocc = false;

        /// <summary>
        /// The hovered
        /// </summary>
        bool hovered = false;

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            hovered = true;
            Refresh();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            hovered = false;
            clicked = false;
            Refresh();
        }

        /// <summary>
        /// The clicked
        /// </summary>
        bool clicked = false;

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            clicked = true;
            Refresh();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            clicked = false;

            var ea = new CrumbClickEventArgs(Index, this.chk, this.chkclk, this);

            OnCrumbClick(ea);

            if (chkclk)
            {
                Checked = !Checked;
            }
            else
            {
                Checked = ea.CheckedAfter;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (AllowTransparency)
            {
                MakeTransparent(this, e.Graphics);
            }

            ZeroitBreadCrumb.dc(e, this.ForeColor, 0, Text, this.img, this.clicked, this.hovered, this.chk, this.chkbox, this.c == null ? this.Width : (this.Width - this.c.Width), this.Font, this.tai, this.txta, this.imga, this.Parent is ZeroitBreadCrumb, this.Controls.Count > 0);
            
            
        }
        #endregion

        #region Drawing
        /// <summary>
        /// Dcs the specified e.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="foreColor">Color of the fore.</param>
        /// <param name="x">The x.</param>
        /// <param name="text">The text.</param>
        /// <param name="img">The img.</param>
        /// <param name="clicked">if set to <c>true</c> [clicked].</param>
        /// <param name="hovered">if set to <c>true</c> [hovered].</param>
        /// <param name="chk">if set to <c>true</c> [CHK].</param>
        /// <param name="chkbox">if set to <c>true</c> [chkbox].</param>
        /// <param name="width">The width.</param>
        /// <param name="font">The font.</param>
        /// <param name="tai">if set to <c>true</c> [tai].</param>
        /// <param name="ta">The ta.</param>
        /// <param name="ia">The ia.</param>
        /// <param name="pt">if set to <c>true</c> [pt].</param>
        /// <param name="ch">if set to <c>true</c> [ch].</param>
        /// <returns>System.Single.</returns>
        public static float dc(PaintEventArgs e, Color foreColor, float x = 0f, string text = "", Image img = null, bool clicked = false, bool hovered = false, bool chk = false, bool chkbox = false, float width = 0f, Font font = null, bool tai = true, ContentAlignment ta = ContentAlignment.MiddleCenter, ContentAlignment ia = ContentAlignment.MiddleLeft, bool pt = false, bool ch = true)
        {
            if (font == null) { font = SystemFonts.MessageBoxFont; }
            width = Math.Max((ch ? 15 : 3) + (chkbox ? 24 : 0) + (img != null ? img.Width : 0) + (!string.IsNullOrEmpty(text) ? TextRenderer.MeasureText(text, font).Width : 0) + (pt ? 13 : 0), width);

            if (clicked)
            {
                e.Graphics.DrawImage(ZeroitBreadCrumb.Clicked_Left_Edge, x, 0);
                for (int i = (int)x + ZeroitBreadCrumb.Clicked_Left_Edge.Width; i <= x + width - (ch ? ZeroitBreadCrumb.Clicked_Right_Triangle : ZeroitBreadCrumb.Clicked_Right_Edge).Width; i++)
                    e.Graphics.DrawImage(ZeroitBreadCrumb.Clicked_Body, i, 0);
                e.Graphics.DrawImage(ch ? ZeroitBreadCrumb.Clicked_Right_Triangle : ZeroitBreadCrumb.Clicked_Right_Edge, x + width - (ch ? ZeroitBreadCrumb.Clicked_Right_Triangle : ZeroitBreadCrumb.Clicked_Right_Edge).Width, 0);
            }
            else if (hovered)
            {
                e.Graphics.DrawImage(ZeroitBreadCrumb.Hovered_Left_Edge, x, 0);
                for (int i = (int)x + ZeroitBreadCrumb.Hovered_Left_Edge.Width; i <= x + width - (ch ? ZeroitBreadCrumb.Hovered_Right_Triangle : ZeroitBreadCrumb.Hovered_Right_Edge).Width; i++)
                    e.Graphics.DrawImage(ZeroitBreadCrumb.Hovered_Body, i, 0);
                e.Graphics.DrawImage((ch ? ZeroitBreadCrumb.Hovered_Right_Triangle : ZeroitBreadCrumb.Hovered_Right_Edge), x + width - (ch ? ZeroitBreadCrumb.Hovered_Right_Triangle : ZeroitBreadCrumb.Hovered_Right_Edge).Width, 0);
            }
            else if (chk && !chkbox)
            {
                e.Graphics.DrawImage(ZeroitBreadCrumb.Selected_Left_Edge, x, 0);
                for (int i = (int)x + ZeroitBreadCrumb.Selected_Left_Edge.Width; i <= x + width - (ch ? ZeroitBreadCrumb.Selected_Right_Triangle : ZeroitBreadCrumb.Selected_Right_Edge).Width; i++)
                    e.Graphics.DrawImage(ZeroitBreadCrumb.Selected_Body, i, 0);
                e.Graphics.DrawImage((ch ? ZeroitBreadCrumb.Selected_Right_Triangle : ZeroitBreadCrumb.Selected_Right_Edge), x + width - (ch ? ZeroitBreadCrumb.Selected_Right_Triangle : ZeroitBreadCrumb.Selected_Right_Edge).Width, 0);
            }
            else
            {
                e.Graphics.DrawImage(ZeroitBreadCrumb.Left_Edge, x, 0);
                for (int i = (int)x + ZeroitBreadCrumb.Left_Edge.Width; i <= x + width - (ch ? ZeroitBreadCrumb.Right_Triangle : ZeroitBreadCrumb.Right_Edge).Width; i++)
                    e.Graphics.DrawImage(ZeroitBreadCrumb.Body, i, 0);
                e.Graphics.DrawImage((ch ? ZeroitBreadCrumb.Right_Triangle : ZeroitBreadCrumb.Right_Edge), x + width - (ch ? ZeroitBreadCrumb.Right_Triangle : ZeroitBreadCrumb.Right_Edge).Width, 0);
            }

            if (chkbox)
            {
                var st = chk ? (clicked ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedPressed : System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal) : (clicked ? System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedPressed : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);

                var sz = CheckBoxRenderer.GetGlyphSize(e.Graphics, st);

                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point((int)(x + (pt ? 13 : 0) + (24 - sz.Height) / 2), (24 - sz.Height) / 2), st);
            }

            if (tai)
            {
                dit(e, foreColor, x + (pt ? 13 : 0), ta, text, font, chkbox, width, ia, img);
            }
            else
            {
                di(e, x, img, ia, chkbox, width);
                dt(e, foreColor, x + (pt ? 13 : 0), ta, text, font, chkbox, width);
            }

            return width;
        }

        /// <summary>
        /// Dts the specified e.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="foreColor">Color of the fore.</param>
        /// <param name="x">The x.</param>
        /// <param name="txta">The txta.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="chkbox">if set to <c>true</c> [chkbox].</param>
        /// <param name="width">The width.</param>
        private static void dt(PaintEventArgs e, Color foreColor, float x = 0f, ContentAlignment txta = ContentAlignment.MiddleCenter, string text = "", Font font = null, bool chkbox = false, float width = 0f)
        {
            if (!string.IsNullOrEmpty(text))
            {
                PointF p = new PointF();

                var s = e.Graphics.MeasureString(text, font);

                switch (txta)
                {
                    case ContentAlignment.BottomCenter:
                        p = new PointF(x + ((chkbox ? (width - 24) : width) - 15 - s.Width) / 2, 21 - s.Height);
                        break;
                    case ContentAlignment.BottomLeft:
                        p = new PointF(x + (chkbox ? 24 : 3), 21 - s.Height);
                        break;
                    case ContentAlignment.BottomRight:
                        p = new PointF(x + ((chkbox ? (width - 24) : width) - 15) - s.Width, 21 - s.Height);
                        break;

                    case ContentAlignment.MiddleCenter:
                        p = new PointF(x + ((chkbox ? (width - 24) : width) - 15 - s.Width) / 2, (24 - s.Height) / 2);
                        break;
                    case ContentAlignment.MiddleLeft:
                        p = new PointF(x + (chkbox ? 24 : 3), (24 - s.Height) / 2);
                        break;
                    case ContentAlignment.MiddleRight:
                        p = new PointF(x + ((chkbox ? (width - 24) : width) - 15) - s.Width, (24 - s.Height) / 2);
                        break;

                    case ContentAlignment.TopCenter:
                        p = new PointF(x + ((chkbox ? (width - 24) : width) - 15 - s.Width) / 2, 3);
                        break;
                    case ContentAlignment.TopLeft:
                        p = new PointF(x + (chkbox ? 24 : 3), 3);
                        break;
                    case ContentAlignment.TopRight:
                        p = new PointF(x + ((chkbox ? (width - 24) : width) - 15) - s.Width, 3);
                        break;
                }

                using (Brush b = new SolidBrush(foreColor))
                    e.Graphics.DrawString(text, font, b, p);
            }
        }

        /// <summary>
        /// Dis the specified e.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="x">The x.</param>
        /// <param name="img">The img.</param>
        /// <param name="imga">The imga.</param>
        /// <param name="chkbox">if set to <c>true</c> [chkbox].</param>
        /// <param name="width">The width.</param>
        private static void di(PaintEventArgs e, float x = 0f, Image img = null, ContentAlignment imga = ContentAlignment.MiddleLeft, bool chkbox = false, float width = 0f)
        {
            if (img != null)
            {
                PointF p = new Point();

                switch (imga)
                {
                    case ContentAlignment.BottomCenter:
                        p = new PointF(x + ((chkbox ? (width - 24) : width) - 15 - img.Width) / 2, 21 - img.Height);
                        break;
                    case ContentAlignment.BottomLeft:
                        p = new PointF(x + (chkbox ? 24 : 3), 21 - img.Height);
                        break;
                    case ContentAlignment.BottomRight:
                        p = new PointF(x + ((chkbox ? (width - 24) : width) - 15) - img.Width, 21 - img.Height);
                        break;

                    case ContentAlignment.MiddleCenter:
                        p = new PointF(x + ((chkbox ? (width - 24) : width) - 15 - img.Width) / 2, (24 - img.Height) / 2);
                        break;
                    case ContentAlignment.MiddleLeft:
                        p = new PointF(x + (chkbox ? 24 : 3), (24 - img.Height) / 2);
                        break;
                    case ContentAlignment.MiddleRight:
                        p = new PointF(x + ((chkbox ? (width - 24) : width) - 15) - img.Width, (24 - img.Height) / 2);
                        break;

                    case ContentAlignment.TopCenter:
                        p = new PointF(x + ((chkbox ? (width - 24) : width) - 15 - img.Width) / 2, 3);
                        break;
                    case ContentAlignment.TopLeft:
                        p = new PointF(x + (chkbox ? 24 : 3), 3);
                        break;
                    case ContentAlignment.TopRight:
                        p = new PointF(x + ((chkbox ? (width - 24) : width) - 15) - img.Width, 3);
                        break;
                }

                e.Graphics.DrawImage(img, p);
            }
        }

        /// <summary>
        /// Dits the specified e.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="foreColor">Color of the fore.</param>
        /// <param name="x">The x.</param>
        /// <param name="txta">The txta.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="chkbox">if set to <c>true</c> [chkbox].</param>
        /// <param name="width">The width.</param>
        /// <param name="imga">The imga.</param>
        /// <param name="img">The img.</param>
        private static void dit(PaintEventArgs e, Color foreColor, float x = 0f, ContentAlignment txta = ContentAlignment.MiddleCenter, string text = "", Font font = null, bool chkbox = false, float width = 0f, ContentAlignment imga = ContentAlignment.MiddleLeft, Image img = null)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (img != null)
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        float w = 0, h = 0, ht = 0;

                        var s = e.Graphics.MeasureString(text, font);

                        switch (txta)
                        {
                            case ContentAlignment.BottomCenter:
                                w = ((chkbox ? (width - 24) : width) - 15 - s.Width - img.Width) / 2; h = 21 - img.Height; ht = 21 - s.Height;
                                break;
                            case ContentAlignment.BottomLeft:
                                w = chkbox ? 24 : 3; h = 21 - img.Height; ht = 21 - s.Height;
                                break;
                            case ContentAlignment.BottomRight:
                                w = ((chkbox ? (width - 24) : width) - 15) - s.Width - img.Width; h = 21 - img.Height; ht = 21 - s.Height;
                                break;

                            case ContentAlignment.MiddleCenter:
                                w = ((chkbox ? (width - 24) : width) - 15 - s.Width - img.Width) / 2; h = (24 - img.Height) / 2; ht = (24 - s.Height) / 2;
                                break;
                            case ContentAlignment.MiddleLeft:
                                w = chkbox ? 24 : 3; h = (24 - img.Height) / 2; ht = (24 - s.Height) / 2;
                                break;
                            case ContentAlignment.MiddleRight:
                                w = ((chkbox ? (width - 24) : width) - 15) - s.Width - img.Width; h = (24 - img.Height) / 2; ht = (24 - s.Height) / 2;
                                break;

                            case ContentAlignment.TopCenter:
                                w = ((chkbox ? (width - 24) : width) - 15 - s.Width - img.Width) / 2; h = ht = 3;
                                break;
                            case ContentAlignment.TopLeft:
                                w = chkbox ? 24 : 3; h = ht = 3;
                                break;
                            case ContentAlignment.TopRight:
                                w = ((chkbox ? (width - 24) : width) - 15) - s.Width - img.Width; h = ht = 3;
                                break;
                        }

                        w += x;

                        e.Graphics.DrawImage(img, w, h);

                        using (Brush b = new SolidBrush(foreColor))
                            e.Graphics.DrawString(text, font, b, w + img.Width, ht);
                    }
                }
                else
                {
                    dt(e, foreColor, x, txta, text, font, chkbox, width);
                }
            }
            else
            {
                di(e, x, img, imga, chkbox, width);
            }
        }
        #endregion





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



    }


    #endregion

}
