using System.IO;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public static class CakeDebug
	{
		public static void AddMessage(string message, CakeSettings connectionSettings)
		{
			if (connectionSettings.DEBUG) using (StreamWriter logFile = new StreamWriter(connectionSettings.LOG_FILENAME, true)) logFile.Write(message + "\r\n");
		}
	}
}