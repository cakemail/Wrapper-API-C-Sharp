
// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeSettings
	{
		public string API_CAKE_URL { get; set; }
		public int CAKE_INTERFACE_ID { get; set; }
		public string CAKE_INTERFACE_KEY { get; set; }
		public string CAKE_MCRYPT_ALG { get; set; }
		public string CAKE_MCRYPT_MODE { get; set; }
		public string CAKE_VERSION { get; set; }
		public bool DEBUG { get; set; }
		public string DEFAULT_LOCALE { get; set; }
		public string LOG_FILENAME { get; set; }
		public string UserEmail { get; set; }
		public string UserPassword { get; set; }
	}
}