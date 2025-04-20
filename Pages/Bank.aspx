<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bank.aspx.cs" Inherits="OnlineBankingApp.Pages.Bank" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div>
                <h1 style="width: 302px"> Transfer Funds </h1>
                <br/>
                Transfer Funds From:
                <asp:DropDownList ID="sndFrom" runat="server">
                    <asp:ListItem>Savings</asp:ListItem>
                    <asp:ListItem>Checkings</asp:ListItem>
                </asp:DropDownList>
                <br />
                Transfer Funds To:&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="sndTo" runat="server">
                    <asp:ListItem>Savings</asp:ListItem>
                    <asp:ListItem>Checkings</asp:ListItem>
                </asp:DropDownList>
                <br />
                Amount to transfer:&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="FndTxt" runat="server"></asp:TextBox>
                <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="FndBtn" runat="server" Text="Transfer Funds" OnClick="FndBtn_Click" />
                <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="StatusMessage" runat="server" Font-Size="10pt" ForeColor="Red" Text="-"></asp:Label>
                <br />
                <asp:Timer ID="Timer1" runat="server" EnableViewState="False" Interval="120000" OnTick="Timer1_Tick1">
                </asp:Timer>
        </div>
     </form>
</body>
</html>
