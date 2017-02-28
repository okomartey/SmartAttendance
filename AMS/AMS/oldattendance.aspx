<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="oldattendance.aspx.cs" Inherits="AMS.oldattendance" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
    Old Attendance<br />
    </h2>
    Enter Date :
    <asp:TextBox ID="TextBox1" runat="server" Width="73px"></asp:TextBox>
    (mm/dd/yy)&nbsp; Period Number :
    <asp:TextBox ID="TextBox2" runat="server" Width="56px"></asp:TextBox>
    <asp:Button ID="btnGetAttendance" runat="server" Text="Get Attendance" /><br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="admno">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="admno" HeaderText="admno" SortExpression="admno" ReadOnly="True" />
            <asp:BoundField DataField="Surname" HeaderText="sname" SortExpression="sname" ReadOnly="True" />
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
            <asp:BoundField DataField="remarks" HeaderText="remarks" SortExpression="remarks" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceConnectionString %>"
        SelectCommand="select  a.admno, Surname, status , remarks from attendance a, students s&#13;&#10;where  period = @period and fcode = @fcode and  adate = @adate and s.admno  = a.admno&#13;&#10;order by Surname"
        UpdateCommand="update  attendance set  status = @status ,  remarks  = @remarks &#13;&#10;where  adate = @adate  and  admno = @admno and period = @period">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox2" Name="period" PropertyName="Text" />
            <asp:SessionParameter Name="fcode" SessionField="fcode" />
            <asp:ControlParameter ControlID="TextBox1" Name="adate" PropertyName="Text" />
        </SelectParameters>
        <UpdateParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="adate" PropertyName="Text" /> 
            <asp:ControlParameter ControlID="TextBox2" Name="period" PropertyName="Text" /> 
            <asp:Parameter Name="status"  Type="String"/>
            <asp:Parameter Name="remarks" Type="String" />
            <asp:Parameter Name="admno" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

