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

using System;
using UnityEngine;
using KSP.Localization;

namespace FieldTrainingLab
{

<<<<<<< Updated upstream
	/// <summary></summary>
	/// <seealso cref="PartModule" />
	public class FieldTrainingLab : PartModule
	{
		ProtoCrewMember[] crewArr = new ProtoCrewMember[8];
		string[] eventArr = 
		{
			"TrainKerbalInside0",
			"TrainKerbalInside1",
			"TrainKerbalInside2",
			"TrainKerbalInside3",
			"TrainKerbalInside4",
			"TrainKerbalInside5",
			"TrainKerbalInside6",
			"TrainKerbalInside7",
		};

		string[] trainingArr =
		{
			"",
			"Training1",
			"Training2",
			"Training3",
			"Training4",
			"Training5"
		};

		float[] levelUpExpTable = { 2, 6, 8, 16, 32, 0 };

		string[] levelNumber = { "1st", "2nd", "3rd", "4th", "5th", "null"};

		[KSPField]
		public int TrainFactor = 20;

		[KSPField]
		public float inSpace = 0.5f;

		[KSPField]
		public float Landed = 0.25f;

		[KSPField]
		public float TimeFactor = 426 * 6 * 60 * 60; // 1Year = 426day, 1day = 6hour, 1hour = 60minutes, 1min = 60sec

		[KSPField(isPersistant = true, guiActive = true, guiName = "Training Lab Status", groupName = "TrainingLab", groupDisplayName = "Training Lab v" + Version.SText, groupStartCollapsed = true)]
		public bool TrainingStatus = false;

		[KSPField(guiActive = false, guiName = "Science Point", groupName = "TrainingLab", groupDisplayName = "Field Training Lab", groupStartCollapsed = true)]
		public int SciRemain;

		[KSPEvent(guiActive = false, guiName = "Training0", groupName = "TrainingLab")]
		public void TrainKerbalInside0()
		{
			TrainKerbal(0);
		}
		[KSPEvent(guiActive = false, guiName = "Training1", groupName = "TrainingLab")]
		public void TrainKerbalInside1()
		{
			TrainKerbal(1);
		}
		[KSPEvent(guiActive = false, guiName = "Training2", groupName = "TrainingLab")]
		public void TrainKerbalInside2()
		{
			TrainKerbal(2);
		}
		[KSPEvent(guiActive = false, guiName = "Training3", groupName = "TrainingLab")]
		public void TrainKerbalInside3()
		{
			TrainKerbal(3);
		}
		[KSPEvent(guiActive = false, guiName = "Training4", groupName = "TrainingLab")]
		public void TrainKerbalInside4()
		{
			TrainKerbal(4);
		}
		[KSPEvent(guiActive = false, guiName = "Training5", groupName = "TrainingLab")]
		public void TrainKerbalInside5()
		{
			TrainKerbal(5);
		}
		[KSPEvent(guiActive = false, guiName = "Training6", groupName = "TrainingLab")]
		public void TrainKerbalInside6()
		{
			TrainKerbal(6);
		}
		[KSPEvent(guiActive = false, guiName = "Training7", groupName = "TrainingLab")]
		public void TrainKerbalInside7()
		{
			TrainKerbal(7);
		}

		#region private functions
		private void TrainKerbal(int index)
		{
			ProtoCrewMember crew = crewArr[index];

			int lastLog = GetCrewTrainedLevel(crew);

			if (lastLog == 5)
			{
				ScreenMessages.PostScreenMessage(crew.name + " already had every training.");
				return;
			}

			float SciCost = CalculateSciCost(levelUpExpTable[lastLog], crew);
			if (ResearchAndDevelopment.Instance.Science < SciCost)
			{
				ScreenMessages.PostScreenMessage("Insufficient Science Points.\n" + 
					"Needed : " + SciCost + ", Remain : " + ResearchAndDevelopment.Instance.Science);
				return;
			}
			ResearchAndDevelopment.Instance.AddScience(-1 * SciCost, TransactionReasons.CrewRecruited);
			RemoveKerbalTrainingExp(crew);
			crew.flightLog.AddEntry(new FlightLog.Entry(crew.flightLog.Flight, trainingArr[lastLog+1], "Kerbin"));
			ScreenMessages.PostScreenMessage(levelNumber[lastLog] + " Training Complete : " + crew.name);

		}
#endregion

#region public functions
		public override void OnUpdate()
		{
			if (HighLogic.CurrentGame.Mode != Game.Modes.CAREER) return;
=======
<<<<<<< Updated upstream
    /// <summary></summary>
    /// <seealso cref="PartModule" />
    public class FieldTrainingLab : PartModule
    {
        ProtoCrewMember[] crewArr = new ProtoCrewMember[8];
        string[] eventArr = 
        {
            "TrainKerbalInside0",
            "TrainKerbalInside1",
            "TrainKerbalInside2",
            "TrainKerbalInside3",
            "TrainKerbalInside4",
            "TrainKerbalInside5",
            "TrainKerbalInside6",
            "TrainKerbalInside7",
        };

        string[] trainingArr =
        {
            "",
            "Training1",
            "Training2",
            "Training3",
            "Training4",
            "Training5"
        };

        float[] levelUpExpTable = { 2, 6, 8, 16, 32, 0 };

        string[] levelNumber = { "1st", "2nd", "3rd", "4th", "5th", "null"};

        [KSPField]
        public int TrainFactor = 20;

        [KSPField]
        public float inSpace = 0.5f;

        [KSPField]
        public float Landed = 0.25f;

        [KSPField]
        public float TimeFactor = 426 * 6 * 60 * 60; // 1Year = 426day, 1day = 6hour, 1hour = 60minutes, 1min = 60sec

        [KSPField(isPersistant = true, guiActive = true, guiName = "Training Lab Status", groupName = "TrainingLab", groupDisplayName = "Training Lab v" + Version.Text, groupStartCollapsed = true)]
        public bool TrainingStatus = false;

        [KSPField(guiActive = false, guiName = "Science Point", groupName = "TrainingLab", groupDisplayName = "Field Training Lab", groupStartCollapsed = true)]
        public int SciRemain;

        [KSPEvent(guiActive = false, guiName = "Training0", groupName = "TrainingLab")]
        public void TrainKerbalInside0()
        {
            TrainKerbal(0);
        }
        [KSPEvent(guiActive = false, guiName = "Training1", groupName = "TrainingLab")]
        public void TrainKerbalInside1()
        {
            TrainKerbal(1);
        }
        [KSPEvent(guiActive = false, guiName = "Training2", groupName = "TrainingLab")]
        public void TrainKerbalInside2()
        {
            TrainKerbal(2);
        }
        [KSPEvent(guiActive = false, guiName = "Training3", groupName = "TrainingLab")]
        public void TrainKerbalInside3()
        {
            TrainKerbal(3);
        }
        [KSPEvent(guiActive = false, guiName = "Training4", groupName = "TrainingLab")]
        public void TrainKerbalInside4()
        {
            TrainKerbal(4);
        }
        [KSPEvent(guiActive = false, guiName = "Training5", groupName = "TrainingLab")]
        public void TrainKerbalInside5()
        {
            TrainKerbal(5);
        }
        [KSPEvent(guiActive = false, guiName = "Training6", groupName = "TrainingLab")]
        public void TrainKerbalInside6()
        {
            TrainKerbal(6);
        }
        [KSPEvent(guiActive = false, guiName = "Training7", groupName = "TrainingLab")]
        public void TrainKerbalInside7()
        {
            TrainKerbal(7);
        }

        #region private functions
        private void TrainKerbal(int index)
        {
            ProtoCrewMember crew = crewArr[index];

            int lastLog = GetCrewTrainedLevel(crew);

            if (lastLog == 5)
            {
                ScreenMessages.PostScreenMessage(crew.name + " already had every training.");
                return;
            }

            float SciCost = CalculateSciCost(levelUpExpTable[lastLog], crew);
            if (ResearchAndDevelopment.Instance.Science < SciCost)
            {
                ScreenMessages.PostScreenMessage("Insufficient Science Points.\n" + 
                    "Needed : " + SciCost + ", Remain : " + ResearchAndDevelopment.Instance.Science);
                return;
            }
            ResearchAndDevelopment.Instance.AddScience(-1 * SciCost, TransactionReasons.CrewRecruited);
            RemoveKerbalTrainingExp(crew);
            crew.flightLog.AddEntry(new FlightLog.Entry(crew.flightLog.Flight, trainingArr[lastLog+1], "Kerbin"));
            ScreenMessages.PostScreenMessage(levelNumber[lastLog] + " Training Complete : " + crew.name);

        }
#endregion

#region public functions
        public override void OnUpdate()
        {
            if (HighLogic.CurrentGame.Mode != Game.Modes.CAREER) return;
=======
	/// <summary></summary><seealso cref="PartModule" />
	public class FieldTrainingLab : PartModule
	{
        readonly ProtoCrewMember[] crewArr = new ProtoCrewMember[8];
		readonly string[] eventArr = 
		{
			"TrainKerbalInside0",
			"TrainKerbalInside1",
			"TrainKerbalInside2",
			"TrainKerbalInside3",
			"TrainKerbalInside4",
			"TrainKerbalInside5",
			"TrainKerbalInside6",
			"TrainKerbalInside7",
		};

		readonly string[] trainingArr =
		{
			"",
			"Training1",
			"Training2",
			"Training3",
			"Training4",
			"Training5"
		};

		readonly float[] levelUpExpTable = { 2, 6, 8, 16, 32, 0 };

		readonly string[] levelNumber = { Localizer.Format("#FTL-1st"), Localizer.Format("#FTL-2nd"), "#FTL-3rd", Localizer.Format("#FTL-4th"), Localizer.Format("#FTL-5th"), Localizer.Format("#FTL-null") };        // #FTL-1st = 1st		// #FTL-2nd = 2nd		// #FTL-null = null		// #FTL-5th = 5th		// #FTL-4th = 4th		// #FTL-3rd = 3rd

		private const string __GroupName__ = "FieldTrainingLab";

		/// <summary>Train Factor</summary>
		[KSPField]
		public int TrainFactor = 20;

        /// <summary>Space situational cost adjustment</summary>
        [KSPField]
		public float inSpace = 0.5f;

        /// <summary>Landed situational cost adjustment</summary>
        [KSPField]
		public float Landed = 0.25f;

        /// <summary>Time Factor</summary>
        [KSPField]
		public float TimeFactor = 426 * 6 * 60 * 60; // 1Year = 426day, 1day = 6hour, 1hour = 60minutes, 1min = 60sec

        /// <summary>PAW Group Status Label</summary>
        [KSPField(isPersistant = false,  guiActive = true, guiActiveEditor = true, groupStartCollapsed = true,
            guiName = " ",
			groupDisplayName = "Training Lab v" + Version.SText)]
        public string PAWStatus = Localizer.Format("#FTL-nameV", Version.SText);

        /// <summary>Training Lab Status</summary>
        [KSPField(isPersistant = true, guiActive = true, groupName = __GroupName__, guiName = "#FTL-status")]
		public bool TrainingStatus = false;

        /// <summary>Science Points Remaining</summary>
        [KSPField(guiActive = false, groupName = __GroupName__, guiName = "#FTL-funds-sci")]
		public int SciRemain;

        /// <summary>Training 0</summary>
        [KSPEvent(guiActive = false, groupName = __GroupName__, guiName = "#FTL-training-0")]
		public void TrainKerbalInside0()
		{ TrainKerbal(0); }

        /// <summary>Training 1</summary>
        [KSPEvent(guiActive = false, groupName = __GroupName__, guiName = "#FTL-training-1")]
		public void TrainKerbalInside1()
		{ TrainKerbal(1); }

        /// <summary>Training 2</summary>
        [KSPEvent(guiActive = false, groupName = __GroupName__, guiName = "#FTL-training-2")]
		public void TrainKerbalInside2()
		{ TrainKerbal(2); }

        /// <summary>Training 3</summary>
        [KSPEvent(guiActive = false, groupName = __GroupName__, guiName = "#FTL-training-3")]
		public void TrainKerbalInside3()
		{ TrainKerbal(3); }

        /// <summary>Training 4</summary>
        [KSPEvent(guiActive = false, groupName = __GroupName__, guiName = "#FTL-training-4")]
		public void TrainKerbalInside4()
		{ TrainKerbal(4); }

        /// <summary>Training 5</summary>
        [KSPEvent(guiActive = false, groupName = __GroupName__, guiName = "#FTL-training-5")]
		public void TrainKerbalInside5()
		{ TrainKerbal(5); }

        /// <summary>Training 6</summary>
        [KSPEvent(guiActive = false, groupName = __GroupName__, guiName = "#FTL-training-6")]
		public void TrainKerbalInside6()
		{ TrainKerbal(6); }

        /// <summary>Training 7</summary>
        [KSPEvent(guiActive = false, groupName = __GroupName__, guiName = "#FTL-training-7")]
		public void TrainKerbalInside7()
		{ TrainKerbal(7); }

#region private functions
		private void TrainKerbal(int index)
		{
			ProtoCrewMember crew = crewArr[index];

			int lastLog = GetCrewTrainedLevel(crew);

			if (lastLog == 5)
			{
				ScreenMessages.PostScreenMessage(Localizer.Format("FTL-max", crew.name));
				// ScreenMessages.PostScreenMessage(crew.name + " already had every training.");
				return;
			}

			float SciCost = CalculateSciCost(levelUpExpTable[lastLog], crew);
			if (ResearchAndDevelopment.Instance.Science < SciCost)
			{
				ScreenMessages.PostScreenMessage(Localizer.Format("FTL-insufficent", Localizer.Format("#FTL-funds-sci"), SciCost, ResearchAndDevelopment.Instance.Science));
				// ScreenMessages.PostScreenMessage("Insufficient Science Points.\n" + "Needed : " + SciCost + ", Remain : " + ResearchAndDevelopment.Instance.Science);
				return;
			}
			ResearchAndDevelopment.Instance.AddScience(-1 * SciCost, TransactionReasons.CrewRecruited);
			RemoveKerbalTrainingExp(crew);
			crew.flightLog.AddEntry(new FlightLog.Entry(crew.flightLog.Flight, trainingArr[lastLog+1], "Kerbin"));
			ScreenMessages.PostScreenMessage(Localizer.Format("#FTL-complete", levelNumber[lastLog], crew.name));
			// ScreenMessages.PostScreenMessage(levelNumber[lastLog] + " Training Complete : " + crew.name);

		}
#endregion

#region public functions

		/// <summary>OnAwake</summary>
        public override void OnAwake() { base.OnAwake(); }

        /// <summary>OnInactive</summary>
        public override void OnInactive() { base.OnInactive(); }

        /// <summary>OnInitialize</summary>
        public override void OnInitialize() { base.OnInitialize(); }

        /// <summary>OnFixedUpdate</summary>
        public override void OnFixedUpdate()
		{
			base.OnFixedUpdate(); 
			UpdatePAWLabel();
		}
		
        /// <summary>OnUpdate</summary>
        public override void OnUpdate()
		{
			if (HighLogic.CurrentGame.Mode != Game.Modes.CAREER) return;
>>>>>>> Stashed changes
>>>>>>> Stashed changes

			Fields["SciRemain"].guiActive = true;
			SciRemain = (int) ResearchAndDevelopment.Instance.Science;

			int index = 0;
			for (int cnt = 0; cnt < crewArr.Length; cnt++) crewArr[cnt] = null;
			foreach (ProtoCrewMember crew in part.protoModuleCrew)
			{
				if (index >= 8) break;
				int lastLog = GetCrewTrainedLevel(crew);

				crewArr[index] = crew;
				int SciCost = (int) CalculateSciCost(levelUpExpTable[lastLog], crew);

				if (lastLog < 5) Events[eventArr[index]].guiName = "[" + lastLog + "->" + (lastLog + 1) + "] " + crew.name + "[" + SciCost + "p]";
				else Events[eventArr[index]].guiName = "[5]" + crew.name;

				Events[eventArr[index]].guiActive = true;
				index++;
			}

			for(; index < eventArr.Length; index++) Events[eventArr[index]].guiActive = false;
		}


#endregion
<<<<<<< Updated upstream
=======
<<<<<<< Updated upstream
        private int CalculateSciCost(float baseValue, ProtoCrewMember crew)
        {
            double calculated = baseValue * TrainFactor * (1 - (GetKerbalTrainingExp(crew) / (TimeFactor * baseValue / 64)));
            int ret = 0;

            if (this.vessel.mainBody.bodyName == "Kerbin" && this.vessel.LandedOrSplashed) ret = ((int) (calculated + 0.5));
            else if (this.vessel.LandedOrSplashed) ret = ((int) (calculated * Landed + 0.5));
            else ret = ((int)(calculated * inSpace + 0.5));

            if (ret < 1) ret = 1;
            return ret;
        }

        private double GetKerbalTrainingExp(ProtoCrewMember crew)
        {
            string lastExpStr = "0";

            FlightLog totalLog = crew.careerLog.CreateCopy();
            totalLog.MergeWith(crew.flightLog.CreateCopy());
            foreach (FlightLog.Entry entry in totalLog.Entries)
                if (entry.type == "TrainingExp") lastExpStr = entry.target;

            return double.Parse(lastExpStr);
        }

        private void RemoveKerbalTrainingExp(ProtoCrewMember crew)
        {
            foreach (FlightLog.Entry entry in crew.careerLog.Entries.ToArray())
                if (entry.type == "TrainingExp")
                    crew.careerLog.Entries.Remove(entry);
            foreach (FlightLog.Entry entry in crew.flightLog.Entries.ToArray())
                if (entry.type == "TrainingExp")
                    crew.flightLog.Entries.Remove(entry);
        }

        private int GetCrewTrainedLevel(ProtoCrewMember crew)
        {
            int lastLog = 0;
            FlightLog totalLog = crew.careerLog.CreateCopy();
            totalLog.MergeWith(crew.flightLog.CreateCopy());

            int deadFlight = -1;
            foreach (FlightLog.Entry entry in totalLog.Entries)
            {
                if (entry.flight <= deadFlight) continue;
                if (entry.type == "Die") deadFlight = entry.flight;
            }
            foreach (FlightLog.Entry entry in totalLog.Entries)
            {
                if (entry.flight <= deadFlight) continue;
                if (lastLog < 1 && entry.type == "Training1") lastLog = 1;
                if (lastLog < 2 && entry.type == "Training2") lastLog = 2;
                if (lastLog < 3 && entry.type == "Training3") lastLog = 3;
                if (lastLog < 4 && entry.type == "Training4") lastLog = 4;
                if (lastLog < 5 && entry.type == "Training5") lastLog = 5;
            }

            return lastLog;
        }

        /// <summary>Converts consumption rate into /s /m /hour and returns a formate string.</summary>
        /// <param name="Rate">The rate.</param>
        /// <returns>RateString="Rate"</returns>
        private static string RateString(double rate)
        {
            //  double rate = double.Parse(value.value);
            string sfx = "/s";
            if (rate <= 0.004444444f)
            {
                rate *= 3600;
                sfx = "/h";
            }
            else if (rate < 0.2666667f)
            {
                rate *= 60;
                sfx = "/m";
            }
            // limit decimal places to 10 and add sfx
            //return String.Format(FuelRateFormat, Rate, sfx);
            return rate.ToString("###.#####") + " EC" + sfx;
        }
        /// <summary>Module information shown in editors</summary>
        private string info = string.Empty;

        public override string GetInfo()
        {
            //? this is what is show in the editor
            //? As annoying as it is, pre-parsing the config MUST be done here, because this is called during part loading.
            //? The config is only fully parsed after everything is fully loaded (which is why it's in OnStart())
            if (info == string.Empty)
            {
                info += Localizer.Format("#FTL-manu"); // #FTL-manu = Kerbalnaut Training Industries, Inc.
                info += "\n v" + Version.SText; // FTL Version Number text
                info += "\n<color=#b4d455FF>" + Localizer.Format("#FTL-desc"); // #FTL-desc = Train Kerbals using Science Points
            }
            // #autoLOC_252004 = ElectricCharge
            // #FieldTrainingFacility_titl = FieldTrainingFacility
            // #FTL-manu = Kerbalnaut Training Industries, Inc.
            // #FTL-desc = Train Kerbals using time and Electric Charge
            return info;
        }
    }
=======
		
		/// <summary>Calculate Science Cost</summary>
		/// <param name="baseValue"></param>
		/// <param name="crew"></param>
		/// <returns></returns>
>>>>>>> Stashed changes
		private int CalculateSciCost(float baseValue, ProtoCrewMember crew)
		{
			double calculated = baseValue * TrainFactor * (1 - (GetKerbalTrainingExp(crew) / (TimeFactor * baseValue / 64)));
			int ret = 0;

			if (this.vessel.mainBody.bodyName == "Kerbin" && this.vessel.LandedOrSplashed) ret = ((int) (calculated + 0.5));
			else if (this.vessel.LandedOrSplashed) ret = ((int) (calculated * Landed + 0.5));
			else ret = ((int)(calculated * inSpace + 0.5));

			if (ret < 1) ret = 1;
			return ret;
		}

<<<<<<< Updated upstream
		private double GetKerbalTrainingExp(ProtoCrewMember crew)
=======
        /// <summary>GetKerbalTrainingExp</summary>
        /// <param name="crew"></param>
        /// <returns></returns>
        private double GetKerbalTrainingExp(ProtoCrewMember crew)
>>>>>>> Stashed changes
		{
			string lastExpStr = "0";

			FlightLog totalLog = crew.careerLog.CreateCopy();
			totalLog.MergeWith(crew.flightLog.CreateCopy());
			foreach (FlightLog.Entry entry in totalLog.Entries)
				if (entry.type == "TrainingExp") lastExpStr = entry.target;

			return double.Parse(lastExpStr);
		}

<<<<<<< Updated upstream
		private void RemoveKerbalTrainingExp(ProtoCrewMember crew)
=======
        /// <summary>RemoveKerbalTrainingExp</summary>
        /// <param name="crew"></param>
        private void RemoveKerbalTrainingExp(ProtoCrewMember crew)
>>>>>>> Stashed changes
		{
			foreach (FlightLog.Entry entry in crew.careerLog.Entries.ToArray())
				if (entry.type == "TrainingExp")
					crew.careerLog.Entries.Remove(entry);
			foreach (FlightLog.Entry entry in crew.flightLog.Entries.ToArray())
				if (entry.type == "TrainingExp")
					crew.flightLog.Entries.Remove(entry);
		}

<<<<<<< Updated upstream
		private int GetCrewTrainedLevel(ProtoCrewMember crew)
=======
        /// <summary>GetCrewTrainedLevel</summary>
        /// <param name="crew"></param>
        /// <returns></returns>
        private int GetCrewTrainedLevel(ProtoCrewMember crew)
>>>>>>> Stashed changes
		{
			int lastLog = 0;
			FlightLog totalLog = crew.careerLog.CreateCopy();
			totalLog.MergeWith(crew.flightLog.CreateCopy());

			int deadFlight = -1;
			foreach (FlightLog.Entry entry in totalLog.Entries)
			{
				if (entry.flight <= deadFlight) continue;
				if (entry.type == "Die") deadFlight = entry.flight;
			}
			foreach (FlightLog.Entry entry in totalLog.Entries)
			{
				if (entry.flight <= deadFlight) continue;
				if (lastLog < 1 && entry.type == "Training1") lastLog = 1;
				if (lastLog < 2 && entry.type == "Training2") lastLog = 2;
				if (lastLog < 3 && entry.type == "Training3") lastLog = 3;
				if (lastLog < 4 && entry.type == "Training4") lastLog = 4;
				if (lastLog < 5 && entry.type == "Training5") lastLog = 5;
			}

			return lastLog;
		}

<<<<<<< Updated upstream
		/// <summary>Converts consumption rate into /s /m /hour and returns a formate string.</summary>
		/// <param name="Rate">The rate.</param>
		/// <returns>RateString="Rate"</returns>
=======
       /// <summary><para>Updates the PAW label.</para></summary>
        internal void UpdatePAWLabel() // private
        {
            string begStr = String.Empty;
            string endStr = String.Empty;

            if (HighLogic.CurrentGame.Parameters.CustomParams<FTL_Options>().coloredPAW)
            {
				begStr = "<b><#FEDD00>"; // banana
                endStr = "</color></b>";
            }

            switch (HighLogic.LoadedScene)
            {
                case GameScenes.FLIGHT:
                    {
                        PAWStatus = begStr + Localizer.Format("FTL-nameV", Version.SText) + endStr;
                        break;
                    }
                case GameScenes.EDITOR:
                    {
                        PAWStatus = begStr + Localizer.Format("FTL-nameV", Version.SText) + endStr;
                        break;
                    }
/*                case GameScenes.LOADING:
                    break;
                case GameScenes.LOADINGBUFFER:
                    break;
                case GameScenes.MAINMENU:
                    break;
                case GameScenes.SETTINGS:
                    break;
                case GameScenes.CREDITS:
                    break;
                case GameScenes.SPACECENTER:
                    break;
                case GameScenes.TRACKSTATION:
                    break;
                case GameScenes.PSYSTEM:
                    break;
                case GameScenes.MISSIONBUILDER:
                    break;
                default:
                    break;*/
            }
        }

		/// <summary>Converts consumption rate into /s /m /hour and returns a formate string.</summary>
		/// <param name="Rate">The rate.</param><returns>RateString="Rate"</returns>
>>>>>>> Stashed changes
		private static string RateString(double rate)
		{
			//  double rate = double.Parse(value.value);
			string sfx = "/s";
			if (rate <= 0.004444444f)
			{
				rate *= 3600;
				sfx = "/h";
			}
			else if (rate < 0.2666667f)
			{
				rate *= 60;
				sfx = "/m";
			}
			// limit decimal places to 10 and add sfx
			//return String.Format(FuelRateFormat, Rate, sfx);
			return rate.ToString("###.#####") + " EC" + sfx;
		}
<<<<<<< Updated upstream
		/// <summary>Module information shown in editors</summary>
		private string info = string.Empty;

		public override string GetInfo()
		{
			//? this is what is show in the editor
			//? As annoying as it is, pre-parsing the config MUST be done here, because this is called during part loading.
			//? The config is only fully parsed after everything is fully loaded (which is why it's in OnStart())
			if (info == string.Empty)
			{
				info += Localizer.Format("#FTL-Agency-titl"); // #FTF-manu = Kerbalnaut Training Industries, Inc.
				info += "\n v" + Version.SText; // FTL Version Number text
				info += "\n<color=#b4d455FF>" + Localizer.Format("#FTL-desc"); // #FTL-desc = Train Kerbals using Science Points
			}
			// #autoLOC_252004 = ElectricCharge
			// #FieldTrainingFacility_titl = FieldTrainingFacility
			// #FTL-manu = Kerbalnaut Training Industries, Inc.
			// #FTL-desc = Train Kerbals using time and Electric Charge
			return info;
		}
	}
=======

		/// <summary>Module information shown in editors</summary>
		private string info = string.Empty;

		/// <summary>create the GetInfo string</summary>
		public override string GetInfo()
		{
			if (info == string.Empty)
			{
				info += Localizer.Format("#FTL-Agency-titl");
                info += "\n" + Localizer.Format("#FTL-Agency-desc") + "\n";
                info += "\n" + Localizer.Format("#FTL-nameV", Version.SText);
				info += "\n<color=#b4d455FF>" + Localizer.Format("#FTL-desc");
				info += "</color>\n\n";
			}
			// #FTL-Agency-titl = Kerbalnaut Training Industries, Inc.
			// #FTL-Agency-decr = For all your hero training needs!
			// #FTL-nameV = Field Training Lab v#.#.#.#
			// #FTL-desc = Train Kerbals using Science Points
			return info;
			// #autoLOC_252004 = ElectricCharge
		}
	}
>>>>>>> Stashed changes
>>>>>>> Stashed changes
}
