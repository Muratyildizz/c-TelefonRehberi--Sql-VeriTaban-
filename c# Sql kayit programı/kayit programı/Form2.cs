using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace kayit_programı
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=MURATYıLDıZ\\MSSQLSERVER22;Database=ticaret;Trusted_Connection=True;");
        
        private void veriler()
        {
        listView1.Clear();
            baglanti.Open();
            SqlCommand komut=new SqlCommand("Select *From Kullanıcı2",baglanti);
            SqlDataReader oku=komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle=new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Sifre"].ToString());
                listView1.Items.Add(ekle);

                

            }
            baglanti.Close();
       
        }
        int id = 0;

        private void Form2_Load(object sender, EventArgs e)
        {
            veriler();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Kullanıcı2 set Ad='"+textBox1.Text.ToString()+"',Sifre='"+textBox2.Text.ToString()+"'where id="+id+"",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            veriler();

        
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;



        }
    }
}
