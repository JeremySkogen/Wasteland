<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CharGen.aspx.cs" Inherits="CharGen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    You are logged in as:<asp:LoginName ID="LoginName2" runat="server" />
        <br />
    
    <br />
    Your characters name
    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox><br />
    <br />
    
    <asp:RadioButtonList ID="RadioButtonListSex" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="M">Male</asp:ListItem>
        <asp:ListItem Value="F">Female</asp:ListItem>
        <asp:ListItem Value="N">Mutant</asp:ListItem>
    </asp:RadioButtonList><br />
    <asp:DropDownList ID="DropDownListClass" runat="server">
        <asp:ListItem>Scientist</asp:ListItem>
        <asp:ListItem>Soldier</asp:ListItem>
        <asp:ListItem>Handyman</asp:ListItem>
    </asp:DropDownList>
        <br />
        <br />
    <asp:Button ID="ButtonCharSubmit" runat="server" Text="Submit" CommandName="PostUserData" OnClick="ButtonCharSubmit_Click" />
        <asp:Button ID="Button1" runat="server" PostBackUrl="~/Main.aspx" Text="Continue" /></div>
    </form>
</body>
</html>
