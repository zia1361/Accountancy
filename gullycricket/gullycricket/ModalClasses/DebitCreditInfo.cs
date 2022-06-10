using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gullycricket.ModalClasses
{
    public class DebitCreditInfo
    {
        public int Id { get; set; }
        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }
        public int TypeId { get; set; }
        public string FinElementTypeName { get; set; }
        public int Amount { get; set; }
    }
}