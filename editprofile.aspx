<%@ Page Title="" Language="C#" MasterPageFile="~/users.master" AutoEventWireup="true" CodeFile="editprofile.aspx.cs" Inherits="editprofile" Debug="true" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Edit Profile" Font-Names="Calibri" Font-Size="X-Large" ForeColor="#006600"></asp:Label></td>
        </tr>
    </table>
    <hr style="border:none;height:1px;background-color:#ff006e" />
    <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Full Name" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TxtFName" runat="server" Font-Names="Calibri" Font-Size="Large" Width="350px"></asp:TextBox>
                        <asp:Label ID="Label9" runat="server" Text="*" Font-Names="Calibri" Font-Size="Large" ForeColor="#000099" ToolTip="Compulsarily Required"></asp:Label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Full name is required" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True" ControlToValidate="TxtFName"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Contact Number" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TxtContactNo" runat="server" Font-Names="Calibri" Font-Size="Large" Width="350px"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Gender" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DdlGender" runat="server" Font-Names="Calibri" Font-Size="Large" Width="350px">
                            <asp:ListItem Value="-1">SELECT GENDER</asp:ListItem>
                            <asp:ListItem>MALE</asp:ListItem>
                            <asp:ListItem>FEMALE</asp:ListItem>
                        </asp:DropDownList></td>
                    <td></td>
                </tr>                                               
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Security Question" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DdlSecQue" runat="server" Font-Names="Calibri" Font-Size="Large" Width="350px">
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
                        <asp:Label ID="Label13" runat="server" Text="Answer" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TxtAnswer" runat="server" Font-Names="Calibri" Font-Size="Large" Width="350px"></asp:TextBox></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align:right">
                        <asp:Button ID="BtnSaveChanges" runat="server" Text="Save Changes" Font-Names="Calibri" Font-Size="Large" ForeColor="Black" Height="40px" OnClick="BtnSaveChanges_Click"/></td>
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
</asp:Content>


