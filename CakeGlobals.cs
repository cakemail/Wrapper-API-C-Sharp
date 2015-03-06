using System.Configuration;

namespace CakeLibrary
{
	public static class CakeGlobals
	{
		public static string API_CAKE_URL = "http://api.cakemail.com";
		public static int CAKE_INTERFACE_ID = 0;
		public static string CAKE_INTERFACE_KEY = "";
		public static string CAKE_MCRYPT_ALG = "blowfish"; // choose one of these: blowfish, tripledes
		public static string CAKE_MCRYPT_MODE = "ecb"; // choose one of these: ecb, cbc
		public static string CAKE_VERSION = "1.0";
		public static bool DEBUG = false;
		public static string DEFAULT_LOCALE = "en_US";
		public static string LOG_FILENAME;

		/**
		 * This is no longer necessary since we get the settings from Azure
		 * These value are initialized in CakeUserAuth.cs in the CakeLibraryWrapper projet
		 * 
		static CakeGlobals()
		{
			Load();
		}
		 */

		/**
		 * Load the properties from App.config
		 *
		 * Rename App.config.template to App.config (e.g. CakeBench.exe.config),
		 * fill each parameter and use CakeGlobals.Load()
		 */
		public static void Load()
		{
			AppSettingsReader propsReader = new AppSettingsReader();

			CAKE_VERSION = ((string)propsReader.GetValue("CAKE_VERSION", typeof(string))).Trim();
			API_CAKE_URL = ((string)propsReader.GetValue("API_CAKE_URL", typeof(string))).Trim();
			CAKE_MCRYPT_ALG = ((string)propsReader.GetValue("CAKE_MCRYPT_ALG", typeof(string))).Trim();
			CAKE_MCRYPT_MODE = ((string)propsReader.GetValue("CAKE_MCRYPT_MODE", typeof(string))).Trim();
			CAKE_INTERFACE_KEY = ((string)propsReader.GetValue("CAKE_INTERFACE_KEY", typeof(string))).Trim();
			CAKE_INTERFACE_ID = int.Parse(((string)propsReader.GetValue("CAKE_INTERFACE_ID", typeof(string))).Trim());
			DEFAULT_LOCALE = ((string)propsReader.GetValue("DEFAULT_LOCALE", typeof(string))).Trim();
			DEBUG = bool.Parse(((string)propsReader.GetValue("DEBUG", typeof(string))).Trim());
			LOG_FILENAME = ((string)propsReader.GetValue("LOG_FILENAME", typeof(string))).Trim();
		}
	}
}