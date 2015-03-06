using System.Xml;
using InOutDictionary = System.Collections.Generic.Dictionary<string, object>;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeGroup : CakeObject
	{
		private const string className = "ClassGroup";

		/**
		 * Adds a user to a group
		 *
		 * @params		an array of parameters
		 * @returns		true or an exception
		 */
		public static bool AddUser(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "AddUser";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
		 * Creates a new group
		 * 
		 * @params		an array of paramaters
		 * @returns		group_id or an exception
		 */
		public static int Create(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Create";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return int.Parse(methodNode["id"].InnerText);
		}

		/**
		 * Deletes a group
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
		 * Gets the informations of a group
		 * 
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetInfo(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetInfo";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "permission" });
			ChangeKey(res, "permission", "permissions");

			return res;
		}

		/**
		 * Returns the list of the groups
		 * 
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetList(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetList";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "group" });
			ChangeKey(res, "group", "groups");

			return res;
		}

		/**
		 * Removes a user from a group
		 *
		 * @params		an array of parameters
		 * @returns		true or an exception
		 */
		public static bool RemoveUser(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "RemoveUser";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
		 * Sets the informations of a group
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
	}
}