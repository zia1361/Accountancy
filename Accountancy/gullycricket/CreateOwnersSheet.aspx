

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Global.Master" AutoEventWireup="true" 
    CodeBehind="CreateOwnersSheet.aspx.cs" Inherits="gullycricket.CreateOwnersSheet" %>

<%@ Register Src="~/UserControl/MessageBox.ascx" TagPrefix="uc1" TagName="MessageBox" %>

<asp:Content ID="Content4" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
         <main id="main" class="main">

    <div class="pagetitle">
      <h1>Create Owners Sheet</h1>
      
    </div><!-- End Page Title -->
    <section class="section">
      <div class="row">
        

        <div class="col-lg-12">
            <uc1:MessageBox runat="server" ID="MessageBox" />
          <div class="card">
            <div class="card-body">
              <h5 class="card-title"></h5>

              
              <div class="row g-3">
                <div class="col-5">
                    <div class="form-group">
                         <label for="date" class="form-label">Select Date</label>
                        <input type="date" class="form-control" id="date" runat="server"/>
                    </div>
                 
                  
                </div>
               
               
              
                <div class="text-center">
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" class="btn btn-primary" runat="server" Text="Generate" />
                  <a href="Dashboard.aspx" class="btn btn-secondary">Back</a>
                </div>
              </div><!-- Vertical Form -->

            </div>
          </div>

          

        </div>
      </div>
    </section>

         <section class="section">
      <div class="row">
        

        <div class="col-lg-12">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title text-center" runat="server" id="companyName"></h5>
                 <h5 class="card-title text-center">Owners Sheet</h5>
                <h5 class="card-title text-center" runat="server" id="generatedDate"></h5>
                
                <h6 class="card-title">Begining Balance of the year</h6>
                <table class="table table-striped">
                <thead>
                  <tr>
                    <th scope="col">#</th>
                    <th scope="col">Transaction Date</th>
                    <th scope="col">Amount</th>
                      <th scope="col">Transaction Type</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="CapitalRepeater" runat="server">
                        <ItemTemplate>
                             <tr>
                    <th scope="row"><%# Container.ItemIndex + 1 %></th>
                    <td scope="row"><%# Eval("TransactionDateString") %></td>
                     <td scope="row"><%# Eval("Amount") %></td>
                       <td scope="row"><%# Eval("TransactionTypeName") %></td>
                                 
                    
                  </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                 
                  
                </tbody>
              </table>
                <strong runat="server" id="beginingBalance" class="badge badge-primary text-left"></strong>
                  <h6 class="card-title">Net Income</h6>
                 <strong runat="server" id="netIncome" class="badge badge-primary text-left"></strong>

                 <h6 class="card-title">Ending Balance of the year</h6>
                 <strong runat="server" id="endingBalance" class="badge badge-secondary text-left"></strong>
                
            </div>
          </div>

          

        </div>
      </div>
    </section>
  </main><!-- End #main -->
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerPlaceholder" runat="server">
</asp:Content>
