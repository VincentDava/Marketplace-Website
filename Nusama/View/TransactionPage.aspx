<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage-Customer.Master" AutoEventWireup="true" CodeBehind="TransactionPage.aspx.cs" Inherits="Nusama.View.TransactionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" Text="Transaction"></asp:Label>
    <br /><br />
    <asp:Label ID="Label2" runat="server" Text="Delivery :"></asp:Label><br />
    <asp:Label ID="Label1" runat="server" Text="Completed"></asp:Label><br />
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
            <hr />
        </ItemTemplate>
    </asp:Repeater>

    <asp:Label runat="server" Text="Payment Detail"></asp:Label><br />
    <asp:Label runat="server" Text="Subtotal Product : "></asp:Label>
    <asp:Label ID="subtotalLabel" runat="server" Text=""></asp:Label><br />
    <asp:Label runat="server" Text="Shipping Fee : 30000"></asp:Label><br />
    <asp:Label runat="server" Text="Service Fee : 5000"></asp:Label><br />
    <asp:Label runat="server" Text="Total Payment :"></asp:Label>
    <asp:Label ID="totalLabel" runat="server" Text=""></asp:Label>
    <br /><br />

    <asp:Button ID="homeBtn" runat="server" Text="Home" OnClick="homeBtn_Click" />
</asp:Content>
