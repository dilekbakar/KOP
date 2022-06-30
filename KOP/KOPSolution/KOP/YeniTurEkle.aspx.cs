using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace KOP
{
    public partial class YeniTurEkle : System.Web.UI.Page
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

        protected void btnTurEkle_Click(object sender, EventArgs e)
        {
            TurEkleIptal();
        }
        private void TurEkleIptal()
        {
            if (TurKayitliMi()==false)
            {
                ParametreliVeriGirisi();
            }
            else
            {
                lblTurUyari.Text = "Eklemeye çalıştığınız tür zaten var.";
                btnTurEkle.Visible = false;
                btnIptal.Visible = true; //İki defa aynı türü eklemeye gerek olmadığı için direkt iptal diyoruz.
            }
        }

        private bool TurKayitliMi()
        {
            bool donenDeger = false;
            try
            {
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    string sorgu = "select * from Turler where TUR_ADI=@TUR_ADI";
                    SqlCommand komut = new SqlCommand(sorgu,baglanti);
                    komut.Parameters.AddWithValue("@TUR_ADI",txtTurAdi.Text);
                    if (baglanti.State==System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read() && dr.GetValue(0) != DBNull.Value)
                    {
                        donenDeger = true;
                    }
                    if (baglanti.State==System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                lblTurUyari.Text = ex.Message.ToString();
            }
            return donenDeger;
        }


        private void ParametreliVeriGirisi()
        {
            try
            {
                
                using(SqlConnection baglanti=new SqlConnection(connectionString))
                {
                    string sorgu = "insert into Turler (TUR_ADI) values ( @TUR_ADI)"; //Tabloya girilen tür adını ekleme.
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@TUR_ADI", txtTurAdi.Text);
                    //Baglantiyi kontrol ediyoruz.
                    if (baglanti.State== System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    komut.ExecuteNonQuery();
                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    lblTurUyari.Text = "Yeni Tür Eklendi.";

                }
              
            }
            catch (Exception ex)
            {

                lblTurUyari.Text = ex.Message.ToString();
            }


        }

        protected void btnIptal_Click(object sender, EventArgs e)
        {
            Response.Redirect("YeniTurEkle.aspx");
        }
    }
}