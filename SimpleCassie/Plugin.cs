using System;
using EXILED;

namespace SimpleCassie
{
	public class Plugin : EXILED.Plugin
	{
		public EventHandlers EventHandlers;

		public bool roundEnabled;

		public bool roundStart;
		public string roundStartMsg;
		public float roundStartDelay;
		public bool roundStartNoise;

		public bool roundEnd;
		public string roundEndMsg;
		public float roundEndDelay;
		public bool roundEndNoise;

		public bool roundWarheadStart;
		public string roundWarheadStartMsg;
		public float roundWarheadStartDelay;
		public bool roundWarheadStartNoise;

		public bool roundWarheadCancelled;
		public string roundWarheadCancelledMsg;
		public float roundWarheadCancelledDelay;
		public bool roundWarheadCancelledNoise;

		public bool roundWarheadDetonation;
		public string roundWarheadDetonationMsg;
		public float roundWarheadDetonationDelay;
		public bool roundWarheadDetonationNoise;

		public override void OnEnable()
		{
			try
			{
				LoadConfig();

				if (!roundEnabled) return;

				Log.Debug("Initializing event handlers..");
				
				EventHandlers = new EventHandlers(this);
				
				Events.RoundStartEvent += EventHandlers.OnRoundStart;
				Events.RoundEndEvent += EventHandlers.OnRoundEnd;
				Events.WarheadStartEvent += EventHandlers.OnWarheadStart;
				Events.WarheadCancelledEvent += EventHandlers.OnWarheadCancelled;
				Events.WarheadDetonationEvent += EventHandlers.OnWarheadDetonation;

				Log.Info($"SimpleCassie loaded.");
			}
			catch (Exception e)
			{
				Log.Error($"There was an error loading the plugin: {e}");
			}
		}

		public void LoadConfig()
		{
			roundEnabled = Config.GetBool("simpleCassie_enable", true);

			roundStart = Config.GetBool("simpleCassie_roundStart", false);
			roundStartMsg = Config.GetString("simpleCassie_roundStart_message", "pitch_0.5 .g6 .g6 Pitch_0.8  facility containment breach . full site lockdown pitch_0.5 .g6 .g6");
			roundStartDelay = Config.GetFloat("simpleCassie_roundStart_delay", 3f);
			roundStartNoise = Config.GetBool("simpleCassie_roundStart_noise", false);

			roundEnd = Config.GetBool("simpleCassie_roundEnd", false);
			roundEndMsg = Config.GetString("simpleCassie_roundEnd_message", "pitch_0.5 .g6 .g6 Pitch_0.8  facility containment breach . full site lockdown pitch_0.5 .g6 .g6");
			roundEndDelay = Config.GetFloat("simpleCassie_roundEnd_delay", 0f);
			roundStartNoise = Config.GetBool("simpleCassie_roundEnd_noise", false);

			roundWarheadStart = Config.GetBool("simpleCassie_warheadStart", false);
			roundWarheadStartMsg = Config.GetString("simpleCassie_warheadStart_message", "pitch_0.5 .g6 .g6 Pitch_0.8  the alpha warhead detonation sequence has been started pitch_0.5 .g6 .g6");
			roundWarheadStartDelay = Config.GetFloat("simpleCassie_warheadStart_delay", 0f);
			roundWarheadStartNoise = Config.GetBool("simpleCassie_warheadStart_noise", false);

			roundWarheadCancelled = Config.GetBool("simpleCassie_warheadCancelled", false);
			roundWarheadCancelledMsg = Config.GetString("simpleCassie_warheadCancelled_message", "pitch_0.5 .g6 .g6 Pitch_0.8  the alpha warhead detonation sequence has been stopped pitch_0.5 .g6 .g6");
			roundWarheadCancelledDelay = Config.GetFloat("simpleCassie_warheadCancelled_delay", 0f);
			roundWarheadCancelledNoise = Config.GetBool("simpleCassie_warheadCancelled_noise", false);

			roundWarheadDetonation = Config.GetBool("simpleCassie_warheadDetonation", false);
			roundWarheadDetonationMsg = Config.GetString("simpleCassie_warheadDetonation_message", "pitch_0.5 .g6 .g6 Pitch_0.8  the alpha warhead will detonate in tminus 5 seconds pitch_0.5 .g6 .g6");
			roundWarheadDetonationDelay = Config.GetFloat("simpleCassie_warheadDetonation_delay", 0f);
			roundWarheadDetonationNoise = Config.GetBool("simpleCassie_warheadDetonation_noise", false);
		}

		public override void OnDisable()
		{
			Events.RoundStartEvent -= EventHandlers.OnRoundStart;
			Events.RoundEndEvent -= EventHandlers.OnRoundEnd;
			Events.WarheadStartEvent -= EventHandlers.OnWarheadStart;
			Events.WarheadCancelledEvent -= EventHandlers.OnWarheadCancelled;
			Events.WarheadDetonationEvent -= EventHandlers.OnWarheadDetonation;

			EventHandlers = null;
		}

		public override void OnReload()
		{
			//This is only fired when you use the EXILED reload command, the reload command will call OnDisable, OnReload, reload the plugin, then OnEnable in that order. There is no GAC bypass, so if you are updating a plugin, it must have a unique assembly name, and you need to remove the old version from the plugins folder
		}

		public override string getName { get; } = "SimpleCassie";
	}
}