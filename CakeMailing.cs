using System.Xml;
using InOutDictionary = System.Collections.Generic.Dictionary<string, object>;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeMailing : CakeObject
	{
		private const string className = "ClassMailing";

		/**
		 * Creates a mailing
		 * 
		 * @params		an array of parameters
		 * @returns		mailing_id or an exception
		 */
		public static int Create(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Create";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return int.Parse(methodNode["id"].InnerText);
		}

		/**
		 * Deletes a mailing
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
		 * Forwards a mailing
		 * 
		 * @params   array  an array of parameters
		 * @returns  mixed  true or an exception
		 */
		public static bool Forward(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Forward";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
		 * Gets the formated email message
		 *
		 * @params		an array of parameters
		 * @returns		the message or an exception
		 */
		public static InOutDictionary GetEmailMessage(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetEmailMessage";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/**
		 * Gets the formated HTML message
		 *
		 * @params		an array of parameters
		 * @returns		the message or an exception
		 */
		public static string GetHtmlMessage(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetHtmlMessage";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return methodNode["html_message"].InnerText;
		}

		/**
		 * Gets a mailing
		 * 
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetInfo(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetInfo";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] { "mailing" });
			ChangeKey(res, "mailing", "mailings");

			return ParseXML(methodNode);
		}

		/**
		 * Returns the list of links for a mailing
		 *
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetLinks(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetLinks";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] {
																"link"
															  }
			  );
			ChangeKey(res, "link", "links");

			return res;
		}

		/**
		 * Returns the total and unique counts of openings for mailing's links
		 *
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetLinksLog(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetLinksLog";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] {
																"link"
															  }
			  );
			ChangeKey(res, "link", "links");

			return res;
		}

		/**
		 * Retrieves the list of mailings
		 * 
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetList(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetList";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] {
																"mailing"
															  }
			  );
			ChangeKey(res, "mailing", "mailings");

			return res;
		}

		/**
		 * Returns the logs of a mailing
		 *
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetLog(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetLog";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);
			InOutDictionary res = ParseXML(methodNode, new string[] {
																"count",
																"log"
															  }
			  );
			ChangeKey(res, "log", "logs");

			return res;
		}

		/**
		 * Gets a mailing information
		 * 
		 * @params		an array of parameters
		 * @returns		an array or an exception
		 */
		public static InOutDictionary GetStats(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetStats";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return ParseXML(methodNode);
		}

		/**
		 * Gets the formated TEXT message
		 *
		 * @params		an array of parameters
		 * @returns		the message or an exception
		 */
		public static string GetTextMessage(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "GetTextMessage";

			XmlNode methodNode = Proccess(className, methodName, parameters, cakeSettings);

			return methodNode["text_message"].InnerText;
		}

		/**
		 * Resumes a suspended mailing
		 * 
		 * @params		an array of parameters
		 * @returns		true or an exception
		 */
		public static bool Resume(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Resume";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
		 * Schedules a mailing
		 * 
		 * @params		an array of parameters
		 * @returns		true or an exception
		 */
		public static bool Schedule(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Schedule";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
		 * Suspends a mailing
		 * 
		 * @params		an array of parameters
		 * @returns		true or an exception
		 */
		public static bool Suspend(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Suspend";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
		 * Sends a test email
		 * 
		 * @params		an array of parameters
		 * @returns		true or an exception
		 */
		public static bool SendTestEmail(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "SendTestEmail";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}

		/**
		 * Sets the parameters for a mailing
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
		 * Unschedules a mailing
		 * 
		 * @params		an array of parameters
		 * @returns		true or an exception
		 */
		public static bool Unschedule(CakeSettings cakeSettings, InOutDictionary parameters)
		{
			const string methodName = "Unschedule";

			Proccess(className, methodName, parameters, cakeSettings);

			return true;
		}
	}
}