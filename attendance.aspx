<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="attendance.aspx.cs" Inherits="AttandanceProject.attendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
          <br />
        <br />
        <br />
        <br />
        <br />
    <h2>
        Attendance
    </h2>
    <asp:HiddenField ID="AttendIdHiddenField" runat="server" />
    <asp:Panel ID="Panel1" runat="server" GroupingText="Attendance Header" Width="100%"> 
        Today :
        <asp:Label ID="lblToday" runat="server" CssClass="borderlabel"></asp:Label>
       &nbsp; &nbsp; 
        Week No:
        <asp:Label ID="lblWeekno" runat="server" CssClass="borderlabel"></asp:Label>
       &nbsp; &nbsp;  
        Period :
        <asp:Label ID="lblPeriod" runat="server" CssClass="borderlabel"></asp:Label>
       &nbsp; &nbsp;  
        Seminster :<asp:Label ID="lblSemister" runat="server" CssClass="borderlabel"></asp:Label>
 

        </asp:Panel>
       <br />
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="admno"
           DataSourceID="SqlDataSource1" Width="100%">
           <Columns>
               <asp:BoundField DataField="admno" HeaderText="admno" ReadOnly="True" SortExpression="admno" >
                   <ItemStyle HorizontalAlign="Center" />
               </asp:BoundField>
               <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" >
                   <ItemStyle HorizontalAlign="Center" />
               </asp:BoundField>
               <asp:TemplateField HeaderText="Attendance">
                   <ItemTemplate>
                       <asp:RadioButton ID="rbPresent" runat="server" Checked="True" GroupName="g1" Text="Present" />
                       <asp:RadioButton ID="rbAbsent" runat="server" GroupName="g1" Text="Absent" />
                       <asp:RadioButton ID="rbLeave" runat="server" GroupName="g1" Text="Leave" />
                   </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Remarks">
                   <ItemTemplate>
                       <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
                   </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
               </asp:TemplateField>
           </Columns>
          
       </asp:GridView>
       <br />
       <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="131px" OnClick="btnSubmit_Click" /><br />
       <br />
       <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="#CC0066"></asp:Label><br />
       <br />
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceConnectionString %>"
           SelectCommand="select  admno, Surname from students&#13;&#10;where   bcode = &#13;&#10;     ( select  bcode from schedule where weekno= @weekno and  period = @period and  &#13;&#10;             fcode = @fcode)&#13;&#10;order by Surname">
           <SelectParameters>
               <asp:QueryStringParameter Name="weekno" QueryStringField="weekno" />
               <asp:QueryStringParameter Name="period" QueryStringField="period" />
               <asp:SessionParameter Name="fcode" SessionField="fcode" />
           </SelectParameters>
       </asp:SqlDataSource>
</asp:Content>