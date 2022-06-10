using gullycricket.DB;
using gullycricket.ModalClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using static gullycricket.Model_Classes.Constants;

namespace gullycricket.Services
{
    public class SheetsManagement
    {
        public IncomeSheetInfo GetIncomeSheetByUserId(int userId, DateTime date)
        {
            try
            {
                IncomeSheetInfo oSheet = new IncomeSheetInfo();
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eEntries = eDataBase.GeneralJournalEntries.Where(eGData => eGData.UserId == userId
                                    & eGData.TransactionDate.Month == date.Month & eGData.TransactionDate.Year == date.Year).ToList();
                    List<SheetInfo> oExpenseTransactions = new List<SheetInfo>();
                    List<SheetInfo> oRevenueTransactions = new List<SheetInfo>();
                    foreach (var eEntry in eEntries)
                    {
                        var eExpenseTransactions = eEntry.JournalEntries.Where(eJData => eJData.ElementTypeId == (int)ElementType.Expense).ToList();
                        foreach (var eExpense in eExpenseTransactions)
                        {
                            oExpenseTransactions.Add(new SheetInfo()
                            {
                                TransactionDate = eEntry.TransactionDate,
                                TransactionDateString = eEntry.TransactionDate.ToString(ConfigurationManager.AppSettings["DateFormat"]),
                                TransactionTypeId = eExpense.TransactionTypeId,
                                TransactionTypeName = eExpense.Transactiontype.TypeName,
                                Amount = eExpense.Amount
                            });
                        }

                        var eRevenueTransactions = eEntry.JournalEntries.Where(eJData => eJData.ElementTypeId == (int)ElementType.Revenue).ToList();
                        foreach (var eRevenue in eRevenueTransactions)
                        {
                            oRevenueTransactions.Add(new SheetInfo()
                            {
                                TransactionDate = eEntry.TransactionDate,
                                TransactionDateString = eEntry.TransactionDate.ToString(ConfigurationManager.AppSettings["DateFormat"]),
                                TransactionTypeId = eRevenue.TransactionTypeId,
                                TransactionTypeName = eRevenue.Transactiontype.TypeName,
                                Amount = eRevenue.Amount
                            });
                        }
                    }

                    oSheet.oExpenseTransactions = oExpenseTransactions;
                    oSheet.oRevenueTransactions = oRevenueTransactions;
                }
                return oSheet;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public double GetNetIncomeByUserId(int userId, DateTime date)
        {
            try
            {
                double netIncome = 0;
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eEntries = eDataBase.GeneralJournalEntries.Where(eGData => eGData.UserId == userId
                                    & eGData.TransactionDate.Month == date.Month & eGData.TransactionDate.Year == date.Year).ToList();
                    double totalExpense = 0;
                    double totalRevenue = 0;
                    List<JournalEntry> eExpenseTransactions = new List<JournalEntry>();
                    List<JournalEntry> eRevenueTransactions = new List<JournalEntry>();
                    foreach (var eEntry in eEntries)
                    {
                        var eExpenseRecord = eEntry.JournalEntries.Where(eJData => eJData.ElementTypeId == (int)ElementType.Expense).ToList();
                        eExpenseRecord.ForEach((record) =>
                        {
                            eExpenseTransactions.Add(record);
                        });
                        

                        var eRevenueRecord = eEntry.JournalEntries.Where(eJData => eJData.ElementTypeId == (int)ElementType.Revenue).ToList();
                        eRevenueRecord.ForEach((record) =>
                        {
                            eRevenueTransactions.Add(record);
                        });
                    }
                    totalExpense = (eExpenseTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Debit)
                                       .Sum(x => x.Amount) - eExpenseTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Credit)
                                       .Sum(x => x.Amount));
                    totalExpense = Math.Abs(totalExpense);

                    totalRevenue = (eRevenueTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Debit)
                                            .Sum(x => x.Amount) - eRevenueTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Credit)
                                            .Sum(x => x.Amount));
                    totalRevenue = Math.Abs(totalRevenue);

                    netIncome = totalRevenue - totalExpense;
                    
                }
                return netIncome;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<SheetInfo> GetCapitalTransactionsByUserId(int userId, DateTime date)
        {
            try
            {
                List<SheetInfo> oCapitalTransactions = new List<SheetInfo>();
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eEntries = eDataBase.GeneralJournalEntries.Where(eGData => eGData.UserId == userId
                                    & eGData.TransactionDate.Month == date.Month & eGData.TransactionDate.Year == date.Year).ToList();
                    
                    foreach (var eEntry in eEntries)
                    {
                        var eCapitalTransactions = eEntry.JournalEntries.Where(eJData => eJData.ElementTypeId == (int)ElementType.Capital).ToList();
                        foreach (var eCapital in eCapitalTransactions)
                        {
                            oCapitalTransactions.Add(new SheetInfo()
                            {
                                TransactionDate = eEntry.TransactionDate,
                                TransactionDateString = eEntry.TransactionDate.ToString(ConfigurationManager.AppSettings["DateFormat"]),
                                TransactionTypeId = eCapital.TransactionTypeId,
                                TransactionTypeName = eCapital.Transactiontype.TypeName,
                                Amount = eCapital.Amount
                            });
                        }

                        
                    }
                }
                return oCapitalTransactions;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public BalanceSheetInfo GetBalanceSheetByUserId(int userId, DateTime date)
        {
            try
            {
                BalanceSheetInfo oSheet = new BalanceSheetInfo();
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eEntries = eDataBase.GeneralJournalEntries.Where(eGData => eGData.UserId == userId
                                    & eGData.TransactionDate.Date <= date.Date).ToList();
                    List<SheetInfo> oAssetsTransactions = new List<SheetInfo>();
                    List<SheetInfo> oLiabilitiesTransactions = new List<SheetInfo>();
                    foreach (var eEntry in eEntries)
                    {
                        var eAssetsTransactions = eEntry.JournalEntries.Where(eJData => eJData.ElementTypeId == (int)ElementType.Asset).ToList();
                        foreach (var eAsset in eAssetsTransactions)
                        {
                            oAssetsTransactions.Add(new SheetInfo()
                            {
                                TransactionDate = eEntry.TransactionDate,
                                TransactionDateString = eEntry.TransactionDate.ToString(ConfigurationManager.AppSettings["DateFormat"]),
                                TransactionTypeId = eAsset.TransactionTypeId,
                                TransactionTypeName = eAsset.Transactiontype.TypeName,
                                Amount = eAsset.Amount
                            });
                        }

                        var eLiabilityTransactions = eEntry.JournalEntries.Where(eJData => eJData.ElementTypeId == (int)ElementType.Liability).ToList();
                        foreach (var eLiability in eLiabilityTransactions)
                        {
                            oLiabilitiesTransactions.Add(new SheetInfo()
                            {
                                TransactionDate = eEntry.TransactionDate,
                                TransactionDateString = eEntry.TransactionDate.ToString(ConfigurationManager.AppSettings["DateFormat"]),
                                TransactionTypeId = eLiability.TransactionTypeId,
                                TransactionTypeName = eLiability.Transactiontype.TypeName,
                                Amount = eLiability.Amount
                            });
                        }
                    }

                    oSheet.oAssetsTransactions = oAssetsTransactions;
                    oSheet.oLiabilitiesTransactions = oLiabilitiesTransactions;
                }
                return oSheet;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public double GetOwnersEquityByUserId(int userId, DateTime date)
        {
            try
            {
                double ownersEquity = 0;
                var oCapitalTransactions = new SheetsManagement().GetCapitalTransactionsByUserId(userId, date);
                double capitalSumValue = (oCapitalTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Debit)
                                            .Sum(x => x.Amount) - oCapitalTransactions.Where(x => x.TransactionTypeId == (int)DebitCreditType.Credit)
                                            .Sum(x => x.Amount));
                capitalSumValue = Math.Abs(capitalSumValue);
                double netIncomeValue = Math.Abs(new SheetsManagement().GetNetIncomeByUserId(userId, date));
                ownersEquity = (capitalSumValue - netIncomeValue);
                return ownersEquity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}