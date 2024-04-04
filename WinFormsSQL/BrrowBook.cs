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
    public partial class LoanAdmin : Form
    {
        public LoanAdmin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }
        SqlConnection con;


        private void LoanAdmin_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-D108EA3\PBQA;Initial Catalog=ppppp;Integrated Security=True");
            con.Open();
            Hienthi();
        }
        public void Hienthi()
        {
            string sqlSelect = "SELECT * FROM MuonTra";
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

            textBox1.Text = selectedRow.Cells["MaMuonTra"].Value.ToString();
            textBox2.Text = selectedRow.Cells["SoThe"].Value.ToString();
            textBox3.Text = selectedRow.Cells["MaNhanVien"].Value.ToString();

            // Khai báo một biến ngàyMuon để lưu giữ giá trị DateTime
            DateTime ngayMuon;

            // Thử chuyển đổi giá trị từ cell "NgayMuon" sang kiểu DateTime
            if (DateTime.TryParse(selectedRow.Cells["NgayMuon"].Value.ToString(), out ngayMuon))
            {
                // Nếu chuyển đổi thành công, gán giá trị cho DateTimePicker hoặc sử dụng giá trị theo nhu cầu
                dateTimePicker1.Value = ngayMuon;
            }
            else
            {
                // Nếu chuyển đổi không thành công, xử lý theo nhu cầu của bạn
                MessageBox.Show("Invalid date format in NgayMuon cell.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlThem = "INSERT INTO MuonTra VALUES (@MaMuonTra , @SoThe ,@MaNhanVien , @NgayMuon )";
            SqlCommand cmd = new SqlCommand(sqlThem, con);
            cmd.Parameters.AddWithValue("MaMuonTra", textBox1.Text);
            cmd.Parameters.AddWithValue("SoThe", textBox2.Text);
            cmd.Parameters.AddWithValue("MaNhanVien", textBox3.Text);
            cmd.Parameters.AddWithValue("NgayMuon", dateTimePicker1.Value);

            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlXua = "UPDATE MuonTra SET MaMuonTra = @MaMuonTra ,SoThe =@SoThe ,MaNhanVien =@MaNhanVien,NgayMuon=@NgayMuon  WHERE MaMuonTra = @MaMuonTra";
            SqlCommand cmd = new SqlCommand(sqlXua, con);
            cmd.Parameters.AddWithValue("MaMuonTra", textBox1.Text);
            cmd.Parameters.AddWithValue("SoThe", textBox2.Text);
            cmd.Parameters.AddWithValue("MaNhanVien", textBox3.Text);
            cmd.Parameters.AddWithValue("NgayMuon", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlXoa = "DELETE FROM MuonTra WHERE MaMuonTra = @MaMuonTra";
            SqlCommand cmd = new SqlCommand(sqlXoa, con);
            cmd.Parameters.AddWithValue("MaMuonTra", textBox1.Text);
            cmd.Parameters.AddWithValue("SoThe", textBox2.Text);
            cmd.Parameters.AddWithValue("MaNhanVien", textBox3.Text);
            cmd.Parameters.AddWithValue("NgayMuon", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();
            Hienthi();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.ResetText();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string searchText = textBox8.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                string query = "SELECT * FROM MuonTra WHERE MaMuonTra LIKE @SearchText  ";
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
            string sqlSelect = "SELECT * FROM ChiTietMuonTra";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
    }
}
