<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AddNewStaff.aspx.cs" Inherits="AMS.AddNewStaff" %>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        Add New Staff</h2>
         <asp:HiddenField ID="StaffIdHiddenField" runat="server" />

     Enter Staff First Name :
    <asp:TextBox ID="SFnameBox" runat="server"></asp:TextBox>
    <br />
     Enter Staff Surname Name:
    <asp:TextBox ID="SSnameBox" runat="server"></asp:TextBox>
    <br />
     Enter Department:
    <asp:TextBox ID="DeptTextBox" runat="server"></asp:TextBox>
    <br />
     Enter Staff Username:
    <asp:TextBox ID="UnameBox" runat="server"></asp:TextBox>
    <br />
     Enter Staff Password:
    <asp:TextBox ID="PwsdTextBox" runat="server"></asp:TextBox>
    <br />
   
   

    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="Addstaff_Click" /><br />
    <br />
     <asp:Label ID="SlblMsg" runat="server" Font-Bold="True" ForeColor="#CC0066"></asp:Label>

  <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="fcode" DataSourceID="SqlDataSource1" Width="100%">
        <EmptyDataRowStyle BackColor="#FFC0C0" Font-Bold="True" />
        <Columns>
            <asp:BoundField DataField="admno" HeaderText="Id" ReadOnly="True" SortExpression="admno" />
            <asp:BoundField DataField="fname" HeaderText="First Name" SortExpression="fname" />
            <asp:BoundField DataField="Surname" HeaderText="Last Name" SortExpression="Surname" />
            <asp:BoundField DataField="fcode" HeaderText="User Name" SortExpression="fcode" />
            <asp:BoundField DataField="pwd" HeaderText="Password" SortExpression="Surname" />
            <asp:BoundField DataField="sname" HeaderText="Subject" SortExpression="sname" />
            
           

           
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceConnectionString %>"
        SelectCommand="AddNewFaculty" SelectCommandType="StoredProcedure" UpdateCommand="update  faculty set  dept = @dept ">
        <SelectParameters>
            <asp:ControlParameter ControlID="UnameBox" Name="fcode" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
