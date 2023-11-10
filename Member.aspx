<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="KarateSchoolProject.Member" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
            <h1>Welcome, <asp:Label ID="lblMemberName" runat="server" Text=""></asp:Label></h1>
            
           <asp:GridView ID="gvPayments" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
    <Columns>
        <asp:BoundField DataField="SectionName" HeaderText="Section Name" ItemStyle-CssClass="col-md-4" HeaderStyle-CssClass="col-md-4" />
        <asp:BoundField DataField="SectionStartDate" HeaderText="Section Start Date" ItemStyle-CssClass="col-md-4" HeaderStyle-CssClass="col-md-4" />
        <asp:BoundField DataField="InstructorName" HeaderText="Instructor Name" ItemStyle-CssClass="col-md-4" HeaderStyle-CssClass="col-md-4" />
        <asp:BoundField DataField="SectionFee" HeaderText="Section Fee" ItemStyle-CssClass="col-md-4" HeaderStyle-CssClass="col-md-4" />
    </Columns>
</asp:GridView>

        <h4>Total Fees: <asp:Label runat="server" ID="lblTotalFee"></asp:Label></h4>
        </div>

</asp:Content>
