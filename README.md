# Pickers
WinUI 3 (WindowsAppSDK) FileOpenPicker doesn't work for app that runs under Administrator privileges.

[Trying to use a FileOpenPicker while running the app as Administrator will crash the app](https://github.com/microsoft/WindowsAppSDK/issues/2504)

In that thread mr. @castorix said:
>I found old links... but they cutted the code :-(
I will try to re-post, but you can find various implementations by typing for example in Google "IFileOpenDialog comimport github"

I found several good implementations:
1. [HedgeModManager](https://github.com/thesupersonic16/HedgeModManager/blob/0f2695f0e12f12ada9f8764827d9fc1370b0307f/HedgeModManager/UI/MainWindow.xaml.cs#L1465)
2. [ShellFileDialogs](https://github.com/daiplusplus/ShellFileDialogs)

This project is IFileOpenDialog interpretation of [HedgeModManager](https://github.com/thesupersonic16/HedgeModManager/blob/0f2695f0e12f12ada9f8764827d9fc1370b0307f/HedgeModManager/ShellProvider.cs) solution. I made File pick dialog and folder pick dialog.

## How to use
Add project to your solution and set dependencies.

### File pick dialog

```csharp
using Pickers;
...

// Set filters.
var filters = new List<string> { "*.mp3", "*.wav" };
// Window handle
var _handle = Process.GetCurrentProcess().MainWindowHandle;
// Create dialog.
var openPicker = new FileOpenPicker(_handle);
// Show dialog.
var file = openPicker.Show(filters);
// Result example: C:\Users\SomeUser\Documents\HelloWorld.mp3 or string.Empty.
```

### Folder pick dialog
```csharp
using Pickers;
...

// Window handle
var _handle = Process.GetCurrentProcess().MainWindowHandle;
// Create dialog.
var openPicker = new FolderPicker(_handle);
// Show dialog.
var path = openPicker.Show();
// Result example: C:\Users\SomeUser\Documents or string.Empty.
```

### Requirements
1. .NET 7 or higher.
2. Windows only.

 Tested in WinUI 3 app (WindowsAppSDK 1.4.240211001) on Windows 11 23H2.
