using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace TranCloud.MVC.CSharp.Models
{
    public class TranCloudTransaction
    {
        public TStream TStream;

        public static string GetTranCloudCreditSaleTransaction()
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
            tranCloudTransaction.TStream.Transaction.TranDeviceID = ConfigReader.GetDeviceID();
            tranCloudTransaction.TStream.Transaction.TranType = "Credit";

            var json = new JavaScriptSerializer().Serialize(tranCloudTransaction);

            return json;
        }
    }
}