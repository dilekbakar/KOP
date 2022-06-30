<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IslemKayitSil.aspx.cs" Inherits="KOP.IslemKayitSil" %>

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
                    <td colspan="2">İŞLEM SİL
                    </td>
                </tr>
                <tr>
                    <td>UYE ADI/TC</td>
                    <td>
                        <asp:TextBox ID="txtUYE_AD" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnIslemAra" Text="İşlem Ara" runat="server" OnClick="btnIslemAra_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblUyariIslemSil" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdViewIslemAra" runat="server"  >
                            <Columns>
                                 <asp:HyperLinkField HeaderText="Sil" DataTextField="UYE_AD" DataNavigateUrlFields="ID" SortExpression="ID"
                                    DataNavigateUrlFormatString="~/IslemSil.aspx?id={0}"></asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
