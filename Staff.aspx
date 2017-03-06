<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="AttandanceProject.Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <br />
        <br />
        <br />
        <br />
        <br />
          <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="AttandanceProject.DataAccess.ASMDataContext" EntityTypeName="" GroupBy="dept" OrderGroupsBy="key desc" Select="new (key as dept, it as faculties)" TableName="faculties">
          </asp:LinqDataSource>
    <asp:GridView ID="StaffGrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="admno" DataSourceID="SqlDataSource1" EmptyDataText="Sorry! No Staff's Name Matched The Given Name."
        Width="100%">
        <EmptyDataRowStyle BackColor="#FFC0C0" Font-Bold="True" />
        <Columns>
             <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="admno" HeaderText="Id" ReadOnly="True" SortExpression="admno"  />
            <asp:BoundField DataField="fname" HeaderText="First Name" ReadOnly="True" SortExpression="fname"  />
            <asp:BoundField DataField="Surname" HeaderText="Last Name" ReadOnly="True"  SortExpression="Surname" />
            <asp:BoundField DataField="fcode" HeaderText="User Name" ReadOnly="True"  SortExpression="fcode" />
            <asp:BoundField DataField="pwd" HeaderText="Password" ReadOnly="True"  SortExpression="Surname" />
            <asp:BoundField DataField="sname" HeaderText="Subjects" SortExpression="sname" />
        </Columns>
    </asp:GridView>

     

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceConnectionString %>"
        SelectCommand="GetAllFaculty" SelectCommandType="StoredProcedure" UpdateCommand="update  faculty set  dept = @dept ">
            <UpdateParameters>
            <asp:ControlParameter ControlID="DeptTextBox" Name="dept" PropertyName="Text" /> 
            <asp:Parameter Name="sname"  Type="String"/>
        </UpdateParameters>
        
    </asp:SqlDataSource>

    <asp:Button ID="AddNewStuff" runat="server" OnClick="AddNewStudent_click" Text="Add New Staff" />
</asp:Content>
