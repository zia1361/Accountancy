<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Global.Master" AutoEventWireup="true" CodeBehind="GeneralJournal.aspx.cs" Inherits="gullycricket.GeneralJournal" %>


<%@ Register Src="~/UserControl/MessageBox.ascx" TagPrefix="uc1" TagName="MessageBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:HiddenField ID="debitList" ClientIDMode="Static" Value="[]" runat="server" />
    <asp:HiddenField ID="creditList" ClientIDMode="Static" Value="[]" runat="server" />
     <main id="main" class="main">

    <div class="pagetitle">
      <h1>General Journal</h1>
      
    </div><!-- End Page Title -->
    <section class="section">
      <div class="row">
        

        <div class="col-lg-12">
            <uc1:MessageBox runat="server" ID="MessageBox" />
            <div   id="errorMessage" class="alert alert-danger">
  <strong><icon class="bi bi-dash-circle-fill"></icon></strong> <span id="errorText"></span>
  <button type="button" class="close" onclick="$('#errorMessage').hide(100);" aria-label="Close">
    <span aria-hidden="true">&times;</span>
  </button>
</div>
          <div class="card">
            <div class="card-body">
              <h5 class="card-title"></h5>

              
              <div class="row g-3">
              
               <div class="col-6">
                    <div class="form-group">
                         <label for="transactionDate" class="form-label">Start Date</label>
                        <input type="date" runat="server" class="form-control" clientidmode="static" id="transactionDate"/>                        
                    </div>
                 
               </div>
               
              
                
              </div><!-- Vertical Form -->
                 <div class="row g-3">
                     <div class="col-12 text-left">
                          <h5 class="card-title">Debit</h5>
                     </div>
                <div class="col-5">
                    <div class="form-group">
                         <label for="ElementListDebit" class="form-label">Select Element Type</label>
                          <asp:DropDownList ClientIDMode="Static" ID="ElementListDebit" class="form-control" runat="server"></asp:DropDownList>
                        
                    </div>
                 
                  
                </div>
  <div class="col-5">
                    <div class="form-group">
                         <label for="debitAmount" class="form-label">Amount</label>
                        <input type="number" class="form-control" id="debitAmount"/>                        
                    </div>
                 
               </div>
<div class="col-2">
                    <div class="form-group">
                         <label class="form-label"></label>
                        <div>
                            <button type="button"  class="btn btn-success" clientidmode="static"   onclick="AddDebitEntry()" >Add</button>  
                        </div>
                                         
                    </div>
                 
               </div>
                     <div class="col-12">
                         <table class="table table-striped">
                <thead>
                  <tr>
                    
                    <th scope="col">Element Type</th>
                    <th scope="col">Amount</th>
                    
                    <th scope="col">Actions</th>
                  </tr>
                </thead>
                <tbody id="debitTbl">
                   
                 
                  
                </tbody>
              </table>
                     </div>
                     </div>
                <div class="row g-3">
                     <div class="col-12 text-left">
                          <h5 class="card-title">Credit</h5>
                     </div>
                <div class="col-5">
                    <div class="form-group">
                         <label for="ElementListCredit" class="form-label">Select Element Type</label>
                          <asp:DropDownList ClientIDMode="Static" ID="ElementListCredit" class="form-control" runat="server"></asp:DropDownList>
                        
                    </div>
                 
                  
                </div>
  <div class="col-5">
                    <div class="form-group">
                         <label for="creditAmount" class="form-label">Amount</label>
                        <input type="number" class="form-control" id="creditAmount"/>                        
                    </div>
                 
               </div>
<div class="col-2">
                    <div class="form-group">
                         <label class="form-label"></label>
                        <div>
                            <button type="button"  class="btn btn-success" clientidmode="static"   onclick="AddCreditEntry()" >Add</button>  
                        </div>
                                         
                    </div>
                 
               </div>
                     <div class="col-12">
                         <table class="table table-striped">
                <thead>
                  <tr>
                    
                    <th scope="col">Element Type</th>
                    <th scope="col">Amount</th>
                    
                    <th scope="col">Actions</th>
                  </tr>
                </thead>
                <tbody id="creditTbl">
                   
                 
                  
                </tbody>
              </table>
                     </div>
                     </div>
                <div class="row g-3">
                    <div class="text-center">
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" OnClientClick="return VerifyEntry()" class="btn btn-primary" runat="server" Text="Submit" />
                  <a href="Dashboard.aspx" class="btn btn-secondary">Back</a>
                </div>
                </div>

            </div>
          </div>



          

        </div>
      </div>
    </section>

        <div class="pagetitle">
      <h1>Transactions history</h1>
      
    </div><!-- End Page Title -->
         <section class="section">
      <div class="row">
        

        <div class="col-lg-12">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title"></h5>
                <table class="table table-striped">
                <thead>
                  <tr>
                    <th scope="col">#</th>
                    <th scope="col">Transaction Date</th>
                    <th scope="col">Transactions</th>
                      <th scope="col">Actions</th>
                     
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="GeneralEntryRepeater" runat="server" OnItemDataBound="GeneralEntryRepeater_ItemDataBound">
                        <ItemTemplate>
                             <tr>
                    <th scope="row"><%# Container.ItemIndex + 1 %></th>
                    <td scope="row"><%# Eval("TransactionDateString") %></td>
                    <td>
                        <asp:HiddenField ID="EntryId" Visible="false" Value='<%# Eval("Id") %>' runat="server" />
                        <table class="table table-striped">
                 <%--<thead>
                  <tr>
                    
                    <th scope="col"></th>
                    <th scope="col"></th>
                       <th scope="col"></th>
                     
                  </tr>--%>
                </thead>
              
                <tbody>
                    <asp:Repeater ID="JournalEntriesRepeater" runat="server">
                        <ItemTemplate>
                             <tr>
                                  <td ><%# Eval("FinElementTypeName") %> &nbsp(<%# Eval("Amount") %>)</td>
                                 <td class="text-center"><%# Eval("TransactionTypeName") %></td>
                                 </tr>
                    </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                            </table>
                    </td>
                    
                                 
                    
                                 <td>
                                     <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="if (!confirm('Are you sure you want delete?')) return false;" OnClick="btnDelete_Click" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger actionBtn btn-sm" data-bs-toggle="tooltip" data-bs-placement="top" title="Delete"><i class="bi bi-trash"></i></asp:LinkButton>
                                 </td>
                  </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                 
                  
                </tbody>
              </table>

            </div>
          </div>

          

        </div>
      </div>
    </section>

  </main><!-- End #main -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footerPlaceholder" runat="server">
    <script src="assets/js/GeneralJournal.js"></script>
    <script>
        $('#errorMessage').hide();
    </script>
</asp:Content>
