// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-27-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="BaseWControl.cs" company="Zeroit Dev Technologies">
//    This program is for creating various controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Zeroit.Framework.MiscControls.Digitals.Helpers.Utils;
using Zeroit.Framework.MiscControls.Digitals.Helpers.Drawable;

namespace Zeroit.Framework.MiscControls.Digitals.Helpers
{
    /// <summary>
    /// Enum ControlShape
    /// </summary>
    public enum ControlShape
    {
        /// <summary>
        /// The rect
        /// </summary>
        Rect,
        /// <summary>
        /// The rounded rect
        /// </summary>
        RoundedRect,
        /// <summary>
        /// The circular
        /// </summary>
        Circular
    }

    /// <summary>
    /// Class BaseWControl.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false)]
    public partial class BaseWControl : UserControl
    {
        /// <summary>
        /// Always transparent
        /// </summary>
        /// <value>The color of the back.</value>
        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return Color.Transparent;
            }
            set { }
        }

        /// <summary>
        /// Gets the gradient color trans.
        /// </summary>
        /// <value>The gradient color trans.</value>
        private Color GradientColorTrans
        {
            get
            {
                return Color.FromArgb(0xcc, GradientColor);
            }
        }

        /// <summary>
        /// Gets the color of the top half.
        /// </summary>
        /// <value>The color of the top half.</value>
        private Color TopHalfColor
        {
            get
            {
                return Color.FromArgb(0x10, GlossColor);
            }
        }

        #region Public Properties

        /// <summary>
        /// The shape of the control
        /// </summary>
        /// <value>The shape.</value>
        [Description("The shape of the control")]
        [DefaultValue(typeof(ControlShape), "RoundedRect")]
        [Category("Appearance")]
        public virtual ControlShape Shape
        {
            get { return m_shape; }
            set
            {
                m_shape = value;
                this.RecalculatePaths();
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// The background color of the control
        /// </summary>
        /// <value>The color of the background.</value>
        [Description("The background color of the control")]
        [DefaultValue(typeof(Color), "DimGray")]
        [Category("Appearance")]
        public virtual Color BackgroundColor
        {
            get { return m_bgColor; }
            set
            {
                m_bgColor = value;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// The color of the control's gloss effect
        /// </summary>
        /// <value>The color of the gloss.</value>
        [Description("The color of the control\'s gloss effect")]
        [DefaultValue(typeof(Color), "White")]
        [Category("Appearance")]
        public virtual Color GlossColor
        {
            get { return m_glossColor; }
            set
            {
                m_glossColor = value;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// The color of the control's gradient effect
        /// </summary>
        /// <value>The color of the gradient.</value>
        [Description("The color of the control\'s gradient effect")]
        [DefaultValue(typeof(Color), "White")]
        [Category("Appearance")]
        public virtual Color GradientColor
        {
            get { return m_gradColor; }
            set
            {
                m_gradColor = value;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// Whether or not to show the control's gloss effect
        /// </summary>
        /// <value><c>true</c> if [show gloss]; otherwise, <c>false</c>.</value>
        [Description("Whether or not to show the control\'s gloss effect")]
        [DefaultValue(true)]
        [Category("Appearance")]
        public virtual bool ShowGloss
        {
            get { return m_bShowGloss; }
            set
            {
                m_bShowGloss = value;
                this.Invalidate(true);
            }
        }

        /// <summary>
        /// Whether or not to show the control's gradient effect
        /// </summary>
        /// <value><c>true</c> if [show gradient]; otherwise, <c>false</c>.</value>
        [Description("Whether or not to show the control\'s gradient effect")]
        [DefaultValue(true)]
        [Category("Appearance")]
        public virtual bool ShowGradient
        {
            get { return m_bShowGrad; }
            set
            {
                m_bShowGrad = value;
                this.Invalidate(true);
            }
        }

        #endregion

        //for accessors
        /// <summary>
        /// The m bg color
        /// </summary>
        private Color m_bgColor = Color.DimGray;
        /// <summary>
        /// The m gloss color
        /// </summary>
        private Color m_glossColor = Color.White;
        /// <summary>
        /// The m grad color
        /// </summary>
        private Color m_gradColor = Color.White;
        /// <summary>
        /// The m shape
        /// </summary>
        private ControlShape m_shape = ControlShape.RoundedRect;
        /// <summary>
        /// The m b show gloss
        /// </summary>
        private bool m_bShowGloss = true;
        /// <summary>
        /// The m b show grad
        /// </summary>
        private bool m_bShowGrad = true;

        //internals
        /// <summary>
        /// The m bg path
        /// </summary>
        private GraphicsPath m_bgPath;
        /// <summary>
        /// The m gloss path
        /// </summary>
        private GraphicsPath m_glossPath;
        /// <summary>
        /// The m b handle gloss
        /// </summary>
        private bool m_bHandleGloss = false;

        /// <summary>
        /// Prevents a default instance of the <see cref="BaseWControl"/> class from being created.
        /// </summary>
        private BaseWControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.UserPaint, true);

            Shape = ControlShape.RoundedRect;
            BackgroundColor = Color.DimGray;
            GradientColor = Color.White;
            GlossColor = Color.White;
            ShowGloss = true;
            ShowGradient = true;

            m_bHandleGloss = true;

            RecalculatePaths();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseWControl"/> class.
        /// </summary>
        /// <param name="bGlossDrawHandledByBase">if set to <c>true</c> [b gloss draw handled by base].</param>
        public BaseWControl(bool bGlossDrawHandledByBase)
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.UserPaint, true);

            Shape = ControlShape.RoundedRect;
            BackgroundColor = Color.DimGray;
            GradientColor = Color.White;
            GlossColor = Color.White;
            ShowGloss = true;
            ShowGradient = true;

            m_bHandleGloss = bGlossDrawHandledByBase;

            RecalculatePaths();
        }

        /// <summary>
        /// Invalidates the specified control.
        /// </summary>
        /// <param name="control">The control.</param>
        protected void Invalidate(IDrawable control)
        {
            Invalidate(control.GetRedrawRegion());
        }

        /// <summary>
        /// Recalculates the paths.
        /// </summary>
        private void RecalculatePaths()
        {
            DisposePaths();
            m_bgPath = GraphicsHelper.GetGraphicsPath(ClientRectangle, Shape);
            m_glossPath = GraphicsHelper.Get3DShinePath(ClientRectangle, Shape);
        }

        /// <summary>
        /// Called when [paint gloss].
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void OnPaintGloss(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (ShowGloss)
            {
                using (Brush shineBrush = new SolidBrush(TopHalfColor))
                {
                    g.FillPath(shineBrush, m_glossPath);
                }
            }
        }

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //dont draw the transparent bg in the region we are going to paint anyways
            GraphicsState state = e.Graphics.Save();

            if (m_bgPath != null)
            {
                e.Graphics.Clip.Exclude(m_bgPath);
            }
            base.OnPaintBackground(e);
            e.Graphics.Restore(state);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Brush bgBrush = new SolidBrush(BackgroundColor))
            using (Brush gradBrush = GraphicsHelper.GetGradBrush(ClientRectangle, Shape, GradientColorTrans))
            {
                if (m_bgPath != null)
                {
                    e.Graphics.FillPath(bgBrush, m_bgPath);

                    if (ShowGradient)
                    {
                        e.Graphics.FillPath(gradBrush, m_bgPath);
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (m_bHandleGloss)
            {
                OnPaintGloss(e.Graphics);
            }

            base.OnPaint(e);
        }

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            RecalculatePaths();
            base.OnResize(e);
        }

        #region Disposing

        /// <summary>
        /// Disposes the paths.
        /// </summary>
        private void DisposePaths()
        {
            if (m_bgPath != null)
            {
                m_bgPath.Dispose();
                m_bgPath = null;
            }
            if (m_glossPath != null)
            {
                m_glossPath.Dispose();
                m_glossPath = null;
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                DisposePaths();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}
