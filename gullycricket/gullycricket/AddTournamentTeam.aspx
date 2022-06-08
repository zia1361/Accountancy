<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Global.Master" AutoEventWireup="true" CodeBehind="AddTournamentTeam.aspx.cs" Inherits="gullycricket.AddTournamentTeam" %>

<%@ Register Src="~/UserControl/MessageBox.ascx" TagPrefix="uc1" TagName="MessageBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <main id="main" class="main">

    <div class="pagetitle">
      <h1>Add Team</h1>
      
    </div><!-- End Page Title -->
    <section class="section">
      <div class="row">
        

        <div class="col-lg-12">
            <uc1:MessageBox runat="server" ID="MessageBox" />
          <div class="card">
            <div class="card-body">
              <h5 class="card-title"></h5>

              
              <div class="row g-3">
                <div class="col-6">
                    <div class="form-group">
                         <label for="TeamList" class="form-label">Select Team</label>
                          <asp:DropDownList ClientIDMode="Static" ID="TeamList" class="form-control" runat="server"></asp:DropDownList>
                        
                    </div>
                 
                  
                </div>
               
               
              
                <div class="text-center">
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" class="btn btn-primary" runat="server" Text="Submit" />
                  <a href="ViewAllTournaments.aspx" class="btn btn-secondary">Back</a>
                </div>
              </div><!-- Vertical Form -->

            </div>
          </div>



          

        </div>
      </div>
    </section>

        <div class="pagetitle">
      <h1>Added Teams</h1>
      
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
                    <th scope="col">Team Name</th>
                      <th scope="col" class="text-center">No. of Players</th>
                    <th scope="col">Actions</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="TeamRepeater" runat="server">
                        <ItemTemplate>
                             <tr>
                    <th scope="row"><%# Container.ItemIndex + 1 %></th>
                    <td><%# Eval("TeamName") %></td>
                    <td class="text-center"><%# Eval("NumberOfPlayers") %></td>
                    
                                 <td>
                                     <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="if (!confirm('Are you sure you want to remove this team from tournament?')) return false;" OnClick="btnDelete_Click" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger actionBtn btn-sm" data-bs-toggle="tooltip" data-bs-placement="top" title="Remove Team"><i class="bi bi-trash"></i></asp:LinkButton>
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
