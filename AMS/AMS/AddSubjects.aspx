<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AddSubjects.aspx.cs" Inherits="AMS.AddSubjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="SubName" runat="server" Text="Subject Name"></asp:Label>
    <asp:TextBox ID="SubNameTextBox" runat="server"></asp:TextBox>
    <asp:Label ID="SubCode" runat="server" Text="Subject Code"></asp:Label>
    <asp:TextBox ID="SubCodeTextBox" runat="server"></asp:TextBox>

    <asp:GridView ID="SubjectDateGrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        PageSize="5" Width="100%" ShowFooter="true">
        <Columns>
            <asp:TemplateField HeaderText="Date" SortExpression="Date">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server"
                        Text='<%# Bind("Date") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Calendar ID="Calendar" runat="server"></asp:Calendar>
<%--                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server" ControlToValidate="NewProductName"
                        Display="Dynamic" ForeColor=""
                        ErrorMessage="You must enter a name for the new product.">
                    * </asp:RequiredFieldValidator>--%>
                </FooterTemplate>
                <FooterStyle Wrap="False" />
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <asp:Button ID="AddNewDate" runat="server" OnClick="AddNewDate_Click" />
</asp:Content>
