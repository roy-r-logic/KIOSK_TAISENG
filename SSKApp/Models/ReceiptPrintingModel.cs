using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSKApp.Models
{
    public class ReceiptPrintingModel
    {
        public string ReceiptNumber { get; set; }
        public string PaymentMode { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal GST { get; set; }
        public decimal Total { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal NewBalance { get; set; }
    }
}
