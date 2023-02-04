<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="lab09_Olofintuyi.Page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="btnReadData" runat="server" Text="Read Data" OnClick="btnReadData_Click" />
        </div>
        <p>
            <asp:TextBox ID="txtMsg" runat="server" Height="228px" TextMode="MultiLine" Width="262px"></asp:TextBox>
        </p>
    </form>
</body>
</html>
