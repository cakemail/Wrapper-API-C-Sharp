using System.Xml;
using InOutDictionary = System.Collections.Generic.Dictionary<string, object>;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeTrigger : CakeObject
	{
		private const string className = "ClassTrigger";

		/**
		 * Creates a new trigger
		 * 
		 * @params		an array of parameters
		 * @returns		the new trigger's id or an exception
		 */
		public static int Create(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Create";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return int.Parse(methodNode["id"].InnerText);
		}

		/**
		 * Gets a trigger
		 * 
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetInfo(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetInfo";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/**
		 * Returns the list of links for a trigger
		 *
		 * @params   array  an array of parameters
		 * @returns  mixed  an array or an exception
		 */
		public static InOutDictionary GetLinks(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetLinks";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "link" });
			ChangeKey(res, "link", "links");

			return res;
		}

		/**
		 * Returns the total and unique counts of openings for triger's links
		 *
		 * @params   array  an array of parameters
		 * @returns  mixed  an array or an exception
		 */
		public static InOutDictionary GetLinksLog(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetLinksLog";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "link" });
			ChangeKey(res, "link", "links");

			return res;
		}

		/**
		 * Retrieves the list of triggers
		 * 
		 * @params		an array of parameters
		 * @returns		the new trigger's id or an exception
		 */
		public static InOutDictionary GetList(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetList";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "trigger" });
			ChangeKey(res, "trigger", "triggers");

			return res;
		}

		/**
		 * Returns the logs of a trigger
		 *
		 * @params   array  an array of parameters
		 * @returns  mixed  an array or an exception
		 */
		public static InOutDictionary GetLog(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetLog";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] {
																"count"
																,"daily"
																,"hourly"
																,"log"
															  }
				);
			ChangeKey(res, "log", "logs");

			return res;
		}

		/**
		 * Sets the parameters for a trigger
		 * 
		 * @params		an array of parameters
		 * @returns		true or an exception
		 */
		public static bool SetInfo(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "SetInfo";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
		 * Unleashes a trigger
		 * 
		 * @params		an array of parameters
		 * @returns		true or an exception
		 */
		public static bool Unleash(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Unleash";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}
	}
}