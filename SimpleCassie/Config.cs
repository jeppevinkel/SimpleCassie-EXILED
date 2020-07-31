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
		public Dictionary<string, object> RoundStart = new Dictionary<string, object>
		{
			{ "Enabled", false },
			{ "Delay", 0f },
			{ "MakeNoise", false },
			{ "Message", "pitch_0.5 .g6 .g6 Pitch_0.8  facility containment breach . full site lockdown pitch_0.5 .g6 .g6" }
		};

		[Description("Settings for announcement at the end of the round.")]
		public Dictionary<string, object> RoundEnd = new Dictionary<string, object>
		{
			{ "Enabled", false },
			{ "Delay", 0f },
			{ "MakeNoise", false },
			{ "Message", "pitch_0.5 .g6 .g6 Pitch_0.8  facility containment breach . full site lockdown pitch_0.5 .g6 .g6" }
		};

		[Description("Settings for announcement when the warhead is started.")]
		public Dictionary<string, object> WarheadStart = new Dictionary<string, object>
		{
			{ "Enabled", false },
			{ "Delay", 0f },
			{ "MakeNoise", false },
			{ "Message", "pitch_0.5 .g6 .g6 Pitch_0.8  the alpha warhead detonation sequence has been started pitch_0.5 .g6 .g6" }
		};

		[Description("Settings for announcement when the warhead is detonated.")]
		public Dictionary<string, object> WarheadDetonation = new Dictionary<string, object>
		{
			{ "Enabled", false },
			{ "Delay", 0f },
			{ "MakeNoise", false },
			{ "Message", "pitch_0.5 .g6 .g6 Pitch_0.8  the alpha warhead will detonate in tminus 5 seconds pitch_0.5 .g6 .g6" }
		};

		[Description("Settings for announcement when the warhead is cancelled.")]
		public Dictionary<string, object> WarheadStop = new Dictionary<string, object>
		{
			{ "Enabled", false },
			{ "Delay", 0f },
			{ "MakeNoise", false },
			{ "Message", "pitch_0.5 .g6 .g6 Pitch_0.8  the alpha warhead detonation sequence has been stopped pitch_0.5 .g6 .g6" }
		};

		[Description("Settings for announcement when the chaos insurgency is respawned.")]
		public Dictionary<string, object> ChaosRespawn = new Dictionary<string, object>
		{
			{ "Enabled", false },
			{ "Delay", 0f },
			{ "MakeNoise", false },
			{ "Message", "pitch_0.5 .g6 .g6 Pitch_0.8  Chaos insurgency has arrived at the gate pitch_0.5 .g6 .g6" }
		};

		[Description("Settings for announcement when the mtf is respawned.")]
		public Dictionary<string, object> MtfRespawn = new Dictionary<string, object>
		{
			{ "Enabled", false },
			{ "Delay", 0f },
			{ "MakeNoise", false },
			{ "Message", "pitch_0.5 .g6 .g6 Pitch_0.8  M T F has arrived at the facility pitch_0.5 .g6 .g6" }
		};
	}
}
