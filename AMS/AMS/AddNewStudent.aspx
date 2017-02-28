<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AddNewStudent.aspx.cs" Inherits="AMS.AddNewStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        Add New Student</h2>
     Enter Student First Name :
    <asp:TextBox ID="FnameBox" runat="server"></asp:TextBox>
    <br />
     Enter Student Surname Name:
    <asp:TextBox ID="SnameBox" runat="server"></asp:TextBox>
    <br />
     Enter Student Semester:
    <asp:TextBox ID="SemBox" runat="server"></asp:TextBox>
    <br />
   

    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSearch_Click" /><br />
    <br />
     <asp:Label ID="SlblMsg" runat="server" Font-Bold="True" ForeColor="#CC0066"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="fname" DataSourceID="SqlDataSource1" EmptyDataText="Sorry! No Student's Name Matched The Given Name."
        Width="100%">
        <EmptyDataRowStyle BackColor="#FFC0C0" Font-Bold="True" />
        <Columns>
            <asp:BoundField DataField="admno" HeaderText="Id" ReadOnly="True" SortExpression="admno" />
            <asp:BoundField DataField="fname" HeaderText="First Name" SortExpression="fname" />
            <asp:BoundField DataField="Surname" HeaderText="Last Name" SortExpression="sname" />
            <asp:BoundField DataField="course" HeaderText="Course" SortExpression="course" />
            <asp:BoundField DataField="semno" HeaderText="Semester." SortExpression="semno" />
           

           
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceConnectionString %>"
        SelectCommand="GetStudents" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="FnameBox" Name="fname" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>


         