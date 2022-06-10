using gullycricket.ModalClasses;
using gullycricket.Model_Classes;
using gullycricket.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gullycricket
{
    public partial class GeneralJournal : System.Web.UI.Page
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
                new GeneralJournalManagement().BindElementType(ElementListDebit);
                new GeneralJournalManagement().BindElementType(ElementListCredit);
            }
            MessageBox.ClearMessage();
            BindData();
        }
        private void BindData()
        {
            try
            {
                GeneralEntryRepeater.DataSource = new GeneralJournalManagement().GetGeneralJournalEntriesByUserId(SessionService.GetCurrentUser().oUser.Id);
                GeneralEntryRepeater.DataBind();
            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(transactionDate.Value.Trim() == "")
                {
                    MessageBox.ErrorMessage("Kindly select date");
                    return;
                }
                var date = DateTime.Now;
                try
                {
                    date = DateTime.ParseExact(transactionDate.Value, "yyyy-MM-dd", null);
                }
                catch (Exception ex)
                {

                    MessageBox.ErrorMessage("Kindly select date");
                    return;
                }
                var oDebitList = new List<DebitCreditInfo>();
                if (debitList.Value != "[]")
                {
                    oDebitList = JsonConvert.DeserializeObject<List<DebitCreditInfo>>(debitList.Value);
                }
                var oCreditList = new List<DebitCreditInfo>();
                if (creditList.Value != "[]")
                {
                    oCreditList = JsonConvert.DeserializeObject<List<DebitCreditInfo>>(creditList.Value);
                }
                double debitSum = oDebitList.Sum(oDData => oDData.Amount);
                double creditSum = oCreditList.Sum(oCData => oCData.Amount);
                if(debitSum != creditSum)
                {
                    MessageBox.ErrorMessage("Debit and Credit should be equal");
                    return;
                }
                oDebitList.ForEach((item) => {
                    item.TransactionTypeId = 1;
                });
                oCreditList.ForEach((item) => {
                    item.TransactionTypeId = 2;
                });
                GeneralJournalInfo oGeneral = new GeneralJournalInfo();
                oGeneral.UserId = SessionService.GetCurrentUser().oUser.Id;
                oGeneral.TransactionDate = date;
                oGeneral.oTransactions = oDebitList.Concat(oCreditList).ToList();
                new GeneralJournalManagement().AddGeneralJournalEntry(oGeneral);
                MessageBox.SuccessMessage("Entry successfully added");
                transactionDate.Value = "";
                BindData();

            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int entryId = 0;
                int.TryParse(((LinkButton)sender).CommandArgument, out entryId);
                if(entryId == 0)
                {
                    MessageBox.ErrorMessage("Invalid or no ID found");
                    return;
                }
                new GeneralJournalManagement().DeleteGeneralJournalEntry(entryId);
                MessageBox.SuccessMessage("Entry successfullly deleted");
                BindData();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected void GeneralEntryRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var journalId = 0;
                    int.TryParse((e.Item.FindControl("EntryId") as HiddenField).Value, out journalId);
                    var JournalEntriesRepeater = e.Item.FindControl("JournalEntriesRepeater") as Repeater;
                    JournalEntriesRepeater.DataSource = new GeneralJournalManagement().GetJournalEntriesByJournalId(journalId);
                    JournalEntriesRepeater.DataBind();



                }
            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }
    }
}