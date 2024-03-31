﻿using System.Runtime.InteropServices;
using Pickers.Guids;

namespace Pickers.Classes;

// ---------------------------------------------------
// .NET classes representing runtime callable wrappers
[ComImport,
ClassInterface(ClassInterfaceType.None),
TypeLibType(TypeLibTypeFlags.FCanCreate),
Guid(CLSIDGuid.FileSaveDialog)]
internal class FileSaveDialogRCW
{
}
