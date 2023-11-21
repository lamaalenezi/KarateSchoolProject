<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="KarateSchoolProject.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Administrator</h1>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Agency FB" Font-Size="XX-Large" Text="Members:"></asp:Label>
    <br />
    
    
    <asp:Button ID="AssignMemberBtn" runat="server" OnClick="AssignMemberBtn_Click" Text="Assign Member" />
    <asp:DropDownList ID="SectionDropDownList" runat="server" DataSourceID="KarateSections" DataTextField="SectionName" DataValueField="SectionName" OnSelectedIndexChanged="SectionDropDownList_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="KarateSections" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString2 %>" SelectCommand="SELECT [SectionName] FROM [Section]"></asp:SqlDataSource>
    <br />
    <asp:GridView ID="MemberGridView" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="KarateSchool" ForeColor="Black" GridLines="Horizontal" Height="289px" Style="margin-right: 4px" Width="638px" OnSelectedIndexChanged="MemberGridView_SelectedIndexChanged1" 
             OnRowDeleting="MemberGridView_RowDeleting" DataKeys="Member_UserID" AutoGenerateColumns="False">
        <Columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="MemberFirstName" HeaderText="First Name" SortExpression="MemberFirstName" />
            <asp:BoundField DataField="MemberLastName" HeaderText="Last Name" SortExpression="MemberLastName" />
            <asp:BoundField DataField="MemberDateJoined" HeaderText="Date Joined" SortExpression="MemberDateJoined" />
            <asp:BoundField DataField="MemberPhoneNumber" HeaderText="Phone Number" SortExpression="MemberPhoneNumber" />
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
            </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
    <asp:SqlDataSource ID="KarateSchool" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString2 %>" SelectCommand="SELECT [MemberFirstName], [MemberLastName], [MemberDateJoined], [MemberPhoneNumber] FROM [Member]"></asp:SqlDataSource>
    <p>
        <strong>Add New Member</strong></p>
    <p>
        First Name&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtMemberFirstName" runat="server" Width="214px"></asp:TextBox>
    </p>
    <p>
        Last Name&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtMemberLastName" runat="server" Width="213px"></asp:TextBox>
    </p>
    <p>
        Date Joined<asp:Calendar ID="CalMemberDateJoined" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" SelectedDate="2023-11-15">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
    </p>
    <p>
        Phone Number&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtMemberPhoneNum" runat="server" Width="192px"></asp:TextBox>
    </p>
    <p>
        Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtMemberEmail" runat="server" Width="187px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="AddMemberBtn" runat="server" OnClick="AddMemberBtn_Click1" Text="Add" />
    </p>
    <br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Agency FB" Font-Size="XX-Large" Text="Instructors:"></asp:Label>
    <br />
    
    <br />
    <asp:GridView ID="InstructorGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="KarateSchoolInstructor" ForeColor="Black" GridLines="Horizontal" Height="189px" Width="643px"
        OnRowDeleting="InstructorGridView_RowDeleting" DataKeys="InstructorID">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="InstructorFirstName" HeaderText="First Name" SortExpression="InstructorFirstName" />
            <asp:BoundField DataField="InstructorLastName" HeaderText="Last Name" SortExpression="InstructorLastName" />
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
    <asp:SqlDataSource ID="KarateSchoolInstructor" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString2 %>" SelectCommand="SELECT [InstructorFirstName], [InstructorLastName] FROM [Instructor]"></asp:SqlDataSource>
    <br />
    <p>
        <strong>Add New Instructor</strong></p>
    <p>
        First Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtInstrFirstName" runat="server"></asp:TextBox>
    </p>
    <p>
        Last Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtInstrLastName" runat="server"></asp:TextBox>
    </p>
    <p>
        Phone Number&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtInstrPhoneNum" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="AddInstructorBtn" runat="server" OnClick="AddInstructorBtn_Click1" Text="Add" />
    </p>
</asp:Content>
