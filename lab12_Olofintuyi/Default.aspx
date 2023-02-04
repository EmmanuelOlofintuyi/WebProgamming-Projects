<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="lab12_Olofintuyi.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="dlTeams" runat="server" AutoPostBack="True" DataSourceID="dsTeams" DataTextField="Name" DataValueField="TeamID" style="margin-bottom: 0px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="dsTeams" runat="server" ConnectionString="<%$ ConnectionStrings:playersConnectionString %>" ProviderName="<%$ ConnectionStrings:playersConnectionString.ProviderName %>" SelectCommand="SELECT [Name], [TeamID] FROM [Teams]"></asp:SqlDataSource>
                    <asp:GridView ID="gvPlayers" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataSourceID="dsPlayers" GridLines="Horizontal">
                        <Columns>
                            <asp:BoundField DataField="LName" HeaderText="LName" SortExpression="LName" />
                            <asp:BoundField DataField="FName" HeaderText="FName" SortExpression="FName" />
                            <asp:BoundField DataField="PNumber" HeaderText="PNumber" SortExpression="PNumber" />
                            <asp:BoundField DataField="BDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="BDate" SortExpression="BDate" />
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
                    <asp:SqlDataSource ID="dsPlayers" runat="server" ConnectionString="<%$ ConnectionStrings:playersConnectionString %>" ProviderName="<%$ ConnectionStrings:playersConnectionString.ProviderName %>" SelectCommand="SELECT [LName], [FName], [PNumber], [BDate] FROM [Players] WHERE ([TeamID] = ?)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="dlTeams" Name="TeamID" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
