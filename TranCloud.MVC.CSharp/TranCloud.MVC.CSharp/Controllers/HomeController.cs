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
using TranCloud.MVC.CSharp.Infrastructure;

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
            //send pole display
            var json = Admin.GetPoleDisplay();            
            var response = TranCloudWebRequest.DoTranCloudRequest(json);

            //send credit sale
            json = TranCloudTransaction.GetTranCloudCreditSaleTransaction();
            response = TranCloudWebRequest.DoTranCloudRequest(json);
            var paymentResponse = PaymentInfoResponse.MapTranCloudResponse(response);

            //pop cash drawer
            json = Admin.GetDrawerOpen();
            response = TranCloudWebRequest.DoTranCloudRequest(json);
            paymentResponse = new PaymentInfoResponse();

            return View(paymentResponse);
        }
    }
}