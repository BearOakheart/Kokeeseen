<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Käyttäjät</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="navigation">
                        <ul id="nav">
                            <li><a href="Tunnit.aspx">Työt</a></li>
                            <li><a href="Tuntikirjaus.aspx">Tuntikirjaus</a></li>
                            <li><a href="Users.aspx">Käyttäjät</a></li>
                        </ul>
           <div id="Login">                 
                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Black" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
           </div>

        </div>
        <asp:GridView ID="GridView1" runat="server" >
          <Columns> 
               <asp:TemplateField>
        <ItemTemplate>
                        <asp:LinkButton ID="btnGrid" PostBackUrl='<%# "Tiedot.aspx?name=" + Eval("name")%>' runat="server" Text="More"/>
                    </ItemTemplate>
        </asp:TemplateField>
              </Columns> 
        </asp:GridView>
    </div>
    </form>
</body>
</html>
