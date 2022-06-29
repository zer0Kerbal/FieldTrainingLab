using System.Text;

using FieldTrainingLab;

public class Constants
{
    public const string MODNAME = "FieldTrainingLab";
    public const string MODTITLE = "Field Training Lab";
    public static readonly string ROOT_PATH = KSPUtil.ApplicationRootPath;
    public static readonly string CONFIG_BASE_FOLDER = ROOT_PATH + "GameData/";
    public static string FTL_BASE_FOLDER { get { return CONFIG_BASE_FOLDER + MODNAME + "/"; } }
    public static string FTL_NODENAME = MODNAME;
    public string FTL_CFG_FILE { get { return FTL_BASE_FOLDER + "PluginData/FTL_Settings.cfg"; } }
}
