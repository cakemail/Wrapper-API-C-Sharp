using System;
using System.Web;
using System.Xml;
using InOutDictionary = System.Collections.Generic.Dictionary<string, object>;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeObject
	{
		public static XmlNode Proccess(string className, string methodName, InOutDictionary parameters, CakeSettings cakeSettings, bool reverseData = false)
		{
			CakeXML cakeXML = new CakeXML(cakeSettings);

			cakeXML.Init();
			cakeXML.AddClass(className, cakeSettings.DEFAULT_LOCALE);
			cakeXML.AddMethod(methodName);

			cakeXML.AddParameters(parameters, reverseData);

			cakeXML.CloseMethod();
			cakeXML.CloseClass();
			cakeXML.Close();

			cakeXML.ExecXML();

			XmlNode resultNode = cakeXML.GetResponse()["result"];
			CheckError(resultNode, cakeXML.GetXML());

			XmlNode methodNode = GetXMLMethod(resultNode, className, methodName);
			CheckError(methodNode, cakeXML.GetXML());

			return methodNode;
		}

		public static XmlNode GetXMLMethod(XmlNode root, string className, string methodName)
		{
			foreach (XmlNode classNode in root)
			{
				if (classNode.Name == "class" && classNode.Attributes["type"].InnerText == className)
				{
					foreach (XmlNode methodNode in classNode)
						if (methodNode.Name == "method" && methodNode.Attributes["type"].InnerText == methodName) return methodNode;
				}
			}

			return null;
		}

		public static void CheckError(XmlNode method, string xml)
		{
			if (method["error_code"] != null)
				throw new CakeException(method["error_code"].InnerText, HttpUtility.UrlDecode(method["error_message"].InnerText + " - API Call: " + xml));
		}

		public static InOutDictionary ParseXML(XmlNode node)
		{
			return ParseXML(node, new string[] { });
		}

		public static InOutDictionary ParseXML(XmlNode node, string[] subListNames)
		{
			return ParseXML(node, subListNames, false);
		}

		public static InOutDictionary ParseXML(XmlNode node, string[] subListNames, bool reverseData)
		{
			InOutDictionary res = new InOutDictionary();

			foreach (XmlNode itemNode in node)
			{
				string itemName = itemNode.Name;

				if (itemNode.Name == "data")
				{
					if (reverseData) res[HttpUtility.UrlDecode(itemNode.InnerText)] = HttpUtility.UrlDecode(itemNode.Attributes["type"].InnerText);
					else res[itemNode.Attributes["type"].InnerText] = HttpUtility.UrlDecode(itemNode.InnerText);
				}
				else
				{
					if (itemNode.ChildNodes.Count > 1)
					{
						InOutDictionary resList;

						if (res.ContainsKey(itemName) && (res[itemName] is InOutDictionary))
							resList = (InOutDictionary)res[itemName];
						else
						{
							resList = new InOutDictionary();
							res[itemName] = resList;
						}

						resList[resList.Count.ToString()] = ParseXML(itemNode, subListNames);
					}
					else
					{
						InOutDictionary resList;

						if (res.ContainsKey(itemName) || (Array.IndexOf(subListNames, itemName) > -1))
						{
							if (res.ContainsKey(itemName) && (res[itemName] is InOutDictionary))
								resList = (InOutDictionary)res[itemName];
							else
							{
								resList = new InOutDictionary();
								if (res.ContainsKey(itemName)) resList.Add("0", res[itemName]);
								res[itemName] = resList;
							}

							resList[resList.Count.ToString()] = HttpUtility.UrlDecode(itemNode.InnerText);
						}
						else res[itemName] = HttpUtility.UrlDecode(itemNode.InnerText);
					}
				}
			}

			return res;
		}

		public static void ChangeKey(InOutDictionary res, string oldName, string newName)
		{
			if (res.ContainsKey(oldName))
			{
				res[newName] = res[oldName];
				res.Remove(oldName);
			}
		}

		/*
		public static InOutDictionary ParamKeysToLowerCase(InOutDictionary pars)
		{
		  InOutDictionary parsOut = new InOutDictionary();
		  foreach (KeyValuePair<string, object> par in pars) parsOut[par.Key.ToLower()] = par.Value;

		  return parsOut;
		}
	*/
	}
}