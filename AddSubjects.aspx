<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSubjects.aspx.cs" Inherits="AttandanceProject.AddSubjects" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <br />
        <br />
        <br />
        <br />
        <br />
       <h2> Add New Subject</h2>
        

    <asp:HiddenField ID="SubjectIdHiddenField" runat="server" />

    <asp:Label ID="SubName" runat="server" Text="Subject Name"></asp:Label>
     <br />
    <asp:TextBox ID="SubNameTextBox" runat="server"></asp:TextBox>
     <br />
    <asp:Label ID="SubCode" runat="server" Text="Subject Code"></asp:Label>
     <br />
    <asp:TextBox ID="SubCodeTextBox" runat="server"></asp:TextBox>
     <br />
     <br />
     <asp:Label ID="SlblMsg" runat="server" Font-Bold="True" ForeColor="#CC0066"></asp:Label>

    <asp:GridView ID="SubjectGrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        PageSize="5" Width="100%" ShowFooter="true">
        <Columns>
            <asp:TemplateField HeaderText="Subjects" SortExpression="sname">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server"
                        Text='<%# Bind("sname") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <asp:Button ID="AddNewDate" runat="server" Text="Add Subject"  OnClick="AddNewDate_Click" />
</asp:Content>
