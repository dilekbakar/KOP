using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KOP.App_Data;
using System.Data.SqlClient;
using System.Data;

namespace KOP
{
    public partial class KitapSorgula : System.Web.UI.Page
    {
        BaglantiYolu by = new BaglantiYolu();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Eğer kullanıcıya atadığımız bilgiler boş olursa ve direk linkten bağlanmaya çalışan olursa yetkisiz girişe yönlendiriyoruz.
            if (Session["KULLANICI"] == null)
            {
                Response.Redirect("YetkisizGiris.aspx");
            }
        }

        protected void btnSorgu_Click(object sender, EventArgs e)
        {
            Sorgula();
        }
        private void Sorgula() //Sorgulama fonksiyonumuz.
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(by.ConnectionString)) 
                {
                    List<string> sorguEki = new List<string>(); //Listeye çeviriyoruz diziyi.
                    List<SqlParameter> parametreler = new List<SqlParameter>(); //Parametreleri listeye çeviriyoruz.
                    if (!string.IsNullOrWhiteSpace(txtSorguIsbn.Text)) //Eğer ISBN textboxu tamamen boş değilse...
                    {
                        sorguEki.Add("ISBN=@ISBN");
                        parametreler.Add(new SqlParameter(@"txtSorguIsbn", System.Data.SqlDbType.NVarChar)

                        {
                            Value = txtSorguIsbn.Text //Eğer veri tabanında gelen veri ile girilen isbn eşitse bu değeri döndürüp listeliyor.ISBN kodunu tam istediğimiz için nurayı like ile yapmadık.
                        });
                    }
                    if (!string.IsNullOrWhiteSpace(txtSorguKitapAdi.Text))
                    {
                        //Girilen veriyi içeren veri var mı diye veri tabanına bakıyor.Daha sonra parametrelere ekliyor.
                        sorguEki.Add("KITAP_ADI like @KITAP_ADI");
                        parametreler.Add(new SqlParameter(@"txtSorguKitapAdi", System.Data.SqlDbType.NVarChar)
                        {
                            Value = txtSorguKitapAdi.Text //Girilen dizini içeren bir veri varsa bu değer döndürülüp listeleniyor.
                        });
                    }

                    if (!string.IsNullOrWhiteSpace(txtSorguYazar.Text))
                    {
                        sorguEki.Add("YAZAR_AD like @YAZAR_AD");
                        parametreler.Add(new SqlParameter(@"txtSorguYazar", System.Data.SqlDbType.NVarChar)
                        {
                            Value = txtSorguYazar.Text //Aynı şekilde girilen dizini içeren verileri listeliyor.
                        });
                    }
                    string sorgu = string.Format("Select * from Kitaplar INNER JOIN Yazarlar on Kitaplar.YAZAR_ID=Yazarlar.ID where {0}",string.Join( " and " ,sorguEki)); //Kitaplar ile Yazarlar tablosunu birleştirdik.
                    SqlCommand komut = new SqlCommand(sorgu, cnn);
                    komut.Parameters.AddWithValue("@ISBN",txtSorguIsbn.Text);//Textboxa girilen değeri kaydettik.
                    komut.Parameters.AddWithValue("@KITAP_ADI","%" +txtSorguKitapAdi.Text.ToString() + "%");//% işareti içinde "girilen değeri içeren" anlamına geliyor.
                    komut.Parameters.AddWithValue("@YAZAR_AD", "%" + txtSorguYazar.Text.ToString() + "%");

                    if (cnn.State==  ConnectionState.Closed)
                    {
                        cnn.Open();
                    }
                    SqlDataReader rd = komut.ExecuteReader(); //Data reader komutumuzu oluşturuyoruz.source ile rd ye yedekleyip,DataBind ile listeye bindiriyoruz.
                    grdViewSorgu.DataSource = rd;
                    grdViewSorgu.DataBind();
                    if (cnn.State== ConnectionState.Open)
                    {
                        cnn.Close();
                    }

                  
                }

            }


    
            catch (Exception ex)
            {

                lblSorgu.Text = ex.Message.ToString();
            }
}
    }
}