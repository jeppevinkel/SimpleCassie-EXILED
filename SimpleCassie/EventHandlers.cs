using System.Collections.Generic;
using System.Linq;
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
			if (!roundPlugin.roundStart)
			{
				return;
			}
			Log.Info($"roundStart: {roundPlugin.roundStart}, roundStartMsg: {roundPlugin.roundStartMsg}, roundStartDelay: {roundPlugin.roundStartDelay}, roundStartNoise: {roundPlugin.roundStartNoise}");
			Timing.RunCoroutine(CassieMessage(roundPlugin.roundStartMsg, false, roundPlugin.roundStartNoise, roundPlugin.roundStartDelay));
			Player.GetHubs().ToArray()[0].SetRotation(1, 2);
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
			if (!roundPlugin.roundWarheadStart)
			{
				return;
			}
			Log.Info($"roundEnd: {roundPlugin.roundWarheadStart}, roundStartMsg: {roundPlugin.roundWarheadStartMsg}, roundStartDelay: {roundPlugin.roundWarheadStartNoise}, roundStartNoise: {roundPlugin.roundWarheadStartDelay}");
			Timing.RunCoroutine(CassieMessage(roundPlugin.roundWarheadStartMsg, false, roundPlugin.roundWarheadStartNoise, roundPlugin.roundWarheadStartDelay));
		}

		public void OnWarheadCancelled(WarheadCancelEvent ev)
		{
			if (!roundPlugin.roundWarheadCancelled)
			{
				return;
			}
			Log.Info($"roundEnd: {roundPlugin.roundWarheadCancelled}, roundStartMsg: {roundPlugin.roundWarheadCancelledMsg}, roundStartDelay: {roundPlugin.roundWarheadCancelledNoise}, roundStartNoise: {roundPlugin.roundWarheadCancelledDelay}");
			Timing.RunCoroutine(CassieMessage(roundPlugin.roundWarheadCancelledMsg, false, roundPlugin.roundWarheadCancelledNoise, roundPlugin.roundWarheadCancelledDelay));
		}

		public void OnWarheadDetonation()
		{
			if (!roundPlugin.roundWarheadDetonation)
			{
				return;
			}
			Log.Info($"roundEnd: {roundPlugin.roundWarheadDetonation}, roundStartMsg: {roundPlugin.roundWarheadDetonationMsg}, roundStartDelay: {roundPlugin.roundWarheadDetonationNoise}, roundStartNoise: {roundPlugin.roundWarheadDetonationDelay}");
			Timing.RunCoroutine(CassieMessage(roundPlugin.roundWarheadDetonationMsg, false, roundPlugin.roundWarheadDetonationNoise, roundPlugin.roundWarheadDetonationDelay));
		}
	}
}