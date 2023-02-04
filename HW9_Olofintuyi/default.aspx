<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="HW9_Olofintuyi._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            <h2>HW 9 - Emmanuel Olofintuyi</h2>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/timelog.html">Time Log</asp:HyperLink> &nbsp; <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/classes.html"> Class Diagram</asp:HyperLink>
            <asp:Panel ID="createEventPanel" runat="server" GroupingText="Create Event">
               <h5>Event Name:<asp:TextBox ID="supplyEventName" runat="server" Height="8px"></asp:TextBox></h5>
               <h5>Available Seat Numbers: First<asp:TextBox ID="supplyFirstSeatNumber" runat="server" Height="11px" Width="23px"></asp:TextBox>&nbsp; Last<asp:TextBox ID="supplyLastSeatNumber" runat="server" Height="11px" Width="23px"></asp:TextBox></h5>
                <asp:Button ID="btnMakeEvent" runat="server" Text="Make Event" OnClick="btnMakeEvent_Click" />&ensp;<asp:Button ID="btnStartOver" runat="server" Text="Start over" OnClick="btnStartOver_Click" />
            </asp:Panel>
                </div>
            <br />
            <div>
            <asp:Panel ID="purchaseTicketPanel" runat="server" GroupingText="Purchase Ticket">
                 <h5>Name<asp:TextBox ID="txtNameTicketHolder" runat="server" Height="8px"></asp:TextBox>&nbsp; Age<asp:TextBox ID="txtAgeTicketHolder" runat="server" Height="11px" Width="23px"></asp:TextBox></h5>
                <h5>Pick Seat, <asp:Label ID="lblSeatNumber" runat="server" Text=""></asp:Label>&nbsp; available</h5>
                <table>
                    <tr>
                        <td>
                <asp:ListBox ID="ListBox1" runat="server" Height="196px"></asp:ListBox>
                            </td>
                
                    
                        <td>
                 <div><asp:Button ID="btnPurchase" runat="server" Text="Purchase" OnClick="btnPurchase_Click" /></div>
                            
                 <div><asp:Button ID="btnEventSummary" runat="server" Text="Event Summary" OnClick="btnEventSummary_Click" /></div>
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
                </div>
        </div>
        
    </form>
</body>
</html>
