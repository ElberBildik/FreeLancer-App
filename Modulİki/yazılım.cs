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
    public partial class yazılım : Form
    {
        

        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        DataTable tablo;
        SqlConnection con = new SqlConnection("Data Source = ELBER\\SQLEXPRESS; Initial Catalog = Modul; Integrated Security = True");
        void griddoldur()
        {

            da = new SqlDataAdapter("Select * From isler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "isler");
            dataGridView1.DataSource = ds.Tables["isler"];
            con.Close();
        }
        void alınanisler()
        {

            da = new SqlDataAdapter("Select * From alınanisler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "isler");
            dataGridView1.DataSource = ds.Tables["isler"];
            con.Close();
        }
        public yazılım()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void yazılımcı_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sorgu = "Insert into alınanisler (ishakkında,fiyat,isbastarihi,isbitistarihi) values (@ishakkında,@fiyat,@isbastarihi,@isbitistarihi)";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@ishakkında", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@fiyat", textBox1.Text);
            cmd.Parameters.AddWithValue("@isbastarihi", textBox2.Text);
            cmd.Parameters.AddWithValue("@isbitistarihi", textBox3.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            //alınan isin tekrarnı önlemek için iş silindi
            string sql = "DELETE FROM isler WHERE isıd=@ıd";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ıd", (label5.Text).ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            alınanisler();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            griddoldur();
        }
    }
}
