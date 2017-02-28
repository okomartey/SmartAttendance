<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Subjects.aspx.cs" Inherits="AMS.Subjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:GridView ID="SubjectGrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
         PageSize="5" Width="100%">
        <Columns>
            <asp:BoundField DataField="scode" HeaderText="Code" SortExpression="adate" />
            <asp:BoundField DataField="sname" HeaderText="Name" SortExpression="period" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="AddSubject" runat="server" Text="Add Subject" OnClick="Button1_Click" />


</asp:Content>
