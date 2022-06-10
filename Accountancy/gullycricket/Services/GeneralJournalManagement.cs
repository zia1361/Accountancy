using gullycricket.DB;
using gullycricket.ModalClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace gullycricket.Services
{
    public class GeneralJournalManagement
    {
        public void BindElementType(DropDownList gList)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eTypes = eDataBase.FinancialElementTypes.ToList();
                    gList.DataSource = eTypes;
                    gList.DataTextField = "TypeName";
                    gList.DataValueField = "Id";
                    gList.DataBind();
                    gList.Items.Insert(0, new ListItem("Select Element Type", "0"));
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

      public void AddGeneralJournalEntry(GeneralJournalInfo oGeneral)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    GeneralJournalEntry eGeneral = new GeneralJournalEntry();
                    eGeneral.UserId = oGeneral.UserId;
                    eGeneral.TransactionDate = oGeneral.TransactionDate;
                    eDataBase.GeneralJournalEntries.InsertOnSubmit(eGeneral);
                    eDataBase.SubmitChanges();
                    foreach (var oTransaction in oGeneral.oTransactions)
                    {
                        JournalEntry eEntry = new JournalEntry();
                        eEntry.JournalId = eGeneral.Id;
                        eEntry.TransactionTypeId = oTransaction.TransactionTypeId;
                        eEntry.ElementTypeId = oTransaction.TypeId;
                        eEntry.Amount = oTransaction.Amount;
                        eDataBase.JournalEntries.InsertOnSubmit(eEntry);
                        eDataBase.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<GeneralJournalInfo> GetGeneralJournalEntriesByUserId(int userId)
        {
            try
            {
                List<GeneralJournalInfo> oEntries = new List<GeneralJournalInfo>();
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eEntries = eDataBase.GeneralJournalEntries.Where(eGData => eGData.UserId == userId).ToList();
                    foreach (var eEntry in eEntries)
                    {
                        oEntries.Add(new GeneralJournalInfo()
                        {
                            Id = eEntry.Id,
                            TransactionDate = eEntry.TransactionDate,
                            TransactionDateString = eEntry.TransactionDate.ToString(ConfigurationManager.AppSettings["DateFormat"])
                        });
                    }
                }
                return oEntries;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void DeleteGeneralJournalEntry(int entryId)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eEntry = eDataBase.GeneralJournalEntries.Where(eEData => eEData.Id == entryId).FirstOrDefault();
                    if(eEntry == null)
                    {
                        throw new Exception("No record found");
                    }
                    eDataBase.JournalEntries.DeleteAllOnSubmit(eEntry.JournalEntries);
                    eDataBase.SubmitChanges();
                    eDataBase.GeneralJournalEntries.DeleteOnSubmit(eEntry);
                    eDataBase.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<DebitCreditInfo> GetJournalEntriesByJournalId(int journalId)
        {
            try
            {
                List<DebitCreditInfo> oEntries = new List<DebitCreditInfo>();
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eEntries = eDataBase.JournalEntries.Where(eJData => eJData.JournalId == journalId).ToList();
                    foreach (var eEntry in eEntries)
                    {
                        oEntries.Add(new DebitCreditInfo()
                        {
                            Id = eEntry.Id,
                            TransactionTypeName = eEntry.Transactiontype.TypeName,
                            TransactionTypeId = eEntry.TransactionTypeId,
                            FinElementTypeName = eEntry.FinancialElementType.TypeName,
                            TypeId = eEntry.ElementTypeId,
                            Amount = eEntry.Amount
                        });
                    }
                }
                return oEntries;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}