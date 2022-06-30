<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Islemler.aspx.cs" Inherits="KOP.Islemler" %>

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
                    <td>UYE_AD</td>
                    <td>
                        <asp:DropDownList ID="ddlUYE_AD" runat="server"></asp:DropDownList>
                       
                    </td>
                </tr>
                <tr>
                    <td>KITAP_ADI</td>
                    <td>
                        <asp:TextBox ID="txtKITAP_ADI" runat="server" Enabled="false"   ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>VERİLME TARİHİ</td>
                    <td>
                        <asp:TextBox ID="txtVTarih" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>TESLİM TARİHİ</td>
                    <td>
                        <asp:TextBox ID="txtTTarih" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td> 
                    <asp:Button ID="btnIslemler" Text="İşlem Kaydı" runat="server" OnClick="btnIslemler_Click"/>
                        <asp:Button ID="btnIptal" Text="İptal" runat="server" Visible="false" OnClick="btnIptal_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnIslemSorgu" Text="Sorgula" runat="server"  OnClick="btnIslemSorgu_Click"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblUyariIslemler" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdViewUyeninKitaplari" runat="server"></asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdViewGecikme" runat="server"></asp:GridView>
                    </td>
                </tr>

            </table>


        </div>
        <asp:hiddenfield id="hfKITAP_ID"
              value="0" 
              runat="server"/>
    </form>
</body>
</html>
