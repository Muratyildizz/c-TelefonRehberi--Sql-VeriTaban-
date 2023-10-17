using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace kayit_programı
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        DataTable tablo;

        public Form1()
        {
            InitializeComponent();
        }

        void MusteriGetir()
        {
            baglanti = new SqlConnection("Server=MURATYıLDıZ\\MSSQLSERVER22;Database=ticaret;Trusted_Connection=True;");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM musteri", baglanti);
            tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MusteriGetir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTelefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection("Server=MURATYıLDıZ\\MSSQLSERVER22;Database=ticaret;Trusted_Connection=True;");
            string sorgu = "INSERT INTO musteri(mno, ad, soyad, tel) VALUES(@mno, @ad, @soyad, @tel)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@mno", txtNo.Text);
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@tel", txtTelefon.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MusteriGetir();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti = new SqlConnection("Server=MURATYıLDıZ\\MSSQLSERVER22;Database=ticaret;Trusted_Connection=True;");
            string sorgu = "DELETE FROM musteri WHERE mno = @mno";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@mno", txtNo.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MusteriGetir();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE musteri SET ad=@ad,soyad=@soyad,tel=@tel WHERE mno=@mno";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@mno", txtNo.Text);
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@tel", txtTelefon.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MusteriGetir();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * From musteri where ad=@ad";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@ad", txtAra.Text);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
