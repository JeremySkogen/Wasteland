<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Enemies.aspx.cs" Inherits="Admin_Default3" Title="Untitled Page" %>
<%-- Add content controls here --%>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <br />
    <br />
    Enemy &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; Defense&nbsp; Offense<br />
    <asp:DataList ID="DataList1" Width="100%" runat="server" DataKeyField="Name" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' style="font-weight: bold"></asp:Label>
            &nbsp; &nbsp;
            <asp:Label ID="DefenseLabel" runat="server" Text='<%# Eval("Defense") %>'></asp:Label>
            &nbsp; &nbsp;
            <asp:Label ID="OffenseLabel" runat="server" Text='<%# Eval("Offense") %>'></asp:Label><br />
            <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>'></asp:Label><br />
            <br />
        </ItemTemplate>
    </asp:DataList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WastelandDBConnectionString %>"
        SelectCommand="SELECT * FROM [Enemy]"></asp:SqlDataSource>
    <br />
    &nbsp;Insert New data:<br />
    <table cellpadding="2">
        <tr>
            <td style="width: 100px">
                Name</td>
            <td style="width: 50px">
                Defense</td>
            <td style="width: 50px">
                Offense</td>
            <td colspan="3">
                Description</td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            <td style="width: 50px">
                <asp:TextBox ID="TextBox3" runat="server" Width="64px"></asp:TextBox></td>
            <td style="width: 50px">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
            <td colspan="3">
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
</asp:Content>
