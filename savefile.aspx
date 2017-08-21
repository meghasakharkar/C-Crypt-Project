<%@ Page Title="" Language="C#" MasterPageFile="~/users.master" AutoEventWireup="true" CodeFile="savefile.aspx.cs" Inherits="savefile" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Save File" Font-Names="Calibri" Font-Size="X-Large" ForeColor="#006600"></asp:Label></td>
        </tr>
    </table>
    <hr style="border: none; height: 1px; background-color: #ff006e" />
    <table>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="File Description" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
            <td>
                <asp:TextBox ID="TxtFileDescription" runat="server" Font-Names="Calibri" Font-Size="Large" Rows="4" TextMode="MultiLine" Width="400px" Wrap="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="File description is required" ControlToValidate="TxtFileDescription" Display="Dynamic" Font-Names="Calibri" Font-Size="Medium" ForeColor="#990033" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Select a file" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
            <td>
                <asp:FileUpload ID="Fupload" runat="server" Font-Names="Calibri" Font-Size="Large" Width="500px" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                <asp:Button ID="BtnSaveToCloud" runat="server" Text="Save To Cloud" BackColor="#006666" BorderColor="#006666" BorderStyle="Solid" Font-Names="Calibri" Font-Size="Large" ForeColor="White" Height="40px" OnClick="BtnSaveToCloud_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="LblMsg" runat="server" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
        </tr>
    </table>
</asp:Content>


