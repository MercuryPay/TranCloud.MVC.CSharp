using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranCloud.MVC.CSharp.Models;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;

namespace TranCloud.MVC.CSharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Complete()
        {
            var tranCloudTransaction = new TranCloudTransaction();
            tranCloudTransaction.TStream = new TStream();
            tranCloudTransaction.TStream.Transaction = new Transaction();
            tranCloudTransaction.TStream.Transaction.Account = new Account();
            tranCloudTransaction.TStream.Transaction.Account.AcctNo = "SecureDevice";
            tranCloudTransaction.TStream.Transaction.Amount = new Amount();
            tranCloudTransaction.TStream.Transaction.Amount.Purchase = "1.11";
            tranCloudTransaction.TStream.Transaction.InvoiceNo = "1234";
            tranCloudTransaction.TStream.Transaction.MerchantID = "1234";
            tranCloudTransaction.TStream.Transaction.OperatorID = "test";
            tranCloudTransaction.TStream.Transaction.PartialAuth = "Allow";
            tranCloudTransaction.TStream.Transaction.RefNo = "1234";
            tranCloudTransaction.TStream.Transaction.SecureDevice = "ONTRAN";
            tranCloudTransaction.TStream.Transaction.TranCode = "Sale";
            tranCloudTransaction.TStream.Transaction.TranDeviceID = "XYZ";
            tranCloudTransaction.TStream.Transaction.TranType = "Credit";

            var json = new JavaScriptSerializer().Serialize(tranCloudTransaction);

            var request = (HttpWebRequest)WebRequest.Create("https://trancloud.dsipscs.com");
            request.Method = "POST";
            request.ContentType = "application/json";

            var username = "username";
            var password = "password";
            var encoded = System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(username + ":" + password));
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

            var tranCloudResponse = new JavaScriptSerializer().Deserialize<dynamic>(response);
            var rstream = tranCloudResponse["RStream"];
            var cmdResponse = rstream["CmdResponse"];
            var tranResponse = rstream["TranResponse"];

            var paymentResponse = new PaymentInfoResponse();
            paymentResponse.AcqRefData = "";
            paymentResponse.Amount = "1.11";
            paymentResponse.CardholderName = "test test";
            paymentResponse.CardType = tranResponse["CardType"];
            paymentResponse.DisplayMessage = cmdResponse["TextResponse"];
            paymentResponse.ExpDate = tranResponse["ExpDate"];
            paymentResponse.MaskedAccount = tranResponse["AcctNo"];
            paymentResponse.Token = tranResponse["RecordNo"];

            return View(paymentResponse);
        }
    }
}