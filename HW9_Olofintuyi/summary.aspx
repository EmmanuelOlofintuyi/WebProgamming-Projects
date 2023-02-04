<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="summary.aspx.cs" Inherits="HW9_Olofintuyi.summary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 340px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Ticket Holders for <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h2>
            <table>
                <tr>
                    <td>
            <asp:Button ID="btPurchaseMoreTickets" runat="server" Text="Purchase More Tickets" OnClick="btPurchaseMoreTickets_Click"  />
                        </td>
                    <td colspan ="2">
                        <h4>Sort:&nbsp; <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                             <asp:ListItem>Order Purchased</asp:ListItem>
                             <asp:ListItem>Name</asp:ListItem>
                             <asp:ListItem>Seat</asp:ListItem>
                         </asp:RadioButtonList></h4>
                    
                    
                         
                    </td>
            </tr>
                <tr>
                    <td>
                        <h4>Remove Ticket Holder</h4>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>Choose Person to Remove</asp:ListItem>
                        </asp:DropDownList>
                        
                    </td>
                    <td class="auto-style1">
                        &ensp;<asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                    </td>
                </tr>
            </table>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="182px" Width="312px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
