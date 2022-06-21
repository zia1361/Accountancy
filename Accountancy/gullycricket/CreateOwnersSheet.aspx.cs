using gullycricket.Backbone;
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
    public partial class CreateOwnersSheet : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            MessageBox.ClearMessage();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
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
            var oUser = SessionService.GetCurrentUser().oUser;
            var oCapitalTransactions = new SheetsManagement().GetCapitalTransactionsByUserId(oUser.Id, selectedDateValue);
            double capitalSumValue = (oCapitalTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Debit)
                                        .Sum(x => x.Amount) - oCapitalTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Credit)
                                        .Sum(x => x.Amount));
            capitalSumValue = Math.Abs(capitalSumValue);
            CapitalRepeater.DataSource = oCapitalTransactions;
            CapitalRepeater.DataBind();
            beginingBalance.InnerText = capitalSumValue.ToString();
            double netIncomeValue = Math.Abs(new SheetsManagement().GetNetIncomeByUserId(oUser.Id, selectedDateValue));
            netIncome.InnerText = netIncomeValue.ToString();
            endingBalance.InnerText = (capitalSumValue - netIncomeValue).ToString();
            companyName.InnerText = SessionService.GetCurrentUser().oUser.Name;
            generatedDate.InnerText = selectedDateValue.ToString("MMMM yyyy");

            //if (netIncomeValue == 0 && oCapitalTransactions.Count <= 0)
            //{
            //    MessageBox.ErrorMessage("No record found");
            //}

        }
    }
}