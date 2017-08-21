<%@ Page Title="" Language="C#" MasterPageFile="~/admins.master" AutoEventWireup="true" CodeFile="regusers.aspx.cs" Inherits="regusers" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Registered Users" Font-Names="Calibri" Font-Size="X-Large" ForeColor="#006600"></asp:Label></td>
        </tr>
    </table>
    <hr style="border:none;height:1px;background-color:#ff006e" />
    <table>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" Font-Names="Calibri" Font-Size="Large" ForeColor="#333333" GridLines="None" Width="900px">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>            
        </tr>
    </table>
</asp:Content>


