<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CommonControls.aspx.cs" Inherits="WebApp.SamplePages.CommonControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 text-center">
            <h1>Common Web Form Controls and using event driven logic</h1>
        </div>
    </div>
    <%-- TextBox --%>
    <div class="row">
        <div class="col-md-6 text-right">
            <asp:Label ID="Label1" runat="server" 
                Text="Enter a selection choice 1 to 4:"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="NumberChoice" runat="server"
                width="50px" Height="30px"
                ToolTip="Enter a number from 1 to 4:"
                placeholder="1"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="SubmitNumberChoice" runat="server" 
                Text="Submit Number Choice" CssClass="btn btn-success"/>
        </div>
    </div>
     <%-- Radiobuttons --%>
    <div class="row">
        <div class="col-md-6 text-right">
            <asp:Label ID="Label2" runat="server" 
                Text="RadioButtons of choice:"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:RadioButtonList ID="RadioButtonListChoice" runat="server">
                <asp:ListItem Value="1">COMP1008</asp:ListItem>
                <asp:ListItem Value="2">CPSC1517</asp:ListItem>
                <asp:ListItem Value="3">DMIT1508</asp:ListItem>
                <asp:ListItem Value="4">DMIT2018</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
     <%-- Checkbox --%>
    <div class="row">
        <div class="col-md-6 text-right">
            <asp:Label ID="Label3" runat="server" 
                Text="CheckBox of Choice:"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:CheckBox ID="ChecBoxChoice" runat="server" 
                text="Checked if a programming language"/>
        </div>
    </div>
     <%-- Literal/Label --%>
    <div class="row">
        <div class="col-md-6 text-right">
            <asp:Literal ID="Literal1" runat="server"
                text="Read only display using a label"></asp:Literal>
        </div>
        <div class="col-md-6">
            <asp:Label ID="DisplayReadonly" runat="server"></asp:Label>
        </div>
    </div>
     <%-- Dropdownlist --%>
    <div class="row">
        <div class="col-md-6 text-right">
            <asp:Label ID="Label4" runat="server" 
                Text="DDL collection:"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:DropDownList ID="CollecionList" runat="server">

            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:LinkButton ID="LinkButtonChoice" runat="server">Submit Collection Choice</asp:LinkButton>
        </div>
    </div>
     <%--  Output are for messages--%>
    <div class="row">
        <div class="col-md-12 text-center">
            <asp:Label ID="MessageLabel" runat="server">

            </asp:Label>
        </div>
    </div>
</asp:Content>
