/* <file>
 * <copyright see="prj:///doc/copyright.rtf"/>
 * <license see="prj:///doc/license.rtf"/>
 * <owner name="¥i·RÀs" email="cute.ofdragon@gmail.com"/>
 * <version value="$version"/>
 * <comment>  
 * </comment>
 * </file>
 */
using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace System
{
	[Flags]
	public enum WindowMessages
	{
		NULL                   = 0x0000,
		CREATE                 = 0x0001,
		DESTROY                = 0x0002,
		MOVE                   = 0x0003,
		SIZE                   = 0x0005,
		ACTIVATE               = 0x0006,
		SETFOCUS               = 0x0007,
		KILLFOCUS              = 0x0008,
		ENABLE                 = 0x000A,
		SETREDRAW              = 0x000B,
		SETTEXT                = 0x000C,
		GETTEXT                = 0x000D,
		GETTEXTLENGTH          = 0x000E,
		PAINT                  = 0x000F,
		CLOSE                  = 0x0010,
		QUERYENDSESSION        = 0x0011,
		QUIT                   = 0x0012,
		QUERYOPEN              = 0x0013,
		ERASEBKGND             = 0x0014,
		SYSCOLORCHANGE         = 0x0015,
		ENDSESSION             = 0x0016,
		SHOWWINDOW             = 0x0018,
		WININICHANGE           = 0x001A,
		SETTINGCHANGE          = 0x001A,
		DEVMODECHANGE          = 0x001B,
		ACTIVATEAPP            = 0x001C,
		FONTCHANGE             = 0x001D,
		TIMECHANGE             = 0x001E,
		CANCELMODE             = 0x001F,
		SETCURSOR              = 0x0020,
		MOUSEACTIVATE          = 0x0021,
		CHILDACTIVATE          = 0x0022,
		QUEUESYNC              = 0x0023,
		GETMINMAXINFO          = 0x0024,
		PAINTICON              = 0x0026,
		ICONERASEBKGND         = 0x0027,
		NEXTDLGCTL             = 0x0028,
		SPOOLERSTATUS          = 0x002A,
		DRAWITEM               = 0x002B,
		MEASUREITEM            = 0x002C,
		DELETEITEM             = 0x002D,
		VKEYTOITEM             = 0x002E,
		CHARTOITEM             = 0x002F,
		SETFONT                = 0x0030,
		GETFONT                = 0x0031,
		SETHOTKEY              = 0x0032,
		GETHOTKEY              = 0x0033,
		QUERYDRAGICON          = 0x0037,
		COMPAREITEM            = 0x0039,
		GETOBJECT              = 0x003D,
		COMPACTING             = 0x0041,
		COMMNOTIFY             = 0x0044,
		WINDOWPOSCHANGING      = 0x0046,
		WINDOWPOSCHANGED       = 0x0047,
		POWER                  = 0x0048,
		COPYDATA               = 0x004A,
		CANCELJOURNAL          = 0x004B,
		NOTIFY                 = 0x004E,
		INPUTLANGCHANGEREQUEST = 0x0050,
		INPUTLANGCHANGE        = 0x0051,
		TCARD                  = 0x0052,
		HELP                   = 0x0053,
		USERCHANGED            = 0x0054,
		NOTIFYFORMAT           = 0x0055,
		CONTEXTMENU            = 0x007B,
		STYLECHANGING          = 0x007C,
		STYLECHANGED           = 0x007D,
		DISPLAYCHANGE          = 0x007E,
		GETICON                = 0x007F,
		SETICON                = 0x0080,
		NCCREATE               = 0x0081,
		NCDESTROY              = 0x0082,
		NCCALCSIZE             = 0x0083,
		NCHITTEST              = 0x0084,
		NCPAINT                = 0x0085,
		NCACTIVATE             = 0x0086,
		GETDLGCODE             = 0x0087,
		SYNCPAINT              = 0x0088,
		NCMOUSEMOVE            = 0x00A0,
		NCLBUTTONDOWN          = 0x00A1,
		NCLBUTTONUP            = 0x00A2,
		NCLBUTTONDBLCLK        = 0x00A3,
		NCRBUTTONDOWN          = 0x00A4,
		NCRBUTTONUP            = 0x00A5,
		NCRBUTTONDBLCLK        = 0x00A6,
		NCMBUTTONDOWN          = 0x00A7,
		NCMBUTTONUP            = 0x00A8,
		NCMBUTTONDBLCLK        = 0x00A9,
		KEYDOWN                = 0x0100,
		KEYUP                  = 0x0101,
		CHAR                   = 0x0102,
		DEADCHAR               = 0x0103,
		SYSKEYDOWN             = 0x0104,
		SYSKEYUP               = 0x0105,
		SYSCHAR                = 0x0106,
		SYSDEADCHAR            = 0x0107,
		KEYLAST                = 0x0108,
		IME_STARTCOMPOSITION   = 0x010D,
		IME_ENDCOMPOSITION     = 0x010E,
		IME_COMPOSITION        = 0x010F,
		IME_KEYLAST            = 0x010F,
		INITDIALOG             = 0x0110,
		COMMAND                = 0x0111,
		SYSCOMMAND             = 0x0112,
		TIMER                  = 0x0113,
		HSCROLL                = 0x0114,
		VSCROLL                = 0x0115,
		INITMENU               = 0x0116,
		INITMENUPOPUP          = 0x0117,
		MENUSELECT             = 0x011F,
		MENUCHAR               = 0x0120,
		ENTERIDLE              = 0x0121,
		MENURBUTTONUP          = 0x0122,
		MENUDRAG               = 0x0123,
		MENUGETOBJECT          = 0x0124,
		UNINITMENUPOPUP        = 0x0125,
		MENUCOMMAND            = 0x0126,
		CTLCOLORMSGBOX         = 0x0132,
		CTLCOLOREDIT           = 0x0133,
		CTLCOLORLISTBOX        = 0x0134,
		CTLCOLORBTN            = 0x0135,
		CTLCOLORDLG            = 0x0136,
		CTLCOLORSCROLLBAR      = 0x0137,
		CTLCOLORSTATIC         = 0x0138,
		MOUSEMOVE              = 0x0200,
		LBUTTONDOWN            = 0x0201,
		LBUTTONUP              = 0x0202,
		LBUTTONDBLCLK          = 0x0203,
		RBUTTONDOWN            = 0x0204,
		RBUTTONUP              = 0x0205,
		RBUTTONDBLCLK          = 0x0206,
		MBUTTONDOWN            = 0x0207,
		MBUTTONUP              = 0x0208,
		MBUTTONDBLCLK          = 0x0209,
		MOUSEWHEEL             = 0x020A,
		PARENTNOTIFY           = 0x0210,
		ENTERMENULOOP          = 0x0211,
		EXITMENULOOP           = 0x0212,
		NEXTMENU               = 0x0213,
		SIZING                 = 0x0214,
		CAPTURECHANGED         = 0x0215,
		MOVING                 = 0x0216,
		DEVICECHANGE           = 0x0219,
		MDICREATE              = 0x0220,
		MDIDESTROY             = 0x0221,
		MDIACTIVATE            = 0x0222,
		MDIRESTORE             = 0x0223,
		MDINEXT                = 0x0224,
		MDIMAXIMIZE            = 0x0225,
		MDITILE                = 0x0226,
		MDICASCADE             = 0x0227,
		MDIICONARRANGE         = 0x0228,
		MDIGETACTIVE           = 0x0229,
		MDISETMENU             = 0x0230,
		ENTERSIZEMOVE          = 0x0231,
		EXITSIZEMOVE           = 0x0232,
		DROPFILES              = 0x0233,
		MDIREFRESHMENU         = 0x0234,
		IME_SETCONTEXT         = 0x0281,
		IME_NOTIFY             = 0x0282,
		IME_CONTROL            = 0x0283,
		IME_COMPOSITIONFULL    = 0x0284,
		IME_SELECT             = 0x0285,
		IME_CHAR               = 0x0286,
		IME_REQUEST            = 0x0288,
		IME_KEYDOWN            = 0x0290,
		IME_KEYUP              = 0x0291,
		MOUSEHOVER             = 0x02A1,
		MOUSELEAVE             = 0x02A3,
		CUT                    = 0x0300,
		COPY                   = 0x0301,
		PASTE                  = 0x0302,
		CLEAR                  = 0x0303,
		UNDO                   = 0x0304,
		RENDERFORMAT           = 0x0305,
		RENDERALLFORMATS       = 0x0306,
		DESTROYCLIPBOARD       = 0x0307,
		DRAWCLIPBOARD          = 0x0308,
		PAINTCLIPBOARD         = 0x0309,
		VSCROLLCLIPBOARD       = 0x030A,
		SIZECLIPBOARD          = 0x030B,
		ASKCBFORMATNAME        = 0x030C,
		CHANGECBCHAIN          = 0x030D,
		HSCROLLCLIPBOARD       = 0x030E,
		QUERYNEWPALETTE        = 0x030F,
		PALETTEISCHANGING      = 0x0310,
		PALETTECHANGED         = 0x0311,
		HOTKEY                 = 0x0312,
		PRINT                  = 0x0317,
		PRINTCLIENT            = 0x0318,
		HANDHELDFIRST          = 0x0358,
		HANDHELDLAST           = 0x035F,
		AFXFIRST               = 0x0360,
		AFXLAST                = 0x037F,
		PENWINFIRST            = 0x0380,
		PENWINLAST             = 0x038F,
		APP                    = 0x8000,
		USER                   = 0x0400
	}

	/// <summary>
	/// PeekMessage() Options
	/// </summary>
	public enum PeekMessages : uint
	{
		NOREMOVE     = 0x0000,
		REMOVE       = 0x0001,
		NOYIELD      = 0x0002
	}

	/// <summary>
	/// SetWindowsHook() codes
	/// </summary>
	[Flags]
	public enum WindowsHookCodes
	{
		MIN              = -1,
		MSGFILTER        = -1,
		JOURNALRECORD    = 0,
		JOURNALPLAYBACK  = 1,
		KEYBOARD         = 2,
		GETMESSAGE       = 3,
		CALLWNDPROC      = 4,
		CBT              = 5,
		SYSMSGFILTER     = 6,
		MOUSE            = 7,
		HARDWARE         = 8,
		DEBUG            = 9,
		SHELL            = 10,
		FOREGROUNDIDLE   = 11,
		CALLWNDPROCRET   = 12,
		KEYBOARD_LL      = 13,
		MOUSE_LL         = 14,
		MAX              = 14,
		//MAX              = 12,
		//MAX              = 11,
		MINHOOK          = MIN,
		MAXHOOK          = MAX
	}

	/* Ternary raster operations */
	[Flags]
	public enum RasterOp : uint
	{
		SRCCOPY             = 0x00CC0020, /* dest = source                   */
		SRCPAINT            = 0x00EE0086, /* dest = source OR dest           */
		SRCAND              = 0x008800C6, /* dest = source AND dest          */
		SRCINVERT           = 0x00660046, /* dest = source XOR dest          */
		SRCERASE            = 0x00440328, /* dest = source AND (NOT dest )   */
		NOTSRCCOPY          = 0x00330008, /* dest = (NOT source)             */
		NOTSRCERASE         = 0x001100A6, /* dest = (NOT src) AND (NOT dest) */
		MERGECOPY           = 0x00C000CA, /* dest = (source AND pattern)     */
		MERGEPAINT          = 0x00BB0226, /* dest = (NOT source) OR dest     */
		PATCOPY             = 0x00F00021, /* dest = pattern                  */
		PATPAINT            = 0x00FB0A09, /* dest = DPSnoo                   */
		PATINVERT           = 0x005A0049, /* dest = pattern XOR dest         */
		DSTINVERT           = 0x00550009, /* dest = (NOT dest)               */
		BLACKNESS           = 0x00000042, /* dest = BLACK                    */
		WHITENESS           = 0x00FF0062, /* dest = WHITE                    */

		NOMIRRORBITMAP      = 0x80000000, /* Do not Mirror the bitmap in this call */
		CAPTUREBLT          = 0x40000000 /* Include layered windows */
	}

	[Flags]
	public enum Palette 
	{
		DIB_RGB_COLORS      = 0, /* color table in RGBs */
		DIB_PAL_COLORS      = 1 /* color table in palette indices */
	}


	[Flags]
	public enum VirtualKeys
	{
		Back		= 0x08,
		Tab			= 0x09,
		Clear		= 0x0C,
		Return		= 0x0D,
			
		ShiftLeft	= 0xA0,
		ControlLeft	= 0xA2,
		ShiftRight	= 0xA1,
		ControlRight= 0xA3,
		AltLeft		= 0xA4,
		AltRight	= 0xA5,

		Menu		= 0x12,
		Pause		= 0x13,
		Capital		= 0x14,
		Escape		= 0x1B,
		Space		= 0x20,
		Prior		= 0x21,
		Next		= 0x22,
		End			= 0x23,
		Home		= 0x24,
		Left		= 0x25,
		Up			= 0x26,
		Right		= 0x27,
		Down		= 0x28,
		Select		= 0x29,
		Print		= 0x2A,
		Execute		= 0x2B,
		Snapshot	= 0x2C,
		Insert		= 0x2D,
		Delete		= 0x2E,
		Help		= 0x2F,

		D0			= 0x30,
		D1			= 0x31,
		D2			= 0x32,
		D3			= 0x33,
		D4			= 0x34,
		D5			= 0x35,
		D6			= 0x36,
		D7			= 0x37,
		D8			= 0x38,
		D9			= 0x39,

		A			= 0x41,
		B			= 0x42,
		C			= 0x43,
		D			= 0x44,
		E			= 0x45,
		F			= 0x46,
		G			= 0x47,
		H			= 0x48,
		I			= 0x49,
		J			= 0x4A,
		K			= 0x4B,
		L			= 0x4C,
		M			= 0x4D,
		N			= 0x4E,
		O			= 0x4F,
		P			= 0x50,
		Q			= 0x51,
		R			= 0x52,
		S			= 0x53,
		T			= 0x54,
		U			= 0x55,
		V			= 0x56,
		W			= 0x57,
		X			= 0x58,
		Y			= 0x59,
		Z			= 0x5A,

		LWindows	= 0x5B,
		RWindows	= 0x5C,
		Apps		= 0x5D,
		NumPad0		= 0x60,
		NumPad1		= 0x61,
		NumPad2		= 0x62,
		NumPad3		= 0x63,
		NumPad4		= 0x64,
		NumPad5		= 0x65,
		NumPad6		= 0x66,
		NumPad7		= 0x67,
		NumPad8		= 0x68,
		NumPad9		= 0x69,
			
		Multiply	= 0x6A,
		Add			= 0x6B,
		Separator	= 0x6C,
		Subtract	= 0x6D,
		Decimal		= 0x6E,
		Divide		= 0x6F,
		F1			= 0x70,
		F2			= 0x71,
		F3			= 0x72,
		F4			= 0x73,
		F5			= 0x74,
		F6			= 0x75,
		F7			= 0x76,
		F8			= 0x77,
		F9			= 0x78,
		F10			= 0x79,
		F11			= 0x7A,
		F12			= 0x7B,
		F13			= 0x7C,
		F14			= 0x7D,
		F15			= 0x7E,
		F16			= 0x7F,
		F17			= 0x80,
		F18			= 0x81,
		F19			= 0x82,
		F20			= 0x83,
		F21			= 0x84,
		F22			= 0x85,
		F23			= 0x86,
		F24			= 0x87,

		NumLock		= 0x90,
		Scroll		= 0x91,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct IconInfo 
	{
		public bool fIcon;
		public int xHotspot;
		public int yHotspot;
		public IntPtr hbmMask;
		public IntPtr hbmColor;
	}

	/// <summary>
	/// structures for defining DIBs 
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct BITMAPCOREHEADER 
	{
		public int    bcSize;                 /* used to get to color table */
		public int    bcWidth;
		public int    bcHeight;
		public int    bcPlanes;
		public int    bcBitCount;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RGBTRIPLE 
	{
		public byte    rgbtBlue;
		public byte    rgbtGreen;
		public byte    rgbtRed;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct BITMAPCOREINFO 
	{
		public BITMAPCOREHEADER    bmciHeader;
		public RGBTRIPLE[]         bmciColors;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RGBQUAD 
	{
		public byte    rgbBlue;
		public byte    rgbGreen;
		public byte    rgbRed;
		public byte    rgbReserved;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public class BITMAPINFO 
	{
		public BITMAPINFOHEADER    bmiHeader;
		public RGBQUAD[]           bmiColors;
		public BITMAPINFO()
		{
			bmiColors = new RGBQUAD[1];
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct BITMAPFILEHEADER 
	{
		public int   bfType;
		public int   bfSize;
		public int   bfReserved1;
		public int   bfReserved2;
		public int   bfOffBits;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct BITMAPINFOHEADER
	{
		public int      biSize;
		public int      biWidth;
		public int      biHeight;
		public short      biPlanes;
		public short      biBitCount;
		public int      biCompression;
		public int      biSizeImage;
		public int      biXPelsPerMeter;
		public int      biYPelsPerMeter;
		public int      biClrUsed;
		public int      biClrImportant;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MSG 
	{
		public IntPtr hwnd;
		public int message;
		public IntPtr wParam;
		public IntPtr lParam;
		public int time;
		public int pt_x;
		public int pt_y;
	}

	/// <summary>
	/// From KBDLLHOOKSTRUCT
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct KeyboardLLHook
	{
		public int    vkCode;
		public int    scanCode;
		public int    flags;
		public int    time;
		IntPtr        dwExtraInfo;
	}

	/// <summary>
	/// From MSLLHOOKSTRUCT
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct MouseLLHook
	{
		public Point pt;
		public long mouseData;
		public long flags;
		public long time;
		public IntPtr dwExtraInfo;
	}

	public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
	public delegate void TimerProc(IntPtr hWnd, uint nMsg, int nIDEvent, int dwTime);

	public class NativeMethod
	{
		[DllImport("user32.dll", EntryPoint="GetDesktopWindow")]
		public static extern IntPtr GetDesktopWindow();

		[DllImport("user32.dll",EntryPoint="GetDC")]
		public static extern IntPtr GetDC(IntPtr ptr);

		[DllImport("user32.dll",EntryPoint="GetSystemMetrics")]
		public static extern int GetSystemMetrics(int nIndex);

		[DllImport("user32.dll",EntryPoint="GetWindowDC")]
		public static extern IntPtr GetWindowDC(Int32 ptr);

		[DllImport("user32.dll",EntryPoint="ReleaseDC")]
		public static extern IntPtr ReleaseDC(IntPtr hWnd,IntPtr hDc);

		[DllImport("user32.dll", EntryPoint="GetCursor")]
		public static extern IntPtr GetCursor();

		[DllImport("user32.dll", EntryPoint="GetCursorPos")]
		public static extern int GetCursorPos(out Point lpPoint);

		[DllImport("user32.dll", EntryPoint="DrawIcon")]
		public static extern int DrawIcon(IntPtr hDC, int x, int y, IntPtr hIcon);

		[DllImport("user32.dll", EntryPoint="GetIconInfo")]
		public static extern int GetIconInfo(IntPtr hIcon, out IconInfo piconinfo);

		[DllImport("gdi32.dll", EntryPoint="DeleteDC")]
		public static extern IntPtr DeleteDC(IntPtr hDc);

		[DllImport("gdi32.dll", EntryPoint="DeleteObject")]
		public static extern IntPtr DeleteObject(IntPtr hDc);

		[DllImport("gdi32.dll", EntryPoint="BitBlt")]
		public static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, RasterOp dwRop);

		[DllImport("gdi32.dll", EntryPoint="CreateCompatibleBitmap")]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

		[DllImport("gdi32.dll", EntryPoint="CreateCompatibleDC")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport("gdi32.dll", EntryPoint="GetDIBits")]
		public static extern int GetDIBits(
			[In] IntPtr hdc,           // handle to DC
			[In] IntPtr hbmp,      // handle to bitmap
			[In] int uStartScan,   // first scan line to set
			[In] int cScanLines,   // number of scan lines to copy
			[Out, MarshalAs(UnmanagedType.LPArray)] byte[] lpvBits,    // array for bitmap bits
			[In, Out] ref BITMAPINFO lpbi, // bitmap data buffer
			[In] Palette uUsage        // RGB or palette index
			);

		[DllImport("gdi32.dll", EntryPoint="SelectObject")]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

		[DllImport("user32.dll",CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
		public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
		
		[DllImport("user32.dll",CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
		public static extern bool UnhookWindowsHookEx(int idHook);

		[DllImport("user32.dll",CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
		public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool WaitMessage();

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool TranslateMessage(ref MSG msg);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool DispatchMessage(ref MSG msg);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool PostMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern uint SendMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern uint SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool GetMessage(ref MSG msg, IntPtr hWnd, uint wFilterMin, uint wFilterMax);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool PeekMessage(ref MSG msg, IntPtr hWnd, uint wFilterMin, uint wFilterMax, PeekMessages wFlag);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern int SetTimer(IntPtr hwnd, int nIDEvent, int uElapse, TimerProc CB); 

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern int KillTimer(IntPtr hwnd, int nIDEvent);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern int RegisterHotKey(IntPtr hWnd, int id, Keys fsModifiers, Keys vk);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern int UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("AdHocDesktop.Native.dll")]
        public static extern IntPtr GetCurrentCursorHandle(); 

	}
}
