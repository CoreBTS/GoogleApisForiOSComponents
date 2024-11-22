using System;
namespace Google.Places
{
	public class Loader
	{
		static Loader ()
		{
		}

		public static void ForceLoad () { }
	}
}

namespace ApiDefinition
{
	partial class Messaging
	{
		static Messaging ()
		{
			Google.Places.Loader.ForceLoad ();
		}
	}
}
