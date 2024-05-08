<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="WebApp_WT_Expt5.feedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Feedback</title>
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

        /* Container styles */
        .container {
            width: 80%;
            margin: 0 auto;
        }

        /* Issue styles */
        .issue {
            background-color: #ffcccc;
            margin-bottom: 10px;
            padding: 10px;
            border-radius: 5px;
        }

        .solved {
            background-color: #f0f0f0;
        }

        .issue span {
            font-weight: bold;
        }

        /* Add Issue container styles */
        #addIssueContainer {
            margin-top: 20px;
        }

        #addIssueContainer h2 {
            margin-bottom: 10px;
        }

        /* Button styles */
        .btn {
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 5px;
        }

        /* Footer styles */
        footer {
            margin-top: 20px;
            text-align: center;
            background-color: #333;
            color: white;
            padding: 10px 0;
            position: fixed;
            bottom: 0;
            width: 100%;
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
        
        <div id="addIssueContainer">
            <h2>Add Issue</h2>
            <asp:TextBox ID="txtIssueName" runat="server" placeholder="Issue Name" /><br />
            <asp:Button ID="btnAddIssue" runat="server" Text="Add Issue" OnClick="btnAddIssue_Click" />
        </div>
        
        <div id="issuesContainer">
            <h2>Issues</h2>
            <asp:Repeater ID="rptIssues" runat="server">
                <ItemTemplate>
                    <div class='<%# Eval("Status").ToString() == "Solved" ? "issue solved" : "issue" %>'>
                        <span><%# Eval("Name") %></span>
                        <asp:Button ID="btnMarkAsSolved" runat="server" Text="Mark as Solved" CommandArgument='<%# Eval("ID") %>' OnClick="btnMarkAsSolved_Click" Visible='<%# Eval("Status").ToString() == "Open" %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
