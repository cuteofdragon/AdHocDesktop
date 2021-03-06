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

    public enum AspectRatioMode
    {
        Stretched,
        LetterBox,
        Crop,
        StretchedAsPrimary
    }

    /// <summary>
    /// From DDCOLOR_* defines
    /// </summary>
    [Flags]
    public enum DDColor
    {
        Brightness =              0x00000001,
        Contrast =               0x00000002,
        Hue =                    0x00000004,
        Saturation =            0x00000008,
        Sharpness =             0x00000010,
        Gamma =                 0x00000020,
        ColorEnable =           0x00000040
    }

    /// <summary>
    /// From DDCOLORCONTROL
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DDColorControl
    {
        int  dwSize;
        DDColor  dwFlags;
        int  lBrightness;
        int  lContrast;
        int  lHue;
        int  lSaturation;
        int  lSharpness;
        int  lGamma;
        int  lColorEnable;
        int  dwReserved1;
    }
    
    #endif

    #endregion

    #region Interfaces

#if ALLOW_UNTESTED_INTERFACES

    [Guid("593CDDE1-0759-11d1-9E69-00C04FD7C15B"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMixerPinConfig
    {
        [PreserveSig]
        int SetRelativePosition(
            int dwLeft,
            int dwTop,
            int dwRight,
            int dwBottom);    

        [PreserveSig]
        int GetRelativePosition(
            out int pdwLeft,
            out int pdwTop,
            out int pdwRight,
            out int pdwBottom
            );

        [PreserveSig]
        int SetZOrder(
            int dwZOrder
            );

        [PreserveSig]
        int GetZOrder(
            out int pdwZOrder
            );

        [PreserveSig]
        int SetColorKey(
            ColorKey pColorKey
            );

        [PreserveSig]
        int GetColorKey(
            out ColorKey pColorKey,
            out int pColor
            );

        [PreserveSig]
        int SetBlendingParameter(
            int dwBlendingParameter
            );

        [PreserveSig]
        int GetBlendingParameter(
            out int pdwBlendingParameter
            );

        [PreserveSig]
        int SetAspectRatioMode(
            AspectRatioMode amAspectRatioMode
            );

        [PreserveSig]
        int GetAspectRatioMode(
            out AspectRatioMode pamAspectRatioMode
            );

        [PreserveSig]
        int SetStreamTransparent(
            [In, MarshalAs(UnmanagedType.Bool)] bool bStreamTransparent
            );

        [PreserveSig]
        int GetStreamTransparent(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbStreamTransparent
            );
    }


    [Guid("EBF47182-8764-11d1-9E69-00C04FD7C15B"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMixerPinConfig2 : IMixerPinConfig
    {
        #region IMixerPinConfig Methods

        [PreserveSig]
        new int SetRelativePosition(
            int dwLeft,
            int dwTop,
            int dwRight,
            int dwBottom);    

        [PreserveSig]
        new int GetRelativePosition(
            out int pdwLeft,
            out int pdwTop,
            out int pdwRight,
            out int pdwBottom
            );

        [PreserveSig]
        new int SetZOrder(
            int dwZOrder
            );

        [PreserveSig]
        new int GetZOrder(
            out int pdwZOrder
            );

        [PreserveSig]
        new int SetColorKey(
            ColorKey pColorKey
            );

        [PreserveSig]
        new int GetColorKey(
            out ColorKey pColorKey,
            out int pColor
            );

        [PreserveSig]
        new int SetBlendingParameter(
            int dwBlendingParameter
            );

        [PreserveSig]
        new int GetBlendingParameter(
            out int pdwBlendingParameter
            );

        [PreserveSig]
        new int SetAspectRatioMode(
            AspectRatioMode amAspectRatioMode
            );

        [PreserveSig]
        new int GetAspectRatioMode(
            out AspectRatioMode pamAspectRatioMode
            );

        [PreserveSig]
        new int SetStreamTransparent(
            [In, MarshalAs(UnmanagedType.Bool)] bool bStreamTransparent
            );

        [PreserveSig]
        new int GetStreamTransparent(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbStreamTransparent
            );

        #endregion

        [PreserveSig]
        int SetOverlaySurfaceColorControls(
            DDColorControl pColorControl
            );

        [PreserveSig]
        int GetOverlaySurfaceColorControls(
            out DDColorControl pColorControl
            );
    }
#endif

    #endregion
}
