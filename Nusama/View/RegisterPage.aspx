<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Nusama.View.RegisterPage" %>

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
            <asp:Label CssClass="title" ID="Label1" runat="server" Text="Register Page"></asp:Label>
            <div>
                <asp:Label ID="nameLabel" runat="server" Text="Name : "></asp:Label>
                <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label4" runat="server" Text="Email : "></asp:Label>
                <asp:TextBox ID="emailBox" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Password : "></asp:Label>
                <input id="passBox" type="password" runat="server"/>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Confirm Password : "></asp:Label>
                <input id="cPassBox" type="password" runat="server"/>
            </div>
            <div>
                <asp:Label ID="Label5" runat="server" Text="Address : "></asp:Label>
                <asp:TextBox ID="addressBox" runat="server"></asp:TextBox>
            </div>

            <asp:Button CssClass="btn btn__large" ID="registerBtn" runat="server" Text="Button" OnClick="registerBtn_Click"/>

        </div>
    </form>
</body>
</html>
