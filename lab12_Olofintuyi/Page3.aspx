<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page3.aspx.cs" Inherits="lab12_Olofintuyi.Page3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TeamID" DataSourceID="dsTeams" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDeleted="GridView1_RowDeleted">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="TeamID" HeaderText="TeamID" InsertVisible="False" ReadOnly="True" SortExpression="TeamID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="CoachLName" HeaderText="CoachLName" SortExpression="CoachLName" />
                    <asp:BoundField DataField="CoachFName" HeaderText="CoachFName" SortExpression="CoachFName" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <asp:SqlDataSource ID="dsTeams" runat="server" ConnectionString="<%$ ConnectionStrings:playersConnectionString %>" DeleteCommand="DELETE FROM [Teams] WHERE [TeamID] = ?" InsertCommand="INSERT INTO [Teams] ([TeamID], [Name], [CoachLName], [CoachFName]) VALUES (?, ?, ?, ?)" ProviderName="<%$ ConnectionStrings:playersConnectionString.ProviderName %>" SelectCommand="SELECT [TeamID], [Name], [CoachLName], [CoachFName] FROM [Teams]" UpdateCommand="UPDATE [Teams] SET [Name] = ?, [CoachLName] = ?, [CoachFName] = ? WHERE [TeamID] = ?">
                <DeleteParameters>
                    <asp:Parameter Name="TeamID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="TeamID" Type="Int32" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="CoachLName" Type="String" />
                    <asp:Parameter Name="CoachFName" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="CoachLName" Type="String" />
                    <asp:Parameter Name="CoachFName" Type="String" />
                    <asp:Parameter Name="TeamID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:Label ID="lblDeleteStatus" runat="server" Text="Label" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
