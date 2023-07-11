using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace xyzauth
{
    internal class auth
    {
        public static string register(string username, string password, string key)
        {
            //param1 is username
            //param2 is password
            //param3 is register key
            string url = "your host.";
            if (param2 == param1 || !Regex.IsMatch(param1, @"^[a-z]+$" ,RegexOptions.IgnoreCase) || !Regex.IsMatch(param2, @"^[a-z0-9_@!.]+$", RegexOptions.IgnoreCase))
            {
                return "Please only use latin letters in your username and latin letter,@,!,numbers and dots in your password";
                return;
            }
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            using (var stream = request.GetRequestStream())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write("username=" + param1 + "&password=" + param2 + "&key=" + param3);
            }
            var response = request.GetResponse() as HttpWebResponse;
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
            return response.ToString();
        }
        public static string login(string username, string password)
        {
            string url = "your host.";
            if (!Regex.IsMatch(username, @"^[a-z]+$", RegexOptions.IgnoreCase) || !Regex.IsMatch(password, @"^[a-z0-9_@!.]+$", RegexOptions.IgnoreCase))
            {
                return "Username or password contain illegal characters.Only use Latin letters for username!";
            }
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            using (var stream = request.GetRequestStream())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write("username=" + username + "&password=" + password);
            }
            var response = request.GetResponse() as HttpWebResponse;
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
            return response.ToString();
        }
    }
}
