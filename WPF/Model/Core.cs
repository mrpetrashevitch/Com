using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace WPF.Model
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void CallBackProgress(double progress);

    public class Core : WPF.ViewModel.Base.ViewModelBase
    {
        #region Api
        const string _PathDll = "core.dll";
        [DllImport(_PathDll, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Interface)]
        extern static ICore create_core();
        #endregion

        ICore ICore;
        public Core()
        {
            ICore = create_core();
        }

        public int Sum(int x, int y, CallBackProgress progress)
        {
            var ptr = Marshal.GetFunctionPointerForDelegate(progress);
            return ICore.sum(x,y, ptr); // Вызов конструктора с 3 параметрами. Но clr всегда вызывает перегрузку метода, который определен первым в интерфейсе.
        }
    }
}
