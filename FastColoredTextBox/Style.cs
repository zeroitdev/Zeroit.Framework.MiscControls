// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="Style.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Style of chars
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <remarks>This is base class for all text and design renderers</remarks>
    public abstract class Style : IDisposable
    {
        /// <summary>
        /// This style is exported to outer formats (HTML for example)
        /// </summary>
        /// <value><c>true</c> if this instance is exportable; otherwise, <c>false</c>.</value>
        public virtual bool IsExportable { get; set; }
        /// <summary>
        /// Occurs when user click on StyleVisualMarker joined to this style
        /// </summary>
        public event EventHandler<VisualMarkerEventArgs> VisualMarkerClick;

        /// <summary>
        /// Constructor
        /// </summary>
        public Style()
        {
            IsExportable = true;
        }

        /// <summary>
        /// Renders given range of text
        /// </summary>
        /// <param name="gr">Graphics object</param>
        /// <param name="position">Position of the range in absolute control coordinates</param>
        /// <param name="range">Rendering range of text</param>
        public abstract void Draw(Graphics gr, Point position, Range range);

        /// <summary>
        /// Occurs when user click on StyleVisualMarker joined to this style
        /// </summary>
        /// <param name="tb">The tb.</param>
        /// <param name="args">The <see cref="VisualMarkerEventArgs"/> instance containing the event data.</param>
        public virtual void OnVisualMarkerClick(ZeroitCodeTextBox tb, VisualMarkerEventArgs args)
        {
            if (VisualMarkerClick != null)
                VisualMarkerClick(tb, args);
        }

        /// <summary>
        /// Shows VisualMarker
        /// Call this method in Draw method, when you need to show VisualMarker for your style
        /// </summary>
        /// <param name="tb">The tb.</param>
        /// <param name="marker">The marker.</param>
        protected virtual void AddVisualMarker(ZeroitCodeTextBox tb, StyleVisualMarker marker)
        {
            tb.AddVisualMarker(marker);
        }

        /// <summary>
        /// Gets the size of range.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <returns>Size.</returns>
        public static Size GetSizeOfRange(Range range)
        {
            return new Size((range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
        }

        /// <summary>
        /// Gets the rounded rectangle.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <param name="d">The d.</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath GetRoundedRectangle(Rectangle rect, int d)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddArc(rect.X, rect.Y, d, d, 180, 90);
            gp.AddArc(rect.X + rect.Width - d, rect.Y, d, d, 270, 90);
            gp.AddArc(rect.X + rect.Width - d, rect.Y + rect.Height - d, d, d, 0, 90);
            gp.AddArc(rect.X, rect.Y + rect.Height - d, d, d, 90, 90);
            gp.AddLine(rect.X, rect.Y + rect.Height - d, rect.X, rect.Y + d / 2);

            return gp;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            ;
        }

        /// <summary>
        /// Returns CSS for export to HTML
        /// </summary>
        /// <returns>System.String.</returns>
        public virtual string GetCSS()
        {
            return "";
        }

        /// <summary>
        /// Returns RTF descriptor for export to RTF
        /// </summary>
        /// <returns>RTFStyleDescriptor.</returns>
        public virtual RTFStyleDescriptor GetRTF()
        {
            return new RTFStyleDescriptor();
        }
    }

    /// <summary>
    /// Style for chars rendering
    /// This renderer can draws chars, with defined fore and back colors
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.Style" />
    public class ZeroitFastTextStyle : Style
    {
        /// <summary>
        /// Gets or sets the fore brush.
        /// </summary>
        /// <value>The fore brush.</value>
        public Brush ForeBrush { get; set; }
        /// <summary>
        /// Gets or sets the background brush.
        /// </summary>
        /// <value>The background brush.</value>
        public Brush BackgroundBrush { get; set; }
        /// <summary>
        /// Gets or sets the font style.
        /// </summary>
        /// <value>The font style.</value>
        public FontStyle FontStyle { get; set; }
        //public readonly Font Font;
        /// <summary>
        /// The string format
        /// </summary>
        public StringFormat stringFormat;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFastTextStyle"/> class.
        /// </summary>
        /// <param name="foreBrush">The fore brush.</param>
        /// <param name="backgroundBrush">The background brush.</param>
        /// <param name="fontStyle">The font style.</param>
        public ZeroitFastTextStyle(Brush foreBrush, Brush backgroundBrush, FontStyle fontStyle)
        {
            this.ForeBrush = foreBrush;
            this.BackgroundBrush = backgroundBrush;
            this.FontStyle = fontStyle;
            stringFormat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces);
        }

        /// <summary>
        /// Renders given range of text
        /// </summary>
        /// <param name="gr">Graphics object</param>
        /// <param name="position">Position of the range in absolute control coordinates</param>
        /// <param name="range">Rendering range of text</param>
        public override void Draw(Graphics gr, Point position, Range range)
        {
            //draw background
            if (BackgroundBrush != null)
                gr.FillRectangle(BackgroundBrush, position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
            //draw chars
            using(var f = new Font(range.tb.Font, FontStyle))
            {
                Line line = range.tb[range.Start.iLine];
                float dx = range.tb.CharWidth;
                float y = position.Y + range.tb.LineInterval/2;
                float x = position.X - range.tb.CharWidth/3;

                if (ForeBrush == null)
                    ForeBrush = new SolidBrush(range.tb.ForeColor);

                if (range.tb.ImeAllowed)
                {
                    //IME mode
                    for (int i = range.Start.iChar; i < range.End.iChar; i++)
                    {
                        SizeF size = ZeroitCodeTextBox.GetCharSize(f, line[i].c);

                        var gs = gr.Save();
                        float k = size.Width > range.tb.CharWidth + 1 ? range.tb.CharWidth/size.Width : 1;
                        gr.TranslateTransform(x, y + (1 - k)*range.tb.CharHeight/2);
                        gr.ScaleTransform(k, (float) Math.Sqrt(k));
                        gr.DrawString(line[i].c.ToString(), f, ForeBrush, 0, 0, stringFormat);
                        gr.Restore(gs);
                        x += dx;
                    }
                }
                else
                {
                    //classic mode 
                    for (int i = range.Start.iChar; i < range.End.iChar; i++)
                    {
                        //draw char
                        gr.DrawString(line[i].c.ToString(), f, ForeBrush, x, y, stringFormat);
                        x += dx;
                    }
                }
            }
        }

        /// <summary>
        /// Returns CSS for export to HTML
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetCSS()
        {
            string result = "";

            if (BackgroundBrush is SolidBrush)
            {
                var s =  ExportToHTML.GetColorAsString((BackgroundBrush as SolidBrush).Color);
                if (s != "")
                    result += "background-color:" + s + ";";
            }
            if (ForeBrush is SolidBrush)
            {
                var s = ExportToHTML.GetColorAsString((ForeBrush as SolidBrush).Color);
                if (s != "")
                    result += "color:" + s + ";";
            }
            if ((FontStyle & FontStyle.Bold) != 0)
                result += "font-weight:bold;";
            if ((FontStyle & FontStyle.Italic) != 0)
                result += "font-style:oblique;";
            if ((FontStyle & FontStyle.Strikeout) != 0)
                result += "text-decoration:line-through;";
            if ((FontStyle & FontStyle.Underline) != 0)
                result += "text-decoration:underline;";

            return result;
        }

        /// <summary>
        /// Returns RTF descriptor for export to RTF
        /// </summary>
        /// <returns>RTFStyleDescriptor.</returns>
        public override RTFStyleDescriptor GetRTF()
        {
            var result = new RTFStyleDescriptor();

            if (BackgroundBrush is SolidBrush)
                result.BackColor = (BackgroundBrush as SolidBrush).Color;
            
            if (ForeBrush is SolidBrush)
                result.ForeColor = (ForeBrush as SolidBrush).Color;
            
            if ((FontStyle & FontStyle.Bold) != 0)
                result.AdditionalTags += @"\b";
            if ((FontStyle & FontStyle.Italic) != 0)
                result.AdditionalTags += @"\i";
            if ((FontStyle & FontStyle.Strikeout) != 0)
                result.AdditionalTags += @"\strike";
            if ((FontStyle & FontStyle.Underline) != 0)
                result.AdditionalTags += @"\ul";

            return result;
        }
    }

    /// <summary>
    /// Renderer for folded block
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.ZeroitFastTextStyle" />
    public class FoldedBlockStyle : ZeroitFastTextStyle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FoldedBlockStyle"/> class.
        /// </summary>
        /// <param name="foreBrush">The fore brush.</param>
        /// <param name="backgroundBrush">The background brush.</param>
        /// <param name="fontStyle">The font style.</param>
        public FoldedBlockStyle(Brush foreBrush, Brush backgroundBrush, FontStyle fontStyle):
            base(foreBrush, backgroundBrush, fontStyle)
        {
        }

        /// <summary>
        /// Draws the specified gr.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="position">The position.</param>
        /// <param name="range">The range.</param>
        public override void Draw(Graphics gr, Point position, Range range)
        {
            if (range.End.iChar > range.Start.iChar)
            {
                base.Draw(gr, position, range);

                int firstNonSpaceSymbolX = position.X;
                
                //find first non space symbol
                for (int i = range.Start.iChar; i < range.End.iChar; i++)
                    if (range.tb[range.Start.iLine][i].c != ' ')
                        break;
                    else
                        firstNonSpaceSymbolX += range.tb.CharWidth;

                //create marker
                range.tb.AddVisualMarker(new FoldedAreaMarker(range.Start.iLine, new Rectangle(firstNonSpaceSymbolX, position.Y, position.X + (range.End.iChar - range.Start.iChar) * range.tb.CharWidth - firstNonSpaceSymbolX, range.tb.CharHeight)));
            }
            else
            {
                //draw '...'
                using(Font f = new Font(range.tb.Font, FontStyle))
                    gr.DrawString("...", f, ForeBrush, range.tb.LeftIndent, position.Y - 2);
                //create marker
                range.tb.AddVisualMarker(new FoldedAreaMarker(range.Start.iLine, new Rectangle(range.tb.LeftIndent + 2, position.Y, 2 * range.tb.CharHeight, range.tb.CharHeight)));
            }
        }
    }

    /// <summary>
    /// Renderer for selected area
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.Style" />
    public class SelectionStyle : Style
    {
        /// <summary>
        /// Gets or sets the background brush.
        /// </summary>
        /// <value>The background brush.</value>
        public Brush BackgroundBrush{ get; set;}
        /// <summary>
        /// Gets the foreground brush.
        /// </summary>
        /// <value>The foreground brush.</value>
        public Brush ForegroundBrush { get; private set; }

        /// <summary>
        /// This style is exported to outer formats (HTML for example)
        /// </summary>
        /// <value><c>true</c> if this instance is exportable; otherwise, <c>false</c>.</value>
        public override bool IsExportable
        {
            get{return false;}  set{}
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionStyle"/> class.
        /// </summary>
        /// <param name="backgroundBrush">The background brush.</param>
        /// <param name="foregroundBrush">The foreground brush.</param>
        public SelectionStyle(Brush backgroundBrush, Brush foregroundBrush = null)
        {
            this.BackgroundBrush = backgroundBrush;
            this.ForegroundBrush = foregroundBrush;
        }

        /// <summary>
        /// Renders given range of text
        /// </summary>
        /// <param name="gr">Graphics object</param>
        /// <param name="position">Position of the range in absolute control coordinates</param>
        /// <param name="range">Rendering range of text</param>
        public override void Draw(Graphics gr, Point position, Range range)
        {
            //draw background
            if (BackgroundBrush != null)
            {
                gr.SmoothingMode = SmoothingMode.None;
                var rect = new Rectangle(position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
                if (rect.Width == 0)
                    return;
                gr.FillRectangle(BackgroundBrush, rect);
                //
                if (ForegroundBrush != null)
                {
                    //draw text
                    gr.SmoothingMode = SmoothingMode.AntiAlias;

                    var r = new Range(range.tb, range.Start.iChar, range.Start.iLine,
                                      Math.Min(range.tb[range.End.iLine].Count, range.End.iChar), range.End.iLine);
                    using (var style = new ZeroitFastTextStyle(ForegroundBrush, null, FontStyle.Regular))
                        style.Draw(gr, new Point(position.X, position.Y - 1), r);
                }
            }
        }
    }

    /// <summary>
    /// Marker style
    /// Draws background color for text
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.Style" />
    public class MarkerStyle : Style
    {
        /// <summary>
        /// Gets or sets the background brush.
        /// </summary>
        /// <value>The background brush.</value>
        public Brush BackgroundBrush{get;set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkerStyle"/> class.
        /// </summary>
        /// <param name="backgroundBrush">The background brush.</param>
        public MarkerStyle(Brush backgroundBrush)
        {
            this.BackgroundBrush = backgroundBrush;
            IsExportable = true;
        }

        /// <summary>
        /// Renders given range of text
        /// </summary>
        /// <param name="gr">Graphics object</param>
        /// <param name="position">Position of the range in absolute control coordinates</param>
        /// <param name="range">Rendering range of text</param>
        public override void Draw(Graphics gr, Point position, Range range)
        {
            //draw background
            if (BackgroundBrush != null)
            {
                Rectangle rect = new Rectangle(position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
                if (rect.Width == 0)
                    return;
                gr.FillRectangle(BackgroundBrush, rect);
            }
        }

        /// <summary>
        /// Returns CSS for export to HTML
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetCSS()
        {
            string result = "";

            if (BackgroundBrush is SolidBrush)
            {
                var s = ExportToHTML.GetColorAsString((BackgroundBrush as SolidBrush).Color);
                if (s != "")
                    result += "background-color:" + s + ";";
            }

            return result;
        }
    }

    /// <summary>
    /// Draws small rectangle for popup menu
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.Style" />
    public class ShortcutStyle : Style
    {
        /// <summary>
        /// The border pen
        /// </summary>
        public Pen borderPen;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortcutStyle"/> class.
        /// </summary>
        /// <param name="borderPen">The border pen.</param>
        public ShortcutStyle(Pen borderPen)
        {
            this.borderPen = borderPen;
        }

        /// <summary>
        /// Renders given range of text
        /// </summary>
        /// <param name="gr">Graphics object</param>
        /// <param name="position">Position of the range in absolute control coordinates</param>
        /// <param name="range">Rendering range of text</param>
        public override void Draw(Graphics gr, Point position, Range range)
        {
            //get last char coordinates
            Point p = range.tb.PlaceToPoint(range.End);
            //draw small square under char
            Rectangle rect = new Rectangle(p.X - 5, p.Y + range.tb.CharHeight - 2, 4, 3);
            gr.FillPath(Brushes.White, GetRoundedRectangle(rect, 1));
            gr.DrawPath(borderPen, GetRoundedRectangle(rect, 1));
            //add visual marker for handle mouse events
            AddVisualMarker(range.tb, new StyleVisualMarker(new Rectangle(p.X-range.tb.CharWidth, p.Y, range.tb.CharWidth, range.tb.CharHeight), this));
        }
    }

    /// <summary>
    /// This style draws a wavy line below a given text range.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.Style" />
    /// <remarks>Thanks for Yallie</remarks>
    public class WavyLineStyle : Style
    {
        /// <summary>
        /// Gets or sets the pen.
        /// </summary>
        /// <value>The pen.</value>
        private Pen Pen { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WavyLineStyle"/> class.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="color">The color.</param>
        public WavyLineStyle(int alpha, Color color)
        {
            Pen = new Pen(Color.FromArgb(alpha, color));
        }

        /// <summary>
        /// Draws the specified gr.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="pos">The position.</param>
        /// <param name="range">The range.</param>
        public override void Draw(Graphics gr, Point pos, Range range)
        {
            var size = GetSizeOfRange(range);
            var start = new Point(pos.X, pos.Y + size.Height - 1);
            var end = new Point(pos.X + size.Width, pos.Y + size.Height - 1);
            DrawWavyLine(gr, start, end);
        }

        /// <summary>
        /// Draws the wavy line.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        private void DrawWavyLine(Graphics graphics, Point start, Point end)
        {
            if (end.X - start.X < 2)
            {
                graphics.DrawLine(Pen, start, end);
                return;
            }

            var offset = -1;
            var points = new List<Point>();

            for (int i = start.X; i <= end.X; i += 2)
            {
                points.Add(new Point(i, start.Y + offset));
                offset = -offset;
            }

            graphics.DrawLines(Pen, points.ToArray());
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();

            if (Pen != null)
                Pen.Dispose();
        }
    }

    /// <summary>
    /// This style is used to mark range of text as ReadOnly block
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.FastControls.Style" />
    /// <remarks>You can inherite this style to add visual effects of readonly text</remarks>
    public class ReadOnlyStyle : Style
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyStyle"/> class.
        /// </summary>
        public ReadOnlyStyle()
        {
            IsExportable = false;
        }

        /// <summary>
        /// Renders given range of text
        /// </summary>
        /// <param name="gr">Graphics object</param>
        /// <param name="position">Position of the range in absolute control coordinates</param>
        /// <param name="range">Rendering range of text</param>
        public override void Draw(Graphics gr, Point position, Range range)
        {
            //
        }
    }
}
