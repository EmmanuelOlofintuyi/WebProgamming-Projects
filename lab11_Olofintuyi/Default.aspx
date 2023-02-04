<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="lab11_Olofintuyi.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
    function ConfirmDelete() {
        return window.confirm("Are you sure you want to delete this entry?");
    }
</script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Lab 11</h2>
				<p>Last Name
					<asp:TextBox ID="txtLName" runat="server" Width="50px"></asp:TextBox>
					&nbsp;First Name
					<asp:TextBox ID="txtFName" runat="server" Width="50px"></asp:TextBox>
					&nbsp;Jersey Num
					<asp:TextBox ID="txtPNumber" runat="server" Width="20px"></asp:TextBox>
					&nbsp;Birth Date
					<asp:TextBox ID="txtBDate" runat="server" Width="50px"></asp:TextBox>
					&nbsp;Team
					<asp:DropDownList ID="ddTeams" runat="server" DataSourceID="dsTeams" DataTextField="Name" DataValueField="TeamID">
					</asp:DropDownList>
					<asp:SqlDataSource ID="dsTeams" runat="server" ConnectionString="<%$ ConnectionStrings:playersConnectionString %>" ProviderName="<%$ ConnectionStrings:playersConnectionString.ProviderName %>" SelectCommand="SELECT [Name], [TeamID] FROM [Teams]"></asp:SqlDataSource>
					&nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
				</p>
                <asp:ValidationSummary runat="server" Font-Bold="True" ForeColor="Red"></asp:ValidationSummary>
				<asp:GridView ID="gvPlayers" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PlayerID" DataSourceID="dsPlayers" OnSelectedIndexChanged="gvPlayers_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" OnClientClick="return ConfirmDelete()">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PlayerID" HeaderText="PlayerID" InsertVisible="False" ReadOnly="True" SortExpression="PlayerID" />
                        <asp:BoundField DataField="TeamID" HeaderText="TeamID" SortExpression="TeamID" />
                        <asp:BoundField DataField="LName" HeaderText="LName" SortExpression="LName" />
                        <asp:BoundField DataField="FName" HeaderText="FName" SortExpression="FName" />
                        <asp:TemplateField HeaderText="PNumber" SortExpression="PNumber">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtGvPNum" runat="server" Text='<%# Bind("PNumber") %>'></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtGvPNum" ErrorMessage="Jersey Number must be between 1 and 99" Font-Bold="True" ForeColor="Red" MaximumValue="99" MinimumValue="1" SetFocusOnError="True" Type="Integer" Width="20px">*</asp:RangeValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblGvPNum" runat="server" Text='<%# Bind("PNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BDate" HeaderText="BDate" SortExpression="BDate" />
                    </Columns>
                    
				</asp:GridView>

            <asp:SqlDataSource ID="dsPlayers" runat="server" 
                ConnectionString="<%$ ConnectionStrings:playersConnectionString %>" 
                DeleteCommand="DELETE FROM [Players] WHERE [PlayerID] = ?" 
                InsertCommand="INSERT INTO [Players] ([TeamID], [LName], [FName], [PNumber], [BDate]) VALUES (?, ?, ?, ?, ?)" 
                ProviderName="<%$ ConnectionStrings:playersConnectionString.ProviderName %>" 
                SelectCommand="SELECT * FROM [Players]" 
                UpdateCommand="UPDATE [Players] SET [TeamID] = ?, [LName] = ?, [FName] = ?, [PNumber] = ?, [BDate] = ? WHERE [PlayerID] = ?">
                <DeleteParameters>
                    <asp:Parameter Name="PlayerID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
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
        <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine"></asp:TextBox>
    </form>
</body>
</html>
