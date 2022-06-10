<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Global.Master" AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs" Inherits="Accountancy.Profile" %>

<%@ Register Src="~/UserControl/MessageBox.ascx" TagPrefix="uc1" TagName="MessageBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <main id="main" class="main">
      
    <div class="pagetitle">
      <h1>Profile</h1>
      
    </div><!-- End Page Title -->

    <section class="section profile">
          <uc1:MessageBox runat="server" ID="MessageBox" />

        
      <div class="row">
        <div class="col-xl-4">

          <div class="card">
            <div class="card-body profile-card pt-4 d-flex flex-column align-items-center">

              <img src="../assets/assets/img/profile-img.jpg" runat="server" id="userImageView" alt="Profile" class="rounded-circle profile-img">
              <h2 runat="server" id="userNameView">Company Name</h2>
              
            </div>
          </div>

        </div>

        <div class="col-xl-8">

          <div class="card">
            <div class="card-body pt-3">
              <!-- Bordered Tabs -->
              <ul class="nav nav-tabs nav-tabs-bordered">

                <li class="nav-item">
                  <button class="nav-link active" type="button" data-bs-toggle="tab" data-bs-target="#profile-overview">Overview</button>
                </li>

                <li class="nav-item">
                  <button class="nav-link" type="button" data-bs-toggle="tab" data-bs-target="#profile-edit">Edit Profile</button>
                </li>

                

                <li class="nav-item">
                  <button class="nav-link" type="button" data-bs-toggle="tab" data-bs-target="#profile-change-password">Change Password</button>
                </li>

              </ul>
              <div class="tab-content pt-2">

                <div class="tab-pane fade show active profile-overview" id="profile-overview">
                 
                  <h5 class="card-title">Profile Details</h5>

                  <div class="row">
                    <div class="col-lg-3 col-md-4 label ">Company Name</div>
                    <div class="col-lg-9 col-md-8" runat="server" id="userNameOverView">N/A</div>
                  </div>

                  

                  <div class="row">
                    <div class="col-lg-3 col-md-4 label">Email</div>
                    <div class="col-lg-9 col-md-8" runat="server" id="emailOverView">N/A</div>
                  </div>

                  <div class="row">
                    <div class="col-lg-3 col-md-4 label">Login ID</div>
                    <div class="col-lg-9 col-md-8" runat="server" id="loginIdOverview">N/A</div>
                  </div>

                  <div class="row">
                    <div class="col-lg-3 col-md-4 label">Registered On</div>
                    <div class="col-lg-9 col-md-8" runat="server" id="registerationDateVoverview">N/A</div>
                  </div>

                 

                  

                </div>

                <div class="tab-pane fade profile-edit pt-3" id="profile-edit">

                  <!-- Profile Edit Form -->
                  <div>
                    <div class="row mb-3">
                      <label for="profileImage" class="col-md-4 col-lg-3 col-form-label">Profile Image</label>
                      <div class="col-md-8 col-lg-9">
                        <img src="../assets/assets/img/profile-img.jpg" alt="Profile" runat="server" clientidmode="static" id="profileImageUpload">
                        <div class="pt-2">
                            <asp:FileUpload ID="profileImageControl" ClientIDMode="Static"  runat="server" class="form-control" />
                   
                  
                          
                        </div>
                      </div>
                    </div>

                    <div class="row mb-3">
                      <label for="fullName" class="col-md-4 col-lg-3 col-form-label">Company Name</label>
                      <div class="col-md-8 col-lg-9">
                        <input name="fullName" type="text" class="form-control" id="userNameControl" runat="server">
                      </div>
                    </div>


                    <div class="row mb-3">
                      <label for="company" class="col-md-4 col-lg-3 col-form-label">Email</label>
                      <div class="col-md-8 col-lg-9">
                        <input name="company" type="text" class="form-control" id="userEmailcontrol" runat="server" >
                      </div>
                    </div>

                    <div class="row mb-3">
                      <label for="Job" class="col-md-4 col-lg-3 col-form-label">Login ID</label>
                      <div class="col-md-8 col-lg-9">
                        <input name="job" type="text" class="form-control" id="loginIdControl" runat="server" >
                      </div>
                    </div>

                    

                    

                    

                   

                    <div class="text-center">
                        <asp:Button ID="btnSave" class="btn btn-primary" OnClick="btnSave_Click" runat="server" Text="Save Changes" />
                      
                    </div>
                  </div><!-- End Profile Edit Form -->

                </div>

                

                <div class="tab-pane fade pt-3" id="profile-change-password">
                  <!-- Change Password Form -->
                  <div>

                    <div class="row mb-3">
                      <label for="currentPassword" class="col-md-4 col-lg-3 col-form-label">Current Password</label>
                      <div class="col-md-8 col-lg-9">
                          <asp:TextBox ID="currentPasswordControl" class="form-control" runat="server"></asp:TextBox>
                      </div>
                    </div>

                    <div class="row mb-3">
                      <label for="newPassword" class="col-md-4 col-lg-3 col-form-label">New Password</label>
                      <div class="col-md-8 col-lg-9">

                          <asp:TextBox ID="newPasswordControl" class="form-control" runat="server"></asp:TextBox>
                      </div>
                    </div>

                    <div class="row mb-3">
                      <label for="renewPassword" class="col-md-4 col-lg-3 col-form-label">Re-enter New Password</label>
                      <div class="col-md-8 col-lg-9">
                          <asp:TextBox ID="renewPasswordControl" class="form-control" runat="server"></asp:TextBox>

                      </div>
                    </div>

                    <div class="text-center">

                        <asp:Button ID="btnChangePassword" OnClick="btnChangePassword_Click" runat="server" class="btn btn-primary" Text="Change Password" />
                      
                    </div>
                  </div><!-- End Change Password Form -->

                </div>

              </div><!-- End Bordered Tabs -->

            </div>
          </div>

        </div>
      </div>
    </section>

  </main><!-- End #main -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footerPlaceholder" runat="server">
    <script>
        $("#profileImageControl").change(function () {
            if (this.files.length > 0) {
                $("#profileImageUpload").attr("src", URL.createObjectURL(this.files[0]))
            }
        });
    </script>
</asp:Content>
