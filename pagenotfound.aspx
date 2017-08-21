<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pagenotfound.aspx.cs" Inherits="pagenotfound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="position:absolute;top:200px;left:200px;width:auto;height:auto">
    <table style="width:100%;text-align:center">
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/pagenotfound2.png" /></td>
        </tr>
         <tr>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Calibri" Font-Size="Large" ImageUrl="~/Images/home.png" ImageWidth="80px" NavigateUrl="~/start.aspx">Home</asp:HyperLink></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
