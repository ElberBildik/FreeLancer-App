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
    
    public partial class YoneticiPaneli : Form
    {
        
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        DataTable tablo;
        SqlConnection con = new SqlConnection("Data Source = ELBER\\SQLEXPRESS; Initial Catalog = Modul; Integrated Security = True");
        public YoneticiPaneli()
        {
            InitializeComponent();
        }
        
        void griddoldur()
        {
           
            da = new SqlDataAdapter("Select * From isler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds,"isler");
            dataGridView1.DataSource = ds.Tables["isler"];
            con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into isler (ishakkında,fiyat,isbastarihi,isbitistarihi) values (@ishakkında,@fiyat,@isbastarihi,@isbitistarihi)";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@ishakkında", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@fiyat", textBox1.Text);
            cmd.Parameters.AddWithValue("@isbastarihi", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@isbitistarihi", dateTimePicker2.Value);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM isler WHERE isıd=@ıd";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ıd", (label6.Text).ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            string sorgu = "Update isler Set ishakkında=@ishakkında,fiyat=@fiyat,isbastarihi=@isbastarihi,isbitistarihi=@isbitistarihi Where isıd=@ıd";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@ishakkında", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@fiyat", textBox1.Text);
            cmd.Parameters.AddWithValue("@isbastarihi", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@isbitistarihi", dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("@ıd", label6.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void YoneticiPaneli_Load(object sender, EventArgs e)
        {

        }
    }
}
