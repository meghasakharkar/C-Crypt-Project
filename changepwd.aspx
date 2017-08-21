<%@ Page Title="" Language="C#" MasterPageFile="~/users.master" AutoEventWireup="true" CodeFile="changepwd.aspx.cs" Inherits="changepwd" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Change Password" Font-Names="Calibri" Font-Size="X-Large" ForeColor="#006600"></asp:Label></td>
        </tr>
    </table>
    <hr style="border: none; height: 1px; background-color: #ff006e" />
    <table>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Current Password" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
            <td>
                <asp:TextBox ID="TxtCurrentPassword" runat="server" Font-Names="Calibri" Font-Size="Large" TextMode="Password" Width="250px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Current password is required" ControlToValidate="TxtCurrentPassword" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="New Password" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
            <td>
                <asp:TextBox ID="TxtNewPassword" runat="server" Font-Names="Calibri" Font-Size="Large" TextMode="Password" Width="250px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="New password is required" ControlToValidate="TxtNewPassword" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Confirm New Password" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
            <td>
                <asp:TextBox ID="TxtConfirmNewPwd" runat="server" Font-Names="Calibri" Font-Size="Large" TextMode="Password" Width="250px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Confirm new password is required" ControlToValidate="TxtConfirmNewPwd" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="New password and confirm new password must be same" ControlToCompare="TxtNewPassword" ControlToValidate="TxtConfirmNewPwd" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align: right">
                <asp:Button ID="BtnChangePwd" runat="server" Text="Change Password" Font-Names="Calibri" Font-Size="Large" OnClick="BtnChangePwd_Click" /></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="LblMsg" runat="server" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
        </tr>
    </table>
</asp:Content>


