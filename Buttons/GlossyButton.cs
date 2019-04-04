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

    #region Glossy Button

    //#region Control

    //public partial class ZeroitGlossyButton : UserControl
    //{


    //    public ZeroitGlossyButton()
    //    {
    //        InitializeComponent();
    //    }
    //    // Import the Gdi32 DLL
    //    [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    //    // Import the Method from DLL. With this method you can create a Form with rounded corners
    //    private static extern IntPtr CreateRoundRectRgn(int leftRect, int topRect, int rightRect, int bottomRect, int wEllipse, int hEllipse);
    //    // Create a Pen that will draw the border of the button.
    //    Pen p = new Pen(Color.Aqua);
    //    // Configure the BtnText Property
    //    [Description("The text associated with the control")]
    //    [Category("Appearance")]
    //    public string BtnText
    //    {
    //        get
    //        {
    //            return label1.Text;
    //        }
    //        set
    //        {
    //            label1.Text = value;
    //            label1.Location = new Point(this.Width / 2 - label1.Width / 2, this.Height / 2 - label1.Height / 2);
    //        }
    //    }
    //    // Set the font of label1 through the Font Property of GlossyButton
    //    public override Font Font
    //    {
    //        get
    //        {
    //            return label1.Font;
    //        }
    //        set
    //        {
    //            label1.Font = value;
    //            // Center the label
    //            label1.Location = new Point(this.Width / 2 - label1.Width / 2, this.Height / 2 - label1.Height / 2);
    //        }
    //    }

    //    protected void onMouseEnter()
    //    {
    //        p.Color = Color.Red; this.BackColor = Color.Firebrick; this.Invalidate();
    //    }

    //    protected void onMouseDown()
    //    {
    //        this.BackColor = Color.Maroon; this.Invalidate();
    //    }

    //    protected void NormalStyle()
    //    {
    //        p.Color = Color.Aqua; this.BackColor = Color.DodgerBlue; this.Invalidate();
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        base.OnPaint(e);

    //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
    //        // Create the rounded corners for your form (in this case your button)
    //        this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, 3, 3));
    //        // Create a transparent white gradient
    //        LinearGradientBrush lb = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(150, Color.White), Color.FromArgb(50, Color.White), LinearGradientMode.Vertical);
    //        // Draw the gradient
    //        e.Graphics.FillRectangle(lb, 2, 2, this.Width - 6, this.Height / 2);
    //        // Draw the border
    //        e.Graphics.DrawRectangle(p, 0, 0, this.Width - 3, this.Height - 3);
    //    }
    //    protected override void OnSizeChanged(EventArgs e)
    //    {
    //        base.OnSizeChanged(e);
    //        // Center the label
    //        label1.Location = new Point(this.Width / 2 - label1.Width / 2, this.Height / 2 - label1.Height / 2);
    //    }

    //    protected override void OnMouseEnter(EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        onMouseEnter();
    //    }
    //    protected override void OnMouseLeave(EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        NormalStyle();
    //    }
    //    protected override void OnMouseDown(MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        onMouseDown();
    //    }
    //    protected override void OnMouseUp(MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        onMouseEnter();
    //    }

    //    private void label1_MouseEnter(object sender, EventArgs e)
    //    {
    //        onMouseEnter();
    //    }

    //    private void label1_MouseLeave(object sender, EventArgs e)
    //    {
    //        NormalStyle();
    //    }

    //    private void label1_MouseDown(object sender, MouseEventArgs e)
    //    {
    //        onMouseDown();
    //    }

    //    private void label1_MouseUp(object sender, MouseEventArgs e)
    //    {
    //        onMouseEnter();
    //    }

    //}



    //#endregion

    //#region Designer Generated Code

    //partial class ZeroitGlossyButton
    //{
    //    /// <summary> 
    //    /// Required designer variable.
    //    /// </summary>
    //    private System.ComponentModel.IContainer components = null;

    //    /// <summary> 
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null))
    //        {
    //            components.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    #region Component Designer generated code

    //    /// <summary> 
    //    /// Required method for Designer support - do not modify 
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    private void InitializeComponent()
    //    {
    //        this.label1 = new System.Windows.Forms.Label();
    //        this.SuspendLayout();
    //        // 
    //        // label1
    //        // 
    //        this.label1.AutoSize = true;
    //        this.label1.BackColor = System.Drawing.Color.Transparent;
    //        this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    //        this.label1.ForeColor = System.Drawing.SystemColors.Info;
    //        this.label1.Location = new System.Drawing.Point(25, 10);
    //        this.label1.Name = "label1";
    //        this.label1.Size = new System.Drawing.Size(35, 13);
    //        this.label1.TabIndex = 0;
    //        this.label1.Text = "label1";
    //        this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
    //        this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
    //        this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
    //        this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
    //        // 
    //        // GlossyButton
    //        // 
    //        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    //        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    //        this.BackColor = System.Drawing.Color.DodgerBlue;
    //        this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    //        this.Controls.Add(this.label1);
    //        this.DoubleBuffered = true;
    //        this.Name = "GlossyButton";
    //        this.Size = new System.Drawing.Size(86, 32);
    //        this.ResumeLayout(false);
    //        this.PerformLayout();

    //    }

    //    #endregion

    //    private System.Windows.Forms.Label label1;
    //}

    //#endregion

    #endregion


}
