using gullycricket.Model_Classes;
using gullycricket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static gullycricket.Model_Classes.Constants;

namespace gullycricket
{
    public partial class CreateIncomeSheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var oUser = SessionService.GetCurrentUser().oUser;
                if (oUser == null)
                {
                    Response.Redirect("pages-error-404.html");
                }
                
            }
            MessageBox.ClearMessage();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedDateValue = DateTime.Now;
                try
                {
                    selectedDateValue = DateTime.ParseExact(date.Value, "yyyy-MM-dd", null);
                }
                catch (Exception ex)
                {

                    MessageBox.ErrorMessage("Kindly select date");
                    return;
                }
                var oSheet = new SheetsManagement().GetIncomeSheetByUserId(SessionService.GetCurrentUser().oUser.Id, selectedDateValue);
                double expenseSumValue = (oSheet.oExpenseTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Debit)
                                        .Sum(x => x.Amount) - oSheet.oExpenseTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Credit)
                                        .Sum(x => x.Amount));
                expenseSumValue = Math.Abs(expenseSumValue);
                double revenueSumValue = (oSheet.oRevenueTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Debit)
                                        .Sum(x => x.Amount) - oSheet.oRevenueTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Credit)
                                        .Sum(x => x.Amount));
                revenueSumValue = Math.Abs(revenueSumValue);
                
                ExpenseRepeater.DataSource = oSheet.oExpenseTransactions;
                ExpenseRepeater.DataBind();
                expenseSum.InnerText = expenseSumValue.ToString();
                RevenueRepeater.DataSource = oSheet.oRevenueTransactions;
                RevenueRepeater.DataBind();
                revenueSum.InnerText = revenueSumValue.ToString();
                netIncome.InnerText = (revenueSumValue - expenseSumValue).ToString();
                companyName.InnerText = SessionService.GetCurrentUser().oUser.Name;
                generatedDate.InnerText = selectedDateValue.ToString("MMMM yyyy");

                if (expenseSumValue == 0 || revenueSumValue == 0)
                {
                    MessageBox.ErrorMessage("No Record found");
                }

            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }
    }
}