using System;
using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SimpleCassie
{
	public sealed class Config : IConfig
	{
		[Description("Determines if the plugin should be enabled.")]
		public bool IsEnabled { get; set; } = true;

		[Description("Settings for announcement at the start of the round.")]
		public AnnouncementSettings RoundStart { get; set; } = new AnnouncementSettings
		(
			false,
			0f,
			false,
			"pitch_0.5 .g6 .g6 Pitch_0.8  facility containment breach . full site lockdown pitch_0.5 .g6 .g6"
		);

		[Description("Settings for announcement at the end of the round.")]
		public AnnouncementSettings RoundEnd { get; set; } = new AnnouncementSettings
		(
			false,
			0f,
			false,
			"pitch_0.5 .g6 .g6 Pitch_0.8  facility containment breach . full site lockdown pitch_0.5 .g6 .g6"
		);

		[Description("Settings for announcement when the warhead is started.")]
		public AnnouncementSettings WarheadStart { get; set; } = new AnnouncementSettings
		(
			false,
			0f,
			false,
			"pitch_0.5 .g6 .g6 Pitch_0.8  the alpha warhead detonation sequence has been started pitch_0.5 .g6 .g6"
		);

		[Description("Settings for announcement when the warhead is detonated.")]
		public AnnouncementSettings WarheadDetonation { get; set; } = new AnnouncementSettings
		(
			false,
			0f,
			false,
			"pitch_0.5 .g6 .g6 Pitch_0.8  the alpha warhead will detonate in tminus 5 seconds pitch_0.5 .g6 .g6"
		);

		[Description("Settings for announcement when the warhead is cancelled.")]
		public AnnouncementSettings WarheadStop { get; set; } = new AnnouncementSettings
		(
			false,
			0f,
			false,
			"pitch_0.5 .g6 .g6 Pitch_0.8  the alpha warhead detonation sequence has been stopped pitch_0.5 .g6 .g6"
		);

		[Description("Settings for announcement when the chaos insurgency is respawned.")]
		public AnnouncementSettings ChaosRespawn { get; set; } = new AnnouncementSettings
		(
			false,
			0f,
			false,
			"pitch_0.5 .g6 .g6 Pitch_0.8  Chaos insurgency has arrived at the gate pitch_0.5 .g6 .g6"
		);

		[Description("Settings for announcement when the mtf is respawned.")]
		public AnnouncementSettings MtfRespawn { get; set; } = new AnnouncementSettings
		(
			false,
			0f,
			false,
			"pitch_0.5 .g6 .g6 Pitch_0.8  M T F has arrived at the facility pitch_0.5 .g6 .g6"
		);
	}

	public class AnnouncementSettings
	{
		public AnnouncementSettings(bool enabled, float delay, bool makeNoise, string message)
		{
			Enabled = enabled;
			Delay = delay;
			MakeNoise = makeNoise;
			Message = message;
		}

		public AnnouncementSettings()
		{
		}

		public bool Enabled { get; set; } = false;
		public float Delay { get; set; } = 0;
		public bool MakeNoise { get; set; } = false;
		public string Message { get; set; } = "";
	}
}
