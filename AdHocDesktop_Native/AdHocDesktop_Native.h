// AdHocDesktop_Native.h

#pragma once

#include <windows.h>

extern "C" { 
__declspec( dllexport ) HCURSOR  __stdcall GetCurrentCursorHandle(); 
};

