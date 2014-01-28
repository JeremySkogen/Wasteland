<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Weapons.aspx.cs" Inherits="Admin_Weapons" Title="Untitled Page" %>
<%-- Add content controls here --%>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    Weapons<br />
    <asp:DataList ID="DataList1" runat="server" DataKeyField="ItemName" DataSourceID="SqlDataSource2">
        <ItemTemplate>
            <asp:Label ID="ItemNameLabel" runat="server" Text='<%# Eval("ItemName") %>' style="font-weight: bold"></asp:Label>
            &nbsp; &nbsp; &nbsp;
            <asp:Label ID="ItemValueLabel" runat="server" Text='<%# Eval("ItemValue") %>'></asp:Label>
            &nbsp; &nbsp; &nbsp;
            <asp:Label ID="ItemOffenseLabel" runat="server" Text='<%# Eval("ItemOffense") %>'></asp:Label>
            &nbsp; &nbsp; &nbsp;
            <asp:Label ID="StrReqLabel" runat="server" Text='<%# Eval("StrReq") %>'></asp:Label>
            &nbsp; &nbsp; &nbsp;
            <asp:Label ID="IntReqLabel" runat="server" Text='<%# Eval("IntReq") %>'></asp:Label><br />
            <asp:Label ID="ItemDescriptionLabel" runat="server" Text='<%# Eval("ItemDescription") %>'></asp:Label>
        </ItemTemplate>
    </asp:DataList>
    <asp:DataList ID="DataList2" runat="server" DataKeyField="UserID" DataSourceID="SqlDataSource2">
        <ItemTemplate>
            UserID:
            <asp:Label ID="UserIDLabel" runat="server" Text='<%# Eval("UserID") %>'></asp:Label><br />
            Name:
            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>'></asp:Label><br />
            Sex:
            <asp:Label ID="SexLabel" runat="server" Text='<%# Eval("Sex") %>'></asp:Label><br />
            Class:
            <asp:Label ID="ClassLabel" runat="server" Text='<%# Eval("Class") %>'></asp:Label><br />
            Str:
            <asp:Label ID="StrLabel" runat="server" Text='<%# Eval("Str") %>'></asp:Label><br />
            Int:
            <asp:Label ID="IntLabel" runat="server" Text='<%# Eval("Int") %>'></asp:Label><br />
            HealthCur:
            <asp:Label ID="HealthCurLabel" runat="server" Text='<%# Eval("HealthCur") %>'></asp:Label><br />
            HealthMax:
            <asp:Label ID="HealthMaxLabel" runat="server" Text='<%# Eval("HealthMax") %>'></asp:Label><br />
            LocationX:
            <asp:Label ID="LocationXLabel" runat="server" Text='<%# Eval("LocationX") %>'></asp:Label><br />
            LocationY:
            <asp:Label ID="LocationYLabel" runat="server" Text='<%# Eval("LocationY") %>'></asp:Label><br />
            Experience:
            <asp:Label ID="ExperienceLabel" runat="server" Text='<%# Eval("Experience") %>'>
            </asp:Label><br />
            <br />
        </ItemTemplate>
    </asp:DataList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:WastelandDBConnectionString1 %>"
        SelectCommand="SELECT * FROM [Char]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WastelandDBConnectionString %>"
        SelectCommand="SELECT * FROM [ItemWeapon]"></asp:SqlDataSource>
    Insert New data:<br />
    <table cellpadding="2">
        <tr>
            <td style="width: 100px">
                Name</td>
            <td style="width: 50px">
                Value</td>
            <td style="width: 50px">
                Offense</td>
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
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" /></asp:Content>
