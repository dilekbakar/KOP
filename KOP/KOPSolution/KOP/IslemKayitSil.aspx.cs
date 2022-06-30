using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KOP.App_Data;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace KOP
{
    public partial class IslemKayitSil : System.Web.UI.Page
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

        protected void btnIslemAra_Click(object sender, EventArgs e)
        {
            IslemAra();
        }


        private void IslemAra() //İşlem arayacağız.GridViewa aktaracağız.
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(by.ConnectionString))
                {
                    List<string> sorguEki = new List<string>();
                    List<SqlParameter> parametreler = new List<SqlParameter>();
                    if (!string.IsNullOrWhiteSpace(txtUYE_AD.Text))
                    {
                        sorguEki.Add("UYE_AD LIKE @UYE_AD"); //üye adı olarak girdiğimiz kayıtları listeliyor.
                        parametreler.Add(new SqlParameter(@"txtUYE_AD", System.Data.SqlDbType.NVarChar)
                        {

                            Value = txtUYE_AD.Text

                        }); 

                    }
                    string sorgu = string.Format("Select * from Islemler where {0}", string.Join("and", sorguEki)); //işlemler tablosunda ({0} yerine sorgu eki geliyor ve yukarıdaki sorgu çalışıyor sanırım.) adı girilen veriyi seçip yazdırdık.
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@UYE_AD", "%" + txtUYE_AD.Text + "%");//% işareti içinde "girilen değeri içeren" anlamına geliyor.
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    SqlDataReader rd = komut.ExecuteReader(); //Data reader komutumuzu oluşturuyoruz.source ile rd ye yedekleyip,DataBind ile listeye bindiriyoruz.
                    grdViewIslemAra.DataSource = rd;
                    grdViewIslemAra.DataBind();
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }

                }

            }
            catch (Exception ex)
            {

                lblUyariIslemSil.Text = ex.Message.ToString();
            }
        }

    }
}