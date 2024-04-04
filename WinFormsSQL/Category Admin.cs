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
    public partial class Category_Admin : Form
    {
        public Category_Admin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        SqlConnection con;

        private void Category_Admin_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-D108EA3\PBQA;Initial Catalog=ppppp;Integrated Security=True");
            con.Open();
            Hienthi();

        }
        public void Hienthi()
        {
            string sqlSelect = "SELECT * FROM TheLoai ";
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

            textBox1.Text = selectedRow.Cells["MaTheLoai"].Value.ToString();
            textBox2.Text = selectedRow.Cells["TenTheLoai"].Value.ToString();
            //Khai báo một biến ngàyMuon để lưu giữ giá trị DateTime
            DateTime ngayMuon;
        }
    }
}
