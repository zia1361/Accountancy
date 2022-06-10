using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gullycricket.ModalClasses
{
    public class SheetInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDateString { get; set; }
        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }
        public string InnerHTML { get; set; }
        public int Amount { get; set; }
    }
}