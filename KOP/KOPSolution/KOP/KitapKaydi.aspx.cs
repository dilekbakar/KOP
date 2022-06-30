using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace KOP
{
    public partial class KitapKaydi : System.Web.UI.Page
    {
        //En başta bağlantımızı kurduk.
        string connectionString = @"Server=DESKTOP-8BBA3PH\SQLEXPRESS01;Database=kutuphanedb;User Id=sa; Password =123456 ; ";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Eğer kullanıcıya atadığımız bilgiler boş olursa ve direk linkten bağlanmaya çalışan olursa yetkisiz girişe yönlendiriyoruz.
            //if (Session["KULLANICI"] == null)
            //{
            //    Response.Redirect("YetkisizGiris.aspx");
            //}

            if (!IsPostBack)
            {
                DdlyeYazarYukle();
                DdlyeTurEkle();
                VeriListele();
            }
        }




        private void VeriListele()  //Void geriye değer döndürmeyen metotlar için kullanılır.Public, Protected ve Private tanımlamalarına ise erişim belirleyiciler(Access Modifiers) denir. Public olarak tanımlanan öğeye kod bloğunun içinden ve dışından erişebilir, yani her yerden ulaşılabilir denilebilir. 
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {


                    string sorgu = "select TOP 15 * from Kitaplar order by ID desc"; //ID numarasına göre sondan listeleyip son 15 kaydı görüntüledik.
                    SqlCommand komut = new SqlCommand(sorgu, baglanti); //komut adında nesne tanımlamak için sqlcommand kullandık.
                    if (baglanti.State == System.Data.ConnectionState.Closed)//Bağlantının açık olup olmadığını kontrol ediyoruz.
                    {
                        baglanti.Open();
                    }
                    SqlDataReader veri = komut.ExecuteReader(); //Veri okuyacağımız için datareader kullandık.

                    grdViewVeriListele.DataSource = veri; //SQL deki verilere ulaşmak için datasource kullanıyoruz.
                    grdViewVeriListele.DataBind();  // DataBind verileri DataSourceye bağlamak ,yerleştirmek için kullandık.


                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }



                }




            }
            catch (Exception ex)
            {

                lblKitapUyari.Text = ex.Message.ToString();
            }
        }

        private void DdlyeTurEkle() //Yine geriye değer döndürmeye bir fonksiyon oluşturuyoruz.DropDownList'e veri tabanında kayıtlı olan türleri çekiyoruz. 
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(connectionString)) //bağlanti isimli bir nesne tanımlıyoruz.Connection string ile bağlantıyı yapıyoruz.
                {
                    string sorgu = "select * from Turler order by TUR_ADI";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti); //komut isimli bir nesne tanımlayark komut oluşturduk.
                    if (baglanti.State == System.Data.ConnectionState.Closed)//Bağlantının açık olup olmadığını kontrol ediyoruz.
                    {
                        baglanti.Open();
                    }
                    SqlDataReader veri = komut.ExecuteReader();
                    while (veri.Read()) //Veriyi okuduğu sürece while döngüsü devam edecek.Okuyamadığı zaman döngü sonlanacak.
                    {
                        ListItem lTur = new ListItem(); //Bir liste oluşturduk.
                        lTur.Text = veri["TUR_ADI"].ToString(); //Bu listeye tür adlarını ekledik.
                        lTur.Value = veri["ID"].ToString();
                        ddlTur.Items.Add(lTur); //listItem a yüklediğimiz verileri ddl ye kaydettik.
                    }
                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                lblKitapUyari.Text = ex.Message.ToString();
            }
        }

        private void DdlyeYazarYukle()
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    string sql = "select * from Yazarlar order by YAZAR_AD";
                    SqlCommand komut = new SqlCommand(sql, baglanti);
                    if (baglanti.State == System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    SqlDataReader veri = komut.ExecuteReader();
                    while (veri.Read())
                    {
                        //ddlYazar.Items.Insert(Convert.ToInt32( veri["ID"]),new ListItem(veri["YAZAR_AD"].ToString(),veri["ID"].ToString()));
                        ListItem l = new ListItem();
                        l.Text = veri["YAZAR_AD"] + " " + veri["YAZAR_SOYAD"];
                        l.Value = veri["ID"].ToString();
                        ddlYazar.Items.Add(l); //aynı şekilde liste oluşturduk.okunan verileri yazar ad soyad kısmında tuttuk daha sonra ddlye itemleri ekledik.
                    }

                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                }

            }
            catch (Exception ex)
            {

                lblKitapUyari.Text = ex.Message.ToString();
            }
        }

        protected void btnKitap_Click(object sender, EventArgs e)
        {
            KitapEkleGuncelle(); 
            VeriListele(); //tıkladığımızda alttaki veri tablosu güncellenecek.


        }

        private void KitapEkleGuncelle() //Kitabın kayıtlı olup olmadığını kontrol ettık bu fonksiyonla.
        {
            if (KitapKayitliMi() == false) //Kitap kayıtlı değilse kaydet.
            {
                KitabiKaydet();


            }
            else
            {
                //Kayıtlı ise güncellemek isteyip istemediğini sor.Eğer hala güncellemek istiyorsa aktif hale gelen güncelle butonuna tıklayıp güncelleyebilir.İstemiyorsa iptal e basıp Kitap Kaydet butonunu tekrardan aktif hale getir.
                lblKitapUyari.Text = "Kayıt zaten var.Güncellemek istediğinizden emin misiniz?"; 
                btnKitapGuncelle.Visible = true;
                btnKitap.Visible = false;
                btnIptal.Visible = true;

            }
        }

        private void KitabiGuncelle() //Güncelleme fonksiyonunun içini dolduruyoruz.
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    //Bağlantıyı kurduktan sonra güncelleme butonuna tıkladıktan sonra aynı isbn kodundaki veryi , yeni girilen bilgilerle günceller.
                    string sql = "update Kitaplar set KITAP_ADI=@KITAP_ADI,TUR=@TUR,YAZAR_ID=@YAZAR_ID,ADET=@ADET,SAYFA_SAYISI=@SAYFA_SAYISI where ISBN=@ISBN";
                    SqlCommand komut = new SqlCommand(sql, baglanti);

                    komut.Parameters.AddWithValue("@KITAP_ADI", txtKitapAdi.Text);
                    komut.Parameters.AddWithValue("@TUR", ddlTur.SelectedItem.Value);
                    komut.Parameters.AddWithValue("@YAZAR_ID", ddlYazar.SelectedItem.Value);
                    komut.Parameters.AddWithValue("@ADET", txtAdet.Text);
                    komut.Parameters.AddWithValue("@SAYFA_SAYISI", txtSayfaSayisi.Text);
                    komut.Parameters.AddWithValue("@ISBN", txtIsbn.Text);
                    if (baglanti.State == System.Data.ConnectionState.Closed) 
                    {
                        baglanti.Open();
                    }
                    komut.ExecuteNonQuery(); //Veri kaydedeceğimiz için ExecuteNonQuery kullanıyoruz.
                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    lblKitapUyari.Text = txtKitapAdi.Text + " Kitabı güncellendi."; //Örneğin Fobi kitabı güncellendi.
                }
            }
            catch (Exception ex) //Bir hata varsa yakalıyor ve uyarı labeline yazıyor.
            {

                lblKitapUyari.Text = ex.Message.ToString();
            }
        }

        private void KitabiKaydet() //KAydetme fonksiyonunun içini dolduruyoruz.
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    //Burada normal veri kayıt işlemi olacak. Kitaplar tablosuna girilen verileri ekleyecek.
                    string sql = "insert into Kitaplar (ISBN,KITAP_ADI,TUR,YAZAR_ID,ADET,SAYFA_SAYISI) values (@ISBN,@KITAP_ADI,@TUR,@YAZAR_ID,@ADET,@SAYFA_SAYISI)";
                    SqlCommand komut = new SqlCommand(sql, baglanti);
                    komut.Parameters.AddWithValue("@ISBN", txtIsbn.Text);
                    komut.Parameters.AddWithValue("@KITAP_ADI", txtKitapAdi.Text);
                    komut.Parameters.AddWithValue("@TUR", ddlTur.SelectedItem.Value);
                    komut.Parameters.AddWithValue("@YAZAR_ID", ddlYazar.SelectedItem.Value);
                    komut.Parameters.AddWithValue("@ADET", txtAdet.Text);
                    komut.Parameters.AddWithValue("@SAYFA_SAYISI", txtSayfaSayisi.Text);
                    if (baglanti.State == System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    komut.ExecuteNonQuery();
                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    lblKitapUyari.Text = txtKitapAdi.Text + " Kitabı kaydedildi.";
                }
            }
            catch (Exception ex)
            {

                lblKitapUyari.Text = ex.Message.ToString();
            }
        }
        private bool KitapKayitliMi() //Kitabın kayıtlı olup olmadığını kontrol eden fonksiyon.
        {
            bool donenDeger = false; //Dönen değer isimli bir nesne tanımladık.
            try
            {
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    string sql = "select * from Kitaplar where ISBN=@ISBN"; //ISBN kodunu veri tabanından okuyup,girilen değeri isbn textboxuna yazıyor.
                    SqlCommand komut = new SqlCommand(sql, baglanti);
                    komut.Parameters.AddWithValue("@ISBN", txtIsbn.Text);
                    if (baglanti.State == System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read() && dr.GetValue(0) != DBNull.Value)//Burası eğer veri tabanından okunan değer null değilse dönendeğeri true döndürüyor.
                    {
                        donenDeger = true; //Okunan değer ile girilen değer eşitse kitap kayıtlı oluyor.
                    }
                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                lblKitapUyari.Text = ex.Message.ToString();
            }
            return donenDeger;
        }

        protected void btnKitapGuncelle_Click(object sender, EventArgs e)
        {
            KitabiGuncelle();
            ButonlariGuncelle(); //Güncellemeye tıklandığında KAydet butonunu aktif diğerlerini pasif yapacak.
            VeriListele();
        }

        protected void btnIptal_Click(object sender, EventArgs e) //İptal butonuna tıklandğında butonları güncelliyor.
        {
            ButonlariGuncelle();
        }
        private void ButonlariGuncelle() //Kaydet butonunu aktif diğerlerini pasif duruma getiriyor.
        {
            btnKitap.Visible = true;
            btnKitapGuncelle.Visible = false;
            btnIptal.Visible = false;
        }
    }
}