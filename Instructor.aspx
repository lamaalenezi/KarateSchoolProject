<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instructor.aspx.cs" Inherits="KarateSchoolProject.Instructor1" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Welcome,
            <asp:Label ID="lblInstructorName" runat="server" Text=""></asp:Label></h1>

        <asp:GridView ID="gvSection" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="SectionName" HeaderText="Section Name" ItemStyle-CssClass="col-md-4" HeaderStyle-CssClass="col-md-4" />
                <asp:BoundField DataField="MemberName" HeaderText="Member Name" ItemStyle-CssClass="col-md-4" HeaderStyle-CssClass="col-md-4" />
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>
