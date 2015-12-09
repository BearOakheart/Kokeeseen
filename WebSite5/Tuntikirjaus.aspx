<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tuntikirjaus.aspx.cs" Inherits="Tuntikirjaus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
        .auto-style2 {
            height: 255px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style2">
     <div id="navigation">
                        <ul id="nav">
                            <li><a href="Tunnit.aspx">Tunnit</a></li>
                            <li><a href="Tuntikirjaus.aspx">Tuntikirjaus</a></li>
                        </ul>
       <div id="Login">                 
                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Black" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
       </div>
      </div>
        
        <table border="1" width="100%">
            <tr>
                <th>Name:</th>
                <td>
                    <asp:Label id="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Workname:</th>
                <td>
                    <asp:TextBox id="txtWorkname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Date:</th>
                <td>
                    <asp:TextBox id="txtDate" runat="server"></asp:TextBox>
                    
                    <asp:Calendar ID="Calendar1" runat="server"  
                               SelectionMode="Day" 
                               ShowGridLines="True"
                               OnSelectionChanged="Selection_Change">

                             <SelectedDayStyle BackColor="Yellow"
                                               ForeColor="Red">
                             </SelectedDayStyle>

                    </asp:Calendar>     

                </td>
            </tr>
            <tr>
                <th>Hours:</th>
                <td>
                    <asp:TextBox id="txtHours" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtHours" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th class="auto-style1">Minutes:</th>
                <td class="auto-style1">
                    <asp:TextBox id="txtMinutes" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtMinutes" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            

        </table>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Lisää työ" Width="113px" />
    </div>
    </form>
</body>
</html>
