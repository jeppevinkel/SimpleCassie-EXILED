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

		public bool warheadStart;
		public string warheadStartMsg;
		public float warheadStartDelay;
		public bool warheadStartNoise;

		public bool warheadCancelled;
		public string warheadCancelledMsg;
		public float warheadCancelledDelay;
		public bool warheadCancelledNoise;

		public bool warheadDetonation;
		public string warheadDetonationMsg;
		public float warheadDetonationDelay;
		public bool warheadDetonationNoise;

		public bool autoWarheadStart;
		public string autoWarheadStartMsg;
		public float autoWarheadStartDelay;
		public bool autoWarheadStartNoise;

		public bool chaosRespawn;
		public string chaosRespawnMsg;
		public float chaosRespawnDelay;
		public bool chaosRespawnNoise;

		public bool mtfRespawn;
		public string mtfRespawnMsg;
		public float mtfRespawnDelay;
		public bool mtfRespawnNoise;

		public override void OnEnable()
		{
			try
			{
				LoadConfig();

				//SCassie.SaveMessages();

				if (!roundEnabled) return;


				Log.Debug("Initializing event handlers..");
				
				EventHandlers = new EventHandlers(this);
				
				Events.RoundStartEvent += EventHandlers.OnRoundStart;
				Events.RoundEndEvent += EventHandlers.OnRoundEnd;
				Events.WarheadStartEvent += EventHandlers.OnWarheadStart;
				Events.WarheadCancelledEvent += EventHandlers.OnWarheadCancelled;
				Events.WarheadDetonationEvent += EventHandlers.OnWarheadDetonation;
				Events.TeamRespawnEvent += EventHandlers.OnTeamRespawn;

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

			warheadStart = Config.GetBool("simpleCassie_warheadStart", false);
			warheadStartMsg = Config.GetString("simpleCassie_warheadStart_message", "pitch_0.5 .g6 .g6 Pitch_0.8  the alpha warhead detonation sequence has been started pitch_0.5 .g6 .g6");
			warheadStartDelay = Config.GetFloat("simpleCassie_warheadStart_delay", 0f);
			warheadStartNoise = Config.GetBool("simpleCassie_warheadStart_noise", false);

			warheadCancelled = Config.GetBool("simpleCassie_warheadCancelled", false);
			warheadCancelledMsg = Config.GetString("simpleCassie_warheadCancelled_message", "pitch_0.5 .g6 .g6 Pitch_0.8  the alpha warhead detonation sequence has been stopped pitch_0.5 .g6 .g6");
			warheadCancelledDelay = Config.GetFloat("simpleCassie_warheadCancelled_delay", 0f);
			warheadCancelledNoise = Config.GetBool("simpleCassie_warheadCancelled_noise", false);

			warheadDetonation = Config.GetBool("simpleCassie_warheadDetonation", false);
			warheadDetonationMsg = Config.GetString("simpleCassie_warheadDetonation_message", "pitch_0.5 .g6 .g6 Pitch_0.8  the alpha warhead will detonate in tminus 5 seconds pitch_0.5 .g6 .g6");
			warheadDetonationDelay = Config.GetFloat("simpleCassie_warheadDetonation_delay", 0f);
			warheadDetonationNoise = Config.GetBool("simpleCassie_warheadDetonation_noise", false);

			autoWarheadStart = Config.GetBool("simpleCassie_autoWarheadStart", false);
			autoWarheadStartMsg = Config.GetString("simpleCassie_autoWarheadStart_message", "pitch_0.5 .g6 .g6 Pitch_0.8  the alpha warhead detonation sequence has been started pitch_0.5 .g6 .g6");
			autoWarheadStartDelay = Config.GetFloat("simpleCassie_autoWarheadStart_delay", 0f);
			autoWarheadStartNoise = Config.GetBool("simpleCassie_autoWarheadStart_noise", false);

			chaosRespawn = Config.GetBool("simpleCassie_chaosRespawn", false);
			chaosRespawnMsg = Config.GetString("simpleCassie_chaosRespawn_message", "pitch_0.5 .g6 .g6 Pitch_0.8  Chaos insurgency has arrived at the gate pitch_0.5 .g6 .g6");
			chaosRespawnDelay = Config.GetFloat("simpleCassie_chaosRespawn_delay", 0f);
			chaosRespawnNoise = Config.GetBool("simpleCassie_chaosRespawn_noise", false);

			mtfRespawn = Config.GetBool("simpleCassie_mtfRespawn", false);
			mtfRespawnMsg = Config.GetString("simpleCassie_mtfRespawn_message", "pitch_0.5 .g6 .g6 Pitch_0.8  M T F has arrived at the facility pitch_0.5 .g6 .g6");
			mtfRespawnDelay = Config.GetFloat("simpleCassie_mtfRespawn_delay", 0f);
			mtfRespawnNoise = Config.GetBool("simpleCassie_mtfRespawn_noise", false);
		}

		public override void OnDisable()
		{
			Events.RoundStartEvent -= EventHandlers.OnRoundStart;
			Events.RoundEndEvent -= EventHandlers.OnRoundEnd;
			Events.WarheadStartEvent -= EventHandlers.OnWarheadStart;
			Events.WarheadCancelledEvent -= EventHandlers.OnWarheadCancelled;
			Events.WarheadDetonationEvent -= EventHandlers.OnWarheadDetonation;
			Events.TeamRespawnEvent -= EventHandlers.OnTeamRespawn;

			EventHandlers = null;
		}

		public override void OnReload()
		{
			//This is only fired when you use the EXILED reload command, the reload command will call OnDisable, OnReload, reload the plugin, then OnEnable in that order. There is no GAC bypass, so if you are updating a plugin, it must have a unique assembly name, and you need to remove the old version from the plugins folder
		}

		public override string getName { get; } = "SimpleCassie";
	}
}