using System.Runtime.InteropServices;

namespace Pickers.Structures;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
internal struct COMDLG_FILTERSPEC
{
    internal COMDLG_FILTERSPEC(string name, string spec)
    {
        pszName = name;
        pszSpec = spec;
    }

    [MarshalAs(UnmanagedType.LPWStr)]
    public string pszName;
    [MarshalAs(UnmanagedType.LPWStr)]
    public string pszSpec;
}
