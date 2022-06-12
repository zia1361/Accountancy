using gullycricket.Model_Classes;
using gullycricket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gullycricket
{
    public partial class ViewTAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageBox.ClearMessage();
            if (!IsPostBack)
            {

                var oUser = SessionService.GetCurrentUser().oUser;
                if (oUser == null)
                {
                    Response.Redirect("pages-error-404.html");
                }
                BindData();

            }
            
        }

        private void BindData()
        {
            try
            {
                int userId = SessionService.GetCurrentUser().oUser.Id;
                double debitSum = 0;
                double creditSum = 0;
                #region AssetsTAccount
                var oAssets = new SheetsManagement().GetTAccountByElementTypeId((int)Constants.ElementType.Asset, userId);
                debitSum = oAssets.Sum(oASum => oASum.DebitValue);
                creditSum = oAssets.Sum(oASum => oASum.CreditValue);
                if(debitSum >= creditSum)
                {
                    assetSumContainer.Style.Add("float", "left");
                    assetSum.InnerText = (debitSum - creditSum).ToString();
                }
                else
                {
                    assetSumContainer.Style.Add("float", "right");
                    assetSum.InnerText = (creditSum - debitSum).ToString();
                }
                AssetRepeater.DataSource = oAssets;
                AssetRepeater.DataBind();
                #endregion

                #region ExpensesTAccount
                var oExpenses = new SheetsManagement().GetTAccountByElementTypeId((int)Constants.ElementType.Expense, userId);
                debitSum = oExpenses.Sum(oASum => oASum.DebitValue);
                creditSum = oExpenses.Sum(oASum => oASum.CreditValue);
                if (debitSum >= creditSum)
                {
                    expenseSumContainer.Style.Add("float", "left");
                    expenseSum.InnerText = (debitSum - creditSum).ToString();
                }
                else
                {
                    expenseSumContainer.Style.Add("float", "right");
                    expenseSum.InnerText = (creditSum - debitSum).ToString();
                }
                ExpenseRepeater.DataSource = oExpenses;
                ExpenseRepeater.DataBind();
                #endregion

                #region LiabilityTAccount
                var oLiabs = new SheetsManagement().GetTAccountByElementTypeId((int)Constants.ElementType.Liability, userId);
                debitSum = oLiabs.Sum(oASum => oASum.DebitValue);
                creditSum = oLiabs.Sum(oASum => oASum.CreditValue);
                if (debitSum >= creditSum)
                {
                    liabSumContainer.Style.Add("float", "left");
                    liabSum.InnerText = (debitSum - creditSum).ToString();
                }
                else
                {
                    liabSumContainer.Style.Add("float", "right");
                    liabSum.InnerText = (creditSum - debitSum).ToString();
                }
                LiabilityRepeater.DataSource = oLiabs;
                LiabilityRepeater.DataBind();
                #endregion

                #region RevenueTAccount
                var oRevenue = new SheetsManagement().GetTAccountByElementTypeId((int)Constants.ElementType.Revenue, userId);
                debitSum = oRevenue.Sum(oASum => oASum.DebitValue);
                creditSum = oRevenue.Sum(oASum => oASum.CreditValue);
                if (debitSum >= creditSum)
                {
                    revenueSumContainer.Style.Add("float", "left");
                    revenueSum.InnerText = (debitSum - creditSum).ToString();
                }
                else
                {
                    revenueSumContainer.Style.Add("float", "right");
                    revenueSum.InnerText = (creditSum - debitSum).ToString();
                }
                RevenueRepeater.DataSource = oRevenue;
                RevenueRepeater.DataBind();
                #endregion

                #region CapitalTAccount
                var oCapital = new SheetsManagement().GetTAccountByElementTypeId((int)Constants.ElementType.Capital, userId);
                debitSum = oCapital.Sum(oASum => oASum.DebitValue);
                creditSum = oCapital.Sum(oASum => oASum.CreditValue);
                if (debitSum >= creditSum)
                {
                    capitalSumContainer.Style.Add("float", "left");
                    capitalSum.InnerText = (debitSum - creditSum).ToString();
                }
                else
                {
                    capitalSumContainer.Style.Add("float", "right");
                    capitalSum.InnerText = (creditSum - debitSum).ToString();
                }
                CapitalRepeater.DataSource = oCapital;
                CapitalRepeater.DataBind();
                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }
    }
}