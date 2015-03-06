using System.Xml;
using InOutDictionary = System.Collections.Generic.Dictionary<string, object>;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeTemplate : CakeObject
	{
		private const string className = "ClassTemplate";

		/**
		 * Creates a new template
		 *
		 * @params		an array of parameters
		 * @returns		the new template's id or an exception
		 */
		public static int Create(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Create";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return int.Parse(methodNode["id"].InnerText);
		}

		/**
		 * Deletes a template
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
		 * gets the list of templates specified by status
		 *
		 * @params		an array of parameters
		 * @returns		an array with the templates or an exception
		 */
		public static InOutDictionary GetList(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetList";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "template" });
			ChangeKey(res, "template", "templates");

			return res;
		}

		/**
		 * retrieves the template's infos
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
		 * Sets the parameters for a template
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