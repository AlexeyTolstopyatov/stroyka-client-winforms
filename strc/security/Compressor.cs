using System;
using System.Text;
using System.Threading.Tasks;

namespace strc.security
{
    public class Compressor
    {
        public static Task<string> ToBytes(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            return Task.FromResult(Convert.ToBase64String(bytes));
        }

        public static Task<string> FromBytes(string base64) 
        {
            byte[] bytes = Convert.FromBase64String(base64);
            return Task.FromResult(Encoding.UTF8.GetString(bytes));
        }
    }
}
