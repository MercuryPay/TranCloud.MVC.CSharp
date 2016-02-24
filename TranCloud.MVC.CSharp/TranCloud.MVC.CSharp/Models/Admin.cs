using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace TranCloud.MVC.CSharp.Models
{
    public class Admin
    {
        public string MerchantID;
        public string TranCode;
        public string SecureDevice;
        public string TranDeviceID;
        public DisplayData DisplayData;

        public static string GetPoleDisplay()
        {
            //print pole display
            var tranCloudAdmin = new TranCloudAdmin();
            tranCloudAdmin.TStream = new TStreamAdmin();
            tranCloudAdmin.TStream.Admin = new Admin();
            tranCloudAdmin.TStream.Admin.SecureDevice = "ONTRAN";
            tranCloudAdmin.TStream.Admin.MerchantID = "NONE";
            tranCloudAdmin.TStream.Admin.TranCode = "PoleDisplay";
            tranCloudAdmin.TStream.Admin.TranDeviceID = ConfigReader.GetDeviceID();
            tranCloudAdmin.TStream.Admin.DisplayData = new DisplayData();
            tranCloudAdmin.TStream.Admin.DisplayData.Line1 = ".WITH MERCURY";
            tranCloudAdmin.TStream.Admin.DisplayData.Line2 = ".SECURITY PAYS!!!!";

            var json = new JavaScriptSerializer().Serialize(tranCloudAdmin);
            return json;
        }

        public static string GetDrawerOpen()
        {
            var tranCloudAdmin = new TranCloudAdmin();
            tranCloudAdmin.TStream = new TStreamAdmin();
            tranCloudAdmin.TStream.Admin = new Admin();
            tranCloudAdmin.TStream.Admin.SecureDevice = "ONTRAN";
            tranCloudAdmin.TStream.Admin.MerchantID = "NONE";
            tranCloudAdmin.TStream.Admin.TranCode = "DrawerOpen";
            tranCloudAdmin.TStream.Admin.TranDeviceID = ConfigReader.GetDeviceID();

            var json = new JavaScriptSerializer().Serialize(tranCloudAdmin);

            return json;
        }

        public static string GetLoadApp()
        {
            var tranCloudAdmin = new TranCloudAdmin();
            tranCloudAdmin.TStream = new TStreamAdmin();
            tranCloudAdmin.TStream.Admin = new Admin();
            tranCloudAdmin.TStream.Admin.SecureDevice = "NONE";
            tranCloudAdmin.TStream.Admin.MerchantID = "NONE";
            tranCloudAdmin.TStream.Admin.TranCode = "LoadApp";
            tranCloudAdmin.TStream.Admin.TranDeviceID = ConfigReader.GetDeviceID();

            var json = new JavaScriptSerializer().Serialize(tranCloudAdmin);

            return json;
        }
    }
}