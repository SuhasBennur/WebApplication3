<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="WebApplication3.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: blueviolet;
            color: white;
        }

        td {
            padding: 10px;
        }

        a {
            color: white;
        }

          #color {
            width: 150px;
            margin-left: 30px;
        }

        #ct {
            margin-left: 30px;
        }
    </style>
</head>
<body id="bodyID" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <label id="ct">Change Theme</label>
            <%--<input type="color" id="color" />--%>
            <asp:DropDownList ID="color" runat="server" AutoPostBack="true" OnSelectedIndexChanged="color_SelectedIndexChanged">
                <asp:ListItem>Select Theme</asp:ListItem>
                <asp:ListItem>Black</asp:ListItem>
                <asp:ListItem>Orange</asp:ListItem>
                <asp:ListItem>Blue</asp:ListItem>
            </asp:DropDownList>
            <hr />

            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <table>
                <tr>
                    <td>
                        <label for="LName"><b>Login Name</b></label></td>
                    <td>
                        <asp:TextBox ID="LName" runat="server" placeholder="Enter Login Name" required="required" Style="width: 300px;" /></td>
                </tr>
                <tr>
                    <td>
                        <label for="psw"><b>Password</b></label></td>
                    <td>
                        <asp:TextBox ID="psw" runat="server" type="Password" placeholder="Enter Password" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters" required="required" Style="width: 300px;" /></td>
                </tr>
                <tr>
                    <td>
                        <label for="RName"><b>Real Name</b></label></td>
                    <td>
                        <asp:TextBox ID="RName" runat="server" placeholder="Enter Real Name" required="required" Style="width: 300px;" /></td>
                </tr>
                <tr>
                    <td>
                        <label for="Dpt"><b>Department </b></label>
                    </td>
                    <td>
                        <asp:TextBox ID="DName" runat="server" placeholder="Enter Department" required="required" Style="width: 300px" /></td>
                </tr>
                <tr>
                    <td>
                        <label for="DOB"><b>Date of Birth</b></label></td>
                    <td>
                        <asp:TextBox ID="DOB" runat="server" type="Date" placeholder="Enter Date of birth(YYYY-MM-DD)" required="required" Style="width: 300px" /></td>
                </tr>
            </table>
            <br />
            <hr />
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Register" />
        </div>
        <div class="container signin">
            <p>Already have an account? <a href="LoginPage.aspx">Login</a>.</p>
        </div>

    </form>

</body>
</html>
