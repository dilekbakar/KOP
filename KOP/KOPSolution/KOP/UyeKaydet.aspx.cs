using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace KOP
{
    public partial class UyeKaydet : System.Web.UI.Page
    {
        string connectionString = @"Server=DESKTOP-8BBA3PH\SQLEXPRESS01;Database=kutuphanedb;User Id=sa; Password =123456 ; ";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Eğer kullanıcıya atadığımız bilgiler boş olursa ve direk linkten bağlanmaya çalışan olursa yetkisiz girişe yönlendiriyoruz.
            if (Session["KULLANICI"] == null)
            {
                Response.Redirect("YetkisizGiris.aspx");
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            //  EskiMethod();
            UyeEkleGuncelle();
        }
        private void UyeEkleGuncelle()
        {
            if (UyeKayitliMi() == false)
            {
                ParametreliVeriGirisi();
            }
            else
            {
                lblUyari.Text = "Uye Zaten kayıtlı.Bilgileri güncellemek istediğinizden emin misiniz?";
                btnEkle.Visible = false;
                btnGuncelle.Visible = true;
                btnIptal.Visible = true;
            }
        }

        private bool UyeKayitliMi()//Uyenin kayıtlı olup olmadığını kontrol ediyoruz.Eğer aynı tc ye sahip başka bir kayıt varsa üye zaten kayıtlıdır.
        {
            bool donendeger = false; //en başta donendegeri false tanımladık daha sonra tcler uyuşursa donendeger true olacak.
            try
            {
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    string sorgu = "select * from Uyeler where TC=@TC"; // girilen tc ile veri tabanından gelen tc değerinin eşleşip eşleşmediğini kontrol edeceğiz.
                    SqlCommand komut = new SqlCommand(sorgu,baglanti);
                    komut.Parameters.AddWithValue("@TC",txtTC.Text);
                    if (baglanti.State== System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    SqlDataReader dr = komut.ExecuteReader();

                    if (dr.Read() && dr.GetValue(0) != DBNull.Value)//eğer okunan değer ve gelen değer eşitse...
                    {
                        donendeger = true;  //...donendeger true oluyor.Yani üye kayıtlı oluyor.
                    }
                    if (baglanti.State== System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }

                }

            }
            catch (Exception ex)
            {

                lblUyari.Text = ex.Message.ToString();
            }
            return donendeger;
        }

        private void UyeGuncelle() //Aynı tc ye ait bir üye varsa onu güncelleyecek.
        {
            //Parametre kullanılacak.try=hata ayıklama ve yakalamada kullanılacak.
            try
            {
              
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    string sorgu = "update Uyeler set TC=@TC,AD=@AD,SOYAD=@SOYAD,EPOSTA=@EPOSTA,TELEFON=@TELEFON,ADRES=@ADRES WHERE TC=@TC";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@TC", txtTC.Text);
                    komut.Parameters.AddWithValue("@AD", txtAd.Text);
                    komut.Parameters.AddWithValue("@SOYAD", txtSoyad.Text);
                    komut.Parameters.AddWithValue("@EPOSTA", txtEposta.Text);
                    komut.Parameters.AddWithValue("@TELEFON", txtTelefon.Text);
                    komut.Parameters.AddWithValue("@ADRES", txtAdres.Text);
                    //Baglantının açık ya da kapalı olma durumuna bakarak bağlantıyı açıp kapatacağız.
                    if (baglanti.State == System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    komut.ExecuteNonQuery();
                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    lblUyari.Text = "Üye Bilgileri Güncellendi.";
                }
            }
            catch (Exception ex)
            {

                lblUyari.Text = ex.Message.ToString();
            }

        }
       

        private void ParametreliVeriGirisi()
        {
            //Parametre kullanılacak.try=hata ayıklama ve yakalamada kullanılacak.
            try
            {
                string connectionString = @"Server=DESKTOP-8BBA3PH\SQLEXPRESS01;Database=kutuphanedb;User Id=sa; Password =123456 ; ";
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    string sorgu = "insert into Uyeler (TC,AD,SOYAD,EPOSTA,TELEFON,ADRES) values (@TC,@AD,@SOYAD,@EPOSTA,@TELEFON,@ADRES)";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@TC", txtTC.Text);
                    komut.Parameters.AddWithValue("@AD", txtAd.Text);
                    komut.Parameters.AddWithValue("@SOYAD", txtSoyad.Text);
                    komut.Parameters.AddWithValue("@EPOSTA", txtEposta.Text);
                    komut.Parameters.AddWithValue("@TELEFON", txtTelefon.Text);
                    komut.Parameters.AddWithValue("@ADRES", txtAdres.Text);
                    //Baglantının açık ya da kapalı olma durumuna bakarak bağlantıyı açıp kapatacağız.
                    if (baglanti.State== System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    komut.ExecuteNonQuery();
                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    lblUyari.Text = "Kaydınız Alınmıştır";
                }
            }
            catch (Exception ex)
            {

                lblUyari.Text = ex.Message.ToString();
            }
        }

        private void EskiMethod()
        {
            //Yanlış metod
            SqlConnection baglanti = new SqlConnection(@"Server=DESKTOP-8BBA3PH\SQLEXPRESS01;Database=kutuphanedb;User Id=sa; Password =123456 ; ");
            string sorgu = "insert into Uyeler (TC,AD,SOYAD,EPOSTA,TELEFON,ADRES) values (" + "'" + txtTC.Text + "'," + "'" + txtAd.Text + "'," + "'" + txtSoyad.Text + "'," + "'" + txtEposta.Text + "'," + "'" + txtTelefon.Text + "'," + "'" + txtAdres.Text + "'" + ")";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            lblUyari.Text = "Kayıt Alındı.";
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            UyeGuncelle();
            ButonGuncelle(); //Üyeyi güncelledikten sonra tekrar butonları güncelliyor.
        }

        protected void btnIptal_Click(object sender, EventArgs e)
        {
            ButonGuncelle();

        }
        private void ButonGuncelle()
        {
            btnEkle.Visible = true;
            btnGuncelle.Visible = false;
            btnIptal.Visible = false;
        }
    }
}