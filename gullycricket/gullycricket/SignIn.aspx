<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="gullycricket.SignIn" %>

<%@ Register Src="~/UserControl/MessageBox.ascx" TagPrefix="uc1" TagName="MessageBox" %>











<!doctype html>
<html lang="en">
  <head>
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

    <title>SignIn</title>
  </head>
  <body>
  

  <div class="d-lg-flex half">
    <div class="bg order-1 order-md-2" style="background-image: url('assets/images/bg.jpeg');"></div>
    <div class="contents order-2 order-md-1">

      <div class="container">
        <div class="row align-items-center justify-content-center">
          <div class="col-md-7">
            <h3>Login to <strong>Gully Cricket</strong></h3>
            <p class="mb-4">Cricket khelo aur dhoom machao.</p>
             
            <form id="Form1" runat="server">
                <uc1:MessageBox runat="server" ID="MessageBox" />
              <div class="form-group first">
                <label for="username">Login ID</label>
                <input type="text" class="form-control"  runat="server" placeholder="your login ID" id="loginId">
              </div>
              <div class="form-group last mb-3">
                <label for="password">Password</label>
                <input type="password" class="form-control"  runat="server" placeholder="Your Password" id="password">
              </div>
              
              
                <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" class="btn btn-block btn-primary" />

              <input type="button" value="Create new account" class="btn btn-block btn-outline-secondary" onclick="window.location.href='signup.aspx'">

            </form>
          </div>
        </div>
      </div>
    </div>

    
  </div>
    
    

    <script src="assets/js/jquery-3.3.1.min.js"></script>
    <script src="assets/js/popper.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/main.js"></script>
      <script src="assets/fontawesome-free-6.1.1-web/js/fontawesome.min.js"></script>
  </body>
</html>