<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBox.ascx.cs" Inherits="gullycricket.UserControl.MessageBox" %>

<div  runat="server" id="messageContainer" role="alert">
  <strong runat="server" id="messageIcon"></strong> <asp:Literal ID="messageText" runat="server"></asp:Literal>
  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
    <span aria-hidden="true">&times;</span>
  </button>
</div>