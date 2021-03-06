#region license

/*
DirectShowLib - Provide access to DirectShow interfaces via .NET
Copyright (C) 2005
http://sourceforge.net/projects/directshownet/

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

#endregion

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Microsoft.DirectX.DirectShow
{

    #region Declarations

#if ALLOW_UNTESTED_INTERFACES

    /// <summary>
    /// From AM_MPEG_AUDIO_DUAL_* defines
    /// </summary>
    public enum MPEGAudioDual
    {
        Merge,
        Left,
        Right
    }

    /// <summary>
    /// From AM_WST_LEVEL
    /// </summary>
    public enum WSTLevel 
    {
        Level1_5 = 0
    }

    /// <summary>
    /// From AM_WST_SERVICE
    /// </summary>
    public enum WSTService
    {
        None = 0,
        Text,
        IDS,
        Invalid
    }

    /// <summary>
    /// From AM_WST_STATE
    /// </summary>
    public enum WSTState
    {
        Off = 0,
        On
    }

    /// <summary>
    /// From AM_WST_STYLE
    /// </summary>
    public enum WSTStyle
    {
        None = 0,
        Invers
    }

    /// <summary>
    /// From AM_WST_DRAWBGMODE
    /// </summary>
    public enum WSTDrawBGMode
    {
        Opaque,
        Transparent
    }

    /// <summary>
    /// From AM_WST_PAGE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WSTPage
    {
        public int	dwPageNr ;
        public int	dwSubPageNr ;
        public IntPtr pucPageData; // BYTE	*
    }

    /// <summary>
    /// From MPEG1WAVEFORMAT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MPEG1WaveFormat
    {
        public WaveFormatEx    wfx;
        public short            fwHeadLayer;
        public int           dwHeadBitrate;
        public short            fwHeadMode;
        public short            fwHeadModeExt;
        public short            wHeadEmphasis;
        public short            fwHeadFlags;
        public int           dwPTSLow;
        public int           dwPTSHigh;
    }

    /// <summary>
    /// From AMVABUFFERINFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AMVABufferInfo
    {
        public int                   dwTypeIndex;
        public int                   dwBufferIndex;
        public int                   dwDataOffset;
        public int                   dwDataSize;
    }

    /// <summary>
    /// From AMVAUncompDataInfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AMVAUncompDataInfo
    {
        public int                   dwUncompWidth;
        public int                   dwUncompHeight;
        public DDPixelFormat           ddUncompPixelFormat;
    }

    /// <summary>
    /// From AMVAUncompBufferInfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AMVAUncompBufferInfo
    {
        public int                   dwMinNumSurfaces;
        public int                   dwMaxNumSurfaces;
        public DDPixelFormat           ddUncompPixelFormat;
    }

    /// <summary>
    /// From AMVAInternalMemInfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AMVAInternalMemInfo
    {
        public int                   dwScratchMemAlloc;
    }

    /// <summary>
    /// From DDSCAPS2
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct DDSCaps2
    {
        [FieldOffset(0)] public int       dwCaps;
        [FieldOffset(4)] public int       dwCaps2;
        [FieldOffset(8)] public int       dwCaps3;
        [FieldOffset(12)] public int       dwCaps4; // Is this supposed to be a array?
        [FieldOffset(12)] public int       dwVolumeDepth;
    }

    /// <summary>
    /// From AMVACompBufferInfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AMVACompBufferInfo
    {
        public int                   dwNumCompBuffers;
        public int                   dwWidthToCreate;
        public int                   dwHeightToCreate;
        public int                   dwBytesToAllocate;
        public DDSCaps2                ddCompCaps;
        public DDPixelFormat           ddPixelFormat;
    }

    /// <summary>
    /// From AMVABeginFrameInfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AMVABeginFrameInfo
    {
        public int                dwDestSurfaceIndex;
        public IntPtr               pInputData;  // LPVOID
        public int                dwSizeInputData;
        public IntPtr               pOutputData;  // LPVOID
        public int                dwSizeOutputData;
    }

    /// <summary>
    /// From AMVAEndFrameInfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AMVAEndFrameInfo
    {
        public int                   dwSizeMiscData;
        public IntPtr                  pMiscData; // LPVOID
    }

#endif

    #endregion

    #region Interfaces

#if ALLOW_UNTESTED_INTERFACES

    [Guid("c47a3420-005c-11d2-9038-00a0c9697298"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMParse
    {
        [PreserveSig]
        int GetParseTime(out long prtCurrent);

        [PreserveSig]
        int SetParseTime(long rtCurrent);

        [PreserveSig]
        int Flush();
    }

    [Guid("a8809222-07bb-48ea-951c-33158100625b"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IGetCapabilitiesKey
    {
        [PreserveSig]
        int GetCapabilitiesKey( [Out] out IntPtr pHKey ); // HKEY
    }

    [Guid("C056DE21-75C2-11d3-A184-00105AEF9F33"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMWstDecoder
    {
        [PreserveSig]
        int GetDecoderLevel(out WSTLevel lpLevel);

        [PreserveSig]
        int GetCurrentService(out WSTService lpService);

        [PreserveSig]
        int GetServiceState(out WSTState lpState);

        [PreserveSig]
        int SetServiceState(WSTState State);

        [PreserveSig]
        int GetOutputFormat(out BitmapInfoHeader lpbmih);

        [PreserveSig]
        int SetOutputFormat(BitmapInfo lpbmi);

        [PreserveSig]
        int GetBackgroundColor(out int pdwPhysColor);

        [PreserveSig]
        int SetBackgroundColor(int dwPhysColor);

        [PreserveSig]
        int GetRedrawAlways([MarshalAs(UnmanagedType.Bool)] out bool lpbOption);

        [PreserveSig]
        int SetRedrawAlways([MarshalAs(UnmanagedType.Bool)] bool bOption);

        [PreserveSig]
        int GetDrawBackgroundMode(out WSTDrawBGMode lpMode);

        [PreserveSig]
        int SetDrawBackgroundMode(WSTDrawBGMode Mode);

        [PreserveSig]
        int SetAnswerMode([MarshalAs(UnmanagedType.Bool)] bool bAnswer);

        [PreserveSig]
        int GetAnswerMode([MarshalAs(UnmanagedType.Bool)] out bool pbAnswer);

        [PreserveSig]
        int SetHoldPage([MarshalAs(UnmanagedType.Bool)] bool bHoldPage);

        [PreserveSig]
        int GetHoldPage([MarshalAs(UnmanagedType.Bool)] out bool pbHoldPage);

        [PreserveSig]
        int GetCurrentPage(out WSTPage pWstPage);

        [PreserveSig]
        int SetCurrentPage(WSTPage WstPage);
    }

    [Guid("b45dd570-3c77-11d1-abe1-00a0c905f375"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMpegAudioDecoder
    {
        [PreserveSig]
        int get_FrequencyDivider(
            out int pDivider
            );

        [PreserveSig]
        int put_FrequencyDivider(
            int Divider
            );

        [PreserveSig]
        int get_DecoderAccuracy(
            out int pAccuracy
            );

        [PreserveSig]
        int put_DecoderAccuracy(
            int Accuracy
            );

        [PreserveSig]
        int get_Stereo(
            out int pStereo
            );

        [PreserveSig]
        int put_Stereo(
            int Stereo
            );

        [PreserveSig]
        int get_DecoderWordSize(
            out int pWordSize
            );

        [PreserveSig]
        int put_DecoderWordSize(
            int WordSize
            );

        [PreserveSig]
        int get_IntegerDecode(
            out int pIntDecode
            );

        [PreserveSig]
        int put_IntegerDecode(
            int IntDecode
            );

        [PreserveSig]
        int get_DualMode(
            out MPEGAudioDual pIntDecode
            );

        [PreserveSig]
        int put_DualMode(
            MPEGAudioDual IntDecode
            );

        [PreserveSig]
        int get_AudioFormat(
            out MPEG1WaveFormat lpFmt
            );
    }

    [Guid("256A6A21-FBAD-11d1-82BF-00A0C9696C8F"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMVideoAcceleratorNotify
    {
        [PreserveSig]
        int GetUncompSurfacesInfo([In, MarshalAs(UnmanagedType.LPStruct)] Guid pGuid,
            [Out] out AMVAUncompBufferInfo pUncompBufferInfo);

        [PreserveSig]
        int SetUncompSurfacesInfo([In] int dwActualUncompSurfacesAllocated);

        [PreserveSig]
        int GetCreateVideoAcceleratorData([In, MarshalAs(UnmanagedType.LPStruct)] Guid pGuid,
            [Out] out int pdwSizeMiscData,
            [Out] IntPtr ppMiscData); // LPVOID
    }

    [Guid("256A6A21-FBAD-11d1-82BF-00A0C9696C8F"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMVideoAccelerator
    {
        [PreserveSig]
        int GetVideoAcceleratorGUIDs([Out] out int pdwNumGuidsSupported,
            [In, Out] Guid [] pGuidsSupported);

        [PreserveSig]
        int GetUncompFormatsSupported( [In, MarshalAs(UnmanagedType.LPStruct)] Guid pGuid,
            [Out] out int pdwNumFormatsSupported,
            [Out] out DDPixelFormat pFormatsSupported);

        [PreserveSig]
        int GetInternalMemInfo([In, MarshalAs(UnmanagedType.LPStruct)] Guid pGuid,
            [In] AMVAUncompDataInfo pamvaUncompDataInfo,
            [Out] out AMVAInternalMemInfo pamvaInternalMemInfo);

        [PreserveSig]
        int GetCompBufferInfo([In, MarshalAs(UnmanagedType.LPStruct)] Guid pGuid,
            [In] AMVAUncompDataInfo pamvaUncompDataInfo,
            [In, Out] int pdwNumTypesCompBuffers,
            [Out] out AMVACompBufferInfo pamvaCompBufferInfo);

        [PreserveSig]
        int GetInternalCompBufferInfo([Out] out int pdwNumTypesCompBuffers,
            [Out] out AMVACompBufferInfo pamvaCompBufferInfo);

        [PreserveSig]
        int BeginFrame([In] AMVABeginFrameInfo amvaBeginFrameInfo);

        [PreserveSig]
        int EndFrame([In] AMVAEndFrameInfo pEndFrameInfo);

        [PreserveSig]
        int GetBuffer(
            [In] int dwTypeIndex,
            [In] int dwBufferIndex,
            [In, MarshalAs(UnmanagedType.Bool)] bool bReadOnly,
            [Out] IntPtr ppBuffer, // LPVOID
            [Out] out int lpStride);

        [PreserveSig]
        int ReleaseBuffer([In] int dwTypeIndex,
            [In] int dwBufferIndex);

        [PreserveSig]
        int Execute(
            [In] int dwFunction,
            [In] IntPtr lpPrivateInputData, // LPVOID
            [In] int cbPrivateInputData,
            [In] IntPtr lpPrivateOutputDat, // LPVOID
            [In] int cbPrivateOutputData,
            [In] int dwNumBuffers,
            [In] AMVABufferInfo pamvaBufferInfo);

        [PreserveSig]
        int QueryRenderStatus([In] int dwTypeIndex,
            [In] int dwBufferIndex,
            [In] int dwFlags);

        [PreserveSig]
        int DisplayFrame([In] int dwFlipToIndex,
            [In] IMediaSample pMediaSample);
    }

    [Guid("56a868fd-0ad4-11ce-b0a3-0020af0ba770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMFilterGraphCallback
    {
        [PreserveSig]
        int UnableToRender(IPin pPin);
     }

    [Guid("45086030-F7E4-486a-B504-826BB5792A3B"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IConfigAsfWriter
    {
        [PreserveSig]
        int ConfigureFilterUsingProfileId([In] int dwProfileId);

        [PreserveSig]
        int GetCurrentProfileId([Out] out int pdwProfileId);

        [PreserveSig]
        int ConfigureFilterUsingProfileGuid([In] ref Guid guidProfile);

        [PreserveSig]
        int GetCurrentProfileGuid([Out] out Guid pProfileGuid);

        ///TODO: Modifier cette entr�e quand IWMProfile sera d�fini...
        [PreserveSig]
        int ConfigureFilterUsingProfile([In, MarshalAs(UnmanagedType.IUnknown)] object pProfile); //IWMProfile

        ///TODO: Modifier cette entr�e quand IWMProfile sera d�fini...
        [PreserveSig]
        int GetCurrentProfileGuid([Out, MarshalAs(UnmanagedType.IUnknown)] out object ppProfile); //IWMProfile

        [PreserveSig]
        int SetIndexMode([In, MarshalAs(UnmanagedType.Bool)] bool bIndexFile);

        [PreserveSig]
        int GetIndexMode([Out, MarshalAs(UnmanagedType.Bool)] out bool pbIndexFile);
    }

    [Guid("546F4260-D53E-11cf-B3F0-00AA003761C5"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMDirectSound
    {
        [PreserveSig]
        int GetDirectSoundInterface([MarshalAs(UnmanagedType.IUnknown)] out object lplpds); // IDirectSound

        [PreserveSig]
        int GetPrimaryBufferInterface([MarshalAs(UnmanagedType.IUnknown)] out object lplpdsb); // IDirectSoundBuffer

        [PreserveSig]
        int GetSecondaryBufferInterface([MarshalAs(UnmanagedType.IUnknown)] out object lplpdsb); // IDirectSoundBuffer

        [PreserveSig]
        int ReleaseDirectSoundInterface([MarshalAs(UnmanagedType.IUnknown)] object lpds); // IDirectSound

        [PreserveSig]
        int ReleasePrimaryBufferInterface([MarshalAs(UnmanagedType.IUnknown)] object lpdsb); // IDirectSoundBuffer

        [PreserveSig]
        int ReleaseSecondaryBufferInterface([MarshalAs(UnmanagedType.IUnknown)] object lpdsb); // IDirectSoundBuffer

        [PreserveSig]
        int SetFocusWindow(IntPtr hWnd, [In, MarshalAs(UnmanagedType.Bool)] bool bSet);

        [PreserveSig]
        int GetFocusWindow(out IntPtr hWnd, [Out, MarshalAs(UnmanagedType.Bool)] out bool bSet);
    }

    [Guid("AB6B4AFE-F6E4-11d0-900D-00C04FD9189D"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDirectDrawMediaSample
    {
        [PreserveSig]
        int GetSurfaceAndReleaseLock(
            [MarshalAs(UnmanagedType.IUnknown)] out object ppDirectDrawSurface, // IDirectDrawSurface
            out Rectangle pRect);

        [PreserveSig]
        int LockMediaSamplePointer();
    }

    [Guid("AB6B4AFC-F6E4-11d0-900D-00C04FD9189D"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDirectDrawMediaSampleAllocator
    {
        [PreserveSig]
        int GetDirectDraw(
            [MarshalAs(UnmanagedType.IUnknown)] out object ppDirectDraw); // IDirectDraw

    }

#endif
    #endregion
}
