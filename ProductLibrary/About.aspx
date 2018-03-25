<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ProductLibrary.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p class="MsoNormal">
        Build a small application that stores and updates product information. The application should list products in the catalog and allow for edit, insert, and archive of products. The default view of the product list should hide the archived products.<o:p></o:p></p>
    <p class="MsoNormal">
        <o:p>&nbsp;</o:p></p>
    <p class="MsoNormal">
        A product is made up of:<o:p></o:p></p>
    <p class="MsoNormal">
        * Number<o:p></o:p></p>
    <p class="MsoNormal">
        * Description<o:p></o:p></p>
    <p class="MsoNormal">
        * Price<o:p></o:p></p>
    <p class="MsoNormal">
        <o:p>&nbsp;</o:p></p>
    <p class="MsoNormal">
        Use the following libraries/patterns:<o:p></o:p></p>
    <p class="MsoNormal">
        * jQuery<o:p></o:p></p>
    <p class="MsoNormal">
        <o:p>Used when you try to enter data into a field but have bad data. </o:p>
    </p>
    <p class="MsoNormal">
        * Web API controllers (c#)<o:p> The Edit page has an API URL field You can expand this to allow direct edits if needed but will bring you to a product based on the DB id</o:p></p>
    <p class="MsoNormal">
        * Repository pattern<o:p> -- Database class</o:p></p>
    <p class="MsoNormal">
        * Entity Framework<o:p> -- Added an example on the product add button </o:p>
    </p>
    <p class="MsoNormal">
        Optional: Angular JS<o:p></o:p></p>
    <p class="MsoNormal">
        <o:p>&nbsp;</o:p></p>
    <p class="MsoNormal">
        Try to limit the use of templates as this is to evaluate your effectiveness writing code.<o:p></o:p></p>
    <p>&nbsp;</p>
</asp:Content>
