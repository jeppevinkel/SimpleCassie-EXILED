using System.Collections.Generic;
using Exiled.API.Features;
using MEC;

namespace SimpleCassie
{
	public static class Extensions
	{
		public static IEnumerator<float> CassieMessage(object msg, bool makeHold, bool makeNoise, float delay)
		{
			yield return Timing.WaitForSeconds(delay);
			Cassie.Message(msg.ToString(), makeHold, makeNoise);
		}
	}
}