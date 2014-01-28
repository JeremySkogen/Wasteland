<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WasteLand</title>
</head>
<body bgcolor="#000000">
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                <tr>
                    <td colspan="2" style="color: #ff9933; font-family: 'Times New Roman'; height: 5px;
                        width: 20%; background-color: transparent; text-align: left">
                        <asp:Image ID="Image2" runat="server" Height="186px" Width="218px" ImageUrl="~/Images/Radiation.jpg" /></td>
                    <td style="width: 30%; color: silver;">
                        <strong style="font-size: 20pt">User:
                            <asp:Label ID="LabelUserName" runat="server" Text="Label"></asp:Label><br />
                            Health: </strong>
                        <asp:TextBox ID="TextBoxHealth" runat="server" BackColor="Black" BorderColor="#FFFF80"
                            ForeColor="Red" Width="100px" Visible="False"></asp:TextBox>
                        <asp:Label ID="LabelHealthStr" runat="server" Text="Label"></asp:Label>
                        <br />
                        <strong style="font-size: 20pt">Str:&nbsp;</strong>
                        <asp:Label ID="LabelStr" runat="server" Text="Label"></asp:Label><br />
                        <strong style="font-size: 20pt">Int: </strong>
                        <asp:Label ID="LabelInt" runat="server" Text="Label"></asp:Label>
                        <br />
                        <strong style="font-size: 20pt">Location: </strong>
                        <asp:Label ID="LabelLoc" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td colspan="2" style="color: #ff9933; font-family: 'Times New Roman'; height: 5px;
                        width: 100%; background-color: transparent; text-align: right">
                        <strong><span style="font-size: 24pt"></span></strong><span style="font-size: 72pt;
                            color: darkgray; font-family: Terminal">WASTELAND</span>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5" style="width: 100%; height: 5px; background-image: url(Images/RadBorder.gif);
                        background-repeat: repeat-x; background-color: transparent" rowspan="1">
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                <tr>
                    <td style="vertical-align: top; width: 250px; text-align: left">
                    </td>
                    <td style="width: 50px">
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td style="vertical-align: top; width: 49%; line-height: 5px; letter-spacing: 3px;
                        text-align: justify">
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td style="width: 100%">
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 250px; text-align: left">
                    </td>
                    <td style="width: 50px">
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td style="vertical-align: top; width: 49%; text-align: center">
                        <asp:Button ID="ButtonUp" runat="server" Text="Up" Width="200px" OnClick="ButtonUp_Click"
                            Height="50px" /></td>
                    <td style="width: 10px">
                    </td>
                    <td style="width: 100%">
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 250px; text-align: left">
                        <asp:ListBox ID="ListBoxInv" runat="server" BackColor="Black" ForeColor="Silver"
                            Width="200px" Height="200px" AutoPostBack="True"></asp:ListBox>
                        <asp:Label ID="LabelItemInfo" runat="server" BackColor="Black" BorderColor="Yellow"
                            ForeColor="Silver" Height="150px" Width="200px" />
                        <asp:Button ID="ButtonItemEquip" runat="server" Text="Equip" Visible="False" Width="50px" />
                        <asp:Button ID="ButtonItemSell" runat="server" Text="Sell" Visible="False" Width="50px" />
                        <asp:Button ID="ButtonItemDrop" runat="server" Text="Drop" Visible="False" Width="50px" /></td>
                    <td style="width: 50px">
                    </td>
                    <td style="width: 10px">
                        <asp:Button ID="ButtonLeft" runat="server" Text="Left" Width="50px" OnClick="ButtonLeft_Click"
                            Height="200px" /></td>
                    <td style="vertical-align: top; width: 49%;
                        text-align: left">
                        <asp:Label ID="LabelMap" runat="server" Height="50%" Text="Label" Width="100%" Font-Names="Courier New"
                            Font-Size="Small" ForeColor="Silver" Style="font-size: 14px; letter-spacing: 3px;
                            text-align: left; line-height: 5px; vertical-align: top;"></asp:Label></td>
                    <td style="width: 10px">
                        <asp:Button ID="ButtonRight" runat="server" Text="Right" Width="50px" OnClick="ButtonRight_Click"
                            Height="200px" /></td>
                    <td style="width: 100%">
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 250px; text-align: left">
                    </td>
                    <td style="width: 50px">
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td style="vertical-align: top; width: 49%; text-align: center">
                        <asp:Button ID="ButtonDown" runat="server" Text="Down" Width="200px" OnClick="ButtonDown_Click"
                            Height="50px" /></td>
                    <td style="width: 10px">
                    </td>
                    <td style="width: 100%">
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; vertical-align: bottom; text-align: left; color: khaki;">
                        <br />
                        <a href="Default.aspx">Default</a></td>
                    <td style="width: 50px">
                        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="50px">
                        </asp:Panel>
                    </td>
                    <td style="width: 10px">
                        &nbsp;</td>
                    <td style="width: 49%; text-align: left; vertical-align: top;">
                        &nbsp;&nbsp;
                        <asp:Button ID="ButtonFight" runat="server" Text="Fight" Visible="False" OnClick="ButtonFight_Click" />
                        <asp:Button ID="ButtonRun" runat="server" OnClick="ButtonRun_Click" Text="Run" Visible="False" />
                        <asp:Button ID="ButtonContinue" runat="server" OnClick="ButtonContinue_Click" Text="Continue"
                            Visible="False" /></td>
                    <td style="width: 10px">
                        &nbsp;</td>
                    <td style="width: 100%">
                        &nbsp;<br />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
