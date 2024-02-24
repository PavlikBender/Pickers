﻿using Pickers.Enums;
using Pickers.Interfaces;
using Pickers.Structures;
using System.Runtime.InteropServices;

namespace Pickers.Classes;

internal static class Helper
{
    /// <summary>
    /// Shows FileOpenDialog.
    /// </summary>
    /// <param name="windowHandle">Window handle where dialog should appear.</param>
    /// <param name="fos">File open dialog options.</param>
    /// <param name="typeFilters">List of extensions applied on dialog.</param>
    /// <returns>Path to selected file, folder or empty string.</returns>
    internal static string Show(nint windowHandle, FOS fos, List<string>? typeFilters = null)
    {
        var dialog = new FileOpenDialog();
        try
        {
            dialog.SetOptions(fos);
            if (typeFilters != null)
            {
                var filterSpecs = typeFilters.Select(f => new COMDLG_FILTERSPEC(f, f)).ToArray();
                dialog.SetFileTypes((uint)filterSpecs.Length, filterSpecs);
            }

            if (dialog.Show(windowHandle) != 0)
                return string.Empty;

            dialog.GetResult(out var item);
            item.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out var path);
            return path;
        }
        finally
        {
#pragma warning disable CA1416 
            Marshal.ReleaseComObject(dialog);
#pragma warning restore CA1416
        }
    }
}
