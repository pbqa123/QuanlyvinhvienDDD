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
    public partial class Library_card : Form
    {
        public Library_card()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }
        SqlConnection con;

        private void Library_card_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-D108EA3\PBQA;Initial Catalog=ppppp;Integrated Security=True");
            con.Open();
            Hienthi();
        }
        public void Hienthi()
        {
            string sqlSelect = "SELECT * FROM TheThuVien";
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

            textBox1.Text = selectedRow.Cells["SoThe"].Value.ToString();
            textBox4.Text = selectedRow.Cells["GhiChu"].Value.ToString();

            // Khai báo một biến ngàyMuon để lưu giữ giá trị DateTime
            DateTime ngayMuon;
            DateTime ngaytra;

            // Thử chuyển đổi giá trị từ cell "NgayMuon" sang kiểu DateTime
            if (DateTime.TryParse(selectedRow.Cells["NgayBatDau"].Value.ToString(), out ngayMuon))
            {
                // Nếu chuyển đổi thành công, gán giá trị cho DateTimePicker hoặc sử dụng giá trị theo nhu cầu
                dateTimePicker2.Value = ngayMuon;
            }
            if (DateTime.TryParse(selectedRow.Cells["NgayHetHan"].Value.ToString(), out ngaytra))
            {
                dateTimePicker1.Value = ngaytra;
            }
            else
            {
                // Nếu chuyển đổi không thành công, xử lý theo nhu cầu của bạn
                MessageBox.Show("Invalid date format in NgayMuon cell.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlThem = "INSERT INTO TheThuVien VALUES ( @SoThe ,@NgayBatDau , @NgayHetHan ,@GhiChu )";
            SqlCommand cmd = new SqlCommand(sqlThem, con);
            cmd.Parameters.AddWithValue("SoThe", textBox1.Text);
            cmd.Parameters.AddWithValue("NgayBatDau", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("NgayHetHan", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("GhiChu", textBox4.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlXua = "UPDATE TheThuVien SET SoThe =@SoThe ,NgayBatDau =@NgayBatDau,NgayHetHan=@NgayHetHan , GhiChu =@GhiChu  WHERE SoThe = @SoThe";
            SqlCommand cmd = new SqlCommand(sqlXua, con);
            cmd.Parameters.AddWithValue("SoThe", textBox1.Text);
            cmd.Parameters.AddWithValue("NgayBatDau", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("NgayHetHan", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("GhiChu", textBox4.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlXoa = "DELETE FROM TheThuVien WHERE SoThe = @SoThe";
            SqlCommand cmd = new SqlCommand(sqlXoa, con);
            cmd.Parameters.AddWithValue("SoThe", textBox1.Text);
            cmd.Parameters.AddWithValue("NgayBatDau", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("NgayHetHan", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("GhiChu", textBox4.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string searchText = textBox8.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                string query = "SELECT * FROM TheThuVien WHERE SoThe LIKE @SearchText or GhiChu LIKE @SearchText  ";
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
            string sqlSelect = "SELECT * FROM TheThuVien";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox4.Clear();
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
        }
    }
}
