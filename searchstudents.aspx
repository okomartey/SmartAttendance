<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="searchstudents.aspx.cs" Inherits="AttandanceProject.searchstudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <br />
        <br />
        <br />
        <br />
        <br />
        <h2>
        Search For Students</h2>
    Enter Student's Name :
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" /><br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="admno" DataSourceID="SqlDataSource1" EmptyDataText="Sorry! No Student's Name Matched The Given Name."
        Width="100%">
        <EmptyDataRowStyle BackColor="#FFC0C0" Font-Bold="True" />
        <Columns>
            <asp:BoundField DataField="admno" HeaderText="Admno" ReadOnly="True" SortExpression="admno" />
            <asp:BoundField DataField="Surname" HeaderText="Name" SortExpression="sname" />
            <asp:BoundField DataField="course" HeaderText="Course" SortExpression="course" />
            <asp:BoundField DataField="semno" HeaderText="Sem No." SortExpression="semno" />
            <asp:HyperLinkField DataNavigateUrlFields="admno" DataNavigateUrlFormatString="studentattendance.aspx?admno={0}"
                Text="Attendance" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceConnectionString %>"
        SelectCommand="GetStudents" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtName" Name="fname" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
