<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KitapKaydi.aspx.cs" Inherits="KOP.KitapKaydi" %>

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
                    <th colspan="2">Kitap Kaydı
                    </th>
                </tr>
                <tr>
                    <td>ISBN
                    </td>
                    <td>
                        <asp:TextBox ID="txtIsbn" runat="server"></asp:TextBox>
                   <%--   Validation controls ile ISBN kodunu girlmesi zorunlu alan yaptık.--%>
                        <asp:RequiredFieldValidator ControlToValidate="txtIsbn" ErrorMessage="Isbn Kodunu Boş Geçemezsiniz!" runat="server"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>KİTAP ADI
                    </td>
                    <td>
                        <asp:TextBox ID="txtKitapAdi" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>TÜR
                    </td>
                    <td>

                        <asp:DropDownList ID="ddlTur" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>YAZAR
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlYazar" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>ADET
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdet" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>SAYFA SAYISI
                    </td>
                    <td>
                        <asp:TextBox ID="txtSayfaSayisi" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan="2">
                        <%--Güncelle butonunu görünür yaptık,diğerlerini pasif durumda bıraktık.--%>
                        <asp:Button ID="btnKitap" Text="Kitabı Kaydet" runat="server" OnClick="btnKitap_Click"   /> 
                        <asp:Button ID="btnKitapGuncelle" Text="Kitabı Güncelle" runat="server" Visible="false" OnClick="btnKitapGuncelle_Click" />
                        <asp:Button ID="btnIptal" Text="Iptal" runat="server" Visible="false" OnClick="btnIptal_Click" />
                    </th>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblKitapUyari" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                   <%-- Veri listelemek için gridview kullandık.Son 15 kaydı listelemek için.--%>
                    <td colspan="2"><asp:GridView class="style-table" ID="grdViewVeriListele" runat="server"></asp:GridView>
                    </td>
                </tr>


            </table>
        </div>
    </form>
</body>
</html>
