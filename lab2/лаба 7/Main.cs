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


namespace лаба_2
{
    public partial class Form1 : Form
    {
       
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open();
            load_data();
        }
        void load_data()
        {
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT*FROM [User]", connection);
            DataTable data = new DataTable();
            sqlData.Fill(data);
            dataGridView1.DataSource = data;

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [User](Number grup, Name, Adress, Grup) VALUES ('" + id_txt.Text + " ',' " + name_txt.Text + "' , '" + ad_txt.Text + "' , '" + grup_txt.Text + " ')", connection);
            command.ExecuteNonQuery();
            clear_fun();
            MessageBox.Show("saved");

        }
        void clear_fun()
        {
            id_txt.Text = "";
            name_txt.Text = "";
            ad_txt.Text = "";
            grup_txt.Text = "";
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            clear_fun();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("UPDATE [User] SET Name student='" + name_txt.Text + "', adress='" + ad_txt.Text + "', Grup='" + grup_txt.Text + "' where number grup='" + id_txt.Text + "'", connection);
            command.ExecuteNonQuery();
            load_data();
            clear_fun();
            MessageBox.Show("Updated");

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [User] WHERE Number grup='" + id_txt.Text + "'", connection);
            command.ExecuteNonQuery();
            load_data();
            clear_fun();
            MessageBox.Show("Deleted");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Num = dataGridView1.CurrentCell.RowIndex;
            id_txt.Text = dataGridView1.Rows[Num].Cells[0].Value.ToString();
            name_txt.Text = dataGridView1.Rows[Num].Cells[1].Value.ToString();
            ad_txt.Text = dataGridView1.Rows[Num].Cells[2].Value.ToString();
            grup_txt.Text = dataGridView1.Rows[Num].Cells[3].Value.ToString();

        }

       
    }
}
