// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="PlatformType.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.MiscControls.FastControls
{
    /// <summary>
    /// Class PlatformType.
    /// </summary>
    public static class PlatformType
    {
        /// <summary>
        /// The processor architecture intel
        /// </summary>
        const ushort PROCESSOR_ARCHITECTURE_INTEL = 0;
        /// <summary>
        /// The processor architecture i a64
        /// </summary>
        const ushort PROCESSOR_ARCHITECTURE_IA64 = 6;
        /// <summary>
        /// The processor architecture am D64
        /// </summary>
        const ushort PROCESSOR_ARCHITECTURE_AMD64 = 9;
        /// <summary>
        /// The processor architecture unknown
        /// </summary>
        const ushort PROCESSOR_ARCHITECTURE_UNKNOWN = 0xFFFF;

        /// <summary>
        /// Struct SYSTEM_INFO
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        struct SYSTEM_INFO
        {
            /// <summary>
            /// The w processor architecture
            /// </summary>
            public ushort wProcessorArchitecture;
            /// <summary>
            /// The w reserved
            /// </summary>
            public ushort wReserved;
            /// <summary>
            /// The dw page size
            /// </summary>
            public uint dwPageSize;
            /// <summary>
            /// The lp minimum application address
            /// </summary>
            public IntPtr lpMinimumApplicationAddress;
            /// <summary>
            /// The lp maximum application address
            /// </summary>
            public IntPtr lpMaximumApplicationAddress;
            /// <summary>
            /// The dw active processor mask
            /// </summary>
            public UIntPtr dwActiveProcessorMask;
            /// <summary>
            /// The dw number of processors
            /// </summary>
            public uint dwNumberOfProcessors;
            /// <summary>
            /// The dw processor type
            /// </summary>
            public uint dwProcessorType;
            /// <summary>
            /// The dw allocation granularity
            /// </summary>
            public uint dwAllocationGranularity;
            /// <summary>
            /// The w processor level
            /// </summary>
            public ushort wProcessorLevel;
            /// <summary>
            /// The w processor revision
            /// </summary>
            public ushort wProcessorRevision;
        };

        /// <summary>
        /// Gets the native system information.
        /// </summary>
        /// <param name="lpSystemInfo">The lp system information.</param>
        [DllImport("kernel32.dll")]
        static extern void GetNativeSystemInfo(ref SYSTEM_INFO lpSystemInfo);

        /// <summary>
        /// Gets the system information.
        /// </summary>
        /// <param name="lpSystemInfo">The lp system information.</param>
        [DllImport("kernel32.dll")]
        static extern void GetSystemInfo(ref SYSTEM_INFO lpSystemInfo);

        /// <summary>
        /// Gets the operation system platform.
        /// </summary>
        /// <returns>Platform.</returns>
        public static Platform GetOperationSystemPlatform()
        {
            var sysInfo = new SYSTEM_INFO();

            // WinXP and older - use GetNativeSystemInfo
            if (Environment.OSVersion.Version.Major > 5 ||
                (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1))
            {
                GetNativeSystemInfo(ref sysInfo);
            }
            // else use GetSystemInfo
            else
            {
                GetSystemInfo(ref sysInfo);
            }

            switch (sysInfo.wProcessorArchitecture)
            {
                case PROCESSOR_ARCHITECTURE_IA64:
                case PROCESSOR_ARCHITECTURE_AMD64:
                    return Platform.X64;

                case PROCESSOR_ARCHITECTURE_INTEL:
                    return Platform.X86;

                default:
                    return Platform.Unknown;
            }
        }
    }

    /// <summary>
    /// Enum Platform
    /// </summary>
    public enum Platform
    {
        /// <summary>
        /// The X86
        /// </summary>
        X86,
        /// <summary>
        /// The X64
        /// </summary>
        X64,
        /// <summary>
        /// The unknown
        /// </summary>
        Unknown
    }

}
