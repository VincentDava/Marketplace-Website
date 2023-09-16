<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage-Seller.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="Nusama.View.ProductDetail" %>
<asp:Content ID="Content2" ContentPlaceHolderID="StyleSheets" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%int customerRole = pullCustomerRole(); %>

    <div class="productDetail">
        <asp:Image ID="productImage" runat="server" width="500px" height="500px"></asp:Image>
        <div class="productDetail__wrapper">
            <asp:Label ID="nameLabel" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="ratingLabel" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="priceLabel" runat="server" Text="Label"></asp:Label>
            <%if (customerRole == 1){ %>
                <asp:Label ID="Label1" runat="server" Text="Color :"></asp:Label>
                <asp:RadioButtonList ID="ColorChoice" runat="server"></asp:RadioButtonList>
                <asp:Label ID="Label2" runat="server" Text="Size :"></asp:Label>
                <asp:RadioButtonList ID="SizeChoice" runat="server"></asp:RadioButtonList>
                <asp:Label ID="Label4" runat="server" Text="Quantity : "></asp:Label>
                <asp:TextBox class="input" ID="qtyBox" runat="server" type="number"></asp:TextBox>
            <%} %>
            <%if (customerRole == 1){ %>
            <asp:Button ID="addToCartBtn" runat="server" Text="Add to Cart" class="btn btn__large" OnClick="addToCartBtn_Click"/>
            <%} %>
        </div>
    </div>
    <div class="commentPage">
        <asp:Label ID="Label3" class="title" runat="server" Text="Comment :"></asp:Label>
        <%if (customerRole == 1){ %>
            <asp:Label ID="Label5" runat="server" Text="Your Comment : "></asp:Label>
            <div>
                <asp:Label ID="Label6" runat="server" Text="Title : "></asp:Label>
                <asp:TextBox class="input" ID="titleBox" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label7" runat="server" Text="Comment : "></asp:Label>
                <asp:TextBox class="input"  ID="commentBox" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label8" runat="server" Text="Rating [1 - 5] : "></asp:Label>
                <asp:TextBox class="input" ID="ratingBox" runat="server" type="number"></asp:TextBox>
            </div>
            <asp:Button class="btn btn__large" ID="addCommentBtn" runat="server" Text="Add Comment" OnClick="addCommentBtn_Click"/>
        <%} %>
        <asp:Repeater ID="commentsRepeater" runat="server">
            <ItemTemplate>
                <div class="commentPage__comments">
                    <span>Author : <%# Eval("customerName") %></span><br />
                    <span>Title : <%# Eval("commentTitle") %></span><br />
                    <span>Content : <%# Eval("commentContent") %></span><br />
                    <span>Rating : <%# Eval("commentRating") %></span>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>