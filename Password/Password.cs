// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="Password.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel.Design;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Password

    #region Control

    #region PasswordEye
    // ********************************************* class PasswordEye    
    /// <summary>
    /// A class collection for rendering a password eye.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Designer(typeof(ZeroitPasswordEyeDesigner))]
    public partial class ZeroitPasswordEye : UserControl
    {

        // ******************************** control delegate and event

        /// <summary>
        /// Delegate PasswordEyePropertiesChangedHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PasswordEyePropertiesChangedEventArgs"/> instance containing the event data.</param>
        public delegate void PasswordEyePropertiesChangedHandler(
                        Object sender,
                        PasswordEyePropertiesChangedEventArgs e);

        /// <summary>
        /// Occurs when [password eye properties changed].
        /// </summary>
        public event PasswordEyePropertiesChangedHandler
                            PasswordEyePropertiesChanged;

        // ************************************************* Constants

        /// <summary>
        /// The backcolor
        /// </summary>
        static Color BACKCOLOR = Color.White;
        /// <summary>
        /// The forecolor
        /// </summary>
        static Color FORECOLOR = Color.Black;
        // used to specify whether or 
        // not TextBox Text is masked
        /// <summary>
        /// The password hidden
        /// </summary>
        const char PASSWORD_HIDDEN = '*';
        /// <summary>
        /// The password visible
        /// </summary>
        const char PASSWORD_VISIBLE = '\0';
        // initial TextBox properties
        /// <summary>
        /// The textbox height
        /// </summary>
        const int TEXTBOX_HEIGHT = 23;
        /// <summary>
        /// The textbox location x
        /// </summary>
        const int TEXTBOX_LOCATION_X = 1;
        /// <summary>
        /// The textbox location y
        /// </summary>
        const int TEXTBOX_LOCATION_Y = 1;
        /// <summary>
        /// The textbox maximum width
        /// </summary>
        static int TEXTBOX_MAXIMUM_WIDTH = 20;
        /// <summary>
        /// The textbox maxlength
        /// </summary>
        const int TEXTBOX_MAXLENGTH = 50;
        // initial Button properties
        /// <summary>
        /// The button height
        /// </summary>
        const int BUTTON_HEIGHT = TEXTBOX_HEIGHT;
        /// <summary>
        /// The button width
        /// </summary>
        const int BUTTON_WIDTH = BUTTON_HEIGHT;
        // initial panel properties
        /// <summary>
        /// The panel location x
        /// </summary>
        const int PANEL_LOCATION_X = 1;
        /// <summary>
        /// The panel location y
        /// </summary>
        const int PANEL_LOCATION_Y = 1;
        /// <summary>
        /// The widest character
        /// </summary>
        const string WIDEST_CHARACTER = "W";

        // ************************************************* variables

        /// <summary>
        /// The backcolor
        /// </summary>
        Color backcolor = BACKCOLOR;
        /// <summary>
        /// The forecolor
        /// </summary>
        Color forecolor = FORECOLOR;
        /// <summary>
        /// The textbox maximum width
        /// </summary>
        int textbox_maximum_width = TEXTBOX_MAXIMUM_WIDTH;

        // ************** trigger_passwordeye_properties_changed_event

        /// <summary>
        /// Triggers the passwordeye properties changed event.
        /// </summary>
        void trigger_passwordeye_properties_changed_event()
        {

            if (PasswordEyePropertiesChanged != null)
            {
                PasswordEyePropertiesChanged(
                    this,
                    new PasswordEyePropertiesChangedEventArgs(
                                                backcolor,
                                                button,
                                                this,
                                                forecolor,
                                                textbox_maximum_width,
                                                panel,
                                                textbox));
            }
        }

        // **************************************** textbox_text_width

        /// <summary>
        /// Textboxes the width of the text.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int textbox_text_width()
        {
            string textbox_text = String.Empty;
            int width = 0;
            // build a test string so we 
            // can find the width needed 
            // for the textbox
            while (textbox_text.Length < textbox_maximum_width)
            {
                textbox_text += WIDEST_CHARACTER;
            }

            using (Graphics graphics = textbox.CreateGraphics())
            {
                Size size = TextRenderer.MeasureText(
                                    graphics,
                                    textbox_text,
                                    textbox.Font,
                                    new Size(1, 1),
                                    TextFormatFlags.NoPadding);
                // MeasureText does not appear 
                // to return a correct length; 
                // 2/3 seems to help
                width =
                    round((2.0 * (double)size.Width) / 3.0);
            }

            return (width);
        }

        // *********************************************** PasswordEye

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPasswordEye" /> class.
        /// </summary>
        public ZeroitPasswordEye()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();

            button.MouseDown += new MouseEventHandler(
                                                button_MouseDown);
            button.MouseUp += new MouseEventHandler(
                                                button_MouseUp);
            textbox.FontChanged += new EventHandler(
                                                textbox_FontChanged);
            textbox.TextChanged += new EventHandler(
                                                textbox_TextChanged);


        }

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

        }

        // **************************************************** OnLoad

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);

            set_control_properties();
        }

        // ***************************************************** round

        // http://en.wikipedia.org/wiki/Rounding

        /// <summary>
        /// Rounds the specified double value.
        /// </summary>
        /// <param name="double_value">The double value.</param>
        /// <returns>System.Int32.</returns>
        int round(double double_value)
        {

            return ((int)(double_value + 0.5));
        }

        // ************************************ set_control_properties

        /// <summary>
        /// Sets the control properties.
        /// </summary>
        void set_control_properties()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            int button_location_y = 0;
            // remove all components from 
            // the control
            this.Controls.Clear();
            // remove all components from 
            // the panel
            panel.Controls.Clear();
            // process textbox first; the 
            // textbox width is dependent 
            // on the Font and the 
            // Max_Display properties; in
            // turn the textbox properties 
            // drive most of the control's 
            // other properties
            textbox.BackColor = backcolor;
            textbox.BorderStyle = BorderStyle.None;
            textbox.ForeColor = forecolor;
            // textbox location within 
            // panel is fixed 
            textbox.Location = new Point(TEXTBOX_LOCATION_X,
                                           TEXTBOX_LOCATION_Y);
            textbox.Size = new Size(textbox_text_width(),
                                      textbox.Height);
            // process button next; the 
            // panel width depends upon 
            // both the textbox and button 
            // properties
            button.BackColor = backcolor;
            button.BackgroundImage = Properties.
                                     Resources.
                                     PasswordEyeImage;
            button.BackgroundImageLayout = ImageLayout.Zoom;
            button.FlatStyle = FlatStyle.Flat;
            // when the textbox.Height is 
            // greater than TEXTBOX_HEIGHT 
            // the button.Size takes on 
            // the value 
            //      ( BUTTON_HEIGHT, 
            //        BUTTON_WIDTH ) 
            // and the button is centered 
            // vertically with respect to 
            // the textbox
            if (textbox.Height > TEXTBOX_HEIGHT)
            {
                button.Size = new Size(BUTTON_HEIGHT,
                                         BUTTON_WIDTH);
                button_location_y =
                    round((double)(textbox.Height -
                                         button.Height) / 2.0);
            }
            else
            {
                button.Size = new Size(textbox.Height,
                                         textbox.Height);
                button_location_y = textbox.Location.Y;
            }
            button.Location = new Point(textbox.Location.X +
                                              textbox.Width + 1,
                                          button_location_y);
            // process panel
            panel.BackColor = backcolor;
            // panel location within 
            // control is fixed
            panel.Location = new Point(PANEL_LOCATION_X,
                                         PANEL_LOCATION_Y);
            panel.Size = new Size(
                                    // space preceeds textbox
                                    (textbox.Location.X + 1) +
                                        // space follows textbox
                                        (textbox.Width + 1) +
                                        // space follows button
                                        (button.Width + 1),
                                    // space at top and bottom
                                    (textbox.Height + 2));
            // add back the TextBox and 
            // the Button to the Panel's 
            // control collection
            panel.Controls.Add(textbox);
            panel.Controls.Add(button);
            // add back the Panel to the 
            // control's control 
            // collection
            this.Controls.Add(panel);
            // adjust the width and height 
            // of the control by adding a 
            // pixel at the right, left,
            // top, and bottom
            this.Width = panel.Width + 2;
            this.Height = panel.Height + 2;
            // advise any subscriber that 
            // the control properties have 
            // changed
            trigger_passwordeye_properties_changed_event();
        }

        // ****************************************** button_MouseDown

        /// <summary>
        /// Handles the MouseDown event of the button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void button_MouseDown(object sender,
                                MouseEventArgs e)
        {

            base.OnMouseDown(e);

            textbox.PasswordChar = PASSWORD_VISIBLE;
        }

        // ******************************************** button_MouseUp

        /// <summary>
        /// Handles the MouseUp event of the button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void button_MouseUp(object sender,
                              MouseEventArgs e)
        {

            base.OnMouseUp(e);

            textbox.PasswordChar = PASSWORD_HIDDEN;
        }

        // *************************************** textbox_FontChanged

        /// <summary>
        /// Handles the FontChanged event of the textbox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void textbox_FontChanged(object sender,
                                   EventArgs e)
        {

            base.OnFontChanged(e);

            set_control_properties();
        }

        // *************************************** textbox_TextChanged

        /// <summary>
        /// Handles the TextChanged event of the textbox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void textbox_TextChanged(object sender,
                                   EventArgs e)
        {

            base.OnTextChanged(e);

            trigger_passwordeye_properties_changed_event();
        }

        // ************************************************* BackColor        
        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Category("Appearance"),
         Description("Gets/Sets backcolor of all components"),
         DefaultValue(typeof(Color), "White"),
         Bindable(true)]
        public override Color BackColor
        {

            get
            {
                return (backcolor);
            }
            set
            {
                if (value != backcolor)
                {
                    backcolor = value;
                    set_control_properties();
                }

                //backcolor = value;
                //set_control_properties();
                //Invalidate();

            }
        }

        // ****************************************************** Font

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Category("Appearance"),
         Description("Gets/Sets the password textbox font"),
         Bindable(true)]
        public override Font Font
        {
            get
            {
                return (textbox.Font);
            }
            set
            {
                if (value != textbox.Font)
                {
                    // textbox_FontChanged is 
                    // triggered by the following 
                    // statement
                    textbox.Font = value;
                }
            }
        }

        // ************************************************* ForeColor

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Category("Appearance"),
         Description("Gets/Sets forecolor of all components"),
         DefaultValue(typeof(Color), "Black"),
         Bindable(true)]
        public override Color ForeColor
        {

            get
            {
                return (forecolor);
            }
            set
            {
                if (value != forecolor)
                {
                    forecolor = value;
                    set_control_properties();
                }
            }
        }

        // ********************************************* MaximumWidth

        /// <summary>
        /// Gets or sets the maximum width.
        /// </summary>
        /// <value>The maximum width.</value>
        [Category("Appearance"),
         Description("Gets/Sets the width of the password textbox"),
         DefaultValue(20),
         Bindable(true)]
        public int MaximumWidth
        {

            get
            {
                return (textbox_maximum_width);
            }
            set
            {
                if (value != textbox_maximum_width)
                {
                    textbox_maximum_width = value;
                    set_control_properties();
                }
            }
        }

        // ************************************************* MaxLength

        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>The maximum length.</value>
        [Category("Appearance"),
         Description("Gets/Sets password textbox MaxLength"),
         DefaultValue(50),
         Bindable(true)]
        public int MaxLength
        {

            get
            {
                return (textbox.MaxLength);
            }
            set
            {
                if (value != textbox.MaxLength)
                {
                    textbox.MaxLength = value;
                    trigger_passwordeye_properties_changed_event();
                }
            }
        }

        // ********************************************** PasswordChar

        /// <summary>
        /// Gets or sets the password character.
        /// </summary>
        /// <value>The password character.</value>
        [Category("Appearance"),
         Description("Gets/Sets password textbox PasswordChar"),
         DefaultValue(typeof(char), "*"),
         Bindable(true)]
        public char PasswordChar
        {

            get
            {
                return (textbox.PasswordChar);
            }
            set
            {
                if (textbox.PasswordChar != value)
                {
                    textbox.PasswordChar = value;
                    set_control_properties();
                }
            }
        }

        // ****************************************************** Text

        // http://stackoverflow.com/questions/2881409/
        //     text-property-in-a-usercontrol-in-c-sharp        
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [Category("Appearance")]
        [Description("Gets/Sets password textbox Text")]
        [DefaultValue("")]
        public override string Text
        {

            get
            {
                return (textbox.Text);
            }
            set
            {
                if (value != textbox.Text)
                {
                    textbox.Text = value;
                    set_control_properties();
                }
            }
        }

    } // class PasswordEye

    // ******************* class PasswordEyePropertiesChangedEventArgs
    #endregion

    #region Event

    /// <summary>
    /// Class PasswordEyePropertiesChangedEventArgs.
    /// </summary>
    public class PasswordEyePropertiesChangedEventArgs
    {
        /// <summary>
        /// The backcolor
        /// </summary>
        public Color backcolor;
        /// <summary>
        /// The button
        /// </summary>
        public Button button;
        /// <summary>
        /// The control
        /// </summary>
        public Control control;
        /// <summary>
        /// The forecolor
        /// </summary>
        public Color forecolor;
        /// <summary>
        /// The maximum width
        /// </summary>
        public int maximum_width;
        /// <summary>
        /// The panel
        /// </summary>
        public Panel panel;
        /// <summary>
        /// The textbox
        /// </summary>
        public TextBox textbox;

        // ********************* PasswordEyePropertiesChangedEventArgs

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordEyePropertiesChangedEventArgs"/> class.
        /// </summary>
        /// <param name="backcolor">The backcolor.</param>
        /// <param name="button">The button.</param>
        /// <param name="control">The control.</param>
        /// <param name="forecolor">The forecolor.</param>
        /// <param name="maximum_width">The maximum width.</param>
        /// <param name="panel">The panel.</param>
        /// <param name="textbox">The textbox.</param>
        public PasswordEyePropertiesChangedEventArgs(
                                                Color backcolor,
                                                Button button,
                                                Control control,
                                                Color forecolor,
                                                int maximum_width,
                                                Panel panel,
                                                TextBox textbox)
        {

            this.backcolor = backcolor;
            this.button = button;
            this.control = control;
            this.forecolor = forecolor;
            this.maximum_width = maximum_width;
            this.panel = panel;
            this.textbox = textbox;
        }

    } // class PasswordEyePropertiesChangedEventArgs

    #endregion

    #endregion

    #region Designer Generated Code


    partial class ZeroitPasswordEye
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
            this.panel = new System.Windows.Forms.Panel();
            this.button = new System.Windows.Forms.Button();
            this.textbox = new System.Windows.Forms.TextBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.button);
            this.panel.Controls.Add(this.textbox);
            this.panel.ForeColor = System.Drawing.Color.Black;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(250, 27);
            this.panel.TabIndex = 3;
            // 
            // button
            // 
            this.button.BackgroundImage = Properties.Resources.PasswordEyeImage;
            this.button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button.FlatAppearance.BorderSize = 0;
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button.ForeColor = System.Drawing.Color.Black;
            this.button.Location = new System.Drawing.Point(226, 2);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(21, 21);
            this.button.TabIndex = 1;
            this.button.UseVisualStyleBackColor = false;
            // 
            // textbox
            // 
            this.textbox.BackColor = System.Drawing.Color.White;
            this.textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox.ForeColor = System.Drawing.Color.Black;
            this.textbox.Location = new System.Drawing.Point(1, 1);
            this.textbox.MaxLength = 20;
            this.textbox.Name = "textbox";
            this.textbox.PasswordChar = '*';
            this.textbox.Size = new System.Drawing.Size(224, 23);
            this.textbox.TabIndex = 0;
            // 
            // PasswordEye
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel);
            this.Name = "PasswordEye";
            this.Size = new System.Drawing.Size(256, 36);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The panel
        /// </summary>
        private System.Windows.Forms.Panel panel;
        /// <summary>
        /// The button
        /// </summary>
        private System.Windows.Forms.Button button;
        /// <summary>
        /// The textbox
        /// </summary>
        private System.Windows.Forms.TextBox textbox;

    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(PasswordEyeDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitPasswordEyeDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitPasswordEyeDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitPasswordEyeSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitPasswordEyeSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitPasswordEyeSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitPasswordEye colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitPasswordEyeSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitPasswordEyeSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitPasswordEye;

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
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get
            {
                return colUserControl.Font;
            }
            set
            {
                GetPropertyByName("Font").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum width.
        /// </summary>
        /// <value>The maximum width.</value>
        public int MaximumWidth
        {

            get
            {
                return colUserControl.MaximumWidth;
            }
            set
            {
                GetPropertyByName("MaximumWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>The maximum length.</value>
        public int MaxLength
        {

            get
            {
                return colUserControl.MaxLength;
            }
            set
            {
                GetPropertyByName("MaxLength").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the password character.
        /// </summary>
        /// <value>The password character.</value>
        public char PasswordChar
        {

            get
            {
                return colUserControl.PasswordChar;
            }
            set
            {
                GetPropertyByName("PasswordChar").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {

            get
            {
                return colUserControl.Text;
            }
            set
            {
                GetPropertyByName("Text").SetValue(colUserControl, value);
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
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("Font",
                                 "Font", "Appearance",
                                 "Sets the font of the text."));

            items.Add(new DesignerActionPropertyItem("MaximumWidth",
                                 "Maximum Width", "Appearance",
                                 "Sets the maximum width."));

            items.Add(new DesignerActionPropertyItem("MaxLength",
                                 "Max Length", "Appearance",
                                 "Sets the maximum length."));

            items.Add(new DesignerActionPropertyItem("PasswordChar",
                                 "Password Char", "Appearance",
                                 "Sets the password character."));

            items.Add(new DesignerActionPropertyItem("Text",
                                 "Text", "Appearance",
                                 "Sets the text."));

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
