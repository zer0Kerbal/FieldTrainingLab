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

using System;
using UnityEngine;
using KSP.Localization;

namespace FieldTrainingLab
{
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

		/// <summary>Training Lab Status</summary>
		[KSPField(isPersistant = true, guiActive = true, groupStartCollapsed = true, groupName = __GroupName__, guiName = "#FTL-status")]
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
				ScreenMessages.PostScreenMessage(Localizer.Format("#FTL-max", crew.name));
				// ScreenMessages.PostScreenMessage(crew.name + " already had every training.");
				return;
			}

			float SciCost = CalculateSciCost(levelUpExpTable[lastLog], crew);
			if (ResearchAndDevelopment.Instance.Science < SciCost)
			{
				ScreenMessages.PostScreenMessage(Localizer.Format("#FTL-insufficent", Localizer.Format("#FTL-funds-sci"), SciCost, ResearchAndDevelopment.Instance.Science));
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

		/// <summary>OnStart</summary>
		public override void OnStart(StartState state)
		{
			base.OnStart(state);

			if (HighLogic.CurrentGame.Parameters.CustomParams<FTL_Options>().coloredPAW)
				Fields["TrainingStatus"].group.displayName = System.String.Format("<color=#FEDD00>" + Localizer.Format("#FTL-nameV", Version.SText) + "</color>");
			else
				Fields["TrainingStatus"].group.displayName = Localizer.Format("#FTL-nameV", Version.SText);
		}

		/// <summary>OnInactive</summary>
		public override void OnInactive() { base.OnInactive(); }

		/// <summary>OnInitialize</summary>
		public override void OnInitialize() { base.OnInitialize(); }

		/// <summary>OnFixedUpdate</summary>
		public override void OnFixedUpdate()
		{ base.OnFixedUpdate(); }
		
		/// <summary>OnUpdate</summary>
		public override void OnUpdate()
		{
			if (HighLogic.CurrentGame.Mode != Game.Modes.CAREER) return;
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
		
		/// <summary>Calculate Science Cost</summary>
		/// <param name="baseValue"></param>
		/// <param name="crew"></param>
		/// <returns></returns>
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

		/// <summary>GetKerbalTrainingExp</summary>
		/// <param name="crew"></param>
		/// <returns></returns>
		private double GetKerbalTrainingExp(ProtoCrewMember crew)
		{
			string lastExpStr = "0";

			FlightLog totalLog = crew.careerLog.CreateCopy();
			totalLog.MergeWith(crew.flightLog.CreateCopy());
			foreach (FlightLog.Entry entry in totalLog.Entries)
				if (entry.type == "TrainingExp") lastExpStr = entry.target;

			return double.Parse(lastExpStr);
		}

		/// <summary>RemoveKerbalTrainingExp</summary>
		/// <param name="crew"></param>
		private void RemoveKerbalTrainingExp(ProtoCrewMember crew)
		{
			foreach (FlightLog.Entry entry in crew.careerLog.Entries.ToArray())
				if (entry.type == "TrainingExp")
					crew.careerLog.Entries.Remove(entry);
			foreach (FlightLog.Entry entry in crew.flightLog.Entries.ToArray())
				if (entry.type == "TrainingExp")
					crew.flightLog.Entries.Remove(entry);
		}

		/// <summary>GetCrewTrainedLevel</summary>
		/// <param name="crew"></param>
		/// <returns></returns>
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

		/// <summary>Module information shown in editors</summary>
		private string info = string.Empty;

		/// <summary>create the GetInfo string</summary>
		public override string GetInfo()
		{
			if (info == string.Empty)
			{
				info += Localizer.Format("#FTL-Agency-titl");
				info += "\n\n<color=#FEDD00>" + Localizer.Format("#FTL-Agency-desc") + "\n";
				info += "\n" + Localizer.Format("#FTL-nameV", Version.SText);
				info += "\n<color=#B4D455>" + Localizer.Format("#FTL-desc");
				info += "</color>\n\n";
			}
			// #FTL-Agency-titl = Kerbalnaut Training Industries, Inc.
			// #FTL-Agency-decr = For all your hero training needs!
			// #FTL-nameV = Field Training Lab v#.#.#.#
			// #FTL-desc = Train Kerbals using Science Points
			return info;
		}
	}
}
