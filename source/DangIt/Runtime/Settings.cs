﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace nsDangIt
{
    public partial class DangIt
    {
        /// <summary>
        /// General user settings about notifications and gameplay elements
        /// </summary>
        public class Settings
        {
            public static Settings Instance;

            public bool EnabledForSave
            { get { return HighLogic.CurrentGame.Parameters.CustomParams<DangItCustomParams1>().EnabledForSave; } }
            public bool ManualFailures
            {
                get { return HighLogic.CurrentGame.Parameters.CustomParams<DangItCustomParams1>().ManualFailures; }
            }
            public float MaxDistance
            {
                get { return HighLogic.CurrentGame.Parameters.CustomParams<DangItCustomParams1>().MaxDistance; }
            }
            public bool Messages
            {
                get { return HighLogic.CurrentGame.Parameters.CustomParams<DangItCustomParams1>().Messages; }
            }
            public bool Glow
            {
                get { return HighLogic.CurrentGame.Parameters.CustomParams<DangItCustomParams1>().Glow; }
            }
            public bool DisableGlowOnF2
            {
                get { return HighLogic.CurrentGame.Parameters.CustomParams<DangItCustomParams1>().DisableGlowOnF2; }
            }
            public bool RequireExperience
            {
                get { return HighLogic.CurrentGame.Parameters.CustomParams<DangItCustomParams1>().RequireExperience; }
            }
            public int Pri_Low_SoundLoops
            {
                get { return HighLogic.CurrentGame.Parameters.CustomParams<DangItCustomParams1>().Pri_Low_SoundLoops; }
            }
            public int Pri_Medium_SoundLoops
            {
                get { return HighLogic.CurrentGame.Parameters.CustomParams<DangItCustomParams1>().Pri_Medium_SoundLoops; }
            }
            public int Pri_High_SoundLoops
            {
                get { return HighLogic.CurrentGame.Parameters.CustomParams<DangItCustomParams1>().Pri_High_SoundLoops; }
            }
            public int AlarmVolume
            {
                get { return HighLogic.CurrentGame.Parameters.CustomParams<DangItCustomParams1>().AlarmVolume; }
            }
            public bool DebugStats
            {
                get { return HighLogic.CurrentGame.Parameters.CustomParams<DangItCustomParams1>().DebugStats; }
            }
            

            public Settings() { Instance = this; }

			public int GetSoundLoopsForPriority(string priority)
			{
				return GetSoundLoopsForPriority (DangIt.PriorityIntFromString (priority));
			}

			public int GetSoundLoopsForPriority(int priority)
			{
				if (priority == 1)
					return Pri_Low_SoundLoops;
				if (priority==2)
					return Pri_Medium_SoundLoops;
				if (priority==3)
					return Pri_High_SoundLoops;
				return 0;
			}

			public float GetMappedVolume()
			{
				return ((float)this.AlarmVolume / 100f);
			}

            /// <summary>
            /// Returns a shallow copy of the object (field-wise).
            /// </summary>
            public Settings ShallowClone()
            {
                return (DangIt.Settings)this.MemberwiseClone();
            }

			// Get the max servicing temp from DANGIT_SETTINGS
			public int GetMaxServicingTemp(){
				UrlDir.UrlConfig[] node = GameDatabase.Instance.GetConfigs ("DANGIT_SETTINGS");
				foreach (UrlDir.UrlConfig curSet in node)
				{
					int val = DangIt.Parse<int> (curSet.config.GetValue ("MaxServicingTemp"), 400);
					DangIt.Instance.Log ("Found a DANGIT_SETTINGS, its MaxServiceTemp is " + val.ToString ());
					return val;
				}
				return 400;
			}
        }
    }
}
