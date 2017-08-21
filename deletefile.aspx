<%@ Page Title="" Language="C#" MasterPageFile="~/users.master" AutoEventWireup="true" CodeFile="deletefile.aspx.cs" Inherits="deletefile" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Delete file" Font-Names="Calibri" Font-Size="X-Large" ForeColor="#006666"></asp:Label></td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="File Name" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
            <td>
                <asp:TextBox ID="TxtFileName" runat="server" Font-Names="Calibri" Font-Size="Large" ReadOnly="True" Width="300px"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Private Kay" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
            <td>
                <asp:TextBox ID="TxtKey" runat="server" Font-Names="Calibri" Font-Size="Large" TextMode="Password" Width="300px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Private key is required" ControlToValidate="TxtKey" Display="Dynamic" Font-Names="Calibri" Font-Size="Large" ForeColor="#990033" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td style="text-align: right">
                <asp:ImageButton ID="IBtnDelete" runat="server" Height="50px" ImageUrl="~/Images/deletefile.png" OnClick="IBtnDelete_Click" /></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="LblMsg" runat="server" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
        </tr>
    </table>
</asp:Content>


