// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="ChromeTabControl.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    #region ZeroitTabControlChrome    
    /// <summary>
    /// A class collection for rendering a chrome tab control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.TabControl" />
    [Designer(typeof(ZeroitTabcontrolChromeDesigner))]
    public class ZeroitChromeTab : TabControl
    {

        #region Variables
        /// <summary>
        /// The selected tab color
        /// </summary>
        private Color selectedTabColor = Color.White;
        /// <summary>
        /// The background color
        /// </summary>
        private Color backgroundColor = Color.White;
        /// <summary>
        /// The ob
        /// </summary>
        bool OB = false;
        /// <summary>
        /// The c1
        /// </summary>
        Color C1 = Color.FromArgb(78, 87, 100);


        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the color of the square.
        /// </summary>
        /// <value>The color of the square.</value>
        public Color SquareColor
        {
            get { return C1; }
            set
            {
                C1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the selected tab.
        /// </summary>
        /// <value>The color of the selected tab.</value>
        public Color SelectedTabColor
        {
            get { return selectedTabColor; }
            set
            {
                selectedTabColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show outer borders.
        /// </summary>
        /// <value><c>true</c> if show outer borders; otherwise, <c>false</c>.</value>
        public bool ShowOuterBorders
        {
            get { return OB; }
            set
            {
                OB = value;
                Invalidate();
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitChromeTab" /> class.
        /// </summary>
        public ZeroitChromeTab()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(30, 115);
        }
        /// <summary>
        /// This member overrides <see cref="M:System.Windows.Forms.Control.CreateHandle" />.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            try
            {
                SelectedTab.BackColor = selectedTabColor;
            }
            catch
            {
            }
            G.Clear(backgroundColor);
            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
                Rectangle textrectangle = new Rectangle(x2.Location.X + 20, x2.Location.Y, x2.Width - 20, x2.Height);
                if (i == SelectedIndex)
                {
                    G.FillRectangle(new SolidBrush(C1), new Rectangle(x2.Location, new Size(9, x2.Height)));


                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(textrectangle.Location.X + 8, textrectangle.Location.Y + 6));
                                G.DrawString("      " + TabPages[i].Text, Font, Brushes.Black, textrectangle, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Near
                                });
                            }
                            else
                            {
                                G.DrawString(TabPages[i].Text, Font, Brushes.Black, textrectangle, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Near
                                });
                            }
                        }
                        catch
                        {
                            G.DrawString(TabPages[i].Text, Font, Brushes.Black, textrectangle, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Near
                            });
                        }
                    }
                    else
                    {
                        G.DrawString(TabPages[i].Text, Font, Brushes.Black, textrectangle, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Near
                        });
                    }

                }
                else
                {
                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(textrectangle.Location.X + 8, textrectangle.Location.Y + 6));
                                G.DrawString("      " + TabPages[i].Text, Font, Brushes.DimGray, textrectangle, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Near
                                });
                            }
                            else
                            {
                                G.DrawString(TabPages[i].Text, Font, Brushes.DimGray, textrectangle, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Near
                                });
                            }
                        }
                        catch
                        {
                            G.DrawString(TabPages[i].Text, Font, Brushes.DimGray, textrectangle, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Near
                            });
                        }
                    }
                    else
                    {
                        G.DrawString(TabPages[i].Text, Font, Brushes.DimGray, textrectangle, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Near
                        });
                    }
                }
            }

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitTabcontrolChromeDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitTabcontrolChromeDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitTabcontrolChromeSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitTabcontrolChromeSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitTabcontrolChromeSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitChromeTab colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTabcontrolChromeSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitTabcontrolChromeSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitChromeTab;

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
        /// Gets or sets the color of the square.
        /// </summary>
        /// <value>The color of the square.</value>
        public Color SquareColor
        {
            get
            {
                return colUserControl.SquareColor;
            }
            set
            {
                GetPropertyByName("SquareColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the selected tab.
        /// </summary>
        /// <value>The color of the selected tab.</value>
        public Color SelectedTabColor
        {
            get
            {
                return colUserControl.SelectedTabColor;
            }
            set
            {
                GetPropertyByName("SelectedTabColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Color BackgroundColor
        {
            get
            {
                return colUserControl.BackgroundColor;
            }
            set
            {
                GetPropertyByName("BackgroundColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show outer borders].
        /// </summary>
        /// <value><c>true</c> if [show outer borders]; otherwise, <c>false</c>.</value>
        public bool ShowOuterBorders
        {
            get
            {
                return colUserControl.ShowOuterBorders;
            }
            set
            {
                GetPropertyByName("ShowOuterBorders").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("BackgroundColor",
                                 "Background Color", "Appearance",
                                 "Sets the background color."));


            items.Add(new DesignerActionPropertyItem("SquareColor",
                                 "Square Color", "Appearance",
                                 "Sets the highlight color."));

            items.Add(new DesignerActionPropertyItem("SelectedTabColor",
                                 "Selected Tab Color", "Appearance",
                                 "Sets the background color of the selected tab."));

            items.Add(new DesignerActionPropertyItem("ShowOuterBorders",
                                 "Show Outer Borders", "Appearance",
                                 "Sets the outer border."));


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
