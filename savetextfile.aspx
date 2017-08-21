<%@ Page Title="" Language="C#" MasterPageFile="~/users.master" AutoEventWireup="true" CodeFile="savetextfile.aspx.cs" Inherits="savetextfile" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Save Text File" Font-Names="Calibri" Font-Size="X-Large" ForeColor="#006600"></asp:Label></td>
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
                <asp:Button ID="BtnSaveToCloud" runat="server" Text="Save To Cloud" Font-Names="Calibri" Font-Size="Large" Height="40px" OnClick="BtnSaveToCloud_Click"  />
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="LblMsg" runat="server" Font-Names="Calibri" Font-Size="Large"></asp:Label>
                &nbsp;<asp:Label ID="LblFileTitle" runat="server" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Original Contents" Font-Names="Calibri" Font-Size="Large" ForeColor="#000066"></asp:Label></td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Encrypted Contents" Font-Names="Calibri" Font-Size="Large" ForeColor="#000066"></asp:Label></td>
        </tr>
         <tr>
            <td>
                <asp:TextBox ID="TxtOriginal" runat="server" Font-Names="Calibri" Font-Size="Large" ReadOnly="True" Rows="15" TextMode="MultiLine" Width="450px" Wrap="False"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="TxtEncrypted" runat="server" Font-Names="Calibri" Font-Size="Large" ReadOnly="True" Rows="15" TextMode="MultiLine" Width="450px" Wrap="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Decrypted Data" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TxtDecrypt" runat="server" Rows="15" TextMode="MultiLine" Width="450px" Wrap="False" Font-Names="Calibri" Font-Size="Large"></asp:TextBox></td>
        </tr>
    </table>
</asp:Content>


