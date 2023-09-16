<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage-Seller.Master" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="Nusama.View.ProductPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="productPage">
        <asp:Label runat="server" Text="Product List" CssClass="title"></asp:Label>
        <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
        <asp:Label ID="errorLabel1" runat="server" Text=""></asp:Label>
    
        <asp:Repeater ID="productRepeater" runat="server" OnItemDataBound="parentRepeater_ItemDataBound">
            <ItemTemplate>
                <div class="productPage__wrapper">
                    <asp:Image CssClass="productPage__img" ID="productImage" runat="server" ImageUrl='<%# Eval("productImage") %>' Width="300px" Height="300px"/>
                    <div>
                        <span>Name : <%# Eval("productName") %></span><br />
                        <span>Price : <%# Eval("productPrice") %></span>
                        <span>Rating : <%# Eval("productRating") %></span>
                        <asp:Label runat="server" Text="Color :"></asp:Label>
                        <asp:Repeater ID="ColorRepeater" runat="server">
                            <ItemTemplate>
                                <div>
                                    <span> <%# Container.DataItem %></span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <br />
                        <asp:Label runat="server" Text="Size :"></asp:Label>
                        <asp:Repeater ID="SizeRepeater" runat="server">
                            <ItemTemplate>
                                <div>
                                    <span> <%# Container.DataItem %></span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="productPage__wrapper--btn">
                        <asp:Button CssClass="btn" ID="addColorSize" runat="server" Text="Add Color or Size" OnClick="addColorSize_Click" CommandArgument='<%# Eval("productId") %>'/>
                        <asp:Button CssClass="btn" ID="editBtn" runat="server" Text="Edit" OnClick="editBtn_Click" CommandArgument='<%# Eval("productId") %>'/>
                        <asp:Button CssClass="btn" ID="removeBtn" runat="server" Text="Remove" OnClick="removeBtn_Click" CommandArgument='<%# Eval("productId") %>'/>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    
    
</asp:Content>
