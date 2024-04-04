using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
namespace WinFormsSQL
{
    public partial class Forgot_Password : Form
    {
        public Forgot_Password()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Exit the application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn Yes, đóng ứng dụng
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
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
                    string username = textBox1.Text;
                    string phoneNumber = textBox2.Text;

                    // Thực hiện truy vấn SQL để lấy mật khẩu
                    string query = "SELECT Password FROM DocGia WHERE Username = @Username AND SoDienThoai = @PhoneNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                        object result = command.ExecuteScalar();

                        if (result != null)  // Kiểm tra xem có mật khẩu trả về hay không
                        {
                            // Hiển thị mật khẩu trên Label
                            label5.Text = " Password : " + result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No information found. Please check your username and phone number again.");
                            label5.Text = "";  // Đặt lại Label nếu không có mật khẩu
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }
    }
}
