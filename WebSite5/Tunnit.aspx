<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tunnit.aspx.cs" Inherits="Tunnit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tunnit</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div id="navigation">
                        <ul id="nav">
                            <li><a href="Tunnit.aspx">Tunnit</a></li>
                            <li><a href="Tuntikirjaus.aspx">Tuntikirjaus</a></li>
                        </ul>
           <div id="Login">                 
                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Black" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
           </div>

        </div>


        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
