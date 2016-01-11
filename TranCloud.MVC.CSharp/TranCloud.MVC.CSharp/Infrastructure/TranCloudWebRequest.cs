using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using TranCloud.MVC.CSharp.Models;

namespace TranCloud.MVC.CSharp.Infrastructure
{
    public class TranCloudWebRequest
    {
        public static string DoTranCloudRequest(string json)
        {
            var request = (HttpWebRequest)WebRequest.Create(ConfigReader.GetTranCloudURL());
            request.Method = "POST";
            request.ContentType = "application/json";

            var encoded = System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(
                ConfigReader.GetTranCloudUserName() + ":" + ConfigReader.GetTranCloudPassword()));

            request.Headers.Add("Authorization", "Basic " + encoded);
            request.Headers.Add("User-Trace", "testing TranCloud.MVC.CSharp");
            request.ContentLength = json.Length;
            using (var webStream = request.GetRequestStream())
            using (var requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(json);
            }

            var response = string.Empty;

            try
            {
                var webResponse = request.GetResponse();
                using (var webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (var responseReader = new StreamReader(webStream))
                        {
                            response = responseReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                response = e.ToString();
            }

            return response;
        }
    }
}