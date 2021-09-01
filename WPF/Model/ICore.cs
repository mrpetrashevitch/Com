using System;
using System.Runtime.InteropServices;

namespace WPF.Model
{
    [ComImport]
    [Guid("10000000-0000-0000-C000-000000000046")]// guid core
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICore
    {
        [PreserveSig]
        int sum(int x, int y, IntPtr progress_func);
    }
}
