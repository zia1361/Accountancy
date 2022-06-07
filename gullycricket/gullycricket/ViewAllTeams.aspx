<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Global.Master" AutoEventWireup="true" CodeBehind="ViewAllTeams.aspx.cs" Inherits="gullycricket.ViewAllTeams" %>
<%@ Register Src="~/UserControl/MessageBox.ascx" TagPrefix="uc1" TagName="MessageBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <main id="main" class="main">

    <div class="pagetitle">
      <h1>All Teams</h1>
      
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
                    <th scope="col">Team Name</th>
                    <th scope="col">Created On</th>
                      <th scope="col" class="text-center">No. of Players</th>
                        <th scope="col" class="text-center">Tournaments Partcipated</th>
                      <th scope="col" class="text-center">Matches Played</th>
                      <th scope="col" class="text-center">Matches Won</th>
                      <th scope="col" class="text-center">Matches Lost</th>
                    
                    <th scope="col">Actions</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="TeamRepeater" runat="server">
                        <ItemTemplate>
                             <tr>
                    <th scope="row"><%# Container.ItemIndex + 1 %></th>
                    <td><%# Eval("TeamName") %></td>
                    <td><%# Eval("RegisteredOnString") %></td>
                    <td class="text-center"><%# Eval("NumberOfPlayers") %></td>
                                  <td class="text-center"><%# Eval("NumberOfTournaments") %></td>
                                  <td class="text-center"><%# Eval("NumberOfMatchesPlayed") %></td>
                                  <td class="text-center"><%# Eval("NumberOfMatchesWon") %></td>
                                  <td class="text-center"><%# Eval("NumberOfMatchesLost") %></td>
                    
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
</asp:Content>
