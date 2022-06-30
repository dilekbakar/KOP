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
    public partial class Islemler : System.Web.UI.Page
    {
        BaglantiYolu by = new BaglantiYolu();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Eğer kullanıcıya atadığımız bilgiler boş olursa ve direk linkten bağlanmaya çalışan olursa yetkisiz girişe yönlendiriyoruz.
            if (Session["KULLANICI"] == null)
            {
                Response.Redirect("YetkisizGiris.aspx");
            }
            txtVTarih.Text = DateTime.Now.ToString("dd.MM.yyyy"); //Kısa tarih yazdırmak istediğimizde kullanıyoruz.
            txtTTarih.Text = DateTime.Now.AddMonths(1).ToString("dd.MM.yyyy"); //Tarihimize 1 ay ekledik.,
            if (!Page.IsPostBack)
            {


                hfKITAP_ID.Value = Request.QueryString["ID"];
                Yukle();
                //IslemKaydi();

                /* KİTAP ID GÖNDEREREK KİTAP ADI ÇEKİLECEK KULLANICILAR COMBOBOX A DOLDURULUP SEÇİM YAPLACAK TARİH SEÇİMİNİN ARDINDAN KİTAP ALMA KONTROLÜ YAPILDIKTAN SONRA İŞLEM GERÇEKLEŞTİRİLECEK*/
                DdlyeUyeEkle();

            }

        }



        protected void btnIslemler_Click(object sender, EventArgs e)
        {
            IslemEkleSil();
            UyeninKitaplari();


        }
        protected void btnIslemSorgu_Click(object sender, EventArgs e)
        {
            Gecikme();           
        }

        private void Gecikme()
        {
            
            try
            {
                using (SqlConnection baglanti = new SqlConnection(by.ConnectionString))
                {
                    string sorgu = " SELECT UYE_AD,KITAP_ADI,DATEDIFF(day,TESLIM_TAR,getdate()) as gecen_gun FROM Islemler where UYE_AD=@UYE_AD AND DATEDIFF(day,TESLIM_TAR,getdate()) > 0 ";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    // komut.Parameters.AddWithValue("@VERILME_TAR",txtVTarih.Text);
                    komut.Parameters.AddWithValue("@UYE_AD", ddlUYE_AD.SelectedItem.Text);
                    komut.Parameters.AddWithValue("@KITAP_ADI", txtKITAP_ADI.Text);
                    komut.Parameters.AddWithValue("@TESLIM_TAR", txtTTarih.Text);
                    komut.Parameters.AddWithValue("@gecen_gun", grdViewGecikme.ToString());


                    if (baglanti.State == System.Data.ConnectionState.Closed)//Bağlantının açık olup olmadığını kontrol ediyoruz.
                    {
                        baglanti.Open();
                    }
                
                    SqlDataReader veri = komut.ExecuteReader(); //Veri okuyacağımız için datareader kullandık.
                  
                   
                        grdViewGecikme.DataSource = veri; //SQL deki verilere ulaşmak için datasource kullanıyoruz.
                        grdViewGecikme.DataBind();  // DataBind verileri "veri"ye bağlamak ,yerleştirmek için kullandık.
                    
                    
                        lblUyariIslemler.Text = "Geciken teslim tarihi var ise aşağıda görüntülenecektir:";
                    

                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                 
                }

            }
            catch (Exception ex)
            {
                lblUyariIslemler.Text = ex.Message.ToString();
            }


           



        }

        private void UyeninKitaplari()  //Void geriye değer döndürmeyen metotlar için kullanılır.Public, Protected ve Private tanımlamalarına ise erişim belirleyiciler(Access Modifiers) denir. Public olarak tanımlanan öğeye kod bloğunun içinden ve dışından erişebilir, yani her yerden ulaşılabilir denilebilir. 
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(by.ConnectionString))
                {


                    string sorgu = "SELECT * from Islemler where UYE_AD in (SELECT UYE_AD from Islemler where UYE_AD=@UYE_AD )";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti); //komut adında nesne tanımlamak için sqlcommand kullandık.
                    komut.Parameters.AddWithValue("@UYE_AD", ddlUYE_AD.SelectedItem.Text);
                    if (baglanti.State == System.Data.ConnectionState.Closed)//Bağlantının açık olup olmadığını kontrol ediyoruz.
                    {
                        baglanti.Open();
                    }
                    SqlDataReader veri = komut.ExecuteReader(); //Veri okuyacağımız için datareader kullandık.

                    grdViewUyeninKitaplari.DataSource = veri; //SQL deki verilere ulaşmak için datasource kullanıyoruz.
                    grdViewUyeninKitaplari.DataBind();  // DataBind verileri "veri"ye bağlamak ,yerleştirmek için kullandık.


                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }



                }




            }
            catch (Exception ex)
            {

                lblUyariIslemler.Text = ex.Message.ToString();
            }
        }




        private void Yukle()
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(by.ConnectionString))
                {
                    string sorgu = "select * from Kitaplar where ID=@KITAP_ADI ";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("KITAP_ADI", hfKITAP_ID.Value);
                    //Baglantının açık ya da kapalı olma durumuna bakarak bağlantıyı açıp kapatacağız.
                    if (baglanti.State == System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        txtKITAP_ADI.Text = dr["KITAP_ADI"].ToString();
                    }
                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }



                }

            }
            catch (Exception ex)
            {

                lblUyariIslemler.Text = ex.Message.ToString();
            }




        }



        private void DdlyeUyeEkle()
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(by.ConnectionString)) //bağlanti isimli bir nesne tanımlıyoruz.Connection string ile bağlantıyı yapıyoruz.
                {
                    string sorgu = "select * from Uyeler order by AD";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti); //komut isimli bir nesne tanımlayark komut oluşturduk.
                    if (baglanti.State == System.Data.ConnectionState.Closed)//Bağlantının açık olup olmadığını kontrol ediyoruz.
                    {
                        baglanti.Open();
                    }
                    SqlDataReader veri = komut.ExecuteReader();
                    while (veri.Read()) //Veriyi okuduğu sürece while döngüsü devam edecek.Okuyamadığı zaman döngü sonlanacak.
                    {
                        ListItem lUye = new ListItem(); //Bir liste oluşturduk.
                        lUye.Text = veri["AD"] + " " + veri["SOYAD"] + " " + veri["TC"];
                        //lUye.Value = veri["ID"].ToString();
                        ddlUYE_AD.Items.Add(lUye); //listItem a yüklediğimiz verileri ddl ye kaydettik.
                    }
                    if (baglanti.State == System.Data.ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                lblUyariIslemler.Text = ex.Message.ToString();
            }
        }
        private void IslemEkleSil()
        {
            if (IslemKayitliMi()==false) //Islem kayitli değilse kaydet.
            {
                IslemKaydi();
            }
            else
            {
                lblUyariIslemler.Text = "Kayıt zaten var.Aynı kitap ile ikinci defa işlem yapamazsınız!";
                btnIptal.Visible = true;
                btnIslemler.Visible = false;
            }
            



        }

        private bool IslemKayitliMi() //İşlemin kayıtlı olup olmadığını kontrol eden fonksiyon.
        {
            bool donenDeger = false; //Dönen değer isimli bir nesne tanımladık.
            try
            {
                using (SqlConnection baglanti = new SqlConnection(by.ConnectionString))
                {
                    string sql = "select * from Islemler where KITAP_ADI=@KITAP_ADI AND UYE_AD=@UYE_AD"; //ISBN kodunu veri tabanından okuyup,girilen değeri isbn textboxuna yazıyor.
                    SqlCommand komut = new SqlCommand(sql, baglanti);
                    komut.Parameters.AddWithValue("@KITAP_ADI", txtKITAP_ADI.Text);
                    komut.Parameters.AddWithValue("@UYE_AD", ddlUYE_AD.Text);
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

                lblUyariIslemler.Text = ex.Message.ToString();
            }
            return donenDeger;
        }

        private void IslemKaydi()
        {
            //try-catch i unutmuyoruz.
            try
            {
                using (SqlConnection baglanti = new SqlConnection(by.ConnectionString))
                {
                    string sorgu = "insert into Islemler (UYE_AD,KITAP_ADI,VERILME_TAR,TESLIM_TAR) values (@UYE_AD,@KITAP_ADI,@VERILME_TAR,@TESLIM_TAR)";


                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@UYE_AD", ddlUYE_AD.SelectedItem.Text);
                    //komut.Parameters.AddWithValue("@SOYAD", ddlUYE_AD.SelectedItem.Value);
                    komut.Parameters.AddWithValue("@KITAP_ADI", txtKITAP_ADI.Text);
                    komut.Parameters.AddWithValue("@VERILME_TAR", Convert.ToDateTime(txtVTarih.Text));
                    komut.Parameters.AddWithValue("@TESLIM_TAR", Convert.ToDateTime(txtTTarih.Text));

                    //sorgu = "select dateadd(day,30,getdate())";
                    //sorgu = "insert into Islemler (@TESLIM_

                    // komut.Parameters.AddWithValue("@TESLIM_TAR",txtTTarih.Text);
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
                    lblUyariIslemler.Text = "İşlem Kaydı Alınmıştır";
                }

            }
            catch (Exception ex)
            {

                lblUyariIslemler.Text = ex.Message.ToString();
            }

        }

        protected void btnIptal_Click(object sender, EventArgs e)
        {
            Response.Redirect("KitapSorgula.aspx");
        }
    }
}