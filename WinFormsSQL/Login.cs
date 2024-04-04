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
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsSQL
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            SqlConnection com = new SqlConnection(@"Data Source=DESKTOP-D108EA3\PBQA;Initial Catalog=ppppp;Integrated Security=True");

        }     
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection com = new SqlConnection(@"Data Source=DESKTOP-D108EA3\PBQA;Initial Catalog=ppppp;Integrated Security=True");
            try
            {
                com.Open();
                string user = textBox1.Text;
                string pass = textBox2.Text;

                // Sử dụng câu truy vấn tham số để ngăn chặn tấn công SQL injection
                string sql = "SELECT * FROM DocGia WHERE Username = @username AND Password = @password";
                string sql2 = "SELECT * FROM NhanVien WHERE Username = @username AND Password = @password";

                SqlCommand cmd = new SqlCommand(sql, com);
                cmd.Parameters.AddWithValue("@username", user);
                cmd.Parameters.AddWithValue("@password", pass);

                SqlDataReader dta = cmd.ExecuteReader();

                if (dta.Read())
                {
                    MessageBox.Show("Logged in successfully");
                    Library userForm = new Library();
                    this.Hide();
                    userForm.Show();
                }
                else
                {
                    // Đóng data reader trước khi sử dụng lại
                    dta.Close();

                    SqlCommand cmd2 = new SqlCommand(sql2, com);
                    cmd2.Parameters.AddWithValue("@username", user);
                    cmd2.Parameters.AddWithValue("@password", pass);

                    SqlDataReader dta2 = cmd2.ExecuteReader();

                    if (dta2.Read())
                    {
                        MessageBox.Show("Login successfully with administrator ");
                        Admin adminForm = new Admin();
                        this.Hide();
                        adminForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login failed");
                    }

                    dta2.Close(); // Đóng data reader thứ hai
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            finally
            {
                com.Close();
            }
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

        private void label5_Click(object sender, EventArgs e)
        {
            Forgot_Password form = new Forgot_Password();
            form.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Create_Acc form = new Create_Acc();
            form.Show();
            this.Hide();
        }
    }
}
