<%@ Page Language="C#" AutoEventWireup="true" CodeFile="javascript.aspx.cs" Inherits="javascript" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>JQuery AutoComplete TextBox Demo</title>
   <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui-1.8.custom.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
    
		<script type="text/javascript">
			$(document).ready(function () {

				SearchText();

				function SearchText() {
					$("#<%=TextBox1.ClientID %>").autocomplete({
						source: function (request, response) {
							$.ajax({
								url: "javascript.aspx/GetAutoCompleteData",
								type: "POST",
								dataType: "json",
								contentType: "application/json; charset=utf-8",
								data: "{ 'txt' : '" + $("#<%=TextBox1.ClientID %>").val() + "'}",
								dataFilter: function (data) { return data; },
								success: function (data) {
									response($.map(data.d, function (item) {
										return {
											label: item,
											value: item
										}
									}))
									//debugger;
								},
								error: function (result) {
									alert("Error");
								}
							});
						},
						minLength: 1,
						delay: 1000
					});
				}
			});
		</script>
</head>
<body>
<form id="form1" runat="server">
<div><h1>AutoComplete Textbox</h1>
City:
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</div>
</form>
   
    
     
	
</body>
</html>

