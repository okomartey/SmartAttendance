<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="AMS.Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        Time Table</h2>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="weekno,period,bcode" DataSourceID="SqlDataSource1" Width="100%">
            <Columns>
                <asp:BoundField DataField="weekname" HeaderText="Week" ReadOnly="True" SortExpression="weekname" />
                <asp:BoundField DataField="weekno" HeaderText="weekno" ReadOnly="True" SortExpression="weekno"
                    Visible="False" />
                <asp:BoundField DataField="period" HeaderText="Period" ReadOnly="True" SortExpression="period" />
                <asp:BoundField DataField="semister" HeaderText="Semister" ReadOnly="True" SortExpression="semister" />
                <asp:BoundField DataField="bcode" HeaderText="bcode" ReadOnly="True" SortExpression="bcode"
                    Visible="False" />
                <asp:BoundField DataField="sname" HeaderText="Subject" SortExpression="sname" />
                <asp:BoundField DataField="scode" HeaderText="scode" SortExpression="scode" Visible="False" />
                <asp:HyperLinkField DataNavigateUrlFields="weekno,period,semister" DataNavigateUrlFormatString="attendance.aspx?weekno={0}&amp;period={1}&amp;semister={2}"
                    Text="Attendance" />
            </Columns>
        </asp:GridView>
        &nbsp;</p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceConnectionString %>"
            SelectCommand="GetTimeTable" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="fcode" SessionField="fcode" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        &nbsp;</p>
</asp:Content>


