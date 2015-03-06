using System.Xml;
using InOutDictionary = System.Collections.Generic.Dictionary<string, object>;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeClient : CakeObject
	{
		private const string className = "ClassClient";

		/**
	 * Activates a client
	 *
	 * @confirmation
	 * @returns		an array or an exception
	 */
		public static InOutDictionary Activate(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Activate";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/* Adds credits to a client */
		public static bool AddCredits(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "AddCredits";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
		 * Creates a new client
		 *
		 * @params		an array of parameters
		 * @returns		the confirmation code or an exception
		 */
		public static InOutDictionary Create(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Create";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/* Gets the credit balance */
		public static InOutDictionary GetCreditBalance(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetCreditBalance";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/* Gets the credit transactions */
		public static InOutDictionary GetCreditTransactions(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetCreditTransactions";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/**
		 * Retrieves the informations about the client
		 * 
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetInfo(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetInfo";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/**
		 * Gets the list with a specified status
		 * 
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetList(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetList";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "client" });
			ChangeKey(res, "client", "clients");

			return res;
		}

		/**
		 * Gets the timezones
		 *
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetTimezones(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetTimezones";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "timezone" });
			ChangeKey(res, "timezone", "timezones");

			return res;
		}

		/* Adds or removes credits to a client for the balance to be 0 at the end of the month */
		public static bool ResetCredits(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "ResetCredits";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/*
		 * Sets the parameters for a user
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
		 * Searchs for clients based on a query string
		 * 
		 * @returns		an array or an exception
		 */
		public static InOutDictionary Search(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Search";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "client" });
			ChangeKey(res, "client", "clients");

			return res;
		}
	}
}