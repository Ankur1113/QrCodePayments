using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razorpay.Api;

namespace QrCodePayments.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            RazorpayClient RC = new RazorpayClient("rzp_test_4cMvJ6ZpAWMdsS", "dXbpU75yzn3IQPoKKkjEOf44");

            Dictionary<string, object> attributes = new Dictionary<string, object>();
            //attributes.Add("type", "upi_qr");
           // attributes.Add("fixed_amount", "true");
            List<QrCode> Data = new List<QrCode>();
            try
            {
                Data = RC.QrCode.fetchAll();
            }
            catch (Exception ex)
            {

                throw;
            }

            List<Models.Root> rt = new List<Models.Root>();
            if (Data.Count > 0)
            {
                foreach (var item in Data)
                {
                    Models.Root tt = new Models.Root();

                    foreach (var item1 in item.Attributes)
                    {

                        string typ = item1.Name;
                        switch (typ)
                        {
                            case nameof(tt.id):
                                tt.id = item1.Value;
                                break;

                            case nameof(tt.notes):
                                Dictionary<string, string> nt = new Dictionary<string, string>();
                                foreach (var ntt in item1.Value)
                                {
                                    string key = ntt.Name;
                                    string val = ntt.Value;
                                    nt.Add(key, val);
                                }
                                tt.notes = nt;
                                break;

                            case nameof(tt.fixed_amount):
                                tt.fixed_amount = item1.Value;
                                break;
                            case nameof(tt.payments_amount_received):
                                tt.payments_amount_received = item1.Value;
                                break;
                            case nameof(tt.payments_count_received):
                                tt.payments_count_received = item1.Value;
                                break;
                            case nameof(tt.type):
                                tt.type = item1.Value;
                                break;
                            case nameof(tt.payment_amount):
                                tt.payment_amount = item1.Value;
                                break;
                        }

                    }
                    rt.Add(tt);

                }
            }



            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}