using System.Runtime.InteropServices;

namespace ModernUI.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {
        public int left, top, right, bottom;
    }
}