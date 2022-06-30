using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using KOP.App_Data;

namespace KOP
{
    public partial class IslemSil : System.Web.UI.Page
    {
        BaglantiYolu by = new BaglantiYolu();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Eğer kullanıcıya atadığımız bilgiler boş olursa ve direk linkten bağlanmaya çalışan olursa yetkisiz girişe yönlendiriyoruz.
            if (Session["KULLANICI"] == null)
            {
                Response.Redirect("YetkisizGiris.aspx");
            }
            if (!Page.IsPostBack)
            {
                hfUYE_AD.Value = Request.QueryString["ID"]; //ID değerini alıp ID değerine karşılık gelen değer yazdıracağız.
                hfKITAP_ADI.Value = Request.QueryString["ID"];
                hfVERILME_TAR.Value = Request.QueryString["ID"];
                hfTESLIM_TAR.Value = Request.QueryString["ID"];
                Yukle();
            }
        }

        protected void btnSIL_Click(object sender, EventArgs e)
        {
           
            KayitSil();
        }
        private void Yukle()
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(by.ConnectionString))
                {
                    string sorgu = "select * from Islemler where ID=@UYE_AD ";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("UYE_AD", hfUYE_AD.Value);
                    komut.Parameters.AddWithValue("KITAP_ADI", hfKITAP_ADI.Value);
                    komut.Parameters.AddWithValue("VERILME_TAR", hfTESLIM_TAR.Value);
                    komut.Parameters.AddWithValue("TESLIM_TAR", hfTESLIM_TAR.Value);
                    //Baglantının açık ya da kapalı olma durumuna bakarak bağlantıyı açıp kapatacağız.
                    if (baglanti.State == System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read()) //ID olarak aldığımız verileri stringe çevireceğiz.
                    {
                        txtUYE_AD.Text = dr["UYE_AD"].ToString();
                        txtKITAP_ADI.Text = dr["KITAP_ADI"].ToString();
                        txtVERILME_TAR.Text = dr["VERILME_TAR"].ToString();
                        txtTESLIM_TAR.Text = dr["TESLIM_TAR"].ToString();
                    }
                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }



                }

            }
            catch (Exception ex)
            {

                lblUyariSIL.Text = ex.Message.ToString();
            }




        }
        private void KayitSil()
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(by.ConnectionString))
                {
                    string sorgu = "DELETE  from Islemler where KITAP_ADI=@KITAP_ADI";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@UYE_AD", txtUYE_AD.Text);
                    komut.Parameters.AddWithValue("@KITAP_ADI", txtKITAP_ADI.Text);
                    komut.Parameters.AddWithValue("@VERILME_TAR", txtVERILME_TAR.Text);
                    komut.Parameters.AddWithValue("@TESLIM_TAR", txtTESLIM_TAR.Text);
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    komut.ExecuteNonQuery();
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    lblUyariSIL.Text = "Silme işleminiz başarıyla tanımlanmıştır.";
                }

            }
            catch (Exception ex)
            {

                lblUyariSIL.Text = ex.Message.ToString();
            }

        }
    }
}