<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultC.aspx.cs" Inherits="HW10_Olofintuyi.DefaultC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script>

	function noSuggestions() {
		$("#txtResults").val("***No Albums to display");
	}

	$(document).ready(function () {
        $("#searchBtn").click(function () {
			const numMartians = $("#txtNumMartians").val();

			$.ajax({
				type: "GET",
				url: "AlbumService.aspx/GetMartians",
				data: {
                    type: searchType,
                    criteria: searchCriteria
				},
				dataType: "json", // xml, html, script, json, text
				success: function (response) {
					if (response.length == 0) {
						return noSuggestions();
					}
					const martians = response;
					const martiansMessage = getMartiansMessage(martians);
					$("#txtResults").val(martiansMessage);
				}
			});
		});
    });



	function getMartiansMessage(martians) {
		var msg = "Martians: id-name\n";
		for (i = 0; i < martians.length; i++) {
			const martian = martians[i];
			msg += "" + martian.Id + "-" + martian.Name + "\n";
		}
		return msg;
	}
</script>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <h3>HW 10 -Album Search, Emmanuel Olofintuyi</h3>
            <asp:Panel ID="Panel1" runat="server" GroupingText="Search">
           <asp:RadioButtonList ID="rblSearchCriteria" runat="server">
               <asp:ListItem>Title</asp:ListItem>
               <asp:ListItem>Artist</asp:ListItem>
               <asp:ListItem>Year</asp:ListItem>
                </asp:RadioButtonList>
                <input id="titleInput" type="text" /><br />
            
                <input id="artistInput" type="text" /><br />
            
                
            
                 <input id="yearInpupt" type="text" /><br />
                <asp:Button ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click" />
                </asp:Panel>
            <div>
            <p>Results</p>
                <asp:TextBox ID="TextBox1" runat="server" Height="221px" TextMode="MultiLine" Width="349px"></asp:TextBox>
                </div>
        </div>
    </form>
</body>
    
</html>
