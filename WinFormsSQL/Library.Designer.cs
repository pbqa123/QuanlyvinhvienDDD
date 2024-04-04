namespace WinFormsSQL
{
    partial class Library
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
            viewBookToolStripMenuItem = new ToolStripMenuItem();
            watchInformationToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { viewBookToolStripMenuItem, watchInformationToolStripMenuItem, logOutToolStripMenuItem, exitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1118, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // viewBookToolStripMenuItem
            // 
            viewBookToolStripMenuItem.BackColor = Color.AliceBlue;
            viewBookToolStripMenuItem.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            viewBookToolStripMenuItem.ForeColor = Color.Blue;
            viewBookToolStripMenuItem.Image = Properties.Resources.pngtree_book_icon_cartoon_style_png_image_19108262;
            viewBookToolStripMenuItem.Name = "viewBookToolStripMenuItem";
            viewBookToolStripMenuItem.Size = new Size(107, 24);
            viewBookToolStripMenuItem.Text = "View Book";
            viewBookToolStripMenuItem.Click += viewBookToolStripMenuItem_Click;
            // 
            // watchInformationToolStripMenuItem
            // 
            watchInformationToolStripMenuItem.BackColor = Color.AliceBlue;
            watchInformationToolStripMenuItem.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            watchInformationToolStripMenuItem.ForeColor = Color.Blue;
            watchInformationToolStripMenuItem.Image = Properties.Resources.images2;
            watchInformationToolStripMenuItem.Name = "watchInformationToolStripMenuItem";
            watchInformationToolStripMenuItem.Size = new Size(158, 24);
            watchInformationToolStripMenuItem.Text = "Watch information";
            watchInformationToolStripMenuItem.Click += watchInformationToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.BackColor = Color.AliceBlue;
            logOutToolStripMenuItem.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            logOutToolStripMenuItem.ForeColor = Color.Blue;
            logOutToolStripMenuItem.Image = Properties.Resources.pngtree_vector_logout_icon_png_image_10232611;
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(90, 24);
            logOutToolStripMenuItem.Text = "Log out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.BackColor = Color.AliceBlue;
            exitToolStripMenuItem.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            exitToolStripMenuItem.ForeColor = Color.Blue;
            exitToolStripMenuItem.Image = Properties.Resources.pngtree_exit_close_button_for_game_user_interface_icon_png_image_3806346;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(65, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // Library
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 526);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            Name = "Library";
            Text = "Library";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem viewBookToolStripMenuItem;
        private ToolStripMenuItem watchInformationToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}