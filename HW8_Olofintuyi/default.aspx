<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="HW8_Olofintuyi._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HW 8 - Emmanuel Olofintuyi</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Course Registration System</h2>
                
            
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="Dorm">Dorm</asp:ListItem>
                <asp:ListItem Value="Meal Plan">Meal Plan</asp:ListItem>
                <asp:ListItem Value="Football Tix">Football Tix</asp:ListItem>
                </asp:CheckBoxList>
    
            <table>
                <tr>
                    <th>
                        Availabale Classes
                        </th>
                    <th>
                        
                    </th>

                    <th>
                        Registered Classes

                    </th>
                </tr>
            <tr>
                <td>
                    <asp:ListBox ID="lbxAvailableClasses" runat="server" Height="266px" Width="125px" SelectionMode="Multiple" ></asp:ListBox>
                   
            </td>
           <td>
               <div><asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click"  /></div>
               <div><asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" /></div>
               <div><asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" /></div>
               
                   <h5>Total Hours: <asp:Label ID="lblHours" runat="server" Text=" 0"> </asp:Label></h5>
                   <h5>Total Cost: <asp:Label ID="lblCost" runat="server"  Text=" 0"> </asp:Label> </h5>
               

               </td>
            
                <td>
                    <asp:ListBox ID="lbxRegisteredClasses" runat="server" Height="262px" Width="94px" SelectionMode="Multiple"></asp:ListBox>
                </td>
                </tr>
                </table>
                    <asp:Label ID="Label" runat="server" Text=""></asp:Label>
                    <h4>Class Number: <asp:TextBox ID="classNumberInput" runat="server" ></asp:TextBox>   Credits: <asp:TextBox ID="creditHourInput" runat="server"></asp:TextBox></h4>
                    <div><asp:Button ID="btnMakeAvailable" runat="server" Text="Make Available" OnClick="btnMakeAvailable_Click"/><asp:Button ID="btnRemoveAvailable" runat="server" Text="Remove From Available" style="margin-left: 10px" OnClick="btnRemoveAvailable_Click" /></div>
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
               </div> 
          
        
    </form>
</body>
</html>
