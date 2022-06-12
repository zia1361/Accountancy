using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gullycricket.ModalClasses
{
    public class TAccountInfo
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDateString { get; set; }
        public int DebitValue { get; set; }
        public int CreditValue { get; set; }
        public string InnerHTML { get; set; }
    }
}