<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage-Customer.Master" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="Nusama.View.CheckoutPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="StyleSheets" runat="server">
    <link href="../CSS/Navigation.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Main.css" rel="stylesheet" type="text/css" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@100;300;400;500;600;700&family=Karma:wght@300;400;500;600;700&family=Montserrat:wght@300;400;500;600;700&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="checkoutPage">
        <asp:Label runat="server" class="title title--checkout" Text="CheckOut"></asp:Label>
        <br /><br />
        <div class="checkoutPage__address">
            <asp:Label ID="Label1" runat="server" Text="Address :"></asp:Label><br />
            <asp:TextBox ID="addressBox" class="input" runat="server"></asp:TextBox>
        </div>
        <br /><br />
        <asp:Repeater ID="cartRepeater" runat="server">
            <ItemTemplate>
                <div>
                    <span>Name : <%# Eval("productName") %></span><br />
                    <asp:Image ID="productImage" runat="server" ImageUrl='<%# Eval("productImage") %>' Width="300px" Height="300px"/><br />
                    <span>Price : <%# Eval("productPrice") %></span><br />
                    <span>Quantity : <%# Eval("productQuantity") %></span><br />
                    <span>Color : <%# Eval("productColor") %></span><br />
                    <span>Size : <%# Eval("productSize") %></span><br />
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="checkoutPage__details">
            <asp:Label runat="server" class="title" Text="Payment Detail"></asp:Label>
            <asp:Label runat="server" Text="Subtotal Product : "></asp:Label>
            <asp:Label ID="subtotalLabel" runat="server" Text=""></asp:Label>
            <asp:Label runat="server" Text="Shipping Fee : 30000"></asp:Label>
            <asp:Label runat="server" Text="Service Fee : 5000"></asp:Label>
            <asp:Label runat="server" Text="Total Payment : "></asp:Label>
            <asp:Label ID="totalLabel" runat="server" Text=""></asp:Label>

            <asp:RadioButtonList class="input--radio" ID="PaymentMethod" runat="server">
                <asp:ListItem Text=" OVO" Value="OVO" />
                <asp:ListItem Text=" Dana" Value="Dana" />
                <asp:ListItem Text=" PayPal" Value="PayPal" />
                <asp:ListItem Text=" AmazonPay" Value="AmazonPay" />
                <asp:ListItem Text=" BCA" Value="BCA" />
            </asp:RadioButtonList>
            
            <asp:Button ID="confirmBtn" class="btn btn__large" runat="server" Text="Confirm" OnClick="confirmBtn_Click" />
        </div>

    </div>
</asp:Content>
