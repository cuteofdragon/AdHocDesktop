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
using System.Runtime.InteropServices;

namespace Microsoft.DirectX.DirectShow.BDA
{

	#region Declarations

#if ALLOW_UNTESTED_INTERFACES

	/// <summary>
	/// From EnTvRat_System
	/// </summary>
	public enum EnTvRat_System
	{
		MPAA = 0,
		US_TV = 1,
		Canadian_English = 2,
		Canadian_French = 3,
		Reserved4 = 4,
		System5 = 5,
		System6 = 6,
		Reserved7 = 7,
		TvRat_kSystems = 8,
		TvRat_SystemDontKnow = 255
	}

	/// <summary>
	/// From EnTvRat_GenericLevel
	/// </summary>
	public enum EnTvRat_GenericLevel
	{
		TvRat_0 = 0,
		TvRat_1 = 1,
		TvRat_2 = 2,
		TvRat_3 = 3,
		TvRat_4 = 4,
		TvRat_5 = 5,
		TvRat_6 = 6,
		TvRat_7 = 7,
		TvRat_kLevels = 8,
		TvRat_LevelDontKnow = 255
	}

	/// <summary>
	/// From EnTvRat_MPAA
	/// </summary>
	public enum EnTvRat_MPAA
	{
		MPAA_NotApplicable = EnTvRat_GenericLevel.TvRat_0,
		MPAA_G = EnTvRat_GenericLevel.TvRat_1,
		MPAA_PG = EnTvRat_GenericLevel.TvRat_2,
		MPAA_PG13 = EnTvRat_GenericLevel.TvRat_3,
		MPAA_R = EnTvRat_GenericLevel.TvRat_4,
		MPAA_NC17 = EnTvRat_GenericLevel.TvRat_5,
		MPAA_X = EnTvRat_GenericLevel.TvRat_6,
		MPAA_NotRated = EnTvRat_GenericLevel.TvRat_7
	}

	/// <summary>
	/// From EnTvRat_US_TV
	/// </summary>
	public enum EnTvRat_US_TV
	{
		US_TV_None = EnTvRat_GenericLevel.TvRat_0,
		US_TV_Y = EnTvRat_GenericLevel.TvRat_1,
		US_TV_Y7 = EnTvRat_GenericLevel.TvRat_2,
		US_TV_G = EnTvRat_GenericLevel.TvRat_3,
		US_TV_PG = EnTvRat_GenericLevel.TvRat_4,
		US_TV_14 = EnTvRat_GenericLevel.TvRat_5,
		US_TV_MA = EnTvRat_GenericLevel.TvRat_6,
		US_TV_None7 = EnTvRat_GenericLevel.TvRat_7
	}

	/// <summary>
	/// From EnTvRat_CAE_TV
	/// </summary>
	public enum EnTvRat_CAE_TV
	{
		CAE_TV_Exempt = EnTvRat_GenericLevel.TvRat_0,
		CAE_TV_C = EnTvRat_GenericLevel.TvRat_1,
		CAE_TV_C8 = EnTvRat_GenericLevel.TvRat_2,
		CAE_TV_G = EnTvRat_GenericLevel.TvRat_3,
		CAE_TV_PG = EnTvRat_GenericLevel.TvRat_4,
		CAE_TV_14 = EnTvRat_GenericLevel.TvRat_5,
		CAE_TV_18 = EnTvRat_GenericLevel.TvRat_6,
		CAE_TV_Reserved = EnTvRat_GenericLevel.TvRat_7
	}

	/// <summary>
	/// From EnTvRat_CAF_TV
	/// </summary>
	public enum EnTvRat_CAF_TV
	{
		CAF_TV_Exempt = EnTvRat_GenericLevel.TvRat_0,
		CAF_TV_G = EnTvRat_GenericLevel.TvRat_1,
		CAF_TV_8 = EnTvRat_GenericLevel.TvRat_2,
		CAF_TV_13 = EnTvRat_GenericLevel.TvRat_3,
		CAF_TV_16 = EnTvRat_GenericLevel.TvRat_4,
		CAF_TV_18 = EnTvRat_GenericLevel.TvRat_5,
		CAF_TV_Reserved6 = EnTvRat_GenericLevel.TvRat_6,
		CAF_TV_Reserved = EnTvRat_GenericLevel.TvRat_7
	}

	/// <summary>
	/// From BfEnTvRat_GenericAttributes
	/// </summary>
	[Flags]
	public enum BfEnTvRat_GenericAttributes
	{
		BfAttrNone = 0,
		BfIsBlocked = 1,
		BfIsAttr_1 = 2,
		BfIsAttr_2 = 4,
		BfIsAttr_3 = 8,
		BfIsAttr_4 = 16,
		BfIsAttr_5 = 32,
		BfIsAttr_6 = 64,
		BfIsAttr_7 = 128,
		BfValidAttrSubmask = 255
	}

	/// <summary>
	/// From BfEnTvRat_Attributes_US_TV
	/// </summary>
	[Flags]
	public enum BfEnTvRat_Attributes_US_TV
	{
		US_TV_IsBlocked = BfEnTvRat_GenericAttributes.BfIsBlocked,
		US_TV_IsViolent = BfEnTvRat_GenericAttributes.BfIsAttr_1,
		US_TV_IsSexualSituation = BfEnTvRat_GenericAttributes.BfIsAttr_2,
		US_TV_IsAdultLanguage = BfEnTvRat_GenericAttributes.BfIsAttr_3,
		US_TV_IsSexuallySuggestiveDialog = BfEnTvRat_GenericAttributes.BfIsAttr_4,
		US_TV_ValidAttrSubmask = 31
	}

	/// <summary>
	/// From BfEnTvRat_Attributes_MPAA
	/// </summary>
	[Flags]
	public enum BfEnTvRat_Attributes_MPAA
	{
		MPAA_IsBlocked = BfEnTvRat_GenericAttributes.BfIsBlocked,
		MPAA_ValidAttrSubmask = 1
	}

	/// <summary>
	/// From BfEnTvRat_Attributes_CAE_TV
	/// </summary>
	[Flags]
	public enum BfEnTvRat_Attributes_CAE_TV
	{
		CAE_IsBlocked = BfEnTvRat_GenericAttributes.BfIsBlocked,
		CAE_ValidAttrSubmask = 1
	}

	/// <summary>
	/// From BfEnTvRat_Attributes_CAF_TV
	/// </summary>
	[Flags]
	public enum BfEnTvRat_Attributes_CAF_TV
	{
		CAF_IsBlocked = BfEnTvRat_GenericAttributes.BfIsBlocked,
		CAF_ValidAttrSubmask = 1
	}


	[ComImport, Guid("C5C5C5F0-3ABC-11D6-B25B-00C04FA0C026")]
	public class XDSToRat
	{
	}

	[ComImport, Guid("C5C5C5F1-3ABC-11D6-B25B-00C04FA0C026")]
	public class EvalRat
	{
	}
#endif

	#endregion

	#region Interfaces

#if ALLOW_UNTESTED_INTERFACES

	[Guid("C5C5C5B0-3ABC-11D6-B25B-00C04FA0C026"),
		InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXDSToRat
	{
		[PreserveSig, DispId(1)]
		int Init();

		[PreserveSig, DispId(2)]
		int ParseXDSBytePair(
			[In] byte byte1,
			[In] byte byte2,
			[Out] out EnTvRat_System pEnSystem,
			[Out] out EnTvRat_GenericLevel pEnLevel,
			[Out] BfEnTvRat_GenericAttributes plBfEnAttributes
			);
	}

	[Guid("C5C5C5B1-3ABC-11D6-B25B-00C04FA0C026"),
		InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IEvalRat
	{
		[PreserveSig, DispId(1)]
		int get_BlockedRatingAttributes(
			[In] EnTvRat_System enSystem,
			[In] EnTvRat_GenericLevel enLevel,
			[Out] out BfEnTvRat_GenericAttributes plbfAttrs
			);

		[PreserveSig, DispId(1)]
		int put_BlockedRatingAttributes(
			[In] EnTvRat_System enSystem,
			[In] EnTvRat_GenericLevel enLevel,
			[In] BfEnTvRat_GenericAttributes plbfAttrs
			);

		[PreserveSig, DispId(2)]
		int get_BlockUnRated([Out, MarshalAs(UnmanagedType.Bool)] out bool pfBlockUnRatedShows);

		[PreserveSig, DispId(2)]
		int put_BlockUnRated([In, MarshalAs(UnmanagedType.Bool)] bool pfBlockUnRatedShows);

		[PreserveSig, DispId(3)]
		int MostRestrictiveRating(
			[In] EnTvRat_System enSystem1,
			[In] EnTvRat_GenericLevel enEnLevel1,
			[In] BfEnTvRat_GenericAttributes lbfEnAttr1,
			[In] EnTvRat_System enSystem2,
			[In] EnTvRat_GenericLevel enEnLevel2,
			[In] BfEnTvRat_GenericAttributes lbfEnAttr2,
			[Out] out EnTvRat_System penSystem,
			[Out] out EnTvRat_GenericLevel penEnLevel,
			[Out] out BfEnTvRat_GenericAttributes plbfEnAttr
			);

		[PreserveSig, DispId(4)]
		int TestRating(
			[In] EnTvRat_System enShowSystem,
			[In] EnTvRat_GenericLevel enShowLevel,
			[In] BfEnTvRat_GenericAttributes lbfEnShowAttributes
			);
	}

#endif

	#endregion
}