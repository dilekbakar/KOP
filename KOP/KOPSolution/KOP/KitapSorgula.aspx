<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KitapSorgula.aspx.cs" Inherits="KOP.KitapSorgula" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="style-table">
                <tr>
                    <td colspan="2">Kitap Sorgulama
                    </td>
                </tr>
                <tr>
                    <td>KİTAP ADI</td>
                    <td>
                        <asp:TextBox ID="txtSorguKitapAdi" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>YAZAR ADI</td>
                    <td>
                        <asp:TextBox ID="txtSorguYazar" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>ISBN</td>
                    <td>
                        <asp:TextBox ID="txtSorguIsbn" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSorgu" Text="Sorgula" runat="server" OnClick="btnSorgu_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblSorgu" runat="server"></asp:Label>

                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:GridView class="style-table" ID="grdViewSorgu" runat="server">
                            <Columns>
                                <asp:HyperLinkField HeaderText="Kitap Seç" DataTextField="KITAP_ADI" DataNavigateUrlFields="ID" SortExpression="ID"
                                    DataNavigateUrlFormatString="~/Islemler.aspx?id={0}"></asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
