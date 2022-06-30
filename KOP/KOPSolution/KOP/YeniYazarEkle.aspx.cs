using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace KOP
{
    public partial class YeniYazarEkle : System.Web.UI.Page
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

        protected void btnYazarKaydet_Click(object sender, EventArgs e)
        {
            YazarEkleIptal();
        }
        private void YazarEkleIptal()
        {
            if (YazarKayitliMi()== false)
            {
                ParametreliVeriGirisi();
            }
            else
            {
                //Kayıtlı ise tekrar kaydetmek isteyip istemediğini soruyor.İstemiyorsa sayfayı tekrar yükleyecek.İki tane aynı isimli yazar olabilir.
                lblUyarıYazar.Text = "Yazar zaten kayıtlı.Aynı isimde bir yazarı tekrardan eklemek istediğinize emin misiniz?";
                btnYazarKaydet.Visible = true;
                btnIptal.Visible = true;
            }
        }

        private bool YazarKayitliMi()
        {
            bool donendeger = false;
            try
            {
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    string sorgu = "select * from Yazarlar where YAZAR_AD=@YAZAR_AD AND YAZAR_SOYAD=@YAZAR_SOYAD";
                    SqlCommand komut = new SqlCommand(sorgu,baglanti);
                    komut.Parameters.AddWithValue("@YAZAR_AD", txtYazarAd.Text);
                    komut.Parameters.AddWithValue("@YAZAR_SOYAD", txtYazarSoyad.Text);
                    if (baglanti.State== System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read() && dr.GetValue(0) != DBNull.Value)
                    {
                        donendeger = true;
                    }
                    if (baglanti.State== System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                lblUyarıYazar.Text = ex.Message.ToString();
            }
            return donendeger;

        }


        private void ParametreliVeriGirisi()
        {
            try //try catch ile hata yakalama sistemi .Hata yakalarsa label a yazdırıyor hatayı.
            {

                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    string sorgu = "insert into Yazarlar (YAZAR_AD,YAZAR_SOYAD) values (@YAZAR_AD,@YAZAR_SOYAD)";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@YAZAR_AD", txtYazarAd.Text);
                    komut.Parameters.AddWithValue("@YAZAR_SOYAD", txtYazarSoyad.Text);

                    if (baglanti.State == System.Data.ConnectionState.Closed) //Bağlantının açık olup olmadığını kontrol eder.
                    {
                        baglanti.Open();
                    }
                    komut.ExecuteNonQuery(); //Veri girişi yapacağımız için ExecuteNonQuery komutunu veriyoruz.
                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    lblUyarıYazar.Text = "Yazar Kayıt işlemi Başarılı.";
                }
            }
            catch (Exception ex)
            {
                lblUyarıYazar.Text = ex.Message.ToString();

            }



        }



        protected void btnIptal_Click(object sender, EventArgs e)
        {
            Response.Redirect("YeniYazarEkle.aspx");
        }
    }
}