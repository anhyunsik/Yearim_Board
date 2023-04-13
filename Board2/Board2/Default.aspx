<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Board2._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>로그인</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>로그인</h1>
            아이디 : <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox><br />
            암호   : <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="btnLogin" runat="server" Text="로그인" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>