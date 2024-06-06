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

namespace ComputerShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=computerdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cmd = new SqlCommand("insert into cs values(@ProductID,@ProductName,@Price,@Status)", con);

            cmd.Parameters.AddWithValue("@ProductID", int.Parse(txtProductID.Text));

            cmd.Parameters.AddWithValue("ProductName", comboname.Text);

            cmd.Parameters.AddWithValue("@Price", comboPrice.Text);

            cmd.Parameters.AddWithValue("@Status", comboStatus.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Record Saved Successfully");

            BindData();

        }

        void BindData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=computerdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cmd = new SqlCommand("select * from cs", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=computerdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cmd = new SqlCommand("delete cs where productid=@productid", con);

            cmd.Parameters.AddWithValue("@ProductID", int.Parse(txtProductID.Text));


            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Are you sure you want to delete data? ");

            BindData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductID.Text = "";
            comboname.Text = "";
            comboPrice.Text = "";
            comboStatus.Text = "";
        }
    }
}
