/* Field Training Lab (FTL)
 * This addon adds a training center in the science laboratory. Paying science points gets kerbals experience. For Kerbal Space Program.
 * Copyright (C) 2016 EFour
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

using System.Text;

using FieldTrainingLab;
using KSP.Localization;

public class Constants
{
    public const string MODNAME = "#FTL-addon-nameFolder";		// #FTL-addon-nameFolder = FieldTrainingLab
    public const string MODTITLE = "#FTL-addon-name";		// #FTL-addon-name = Field Training Lab
    public static readonly string ROOT_PATH = KSPUtil.ApplicationRootPath;
    public static readonly string CONFIG_BASE_FOLDER = ROOT_PATH + "GameData/";
    public static string FTL_BASE_FOLDER { get { return CONFIG_BASE_FOLDER + MODNAME + "/"; } }
    public static string FTL_NODENAME = MODNAME;
    public string FTL_CFG_FILE { get { return FTL_BASE_FOLDER + "PluginData/settings.ftl"; } }
    //public string FTL_CFG_FILE { get { return FTL_BASE_FOLDER + "PluginData/FTL_Settings.cfg"; } }
}
