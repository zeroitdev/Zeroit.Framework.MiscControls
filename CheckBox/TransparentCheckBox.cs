// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="TransparentCheckBox.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Security;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region Zeroit CheckBox Transparent

    #region CheckBox    
    /// <summary>
    /// A class collection for rendering a transparent checkbox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.CheckBox" />
    [ToolboxBitmapAttribute(typeof(CheckBox))]
    public class ZeroitCheckBoxTransparent : CheckBox
    {

        #region Private Fields

        /// <summary>
        /// The flat style
        /// </summary>
        private FlatStyle _FlatStyle = FlatStyle.System;

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the flat style appearance of the button control.
        /// </summary>
        /// <value>The flat style.</value>
        [DefaultValueAttribute(typeof(FlatStyle), "System")]
        public new FlatStyle FlatStyle
        {
            get
            {
                return this._FlatStyle;
            }
            set
            {
                if (this._FlatStyle.Equals(value))
                {
                    return;
                }
                this._FlatStyle = value;
                if (this._FlatStyle.Equals(FlatStyle.System))
                {
                    base.FlatStyle = FlatStyle.Standard;
                }
                else
                {
                    base.FlatStyle = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets the background color of the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [DefaultValueAttribute(typeof(System.Drawing.Color), "Transparent")]
        public override System.Drawing.Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCheckBoxTransparent" /> class.
        /// </summary>
        public ZeroitCheckBoxTransparent()
            : base()
        {
            this.SetDefaultControlStyles();
            this.customInitialisation();
        }

        #endregion

        #region Methods and Overrides

        /// <summary>
        /// Sets the default control styles.
        /// </summary>
        private void SetDefaultControlStyles()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        /// <summary>
        /// Customs the initialisation.
        /// </summary>
        private void customInitialisation()
        {
            this.SuspendLayout();
            this._FlatStyle = FlatStyle.System;
            this.BackColor = Color.Transparent;
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this._FlatStyle.Equals(FlatStyle.System))
            {
                DrawingHelper.DrawCheckBox(e.Graphics, this.GetCheckBoxRectangle(), false, this.CheckState);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (this._FlatStyle.Equals(FlatStyle.System))
            {
                Graphics graph = this.CreateGraphics();
                DrawingHelper.DrawCheckBox(graph, this.GetCheckBoxRectangle(), false, this.CheckState);
                graph.Dispose();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (this._FlatStyle.Equals(FlatStyle.System))
            {
                Graphics graph = this.CreateGraphics();
                DrawingHelper.DrawCheckBox(graph, this.GetCheckBoxRectangle(), true, this.CheckState);
                graph.Dispose();
            }
        }

        /// <summary>
        /// Handles the <see cref="E:MouseUp" /> event.
        /// </summary>
        /// <param name="mevent">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if (this._FlatStyle.Equals(FlatStyle.System))
            {
                Graphics graph = this.CreateGraphics();
                DrawingHelper.DrawCheckBox(graph, this.GetCheckBoxRectangle(), true, this.CheckState);
                graph.Dispose();
            }
        }

        /// <summary>
        /// Gets the CheckBox rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        protected Rectangle GetCheckBoxRectangle()
        {
            int x = 0;
            int y = 2;
            int w = 12;
            if (this.CheckAlign == ContentAlignment.BottomCenter)
            {
                x = DrawingHelper.ToInt32((this.Width - w) / 2) - 1;
                y = this.Height - w - 2;
            }
            else if (this.CheckAlign == ContentAlignment.BottomLeft)
            {
                y = this.Height - w - 2;
            }
            else if (this.CheckAlign == ContentAlignment.BottomRight)
            {
                x = this.Width - w - 2;
                y = this.Height - w - 2;
            }
            else if (this.CheckAlign == ContentAlignment.MiddleCenter)
            {
                x = DrawingHelper.ToInt32((this.Width - w) / 2) - 1;
                y = DrawingHelper.ToInt32((this.Height - w) / 2) - 1;
            }
            else if (this.CheckAlign == ContentAlignment.MiddleLeft)
            {
                y = DrawingHelper.ToInt32((this.Height - w) / 2) - 1;
            }
            else if (this.CheckAlign == ContentAlignment.MiddleRight)
            {
                x = this.Width - w - 2;
                y = DrawingHelper.ToInt32((this.Height - w) / 2) - 1;
            }
            else if (this.CheckAlign == ContentAlignment.TopCenter)
            {
                x = DrawingHelper.ToInt32((this.Width - w) / 2) - 1;
            }
            else if (this.CheckAlign == ContentAlignment.TopLeft)
            {
            }
            else if (this.CheckAlign == ContentAlignment.TopRight)
            {
                x = this.Width - w - 2;
            }
            return new Rectangle(x, y, w, w);
        } 
        #endregion


    }

    #endregion

    #region CustomColors


    /// <summary>
    /// Class CustomColors.
    /// </summary>
    public class CustomColors
    {
        /// <summary>
        /// The no theme
        /// </summary>
        public const int NoTheme = 1;
        /// <summary>
        /// The normal color
        /// </summary>
        public const int NormalColor = 1;
        /// <summary>
        /// The home stead
        /// </summary>
        public const int HomeStead = 2;
        /// <summary>
        /// The metallic
        /// </summary>
        public const int Metallic = 3;
        /// <summary>
        /// The explorer bar header font
        /// </summary>
        private static Color[] _ExplorerBarHeaderFont = { Color.FromArgb(33, 93, 198), Color.FromArgb(86, 102, 45), Color.FromArgb(63, 61, 61) };
        /// <summary>
        /// The CheckBox hover light
        /// </summary>
        private static Color[] _CheckBoxHoverLight = { Color.FromArgb(255, 240, 207), Color.FromArgb(255, 240, 207), Color.FromArgb(255, 240, 207) };
        /// <summary>
        /// The CheckBox hover dark
        /// </summary>
        private static Color[] _CheckBoxHoverDark = { Color.FromArgb(249, 179, 48), Color.FromArgb(249, 179, 48), Color.FromArgb(249, 179, 48) };
        /// <summary>
        /// The CheckBox check
        /// </summary>
        private static Color[] _CheckBoxCheck = { Color.FromArgb(33, 161, 33), Color.FromArgb(33, 161, 33), Color.FromArgb(33, 161, 33) };

        /// <summary>
        /// Gets the CheckBox hover light.
        /// </summary>
        /// <value>The CheckBox hover light.</value>
        public static Color CheckBoxHoverLight
        {
            get
            {
                return _CheckBoxHoverLight[CurrentThemeIndex - 1];
            }
        }

        /// <summary>
        /// Gets the CheckBox hover dark.
        /// </summary>
        /// <value>The CheckBox hover dark.</value>
        public static Color CheckBoxHoverDark
        {
            get
            {
                return _CheckBoxHoverDark[CurrentThemeIndex - 1];
            }
        }

        /// <summary>
        /// Gets the CheckBox border.
        /// </summary>
        /// <value>The CheckBox border.</value>
        public static Color CheckBoxBorder
        {
            get
            {
                return _ExplorerBarHeaderFont[CurrentThemeIndex - 1];
            }
        }

        /// <summary>
        /// Gets the CheckBox check.
        /// </summary>
        /// <value>The CheckBox check.</value>
        public static Color CheckBoxCheck
        {
            get
            {
                return _CheckBoxCheck[CurrentThemeIndex - 1];
            }
        }

        /// <summary>
        /// Gets the index of the current theme.
        /// </summary>
        /// <value>The index of the current theme.</value>
        private static int CurrentThemeIndex
        {
            get
            {
                int index = CustomColors.NoTheme;
                if (CustomColors.ThemesSupported.Equals(true))
                {
                    try
                    {
                        index = CustomColors.CurrentThemeIndexInternal;
                    }
                    catch
                    {
                        index = CustomColors.NoTheme;
                    }
                    finally
                    {
                    }
                }
                return index;
            }
        }

        /// <summary>
        /// Gets the current theme index internal.
        /// </summary>
        /// <value>The current theme index internal.</value>
        private static int CurrentThemeIndexInternal
        {
            get
            {
                try
                {
                    System.Text.StringBuilder sbFile = new System.Text.StringBuilder(255);
                    System.Text.StringBuilder sbColor = new System.Text.StringBuilder(255);
                    UnsafeNativeMethods.GetCurrentThemeName(sbFile, sbFile.Capacity, sbColor, sbColor.Capacity, null, 0);
                    if (sbColor.ToString().ToUpper().Trim() == "NORMALCOLOR")
                    {
                        return CustomColors.NormalColor;
                    }
                    else if (sbColor.ToString().ToUpper().Trim() == "HOMESTEAD")
                    {
                        return CustomColors.HomeStead;
                    }
                    else if (sbColor.ToString().ToUpper().Trim() == "METALLIC")
                    {
                        return CustomColors.Metallic;
                    }
                    return CustomColors.Metallic;
                }
                catch
                {
                    return CustomColors.NoTheme;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [themes supported].
        /// </summary>
        /// <value><c>true</c> if [themes supported]; otherwise, <c>false</c>.</value>
        public static bool ThemesSupported
        {
            get
            {
                if ((System.Environment.OSVersion.Version.Major > 4) && (System.Environment.OSVersion.Version.Minor > 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="CustomColors"/> class from being created.
        /// </summary>
        private CustomColors()
        {
        }
        /// <summary>
        /// Class UnsafeNativeMethods.
        /// </summary>
        [SuppressUnmanagedCodeSecurity()]
        private class UnsafeNativeMethods
        {

            /// <summary>
            /// Gets the name of the current theme.
            /// </summary>
            /// <param name="sbThemeFileName">Name of the sb theme file.</param>
            /// <param name="maxNameChars">The maximum name chars.</param>
            /// <param name="sbColorScheme">The sb color scheme.</param>
            /// <param name="maxColorChars">The maximum color chars.</param>
            /// <param name="sbSizeName">Name of the sb size.</param>
            /// <param name="maxSizeChars">The maximum size chars.</param>
            [System.Runtime.InteropServices.DllImportAttribute("uxtheme.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
            public static extern void GetCurrentThemeName(System.Text.StringBuilder sbThemeFileName, int maxNameChars, System.Text.StringBuilder sbColorScheme, int maxColorChars, System.Text.StringBuilder sbSizeName, int maxSizeChars);
        }
    }
    #endregion

    #region DrawingHelper
    /// <summary>
    /// Class DrawingHelper.
    /// </summary>
    public class DrawingHelper
    {

        /// <summary>
        /// Draws the CheckBox.
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="hot">if set to <c>true</c> [hot].</param>
        /// <param name="state">The state.</param>
        public static void DrawCheckBox(Graphics graph, Rectangle rect, bool hot, CheckState state)
        {
            DrawCheckBackground(graph, rect);
            if (hot.Equals(true))
            {
                DrawCheckHot(graph, rect);
            }
            DrawCheckState(graph, rect, state);
        }

        /// <summary>
        /// Draws the check background.
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="rect">The rect.</param>
        private static void DrawCheckBackground(Graphics graph, Rectangle rect)
        {
            LinearGradientBrush fillBrush;
            fillBrush = new LinearGradientBrush(rect, SystemColors.ControlLightLight, SystemColors.ControlDark, LinearGradientMode.ForwardDiagonal);
            fillBrush.SetSigmaBellShape(0F, 0.5F);
            Pen borderPen;
            borderPen = new Pen(CustomColors.CheckBoxBorder, 1);
            graph.FillRectangle(fillBrush, rect);
            graph.DrawRectangle(borderPen, rect);
            fillBrush.Dispose();
            borderPen.Dispose();
        }

        /// <summary>
        /// Draws the check hot.
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="rect">The rect.</param>
        private static void DrawCheckHot(Graphics graph, Rectangle rect)
        {
            LinearGradientBrush fillBrush;
            Pen hotPen;
            fillBrush = new LinearGradientBrush(rect, CustomColors.CheckBoxHoverLight, CustomColors.CheckBoxHoverDark, LinearGradientMode.ForwardDiagonal);
            float[] relativeIntensities = { 0F, 0.7F, 1F };
            float[] relativePositions = { 0F, 0.5F, 1F };
            Blend blend = new Blend();
            blend.Factors = relativeIntensities;
            blend.Positions = relativePositions;
            fillBrush.Blend = blend;
            hotPen = new Pen(fillBrush, 1);
            Rectangle rect1 = new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
            Rectangle rect2 = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4);
            graph.DrawRectangles(hotPen, new Rectangle[] { rect1, rect2 });
            fillBrush.Dispose();
            hotPen.Dispose();
        }

        /// <summary>
        /// Draws the state of the check.
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="state">The state.</param>
        private static void DrawCheckState(Graphics graph, Rectangle rect, CheckState state)
        {
            if (state == CheckState.Checked)
            {
                Pen checkPen;
                checkPen = new Pen(CustomColors.CheckBoxCheck, 1);
                System.Drawing.PointF[] points;
                points = new System.Drawing.PointF[] { new System.Drawing.PointF(rect.X + 3, rect.Y + 5), new System.Drawing.PointF(rect.X + 5, rect.Y + 7), new System.Drawing.PointF(rect.X + 9, rect.Y + 3), new System.Drawing.PointF(rect.X + 9, rect.Y + 4), new System.Drawing.PointF(rect.X + 5, rect.Y + 8), new System.Drawing.PointF(rect.X + 3, rect.Y + 6), new System.Drawing.PointF(rect.X + 3, rect.Y + 7), new System.Drawing.PointF(rect.X + 5, rect.Y + 9), new System.Drawing.PointF(rect.X + 9, rect.Y + 5) };
                graph.DrawLines(checkPen, points);
                checkPen.Dispose();
            }
            else if (state == CheckState.Indeterminate)
            {
                Brush checkBrush;
                checkBrush = new SolidBrush(CustomColors.CheckBoxCheck);
                Rectangle rect1 = new Rectangle(rect.X + 3, rect.Y + 3, rect.Width - 5, rect.Height - 5);
                graph.FillRectangle(checkBrush, rect1);
                checkBrush.Dispose();
            }
            else if (state == CheckState.Unchecked)
            {
            }
        }

        /// <summary>
        /// To the int32.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        public static int ToInt32(double value)
        {
            decimal decValue = new decimal(value);
            return Decimal.ToInt32(Decimal.Floor(decValue));
        }

    }

    #endregion

    #endregion


}
