using BlowfishNET;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

// The C# library to access the API that CakeMail provided you is protected by the following licence: http://en.wikipedia.org/wiki/BSD_licenses
namespace CakeLibrary
{
	public class CakeCrypt
	{
		public SymmetricAlgorithm cryptor;

		public CakeCrypt(SymmetricAlgorithm cryptor)
		{
			this.cryptor = cryptor;
		}

		public CakeCrypt(string cryptAlg, string cryptMode, string interfaceKey)
		{
			cryptor = GetSymmetricAlgorithm(cryptAlg, cryptMode);
			cryptor.Key = Encoding.Default.GetBytes(interfaceKey);
			cryptor.GenerateIV();
		}

		/**
		 * Encrypts some data with a given key
		 *
		 * @data
		 * @key
		 * @returns		the encrypted data in binary hex format
		 */

		public string CakeEncryptHex(string data)
		{
			return ToHex(Encoding.Default.GetBytes(CakeEncrypt(data)));
		}

		public string CakeEncrypt(string data)
		{
			return Encoding.Default.GetString(CakeEncrypt(Encoding.Default.GetBytes(data)));
		}

		public byte[] CakeEncrypt(byte[] data)
		{
			int len = data.Length;
			int lenAligned = AdjustSize(len, cryptor.BlockSize);

			byte[] workData = new byte[lenAligned];
			Array.Clear(workData, 0, lenAligned);
			Array.Copy(data, workData, len);

			ICryptoTransform cryptoTransform = cryptor.CreateEncryptor();
			cryptoTransform.TransformBlock(workData, 0, lenAligned, workData, 0);

			return workData;
		}

		/**
		 * Decrypts some data with a given key
		 *
		 * @data	in hex encrypted format
		 * @key
		 * @returns	the decrypted data
		 */

		public string CakeDecryptHex(string data)
		{
			return Encoding.Default.GetString(CakeDecrypt(FromHex(data))).Replace("\0", "");
		}

		public string CakeDecrypt(string data)
		{
			return Encoding.Default.GetString(CakeDecrypt(Encoding.Default.GetBytes(data))).Replace("\0", "");
		}

		public byte[] CakeDecrypt(byte[] data)
		{
			int blockSize;
			if (cryptor.Mode != CipherMode.ECB)
			{
				blockSize = cryptor.BlockSize / 8;
				byte[] IV = new byte[blockSize];
				Array.Copy(data, IV, blockSize);
				cryptor.IV = IV;
			}
			else blockSize = 0;

			int len = data.Length - blockSize;
			int lenAligned = AdjustSize(len, cryptor.BlockSize);

			byte[] inputData = new byte[lenAligned];
			Array.Clear(inputData, 0, lenAligned);
			Array.Copy(data, blockSize, inputData, 0, len);

			byte[] outputData = new byte[lenAligned];
			Array.Clear(outputData, 0, lenAligned);

			ICryptoTransform cryptoTransform = cryptor.CreateDecryptor();
			cryptoTransform.TransformBlock(inputData, 0, lenAligned, outputData, 0);

			return outputData;
		}

		private static int AdjustSize(int arg, int to)
		{
			to = to / 8;

			int res = arg & ~(to - 1);
			if (res < arg) res += to;

			return res;
		}

		public static string ToHex(byte[] data)
		{
			StringBuilder res = new StringBuilder(data.Length * 2);
			foreach (byte b in data)
			{
				string one = Convert.ToString(b, 16);
				if (one.Length == 1) one = "0" + one;
				res.Append(one);
			}

			return res.ToString();
		}

		public static byte[] FromHex(string data)
		{
			List<byte> res = new List<byte>(data.Length / 2);
			int iIndex = 0;
			while (iIndex < data.Length)
			{
				res.Add(Convert.ToByte(data.Substring(iIndex, 2), 16));
				iIndex += 2;
			}

			return res.ToArray();
		}

		private static SymmetricAlgorithm GetSymmetricAlgorithm(string algorithmName, string algorithmMode)
		{
			SymmetricAlgorithm symmetricAlgorithm;

			switch (algorithmName)
			{
				case "blowfish":
					{
						symmetricAlgorithm = new BlowfishAlgorithm();
						break;
					}

				case "tripledes":
					{
						symmetricAlgorithm = new TripleDESCryptoServiceProvider();
						break;
					}

				default: throw new CakeException(CakeErrors.ENCRYPTION_ERROR);
			}

			switch (algorithmMode)
			{
				case "ecb":
					{
						symmetricAlgorithm.Mode = CipherMode.ECB;
						break;
					}

				case "cbc":
					{
						symmetricAlgorithm.Mode = CipherMode.CBC;
						break;
					}

				default: throw new CakeException(CakeErrors.ENCRYPTION_ERROR);
			}

			return symmetricAlgorithm;
		}
	}
}