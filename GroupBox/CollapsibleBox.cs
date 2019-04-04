// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="CollapsibleBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace Zeroit.Framework.MiscControls
{

    #region Collapsible GroupBox

    #region CollapseBox

    /// <summary>
    /// Summary description for CollapseBox.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitOwnerDrawButton" />
    [ToolboxItem(true)]
    public class ZeroitCollapseBox : ZeroitOwnerDrawButton
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #region Internal variables
        /// <summary>
        /// The m b is plus
        /// </summary>
        private bool m_bIsPlus;
        #endregion Internal variables

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCollapseBox"/> class.
        /// </summary>
        public ZeroitCollapseBox()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // CollapseBox
            // 
            this.Click += new System.EventHandler(this.CollapseBox_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CollapseBox_Paint);
            this.DoubleClick += new System.EventHandler(this.CollapseBox_DoubleClick);

        }
        #endregion

        #region Events
        /// <summary>
        /// Handles the Click event of the CollapseBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CollapseBox_Click(object sender, System.EventArgs e)
        {
            IsPlus = !IsPlus;
        }

        /// <summary>
        /// Handles the DoubleClick event of the CollapseBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CollapseBox_DoubleClick(object sender, System.EventArgs e)
        {
            // fast clicking registers as double-clicking, so map a double-click
            // event into a single click.
            CollapseBox_Click(sender, e);
        }

        /// <summary>
        /// Handles the Paint event of the CollapseBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void CollapseBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (m_ButtonState == ButtonState.TrackingInside)
                g.FillRectangle(Brushes.LightGray, ClientRectangle);
            else
                g.FillRectangle(Brushes.White, ClientRectangle);

            Rectangle theRec = new Rectangle();
            theRec = ClientRectangle;
            theRec.Width--;
            theRec.Height--;
            g.DrawRectangle(Pens.Black, theRec);
            g.DrawLine(Pens.Black, theRec.X + 2, theRec.Y + (this.Height / 2),
                theRec.X + this.Width - 3, theRec.Y + (this.Height / 2));
            if (m_bIsPlus)
            {
                g.DrawLine(Pens.Black, theRec.X + (this.Width / 2), theRec.Y + 2,
                    theRec.X + (this.Width / 2), theRec.Y + this.Height - 3);
            }
        }
        #endregion Events

        #region Accessors
        /// <summary>
        /// Gets or sets a value indicating whether this instance is plus.
        /// </summary>
        /// <value><c>true</c> if this instance is plus; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool IsPlus
        {
            get
            {
                return m_bIsPlus;
            }
            set
            {
                if (m_bIsPlus != value)
                {
                    m_bIsPlus = value;
                    Invalidate();
                }
            }
        }
        #endregion Accessors
    }

    #endregion

    #region Control

    /// <summary>
    /// A class collection for rendering a collapsible GroupBox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(true)]
    public class ZeroitCollapsibleGroupBox : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// The k collapsed height
        /// </summary>
        public const int kCollapsedHeight = 20;

        #region Members
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// The m collapse box
        /// </summary>
        private ZeroitCollapseBox m_CollapseBox;
        /// <summary>
        /// The m trash icon
        /// </summary>
        private ZeroitCollapsibleZeroitImageButton m_TrashIcon;
        /// <summary>
        /// Occurs when [collapse box clicked event].
        /// </summary>
        public event CollapseBoxClickedEventHandler CollapseBoxClickedEvent;
        /// <summary>
        /// Occurs when [trash can clicked event].
        /// </summary>
        public event TrashCanClickedEventHandler TrashCanClickedEvent;

        /// <summary>
        /// The m caption
        /// </summary>
        private string m_Caption;
        //private bool							m_bContainsTrashCan;
        //private System.Windows.Forms.GroupBox	m_GroupBox;
        /// <summary>
        /// The m full size
        /// </summary>
        private Size m_FullSize;
        /// <summary>
        /// The m b resizing from collapse
        /// </summary>
        private bool m_bResizingFromCollapse = false;
        #endregion Members

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCollapsibleGroupBox" /> class.
        /// </summary>
        public ZeroitCollapsibleGroupBox()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ZeroitCollapsibleGroupBox));
            this.m_CollapseBox = new ZeroitCollapseBox();
            this.m_TrashIcon = new ZeroitCollapsibleZeroitImageButton();
            this.SuspendLayout();
            // 
            // m_CollapseBox
            // 
            this.m_CollapseBox.IsPlus = false;
            this.m_CollapseBox.Location = new System.Drawing.Point(12, 1);
            this.m_CollapseBox.Name = "m_CollapseBox";
            this.m_CollapseBox.Size = new System.Drawing.Size(11, 11);
            this.m_CollapseBox.TabIndex = 1;
            this.m_CollapseBox.Click += new System.EventHandler(this.CollapseBox_Click);
            this.m_CollapseBox.DoubleClick += new System.EventHandler(this.CollapseBox_DoubleClick);
            // 
            // m_TrashIcon
            // 
            this.m_TrashIcon.Location = new System.Drawing.Point(88, 0);
            this.m_TrashIcon.Name = "m_TrashIcon";
            //this.m_TrashIcon.DefaultImage = ((System.Drawing.Image)(resources.GetObject("m_TrashIcon.DefaultImage")));
            //this.m_TrashIcon.PressedImage = ((System.Drawing.Image)(resources.GetObject("m_TrashIcon.PressedImage")));
            this.m_TrashIcon.Size = new System.Drawing.Size(16, 16);
            this.m_TrashIcon.TabIndex = 2;
            this.m_TrashIcon.TabStop = false;
            this.m_TrashIcon.Click += new System.EventHandler(this.TrashIcon_Click);
            // 
            // CollapsibleGroupBox
            // 
            this.Controls.Add(this.m_TrashIcon);
            this.Controls.Add(this.m_CollapseBox);
            this.Name = "CollapsibleGroupBox";
            this.Resize += new System.EventHandler(this.CollapsibleGroupBox_Resize);
            this.Load += new System.EventHandler(this.CollapsibleGroupBox_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CollapsibleGroupBox_Paint);
            this.ResumeLayout(false);

        }
        #endregion

        #region Events
        /// <summary>
        /// Handles the Load event of the CollapsibleGroupBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CollapsibleGroupBox_Load(object sender, System.EventArgs e)
        {
            SetGroupBoxCaption();
        }

        /// <summary>
        /// Handles the Resize event of the CollapsibleGroupBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CollapsibleGroupBox_Resize(object sender, System.EventArgs e)
        {
            if (m_bResizingFromCollapse != true)
            {
                m_FullSize = this.Size;
            }

            Invalidate();
        }

        /// <summary>
        /// Handles the Paint event of the CollapsibleGroupBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void CollapsibleGroupBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // UG! I originall added a GroupBox control but ran into problems...
            // Panes derived from CollapsibleGroupBox would "chew up" controls
            // added to them, so I had to get rid of the GroupBox and draw a fake
            // group box myself
            Graphics g = e.Graphics;
            Rectangle theRec = new Rectangle();
            theRec = this.ClientRectangle;

            //Color theEdgeGrayColor = Color.FromArgb(170, 170, 156);
            //Pen thePen = new Pen(theEdgeGrayColor);
            Pen thePen = SystemPens.ControlDark;


            int theTextSize = (int)g.MeasureString(m_Caption, this.Font).Width;
            if (theTextSize < 1)
                theTextSize = 1;

            int theCaptionPosition = (theRec.X + 8) + 2 + m_CollapseBox.Width + 2;
            int theEndPosition = theCaptionPosition + theTextSize + 1;
            if (m_TrashIcon.Visible)
                theEndPosition += (m_TrashIcon.Width + 2);


            g.DrawLine(thePen, theRec.X + 8, theRec.Y + 5,
                theRec.X, theRec.Y + 5);

            g.DrawLine(thePen, theRec.X, theRec.Y + 5,
                theRec.X, theRec.Bottom - 2);

            g.DrawLine(thePen, theRec.X, theRec.Bottom - 2,
                theRec.Right - 1, theRec.Bottom - 2);

            g.DrawLine(thePen, theRec.Right - 2, theRec.Bottom - 2,
                theRec.Right - 2, theRec.Y + 5);

            g.DrawLine(thePen, theRec.Right - 2, theRec.Y + 5,
                theRec.X + theEndPosition, theRec.Y + 5);



            g.DrawLine(Pens.White, theRec.X + 8, theRec.Y + 6,
                theRec.X + 1, theRec.Y + 6);

            g.DrawLine(Pens.White, theRec.X + 1, theRec.Y + 6,
                theRec.X + 1, theRec.Bottom - 3);

            g.DrawLine(Pens.White, theRec.X, theRec.Bottom - 1,
                theRec.Right, theRec.Bottom - 1);

            g.DrawLine(Pens.White, theRec.Right - 1, theRec.Bottom - 1,
                theRec.Right - 1, theRec.Y + 5);

            g.DrawLine(Pens.White, theRec.Right - 3, theRec.Y + 6,
                theRec.X + theEndPosition, theRec.Y + 6);

            StringFormat sf = new StringFormat();
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            g.DrawString(m_Caption, this.Font, drawBrush, theCaptionPosition, 0);
        }

        /// <summary>
        /// Handles the Click event of the CollapseBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void CollapseBox_Click(object sender, System.EventArgs e)
        {
            // at this point the control's value has changed but hasn't been
            // redrawn on the screen
            this.IsCollapsed = m_CollapseBox.IsPlus;

            if (CollapseBoxClickedEvent != null)
            {
                CollapseBoxClickedEvent(this);
            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the CollapseBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CollapseBox_DoubleClick(object sender, System.EventArgs e)
        {
            // fast clicking registers as double-clicking, so map a double-click
            // event into a single click.
            CollapseBox_Click(sender, e);
        }

        /// <summary>
        /// Handles the Click event of the TrashIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TrashIcon_Click(object sender, System.EventArgs e)
        {
            if (TrashCanClickedEvent != null)
            {
                TrashCanClickedEvent(this);
            }
        }
        #endregion events

        #region Accessors        
        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        [DefaultValue("")]
        public string Caption
        {
            get
            {
                return m_Caption;
            }
            set
            {
                m_Caption = value;
                SetGroupBoxCaption();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to contain trash can.
        /// </summary>
        /// <value><c>true</c> if contains trash can; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool ContainsTrashCan
        {
            get
            {
                return m_TrashIcon.Visible;
            }
            set
            {
                //m_bContainsTrashCan = value;
                m_TrashIcon.Visible = value;
                SetGroupBoxCaption();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets the full height.
        /// </summary>
        /// <value>The full height.</value>
        [Browsable(false)]
        public int FullHeight
        {
            get
            {
                return m_FullSize.Height;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this control is collapsed.
        /// </summary>
        /// <value><c>true</c> if this instance is collapsed; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Browsable(false)]
        public bool IsCollapsed
        {
            get
            {
#if DEBUG
                if (m_CollapseBox.IsPlus)
                {
                    Debug.Assert(this.Height == kCollapsedHeight);
                }
                else
                {
                    Debug.Assert(this.Height > kCollapsedHeight);
                }
#endif
                return m_CollapseBox.IsPlus;
            }
            set
            {
                if (m_CollapseBox.IsPlus != value)
                {
                    m_CollapseBox.IsPlus = value;
                }

                if (m_CollapseBox.IsPlus != true)
                {
                    //Expand();
                    this.Size = m_FullSize;
                }
                else
                {
                    //Collapse();
                    m_bResizingFromCollapse = true;
                    Size smallSize = m_FullSize;
                    smallSize.Height = kCollapsedHeight;
                    this.Size = smallSize;
                    m_bResizingFromCollapse = false;
                }

                Invalidate();
            }
        }
        #endregion accessors

        #region Methods
        /// <summary>
        /// Sets the group box caption.
        /// </summary>
        private void SetGroupBoxCaption()
        {
            RepositionTrashCan();
        }

        /// <summary>
        /// Repositions the trash can.
        /// </summary>
        private void RepositionTrashCan()
        {
            if (m_TrashIcon.Visible)
            {
                // Since the trash icon's location is a function of the caption's width,
                // we also need to reposition the trash icon
                // first, find the width of the string
                Graphics g = CreateGraphics();
                SizeF theTextSize = new SizeF();
                theTextSize = g.MeasureString(m_Caption, this.Font);
                // Hmm... MeasureString() doesn't seem to be returning the
                // correct width.  Close... but not exact

                // 11 is the number of pixels from the beginning of the group box
                // to the beginning of text of the group box's caption
                //m_TrashIcon.Left = m_GroupBox.Location.X + 29 + (int)theTextSize.Width - 4;
                m_TrashIcon.Left = this.Location.X + 29 + (int)theTextSize.Width - 4;
                // -4 is a fudge factor.  Hey, what can I say...
            }
        }
        #endregion Methods


        /// <summary>
        /// Delegate CollapseBoxClickedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        public delegate void CollapseBoxClickedEventHandler(object sender);
        /// <summary>
        /// Delegate TrashCanClickedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        public delegate void TrashCanClickedEventHandler(object sender);
    }

    #endregion

    #region ZeroitExpandingPanel

    /// <summary>
    /// Summary description for ExpandingPanel.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    [ToolboxItem(true)]
    public class ZeroitExpandingPanel : System.Windows.Forms.Panel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        /// <summary>
        /// The m group array
        /// </summary>
        ArrayList m_GroupArray = null;


        /// <summary>
        /// The k gap
        /// </summary>
        public const int kGap = 6;
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitExpandingPanel"/> class.
        /// </summary>
        public ZeroitExpandingPanel()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            m_GroupArray = new ArrayList();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ExpandingPanel
            // 
            this.Move += new System.EventHandler(this.ExpandingPanel_Move);
            this.Resize += new System.EventHandler(this.ExpandingPanel_Resize);
            this.SizeChanged += new System.EventHandler(this.ExpandingPanel_SizeChanged);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.ExpandingPanel_Layout);

        }
        #endregion


        /// <summary>
        /// Adds the group.
        /// </summary>
        /// <param name="theGroupBox">The group box.</param>
        public void AddGroup(ZeroitCollapsibleGroupBox theGroupBox)
        {
            m_GroupArray.Add(theGroupBox);


            this.SuspendLayout();
            Size theSize = this.AutoScrollMinSize;
            theGroupBox.Location = new System.Drawing.Point(4, theSize.Height + 4);


            theSize.Height += (theGroupBox.Height + kGap);
            this.AutoScrollMinSize = theSize;
            theGroupBox.CollapseBoxClickedEvent += new ZeroitCollapsibleGroupBox.CollapseBoxClickedEventHandler(this.CollapseBox_Click);
            theGroupBox.TrashCanClickedEvent += new ZeroitCollapsibleGroupBox.TrashCanClickedEventHandler(this.TrashCan_Click);
            this.Controls.Add(theGroupBox);
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Handles the Layout event of the ExpandingPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LayoutEventArgs"/> instance containing the event data.</param>
        private void ExpandingPanel_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
        {
        }

        /// <summary>
        /// Handles the Move event of the ExpandingPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ExpandingPanel_Move(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Resize event of the ExpandingPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ExpandingPanel_Resize(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Handles the SizeChanged event of the ExpandingPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ExpandingPanel_SizeChanged(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Collapses the box click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void CollapseBox_Click(object sender)
        {
            int nIndex;
            nIndex = m_GroupArray.IndexOf(sender);

            ZeroitCollapsibleGroupBox theGroupBox;
            theGroupBox = (ZeroitCollapsibleGroupBox)m_GroupArray[nIndex];

            int nDelta;
            if (theGroupBox.Height == ZeroitCollapsibleGroupBox.kCollapsedHeight)
            {
                nDelta = -(theGroupBox.FullHeight - ZeroitCollapsibleGroupBox.kCollapsedHeight);
            }
            else
            {
                nDelta = (theGroupBox.FullHeight - ZeroitCollapsibleGroupBox.kCollapsedHeight);
            }

            for (int i = (nIndex + 1); i < m_GroupArray.Count; i++)
            {
                theGroupBox = (ZeroitCollapsibleGroupBox)m_GroupArray[i];
                theGroupBox.Top += nDelta;
            }

            Size theSize = this.AutoScrollMinSize;
            theSize.Height += nDelta;
            this.AutoScrollMinSize = theSize;
        }

        /// <summary>
        /// Trashes the can click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void TrashCan_Click(object sender)
        {
            int nIndex;
            nIndex = m_GroupArray.IndexOf(sender);

            ZeroitCollapsibleGroupBox theGroupBox;
            theGroupBox = (ZeroitCollapsibleGroupBox)m_GroupArray[nIndex];

            int nDelta;
            nDelta = theGroupBox.Height + kGap;

            m_GroupArray.RemoveAt(nIndex);
            theGroupBox.Dispose();
            theGroupBox = null;

            for (int i = nIndex; i < m_GroupArray.Count; i++)
            {
                theGroupBox = (ZeroitCollapsibleGroupBox)m_GroupArray[i];
                theGroupBox.Top -= nDelta;
            }

            Size theSize = this.AutoScrollMinSize;
            theSize.Height -= nDelta;
            this.AutoScrollMinSize = theSize;
        }
    }

    #endregion

    #region NOT USED
    /// <summary>
    /// Class IndexerArray.
    /// </summary>
    class IndexerArray
    {
        /// <summary>
        /// The data
        /// </summary>
        protected ArrayList data = new ArrayList();

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified index.
        /// </summary>
        /// <param name="idx">The index.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// [IndexerArray.get_Item]Index out of range
        /// or
        /// [IndexerArray.set_Item]Index out of range
        /// </exception>
        public object this[int idx]
        {
            get
            {
                if (idx > -1 && idx < data.Count)
                {
                    return (data[idx]);
                }
                else
                {
                    throw new InvalidOperationException("[IndexerArray.get_Item]Index out of range");
                }
            }
            set
            {
                if (idx > -1 && idx < data.Count)
                {
                    data[idx] = value;
                }
                else if (idx == data.Count)
                {
                    data.Add(value);
                }
                else
                {
                    throw new InvalidOperationException("[IndexerArray.set_Item]Index out of range");
                }
            }
        }
    }

    #endregion NOT USED

    #region Image Button

    /// <summary>
    /// A class collection for rendering an ZeroitImageButton.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitOwnerDrawButton" />
    [ToolboxItem(true)]
    public class ZeroitCollapsibleZeroitImageButton : ZeroitOwnerDrawButton
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #region Internal variables
        /// <summary>
        /// The m normal image
        /// </summary>
        private Image m_NormalImage = null;
        /// <summary>
        /// The m pressed image
        /// </summary>
        private Image m_PressedImage = null;
        #endregion Internal variables

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCollapsibleZeroitImageButton" /> class.
        /// </summary>
        public ZeroitCollapsibleZeroitImageButton()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ZeroitImageButton
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ZeroitImageButton_Paint);
        }
        #endregion

        #region Events
        /// <summary>
        /// Handles the Paint event of the ZeroitImageButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void ZeroitImageButton_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (m_ButtonState == ButtonState.TrackingInside)
            {
                if (m_PressedImage != null)
                {
                    g.DrawImage(m_PressedImage, 0, 0, m_PressedImage.Width, m_PressedImage.Height);
                }
            }
            else
            {
                if (m_NormalImage != null)
                {
                    g.DrawImage(m_NormalImage, 0, 0, m_NormalImage.Width, m_NormalImage.Height);
                }
            }
        }
        #endregion Events

        #region Accessors        
        /// <summary>
        /// Gets or sets the default image.
        /// </summary>
        /// <value>The default image.</value>
        public Image DefaultImage
        {
            get
            {
                return m_NormalImage;
            }
            set
            {
                m_NormalImage = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the pressed image.
        /// </summary>
        /// <value>The pressed image.</value>
        public Image PressedImage
        {
            get
            {
                return m_PressedImage;
            }
            set
            {
                m_PressedImage = value;
                Invalidate();
            }
        }
        #endregion Accessors
    }

    #endregion

    #region OwnerDrawButton

    /// <summary>
    /// A class collection for rendering a owner drawn button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [ToolboxItem(false)]
    public class ZeroitOwnerDrawButton : System.Windows.Forms.Control
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #region Internal variables
        /// <summary>
        /// Enum representing the state of the button
        /// </summary>
        public enum ButtonState
        {
            /// <summary>
            /// The normal
            /// </summary>
            Normal,
            /// <summary>
            /// The tracking inside
            /// </summary>
            TrackingInside,
            /// <summary>
            /// The tracking outside
            /// </summary>
            TrackingOutside
        }

        /// <summary>
        /// The m button state
        /// </summary>
        protected ButtonState m_ButtonState = ButtonState.Normal;
        #endregion Internal variables

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitOwnerDrawButton" /> class.
        /// </summary>
        public ZeroitOwnerDrawButton()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // OwnerDrawButton
            // 
            this.Resize += new System.EventHandler(this.OwnerDrawButton_Resize);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OwnerDrawButton_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OwnerDrawButton_Paint);
            this.MouseEnter += new System.EventHandler(this.OwnerDrawButton_MouseEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OwnerDrawButton_MouseMove);
            this.MouseLeave += new System.EventHandler(this.OwnerDrawButton_MouseLeave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OwnerDrawButton_MouseDown);

        }
        #endregion

        #region Events
        /// <summary>
        /// Handles the Paint event of the OwnerDrawButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void OwnerDrawButton_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // needs to be implemented by the derived class
        }

        /// <summary>
        /// Handles the MouseDown event of the OwnerDrawButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void OwnerDrawButton_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            m_ButtonState = ButtonState.TrackingInside;
            Invalidate();
        }

        /// <summary>
        /// Handles the MouseEnter event of the OwnerDrawButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OwnerDrawButton_MouseEnter(object sender, System.EventArgs e)
        {
            if (m_ButtonState == ButtonState.TrackingOutside)
            {
                m_ButtonState = ButtonState.TrackingInside;
                Invalidate();
            }
        }

        /// <summary>
        /// Handles the MouseLeave event of the OwnerDrawButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OwnerDrawButton_MouseLeave(object sender, System.EventArgs e)
        {
            if (m_ButtonState == ButtonState.TrackingInside)
            {
                m_ButtonState = ButtonState.TrackingOutside;
                Invalidate();
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the OwnerDrawButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void OwnerDrawButton_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (m_ButtonState == ButtonState.Normal)
                return;

            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            if (m_ButtonState == ButtonState.TrackingInside)
            {
                if (!bounds.Contains(e.X, e.Y))
                    OwnerDrawButton_MouseLeave(sender, e);
            }
            else if (m_ButtonState == ButtonState.TrackingOutside)
            {
                if (bounds.Contains(e.X, e.Y))
                    OwnerDrawButton_MouseEnter(sender, e);
            }
        }

        /// <summary>
        /// Handles the MouseUp event of the OwnerDrawButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void OwnerDrawButton_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (m_ButtonState != ButtonState.Normal)
            {
                m_ButtonState = ButtonState.Normal;
                Invalidate();
            }
        }

        /// <summary>
        /// Handles the Resize event of the OwnerDrawButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OwnerDrawButton_Resize(object sender, System.EventArgs e)
        {
            Invalidate();
        }
        #endregion Events
    }

    #endregion

    #endregion

}
