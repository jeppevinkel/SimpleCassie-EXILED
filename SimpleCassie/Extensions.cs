namespace SimpleCassie
{
	public static class Extensions
	{
		//These are two commonly used extensions that will make your life considerably easier
		//When sending RaReply's, you need to identify the 'source' of the message with a string followed by '#' at the start of the message, otherwise the message will not be sent
		public static void RaMessage(this CommandSender sender, string message, bool success = true) =>
			sender.RaReply("SimpleCassie#" + message, success, true, string.Empty);

		public static void Broadcast(this ReferenceHub rh, uint time, string message) => rh.GetComponent<Broadcast>().TargetAddElement(rh.scp079PlayerScript.connectionToClient, message, time, false);

		private static MTFRespawn _mtfRespawn;
		public static MTFRespawn MtfRespawn
		{
			get
			{
				if (_mtfRespawn == null)
				{
					_mtfRespawn = PlayerManager.localPlayer.GetComponent<MTFRespawn>();
				}
				return _mtfRespawn;
			}
			internal set => _mtfRespawn = value;
		}
	}
}