using System.Xml;
using InOutDictionary = System.Collections.Generic.Dictionary<string, object>;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeCampaign : CakeObject
	{
		private const string className = "ClassCampaign";

		/**
		 * Creates a new campaign
		 *
		 * @params		an array of parameters
		 * @returns		the new campaign's id or an exception
		 */
		public static int Create(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Create";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return int.Parse(methodNode["id"].InnerText);
		}

		/**
		 * Deletes a campaign
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
		 * gets the list of campaigns specified by status
		 *
		 * @params		an array of parameters
		 * @returns		an array with the campaigns or an exception
		 */
		public static InOutDictionary GetList(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetList";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "campaign" });
			ChangeKey(res, "campaign", "campaigns");

			return res;
		}

		/**
		 * retrieves the campaign's infos
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
		 * gets the count of mailings assigned to a campaign
		 *
		 * @params		an array of parameters
		 * @returns		an integer or an exception
		 */
		public static int GetMailingsCount(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			throw new CakeException("Not realized");
		}

		/**
		 * Sets the parameters for a campaign
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