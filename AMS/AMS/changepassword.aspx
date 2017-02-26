<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="AMS.changepassword" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2> Change Password</h2>
    <table>
        <tr>
            <td>
                Old Password :
            </td>
            <td >
                <asp:TextBox ID="txtOldpwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldpwd"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                New Password :
            </td>
            <td >
                <asp:TextBox ID="txtNewpwd" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td >
                Confirm New Password :
            </td>
            <td >
                <asp:TextBox ID="txtConfirmpwd" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click" Text="Change Password" /><br />
    <br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label><br />
</asp:Content>

