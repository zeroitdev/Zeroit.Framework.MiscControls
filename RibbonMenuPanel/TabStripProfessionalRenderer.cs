// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TabStripProfessionalRenderer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class TabStripProfessionalRenderer.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolStripProfessionalRenderer" />
    public class TabStripProfessionalRenderer : ToolStripProfessionalRenderer
    {

        /// <summary>
        /// The bottom left
        /// </summary>
        private const int BOTTOM_LEFT = 0;
        /// <summary>
        /// The top left
        /// </summary>
        private const int TOP_LEFT = 1;
        /// <summary>
        /// The top right
        /// </summary>
        private const int TOP_RIGHT = 2;
        /// <summary>
        /// The bottom right
        /// </summary>
        private const int BOTTOM_RIGHT = 3;
        /// <summary>
        /// The oncolor
        /// </summary>
        private Color oncolor;
        /// <summary>
        /// The onbackcolor
        /// </summary>
        private Color onbackcolor;

        /// <summary>
        /// The basecolor
        /// </summary>
        private Color basecolor;
        /// <summary>
        /// The halocolor
        /// </summary>
        private Color halocolor;

        /// <summary>
        /// The x0
        /// </summary>
        int X0;
        /// <summary>
        /// The xf
        /// </summary>
        int XF;
        /// <summary>
        /// The y0
        /// </summary>
        int Y0;
        /// <summary>
        /// The yf
        /// </summary>
        int YF;
        /// <summary>
        /// The t
        /// </summary>
        int T = 2;
        /// <summary>
        /// The i zero
        /// </summary>
        int i_Zero = 180;
        /// <summary>
        /// The i sweep
        /// </summary>
        int i_Sweep = 90;
        /// <summary>
        /// The x
        /// </summary>
        int X; int Y;
        /// <summary>
        /// The path
        /// </summary>
        GraphicsPath path;
        /// <summary>
        /// The d
        /// </summary>
        int D = -1;

        /// <summary>
        /// Gets or sets the color of the on.
        /// </summary>
        /// <value>The color of the on.</value>
        public Color OnColor
        {
            get
            {
                return oncolor;
            }
            set
            {
                oncolor = value;
            }

        }
        /// <summary>
        /// Gets or sets the color of the on back.
        /// </summary>
        /// <value>The color of the on back.</value>
        public Color OnBackColor
        {
            get
            {
                return onbackcolor;
            }
            set
            {
                onbackcolor = value;
            }

        }

        /// <summary>
        /// Gets or sets the color of the base.
        /// </summary>
        /// <value>The color of the base.</value>
        public Color BaseColor
        {
            get { return basecolor; }
            set { basecolor = value; }
        }

        /// <summary>
        /// Gets or sets the color of the halo.
        /// </summary>
        /// <value>The color of the halo.</value>
        public Color HaloColor
        {
            get { return halocolor; }
            set { halocolor = value; }
        }

        /// <summary>
        /// This renderer supports rendering of tabs.
        /// </summary>
        public TabStripProfessionalRenderer()
        {
            this.RoundedEdges = false; // get rid of the curves around the edges
            this.OnColor = Color.FromArgb(226, 209, 156);
            this.OnBackColor = Color.FromArgb(191, 219, 255);

        }


        /// <summary>
        /// Sets the transparency.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="transparency">The transparency.</param>
        /// <returns>Color.</returns>
        public Color SetTransparency(Color color, int transparency)
        {
            if (transparency >= 0 & transparency <= 255)
            {
                return Color.FromArgb(transparency, color.R, color.G, color.B);
            }
            else if (transparency > 255)
            {
                return Color.FromArgb(255, color.R, color.G, color.B);
            }
            else
            {
                return Color.FromArgb(0, color.R, color.G, color.B);
            }
        }

        /// <summary>
        /// Control when the background of the Tab is painting.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ZeroitTabStrip tabStrip = e.ToolStrip as ZeroitTabStrip;
            Tab tab = e.Item as Tab;
            int i_opacity = tab.i_opacity;

            if (tab == null)
            {
                base.OnRenderButtonBackground(e);
                return;
            }
            Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            int textwidth = Convert.ToInt16(g.MeasureString(tab.Text, tab.Font).Width) - Convert.ToInt16(tab.Text.Length / 3);
            int textheight = Convert.ToInt16(g.MeasureString(tab.Text, tab.Font).Height);

            if (tabStrip != null)
            {

                #region Tab Selected and NOT active
                if (tab.b_selected & !tab.b_active)
                {
                    #region Show Lateral Gradients
                    Rectangle ri = bounds;
                    ri.Width = (tab.Width - textwidth) / 2;
                    ri.X += 2; ri.Width -= 2;
                    Color C0i = BaseColor; int c_origin = 255; C0i = SetTransparency(C0i, 0);
                    Color CFi = HaloColor; c_origin = 255; CFi = SetTransparency(CFi, c_origin - i_opacity);
                    LinearGradientBrush b = new LinearGradientBrush(ri, C0i, CFi, LinearGradientMode.BackwardDiagonal);
                    g.FillRectangle(b, ri.X, ri.Y, ri.Width, ri.Height);
                    int offset = bounds.Width - ri.Width - 1;
                    ri.Location = new Point(offset, 1);
                    b = new LinearGradientBrush(ri, C0i, CFi, LinearGradientMode.ForwardDiagonal);
                    g.FillRectangle(b, offset, ri.Y, ri.Width, ri.Height);
                    #endregion

                    #region Show Central Gradient
                    Rectangle r = bounds;
                    r.X += 2; r.Width -= 2;
                    r.Height = r.Height / 2;
                    Color C0 = BaseColor; c_origin = 255; C0 = SetTransparency(C0, c_origin - i_opacity);
                    Color CF = HaloColor; c_origin = 255; CF = SetTransparency(CF, c_origin - i_opacity);
                    b = new LinearGradientBrush(r, C0, CF, LinearGradientMode.Vertical);
                    g.FillRectangle(b, r.X, r.Y + r.Height + 1, r.Width - r.X, r.Height);
                    #endregion

                    #region Show Vertical Side Lines
                    int Offs = 0;
                    X0 = 0; XF = tab.Width + X0;
                    YF = tab.Height + Y0; Y0 = 0;
                    Point P0 = new Point(X0, Y0);
                    Point PF = new Point(X0, YF / 2);
                    Color C0sl = this.OnBackColor; C0sl = SetTransparency(C0sl, 0);
                    Color CFsl = Color.White;
                    Rectangle rsl = new Rectangle(X0, Y0 + Offs, X0 + 1, YF / 2);
                    b = new LinearGradientBrush(rsl, C0sl, CFsl, LinearGradientMode.Vertical);
                    g.FillRectangle(b, X0, Y0 + Offs, rsl.Width, rsl.Height);
                    rsl = new Rectangle(X0, YF / 2 - 1, X0 + 1, YF - Offs);
                    b = new LinearGradientBrush(rsl, CFsl, C0sl, LinearGradientMode.Vertical);
                    g.FillRectangle(b, X0, YF / 2 - 1, rsl.Width, rsl.Height);

                    Rectangle rsr = new Rectangle(XF - 2, Y0 + Offs, XF - 1, YF / 2);
                    b = new LinearGradientBrush(rsr, C0sl, CFsl, LinearGradientMode.Vertical);
                    g.FillRectangle(b, XF - 1, Y0 + Offs, rsr.Width, rsr.Height);
                    rsr = new Rectangle(XF - 2, YF / 2 - 1, XF - 1, YF - Offs);
                    b = new LinearGradientBrush(rsr, CFsl, C0sl, LinearGradientMode.Vertical);
                    g.FillRectangle(b, XF - 1, YF / 2 - 1, rsr.Width, rsr.Height);
                    #endregion

                    #region Show Border
                    X0 = 0; XF = tab.Width + X0;
                    Y0 = 0; YF = tab.Height + Y0;
                    P0 = new Point(X0, Y0);
                    PF = new Point(X0, Y0 + YF - 15);
                    Color BorderColor = BaseColor; c_origin = 255; BorderColor = SetTransparency(BorderColor, c_origin - i_opacity);
                    Pen PBorder = new Pen(BorderColor);
                    X = X0; Y = Y0; i_Zero = 270; D = 1; T = 5;
                    DrawArc(0);
                    g.DrawPath(PBorder, path);
                    X = X0; Y = Y0; i_Zero = 270; D = 1; T = 5;
                    DrawArc(1);
                    Color IBC = Color.White; c_origin = 164; IBC = SetTransparency(IBC, c_origin - i_opacity);
                    PBorder = new Pen(IBC);
                    g.DrawPath(PBorder, path);
                    #endregion
                }
                #endregion

                else if (tab.b_active & !tab.b_selected)
                {
                    #region Show Upper Rectangle
                    Rectangle upblock = new Rectangle(8, 3, bounds.Width - 16, 4);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(245, 250, 255)), upblock);
                    #endregion

                    #region Show Bottom Rectangle
                    Color CFsl = this.BaseColor;
                    Color C0sl = Color.FromArgb(CFsl.R + 19, CFsl.G + 15, CFsl.B + 10);
                    Rectangle doblock = new Rectangle(6, 3, bounds.Width - 12, bounds.Height);
                    Brush b = new LinearGradientBrush(doblock, C0sl, CFsl, LinearGradientMode.Vertical);
                    g.FillRectangle(b, doblock);
                    #endregion

                    #region Show Line Borders
                    Pen b2 = Pens.White; Pen b3 = Pens.White; Pen b4 = Pens.White;
                    int R0 = this.BaseColor.R;
                    int G0 = this.BaseColor.G;
                    int B0 = this.BaseColor.B;
                    int TX0 = 0; int TY0 = 0; int TXF = bounds.Width; int TYF = bounds.Height;
                    if (R0 != 0 & G0 != 0 & B0 != 0)
                    {

                        if (BaseColor.GetBrightness() < 0.5) //Dark Colors
                        {
                            b2 = new Pen(Color.FromArgb(R0 - 22, G0 - 11, B0));
                            b3 = new Pen(Color.FromArgb(R0 + 18, G0 + 25, B0));
                            b4 = new Pen(Color.FromArgb(R0, G0, B0));
                        }
                        else
                        {
                            b2 = new Pen(Color.FromArgb(R0 - 74, G0 - 49, B0 - 15));
                            b3 = new Pen(Color.FromArgb(R0 - 8, G0 - 24, B0 + 10));
                            b4 = new Pen(Color.FromArgb(R0, G0, B0));
                        }


                        DrawTab(TX0, TY0, TXF, TYF);
                        g.DrawPath(b2, path);
                        DrawTab(TX0 + 1, TY0 + 1, TXF - 1, TYF);
                        g.DrawPath(b3, path);
                        DrawTab(TX0 + 2, TY0 + 2, TXF - 2, TYF);
                        g.DrawPath(b4, path);

                    }
                    #endregion

                    #region Show Shadow
                    Point P0 = new Point(bounds.Right - 5, 3); Point PF = new Point(bounds.Right - 5, bounds.Height - 2);
                    Pen ps = new Pen(SetTransparency(Color.Black, 20));
                    g.DrawLine(ps, P0, PF);
                    P0 = new Point(bounds.Right - 4, 4); PF = new Point(bounds.Right - 4, bounds.Height - 1);
                    ps = new Pen(SetTransparency(Color.Black, 10));
                    g.DrawLine(ps, P0, PF);
                    #endregion

                }
                else if (tab.b_active & tab.b_selected)
                {
                    #region Show Upper Rectangle
                    Rectangle upblock = new Rectangle(8, 3, bounds.Width - 16, 4);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(245, 250, 255)), upblock);
                    #endregion

                    #region Show Bottom Rectangle
                    Color CFsl = this.BaseColor;
                    Color C0sl = Color.FromArgb(CFsl.R + 19, CFsl.G + 15, CFsl.B + 10);
                    Rectangle doblock = new Rectangle(6, 3, bounds.Width - 12, bounds.Height);
                    Brush b = new LinearGradientBrush(doblock, C0sl, CFsl, LinearGradientMode.Vertical);
                    g.FillRectangle(b, doblock);
                    #endregion

                    #region Show Line Borders
                    Pen b2 = Pens.White; Pen b3 = Pens.White; Pen b4 = Pens.White;
                    int R0 = this.BaseColor.R;
                    int G0 = this.BaseColor.G;
                    int B0 = this.BaseColor.B;
                    int TX0 = 0; int TY0 = 0; int TXF = bounds.Width; int TYF = bounds.Height;
                    if (R0 != 0 & G0 != 0 & B0 != 0)
                    {

                        if (BaseColor.GetBrightness() < 0.5) //Dark Colors
                        {
                            b2 = new Pen(Color.FromArgb(R0 - 26, G0 - 14, B0 - 3));
                            b3 = new Pen(Color.FromArgb(R0 + 18, G0 + 25, B0));
                            b4 = new Pen(Color.FromArgb(R0, G0, B0));
                        }
                        else
                        {
                            b2 = new Pen(Color.FromArgb(R0 - 74, G0 - 49, B0 - 15));
                            b3 = new Pen(Color.FromArgb(R0 - 8, G0 - 24, B0 + 10));
                            b4 = new Pen(Color.FromArgb(R0, G0, B0));
                        }


                        DrawTab(TX0, TY0, TXF, TYF);
                        g.DrawPath(b2, path);
                        DrawTab(TX0 + 1, TY0 + 1, TXF - 1, TYF);
                        g.DrawPath(b3, path);
                        DrawTab(TX0 + 2, TY0 + 2, TXF - 2, TYF);
                        g.DrawPath(b4, path);

                    }
                    #endregion

                    #region Show Shadow
                    Point P0 = new Point(bounds.Right - 5, 3); Point PF = new Point(bounds.Right - 5, bounds.Height - 2);
                    Pen ps = new Pen(SetTransparency(Color.Black, 20));
                    g.DrawLine(ps, P0, PF);
                    P0 = new Point(bounds.Right - 4, 4); PF = new Point(bounds.Right - 4, bounds.Height - 1);
                    ps = new Pen(SetTransparency(Color.Black, 10));
                    g.DrawLine(ps, P0, PF);
                    #endregion

                    #region Show Halo
                    Color CH = halocolor; int c_origin = 255; CH = SetTransparency(CH, c_origin - i_opacity);
                    DrawHalo(TX0, TY0, TXF, TYF);
                    g.DrawPath(new Pen(CH), path);
                    DrawHalo(TX0 + 1, TY0 + 1, TXF + 1, TYF);
                    g.DrawPath(new Pen(CH), path);
                    #endregion

                }

            }
            else
            {
                base.OnRenderButtonBackground(e);
            }

        }





        /// <summary>
        /// Control how the border of the toolstrip draws - keep track of if there's
        /// a selected tab and make that look "connected" by skipping drawing a line through it.
        /// </summary>
        /// <param name="VOff">The v off.</param>
        /*  protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) {
             TabStrip tabStrip = e.ToolStrip as TabStrip;
           
              using (Pen outerBlueBorderPen = new Pen(Color.Red)) {
                  using (Pen innerWhiteBorderPen = new Pen(Color.Red))
                  {
                      if (tabStrip != null) {
                          if (tabStrip.SelectedTab != null) {
                              // left border coords
                              Point borderStart1 = new Point(0, tabStrip.SelectedTab.Bounds.Bottom);
                              Point borderStop1 = new Point(tabStrip.SelectedTab.Bounds.Left, tabStrip.SelectedTab.Bounds.Bottom);

                              // right border coords
                              Point borderStart2 = new Point(tabStrip.SelectedTab.Bounds.Right - 1, tabStrip.SelectedTab.Bounds.Bottom);
                              Point borderStop2 = new Point(tabStrip.ClientRectangle.Right, tabStrip.SelectedTab.Bounds.Bottom);

                              e.Graphics.DrawLine(outerBlueBorderPen, borderStart1, borderStop1);
                              e.Graphics.DrawLine(outerBlueBorderPen, borderStart2, borderStop2);

                              // shift all points down one to draw the white line
                              borderStop1.Offset(0, 1);
                              borderStart1.Offset(0, 1);
                              borderStart2.Offset(0, 1);
                              borderStop2.Offset(0, 1);
                              e.Graphics.DrawLine(innerWhiteBorderPen, borderStart1, borderStop1);
                              e.Graphics.DrawLine(innerWhiteBorderPen, borderStart2, borderStop2);

                          }
                          else {
                              e.Graphics.DrawLine(outerBlueBorderPen, new Point(0, tabStrip.DisplayRectangle.Bottom), new Point(tabStrip.Width, tabStrip.DisplayRectangle.Bottom));
                              e.Graphics.DrawLine(innerWhiteBorderPen, new Point(0, tabStrip.DisplayRectangle.Bottom + 1), new Point(tabStrip.Width, tabStrip.DisplayRectangle.Bottom + 1));
                            

                          }   

                      }
                  }
              }
            
          }
       */

        public void DrawArc(int VOff)
        {
            i_Zero = 180; X0 = X0 + D; XF = XF - D; Y0 = Y0 + VOff;
            path = new GraphicsPath();
            Point P0 = new Point(X0, YF); Point PF = new Point(X0, Y0 + T);
            path.AddLine(P0, PF);
            path.AddArc(X0, Y0, T, T, i_Zero, i_Sweep); i_Zero += 90;
            P0 = new Point(X0 + T, Y0); PF = new Point(XF - T, Y0);
            path.AddLine(P0, PF);
            path.AddArc(XF - T - 1, Y0, T, T, i_Zero, i_Sweep);
            P0 = new Point(XF - 1, Y0 + T); PF = new Point(XF - 1, YF);
            path.AddLine(P0, PF);
        }

        /// <summary>
        /// Draws the tab.
        /// </summary>
        /// <param name="_X0">The x0.</param>
        /// <param name="_Y0">The y0.</param>
        /// <param name="_XF">The xf.</param>
        /// <param name="_YF">The yf.</param>
        public void DrawTab(int _X0, int _Y0, int _XF, int _YF)
        {
            T = 6; i_Zero = 90;
            path = new GraphicsPath();
            Point P0 = new Point(_X0, _YF); Point PF = new Point(_X0 + T, _YF - T);
            path.AddArc(_X0, _YF - T, T, T, i_Zero, -i_Sweep); i_Zero = 180; //path.AddLine(P0, PF); // _/
            path.AddArc(_X0 + T, _Y0, T, T, i_Zero, i_Sweep); i_Zero = 270; // path.AddLine(P0, PF); // /-
            path.AddArc(_XF - 2 * T, _Y0, T, T, i_Zero, i_Sweep); i_Zero = 180; // path.AddLine(P0, PF); // /-
            path.AddArc(_XF - T, _YF - T, T, T, i_Zero, -i_Sweep); // path.AddLine(P0, PF); // /-
        }

        /// <summary>
        /// Draws the halo.
        /// </summary>
        /// <param name="_X0">The x0.</param>
        /// <param name="_Y0">The y0.</param>
        /// <param name="_XF">The xf.</param>
        /// <param name="_YF">The yf.</param>
        public void DrawHalo(int _X0, int _Y0, int _XF, int _YF)
        {
            path = new GraphicsPath();
            Point P0 = new Point(_X0 + 5, _YF - 3); Point PF = new Point(_X0 + 6, _Y0 + 3);
            path.AddLine(P0, PF);
            P0 = new Point(_X0 + 7, _Y0); PF = new Point(_XF - 8, _Y0);
            path.AddLine(P0, PF);
            P0 = new Point(_XF - 7, _Y0 + 3); PF = new Point(_XF - 6, _YF - 3);
            path.AddLine(P0, PF);
        }

        /// <summary>
        /// Handles the <see cref="E:RenderToolStripBorder" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs" /> that contains the event data.</param>
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }

        
    }
}
