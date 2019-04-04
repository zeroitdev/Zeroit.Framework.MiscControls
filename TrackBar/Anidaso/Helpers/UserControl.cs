// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 02-20-2018
// ***********************************************************************
// <copyright file="UserControl.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Management;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls.Helper
{
    /// <summary>
    /// Class CustomUserControl.
    /// </summary>
    public static class CustomUserControl
	{
        /// <summary>
        /// The string 0
        /// </summary>
        private static string string_0;

        /// <summary>
        /// The string 1
        /// </summary>
        private static string string_1;

        /// <summary>
        /// Initializes static members of the <see cref="CustomUserControl"/> class.
        /// </summary>
        static CustomUserControl()
		{
			CustomUserControl.string_0 = "";
			CustomUserControl.string_1 = string.Empty;
		}

        /// <summary>
        /// Gets the hexadecimal string.
        /// </summary>
        /// <param name="bt">The bt.</param>
        /// <returns>System.String.</returns>
        private static string GetHexString(IList<byte> bt)
		{
			char chr;
			string empty = string.Empty;
			for (int i = 0; i < bt.Count; i++)
			{
				byte item = bt[i];
				int num = item & 15;
				int num1 = item >> 4 & 15;
				if (num1 <= 9)
				{
					empty = string.Concat(empty, num1.ToString(CultureInfo.InvariantCulture));
				}
				else
				{
					chr = (char)(num1 - 10 + 65);
					empty = string.Concat(empty, chr.ToString(CultureInfo.InvariantCulture));
				}
				if (num <= 9)
				{
					empty = string.Concat(empty, num.ToString(CultureInfo.InvariantCulture));
				}
				else
				{
					chr = (char)(num - 10 + 65);
					empty = string.Concat(empty, chr.ToString(CultureInfo.InvariantCulture));
				}
				if (i + 1 != bt.Count && (i + 1) % 2 == 0)
				{
					empty = string.Concat(empty, "-");
				}
			}
			return empty;
		}

        /// <summary>
        /// Smethods the 0.
        /// </summary>
        /// <param name="string_2">The string 2.</param>
        /// <param name="string_3">The string 3.</param>
        /// <param name="string_4">The string 4.</param>
        /// <returns>System.String.</returns>
        private static string smethod_0(string string_2, string string_3, string string_4)
		{
			string str = "";
			foreach (ManagementBaseObject instance in (new ManagementClass(string_2)).GetInstances())
			{
				if (instance[string_4].ToString() != "True" || str != "")
				{
					continue;
				}
				try
				{
					str = instance[string_3].ToString();
					return str;
				}
				catch
				{
				}
			}
			return str;
		}

        /// <summary>
        /// Smethods the 1.
        /// </summary>
        /// <param name="string_2">The string 2.</param>
        /// <param name="string_3">The string 3.</param>
        /// <returns>System.String.</returns>
        private static string smethod_1(string string_2, string string_3)
		{
			string str = "";
			foreach (ManagementBaseObject instance in (new ManagementClass(string_2)).GetInstances())
			{
				if (str != "")
				{
					continue;
				}
				try
				{
					str = instance[string_3].ToString();
					return str;
				}
				catch
				{
				}
			}
			return str;
		}

        /// <summary>
        /// Smethods the 2.
        /// </summary>
        /// <returns>System.String.</returns>
        private static string smethod_2()
		{
			return string.Concat(CustomUserControl.smethod_1("Win32_DiskDrive", "Model"), CustomUserControl.smethod_1("Win32_DiskDrive", "Manufacturer"), CustomUserControl.smethod_1("Win32_DiskDrive", "Signature"), CustomUserControl.smethod_1("Win32_DiskDrive", "TotalHeads"));
		}

        /// <summary>
        /// Smethods the 3.
        /// </summary>
        /// <returns>System.String.</returns>
        private static string smethod_3()
		{
			return string.Concat(CustomUserControl.smethod_1("Win32_VideoController", "DriverVersion"), CustomUserControl.smethod_1("Win32_VideoController", "Name"));
		}

        /// <summary>
        /// Smethods the 4.
        /// </summary>
        /// <returns>System.String.</returns>
        private static string smethod_4()
		{
			return CustomUserControl.smethod_0("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
		}

        /// <summary>
        /// Smethods the 5.
        /// </summary>
        /// <param name="string_2">The string 2.</param>
        /// <returns>System.String.</returns>
        private static string smethod_5(string string_2)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] bytes = Encoding.ASCII.GetBytes(string_2);
			return CustomUserControl.GetHexString(mD5CryptoServiceProvider.ComputeHash(bytes));
		}

        /// <summary>
        /// Smethods the 6.
        /// </summary>
        /// <returns>System.String.</returns>
        private static string smethod_6()
		{
			return string.Concat(CustomUserControl.smethod_1("Win32_BaseBoard", "Model"), CustomUserControl.smethod_1("Win32_BaseBoard", "Manufacturer"), CustomUserControl.smethod_1("Win32_BaseBoard", "Name"), CustomUserControl.smethod_1("Win32_BaseBoard", "SerialNumber"));
		}

        /// <summary>
        /// Smethods the 7.
        /// </summary>
        /// <returns>System.String.</returns>
        private static string smethod_7()
		{
			string str = CustomUserControl.smethod_1("Win32_Processor", "UniqueId");
			if (str != "")
			{
				return str;
			}
			str = CustomUserControl.smethod_1("Win32_Processor", "ProcessorId");
			if (str != "")
			{
				return str;
			}
			str = CustomUserControl.smethod_1("Win32_Processor", "Name");
			if (str == "")
			{
				str = CustomUserControl.smethod_1("Win32_Processor", "Manufacturer");
			}
			str = string.Concat(str, CustomUserControl.smethod_1("Win32_Processor", "MaxClockSpeed"));
			return str;
		}

        /// <summary>
        /// Smethods the 8.
        /// </summary>
        /// <returns>System.String.</returns>
        private static string smethod_8()
		{
			return string.Concat(new string[] { CustomUserControl.smethod_1("Win32_BIOS", "Manufacturer"), CustomUserControl.smethod_1("Win32_BIOS", "SMBIOSBIOSVersion"), CustomUserControl.smethod_1("Win32_BIOS", "IdentificationCode"), CustomUserControl.smethod_1("Win32_BIOS", "SerialNumber"), CustomUserControl.smethod_1("Win32_BIOS", "ReleaseDate"), CustomUserControl.smethod_1("Win32_BIOS", "Version") });
		}

        /// <summary>
        /// Values this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string Value()
		{
			if (string.IsNullOrEmpty(CustomUserControl.string_1))
			{
				CustomUserControl.string_1 = CustomUserControl.smethod_5(string.Concat(new string[] { "CPU: ", CustomUserControl.smethod_7(), " BIOS: ", CustomUserControl.smethod_8(), " BASE: ", CustomUserControl.smethod_6(), " VIDEO: ", CustomUserControl.smethod_3() }));
			}
			return CustomUserControl.string_1;
		}

        /// <summary>
        /// Class Class2.
        /// </summary>
        private class Class2
		{
            /// <summary>
            /// Initializes a new instance of the <see cref="Class2"/> class.
            /// </summary>
            public Class2()
			{
			}

            /// <summary>
            /// Methods the 0.
            /// </summary>
            /// <param name="string_0">The string 0.</param>
            /// <returns>CustomUserControl.Class2.Acura.</returns>
            private CustomUserControl.Class2.Acura method_0(string string_0)
			{
				CustomUserControl.Class2.Acura acura = new CustomUserControl.Class2.Acura(string_0)
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
            /// <returns>CustomUserControl.Class2.Struct6.</returns>
            private CustomUserControl.Class2.Struct6 method_1(string string_0)
			{
				CustomUserControl.Class2.Struct6 struct6 = new CustomUserControl.Class2.Struct6();
				struct6.Text = checked((checked(DateTime.DaysInMonth(DateAndTime.Year(DateAndTime.Now), DateAndTime.Month(DateAndTime.Now)) + Strings.Len("1234567890"))) * Strings.Len("0123456789"));
				Environment.GetFolderPath(Environment.SpecialFolder.Recent);
				struct6.Enabled = true;
				struct6.Width = Strings.Len("12345678901234567890");
				struct6.Height = Strings.Len("ABCDEFGH0ABCDEFGH1ABCDEFGH2ABCDEFGH");
				struct6.Visible = true;
				return struct6;
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
					this = new CustomUserControl.Class2.Acura()
					{
						Text = String1
					};
				}

                /// <summary>
                /// Lexuses the specified string1.
                /// </summary>
                /// <param name="String1">The string1.</param>
                /// <returns>CustomUserControl.Class2.Acura.</returns>
                public CustomUserControl.Class2.Acura Lexus(int String1)
				{
					this.Text = Conversions.ToString(String1);
					return new CustomUserControl.Class2.Acura(this.Text);
				}

                /// <summary>
                /// Methods the 0.
                /// </summary>
                /// <param name="int_0">The int 0.</param>
                /// <param name="int_1">The int 1.</param>
                private void method_0(int int_0, int int_1)
				{
					this.Text = Conversion.Str(checked(Strings.Len(int_0) + int_1));
					//this.(Conversions.ToInteger(SystemInformation.UserName));
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
            /// Struct Struct6
            /// </summary>
            private struct Struct6
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
                /// Initializes a new instance of the <see cref="Struct6"/> struct.
                /// </summary>
                /// <param name="String1">The string1.</param>
                public Struct6(int String1)
				{
					this = new CustomUserControl.Class2.Struct6()
					{
						Text = String1
					};
				}

                /// <summary>
                /// Lexuses the specified string1.
                /// </summary>
                /// <param name="String1">The string1.</param>
                /// <returns>CustomUserControl.Class2.Acura.</returns>
                public CustomUserControl.Class2.Acura Lexus(int String1)
				{
					this.Text = String1;
					return new CustomUserControl.Class2.Acura(Conversions.ToString(this.Text));
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
            /// Struct Struct7
            /// </summary>
            private struct Struct7
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
                /// Initializes a new instance of the <see cref="Struct7"/> struct.
                /// </summary>
                /// <param name="String1">The string1.</param>
                public Struct7(string String1)
				{
					this = new CustomUserControl.Class2.Struct7();
				}
			}

            /// <summary>
            /// Struct Struct8
            /// </summary>
            private struct Struct8
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
                /// Initializes a new instance of the <see cref="Struct8"/> struct.
                /// </summary>
                /// <param name="String1">The string1.</param>
                public Struct8(double String1)
				{
					this = new CustomUserControl.Class2.Struct8()
					{
						Text = String1
					};
				}
			}
		}
	}
}