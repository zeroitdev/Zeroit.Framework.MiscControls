// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PlainRadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{


    #region Helper Class for ZeroitRadioButtonPlain
    /// <summary>
    /// Class Helpers2.
    /// </summary>
    static class Helpers2
    {

        /// <summary>
        /// Enum MouseState
        /// </summary>
        public enum MouseState : byte
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The over
            /// </summary>
            Over = 1,
            /// <summary>
            /// Down
            /// </summary>
            Down = 2
        }

        /// <summary>
        /// Fulls the rectangle.
        /// </summary>
        /// <param name="S">The s.</param>
        /// <param name="Subtract">if set to <c>true</c> [subtract].</param>
        /// <returns>Rectangle.</returns>
        public static Rectangle FullRectangle(Size S, bool Subtract)
        {
            if (Subtract)
            {
                return new Rectangle(0, 0, S.Width - 1, S.Height - 1);
            }
            else
            {
                return new Rectangle(0, 0, S.Width, S.Height);
            }
        }

        /// <summary>
        /// Greys the color.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <returns>Color.</returns>
        public static Color GreyColor(int G)
        {
            return Color.FromArgb(G, G, G);
        }

        /// <summary>
        /// Centers the string.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="T">The t.</param>
        /// <param name="F">The f.</param>
        /// <param name="C">The c.</param>
        /// <param name="R">The r.</param>
        public static void CenterString(Graphics G, string T, Font F, Color C, Rectangle R)
        {
            SizeF TS = G.MeasureString(T, F);

            using (SolidBrush B = new SolidBrush(C))
            {
                G.DrawString(T, F, B, new Point((int)(R.Width / 2 - (TS.Width / 2)), (int)(R.Height / 2 - (TS.Height / 2))));
            }
        }


        /// <summary>
        /// Fills the round rect.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="R">The r.</param>
        /// <param name="Curve">The curve.</param>
        /// <param name="C">The c.</param>
        public static void FillRoundRect(Graphics G, Rectangle R, int Curve, Color C)
        {
            using (SolidBrush B = new SolidBrush(C))
            {
                G.FillPie(B, R.X, R.Y, Curve, Curve, 180, 90);
                G.FillPie(B, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
                G.FillPie(B, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
                G.FillPie(B, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
                G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), R.Y, R.Width - Curve, Convert.ToInt32(Curve / 2));
                G.FillRectangle(B, R.X, Convert.ToInt32(R.Y + Curve / 2), R.Width, R.Height - Curve);
                G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height - Curve / 2), R.Width - Curve, Convert.ToInt32(Curve / 2));
            }

        }


        /// <summary>
        /// Draws the round rect.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="R">The r.</param>
        /// <param name="Curve">The curve.</param>
        /// <param name="C">The c.</param>
        public static void DrawRoundRect(Graphics G, Rectangle R, int Curve, Color C)
        {
            using (Pen P = new Pen(C))
            {
                G.DrawArc(P, R.X, R.Y, Curve, Curve, 180, 90);
                G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), R.Y, Convert.ToInt32(R.X + R.Width - Curve / 2), R.Y);
                G.DrawArc(P, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
                G.DrawLine(P, R.X, Convert.ToInt32(R.Y + Curve / 2), R.X, Convert.ToInt32(R.Y + R.Height - Curve / 2));
                G.DrawLine(P, Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + Curve / 2), Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + R.Height - Curve / 2));
                G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height), Convert.ToInt32(R.X + R.Width - Curve / 2), Convert.ToInt32(R.Y + R.Height));
                G.DrawArc(P, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
                G.DrawArc(P, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
            }

        }


        /// <summary>
        /// Centers the string tab.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="shadow">if set to <c>true</c> [shadow].</param>
        /// <param name="yOffset">The y offset.</param>
        public static void CenterStringTab(Graphics G, string text, Font font, Brush brush, Rectangle rect, bool shadow = false, int yOffset = 0)
        {
            SizeF textSize = G.MeasureString(text, font);
            int textX = (int)(rect.X + (rect.Width / 2) - (textSize.Width / 2));
            int textY = (int)(rect.Y + (rect.Height / 2) - (textSize.Height / 2) + yOffset);

            if (shadow)
                G.DrawString(text, font, Brushes.Black, textX + 1, textY + 1);
            G.DrawString(text, font, brush, textX, textY + 1);

        }

    }
    #endregion

    #region Theme for ZeroitRadioButtonPlain, ZeroitCheckBoxTransparent
    /// <summary>
    /// Class Theme1.
    /// </summary>
    static class Theme1
    {

        /// <summary>
        /// Globals the font.
        /// </summary>
        /// <param name="B">The b.</param>
        /// <param name="S">The s.</param>
        /// <returns>Font.</returns>
        public static Font GlobalFont(FontStyle B, int S)
        {
            return new Font("Segoe UI", S, B);
        }

        /// <summary>
        /// Gets the check mark.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GetCheckMark()
        {
            return "iVBORw0KGgoAAAANSUhEUgAAABMAAAAQCAYAAAD0xERiAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAEySURBVDhPY/hPRUBdw/79+/efVHz77bf/X37+wRAn2bDff/7+91l+83/YmtsYBpJs2ITjz/8rTbrwP2Dlrf9XXn5FkSPJsD13P/y3nHsVbNjyy28w5Ik27NWXX//TNt8DG1S19zFWNRiGvfzy8//ccy9RxEB4wvFnYIMMZl7+//brLwx5EEYx7MP33/9dF18Ha1py8RVcHBR7mlMvgsVXX8X0Hgwz/P379z8yLtz5AKxJdcpFcBj9+v3nf/CqW2Cx5E13UdSiYwzDvv36/d9/BUSzzvRL/0t2PQSzQd57+vEHilp0jGEYCJ9+8hnuGhiee+4Vhjp0jNUwEN566/1/m/mQZJC/48H/zz9+YVWHjHEaBsKgwAZ59eH771jl0TFew0D48osvWMWxYYKGEY///gcAqiuA6kEmfEMAAAAASUVORK5CYII=";
        }

    }
    #endregion

    #region ZeroitRadioButtonPlain

    /// <summary>
    /// A class collection for rendering a radio button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitRadioButtonPlainDesigner))]
    [DefaultEvent("CheckedChanged")]
    public class ZeroitRadioButtonPlain : Control
    {

        #region " Public "
        /// <summary>
        /// Occurs when [checked changed].
        /// </summary>
        public event CheckedChangedEventHandler CheckedChanged;
        /// <summary>
        /// Delegate CheckedChangedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void CheckedChangedEventHandler(object sender, EventArgs e);
        #endregion

        #region " Private "
        /// <summary>
        /// The bold
        /// </summary>
        private bool _Bold;
        /// <summary>
        /// The state
        /// </summary>
        private Helpers2.MouseState State;
        //private Color ETC = borderColor;

        /// <summary>
        /// The g
        /// </summary>
        private Graphics G;
        /// <summary>
        /// The enabled calculate
        /// </summary>
        private bool _EnabledCalc;
        /// <summary>
        /// The checked
        /// </summary>
        private bool _Checked;

        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.Blue;
        /// <summary>
        /// The inner fill
        /// </summary>
        private Color innerFill = Color.FromArgb(34, 146, 208);
        /// <summary>
        /// The etc enabled
        /// </summary>
        private Color etcEnabled = Color.FromArgb(66, 78, 90);

        /// <summary>
        /// The checked width
        /// </summary>
        private int checkedWidth = 12;
        /// <summary>
        /// The unchecked width
        /// </summary>
        private int uncheckedWidth = 22;

        /// <summary>
        /// The text location x
        /// </summary>
        private int textLocationX = 32;
        /// <summary>
        /// The text location y
        /// </summary>
        private int textLocationY = 4;

        /// <summary>
        /// The inner fill location1 x
        /// </summary>
        private int innerFillLocation1X = 7;
        /// <summary>
        /// The inner fill location1 y
        /// </summary>
        private int innerFillLocation1Y = 7;

        /// <summary>
        /// The inner fill location2 x
        /// </summary>
        private int innerFillLocation2X = 2;
        /// <summary>
        /// The inner fill location2 y
        /// </summary>
        private int innerFillLocation2Y = 2;


        #region Brush Enum
        /// <summary>
        /// Enum Background
        /// </summary>
        private enum Background
        {
            /// <summary>
            /// The alice blue
            /// </summary>
            AliceBlue,
            /// <summary>
            /// The antique white
            /// </summary>
            AntiqueWhite,
            /// <summary>
            /// The aqua
            /// </summary>
            Aqua,
            /// <summary>
            /// The aquamarine
            /// </summary>
            Aquamarine,
            /// <summary>
            /// The azure
            /// </summary>
            Azure,
            /// <summary>
            /// The beige
            /// </summary>
            Beige,
            /// <summary>
            /// The bisque
            /// </summary>
            Bisque,
            /// <summary>
            /// The black
            /// </summary>
            Black,
            /// <summary>
            /// The blanched almond
            /// </summary>
            BlanchedAlmond,
            /// <summary>
            /// The blue
            /// </summary>
            Blue,
            /// <summary>
            /// The blue violet
            /// </summary>
            BlueViolet,
            /// <summary>
            /// The brown
            /// </summary>
            Brown,
            /// <summary>
            /// The burly wood
            /// </summary>
            BurlyWood,
            /// <summary>
            /// The cadet blue
            /// </summary>
            CadetBlue,
            /// <summary>
            /// The chartreuse
            /// </summary>
            Chartreuse,
            /// <summary>
            /// The chocolate
            /// </summary>
            Chocolate,
            /// <summary>
            /// The coral
            /// </summary>
            Coral,
            /// <summary>
            /// The cornflower blue
            /// </summary>
            CornflowerBlue,
            /// <summary>
            /// The cornsilk
            /// </summary>
            Cornsilk,
            /// <summary>
            /// The crimson
            /// </summary>
            Crimson,
            /// <summary>
            /// The cyan
            /// </summary>
            Cyan,
            /// <summary>
            /// The dark blue
            /// </summary>
            DarkBlue,
            /// <summary>
            /// The dark cyan
            /// </summary>
            DarkCyan,
            /// <summary>
            /// The dark goldenrod
            /// </summary>
            DarkGoldenrod,
            /// <summary>
            /// The dark gray
            /// </summary>
            DarkGray,
            /// <summary>
            /// The dark green
            /// </summary>
            DarkGreen,
            /// <summary>
            /// The dark khaki
            /// </summary>
            DarkKhaki,
            /// <summary>
            /// The dark magenta
            /// </summary>
            DarkMagenta,
            /// <summary>
            /// The dark olive green
            /// </summary>
            DarkOliveGreen,
            /// <summary>
            /// The dark orange
            /// </summary>
            DarkOrange,
            /// <summary>
            /// The dark orchid
            /// </summary>
            DarkOrchid,
            /// <summary>
            /// The dark red
            /// </summary>
            DarkRed,
            /// <summary>
            /// The dark salmon
            /// </summary>
            DarkSalmon,
            /// <summary>
            /// The dark sea green
            /// </summary>
            DarkSeaGreen,
            /// <summary>
            /// The dark slate blue
            /// </summary>
            DarkSlateBlue,
            /// <summary>
            /// The dark slate gray
            /// </summary>
            DarkSlateGray,
            /// <summary>
            /// The dark turquoise
            /// </summary>
            DarkTurquoise,
            /// <summary>
            /// The dark violet
            /// </summary>
            DarkViolet,
            /// <summary>
            /// The deep pink
            /// </summary>
            DeepPink,
            /// <summary>
            /// The deep sky blue
            /// </summary>
            DeepSkyBlue,
            /// <summary>
            /// The dim gray
            /// </summary>
            DimGray,
            /// <summary>
            /// The dodger blue
            /// </summary>
            DodgerBlue,
            /// <summary>
            /// The firebrick
            /// </summary>
            Firebrick,
            /// <summary>
            /// The floral white
            /// </summary>
            FloralWhite,
            /// <summary>
            /// The forest green
            /// </summary>
            ForestGreen,
            /// <summary>
            /// The fuchsia
            /// </summary>
            Fuchsia,
            /// <summary>
            /// The gainsboro
            /// </summary>
            Gainsboro,
            /// <summary>
            /// The ghost white
            /// </summary>
            GhostWhite,
            /// <summary>
            /// The gold
            /// </summary>
            Gold,
            /// <summary>
            /// The goldenrod
            /// </summary>
            Goldenrod,
            /// <summary>
            /// The gray
            /// </summary>
            Gray,
            /// <summary>
            /// The green
            /// </summary>
            Green,
            /// <summary>
            /// The green yellow
            /// </summary>
            GreenYellow,
            /// <summary>
            /// The honeydew
            /// </summary>
            Honeydew,
            /// <summary>
            /// The hot pink
            /// </summary>
            HotPink,
            /// <summary>
            /// The indian red
            /// </summary>
            IndianRed,
            /// <summary>
            /// The indigo
            /// </summary>
            Indigo,
            /// <summary>
            /// The ivory
            /// </summary>
            Ivory,
            /// <summary>
            /// The khaki
            /// </summary>
            Khaki,
            /// <summary>
            /// The lavender
            /// </summary>
            Lavender,
            /// <summary>
            /// The lavender blush
            /// </summary>
            LavenderBlush,
            /// <summary>
            /// The lawn green
            /// </summary>
            LawnGreen,
            /// <summary>
            /// The lemon chiffon
            /// </summary>
            LemonChiffon,
            /// <summary>
            /// The light blue
            /// </summary>
            LightBlue,
            /// <summary>
            /// The light coral
            /// </summary>
            LightCoral,
            /// <summary>
            /// The light cyan
            /// </summary>
            LightCyan,
            /// <summary>
            /// The light goldenrod yellow
            /// </summary>
            LightGoldenrodYellow,
            /// <summary>
            /// The light gray
            /// </summary>
            LightGray,
            /// <summary>
            /// The light green
            /// </summary>
            LightGreen,
            /// <summary>
            /// The light pink
            /// </summary>
            LightPink,
            /// <summary>
            /// The light salmon
            /// </summary>
            LightSalmon,
            /// <summary>
            /// The light sea green
            /// </summary>
            LightSeaGreen,
            /// <summary>
            /// The light sky blue
            /// </summary>
            LightSkyBlue,
            /// <summary>
            /// The light slate gray
            /// </summary>
            LightSlateGray,
            /// <summary>
            /// The light steel blue
            /// </summary>
            LightSteelBlue,
            /// <summary>
            /// The light yellow
            /// </summary>
            LightYellow,
            /// <summary>
            /// The lime
            /// </summary>
            Lime,
            /// <summary>
            /// The lime green
            /// </summary>
            LimeGreen,
            /// <summary>
            /// The linen
            /// </summary>
            Linen,
            /// <summary>
            /// The magenta
            /// </summary>
            Magenta,
            /// <summary>
            /// The maroon
            /// </summary>
            Maroon,
            /// <summary>
            /// The medium aquamarine
            /// </summary>
            MediumAquamarine,
            /// <summary>
            /// The medium blue
            /// </summary>
            MediumBlue,
            /// <summary>
            /// The medium orchid
            /// </summary>
            MediumOrchid,
            /// <summary>
            /// The medium purple
            /// </summary>
            MediumPurple,
            /// <summary>
            /// The medium sea green
            /// </summary>
            MediumSeaGreen,
            /// <summary>
            /// The medium slate blue
            /// </summary>
            MediumSlateBlue,
            /// <summary>
            /// The medium spring green
            /// </summary>
            MediumSpringGreen,
            /// <summary>
            /// The medium turquoise
            /// </summary>
            MediumTurquoise,
            /// <summary>
            /// The medium violet red
            /// </summary>
            MediumVioletRed,
            /// <summary>
            /// The midnight blue
            /// </summary>
            MidnightBlue,
            /// <summary>
            /// The mint cream
            /// </summary>
            MintCream,
            /// <summary>
            /// The misty rose
            /// </summary>
            MistyRose,
            /// <summary>
            /// The moccasin
            /// </summary>
            Moccasin,
            /// <summary>
            /// The navajo white
            /// </summary>
            NavajoWhite,
            /// <summary>
            /// The navy
            /// </summary>
            Navy,
            /// <summary>
            /// The old lace
            /// </summary>
            OldLace,
            /// <summary>
            /// The olive
            /// </summary>
            Olive,
            /// <summary>
            /// The olive drab
            /// </summary>
            OliveDrab,
            /// <summary>
            /// The orange
            /// </summary>
            Orange,
            /// <summary>
            /// The orange red
            /// </summary>
            OrangeRed,
            /// <summary>
            /// The orchid
            /// </summary>
            Orchid,
            /// <summary>
            /// The pale goldenrod
            /// </summary>
            PaleGoldenrod,
            /// <summary>
            /// The pale green
            /// </summary>
            PaleGreen,
            /// <summary>
            /// The pale turquoise
            /// </summary>
            PaleTurquoise,
            /// <summary>
            /// The pale violet red
            /// </summary>
            PaleVioletRed,
            /// <summary>
            /// The papaya whip
            /// </summary>
            PapayaWhip,
            /// <summary>
            /// The peach puff
            /// </summary>
            PeachPuff,
            /// <summary>
            /// The peru
            /// </summary>
            Peru,
            /// <summary>
            /// The pink
            /// </summary>
            Pink,
            /// <summary>
            /// The plum
            /// </summary>
            Plum,
            /// <summary>
            /// The powder blue
            /// </summary>
            PowderBlue,
            /// <summary>
            /// The purple
            /// </summary>
            Purple,
            /// <summary>
            /// The red
            /// </summary>
            Red,
            /// <summary>
            /// The rosy brown
            /// </summary>
            RosyBrown,
            /// <summary>
            /// The royal blue
            /// </summary>
            RoyalBlue,
            /// <summary>
            /// The saddle brown
            /// </summary>
            SaddleBrown,
            /// <summary>
            /// The salmon
            /// </summary>
            Salmon,
            /// <summary>
            /// The sandy brown
            /// </summary>
            SandyBrown,
            /// <summary>
            /// The sea green
            /// </summary>
            SeaGreen,
            /// <summary>
            /// The sea shell
            /// </summary>
            SeaShell,
            /// <summary>
            /// The sienna
            /// </summary>
            Sienna,
            /// <summary>
            /// The silver
            /// </summary>
            Silver,
            /// <summary>
            /// The sky blue
            /// </summary>
            SkyBlue,
            /// <summary>
            /// The slate blue
            /// </summary>
            SlateBlue,
            /// <summary>
            /// The slate gray
            /// </summary>
            SlateGray,
            /// <summary>
            /// The snow
            /// </summary>
            Snow,
            /// <summary>
            /// The spring green
            /// </summary>
            SpringGreen,
            /// <summary>
            /// The steel blue
            /// </summary>
            SteelBlue,
            /// <summary>
            /// The tan
            /// </summary>
            Tan,
            /// <summary>
            /// The teal
            /// </summary>
            Teal,
            /// <summary>
            /// The thistle
            /// </summary>
            Thistle,
            /// <summary>
            /// The tomato
            /// </summary>
            Tomato,
            /// <summary>
            /// The transparent
            /// </summary>
            Transparent,
            /// <summary>
            /// The turquoise
            /// </summary>
            Turquoise,
            /// <summary>
            /// The violet
            /// </summary>
            Violet,
            /// <summary>
            /// The wheat
            /// </summary>
            Wheat,
            /// <summary>
            /// The white
            /// </summary>
            White,
            /// <summary>
            /// The white smoke
            /// </summary>
            WhiteSmoke,
            /// <summary>
            /// The yellow green
            /// </summary>
            YellowGreen
        }

        #endregion


        #endregion

        #region " Properties "        
        /// <summary>
        /// Gets or sets the color of the etc.
        /// </summary>
        /// <value>The color of the etc.</value>
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner fill.
        /// </summary>
        /// <value>The inner fill.</value>
        public Color InnerFill
        {
            get { return innerFill; }
            set
            {
                innerFill = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the etc enabled.
        /// </summary>
        /// <value>The color of the etc enabled.</value>
        public Color ETCEnabledColor
        {
            get { return etcEnabled; }
            set
            {
                etcEnabled = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the checked.
        /// </summary>
        /// <value>The width of the checked.</value>
        public int CheckedWidth
        {
            get { return checkedWidth; }
            set
            {
                checkedWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the unchecked.
        /// </summary>
        /// <value>The width of the unchecked.</value>
        public int UncheckedWidth
        {
            get { return uncheckedWidth; }
            set
            {
                uncheckedWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text location x.
        /// </summary>
        /// <value>The text location x.</value>
        public int TextLocationX
        {
            get { return textLocationX; }
            set
            {
                textLocationX = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text location y.
        /// </summary>
        /// <value>The text location y.</value>
        public int TextLocationY
        {
            get { return textLocationY; }
            set
            {
                textLocationY = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner fill location1 x.
        /// </summary>
        /// <value>The inner fill location1 x.</value>
        public int InnerFillLocation1X
        {
            get { return innerFillLocation1X; }
            set
            {
                innerFillLocation1X = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner fill location1 y.
        /// </summary>
        /// <value>The inner fill location1 y.</value>
        public int InnerFillLocation1Y
        {
            get { return innerFillLocation1Y; }
            set
            {
                innerFillLocation1Y = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner fill location2 x.
        /// </summary>
        /// <value>The inner fill location2 x.</value>
        public int InnerFillLocation2X
        {
            get { return innerFillLocation2X; }
            set
            {
                innerFillLocation2X = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner fill location2 y.
        /// </summary>
        /// <value>The inner fill location2 y.</value>
        public int InnerFillLocation2Y
        {
            get { return innerFillLocation2Y; }
            set
            {
                innerFillLocation2Y = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitRadioButtonPlain"/> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control can respond to user interaction.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public new bool Enabled
        {
            get { return EnabledCalc; }
            set
            {
                _EnabledCalc = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enabled calculate].
        /// </summary>
        /// <value><c>true</c> if [enabled calculate]; otherwise, <c>false</c>.</value>
        [DisplayName("Enabled")]
        public bool EnabledCalc
        {
            get { return _EnabledCalc; }
            set
            {
                Enabled = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitRadioButtonPlain"/> is bold.
        /// </summary>
        /// <value><c>true</c> if bold; otherwise, <c>false</c>.</value>
        public bool Bold
        {
            get { return _Bold; }
            set
            {
                _Bold = value;
                Invalidate();
            }
        }

        #endregion

        #region " Control "        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRadioButtonPlain" /> class.
        /// </summary>
        public ZeroitRadioButtonPlain()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;

            DoubleBuffered = true;
            ForeColor = Color.White;
            Font = Theme1.GlobalFont(FontStyle.Regular, 10);
            Size = new Size(160, 27);
            Enabled = true;
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            //G.Clear(Parent.BackColor);

            if (Enabled)
            {
                //ETC = etcEnabled;

                switch (State)
                {

                    case Helpers2.MouseState.Over:
                    case Helpers2.MouseState.Down:

                        using (Pen P = new Pen(innerFill))
                        {
                            G.DrawEllipse(P, new Rectangle(innerFillLocation2X, innerFillLocation2Y, uncheckedWidth, uncheckedWidth));
                        }


                        break;
                    default:

                        using (Pen P = new Pen(borderColor))
                        {
                            G.DrawEllipse(P, new Rectangle(innerFillLocation2X, innerFillLocation2Y, uncheckedWidth, uncheckedWidth));
                        }


                        break;
                }


                if (Checked)
                {
                    using (SolidBrush B = new SolidBrush(innerFill))
                    {
                        G.FillEllipse(B, new Rectangle(innerFillLocation1X, innerFillLocation1Y, checkedWidth, checkedWidth));
                    }

                }

            }
            else
            {
                //ETC = borderColor;

                using (Pen P = new Pen(borderColor))
                {
                    G.DrawEllipse(P, new Rectangle(innerFillLocation2X, innerFillLocation2Y, uncheckedWidth, uncheckedWidth));
                }


                if (Checked)
                {
                    using (SolidBrush B = new SolidBrush(innerFill))
                    {
                        G.FillEllipse(B, new Rectangle(innerFillLocation1X, innerFillLocation1Y, checkedWidth, checkedWidth));
                    }

                }

            }

            using (SolidBrush B = new SolidBrush(ForeColor))
            {
                G.DrawString(Text, Font, B, new Point(textLocationX, textLocationY));


                #region Brushes Paint String
                //switch (background)
                //{
                //    case Background.AliceBlue:
                //        G.DrawString(Text, Font, Brushes.AliceBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.AntiqueWhite:
                //        G.DrawString(Text, Font, Brushes.AntiqueWhite, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Aqua:
                //        G.DrawString(Text, Font, Brushes.Aqua, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Aquamarine:
                //        G.DrawString(Text, Font, Brushes.Aquamarine, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Azure:
                //        G.DrawString(Text, Font, Brushes.Azure, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Beige:
                //        G.DrawString(Text, Font, Brushes.Beige, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Bisque:
                //        G.DrawString(Text, Font, Brushes.Bisque, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Black:
                //        G.DrawString(Text, Font, Brushes.Black, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.BlanchedAlmond:
                //        G.DrawString(Text, Font, Brushes.BlanchedAlmond, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Blue:
                //        G.DrawString(Text, Font, Brushes.Blue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.BlueViolet:
                //        G.DrawString(Text, Font, Brushes.BlueViolet, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Brown:
                //        G.DrawString(Text, Font, Brushes.Brown, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.BurlyWood:
                //        G.DrawString(Text, Font, Brushes.BurlyWood, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.CadetBlue:
                //        G.DrawString(Text, Font, Brushes.CadetBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Chartreuse:
                //        G.DrawString(Text, Font, Brushes.Chartreuse, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Chocolate:
                //        G.DrawString(Text, Font, Brushes.Chocolate, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Coral:
                //        G.DrawString(Text, Font, Brushes.Coral, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.CornflowerBlue:
                //        G.DrawString(Text, Font, Brushes.CornflowerBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Cornsilk:
                //        G.DrawString(Text, Font, Brushes.Cornsilk, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Crimson:
                //        G.DrawString(Text, Font, Brushes.Crimson, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Cyan:
                //        G.DrawString(Text, Font, Brushes.Cyan, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkBlue:
                //        G.DrawString(Text, Font, Brushes.DarkBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkCyan:
                //        G.DrawString(Text, Font, Brushes.DarkCyan, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkGoldenrod:
                //        G.DrawString(Text, Font, Brushes.DarkGoldenrod, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkGray:
                //        G.DrawString(Text, Font, Brushes.DarkGray, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkGreen:
                //        G.DrawString(Text, Font, Brushes.DarkGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkKhaki:
                //        G.DrawString(Text, Font, Brushes.DarkKhaki, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkMagenta:
                //        G.DrawString(Text, Font, Brushes.DarkMagenta, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkOliveGreen:
                //        G.DrawString(Text, Font, Brushes.DarkOliveGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkOrange:
                //        G.DrawString(Text, Font, Brushes.DarkOrange, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkOrchid:
                //        G.DrawString(Text, Font, Brushes.DarkOrchid, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkRed:
                //        G.DrawString(Text, Font, Brushes.DarkRed, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkSalmon:
                //        G.DrawString(Text, Font, Brushes.DarkSalmon, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkSeaGreen:
                //        G.DrawString(Text, Font, Brushes.DarkSeaGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkSlateBlue:
                //        G.DrawString(Text, Font, Brushes.DarkSlateBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkSlateGray:
                //        G.DrawString(Text, Font, Brushes.DarkSlateGray, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkTurquoise:
                //        G.DrawString(Text, Font, Brushes.DarkTurquoise, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DarkViolet:
                //        G.DrawString(Text, Font, Brushes.DarkViolet, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DeepPink:
                //        G.DrawString(Text, Font, Brushes.DeepPink, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DeepSkyBlue:
                //        G.DrawString(Text, Font, Brushes.DeepSkyBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DimGray:
                //        G.DrawString(Text, Font, Brushes.DimGray, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.DodgerBlue:
                //        G.DrawString(Text, Font, Brushes.DodgerBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Firebrick:
                //        G.DrawString(Text, Font, Brushes.Firebrick, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.FloralWhite:
                //        G.DrawString(Text, Font, Brushes.FloralWhite, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.ForestGreen:
                //        G.DrawString(Text, Font, Brushes.ForestGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Fuchsia:
                //        G.DrawString(Text, Font, Brushes.Fuchsia, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Gainsboro:
                //        G.DrawString(Text, Font, Brushes.Gainsboro, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.GhostWhite:
                //        G.DrawString(Text, Font, Brushes.GhostWhite, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Gold:
                //        G.DrawString(Text, Font, Brushes.Gold, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Goldenrod:
                //        G.DrawString(Text, Font, Brushes.Goldenrod, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Gray:
                //        G.DrawString(Text, Font, Brushes.Gray, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Green:
                //        G.DrawString(Text, Font, Brushes.Green, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.GreenYellow:
                //        G.DrawString(Text, Font, Brushes.GreenYellow, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Honeydew:
                //        G.DrawString(Text, Font, Brushes.Honeydew, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.HotPink:
                //        G.DrawString(Text, Font, Brushes.HotPink, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.IndianRed:
                //        G.DrawString(Text, Font, Brushes.IndianRed, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Indigo:
                //        G.DrawString(Text, Font, Brushes.Indigo, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Ivory:
                //        G.DrawString(Text, Font, Brushes.Ivory, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Khaki:
                //        G.DrawString(Text, Font, Brushes.Khaki, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Lavender:
                //        G.DrawString(Text, Font, Brushes.Lavender, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LavenderBlush:
                //        G.DrawString(Text, Font, Brushes.LavenderBlush, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LawnGreen:
                //        G.DrawString(Text, Font, Brushes.LawnGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LemonChiffon:
                //        G.DrawString(Text, Font, Brushes.LemonChiffon, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LightBlue:
                //        G.DrawString(Text, Font, Brushes.LightBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LightCoral:
                //        G.DrawString(Text, Font, Brushes.LightCoral, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LightCyan:
                //        G.DrawString(Text, Font, Brushes.LightCyan, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LightGoldenrodYellow:
                //        G.DrawString(Text, Font, Brushes.LightGoldenrodYellow, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LightGray:
                //        G.DrawString(Text, Font, Brushes.LightGray, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LightGreen:
                //        G.DrawString(Text, Font, Brushes.LightGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LightPink:
                //        G.DrawString(Text, Font, Brushes.LightPink, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LightSalmon:
                //        G.DrawString(Text, Font, Brushes.LightSalmon, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LightSeaGreen:
                //        G.DrawString(Text, Font, Brushes.LightSeaGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LightSkyBlue:
                //        G.DrawString(Text, Font, Brushes.LightSkyBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LightSlateGray:
                //        G.DrawString(Text, Font, Brushes.LightSlateGray, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LightSteelBlue:
                //        G.DrawString(Text, Font, Brushes.LightSteelBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LightYellow:
                //        G.DrawString(Text, Font, Brushes.LightYellow, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Lime:
                //        G.DrawString(Text, Font, Brushes.Lime, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.LimeGreen:
                //        G.DrawString(Text, Font, Brushes.LimeGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Linen:
                //        G.DrawString(Text, Font, Brushes.Linen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Magenta:
                //        G.DrawString(Text, Font, Brushes.Magenta, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Maroon:
                //        G.DrawString(Text, Font, Brushes.Maroon, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.MediumAquamarine:
                //        G.DrawString(Text, Font, Brushes.MediumAquamarine, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.MediumBlue:
                //        G.DrawString(Text, Font, Brushes.MediumBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.MediumOrchid:
                //        G.DrawString(Text, Font, Brushes.MediumOrchid, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.MediumPurple:
                //        G.DrawString(Text, Font, Brushes.MediumPurple, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.MediumSeaGreen:
                //        G.DrawString(Text, Font, Brushes.MediumSeaGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.MediumSlateBlue:
                //        G.DrawString(Text, Font, Brushes.MediumSlateBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.MediumSpringGreen:
                //        G.DrawString(Text, Font, Brushes.MediumSpringGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.MediumTurquoise:
                //        G.DrawString(Text, Font, Brushes.MediumTurquoise, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.MediumVioletRed:
                //        G.DrawString(Text, Font, Brushes.MediumVioletRed, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.MidnightBlue:
                //        G.DrawString(Text, Font, Brushes.MidnightBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.MintCream:
                //        G.DrawString(Text, Font, Brushes.MintCream, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.MistyRose:
                //        G.DrawString(Text, Font, Brushes.MistyRose, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Moccasin:
                //        G.DrawString(Text, Font, Brushes.Moccasin, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.NavajoWhite:
                //        G.DrawString(Text, Font, Brushes.NavajoWhite, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Navy:
                //        G.DrawString(Text, Font, Brushes.Navy, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.OldLace:
                //        G.DrawString(Text, Font, Brushes.OldLace, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Olive:
                //        G.DrawString(Text, Font, Brushes.Olive, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.OliveDrab:
                //        G.DrawString(Text, Font, Brushes.OliveDrab, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Orange:
                //        G.DrawString(Text, Font, Brushes.Orange, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.OrangeRed:
                //        G.DrawString(Text, Font, Brushes.OrangeRed, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Orchid:
                //        G.DrawString(Text, Font, Brushes.Orchid, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.PaleGoldenrod:
                //        G.DrawString(Text, Font, Brushes.PaleGoldenrod, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.PaleGreen:
                //        G.DrawString(Text, Font, Brushes.PaleGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.PaleTurquoise:
                //        G.DrawString(Text, Font, Brushes.PaleTurquoise, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.PaleVioletRed:
                //        G.DrawString(Text, Font, Brushes.PaleVioletRed, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.PapayaWhip:
                //        G.DrawString(Text, Font, Brushes.PapayaWhip, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.PeachPuff:
                //        G.DrawString(Text, Font, Brushes.PeachPuff, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Peru:
                //        G.DrawString(Text, Font, Brushes.Peru, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Pink:
                //        G.DrawString(Text, Font, Brushes.Pink, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Plum:
                //        G.DrawString(Text, Font, Brushes.Plum, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.PowderBlue:
                //        G.DrawString(Text, Font, Brushes.PowderBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Purple:
                //        G.DrawString(Text, Font, Brushes.Purple, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Red:
                //        G.DrawString(Text, Font, Brushes.Red, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.RosyBrown:
                //        G.DrawString(Text, Font, Brushes.RosyBrown, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.RoyalBlue:
                //        G.DrawString(Text, Font, Brushes.RoyalBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.SaddleBrown:
                //        G.DrawString(Text, Font, Brushes.SaddleBrown, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Salmon:
                //        G.DrawString(Text, Font, Brushes.Salmon, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.SandyBrown:
                //        G.DrawString(Text, Font, Brushes.SandyBrown, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.SeaGreen:
                //        G.DrawString(Text, Font, Brushes.SeaGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.SeaShell:
                //        G.DrawString(Text, Font, Brushes.SeaShell, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Sienna:
                //        G.DrawString(Text, Font, Brushes.Sienna, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Silver:
                //        G.DrawString(Text, Font, Brushes.Silver, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.SkyBlue:
                //        G.DrawString(Text, Font, Brushes.SkyBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.SlateBlue:
                //        G.DrawString(Text, Font, Brushes.SlateBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.SlateGray:
                //        G.DrawString(Text, Font, Brushes.SlateGray, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Snow:
                //        G.DrawString(Text, Font, Brushes.Snow, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.SpringGreen:
                //        G.DrawString(Text, Font, Brushes.SpringGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.SteelBlue:
                //        G.DrawString(Text, Font, Brushes.SteelBlue, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Tan:
                //        G.DrawString(Text, Font, Brushes.Tan, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Teal:
                //        G.DrawString(Text, Font, Brushes.Teal, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Thistle:
                //        G.DrawString(Text, Font, Brushes.Thistle, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Tomato:
                //        G.DrawString(Text, Font, Brushes.Tomato, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Transparent:
                //        G.DrawString(Text, Font, Brushes.Transparent, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Turquoise:
                //        G.DrawString(Text, Font, Brushes.Turquoise, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Violet:
                //        G.DrawString(Text, Font, Brushes.Violet, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.Wheat:
                //        G.DrawString(Text, Font, Brushes.Wheat, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.White:
                //        G.DrawString(Text, Font, Brushes.White, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.WhiteSmoke:
                //        G.DrawString(Text, Font, Brushes.WhiteSmoke, new Point(textLocationX, textLocationY));
                //        break;
                //    case Background.YellowGreen:
                //        G.DrawString(Text, Font, Brushes.YellowGreen, new Point(textLocationX, textLocationY));
                //        break;
                //    default:
                //        break;
                //}

                #endregion


                //if (Bold)
                //{
                //    G.DrawString(Text, Theme1.GlobalFont(FontStyle.Bold, 10), B, new Point(32, 4));
                //}
                //else
                //{
                //    G.DrawString(Text, Theme1.GlobalFont(FontStyle.Regular, 10), B, new Point(32, 4));
                //}

            }


        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = Helpers2.MouseState.Down;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);


            if (Enabled)
            {

                if (!Checked)
                {
                    foreach (Control C in Parent.Controls)
                    {
                        if (C is ZeroitRadioButtonTransparent)
                        {
                            ((ZeroitRadioButtonTransparent)C).Checked = false;
                        }
                    }

                }

                Checked = true;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this, e);
                }
            }

            State = Helpers2.MouseState.Over;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = Helpers2.MouseState.Over;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = Helpers2.MouseState.None;
            Invalidate();
        }

        #endregion

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitRadioButtonPlainDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitRadioButtonPlainDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitRadioButtonPlainSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitRadioButtonPlainSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitRadioButtonPlainSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitRadioButtonPlain colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitRadioButtonPlainSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitRadioButtonPlainSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitRadioButtonPlain;

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
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return colUserControl.BorderColor;
            }
            set
            {
                GetPropertyByName("BorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the inner fill.
        /// </summary>
        /// <value>The inner fill.</value>
        public Color InnerFill
        {
            get
            {
                return colUserControl.InnerFill;
            }
            set
            {
                GetPropertyByName("InnerFill").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the etc enabled.
        /// </summary>
        /// <value>The color of the etc enabled.</value>
        public Color ETCEnabledColor
        {
            get
            {
                return colUserControl.ETCEnabledColor;
            }
            set
            {
                GetPropertyByName("ETCEnabledColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the checked.
        /// </summary>
        /// <value>The width of the checked.</value>
        public int CheckedWidth
        {
            get
            {
                return colUserControl.CheckedWidth;
            }
            set
            {
                GetPropertyByName("CheckedWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the unchecked.
        /// </summary>
        /// <value>The width of the unchecked.</value>
        public int UncheckedWidth
        {
            get
            {
                return colUserControl.UncheckedWidth;
            }
            set
            {
                GetPropertyByName("UncheckedWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text location x.
        /// </summary>
        /// <value>The text location x.</value>
        public int TextLocationX
        {
            get
            {
                return colUserControl.TextLocationX;
            }
            set
            {
                GetPropertyByName("TextLocationX").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text location y.
        /// </summary>
        /// <value>The text location y.</value>
        public int TextLocationY
        {
            get
            {
                return colUserControl.TextLocationY;
            }
            set
            {
                GetPropertyByName("TextLocationY").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the inner fill location1 x.
        /// </summary>
        /// <value>The inner fill location1 x.</value>
        public int InnerFillLocation1X
        {
            get
            {
                return colUserControl.InnerFillLocation1X;
            }
            set
            {
                GetPropertyByName("InnerFillLocation1X").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the inner fill location1 y.
        /// </summary>
        /// <value>The inner fill location1 y.</value>
        public int InnerFillLocation1Y
        {
            get
            {
                return colUserControl.InnerFillLocation1Y;
            }
            set
            {
                GetPropertyByName("InnerFillLocation1Y").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the inner fill location2 x.
        /// </summary>
        /// <value>The inner fill location2 x.</value>
        public int InnerFillLocation2X
        {
            get
            {
                return colUserControl.InnerFillLocation2X;
            }
            set
            {
                GetPropertyByName("InnerFillLocation2X").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the inner fill location2 y.
        /// </summary>
        /// <value>The inner fill location2 y.</value>
        public int InnerFillLocation2Y
        {
            get
            {
                return colUserControl.InnerFillLocation2Y;
            }
            set
            {
                GetPropertyByName("InnerFillLocation2Y").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitRadioButtonPlainSmartTagActionList"/> is checked.
        /// </summary>
        /// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
        public bool Checked
        {
            get
            {
                return colUserControl.Checked;
            }
            set
            {
                GetPropertyByName("Checked").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitRadioButtonPlainSmartTagActionList"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled
        {
            get
            {
                return colUserControl.Enabled;
            }
            set
            {
                GetPropertyByName("Enabled").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enabled calculate].
        /// </summary>
        /// <value><c>true</c> if [enabled calculate]; otherwise, <c>false</c>.</value>
        [DisplayName("Enabled")]
        public bool EnabledCalc
        {
            get
            {
                return colUserControl.EnabledCalc;
            }
            set
            {
                GetPropertyByName("EnabledCalc").SetValue(colUserControl, value);
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
                                 "Set the BackColor of the control."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "ETC Color", "Appearance",
                                 "Set the circle border color."));

            items.Add(new DesignerActionPropertyItem("ETCEnabledColor",
                                 "ETCEnabledColor", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("InnerFill",
                                 "Inner Fill", "Appearance",
                                 "Set the innerfill."));


            items.Add(new DesignerActionPropertyItem("CheckedWidth",
                                 "Checked Width", "Appearance",
                                 "Set the width of the control."));

            items.Add(new DesignerActionPropertyItem("UncheckedWidth",
                                 "Unchecked Width", "Appearance",
                                 "Set the width of the control when not checked."));

            items.Add(new DesignerActionPropertyItem("TextLocationX",
                                 "Text LocationX", "Appearance",
                                 "Set the text x-cordinate location."));

            items.Add(new DesignerActionPropertyItem("TextLocationY",
                                 "TextLocationY", "Appearance",
                                 "Set the text y-cordinate location."));

            items.Add(new DesignerActionPropertyItem("InnerFillLocation1X",
                                 "Inner FillLocation 1X", "Appearance",
                                 "Set the inner-fill x-cordinate location."));

            items.Add(new DesignerActionPropertyItem("InnerFillLocation1Y",
                                 "Inner FillLocation 1Y", "Appearance",
                                 "Set the inner-fill y-cordinate location."));

            items.Add(new DesignerActionPropertyItem("InnerFillLocation2X",
                                 "Inner FillLocation 2X", "Appearance",
                                 "Set the inner-fill x-cordinate location."));

            items.Add(new DesignerActionPropertyItem("InnerFillLocation2Y",
                                 "Inner FillLocation 2Y", "Appearance",
                                 "Set the inner-fill x-cordinate location."));

            
            items.Add(new DesignerActionPropertyItem("Checked",
                                 "Checked", "Appearance",
                                 "Set to tick the control."));

            items.Add(new DesignerActionPropertyItem("Enabled",
                                 "Enabled", "Appearance",
                                 "Set to enable the control."));

            items.Add(new DesignerActionPropertyItem("EnabledCalc",
                                 "Enabled Calc", "Appearance",
                                 "Set to enable the control."));

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



}
