using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    class Program
    {
        private const string ClientId = "your client ID";

        static void Main()
        {
            // Step 1 - Authorization
            //var uri = "https://login.live.com/oauth20_authorize.srf";

            //var authorizeUri = new StringBuilder(uri);

            //authorizeUri.AppendFormat("?client_id={0}&", ClientId);
            //authorizeUri.AppendFormat("scope={0}&", "wl.signin%20wl.work_profile%20wl.postal_addresses");
            //authorizeUri.AppendFormat("response_type={0}&", "token");
            //authorizeUri.AppendFormat("redirect_uri={0}", UrlEncode("http://redirect_uri.com"));

            //var startInfo = new ProcessStartInfo();
            //startInfo.FileName = authorizeUri.ToString();
            //Process.Start(startInfo);

        
            // Step 2 - Get User Profile
            var access_token = "your access token";

            //http://apis.live.net/v5.0/me?access_token=ACCESS_TOKEN

            var requestUri = new StringBuilder("https://apis.live.net/v5.0/me");
            requestUri.AppendFormat("?access_token={0}", access_token);
            var request = (HttpWebRequest)WebRequest.Create(requestUri.ToString());
            request.Method = "GET";

            var response = (HttpWebResponse) request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var json = reader.ReadToEnd();

                var user = JsonConvert.DeserializeObject<User>(json);

                Console.WriteLine(user.Id);
                Console.WriteLine(user.Name);
                Console.WriteLine(user.FirstName);
                Console.WriteLine(user.LastName);
                Console.WriteLine(user.Gender);
                Console.WriteLine(user.Locale);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static string UrlEncode(string s)
        {
            char[] temp = HttpUtility.UrlEncode(s).ToCharArray();
            for (int i = 0; i < temp.Length - 2; i++)
            {
                if (temp[i] == '%')
                {
                    temp[i + 1] = char.ToUpper(temp[i + 1]);
                    temp[i + 2] = char.ToUpper(temp[i + 2]);
                }
            }

            var values = new Dictionary<string, string>
            {
                { "!", "%21" },
                { "#", "%23" },
                { "$", "%24" },
                { "&", "%26" },
                { "'", "%27" },
                { "(", "%28" },
                { ")", "%29" },
                { "*", "%2A" },
                { "+", "%2B" },
                { ",", "%2C" },
                { "/", "%2F" },
                { ":", "%3A" },
                { ";", "%3B" },
                { "=", "%3D" },
                { "?", "%3F" },
                { "@", "%40" },
                { "[", "%5B" },
                { "]", "%5D" }
            };

            var data = new StringBuilder(new string(temp));
            foreach (string character in values.Keys)
            {
                data.Replace(character, values[character]);
            }

            return data.ToString();
        }
    }
}
