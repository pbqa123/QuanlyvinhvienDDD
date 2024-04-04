using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;
namespace WinFormsSQL
{
    public partial class Create_Acc : Form
    {
        public Create_Acc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-D108EA3\\PBQA;Initial Catalog=ppppp;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Lấy thông tin từ người dùng
                    string tenDocGia = textBox3.Text;
                    string soDienThoai = textBox4.Text;
                    string username = textBox1.Text;
                    string password = textBox2.Text;

                    // Tạo mã độc giả ngẫu nhiên
                    Random random = new Random();
                    int maDocGia = random.Next(100000, 999999);
                    // Thực hiện thêm dữ liệu vào cơ sở dữ liệu
                    string query = "INSERT INTO DocGia (MaDocGia, TenDocGia, SoDienThoai, Username, Password) " +
                                   "VALUES (@MaDocGia, @TenDocGia, @SoDienThoai, @Username, @Password)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDocGia", maDocGia);
                        command.Parameters.AddWithValue("@TenDocGia", tenDocGia);
                        command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sign Up Success!");
                        }
                        else
                        {
                            MessageBox.Show("Registration failed. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Exit the application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn Yes, đóng ứng dụng
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
