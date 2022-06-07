<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Global.Master" AutoEventWireup="true" CodeBehind="CreateTeam.aspx.cs" Inherits="gullycricket.CreateTeam" %>

<%@ Register Src="~/UserControl/MessageBox.ascx" TagPrefix="uc1" TagName="MessageBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <main id="main" class="main">

    <div class="pagetitle">
      <h1>Create Team</h1>
      
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
                         <label for="teamName" class="form-label">Team Name</label>
                        <input type="text" class="form-control" id="teamName" runat="server">
                    </div>
                 
                  
                </div>
               
               
              
                <div class="text-center">
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" class="btn btn-primary" runat="server" Text="Submit" />
                  <a href="CreateTeam.aspx" class="btn btn-secondary">Reset</a>
                </div>
              </div><!-- Vertical Form -->

            </div>
          </div>

          

        </div>
      </div>
    </section>

  </main><!-- End #main -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footerPlaceholder" runat="server">
  
</asp:Content>
