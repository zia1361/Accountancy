<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="gullycricket.SignUp" %>

<%@ Register Src="~/UserControl/MessageBox.ascx" TagPrefix="uc1" TagName="MessageBox" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="assets/fonts/icomoon/style.css">

    <link rel="stylesheet" href="assets/css/owl.carousel.min.css">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css">
    
    <!-- Style -->
    <link rel="stylesheet" href="assets/css/style.css">

      <link href="assets/fontawesome-free-6.1.1-web/css/fontawesome.min.css" rel="stylesheet" />


</head>
<body>
    <form id="form1" runat="server">
         <div class="d-lg-flex half">
    <div class="bg order-1 order-md-2" style="background-image: url('assets/images/bg.jpg');"></div>
    <div class="contents order-2 order-md-1">

      <div class="container">
        <div class="row align-items-center justify-content-center">
          <div class="col-md-7">
            <h3>Register to <strong>Accountancy</strong></h3>
            
              <uc1:MessageBox runat="server" ID="MessageBox" />
              <div class="form-group">
                <label for="username">Company Name</label>
                <input type="text" class="form-control" runat="server" placeholder="Airlift" id="username"/>
              </div>
              <div class="form-group">
                <label for="userEmail">Email</label>
                <input type="email" class="form-control" runat="server" placeholder="your-email@gmail.com" id="userEmail"/>
              </div>
              <div class="form-group">
                <label for="userId">Login ID</label>
                <input type="text" class="form-control" runat="server" placeholder="John-123" id="loginId"/>
              </div>
              <div class="form-group last mb-3">
                <label for="password">Password</label>
                <input type="password" class="form-control" runat="server" placeholder="Your Password" id="password"/>
              </div>
              
                <asp:Button ID="btnSignUp" OnClick="btnSignUp_Click" runat="server" Text="Sign Up" class="btn btn-block btn-secondary" />
              

                
              Already have an account ?<input type="button" value="Login" class="btn btn-block btn-outline-primary" onclick="window.location.href='signin.aspx'"/>
              

            
          </div>
        </div>
      </div>
    </div>

    
  </div>
    </form>
    
    <script src="assets/js/jquery-3.3.1.min.js"></script>
    <script src="assets/js/popper.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/main.js"></script>
    <script src="assets/fontawesome-free-6.1.1-web/js/fontawesome.min.js"></script>
  

</body>
</html>
