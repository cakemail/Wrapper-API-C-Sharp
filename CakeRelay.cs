using System.Xml;
using InOutDictionary = System.Collections.Generic.Dictionary<string, object>;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeRelay : CakeObject
	{
		private const string className = "ClassRelay";

		/**
		 * Retrieves the logs
		 * 
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetLogs(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetLogs";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/**
		 * Sends an email
		 * 
		 * @params		an array of parameters
		 * @returns		true or an exception
		 */
		public static bool Send(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Send";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}
	}
}