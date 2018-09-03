<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExampleApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <p>Looks like we need to click the link below to trigger our MXAccess call - Clicking the link will load a new page which will log into MXAccess, then write a value to MyUDO.MyUDA and wait for the event to complete.</p>
        <p><a runat="server" href="~/GoGoGo">GoGoGo</a></p>
    </div>

</asp:Content>
