<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage-Customer.Master" AutoEventWireup="true" CodeBehind="TransactionList.aspx.cs" Inherits="Nusama.View.TransactionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="transactionlist">
        <asp:Label CssClass="title" runat="server" Text="Transaction List"></asp:Label>

        <asp:Repeater ID="transactionRepeater" runat="server">
            <ItemTemplate>
                <div class="transactionlist__wrapper">
                    <span>Transaction ID : <%# Eval("transactionId") %></span>
                    <span>Time : <%# Eval("transactionDate") %></span>
                    <span>Address : <%# Eval("address") %></span>
                    <asp:Button CssClass="btn btn__large" Text="Detail" ID="tranDetailBtn" runat="server" OnClick="tranDetailBtn_Click" CommandArgument='<%# Eval("transactionId") %>'/>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
