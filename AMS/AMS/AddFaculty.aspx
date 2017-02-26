<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeBehind="AddFaculty.aspx.cs" Inherits="AMS.AddFaculty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
       Create New Faculty</h2>
    Enter Faculty Code :
    <asp:TextBox ID="FcodeBox" runat="server"></asp:TextBox><br />
    <br />
     Enter Password :
    <asp:TextBox ID="PwdBox" runat="server"></asp:TextBox><br />
    <br />
     Enter Faculty Name :
    <asp:TextBox ID="FnameBox" runat="server"></asp:TextBox><br />
    <br />
     Enter Faculty department :
    <asp:TextBox ID="FdeptBox" runat="server"></asp:TextBox><br />
    <br />

    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSearch_Click" /><br />
    <br />
     <asp:Label ID="FlblMsg" runat="server" Font-Bold="True" ForeColor="#CC0066"></asp:Label>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="fcode" DataSourceID="SqlDataSource1" EmptyDataText="Sorry! No Faculty Name Matched The Given Name."
        Width="100%">
        <EmptyDataRowStyle BackColor="#FFC0C0" Font-Bold="True" />
        <Columns>
            <asp:BoundField DataField="fcode" HeaderText="fcode" ReadOnly="True" SortExpression="fcode" />
            <asp:BoundField DataField="pwd" HeaderText="pwd" SortExpression="pwd" />
            <asp:BoundField DataField="fname" HeaderText="fname" SortExpression="fname" />
            <asp:BoundField DataField="dept" HeaderText="dept" SortExpression="dept" />
           
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceConnectionString %>"
        SelectCommand="AddNewFaculty" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="FcodeBox" Name="fcode" PropertyName="Text" Type="String" />
             
           
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
