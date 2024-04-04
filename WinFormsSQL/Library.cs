using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsSQL
{
    public partial class Library : Form
    {
        public Library()
        {
            InitializeComponent();
        }

        private void viewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_book form = new View_book();
            form.MdiParent = this;
            form.Show();
        }

        private void watchInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Watch_information form = new Watch_information();
            form.MdiParent = this;
            form.Show();
        }

        private void borrowedAndReturnedBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History_book form = new History_book();
            form.MdiParent = this;
            form.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
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
