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
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using KSP.Localization;

namespace FieldTrainingLab
{
    // http://forum.kerbalspaceprogram.com/index.php?/topic/147576-modders-notes-for-ksp-12/#comment-2754813
    // search for "Mod integration into Stock Settings

    /// <summary>Game Settings FTL Options</summary>
    public class FTL_Options : GameParameters.CustomParameterNode
    {
        /// <summary>Settings Title</summary>
        public override string Title { get { return "#FTL-settings-title-label"; } }		// #FTL-settings-title-label = [WIP] Field Training Lab Settings

        /// <summary>Settings Section</summary>
        public override string Section { get { return "#FTL-settings-section"; } }		// #FTL-settings-section = [WIP] Field Training

        /// <summary>Settings Display Section</summary>
        public override string DisplaySection { get { return "#FTL-settings-section-display-label"; } }		// #FTL-settings-section-display-label = [WIP] Field Training

        /// <summary>Settings Section Order</summary>
        public override int SectionOrder { get { return 1; } }

        /// <summary>Settings  Game Mode</summary>
        public override GameParameters.GameMode GameMode { get { return GameParameters.GameMode.ANY; } }

        /// <summary>Settings module master enable/disable</summary>
        [GameParameters.CustomParameterUI("#FTL-settings-enable",		// #FTL-settings-enable = Enable Field Training Lab?
            toolTip = "#FTL-settings-enable-tt",		// #FTL-settings-enable-tt = Field Training Labs are enabled if set to yes.
            newGameOnly = false, unlockedDuringMission = true)]
        public bool enableFTL = true;

        /// <summary>Settings Payment</summary>
        [GameParameters.CustomStringParameterUI("#FTL-settings-paymentLabel",		// #FTL-settings-paymentLabel = Payment Label
            toolTip = "#FTL-settings-paymentLabel-tt",		// #FTL-settings-paymentLabel-tt = Science/Reputation/Funds
            autoPersistance = true,
            lines = 2,
            title = "#FTL-settings-paymentType",		// #FTL-settings-paymentType = How would you like to pay for your kerbal training?
            unlockedDuringMission = true)]
        public string UIstring = "";

        ///<summary>require science points to gain experience</summary>        
        [GameParameters.CustomParameterUI("#FTL-settings-paymentType-tt",		// #FTL-settings-paymentType-tt = Require Science Points to advance
            toolTip = "#FTL-settings-paymentScience",		// #FTL-settings-paymentScience = If enabled, requires expending Science points to gain experience.
            newGameOnly = false, unlockedDuringMission = true)]
        public bool requireSciencePoints = true;

        ///<summary>number of science points per experience point</summary> 
       [GameParameters.CustomFloatParameterUI("#FTL-settings-paymentScience-tt",		// #FTL-settings-paymentScience-tt = Science : Experience
        toolTip = "#FTL-settings-paymentScienceRatio",		// #FTL-settings-paymentScienceRatio = Ratio of Science Points per Experience Point.
            newGameOnly = false,
            unlockedDuringMission = true,
            minValue = 0.0f,
            maxValue = 100.0f,
            stepCount = 1)]
       public double costScience = 20.0f;

        ///<summary>require Reputation to gain experience</summary>
        [GameParameters.CustomParameterUI("#FTL-settings-paymentScienceRatio-tt",		// #FTL-settings-paymentScienceRatio-tt = Require Reputation to advance
            toolTip = "#FTL-settings-paymentRep",		// #FTL-settings-paymentRep = If enabled, requires expending Reputation to gain experience.
            newGameOnly = false, unlockedDuringMission = true)]
        public bool requireReputationPoints = false;

        ///<summary>number of Reputation per experience point</summary>
        [GameParameters.CustomFloatParameterUI("#FTL-settings-paymentRep-tt",		// #FTL-settings-paymentRep-tt = Reputation : Experience
         toolTip = "#FTL-settings-paymentRepRatio",		// #FTL-settings-paymentRepRatio = Ratio of Reputation per Experience Point.
             newGameOnly = false,
             unlockedDuringMission = true,
             minValue = 0.0f,
             maxValue = 50.0f)]
        public double costReputation = 0.1f;

        ///<summary>require Funds to gain experience</summary>       
        [GameParameters.CustomParameterUI("#FTL-settings-paymentRepRatio-tt",		// #FTL-settings-paymentRepRatio-tt = Require Funds to advance
        toolTip = "#FTL-settings-paymentFunds",		// #FTL-settings-paymentFunds = If enabled, requires expending Funds to gain experience.
            newGameOnly = false, unlockedDuringMission = true)]
        public bool requireFunds = false;

        ///<summary>amount of Funds per experience point</summary>  
        [GameParameters.CustomFloatParameterUI("#FTL-settings-paymentFunds-tt",		// #FTL-settings-paymentFunds-tt = Funds : Experience
         toolTip = "#FTL-settings-paymentFundsRatio",		// #FTL-settings-paymentFundsRatio = Ratio of Funds per Experience Point.
             newGameOnly = false,
             unlockedDuringMission = true,
             minValue = 0.0f,
             maxValue = 5000.0f,
             stepCount = 1)]
        public double costFunds = 1000f;

        /// <summary>Settings - KSP Mail</summary>
        [GameParameters.CustomParameterUI("#FTL-settings-paymentFundsRatio-tt",		// #FTL-settings-paymentFundsRatio-tt = KSPMail
            toolTip = "#FTL-settings-mail-tt",		// #FTL-settings-mail-tt = Recieve a colorful Joyntmail announcing graduation to a new rank?.
            newGameOnly = false, unlockedDuringMission = true)]
        public bool KSPMail = true;

        /// <summary>Settings allow colored PAW</summary>
        [GameParameters.CustomParameterUI("#FTL-settings-pawColor",		// #FTL-settings-pawColor = PAW Color
            toolTip = "#FTL-settings-pawColor-tt",		// #FTL-settings-pawColor-tt = allow color coding in Field Training Lab PAW (part action window) / RMB (right menu button).
            newGameOnly = false, unlockedDuringMission = true)]
        public bool coloredPAW = true;

        // If you want to have some of the game settings default to enabled,  change 
        // the "if false" to "if true" and set the values as you like


#if true
        /// <summary>Had Presets?</summary>
        public override bool HasPresets { get { return true; } }
        /// <summary>Difficulty Presets</summary>
        public override void SetDifficultyPreset(GameParameters.Preset preset)
        {
            Debug.Log("Setting difficulty preset");
            switch (preset)
            {
                case GameParameters.Preset.Easy:
                    enableFTL = true;
                    requireSciencePoints = true;
                    requireReputationPoints = false;
                    requireFunds = false;
                    costScience = 15;
                    costFunds = 100;
                    costReputation = .1;
                   // autoSwitch = true;
                    break;

                case GameParameters.Preset.Normal:
                    enableFTL = true;
                    requireSciencePoints = true;
                    requireFunds = true;
                    requireReputationPoints = false;
                    costScience = 20;
                    costFunds = 1000;
                    costReputation = 1;
                    // autoSwitch = true;
                    break;

                case GameParameters.Preset.Moderate:
                    enableFTL = true;
                    requireSciencePoints = true;
                    requireFunds = true;
                    requireReputationPoints = true;
                    costScience = 25;
                    costFunds = 1000;
                    costReputation = 1.5;
                    //autoSwitch = true;
                    break;

                case GameParameters.Preset.Hard:
                    enableFTL = false;
                    requireSciencePoints = true;
                    requireFunds = true;
                    requireReputationPoints = true;
                    costScience = 30;
                    costFunds = 1000;
                    costReputation = 2.0;
                    //autoSwitch = false;
                    break;
            }
        }

#else
        public override bool HasPresets { get { return false; } }
        public override void SetDifficultyPreset(GameParameters.Preset preset) { }
#endif
        /// <summary>Enabled?</summary>
        /// <param name="member"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override bool Enabled(MemberInfo member, GameParameters parameters) { return true; }

        /// <summary>Interactible?</summary>
        /// <param name="member"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override bool Interactible(MemberInfo member, GameParameters parameters) { return true; }
        
        /// <summary>ValidValues</summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public override IList ValidValues(MemberInfo member) { return null; }
    }
}