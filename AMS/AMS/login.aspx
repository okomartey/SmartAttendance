<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AttandanceProject.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <br />
        <br />
        <br />
        <br />
        <br />
     <h2> Login</h2>
     <table>
        <tr>
            <td>
               Faculty Code :
            </td>
            <td >
     
           <asp:TextBox ID="txtFcode" runat="server" Width="150px"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFcode"
               Display="Dynamic" ErrorMessage="Faculty Code is required!">*</asp:RequiredFieldValidator></td>
             </tr>
        <tr>
        
       <td >Password: </td>
       <td>
           <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd"
               Display="Dynamic" ErrorMessage="Password is required!">*</asp:RequiredFieldValidator></td>
             </tr>
        <tr>
              </table>
 
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="96px" />
        <p />
        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="#CC0066"></asp:Label>
        <p />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />


</asp:Content>
