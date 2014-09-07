using System;
using System.Text;

namespace CompleteSample.Authentication
{
    public class BasicAuthenticationCredentials
    {
        private static readonly char[] BlankChar = { ' ' };
        private static readonly char[] ColonChar = { ':' };

        public string UserName { get; private set; }
        public string Password { get; private set; }

        public static bool TryParse(string header, out BasicAuthenticationCredentials authenticationCredentials)
        {
            authenticationCredentials = null;

            if (header == null)
            {
                return false;
            }

            var values = header.Split(BlankChar, StringSplitOptions.RemoveEmptyEntries);

            if (values.Length != 2 || values[0] != "Basic")
            {
                return false;
            }

            var tuple = DecodeBase64(values[1]).Split(ColonChar);

            authenticationCredentials = new BasicAuthenticationCredentials
            {
                UserName = tuple[0],
                Password = tuple[1],
            };
            return true;
        }

        private static string DecodeBase64(string source)
        {
            var data = Convert.FromBase64String(source);
            var result = Encoding.UTF8.GetString(data);

            return result;
        }
    }
}