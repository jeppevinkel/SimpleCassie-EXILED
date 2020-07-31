using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using Respawning;

namespace SimpleCassie.Handlers
{
	class Server
	{
		public void OnRoundStarted()
		{
			Dictionary<string, object> settings = SimpleCassie.Instance.Config.RoundStart;
			Log.Info(
				$"RoundStart: {settings["Enabled"]}, roundStartMsg: {settings["Message"]}, roundStartDelay: {settings["Delay"]}, roundStartNoise: {settings["MakeNoise"]}");
			Timing.RunCoroutine(Extensions.CassieMessage(settings["Message"], false, (bool) settings["MakeNoise"],
				(float) settings["Delay"]));
		}

		public void OnRoundEnded(RoundEndedEventArgs ev)
		{
			Dictionary<string, object> settings = SimpleCassie.Instance.Config.RoundEnd;
			Log.Info(
				$"RoundStart: {settings["Enabled"]}, roundStartMsg: {settings["Message"]}, roundStartDelay: {settings["Delay"]}, roundStartNoise: {settings["MakeNoise"]}");
			Timing.RunCoroutine(Extensions.CassieMessage(settings["Message"], false, (bool) settings["MakeNoise"],
				(float) settings["Delay"]));
		}

		public void OnRespawningTeam(RespawningTeamEventArgs ev)
		{
			if (ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency)
			{
				Dictionary<string, object> settings = SimpleCassie.Instance.Config.ChaosRespawn;
				Log.Info(
					$"ChaosRespawn: {settings["Enabled"]}, roundStartMsg: {settings["Message"]}, roundStartDelay: {settings["Delay"]}, roundStartNoise: {settings["MakeNoise"]}");
				Timing.RunCoroutine(Extensions.CassieMessage(settings["Message"], false, (bool) settings["MakeNoise"],
					(float) settings["Delay"]));
			}
			else if (ev.NextKnownTeam == SpawnableTeamType.NineTailedFox)
			{
				Dictionary<string, object> settings = SimpleCassie.Instance.Config.MtfRespawn;
				Log.Info(
					$"MtfRespawn: {settings["Enabled"]}, roundStartMsg: {settings["Message"]}, roundStartDelay: {settings["Delay"]}, roundStartNoise: {settings["MakeNoise"]}");
				Timing.RunCoroutine(Extensions.CassieMessage(settings["Message"], false, (bool) settings["MakeNoise"],
					(float) settings["Delay"]));
			}
		}
	}
}
