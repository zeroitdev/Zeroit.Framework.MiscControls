// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="FlatTab.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel.Design;

namespace Zeroit.Framework.MiscControls.Tabs.FlatTab
{
    /// <summary>
    /// A class collection for rendering a Flat TabControl.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TabControl" />
	[ToolboxBitmap(typeof(System.Windows.Forms.TabControl))] //,
                                                             //Designer(typeof(Designers.ZeroitFlatTabDesigner))]

    public class ZeroitFlatTab : System.Windows.Forms.TabControl
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        /// <summary>
        /// The sc up down
        /// </summary>
        private SubClass scUpDown = null;
        /// <summary>
        /// The b up down
        /// </summary>
        private bool bUpDown; // true when the button UpDown is required
        /// <summary>
        /// The left right images
        /// </summary>
        private ImageList leftRightImages = null;
        /// <summary>
        /// The n margin
        /// </summary>
        private const int nMargin = 5;
        /// <summary>
        /// The m back color
        /// </summary>
        private Color mBackColor = SystemColors.Control;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFlatTab" /> class.
        /// </summary>
        public ZeroitFlatTab()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // double buffering
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            bUpDown = false;

            this.ControlAdded += new ControlEventHandler(ZeroitFlatTab_ControlAdded);
            this.ControlRemoved += new ControlEventHandler(ZeroitFlatTab_ControlRemoved);
            this.SelectedIndexChanged += new EventHandler(ZeroitFlatTab_SelectedIndexChanged);

            leftRightImages = new ImageList();
            //leftRightImages.ImageSize = new Size(16, 16); // default

            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ZeroitFlatTab));
            Bitmap updownImage = Properties.Resources.TabIcons;/* ((System.Drawing.Bitmap)(resources.GetObject("Zeroit.Framework.MiscControls.Resources.TabIcons.bmp")));*/

            if (updownImage != null)
            {
                updownImage.MakeTransparent(Color.White);
                leftRightImages.Images.AddStrip(updownImage);
            }
        }

        #region Methods and Overrides
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

                leftRightImages.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawControl(e.Graphics);
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        /// <param name="g">The g.</param>
        internal void DrawControl(Graphics g)
        {
            if (!Visible)
                return;

            Rectangle TabControlArea = this.ClientRectangle;
            Rectangle TabArea = this.DisplayRectangle;

            //----------------------------
            // fill client area
            Brush br = new SolidBrush(mBackColor); //(SystemColors.Control); UPDATED
            g.FillRectangle(br, TabControlArea);
            br.Dispose();
            //----------------------------

            //----------------------------
            // draw border
            int nDelta = SystemInformation.Border3DSize.Width;

            Pen border = new Pen(SystemColors.ControlDark);
            TabArea.Inflate(nDelta, nDelta);
            g.DrawRectangle(border, TabArea);
            border.Dispose();
            //----------------------------


            //----------------------------
            // clip region for drawing tabs
            Region rsaved = g.Clip;
            Rectangle rreg;

            int nWidth = TabArea.Width + nMargin;
            if (bUpDown)
            {
                // exclude updown control for painting
                if (Win32.IsWindowVisible(scUpDown.Handle))
                {
                    Rectangle rupdown = new Rectangle();
                    Win32.GetWindowRect(scUpDown.Handle, ref rupdown);
                    Rectangle rupdown2 = this.RectangleToClient(rupdown);

                    nWidth = rupdown2.X;
                }
            }

            rreg = new Rectangle(TabArea.Left, TabControlArea.Top, nWidth - nMargin, TabControlArea.Height);

            g.SetClip(rreg);

            // draw tabs
            for (int i = 0; i < this.TabCount; i++)
                DrawTab(g, this.TabPages[i], i);

            g.Clip = rsaved;
            //----------------------------


            //----------------------------
            // draw background to cover flat border areas
            if (this.SelectedTab != null)
            {
                System.Windows.Forms.TabPage tabPage = this.SelectedTab;
                Color color = tabPage.BackColor;
                border = new Pen(color);

                TabArea.Offset(1, 1);
                TabArea.Width -= 2;
                TabArea.Height -= 2;

                g.DrawRectangle(border, TabArea);
                TabArea.Width -= 1;
                TabArea.Height -= 1;
                g.DrawRectangle(border, TabArea);

                border.Dispose();
            }
            //----------------------------
        }

        /// <summary>
        /// Draws the tab.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="tabPage">The tab page.</param>
        /// <param name="nIndex">Index of the n.</param>
        internal void DrawTab(Graphics g, System.Windows.Forms.TabPage tabPage, int nIndex)
        {
            Rectangle recBounds = this.GetTabRect(nIndex);
            RectangleF tabTextArea = (RectangleF)this.GetTabRect(nIndex);

            bool bSelected = (this.SelectedIndex == nIndex);

            Point[] pt = new Point[7];
            if (this.Alignment == TabAlignment.Top)
            {
                pt[0] = new Point(recBounds.Left, recBounds.Bottom);
                pt[1] = new Point(recBounds.Left, recBounds.Top + 3);
                pt[2] = new Point(recBounds.Left + 3, recBounds.Top);
                pt[3] = new Point(recBounds.Right - 3, recBounds.Top);
                pt[4] = new Point(recBounds.Right, recBounds.Top + 3);
                pt[5] = new Point(recBounds.Right, recBounds.Bottom);
                pt[6] = new Point(recBounds.Left, recBounds.Bottom);
            }
            else
            {
                pt[0] = new Point(recBounds.Left, recBounds.Top);
                pt[1] = new Point(recBounds.Right, recBounds.Top);
                pt[2] = new Point(recBounds.Right, recBounds.Bottom - 3);
                pt[3] = new Point(recBounds.Right - 3, recBounds.Bottom);
                pt[4] = new Point(recBounds.Left + 3, recBounds.Bottom);
                pt[5] = new Point(recBounds.Left, recBounds.Bottom - 3);
                pt[6] = new Point(recBounds.Left, recBounds.Top);
            }

            //----------------------------
            // fill this tab with background color
            Brush br = new SolidBrush(tabPage.BackColor);
            g.FillPolygon(br, pt);
            br.Dispose();
            //----------------------------

            //----------------------------
            // draw border
            //g.DrawRectangle(SystemPens.ControlDark, recBounds);
            g.DrawPolygon(SystemPens.ControlDark, pt);

            if (bSelected)
            {
                //----------------------------
                // clear bottom lines
                Pen pen = new Pen(tabPage.BackColor);

                switch (this.Alignment)
                {
                    case TabAlignment.Top:
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom, recBounds.Right - 1, recBounds.Bottom);
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom + 1, recBounds.Right - 1, recBounds.Bottom + 1);
                        break;

                    case TabAlignment.Bottom:
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Top, recBounds.Right - 1, recBounds.Top);
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 1, recBounds.Right - 1, recBounds.Top - 1);
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 2, recBounds.Right - 1, recBounds.Top - 2);
                        break;
                }

                pen.Dispose();
                //----------------------------
            }
            //----------------------------

            //----------------------------
            // draw tab's icon
            if ((tabPage.ImageIndex >= 0) && (ImageList != null) && (ImageList.Images[tabPage.ImageIndex] != null))
            {
                int nLeftMargin = 8;
                int nRightMargin = 2;

                Image img = ImageList.Images[tabPage.ImageIndex];

                Rectangle rimage = new Rectangle(recBounds.X + nLeftMargin, recBounds.Y + 1, img.Width, img.Height);

                // adjust rectangles
                float nAdj = (float)(nLeftMargin + img.Width + nRightMargin);

                rimage.Y += (recBounds.Height - img.Height) / 2;
                tabTextArea.X += nAdj;
                tabTextArea.Width -= nAdj;

                // draw icon
                g.DrawImage(img, rimage);
            }
            //----------------------------

            //----------------------------
            // draw string
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            br = new SolidBrush(tabPage.ForeColor);

            g.DrawString(tabPage.Text, Font, br, tabTextArea, stringFormat);
            //----------------------------
        }

        /// <summary>
        /// Draws the icons.
        /// </summary>
        /// <param name="g">The g.</param>
        internal void DrawIcons(Graphics g)
        {
            if ((leftRightImages == null) || (leftRightImages.Images.Count != 4))
                return;

            //----------------------------
            // calc positions
            Rectangle TabControlArea = this.ClientRectangle;

            Rectangle r0 = new Rectangle();
            Win32.GetClientRect(scUpDown.Handle, ref r0);

            Brush br = new SolidBrush(SystemColors.Control);
            g.FillRectangle(br, r0);
            br.Dispose();

            Pen border = new Pen(SystemColors.ControlDark);
            Rectangle rborder = r0;
            rborder.Inflate(-1, -1);
            g.DrawRectangle(border, rborder);
            border.Dispose();

            int nMiddle = (r0.Width / 2);
            int nTop = (r0.Height - 16) / 2;
            int nLeft = (nMiddle - 16) / 2;

            Rectangle r1 = new Rectangle(nLeft, nTop, 16, 16);
            Rectangle r2 = new Rectangle(nMiddle + nLeft, nTop, 16, 16);
            //----------------------------

            //----------------------------
            // draw buttons
            Image img = leftRightImages.Images[1];
            if (img != null)
            {
                if (this.TabCount > 0)
                {
                    Rectangle r3 = this.GetTabRect(0);
                    if (r3.Left < TabControlArea.Left)
                        g.DrawImage(img, r1);
                    else
                    {
                        img = leftRightImages.Images[3];
                        if (img != null)
                            g.DrawImage(img, r1);
                    }
                }
            }

            img = leftRightImages.Images[0];
            if (img != null)
            {
                if (this.TabCount > 0)
                {
                    Rectangle r3 = this.GetTabRect(this.TabCount - 1);
                    if (r3.Right > (TabControlArea.Width - r0.Width))
                        g.DrawImage(img, r2);
                    else
                    {
                        img = leftRightImages.Images[2];
                        if (img != null)
                            g.DrawImage(img, r2);
                    }
                }
            }
            //----------------------------
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.CreateControl" /> method.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            FindUpDown();
        }

        /// <summary>
        /// Handles the ControlAdded event of the ZeroitFlatTab control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ControlEventArgs"/> instance containing the event data.</param>
        private void ZeroitFlatTab_ControlAdded(object sender, ControlEventArgs e)
        {
            FindUpDown();
            UpdateUpDown();
        }

        /// <summary>
        /// Handles the ControlRemoved event of the ZeroitFlatTab control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ControlEventArgs"/> instance containing the event data.</param>
        private void ZeroitFlatTab_ControlRemoved(object sender, ControlEventArgs e)
        {
            FindUpDown();
            UpdateUpDown();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ZeroitFlatTab control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ZeroitFlatTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUpDown();
            Invalidate();   // we need to update border and background colors
        }

        /// <summary>
        /// Finds up down.
        /// </summary>
        private void FindUpDown()
        {
            bool bFound = false;

            // find the UpDown control
            IntPtr pWnd = Win32.GetWindow(this.Handle, Win32.GW_CHILD);

            while (pWnd != IntPtr.Zero)
            {
                //----------------------------
                // Get the window class name
                char[] className = new char[33];

                int length = Win32.GetClassName(pWnd, className, 32);

                string s = new string(className, 0, length);
                //----------------------------

                if (s == "msctls_updown32")
                {
                    bFound = true;

                    if (!bUpDown)
                    {
                        //----------------------------
                        // Subclass it
                        this.scUpDown = new SubClass(pWnd, true);
                        this.scUpDown.SubClassedWndProc += new SubClass.SubClassWndProcEventHandler(scUpDown_SubClassedWndProc);
                        //----------------------------

                        bUpDown = true;
                    }
                    break;
                }

                pWnd = Win32.GetWindow(pWnd, Win32.GW_HWNDNEXT);
            }

            if ((!bFound) && (bUpDown))
                bUpDown = false;
        }

        /// <summary>
        /// Updates up down.
        /// </summary>
        private void UpdateUpDown()
        {
            if (bUpDown)
            {
                if (Win32.IsWindowVisible(scUpDown.Handle))
                {
                    Rectangle rect = new Rectangle();

                    Win32.GetClientRect(scUpDown.Handle, ref rect);
                    Win32.InvalidateRect(scUpDown.Handle, ref rect, true);
                }
            }
        }
        #endregion

        #region scUpDown_SubClassedWndProc Event Handler

        /// <summary>
        /// Scs up down sub classed WND proc.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns>System.Int32.</returns>
        private int scUpDown_SubClassedWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Win32.WM_PAINT:
                    {
                        //------------------------
                        // redraw
                        IntPtr hDC = Win32.GetWindowDC(scUpDown.Handle);
                        Graphics g = Graphics.FromHdc(hDC);

                        DrawIcons(g);

                        g.Dispose();
                        Win32.ReleaseDC(scUpDown.Handle, hDC);
                        //------------------------

                        // return 0 (processed)
                        m.Result = IntPtr.Zero;

                        //------------------------
                        // validate current rect
                        Rectangle rect = new Rectangle();

                        Win32.GetClientRect(scUpDown.Handle, ref rect);
                        Win32.ValidateRect(scUpDown.Handle, ref rect);
                        //------------------------
                    }
                    return 1;
            }

            return 0;
        }
        #endregion

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }


        #endregion

        #region Properties

        /// <summary>
        /// Gets the collection of tab pages in this tab control.
        /// </summary>
        /// <value>The tab pages.</value>
        [Editor(typeof(TabpageExCollectionEditor), typeof(UITypeEditor))]
        public new TabPageCollection TabPages
        {
            get
            {
                return base.TabPages;
            }
        }

        /// <summary>
        /// Gets or sets the area of the control (for example, along the top) where the tabs are aligned.
        /// </summary>
        /// <value>The alignment.</value>
        new public TabAlignment Alignment
        {
            get { return base.Alignment; }
            set
            {
                TabAlignment ta = value;
                if ((ta != TabAlignment.Top) && (ta != TabAlignment.Bottom))
                    ta = TabAlignment.Top;

                base.Alignment = ta;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether more than one row of tabs can be displayed.
        /// </summary>
        /// <value><c>true</c> if multiline; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        new public bool Multiline
        {
            get { return base.Multiline; }
            set { base.Multiline = false; }
        }
        /// <summary>
        /// Gets or sets the Background color.
        /// </summary>
        /// <value>The color of the back.</value>
        [Browsable(true)]
        public new Color BackColor
        {
            get { return mBackColor; }
            set { mBackColor = value; this.Invalidate(); }
        }

        #endregion

        #region TabpageExCollectionEditor

        /// <summary>
        /// Class TabpageExCollectionEditor.
        /// </summary>
        /// <seealso cref="System.ComponentModel.Design.CollectionEditor" />
        internal class TabpageExCollectionEditor : CollectionEditor
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TabpageExCollectionEditor"/> class.
            /// </summary>
            /// <param name="type">The type of the collection for this editor to edit.</param>
            public TabpageExCollectionEditor(System.Type type) : base(type)
            {
            }

            /// <summary>
            /// Gets the data type that this collection contains.
            /// </summary>
            /// <returns>The data type of the items in the collection, or an <see cref="T:System.Object" /> if no Item property can be located on the collection.</returns>
            protected override Type CreateCollectionItemType()
            {
                return typeof(System.Windows.Forms.TabPage);
            }
        }

        #endregion
    }

    //#endregion
}
