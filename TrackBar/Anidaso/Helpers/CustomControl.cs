// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="CustomControl.cs" company="Zeroit Dev Technologies">
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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.Helper
{
    /// <summary>
    /// Class CustomControl.
    /// </summary>
    public static class CustomControl
    {
        /// <summary>
        /// The myidentity
        /// </summary>
        public static string myidentity;

        /// <summary>
        /// Initializes static members of the <see cref="CustomControl"/> class.
        /// </summary>
        static CustomControl()
        {
            int num = 0;
            int num1 = 0;
            int num2;
            CustomControl.myidentity = "";
            if (!CustomControl.Paint_())
            {
                do
                {
                    if (num != num1)
                    {
                        break;
                    }
                    num1 = 1;
                    num2 = num;
                    num = 1;
                }
                while (1 <= num2);
            }
            else
            {
                CustomControl.initializeComponent(true);
            }
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        /// <param name="sender">The sender.</param>
        public static void initializeComponent(Control sender)
        {
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        /// <param name="firstTime">if set to <c>true</c> [first time].</param>
        public static void initializeComponent(bool firstTime)
        {
            //DialogResult dialogResult;
            //if (firstTime)
            //{
            //    MessageBox.Show("Zeroit Control", "Zeroit License", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
            //if (CustomControl.Paint_())
            //{
            //    string str = CustomControl.RenderComplete();
            //    do
            //    {
            //        if (str.ToLower().Trim() == "true")
            //        {
            //            return;
            //        }

            //        dialogResult = MessageBox.Show(string.Concat(str, "", MessageBoxButtons.AbortRetryIgnore,
            //            MessageBoxIcon.Exclamation));
            //    }
            //    while (dialogResult == DialogResult.Retry);
            //    if (dialogResult == DialogResult.Abort)
            //    {
            //        cmd.EXECUTECMD("taskkill /im devenv.exe /f");
            //    }
            //    if (dialogResult == DialogResult.Ignore & firstTime)
            //    {
            //        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer()
            //        {
            //            Interval = 5000
            //        };
            //        timer.Tick += new EventHandler(CustomControl.smethod_0);
            //        timer.Start();
            //        return;
            //    }
            //}
        }

        /// <summary>
        /// Paints this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Paint_()
        {
            if (Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Renders the complete.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string RenderComplete()
        {
            if (CustomControl.myidentity.Trim().Length == 0)
            {
                CustomControl.myidentity = CustomUserControl.Value().ToString();
            }
            return true.ToString();
        }

        /// <summary>
        /// Handles the 0 event of the smethod control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private static void smethod_0(object sender, EventArgs e)
        {
            ((System.Windows.Forms.Timer)sender).Enabled = false;
            CustomControl.initializeComponent(false);
            ((System.Windows.Forms.Timer)sender).Enabled = true;
        }

        /// <summary>
        /// Class Class1.
        /// </summary>
        private class Class1
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Class1"/> class.
            /// </summary>
            public Class1()
            {
            }

            /// <summary>
            /// Methods the 0.
            /// </summary>
            /// <param name="string_0">The string 0.</param>
            /// <returns>CustomControl.Class1.Acura.</returns>
            private CustomControl.Class1.Acura method_0(string string_0)
            {
                CustomControl.Class1.Acura acura = new CustomControl.Class1.Acura(string_0)
                {
                    Text = Environment.GetFolderPath(Environment.SpecialFolder.Recent),
                    Enabled = true,
                    Width = Strings.Len("12345678901234567890"),
                    Height = Strings.Len("ABCDEFGH0ABCDEFGH1ABCDEFGH2ABCDEFGH"),
                    Visible = true
                };
                return acura;
            }

            /// <summary>
            /// Methods the 1.
            /// </summary>
            /// <param name="string_0">The string 0.</param>
            /// <returns>CustomControl.Class1.Struct3.</returns>
            private CustomControl.Class1.Struct3 method_1(string string_0)
            {
                CustomControl.Class1.Struct3 struct3 = new CustomControl.Class1.Struct3();
                struct3.Text = checked((checked(DateTime.DaysInMonth(DateAndTime.Year(DateAndTime.Now), DateAndTime.Month(DateAndTime.Now)) + Strings.Len("1234567890"))) * Strings.Len("0123456789"));
                Environment.GetFolderPath(Environment.SpecialFolder.Recent);
                struct3.Enabled = true;
                struct3.Width = Strings.Len("12345678901234567890");
                struct3.Height = Strings.Len("ABCDEFGH0ABCDEFGH1ABCDEFGH2ABCDEFGH");
                struct3.Visible = true;
                return struct3;
            }

            /// <summary>
            /// Struct Acura
            /// </summary>
            public struct Acura
            {
                /// <summary>
                /// The text
                /// </summary>
                public string Text;

                /// <summary>
                /// The enabled
                /// </summary>
                public bool Enabled;

                /// <summary>
                /// The width
                /// </summary>
                public int Width;

                /// <summary>
                /// The height
                /// </summary>
                public int Height;

                /// <summary>
                /// The visible
                /// </summary>
                public bool Visible;

                /// <summary>
                /// Initializes a new instance of the <see cref="Acura"/> struct.
                /// </summary>
                /// <param name="String1">The string1.</param>
                public Acura(string String1)
                {
                    this = new CustomControl.Class1.Acura()
                    {
                        Text = String1
                    };
                }

                /// <summary>
                /// Lexuses the specified string1.
                /// </summary>
                /// <param name="String1">The string1.</param>
                /// <returns>CustomControl.Class1.Acura.</returns>
                public CustomControl.Class1.Acura Lexus(int String1)
                {
                    this.Text = Conversions.ToString(String1);
                    return new CustomControl.Class1.Acura(this.Text);
                }

                /// <summary>
                /// Methods the 0.
                /// </summary>
                /// <param name="int_0">The int 0.</param>
                /// <param name="int_1">The int 1.</param>
                private void method_0(int int_0, int int_1)
                {
                    this.Text = Conversion.Str(checked(Strings.Len(int_0) + int_1));

                }

                /// <summary>
                /// Sorts the tree.
                /// </summary>
                /// <param name="ctree">The ctree.</param>
                /// <param name="so">The so.</param>
                public void SortTree(TreeView ctree, SortOrder so)
                {
                    object[] objectValue;
                    try
                    {
                        TreeView treeView = new TreeView();
                        string[] text = new string[checked(checked(ctree.GetNodeCount(false) - 1) + 1)];
                        int i = 0;
                        int j = 0;
                        int length = checked(checked((int)text.Length) - 1);
                        for (i = 0; i <= length; i++)
                        {
                            text[i] = ctree.Nodes[i].Text;
                            TreeNodeCollection nodes = treeView.Nodes;
                            objectValue = new object[] { RuntimeHelpers.GetObjectValue(ctree.Nodes[i].Clone()) };
                            NewLateBinding.LateCall(nodes, null, "Add", objectValue, null, null, null, true);
                        }
                        if (so != SortOrder.Ascending)
                        {
                            Array.Reverse(text);
                        }
                        else
                        {
                            Array.Sort<string>(text);
                        }
                        for (i = checked(ctree.GetNodeCount(false) - 1); i >= 0; i = checked(i + -1))
                        {
                            ctree.Nodes[i].Remove();
                        }
                        int num = checked(checked((int)text.Length) - 1);
                        for (j = 0; j <= num; j++)
                        {
                            int nodeCount = checked(treeView.GetNodeCount(false) - 1);
                            for (i = 0; i <= nodeCount; i++)
                            {
                                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(text[j].Trim(), treeView.Nodes[i].Text, false) == 0)
                                {
                                    TreeNodeCollection treeNodeCollections = ctree.Nodes;
                                    objectValue = new object[] { RuntimeHelpers.GetObjectValue(treeView.Nodes[i].Clone()) };
                                    NewLateBinding.LateCall(treeNodeCollections, null, "Add", objectValue, null, null, null, true);
                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        ProjectData.SetProjectError(exception);
                        ProjectData.ClearProjectError();
                    }
                }
            }

            /// <summary>
            /// Struct Struct3
            /// </summary>
            private struct Struct3
            {
                /// <summary>
                /// The text
                /// </summary>
                public int Text;

                /// <summary>
                /// The enabled
                /// </summary>
                public bool Enabled;

                /// <summary>
                /// The width
                /// </summary>
                public int Width;

                /// <summary>
                /// The height
                /// </summary>
                public int Height;

                /// <summary>
                /// The visible
                /// </summary>
                public bool Visible;

                /// <summary>
                /// Initializes a new instance of the <see cref="Struct3"/> struct.
                /// </summary>
                /// <param name="String1">The string1.</param>
                public Struct3(int String1)
                {
                    this = new CustomControl.Class1.Struct3()
                    {
                        Text = String1
                    };
                }

                /// <summary>
                /// Lexuses the specified string1.
                /// </summary>
                /// <param name="String1">The string1.</param>
                /// <returns>CustomControl.Class1.Acura.</returns>
                public CustomControl.Class1.Acura Lexus(int String1)
                {
                    this.Text = String1;
                    return new CustomControl.Class1.Acura(Conversions.ToString(this.Text));
                }

                /// <summary>
                /// Methods the 0.
                /// </summary>
                /// <param name="int_0">The int 0.</param>
                /// <param name="int_1">The int 1.</param>
                private void method_0(int int_0, int int_1)
                {
                    this.Text = Conversions.ToInteger(Conversion.Str(checked(Strings.Len(int_0) + int_1)));
                    //this.(Conversions.ToInteger(SystemInformation.UserName));
                }
            }

            /// <summary>
            /// Struct Struct4
            /// </summary>
            private struct Struct4
            {
                /// <summary>
                /// The text
                /// </summary>
                public DataTable Text;

                /// <summary>
                /// The enabled
                /// </summary>
                public bool Enabled;

                /// <summary>
                /// The width
                /// </summary>
                public int Width;

                /// <summary>
                /// The height
                /// </summary>
                public int Height;

                /// <summary>
                /// The visible
                /// </summary>
                public bool Visible;

                /// <summary>
                /// Initializes a new instance of the <see cref="Struct4"/> struct.
                /// </summary>
                /// <param name="String1">The string1.</param>
                public Struct4(string String1)
                {
                    this = new CustomControl.Class1.Struct4();
                }
            }

            /// <summary>
            /// Struct Struct5
            /// </summary>
            private struct Struct5
            {
                /// <summary>
                /// The text
                /// </summary>
                public double Text;

                /// <summary>
                /// The enabled
                /// </summary>
                public bool Enabled;

                /// <summary>
                /// The width
                /// </summary>
                public int Width;

                /// <summary>
                /// The height
                /// </summary>
                public int Height;

                /// <summary>
                /// The visible
                /// </summary>
                public bool Visible;

                /// <summary>
                /// Initializes a new instance of the <see cref="Struct5"/> struct.
                /// </summary>
                /// <param name="String1">The string1.</param>
                public Struct5(double String1)
                {
                    this = new CustomControl.Class1.Struct5()
                    {
                        Text = String1
                    };
                }
            }
        }
    }

}
