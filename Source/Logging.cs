using System;
using System.Diagnostics;


namespace FieldTrainingLab

{
    public static class Log
	{

		public enum LEVEL
		{
			OFF = 0,
			ERROR = 1,
			WARNING = 2,
			INFO = 3,
			DETAIL = 4,
			TRACE = 5}

		;

		public  static LEVEL level = LEVEL.INFO;


		public static LEVEL GetLevel ()
		{
			return level;
		}

		public static void SetLevel (LEVEL level)
		{
			UnityEngine.Debug.Log ("log level " + level);
			Log.level = level;
		}

		public static LEVEL GetLogLevel ()
		{
			return level;
		}

		private static bool IsLevel (LEVEL level)
		{
			return level == Log.level;
		}

		public static bool IsLogable (LEVEL level)
		{
			return level <= Log.level;
		}

		public static void Trace (String msg)
		{
			if (IsLogable (LEVEL.TRACE)) {
				UnityEngine.Debug.Log (Constants.MODNAME+ ": " + msg);
			}
		}

		public static void Detail (String msg)
		{
			if (IsLogable (LEVEL.DETAIL)) {
				UnityEngine.Debug.Log (Constants.MODNAME+ ": " + msg);
			}
		}

		[ConditionalAttribute ("DEBUG")]
		public static void Info (String msg)
		{
			if (IsLogable (LEVEL.INFO)) {
				
				UnityEngine.Debug.Log (Constants.MODNAME + ": " + msg);
			}
		}

		[ConditionalAttribute ("DEBUG")]
		public static void Test (String msg)
		{
			//if (IsLogable(LEVEL.INFO))
			{
				UnityEngine.Debug.LogWarning (Constants.MODNAME + " TEST:" + msg);
			}
		}


		public static void Warning (String msg)
		{
			if (IsLogable (LEVEL.WARNING)) {
				UnityEngine.Debug.LogWarning (Constants.MODNAME+ ": " + msg);
			}
		}

		public static void Error (String msg)
		{
			if (IsLogable (LEVEL.ERROR)) {
				UnityEngine.Debug.LogError (Constants.MODNAME+ ": " + msg);
			}
		}

		public static void Exception (Exception e)
		{
			Log.Error ("exception caught: " + e.GetType () + ": " + e.Message);
		}

	}
}
