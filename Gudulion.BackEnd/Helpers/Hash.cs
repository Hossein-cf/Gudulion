namespace Sweet.BackEnd.Helpers;

using System.Security.Cryptography;
using System.Text;

public class Hash : IHash
{
    public string HashText(string text)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            var hashedString = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hashedString;
        }
    }
}

public interface IHash
{
    public string HashText(string text);
}