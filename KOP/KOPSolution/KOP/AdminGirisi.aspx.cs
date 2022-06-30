using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace KOP
{
    public partial class AdminGirisi : System.Web.UI.Page
    {
        string connectionString = @"Server=DESKTOP-8BBA3PH\SQLEXPRESS01;Database=kutuphanedb;User Id=sa; Password =123456 ; ";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdminGiris_Click(object sender, EventArgs e)
        {
            // ParametreliVeriGirisi();
            //   VeriTabansizKullaniciKontrolu();

            VeriTabanliKullaniciKontrolu();
        }
        private void VeriTabanliKullaniciKontrolu()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString) )
                {
                    string sql = "select * from Admindb where KULLANICI_AD=@KULLANICI_AD ";
                    SqlCommand kmt = new SqlCommand(sql, cnn);
                    kmt.Parameters.AddWithValue("@KULLANICI_AD",txtKullaniciAdi.Text);
                    if (cnn.State==System.Data.ConnectionState.Closed)
                    {
                        cnn.Open();
                    }
                    SqlDataReader veriTabanindanGelen = kmt.ExecuteReader(); //Veri okumak için datareader kullanıyoruz.
                    if (veriTabanindanGelen.Read() && veriTabanindanGelen.GetValue(0)!=DBNull.Value) //veri tabanından gelen veri null değilse...
                    {
                        string kullaniciAdi = veriTabanindanGelen["KULLANICI_AD"].ToString();  //veri tabanından gelen veriyi kullaniciAdi nesnesine atıyoruz.
                        string sifre = veriTabanindanGelen["SIFRE"].ToString(); //Aynı şekilde şifreyi de.
                        if (kullaniciAdi == txtKullaniciAdi.Text && sifre == txtSifre.Text) //Kullanıcı adı VE şifre veri tabanından gelenle aynıysa...
                        {
                            Session["KULLANICI"] = txtKullaniciAdi.Text; //Kullanıcı isimli session nesnesine aktardık verileri.
                            Response.Redirect("Anasayfa.aspx"); //Anasayfaya yönlendirdik.
                        }
                        else
                        {
                            lblAdminUyari.Text = "Kullanıcı adınız ya da şifreniz yanlış."; //Yanlış girme durumunda verilen uyarı.
                        }
                    }
                    else
                    {
                        lblAdminUyari.Text = "Böyle bir kullanıcı yok.";
                    }
                    if (cnn.State==System.Data.ConnectionState.Open)
                    {
                        cnn.Close();
                    }

                }
            }
            catch (Exception ex)
            {

                lblAdminUyari.Text = ex.Message.ToString();
            }
        }
        private void VeriTabansizKullaniciKontrolu() //Veri tabanına bağlanmadan kendi verdiğimiz değerlere göre kontrol ediyor.
        {
            string kullaniciAdi = "admin";
            string sifre = "1234";

            if (kullaniciAdi==txtKullaniciAdi.Text && sifre==txtSifre.Text)
            {
                Session["KULLANICI"] = txtKullaniciAdi.Text;
                Response.Redirect("Anasayfa.aspx");
            }
            else
            {
                lblAdminUyari.Text = "Kullanıcı adınız ya da şifreniz yanlış.";
            }
        }

        private void ParametreliVeriGirisi()
        {
            try
            {
                
                using (SqlConnection baglanti=new SqlConnection(connectionString))
                {
                    string sorgu = "select KULLANICI_AD,SIFRE,ADI,YETKI from Admindb ";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@KULLANICI_AD", txtKullaniciAdi.Text);
                    komut.Parameters.AddWithValue("@SIFRE", txtSifre.Text);
                    //komut.Parameters.AddWithValue("@ADI", txtAd.Text);
                    //komut.Parameters.AddWithValue("@YETKI", kullaniciTipi.Value);
                    
                    //Baglantının açık olup olmadığını kontrol edeceğiz.
                    if (baglanti.State == System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                      
                    }
                   komut.ExecuteReader();
                    if (baglanti.State== System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                  
                    lblAdminUyari.Text = "Giriş Başarılı.";

                }

            }
            catch (Exception ex)
            {
                lblAdminUyari.Text = ex.Message.ToString();
                
            }




        }
    }
}