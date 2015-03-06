using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using InOutDictionary = System.Collections.Generic.Dictionary<string, object>;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeXML
	{
		protected string classes;
		protected bool closed_xml;
		protected int depth;
		protected XmlDocument response;
		protected string x_i;
		protected string x_v;
		protected string xml;
		private CakeSettings _cakeSettings;

		public CakeXML(CakeSettings cakeSettings)
		{
			_cakeSettings = cakeSettings;
		}

		/**
		* Adds a new class into the xml' structure
		*
		* @class		the class' name
		*/
		public void AddClass(string className, string locale)
		{
			if (closed_xml) throw new CakeException(CakeErrors.CLOSED_XML);

			Insert("<class type=\"" + HttpUtility.UrlPathEncode(className) + "\" locale=\"" + HttpUtility.UrlPathEncode(locale) + "\">");
			depth += 2;
		}

		/**
		* Adds a new method to a class
		*
		* @method		the method's name
		*/
		public void AddMethod(string methodName)
		{
			if (closed_xml) throw new CakeException(CakeErrors.CLOSED_XML);

			Insert("<method type=\"" + HttpUtility.UrlPathEncode(methodName) + "\">");
			depth += 2;
		}

		/**
	   * Adds a new parameter into a method
	   *
	   * @parameters	the parameters
	   */
		public void AddParameters(InOutDictionary parameters, bool reverseData)
		{
			if (closed_xml) throw new CakeException(CakeErrors.CLOSED_XML);

			foreach (KeyValuePair<string, object> parameter in parameters)
			{
				if (parameter.Value is InOutDictionary)
				{
					foreach (KeyValuePair<string, object> customParameter in (InOutDictionary)parameter.Value)
					{
						if (customParameter.Value is InOutDictionary)
						{
							AddTag(parameter.Key);
							foreach (KeyValuePair<string, object> customParameter2 in (InOutDictionary)customParameter.Value)
								AddCustomParameter(customParameter2.Key, customParameter2.Value);
							CloseTag(parameter.Key);
						}
						else
						{
							if (reverseData) AddCustomParameter(customParameter.Value.ToString(), customParameter.Key);
							else AddCustomParameter(customParameter.Key, customParameter.Value);
						}
					}
				}
				else if (parameter.Value is Array)
				{
					foreach (object customParameter in (Array)parameter.Value)
					{
						AddParameter(parameter.Key, customParameter);
					}
				}
				else AddParameter(parameter.Key, parameter.Value);
			}
		}

		/**
		* Adds a new parameter into a method
		*
		* @name		the parameter's name
		* @value		the parameters's value
		*/
		public void AddParameter(string name, object value)
		{
			if (closed_xml) throw new CakeException(CakeErrors.CLOSED_XML);

			string val = value.ToString();
			if (value is bool) val = val.ToLowerInvariant();

			Insert("<" + name + ">" + EncodeContent(HttpUtility.UrlPathEncode(val)) + "</" + name + ">");
		}

		/**
		* Adds a new custom parameter into a method
		*
		* @type		the parameter's type
		* @value		the parameters's value
		*/
		public void AddCustomParameter(string type, object value)
		{
			if (closed_xml) throw new CakeException(CakeErrors.CLOSED_XML);

			string val = value.ToString();
			if (value is bool) val = val.ToLowerInvariant();

			Insert("<data type=\"" + HttpUtility.HtmlEncode(HttpUtility.UrlPathEncode(type)) + "\">" + HttpUtility.HtmlEncode(HttpUtility.UrlPathEncode(val)) + "</data>");
		}

		/**
		* Adds a new tag
		*/
		public void AddTag(string tagName)
		{
			if (closed_xml) throw new CakeException(CakeErrors.CLOSED_XML);

			Insert("<" + tagName + ">");
			depth += 2;
		}

		/**
		* Closes the xml' structure
		*/
		public void Close()
		{
			if (closed_xml) throw new CakeException(CakeErrors.CLOSED_XML);

			depth -= 2;
			Insert("</body>");

			closed_xml = true;
		}

		/**
		* Closes a class
		*/
		public void CloseClass()
		{
			if (closed_xml) throw new CakeException(CakeErrors.CLOSED_XML);

			depth -= 2;
			Insert("</class>");
		}

		/**
		* Closes a method
		*/
		public void CloseMethod()
		{
			if (closed_xml) throw new CakeException(CakeErrors.CLOSED_XML);

			depth -= 2;
			Insert("</method>");
		}

		/**
		* Closes a tag
		*/
		public void CloseTag(string tagName)
		{
			if (closed_xml) throw new CakeException(CakeErrors.CLOSED_XML);

			depth -= 2;
			Insert("</" + tagName + ">");
		}

		/**
		* Executes the xml
		*/
		public void ExecXML()
		{
			if (!closed_xml) throw new CakeException(CakeErrors.UNCLOSED_XML);

			DateTime startTime = DateTime.Now;

			CakeDebug.AddMessage(xml, _cakeSettings);

			CakeCrypt cakeCrypt = new CakeCrypt(_cakeSettings.CAKE_MCRYPT_ALG, _cakeSettings.CAKE_MCRYPT_MODE, _cakeSettings.CAKE_INTERFACE_KEY);

			cakeCrypt.cryptor.IV = Encoding.Default.GetBytes("00000000");
			string xml_req = cakeCrypt.CakeEncryptHex(xml);

			string IV = "";
			if (cakeCrypt.cryptor.Mode != CipherMode.ECB) IV = CakeCrypt.ToHex(cakeCrypt.cryptor.IV);

			using (WebClient webClient = new WebClient())
			{
				webClient.Headers.Add("user-agent", "CakeLibrary .NET " + _cakeSettings.CAKE_VERSION);

				NameValueCollection data = new NameValueCollection();
				data.Add("id", _cakeSettings.CAKE_INTERFACE_ID.ToString());
				data.Add("alg", _cakeSettings.CAKE_MCRYPT_ALG);
				data.Add("mode", _cakeSettings.CAKE_MCRYPT_MODE);
				data.Add("request", IV + xml_req);
				CakeDebug.AddMessage(IV + xml_req, _cakeSettings);

				string resXML = Encoding.Default.GetString(webClient.UploadValues(_cakeSettings.API_CAKE_URL, "POST", data));

				resXML = resXML.Contains("<?xml") ? resXML.Substring(resXML.IndexOf("<?xml")) : cakeCrypt.CakeDecryptHex(resXML);

				CakeDebug.AddMessage(resXML, _cakeSettings);

				response = new XmlDocument();
				response.LoadXml(resXML);
			}

			DateTime endTime = DateTime.Now;

			CakeDebug.AddMessage("Spent time: " + (endTime - startTime) + " s \r\n", _cakeSettings);
		}

		/**
		* Returns the xml structure
		*/
		public string GetXML()
		{
			return xml;
		}

		/**
		* Returns the XML response
		*/
		public XmlDocument GetResponse()
		{
			return response;
		}

		/**
		* Initialises the xml' structure
		*/
		public void Init()
		{
			if (xml == null)
			{
				Insert("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
				Insert("<body version=\"" + _cakeSettings.CAKE_VERSION + "\">");
				depth += 2;
			}
		}

		/**
		* Insert a new line with identation
		*
		* @value
		* @returns	an exception in case of error
		*/
		protected void Insert(string value)
		{
			if (closed_xml) throw new CakeException(CakeErrors.CLOSED_XML);

			for (int i = 0; i < depth; i++) xml += " ";

			xml += value + "\n";
		}

		/**
		* Encode a string into a HTML safe string
		*/
		private static String EncodeContent(string str)
		{
			if (string.IsNullOrEmpty(str)) return "";

			StringBuilder output = new StringBuilder((int)(str.Length * 1.1));

			foreach (char c in str)
			{
				switch (c)
				{
					case '&':
						output.Append("&amp;");
						break;
					case '>':
						output.Append("&gt;");
						break;
					case '<':
						output.Append("&lt;");
						break;
					case '"':
						output.Append("&quot;");
						break;
					default:
						Int32 iCharValue = Convert.ToInt32(c);
						if (iCharValue > 127)
						{
							output.Append("&#");
							output.Append(iCharValue.ToString());
							output.Append(";");
						}
						else
						{
							output.Append(c);
						}
						break;
				}
			}
			return output.ToString();
		}
	}
}