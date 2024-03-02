using System.Security.Cryptography;
using System.Text;

namespace BelajarAPI.Helper;

public static class EncryptionHelper
{
	public static string Encrypt(string strPlainText, string strKey)
	{
		string strResult;
		try
		{
			strResult = Convert.ToBase64String(EncryptToByte(strPlainText, strKey));
		}
		catch (Exception)
		{
			strResult = "";
		}
		return strResult;
	}

	public static byte[] EncryptToByte(string strPlainText, string strKey)
	{
		string strGuid = Guid.NewGuid().ToString().Substring(1, 15).Trim();
		strPlainText = strGuid + strPlainText;
		TripleDES des = CreateDES(strKey);
		ICryptoTransform ct = des.CreateEncryptor();
		byte[] input = Encoding.Unicode.GetBytes(strPlainText);
		return ct.TransformFinalBlock(input, 0, input.Length);
	}

	public static string Decrypt(string strEncryptedText, string strKey)
	{
		string strResult = "";
		try
		{
			if (strEncryptedText.Trim() != "")
			{
				byte[] strCypher = Convert.FromBase64String(strEncryptedText);

				TripleDES des = CreateDES(strKey);
				ICryptoTransform ct = des.CreateDecryptor();
				byte[] output = ct.TransformFinalBlock(strCypher, 0, strCypher.Length);
				strResult = Encoding.Unicode.GetString(output);
				if (strResult.Length < 15)
					strResult = "";
				else
					strResult = strResult.Substring(15, strResult.Length - 15);
			}
		}
		catch (Exception)
		{
			strResult = "";
		}
		return strResult;
	}

	static TripleDES CreateDES(string strKey)
	{
		MD5 md5 = new MD5CryptoServiceProvider();
		TripleDES des = new TripleDESCryptoServiceProvider
		{
			Key = md5.ComputeHash(Encoding.Unicode.GetBytes(strKey))
		};
		des.IV = new byte[des.BlockSize / 8];
		return des;
	}
}