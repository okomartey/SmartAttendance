<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="AttandanceProject.Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <br />
        <br />
        <br />
        <br />
        <br />
    <asp:GridView ID="StaffGrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="admno" DataSourceID="SqlDataSource1" EmptyDataText="Sorry! No Staff's Name Matched The Given Name."
        Width="100%">
        <EmptyDataRowStyle BackColor="#FFC0C0" Font-Bold="True" />
        <Columns>
            <asp:BoundField DataField="admno" HeaderText="Id" ReadOnly="True" SortExpression="admno" />
            <asp:BoundField DataField="fname" HeaderText="First Name" SortExpression="fname" />
            <asp:BoundField DataField="Surname" HeaderText="Last Name" SortExpression="Surname" />
            <asp:BoundField DataField="fcode" HeaderText="User Name" SortExpression="fcode" />
            <asp:BoundField DataField="pwd" HeaderText="Password" SortExpression="Surname" />
            <asp:BoundField DataField="sname" HeaderText="Subjects" SortExpression="sname" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceConnectionString %>"
        SelectCommand="GetAllFaculty" SelectCommandType="StoredProcedure">

        
    </asp:SqlDataSource>

    <asp:Button ID="AddNewStuff" runat="server" OnClick="AddNewStudent_click" Text="Add New Staff" />
</asp:Content>
