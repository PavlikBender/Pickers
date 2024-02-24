﻿using Pickers.Classes;
using Pickers.Enums;

namespace Pickers;

/// <summary>
/// Class responsible for file pick dialog.
/// </summary>
public class FileOpenPicker
{
    /// <summary>
    /// Window handle where dialog should appear.
    /// </summary>
    private readonly IntPtr _windowHandle;

    public FileOpenPicker(IntPtr windowHandle)
    {
        _windowHandle = windowHandle;
    }

    /// <summary>
    /// Shows file pick dialog.
    /// </summary>
    /// <param name="typeFilters">List of extensions applied on dialog.</param>
    /// <returns>Path to selected file or empty string.</returns>
    public string Show(List<string>? typeFilters = null)
    {
        return Helper.Show(_windowHandle, FOS.FOS_FORCEFILESYSTEM, typeFilters);
    }
}
