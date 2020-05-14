<%@ Page Title="Inventory Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Inventory._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style=”color:#00f3ff”>
        <h1 style=”background-color:#00f3ff”>Inventory Management</h1>
        <p class="lead">This is an application created by R & G to manage a inventory for a company.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Add User</h2>
<%--            TODO: ADD Security Measures--%>
            <div class="row">
                <div class="col-md-2">
                    <p>Username:</p>
                
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="usernametb" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <p>Password:</p>
                </div>
                <div class="col-md-2">
                    <asp:TextBox TextMode="Password" ID="passwordtb" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <asp:Button ID="adduserbutton" runat="server" Text="Add User" OnClick="AddNewUser_Click" />
            </div>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
