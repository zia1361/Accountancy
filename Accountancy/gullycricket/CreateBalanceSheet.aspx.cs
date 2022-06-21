using gullycricket.Backbone;
using gullycricket.Model_Classes;
using gullycricket.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static gullycricket.Model_Classes.Constants;

namespace gullycricket
{
    public partial class CreateBalanceSheet : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
                var oUser = SessionService.GetCurrentUser().oUser;
                var oSheet = new SheetsManagement().GetBalanceSheetByUserId(oUser.Id, selectedDateValue);
                double assetSumValue = (oSheet.oAssetsTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Debit)
                                        .Sum(x => x.Amount) - oSheet.oAssetsTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Credit)
                                        .Sum(x => x.Amount));
                assetSumValue = Math.Abs(assetSumValue);
                double liabilitySumValue = (oSheet.oLiabilitiesTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Debit)
                                        .Sum(x => x.Amount) - oSheet.oLiabilitiesTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Credit)
                                        .Sum(x => x.Amount));
                liabilitySumValue = Math.Abs(liabilitySumValue);

                //if (assetSumValue == 0 || (liabilitySumValue + equitySumValue == 0))
                //{
                //    MessageBox.ErrorMessage("No Record found");
                //}

                AssetRepeater.DataSource = oSheet.oAssetsTransactions;
                AssetRepeater.DataBind();
                assetSum.InnerText = assetSumValue.ToString();
                LiabilityRepeater.DataSource = oSheet.oLiabilitiesTransactions;
                LiabilityRepeater.DataBind();
                liabilitySum.InnerText = liabilitySumValue.ToString();
                double equitySumValue = Math.Abs(new SheetsManagement().GetOwnersEquityByUserId(oUser.Id, selectedDateValue));
                equitySum.InnerText = equitySumValue.ToString();
                liabEquitySum.InnerText = (equitySumValue + liabilitySumValue).ToString();
                companyName.InnerText = SessionService.GetCurrentUser().oUser.Name;
                generatedDate.InnerText = selectedDateValue.ToString(ConfigurationManager.AppSettings["DateFormat"]);



            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }
    }
}