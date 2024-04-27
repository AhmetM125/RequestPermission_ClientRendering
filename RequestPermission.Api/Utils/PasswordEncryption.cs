using System.Security.Cryptography;

namespace RequestPermission.Api.Utils;

public static class PasswordEncryption
{
    private static string encryptionKey = "MySecretEncryptionKey123";
    public static string Encrypt(string clearText)
    {
        byte[] clearBytes = System.Text.Encoding.UTF8.GetBytes(clearText);

        using (Aes encryptor = Aes.Create())
        {
            if (encryptor != null)
            {
                encryptor.Mode = CipherMode.ECB;

                encryptor.Key = System.Text.Encoding.UTF8.GetBytes(encryptionKey);

                encryptor.Padding = PaddingMode.PKCS7;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                    clearText = clearText.Replace('+', '-').Replace('/', '_');
                }
            }
        }
        return clearText;
    }
    public static string Decrypt(string cipherText)
    {
        cipherText = cipherText.Replace('-', '+').Replace('_', '/');

        byte[] cipherBytes = Convert.FromBase64String(cipherText);

        using (Aes encryptor = Aes.Create())
        {
            if (encryptor != null)
            {
                encryptor.Key = System.Text.Encoding.UTF8.GetBytes(encryptionKey);

                encryptor.Mode = CipherMode.ECB;

                encryptor.Padding = PaddingMode.PKCS7;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
        return cipherText;
    }
}
