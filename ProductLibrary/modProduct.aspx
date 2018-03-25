<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modProduct.aspx.cs" Inherits="ProductLibrary.modProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="modPanel" runat ="server" HorizontalAlign="left">
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
        Name: <asp:TextBox ID="tbName" runat ="server" ClientIDMode="Static"></asp:TextBox> <br />
        Description: <asp:TextBox ID="tbDescription" runat ="server" ClientIDMode="Static"></asp:TextBox> <br />
        Price: <asp:TextBox ID="tbPrice" runat ="server" ClientIDMode="Static"></asp:TextBox> <br />
        <asp:Checkbox ID="activeCB" runat ="server" ClientIDMode="Static" Text="Active" TextAlign="Left" Checked="true"> </asp:Checkbox> <br />
        <asp:Button ID="btnSubmit" runat="server" ClientIDMode="Static" Text="Submit" OnClick="btnSubmit_Click"/>
    </asp:Panel>

</asp:Content>
