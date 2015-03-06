using System.Xml;
using InOutDictionary = System.Collections.Generic.Dictionary<string, object>;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeList : CakeObject
	{
		private const string className = "ClassList";

		/**
	 * Adds a test e-mail to list
	 *
	 * @params		an array of parameters
	 * @returns		true or an exception
	 */
		public static bool AddTestEmail(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "AddTestEmail";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
	 * Creates a list
	 * 
	 * @params		an array of parameters
	 * @returns		list_id or exception
	 */
		public static int Create(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Create";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings, true);

			return int.Parse(methodNode["id"].InnerText);
		}

		/**
	 * Creates a sublist
	 * 
	 * @params		an array of parameters
	 * @returns		sublist_id or an exception
	 */
		public static int CreateSublist(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "CreateSublist";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return int.Parse(methodNode["sublist_id"].InnerText);
		}

		/**
	 * Deletes a list
	 * 
	 * @params		an array of parameters
	 * @returns		true or an exception
	 */
		public static bool Delete(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Delete";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
	 * Deletes an e-mail from a list
	 * 
	 * @params		an array of parameters
	 * @returns		true or an exception
	 */
		public static bool DeleteEmail(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "DeleteEmail";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
	 * Deletes a record from a list
	 * 
	 * @params		an array of parameters
	 * @returns		true or an exception
	 */
		public static bool DeleteRecord(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "DeleteRecord";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
	 * Deletes a sublist from a list
	 *
	 * @params      an array of parameters
	 * @returns     true or an exception
	 */
		public static bool DeleteSublist(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "DeleteSublist";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
	 * Deletes a test e-mail from a list
	 *
	 * @params		an array of parameters
	 * @return		true or an exception
	 */
		public static bool DeleteTestEmail(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "DeleteTestEmail";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
	 * Edits the structure of the list
	 *
	 * @params		an array of parameters
	 * @return		true or an exception
	 */
		public static bool EditStructure(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "EditStructure";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
	 * Gets the list's fields
	 * 
	 * @params		an array of parameters
	 * @returns		an array or an exception
	 */
		public static InOutDictionary GetFields(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetFields";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode, new string[] { }, true);
		}

		/**
	 * Gets the list's informations
	 * 
	 * @params		an array of parameters
	 * @returns		an array or an exception
	 */
		public static InOutDictionary GetInfo(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetInfo";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			if (methodNode["list"] != null) return ParseXML(methodNode["list"]);

			return ParseXML(methodNode["sublist"]);
		}

		/**
	 * Gets the lists with a specified status
	 * 
	 * @params		an array of parameters
	 * @returns		an array or an exception
	 */
		public static InOutDictionary GetList(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetList";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/**
	 * Returns the logs of a list
	 *
	 * @params   array  an array of parameters
	 * @returns  mixed  an array or an exception
	 */
		public static InOutDictionary GetLog(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetLog";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] {
																"log"
															  }
				);
			ChangeKey(res, "log", "logs");

			return res;
		}

		/**
	 * Retrieves a single record from a list
	 *
	 * @params		an array of parameters
	 * @returns		an array or an exception
	 */
		public static InOutDictionary GetRecord(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetRecord";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/**
	 * Gets the sublists of a list
	 * 
	 * @params		an array of parameters
	 * @returns		an array or an exception
	 */
		public static InOutDictionary GetSublists(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetSublists";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[]
														{
															"sublist"
														}
				);
			ChangeKey(res, "sublist", "sublists");

			return res;
		}

		/**
	 * Gets the list of the test e-mails
	 *
	 * @params		an array of parameters
	 * @returns		an array or an exception
	 */
		public static InOutDictionary GetTestEmails(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetTestEmails";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[]
														{
															"test_email"
														}
				);
			ChangeKey(res, "test_email", "test_emails");

			return res;
		}

		/**
	 * Imports records into a list
	 *
	 * @params		an array of parameters
	 * @returns		an array or an exception
	 */
		public static InOutDictionary Import(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Import";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[]
														{
															"record"
														}
				);
			ChangeKey(res, "record", "records");

			return res;
		}

		/**
	 * Sets the parameters for a list
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
	 * Searchs a list after a set of conditions
	 * 
	 * @params		an array of parameters
	 * @returns		an array or an exception
	 */
		public static InOutDictionary Search(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Search";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[]
														{
															"record"
														}
				);
			ChangeKey(res, "record", "records");

			return res;
		}

		/**
	 * Shows a list
	 * 
	 * @params		an array of parameters
	 * @returns		an array or an exception
	 */
		public static InOutDictionary Show(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Show";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[]
														{
															"record"
														}
				);
			ChangeKey(res, "record", "records");

			return res;
		}

		/**
	 * Subscribes an e-mail to a list
	 * 
	 * @params		an array of parameters
	 * @returns		true or an exception
	 */
		public static int SubscribeEmail(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "SubscribeEmail";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return int.Parse(methodNode["record_id"].InnerText);
		}

		/**
	 * Tests a sublist before creation
	 *
	 * @params		an array of parameters
	 * @returns		the results fetching the query or an exception
	 */
		public static InOutDictionary TestSublist(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "TestSublist";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[]
														{
															"record"
														}
				);
			ChangeKey(res, "record", "records");

			return res;
		}

		/**
	 * Unsubscribes an e-mail from a list
	 * 
	 * @params		an array of parameters
	 * @returns		true or an exception
	 */
		public static bool UnsubscribeEmail(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "UnsubscribeEmail";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
	 * Updates a record into a list
	 * 
	 * @params		an array of parameters
	 * @returns		true or an exception
	 */
		public static bool UpdateRecord(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "UpdateRecord";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
	 * Uploads a file into a list
	 * 
	 * @params   array  an array of parameters
	 * @returns  mixed
	 */
		public static InOutDictionary Upload(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Upload";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}
	}
}