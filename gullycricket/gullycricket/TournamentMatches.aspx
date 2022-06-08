<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Global.Master" AutoEventWireup="true" CodeBehind="TournamentMatches.aspx.cs" Inherits="gullycricket.TournamentMatches" %>

<%@ Register Src="~/UserControl/MessageBox.ascx" TagPrefix="uc1" TagName="MessageBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <main id="main" class="main">

    <div class="pagetitle">
      <h1>Add Match</h1>
      
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
                         <label for="TeamList" class="form-label">Select Team 1</label>
                          <asp:DropDownList ClientIDMode="Static" ID="TeamList" class="form-control" runat="server"></asp:DropDownList>
                        
                    </div>
                 
                  
                </div>

                  <div class="col-6">
                    <div class="form-group">
                         <label for="TeamList2" class="form-label">Select Team 2</label>
                          <asp:DropDownList ClientIDMode="Static" ID="TeamList2" class="form-control" runat="server"></asp:DropDownList>
                        
                    </div>
                 
                  
                </div>
               <div class="col-6">
                    <div class="form-group">
                         <label for="startDate" class="form-label">Start Date</label>
                        <input type="date" runat="server" class="form-control" clientidmode="static" id="startDate"/>                        
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
      <h1>Tournament Matches</h1>
      
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
                    <th scope="col">Teams</th>
                      <th scope="col" class="text-center">Starting Date</th>
                      <th scope="col" class="text-center">Match Status</th>
                      <th scope="col" class="text-center">Toss Winner</th>
                      <th scope="col" class="text-center">Current Inning</th>
                      <th scope="col" class="text-center">Target Score</th>
                      <th scope="col" class="text-center">Match Winner</th>
                      
                    <th scope="col" class="text-center">Actions</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="MatchRepeater" runat="server">
                        <ItemTemplate>
                             <tr>
                    <th scope="row"><%# Container.ItemIndex + 1 %></th>
                    <td><%# Eval("Team1Name") %> V/S <%# Eval("Team2Name") %></td>
                    <td class="text-center"><%# Eval("StartingDateString") %></td>
                                  <td class="text-center"><%# Eval("MatchStatusName") %></td>
                                 <td class="text-center"><%# Eval("TossWinningTeamName") %></td>
                                 <td class="text-center"><%# Eval("CurrentInningTeamName") %></td>
                    <td class="text-center"><%# Convert.ToInt32(Eval("TargetScore")) == 0 ? "N/A" : Eval("TargetScore") %></td>
                                 <td class="text-center"><%# Eval("WinnerTeamName") %></td>
                                 <td class="text-center">
                                     <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="if (!confirm('Are you sure you want to delete this match from tournament?')) return false;" OnClick="btnDelete_Click" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger actionBtn btn-sm" data-bs-toggle="tooltip" data-bs-placement="top" title="Delete"><i class="bi bi-trash"></i></asp:LinkButton>
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
