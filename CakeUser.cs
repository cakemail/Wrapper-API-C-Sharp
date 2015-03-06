using System.Xml;
using InOutDictionary = System.Collections.Generic.Dictionary<string, object>;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeUser : CakeObject
	{
		private const string className = "ClassUser";

		/* Checks for a permission on a user */
		public static bool CheckPermission(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "CheckPermission";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
	 * Creates a user
	 * 
	 * @params		an array of parameters
	 * @returns		an array or an exception
	 */
		public static InOutDictionary Create(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Create";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/**
		 * Gets the informations about a user
		 *
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static bool Delete(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Delete";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
		 * Gets the informations about a user
		 *
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetInfo(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetInfo";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] {
																"user"
															  }
				);
			ChangeKey(res, "user", "users");

			return ParseXML(methodNode);
		}

		/**
		 * Gets the list with a specified status
		 * 
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetList(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetList";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] {
																"user",
																"group_id"
															  }
			  );
			ChangeKey(res, "user", "users");

			return res;
		}

		/**
		 * Recovers a password for a user
		 *
		 * @params		an array of parameters
		 * @returns		true or an exception
		 */
		public static bool PasswordRecovery(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "PasswordRecovery";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
		 * Logs-in a user
		 *
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary Login(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Login";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/**
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
	}
}