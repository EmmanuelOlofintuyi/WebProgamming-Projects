<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="lab10_Olofintuyi.Page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvPlayers" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataSourceID="dsPlayers" GridLines="Horizontal" DataKeyNames="PlayerID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="PlayerID" HeaderText="PlayerID" InsertVisible="False" SortExpression="PlayerID" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Team" SortExpression="TeamID">
                        <EditItemTemplate>
                            <asp:DropDownList ID="gvDdlTeams" runat="server" DataSourceID="dsTeams" DataTextField="Name" DataValueField="TeamID" SelectedValue='<%# Bind("TeamID") %>'>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="dsTeams" runat="server" ConnectionString="<%$ ConnectionStrings:playersConnectionString %>" ProviderName="<%$ ConnectionStrings:playersConnectionString.ProviderName %>" SelectCommand="SELECT [TeamID], [Name] FROM [Teams]"></asp:SqlDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="gvLblTeamName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            <asp:HiddenField ID="TeamIDHidden" runat="server" Visible="false" 
                                  Value='<%# Eval("TeamID") %>' />

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="LName" HeaderText="LName" SortExpression="LName" />
                    <asp:BoundField DataField="FName" HeaderText="FName" SortExpression="FName" />
                    <asp:BoundField DataField="PNumber" HeaderText="PNumber" SortExpression="PNumber" />
                    <asp:BoundField DataField="BDate" HeaderText="BDate" SortExpression="BDate" DataFormatString="{0:MM/dd/yyyy}" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" Visible="False" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
            <asp:SqlDataSource ID="dsPlayers" runat="server" ConnectionString="<%$ ConnectionStrings:playersConnectionString %>" DeleteCommand="DELETE FROM [Players] WHERE [PlayerID] = ?" InsertCommand="INSERT INTO [Players] ([PlayerID], [TeamID], [LName], [FName], [PNumber], [BDate]) VALUES (?, ?, ?, ?, ?, ?)" ProviderName="<%$ ConnectionStrings:playersConnectionString.ProviderName %>" SelectCommand="SELECT Players.PlayerID, Players.TeamID, Players.LName, Players.FName, Players.PNumber, Players.BDate, Teams.Name FROM (Players INNER JOIN Teams ON Players.TeamID = Teams.TeamID)" UpdateCommand="UPDATE [Players] SET [TeamID] = ?, [LName] = ?, [FName] = ?, [PNumber] = ?, [BDate] = ? WHERE [PlayerID] = ?">
                <DeleteParameters>
                    <asp:Parameter Name="PlayerID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="PlayerID" Type="Int32" />
                    <asp:Parameter Name="TeamID" Type="Int32" />
                    <asp:Parameter Name="LName" Type="String" />
                    <asp:Parameter Name="FName" Type="String" />
                    <asp:Parameter Name="PNumber" Type="Int32" />
                    <asp:Parameter Name="BDate" Type="DateTime" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="TeamID" Type="Int32" />
                    <asp:Parameter Name="LName" Type="String" />
                    <asp:Parameter Name="FName" Type="String" />
                    <asp:Parameter Name="PNumber" Type="Int32" />
                    <asp:Parameter Name="BDate" Type="DateTime" />
                    <asp:Parameter Name="PlayerID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <asp:TextBox ID="txtMsg" runat="server" Height="275px" TextMode="MultiLine" Width="328px"></asp:TextBox>
    </form>
</body>
</html>
