<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Wasteland</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Main.aspx">
                </asp:Login>
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Register.aspx">Register</asp:HyperLink>
            </AnonymousTemplate>
            <LoggedInTemplate>
                Welcome
                <asp:LoginName ID="LoginName1" runat="server" />
                <br />
                <br />
                <asp:LoginStatus ID="LoginStatus1" runat="server" />
                <br />
                <a href="Admin/Default.aspx">Admin/Default.aspx</a>
                <br />
                <a href="Main.aspx">Main.aspx</a>
            </LoggedInTemplate>
        </asp:LoginView>
        <br />
        <br />
        
    </form>
</body>
</html>
