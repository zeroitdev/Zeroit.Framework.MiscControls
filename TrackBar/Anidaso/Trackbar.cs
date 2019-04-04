namespace Zeroit.Framework.MiscControls
{
 //   /// <summary>
 //   /// A class collection for rendering a trackbar.
 //   /// </summary>
 //   /// <seealso cref="System.Windows.Forms.UserControl" />
 //   [DebuggerStepThrough]
	//[DefaultEvent("ValueChanged")]
	//[ProvideProperty("ZeroitFramework", typeof(Control))]
	//public class ZeroitAnidasoTrackbar : UserControl
	//{
	//	private int int_0 = 100;

	//	private int int_1;

	//	private int int_2;

	//	private int int_3;

	//	private int int_4;

	//	private Drag drag_0 = new Drag();

	//	private IContainer icontainer_0;

	//	private Panel bg;

	//	private Panel slider;

 //       EventHandler eventHandler_0;

 //       /// <summary>
 //       /// Gets or sets the color of the backgroud.
 //       /// </summary>
 //       /// <value>The color of the backgroud.</value>
 //       public Color BackgroudColor
	//	{
	//		get
	//		{
	//			return this.bg.BackColor;
	//		}
	//		set
	//		{
	//			this.bg.BackColor = value;
	//		}
	//	}

 //       /// <summary>
 //       /// Gets or sets the border radius.
 //       /// </summary>
 //       /// <value>The border radius.</value>
 //       public int BorderRadius
	//	{
	//		get
	//		{
	//			return this.int_3;
	//		}
	//		set
	//		{
	//			this.int_3 = value;
	//			Ellipse.Apply(this.bg, this.int_3);
	//		}
	//	}

 //       /// <summary>
 //       /// Gets or sets the color of the indicator.
 //       /// </summary>
 //       /// <value>The color of the indicator.</value>
 //       public Color IndicatorColor
	//	{
	//		get
	//		{
	//			return this.slider.BackColor;
	//		}
	//		set
	//		{
	//			this.slider.BackColor = value;
	//		}
	//	}

 //       /// <summary>
 //       /// Gets or sets the maximum value.
 //       /// </summary>
 //       /// <value>The maximum value.</value>
 //       public int MaximumValue
	//	{
	//		get
	//		{
	//			return this.int_0;
	//		}
	//		set
	//		{
	//			this.int_0 = value;
	//			this.slider.Left = (base.Width - this.slider.Width) * this.int_2 / (this.int_0 - this.int_1);
	//		}
	//	}

 //       /// <summary>
 //       /// Gets or sets the minimum value.
 //       /// </summary>
 //       /// <value>The minimum value.</value>
 //       public int MinimumValue
	//	{
	//		get
	//		{
	//			return this.int_1;
	//		}
	//		set
	//		{
	//			this.int_1 = value;
	//			this.slider.Left = (base.Width - this.slider.Width) * this.int_2 / (this.int_0 - this.int_1);
	//		}
	//	}

 //       /// <summary>
 //       /// Gets or sets the slider radius.
 //       /// </summary>
 //       /// <value>The slider radius.</value>
 //       public int SliderRadius
	//	{
	//		get
	//		{
	//			return this.int_4;
	//		}
	//		set
	//		{
	//			this.int_4 = value;
	//			Ellipse.Apply(this.slider, this.int_4);
	//		}
	//	}

 //       /// <summary>
 //       /// Gets or sets the value.
 //       /// </summary>
 //       /// <value>The value.</value>
 //       public int Value
	//	{
	//		get
	//		{
	//			return this.int_2;
	//		}
	//		set
	//		{
	//			if (value > this.int_0)
	//			{
	//				MessageBox.Show("Cannot exceed maximum Value");
	//				return;
	//			}
	//			this.int_2 = value;
	//			this.slider.Left = (this.int_0 - this.int_1) * this.int_2 / (base.Width - 15);
	//		}
	//	}

 //       /// <summary>
 //       /// Initializes a new instance of the <see cref="ZeroitAnidasoTrackbar"/> class.
 //       /// </summary>
 //       public ZeroitAnidasoTrackbar()
	//	{
	//		this.InitializeComponent();
	//	}

	//	private void bg_MouseDown(object sender, MouseEventArgs e)
	//	{
	//		int num = 0;
	//		int num1 = 0;
	//		int num2;
	//		if (e.Button == System.Windows.Forms.MouseButtons.Left)
	//		{
	//			int x = e.X;
	//			if (x > 0 && x + this.slider.Width < base.Width)
	//			{
	//				this.slider.Left = x;
	//				this.Value = this.int_0 * this.slider.Left / (base.Width - 15);
	//				if (this.eventHandler_0 == null)
	//				{
	//					do
	//					{
	//						if (num != num1)
	//						{
	//							break;
	//						}
	//						num1 = 1;
	//						num2 = num;
	//						num = 1;
	//					}
	//					while (1 <= num2);
	//					return;
	//				}
	//				this.eventHandler_0(this, new EventArgs());
	//				return;
	//			}
	//		}
	//		do
	//		{
	//			if (num != num1)
	//			{
	//				break;
	//			}
	//			num1 = 1;
	//			num2 = num;
	//			num = 1;
	//		}
	//		while (1 <= num2);
	//	}

	//	private void bg_MouseMove(object sender, MouseEventArgs e)
	//	{
	//	}

	//	private void bg_Paint(object sender, PaintEventArgs e)
	//	{
	//	}

	//	private void ZeroitAnidasoTrackbar_Load(object sender, EventArgs e)
	//	{
	//		CustomControl.initializeComponent(this);
	//	}

	//	private void ZeroitAnidasoTrackbar_Resize(object sender, EventArgs e)
	//	{
	//		base.Height = this.slider.Height + 10;
	//		this.bg.Width = base.Width;
	//		this.bg.Left = 0;
	//		Ellipse.Apply(this.bg, this.int_3);
	//		Ellipse.Apply(this.slider, this.int_4);
	//	}

	//	protected override void Dispose(bool disposing)
	//	{
	//		if (disposing && this.icontainer_0 != null)
	//		{
	//			this.icontainer_0.Dispose();
	//		}
	//		base.Dispose(disposing);
	//	}

	//	private void InitializeComponent()
	//	{
	//		this.bg = new Panel();
	//		this.slider = new Panel();
	//		base.SuspendLayout();
	//		this.bg.BackColor = Color.DarkGray;
	//		this.bg.Cursor = Cursors.Hand;
	//		this.bg.Location = new Point(0, 8);
	//		this.bg.Name = "bg";
	//		this.bg.Size = new System.Drawing.Size(415, 10);
	//		this.bg.TabIndex = 0;
	//		this.bg.Paint += new PaintEventHandler(this.bg_Paint);
	//		this.bg.MouseDown += new MouseEventHandler(this.bg_MouseDown);
	//		this.bg.MouseMove += new MouseEventHandler(this.bg_MouseMove);
	//		this.slider.BackColor = Color.SeaGreen;
	//		this.slider.Cursor = Cursors.Hand;
	//		this.slider.Location = new Point(0, 3);
	//		this.slider.Name = "slider";
	//		this.slider.Size = new System.Drawing.Size(20, 20);
	//		this.slider.TabIndex = 1;
	//		this.slider.MouseDown += new MouseEventHandler(this.slider_MouseDown);
	//		this.slider.MouseMove += new MouseEventHandler(this.slider_MouseMove);
	//		this.slider.MouseUp += new MouseEventHandler(this.slider_MouseUp);
	//		base.AutoScaleDimensions = new SizeF(6f, 13f);
	//		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	//		this.BackColor = Color.Transparent;
	//		base.Controls.Add(this.slider);
	//		base.Controls.Add(this.bg);
	//		base.Name = "ZeroitAnidasoTrackbar";
	//		base.Size = new System.Drawing.Size(415, 28);
	//		base.Load += new EventHandler(this.ZeroitAnidasoTrackbar_Load);
	//		base.Resize += new EventHandler(this.ZeroitAnidasoTrackbar_Resize);
	//		base.ResumeLayout(false);
	//	}

	//	private void slider_MouseDown(object sender, MouseEventArgs e)
	//	{
	//		this.drag_0.Grab(this.slider);
	//	}

	//	private void slider_MouseMove(object sender, MouseEventArgs e)
	//	{
	//		int num = 0;
	//		int num1 = 0;
	//		int num2;
	//		int left = this.slider.Left;
	//		if (left >= 0 && left + this.slider.Width <= base.Width)
	//		{
	//			this.drag_0.MoveObject(true, false);
	//			int int0 = this.int_0 * this.slider.Left / (base.Width - this.slider.Width);
	//			this.int_2 = int0;
	//			if (int0 < 0)
	//			{
	//				this.Value = 0;
	//			}
	//			else if (int0 > this.int_0)
	//			{
	//				this.Value = this.MaximumValue;
	//			}
	//			if (this.eventHandler_0 == null)
	//			{
	//				do
	//				{
	//					if (num != num1)
	//					{
	//						break;
	//					}
	//					num1 = 1;
	//					num2 = num;
	//					num = 1;
	//				}
	//				while (1 <= num2);
	//				return;
	//			}
	//			this.eventHandler_0(this, new EventArgs());
	//			return;
	//		}
	//		do
	//		{
	//			if (num != num1)
	//			{
	//				break;
	//			}
	//			num1 = 1;
	//			num2 = num;
	//			num = 1;
	//		}
	//		while (1 <= num2);
	//	}

	//	private void slider_MouseUp(object sender, MouseEventArgs e)
	//	{
	//		this.drag_0.Release();
	//	}

	//	public event EventHandler ValueChanged
	//	{
	//		add
	//		{
	//			EventHandler eventHandler;
	//			EventHandler eventHandler0 = this.eventHandler_0;
	//			do
	//			{
	//				eventHandler = eventHandler0;
	//				EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
	//				eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, eventHandler1, eventHandler);
	//			}
	//			while ((object)eventHandler0 != (object)eventHandler);
	//		}
	//		remove
	//		{
	//			EventHandler eventHandler;
	//			EventHandler eventHandler0 = this.eventHandler_0;
	//			do
	//			{
	//				eventHandler = eventHandler0;
	//				EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
	//				eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, eventHandler1, eventHandler);
	//			}
	//			while ((object)eventHandler0 != (object)eventHandler);
	//		}
	//	}
	//}
}