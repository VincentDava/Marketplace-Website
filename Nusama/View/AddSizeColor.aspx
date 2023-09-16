<%@ Page Title="" enableEventValidation="false" Language="C#" MasterPageFile="~/View/MasterPage-Seller.Master" AutoEventWireup="true" CodeBehind="AddSizeColor.aspx.cs" Inherits="Nusama.View.AddSizeColor" %>
<asp:Content ID="Content2" ContentPlaceHolderID="StyleSheets" runat="server">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="insertproduct">
        <div class="title">
            <asp:Label runat="server" Text="Add Color and Size Option"></asp:Label>
            <asp:Label runat="server" ID="productIdLabel" Text="Product ID"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" Text="Add Color :"></asp:Label>
            <asp:TextBox ID="colorBox" runat="server"></asp:TextBox>
            <asp:Button ID="addColorBtn" runat="server" Text="Add" OnClick="addColorBtn_Click"/>
            <asp:Label runat="server" ID="colorStatus" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" Text="Add Size :"></asp:Label>
            <asp:TextBox ID="sizeBox" runat="server"></asp:TextBox>
            <asp:Button ID="addSizeBtn" runat="server" Text="Add" OnClick="addSizeBtn_Click"/>
            <asp:Label runat="server" ID="sizeStatus" Text=""></asp:Label>
            <asp:Label runat="server" ID="statusLabel" Text=""></asp:Label>
        </div>
   

        <asp:Label CssClass="title" runat="server" Text="Delete Color"></asp:Label>
        <div class="color__wrapper">
            <asp:Repeater ID="ColorRepeater" runat="server">
                <ItemTemplate>
                    <div>
                        <span><%# Eval("colorName") %></span><br />
                        <asp:Button CssClass="btn" Text="Delete" runat="server" ID="deleteColorBtn" OnClick="deleteColorBtn_Click" CommandArgument='<%# Eval("colorName") %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>


        <asp:Label CssClass="title" runat="server" Text="Delete Size"></asp:Label>
        <div class="size__wrapper">
            <asp:Repeater ID="SizeRepeater" runat="server">
                <ItemTemplate>
                    <div>
                        <span> <%# Eval("productSize") %></span><br />
                        <asp:Button CssClass="btn" Text="Delete" runat="server" ID="deleteSizeBtn" OnClick="deleteSizeBtn_Click" CommandArgument='<%# Eval("productSize") %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
