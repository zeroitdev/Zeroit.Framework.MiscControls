// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="FATabStripItem.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// A class collection for rendering a tab strip item.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [Designer(typeof(ZeroitFameyeTabStripItemDesigner))]
    [ToolboxItem(false)]
    [DefaultProperty("Title")]
    [DefaultEvent("Changed")]
    public class ZeroitFameyeTabStripItem : Panel
    {
        #region Events

        /// <summary>
        /// Occurs when [changed].
        /// </summary>
        public event EventHandler Changed;

        #endregion

        #region Fields

        //private DrawItemState drawState = DrawItemState.None;
        /// <summary>
        /// The strip rect
        /// </summary>
        private RectangleF stripRect = Rectangle.Empty;
        /// <summary>
        /// The image
        /// </summary>
        private Image image = null;
        /// <summary>
        /// The can close
        /// </summary>
        private bool canClose = true;
        /// <summary>
        /// The selected
        /// </summary>
        private bool selected = false;
        /// <summary>
        /// The visible
        /// </summary>
        private bool visible = true;
        /// <summary>
        /// The is drawn
        /// </summary>
        private bool isDrawn = false;
        /// <summary>
        /// The title
        /// </summary>
        private string title = string.Empty;

        #endregion

        #region Props        
        /// <summary>
        /// Gets or sets the height and width of the control.
        /// </summary>
        /// <value>The size.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control and all its child controls are displayed.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public new bool Visible
        {
            get { return visible; }
            set
            {
                if (visible == value)
                    return;

                visible = value;
                OnChanged();
            }
        }

        /// <summary>
        /// Gets or sets the strip rectangle.
        /// </summary>
        /// <value>The strip rect.</value>
        internal RectangleF StripRect
        {
            get { return stripRect; }
            set { stripRect = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this control is drawn.
        /// </summary>
        /// <value><c>true</c> if this instance is drawn; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsDrawn
        {
            get { return isDrawn; }
            set
            {
                if (isDrawn == value)
                    return;

                isDrawn = value;
            }
        }

        /// <summary>
        /// Image of <see cref="FATabStripItem" /> which will be displayed
        /// on menu items.
        /// </summary>
        /// <value>The image.</value>
        [DefaultValue(null)]
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this control can close.
        /// </summary>
        /// <value><c>true</c> if this control can close; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool CanClose
        {
            get { return canClose; }
            set { canClose = value; }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DefaultValue("Name")]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title == value)
                    return;

                title = value;
                OnChanged();
            }
        }

        /// <summary>
        /// Gets and sets a value indicating if the page is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected == value)
                    return;

                selected = value;
            }
        }

        /// <summary>
        /// Gets the caption.
        /// </summary>
        /// <value>The caption.</value>
        [Browsable(false)]
        public string Caption
        {
            get { return Title; }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFameyeTabStripItem" /> class.
        /// </summary>
        public ZeroitFameyeTabStripItem() : this(string.Empty, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFameyeTabStripItem" /> class.
        /// </summary>
        /// <param name="displayControl">The display control.</param>
        public ZeroitFameyeTabStripItem(Control displayControl) : this(string.Empty, displayControl)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFameyeTabStripItem" /> class.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="displayControl">The display control.</param>
        public ZeroitFameyeTabStripItem(string caption, Control displayControl) 
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ContainerControl, true);
            
            selected = false;
            Visible = true;

            UpdateText(caption, displayControl);

            //Add to controls
            if(displayControl != null)
                Controls.Add(displayControl);
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Handles proper disposition of the tab page control.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            
            if(disposing)
            {
                if(image != null)
                    image.Dispose();
            }
        }

        #endregion

        #region ShouldSerialize

        /// <summary>
        /// Shoulds the serialize is drawn.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeIsDrawn()
        {
            return false;
        }

        /// <summary>
        /// Shoulds the serialize dock.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeDock()
        {
            return false;
        }

        /// <summary>
        /// Shoulds the serialize controls.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeControls()
        {
            return Controls != null && Controls.Count > 0;
        }

        /// <summary>
        /// Shoulds the serialize visible.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ShouldSerializeVisible()
        {
            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the text.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="displayControl">The display control.</param>
        private void UpdateText(string caption, Control displayControl)
        {
            if (displayControl != null && displayControl is ICaptionSupport)
            {
                ICaptionSupport capControl = displayControl as ICaptionSupport;
                Title = capControl.Caption;
            }
            else if (caption.Length <= 0 && displayControl != null)
            {
                Title = displayControl.Text;
            }
            else if (caption != null)
            {
                Title = caption;
            }
            else
            {
                Title = string.Empty;
            }
        }

        /// <summary>
        /// Assigns the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Assign(ZeroitFameyeTabStripItem item)
        {
            Visible = item.Visible;
            Text = item.Text;
            CanClose = item.CanClose;
            Tag = item.Tag;
        }

        /// <summary>
        /// Called when [changed].
        /// </summary>
        protected internal virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }

        /// <summary>
        /// Return a string representation of page.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Caption;
        }

        #endregion
    }
}
