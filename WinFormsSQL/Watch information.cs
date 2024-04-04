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
    public partial class Watch_information : Form
    {
        public Watch_information()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
           
            SqlCommand cmd = new SqlCommand();
            con = new SqlConnection(@"Data Source=DESKTOP-D108EA3\PBQA;Initial Catalog=ppppp;Integrated Security=True");
            con.Open();

        }
        SqlConnection con;
        private void label7_Click(object sender, EventArgs e)
        {

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
                    string phoneNumber = textBox1.Text;

                    // Thực hiện truy vấn SQL để lấy thông tin
                    string query = "SELECT MaDocGia, TenDocGia, DiaChi, SoThe, Username, Password FROM DocGia WHERE SoDienThoai = @PhoneNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())  // Kiểm tra xem có dữ liệu trả về hay không
                            {
                                // Hiển thị thông tin trên các TextBox
                                textBox2.Text = reader["TenDocGia"].ToString().Trim();
                                textBox3.Text = reader["DiaChi"].ToString().Trim();
                                textBox4.Text = reader["SoThe"].ToString().Trim();
                                textBox5.Text = reader["Username"].ToString().Trim();
                                textBox6.Text = reader["Password"].ToString().Trim();
                                textBox7.Text = reader["MaDocGia"].ToString().Trim();
                            }
                            else
                            {
                                MessageBox.Show("No information found. Please check your phone number again.");
                                // Đặt lại TextBox nếu không có dữ liệu
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                                textBox5.Text = "";
                                textBox6.Text = "";
                                textBox7.Text = "";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
                }
            }
        }
        private string originalName;
        private string originalAddress;
        private string originalPhoneNumber;
        private string originalUsername;
        private string originalPassword;




        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlXua = "UPDATE DocGia SET TenDocGia = @TenDocGia, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, SoThe = @SoThe, Username = @Username, Password = @Password WHERE MaDocGia = @MaDocGia";
                SqlCommand cmd = new SqlCommand(sqlXua, con);
                cmd.Parameters.AddWithValue("@MaDocGia", textBox7.Text);
                cmd.Parameters.AddWithValue("@TenDocGia", textBox2.Text);
                cmd.Parameters.AddWithValue("@DiaChi", textBox3.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", textBox1.Text);
                cmd.Parameters.AddWithValue("@SoThe", textBox4.Text);
                cmd.Parameters.AddWithValue("@Username", textBox5.Text);
                cmd.Parameters.AddWithValue("@Password", textBox6.Text);

                // Track changes
                List<string> changes = new List<string>();

                if (!string.IsNullOrEmpty(textBox2.Text) && textBox2.Text != originalName)
                {
                    changes.Add($"Tên đã thay đổi : {originalName} {textBox2.Text}");
                }

                if (!string.IsNullOrEmpty(textBox3.Text) && textBox3.Text != originalAddress)
                {
                    changes.Add($"Địa chỉ đã thay đổi : {originalAddress} {textBox3.Text}");
                }

                if (!string.IsNullOrEmpty(textBox1.Text) && textBox1.Text != originalPhoneNumber)
                {
                    changes.Add($"Số điện thoại đã thay đổi : { originalPhoneNumber} {textBox1.Text}");
                }

                if (!string.IsNullOrEmpty(textBox5.Text) && textBox5.Text != originalUsername)
                {
                    changes.Add($"Username đã thay đổi : {originalUsername} {textBox5.Text}");
                }

                if (!string.IsNullOrEmpty(textBox6.Text) && textBox6.Text != originalPassword)
                {
                    changes.Add($"Password đã thay đổi : {originalPassword} {textBox6.Text}");
                }

                if (changes.Count > 0)
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        string changeMessage = string.Join(Environment.NewLine, changes);
                        MessageBox.Show($"Cập nhật thành công! {Environment.NewLine}{changeMessage}");
                    }
                    else
                    {
                        MessageBox.Show("Không có bản ghi nào được cập nhật. Vui lòng kiểm tra thông tin và thử lại.");
                    }
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào được thực hiện.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}");
            }
        }
    }
}
