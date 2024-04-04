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
    public partial class Reader_Management : Form
    {
        public Reader_Management()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        SqlConnection con;

        private void Reader_Management_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-D108EA3\PBQA;Initial Catalog=ppppp;Integrated Security=True");
            con.Open();
            Hienthi();
        }
        public void Hienthi()
        {
            string sqlSelect = "SELECT * FROM DocGia";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
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

            textBox1.Text = selectedRow.Cells["MaDocGia"].Value.ToString();
            textBox2.Text = selectedRow.Cells["TenDocGia"].Value.ToString();
            textBox3.Text = selectedRow.Cells["DiaChi"].Value.ToString();
            textBox4.Text = selectedRow.Cells["SoDienThoai"].Value.ToString();
            textBox5.Text = selectedRow.Cells["SoThe"].Value.ToString();
            textBox9.Text = selectedRow.Cells["Username"].Value.ToString();
            textBox10.Text = selectedRow.Cells["Password"].Value.ToString();

            //Khai báo một biến ngàyMuon để lưu giữ giá trị DateTime
            DateTime ngayMuon;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlThem = "INSERT INTO DocGia VALUES (@MaDocGia , @TenDocGia ,@DiaChi , @SoDienThoai ,@SoThe , @Username ,@Password )";
            SqlCommand cmd = new SqlCommand(sqlThem, con);
            cmd.Parameters.AddWithValue("MaDocGia", textBox1.Text);
            cmd.Parameters.AddWithValue("TenDocGia", textBox2.Text);
            cmd.Parameters.AddWithValue("DiaChi", textBox3.Text);
            cmd.Parameters.AddWithValue("SoDienThoai", textBox4.Text);
            cmd.Parameters.AddWithValue("SoThe", textBox5.Text);
            cmd.Parameters.AddWithValue("Username", textBox9.Text);
            cmd.Parameters.AddWithValue("Password", textBox10.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlXua = "UPDATE DocGia SET MaDocGia = @MaDocGia , TenDocGia = @TenDocGia , DiaChi = @DiaChi , SoDienThoai = @SoDienThoai , SoThe = @SoThe , Username = @Username , Password = @Password WHERE MaDocGia = @MaDocGia";
            SqlCommand cmd = new SqlCommand(sqlXua, con);
            cmd.Parameters.AddWithValue("MaDocGia", textBox1.Text);
            cmd.Parameters.AddWithValue("TenDocGia", textBox2.Text);
            cmd.Parameters.AddWithValue("DiaChi", textBox3.Text);
            cmd.Parameters.AddWithValue("SoDienThoai", textBox4.Text);
            cmd.Parameters.AddWithValue("SoThe", textBox5.Text);
            cmd.Parameters.AddWithValue("Username", textBox9.Text);
            cmd.Parameters.AddWithValue("Password", textBox10.Text);

            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlXoa = "DELETE FROM DocGia WHERE MaDocGia = @MaDocGia";
            SqlCommand cmd = new SqlCommand(sqlXoa, con);
            cmd.Parameters.AddWithValue("MaDocGia", textBox1.Text);
            cmd.Parameters.AddWithValue("TenDocGia", textBox2.Text);
            cmd.Parameters.AddWithValue("DiaChi", textBox3.Text);
            cmd.Parameters.AddWithValue("SoDienThoai", textBox4.Text);
            cmd.Parameters.AddWithValue("SoThe", textBox5.Text);
            cmd.Parameters.AddWithValue("Username", textBox9.Text);
            cmd.Parameters.AddWithValue("Password", textBox10.Text);

            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string sqlSelect = "SELECT * FROM DocGia";
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
                string query = "SELECT * FROM DocGia WHERE MaDocGia LIKE @SearchText  OR TenDocGia LIKE @SearchText OR SoDienThoai LIKE @SearchText OR DiaChi LIKE @SearchText ";
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
    }
}
