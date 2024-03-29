﻿//22
// 
// This code was generated by a tool. Any changes made manually will be lost
// the next time this code is regenerated.
// 
/* Field Training Lab (FTL)
 * This addon adds a training center in the science laboratory. Paying science points gets kerbals experience. For Kerbal Space Program.
 * Copyright (C) 2016 Efour
 * Copyright (C) 2019, 2022, 2023 zer0Kerbal (zer0Kerbal at hotmail dot com)
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using System.Reflection;

[assembly: AssemblyFileVersion("1.2.2.22")]
[assembly: AssemblyVersion("1.2.2.0")]
[assembly: AssemblyInformationalVersion("1.2.2")]
[assembly: KSPAssembly("FieldTrainingLab", 1,2,2)]

namespace FieldTrainingLab
{
	/// <summary>Version - retrieved at compile from FieldTrainingLab.version</summary>
	public static class Version
	{
		/// <summary>Major revision</summary>
		public const int major = 1;
		/// <summary>Minor revision</summary>
		public const int minor = 2;
		/// <summary>Patch revision</summary>
		public const int patch = 2;
		/// <summary>Build revision</summary>
		public const int build = 0;
		/// <summary>Version String const</summary>
		public const string Number = "1.2.2.0";
#if DEBUG
		/// <summary>Debug Version String const</summary>
        public const string Text = Number + "-zed'K BETA DEBUG";
		/// <summary>Debug SVersion String const</summary>
        public const string SText = Number + "-zed'K BETA DEBUG";
#else
		/// <summary>Text Version String const</summary>
        public const string Text = Number + "-zed'K";
		/// <summary>Plain Text Version String const</summary>
		public const string SText = Number;
#endif
	}
}