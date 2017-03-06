<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssignTimeTable.aspx.cs" Inherits="AttandanceProject.AssignTimeTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <br />
        <br />
        <br />
        <br />
        <br />
     <h2>
    Assign TimeTable<br />
    </h2>

     <asp:HiddenField ID="TimeTableIdHiddenField" runat="server" />
    <asp:Label ID="StaffUname" runat="server" Text="Staff Username"></asp:Label>
     <br />
      <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="LinqDataSource2" DataTextField="fcode" DataValueField="fcode">
      </asp:DropDownList>
      <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="AttandanceProject.DataAccess.ASMDataContext" EntityTypeName="" Select="new (fcode)" TableName="faculties">
      </asp:LinqDataSource>
     <br />
      <asp:Label ID="Sem" runat="server" Text="Semester"></asp:Label>
     <br />
      <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
      </asp:DropDownList>
     <br />
    <asp:Label ID="Weekno" runat="server" Text="Week day"></asp:Label>
     <br />
      <asp:DropDownList ID="DropDownList5" runat="server">
          <asp:ListItem Value="0">Sunday</asp:ListItem>
          <asp:ListItem Value="1">Monday</asp:ListItem>
          <asp:ListItem Value="2">Tuesday</asp:ListItem>
          <asp:ListItem Value="3">Wednesday</asp:ListItem>
          <asp:ListItem Value="4">Thursday</asp:ListItem>
      </asp:DropDownList>
     <br />
    <asp:Label ID="Period" runat="server" Text="period"></asp:Label>
    <asp:DropDownList ID="DropDownList3" runat="server">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
    </asp:DropDownList>   
    <br />
     <br />
    Assign Subject :
    <asp:Label ID="SubCode" runat="server" Text="Subject Code"></asp:Label>
      <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="LinqDataSource1" DataTextField="sname" DataValueField="scode">
      </asp:DropDownList>
      <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="AttandanceProject.DataAccess.ASMDataContext" EntityTypeName="" OrderBy="sname" Select="new (scode, sname)" TableName="subjects">
      </asp:LinqDataSource>
    <br />
    <br />

    <asp:Label ID="SlblMsg" runat="server" Font-Bold="True" ForeColor="#CC0066"></asp:Label>

        <asp:GridView ID="TimeTableGrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        PageSize="5" Width="100%" ShowFooter="true">
        <Columns>
            <asp:TemplateField HeaderText="TimeTable" SortExpression="fcode">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server"
                        Text='<%# Bind("fcode") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>


        </Columns>
    </asp:GridView>

    <asp:Button ID="Assign" runat="server" Text="Assign "  OnClick="Assign_Click" />

</asp:Content>
