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

namespace Modulİki
{
    public partial class uye : Form
    {
        public uye()
        {
            InitializeComponent();
        }
        SqlCommand komut;
        SqlDataAdapter da;
        SqlConnection baglan = new SqlConnection("Data Source = ELBER\\SQLEXPRESS; Initial Catalog = Modul; Integrated Security = True");
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Anasayfa ac = new Anasayfa();
            ac.Show();
        }

        private void uye_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "insert into Kullanıcılar (sifre,kullanicitipi,kullanıcı) values (@sifre,@kullanıcıtipi,@kullanıcı)";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@sifre", txtSf.Text);
            komut.Parameters.AddWithValue("@kullanıcıtipi", comboBox1.Text);
            komut.Parameters.AddWithValue("kullanıcı", txtKA.Text);
            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("kayıt başarılı lütfen ana sayfaya dönüp giriş yapınız..!");
        }
    }
}
