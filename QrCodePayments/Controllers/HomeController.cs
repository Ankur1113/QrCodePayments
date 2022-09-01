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

            //RazorpayClient RC = new RazorpayClient("rzp_test_4cMvJ6ZpAWMdsS", "dXbpU75yzn3IQPoKKkjEOf44");
            RazorpayClient RC = new RazorpayClient("rzp_live_M0bVKbPL25d5FZ", "E33dJnsBijTSJdo8vIFNJfiz");



            int recordcount = 0;
            int skipCount = 0;

            List<QrCode> Data = new List<QrCode>();
            do
            {
                try
                {
                    Dictionary<string, object> attributes = new Dictionary<string, object>();
                    attributes.Add("count", 100);
                    attributes.Add("skip", skipCount);
                    attributes.Add("from", 1659308400);
                    attributes.Add("to", 1661986800);

                    var tmpdata = RC.QrCode.fetchAll(attributes);
                    Data.AddRange(tmpdata);
                    recordcount = tmpdata.Count();
                    skipCount = skipCount + recordcount;
                }
                catch (Exception ex)
                {
                    throw;
                }

            } while (recordcount == 100);




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
                            case nameof(tt.status):
                                tt.status = item1.Value;
                                break;
                            case nameof(tt.name):
                                tt.name = item1.Value;
                                break;
                        }

                    }
                    if (tt.fixed_amount == true && Convert.ToInt32(tt.payments_amount_received) > 0 && tt.status == "closed" && Convert.ToInt32(tt.fixed_amount) > 0 && tt.type == "upi_qr")
                    {
                        rt.Add(tt);
                    }

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