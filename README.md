# TranCloud.MVC.CSharp

* More documentation?  http://developer.mercurypay.com
* Questions?  integrationteam@mercurypay.com
* **Feature request?** Open an issue.
* Feel like **contributing**?  Submit a pull request.

# Overview

Visual Studio MVC website application that shows how to integrate to Datacap's TranCloud platform.

![TranCloud.MVC.CSharp](https://github.com/mercurypay/TranCloud.MVC.CSharp/blob/master/screenshot1.PNG)


![HostedCheckout.MVC.CSharp](https://github.com/mercurypay/TranCloud.MVC.CSharp/blob/master/screenshot2.PNG)

# Payment Processing

##Step 1: Collect and Format Transaction Information


```
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

```


##Step 2: POST Request to TranCloud


```
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
```


##Step 3: Process and Display Response


```
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
```



###�2015 Mercury Payment Systems, LLC - all rights reserved.

Disclaimer:
This software and all specifications and documentation contained herein or provided to you hereunder (the "Software") are provided free of charge strictly on an "AS IS" basis. No representations or warranties are expressed or implied, including, but not limited to, warranties of suitability, quality, merchantability, or fitness for a particular purpose (irrespective of any course of dealing, custom or usage of trade), and all such warranties are expressly and specifically disclaimed. Mercury Payment Systems shall have no liability or responsibility to you nor any other person or entity with respect to any liability, loss, or damage, including lost profits whether foreseeable or not, or other obligation for any cause whatsoever, caused or alleged to be caused directly or indirectly by the Software. Use of the Software signifies agreement with this disclaimer notice.