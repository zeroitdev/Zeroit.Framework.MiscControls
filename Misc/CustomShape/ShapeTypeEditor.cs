// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ShapeTypeEditor.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Zeroit.Framework.MiscControls
{
    #region ShapeTypeEditorControl
    /// <summary>
    /// Class ShapeTypeEditorControl.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    internal class ShapeTypeEditorControl : System.Windows.Forms.UserControl
    {
        // Stores the shape
        /// <summary>
        /// The shape
        /// </summary>
        public ShapeType shape;
        // Specification for the UI

        /// <summary>
        /// The numshape
        /// </summary>
        private int _numshape,  //number of shapes
                                /// <summary>
                                /// The numrow
                                /// </summary>
                    _numrow,    //number of rows
                                /// <summary>
                                /// The numcol
                                /// </summary>
                    _numcol,    //number of columns
                                /// <summary>
                                /// The valid width
                                /// </summary>
                    _valid_width,
                    /// <summary>
                    /// The valid height
                    /// </summary>
                    _valid_height,
                    /// <summary>
                    /// The width
                    /// </summary>
                    _width = 20,  //width of each shape
                                  /// <summary>
                                  /// The height
                                  /// </summary>
                    _height = 20; //height of each shape


        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeTypeEditorControl"/> class.
        /// </summary>
        /// <param name="initial_shape">The initial shape.</param>
        public ShapeTypeEditorControl(ShapeType initial_shape)
        {
            this.shape = initial_shape;
            //Find the number of shapes in the enumeration
            int numshape = Enum.GetValues(typeof(ShapeType)).GetLength(0);

            //Find the number of rows and colums to accomodate the shapes
            int numcol = 0, numrow = 0;
            numrow = (int)(Math.Sqrt(numshape));
            numcol = numshape / numrow;
            if (numshape % numcol > 0) numcol++;

            //Record the specifications
            _numshape = numshape;
            _numrow = numrow;
            _numcol = numcol;

            _valid_width = _numcol * _width + (_numcol - 1) * 6 + 2 * 4;
            _valid_height = _numrow * _height + (_numrow - 1) * 6 + 2 * 4;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap bm = new Bitmap(this.Width, this.Height, e.Graphics);
            Graphics g = Graphics.FromImage(bm);
            g.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, bm.Width, bm.Height));
            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(0, 0, this.Width, this.Height));
            int x = 4, y = 4;
            int n = 0;
            foreach (ShapeType shape in Enum.GetValues(typeof(ShapeType)))
            {

                GraphicsPath path = new GraphicsPath();
                ZeroitCustomControl.updateOutline(ref path, shape, _width, _height, 2);
                g.FillRectangle(Brushes.LightGray, 0, 0, bm.Width, bm.Height);
                g.FillPath(Brushes.Yellow, path);
                g.DrawPath(Pens.Red, path);
                e.Graphics.DrawImage(bm, x, y, new Rectangle(new Point(0, 0), new Size(_width + 1, _height + 1)), GraphicsUnit.Pixel);
                if (this.shape.Equals(shape))
                {
                    e.Graphics.DrawRectangle(Pens.Red, new Rectangle(new Point(x - 2, y - 2), new Size(_width + 4, _height + 4)));
                }
                n++;
                x = (n % _numcol) * (_width); x = x + (n % _numcol) * 6 + 4;
                y = (n / _numcol) * (_height); y = y + (n / _numcol) * 6 + 4;

            }
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ShapeTypeEditorControl
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.Name = "ShapeTypeEditorControl";

        }

        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {

            if (e.Button.Equals(MouseButtons.Left))
            {
                if (e.X > _valid_width) return;
                if (e.Y > _valid_height) return;

                int x, y;
                int n;
                x = e.X; y = e.Y;
                n = (y / (_valid_height / _numrow)) * _numcol + ((x / (_valid_width / _numcol)) % _numcol);

                int count = 0;

                foreach (ShapeType shape in Enum.GetValues(typeof(ShapeType)))
                {
                    if (count == n)
                    {
                        this.shape = shape;
                        //close the editor immediately
                        SendKeys.Send("{ENTER}");
                    }
                    count++;
                }
            }

        }

    }

    /// <summary>
    /// Class ShapeTypeEditor.
    /// </summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor" />
    public class ShapeTypeEditor : System.Drawing.Design.UITypeEditor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeTypeEditor"/> class.
        /// </summary>
        public ShapeTypeEditor()
        {
        }

        // Indicates whether the UITypeEditor provides a form-based (modal) dialog, 
        // drop down dialog, or no UI outside of the properties window.
        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle" /> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)" /> method. If the <see cref="T:System.Drawing.Design.UITypeEditor" /> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None" />.</returns>
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        // Displays the UI for value selection.
        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle" /> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider" /> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            // Return the value if the value is not of type ShapeType
            if (value.GetType() != typeof(ShapeType))
                return value;

            // Uses the IWindowsFormsEditorService to display a 
            // drop-down UI in the Properties window.
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                // Display an Shape Type Editor Control and retrieve the value.
                ShapeTypeEditorControl editor = new ShapeTypeEditorControl((ShapeType)value);
                edSvc.DropDownControl(editor);

                // Return the value in the appropraite data format.
                if (value.GetType() == typeof(ShapeType))
                    return editor.shape;
            }
            return value;
        }

        // Draws a representation of the property's value.
        /// <summary>
        /// Paints a representation of the value of an object using the specified <see cref="T:System.Drawing.Design.PaintValueEventArgs" />.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Drawing.Design.PaintValueEventArgs" /> that indicates what to paint and where to paint it.</param>
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        public override void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        {
            Bitmap bm = new Bitmap(e.Bounds.Width + 4, e.Bounds.Height + 4, e.Graphics);
            Graphics g = Graphics.FromImage(bm);
            ShapeType shape = (ShapeType)e.Value;
            GraphicsPath path = new GraphicsPath();

            ZeroitCustomControl.updateOutline(ref path, shape, e.Bounds.Width - 5, e.Bounds.Height - 5, 2);
            g.FillPath(Brushes.Yellow, path);
            g.DrawPath(Pens.Red, path);
            e.Graphics.DrawImage(bm, 3, 3, new Rectangle(new Point(0, 0), new Size(e.Bounds.Width, e.Bounds.Height)), GraphicsUnit.Pixel);

        }

        // Indicates whether the UITypeEditor supports painting a 
        // representation of a property's value.
        /// <summary>
        /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that can be used to gain additional context information.</param>
        /// <returns>true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)" /> is implemented; otherwise, false.</returns>
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }
    }


    #endregion
}
