<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Nusama.View.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/Navigation.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Main.css" rel="stylesheet" type="text/css" />

    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@100;300;400;500;600;700&family=Karma:wght@300;400;500;600;700&family=Montserrat:wght@300;400;500;600;700&display=swap" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login">
            <asp:Label CssClass="title" ID="Label1" runat="server" Text="Login Page"></asp:Label>
            <div>
                <asp:Label ID="nameLabel" runat="server" Text="Email : "></asp:Label>
                <asp:TextBox ID="emailBox" CssClass="input" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Password : "></asp:Label>
                <input id="passBox" class="input" type="password" runat="server"/>
            </div>
            <asp:Button ID="loginBtn" CssClass="btn btn__large" runat="server" Text="Login" OnClick="loginBtn_Click"/>
            <asp:Button ID="guestBtn" CssClass="btn btn__large" runat="server" Text="Continue as Guest" OnClick="guestBtn_Click"/>
            <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
