using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXILED;
using Newtonsoft.Json;

namespace SimpleCassie
{
	public static class SCassie
	{
		public static CassieMessages CassieMessages = new CassieMessages();

		public static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		public static readonly string PluginsDir = Path.Combine(AppData, "Plugins");
		private static readonly string MyDir = Path.Combine(PluginsDir, "SimpleCassie");

		public static string FilePath = Path.Combine(MyDir, "CassieMessages.json");

		public static void LoadMessaged()
		{
			Log.Debug("Loading messages...");

			Directory.CreateDirectory(MyDir);

			

		}

		public static void SaveMessages()
		{
			Log.Debug("Saving messages...");

			Directory.CreateDirectory(MyDir);

			try
			{
				JsonSerializer serializer = new JsonSerializer();
				string json = JsonConvert.SerializeObject(CassieMessages, Formatting.Indented);

				if (File.Exists(FilePath))
				{
					string oldJson = File.ReadAllText(FilePath);
					if (oldJson != json)
					{
						if (File.Exists($"{FilePath}.BACKUP.json")) File.Delete($"{FilePath}.BACKUP.json");
						File.Copy(FilePath, $"{FilePath}.BACKUP.json");
					}
				}

				File.WriteAllText(FilePath, json);
				Log.Debug($"Saved messages: {Path.GetFileName(FilePath)}");
			}
			catch (Exception e)
			{
				Log.Error(e.Message);
			}
		}
	}

	[JsonObject(MemberSerialization.OptOut)]
	public class CassieMessages
	{
		[JsonProperty]
		public static RoundStartEvent roundStartEvent = new RoundStartEvent();
		[JsonProperty]
		public static RoundEndEvent roundEndEvent = new RoundEndEvent();
	}

	[JsonObject(MemberSerialization.OptOut)]
	public class RoundStartEvent
	{
		public string GlobalMessage;
		public string SCPMessage;
		public string ChosMessage;
	}

	[JsonObject(MemberSerialization.OptOut)]
	public class RoundEndEvent
	{
		public string GlobalMessage;
		public string SCPMessage;
		public string ChosMessage;
	}
}
