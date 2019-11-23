<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Capthca.Default" %>
<%@ Register TagPrefix = "img" TagName="imageVerifier" src="captcha.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img:imageVerifier runat="server" />
            <br />
            <asp:TextBox ID="txt_verify" runat="server"></asp:TextBox>
            <asp:button id="sumbit" runat="server" Text="sumit" OnClick="sumbit_Click"/>
        </div>
    </form>
</body>
</html>
