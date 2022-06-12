
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Global.Master" AutoEventWireup="true" 
    CodeBehind="ViewTAccount.aspx.cs" Inherits="gullycricket.ViewTAccount" %>

<%@ Register Src="~/UserControl/MessageBox.ascx" TagPrefix="uc1" TagName="MessageBox" %>

<asp:Content ID="Content4" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
         <main id="main" class="main">

    <div class="pagetitle">
      <h1>T-Account</h1>
      
    </div><!-- End Page Title -->
    <section class="section">
      <div class="row">
        

        <div class="col-lg-12">
            <uc1:MessageBox runat="server" ID="MessageBox" />
          

          

        </div>
      </div>
    </section>

         <section class="section">
      <div class="row">
        

        <div class="col-lg-12">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title text-center" runat="server" id="companyName"></h5>
               
                <div class="row">
                    <div class="col-4">
                    <h6 class="card-title">Asset</h6>
                <table class="table table-striped">
                <thead>
                  <tr>
                    
                    <th scope="col">Debit</th>
                    <th scope="col">Credit</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="AssetRepeater" runat="server">
                        <ItemTemplate>
                             <tr>
                      <%# Eval("InnerHTML") %>
                    
                  </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                 
                  
                </tbody>
              </table>
                <strong runat="server" id="assetSumContainer">Total: &nbsp <span runat="server" id="assetSum" class="badge badge-primary"></span></strong>
                </div>
                    <div class="col-4">
                    <h6 class="card-title">Expense</h6>
                <table class="table table-striped">
                <thead>
                  <tr>
                    
                    <th scope="col">Debit</th>
                    <th scope="col">Credit</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="ExpenseRepeater" runat="server">
                        <ItemTemplate>
                             <tr>
                      <%# Eval("InnerHTML") %>
                    
                  </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                 
                  
                </tbody>
              </table>
                <strong runat="server" id="expenseSumContainer">Total: &nbsp <span runat="server" id="expenseSum" class="badge badge-primary"></span></strong>
                </div>
                    <div class="col-4">
                    <h6 class="card-title">Liability</h6>
                <table class="table table-striped">
                <thead>
                  <tr>
                    
                    <th scope="col">Debit</th>
                    <th scope="col">Credit</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="LiabilityRepeater" runat="server">
                        <ItemTemplate>
                             <tr>
                      <%# Eval("InnerHTML") %>
                    
                  </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                 
                  
                </tbody>
              </table>
                <strong runat="server" id="liabSumContainer">Total: &nbsp <span runat="server" id="liabSum" class="badge badge-primary"></span></strong>
                </div>
                    <div class="col-4">
                    <h6 class="card-title">Revenue</h6>
                <table class="table table-striped">
                <thead>
                  <tr>
                    
                    <th scope="col">Debit</th>
                    <th scope="col">Credit</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RevenueRepeater" runat="server">
                        <ItemTemplate>
                             <tr>
                      <%# Eval("InnerHTML") %>
                    
                  </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                 
                  
                </tbody>
              </table>
                <strong runat="server" id="revenueSumContainer">Total: &nbsp <span runat="server" id="revenueSum" class="badge badge-primary"></span></strong>
                </div>
                    <div class="col-4">
                    <h6 class="card-title">Capital</h6>
                <table class="table table-striped">
                <thead>
                  <tr>
                    
                    <th scope="col">Debit</th>
                    <th scope="col">Credit</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="CapitalRepeater" runat="server">
                        <ItemTemplate>
                             <tr>
                      <%# Eval("InnerHTML") %>
                    
                  </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                 
                  
                </tbody>
              </table>
                <strong runat="server" id="capitalSumContainer">Total: &nbsp <span runat="server" id="capitalSum" class="badge badge-primary"></span></strong>
                </div>
                
                </div>
                  
                
                
            </div>
          </div>

          

        </div>
      </div>
    </section>
  </main><!-- End #main -->
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerPlaceholder" runat="server">
</asp:Content>
