namespace WinFormsSQL
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            bookManagementToolStripMenuItem = new ToolStripMenuItem();
            readerManagementToolStripMenuItem = new ToolStripMenuItem();
            libraryCardToolStripMenuItem = new ToolStripMenuItem();
            readerManagementToolStripMenuItem1 = new ToolStripMenuItem();
            categoryManagementToolStripMenuItem = new ToolStripMenuItem();
            categoryToolStripMenuItem = new ToolStripMenuItem();
            publishingCompanyToolStripMenuItem = new ToolStripMenuItem();
            libraryLoanManagementToolStripMenuItem = new ToolStripMenuItem();
            borrowBooksToolStripMenuItem = new ToolStripMenuItem();
            returnBooksToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { bookManagementToolStripMenuItem, readerManagementToolStripMenuItem, categoryManagementToolStripMenuItem, libraryLoanManagementToolStripMenuItem, logOutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1155, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // bookManagementToolStripMenuItem
            // 
            bookManagementToolStripMenuItem.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            bookManagementToolStripMenuItem.ForeColor = Color.Blue;
            bookManagementToolStripMenuItem.Image = Properties.Resources.pngtree_book_icon_cartoon_style_png_image_1910826;
            bookManagementToolStripMenuItem.Name = "bookManagementToolStripMenuItem";
            bookManagementToolStripMenuItem.Size = new Size(158, 24);
            bookManagementToolStripMenuItem.Text = "Book management";
            bookManagementToolStripMenuItem.Click += bookManagementToolStripMenuItem_Click;
            // 
            // readerManagementToolStripMenuItem
            // 
            readerManagementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { libraryCardToolStripMenuItem, readerManagementToolStripMenuItem1 });
            readerManagementToolStripMenuItem.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            readerManagementToolStripMenuItem.ForeColor = Color.Blue;
            readerManagementToolStripMenuItem.Image = Properties.Resources.images1;
            readerManagementToolStripMenuItem.Name = "readerManagementToolStripMenuItem";
            readerManagementToolStripMenuItem.Size = new Size(169, 24);
            readerManagementToolStripMenuItem.Text = "Reader Management";
            readerManagementToolStripMenuItem.Click += readerManagementToolStripMenuItem_Click;
            // 
            // libraryCardToolStripMenuItem
            // 
            libraryCardToolStripMenuItem.ForeColor = Color.Blue;
            libraryCardToolStripMenuItem.Name = "libraryCardToolStripMenuItem";
            libraryCardToolStripMenuItem.Size = new Size(224, 26);
            libraryCardToolStripMenuItem.Text = "Library card";
            libraryCardToolStripMenuItem.Click += libraryCardToolStripMenuItem_Click;
            // 
            // readerManagementToolStripMenuItem1
            // 
            readerManagementToolStripMenuItem1.Name = "readerManagementToolStripMenuItem1";
            readerManagementToolStripMenuItem1.Size = new Size(224, 26);
            // 
            // categoryManagementToolStripMenuItem
            // 
            categoryManagementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoryToolStripMenuItem, publishingCompanyToolStripMenuItem });
            categoryManagementToolStripMenuItem.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            categoryManagementToolStripMenuItem.ForeColor = Color.Blue;
            categoryManagementToolStripMenuItem.Image = Properties.Resources.pngtree_system_good_icon_with_line_style_vector_illustration_png_image_876747;
            categoryManagementToolStripMenuItem.Name = "categoryManagementToolStripMenuItem";
            categoryManagementToolStripMenuItem.Size = new Size(142, 24);
            categoryManagementToolStripMenuItem.Text = "Manage authors";
            categoryManagementToolStripMenuItem.Click += categoryManagementToolStripMenuItem_Click;
            // 
            // categoryToolStripMenuItem
            // 
            categoryToolStripMenuItem.ForeColor = Color.Blue;
            categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            categoryToolStripMenuItem.Size = new Size(224, 26);
            categoryToolStripMenuItem.Text = "Category";
            categoryToolStripMenuItem.Click += categoryToolStripMenuItem_Click;
            // 
            // publishingCompanyToolStripMenuItem
            // 
            publishingCompanyToolStripMenuItem.ForeColor = Color.Blue;
            publishingCompanyToolStripMenuItem.Name = "publishingCompanyToolStripMenuItem";
            publishingCompanyToolStripMenuItem.Size = new Size(224, 26);
            publishingCompanyToolStripMenuItem.Text = "Publishing company";
            // 
            // libraryLoanManagementToolStripMenuItem
            // 
            libraryLoanManagementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { borrowBooksToolStripMenuItem, returnBooksToolStripMenuItem });
            libraryLoanManagementToolStripMenuItem.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            libraryLoanManagementToolStripMenuItem.ForeColor = Color.Blue;
            libraryLoanManagementToolStripMenuItem.Image = Properties.Resources.images__2_;
            libraryLoanManagementToolStripMenuItem.Name = "libraryLoanManagementToolStripMenuItem";
            libraryLoanManagementToolStripMenuItem.Size = new Size(205, 24);
            libraryLoanManagementToolStripMenuItem.Text = "Library Loan Management";
            libraryLoanManagementToolStripMenuItem.Click += libraryLoanManagementToolStripMenuItem_Click;
            // 
            // borrowBooksToolStripMenuItem
            // 
            borrowBooksToolStripMenuItem.BackColor = Color.AliceBlue;
            borrowBooksToolStripMenuItem.ForeColor = Color.Blue;
            borrowBooksToolStripMenuItem.Name = "borrowBooksToolStripMenuItem";
            borrowBooksToolStripMenuItem.Size = new Size(267, 26);
            borrowBooksToolStripMenuItem.Text = "Borrow books";
            borrowBooksToolStripMenuItem.Click += borrowBooksToolStripMenuItem_Click;
            // 
            // returnBooksToolStripMenuItem
            // 
            returnBooksToolStripMenuItem.ForeColor = Color.Blue;
            returnBooksToolStripMenuItem.Name = "returnBooksToolStripMenuItem";
            returnBooksToolStripMenuItem.Size = new Size(267, 26);
            returnBooksToolStripMenuItem.Text = "Loan and Repayment Details";
            returnBooksToolStripMenuItem.Click += returnBooksToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            logOutToolStripMenuItem.ForeColor = Color.Blue;
            logOutToolStripMenuItem.Image = Properties.Resources.pngtree_vector_logout_icon_png_image_1023261;
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(90, 24);
            logOutToolStripMenuItem.Text = "Log out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // guna2ContextMenuStrip1
            // 
            guna2ContextMenuStrip1.ImageScalingSize = new Size(20, 20);
            guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            guna2ContextMenuStrip1.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            guna2ContextMenuStrip1.RenderStyle.BorderColor = Color.Gainsboro;
            guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = Color.White;
            guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = Color.White;
            guna2ContextMenuStrip1.RenderStyle.SeparatorColor = Color.Gainsboro;
            guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            guna2ContextMenuStrip1.Size = new Size(61, 4);
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1155, 551);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Admin";
            Text = "Admin";
            Load += Admin_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem bookManagementToolStripMenuItem;
        private ToolStripMenuItem readerManagementToolStripMenuItem;
        private ToolStripMenuItem categoryManagementToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private ToolStripMenuItem libraryLoanManagementToolStripMenuItem;
        private ToolStripMenuItem borrowBooksToolStripMenuItem;
        private ToolStripMenuItem returnBooksToolStripMenuItem;
        private ToolStripMenuItem libraryCardToolStripMenuItem;
        private ToolStripMenuItem readerManagementToolStripMenuItem1;
        private ToolStripMenuItem categoryToolStripMenuItem;
        private ToolStripMenuItem publishingCompanyToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
    }
}