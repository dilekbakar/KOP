<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UyeKaydet.aspx.cs" Inherits="KOP.UyeKaydet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%-- Kütüphaneye üye kaydı ekranı--%>
            <table class="style-table">
                <tr>
                    <th colspan="2">
                        Yeni Üye Kaydı
                    </th>
                </tr>
                <tr>
                    <td>TC</td>
                    <td>
                        <asp:TextBox ID="txtTC" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>AD</td>
                    <td>
                        <asp:TextBox ID="txtAd" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>SOYAD</td>
                    <td>
                        <asp:TextBox ID ="txtSoyad" runat ="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>EPOSTA</td>
                    <td>
                        <asp:TextBox type="email" ID ="txtEposta" placeholder="ornek@gmail.com" runat ="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>TELEFON</td>
                    <td>
                        <asp:TextBox  ID="txtTelefon" placeholder="(5XX)XXX-XX-XX" runat  ="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>ADRES</td>
                    <td>
                        <asp:TextBox ID="txtAdres"  runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan="2">
                        <asp:Button runat="server" ID="btnEkle" Text="Yeni üyeyi Kaydet"  OnClick="btnEkle_Click"/>
                        <asp:Button runat="server" ID="btnGuncelle" Text="Bilgileri Güncelle" OnClick="btnGuncelle_Click" Visible="false" />
                        <asp:Button runat="server" ID="btnIptal" Text="İptal" OnClick="btnIptal_Click" Visible="false" />
                    </th>
                </tr>
                 <tr>
                    <td colspan="2">
                        <asp:Label ID="lblUyari" runat="server" ></asp:Label>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
