<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="lab10_Olofintuyi.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" ID="gvPlayers" AutoGenerateColumns="False" DataKeyNames="PlayerID" DataSourceID="dsPlayers" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvPlayers_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="PlayerID" HeaderText="PlayerID" InsertVisible="False" ReadOnly="True" SortExpression="PlayerID" />
                    <asp:BoundField DataField="LName" HeaderText="LName" SortExpression="LName" />
                    <asp:BoundField DataField="FName" HeaderText="FName" SortExpression="FName" />
                    <asp:BoundField DataField="PNumber" HeaderText="PNumber" SortExpression="PNumber" />
                    <asp:BoundField DataField="BDate" HeaderText="BDate" SortExpression="BDate" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:SqlDataSource ID="dsPlayers" runat="server" 
                ConnectionString="<%$ ConnectionStrings:playersConnectionString %>" 
                DeleteCommand="DELETE FROM [Players] WHERE [PlayerID] = ?" 
                InsertCommand="INSERT INTO [Players] ([PlayerID], [LName], [FName], [PNumber], [BDate]) VALUES (?, ?, ?, ?, ?)" 
                ProviderName="<%$ ConnectionStrings:playersConnectionString.ProviderName %>" 
                SelectCommand="SELECT [PlayerID], [LName], [FName], [PNumber], [BDate] FROM [Players]" 
                UpdateCommand="UPDATE [Players] SET [LName] = ?, [FName] = ?, [PNumber] = ?, [BDate] = ? WHERE [PlayerID] = ?">
                <DeleteParameters>
                    <asp:Parameter Name="PlayerID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="PlayerID" Type="Int32" />
                    <asp:Parameter Name="LName" Type="String" />
                    <asp:Parameter Name="FName" Type="String" />
                    <asp:Parameter Name="PNumber" Type="Int32" />
                    <asp:Parameter Name="BDate" Type="DateTime" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="LName" Type="String" />
                    <asp:Parameter Name="FName" Type="String" />
                    <asp:Parameter Name="PNumber" Type="Int32" />
                    <asp:Parameter Name="BDate" Type="DateTime" />
                    <asp:Parameter Name="PlayerID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <asp:TextBox ID="txtMsg" runat="server" Height="246px" TextMode="MultiLine" Width="385px"></asp:TextBox>
    </form>
</body>
</html>
