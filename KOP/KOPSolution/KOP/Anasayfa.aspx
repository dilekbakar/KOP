<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="KOP.Anasayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div >
            
           <nav class="anaMenu"> 
             <ul>

               <li ><a href="Anasayfa.aspx">Anasayfa</a></li>
                <li><a href="#">Kayıt/Güncelleme</a>
                 <ul> 
                     <li><a href="KitapKaydi.aspx">Kitap Kayıt/Güncelleme</a></li>
                     <li><a href ="UyeKaydet.aspx" >Üye Kayıt</a></li>
                     <li><a href="YeniYazarEkle.aspx">Yazar Kayıt</a></li>
                     <li><a href="YeniTurEkle.aspx">Tür Kayıt</a></li>
                     
                 </ul>
                </li>
                 <li><a href="#">Sorgulama İşlemleri</a>
                     <ul>
                       <li><a href ="KitapSorgula.aspx">Yeni İşlem Kaydı</a></li>
                        <li><a href ="IslemKayitSil.aspx">İşlem Silme</a></li>
                  
                    
                     </ul>
                 </li>
            </ul>
        
         </nav>
           
        </div>
    </form>
</body>
</html>
