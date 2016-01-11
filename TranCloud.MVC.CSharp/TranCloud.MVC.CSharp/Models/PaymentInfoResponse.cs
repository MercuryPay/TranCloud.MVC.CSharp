using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace TranCloud.MVC.CSharp.Models
{
    public class PaymentInfoResponse
    {
        public string AcqRefData;
        public string Amount;
        public string CardholderName;
        public string CardType;
        public string DisplayMessage;
        public string ExpDate;
        public string MaskedAccount;
        public string Token;

        public static PaymentInfoResponse MapTranCloudResponse(string response)
        {
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

            return paymentResponse;
        }
    }
}