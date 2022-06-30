<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YeniYazarEkle.aspx.cs" Inherits="KOP.YeniYazarEkle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href ="css/style.css" />
 </head>
<body>
    <form id="form1" runat="server">
        <div>
      <%--  Kütüphaneye yeni yazar kaydı ekleme--%>
            <table width:%25 cellspacing="0" cellpadding="0" class="style-table">
                <tr>
                    <th colspan ="2">
                        Yeni Yazar Kaydı
                    </th>
                </tr>
                <tr>
                    <td>AD</td>
                    <td>
                        <asp:TextBox ID ="txtYazarAd" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>SOYAD</td>
                    <td>
                        <asp:TextBox ID="txtYazarSoyad" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan ="2">
                        <asp:Button runat="server" ID="btnYazarKaydet" Text="Yeni Yazarı Kaydet"  OnClick="btnYazarKaydet_Click" />
                        <asp:Button runat="server" ID="btnIptal" Text="İptal" Visible="false" OnClick="btnIptal_Click" />
                    </th>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblUyarıYazar" runat="server"></asp:Label>
                    </td>
                </tr>

            </table>

        </div>
    </form>
</body>
</html>