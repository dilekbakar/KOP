<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGirisi.aspx.cs" Inherits="KOP.AdminGirisi" %>

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
          <%--  Kütüphane sistemine admin girisi--%>

           <table  class ="style-table" >
               <tr>
                   <th colspan="2">
                       Admin Girişi
                   </th>
               </tr>
               <tr>
                   <td>KULLANICI ADI</td>
                   <td>
                       <asp:TextBox ID="txtKullaniciAdi" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>ŞİFRE</td>
                   <td>
                       <asp:TextBox type="password" name="passAdmin" ID="txtSifre" runat ="server"></asp:TextBox>
                   </td>
               </tr>
              
           <%--    <tr>
                   <td>YETKİ</td>
                   <td>
                       <asp:TextBox ID="txtYetki" placeholder="Yönetici,Görevli vb..." runat="server"></asp:TextBox>
                   </td>
               </tr>--%>

            <%--   <tr>
                   <td>YETKİ</td>
                   <td>
                       <label>
                           <input type="checkbox" name="yetki" id="cbyetki" value="0" />Yönetici
                       </label>
                       <label>
                           <input type="checkbox" name="yetki" id="chckbyetki" value="1" />Görevli
                       </label>
                   </td>
               </tr>--%>

         <%--      <tr>
                   <td>YETKİ</td>
                   <td>
                       
                       <input type="radio" name="rdYetki" id="rdioYonetici" value="0" />Yönetici 
                      
                       <input type="radio" name="rdYetki" id="rdioGorevli" value="1" />Görevli
                      
                   </td>
               </tr>--%>




               <tr>
                   <th colspan="2">
                       <asp:Button runat="server" ID="btnAdminGiris" Text="Admin Girişi"   OnClick="btnAdminGiris_Click"  />
                   </th>
               </tr>
               <tr>
                   <td colspan="2">
                       <asp:Label ID="lblAdminUyari" runat="server"></asp:Label>
                   </td>
               </tr>

           </table>
        </div>
    </form>
</body>
</html>