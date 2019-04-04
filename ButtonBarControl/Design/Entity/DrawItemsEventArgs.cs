// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="DrawItemsEventArgs.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class holding information related to <see cref="ZeroitToxicButton.CustomDrawItems" /> event.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class DrawItemsEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DrawItemEventArgs" /> with supplied arguments.
        /// </summary>
        /// <param name="ge">Graphics object where drawing will be done</param>
        /// <param name="bounds">Bound of <see cref="BarItem" /></param>
        /// <param name="item"><see cref="BarItem" /> to draw</param>
        /// <param name="state"><see cref="Enums.State" /> or <see cref="BarItem" /></param>
        /// <param name="bar"><see cref="ZeroitToxicButton" /> control</param>
        public DrawItemsEventArgs(Graphics ge, Rectangle bounds, BarItem item, State state, ZeroitToxicButton bar)
        {
            Handeled = false;
            Graphics = ge;
            Bounds = bounds;
            Item = item;
            State = state;
            Bar = bar;
        }

        /// <summary>
        /// Gets or sets drwaing has been done by user or not.
        /// </summary>
        /// <value><c>true</c> if handeled; otherwise, <c>false</c>.</value>
        public bool Handeled { get; set; }

        /// <summary>
        /// Gets Graphics surface.
        /// </summary>
        /// <value>The graphics.</value>
        public Graphics Graphics { get; private set; }

        /// <summary>
        /// Gets Bounds of <see cref="BarItem" />
        /// </summary>
        /// <value>The bounds.</value>
        public Rectangle Bounds { get; private set; }

        /// <summary>
        /// Gets related <see cref="BarItem" />
        /// </summary>
        /// <value>The item.</value>
        public BarItem Item { get; private set; }

        /// <summary>
        /// Gets related <see cref="ZeroitToxicButton" />
        /// </summary>
        /// <value>The bar.</value>
        public ZeroitToxicButton Bar { get; private set; }

        /// <summary>
        /// Gets <see cref="Enums.State" /> of <see cref="BarItem" />
        /// </summary>
        /// <value>The state.</value>
        public State State { get; private set; }

        /// <summary>
        /// Draws Item Background.
        /// </summary>
        public void DrawItemBackGround()
        {
            if (Bounds.Height == 0 || Bounds.Width == 0)
            {
                return;
            }
            switch (State)
            {
                case State.Selected:
                    PaintUtility.PaintGradientRectangle(Graphics, Bounds,
                                                        Item.Appearance.SelectedStyle.IsEmpty
                                                            ? Bar.CurrentAppearance.Item.SelectedStyle
                                                            : Item.Appearance.SelectedStyle);
                    break;
                case State.Disabled:
                    PaintUtility.PaintGradientRectangle(Graphics, Bounds,
                                                        Item.Appearance.DisabledStyle.IsEmpty
                                                            ? Bar.CurrentAppearance.Item.DisabledStyle
                                                            : Item.Appearance.DisabledStyle);
                    break;
                case State.Hover:
                    PaintUtility.PaintGradientRectangle(Graphics, Bounds,
                                                        Item.Appearance.HoverStyle.IsEmpty
                                                            ? Bar.CurrentAppearance.Item.HoverStyle
                                                            : Item.Appearance.HoverStyle);
                    break;
                case State.SelectedHover:
                    PaintUtility.PaintGradientRectangle(Graphics, Bounds,
                                                        Item.Appearance.SelectedHoverStyle.IsEmpty
                                                            ? Bar.CurrentAppearance.Item.SelectedHoverStyle
                                                            : Item.Appearance.SelectedHoverStyle);
                    break;
                case State.Normal:
                    PaintUtility.PaintGradientRectangle(Graphics, Bounds,
                                                        Item.Appearance.BackStyle.IsEmpty
                                                            ? Bar.CurrentAppearance.Item.BackStyle
                                                            : Item.Appearance.BackStyle);
                    break;
                case State.Pressed:
                    PaintUtility.PaintGradientRectangle(Graphics, Bounds,
                                                        Item.Appearance.ClickStyle.IsEmpty
                                                            ? Bar.CurrentAppearance.Item.ClickStyle
                                                            : Item.Appearance.ClickStyle);
                    break;
            }
        }

        /// <summary>
        /// Draws Item Border
        /// </summary>
        public void DrawItemBorder()
        {
            if (!Bar.ShowBorders && Item.ShowBorder == ShowBorder.Inherit || Item.ShowBorder == ShowBorder.NotShow)
            {
                return;
            }
            switch (State)
            {
                case State.Selected:
                    PaintUtility.PaintBorder(Graphics, Bounds,
                                             Item.Appearance.SelectedBorder.IsEmpty
                                                 ? Bar.CurrentAppearance.Item.SelectedBorder
                                                 : Item.Appearance.SelectedBorder);
                    break;
                case State.Disabled:
                    PaintUtility.PaintBorder(Graphics, Bounds,
                                             Item.Appearance.DisabledBorder.IsEmpty
                                                 ? Bar.CurrentAppearance.Item.DisabledBorder
                                                 : Item.Appearance.DisabledBorder);
                    break;
                case State.Hover:
                    PaintUtility.PaintBorder(Graphics, Bounds,
                                             Item.Appearance.HoverBorder.IsEmpty
                                                 ? Bar.CurrentAppearance.Item.HoverBorder
                                                 : Item.Appearance.HoverBorder);
                    break;
                case State.SelectedHover:
                    PaintUtility.PaintBorder(Graphics, Bounds,
                                             Item.Appearance.HoverBorder.IsEmpty
                                                 ? Bar.CurrentAppearance.Item.HoverBorder
                                                 : Item.Appearance.HoverBorder);
                    break;
                case State.Normal:
                    PaintUtility.PaintBorder(Graphics, Bounds,
                                             Item.Appearance.NormalBorder.IsEmpty
                                                 ? Bar.CurrentAppearance.Item.NormalBorder
                                                 : Item.Appearance.NormalBorder);
                    break;
                case State.Pressed:
                    PaintUtility.PaintBorder(Graphics, Bounds,
                                             Item.Appearance.SelectedBorder.IsEmpty
                                                 ? Bar.CurrentAppearance.Item.SelectedBorder
                                                 : Item.Appearance.SelectedBorder);
                    break;
            }
        }

        /// <summary>
        /// Draw related icon if any.
        /// </summary>
        public void DrawIcon()
        {
            ImageAlignment alignment = Item.ImageAlignment == ItemImageAlignment.Inherit
                                           ? Bar.ImageAlignment
                                           : ((ImageAlignment) ((int) Item.ImageAlignment));
            var b = new Rectangle(Bounds.Location, Bounds.Size);
            var iconSize = Size.Empty;
            if (Bar.ImageList != null && Item.ImageIndex >= 0 && Item.ImageIndex < Bar.ImageList.Images.Count)
            {
                iconSize = Bar.ImageList.ImageSize;
            }
            b.Inflate(-2, -2);
            var iconRect = new Rectangle(0, 0,
                                         iconSize.Width, iconSize.Height);
            if (alignment == ImageAlignment.Top || alignment == ImageAlignment.Bottom)
                iconRect.X = b.X + (b.Width - iconSize.Width)/2;
            else if (alignment == ImageAlignment.Left)
                iconRect.X = b.X;
            else
                iconRect.X = b.X + b.Width - iconSize.Width;

            if (alignment == ImageAlignment.Top)
                iconRect.Y = b.Y;
            else if (alignment == ImageAlignment.Bottom)
                iconRect.Y = b.Y + b.Height - iconSize.Height;
            else if (alignment == ImageAlignment.Right || alignment == ImageAlignment.Left)
                iconRect.Y = b.Y + (b.Height - iconSize.Height)/2;

            if (State == State.Pressed)
            {
                iconRect.Offset(1, 1);
            }
            if (Bar.ImageList != null && Item.ImageIndex >= 0 && Item.ImageIndex < Bar.ImageList.Images.Count)
            {
                if (Item.Enabled)
                {
                    Graphics.DrawImage(Bar.ImageList.Images[Item.ImageIndex], iconRect.X, iconRect.Y);
                }
                else
                {
                    ControlPaint.DrawImageDisabled(Graphics, Bar.ImageList.Images[Item.ImageIndex], iconRect.X,
                                                   iconRect.Y, Bar.BackColor);
                }
            }
        }

        /// <summary>
        /// Draw Caption of <see cref="BarItem" />
        /// </summary>
        public void DrawItemText()
        {
            ImageAlignment alignment = Item.ImageAlignment == ItemImageAlignment.Inherit
                                           ? Bar.ImageAlignment
                                           : ((ImageAlignment) ((int) Item.ImageAlignment));
            var b = new Rectangle(Bounds.Location, Bounds.Size);
            var iconSize = Size.Empty;
            if (Bar.ImageList != null && Item.ImageIndex >= 0 && Item.ImageIndex < Bar.ImageList.Images.Count)
            {
                iconSize = Bar.ImageList.ImageSize;
            }
            int iW = (!iconSize.IsEmpty && (alignment == ImageAlignment.Left || alignment == ImageAlignment.Right)
                          ? iconSize.Width
                          : 0);
            int iH = (!iconSize.IsEmpty && (alignment == ImageAlignment.Bottom || alignment == ImageAlignment.Top)
                          ? iconSize.Height
                          : 0);

            var textRect = new Rectangle(0, 0,
                                         Bounds.Width - iW - 1, Bounds.Height - iH - 2);
            if (alignment == ImageAlignment.Top || alignment == ImageAlignment.Bottom)
                textRect.X = b.X;
            else if (alignment == ImageAlignment.Left)
                textRect.X = b.X + iW;
            else
                textRect.X = Bounds.X;

            if (alignment == ImageAlignment.Bottom || alignment == ImageAlignment.Right)
                textRect.Y = b.Y;
            else if (alignment == ImageAlignment.Top)
                textRect.Y = b.Y + iH;
            else if (alignment == ImageAlignment.Left)
                textRect.Y = b.Y;


            string itemText = Item.Caption;
            var c = Color.Empty;
            switch (State)
            {
                case State.Selected:
                    c = Item.Appearance.SelectedForeGround.IsEmpty
                            ? Bar.CurrentAppearance.Item.SelectedForeGround
                            : Item.Appearance.SelectedForeGround;
                    break;
                case State.Disabled:
                    c = Item.Appearance.DisabledForeGround.IsEmpty
                            ? Bar.CurrentAppearance.Item.DisabledForeGround
                            : Item.Appearance.DisabledForeGround;
                    break;
                case State.Hover:
                    c = Item.Appearance.HoverForeGround.IsEmpty
                            ? Bar.CurrentAppearance.Item.HoverForeGround
                            : Item.Appearance.HoverForeGround;
                    break;
                case State.SelectedHover:
                    c = Item.Appearance.HoverForeGround.IsEmpty
                            ? Bar.CurrentAppearance.Item.HoverForeGround
                            : Item.Appearance.HoverForeGround;
                    break;
                case State.Normal:
                    c = Item.Appearance.NormalForeGround.IsEmpty
                            ? Bar.CurrentAppearance.Item.NormalForeGround
                            : Item.Appearance.NormalForeGround;
                    break;
                case State.Pressed:
                    c = Item.Appearance.SelectedForeGround.IsEmpty
                            ? Bar.CurrentAppearance.Item.SelectedForeGround
                            : Item.Appearance.SelectedForeGround;
                    break;
            }
            PaintUtility.DrawString(Graphics, textRect, itemText,
                                    Item.Appearance.AppearenceText.IsEmpty
                                        ? Bar.CurrentAppearance.Item.AppearenceText
                                        : Item.Appearance.AppearenceText, Bar.UseMnemonic, c);
        }
    }
}