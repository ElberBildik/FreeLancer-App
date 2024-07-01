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
    public partial class Yazılımcıgiris : Form
    {
        public Yazılımcıgiris()
        {
            InitializeComponent();
        }
        SqlDataAdapter da;
        DataSet ds;
        DataTable tablo;
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;
        

        private void Yazılımcıgiris_Load(object sender, EventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uye ac = new uye();
            ac.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string connectionString = "Data Source = ELBER\\SQLEXPRESS; Initial Catalog = Modul; Integrated Security = True";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT kullanicitipi FROM Kullanıcılar WHERE kullanıcı = @username AND sifre = @password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string userType = reader["kullanicitipi"].ToString();

                        if (userType == "yazılımcı")
                        {
                            yazılım ac = new yazılım();
                            ac.Show();
                        }
                        else
                        {
                            MessageBox.Show("Lütfen yönetici ekranından giriş yapınız.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bilgileriniz yanlış. Lütfen tekrar deneyin.");
                    }
                }
            }
        }
    }
}
