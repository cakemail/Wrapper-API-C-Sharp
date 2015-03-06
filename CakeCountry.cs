using System.Xml;
using InOutDictionary = System.Collections.Generic.Dictionary<string, object>;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeCountry : CakeObject
	{
		private const string className = "ClassCountry";

		/**
		 * Gets the list of countries
		 * 
		 * @params		an empty array
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetList(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetList";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "country" });
			ChangeKey(res, "country", "countries");

			return res;
		}

		/**
		 * Gets the list of provinces for a specified country
		 * 
		 * @params		an array of paramaters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetProvinces(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetProvinces";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "province" });
			ChangeKey(res, "province", "provinces");

			return res;
		}
	}
}