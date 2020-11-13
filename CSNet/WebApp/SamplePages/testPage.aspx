<%@ Page Title="Test Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testPage.aspx.cs" Inherits="WebApp.SamplePages.testPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Test page</h1>
    <blockquote>Sample of how you could possibly setup your project default page</blockquote>
    <div class="row">
        <div class="col-7">
            <%-- ERD diagram --%>
            <asp:Image ID="Image1" runat="server" />
        </div>
        <div class="col-5">
            <%-- Project description --%>
        </div>
    </div>
    <div class="row">
        <div class="col-7">
            <%-- class diagram --%>
        </div>
        <div class="col-5">
            <%-- Known bugs --%>
            <%-- SQL procedures --%>
        </div>
    </div>
</asp:Content>
