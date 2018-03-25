<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProductLibrary._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">
                $(function () {
                    $('#btnSubmit').click(function () {
                        if ($('#tbName').val() == '') {
                            alert('The Name field cannot be blank');
                        }
                        if ($('#tbDescription').val() == '') {
                            alert('The Description field cannot be blank');
                        }
                        if ($('#tbPrice').val() == '') {
                            alert('The Price field cannot be blank');
                        }
                    });
                });
    </script>

    <div class="jumbotron">
        <h1>Simple Product Catalog</h1>
        <p class="lead">This UI will show you the products already in the system and give you the ability to modify them. </p>
        <asp:Button ID="addProductBtn" runat="server" Text="Add Product" OnClick="addProductBtn_Click" />
        <asp:Panel ID="addProductPanel" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="tbName" runat="server" ClientIDMode="Static"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Description:"></asp:Label>
            <asp:TextBox ID="tbDescription" runat="server" ClientIDMode="Static"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Price:"></asp:Label>
            <asp:TextBox ID="tbPrice" runat="server" ClientIDMode="Static"></asp:TextBox>
            <br />
            <asp:CheckBox ID="cbActive" runat="server" OnCheckedChanged="cbActive_CheckedChanged" Text="Active:" TextAlign="Left" Checked="True" />
            <br />
            <asp:Button ID="btnSubmit" runat="server" ClientIDMode="Static" Text="Submit" OnClick="btnSubmit_Click"/>
            </asp:Panel>
    </div>


    <asp:Panel ID="productList" runat ="server">
        <h1>Products:</h1>
    </asp:Panel>
   

</asp:Content>
