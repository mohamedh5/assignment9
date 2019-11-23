<%@ Page Title="login" Language="C#"MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="logIn.aspx.cs" Inherits="Store.login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="text-align:center">
        
        <h1>Login</h1>
            UserName :
            <asp:TextBox ID="txt_name" runat="server" Width="20%"></asp:TextBox>
        <br />
            Password :
            <asp:TextBox ID="txt_pass" runat="server" Width="20%"></asp:TextBox>
        <br />
            <asp:Button ID="btn_login" runat="server" Text="login" Width="10%" OnClick="btn_login_Click" />
        <div style="background-color:red" runat="server" id="error"></div>
    </div>

</asp:Content>
