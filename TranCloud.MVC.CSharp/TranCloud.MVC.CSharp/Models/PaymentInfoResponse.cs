using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}