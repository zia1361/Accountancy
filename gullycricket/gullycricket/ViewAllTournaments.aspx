<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Global.Master" AutoEventWireup="true" CodeBehind="ViewAllTournaments.aspx.cs" Inherits="gullycricket.ViewAllTournaments" %>

<%@ Register Src="~/UserControl/MessageBox.ascx" TagPrefix="uc1" TagName="MessageBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <main id="main" class="main">

    <div class="pagetitle">
      <h1>All Tournaments</h1>
      
    </div><!-- End Page Title -->
    <section class="section">
      <div class="row">
        

        <div class="col-lg-12">
            <uc1:MessageBox runat="server" ID="MessageBox" />
          <div class="card">
            <div class="card-body">
              <h5 class="card-title"></h5>
                <table class="table table-striped">
                <thead>
                  <tr>
                    <th scope="col">#</th>
                    <th scope="col">Tournament Name</th>
                    <th scope="col">Created On</th>
                    <th scope="col" class="text-center">No. of Teams</th>
                      <th scope="col" class="text-center">Winner</th>
                    <th scope="col" >Actions</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="TournamentRepeater" runat="server">
                        <ItemTemplate>
                             <tr>
                    <th scope="row"><%# Container.ItemIndex + 1 %></th>
                    <td><%# Eval("TournamentName") %></td>
                    <td><%# Eval("RegisteredOnString") %></td>
                    <td class="text-center"><%# Eval("NumberOfTeams") %></td>
                    <td class="text-center"><%# Eval("WinnerTeamName") %></td>
                                 <td>
                                     <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="if (!confirm('Are you sure you want delete?')) return false;" OnClick="btnDelete_Click" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger actionBtn"><i class="bi bi-trash"></i></asp:LinkButton>
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
</asp:Content>
