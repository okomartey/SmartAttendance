<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="faculties.aspx.cs" Inherits="AMS.faculties" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        List Of Faculties</h2>
    <p>
        <asp:DataList ID="DataList1" runat="server" DataKeyField="fcode" DataSourceID="SqlDataSource1" Width="100%">
        <HeaderTemplate>
          <hr/> 
        </HeaderTemplate> 
            <ItemTemplate>
                Faculty Code : <%# Eval("fcode") %>
                <br />
                Faculty Name :
                <%# Eval("fname") %>
                <br />
                Departmet :
                <%# Eval("dept") %>
            </ItemTemplate>
           <SeparatorTemplate>
                <hr /> 
           </SeparatorTemplate> 
          <FooterTemplate>
            <hr /> 
          </FooterTemplate> 
        </asp:DataList>&nbsp;&nbsp;&nbsp;</p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceConnectionString %>"
            SelectCommand="SELECT [fcode], [fname], [dept] FROM [faculty]"
             DeleteCommand="DELETE FROM [faculty] WHERE [fcode] = @fcode" 
             InsertCommand="INSERT INTO [faculty] ([fcode],[pwd], [fname], [dept]) VALUES (@fcode,'', @fname, @dept)" 
             UpdateCommand="UPDATE [faculty] SET [fname] = @fname, [dept] = @dept WHERE [fcode] = @fcode">
            <DeleteParameters>
                <asp:Parameter Name="fcode" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="fname" Type="String" />
                <asp:Parameter Name="dept" Type="String" />
                <asp:Parameter Name="fcode" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="fcode" Type="String" />
                <asp:Parameter Name="fname" Type="String" />
                <asp:Parameter Name="dept" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        &nbsp;</p>
</asp:Content>

