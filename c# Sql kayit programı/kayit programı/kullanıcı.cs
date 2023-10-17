using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace kayit_programı
{
    public partial class kullanıcı : Form
    {

      SqlConnection baglanti=new SqlConnection("Server=MURATYıLDıZ\\MSSQLSERVER22;Database=ticaret;Trusted_Connection=True;");
        public kullanıcı()
        {
            InitializeComponent();
        }

        private void kullanıcı_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                String Sql = "Select * From Kullanıcı2 where Ad=@Adi And Sifre=@sifresi";
                SqlParameter prm1 = new SqlParameter("adi", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifresi", textBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(Sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

                if(dt.Rows.Count>0)
                {
                    Form1 fr=new Form1();
                    fr.Show();
                }


            }
            catch (Exception)
            {

                MessageBox.Show("hatalı giriş");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
        }
    }
}
