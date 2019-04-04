// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="LBIndustrialCtrlBase.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.MiscControls
{

    #region LBIndustrialCtrlBase
    /// <summary>
    /// Base class for the IndustrialCtrls
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class ZeroitLBIndustrialCtrlBase : UserControl
    {
        #region (* Constructor *)
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLBIndustrialCtrlBase"/> class.
        /// </summary>
        public ZeroitLBIndustrialCtrlBase()
        {
            InitializeComponent();

            // Set the styles for drawing
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);

            // Transparent background
            this.BackColor = Color.Transparent;

            // Creation of the default renderer
            this._defaultRenderer = CreateDefaultRenderer();
            if (this._defaultRenderer != null)
                this._defaultRenderer.Control = this;
        }
        #endregion

        #region (* Properties *)
        /// <summary>
        /// Default renderer of the control
        /// </summary>
        private ILBRenderer _defaultRenderer = null;
        /// <summary>
        /// Gets the default renderer.
        /// </summary>
        /// <value>The default renderer.</value>
        [Browsable(false)]
        public ILBRenderer DefaultRenderer
        {
            get { return this._defaultRenderer; }
        }

        /// <summary>
        /// User defined renderer
        /// </summary>
        private ILBRenderer _renderer = null;
        /// <summary>
        /// Gets or sets the renderer.
        /// </summary>
        /// <value>The renderer.</value>
        [Browsable(false)]
        public ILBRenderer Renderer
        {
            set
            {
                // set the renderer
                this._renderer = value;
                if (this._renderer != null)
                {
                    // Set the control tu the renderer
                    this._renderer.Control = this;
                    // Update the renderer
                    this._renderer.Update();
                }

                // Redraw the renderer
                Invalidate();
            }
            get { return this._renderer; }
        }
        #endregion

        #region (* Events delegates *)
        /// <summary>
        /// Font change event
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnFontChanged(EventArgs e)
        {
            // Calculate dimensions
            this.CalculateDimensions();
        }
        /// <summary>
        /// SizeChanged event
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnSizeChanged(EventArgs e)
        {
            // Default
            base.OnSizeChanged(e);
            // Calculate al the data for
            // drawing the control
            this.CalculateDimensions();
            // Redraw
            this.Invalidate();
        }

        /// <summary>
        /// Resize event
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Calculate al the data for
            // drawing the control
            this.CalculateDimensions();
            // Redraw
            this.Invalidate();
        }
        /// <summary>
        /// Paint event
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnPaint(PaintEventArgs e)
        {
            if (AllowTransparency)
            {
                MakeTransparent(this, e.Graphics);
            }

            // Rectangle of the control
            RectangleF _rc = new RectangleF(0, 0, this.Width, this.Height);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Call the default renderer if the user
            // rendere is null
            if (this.Renderer == null)
            {
                this.DefaultRenderer.Draw(e.Graphics);
                return;
            }

            // Draw with the user renderer
            this.Renderer.Draw(e.Graphics);
        }
        #endregion

        #region (* Virtual method *)
        /// <summary>
        /// Call from the constructor to create the default renderer
        /// </summary>
        /// <returns>ILBRenderer.</returns>
        protected virtual ILBRenderer CreateDefaultRenderer()
        {
            return new ZeroitLBRendererBase();
        }

        /// <summary>
        /// Calculate the dimensions of the control
        /// </summary>
        protected virtual void CalculateDimensions()
        {
            this.DefaultRenderer.Update();

            // Update the data in the renderer
            if (this.Renderer != null)
                this.Renderer.Update();

            this.Invalidate();
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

    /// <summary>
    /// Base class for the controls renderer
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ILBRenderer" />
    public class ZeroitLBRendererBase : ILBRenderer
    {
        #region (* Constructor *)
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLBRendererBase"/> class.
        /// </summary>
        public ZeroitLBRendererBase()
        {
        }
        #endregion

        #region (* IDisposable implementation *)
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.OnDispose();
        }
        #endregion

        #region (* Properties *)
        /// <summary>
        /// Associated control
        /// </summary>
        protected object _control = null;
        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>The control.</value>
        public object Control
        {
            set { this._control = value; }
            get { return this._control; }
        }
        #endregion

        #region (* Virtual methods *)
        /// <summary>
        /// Dispose the resource of the object
        /// </summary>
        public virtual void OnDispose()
        {
        }

        /// <summary>
        /// Update the renderer
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool Update()
        {
            return false;
        }

        /// <summary>
        /// Drawing method
        /// </summary>
        /// <param name="Gr">The gr.</param>
        /// <exception cref="System.ArgumentNullException">Gr</exception>
        /// <exception cref="System.NullReferenceException">Associated control is not valid</exception>
        public virtual void Draw(Graphics Gr)
        {
            // Check the graphics
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            // Check the control
            Control ctrl = this.Control as Control;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            // Default drawing
            Rectangle rc = ctrl.Bounds;

            Gr.FillRectangle(Brushes.White, ctrl.Bounds);
            Gr.DrawRectangle(Pens.Black, ctrl.Bounds);

            Gr.DrawLine(Pens.Red,
                          ctrl.Left,
                          ctrl.Top,
                          ctrl.Right,
                          ctrl.Bottom);

            Gr.DrawLine(Pens.Red,
                          ctrl.Right,
                          ctrl.Top,
                          ctrl.Left,
                          ctrl.Bottom);
        }
        #endregion
    }
    #endregion

    #region Designer Generated Code

    partial class ZeroitLBIndustrialCtrlBase
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            // Dispose the renderers
            this.DefaultRenderer.Dispose();
            if (this.Renderer != null)
                this.Renderer.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion
    }

    #endregion

}
