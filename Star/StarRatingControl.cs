// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="StarRatingControl.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Rating Star

    #region Control    
    /// <summary>
    /// A class collection for rendering a star rating control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitRating : System.Windows.Forms.Control
    {


        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.AntiAlias;

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRating" /> class.
        /// </summary>
        public ZeroitRating()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            Width = 120;
            Height = 18;

            m_starAreas = new Rectangle[StarCount];
        }

        #region Properties        
        /// <summary>
        /// Gets or sets the left margin.
        /// </summary>
        /// <value>The left margin.</value>
        public int LeftMargin
        {
            get
            {
                return m_leftMargin;
            }
            set
            {
                if (m_leftMargin != value)
                {
                    m_leftMargin = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the right margin.
        /// </summary>
        /// <value>The right margin.</value>
        public int RightMargin
        {
            get
            {
                return m_rightMargin;
            }
            set
            {
                if (m_rightMargin != value)
                {
                    m_rightMargin = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the top margin.
        /// </summary>
        /// <value>The top margin.</value>
        public int TopMargin
        {
            get
            {
                return m_topMargin;
            }
            set
            {
                if (m_topMargin != value)
                {
                    m_topMargin = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the bottom margin.
        /// </summary>
        /// <value>The bottom margin.</value>
        public int BottomMargin
        {
            get
            {
                return m_bottomMargin;
            }
            set
            {
                if (m_bottomMargin != value)
                {
                    m_bottomMargin = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the star spacing.
        /// </summary>
        /// <value>The star spacing.</value>
        public int StarSpacing
        {
            get
            {
                return m_starSpacing;
            }
            set
            {
                if (m_starSpacing != value)
                {
                    m_starSpacing = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the star count.
        /// </summary>
        /// <value>The star count.</value>
        public int StarCount
        {
            get
            {
                return m_starCount;
            }
            set
            {
                if (m_starCount != value)
                {
                    m_starCount = value;
                    m_starAreas = new Rectangle[m_starCount];
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this controls is hovered.
        /// </summary>
        /// <value><c>true</c> if this instance is hovering; otherwise, <c>false</c>.</value>
        public bool IsHovering
        {
            get
            {
                return m_hovering;
            }
        }

        /// <summary>
        /// Gets or sets the color of the outline.
        /// </summary>
        /// <value>The color of the outline.</value>
        public Color OutlineColor
        {
            get
            {
                return m_outlineColor;
            }
            set
            {
                if (m_outlineColor != value)
                {
                    m_outlineColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the control when hovered.
        /// </summary>
        /// <value>The color of the hover.</value>
        public Color HoverColor
        {
            get
            {
                return m_hoverColor;
            }
            set
            {
                if (m_hoverColor != value)
                {
                    m_hoverColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the selected control.
        /// </summary>
        /// <value>The color of the selected.</value>
        public Color SelectedColor
        {
            get
            {
                return m_selectedColor;
            }
            set
            {
                if (m_selectedColor != value)
                {
                    m_selectedColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the outline thickness.
        /// </summary>
        /// <value>The outline thickness.</value>
        public int OutlineThickness
        {
            get
            {
                return m_outlineThickness;
            }
            set
            {
                if (m_outlineThickness != value)
                {
                    m_outlineThickness = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets the hover star.
        /// </summary>
        /// <value>The hover star.</value>
        public int HoverStar
        {
            get
            {
                return m_hoverStar;
            }
        }

        /// <summary>
        /// Gets the selected star.
        /// </summary>
        /// <value>The selected star.</value>
        public int SelectedStar
        {
            get
            {
                return m_selectedStar;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Draws the star.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="starAreaIndex">Index of the star area.</param>
        protected void DrawStar(Graphics g, Rectangle rect, int starAreaIndex)
        {
            Brush fillBrush;
            Pen outlinePen = new Pen(OutlineColor, OutlineThickness);

            if (m_hovering && m_hoverStar > starAreaIndex)
            {
                fillBrush = new LinearGradientBrush(rect, HoverColor, BackColor, LinearGradientMode.ForwardDiagonal);
            }
            else if ((!m_hovering) && m_selectedStar > starAreaIndex)
            {
                fillBrush = new LinearGradientBrush(rect, SelectedColor, BackColor, LinearGradientMode.ForwardDiagonal);
            }
            else
            {
                fillBrush = new SolidBrush(BackColor);
            }

            PointF[] p = new PointF[10];
            p[0].X = rect.X + (rect.Width / 2);
            p[0].Y = rect.Y;
            p[1].X = rect.X + (42 * rect.Width / 64);
            p[1].Y = rect.Y + (19 * rect.Height / 64);
            p[2].X = rect.X + rect.Width;
            p[2].Y = rect.Y + (22 * rect.Height / 64);
            p[3].X = rect.X + (48 * rect.Width / 64);
            p[3].Y = rect.Y + (38 * rect.Height / 64);
            p[4].X = rect.X + (52 * rect.Width / 64);
            p[4].Y = rect.Y + rect.Height;
            p[5].X = rect.X + (rect.Width / 2);
            p[5].Y = rect.Y + (52 * rect.Height / 64);
            p[6].X = rect.X + (12 * rect.Width / 64);
            p[6].Y = rect.Y + rect.Height;
            p[7].X = rect.X + rect.Width / 4;
            p[7].Y = rect.Y + (38 * rect.Height / 64);
            p[8].X = rect.X;
            p[8].Y = rect.Y + (22 * rect.Height / 64);
            p[9].X = rect.X + (22 * rect.Width / 64);
            p[9].Y = rect.Y + (19 * rect.Height / 64);

            g.FillPolygon(fillBrush, p);
            g.DrawPolygon(outlinePen, p);
        }

        #endregion

        #region Overrides
        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="pe">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.SmoothingMode = smoothing;
            pe.Graphics.Clear(BackColor);

            int starWidth = (Width - (LeftMargin + RightMargin + (StarSpacing * (StarCount - 1)))) / StarCount;
            int starHeight = (Height - (TopMargin + BottomMargin));

            Rectangle drawArea = new Rectangle(LeftMargin, TopMargin, starWidth, starHeight);

            for (int i = 0; i < StarCount; ++i)
            {
                m_starAreas[i].X = drawArea.X - StarSpacing / 2;
                m_starAreas[i].Y = drawArea.Y;
                m_starAreas[i].Width = drawArea.Width + StarSpacing / 2;
                m_starAreas[i].Height = drawArea.Height;

                DrawStar(pe.Graphics, drawArea, i);

                drawArea.X += drawArea.Width + StarSpacing;
            }

            base.OnPaint(pe);
        }

        /// <summary>
        /// Handles the <see cref="E:MouseEnter" /> event.
        /// </summary>
        /// <param name="ea">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseEnter(System.EventArgs ea)
        {
            m_hovering = true;
            Invalidate();
            base.OnMouseEnter(ea);
        }

        /// <summary>
        /// Handles the <see cref="E:MouseLeave" /> event.
        /// </summary>
        /// <param name="ea">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseLeave(System.EventArgs ea)
        {
            m_hovering = false;
            Invalidate();
            base.OnMouseLeave(ea);
        }

        /// <summary>
        /// Handles the <see cref="E:MouseMove" /> event.
        /// </summary>
        /// <param name="args">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseMove(MouseEventArgs args)
        {
            for (int i = 0; i < StarCount; ++i)
            {
                if (m_starAreas[i].Contains(args.X, args.Y))
                {
                    m_hoverStar = i + 1;
                    Invalidate();
                    break;
                }
            }

            base.OnMouseMove(args);
        }

        /// <summary>
        /// Handles the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnClick(System.EventArgs args)
        {
            Point p = PointToClient(MousePosition);

            for (int i = 0; i < StarCount; ++i)
            {
                if (m_starAreas[i].Contains(p))
                {
                    m_hoverStar = i + 1;
                    m_selectedStar = i + 1;
                    Invalidate();
                    break;
                }
            }

            base.OnClick(args);
        }
        #endregion

        #region Protected Data

        /// <summary>
        /// The m left margin
        /// </summary>
        protected int m_leftMargin = 2;
        /// <summary>
        /// The m right margin
        /// </summary>
        protected int m_rightMargin = 2;
        /// <summary>
        /// The m top margin
        /// </summary>
        protected int m_topMargin = 2;
        /// <summary>
        /// The m bottom margin
        /// </summary>
        protected int m_bottomMargin = 2;
        /// <summary>
        /// The m star spacing
        /// </summary>
        protected int m_starSpacing = 8;
        /// <summary>
        /// The m star count
        /// </summary>
        protected int m_starCount = 5;
        /// <summary>
        /// The m star areas
        /// </summary>
        protected Rectangle[] m_starAreas;
        /// <summary>
        /// The m hovering
        /// </summary>
        protected bool m_hovering = false;

        /// <summary>
        /// The m hover star
        /// </summary>
        protected int m_hoverStar = 0;
        /// <summary>
        /// The m selected star
        /// </summary>
        protected int m_selectedStar = 0;

        /// <summary>
        /// The m outline color
        /// </summary>
        protected Color m_outlineColor = Color.DarkGray;
        /// <summary>
        /// The m hover color
        /// </summary>
        protected Color m_hoverColor = Color.Yellow;
        /// <summary>
        /// The m selected color
        /// </summary>
        protected Color m_selectedColor = Color.RoyalBlue;

        /// <summary>
        /// The m outline thickness
        /// </summary>
        protected int m_outlineThickness = 1;

        #endregion
    }

    #endregion

    #endregion
}
