using System;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public static class CakeErrors
	{
		public static CakeError CLOSED_XML = new CakeError(500, "The xml is closed; no further modifications");
		public static CakeError DECRYPTION_ERROR = new CakeError(502, "Decryption error");
		public static CakeError ENCRYPTION_ERROR = new CakeError(503, "Encryption error");
		public static CakeError UNCLOSED_XML = new CakeError(501, "The xml is not closed");
		public static CakeError XML_PARSE_ERROR = new CakeError(504, "Error parsing the xml structure");

		#region Nested type: CakeError

		public struct CakeError
		{
			public int Code;
			public string Message;

			public CakeError(int code, string message)
			{
				Code = code;
				Message = message;
			}
		}

		#endregion
	}

	public class CakeException : ApplicationException
	{
		public int Code = 0;

		public CakeException(CakeErrors.CakeError cakeError)
			: base(cakeError.Message)
		{
			Code = cakeError.Code;
		}

		public CakeException(int code, string message)
			: base(message)
		{
			Code = code;
		}

		public CakeException(string code, string message)
			: base(message)
		{
			Code = int.Parse(code);
		}

		public CakeException(string message)
			: base(message)
		{
		}
	}
}