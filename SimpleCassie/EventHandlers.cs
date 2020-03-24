using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EXILED;
using MEC;
using EXILED.Extensions;

namespace SimpleCassie
{
	public class EventHandlers
	{
		public Plugin roundPlugin;
		public EventHandlers(Plugin plugin) => this.roundPlugin = plugin;

		public IEnumerator<float> CassieMessage(string msg, bool makeHold, bool makeNoise, float delay)
		{
			yield return Timing.WaitForSeconds(delay);
			Extensions.MtfRespawn.RpcPlayCustomAnnouncement(msg, makeHold, makeNoise);
		}

		public void OnRoundStart()
		{
			if (roundPlugin.autoWarheadStart && EXILED.Plugin.Config.GetBool("util_enable_autonuke", false))
			{
				Timing.CallDelayed(EXILED.Plugin.Config.GetInt("util_autonuke_time", 600), () =>
				{
					Log.Info($"autoWarheadStart: {roundPlugin.autoWarheadStart}, roundStartMsg: {roundPlugin.autoWarheadStartMsg}, roundStartDelay: {roundPlugin.autoWarheadStartDelay}, roundStartNoise: {roundPlugin.autoWarheadStartNoise}");
					Timing.RunCoroutine(CassieMessage(roundPlugin.autoWarheadStartMsg, false, roundPlugin.autoWarheadStartNoise, roundPlugin.autoWarheadStartDelay));
				});
			}

			if (!roundPlugin.roundStart)
			{
				return;
			}
			Log.Info($"roundStart: {roundPlugin.roundStart}, roundStartMsg: {roundPlugin.roundStartMsg}, roundStartDelay: {roundPlugin.roundStartDelay}, roundStartNoise: {roundPlugin.roundStartNoise}");
			Timing.RunCoroutine(CassieMessage(roundPlugin.roundStartMsg, false, roundPlugin.roundStartNoise, roundPlugin.roundStartDelay));
		}

		public void OnRoundEnd()
		{
			if (!roundPlugin.roundEnd)
			{
				return;
			}
			Log.Info($"roundEnd: {roundPlugin.roundEnd}, roundStartMsg: {roundPlugin.roundEndMsg}, roundStartDelay: {roundPlugin.roundEndDelay}, roundStartNoise: {roundPlugin.roundEndNoise}");
			Timing.RunCoroutine(CassieMessage(roundPlugin.roundEndMsg, false, roundPlugin.roundEndNoise, roundPlugin.roundEndDelay));
		}

		public void OnWarheadStart(WarheadStartEvent ev)
		{
			if (!roundPlugin.warheadStart)
			{
				return;
			}
			Log.Info($"roundEnd: {roundPlugin.warheadStart}, roundStartMsg: {roundPlugin.warheadStartMsg}, roundStartDelay: {roundPlugin.warheadStartNoise}, roundStartNoise: {roundPlugin.warheadStartDelay}");
			Timing.RunCoroutine(CassieMessage(roundPlugin.warheadStartMsg, false, roundPlugin.warheadStartNoise, roundPlugin.warheadStartDelay));
		}

		public void OnWarheadCancelled(WarheadCancelEvent ev)
		{
			if (!roundPlugin.warheadCancelled)
			{
				return;
			}
			Log.Info($"roundEnd: {roundPlugin.warheadCancelled}, roundStartMsg: {roundPlugin.warheadCancelledMsg}, roundStartDelay: {roundPlugin.warheadCancelledNoise}, roundStartNoise: {roundPlugin.warheadCancelledDelay}");
			Timing.RunCoroutine(CassieMessage(roundPlugin.warheadCancelledMsg, false, roundPlugin.warheadCancelledNoise, roundPlugin.warheadCancelledDelay));
		}

		public void OnWarheadDetonation()
		{
			if (!roundPlugin.warheadDetonation)
			{
				return;
			}
			Log.Info($"roundEnd: {roundPlugin.warheadDetonation}, roundStartMsg: {roundPlugin.warheadDetonationMsg}, roundStartDelay: {roundPlugin.warheadDetonationNoise}, roundStartNoise: {roundPlugin.warheadDetonationDelay}");
			Timing.RunCoroutine(CassieMessage(roundPlugin.warheadDetonationMsg, false, roundPlugin.warheadDetonationNoise, roundPlugin.warheadDetonationDelay));
		}
	}
}