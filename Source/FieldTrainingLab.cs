
using UnityEngine;
namespace FieldTrainingLab
{

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

        [KSPField(isPersistant = true, guiActive = true, guiName = "Training Lab Status", groupName = "TrainingLab", groupDisplayName = "Training Lab", groupStartCollapsed = true)]
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

            int lastLog = getCrewTrainedLevel(crew);

            if (lastLog == 5)
            {
                ScreenMessages.PostScreenMessage(crew.name + " already had every training.");
                return;
            }

            float SciCost = calculateSciCost(levelUpExpTable[lastLog], crew);
            if (ResearchAndDevelopment.Instance.Science < SciCost)
            {
                ScreenMessages.PostScreenMessage("Insufficient Science Points.\n" + 
                    "Needed : " + SciCost + ", Remain : " + ResearchAndDevelopment.Instance.Science);
                return;
            }
            ResearchAndDevelopment.Instance.AddScience(-1 * SciCost, TransactionReasons.CrewRecruited);
            removeKerbalTrainingExp(crew);
            crew.flightLog.AddEntry(new FlightLog.Entry(crew.flightLog.Flight, trainingArr[lastLog+1], "Kerbin"));
            ScreenMessages.PostScreenMessage(levelNumber[lastLog] + " Training Complete : " + crew.name);

        }
#endregion

#region public functions
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
                int lastLog = getCrewTrainedLevel(crew);

                crewArr[index] = crew;
                int SciCost = (int) calculateSciCost(levelUpExpTable[lastLog], crew);

                if (lastLog < 5) Events[eventArr[index]].guiName = "[" + lastLog + "->" + (lastLog + 1) + "] " + crew.name + "[" + SciCost + "p]";
                else Events[eventArr[index]].guiName = "[5]" + crew.name;

                Events[eventArr[index]].guiActive = true;
                index++;
            }

            for(; index < eventArr.Length; index++) Events[eventArr[index]].guiActive = false;
        }


#endregion
        private int calculateSciCost(float baseValue, ProtoCrewMember crew)
        {
            double calculated = baseValue * TrainFactor * (1 - (getKerbalTrainingExp(crew) / (TimeFactor * baseValue / 64)));
            int ret = 0;

            if (this.vessel.mainBody.bodyName == "Kerbin" && this.vessel.LandedOrSplashed) ret = ((int) (calculated + 0.5));
            else if (this.vessel.LandedOrSplashed) ret = ((int) (calculated * Landed + 0.5));
            else ret = ((int)(calculated * inSpace + 0.5));

            if (ret < 1) ret = 1;
            return ret;
        }

        private double getKerbalTrainingExp(ProtoCrewMember crew)
        {
            string lastExpStr = "0";

            FlightLog totalLog = crew.careerLog.CreateCopy();
            totalLog.MergeWith(crew.flightLog.CreateCopy());
            foreach (FlightLog.Entry entry in totalLog.Entries)
                if (entry.type == "TrainingExp") lastExpStr = entry.target;

            return double.Parse(lastExpStr);
        }

        private void removeKerbalTrainingExp(ProtoCrewMember crew)
        {
            foreach (FlightLog.Entry entry in crew.careerLog.Entries.ToArray())
                if (entry.type == "TrainingExp")
                    crew.careerLog.Entries.Remove(entry);
            foreach (FlightLog.Entry entry in crew.flightLog.Entries.ToArray())
                if (entry.type == "TrainingExp")
                    crew.flightLog.Entries.Remove(entry);
        }

        private int getCrewTrainedLevel(ProtoCrewMember crew)
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
    }
}
