<%@ Page Language="C#" AutoEventWireup="true" CodeFile="start.aspx.cs" Inherits="start" Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    
</head>
<body>
    <form id="form1" runat="server">
        <div style="position: absolute; left: 50px; top: 100px; width: 600px; height: auto">
            <table>
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/cc.png" Width="500px" /></td>
                </tr>
            </table>
        </div>
        <div style="position: absolute; left: 701px; top: 100px; width: auto; height: auto">
                 <table>
                     <tr>
                         <td colspan="2">
                             <asp:Label ID="Label3" runat="server" Text="Login Here" Font-Names="Calibri" Font-Size="Large" ForeColor="#003366"></asp:Label></td>
                     </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Userid" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="TxtUserid" runat="server" Font-Names="Calibri" Font-Size="Large"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Userid (i.e. emailid) is required" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True" ControlToValidate="TxtUserid"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid userid (i.e. emailid)" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True" ControlToValidate="TxtUserid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Password" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="TxtPassword" runat="server" Font-Names="Calibri" Font-Size="Large" TextMode="Password"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True" ControlToValidate="TxtPassword">Password is required</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:ImageButton ID="BtnLogin" runat="server" ImageUrl="~/Images/loginbutton.png" Width="200px" OnClick="BtnLogin_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="LblMsg" runat="server" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    </tr>
                </table>
            <asp:Panel ID="Panel2" runat="server" Width="300px">
                <hr style="border: none; background-color: #0094ff; height: 1px;" />
                <table>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Calibri" Font-Size="Medium" NavigateUrl="~/regfrm.aspx" ImageHeight="80px" ImageUrl="~/Images/reg.gif" ToolTip="New Registration">New Registration</asp:HyperLink></td>
                        <td>
                            <asp:HyperLink ID="HyperLink2" runat="server" Font-Names="Calibri" Font-Size="Medium" ImageHeight="80px" ImageUrl="~/Images/forgot_password_icon.jpg" NavigateUrl="~/forgetpwd.aspx" ToolTip="Forget Password">Forget Password</asp:HyperLink></td>
                    </tr>
                </table>
                <hr style="border: none; background-color: #0094ff; height: 1px;" />
            </asp:Panel>
            <br /><br /><br />
            <table>
                <tr>
                    <td>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/encryption.png" Width="600px" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
