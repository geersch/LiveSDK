using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication
{
    class Program
    {
        private const string ClientId = "Your Client ID";
        private const string RedirectUri = "http://your_redirect_uri.com";
        private const string AccessToken = "Your Access Token";

        private static void AuthorizeApplication()
        {
            const string uri = "https://login.live.com/oauth20_authorize.srf";

            var authorizeUri = new StringBuilder(uri);

            authorizeUri.AppendFormat("?client_id={0}&", ClientId);
            authorizeUri.AppendFormat("scope={0}&", "wl.signin%20wl.skydrive%20wl.photos");
            authorizeUri.AppendFormat("response_type={0}&", "token");
            authorizeUri.AppendFormat("redirect_uri={0}", UrlEncode(RedirectUri));

            var startInfo = new ProcessStartInfo { FileName = authorizeUri.ToString() };
            Process.Start(startInfo);
        }

        private static void ListFolders()
        {
            var requestUri = new StringBuilder("https://apis.live.net/v5.0/me/skydrive/files");
            requestUri.AppendFormat("?access_token={0}", AccessToken);
            var request = (HttpWebRequest)WebRequest.Create(requestUri.ToString());
            request.Method = "GET";

            var response = (HttpWebResponse)request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var json = reader.ReadToEnd();

                var skyDrive = JsonConvert.DeserializeObject<SkyDrive>(json);

                foreach (var folder in skyDrive.Folders)
                {
                    Console.WriteLine(String.Format("{0}: {1}", folder.Id, folder.Name));
                }
            }
        }

        private static void ListOtherContentTypes()
        {
            var requestUri = new StringBuilder("https://apis.live.net/v5.0/me/skydrive/files");
            requestUri.AppendFormat("?access_token={0}", AccessToken);
            var request = (HttpWebRequest)WebRequest.Create(requestUri.ToString());
            request.Method = "GET";

            var response = (HttpWebResponse)request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var json = JObject.Parse(reader.ReadToEnd());

                var contents = new List<FileSystemInfo>();
                foreach (var item in json["data"])
                {
                    var type = item["type"].ToString();
                    switch (type)
                    {
                        case "photo":
                            contents.Add(JsonConvert.DeserializeObject<Photo>(item.ToString()));
                            break;

                        case "video":
                            contents.Add(JsonConvert.DeserializeObject<Video>(item.ToString()));
                            break;

                        case "folder":
                        case "album":
                            contents.Add(JsonConvert.DeserializeObject<Folder>(item.ToString()));
                            break;
                    }
                }

                foreach (var item in contents)
                {
                    Console.WriteLine(String.Format("{0} : {1}", item.Type, item.Name));
                    if (item is Photo)
                    {
                        Console.WriteLine(String.Format("Size: {0} bytes", ((Photo)item).Size));
                    }
                }
            }
        }

        private static void ListFolderContents(string folderId)
        {
            var requestUri = new StringBuilder(String.Format("https://apis.live.net/v5.0/{0}/files", folderId));
            requestUri.AppendFormat("?access_token={0}", AccessToken);
            var request = (HttpWebRequest)WebRequest.Create(requestUri.ToString());
            request.Method = "GET";

            var response = (HttpWebResponse)request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var json = JObject.Parse(reader.ReadToEnd());

                // Parse the JSON data here
                // ...
            }
        }

        static void Main()
        {
            //AuthorizeApplication();

            ListFolders();

            ListOtherContentTypes();

            ListFolderContents("your folder ID");

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
