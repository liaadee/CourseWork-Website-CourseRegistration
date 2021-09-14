<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab8.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="App_Themes\SiteStyles.css" rel="stylesheet" />
    <title>Lab 8 - Add Students Form</title>
</head>
<body>
    <h1>Students</h1>
    <form id="addStudentForm" runat="server">
        <asp:Label ID="labelName" runat="server" Text="Student Name:" CssClass="inputLabel"></asp:Label>
        <asp:TextBox ID="textboxName" runat="server" CssClass="input"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="textboxName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" CssClass="error"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="labelStudentType" runat="server" Text="Student Type:" CssClass="inputLabel"></asp:Label>
        <asp:DropDownList ID="dropdownStudentType" runat="server" CssClass="inputList">
            <asp:ListItem Text="--Select--" Selected="True" Value=""></asp:ListItem>
            <asp:ListItem Text="Full-Time" Value="itemFullTime"></asp:ListItem>
            <asp:ListItem Text="Part-Time" Value="itemPartTime"></asp:ListItem>
            <asp:ListItem Text="Co-op" Value="itemCoop"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ControlToValidate="dropdownStudentType" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" CssClass="error"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="button" runat="server" Text="Add" CssClass="button" OnClick="button_Click" />
    </form>
    <asp:Table ID="tableConfirmation" runat="server" CssClass="table">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell Text="ID"></asp:TableHeaderCell>
            <asp:TableHeaderCell Text="Name"></asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow runat="server" ID="rowDefault">
            <asp:TableCell ColumnSpan="2" CssClass="emphasis" HorizontalAlign="Center" Text="No Students Added" ForeColor="Red"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div>
        <a href="RegisterCourse.aspx">Register Courses</a>
    </div>
</body>
</html>
