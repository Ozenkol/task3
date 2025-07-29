using System.Security.Cryptography;
using System.Text;

namespace Model;

public static class Encryption
{
    private static string secretKey = null;
    private static string hmac = null;

    public static string Encode(string input, string secretKey)
    {
        byte[] key = Encoding.ASCII.GetBytes(secretKey);
        HMACSHA1 myhmacsha1 = new(key);
        byte[] byteArray = Encoding.ASCII.GetBytes(input);
        MemoryStream stream = new(byteArray);
        return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
    }

    public static void SetSecretWord(string secretWord) {
        secretKey = secretWord;
    }

    public static string GetHMAC() {
        return hmac;
    }

    public static void GenerateHMAC(string input)
    {
        hmac = Encode(secretKey, input);
    }
}