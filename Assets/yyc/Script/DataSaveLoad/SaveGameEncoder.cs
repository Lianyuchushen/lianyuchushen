using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;

public static class SaveGameEncoder {

    public static string Encode (string input)
    {
        return Convert.ToBase64String (Encoding.UTF8.GetBytes (input));
    }

    public static string Decode (string input)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(input));
    }
}
