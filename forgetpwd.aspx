<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgetpwd.aspx.cs" Inherits="forgetpwd" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="position:absolute;left:0px;top:10px;width:100%;height:auto">
        <center>
    <table>
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/forgot-password-ribbon.png" /></td>
        </tr>
    </table>
            </center>
    </div>
        <div style="position:absolute;left:0px;top:200px;width:100%;height:auto">
             <hr style="border: none; background-color: #ff006e; height: 1px;" />
            <center>
            <table>
                <tr>
                    <td style="text-align:left">
                        <asp:Label ID="Label1" runat="server" Text="Userid (Emailid)" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td style="text-align:left">
                        <asp:TextBox ID="TxtUserId" runat="server" Font-Names="Calibri" Font-Size="Large" Width="250px"></asp:TextBox></td>
                    <td style="text-align:left"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Userid (i.e. emailid) is required" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" ControlToValidate="TxtUserId" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid emailid" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" ControlToValidate="TxtUserId" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left">
                        <asp:Label ID="Label2" runat="server" Text="Security Question" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td style="text-align:left">
                        <asp:DropDownList ID="DdlSecurityQuestion" runat="server" Font-Names="Calibri" Font-Size="Large" Width="250px">
                            <asp:ListItem Value="-1">SECURITY QUESTION?</asp:ListItem>
                            <asp:ListItem>WHAT IS YOUR MOTHERS MAIDEN NAME?
                            </asp:ListItem>
                            <asp:ListItem>WHAT IS YOUR FAVOURITE COLOR?</asp:ListItem>
                            <asp:ListItem>WHAT IS YOUR FIRST SCHOOL NAME?</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="text-align:left"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Security question is required" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" ControlToValidate="DdlSecurityQuestion" InitialValue="-1" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="text-align:left">
                        <asp:Label ID="Label3" runat="server" Text="Answer" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td style="text-align:left">
                        <asp:TextBox ID="TxtAnswer" runat="server" Font-Names="Calibri" Font-Size="Large" TextMode="Password" Width="250px"></asp:TextBox></td>
                    <td style="text-align:left"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Answer is required" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" ControlToValidate="TxtAnswer" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align:right">
                        <asp:Button ID="BtnSendRequest" runat="server" Text="Send Request" Font-Names="Calibri" Font-Size="Large" BackColor="#CC0066" BorderColor="#990033" BorderStyle="Solid" ForeColor="White" Height="40px" OnClick="BtnSendRequest_Click" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align:left">
                        <asp:Label ID="LblMsg" runat="server" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>                    
                </tr>
            </table>
                </center>
            <hr style="border: none; background-color: #ff006e; height: 1px;" />
            <center>
            <table>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Images/home.png" ImageWidth="80px" NavigateUrl="~/start.aspx">Home</asp:HyperLink></td>
                </tr>
            </table>
                </center>
        </div>
    </form>
</body>
</html>
