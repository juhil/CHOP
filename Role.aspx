<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Role.aspx.cs"  Inherits="_Default"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 
<html runat="server">

<head runat="server">
  <title>Free HTML5 Templates</title>
   <meta name="description" content="website description" />
  <meta name="keywords" content="website keywords, website keywords" />
  <meta http-equiv="content-type" content="text/html; charset=windows-1252" />
  <link rel="stylesheet" type="text/css" href="css/style.css" />
  <!-- modernizr enables HTML5 elements and feature detects -->
  <script type="text/javascript" src="js/modernizr-1.5.min.js"></script>

 
    
</head>
<body runat="server">
  <div id="main">
    <header>
	  <div id="banner">
	    <div id="welcome">
	     <h2>Children's Hospital of Philadelphia&reg;</h2>
	    </div><!--close welcome-->			  	
	  </div><!--close banner-->	
	</header>
	
	<nav>
	  <div id="menubar">
        <ul id="nav">
          <li class="current"><a href="Role.aspx">Role</a></li>
          <li><a href="Template.aspx">Template</a></li>
          <li><a href="Cadence.aspx">Cadence</a></li>
          <li><a href="Training.aspx">Training</a></li>
          <li><a href="Employee.aspx">Employee</a></li>
          <li><a href="Reports.aspx">Reports</a></li>
      
        </ul>
      </div><!--close menubar-->	
    </nav>	
    
	<div id="site_content">		

        <form id="form1" runat="server">
             <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
   
    <div>
        
        <table>
            <tr>
                <td>Job Code:</td>
                <td>
                    
                    <asp:TextBox ID="TxtNam" runat="server"></asp:TextBox>

                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtNam"
         MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" 
         ServiceMethod="GetCity" >
    </cc1:AutoCompleteExtender>

                    
                </td>
            </tr>
            <tr>
                <td>Department No:</td>
                <td>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [batch_year] FROM [Batch_year]"></asp:SqlDataSource>
            <asp:DropDownList ID="DPdeptno" runat="server" ></asp:DropDownList>
               
                      </td>
            </tr>
            <tr>
                <td>Department Name:</td>
                <td>
                    <asp:TextBox ID="TBdeptname" runat="server"></asp:TextBox>
    
                                </td>
            </tr>

            <tr>
                <td>Job Description:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Template No:</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Template Name:</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Provider:</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
</table>

    </div>
    </form>
	</div><!--close site_content-->  	
  
    <footer>
	  </footer> 
  
  </div><!--close main-->
  
  <!-- javascript at the bottom for fast page loading -->
  <script type="text/javascript" src="js/jquery.min.js"></script>
  <script type="text/javascript" src="js/image_slide.js"></script>
  
</body>
</html>
