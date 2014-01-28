<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Armor.aspx.cs" Inherits="Admin_Default2" Title="Untitled Page" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    &nbsp;Armor<br />
    <asp:DataList ID="DataList1" runat="server" DataKeyField="ItemName" DataSourceID="SqlDataSource1"
        Height="393px" Width="90%">
        <ItemTemplate>
            <asp:Label ID="ItemNameLabel" runat="server" Text='<%# Eval("ItemName") %>' style="font-weight: bold"></asp:Label>
            &nbsp; &nbsp;
            <asp:Label ID="ItemValueLabel" runat="server" Text='<%# Eval("ItemValue") %>'></asp:Label>
            &nbsp; &nbsp;
            <asp:Label ID="ItemDefenseLabel" runat="server" Text='<%# Eval("ItemDefense") %>'>
            </asp:Label>
            &nbsp; &nbsp;
            <asp:Label ID="StrReqLabel" runat="server" Text='<%# Eval("StrReq") %>'></asp:Label>
            &nbsp; &nbsp;
            <asp:Label ID="IntReqLabel" runat="server" Text='<%# Eval("IntReq") %>'></asp:Label><br />
            <asp:Label ID="ItemDescriptionLabel" runat="server" Text='<%# Eval("ItemDescription") %>'>
            </asp:Label>
        </ItemTemplate>
    </asp:DataList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WastelandDBConnectionString %>"
        SelectCommand="SELECT * FROM [ItemArmor]"></asp:SqlDataSource>
    <br />
    Insert New data:<br />
    <table cellpadding="2">
        <tr>
            <td style="width: 100px">
                Name</td>
            <td style="width: 50px">
                Value</td>
            <td style="width: 50px">
                Defense</td>
            <td style="width: 30%">
                Description</td>
            <td style="width: 100px">
                StrReq</td>
            <td style="width: 100px">
                IntReq</td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            <td style="width: 50px">
                <asp:TextBox ID="TextBox3" runat="server" Width="64px"></asp:TextBox></td>
            <td style="width: 50px">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
            <td style="width: 30%">
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
</asp:Content>
