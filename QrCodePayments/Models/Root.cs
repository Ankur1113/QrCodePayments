using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QrCodePayments.Models
{
    public class Root
    {
        public string id { get; set; }
        public string entity { get; set; }
        public int created_at { get; set; }
        public string name { get; set; }
        public string usage { get; set; }
        public string type { get; set; }
        public string image_url { get; set; }
        public string payment_amount { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public bool fixed_amount { get; set; }
        public string payments_amount_received { get; set; }
        public string payments_count_received { get; set; }
        public Dictionary<string,string> notes { get; set; }
        public string customer_id { get; set; }
        public int close_by { get; set; }
        public int closed_at { get; set; }
        public string close_reason { get; set; }
    }
   
}