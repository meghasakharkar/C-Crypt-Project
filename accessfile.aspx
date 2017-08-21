<%@ Page Title="" Language="C#" MasterPageFile="~/users.master" AutoEventWireup="true" CodeFile="accessfile.aspx.cs" Inherits="accessfile" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Access File" Font-Names="Calibri" Font-Size="X-Large" ForeColor="#006600"></asp:Label></td>
        </tr>
    </table>
    <hr style="border:none;height:1px;background-color:#ff006e" />
     <table>
        <tr>
            <td>
                <asp:Label ID="LblMsg" runat="server" Font-Names="Calibri" Font-Size="Large"></asp:Label></td>           
        </tr>
        <tr>
            <td>
                <asp:Table ID="Table1" runat="server" Font-Names="Calibri" Font-Size="Large" GridLines="Horizontal" Width="1000px"></asp:Table>
            </td>
        </tr>
    </table>
</asp:Content>


