<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="AMS.test" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceConnectionString %>"
        DeleteCommand="DELETE FROM [faculty] WHERE [fcode] = @fcode" InsertCommand="INSERT INTO [faculty] ([fcode], [pwd], [fname], [dept]) VALUES (@fcode, @pwd, @fname, @dept)"
        SelectCommand="SELECT * FROM [faculty]" UpdateCommand="UPDATE [faculty] SET [pwd] = @pwd, [fname] = @fname, [dept] = @dept WHERE [fcode] = @fcode">
        <DeleteParameters>
            <asp:Parameter Name="fcode" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="pwd" Type="String" />
            <asp:Parameter Name="fname" Type="String" />
            <asp:Parameter Name="dept" Type="String" />
            <asp:Parameter Name="fcode" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="fcode" Type="String" />
            <asp:Parameter Name="pwd" Type="String" />
            <asp:Parameter Name="fname" Type="String" />
            <asp:Parameter Name="dept" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>

