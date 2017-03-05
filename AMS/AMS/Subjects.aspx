<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subjects.aspx.cs" Inherits="AttandanceProject.Subjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <br />
        <br />
        <br />
        <br />
        <br />
    <asp:GridView ID="SubjectGrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
         PageSize="5" Width="100%">
        <Columns>
            <asp:BoundField DataField="scode" HeaderText="Code" SortExpression="adate" />
            <asp:BoundField DataField="sname" HeaderText="Name" SortExpression="period" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="AddSubject" runat="server" Text="Add Subject" OnClick="Button1_Click" />

</asp:Content>
