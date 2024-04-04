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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WinFormsSQL
{
    public partial class Author_Genres : Form
    {
        public Author_Genres()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }
        SqlConnection con;
        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải là dòng header không
            if (e.RowIndex == -1)
            {
                return;
            }

            // Lấy dữ liệu từ DataGridView và hiển thị trong TextBoxes
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

            textBox1.Text = selectedRow.Cells["MaTacGia"].Value.ToString();
            textBox2.Text = selectedRow.Cells["TenTacGia"].Value.ToString();

            //Khai báo một biến ngàyMuon để lưu giữ giá trị DateTime    
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Author_Genres_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-D108EA3\PBQA;Initial Catalog=ppppp;Integrated Security=True");
            con.Open();
            Hienthi();
            Hienthi2();

        }
        public void Hienthi()
        {
            string sqlSelect = "SELECT * FROM TacGia ";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
        public void Hienthi2()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlThem = "INSERT INTO TacGia VALUES (@MaTacGia , @TenTacGia )";
            SqlCommand cmd = new SqlCommand(sqlThem, con);
            cmd.Parameters.AddWithValue("MaTacGia", textBox1.Text);
            cmd.Parameters.AddWithValue("TenTacGia", textBox2.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlXua = "UPDATE TacGia SET MaTacGia = @MaTacGia ,TenTacGia = @TenTacGia  WHERE MaTacGia = @MaTacGia";
            SqlCommand cmd = new SqlCommand(sqlXua, con);
            cmd.Parameters.AddWithValue("MaTacGia", textBox1.Text);
            cmd.Parameters.AddWithValue("TenTacGia", textBox2.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlXoa = "DELETE FROM TacGia WHERE MaTacGia = @MaTacGia";
            SqlCommand cmd = new SqlCommand(sqlXoa, con);
            cmd.Parameters.AddWithValue("MaTacGia", textBox1.Text);
            cmd.Parameters.AddWithValue("TenTacGia", textBox2.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string sqlSelect = "SELECT * FROM TacGia ";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string searchText = textBox8.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                string query = "SELECT * FROM TacGia WHERE MaTacGia LIKE @SearchText  OR TenTacGia LIKE @SearchText  ";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Assuming you have a DataGridView named dataGridView1 on your form
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
