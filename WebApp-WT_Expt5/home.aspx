<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApp_WT_Expt5.home" %>

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

    /* Additional styles */
    .title {
        font-size: 24px;
        font-weight: bold;
        margin-bottom: 5px;
    }

    .description {
        margin-bottom: 10px;
    }

    /* Add News form styles */
    #addFormContainer {
        margin-top: 20px;
        border: 1px solid #ddd;
        padding: 20px;
        width: 300px;
        margin-left: auto;
        margin-right: auto; /* Center align */
    }

    #addFormContainer h2 {
        font-size: 20px;
        margin-bottom: 10px;
    }

    #addFormContainer input[type="text"],
    #addFormContainer input[type="date"],
    #addFormContainer input[type="submit"] {
        width: 100%;
        margin-bottom: 10px;
        padding: 10px;
        box-sizing: border-box;
    }

    #addFormContainer input[type="submit"] {
        background-color: #4CAF50;
        color: white;
        border: none;
        cursor: pointer;
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
                <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-CssClass="title" />
                <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-CssClass="description" />
                <asp:BoundField DataField="PublishDate" HeaderText="Publish Date" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="Source" HeaderText="Source" />
            </Columns>
        </asp:GridView>
        <div id="addFormContainer">
            <h2>Add News</h2>
            <asp:TextBox ID="txtTitle" runat="server" placeholder="Title" /><br />
            <asp:TextBox ID="txtDescription" runat="server" placeholder="Description" /><br />
            <asp:TextBox ID="txtPublishDate" runat="server" placeholder="Publish Date (yyyy-MM-dd)" /><br />
            <asp:TextBox ID="txtSource" runat="server" placeholder="Source" /><br />
            <asp:Button ID="btnAddNews" runat="server" Text="Add News" OnClick="btnAddNews_Click" />
        </div>
    </form>
</body>
</html>