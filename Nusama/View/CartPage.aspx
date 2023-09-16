<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage-Customer.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="Nusama.View.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cartpage">
        <asp:Label runat="server" Text="Cart" CssClass="title"></asp:Label>
    
        <asp:Repeater ID="cartRepeater" runat="server">
            <ItemTemplate>
                <div class="cartpage__wrapper">
                    <asp:Image ID="productImage" runat="server" ImageUrl='<%# Eval("productImage") %>' Width="300px" Height="300px"/>
                    <div class="cartpage__wrapper--middle">
                        <span>Name : <%# Eval("productName") %></span>
                        <span>Color : <%# Eval("productColor") %></span>
                        <span>Size : <%# Eval("productSize") %></span>
                    </div>
                    <div class="cartpage__wrapper--last">
                        <span>Price : <%# Eval("productPrice") %></span>
                        <span>Quantity : <%# Eval("productQuantity") %></span>
                        <asp:Button ID="removeBtn" CssClass="btn" runat="server" Text="Remove" OnClick="removeBtn_Click" CommandArgument='<%# Eval("cartId") %>'/>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Button ID="checkOut" CssClass="btn" runat="server" Text="CheckOut" OnClick="checkOut_Click" />
    </div>
</asp:Content>
