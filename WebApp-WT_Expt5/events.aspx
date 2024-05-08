<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="WebApp_WT_Expt5.Events" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        /* Navbar styles */
        .navbar {
            background-color: #333;
            overflow: hidden;
        }

        .navbar a {
            float: left;
            display: block;
            color: white;
            text-align: center;
            padding: 14px 20px;
            text-decoration: none;
        }

        /* Search box styles */
        #searchContainer {
            text-align: center;
            margin-top: 20px;
        }

        #txtSearch {
            width: 300px;
            padding: 10px;
            margin-right: 10px;
        }

        #btnSearch {
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
        }

        /* GridView styles */
        #GridView1 {
            margin-top: 20px;
            width: 100%;
            border-collapse: collapse;
        }

        #GridView1 th, #GridView1 td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        #GridView1 th {
            background-color: #4CAF50;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="navbar">
        <a href="home.aspx">Home</a>
        <a href="events.aspx">Events</a>
        <a href="feedback.aspx">Problems</a>
    </div>
    <div id="searchContainer">
        <asp:TextBox ID="txtSearch" runat="server" placeholder="Enter search keyword" />
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Name" HeaderText="Event Name" />
        <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="Location" HeaderText="Location" />
        <asp:BoundField DataField="Description" HeaderText="Description" />
    </Columns>
</asp:GridView>


</form>
</body>
</html>
