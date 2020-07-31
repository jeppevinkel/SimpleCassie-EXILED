using Exiled.Events.EventArgs;
using System.Collections.Generic;
using Exiled.API.Features;
using MEC;

namespace SimpleCassie.Handlers
{
	class Warhead
	{
		internal void OnStarting(StartingEventArgs ev)
		{
			if (ev.IsAllowed)
			{
				AnnouncementSettings settings = SimpleCassie.Instance.Config.WarheadStart;
				Log.Info(
					$"RoundStart: {settings.Enabled}, roundStartMsg: {settings.Message}, roundStartDelay: {settings.Delay}, roundStartNoise: {settings.MakeNoise}");
				Timing.RunCoroutine(Extensions.CassieMessage(settings.Message, false, settings.MakeNoise,
					settings.Delay));
			}
		}

		internal void OnStopping(StoppingEventArgs ev)
		{
			if (ev.IsAllowed)
			{
				AnnouncementSettings settings = SimpleCassie.Instance.Config.WarheadStop;
				Log.Info(
					$"RoundStart: {settings.Enabled}, roundStartMsg: {settings.Message}, roundStartDelay: {settings.Delay}, roundStartNoise: {settings.MakeNoise}");
				Timing.RunCoroutine(Extensions.CassieMessage(settings.Message, false, (bool)settings.MakeNoise,
					(float)settings.Delay));
			}
		}

		internal void OnDetonated()
		{
			AnnouncementSettings settings = SimpleCassie.Instance.Config.WarheadDetonation;
			Log.Info(
				$"RoundStart: {settings.Enabled}, roundStartMsg: {settings.Message}, roundStartDelay: {settings.Delay}, roundStartNoise: {settings.MakeNoise}");
			Timing.RunCoroutine(Extensions.CassieMessage(settings.Message, false, settings.MakeNoise,
				settings.Delay));
		}
	}
}
