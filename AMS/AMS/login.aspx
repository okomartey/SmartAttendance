<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AMS.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<style>
     .header {
     background-color:#dddddd;
     font:700 14pt arial;
     color:red;
     text-align:center;
     }
     .loginbox {
       position:absolute;
       top:150px;
       left:200px;
       width:400px;
       height:200px;  
       background-color:white;
       text-align:center;
       border-right: black solid;
       border-top: black solid;
       border-left: black solid;
       border-bottom: black solid;
     }
     .title {
       font:700 30pt arial;
       color:white;
       background-color:navy;
       text-align:center;
       letter-spacing:10pt;
     }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="title">Online Attendance</div>
    <div class="loginbox"> 
      <div class="header">Login</div>
      <p />
      <table>
       <tr>
       <td >Faculty Code: </td>
       <td>
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
      </table>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="96px" />
        <p />
        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="#CC0066"></asp:Label>
        <p />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
   </form>
</body>
</html>
