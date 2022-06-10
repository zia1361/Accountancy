using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gullycricket.ModalClasses
{
    public class BalanceSheetInfo
    {
        public List<SheetInfo> oAssetsTransactions { get; set; }
        public List<SheetInfo> oLiabilitiesTransactions { get; set; }
    }
}