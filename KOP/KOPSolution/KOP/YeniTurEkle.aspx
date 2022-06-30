<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YeniTurEkle.aspx.cs" Inherits="KOP.YeniTurEkle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--Kütüphaneye yeni Tür Ekleme--%>
            <table width:%25 cellpadding="0" cellspacing="0" class="style-table">
                <tr>
                    <th colspan="2">
                        Yeni Tür Ekle
                    </th>
                </tr>
                <tr>
                    <td>TÜR ADI</td>
                    <td>
                        <asp:TextBox ID="txtTurAdi" runat="server" ></asp:TextBox>  
                    </td>
                </tr>

                <%--<tr>
                    <td>TÜR ADI</td>
                    <td>
                        <label>
                            <input type="checkbox" name="cbTur" id="cbKorku" value="0" />Korku
                        </label>
                         <label>
                            <input type="checkbox" name="cbTur" id="cbGerilim" value="1" />Gerilim
                        </label>
                         <label>
                            <input type="checkbox" name="cbTur" id="cbPsikoloji" value="2" />Psikoloji
                        </label>
                         <label>
                            <input type="checkbox" name="cbTur" id="cbTarih" value="3" />Tarih
                        </label>
                         <label>
                            <input type="checkbox" name="cbTur" id="cbKisiselGelisim" value="4" />Kişisel Gelişim
                        </label>
                         <label>
                            <input type="checkbox" name="cbTur" id="cbBilimKurgu" value="5" />Bilim-Kurgu
                        </label>
                         <label>
                            <input type="checkbox" name="cbTur" id="cbFantastik" value="6" />Fantastik
                        </label>


                    </td>
                </tr>--%>



                <tr>
                    <th colspan="2">
                        <asp:Button runat="server" ID ="btnTurEkle"  Text="Yeni Tür Ekle"  OnClick="btnTurEkle_Click"/>
                        <asp:Button runat="server" ID="btnIptal" Text="İptal" Visible="false" OnClick="btnIptal_Click" />
                    </th>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblTurUyari" runat="server"></asp:Label>
                    </td>
                </tr>


            </table>
        </div>
    </form>
</body>
</html>
