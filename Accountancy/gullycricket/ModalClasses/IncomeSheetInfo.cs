using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gullycricket.ModalClasses
{
    public class IncomeSheetInfo
    {
        public List<SheetInfo> oExpenseTransactions { get; set; }
        public List<SheetInfo> oRevenueTransactions { get; set; }
    }
}