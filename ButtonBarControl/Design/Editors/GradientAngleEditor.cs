// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 06-13-2017
// ***********************************************************************
// <copyright file="GradientAngleEditor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class GradientAngleEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    internal class GradientAngleEditor : UITypeEditor
    {
        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:System.Drawing.Design.UITypeEditor"></see> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.</returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"></see> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService;
            GradientEditorUI editor;

            if (context != null && context.Instance != null && provider != null)
            {
                editorService = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
                if (!(value is int && (int) value < 360 && (int) value >= 0))
                {
                    value = 0;
                }
                if (editorService != null)
                {
                    var currentValue = (int) value;
                    editor = new GradientEditorUI(currentValue) {Dock = DockStyle.Fill};
                    editorService.DropDownControl(editor);
                    value = editor.GetValue();
                }
            }

            return value;
        }

        /// <summary>
        /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <returns>true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)"></see> is implemented; otherwise, false.</returns>
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        #region Nested type: GradientEditorUI

        /// <summary>
        /// Class GradientEditorUI.
        /// </summary>
        /// <seealso cref="System.Windows.Forms.UserControl" />
        internal class GradientEditorUI : UserControl
        {
            /// <summary>
            /// The diameter
            /// </summary>
            private int diameter;
            /// <summary>
            /// The hover value
            /// </summary>
            private int hoverValue;
            /// <summary>
            /// The midx
            /// </summary>
            private int midx;
            /// <summary>
            /// The midy
            /// </summary>
            private int midy;
            /// <summary>
            /// The value
            /// </summary>
            private int value;

            /// <summary>
            /// Initializes a new instance of the <see cref="GradientEditorUI"/> class.
            /// </summary>
            internal GradientEditorUI()
            {
                value = 0;
                InitializeComponent();
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="GradientEditorUI"/> class.
            /// </summary>
            /// <param name="value">The value.</param>
            internal GradientEditorUI(int value)
            {
                this.value = value;
                InitializeComponent();
            }

            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>The value.</value>
            public int Value
            {
                get { return value; }
                set
                {
                    if (value != this.value)
                    {
                        this.value = value;
                        OnValueChanged();
                    }
                }
            }

            /// <summary>
            /// Occurs when [value changed].
            /// </summary>
            internal event EventHandler ValueChanged;

            /// <summary>
            /// Called when [value changed].
            /// </summary>
            internal virtual void OnValueChanged()
            {
                if (ValueChanged != null)
                {
                    ValueChanged(this, EventArgs.Empty);
                }
            }

            /// <summary>
            /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
            /// </summary>
            /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
            protected override void OnPaint(PaintEventArgs e)
            {
                PaintValue(e);
            }

            /// <summary>
            /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"></see> event.
            /// </summary>
            /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                if (HitTest(e.Location))
                {
                    int angle = GetAngle(e.Location);
                    if (angle != -1)
                    {
                        value = angle;
                        OnValueChanged();
                    }
                    Invalidate();
                }
            }

            /// <summary>
            /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"></see> event.
            /// </summary>
            /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                if (HitTest(e.Location))
                {
                    int angle = GetAngle(e.Location);
                    if (angle != -1)
                    {
                        hoverValue = angle;
                    }
                    Invalidate(new Rectangle((int) (Width - diameter*0.25), 1, (int) (0.25*diameter),
                                             (int) (2*Font.SizeInPoints)));
                }
            }

            /// <summary>
            /// Hits the test.
            /// </summary>
            /// <param name="point">The point.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            private bool HitTest(Point point)
            {
                var distance = (int) Math.Sqrt((point.X - midx)*(point.X - midx) + (point.Y - midy)*(point.Y - midy));
                return distance <= (diameter*0.7)/2;
            }

            /// <summary>
            /// Gets the angle.
            /// </summary>
            /// <param name="p">The p.</param>
            /// <returns>System.Int32.</returns>
            private int GetAngle(Point p)
            {
                if ((p.X - midx) != 0)
                {
                    var ret = (int) ((Math.Atan((p.Y - midy)/(float) (p.X - midx)))*(180)/Math.PI);
                    if ((p.Y - midy) >= 0 && (p.X - midx) <= 0)
                    {
                        ret = 180 + ret;
                    }
                    else if ((p.Y - midy) <= 0 && (p.X - midx) <= 0)
                    {
                        ret = 180 + ret;
                    }
                    else if ((p.Y - midy) <= 0 && (p.X - midx) >= 0)
                    {
                        ret = 360 + ret;
                    }
                    return ret;
                }
                if ((p.Y - midy) > 0)
                {
                    return 90;
                }
                if ((p.Y - midy) < 0)
                {
                    return 270;
                }
                return -1;
            }

            /// <summary>
            /// Paints the value.
            /// </summary>
            /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
            private void PaintValue(PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                diameter = Math.Min(Height, Width);
                midx = ClientSize.Width/2;
                midy = ClientSize.Height/2;
                DrawFrame(e);
                e.Graphics.DrawString(value.ToString(), Font, Brushes.Red, 1, 1);
                e.Graphics.DrawString(hoverValue.ToString(), Font, Brushes.Green, (float) (Width - diameter*0.25), 1);
                DrawLine(e, value, Color.Red);
                if (HitTest(MousePosition))
                {
                    DrawLine(e, hoverValue, Color.Green);
                }
            }

            /// <summary>
            /// Draws the line.
            /// </summary>
            /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
            /// <param name="val">The value.</param>
            /// <param name="color">The color.</param>
            private void DrawLine(PaintEventArgs e, int val, Color color)
            {
                var p = new Pen(color, 2);
                var current = GetCurrentPoint(val);
                e.Graphics.DrawLine(p, midx, midy, current.X, current.Y);
            }

            /// <summary>
            /// Gets the current point.
            /// </summary>
            /// <param name="val">The value.</param>
            /// <returns>Point.</returns>
            private Point GetCurrentPoint(int val)
            {
                return new Point((int) (midx + Math.Cos(val*Math.PI/180)*diameter*0.8/2),
                                 (int) (midy + Math.Sin(val*Math.PI/180)*diameter*0.8/2));
            }

            /// <summary>
            /// Processes a command key.
            /// </summary>
            /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"></see>, passed by reference, that represents the window message to process.</param>
            /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"></see> values that represents the key to process.</param>
            /// <returns>true if the character was processed by the control; otherwise, false.</returns>
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                if ((Enabled) && ((msg.Msg == 0x100) || (msg.Msg == 260)))
                {
                    switch (keyData)
                    {
                        case Keys.Left:
                            if (value > 0)
                            {
                                value--;
                            }
                            break;

                        case Keys.Up:
                            if (value < 360)
                            {
                                value++;
                            }
                            break;

                        case Keys.Right:
                            if (value < 360)
                            {
                                value++;
                            }
                            break;

                        case Keys.Down:
                            if (value > 0)
                            {
                                value--;
                            }
                            break;
                    }
                    OnValueChanged();
                }
                if (value == 360)
                {
                    value = 0;
                }
                Invalidate();
                return base.ProcessCmdKey(ref msg, keyData);
            }

            /// <summary>
            /// Draws the frame.
            /// </summary>
            /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
            private void DrawFrame(PaintEventArgs e)
            {
                var p = new Pen(Color.Black, 2);
                var drawRect = new Rectangle((int) (midx - 0.7*diameter/2), (int) (midy - 0.7*diameter/2),
                                             (int) (0.7*diameter), (int) (0.7*diameter));
                e.Graphics.DrawEllipse(p, drawRect);
                drawRect.Inflate(1, 1);
                e.Graphics.TranslateClip(1, 1);
                e.Graphics.DrawEllipse(Pens.Gray, drawRect);
                e.Graphics.DrawLine(Pens.Black, midx, midy - diameter/2, midx, midy + diameter/2);
                e.Graphics.DrawLine(Pens.Black, midx - diameter/2, midy, midx + diameter/2, midy);
                e.Graphics.DrawString("0", Font, Brushes.LimeGreen, (float) (midx + 0.8*diameter/2), midy);
                e.Graphics.DrawString("180", Font, Brushes.LimeGreen, (midx - diameter/2), midy);
                e.Graphics.DrawString("90", Font, Brushes.LimeGreen, midx, (float) (midy + 0.8*diameter/2));
                e.Graphics.DrawString("270", Font, Brushes.LimeGreen, midx, (midy - diameter/2));
            }

            /// <summary>
            /// Gets the value.
            /// </summary>
            /// <returns>System.Int32.</returns>
            internal int GetValue()
            {
                return value;
            }

            #region Component Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.SuspendLayout();
                // 
                // GradientEditorUI
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.SystemColors.Window;
                this.Name = "GradientEditorUI";
                this.ResumeLayout(false);
            }

            #endregion
        }

        #endregion
    }
}