<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage-Seller.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="Nusama.View.EditProduct" %>
<asp:Content ID="Content2" ContentPlaceHolderID="StyleSheets" runat="server">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="insertproduct">
        <asp:Label CssClass="title" runat="server" Text="Edit Product"></asp:Label>
        <div>
            <asp:Label runat="server" Text="Name : "></asp:Label>
            <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="Price : "></asp:Label>
            <asp:TextBox ID="priceBox" runat="server" type="number"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="Desc :"></asp:Label>
            <asp:TextBox ID="descBox" runat="server"></asp:TextBox>
        </div>
        <div class="insertproduct--img">
            <asp:Label runat="server" Text="Image : "></asp:Label>
            <asp:Image ID="currentImage" runat="server" width="500px" Height="500px"/>
            <asp:FileUpload ID="imageUpload" runat="server"></asp:FileUpload>
        </div>

        <asp:Button CssClass="btn btn__large" ID="updateBtn" runat="server" Text="Add Product" OnClick="updateBtn_Click"/>
        <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
    </div>

    

</asp:Content>
