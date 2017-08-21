<%@ Page Language="C#" AutoEventWireup="true" CodeFile="regfrm.aspx.cs" Inherits="regfrm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position: absolute; top: 0px; left: 150px; width: auto; height: 200px">
            <table>
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/regcloud1.jpg" /></td>
                </tr>
            </table>
            <hr style="border: none; background-color: #0094ff; height: 1px;" />
        </div>
        <div style="position: absolute; left: 150px; top: 201px; width: auto; height: auto">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Full Name" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TxtFName" runat="server" Font-Names="Calibri" Font-Size="Large" Width="250px"></asp:TextBox>
                        <asp:Label ID="Label9" runat="server" Text="*" Font-Names="Calibri" Font-Size="Large" ForeColor="#000099" ToolTip="Compulsarily Required"></asp:Label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Full name is required" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True" ControlToValidate="TxtFName">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Contact Number" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TxtContactNo" runat="server" Font-Names="Calibri" Font-Size="Large" Width="250px"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Gender" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DdlGender" runat="server" Font-Names="Calibri" Font-Size="Large" Width="250px">
                            <asp:ListItem Value="-1">SELECT GENDER</asp:ListItem>
                            <asp:ListItem>MALE</asp:ListItem>
                            <asp:ListItem>FEMALE</asp:ListItem>
                        </asp:DropDownList></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Email-Id" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TxtEmailId" runat="server" Font-Names="Calibri" Font-Size="Large" Width="250px"></asp:TextBox>
                        <asp:Label ID="Label10" runat="server" Text="*" Font-Names="Calibri" Font-Size="Large" ForeColor="#000099" ToolTip="Compulsarily Required"></asp:Label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email-id is required" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True" ControlToValidate="TxtEmailId">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid emailid" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True" ControlToValidate="TxtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Password" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TxtPassword" runat="server" Font-Names="Calibri" Font-Size="Large" TextMode="Password" Width="250px"></asp:TextBox>
                        <asp:Label ID="Label11" runat="server" Text="*" Font-Names="Calibri" Font-Size="Large" ForeColor="#000099" ToolTip="Compulsarily Required"></asp:Label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Password is required" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True" ControlToValidate="TxtPassword">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Confirm Password" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TxtCPwd" runat="server" Font-Names="Calibri" Font-Size="Large" TextMode="Password" Width="250px"></asp:TextBox>
                        <asp:Label ID="Label12" runat="server" Text="*" Font-Names="Calibri" Font-Size="Large" ForeColor="#000099" ToolTip="Compulsarily Required"></asp:Label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Confirm password is required" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True" ControlToValidate="TxtCPwd">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password and confirm password must be same" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True" ControlToCompare="TxtPassword" ControlToValidate="TxtCPwd">*</asp:CompareValidator>
                    </td>
                </tr>                
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Security Question" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DdlSecQue" runat="server" Font-Names="Calibri" Font-Size="Large" Width="250px">
                            <asp:ListItem Value="-1">SECURITY QUESTION?</asp:ListItem>
                            <asp:ListItem>WHAT IS YOUR MOTHERS MAIDEN NAME?
                            </asp:ListItem>
                            <asp:ListItem>WHAT IS YOUR FAVOURITE COLOR?</asp:ListItem>
                            <asp:ListItem>WHAT IS YOUR FIRST SCHOOL NAME?</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Answer" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TxtAnswer" runat="server" Font-Names="Calibri" Font-Size="Large" TextMode="Password" Width="250px"></asp:TextBox></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align:right">
                        <asp:Button ID="BtnRegister" runat="server" Text="Register" Font-Names="Calibri" Font-Size="Large" BackColor="#CC0066" BorderColor="#990033" BorderStyle="Solid" ForeColor="White" Height="40px" OnClick="BtnRegister_Click" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="LblMsg" runat="server" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" ShowMessageBox="True" ShowSummary="False" />
                    </td>
                </tr>
            </table>
            <hr style="border: none; background-color: #0094ff; height: 1px;" />
            <table>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" Height="100px" ImageHeight="100px" ImageUrl="~/Images/home.png" NavigateUrl="~/start.aspx">HyperLink</asp:HyperLink></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
