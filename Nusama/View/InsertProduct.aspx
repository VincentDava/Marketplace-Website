<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage-Seller.Master" AutoEventWireup="true" CodeBehind="InsertProduct.aspx.cs" Inherits="Nusama.View.InsertProduct" %>
<asp:Content ID="Content2" ContentPlaceHolderID="StyleSheets" runat="server">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="insertproduct">
        <asp:Label CssClass="title" runat="server" Text="Insert Product"></asp:Label>

        <div>
            <asp:Label runat="server" Text="Name : "></asp:Label>
            <asp:TextBox CssClass="input" ID="nameBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="Price : "></asp:Label>
            <asp:TextBox CssClass="input" ID="priceBox" runat="server" type="number"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="Desc :"></asp:Label>
            <asp:TextBox CssClass="input" ID="descBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="Category :"></asp:Label>
            <asp:DropDownList ID="categoryDropdown" runat="server">
                <asp:ListItem Text="T-shirt" Value="tshirt"></asp:ListItem>
                <asp:ListItem Text="Accesories" Value="accesso"></asp:ListItem>
                <asp:ListItem Text="Shoes" Value="shoes"></asp:ListItem>
                <asp:ListItem Text="Pants" Value="pants"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="Image: "></asp:Label>
            <asp:FileUpload ID="imageUpload" runat="server"></asp:FileUpload>
        </div>

        <asp:Button ID="addBtn" CssClass="btn btn__large" runat="server" Text="Add Product" OnClick="addBtn_Click"/><br />
        <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
