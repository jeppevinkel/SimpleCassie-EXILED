using System;
using Exiled.API.Features;
using Exiled.Loader;
using Server = Exiled.Events.Handlers.Server;
using Warhead = Exiled.Events.Handlers.Warhead;

namespace SimpleCassie
{
	public class SimpleCassie : Plugin<Config>
	{
		private Handlers.Server server;
		private Handlers.Warhead warhead;

		private static readonly Lazy<SimpleCassie> LazyInstance = new Lazy<SimpleCassie>(() => new SimpleCassie());
		public static SimpleCassie Instance = LazyInstance.Value;

		private SimpleCassie()
		{
		}

		public override void OnEnabled()
		{
			Log.Debug("Initializing event handlers..", Loader.ShouldDebugBeShown);

			RegisterEvents();

			Log.Info($"SimpleCassie loaded.");

		}

		public override void OnDisabled()
		{
			UnregisterEvents();
		}

		public void RegisterEvents()
		{
			server = new Handlers.Server();
			warhead = new Handlers.Warhead();

			Server.RoundStarted += server.OnRoundStarted;
			Server.RoundEnded += server.OnRoundEnded;
			Server.RespawningTeam += server.OnRespawningTeam;

			Warhead.Starting += warhead.OnStarting;
			Warhead.Stopping += warhead.OnStopping;
			Warhead.Detonated += warhead.OnDetonated;
		}

		public void UnregisterEvents()
		{
			Server.RoundStarted -= server.OnRoundStarted;
			Server.RoundEnded -= server.OnRoundEnded;
			Server.RespawningTeam -= server.OnRespawningTeam;

			Warhead.Starting -= warhead.OnStarting;
			Warhead.Stopping -= warhead.OnStopping;
			Warhead.Detonated -= warhead.OnDetonated;

			server = null;
			warhead = null;
		}
	}
}