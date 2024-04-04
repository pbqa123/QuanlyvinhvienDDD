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


namespace WinFormsSQL
{
    public partial class Book_management : Form
    {
        public Book_management()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }
        SqlConnection con;

        private void Book_management_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-D108EA3\PBQA;Initial Catalog=ppppp;Integrated Security=True");
            con.Open();
            Hienthi();
        }
        public void Hienthi()
        {
            string sqlSelect = "SELECT * FROM Sach";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlThem = "INSERT INTO Sach VALUES (@MaSach , @TenSach ,@MaTacGia , @MaTheLoai ,@MaNXB , @NamXuatBan )";
            SqlCommand cmd = new SqlCommand(sqlThem, con);
            cmd.Parameters.AddWithValue("MaSach", textBox1.Text);
            cmd.Parameters.AddWithValue("TenSach", textBox2.Text);
            cmd.Parameters.AddWithValue("MaTacGia", textBox3.Text);
            cmd.Parameters.AddWithValue("MaTheLoai", textBox4.Text);
            cmd.Parameters.AddWithValue("MaNXB", textBox5.Text);
            cmd.Parameters.AddWithValue("NamXuatBan", textBox6.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
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

            textBox1.Text = selectedRow.Cells["MaSach"].Value.ToString();
            textBox2.Text = selectedRow.Cells["TenSach"].Value.ToString();
            textBox3.Text = selectedRow.Cells["MaTacGia"].Value.ToString();
            textBox4.Text = selectedRow.Cells["MaTheLoai"].Value.ToString();
            textBox5.Text = selectedRow.Cells["MaNXB"].Value.ToString();
            textBox6.Text = selectedRow.Cells["NamXuatBan"].Value.ToString();
            //Khai báo một biến ngàyMuon để lưu giữ giá trị DateTime
            DateTime ngayMuon;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlXua = "UPDATE Sach SET MaSach = @MaSach , TenSach = @TenSach , MaTacGia = @MaTacGia , MaTheLoai = @MaTheLoai , MaNXB = @MaNXB , NamXuatBan = @NamXuatBan WHERE MaSach = @MaSach";
            SqlCommand cmd = new SqlCommand(sqlXua, con);
            cmd.Parameters.AddWithValue("MaSach", textBox1.Text);
            cmd.Parameters.AddWithValue("TenSach", textBox2.Text);
            cmd.Parameters.AddWithValue("MaTacGia", textBox3.Text);
            cmd.Parameters.AddWithValue("MaTheLoai", textBox4.Text);
            cmd.Parameters.AddWithValue("MaNXB", textBox5.Text);
            cmd.Parameters.AddWithValue("NamXuatBan", textBox6.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlXoa = "DELETE FROM Sach WHERE MaSach = @MaSach";
            SqlCommand cmd = new SqlCommand(sqlXoa, con);
            cmd.Parameters.AddWithValue("MaSach", textBox1.Text);
            cmd.Parameters.AddWithValue("TenSach", textBox2.Text);
            cmd.Parameters.AddWithValue("MaTacGia", textBox3.Text);
            cmd.Parameters.AddWithValue("MaTheLoai", textBox4.Text);
            cmd.Parameters.AddWithValue("MaNXB", textBox5.Text);
            cmd.Parameters.AddWithValue("NamXuatBan", textBox6.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string searchText = textBox8.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                string query = "SELECT * FROM Sach WHERE TenSach LIKE @SearchText OR MaSach LIKE @SearchText";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string sqlSelect = "SELECT * FROM Sach";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
