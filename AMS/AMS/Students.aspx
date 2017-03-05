<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="AttandanceProject.Students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <br />
        <br />
        <br />
        <br />
        <br />
     <asp:GridView ID="StudentsGrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="admno" DataSourceID="SqlDataSource1" EmptyDataText="Sorry! No Student's Name Matched The Given Name."
        Width="100%">
        <EmptyDataRowStyle BackColor="#FFC0C0" Font-Bold="True" />
        <Columns>
            <asp:BoundField DataField="admno" HeaderText="Id" ReadOnly="True" SortExpression="admno" />
            <asp:BoundField DataField="fname" HeaderText="First Name" SortExpression="fname" />
            <asp:BoundField DataField="Surname" HeaderText="Lastname" SortExpression="Surname" />
            <asp:BoundField DataField="course" HeaderText="Course" SortExpression="course" />
            <asp:BoundField DataField="semno" HeaderText="Semester." SortExpression="semno" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceConnectionString %>"
        SelectCommand="GetAllStudents" SelectCommandType="StoredProcedure">
        
    </asp:SqlDataSource>

    <asp:Button ID="AddNewStudent" runat="server" OnClick="AddNewStudent_click" Text="Add New Student" />
</asp:Content>
