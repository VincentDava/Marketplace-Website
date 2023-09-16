<%@ Page Title="" enableEventValidation="false" Language="C#" MasterPageFile="~/View/MasterPage-Seller.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="Nusama.View.SearchPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="StyleSheets" runat="server">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="searchpage">
        <asp:Label CssClass="title" runat="server" Text="Search"></asp:Label>
        <asp:Label ID="keyBox" runat="server" Text=""></asp:Label>
        <asp:Repeater ID="resultRepeater" runat="server">
            <ItemTemplate>
                <div class="searchpage__wrapper">
                    <asp:Image ImageUrl=' <%# Eval("productImage") %>' runat="server" width="200px" Height="200px"/>
                    <div class="searchpage__wrapper--inside">
                        <span>Name : <%# Eval("productName") %></span>
                        <span>Price : <%# Eval("productPrice") %></span>
                        <span>Rating : <%# Eval("productRating") %></span>
                        <asp:Button CssClass="btn" ID="moreDetailBtn" Text="More Detail" runat="server" OnClick="moreDetailBtn_Click" CommandArgument='<%# Eval("productId") %>'/>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
