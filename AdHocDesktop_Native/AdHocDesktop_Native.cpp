// This is the main DLL file.

#include "stdafx.h"

#include "AdHocDesktop_Native.h"


		HCURSOR __stdcall GetCurrentCursorHandle()
		{
		/**********************************************************
			http://support.microsoft.com/kb/q230495/
			GetCurrentCursorHandle

			Purpose:
				Retrieves a handle to the current cursor regardless of
				whether or not it's owned by the current thread. This is
				useful, for example, when you need to draw the image
				of the current cursor into a screen capture using
				DrawIcon().

			Input:
				<none>

			Return:
				The return value is the handle to the current cursor.
				If there is no cursor, the return value is NULL.

			Notes:
				Windows NT: This function cannot be used to capture the
				cursor on another desktop.

			**********************************************************/

			POINT pt;
			HWND hWnd;
			DWORD dwThreadID, dwCurrentThreadID;
			HCURSOR hCursor = NULL;

			// Find out which window owns the cursor
			GetCursorPos(&pt);
			hWnd = WindowFromPoint(pt);

			// Get the thread ID for the cursor owner.
			dwThreadID = GetWindowThreadProcessId(hWnd, NULL);

			// Get the thread ID for the current thread
			dwCurrentThreadID = GetCurrentThreadId();

			// If the cursor owner is not us then we must attach to
			// the other thread in so that we can use GetCursor() to
			// return the correct hCursor
			if (dwCurrentThreadID != dwThreadID) {

				// Attach to the thread that owns the cursor
				if (AttachThreadInput(dwCurrentThreadID, dwThreadID, TRUE)) {

					// Get the handle to the cursor
					hCursor = GetCursor();

					// Detach from the thread that owns the cursor
					AttachThreadInput(dwCurrentThreadID, dwThreadID, FALSE);
				}
			} else
				hCursor = GetCursor();

			return hCursor;
		}