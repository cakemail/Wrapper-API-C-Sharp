using System.Xml;
using InOutDictionary = System.Collections.Generic.Dictionary<string, object>;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeSuppressionList : CakeObject
	{
		private const string className = "ClassSuppressionList";

		/* Imports one or more domains into the suppression list */
		public static InOutDictionary ImportDomains(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "ImportDomains";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "record" });
			ChangeKey(res, "record", "records");

			return res;
		}

		/* Imports one or more emails into the suppression list */
		public static InOutDictionary ImportEmails(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "ImportEmails";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "record" });
			ChangeKey(res, "record", "records");

			return res;
		}

		/* Imports one or more local-parts into the suppression list */
		public static InOutDictionary ImportLocalparts(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "ImportLocalparts";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "record" });
			ChangeKey(res, "record", "records");

			return res;
		}

		/* Exports the domains from the suppression list */
		public static InOutDictionary ExportDomains(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "ExportDomains";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/* Exports the emails from the suppression list */
		public static InOutDictionary ExportEmails(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "ExportEmails";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/* Exports the local-parts from the suppression list */
		public static InOutDictionary ExportLocalparts(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "ExportLocalparts";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/* Deletes one or more domains from the suppression list */
		public static InOutDictionary DeleteDomains(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "DeleteDomains";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "record" });
			ChangeKey(res, "record", "records");

			return res;
		}

		/* Deletes one or more emails from the suppression list */
		public static InOutDictionary DeleteEmails(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "DeleteEmails";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "record" });
			ChangeKey(res, "record", "records");

			return res;
		}

		/* Deletes one or more local-parts from the suppression list */
		public static InOutDictionary DeleteLocalparts(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "DeleteLocalparts";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "record" });
			ChangeKey(res, "record", "records");

			return res;
		}
	}
}