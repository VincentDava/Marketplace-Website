<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage-Customer.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Nusama.View.Homepage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="StyleSheets" runat="server">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     
    <div class="homepage">
        <asp:Label ID="Label2" runat="server" class="title" Text="Today's Offer"></asp:Label><br />
        <div class="product__wrapper">
            <%foreach(var x in db.Products) {%>
                <div class="product">
                    <a class="product__link" href="<%= ResolveUrl("~/View/ProductDetail.aspx?productId=") + HttpUtility.UrlEncode(x.productId.ToString()) %>">
                        <img class="product__img" src='<%= x.productImage%>' alt="Album Image" width="100" height="100"/>
                        <p class="product__title"><%= x.productName %></p>
                        <p> Rp. <%= x.productPrice %></p>
                        <p><%= x.productRating %></p>
                    </a>
                </div>
            <% }%>
        </div>
    </div>
</asp:Content>
