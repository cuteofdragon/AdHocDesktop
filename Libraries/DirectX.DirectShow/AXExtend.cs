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
using System.Text;

namespace Microsoft.DirectX.DirectShow
{

    #region Declarations

#if ALLOW_UNTESTED_INTERFACES
    /// <summary>
    /// unnamed enum
    /// </summary>
    public enum Merit
    {
        Preferred = 0x800000,
        Normal = 0x600000,
        Unlikely = 0x400000,
        DoNotUse = 0x200000,
        SWCompressor = 0x100000,
        HWCompressor = 0x100050
    }

    /// <summary>
    /// From QualityMessageType
    /// </summary>
    public enum QualityMessageType
    {
        Famine,
        Flood
    }

    /// <summary>
    /// From VideoCopyProtectionType
    /// </summary>
    public enum VideoCopyProtectionType
    {
        MacrovisionBasic,
        MacrovisionCBI
    }

    /// <summary>
    /// CameraControlProperty
    /// </summary>
    public enum CameraControlProperty
    {
        Pan,
        Tilt,
        Roll,
        Zoom,
        Exposure,
        Iris,
        Focus
    }

    /// <summary>
    /// CameraControlFlags
    /// </summary>
    public enum CameraControlFlags
    {
        Auto = 0x0001,
        Manual = 0x0002
    }

    /// <summary>
    /// From _AMSTREAMSELECTINFOFLAGS
    /// </summary>
    [Flags]
    public enum AMStreamSelectInfoFlags
    {
        Enabled = 0x01,
        Exclusive = 0x02
    }

    /// <summary>
    /// From _AMSTREAMSELECTENABLEFLAGS
    /// </summary>
    [Flags]
    public enum AMStreamSelectEnableFlags
    {
        Enable = 0x01,
        EnableAll = 0x02
    }

    /// <summary>
    /// _AMRESCTL_RESERVEFLAGS
    /// </summary>
    [Flags]
    public enum AMResCtlReserveFlags
    {
        Reserve = 0x00,
        UnReserve = 0x01
    }

    /// <summary>
    /// From _AM_FILTER_MISC_FLAGS
    /// </summary>
    [Flags]
    public enum AMFilterMiscFlags
    {
        IsRenderer = 0x00000001,
        IsSource = 0x00000002
    }

    /// <summary>
    /// From DECIMATION_USAGE
    /// </summary>
    public enum DecimationUsage
    {
        Legacy,
        UseDecoderOnly,
        UseVideoPortOnly,
        UseOverlayOnly,
        Default
    }

    /// <summary>
    /// From _AM_PUSHSOURCE_FLAGS
    /// </summary>
    [Flags]
    public enum AMPushSourceFlags
    {
        InternalRM = 0x00000001,
        NotLive = 0x00000002,
        PivateClock = 0x00000004,
        UseStreamClock = 0x00010000,
        UseClockChain = 0x00020000,
    }

    /// <summary>
    /// From _DVDECODERRESOLUTION
    /// </summary>
    public enum DVDecoderResolution
    {
        r720x480 = 1000,
        r360x240 = 1001,
        r180x120 = 1002,
        r88x60 = 1003
    }

    /// <summary>
    /// From _DVResolution
    /// </summary>
    public enum DVResolution
    {
        Full = 1000,
        Half = 1001,
        Quarter = 1002,
        Dc = 1003
    }

    /// <summary>
    /// From _AM_AUDIO_RENDERER_STAT_PARAM
    /// </summary>
    public enum AMAudioRendererStatParam
    {
        BreakCount = 1,
        SlaveMode,
        SilenceDur,
        LastBufferDur,
        Discontinuities,
        SlaveRate,
        SlaveDropWriteDur,
        SlaveHighLowError,
        SlaveLastHighLowError,
        SlaveAccumError,
        BufferFullness,
        Jitter
    }

    /// <summary>
    /// From _AM_INTF_SEARCH_FLAGS
    /// </summary>
    [Flags]
    public enum AMIntfSearchFlags
    {
        InputPin = 0x00000001,
        OutputPin = 0x00000002,
        Filter = 0x00000004
    }

    /// <summary>
    /// From AMOVERLAYFX
    /// </summary>
    [Flags]
    public enum AMOverlayFX
    {
        NoFX = 0x00000000,
        MirrorLeftRight = 0x00000002,
        MirrorUpDown = 0x00000004,
        Deinterlace = 0x00000008
    }

    /// <summary>
    /// From VIDEOENCODER_BITRATE_MODE
    /// </summary>
    public enum VideoEncoderBitrateMode
    {
        ConstantBitRate = 0,
        VariableBitRateAverage,
        VariableBitRatePeak
    }

    /// <summary>
    /// From AM_QUERY_DECODER_* defines
    /// </summary>
    public enum AMQueryDecoder
    {
        VMRSupport = 0x00000001,
        DXVA_1Support = 0x00000002,
        DVDSupport = 0x00000003,
        ATSC_SDSupport = 0x00000004,
        ATSC_HDSupport = 0x00000005,
        VMR9Support = 0x00000006
    }

    /// <summary>
    /// From DECODER_CAP_* defines
    /// </summary>
    public enum DecoderCap
    {
        NotSupported = 0x00000000,
        Supported = 0x00000001
    }

    /// <summary>
    /// From unnamed enum (REG_PINFLAG_B_*)
    /// </summary>
    [Flags]
    public enum RegPinFlag
    {
        Zero = 0x1,
        Renderer = 0x2,
        Many = 0x4,
        Output = 0x8
    }

    /// <summary>
    /// From unnamed enum (ADVISE_*)
    /// </summary>
    [Flags]
    public enum Advise
    {
        None = 0x0,
        Clipping = 0x1,
        Palette = 0x2,
        ColorKey = 0x4,
        Position = 0x8,
        DisplayChange = 0x10,
        All = Advise.Clipping | Advise.Palette | Advise.ColorKey | Advise.Position,
        All2 = Advise.All | Advise.DisplayChange
    }

    /// <summary>
    /// From AM_STREAM_INFO_FLAGS
    /// </summary>
    [Flags]
    public enum AMStreamInfoFlags
    {
        StartDefined = 0x00000001,
        StopDefined = 0x00000002,
        Discarding = 0x00000004,
        StopSendExtra = 0x00000010
    }

    /// <summary>
    /// From _DVENCODERRESOLUTION
    /// </summary>
    public enum DVEncoderResolution
    {
        r720x480 = 2012,
        r360x240 = 2013,
        r180x120 = 2014,
        r88x60 = 2015
    }

    /// <summary>
    /// From _DVENCODERVIDEOFORMAT
    /// </summary>
    public enum DVEncoderVideoFormat
    {
        NTSC = 2000,
        PAL = 2001
    }

    /// <summary>
    /// From _DVENCODERFORMAT
    /// </summary>
    public enum DVEncoderFormat
    {
        DVSD = 2007,
        DVHD = 2008,
        DVSL = 2009
    }

    /// <summary>
    /// From MPEG2_PROGRAM_* defines
    /// </summary>
    public enum MPEG2Program
    {
        StreamMap = 0x00000000,
        ElementaryStream = 0x00000001,
        DirecoryPesPacket = 0x00000002,
        PackHeader = 0x00000003,
        PesSteam = 0x00000004,
        SystemHeader = 0x00000005,
    }

    // ------------------------------------------------------------------------

    /// <summary>
    /// From REGFILTER
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RegFilter
    {
        public Guid Clsid;
        [MarshalAs(UnmanagedType.LPWStr)] public string Name;
    }

    /// <summary>
    /// From REGPINTYPES
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RegPinTypes
    {
        public Guid clsMajorType;
        public Guid clsMinorType;
    }

    /// <summary>
    /// From Quality
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Quality
    {
        public QualityMessageType Type;
        public int Proportion;
        public long Late;
        public long TimeStamp;
    }

    /// <summary>
    /// From REGFILTERPINS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RegFilterPins
    {
        [MarshalAs(UnmanagedType.LPWStr)] public string strName;
        [MarshalAs(UnmanagedType.Bool)] public bool bRendered;
        [MarshalAs(UnmanagedType.Bool)] public bool bOutput;
        [MarshalAs(UnmanagedType.Bool)] public bool bZero;
        [MarshalAs(UnmanagedType.Bool)] public bool bMany;
        public Guid clsConnectsToFilter;
        [MarshalAs(UnmanagedType.LPWStr)] public string strConnectsToPin;
        public int nMediaTypes;
        [MarshalAs(UnmanagedType.LPStruct)] public RegPinTypes lpMediaType;
    }

    /// <summary>
    /// From REGPINMEDIUM
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class RegPinMedium
    {
        public Guid clsMedium;
        public int dw1;
        public int dw2;
    }

    /// <summary>
    /// From REGFILTERPINS2
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RegFilterPins2
    {
        public RegPinFlag dwFlags;
        public int cInstances;
        public int nMediaTypes;
        public IntPtr lpMediaType; // REGPINTYPES *
        public int nMediums;
        public IntPtr lpMedium; // REGPINMEDIUM *
        public Guid clsPinCategory;
    }

    /// <summary>
    /// From REGFILTER2
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct RegFilter2
    {
        [FieldOffset(0)] public int dwVersion;
        [FieldOffset(4)] public int dwMerit;
        [FieldOffset(8)] public int cPins;
        [FieldOffset(12)] public IntPtr rgPins; // REGFILTERPINS *
        [FieldOffset(8)] public int cPins2;
        [FieldOffset(12)] public IntPtr rgPins2; // REGFILTERPINS2 *
    }

    /// <summary>
    /// From COLORKEY
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ColorKey
    {
        public int KeyType;
        public int PaletteIndex;
        public int LowColorValue;
        public int HighColorValue;
    }

    /// <summary>
    /// From RGNDATAHEADER
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RgnDataHeader
    {
        public int dwSize;
        public int iType;
        public int nCount;
        public int nRgnSize;
        public Rectangle rcBound;
    }

    /// <summary>
    /// From RGNDATA
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RgnData
    {
        public RgnDataHeader rdh;
        public IntPtr Buffer;
    }

    /// <summary>
    /// From AM_STREAM_INFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AMStreamInfo
    {
        public long tStart;
        public long tStop;
        public int dwStartCookie;
        public int dwStopCookie;
        public int dwFlags;
    }

    /// <summary>
    /// From TIMECODE
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct TimeCode
    {
        public short wFrameRate;
        public short wFrameFract;
        public int dwFrames;
    }

    /// <summary>
    /// From TIMECODE_SAMPLE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TimeCodeSample
    {
        public long qwTick;
        public TimeCode timecode;
        public int dwUser;
        public int dwFlags;
    }

    /// <summary>
    /// From DVINFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DVInfo
    {
        public int dwDVAAuxSrc;
        public int dwDVAAuxCtl;
        public int dwDVAAuxSrc1;
        public int dwDVAAuxCtl1;
        public int dwDVVAuxSrc;
        public int dwDVVAuxCtl;
        public int dwDVReserved1;
        public int dwDVReserved2;
    }

    /// <summary>
    /// From STREAM_ID_MAP
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct StreamIdMap
    {
        public int stream_id;
        public int dwMediaSampleContent;
        public int ulSubstreamFilterValue;
        public int iDataOffset;
    }

    /// <summary>
    /// From CodecAPIEventData
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CodecAPIEventData
    {
        public Guid guid;
        public int dataLength;
        public int reserved1;
        public int reserved2;
        public int reserved3;
    }

    /// <summary>
    /// From AMCOPPSignature
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AMCOPPSignature
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.I1, SizeConst=256)] public byte[] Signature;
    }

    /// <summary>
    /// From AMCOPPCommand
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AMCOPPCommand
    {
        public Guid macKDI;
        public Guid guidCommandID;
        public int dwSequence;
        public int cbSizeData;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.I1, SizeConst=4056)] public byte[] CommandData;
    }

    /// <summary>
    /// From AMCOPPStatusInput
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AMCOPPStatusInput
    {
        public Guid rApp;
        public Guid guidStatusRequestID;
        public int dwSequence;
        public int cbSizeData;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.I1, SizeConst=4056)] public byte[] StatusData;
    }

    /// <summary>
    /// From AMCOPPStatusOutput
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AMCOPPStatusOutput
    {
        public Guid macKDI;
        public int cbSizeData;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.I1, SizeConst=4076)] public byte[] COPPStatus;
    }

#endif

    /// <summary>
    /// From _AM_RENSDEREXFLAGS
    /// </summary>
    [Flags]
    public enum AMRenderExFlags
    {
        None = 0,
        RenderToExistingRenderers = 1
    }

    /// <summary>
    /// From InterleavingMode
    /// </summary>
    public enum InterleavingMode
    {
        None,
        Capture,
        Full,
        NoneBuffered
    }

    /// <summary>
    /// From AM_FILESINK_FLAGS
    /// </summary>
    [Flags]
    public enum AMFileSinkFlags
    {
        None = 0,
        OverWrite = 0x00000001
    }

    /// <summary>
    /// From KSPROPERTY_SUPPORT_* defines
    /// </summary>
    [Flags]
    public enum KSPropertySupport
    {
        Get = 1,
        Set = 2
    }

    /// <summary>
    /// AMPROPERTY_PIN
    /// </summary>
    public enum AMPropertyPin
    {
        Category,
        Medium
    }

    /// <summary>
    /// AMTunerSubChannel
    /// </summary>
    public enum AMTunerSubChannel
    {
        NoTune = -2,
        Default = -1
    }

    /// <summary>
    /// AMTunerSignalStrength
    /// </summary>
    public enum AMTunerSignalStrength
    {
        HasNoSignalStrength = -1,
        NoSignal = 0,
        SignalPresent = 1
    }

    /// <summary>
    /// AMTunerModeType
    /// </summary>
    [Flags]
    public enum AMTunerModeType
    {
        Default = 0x0000,
        TV = 0x0001,
        FMRadio = 0x0002,
        AMRadio = 0x0004,
        Dss = 0x0008,
        DTV = 0x0010
    }

    /// <summary>
    /// AMTunerEventType
    /// </summary>
    public enum AMTunerEventType
    {
        Changed = 0x0001
    }

    /// <summary>
    /// From AnalogVideoStandard
    /// </summary>
    [Flags]
    public enum AnalogVideoStandard
    {
        None = 0x00000000,
        NTSC_M = 0x00000001,
        NTSC_M_J = 0x00000002,
        NTSC_433 = 0x00000004,
        PAL_B = 0x00000010,
        PAL_D = 0x00000020,
        PAL_G = 0x00000040,
        PAL_H = 0x00000080,
        PAL_I = 0x00000100,
        PAL_M = 0x00000200,
        PAL_N = 0x00000400,
        PAL_60 = 0x00000800,
        SECAM_B = 0x00001000,
        SECAM_D = 0x00002000,
        SECAM_G = 0x00004000,
        SECAM_H = 0x00008000,
        SECAM_K = 0x00010000,
        SECAM_K1 = 0x00020000,
        SECAM_L = 0x00040000,
        SECAM_L1 = 0x00080000,
        PAL_N_COMBO = 0x00100000,

        NTSCMask = 0x00000007,
        PALMask = 0x00100FF0,
        SECAMMask = 0x000FF000
    }

    /// <summary>
    /// From TunerInputType
    /// </summary>
    public enum TunerInputType
    {
        Cable,
        Antenna
    }

    /// <summary>
    /// VideoControlFlags
    /// </summary>
    [Flags]
    public enum VideoControlFlags
    {
        None = 0x0,
        FlipHorizontal = 0x0001,
        FlipVertical = 0x0002,
        ExternalTriggerEnable = 0x0004,
        Trigger = 0x0008
    }

    /// <summary>
    /// TVAudioMode
    /// </summary>
    [Flags]
    public enum TVAudioMode
    {
        Mono = 0x0001,
        Stereo = 0x0002,
        LangA = 0x0010,
        LangB = 0x0020,
        LangC = 0x0040,
    }

    /// <summary>
    /// VideoProcAmpProperty
    /// </summary>
    public enum VideoProcAmpProperty
    {
        Brightness,
        Contrast,
        Hue,
        Saturation,
        Sharpness,
        Gamma,
        ColorEnable,
        WhiteBalance,
        BacklightCompensation,
        Gain
    }

    /// <summary>
    /// VideoProcAmpFlags
    /// </summary>
    [Flags]
    public enum VideoProcAmpFlags
    {
        Auto = 0x0001,
        Manual = 0x0002
    }

    /// <summary>
    /// From PhysicalConnectorType
    /// </summary>
    public enum PhysicalConnectorType
    {
        Video_Tuner = 1,
        Video_Composite,
        Video_SVideo,
        Video_RGB,
        Video_YRYBY,
        Video_SerialDigital,
        Video_ParallelDigital,
        Video_SCSI,
        Video_AUX,
        Video_1394,
        Video_USB,
        Video_VideoDecoder,
        Video_VideoEncoder,
        Video_SCART,
        Video_Black,

        Audio_Tuner = 0x1000,
        Audio_Line,
        Audio_Mic,
        Audio_AESDigital,
        Audio_SPDIFDigital,
        Audio_SCSI,
        Audio_AUX,
        Audio_1394,
        Audio_USB,
        Audio_AudioDecoder,
    }

    /// <summary>
    /// AMTVAudioEventType
    /// </summary>
    [Flags]
    public enum AMTVAudioEventType
    {
        Changed = 0x0001
    }

    /// <summary>
    /// CompressionCaps
    /// </summary>
    [Flags]
    public enum CompressionCaps
    {
        None = 0x0,
        CanQuality = 0x01,
        CanCrunch = 0x02,
        CanKeyFrame = 0x04,
        CanBFrame = 0x08,
        CanWindow = 0x10
    }

    /// <summary>
    /// From VfwCompressDialogs
    /// </summary>
    [Flags]
    public enum VfwCompressDialogs
    {
        Config = 0x01,
        About = 0x02,
        QueryConfig = 0x04,
        QueryAbout = 0x08
    }

    /// <summary>
    /// From VfwCaptureDialogs
    /// </summary>
    [Flags]
    public enum VfwCaptureDialogs
    {
        Source = 0x01,
        Format = 0x02,
        Display = 0x04
    }

    /// <summary>
    /// From VIDEO_STREAM_CONFIG_CAPS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class VideoStreamConfigCaps
    {
        public Guid guid;
        public AnalogVideoStandard VideoStandard;
        public Size InputSize;
        public Size MinCroppingSize;
        public Size MaxCroppingSize;
        public int CropGranularityX;
        public int CropGranularityY;
        public int CropAlignX;
        public int CropAlignY;
        public Size MinOutputSize;
        public Size MaxOutputSize;
        public int OutputGranularityX;
        public int OutputGranularityY;
        public int StretchTapsX;
        public int StretchTapsY;
        public int ShrinkTapsX;
        public int ShrinkTapsY;
        public long MinFrameInterval;
        public long MaxFrameInterval;
        public int MinBitsPerSecond;
        public int MaxBitsPerSecond;
    }

    /// <summary>
    /// From AUDIO_STREAM_CONFIG_CAPS
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class AudioStreamConfigCaps
    {
        public Guid guid;
        public int MinimumChannels;
        public int MaximumChannels;
        public int ChannelsGranularity;
        public int MinimumBitsPerSample;
        public int MaximumBitsPerSample;
        public int BitsPerSampleGranularity;
        public int MinimumSampleFrequency;
        public int MaximumSampleFrequency;
        public int SampleFrequencyGranularity;
    }

    #endregion

    #region Interfaces

#if ALLOW_UNTESTED_INTERFACES

    [Guid("56a868a4-0ad4-11ce-b03a-0020af0ba770"),
    Obsolete("This interface has been deprecated.  Use IFilterMapper2::EnumMatchingFilters", false),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumRegFilters
    {
        [PreserveSig]
        int Next(
            [In] int cFilters,
            [Out] out IntPtr apRegFilter, // REGFILTER **
            [Out] out int pcFetched
            );

        [PreserveSig]
        int Skip([In] int cFilters);

        [PreserveSig]
        int Reset();

        [PreserveSig]
        int Clone([Out] out IEnumRegFilters ppEnum);
    }

    [Guid("56a868a3-0ad4-11ce-b03a-0020af0ba770"),
    Obsolete("This interface has been deprecated.  Use IFilterMapper2.", false),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFilterMapper
    {
        [PreserveSig]
        int RegisterFilter(
            [In] Guid clsid,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] Merit dwMerit
            );

        [PreserveSig]
        int RegisterFilterInstance(
            [In] Guid clsid,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out Guid MRId
            );

        [PreserveSig]
        int RegisterPin(
            [In] Guid Filter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In, MarshalAs(UnmanagedType.Bool)] bool bRendered,
            [In, MarshalAs(UnmanagedType.Bool)] bool bOutput,
            [In, MarshalAs(UnmanagedType.Bool)] bool bZero,
            [In, MarshalAs(UnmanagedType.Bool)] bool bMany,
            [In] Guid ConnectsToFilter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ConnectsToPin
            );

        [PreserveSig]
        int RegisterPinType(
            [In] Guid clsFilter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string strName,
            [In] Guid clsMajorType,
            [In] Guid clsSubType
            );

        [PreserveSig]
        int UnregisterFilter([In] Guid Filter);

        [PreserveSig]
        int UnregisterFilterInstance([In] Guid MRId);

        [PreserveSig]
        int UnregisterPin(
            [In] Guid Filter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name
            );

        [PreserveSig]
        int EnumMatchingFilters(
            [Out] out IEnumRegFilters ppEnum,
            [In] Merit dwMerit,
            [In, MarshalAs(UnmanagedType.Bool)] bool bInputNeeded,
            [In] Guid clsInMaj,
            [In] Guid clsInSub,
            [In, MarshalAs(UnmanagedType.Bool)] bool bRender,
            [In, MarshalAs(UnmanagedType.Bool)] bool bOututNeeded,
            [In] Guid clsOutMaj,
            [In] Guid clsOutSub
            );
    }

    [Guid("b79bb0b0-33c1-11d1-abe1-00a0c905f375"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFilterMapper2
    {
        [PreserveSig]
        int CreateCategory(
            [In] Guid clsidCategory,
            [In] Merit dwCategoryMerit,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Description
            );

        [PreserveSig]
        int UnregisterFilter(
            [In] Guid clsidCategory,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szInstance,
            [In] Guid Filter
            );

        [PreserveSig]
        int RegisterFilter(
            [In] Guid clsidFilter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out UCOMIMoniker ppMoniker,
            [In] Guid pclsidCategory,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szInstance,
            [In] ref RegFilter2 prf2
            );

        [PreserveSig]
        int EnumMatchingFilters(
            [Out] out UCOMIEnumMoniker ppEnum,
            [In] int dwFlags,
            [In, MarshalAs(UnmanagedType.Bool)] bool bExactMatch,
            [In] Merit dwMerit,
            [In, MarshalAs(UnmanagedType.Bool)] bool bInputNeeded,
            [In] int cInputTypes,
            [In] IntPtr pInputTypes, // GUID *
            [In] RegPinMedium pMedIn,
            [In] Guid pPinCategoryIn,
            [In, MarshalAs(UnmanagedType.Bool)] bool bRender,
            [In, MarshalAs(UnmanagedType.Bool)] bool bOutputNeeded,
            [In] int cOutputTypes,
            [In] IntPtr pOutputTypes, // GUID *
            [In] RegPinMedium pMedOut,
            [In] Guid pPinCategoryOut
            );
    }

    [Guid("b79bb0b1-33c1-11d1-abe1-00a0c905f375"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFilterMapper3 : IFilterMapper2
    {
        #region IFilterMapper2 Methods

        [PreserveSig]
        new int CreateCategory(
            [In] Guid clsidCategory,
            [In] Merit dwCategoryMerit,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Description
            );

        [PreserveSig]
        new int UnregisterFilter(
            [In] Guid clsidCategory,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szInstance,
            [In] Guid Filter
            );

        [PreserveSig]
        new int RegisterFilter(
            [In] Guid clsidFilter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out UCOMIMoniker ppMoniker,
            [In] Guid pclsidCategory,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szInstance,
            [In] ref RegFilter2 prf2
            );

        [PreserveSig]
        new int EnumMatchingFilters(
            [Out] out UCOMIEnumMoniker ppEnum,
            [In] int dwFlags,
            [In, MarshalAs(UnmanagedType.Bool)] bool bExactMatch,
            [In] Merit dwMerit,
            [In, MarshalAs(UnmanagedType.Bool)] bool bInputNeeded,
            [In] int cInputTypes,
            [In] IntPtr pInputTypes, // GUID *
            [In] RegPinMedium pMedIn,
            [In] Guid pPinCategoryIn,
            [In, MarshalAs(UnmanagedType.Bool)] bool bRender,
            [In, MarshalAs(UnmanagedType.Bool)] bool bOutputNeeded,
            [In] int cOutputTypes,
            [In] IntPtr pOutputTypes, // GUID *
            [In] RegPinMedium pMedOut,
            [In] Guid pPinCategoryOut
            );

        #endregion

        [PreserveSig]
        int GetICreateDevEnum([Out] out ICreateDevEnum ppEnum);
    }

    [Guid("56a868a5-0ad4-11ce-b03a-0020af0ba770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IQualityControl
    {
        [PreserveSig]
        int Notify(
            [In] IBaseFilter pSelf,
            [In] Quality q
            );

        [PreserveSig]
        int SetSink([In] IQualityControl piqc);
    }

    [Guid("56a868a0-0ad4-11ce-b03a-0020af0ba770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOverlayNotify
    {
        [PreserveSig]
        int OnPaletteChange(
            [In] int dwColors,
            [In] IntPtr pPalette // PALETTEENTRY *
            );

        [PreserveSig]
        int OnClipChange(
            [In] Rectangle pSourceRect,
            [In] Rectangle pDestinationRect,
            [In] RgnData pRgnData
            );

        [PreserveSig]
        int OnColorKeyChange([In] ColorKey pColorKey);

        [PreserveSig]
        int OnPositionChange(
            [In] Rectangle pSourceRect,
            [In] Rectangle pDestinationRect
            );
    }

    [Guid("680EFA10-D535-11D1-87C8-00A0C9223196"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOverlayNotify2 : IOverlayNotify
    {
        #region IOverlayNotify Methods

        [PreserveSig]
        new int OnPaletteChange(
            [In] int dwColors,
            [In] IntPtr pPalette // PALETTEENTRY *
            );

        [PreserveSig]
        new int OnClipChange(
            [In] Rectangle pSourceRect,
            [In] Rectangle pDestinationRect,
            [In] RgnData pRgnData
            );

        [PreserveSig]
        new int OnColorKeyChange([In] ColorKey pColorKey);

        [PreserveSig]
        new int OnPositionChange(
            [In] Rectangle pSourceRect,
            [In] Rectangle pDestinationRect
            );

        #endregion

        [PreserveSig]
        int OnDisplayChange(IntPtr hMonitor); // HMONITOR
    }

    [Guid("56a868a1-0ad4-11ce-b03a-0020af0ba770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOverlay
    {
        [PreserveSig]
        int GetPalette(
            [Out] out int pdwColors,
            [Out] out IntPtr ppPalette // PALETTEENTRY **
            );

        [PreserveSig]
        int SetPalette(
            [In] int dwColors,
            [In] IntPtr pPalette // PALETTEENTRY *
            );

        [PreserveSig]
        int GetDefaultColorKey([Out] out ColorKey pColorKey);

        [PreserveSig]
        int GetColorKey([Out] ColorKey pColorKey);

        [PreserveSig]
        int SetColorKey([In] ref ColorKey pColorKey);

        [PreserveSig]
        int GetWindowHandle([Out] out IntPtr pHwnd); // HWND *

        [PreserveSig]
        int GetClipList(
            [Out] out Rectangle pSourceRect,
            [Out] out Rectangle pDestinationRect,
            [Out] out RgnData ppRgnData
            );

        [PreserveSig]
        int GetVideoPosition(
            [Out] out Rectangle pSourceRect,
            [Out] out Rectangle pDestinationRect
            );

        [PreserveSig]
        int Advise(
            [In] IOverlayNotify pOverlayNotify,
            [In] int dwInterests
            );

        [PreserveSig]
        int Unadvise();
    }

    [Guid("56a868a2-0ad4-11ce-b03a-0020af0ba770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMediaEventSink
    {
        [PreserveSig]
        int Notify(
            [In] int EventCode,
            [In] int EventParam1,
            [In] int EventParam2
            );
    }

    [Guid("bf87b6e0-8c27-11d0-b3f0-00aa003761c5"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Obsolete("The ICaptureGraphBuilder interface is deprecated. Use ICaptureGraphBuilder2 instead.", false)]
    public interface ICaptureGraphBuilder
    {
        [PreserveSig]
        int SetFiltergraph([In] IGraphBuilder pfg);

        [PreserveSig]
        int GetFiltergraph([Out] out IGraphBuilder ppfg);

        [PreserveSig]
        int SetOutputFileName(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pType,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpstrFile,
            [Out] out IBaseFilter ppbf,
            [Out] out IFileSinkFilter ppSink
            );

        [PreserveSig]
        int FindInterface(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pCategory,
            [In] IBaseFilter pf,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppint
            );

        [PreserveSig]
        int RenderStream(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pCategory,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pSource,
            [In] IBaseFilter pfCompressor,
            [In] IBaseFilter pfRenderer
            );

        [PreserveSig]
        int ControlStream(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pCategory,
            [In] IBaseFilter pFilter,
            [In] long pstart,
            [In] long pstop,
            [In] short wStartCookie,
            [In] short wStopCookie
            );

        [PreserveSig]
        int AllocCapFile(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpstrFile,
            [In] long dwlSize
            );

        [PreserveSig]
        int CopyCaptureFile(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpwstrOld,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpwstrNew,
            [In] int fAllowEscAbort,
            [In] IAMCopyCaptureFileProgress pFilter
            );
    }

    [Guid("56a868bf-0ad4-11ce-b03a-0020af0ba770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStreamBuilder
    {
        [PreserveSig]
        int Render(
            [In] IPin ppinOut,
            [In] IGraphBuilder pGraph
            );

        [PreserveSig]
        int Backout(
            [In] IPin ppinOut,
            [In] IGraphBuilder pGraph
            );
    }

    [Guid("56a868aa-0ad4-11ce-b03a-0020af0ba770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAsyncReader
    {
        [PreserveSig]
        int RequestAllocator(
            [In] IMemAllocator pPreferred,
            [In] AllocatorProperties pProps,
            [Out] out IMemAllocator ppActual
            );

        [PreserveSig]
        int Request(
            [In] IMediaSample pSample,
            [In] int dwUser
            );

        [PreserveSig]
        int WaitForNext(
            [In] int dwTimeout,
            [Out] out IMediaSample ppSample,
            [Out] out int pdwUser
            );

        [PreserveSig]
        int SyncReadAligned([In] IMediaSample pSample);

        [PreserveSig]
        int SyncRead(
            [In] long llPosition,
            [In] long lLength,
            [Out] out IntPtr pBuffer // BYTE *
            );

        [PreserveSig]
        int Length(
            [Out] out long pTotal,
            [Out] out long pAvailable
            );

        [PreserveSig]
        int BeginFlush();

        [PreserveSig]
        int EndFlush();
    }

    [Guid("56a868ab-0ad4-11ce-b03a-0020af0ba770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IGraphVersion
    {
        [PreserveSig]
        int QueryVersion([Out] out int pVersion);
    }

    [Guid("56a868ad-0ad4-11ce-b03a-0020af0ba770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IResourceConsumer
    {
        [PreserveSig]
        int AcquireResource([In] int idResource);

        [PreserveSig]
        int ReleaseResource([In] int idResource);
    }

    [Guid("56a868ac-0ad4-11ce-b03a-0020af0ba770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IResourceManager
    {
        [PreserveSig]
        int Register(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pName,
            [In] int cResource,
            [Out] out int plToken
            );

        [PreserveSig]
        int RegisterGroup(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pName,
            [In] int cResource,
            [In] IntPtr palTokens, // int *
            [Out] out int plToken
            );

        [PreserveSig]
        int RequestResource(
            [In] int idResource,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pFocusObject,
            [In] IResourceConsumer pConsumer
            );

        [PreserveSig]
        int NotifyAcquire(
            [In] int idResource,
            [In] IResourceConsumer pConsumer,
            [In] int hr
            );

        [PreserveSig]
        int NotifyRelease(
            [In] int idResource,
            [In] IResourceConsumer pConsumer,
            [In, MarshalAs(UnmanagedType.Bool)] bool bStillWant
            );

        [PreserveSig]
        int CancelRequest(
            [In] int idResource,
            [In] IResourceConsumer pConsumer
            );

        [PreserveSig]
        int SetFocus([In, MarshalAs(UnmanagedType.IUnknown)] object pFocusObject);

        [PreserveSig]
        int ReleaseFocus([In, MarshalAs(UnmanagedType.IUnknown)] object pFocusObject);
    }

    [Guid("56a868af-0ad4-11ce-b03a-0020af0ba770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDistributorNotify
    {
        [PreserveSig]
        int Stop();

        [PreserveSig]
        int Pause();

        [PreserveSig]
        int Run(long tStart);

        [PreserveSig]
        int SetSyncSource([In] IReferenceClock pClock);

        [PreserveSig]
        int NotifyGraphChange();
    }

    [Guid("36b73881-c2c8-11cf-8b46-00805f6cef60"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMStreamControl
    {
        [PreserveSig]
        int StartAt(
            [In] long ptStart,
            [In] int dwCookie
            );

        [PreserveSig]
        int StopAt(
            [In] long ptStop,
            [In, MarshalAs(UnmanagedType.Bool)] bool bSendExtra,
            [In] int dwCookie
            );

        [PreserveSig]
        int GetInfo([Out] out AMStreamInfo pInfo);
    }

    [Guid("36b73883-c2c8-11cf-8b46-00805f6cef60"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISeekingPassThru
    {
        int Init(
            [In, MarshalAs(UnmanagedType.Bool)] bool bSupportRendering,
            [In] IPin pPin
            );
    }

    [Guid("56ED71A0-AF5F-11D0-B3F0-00AA003761C5"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMBufferNegotiation
    {
        [PreserveSig]
        int SuggestAllocatorProperties([In] AllocatorProperties pprop);

        [PreserveSig]
        int GetAllocatorProperties([Out] out AllocatorProperties pprop);
    }

    [Guid("C6E13370-30AC-11d0-A18C-00A0C9118956"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMCameraControl
    {
        [PreserveSig]
        int GetRange(
            [In] CameraControlProperty Property,
            [Out] out int pMin,
            [Out] out int pMax,
            [Out] out int pSteppingDelta,
            [Out] out int pDefault,
            [Out] out CameraControlFlags pCapsFlags
            );

        [PreserveSig]
        int Set(
            [In] CameraControlProperty Property,
            [In] int lValue,
            [In] CameraControlFlags Flags
            );

        [PreserveSig]
        int Get(
            [In] CameraControlProperty Property,
            [Out] out int lValue,
            [Out] out CameraControlFlags Flags
            );
    }

    [Guid("211A8765-03AC-11d1-8D13-00AA00BD8339"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IBPCSatelliteTuner : IAMTuner
    {
        #region IAMTuner Methods

        [PreserveSig]
        new int put_Channel(
            [In] int lChannel,
            [In] AMTunerSubChannel lVideoSubChannel,
            [In] AMTunerSubChannel lAudioSubChannel
            );

        [PreserveSig]
        new int get_Channel(
            [Out] out int plChannel,
            [Out] out AMTunerSubChannel plVideoSubChannel,
            [Out] out AMTunerSubChannel plAudioSubChannel
            );

        [PreserveSig]
        new int ChannelMinMax(
            [Out] out int lChannelMin,
            [Out] out int lChannelMax
            );

        [PreserveSig]
        new int put_CountryCode([In] int lCountryCode);

        [PreserveSig]
        new int get_CountryCode([Out] out int plCountryCode);

        [PreserveSig]
        new int put_TuningSpace([In] int lTuningSpace);

        [PreserveSig]
        new int get_TuningSpace([Out] out int plTuningSpace);

        [PreserveSig]
        new int Logon([In] IntPtr hCurrentUser); // HANDLE

        [PreserveSig]
        new int Logout();

        [PreserveSig]
        new int SignalPresent([Out] out AMTunerSignalStrength plSignalStrength);

        [PreserveSig]
        new int put_Mode([In] AMTunerModeType lMode);

        [PreserveSig]
        new int get_Mode([Out] out AMTunerModeType plMode);

        [PreserveSig]
        new int GetAvailableModes([Out] out AMTunerModeType plModes);

        [PreserveSig]
        new int RegisterNotificationCallBack(
            [In] IAMTunerNotification pNotify,
            [In] AMTunerEventType lEvents
            );

        [PreserveSig]
        new int UnRegisterNotificationCallBack([In] IAMTunerNotification pNotify);

        #endregion

        [PreserveSig]
        int get_DefaultSubChannelTypes(
            [Out] out int plDefaultVideoType,
            [Out] out int plDefaultAudioType
            );

        [PreserveSig]
        int put_DefaultSubChannelTypes(
            [In] int lDefaultVideoType,
            [In] int lDefaultAudioType
            );

        [PreserveSig]
        int IsTapingPermitted();
    }

    [Guid("83EC1C33-23D1-11d1-99E6-00A0C9560266"),
    Obsolete("This interface has been deprecated.", false),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMTVAudioNotification
    {
        [PreserveSig]
        int OnEvent([In] AMTVAudioEventType Event);
    }

    [Guid("C6E133B0-30AC-11d0-A18C-00A0C9118956"),
    Obsolete("This interface has been deprecated.", false),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMAnalogVideoEncoder
    {
        [PreserveSig]
        int get_AvailableTVFormats([Out] out AnalogVideoStandard lAnalogVideoStandard);

        [PreserveSig]
        int put_TVFormat([In] AnalogVideoStandard lAnalogVideoStandard);

        [PreserveSig]
        int get_TVFormat([Out] out AnalogVideoStandard plAnalogVideoStandard);

        [PreserveSig]
        int put_CopyProtection([In] VideoCopyProtectionType lVideoCopyProtection);

        [PreserveSig]
        int get_CopyProtection([Out] out VideoCopyProtectionType lVideoCopyProtection);


        [PreserveSig]
        int put_CCEnable([In] int lCCEnable);

        [PreserveSig]
        int get_CCEnable([Out] out int lCCEnable);
    }

    [Guid("6025A880-C0D5-11d0-BD4E-00A0C911CE86"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMediaPropertyBag : IPropertyBag
    {
        #region IPropertyBag Methods

        [PreserveSig]
        new int Read(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPropName,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pVar,
            [In] IErrorLog pErrorLog
            );

        [PreserveSig]
        new int Write(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPropName,
            [In] ref object pVar
            );

        #endregion

        [PreserveSig]
        int EnumProperty(
            [In] int iProperty,
            [In, Out] ref object pvarPropertyName,
            [In, Out] ref object pvarPropertyValue
            );
    }

    [Guid("5738E040-B67F-11d0-BD4D-00A0C911CE86"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistMediaPropertyBag : IPersist
    {
        #region IPersist

        [PreserveSig]
        new int GetClassID([Out] out Guid pClassID);

        #endregion

        [PreserveSig]
        int InitNew();

        [PreserveSig]
        int Load(
            [In] IMediaPropertyBag pPropBag,
            [In] IErrorLog pErrorLog
            );

        [PreserveSig]
        int Save(
            [In] IMediaPropertyBag pPropBag,
            [In, MarshalAs(UnmanagedType.Bool)] bool fClearDirty,
            [In, MarshalAs(UnmanagedType.Bool)] bool fSaveAllProperties
            );
    }

    [Guid("F938C991-3029-11cf-8C44-00AA006B6814"),
    Obsolete("This interface has been deprecated.", false),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMPhysicalPinInfo
    {
        [PreserveSig]
        int GetPhysicalType(
            [Out] out PhysicalConnectorType pType,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszType
            );
    }

    [Guid("B5730A90-1A2C-11cf-8C23-00AA006B6814"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMExtDevice
    {
        [PreserveSig]
        int GetCapability(
            [In] int Capability,
            [Out] out int pValue,
            [Out] out double pdblValue
            );

        [PreserveSig]
        int get_ExternalDeviceID([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszData);

        [PreserveSig]
        int get_ExternalDeviceVersion([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszData);

        [PreserveSig]
        int put_DevicePower([In] int PowerMode);

        [PreserveSig]
        int get_DevicePower([Out] out int pPowerMode);

        [PreserveSig]
        int Calibrate(
            [In] IntPtr hEvent, // HEVENT
            [In] int Mode,
            [Out] out int pStatus
            );

        [PreserveSig]
        int put_DevicePort([In] int DevicePort);

        [PreserveSig]
        int get_DevicePort([Out] out int pDevicePort);
    }

    [Guid("A03CD5F0-3045-11cf-8C44-00AA006B6814"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMExtTransport
    {
        [PreserveSig]
        int GetCapability(
            [In] int Capability,
            [Out] out int pValue,
            [Out] out double pdblValue
            );

        [PreserveSig]
        int put_MediaState([In] int State);

        [PreserveSig]
        int get_MediaState([Out] out int pState);

        [PreserveSig]
        int put_LocalControl([In] int State);

        [PreserveSig]
        int get_LocalControl([Out] out int pState);

        [PreserveSig]
        int GetStatus(
            [In] int StatusItem,
            [Out] out int pValue
            );

        [PreserveSig]
        int GetTransportBasicParameters(
            [In] int Param,
            [Out] out int pValue,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszData
            );

        [PreserveSig]
        int SetTransportBasicParameters(
            [In] int Param,
            [In] int Value,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszData
            );

        [PreserveSig]
        int GetTransportVideoParameters(
            [In] int Param,
            [Out] out int pValue
            );

        [PreserveSig]
        int SetTransportVideoParameters(
            [In] int Param,
            [In] int Value
            );

        [PreserveSig]
        int GetTransportAudioParameters(
            [In] int Param,
            [Out] out int pValue
            );

        [PreserveSig]
        int SetTransportAudioParameters(
            [In] int Param,
            [In] int Value
            );

        [PreserveSig]
        int put_Mode([In] int Mode);

        [PreserveSig]
        int get_Mode([Out] out int pMode);

        [PreserveSig]
        int put_Rate([In] double dblRate);

        [PreserveSig]
        int get_Rate([Out] out double pdblRate);

        [PreserveSig]
        int GetChase(
            [Out] out int pEnabled,
            [Out] out int pOffset,
            [Out] out IntPtr phEvent // HEVENT
            );

        [PreserveSig]
        int SetChase(
            [In] int Enable,
            [In] int Offset,
            [In] IntPtr hEvent // HEVENT
            );

        [PreserveSig]
        int GetBump(
            [Out] out int pSpeed,
            [Out] out int pDuration
            );

        [PreserveSig]
        int SetBump(
            [In] int Speed,
            [In] int Duration
            );

        [PreserveSig]
        int get_AntiClogControl([Out] out int pEnabled);

        [PreserveSig]
        int put_AntiClogControl([In] int Enable);

        [PreserveSig]
        int GetEditPropertySet(
            [In] int EditID,
            [Out] out int pState
            );

        [PreserveSig]
        int SetEditPropertySet(
            [In, Out] ref int pEditID,
            [In] int State
            );

        [PreserveSig]
        int GetEditProperty(
            [In] int EditID,
            [In] int Param,
            [Out] out int pValue
            );

        [PreserveSig]
        int SetEditProperty(
            [In] int EditID,
            [In] int Param,
            [In] int Value
            );

        [PreserveSig]
        int get_EditStart([Out] out int pValue);

        [PreserveSig]
        int put_EditStart([In] int Value);
    }

    [Guid("9B496CE1-811B-11cf-8C77-00AA006B6814"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMTimecodeReader
    {
        [PreserveSig]
        int GetTCRMode(
            [In] int Param,
            [Out] out int pValue
            );

        [PreserveSig]
        int SetTCRMode(
            [In] int Param,
            [In] int Value
            );

        [PreserveSig]
        int put_VITCLine([In] int Line);

        [PreserveSig]
        int get_VITCLine([Out] out int pLine);

        [PreserveSig]
        int GetTimecode([Out] out TimeCodeSample pTimecodeSample);
    }

    [Guid("9B496CE0-811B-11cf-8C77-00AA006B6814"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMTimecodeGenerator
    {
        [PreserveSig]
        int GetTCGMode(
            [In] int Param,
            [Out] out int pValue
            );

        [PreserveSig]
        int SetTCGMode(
            [In] int Param,
            [In] int Value
            );

        [PreserveSig]
        int put_VITCLine([In] int Line);

        [PreserveSig]
        int get_VITCLine([Out] out int pLine);

        [PreserveSig]
        int SetTimecode([In] TimeCodeSample pTimecodeSample);


        [PreserveSig]
        int GetTimecode([Out] TimeCodeSample pTimecodeSample);
    }

    [Guid("9B496CE2-811B-11cf-8C77-00AA006B6814"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMTimecodeDisplay
    {
        [PreserveSig]
        int GetTCDisplayEnable([Out] out int pState);

        [PreserveSig]
        int SetTCDisplayEnable([In] int State);

        [PreserveSig]
        int GetTCDisplay(
            [In] int Param,
            [Out] out int pValue
            );

        [PreserveSig]
        int SetTCDisplay(
            [In] int Param,
            [In] int Value
            );
    }

    [Guid("c6545bf0-e76b-11d0-bd52-00a0c911ce86"),
    Obsolete("This interface has been deprecated.", false),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMDevMemoryAllocator
    {
        [PreserveSig]
        int GetInfo(
            [Out] out int pdwcbTotalFree,
            [Out] out int pdwcbLargestFree,
            [Out] out int pdwcbTotalMemory,
            [Out] out int pdwcbMinimumChunk
            );

        [PreserveSig]
        int CheckMemory([In] IntPtr pBuffer); // BYTE *

        [PreserveSig]
        int Alloc(
            [Out] out IntPtr ppBuffer, // BYTE **
            [In, Out] ref int pdwcbBuffer
            );

        [PreserveSig]
        int Free([In] IntPtr pBuffer); // BYTE *

        [PreserveSig]
        int GetDevMemoryObject(
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppUnkInnner,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter
            );
    }

    [Guid("c6545bf1-e76b-11d0-bd52-00a0c911ce86"),
    Obsolete("This interface has been deprecated.", false),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMDevMemoryControl
    {
        [PreserveSig]
        int QueryWriteSync();

        [PreserveSig]
        int WriteSync();

        [PreserveSig]
        int GetDevId([Out] out int pdwDevId);
    }

    [Guid("c1960960-17f5-11d1-abe1-00a0c905f375"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMStreamSelect
    {
        [PreserveSig]
        int Count([Out] out int pcStreams);

        [PreserveSig]
        int Info(
            [In] int lIndex,
            [Out] out AMMediaType ppmt,
            [Out] out AMStreamSelectInfoFlags pdwFlags,
            [Out] out int plcid,
            [Out] out int pdwGroup,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszName,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppObject,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppUnk
            );

        [PreserveSig]
        int Enable(
            [In] int lIndex,
            [In] AMStreamSelectEnableFlags dwFlags
            );
    }

    [Guid("8389d2d0-77d7-11d1-abe6-00a0c905f375"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMResourceControl
    {
        [PreserveSig]
        int Reserve(
            [In] AMResCtlReserveFlags dwFlags,
            [In] IntPtr pvReserved // PVOID
            );
    }

    [Guid("4d5466b0-a49c-11d1-abe8-00a0c905f375"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMClockAdjust
    {
        [PreserveSig]
        int SetClockDelta([In] long rtDelta);
    }

    [Guid("2dd74950-a890-11d1-abe8-00a0c905f375"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMFilterMiscFlags
    {
        [PreserveSig]
        int GetMiscFlags();
    }

    [Guid("48efb120-ab49-11d2-aed2-00a0c995e8d5"),
    Obsolete("This interface has been deprecated.", false),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDrawVideoImage
    {
        [PreserveSig]
        int DrawVideoImageBegin();

        [PreserveSig]
        int DrawVideoImageEnd();

        [PreserveSig]
        int DrawVideoImageDraw(
            [In] IntPtr hdc, // HDC
            [In] Rectangle lprcSrc,
            [In] Rectangle lprcDst
            );
    }

    [Guid("2e5ea3e0-e924-11d2-b6da-00a0c995e8df"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDecimateVideoImage
    {
        [PreserveSig]
        int SetDecimationImageSize(
            [In] int lWidth,
            [In] int lHeight
            );

        [PreserveSig]
        int ResetDecimationImageSize();
    }

    [Guid("60d32930-13da-11d3-9ec6-c4fcaef5c7be"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMVideoDecimationProperties
    {
        [PreserveSig]
        int QueryDecimationUsage([Out] out DecimationUsage lpUsage);

        [PreserveSig]
        int SetDecimationUsage([In] DecimationUsage Usage);
    }

    [Guid("F185FE76-E64E-11d2-B76E-00C04FB6BD3D"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMPushSource
    {
        [PreserveSig]
        int GetPushSourceFlags([Out] out AMPushSourceFlags pFlags);

        [PreserveSig]
        int SetPushSourceFlags([In] AMPushSourceFlags Flags);

        [PreserveSig]
        int SetStreamOffset([In] long rtOffset);

        [PreserveSig]
        int GetStreamOffset([Out] out long prtOffset);

        [PreserveSig]
        int GetMaxStreamOffset([Out] out long prtMaxOffset);

        [PreserveSig]
        int SetMaxStreamOffset([In] long rtMaxOffset);
    }

    [Guid("f90a6130-b658-11d2-ae49-0000f8754b99"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMDeviceRemoval
    {
        [PreserveSig]
        int DeviceInfo(
            [Out] out Guid pclsidInterfaceClass,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pwszSymbolicLink
            );

        [PreserveSig]
        int Reassociate();

        [PreserveSig]
        int Disassociate();
    }

    [Guid("d18e17a0-aacb-11d0-afb0-00aa00b67a42"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDVEnc
    {
        [PreserveSig]
        int get_IFormatResolution(
            [Out] out DVEncoderVideoFormat VideoFormat,
            [Out] out DVEncoderFormat DVFormat,
            [Out] out DVEncoderResolution Resolution,
            [In] byte fDVInfo,
            [Out] out DVInfo sDVInfo
            );

        [PreserveSig]
        int put_IFormatResolution(
            [In] DVEncoderVideoFormat VideoFormat,
            [In] DVEncoderFormat DVFormat,
            [In] DVEncoderResolution Resolution,
            [In] byte fDVInfo,
            [In] DVInfo sDVInfo
            );
    }

    [Guid("b8e8bd60-0bfe-11d0-af91-00aa00b67a42"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IIPDVDec
    {
        [PreserveSig]
        int get_IPDisplay([Out] out int displayPix);

        [PreserveSig]
        int put_IPDisplay([In] int displayPix);
    }

    [Guid("58473A19-2BC8-4663-8012-25F81BABDDD1"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDVRGB219
    {
        [PreserveSig]
        int SetRGB219([In, MarshalAs(UnmanagedType.Bool)] bool bState);
    }

    [Guid("92a3a302-da7c-4a1f-ba7e-1802bb5d2d02"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDVSplitter
    {
        [PreserveSig]
        int DiscardAlternateVideoFrames([In] int nDiscard);
    }

    [Guid("22320CB2-D41A-11d2-BF7C-D7CB9DF0BF93"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMAudioRendererStats
    {
        [PreserveSig]
        int GetStatParam(
            [In] AMAudioRendererStatParam dwParam,
            [Out] out int pdwParam1,
            [Out] out int pdwParam2
            );
    }

    [Guid("62EA93BA-EC62-11d2-B770-00C04FB6BD3D"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMLatency
    {
        [PreserveSig]
        int GetLatency([In] long prtLatency);
    }

    [Guid("632105FA-072E-11d3-8AF9-00C04FB6BD3D"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMGraphStreams
    {
        [PreserveSig]
        int FindUpstreamInterface(
            [In] IPin pPin,
            [In] Guid riid,
            [Out] out IntPtr ppvInterface, // void **
            [In] AMIntfSearchFlags dwFlags
            );

        [PreserveSig]
        int SyncUsingStreamOffset([In, MarshalAs(UnmanagedType.Bool)] bool bUseStreamOffset);

        [PreserveSig]
        int SetMaxGraphLatency([In] long rtMaxGraphLatency);
    }

    [Guid("62fae250-7e65-4460-bfc9-6398b322073c"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMOverlayFX
    {
        [PreserveSig]
        int QueryOverlayFXCaps([Out] out AMOverlayFX lpdwOverlayFXCaps);

        [PreserveSig]
        int SetOverlayFX([In] AMOverlayFX dwOverlayFX);

        [PreserveSig]
        int GetOverlayFX([Out] out AMOverlayFX lpdwOverlayFX);
    }

    [Guid("8E1C39A1-DE53-11cf-AA63-0080C744528D"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMOpenProgress
    {
        [PreserveSig]
        int QueryProgress(
            [Out] out long pllTotal,
            [Out] out long pllCurrent
            );

        [PreserveSig]
        int AbortOperation();
    }

    [Guid("436eee9c-264f-4242-90e1-4e330c107512"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMpeg2Demultiplexer
    {
        [PreserveSig]
        int CreateOutputPin(
            [In] AMMediaType pMediaType,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPinName,
            [Out] out IPin ppIPin
            );

        [PreserveSig]
        int SetOutputPinMediaType(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPinName,
            [In] AMMediaType pMediaType
            );

        [PreserveSig]
        int DeleteOutputPin([In, MarshalAs(UnmanagedType.LPWStr)] string pszPinName);
    }

    [Guid("945C1566-6202-46fc-96C7-D87F289C6534"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumStreamIdMap
    {
        [PreserveSig]
        int Next(
            [In] int cRequest,
            [In, Out] ref IntPtr pStreamIdMap, // STREAM_ID_MAP *
            [Out] out int pcReceived
            );

        [PreserveSig]
        int Skip([In] int cRecords);

        [PreserveSig]
        int Reset();

        [PreserveSig]
        int Clone([Out] out IEnumStreamIdMap ppIEnumStreamIdMap);
    }

    [Guid("D0E04C47-25B8-4369-925A-362A01D95444"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMPEG2StreamIdMap
    {
        [PreserveSig]
        int MapStreamId(
            [In] int ulStreamId,
            [In] MPEG2Program MediaSampleContent,
            [In] int ulSubstreamFilterValue,
            [In] int iDataOffset
            );

        [PreserveSig]
        int UnmapStreamId(
            [In] int culStreamId,
            [In, MarshalAs(UnmanagedType.LPArray)] int[] pulStreamId
            );

        [PreserveSig]
        int EnumStreamIdMap([Out] out IEnumStreamIdMap ppIEnumStreamIdMap);
    }

    [Guid("7B3A2F01-0751-48DD-B556-004785171C54"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IRegisterServiceProvider
    {
        [PreserveSig]
        int RegisterService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guidService,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pUnkObject
            );
    }

    [Guid("9FD52741-176D-4b36-8F51-CA8F933223BE"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMClockSlave
    {
        [PreserveSig]
        int SetErrorTolerance([In] int dwTolerance);

        [PreserveSig]
        int GetErrorTolerance([Out] out int pdwTolerance);
    }

    [Guid("4995f511-9ddb-4f12-bd3b-f04611807b79"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMGraphBuilderCallback
    {
        [PreserveSig]
        int SelectedFilter([In] UCOMIMoniker pMon);

        [PreserveSig]
        int CreatedFilter([In] IBaseFilter pFil);
    }

    [Guid("901db4c7-31ce-41a2-85dc-8fa0bf41b8da"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICodecAPI
    {
        [PreserveSig]
        int IsSupported([In] Guid Api);

        [PreserveSig]
        int IsModifiable([In] Guid Api);

        [PreserveSig]
        int GetParameterRange(
            [In] Guid Api,
            [Out] out object ValueMin,
            [Out] out object ValueMax,
            [Out] out object SteppingDelta
            );

        [PreserveSig]
        int GetParameterValues(
            [In] Guid Api,
            [Out] out object[] Values,
            [Out] out int ValuesCount
            );

        [PreserveSig]
        int GetDefaultValue(
            [In] Guid Api,
            [Out] out object Value
            );

        [PreserveSig]
        int GetValue(
            [In] Guid Api,
            [Out] out object Value
            );

        [PreserveSig]
        int SetValue(
            [In] Guid Api,
            [In] object Value
            );

        [PreserveSig]
        int RegisterForEvent(
            [In] Guid Api,
            [In] int userData
            );

        [PreserveSig]
        int UnregisterForEvent([In] Guid Api);

        [PreserveSig]
        int SetAllDefaults();

        [PreserveSig]
        int SetValueWithNotify(
            [In] Guid Api,
            [In] object Value,
            [Out] out Guid[] ChangedParam,
            [Out] int ChangedParamCount
            );

        [PreserveSig]
        int SetAllDefaultsWithNotify(
            [Out] out Guid[] ChangedParam,
            [Out] out int ChangedParamCount
            );

        [PreserveSig]
        int GetAllSettings([In] UCOMIStream pStream);

        [PreserveSig]
        int SetAllSettings([In] UCOMIStream pStream);

        [PreserveSig]
        int SetAllSettingsWithNotify(
            [In] UCOMIStream pStream,
            [Out] out Guid[] ChangedParam,
            [Out] out int ChangedParamCount
            );
    }

    [Guid("70423839-6ACC-4b23-B079-21DBF08156A5"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEncoderAPI
    {
        [PreserveSig]
        int IsSupported([In] Guid Api);

        [PreserveSig]
        int IsAvailable([In] Guid Api);

        [PreserveSig]
        int GetParameterRange(
            [In] Guid Api,
            [Out] out object ValueMin,
            [Out] out object ValueMax,
            [Out] out object SteppingDelta
            );

        [PreserveSig]
        int GetParameterValues(
            [In] Guid Api,
            [Out] out object[] Values,
            [Out] out int ValuesCount
            );

        [PreserveSig]
        int GetDefaultValue(
            [In] Guid Api,
            [Out] out object Value
            );

        [PreserveSig]
        int GetValue(
            [In] Guid Api,
            [Out] out object Value
            );

        [PreserveSig]
        int SetValue(
            [In] Guid Api,
            [In] object Value
            );
    }

    [Guid("02997C3B-8E1B-460e-9270-545E0DE9563E"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVideoEncoder : IEncoderAPI
    {
        #region IEncoderAPI Methods

        [PreserveSig]
        new int IsSupported([In] Guid Api);

        [PreserveSig]
        new int IsAvailable([In] Guid Api);

        [PreserveSig]
        new int GetParameterRange(
            [In] Guid Api,
            [Out] out object ValueMin,
            [Out] out object ValueMax,
            [Out] out object SteppingDelta
            );

        [PreserveSig]
        new int GetParameterValues(
            [In] Guid Api,
            [Out] out object[] Values,
            [Out] out int ValuesCount
            );

        [PreserveSig]
        new int GetDefaultValue(
            [In] Guid Api,
            [Out] out object Value
            );

        [PreserveSig]
        new int GetValue(
            [In] Guid Api,
            [Out] out object Value
            );

        [PreserveSig]
        new int SetValue(
            [In] Guid Api,
            [In] object Value
            );

        #endregion
    }

    [Guid("c0dff467-d499-4986-972b-e1d9090fa941"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMDecoderCaps
    {
        [PreserveSig]
        int GetDecoderCaps(
            [In] AMQueryDecoder dwCapIndex,
            [Out] out DecoderCap lpdwCap
            );
    }

    [Guid("6feded3e-0ff1-4901-a2f1-43f7012c8515"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMCertifiedOutputProtection
    {
        [PreserveSig]
        int KeyExchange(
            [Out] out Guid pRandom,
            [Out] out IntPtr VarLenCertGH, // BYTE **
            [Out] out int pdwLengthCertGH
            );

        [PreserveSig]
        int SessionSequenceStart([In] AMCOPPSignature pSig);

        [PreserveSig]
        int ProtectionCommand([In] AMCOPPCommand cmd);

        [PreserveSig]
        int ProtectionStatus(
            [In] AMCOPPStatusInput pStatusInput,
            [Out] out AMCOPPStatusOutput pStatusOutput
            );
    }
#endif

    [Guid("56a868a9-0ad4-11ce-b03a-0020af0ba770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IGraphBuilder : IFilterGraph
    {
        #region IFilterGraph Methods

        [PreserveSig]
        new int AddFilter(
            [In] IBaseFilter pFilter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pName
            );

        [PreserveSig]
        new int RemoveFilter([In] IBaseFilter pFilter);

        [PreserveSig]
        new int EnumFilters([Out] out IEnumFilters ppEnum);

        [PreserveSig]
        new int FindFilterByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pName,
            [Out] out IBaseFilter ppFilter
            );

        [PreserveSig]
        new int ConnectDirect(
            [In] IPin ppinOut,
            [In] IPin ppinIn,
            [In, MarshalAs(UnmanagedType.LPStruct)]
            AMMediaType pmt
            );

        [PreserveSig]
        new int Reconnect([In] IPin ppin);

        [PreserveSig]
        new int Disconnect([In] IPin ppin);

        [PreserveSig]
        new int SetDefaultSyncSource();

        #endregion

        [PreserveSig]
        int Connect(
            [In] IPin ppinOut,
            [In] IPin ppinIn
            );

        [PreserveSig]
        int Render([In] IPin ppinOut);

        [PreserveSig]
        int RenderFile(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFile,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrPlayList
            );

        [PreserveSig]
        int AddSourceFilter(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFilterName,
            [Out] out IBaseFilter ppFilter
            );

        [PreserveSig]
        int SetLogFile(IntPtr hFile); // DWORD_PTR

        [PreserveSig]
        int Abort();

        [PreserveSig]
        int ShouldOperationContinue();
    }

    [Guid("36b73882-c2c8-11cf-8b46-00805f6cef60"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFilterGraph2 : IGraphBuilder
    {
        #region IFilterGraph Methods

        [PreserveSig]
        new int AddFilter(
            [In] IBaseFilter pFilter,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pName
            );

        [PreserveSig]
        new int RemoveFilter([In] IBaseFilter pFilter);

        [PreserveSig]
        new int EnumFilters([Out] out IEnumFilters ppEnum);

        [PreserveSig]
        new int FindFilterByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pName,
            [Out] out IBaseFilter ppFilter
            );

        [PreserveSig]
        new int ConnectDirect(
            [In] IPin ppinOut,
            [In] IPin ppinIn,
            [In, MarshalAs(UnmanagedType.LPStruct)]
            AMMediaType pmt
            );

        [PreserveSig]
        new int Reconnect([In] IPin ppin);

        [PreserveSig]
        new int Disconnect([In] IPin ppin);

        [PreserveSig]
        new int SetDefaultSyncSource();

        #endregion

        #region IGraphBuilder Method

        [PreserveSig]
        new int Connect(
            [In] IPin ppinOut,
            [In] IPin ppinIn
            );

        [PreserveSig]
        new int Render([In] IPin ppinOut);

        [PreserveSig]
        new int RenderFile(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFile,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrPlayList
            );

        [PreserveSig]
        new int AddSourceFilter(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFilterName,
            [Out] out IBaseFilter ppFilter
            );

        [PreserveSig]
        new int SetLogFile(IntPtr hFile); // DWORD_PTR

        [PreserveSig]
        new int Abort();

        [PreserveSig]
        new int ShouldOperationContinue();

        #endregion

        [PreserveSig]
        int AddSourceFilterForMoniker(
            [In] UCOMIMoniker pMoniker,
            [In] UCOMIBindCtx pCtx,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFilterName,
            [Out] out IBaseFilter ppFilter
            );

        [PreserveSig]
        int ReconnectEx(
            [In] IPin ppin,
            [In] AMMediaType pmt
            );

        [PreserveSig]
        int RenderEx(
            [In] IPin pPinOut,
            [In] AMRenderExFlags dwFlags,
            [In] IntPtr pvContext // DWORD *
            );
    }
    [Guid("5ACD6AA0-F482-11ce-8B67-00AA00A3F1A6"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IConfigAviMux
    {
        [PreserveSig]
        int SetMasterStream([In] int iStream);

        [PreserveSig]
        int GetMasterStream([Out] out int pStream);

        [PreserveSig]
        int SetOutputCompatibilityIndex([In, MarshalAs(UnmanagedType.Bool)] bool fOldIndex);

        [PreserveSig]
        int GetOutputCompatibilityIndex([Out, MarshalAs(UnmanagedType.Bool)] out bool pfOldIndex);
    }

    [Guid("BEE3D220-157B-11d0-BD23-00A0C911CE86"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IConfigInterleaving
    {
        [PreserveSig]
        int put_Mode([In] InterleavingMode mode);

        [PreserveSig]
        int get_Mode([Out] out InterleavingMode pMode);

        [PreserveSig]
        int put_Interleaving(
            [In] ref long prtInterleave,
            [In] ref long prtPreroll
            );

        [PreserveSig]
        int get_Interleaving(
            [Out] out long prtInterleave,
            [Out] out long prtPreroll
            );
    }

    [Guid("a2104830-7c70-11cf-8bce-00aa00a3f1a6"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileSinkFilter
    {
        [PreserveSig]
        int SetFileName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt
            );

        [PreserveSig]
        int GetCurFile(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pszFileName,
            [Out, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt
            );
    }

    [Guid("00855B90-CE1B-11d0-BD4F-00A0C911CE86"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileSinkFilter2 : IFileSinkFilter
    {
        #region IFileSinkFilter Methods

        [PreserveSig]
        new int SetFileName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt
            );

        [PreserveSig]
        new int GetCurFile(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pszFileName,
            [Out, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt
            );

        #endregion

        [PreserveSig]
        int SetMode([In] AMFileSinkFlags dwFlags);

        [PreserveSig]
        int GetMode([Out] out AMFileSinkFlags dwFlags);
    }

    [Guid("56a868a6-0ad4-11ce-b03a-0020af0ba770"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileSourceFilter
    {
        [PreserveSig]
        int Load(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
            [In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt
            );

        [PreserveSig]
        int GetCurFile(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pszFileName,
            [Out, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt
            );
    }

    [Guid("e46a9787-2b71-444d-a4b5-1fab7b708d6a"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVideoFrameStep
    {
        [PreserveSig]
        int Step(
            [In] int dwFrames,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pStepObject
            );

        [PreserveSig]
        int CanStep(
            [In] int bMultiple,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pStepObject
            );

        [PreserveSig]
        int CancelStep();
    }

    [Guid("31EFAC30-515C-11d0-A9AA-00AA0061BE93"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IKsPropertySet
    {
        [PreserveSig]
        int Set(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guidPropSet,
            [In] int dwPropID,
            [In] IntPtr pInstanceData,
            [In] int cbInstanceData,
            [In] IntPtr pPropData,
            [In] int cbPropData
            );

        [PreserveSig]
        int Get(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guidPropSet,
            [In] int dwPropID,
            [In] IntPtr pInstanceData,
            [In] int cbInstanceData,
            [In, Out] IntPtr pPropData,
            [In] int cbPropData,
            [Out] out int pcbReturned
            );

        [PreserveSig]
        int QuerySupported(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guidPropSet,
            [In] int dwPropID,
            [Out] out KSPropertySupport pTypeSupport
            );
    }

    [Guid("211A8761-03AC-11d1-8D13-00AA00BD8339"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMTuner
    {
        [PreserveSig]
        int put_Channel(
            [In] int lChannel,
            [In] AMTunerSubChannel lVideoSubChannel,
            [In] AMTunerSubChannel lAudioSubChannel
            );

        [PreserveSig]
        int get_Channel(
            [Out] out int plChannel,
            [Out] out AMTunerSubChannel plVideoSubChannel,
            [Out] out AMTunerSubChannel plAudioSubChannel
            );

        [PreserveSig]
        int ChannelMinMax(
            [Out] out int lChannelMin,
            [Out] out int lChannelMax
            );

        [PreserveSig]
        int put_CountryCode([In] int lCountryCode);

        [PreserveSig]
        int get_CountryCode([Out] out int plCountryCode);

        [PreserveSig]
        int put_TuningSpace([In] int lTuningSpace);

        [PreserveSig]
        int get_TuningSpace([Out] out int plTuningSpace);

        [PreserveSig]
        int Logon([In] IntPtr hCurrentUser); // HANDLE

        [PreserveSig]
        int Logout();

        [PreserveSig]
        int SignalPresent([Out] out AMTunerSignalStrength plSignalStrength);

        [PreserveSig]
        int put_Mode([In] AMTunerModeType lMode);

        [PreserveSig]
        int get_Mode([Out] out AMTunerModeType plMode);

        [PreserveSig]
        int GetAvailableModes([Out] out AMTunerModeType plModes);

        [PreserveSig]
        int RegisterNotificationCallBack(
            [In] IAMTunerNotification pNotify,
            [In] AMTunerEventType lEvents
            );

        [PreserveSig]
        int UnRegisterNotificationCallBack([In] IAMTunerNotification pNotify);
    }

    [Guid("211A8760-03AC-11d1-8D13-00AA00BD8339"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMTunerNotification
    {
        [PreserveSig]
        int OnEvent([In] AMTunerEventType Event);
    }

    [Guid("211A8766-03AC-11d1-8D13-00AA00BD8339"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMTVTuner : IAMTuner
    {
        #region IAMTuner

        [PreserveSig]
        new int put_Channel(
            [In] int lChannel,
            [In] AMTunerSubChannel lVideoSubChannel,
            [In] AMTunerSubChannel lAudioSubChannel
            );

        [PreserveSig]
        new int get_Channel(
            [Out] out int plChannel,
            [Out] out AMTunerSubChannel plVideoSubChannel,
            [Out] out AMTunerSubChannel plAudioSubChannel
            );

        [PreserveSig]
        new int ChannelMinMax(
            [Out] out int lChannelMin,
            [Out] out int lChannelMax
            );

        [PreserveSig]
        new int put_CountryCode([In] int lCountryCode);

        [PreserveSig]
        new int get_CountryCode([Out] out int plCountryCode);

        [PreserveSig]
        new int put_TuningSpace([In] int lTuningSpace);

        [PreserveSig]
        new int get_TuningSpace([Out] out int plTuningSpace);

        [PreserveSig]
        new int Logon([In] IntPtr hCurrentUser); // HANDLE

        [PreserveSig]
        new int Logout();

        [PreserveSig]
        new int SignalPresent([Out] out AMTunerSignalStrength plSignalStrength);

        [PreserveSig]
        new int put_Mode([In] AMTunerModeType lMode);

        [PreserveSig]
        new int get_Mode([Out] out AMTunerModeType plMode);

        [PreserveSig]
        new int GetAvailableModes([Out] out AMTunerModeType plModes);

        [PreserveSig]
        new int RegisterNotificationCallBack(
            [In] IAMTunerNotification pNotify,
            [In] AMTunerEventType lEvents
            );

        [PreserveSig]
        new int UnRegisterNotificationCallBack([In] IAMTunerNotification pNotify);

        #endregion

        [PreserveSig]
        int get_AvailableTVFormats([Out] out AnalogVideoStandard lAnalogVideoStandard);

        [PreserveSig]
        int get_TVFormat([Out] out AnalogVideoStandard lAnalogVideoStandard);

        [PreserveSig]
        int AutoTune(
            [In] int lChannel,
            [Out] out int plFoundSignal
            );

        [PreserveSig]
        int StoreAutoTune();

        [PreserveSig]
        int get_NumInputConnections([Out] out int plNumInputConnections);

        [PreserveSig]
        int put_InputType(
            [In] int lIndex,
            [In] TunerInputType inputType
            );

        [PreserveSig]
        int get_InputType(
            [In] int lIndex,
            [Out] out TunerInputType inputType
            );

        [PreserveSig]
        int put_ConnectInput([In] int lIndex);

        [PreserveSig]
        int get_ConnectInput([Out] out int lIndex);

        [PreserveSig]
        int get_VideoFrequency([Out] out int lFreq);

        [PreserveSig]
        int get_AudioFrequency([Out] out int lFreq);
    }

    [Guid("6a2e0670-28e4-11d0-a18c-00a0c9118956"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMVideoControl
    {
        [PreserveSig]
        int GetCaps(
            [In] IPin pPin,
            [Out] out VideoControlFlags pCapsFlags
            );

        [PreserveSig]
        int SetMode(
            [In] IPin pPin,
            [In] VideoControlFlags Mode
            );

        [PreserveSig]
        int GetMode(
            [In] IPin pPin,
            [Out] out VideoControlFlags Mode
            );

        [PreserveSig]
        int GetCurrentActualFrameRate(
            [In] IPin pPin,
            [Out] out long ActualFrameRate
            );

        [PreserveSig]
        int GetMaxAvailableFrameRate(
            [In] IPin pPin,
            [In] int iIndex,
            [In] Size Dimensions,
            [Out] out long MaxAvailableFrameRate
            );

        [PreserveSig]
        int GetFrameRateList(
            [In] IPin pPin,
            [In] int iIndex,
            [In] Size Dimensions,
            [Out] out int ListSize,
            [Out] out IntPtr FrameRates
            );
    }

    [Guid("C6E13350-30AC-11d0-A18C-00A0C9118956"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMAnalogVideoDecoder
    {
        [PreserveSig]
        int get_AvailableTVFormats([Out] out AnalogVideoStandard lAnalogVideoStandard);

        [PreserveSig]
        int put_TVFormat([In] AnalogVideoStandard lAnalogVideoStandard);

        [PreserveSig]
        int get_TVFormat([Out] out AnalogVideoStandard plAnalogVideoStandard);

        [PreserveSig]
        int get_HorizontalLocked([Out, MarshalAs(UnmanagedType.Bool)] out bool plLocked);

        [PreserveSig]
        int put_VCRHorizontalLocking([In, MarshalAs(UnmanagedType.Bool)] bool lVCRHorizontalLocking);

        [PreserveSig]
        int get_VCRHorizontalLocking([Out, MarshalAs(UnmanagedType.Bool)] out bool plVCRHorizontalLocking);

        [PreserveSig]
        int get_NumberOfLines([Out] out int plNumberOfLines);

        [PreserveSig]
        int put_OutputEnable([In, MarshalAs(UnmanagedType.Bool)] bool lOutputEnable);

        [PreserveSig]
        int get_OutputEnable([Out, MarshalAs(UnmanagedType.Bool)] out bool plOutputEnable);
    }

    [Guid("C6E13360-30AC-11d0-A18C-00A0C9118956"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMVideoProcAmp
    {
        [PreserveSig]
        int GetRange(
            [In] VideoProcAmpProperty Property,
            [Out] out int pMin,
            [Out] out int pMax,
            [Out] out int pSteppingDelta,
            [Out] out int pDefault,
            [Out] out VideoProcAmpFlags pCapsFlags
            );

        [PreserveSig]
        int Set(
            [In] VideoProcAmpProperty Property,
            [In] int lValue,
            [In] VideoProcAmpFlags Flags
            );

        [PreserveSig]
        int Get(
            [In] VideoProcAmpProperty Property,
            [Out] out int lValue,
            [Out] out VideoProcAmpFlags Flags
            );
    }

    [Guid("54C39221-8380-11d0-B3F0-00AA003761C5"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMAudioInputMixer
    {
        [PreserveSig]
        int put_Enable([In, MarshalAs(UnmanagedType.Bool)] bool fEnable);

        [PreserveSig]
        int get_Enable([Out, MarshalAs(UnmanagedType.Bool)] out bool pfEnable);

        [PreserveSig]
        int put_Mono([In, MarshalAs(UnmanagedType.Bool)] bool fMono);

        [PreserveSig]
        int get_Mono([Out, MarshalAs(UnmanagedType.Bool)] out bool pfMono);

        [PreserveSig]
        int put_MixLevel([In] double Level);

        [PreserveSig]
        int get_MixLevel([Out] out double pLevel);

        [PreserveSig]
        int put_Pan([In] double Pan);

        [PreserveSig]
        int get_Pan([Out] out double pPan);

        [PreserveSig]
        int put_Loudness([In, MarshalAs(UnmanagedType.Bool)] bool fLoudness);

        [PreserveSig]
        int get_Loudness([Out, MarshalAs(UnmanagedType.Bool)] out bool pfLoudness);

        [PreserveSig]
        int put_Treble([In] double Treble);

        [PreserveSig]
        int get_Treble([Out] out double pTreble);

        [PreserveSig]
        int get_TrebleRange([Out] out double pRange);

        [PreserveSig]
        int put_Bass([In] double Bass);

        [PreserveSig]
        int get_Bass([Out] out double pBass);

        [PreserveSig]
        int get_BassRange([Out] out double pRange);
    }

    [Guid("670d1d20-a068-11d0-b3f0-00aa003761c5"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMCopyCaptureFileProgress
    {
        [PreserveSig]
        int Progress(int iProgress);
    }

    [Guid("C6E13380-30AC-11d0-A18C-00A0C9118956"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMCrossbar
    {
        [PreserveSig]
        int get_PinCounts(
            [Out] out int OutputPinCount,
            [Out] out int InputPinCount
            );

        [PreserveSig]
        int CanRoute(
            [In] int OutputPinIndex,
            [In] int InputPinIndex
            );

        [PreserveSig]
        int Route(
            [In] int OutputPinIndex,
            [In] int InputPinIndex
            );

        [PreserveSig]
        int get_IsRoutedTo(
            [In] int OutputPinIndex,
            [Out] out int InputPinIndex
            );

        [PreserveSig]
        int get_CrossbarPinInfo(
            [In, MarshalAs(UnmanagedType.Bool)] bool IsInputPin,
            [In] int PinIndex,
            [Out] out int PinIndexRelated,
            [Out] out PhysicalConnectorType PhysicalType
            );
    }

    [Guid("C6E13344-30AC-11d0-A18C-00A0C9118956"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMDroppedFrames
    {
        [PreserveSig]
        int GetNumDropped([Out] out int plDropped);

        [PreserveSig]
        int GetNumNotDropped([Out] out int plNotDropped);

        [PreserveSig]
        int GetDroppedInfo(
            [In] int lSize,
            [Out, MarshalAs(UnmanagedType.LPArray)] out int[] plArray,
            [Out] out int plNumCopied
            );

        [PreserveSig]
        int GetAverageFrameSize([Out] out int plAverageSize);
    }

    [Guid("83EC1C30-23D1-11d1-99E6-00A0C9560266"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMTVAudio
    {
        [PreserveSig]
        int GetHardwareSupportedTVAudioModes([Out] out TVAudioMode plModes);

        [PreserveSig]
        int GetAvailableTVAudioModes([Out] out TVAudioMode plModes);

        [PreserveSig]
        int get_TVAudioMode([Out] out TVAudioMode plMode);

        [PreserveSig]
        int put_TVAudioMode([In] TVAudioMode lMode);

        [PreserveSig]
        int RegisterNotificationCallBack(
            [In] IAMTunerNotification pNotify,
            [In] AMTVAudioEventType lEvents
            );

        [PreserveSig]
        int UnRegisterNotificationCallBack([In] IAMTunerNotification pNotify);
    }

    [Guid("D8D715A3-6E5E-11D0-B3F0-00AA003761C5"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMVfwCompressDialogs
    {
        [PreserveSig]
        int ShowDialog(
            [In] VfwCompressDialogs iDialog,
            [In] IntPtr hwnd 
            );

        [PreserveSig]
        int GetState(
            [In] IntPtr pState,
            [In, Out] ref int pcbState
            );

        [PreserveSig]
        int SetState(
            [In] IntPtr pState,
            [In] int pcbState
            );

        [PreserveSig]
        int SendDriverMessage(
            [In] int uMsg,
            [In] int dw1,
            [In] int dw2
            );
    }

    [Guid("C6E13343-30AC-11d0-A18C-00A0C9118956"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMVideoCompression
    {
        [PreserveSig]
        int put_KeyFrameRate([In] int KeyFrameRate);

        [PreserveSig]
        int get_KeyFrameRate([Out] out int pKeyFrameRate);

        [PreserveSig]
        int put_PFramesPerKeyFrame([In] int PFramesPerKeyFrame);

        [PreserveSig]
        int get_PFramesPerKeyFrame([Out] out int pPFramesPerKeyFrame);

        [PreserveSig]
        int put_Quality([In] double Quality);

        [PreserveSig]
        int get_Quality([Out] out double pQuality);

        [PreserveSig]
        int put_WindowSize([In] long WindowSize);

        [PreserveSig]
        int get_WindowSize([Out] out long pWindowSize);

        [PreserveSig]
        int GetInfo(
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszVersion, // WCHAR *
            [Out] out int pcbVersion,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDescription, // LPWSTR
            [Out] out int pcbDescription,
            [Out] out int pDefaultKeyFrameRate,
            [Out] out int pDefaultPFramesPerKey,
            [Out] out double pDefaultQuality,
            [Out] out CompressionCaps pCapabilities
            );

        [PreserveSig]
        int OverrideKeyFrame([In] int FrameNumber);

        [PreserveSig]
        int OverrideFrameSize(
            [In] int FrameNumber,
            [In] int Size
            );
    }

    [Guid("D8D715A0-6E5E-11D0-B3F0-00AA003761C5"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMVfwCaptureDialogs
    {
        [PreserveSig]
        int HasDialog([In] VfwCaptureDialogs iDialog);

        [PreserveSig]
        int ShowDialog(
            [In] VfwCaptureDialogs iDialog,
            [In] IntPtr hwnd // HWND *
            );

        [PreserveSig]
        int SendDriverMessage(
            [In] VfwCaptureDialogs iDialog,
            [In] int uMsg,
            [In] int dw1,
            [In] int dw2
            );
    }

    [Guid("93E5A4E0-2D50-11d2-ABFA-00A0C9C6E38D"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICaptureGraphBuilder2
    {
        [PreserveSig]
        int SetFiltergraph([In] IGraphBuilder pfg);

        [PreserveSig]
        int GetFiltergraph([Out] out IGraphBuilder ppfg);

        [PreserveSig]
        int SetOutputFileName(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pType,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpstrFile,
            [Out] out IBaseFilter ppbf,
            [Out] out IFileSinkFilter ppSink
            );

        [PreserveSig]
        int FindInterface(
            [In, MarshalAs(UnmanagedType.LPStruct)] DsGuid pCategory,
            [In, MarshalAs(UnmanagedType.LPStruct)] DsGuid pType,
            [In] IBaseFilter pbf,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppint
            );

        [PreserveSig]
        int RenderStream(
            [In, MarshalAs(UnmanagedType.LPStruct)] DsGuid PinCategory,
            [In, MarshalAs(UnmanagedType.LPStruct)] DsGuid MediaType,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pSource,
            [In] IBaseFilter pfCompressor,
            [In] IBaseFilter pfRenderer
            );

        [PreserveSig]
        int ControlStream(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid PinCategory,
            [In, MarshalAs(UnmanagedType.LPStruct)] DsGuid MediaType,
            [In, MarshalAs(UnmanagedType.Interface)] IBaseFilter pFilter,
            [In] DsLong pstart,
            [In] DsLong pstop,
            [In] short wStartCookie,
            [In] short wStopCookie
            );

        [PreserveSig]
        int AllocCapFile(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpstrFile,
            [In] long dwlSize
            );

        [PreserveSig]
        int CopyCaptureFile(
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpwstrOld,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpwstrNew,
            [In, MarshalAs(UnmanagedType.Bool)] bool fAllowEscAbort,
            [In] IAMCopyCaptureFileProgress pFilter
            );

        [PreserveSig]
        int FindPin(
            [In, MarshalAs(UnmanagedType.IUnknown)] object pSource,
            [In] PinDirection pindir,
            [In, MarshalAs(UnmanagedType.LPStruct)] DsGuid PinCategory,
            [In, MarshalAs(UnmanagedType.LPStruct)] DsGuid MediaType,
            [In, MarshalAs(UnmanagedType.Bool)] bool fUnconnected,
            [In] int ZeroBasedIndex,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPin ppPin
            );
    }

    [Guid("C6E13340-30AC-11d0-A18C-00A0C9118956"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAMStreamConfig
    {
        [PreserveSig]
        int SetFormat([In, MarshalAs(UnmanagedType.LPStruct)] AMMediaType pmt);

        [PreserveSig]
        int GetFormat([Out] out AMMediaType pmt);

        [PreserveSig]
        int GetNumberOfCapabilities(out int piCount, out int piSize);

        [PreserveSig]
        int GetStreamCaps(
            [In] int iIndex,
            [Out] out AMMediaType ppmt,
            [In] IntPtr pSCC
            );
    }

    #endregion

}