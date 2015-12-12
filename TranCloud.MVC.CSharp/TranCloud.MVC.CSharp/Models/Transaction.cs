using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranCloud.MVC.CSharp.Models
{
    public class Transaction
    {
        public string MerchantID;
        public string OperatorID;
        public string TranType;
        public string TranCode;
        public string InvoiceNo;
        public string RefNo;
        public string PartialAuth;
        public string SecureDevice;
        public Account Account;
        public Amount Amount;
        public string TranDeviceID;
    }
}