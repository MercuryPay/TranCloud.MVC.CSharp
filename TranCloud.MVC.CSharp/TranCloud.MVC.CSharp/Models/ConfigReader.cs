using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace TranCloud.MVC.CSharp.Models
{
    public class ConfigReader
    {
        public static string GetDeviceID()
        {
            return WebConfigurationManager.AppSettings["DeviceID"];
        }

        public static string GetTranCloudURL()
        {
            return WebConfigurationManager.AppSettings["TranCloudURL"];
        }

        public static string GetTranCloudUserName()
        {
            return WebConfigurationManager.AppSettings["TranCloudUserName"];
        }

        public static string GetTranCloudPassword()
        {
            return WebConfigurationManager.AppSettings["TranCloudPassword"];
        }
    }
}