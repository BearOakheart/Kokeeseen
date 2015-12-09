<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="../JavaScript/jquery-1.3.2.min.js"></script>
    <title>XML tietokannan käyttö</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>XML</h1>
        
        <div>
            <table id="LoginTable">
        <tr>
            <td>Username</td>
            <td>
                <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Group3" runat="server" ErrorMessage="Please type username!" ControlToValidate="txtLogin"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox  ID="txtPassword" TextMode="password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Group3" ErrorMessage="Password required" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="Group3" OnClick="btnLogin_Click"/><br/>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
        </div>

    </div>
    </form>
</body>
</html>
