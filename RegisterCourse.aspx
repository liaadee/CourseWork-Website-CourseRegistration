<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="App_Themes\SiteStyles.css" rel="stylesheet" />
    <title>Lab 8 - Register Courses</title>
</head>
<body>
    <h1>Registrations</h1>
    <form id="registerForm" runat="server">
        <asp:Label ID="labelStudent" runat="server" Text="Student:" CssClass="inputLabel"></asp:Label>
        <asp:DropDownList ID="dropdownStudents" runat="server" CssClass="inputList" AutoPostBack="True" EnableViewState="true" OnSelectedIndexChanged="dropdownStudents_SelectedIndexChanged">
            <asp:ListItem Text="--Select--" Selected="True" Value=""></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="validatorDropdownStudent" runat="server" ErrorMessage="Required" ControlToValidate="dropdownStudents" CssClass="error"></asp:RequiredFieldValidator>
        <%-- Registration Summary section --%>
        <asp:Panel ID="panelSummary" runat="server" CssClass="distinct">
            Selected Student has registered for 
            <asp:Label ID="labelNumberOfRegisteredCourses" runat="server" Text="0"></asp:Label>
            courses, 
            <asp:Label ID="labelWeeklyHoursOfRegisteredCourses" runat="server" Text="0"></asp:Label>
            hours weekly
        </asp:Panel>
        <%-- Course selection section: --%>
        <asp:Panel ID="panelInitialRequest" runat="server" Width="556px">
            <p>The following courses are currently available for registeration:</p>
            <%-- Error messages section: --%>
            <asp:Panel ID="panelErrorMessages" runat="server" CssClass="emphasis" Width="869px">
                <asp:Label ID="labelErrorMessageRegister" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="panelErrorMessageCheckbox" runat="server" CssClass="emphasis" Width="869px">
                <asp:Label ID="labelErrorMessageCheckbox" runat="server" Text="You must select at least 1 course"></asp:Label>
            </asp:Panel>
            <%-- CheckboxList etc. --%>
            <asp:CheckBoxList ID="checkboxlistCourses" runat="server" SelectedIndexChanged="checkboxlistCoursesFunc">
            </asp:CheckBoxList>
        </asp:Panel>
        <asp:Button ID="buttonSubmit" Text="Save" runat="server" CssClass="button" OnClick="buttonSubmit_Click" />
    </form>
    <p></p>
    <div>
        <a href="AddStudent.aspx">Add Students</a>
    </div>
</body>
</html>
