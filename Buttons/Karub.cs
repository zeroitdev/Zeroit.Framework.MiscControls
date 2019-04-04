// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 02-13-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-06-2018
// ***********************************************************************
// <copyright file="Karub.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{

    #region Karub Button

    #region Control

    /// <summary>
    /// A class collection for rendering a button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public partial class ZeroitKaruButton : Control
    {
        #region Enumlar

        /// <summary>
        /// Enum representing a Layer Status for <c><see cref="ZeroitKaruButton" /></c>.
        /// </summary>
        public enum LayerStatus
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The self
            /// </summary>
            Self = 1,
            /// <summary>
            /// The top left
            /// </summary>
            TopLeft = 2,
            /// <summary>
            /// The top
            /// </summary>
            Top = 3,
            /// <summary>
            /// The top right
            /// </summary>
            TopRight = 4,
            /// <summary>
            /// The left
            /// </summary>
            Left = 5,
            /// <summary>
            /// The right
            /// </summary>
            Right = 6,
            /// <summary>
            /// The bottom left
            /// </summary>
            BottomLeft = 7,
            /// <summary>
            /// The bottom
            /// </summary>
            Bottom = 8,
            /// <summary>
            /// The bottom right
            /// </summary>
            BottomRight = 9
        };

        /// <summary>
        /// Enum representing a Border Line for <c><see cref="ZeroitKaruButton" /></c>.
        /// </summary>
        public enum BorderLine
        {
            /// <summary>
            /// Down
            /// </summary>
            Down = 0,
            /// <summary>
            /// The center
            /// </summary>
            Center = 1,
            /// <summary>
            /// Up
            /// </summary>
            Up = 2
        };

        /// <summary>
        /// Enum representing the States for <c><see cref="ZeroitKaruButton" /></c>.
        /// </summary>
        public enum States
        {
            /// <summary>
            /// The normal
            /// </summary>
            Normal = 0,//Normal butonun þekli
            /// <summary>
            /// The highlighted
            /// </summary>
            Highlighted = 1,//Butonun üzerine gelindiðindeki konum
            /// <summary>
            /// The pressed
            /// </summary>
            Pressed = 2,//Basýlý durumu
            //Disabled = 3//Kullanýmda yokken ki durumu
        };

        /// <summary>
        /// Enum representing the Style for <c><see cref="ZeroitKaruButton" /></c>.
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// The calm cyan
            /// </summary>
            CalmCyan = 0,
            /// <summary>
            /// The diamond red
            /// </summary>
            DiamondRed = 1,
            /// <summary>
            /// The custom
            /// </summary>
            Custom = 2
        };

        /// <summary>
        /// Enum representing PositionIcon for <c><see cref="ZeroitKaruButton" /></c>.
        /// </summary>
        public enum PositionIcon
        {
            /// <summary>
            /// The left
            /// </summary>
            Left = 0,
            /// <summary>
            /// The center
            /// </summary>
            Center = 1,
            /// <summary>
            /// The right
            /// </summary>
            Right = 2
        };

        /// <summary>
        /// Enum representing IconMask for <c><see cref="ZeroitKaruButton" /></c>.
        /// </summary>
        public enum IconMask
        {
            /// <summary>
            /// The original
            /// </summary>
            Original = 0,
            /// <summary>
            /// The highlighted 25
            /// </summary>
            Highlighted_25 = 1,
            /// <summary>
            /// The highlighted 50
            /// </summary>
            Highlighted_50 = 2,
            /// <summary>
            /// The whitened 50
            /// </summary>
            Whitened_50 = 3,
            /// <summary>
            /// The whitened 75
            /// </summary>
            Whitened_75 = 4,
            /// <summary>
            /// The mask
            /// </summary>
            Mask = 5,
            /// <summary>
            /// The gamma lighter
            /// </summary>
            GammaLighter = 6,
            /// <summary>
            /// The gamma darker
            /// </summary>
            GammaDarker = 7,
            /// <summary>
            /// The icon with shadow
            /// </summary>
            IconWithShadow = 8
        };

        /// <summary>
        /// Enum representing HorizontalTextAlign for <c><see cref="ZeroitKaruButton" /></c>.
        /// </summary>
        public enum HorizontalTextAlign
        {
            /// <summary>
            /// The left
            /// </summary>
            Left = 0,
            /// <summary>
            /// The center
            /// </summary>
            Center = 1,
            /// <summary>
            /// The right
            /// </summary>
            Right = 2
        }

        /// <summary>
        /// Enum representing VerticalTextAlign for <c><see cref="ZeroitKaruButton" /></c>.
        /// </summary>
        public enum VerticalTextAlign
        {
            /// <summary>
            /// Up
            /// </summary>
            Up = 0,
            /// <summary>
            /// The center
            /// </summary>
            Center = 1,
            /// <summary>
            /// Down
            /// </summary>
            Down = 2
        };

        #endregion

        #region Member

        /// <summary>
        /// The layer
        /// </summary>
        private LayerStatus _Layer = LayerStatus.None;//Herhangi bir layer atanmamakta
        /// <summary>
        /// The layer center color
        /// </summary>
        private Color _layerCenterColor = Color.Transparent;//Kontrolün kenar rengi varsayýlan transparent
        /// <summary>
        /// The uzeri
        /// </summary>
        private bool uzeri = false;//üzerine gelinip gelinmediðinin deðerini tutacak
        /// <summary>
        /// The glow length
        /// </summary>
        private int _GlowLength = 2;
        /// <summary>
        /// The button icon
        /// </summary>
        private Icon buttonIcon = null;
        /// <summary>
        /// The gorunum
        /// </summary>
        private IconMask gorunum = IconMask.Original;
        /// <summary>
        /// The icon draw width
        /// </summary>
        private int iconDrawWidth; //iconun geniþliði
        /// <summary>
        /// The edge pending
        /// </summary>
        private int EDGE_PENDING = 5; //Iconun sol veya sað köþeye olan uzaklýðý
        /// <summary>
        /// The sinir
        /// </summary>
        private BorderLine _sinir = BorderLine.Up;
        /// <summary>
        /// The renk center
        /// </summary>
        private Color[] renkCenter = { Color.FromArgb(100, 93, 8, 41), Color.FromArgb(100, 17, 16, 90), Color.Empty };
        /// <summary>
        /// The buton durum
        /// </summary>
        private States butonDurum;
        /// <summary>
        /// The button style
        /// </summary>
        private Style _buttonStyle = Style.CalmCyan;
        /// <summary>
        /// The icon yerlesim
        /// </summary>
        private PositionIcon _iconYerlesim = PositionIcon.Left;
        /// <summary>
        /// The yazi dikey
        /// </summary>
        private VerticalTextAlign _yaziDikey = VerticalTextAlign.Center;
        /// <summary>
        /// The yazi yatay
        /// </summary>
        private HorizontalTextAlign _yaziYatay = HorizontalTextAlign.Left;
        /// <summary>
        /// The yazý style
        /// </summary>
        private System.Drawing.Text.TextRenderingHint _yazýStyle = System.Drawing.Text.TextRenderingHint.SystemDefault;

        #region Renk Tablosu

        /// <summary>
        /// The renk dizi
        /// </summary>
        private Color[][,] renkDizi = new Color[3][,]
            {
                //CalmCyan
                new Color[,]{{Color.FromArgb(115, 163, 183),Color.FromArgb(94, 146, 159),Color.FromArgb(184, 212, 220),Color.FromArgb(143, 181, 192),
                    Color.FromArgb(125, Color.White),Color.FromArgb(100, Color.White),Color.White,Color.FromArgb(180, 209, 219)},//normal durum renkleri
                    
                    {Color.FromArgb(47, 216, 229),Color.FromArgb(14, 102, 159),Color.FromArgb(166, 204, 229),Color.FromArgb(116, 170, 206),//üzerine gelindiðindeki durum
                        Color.FromArgb(125, Color.White),Color.FromArgb(100, Color.White),Color.White,Color.FromArgb(180, 209, 219)},

                    {Color.FromArgb(23, 214, 198),Color.FromArgb(7, 36, 67),Color.FromArgb(100, 174, 194),Color.FromArgb(80, 115, 145),//basýlý durumundaki renkler
                        Color.FromArgb(125, Color.White),Color.FromArgb(100, Color.White),Color.White,Color.FromArgb(180, 209, 219)}},
               //DiamondRed
                new Color[,]{{Color.FromArgb(171, 115, 106),Color.FromArgb(185, 63, 42),Color.FromArgb(203, 167, 163),Color.FromArgb(174, 115, 109),
                    Color.FromArgb(125, Color.White),Color.FromArgb(100, Color.White),Color.White,Color.FromArgb(217, 178, 166)},

                    {Color.FromArgb(230, 149, 48),Color.FromArgb(170, 38, 19),Color.FromArgb(230, 154, 142),Color.FromArgb(208, 101, 84),
                        Color.FromArgb(125, Color.White),Color.FromArgb(100, Color.White),Color.White,Color.FromArgb(245, 232, 120)},

                    {Color.FromArgb(144, 109, 33),Color.FromArgb(71, 13, 2),Color.FromArgb(150, 166, 144),Color.FromArgb(164, 100, 75),
                        Color.FromArgb(125, Color.White),Color.FromArgb(100, Color.White),Color.White,Color.FromArgb(204, 203, 30)}},
                //Custom
                new Color[,]{{Color.Empty,Color.Empty,Color.Empty,Color.Empty,Color.Empty,Color.Empty,Color.Empty,Color.Empty},//normal konum
                    {Color.Empty,Color.Empty,Color.Empty,Color.Empty,Color.Empty,Color.Empty,Color.Empty,Color.Empty},//üzerine gelindiðindeki durum
                    {Color.Empty,Color.Empty,Color.Empty,Color.Empty,Color.Empty,Color.Empty,Color.Empty,Color.Empty}}//basýlý haldeki durumu

            };

        #endregion

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitKaruButton" /> class.
        /// </summary>
        public ZeroitKaruButton()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;//butonun arka planý transparan renkte olacak.
            butonDurum = States.Normal;
        }

        #endregion

        #region Override Method

        //Focus olayý gerçekleþtiði zaman tekrar paint mesajý gönderiyoruz 
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
        }

        //Konrolümüz aktifliðini kaybettiðinde paint mesajý gönderiyoruz 
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            Invalidate();
            base.OnLostFocus(e);
        }

        //Kontolümüz üzerindeki yazý deðiþtiðinde kontrolümüzü güncelliyoruz 
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        //Kontrolümüzün boyutlarý deðiþtiðinde kontrolümüzü güncelliyoruz 
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            Invalidate();
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            butonDurum = States.Highlighted;
            this.uzeri = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            butonDurum = States.Normal;
            this.uzeri = false;
            Invalidate();//paint mesajýný gönder
            base.OnMouseLeave(e);
        }

        //Kullanýcý mouse ile button týkladýðýnda gerçeleþmesini istediðimiz iþlemleri belirliyoruz 
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //Eðer sol tuþ ise 
            {
                Focus(); //kontrolü seçili hale getir 
                Capture = true;
                butonDurum = States.Pressed;//buttonu basýlý duruma bilgisini tut 
                Invalidate();
                Update();
            }
            else //deðilse taban sýnýf ön tanýmlý iþlemleri yapsýn 
            {
                base.OnMouseDown(e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Capture = false;
                butonDurum = States.Highlighted;
                Invalidate();
                Update();
            }
            else
            {
                base.OnMouseUp(e);
            }
        }

        //Kontrole paint mesajý geldiði zaman buttonun tekrar boyanmasýný ve çizilmesini saðlamak için 
        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="pe">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            Draw(pe.Graphics); //bu method ile button için gerekli tüm çizim ve boyama iþlemlerini yapacaðýz.
            //Kontrolü baþtan-aþaðýya kendimiz çizeceðimiz için ana classýn methodunu çaðýrmayacaðýz.
        }

        #endregion

        #region Virtual Method

        //parametre olarak kontrolümüzün Graphics nesnesini veriyoruz
        //Çizim methodumuz.
        /// <summary>
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void Draw(Graphics g)
        {
            DrawButton(g);
            if (buttonIcon != null)//icon deðeri boþ deðilse iconu çizdir
                DrawIcon(g);
            DrawText(g);//her halükarda yazý yazdýrýlacak.
        }

        //Buttonumuzu çiziyoruz 
        /// <summary>
        /// Draws the button.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void DrawButton(Graphics g)
        {
            Rectangle backRect = new Rectangle();
            Rectangle ShineRect = new Rectangle();

            if (_sinir == BorderLine.Up)//tamam
            {
                backRect = new Rectangle(1, this.Height / 2 - 1, this.Width - 2, this.Height / 2);
                ShineRect = new Rectangle(1, 1, this.Width - 2, this.Height / 2 - 2);//üstteki
            }
            else if (_sinir == BorderLine.Center)//tamam
            {
                backRect = new Rectangle(1, this.Height / 2, this.Width - 2, this.Height / 2 - 1);
                ShineRect = new Rectangle(1, 1, this.Width - 2, this.Height / 2 - 1);//üstteki
            }
            else if (_sinir == BorderLine.Down)//tamam
            {
                backRect = new Rectangle(1, this.Height / 2 + 1, this.Width - 2, this.Height / 2 - 2);
                ShineRect = new Rectangle(1, 1, this.Width - 2, this.Height / 2);//üstteki
            }

            LinearGradientBrush lgb;//dispose edilecek
            int k = (int)butonDurum;//butonun durumunu tutacak

            if (_buttonStyle == Style.CalmCyan)
            {
                lgb = new LinearGradientBrush(backRect, renkDizi[0][k, 1], renkDizi[0][k, 0], LinearGradientMode.Vertical);
                g.FillRectangle(lgb, backRect);

                lgb = new LinearGradientBrush(ShineRect, renkDizi[0][k, 2], renkDizi[0][k, 3], LinearGradientMode.Vertical);
                g.FillRectangle(lgb, ShineRect);
                //Top-Bottom Border draw
                g.DrawLine(new Pen(renkDizi[0][k, 6]), 1, 1, this.Width - 2, 1);
                g.DrawLine(new Pen(renkDizi[0][k, 7]), 1, this.Height - 2, this.Width - 2, this.Height - 2);
                //Left-Right Border draw
                g.DrawLine(new Pen(renkDizi[0][k, 4]), 1, 1, 1, this.Height - 2);
                g.DrawLine(new Pen(renkDizi[0][k, 5]), this.Width - 2, 1, this.Width - 2, this.Height - 3);

                if (uzeri)
                    g.DrawRectangle(new Pen(renkCenter[0]), 0, 0, this.Width - 1, this.Height - 1);

            }
            else if (_buttonStyle == Style.DiamondRed)
            {
                lgb = new LinearGradientBrush(backRect, renkDizi[1][k, 1], renkDizi[1][k, 0], LinearGradientMode.Vertical);
                g.FillRectangle(lgb, backRect);

                lgb = new LinearGradientBrush(ShineRect, renkDizi[1][k, 2], renkDizi[1][k, 3], LinearGradientMode.Vertical);
                g.FillRectangle(lgb, ShineRect);

                g.DrawLine(new Pen(renkDizi[1][k, 6]), 1, 1, this.Width - 2, 1);
                g.DrawLine(new Pen(renkDizi[1][k, 7]), 1, this.Height - 2, this.Width - 2, this.Height - 2);

                g.DrawLine(new Pen(renkDizi[1][k, 4]), 1, 1, 1, this.Height - 2);
                g.DrawLine(new Pen(renkDizi[1][k, 5]), this.Width - 2, 1, this.Width - 2, this.Height - 3);

                if (uzeri)
                    g.DrawRectangle(new Pen(renkCenter[1]), 0, 0, this.Width - 1, this.Height - 1);

            }
            else
            {
                lgb = new LinearGradientBrush(backRect, renkDizi[2][k, 1], renkDizi[2][k, 0], LinearGradientMode.Vertical);
                g.FillRectangle(lgb, backRect);

                lgb = new LinearGradientBrush(ShineRect, renkDizi[2][k, 2], renkDizi[2][k, 3], LinearGradientMode.Vertical);
                g.FillRectangle(lgb, ShineRect);

                g.DrawLine(new Pen(renkDizi[2][k, 6]), 1, 1, this.Width - 2, 1);
                g.DrawLine(new Pen(renkDizi[2][k, 7]), 1, this.Height - 2, this.Width - 2, this.Height - 2);

                g.DrawLine(new Pen(renkDizi[2][k, 4]), 1, 1, 1, this.Height - 2);
                g.DrawLine(new Pen(renkDizi[2][k, 5]), this.Width - 2, 1, this.Width - 2, this.Height - 3);

                if (uzeri)
                    g.DrawRectangle(new Pen(renkCenter[2]), 0, 0, this.Width - 1, this.Height - 1);

            }

            if (_Layer != LayerStatus.None)
            {
                int x = 0, y = 0;

                switch (_Layer)
                {
                    case LayerStatus.Bottom:
                        y += Size.Height / 2 - 1;
                        break;
                    case LayerStatus.BottomLeft:
                        x -= Size.Width / 2;
                        y += Size.Height / 2 - 1;
                        break;
                    case LayerStatus.BottomRight:
                        x += Size.Width / 2;
                        y += Size.Height / 2 - 1;
                        break;
                    case LayerStatus.Left:
                        x -= Size.Width / 2;
                        break;
                    case LayerStatus.Right:
                        x += Size.Width / 2;
                        break;
                    case LayerStatus.Top:
                        y -= Size.Height / 2 + 1;
                        break;
                    case LayerStatus.TopLeft:
                        x -= Size.Width / 2;
                        y -= Size.Height / 2 + 1;
                        break;
                    case LayerStatus.TopRight:
                        x += Size.Width / 2;
                        y -= Size.Height / 2 + 1;
                        break;
                }

                Point startPoint = new Point(x - _GlowLength, y - _GlowLength);

                GraphicsPath pth = new GraphicsPath();
                pth.AddRectangle(new Rectangle(startPoint, new Size(Size.Width + _GlowLength * 2, Size.Height + _GlowLength * 2)));

                PathGradientBrush pgb = new PathGradientBrush(pth);
                pgb.CenterColor = _layerCenterColor;
                pgb.SurroundColors = new Color[] { Color.Transparent };
                pgb.FocusScales = new PointF(0.7F, 0.7F);

                ColorBlend cb = new ColorBlend(2);
                cb.Positions[0] = 0.0F;
                cb.Positions[1] = 1.0F;

                cb.Colors = new Color[] { Color.Transparent, Color.FromArgb(150, 93, 198, 242) };
                pgb.InterpolationColors = cb;
                pgb.FocusScales = new PointF(0.7F, 0.7F);

                g.FillPath(pgb, pth);//alaný dolduruyoruz.

                lgb.Dispose();
                pgb.Dispose();
                pth.Dispose();
            }

        }
        //iconu çizecek olan method
        /// <summary>
        /// Draws the icon.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void DrawIcon(Graphics g)//hata yok çizim doðru
        {
            int top = (Height / 2) - (buttonIcon.Height / 2);//çizilecek iconun top deðeri
            int height = buttonIcon.Height;//iconun yüksekliði
            int width = buttonIcon.Width;//iconun geniþliði
            if ((top + height) >= Height)//eðer iconun top deðeri ile iconun yükseklik toplamý kontrolün yüksekliðinden fazla olursa oynama yap
            {
                top = EDGE_PENDING;
                int drawHeight = Height - (2 * EDGE_PENDING);
                float scale = ((float)drawHeight / (float)height);
                width = (int)((float)width * scale);
                height = drawHeight;
            }

            Rectangle iconRect;
            if (_iconYerlesim == PositionIcon.Left)//sol kýsma çizilecek icon
            {
                iconRect = new Rectangle(EDGE_PENDING, top, width, height);
            }
            else if (_iconYerlesim == PositionIcon.Right)//sað kýsma çizilecek icon
            {
                iconRect = new Rectangle(Width - (EDGE_PENDING + width), top, width, height);
            }
            else//merkeze çizilecek icon
            {
                iconRect = new Rectangle(Width / 2 - width / 2, top, width, height);
            }

            if (butonDurum == States.Pressed)
                iconRect.Offset(1, 1);//eðer buton basýlý ise 1,1 oranýnda sapma meydana gelsin.

            Image butonResim = buttonIcon.ToBitmap();
            //iconumuzu çizdiriyoruz.
            switch (gorunum)
            {
                case IconMask.Original:
                    g.DrawImage(butonResim, iconRect);
                    break;
                case IconMask.Highlighted_25://5 tane
                    DrawHighlightedIcon(
                    g, butonResim, iconRect,
                    Color.FromKnownColor(KnownColor.Highlight),
                    64);
                    break;
                case IconMask.Highlighted_50://3 tane
                    DrawHighlightedIcon(
                    g, butonResim, iconRect);
                    break;
                case IconMask.Whitened_50://4 tane
                    DrawHighlightedIcon(
                    g, butonResim, iconRect,
                    Color.White);
                    break;
                case IconMask.Whitened_75://5 tane
                    DrawHighlightedIcon(
                    g, butonResim, iconRect,
                    Color.White, 192);
                    break;
                case IconMask.Mask://5 tane
                    DrawHighlightedIcon(
                    g, butonResim, iconRect,
                    Color.FromKnownColor(KnownColor.ControlDarkDark), 225);
                    break;
                case IconMask.GammaDarker://olumlu - 4 tane
                    DrawHighlightedIcon(
                    g, butonResim, iconRect,
                    2.2F);
                    break;
                case IconMask.GammaLighter://olumlu - 4 tane
                    DrawHighlightedIcon(
                        g, butonResim, iconRect,
                        0.5F);
                    break;
                default:
                    DrawHighlightedIcon(
                    g, butonResim, iconRect,
                    Color.FromKnownColor(KnownColor.ControlDark), 230, 0.8F);
                    g.DrawImage(butonResim, iconRect);
                    break;
            }
            iconDrawWidth = iconRect.Width;
            butonResim.Dispose();//image'ý temizle
        }

        //Konrolümüzün üzerindeki yazýyý çizecek olan method.
        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void DrawText(Graphics g)
        {
            switch (_yazýStyle)
            {
                case System.Drawing.Text.TextRenderingHint.AntiAlias:
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    break;
                case System.Drawing.Text.TextRenderingHint.AntiAliasGridFit:
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    break;
                case System.Drawing.Text.TextRenderingHint.ClearTypeGridFit:
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    break;
                case System.Drawing.Text.TextRenderingHint.SingleBitPerPixel:
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                    break;
                case System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit:
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                    break;
                default:
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
                    break;
            }


            StringFormat fmt = new StringFormat();

            if (_yaziYatay == HorizontalTextAlign.Left)
                fmt.Alignment = StringAlignment.Near;
            else if (_yaziYatay == HorizontalTextAlign.Right)
                fmt.Alignment = StringAlignment.Far;
            else
            {
                fmt.Alignment = StringAlignment.Center;
            }

            if (_yaziDikey == VerticalTextAlign.Center)
                fmt.LineAlignment = StringAlignment.Center;
            else if (_yaziDikey == VerticalTextAlign.Up)
                fmt.LineAlignment = StringAlignment.Near;
            else
                fmt.LineAlignment = StringAlignment.Far;

            //yazýnýn sol kenara olan uzaklýðýný belirliyoruz 
            int left = 0;
            int width = 0;

            if (buttonIcon != null)
            {
                if (_yaziYatay == HorizontalTextAlign.Left)//icon varsa sol deðeri
                {
                    if (_iconYerlesim == PositionIcon.Left)
                        left = iconDrawWidth + EDGE_PENDING;
                    else if (_iconYerlesim == PositionIcon.Right)
                        left = EDGE_PENDING;
                    else
                        left = EDGE_PENDING;

                    width = Width - left;
                }
                else if (_yaziYatay == HorizontalTextAlign.Right)
                {
                    if (_iconYerlesim == PositionIcon.Left)
                        width = Width - EDGE_PENDING;
                    else if (_iconYerlesim == PositionIcon.Right)
                        width = Width - (EDGE_PENDING + iconDrawWidth);
                    else
                        width = Width - EDGE_PENDING;
                }
                else
                {
                    width = Width;
                }
            }
            else
            {
                if (_yaziYatay == HorizontalTextAlign.Left)//icon varsa sol deðeri
                {
                    left = EDGE_PENDING;//üzerine ekleme yap
                    width = Width - left;
                }
                else if (_yaziYatay == HorizontalTextAlign.Right)
                {
                    width = Width - EDGE_PENDING;
                }
                else
                {
                    width = Width;
                }

            }


            int top = EDGE_PENDING;
            int height = Height - (2 * EDGE_PENDING);
            RectangleF layoutRect = new Rectangle(left, top, width, height);
            if (butonDurum == States.Pressed)
                layoutRect.Offset(1, 1);

            SolidBrush textBrush = new SolidBrush(this.ForeColor);
            g.DrawString(Text, Font, textBrush, layoutRect, fmt);
            textBrush.Dispose();
        }



        /// <summary>
        /// Draws the highlighted icon.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="destRect">The dest rect.</param>
        protected virtual void DrawHighlightedIcon(Graphics graphics, Image icon, Rectangle destRect)
        {
            DrawHighlightedIcon(
                graphics, icon, destRect,
                Color.FromKnownColor(KnownColor.Highlight), 128, 1.0F);//6lý
        }

        //dark and light gamma çizimi
        /// <summary>
        /// Draws the highlighted icon.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="destRect">The dest rect.</param>
        /// <param name="gamma">The gamma.</param>
        protected virtual void DrawHighlightedIcon(Graphics graphics, Image icon, Rectangle destRect, float gamma)
        {
            // Now set up the gamma:
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(gamma);

            // Draw the image with the gamma applied:
            graphics.DrawImage(
                icon,
                destRect,
                0, 0, icon.Width, icon.Height,
                GraphicsUnit.Pixel, imageAttr);
            // Done.
            imageAttr.Dispose();
        }

        /// <summary>
        /// Draws the highlighted icon.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="destRect">The dest rect.</param>
        /// <param name="highlightColor">Color of the highlight.</param>
        protected virtual void DrawHighlightedIcon(Graphics graphics, Image icon, Rectangle destRect, Color highlightColor)
        {
            DrawHighlightedIcon(
                graphics, icon, destRect,
                highlightColor, 128, 1.0F);//6lý
        }

        //mask icon çizimi
        /// <summary>
        /// Draws the highlighted icon.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="destRect">The dest rect.</param>
        /// <param name="highlightColor">Color of the highlight.</param>
        /// <param name="highlightAmount">The highlight amount.</param>
        protected virtual void DrawHighlightedIcon(Graphics graphics, Image icon, Rectangle destRect, Color highlightColor, int highlightAmount)
        {
            DrawHighlightedIcon(
                graphics, icon, destRect,
                highlightColor, highlightAmount, 1.0F);//6lý
        }
        //icon gölge çizimi
        /// <summary>
        /// Draws the highlighted icon.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="destRect">The dest rect.</param>
        /// <param name="highlightColor">Color of the highlight.</param>
        /// <param name="highlightAmount">The highlight amount.</param>
        /// <param name="gamma">The gamma.</param>
        protected virtual void DrawHighlightedIcon(Graphics graphics, Image icon, Rectangle destRect, Color highlightColor, int highlightAmount, float gamma)
        {
            Bitmap bm = new Bitmap(
               icon.Width, icon.Height + 1
                );
            Graphics gfx = Graphics.FromImage(bm);

            // Set the background colour to a colour that "won't" appear in the icon:
            Brush br = new SolidBrush(Color.FromArgb(254, 253, 254));
            gfx.FillRectangle(br, 0, 0, bm.Width, bm.Height);
            br.Dispose();
            // iconun çizimi
            gfx.DrawImage(icon, 0, 0);
            // Overdraw with the highlight colour:
            br = new SolidBrush(Color.FromArgb(highlightAmount, highlightColor));
            gfx.FillRectangle(br, 0, 0, bm.Width, bm.Height);
            br.Dispose();
            gfx.Dispose();

            // Now set up a colour mapping from the colour of the pixel
            // at 0,0 to transparent:
            ImageAttributes imageAttr = new ImageAttributes();
            ColorMap[] map = new ColorMap[1] { new ColorMap() };
            map[0].OldColor = bm.GetPixel(0, 0);
            map[0].NewColor = Color.FromArgb(0, 0, 0, 0);
            imageAttr.SetRemapTable(map);
            if (gamma != 1.0F)
            {
                imageAttr.SetGamma(1.0F);
            }
            //sapma meydana getireceðiz.
            if (gorunum == IconMask.IconWithShadow)
                destRect.Offset(1, 1);
            graphics.DrawImage(
                bm, destRect,
                0, 0, icon.Width, icon.Height,
                GraphicsUnit.Pixel, imageAttr);
            // iþlem tamamlandý
            imageAttr.Dispose();
            bm.Dispose();
        }


        #endregion

        #region Property

        /// <summary>
        /// Sets the middle shine.
        /// </summary>
        /// <value>The middle shine.</value>
        [Description("Sets the middle shine."), 
         Browsable(true),
         DefaultValue(ZeroitKaruButton.BorderLine.Center), 
         Category("Appearance")]
        public BorderLine MiddleShine
        {
            get { return _sinir; }
            set
            {
                _sinir = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the layer status.
        /// </summary>
        /// <value>The layer.</value>
        [Browsable(true), Category("Appearance"),
        Description("Sets the Layer status."),
        DefaultValue(ZeroitKaruButton.LayerStatus.None)]
        public LayerStatus Layer
        {
            get { return _Layer; }
            set
            {
                _Layer = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the highlight area.
        /// </summary>
        /// <value>The highlight area.</value>
        [Browsable(true), Category("Appearance")]
        public Color HighlightArea
        {
            get { return renkCenter[2]; }
            set
            {
                renkCenter[2] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the button icon.
        /// </summary>
        /// <value>The button icon.</value>
        [System.ComponentModel.Description("Sets the icon of the button"),
        System.ComponentModel.Category("Appearance"),
        System.ComponentModel.DefaultValue(null)]
        public Icon ButtonIcon
        {
            get { return buttonIcon; }
            set
            {
                buttonIcon = value;
                Invalidate(); // kontrolümüze paint mesajýný gönderiyoruz 
                Update(); //kontrolümüzün çizim iþlemini yapýyoruz 
            }
        }

        /// <summary>
        /// Gets or sets the style of the button.
        /// </summary>
        /// <value>The button style.</value>
        [Description("Sets the style of the button."), Browsable(true),
        DefaultValue(ZeroitKaruButton.Style.CalmCyan),
        Category("Appearance")]
        public Style ButtonStyle
        {
            get { return _buttonStyle; }
            set
            {
                _buttonStyle = value;
                Invalidate();//paint mesajýný gönderiyoruz.
                Update();//kontrolümüzün çizim iþlemini yapýyoruz.
            }
        }

        /// <summary>
        /// Gets or sets the icon position.
        /// </summary>
        /// <value>The icon position.</value>
        [Description("Sets the position of the icon."),
        DefaultValue(ZeroitKaruButton.PositionIcon.Left), Browsable(true),
        Category("Appearance")]
        public PositionIcon IconPosition
        {
            get { return _iconYerlesim; }
            set
            {
                _iconYerlesim = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the icon dimension.
        /// </summary>
        /// <value>The icon dimension.</value>
        [Description("Sets the icon dimensions."),
        Browsable(true),
        DefaultValue(5), Category("Appearance")]
        public int IconDimension
        {
            get { return EDGE_PENDING; }
            set
            {
                EDGE_PENDING = value;
                Invalidate();//a paint message to be sent to wnd proc from property.
                Update();//control updated
            }
        }

        /// <summary>
        /// Gets or sets the icon masking.
        /// </summary>
        /// <value>The icon masking.</value>
        [Description("Sets the icon masking."),
        DefaultValue(ZeroitKaruButton.IconMask.Original),
        Browsable(true), Category("Appearance")]
        public IconMask IconMasking
        {
            get { return gorunum; }
            set
            {
                gorunum = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the horizontal text alignment.
        /// </summary>
        /// <value>The text horizontal alignment.</value>
        [Category("Appearance"),
        Description("Sets the horizontal text alignment."),
        DefaultValue(ZeroitKaruButton.HorizontalTextAlign.Left)]
        public HorizontalTextAlign TextHorizontalAlignment
        {
            get { return _yaziYatay; }
            set
            {
                _yaziYatay = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the vertical text alignment.
        /// </summary>
        /// <value>The text vertical alignment.</value>
        [Category("Appearance"),
        Description("Sets the vertical text alignment."),
        DefaultValue(ZeroitKaruButton.VerticalTextAlign.Center)]
        public VerticalTextAlign TextVerticalAlignment
        {
            get { return _yaziDikey; }
            set
            {
                _yaziDikey = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the text rendering mode.
        /// </summary>
        /// <value>The text rendering.</value>
        [Description("Sets the text rendering mode."),
        Category("Appearance"),
        DefaultValue(System.Drawing.Text.TextRenderingHint.SystemDefault)]
        public System.Drawing.Text.TextRenderingHint TextRendering
        {
            get { return _yazýStyle; }
            set
            {
                _yazýStyle = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the background high mode.
        /// </summary>
        /// <value>The background high.</value>
        [Category("Appearance")]
        public Color BackgroundHigh
        {
            get { return renkDizi[2][0, 0]; }
            set
            {
                renkDizi[2][0, 0] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the background low mode.
        /// </summary>
        /// <value>The background low.</value>
        [Category("Appearance")]
        public Color BackgroundLow
        {
            get { return renkDizi[2][0, 1]; }
            set
            {
                renkDizi[2][0, 1] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the shine high mode.
        /// </summary>
        /// <value>The shine high.</value>
        [Category("Appearance")]
        public Color ShineHigh
        {
            get { return renkDizi[2][0, 2]; }
            set
            {
                renkDizi[2][0, 2] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the shine low mode.
        /// </summary>
        /// <value>The shine low.</value>
        [Category("Appearance")]
        public Color ShineLow
        {
            get { return renkDizi[2][0, 3]; }
            set
            {
                renkDizi[2][0, 3] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the border left color.
        /// </summary>
        /// <value>The border left.</value>
        [Category("Appearance")]
        public Color BorderLeft
        {
            get { return renkDizi[2][0, 4]; }
            set
            {
                renkDizi[2][0, 4] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the border right color.
        /// </summary>
        /// <value>The border right.</value>
        [Category("Appearance")]
        public Color BorderRight
        {
            get { return renkDizi[2][0, 5]; }
            set
            {
                renkDizi[2][0, 5] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the border top color.
        /// </summary>
        /// <value>The border top.</value>
        [Category("Appearance")]
        public Color BorderTop
        {
            get { return renkDizi[2][0, 6]; }
            set
            {
                renkDizi[2][0, 6] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the border bottom color.
        /// </summary>
        /// <value>The border bottom.</value>
        [Category("Appearance")]
        public Color BorderBottom
        {
            get { return renkDizi[2][0, 7]; }
            set
            {
                renkDizi[2][0, 7] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the background high focus color.
        /// </summary>
        /// <value>The background high focus.</value>
        [Category("Appearance")]
        public Color BackgroundHighFocus
        {
            get { return renkDizi[2][1, 0]; }
            set
            {
                renkDizi[2][1, 0] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the background low focus color.
        /// </summary>
        /// <value>The background low focus.</value>
        [Category("Appearance")]
        public Color BackgroundLowFocus
        {
            get { return renkDizi[2][1, 1]; }
            set
            {
                renkDizi[2][1, 1] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the shine high focus color.
        /// </summary>
        /// <value>The shine high focus.</value>
        [Category("Appearance")]
        public Color ShineHighFocus
        {
            get { return renkDizi[2][1, 2]; }
            set
            {
                renkDizi[2][1, 2] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the shine low focus color.
        /// </summary>
        /// <value>The shine low focus.</value>
        [Category("Appearance")]
        public Color ShineLowFocus
        {
            get { return renkDizi[2][1, 3]; }
            set
            {
                renkDizi[2][1, 3] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the border left focus color.
        /// </summary>
        /// <value>The border left focus.</value>
        [Category("Appearance")]
        public Color BorderLeftFocus
        {
            get { return renkDizi[2][1, 4]; }
            set
            {
                renkDizi[2][1, 4] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the border right focus color.
        /// </summary>
        /// <value>The border right focus.</value>
        [Category("Appearance")]
        public Color BorderRightFocus
        {
            get { return renkDizi[2][1, 5]; }
            set
            {
                renkDizi[2][1, 5] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the border top focus color.
        /// </summary>
        /// <value>The border top focus.</value>
        [Category("Appearance")]
        public Color BorderTopFocus
        {
            get { return renkDizi[2][1, 6]; }
            set
            {
                renkDizi[2][1, 6] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the border bottom focus color.
        /// </summary>
        /// <value>The border bottom focus.</value>
        [Category("Appearance")]
        public Color BorderBottomFocus
        {
            get { return renkDizi[2][1, 7]; }
            set
            {
                renkDizi[2][1, 7] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the background high pressed color.
        /// </summary>
        /// <value>The background high pressed.</value>
        [Category("Appearance")]
        public Color BackgroundHighPressed
        {
            get { return renkDizi[2][2, 0]; }
            set
            {
                renkDizi[2][2, 0] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the background low pressed color.
        /// </summary>
        /// <value>The background low pressed.</value>
        [Category("Appearance")]
        public Color BackgroundLowPressed
        {
            get { return renkDizi[2][2, 1]; }
            set
            {
                renkDizi[2][2, 1] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the shine high pressed color.
        /// </summary>
        /// <value>The shine high pressed.</value>
        [Category("Appearance")]
        public Color ShineHighPressed
        {
            get { return renkDizi[2][2, 2]; }
            set
            {
                renkDizi[2][2, 2] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the shine low pressed color.
        /// </summary>
        /// <value>The shine low pressed.</value>
        [Category("Appearance")]
        public Color ShineLowPressed
        {
            get { return renkDizi[2][2, 3]; }
            set
            {
                renkDizi[2][2, 3] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the border left pressed color.
        /// </summary>
        /// <value>The border left pressed.</value>
        [Category("Appearance")]
        public Color BorderLeftPressed
        {
            get { return renkDizi[2][2, 4]; }
            set
            {
                renkDizi[2][2, 4] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the border right pressed color.
        /// </summary>
        /// <value>The border right pressed.</value>
        [Category("Appearance")]
        public Color BorderRightPressed
        {
            get { return renkDizi[2][2, 5]; }
            set
            {
                renkDizi[2][2, 5] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the border top pressed color.
        /// </summary>
        /// <value>The border top pressed.</value>
        [Category("Appearance")]
        public Color BorderTopPressed
        {
            get { return renkDizi[2][2, 6]; }
            set
            {
                renkDizi[2][2, 6] = value;
                Invalidate();
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the border bottom pressed color.
        /// </summary>
        /// <value>The border bottom pressed.</value>
        [Category("Appearance")]
        public Color BorderBottomPressed
        {
            get { return renkDizi[2][2, 7]; }
            set
            {
                renkDizi[2][2, 7] = value;
                Invalidate();
                Update();
            }
        }

        #endregion

    }

    #endregion

    #region Designer Generated Code

    partial class ZeroitKaruButton
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            components = new System.ComponentModel.Container();
            buttonIcon = null;
            this.Size = new System.Drawing.Size(100, 25);//yaratýlcak butonun varsayýlan boyutlarý
        }

        #endregion
    }

    #endregion

    #endregion


}
