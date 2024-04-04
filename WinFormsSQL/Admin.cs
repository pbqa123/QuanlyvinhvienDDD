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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void bookManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Book_management form = new Book_management();
            form.MdiParent = this;
            form.Show();
        }

        private void readerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reader_Management form = new Reader_Management();
            form.MdiParent = this;
            form.Show();
        }

        private void categoryManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Author_Genres form = new Author_Genres();
            form.MdiParent = this;
            form.Show();
        }

        private void libraryLoanManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void borrowBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoanAdmin form = new LoanAdmin();
            form.MdiParent = this;
            form.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Return_Book from = new Return_Book();
            from.MdiParent = this;
            from.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void libraryCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Library_card from = new Library_card();
            from.MdiParent = this;
            from.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category_Admin from = new Category_Admin();
            from.MdiParent = this;
            from.Show();
        }
    }
}
